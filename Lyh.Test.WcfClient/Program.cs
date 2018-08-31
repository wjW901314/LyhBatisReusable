using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lyh.Test.WcfClient.ServiceProxy;

namespace Lyh.Test.WcfClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new UserContractClient();

            try
            {
                var result = client.Login("", "");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                client=new UserContractClient();
            }

            var obj = client.GetUser(999);
            Console.WriteLine(obj.Id + " " + obj.CtfId + " " + obj.Name);

            Console.ReadLine();
        }
    }
}