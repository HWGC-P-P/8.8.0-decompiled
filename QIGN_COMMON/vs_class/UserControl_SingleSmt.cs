using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_SingleSmt : UserControl
	{
		private IContainer components;

		private CnButton cnButton_vsplus_startsmt;

		private CnButton cnButton_vsplus_continuesmt;

		private CnButton cnButton_PauseSmt;

		private Label label_chips;

		private Label label_pcbs;

		private Label label_finishrate;

		private Label label_avespeed;

		private Label label_maxspeed;

		private ProgressBar progressBar;

		private CheckBox checkbox_jebotai;

		private Label label16;

		private Label label5;

		private Label label7;

		private Label label8;

		private Panel panel32;

		private Label label_smtASpeed;

		private TrackBar trackBar_smtASpeed;

		private Label label_smt_XYspeed;

		private Label label_smtXYSpeed;

		private TrackBar trackBar_smtXYSpeed;

		private Label label_smt_Aspeed;

		private CheckBox checkBox_FinishAutoSmt;

		private Panel panel_smtshoware;

		private CheckBox checkBox_flashlight;

		private CnButton cnButton_vsplus_stopsmt;

		private Label label_vsplus_smtmode;

		private CnButton cnButton_vsplus_setsmt;

		private CnButton cnButton_SmtVisualShow;

		private Label label_haiba;

		private Label label9;

		private Label label_SmtIndexNo;

		private Label label12;

		private Label label_jiebotai;

		private CnButton cnButton_vsplus_startsmt2;

		private Label label_SmtState;

		private Panel panel1;

		private Panel panel_fakepcb_smt;

		private CnButton cnButton_Loukong_clearS3;

		private Panel panel_more_setting;

		private CnButton cnButton_isMount;

		private CnButton cnButton_platestartindex;

		private CnButton cnButton_vsplus_setsmt2;

		private CnButton cnButton_more_settinh_close;

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
			label_chips = new System.Windows.Forms.Label();
			label_pcbs = new System.Windows.Forms.Label();
			label_finishrate = new System.Windows.Forms.Label();
			label_avespeed = new System.Windows.Forms.Label();
			label_maxspeed = new System.Windows.Forms.Label();
			progressBar = new System.Windows.Forms.ProgressBar();
			checkbox_jebotai = new System.Windows.Forms.CheckBox();
			label16 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			panel32 = new System.Windows.Forms.Panel();
			label_smtASpeed = new System.Windows.Forms.Label();
			trackBar_smtASpeed = new System.Windows.Forms.TrackBar();
			label_smt_XYspeed = new System.Windows.Forms.Label();
			label_smtXYSpeed = new System.Windows.Forms.Label();
			trackBar_smtXYSpeed = new System.Windows.Forms.TrackBar();
			label_smt_Aspeed = new System.Windows.Forms.Label();
			checkBox_FinishAutoSmt = new System.Windows.Forms.CheckBox();
			checkBox_flashlight = new System.Windows.Forms.CheckBox();
			panel_smtshoware = new System.Windows.Forms.Panel();
			panel_fakepcb_smt = new System.Windows.Forms.Panel();
			label_vsplus_smtmode = new System.Windows.Forms.Label();
			label_haiba = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label_SmtIndexNo = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label_jiebotai = new System.Windows.Forms.Label();
			label_SmtState = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			panel_more_setting = new System.Windows.Forms.Panel();
			cnButton_vsplus_startsmt = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_Loukong_clearS3 = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_SmtVisualShow = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_vsplus_stopsmt = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_PauseSmt = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_vsplus_startsmt2 = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_vsplus_continuesmt = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_vsplus_setsmt = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_more_settinh_close = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_vsplus_setsmt2 = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_platestartindex = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_isMount = new QIGN_COMMON.vs_acontrol.CnButton();
			panel32.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_smtASpeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_smtXYSpeed).BeginInit();
			panel_smtshoware.SuspendLayout();
			panel_fakepcb_smt.SuspendLayout();
			panel1.SuspendLayout();
			panel_more_setting.SuspendLayout();
			SuspendLayout();
			label_chips.BackColor = System.Drawing.Color.White;
			label_chips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_chips.Font = new System.Drawing.Font("黑体", 14.5f);
			label_chips.Location = new System.Drawing.Point(108, 101);
			label_chips.Name = "label_chips";
			label_chips.Size = new System.Drawing.Size(75, 32);
			label_chips.TabIndex = 1;
			label_chips.Text = "0";
			label_chips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_pcbs.BackColor = System.Drawing.Color.White;
			label_pcbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_pcbs.Font = new System.Drawing.Font("黑体", 14.5f);
			label_pcbs.Location = new System.Drawing.Point(190, 101);
			label_pcbs.Name = "label_pcbs";
			label_pcbs.Size = new System.Drawing.Size(75, 32);
			label_pcbs.TabIndex = 1;
			label_pcbs.Text = "0";
			label_pcbs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_finishrate.Font = new System.Drawing.Font("黑体", 18.5f);
			label_finishrate.Location = new System.Drawing.Point(507, 106);
			label_finishrate.Name = "label_finishrate";
			label_finishrate.Size = new System.Drawing.Size(94, 23);
			label_finishrate.TabIndex = 1;
			label_finishrate.Text = "100%";
			label_finishrate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_avespeed.BackColor = System.Drawing.Color.White;
			label_avespeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_avespeed.Font = new System.Drawing.Font("黑体", 14.5f);
			label_avespeed.Location = new System.Drawing.Point(271, 101);
			label_avespeed.Name = "label_avespeed";
			label_avespeed.Size = new System.Drawing.Size(75, 32);
			label_avespeed.TabIndex = 1;
			label_avespeed.Text = "0";
			label_avespeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_maxspeed.BackColor = System.Drawing.Color.White;
			label_maxspeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_maxspeed.Font = new System.Drawing.Font("黑体", 14.5f);
			label_maxspeed.Location = new System.Drawing.Point(351, 101);
			label_maxspeed.Name = "label_maxspeed";
			label_maxspeed.Size = new System.Drawing.Size(75, 32);
			label_maxspeed.TabIndex = 1;
			label_maxspeed.Text = "0";
			label_maxspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			progressBar.Location = new System.Drawing.Point(14, 74);
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(566, 23);
			progressBar.TabIndex = 2;
			checkbox_jebotai.AutoSize = true;
			checkbox_jebotai.Font = new System.Drawing.Font("黑体", 10.5f);
			checkbox_jebotai.ForeColor = System.Drawing.Color.White;
			checkbox_jebotai.Location = new System.Drawing.Point(305, 25);
			checkbox_jebotai.Name = "checkbox_jebotai";
			checkbox_jebotai.Size = new System.Drawing.Size(96, 18);
			checkbox_jebotai.TabIndex = 3;
			checkbox_jebotai.Text = "接驳台模式";
			checkbox_jebotai.UseVisualStyleBackColor = true;
			checkbox_jebotai.CheckedChanged += new System.EventHandler(checkbox_jebotai_CheckedChanged);
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("黑体", 11f);
			label16.Location = new System.Drawing.Point(104, 135);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(71, 15);
			label16.TabIndex = 4;
			label16.Text = "完成点数";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 11f);
			label5.Location = new System.Drawing.Point(187, 135);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(71, 15);
			label5.TabIndex = 4;
			label5.Text = "完成板组";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 11f);
			label7.Location = new System.Drawing.Point(265, 135);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(71, 15);
			label7.TabIndex = 4;
			label7.Text = "平均时速";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("黑体", 11f);
			label8.Location = new System.Drawing.Point(346, 135);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(71, 15);
			label8.TabIndex = 4;
			label8.Text = "最高时速";
			panel32.BackColor = System.Drawing.Color.DimGray;
			panel32.Controls.Add(cnButton_Loukong_clearS3);
			panel32.Controls.Add(cnButton_SmtVisualShow);
			panel32.Controls.Add(label_smtASpeed);
			panel32.Controls.Add(trackBar_smtASpeed);
			panel32.Controls.Add(label_smt_XYspeed);
			panel32.Controls.Add(label_smtXYSpeed);
			panel32.Controls.Add(trackBar_smtXYSpeed);
			panel32.Controls.Add(label_smt_Aspeed);
			panel32.Controls.Add(checkBox_FinishAutoSmt);
			panel32.Controls.Add(checkBox_flashlight);
			panel32.Controls.Add(checkbox_jebotai);
			panel32.Font = new System.Drawing.Font("黑体", 11.25f);
			panel32.Location = new System.Drawing.Point(14, 155);
			panel32.Name = "panel32";
			panel32.Size = new System.Drawing.Size(566, 47);
			panel32.TabIndex = 6;
			label_smtASpeed.AutoSize = true;
			label_smtASpeed.Font = new System.Drawing.Font("楷体", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smtASpeed.ForeColor = System.Drawing.Color.White;
			label_smtASpeed.Location = new System.Drawing.Point(170, 28);
			label_smtASpeed.Name = "label_smtASpeed";
			label_smtASpeed.Size = new System.Drawing.Size(21, 13);
			label_smtASpeed.TabIndex = 11;
			label_smtASpeed.Text = "64";
			trackBar_smtASpeed.Location = new System.Drawing.Point(66, 24);
			trackBar_smtASpeed.Maximum = 64;
			trackBar_smtASpeed.Minimum = 1;
			trackBar_smtASpeed.Name = "trackBar_smtASpeed";
			trackBar_smtASpeed.Size = new System.Drawing.Size(104, 45);
			trackBar_smtASpeed.TabIndex = 10;
			trackBar_smtASpeed.TickFrequency = 8;
			trackBar_smtASpeed.Value = 1;
			trackBar_smtASpeed.Scroll += new System.EventHandler(trackBar_smtASpeed_Scroll);
			label_smt_XYspeed.AutoSize = true;
			label_smt_XYspeed.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smt_XYspeed.ForeColor = System.Drawing.Color.White;
			label_smt_XYspeed.Location = new System.Drawing.Point(6, 5);
			label_smt_XYspeed.Name = "label_smt_XYspeed";
			label_smt_XYspeed.Size = new System.Drawing.Size(56, 14);
			label_smt_XYspeed.TabIndex = 6;
			label_smt_XYspeed.Text = "X-Y速度";
			label_smtXYSpeed.AutoSize = true;
			label_smtXYSpeed.Font = new System.Drawing.Font("楷体", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smtXYSpeed.ForeColor = System.Drawing.Color.White;
			label_smtXYSpeed.Location = new System.Drawing.Point(170, 4);
			label_smtXYSpeed.Name = "label_smtXYSpeed";
			label_smtXYSpeed.Size = new System.Drawing.Size(21, 13);
			label_smtXYSpeed.TabIndex = 11;
			label_smtXYSpeed.Text = "64";
			trackBar_smtXYSpeed.Location = new System.Drawing.Point(66, 2);
			trackBar_smtXYSpeed.Maximum = 64;
			trackBar_smtXYSpeed.Minimum = 1;
			trackBar_smtXYSpeed.Name = "trackBar_smtXYSpeed";
			trackBar_smtXYSpeed.Size = new System.Drawing.Size(104, 45);
			trackBar_smtXYSpeed.TabIndex = 10;
			trackBar_smtXYSpeed.TickFrequency = 8;
			trackBar_smtXYSpeed.Value = 1;
			trackBar_smtXYSpeed.Scroll += new System.EventHandler(trackBar_smtXYSpeed_Scroll);
			label_smt_Aspeed.AutoSize = true;
			label_smt_Aspeed.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smt_Aspeed.ForeColor = System.Drawing.Color.White;
			label_smt_Aspeed.Location = new System.Drawing.Point(4, 26);
			label_smt_Aspeed.Name = "label_smt_Aspeed";
			label_smt_Aspeed.Size = new System.Drawing.Size(63, 14);
			label_smt_Aspeed.TabIndex = 6;
			label_smt_Aspeed.Text = "旋转速度";
			checkBox_FinishAutoSmt.AutoSize = true;
			checkBox_FinishAutoSmt.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_FinishAutoSmt.ForeColor = System.Drawing.Color.White;
			checkBox_FinishAutoSmt.Location = new System.Drawing.Point(204, 25);
			checkBox_FinishAutoSmt.Name = "checkBox_FinishAutoSmt";
			checkBox_FinishAutoSmt.Size = new System.Drawing.Size(96, 18);
			checkBox_FinishAutoSmt.TabIndex = 3;
			checkBox_FinishAutoSmt.Text = "结束全自动";
			checkBox_FinishAutoSmt.UseVisualStyleBackColor = true;
			checkBox_FinishAutoSmt.CheckedChanged += new System.EventHandler(checkBox_FinishAutoSmt_CheckedChanged);
			checkBox_flashlight.AutoSize = true;
			checkBox_flashlight.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_flashlight.ForeColor = System.Drawing.Color.White;
			checkBox_flashlight.Location = new System.Drawing.Point(305, 4);
			checkBox_flashlight.Name = "checkBox_flashlight";
			checkBox_flashlight.Size = new System.Drawing.Size(96, 18);
			checkBox_flashlight.TabIndex = 3;
			checkBox_flashlight.Text = "闪光灯模式";
			checkBox_flashlight.UseVisualStyleBackColor = true;
			checkBox_flashlight.CheckedChanged += new System.EventHandler(checkBox_flashlight_CheckedChanged);
			panel_smtshoware.AutoScroll = true;
			panel_smtshoware.Controls.Add(panel_fakepcb_smt);
			panel_smtshoware.Location = new System.Drawing.Point(3, 211);
			panel_smtshoware.Name = "panel_smtshoware";
			panel_smtshoware.Size = new System.Drawing.Size(633, 661);
			panel_smtshoware.TabIndex = 7;
			panel_fakepcb_smt.Controls.Add(panel_more_setting);
			panel_fakepcb_smt.Location = new System.Drawing.Point(6, 6);
			panel_fakepcb_smt.Name = "panel_fakepcb_smt";
			panel_fakepcb_smt.Size = new System.Drawing.Size(620, 646);
			panel_fakepcb_smt.TabIndex = 0;
			label_vsplus_smtmode.Font = new System.Drawing.Font("黑体", 14.5f);
			label_vsplus_smtmode.Location = new System.Drawing.Point(14, 37);
			label_vsplus_smtmode.Name = "label_vsplus_smtmode";
			label_vsplus_smtmode.Size = new System.Drawing.Size(362, 32);
			label_vsplus_smtmode.TabIndex = 1;
			label_vsplus_smtmode.Text = "全自动贴装";
			label_vsplus_smtmode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_vsplus_smtmode.Visible = false;
			label_haiba.BackColor = System.Drawing.Color.White;
			label_haiba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_haiba.Font = new System.Drawing.Font("黑体", 14.5f);
			label_haiba.Location = new System.Drawing.Point(432, 101);
			label_haiba.Name = "label_haiba";
			label_haiba.Size = new System.Drawing.Size(75, 32);
			label_haiba.TabIndex = 1;
			label_haiba.Text = "0";
			label_haiba.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("黑体", 11f);
			label9.Location = new System.Drawing.Point(428, 135);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(103, 15);
			label9.TabIndex = 4;
			label9.Text = "当前海拔(mm)";
			label_SmtIndexNo.BackColor = System.Drawing.Color.White;
			label_SmtIndexNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_SmtIndexNo.Font = new System.Drawing.Font("黑体", 14.5f);
			label_SmtIndexNo.Location = new System.Drawing.Point(14, 101);
			label_SmtIndexNo.Name = "label_SmtIndexNo";
			label_SmtIndexNo.Size = new System.Drawing.Size(88, 32);
			label_SmtIndexNo.TabIndex = 1;
			label_SmtIndexNo.Text = "0";
			label_SmtIndexNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("黑体", 11f);
			label12.Location = new System.Drawing.Point(10, 136);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(71, 15);
			label12.TabIndex = 4;
			label12.Text = "当前标号";
			label_jiebotai.Font = new System.Drawing.Font("黑体", 14.5f);
			label_jiebotai.Location = new System.Drawing.Point(14, 74);
			label_jiebotai.Name = "label_jiebotai";
			label_jiebotai.Size = new System.Drawing.Size(566, 77);
			label_jiebotai.TabIndex = 1;
			label_jiebotai.Text = "接驳台模式";
			label_jiebotai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_jiebotai.Visible = false;
			label_SmtState.Font = new System.Drawing.Font("黑体", 14.5f);
			label_SmtState.Location = new System.Drawing.Point(12, -3);
			label_SmtState.Name = "label_SmtState";
			label_SmtState.Size = new System.Drawing.Size(566, 38);
			label_SmtState.TabIndex = 1;
			label_SmtState.Text = "空闲";
			label_SmtState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel1.Controls.Add(label_SmtState);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label16);
			panel1.Controls.Add(label_maxspeed);
			panel1.Controls.Add(label_haiba);
			panel1.Controls.Add(label_avespeed);
			panel1.Controls.Add(label_pcbs);
			panel1.Controls.Add(label_chips);
			panel1.Controls.Add(cnButton_vsplus_startsmt);
			panel1.Controls.Add(label_finishrate);
			panel1.Controls.Add(progressBar);
			panel1.Controls.Add(panel32);
			panel1.Controls.Add(label12);
			panel1.Controls.Add(label_SmtIndexNo);
			panel1.Controls.Add(cnButton_vsplus_stopsmt);
			panel1.Controls.Add(cnButton_PauseSmt);
			panel1.Controls.Add(cnButton_vsplus_startsmt2);
			panel1.Controls.Add(cnButton_vsplus_continuesmt);
			panel1.Controls.Add(label_jiebotai);
			panel1.Controls.Add(cnButton_vsplus_setsmt);
			panel1.Controls.Add(label_vsplus_smtmode);
			panel1.Location = new System.Drawing.Point(23, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(608, 205);
			panel1.TabIndex = 8;
			panel_more_setting.BackColor = System.Drawing.Color.White;
			panel_more_setting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_more_setting.Controls.Add(cnButton_more_settinh_close);
			panel_more_setting.Controls.Add(cnButton_vsplus_setsmt2);
			panel_more_setting.Controls.Add(cnButton_platestartindex);
			panel_more_setting.Controls.Add(cnButton_isMount);
			panel_more_setting.Location = new System.Drawing.Point(7, 31);
			panel_more_setting.Name = "panel_more_setting";
			panel_more_setting.Size = new System.Drawing.Size(586, 114);
			panel_more_setting.TabIndex = 0;
			panel_more_setting.Visible = false;
			cnButton_vsplus_startsmt.BackColor = System.Drawing.Color.DimGray;
			cnButton_vsplus_startsmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_vsplus_startsmt.CnPressDownColor = System.Drawing.Color.White;
			cnButton_vsplus_startsmt.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_vsplus_startsmt.ForeColor = System.Drawing.Color.White;
			cnButton_vsplus_startsmt.Location = new System.Drawing.Point(14, 37);
			cnButton_vsplus_startsmt.Name = "cnButton_vsplus_startsmt";
			cnButton_vsplus_startsmt.Size = new System.Drawing.Size(240, 32);
			cnButton_vsplus_startsmt.TabIndex = 0;
			cnButton_vsplus_startsmt.Text = "开始运行";
			cnButton_vsplus_startsmt.UseVisualStyleBackColor = false;
			cnButton_vsplus_startsmt.Click += new System.EventHandler(cnButton_vsplus_startsmt_Click);
			cnButton_Loukong_clearS3.BackColor = System.Drawing.Color.RosyBrown;
			cnButton_Loukong_clearS3.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_Loukong_clearS3.CnPressDownColor = System.Drawing.Color.White;
			cnButton_Loukong_clearS3.Font = new System.Drawing.Font("黑体", 10.25f);
			cnButton_Loukong_clearS3.Location = new System.Drawing.Point(471, 4);
			cnButton_Loukong_clearS3.Name = "cnButton_Loukong_clearS3";
			cnButton_Loukong_clearS3.Size = new System.Drawing.Size(91, 40);
			cnButton_Loukong_clearS3.TabIndex = 12;
			cnButton_Loukong_clearS3.Text = "出口位置PCB\r\n取走确认";
			cnButton_Loukong_clearS3.UseVisualStyleBackColor = false;
			cnButton_Loukong_clearS3.Visible = false;
			cnButton_Loukong_clearS3.Click += new System.EventHandler(cnButton_Loukong_clearS3_Click);
			cnButton_SmtVisualShow.BackColor = System.Drawing.SystemColors.ButtonFace;
			cnButton_SmtVisualShow.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_SmtVisualShow.CnPressDownColor = System.Drawing.Color.White;
			cnButton_SmtVisualShow.Font = new System.Drawing.Font("黑体", 11.5f);
			cnButton_SmtVisualShow.Location = new System.Drawing.Point(427, 4);
			cnButton_SmtVisualShow.Name = "cnButton_SmtVisualShow";
			cnButton_SmtVisualShow.Size = new System.Drawing.Size(42, 40);
			cnButton_SmtVisualShow.TabIndex = 0;
			cnButton_SmtVisualShow.Text = "视觉";
			cnButton_SmtVisualShow.UseVisualStyleBackColor = false;
			cnButton_SmtVisualShow.Click += new System.EventHandler(cnButton_SmtVisualShow_Click);
			cnButton_vsplus_stopsmt.BackColor = System.Drawing.SystemColors.Control;
			cnButton_vsplus_stopsmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_vsplus_stopsmt.CnPressDownColor = System.Drawing.Color.White;
			cnButton_vsplus_stopsmt.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_vsplus_stopsmt.Location = new System.Drawing.Point(483, 37);
			cnButton_vsplus_stopsmt.Name = "cnButton_vsplus_stopsmt";
			cnButton_vsplus_stopsmt.Size = new System.Drawing.Size(96, 32);
			cnButton_vsplus_stopsmt.TabIndex = 0;
			cnButton_vsplus_stopsmt.Text = "结束";
			cnButton_vsplus_stopsmt.UseVisualStyleBackColor = false;
			cnButton_vsplus_stopsmt.Visible = false;
			cnButton_vsplus_stopsmt.Click += new System.EventHandler(cnButton_vsplus_stopsmt_Click);
			cnButton_PauseSmt.BackColor = System.Drawing.SystemColors.Control;
			cnButton_PauseSmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.PressDown;
			cnButton_PauseSmt.CnPressDownColor = System.Drawing.Color.LightCoral;
			cnButton_PauseSmt.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_PauseSmt.Location = new System.Drawing.Point(381, 37);
			cnButton_PauseSmt.Name = "cnButton_PauseSmt";
			cnButton_PauseSmt.Size = new System.Drawing.Size(96, 32);
			cnButton_PauseSmt.TabIndex = 0;
			cnButton_PauseSmt.Tag = "pause";
			cnButton_PauseSmt.Text = "暂停";
			cnButton_PauseSmt.UseVisualStyleBackColor = false;
			cnButton_PauseSmt.Visible = false;
			cnButton_PauseSmt.Click += new System.EventHandler(cnButton_PauseSmt_Click);
			cnButton_vsplus_startsmt2.BackColor = System.Drawing.SystemColors.Control;
			cnButton_vsplus_startsmt2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_vsplus_startsmt2.CnPressDownColor = System.Drawing.Color.White;
			cnButton_vsplus_startsmt2.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_vsplus_startsmt2.Location = new System.Drawing.Point(16, 37);
			cnButton_vsplus_startsmt2.Name = "cnButton_vsplus_startsmt2";
			cnButton_vsplus_startsmt2.Size = new System.Drawing.Size(124, 32);
			cnButton_vsplus_startsmt2.TabIndex = 0;
			cnButton_vsplus_startsmt2.Text = "开始运行";
			cnButton_vsplus_startsmt2.UseVisualStyleBackColor = false;
			cnButton_vsplus_startsmt2.Click += new System.EventHandler(cnButton_vsplus_startsmt_Click);
			cnButton_vsplus_continuesmt.BackColor = System.Drawing.Color.DimGray;
			cnButton_vsplus_continuesmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_vsplus_continuesmt.CnPressDownColor = System.Drawing.Color.White;
			cnButton_vsplus_continuesmt.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_vsplus_continuesmt.ForeColor = System.Drawing.Color.White;
			cnButton_vsplus_continuesmt.Location = new System.Drawing.Point(144, 37);
			cnButton_vsplus_continuesmt.Name = "cnButton_vsplus_continuesmt";
			cnButton_vsplus_continuesmt.Size = new System.Drawing.Size(110, 32);
			cnButton_vsplus_continuesmt.TabIndex = 0;
			cnButton_vsplus_continuesmt.Text = "续贴";
			cnButton_vsplus_continuesmt.UseVisualStyleBackColor = false;
			cnButton_vsplus_continuesmt.Click += new System.EventHandler(cnButton_vsplus_continuesmt_Click);
			cnButton_vsplus_setsmt.BackColor = System.Drawing.SystemColors.ButtonFace;
			cnButton_vsplus_setsmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_vsplus_setsmt.CnPressDownColor = System.Drawing.Color.White;
			cnButton_vsplus_setsmt.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_vsplus_setsmt.Location = new System.Drawing.Point(260, 37);
			cnButton_vsplus_setsmt.Name = "cnButton_vsplus_setsmt";
			cnButton_vsplus_setsmt.Size = new System.Drawing.Size(116, 32);
			cnButton_vsplus_setsmt.TabIndex = 0;
			cnButton_vsplus_setsmt.Text = "更多设置..";
			cnButton_vsplus_setsmt.UseVisualStyleBackColor = false;
			cnButton_vsplus_setsmt.Click += new System.EventHandler(cnButton_vsplus_setsmt_Click);
			cnButton_more_settinh_close.BackColor = System.Drawing.SystemColors.ButtonFace;
			cnButton_more_settinh_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_more_settinh_close.CnPressDownColor = System.Drawing.Color.White;
			cnButton_more_settinh_close.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cnButton_more_settinh_close.Location = new System.Drawing.Point(543, 13);
			cnButton_more_settinh_close.Name = "cnButton_more_settinh_close";
			cnButton_more_settinh_close.Size = new System.Drawing.Size(30, 30);
			cnButton_more_settinh_close.TabIndex = 0;
			cnButton_more_settinh_close.Text = "X";
			cnButton_more_settinh_close.UseVisualStyleBackColor = false;
			cnButton_more_settinh_close.Click += new System.EventHandler(cnButton_more_settinh_close_Click);
			cnButton_vsplus_setsmt2.BackColor = System.Drawing.SystemColors.ButtonFace;
			cnButton_vsplus_setsmt2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_vsplus_setsmt2.CnPressDownColor = System.Drawing.Color.White;
			cnButton_vsplus_setsmt2.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_vsplus_setsmt2.Location = new System.Drawing.Point(428, 13);
			cnButton_vsplus_setsmt2.Name = "cnButton_vsplus_setsmt2";
			cnButton_vsplus_setsmt2.Size = new System.Drawing.Size(94, 48);
			cnButton_vsplus_setsmt2.TabIndex = 0;
			cnButton_vsplus_setsmt2.Text = "生产设置";
			cnButton_vsplus_setsmt2.UseVisualStyleBackColor = false;
			cnButton_vsplus_setsmt2.Click += new System.EventHandler(cnButton_vsplus_setsmt2_Click);
			cnButton_platestartindex.BackColor = System.Drawing.SystemColors.ButtonFace;
			cnButton_platestartindex.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_platestartindex.CnPressDownColor = System.Drawing.Color.White;
			cnButton_platestartindex.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_platestartindex.Location = new System.Drawing.Point(111, 13);
			cnButton_platestartindex.Name = "cnButton_platestartindex";
			cnButton_platestartindex.Size = new System.Drawing.Size(95, 48);
			cnButton_platestartindex.TabIndex = 0;
			cnButton_platestartindex.Text = "料盘起始";
			cnButton_platestartindex.UseVisualStyleBackColor = false;
			cnButton_platestartindex.Click += new System.EventHandler(cnButton_platestartindex_Click);
			cnButton_isMount.BackColor = System.Drawing.SystemColors.ButtonFace;
			cnButton_isMount.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_isMount.CnPressDownColor = System.Drawing.Color.White;
			cnButton_isMount.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_isMount.Location = new System.Drawing.Point(10, 13);
			cnButton_isMount.Name = "cnButton_isMount";
			cnButton_isMount.Size = new System.Drawing.Size(95, 48);
			cnButton_isMount.TabIndex = 0;
			cnButton_isMount.Text = "是否贴装";
			cnButton_isMount.UseVisualStyleBackColor = false;
			cnButton_isMount.Click += new System.EventHandler(cnButton_isMount_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(180, 180, 180);
			base.Controls.Add(panel1);
			base.Controls.Add(panel_smtshoware);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_SingleSmt";
			base.Size = new System.Drawing.Size(640, 907);
			base.Load += new System.EventHandler(UserControl_SingleSmt_Load);
			panel32.ResumeLayout(false);
			panel32.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_smtASpeed).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_smtXYSpeed).EndInit();
			panel_smtshoware.ResumeLayout(false);
			panel_fakepcb_smt.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_more_setting.ResumeLayout(false);
			ResumeLayout(false);
		}

		public UserControl_SingleSmt(int fn)
		{
			InitializeComponent();
			mFn = fn;
		}

		private void UserControl_SingleSmt_Load(object sender, EventArgs e)
		{
			checkbox_jebotai.Checked = MainForm0.USR3B[mFn].mIsJieBoTaiMode;
			checkBox_FinishAutoSmt.Checked = MainForm0.uc_job[mFn].bIsFinishAutoRun;
			checkBox_flashlight.Checked = MainForm0.USR3B[mFn].mIsFlashlightMode;
			trackBar_smtXYSpeed.Value = MainForm0.USR3B[mFn].mSmtXYSpeed;
			label_smtXYSpeed.Text = MainForm0.USR3B[mFn].mSmtXYSpeed.ToString();
			trackBar_smtASpeed.Value = MainForm0.USR3B[mFn].mSmtASpeed;
			label_smtASpeed.Text = MainForm0.USR3B[mFn].mSmtASpeed.ToString();
			panel_fakepcb_smt.Paint += panel_vsplus_fakepcb_Paint;
			base.Controls.Add(MainForm0.uc_VisualShowSmt[mFn]);
			MainForm0.uc_VisualShowSmt[mFn].set_mode(1);
			MainForm0.uc_VisualShowSmt[mFn].Location = new Point(1, panel_smtshoware.Location.Y);
			MainForm0.uc_VisualShowSmt[mFn].BringToFront();
			MainForm0.uc_VisualShowSmt[mFn].Visible = false;
			panel1.Controls.Add(panel_more_setting);
			panel_more_setting.Location = new Point(3, 37);
			panel_more_setting.Visible = false;
		}

		private void cnButton_vsplus_startsmt_Click(object sender, EventArgs e)
		{
			MainForm0.uc_job[mFn].vsplus_startsmt(0, 0f, SmtOpMode.Idle);
		}

		public void set_pause_stop_button_visiable(bool flag)
		{
			cnButton_PauseSmt.Visible = flag;
			cnButton_vsplus_stopsmt.Visible = flag;
		}

		public bool get_pause_stop_button_visable()
		{
			return cnButton_PauseSmt.Visible;
		}

		public void set_cnButton_vsplus_startsmt_visiable(bool flag)
		{
			cnButton_vsplus_startsmt.Visible = flag;
		}

		public void set_label_vsplus_smtmode_visiable(bool f)
		{
			label_vsplus_smtmode.Visible = f;
			label_vsplus_smtmode.BringToFront();
		}

		public void set_label_vsplus_smtmode_string(string s)
		{
			label_vsplus_smtmode.Text = s;
		}

		public void set_label_SmtState(string s)
		{
			label_SmtState.Text = s;
		}

		public void set_progress_bar_minvmax(int minv, int v, int maxv)
		{
			progressBar.Value = 0;
			progressBar.Minimum = minv;
			progressBar.Maximum = maxv;
			progressBar.Value = v;
			if (maxv > 0 && v <= maxv)
			{
				label_finishrate.Text = v * 100 / maxv + "%";
			}
		}

		public void set_progress_bar_v(int value)
		{
			if (value >= progressBar.Minimum && value <= progressBar.Maximum && progressBar.Maximum > 0)
			{
				progressBar.Value = value;
				label_finishrate.Text = value * 100 / progressBar.Maximum + "%";
			}
		}

		public void set_avespeed(int value)
		{
			label_avespeed.Text = value.ToString();
		}

		public void set_maxspeed(int value)
		{
			label_maxspeed.Text = value.ToString();
		}

		public void set_chips(int value)
		{
			label_chips.Text = value.ToString();
		}

		public void set_pcbs(int value)
		{
			label_pcbs.Text = value.ToString();
		}

		public void set_jebotai(bool v)
		{
			checkbox_jebotai.Checked = v;
		}

		public void set_haiba(float v)
		{
			label_haiba.Text = v.ToString("F2");
		}

		public void set_SmtIndexNo(string s)
		{
			label_SmtIndexNo.Text = s;
		}

		private void checkbox_jebotai_CheckedChanged(object sender, EventArgs e)
		{
			MainForm0.USR3B[mFn].mIsJieBoTaiMode = checkbox_jebotai.Checked;
			label_jiebotai.Visible = MainForm0.USR3B[mFn].mIsJieBoTaiMode;
			label_jiebotai.BringToFront();
		}

		private void checkBox_FinishAutoSmt_CheckedChanged(object sender, EventArgs e)
		{
			MainForm0.uc_job[mFn].bIsFinishAutoRun = checkBox_FinishAutoSmt.Checked;
		}

		private void checkBox_flashlight_CheckedChanged(object sender, EventArgs e)
		{
			if (MainForm0.USR3B[mFn] != null)
			{
				MainForm0.USR3B[mFn].mIsFlashlightMode = checkBox_flashlight.Checked;
			}
		}

		private void trackBar_smtXYSpeed_Scroll(object sender, EventArgs e)
		{
			MainForm0.USR3B[mFn].mSmtXYSpeed = trackBar_smtXYSpeed.Value;
			label_smtXYSpeed.Text = MainForm0.USR3B[mFn].mSmtXYSpeed.ToString();
			if (MainForm0.uc_job[mFn].LOW_SPEED)
			{
				MainForm0.uc_job[mFn].XY_SPEED = MainForm0.USR3B[mFn].mSmtXYSpeed / 2;
			}
		}

		private void trackBar_smtASpeed_Scroll(object sender, EventArgs e)
		{
			MainForm0.USR3B[mFn].mSmtASpeed = trackBar_smtASpeed.Value;
			label_smtASpeed.Text = MainForm0.USR3B[mFn].mSmtASpeed.ToString();
			if (MainForm0.uc_job[mFn].LOW_SPEED)
			{
				MainForm0.uc_job[mFn].A_SPEED = MainForm0.USR3B[mFn].mSmtASpeed / 2;
			}
		}

		private void cnButton_vsplus_stopsmt_Click(object sender, EventArgs e)
		{
			MainForm0.uc_job[mFn].vsplus_stopsmt();
		}

		private void cnButton_PauseSmt_Click(object sender, EventArgs e)
		{
			if ((string)cnButton_PauseSmt.Tag == "pause")
			{
				MainForm0.mRunDoing[mFn] |= 1;
				cnButton_PauseSmt.Text = ((MainForm0.USR_INIT.mLanguage == 2) ? "Resume" : "恢复");
				cnButton_PauseSmt.Tag = "resume";
			}
			else if ((string)cnButton_PauseSmt.Tag == "resume")
			{
				MainForm0.mRunDoing[mFn] = 0;
				cnButton_PauseSmt.Text = ((MainForm0.USR_INIT.mLanguage == 2) ? "Pause" : "暂停");
				cnButton_PauseSmt.Tag = "pause";
			}
		}

		private void cnButton_vsplus_continuesmt_Click(object sender, EventArgs e)
		{
			MainForm0.uc_job[mFn].vsplus_continuesmt();
		}

		private void panel_vsplus_fakepcb_Paint(object sender, PaintEventArgs e)
		{
			Panel panel_fake = (Panel)sender;
			int mUSR3Idx = MainForm0.uc_job[mFn].mUSR3Idx;
			draw_fakepcb(panel_fake, panel_fakepcb_smt.Size, MainForm0.uc_job[mFn].mUSR3List[mUSR3Idx].mPointlistSmt);
		}

		public void draw_fakechip(int usr3idx, int index, bool isdone)
		{
			USR3_DATA usr3 = MainForm0.uc_job[mFn].mUSR3List[usr3idx];
			Panel panelfake = panel_fakepcb_smt;
			if (usr3.draw_chipinfo_list != null && usr3.draw_chipinfo_list.Count != 0 && usr3.draw_chipinfo_list.Count > 1 && index < usr3.draw_chipinfo_list.Count)
			{
				BeginInvoke((MethodInvoker)delegate
				{
					Graphics graphics = panelfake.CreateGraphics();
					SolidBrush solidBrush = new SolidBrush(Color.Black);
					SolidBrush solidBrush2 = new SolidBrush(Color.White);
					usr3.draw_chipinfo_list[index].isdone = isdone;
					graphics.FillRectangle(isdone ? solidBrush : solidBrush2, usr3.draw_chipinfo_list[index].draw_smt_x, usr3.draw_chipinfo_list[index].draw_smt_y, usr3.draw_chipinfo_list[index].draw_smt_w, usr3.draw_chipinfo_list[index].draw_smt_h);
					solidBrush.Dispose();
					solidBrush2.Dispose();
					graphics.Dispose();
				});
			}
		}

		public void draw_fakepcb(Panel panel_fake, Size panel_size, BindingList<ChipBoardElement> pointlist)
		{
			int mUSR3Idx = MainForm0.uc_job[mFn].mUSR3Idx;
			USR3_DATA uSR3_DATA = MainForm0.uc_job[mFn].mUSR3List[mUSR3Idx];
			if (uSR3_DATA == null || pointlist == null || pointlist.Count == 0)
			{
				panel_fake.Controls.Clear();
				Graphics graphics = panel_fake.CreateGraphics();
				graphics.Clear(panel_fake.BackColor);
				graphics.Dispose();
				return;
			}
			int num = panel_size.Width;
			int num2 = panel_size.Height;
			int num3 = 5;
			int num4 = 4;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 99999f;
			float num8 = 99999f;
			float num9 = 1f;
			float num10 = 1f;
			float num11 = 1f;
			int num12 = 99999;
			for (int i = 0; i < pointlist.Count; i++)
			{
				if ((float)pointlist[i].X > num6)
				{
					num6 = (int)pointlist[i].X;
				}
				if ((float)pointlist[i].Y > num5)
				{
					num5 = (int)pointlist[i].Y;
				}
				if ((float)pointlist[i].X < num8)
				{
					num8 = (int)pointlist[i].X;
				}
				if ((float)pointlist[i].Y < num7)
				{
					num7 = (int)pointlist[i].Y;
				}
			}
			float num13 = (num6 - num8) / 10f;
			float num14 = (num5 - num7) / 10f;
			float num15 = num6;
			float num16 = num8;
			float num17 = num5;
			float num18 = num7;
			if (uSR3_DATA.mArrayPCBRow > 1)
			{
				num17 = 0f;
				num18 = 99999f;
				for (int j = 0; j < pointlist.Count; j++)
				{
					if (pointlist[j].Arrayno == 0)
					{
						if ((float)pointlist[j].Y > num17)
						{
							num17 = pointlist[j].Y;
						}
						if ((float)pointlist[j].Y < num18)
						{
							num18 = pointlist[j].Y;
						}
					}
				}
				num14 = (num5 - num7 - (num17 - num18) * (float)uSR3_DATA.mArrayPCBRow) / (float)(uSR3_DATA.mArrayPCBRow - 1);
			}
			if (uSR3_DATA.mArrayPCBColumn > 1)
			{
				num15 = 0f;
				num16 = 99999f;
				for (int k = 0; k < pointlist.Count; k++)
				{
					if (pointlist[k].Arrayno == 0)
					{
						if ((float)pointlist[k].X > num15)
						{
							num15 = pointlist[k].X;
						}
						if ((float)pointlist[k].X < num16)
						{
							num16 = pointlist[k].X;
						}
					}
				}
				num13 = (num6 - num8 - (num15 - num16) * (float)uSR3_DATA.mArrayPCBColumn) / (float)(uSR3_DATA.mArrayPCBColumn - 1);
			}
			num9 = (num6 - num8 + num13 * 4f / 5f) / (float)(num - num4 * 2);
			num10 = (num5 - num7 + num14 * 4f / 5f) / (float)(num2 - num4 * 2);
			num11 = ((!(num9 > num10)) ? num10 : num9);
			if ((double)num11 <= 1E-06)
			{
				return;
			}
			for (int l = 0; l < pointlist.Count; l++)
			{
				for (int m = l + 1; m < pointlist.Count; m++)
				{
					int num19 = (int)(pointlist[l].X - pointlist[m].X);
					int num20 = (int)(pointlist[l].Y - pointlist[m].Y);
					int num21 = (int)Math.Sqrt(num19 * num19 + num20 * num20);
					if (num21 < num12 && num21 > 0)
					{
						num12 = num21;
					}
				}
			}
			if ((float)num12 < (float)num3 * num11)
			{
				num11 = (float)num12 / (float)num3;
				num = (int)((num6 - num8 + num13 * 4f / 5f) / num11) + num4 * 2;
				num2 = (int)((num5 - num7 + num14 * 4f / 5f) / num11) + num4 * 2;
				panel_fake.Size = new Size(num, num2);
			}
			else
			{
				panel_fake.Size = new Size(panel_size.Width, panel_size.Height);
			}
			Graphics graphics2 = panel_fake.CreateGraphics();
			SolidBrush solidBrush = new SolidBrush(Color.DarkSeaGreen);
			SolidBrush solidBrush2 = new SolidBrush(Color.White);
			SolidBrush solidBrush3 = new SolidBrush(Color.Black);
			Pen pen = new Pen(Color.Black, 1f);
			int num22 = (num - (int)((double)((num6 - num8 + num13 * 4f / 5f) / num11) + 0.5)) / 2;
			int num23 = (num2 - (int)((double)((num5 - num7 + num14 * 4f / 5f) / num11) + 0.5)) / 2;
			int num24 = 5;
			int num25 = (int)((double)((num15 - num16 + num13 * 4f / 5f) / num11) + 0.5);
			int num26 = (int)((double)((num17 - num18 + num14 * 4f / 5f) / num11) + 0.5);
			int num27 = 0;
			int num28 = 0;
			if (num25 < 30)
			{
				num25 = 30;
				num27 = -13;
			}
			if (num26 < 30)
			{
				num26 = 30;
				num28 = -13;
			}
			for (int n = 0; n < uSR3_DATA.mArrayPCBRow; n++)
			{
				for (int num29 = 0; num29 < uSR3_DATA.mArrayPCBColumn; num29++)
				{
					int num30 = num22 + (int)((double)((float)num29 * (num15 - num16 + num13) / num11) + 0.5) + num27;
					int num31 = num23 + (int)((double)((float)n * (num17 - num18 + num14) / num11) + 0.5) + num28;
					graphics2.FillRectangle(solidBrush, num30, num31, num25, num26);
					graphics2.DrawRectangle(pen, num30, num31, num25, num26);
				}
			}
			for (int num32 = 0; num32 < pointlist.Count; num32++)
			{
				int draw_smt_x = num22 - num24 / 2 - 1 + (int)((double)(((float)pointlist[num32].X - num8 + num13 * 2f / 5f) / num11) + 0.5);
				int draw_smt_y = num23 - num24 / 2 - 1 + (int)((double)(((float)pointlist[num32].Y - num7 + num14 * 2f / 5f) / num11) + 0.5);
				int draw_smt_w = (int)((double)num24 + (double)num24 * Math.Abs(Math.Cos((double)pointlist[num32].A * 3.1415926 / 180.0)));
				int draw_smt_h = (int)((double)num24 + (double)num24 * Math.Abs(Math.Sin((double)pointlist[num32].A * 3.1415926 / 180.0)));
				SolidBrush brush = solidBrush2;
				if (pointlist == uSR3_DATA.mPointlistSmt && uSR3_DATA.draw_chipinfo_list != null && num32 < uSR3_DATA.draw_chipinfo_list.Count())
				{
					uSR3_DATA.draw_chipinfo_list[num32].draw_smt_x = draw_smt_x;
					uSR3_DATA.draw_chipinfo_list[num32].draw_smt_y = draw_smt_y;
					uSR3_DATA.draw_chipinfo_list[num32].draw_smt_w = draw_smt_w;
					uSR3_DATA.draw_chipinfo_list[num32].draw_smt_h = draw_smt_h;
					brush = (uSR3_DATA.draw_chipinfo_list[num32].isdone ? solidBrush3 : solidBrush2);
				}
				graphics2.FillRectangle(brush, draw_smt_x, draw_smt_y, draw_smt_w, draw_smt_h);
			}
			solidBrush.Dispose();
			solidBrush2.Dispose();
			solidBrush3.Dispose();
			pen.Dispose();
			graphics2.Dispose();
		}

		public void draw_fakechip_all(int usr3idx, bool isdone)
		{
			USR3_DATA usr3 = MainForm0.uc_job[mFn].mUSR3List[usr3idx];
			Panel panelfake = panel_fakepcb_smt;
			if (usr3.draw_chipinfo_list == null || usr3.draw_chipinfo_list.Count == 0 || usr3.draw_chipinfo_list.Count <= 1)
			{
				return;
			}
			Invoke((MethodInvoker)delegate
			{
				Graphics graphics = panelfake.CreateGraphics();
				SolidBrush solidBrush = new SolidBrush(Color.Black);
				SolidBrush solidBrush2 = new SolidBrush(Color.White);
				for (int i = 0; i < usr3.draw_chipinfo_list.Count; i++)
				{
					usr3.draw_chipinfo_list[i].isdone = isdone;
					graphics.FillRectangle(isdone ? solidBrush : solidBrush2, usr3.draw_chipinfo_list[i].draw_smt_x, usr3.draw_chipinfo_list[i].draw_smt_y, usr3.draw_chipinfo_list[i].draw_smt_w, usr3.draw_chipinfo_list[i].draw_smt_h);
				}
				solidBrush.Dispose();
				solidBrush2.Dispose();
				graphics.Dispose();
			});
		}

		private void cnButton_vsplus_setsmt_Click(object sender, EventArgs e)
		{
			panel_more_setting.Visible = true;
			panel_more_setting.BringToFront();
		}

		private void cnButton_SmtVisualShow_Click(object sender, EventArgs e)
		{
			if (MainForm0.uc_VisualShowSmt[mFn].Visible)
			{
				MainForm0.uc_VisualShowSmt[mFn].Visible = false;
				return;
			}
			panel1.Controls.Add(panel_more_setting);
			panel_more_setting.Location = new Point(3, 37);
			MainForm0.uc_VisualShowSmt[mFn].Visible = true;
			MainForm0.uc_VisualShowSmt[mFn].BringToFront();
		}

		public void set_finishautorun(bool v)
		{
			checkBox_FinishAutoSmt.Checked = v;
		}

		public bool get_finishautorun()
		{
			return checkBox_FinishAutoSmt.Checked;
		}

		private void cnButton_Loukong_clearS3_Click(object sender, EventArgs e)
		{
			cnButton_Loukong_clearS3.Visible = false;
			if (MainForm0.mConDevExt != null && MainForm0.mConDevExt[0] != null)
			{
				MainForm0.mConDevExt[0].send_loukong_clearS3();
			}
		}

		public void set_loukong_takeaway_visiable(bool flag)
		{
			cnButton_Loukong_clearS3.Visible = flag;
		}

		private void cnButton_more_settinh_close_Click(object sender, EventArgs e)
		{
			panel_more_setting.Visible = false;
		}

		private void cnButton_vsplus_setsmt2_Click(object sender, EventArgs e)
		{
			panel_more_setting.Visible = false;
			Invoke((MethodInvoker)delegate
			{
				MainForm0.static_this.set_tabControl_dsq(mFn);
				MainForm0.uc_job[mFn].vsplus_setsmt();
				MainForm0.uc_smtRunning.Visible = false;
			});
		}

		private void cnButton_isMount_Click(object sender, EventArgs e)
		{
			panel_more_setting.Visible = false;
			Form_SmtArrayIsMount form_SmtArrayIsMount = new Form_SmtArrayIsMount(mFn, MainForm0.USR3B[mFn].mFeederInstallList, MainForm0.USR3B[mFn].mIsMountStacksNew, MainForm0.U3[mFn][MainForm0.U3Idx[mFn]]);
			form_SmtArrayIsMount.ShowDialog();
		}

		private void cnButton_platestartindex_Click(object sender, EventArgs e)
		{
			panel_more_setting.Visible = false;
			StackElement[] stack = MainForm0.USR2[mFn].mStackLib.stacktab[1];
			_ = MainForm0.USR2[mFn].mStackLib.index[1];
			Form_SmtStackPlateStartIndex form_SmtStackPlateStartIndex = new Form_SmtStackPlateStartIndex(MainForm0.USR_INIT.mLanguage, stack);
			form_SmtStackPlateStartIndex.ShowDialog();
		}
	}
}
