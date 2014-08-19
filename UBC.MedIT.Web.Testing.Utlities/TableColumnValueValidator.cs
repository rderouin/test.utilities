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

        private void Fail(ValidationEventArgs e, string message)
        {
            e.IsValid = false;
            e.Message = message;
        }

        private void Pass(ValidationEventArgs e, string message)
        {
            e.IsValid = true;
            e.Message = message;
        }

        private void ValidateTable(ValidationEventArgs e)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(e.Response.BodyString);

            var table = doc.GetElementbyId(TableId);

            if (table == null)
            {
                Fail(e, String.Format("Could not locate a table tag named '{0}'!", TableId));
            }
            else if (table.Name != "table")
            {
                Fail(e, String.Format("Found a tag named '{0}' but it wasn't a table!", TableId));
            }
            else
            {
                ValidateTable(e, table);
            }
        }

        private void ValidateTable(ValidationEventArgs e, HtmlAgilityPack.HtmlNode table)
        {
            var columns = table.SelectNodes("//th");

            if (columns == null || columns.Count == 0)
            {
                Fail(e, "Could not locate any columns in the table!");
            }
            else
            {
                int columnIndex = FindColumnIndexByName(columns, ColumnName);

                if (columnIndex == -1)
                {
                    Fail(e, String.Format("Could not find a column named '{0}'!", ColumnName));
                }
                else
                {
                    bool foundTheValue = DoesValueExistInColumn(table, columnIndex, ExpectedValue);

                    if (foundTheValue == true)
                    {
                        Pass(e, "Found the column value!");
                    }
                    else
                    {
                        Fail(e, String.Format("Could not find a cell with the value '{0}'", ExpectedValue));
                    }
                }
            }
        }

        private bool DoesValueExistInColumn(HtmlAgilityPack.HtmlNode table, int columnIndex, string ExpectedValue)
        {
            throw new NotImplementedException();
        }

        private int FindColumnIndexByName(HtmlAgilityPack.HtmlNodeCollection columns, string ColumnName)
        {
            throw new NotImplementedException();
        }

    }
}
