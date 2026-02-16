using System;
using System.IO;
using System.Linq;

namespace Folders_Max_WinForm
{
    public class CoronaBatchOrganizer
    {
        public static void Organize(string sourceFolder)
        {
            if (!Directory.Exists(sourceFolder))
                throw new Exception("Папка не существует");

            string parentFolder = Path.GetDirectoryName(sourceFolder);

            string rootFolder = CreateRootFolder(parentFolder);

            var files = Directory.GetFiles(sourceFolder);

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);

                // 1️⃣ LightMix оставляем в корне
                if (fileName.Contains("Interactive LightMix"))
                {
                    File.Move(file, Path.Combine(rootFolder, fileName));
                    continue;
                }

                // 2️⃣ Остальные распределяем по номеру
                string prefix = GetPrefixNumber(fileName);

                if (prefix != null)
                {
                    string targetFolder = Path.Combine(rootFolder, prefix);
                    Directory.CreateDirectory(targetFolder);

                    File.Move(file, Path.Combine(targetFolder, fileName));
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
