using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Folders_Max_WinForm
{
    public class CoronaBatchOrganizerMapsByMaps
    {
        public static void Organize(string sourceFolder)
        {
            if (!Directory.Exists(sourceFolder))
                throw new Exception("Папка не существует");

            var files = Directory.GetFiles(sourceFolder, "*.*", SearchOption.TopDirectoryOnly);

            if (files.Length == 0)
                throw new Exception("В папке нет файлов для сортировки.");

            var validFiles = files
                .Where(f => TryGetFolderName(Path.GetFileName(f), out _))
                .ToList();

            if (!validFiles.Any())
                throw new Exception("Нет файлов подходящих под формат 00_Name0000.");

            string parentFolder = Directory.GetParent(sourceFolder)?.FullName;

            if (parentFolder == null)
                throw new Exception("Невозможно определить родительскую папку.");

            string rootFolder = CreateRootFolder(parentFolder);

            foreach (var file in validFiles)
            {
                string fileName = Path.GetFileName(file);

                if (!TryGetFolderName(fileName, out string folderName))
                    continue;

                string targetFolder = Path.Combine(rootFolder, folderName);

                if (!Directory.Exists(targetFolder))
                    Directory.CreateDirectory(targetFolder);

                string targetPath = Path.Combine(targetFolder, fileName);

                if (!File.Exists(targetPath))
                    File.Move(file, targetPath);
            }
        }

        private static bool TryGetFolderName(string fileName, out string folderName)
        {
            folderName = null;

            if (fileName.Length < 4)
                return false;

            if (!int.TryParse(fileName.Substring(0, 2), out _))
                return false;

            if (fileName[2] != '_')
                return false;

            string withoutPrefix = fileName.Substring(3);
            string nameWithoutExt = Path.GetFileNameWithoutExtension(withoutPrefix);

            // убираем хвостовые цифры
            string cleaned = Regex.Replace(nameWithoutExt, @"\d+$", "");

            if (string.IsNullOrWhiteSpace(cleaned))
                return false;

            folderName = cleaned.Trim();

            return true;
        }

        private static string CreateRootFolder(string parentFolder)
        {
            var existing = Directory.GetDirectories(parentFolder)
                .Select(Path.GetFileName)
                .Where(name =>
                    name.Length >= 2 &&
                    int.TryParse(name.Substring(0, 2), out _))
                .ToList();

            int max = 0;

            foreach (var folder in existing)
            {
                if (int.TryParse(folder.Substring(0, 2), out int number))
                    if (number > max)
                        max = number;
            }

            int nextNumber = max + 1;

            string date = DateTime.Now.ToString("dd-MM-yy");
            string newFolderName = $"{nextNumber:D2}_{date}";

            string fullPath = Path.Combine(parentFolder, newFolderName);

            Directory.CreateDirectory(fullPath);

            return fullPath;
        }
    }
}
