using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace BitHiker.Api.Models
{
    [Route("/exchanges", "POST")]
    [Route("/exchanges/{Id}", "PUT")]
    public class Exchange : IReturn<Exchange>
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string TargetUserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    [Route("/exchanges", "GET")]
    [Route("/exchanges/{UserIds}", "GET")]
    public class Exchanges : IReturn<List<Exchange>>
    {
        public string[] UserIds { get; set; }

        public Exchanges(params string[] userIds)
        {
            UserIds = userIds;
        }
    }
}