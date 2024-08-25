using Newtonsoft.Json;
using ScadaAPI.Logic.Config.Models;

namespace ScadaAPI.Logic.Config;

/// <summary>
/// Represents the configuration settings for the application.
/// </summary>
public static class AppSettings
{
    /// <summary>
    /// Gets or sets the configuration instance.
    /// </summary>
    public static Configuration Configuration { get; private set; }

    static AppSettings()
    {
        Configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json")));
    }
}