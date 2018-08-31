using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lyh.MyBatis.DAL.Implements;
using Lyh.MyBatis.Model;

namespace Lyh.MyBatis.BLL
{
    public class UserManager
    {
        public static bool Login(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("用户名不能为空");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("密码不能为空");
            var userDao = new UserDao();
            return userDao.Login(name, password);
        }

        public static User GetUser(int id)
        {
            var userDao = new UserDao();
            return userDao.Get(id);
        }

        public static IList<User> GetPageUsers(int pageIndex, int pageSize)
        {
            if (pageIndex < 0) throw new Exception("页码无效");
            if (pageSize < 1) throw new Exception("页大小无效");
            var userDao = new UserDao();
            return userDao.GetByPage(pageIndex*pageSize, (pageIndex + 1)*pageSize);
        }

        public static int GetTotalCount()
        {
            var userDao = new UserDao();
            return userDao.GetCount();
        }

        public static int Insert(User user)
        {
            var userDao = new UserDao();
            return (int) userDao.Insert(user);
        }
    }
}