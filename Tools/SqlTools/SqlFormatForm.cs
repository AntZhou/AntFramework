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
    public partial class SqlFormatForm : Form
    {
        public Func<string,string> BtnAction;
        public SqlFormatForm()
        {
            this.InitializeComponent();
        }

        private void FormatBtnClick(object sender, EventArgs e)
        {
            if (null!=this.BtnAction)
            {
                this.afterTxt.Text = this.BtnAction(this.beforeTxt.Text);
            }
        }
    }
}
