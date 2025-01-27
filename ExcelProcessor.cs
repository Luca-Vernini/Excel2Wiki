using System;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace Excel2Wiki
{
    public class ExcelProcessor
    {
        public DataTable ImportFile(string filePath, bool skipEmptyRows)
        {
            IWorkbook workbook;
            ISheet sheet;

            using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                if (filePath.EndsWith(".xlsx"))
                {
                    workbook = new XSSFWorkbook(fileStream);
                }
                else if (filePath.EndsWith(".xls"))
                {
                    workbook = new HSSFWorkbook(fileStream);
                }
                else
                {
                    throw new Exception("Unsupported file type");
                }

                sheet = workbook.GetSheetAt(0);
            }

            var dataTable = new DataTable();

            // Leggi l'intestazione
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int i = 0; i < cellCount; i++)
            {
                dataTable.Columns.Add($"Column {i + 1}");
            }

            // Leggi le righe
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (skipEmptyRows && IsRowEmpty(row))
                    continue;

                var dataRow = dataTable.NewRow();
                for (int j = 0; j < cellCount; j++)
                {
                    dataRow[j] = row?.GetCell(j)?.ToString() ?? string.Empty;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        private bool IsRowEmpty(IRow row)
        {
            if (row == null) return true;
            foreach (ICell cell in row)
            {
                if (cell != null && !string.IsNullOrWhiteSpace(cell.ToString()))
                    return false;
            }
            return true;
        }
    }

}
