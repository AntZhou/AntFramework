namespace XmlDatabase.Core.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), CompilerGenerated, DebuggerNonUserCode]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        internal static string ChangeActionError
        {
            get
            {
                return ResourceManager.GetString("ChangeActionError", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static string DatabaseClosed
        {
            get
            {
                return ResourceManager.GetString("DatabaseClosed", resourceCulture);
            }
        }

        internal static string DatabaseOpened
        {
            get
            {
                return ResourceManager.GetString("DatabaseOpened", resourceCulture);
            }
        }

        internal static string DeleteObject
        {
            get
            {
                return ResourceManager.GetString("DeleteObject", resourceCulture);
            }
        }

        internal static string DeleteObjectError
        {
            get
            {
                return ResourceManager.GetString("DeleteObjectError", resourceCulture);
            }
        }

        internal static string GeneralException
        {
            get
            {
                return ResourceManager.GetString("GeneralException", resourceCulture);
            }
        }

        internal static string InsertObject
        {
            get
            {
                return ResourceManager.GetString("InsertObject", resourceCulture);
            }
        }

        internal static string QueryObject
        {
            get
            {
                return ResourceManager.GetString("QueryObject", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("XmlDatabase.Core.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static string TypeConfiguration
        {
            get
            {
                return ResourceManager.GetString("TypeConfiguration", resourceCulture);
            }
        }

        internal static string UpdateObject
        {
            get
            {
                return ResourceManager.GetString("UpdateObject", resourceCulture);
            }
        }
    }
}

