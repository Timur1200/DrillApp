using DrillApp.Service;
using DrillApp.View.Pages.Personal;
using DrillApp.View.Windows;
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
using DrillApp.View.Pages.Equipment;
using DrillApp.View.Pages.Order;

namespace DrillApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Nav.frame = MainFrame;
            if (Session.user.РольКод == (int)roles.Мастер)
            {
                MasterPanel.Visibility= Visibility.Visible;
                AdminPanel.Visibility= Visibility.Collapsed;
            }
            else
            {
                MasterPanel.Visibility = Visibility.Collapsed;
                AdminPanel.Visibility = Visibility.Visible;
            }
            TextBlockFio.Text = $"{Session.user.Роль.Имя} {Session.user.Фио}";
            
        }
        private void Go(Page p)
        {
            MainFrame.Navigate(p);
        }

        private void LeaveClick(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void PersonalClick(object sender, RoutedEventArgs e)
        {
            Go(new PersonalMainPage());
        }

        private void EquipmentClick(object sender, RoutedEventArgs e)
        {
            Go(new EquipmentMainPage());
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Nav.Back();
        }

        private void NewOrdersClick(object sender, RoutedEventArgs e)
        {
            Go(new OrderMainPage());
        }

        private void OrdersClick(object sender, RoutedEventArgs e)
        {
            Go(new OrderlAllMainPage());
        }
    }
}
