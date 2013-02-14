using BitHiker.Api.Models;
using BitHiker.Api.Repositories;
using ServiceStack.Common;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace BitHiker.Api.Services
{
    public class PrototypeExchangeResponse : Exchange
    {
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class PrototypeExchangeService : Service
    {
        public PrototypeExchangeRepository Repository { get; set; }

        public object Post(PrototypeExchange exchange)
        {
            return Repository.Store(exchange);
        }

        public object Get(PrototypeExchanges request)
        {
            return request.UserIds.IsEmpty()
                       ? Repository.GetAll()
                       : Repository.GetByUserIds(request.UserIds);
        }
    }
}