using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using QVPrjManager.Models;

namespace QVPrjManager.Operations
{
    class VariableOperation
    {
        bool isSingle = false;
        string selectedProject = "";
        string[] targetProjects;
        TextBox resultsTextBox = new TextBox();
        DataGridView gridView = new DataGridView();

        List<VariableStat> variableStats = new List<VariableStat>();
        List<string> sourceObjectLines = new List<string>();
        string startTag;
        string endTag;

        TextBox objectTextBox;
        TextBox objectCountTextBox;
        ProgressBar objectProgressBar;
        TextBox variableTextBox;
        ProgressBar variableProgressBar;

        bool ignoreSystemVariables = false;
        string[] reservedVariables;

        /// <summary>
        /// Initialize the class
        /// </summary>
        /// <param name="st">Starting XML tag</param>
        /// <param name="et">Ending XML tag</param>
        public VariableOperation(string st, string et, DataGridView dataGrid, TextBox objectTB, TextBox objectCountTB, ProgressBar objectPB, TextBox variableTB, ProgressBar variablePB, bool ignoreSV)
        {
            this.startTag = st;
            this.endTag = et;
            this.gridView = dataGrid;
            this.gridView.Rows.Clear();
            this.gridView.Refresh();
            this.objectTextBox = objectTB;
            this.objectCountTextBox = objectCountTB;
            this.objectProgressBar = objectPB;
            this.variableTextBox = variableTB;
            this.variableProgressBar = variablePB;
            this.ignoreSystemVariables = ignoreSV;
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
            if (ignoreSystemVariables)
            {
                string reservedWordPath = AppDomain.CurrentDomain.BaseDirectory + "\\QVSystemVars.txt";
                if (File.Exists(reservedWordPath))
                    reservedVariables = File.ReadAllLines(reservedWordPath);
            }
            UpdateResults("Performing Variable Analysis Operation...");

            foreach (string qvw in targetProjects)
            {
                string folder = qvw.Replace(".qvw", "-prj");
                string[] targetList = Directory.GetFiles(folder, "AllProperties.xml");
                UpdateSingleProject(targetList[0], folder, Path.GetFileName(qvw));
            }
            UpdateResults(Environment.NewLine + "    Complete!");
        }

