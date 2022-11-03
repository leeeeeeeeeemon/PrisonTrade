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
    /// Логика взаимодействия для PrisonersPage.xaml
    /// </summary>
    public partial class PrisonersPage : Page
    {
        List<People> peoples = bd_connection.connection.People.ToList();
        public PrisonersPage()
        {
            InitializeComponent();
            this.DataContext = this;
            prisionerList.ItemsSource = peoples;
        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
