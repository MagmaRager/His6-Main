using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;

using His6.Base;
using His6.Model;
using DevExpress.Utils.Svg;

namespace His6.Main
{
    /// <summary>
    ///  系统主窗口
    /// </summary>
    public partial class FrmMainRibbon : RibbonForm
    {
        #region 成员变量

        //  外部信息接口对象
        private RemoteInfoReceiver infoRemoteAction;

        //  本地信息接口对象
        private LocalInfoReceiver infoLocalAction;

        //  通知窗口对象列表
        private Dictionary<string, FrmNoticeBase> dictNotice = new Dictionary<string, FrmNoticeBase>(); 

        Timer timer1;
        //  菜单固定项目数
        int fixedItemCount = 0;
        //  系统标题名称
        public string Title { get; internal set; } 

        #endregion

        #region 构造方法
        /// <summary>
        ///  构造方法
        /// </summary>
        public FrmMainRibbon()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            this.ribbon.Manager.UseAltKeyForMenu = false;

            if (!DesignMode)
            {
                #region 加载皮肤

                DisplayHelper.SetCaption("加载换肤信息");
                SkinHelper.InitSkinGallery(rgbiSkins, true);
                this.bsiSkin.Visibility = BarItemVisibility.Never;
                // 获取默认皮肤
                string default_skin = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;

                var parmList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()),
                    new KeyValuePair<string, string>("parmName", "DEF_SKIN")
                };
                CustomException ce = null;
                string skinname = HttpDataHelper.GetStringWithInfo("BASE", "/sys/parameteremp", out ce, parmList);
                if (!String.IsNullOrEmpty(skinname) && default_skin != skinname)
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinname);
                }
                
                #endregion

                customTabbedMdiManager1.MdParBackImage = Properties.Resources.Main;
                // 启动定时器
                this.timer1 = new Timer();
                this.timer1.Interval = 1000;
                this.timer1.Tick += (ts, te) => 
                {
                    this.barItemServerTimeLable.Caption = DateTime.Now.ToString("MM/dd HH:mm:ss ");
                };
            }
            this.fixedItemCount = this.ribbon.Items.Count;
            switch (LogHelper._logLevel)
            {
                case 0:
                    this.bciLogNone.Checked = true;
                    break;
                case 1:
                    this.bciLogError.Checked = true;
                    break;
                case 2:
                    this.bciLogWarn.Checked = true;
                    break;
                case 3:
                    this.bciLogDebug.Checked = true;
                    break;
                case 4:
                    this.bciLogInfo.Checked = true;
                    break;
            }
        }

        #endregion

        #region 初始化有关

        /// <summary>
        ///  系统初始化处理
        /// </summary>
        public bool Init()
        {
            if (EmpInfo.Id <= 0)
            {
                this.Close();
                return false;
            }

            //  人员基本信息
            LogHelper.Info(this, "系统初始化 --- 设置人员有关信息");
            this.bsiOper.Caption = EmpInfo.Name + "(" + EmpInfo.BizDeptName + ")";
            this.bsiIP.Caption = EnvInfo.ComputerIp;
            this.bsiUser.Caption = EnvInfo.UserName;
            this.bbiChangeChoice.Caption = (EmpInfo.InputChoice == "1") ? "首拼" : "五笔";
            LinkMacAddress.Caption = "未识别";
            for (int i = 0; i < EnvInfo.ComputerMacIpList.Count; i++)
            {
                if (i==0)
                {
                    LinkMacAddress.Caption = EnvInfo.ComputerMacIpList[i].Mac;
                }
                else
                {
                    var item = new BarHeaderItem {Caption = EnvInfo.ComputerMacIpList[i].Mac,AllowRightClickInMenu = false};
                    LinkMacAddress.LinksPersistInfo.Add(new LinkPersistInfo(item)); 
                }
            }
            //初始化子系统
            LogHelper.Info(this, "系统初始化 --- 子系统初始化");
            string open_menu_code = InitSubSystem();

            //初始化主菜单
            LogHelper.Info(this, "系统初始化 --- 生成主菜单");
            InitMainMenu(open_menu_code);

            //  加入可切换的子系统
            BarSubItem bsiSystem = new DevExpress.XtraBars.BarSubItem();
            bsiSystem.Caption = "系统切换";
            bsiSystem.Id = this.ribbon.Items.Count;
            bsiSystem.Name = "bsiSystem";
            this.ribbon.Items.Add(bsiSystem);
            this.rbPageGroupTools.ItemLinks.Insert(0, bsiSystem);
            foreach (BDictSystem system in EmpInfo.CanUseSystemList)
            {
                if (system.Code != EnvInfo.SystemCode)
                {
                    BarButtonItem bbi = new BarButtonItem();
                    bbi.Caption = system.Name;
                    bbi.Id = this.ribbon.Items.Count;
                    bbi.Name = "bbiSystem" + system.Code;
                    bbi.Tag = system.Code;
                    bbi.ItemClick += new ItemClickEventHandler(this.bbiSystem_ItemClick);
                    bbi.RibbonStyle = RibbonItemStyles.Default;

                    if (!string.IsNullOrEmpty(system.Ico))
                    {
                        bbi.ImageOptions.Image = BmpHelper.GetIco(system.Ico);
                    }
                    this.ribbon.Items.Add(bbi);
                    bsiSystem.LinksPersistInfo.Add(new LinkPersistInfo(bbi));
                }
            }

            //  v9.2以后不加入会出现下拉菜单不能出来！！！
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();

            //初始化外部信息对象, 危机值、关注项由通知
            List<string> infoRemoteCodeList = new List<string>();
            //  TODO:  ？？？ 
            infoRemoteCodeList.Add("");             //  危机值信息
            infoRemoteCodeList.Add("");             //  关注项信息

            infoRemoteAction = new RemoteInfoReceiver(infoRemoteCodeList, SynCallbackInfo);

            //初始化内部信息对象
            List<string> infoLocalCodeList = new List<string>();
            infoLocalCodeList.Add(LocalInfoHelper.OpenForm);                //  打开Form
            infoLocalCodeList.Add(LocalInfoHelper.AddNotice);               //  接受通知
            infoLocalCodeList.Add(LocalInfoHelper.DelNotice);               //  撤销通知
            infoLocalAction = new LocalInfoReceiver(infoLocalCodeList, CallbackInfo);

            for (int index = 0; index < ribbon.Pages.Count; index++)
            {
                var item = ribbon.Pages[index];
                item.Appearance.Font = new Font(SystemFonts.DefaultFont.Name, SystemFonts.DefaultFont.Size);
            }
            for (int index = 0; index < ribbon.Items.Count; index++)
            {
                var item = ribbon.Items[index];
                item.ItemAppearance.SetFont(new Font(SystemFonts.DefaultFont.Name, SystemFonts.DefaultFont.Size));
            }

            LogHelper.Info(this, "系统初始化 --- 启动定时器");
            timer1.Start();
            DisplayHelper.Close();
            return true;
        }

        /// <summary>
        /// 初始化子系统
        /// </summary>
        /// <returns>子系统自动打开的菜单代码</returns>
        private string InitSubSystem()
        {
            DisplayHelper.Show("获取子系统相关数据", "正在装载系统，请等待...");

            BDictSystem system = EmpInfo.CanUseSystemList.Find(sys => sys.Code == EnvInfo.SystemCode);
            this.Text = this.Title + " --- " + EnvInfo.SystemName;
            Image img = BmpHelper.GetBmp(system.Ico);
            if (img != null)
            {
                Bitmap map = new Bitmap(img);
                Icon icon = Icon.FromHandle(map.GetHicon());
                if (icon != null)
                {
                    this.Icon = icon;
                }
            }

            //  获取参数（ParamHelper） 根据系统和人员获取默认菜单
            String pname = "DEF_MENU_" + EnvInfo.SystemCode;

            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()),
                new KeyValuePair<string, string>("parmName", pname)
            };
            CustomException ce = null;
            String menuCode = HttpDataHelper.GetStringWithInfo("BASE", "/sys/parameteremp", out ce, parmList);
            return menuCode;
        }

        #region 初始化菜单
        /// <summary>
        /// 主菜单
        /// </summary>
        /// <param name="open_menu_code">自动打开菜单代码</param>
        private void InitMainMenu(string open_menu_code)
        {
            //  产生菜单\

            string ribbonmin = "2";
            //  TODO: 获取员工工具带条最小化的值

            this.ribbon.Minimized = (ribbonmin == "1");
            this.ribbon.MinimizedChanged += new EventHandler(ribbon_MinimizedChanged);

            //  清除除固定外的菜单项
            for (int i = this.ribbon.Pages.Count - 2; i >= 0; i--)
            {
                this.ribbon.Pages[i].Dispose();
            }
            for (int i = this.ribbon.Items.Count - 1; i >= this.fixedItemCount; i--)
            {
                this.ribbon.Items[i].Dispose();
            }

            // 形成工具条并取运行默认功能
            this.Create_Page(open_menu_code);
        }

        /// <summary>
        /// 形成Page及Item
        /// </summary>
        private void Create_Page(string open_menu_code)
        {
            //  取菜单表
            //  获取可用菜单信息
            String roles = EmpInfo.Roles;

            var parmList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("systemId", EnvInfo.SystemId.ToString()),
                new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()),
                new KeyValuePair<string, string>("roles", EmpInfo.Roles),
            };
            CustomException ce = null;
            List<DataMenu> menuList = HttpDataHelper.GetWithInfo<List<DataMenu>>("BASE", "/sys/menu", out ce, parmList);
            // 删除失效菜单（模块或对象不可用）
            for (int i = menuList.Count - 1; i >= 0; i--)
            {
                if(!String.IsNullOrEmpty(menuList[i].ObjectCode) && (String.IsNullOrEmpty(menuList[i].ObjectName) || String.IsNullOrEmpty(menuList[i].ModuleName)))
                {
                    menuList.RemoveAt(i);
                }
            }

            int num = 0;
            string curPageOrd = "";
            RibbonPage rbPage = new RibbonPage();
            RibbonPageGroup rbPageGroup = new RibbonPageGroup();

            for (int i = 0; i < menuList.Count; i++)
            {
                string code = menuList[i].Code;
                string title = menuList[i].Title;

                if (code.Length == 1)        //  对应页
                {
                    rbPage = new RibbonPage(title);
                    rbPage.Name = "rbPage" + code;
                    this.ribbon.Pages.Insert(num, rbPage);
                    this.ribbon.Pages[num].Visible = false;
                    curPageOrd = code;
                    num++;
                }

                if (code.Length == 2)   //  对应页组                        
                {
                    int funcount = CountFunctionItem(menuList, i);      //  是否存在功能
                    if (funcount > 0 && num > 0 && curPageOrd == code.Substring(0, 1))
                    {
                        this.ribbon.Pages[num - 1].Visible = true;
                        //  加入页组
                        rbPageGroup = new RibbonPageGroup("");
                        rbPageGroup.Name = "rbPageGroup" + code;
                        rbPageGroup.ShowCaptionButton = false;

                        rbPage.Groups.Add(rbPageGroup);

                        string funname = menuList[i].ObjectName;
                        if (!string.IsNullOrEmpty(funname))
                        {
                            BarButtonItem bbi = new BarButtonItem();
                            bbi.Caption = title;
                            bbi.Id = this.ribbon.Items.Count;
                            bbi.Name = "bbi" + code;

                            if (!string.IsNullOrEmpty(menuList[i].Prompt))
                            {
                                SuperToolTip stt = new SuperToolTip();
                                ToolTipItem tti = new ToolTipItem();
                                tti.Text = menuList[i].Prompt;
                                stt.Items.Add(tti);
                                bbi.SuperTip = stt;
                            }

                            string ico = menuList[i].Ico;
                            if (!ico.IsNullOrEmpty())                               //  图标
                            {
                                if (ico.ToLower().EndsWith("svg"))
                                    bbi.ImageOptions.SvgImage = BmpHelper.GetSvg(ico);
                                else
                                    bbi.LargeGlyph = BmpHelper.GetIco(ico);

                                bbi.RibbonStyle = RibbonItemStyles.Default;
                            }
                            bbi.Tag = ToFunction(menuList[i]);

                            bbi.ItemClick += new ItemClickEventHandler(this.dynamic_bbi_ItemClick);
                            this.ribbon.Items.Add(bbi);
                            rbPageGroup.ItemLinks.Add(bbi);
                            rbPageGroup.Visible = true;
                        }
                        else
                        {
                            BarSubItem bsimenu = this.CreateMenu(menuList, ref i);              //  产生菜单

                            if (bsimenu.LinksPersistInfo.Count > 0 || bsimenu.Tag != null)        //  有子项才加入
                            {
                                this.ribbon.Items.Add(bsimenu);
                                rbPageGroup.ItemLinks.Add(bsimenu);
                                rbPageGroup.Visible = true;
                            }
                        }
                    }
                }
            }

            this.ribbon.SelectedPage = this.ribbon.Pages[0];
            //  找自动打开菜单
            if (open_menu_code != null)
            {
                DataMenu default_menu = menuList.Find(o => o.Code == open_menu_code);
                if(default_menu != null && !String.IsNullOrEmpty(default_menu.ObjectName) && !String.IsNullOrEmpty(default_menu.ModuleName))
                {
                    Execute(ToFunction(default_menu));
                }
            }
            return;
        }

        /// <summary>
        ///  产生菜单
        /// </summary>
        /// <param name="menu">菜单数据</param>
        /// <param name="pi">菜单起点</param>
        /// <returns></returns>
        private BarSubItem CreateMenu(List<DataMenu> menuList, ref int pi)
        {
            //  取数据到变量
            string code = menuList[pi].Code;
            string title = menuList[pi].Title;

            //  加入下拉菜单
            BarSubItem bsimenu = new BarSubItem();
            bsimenu.Caption = title;
            bsimenu.Name = "bsi" + code;

            string ico = menuList[pi].Ico; 
            if (!ico.IsNullOrEmpty())					//  图标
            {
                if (ico.ToLower().EndsWith("svg"))
                    bsimenu.ImageOptions.SvgImage = BmpHelper.GetSvg(ico);
                else
                {
                    Image img = BmpHelper.GetIco(ico);
                    bsimenu.LargeGlyph = bsimenu.Glyph = img;
                }
            }

            //  在菜单项下加入菜单（中间项）或子项（功能项）
            pi++;
            for (; pi < menuList.Count; pi++)
            {
                string code1 = menuList[pi].Code;
                string title1 = menuList[pi].Title;
                if (code1.Length == (code.Length + 1) && code1.Substring(0, code.Length) == code)
                {
                    string modname = menuList[pi].ModuleName;
                    string funname = menuList[pi].ObjectName;
                    string para = menuList[pi].Parameter;
                    int openflag = menuList[pi].WinState;
                    if (string.IsNullOrEmpty(funname))                      //  有子菜单
                    {
                        BarSubItem bsisubmenu = this.CreateMenu(menuList, ref pi);
                        if (bsisubmenu.LinksPersistInfo.Count > 0)          //  有子项才加入
                        {
                            this.ribbon.Items.Add(bsisubmenu);
                            bsimenu.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bsisubmenu));
                        }
                    }
                    else
                    {
                        //  是功能加入功能项
                        BarButtonItem bbi = new BarButtonItem();
                        bbi.Caption = title1;
                        bbi.Id = this.ribbon.Items.Count;
                        bbi.Name = "bbi" + code1;

                        if (!string.IsNullOrEmpty(menuList[pi].Prompt))
                        {
                            SuperToolTip stt = new SuperToolTip();
                            ToolTipItem tti = new ToolTipItem();
                            tti.Text = menuList[pi].Prompt;
                            stt.Items.Add(tti);
                            bbi.SuperTip = stt;
                        }

                        ico = menuList[pi].Ico; 
                        if (!ico.IsNullOrEmpty())		//  图标
                        {
                            bbi.RibbonStyle = RibbonItemStyles.Default;
                            if (ico.ToLower().EndsWith("svg"))
                                bbi.ImageOptions.SvgImage = BmpHelper.GetSvg(ico);
                            else
                                bbi.Glyph = BmpHelper.GetIco(ico);
                        }
                        bbi.Tag = ToFunction(menuList[pi]);

                        bbi.ItemClick += new ItemClickEventHandler(this.dynamic_bbi_ItemClick);
                        this.ribbon.Items.Add(bbi);
                        bsimenu.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi));
                    }
                }
                else
                {
                    pi--;
                    break;
                }
            }
            return bsimenu;
        }

        /// <summary>
        /// 功能项计数
        /// </summary>
        /// <param name="menu">菜单数据数组</param>
        /// <param name="pi">限定父编号</param>
        /// <returns>数目</returns>
        private int CountFunctionItem(List<DataMenu> menuList, int pi)
        {
            string pno = menuList[pi].Code;

            int num = 0;
            for (int i = pi; i < menuList.Count; i++)
            {
                string no = menuList[i].Code;
                if (no.Length < pno.Length) break;
                else
                {
                    if (pno == no.Substring(0, pno.Length) && !menuList[i].ObjectName.IsNullOrEmpty())
                    {
                        num++;
                    }
                }
            }
            return num;
        }

        private DataFunction ToFunction(DataMenu menu)
        {
            return new DataFunction(menu.Title, menu.ModuleName, menu.ObjectName, menu.Parameter, menu.WinState);

        }

        #endregion

        #endregion


        #region 菜单功能
        /// <summary>
        /// 点击菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dynamic_bbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataFunction df = e.Item.Tag as DataFunction;
            if (df != null)
            {
                this.Execute(df);
            }
        }

        /// <summary>
        ///  调用运行窗体
        ///  <param name="menu">菜单对象</param>
        /// </summary>
        public void Execute(DataFunction df)
        {
            bool exists = false;
            //判断是否存在已经打开的窗口(0：弹窗 1：新开 不需要判断)
            if (df.OpenFlag > 1)
            {
                //  检查是否已打开窗口
                foreach (Form child in this.MdiChildren)
                {
                    if (child.ProductName == df.ModuleName && child.GetType().Name == df.ObjectName)
                    {
                        FrmBase tempChild = child as FrmBase;
                        if (tempChild != null)
                        {
                            //  3: 不判断参数 或 2：判断参数但参数值相同时激活窗口
                            if (df.OpenFlag == 3 || tempChild.ControlParameter == df.Parameter)
                            {
                                child.Focus();
                                exists = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (!exists)
            {
                Execute(df.Title, df.ModuleName, df.ObjectName, df.Parameter, df.OpenFlag == 0);
            }

            return ;
        }

        /// <summary>
        ///  消息调用运行窗体
        ///  <param name="title">标题</param>
        ///  <param name="module">模块</param>
        ///  <param name="function">功能</param>
        ///  <param name="parameter">参数</param>
        ///  <param name="is_popup">是否弹出</param>
        /// </summary>
        private bool Execute(string title, string module, string function, string parameter, bool is_popup)
        {
            bool ok = false;
            FrmBase newform = null;

            DisplayHelper.Show(String.Format("正在创建{0}，请稍后...", title), "窗体加载中...");
            string module_dll = module;
            int index = module.IndexOf(",");
            if (index != -1)
            {
                module_dll = module.Substring(0, index);
            }
            try
            {
                Assembly theDll = Assembly.Load(module_dll);
                LogHelper.Info(this, "开始创建窗体" + module_dll + "." + function);
                newform = theDll.CreateInstance(module_dll + "." + function) as FrmBase;
                if (newform == null)
                {
                    string error = "调用运行库不成功！\r\n无法创建" + module + "模块的" + function + "窗体！";
                    LogHelper.Error(this, error);
                    MessageHelper.ShowError(error);
                }
                else
                {
                    LogHelper.Info(this, "窗体" + newform.Name + "|" + newform.ControlCode + "|" + newform.ControlName + "创建完成");

                    if (!string.IsNullOrEmpty(title))
                    {
                        newform.Text = title;
                    }

                    LogHelper.Info(this, "窗体" + newform.Name + "|" + newform.ControlCode + "|" + newform.ControlName + 
                        "开始初始化，本地时间为" + DateTime.Now);
                    newform.SetParameter(parameter);

                    if (newform.Init())
                    {
                        LogHelper.Info(this, "窗体" + newform.Name + "|" + newform.ControlCode + "|" + newform.ControlName + "初始化完成");
                        
                        if (is_popup)
                        {
                            DisplayHelper.Close();
                            newform.ShowDialog();
                        }
                        else
                        {
                            DisplayHelper.Show("正在加载子窗体信息,请稍后...", "正在加载...");
                            newform.MdiParent = this;
                            newform.Show();
                            DisplayHelper.Close();
                        }
                        ok = true;
                    }
                    else
                    {
                        LogHelper.Error(this, "窗体" + newform.Name + "|" + newform.ControlCode + "|" + newform.ControlName + "初始化失败");
                        newform.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "调用模块:" + module_dll + "\r\n对象:" + function + "\r\n参数：" + parameter ?? string.Empty +
                    "\r\n错误消息：" + ex.Message;

                msg += "\r\n异常跟踪:" + ex.StackTrace;
                if (ex.InnerException != null)
                {
                    msg += "\r\n异常消息：" + ex.InnerException.Message;
                    if (ex.InnerException is CustomException)
                    {
                        CustomException ce = (CustomException)ex.InnerException;
                        msg += "\r\n业务异常信息：" + ce.Info + "\r\n" + ce.InnerMessage;
                    }
                    MessageHelper.ShowError(msg);
                    msg += "\r\n异常栈:" + ex.InnerException.StackTrace;
                }
                else MessageHelper.ShowError(msg);

                LogHelper.Error(this, msg);
            }
            finally
            {
                DisplayHelper.Close();
            }
            return ok;
        }

        #endregion

        #region 辅助处理

        /// <summary>
        ///  系统切换
        /// </summary>
        private void bbiSystem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.MdiChildren.GetLength(0) > 0)
            {
                MessageHelper.ShowWarning("还有未关闭窗口，请关闭后再转换！");
                return;
            }

            LogHelper.Info(this, "切换系统 --- 关闭外部信息接口");
            infoRemoteAction.Close();

            LogHelper.Info(this, "切换系统 --- 关闭内部信息接口");
            infoLocalAction.Close();

            string code = e.Item.Tag.ToString();

            if(code == "OPC")
            {
                WindowsFormsSettings.DefaultFont = new Font(SystemFonts.DefaultFont.Name, 10);
            }
            else
            {
                WindowsFormsSettings.DefaultFont = new Font(SystemFonts.DefaultFont.Name, SystemFonts.DefaultFont.Size);
            }

            EmpInfo.SelectSystem(code);

            this.Init();
        }

        /// <summary>
        ///  辅助处理
        /// </summary>
        private void bbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            string item = e.Item.Tag.ToString();

            switch (item)
            {
                case "ABOUT":
                    FrmAbout aboutform = new FrmAbout();
                    aboutform.WindowState = FormWindowState.Normal;
                    aboutform.ShowDialog();
                    break;
                case "HELP":
                    string file = EnvInfo.RunPath + "Help\\index.html";
                    try
                    {
                        Help.ShowHelp(this, file);
                    }
                    catch
                    {
                        MessageHelper.ShowError("打开帮助文件不成功。");
                    }
                    break;
                case "CALC":                   //  计算器
                    Process pRunExeFile = new Process();
                    pRunExeFile.StartInfo.FileName = System.Environment.SystemDirectory + "\\calc.exe";
                    pRunExeFile.Start();
                    break;
                case "DFM":
                    FrmMenuDefault frmdfm = new FrmMenuDefault();
                    frmdfm.ShowDialog();
                    break;
                case "SQLH":
                    FrmSqlMonitor frmsh = new FrmSqlMonitor();
                    frmsh.MdiParent = this;
                    frmsh.Show();
                    break;
                case "PASSWORD":
                    FrmPassword frmpw = new FrmPassword();
                    frmpw.ShowDialog();
                    break;
                case "EXIT":
                    this.Close();
                    break;
                case "CLOSECHILD":
                    foreach (FrmBase frmmdi in this.MdiChildren)
                    {
                        frmmdi.Close();
                    }
                    break;
                case "RELOGIN":
                    if (this.MdiChildren.GetLength(0) > 0)
                    {
                        MessageHelper.ShowWarning("还有未关闭窗口，请关闭后再转换！");
                        return;
                    }

                    LogHelper.Info(this, "退出系统 --- 停止定时器");
                    this.timer1.Stop();

                    LogHelper.Info(this, "退出系统 --- 关闭外部信息接口");
                    infoRemoteAction.Close();

                    LogHelper.Info(this, "退出系统 --- 关闭内部信息接口");
                    infoLocalAction.Close();

                    EmpInfo.Logout();
                    LogHelper.Info(this, "退出系统完成");

                    //  打开登录窗口， 成功后刷新界面
                    FrmLogin frm_login = new FrmLogin();
                    frm_login.Text = this.Title;
                    if (frm_login.ShowDialog() == DialogResult.OK)
                    {
                        this.Init();
                    }
                    else
                    {
                        this.Close();
                    }
                    break;
                case "LOG0":
                    LogHelper._logLevel = 0;
                    this.bciLogNone.Checked = true;
                    this.bciLogError.Checked = false;
                    this.bciLogWarn.Checked = false;
                    this.bciLogDebug.Checked = false;
                    this.bciLogInfo.Checked = false;
                    break;
                case "LOG1":
                    LogHelper._logLevel = 1;
                    this.bciLogNone.Checked = false;
                    this.bciLogError.Checked = true;
                    this.bciLogWarn.Checked = false;
                    this.bciLogDebug.Checked = false;
                    this.bciLogInfo.Checked = false;
                    break;
                case "LOG2":
                    LogHelper._logLevel = 2;
                    this.bciLogNone.Checked = false;
                    this.bciLogError.Checked = false;
                    this.bciLogWarn.Checked = true;
                    this.bciLogDebug.Checked = false;
                    this.bciLogInfo.Checked = false;
                    break;
                case "LOG3":
                    LogHelper._logLevel = 3;
                    this.bciLogNone.Checked = false;
                    this.bciLogError.Checked = false;
                    this.bciLogWarn.Checked = false;
                    this.bciLogDebug.Checked = true;
                    this.bciLogInfo.Checked = false;
                    break;
                case "LOG4":
                    LogHelper._logLevel = 4;
                    this.bciLogNone.Checked = false;
                    this.bciLogError.Checked = false;
                    this.bciLogWarn.Checked = false;
                    this.bciLogDebug.Checked = false;
                    this.bciLogInfo.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 切换输入法
        /// </summary>
        private void bbiChangeChoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmInputCode frminput = new FrmInputCode();
            if (frminput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.bbiChangeChoice.Caption = (EmpInfo.InputChoice == "1") ? "首拼" : "五笔";

                List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
                parms.Add(new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()));
                parms.Add(new KeyValuePair<string, string>("parmName", "DEF_INPUT"));
                parms.Add(new KeyValuePair<string, string>("input", (EmpInfo.InputChoice == "1" ? 1 : 2).ToString()));
                // 设置默认输入法
                CustomException ce = null;
                HttpDataHelper.HttpPostFormUrlParamWithInfo("BASE", "/sys/parameteremp",out ce, parms);
            }
        }

        /// <summary>
        /// 换肤Gallery
        /// </summary>
        private void rgbiSkins_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            //  记录员工个人皮肤选项
            String newSkin = Convert.ToString(e.Item.Tag);
            List<KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
            parms.Add(new KeyValuePair<string, string>("empId", EmpInfo.Id.ToString()));
            parms.Add(new KeyValuePair<string, string>("parmName", "DEF_SKIN"));
            parms.Add(new KeyValuePair<string, string>("value", newSkin));
            CustomException ce = null;
            HttpDataHelper.HttpPostFormUrlParamWithInfo("BASE", "/sys/parameteremp", out ce, parms);
            MessageHelper.ShowInfo("已设置新皮肤： " + newSkin);
        }

        /// <summary>
        ///  ribbon 改变
        /// </summary>
        private void ribbon_MinimizedChanged(object sender, EventArgs e)
        {
            string val = this.ribbon.Minimized ? "1" : "0";
            //  TODO: 保存员工工具带条最小化的值

            //ServiceFactory.CreateService<ISysConfig>().SetEmpParameterValue
            //    (SystemInfo.Oper.Id, WinParameterHelper.SYS_MIN_RIBBON, val);
        }

        /// <summary>
        /// 判断是否退出
        /// </summary>
        private void FrmRibbonMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EmpInfo.Id <= 0)
            {
                e.Cancel = false;
                return;
            }

            var mdiFrm = this.MdiChildren;
            foreach (var frm in mdiFrm)
            {
                if (frm.DialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            DialogResult result = MessageHelper.ShowYesNoAndWarning("是否退出当前系统？");
            if (result == DialogResult.Yes)
            {
                LogHelper.Info(this, "退出系统 --- 关闭外部信息接口");
                infoRemoteAction.Close();

                LogHelper.Info(this, "退出系统 --- 关闭内部信息接口");
                infoLocalAction.Close();

                EmpInfo.Logout();
                timer1.Stop();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion


        #region 接收到信息的内部调用处理

        /// <summary>
        ///  异步信息回调函数，用于实现在主线程调用CallbackInfo函数。
        /// </summary>
        /// <param name="infoBody">信息内容</param>
        private void SynCallbackInfo(string infoCode, string infoBody)
        {
            if (this.InvokeRequired)
            {
                OnCallbackInfo m = new OnCallbackInfo(CallbackInfo);
                this.Invoke(m, new object[] { infoCode, infoBody });
            }
            else
            {
                CallbackInfo(infoCode, infoBody);
            }
        }

        /// <summary>
        ///  信息回调函数，实现接收信息后的相关处理。
        /// </summary>
        /// <param name="infoBody">信息内容</param>
        private void CallbackInfo(string infoCode, string infoBody)
        {
            switch (infoCode)
            {
                case LocalInfoHelper.OpenForm:  //  打开窗口
                    DataFunction df = infoBody.DeserializeObject<DataFunction>();
                    Execute(df);
                    break;
                case LocalInfoHelper.AddNotice: //  增加通知窗口
                    if(!this.dictNotice.ContainsKey(infoBody))
                    {
                        int idx = infoBody.IndexOf(";");
                        string module = infoBody.Substring(0, idx);
                        int idx1 = infoBody.IndexOf(";", idx + 1); 
                        string form = infoBody.Substring(idx + 1, idx1 - idx - 1);
                        string parameter = infoBody.Substring(idx1 + 1);

                        //  产生通知窗口
                        FrmNoticeBase frmAddNotice = this.CreateNotice(module, form, parameter);
                        this.dictNotice.Add(infoBody, frmAddNotice);

                        //  产生通知栏
                        this.CreateNoticeIco(frmAddNotice);
                    }
                    break;
                case LocalInfoHelper.DelNotice: //  撤销通知窗口
                    if (this.dictNotice.ContainsKey(infoBody))
                    {
                        FrmNoticeBase frmDelNotice = this.dictNotice[infoBody];
                        frmDelNotice.Stop();

                        BarButtonItem bbi = (BarButtonItem)frmDelNotice.Tag;
                        if(bbi != null)
                        {
                            this.ribbon.Items.Remove((BarButtonItem)frmDelNotice.Tag);  //  已验证：this.ribbonStatusBar.ItemLinks下也同时移除
                            bbi = null;
                        }
                        frmDelNotice = null;
                        this.dictNotice.Remove(infoBody);
                    }
                    break;

            }

        }

        /// <summary>
        ///  动态产生通知窗口
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <param name="function">窗口名称</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        private FrmNoticeBase CreateNotice(string module, string function, string parameter)
        {
            FrmNoticeBase newform = null;

            try
            {
                Assembly theDll = Assembly.Load(module);
                LogHelper.Info(this, "开始创建通知窗口" + module + "." + function);
                newform = theDll.CreateInstance(module + "." + function) as FrmNoticeBase;
                if (newform == null)
                {
                    string error = "调用运行库不成功！\r\n无法创建" + module + "模块的" + function + "通知窗体！";
                    LogHelper.Error(this, error);
                }
                else
                {
                    LogHelper.Info(this, "通知窗体" + module + "." + function + "|" + parameter + "创建完成");
                    newform.Init(parameter);
                    LogHelper.Info(this, "通知窗体" + module + "." + function + "|" + parameter + "初始化完成");
                }
            }
            catch (Exception ex)
            {
                string msg = "调用模块:" + module + "\r\n对象:" + function + "\r\n参数：" + parameter ?? string.Empty +
                    "\r\n错误消息：" + ex.Message + "\r\n异常跟踪:" + ex.StackTrace;
                if (ex.InnerException != null)
                {
                    msg += "\r\n异常消息：" + ex.InnerException.Message + "\r\n异常错误:" + ex.InnerException.StackTrace;
                }
                LogHelper.Error(this, msg);
            }
            return newform;
        }

        /// <summary>
        ///  产生状态栏的通知项
        /// </summary>
        /// <param name="frm">通知窗口</param>
        private void CreateNoticeIco(FrmNoticeBase frm)
        {
            BarButtonItem bbi = new BarButtonItem();
            //  TODO:
            bbi.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            bbi.Caption = frm.NoticeCount.ToString();
            bbi.Glyph = frm.IcoImage;
            bbi.Hint = frm.IcoHint;

            bbi.Id = this.ribbon.Items.Count ;
            bbi.ItemAppearance.Normal.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            bbi.ItemAppearance.Normal.ForeColor = frm.IcoColor;
            bbi.ItemAppearance.Normal.Options.UseFont = true;
            bbi.ItemAppearance.Normal.Options.UseForeColor = true;
            bbi.Name = "barItemNotice" + bbi.Id.ToString();
            bbi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            this.ribbon.Items.Add(bbi);
            this.ribbonStatusBar.ItemLinks.Add(bbi);
            frm.Tag = bbi;
            bbi.Tag = frm;

            //  通知数量改变时调整图标数量
            frm.OnNoticeCountChanged += (Sender, e) =>
            {
                bbi.Caption = frm.NoticeCount.ToString();
                //  有通知时自动打开的通知窗口处理
                if (frm.AutoOpen && !frm.Visible)
                {
                    frm.ShowDialog();
                }
            };
            
            //  通知图标双击时弹出窗口
            bbi.ItemDoubleClick += (sender, e) =>
            {
                FrmNoticeBase frm_notice = (FrmNoticeBase)e.Item.Tag;
                frm_notice.ShowDialog();
            };
        }


        /*?
                private void ExecuteCall()
                {
                    if (!this.IsHandleCreated)
                        return;
                    lock (CallFunctionList.ReciveData)
                    {
                        //  将等待数据移到接收数据队列
                        lock (CallFunctionList.WaitData)
                        {
                            while (CallFunctionList.WaitData.Count > 0)
                            {
                                CallFunction info = CallFunctionList.WaitData.Dequeue();
                                CallFunctionList.ReciveData.Enqueue(info);
                            }
                        }

                        //  接收数据队列执行对应功能
                        while (CallFunctionList.ReciveData.Count > 0)
                        {
                            try
                            {
                                CallFunction info = CallFunctionList.ReciveData.Dequeue();
                                DataFunction fi = info.Info;
                                switch (info.Code)
                                {
                                    case "Display Title":          //  显示标题
                                        //  不同的控件新建
                                        if ((fi.ModuleName + "." + fi.FunctionName) != UCTitleControl.GetType().FullName)
                                        {
                                            string strDllFile = SystemInfo.Environment.RunPath + fi.ModuleName + ".dll";
                                            System.Reflection.Assembly theDll = System.Reflection.Assembly.LoadFrom(strDllFile);
                                            this.UCTitleControl = (UCTitleControlBase)theDll.CreateInstance
                                                (fi.ModuleName + "." + fi.FunctionName);
                                            this.dockPanelTitle.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                                            this.dockPanelTitle.Height = this.UCTitleControl.Height + 1;
                                            this.dockPanel2_Container.Controls.Add(this.UCTitleControl);
                                            this.UCTitleControl.Dock = System.Windows.Forms.DockStyle.Top;
                                        }
                                        this.dockPanelTitle.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                                        this.UCTitleControl.Init(fi.FunctionParameter);
                                        break;
                                    case "Close Title":           // 关闭标题
                                        //不同的控件新建
                                        if ((fi.ModuleName + "." + fi.FunctionName) == UCTitleControl.GetType().FullName)
                                        {
                                            this.dockPanelTitle.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                                        }
                                        break;
                                    case "Display Message":      //  显示其他信息在状态栏中
                                        this.bsiOther.Caption = fi.FunctionParameter;
                                        break;
                                    default:                     //  其他(与主窗口的界面无关)
                                        MainHelper.ExecuteMessage(info);
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageDialog.ShowError(ex.Message);
                            }
                        }
                    }
                }
        */
        #endregion
    }
}
