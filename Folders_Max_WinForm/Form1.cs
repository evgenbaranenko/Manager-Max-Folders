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

            int nextNumber = GetNextProjectNumber(basePath);

            // Приводим всё к ВЕРХНЕМУ РЕГИСТРУ
            clientName = clientName.ToUpper();
            projectName = projectName.ToUpper();

            string finalName = $"{nextNumber:D2}_{clientName}__{projectName}";

            if (checkBoxAddDate.Checked)
            {
                string date = DateTime.Now.ToString("dd-MM-yy");
                finalName += $"__({date})";
            }

            string projectFolder = Path.Combine(basePath, finalName);
            CreateDirectory(projectFolder);

            Create3dsMaxStructureFolders(projectFolder);

            MessageBox.Show($"Проект создан:\n{finalName}");
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