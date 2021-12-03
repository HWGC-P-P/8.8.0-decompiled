using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.Properties;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_SmtSetting : UserControl
	{
		private IContainer components;

		private CnButton button_SmtStackPlateStartNo;

		private CnButton button_StackIsMount;

		private Label label1;

		private NumericUpDown numericUpDown_failretryNum;

		private CheckBox checkBox_Loukong;

		private CheckBox checkBox_ischeckNozzle;

		private Label label_gotodefinexy_aftersmtdone;

		private CnButton button_gotodefinexy_Save;

		private CnButton button_gotodefinexy_Goto;

		private CheckBox checkBox_youxian_pik;

		private CheckBox checkBox_youxian_visual;

		private Panel panel1;

		private RadioButton radioButton_visualfailretry_afterfinish;

		private RadioButton radioButton_visualfailretry_rightnow;

		private CheckBox checkBox5;

		private CnButton button_close;

		private Panel panel_marksetting;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private RadioButton radioButton5;

		private RadioButton radioButton6;

		private CheckBox checkBox_AutoFail_ToManual;

		private CheckBox checkBox_Memory_Mark;

		private CheckBox checkBox_No_Mark;

		private Label label6;

		private Label label3;

		private Label label7;

		private Label label8;

		private Label label9;

		private RadioButton radioButton_none_aftersmtdone;

		private RadioButton radioButton_gotodefine_aftersmtdone;

		private RadioButton radioButton_gotopik_aftersmtdone;

		private Panel panel_safespace;

		private PictureBox pictureBox2;

		private NumericUpDown numericUpDown_safespace;

		private Label label123;

		private Label label122;

		private Label label2;

		private Panel panel4;

		private RadioButton radioButton_prjmode0;

		private RadioButton radioButton_prjmode1;

		private RadioButton radioButton1;

		private CheckBox checkBox_gen0_raisespeed;

		private CheckBox checkBox_afteryouxian_gotomark1;

		private CheckBox checkBox_preparevacuum_veryearly;

		private Label label10;

		private Label label11;

		private Panel panel_tran4;

		private NumericUpDown numericUpDown_tran4_finishsignal_delay;

		private NumericUpDown numericUpDown_tran4_waitnewsignal_delay;

		private Panel panel_youxianpik;

		private Label label12;

		private CnButton button_youxian_pik;

		private Label label13;

		private CnButton button_marksetting;

		private CnButton button_close_youxianpik;

		private CnButton button_close_marksetting;

		private Panel panel2;

		private Label label4;

		private int mFn;

		private USR_DATA USR;

		private USR2_DATA USR2;

		private USR3_BASE USR3B;

		public BindingList<USR3_DATA> U3;

		public int U3Idx;

		private USR_INIT_DATA USR_INIT;

		private RadioButton[] radioButton_markfail;

		private RadioButton[] radioButton_gotoxy_aftersmtdone;

		public event void_Func_int button_subpcb_sel;

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
			numericUpDown_failretryNum = new System.Windows.Forms.NumericUpDown();
			checkBox_Loukong = new System.Windows.Forms.CheckBox();
			checkBox_ischeckNozzle = new System.Windows.Forms.CheckBox();
			label_gotodefinexy_aftersmtdone = new System.Windows.Forms.Label();
			checkBox_youxian_pik = new System.Windows.Forms.CheckBox();
			checkBox_youxian_visual = new System.Windows.Forms.CheckBox();
			panel1 = new System.Windows.Forms.Panel();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton_visualfailretry_afterfinish = new System.Windows.Forms.RadioButton();
			radioButton_visualfailretry_rightnow = new System.Windows.Forms.RadioButton();
			checkBox5 = new System.Windows.Forms.CheckBox();
			panel_marksetting = new System.Windows.Forms.Panel();
			radioButton4 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton6 = new System.Windows.Forms.RadioButton();
			checkBox_AutoFail_ToManual = new System.Windows.Forms.CheckBox();
			checkBox_Memory_Mark = new System.Windows.Forms.CheckBox();
			checkBox_No_Mark = new System.Windows.Forms.CheckBox();
			label6 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			radioButton_none_aftersmtdone = new System.Windows.Forms.RadioButton();
			radioButton_gotodefine_aftersmtdone = new System.Windows.Forms.RadioButton();
			radioButton_gotopik_aftersmtdone = new System.Windows.Forms.RadioButton();
			panel_safespace = new System.Windows.Forms.Panel();
			numericUpDown_safespace = new System.Windows.Forms.NumericUpDown();
			label123 = new System.Windows.Forms.Label();
			label122 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			radioButton_prjmode1 = new System.Windows.Forms.RadioButton();
			radioButton_prjmode0 = new System.Windows.Forms.RadioButton();
			checkBox_gen0_raisespeed = new System.Windows.Forms.CheckBox();
			checkBox_afteryouxian_gotomark1 = new System.Windows.Forms.CheckBox();
			checkBox_preparevacuum_veryearly = new System.Windows.Forms.CheckBox();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			panel_tran4 = new System.Windows.Forms.Panel();
			numericUpDown_tran4_finishsignal_delay = new System.Windows.Forms.NumericUpDown();
			numericUpDown_tran4_waitnewsignal_delay = new System.Windows.Forms.NumericUpDown();
			panel_youxianpik = new System.Windows.Forms.Panel();
			label13 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			button_close_youxianpik = new QIGN_COMMON.vs_acontrol.CnButton();
			button_gotodefinexy_Save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_gotodefinexy_Goto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close_marksetting = new QIGN_COMMON.vs_acontrol.CnButton();
			button_marksetting = new QIGN_COMMON.vs_acontrol.CnButton();
			button_youxian_pik = new QIGN_COMMON.vs_acontrol.CnButton();
			button_StackIsMount = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SmtStackPlateStartNo = new QIGN_COMMON.vs_acontrol.CnButton();
			((System.ComponentModel.ISupportInitialize)numericUpDown_failretryNum).BeginInit();
			panel1.SuspendLayout();
			panel_marksetting.SuspendLayout();
			panel_safespace.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_safespace).BeginInit();
			panel4.SuspendLayout();
			panel_tran4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_tran4_finishsignal_delay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_tran4_waitnewsignal_delay).BeginInit();
			panel_youxianpik.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(253, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(63, 14);
			label1.TabIndex = 1;
			label1.Text = "重取次数";
			numericUpDown_failretryNum.Location = new System.Drawing.Point(328, 0);
			numericUpDown_failretryNum.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_failretryNum.Name = "numericUpDown_failretryNum";
			numericUpDown_failretryNum.Size = new System.Drawing.Size(45, 23);
			numericUpDown_failretryNum.TabIndex = 2;
			numericUpDown_failretryNum.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			numericUpDown_failretryNum.ValueChanged += new System.EventHandler(numericUpDown_failretryNum_ValueChanged);
			checkBox_Loukong.AutoSize = true;
			checkBox_Loukong.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_Loukong.ForeColor = System.Drawing.Color.White;
			checkBox_Loukong.Location = new System.Drawing.Point(12, 101);
			checkBox_Loukong.Name = "checkBox_Loukong";
			checkBox_Loukong.Size = new System.Drawing.Size(74, 19);
			checkBox_Loukong.TabIndex = 3;
			checkBox_Loukong.Text = "镂空板";
			checkBox_Loukong.UseVisualStyleBackColor = true;
			checkBox_Loukong.CheckedChanged += new System.EventHandler(checkBox_Loukong_CheckedChanged);
			checkBox_ischeckNozzle.AutoSize = true;
			checkBox_ischeckNozzle.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_ischeckNozzle.ForeColor = System.Drawing.Color.White;
			checkBox_ischeckNozzle.Location = new System.Drawing.Point(13, 221);
			checkBox_ischeckNozzle.Name = "checkBox_ischeckNozzle";
			checkBox_ischeckNozzle.Size = new System.Drawing.Size(154, 19);
			checkBox_ischeckNozzle.TabIndex = 3;
			checkBox_ischeckNozzle.Text = "吸嘴异物检测报警";
			checkBox_ischeckNozzle.UseVisualStyleBackColor = true;
			checkBox_ischeckNozzle.Visible = false;
			checkBox_ischeckNozzle.CheckedChanged += new System.EventHandler(checkBox_ischeckNozzle_CheckedChanged);
			label_gotodefinexy_aftersmtdone.BackColor = System.Drawing.Color.White;
			label_gotodefinexy_aftersmtdone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_gotodefinexy_aftersmtdone.Enabled = false;
			label_gotodefinexy_aftersmtdone.Location = new System.Drawing.Point(41, 158);
			label_gotodefinexy_aftersmtdone.Name = "label_gotodefinexy_aftersmtdone";
			label_gotodefinexy_aftersmtdone.Size = new System.Drawing.Size(58, 32);
			label_gotodefinexy_aftersmtdone.TabIndex = 1;
			label_gotodefinexy_aftersmtdone.Text = "X00000\r\nY00000";
			label_gotodefinexy_aftersmtdone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_youxian_pik.AutoSize = true;
			checkBox_youxian_pik.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_youxian_pik.ForeColor = System.Drawing.Color.White;
			checkBox_youxian_pik.Location = new System.Drawing.Point(12, 137);
			checkBox_youxian_pik.Name = "checkBox_youxian_pik";
			checkBox_youxian_pik.Size = new System.Drawing.Size(218, 19);
			checkBox_youxian_pik.TabIndex = 3;
			checkBox_youxian_pik.Text = "提前取料（全自动运行时）";
			checkBox_youxian_pik.UseVisualStyleBackColor = true;
			checkBox_youxian_pik.CheckedChanged += new System.EventHandler(checkBox_youxian_pik_CheckedChanged);
			checkBox_youxian_visual.AutoSize = true;
			checkBox_youxian_visual.Location = new System.Drawing.Point(9, 11);
			checkBox_youxian_visual.Name = "checkBox_youxian_visual";
			checkBox_youxian_visual.Size = new System.Drawing.Size(166, 18);
			checkBox_youxian_visual.TabIndex = 3;
			checkBox_youxian_visual.Text = "提前取料后，直接视觉";
			checkBox_youxian_visual.UseVisualStyleBackColor = true;
			checkBox_youxian_visual.CheckedChanged += new System.EventHandler(checkBox_youxian_visual_CheckedChanged);
			panel1.Controls.Add(radioButton1);
			panel1.Controls.Add(radioButton_visualfailretry_afterfinish);
			panel1.Controls.Add(radioButton_visualfailretry_rightnow);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(numericUpDown_failretryNum);
			panel1.Font = new System.Drawing.Font("黑体", 10.5f);
			panel1.ForeColor = System.Drawing.Color.White;
			panel1.Location = new System.Drawing.Point(279, 97);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(410, 58);
			panel1.TabIndex = 4;
			radioButton1.AutoSize = true;
			radioButton1.Enabled = false;
			radioButton1.Location = new System.Drawing.Point(3, 39);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(291, 18);
			radioButton1.TabIndex = 0;
			radioButton1.Text = "元件识别失败，从多组供料的其他料站取料";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton1.Visible = false;
			radioButton_visualfailretry_afterfinish.AutoSize = true;
			radioButton_visualfailretry_afterfinish.Enabled = false;
			radioButton_visualfailretry_afterfinish.Location = new System.Drawing.Point(3, 22);
			radioButton_visualfailretry_afterfinish.Name = "radioButton_visualfailretry_afterfinish";
			radioButton_visualfailretry_afterfinish.Size = new System.Drawing.Size(284, 18);
			radioButton_visualfailretry_afterfinish.TabIndex = 0;
			radioButton_visualfailretry_afterfinish.Text = "元件识别失败，完成单PCB贴装后统一补料";
			radioButton_visualfailretry_afterfinish.UseVisualStyleBackColor = true;
			radioButton_visualfailretry_rightnow.AutoSize = true;
			radioButton_visualfailretry_rightnow.Checked = true;
			radioButton_visualfailretry_rightnow.Location = new System.Drawing.Point(3, 4);
			radioButton_visualfailretry_rightnow.Name = "radioButton_visualfailretry_rightnow";
			radioButton_visualfailretry_rightnow.Size = new System.Drawing.Size(207, 18);
			radioButton_visualfailretry_rightnow.TabIndex = 0;
			radioButton_visualfailretry_rightnow.TabStop = true;
			radioButton_visualfailretry_rightnow.Text = "元件识别失败，立即抛料重取";
			radioButton_visualfailretry_rightnow.UseVisualStyleBackColor = true;
			radioButton_visualfailretry_rightnow.CheckedChanged += new System.EventHandler(radioButton_visualfailretry_rightnow_CheckedChanged);
			checkBox5.AutoSize = true;
			checkBox5.Enabled = false;
			checkBox5.ForeColor = System.Drawing.Color.White;
			checkBox5.Location = new System.Drawing.Point(13, 203);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(152, 18);
			checkBox5.TabIndex = 3;
			checkBox5.Text = "高阶闭环，人工干预";
			checkBox5.UseVisualStyleBackColor = true;
			checkBox5.Visible = false;
			panel_marksetting.BackColor = System.Drawing.Color.White;
			panel_marksetting.Controls.Add(button_close_marksetting);
			panel_marksetting.Controls.Add(radioButton4);
			panel_marksetting.Controls.Add(radioButton3);
			panel_marksetting.Controls.Add(radioButton5);
			panel_marksetting.Controls.Add(radioButton6);
			panel_marksetting.Controls.Add(checkBox_AutoFail_ToManual);
			panel_marksetting.Controls.Add(checkBox_Memory_Mark);
			panel_marksetting.Controls.Add(checkBox_No_Mark);
			panel_marksetting.Controls.Add(label6);
			panel_marksetting.Location = new System.Drawing.Point(279, 159);
			panel_marksetting.Name = "panel_marksetting";
			panel_marksetting.Size = new System.Drawing.Size(422, 197);
			panel_marksetting.TabIndex = 10;
			panel_marksetting.Visible = false;
			radioButton4.AutoSize = true;
			radioButton4.Checked = true;
			radioButton4.Location = new System.Drawing.Point(8, 77);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(277, 18);
			radioButton4.TabIndex = 3;
			radioButton4.TabStop = true;
			radioButton4.Text = "Mark失败，结束当前板组，并退出全自动\r\n";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Enabled = false;
			radioButton3.Location = new System.Drawing.Point(8, 95);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(277, 18);
			radioButton3.TabIndex = 3;
			radioButton3.Text = "Mark失败，跳过当前板组，并继续全自动\r\n";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton5.AutoSize = true;
			radioButton5.Location = new System.Drawing.Point(8, 130);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(410, 18);
			radioButton5.TabIndex = 3;
			radioButton5.Text = "Mark失败，跳过当前子PCB，继续完成当前板组，并继续全自动\r\n";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton6.AutoSize = true;
			radioButton6.Location = new System.Drawing.Point(8, 112);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new System.Drawing.Size(410, 18);
			radioButton6.TabIndex = 3;
			radioButton6.Text = "Mark失败，跳过当前子PCB，继续完成当前板组，并退出全自动\r\n";
			radioButton6.UseVisualStyleBackColor = true;
			checkBox_AutoFail_ToManual.AutoSize = true;
			checkBox_AutoFail_ToManual.Location = new System.Drawing.Point(8, 35);
			checkBox_AutoFail_ToManual.Name = "checkBox_AutoFail_ToManual";
			checkBox_AutoFail_ToManual.Size = new System.Drawing.Size(208, 18);
			checkBox_AutoFail_ToManual.TabIndex = 8;
			checkBox_AutoFail_ToManual.Text = "自动Mark失败就立即手动Mark";
			checkBox_AutoFail_ToManual.UseVisualStyleBackColor = true;
			checkBox_AutoFail_ToManual.CheckedChanged += new System.EventHandler(checkBox_AutoFailToManual_CheckedChanged);
			checkBox_Memory_Mark.AutoSize = true;
			checkBox_Memory_Mark.Location = new System.Drawing.Point(8, 55);
			checkBox_Memory_Mark.Name = "checkBox_Memory_Mark";
			checkBox_Memory_Mark.Size = new System.Drawing.Size(110, 18);
			checkBox_Memory_Mark.TabIndex = 9;
			checkBox_Memory_Mark.Text = "全自动时记忆";
			checkBox_Memory_Mark.UseVisualStyleBackColor = true;
			checkBox_Memory_Mark.Visible = false;
			checkBox_Memory_Mark.CheckedChanged += new System.EventHandler(checkBox_MemoryMark_CheckedChanged);
			checkBox_No_Mark.AutoSize = true;
			checkBox_No_Mark.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			checkBox_No_Mark.Location = new System.Drawing.Point(8, 167);
			checkBox_No_Mark.Name = "checkBox_No_Mark";
			checkBox_No_Mark.Size = new System.Drawing.Size(166, 18);
			checkBox_No_Mark.TabIndex = 7;
			checkBox_No_Mark.Text = "不用Mark（谨慎修改）";
			checkBox_No_Mark.UseVisualStyleBackColor = true;
			checkBox_No_Mark.CheckedChanged += new System.EventHandler(checkBox_No_Mark_CheckedChanged);
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label6.Location = new System.Drawing.Point(138, 11);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(119, 14);
			label6.TabIndex = 6;
			label6.Text = "MARK规则高级配置";
			label3.BackColor = System.Drawing.Color.White;
			label3.Location = new System.Drawing.Point(-9, 365);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(740, 5);
			label3.TabIndex = 24;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 15f);
			label7.ForeColor = System.Drawing.Color.White;
			label7.Location = new System.Drawing.Point(77, 8);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(89, 20);
			label7.TabIndex = 1;
			label7.Text = "生产设置\r\n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(8, 439);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(140, 14);
			label8.TabIndex = 1;
			label8.Text = "行程内最高点Z轴高度";
			label9.BackColor = System.Drawing.Color.White;
			label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label9.Location = new System.Drawing.Point(8, 457);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(452, 46);
			label9.TabIndex = 25;
			radioButton_none_aftersmtdone.AutoSize = true;
			radioButton_none_aftersmtdone.Location = new System.Drawing.Point(8, 77);
			radioButton_none_aftersmtdone.Name = "radioButton_none_aftersmtdone";
			radioButton_none_aftersmtdone.Size = new System.Drawing.Size(95, 18);
			radioButton_none_aftersmtdone.TabIndex = 27;
			radioButton_none_aftersmtdone.TabStop = true;
			radioButton_none_aftersmtdone.Text = "无额外动作";
			radioButton_none_aftersmtdone.UseVisualStyleBackColor = true;
			radioButton_gotodefine_aftersmtdone.AutoSize = true;
			radioButton_gotodefine_aftersmtdone.Location = new System.Drawing.Point(8, 134);
			radioButton_gotodefine_aftersmtdone.Name = "radioButton_gotodefine_aftersmtdone";
			radioButton_gotodefine_aftersmtdone.Size = new System.Drawing.Size(137, 18);
			radioButton_gotodefine_aftersmtdone.TabIndex = 27;
			radioButton_gotodefine_aftersmtdone.TabStop = true;
			radioButton_gotodefine_aftersmtdone.Text = "定位到自定义坐标";
			radioButton_gotodefine_aftersmtdone.UseVisualStyleBackColor = true;
			radioButton_gotopik_aftersmtdone.AutoSize = true;
			radioButton_gotopik_aftersmtdone.Location = new System.Drawing.Point(8, 98);
			radioButton_gotopik_aftersmtdone.Name = "radioButton_gotopik_aftersmtdone";
			radioButton_gotopik_aftersmtdone.Size = new System.Drawing.Size(235, 32);
			radioButton_gotopik_aftersmtdone.TabIndex = 27;
			radioButton_gotopik_aftersmtdone.TabStop = true;
			radioButton_gotopik_aftersmtdone.Text = "定位到首轮取料坐标（提前取料）\r\n或MARK1（不提前取料）";
			radioButton_gotopik_aftersmtdone.UseVisualStyleBackColor = true;
			panel_safespace.Controls.Add(pictureBox2);
			panel_safespace.Controls.Add(numericUpDown_safespace);
			panel_safespace.Controls.Add(label123);
			panel_safespace.Controls.Add(label122);
			panel_safespace.Location = new System.Drawing.Point(287, 194);
			panel_safespace.Name = "panel_safespace";
			panel_safespace.Size = new System.Drawing.Size(315, 134);
			panel_safespace.TabIndex = 177;
			numericUpDown_safespace.DecimalPlaces = 1;
			numericUpDown_safespace.Font = new System.Drawing.Font("楷体", 10.5f);
			numericUpDown_safespace.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_safespace.Location = new System.Drawing.Point(132, 104);
			numericUpDown_safespace.Maximum = new decimal(new int[4] { 25, 0, 0, 0 });
			numericUpDown_safespace.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
			numericUpDown_safespace.Name = "numericUpDown_safespace";
			numericUpDown_safespace.Size = new System.Drawing.Size(57, 23);
			numericUpDown_safespace.TabIndex = 169;
			numericUpDown_safespace.Value = new decimal(new int[4] { 2, 0, 0, 0 });
			numericUpDown_safespace.ValueChanged += new System.EventHandler(numericUpDown_safespace_ValueChanged);
			label123.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			label123.Font = new System.Drawing.Font("黑体", 10.5f);
			label123.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			label123.Location = new System.Drawing.Point(130, 5);
			label123.Name = "label123";
			label123.Size = new System.Drawing.Size(176, 62);
			label123.TabIndex = 167;
			label123.Text = "请务必正确填写基准高度，\r\n相机高度，元件厚度等，\r\n综合考虑贴装情况，来设置\r\n\"贴装安全间隙\"";
			label122.AutoSize = true;
			label122.Font = new System.Drawing.Font("黑体", 11.25f);
			label122.ForeColor = System.Drawing.Color.White;
			label122.Location = new System.Drawing.Point(128, 82);
			label122.Name = "label122";
			label122.Size = new System.Drawing.Size(135, 15);
			label122.TabIndex = 167;
			label122.Text = "贴装安全间隙(mm)";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label2.Location = new System.Drawing.Point(3, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(147, 14);
			label2.TabIndex = 6;
			label2.Text = "工程模式（谨慎修改）";
			panel4.BackColor = System.Drawing.Color.Azure;
			panel4.Controls.Add(radioButton_prjmode1);
			panel4.Controls.Add(radioButton_prjmode0);
			panel4.Controls.Add(label2);
			panel4.Location = new System.Drawing.Point(14, 264);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(209, 62);
			panel4.TabIndex = 179;
			radioButton_prjmode1.AutoSize = true;
			radioButton_prjmode1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			radioButton_prjmode1.Location = new System.Drawing.Point(19, 42);
			radioButton_prjmode1.Name = "radioButton_prjmode1";
			radioButton_prjmode1.Size = new System.Drawing.Size(130, 18);
			radioButton_prjmode1.TabIndex = 180;
			radioButton_prjmode1.Text = "多种PCB板组模式";
			radioButton_prjmode1.UseVisualStyleBackColor = true;
			radioButton_prjmode1.CheckedChanged += new System.EventHandler(radioButton_prjmode1_CheckedChanged);
			radioButton_prjmode0.AutoSize = true;
			radioButton_prjmode0.Checked = true;
			radioButton_prjmode0.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			radioButton_prjmode0.Location = new System.Drawing.Point(19, 24);
			radioButton_prjmode0.Name = "radioButton_prjmode0";
			radioButton_prjmode0.Size = new System.Drawing.Size(116, 18);
			radioButton_prjmode0.TabIndex = 180;
			radioButton_prjmode0.TabStop = true;
			radioButton_prjmode0.Text = "单种PCB板模式";
			radioButton_prjmode0.UseVisualStyleBackColor = true;
			radioButton_prjmode0.CheckedChanged += new System.EventHandler(radioButton_prjmode0_CheckedChanged);
			checkBox_gen0_raisespeed.AutoSize = true;
			checkBox_gen0_raisespeed.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_gen0_raisespeed.ForeColor = System.Drawing.Color.White;
			checkBox_gen0_raisespeed.Location = new System.Drawing.Point(13, 239);
			checkBox_gen0_raisespeed.Name = "checkBox_gen0_raisespeed";
			checkBox_gen0_raisespeed.Size = new System.Drawing.Size(130, 19);
			checkBox_gen0_raisespeed.TabIndex = 180;
			checkBox_gen0_raisespeed.Text = "T系列机型提速";
			checkBox_gen0_raisespeed.UseVisualStyleBackColor = true;
			checkBox_gen0_raisespeed.Visible = false;
			checkBox_gen0_raisespeed.CheckedChanged += new System.EventHandler(checkBox_gen0_raisespeed_CheckedChanged);
			checkBox_afteryouxian_gotomark1.AutoSize = true;
			checkBox_afteryouxian_gotomark1.Location = new System.Drawing.Point(9, 30);
			checkBox_afteryouxian_gotomark1.Name = "checkBox_afteryouxian_gotomark1";
			checkBox_afteryouxian_gotomark1.Size = new System.Drawing.Size(229, 18);
			checkBox_afteryouxian_gotomark1.TabIndex = 181;
			checkBox_afteryouxian_gotomark1.Text = "提前取料或视觉后，定位到Mark1";
			checkBox_afteryouxian_gotomark1.UseVisualStyleBackColor = true;
			checkBox_afteryouxian_gotomark1.CheckedChanged += new System.EventHandler(checkBox_afteryouxian_gotomark1_CheckedChanged);
			checkBox_preparevacuum_veryearly.AutoSize = true;
			checkBox_preparevacuum_veryearly.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_preparevacuum_veryearly.ForeColor = System.Drawing.Color.White;
			checkBox_preparevacuum_veryearly.Location = new System.Drawing.Point(12, 119);
			checkBox_preparevacuum_veryearly.Name = "checkBox_preparevacuum_veryearly";
			checkBox_preparevacuum_veryearly.Size = new System.Drawing.Size(170, 19);
			checkBox_preparevacuum_veryearly.TabIndex = 182;
			checkBox_preparevacuum_veryearly.Text = "取料时，超前备真空";
			checkBox_preparevacuum_veryearly.UseVisualStyleBackColor = true;
			checkBox_preparevacuum_veryearly.CheckedChanged += new System.EventHandler(checkBox_preparevacuum_veryearly_CheckedChanged);
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(4, 8);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(91, 14);
			label10.TabIndex = 183;
			label10.Text = "等板间歇(ms)";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(180, 8);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(119, 14);
			label11.TabIndex = 183;
			label11.Text = "完成信号时常(ms)";
			panel_tran4.Controls.Add(numericUpDown_tran4_finishsignal_delay);
			panel_tran4.Controls.Add(numericUpDown_tran4_waitnewsignal_delay);
			panel_tran4.Controls.Add(label10);
			panel_tran4.Controls.Add(label11);
			panel_tran4.ForeColor = System.Drawing.Color.White;
			panel_tran4.Location = new System.Drawing.Point(287, 327);
			panel_tran4.Name = "panel_tran4";
			panel_tran4.Size = new System.Drawing.Size(444, 33);
			panel_tran4.TabIndex = 184;
			numericUpDown_tran4_finishsignal_delay.Location = new System.Drawing.Point(308, 3);
			numericUpDown_tran4_finishsignal_delay.Maximum = new decimal(new int[4] { 5000, 0, 0, 0 });
			numericUpDown_tran4_finishsignal_delay.Name = "numericUpDown_tran4_finishsignal_delay";
			numericUpDown_tran4_finishsignal_delay.Size = new System.Drawing.Size(58, 23);
			numericUpDown_tran4_finishsignal_delay.TabIndex = 184;
			numericUpDown_tran4_finishsignal_delay.Value = new decimal(new int[4] { 1000, 0, 0, 0 });
			numericUpDown_tran4_finishsignal_delay.ValueChanged += new System.EventHandler(numericUpDown_tran4_finishsignal_delay_ValueChanged);
			numericUpDown_tran4_waitnewsignal_delay.Location = new System.Drawing.Point(103, 3);
			numericUpDown_tran4_waitnewsignal_delay.Maximum = new decimal(new int[4] { 5000, 0, 0, 0 });
			numericUpDown_tran4_waitnewsignal_delay.Name = "numericUpDown_tran4_waitnewsignal_delay";
			numericUpDown_tran4_waitnewsignal_delay.Size = new System.Drawing.Size(58, 23);
			numericUpDown_tran4_waitnewsignal_delay.TabIndex = 184;
			numericUpDown_tran4_waitnewsignal_delay.Value = new decimal(new int[4] { 500, 0, 0, 0 });
			numericUpDown_tran4_waitnewsignal_delay.ValueChanged += new System.EventHandler(numericUpDown_tran4_waitnewsignal_delay_ValueChanged);
			panel_youxianpik.BackColor = System.Drawing.Color.White;
			panel_youxianpik.Controls.Add(button_close_youxianpik);
			panel_youxianpik.Controls.Add(radioButton_none_aftersmtdone);
			panel_youxianpik.Controls.Add(radioButton_gotodefine_aftersmtdone);
			panel_youxianpik.Controls.Add(checkBox_youxian_visual);
			panel_youxianpik.Controls.Add(radioButton_gotopik_aftersmtdone);
			panel_youxianpik.Controls.Add(label13);
			panel_youxianpik.Controls.Add(label_gotodefinexy_aftersmtdone);
			panel_youxianpik.Controls.Add(checkBox_afteryouxian_gotomark1);
			panel_youxianpik.Controls.Add(button_gotodefinexy_Save);
			panel_youxianpik.Controls.Add(button_gotodefinexy_Goto);
			panel_youxianpik.Location = new System.Drawing.Point(11, 159);
			panel_youxianpik.Name = "panel_youxianpik";
			panel_youxianpik.Size = new System.Drawing.Size(262, 197);
			panel_youxianpik.TabIndex = 185;
			panel_youxianpik.Visible = false;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("黑体", 11f);
			label13.Location = new System.Drawing.Point(58, 58);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(119, 15);
			label13.TabIndex = 6;
			label13.Text = "贴完一块板之后";
			label12.BackColor = System.Drawing.Color.Red;
			label12.Location = new System.Drawing.Point(12, 34);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(227, 6);
			label12.TabIndex = 186;
			panel2.Controls.Add(panel_youxianpik);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(panel_marksetting);
			panel2.Controls.Add(panel_tran4);
			panel2.Controls.Add(button_marksetting);
			panel2.Controls.Add(button_youxian_pik);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(checkBox_youxian_pik);
			panel2.Controls.Add(checkBox_preparevacuum_veryearly);
			panel2.Controls.Add(checkBox_gen0_raisespeed);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(panel_safespace);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(panel1);
			panel2.Controls.Add(checkBox5);
			panel2.Controls.Add(checkBox_ischeckNozzle);
			panel2.Controls.Add(checkBox_Loukong);
			panel2.Controls.Add(button_StackIsMount);
			panel2.Controls.Add(button_close);
			panel2.Controls.Add(button_SmtStackPlateStartNo);
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(714, 365);
			panel2.TabIndex = 189;
			label4.BackColor = System.Drawing.Color.White;
			label4.Location = new System.Drawing.Point(-3, -3);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(740, 5);
			label4.TabIndex = 24;
			pictureBox2.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox2.Image = QIGN_COMMON.Properties.Resources.SAFE_SPACE;
			pictureBox2.Location = new System.Drawing.Point(3, 3);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(124, 128);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 170;
			pictureBox2.TabStop = false;
			button_close_youxianpik.BackColor = System.Drawing.Color.LightGray;
			button_close_youxianpik.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_youxianpik.CnPressDownColor = System.Drawing.Color.White;
			button_close_youxianpik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button_close_youxianpik.Location = new System.Drawing.Point(230, 2);
			button_close_youxianpik.Name = "button_close_youxianpik";
			button_close_youxianpik.Size = new System.Drawing.Size(30, 30);
			button_close_youxianpik.TabIndex = 189;
			button_close_youxianpik.Text = "X";
			button_close_youxianpik.UseVisualStyleBackColor = false;
			button_close_youxianpik.Click += new System.EventHandler(button_close_youxianpik_Click);
			button_gotodefinexy_Save.BackColor = System.Drawing.Color.LightGray;
			button_gotodefinexy_Save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_gotodefinexy_Save.CnPressDownColor = System.Drawing.Color.White;
			button_gotodefinexy_Save.Enabled = false;
			button_gotodefinexy_Save.Location = new System.Drawing.Point(103, 158);
			button_gotodefinexy_Save.Name = "button_gotodefinexy_Save";
			button_gotodefinexy_Save.Size = new System.Drawing.Size(45, 32);
			button_gotodefinexy_Save.TabIndex = 0;
			button_gotodefinexy_Save.Text = "保存";
			button_gotodefinexy_Save.UseVisualStyleBackColor = false;
			button_gotodefinexy_Save.Click += new System.EventHandler(button_gotodefinexy_Save_Click);
			button_gotodefinexy_Goto.BackColor = System.Drawing.Color.LightGray;
			button_gotodefinexy_Goto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_gotodefinexy_Goto.CnPressDownColor = System.Drawing.Color.White;
			button_gotodefinexy_Goto.Enabled = false;
			button_gotodefinexy_Goto.Location = new System.Drawing.Point(149, 158);
			button_gotodefinexy_Goto.Name = "button_gotodefinexy_Goto";
			button_gotodefinexy_Goto.Size = new System.Drawing.Size(45, 32);
			button_gotodefinexy_Goto.TabIndex = 0;
			button_gotodefinexy_Goto.Text = "定位";
			button_gotodefinexy_Goto.UseVisualStyleBackColor = false;
			button_gotodefinexy_Goto.Click += new System.EventHandler(button_gotodefinexy_Goto_Click);
			button_close_marksetting.BackColor = System.Drawing.Color.LightGray;
			button_close_marksetting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_marksetting.CnPressDownColor = System.Drawing.Color.White;
			button_close_marksetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button_close_marksetting.Location = new System.Drawing.Point(388, 4);
			button_close_marksetting.Name = "button_close_marksetting";
			button_close_marksetting.Size = new System.Drawing.Size(30, 30);
			button_close_marksetting.TabIndex = 189;
			button_close_marksetting.Text = "X";
			button_close_marksetting.UseVisualStyleBackColor = false;
			button_close_marksetting.Click += new System.EventHandler(button_close_marksetting_Click);
			button_marksetting.BackColor = System.Drawing.Color.LightGray;
			button_marksetting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_marksetting.CnPressDownColor = System.Drawing.Color.White;
			button_marksetting.Font = new System.Drawing.Font("黑体", 11f);
			button_marksetting.Location = new System.Drawing.Point(287, 161);
			button_marksetting.Name = "button_marksetting";
			button_marksetting.Size = new System.Drawing.Size(189, 31);
			button_marksetting.TabIndex = 188;
			button_marksetting.Text = "MARK规则高级配置";
			button_marksetting.UseVisualStyleBackColor = false;
			button_marksetting.Click += new System.EventHandler(button_marksetting_Click);
			button_youxian_pik.BackColor = System.Drawing.Color.LightGray;
			button_youxian_pik.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_youxian_pik.CnPressDownColor = System.Drawing.Color.White;
			button_youxian_pik.Font = new System.Drawing.Font("黑体", 11f);
			button_youxian_pik.Location = new System.Drawing.Point(12, 162);
			button_youxian_pik.Name = "button_youxian_pik";
			button_youxian_pik.Size = new System.Drawing.Size(196, 31);
			button_youxian_pik.TabIndex = 187;
			button_youxian_pik.Text = "高级配置详情";
			button_youxian_pik.UseVisualStyleBackColor = false;
			button_youxian_pik.Click += new System.EventHandler(button_youxian_pik_Click);
			button_StackIsMount.BackColor = System.Drawing.Color.LightGray;
			button_StackIsMount.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_StackIsMount.CnPressDownColor = System.Drawing.Color.White;
			button_StackIsMount.Font = new System.Drawing.Font("黑体", 11.5f);
			button_StackIsMount.Location = new System.Drawing.Point(12, 43);
			button_StackIsMount.Name = "button_StackIsMount";
			button_StackIsMount.Size = new System.Drawing.Size(101, 51);
			button_StackIsMount.TabIndex = 0;
			button_StackIsMount.Text = "是否贴装";
			button_StackIsMount.UseVisualStyleBackColor = false;
			button_StackIsMount.Click += new System.EventHandler(button_StackIsMount_Click);
			button_close.BackColor = System.Drawing.Color.LightGray;
			button_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close.CnPressDownColor = System.Drawing.Color.White;
			button_close.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_close.Location = new System.Drawing.Point(672, 6);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(28, 28);
			button_close.TabIndex = 0;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = false;
			button_close.Click += new System.EventHandler(button_close_Click);
			button_SmtStackPlateStartNo.BackColor = System.Drawing.Color.LightGray;
			button_SmtStackPlateStartNo.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SmtStackPlateStartNo.CnPressDownColor = System.Drawing.Color.White;
			button_SmtStackPlateStartNo.Font = new System.Drawing.Font("黑体", 11.5f);
			button_SmtStackPlateStartNo.Location = new System.Drawing.Point(123, 43);
			button_SmtStackPlateStartNo.Name = "button_SmtStackPlateStartNo";
			button_SmtStackPlateStartNo.Size = new System.Drawing.Size(101, 51);
			button_SmtStackPlateStartNo.TabIndex = 0;
			button_SmtStackPlateStartNo.Text = "料盘起始";
			button_SmtStackPlateStartNo.UseVisualStyleBackColor = false;
			button_SmtStackPlateStartNo.Click += new System.EventHandler(button_SmtStackPlateStartNo_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.DimGray;
			base.Controls.Add(panel2);
			base.Controls.Add(label3);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_SmtSetting";
			base.Size = new System.Drawing.Size(714, 370);
			base.Load += new System.EventHandler(UserControl_SmtSetting_Load);
			base.MouseClick += new System.Windows.Forms.MouseEventHandler(UserControl_SmtSetting_MouseClick);
			((System.ComponentModel.ISupportInitialize)numericUpDown_failretryNum).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_marksetting.ResumeLayout(false);
			panel_marksetting.PerformLayout();
			panel_safespace.ResumeLayout(false);
			panel_safespace.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_safespace).EndInit();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel_tran4.ResumeLayout(false);
			panel_tran4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_tran4_finishsignal_delay).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_tran4_waitnewsignal_delay).EndInit();
			panel_youxianpik.ResumeLayout(false);
			panel_youxianpik.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public UserControl_SmtSetting(int fn, USR_DATA usr, USR2_DATA usr2, USR3_BASE usr3b)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR3B = usr3b;
			USR_INIT = MainForm0.USR_INIT;
			USR2 = usr2;
			U3 = MainForm0.U3[mFn];
			U3Idx = MainForm0.U3Idx[mFn];
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "生产设置", "生產設置", "Smt Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_StackIsMount,
				str = new string[3] { "是否贴装", "是否貼裝", "Is Mount" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SmtStackPlateStartNo,
				str = new string[3] { "料盘起始", "料盤起始", "Plate Start Index" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_Loukong,
				str = new string[3] { "镂空板", "鏤空板", "Hollow PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_preparevacuum_veryearly,
				str = new string[3] { "取料时，超前备真空", "取料時，超前備真空", "Open vacuum very early" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_youxian_pik,
				str = new string[3] { "提前取料（全自动运行时）", "提前取料（全自動運行時）", "Pre-Pick in Auto Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_youxian_pik,
				str = new string[3] { "高级配置详情", "高級配置詳情", "High Level Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_youxian_visual,
				str = new string[3] { "提前取料后，直接视觉", "提前取料後，直接視覺", "Pre-Visual After Pre-Pick" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_afteryouxian_gotomark1,
				str = new string[3] { "提前取料或视觉后，定位到Mark1", "提前取料或視覺後，定位到Mark1", "Goto Mark1 after Pre-Pick&Visual" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label13,
				str = new string[3] { "贴完一块板之后", "貼完壹塊板之後", "When Complete one PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_none_aftersmtdone,
				str = new string[3] { "无额外动作", "無額外動作", "Do Nothing" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_gotopik_aftersmtdone,
				str = new string[3]
				{
					"定位到首轮取料坐标（提前取料）" + Environment.NewLine + "或MARK1（不提前取料）",
					"定位到首輪取料坐標（提前取料）" + Environment.NewLine + "或MARK1（不提前取料）",
					"Goto Pick Place（Pre-Pick Mode）" + Environment.NewLine + "Or MARK1（Not Pre-Pick）"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_gotodefine_aftersmtdone,
				str = new string[3] { "定位到自定义坐标", "定位到自定義坐標", "Goto Defined Coord" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_gotodefinexy_Save,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_gotodefinexy_Goto,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "元件识别失败处理", "元件識別失敗處理", "Solution when chip visual fail" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_visualfailretry_rightnow,
				str = new string[3] { "元件识别失败，立即抛料重取", "元件識別失敗，立即拋料重取", "Drop Directly and Re-Pick" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_visualfailretry_afterfinish,
				str = new string[3] { "元件识别失败，完成单PCB贴装后统一补料", "元件識別失敗，完成單PCB貼裝後統壹補料", "Remedy after the board is finished" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton1,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "重取次数", "重取次數", "Retry Count" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_marksetting,
				str = new string[3] { "MARK规则高级配置", "MARK規則高級配置", "Mark Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "MARK规则高级配置", "MARK規則高級配置", "Mark Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_AutoFail_ToManual,
				str = new string[3] { "自动Mark失败就立即手动Mark", "自動Mark失敗就立即手動Mark", "Use manunl Mark mode when auto mark fail" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_Memory_Mark,
				str = new string[3] { "全自动时记忆", "全自動時記憶", "Remember when Auto Run Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton4,
				str = new string[3] { "Mark失败，结束当前板组，并退出全自动", "Mark失敗，結束當前板組，並退出全自動", "When mark fail, exit current PCBs, then exit auto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton3,
				str = new string[3] { "Mark失败，跳过当前板组，并继续全自动", "Mark失敗，跳過當前板組，並繼續全自動", "When mark fail, skip current PCBs, continue auto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton6,
				str = new string[3] { "Mark失败，跳过当前子PCB，继续完成当前板组，并退出全自动", "Mark失敗，跳過當前子PCB，繼續完成當前板組，並退出全自動", "When mark fail, skip current sub PCB, continue cur PCBs, exit Auto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton5,
				str = new string[3] { "Mark失败，跳过当前子PCB，继续完成当前板组，并继续全自动", "Mark失敗，跳過當前子PCB，繼續完成當前板組，並繼續全自動", "When mark fail, skip current sub PCB, continue cur PCBs, continue Auto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_No_Mark,
				str = new string[3] { "不用Mark（谨慎修改）", "不用Mark（謹慎修改）", "None Mark" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "工程模式（谨慎修改）", "工程模式（謹慎修改）", "Project Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_prjmode0,
				str = new string[3] { "单种PCB板模式", "單種PCB板模式", "Single PCB Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_prjmode1,
				str = new string[3] { "多种PCB板组模式", "多種PCB板組模式", "Multi PCB Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label122,
				str = new string[3] { "贴装安全间隙(mm)", "貼裝安全間隙(mm)", "Smt Safe Space (mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label10,
				str = new string[3] { "等板间歇(ms)", "等板間歇(ms)", "Wait PCB Delay (ms)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "完成信号时常(ms)", "完成信號時常(ms)", "End-Signal Delay (ms)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label123,
				str = new string[3]
				{
					"请务必正确填写基准高度，" + Environment.NewLine + "相机高度，元件厚度等，" + Environment.NewLine + "综合考虑贴装情况，来设置" + Environment.NewLine + "贴装安全间隙",
					"請務必正確填寫基準高度，" + Environment.NewLine + "相機高度，元件厚度等，" + Environment.NewLine + "綜合考慮貼裝情況，來設置" + Environment.NewLine + "貼裝安全間隙",
					"Please fill correct base-H，" + Environment.NewLine + "camera base-H，chip-H，" + Environment.NewLine + " and totally smt to set " + Environment.NewLine + "Smt Safe Space"
				}
			});
			return list;
		}

		private void UserControl_SmtSetting_Load(object sender, EventArgs e)
		{
			if (HW.mFnNum >= 2)
			{
				checkBox_Loukong.Visible = false;
			}
			panel_safespace.Visible = HW.mSmtGenerationNo != 0;
			checkBox_No_Mark.Checked = USR3B.mIsDisableMark;
			checkBox_Memory_Mark.Checked = USR3B.mIsMemoryMark;
			checkBox_AutoFail_ToManual.Checked = USR3B.mIsAutoFail_then_ManualMark;
			numericUpDown_failretryNum.Value = USR3B.mSmtPikRetryNum;
			radioButton_visualfailretry_rightnow.Checked = !USR3B.mIsPikRetry_AfterFinish;
			radioButton_markfail = new RadioButton[4] { radioButton4, radioButton3, radioButton6, radioButton5 };
			for (int i = 0; i < 4; i++)
			{
				radioButton_markfail[i].Tag = i;
				radioButton_markfail[i].CheckedChanged += radioButton_markfail_CheckedChanged;
				if (i == (int)USR3B.mMarkFailtoDo)
				{
					radioButton_markfail[i].Checked = true;
				}
			}
			CheckBox checkBox = checkBox_youxian_pik;
			CheckBox checkBox2 = checkBox_youxian_visual;
			bool flag = (checkBox_afteryouxian_gotomark1.Enabled = USR3B.mIsYouxianPik);
			bool @checked = (checkBox2.Enabled = flag);
			checkBox.Checked = @checked;
			checkBox_youxian_visual.Checked = USR3B.mIsYouxianVisual;
			checkBox_afteryouxian_gotomark1.Checked = USR3B.mIsAfterYouxianPikGotoMark1;
			radioButton_gotoxy_aftersmtdone = new RadioButton[3] { radioButton_none_aftersmtdone, radioButton_gotopik_aftersmtdone, radioButton_gotodefine_aftersmtdone };
			for (int j = 0; j < 3; j++)
			{
				radioButton_gotoxy_aftersmtdone[j].Tag = j;
				radioButton_gotoxy_aftersmtdone[j].CheckedChanged += radioButton_gotoxy_aftersmtdone_CheckedChanged;
				radioButton_gotoxy_aftersmtdone[j].Checked = ((j == USR3B.mGotoXYafterSmtDone_v) ? true : false);
			}
			if (USR3B.mGotoXYafterSmtDone_Define == null)
			{
				USR3B.mGotoXYafterSmtDone_Define = new Coordinate(0L, 0L);
			}
			label_gotodefinexy_aftersmtdone.Text = MainForm0.format_XY_label_string(USR3B.mGotoXYafterSmtDone_Define);
			checkBox_Loukong.Checked = USR3B.mIsLoukongPCB;
			checkBox_ischeckNozzle.Checked = USR3B.mIsCheckNozzleDirty;
			checkBox_gen0_raisespeed.Checked = USR3B.mIsGen0RaiseSpeed;
			checkBox_preparevacuum_veryearly.Checked = USR3B.mIsPrepareVacuum_veryEarly;
			radioButton_prjmode0.CheckedChanged -= radioButton_prjmode0_CheckedChanged;
			radioButton_prjmode1.CheckedChanged -= radioButton_prjmode1_CheckedChanged;
			radioButton_prjmode0.Checked = ((USR3B.mPrjMode == 0) ? true : false);
			radioButton_prjmode1.Checked = USR3B.mPrjMode == 1;
			radioButton_prjmode0.CheckedChanged += radioButton_prjmode0_CheckedChanged;
			radioButton_prjmode1.CheckedChanged += radioButton_prjmode1_CheckedChanged;
			flush_prjmode();
			panel_tran4.Visible = ((HW.mDeviceType == DeviceType.HW_6S_TRAN4 || HW.mDeviceType == DeviceType.HW_8S_TRAN4) ? true : false);
			if (USR3B.mOem == null)
			{
				USR3B.mOem = new OEM_USR3_BASE();
			}
			numericUpDown_tran4_waitnewsignal_delay.Value = USR3B.mOem.tran4_waitnewsignal_delay;
			numericUpDown_tran4_finishsignal_delay.Value = USR3B.mOem.tran4_finishsignal_delay;
			if (USR3B.mInBoardMode == 1)
			{
				checkBox_Loukong.Enabled = false;
				checkBox_youxian_pik.Enabled = false;
				button_youxian_pik.Enabled = false;
			}
			if (!HW.mIsSanduanshi)
			{
				checkBox_youxian_pik.Visible = false;
				USR3B.mIsYouxianPik = false;
				USR3B.mIsYouxianVisual = false;
				button_youxian_pik.Visible = false;
				USR3B.mIsAfterYouxianPikGotoMark1 = false;
				USR3B.mGotoXYafterSmtDone_v = 0;
			}
			MainForm0.CreateAddButtonPic(button_StackIsMount);
			MainForm0.CreateAddButtonPic(button_SmtStackPlateStartNo);
			MainForm0.CreateAddButtonPic(button_youxian_pik);
			MainForm0.CreateAddButtonPic(button_marksetting);
			MainForm0.CreateAddButtonPic(button_gotodefinexy_Save);
			MainForm0.CreateAddButtonPic(button_gotodefinexy_Goto);
			MainForm0.CreateAddButtonPic(button_close);
			MainForm0.CreateAddButtonPic(button_close_youxianpik);
			MainForm0.CreateAddButtonPic(button_close_marksetting);
			MainForm0.CreateAddButtonPic(button_close_youxianpik);
			MainForm0.CreateAddButtonPic(button_close_youxianpik);
			MainForm0.CreateAddButtonPic(button_close_youxianpik);
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void radioButton_markfail_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				USR3B.mMarkFailtoDo = (MarkFailtoDo)radioButton.Tag;
			}
		}

		private void checkBox_No_Mark_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsDisableMark = checkBox_No_Mark.Checked;
		}

		private void checkBox_MemoryMark_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsMemoryMark = checkBox_Memory_Mark.Checked;
		}

		private void checkBox_AutoFailToManual_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsAutoFail_then_ManualMark = checkBox_AutoFail_ToManual.Checked;
		}

		private void numericUpDown_failretryNum_ValueChanged(object sender, EventArgs e)
		{
			USR3B.mSmtPikRetryNum = (int)numericUpDown_failretryNum.Value;
		}

		private void radioButton_visualfailretry_rightnow_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsPikRetry_AfterFinish = !radioButton_visualfailretry_rightnow.Checked;
		}

		private void checkBox_youxian_pik_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsYouxianPik = checkBox_youxian_pik.Checked;
			CheckBox checkBox = checkBox_afteryouxian_gotomark1;
			bool enabled = (checkBox_youxian_visual.Enabled = USR3B.mIsYouxianPik);
			checkBox.Enabled = enabled;
		}

		private void checkBox_youxian_visual_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsYouxianVisual = checkBox_youxian_visual.Checked;
		}

		private void radioButton_gotoxy_aftersmtdone_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			int num = (int)radioButton.Tag;
			if (radioButton.Checked)
			{
				USR3B.mGotoXYafterSmtDone_v = num;
				label_gotodefinexy_aftersmtdone.Enabled = num == 2;
				CnButton cnButton = button_gotodefinexy_Goto;
				bool enabled = (button_gotodefinexy_Save.Enabled = num == 2);
				cnButton.Enabled = enabled;
			}
		}

		private void button_gotodefinexy_Save_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox("是否保存坐标", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR3B.mGotoXYafterSmtDone_Define.X = MainForm0.mCur[MainForm0.mFn].x;
				USR3B.mGotoXYafterSmtDone_Define.Y = MainForm0.mCur[MainForm0.mFn].y;
				MainForm0.save_usrProjectData();
				label_gotodefinexy_aftersmtdone.Text = MainForm0.format_XY_label_string(USR3B.mGotoXYafterSmtDone_Define);
			}
		}

		private void button_gotodefinexy_Goto_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[MainForm0.mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR3B.mGotoXYafterSmtDone_Define);
			}
		}

		private void numericUpDown_safespace_ValueChanged(object sender, EventArgs e)
		{
			USR3B.mSmtSafeSpace = (float)numericUpDown_safespace.Value;
		}

		private void button_StackIsMount_Click(object sender, EventArgs e)
		{
			Form_SmtArrayIsMount form_SmtArrayIsMount = new Form_SmtArrayIsMount(mFn, USR3B.mFeederInstallList, USR3B.mIsMountStacksNew, U3[U3Idx]);
			form_SmtArrayIsMount.button_subpcb_sel += this.button_subpcb_sel.Invoke;
			form_SmtArrayIsMount.ShowDialog();
			Dispose();
		}

		private void button_SmtStackPlateStartNo_Click(object sender, EventArgs e)
		{
			StackElement[] stack = USR2.mStackLib.stacktab[1];
			_ = USR2.mStackLib.index[1];
			Form_SmtStackPlateStartIndex form_SmtStackPlateStartIndex = new Form_SmtStackPlateStartIndex(USR_INIT.mLanguage, stack);
			form_SmtStackPlateStartIndex.ShowDialog();
			_ = 2;
			Dispose();
		}

		private void radioButton_prjmode0_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_prjmode0.Checked)
			{
				string[] array = new string[3] { "确认修改工程模式吗？", "確認修改工程模式嗎？", "Are you going to change project mode?" };
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					USR3B.mPrjMode = 0;
				}
				else
				{
					radioButton_prjmode1.CheckedChanged -= radioButton_prjmode1_CheckedChanged;
					radioButton_prjmode1.Checked = true;
					radioButton_prjmode1.CheckedChanged += radioButton_prjmode1_CheckedChanged;
					USR3B.mPrjMode = 1;
				}
				flush_prjmode();
			}
		}

		private void radioButton_prjmode1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_prjmode1.Checked)
			{
				string[] array = new string[3] { "确认修改工程模式吗？", "確認修改工程模式嗎？", "Are you going to change project mode?" };
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					USR3B.mPrjMode = 1;
				}
				else
				{
					radioButton_prjmode0.CheckedChanged -= radioButton_prjmode0_CheckedChanged;
					radioButton_prjmode0.Checked = true;
					radioButton_prjmode0.CheckedChanged += radioButton_prjmode0_CheckedChanged;
					USR3B.mPrjMode = 0;
				}
				flush_prjmode();
			}
		}

		private void flush_prjmode()
		{
			radioButton_markfail[2].Visible = USR3B.mPrjMode == 1;
			radioButton_markfail[3].Visible = USR3B.mPrjMode == 1;
			if (USR3B.mPrjMode == 0 && (USR3B.mMarkFailtoDo == MarkFailtoDo.EndPcb_ContinueLoop_andContinue || USR3B.mMarkFailtoDo == MarkFailtoDo.EndPcb_ContinueLoop_andExit))
			{
				USR3B.mMarkFailtoDo = MarkFailtoDo.EndLoop_andExit;
				radioButton_markfail[(int)USR3B.mMarkFailtoDo].Checked = true;
			}
			if (USR3B.mIsPrjModeFixed)
			{
				panel4.Enabled = false;
			}
			MainForm0.uc_job[mFn].flush_proj_mode();
		}

		private void checkBox_Loukong_CheckedChanged(object sender, EventArgs e)
		{
			if (USR3B != null)
			{
				USR3B.mIsLoukongPCB = checkBox_Loukong.Checked;
				if (!MainForm0.mIsSimulation && MainForm0.mConDevExt != null && MainForm0.mConDevExt[0] != null)
				{
					MainForm0.mConDevExt[0].send_loukong_enable(USR3B.mIsLoukongPCB ? 1 : 0, HW.mIsSanduanshi);
				}
			}
		}

		private void checkBox_ischeckNozzle_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsCheckNozzleDirty = checkBox_ischeckNozzle.Checked;
		}

		private void checkBox_gen0_raisespeed_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsGen0RaiseSpeed = checkBox_gen0_raisespeed.Checked;
			USR3B.mGen0SafeZ = (checkBox_gen0_raisespeed.Checked ? 768 : 768);
		}

		private void checkBox_afteryouxian_gotomark1_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsAfterYouxianPikGotoMark1 = checkBox_afteryouxian_gotomark1.Checked;
		}

		private void checkBox_preparevacuum_veryearly_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsPrepareVacuum_veryEarly = checkBox_preparevacuum_veryearly.Checked;
		}

		private void numericUpDown_tran4_waitnewsignal_delay_ValueChanged(object sender, EventArgs e)
		{
			if (USR3B.mOem == null)
			{
				USR3B.mOem = new OEM_USR3_BASE();
			}
			USR3B.mOem.tran4_waitnewsignal_delay = (int)numericUpDown_tran4_waitnewsignal_delay.Value;
		}

		private void numericUpDown_tran4_finishsignal_delay_ValueChanged(object sender, EventArgs e)
		{
			if (USR3B.mOem == null)
			{
				USR3B.mOem = new OEM_USR3_BASE();
			}
			USR3B.mOem.tran4_finishsignal_delay = (int)numericUpDown_tran4_finishsignal_delay.Value;
		}

		private void UserControl_SmtSetting_MouseClick(object sender, MouseEventArgs e)
		{
			panel_youxianpik.Visible = false;
		}

		private void button_youxian_pik_Click(object sender, EventArgs e)
		{
			panel_youxianpik.Visible = true;
		}

		private void button_close_youxianpik_Click(object sender, EventArgs e)
		{
			panel_youxianpik.Visible = false;
		}

		private void button_marksetting_Click(object sender, EventArgs e)
		{
			panel_marksetting.Visible = true;
		}

		private void button_close_marksetting_Click(object sender, EventArgs e)
		{
			panel_marksetting.Visible = false;
		}
	}
}
