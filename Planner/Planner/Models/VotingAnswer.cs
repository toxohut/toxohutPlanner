using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class VotingAnswer
    {        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VotingAnswerId { get; set; }
        [ForeignKey("Voting")]
        public int VotingId { get; set; }
        public virtual Voting Voting { get; set; }
        public string AnswerText { get; set; }        
    }

    
}