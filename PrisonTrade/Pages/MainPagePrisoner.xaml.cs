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
    /// Логика взаимодействия для MainPagePrisoner.xaml
    /// </summary>
    public partial class MainPagePrisoner : Page
    {
        People pplID;
        //public static List<bug> bugs;
        List<bugDesc> bugs; //= bd_connection.connection.bugDesc.ToList();
        public MainPagePrisoner(People id)
        {
            pplID = id;
            InitializeComponent();
            bugs = bd_connection.connection.bugDesc.ToList();
            this.DataContext = this;
            BagCB.ItemsSource = bugs;
        }

        private void showPrisonerBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PrisonersPage());
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if(loginAuth_tb.Text == "" || BagCB.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!");
            } else
            {
                Trade trade = new Trade();
                trade.id_PeopGive = pplID.id;
                trade.id_PeopTake = Convert.ToInt32(loginAuth_tb.Text);
                trade.id_Bug = BagCB.SelectedIndex + 1;
                int con = Convert.ToInt32(loginAuth_tb.Text);
                People f = bd_connection.connection.People.FirstOrDefault(p => p.id == con);
                if(f == null)
                {
                    MessageBox.Show("Пользователь не найден!");
                } else
                {
                    trade.id_Guild = f.id_Guld;
                    bd_connection.connection.Trade.Add(trade);
                    bd_connection.connection.SaveChanges();
                    MessageBox.Show("Заявка на посылку созданна");
                    if(f.id_Guld == 4)
                    {
                        MessageBox.Show("Ваша гильдия измененна на Петух");
                        pplID.id_Guld = 4;
                        bd_connection.connection.SaveChanges();
                    }
                }
            }
        }
    }
}
