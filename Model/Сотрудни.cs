using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrillApp.Model
{
    partial class Сотрудник
    {
        public string Status
        {
            get
            {
                return Уволен ? "Уволен" : "Работает";
            }
        }
    }
}
