using System;
using System.Collections.Generic;
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

namespace Архивариус
{
    /// <summary>
    /// Логика взаимодействия для Compiling_a_nomenclature_of_cases.xaml
    /// </summary>
    public partial class Compiling_a_nomenclature_of_cases : Window
    {
        private Archive_work _currentArchive = new Archive_work();

        public Compiling_a_nomenclature_of_cases()
        {
            InitializeComponent();

            //if (selectedArchive != null)
            //    _currentArchive = selectedArchive;

            Storage_articleCombo.ItemsSource = Helper.GetContext().Storage_article.ToList();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Index.Text == "" || Title.Text == "" || Note.Text == "" || Number.Text == "" || Start == null || Finish == null || Storage_articleCombo == null)
            {
                MessageBox.Show("Пустые значения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var ID_Storage_article = Helper.GetContext().Storage_article.FirstOrDefault(x => x.Storage_article1 == Storage_articleCombo.Text);
                Archive_work aw = new Archive_work
                {
                    Сase_index = Convert.ToInt32(Index.Text),
                    YearCreate = Convert.ToDateTime(Start.SelectedDate),
                    YearFinish = Convert.ToDateTime(Finish.SelectedDate),
                    Title = Title.Text,
                    Note = Note.Text,
                    Number_of_cases = Convert.ToInt32(Number.Text),
                    Storage_article_ID = ID_Storage_article.ID_Storage_article,
                };
                Helper.GetContext().Archive_work.Add(aw);
                Helper.GetContext().SaveChanges();
                MessageBox.Show("Документ успешно сохранен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Start.SelectedDate = null;
                Finish.SelectedDate = null;
                Index.Text = "";
                Title.Text = "";
                Note.Text = "";
                Number.Text = "";
                Storage_articleCombo.Text = "";
            }
        }

        private void Insert_article(object sender, RoutedEventArgs e)
        {
            Creation_article ca = new Creation_article();
            ca.ShowDialog();
            this.Show();
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
    }
}