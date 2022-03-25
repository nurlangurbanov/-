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
            RoleCombo.ItemsSource = Helper.GetContext().Role.ToList();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (Logintxt.Text == "" || Passwordpsw.Password == "" || RoleCombo == null)
            {
                MessageBox.Show("Пустые значения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var ID_Role = Helper.GetContext().Role.FirstOrDefault(x => x.Role_Name == RoleCombo.Text);
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
                RoleCombo.Text = "";
            }
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.ShowDialog();
            this.Close();
        }
    }
}