using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Guest
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean Invited { get; set; }
        public Boolean Coming { get; set; }
        public virtual User User { get; set; }
        public virtual Status Status { get; set; }
    }
}