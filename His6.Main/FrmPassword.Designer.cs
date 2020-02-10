namespace His6.Main
{
    partial class FrmPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.button2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNew2 = new DevExpress.XtraEditors.TextEdit();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtOld = new DevExpress.XtraEditors.TextEdit();
            this.txtNew1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Appearance.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Appearance.BackColor2 = System.Drawing.Color.AliceBlue;
            this.panel1.Appearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.panel1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.Appearance.Options.UseBorderColor = true;
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtNew2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.txtOld);
            this.panel1.Controls.Add(this.txtNew1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 291);
            this.panel1.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.button2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.button2.Appearance.Options.UseBorderColor = true;
            this.button2.Appearance.Options.UseFont = true;
            this.button2.Appearance.Options.UseForeColor = true;
            this.button2.Location = new System.Drawing.Point(353, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 54);
            this.button2.TabIndex = 9;
            this.button2.Text = "取消 ";
            this.button2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(34, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(180, 30);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "输入旧口令：";
            // 
            // txtNew2
            // 
            this.txtNew2.EnterMoveNextControl = true;
            this.txtNew2.Location = new System.Drawing.Point(219, 136);
            this.txtNew2.Name = "txtNew2";
            this.txtNew2.Properties.PasswordChar = '*';
            this.txtNew2.Size = new System.Drawing.Size(322, 36);
            this.txtNew2.TabIndex = 5;
            //this.txtNew2.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // button1
            // 
            this.button1.Appearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.button1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.button1.Appearance.Options.UseBorderColor = true;
            this.button1.Appearance.Options.UseFont = true;
            this.button1.Appearance.Options.UseForeColor = true;
            this.button1.Location = new System.Drawing.Point(101, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 54);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定 ";
            this.button1.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Location = new System.Drawing.Point(34, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(180, 30);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "输入新口令：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Location = new System.Drawing.Point(34, 134);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(180, 30);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "再输入一次：";
            // 
            // txtOld
            // 
            this.txtOld.EnterMoveNextControl = true;
            this.txtOld.Location = new System.Drawing.Point(219, 36);
            this.txtOld.Name = "txtOld";
            this.txtOld.Properties.PasswordChar = '*';
            this.txtOld.Size = new System.Drawing.Size(322, 36);
            this.txtOld.TabIndex = 3;
            //this.txtOld.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtNew1
            // 
            this.txtNew1.EnterMoveNextControl = true;
            this.txtNew1.Location = new System.Drawing.Point(219, 83);
            this.txtNew1.Name = "txtNew1";
            this.txtNew1.Properties.PasswordChar = '*';
            this.txtNew1.Size = new System.Drawing.Size(322, 36);
            this.txtNew1.TabIndex = 4;
            //this.txtNew1.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // FrmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 291);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "口令修改";
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.SimpleButton button2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNew2;
        private DevExpress.XtraEditors.SimpleButton button1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtOld;
        private DevExpress.XtraEditors.TextEdit txtNew1;
    }
}