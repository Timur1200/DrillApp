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
    /// Логика взаимодействия для OrderAddEditPage.xaml
    /// </summary>
    public partial class OrderAddEditPage : Page
    {
        public OrderAddEditPage()
        {
            InitializeComponent();
            _order = new Заявка();
            _order.Дата = DateTime.Now;
            _order.Сотрудник = Session.user;
            _order.Статус = (int)status.Ремонтируется;
            _list = DrillMasterEntities.GetContext().Оборудование
                .Where(x => x.Списан == false)
                .Where(x => x.Ремонтируется == false)
                .ToList();
            EquipCBox.ItemsSource = _list;
            DataContext = _order;
        }
        private Заявка _order;
        private List<Оборудование> _list;
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DrillMasterEntities.GetContext().Заявка.Add(_order);
            _order.Оборудование.Ремонтируется = true;
            DrillMasterEntities.GetContext().SaveChanges();
            Nav.Back();
        }

        private void EquipCBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EquipCBox.Text == "")
            {

                EquipCBox.ItemsSource = _list;
                EquipCBox.SelectedItem = null;
                return;
            }
            EquipCBox.IsDropDownOpen = true;
            string Text = EquipCBox.Text.ToLower();


            EquipCBox.ItemsSource = _list.Where(q => q.name.ToLower().Contains(Text)).ToList();
        }
    }
}
