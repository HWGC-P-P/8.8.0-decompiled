using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms.Form_Debug
{
	public class Form_DebugTRAN4 : Form
	{
		private IContainer components;

		private Panel panel1;

		private Label label_B;

		private Label label_A;

		private CheckBox checkBox_SB;

		private CheckBox checkBox_SA;

		private Label label_SB;

		private Label label_SA;

		private Panel panel6;

		private Panel panel5;

		private Panel panel4;

		private Panel panel2;

		private Label label2;

		private Label[] label_S;

		private Label[] label_W;

		private CheckBox[] checkBox_S;

		private int mPlayWoodState_Sensor = -1;

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
			label_B = new System.Windows.Forms.Label();
			label_A = new System.Windows.Forms.Label();
			checkBox_SB = new System.Windows.Forms.CheckBox();
			checkBox_SA = new System.Windows.Forms.CheckBox();
			label_SB = new System.Windows.Forms.Label();
			label_SA = new System.Windows.Forms.Label();
			panel6 = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.SystemColors.Control;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label_B);
			panel1.Controls.Add(label_A);
			panel1.Controls.Add(checkBox_SB);
			panel1.Controls.Add(checkBox_SA);
			panel1.Controls.Add(label_SB);
			panel1.Controls.Add(label_SA);
			panel1.Controls.Add(panel6);
			panel1.Controls.Add(panel5);
			panel1.Controls.Add(panel4);
			panel1.Controls.Add(panel2);
			panel1.Location = new System.Drawing.Point(46, 39);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(919, 266);
			panel1.TabIndex = 1;
			label_B.BackColor = System.Drawing.Color.SpringGreen;
			label_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_B.Location = new System.Drawing.Point(702, 147);
			label_B.Name = "label_B";
			label_B.Size = new System.Drawing.Size(32, 59);
			label_B.TabIndex = 11;
			label_B.Visible = false;
			label_A.BackColor = System.Drawing.Color.SpringGreen;
			label_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_A.Location = new System.Drawing.Point(623, 147);
			label_A.Name = "label_A";
			label_A.Size = new System.Drawing.Size(32, 59);
			label_A.TabIndex = 10;
			label_A.Visible = false;
			checkBox_SB.AutoSize = true;
			checkBox_SB.Location = new System.Drawing.Point(230, 216);
			checkBox_SB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_SB.Name = "checkBox_SB";
			checkBox_SB.Size = new System.Drawing.Size(67, 20);
			checkBox_SB.TabIndex = 5;
			checkBox_SB.Text = "B信号";
			checkBox_SB.UseVisualStyleBackColor = true;
			checkBox_SA.AutoSize = true;
			checkBox_SA.Location = new System.Drawing.Point(228, 112);
			checkBox_SA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_SA.Name = "checkBox_SA";
			checkBox_SA.Size = new System.Drawing.Size(67, 20);
			checkBox_SA.TabIndex = 6;
			checkBox_SA.Text = "A信号";
			checkBox_SA.UseVisualStyleBackColor = true;
			label_SB.BackColor = System.Drawing.Color.LightGray;
			label_SB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_SB.Location = new System.Drawing.Point(228, 147);
			label_SB.Name = "label_SB";
			label_SB.Size = new System.Drawing.Size(32, 59);
			label_SB.TabIndex = 4;
			label_SA.BackColor = System.Drawing.Color.LightGray;
			label_SA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_SA.Location = new System.Drawing.Point(228, 43);
			label_SA.Name = "label_SA";
			label_SA.Size = new System.Drawing.Size(32, 59);
			label_SA.TabIndex = 4;
			panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel6.Location = new System.Drawing.Point(28, 205);
			panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(459, 8);
			panel6.TabIndex = 1;
			panel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel5.Location = new System.Drawing.Point(28, 101);
			panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(459, 8);
			panel5.TabIndex = 1;
			panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel4.Location = new System.Drawing.Point(28, 140);
			panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(459, 8);
			panel4.TabIndex = 1;
			panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel2.Location = new System.Drawing.Point(28, 36);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(459, 8);
			panel2.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(149, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(192, 16);
			label2.TabIndex = 13;
			label2.Text = "TRAN4机型是双轨道AB信号";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.DimGray;
			base.ClientSize = new System.Drawing.Size(1027, 340);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("黑体", 12f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.Name = "Form_DebugTRAN4";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_DebugTRAN4_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		public Form_DebugTRAN4()
		{
			InitializeComponent();
			label_S = new Label[2] { label_SA, label_SB };
			label_W = new Label[2] { label_A, label_B };
			checkBox_S = new CheckBox[2] { checkBox_SA, checkBox_SB };
			for (int i = 0; i < 2; i++)
			{
				label_W[i].Location = label_S[i].Location;
				label_W[i].BringToFront();
				checkBox_S[i].Tag = i;
				checkBox_S[i].CheckedChanged += checkBox_S_CheckedChanged;
			}
		}

		private void checkBox_S_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			int num = (int)checkBox.Tag;
			label_W[num].Visible = checkBox.Checked;
		}

		private void Form_DebugTRAN4_Load(object sender, EventArgs e)
		{
		}

		public void readPlayWoodState()
		{
			mPlayWoodState_Sensor = -1;
			Thread thread = new Thread(thd_readPlayWoodState);
			thread.IsBackground = true;
			thread.Start();
		}

		private void thd_readPlayWoodState()
		{
			Thread.Sleep(100);
			mPlayWoodState_Sensor = 0;
			for (int i = 0; i < 2; i++)
			{
				mPlayWoodState_Sensor |= (checkBox_S[i].Checked ? 1 : 0) << i;
			}
		}

		public int get_S()
		{
			return mPlayWoodState_Sensor;
		}

		public void sendOutBoard(int i)
		{
			checkBox_S[i].Checked = false;
		}
	}
}
