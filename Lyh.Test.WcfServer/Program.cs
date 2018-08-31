using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Lyh.Wcf.Hosts;
using Lyh.Wcf.Services;

namespace Lyh.Test.WcfServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Starting...");
            try
            {
                ServiceHostManager.Instance.Opening += Instance_Opening;
                ServiceHostManager.Instance.Opened += Instance_Opened;
                ServiceHostManager.Instance.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("OK.");

            Console.ReadLine();

            ServiceHostManager.Instance.Close();
        }

        static void Instance_Opened(object sender, EventArgs e)
        {
            var sh = sender as ServiceHost;
            var v = sh.Description.Endpoints[0];
            var s = string.Format("[A]:{0},[B]:{1},[C]:{2}", v.Address, v.Binding.Name, v.Contract.Name);
            Console.WriteLine(s);
        }

        static void Instance_Opening(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
        }
    }
}