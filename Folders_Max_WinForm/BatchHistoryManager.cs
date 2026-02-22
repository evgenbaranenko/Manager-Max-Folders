using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Folders_Max_WinForm
{
    public static class BatchHistoryManager
    {
        private static readonly string AppFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FoldersMaxTool");

        private static readonly string HistoryFile =
            Path.Combine(AppFolder, "operations.json");

        private static readonly object FileLock = new object();

        public static void SaveOperation(BatchOperationLog log, string sortedRootFolder)
        {
            if (log == null)
                throw new ArgumentNullException(nameof(log));

            Directory.CreateDirectory(AppFolder);

            lock (FileLock)
            {
                var operations = LoadAll();

                log.SortedRootFolder = sortedRootFolder;
                operations.Add(log);

                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(operations, options);

                // Write atomically
                var tempFile = HistoryFile + ".tmp";
                File.WriteAllText(tempFile, json);
                File.Copy(tempFile, HistoryFile, true);
                File.Delete(tempFile);
            }
        }

        public static void UndoLast()
        {
            lock (FileLock)
            {
                var operations = LoadAll();

                if (operations.Count == 0)
                    throw new InvalidOperationException("Нет операций для отмены.");

                var last = operations[^1];

                // Перемещаем файлы обратно в исходные позиции
                foreach (var file in last.Files)
                {
                    try
                    {
                        if (File.Exists(file.Destination))
                        {
                            var destDir = Path.GetDirectoryName(file.Source);
                            if (!string.IsNullOrEmpty(destDir) && !Directory.Exists(destDir))
                                Directory.CreateDirectory(destDir);

                            File.Move(file.Destination, file.Source);
                        }
                    }
                    catch
                    {
                        // Игнорируем отдельные ошибки перемещения, продолжая откат других файлов
                    }
                }

                try
                {
                    if (!string.IsNullOrWhiteSpace(last.SortedRootFolder) && Directory.Exists(last.SortedRootFolder))
                        Directory.Delete(last.SortedRootFolder, true);
                }
                catch
                {
                    // Игнорируем ошибки удаления папки
                }

                operations.RemoveAt(operations.Count - 1);

                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(operations, options);

                var tempFile = HistoryFile + ".tmp";
                File.WriteAllText(tempFile, json);
                File.Copy(tempFile, HistoryFile, true);
                File.Delete(tempFile);
            }
        }

        private static List<BatchOperationLog> LoadAll()
        {
            try
            {
                if (!File.Exists(HistoryFile))
                    return new List<BatchOperationLog>();

                var json = File.ReadAllText(HistoryFile);
                if (string.IsNullOrWhiteSpace(json))
                    return new List<BatchOperationLog>();

                return JsonSerializer.Deserialize<List<BatchOperationLog>>(json)
                       ?? new List<BatchOperationLog>();
            }
            catch
            {
                // Если файл повреждён или произошла ошибка чтения/десериализации — возвращаем пустой список
                return new List<BatchOperationLog>();
            }
        }
    }
}
