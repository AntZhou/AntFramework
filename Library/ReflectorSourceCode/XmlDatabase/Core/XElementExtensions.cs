namespace XmlDatabase.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Xml.Linq;

    internal static class XElementExtensions
    {
        private static readonly List<string> generalTypes = new List<string> { "System.Byte", "System.SByte", "System.Int16", "System.UInt16", "System.Int32", "System.UInt32", "System.Int64", "System.UInt64", "System.Double", "System.Decimal", "System.Single", "System.Boolean", "System.String", "System.DateTime" };

        public static Entity ConvertToObject<T>(this XElement e)
        {
            Guid id = new Guid();
            return new Entity { Instance = GetTypeInstance(e, typeof(T), true, out id), Id = id };
        }

        public static XElement ConvertToXml(this object instance, Guid uuid)
        {
            return instance.ConvertToXml(instance.GetType().Name, uuid);
        }

        public static XElement ConvertToXml(this object instance, string elementName, Guid uuid)
        {
            return GetTypeElement(instance.GetType(), instance, elementName, uuid);
        }

        private static XElement GetTypeElement(Type t, object instance, string name, Guid uuid)
        {
            XElement element = new XElement(name);
            if (uuid != Guid.Empty)
            {
                element.Add(new XAttribute("_uuid", uuid.ToString()));
            }
            foreach (PropertyInfo info in from _p in t.GetProperties()
                where (_p.GetGetMethod() != null) && (_p.GetValue(instance, null) != null)
                select _p)
            {
                Type propertyType = info.PropertyType;
                string fullName = propertyType.FullName;
                if (!generalTypes.Contains(fullName))
                {
                    if (propertyType.IsEnum)
                    {
                        XElement content = new XElement(info.Name);
                        content.Add(new XAttribute("Enum", info.GetValue(instance, null)));
                        element.Add(content);
                    }
                    else if ((propertyType.GetInterface(typeof(IList).FullName) != null) && propertyType.IsGenericType)
                    {
                        IList list = (IList) info.GetValue(instance, null);
                        if ((list != null) && (list.Count > 0))
                        {
                            XElement element3 = new XElement(info.Name);
                            foreach (object obj2 in list)
                            {
                                XElement element4 = GetTypeElement(obj2.GetType(), obj2, info.Name.Substring(0, info.Name.Length - 1), Guid.Empty);
                                element3.Add(element4);
                            }
                            element.Add(element3);
                        }
                    }
                    else if (propertyType.IsClass || propertyType.IsValueType)
                    {
                        object obj3 = info.GetValue(instance, null);
                        element.Add(GetTypeElement(propertyType, obj3, info.Name, Guid.Empty));
                    }
                }
                else
                {
                    element.Add(new XAttribute(info.Name, info.GetValue(instance, null)));
                }
            }
            return element;
        }

        private static object GetTypeInstance(XElement e, Type t, bool topLevel, out Guid id)
        {
            string fullName = t.FullName;
            object obj2 = t.Assembly.CreateInstance(fullName);
            foreach (PropertyInfo info in from _p in t.GetProperties()
                where _p.GetSetMethod() != null
                select _p)
            {
                Type propertyType = info.PropertyType;
                string item = propertyType.FullName;
                if (!generalTypes.Contains(item))
                {
                    if (propertyType.IsEnum)
                    {
                        XElement element = e.Element(info.Name);
                        if (element != null)
                        {
                            info.SetValue(obj2, Enum.Parse(info.PropertyType, element.Attribute("Enum").Value), null);
                        }
                    }
                    else if ((propertyType.GetInterface(typeof(IList).FullName) != null) && propertyType.IsGenericType)
                    {
                        IList list = (IList) typeof(List<string>).Assembly.CreateInstance(propertyType.FullName);
                        Type type2 = propertyType.GetGenericArguments()[0];
                        foreach (XElement element3 in e.Element(info.Name).Elements())
                        {
                            list.Add(GetTypeInstance(element3, type2, false, out id));
                        }
                        info.SetValue(obj2, list, null);
                    }
                    else if (propertyType.IsClass || propertyType.IsValueType)
                    {
                        XElement element4 = e.Element(info.Name);
                        if (element4 != null)
                        {
                            info.SetValue(obj2, GetTypeInstance(element4, propertyType, false, out id), null);
                        }
                    }
                }
                else if (e.Attribute(info.Name) != null)
                {
                    info.SetValue(obj2, Convert.ChangeType(e.Attribute(info.Name).Value, propertyType), null);
                }
            }
            if (topLevel && (e.Attribute("_uuid") != null))
            {
                id = new Guid(e.Attribute("_uuid").Value);
                return obj2;
            }
            id = Guid.Empty;
            return obj2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Entity
        {
            public Guid Id { get; set; }
            public object Instance { get; set; }
        }
    }
}

