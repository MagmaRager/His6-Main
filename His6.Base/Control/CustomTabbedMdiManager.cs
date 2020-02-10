using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraTabbedMdi;

namespace His6.Base.Control
{
    public class CustomTabbedMdiManager : XtraTabbedMdiManager
    {
        public CustomTabbedMdiManager() : base()
        {
        }

        public CustomTabbedMdiManager(IContainer container) : base(container)
        {
        }

        public Image MdParBackImage { set; get; } = null;

        protected override void DrawNC(DevExpress.Utils.Drawing.DXPaintEventArgs e)
        {
            if (this.Pages.Count > 0 || MdParBackImage == null)

            {
                base.DrawNC(e);
            }
            else
            {
                e.Graphics.DrawImage(MdParBackImage, Bounds);
            }
        }
    }
}
