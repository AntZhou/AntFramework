namespace Ant.Core
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;

    public static class ObjectExtension
    {
        /// <summary>
        ///     对象是否为空
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
            return DeserializeFromXml(SerializeToXml(source), source.GetType());
        }

        /// <summary>
        ///     Xml反序列化
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="returnType"></param>
        /// <returns></returns>
        public static object DeserializeFromXml(string inputString, Type returnType)
        {
            using (var reader = new StringReader(inputString))
            {
                var serializer = new XmlSerializer(returnType);
                return Convert.ChangeType(serializer.Deserialize(reader), returnType);
            }
        }

        /// <summary>
        ///     Xml反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static T DeserializeFromXml<T>(string inputString)
        {
            using (var reader = new StringReader(inputString))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        ///     Xml序列化
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string SerializeToXml(object source)
        {
            using (TextWriter writer = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(source.GetType());
                xmlSerializer.Serialize(writer, source);
                return writer.ToString();
            }
        }
    }
}