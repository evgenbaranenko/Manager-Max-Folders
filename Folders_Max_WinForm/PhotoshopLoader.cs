using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Folders_Max_WinForm
{
    public static class PhotoshopLoader
    {
        public static void LoadFolderIntoStack(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                throw new Exception(MessageText.FolderNotFound);

            string photoshopPath = GetPhotoshopPath();

            if (string.IsNullOrWhiteSpace(photoshopPath) || !File.Exists(photoshopPath))
                throw new Exception(MessageText.PhotoshopNotFound);

            string jsxScript = GenerateJsx(folderPath);

            string tempPath = Path.Combine(Path.GetTempPath(), "loadToStack.jsx");
            File.WriteAllText(tempPath, jsxScript, Encoding.UTF8);

            Process.Start(new ProcessStartInfo
            {
                FileName = photoshopPath,
                Arguments = $"-r \"{tempPath}\"",
                UseShellExecute = true
            });
        }

        private static string GenerateJsx(string folderPath)
        {
            var folderForJs = folderPath.Replace("\\", "/");

            var lines = new[]
            {
                $"var folder = new Folder(\"{folderForJs}\");",
                "var files = folder.getFiles(/\\.(jpg|png|tif|tiff|exr)$/i);",
                "if(files.length > 0) {",
                "    files.sort();",

                "    var baseDoc = app.open(files[0]);",
                "    app.activeDocument = baseDoc;",

                "    var firstName = decodeURI(files[0].name).replace(/\\.[^\\.]+$/, '');",
                "    baseDoc.activeLayer.name = firstName;",

                "    for(var i=1; i<files.length; i++) {",
                "        var tempDoc = app.open(files[i]);",
                "        var layerName = decodeURI(files[i].name).replace(/\\.[^\\.]+$/, '');",
                "",
                "        try {",
                "            var duplicatedLayer = tempDoc.activeLayer.duplicate(baseDoc, ElementPlacement.PLACEATBEGINNING);",
                "",
                "            app.activeDocument = baseDoc;",
                "            baseDoc.activeLayer = duplicatedLayer;",
                "            duplicatedLayer.name = layerName;",
                "",
                "        } catch(e) {}",
                "",
                "        tempDoc.close(SaveOptions.DONOTSAVECHANGES);",
                "    }",
                "}"
            };

            return string.Join("\n", lines);
        }

        private static string GetPhotoshopPath()
        {
            var settings = SettingsManager.Load();

            if (!string.IsNullOrWhiteSpace(settings.PhotoshopPath) && File.Exists(settings.PhotoshopPath))
                return settings.PhotoshopPath;

            return string.Empty;
        }

        public static void CreatePsdFromFolder(string folderPath, string outputPsdPath)
        {
            if (!Directory.Exists(folderPath))
                throw new Exception(MessageText.FolderNotFound);

            string photoshopPath = GetPhotoshopPath();

            if (string.IsNullOrWhiteSpace(photoshopPath) || !File.Exists(photoshopPath))
                throw new Exception(MessageText.PhotoshopNotFound);

            var folderForJs = folderPath.Replace("\\", "/");
            var outForJs = outputPsdPath.Replace("\\", "/");

            var lines = new[]
            {
                $"var folder = new Folder(\"{folderForJs}\");",
                "var files = folder.getFiles(/\\.(jpg|png|tif|tiff|exr)$/i);",
                "if(files.length > 0) {",
                "    files.sort();",

                "    var baseDoc = app.open(files[0]);",
                "    app.activeDocument = baseDoc;",

                "    var firstName = decodeURI(files[0].name).replace(/\\.[^\\.]+$/, '');",
                "    baseDoc.activeLayer.name = firstName;",

                "    for(var i=1; i<files.length; i++) {",
                "        var tempDoc = app.open(files[i]);",
                "        var layerName = decodeURI(files[i].name).replace(/\\.[^\\.]+$/, '');",
                "",
                "        try {",
                "            var duplicatedLayer = tempDoc.activeLayer.duplicate(baseDoc, ElementPlacement.PLACEATBEGINNING);",
                "",
                "            app.activeDocument = baseDoc;",
                "            baseDoc.activeLayer = duplicatedLayer;",
                "            duplicatedLayer.name = layerName;",
                "",
                "        } catch(e) {}",
                "",
                "        tempDoc.close(SaveOptions.DONOTSAVECHANGES);",
                "    }",
                "",
                $"    var saveFile = new File(\"{outForJs}\");",
                "    var psdOptions = new PhotoshopSaveOptions();",
                "    baseDoc.saveAs(saveFile, psdOptions, true);",
                "    baseDoc.close(SaveOptions.DONOTSAVECHANGES);",
                "}"
            };

            string jsx = string.Join("\n", lines);

            string tempPath = Path.Combine(Path.GetTempPath(), "create_psd_" + Guid.NewGuid() + ".jsx");
            File.WriteAllText(tempPath, jsx, Encoding.UTF8);

            Process.Start(new ProcessStartInfo
            {
                FileName = photoshopPath,
                Arguments = $"-r \"{tempPath}\"",
                UseShellExecute = true
            });
        }
    }
}
