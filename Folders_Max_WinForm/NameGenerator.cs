using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Folders_Max_WinForm
{
    public static class NameGenerator
    {
        /// <summary>
        /// Формирует итоговое имя папки на основе базового имени и опций.
        /// </summary>
        /// <param name="basePath">Путь к каталогу, где создаются папки (требуется только при включённой нумерации).</param>
        /// <param name="baseName">Базовое имя проекта (непустое).</param>
        /// <param name="addNumber">Добавлять ли порядковый номер в начало.</param>
        /// <param name="addDate">Добавлять ли дату в конец в формате dd-MM-yy.</param>
        /// <returns>Сформированное имя папки.</returns>
        /// <exception cref="ArgumentException">Если baseName пуст или null.</exception>
        public static string GenerateFinalName(string basePath, string baseName, bool addNumber, bool addDate)
        {
            if (string.IsNullOrWhiteSpace(baseName))
                throw new ArgumentException("Base name must be provided", nameof(baseName));

            string finalName = baseName.Trim();

            if (addNumber)
            {
                int nextNumber = GetNextProjectNumber(basePath);
                finalName = $"{nextNumber:D2}_{finalName}";
            }

            if (addDate)
            {
                string date = DateTime.Now.ToString("dd-MM-yy", CultureInfo.InvariantCulture);
                finalName += $"_({date})";
            }

            return finalName;
        }

        private static int GetNextProjectNumber(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("Base path must be provided when numbering is requested", nameof(basePath));

            if (!Directory.Exists(basePath))
                throw new DirectoryNotFoundException($"Directory not found: {basePath}");

            // Выбираем сигнатуры папок, у которых имя начинается с числа и символа '_',
            // парсим ведущую часть и берём максимум.
            int max = Directory
                .GetDirectories(basePath)
                .Select(Path.GetFileName)
                .Select(name => TryParseLeadingNumber(name, out var n) ? n : 0)
                .DefaultIfEmpty(0)
                .Max();

            return max + 1;
        }

        private static bool TryParseLeadingNumber(string folderName, out int number)
        {
            number = 0;
            if (string.IsNullOrEmpty(folderName))
                return false;

            var parts = folderName.Split('_');
            if (parts.Length == 0)
                return false;

            return int.TryParse(parts[0], out number);
        }
    }
}