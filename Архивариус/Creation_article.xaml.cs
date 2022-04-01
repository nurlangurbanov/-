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
    /// Логика взаимодействия для Creation_article.xaml
    /// </summary>
    public partial class Creation_article : Window
    {
        public Creation_article()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Storage_articletxt.Text == "" || Shelf_life_by_articletxt.Text == "" || Note_on_storage_articletxt.Text == "")
            {
                MessageBox.Show("Пустые значения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Storage_article sa = new Storage_article
                {
                    Storage_article1 = Storage_articletxt.Text,
                    Shelf_life_by_article = Shelf_life_by_articletxt.Text,
                    Note_on_storage_article = Note_on_storage_articletxt.Text
                };
                Helper.GetContext().Storage_article.Add(sa);
                Helper.GetContext().SaveChanges();
                MessageBox.Show("Документ успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Storage_articletxt.Text = "";
                Shelf_life_by_articletxt.Text = "";
                Note_on_storage_articletxt.Text = "";
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
    }
}
