using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_Stack_feedersel2 : UserControl
	{
		public void_Func_void callback_flush_feederno;

		public USR_STACKLIB mStackLib;

		public ProviderType mProvType;

		private IContainer components;

		private Panel panel1;

		private Label label1;

		public UserControl_Stack_feedersel2(ProviderType providertype, USR_STACKLIB lib)
		{
			InitializeComponent();
			mStackLib = lib;
			mProvType = providertype;
			label1.Text = STR.PROVIDER_STR[(int)mProvType][MainForm0.USR_INIT.mLanguage];
			if (mProvType == ProviderType.Feedr)
			{
				int num = Math.Max(HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].emp_m[0] + HW.malgo2[MainForm0.mFn].slt_r[0], HW.malgo2[MainForm0.mFn].slt_l[1] + HW.malgo2[MainForm0.mFn].emp_m[1] + HW.malgo2[MainForm0.mFn].slt_r[1]);
				panel1.Size = new Size(590, 19 * num + 30);
				base.Size = new Size(626, 36 + 19 * num + 30);
				int num2 = HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0];
				for (int i = 0; i < 2; i++)
				{
					int num3 = 0;
					for (int j = 0; j < HW.malgo2[MainForm0.mFn].slt_l[i]; j++)
					{
						CnLabel cnLabel = new CnLabel();
						panel1.Controls.Add(cnLabel);
						cnLabel.Location = new Point(i * 350 + 20, 19 * num3 + 15);
						int num4 = j + ((i == 1) ? num2 : 0);
						cnLabel.Text = (num4 + 1).ToString("D2") + "  " + mStackLib.stacktab[(int)mProvType][num4].mChipFootprint + " " + mStackLib.stacktab[(int)mProvType][num4].mChipValue;
						cnLabel.Tag = num4;
						cnLabel.Size = new Size(200, 19);
						cnLabel.TextAlign = ContentAlignment.MiddleLeft;
						cnLabel.Click += lb_Click;
						cnLabel.BackColor = Color.FromArgb(230, 230, 230);
						cnLabel.ForeColor = (mStackLib.stacktab[0][num4].mSelected ? Color.Black : Color.Gray);
						num3++;
					}
					num3 += HW.malgo2[MainForm0.mFn].emp_m[i];
					for (int k = HW.malgo2[MainForm0.mFn].slt_l[i]; k < HW.malgo2[MainForm0.mFn].slt_l[i] + HW.malgo2[MainForm0.mFn].slt_r[i]; k++)
					{
						CnLabel cnLabel2 = new CnLabel();
						panel1.Controls.Add(cnLabel2);
						cnLabel2.Location = new Point(i * 350 + 20, 19 * num3 + 15);
						int num5 = k + ((i == 1) ? num2 : 0);
						cnLabel2.Text = (num5 + 1).ToString("D2") + "  " + mStackLib.stacktab[(int)mProvType][num5].mChipFootprint + " " + mStackLib.stacktab[(int)mProvType][num5].mChipValue;
						cnLabel2.Tag = num5;
						cnLabel2.TextAlign = ContentAlignment.MiddleLeft;
						cnLabel2.Size = new Size(200, 19);
						cnLabel2.Click += lb_Click;
						cnLabel2.BackColor = Color.FromArgb(230, 230, 230);
						cnLabel2.ForeColor = (mStackLib.stacktab[0][num5].mSelected ? Color.Black : Color.Gray);
						num3++;
					}
				}
			}
			else
			{
				string text = "";
				if (mProvType == ProviderType.Plate)
				{
					text = "P";
				}
				else if (mProvType == ProviderType.Vibra)
				{
					text = "V";
				}
				int num6 = (HW.mStackNum[MainForm0.mFn][(int)mProvType] + 1) / 2;
				panel1.Size = new Size(590, 19 * num6 + 30);
				base.Size = new Size(626, 36 + 19 * num6 + 30);
				for (int l = 0; l < HW.mStackNum[MainForm0.mFn][(int)mProvType]; l++)
				{
					CnLabel cnLabel3 = new CnLabel();
					panel1.Controls.Add(cnLabel3);
					cnLabel3.Location = new Point(l / num6 * 350 + 20, 19 * (l % num6) + 15);
					int num7 = l;
					cnLabel3.Text = text + (num7 + 1).ToString("D2") + "  " + mStackLib.stacktab[(int)mProvType][num7].mChipFootprint + " " + mStackLib.stacktab[(int)mProvType][num7].mChipValue;
					cnLabel3.Tag = num7;
					cnLabel3.Size = new Size(200, 19);
					cnLabel3.TextAlign = ContentAlignment.MiddleLeft;
					cnLabel3.Click += lb_Click;
					cnLabel3.BackColor = Color.FromArgb(230, 230, 230);
					cnLabel3.ForeColor = (mStackLib.stacktab[(int)mProvType][num7].mSelected ? Color.Black : Color.Gray);
				}
			}
		}

		private void lb_Click(object sender, EventArgs e)
		{
			CnLabel cnLabel = (CnLabel)sender;
			int num = (int)cnLabel.Tag;
			mStackLib.index[(int)mProvType] = num;
			if (callback_flush_feederno != null)
			{
				callback_flush_feederno();
			}
			Dispose();
		}

		private void UserControl_Stack_feedersel2_MouseLeave(object sender, EventArgs e)
		{
			Dispose();
		}

		private void panel1_MouseClick(object sender, MouseEventArgs e)
		{
			Dispose();
		}

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
			panel1.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.White;
			panel1.Controls.Add(label1);
			panel1.Font = new System.Drawing.Font("楷体", 15f);
			panel1.Location = new System.Drawing.Point(16, 18);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(553, 650);
			panel1.TabIndex = 0;
			panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(panel1_MouseClick);
			label1.BackColor = System.Drawing.Color.DimGray;
			label1.Font = new System.Drawing.Font("黑体", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(228, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(135, 51);
			label1.TabIndex = 0;
			label1.Text = "普通飞达";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightBlue;
			base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_Stack_feedersel2";
			base.Size = new System.Drawing.Size(579, 683);
			base.MouseLeave += new System.EventHandler(UserControl_Stack_feedersel2_MouseLeave);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
