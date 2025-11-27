using System;
using System.IO;
using System.Text.Json;

namespace DataAccess.Helpers
{
    internal static class ConfigProvider
    {
        private static JsonDocument? _doc;

        private static void EnsureLoaded()
        {
            if (_doc != null) return;
            // try common locations: application base directory (Presentation.exe folder)
            var baseDir = AppContext.BaseDirectory;
            var candidate = Path.Combine(baseDir, "appsettings.json");
            if (!File.Exists(candidate))
            {
                // also try one folder up in case running from bin\Debug\netX
                var parent = Path.GetDirectoryName(baseDir) ?? baseDir;
                candidate = Path.Combine(parent, "appsettings.json");
                if (!File.Exists(candidate))
                {
                    // last resort: current directory
                    candidate = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                }
            }
            if (!File.Exists(candidate)) return;
            try
            {
                var json = File.ReadAllText(candidate);
                _doc = JsonDocument.Parse(json);
            }
            catch
            {
                _doc = null;
            }
        }

        public static string GetConnectionString(string name)
        {
            EnsureLoaded();
            if (_doc == null) return string.Empty;
            try
            {
                if (_doc.RootElement.TryGetProperty("ConnectionStrings", out var cs) && cs.ValueKind == JsonValueKind.Object)
                {
                    if (cs.TryGetProperty(name, out var v)) return v.GetString() ?? string.Empty;
                }
            }
            catch { }
            return string.Empty;
        }
    }
}
