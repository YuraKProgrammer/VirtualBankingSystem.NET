using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBS.Models
{
    public class Payment
    {
        private int recipientId { get; set; }
        private int summ { get; set; }

        private string target { get; set; }
        public Payment(int recipientId, int summ, string target)
        {
            this.recipientId = recipientId;
            this.summ = summ;
            this.target = target;
        }
        public int GetSumm()
        {
            return summ;
        }

        public int GetRecipientId()
        {
            return recipientId;
        }

        public string GetTarget()
        {
            return target;
        }
    }
}
