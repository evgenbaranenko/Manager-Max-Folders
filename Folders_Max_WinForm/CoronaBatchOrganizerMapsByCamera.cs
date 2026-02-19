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

            var files = Directory.GetFiles(sourceFolder, "*.*", SearchOption.TopDirectoryOnly);

            if (files.Length == 0)
                throw new Exception("В папке нет файлов для обработки.");

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
                string targetPath = null;

                // 🔹 1. LightMix ВСЕГДА в корень новой папки
                if (fileName.Contains("LightMix", StringComparison.OrdinalIgnoreCase))
                {
                    targetPath = Path.Combine(rootFolder, fileName);
                }
                else
                {
                    string cameraNumber = ExtractCameraNumber(fileName);

                    if (cameraNumber != null)
                    {
                        string targetFolder = Path.Combine(rootFolder, cameraNumber);

                        if (!Directory.Exists(targetFolder))
                            Directory.CreateDirectory(targetFolder);

                        targetPath = Path.Combine(targetFolder, fileName);
                    }
                }

                if (targetPath == null)
                    continue;

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



        private static string ExtractCameraKey(string fileName)
        {
            if (fileName.StartsWith("SCV_", StringComparison.OrdinalIgnoreCase))
            {
                var parts = fileName.Split('_');
                if (parts.Length >= 2)
                    return parts[0] + "_" + parts[1];
            }

            var match = System.Text.RegularExpressions.Regex.Match(fileName, @"^(\d{2})_");
            if (match.Success)
                return match.Groups[1].Value;

            return null;
        }
        // 🔥 Универсальный парсер камеры
        private static string GetCameraNumber(string fileName)
        {
            /*
             Поддерживает:
             SCV_010
             SCV_010_***
             SCV_010000
             любые дополнительные префиксы
            */

            var match = Regex.Match(fileName, @"SCV_(\d{3})");

            if (match.Success)
                return match.Groups[1].Value;

            return null;
        }
        private static string ExtractCameraNumber(string fileName)
        {
            string name = Path.GetFileNameWithoutExtension(fileName);

            // 🔹 Новый формат SCV_01_...
            if (name.StartsWith("SCV_", StringComparison.OrdinalIgnoreCase))
            {
                var parts = name.Split('_');
                if (parts.Length > 1 && int.TryParse(parts[1], out int scvNum))
                    return scvNum.ToString("D2");
            }

            // 🔹 Старый формат 01_...
            if (name.Length >= 2 && int.TryParse(name.Substring(0, 2), out int oldNum))
                return oldNum.ToString("D2");

            // 🔹 Формат 010000
            if (name.Length >= 2 && int.TryParse(name.Substring(0, 2), out int numericOnly))
                return numericOnly.ToString("D2");

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
