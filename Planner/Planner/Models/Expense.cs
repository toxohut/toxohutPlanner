using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Expense
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ExpenseId { get; set; }
        public virtual Meeting MeetingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //todo: kategoria
        //todo: zaliczka?
        [Column(TypeName = "Date")]
        public DateTime PaymentTerm { get; set; }
        public Decimal PaymentAmount { get; set; }
        public Boolean Done { get; set; }
        //usługodawca, odniesienie do uzytkowników
        public virtual User Provider { get; set; }
        //dokumenty
    }
}