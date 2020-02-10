using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace His6.Base
{
    [ToolboxItem(true)]
    public class CustomLookUpEdit : LookUpEdit
    {
        static CustomLookUpEdit()
        {
            RepositoryItemCustomLookUpEdit.Register();
        }

        public CustomLookUpEdit() : base()
        {
            this.Properties.ButtonClick += Properties_ButtonClick;
            this.Properties.ActionButtonIndex = 1;
            this.Properties.AutoHeight = false;
            this.Properties.NullText = null;
            this.Height = 30;
        }

        private void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Clear&&!this.ReadOnly)
            {
                base.EditValue = null;
            }
        }

        public override string EditorTypeName => RepositoryItemCustomLookUpEdit.editorTypeName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomLookUpEdit Properties => base.Properties as RepositoryItemCustomLookUpEdit;
    }

    [UserRepositoryItem("Register")]
    public class RepositoryItemCustomLookUpEdit : RepositoryItemLookUpEdit
    {
        internal const string editorTypeName = "CustomLookUpEdit";

        static RepositoryItemCustomLookUpEdit()
        {
            RepositoryItemCustomLookUpEdit.Register();
        }

        public static void Register()
        {
            //this.CreateDefaultButton();
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(editorTypeName, typeof(CustomLookUpEdit), typeof(RepositoryItemCustomLookUpEdit),
                typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }

        public RepositoryItemCustomLookUpEdit() : base()
        {
            //Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            Buttons.Add(new EditorButton(ButtonPredefines.Clear));
            Buttons.Add(new EditorButton(ButtonPredefines.Combo));
        }

        public override string EditorTypeName => editorTypeName;
    }
}
