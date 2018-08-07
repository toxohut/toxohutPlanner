using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Voting
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VotingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Event EventParent { get; set; }
        public Boolean IsOpenQuestion { get; set; }       
    }
}