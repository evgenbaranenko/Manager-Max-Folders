
namespace Folders_Max_WinForm
{
    public class CoronaBatchUndoManager
    {
        public static void Undo(string sortedRootFolder)
        {
            if (!Directory.Exists(sortedRootFolder))
                throw new Exception("Папка сортировки не найдена.");

            string originalFolder = Directory.GetParent(sortedRootFolder)?.FullName;

            if (originalFolder == null)
                throw new Exception("Не удалось определить исходную папку.");

            var allFiles = Directory
                .GetFiles(sortedRootFolder, "*.*", SearchOption.AllDirectories);

            if (allFiles.Length == 0)
                throw new Exception("Нет файлов для восстановления.");

            foreach (var file in allFiles)
            {
                string fileName = Path.GetFileName(file);
                string targetPath = Path.Combine(originalFolder, fileName);

                if (!File.Exists(targetPath))
                    File.Move(file, targetPath);
            }

            // Удаляем корневую папку сортировки
            Directory.Delete(sortedRootFolder, true);
        }
    }
}