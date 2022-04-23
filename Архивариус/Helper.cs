using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Архивариус
{
    class Helper
    {
        private static gr682_gnmEntities _context;
        public static gr682_gnmEntities GetContext()
        {
            if (_context == null)
            {
                _context = new gr682_gnmEntities();
            }
            return _context;
        }
    }
}
