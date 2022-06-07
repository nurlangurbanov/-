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
    /// Логика взаимодействия для Create_category.xaml
    /// </summary>
    public partial class Create_category : Window
    {
        public Create_category()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Name_category.Text == "")
            {
                MessageBox.Show("Пустые значения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Category cg = new Category
                    {
                        Category1 = Name_category.Text,
                    };
                    Helper.GetContext().Category.Add(cg);
                    Helper.GetContext().SaveChanges();
                    MessageBox.Show("Документ успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    Name_category.Text = "";
                }
                catch
                {
                    MessageBox.Show("Ошибка при создании", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
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
