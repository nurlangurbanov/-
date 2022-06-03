using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Архивариус
{
    internal class SQLRequest
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=mssql;Initial Catalog=gr682_gnm;Integrated Security=True");

        public int ImFunc(int maxID)
        {
            sqlConnection.Open();
            string vivodID1 = @"SELECT MAX(ID_Images) FROM Images";
            SqlCommand command1 = new SqlCommand(vivodID1, sqlConnection);
            SqlDataReader reader1 = command1.ExecuteReader();

            if (reader1.HasRows) // если есть данные
            {
                while (reader1.Read()) // построчно считываем данные
                {
                    object id = reader1.GetValue(0);
                    maxID = Convert.ToInt32(id.ToString());
                }
            }
            reader1.Close();
            return maxID;
        }

        public int AddCheck(int ID_Authorized_user_roleint, int ID_Regint)
        {
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

            return ID_Regint;
        }
    }
}