        private void UpdateSingleProject(string target, string folder, string qvwName)
        {
            string[] lines;
            List<string> variables = new List<string>();
            List<string> objectList = new List<string>();
            List<Variable> variableDetails = new List<Variable>();

            // Open the target and read all Variables
            lines = File.ReadAllLines(target);

            int startVariables = Array.IndexOf(lines, startTag) + 1;
            int endVariables = Array.LastIndexOf(lines, endTag);
            // Read each Variable name
            for (int i = startVariables; i < endVariables; i++)
            {
                // Ignore lines where start and end tags are on the same line
                if (lines[i].Contains(startTag) && !lines[i].Contains(endTag.Trim()))
                {
                    string varName = lines[i + 1].Replace("<Name>", "").Replace("</Name>", "").Trim();
                    if(reservedVariables == null || !reservedVariables.Contains(varName))
                        variables.Add(varName);
                }
            }

            variableProgressBar.Maximum = variables.Count();
            variableProgressBar.Step = 1;
            variableProgressBar.Value = 0;

            DataGridViewRow row = (DataGridViewRow)gridView.RowTemplate.Clone();
            row.CreateCells(gridView, qvwName, variables.Count(), 0, 0, 0);
            int idx = gridView.Rows.Add(row);

            variableStats.Add(new VariableStat
            {
                QVWName = qvwName,
                NumVariables = variables.Count(),
                NumUsed = 0,
                NumUses = 0,
                NumUnUsed = 0,
                GridRowIdx = idx
            });
            VariableStat stat = (from v in variableStats
                                 where v.QVWName.Equals(qvwName)
                                 select v).First();

            objectList.AddRange(Directory.GetFiles(folder, "*.xml").ToList<string>());
            objectList.AddRange(Directory.GetFiles(folder, "*.txt").ToList<string>());

            // Open and chech each object for presence of any variables.
            // When found, record the name of the object and line number variable was found
            objectProgressBar.Maximum = objectList.Count();
            objectProgressBar.Step = 1;
            objectProgressBar.Value = 0;

            int objectIdx = 0;
            foreach (string objectName in objectList)
            {
                string objectNameOnly = objectName.Replace(folder + "\\", "").Replace(".xml", "");
                objectIdx++;
                objectTextBox.Text = objectNameOnly;
                objectTextBox.Refresh();
                objectCountTextBox.Text = string.Format("{0} / {1}", objectIdx, objectList.Count());
                objectCountTextBox.Refresh();
                objectProgressBar.PerformStep();

                if (objectName.Contains("AllProperties.xml") ||
                    objectName.Contains("DocProperties.xml") ||
                    objectName.Contains("DocInternals.xml")) continue;

                bool inBase64 = false;
                string base64EndTag = "";

                lines = File.ReadAllLines(objectName);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < lines.Length; i++)
                {
                    // Ignore comment lines
                    if (lines[i].Trim().StartsWith("//")) continue;

                    if (lines[i].Contains("enctype=\"base64\""))
                    {
                        // If the end tag is on same line as start tag, skip it.
                        if (lines[i].Contains("base64\"></"))
                            continue;

                        inBase64 = true;
                        base64EndTag = lines[i].Replace(" enctype=\"base64\"", "").Trim().Replace("<", "</");
                        continue;
                    }

                    if (inBase64)
                    {
                        if (lines[i].Contains(base64EndTag))
                            inBase64 = false;
                        continue;
                    }

                    Application.DoEvents();
                    sb.AppendLine(lines[i]);
                }
                string allLines = sb.ToString();
                variableProgressBar.Value = 0;
                for (int j = 0; j < variables.Count; j++)
                {
                    variableTextBox.Text = variables[j];
                    variableTextBox.Refresh();
                    variableProgressBar.PerformStep();
                    Match m = Regex.Match(allLines, string.Format("\\b{0}\\b", variables[j]));
                    while (m.Success)
                    {
                        Variable variable = (from v in variableDetails
                                             where v.VariableName.Equals(variables[j])
                                             select v).FirstOrDefault();


                        stat.NumUses++;
                        // Only increment the number used if it is the first time the variable has been seen as used
                        if (variable == null)
                            stat.NumUsed++;

                        variableDetails.Add(new Variable
                        {
                            VariableName = variables[j],
                            IsUsed = true,
                            ObjectName = objectNameOnly
                        });
                        if (stat.NumUses % 10 == 0)
                            UpdateGrid(stat);
                        Application.DoEvents();
                        m = m.NextMatch();
                    }
                }
                // Update the grid after every object scanned.
                UpdateGrid(stat);
            }
            // For each used variable, determine what sheet the object is on
            lines = File.ReadAllLines(folder + "\\QlikViewProject.xml");
            int startSheets = Array.IndexOf(lines, "  <SHEETS>") + 1;
            int endSheets = Array.LastIndexOf(lines, "  </SHEETS>");

            foreach (Variable variable in variableDetails)
            {
                if (string.IsNullOrEmpty(variable.ObjectName)) continue;

                if (variable.ObjectName.StartsWith("SH"))
                {
                    variable.SheetName = variable.ObjectName;
                    continue;
                }
                string currentSheet = "";
                for (int i = startSheets; i < endSheets; i++)
                {
                    if (lines[i].Contains("<SheetId>"))
                    {
                        currentSheet = lines[i].Replace("<SheetId>Document\\", "").Replace("</SheetId>", "").Trim();
                        continue;
                    }
                    if (lines[i].Contains(variable.ObjectName + "</ObjectId>"))
                    {
                        variable.SheetName = currentSheet;
                        break;
                    }
                }
            }

