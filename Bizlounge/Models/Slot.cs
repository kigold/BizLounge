using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizlounge.Models
{
    public class Slot
    {
        //Project slot
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        //Total Amount Received as payback from project
        public Decimal AmountReceived { get; set; }
        //Project Budget/Project SlotCount = Slot Amount
        public virtual Project Project { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
