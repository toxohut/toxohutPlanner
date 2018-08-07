using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Event
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string Name { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual Status Status { get; set; }
        public virtual Expense ExpenseId { get; set; }
    }
}