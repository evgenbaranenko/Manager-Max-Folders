using System;
using System.IO;
using System.Linq;

namespace Folders_Max_WinForm
{
    public class CoronaBatchOrganizerMapsByCamera
    {
        public static void Organize(string sourceFolder)
        {
            if (!Directory.Exists(sourceFolder))
                throw new Exception("Папка не существует");

            var files = Directory.GetFiles(sourceFolder);

            if (files.Length == 0)
                throw new Exception("В папке нет файлов для обработки.");

            // Проверяем есть ли файлы, которые реально будем переносить
            bool hasValidFiles = files.Any(f =>
                Path.GetFileName(f).Contains("Interactive LightMix") ||
                GetPrefixNumber(Path.GetFileName(f)) != null);

            if (!hasValidFiles)
                throw new Exception("Нет файлов, подходящих для сортировки.");

            string parentFolder = Path.GetDirectoryName(sourceFolder);

            // 🔥 Создаём корневую папку ТОЛЬКО если есть что переносить
            string rootFolder = CreateRootFolder(parentFolder);

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);

                // LightMix остаётся в корне
                if (fileName.Contains("Interactive LightMix"))
                {
                    File.Move(file, Path.Combine(rootFolder, fileName));
                    continue;
                }

                string prefix = GetPrefixNumber(fileName);

                if (prefix != null)
                {
                    string targetFolder = Path.Combine(rootFolder, prefix);
                    Directory.CreateDirectory(targetFolder);

                    if (!File.Exists(Path.Combine(targetFolder, fileName)))
                    {
                        File.Move(file, Path.Combine(targetFolder, fileName));
                    }
                }
            }
        }


        private static string CreateRootFolder(string parentFolder)
        {
            var existing = Directory.GetDirectories(parentFolder)
                .Select(Path.GetFileName)
                .Where(x => x.Length >= 2 && int.TryParse(x.Substring(0, 2), out _))
                .ToList();

            int max = 0;

            foreach (var folder in existing)
            {
                if (int.TryParse(folder.Substring(0, 2), out int num))
                    if (num > max)
                        max = num;
            }

            int next = max + 1;

            string date = DateTime.Now.ToString("dd-MM-yy");
            string folderName = $"{next:D2}_{date}";

            string fullPath = Path.Combine(parentFolder, folderName);
            Directory.CreateDirectory(fullPath);

            return fullPath;
        }

        private static string GetPrefixNumber(string fileName)
        {
            if (fileName.Length < 2)
                return null;

            string firstTwo = fileName.Substring(0, 2);

            return int.TryParse(firstTwo, out _) ? firstTwo : null;
        }
    }
}
