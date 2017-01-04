namespace SqlTools
{
    partial class BaseForm
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
            this.baseMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // baseMenuStrip
            // 
            this.baseMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.baseMenuStrip.Name = "baseMenuStrip";
            this.baseMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.baseMenuStrip.TabIndex = 0;
            this.baseMenuStrip.Text = "menuStrip1";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(784, 437);
            this.mainPanel.TabIndex = 1;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.baseMenuStrip);
            this.MainMenuStrip = this.baseMenuStrip;
            this.Name = "BaseForm";
            this.Text = "工具箱";
            this.Load += new System.EventHandler(this.BaseFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip baseMenuStrip;
        private System.Windows.Forms.Panel mainPanel;
    }
}