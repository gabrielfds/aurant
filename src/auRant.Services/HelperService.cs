using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using auRant.Core;
using System.IO;

namespace auRant.Services
{
    public class HelperService
    {
        public HelperService()
        {
        }

        /// <summary>
        /// Saves a file in a given folder
        /// </summary>
        /// <param name="file">The HttpPostedFileBase to save</param>
        /// <param name="folder">the folder where to save the file, it will be based inside /Content/file/{folder parameter} </param>
        public void SaveFile(HttpPostedFileBase file, string folder)
        {
            string fileFolder = string.Concat(AppDomain.CurrentDomain.BaseDirectory, folder);
            CreateFolder(fileFolder);
            file.SaveAs(string.Concat(fileFolder, file.FileName));
        }

        public void CreateFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}
