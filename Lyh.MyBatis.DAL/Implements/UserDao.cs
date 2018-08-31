using System.Collections.Generic;
using Lyh.MyBatis.DAL.Interfaces;
using Lyh.MyBatis.Model;

namespace Lyh.MyBatis.DAL.Implements
{
    public class UserDao : BaseDao<User>, IUserDao
    {
        public override string Namespace
        {
            get { return "User"; }
        }

        public bool Login(string name, string password)
        {
            return false;
        }

        public IList<User> GetByPage(int startRowIndex, int endRowIndex)
        {
            var args = new Dictionary<string, object>
            {
                {"StartRowIndex", startRowIndex},
                {"EndRowIndex", endRowIndex}
            };
            return Mapper.Instance.QueryForList<User>(GetStatementName("GetByPage"), args);
        }

        public int GetCount()
        {
            return Mapper.Instance.QueryForObject<int>(GetStatementName("GetCount"), null);
        }
    }
}