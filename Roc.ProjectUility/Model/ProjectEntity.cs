/*******************************************************************************
    * Copyright 2016 Roc.Framework 版权所有
    * Author: Roc Ching
    * Description: Roc 快速开发平台
    * Date：2016-09-12
    *********************************************************************************/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roc.ProjectUility.Model
{
    public class ProjectEntity
    {
        public string ProjectPath { get; set; }

        public string AssemblyName { get; set; }

        public string RootNamespace { get; set; }

        public string Namespace { get; set; }
    }
}
