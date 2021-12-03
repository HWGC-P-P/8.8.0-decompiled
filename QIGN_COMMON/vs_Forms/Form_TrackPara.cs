using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_TrackPara : Form
	{
		private IContainer components;

		private Label label8;

		private Label label9;

		private Label label12;

		private NumericUpDown numericUpDown_delayL;

		private Label label13;

		private Label label14;

		private Label label19;

		private NumericUpDown numericUpDown_delayM;

		private Label label20;

		private NumericUpDown numericUpDown_delayR;

		private Label label21;

		private TrackBar trackBar_speed;

		private Label label_speed;

		private CnButton cnButton_OK;

		private CnButton cnButton_Cancel;

		private Label label15;

		private Label label17;

		private Label label18;

		private Label label22;

		private Label label23;

		private Label label24;

		private Label label25;

		private Label label26;

		private Label label27;

		private Label label28;

		private Label label29;

		private Panel panel1;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private Label label1;

		private Label label2;

		private Panel panel_hwdu;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label10;

		private Label label11;

		private Label label30;

		private Label label3;

		private Label label4;

		private Label label31;

		private Label label32;

		private Panel panel_3ds;

		private Panel panel_1ds;

		private Label label33;

		private Label label34;

		private Label label35;

		private Label label36;

		private Label label37;

		private Label label38;

		private Label label39;

		private Label label41;

		private Label label42;

		private Label label40;

		private Label label43;

		private Panel panel_dsq;

		private NumericUpDown numericUpDown_delay2;

		private TrackBar trackBar_speed2;

		private Label label_speed2;

		private TrackPara mTrack;

		private RadioButton[] radiobuttons_mode;

		private USR_INIT_DATA USR_INIT;

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
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			numericUpDown_delayL = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			numericUpDown_delayM = new System.Windows.Forms.NumericUpDown();
			label20 = new System.Windows.Forms.Label();
			numericUpDown_delayR = new System.Windows.Forms.NumericUpDown();
			label21 = new System.Windows.Forms.Label();
			trackBar_speed = new System.Windows.Forms.TrackBar();
			label_speed = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel_hwdu = new System.Windows.Forms.Panel();
			trackBar_speed2 = new System.Windows.Forms.TrackBar();
			numericUpDown_delay2 = new System.Windows.Forms.NumericUpDown();
			panel_1ds = new System.Windows.Forms.Panel();
			label33 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			label36 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			label42 = new System.Windows.Forms.Label();
			panel_3ds = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			label32 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label40 = new System.Windows.Forms.Label();
			label43 = new System.Windows.Forms.Label();
			label_speed2 = new System.Windows.Forms.Label();
			panel_dsq = new System.Windows.Forms.Panel();
			cnButton_Cancel = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_OK = new QIGN_COMMON.vs_acontrol.CnButton();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delayL).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delayM).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delayR).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_speed).BeginInit();
			panel1.SuspendLayout();
			panel_hwdu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_speed2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delay2).BeginInit();
			panel_1ds.SuspendLayout();
			panel_3ds.SuspendLayout();
			panel_dsq.SuspendLayout();
			SuspendLayout();
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("黑体", 12.5f);
			label8.Location = new System.Drawing.Point(123, 15);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(80, 17);
			label8.TabIndex = 1;
			label8.Text = "左机轨道";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("黑体", 12.5f);
			label9.Location = new System.Drawing.Point(553, 15);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(80, 17);
			label9.TabIndex = 1;
			label9.Text = "右机轨道";
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("黑体", 12.5f);
			label12.Location = new System.Drawing.Point(322, 15);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(98, 17);
			label12.TabIndex = 1;
			label12.Text = "待命区轨道";
			numericUpDown_delayL.DecimalPlaces = 2;
			numericUpDown_delayL.Font = new System.Drawing.Font("黑体", 11.5f);
			numericUpDown_delayL.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_delayL.Location = new System.Drawing.Point(169, 141);
			numericUpDown_delayL.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_delayL.Name = "numericUpDown_delayL";
			numericUpDown_delayL.Size = new System.Drawing.Size(72, 25);
			numericUpDown_delayL.TabIndex = 2;
			numericUpDown_delayL.ValueChanged += new System.EventHandler(numericUpDown_delayL_ValueChanged);
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("黑体", 12.5f);
			label13.Location = new System.Drawing.Point(50, 144);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(116, 17);
			label13.TabIndex = 1;
			label13.Text = "左机出板延时";
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("黑体", 16.5f);
			label14.Location = new System.Drawing.Point(289, 21);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(230, 22);
			label14.TabIndex = 1;
			label14.Text = "传板轨道参数总体设置";
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("黑体", 12.5f);
			label19.Location = new System.Drawing.Point(274, 144);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(134, 17);
			label19.TabIndex = 1;
			label19.Text = "待命区出板延时";
			numericUpDown_delayM.DecimalPlaces = 2;
			numericUpDown_delayM.Font = new System.Drawing.Font("黑体", 11.5f);
			numericUpDown_delayM.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_delayM.Location = new System.Drawing.Point(414, 141);
			numericUpDown_delayM.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_delayM.Name = "numericUpDown_delayM";
			numericUpDown_delayM.Size = new System.Drawing.Size(75, 25);
			numericUpDown_delayM.TabIndex = 2;
			numericUpDown_delayM.ValueChanged += new System.EventHandler(numericUpDown_delayM_ValueChanged);
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("黑体", 12.5f);
			label20.Location = new System.Drawing.Point(505, 144);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(116, 17);
			label20.TabIndex = 1;
			label20.Text = "右机出板延时";
			numericUpDown_delayR.DecimalPlaces = 2;
			numericUpDown_delayR.Font = new System.Drawing.Font("黑体", 11.5f);
			numericUpDown_delayR.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_delayR.Location = new System.Drawing.Point(625, 141);
			numericUpDown_delayR.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_delayR.Name = "numericUpDown_delayR";
			numericUpDown_delayR.Size = new System.Drawing.Size(81, 25);
			numericUpDown_delayR.TabIndex = 2;
			numericUpDown_delayR.ValueChanged += new System.EventHandler(numericUpDown_delayR_ValueChanged);
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("黑体", 12.5f);
			label21.Location = new System.Drawing.Point(50, 213);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(116, 17);
			label21.TabIndex = 1;
			label21.Text = "总体传板速度";
			trackBar_speed.LargeChange = 1;
			trackBar_speed.Location = new System.Drawing.Point(183, 213);
			trackBar_speed.Maximum = 9;
			trackBar_speed.Name = "trackBar_speed";
			trackBar_speed.Size = new System.Drawing.Size(163, 45);
			trackBar_speed.TabIndex = 3;
			trackBar_speed.Value = 7;
			trackBar_speed.Scroll += new System.EventHandler(trackBar_speed_Scroll);
			label_speed.BackColor = System.Drawing.Color.White;
			label_speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_speed.Font = new System.Drawing.Font("黑体", 14f);
			label_speed.Location = new System.Drawing.Point(352, 201);
			label_speed.Name = "label_speed";
			label_speed.Size = new System.Drawing.Size(38, 40);
			label_speed.TabIndex = 1;
			label_speed.Text = "7";
			label_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label15.BackColor = System.Drawing.Color.Black;
			label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label15.Location = new System.Drawing.Point(284, 45);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(158, 8);
			label15.TabIndex = 0;
			label15.Text = "label1";
			label17.BackColor = System.Drawing.Color.Black;
			label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label17.Location = new System.Drawing.Point(456, 125);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(258, 8);
			label17.TabIndex = 0;
			label17.Text = "label1";
			label18.BackColor = System.Drawing.Color.Black;
			label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label18.Location = new System.Drawing.Point(284, 125);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(158, 8);
			label18.TabIndex = 0;
			label18.Text = "label1";
			label22.BackColor = System.Drawing.Color.Black;
			label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label22.Location = new System.Drawing.Point(12, 125);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(258, 8);
			label22.TabIndex = 0;
			label22.Text = "label1";
			label23.BackColor = System.Drawing.Color.Black;
			label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label23.Location = new System.Drawing.Point(12, 45);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(258, 8);
			label23.TabIndex = 0;
			label23.Text = "label1";
			label24.BackColor = System.Drawing.Color.Black;
			label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label24.Location = new System.Drawing.Point(456, 45);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(258, 8);
			label24.TabIndex = 0;
			label24.Text = "label1";
			label25.BackColor = System.Drawing.Color.Silver;
			label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label25.Font = new System.Drawing.Font("黑体", 12.5f);
			label25.Location = new System.Drawing.Point(12, 45);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(58, 86);
			label25.TabIndex = 0;
			label25.Text = "左机入口";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label26.Font = new System.Drawing.Font("黑体", 12.5f);
			label26.Location = new System.Drawing.Point(194, 47);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(58, 86);
			label26.TabIndex = 0;
			label26.Text = "左机贴板";
			label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label27.BackColor = System.Drawing.Color.Silver;
			label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label27.Font = new System.Drawing.Font("黑体", 12.5f);
			label27.Location = new System.Drawing.Point(362, 45);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(58, 86);
			label27.TabIndex = 0;
			label27.Text = "缓冲区";
			label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label28.Font = new System.Drawing.Font("黑体", 12.5f);
			label28.Location = new System.Drawing.Point(579, 45);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(58, 86);
			label28.TabIndex = 0;
			label28.Text = "右机贴板";
			label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label29.BackColor = System.Drawing.Color.Silver;
			label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label29.Font = new System.Drawing.Font("黑体", 12.5f);
			label29.Location = new System.Drawing.Point(656, 45);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(58, 86);
			label29.TabIndex = 0;
			label29.Text = "右机出口";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel1.BackColor = System.Drawing.Color.DimGray;
			panel1.Controls.Add(radioButton2);
			panel1.Controls.Add(radioButton1);
			panel1.Location = new System.Drawing.Point(449, 201);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(265, 56);
			panel1.TabIndex = 5;
			radioButton2.AutoSize = true;
			radioButton2.Font = new System.Drawing.Font("黑体", 12.5f);
			radioButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			radioButton2.Location = new System.Drawing.Point(6, 28);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(251, 21);
			radioButton2.TabIndex = 0;
			radioButton2.Text = "长板模式（最大600mm板长）";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Checked = true;
			radioButton1.Font = new System.Drawing.Font("黑体", 12.5f);
			radioButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			radioButton1.Location = new System.Drawing.Point(6, 3);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(98, 21);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "标准模式";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton1.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			label1.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.Font = new System.Drawing.Font("黑体", 12.5f);
			label1.Location = new System.Drawing.Point(549, 47);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(165, 86);
			label1.TabIndex = 0;
			label1.Text = "右机贴板";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label1.Visible = false;
			label2.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Font = new System.Drawing.Font("黑体", 12.5f);
			label2.Location = new System.Drawing.Point(87, 45);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(165, 86);
			label2.TabIndex = 0;
			label2.Text = "左机贴板";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.Visible = false;
			panel_hwdu.Controls.Add(trackBar_speed2);
			panel_hwdu.Controls.Add(numericUpDown_delay2);
			panel_hwdu.Controls.Add(panel_1ds);
			panel_hwdu.Controls.Add(panel_3ds);
			panel_hwdu.Controls.Add(label40);
			panel_hwdu.Controls.Add(label43);
			panel_hwdu.Controls.Add(label_speed2);
			panel_hwdu.Location = new System.Drawing.Point(800, 67);
			panel_hwdu.Name = "panel_hwdu";
			panel_hwdu.Size = new System.Drawing.Size(769, 281);
			panel_hwdu.TabIndex = 6;
			trackBar_speed2.LargeChange = 1;
			trackBar_speed2.Location = new System.Drawing.Point(109, 201);
			trackBar_speed2.Maximum = 9;
			trackBar_speed2.Name = "trackBar_speed2";
			trackBar_speed2.Size = new System.Drawing.Size(125, 45);
			trackBar_speed2.TabIndex = 3;
			trackBar_speed2.Value = 7;
			trackBar_speed2.Scroll += new System.EventHandler(trackBar_speed2_Scroll);
			numericUpDown_delay2.DecimalPlaces = 2;
			numericUpDown_delay2.Font = new System.Drawing.Font("黑体", 11.5f);
			numericUpDown_delay2.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_delay2.Location = new System.Drawing.Point(114, 159);
			numericUpDown_delay2.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_delay2.Name = "numericUpDown_delay2";
			numericUpDown_delay2.Size = new System.Drawing.Size(120, 25);
			numericUpDown_delay2.TabIndex = 2;
			panel_1ds.Controls.Add(label33);
			panel_1ds.Controls.Add(label34);
			panel_1ds.Controls.Add(label35);
			panel_1ds.Controls.Add(label36);
			panel_1ds.Controls.Add(label37);
			panel_1ds.Controls.Add(label38);
			panel_1ds.Controls.Add(label39);
			panel_1ds.Controls.Add(label41);
			panel_1ds.Controls.Add(label42);
			panel_1ds.Location = new System.Drawing.Point(3, 13);
			panel_1ds.Name = "panel_1ds";
			panel_1ds.Size = new System.Drawing.Size(628, 116);
			panel_1ds.TabIndex = 1;
			panel_1ds.Visible = false;
			label33.BackColor = System.Drawing.Color.Black;
			label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label33.Location = new System.Drawing.Point(187, 13);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(288, 8);
			label33.TabIndex = 0;
			label33.Text = "label1";
			label34.BackColor = System.Drawing.Color.Black;
			label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label34.Location = new System.Drawing.Point(456, 93);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(158, 8);
			label34.TabIndex = 0;
			label34.Text = "label1";
			label35.BackColor = System.Drawing.Color.Black;
			label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label35.Location = new System.Drawing.Point(187, 93);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(288, 8);
			label35.TabIndex = 0;
			label35.Text = "label1";
			label36.BackColor = System.Drawing.Color.Black;
			label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label36.Location = new System.Drawing.Point(11, 93);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(198, 8);
			label36.TabIndex = 0;
			label36.Text = "label1";
			label37.BackColor = System.Drawing.Color.Black;
			label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label37.Location = new System.Drawing.Point(11, 13);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(198, 8);
			label37.TabIndex = 0;
			label37.Text = "label1";
			label38.BackColor = System.Drawing.Color.Black;
			label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label38.Location = new System.Drawing.Point(456, 13);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(158, 8);
			label38.TabIndex = 0;
			label38.Text = "label1";
			label39.BackColor = System.Drawing.Color.Silver;
			label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label39.Font = new System.Drawing.Font("黑体", 12.5f);
			label39.Location = new System.Drawing.Point(546, 13);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(58, 86);
			label39.TabIndex = 0;
			label39.Text = "出口";
			label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label41.BackColor = System.Drawing.Color.Silver;
			label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label41.Font = new System.Drawing.Font("黑体", 12.5f);
			label41.Location = new System.Drawing.Point(11, 13);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(58, 86);
			label41.TabIndex = 0;
			label41.Text = "入口";
			label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label42.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label42.Font = new System.Drawing.Font("黑体", 12.5f);
			label42.Location = new System.Drawing.Point(325, 15);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(58, 86);
			label42.TabIndex = 0;
			label42.Text = "贴板";
			label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_3ds.Controls.Add(label5);
			panel_3ds.Controls.Add(label6);
			panel_3ds.Controls.Add(label7);
			panel_3ds.Controls.Add(label10);
			panel_3ds.Controls.Add(label11);
			panel_3ds.Controls.Add(label30);
			panel_3ds.Controls.Add(label32);
			panel_3ds.Controls.Add(label31);
			panel_3ds.Controls.Add(label3);
			panel_3ds.Controls.Add(label4);
			panel_3ds.Location = new System.Drawing.Point(3, 14);
			panel_3ds.Name = "panel_3ds";
			panel_3ds.Size = new System.Drawing.Size(628, 116);
			panel_3ds.TabIndex = 1;
			panel_3ds.Visible = false;
			label5.BackColor = System.Drawing.Color.Black;
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Location = new System.Drawing.Point(187, 13);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(258, 8);
			label5.TabIndex = 0;
			label5.Text = "label1";
			label6.BackColor = System.Drawing.Color.Black;
			label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label6.Location = new System.Drawing.Point(456, 93);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(158, 8);
			label6.TabIndex = 0;
			label6.Text = "label1";
			label7.BackColor = System.Drawing.Color.Black;
			label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label7.Location = new System.Drawing.Point(187, 93);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(258, 8);
			label7.TabIndex = 0;
			label7.Text = "label1";
			label10.BackColor = System.Drawing.Color.Black;
			label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label10.Location = new System.Drawing.Point(11, 93);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(158, 8);
			label10.TabIndex = 0;
			label10.Text = "label1";
			label11.BackColor = System.Drawing.Color.Black;
			label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label11.Location = new System.Drawing.Point(11, 13);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(158, 8);
			label11.TabIndex = 0;
			label11.Text = "label1";
			label30.BackColor = System.Drawing.Color.Black;
			label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label30.Location = new System.Drawing.Point(456, 13);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(158, 8);
			label30.TabIndex = 0;
			label30.Text = "label1";
			label32.BackColor = System.Drawing.Color.Silver;
			label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label32.Font = new System.Drawing.Font("黑体", 12.5f);
			label32.Location = new System.Drawing.Point(546, 13);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(58, 86);
			label32.TabIndex = 0;
			label32.Text = "出口";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label31.BackColor = System.Drawing.Color.Silver;
			label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label31.Font = new System.Drawing.Font("黑体", 12.5f);
			label31.Location = new System.Drawing.Point(111, 15);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(58, 86);
			label31.TabIndex = 0;
			label31.Text = "等待";
			label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.BackColor = System.Drawing.Color.Silver;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.Font = new System.Drawing.Font("黑体", 12.5f);
			label3.Location = new System.Drawing.Point(11, 13);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(58, 86);
			label3.TabIndex = 0;
			label3.Text = "入口";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Font = new System.Drawing.Font("黑体", 12.5f);
			label4.Location = new System.Drawing.Point(325, 15);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(58, 86);
			label4.TabIndex = 0;
			label4.Text = "贴板";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label40.AutoSize = true;
			label40.Font = new System.Drawing.Font("黑体", 12.5f);
			label40.Location = new System.Drawing.Point(23, 159);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(80, 17);
			label40.TabIndex = 1;
			label40.Text = "出板延时";
			label43.AutoSize = true;
			label43.Font = new System.Drawing.Font("黑体", 12.5f);
			label43.Location = new System.Drawing.Point(23, 200);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(80, 17);
			label43.TabIndex = 1;
			label43.Text = "传板速度";
			label_speed2.BackColor = System.Drawing.Color.White;
			label_speed2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_speed2.Font = new System.Drawing.Font("黑体", 14f);
			label_speed2.Location = new System.Drawing.Point(253, 194);
			label_speed2.Name = "label_speed2";
			label_speed2.Size = new System.Drawing.Size(38, 40);
			label_speed2.TabIndex = 1;
			label_speed2.Text = "7";
			label_speed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_dsq.Controls.Add(panel1);
			panel_dsq.Controls.Add(trackBar_speed);
			panel_dsq.Controls.Add(numericUpDown_delayR);
			panel_dsq.Controls.Add(numericUpDown_delayM);
			panel_dsq.Controls.Add(numericUpDown_delayL);
			panel_dsq.Controls.Add(label24);
			panel_dsq.Controls.Add(label9);
			panel_dsq.Controls.Add(label12);
			panel_dsq.Controls.Add(label20);
			panel_dsq.Controls.Add(label19);
			panel_dsq.Controls.Add(label_speed);
			panel_dsq.Controls.Add(label21);
			panel_dsq.Controls.Add(label13);
			panel_dsq.Controls.Add(label8);
			panel_dsq.Controls.Add(label23);
			panel_dsq.Controls.Add(label22);
			panel_dsq.Controls.Add(label18);
			panel_dsq.Controls.Add(label17);
			panel_dsq.Controls.Add(label15);
			panel_dsq.Controls.Add(label27);
			panel_dsq.Controls.Add(label1);
			panel_dsq.Controls.Add(label25);
			panel_dsq.Controls.Add(label2);
			panel_dsq.Controls.Add(label29);
			panel_dsq.Controls.Add(label28);
			panel_dsq.Controls.Add(label26);
			panel_dsq.Location = new System.Drawing.Point(39, 67);
			panel_dsq.Name = "panel_dsq";
			panel_dsq.Size = new System.Drawing.Size(736, 282);
			panel_dsq.TabIndex = 7;
			cnButton_Cancel.BackColor = System.Drawing.Color.LightGray;
			cnButton_Cancel.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_Cancel.CnPressDownColor = System.Drawing.Color.White;
			cnButton_Cancel.Font = new System.Drawing.Font("黑体", 13f);
			cnButton_Cancel.Location = new System.Drawing.Point(467, 360);
			cnButton_Cancel.Name = "cnButton_Cancel";
			cnButton_Cancel.Size = new System.Drawing.Size(114, 36);
			cnButton_Cancel.TabIndex = 4;
			cnButton_Cancel.Text = "取消";
			cnButton_Cancel.UseVisualStyleBackColor = false;
			cnButton_Cancel.Click += new System.EventHandler(cnButton_Cancel_Click);
			cnButton_OK.BackColor = System.Drawing.Color.LightGray;
			cnButton_OK.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_OK.CnPressDownColor = System.Drawing.Color.White;
			cnButton_OK.Font = new System.Drawing.Font("黑体", 13f);
			cnButton_OK.Location = new System.Drawing.Point(233, 360);
			cnButton_OK.Name = "cnButton_OK";
			cnButton_OK.Size = new System.Drawing.Size(114, 36);
			cnButton_OK.TabIndex = 4;
			cnButton_OK.Text = "确定";
			cnButton_OK.UseVisualStyleBackColor = false;
			cnButton_OK.Click += new System.EventHandler(cnButton_OK_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(1410, 417);
			base.Controls.Add(panel_dsq);
			base.Controls.Add(panel_hwdu);
			base.Controls.Add(cnButton_Cancel);
			base.Controls.Add(cnButton_OK);
			base.Controls.Add(label14);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_TrackPara";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_TrackPara_Load);
			((System.ComponentModel.ISupportInitialize)numericUpDown_delayL).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delayM).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delayR).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_speed).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_hwdu.ResumeLayout(false);
			panel_hwdu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_speed2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delay2).EndInit();
			panel_1ds.ResumeLayout(false);
			panel_3ds.ResumeLayout(false);
			panel_dsq.ResumeLayout(false);
			panel_dsq.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_TrackPara()
		{
			InitializeComponent();
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			base.Size = new Size(850, base.Height);
			panel_hwdu.Location = panel_dsq.Location;
			if (HW.mDeviceType == DeviceType.DSQ800_120F)
			{
				panel_dsq.Visible = true;
				panel_hwdu.Visible = false;
			}
			else
			{
				panel_dsq.Visible = false;
				panel_hwdu.Visible = true;
				panel_1ds.Location = panel_3ds.Location;
				if (HW.mIsSanduanshi)
				{
					panel_3ds.Visible = true;
				}
				else
				{
					panel_1ds.Visible = true;
				}
			}
			if (HW.mDeviceType == DeviceType.DSQ800_120F)
			{
				radiobuttons_mode = new RadioButton[2] { radioButton1, radioButton2 };
				if (MainForm0.USR_INIT.mTrack != null)
				{
					numericUpDown_delayL.Value = (decimal)MainForm0.USR_INIT.mTrack.delayL;
					numericUpDown_delayM.Value = (decimal)MainForm0.USR_INIT.mTrack.delayM;
					numericUpDown_delayR.Value = (decimal)MainForm0.USR_INIT.mTrack.delayR;
					trackBar_speed.Value = MainForm0.USR_INIT.mTrack.speed;
					label_speed.Text = MainForm0.USR_INIT.mTrack.speed.ToString();
					radiobuttons_mode[MainForm0.USR_INIT.mTrack.mode].Checked = true;
					label1.Visible = (label2.Visible = ((MainForm0.USR_INIT.mTrack.mode != 0) ? true : false));
					panel1.Visible = MainForm0.USR_INIT.mSmtSubDevice == 1;
				}
			}
			else if (MainForm0.USR[0] != null)
			{
				numericUpDown_delay2.Value = (decimal)MainForm0.USR[0].mTrackDelay;
				trackBar_speed2.Value = MainForm0.USR[0].mTrackSpeed;
				label_speed2.Text = MainForm0.USR[0].mTrackSpeed.ToString();
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label14,
				str = new string[3] { "传板轨道参数总体设置", "传板轨道参数总体设置", "Track Totally Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label41,
				str = new string[3] { "入口", "入口", "Enter" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label42,
				str = new string[3] { "贴板", "贴板", "SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label39,
				str = new string[3] { "出口", "出口", "Exit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label40,
				str = new string[3] { "出板延时", "出板延时", "Output Delay" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label43,
				str = new string[3] { "传板速度", "传板速度", "Track Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_OK,
				str = new string[3] { "确定", "确定", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_Cancel,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label8,
				str = new string[3] { "左机轨道", "左机轨道", "Left Track" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label12,
				str = new string[3] { "缓冲区轨道", "缓冲区轨道", "Middle Track" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label9,
				str = new string[3] { "右机轨道", "右机轨道", "Right Track" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label25,
				str = new string[3] { "左机入口", "左机入口", "Left Enter" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "左机贴板", "左机贴板", "Left SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label27,
				str = new string[3] { "缓冲区", "缓冲区", "Middle Area" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "右机贴板", "右机贴板", "Right SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label26,
				str = new string[3] { "左机贴板", "左机贴板", "Left SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label28,
				str = new string[3] { "右机贴板", "右机贴板", "Right SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label29,
				str = new string[3] { "右机出口", "右机出口", "Right Exit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label13,
				str = new string[3] { "左机出板延时", "左机出板延时", "Left Output Delay" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label19,
				str = new string[3] { "待命区出板延时", "待命区出板延时", "Middle Output Delay" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label20,
				str = new string[3] { "右机出板延时", "右机出板延时", "Right Output Delay" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label28,
				str = new string[3] { "右机贴板", "右机贴板", "Right SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label21,
				str = new string[3] { "总体传板速度", "总体传板速度", "Totally Track Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton1,
				str = new string[3] { "标准模式", "标准模式", "Standard Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton2,
				str = new string[3] { "长板模式（最大600mm板长）", "长板模式（最大600mm板长）", "Long PCB Mode (600mm Most)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "入口", "入口", "Enter" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label31,
				str = new string[3] { "等待", "等待", "Buffer" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "贴板", "贴板", "SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label32,
				str = new string[3] { "出口", "出口", "Exit" }
			});
			return list;
		}

		private void cnButton_OK_Click(object sender, EventArgs e)
		{
			if (HW.mDeviceType == DeviceType.DSQ800_120F)
			{
				if (MainForm0.USR_INIT.mTrack != null)
				{
					MainForm0.USR_INIT.mTrack.delayL = (float)numericUpDown_delayL.Value;
					MainForm0.USR_INIT.mTrack.delayM = (float)numericUpDown_delayM.Value;
					MainForm0.USR_INIT.mTrack.delayR = (float)numericUpDown_delayR.Value;
					MainForm0.USR_INIT.mTrack.speed = trackBar_speed.Value;
					MainForm0.USR_INIT.mTrack.mode = ((!radiobuttons_mode[0].Checked) ? 1 : 0);
				}
				if (MainForm0.USR3_INIT != null && MainForm0.USR3_INIT.mTrack != null)
				{
					MainForm0.USR3_INIT.mTrack.delayL = (float)numericUpDown_delayL.Value;
					MainForm0.USR3_INIT.mTrack.delayM = (float)numericUpDown_delayM.Value;
					MainForm0.USR3_INIT.mTrack.delayR = (float)numericUpDown_delayR.Value;
					MainForm0.USR3_INIT.mTrack.speed = trackBar_speed.Value;
					MainForm0.USR3_INIT.mTrack.mode = ((!radiobuttons_mode[0].Checked) ? 1 : 0);
				}
			}
			else
			{
				if (MainForm0.USR[0] != null)
				{
					MainForm0.USR[0].mTrackDelay = (float)numericUpDown_delay2.Value;
					MainForm0.USR[0].mTrackSpeed = trackBar_speed2.Value;
				}
				if (MainForm0.USR3B[0] != null)
				{
					MainForm0.USR3B[0].mTrackDelay = (float)numericUpDown_delay2.Value;
					MainForm0.USR3B[0].mTrackSpeed = trackBar_speed2.Value;
				}
			}
			base.DialogResult = DialogResult.OK;
		}

		private void cnButton_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void trackBar_speed_Scroll(object sender, EventArgs e)
		{
			label_speed.Text = trackBar_speed.Value.ToString();
		}

		private void numericUpDown_delayL_ValueChanged(object sender, EventArgs e)
		{
			float num = (float)numericUpDown_delayL.Value;
			if ((double)num < 0.25)
			{
				numericUpDown_delayL.Value = 0.25m;
			}
		}

		private void numericUpDown_delayM_ValueChanged(object sender, EventArgs e)
		{
			float num = (float)numericUpDown_delayM.Value;
			if ((double)num < 0.25)
			{
				numericUpDown_delayM.Value = 0.25m;
			}
		}

		private void numericUpDown_delayR_ValueChanged(object sender, EventArgs e)
		{
			float num = (float)numericUpDown_delayR.Value;
			if ((double)num < 0.25)
			{
				numericUpDown_delayR.Value = 0.25m;
			}
		}

		private void Form_TrackPara_Load(object sender, EventArgs e)
		{
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			Label label = label1;
			bool visible = (label2.Visible = ((!radioButton1.Checked) ? true : false));
			label.Visible = visible;
		}

		private void trackBar_speed2_Scroll(object sender, EventArgs e)
		{
			label_speed2.Text = trackBar_speed2.Value.ToString();
		}
	}
}
