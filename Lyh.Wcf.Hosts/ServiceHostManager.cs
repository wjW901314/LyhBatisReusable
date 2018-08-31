using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;

namespace Lyh.Wcf.Hosts
{
    public class ServiceHostManager
    {
        public event EventHandler Closed;
        public event EventHandler Closing;
        public event EventHandler Faulted;
        public event EventHandler Opened;
        public event EventHandler Opening;
        public readonly IList<ServiceHost> Hosts = new List<ServiceHost>();
        public readonly string ServiceAssembly;
        private static readonly ServiceHostManager instance = new ServiceHostManager();

        public static ServiceHostManager Instance
        {
            get { return instance; }
        } 


        public ServiceHostManager()
        {
            ServiceAssembly = ConfigurationManager.AppSettings["ServiceAssembly"];
        }

        private void OpenHost(Type t)
        {
            var host = new ServiceHost(t);
            host.Opening += Opening;
            host.Opened += Opened;
            host.Closing += Closing;
            host.Closed += Closed;
            host.Faulted += Faulted;
            host.Open();
            Hosts.Add(host);
        }

        public void Start()
        {
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            var svcmod = (ServiceModelSectionGroup) config.GetSectionGroup("system.serviceModel");
            foreach (ServiceElement se in svcmod.Services.Services)
            {
                var type = Type.GetType(string.Format("{0},{1}", se.Name, ServiceAssembly));
                if (type == null) throw new Exception("配置文件中的服务类型 " + se.Name + " 无效.");
                OpenHost(type);
            }
        }

        public void Close()
        {
            foreach (var host in Hosts)
            {
                host.Close();
            }
        }
    }
}