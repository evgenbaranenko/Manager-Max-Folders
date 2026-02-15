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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        button3dsMaxStructureFolders = new System.Windows.Forms.Button();
        textBoxPath = new System.Windows.Forms.TextBox();
        buttonChoosePath = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button3dsMaxStructureFolders
        // 
        button3dsMaxStructureFolders.Location = new System.Drawing.Point(335, 217);
        button3dsMaxStructureFolders.Name = "button3dsMaxStructureFolders";
        button3dsMaxStructureFolders.Size = new System.Drawing.Size(166, 44);
        button3dsMaxStructureFolders.TabIndex = 0;
        button3dsMaxStructureFolders.Text = "Create 3dsMax structure folders";
        button3dsMaxStructureFolders.UseVisualStyleBackColor = true;
        button3dsMaxStructureFolders.Click += ButtonCreateMaxFolders;
        // 
        // textBoxPath
        // 
        textBoxPath.Location = new System.Drawing.Point(227, 145);
        textBoxPath.Name = "textBoxPath";
        textBoxPath.Size = new System.Drawing.Size(377, 23);
        textBoxPath.TabIndex = 1;
        textBoxPath.TextChanged += TextBoxPathTextChanged;
        // 
        // buttonChoosePath
        // 
        buttonChoosePath.Location = new System.Drawing.Point(335, 178);
        buttonChoosePath.Name = "buttonChoosePath";
        buttonChoosePath.Size = new System.Drawing.Size(165, 39);
        buttonChoosePath.TabIndex = 2;
        buttonChoosePath.Text = "Choose path";
        buttonChoosePath.UseVisualStyleBackColor = true;
        buttonChoosePath.Click += buttonChoosePath_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkSalmon;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        ClientSize = new System.Drawing.Size(784, 361);
        Controls.Add(buttonChoosePath);
        Controls.Add(textBoxPath);
        Controls.Add(button3dsMaxStructureFolders);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button buttonChoosePath;

    private System.Windows.Forms.TextBox textBoxPath;

    private System.Windows.Forms.Button button3dsMaxStructureFolders;

    #endregion
}