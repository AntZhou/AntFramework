using System;

namespace Ant.Core
{
    using System.Linq;
    using System.Text;

    public static class Extension
    {
        /// <summary>
        /// 对象是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            if (obj == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            int result;
            if (!int.TryParse(str, out result))
            {
                throw new ArgumentOutOfRangeException(string.Format("{0}无法转化为int类型", str));
            }
            return result;
        }

        /// <summary>
        /// 转换为long
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
            StringBuilder sb = new StringBuilder();
            foreach (var ch in from ch in arr let unicode = ch where unicode > 31 && unicode != 127 select ch)
            {
                sb.Append(ch);
            }
            return sb.ToString();
        }
    }
}
