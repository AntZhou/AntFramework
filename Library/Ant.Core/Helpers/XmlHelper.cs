namespace Ant.Core.Helpers
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public static class XmlHelper
    {
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