/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application
{
    public enum DbLogType
    {
        [Description("其他")]
        Other = 0,
        [Description("登录")]
        Login = 1,
        [Description("退出")]
        Exit = 2,
        [Description("访问")]
        Visit = 3,
        [Description("新增")]
        Create = 4,
        [Description("删除")]
        Delete = 5,
        [Description("修改")]
        Update = 6,
        [Description("提交")]
        Submit = 7,
        [Description("异常")]
        Exception = 8,
    }
}
