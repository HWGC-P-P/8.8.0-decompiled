using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_class;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_SearchExt : Form
	{
		private IContainer components;

		private Panel panel1;

		private Label label1;

		private Button button_ok;

		private int mFn;

		private USR3_DATA USR3;

		private USR_DATA USR;

		private USR2_DATA USR2;

		private BindingList<ChipBoardElement> point_list;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			panel1 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			button_ok = new System.Windows.Forms.Button();
			SuspendLayout();
			panel1.Location = new System.Drawing.Point(45, 52);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(833, 500);
			panel1.TabIndex = 0;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 18.75f);
			label1.Location = new System.Drawing.Point(395, 22);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(116, 25);
			label1.TabIndex = 1;
			label1.Text = "搜索结果";
			button_ok.Font = new System.Drawing.Font("楷体", 12.5f);
			button_ok.Location = new System.Drawing.Point(329, 565);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(259, 40);
			button_ok.TabIndex = 2;
			button_ok.Text = "完成";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(930, 626);
			base.Controls.Add(button_ok);
			base.Controls.Add(label1);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_SearchExt";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_SearchExt(int fn, USR_DATA usr, USR2_DATA usr2, USR3_DATA usr3, BindingList<ChipBoardElement> plist, bool is_pcbcheck, bool is_editenable)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR2 = usr2;
			USR3 = usr3;
			point_list = plist;
			UserControl_pcbedit_datagridview userControl_pcbedit_datagridview = new UserControl_pcbedit_datagridview(mFn, usr, usr2, usr3, plist, "search_list", is_pcbcheck, is_editenable);
			panel1.Controls.Add(userControl_pcbedit_datagridview);
			userControl_pcbedit_datagridview.Location = new Point(0, 0);
			userControl_pcbedit_datagridview.BringToFront();
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
