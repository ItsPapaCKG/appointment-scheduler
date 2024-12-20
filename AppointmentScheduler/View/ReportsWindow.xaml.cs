﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppointmentScheduler.View
{
    /// <summary>
    /// Interaction logic for ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // Customize or manipulate the columns as they are generated
            var columnName = e.Column.Header.ToString();

            // Optionally modify column properties
            e.Column.Header = columnName; // Keep the column name as-is for dynamic properties

            Debug.WriteLine($"ColumnHeader = columnName");

        }

        public void SetReportHeader(string s)
        {
            ReportHeader.Content = s;
        }

        public void GenColumns()
        {
            var rows = dataGrid1.ItemsSource.OfType<IDictionary<string, object>>();
            var columns = rows.SelectMany(d => d.Keys).Distinct(StringComparer.OrdinalIgnoreCase);

            foreach (string text in columns)
            {
                // now set up a column and binding for each property
                var column = new DataGridTextColumn
                {
                    Header = text,
                    Binding = new Binding(text)
                };

                dataGrid1.Columns.Add(column);
            }
        }
    }
}
