namespace His6.Base
{
    partial class UCDevReport
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.printControl1 = new DevExpress.XtraPrinting.Control.PrintControl();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl1.IsMetric = true;
            this.printControl1.Location = new System.Drawing.Point(0, 0);
            this.printControl1.Margin = new System.Windows.Forms.Padding(7);
            this.printControl1.Name = "printControl1";
            this.printControl1.Size = new System.Drawing.Size(1627, 1026);
            this.printControl1.TabIndex = 4;
            // 
            // UCDevReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.printControl1);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "UCDevReport";
            this.Size = new System.Drawing.Size(1627, 1026);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraPrinting.Control.PrintControl printControl1;
    }
}
