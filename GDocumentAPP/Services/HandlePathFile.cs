using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDocumentAPP.Services
{
    public class HandlePathFile
    {
        public string GenerateFolderBackup(string parentPath)
        {

            string backupPath = System.IO.Path.Combine(parentPath, "imagesBackup" + String.Format("{0:yyyyMMdd}", DateTime.Today));

            bool isExists = System.IO.Directory.Exists(backupPath);

            if (!isExists)
                System.IO.Directory.CreateDirectory(backupPath);
            //Manejar la exception de permiso en la ruta.

            return backupPath;
        }

        public void CopyDirectory(string sourcePath, string destinationPath) {
         
            if (!System.IO.Directory.Exists(destinationPath)) {
                System.IO.Directory.CreateDirectory(destinationPath);
            }

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    string fileName = System.IO.Path.GetFileName(s);
                    string destFile = System.IO.Path.Combine(destinationPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
           
        }

        public void SaveFileBackup(string parentPath, HttpPostedFileBase file)
        {
            var path = string.Format("{0}\\{1}", parentPath, file.FileName);
            file.SaveAs(path);

        }

        public void deleteFile(string path) {

        }
    }
}