using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizlounge.Models
{
    public class Payment
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        //what cycle is the payment for
        public int ProjectPaybackCycle { get; set; }
        [ForeignKey("ApplicationUser")]
        public string PayeerId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string PayeeId { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public Decimal Amount { get; set; }
        public string Proof { get; set; }
        public EnumStatus Status { get; set; }

        public virtual Project Project { get; set; }
        public virtual ApplicationUser Payer { get; set; }
        public virtual ApplicationUser Payee { get; set; }

        //enum
        public enum EnumStatus
        {
            Pending,
            Received,
        }
    }
}
