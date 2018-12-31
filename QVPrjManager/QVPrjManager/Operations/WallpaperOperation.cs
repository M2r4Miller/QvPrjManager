using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace QVPrjManager.Operations
{
    class WallpaperOperation
    {
        bool isSingle = false;
        string selectedProject = "";
        string[] targetProjects;
        TextBox resultsTextBox = new TextBox();

        List<string> sourceObjectLines = new List<string>();
        string startTag;
        string endTag;

        string picturesFolder;

        /// <summary>
        /// Initialize the class
        /// </summary>
        /// <param name="st">Starting XML tag</param>
        /// <param name="et">Ending XML tag</param>
        public WallpaperOperation(string st, string et)
        {
            this.startTag = st;
            this.endTag = et;
            //this.wallpaperPictureBox = pb;
            picturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        /// <summary>
        /// Perform the wallpaper copy operation
        /// </summary>
        /// <param name="updatedChartsTextBox">Textbox reference used for updates</param>
        /// <param name="single">True if operating on a single project only</param>
        /// <param name="selProject">Name and path of master object</param>
        /// <param name="target">Path to project(s) to update</param>
        internal void PerformOperation(TextBox updatedChartsTextBox, bool single, string selProject, string[] targets)
        {
            resultsTextBox = updatedChartsTextBox;
            isSingle = single;
            selectedProject = selProject;
            targetProjects = targets;

            LoadSourceObject();
            if (sourceObjectLines.Count == 0)
            {
                MessageBox.Show("Wallpaper Copy Error - Nothing loaded from Master Object", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            UpdateResults("Performing Wallpaper Copy Operation...");

            foreach (string qvw in targetProjects)
            {
                string folder = qvw.Replace(".qvw", "-prj");
                string[] targetList = Directory.GetFiles(folder, "TopLayout.xml");
                UpdateSingleProject(targetList);
            }
            UpdateResults(Environment.NewLine + "    Complete!");
        }

        private void UpdateSingleProject(string[] targetList)
        {
            string[] lines;
            bool inObject;

            foreach (string target in targetList)
            {
                // Open the target and place the ActiveBackground appropriately
                lines = File.ReadAllLines(target);
                List<string> outLines = new List<string>();
                inObject = false;
                bool addObject = false;
                // Replace the ActiveBackground in the target
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Contains(startTag))
                    {
                        inObject = true;
                        if (!addObject)
                        {
                            outLines.AddRange(sourceObjectLines);
                            addObject = true;
                        }
                    }
                    if (inObject)
                        if (lines[i].Contains(endTag))
                        {
                            inObject = false;
                            continue;
                        }

                    if (!inObject)
                        outLines.Add(lines[i]);
                }
                // Update display
                UpdateResults("    " + target);

                // Write out the target
                File.WriteAllLines(target, outLines.ToArray(), System.Text.Encoding.UTF8);
            }
        }

        /// <summary>
        /// Load the XML fragment from master object used to update other objects.
        /// </summary>
        private void LoadSourceObject()
        {
            string topLayout = Path.GetDirectoryName(selectedProject) + "\\TopLayout.xml";
            // Get the Active Background from the master
            bool inObject = false;

            string[] lines = File.ReadAllLines(topLayout);
            inObject = false;
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Contains(startTag))
                    inObject = true;
                if (inObject)
                    if (lines[i].Contains(endTag))
                    {
                        inObject = false;
                        sourceObjectLines.Add(lines[i]);
                        continue;
                    }
                    else
                        sourceObjectLines.Add(lines[i]);
            }
        }

        /// <summary>
        /// Update a project
        /// </summary>
        /// <param name="targetList">List of XML files to update</param>
        private void UpdateResults(string text)
        {
            resultsTextBox.Text += text + Environment.NewLine;
            resultsTextBox.Focus();
            resultsTextBox.SelectAll();
            resultsTextBox.ScrollToCaret();
            resultsTextBox.Refresh();
        }
    }
}
