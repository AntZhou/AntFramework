namespace SqlTools
{
    partial class SqlFormatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.beforeTxt = new System.Windows.Forms.RichTextBox();
            this.afterTxt = new System.Windows.Forms.RichTextBox();
            this.formatBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // beforeTxt
            // 
            this.beforeTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.beforeTxt.Location = new System.Drawing.Point(0, 0);
            this.beforeTxt.Name = "beforeTxt";
            this.beforeTxt.Size = new System.Drawing.Size(784, 217);
            this.beforeTxt.TabIndex = 1;
            this.beforeTxt.Text = "";
            // 
            // afterTxt
            // 
            this.afterTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.afterTxt.Location = new System.Drawing.Point(0, 244);
            this.afterTxt.Name = "afterTxt";
            this.afterTxt.Size = new System.Drawing.Size(784, 193);
            this.afterTxt.TabIndex = 2;
            this.afterTxt.Text = "";
            // 
            // formatBtn
            // 
            this.formatBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatBtn.Location = new System.Drawing.Point(0, 217);
            this.formatBtn.Name = "formatBtn";
            this.formatBtn.Size = new System.Drawing.Size(784, 27);
            this.formatBtn.TabIndex = 3;
            this.formatBtn.Text = "格式化";
            this.formatBtn.UseVisualStyleBackColor = true;
            this.formatBtn.Click += new System.EventHandler(this.FormatBtnClick);
            // 
            // SqlFormatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 437);
            this.Controls.Add(this.formatBtn);
            this.Controls.Add(this.afterTxt);
            this.Controls.Add(this.beforeTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SqlFormatForm";
            this.Text = "SqlFormatForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox beforeTxt;
        private System.Windows.Forms.RichTextBox afterTxt;
        private System.Windows.Forms.Button formatBtn;
    }
}