/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roc.ProjectUility.Model
{
    public class ConfigEntity
    {
        public string ProjectPath { get; set; }

        public string ProjectPattern { get; set; }

        public string NamespacePattern { get; set; }

        public string ProjectCodeDescription { get; set; }

        public string OldProjectCodeDescriptionPattern { get; set; }
    }
}
