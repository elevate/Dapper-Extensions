using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using System.Threading.Tasks;


namespace DapperExtensions
{
    public interface IDatabase : IDisposable
    {
        bool HasActiveTransaction { get; }
        IDbConnection Connection { get; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
        void RunInTransaction(Action action);
        T RunInTransaction<T>(Func<T> func);
        Task<T> Get<T>(dynamic id, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<T> Get<T>(dynamic id, int? commandTimeout = null) where T : class;
        Task Insert<T>(IEnumerable<T> entities, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task Insert<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class;
        Task<dynamic> Insert<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<dynamic> Insert<T>(T entity, int? commandTimeout = null) where T : class;
        Task<bool> Update<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<bool> Update<T>(T entity, int? commandTimeout = null) where T : class;
        Task<bool> Delete<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<bool> Delete<T>(T entity, int? commandTimeout = null) where T : class;
        Task<bool> Delete<T>(object predicate, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<bool> Delete<T>(object predicate, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetList<T>(object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) where T : class;
        Task<IEnumerable<T>> GetList<T>(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null, bool buffered = true) where T : class;
        Task<IEnumerable<T>> GetPage<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) where T : class;
        Task<IEnumerable<T>> GetPage<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, int? commandTimeout = null, bool buffered = true) where T : class;
        Task<IEnumerable<T>> GetSet<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class;
        Task<IEnumerable<T>> GetSet<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, int? commandTimeout, bool buffered) where T : class;
        Task<int> Count<T>(object predicate, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<int> Count<T>(object predicate, int? commandTimeout = null) where T : class;
        IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, IDbTransaction transaction, int? commandTimeout = null);
        IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, int? commandTimeout = null);
        void ClearCache();
        Guid GetNextGuid();
        IClassMapper GetMap<T>() where T : class;
    }
}