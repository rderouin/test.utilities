using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System.ComponentModel;


namespace UBC.MedIT.Web.Testing.Utlities
{
    [DisplayName("Table Column Value")]
    [Description("Validates that a value exists in a column in an HTML table.")]
    public class TableColumnValueValidator : ValidationRule
    {
        [DisplayName("Table ID")]
        [Description("Id attribute value for the table.")]
        public string TableId { get; set; }

        [DisplayName("Column Name")]
        [Description("Name of th ecolumn that should ahve the value.")]
        public string ColumnName { get; set; }

        [DisplayName("Expected Value")]
        [Description("Expected value that should be in the table cell")]
        public string ExpectedValue { get; set; }
        
        public override void Validate(object sender, ValidationEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TableId) == true)
            {
                Fail(e, "Table Id does not have a valid value!");
            }
            else if (String.IsNullOrWhiteSpace(ColumnName) == true)
            {
                Fail(e, "Column Name does not have a valid value!");
            }
            else if (ExpectedValue == null)
            {
                Fail(e, "Expected value cannot be null");
            }
            else
            {
                ValidateTable(e);
            }

        }

        private void Fail(ValidationEventArgs e, string p)
        {
            throw new NotImplementedException();
        }

        private void ValidateTable(ValidationEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
