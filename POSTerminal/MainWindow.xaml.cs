using System.Windows;
using System.Windows.Controls;

namespace POSTerminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Auth.LoadAccounts();
            Order.PLUs.Add("PLU1000000000", new PLU("PLU1000000000", "Item 1", 1.00));
            Order.PLUs.Add("PLU1100000000", new PLU("PLU1100000000", "Item 2", 2.70));
            Order.PLUs.Add("PLU1110000000", new PLU("PLU1110000000", "Item 3", 1.75));
            Order.PLUs.Add("PLU1111000000", new PLU("PLU1111000000", "Item 4", 4.45));
            Order.PLUs.Add("PLU1111100000", new PLU("PLU1111100000", "Item 5", 0.50, Auth.LVL_SUPERVISOR));
        }

        private void Keypad_Loaded(object sender, RoutedEventArgs e)
        { }

        private void LoadPage(object sender, RoutedEventArgs e)
        {
            UserControl uc = sender as UserControl;
            Static.Pages[uc.Name] = uc;
        }

        private void LstOrder_Loaded(object sender, RoutedEventArgs e)
        {
            Order.ListItemBox = sender as ListBox;
        }

        private void Info1_Loaded(object sender, RoutedEventArgs e)
        {
            Static.InfoOne = sender as TextBlock;
        }

        private void LstOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!Auth.SignedIn)
                return;

            ListBox lb = sender as ListBox;

            if (lb.SelectedIndex >= 0)
                Order.SelectedId = lb.SelectedIndex;
        }
    }
}
