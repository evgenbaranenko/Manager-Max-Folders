using System.Collections.Generic;
using System.Text.Json;
namespace Folders_Max_WinForm
{
    public class BatchOperationLog
    {
        public string OriginalFolder { get; set; }
        public string SortedRootFolder { get; set; }
        public List<FileMoveInfo> Files { get; set; } = new();
    }

    public class FileMoveInfo
    {
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}