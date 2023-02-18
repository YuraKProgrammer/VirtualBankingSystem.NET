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
            

    }
}
