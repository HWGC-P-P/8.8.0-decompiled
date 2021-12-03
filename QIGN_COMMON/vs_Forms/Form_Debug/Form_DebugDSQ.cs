using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms.Form_Debug
{
	public class Form_DebugDSQ : Form
	{
		private IContainer components;

		private Panel panel1;

		private Panel panel3;

		private Panel panel4;

		private Panel panel2;

		private Label label_S4;

		private Label label_S3;

		private Label label_S2;

		private Label label_S1;

		private Label label_S0;

		private Panel panel7;

		private Panel panel6;

		private Panel panel5;

		private CheckBox checkBox_S4;

		private CheckBox checkBox_S3;

		private CheckBox checkBox_S2;

		private CheckBox checkBox_S1;

		private CheckBox checkBox_S0;

		private Label label_B3;

		private Label label_B2;

		private Label label_B1;

		private CheckBox checkBox_M0;

		private CheckBox checkBox_M2;

		private CheckBox checkBox_M1;

		private CnButton cnButton_inboard;

		private CnButton cnButton_inboard2;

		private Label label1;

		private Panel panel9;

		private Panel panel8;

		private CheckBox checkBox_S5;

		private Label label2;

		private Label label_B4;

		private CnButton cnButton_outboard2;

		private CnButton cnButton_outboard;

		private Label[] label_S;

		private CheckBox[] checkBox_S;

		private CheckBox[] checkBox_M;

		private int mPlayWoodState_Sensor = -1;

		private int mPlayWoodState_Motor = -1;

		private QnCommon.BoardStateEn[] mInBoardState;

		private QnCommon.BoardStateEn[] mOutBoardState;

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
			label_B3 = new System.Windows.Forms.Label();
			label_B2 = new System.Windows.Forms.Label();
			label_B1 = new System.Windows.Forms.Label();
			checkBox_S4 = new System.Windows.Forms.CheckBox();
			checkBox_S3 = new System.Windows.Forms.CheckBox();
			checkBox_S2 = new System.Windows.Forms.CheckBox();
			checkBox_M2 = new System.Windows.Forms.CheckBox();
			checkBox_M1 = new System.Windows.Forms.CheckBox();
			checkBox_M0 = new System.Windows.Forms.CheckBox();
			checkBox_S1 = new System.Windows.Forms.CheckBox();
			checkBox_S0 = new System.Windows.Forms.CheckBox();
			label_S4 = new System.Windows.Forms.Label();
			label_S3 = new System.Windows.Forms.Label();
			label_S2 = new System.Windows.Forms.Label();
			label_S1 = new System.Windows.Forms.Label();
			label_S0 = new System.Windows.Forms.Label();
			panel7 = new System.Windows.Forms.Panel();
			panel6 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			cnButton_inboard2 = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_inboard = new QIGN_COMMON.vs_acontrol.CnButton();
			panel8 = new System.Windows.Forms.Panel();
			panel9 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			checkBox_S5 = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			label_B4 = new System.Windows.Forms.Label();
			cnButton_outboard = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_outboard2 = new QIGN_COMMON.vs_acontrol.CnButton();
			panel1.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.SystemColors.Control;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Controls.Add(cnButton_outboard2);
			panel1.Controls.Add(cnButton_outboard);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(cnButton_inboard2);
			panel1.Controls.Add(cnButton_inboard);
			panel1.Controls.Add(label_B4);
			panel1.Controls.Add(label_B3);
			panel1.Controls.Add(label_B2);
			panel1.Controls.Add(label_B1);
			panel1.Controls.Add(checkBox_S5);
			panel1.Controls.Add(checkBox_S4);
			panel1.Controls.Add(checkBox_S3);
			panel1.Controls.Add(checkBox_S2);
			panel1.Controls.Add(checkBox_M2);
			panel1.Controls.Add(checkBox_M1);
			panel1.Controls.Add(checkBox_M0);
			panel1.Controls.Add(checkBox_S1);
			panel1.Controls.Add(checkBox_S0);
			panel1.Controls.Add(label_S4);
			panel1.Controls.Add(label_S3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label_S2);
			panel1.Controls.Add(label_S1);
			panel1.Controls.Add(label_S0);
			panel1.Controls.Add(panel9);
			panel1.Controls.Add(panel7);
			panel1.Controls.Add(panel6);
			panel1.Controls.Add(panel8);
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(panel5);
			panel1.Controls.Add(panel4);
			panel1.Controls.Add(panel2);
			panel1.Location = new System.Drawing.Point(31, 32);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(890, 270);
			panel1.TabIndex = 0;
			label_B3.BackColor = System.Drawing.Color.SpringGreen;
			label_B3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_B3.Location = new System.Drawing.Point(215, 143);
			label_B3.Name = "label_B3";
			label_B3.Size = new System.Drawing.Size(32, 59);
			label_B3.TabIndex = 11;
			label_B3.Visible = false;
			label_B2.BackColor = System.Drawing.Color.SpringGreen;
			label_B2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_B2.Location = new System.Drawing.Point(136, 143);
			label_B2.Name = "label_B2";
			label_B2.Size = new System.Drawing.Size(32, 59);
			label_B2.TabIndex = 10;
			label_B1.BackColor = System.Drawing.Color.SpringGreen;
			label_B1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_B1.Location = new System.Drawing.Point(86, 143);
			label_B1.Name = "label_B1";
			label_B1.Size = new System.Drawing.Size(32, 59);
			label_B1.TabIndex = 9;
			checkBox_S4.AutoSize = true;
			checkBox_S4.Location = new System.Drawing.Point(718, 112);
			checkBox_S4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S4.Name = "checkBox_S4";
			checkBox_S4.Size = new System.Drawing.Size(43, 20);
			checkBox_S4.TabIndex = 7;
			checkBox_S4.Text = "S4";
			checkBox_S4.UseVisualStyleBackColor = true;
			checkBox_S3.AutoSize = true;
			checkBox_S3.Location = new System.Drawing.Point(625, 112);
			checkBox_S3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S3.Name = "checkBox_S3";
			checkBox_S3.Size = new System.Drawing.Size(43, 20);
			checkBox_S3.TabIndex = 7;
			checkBox_S3.Text = "S3";
			checkBox_S3.UseVisualStyleBackColor = true;
			checkBox_S2.AutoSize = true;
			checkBox_S2.Location = new System.Drawing.Point(434, 112);
			checkBox_S2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S2.Name = "checkBox_S2";
			checkBox_S2.Size = new System.Drawing.Size(43, 20);
			checkBox_S2.TabIndex = 8;
			checkBox_S2.Text = "S2";
			checkBox_S2.UseVisualStyleBackColor = true;
			checkBox_M2.AutoSize = true;
			checkBox_M2.Location = new System.Drawing.Point(614, 8);
			checkBox_M2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_M2.Name = "checkBox_M2";
			checkBox_M2.Size = new System.Drawing.Size(43, 20);
			checkBox_M2.TabIndex = 5;
			checkBox_M2.Text = "M2";
			checkBox_M2.UseVisualStyleBackColor = true;
			checkBox_M1.AutoSize = true;
			checkBox_M1.Location = new System.Drawing.Point(358, 8);
			checkBox_M1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_M1.Name = "checkBox_M1";
			checkBox_M1.Size = new System.Drawing.Size(43, 20);
			checkBox_M1.TabIndex = 5;
			checkBox_M1.Text = "M1";
			checkBox_M1.UseVisualStyleBackColor = true;
			checkBox_M0.AutoSize = true;
			checkBox_M0.Location = new System.Drawing.Point(125, 8);
			checkBox_M0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_M0.Name = "checkBox_M0";
			checkBox_M0.Size = new System.Drawing.Size(43, 20);
			checkBox_M0.TabIndex = 5;
			checkBox_M0.Text = "M0";
			checkBox_M0.UseVisualStyleBackColor = true;
			checkBox_S1.AutoSize = true;
			checkBox_S1.Location = new System.Drawing.Point(224, 112);
			checkBox_S1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S1.Name = "checkBox_S1";
			checkBox_S1.Size = new System.Drawing.Size(43, 20);
			checkBox_S1.TabIndex = 5;
			checkBox_S1.Text = "S1";
			checkBox_S1.UseVisualStyleBackColor = true;
			checkBox_S0.AutoSize = true;
			checkBox_S0.Location = new System.Drawing.Point(37, 112);
			checkBox_S0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S0.Name = "checkBox_S0";
			checkBox_S0.Size = new System.Drawing.Size(43, 20);
			checkBox_S0.TabIndex = 6;
			checkBox_S0.Text = "S0";
			checkBox_S0.UseVisualStyleBackColor = true;
			label_S4.BackColor = System.Drawing.Color.LightGray;
			label_S4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S4.Location = new System.Drawing.Point(718, 43);
			label_S4.Name = "label_S4";
			label_S4.Size = new System.Drawing.Size(32, 59);
			label_S4.TabIndex = 4;
			label_S3.BackColor = System.Drawing.Color.LightGray;
			label_S3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S3.Location = new System.Drawing.Point(625, 43);
			label_S3.Name = "label_S3";
			label_S3.Size = new System.Drawing.Size(32, 59);
			label_S3.TabIndex = 4;
			label_S2.BackColor = System.Drawing.Color.LightGray;
			label_S2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S2.Location = new System.Drawing.Point(436, 43);
			label_S2.Name = "label_S2";
			label_S2.Size = new System.Drawing.Size(32, 59);
			label_S2.TabIndex = 4;
			label_S1.BackColor = System.Drawing.Color.LightGray;
			label_S1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S1.Location = new System.Drawing.Point(222, 43);
			label_S1.Name = "label_S1";
			label_S1.Size = new System.Drawing.Size(32, 59);
			label_S1.TabIndex = 4;
			label_S0.BackColor = System.Drawing.Color.LightGray;
			label_S0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S0.Location = new System.Drawing.Point(37, 43);
			label_S0.Name = "label_S0";
			label_S0.Size = new System.Drawing.Size(32, 59);
			label_S0.TabIndex = 4;
			panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel7.Location = new System.Drawing.Point(297, 101);
			panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(185, 8);
			panel7.TabIndex = 1;
			panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel6.Location = new System.Drawing.Point(494, 101);
			panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(259, 8);
			panel6.TabIndex = 1;
			panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel3.Location = new System.Drawing.Point(297, 36);
			panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(185, 8);
			panel3.TabIndex = 1;
			panel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel5.Location = new System.Drawing.Point(28, 101);
			panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(259, 8);
			panel5.TabIndex = 1;
			panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel4.Location = new System.Drawing.Point(494, 36);
			panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(259, 8);
			panel4.TabIndex = 1;
			panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel2.Location = new System.Drawing.Point(28, 36);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(259, 8);
			panel2.TabIndex = 1;
			cnButton_inboard2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			cnButton_inboard2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_inboard2.CnPressDownColor = System.Drawing.Color.White;
			cnButton_inboard2.Location = new System.Drawing.Point(525, 220);
			cnButton_inboard2.Name = "cnButton_inboard2";
			cnButton_inboard2.Size = new System.Drawing.Size(75, 34);
			cnButton_inboard2.TabIndex = 12;
			cnButton_inboard2.Text = "进板";
			cnButton_inboard2.UseVisualStyleBackColor = false;
			cnButton_inboard2.Click += new System.EventHandler(cnButton_inboard2_Click);
			cnButton_inboard.BackColor = System.Drawing.SystemColors.AppWorkspace;
			cnButton_inboard.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_inboard.CnPressDownColor = System.Drawing.Color.White;
			cnButton_inboard.Location = new System.Drawing.Point(86, 220);
			cnButton_inboard.Name = "cnButton_inboard";
			cnButton_inboard.Size = new System.Drawing.Size(75, 34);
			cnButton_inboard.TabIndex = 12;
			cnButton_inboard.Text = "进板";
			cnButton_inboard.UseVisualStyleBackColor = false;
			cnButton_inboard.Click += new System.EventHandler(cnButton_inboard_Click);
			panel8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel8.Location = new System.Drawing.Point(786, 36);
			panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(93, 8);
			panel8.TabIndex = 1;
			panel9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel9.Location = new System.Drawing.Point(786, 101);
			panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(93, 8);
			panel9.TabIndex = 1;
			label1.BackColor = System.Drawing.Color.LightGray;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.Location = new System.Drawing.Point(846, 43);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 59);
			label1.TabIndex = 4;
			checkBox_S5.AutoSize = true;
			checkBox_S5.Location = new System.Drawing.Point(835, 112);
			checkBox_S5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S5.Name = "checkBox_S5";
			checkBox_S5.Size = new System.Drawing.Size(43, 20);
			checkBox_S5.TabIndex = 7;
			checkBox_S5.Text = "S5";
			checkBox_S5.UseVisualStyleBackColor = true;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(783, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(88, 16);
			label2.TabIndex = 13;
			label2.Text = "后端接驳台";
			label_B4.BackColor = System.Drawing.Color.SpringGreen;
			label_B4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_B4.Location = new System.Drawing.Point(265, 143);
			label_B4.Name = "label_B4";
			label_B4.Size = new System.Drawing.Size(32, 59);
			label_B4.TabIndex = 11;
			label_B4.Visible = false;
			cnButton_outboard.BackColor = System.Drawing.SystemColors.AppWorkspace;
			cnButton_outboard.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_outboard.CnPressDownColor = System.Drawing.Color.White;
			cnButton_outboard.Location = new System.Drawing.Point(167, 220);
			cnButton_outboard.Name = "cnButton_outboard";
			cnButton_outboard.Size = new System.Drawing.Size(75, 34);
			cnButton_outboard.TabIndex = 14;
			cnButton_outboard.Text = "出板";
			cnButton_outboard.UseVisualStyleBackColor = false;
			cnButton_outboard.Click += new System.EventHandler(cnButton_outboard_Click);
			cnButton_outboard2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			cnButton_outboard2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_outboard2.CnPressDownColor = System.Drawing.Color.White;
			cnButton_outboard2.Location = new System.Drawing.Point(606, 220);
			cnButton_outboard2.Name = "cnButton_outboard2";
			cnButton_outboard2.Size = new System.Drawing.Size(75, 34);
			cnButton_outboard2.TabIndex = 14;
			cnButton_outboard2.Text = "出板";
			cnButton_outboard2.UseVisualStyleBackColor = false;
			cnButton_outboard2.Click += new System.EventHandler(cnButton_outboard2_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.DimGray;
			base.ClientSize = new System.Drawing.Size(948, 332);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_DebugDSQ";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_DebugDSQ_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		public Form_DebugDSQ()
		{
			InitializeComponent();
			mInBoardState = new QnCommon.BoardStateEn[HW.mFnNum];
			mOutBoardState = new QnCommon.BoardStateEn[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mInBoardState[i] = QnCommon.BoardStateEn.Unknown;
				mOutBoardState[i] = QnCommon.BoardStateEn.Unknown;
			}
			checkBox_S = new CheckBox[6] { checkBox_S0, checkBox_S1, checkBox_S2, checkBox_S3, checkBox_S4, checkBox_S5 };
			label_S = new Label[6] { label_S0, label_S1, label_S2, label_S3, label_S4, label1 };
			checkBox_M = new CheckBox[3] { checkBox_M0, checkBox_M1, checkBox_M2 };
			label_B1.Visible = false;
			label_B2.Visible = false;
			label_B1.BackColor = Color.SpringGreen;
			label_B2.BackColor = Color.SpringGreen;
			for (int j = 0; j < 6; j++)
			{
				checkBox_S[j].Tag = j;
				checkBox_S[j].CheckedChanged += checkBox_S1_CheckedChanged;
			}
		}

		private void Form_DebugDSQ_Load(object sender, EventArgs e)
		{
		}

		private void checkBox_S1_CheckedChanged(object sender, EventArgs e)
		{
			int num = (int)((CheckBox)sender).Tag;
			label_S[num].BackColor = (checkBox_S[num].Checked ? Color.SpringGreen : Color.LightGray);
			if (num == 5)
			{
				label_S[num].BackColor = (checkBox_S[num].Checked ? Color.LightGray : Color.SpringGreen);
			}
		}

		public void readPlayWoodState()
		{
			mPlayWoodState_Sensor = -1;
			mPlayWoodState_Motor = -1;
			Thread thread = new Thread(thd_readPlayWoodState);
			thread.Priority = ThreadPriority.Highest;
			thread.IsBackground = true;
			thread.Start();
		}

		private void thd_readPlayWoodState()
		{
			Thread.Sleep(100);
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 6; i++)
			{
				num |= (checkBox_S[i].Checked ? 1 : 0) << i;
			}
			for (int j = 0; j < 3; j++)
			{
				num2 |= (checkBox_M[j].Checked ? 1 : 0) << j;
			}
			mPlayWoodState_Sensor = num;
			mPlayWoodState_Motor = num2;
		}

		public int get_S()
		{
			return mPlayWoodState_Sensor;
		}

		public int get_M()
		{
			return mPlayWoodState_Motor;
		}

		public QnCommon.BoardStateEn get_InB(int fn)
		{
			return mInBoardState[fn];
		}

		public QnCommon.BoardStateEn get_OutB(int fn)
		{
			return mOutBoardState[fn];
		}

		public void set_InB(int fn, QnCommon.BoardStateEn state)
		{
			mInBoardState[fn] = state;
		}

		public void set_OutB(int fn, QnCommon.BoardStateEn state)
		{
			mOutBoardState[fn] = state;
		}

		public void set_track0_run(bool flag)
		{
			Color color3 = (panel2.BackColor = (panel5.BackColor = (flag ? Color.Red : Color.Black)));
			checkBox_M[0].Checked = flag;
		}

		public void set_track1_run(bool flag)
		{
			Color color3 = (panel3.BackColor = (panel7.BackColor = (flag ? Color.Red : Color.Black)));
			checkBox_M[1].Checked = flag;
		}

		public void set_track2_run(bool flag)
		{
			Color color3 = (panel4.BackColor = (panel6.BackColor = (flag ? Color.Red : Color.Black)));
			checkBox_M[2].Checked = flag;
		}

		private void cnButton_inboard_Click(object sender, EventArgs e)
		{
			sendInBoard(0);
		}

		private void cnButton_inboard2_Click(object sender, EventArgs e)
		{
			sendInBoard(1);
		}

		private void cnButton_outboard_Click(object sender, EventArgs e)
		{
			sendOutBoard(0);
		}

		private void cnButton_outboard2_Click(object sender, EventArgs e)
		{
			sendOutBoard(1);
		}

		public void sendInBoard(int fn)
		{
			bool flag = false;
			switch (fn)
			{
			case 0:
				if (checkBox_S[0].Checked && !checkBox_S[1].Checked && !checkBox_M[0].Checked)
				{
					flag = true;
				}
				break;
			case 1:
				if (checkBox_S[2].Checked && !checkBox_S[3].Checked && !checkBox_S[4].Checked && !checkBox_M[1].Checked && !checkBox_M[2].Checked)
				{
					flag = true;
				}
				break;
			}
			if (flag)
			{
				Thread thread = new Thread(thd_sendInBoard);
				thread.Priority = ThreadPriority.Highest;
				thread.IsBackground = true;
				thread.Start(fn);
			}
		}

		private void thd_sendInBoard(object o)
		{
			int num = (int)o;
			switch (num)
			{
			case 0:
				mInBoardState[num] = QnCommon.BoardStateEn.Busy;
				Invoke((MethodInvoker)delegate
				{
					label_B1.Location = label_S[0].Location;
					label_B1.BringToFront();
					label_B1.Visible = true;
					checkBox_S[0].Checked = false;
					set_track0_run(flag: true);
				});
				while (label_B1.Location.X < label_S[1].Location.X)
				{
					Thread.Sleep(2);
					Invoke((MethodInvoker)delegate
					{
						label_B1.Location = new Point(label_B1.Location.X + 1, label_B1.Location.Y);
					});
				}
				Invoke((MethodInvoker)delegate
				{
					label_B1.Visible = false;
					checkBox_S[1].Checked = true;
					set_track0_run(flag: false);
				});
				mInBoardState[num] = QnCommon.BoardStateEn.Ok;
				break;
			case 1:
				mInBoardState[num] = QnCommon.BoardStateEn.Busy;
				Invoke((MethodInvoker)delegate
				{
					label_B2.Location = label_S[2].Location;
					label_B2.BringToFront();
					label_B2.Visible = true;
					checkBox_S[2].Checked = false;
					set_track1_run(flag: true);
					set_track2_run(flag: true);
				});
				if (MainForm0.USR_INIT.mTrack.mode == 0)
				{
					while (label_B2.Location.X < label_S[3].Location.X)
					{
						Thread.Sleep(2);
						Invoke((MethodInvoker)delegate
						{
							if (label_B2.Location.X == label_S[2].Location.X + 50)
							{
								set_track1_run(flag: false);
							}
							label_B2.Location = new Point(label_B2.Location.X + 1, label_B2.Location.Y);
						});
					}
					Invoke((MethodInvoker)delegate
					{
						label_B2.Visible = false;
						checkBox_S[3].Checked = true;
						set_track1_run(flag: false);
						set_track2_run(flag: false);
					});
				}
				else
				{
					while (label_B2.Location.X < label_S[4].Location.X)
					{
						Thread.Sleep(2);
						Invoke((MethodInvoker)delegate
						{
							if (label_B2.Location.X == label_S[2].Location.X + 50)
							{
								set_track1_run(flag: false);
							}
							label_B2.Location = new Point(label_B2.Location.X + 1, label_B2.Location.Y);
						});
					}
					Invoke((MethodInvoker)delegate
					{
						label_B2.Visible = false;
						checkBox_S[4].Checked = true;
						set_track1_run(flag: false);
						set_track2_run(flag: false);
					});
				}
				mInBoardState[num] = QnCommon.BoardStateEn.Ok;
				break;
			}
		}

		public void sendOutBoard(int fn)
		{
			bool flag = false;
			switch (fn)
			{
			case 0:
				flag = checkBox_S[1].Checked && !checkBox_S[2].Checked && !checkBox_M[0].Checked && !checkBox_M[1].Checked;
				break;
			case 1:
				flag = ((MainForm0.USR_INIT.mTrack.mode != 0) ? ((checkBox_S[3].Checked || checkBox_S[4].Checked) && !checkBox_M[2].Checked && checkBox_S[5].Checked) : (checkBox_S[3].Checked && !checkBox_S[4].Checked && !checkBox_M[2].Checked));
				break;
			}
			if (flag)
			{
				Thread thread = new Thread(thd_sendOutBoard);
				thread.Priority = ThreadPriority.Highest;
				thread.IsBackground = true;
				thread.Start(fn);
			}
		}

		private void thd_sendOutBoard(object o)
		{
			int num = (int)o;
			switch (num)
			{
			case 0:
				mOutBoardState[num] = QnCommon.BoardStateEn.Busy;
				Invoke((MethodInvoker)delegate
				{
					label_B3.Location = label_S[1].Location;
					label_B3.BringToFront();
					label_B3.Visible = true;
					checkBox_S[1].Checked = false;
					set_track0_run(flag: true);
					set_track1_run(flag: true);
				});
				while (label_B3.Location.X < label_S[2].Location.X)
				{
					Thread.Sleep(1);
					Invoke((MethodInvoker)delegate
					{
						label_B3.Location = new Point(label_B3.Location.X + 1, label_B3.Location.Y);
						if (label_B3.Location.X == label_S[1].Location.X + 80)
						{
							set_track0_run(flag: false);
						}
					});
				}
				Invoke((MethodInvoker)delegate
				{
					label_B3.Visible = false;
					checkBox_S[2].Checked = true;
					set_track0_run(flag: false);
					set_track1_run(flag: false);
				});
				mOutBoardState[num] = QnCommon.BoardStateEn.Ok;
				break;
			case 1:
				mOutBoardState[num] = QnCommon.BoardStateEn.Busy;
				if (MainForm0.USR_INIT.mTrack.mode == 0)
				{
					Invoke((MethodInvoker)delegate
					{
						label_B4.Location = label_S[3].Location;
						label_B4.BringToFront();
						label_B4.Visible = true;
						checkBox_S[3].Checked = false;
						set_track2_run(flag: true);
					});
					while (label_B4.Location.X < label_S[4].Location.X)
					{
						Thread.Sleep(1);
						Invoke((MethodInvoker)delegate
						{
							label_B4.Location = new Point(label_B4.Location.X + 1, label_B4.Location.Y);
						});
					}
					Invoke((MethodInvoker)delegate
					{
						label_B4.Visible = false;
						checkBox_S[4].Checked = true;
						set_track2_run(flag: false);
					});
				}
				else
				{
					Invoke((MethodInvoker)delegate
					{
						label_B4.Location = label_S[4].Location;
						label_B4.BringToFront();
						label_B4.Visible = true;
						checkBox_S[4].Checked = false;
						set_track2_run(flag: true);
					});
					while (label_B4.Location.X < label_S[5].Location.X)
					{
						Thread.Sleep(1);
						Invoke((MethodInvoker)delegate
						{
							label_B4.Location = new Point(label_B4.Location.X + 1, label_B4.Location.Y);
						});
					}
					Invoke((MethodInvoker)delegate
					{
						label_B4.Visible = false;
						checkBox_S[5].Checked = false;
						set_track2_run(flag: false);
					});
				}
				mOutBoardState[num] = QnCommon.BoardStateEn.Ok;
				break;
			}
		}
	}
}
