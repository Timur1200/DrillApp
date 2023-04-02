using DrillApp.Model;
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
    /// Логика взаимодействия для OrderlAllMainPage.xaml
    /// </summary>
    public partial class OrderlAllMainPage : Page
    {
        public OrderlAllMainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = DrillMasterEntities.GetContext().Заявка.ToList();
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new DiagnosticsPage(DGrid.SelectedItem as Заявка));
        }
    }
}
