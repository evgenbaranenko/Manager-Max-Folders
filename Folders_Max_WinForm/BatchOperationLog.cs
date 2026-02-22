using System.Collections.Generic;
namespace Folders_Max_WinForm
{
    /// <summary>
    /// Запись об одной пакетной операции — исходная папка, результат сортировки и список перемещённых файлов.
    /// </summary>
    public record BatchOperationLog
    {
        /// <summary>Путь к исходной папке, откуда брались файлы.</summary>
        public string OriginalFolder { get; set; } = string.Empty;

        /// <summary>Путь к корню отсортированной папки, если она была создана.</summary>
        public string SortedRootFolder { get; set; } = string.Empty;

        /// <summary>Список перемещённых файлов и их целевых путей.</summary>
        public List<FileMoveInfo> Files { get; set; } = new();
    }

    /// <summary>
    /// Информация о перемещении одного файла: исходный путь и путь назначения.
    /// </summary>
    public record FileMoveInfo
    {
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
    }
}