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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            if (loginTb.Text =="" || Password.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            } else
            {
                int log = Convert.ToInt32(loginTb.Text);
                People people = bd_connection.connection.People.FirstOrDefault(p => (int)p.id == log && p.Password == Password.Text);
                if (people == null)
                {
                    MessageBox.Show("Пользователь не найден");
                } else
                {
                    NavigationService.Navigate(new MainPagePrisoner(people));
                }
            }
        }

        private void loginbtnEmp_Click(object sender, RoutedEventArgs e)
        {
            if (loginTb.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                int log = Convert.ToInt32(loginTb.Text);
                Employee emp = bd_connection.connection.Employee.FirstOrDefault(p => (int)p.id == log && p.Password == Password.Text);
                if (emp == null)
                {
                    MessageBox.Show("Пользователь не найден");
                }
                else
                {
                    NavigationService.Navigate(new MainPageEmp());
                }
            }
            
        }
    }
}
