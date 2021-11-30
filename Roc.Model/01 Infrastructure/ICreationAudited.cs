/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System;

namespace Roc.Model
{
    public interface ICreationAudited
    {
        string F_Id { get; set; }
        string F_CreatorUserId { get; set; }
        DateTime? F_CreatorTime { get; set; }
    }
}