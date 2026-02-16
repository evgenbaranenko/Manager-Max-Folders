namespace Folders_Max_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ButtonChoosePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку, где создать структуру";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxPath.Text = dialog.SelectedPath;
                }
            }
        }
        private void ButtonCreateMaxFolders(object sender, EventArgs e)
        {
            if (InputPath(out var basePath)) return;
            if (InputProjectName(out var projectName)) return;
            if (InputClient(out var clientName)) return;

            clientName = clientName.ToUpper();
            projectName = projectName.ToUpper();

            string typeTag = GetProjectTypeTag(true);

            string datePart = "";
            if (checkBoxAddDate.Checked)
                datePart = $"_({DateTime.Now:dd-MM-yy})";

            string nameWithoutNumber = $"{clientName}__{projectName}__{typeTag}{datePart}";

            string existingProject = FindExistingProject(basePath, nameWithoutNumber);

            string projectFolder;
            bool isNewProject = false;

            if (existingProject != null)
            {
                projectFolder = existingProject;
            }
            else
            {
                int nextNumber = GetNextProjectNumber(basePath);
                string finalName = $"{nextNumber:D2}_{nameWithoutNumber}";
                projectFolder = Path.Combine(basePath, finalName);
                CreateDirectory(projectFolder);
                isNewProject = true;
            }

            bool wasUpdated = Create3dsMaxStructureFolders(projectFolder);

            if (!isNewProject && !wasUpdated)
            {
                MessageBox.Show("VIZ структура уже полностью создана.");
                return;
            }

            MessageBox.Show("VIZ структура создана / обновлена успешно!");
            
            if (checkBoxCreateShortcut.Checked)
            {
                CreateDesktopShortcut(projectFolder);
            }
        }
        private void ButtonCreateFullProject_Click(object sender, EventArgs e)
        {
            if (InputPath(out var basePath)) return;
            if (InputProjectName(out var projectName)) return;
            if (InputClient(out var clientName)) return;

            if (!checkBoxArchitecture.Checked && !checkBoxDesign.Checked)
            {
                MessageBox.Show("Выберите тип проекта!", "Ошибка");
                return;
            }

            clientName = clientName.ToUpper();
            projectName = projectName.ToUpper();

            string typeTag = GetProjectTypeTag(false);

            string datePart = "";
            if (checkBoxAddDate.Checked)
                datePart = $"_({DateTime.Now:dd-MM-yy})";

            string nameWithoutNumber = $"{clientName}__{projectName}__{typeTag}{datePart}";

            string existingProject = FindExistingProject(basePath, nameWithoutNumber);

            string projectFolder;
            bool isNewProject = false;

            if (existingProject != null)
            {
                projectFolder = existingProject;
            }
            else
            {
                int nextNumber = GetNextProjectNumber(basePath);
                string finalName = $"{nextNumber:D2}_{nameWithoutNumber}";
                projectFolder = Path.Combine(basePath, finalName);
                CreateDirectory(projectFolder);
                isNewProject = true;
            }

            bool wasUpdated = CreateFullProjectStructure(projectFolder);

            if (!isNewProject && !wasUpdated)
            {
                MessageBox.Show("Этот проект уже существует и структура полностью создана.");
                return;
            }

            MessageBox.Show("Структура проекта обновлена / создана успешно!");
            
            if (checkBoxCreateShortcut.Checked)
            {
                CreateDesktopShortcut(projectFolder);
            }
        }
        private string GetProjectTypeTag(bool isVizButton = false)
        {
            if (isVizButton)
                return "VIZ";

            if (checkBoxArchitecture.Checked && checkBoxDesign.Checked)
                return "ARCH_INT";

            if (checkBoxArchitecture.Checked)
                return "ARCH";

            if (checkBoxDesign.Checked)
                return "INT";

            return "";
        }
        private string FindExistingProject(string basePath, string nameWithoutNumber)
        {
            var directories = Directory.GetDirectories(basePath);

            foreach (var dir in directories)
            {
                string folderName = Path.GetFileName(dir);

                if (folderName.Contains($"_{nameWithoutNumber}"))
                {
                    return dir;
                }
            }

            return null;
        }
        private bool CreateFullProjectStructure(string basePath)
        {
            bool createdSomething = false;

            createdSomething |= SafeCreate(Path.Combine(basePath, "00_Договор"));
            createdSomething |= SafeCreate(Path.Combine(basePath, "01_Референсы"));

            string sourceInfo = Path.Combine(basePath, "02_Исходная_информация");
            createdSomething |= SafeCreate(sourceInfo);
            createdSomething |= SafeCreate(Path.Combine(sourceInfo, "01_Исходные_данные_(тех.документация)"));
            createdSomething |= SafeCreate(Path.Combine(sourceInfo, "02_Пожелания_заказчика"));
            createdSomething |= SafeCreate(Path.Combine(sourceInfo, "03_Доп.информация"));
            createdSomething |= SafeCreate(Path.Combine(sourceInfo, "04_Фото"));

            string projectFolder = Path.Combine(basePath, "03_Проектирование");
            string issueFolder = Path.Combine(basePath, "04_Выдача");

            createdSomething |= SafeCreate(projectFolder);
            createdSomething |= SafeCreate(issueFolder);

            var sections = new List<string>();

            if (checkBoxArchitecture.Checked || checkBoxDesign.Checked)
                sections.Add("01_ОБ");

            if (checkBoxArchitecture.Checked)
            {
                sections.Add("02_ЭП");
                sections.Add("03_Р");
            }

            if (checkBoxDesign.Checked)
            {
                sections.Add("04_Дизайн-проект");
            }

            foreach (var section in sections)
            {
                createdSomething |= SafeCreate(Path.Combine(projectFolder, section));
                createdSomething |= SafeCreate(Path.Combine(issueFolder, section));
            }

            string supervision = Path.Combine(basePath, "05_Авторский_надзор");
            createdSomething |= SafeCreate(supervision);
            createdSomething |= SafeCreate(Path.Combine(supervision, "01_Фото"));

            return createdSomething;
        }
        private bool SafeCreate(string path)
        {
            if (Directory.Exists(path))
                return false;

            Directory.CreateDirectory(path);
            return true;
        }
        private bool InputClient(out string clientName)
        {
            clientName = textBoxClient.Text.Trim();

            if (string.IsNullOrWhiteSpace(clientName))
            {
                MessageBox.Show("Введите заказчика!", "Ошибка");
                return true;
            }

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                if (clientName.Contains(c))
                {
                    MessageBox.Show("Название заказчика содержит недопустимые символы!", "Ошибка");
                    return true;
                }
            }

            return false;
        }
        private int GetNextProjectNumber(string basePath)
        {
            var directories = Directory.GetDirectories(basePath);

            int maxNumber = 0;

            foreach (var dir in directories)
            {
                string folderName = Path.GetFileName(dir);

                var parts = folderName.Split('_');

                if (parts.Length > 0 && int.TryParse(parts[0], out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }

            return maxNumber + 1;
        }
        private bool InputProjectName(out string projectName)
        {
            projectName = textBoxProjectName.Text.Trim();

            if (string.IsNullOrWhiteSpace(projectName))
            {
                MessageBox.Show("Введите название проекта!", "Ошибка");
                return true;
            }

            // Запрещённые символы Windows
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                if (projectName.Contains(c))
                {
                    MessageBox.Show("Название проекта содержит недопустимые символы!", "Ошибка");
                    return true;
                }
            }

            return false;
        }
        private bool Create3dsMaxStructureFolders(string basePath)
        {
            bool createdSomething = false;

            string mainFolder = Path.Combine(basePath, "03_3dsMax");
            createdSomething |= SafeCreate(mainFolder);

            string[] subFolders =
            {
                "00_Temp",
                "01_Max",
                "02_Texture",
                "03_Render",
                "04_Import",
                "05_Export",
                "06_Proxy",
                "07_Models"
            };

            foreach (var sub in subFolders)
            {
                createdSomething |= SafeCreate(Path.Combine(mainFolder, sub));
            }

            createdSomething |= SafeCreate(Path.Combine(basePath, "02_IN"));
            createdSomething |= SafeCreate(Path.Combine(basePath, "04_OUT"));
            createdSomething |= SafeCreate(Path.Combine(basePath, "01_Contract"));

            return createdSomething;
        }
        private void CreateDirectory( string folder ) => Directory.CreateDirectory(folder);
        private bool InputPath(out string basePath)
        {
            basePath = textBoxPath.Text.Trim();

            if (string.IsNullOrWhiteSpace(basePath))
            {
                MessageBox.Show("Укажите путь для создания папок!", "Ошибка");
                return true;
            }

            if (Directory.Exists(basePath)) return false;
            
            MessageBox.Show("Такого пути не существует!", "Ошибка");
            return true;
        }
        private void TextBoxPathTextChanged(object sender, EventArgs e)
        { 
            // throw new System.NotImplementedException();
        }
        private void CheckBoxAddDate_CheckedChanged(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();
        }
        private void CheckBoxCreateShortcut_CheckedChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }
        private void CreateDesktopShortcut(string projectFolder)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string projectName = Path.GetFileName(projectFolder);
            string shortcutLocation = Path.Combine(desktopPath, projectName + ".lnk");

            if (File.Exists(shortcutLocation))
                return; // защита от повторного создания

            Type shellType = Type.GetTypeFromProgID("WScript.Shell");
            dynamic shell = Activator.CreateInstance(shellType);

            var shortcut = shell.CreateShortcut(shortcutLocation);
            shortcut.TargetPath = projectFolder;
            shortcut.WorkingDirectory = projectFolder;
            shortcut.Save();
        }
    }
}