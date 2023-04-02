using DrillApp.Model;
using DrillApp.Service;
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

namespace DrillApp.View.Pages.Order
{
    /// <summary>
    /// Логика взаимодействия для OrderMainPage.xaml
    /// </summary>
    public partial class OrderMainPage : Page
    {
        public OrderMainPage()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new OrderAddEditPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = DrillMasterEntities.GetContext().Заявка.Where(q=>q.КодСотрудника==Session.user.Код).ToList();
        }

        private void ReportClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new ReportMainPage(DGrid.SelectedItem as Заявка));
        }
    }
}
