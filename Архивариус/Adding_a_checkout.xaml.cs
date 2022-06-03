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
    /// Логика взаимодействия для Adding_a_checkout.xaml
    /// </summary>
    public partial class Adding_a_checkout : Window
    {
        int ID_Authorized_user_roleint;

        int ID_Regint;

        public Adding_a_checkout()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Index_iss.Text == "" || Title.Text == "" || To_whom_issued.Text == "" || Number.Text == "" || Start == null || Finish == null)
            {
                MessageBox.Show("Пустые значения!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    SQLRequest sQLRequest = new SQLRequest();   

                    Issuance issuance = new Issuance
                    {
                        To_whom_issued = To_whom_issued.Text,
                        Date_of_issue = Convert.ToDateTime(Start.SelectedDate),
                        Date_return = Convert.ToDateTime(Finish.SelectedDate),
                        Archive_ID = Convert.ToInt32(Archive_IDtxt.Text),
                        Reg_ID = sQLRequest.AddCheck(ID_Authorized_user_roleint, ID_Regint)
                    };

                    Helper.GetContext().Issuance.Add(issuance);
                    Helper.GetContext().SaveChanges();
                    MessageBox.Show("Документ успешно сохранен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    Start.SelectedDate = null;
                    Finish.SelectedDate = null;
                    To_whom_issued.Text = "";
                    Index_iss.Text = "";
                    Title.Text = "";
                    Number.Text = "";
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
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