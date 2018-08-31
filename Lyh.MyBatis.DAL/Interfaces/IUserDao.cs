using System.Collections.Generic;
using Lyh.MyBatis.Model;

namespace Lyh.MyBatis.DAL.Interfaces
{
    public interface IUserDao
    {
        bool Login(string name, string password);
        IList<User> GetByPage(int startRowIndex, int endRowIndex);
        int GetCount();
    }
}
