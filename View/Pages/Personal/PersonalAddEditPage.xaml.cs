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
    /// Логика взаимодействия для PersonalAddEditPage.xaml
    /// </summary>
    public partial class PersonalAddEditPage : Page
    {
        public PersonalAddEditPage(Сотрудник pers)
        {
            InitializeComponent();
            CBoxRole.ItemsSource = DrillMasterEntities.GetContext().Роль.ToList();
            if (pers == null)
            {
                _personal = new Сотрудник();
                _personal.Уволен = false;
            }
            else
            {
                _personal = pers;
            }
            DataContext = _personal;
        }
        private Сотрудник _personal { get; set; }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_personal.Код == 0) DrillMasterEntities.GetContext().Сотрудник.Add(_personal);
                DrillMasterEntities.GetContext().SaveChanges();
                Nav.Back();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
