using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lyh.Controls.WindowsForms.BigData
{
    public delegate void PageIndexChangedHandler(object sender, PageEventArgs args);

    public partial class Pager : UserControl
    {
        public Pager()
        {
            InitializeComponent();
        }

        //定义事件
        public event PageIndexChangedHandler OnPageIndexChanged;

        #region 页面属性

        /// <summary>
        /// 默认每页显示数据量
        /// </summary>
        private const int DefaultPageSize = 18;

        /// <summary>
        /// 总页数
        /// </summary>
        private int pageCount = 0;

        /// <summary>
        /// 总记录数
        /// </summary>
        private int recordCount = 0;

        /// <summary>
        /// 最大记录
        /// </summary>
        private int maxRecord = 0;

        /// <summary>
        /// 每页条数
        /// </summary>
        private int pageSize = 10;

        /// <summary>
        /// 当前页面索引
        /// </summary>
        private int currentPageIndex = 0;

        /// <summary>
        /// 记录编号
        /// </summary>
        private int recordNo;

        #endregion

        #region 公开的属性

        /// <summary>
        /// 获取总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return pageCount;
            }
        }

        private void CalculatePageCount()
        {
            pageCount = (int) Math.Ceiling((double) recordCount/pageSize);
        }

        /// <summary>
        /// 获取或设置当前页面索引
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                return currentPageIndex;
            }
            set
            {
                if (value < 0 || value >= pageCount || pageCount == value) return;
                currentPageIndex = value;
                RefreshData();
            }
        }

        /// <summary>
        /// 获取或设置一页显示多少条数据
        /// </summary>
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (value <= 0 || pageSize == value) return;
                pageSize = value;
                RefreshData();
            }
        }

        /// <summary>
        /// 获取或设置总记录数
        /// </summary>
        public int RecordCount
        {
            get
            {
                return recordCount;
            }
            set
            {
                if (recordCount == value || recordCount < 0) return;
                recordCount = value;
                CalculatePageCount();
                RefreshData();
            }
        }

        #endregion

        /// <summary>
        ///  应根据当前的CurrentPageIndex和pageCount设定按钮可用
        /// </summary>
        private void RefreshData()
        {
            if (pageCount > 1)
            {
                btnFirst.Enabled = btnPrev.Enabled = (currentPageIndex > 0);
                btnNext.Enabled = btnLast.Enabled = (currentPageIndex < pageCount - 1);
            }
            else
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            currentPageIndex = Math.Min(currentPageIndex, pageCount - 1);

            var start = 0;
            var end = 0;
            if (currentPageIndex == pageCount - 1)
            {
                start = currentPageIndex*pageSize + 1;
                end = recordCount;
            }
            else if (currentPageIndex < pageCount - 1)
            {
                start = currentPageIndex*pageSize + 1;
                end = start + pageSize - 1;
            }
            txtPageSize.Text = pageSize.ToString();
            txtPageIndex.Text = (currentPageIndex + 1).ToString();
            lblPageCount.Text = string.Format("/{0}页", pageCount);
            lblTip.Text = string.Format("显示{0}-{1},共{2}条", start, end, recordCount);
            if (OnPageIndexChanged != null)
            {
                OnPageIndexChanged(this, new PageEventArgs(currentPageIndex, pageSize));
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPageIndex = 0;
            RefreshData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentPageIndex = (currentPageIndex > 0) ? --currentPageIndex : 0;
            RefreshData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPageIndex = (currentPageIndex < pageCount - 1) ? ++currentPageIndex : pageCount - 1;
            RefreshData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPageIndex = pageCount - 1;
            RefreshData();
        }

        private void txtPageIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            lock (this)
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
                    e.Handled = true;
                if (e.KeyChar == 13)
                {
                    string indexText = txtPageIndex.Text.Trim();
                    int result;
                    if (!int.TryParse(indexText, out result))
                    {
                        MessageBox.Show("请输入正确的数字类型");
                        txtPageIndex.Text = (currentPageIndex + 1).ToString();
                        return;
                    }
                    if (result < 1)
                    {
                        MessageBox.Show("请输入正确的页码");
                        return;
                    }
                    result--;
                    if (result >= pageCount)
                    {
                        FormHelpers.MessageBoxHelper.Alert("超出页码");
                        txtPageIndex.Text = (currentPageIndex + 1).ToString();
                    }
                    else
                    {
                        currentPageIndex = result;
                        RefreshData();
                    }
                }
            }
        }

        private void txtPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
            if (e.KeyChar == 13)
            {
                string pageSizeText = txtPageSize.Text.Trim();
                int result;
                if (!int.TryParse(pageSizeText, out result))
                {
                    MessageBox.Show("请输入正确的数字类型");
                    txtPageSize.Text = pageSize.ToString();
                    return;
                }
                if (result < 1)
                {
                    MessageBox.Show("请输入正确的每页大小");
                    txtPageSize.Text = pageSize.ToString();
                }
                else
                {
                    pageSize = result;
                    CalculatePageCount();
                    RefreshData();
                }
            }
        }

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            var toolStrip = sender as ToolStrip;
            if (toolStrip != null && toolStrip.RenderMode == ToolStripRenderMode.ManagerRenderMode)
            {
                var rect = new Rectangle(0, 0, toolStrip1.Width - 2, toolStrip1.Height - 1);
                e.Graphics.SetClip(rect);
            }
        }
    }

    public class PageEventArgs : EventArgs
    {
        private int pageIndex;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public PageEventArgs(int pageIndex, int pageSize)
        {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }
    }
}