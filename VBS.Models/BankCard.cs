using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models
{
    public class BankCard
    {
        public int Id { get; set; }
        public string OwnersName { get; set; }
        public DateTime LastDate { get; set; }
        public Money Money { get; set; }
            
        public BankCard(int id, string ownersName, DateTime lastDate, Currency currency)
        {
            Id = id;
            OwnersName = ownersName;
            LastDate = lastDate;
            Money = new Money(currency, 0);
        }
    }
}
