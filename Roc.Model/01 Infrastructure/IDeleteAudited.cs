/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System;

namespace Roc.Model
{
    public interface IDeleteAudited 
    {
        /// <summary>
        /// 逻辑删除标记
        /// </summary>
        bool? F_DeleteMark { get; set; }

        /// <summary>
        /// 删除实体的用户
        /// </summary>
        string F_DeleteUserId { get; set; }

        /// <summary>
        /// 删除实体时间
        /// </summary>
        DateTime? F_DeleteTime { get; set; } 
    }
}