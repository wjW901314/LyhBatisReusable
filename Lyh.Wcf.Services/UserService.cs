using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lyh.MyBatis.BLL;
using Lyh.MyBatis.Model;
using Lyh.Wcf.Contracts;

namespace Lyh.Wcf.Services
{
    public class UserService : IUserContract
    {
        public bool Login(string name, string password)
        {
            return UserManager.Login(name, password);
        }

        public User GetUser(int id)
        {
            return UserManager.GetUser(id);
        }

        public IList<User> GetPageUsers(int pageIndex, int pageSize)
        {
            return UserManager.GetPageUsers(pageIndex, pageSize);
        }

        public int GetTotalCount()
        {
            return UserManager.GetTotalCount();
        }
    }
}
