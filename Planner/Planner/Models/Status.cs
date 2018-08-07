using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Status
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }
        public int TableId { get; set; }//do czego są te statusy, czy do spotkania czy do gosci
        public string Name { get; set; }
    }
}