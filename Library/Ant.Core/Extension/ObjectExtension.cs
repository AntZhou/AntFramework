namespace Ant.Core.Extension
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    using Ant.Core.Helpers;

    public static class ObjectExtension
    {
        /// <summary>
        ///     对象是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        ///     通过二进制克隆
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object BinaryClone(this object obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0L;
                return formatter.Deserialize(stream);
            }
        }

        /// <summary>
        ///     通过Xml克隆
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static object XmlClone(this object source)
        {
            string xml = XmlHelper.SerializeToXml(source);
            return XmlHelper.DeserializeFromXml(xml, source.GetType());
        }
        
    }
}