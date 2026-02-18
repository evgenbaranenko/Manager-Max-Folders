using System;
using System.IO;
using System.Linq;
using System.Text.Json;
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

            var validFiles = files
                .Where(f => TryGetFolderName(Path.GetFileName(f), out _))
                .ToList();

            if (!validFiles.Any())
                throw new Exception("Нет файлов подходящих под формат 00_Name0000.");

            string parentFolder = destinationFolder;

            if (parentFolder == null)
                throw new Exception("Невозможно определить родительскую папку.");

            string rootFolder = CreateRootFolder(
                destinationFolder,
                sourceFolder,
                addDate,
                addNumber
            );


            // 🔥 Создаём лог операции
            var log = new BatchOperationLog
            {
                OriginalFolder = sourceFolder
            };

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
                {
                    File.Move(file, targetPath);

                    // 🔥 Логируем перемещение
                    log.Files.Add(new FileMoveInfo
                    {
                        Source = file,
                        Destination = targetPath
                    });
                }
            }

            // 🔥 Сохраняем лог
            
            BatchHistoryManager.SaveOperation(log, rootFolder);
            
            return rootFolder;
        }
        
        private static bool TryGetFolderName(string fileName, out string folderName)
        {
            folderName = null;

            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

            // 1️⃣ Если имя состоит только из цифр → кладём в папку 000000
            if (Regex.IsMatch(nameWithoutExt, @"^\d+$"))
            {
                folderName = "000000";
                return true;
            }

            // 2️⃣ Если формат 05_Name0000
            if (fileName.Length < 4)
                return false;

            if (!int.TryParse(fileName.Substring(0, 2), out _))
                return false;

            if (fileName[2] != '_')
                return false;

            string withoutPrefix = fileName.Substring(3);

            string cleaned = Regex.Replace(
                Path.GetFileNameWithoutExtension(withoutPrefix),
                @"\d+$",
                ""
            );

            if (string.IsNullOrWhiteSpace(cleaned))
                return false;

            folderName = cleaned.Trim();

            return true;
        }

        private static string CreateRootFolder(
            string destinationFolder,
            string sourceFolder,
            bool addDate,
            bool addNumber)
        {
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
