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
    /// Логика взаимодействия для Main_Window.xaml
    /// </summary>
    public partial class Main_Window : Window
    {
        public Main_Window()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                //tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                //tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                //tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                //tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Creation_of_nomenclature_cases_Click(object sender, RoutedEventArgs e)
        {
            Creation_of_nomenclature_cases CNC = new Creation_of_nomenclature_cases();
            CNC.ShowDialog();
            this.Show();
        }

        private void Electronic_document_work_Click(object sender, RoutedEventArgs e)
        {
            Electronic_document_work CNC = new Electronic_document_work();
            CNC.ShowDialog();
            this.Show();
        }

        private void Issuance_for_temporary_use_Click(object sender, RoutedEventArgs e)
        {
            Issuance_for_temporary_use CNC = new Issuance_for_temporary_use();
            CNC.ShowDialog();
            this.Show();
        }

        private void Write_off_of_documents_Click(object sender, RoutedEventArgs e)
        {
            Write_off_of_documents CNC = new Write_off_of_documents();
            CNC.ShowDialog();
            this.Show();
        }

        private void Creation_article_Click(object sender, RoutedEventArgs e)
        {
            Creation_article CNC = new Creation_article();
            CNC.ShowDialog();
            this.Show();
        }
    }
}
