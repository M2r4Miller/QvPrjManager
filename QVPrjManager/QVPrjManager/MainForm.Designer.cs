﻿namespace QVPrjManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Active Background");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Active Foreground");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Inactive Background");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Inactive Foreground");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Colors", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Font");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Caption Font");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Fonts", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Wallpaper Image");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Variable Mapping");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectedProjectTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FindProjectButton = new System.Windows.Forms.Button();
            this.OperationsTreeView = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OperationsTabPage = new System.Windows.Forms.TabPage();
            this.IgnoreSystemVariablesCheckBox = new System.Windows.Forms.CheckBox();
            this.RefreshPrjCheckBox = new System.Windows.Forms.CheckBox();
            this.UpdatedChartsTextBox = new System.Windows.Forms.TextBox();
            this.PerformOperationButton = new System.Windows.Forms.Button();
            this.WallpaperTabPage = new System.Windows.Forms.TabPage();
            this.CopyImageButton = new System.Windows.Forms.Button();
            this.LoadImageFromDiskButton = new System.Windows.Forms.Button();
            this.WallpaperPictureBox = new System.Windows.Forms.PictureBox();
            this.VariableMappingTabPage = new System.Windows.Forms.TabPage();
            this.VariableTextBox = new System.Windows.Forms.TextBox();
            this.ObjectCountTextBox = new System.Windows.Forms.TextBox();
            this.ObjectTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.VariableProgressBar = new System.Windows.Forms.ProgressBar();
            this.ObjectProgressBar = new System.Windows.Forms.ProgressBar();
            this.VariableMappingDataGridView = new System.Windows.Forms.DataGridView();
            this.qvwColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varCountTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varCountUsedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varCountUsesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varCountUnusedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TargetProjectTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FindTargetProjectButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.MultipleRadioButton = new System.Windows.Forms.RadioButton();
            this.SingleRadioButton = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AutomationCheckBox = new System.Windows.Forms.CheckBox();
            this.InfoButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.OperationsTabPage.SuspendLayout();
            this.WallpaperTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WallpaperPictureBox)).BeginInit();
            this.VariableMappingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableMappingDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Filter = "xml files|*.xml|All files|*.*";
            // 
            // SelectedProjectTextBox
            // 
            this.SelectedProjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedProjectTextBox.Location = new System.Drawing.Point(132, 12);
            this.SelectedProjectTextBox.Name = "SelectedProjectTextBox";
            this.SelectedProjectTextBox.Size = new System.Drawing.Size(678, 20);
            this.SelectedProjectTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.SelectedProjectTextBox, "Choose XML file from existing -prj folder to use as the\r\nMaster object, from whic" +
        "h properties will be copied to\r\nother QVWs.\r\n\r\nChart objects work best (CH*.xml)" +
        "!");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Master Object Path:";
            // 
            // FindProjectButton
            // 
            this.FindProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindProjectButton.Location = new System.Drawing.Point(816, 12);
            this.FindProjectButton.Name = "FindProjectButton";
            this.FindProjectButton.Size = new System.Drawing.Size(25, 20);
            this.FindProjectButton.TabIndex = 1;
            this.FindProjectButton.Text = "...";
            this.toolTip1.SetToolTip(this.FindProjectButton, "Click to choose the Master Object");
            this.FindProjectButton.UseVisualStyleBackColor = true;
            this.FindProjectButton.Click += new System.EventHandler(this.FindProjectButton_Click);
            // 
            // OperationsTreeView
            // 
            this.OperationsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationsTreeView.CheckBoxes = true;
            this.OperationsTreeView.HotTracking = true;
            this.OperationsTreeView.Location = new System.Drawing.Point(3, 39);
            this.OperationsTreeView.Name = "OperationsTreeView";
            treeNode1.Name = "Node5";
            treeNode1.Text = "Active Background";
            treeNode2.Name = "Node6";
            treeNode2.Text = "Active Foreground";
            treeNode3.Name = "Node7";
            treeNode3.Text = "Inactive Background";
            treeNode4.Name = "Node8";
            treeNode4.Text = "Inactive Foreground";
            treeNode5.Name = "ColorOperations";
            treeNode5.Text = "Colors";
            treeNode6.Name = "Node9";
            treeNode6.Text = "Font";
            treeNode7.Name = "Node10";
            treeNode7.Text = "Caption Font";
            treeNode8.Name = "Node2";
            treeNode8.Text = "Fonts";
            treeNode9.Name = "Node11";
            treeNode9.Text = "Wallpaper Image";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Variable Mapping";
            treeNode10.ToolTipText = "Reports Unused and Where used";
            this.OperationsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode8,
            treeNode9,
            treeNode10});
            this.OperationsTreeView.Size = new System.Drawing.Size(215, 296);
            this.OperationsTreeView.TabIndex = 0;
            this.toolTip1.SetToolTip(this.OperationsTreeView, "Choose one or more operations to perform");
            this.OperationsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.OperationsTreeView_AfterCheck);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.OperationsTabPage);
            this.tabControl1.Controls.Add(this.WallpaperTabPage);
            this.tabControl1.Controls.Add(this.VariableMappingTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 338);
            this.tabControl1.TabIndex = 0;
            // 
            // OperationsTabPage
            // 
            this.OperationsTabPage.Controls.Add(this.IgnoreSystemVariablesCheckBox);
            this.OperationsTabPage.Controls.Add(this.RefreshPrjCheckBox);
            this.OperationsTabPage.Controls.Add(this.UpdatedChartsTextBox);
            this.OperationsTabPage.Controls.Add(this.PerformOperationButton);
            this.OperationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.OperationsTabPage.Name = "OperationsTabPage";
            this.OperationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OperationsTabPage.Size = new System.Drawing.Size(593, 312);
            this.OperationsTabPage.TabIndex = 0;
            this.OperationsTabPage.Text = "Operations Results";
            this.OperationsTabPage.UseVisualStyleBackColor = true;
            // 
            // IgnoreSystemVariablesCheckBox
            // 
            this.IgnoreSystemVariablesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IgnoreSystemVariablesCheckBox.AutoSize = true;
            this.IgnoreSystemVariablesCheckBox.Checked = true;
            this.IgnoreSystemVariablesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreSystemVariablesCheckBox.Location = new System.Drawing.Point(192, 9);
            this.IgnoreSystemVariablesCheckBox.Name = "IgnoreSystemVariablesCheckBox";
            this.IgnoreSystemVariablesCheckBox.Size = new System.Drawing.Size(261, 17);
            this.IgnoreSystemVariablesCheckBox.TabIndex = 5;
            this.IgnoreSystemVariablesCheckBox.Text = "Ignore System Variables When Mapping Variables";
            this.toolTip1.SetToolTip(this.IgnoreSystemVariablesCheckBox, "When checked, any variable listed in QVSystemVars.txt\r\nfile located in same folde" +
        "r as the EXE will be ignored\r\nduring the mapping process.");
            this.IgnoreSystemVariablesCheckBox.UseVisualStyleBackColor = true;
            this.IgnoreSystemVariablesCheckBox.Visible = false;
            // 
            // RefreshPrjCheckBox
            // 
            this.RefreshPrjCheckBox.AutoSize = true;
            this.RefreshPrjCheckBox.Location = new System.Drawing.Point(16, 9);
            this.RefreshPrjCheckBox.Name = "RefreshPrjCheckBox";
            this.RefreshPrjCheckBox.Size = new System.Drawing.Size(170, 17);
            this.RefreshPrjCheckBox.TabIndex = 0;
            this.RefreshPrjCheckBox.Text = "Refresh -prj Prior to Operations";
            this.toolTip1.SetToolTip(this.RefreshPrjCheckBox, "If using Automation, this forces the refresh of -prj folders before operations");
            this.RefreshPrjCheckBox.UseVisualStyleBackColor = true;
            // 
            // UpdatedChartsTextBox
            // 
            this.UpdatedChartsTextBox.AcceptsReturn = true;
            this.UpdatedChartsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdatedChartsTextBox.Location = new System.Drawing.Point(6, 75);
            this.UpdatedChartsTextBox.Multiline = true;
            this.UpdatedChartsTextBox.Name = "UpdatedChartsTextBox";
            this.UpdatedChartsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.UpdatedChartsTextBox.Size = new System.Drawing.Size(581, 231);
            this.UpdatedChartsTextBox.TabIndex = 2;
            // 
            // PerformOperationButton
            // 
            this.PerformOperationButton.Location = new System.Drawing.Point(16, 32);
            this.PerformOperationButton.Name = "PerformOperationButton";
            this.PerformOperationButton.Size = new System.Drawing.Size(100, 23);
            this.PerformOperationButton.TabIndex = 1;
            this.PerformOperationButton.Text = "Perform Operation";
            this.toolTip1.SetToolTip(this.PerformOperationButton, "Click this to perform the operations chosen on the target project(s)");
            this.PerformOperationButton.UseVisualStyleBackColor = true;
            this.PerformOperationButton.Click += new System.EventHandler(this.PerformOperationButton_Click);
            // 
            // WallpaperTabPage
            // 
            this.WallpaperTabPage.Controls.Add(this.CopyImageButton);
            this.WallpaperTabPage.Controls.Add(this.LoadImageFromDiskButton);
            this.WallpaperTabPage.Controls.Add(this.WallpaperPictureBox);
            this.WallpaperTabPage.Location = new System.Drawing.Point(4, 22);
            this.WallpaperTabPage.Name = "WallpaperTabPage";
            this.WallpaperTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WallpaperTabPage.Size = new System.Drawing.Size(593, 312);
            this.WallpaperTabPage.TabIndex = 1;
            this.WallpaperTabPage.Text = "Wallpaper";
            this.toolTip1.SetToolTip(this.WallpaperTabPage, "This tab allows updating the wallpaper image of the project that contains the Mas" +
        "ter Object");
            this.WallpaperTabPage.UseVisualStyleBackColor = true;
            // 
            // CopyImageButton
            // 
            this.CopyImageButton.Location = new System.Drawing.Point(167, 6);
            this.CopyImageButton.Name = "CopyImageButton";
            this.CopyImageButton.Size = new System.Drawing.Size(155, 23);
            this.CopyImageButton.TabIndex = 1;
            this.CopyImageButton.Text = "Copy Image to Master";
            this.toolTip1.SetToolTip(this.CopyImageButton, "Update the wallpaper in the project that contains the Master Object");
            this.CopyImageButton.UseVisualStyleBackColor = true;
            this.CopyImageButton.Click += new System.EventHandler(this.CopyImageButton_Click);
            // 
            // LoadImageFromDiskButton
            // 
            this.LoadImageFromDiskButton.Location = new System.Drawing.Point(6, 6);
            this.LoadImageFromDiskButton.Name = "LoadImageFromDiskButton";
            this.LoadImageFromDiskButton.Size = new System.Drawing.Size(155, 23);
            this.LoadImageFromDiskButton.TabIndex = 0;
            this.LoadImageFromDiskButton.Text = "Load New Image From Disk";
            this.toolTip1.SetToolTip(this.LoadImageFromDiskButton, "Select and load a new image to become wallpaper in the project that contains the " +
        "Master Object");
            this.LoadImageFromDiskButton.UseVisualStyleBackColor = true;
            this.LoadImageFromDiskButton.Click += new System.EventHandler(this.LoadImageFromDiskButton_Click);
            // 
            // WallpaperPictureBox
            // 
            this.WallpaperPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WallpaperPictureBox.Location = new System.Drawing.Point(6, 35);
            this.WallpaperPictureBox.Name = "WallpaperPictureBox";
            this.WallpaperPictureBox.Size = new System.Drawing.Size(581, 271);
            this.WallpaperPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WallpaperPictureBox.TabIndex = 0;
            this.WallpaperPictureBox.TabStop = false;
            // 
            // VariableMappingTabPage
            // 
            this.VariableMappingTabPage.Controls.Add(this.VariableTextBox);
            this.VariableMappingTabPage.Controls.Add(this.ObjectCountTextBox);
            this.VariableMappingTabPage.Controls.Add(this.ObjectTextBox);
            this.VariableMappingTabPage.Controls.Add(this.label2);
            this.VariableMappingTabPage.Controls.Add(this.label1);
            this.VariableMappingTabPage.Controls.Add(this.VariableProgressBar);
            this.VariableMappingTabPage.Controls.Add(this.ObjectProgressBar);
            this.VariableMappingTabPage.Controls.Add(this.VariableMappingDataGridView);
            this.VariableMappingTabPage.Location = new System.Drawing.Point(4, 22);
            this.VariableMappingTabPage.Name = "VariableMappingTabPage";
            this.VariableMappingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VariableMappingTabPage.Size = new System.Drawing.Size(593, 312);
            this.VariableMappingTabPage.TabIndex = 2;
            this.VariableMappingTabPage.Text = "Variable Mapping";
            this.VariableMappingTabPage.UseVisualStyleBackColor = true;
            // 
            // VariableTextBox
            // 
            this.VariableTextBox.Location = new System.Drawing.Point(60, 33);
            this.VariableTextBox.Name = "VariableTextBox";
            this.VariableTextBox.Size = new System.Drawing.Size(261, 20);
            this.VariableTextBox.TabIndex = 4;
            // 
            // ObjectCountTextBox
            // 
            this.ObjectCountTextBox.Location = new System.Drawing.Point(215, 6);
            this.ObjectCountTextBox.Name = "ObjectCountTextBox";
            this.ObjectCountTextBox.Size = new System.Drawing.Size(106, 20);
            this.ObjectCountTextBox.TabIndex = 4;
            // 
            // ObjectTextBox
            // 
            this.ObjectTextBox.Location = new System.Drawing.Point(60, 6);
            this.ObjectTextBox.Name = "ObjectTextBox";
            this.ObjectTextBox.Size = new System.Drawing.Size(149, 20);
            this.ObjectTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Variable:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Object:";
            // 
            // VariableProgressBar
            // 
            this.VariableProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VariableProgressBar.Location = new System.Drawing.Point(327, 33);
            this.VariableProgressBar.Name = "VariableProgressBar";
            this.VariableProgressBar.Size = new System.Drawing.Size(260, 20);
            this.VariableProgressBar.TabIndex = 2;
            // 
            // ObjectProgressBar
            // 
            this.ObjectProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectProgressBar.Location = new System.Drawing.Point(327, 6);
            this.ObjectProgressBar.Name = "ObjectProgressBar";
            this.ObjectProgressBar.Size = new System.Drawing.Size(260, 20);
            this.ObjectProgressBar.TabIndex = 1;
            // 
            // VariableMappingDataGridView
            // 
            this.VariableMappingDataGridView.AllowUserToAddRows = false;
            this.VariableMappingDataGridView.AllowUserToDeleteRows = false;
            this.VariableMappingDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VariableMappingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VariableMappingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qvwColumn,
            this.varCountTotalColumn,
            this.varCountUsedColumn,
            this.varCountUsesColumn,
            this.varCountUnusedColumn});
            this.VariableMappingDataGridView.Location = new System.Drawing.Point(3, 59);
            this.VariableMappingDataGridView.Name = "VariableMappingDataGridView";
            this.VariableMappingDataGridView.ReadOnly = true;
            this.VariableMappingDataGridView.RowHeadersWidth = 20;
            this.VariableMappingDataGridView.Size = new System.Drawing.Size(587, 250);
            this.VariableMappingDataGridView.TabIndex = 0;
            // 
            // qvwColumn
            // 
            this.qvwColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qvwColumn.FillWeight = 60F;
            this.qvwColumn.HeaderText = "QVW Name";
            this.qvwColumn.Name = "qvwColumn";
            this.qvwColumn.ReadOnly = true;
            this.qvwColumn.Width = 89;
            // 
            // varCountTotalColumn
            // 
            this.varCountTotalColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.varCountTotalColumn.FillWeight = 10F;
            this.varCountTotalColumn.HeaderText = "# Variables";
            this.varCountTotalColumn.Name = "varCountTotalColumn";
            this.varCountTotalColumn.ReadOnly = true;
            this.varCountTotalColumn.Width = 85;
            // 
            // varCountUsedColumn
            // 
            this.varCountUsedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.varCountUsedColumn.FillWeight = 10F;
            this.varCountUsedColumn.HeaderText = "# Used";
            this.varCountUsedColumn.Name = "varCountUsedColumn";
            this.varCountUsedColumn.ReadOnly = true;
            this.varCountUsedColumn.Width = 67;
            // 
            // varCountUsesColumn
            // 
            this.varCountUsesColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.varCountUsesColumn.FillWeight = 10F;
            this.varCountUsesColumn.HeaderText = "# Uses";
            this.varCountUsesColumn.Name = "varCountUsesColumn";
            this.varCountUsesColumn.ReadOnly = true;
            this.varCountUsesColumn.Width = 66;
            // 
            // varCountUnusedColumn
            // 
            this.varCountUnusedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.varCountUnusedColumn.FillWeight = 10F;
            this.varCountUnusedColumn.HeaderText = "# UN-Used";
            this.varCountUnusedColumn.Name = "varCountUnusedColumn";
            this.varCountUnusedColumn.ReadOnly = true;
            this.varCountUnusedColumn.Width = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Select Operation(s) to perform\r\non the Target Project(s):";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(12, 87);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.OperationsTreeView);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(829, 338);
            this.splitContainer2.SplitterDistance = 224;
            this.splitContainer2.TabIndex = 16;
            // 
            // TargetProjectTextBox
            // 
            this.TargetProjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetProjectTextBox.Location = new System.Drawing.Point(132, 61);
            this.TargetProjectTextBox.Name = "TargetProjectTextBox";
            this.TargetProjectTextBox.Size = new System.Drawing.Size(678, 20);
            this.TargetProjectTextBox.TabIndex = 5;
            this.toolTip1.SetToolTip(this.TargetProjectTextBox, "Shows either the single QVW being updated or the path where multiple QVWs reside");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Target Project(s) Path:";
            // 
            // FindTargetProjectButton
            // 
            this.FindTargetProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindTargetProjectButton.Location = new System.Drawing.Point(816, 61);
            this.FindTargetProjectButton.Name = "FindTargetProjectButton";
            this.FindTargetProjectButton.Size = new System.Drawing.Size(25, 20);
            this.FindTargetProjectButton.TabIndex = 6;
            this.FindTargetProjectButton.Text = "...";
            this.toolTip1.SetToolTip(this.FindTargetProjectButton, "Click to choose the target QVWs");
            this.FindTargetProjectButton.UseVisualStyleBackColor = true;
            this.FindTargetProjectButton.Click += new System.EventHandler(this.FindTargetProjectButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Project Update Method:";
            // 
            // MultipleRadioButton
            // 
            this.MultipleRadioButton.AutoSize = true;
            this.MultipleRadioButton.Location = new System.Drawing.Point(228, 38);
            this.MultipleRadioButton.Name = "MultipleRadioButton";
            this.MultipleRadioButton.Size = new System.Drawing.Size(102, 17);
            this.MultipleRadioButton.TabIndex = 3;
            this.MultipleRadioButton.Text = "Multiple Projects";
            this.toolTip1.SetToolTip(this.MultipleRadioButton, "Select multiple QVWs to update");
            this.MultipleRadioButton.UseVisualStyleBackColor = true;
            // 
            // SingleRadioButton
            // 
            this.SingleRadioButton.AutoSize = true;
            this.SingleRadioButton.Checked = true;
            this.SingleRadioButton.Location = new System.Drawing.Point(132, 38);
            this.SingleRadioButton.Name = "SingleRadioButton";
            this.SingleRadioButton.Size = new System.Drawing.Size(90, 17);
            this.SingleRadioButton.TabIndex = 2;
            this.SingleRadioButton.TabStop = true;
            this.SingleRadioButton.Text = "Single Project";
            this.toolTip1.SetToolTip(this.SingleRadioButton, "Select single QVW to update.");
            this.SingleRadioButton.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 7500;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // AutomationCheckBox
            // 
            this.AutomationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AutomationCheckBox.AutoSize = true;
            this.AutomationCheckBox.Location = new System.Drawing.Point(665, 38);
            this.AutomationCheckBox.Name = "AutomationCheckBox";
            this.AutomationCheckBox.Size = new System.Drawing.Size(145, 17);
            this.AutomationCheckBox.TabIndex = 4;
            this.AutomationCheckBox.Text = "Use QlikView Automation";
            this.AutomationCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.AutomationCheckBox, "If you have QlikView 11 or higher installed,\r\nand you want to automatically popul" +
        "ate / refresh\r\nthe contents of the -prj folders associated with the \r\nTarget Pro" +
        "ject(s), then check this box.");
            this.AutomationCheckBox.UseVisualStyleBackColor = true;
            // 
            // InfoButton
            // 
            this.InfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoButton.Image = ((System.Drawing.Image)(resources.GetObject("InfoButton.Image")));
            this.InfoButton.Location = new System.Drawing.Point(-1, -3);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(20, 20);
            this.InfoButton.TabIndex = 17;
            this.toolTip1.SetToolTip(this.InfoButton, "About this Application");
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 437);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.AutomationCheckBox);
            this.Controls.Add(this.SingleRadioButton);
            this.Controls.Add(this.MultipleRadioButton);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.FindTargetProjectButton);
            this.Controls.Add(this.FindProjectButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TargetProjectTextBox);
            this.Controls.Add(this.SelectedProjectTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "QlikView Project Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.OperationsTabPage.ResumeLayout(false);
            this.OperationsTabPage.PerformLayout();
            this.WallpaperTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WallpaperPictureBox)).EndInit();
            this.VariableMappingTabPage.ResumeLayout(false);
            this.VariableMappingTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableMappingDataGridView)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox SelectedProjectTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button FindProjectButton;
        private System.Windows.Forms.TreeView OperationsTreeView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage OperationsTabPage;
        private System.Windows.Forms.Button PerformOperationButton;
        private System.Windows.Forms.TabPage WallpaperTabPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox UpdatedChartsTextBox;
        private System.Windows.Forms.TextBox TargetProjectTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button FindTargetProjectButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton MultipleRadioButton;
        private System.Windows.Forms.RadioButton SingleRadioButton;
        private System.Windows.Forms.Button LoadImageFromDiskButton;
        private System.Windows.Forms.PictureBox WallpaperPictureBox;
        private System.Windows.Forms.Button CopyImageButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox RefreshPrjCheckBox;
        private System.Windows.Forms.CheckBox AutomationCheckBox;
        private System.Windows.Forms.TabPage VariableMappingTabPage;
        private System.Windows.Forms.DataGridView VariableMappingDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn qvwColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varCountTotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varCountUsedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varCountUsesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varCountUnusedColumn;
        private System.Windows.Forms.TextBox VariableTextBox;
        private System.Windows.Forms.TextBox ObjectTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar VariableProgressBar;
        private System.Windows.Forms.ProgressBar ObjectProgressBar;
        private System.Windows.Forms.TextBox ObjectCountTextBox;
        private System.Windows.Forms.CheckBox IgnoreSystemVariablesCheckBox;
        private System.Windows.Forms.Button InfoButton;
    }
}

