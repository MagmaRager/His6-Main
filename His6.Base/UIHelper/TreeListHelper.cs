using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraTreeList.Nodes;

namespace His6.Base
{
    /// <summary>
    ///  TreeList加工处理类
    /// </summary>
    public static class TreeListHelper
    {
        /// <summary>
        /// 便利方式：
        /// 0：深度优先
        /// 1：广度优先
        /// </summary>
        public enum IterateMode
        {
            /// <summary>
            /// 深度
            /// </summary>
            Depth = 0,
            /// <summary>
            /// 广度
            /// </summary>
            Breadth
        }

        #region 文件导出

        /// <summary>
        ///  TreeList导出
        /// </summary>
        /// <param name="tl">TreeList控件</param>
        /// <param name="path">默认路径</param>
        public static void ExportTo(TreeList tl, string path)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "选择导出文件";
            saveFileDialog1.InitialDirectory = path;
            saveFileDialog1.Filter = "网页文件(*.HTML)|*.HTML|文本文件(*.TXT)|*.TXT|EXCEL(*.XLS)|*.XLS|PDF(*.PDF)|*.PDF";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;

                if (filename.IndexOf(".HTML") > 0)
                {
                    tl.ExportToHtml(filename);
                }

                if (filename.IndexOf(".TXT") > 0)
                {
                    tl.ExportToText(filename);
                }

                if (filename.IndexOf(".XLS") > 0)
                {
                    tl.ExportToXls(filename);
                }

                if (filename.IndexOf(".PDF") > 0)
                {
                    tl.ExportToPdf(filename);
                }

