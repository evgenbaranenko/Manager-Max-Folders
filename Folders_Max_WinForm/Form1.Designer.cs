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
        buttonCoronaBatchOrganizerMapsByCamera = new System.Windows.Forms.Button();
        buttonCoronaBatchOrganizerMapsByMaps = new System.Windows.Forms.Button();
        buttonUndoLast = new System.Windows.Forms.Button();
        textBoxDestinationPath = new System.Windows.Forms.TextBox();
        buttonChooseDestination = new System.Windows.Forms.Button();
        buttonCopyTemplate = new System.Windows.Forms.Button();
        textBoxNewProjectName = new System.Windows.Forms.TextBox();
        checkBoxAddNumber = new System.Windows.Forms.CheckBox();
        groupBox1 = new System.Windows.Forms.GroupBox();
        groupBox3 = new System.Windows.Forms.GroupBox();
        groupBox4 = new System.Windows.Forms.GroupBox();
        groupBox2 = new System.Windows.Forms.GroupBox();
        toolTip1 = new System.Windows.Forms.ToolTip(components);
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
        SuspendLayout();
        // 
        // button3dsMaxStructureFolders
        // 
        button3dsMaxStructureFolders.BackColor = System.Drawing.Color.DarkGray;
        button3dsMaxStructureFolders.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        button3dsMaxStructureFolders.Location = new System.Drawing.Point(14, 59);
        button3dsMaxStructureFolders.Name = "button3dsMaxStructureFolders";
        button3dsMaxStructureFolders.Size = new System.Drawing.Size(142, 45);
        button3dsMaxStructureFolders.TabIndex = 0;
        button3dsMaxStructureFolders.Text = "Create 3dsMax structure folders";
        button3dsMaxStructureFolders.UseVisualStyleBackColor = false;
        button3dsMaxStructureFolders.Click += ButtonCreateMaxFolders;
        // 
        // textBoxPath
        // 
        textBoxPath.BackColor = System.Drawing.SystemColors.ButtonFace;
        textBoxPath.Location = new System.Drawing.Point(14, 246);
        textBoxPath.Name = "textBoxPath";
        textBoxPath.PlaceholderText = "Path";
        textBoxPath.Size = new System.Drawing.Size(565, 23);
        textBoxPath.TabIndex = 1;
        textBoxPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        textBoxPath.TextChanged += TextBoxPathTextChanged;
        // 
        // buttonChoosePath
        // 
        buttonChoosePath.BackColor = System.Drawing.Color.DarkGray;
        buttonChoosePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        buttonChoosePath.ForeColor = System.Drawing.SystemColors.ControlText;
        buttonChoosePath.Location = new System.Drawing.Point(582, 246);
        buttonChoosePath.Margin = new System.Windows.Forms.Padding(0);
        buttonChoosePath.Name = "buttonChoosePath";
        buttonChoosePath.Size = new System.Drawing.Size(28, 23);
        buttonChoosePath.TabIndex = 2;
        buttonChoosePath.Text = "...";
        buttonChoosePath.UseVisualStyleBackColor = false;
        buttonChoosePath.Click += ButtonChoosePath_Click;
        // 
        // bindingSource1
        // 
        bindingSource1.RaiseListChangedEvents = false;
        // 
        // textBoxProjectName
        // 
        textBoxProjectName.BackColor = System.Drawing.SystemColors.ButtonFace;
        textBoxProjectName.Location = new System.Drawing.Point(161, 30);
        textBoxProjectName.Name = "textBoxProjectName";
        textBoxProjectName.PlaceholderText = "Project name";
        textBoxProjectName.Size = new System.Drawing.Size(143, 23);
        textBoxProjectName.TabIndex = 3;
        textBoxProjectName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // bindingSource2
        // 
        bindingSource2.RaiseListChangedEvents = false;
        // 
        // buttonCreateFullProject
        // 
        buttonCreateFullProject.BackColor = System.Drawing.Color.DarkGray;
        buttonCreateFullProject.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        buttonCreateFullProject.Location = new System.Drawing.Point(161, 59);
        buttonCreateFullProject.Name = "buttonCreateFullProject";
        buttonCreateFullProject.Size = new System.Drawing.Size(143, 45);
        buttonCreateFullProject.TabIndex = 4;
        buttonCreateFullProject.Text = "Create ARCH\\INT structure folders";
        buttonCreateFullProject.UseVisualStyleBackColor = false;
        buttonCreateFullProject.Click += ButtonCreateFullProject_Click;
        // 
        // checkBoxAddDate
        // 
        checkBoxAddDate.BackColor = System.Drawing.Color.DarkGray;
        checkBoxAddDate.ForeColor = System.Drawing.SystemColors.ControlText;
        checkBoxAddDate.Location = new System.Drawing.Point(130, 307);
        checkBoxAddDate.Name = "checkBoxAddDate";
        checkBoxAddDate.Size = new System.Drawing.Size(52, 20);
        checkBoxAddDate.TabIndex = 5;
        checkBoxAddDate.Text = "Date";
        checkBoxAddDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        checkBoxAddDate.UseVisualStyleBackColor = true;
        checkBoxAddDate.CheckedChanged += CheckBoxAddDate_CheckedChanged;
        // 
        // textBoxClient
        // 
        textBoxClient.BackColor = System.Drawing.SystemColors.ButtonFace;
        textBoxClient.Location = new System.Drawing.Point(14, 30);
        textBoxClient.Name = "textBoxClient";
        textBoxClient.PlaceholderText = "Customer";
        textBoxClient.Size = new System.Drawing.Size(141, 23);
        textBoxClient.TabIndex = 6;
        textBoxClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // checkBoxArchitecture
        // 
        checkBoxArchitecture.Location = new System.Drawing.Point(163, 106);
        checkBoxArchitecture.Name = "checkBoxArchitecture";
        checkBoxArchitecture.Size = new System.Drawing.Size(63, 20);
        checkBoxArchitecture.TabIndex = 7;
        checkBoxArchitecture.Text = "ARCH";
        checkBoxArchitecture.UseVisualStyleBackColor = true;
        // 
        // checkBoxDesign
        // 
        checkBoxDesign.Location = new System.Drawing.Point(232, 106);
        checkBoxDesign.Name = "checkBoxDesign";
        checkBoxDesign.Size = new System.Drawing.Size(52, 20);
        checkBoxDesign.TabIndex = 8;
        checkBoxDesign.Text = "INT";
        checkBoxDesign.UseVisualStyleBackColor = true;
        // 
        // checkBoxCreateShortcut
        // 
        checkBoxCreateShortcut.ForeColor = System.Drawing.SystemColors.ControlText;
        checkBoxCreateShortcut.Location = new System.Drawing.Point(205, 307);
        checkBoxCreateShortcut.Name = "checkBoxCreateShortcut";
        checkBoxCreateShortcut.Size = new System.Drawing.Size(100, 20);
        checkBoxCreateShortcut.TabIndex = 9;
        checkBoxCreateShortcut.Text = "Link desktop";
        checkBoxCreateShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        checkBoxCreateShortcut.UseVisualStyleBackColor = true;
        checkBoxCreateShortcut.CheckedChanged += CheckBoxCreateShortcut_CheckedChanged;
        // 
        // buttonCoronaBatchOrganizerMapsByCamera
        // 
        buttonCoronaBatchOrganizerMapsByCamera.BackColor = System.Drawing.Color.DarkGray;
        buttonCoronaBatchOrganizerMapsByCamera.Location = new System.Drawing.Point(319, 30);
        buttonCoronaBatchOrganizerMapsByCamera.Name = "buttonCoronaBatchOrganizerMapsByCamera";
        buttonCoronaBatchOrganizerMapsByCamera.Size = new System.Drawing.Size(142, 45);
        buttonCoronaBatchOrganizerMapsByCamera.TabIndex = 10;
        buttonCoronaBatchOrganizerMapsByCamera.Text = "Organize render maps by camera";
        toolTip1.SetToolTip(buttonCoronaBatchOrganizerMapsByCamera, ("Собирает все карты корона рендер для каждого ракурса в отдельные папки\r\n1. Выбира" + "ем \"Path\" - путь где лежат все карты после сохранения/батч рендер\r\n2. "));
        buttonCoronaBatchOrganizerMapsByCamera.UseVisualStyleBackColor = false;
        buttonCoronaBatchOrganizerMapsByCamera.Click += ButtonCoronaBatchOrganizerMapsByCamera_Click;
        // 
        // buttonCoronaBatchOrganizerMapsByMaps
        // 
        buttonCoronaBatchOrganizerMapsByMaps.BackColor = System.Drawing.Color.DarkGray;
        buttonCoronaBatchOrganizerMapsByMaps.Location = new System.Drawing.Point(467, 30);
        buttonCoronaBatchOrganizerMapsByMaps.Name = "buttonCoronaBatchOrganizerMapsByMaps";
        buttonCoronaBatchOrganizerMapsByMaps.Size = new System.Drawing.Size(142, 45);
        buttonCoronaBatchOrganizerMapsByMaps.TabIndex = 11;
        buttonCoronaBatchOrganizerMapsByMaps.Text = "Organize render maps by maps";
        buttonCoronaBatchOrganizerMapsByMaps.UseVisualStyleBackColor = false;
        buttonCoronaBatchOrganizerMapsByMaps.Click += ButtonCoronaBatchOrganizerMapsByMaps_Click;
        // 
        // buttonUndoLast
        // 
        buttonUndoLast.BackColor = System.Drawing.Color.DarkGray;
        buttonUndoLast.Location = new System.Drawing.Point(319, 80);
        buttonUndoLast.Name = "buttonUndoLast";
        buttonUndoLast.Size = new System.Drawing.Size(290, 25);
        buttonUndoLast.TabIndex = 13;
        buttonUndoLast.Text = "Undo last sort operation";
        buttonUndoLast.UseVisualStyleBackColor = false;
        buttonUndoLast.Click += ButtonUndoLast_Click;
        // 
        // textBoxDestinationPath
        // 
        textBoxDestinationPath.Location = new System.Drawing.Point(14, 275);
        textBoxDestinationPath.Name = "textBoxDestinationPath";
        textBoxDestinationPath.PlaceholderText = "Path to save";
        textBoxDestinationPath.Size = new System.Drawing.Size(565, 23);
        textBoxDestinationPath.TabIndex = 17;
        textBoxDestinationPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // buttonChooseDestination
        // 
        buttonChooseDestination.BackColor = System.Drawing.Color.DarkGray;
        buttonChooseDestination.Location = new System.Drawing.Point(582, 275);
        buttonChooseDestination.Name = "buttonChooseDestination";
        buttonChooseDestination.Size = new System.Drawing.Size(29, 23);
        buttonChooseDestination.TabIndex = 18;
        buttonChooseDestination.Text = "...";
        buttonChooseDestination.UseVisualStyleBackColor = false;
        buttonChooseDestination.Click += ButtonChooseDestination_Click;
        // 
        // buttonCopyTemplate
        // 
        buttonCopyTemplate.BackColor = System.Drawing.Color.DarkGray;
        buttonCopyTemplate.Location = new System.Drawing.Point(14, 185);
        buttonCopyTemplate.Name = "buttonCopyTemplate";
        buttonCopyTemplate.Size = new System.Drawing.Size(290, 45);
        buttonCopyTemplate.TabIndex = 19;
        buttonCopyTemplate.Text = "Create work folder structure";
        buttonCopyTemplate.UseVisualStyleBackColor = false;
        buttonCopyTemplate.Click += ButtonCopyTemplate_Click;
        // 
        // textBoxNewProjectName
        // 
        textBoxNewProjectName.Location = new System.Drawing.Point(14, 156);
        textBoxNewProjectName.Name = "textBoxNewProjectName";
        textBoxNewProjectName.PlaceholderText = "Enter the name of the new project";
        textBoxNewProjectName.Size = new System.Drawing.Size(290, 23);
        textBoxNewProjectName.TabIndex = 20;
        textBoxNewProjectName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // checkBoxAddNumber
        // 
        checkBoxAddNumber.Location = new System.Drawing.Point(16, 309);
        checkBoxAddNumber.Name = "checkBoxAddNumber";
        checkBoxAddNumber.Size = new System.Drawing.Size(97, 16);
        checkBoxAddNumber.TabIndex = 21;
        checkBoxAddNumber.Text = " Add number";
        checkBoxAddNumber.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.BackColor = System.Drawing.Color.Transparent;
        groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
        groupBox1.Location = new System.Drawing.Point(9, 10);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(300, 120);
        groupBox1.TabIndex = 25;
        groupBox1.TabStop = false;
        groupBox1.Text = "CREATING A WORK FOLDER STRUCTURE";
        // 
        // groupBox3
        // 
        groupBox3.BackColor = System.Drawing.Color.Transparent;
        groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
        groupBox3.Location = new System.Drawing.Point(10, 137);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(300, 100);
        groupBox3.TabIndex = 27;
        groupBox3.TabStop = false;
        groupBox3.Text = "COPY A FOLDER STRUCTURE";
        // 
        // groupBox4
        // 
        groupBox4.BackColor = System.Drawing.Color.Transparent;
        groupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
        groupBox4.Location = new System.Drawing.Point(314, 137);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new System.Drawing.Size(300, 100);
        groupBox4.TabIndex = 28;
        groupBox4.TabStop = false;
        groupBox4.Text = "RENAMING FILES";
        // 
        // groupBox2
        // 
        groupBox2.BackColor = System.Drawing.Color.Transparent;
        groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
        groupBox2.Location = new System.Drawing.Point(314, 10);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(300, 120);
        groupBox2.TabIndex = 26;
        groupBox2.TabStop = false;
        groupBox2.Text = "ORGANIZE CORONA MAPS";
        // 
        // toolTip1
        // 
        toolTip1.AutomaticDelay = 1000;
        toolTip1.Popup += toolTip1_Popup;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkGray;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        ClientSize = new System.Drawing.Size(627, 558);
        Controls.Add(textBoxProjectName);
        Controls.Add(textBoxClient);
        Controls.Add(checkBoxAddNumber);
        Controls.Add(textBoxNewProjectName);
        Controls.Add(buttonCopyTemplate);
        Controls.Add(buttonChooseDestination);
        Controls.Add(textBoxDestinationPath);
        Controls.Add(buttonUndoLast);
        Controls.Add(buttonCoronaBatchOrganizerMapsByMaps);
        Controls.Add(buttonCoronaBatchOrganizerMapsByCamera);
        Controls.Add(checkBoxCreateShortcut);
        Controls.Add(checkBoxDesign);
        Controls.Add(checkBoxArchitecture);
        Controls.Add(checkBoxAddDate);
        Controls.Add(buttonCreateFullProject);
        Controls.Add(buttonChoosePath);
        Controls.Add(textBoxPath);
        Controls.Add(button3dsMaxStructureFolders);
        Controls.Add(groupBox1);
        Controls.Add(groupBox2);
        Controls.Add(groupBox3);
        Controls.Add(groupBox4);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        Location = new System.Drawing.Point(15, 15);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ToolTip toolTip1;

    private System.Windows.Forms.GroupBox groupBox2;

    private System.Windows.Forms.GroupBox groupBox4;

    private System.Windows.Forms.GroupBox groupBox3;

    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.CheckBox checkBoxAddNumber;

    private System.Windows.Forms.TextBox textBoxNewProjectName;

    private System.Windows.Forms.Button buttonCopyTemplate;

    private System.Windows.Forms.Button buttonChooseDestination;

    private System.Windows.Forms.TextBox textBoxDestinationPath;

    private System.Windows.Forms.Button buttonUndoLast;

    private System.Windows.Forms.Button buttonCoronaBatchOrganizerMapsByMaps;

    private System.Windows.Forms.Button buttonCoronaBatchOrganizerMapsByCamera;

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