using System.Text.Json;


namespace Common {
    public sealed class ConfigManager<T> where T : class {
        static readonly ConfigManager<T> _instance = new();

        /// <summary>
        /// Get the singleton install
        /// </summary>
        public static ConfigManager<T> Instance => _instance;

        private readonly string file = $".{typeof(T).ToString().ToLower()}.json";

        public T Config { get; set; } = Activator.CreateInstance<T>();

        private ConfigManager() {
            if (File.Exists(file)) { Load(); } else { Save(); }
        }

        public void CreateNew() {
            Config = Activator.CreateInstance<T>();
            var fs = File.Create(file);
            JsonSerializer.Serialize(fs, Config);
            fs.Close();
        }

        public void Save() {
            var fs = File.OpenWrite(file);
            JsonSerializer.Serialize(fs, Config);
            fs.Close();
        }

        public void Load() {
            var fs = File.OpenRead(file);
            Config = JsonSerializer.Deserialize<T>(fs) ?? Activator.CreateInstance<T>();
            fs.Close();
        }

    }

    public class MqttConfig {
        public string Uri { get; set; } = "app.kennatech.vn";
        public int Port { get; set; } = 1883;
    }
}