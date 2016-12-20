namespace SqlStringFormat
{
    partial class SqlStringFormatForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BeforeTxt = new System.Windows.Forms.RichTextBox();
            this.FormatBtn = new System.Windows.Forms.Button();
            this.AfterTxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BeforeTxt
            // 
            this.BeforeTxt.Location = new System.Drawing.Point(12, 12);
            this.BeforeTxt.Name = "BeforeTxt";
            this.BeforeTxt.Size = new System.Drawing.Size(743, 203);
            this.BeforeTxt.TabIndex = 0;
            this.BeforeTxt.Text = "";
            // 
            // FormatBtn
            // 
            this.FormatBtn.Location = new System.Drawing.Point(659, 221);
            this.FormatBtn.Name = "FormatBtn";
            this.FormatBtn.Size = new System.Drawing.Size(96, 23);
            this.FormatBtn.TabIndex = 1;
            this.FormatBtn.Text = "格式化";
            this.FormatBtn.UseVisualStyleBackColor = true;
            this.FormatBtn.Click += new System.EventHandler(this.FormatBtnClick);
            // 
            // AfterTxt
            // 
            this.AfterTxt.Location = new System.Drawing.Point(12, 250);
            this.AfterTxt.Name = "AfterTxt";
            this.AfterTxt.Size = new System.Drawing.Size(743, 98);
            this.AfterTxt.TabIndex = 2;
            this.AfterTxt.Text = "";
            // 
            // SqlStringFormatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 360);
            this.Controls.Add(this.AfterTxt);
            this.Controls.Add(this.FormatBtn);
            this.Controls.Add(this.BeforeTxt);
            this.Name = "SqlStringFormatForm";
            this.Text = "SqlFormat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox BeforeTxt;
        private System.Windows.Forms.Button FormatBtn;
        private System.Windows.Forms.RichTextBox AfterTxt;
    }
}

