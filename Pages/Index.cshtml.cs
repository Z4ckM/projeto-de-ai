using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.ML;
using Microsoft.ML;
using ML_2025.Models;
using ML_2025.Services;
using System.IO;

public class IndexModel : PageModel
{
    private readonly PredictionEngine<Produto, ProductPrediction> _predictionEngine;

    public IndexModel(PredictionEngine<Produto, ProductPrediction> predictionEngine)
    {
        _predictionEngine = predictionEngine;
    }

    public List<Produto> Resultados { get; set; }

    [BindProperty]
    public string InputText { get; set; }

    public ProductPrediction PredictionResult { get; set; }

    public void OnPost()
    {
        if (!string.IsNullOrWhiteSpace(InputText))
        {
            var input = new Produto { Text = InputText };
            PredictionResult = _predictionEngine.Predict(input);
        }
    }

    public IActionResult OnPostRating([FromBody] RatingInput dados)
    {
        string pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ratings");

        string nomeArquivo = $"ratings_.csv";

        string csv =
            $"ratings_.csv\n" +
             $"{dados.Input};{dados.Positivo}\r\n";

        string caminho = Path.Combine(pasta, nomeArquivo);

        if (!System.IO.File.Exists(caminho))
        {
            string cabecalho = "Input;Positivo" + Environment.NewLine;
            System.IO.File.WriteAllText(caminho, cabecalho);
        }
        string novaLinha = $"{dados.Input};{dados.Positivo}{Environment.NewLine}";
        System.IO.File.AppendAllText(caminho, novaLinha);

        return new JsonResult(new { sucesso = true, mensagem = "Obrigado pelo feedback!" });
    }
    public class RatingInput
    {
        public string Input { get; set; }
        public bool Positivo { get; set; }
    }
    public void OnGet()
    {
        LogService.Registrar("Usuário", "Acessou página", "Index.cshtml", "127.0.0.1");
    }


}
