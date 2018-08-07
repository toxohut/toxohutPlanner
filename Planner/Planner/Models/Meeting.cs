using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Meeting
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MeetingId { get; set; }
        public virtual User Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }        
    }
}