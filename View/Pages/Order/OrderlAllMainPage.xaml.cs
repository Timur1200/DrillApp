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
using Word = Microsoft.Office.Interop.Word;

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
           _list = DrillMasterEntities.GetContext().Заявка.ToList();
            DGrid.ItemsSource = _list;
        }
        List<Заявка> _list;
        private void NextClick(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new DiagnosticsPage(DGrid.SelectedItem as Заявка));
        }

        private void WordClick(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string text = SearhTextBox.Text.ToLower();
                if (string.IsNullOrEmpty(text))
                {
                    DGrid.ItemsSource = _list;
                    return;
                }

                DGrid.ItemsSource = _list.Where(q => q.Оборудование.name.ToLower().Contains(text) || q.Код.ToString().Contains(text)).ToList();

            }
            catch
            {

            }
        }
    }
}
