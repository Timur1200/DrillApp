using DrillApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EquipmentAddEditPage.xaml
    /// </summary>
    public partial class EquipmentAddEditPage : Page
    {
        public EquipmentAddEditPage(Оборудование eq)
        {
            InitializeComponent();
            if(eq == null)
            {
                _equip = new Оборудование();
                _equip.ДатаПриема = DateTime.Now;
            }
            else
            {
                _equip = eq;
            }
            _listType = DrillMasterEntities.GetContext().ТипОборудования.ToList();
            TypeComboBox.ItemsSource = _listType;
            DataContext = _equip;
        }
        private Оборудование _equip { get; set; }
        private List<ТипОборудования> _listType;
        private void ClientComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TypeComboBox.Text == "")
            {

                TypeComboBox.ItemsSource = _listType;
                TypeComboBox.SelectedItem = null;
                return;
            }
            TypeComboBox.IsDropDownOpen = true;
            string Text = TypeComboBox.Text;


            TypeComboBox.ItemsSource = _listType.Where(q => q.Имя.Contains(Text)).ToList();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_equip.ТипОборудования == null)
            {
                MessageBox.Show("Нужно выбрать тип оборудования!");
                return;
            }
            if (_equip.Код == 0) DrillMasterEntities.GetContext().Оборудование.Add(_equip);

            DrillMasterEntities.GetContext().SaveChanges();
            Nav.Back();
        }
    }
}
