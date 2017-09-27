using System;
using System.Collections.Generic;
using DapperExtensions;

namespace Comic.Data.Dapper
{
    public interface IRepository<T>
    {
        long Add(T item);
        void Remove(T item);
        void Update(T item);
        T FindByID(Int32 id);
        T FindByID(String id);
        IEnumerable<T> FindAll();

    }
}