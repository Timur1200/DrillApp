using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrillApp.Model
{
    partial class Заявка
    {
        public string статус { get
            {
                return ((status)Статус).ToString();
            } }
    }
}
