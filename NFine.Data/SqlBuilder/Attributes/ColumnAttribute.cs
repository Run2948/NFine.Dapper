using System;

namespace NFine.Data
{
    /// <summary>
    /// Configures the name of the column related to this property. If the attribute is not specified, the property name is used instead.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
