using System.Text.Json;

namespace Logger.FileServices
{
    /// <summary>
    /// Service for working with configurations.
    /// </summary>
    internal static class ConfigService
    {
        private const string ConfigurationFileName = "\\configuration.json";
        private static string _pathToConfigurationalFile;

        static ConfigService()
        {
            _pathToConfigurationalFile = Path.GetFullPath(Directory.GetCurrentDirectory()) + ConfigurationFileName;
            if (!File.Exists(_pathToConfigurationalFile))
            {
                File.Create(_pathToConfigurationalFile);
            }
        }

        /// <summary>
        /// Gets log directory name.
        /// </summary>
        /// <returns>Directory name fron configuration or default name.</returns>
        /// <exception cref="FileNotFoundException">Throws when configuration file was not found.</exception>
        /// <exception cref="ArgumentException">Throws when the configuration file is empty.</exception>
        public static string GetLogDirectoryName()
        {
            if (!File.Exists(_pathToConfigurationalFile))
            {
                throw new FileNotFoundException($"There is no any {ConfigurationFileName}.");
            }

            var dataFrmoConfigFileInJsonFormat = File.ReadAllLines(_pathToConfigurationalFile);
            if (dataFrmoConfigFileInJsonFormat[0] == null)
            {
                throw new ArgumentException($"{ConfigurationFileName} is empty");
            }

            string? result = JsonSerializer.Deserialize<string>(dataFrmoConfigFileInJsonFormat[0]);
            if (result == null)
            {
                throw new ArgumentException($"Cannot deserialize content of the {ConfigurationFileName}");
            }

            return result;
        }
    }
}
