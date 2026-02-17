using System;
using System.IO;

namespace Folders_Max_WinForm
{
    public static class ProjectTemplateCopier
    {
        public static string CopyTemplate(string templatePath, string destinationPath, string newProjectName)
        {
            if (!Directory.Exists(templatePath))
                throw new Exception("Папка шаблона не существует.");

            if (!Directory.Exists(destinationPath))
                throw new Exception("Папка назначения не существует.");

            string newProjectPath = Path.Combine(destinationPath, newProjectName);

            if (Directory.Exists(newProjectPath))
                throw new Exception("Папка с таким именем уже существует.");

            CopyDirectory(templatePath, newProjectPath);

            return newProjectPath;
        }



        private static void CopyDirectory(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, destFile);
            }

            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                string destDir = Path.Combine(targetDir, Path.GetFileName(directory));
                CopyDirectory(directory, destDir);
            }
        }
    }
}