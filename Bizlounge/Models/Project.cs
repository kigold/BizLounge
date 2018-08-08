using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizlounge.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        //System.Globalization.CultureInfo.CreateSpecificCulture("en-NG")
        //Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-NG"), "Order Total: {0:C}", moneyvalue);
        public Decimal Budget { get; set; }
        [Display(Name = "Total Cash Payout")]
        [DataType(DataType.Currency)]
        public Decimal TotalPayout { get; set; }
        public string Duration { get; set; }
        [Display(Name= "Payback Interval")]
        public EnumPaybackInterval PaybackInterval { get; set; }
        [Display(Name = "Payback Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public Decimal PaybackAmount { get; set; }
        [Display(Name = "Payback Cycle")]
        public int PaybackCycleCount { get; set; }
        public EnumStatus Status { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public Decimal Bonus { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ProjectOwnerId { get; set; }
        [Display(Name = "Investors Slots")]
        public int SlotCount { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
        public virtual ApplicationUser ProjectOwner { get; set; }

        //enums
        public enum EnumStatus
        {
            Pitch,
            Started,
            Completed,
        }
        public enum EnumPaybackInterval
        {
            Daily,
            Weekly,
            Monthly,
            Yearly,
        }
    }
}
