using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrillApp
{
    internal class Nav
    {
        public static Frame frame { get; set; }
        public static void Back()
        {
            if (frame.NavigationService.CanGoBack) frame.NavigationService.GoBack();
        }
    }
}
