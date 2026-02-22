using System;
using System.IO;

namespace Folders_Max_WinForm
{
    public static class ProjectTemplateCopier
    {
        /// <summary>
        /// Копирует структуру шаблона в новую папку с названием <paramref name="newProjectName"/> внутри <paramref name="destinationPath"/>.
        /// Возвращает полный путь к созданной папке.
        /// </summary>
        /// <exception cref="ArgumentException">Если один из путей или имя проекта некорректны.</exception>
        /// <exception cref="DirectoryNotFoundException">Если шаблонная или целевая папка не найдены.</exception>
        /// <exception cref="IOException">Если целевая папка уже существует или при ошибке копирования.</exception>
        public static string CopyTemplate(string templatePath, string destinationPath, string newProjectName, BatchOperationLog? log = null)
        {
            if (string.IsNullOrWhiteSpace(templatePath))
                throw new ArgumentException(MessageText.TemplatePathRequired, nameof(templatePath));
            if (string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException(MessageText.DestinationPathRequired, nameof(destinationPath));
            if (string.IsNullOrWhiteSpace(newProjectName))
                throw new ArgumentException(MessageText.NewProjectNameRequired, nameof(newProjectName));

            // Проверка на недопустимые символы в имени
            if (newProjectName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                throw new ArgumentException(MessageText.NewProjectNameInvalidChars, nameof(newProjectName));

            if (!Directory.Exists(templatePath))
                throw new DirectoryNotFoundException(MessageText.TemplateFolderNotFound);

            if (!Directory.Exists(destinationPath))
                throw new DirectoryNotFoundException(MessageText.DestinationFolderNotFound);

            // Нормализуем пути
            templatePath = Path.GetFullPath(templatePath);
            destinationPath = Path.GetFullPath(destinationPath);

            // Нельзя копировать в ту же папку
            if (string.Equals(templatePath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                destinationPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                StringComparison.OrdinalIgnoreCase))
            {
                throw new IOException(MessageText.CannotCopyIntoSameFolder);
            }

            // Нельзя копировать внутрь самой себя — учитываем границу директорий
            string templateWithSep = templatePath.EndsWith(Path.DirectorySeparatorChar.ToString()) ||
                                     templatePath.EndsWith(Path.AltDirectorySeparatorChar.ToString())
                ? templatePath
                : templatePath + Path.DirectorySeparatorChar;

            if (destinationPath.StartsWith(templateWithSep, StringComparison.OrdinalIgnoreCase))
                throw new IOException(MessageText.CannotCopyInsideItself);

            string newProjectPath = Path.Combine(destinationPath, newProjectName);

            if (Directory.Exists(newProjectPath) || File.Exists(newProjectPath))
                throw new IOException(MessageText.FolderExistsWithName);

            CopyDirectory(templatePath, newProjectPath, log);

            return newProjectPath;
        }


        private static void CopyDirectory(string sourceDir, string targetDir, BatchOperationLog? log = null)
        {
            // Создаём целевую директорию
            Directory.CreateDirectory(targetDir);

            // Копируем файлы текущего уровня
            foreach (var file in Directory.EnumerateFiles(sourceDir))
            {
                var destFile = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, destFile);
                if (log != null)
                {
                    try { log.Files.Add(new FileMoveInfo { Source = file, Destination = destFile, IsCopy = true }); } catch { }
                }
            }

            // Рекурсивно копируем поддиректории
            foreach (var directory in Directory.EnumerateDirectories(sourceDir))
            {
                var destDir = Path.Combine(targetDir, Path.GetFileName(directory));
                CopyDirectory(directory, destDir, log);
            }
        }
    }
}