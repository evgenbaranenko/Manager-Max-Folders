using System;
using System.IO;
using System.Text.Json;

namespace Folders_Max_WinForm
{
    public record AppSettings
    {
        public string PhotoshopPath { get; set; } = string.Empty;
    }

    public static class SettingsManager
    {
        private static readonly string AppFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FoldersMaxTool");

        private static readonly string SettingsFile = Path.Combine(AppFolder, "settings.json");

        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public static AppSettings Load()
        {
            try
            {
                if (!File.Exists(SettingsFile))
                    return new AppSettings();

                var json = File.ReadAllText(SettingsFile);
                if (string.IsNullOrWhiteSpace(json)) return new AppSettings();

                return JsonSerializer.Deserialize<AppSettings>(json, JsonOptions) ?? new AppSettings();
            }
            catch
            {
                return new AppSettings();
            }
        }

        public static void Save(AppSettings settings)
        {
            try
            {
                Directory.CreateDirectory(AppFolder);
                var json = JsonSerializer.Serialize(settings, JsonOptions);
                var tmp = SettingsFile + ".tmp";
                File.WriteAllText(tmp, json);
                File.Move(tmp, SettingsFile, true);
            }
            catch
            {
                // ignore
            }
        }
    }
}
