using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace QVPrjManager.Operations
{
    class BackupOperation
    {
        internal void BackupAll(TextBox textBox, bool isSingle, string[] qvws)
        {            
            // Do the backup prior to operations (Create and populate -prj folder if necessary)
            textBox.Text += string.Format("Backing up project{0} prior to operation...", (isSingle ? "" : "(s)"));
            textBox.Refresh();

            // Back them up
            foreach (string qvw in qvws)
            {
                string prjFolder = qvw.Replace(".qvw", "-prj");

                textBox.Text += Environment.NewLine + "    " + prjFolder;
                BackupProject(prjFolder);
            }
            textBox.Text += Environment.NewLine + "    Complete!" + Environment.NewLine + Environment.NewLine;
            textBox.Refresh();
        }
        /// <summary>
        /// Zip the contents of the target project before operating on it
        /// </summary>
        /// <param name="projectFolder">Project folder being operated on</param>
        /// <returns>Name of the backup ZIP file</returns>
        internal string BackupProject(string projectFolder)
        {
            //int sep = projectFolder.LastIndexOf("\\") + 1;
            string zipName = GetZipName(projectFolder.Trim());
            if (File.Exists(zipName))
                File.Delete(zipName);

            ZipFile.CreateFromDirectory(projectFolder, zipName);
            return zipName;
        }

        /// <summary>
        /// Determine correct name for the ZIP backup file
        /// </summary>
        /// <param name="targetFolder">Project folder being operated on</param>
        /// <returns>Zip file name for the project</returns>
        private string GetZipName(string targetFolder)
        {
            string zipName = targetFolder +"_001.zip";
            int bslash = targetFolder.LastIndexOf("\\");
            string zipFolder = targetFolder.Substring(0, bslash);
            bslash += 1;
            string zipFile = targetFolder.Substring(bslash) + "*.zip";
            string[] zipList = Directory.GetFiles(zipFolder, zipFile);
            zipName = string.Format("{0}_{1:D3}.zip", targetFolder, zipList.Length + 1);
            return zipName;
        }
    }
}
