using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ImagesArchive_insert.xaml
    /// </summary>
    public partial class ImagesArchive_insert : Window
    {
        string imageLoc = "";
        string shortFileName = "";
        byte[] archive_photobyte = null;
        public ImagesArchive_insert()
        {
            InitializeComponent();
        }

        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dld = new OpenFileDialog();
                //dld.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg";
                dld.Title = "Выберите фотографию пользователя";
                bool? result = dld.ShowDialog();
                if (result == true)
                {
                    shortFileName = dld.FileName.Substring(dld.FileName.LastIndexOf('\\') + 1);
                    imageLoc = dld.FileName.ToString();
                    photo_archive.Source = new BitmapImage(new Uri(imageLoc));
                    FileStream fs = new FileStream(imageLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    archive_photobyte = br.ReadBytes((int)fs.Length);

                    photo_archive.Source = new BitmapImage(new Uri(dld.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                Images archive = new Images
                {
                    FileName = shortFileName,
                    ImageDate = archive_photobyte,
                };
                Helper.GetContext().Images.Add(archive);
                Helper.GetContext().SaveChanges();
                MessageBox.Show("Скан успешно сохранен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
