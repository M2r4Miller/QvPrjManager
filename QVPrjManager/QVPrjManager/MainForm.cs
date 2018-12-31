using QVPrjManager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using QVPrjManager.Operations;
using QlikView;
using System.Threading;

namespace QVPrjManager
{
    public partial class MainForm : Form
    {
        Settings settings;
        CopyOperation copyOperation;
        WallpaperOperation wallpaperOperation;
        VariableOperation variableOperation;
        BackupOperation backupOperation = new BackupOperation();
        QlikViewOperation qlikViewOperation = new QlikViewOperation();

        string imageFileName;
        string masterFile;
        string[] targetDocuments;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            settings = new Settings();
            OperationsTreeView.ExpandAll();
        }

        /// <summary>
        /// Select the "Master" object that properties will be copied from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindProjectButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Select Master Object to work on";
            openFileDialog1.Filter = "Charts (CH*.xml)|CH*.xml|All (*.xml)|*.xml";
            openFileDialog1.ShowDialog();
            SelectedProjectTextBox.Text = openFileDialog1.FileName;
            masterFile = Path.GetFileName(SelectedProjectTextBox.Text);

            if (masterFile.StartsWith("CH"))
            {
                // add chart nodes
                TreeNode node = OperationsTreeView.Nodes.Add("ChartOnly", "Chart Operations");
                node.Nodes.Add("BackgroundColor", "Backgound Color");
                node.Nodes.Add("BackgroundImage", "Background Image");
                node.Nodes.Add("ColorMap", "ColorMap");
                OperationsTreeView.ExpandAll();
            }
            else
            {
                // remove chart nodes
                TreeNode node = OperationsTreeView.Nodes["ChartOnly"];
                if (node != null)
                    OperationsTreeView.Nodes.Remove(node);
            }
        }

        /// <summary>
        /// Choose either a single project or a folder containing multiple -prj folders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindTargetProjectButton_Click(object sender, EventArgs e)
        {
            if (SingleRadioButton.Checked)
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Title = "Select QVW to Update";
                openFileDialog1.Filter = "QlikView Application (*.qvw)|*.qvw";
                openFileDialog1.Multiselect = false;
                openFileDialog1.ShowDialog();
                TargetProjectTextBox.Text = openFileDialog1.FileName;
                targetDocuments = openFileDialog1.FileNames;
            }
            else
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Title = "Select Folder Containing QlikView Applications to Update";
                openFileDialog1.Filter = "QlikView Application (*.qvw)|*.qvw";
                openFileDialog1.ValidateNames = true;
                openFileDialog1.Multiselect = true;
                openFileDialog1.AddExtension = false;
                openFileDialog1.CheckFileExists = false;
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.ShowDialog();
                targetDocuments = openFileDialog1.FileNames;
                if (openFileDialog1.FileNames.Length > 1)
                    TargetProjectTextBox.Text = Path.GetDirectoryName(openFileDialog1.FileName) + " (Multiple Selected)";
                else
                    TargetProjectTextBox.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Perform all operations selected in the treeview control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PerformOperationButton_Click(object sender, EventArgs e)
        {
            // Get list of operations from the OperationsTreeView
            List<string> operations = new List<string>();
            foreach (TreeNode node in OperationsTreeView.Nodes)
            {
                if (node.Checked)
                    operations.Add(node.Text);
                foreach (TreeNode childNode in node.Nodes)
                {
                    if (childNode.Checked)
                        operations.Add(childNode.Text);
                }
            }

            // If there isn't anything selected, then there isn't anything to do
            if (operations.Count == 0)
            {
                MessageBox.Show("Must choose at least one operation first!", "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                OperationsTreeView.Focus();
                return;
            }

            bool variableMapping = operations.Contains("Variable Mapping");

            if (!variableMapping || (variableMapping && operations.Count() > 1))
            {
                if (string.IsNullOrEmpty(SelectedProjectTextBox.Text.Trim()) || !File.Exists(SelectedProjectTextBox.Text.Trim()))
                {
                    MessageBox.Show("Select a master chart first!", "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    FindProjectButton.Focus();
                    return;
                }
            }
            if (string.IsNullOrEmpty(TargetProjectTextBox.Text.Trim()))
            {
                MessageBox.Show("Choose a Target Project first!", "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                FindTargetProjectButton.Focus();
                return;
            }

            UpdatedChartsTextBox.Clear();

            // Create and update -prj folders if needed and then backup -prj folders
            bool success = qlikViewOperation.CreatePRJFolders(UpdatedChartsTextBox, SingleRadioButton.Checked, RefreshPrjCheckBox.Checked, AutomationCheckBox.Checked, targetDocuments);
            if(!success)
            {
                MessageBox.Show("Open each QVW that you wish to update and click \"Save\" in order to populate the associated -prj folder. Then run this app again.", "Manual -prj update notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            backupOperation.BackupAll(UpdatedChartsTextBox, SingleRadioButton.Checked, targetDocuments);

            foreach (string operation in operations)
            {
                switch (operation)
                {
                    case "ColorMap":
                        copyOperation = new CopyOperation("ColorMap", "<ColorMap>", "</ColorMap>", true);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Background Color":
                        copyOperation = new CopyOperation("Frame Background Color", "<BackgroundColor>", "</BackgroundColor>", true);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        copyOperation = new CopyOperation("Frame Background Color Transparency", "<BkgAlpha>", "</BkgAlpha>", true);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Background Image":
                        copyOperation = new CopyOperation("Frame Background Image", "<Bmp enctype=\"base64\">", "</Bmp>", true);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        copyOperation = new CopyOperation("Frame Background Image Transparency", "<BkgAlpha>", "</BkgAlpha>", true);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        copyOperation = new CopyOperation("Frame Background Image Coverage", "<FullBkgBmp>", "</FullBkgBmp>", true);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Active Background":
                        copyOperation = new CopyOperation("Active Background", "<ActiveBgColor>", "</ActiveBgColor>", false);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Active Foreground":
                        copyOperation = new CopyOperation("Active Foreground", "<ActiveFgColor>", "</ActiveFgColor>", false);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Inactive Background":
                        copyOperation = new CopyOperation("Inactive Background", "<BgColor>", "</BgColor>", false);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Inactive Foreground":
                        copyOperation = new CopyOperation("Inactive Foreground", "<FgColor>", "</FgColor>", false);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Font":
                        copyOperation = new CopyOperation("Font", "<Font>", "</Font>", false);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Caption Font":
                        copyOperation = new CopyOperation("Caption Font", "<CaptionFont>", "</CaptionFont>", false);
                        copyOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Wallpaper Image":
                        wallpaperOperation = new WallpaperOperation("<WallpaperPic enctype=\"base64\">", "</WallpaperPic>");
                        wallpaperOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    case "Variable Mapping":
                        bool ignoreSV = (IgnoreSystemVariablesCheckBox.Visible ? IgnoreSystemVariablesCheckBox.Checked : true);
                        tabControl1.SelectedTab = VariableMappingTabPage;
                        tabControl1.Refresh();
                        VariableMappingTabPage.Select();
                        variableOperation = new VariableOperation("  <VariableProperties>",
                                                                    "  </VariableProperties>",
                                                                    VariableMappingDataGridView,
                                                                    ObjectTextBox,
                                                                    ObjectCountTextBox,
                                                                    ObjectProgressBar,
                                                                    VariableTextBox,
                                                                    VariableProgressBar,
                                                                    ignoreSV
                                                                 );
                        variableOperation.PerformOperation(UpdatedChartsTextBox, SingleRadioButton.Checked, SelectedProjectTextBox.Text, targetDocuments);
                        break;
                    default:
                        break;
                }
            }
            UpdatedChartsTextBox.Text += string.Format("Refreshing project{0} after operation{0}...", (SingleRadioButton.Checked ? "" : "(s)"));
            UpdatedChartsTextBox.Focus();
            UpdatedChartsTextBox.SelectAll();
            UpdatedChartsTextBox.ScrollToCaret();
            UpdatedChartsTextBox.Refresh();

            if (AutomationCheckBox.Checked)
                qlikViewOperation.RefreshQVW(UpdatedChartsTextBox, targetDocuments);

            MessageBox.Show("Operations Complete!", "Copy Operations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //IgnoreSystemVariablesCheckBox.Visible = false;
        }

        /// <summary>
        /// Load new image into PictureBox control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImageFromDiskButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG images|*.png|JPG images|*.jpg|All files|*.*";
            openFileDialog1.Title = "Select Image file to open";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog1.OpenFile());
                WallpaperPictureBox.Image = bitmap;
                imageFileName = openFileDialog1.FileName;
                Refresh();
            }
        }

        /// <summary>
        /// Base64 encode the image and write it out to TopLayout.xml in the project that contains the Master object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyImageButton_Click(object sender, EventArgs e)
        {
            if (WallpaperPictureBox.Image == null)
            {
                MessageBox.Show("Must Load an Image first!", "Copy Image Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Base64 encode the image first
            byte[] data = File.ReadAllBytes(imageFileName);
            string s = Convert.ToBase64String(data);
            List<string> lines76 = new List<string>();
            int numLines = s.Length / 76;
            bool remainder = true;

            remainder = !(numLines * 76 == s.Length);
            lines76.Add("<WallpaperPic enctype=\"base64\">");
            for (int i = 0; i < numLines; i++)
            {
                lines76.Add(s.Substring(i * 76, 76));
            }
            if (remainder)
            {
                lines76.Add(s.Substring(numLines * 76));
            }
            lines76.Add("</WallpaperPic>");

            string target = Path.GetDirectoryName(SelectedProjectTextBox.Text.Trim()) + "\\TopLayout.xml";
            //foreach (string target in targetList)
            {
                // Open the target and place the ActiveBackground appropriately
                string[] lines = File.ReadAllLines(target);
                List<string> outLines = new List<string>();
                bool inObject = false;
                bool addObject = false;
                // Replace the ActiveBackground in the target
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Contains("<WallpaperPic enctype=\"base64\">"))
                    {
                        inObject = true;
                        if (!addObject)
                        {
                            outLines.AddRange(lines76);
                            addObject = true;
                        }
                    }
                    if (inObject)
                        if (lines[i].Contains("</WallpaperPic>"))
                        {
                            inObject = false;
                            continue;
                        }

                    if (!inObject)
                        outLines.Add(lines[i]);
                }
                // Update display
                //UpdateResults(target);

                // Write out the target
                File.WriteAllLines(target, outLines.ToArray(), System.Text.Encoding.UTF8);
            }
            MessageBox.Show("Wallpaper Updated in Master!", "Copy Wallpaper Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OperationsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            IgnoreSystemVariablesCheckBox.Visible = false;
            foreach (TreeNode node in OperationsTreeView.Nodes)
            {
                if (node.Checked)
                    if (node.Text.Equals("Variable Mapping"))
                    {
                        IgnoreSystemVariablesCheckBox.Visible = true;
                        break;
                    }
            }
            IgnoreSystemVariablesCheckBox.Refresh();
            OperationsTabPage.Refresh();
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
