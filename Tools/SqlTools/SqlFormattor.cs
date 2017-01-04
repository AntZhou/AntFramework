namespace SqlTools
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SqlFormattor
    {
        private string sql;

        public SqlFormattor(string sql)
        {
            this.sql = sql;
        }

        public string BaseFormat()
        {
            this.RemoveComment();
            this.sql = this.sql.Replace("\n", " ");
            this.sql = this.sql.Replace("\t", " ");
            this.RemoveNoneffectiveSpace();
            return this.sql;
        }

        private void RemoveComment()
        {
            while (this.sql.Contains("--"))
            {
                var startIndex = this.sql.IndexOf("--", StringComparison.Ordinal);
                var endIndex = this.sql.IndexOf("\n", startIndex, StringComparison.Ordinal);
                this.sql = this.sql.Remove(startIndex, endIndex - startIndex);
            }
        }

        private void RemoveNoneffectiveSpace()
        {
            while (this.sql.Contains("  "))
            {
                this.sql = this.sql.Replace("  ", " ");
            }
            new List<string> { ",", "(", ")", ";", "<", ">", "=" }.ForEach(this.RemoveSpaceNearByString);
            this.sql = this.sql.Trim();
        }

        private void RemoveSpaceNearByString(string str)
        {
            this.sql = this.sql.Replace($" {str} ", str);
            this.sql = this.sql.Replace($" {str}", str);
            this.sql = this.sql.Replace($"{str} ", str);
        }

        public string Page08Format()
        {
            var orderIndex = this.sql.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase);
            var orderSql = this.sql.Substring(orderIndex);
            this.sql = this.sql.Substring(0, this.sql.Length - orderSql.Length);

            var fromIndex = this.sql.IndexOf("FROM", StringComparison.OrdinalIgnoreCase);
            var fromAndWhereSql = this.sql.Substring(fromIndex);

            var selectIndex = this.sql.IndexOf("SELECT", StringComparison.OrdinalIgnoreCase);
            this.sql = this.sql.Insert(selectIndex + 7, $"ROW_NUMBER() OVER ( {orderSql} ) rowNumber,");
            this.sql = $"SELECT COUNT(1) {fromAndWhereSql};SELECT * FROM({this.sql}) A WHERE rowNumber>(@Page-1)*@PageSize AND rowNumber<=@Page*@PageSize;";
            return this.BaseFormat();
        }

        public string Page12Format()
        {
            var fromIndex = this.sql.IndexOf("FROM", StringComparison.OrdinalIgnoreCase);
            var orderIndex = this.sql.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase);
            var fromAndWhereSql = this.sql.Substring(fromIndex, orderIndex-fromIndex);
            this.sql =
                $"SELECT COUNT(1) {fromAndWhereSql};{this.sql} OFFSET ( @Page - 1 ) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;";
            return this.BaseFormat();
        }

        public string Page12FormatCSharp()
        {
            StringBuilder result = new StringBuilder();
            var fromIndex = this.sql.IndexOf("FROM", StringComparison.OrdinalIgnoreCase);
            var selectSql = this.sql.Substring(0,fromIndex);
            result.AppendLine($"const string SelectSql = @\"{new SqlFormattor(selectSql).BaseFormat()}\";");

            var orderIndex = this.sql.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase);
            var fromAndWhereSql = this.sql.Substring(fromIndex, orderIndex - fromIndex);
            result.AppendLine($"StringBuilder fromAndWhereSql = new StringBuilder(@\"{new SqlFormattor(fromAndWhereSql).BaseFormat()}\");");
            result.AppendLine(@"//添加条件 fromAndWhereSql.Append(...)");

            var ordersql = this.sql.Substring(orderIndex);
            var pageSql = $"{ordersql} OFFSET ( @Page - 1 ) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY";
            result.AppendLine($"const string PageSql = @\"{new SqlFormattor(pageSql).BaseFormat()}\";");

            result.AppendLine("var sql = string.Format(@\"SELECT COUNT(1){0};{1} {0} {2}\", fromAndWhereSql.ToString(), SelectSql, PageSql);");
            return result.ToString();
        }
    }
}