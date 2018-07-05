using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        
    }
    public class Meeting
    {
        public int MeetingId { get; set; }
        public string Name { get; set; }
    }
}