using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        SqlConnection sqlConnection = new SqlConnection("Data Source=mssql;Initial Catalog=gr682_gnm;Integrated Security=True");

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
                    //var ID_Archive = Helper.GetContext().Archive_work.FirstOrDefault(x => x.Title == Title.Text);
                    sqlConnection.Open();
                    string vivodID1 = @"SELECT MAX(ID_Authorized_user_role) FROM Authorized_user_role";
                    SqlCommand command1 = new SqlCommand(vivodID1, sqlConnection);
                    SqlDataReader reader1 = command1.ExecuteReader();

                    if (reader1.HasRows) // если есть данные
                    {
                        while (reader1.Read()) // построчно считываем данные
                        {
                            object id = reader1.GetValue(0);
                            ID_Authorized_user_roleint = Convert.ToInt32(id.ToString());
                        }
                    }
                    reader1.Close();

                    string vivodID2 = $"SELECT Reg_ID FROM Authorized_user_role where ID_Authorized_user_role = {ID_Authorized_user_roleint}";
                    SqlCommand command2 = new SqlCommand(vivodID2, sqlConnection);
                    SqlDataReader reader2 = command2.ExecuteReader();

                    if (reader2.HasRows) // если есть данные
                    {
                        while (reader2.Read()) // построчно считываем данные
                        {
                            object id = reader2.GetValue(0);
                            ID_Regint = Convert.ToInt32(id.ToString());
                        }
                    }
                    reader2.Close();

                    Issuance issuance = new Issuance
                    {
                        To_whom_issued = To_whom_issued.Text,
                        Date_of_issue = Convert.ToDateTime(Start.SelectedDate),
                        Date_return = Convert.ToDateTime(Finish.SelectedDate),
                        Archive_ID = Convert.ToInt32(Archive_IDtxt.Text),
                        Reg_ID = ID_Regint
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
    }
}