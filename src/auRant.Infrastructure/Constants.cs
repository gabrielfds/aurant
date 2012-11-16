using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Infrastructure
{
    public static class Constants
    {
        public static class Parameter
        {
            public static string UrlFanPage { get; set; }
        }

        public static class Folder
        {
            public static string fileFolderBase { get { return @"\Content\file\"; } }
        }
    }
}
