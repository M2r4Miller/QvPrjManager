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

        public void CreatePRJFolders(TextBox textBox, bool isSingle, bool refreshPrj, string[] qvws)
        {
            textBox.Text += "Performing -prj maintenance prior to operation...";
            textBox.Refresh();

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
                }
                if (refresh)
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
            application.Quit();
            textBox.Text += Environment.NewLine + "    Complete!" + Environment.NewLine + Environment.NewLine;
            textBox.Refresh();
        }

        public void RefreshQVW(TextBox textBox, string[] qvws)
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
