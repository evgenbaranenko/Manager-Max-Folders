namespace Folders_Max_WinForm;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        button3dsMaxStructureFolders = new System.Windows.Forms.Button();
        textBoxPath = new System.Windows.Forms.TextBox();
        buttonChoosePath = new System.Windows.Forms.Button();
        bindingSource1 = new System.Windows.Forms.BindingSource(components);
        textBoxProjectName = new System.Windows.Forms.TextBox();
        bindingSource2 = new System.Windows.Forms.BindingSource(components);
        fontDialog1 = new System.Windows.Forms.FontDialog();
        fontDialog2 = new System.Windows.Forms.FontDialog();
        buttonCreateFullProject = new System.Windows.Forms.Button();
        checkBoxAddDate = new System.Windows.Forms.CheckBox();
        textBoxClient = new System.Windows.Forms.TextBox();
        checkBoxArchitecture = new System.Windows.Forms.CheckBox();
        checkBoxDesign = new System.Windows.Forms.CheckBox();
        checkBoxCreateShortcut = new System.Windows.Forms.CheckBox();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
        SuspendLayout();
        // 
        // button3dsMaxStructureFolders
        // 
        button3dsMaxStructureFolders.BackColor = System.Drawing.Color.LightSteelBlue;
        button3dsMaxStructureFolders.Location = new System.Drawing.Point(12, 102);
        button3dsMaxStructureFolders.Name = "button3dsMaxStructureFolders";
        button3dsMaxStructureFolders.Size = new System.Drawing.Size(141, 44);
        button3dsMaxStructureFolders.TabIndex = 0;
        button3dsMaxStructureFolders.Text = "Create 3dsMax structure folders";
        button3dsMaxStructureFolders.UseVisualStyleBackColor = false;
        button3dsMaxStructureFolders.Click += ButtonCreateMaxFolders;
        // 
        // textBoxPath
        // 
        textBoxPath.BackColor = System.Drawing.SystemColors.ButtonFace;
        textBoxPath.Location = new System.Drawing.Point(12, 44);
        textBoxPath.Name = "textBoxPath";
        textBoxPath.Size = new System.Drawing.Size(290, 23);
        textBoxPath.TabIndex = 1;
        textBoxPath.Text = "Path";
        textBoxPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        textBoxPath.TextChanged += TextBoxPathTextChanged;
        // 
        // buttonChoosePath
        // 
        buttonChoosePath.BackColor = System.Drawing.Color.LightSteelBlue;
        buttonChoosePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        buttonChoosePath.Location = new System.Drawing.Point(12, 12);
        buttonChoosePath.Name = "buttonChoosePath";
        buttonChoosePath.Size = new System.Drawing.Size(290, 26);
        buttonChoosePath.TabIndex = 2;
        buttonChoosePath.Text = "Choose path";
        buttonChoosePath.UseVisualStyleBackColor = false;
        buttonChoosePath.Click += ButtonChoosePath_Click;
        // 
        // textBoxProjectName
        // 
        textBoxProjectName.BackColor = System.Drawing.SystemColors.ButtonFace;
        textBoxProjectName.Location = new System.Drawing.Point(159, 73);
        textBoxProjectName.Name = "textBoxProjectName";
        textBoxProjectName.Size = new System.Drawing.Size(143, 23);
        textBoxProjectName.TabIndex = 3;
        textBoxProjectName.Text = "Project name";
        textBoxProjectName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // buttonCreateFullProject
        // 
        buttonCreateFullProject.BackColor = System.Drawing.Color.LightSteelBlue;
        buttonCreateFullProject.Location = new System.Drawing.Point(159, 102);
        buttonCreateFullProject.Name = "buttonCreateFullProject";
        buttonCreateFullProject.Size = new System.Drawing.Size(143, 43);
        buttonCreateFullProject.TabIndex = 4;
        buttonCreateFullProject.Text = "Create ARCH\\INT structure folders";
        buttonCreateFullProject.UseVisualStyleBackColor = false;
        buttonCreateFullProject.Click += ButtonCreateFullProject_Click;
        // 
        // checkBoxAddDate
        // 
        checkBoxAddDate.BackColor = System.Drawing.Color.DarkSalmon;
        checkBoxAddDate.Checked = true;
        checkBoxAddDate.CheckState = System.Windows.Forms.CheckState.Checked;
        checkBoxAddDate.Location = new System.Drawing.Point(308, 72);
        checkBoxAddDate.Name = "checkBoxAddDate";
        checkBoxAddDate.Size = new System.Drawing.Size(52, 24);
        checkBoxAddDate.TabIndex = 5;
        checkBoxAddDate.Text = "Date";
        checkBoxAddDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        checkBoxAddDate.UseVisualStyleBackColor = false;
        checkBoxAddDate.CheckedChanged += checkBoxAddDate_CheckedChanged;
        // 
        // textBoxClient
        // 
        textBoxClient.BackColor = System.Drawing.SystemColors.ButtonFace;
        textBoxClient.Location = new System.Drawing.Point(12, 73);
        textBoxClient.Name = "textBoxClient";
        textBoxClient.Size = new System.Drawing.Size(141, 23);
        textBoxClient.TabIndex = 6;
        textBoxClient.Text = "Customer";
        textBoxClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // checkBoxArchitecture
        // 
        checkBoxArchitecture.Location = new System.Drawing.Point(308, 103);
        checkBoxArchitecture.Name = "checkBoxArchitecture";
        checkBoxArchitecture.Size = new System.Drawing.Size(63, 24);
        checkBoxArchitecture.TabIndex = 7;
        checkBoxArchitecture.Text = "ARCH";
        checkBoxArchitecture.UseVisualStyleBackColor = true;
        // 
        // checkBoxDesign
        // 
        checkBoxDesign.Location = new System.Drawing.Point(308, 122);
        checkBoxDesign.Name = "checkBoxDesign";
        checkBoxDesign.Size = new System.Drawing.Size(52, 24);
        checkBoxDesign.TabIndex = 8;
        checkBoxDesign.Text = "INT";
        checkBoxDesign.UseVisualStyleBackColor = true;
        // 
        // checkBoxCreateShortcut
        // 
        checkBoxCreateShortcut.Location = new System.Drawing.Point(366, 72);
        checkBoxCreateShortcut.Name = "checkBoxCreateShortcut";
        checkBoxCreateShortcut.Size = new System.Drawing.Size(100, 24);
        checkBoxCreateShortcut.TabIndex = 9;
        checkBoxCreateShortcut.Text = "Link desktop";
        checkBoxCreateShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        checkBoxCreateShortcut.UseVisualStyleBackColor = true;
        checkBoxCreateShortcut.CheckedChanged += checkBoxCreateShortcut_CheckedChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkSalmon;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        ClientSize = new System.Drawing.Size(615, 361);
        Controls.Add(checkBoxCreateShortcut);
        Controls.Add(checkBoxDesign);
        Controls.Add(checkBoxArchitecture);
        Controls.Add(textBoxClient);
        Controls.Add(checkBoxAddDate);
        Controls.Add(buttonCreateFullProject);
        Controls.Add(textBoxProjectName);
        Controls.Add(buttonChoosePath);
        Controls.Add(textBoxPath);
        Controls.Add(button3dsMaxStructureFolders);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Project folder creator 1.0";
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.CheckBox checkBoxCreateShortcut;

    private System.Windows.Forms.CheckBox checkBoxArchitecture;
    private System.Windows.Forms.CheckBox checkBoxDesign;

    private System.Windows.Forms.TextBox textBoxClient;

    private System.Windows.Forms.CheckBox checkBoxAddDate;

    private System.Windows.Forms.Button buttonCreateFullProject;

    private System.Windows.Forms.FontDialog fontDialog1;
    private System.Windows.Forms.FontDialog fontDialog2;

    private System.Windows.Forms.TextBox textBoxProjectName;
    private System.Windows.Forms.BindingSource bindingSource2;

    private System.Windows.Forms.BindingSource bindingSource1;

    private System.Windows.Forms.Button buttonChoosePath;

    private System.Windows.Forms.TextBox textBoxPath;

    private System.Windows.Forms.Button button3dsMaxStructureFolders;

    #endregion
}