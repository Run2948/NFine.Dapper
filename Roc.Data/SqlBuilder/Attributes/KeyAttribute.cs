using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roc.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : Attribute
    {
        public KeyAttribute(bool increment)
        {
            this.Increment = increment;
        }

        public KeyAttribute()
            : this(false)
        {

        }
        /// <summary>
        /// 是否是自增
        /// </summary>
        public bool Increment { get; set; }
    }
}
