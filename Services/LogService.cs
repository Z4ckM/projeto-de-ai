using System;
using System.IO;

namespace ML_2025.Services
{
    public static class LogService
    {
        private static string _pastaLogs = "";

        public static void Configurar(string webRootPath)
        {
            _pastaLogs = Path.Combine(webRootPath, "logs");

            if (!Directory.Exists(_pastaLogs))
                Directory.CreateDirectory(_pastaLogs);
        }

        public static void Registrar(string usuario, string acao, string descricao, string ip)
        {
            if (string.IsNullOrEmpty(_pastaLogs))
                throw new Exception("LogService não foi configurado. Chame LogService.Configurar() no Program.cs.");

            string arquivo = Path.Combine(_pastaLogs, "logs.csv");

            string linha =
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},{usuario},{acao},\"{descricao}\",{ip}{Environment.NewLine}";

            File.AppendAllText(arquivo, linha);
        }
    }
}
