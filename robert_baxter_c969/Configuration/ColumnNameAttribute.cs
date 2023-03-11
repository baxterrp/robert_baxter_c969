using System;

namespace robert_baxter_c969.Configuration
{
    public class ColumnNameAttribute : Attribute
    {
        public string Column { get; set; }

        public ColumnNameAttribute(string column)
        {
            Column = column;
        }
    }
}
