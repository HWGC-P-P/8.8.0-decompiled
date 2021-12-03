using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_Debug : Form
	{
		private IContainer components;

		private Panel panel0;

		private Label label1;

		private Label label2;

		private Panel panel1;

		private Panel panel7;

		private Panel panel6;

		private Panel panel3;

		private Panel panel5;

		private Panel panel4;

		private Panel panel2;

		private Label label_S1;

		private Label label_S4;

		private Label label_S3;

		private Label label_S2;

		private CheckBox checkBox_S4;

		private CheckBox checkBox_S3;

		private CheckBox checkBox_S2;

		private CheckBox checkBox_M3;

		private CheckBox checkBox_M2;

		private CheckBox checkBox_M1;

		private CheckBox checkBox_S1;

		private Label label_B1;

		private Label label_B2;

		private Label label_B0;

		private CheckBox checkBox_IsNozzleDirty;

		private Panel panel_autorun_3ds;

		private Panel panel8;

		private Label label3;

		private Panel panel9;

		private Panel panel11;

		private Panel panel10;

		private Label label_flk1;

		private Label label_flk0;

		private CheckBox checkBox_outside_signal_ready;

		private Label label7;

		private Label label6;

		private Label label_flktab;

		private Label label5;

		private Label label4;

		private Panel panel12;

		private Button button_scancode;

		private TextBox textBox_scancode;

		private TextBox textBox_ispcbcodesmt;

		private Label label8;

		private Button button_ispcbcodesmtsend;

		private Panel panel_autorun_1ds;

		private Panel panel14;

		private Label label9;

		private Panel panel16;

		private Panel panel15;

		private CheckBox checkBox_D2;

		private CheckBox checkBox_D3;

		private CheckBox checkBox_D1;

		private Label label_D1;

		private Label label_D2;

		private Label label_D3;

		private CheckBox checkBox_D4;

		private Panel panel17;

		private Panel panel18;

		private Label label_D4;

		private CheckBox checkBox_IsBTC;

		private Button button_Inborad;

		private Button button_OutBoard;

		private NumericUpDown numericUpDown_debugrun_speed;

		private Panel panel_autorun_1ds_2dt;

		private Panel panel19;

		private CheckBox checkBox_DD2;

		private CheckBox checkBox_DD5;

		private CheckBox checkBox_DD3;

		private CheckBox checkBox_DD4;

		private CheckBox checkBox_DD1;

		private Panel panel20;

		private Panel panel21;

		private Label label_DD1;

		private Label label_DD4;

		private Label label_DD3;

		private Label label_DD2;

		private Panel panel22;

		private Panel panel23;

		private Label label_DD5;

		private Label label14;

		private CheckBox checkBox_IsBTC2;

		private CheckBox[] checkbox_vis;

		private CheckBox[] checkBox_S;

		private CheckBox[] checkBox_D;

		private CheckBox[] checkBox_DD;

		private CheckBox[] checkBox_M;

		private Label[] label_S;

		private Label[] label_D;

		private Label[] label_DD;

		private int mPlayWoodState_Sensor = -1;

		private int mPlayWoodState_Motor = -1;

		private QnCommon.BoardStateEn mInBoardState;

		private QnCommon.BoardStateEn mOutBoardState;

		private CheckBox[] checkbox_flk_vacc;

		private bool mIsSanduanshi;

		private bool mIsBtc;

		private int m_debugrun_speed = 1;

		private int mFn;

		private BindingList<string> mXiaohan_codelist;

		private BindingList<string> mXiaohan_codeissmtlist;

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
			panel0 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			checkBox_S4 = new System.Windows.Forms.CheckBox();
			checkBox_S3 = new System.Windows.Forms.CheckBox();
			checkBox_S2 = new System.Windows.Forms.CheckBox();
			checkBox_M3 = new System.Windows.Forms.CheckBox();
			label_B0 = new System.Windows.Forms.Label();
			label_B2 = new System.Windows.Forms.Label();
			checkBox_M2 = new System.Windows.Forms.CheckBox();
			label_B1 = new System.Windows.Forms.Label();
			checkBox_M1 = new System.Windows.Forms.CheckBox();
			checkBox_S1 = new System.Windows.Forms.CheckBox();
			label_S4 = new System.Windows.Forms.Label();
			label_S3 = new System.Windows.Forms.Label();
			label_S2 = new System.Windows.Forms.Label();
			label_S1 = new System.Windows.Forms.Label();
			panel7 = new System.Windows.Forms.Panel();
			panel6 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			checkBox_IsNozzleDirty = new System.Windows.Forms.CheckBox();
			panel_autorun_3ds = new System.Windows.Forms.Panel();
			panel8 = new System.Windows.Forms.Panel();
			panel9 = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			checkBox_outside_signal_ready = new System.Windows.Forms.CheckBox();
			panel11 = new System.Windows.Forms.Panel();
			label_flktab = new System.Windows.Forms.Label();
			panel10 = new System.Windows.Forms.Panel();
			label_flk1 = new System.Windows.Forms.Label();
			label_flk0 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			panel12 = new System.Windows.Forms.Panel();
			button_ispcbcodesmtsend = new System.Windows.Forms.Button();
			button_scancode = new System.Windows.Forms.Button();
			textBox_ispcbcodesmt = new System.Windows.Forms.TextBox();
			textBox_scancode = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			panel_autorun_1ds = new System.Windows.Forms.Panel();
			panel14 = new System.Windows.Forms.Panel();
			checkBox_D2 = new System.Windows.Forms.CheckBox();
			checkBox_IsBTC = new System.Windows.Forms.CheckBox();
			checkBox_D4 = new System.Windows.Forms.CheckBox();
			checkBox_D3 = new System.Windows.Forms.CheckBox();
			checkBox_D1 = new System.Windows.Forms.CheckBox();
			panel16 = new System.Windows.Forms.Panel();
			panel15 = new System.Windows.Forms.Panel();
			label_D1 = new System.Windows.Forms.Label();
			label_D3 = new System.Windows.Forms.Label();
			label_D2 = new System.Windows.Forms.Label();
			panel17 = new System.Windows.Forms.Panel();
			panel18 = new System.Windows.Forms.Panel();
			label_D4 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			button_Inborad = new System.Windows.Forms.Button();
			button_OutBoard = new System.Windows.Forms.Button();
			numericUpDown_debugrun_speed = new System.Windows.Forms.NumericUpDown();
			panel_autorun_1ds_2dt = new System.Windows.Forms.Panel();
			panel19 = new System.Windows.Forms.Panel();
			checkBox_IsBTC2 = new System.Windows.Forms.CheckBox();
			checkBox_DD2 = new System.Windows.Forms.CheckBox();
			checkBox_DD5 = new System.Windows.Forms.CheckBox();
			checkBox_DD3 = new System.Windows.Forms.CheckBox();
			checkBox_DD4 = new System.Windows.Forms.CheckBox();
			checkBox_DD1 = new System.Windows.Forms.CheckBox();
			panel20 = new System.Windows.Forms.Panel();
			panel21 = new System.Windows.Forms.Panel();
			label_DD1 = new System.Windows.Forms.Label();
			label_DD4 = new System.Windows.Forms.Label();
			label_DD3 = new System.Windows.Forms.Label();
			label_DD2 = new System.Windows.Forms.Label();
			panel22 = new System.Windows.Forms.Panel();
			panel23 = new System.Windows.Forms.Panel();
			label_DD5 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel_autorun_3ds.SuspendLayout();
			panel8.SuspendLayout();
			panel9.SuspendLayout();
			panel12.SuspendLayout();
			panel_autorun_1ds.SuspendLayout();
			panel14.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_debugrun_speed).BeginInit();
			panel_autorun_1ds_2dt.SuspendLayout();
			panel19.SuspendLayout();
			SuspendLayout();
			panel0.BackColor = System.Drawing.SystemColors.Control;
			panel0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel0.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			panel0.Location = new System.Drawing.Point(12, 32);
			panel0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel0.Name = "panel0";
			panel0.Size = new System.Drawing.Size(577, 45);
			panel0.TabIndex = 0;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(65, 19);
			label1.TabIndex = 1;
			label1.Text = "视觉结果";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(11, 3);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(121, 19);
			label2.TabIndex = 1;
			label2.Text = "三段式全自动传板";
			panel1.BackColor = System.Drawing.SystemColors.Control;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Controls.Add(checkBox_S4);
			panel1.Controls.Add(checkBox_S3);
			panel1.Controls.Add(checkBox_S2);
			panel1.Controls.Add(checkBox_M3);
			panel1.Controls.Add(label_B0);
			panel1.Controls.Add(label_B2);
			panel1.Controls.Add(checkBox_M2);
			panel1.Controls.Add(label_B1);
			panel1.Controls.Add(checkBox_M1);
			panel1.Controls.Add(checkBox_S1);
			panel1.Controls.Add(label_S4);
			panel1.Controls.Add(label_S3);
			panel1.Controls.Add(label_S2);
			panel1.Controls.Add(label_S1);
			panel1.Controls.Add(panel7);
			panel1.Controls.Add(panel6);
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(panel5);
			panel1.Controls.Add(panel4);
			panel1.Controls.Add(panel2);
			panel1.Location = new System.Drawing.Point(9, 26);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(577, 179);
			panel1.TabIndex = 2;
			checkBox_S4.AutoSize = true;
			checkBox_S4.Location = new System.Drawing.Point(529, 140);
			checkBox_S4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S4.Name = "checkBox_S4";
			checkBox_S4.Size = new System.Drawing.Size(42, 18);
			checkBox_S4.TabIndex = 4;
			checkBox_S4.Text = "S4";
			checkBox_S4.UseVisualStyleBackColor = true;
			checkBox_S3.AutoSize = true;
			checkBox_S3.Location = new System.Drawing.Point(357, 140);
			checkBox_S3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S3.Name = "checkBox_S3";
			checkBox_S3.Size = new System.Drawing.Size(42, 18);
			checkBox_S3.TabIndex = 4;
			checkBox_S3.Text = "S3";
			checkBox_S3.UseVisualStyleBackColor = true;
			checkBox_S2.AutoSize = true;
			checkBox_S2.Location = new System.Drawing.Point(124, 140);
			checkBox_S2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S2.Name = "checkBox_S2";
			checkBox_S2.Size = new System.Drawing.Size(42, 18);
			checkBox_S2.TabIndex = 4;
			checkBox_S2.Text = "S2";
			checkBox_S2.UseVisualStyleBackColor = true;
			checkBox_M3.AutoSize = true;
			checkBox_M3.Location = new System.Drawing.Point(451, 4);
			checkBox_M3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_M3.Name = "checkBox_M3";
			checkBox_M3.Size = new System.Drawing.Size(42, 18);
			checkBox_M3.TabIndex = 4;
			checkBox_M3.Text = "M3";
			checkBox_M3.UseVisualStyleBackColor = true;
			label_B0.BackColor = System.Drawing.Color.SpringGreen;
			label_B0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_B0.Location = new System.Drawing.Point(240, 113);
			label_B0.Name = "label_B0";
			label_B0.Size = new System.Drawing.Size(32, 59);
			label_B0.TabIndex = 3;
			label_B0.Visible = false;
			label_B0.Click += new System.EventHandler(label_B2_Click);
			label_B2.BackColor = System.Drawing.Color.SpringGreen;
			label_B2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_B2.Location = new System.Drawing.Point(309, 113);
			label_B2.Name = "label_B2";
			label_B2.Size = new System.Drawing.Size(32, 59);
			label_B2.TabIndex = 3;
			label_B2.Click += new System.EventHandler(label_B2_Click);
			checkBox_M2.AutoSize = true;
			checkBox_M2.Location = new System.Drawing.Point(263, 4);
			checkBox_M2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_M2.Name = "checkBox_M2";
			checkBox_M2.Size = new System.Drawing.Size(42, 18);
			checkBox_M2.TabIndex = 4;
			checkBox_M2.Text = "M2";
			checkBox_M2.UseVisualStyleBackColor = true;
			label_B1.BackColor = System.Drawing.Color.LightGreen;
			label_B1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_B1.Location = new System.Drawing.Point(187, 113);
			label_B1.Name = "label_B1";
			label_B1.Size = new System.Drawing.Size(32, 59);
			label_B1.TabIndex = 3;
			checkBox_M1.AutoSize = true;
			checkBox_M1.Location = new System.Drawing.Point(56, 4);
			checkBox_M1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_M1.Name = "checkBox_M1";
			checkBox_M1.Size = new System.Drawing.Size(42, 18);
			checkBox_M1.TabIndex = 4;
			checkBox_M1.Text = "M1";
			checkBox_M1.UseVisualStyleBackColor = true;
			checkBox_S1.AutoSize = true;
			checkBox_S1.Location = new System.Drawing.Point(4, 140);
			checkBox_S1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_S1.Name = "checkBox_S1";
			checkBox_S1.Size = new System.Drawing.Size(42, 18);
			checkBox_S1.TabIndex = 4;
			checkBox_S1.Text = "S1";
			checkBox_S1.UseVisualStyleBackColor = true;
			checkBox_S1.CheckedChanged += new System.EventHandler(checkBox_S1_CheckedChanged);
			label_S4.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_S4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S4.Location = new System.Drawing.Point(529, 39);
			label_S4.Name = "label_S4";
			label_S4.Size = new System.Drawing.Size(32, 59);
			label_S4.TabIndex = 3;
			label_S3.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_S3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S3.Location = new System.Drawing.Point(357, 39);
			label_S3.Name = "label_S3";
			label_S3.Size = new System.Drawing.Size(32, 59);
			label_S3.TabIndex = 3;
			label_S2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_S2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S2.Location = new System.Drawing.Point(124, 39);
			label_S2.Name = "label_S2";
			label_S2.Size = new System.Drawing.Size(32, 59);
			label_S2.TabIndex = 3;
			label_S1.BackColor = System.Drawing.Color.LightGray;
			label_S1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S1.Location = new System.Drawing.Point(4, 39);
			label_S1.Name = "label_S1";
			label_S1.Size = new System.Drawing.Size(32, 59);
			label_S1.TabIndex = 3;
			panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel7.Location = new System.Drawing.Point(162, 97);
			panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(263, 15);
			panel7.TabIndex = 0;
			panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel6.Location = new System.Drawing.Point(431, 97);
			panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(130, 15);
			panel6.TabIndex = 0;
			panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel3.Location = new System.Drawing.Point(162, 26);
			panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(263, 15);
			panel3.TabIndex = 0;
			panel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel5.Location = new System.Drawing.Point(3, 97);
			panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(153, 15);
			panel5.TabIndex = 0;
			panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel4.Location = new System.Drawing.Point(431, 26);
			panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(130, 15);
			panel4.TabIndex = 0;
			panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel2.Location = new System.Drawing.Point(3, 26);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(153, 15);
			panel2.TabIndex = 0;
			checkBox_IsNozzleDirty.AutoSize = true;
			checkBox_IsNozzleDirty.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_IsNozzleDirty.ForeColor = System.Drawing.Color.White;
			checkBox_IsNozzleDirty.Location = new System.Drawing.Point(486, 9);
			checkBox_IsNozzleDirty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			checkBox_IsNozzleDirty.Name = "checkBox_IsNozzleDirty";
			checkBox_IsNozzleDirty.Size = new System.Drawing.Size(93, 23);
			checkBox_IsNozzleDirty.TabIndex = 3;
			checkBox_IsNozzleDirty.Text = "吸嘴有异物";
			checkBox_IsNozzleDirty.UseVisualStyleBackColor = true;
			panel_autorun_3ds.Controls.Add(panel1);
			panel_autorun_3ds.Controls.Add(label2);
			panel_autorun_3ds.Location = new System.Drawing.Point(3, 83);
			panel_autorun_3ds.Name = "panel_autorun_3ds";
			panel_autorun_3ds.Size = new System.Drawing.Size(589, 209);
			panel_autorun_3ds.TabIndex = 4;
			panel8.Controls.Add(panel9);
			panel8.Location = new System.Drawing.Point(830, 150);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(415, 183);
			panel8.TabIndex = 5;
			panel9.BackColor = System.Drawing.SystemColors.Control;
			panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel9.Controls.Add(label5);
			panel9.Controls.Add(label4);
			panel9.Controls.Add(label7);
			panel9.Controls.Add(label6);
			panel9.Controls.Add(checkBox_outside_signal_ready);
			panel9.Controls.Add(panel11);
			panel9.Controls.Add(label_flktab);
			panel9.Controls.Add(panel10);
			panel9.Controls.Add(label_flk1);
			panel9.Controls.Add(label_flk0);
			panel9.Location = new System.Drawing.Point(9, 26);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(400, 148);
			panel9.TabIndex = 2;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(277, 49);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(47, 42);
			label5.TabIndex = 6;
			label5.Text = "1   2\r\n3   4\r\n5   6";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(14, 49);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(47, 42);
			label4.TabIndex = 6;
			label4.Text = "1   2\r\n3   4\r\n5   6";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(258, 127);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(79, 14);
			label7.TabIndex = 5;
			label7.Text = "Out Place";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(7, 127);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(87, 14);
			label6.TabIndex = 5;
			label6.Text = "Work Place";
			checkBox_outside_signal_ready.AutoSize = true;
			checkBox_outside_signal_ready.Location = new System.Drawing.Point(4, -1);
			checkBox_outside_signal_ready.Name = "checkBox_outside_signal_ready";
			checkBox_outside_signal_ready.Size = new System.Drawing.Size(186, 18);
			checkBox_outside_signal_ready.TabIndex = 4;
			checkBox_outside_signal_ready.Text = "OutSide_Signal_Ready";
			checkBox_outside_signal_ready.UseVisualStyleBackColor = true;
			panel11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel11.Location = new System.Drawing.Point(4, 113);
			panel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel11.Name = "panel11";
			panel11.Size = new System.Drawing.Size(314, 10);
			panel11.TabIndex = 0;
			label_flktab.BackColor = System.Drawing.Color.DarkSeaGreen;
			label_flktab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_flktab.Font = new System.Drawing.Font("微软雅黑", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_flktab.Location = new System.Drawing.Point(325, 28);
			label_flktab.Name = "label_flktab";
			label_flktab.Size = new System.Drawing.Size(56, 86);
			label_flktab.TabIndex = 3;
			label_flktab.Click += new System.EventHandler(label_B2_Click);
			panel10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel10.Location = new System.Drawing.Point(4, 17);
			panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel10.Name = "panel10";
			panel10.Size = new System.Drawing.Size(315, 10);
			panel10.TabIndex = 0;
			label_flk1.BackColor = System.Drawing.SystemColors.ButtonFace;
			label_flk1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_flk1.Location = new System.Drawing.Point(263, 28);
			label_flk1.Name = "label_flk1";
			label_flk1.Size = new System.Drawing.Size(56, 97);
			label_flk1.TabIndex = 3;
			label_flk0.BackColor = System.Drawing.SystemColors.ButtonFace;
			label_flk0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_flk0.Location = new System.Drawing.Point(4, 28);
			label_flk0.Name = "label_flk0";
			label_flk0.Size = new System.Drawing.Size(53, 86);
			label_flk0.TabIndex = 3;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label3.ForeColor = System.Drawing.Color.White;
			label3.Location = new System.Drawing.Point(5, 4);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(65, 19);
			label3.TabIndex = 1;
			label3.Text = "霄汉扫码";
			panel12.Controls.Add(button_ispcbcodesmtsend);
			panel12.Controls.Add(button_scancode);
			panel12.Controls.Add(textBox_ispcbcodesmt);
			panel12.Controls.Add(textBox_scancode);
			panel12.Controls.Add(label8);
			panel12.Controls.Add(label3);
			panel12.Location = new System.Drawing.Point(608, 32);
			panel12.Name = "panel12";
			panel12.Size = new System.Drawing.Size(204, 112);
			panel12.TabIndex = 6;
			panel12.Visible = false;
			button_ispcbcodesmtsend.Location = new System.Drawing.Point(118, 76);
			button_ispcbcodesmtsend.Name = "button_ispcbcodesmtsend";
			button_ispcbcodesmtsend.Size = new System.Drawing.Size(75, 23);
			button_ispcbcodesmtsend.TabIndex = 3;
			button_ispcbcodesmtsend.Text = "发送";
			button_ispcbcodesmtsend.UseVisualStyleBackColor = true;
			button_ispcbcodesmtsend.Click += new System.EventHandler(button_ispcbcodesmtsend_Click);
			button_scancode.Location = new System.Drawing.Point(118, 26);
			button_scancode.Name = "button_scancode";
			button_scancode.Size = new System.Drawing.Size(75, 23);
			button_scancode.TabIndex = 3;
			button_scancode.Text = "扫码";
			button_scancode.UseVisualStyleBackColor = true;
			button_scancode.Click += new System.EventHandler(button_scancode_Click);
			textBox_ispcbcodesmt.Location = new System.Drawing.Point(9, 76);
			textBox_ispcbcodesmt.Name = "textBox_ispcbcodesmt";
			textBox_ispcbcodesmt.Size = new System.Drawing.Size(103, 23);
			textBox_ispcbcodesmt.TabIndex = 2;
			textBox_scancode.Location = new System.Drawing.Point(9, 26);
			textBox_scancode.Name = "textBox_scancode";
			textBox_scancode.Size = new System.Drawing.Size(103, 23);
			textBox_scancode.TabIndex = 2;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label8.ForeColor = System.Drawing.Color.White;
			label8.Location = new System.Drawing.Point(5, 55);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(65, 19);
			label8.TabIndex = 1;
			label8.Text = "贴板信号";
			panel_autorun_1ds.Controls.Add(panel14);
			panel_autorun_1ds.Controls.Add(label9);
			panel_autorun_1ds.Location = new System.Drawing.Point(3, 297);
			panel_autorun_1ds.Name = "panel_autorun_1ds";
			panel_autorun_1ds.Size = new System.Drawing.Size(589, 212);
			panel_autorun_1ds.TabIndex = 7;
			panel14.BackColor = System.Drawing.SystemColors.Control;
			panel14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel14.Controls.Add(checkBox_D2);
			panel14.Controls.Add(checkBox_IsBTC);
			panel14.Controls.Add(checkBox_D4);
			panel14.Controls.Add(checkBox_D3);
			panel14.Controls.Add(checkBox_D1);
			panel14.Controls.Add(panel16);
			panel14.Controls.Add(panel15);
			panel14.Controls.Add(label_D1);
			panel14.Controls.Add(label_D3);
			panel14.Controls.Add(label_D2);
			panel14.Controls.Add(panel17);
			panel14.Controls.Add(panel18);
			panel14.Controls.Add(label_D4);
			panel14.Location = new System.Drawing.Point(9, 32);
			panel14.Name = "panel14";
			panel14.Size = new System.Drawing.Size(577, 165);
			panel14.TabIndex = 0;
			checkBox_D2.AutoSize = true;
			checkBox_D2.Location = new System.Drawing.Point(206, 129);
			checkBox_D2.Name = "checkBox_D2";
			checkBox_D2.Size = new System.Drawing.Size(42, 18);
			checkBox_D2.TabIndex = 1;
			checkBox_D2.Text = "D2";
			checkBox_D2.UseVisualStyleBackColor = true;
			checkBox_IsBTC.AutoSize = true;
			checkBox_IsBTC.Location = new System.Drawing.Point(370, 4);
			checkBox_IsBTC.Name = "checkBox_IsBTC";
			checkBox_IsBTC.Size = new System.Drawing.Size(131, 18);
			checkBox_IsBTC.TabIndex = 1;
			checkBox_IsBTC.Text = "启用后端接驳台";
			checkBox_IsBTC.UseVisualStyleBackColor = true;
			checkBox_IsBTC.CheckedChanged += new System.EventHandler(checkBox_IsBTC_CheckedChanged);
			checkBox_D4.AutoSize = true;
			checkBox_D4.Location = new System.Drawing.Point(518, 129);
			checkBox_D4.Name = "checkBox_D4";
			checkBox_D4.Size = new System.Drawing.Size(42, 18);
			checkBox_D4.TabIndex = 1;
			checkBox_D4.Text = "D4";
			checkBox_D4.UseVisualStyleBackColor = true;
			checkBox_D3.AutoSize = true;
			checkBox_D3.Location = new System.Drawing.Point(428, 129);
			checkBox_D3.Name = "checkBox_D3";
			checkBox_D3.Size = new System.Drawing.Size(42, 18);
			checkBox_D3.TabIndex = 1;
			checkBox_D3.Text = "D3";
			checkBox_D3.UseVisualStyleBackColor = true;
			checkBox_D1.AutoSize = true;
			checkBox_D1.Location = new System.Drawing.Point(9, 129);
			checkBox_D1.Name = "checkBox_D1";
			checkBox_D1.Size = new System.Drawing.Size(42, 18);
			checkBox_D1.TabIndex = 1;
			checkBox_D1.Text = "D1";
			checkBox_D1.UseVisualStyleBackColor = true;
			panel16.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel16.Location = new System.Drawing.Point(9, 105);
			panel16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel16.Name = "panel16";
			panel16.Size = new System.Drawing.Size(465, 15);
			panel16.TabIndex = 0;
			panel15.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel15.Location = new System.Drawing.Point(9, 31);
			panel15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel15.Name = "panel15";
			panel15.Size = new System.Drawing.Size(465, 15);
			panel15.TabIndex = 0;
			label_D1.BackColor = System.Drawing.Color.LightGray;
			label_D1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_D1.Location = new System.Drawing.Point(9, 45);
			label_D1.Name = "label_D1";
			label_D1.Size = new System.Drawing.Size(32, 59);
			label_D1.TabIndex = 3;
			label_D3.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_D3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_D3.Location = new System.Drawing.Point(439, 45);
			label_D3.Name = "label_D3";
			label_D3.Size = new System.Drawing.Size(32, 59);
			label_D3.TabIndex = 3;
			label_D2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_D2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_D2.Location = new System.Drawing.Point(206, 45);
			label_D2.Name = "label_D2";
			label_D2.Size = new System.Drawing.Size(32, 59);
			label_D2.TabIndex = 3;
			panel17.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel17.Location = new System.Drawing.Point(481, 31);
			panel17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel17.Name = "panel17";
			panel17.Size = new System.Drawing.Size(80, 15);
			panel17.TabIndex = 0;
			panel18.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel18.Location = new System.Drawing.Point(481, 105);
			panel18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel18.Name = "panel18";
			panel18.Size = new System.Drawing.Size(80, 15);
			panel18.TabIndex = 0;
			label_D4.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_D4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_D4.Location = new System.Drawing.Point(529, 45);
			label_D4.Name = "label_D4";
			label_D4.Size = new System.Drawing.Size(32, 59);
			label_D4.TabIndex = 3;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label9.ForeColor = System.Drawing.Color.White;
			label9.Location = new System.Drawing.Point(11, 10);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(121, 19);
			label9.TabIndex = 1;
			label9.Text = "单段式全自动传板";
			button_Inborad.Location = new System.Drawing.Point(608, 173);
			button_Inborad.Name = "button_Inborad";
			button_Inborad.Size = new System.Drawing.Size(75, 23);
			button_Inborad.TabIndex = 8;
			button_Inborad.Text = "进板";
			button_Inborad.UseVisualStyleBackColor = true;
			button_Inborad.Click += new System.EventHandler(button_Inborad_Click);
			button_OutBoard.Location = new System.Drawing.Point(689, 173);
			button_OutBoard.Name = "button_OutBoard";
			button_OutBoard.Size = new System.Drawing.Size(75, 23);
			button_OutBoard.TabIndex = 8;
			button_OutBoard.Text = "出板";
			button_OutBoard.UseVisualStyleBackColor = true;
			button_OutBoard.Click += new System.EventHandler(button_OutBoard_Click);
			numericUpDown_debugrun_speed.Font = new System.Drawing.Font("微软雅黑", 9.25f, System.Drawing.FontStyle.Bold);
			numericUpDown_debugrun_speed.Location = new System.Drawing.Point(608, 205);
			numericUpDown_debugrun_speed.Name = "numericUpDown_debugrun_speed";
			numericUpDown_debugrun_speed.Size = new System.Drawing.Size(75, 24);
			numericUpDown_debugrun_speed.TabIndex = 9;
			numericUpDown_debugrun_speed.ValueChanged += new System.EventHandler(numericUpDown_debugrun_speed_ValueChanged);
			panel_autorun_1ds_2dt.Controls.Add(panel19);
			panel_autorun_1ds_2dt.Controls.Add(label14);
			panel_autorun_1ds_2dt.Location = new System.Drawing.Point(3, 516);
			panel_autorun_1ds_2dt.Name = "panel_autorun_1ds_2dt";
			panel_autorun_1ds_2dt.Size = new System.Drawing.Size(589, 212);
			panel_autorun_1ds_2dt.TabIndex = 7;
			panel19.BackColor = System.Drawing.SystemColors.Control;
			panel19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel19.Controls.Add(checkBox_IsBTC2);
			panel19.Controls.Add(checkBox_DD2);
			panel19.Controls.Add(checkBox_DD5);
			panel19.Controls.Add(checkBox_DD3);
			panel19.Controls.Add(checkBox_DD4);
			panel19.Controls.Add(checkBox_DD1);
			panel19.Controls.Add(panel20);
			panel19.Controls.Add(panel21);
			panel19.Controls.Add(label_DD1);
			panel19.Controls.Add(label_DD4);
			panel19.Controls.Add(label_DD3);
			panel19.Controls.Add(label_DD2);
			panel19.Controls.Add(panel22);
			panel19.Controls.Add(panel23);
			panel19.Controls.Add(label_DD5);
			panel19.Location = new System.Drawing.Point(9, 32);
			panel19.Name = "panel19";
			panel19.Size = new System.Drawing.Size(577, 165);
			panel19.TabIndex = 0;
			checkBox_IsBTC2.AutoSize = true;
			checkBox_IsBTC2.Location = new System.Drawing.Point(370, 3);
			checkBox_IsBTC2.Name = "checkBox_IsBTC2";
			checkBox_IsBTC2.Size = new System.Drawing.Size(131, 18);
			checkBox_IsBTC2.TabIndex = 4;
			checkBox_IsBTC2.Text = "启用后端接驳台";
			checkBox_IsBTC2.UseVisualStyleBackColor = true;
			checkBox_IsBTC2.CheckedChanged += new System.EventHandler(checkBox_IsBTC2_CheckedChanged);
			checkBox_DD2.AutoSize = true;
			checkBox_DD2.Location = new System.Drawing.Point(206, 129);
			checkBox_DD2.Name = "checkBox_DD2";
			checkBox_DD2.Size = new System.Drawing.Size(50, 18);
			checkBox_DD2.TabIndex = 1;
			checkBox_DD2.Text = "DD2";
			checkBox_DD2.UseVisualStyleBackColor = true;
			checkBox_DD5.AutoSize = true;
			checkBox_DD5.Location = new System.Drawing.Point(518, 129);
			checkBox_DD5.Name = "checkBox_DD5";
			checkBox_DD5.Size = new System.Drawing.Size(50, 18);
			checkBox_DD5.TabIndex = 1;
			checkBox_DD5.Text = "DD5";
			checkBox_DD5.UseVisualStyleBackColor = true;
			checkBox_DD3.AutoSize = true;
			checkBox_DD3.Location = new System.Drawing.Point(337, 129);
			checkBox_DD3.Name = "checkBox_DD3";
			checkBox_DD3.Size = new System.Drawing.Size(50, 18);
			checkBox_DD3.TabIndex = 1;
			checkBox_DD3.Text = "DD3";
			checkBox_DD3.UseVisualStyleBackColor = true;
			checkBox_DD4.AutoSize = true;
			checkBox_DD4.Location = new System.Drawing.Point(428, 129);
			checkBox_DD4.Name = "checkBox_DD4";
			checkBox_DD4.Size = new System.Drawing.Size(50, 18);
			checkBox_DD4.TabIndex = 1;
			checkBox_DD4.Text = "DD4";
			checkBox_DD4.UseVisualStyleBackColor = true;
			checkBox_DD1.AutoSize = true;
			checkBox_DD1.Location = new System.Drawing.Point(9, 129);
			checkBox_DD1.Name = "checkBox_DD1";
			checkBox_DD1.Size = new System.Drawing.Size(50, 18);
			checkBox_DD1.TabIndex = 1;
			checkBox_DD1.Text = "DD1";
			checkBox_DD1.UseVisualStyleBackColor = true;
			panel20.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel20.Location = new System.Drawing.Point(9, 105);
			panel20.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel20.Name = "panel20";
			panel20.Size = new System.Drawing.Size(465, 15);
			panel20.TabIndex = 0;
			panel21.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel21.Location = new System.Drawing.Point(9, 31);
			panel21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel21.Name = "panel21";
			panel21.Size = new System.Drawing.Size(465, 15);
			panel21.TabIndex = 0;
			label_DD1.BackColor = System.Drawing.Color.LightGray;
			label_DD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_DD1.Location = new System.Drawing.Point(9, 45);
			label_DD1.Name = "label_DD1";
			label_DD1.Size = new System.Drawing.Size(32, 59);
			label_DD1.TabIndex = 3;
			label_DD4.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_DD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_DD4.Location = new System.Drawing.Point(439, 45);
			label_DD4.Name = "label_DD4";
			label_DD4.Size = new System.Drawing.Size(32, 59);
			label_DD4.TabIndex = 3;
			label_DD3.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_DD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_DD3.Location = new System.Drawing.Point(357, 45);
			label_DD3.Name = "label_DD3";
			label_DD3.Size = new System.Drawing.Size(32, 59);
			label_DD3.TabIndex = 3;
			label_DD2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_DD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_DD2.Location = new System.Drawing.Point(206, 45);
			label_DD2.Name = "label_DD2";
			label_DD2.Size = new System.Drawing.Size(32, 59);
			label_DD2.TabIndex = 3;
			panel22.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel22.Location = new System.Drawing.Point(481, 31);
			panel22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel22.Name = "panel22";
			panel22.Size = new System.Drawing.Size(80, 15);
			panel22.TabIndex = 0;
			panel23.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel23.Location = new System.Drawing.Point(481, 105);
			panel23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel23.Name = "panel23";
			panel23.Size = new System.Drawing.Size(80, 15);
			panel23.TabIndex = 0;
			label_DD5.BackColor = System.Drawing.SystemColors.ActiveBorder;
			label_DD5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_DD5.Location = new System.Drawing.Point(529, 45);
			label_DD5.Name = "label_DD5";
			label_DD5.Size = new System.Drawing.Size(32, 59);
			label_DD5.TabIndex = 3;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label14.ForeColor = System.Drawing.Color.White;
			label14.Location = new System.Drawing.Point(11, 10);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(79, 19);
			label14.TabIndex = 1;
			label14.Text = "两段式贴板";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.SystemColors.ControlDarkDark;
			base.ClientSize = new System.Drawing.Size(822, 726);
			base.Controls.Add(numericUpDown_debugrun_speed);
			base.Controls.Add(button_OutBoard);
			base.Controls.Add(button_Inborad);
			base.Controls.Add(panel_autorun_1ds_2dt);
			base.Controls.Add(panel_autorun_1ds);
			base.Controls.Add(panel12);
			base.Controls.Add(panel8);
			base.Controls.Add(panel_autorun_3ds);
			base.Controls.Add(checkBox_IsNozzleDirty);
			base.Controls.Add(label1);
			base.Controls.Add(panel0);
			Font = new System.Drawing.Font("黑体", 10.25f, System.Drawing.FontStyle.Bold);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "Form_Debug";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.TopMost = true;
			base.Load += new System.EventHandler(Form_Debug_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_autorun_3ds.ResumeLayout(false);
			panel_autorun_3ds.PerformLayout();
			panel8.ResumeLayout(false);
			panel9.ResumeLayout(false);
			panel9.PerformLayout();
			panel12.ResumeLayout(false);
			panel12.PerformLayout();
			panel_autorun_1ds.ResumeLayout(false);
			panel_autorun_1ds.PerformLayout();
			panel14.ResumeLayout(false);
			panel14.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_debugrun_speed).EndInit();
			panel_autorun_1ds_2dt.ResumeLayout(false);
			panel_autorun_1ds_2dt.PerformLayout();
			panel19.ResumeLayout(false);
			panel19.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_Debug(int fn, bool issanduanshi, bool is_bct)
		{
			InitializeComponent();
			mFn = fn;
			mIsSanduanshi = issanduanshi;
			mIsBtc = is_bct;
			checkbox_vis = new CheckBox[HW.mZnNum[MainForm0.mFn]];
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				CheckBox checkBox = new CheckBox();
				panel0.Controls.Add(checkBox);
				checkBox.Tag = i;
				checkBox.Text = "Z" + (i + 1);
				checkBox.Size = new Size(60, 20);
				checkBox.Location = new Point(i * 68 + 4, 20);
				checkBox.Checked = true;
				checkbox_vis[i] = checkBox;
			}
			mPlayWoodState_Sensor = -1;
			mPlayWoodState_Motor = -1;
			mInBoardState = QnCommon.BoardStateEn.Unknown;
			mOutBoardState = QnCommon.BoardStateEn.Unknown;
			label_S = new Label[4] { label_S1, label_S2, label_S3, label_S4 };
			label_B1.Visible = false;
			label_B2.Visible = false;
			label_B1.BackColor = Color.SpringGreen;
			label_B2.BackColor = Color.SpringGreen;
			checkBox_S = new CheckBox[4] { checkBox_S1, checkBox_S2, checkBox_S3, checkBox_S4 };
			checkBox_M = new CheckBox[3] { checkBox_M1, checkBox_M2, checkBox_M3 };
			for (int j = 0; j < 4; j++)
			{
				checkBox_S[j].Tag = j;
			}
			for (int k = 0; k < 4; k++)
			{
				checkBox_S[k].CheckedChanged += checkBox_S1_CheckedChanged;
			}
			mPlayWoodState_Sensor = -1;
			mInBoardState = QnCommon.BoardStateEn.Unknown;
			mOutBoardState = QnCommon.BoardStateEn.Unknown;
			label_D = new Label[4] { label_D1, label_D2, label_D3, label_D4 };
			if (!mIsSanduanshi)
			{
				panel14.Controls.Add(label_B1);
				panel14.Controls.Add(label_B2);
				label_B1.Location = label_D1.Location;
				label_B2.Location = label_D2.Location;
			}
			checkBox_D = new CheckBox[4] { checkBox_D1, checkBox_D2, checkBox_D3, checkBox_D4 };
			for (int l = 0; l < 4; l++)
			{
				checkBox_D[l].Tag = l;
			}
			for (int m = 0; m < 4; m++)
			{
				checkBox_D[m].CheckedChanged += checkBox_D1_CheckedChanged;
			}
			panel17.Visible = (panel18.Visible = (label_D4.Visible = (checkBox_D4.Visible = (checkBox_IsBTC.Checked = mIsBtc))));
			mPlayWoodState_Sensor = -1;
			label14.Text = HW.mSections + "段贴装模式";
			mInBoardState = QnCommon.BoardStateEn.Unknown;
			mOutBoardState = QnCommon.BoardStateEn.Unknown;
			label_DD = new Label[5] { label_DD1, label_DD2, label_DD3, label_DD4, label_DD5 };
			if (mIsSanduanshi && MainForm0.USR3B[mFn].mInBoardMode == 1)
			{
				panel19.Controls.Add(label_B1);
				panel19.Controls.Add(label_B2);
				label_B1.Location = label_DD1.Location;
				label_B2.Location = label_DD2.Location;
			}
			checkBox_DD = new CheckBox[5] { checkBox_DD1, checkBox_DD2, checkBox_DD3, checkBox_DD4, checkBox_DD5 };
			for (int n = 0; n < 5; n++)
			{
				checkBox_DD[n].Tag = n;
			}
			for (int num = 0; num < 5; num++)
			{
				checkBox_DD[num].CheckedChanged += checkBox_DD1_CheckedChanged;
			}
			panel22.Visible = (panel23.Visible = (label_DD5.Visible = (checkBox_DD5.Visible = (checkBox_IsBTC.Checked = mIsBtc))));
			panel_autorun_1ds_2dt.Location = (panel_autorun_1ds.Location = panel_autorun_3ds.Location);
			panel_autorun_1ds.Visible = !mIsSanduanshi;
			panel_autorun_3ds.Visible = ((mIsSanduanshi && MainForm0.USR3B[mFn].mInBoardMode == 0) ? true : false);
			panel_autorun_1ds_2dt.Visible = ((mIsSanduanshi && MainForm0.USR3B[mFn].mInBoardMode == 1) ? true : false);
			m_debugrun_speed = 3;
			numericUpDown_debugrun_speed.Value = m_debugrun_speed;
			checkbox_flk_vacc = new CheckBox[HW.mFlkTabVaccNum];
			for (int num2 = 0; num2 < HW.mFlkTabVaccNum; num2++)
			{
				checkbox_flk_vacc[num2] = new CheckBox();
				checkbox_flk_vacc[num2].Text = (num2 + 1).ToString();
				label_flktab.Controls.Add(checkbox_flk_vacc[num2]);
				checkbox_flk_vacc[num2].Location = new Point(8 + 25 * (num2 % 2), 8 + num2 / 2 * 25);
				checkbox_flk_vacc[num2].AutoSize = false;
				checkbox_flk_vacc[num2].Size = new Size(25, 20);
			}
		}

		private void Form_Debug_Load(object sender, EventArgs e)
		{
		}

		public bool get_visual(int zn)
		{
			return checkbox_vis[zn].Checked;
		}

		private void thd_readPlayWoodState()
		{
			Thread.Sleep(300);
			if (mIsSanduanshi)
			{
				mPlayWoodState_Sensor = 0;
				mPlayWoodState_Motor = 0;
				if (MainForm0.USR3B[mFn].mInBoardMode == 1)
				{
					if (HW.mSections == 2)
					{
						mPlayWoodState_Sensor |= (checkBox_DD[0].Checked ? 1 : 0);
						mPlayWoodState_Sensor |= (checkBox_DD[1].Checked ? 1 : 0) << 2;
						mPlayWoodState_Sensor |= (checkBox_DD[2].Checked ? 1 : 0) << 5;
						mPlayWoodState_Sensor |= (checkBox_DD[3].Checked ? 1 : 0) << 3;
						mPlayWoodState_Sensor |= ((!checkBox_DD[4].Checked) ? 1 : 0) << 4;
					}
					else if (HW.mSections == 3)
					{
						mPlayWoodState_Sensor |= (checkBox_DD[0].Checked ? 1 : 0);
						mPlayWoodState_Sensor |= (checkBox_DD[1].Checked ? 1 : 0) << 1;
						mPlayWoodState_Sensor |= (checkBox_DD[2].Checked ? 1 : 0) << 2;
						mPlayWoodState_Sensor |= (checkBox_DD[3].Checked ? 1 : 0) << 3;
						mPlayWoodState_Sensor |= (checkBox_DD[4].Checked ? 1 : 0) << 4;
					}
				}
				else
				{
					for (int i = 0; i < 4; i++)
					{
						mPlayWoodState_Sensor |= (checkBox_S[i].Checked ? 1 : 0) << i;
					}
					for (int j = 0; j < 3; j++)
					{
						mPlayWoodState_Motor |= (checkBox_M[j].Checked ? 1 : 0) << j;
					}
				}
			}
			else
			{
				mPlayWoodState_Sensor = 0;
				for (int k = 0; k < 4; k++)
				{
					mPlayWoodState_Sensor |= (checkBox_D[k].Checked ? 1 : 0) << k + 1;
				}
			}
		}

		public void readPlayWoodState()
		{
			Thread thread = new Thread(thd_readPlayWoodState);
			thread.IsBackground = true;
			thread.Start();
		}

		private void thd_sendInBoard(object o)
		{
			if (mIsSanduanshi)
			{
				if (MainForm0.USR3B[mFn].mInBoardMode == 1)
				{
					int section = (int)o;
					mInBoardState = QnCommon.BoardStateEn.Busy;
					Invoke((MethodInvoker)delegate
					{
						label_B1.Location = label_DD[section].Location;
						label_B1.BringToFront();
						label_B1.Visible = true;
						checkBox_DD[section].Checked = false;
					});
					while (label_B1.Location.X < label_DD[section + 1].Location.X)
					{
						Thread.Sleep(m_debugrun_speed);
						Invoke((MethodInvoker)delegate
						{
							label_B1.Location = new Point(label_B1.Location.X + 1, label_B1.Location.Y);
						});
					}
					Invoke((MethodInvoker)delegate
					{
						label_B1.Visible = false;
						checkBox_DD[section + 1].Checked = true;
						checkBox_DD[section].Checked = false;
					});
					mInBoardState = QnCommon.BoardStateEn.Ok;
					return;
				}
				mInBoardState = QnCommon.BoardStateEn.Busy;
				Invoke((MethodInvoker)delegate
				{
					label_B1.Location = label_S[1].Location;
					label_B1.BringToFront();
					label_B1.Visible = true;
					checkBox_S[1].Checked = false;
					checkBox_M[0].Checked = true;
					checkBox_M[1].Checked = true;
				});
				while (label_B1.Location.X < label_S[2].Location.X)
				{
					Thread.Sleep(m_debugrun_speed);
					Invoke((MethodInvoker)delegate
					{
						if (label_B1.Location.X == label_S[1].Location.X + 50)
						{
							checkBox_M[0].Checked = false;
						}
						label_B1.Location = new Point(label_B1.Location.X + 1, label_B1.Location.Y);
					});
				}
				Invoke((MethodInvoker)delegate
				{
					label_B1.Visible = false;
					checkBox_S[2].Checked = true;
					checkBox_M[1].Checked = false;
				});
				mInBoardState = QnCommon.BoardStateEn.Ok;
				return;
			}
			mInBoardState = QnCommon.BoardStateEn.Busy;
			Invoke((MethodInvoker)delegate
			{
				label_B1.Location = label_D[0].Location;
				label_B1.BringToFront();
				label_B1.Visible = true;
				checkBox_D[0].Checked = false;
			});
			while (label_B1.Location.X < label_D[1].Location.X)
			{
				Thread.Sleep(m_debugrun_speed);
				Invoke((MethodInvoker)delegate
				{
					label_B1.Location = new Point(label_B1.Location.X + 1, label_B1.Location.Y);
				});
			}
			Invoke((MethodInvoker)delegate
			{
				label_B1.Visible = false;
				checkBox_D[1].Checked = true;
			});
			mInBoardState = QnCommon.BoardStateEn.Ok;
		}

		public void sendInBoard()
		{
			if (mIsSanduanshi)
			{
				if (MainForm0.USR3B[mFn].mInBoardMode == 1)
				{
					if (checkBox_DD[0].Checked && !checkBox_DD[1].Checked && !checkBox_DD[2].Checked && !checkBox_DD[3].Checked)
					{
						Thread thread = new Thread(thd_sendInBoard);
						thread.IsBackground = true;
						thread.Start(0);
					}
					else if (checkBox_DD[1].Checked && !checkBox_DD[2].Checked && !checkBox_DD[3].Checked)
					{
						Thread thread2 = new Thread(thd_sendInBoard);
						thread2.IsBackground = true;
						thread2.Start(1);
					}
					else if (HW.mSections == 3 && checkBox_DD[2].Checked && !checkBox_DD[3].Checked)
					{
						Thread thread3 = new Thread(thd_sendInBoard);
						thread3.IsBackground = true;
						thread3.Start(2);
					}
				}
				else if (!checkBox_M[0].Checked && !checkBox_M[1].Checked && checkBox_S[1].Checked && !checkBox_S[2].Checked)
				{
					Thread thread4 = new Thread(thd_sendInBoard);
					thread4.IsBackground = true;
					thread4.Start(0);
				}
			}
			else if (checkBox_D[0].Checked && !checkBox_D[1].Checked && !checkBox_D[2].Checked)
			{
				Thread thread5 = new Thread(thd_sendInBoard);
				thread5.IsBackground = true;
				thread5.Start(0);
			}
		}

		private void thd_sendOutBoard(object o)
		{
			if (mIsSanduanshi)
			{
				if (MainForm0.USR3B[mFn].mInBoardMode == 1)
				{
					int section = (int)o;
					mOutBoardState = QnCommon.BoardStateEn.Busy;
					Invoke((MethodInvoker)delegate
					{
						label_B2.Location = label_DD[section + 1].Location;
						label_B2.BringToFront();
						label_B2.Visible = true;
						checkBox_DD[section + 1].Checked = false;
					});
					if (HW.mSections == 2)
					{
						while (label_B2.Location.X < label_DD[3].Location.X)
						{
							Thread.Sleep(m_debugrun_speed);
							Invoke((MethodInvoker)delegate
							{
								label_B2.Location = new Point(label_B2.Location.X + 1, label_B2.Location.Y);
							});
						}
						Invoke((MethodInvoker)delegate
						{
							label_B2.Visible = false;
							checkBox_DD[3].Checked = true;
							label_DD[3].BackColor = Color.SpringGreen;
						});
						Thread.Sleep(3);
					}
					if (checkBox_IsBTC2.Checked && (HW.mSections == 2 || HW.mSections == 3))
					{
						Invoke((MethodInvoker)delegate
						{
							label_B2.Visible = true;
							checkBox_DD[3].Checked = false;
							label_DD[3].BackColor = Color.LightGray;
						});
						while (label_B2.Location.X < label_DD[4].Location.X)
						{
							Thread.Sleep(m_debugrun_speed);
							Invoke((MethodInvoker)delegate
							{
								label_B2.Location = new Point(label_B2.Location.X + 1, label_B2.Location.Y);
							});
						}
						Invoke((MethodInvoker)delegate
						{
							label_B2.Visible = false;
							checkBox_DD[4].Checked = true;
							label_DD[4].BackColor = Color.SpringGreen;
						});
						Thread.Sleep(3);
					}
					mOutBoardState = QnCommon.BoardStateEn.Ok;
					return;
				}
				mOutBoardState = QnCommon.BoardStateEn.Busy;
				Invoke((MethodInvoker)delegate
				{
					label_B2.Location = label_S[2].Location;
					label_B2.BringToFront();
					label_B2.Visible = true;
					checkBox_S[2].Checked = false;
					checkBox_M[1].Checked = true;
					checkBox_M[2].Checked = true;
				});
				while (label_B2.Location.X < label_S[3].Location.X)
				{
					Thread.Sleep(m_debugrun_speed);
					Invoke((MethodInvoker)delegate
					{
						label_B2.Location = new Point(label_B2.Location.X + 1, label_B2.Location.Y);
						if (label_B2.Location.X == label_S[2].Location.X + 50)
						{
							checkBox_M[1].Checked = false;
						}
					});
				}
				Invoke((MethodInvoker)delegate
				{
					label_B2.Visible = false;
					checkBox_S[3].Checked = true;
					checkBox_M[2].Checked = false;
				});
				mOutBoardState = QnCommon.BoardStateEn.Ok;
				return;
			}
			mOutBoardState = QnCommon.BoardStateEn.Busy;
			Invoke((MethodInvoker)delegate
			{
				label_B2.Location = label_D[1].Location;
				label_B2.BringToFront();
				label_B2.Visible = true;
				checkBox_D[1].Checked = false;
			});
			while (label_B2.Location.X < label_D[2].Location.X)
			{
				Thread.Sleep(m_debugrun_speed);
				Invoke((MethodInvoker)delegate
				{
					label_B2.Location = new Point(label_B2.Location.X + 1, label_B2.Location.Y);
				});
			}
			Invoke((MethodInvoker)delegate
			{
				label_B2.Visible = false;
				checkBox_D[2].Checked = true;
				label_D[2].BackColor = Color.SpringGreen;
			});
			Thread.Sleep(3);
			if (checkBox_IsBTC.Checked)
			{
				Invoke((MethodInvoker)delegate
				{
					label_B2.Visible = true;
					checkBox_D[2].Checked = false;
					label_D[2].BackColor = Color.LightGray;
				});
				while (label_B2.Location.X < label_D[3].Location.X)
				{
					Thread.Sleep(m_debugrun_speed);
					Invoke((MethodInvoker)delegate
					{
						label_B2.Location = new Point(label_B2.Location.X + 1, label_B2.Location.Y);
					});
				}
				Invoke((MethodInvoker)delegate
				{
					label_B2.Visible = false;
					checkBox_D[3].Checked = true;
					label_D[3].BackColor = Color.SpringGreen;
				});
				Thread.Sleep(3);
			}
			mOutBoardState = QnCommon.BoardStateEn.Ok;
		}

		public void sendOutBoard()
		{
			if (mIsSanduanshi)
			{
				if (MainForm0.USR3B[mFn].mInBoardMode == 1)
				{
					if (HW.mSections == 2)
					{
						if (checkBox_DD[2].Checked && !checkBox_DD[3].Checked)
						{
							Thread thread = new Thread(thd_sendOutBoard);
							thread.IsBackground = true;
							thread.Start(1);
						}
					}
					else if (HW.mSections == 3 && checkBox_DD[3].Checked)
					{
						Thread thread2 = new Thread(thd_sendOutBoard);
						thread2.IsBackground = true;
						thread2.Start(2);
					}
				}
				else if (!checkBox_M[1].Checked && !checkBox_M[2].Checked && checkBox_S[2].Checked && !checkBox_S[3].Checked)
				{
					Thread thread3 = new Thread(thd_sendOutBoard);
					thread3.IsBackground = true;
					thread3.Start(0);
				}
			}
			else if (!checkBox_D[0].Checked && checkBox_D[1].Checked && !checkBox_D[2].Checked && (!checkBox_IsBTC.Checked || (checkBox_IsBTC.Checked && !checkBox_D[3].Checked)))
			{
				Thread thread4 = new Thread(thd_sendOutBoard);
				thread4.IsBackground = true;
				thread4.Start(0);
			}
		}

		private void button_Inborad_Click(object sender, EventArgs e)
		{
			sendInBoard();
		}

		private void button_OutBoard_Click(object sender, EventArgs e)
		{
			sendOutBoard();
		}

		public int get_S()
		{
			return mPlayWoodState_Sensor;
		}

		public int get_M()
		{
			return mPlayWoodState_Motor;
		}

		public QnCommon.BoardStateEn get_InB()
		{
			return mInBoardState;
		}

		public QnCommon.BoardStateEn get_OutB()
		{
			return mOutBoardState;
		}

		public bool get_IsNozzleDirty()
		{
			return checkBox_IsNozzleDirty.Checked;
		}

		public void set_InB(QnCommon.BoardStateEn state)
		{
			mInBoardState = state;
		}

		public void set_OutB(QnCommon.BoardStateEn state)
		{
			mOutBoardState = state;
		}

		private void thd_inboard_0()
		{
			Invoke((MethodInvoker)delegate
			{
				label_B0.Location = label_S[0].Location;
				label_B0.BringToFront();
				label_B0.Visible = true;
				checkBox_S[0].Checked = false;
				checkBox_M[0].Checked = true;
			});
			while (label_B0.Location.X < label_S[1].Location.X)
			{
				Thread.Sleep(3);
				Invoke((MethodInvoker)delegate
				{
					label_B0.Location = new Point(label_B0.Location.X + 1, label_B0.Location.Y);
				});
			}
			Invoke((MethodInvoker)delegate
			{
				label_B0.Visible = false;
				checkBox_S[1].Checked = true;
				checkBox_M[0].Checked = false;
			});
		}

		private void checkBox_S1_CheckedChanged(object sender, EventArgs e)
		{
			int num = (int)((CheckBox)sender).Tag;
			if (checkBox_S[num].Checked)
			{
				label_S[num].BackColor = Color.SpringGreen;
				if (num == 0 && !checkBox_S[1].Checked && !checkBox_M[0].Checked)
				{
					Thread thread = new Thread(thd_inboard_0);
					thread.IsBackground = true;
					thread.Start();
				}
			}
			else
			{
				if (num == 1 && checkBox_S[0].Checked)
				{
					Thread thread2 = new Thread(thd_inboard_0);
					thread2.IsBackground = true;
					thread2.Start();
				}
				label_S[num].BackColor = Color.LightGray;
			}
		}

		private void label_B2_Click(object sender, EventArgs e)
		{
		}

		private void numericUpDown_debugrun_speed_ValueChanged(object sender, EventArgs e)
		{
			m_debugrun_speed = (int)numericUpDown_debugrun_speed.Value;
		}

		private void checkBox_D1_CheckedChanged(object sender, EventArgs e)
		{
			int num = (int)((CheckBox)sender).Tag;
			label_D[num].BackColor = (checkBox_D[num].Checked ? Color.SpringGreen : Color.LightGray);
		}

		private void checkBox_DD1_CheckedChanged(object sender, EventArgs e)
		{
			int num = (int)((CheckBox)sender).Tag;
			label_DD[num].BackColor = (checkBox_DD[num].Checked ? Color.SpringGreen : Color.LightGray);
		}

		private void checkBox_IsBTC_CheckedChanged(object sender, EventArgs e)
		{
			Panel panel = panel17;
			Panel panel2 = panel18;
			Label label = label_D4;
			bool flag = (checkBox_D4.Visible = checkBox_IsBTC.Checked);
			bool flag3 = (label.Visible = flag);
			bool visible = (panel2.Visible = flag3);
			panel.Visible = visible;
		}

		private void button_scancode_Click(object sender, EventArgs e)
		{
			if (!checkBox_S[0].Checked)
			{
				mXiaohan_codelist.Add(textBox_scancode.Text);
				checkBox_S[0].Checked = true;
			}
		}

		private void button_ispcbcodesmtsend_Click(object sender, EventArgs e)
		{
			mXiaohan_codeissmtlist.Add(textBox_ispcbcodesmt.Text);
		}

		public void set_ScanCodeList(BindingList<string> codelist)
		{
			mXiaohan_codelist = codelist;
		}

		public void set_ScanCodeisSmtList(BindingList<string> codelist)
		{
			mXiaohan_codeissmtlist = codelist;
		}

		private void checkBox_IsBTC2_CheckedChanged(object sender, EventArgs e)
		{
		}
	}
}
