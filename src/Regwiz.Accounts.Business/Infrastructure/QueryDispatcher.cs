using System;
using Microsoft.Extensions.DependencyInjection;
using Regwiz.Accounts.Business.Exceptions;

namespace Regwiz.Accounts.Business.Infrastructure
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly ServiceProvider _resolver;

        public QueryDispatcher(ServiceProvider resolver)
        {
            _resolver = resolver;
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            if (query == null) throw new ArgumentNullException("query");

            var handler = _resolver.GetService<IQueryHandler<TQuery, TResult>>();

            if (handler == null) throw new QueryHandlerNotFoundException(typeof(TQuery).ToString());

            return handler.Execute(query);
        }
    }
}