using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using Lyh.Controls.WindowsForms.Properties;

namespace Lyh.Controls.WindowsForms.Trees
{
    public partial class ServiceHostTreeView : TreeView
    {
        public ServiceHostTreeView()
        {
            InitializeComponent();
            ItemHeight = 18;
        }

        public ServiceHostTreeView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public virtual IList<ServiceHost> ServiceHosts { get; set; }

        public virtual void CreateImageList()
        {
            ImageList = new ImageList();
            ImageList.Images.Add(Resources.network);
            ImageList.Images.Add(Resources.plugin);
            ImageList.Images.Add(Resources.address);
            ImageList.Images.Add(Resources.binding);
            ImageList.Images.Add(Resources.contract);
            ImageList.Images.Add(Resources.method);
        }

        public virtual void CreatTreeView()
        {
            CreateImageList();
            foreach (var host in ServiceHosts)
            {
                var nodeService = new TreeNode(host.Description.Name, 0, 0);
                foreach (var endpoint in host.Description.Endpoints)
                {
                    var nodeEndpoint = new TreeNode(endpoint.Name, 1, 1);
                    var nodeAddress = new TreeNode(endpoint.Address.Uri.AbsoluteUri, 2, 2);
                    var nodeBinding = new TreeNode(endpoint.Binding.Name, 3, 3);
                    var nodeContract = new TreeNode(endpoint.Contract.Name, 4, 4);
                    foreach (var method in endpoint.Contract.ContractType.GetMethods())
                    {
                        var nodeMethod = new TreeNode(method.Name, 5, 5);
                        nodeContract.Nodes.Add(nodeMethod);
                    }
                    nodeEndpoint.Nodes.AddRange(new[] {nodeAddress, nodeBinding, nodeContract});
                    nodeService.Nodes.Add(nodeEndpoint);
                }
                Nodes.Add(nodeService);
            }
        }
    }
}