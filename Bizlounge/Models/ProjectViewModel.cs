using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bizlounge.Models
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Slot> Slots { get; set; }
        public ApplicationUser ProjectOwner { get; set; }
    }
}
