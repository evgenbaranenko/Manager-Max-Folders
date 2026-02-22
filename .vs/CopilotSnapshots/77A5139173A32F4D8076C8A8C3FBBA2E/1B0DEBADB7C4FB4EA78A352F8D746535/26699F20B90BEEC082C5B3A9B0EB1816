using System;
using System.IO;
using System.Linq;

namespace Folders_Max_WinForm
{
    public static class NameGenerator
    {
        public static string GenerateFinalName(
            string basePath,
            string baseName,
            bool addNumber,
            bool addDate)
        {
            string finalName = baseName;

            // 🔢 Нумерация
            if (addNumber)
            {
                int nextNumber = GetNextProjectNumber(basePath);
                finalName = $"{nextNumber:D2}_{finalName}";
            }

            // 📅 Дата
            if (addDate)
            {
                string date = DateTime.Now.ToString("dd-MM-yy");
                finalName += $"_({date})";
            }

            return finalName;
        }

        private static int GetNextProjectNumber(string basePath)
        {
            var directories = Directory.GetDirectories(basePath);

            int maxNumber = 0;

            foreach (var dir in directories)
            {
                string folderName = Path.GetFileName(dir);

                var parts = folderName.Split('_');

                if (parts.Length > 0 && int.TryParse(parts[0], out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }

            return maxNumber + 1;
        }
    }
}