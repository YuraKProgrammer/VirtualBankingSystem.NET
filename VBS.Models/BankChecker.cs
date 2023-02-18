using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models
{
    public static class BankChecker
    {
        public static bool Check(Bank bank)
        {
            if (bank!=null && DateTime.UtcNow == bank.NowTime)
            {
                return true;
            }
            return false;
        } 
    }
}
