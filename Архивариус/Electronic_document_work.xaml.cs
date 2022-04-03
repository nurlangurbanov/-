using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Electronic_document_work.xaml
    /// </summary>
    public partial class Electronic_document_work : Window
    {
        public Electronic_document_work()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            dtElectronic.ItemsSource = Helper.GetContext().Archive_of_electronic_documents.ToList();
            Storage_articleCombo.ItemsSource = Helper.GetContext().Storage_article.ToList();
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

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Index.Text == "" || Title.Text == "" || Storage_articleCombo == null || Way.Text == "")
            {
                MessageBox.Show("Пустые значения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var ID_Storage_article = Helper.GetContext().Storage_article.FirstOrDefault(x => x.Storage_article1 == Storage_articleCombo.Text);
                Archive_of_electronic_documents ae = new Archive_of_electronic_documents
                {
                    Сase_index = Index.Text,
                    Title = Title.Text,
                    Storage_article_ID = ID_Storage_article.ID_Storage_article,
                    Way = Way.Text
                };
                Helper.GetContext().Archive_of_electronic_documents.Add(ae);
                Helper.GetContext().SaveChanges();
                MessageBox.Show("Документ успешно сохранен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Index.Text = "";
                Title.Text = "";
                Storage_articleCombo.Text = "";
                Way.Text = "";
                Load();
            }

        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var Electronic = dtElectronic.SelectedItems.Cast<Archive_of_electronic_documents>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {Electronic.Count()} элементов ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Helper.GetContext().Archive_of_electronic_documents.RemoveRange(Electronic);
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

        private void Open(object sender, RoutedEventArgs e)
        {
            Archive_of_electronic_documents worker = (Archive_of_electronic_documents)dtElectronic.SelectedItem;
            string path = worker.Way;
            Process.Start(path);
        }

        private void Insert_way(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult)
                    MessageBox.Show(dialog.FileName.Remove(dialog.FileName.IndexOf(dialog.SafeFileName)));
                Way.Text = dialog.FileName.Remove(dialog.FileName.IndexOf(dialog.SafeFileName));
            }
            catch
            {
                MessageBox.Show("Не выбран файл!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}