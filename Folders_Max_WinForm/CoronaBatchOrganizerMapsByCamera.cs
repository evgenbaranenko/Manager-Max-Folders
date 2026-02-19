using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Folders_Max_WinForm
{
    public class CoronaBatchOrganizerMapsByCamera
    {
        public static string Organize(
     string sourceFolder,
     string destinationFolder,
     bool addDate,
     bool addNumber)
        {
            if (!Directory.Exists(sourceFolder))
                throw new Exception("Папка не существует");

            var files = Directory.GetFiles(sourceFolder);

            if (files.Length == 0)
                throw new Exception("В папке нет файлов.");

            string rootFolder = CreateRootFolder(
                destinationFolder,
                sourceFolder,
                addDate,
                addNumber
            );

            var log = new BatchOperationLog
            {
                OriginalFolder = sourceFolder
            };

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string targetFolder = null;

                // 🔥 1️⃣ Все LightMix в отдельную папку
                if (fileName.Contains("LightMix", StringComparison.OrdinalIgnoreCase))
                {
                    targetFolder = Path.Combine(rootFolder, "LightMix");
                }
                else
                {
                    // 🔥 2️⃣ Определяем камеру (SCV_001, SCV_010 и т.д.)
                    string cameraName = GetCameraPrefix(fileName);

                    if (!string.IsNullOrWhiteSpace(cameraName))
                    {
                        targetFolder = Path.Combine(rootFolder, cameraName);
                    }
                    else
                    {
                        // 🔥 3️⃣ Если не удалось определить — в папку 0000
                        targetFolder = Path.Combine(rootFolder, "0000");
                    }
                }

                Directory.CreateDirectory(targetFolder);

                string targetPath = Path.Combine(targetFolder, fileName);

                if (!File.Exists(targetPath))
                {
                    File.Move(file, targetPath);

                    log.Files.Add(new FileMoveInfo
                    {
                        Source = file,
                        Destination = targetPath
                    });
                }
            }

            BatchHistoryManager.SaveOperation(log, rootFolder);

            return rootFolder;
        }
        private static string GetCameraPrefix(string fileName)
        {
            // SCV_001_...
            if (fileName.StartsWith("SCV_", StringComparison.OrdinalIgnoreCase))
            {
                var parts = fileName.Split('_');

                if (parts.Length >= 2)
                    return $"SCV_{parts[1]}";
            }

            return null;
        }


        private static string CreateRootFolder(
            string destinationFolder,
            string sourceFolder,
            bool addDate,
            bool addNumber)
        {
            destinationFolder = Path.GetFullPath(destinationFolder);
            sourceFolder = Path.GetFullPath(sourceFolder);

            string sourceFolderName = new DirectoryInfo(sourceFolder).Name;

            string baseName = $"{sourceFolderName} - Maps By Camera";

            string folderName = NameGenerator.GenerateFinalName(
                destinationFolder,
                baseName,
                addNumber,
                addDate
            );

            string fullPath = Path.Combine(destinationFolder, folderName);

            Directory.CreateDirectory(fullPath);

            return fullPath;
        }
    }
}
