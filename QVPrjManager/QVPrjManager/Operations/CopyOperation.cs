using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QVPrjManager.Operations
{
    class CopyOperation
    {
        bool isSingle = false;
        string selectedProject = "";
        string[] targetProjects;
        TextBox resultsTextBox = new TextBox();

        List<string> sourceObjectLines = new List<string>();
        string operationName;
        string startTag;
        string endTag;
        bool isChartOnly = false;
        bool includeSheets = false;
        string types = "BM|BU|CH|CS|CT|IB|LA|LB|MB|SB|SL|SO|TB|TX";

        /// <summary>
        /// Initialize the class
        /// </summary>
        /// <param name="opname">The operation being performed - used for updates and error messages</param>
        /// <param name="st">Starting XML tag</param>
        /// <param name="et">Ending XML tag</param>
        /// <param name="chartsOnly">True if operating on chart objects only</param>
        public CopyOperation(string opname, string st, string et, bool chartsOnly)
        {
            this.operationName = opname;
            this.startTag = st;
            this.endTag = et;
            this.isChartOnly = chartsOnly;
            if (operationName.Equals("ColorMap"))
            {
                DialogResult dialogResult = MessageBox.Show("Perform ColorMap Operation on Sheet Objects as well?", "ColorMap Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                includeSheets = dialogResult == DialogResult.Yes;
            }

        }

        /// <summary>
        /// Perform the operation class is initialized to
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
                MessageBox.Show(operationName + " Copy Error - Nothing loaded from Master Object", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //updatedChartsTextBox.Clear();
            UpdateResults("Performing " + operationName + " Copy Operation...");

            string[] typeList = types.Split('|');
            foreach (string qvw in targetProjects)
            {
                string folder = qvw.Replace(".qvw", "-prj");
                if (isChartOnly)
                {
                    string[] targetList = Directory.GetFiles(folder, "CH*.xml");
                    UpdateSingleProject(targetList);
                    if (includeSheets)
                    {
                        targetList = Directory.GetFiles(folder, "SH*.xml");
                        UpdateSingleProject(targetList);
                    }
                }
                else
                {
                    foreach (string type in typeList)
                    {
                        string[] targetList = Directory.GetFiles(folder, string.Format("{0}*.xml", type));
                        UpdateSingleProject(targetList);
                    }
                }
            }
            UpdateResults("    Complete!" + Environment.NewLine);
        }

        /// <summary>
        /// Load the XML fragment from master object used to update other objects.
        /// </summary>
        private void LoadSourceObject()
        {
            // Get the Active Background from the master
            bool inObject = false;
            string xmlFile = selectedProject.Trim();
            string[] lines = File.ReadAllLines(xmlFile);
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
        /// Add text to the textbox on the form
        /// </summary>
        /// <param name="text">Text to add</param>
        private void UpdateResults(string text)
        {
            resultsTextBox.Text += text + Environment.NewLine;
            resultsTextBox.Refresh();
        }
    }
}
