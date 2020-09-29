using System;
using System.Data;

namespace ReportingModule.ViewModels.Search
{
    public static class SearchResultExtension
    {
        public static DataTable ToDataTable<T>(this SearchResult<T> searchResult,
            (string columnName, Type type, string propertyName)[] mapping)
        {
            var dt = new DataTable();

            foreach (var map in mapping)
            {
                dt.Columns.Add(new DataColumn(map.columnName, map.type));
            }

            foreach (var viewModel in searchResult.Items)
            {
                var row = dt.NewRow();
                PopulateDataRow(row, viewModel, mapping);
                dt.Rows.Add(row);
            }

            return dt;
        }

        private static void PopulateDataRow<T>(DataRow dataRow, T viewModel, (string columnName, Type type, string propertyName)[] mapping)
        {
            foreach (var map in mapping)
            {
                dataRow[map.columnName] = GetPropertyValue(viewModel, map.propertyName);
            }
        }

        private static string GetPropertyValue<T>(T viewModel, string propertyName)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);

            if (propertyInfo != null)
                return propertyInfo.GetValue(viewModel)?.ToString();

            return null;
        }
    }
}