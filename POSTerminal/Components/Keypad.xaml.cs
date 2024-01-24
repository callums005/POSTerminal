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

namespace POSTerminal.Components
{
    /// <summary>
    /// Interaction logic for Keypad.xaml
    /// </summary>
    public partial class Keypad : UserControl
    {
        public Keypad()
        {
            InitializeComponent();
        }

        private void Modify(string key)
        {
            TextBox tb = FindName("inpBox") as TextBox;

            if (key != "Clear" && key != "Backspace" && key != "Enter" && key != "SignOn" && key != "Qty")
            {
                tb.Text += key;
                return;
            }

            if (key == "Clear")
                tb.Text = "";
            else if (key == "Backspace")
            {
                if (tb.Text.Length > 0)
                {
                    tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                }
            }
            else if (key == "SignOn")
            {
                if (Auth.CheckCode(tb.Text))
                {
                    tb.Text = "";
                }
            }
            else if (key == "Qty")
            { }
        }

        private void Clear_Click(object sender, RoutedEventArgs e) { Modify("Clear"); }
        private void Backspace_Click(object sender, RoutedEventArgs e) { Modify("Backspace"); }
        private void Enter_Click(object sender, RoutedEventArgs e) { Modify("Enter"); }
        private void SignOn_Click(object sender, RoutedEventArgs e) { Modify("SignOn"); }
        private void Qty_Click(object sender, RoutedEventArgs e) { Modify("Qty"); }
        private void Num0_Click(object sender, RoutedEventArgs e) { Modify("0"); }
        private void Num1_Click(object sender, RoutedEventArgs e) { Modify("1"); }
        private void Num2_Click(object sender, RoutedEventArgs e) { Modify("2"); }
        private void Num3_Click(object sender, RoutedEventArgs e) { Modify("3");  }
        private void Num4_Click(object sender, RoutedEventArgs e) { Modify("4"); }
        private void Num5_Click(object sender, RoutedEventArgs e) { Modify("5"); }
        private void Num6_Click(object sender, RoutedEventArgs e) { Modify("6"); }
        private void Num7_Click(object sender, RoutedEventArgs e) { Modify("7"); }
        private void Num8_Click(object sender, RoutedEventArgs e) { Modify("8"); }
        private void Num9_Click(object sender, RoutedEventArgs e) { Modify("9"); }
    }
}
