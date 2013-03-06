using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitHiker.Api.Models
{
    public class User
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TimeZone { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}