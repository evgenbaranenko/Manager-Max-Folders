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
            
            // Создаем папку проекта
            string projectFolder = Path.Combine(basePath, projectName);
            CreateDirectory(projectFolder);
            
            Create3dsMaxStructureFolders(projectFolder);
            
            MessageBox.Show("Папки созданы успешно!");
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
            Create3dsMaxFolders(basePath);
            CreateDirectory(Path.Combine(basePath, "_IN"));
            CreateDirectory(Path.Combine(basePath, "_OUT"));
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