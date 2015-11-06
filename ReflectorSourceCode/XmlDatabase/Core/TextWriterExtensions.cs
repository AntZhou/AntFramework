namespace XmlDatabase.Core
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    internal static class TextWriterExtensions
    {
        public static void WriteEx(this TextWriter writer, string value)
        {
            writer.WriteEx(value, false);
        }

        public static void WriteEx(this TextWriter writer, string value, bool quickFlush)
        {
            writer.WriteLine(value);
            if (quickFlush)
            {
                writer.Flush();
            }
        }
    }
}

