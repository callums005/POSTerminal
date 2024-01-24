using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using System.Threading;

namespace POSTerminal.View
{
    /// <summary>
    /// Interaction logic for Functions.xaml
    /// </summary>
    public partial class Functions : UserControl
    {
        public Functions()
        {
            InitializeComponent();
        }

        private void CmdExitPOS_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth.CheckAuthLevel(Auth.LVL_MANAGER))
                return;

            Environment.Exit(1);
        }

        private void CmdRestartPOS_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CmdBack_Click(object sender, RoutedEventArgs e)
        {
            Static.Pages["viewMain"].Visibility = Visibility.Visible;
            Static.Pages["viewFunctions"].Visibility = Visibility.Hidden;
        }

        private void CmdSignOff_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth.SignedIn)
                return;

            Auth.SignOff();
        }

        private void CmdDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth.CheckAuthLevel(Auth.LVL_TRAINEE))
                return;

            Order.RemoveItem();
        }

        private void CmdEmployees_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth.CheckAuthLevel(Auth.LVL_MANAGER))
                return;

            Static.Pages["viewFunctions"].Visibility = Visibility.Hidden;
            Static.Pages["viewAccounts"].Visibility = Visibility.Visible;
        }
    }
}
