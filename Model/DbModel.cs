using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrillApp.Model
{
    partial class DrillMasterEntities
    {
        private static DrillMasterEntities _context;

        public static DrillMasterEntities GetContext()
        {
            if (_context == null) _context = new DrillMasterEntities();
            return _context;
        }
    }
}
