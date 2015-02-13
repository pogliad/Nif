using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using Excel;
using Nif.Core.Extensions;

namespace Nif.Converters.ExcelConverter
{
    public enum ExcelFileFormat
    {
        [Description("97-2003 format; *.xls")]
        Xsl,
        [Description("2007 format; *.xlsx")]
        Xslx
    }

    public static class ExcelConverter
    {
        public static string ExcelToCsv(byte[] data, ExcelFileFormat fileFormat, int activeSheetNumber = 0)
        {
            Contract.Requires<ArgumentNullException>(data.IsNotNull());
            Contract.Requires<ArgumentOutOfRangeException>(activeSheetNumber >= 0);

            var stream = new MemoryStream(data);
            IExcelDataReader reader = null;

            switch (fileFormat)
            {
                case ExcelFileFormat.Xsl: reader = ExcelReaderFactory.CreateBinaryReader(stream); break;
                case ExcelFileFormat.Xslx: reader = ExcelReaderFactory.CreateOpenXmlReader(stream); break;
            }

            if (reader.IsNull())
            {
                throw new NullReferenceException("reader");
            }

            var ds = reader.AsDataSet();
            var csvData = new StringBuilder();
            var rowIndex = 0;

            while (rowIndex < ds.Tables[activeSheetNumber].Rows.Count)
            {
                for (var columnIndex = 0; columnIndex < ds.Tables[activeSheetNumber].Columns.Count; columnIndex++)
                {
                    csvData.Append(ds.Tables[activeSheetNumber].Rows[rowIndex][columnIndex] + ",");
                }

                rowIndex++;
                csvData.AppendLine();
            }

            return csvData.ToString();
        }
    }
}