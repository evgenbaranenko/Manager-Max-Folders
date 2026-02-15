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
        buttonFullStructureFolders = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
        SuspendLayout();
        // 
        // button3dsMaxStructureFolders
        // 
        button3dsMaxStructureFolders.Location = new System.Drawing.Point(12, 102);
        button3dsMaxStructureFolders.Name = "button3dsMaxStructureFolders";
        button3dsMaxStructureFolders.Size = new System.Drawing.Size(141, 44);
        button3dsMaxStructureFolders.TabIndex = 0;
        button3dsMaxStructureFolders.Text = "Create 3dsMax structure folders";
        button3dsMaxStructureFolders.UseVisualStyleBackColor = true;
        button3dsMaxStructureFolders.Click += ButtonCreateMaxFolders;
        // 
        // textBoxPath
        // 
        textBoxPath.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        textBoxPath.Location = new System.Drawing.Point(12, 12);
        textBoxPath.Name = "textBoxPath";
        textBoxPath.Size = new System.Drawing.Size(290, 23);
        textBoxPath.TabIndex = 1;
        textBoxPath.Text = "Path";
        textBoxPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        textBoxPath.TextChanged += TextBoxPathTextChanged;
        // 
        // buttonChoosePath
        // 
        buttonChoosePath.Location = new System.Drawing.Point(12, 41);
        buttonChoosePath.Name = "buttonChoosePath";
        buttonChoosePath.Size = new System.Drawing.Size(290, 26);
        buttonChoosePath.TabIndex = 2;
        buttonChoosePath.Text = "Choose path";
        buttonChoosePath.UseVisualStyleBackColor = true;
        buttonChoosePath.Click += buttonChoosePath_Click;
        // 
        // textBoxProjectName
        // 
        textBoxProjectName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        textBoxProjectName.Location = new System.Drawing.Point(12, 73);
        textBoxProjectName.Name = "textBoxProjectName";
        textBoxProjectName.Size = new System.Drawing.Size(290, 23);
        textBoxProjectName.TabIndex = 3;
        textBoxProjectName.Text = "Project name";
        textBoxProjectName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // button1
        // 
        buttonFullStructureFolders.Location = new System.Drawing.Point(159, 102);
        buttonFullStructureFolders.Name = "buttonFullStructureFolders";
        buttonFullStructureFolders.Size = new System.Drawing.Size(142, 43);
        buttonFullStructureFolders.TabIndex = 4;
        buttonFullStructureFolders.Text = "button1";
        buttonFullStructureFolders.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkSalmon;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        ClientSize = new System.Drawing.Size(784, 361);
        Controls.Add(buttonFullStructureFolders);
        Controls.Add(textBoxProjectName);
        Controls.Add(buttonChoosePath);
        Controls.Add(textBoxPath);
        Controls.Add(button3dsMaxStructureFolders);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button buttonFullStructureFolders;

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