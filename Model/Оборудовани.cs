using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrillApp.Model
{
    partial class Оборудование
    {
        public string списан
        {
            get
            {
                return Списан ? "Да" : "Нет";
            }
        }
        public string ремонт
        {
            get
            {
                return Ремонтируется ? "Да" : "Нет";
            }
        }
        public string name
        {
            get
            {
                return $"{ТипОборудования.Имя} №{Код}";
            }
        }
    }
}
