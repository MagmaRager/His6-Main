using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Helpers;
using DevExpress.XtraGrid.Views.Base;

namespace His6.Base
{
    public class CustomGridLookUpEdit : GridLookUpEdit
    {
        static CustomGridLookUpEdit() { RepositoryItemCustomGridLookUpEdit.RegisterCustomGridLookUpEdit(); }

        public CustomGridLookUpEdit() : base()
        {
            this.Properties.ButtonClick += Properties_ButtonClick;
            this.Properties.ActionButtonIndex = 1;
        }

        private void Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Clear && !this.ReadOnly)
            {
                base.EditValue = null;
            }
        }
        public override string EditorTypeName => RepositoryItemCustomGridLookUpEdit.CustomGridLookUpEditName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomGridLookUpEdit Properties => base.Properties as RepositoryItemCustomGridLookUpEdit;
    }
    [UserRepositoryItem("RegisterCustomGridLookUpEdit")]
    public class RepositoryItemCustomGridLookUpEdit : RepositoryItemGridLookUpEdit
    {
        static RepositoryItemCustomGridLookUpEdit() { RegisterCustomGridLookUpEdit(); }

        public RepositoryItemCustomGridLookUpEdit()
        {
            Buttons.Add(new EditorButton(ButtonPredefines.Clear));
            Buttons.Add(new EditorButton(ButtonPredefines.Combo));
            TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            PopupFilterMode = PopupFilterMode.Contains;
            AutoComplete =false;
        }


        [Browsable(false)]
        public override DevExpress.XtraEditors.Controls.TextEditStyles TextEditStyle { get => base.TextEditStyle;
            set => base.TextEditStyle = value;
        }
        public const string CustomGridLookUpEditName = "CustomGridLookUpEdit";

        public override string EditorTypeName => CustomGridLookUpEditName;

        public static void RegisterCustomGridLookUpEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomGridLookUpEditName,
                typeof(CustomGridLookUpEdit), typeof(RepositoryItemCustomGridLookUpEdit),
                typeof(GridLookUpEditBaseViewInfo), new ButtonEditPainter(), true));
        }
        protected override ColumnView CreateViewInstance() { return new CustomGridView(); }
        protected override GridControl CreateGrid() { return new CustomGridControl(); }
    }
}
