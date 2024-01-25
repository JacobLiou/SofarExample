namespace WinformMessenger
{
    partial class EmbedControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            uiButton1 = new Sunny.UI.UIButton();
            uiipTextBox1 = new Sunny.UI.UIIPTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 143);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Location = new Point(528, 316);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(125, 44);
            uiButton1.TabIndex = 1;
            uiButton1.Text = "确认";
            uiButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // uiipTextBox1
            // 
            uiipTextBox1.FillColor2 = Color.FromArgb(235, 243, 255);
            uiipTextBox1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiipTextBox1.Location = new Point(214, 127);
            uiipTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiipTextBox1.MinimumSize = new Size(1, 1);
            uiipTextBox1.Name = "uiipTextBox1";
            uiipTextBox1.Padding = new Padding(1);
            uiipTextBox1.ShowText = false;
            uiipTextBox1.Size = new Size(188, 36);
            uiipTextBox1.TabIndex = 2;
            uiipTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // EmbedControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uiipTextBox1);
            Controls.Add(uiButton1);
            Controls.Add(label1);
            Name = "EmbedControl";
            Size = new Size(725, 408);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIIPTextBox uiipTextBox1;
    }
}
