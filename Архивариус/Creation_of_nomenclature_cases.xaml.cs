using System;
using System.Collections.Generic;
using System.Data;
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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Архивариус
{
    /// <summary>
    /// Логика взаимодействия для Creation_of_nomenclature_cases.xaml
    /// </summary>
    public partial class Creation_of_nomenclature_cases : Window
    {
        public Creation_of_nomenclature_cases()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            dtArchive.ItemsSource = Helper.GetContext().Archive_work.ToList();
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            Compiling_a_nomenclature_of_cases cc = new Compiling_a_nomenclature_of_cases((sender as Button).DataContext as Archive_work);
            cc.ShowDialog();
            this.Show();
            Load();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            //var Archive = dtArchive.SelectedItems.Cast<Archive_work>().ToList();
            //Compiling_a_nomenclature_of_cases cc = new Compiling_a_nomenclature_of_cases((sender as Button).DataContext as Archive_work);
            //cc.Show();
            
            Load();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var Archive = dtArchive.SelectedItems.Cast<Archive_work>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {Archive.Count()} элементов ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Helper.GetContext().Archive_work.RemoveRange(Archive);
                    Helper.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            Load();
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                dtArchive.Measure(pageSize);
                dtArchive.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dtArchive, Title);
            }
        }

        private void Excel_export(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();

            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < dtArchive.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = dtArchive.Columns[j].Header;
            }
            for (int i = 0; i < dtArchive.Columns.Count; i++)
            {
                for (int j = 0; j < dtArchive.Items.Count; j++)
                {
                    TextBlock b = dtArchive.Columns[i].GetCellContent(dtArchive.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
            excel.Visible = true;
        }

        private void Word_export(object sender, RoutedEventArgs e)
        {

        }
    }
}