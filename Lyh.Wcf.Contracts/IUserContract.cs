using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Lyh.MyBatis.Model;

namespace Lyh.Wcf.Contracts
{
    [ServiceContract]
    public interface IUserContract
    {
        [OperationContract]
        bool Login(string name, string password);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        IList<User> GetPageUsers(int pageIndex, int pageSize);

        [OperationContract]
        int GetTotalCount();
    }
}