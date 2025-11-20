using Microsoft.ML;
using ML_2025.Models;
using ML_2025.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// CONFIGURAR LOGSERVICE AQUI
LogService.Configurar(builder.Environment.WebRootPath);

LogService.Registrar("Sistema", "Inicialização", "Aplicação iniciada", "127.0.0.1");

var pastaModelos = Path.Combine(AppContext.BaseDirectory, "MLModels");
if (!File.Exists(Path.Combine(pastaModelos, "model.zip")))
    ModelBuilder.Treinar(pastaModelos);

var mlContext = new MLContext();
var modelPath = Path.Combine(pastaModelos, "model.zip");
var model = mlContext.Model.Load(modelPath, out _);
var engine = mlContext.Model.CreatePredictionEngine<Produto, ProductPrediction>(model);

builder.Services.AddSingleton(engine);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapPost("/predict", (CompareRequest request, PredictionEngine<Produto, ProductPrediction> engine) =>
{
    var prediction = engine.Predict(new Produto { Text = request.Text });

    LogService.Registrar(
        "Usuário",
        "Predição",
        $"Texto recebido: {request.Text}",
        "127.0.0.1"
    );

    return Results.Ok(prediction);
});

app.Run();
