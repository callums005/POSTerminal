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
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : UserControl
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void CmdBack_Click(object sender, RoutedEventArgs e)
        {
            Static.Pages["viewAccounts"].Visibility = Visibility.Hidden;
            Static.Pages["viewFunctions"].Visibility = Visibility.Visible;
        }

        private void CmdNew_Click(object sender, RoutedEventArgs e)
        {
            Grid newGrid = FindName("New") as Grid;

            newGrid.Visibility = Visibility.Visible;
        }

        private void CmdModify_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmdDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmdCreateNew_Click(object sender, RoutedEventArgs e)
        {
            TextBox InpPasscode = FindName("InpPasscode") as TextBox;
            TextBox InpName = FindName("InpName") as TextBox;

            RadioButton[] radButtons = new RadioButton[4];

            radButtons[0] = FindName("radTrainee") as RadioButton;
            radButtons[1] = FindName("radCashier") as RadioButton;
            radButtons[2] = FindName("radSupervisor") as RadioButton;
            radButtons[3] = FindName("radManager") as RadioButton;

            int perms = 0x000;

            for (int i = 0; i < radButtons.Length; i++)
            {
                if (radButtons[i].IsChecked == true)
                {
                    switch(i)
                    {
                        case 0:
                            perms = Auth.LVL_TRAINEE;
                            break;
                        case 1:
                            perms = Auth.LVL_CASHIER;
                            break;
                        case 2:
                            perms = Auth.LVL_SUPERVISOR;
                            break;
                        case 3:
                            perms = Auth.LVL_MANAGER;
                            break;

                    }
                }
            }

            Auth.Accounts.Add(InpPasscode.Text, new EmployeeAccount(InpPasscode.Text, InpName.Text, perms));
        }

        
    }
}
