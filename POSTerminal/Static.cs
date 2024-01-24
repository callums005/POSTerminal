using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POSTerminal
{
    public static class Static
    {
        public static Dictionary<string, UserControl> Pages = new Dictionary<string, UserControl>();
        public static TextBlock InfoOne = null;
    }
}
