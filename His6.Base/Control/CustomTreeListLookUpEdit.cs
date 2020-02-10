using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace His6.Base
{
    [ToolboxItem(true)]
    public class CustomTreeListLookUpEdit: TreeListLookUpEdit
    {
        static CustomTreeListLookUpEdit()
        {
            RepositoryItemCustomTreeListLookUpEdit.Register();
        }

        public CustomTreeListLookUpEdit():base()
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
        public override string EditorTypeName => RepositoryItemCustomTreeListLookUpEdit.editorTypeName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomTreeListLookUpEdit Properties => base.Properties as RepositoryItemCustomTreeListLookUpEdit;
    }
    [UserRepositoryItem("Register")]
   public class RepositoryItemCustomTreeListLookUpEdit : RepositoryItemTreeListLookUpEdit
    {
       internal const string editorTypeName = "CustomTreeListLookUpEdit";

       static RepositoryItemCustomTreeListLookUpEdit()
       {
           RepositoryItemCustomTreeListLookUpEdit.Register();
       }

       public static void Register()
       {
           //this.CreateDefaultButton();
           EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(editorTypeName, typeof(CustomTreeListLookUpEdit), typeof(RepositoryItemCustomTreeListLookUpEdit),
               typeof(TreeListLookUpEditBaseViewInfo), new ButtonEditPainter(), true));

       }

       public RepositoryItemCustomTreeListLookUpEdit() : base()
       {
           //Buttons.Add(new EditorButton(ButtonPredefines.Delete));
           Buttons.Add(new EditorButton(ButtonPredefines.Clear));
           Buttons.Add(new EditorButton(ButtonPredefines.Combo));
       }

       public override string EditorTypeName => editorTypeName;
   }
}
