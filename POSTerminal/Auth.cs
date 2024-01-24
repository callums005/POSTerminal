using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal
{
    public class EmployeeAccount
    {
        public EmployeeAccount(string pass, string user, int permLvl)
        {
            Passcode = pass;
            Username = user;
            PermissionLevel = permLvl;
        }

        public string Passcode = "";
        public string Username = "";
        public int PermissionLevel = 0x001;
    }

    public static class Auth
    {
        public static Dictionary<string, EmployeeAccount> Accounts = new Dictionary<string, EmployeeAccount>();

        public static string Account = "";
        public static bool SignedIn = false;

        public static int LVL_MANAGER = 0x111;
        public static int LVL_SUPERVISOR = 0x011;
        public static int LVL_CASHIER = 0x001;
        public static int LVL_TRAINEE = 0x000;

        public static void LoadAccounts()
        {
            Accounts.Add("0000", new EmployeeAccount("0000", "T_Trainee", 0x000));
            Accounts.Add("0001", new EmployeeAccount("0001", "T_Cashier", 0x001));
            Accounts.Add("0002", new EmployeeAccount("0002", "T_Supervisor", 0x011));
            Accounts.Add("0003", new EmployeeAccount("0003", "T_Manager", 0x111));
        }

        public static bool CheckCode(string code)
        {
            if (Accounts.ContainsKey(code))
            {
                Account = code;
                SignedIn = true;
                Static.InfoOne.Text = $"SIGNED ON: {Auth.GetName()}";

                return true;
            }

            return false;
        }

        public static bool CheckAuthLevel(int lvl)
        {
            if (!SignedIn)
                return false;

            if (Accounts.ContainsKey(Account))
            {
                if (Accounts[Account].PermissionLevel >= lvl)
                    return true;
            }

            return false;
        }

        public static void SignOff()
        {
            Account = "";
            SignedIn = false;
            Static.InfoOne.Text = $"PLEASE SIGN ON";
        }

        public static string GetName()
        {
            if (Accounts.ContainsKey(Account))
                return SignedIn ? Accounts[Account].Username : "N/A";

            return "ACCOUNT DOES NOT EXIST";
        }

    }
}
