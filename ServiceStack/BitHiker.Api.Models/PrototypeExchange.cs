using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace BitHiker.Api.Models
{
    [Route("/prototype_exchanges", "POST")]
    [Route("/prototype_exchanges/{Id}", "PUT")]
    public class PrototypeExchange : IReturn<PrototypeExchange>
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string TargetUserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double HorizontalAccuracy { get; set; }
        public double LocationFreshnessInSeconds { get; set; }
        //public double TransferTime { get; set; }
        //public double LocationLockTimeInSeconds { get; set; }
    }

    [Route("/prototype_exchanges", "GET")]
    [Route("/prototype_exchanges/{UserIds}", "GET")]
    public class PrototypeExchanges : IReturn<List<PrototypeExchange>>
    {
        public string[] UserIds { get; set; }

        public PrototypeExchanges(params string[] userIds)
        {
            UserIds = userIds;
        }
    }
}