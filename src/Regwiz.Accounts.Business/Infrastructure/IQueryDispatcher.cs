﻿namespace Regwiz.Accounts.Business.Infrastructure
{
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}