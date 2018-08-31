namespace Lyh.Server.WcfHost
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.serviceHostTreeView1 = new Lyh.Controls.WindowsForms.Trees.ServiceHostTreeView(this.components);
            this.SuspendLayout();
            // 
            // serviceHostTreeView1
            // 
            this.serviceHostTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceHostTreeView1.ItemHeight = 18;
            this.serviceHostTreeView1.Location = new System.Drawing.Point(0, 0);
            this.serviceHostTreeView1.Name = "serviceHostTreeView1";
            this.serviceHostTreeView1.ServiceHosts = null;
            this.serviceHostTreeView1.Size = new System.Drawing.Size(469, 268);
            this.serviceHostTreeView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 268);
            this.Controls.Add(this.serviceHostTreeView1);
            this.Name = "MainForm";
            this.Text = "服务端";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private Controls.WindowsForms.Trees.ServiceHostTreeView serviceHostTreeView1;

    }
}