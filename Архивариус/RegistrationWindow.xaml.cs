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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            dtUser.ItemsSource = Helper.GetContext().Reg.ToList();
            Role_Combo.ItemsSource = Helper.GetContext().Role.ToList();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (Logintxt.Text == "" || Passwordpsw.Password == "" || LastNametxt.Text == "" || FirstNametxt.Text == "" || Role_Combo == null)
            {
                MessageBox.Show("Пустые значения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    var ID_Role = Helper.GetContext().Role.FirstOrDefault(x => x.Role_Name == Role_Combo.Text);
                    Reg reg = new Reg
                    {
                        Login = Logintxt.Text,
                        Password = Passwordpsw.Password,
                        LastName = LastNametxt.Text,
                        FirstName = FirstNametxt.Text,
                        MiddleName = MiddleNametxt.Text,
                        Role_ID = ID_Role.ID_Role,
                    };
                    Helper.GetContext().Reg.Add(reg);
                    Helper.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    Logintxt.Text = "";
                    Passwordpsw.Password = "";
                    Role_Combo.Text = "";
                    Load();
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавление", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var User = dtUser.SelectedItems.Cast<Reg>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующее {User.Count()} пользователей ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Helper.GetContext().Reg.RemoveRange(User);
                    Helper.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    Load();
                }
                catch
                {
                    MessageBox.Show("Не удалось выполнить удаление!");
                }
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                var ID_Role = Helper.GetContext().Role.FirstOrDefault(x => x.Role_Name == Role_Combo.Text);
                Reg reg = new Reg
                {
                    Login = Logintxt.Text,
                    Password = Passwordpsw.Password,
                    LastName = LastNametxt.Text,
                    FirstName = FirstNametxt.Text,
                    MiddleName = MiddleNametxt.Text,
                    Role_ID = ID_Role.ID_Role,
                };
                Helper.GetContext().Reg.Add(reg);
                Helper.GetContext().SaveChanges();
                Load();
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить изменение!");
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

        private void dtUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reg reg = (Reg)dtUser.SelectedItem;
            Logintxt.Text = reg.Login;
            Passwordpsw.Password = reg.Password;
            LastNametxt.Text = reg.LastName;
            FirstNametxt.Text = reg.FirstName;
            MiddleNametxt.Text = reg.MiddleName;
            Role_Combo.SelectedItem = reg.Role;
        }
    }
}