using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Lyh.MyBatis.Model
{
    [DataContract]
    public class User
    {
        private int _id;

        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _UserName;

        [DataMember]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _password;

        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _Email;

        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}