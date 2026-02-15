namespace Folders_Max_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonChoosePath_Click(object sender, EventArgs e)
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

            int nextNumber = GetNextProjectNumber(basePath);
            string finalName = $"{nextNumber:D2}_{nameWithoutNumber}";

            string projectFolder = Path.Combine(basePath, finalName);
            CreateDirectory(projectFolder);

            Create3dsMaxStructureFolders(projectFolder);

            MessageBox.Show($"Создан VIZ проект:\n{finalName}");
        }
        private void buttonCreateFullProject_Click(object sender, EventArgs e)
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

            // 🔍 Ищем существующий проект
            string existingProject = FindExistingProject(basePath, nameWithoutNumber);

            string projectFolder;

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
            }

            // Добавляем недостающие разделы
            CreateFullProjectStructure(projectFolder);

            MessageBox.Show("Структура обновлена / создана успешно!");
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
        private void CreateFullProjectStructure(string basePath)
        {
            // --- Общие папки ---
            CreateDirectory(Path.Combine(basePath, "00_Договор"));
            CreateDirectory(Path.Combine(basePath, "01_Референсы"));

            string sourceInfo = Path.Combine(basePath, "02_Исходная_информация");
            CreateDirectory(sourceInfo);
            CreateDirectory(Path.Combine(sourceInfo, "01_Исходные_данные_(тех.документация)"));
            CreateDirectory(Path.Combine(sourceInfo, "02_Пожелания_заказчика"));
            CreateDirectory(Path.Combine(sourceInfo, "03_Доп.информация"));
            CreateDirectory(Path.Combine(sourceInfo, "04_Фото"));

            // --- Основные рабочие папки ---
            string projectFolder = Path.Combine(basePath, "03_Проектирование");
            string issueFolder = Path.Combine(basePath, "04_Выдача");

            CreateDirectory(projectFolder);
            CreateDirectory(issueFolder);

            // --- Определяем какие разделы нужны ---
            var sections = new List<string>();

            // ОБ создаётся если выбран хоть один тип
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

            // --- Создание разделов ---
            foreach (var section in sections)
            {
                CreateDirectory(Path.Combine(projectFolder, section));
                CreateDirectory(Path.Combine(issueFolder, section));
            }

            // --- Авторский надзор ---
            string supervision = Path.Combine(basePath, "05_Авторский_надзор");
            CreateDirectory(supervision);
            CreateDirectory(Path.Combine(supervision, "01_Фото"));
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
        private void Create3dsMaxStructureFolders(string basePath)
        {
           
            CreateDirectory(Path.Combine(basePath, "01_Contract"));
            CreateDirectory(Path.Combine(basePath, "02_IN"));
            Create3dsMaxFolders(basePath);
            CreateDirectory(Path.Combine(basePath, "04_OUT"));
           
        }
        private void Create3dsMaxFolders(string basePath)
        {
            string mainFolder = Path.Combine(basePath, "03_3dsMax");
            CreateDirectory(mainFolder);

            string[] subFolders = {
                "00_Temp",
                "01_Max",
                "02_Texture",
                "03_Render",
                "04_Import",
                "05_Export",
                "06_Proxy",
                "07_Models"
            };

            foreach (string sub in subFolders)
            {
                CreateDirectory(Path.Combine(mainFolder, sub));
            }
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
    }
}