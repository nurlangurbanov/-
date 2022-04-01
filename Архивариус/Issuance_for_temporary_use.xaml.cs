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
    /// Логика взаимодействия для Issuance_for_temporary_use.xaml
    /// </summary>
    public partial class Issuance_for_temporary_use : Window
    {
        public Issuance_for_temporary_use()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            dtIssuance.ItemsSource = Helper.GetContext().Issuance.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var Issuance = dtIssuance.SelectedItems.Cast<Issuance>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {Issuance.Count()} элементов ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Helper.GetContext().Issuance.RemoveRange(Issuance);
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Collapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}