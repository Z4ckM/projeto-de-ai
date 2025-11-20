using Microsoft.ML;
using ML_2025.Models;
using ML_2025.Services;   // ← importante
using System.IO;

namespace ML_2025.Services
{
    public static class ModelBuilder
    {
        public static void Treinar(string MLModels)
        {
            LogService.Registrar("sistema", "Treinamento", "Iniciando treinamento", "127.0.0.1");

            var ml = new MLContext(seed: 1);

            var data = ml.Data.LoadFromTextFile<Produto>(
                Path.Combine(MLModels, "produtos_tecnologia_categorias_final.csv"),
                hasHeader: true,
                separatorChar: ';');

            var split = ml.Data.TrainTestSplit(data, testFraction: 0.2, seed: 1);

            var pipeline = ml.Transforms.Text.FeaturizeText("Features", nameof(Produto.Text))
                .Append(ml.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: nameof(Produto.Nome),
                    featureColumnName: "Features"));

            var model = pipeline.Fit(split.TrainSet);

            var caminhoModelo = Path.Combine(MLModels, "model.zip");
            ml.Model.Save(model, split.TrainSet.Schema, caminhoModelo);

            LogService.Registrar("sistema", "Treinamento", "Modelo treinado com sucesso", "127.0.0.1");
        }
    }
}
 