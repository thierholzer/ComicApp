using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Comic.Data.Dapper
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        string _connectionString = string.Empty;

        public Repository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ComicDB"].ConnectionString;
        }

        public long Add(T item)
        {
            long id;
            using (IDbConnection _connection = new SqlConnection(_connectionString))
            {
                id = _connection.Insert(item);
                _connection.Close();
            }
            return id;
        }

        public void Dispose()
        {

        }

        public IEnumerable<T> Find<TValue>(Expression<Func<T, object>> expression, TValue value)
        {
            IEnumerable<T> list = Enumerable.Empty<T>();
            using (IDbConnection _connection = new SqlConnection(_connectionString))
            {
                var p = Predicates.Field<T>(expression, Operator.Eq, value);
                list = _connection.GetList<T>(p);
                _connection.Close();
            }
            return list;
        }

        public IEnumerable<T> Get(PredicateGroup predicates)
        {
            if (predicates == null) throw new ArgumentNullException("predicates");
            IEnumerable<T> list = Enumerable.Empty<T>();
            using (IDbConnection _connection = new SqlConnection(_connectionString))
            {
                return _connection.GetList<T>(predicates);
            }
        }

        public IEnumerable<T> FindAll()
        {
            IEnumerable<T> list = Enumerable.Empty<T>();
            using (IDbConnection _connection = new SqlConnection(_connectionString))
            {
                
               return _connection.GetList<T>().ToArray();
            }
        }

        public T FindByID(string id)
        {
            T entity;
            using (IDbConnection _connection = new SqlConnection(_connectionString))
            {
                entity = _connection.Get<T>(id);
                _connection.Close();
            }
            return entity;
        }

        public T FindByID(int id)
        {
            T entity;
            using (IDbConnection _connection = new SqlConnection(_connectionString))
            {
                entity = _connection.Get<T>(id);
                _connection.Close();
            }
            return entity;
        }

        public void Remove(T item)
        {
            using (IDbConnection _connection = new SqlConnection(_connectionString))
            {
                _connection.Delete(item);
                _connection.Close();
            }
        }

        public void Update(T item)
        {
            using (IDbConnection _connection = new SqlConnection(_connectionString))
            {
                _connection.Update(item);
                _connection.Close();
            }
        }

    }
}