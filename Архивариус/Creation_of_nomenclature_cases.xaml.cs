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
            dtArchive.ItemsSource = Helper.GetContext().Archive_work.Where(x => x.Signature_documents_ID == 1).ToList();
            Category_Combo.ItemsSource = Helper.GetContext().Category.ToList();
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            Compiling_a_nomenclature_of_cases cc = new Compiling_a_nomenclature_of_cases();
            cc.ShowDialog();
            this.Show();
            Load();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы будете изменять скан ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                Archive_work worker = (Archive_work)dtArchive.SelectedItem;
                if (worker == null)
                {
                    MessageBox.Show("Не выбран документ!");
                }
                else
                    try
                    {
                        Compiling_a_nomenclature_of_cases cc = new Compiling_a_nomenclature_of_cases();
                        cc.Text.Visibility = Visibility.Hidden;
                        cc.ImageCheck.Visibility = Visibility.Hidden;
                        cc.Text_InsertImage.Visibility = Visibility.Hidden;
                        var ID_Image = Helper.GetContext().Archive_work.FirstOrDefault(x => x.Images_ID == worker.Images_ID); 
                        cc.Index.Text = Convert.ToString(worker.Сase_index);
                        cc.Start.SelectedDate = worker.YearCreate;
                        cc.Finish.SelectedDate = worker.YearFinish;
                        cc.Title.Text = worker.Title;
                        cc.Note.Text = worker.Note;
                        cc.Number.Text = Convert.ToString(worker.Number_of_cases);
                        cc.Storage_articleCombo.SelectedItem = worker.Storage_article;
                        cc.Category_Combo.SelectedItem = worker.Category;
                        cc.ShowDialog();
                        Load();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!");
                    }
            }
            else
            {
                Archive_work worker = (Archive_work)dtArchive.SelectedItem;
                if (worker == null)
                {
                    MessageBox.Show("Не выбран документ!");
                }
                else
                    try
                    {
                        Compiling_a_nomenclature_of_cases cc = new Compiling_a_nomenclature_of_cases();
                        cc.Text.Visibility = Visibility.Hidden;
                        cc.ImageCheck.Visibility = Visibility.Hidden;
                        cc.Text_InsertImage.Visibility = Visibility.Hidden;
                        cc.Button_InsertImage.Visibility = Visibility;   
                        var ID_Image = Helper.GetContext().Archive_work.FirstOrDefault(x => x.Images_ID == worker.Images_ID);
                        cc.Index.Text = Convert.ToString(worker.Сase_index);
                        cc.Start.SelectedDate = worker.YearCreate;
                        cc.Finish.SelectedDate = worker.YearFinish;
                        cc.Title.Text = worker.Title;
                        cc.Note.Text = worker.Note;
                        cc.Number.Text = Convert.ToString(worker.Number_of_cases);
                        cc.Storage_articleCombo.SelectedItem = worker.Storage_article;
                        cc.Category_Combo.SelectedItem = worker.Category;
                        cc.ShowDialog();
                        Load();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!");
                    }
            }
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
                catch
                {
                    MessageBox.Show("Документ выдан на временное пользование!");
                }
            }
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                dtArchive.Measure(pageSize);
                dtArchive.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dtArchive, Title);
            }
        }

        private void Extradition_Click(object sender, RoutedEventArgs e)
        {
            Adding_a_checkout Aac = new Adding_a_checkout();
            if (Aac.Archive_IDtxt.Text == null)
            {
                MessageBox.Show("Не выбран документ!");
            }
            else
            {
                Archive_work worker = (Archive_work)dtArchive.SelectedItem;
                Aac.Archive_IDtxt.Text = Convert.ToString(worker.ID_Archive);
                Aac.Start.SelectedDate = worker.YearCreate;
                Aac.Finish.SelectedDate = worker.YearFinish;
                Aac.Title.Text = worker.Title;
                Aac.Number.Text = Convert.ToString(worker.Number_of_cases);
                Aac.ShowDialog();
                Helper.GetContext().SaveChanges();
                Load();
            }
        }

        private void Signature(object sender, RoutedEventArgs e)
        {
            Archive_work worker = (Archive_work)dtArchive.SelectedItem;
            if (worker == null)
            {
                MessageBox.Show("Не выбран документ!");
            }
            else
            {
                worker.Signature_documents_ID = 2;
                Helper.GetContext().SaveChanges();
                Load();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IndexS.Text != "")
                {
                    int index = Convert.ToInt32(IndexS.Text);
                    dtArchive.ItemsSource = Helper.GetContext().Archive_work.Where(x => x.Сase_index == index).ToList();
                }
                if (TitleS.Text != "")
                {
                    dtArchive.ItemsSource = Helper.GetContext().Archive_work.Where(x => x.Title == TitleS.Text).ToList();
                }
                if (ArticleS.Text != "")
                {
                    dtArchive.ItemsSource = Helper.GetContext().Storage_article.Where(x => x.Storage_article1 == ArticleS.Text).ToList();
                }
                if (StartS.Text != "")
                {
                    dtArchive.ItemsSource = Helper.GetContext().Archive_work.Where(x => x.YearCreate == Convert.ToDateTime(StartS.SelectedDate)).ToList();
                }
                if (FinishS.Text != "")
                {
                    dtArchive.ItemsSource = Helper.GetContext().Archive_work.Where(x => x.YearFinish == Convert.ToDateTime(FinishS.SelectedDate)).ToList();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при поиске", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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

        private void Category_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var ID_Category = Convert.ToInt32(Helper.GetContext().Category.FirstOrDefault(x => x.Category1 == Category_Combo.Text));

            //dtArchive.ItemsSource = Helper.GetContext().Archive_work.Where(x => x.Category_ID == ID_Category).ToList();
        }
    }
}