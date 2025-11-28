using Microsoft.ML;
using ML_2025.Models;
using ML_2025.Services;   
using System.IO;

namespace ML_2025.Services
{
    public static class ModelBuilder
    {
        public static void Treinar(string pastaModelos)
        {
            var ml = new MLContext();

            var dataPath = Path.Combine(pastaModelos, "produtos_tecnologia_categorias_final.csv");

            var data = ml.Data.LoadFromTextFile<Produto>(
                dataPath,
                hasHeader: true,
                separatorChar: ';'
            );

            var pipeline = ml.Transforms.Text
                .FeaturizeText("Features", nameof(Produto.Text))
                .Append(ml.Transforms.Conversion.MapValueToKey("Label", nameof(Produto.Nome)))
                .Append(ml.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(ml.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(data);

            Directory.CreateDirectory(pastaModelos);
            ml.Model.Save(model, data.Schema, Path.Combine(pastaModelos, "model.zip"));
        }
    }
}