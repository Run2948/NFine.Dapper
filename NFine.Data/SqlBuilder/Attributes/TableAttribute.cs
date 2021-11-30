using System;

namespace NFine.Data
{
    /// <summary>
    /// Configures the name of the db table related to this entity. If the attribute is not specified, the class name is used instead.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