                OpenFile(filename);
            }
        }

        /// <summary>
        ///  文件打开
        /// </summary>
        /// <param name="fileName">文件名</param>
        private static void OpenFile(string fileName)
        {
            if (MessageHelper.ShowYesNoAndQuestion("是否打开文件？") == DialogResult.Yes)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("不能找到打开该文件的系统。\r\n" + ex.Message);
                }
            }
        }

        #endregion

        //  TODO: 以下内容未整理
        
        /*
        #region 右击菜单项控制

        /// <summary>
        ///  限定列选择
        /// </summary>
        /// <param name="tl">TreeList对象</param>
        /// <param name="columnCenter">列标题是否居中(默认true)</param>
        public static void SetNoChoiceColumn(TreeList tl, bool columnCenter = true)
        {
            //tl.PopupMenuShowing += new PopupMenuShowingEventHandler(NoChoiceColumn);
            //  选择列处理
            for (int i = 0; i < tl.Columns.Count; i++)
            {
                if (columnCenter)
                {
                    tl.Columns[i].AppearanceHeader.Options.UseTextOptions = true;
                    tl.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                //tl.Columns[i].OptionsColumn.AllowMoveToCustomizationForm = false;
            }
        }

        private static void NoChoiceColumn(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.MenuType == TreeListMenuType.Column)
            {
                DXMenuItem mi_column = GetItemByStringId(e.Menu, TreeListStringId.MenuColumnColumnCustomization);
                if (mi_column != null)
                {
                    mi_column.Visible = false;
                }
            }
        }

        private static DXMenuItem GetItemByStringId(DXPopupMenu menu, TreeListStringId id)
        {
            foreach (DXMenuItem item in menu.Items)
            {
                if (item.Caption == TreeListLocalizer.Active.GetLocalizedString(id))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置树形控件右键菜单
        /// </summary>
        /// <param name="_tlBase"></param>
        /// <param name="showMenu"></param>
        public static void SetMenu(TreeList _tlBase, bool showMenu)
        {
            _tlBase.OptionsMenu.EnableColumnMenu = _tlBase.OptionsMenu.EnableFooterMenu = showMenu;
        }

        #endregion

        #region 布局选择有关

        /// <summary>
        ///  设置布局菜单
        /// </summary>
        /// <param name="code">对象代码</param>
        /// <param name="tl">TreeList对象</param>
        public static void SetLayout(string code, TreeList tl)
        {
            TreeListLayoutMenu menu = new TreeListLayoutMenu();
            menu.Init(code, tl);
            tl.ContextMenuStrip = menu;
        }

        /// <summary>
        /// 设置TreeList中的列是否只读,如果需要某几列特殊处理,根据allowEditList中设置的为准,键为列对应的FieldName,值是否允许编辑
        /// </summary>
        /// <param name="isReadonly"></param>
        /// <param name="tlBase"></param>
        /// <param name="allowEditList">键为列对应的FieldName,值是否允许编辑</param>
        public static void SetReadOnly(bool isReadonly, TreeList tlBase, Dictionary<string, bool> allowEditList = null)
        {
            if (tlBase == null)
            {
                return;
            }

            foreach (TreeListColumn tlColumn in tlBase.Columns)
            {
                if (allowEditList != null && allowEditList.ContainsKey(tlColumn.FieldName))
                {
                    tlColumn.OptionsColumn.AllowEdit = tlColumn.OptionsColumn.AllowFocus = allowEditList[tlColumn.FieldName];
                }
                else
                {
                    tlColumn.OptionsColumn.AllowEdit = tlColumn.OptionsColumn.AllowFocus = !isReadonly;
                }
            }
        }
        #endregion

        #region 验证TreeList数据有效性方法
        /// <summary>
        /// 验证TreeList上数据的有效性
        ///  [ 验证的标志，都需在Tag中设置，多个标志间用逗号分隔，
        /// 如需验证该列不可为空加notnull,
        /// 验证该列不可重复加notrepeat，
        /// 验证该列的数值可以为负数加canminus(默认数值型的不可为负数),
        /// 限制该列长度，则需在最后面加长度数，
        /// 限制数值的小数位数，需在长度后面加点号.再加小数位数
        /// 限制数值型为0的列是否算是空，默认为false不算是空，
        /// 改AllowIncrementalSearch为false才认为数值型为0的值算是空值
        /// (此时前面的长度减去小数位数才是可输入的最大整数位数)
        /// 如notnull,notrepeat,canminus,8.2表示
        /// 该列不可为空，值不可重复，可以为负数，
        /// 且整数最大为6位，小数最大为2位 ]
        /// </summary>
        /// <param name="tlBase"></param>
        /// <param name="data">需验证的数据信息,
        /// 可为bindingSource,IList,DataTable,DataRow,DataRowView,Entity等</param>
        /// <returns></returns>
        public static bool ValidateRow(TreeList tlBase, object data)
        {
            if (data == null)
            {
                return true;
            }
            if (tlBase.HasColumnErrors)
            {
                tlBase.ClearColumnErrors();
            }
            //如果是bindingSource数据源时
            if (data is BindingSource)
            {
                BindingSource bsData = data as BindingSource;
                if (bsData.DataSource is DataTable)
                {
                    return ValidateRow(tlBase, bsData.DataSource as DataTable);
                }
            }
            //如果是DataTable数据源时
            if (data is DataTable)
            {
                DataTable dtData = data as DataTable;
                foreach (DataRow drData in dtData.Rows)
                {
                    if (!ValidateRow(tlBase, drData))
                    {
                        return false;
                    }
                }
                return true;
            }
            //如果是IList集合数据源时
            if (data is IList)
            {
                IList list = data as IList;
                foreach (var entity in list)
                {
                    if (entity is DataRowView)
                    {
                        if (!ValidateData(tlBase, (entity as DataRowView).Row))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            //如果是DataRowView数据行信息时
            if (data is DataRowView)
            {
                return ValidateData(tlBase, (data as DataRowView).Row);
            }
            //如果是DataRow数据行时
            if (data is DataRow)
            {
                return ValidateData(tlBase, data as DataRow);
            }
            return true;
        }

        #region 验证实体信息数据是否有效

        /// <summary>
        /// 验证DataRow数据行是否有效
        /// </summary>
        /// <param name="tlBase">gridView视图</param>
        /// <param name="drData">DataRow数据信息</param>
        /// <returns>返回true验证通过，返回false验证失败</returns>
        static bool ValidateData(TreeList tlBase, DataRow drData)
        {
            try
            {
                if (tlBase == null || drData == null || drData.RowState == DataRowState.Deleted)
                {
                    return true;
                }

                DataTable dt;//TreeList绑定的DataTable数据源
                int dataIndex;//数据源中的索引
                TreeListColumn tlc = null;//TreeList列变量
                object value;//对应数据列值
                string description;//显示的描述文本
                string tag;//TreeListColumn列的Tag值
                BindingSource bs = tlBase.DataSource as BindingSource;

                if (bs == null)
                {
                    if (tlBase.DataSource is DataView)
                    {
                        dt = (tlBase.DataSource as DataView).Table;
                    }
                    else
                    {
                        dt = tlBase.DataSource as DataTable;
                    }
                }
                else
                {
                    dt = bs.DataSource as DataTable;
                }

                if (dt == null)
                {
                    return false;
                }

                dataIndex = dt.Rows.IndexOf(drData);
                foreach (DataRow dr_old in dt.Rows)
                {
                    if (dr_old.RowState == DataRowState.Deleted)
                    {
                        dataIndex--;
                    }
                    if (dr_old == drData)
                    {
                        break;
                    }
                }

                foreach (DataColumn dataColumn in drData.Table.Columns)
                {
                    //获取列对应的值
                    value = drData[dataColumn.ColumnName];

                    //获取对应的GridColumn列信息
                    tlc = tlBase.Columns.ColumnByFieldName(dataColumn.ColumnName);
                    //列信息为null或该列不可编辑时不需验证
                    if (tlc == null || !tlc.OptionsColumn.AllowEdit || tlc.VisibleIndex == -1)
                    {
                        continue;
                    }

                    //值不可为空时
                    if (!dataColumn.AllowDBNull && tlc.OptionsColumn.AllowEdit &&
                        (value == DBNull.Value || value == null ||
                        (!tlc.AllowIncrementalSearch && (dataColumn.DataType == typeof(decimal) ||
                        dataColumn.DataType == typeof(int) || dataColumn.DataType == typeof(long) ||
                        dataColumn.DataType == typeof(float) || dataColumn.DataType == typeof(double) ||
                        dataColumn.DataType == typeof(short)) && Convert.ToInt32(value) == 0)))
                    {
                        SetTreeListColumnError(tlBase, tlc, dataIndex, String.Format("{0} 不可为空！", tlc.Caption), ErrorType.Default);
                        return false;
                    }

                    //获取设置的Tag值
                    tag = Convert.ToString(tlc.Tag).ToLower();

                    //是否可为负数，如果找不到该标志且为数值类型，则只可以为正数
                    if (tag.IndexOf("canminus") == -1 &&
                        (dataColumn.DataType == typeof(decimal) || dataColumn.DataType == typeof(decimal?) ||
                            dataColumn.DataType == typeof(int) || dataColumn.DataType == typeof(int?) ||
                            dataColumn.DataType == typeof(long) || dataColumn.DataType == typeof(long?) ||
                            dataColumn.DataType == typeof(float) || dataColumn.DataType == typeof(float?) ||
                            dataColumn.DataType == typeof(double) || dataColumn.DataType == typeof(double?) ||
                            dataColumn.DataType == typeof(short) || dataColumn.DataType == typeof(short?)))
                    {
                        double num = 0;
                        if (value != DBNull.Value && !double.TryParse(Convert.ToString(value), out num))
                        {
                            SetTreeListColumnError(tlBase, tlc, dataIndex, String.Format("{0} 不是有效数值！", tlc.Caption), ErrorType.Warning);
                            return false;
                        }
                        if (num < 0)
                        {
                            SetTreeListColumnError(tlBase, tlc, dataIndex, String.Format("{0} 不能为负数！", tlc.Caption), ErrorType.Warning);
                            return false;
                        }
                    }
                    //Tag值为null时则继续
                    if (string.IsNullOrEmpty(tag))
                    {
                        continue;
                    }
                    //如果该列有替换列是RepositoryItemImageComboBox时特殊处理
                    if (tlc.ColumnEdit is RepositoryItemImageComboBox)
                    {
                        if (value == null || value == DBNull.Value)
                        {
                            description = null;
                        }
                        else
                        {
                            ImageComboBoxItem icbiItem = (tlc.ColumnEdit as RepositoryItemImageComboBox).Items.GetItem(value);
                            if (icbiItem != null)
                            {
                                description = icbiItem.Description.Trim();
                            }
                            else
                            {
                                description = value == DBNull.Value ? string.Empty : Convert.ToString(value).Trim();
                            }
                        }
                    }
                    else
                    {
                        description = value == DBNull.Value ? string.Empty : Convert.ToString(value).Trim();
                    }

                    //非空验证(存在tag值时是否有notnull字符串)
                    if (tag.IndexOf("notnull") != -1 && string.IsNullOrEmpty(description))
                    {
                        SetTreeListColumnError(tlBase, tlc, dataIndex, String.Format("{0} 不可为空！", tlc.Caption), ErrorType.Default);
                        return false;
                    }
                    //不可重复验证
                    if (tag.IndexOf("notrepeat") != -1)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            //如果是删除状态，或是自己本身，或是隐藏列时不比较
                            if (item.RowState == DataRowState.Deleted ||
                                drData.GetHashCode() == item.GetHashCode() ||
                                tlc.VisibleIndex == -1)
                            {
                                continue;
                            }
                            else if (Convert.ToString(value).Trim() == Convert.ToString(item[dataColumn.ColumnName]).Trim())
                            {
                                SetTreeListColumnError(tlBase, tlc, dataIndex, String.Format("{0} 不可重复！", tlc.Caption), ErrorType.Warning);
                                return false;
                            }
                        }
                    }

                    //实际输入的字节长度
                    int byteLength = Encoding.Default.GetByteCount(Convert.ToString(value));
                    int limitLength;//整数长度限制
                    int scaleLength = 0;//小数精度限制
                    //数据值对应的字符串, 如8.2表示整数位数最多是8-2=6位,小数位数最多是2位
                    string[] str_array = tag.Substring(tag.LastIndexOf(',') + 1).Trim().Split('.');
                    if (!int.TryParse(str_array[0], out limitLength))
                    {
                        limitLength = 0;
                    }
                    if (str_array.Length == 2 && !int.TryParse(str_array[1], out scaleLength))
                    {
                        scaleLength = 0;
                    }
                    //设置最大长度不可超过DataTable自带的长度
                    if (limitLength > dataColumn.MaxLength && dataColumn.MaxLength > 0)
                    {
                        limitLength = dataColumn.MaxLength;
                    }
                    //验证长度
                    if ((limitLength > 0 && dataColumn.DataType == typeof(string))
                        || (limitLength > 0 && scaleLength == 0 &&
                        (dataColumn.DataType == typeof(decimal) || dataColumn.DataType == typeof(float) ||
                        dataColumn.DataType == typeof(double) || dataColumn.DataType == typeof(short) ||
                        dataColumn.DataType == typeof(int) || dataColumn.DataType == typeof(long))))
                    {
                        if (byteLength > limitLength)
                        {//长度限制
                            SetTreeListColumnError(tlBase, tlc, dataIndex, String.Format("{0} 长度不能超过{1}！",
                                tlc.Caption, limitLength), ErrorType.Information);
                            return false;
                        }
                    }
                    else if ((dataColumn.DataType == typeof(decimal) || dataColumn.DataType == typeof(float) ||
                        dataColumn.DataType == typeof(double) || dataColumn.DataType == typeof(short) ||
                        dataColumn.DataType == typeof(int) || dataColumn.DataType == typeof(long)) &&
                        limitLength > 0 && scaleLength > 0)
                    {//有小数位
                        string inputString = Convert.ToString(value).Trim();
                        string[] lengths = inputString.Split('.');
                        if (lengths.Length > 0 && lengths[0].Length > limitLength - scaleLength)
                        {
                            SetTreeListColumnError(tlBase, tlc, dataIndex, String.Format("{0} 整位数不能超过{1}！",
                                tlc.Caption, limitLength - scaleLength), ErrorType.Information);
                            return false;
                        }
                        else if (lengths.Length == 2 && lengths[1].Length > scaleLength)
                        {
                            SetTreeListColumnError(tlBase, tlc, dataIndex, String.Format("{0} 小数位数不能超过{1}！",
                                tlc.Caption, scaleLength), ErrorType.Information);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex.Message);
            }
            return true;
        }

        /// <summary>
        /// 设置GridColumn错误信息方法
        /// </summary>
        /// <param name="tlBase">GridView视力控件</param>
        /// <param name="tlc">TreeList列</param>
        /// <param name="dataIndex">数据集中的索引(不是界面上排序后看到的索引)</param>
        /// <param name="errorType">错误类型</param>
        /// <param name="errorText">错误文本信息</param>
        static void SetTreeListColumnError(TreeList tlBase, TreeListColumn tlc, int dataIndex, string errorText, ErrorType errorType)
        {
            tlBase.FocusedNode = tlBase.GetNodeByVisibleIndex(dataIndex);
            tlBase.FocusedColumn = tlc;
            tlBase.SetColumnError(tlc, errorText, errorType);
        }
        #endregion

        #endregion

        #region 数据源为空时显示无数据字样
        /// <summary>
        /// TreeList数据源为空时显示无数据字样
        /// </summary>
        /// <param name="tl"></param>
        /// <param name="e"></param>
        /// <param name="displayText">要显示的中文</param>
        public static void DrawEmptyForeground(TreeList tl, CustomDrawEmptyAreaEventArgs e, string displayText = null)
        {
            if (tl.VisibleNodesCount != 0)
            {
                return;
            }
            DataTable dataSource = tl.DataSource as DataTable;
            if (string.IsNullOrEmpty(displayText))
            {
                if (dataSource == null)
                {
                    IList list = tl.DataSource as IList;
                    if (list == null || list.Count == 0)//数据源为空
                    {
                        displayText = "无数据";
                    }
                    else
                    {
                        displayText = "过滤后无数据";
                    }
                }
                else if (dataSource.Rows.Count == 0)
                {
                    displayText = "无数据";
                }
                else
                {
                    displayText = "过滤后无数据";
                }
            }

            Font font = new Font("Tahoma", 20, FontStyle.Bold);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;
            RectangleF r = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.DrawString(displayText, font, SystemBrushes.ControlDark, r, drawFormat);
            e.Handled = true;
        }
        #endregion

        #region 其他扩展方法
        #region 取树所有节点
        /// <summary>
        /// 以默认方式(深度优先)遍历获得树的所有节点
        /// </summary>
        /// <param name="treeList">待遍历的树</param>
        /// <returns>TreeListNodes节点集合</returns>
        public static TreeListNodes GetAllNodes(this TreeList treeList)
        {
            return treeList.GetAllNodes(IterateMode.Depth);
        }

        /// <summary>
        /// 以指定的遍历方式遍历获得树的所有节点
        /// </summary>
        /// <param name="treeList">待遍历的树</param>
        /// <param name="iterateMode">便利方式，枚举</param>
        /// <returns>TreeListNodes节点集合</returns>
        public static TreeListNodes GetAllNodes(this TreeList treeList, IterateMode iterateMode)
        {
            TreeListNodes nodes = new TreeListNodes(treeList);
            treeList.OperateAllNodes(node => nodes.Add(node), iterateMode);
            return nodes;
        }

        /// <summary>
        /// 以默认方式(深度优先)遍历获得树的所有节点
        /// </summary>
        /// <param name="treeList">待遍历的树</param>
        /// <returns>节点集合</returns>
        public static List<TreeListNode> GetAllNodeList(this TreeList treeList)
        {
            return treeList.GetAllNodeList(IterateMode.Depth);
        }

        /// <summary>
        /// 以指定的遍历方式遍历获得树的所有节点
        /// </summary>
        /// <param name="treeList">待遍历的树</param>
        /// <param name="iterateMode">便利方式，枚举</param>
        /// <returns>节点集合</returns>
        public static List<TreeListNode> GetAllNodeList(this TreeList treeList, IterateMode iterateMode)
        {
            List<TreeListNode> nodes = new List<TreeListNode>();
            treeList.OperateAllNodes(node => nodes.Add(node), iterateMode);
            return nodes;
        }
        #endregion

        #region 取根节点中的所有节点
        /// <summary>
        /// 以默认方式(深度优先)遍历获得节点的所有节点
        /// </summary>
        /// <param name="root">根节点</param>
        /// <returns>TreeListNodes节点集合</returns>
        public static TreeListNodes GetAllNodes(this TreeListNode root)
        {
            return root.GetAllNodes(IterateMode.Depth);
        }

        /// <summary>
        /// 以指定的遍历方式遍历获得节点的所有节点
        /// </summary>
        /// <param name="root">根节点</param>
        /// <param name="iterateMode">遍历方式</param>
        /// <returns>TreeListNodes节点集合</returns>
        public static TreeListNodes GetAllNodes(this TreeListNode root, IterateMode iterateMode)
        {
            TreeListNodes nodes = new TreeListNodes(root.TreeList);
            root.OperateAllNodes(node => nodes.Add(node), iterateMode);
            return nodes;
        }

        /// <summary>
        /// 以默认方式(深度优先)遍历获得节点的所有节点
        /// </summary>
        /// <param name="root">根节点</param>
        /// <returns>TreeListNodes节点集合</returns>
        public static List<TreeListNode> GetAllNodeList(this TreeListNode root)
        {
            return root.GetAllNodeList(IterateMode.Depth);
        }

        /// <summary>
        /// 以指定的遍历方式遍历获得节点的所有节点
        /// </summary>
        /// <param name="root">根节点</param>
        /// <param name="iterateMode">遍历方式</param>
        /// <returns>TreeListNodes节点集合</returns>
        public static List<TreeListNode> GetAllNodeList(this TreeListNode root, IterateMode iterateMode)
        {
            List<TreeListNode> nodes = new List<TreeListNode>();
            root.OperateAllNodes(node => nodes.Add(node), iterateMode);
            return nodes;
        }
        #endregion

        #region 按条件查找树
        /// <summary>
        /// 以默认遍历方式(深度优先)查询符合条件的节点
        /// </summary>
        /// <param name="treeList">待查询的树</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>符合条件的TreeListNodes集合</returns>
        public static TreeListNodes FindNodes(this TreeList treeList, Func<TreeListNode, bool> predicate)
        {
            return treeList.FindNodes(predicate, IterateMode.Depth);
        }

        /// <summary>
        /// 以指定遍历方式查询符合条件的节点
        /// </summary>
        /// <param name="treeList">待查询的树</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="iterateMode">遍历条件</param>
        /// <returns>符合条件的TreeListNodes集合</returns>
        public static TreeListNodes FindNodes(this TreeList treeList, Func<TreeListNode, bool> predicate, IterateMode iterateMode)
        {
            if (treeList == null)
                throw new ArgumentException("treeList");
            if (predicate == null)
                throw new ArgumentException("predicate");

            TreeListNodes nodes = new TreeListNodes(treeList);
            treeList.OperateAllNodes(node =>
            {
                if (predicate(node))
                    nodes.Add(node);
            }, iterateMode);
            return nodes;
        }
        #endregion

        #region 按条件查找节点
        /// <summary>
        /// 以默认遍历方式(深度优先)查询符合条件的节点
        /// </summary>
        /// <param name="root">待查找的节点</param>
        /// <param name="predicate">查找条件</param>
        /// <returns>符合条件的TreeListNodes集合</returns>
        public static TreeListNodes FindNodes(this TreeListNode root, Func<TreeListNode, bool> predicate)
        {
            return root.FindNodes(predicate, IterateMode.Depth);
        }

        /// <summary>
        /// 以指定遍历方式查询符合条件的节点
        /// </summary>
        /// <param name="root">待查询的树</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="iterateMode">遍历条件</param>
        /// <returns>符合条件的TreeListNodes集合</returns>
        public static TreeListNodes FindNodes(this TreeListNode root, Func<TreeListNode, bool> predicate, IterateMode iterateMode)
        {
            if (root == null)
                throw new ArgumentException("root");
            if (predicate == null)
                throw new ArgumentException("predicate");

            TreeListNodes nodes = new TreeListNodes(root.TreeList);
            root.OperateAllNodes(node =>
            {
                if (predicate(node))
                    nodes.Add(node);
            }, iterateMode);
            return nodes;
        }
        #endregion

        #region 判断树中是否存在节点
        /// <summary>
        /// 判断树中是否存在某个条件的节点(深度优先)
        /// </summary>
        /// <param name="treeList">待查找的树</param>
        /// <param name="predicate">判断条件</param>
        /// <returns>是否存在</returns>
        public static bool ExistsNode(this TreeList treeList, Func<TreeListNode, bool> predicate)
        {
            return treeList.ExistsNode(predicate, IterateMode.Depth);
        }

        /// <summary>
        /// 以指定遍历方式和判断条件判断树中是否存在某个条件的节点
        /// </summary>
        /// <param name="treeList">待查找的树</param>
        /// <param name="predicate">判断条件</param>
        /// <param name="iterateMode">遍历方式</param>
        /// <returns>是否存在</returns>
        public static bool ExistsNode(this TreeList treeList, Func<TreeListNode, bool> predicate, IterateMode iterateMode)
        {
            bool isExist = false;
            treeList.OperateAllNodes(node =>
            {
                if (predicate(node))
                {
                    isExist = true;
                }
            }, iterateMode);
            return isExist;
        }
        #endregion

        #region 判断节点中是否存在节点
        /// <summary>
        /// 判断树中是否存在某个条件的节点(深度优先)
        /// </summary>
        /// <param name="root">带查找的根节点</param>
        /// <param name="predicate">判断条件</param>
        /// <returns>是否存在</returns>
        public static bool ExistsNode(this TreeListNode root, Func<TreeListNode, bool> predicate)
        {
            return root.ExistsNode(predicate, IterateMode.Depth);
        }

        /// <summary>
        /// 以指定遍历方式和判断条件判断节点中是否存在某个条件的节点
        /// </summary>
        /// <param name="root">带查找的根节点</param>
        /// <param name="predicate">判断条件</param>
        /// <param name="iterateMode">遍历方式</param>
        /// <returns>是否存在</returns>
        public static bool ExistsNode(this TreeListNode root, Func<TreeListNode, bool> predicate, IterateMode iterateMode)
        {
            bool isExist = false;
            root.OperateAllNodes(node =>
            {
                if (predicate(node))
                {
                    isExist = true;
                }
            }, iterateMode);
            return isExist;
        }
        #endregion

        #region 对树的通用处理
        /// <summary>
        /// 以默认遍历方式(深度优先)、指定处理方式,处理树的所有节点
        /// </summary>
        /// <param name="treeList">待处理的树</param>
        /// <param name="operate">处理方式,外部委托函数</param>
        public static void OperateAllNodes(this TreeList treeList, Action<TreeListNode> operate)
        {
            treeList.OperateAllNodes(operate, IterateMode.Depth);
        }

        /// <summary>
        /// 以指定的遍历方式、处理方式,处理树的所有节点
        /// </summary>
        /// <param name="treeList">待处理的树</param>
        /// <param name="operate">处理方式,外部委托函数</param>
        /// <param name="iterateMode">遍历方式</param>
        public static void OperateAllNodes(this TreeList treeList, Action<TreeListNode> operate, IterateMode iterateMode)
        {
            if (treeList == null)
                throw new ArgumentNullException("treeList");
            if (operate == null)
                throw new ArgumentNullException("operate");

            if (iterateMode == IterateMode.Depth)
            {
                foreach (TreeListNode node in treeList.Nodes)
                {
                    OperateAllNodesWithDepth(node, operate);
                }
            }
            else
            {
                Queue<TreeListNode> nodeQueue = new Queue<TreeListNode>();
                foreach (TreeListNode node in treeList.Nodes)
                {
                    nodeQueue.Enqueue(node);
                }
                OperateAllNodesWithBreadth(nodeQueue, operate);
            }
        }
        #endregion

        #region 对节点的通用处理(含算法)
        /// <summary>
        /// 以默认遍历方式(深度优先)对节点及其子节点进行处理
        /// </summary>
        /// <param name="root">待处理的根节点</param>
        /// <param name="operate">处理方式，外部委托函数</param>
        public static void OperateAllNodes(this TreeListNode root, Action<TreeListNode> operate)
        {
            root.OperateAllNodes(operate, IterateMode.Depth);
        }

        /// <summary>
        /// 以指定遍历方式对节点及其子节点进行处理
        /// </summary>
        /// <param name="root">待处理的根节点</param>
        /// <param name="operate"></param>
        /// <param name="iterateMode">处理方式，外部委托函数</param>
        public static void OperateAllNodes(this TreeListNode root, Action<TreeListNode> operate, IterateMode iterateMode)
        {
            if (iterateMode == IterateMode.Depth)
            {
                root.OperateAllNodesWithDepth(operate);
            }
            else
            {
                root.OperateAllNodesWithBreadth(operate);
            }
        }

        /// <summary>
        /// 以深度优先遍历，指定的处理方式处理节点以及其子节点
        /// </summary>
        /// <param name="root">待处理的根节点</param>
        /// <param name="operate">处理方式</param>
        private static void OperateAllNodesWithDepth(this TreeListNode root, Action<TreeListNode> operate)
        {
            if (root == null)
                throw new ArgumentNullException("root");
            if (operate == null)
                throw new ArgumentNullException("operate");

            operate(root);
            if (root.HasChildren)
            {
                foreach (TreeListNode node in root.Nodes)
                {
                    OperateAllNodesWithDepth(node, operate);
                }
            }
        }

        /// <summary>
        /// 以广度优先遍历，指定的处理方式处理节点以及其子节点
        /// </summary>
        /// <param name="root">待处理的根节点</param>
        /// <param name="operate">处理方式</param>
        private static void OperateAllNodesWithBreadth(this TreeListNode root, Action<TreeListNode> operate)
        {
            if (root == null)
                throw new ArgumentNullException("root");
            if (operate == null)
                throw new ArgumentNullException("operate");

            Queue<TreeListNode> nodeQueue = new Queue<TreeListNode>();
            nodeQueue.Enqueue(root);
            OperateAllNodesWithBreadth(nodeQueue, operate);
        }

        /// <summary>
        /// 广度优先的方式遍历并处理节点
        /// </summary>
        /// <param name="nodeQueue">待遍历的节点队列</param>
        /// <param name="operate">处理方式，外部委托函数</param>
        private static void OperateAllNodesWithBreadth(Queue<TreeListNode> nodeQueue, Action<TreeListNode> operate)
        {
            TreeListNode node = null;
            if (nodeQueue.Count > 0)
            {
                node = nodeQueue.Dequeue();
            }
            else
                return;

            operate(node);
            if (node.HasChildren)
            {
                foreach (TreeListNode child in node.Nodes)
                {
                    nodeQueue.Enqueue(child);
                }
            }
            OperateAllNodesWithBreadth(nodeQueue, operate);
        }
        #endregion

        #region foreach使用(广度优先遍历)：foreach (TreeListNode node in treeList1.GetEnumerableNodes()){ ... }
        /// <summary>
        /// 遍历方法
        /// </summary>
        /// <param name="treeList"></param>
        /// <returns></returns>
        public static EnumerableNodes GetEnumerableNodes(this TreeList treeList)
        {
            if (treeList == null)
                throw new ArgumentNullException("treeList");
            return new EnumerableNodes(treeList);
        }
        #endregion
        #endregion

        #region 节点选择相关方法
        /// <summary>
        /// 设置父节点是否选中
        /// </summary>
        /// <param name="node"></param>
        public static void SetParentCheckNode(TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                foreach (TreeListNode childNode in node.ParentNode.Nodes)
                {
                    if (!childNode.Checked)
                    {
                        node.ParentNode.CheckState = CheckState.Indeterminate;
                        SetAllParentCheckNode(node.ParentNode);
                        return;
                    }
                }
                node.ParentNode.CheckState = CheckState.Checked;
                SetParentCheckNode(node.ParentNode);
            }
        }

        /// <summary>
        /// 设置所有的父节点为半选状态
        /// </summary>
        /// <param name="node"></param>
        public static void SetAllParentCheckNode(TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                node.ParentNode.CheckState = CheckState.Indeterminate;
                SetAllParentCheckNode(node.ParentNode);
            }
        }

        /// <summary>
        /// 获取所有子孙节点状态的递归方法
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="sbChecked"></param>
        /// <param name="tlcColumn"></param>
        public static void GetCheckNode(TreeListNode parentNode, StringBuilder sbChecked, TreeListColumn tlcColumn)
        {
            if (parentNode.Checked)
            {
                sbChecked.Append("," + parentNode.GetValue(tlcColumn));
            }
            foreach (TreeListNode node in parentNode.Nodes)
            {
                if (node.Checked)
                {
                    sbChecked.Append("," + node.GetValue(tlcColumn));
                }
                GetCheckNode(node, sbChecked, tlcColumn);
            }
        }
        #endregion
        */
    }

    /*
    #region 遍历类
    /// <summary>
    /// 遍历类
    /// </summary>
    public class EnumerableNodes : IEnumerable<TreeListNode>
    {
        TreeList treeList;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="treeList"></param>
        public EnumerableNodes(TreeList treeList)
        {
            this.treeList = treeList;
        }

        #region IEnumerable<TreeListNode> 接口实现
        /// <summary>
        /// 遍历方法
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TreeListNode> GetEnumerator()
        {
            if (this.treeList == null)
                throw new ArgumentNullException("treeList");
            return new TreeListNodesEnumerator(this.treeList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region 枚举器

        private sealed class TreeListNodesEnumerator : IEnumerator<TreeListNode>
        {
            TreeList treeList;
            TreeListNode currentNode;
            Queue<TreeListNode> nodeQueue;

            public TreeListNodesEnumerator(TreeList treeList)
            {
                this.treeList = treeList;
                if (treeList.HasChildren)
                {
                    this.nodeQueue = new Queue<TreeListNode>();
                    foreach (TreeListNode node in this.treeList.Nodes)
                    {
                        nodeQueue.Enqueue(node);
                    }
                }
            }

            #region IEnumerator<TreeListNode>实现
            public TreeListNode Current
            {
                get
                {
                    if (this.currentNode == null)
                        throw new Exception("无效的枚举器");
                    return this.currentNode;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public bool MoveNext()
            {
                TreeListNode currentNode = this.currentNode;
                if (nodeQueue == null)
                {
                    return false;
                }
                else if (currentNode == null)
                {
                    this.currentNode = nodeQueue.Dequeue();
                    return true;
                }

                if (currentNode.HasChildren)
                {
                    foreach (TreeListNode node in currentNode.Nodes)
                    {
                        nodeQueue.Enqueue(node);
                    }
                }

                if (nodeQueue.Count > 0)
                {
                    this.currentNode = nodeQueue.Dequeue();
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                this.currentNode = null;
                this.nodeQueue.Clear();
                if (treeList.HasChildren)
                {
                    this.nodeQueue = new Queue<TreeListNode>();
                    foreach (TreeListNode node in this.treeList.Nodes)
                    {
                        nodeQueue.Enqueue(node);
                    }
                }
            }

            public void Dispose()
            {
            }
            #endregion
        }
        #endregion
    }
    #endregion
    */
}
