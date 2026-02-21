using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Folders_Max_WinForm
{
    public class CoronaBatchOrganizerMapsByMaps
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
                throw new Exception("В папке нет файлов для сортировки.");

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

                string folderKey = GetFolderKey(fileName);

                if (folderKey == null)
                    continue;

                string targetFolder = Path.Combine(rootFolder, folderKey);

                if (!Directory.Exists(targetFolder))
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

        // ------------------------------------------------------------
        // 🔥 УНИВЕРСАЛЬНОЕ ОПРЕДЕЛЕНИЕ ПАПКИ
        // ------------------------------------------------------------
        private static string GetFolderKey(string fileName)
        {
            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

            string namePart = null;

            // --------------------------------------------------
            // 1️⃣ SCV_010  (без хвоста)
            // --------------------------------------------------
            if (Regex.IsMatch(nameWithoutExt, @"^SCV_\d{3}$"))
                return "0000";

            // --------------------------------------------------
            // 2️⃣ SCV_010_ЧтоТо
            // --------------------------------------------------
            var scvMatch = Regex.Match(nameWithoutExt, @"^SCV_\d{3}_(.*)");
            if (scvMatch.Success)
            {
                namePart = scvMatch.Groups[1].Value;
            }
            // --------------------------------------------------
            // 3️⃣ Новая система 01_CMasking_ID0000
            // --------------------------------------------------
            else if (nameWithoutExt.Length > 3 &&
                     int.TryParse(nameWithoutExt.Substring(0, 2), out _) &&
                     nameWithoutExt[2] == '_')
            {
                namePart = nameWithoutExt.Substring(3);
            }
            // --------------------------------------------------
            // 4️⃣ Только цифры
            // --------------------------------------------------
            else if (Regex.IsMatch(nameWithoutExt, @"^\d+$"))
            {
                return "0000";
            }

            if (string.IsNullOrWhiteSpace(namePart))
                return null;

            // 🔥 Удаляем цифры в конце
            namePart = Regex.Replace(namePart, @"\d+$", "");

            // 🔥 ГЛУБОКАЯ ОЧИСТКА
            namePart = namePart.Trim();
            namePart = namePart.Trim('_', '-', ' ');
            namePart = Regex.Replace(namePart, @"_{2,}", "_");
            namePart = Regex.Replace(namePart, @"\s{2,}", " ");

            if (string.IsNullOrWhiteSpace(namePart))
                return "0000";

            return namePart;
        }



        // ------------------------------------------------------------
        private static string CreateRootFolder(
            string destinationFolder,
            string sourceFolder,
            bool addDate,
            bool addNumber)
        {
            destinationFolder = Path.GetFullPath(destinationFolder);
            sourceFolder = Path.GetFullPath(sourceFolder);

            string sourceFolderName = new DirectoryInfo(sourceFolder).Name;

            string baseName = $"{sourceFolderName} - Maps By Maps";

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