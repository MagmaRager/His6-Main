using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace His6.Base
{
    public class CustomGridView : GridView
    {
        public CustomGridView() : base() { }

        protected internal virtual void SetGridControlAccessMetod(GridControl newControl)
        {
            SetGridControl(newControl);
        }

        /// <summary>
        /// 是否过滤隐藏列，true：过滤
        /// </summary>
        //[Browsable(true)]
        //[Category("Options")]
        //[DefaultValue(false)]
        //public bool IsFilterNoVisable { get; set; }
        ///// <summary>
        ///// 是否只过滤string 类型数据 true :是
        ///// </summary>
        //[Browsable(true)]
        //[Category("Options")]
        //[DefaultValue(false)]
        public bool IsFilterStr { get; set; }

        protected override string OnCreateLookupDisplayFilter(string text, string displayMember)
        {
            List<CriteriaOperator> subStringOperators = new List<CriteriaOperator>();
            foreach (string item in text.Split(' '))
            {
                List<CriteriaOperator> columnsOperators = new List<CriteriaOperator>();
                foreach (GridColumn col in Columns)
                {
                    //if (!col.Visible && !IsFilterNoVisable)
                    //{
                    //    continue;
                    //}

                    //if (col.ColumnType != typeof(string)&& IsFilterStr)
                    //{
                    //    continue;
                    //}

                    columnsOperators.Add(new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty(col.FieldName), item));
                }

                subStringOperators.Add(new GroupOperator(GroupOperatorType.Or, columnsOperators));
            }

            return new GroupOperator(GroupOperatorType.And, subStringOperators).ToString();
        }

        protected override string ViewName { get { return "CustomGridView"; } }
        protected virtual internal string GetExtraFilterText => ExtraFilterText;
    }

    public class CustomGridControl : GridControl
    {
        public CustomGridControl() : base() { }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomGridInfoRegistrator());
        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView("CustomGridView");
        }

    }

    public class CustomGridPainter : GridPainter
    {
        public CustomGridPainter(GridView view) : base(view) { }

        public virtual new CustomGridView View => (CustomGridView)base.View;

        protected override void DrawRowCell(GridViewDrawArgs e, GridCellInfo cell)
        {
            cell.ViewInfo.MatchedStringUseContains = true;
            cell.ViewInfo.MatchedString = View.GetExtraFilterText;
            cell.State = GridRowCellState.Dirty;
            e.ViewInfo.UpdateCellAppearance(cell);
            base.DrawRowCell(e, cell);
        }
    }

    public class CustomGridInfoRegistrator : GridInfoRegistrator
    {
        public CustomGridInfoRegistrator() : base() { }
        public override BaseViewPainter CreatePainter(BaseView view) { return new CustomGridPainter(view as DevExpress.XtraGrid.Views.Grid.GridView); }
        public override string ViewName => "CustomGridView";

        public override BaseView CreateView(GridControl grid)
        {
            CustomGridView view = new CustomGridView();
            view.SetGridControlAccessMetod(grid);
            return view;
        }

    }
}
