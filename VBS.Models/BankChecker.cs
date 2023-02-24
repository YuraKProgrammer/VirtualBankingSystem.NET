using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models
{
    public static class BankChecker
    {
        public static bool CheckBank(Bank bank)
        {
            if (bank!=null && DateTime.UtcNow == bank.NowTime)
            {
                return true;
            }
            return false;
        }
        
        public static string GetToken1(int id1, int id2, int summ, int superCode)
        {
            return ((id1 * id2) / (summ * superCode)).ToString();
        }

        public static int GetSuperCode1(int id1, int id2, int summ, string token)
        {
            int t = Int32.Parse(token);

        } 
    }
}
