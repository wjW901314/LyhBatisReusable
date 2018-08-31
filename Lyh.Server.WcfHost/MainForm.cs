using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lyh.Controls.WindowsForms.BaseForms;
using Lyh.Wcf.Hosts;

namespace Lyh.Server.WcfHost
{
	public partial class MainForm: ServerForm
	{
		public MainForm()
		{
			InitializeComponent();
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            ServiceHostManager.Instance.Start();
            serviceHostTreeView1.ServiceHosts = ServiceHostManager.Instance.Hosts;
            serviceHostTreeView1.CreatTreeView();
        }
	}
}
