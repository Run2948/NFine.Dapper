/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Roc.ProjectUility.Model;
using Roc.ProjectUility.Helper;

namespace Roc.ProjectUility
{
    public partial class MainForm : Form
    {
        private ConfigEntity config;

        public MainForm()
        {
            InitializeComponent();
            this.Init();

//            string desc = @"
//            desc = desc.Trim();
//            //desc = desc.Replace("\r\n", "");
//            config.ProjectCodeDescription = desc;
//            MessageBox.Show(desc);
        }

        private void Init()
        {
            config = ProjectHelper.LoadConfig();
            this.txtProjectPath.Text = config.ProjectPath;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = this.txtProjectPath.Text;
            if (string.IsNullOrEmpty(path)) return;

            config.ProjectPath = path;
            BindGrid();
        }

        private void ChooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            var result = path.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                this.txtProjectPath.Text = path.SelectedPath;
            }
        }

        private void BindGrid()
        {
            string path = config.ProjectPath;
            string searchPattern = config.ProjectPattern;
            string[] fileNames = ProjectHelper.GetFileNames(path, searchPattern, true);
            if (fileNames == null || fileNames.Length < 1) return;

            List<ProjectEntity> projects = new List<ProjectEntity>();
            foreach (string name in fileNames)
            {
                ProjectEntity p = ProjectHelper.GetProjectEntity(name);
                projects.Add(p);
            }
            grid.DataSource = projects;
        }

        private void btnUpdateNameSpace_Click(object sender, EventArgs e)
        {
            int flag = 0;
            var rows = grid.Rows;
            if (rows != null && rows.Count > 0)
            {
                foreach (DataGridViewRow row in rows)
                {
                    ProjectEntity p = (ProjectEntity)row.DataBoundItem;
                    if (p != null && !string.IsNullOrEmpty(p.Namespace))
                    {
                        flag++;
                        ProjectHelper.UpdateProjectNamespace(config.ProjectPath, p, new string[] { config.ProjectPattern, config.NamespacePattern });
                    }
                }
            }
            if (flag > 0)
            {
                MessageBox.Show("修改命名空间成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("请填写新的命名空间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateCodeDescription_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = grid.Rows;
                if (rows == null || rows.Count < 1)
                {
                    MessageBox.Show("请先加载子项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ProjectHelper.UpdateProjectCodeDescription(true, config, new string[] { config.NamespacePattern });
                MessageBox.Show("修改代码描述成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改代码描述失败--" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
