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
    /// Логика взаимодействия для TypeEquipmentAddEditPage.xaml
    /// </summary>
    public partial class TypeEquipmentAddEditPage : Page
    {
        public TypeEquipmentAddEditPage(ТипОборудования type)
        {
            InitializeComponent();
            if (type == null)
            {
                _type = new ТипОборудования();
            }
            else
            {
                _type = type;  
            }
            DataContext = _type;
        }
        private ТипОборудования _type { get; set; }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_type.Код == 0) DrillMasterEntities.GetContext().ТипОборудования.Add(_type);
                DrillMasterEntities.GetContext().SaveChanges();
                Nav.Back();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
