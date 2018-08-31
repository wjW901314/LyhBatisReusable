using System.Collections.Generic;

namespace Lyh.MyBatis.DAL.Interfaces
{
    public interface IBaseDao<T>
    {
        string Namespace { get; set; }
        string StatementInsert { get; set; }
        string StatementDelete { get; set; }
        string StatementUpdate { get; set; }
        string StatementGet { get; set; }
        string StatementGetList { get; set; }
        object Insert(T entity);
        int Delete(object obj);
        int Update(T entity);
        T Get(object obj);
        IList<T> GetList(object obj);
    }
}
