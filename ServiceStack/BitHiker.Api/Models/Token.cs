using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitHiker.Api.Models
{
    public class Token
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int MaxAssignments { get; set; }
        public int MaxReassignments { get; set; }
        public bool AllowUseridReassignment { get; set; }
        public string LastKnownLocationId { get; set; }
        public DateTime AllowTokenReassignmentAfterDate { get; set; }
        public DateTime AllowTokenReassignmentBeforeDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
    }
}