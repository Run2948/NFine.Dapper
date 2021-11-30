/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/namespace Roc.ProjectUility
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtProjectPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdateCodeDescription = new System.Windows.Forms.Button();
            this.btnUpdateNameSpace = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grid = new System.Windows.Forms.DataGridView();
            this.ProjectPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssemblyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RootNamespace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewNameSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChooseToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // ChooseToolStripMenuItem
            // 
            this.ChooseToolStripMenuItem.Name = "ChooseToolStripMenuItem";
            this.ChooseToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ChooseToolStripMenuItem.Text = "选择项目目录";
            this.ChooseToolStripMenuItem.Click += new System.EventHandler(this.ChooseToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.txtProjectPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 51);
            this.panel1.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(500, 14);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "加载";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Location = new System.Drawing.Point(87, 16);
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(393, 21);
            this.txtProjectPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目目录:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdateCodeDescription);
            this.panel2.Controls.Add(this.btnUpdateNameSpace);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(761, 60);
            this.panel2.TabIndex = 2;
            // 
            // btnUpdateCodeDescription
            // 
            this.btnUpdateCodeDescription.Location = new System.Drawing.Point(442, 15);
            this.btnUpdateCodeDescription.Name = "btnUpdateCodeDescription";
            this.btnUpdateCodeDescription.Size = new System.Drawing.Size(105, 23);
            this.btnUpdateCodeDescription.TabIndex = 1;
            this.btnUpdateCodeDescription.Text = "修改代码描述";
            this.btnUpdateCodeDescription.UseVisualStyleBackColor = true;
            this.btnUpdateCodeDescription.Click += new System.EventHandler(this.btnUpdateCodeDescription_Click);
            // 
            // btnUpdateNameSpace
            // 
            this.btnUpdateNameSpace.Location = new System.Drawing.Point(597, 15);
            this.btnUpdateNameSpace.Name = "btnUpdateNameSpace";
            this.btnUpdateNameSpace.Size = new System.Drawing.Size(105, 23);
            this.btnUpdateNameSpace.TabIndex = 0;
            this.btnUpdateNameSpace.Text = "修改命名空间";
            this.btnUpdateNameSpace.UseVisualStyleBackColor = true;
            this.btnUpdateNameSpace.Click += new System.EventHandler(this.btnUpdateNameSpace_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(761, 260);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(753, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "子项目";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectPath,
            this.AssemblyName,
            this.RootNamespace,
            this.NewNameSpace});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 3);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 23;
            this.grid.Size = new System.Drawing.Size(747, 228);
            this.grid.TabIndex = 0;
            // 
            // ProjectPath
            // 
            this.ProjectPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ProjectPath.DataPropertyName = "ProjectPath";
            this.ProjectPath.HeaderText = "项目根目录";
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.Width = 88;
            // 
            // AssemblyName
            // 
            this.AssemblyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AssemblyName.DataPropertyName = "AssemblyName";
            this.AssemblyName.HeaderText = "程序集名称";
            this.AssemblyName.Name = "AssemblyName";
            this.AssemblyName.Width = 88;
            // 
            // RootNamespace
            // 
            this.RootNamespace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RootNamespace.DataPropertyName = "RootNamespace";
            this.RootNamespace.HeaderText = "命名空间";
            this.RootNamespace.Name = "RootNamespace";
            this.RootNamespace.Width = 76;
            // 
            // NewNameSpace
            // 
            this.NewNameSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NewNameSpace.DataPropertyName = "Namespace";
            this.NewNameSpace.HeaderText = "新命名空间";
            this.NewNameSpace.Name = "NewNameSpace";
            this.NewNameSpace.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NewNameSpace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NewNameSpace.Width = 69;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 396);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目辅助工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtProjectPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnUpdateNameSpace;
        private System.Windows.Forms.Button btnUpdateCodeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssemblyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RootNamespace;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewNameSpace;
    }
}