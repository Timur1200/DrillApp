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
    /// Логика взаимодействия для TypeEquipmentMainPage.xaml
    /// </summary>
    public partial class TypeEquipmentMainPage : Page
    {
        public TypeEquipmentMainPage()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new TypeEquipmentAddEditPage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
           if ( DGrid.SelectedItem as ТипОборудования == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            Nav.frame.Navigate(new TypeEquipmentAddEditPage(DGrid.SelectedItem as ТипОборудования));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem as ТипОборудования == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            try
            {
                DrillMasterEntities.GetContext().ТипОборудования.Remove(DGrid.SelectedItem as ТипОборудования);
                DrillMasterEntities.GetContext().SaveChanges();
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Page_Loaded(null, null);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = DrillMasterEntities.GetContext().ТипОборудования.ToList();
        }
    }
}
