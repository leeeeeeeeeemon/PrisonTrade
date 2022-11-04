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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrisonTrade.BD;

namespace PrisonTrade.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPageEmp.xaml
    /// </summary>
    public partial class MainPageEmp : Page
    {
        List<Trade> trades = bd_connection.connection.Trade.ToList();
        public MainPageEmp()
        {
            InitializeComponent();
            this.DataContext = this;
            tradeList.ItemsSource = trades;
            //Trade f = bd_connection.connection.Trade.FirstOrDefault();
            
        }

        private void prisionerPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PrisonersPage());
        }
    }
}
