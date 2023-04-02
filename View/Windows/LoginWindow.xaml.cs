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
using System.Windows.Shapes;

namespace DrillApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var users = DrillMasterEntities.GetContext().Сотрудник.ToList();
                foreach ( var user in users )
                {
                    if (user.Логин == LoginTBox.Text && user.Пароль == PassBox.Password)
                    {
                        if (user.Уволен)
                        {
                            MessageBox.Show("У вас нет доступа к системе");
                            return;
                        }
                        Session.user = user;
                        MainWindow win = new MainWindow();
                        win.Show();
                        this.Close();
                        return;
                    }
                }
                MessageBox.Show("Неверно введен логин или пароль");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
