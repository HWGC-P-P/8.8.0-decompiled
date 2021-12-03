using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms.Form_Debug;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_SmtRunning : UserControl
	{
		private IContainer components;

		private CnButton cnButton_all_stop;

		private CheckBox checkBox_all_finishauto;

		private CheckBox checkBox_simulate_visualpass;

		private CnButton cnButto_all_manual;

		private Label label_avespeed;

		private Panel panel_fakepcb_smt;

		private Label label_chips;

		private Label label16;

		private Label label_pcbs;

		private Label label14;

		private CnButton cnButton_all_autorun;

		private Label label12;

		private Label label10;

		private Label label_maxspeed;

		private CnButton cnButton_close;

		private CheckBox checkBox_simulator;

		private CheckBox checkBox_LouKong;

		private Panel[] panels;

		private ProgressBar[] progressbars;

		private Label[] labels_maxspeed;

		private Label[] labels_avespeed;

		private Label[] labels_pcbs;

		private Label[] labels_chips;

		private Label[] labels_finishrate;

		private Panel[] panels_smtshoware;

		private Panel[] panels_fakepcb_smt;

		private CheckBox[] checkboxs_jebotai;

		private Label[] labels_jiebotai;

		private CnButton[] buttons_start_autoRun;

		private CnButton[] buttons_start_manulRun;

		private CnButton[] buttons_stop;

		private CnButton[] buttons_continue;

		public UserControl_SingleSmt[] ucs_singlesmt;

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
			checkBox_all_finishauto = new System.Windows.Forms.CheckBox();
			checkBox_simulate_visualpass = new System.Windows.Forms.CheckBox();
			label_avespeed = new System.Windows.Forms.Label();
			panel_fakepcb_smt = new System.Windows.Forms.Panel();
			label_chips = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label_pcbs = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label_maxspeed = new System.Windows.Forms.Label();
			checkBox_simulator = new System.Windows.Forms.CheckBox();
			checkBox_LouKong = new System.Windows.Forms.CheckBox();
			cnButton_close = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_all_stop = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButto_all_manual = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_all_autorun = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_fakepcb_smt.SuspendLayout();
			SuspendLayout();
			checkBox_all_finishauto.AutoSize = true;
			checkBox_all_finishauto.Font = new System.Drawing.Font("黑体", 12.5f);
			checkBox_all_finishauto.Location = new System.Drawing.Point(839, 104);
			checkBox_all_finishauto.Name = "checkBox_all_finishauto";
			checkBox_all_finishauto.Size = new System.Drawing.Size(117, 21);
			checkBox_all_finishauto.TabIndex = 16;
			checkBox_all_finishauto.Text = "结束全自动";
			checkBox_all_finishauto.UseVisualStyleBackColor = true;
			checkBox_all_finishauto.CheckedChanged += new System.EventHandler(checkBox_all_finishauto_CheckedChanged);
			checkBox_simulate_visualpass.AutoSize = true;
			checkBox_simulate_visualpass.Font = new System.Drawing.Font("黑体", 12.5f);
			checkBox_simulate_visualpass.Location = new System.Drawing.Point(23, 35);
			checkBox_simulate_visualpass.Name = "checkBox_simulate_visualpass";
			checkBox_simulate_visualpass.Size = new System.Drawing.Size(180, 21);
			checkBox_simulate_visualpass.TabIndex = 15;
			checkBox_simulate_visualpass.Text = "仿真-忽略识别失败";
			checkBox_simulate_visualpass.UseVisualStyleBackColor = true;
			checkBox_simulate_visualpass.Visible = false;
			checkBox_simulate_visualpass.CheckedChanged += new System.EventHandler(checkBox_simulate_visualpass_CheckedChanged);
			label_avespeed.BackColor = System.Drawing.Color.White;
			label_avespeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_avespeed.Font = new System.Drawing.Font("黑体", 30.5f);
			label_avespeed.Location = new System.Drawing.Point(449, 42);
			label_avespeed.Name = "label_avespeed";
			label_avespeed.Size = new System.Drawing.Size(160, 55);
			label_avespeed.TabIndex = 9;
			label_avespeed.Text = "20000";
			label_avespeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_fakepcb_smt.Controls.Add(label_chips);
			panel_fakepcb_smt.Controls.Add(label16);
			panel_fakepcb_smt.Controls.Add(label_pcbs);
			panel_fakepcb_smt.Controls.Add(label14);
			panel_fakepcb_smt.Location = new System.Drawing.Point(317, 251);
			panel_fakepcb_smt.Name = "panel_fakepcb_smt";
			panel_fakepcb_smt.Size = new System.Drawing.Size(681, 605);
			panel_fakepcb_smt.TabIndex = 12;
			panel_fakepcb_smt.Visible = false;
			label_chips.BackColor = System.Drawing.Color.White;
			label_chips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_chips.Font = new System.Drawing.Font("黑体", 20.5f);
			label_chips.Location = new System.Drawing.Point(46, 46);
			label_chips.Name = "label_chips";
			label_chips.Size = new System.Drawing.Size(138, 55);
			label_chips.TabIndex = 0;
			label_chips.Text = "20000";
			label_chips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("黑体", 14.5f);
			label16.Location = new System.Drawing.Point(70, 112);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(89, 20);
			label16.TabIndex = 1;
			label16.Text = "完成点数";
			label_pcbs.BackColor = System.Drawing.Color.White;
			label_pcbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_pcbs.Font = new System.Drawing.Font("黑体", 20.5f);
			label_pcbs.Location = new System.Drawing.Point(240, 46);
			label_pcbs.Name = "label_pcbs";
			label_pcbs.Size = new System.Drawing.Size(138, 55);
			label_pcbs.TabIndex = 0;
			label_pcbs.Text = "20000";
			label_pcbs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("黑体", 14.5f);
			label14.Location = new System.Drawing.Point(264, 112);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(89, 20);
			label14.TabIndex = 1;
			label14.Text = "完成板组";
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("黑体", 20.5f);
			label12.Location = new System.Drawing.Point(659, 109);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(124, 28);
			label12.TabIndex = 10;
			label12.Text = "最高时速";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("黑体", 20.5f);
			label10.Location = new System.Drawing.Point(468, 109);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(124, 28);
			label10.TabIndex = 11;
			label10.Text = "平均时速";
			label_maxspeed.BackColor = System.Drawing.Color.White;
			label_maxspeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_maxspeed.Font = new System.Drawing.Font("黑体", 30.5f);
			label_maxspeed.Location = new System.Drawing.Point(640, 42);
			label_maxspeed.Name = "label_maxspeed";
			label_maxspeed.Size = new System.Drawing.Size(160, 55);
			label_maxspeed.TabIndex = 8;
			label_maxspeed.Text = "20000";
			label_maxspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_simulator.AutoSize = true;
			checkBox_simulator.Font = new System.Drawing.Font("黑体", 12.5f);
			checkBox_simulator.Location = new System.Drawing.Point(23, 17);
			checkBox_simulator.Name = "checkBox_simulator";
			checkBox_simulator.Size = new System.Drawing.Size(81, 21);
			checkBox_simulator.TabIndex = 19;
			checkBox_simulator.Text = "仿真器";
			checkBox_simulator.UseVisualStyleBackColor = true;
			checkBox_simulator.Visible = false;
			checkBox_simulator.CheckedChanged += new System.EventHandler(checkBox_simulator_CheckedChanged);
			checkBox_LouKong.AutoSize = true;
			checkBox_LouKong.Font = new System.Drawing.Font("黑体", 12.5f);
			checkBox_LouKong.Location = new System.Drawing.Point(962, 103);
			checkBox_LouKong.Name = "checkBox_LouKong";
			checkBox_LouKong.Size = new System.Drawing.Size(81, 21);
			checkBox_LouKong.TabIndex = 20;
			checkBox_LouKong.Text = "镂空板";
			checkBox_LouKong.UseVisualStyleBackColor = true;
			checkBox_LouKong.CheckedChanged += new System.EventHandler(checkBox_LouKong_CheckedChanged);
			cnButton_close.BackColor = System.Drawing.Color.DimGray;
			cnButton_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_close.CnPressDownColor = System.Drawing.Color.White;
			cnButton_close.Font = new System.Drawing.Font("黑体", 12.5f);
			cnButton_close.ForeColor = System.Drawing.Color.White;
			cnButton_close.Location = new System.Drawing.Point(1189, 17);
			cnButton_close.Name = "cnButton_close";
			cnButton_close.Size = new System.Drawing.Size(75, 39);
			cnButton_close.TabIndex = 18;
			cnButton_close.Text = "返回";
			cnButton_close.UseVisualStyleBackColor = false;
			cnButton_close.Click += new System.EventHandler(cnButton_close_Click);
			cnButton_all_stop.BackColor = System.Drawing.Color.DimGray;
			cnButton_all_stop.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_all_stop.CnPressDownColor = System.Drawing.Color.White;
			cnButton_all_stop.Font = new System.Drawing.Font("黑体", 15.5f);
			cnButton_all_stop.ForeColor = System.Drawing.Color.White;
			cnButton_all_stop.Location = new System.Drawing.Point(974, 42);
			cnButton_all_stop.Name = "cnButton_all_stop";
			cnButton_all_stop.Size = new System.Drawing.Size(62, 55);
			cnButton_all_stop.TabIndex = 17;
			cnButton_all_stop.Text = "结束";
			cnButton_all_stop.UseVisualStyleBackColor = false;
			cnButton_all_stop.Click += new System.EventHandler(cnButton_all_stop_Click);
			cnButto_all_manual.BackColor = System.Drawing.Color.DimGray;
			cnButto_all_manual.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButto_all_manual.CnPressDownColor = System.Drawing.Color.White;
			cnButto_all_manual.Font = new System.Drawing.Font("黑体", 15.5f);
			cnButto_all_manual.ForeColor = System.Drawing.Color.White;
			cnButto_all_manual.Location = new System.Drawing.Point(23, 59);
			cnButto_all_manual.Name = "cnButto_all_manual";
			cnButto_all_manual.Size = new System.Drawing.Size(81, 35);
			cnButto_all_manual.TabIndex = 14;
			cnButto_all_manual.Text = "单贴";
			cnButto_all_manual.UseVisualStyleBackColor = false;
			cnButto_all_manual.Visible = false;
			cnButto_all_manual.Click += new System.EventHandler(cnButto_all_manual_Click);
			cnButton_all_autorun.BackColor = System.Drawing.Color.DimGray;
			cnButton_all_autorun.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_all_autorun.CnPressDownColor = System.Drawing.Color.White;
			cnButton_all_autorun.Font = new System.Drawing.Font("黑体", 15.5f);
			cnButton_all_autorun.ForeColor = System.Drawing.Color.White;
			cnButton_all_autorun.Location = new System.Drawing.Point(835, 42);
			cnButton_all_autorun.Name = "cnButton_all_autorun";
			cnButton_all_autorun.Size = new System.Drawing.Size(133, 55);
			cnButton_all_autorun.TabIndex = 13;
			cnButton_all_autorun.Text = "全自动";
			cnButton_all_autorun.UseVisualStyleBackColor = false;
			cnButton_all_autorun.Click += new System.EventHandler(cnButton_all_autorun_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(checkBox_LouKong);
			base.Controls.Add(checkBox_simulator);
			base.Controls.Add(cnButton_close);
			base.Controls.Add(cnButton_all_stop);
			base.Controls.Add(checkBox_all_finishauto);
			base.Controls.Add(checkBox_simulate_visualpass);
			base.Controls.Add(cnButto_all_manual);
			base.Controls.Add(label_avespeed);
			base.Controls.Add(panel_fakepcb_smt);
			base.Controls.Add(cnButton_all_autorun);
			base.Controls.Add(label12);
			base.Controls.Add(label10);
			base.Controls.Add(label_maxspeed);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.Name = "UserControl_SmtRunning";
			base.Size = new System.Drawing.Size(1280, 990);
			base.Load += new System.EventHandler(UserControl_SmtRunning_Load);
			panel_fakepcb_smt.ResumeLayout(false);
			panel_fakepcb_smt.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public UserControl_SmtRunning()
		{
			InitializeComponent();
		}

		private void UserControl_SmtRunning_Load(object sender, EventArgs e)
		{
			if (MainForm0.mIsSimulation)
			{
				cnButto_all_manual.Visible = true;
				checkBox_simulate_visualpass.Visible = true;
				checkBox_simulate_visualpass.Checked = true;
				checkBox_simulator.Visible = true;
			}
			ucs_singlesmt = new UserControl_SingleSmt[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				ucs_singlesmt[i] = new UserControl_SingleSmt(i);
				ucs_singlesmt[i].Location = new Point(640 * i, 152);
				base.Controls.Add(ucs_singlesmt[i]);
				ucs_singlesmt[i].BringToFront();
			}
			for (int j = 0; j < HW.mFnNum; j++)
			{
				ucs_singlesmt[j].set_maxspeed((int)MainForm0.uc_job[j].msmt_max_hourspeed);
				ucs_singlesmt[j].set_avespeed((int)MainForm0.uc_job[j].msmt_hourspeed);
				ucs_singlesmt[j].set_pcbs(MainForm0.uc_job[j].msmt_real_loops);
				ucs_singlesmt[j].set_chips(MainForm0.uc_job[j].msmt_real_chips);
				ucs_singlesmt[j].set_progress_bar_minvmax(0, MainForm0.uc_job[j].get_progress_bar_v(), MainForm0.uc_job[j].get_progress_bar_max_v());
			}
			label_avespeed.Text = ((int)MainForm0.total_avespeed).ToString();
			label_maxspeed.Text = ((int)MainForm0.total_maxspeed).ToString();
			checkBox_LouKong.Checked = MainForm0.USR3_INIT.mIsLoukong;
			for (int k = 0; k < HW.mFnNum; k++)
			{
				if (MainForm0.uc_job[k].bIsFinishAutoRun)
				{
					checkBox_all_finishauto.Checked = MainForm0.uc_job[k].bIsFinishAutoRun;
					break;
				}
			}
		}

		public void set_ui_enable(bool flag)
		{
			cnButton_all_autorun.Enabled = flag;
		}

		public void checkboxs_jebotai_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			int num = (int)checkBox.Tag;
			labels_jiebotai[num].Visible = (MainForm0.USR3B[num].mIsJieBoTaiMode = checkBox.Checked);
		}

		public void buttons_start_autoRun_Click(object sender, EventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			int num = (int)cnButton.Tag;
			MainForm0.uc_job[num].vsplus_startsmt(0, 0f, SmtOpMode.AutoRun);
		}

		public void buttons_start_manulRun_Click(object sender, EventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			int num = (int)cnButton.Tag;
			MainForm0.uc_job[num].vsplus_startsmt(0, 0f, SmtOpMode.CurLoop);
		}

		public void buttons_stop_Click(object sender, EventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			int num = (int)cnButton.Tag;
			MainForm0.uc_job[num].vsplus_stopsmt();
		}

		public void buttons_continue_Click(object sender, EventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			int num = (int)cnButton.Tag;
			MainForm0.uc_job[num].vsplus_startsmt(MainForm0.uc_job[num].mis_maybe_continue, MainForm0.uc_job[num].msmt_curhaiba, SmtOpMode.ContinueLoop);
		}

		private void cnButton_all_autorun_Click(object sender, EventArgs e)
		{
			if (MainForm0.uc_job[0].loukong_state_confirm())
			{
				for (int i = 0; i < HW.mFnNum; i++)
				{
					MainForm0.uc_job[i].vsplus_startsmt(0, 0f, SmtOpMode.AutoRun);
				}
			}
		}

		private void cnButto_all_manual_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				MainForm0.uc_job[i].vsplus_startsmt(0, 0f, SmtOpMode.CurLoop);
			}
		}

		private void cnButton_all_stop_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				MainForm0.uc_job[i].vsplus_stopsmt();
			}
		}

		private void checkBox_simulate_visualpass_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				MainForm0.uc_job[i].is_ignore_visualfail = checkBox_simulate_visualpass.Checked;
			}
		}

		private void checkBox_all_finishauto_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				ucs_singlesmt[i].set_finishautorun(checkBox_all_finishauto.Checked);
			}
		}

		public void set_finishauto(int fn, bool flag)
		{
			ucs_singlesmt[fn].set_finishautorun(flag);
			if (ucs_singlesmt[1 - fn].get_finishautorun() == flag)
			{
				checkBox_all_finishauto.Checked = flag;
			}
		}

		public void set_cnButton_vsplus_startsmt_visiable(int fn, bool flag)
		{
			ucs_singlesmt[fn].set_cnButton_vsplus_startsmt_visiable(flag);
		}

		public void set_label_vsplus_smtmode_visiable(int fn, bool flag)
		{
			ucs_singlesmt[fn].set_label_vsplus_smtmode_visiable(flag);
		}

		public void set_label_vsplus_smtmode_string(int fn, string s)
		{
			ucs_singlesmt[fn].set_label_vsplus_smtmode_string(s);
		}

		public void set_pause_stop_button_visiable(int fn, bool flag)
		{
			ucs_singlesmt[fn].set_pause_stop_button_visiable(flag);
			if (flag)
			{
				set_ui_enable(flag: false);
			}
			else
			{
				if (flag)
				{
					return;
				}
				for (int i = 0; i < HW.mFnNum; i++)
				{
					if (ucs_singlesmt[i].get_pause_stop_button_visable())
					{
						return;
					}
				}
				set_ui_enable(flag: true);
			}
		}

		public void set_label_SmtState(int fn, string s)
		{
			ucs_singlesmt[fn].set_label_SmtState(s);
		}

		public void set_progress_bar_minvmax(int fn, int minv, int v, int maxv)
		{
			ucs_singlesmt[fn].set_progress_bar_minvmax(minv, v, maxv);
		}

		public void set_progress_bar_v(int fn, int value)
		{
			ucs_singlesmt[fn].set_progress_bar_v(value);
		}

		public void set_avespeed(int fn, int value)
		{
			ucs_singlesmt[fn].set_avespeed(value);
		}

		public void set_maxspeed(int fn, int value)
		{
			ucs_singlesmt[fn].set_maxspeed(value);
		}

		public void set_chips(int fn, int value)
		{
			ucs_singlesmt[fn].set_chips(value);
		}

		public void set_pcbs(int fn, int value)
		{
			ucs_singlesmt[fn].set_pcbs(value);
		}

		public void set_haiba(int fn, float value)
		{
			ucs_singlesmt[fn].set_haiba(value);
		}

		public void set_SmtIndexNo(int fn, string s)
		{
			ucs_singlesmt[fn].set_SmtIndexNo(s);
		}

		public void set_total_speed(int ave, int maxspeed)
		{
			if (!MainForm0.mutex_fm_smtrunning)
			{
				MainForm0.mutex_fm_smtrunning = true;
				label_avespeed.Text = ave.ToString();
				label_maxspeed.Text = maxspeed.ToString();
				MainForm0.mutex_fm_smtrunning = false;
			}
		}

		public void draw_fakechip(int fn, int usr3idx, int index, bool isdone)
		{
			ucs_singlesmt[fn].draw_fakechip(usr3idx, index, isdone);
		}

		public void draw_fakechip_all(int fn, int usr3idx, bool isdone)
		{
			ucs_singlesmt[fn].draw_fakechip_all(usr3idx, isdone);
		}

		private void cnButton_close_Click(object sender, EventArgs e)
		{
			base.Visible = false;
		}

		private void checkBox_simulator_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_simulator.Checked && (MainForm0.mDebugFormDSQ == null || MainForm0.mDebugFormDSQ.IsDisposed))
			{
				MainForm0.mDebugFormDSQ = new Form_DebugDSQ();
				MainForm0.mDebugFormDSQ.TopMost = true;
				MainForm0.mDebugFormDSQ.Show();
			}
		}

		private void checkBox_LouKong_CheckedChanged(object sender, EventArgs e)
		{
			MainForm0.USR3_INIT.mIsLoukong = checkBox_LouKong.Checked;
			if (!MainForm0.mIsSimulation && MainForm0.mConDevExt != null && MainForm0.mConDevExt[0] != null)
			{
				MainForm0.mConDevExt[0].send_loukong_enable(MainForm0.USR3_INIT.mIsLoukong ? 1 : 0, HW.mIsSanduanshi);
			}
		}
	}
}
