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
        gr682_gnmEntities db = new gr682_gnmEntities();
        public Compiling_a_nomenclature_of_cases()
        {
            InitializeComponent();
            Storage_articleCombo.ItemsSource = Helper.GetContext().Storage_article.ToList();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Index.Text == "" || Title.Text == "" || Note.Text == "" || Shelf.Text == "" || Number.Text == "" || Start == null || Finish == null || Storage_articleCombo == null)
            {
                MessageBox.Show("Пустые значения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //var role = Helper.GetContext().RoleUsers.FirstOrDefault(x => x.RoleName == rolecombo.Text);
                var ID_Storage_article = Helper.GetContext().Storage_article.FirstOrDefault(x => x.Shelf_life_by_article == Storage_articleCombo.Text);
                Archive users = new Archive
                {
                    Сase_index = Convert.ToInt32(Index.Text),
                    YearCreate = Convert.ToDateTime(Start.SelectedDate),
                    YearFinish = Convert.ToDateTime(Finish.SelectedDate),
                    Title = Title.Text,
                    Note = Note.Text,
                    Number_of_cases = Convert.ToInt32(Number.Text),
                    Storage_article_ID = ID_Storage_article.ID_Storage_article,
                };
                Helper.GetContext().Archive.Add(users);
                Helper.GetContext().SaveChanges();
                MessageBox.Show("Документ успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Index.Text = "";
                Title.Text = "";
                Shelf.Text = "";
                Number.Text = "";
                Storage_articleCombo.Text = "";
            }
        }
    }
}
