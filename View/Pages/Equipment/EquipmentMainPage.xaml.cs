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

namespace DrillApp.View.Pages.Equipment
{
    /// <summary>
    /// Логика взаимодействия для EquipmentMainPage.xaml
    /// </summary>
    public partial class EquipmentMainPage : Page
    {
        public EquipmentMainPage()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate((new EquipmentAddEditPage(null)));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            Nav.frame.Navigate((new EquipmentAddEditPage(DGrid.SelectedItem as Оборудование)));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {

        }

        private void TypeClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new TypeEquipmentMainPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = DrillMasterEntities.GetContext().Оборудование.ToList();
        }
    }
}
