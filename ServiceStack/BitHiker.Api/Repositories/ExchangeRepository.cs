using System;
using System.Collections.Generic;
using System.Linq;
using BitHiker.Api.Models;
using ServiceStack.OrmLite;

namespace BitHiker.Api.Repositories
{
    public class ExchangeRepository
    {
        private readonly IDbConnectionFactory _dbFactory;

        public ExchangeRepository(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void CreateMissingTables()
        {
            _dbFactory.Run(db => db.CreateTable<Exchange>(false));
        }

        public List<Exchange> GetAll()
        {
            return _dbFactory.Run(db => db.Select<Exchange>());
        }

        public List<Exchange> GetByUserIds(string[] userIds)
        {
            return _dbFactory.OpenDbConnection().Each<Exchange>().Where(p => userIds.Contains(p.UserId)).ToList();
        }

        public Exchange GetById(string id)
        {
            return _dbFactory.OpenDbConnection().GetById<Exchange>(id);
        }

        public Exchange Store(Exchange exchange)
        {
            if (exchange.Id == null)
            {
                exchange.Id = Guid.NewGuid().ToString("N");
                _dbFactory.OpenDbConnection().Insert(exchange);
            }
            else _dbFactory.OpenDbConnection().Update(exchange);

            return exchange;
        }
    }
}