using System.Collections.Generic;
using Lyh.MyBatis.DAL.Interfaces;

namespace Lyh.MyBatis.DAL.Implements
{
    public class BaseDao<T> : IBaseDao<T>
    {
        public virtual string Namespace
        {
            get { return ""; }
            set { }
        }

        public virtual string StatementInsert
        {
            get { return "Insert"; }
            set { }
        }

        public virtual string StatementDelete
        {
            get { return "Delete"; }
            set { }
        }

        public virtual string StatementUpdate
        {
            get { return "Update"; }
            set { }
        }

        public virtual string StatementGet
        {
            get { return "Get"; }
            set { }
        }

        public virtual string StatementGetList
        {
            get { return "GetList"; }
            set { }
        }

        public virtual object Insert(T entity)
        {
            return Mapper.Instance.Insert(GetStatementName(StatementInsert), entity);
        }

        public virtual int Delete(object obj)
        {
            return Mapper.Instance.Delete(GetStatementName(StatementDelete), obj);
        }

        public virtual int Update(T entity)
        {
            return Mapper.Instance.Update(GetStatementName(StatementUpdate), entity);
        }

        public virtual T Get(object obj)
        {
            return Mapper.Instance.QueryForObject<T>(GetStatementName(StatementGet), obj);
        }

        public virtual IList<T> GetList(object obj)
        {
            return Mapper.Instance.QueryForList<T>(GetStatementName(StatementGetList), obj);
        }

        protected string GetStatementName(string statementName)
        {
            return string.IsNullOrWhiteSpace(Namespace) ? statementName : Namespace + "." + statementName;
        }
    }
}