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
        btnMaxStrFldr = new System.Windows.Forms.Button();
        textBoxPath = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // btnMaxStrFldr
        // 
        btnMaxStrFldr.Location = new System.Drawing.Point(335, 217);
        btnMaxStrFldr.Name = "btnMaxStrFldr";
        btnMaxStrFldr.Size = new System.Drawing.Size(166, 44);
        btnMaxStrFldr.TabIndex = 0;
        btnMaxStrFldr.Text = "Create Max structure folders";
        btnMaxStrFldr.UseVisualStyleBackColor = true;
        btnMaxStrFldr.Click += ButtonCreateMaxFolders;
        // 
        // textBoxPath
        // 
        textBoxPath.Location = new System.Drawing.Point(227, 145);
        textBoxPath.Name = "textBoxPath";
        textBoxPath.Size = new System.Drawing.Size(377, 23);
        textBoxPath.TabIndex = 1;
        textBoxPath.TextChanged += TextBoxPathTextChanged;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(335, 178);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(165, 39);
        button1.TabIndex = 2;
        button1.Text = "buttonChoosePath";
        button1.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkSalmon;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        ClientSize = new System.Drawing.Size(784, 361);
        Controls.Add(button1);
        Controls.Add(textBoxPath);
        Controls.Add(btnMaxStrFldr);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.TextBox textBoxPath;

    private System.Windows.Forms.Button btnMaxStrFldr;

    #endregion
}