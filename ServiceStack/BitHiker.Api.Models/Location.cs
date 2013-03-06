using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitHiker.Api.Models
{
    public class Location
    {
        public string Id { get; set; }
        public decimal Point { get; set; }
        public DateTime CreationDate { get; set; }
    }
}