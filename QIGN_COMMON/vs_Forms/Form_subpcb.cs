using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_subpcb : Form
	{
		private IContainer components;

		private Label label1;

		private Panel panel1;

		private Label label2;

		private CnButton[] button_subpcb;

		private int mSelectedIdx;

		private int mFn;

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
			label1 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 15f);
			label1.Location = new System.Drawing.Point(40, 27);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(109, 20);
			label1.TabIndex = 0;
			label1.Text = "选择子工程";
			panel1.BackColor = System.Drawing.Color.PeachPuff;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Location = new System.Drawing.Point(27, 62);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(591, 188);
			panel1.TabIndex = 1;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 15f);
			label2.Location = new System.Drawing.Point(290, 27);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(139, 20);
			label2.TabIndex = 2;
			label2.Text = "PCB1 WIFI模块";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightSalmon;
			base.ClientSize = new System.Drawing.Size(642, 278);
			base.Controls.Add(label2);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.Name = "Form_subpcb";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_subpcb_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_subpcb(int fn)
		{
			InitializeComponent();
			mFn = fn;
		}

		private void Form_subpcb_Load(object sender, EventArgs e)
		{
			mSelectedIdx = MainForm0.U3Idx[mFn];
			if (MainForm0.U3[mFn] != null && MainForm0.U3[mFn].Count >= 1)
			{
				button_subpcb = new CnButton[MainForm0.U3[mFn].Count];
				int num = (panel1.Width - 3) / 53;
				for (int i = 0; i < MainForm0.U3[mFn].Count; i++)
				{
					CnButton cnButton = new CnButton();
					panel1.Controls.Add(cnButton);
					cnButton.Size = new Size(50, 26);
					cnButton.Location = new Point(3 + 53 * (i % num), 3 + 29 * (i / num));
					cnButton.Text = MainForm0.U3[mFn][i].mPcbID;
					cnButton.ForeColor = Color.White;
					cnButton.MouseDown += button_subpcb_Click;
					cnButton.CnButtonMode = ButtonModeEn.PressRadio;
					cnButton.CnPressDownColor = Color.Red;
					cnButton.ForeColor = Color.White;
					cnButton.BackColor = Color.DimGray;
					cnButton.Tag = i;
					button_subpcb[i] = cnButton;
				}
				flush_button();
			}
		}

		private void button_subpcb_Click(object sender, MouseEventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			int num = (mSelectedIdx = (int)cnButton.Tag);
			flush_button();
			base.DialogResult = DialogResult.OK;
		}

		public void flush_button()
		{
			for (int i = 0; i < MainForm0.U3[mFn].Count; i++)
			{
				button_subpcb[i].CnSetPressDown(i == mSelectedIdx);
				if (i == mSelectedIdx)
				{
					label2.Text = MainForm0.U3[mFn][mSelectedIdx].mPcbID + " " + MainForm0.U3[mFn][mSelectedIdx].mPcbDescription;
				}
			}
		}

		public int get_selectedindex()
		{
			return mSelectedIdx;
		}
	}
}
