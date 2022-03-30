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
    /// Логика взаимодействия для Issuance_for_temporary_use.xaml
    /// </summary>
    public partial class Issuance_for_temporary_use : Window
    {
        public Issuance_for_temporary_use()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            dtIssuance.ItemsSource = Helper.GetContext().Issuance.ToList();
        }
    }
}
