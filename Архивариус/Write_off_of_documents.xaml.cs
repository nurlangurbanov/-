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
    }
}
