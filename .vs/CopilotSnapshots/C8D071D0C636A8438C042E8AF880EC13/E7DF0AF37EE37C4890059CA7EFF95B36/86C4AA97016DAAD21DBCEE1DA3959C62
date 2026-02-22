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

        public static void SaveOperation(BatchOperationLog log, string sortedRootFolder)
        {
            if (!Directory.Exists(AppFolder))
                Directory.CreateDirectory(AppFolder);

            var operations = LoadAll();

            log.SortedRootFolder = sortedRootFolder;

            operations.Add(log);

            var json = JsonSerializer.Serialize(operations);
            File.WriteAllText(HistoryFile, json);
        }

        public static void UndoLast()
        {
            var operations = LoadAll();

            if (operations.Count == 0)
                throw new Exception("Нет операций для отмены.");

            var last = operations[^1];

            foreach (var file in last.Files)
            {
                if (File.Exists(file.Destination))
                {
                    File.Move(file.Destination, file.Source);
                }
            }

            if (Directory.Exists(last.SortedRootFolder))
                Directory.Delete(last.SortedRootFolder, true);

            operations.RemoveAt(operations.Count - 1);

            var json = JsonSerializer.Serialize(operations);
            File.WriteAllText(HistoryFile, json);
        }

        private static List<BatchOperationLog> LoadAll()
        {
            if (!File.Exists(HistoryFile))
                return new List<BatchOperationLog>();

            var json = File.ReadAllText(HistoryFile);

            return JsonSerializer.Deserialize<List<BatchOperationLog>>(json)
                   ?? new List<BatchOperationLog>();
        }
    }
}
