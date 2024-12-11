using System;
using System.IO;
using System.Text.Json; // Используем только System.Text.Json
using System.Text.Json.Serialization;

namespace Server.Data
{
    public class DataReader
    {
        public string? ConnectToDb { get; }
        public string? Telegram { get; }

        public DataReader(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);

            // Десериализуем весь JSON в объект ConfigRoot
            var configRoot = JsonSerializer.Deserialize<ConfigRoot>(jsonString);
            if (configRoot == null || configRoot.Database == null || configRoot.TelegramBot == null)
            {
                throw new ArgumentException("Invalid or missing configuration in the JSON file.");
            }

            Console.WriteLine($"Deserialized config: {configRoot.Database.Host}, {configRoot.Database.Port}, {configRoot.Database.Username}, {configRoot.Database.Database}");
            Console.WriteLine($"Deserialized telegram: {configRoot.TelegramBot.Token}");

            // Проверка на null или пустые строки
            if (string.IsNullOrEmpty(configRoot.Database.Host) ||
                string.IsNullOrEmpty(configRoot.Database.Port) ||
                string.IsNullOrEmpty(configRoot.Database.Username) ||
                string.IsNullOrEmpty(configRoot.Database.Password) ||
                string.IsNullOrEmpty(configRoot.Database.Database) ||
                string.IsNullOrEmpty(configRoot.TelegramBot.Token))
            {
                throw new ArgumentException("One or more connection parameters are missing in the config file.");
            }

            ConnectToDb = $"Host={configRoot.Database.Host};Port={configRoot.Database.Port};Username={configRoot.Database.Username};Password={configRoot.Database.Password};Database={configRoot.Database.Database}";
            Telegram = configRoot.TelegramBot.Token;
        }
    }

    public class ConfigRoot
    {
        [JsonPropertyName("Database")]
        public DataBaseConfig? Database { get; set; }

        [JsonPropertyName("TelegramBot")]
        public TelegramConfig? TelegramBot { get; set; }
    }

    public class DataBaseConfig
    {
        [JsonPropertyName("Host")]
        public string? Host { get; set; }

        [JsonPropertyName("Port")]
        public string? Port { get; set; }

        [JsonPropertyName("Username")]
        public string? Username { get; set; }

        [JsonPropertyName("Password")]
        public string? Password { get; set; }

        [JsonPropertyName("Database")]
        public string? Database { get; set; }
    }

    public class TelegramConfig
    {
        [JsonPropertyName("TELEGRAM_BOT_TOKEN")]
        public string? Token { get; set; }
    }
}
