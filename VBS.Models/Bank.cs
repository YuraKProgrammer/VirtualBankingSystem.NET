using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models
{
    public class Bank
    {
        public DateTime NowTime;

        public List<BankCard> bankCards;

        public bool MakeAMoneyTransfer(int id1, int id2, int summ)
        {
            var c1 = bankCards.Where(bc => bc.Id == id1).FirstOrDefault();
            var c2 = bankCards.Where(bc => bc.Id == id2).FirstOrDefault();
            if (CheckCard(c1) && CheckCard(c2) && c1.Money.Currency==c2.Money.Currency && c1.Money.Value > summ)
            {
                c1.Money.Value = c1.Money.Value - summ;
                c2.Money.Value = c2.Money.Value + summ;
                return true;
            }
            return false;
        } 

        public bool CheckCard(BankCard bankCard)
        {
            if (bankCard!=null && bankCard.LastDate < DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
