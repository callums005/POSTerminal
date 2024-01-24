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

namespace POSTerminal.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void CmdFunctionView_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth.SignedIn)
                return;

            Static.Pages["viewMain"].Visibility = Visibility.Hidden;
            Static.Pages["viewFunctions"].Visibility = Visibility.Visible;
        }

        private void CmdItemOne_Click(object sender, RoutedEventArgs e)
        {
            Order.AddItem("PLU1000000000");
        }

        private void CmdItemTwo_Click(object sender, RoutedEventArgs e)
        {
            Order.AddItem("PLU1111100000");
        }
    }
}
