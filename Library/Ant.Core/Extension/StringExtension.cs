namespace Ant.Extension
{
    using System;
    using System.Linq;
    using System.Text;

    public static class StringExtension
    {
        /// <summary>
        ///     转换为int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            int result;
            if (!int.TryParse(str, out result))
            {
                throw new ArgumentOutOfRangeException($"{str}无法转化为int类型");
            }
            return result;
        }

        /// <summary>
        ///     是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        ///     转换为long
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ToLong(this string str)
        {
            long result;
            if (!long.TryParse(str, out result))
            {
                throw new ArgumentOutOfRangeException(string.Format("{0}无法转化为long类型", str));
            }
            return result;
        }

        /// <summary>
        ///     删除不可见字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DeleteUnVisibleChar(this string str)
        {
            var arr = str.ToCharArray();
            var sb = new StringBuilder();
            foreach (var ch in from ch in arr let unicode = ch where unicode > 31 && unicode != 127 select ch)
            {
                sb.Append(ch);
            }
            return sb.ToString();
        }
    }
}