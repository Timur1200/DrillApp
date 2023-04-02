using DrillApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrillApp.Service
{
    enum roles
    {
        Мастер=1,
        СтаршийМастер=2,
    }

    internal class Session
    {
        public static Сотрудник user { get; set; }
    }
}
