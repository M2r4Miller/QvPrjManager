using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QlikView;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace QVPrjManager.Operations
{
    class QlikViewOperation
    {
        QlikView.Application application;

        /// <summary>
        /// Creates missing -prj folders, optionally refreshes existing -prj folders
        /// </summary>
        /// <param name="textBox">Textbox reference used for updates</param>
        /// <param name="isSingle">True if operating on a single project only</param>
        /// <param name="refreshPrj">True indicates existing -prj folders should be refreshed</param>
        /// <param name="useAutomation">True indicates QlikView Automation is being used</param>
        /// <param name="qvws">List of QVWs that are the targets of operations</param>
        internal bool CreatePRJFolders(TextBox textBox, bool isSingle, bool refreshPrj, bool useAutomation, string[] qvws)
        {
            textBox.Text += "Performing -prj maintenance prior to operation...";
            textBox.Refresh();
            bool prjCreated = false;
            bool prjEmpty = false;
            bool success = true;

            if(useAutomation)
                application = new QlikView.Application();
            foreach (string qvw in qvws)
            {
                string prjFolder = qvw.Replace(".qvw", "-prj");
                bool refresh = refreshPrj;
                if (!Directory.Exists(prjFolder))
                {
                    refresh = true;
                    textBox.Text += Environment.NewLine + "    Creating -prj Folder for " + qvw;
                    textBox.Refresh();
                    // Create -prj folder
                    Directory.CreateDirectory(prjFolder);
                    prjCreated = true;
                }
                else
                {
                    string[] prjFiles = Directory.EnumerateFiles(prjFolder).ToArray();
                    if(prjFiles.Length < 8 && !useAutomation)
                    {
                        MessageBox.Show("Empty -prj folder found for\n " + prjFolder.Replace("-prj", ".qvw"), "Empty -prj Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        prjEmpty = true;
                    }
                }
                if (refresh && useAutomation)
                {
                    textBox.Text += Environment.NewLine + "    Refreshing -prj Folder for " + qvw;
                    textBox.Refresh();
                    foreach (string file in Directory.EnumerateFiles(prjFolder))
                    {
                        File.Delete(file);
                    }
                    
                    // Populate (or repopulate) -prj folder
                    try
                    {
                        QlikView.Doc document = application.OpenDoc(qvw);
                        Thread.Sleep(1000);
                        document.Save();
                        document.CloseDoc();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("QV -prj Error: " + ee.Message, "QV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox.Text += "  ERROR Populating -prj Folder ...";
                        textBox.Refresh();
                        throw;
                    }
                }
            }
            if(useAutomation)
                application.Quit();
            if (prjCreated && !useAutomation)
            {
                MessageBox.Show("-prj folders were created, and must be populated before operations can be performed.", "Created -prj Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                success = false;
            }
            textBox.Text += Environment.NewLine + "    Complete!" + Environment.NewLine + Environment.NewLine;
            textBox.Refresh();

            if (prjEmpty)
                success = false;

            return success;
        }

        /// <summary>
        /// After performing the Operations, the QVWs are refreshed to solidify the changes made
        /// </summary>
        /// <param name="textBox">Textbox reference used for updates</param>
        /// <param name="qvws">List of QVWs that are the targets of operations</param>
        internal void RefreshQVW(TextBox textBox, string[] qvws)
        {
            application = new QlikView.Application();
            foreach (string qvw in qvws)
            {
                textBox.Text += Environment.NewLine + "    " + qvw;
                textBox.Refresh();

                try
                {
                    QlikView.Doc document = application.OpenDoc(qvw);
                    Thread.Sleep(1000);
                    document.Save();
                    document.CloseDoc();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("QV Refreshing Error: " + ee.Message, "QV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Text += "  ERROR Refreshing ...";
                    textBox.Refresh();
                    throw;
                }
            }
            application.Quit();
            textBox.Text += Environment.NewLine + "    Complete!" + Environment.NewLine;
            textBox.Refresh();
        }
    }
}
