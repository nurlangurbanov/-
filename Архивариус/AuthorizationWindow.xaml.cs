﻿using System;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (Logintxt.Text == "" || Passwordpsw.Password == "")
            {
                MessageBox.Show("Пустое поле логина/пароля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var todaysDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                var user = Helper.GetContext().Reg.FirstOrDefault(x => x.Login == Logintxt.Text && x.Password == Passwordpsw.Password);
                if (user == null)
                {
                    MessageBox.Show("Такого пользователя не существует!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    Logintxt.Text = "";
                    Passwordpsw.Password = "";
                    Logintxt.Focus();
                }
                //else if (user.ID_Status == 2)
                //{
                //    MessageBox.Show("Этот сотрудник уволен!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                //    logintxt.Text = "";
                //    passwordpsw.Password = "";
                //    logintxt.Focus();
                //}
                //else
                //{
                //    string userinfo = user.LastName + " " + user.FirstName.Substring(0, 1) + ". " + user.MiddleName.Substring(0, 1) + ".";
                //    Helper.ID_user = user.ID_User;
                //    if (user.ID_Role == 1)
                //    {
                //        MessageBox.Show("Вы вошли как Администратор!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                //        AdminWindow adminWindow = new AdminWindow();
                //        adminWindow.Title = "Администратор - " + userinfo;
                //        adminWindow.Show();
                //        this.Close();
                //    }
                //    if (user.ID_Role == 2)
                //    {
                //        if (Helper.GetContext().WorkShift.Where(x => x.ID_User == Helper.ID_user && x.DateShift == todaysDate).FirstOrDefault() != null)
                //        {
                //            MessageBox.Show("Вы вошли как Официант!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                //            WaiterWindow waiterWindow = new WaiterWindow();
                //            waiterWindow.Title = "Официант - " + userinfo;
                //            waiterWindow.Show();
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Ваша смена сегодня не назначена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                //        }
                //    }
                //    if (user.ID_Role == 3)
                //    {
                //        if (Helper.GetContext().WorkShift.Where(x => x.ID_User == Helper.ID_user && x.DateShift == todaysDate).FirstOrDefault() != null)
                //        {
                //            MessageBox.Show("Вы вошли как Повар!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                //            CookWindow cookWindow = new CookWindow();
                //            cookWindow.Title = "Повар - " + userinfo;
                //            cookWindow.Show();
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Ваша смена сегодня не назначена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                //        }
                //    }
                //}
            }
        }
    }
}
