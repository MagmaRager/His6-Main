using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace His6.Base
{
    /// <summary>
    ///  Grid加工处理类
    /// </summary>
    public class GridHelper
    {
        #region 导出有关

        /// <summary>
        ///  Grid导出
        /// </summary>
        /// <param name="gc">GridControl控件</param>
        /// <param name="path">默认路径</param>
        public static void ExportTo(GridView gv, string path)
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
                    gv.ExportToHtml(filename);
                }

                if (filename.IndexOf(".TXT") > 0)
                {
                    gv.ExportToText(filename);
                }

                if (filename.IndexOf(".XLS") > 0)
                {
                    gv.ExportToXls(filename);
                }

                if (filename.IndexOf(".PDF") > 0)
                {
                    gv.ExportToPdf(filename);
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
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
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

        /*  以下未验证
         
        #region 限定过滤、分组、选列等属性

        /// <summary>
        ///  限定过滤、分组、选列
        /// </summary>
        /// <param name="gv">GridView对象</param>
        /// <param name="noFilter">去除过滤</param>
        /// <param name="noGroup">去除分组</param>
        /// <param name="noChoiceColumn">去除选列</param>
        /// <param name="columnCenter">列标题居中显示(默认为true)</param>
        public static void SetProperty(GridView gv, bool noFilter, bool noGroup, bool noChoiceColumn, bool columnCenter = true)
        {
            if (noFilter)
            {
                SetNoFilter(gv);
            }
            if (noGroup)
            {
                SetNoGroup(gv);
            }
            if (noChoiceColumn)
            {
                SetNoChoiceColumn(gv, columnCenter);
            }
        }

        /// <summary>
        ///  去除过滤
        /// </summary>
        /// <param name="gv">GridView对象</param>
        public static void SetNoFilter(GridView gv)
        {
            gv.OptionsCustomization.AllowFilter = false;
        }

        /// <summary>
        ///  去除分组设置（包括菜单）
        /// </summary>
        /// <param name="gv">GridView对象</param>
        public static void SetNoGroup(GridView gv)
        {
            gv.PopupMenuShowing += new PopupMenuShowingEventHandler(gv_NoGroup);
            gv.OptionsCustomization.AllowGroup = false;
            gv.OptionsView.ShowGroupPanel = false;
        }

        /// <summary>
        ///  限定列选择
        /// </summary>
        /// <param name="gv">GridView对象</param>
        /// <param name="columnCenter">列标题是否居中，默认是true</param>
        public static void SetNoChoiceColumn(GridView gv, bool columnCenter = true)
        {
            gv.OptionsCustomization.AllowQuickHideColumns = false;
            //  选择列处理
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                if (columnCenter)
                {
                    gv.Columns[i].AppearanceHeader.Options.UseTextOptions = true;
                    gv.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }
        }

        /// <summary>
        ///  限定下拉列选择有关项
        /// </summary>
        private static void gv_NoChoiceColumn(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                DXMenuItem mi_column = GetItemByStringId(e.Menu, GridStringId.MenuColumnBestFit);
                mi_column = GetItemByStringId(e.Menu, GridStringId.MenuColumnColumnCustomization);
                if (mi_column != null)
                {
                    mi_column.Visible = false;
                }

                mi_column = GetItemByStringId(e.Menu, GridStringId.MenuColumnRemoveColumn);
                if (mi_column != null)
                {
                    mi_column.Visible = false;
                }
            }
        }
        /// <summary>
        /// 不可分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void gv_NoGroup(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                // Show Group By Box
                DXMenuItem miGroup = GetItemByStringId(e.Menu, GridStringId.MenuGroupPanelShow);
                if (miGroup != null)
                {
                    miGroup.Visible = false;
                }

                miGroup = GetItemByStringId(e.Menu, GridStringId.MenuColumnGroup);
                if (miGroup != null)
                {
                    miGroup.Visible = false;
                }

                miGroup = GetItemByStringId(e.Menu, GridStringId.MenuColumnBandCustomization);
                if (miGroup != null)
                {
                    miGroup.Visible = false;
                }

                miGroup = GetItemByStringId(e.Menu, GridStringId.MenuColumnFilterMode);
                if (miGroup != null)
                {
                    miGroup.Visible = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static DXMenuItem GetItemByStringId(DXPopupMenu menu, GridStringId id)
        {
            foreach (DXMenuItem item in menu.Items)
            {
                if (item.Caption == GridLocalizer.Active.GetLocalizedString(id))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置Grid控件是否显示右键菜单
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="showMenu">是否显示右键菜单</param>
        public static void SetMenu(GridView gv, bool showMenu)
        {
            if (gv != null)
            {
                gv.OptionsMenu.EnableColumnMenu = gv.OptionsMenu.EnableFooterMenu =
                    gv.OptionsMenu.EnableGroupPanelMenu = showMenu;
            }
        }

        #endregion

        #region 布局选择有关

        /// <summary>
        ///  设置布局菜单
        /// </summary>
        /// <param name="code">对象代码</param>
        /// <param name="gv">gridview对象</param>
        public static void SetLayout(string code, GridView gv)
        {
            GridLayoutMenu menu = new GridLayoutMenu();
            menu.Init(code, gv);
            gv.GridControl.ContextMenuStrip = menu;
        }
        #endregion

        #region 设置GridView中列是否只读
        /// <summary>
        /// 设置GridView中的列是否只读,如果需要某几列特殊处理,根据allowEditList中设置的为准,键为列对应的FieldName,值是否允许编辑
        /// </summary>
        /// <param name="isReadonly">是否只读，不可编辑</param>
        /// <param name="gvBase">GridView视图控件</param>
        /// <param name="allowEditList">键为列对应的FieldName,值是否允许编辑</param>
        public static void SetReadOnly(bool isReadonly, GridView gvBase, Dictionary<string, bool> allowEditList = null)
        {
            if (gvBase == null)
            {
                return;
            }

            foreach (GridColumn gridColumn in gvBase.Columns)
            {
                if (allowEditList != null && allowEditList.ContainsKey(gridColumn.FieldName))
                {
                    gridColumn.OptionsColumn.AllowEdit = gridColumn.OptionsColumn.AllowFocus = allowEditList[gridColumn.FieldName];
                }
                else
                {
                    gridColumn.OptionsColumn.AllowEdit = gridColumn.OptionsColumn.AllowFocus = !isReadonly;
                }
            }
        }
        #endregion

        #region 验证GridView数据有效性方法

        /// <summary>
        /// 验证GridView上数据的有效性
        ///  [ 验证的标志，都需在Tag中设置，多个标志间用逗号分隔，
        /// 如需验证该列不可为空加notnull,
        /// 验证该列不可重复加notrepeat，
        /// 验证该列的数值可以为负数加canminus(默认数值型的不可为负数),
        /// 限制该列长度，则需在最后面加长度数，
        /// 限制数值的小数位数，需在长度后面加点号.再加小数位数
        /// 限制数值型为0的列是否算是空，默认为false不算是空，
        /// 改ShowUnboundExpressionMenu为true才认为数值型为0的值算是空值
        /// (此时前面的长度减去小数位数才是可输入的最大整数位数)
        /// 如notnull,notrepeat,canminus,8.2表示
        /// 该列不可为空，值不可重复，可以为负数，
        /// 且整数最大为6位，小数最大为2位 ]
        /// </summary>
        /// <param name="gvBase"></param>
        /// <param name="data">需验证的数据信息,
        /// 可为bindingSource,IList,DataTable,DataRow,DataRowView,Entity等</param>
        /// <returns></returns>
        public static bool ValidateRow(GridView gvBase, object data)
        {
            if (data == null)
            {
                return true;
            }
            if (gvBase.HasColumnErrors)
            {
                gvBase.ClearColumnErrors();
            }
            //如果是bindingSource数据源时
            if (data is BindingSource)
            {
                BindingSource bsData = data as BindingSource;
                if (bsData.DataSource is DataTable)
                {
                    return ValidateRow(gvBase, bsData.DataSource as DataTable);
                }
            }
            //如果是DataTable数据源时
            if (data is DataTable)
            {
                DataTable dtData = data as DataTable;
                foreach (DataRow drData in dtData.Rows)
                {
                    if (!ValidateRow(gvBase, drData))
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
                        if (!ValidateData(gvBase, (entity as DataRowView).Row))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!ValidateData(gvBase, entity))
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
                return ValidateData(gvBase, (data as DataRowView).Row);
            }
            //如果是DataRow数据行时
            if (data is DataRow)
            {
                return ValidateData(gvBase, data as DataRow);
            }
            return true;
        }

        /// <summary>
        /// 验证实体信息Entity是否有效
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gvBase"></param>
        /// <param name="entity">实体信息</param>
        /// <returns></returns>
        static bool ValidateData<T>(GridView gvBase, T entity)
        {
            try
            {
                if (gvBase == null || entity == null)
                {
                    return true;
                }

                IList list = gvBase.GridControl.DataSource as BindingSource;//获取GridControl数据源
                PropertyInfo[] propertys = entity.GetType().GetProperties();//该实体对象属性组
                GridColumn gc;//Grid列变量
                object value;//对应属性值
                object[] attrs;//特性数组
                int dataIndex;//数据集中索引
                string description;//显示的描述文本
                ColumnAttribute attr;//自定义特性
                string tag;//GridColumn的Tag值

                if (list == null)
                {
                    list = gvBase.GridControl.DataSource as IList;
                    if (list == null)
                    {
                        return false;
                    }
                }
                //获取数据源中的索引
                dataIndex = list.IndexOf(entity);

                foreach (PropertyInfo property in propertys)
                {
                    //获取自定义特性
                    attrs = property.GetCustomAttributes(typeof(ColumnAttribute), false);
                    if (attrs == null || attrs.Length == 0)
                    {
                        attr = null;
                    }
                    else
                    {
                        attr = attrs[0] as ColumnAttribute;//自定义属性
                    }

                    //获取属性对应的值
                    value = property.GetValue(entity, null);
                    //获取对应的GridColumn列
                    gc = gvBase.Columns.ColumnByFieldName(property.Name);
                    //列信息为null或它的Tag值为null或该列不可编辑时不需验证
                    if (gc == null || !gc.OptionsColumn.AllowEdit || gc.VisibleIndex == -1)
                    {
                        continue;
                    }
                    //实际输入的字节长度
                    int byteLength = Encoding.Default.GetByteCount(Convert.ToString(value));

                    #region 根据列特性先验证一些数据有效性
                    //特性不为空时，先验证一些可判断的条件
                    if (attr != null)
                    {
                        //如果特性限制不可为空时
                        if (attr.NotNull && gc.OptionsColumn.AllowEdit &&
                            (value == null || value.ToString().Trim() == string.Empty ||
                            (gc.ShowUnboundExpressionMenu &&
                                (attr.DBType == DbType.Decimal || attr.DBType == DbType.Int32 || attr.DBType == DbType.Int64 ||
                                attr.DBType == DbType.Int16 || attr.DBType == DbType.Single || attr.DBType == DbType.Double)
                                 && Convert.ToInt32(value) == 0)))
                        {
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不可为空！", gc.Caption), ErrorType.Default);
                            return false;
                        }
                        //验证长度
                        if (attr.DBType == DbType.String || ((attr.DBType == DbType.Decimal ||
                            attr.DBType == DbType.Single || attr.DBType == DbType.Double) && attr.Scale == 0) ||
                            attr.DBType == DbType.Int32 || attr.DBType == DbType.Int64 || attr.DBType == DbType.Int16)
                        {
                            if (byteLength > attr.Length)
                            {//长度限制
                                SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 长度不能超过{1}！",
                                    gc.Caption, attr.Length), ErrorType.Information);
                                return false;
                            }
                        }
                        //验证小数位数
                        if ((attr.DBType == DbType.Decimal || attr.DBType == DbType.Single ||
                            attr.DBType == DbType.Double) && attr.Length > 0 && attr.Scale > 0)
                        {//有小数位
                            string inputString = Convert.ToString(value).Trim();
                            string[] lengths = inputString.Split('.');
                            if (lengths.Length > 0 && lengths[0].Length > attr.Length - attr.Scale)
                            {
                                SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 整位数不能超过{1}！",
                                    gc.Caption, attr.Length - attr.Scale), ErrorType.Information);
                                return false;
                            }
                            else if (lengths.Length == 2 && lengths[1].Length > attr.Scale)
                            {
                                SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 小数位数不能超过{1}！",
                                    gc.Caption, attr.Scale), ErrorType.Information);
                                return false;
                            }
                        }
                    }
                    #endregion


                    //获取设置的Tag值
                    tag = Convert.ToString(gc.Tag).ToLower();

                    //是否可为负数，如果找不到该标志且是数值类型，则只可以为正数
                    if (tag.IndexOf("canminus") == -1 &&
                        (property.PropertyType == typeof(decimal?) || property.PropertyType == typeof(decimal) ||
                             property.PropertyType == typeof(int?) || property.PropertyType == typeof(int) ||
                             property.PropertyType == typeof(long?) || property.PropertyType == typeof(long) ||
                             property.PropertyType == typeof(float?) || property.PropertyType == typeof(float) ||
                             property.PropertyType == typeof(double?) || property.PropertyType == typeof(double) ||
                             property.PropertyType == typeof(short?) || property.PropertyType == typeof(short)))
                    {
                        double num = 0;
                        if (value != null && !double.TryParse(Convert.ToString(value), out num))
                        {
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不是有效数值！", gc.Caption), ErrorType.Warning);
                            return false;
                        }
                        if (num < 0)
                        {
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不能为负数！", gc.Caption), ErrorType.Warning);
                            return false;
                        }
                    }
                    //Tag值为空，则继续
                    if (string.IsNullOrEmpty(tag))
                    {
                        continue;
                    }

                    if (gc.ColumnEdit is RepositoryItemImageComboBox)
                    {//如果该列有替换列，类型是RepositoryItemImageComboBox时特殊处理
                        if (value == null)
                        {
                            description = null;
                        }
                        else
                        {
                            ImageComboBoxItem icbiItem = (gc.ColumnEdit as RepositoryItemImageComboBox).Items.GetItem(value);
                            if (icbiItem != null)
                            {
                                description = icbiItem.Description.Trim();
                            }
                            else
                            {
                                description = Convert.ToString(value).Trim();
                            }
                        }
                    }
                    else
                    {
                        description = Convert.ToString(value).Trim();
                    }

                    //非空验证
                    if (tag.IndexOf("notnull") != -1 && string.IsNullOrEmpty(description))
                    {
                        SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不可为空！", gc.Caption), ErrorType.Default);
                        return false;
                    }

                    //不可重复验证
                    if ((tag.IndexOf("notrepeat") != -1))
                    {
                        foreach (var item in list)
                        {
                            //值为null或等于本身或是隐藏列时不比较
                            if (entity.GetHashCode() == item.GetHashCode() || property.GetValue(item, null) == null ||
                                value == null || gc.VisibleIndex == -1)
                            {
                                continue;
                            }//需判断改造
                            else if (Convert.ToString(property.GetValue(item, null)).Trim() == Convert.ToString(value).Trim())
                            {
                                SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不可重复！", gc.Caption), ErrorType.Warning);
                                return false;
                            }
                        }
                    }

                    //数据值对应的字符串, 如8.2表示整数位数最多是8-2=6位,小数位数最多是2位
                    string[] str_array = tag.Substring(tag.LastIndexOf(',') + 1).Trim().Split('.');
                    int limitLength;//整数长度限制
                    int scaleLength = 0;//小数精度限制

                    if (!int.TryParse(str_array[0], out limitLength))
                    {
                        limitLength = 0;
                    }
                    if (str_array.Length == 2 && !int.TryParse(str_array[1], out scaleLength))
                    {
                        scaleLength = 0;
                    }
                    //验证长度
                    if (limitLength > 0 && scaleLength == 0 && byteLength > limitLength)
                    {//长度限制
                        SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 长度不能超过{1}！",
                            gc.Caption, limitLength), ErrorType.Information);
                        return false;
                    }
                    else if (limitLength > 0 && scaleLength > 0)
                    {
                        //有小数位
                        string inputString = Convert.ToString(value).Trim();
                        string[] lengths = inputString.Split('.');
                        if (lengths.Length > 0 && lengths[0].Length > limitLength - scaleLength)
                        {
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 整位数不能超过{1}！",
                                gc.Caption, limitLength - scaleLength), ErrorType.Information);
                            return false;
                        }
                        else if (lengths.Length == 2 && lengths[1].Length > scaleLength)
                        {
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 小数位数不能超过{1}！",
                                gc.Caption, scaleLength), ErrorType.Information);
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

        #region 验证实体信息数据是否有效

        /// <summary>
        /// 验证DataRow数据行是否有效
        /// </summary>
        /// <param name="gvBase">gridView视图</param>
        /// <param name="drData">DataRow数据信息</param>
        /// <returns>返回true验证通过，返回false验证失败</returns>
        static bool ValidateData(GridView gvBase, DataRow drData)
        {
            try
            {
                if (gvBase == null || drData == null || drData.RowState == DataRowState.Deleted)
                {
                    return true;
                }

                DataTable dt;//GridControl绑定的DataTable数据源
                int dataIndex;//数据源中的索引
                GridColumn gc = null;//Grid列变量
                object value;//对应数据列值
                string description;//显示的描述文本
                string tag;//gridColumn列的Tag值
                BindingSource bs = gvBase.GridControl.DataSource as BindingSource;

                if (bs == null)
                {
                    if (gvBase.GridControl.DataSource is DataView)
                    {
                        dt = (gvBase.GridControl.DataSource as DataView).Table;
                    }
                    else
                    {
                        dt = gvBase.GridControl.DataSource as DataTable;
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
                    gc = gvBase.Columns.ColumnByFieldName(dataColumn.ColumnName);
                    //列信息为null或该列不可编辑时不需验证
                    if (gc == null || !gc.OptionsColumn.AllowEdit || gc.VisibleIndex == -1)
                    {
                        continue;
                    }

                    //值不可为空时
                    if (!dataColumn.AllowDBNull && gc.OptionsColumn.AllowEdit &&
                        (value == DBNull.Value || value == null || (gc.ShowUnboundExpressionMenu &&
                              (dataColumn.DataType == typeof(decimal) || dataColumn.DataType == typeof(int) ||
                              dataColumn.DataType == typeof(long) || dataColumn.DataType == typeof(float) ||
                              dataColumn.DataType == typeof(double) || dataColumn.DataType == typeof(short)) &&
                              Convert.ToInt32(value) == 0)))
                    {
                        SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不可为空！", gc.Caption), ErrorType.Default);
                        return false;
                    }

                    //获取设置的Tag值
                    tag = Convert.ToString(gc.Tag).ToLower();

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
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不是有效数值！", gc.Caption), ErrorType.Warning);
                            return false;
                        }
                        if (num < 0)
                        {
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不能为负数！", gc.Caption), ErrorType.Warning);
                            return false;
                        }
                    }

                    //如果该列有替换列是RepositoryItemImageComboBox时特殊处理
                    if (gc.ColumnEdit is RepositoryItemImageComboBox)
                    {
                        if (value == null || value == DBNull.Value)
                        {
                            description = null;
                        }
                        else
                        {
                            ImageComboBoxItem icbiItem = (gc.ColumnEdit as RepositoryItemImageComboBox).Items.GetItem(value);
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
                    //else if (gc.ColumnEdit is RepositoryItemCheckEdit)
                    //{
                    //    RepositoryItemCheckEdit repositoryCheck = gc.ColumnEdit as RepositoryItemCheckEdit;
                    //    DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
                    //    //DevExpress.XtraEditors.BaseCheckEdit checkItem = gc.ColumnEdit as DevExpress.XtraEditors.BaseCheckEdit;
                    //    info.EditValue =(short) value;
                    //    description = "";
                    //}
                    else
                    {
                        description = value == DBNull.Value ? string.Empty : Convert.ToString(value).Trim();
                    }
                    //Tag值为null时则继续
                    if (string.IsNullOrEmpty(tag))
                    {
                        continue;
                    }
                    //非空验证(存在tag值时是否有notnull字符串)
                    if (tag.IndexOf("notnull") != -1 && string.IsNullOrEmpty(description))
                    {
                        SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不可为空！", gc.Caption), ErrorType.Default);
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
                                gc.VisibleIndex == -1)
                            {
                                continue;
                            }
                            else if (Convert.ToString(value).Trim() == Convert.ToString(item[dataColumn.ColumnName]).Trim())
                            {
                                SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 不可重复！", gc.Caption), ErrorType.Warning);
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
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 长度不能超过{1}！",
                                gc.Caption, limitLength), ErrorType.Information);
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
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 整位数不能超过{1}！",
                                gc.Caption, limitLength - scaleLength), ErrorType.Information);
                            return false;
                        }
                        else if (lengths.Length == 2 && lengths[1].Length > scaleLength)
                        {
                            SetGridColumnError(gvBase, gc, dataIndex, String.Format("{0} 小数位数不能超过{1}！",
                                gc.Caption, scaleLength), ErrorType.Information);
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
        /// <param name="gvBase">GridView视力控件</param>
        /// <param name="gc">Grid列</param>
        /// <param name="dataIndex">数据集中的索引(不是界面上排序后看到的索引)</param>
        /// <param name="errorType">错误类型</param>
        /// <param name="errorText">错误文本信息</param>
        static void SetGridColumnError(GridView gvBase, GridColumn gc, int dataIndex, string errorText, ErrorType errorType)
        {
            gvBase.FocusedRowHandle = gvBase.GetRowHandle(dataIndex);
            gvBase.FocusedColumn = gc;
            gvBase.SetColumnError(gc, errorText, errorType);
        }
        #endregion

        #endregion

        #region 数据源为空时显示无数据字样
        /// <summary>
        /// Grid数据源为空时显示无数据字样
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="e"></param>
        /// <param name="displayText">要显示的中文</param>
        public static void DrawEmptyForeground(GridView gv, CustomDrawEventArgs e, string displayText = null)
        {
            if (gv.RowCount != 0)
            {
                return;
            }

            DataView dataSource = gv.DataSource as DataView;
            if (string.IsNullOrEmpty(displayText))
            {
                if (dataSource == null)
                {
                    IList list = gv.DataSource as IList;
                    if (list == null || list.Count == 0)//数据源为空
                    {
                        displayText = "无数据";
                    }
                    else
                    {
                        displayText = "过滤后无数据";
                    }
                }
                else if (dataSource.Count == 0)
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
    */
    }
}
