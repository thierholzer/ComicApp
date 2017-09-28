using System;
using System.Collections.Generic;
using DapperExtensions;
using System.Linq.Expressions;

namespace Comic.Data.Dapper
{
    public interface IRepository<T>
    {
        long Add(T item);
        void Remove(T item);
        void Update(T item);
        T FindByID(Int32 id);
        T FindByID(String id);
        IEnumerable<T> Find<TValue>(Expression<Func<T, object>> expression, TValue value);
        IEnumerable<T> FindAll();
        IEnumerable<T> Get(PredicateGroup Predicates);
    }
}