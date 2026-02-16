using System;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace Folders_Max_WinForm
{
    public class CoronaBatchOrganizerMapsByCamera
    {
   public static string Organize(string sourceFolder, bool addDate)
{
    if (!Directory.Exists(sourceFolder))
        throw new Exception("Папка не существует");

    var files = Directory.GetFiles(sourceFolder, "*.*", SearchOption.TopDirectoryOnly);

    if (files.Length == 0)
        throw new Exception("В папке нет файлов для обработки.");

    bool hasValidFiles = files.Any(f =>
        Path.GetFileName(f).Contains("Interactive LightMix") ||
        GetPrefixNumber(Path.GetFileName(f)) != null);

    if (!hasValidFiles)
        throw new Exception("Нет файлов подходящих для сортировки.");

    // Создаём корневую папку НА УРОВЕНЬ ВЫШЕ
    string parentFolder = Directory.GetParent(sourceFolder)?.FullName;

    if (parentFolder == null)
        throw new Exception("Невозможно определить родительскую папку.");

    string rootFolder = CreateRootFolder(parentFolder, addDate);

    // 🔥 Создаём лог операции
    var log = new BatchOperationLog
    {
        OriginalFolder = sourceFolder
    };

    foreach (var file in files)
    {
        string fileName = Path.GetFileName(file);

        string targetPath = null;

        // 1️⃣ LightMix остаётся в корне
        if (fileName.Contains("Interactive LightMix"))
        {
            targetPath = Path.Combine(rootFolder, fileName);
        }
        else
        {
            string prefix = GetPrefixNumber(fileName);

            if (prefix != null)
            {
                string targetFolder = Path.Combine(rootFolder, prefix);

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

            // 🔥 Логируем перемещение
            log.Files.Add(new FileMoveInfo
            {
                Source = file,
                Destination = targetPath
            });
        }
    }

    // 🔥 Сохраняем лог в .undo.json
    // string logPath = Path.Combine(rootFolder, ".undo.json");
    // var json = System.Text.Json.JsonSerializer.Serialize(log);

    BatchHistoryManager.SaveOperation(log, rootFolder);

    // File.WriteAllText(logPath, json);

    return rootFolder;
}
   
private static string CreateRootFolder(string parentFolder, bool addDate)
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

    string folderName = $"{nextNumber:D2}";

    if (addDate)
    {
        string date = DateTime.Now.ToString("dd-MM-yy");
        folderName += $"_{date}";
    }

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
