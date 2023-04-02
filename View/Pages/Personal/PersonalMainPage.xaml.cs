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

namespace DrillApp.View.Pages.Personal
{
    /// <summary>
    /// Логика взаимодействия для PersonalMainPage.xaml
    /// </summary>
    public partial class PersonalMainPage : Page
    {
        public PersonalMainPage()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new PersonalAddEditPage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new PersonalAddEditPage(DGrid.SelectedItem as Сотрудник));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem as Сотрудник == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            else
            {
                var item = DGrid.SelectedItem as Сотрудник;
                
                item.Уволен = !item.Уволен;
                DrillMasterEntities.GetContext().SaveChanges();
                Page_Loaded(null, null);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGrid.ItemsSource = DrillMasterEntities.GetContext().Сотрудник.OrderBy(q=>q.Уволен).ToList();

        }
    }
}
