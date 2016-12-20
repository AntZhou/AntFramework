using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlStringFormat
{
    public partial class SqlStringFormatForm : Form
    {
        public SqlStringFormatForm()
        {
            this.InitializeComponent();
        }

        private void FormatBtnClick(object sender, EventArgs e)
        {
            var sql = this.BeforeTxt.Text.Trim();
            this.RemoveComment(ref sql);
            sql = sql.Replace("\n", " ");
            sql = sql.Replace("\t", " ");
            this.Replace(ref sql,"  ", " ");
            this.AfterTxt.Text = sql;
        }

        private void Replace(ref string s,string s1, string s2)
        {
            while (s.Contains(s1))
            {
                s = s.Replace(s1, s2);
            }
        }

        private void RemoveComment(ref string sql)
        {
            while (sql.Contains("--"))
            {
                var startIndex = sql.IndexOf("--", StringComparison.Ordinal);
                var endIndex = sql.IndexOf("\n", startIndex, StringComparison.Ordinal);
                sql = sql.Remove(startIndex, endIndex - startIndex);
            }
        }
    }
}
