using BitHiker.Api.Models;
using BitHiker.Api.Repositories;
using ServiceStack.Common;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace BitHiker.Api.Services
{
    public class ExchangeResponse : Exchange
    {
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class ExchangeService : Service
    {
        public ExchangeRepository Repository { get; set; }

        public object Post(Exchange exchange)
        {
            return Repository.Store(exchange);
        }

        public object Get(Exchanges request)
        {
            return request.UserIds.IsEmpty()
                       ? Repository.GetAll()
                       : Repository.GetByUserIds(request.UserIds);
        }
    }
}