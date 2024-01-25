namespace WinformMessenger;

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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        embedControl1 = new EmbedControl();
        SuspendLayout();
        // 
        // embedControl1
        // 
        embedControl1.Location = new Point(113, 75);
        embedControl1.Name = "embedControl1";
        embedControl1.Size = new Size(915, 464);
        embedControl1.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1193, 650);
        Controls.Add(embedControl1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private EmbedControl embedControl1;
}
