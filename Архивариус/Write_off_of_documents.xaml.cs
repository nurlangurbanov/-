using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using Word = Microsoft.Office.Interop.Word;


namespace Архивариус
{
    /// <summary>
    /// Логика взаимодействия для Write_off_of_documents.xaml
    /// </summary>
    public partial class Write_off_of_documents : Window
    {
        public Write_off_of_documents()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            dtArchive.ItemsSource = Helper.GetContext().Archive_work.Where(x => x.Signature_documents_ID == 2).ToList();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            Archive_work worker = (Archive_work)dtArchive.SelectedItem;
            worker.Signature_documents_ID = 1;
            Helper.GetContext().SaveChanges();
            Load();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Collapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Word_Click(object sender, RoutedEventArgs e)
        {
            var helper = new Word_Helper("Act.doc");

            var items = new Dictionary<string, string>
            {
                {"<TitleW>", Convert.ToString(dtArchive.Columns[1])},

                {"<ArticleW>", Convert.ToString(dtArchive.Columns[2])},

                {"<CountW>", Convert.ToString(dtArchive.Columns[4])}
            };

            helper.Process(items);

            //if (dtArchive.Items.Count != 0)
            //{
            //    int RowCount = dtArchive.Items.Count;
            //    int ColumnCount = dtArchive.Columns.Count;
            //    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

            //    //Добавление строк и ячеек
            //    int r = 0;
            //    for (int c = 0; c <= ColumnCount - 1; c++)
            //    {
            //        for (r = 0; r <= RowCount - 1; r++)
            //        {
            //            DataArray[r, c] = dtArchive.Columns[c];
            //        }
            //    }

            //    Word.Document oDoc = new Word.Document();
            //    oDoc.Application.Visible = true;

            //    //Ориентация листа
            //    oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


            //    dynamic oRange = oDoc.Content.Application.Selection.Range;
            //    string oTemp = "";
            //    for (r = 0; r <= RowCount - 1; r++)
            //    {
            //        for (int c = 0; c <= ColumnCount - 1; c++)
            //        {
            //            oTemp = oTemp + DataArray[r, c] + "\t";
            //        }
            //    }

            //    oRange.Text = oTemp;

            //    //Формат таблицы
            //    oRange.Text = oTemp;
            //    object oMissing = Missing.Value;
            //    object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
            //    object ApplyBorders = true;
            //    object AutoFit = true;
            //    object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;



            //    oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
            //                      Type.Missing, Type.Missing, ref ApplyBorders,
            //                      Type.Missing, Type.Missing, Type.Missing,
            //                      Type.Missing, Type.Missing, Type.Missing,
            //                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

            //    oRange.Select();

            //    oDoc.Application.Selection.Tables[1].Select();
            //    oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
            //    oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
            //    oDoc.Application.Selection.Tables[1].Rows[1].Select();
            //    oDoc.Application.Selection.InsertRowsAbove(1);
            //    oDoc.Application.Selection.Tables[1].Rows[1].Select();

            //    //Стиль заголовка таблицы
            //    oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 2;
            //    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
            //    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

            //    //add header row manually
            //    for (int c = 0; c <= ColumnCount - 1; c++)
            //    {
            //        oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dtArchive.Columns[c].ToString();
            //    }

            //    //Стили таблицы
            //    oDoc.Application.Selection.Tables[1].Rows[1].Select();
            //    oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            //    oDoc.Application.Selection.Tables[1].Borders.Enable = 1;

            //    //Текст шапки
            //    foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
            //    {
            //        Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            //        headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
            //        headerRange.Text = "Заявка на закупку картриджа";
            //        headerRange.Font.Size = 16;
            //        headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //    }

            //    //Сохранение файла

            //    oDoc.SaveAs("Act.doc", ref oMissing, ref oMissing, ref oMissing,
            //ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            //ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            //ref oMissing, ref oMissing);
            //}
        }
    }
}