using System.Collections.Generic;
using System.Windows.Controls;

namespace POSTerminal
{
    public class PLU
    {
        public PLU(string plu, string item, double price, int permLvl = 0x000)
        {
            PLU_ID = plu;
            ItemName = item;
            Price = price;
            PermissionLevel = permLvl;
        }

        public string PLU_ID = "";
        public string ItemName = "";
        public double Price = 0.00;
        public int PermissionLevel;
    }


    public static class Order
    {
        public static Dictionary<string, PLU> PLUs = new Dictionary<string, PLU>();
        public static List<string> Items = new List<string>();
        public static ListBox ListItemBox = null;
        public static int SelectedId = 0;

        public static void AddItem(string plu)
        {
            if (!Auth.CheckAuthLevel(Auth.LVL_TRAINEE))
                return;

            if (PLUs.ContainsKey(plu))
            {
                if (!Auth.CheckAuthLevel(PLUs[plu].PermissionLevel))
                    return;

                ListItemBox.Items.Add(new ListBoxItem() { Content = PLUs[plu].ItemName, FontSize = 18 });
                Items.Add(PLUs[plu].ItemName);
            }

        }

        public static void RemoveItem()
        {
            if (Items.Count < 1)
                return;

            ListItemBox.Items.RemoveAt(SelectedId);
            Items.RemoveAt(SelectedId);

            if (SelectedId > Items.Count - 1)
                SelectedId = Items.Count - 1;
        }


    }
}