            // Add Variables to the list that are unused
            //VariableStat stat = (from v in variableStats
            //                     where v.QVWName.Equals(qvwName)
            //                     select v).First();
            foreach (string variable in variables)
            {
                Variable varItem = (from v in variableDetails
                                    where v.VariableName.Equals(variable)
                                    select v).FirstOrDefault();
                if (varItem == null)
                {
                    variableDetails.Add(new Variable
                    {
                        VariableName = variable,
                        IsUsed = false
                    });
                    stat.NumUnUsed++;
                    UpdateGrid(stat);
                }
            }

            // Write out variable usage report
            string fileName = folder.Replace("-prj", "-VariableUsage.txt");
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Used?\tName\tSheet\tObject");
                foreach (Variable item in variableDetails)
                {
                    sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", (item.IsUsed ? "Yes" : "No"), item.VariableName, item.SheetName, item.ObjectName));
                }
            }

            // Update display
            UpdateResults("    See " + fileName + " for results");
            if(stat.NumUnUsed > 0)
            {
               DialogResult dr = MessageBox.Show("Mapping Results are Saved in " + fileName + Environment.NewLine + Environment.NewLine +
                   "Delete Unused Variables from " + qvwName + "?", "Variable Mapping", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(dr == DialogResult.Yes)
                {
                    DeleteUnusedVariables(target, variableDetails);
                }
            }
        }

        private void DeleteUnusedVariables(string target, List<Variable> variableDetails)
        {
            // Read in reserved variable names regardless of whether they are ignored or not during mapping.
            // This is so we never delete reserved variables
            string reservedWordPath = AppDomain.CurrentDomain.BaseDirectory + "\\QVSystemVars.txt";
            if (File.Exists(reservedWordPath))
                reservedVariables = File.ReadAllLines(reservedWordPath);

            var unUsedQuery = from v in variableDetails
                              where !v.IsUsed
                              select v;
            // Open the target and read all Variables
            string[] lines = File.ReadAllLines(target);
            List<string> outLines = new List<string>();

            int startVariables = Array.IndexOf(lines, startTag) + 1;
            int endVariables = Array.LastIndexOf(lines, endTag);

            for (int i = 0; i < startVariables; i++)
            {
                outLines.Add(lines[i]);
            }
            
            // Read each Variable name
            for (int i = startVariables; i < endVariables; i++)
            {
                // Ignore lines where start and end tags are on the same line
                if (lines[i].Contains(startTag) && !lines[i].Contains(endTag.Trim()))
                {
                    string varName = lines[i + 1].Replace("<Name>", "").Replace("</Name>", "").Trim();
                    // Preserve all reserved variables
                    if (reservedVariables == null || reservedVariables.Contains(varName))
                    {
                        outLines.Add("  " + startTag);
                        for (int j = i + 1; j < i + 30; j++)
                        {
                            outLines.Add(lines[j]);
                            if (lines[j].Equals("  " + endTag))
                                break;
                        }
                    }
                    else
                    {
                        Variable variable = (from v in variableDetails
                                             where v.VariableName.Equals(varName)
                                                && !v.IsUsed
                                             select v).FirstOrDefault();
                        if (variable == null)
                        {
                            outLines.Add("  " + startTag);
                            for (int j = i + 1; j < i + 30; j++)
                            {
                                outLines.Add(lines[j]);
                                if (lines[j].Equals("  " + endTag))
                                    break;
                            }
                        }
                    }
                }
            }
            for (int i = endVariables; i < lines.Length; i++)
            {
                outLines.Add(lines[i]);
            }
            File.WriteAllLines(target, outLines.ToArray(), Encoding.UTF8);
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

        private void UpdateGrid(VariableStat stat)
        {
            DataGridViewRow row = gridView.Rows[stat.GridRowIdx];
            row.Cells[0].Value = stat.QVWName;
            row.Cells[1].Value = stat.NumVariables;
            row.Cells[2].Value = stat.NumUsed;
            row.Cells[3].Value = stat.NumUses;
            row.Cells[4].Value = stat.NumUnUsed;
            gridView.Refresh();
        }
    }
}
