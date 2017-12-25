using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Server
{
    /// <summary>
    /// 分页控件，支持多线程（跨线程安全访问）
    /// </summary>
    public partial class Pager : UserControl
    {
        #region 属性字段

        /// <summary>
        /// 当面页码
        /// </summary>
        public virtual int PageIndex { get; set; }

        /// <summary>
        /// 每页显示记录的条数
        /// </summary>
        public virtual int PageSize { get; set; }

        /// <summary>
        /// 满足条件的记录总条数
        /// </summary>
        public virtual int RecordCount { get; set; }

        /// <summary>
        /// 页码总数
        /// </summary>
        private int PageCount = 0;

        #endregion

        #region 委托事件

        /// <summary>
        /// 页码切换事件
        /// </summary>
        public event EventHandler OnPageChanged;

        /// <summary>
        /// 设置控件状态的委托（采用多线程技术，使用delegate和invoke来从其他线程中控制控件信息）
        /// </summary>
        private delegate void SetCtrolEnabledDelegate();

        /// <summary>
        /// 页面控件呈现的委托（采用多线程技术，使用delegate和invoke来从其他线程中控制控件信息）
        /// </summary>
        private delegate void PageDelegate();

        /// <summary>
        /// 跨线程安全访问控件的委托
        /// </summary>
        /// <param name="objCtrl"></param>
        /// <param name="text"></param>
        /// <param name="uctl"></param>
        private delegate void SetTextCallback(System.Windows.Forms.ToolStripLabel objCtrl, string text, UserControl uctl);

        #endregion

        /// <summary>
        /// 跨线程安全设置控件的Text值
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="objCtrl"></param>
        /// <param name="text"></param>
        /// <param name="uctl"></param>
        private static void SetText<TObject>(TObject objCtrl, string text, UserControl uctl) where TObject : System.Windows.Forms.ToolStripLabel
        {
            if (objCtrl.Owner.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);

                if (objCtrl.Owner.IsDisposed || !objCtrl.Owner.IsHandleCreated)
                {
                    return;
                }

                uctl.Invoke(d, new object[] { objCtrl, text, uctl });
            }
            else
            {
                objCtrl.Text = text;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        public Pager()
        {
            InitializeComponent();
            SetText(this.lbl_PageCount, "0", this);
            SetText(this.lbl_PageCount, "每页0条记录,共0条记录", this);
        }

        /// <summary>
        /// 外部调用分页控件
        /// </summary>
        public void Page()
        {
            PageCount = GetPageCount();
            Page(false);
        }

        /// <summary>
        /// 界面呈现
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int GetPageCount()
        {
            if (PageSize == 0)
            {
                return 0;
            }
            int pageCount = RecordCount / PageSize;
            if (RecordCount % PageSize == 0)
            {
                pageCount = RecordCount / PageSize;
            }
            else
            {
                pageCount = RecordCount / PageSize + 1;
            }
            return pageCount;
        }

        /// <summary>
        /// 设置页码导航键为可用
        /// </summary>
        private void SetCtrolEnabled()
        {
            if (this.toolStrip1.InvokeRequired)//等待异步
            {
                SetCtrolEnabledDelegate myDelegate = new SetCtrolEnabledDelegate(SetCtrolEnabled);
                this.Invoke(myDelegate);//通过委托调用
            }
            else
            {
                btn_First.Enabled = true;
                btn_Last.Enabled = true;
                btn_Next.Enabled = true;
                btn_Previous.Enabled = true;
            }

        }

        /// <summary>
        /// 页面控件呈现
        /// </summary>
        private void Page(bool callEvent)
        {
            if (this.toolStrip1.InvokeRequired)//等待异步
            {
                PageDelegate myDelegate = new PageDelegate(SetCtrolEnabled);

                if (this.Parent != null && !this.Parent.IsHandleCreated)
                {
                    return;
                }

                if (IsDisposed || !this.IsHandleCreated || !this.toolStrip1.IsHandleCreated)
                {
                    return;
                }

                this.Invoke(myDelegate, new object[] { false });//通过委托调用
            }
            else
            {
                if (PageIndex == 0)
                {
                    PageIndex = 1;
                }

                txt_CurrentIndex.Text = PageIndex.ToString();
                lbl_PageCount.Text = PageCount.ToString();
                lbl_RecordCount.Text = string.Format("每页{0}条记录,共{1}条记录", PageSize, RecordCount);

                if (callEvent && OnPageChanged != null)
                {
                    OnPageChanged(this, null);//当前分页数字改变时，触发委托事件
                }
                SetCtrolEnabled();
                if (PageCount == 1)//有且仅有一页
                {
                    btn_First.Enabled = false;
                    btn_Last.Enabled = false;
                    btn_Next.Enabled = false;
                    btn_Previous.Enabled = false;
                }
                else if (PageIndex == 1)//第一页
                {
                    btn_First.Enabled = false;
                    btn_Previous.Enabled = false;
                }
                else if (PageIndex == PageCount)//最后一页
                {
                    btn_Next.Enabled = false;
                    btn_Last.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 点击翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
            {
                return;
            }
            switch (e.ClickedItem.Tag.ToString())
            {
                case "First":
                    PageIndex = 1;
                    break;
                case "Previous":
                    PageIndex = Math.Max(1, PageIndex - 1);
                    break;
                case "Next":
                    PageIndex = Math.Min(PageCount, PageIndex + 1);
                    break;
                case "Last":
                    PageIndex = PageCount;
                    break;
            }
            Page(true);
        }

        #region 页码值改变事件
        /// <summary>
        /// 在页码处输入按下键盘输入字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_CurrentIndex_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_CurrentIndex != null)
                {
                    if (!ValidateInput(txt_CurrentIndex.Text.Trim()))
                    {
                        MessageBox.Show
                            (
                            string.Format("只能输入大于零的数字。"),
                            "文电系统",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                            );
                        return;
                    }
                    int index = 1;
                    int.TryParse(txt_CurrentIndex.Text, out index);

                    if (0 <= index && index <= PageCount)
                    {
                        PageIndex = index;
                    }
                    else
                    {
                        MessageBox.Show
                            (
                            string.Format("数字超出范围。"),
                            "文电系统",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                            );
                    }
                    Page(true);
                }
            }
        }

        private void txt_CurrentIndex_TextChanged(object sender, EventArgs e)
        {
            if (txt_CurrentIndex != null)
            {
                if (!ValidateInput(txt_CurrentIndex.Text.Trim()))
                {
                    MessageBox.Show
                        (
                        string.Format("只能输入大于零的数字。"),
                        "文电系统",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    return;
                }
                int index = 1;
                int.TryParse(txt_CurrentIndex.Text, out index);

                if (0 <= index && index <= PageCount)
                {
                    PageIndex = index;
                }
                else
                {
                    MessageBox.Show
                        (
                        string.Format("数字超出范围。"),
                        "文电系统",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
                Page(true);
            }
        }
        #endregion

        /// <summary>
        /// 验证输入的页码为数字
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private bool ValidateInput(string inputString)
        {
            Regex reg = new Regex("^[1-9]\\d*$");
            Match match = reg.Match(inputString);
            return match.Success;
        }


    }
}
