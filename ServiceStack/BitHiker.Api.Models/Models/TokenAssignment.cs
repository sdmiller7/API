using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitHiker.Api.Models
{
    public class TokenAssignment
    {
        public string Id { get; set; }
        public string TokenId { get; set; }
        public string UserId { get; set; }
        public string LocationId { get; set; }
        public string PriorAssignmentId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}