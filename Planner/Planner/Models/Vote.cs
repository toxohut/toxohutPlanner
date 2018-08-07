using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Vote
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }
        public virtual Voting VotingId { get; set; }
        public virtual User UserId { get; set; }
        public string OpenAnswer { get; set; }
        public virtual VotingAnswer VotingAnswerId { get; set; }
    }
}