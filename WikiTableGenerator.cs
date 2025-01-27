using System.Data;
using System.Text;

namespace Excel2Wiki
{
    public class WikiTableGenerator
    {
        public string GenerateWikiTable(DataGridView gridView, bool isSortable, bool firstRowIsHeader, string caption)
        {
            var wikiTable = new StringBuilder();

            // Inizia la tabella
            wikiTable.AppendLine(isSortable ? "{| class=\"wikitable sortable\"" : "{| class=\"wikitable\"");

            // Aggiungi caption
            if (!string.IsNullOrWhiteSpace(caption))
            {
                wikiTable.AppendLine($"|+ {caption}");
            }

            // Se la prima riga è un'intestazione
            if (firstRowIsHeader && gridView.Rows.Count > 0)
            {
                AppendRowToWikiTable(wikiTable, gridView.Rows[0], true);
            }

            // Aggiungi le righe di dati
            for (int i = firstRowIsHeader ? 1 : 0; i < gridView.Rows.Count; i++)
            {
                if (!gridView.AllowUserToAddRows || i < gridView.Rows.Count - 1)
                {
                    AppendRowToWikiTable(wikiTable, gridView.Rows[i], false);
                }
            }

            // Chiudi la tabella
            wikiTable.AppendLine("|}");
            return wikiTable.ToString();
        }

        private void AppendRowToWikiTable(StringBuilder wikiTable, DataGridViewRow row, bool isHeader)
        {
            wikiTable.AppendLine("|-");

            foreach (DataGridViewCell cell in row.Cells)
            {
                string cellValue = cell.Value?.ToString() ?? string.Empty;
                wikiTable.AppendLine(isHeader ? $"! {cellValue}" : $"| {cellValue}");
            }
        }

    }

}
