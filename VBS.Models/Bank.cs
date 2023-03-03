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
        private const int superCode = 123;
        private const int cancellationCode = 1;
        private List<BankCard> bankCards = new List<BankCard>();

        public string MakeAMoneyTransfer(int id1, int id2, int summ)
        {
            NowTime = DateTime.UtcNow;
            var c1 = bankCards.Where(bc => bc.Id == id1).FirstOrDefault();
            var c2 = bankCards.Where(bc => bc.Id == id2).FirstOrDefault();
            if (BankChecker.CheckBank(this))
            {
                if (CheckCard(c1) && CheckCard(c2) && c1.Money.Currency == c2.Money.Currency && c1.Money.Value >= summ)
                {
                    c1.Money.Value = c1.Money.Value - summ;
                    c2.Money.Value = c2.Money.Value + summ;
                    return BankChecker.GetToken1(id1,id2,summ,superCode);
                }
            }
            return BankChecker.GetToken1(id1, id2, summ, cancellationCode);
        } 

        public string MakeDomesticPayment(int id, Payment payment)
        {
            NowTime = DateTime.UtcNow;
            var id2 = payment.GetRecipientId();
            var c1 = bankCards.Where(bc => bc.Id == id).FirstOrDefault();
            var c2 = bankCards.Where(bc => bc.Id == id2).FirstOrDefault();
            var summ = payment.GetSumm();
            if (BankChecker.CheckBank(this))
            {
                if (CheckCard(c1) && CheckCard(c2) && c1.Money.Currency == c2.Money.Currency && c1.Money.Value >= summ)
                {
                    c1.Money.Value = c1.Money.Value - summ;
                    c2.Money.Value = c2.Money.Value + summ;
                    return BankChecker.GetToken1(id, id2, summ, superCode);
                }
            }
            return BankChecker.GetToken1(id, id2, summ, cancellationCode);
        }

        public bool CheckCorrectnessOfTransfer(int id1, int id2, int summ, string token)
        {
            if (BankChecker.GetSuperCode1(id1, id2, summ, token)==superCode)
            {
                return true;
            }
            else if (BankChecker.GetSuperCode1(id1, id2, summ, token)==cancellationCode) 
            {
                return false;
            }
            else
            {
                throw new Exception("ВНИМЕНИЕ! ПОДДЕЛЬНЫЙ ТОКЕН!");
            }
        }

        public bool CheckCorrectnessOfDomesticPayment(int id1, Payment payment, string token)
        {
            if (BankChecker.GetSuperCode1(id1, payment.GetRecipientId(), payment.GetSumm(), token) == superCode)
            {
                return true;
            }
            else if (BankChecker.GetSuperCode1(id1, payment.GetRecipientId(), payment.GetSumm(), token) == cancellationCode)
            {
                return false;
            }
            else
            {
                throw new Exception("ВНИМЕНИЕ! ПОДДЕЛЬНЫЙ ТОКЕН!");
            }
        }

        public int GetCountOfMoney(int id)
        {
            var c = bankCards.Where(bc => bc.Id == id).FirstOrDefault();
            return c.Money.Value;
        }

        public bool CheckCard(BankCard bankCard)
        {
            if (bankCard!=null && bankCard.LastDate > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public int CreateCard(string ownersName,Currency currency)
        {
            var id = bankCards.Count + 1;
            var ld = DateTime.UtcNow.AddDays(1826);
            var bc = new BankCard(id, ownersName, ld, currency); 
            bankCards.Add(bc);
            return id;
        } 

        public int KnowBalance(int id)
        {
            var c = bankCards.Where(bc => bc.Id == id).FirstOrDefault();
            return c.Money.Value;
        }

        public void EmptyEnrollment(int id, int value)
        {
            var c = bankCards.Where(bc => bc.Id == id).FirstOrDefault();
            c.Money.Value+=value;
        }
    }
}
