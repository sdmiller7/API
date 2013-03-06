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

    public class PrototypeExchangeRepository
    {
        private readonly IDbConnectionFactory _dbFactory;

        public PrototypeExchangeRepository(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void CreateMissingTables()
        {
            _dbFactory.Run(db => db.CreateTable<PrototypeExchange>(false));
        }

        public List<PrototypeExchange> GetAll()
        {
            return _dbFactory.Run(db => db.Select<PrototypeExchange>());
        }

        public List<PrototypeExchange> GetByUserIds(string[] userIds)
        {
            using (var dbConnection = _dbFactory.OpenDbConnection())
            {
                return dbConnection.Each<PrototypeExchange>().Where(p => userIds.Contains(p.UserId)).ToList();
            }
        }

        public PrototypeExchange GetById(string id)
        {
            using (var dbConnection = _dbFactory.OpenDbConnection())
            {
                return dbConnection.GetById<PrototypeExchange>(id);
            }
        }

        public PrototypeExchange Store(PrototypeExchange exchange)
        {
            using (var dbConnection = _dbFactory.OpenDbConnection())
            {
                if (exchange.Id == null)
                {
                    exchange.Id = Guid.NewGuid().ToString("N");
                    dbConnection.Insert(exchange);
                }
                else dbConnection.Update(exchange);
            }

            return exchange;
        }
    }
}