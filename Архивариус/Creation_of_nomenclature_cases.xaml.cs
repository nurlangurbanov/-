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
            dtArchive.ItemsSource = Helper.GetContext().Archive_work.ToList();
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            Compiling_a_nomenclature_of_cases cc = new Compiling_a_nomenclature_of_cases();
            cc.ShowDialog();
            this.Show();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            DataRowView red = (DataRowView)dtArchive.SelectedItems[0];
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            //int id = Convert.ToInt32(iduser.Text);
            //if (id != 0)
            //{
            //    var idduser = Helper.GetContext().Users.Where(x => x.ID_User == id).FirstOrDefault();
            //    idduser.ID_Status = 2;
            //    Helper.GetContext().SaveChanges();
            //    MessageBox.Show("Пользователь успешно удален!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

            DataRowView red = (DataRowView)dtArchive.SelectedItems[0];
            int id = Convert.ToInt32(red);
            var idduser = Helper.GetContext().Archive_work.Where(x => x.ID_Archive == id).FirstOrDefault();
            //idduser.ID_Status = 2;
            Helper.GetContext().SaveChanges();
            MessageBox.Show("Пользователь успешно удален!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}