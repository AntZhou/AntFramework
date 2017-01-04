using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlTools
{
    using System.Runtime.Remoting;
    using System.Security.Cryptography;

    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            this.InitializeComponent();
        }

        private void BaseFormLoad(object sender, EventArgs e)
        {
            var subItem = this.AddContextMenu("格式化", this.baseMenuStrip.Items, null);
            //添加子菜单 
            this.AddContextMenu("基本", subItem.DropDownItems, new EventHandler(this.BaseFormatBtnClick));
            this.AddContextMenu("08分页SQL版", subItem.DropDownItems, new EventHandler(this.Page08FormatBtnClick));
            this.AddContextMenu("12分页SQL版", subItem.DropDownItems, new EventHandler(this.Page12FormatBtnClick));
            this.AddContextMenu("12分页C#版", subItem.DropDownItems, new EventHandler(this.Page12CSharpFormatBtnClick));

            //添加菜单二 
            subItem = this.AddContextMenu("测试", this.baseMenuStrip.Items, null);
            //添加子菜单 
            this.AddContextMenu("添加出库", subItem.DropDownItems, new EventHandler(this.MenuClicked));
            this.AddContextMenu("出库管理", subItem.DropDownItems, new EventHandler(this.MenuClicked));
        }

        private bool isFirstActionItem = true;

        ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (text == "-")
            {
                ToolStripSeparator tsp = new ToolStripSeparator();
                cms.Add(tsp);
                return null;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                tsmi.Tag = text + "TAG";
                if (callback != null) tsmi.Click += callback;
                cms.Add(tsmi);
                if (this.isFirstActionItem && null!= callback)
                {
                    this.isFirstActionItem = false;
                    callback.Invoke(tsmi, new EventArgs());
                }
                return tsmi;
            }
            return null;
        }

        void MenuClicked(object sender, EventArgs e)
        {
            
        }

        private void Rename(string title)
        {
            this.Text = $"工具箱-{title}";
        }

        public void ShowForm(object sender,Form @from)
        {
            var item = sender as ToolStripMenuItem;
            if (item != null)
            {
                this.Rename(item.Text.Trim());
            }
            this.mainPanel.Controls.Clear();
            @from.Anchor = AnchorStyles.Top;
            @from.Anchor = AnchorStyles.Left;
            @from.Dock = DockStyle.Fill;
            @from.TopLevel = false;
            this.mainPanel.Controls.Add(@from);
            @from.Show();
        }

        void BaseFormatBtnClick(object sender, EventArgs e)
        {
            Form @form = new SqlFormatForm() {BtnAction = sql=> new SqlFormattor(sql).BaseFormat() };
            this.ShowForm(sender,@form);
        }

        private void Page08FormatBtnClick(object sender, EventArgs e)
        {
            Form @form = new SqlFormatForm() {BtnAction = sql=> new SqlFormattor(sql).Page08Format() };
            this.ShowForm(sender,@form);
        }
        private void Page12FormatBtnClick(object sender, EventArgs e)
        {
            Form @form = new SqlFormatForm() {BtnAction = sql=> new SqlFormattor(sql).Page12Format() };
            this.ShowForm(sender,@form);
        }
        private void Page12CSharpFormatBtnClick(object sender, EventArgs e)
        {
            Form @form = new SqlFormatForm() { BtnAction = sql => new SqlFormattor(sql).Page12FormatCSharp() };
            this.ShowForm(sender, @form);
        }

    }
}
