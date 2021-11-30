/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Linq;
using Microsoft.Build.Evaluation;

using Roc.ProjectUility.Model;

namespace Roc.ProjectUility.Helper
{
    public class ProjectHelper
    {
        public static ConfigEntity LoadConfig()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = string.Format(@"{0}\config\config.xml", baseDirectory);

            ConfigEntity config = new ConfigEntity();
            try
            {
                XDocument doc = XDocument.Load(filePath);
                var settings = doc.Element("settings");
                config.ProjectPattern = settings.Element("projectPattern").Value;
                config.ProjectPath = settings.Element("projectPath").Value;
                config.NamespacePattern = settings.Element("projectNamespacePattern").Value;
                config.OldProjectCodeDescriptionPattern = settings.Element("oldProjectCodeDescriptionPattern").Value;
                config.ProjectCodeDescription = settings.Element("projectCodeDescription").Value;
            }
            catch { }
            return config;
        }

        public static ProjectEntity GetProjectEntity(string path)
        {
            ProjectCollection pc = new ProjectCollection();
            var project = pc.LoadProject(path);
            ProjectEntity p = new ProjectEntity();
            p.AssemblyName = project.GetPropertyValue("AssemblyName");
            p.RootNamespace = project.GetPropertyValue("RootNamespace");
            p.ProjectPath = Path.GetDirectoryName(path);
            return p;
        }

        public static void UpdateConfig()
        {

        }

        public static void UpdateProjectNamespace(string projectPath, ProjectEntity p, IEnumerable<string> ps)
        {
            UpdateProjectCode(true, projectPath, p.RootNamespace, p.Namespace, ps, (reg, input) =>
            {
                return input = reg.Replace(input, p.Namespace);
            });
        }

        public static void UpdateProjectCodeDescription(bool flag, ConfigEntity config, IEnumerable<string> ps)
        {
            string replacement = flag ? config.ProjectCodeDescription : "";
            replacement = replacement.Trim();
            UpdateProjectCode(false, config.ProjectPath, config.OldProjectCodeDescriptionPattern, replacement, ps, (reg, input) =>
            {
                bool match = reg.IsMatch(input);
                if (match) input =reg.Replace(input, replacement);
                else input = replacement + input;
                return input;
            }, RegexOptions.None);
        }

        public static void UpdateProjectCode(bool updateFileNmae, string projectPath, string regPattern, string replacement, IEnumerable<string> ps, Func<Regex, string, string> func, RegexOptions options = RegexOptions.Multiline)
        {
            List<string> names = new List<string>();
            foreach (var pattern in ps)
            {
                string[] fileNames = GetFileNames(projectPath, pattern, true);
                if (fileNames == null || fileNames.Length < 1) return;
                names.AddRange(fileNames);
            }

            Regex reg = new Regex(regPattern, options);
            foreach (var name in names)
            {
                try
                {
                    string path = name;
                    //string n = Path.GetFileNameWithoutExtension(path);
                    //if (updateFileNmae && n == regPattern)
                    //{
                    //    string destPath = string.Format(@"{0}\{1}{2}", Path.GetDirectoryName(path), replacement, Path.GetExtension(path));
                    //    File.Move(path, destPath);
                    //    path = destPath;
                    //}
                    string input = string.Empty;
                    using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                    {
                        input = sr.ReadToEnd();
                    }
                    input = func(reg, input);
                    using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                    {
                        sw.Write(input);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        public static string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
        {
            //如果目录不存在，则抛出异常
            if (!Directory.Exists(directoryPath))
            {
                throw new FileNotFoundException();
            }

            try
            {
                if (isSearchChild)
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                else
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
    }
}
