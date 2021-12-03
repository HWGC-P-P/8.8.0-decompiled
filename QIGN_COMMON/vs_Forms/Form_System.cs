using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_System : Form
	{
		private IContainer components;

		private Label label1;

		private CnButton button_def_channel;

		private Panel panel112;

		private CnButton button_warningalarm_set;

		private Label label_sw_state;

		private CnButton button_sw_register;

		private Label label_keytime;

		private Label label_revision;

		private Label label_sw_version;

		private CnButton button_lock_engineerpassword;

		private CnButton button_modify_engineerpassword;

		private CnButton button_Library;

		private Label label_smtmiles;

		private ComboBox cbo_SmtDevice;

		private ComboBox comboBox_SmtSubDevice;

		private Panel panel_openshape;

		private CheckBox checkBox_FeederGoodbye;

		private RadioButton radioButton_SafeOpenShapeStop;

		private CnButton button_M;

		private RadioButton radioButton_SafeOpenShapeSlow;

		private Label label14;

		private Label lb_language;

		private CnButton button_UsedAsTab;

		private Label label_devicetype;

		private ComboBox cbo_languige;

		private CnButton button_ParameterRestore;

		private Label label16AC;

		private CheckBox checkBox_BCT;

		private Label label11;

		private CnButton button_ParameterSaveAs;

		private Label label_firmware_version_0;

		private Panel panel63;

		private CnButton button_track_speedbase;

		private NumericUpDown numericUpDown_track_speedbase;

		private Label label216;

		private Label label_firmware_version_1;

		private Label label_firmware_version_2;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label61;

		private Panel panel_inboard_mode;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private Label label7;

		private Label label_firmware_version_3;

		private USR_INIT_DATA USR_INIT;

		private USR_DATA USR;

		private RadioButton[] radioButton_inboard_mode;

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
			panel112 = new System.Windows.Forms.Panel();
			label_sw_state = new System.Windows.Forms.Label();
			label_keytime = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label_revision = new System.Windows.Forms.Label();
			label_sw_version = new System.Windows.Forms.Label();
			label_smtmiles = new System.Windows.Forms.Label();
			cbo_SmtDevice = new System.Windows.Forms.ComboBox();
			comboBox_SmtSubDevice = new System.Windows.Forms.ComboBox();
			panel_openshape = new System.Windows.Forms.Panel();
			checkBox_FeederGoodbye = new System.Windows.Forms.CheckBox();
			radioButton_SafeOpenShapeStop = new System.Windows.Forms.RadioButton();
			radioButton_SafeOpenShapeSlow = new System.Windows.Forms.RadioButton();
			label14 = new System.Windows.Forms.Label();
			lb_language = new System.Windows.Forms.Label();
			label_devicetype = new System.Windows.Forms.Label();
			cbo_languige = new System.Windows.Forms.ComboBox();
			label16AC = new System.Windows.Forms.Label();
			checkBox_BCT = new System.Windows.Forms.CheckBox();
			label11 = new System.Windows.Forms.Label();
			label_firmware_version_0 = new System.Windows.Forms.Label();
			panel63 = new System.Windows.Forms.Panel();
			numericUpDown_track_speedbase = new System.Windows.Forms.NumericUpDown();
			label216 = new System.Windows.Forms.Label();
			label_firmware_version_1 = new System.Windows.Forms.Label();
			label_firmware_version_2 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label61 = new System.Windows.Forms.Label();
			panel_inboard_mode = new System.Windows.Forms.Panel();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			label7 = new System.Windows.Forms.Label();
			label_firmware_version_3 = new System.Windows.Forms.Label();
			button_Library = new QIGN_COMMON.vs_acontrol.CnButton();
			button_lock_engineerpassword = new QIGN_COMMON.vs_acontrol.CnButton();
			button_sw_register = new QIGN_COMMON.vs_acontrol.CnButton();
			button_warningalarm_set = new QIGN_COMMON.vs_acontrol.CnButton();
			button_M = new QIGN_COMMON.vs_acontrol.CnButton();
			button_modify_engineerpassword = new QIGN_COMMON.vs_acontrol.CnButton();
			button_def_channel = new QIGN_COMMON.vs_acontrol.CnButton();
			button_track_speedbase = new QIGN_COMMON.vs_acontrol.CnButton();
			button_UsedAsTab = new QIGN_COMMON.vs_acontrol.CnButton();
			button_ParameterRestore = new QIGN_COMMON.vs_acontrol.CnButton();
			button_ParameterSaveAs = new QIGN_COMMON.vs_acontrol.CnButton();
			panel112.SuspendLayout();
			panel_openshape.SuspendLayout();
			panel63.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_track_speedbase).BeginInit();
			panel_inboard_mode.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14.5f);
			label1.Location = new System.Drawing.Point(20, 22);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 20);
			label1.TabIndex = 0;
			label1.Text = "系统参数";
			panel112.Controls.Add(label_sw_state);
			panel112.Controls.Add(button_sw_register);
			panel112.Controls.Add(label_keytime);
			panel112.Controls.Add(label6);
			panel112.Location = new System.Drawing.Point(17, 422);
			panel112.Name = "panel112";
			panel112.Size = new System.Drawing.Size(820, 52);
			panel112.TabIndex = 170;
			label_sw_state.Font = new System.Drawing.Font("黑体", 12f);
			label_sw_state.Location = new System.Drawing.Point(121, 12);
			label_sw_state.Name = "label_sw_state";
			label_sw_state.Size = new System.Drawing.Size(151, 27);
			label_sw_state.TabIndex = 158;
			label_sw_state.Text = "试用版本 功能受限";
			label_keytime.Font = new System.Drawing.Font("黑体", 12f);
			label_keytime.Location = new System.Drawing.Point(278, 12);
			label_keytime.Name = "label_keytime";
			label_keytime.Size = new System.Drawing.Size(159, 27);
			label_keytime.TabIndex = 0;
			label_keytime.Text = "2019/06/01 18:00:00";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("黑体", 12f);
			label6.Location = new System.Drawing.Point(6, 11);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(72, 16);
			label6.TabIndex = 0;
			label6.Text = "软件授权";
			label_revision.AutoSize = true;
			label_revision.Font = new System.Drawing.Font("黑体", 12f);
			label_revision.Location = new System.Drawing.Point(23, 77);
			label_revision.Name = "label_revision";
			label_revision.Size = new System.Drawing.Size(72, 16);
			label_revision.TabIndex = 158;
			label_revision.Text = "软件版本";
			label_sw_version.BackColor = System.Drawing.Color.AntiqueWhite;
			label_sw_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_sw_version.Font = new System.Drawing.Font("楷体", 11f);
			label_sw_version.Location = new System.Drawing.Point(136, 73);
			label_sw_version.Name = "label_sw_version";
			label_sw_version.Size = new System.Drawing.Size(173, 23);
			label_sw_version.TabIndex = 158;
			label_sw_version.Text = "190516_3.7.0_T0";
			label_sw_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_smtmiles.BackColor = System.Drawing.Color.White;
			label_smtmiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_smtmiles.Font = new System.Drawing.Font("楷体", 11f);
			label_smtmiles.Location = new System.Drawing.Point(136, 226);
			label_smtmiles.Name = "label_smtmiles";
			label_smtmiles.Size = new System.Drawing.Size(173, 25);
			label_smtmiles.TabIndex = 158;
			label_smtmiles.Text = "0 CHIPS";
			label_smtmiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cbo_SmtDevice.DisplayMember = "1";
			cbo_SmtDevice.Font = new System.Drawing.Font("黑体", 12f);
			cbo_SmtDevice.FormattingEnabled = true;
			cbo_SmtDevice.Items.AddRange(new object[16]
			{
				"HW_4_50", "HW_4_42", "HW_4_44", "HW_6", "HW_6S", "HW_8S", "HW_8SX", "HW_8S_PLUS", "HW_8S_3LED", "HW_6_FLK",
				"HW_6_TRANSFER", "DT408H", "HW_6_TRAN2", "HW_4SG_50", "HW_6S_TRAN3", "HW_6SX"
			});
			cbo_SmtDevice.Location = new System.Drawing.Point(136, 288);
			cbo_SmtDevice.Name = "cbo_SmtDevice";
			cbo_SmtDevice.Size = new System.Drawing.Size(173, 24);
			cbo_SmtDevice.TabIndex = 1;
			cbo_SmtDevice.SelectedIndexChanged += new System.EventHandler(cbo_SmtDevice_SelectedIndexChanged);
			comboBox_SmtSubDevice.Font = new System.Drawing.Font("黑体", 12f);
			comboBox_SmtSubDevice.FormattingEnabled = true;
			comboBox_SmtSubDevice.Items.AddRange(new object[2] { "标准机型", "加长机型（支持600mm板长）" });
			comboBox_SmtSubDevice.Location = new System.Drawing.Point(313, 289);
			comboBox_SmtSubDevice.Name = "comboBox_SmtSubDevice";
			comboBox_SmtSubDevice.Size = new System.Drawing.Size(156, 24);
			comboBox_SmtSubDevice.TabIndex = 165;
			comboBox_SmtSubDevice.Visible = false;
			comboBox_SmtSubDevice.SelectedIndexChanged += new System.EventHandler(comboBox_SmtSubDevice_SelectedIndexChanged);
			panel_openshape.Controls.Add(checkBox_FeederGoodbye);
			panel_openshape.Controls.Add(radioButton_SafeOpenShapeStop);
			panel_openshape.Controls.Add(radioButton_SafeOpenShapeSlow);
			panel_openshape.Controls.Add(label14);
			panel_openshape.Location = new System.Drawing.Point(18, 370);
			panel_openshape.Name = "panel_openshape";
			panel_openshape.Size = new System.Drawing.Size(512, 54);
			panel_openshape.TabIndex = 164;
			checkBox_FeederGoodbye.AutoSize = true;
			checkBox_FeederGoodbye.Font = new System.Drawing.Font("黑体", 12f);
			checkBox_FeederGoodbye.Location = new System.Drawing.Point(121, 30);
			checkBox_FeederGoodbye.Name = "checkBox_FeederGoodbye";
			checkBox_FeederGoodbye.Size = new System.Drawing.Size(275, 20);
			checkBox_FeederGoodbye.TabIndex = 1;
			checkBox_FeederGoodbye.Text = "飞达防撞 （需要安装安全传感器）";
			checkBox_FeederGoodbye.UseVisualStyleBackColor = true;
			checkBox_FeederGoodbye.CheckedChanged += new System.EventHandler(checkBox_FeederGoodbye_CheckedChanged);
			radioButton_SafeOpenShapeStop.AutoSize = true;
			radioButton_SafeOpenShapeStop.Font = new System.Drawing.Font("黑体", 12f);
			radioButton_SafeOpenShapeStop.Location = new System.Drawing.Point(282, 3);
			radioButton_SafeOpenShapeStop.Name = "radioButton_SafeOpenShapeStop";
			radioButton_SafeOpenShapeStop.Size = new System.Drawing.Size(90, 20);
			radioButton_SafeOpenShapeStop.TabIndex = 0;
			radioButton_SafeOpenShapeStop.Text = "开盖停机";
			radioButton_SafeOpenShapeStop.UseVisualStyleBackColor = true;
			radioButton_SafeOpenShapeSlow.AutoSize = true;
			radioButton_SafeOpenShapeSlow.Checked = true;
			radioButton_SafeOpenShapeSlow.Font = new System.Drawing.Font("黑体", 12f);
			radioButton_SafeOpenShapeSlow.Location = new System.Drawing.Point(121, 3);
			radioButton_SafeOpenShapeSlow.Name = "radioButton_SafeOpenShapeSlow";
			radioButton_SafeOpenShapeSlow.Size = new System.Drawing.Size(90, 20);
			radioButton_SafeOpenShapeSlow.TabIndex = 0;
			radioButton_SafeOpenShapeSlow.TabStop = true;
			radioButton_SafeOpenShapeSlow.Text = "开盖降速";
			radioButton_SafeOpenShapeSlow.UseVisualStyleBackColor = true;
			radioButton_SafeOpenShapeSlow.CheckedChanged += new System.EventHandler(radioButton_SafeOpenShape_CheckedChanged);
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("黑体", 12f);
			label14.Location = new System.Drawing.Point(6, 5);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(72, 16);
			label14.TabIndex = 0;
			label14.Text = "安全设置";
			lb_language.AutoSize = true;
			lb_language.Font = new System.Drawing.Font("黑体", 12f);
			lb_language.Location = new System.Drawing.Point(23, 259);
			lb_language.Name = "lb_language";
			lb_language.Size = new System.Drawing.Size(72, 16);
			lb_language.TabIndex = 0;
			lb_language.Text = "语言选择";
			label_devicetype.AutoSize = true;
			label_devicetype.Font = new System.Drawing.Font("黑体", 12f);
			label_devicetype.Location = new System.Drawing.Point(24, 290);
			label_devicetype.Name = "label_devicetype";
			label_devicetype.Size = new System.Drawing.Size(72, 16);
			label_devicetype.TabIndex = 0;
			label_devicetype.Text = "机型选择";
			cbo_languige.Font = new System.Drawing.Font("黑体", 12f);
			cbo_languige.FormattingEnabled = true;
			cbo_languige.Items.AddRange(new object[3] { "简体中文", "繁體中文", "English" });
			cbo_languige.Location = new System.Drawing.Point(136, 257);
			cbo_languige.Name = "cbo_languige";
			cbo_languige.Size = new System.Drawing.Size(173, 24);
			cbo_languige.TabIndex = 1;
			cbo_languige.SelectedIndexChanged += new System.EventHandler(cbo_languige_SelectedIndexChanged);
			label16AC.AutoSize = true;
			label16AC.Font = new System.Drawing.Font("黑体", 12f);
			label16AC.Location = new System.Drawing.Point(23, 106);
			label16AC.Name = "label16AC";
			label16AC.Size = new System.Drawing.Size(96, 16);
			label16AC.TabIndex = 158;
			label16AC.Text = "主控板1固件";
			checkBox_BCT.AutoSize = true;
			checkBox_BCT.Font = new System.Drawing.Font("黑体", 12f);
			checkBox_BCT.Location = new System.Drawing.Point(538, 277);
			checkBox_BCT.Name = "checkBox_BCT";
			checkBox_BCT.Size = new System.Drawing.Size(171, 20);
			checkBox_BCT.TabIndex = 0;
			checkBox_BCT.Text = "是否使用后端接驳台";
			checkBox_BCT.UseVisualStyleBackColor = true;
			checkBox_BCT.CheckedChanged += new System.EventHandler(checkBox_BCT_CheckedChanged);
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("黑体", 12f);
			label11.Location = new System.Drawing.Point(23, 229);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(72, 16);
			label11.TabIndex = 158;
			label11.Text = "贴装里程";
			label_firmware_version_0.BackColor = System.Drawing.Color.AntiqueWhite;
			label_firmware_version_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_firmware_version_0.Font = new System.Drawing.Font("楷体", 11f);
			label_firmware_version_0.Location = new System.Drawing.Point(136, 102);
			label_firmware_version_0.Name = "label_firmware_version_0";
			label_firmware_version_0.Size = new System.Drawing.Size(173, 24);
			label_firmware_version_0.TabIndex = 158;
			label_firmware_version_0.Text = "--";
			label_firmware_version_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel63.Controls.Add(button_track_speedbase);
			panel63.Controls.Add(numericUpDown_track_speedbase);
			panel63.Controls.Add(label216);
			panel63.Location = new System.Drawing.Point(538, 303);
			panel63.Name = "panel63";
			panel63.Size = new System.Drawing.Size(302, 40);
			panel63.TabIndex = 174;
			numericUpDown_track_speedbase.Font = new System.Drawing.Font("黑体", 12f);
			numericUpDown_track_speedbase.Location = new System.Drawing.Point(110, 6);
			numericUpDown_track_speedbase.Maximum = new decimal(new int[4] { 600, 0, 0, 0 });
			numericUpDown_track_speedbase.Name = "numericUpDown_track_speedbase";
			numericUpDown_track_speedbase.Size = new System.Drawing.Size(79, 26);
			numericUpDown_track_speedbase.TabIndex = 10;
			numericUpDown_track_speedbase.Value = new decimal(new int[4] { 340, 0, 0, 0 });
			numericUpDown_track_speedbase.ValueChanged += new System.EventHandler(numericUpDown_track_speedbase_ValueChanged);
			label216.AutoSize = true;
			label216.Font = new System.Drawing.Font("黑体", 12f);
			label216.Location = new System.Drawing.Point(3, 9);
			label216.Name = "label216";
			label216.Size = new System.Drawing.Size(104, 16);
			label216.TabIndex = 9;
			label216.Text = "轨道转速基数";
			label_firmware_version_1.BackColor = System.Drawing.Color.AntiqueWhite;
			label_firmware_version_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_firmware_version_1.Font = new System.Drawing.Font("楷体", 11f);
			label_firmware_version_1.Location = new System.Drawing.Point(136, 132);
			label_firmware_version_1.Name = "label_firmware_version_1";
			label_firmware_version_1.Size = new System.Drawing.Size(173, 24);
			label_firmware_version_1.TabIndex = 158;
			label_firmware_version_1.Text = "--";
			label_firmware_version_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_firmware_version_2.BackColor = System.Drawing.Color.AntiqueWhite;
			label_firmware_version_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_firmware_version_2.Font = new System.Drawing.Font("楷体", 11f);
			label_firmware_version_2.Location = new System.Drawing.Point(136, 162);
			label_firmware_version_2.Name = "label_firmware_version_2";
			label_firmware_version_2.Size = new System.Drawing.Size(173, 24);
			label_firmware_version_2.TabIndex = 158;
			label_firmware_version_2.Text = "--";
			label_firmware_version_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 12f);
			label4.Location = new System.Drawing.Point(23, 136);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(96, 16);
			label4.TabIndex = 158;
			label4.Text = "主控板2固件";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 12f);
			label5.Location = new System.Drawing.Point(23, 166);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(96, 16);
			label5.TabIndex = 158;
			label5.Text = "主控板3固件";
			label61.BackColor = System.Drawing.Color.Red;
			label61.Location = new System.Drawing.Point(24, 48);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(810, 4);
			label61.TabIndex = 175;
			panel_inboard_mode.Controls.Add(radioButton2);
			panel_inboard_mode.Controls.Add(radioButton1);
			panel_inboard_mode.Font = new System.Drawing.Font("黑体", 11.5f);
			panel_inboard_mode.Location = new System.Drawing.Point(136, 314);
			panel_inboard_mode.Name = "panel_inboard_mode";
			panel_inboard_mode.Size = new System.Drawing.Size(363, 45);
			panel_inboard_mode.TabIndex = 176;
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(3, 24);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(330, 20);
			radioButton2.TabIndex = 0;
			radioButton2.Text = "分段贴板模式(必须安装分段挡板硬件装置)";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Checked = true;
			radioButton1.Location = new System.Drawing.Point(3, 3);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(122, 20);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "标准贴板模式";
			radioButton1.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 12f);
			label7.Location = new System.Drawing.Point(23, 197);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(96, 16);
			label7.TabIndex = 158;
			label7.Text = "主控板4固件";
			label_firmware_version_3.BackColor = System.Drawing.Color.AntiqueWhite;
			label_firmware_version_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_firmware_version_3.Font = new System.Drawing.Font("楷体", 11f);
			label_firmware_version_3.Location = new System.Drawing.Point(136, 193);
			label_firmware_version_3.Name = "label_firmware_version_3";
			label_firmware_version_3.Size = new System.Drawing.Size(173, 24);
			label_firmware_version_3.TabIndex = 158;
			label_firmware_version_3.Text = "--";
			label_firmware_version_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button_Library.BackColor = System.Drawing.Color.LightGray;
			button_Library.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_Library.CnPressDownColor = System.Drawing.Color.White;
			button_Library.Font = new System.Drawing.Font("黑体", 12f);
			button_Library.Location = new System.Drawing.Point(686, 152);
			button_Library.Name = "button_Library";
			button_Library.Size = new System.Drawing.Size(142, 78);
			button_Library.TabIndex = 156;
			button_Library.Text = "封装库";
			button_Library.UseVisualStyleBackColor = false;
			button_Library.Click += new System.EventHandler(button_Library_Click);
			button_lock_engineerpassword.BackColor = System.Drawing.Color.LightGray;
			button_lock_engineerpassword.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_lock_engineerpassword.CnPressDownColor = System.Drawing.Color.White;
			button_lock_engineerpassword.Font = new System.Drawing.Font("黑体", 12f);
			button_lock_engineerpassword.Location = new System.Drawing.Point(686, 110);
			button_lock_engineerpassword.Name = "button_lock_engineerpassword";
			button_lock_engineerpassword.Size = new System.Drawing.Size(142, 36);
			button_lock_engineerpassword.TabIndex = 166;
			button_lock_engineerpassword.Text = "工程师密码锁定";
			button_lock_engineerpassword.UseVisualStyleBackColor = false;
			button_lock_engineerpassword.Click += new System.EventHandler(button_lock_engineerpassword_Click);
			button_sw_register.BackColor = System.Drawing.Color.LightGray;
			button_sw_register.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_sw_register.CnPressDownColor = System.Drawing.Color.White;
			button_sw_register.Font = new System.Drawing.Font("黑体", 12f);
			button_sw_register.Location = new System.Drawing.Point(521, 3);
			button_sw_register.Name = "button_sw_register";
			button_sw_register.Size = new System.Drawing.Size(290, 36);
			button_sw_register.TabIndex = 169;
			button_sw_register.Text = "软件授权";
			button_sw_register.UseVisualStyleBackColor = false;
			button_sw_register.Click += new System.EventHandler(button_sw_register_Click);
			button_warningalarm_set.BackColor = System.Drawing.Color.LightGray;
			button_warningalarm_set.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_warningalarm_set.CnPressDownColor = System.Drawing.Color.White;
			button_warningalarm_set.Font = new System.Drawing.Font("黑体", 12f);
			button_warningalarm_set.Location = new System.Drawing.Point(538, 194);
			button_warningalarm_set.Name = "button_warningalarm_set";
			button_warningalarm_set.Size = new System.Drawing.Size(142, 36);
			button_warningalarm_set.TabIndex = 173;
			button_warningalarm_set.Text = "报警灯设置";
			button_warningalarm_set.UseVisualStyleBackColor = false;
			button_warningalarm_set.Click += new System.EventHandler(button_warningalarm_set_Click);
			button_M.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_M.CnPressDownColor = System.Drawing.Color.White;
			button_M.Font = new System.Drawing.Font("黑体", 12f);
			button_M.Location = new System.Drawing.Point(686, 194);
			button_M.Name = "button_M";
			button_M.Size = new System.Drawing.Size(142, 36);
			button_M.TabIndex = 171;
			button_M.Text = "M";
			button_M.UseVisualStyleBackColor = true;
			button_M.Visible = false;
			button_modify_engineerpassword.BackColor = System.Drawing.Color.LightGray;
			button_modify_engineerpassword.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_modify_engineerpassword.CnPressDownColor = System.Drawing.Color.White;
			button_modify_engineerpassword.Font = new System.Drawing.Font("黑体", 12f);
			button_modify_engineerpassword.Location = new System.Drawing.Point(538, 110);
			button_modify_engineerpassword.Name = "button_modify_engineerpassword";
			button_modify_engineerpassword.Size = new System.Drawing.Size(142, 36);
			button_modify_engineerpassword.TabIndex = 166;
			button_modify_engineerpassword.Text = "设置工程师密码";
			button_modify_engineerpassword.UseVisualStyleBackColor = false;
			button_modify_engineerpassword.Click += new System.EventHandler(button_modify_engineerpassword_Click);
			button_def_channel.BackColor = System.Drawing.Color.LightGray;
			button_def_channel.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_def_channel.CnPressDownColor = System.Drawing.Color.White;
			button_def_channel.Font = new System.Drawing.Font("黑体", 12f);
			button_def_channel.Location = new System.Drawing.Point(538, 152);
			button_def_channel.Name = "button_def_channel";
			button_def_channel.Size = new System.Drawing.Size(142, 36);
			button_def_channel.TabIndex = 100;
			button_def_channel.Text = "相机通道配置";
			button_def_channel.UseVisualStyleBackColor = false;
			button_def_channel.Click += new System.EventHandler(button_def_channel_Click);
			button_track_speedbase.BackColor = System.Drawing.Color.LightGray;
			button_track_speedbase.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_track_speedbase.CnPressDownColor = System.Drawing.Color.White;
			button_track_speedbase.Font = new System.Drawing.Font("黑体", 12f);
			button_track_speedbase.Location = new System.Drawing.Point(202, 6);
			button_track_speedbase.Name = "button_track_speedbase";
			button_track_speedbase.Size = new System.Drawing.Size(88, 28);
			button_track_speedbase.TabIndex = 11;
			button_track_speedbase.Text = "设置";
			button_track_speedbase.UseVisualStyleBackColor = false;
			button_track_speedbase.Click += new System.EventHandler(button_track_speedbase_Click);
			button_UsedAsTab.BackColor = System.Drawing.Color.LightGray;
			button_UsedAsTab.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_UsedAsTab.CnPressDownColor = System.Drawing.Color.White;
			button_UsedAsTab.Font = new System.Drawing.Font("黑体", 12f);
			button_UsedAsTab.Location = new System.Drawing.Point(538, 235);
			button_UsedAsTab.Name = "button_UsedAsTab";
			button_UsedAsTab.Size = new System.Drawing.Size(290, 36);
			button_UsedAsTab.TabIndex = 163;
			button_UsedAsTab.Text = "机器当接驳台使用";
			button_UsedAsTab.UseVisualStyleBackColor = false;
			button_UsedAsTab.Click += new System.EventHandler(button_UsedAsTab_Click);
			button_ParameterRestore.BackColor = System.Drawing.Color.LightGray;
			button_ParameterRestore.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_ParameterRestore.CnPressDownColor = System.Drawing.Color.White;
			button_ParameterRestore.Font = new System.Drawing.Font("黑体", 12f);
			button_ParameterRestore.Location = new System.Drawing.Point(686, 68);
			button_ParameterRestore.Name = "button_ParameterRestore";
			button_ParameterRestore.Size = new System.Drawing.Size(142, 36);
			button_ParameterRestore.TabIndex = 159;
			button_ParameterRestore.Text = "恢复参数";
			button_ParameterRestore.UseVisualStyleBackColor = false;
			button_ParameterRestore.Click += new System.EventHandler(button_ParameterRestore_Click);
			button_ParameterSaveAs.BackColor = System.Drawing.Color.LightGray;
			button_ParameterSaveAs.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_ParameterSaveAs.CnPressDownColor = System.Drawing.Color.White;
			button_ParameterSaveAs.Font = new System.Drawing.Font("黑体", 12f);
			button_ParameterSaveAs.Location = new System.Drawing.Point(538, 68);
			button_ParameterSaveAs.Name = "button_ParameterSaveAs";
			button_ParameterSaveAs.Size = new System.Drawing.Size(142, 36);
			button_ParameterSaveAs.TabIndex = 159;
			button_ParameterSaveAs.Text = "备份参数";
			button_ParameterSaveAs.UseVisualStyleBackColor = false;
			button_ParameterSaveAs.Click += new System.EventHandler(button_ParameterSaveAs_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightBlue;
			base.ClientSize = new System.Drawing.Size(861, 486);
			base.Controls.Add(button_Library);
			base.Controls.Add(panel_inboard_mode);
			base.Controls.Add(label61);
			base.Controls.Add(button_lock_engineerpassword);
			base.Controls.Add(panel112);
			base.Controls.Add(button_warningalarm_set);
			base.Controls.Add(button_M);
			base.Controls.Add(button_modify_engineerpassword);
			base.Controls.Add(button_def_channel);
			base.Controls.Add(panel63);
			base.Controls.Add(button_UsedAsTab);
			base.Controls.Add(button_ParameterRestore);
			base.Controls.Add(label1);
			base.Controls.Add(checkBox_BCT);
			base.Controls.Add(panel_openshape);
			base.Controls.Add(button_ParameterSaveAs);
			base.Controls.Add(label_revision);
			base.Controls.Add(label_sw_version);
			base.Controls.Add(label_firmware_version_3);
			base.Controls.Add(label_firmware_version_2);
			base.Controls.Add(label_firmware_version_1);
			base.Controls.Add(label_firmware_version_0);
			base.Controls.Add(label11);
			base.Controls.Add(label7);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label16AC);
			base.Controls.Add(label_smtmiles);
			base.Controls.Add(cbo_languige);
			base.Controls.Add(cbo_SmtDevice);
			base.Controls.Add(label_devicetype);
			base.Controls.Add(comboBox_SmtSubDevice);
			base.Controls.Add(lb_language);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_System";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_System_Load);
			panel112.ResumeLayout(false);
			panel112.PerformLayout();
			panel_openshape.ResumeLayout(false);
			panel_openshape.PerformLayout();
			panel63.ResumeLayout(false);
			panel63.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_track_speedbase).EndInit();
			panel_inboard_mode.ResumeLayout(false);
			panel_inboard_mode.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_System(USR_INIT_DATA usr_init, USR_DATA usr)
		{
			InitializeComponent();
			USR_INIT = usr_init;
			USR = usr;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "系统参数", "系統參數", "System Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_revision,
				str = new string[3] { "软件版本", "軟件版本", "Software Version" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label16AC,
				str = new string[3] { "主控板1固件", "主控板1固件", "Board-1 Firmware" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "主控板2固件", "主控板2固件", "Board-2 Firmware" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "主控板3固件", "主控板3固件", "Board-3 Firmware" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "主控板4固件", "主控板4固件", "Board-4 Firmware" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "贴装里程", "貼裝裏程", "SMT Miles" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_language,
				str = new string[3] { "语言选择", "語言選擇", "Language" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_devicetype,
				str = new string[3] { "机型选择", "機型選擇", "Device Select" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton1,
				str = new string[3] { "标准贴板模式（三段式进板）", "標準貼板模式（三段式進板）", "Standard SMT Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton2,
				str = new string[3] { "两段贴板模式(必须安装两个挡板装置)", "兩段貼板模式(必須安裝兩個擋板裝置)", "Two Section PCB SMT Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label14,
				str = new string[3] { "安全设置", "安全設置", "Open Shape Safety" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_SafeOpenShapeSlow,
				str = new string[3] { "开盖降速", "開蓋降速", "Low Speed Running" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_SafeOpenShapeStop,
				str = new string[3] { "开盖停机", "開蓋停機", "Stop Running" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_FeederGoodbye,
				str = new string[3] { "飞达防撞 （需要安装安全传感器）", "飛達防撞 （需要安裝安全傳感器）", "Feeder Collision Avoidance (related sensors requirement)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_sw_state,
				str = new string[3] { "试用版本 功能受限", "試用版本 功能受限", "Trial Version" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ParameterSaveAs,
				str = new string[3] { "备份参数", "備份參數", "Export Parameter" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ParameterRestore,
				str = new string[3] { "恢复参数", "恢復參數", "Import Parameter" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_modify_engineerpassword,
				str = new string[3] { "设置工程师密码", "設置工程師密碼", "Engineer Password" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_lock_engineerpassword,
				str = new string[3] { "工程师密码锁定", "工程師密碼鎖定", "Engineer Pwd Lock" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_def_channel,
				str = new string[3] { "相机通道配置", "相機通道配置", "Camera Channel Set" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_warningalarm_set,
				str = new string[3] { "报警灯设置", "報警燈設置", "Warning Lamp Config" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Library,
				str = new string[3] { "封装库", "封裝庫", "Footprint Lab" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_UsedAsTab,
				str = new string[3] { "机器当接驳台使用", "機器當接駁臺使用", "Collect Table Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_BCT,
				str = new string[3] { "是否使用后端接驳台", "是否使用後端接駁臺", "Is using back collect table" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label216,
				str = new string[3] { "传板轨道基数", "傳板軌道基數", "Track Base Data" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_track_speedbase,
				str = new string[3] { "设置", "設置", "Set" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_sw_register,
				str = new string[3] { "软件授权", "軟件授權", "Software Resgister" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "软件授权", "軟件授權", "Software Resgister" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_sw_version,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_firmware_version_0,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_firmware_version_1,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_firmware_version_2,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_firmware_version_3,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_smtmiles,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cbo_languige,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cbo_SmtDevice,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_SmtSubDevice,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_keytime,
				str = new string[3] { "", "", "" }
			});
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_track_speedbase
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			return list;
		}

		private void Form_System_Load(object sender, EventArgs e)
		{
			init_system();
			for (int i = 0; i < 2; i++)
			{
				radioButton_inboard_mode[i].Tag = i;
				radioButton_inboard_mode[i].Click += radioButton_inboard_mode_CheckedChanged;
			}
			MainForm0.__wind_checkget_software_state(0);
			label_sw_state.Text = MainForm0.str_wind_sw_state;
			label_keytime.Text = MainForm0.str_wind_keytime;
		}

		private void init_system()
		{
			label_sw_version.Text = "20210712_8.8.0_T46_R";
			label_firmware_version_0.Text = MainForm0.static_firmware_version[0];
			label_firmware_version_1.Text = MainForm0.static_firmware_version[1];
			label_firmware_version_2.Text = MainForm0.static_firmware_version[2];
			label_firmware_version_3.Text = MainForm0.static_firmware_version[3];
			label_smtmiles.Text = MainForm0.mSmtMiles + "  Chips";
			cbo_languige.SelectedIndex = USR_INIT.mLanguage;
			checkBox_BCT.Checked = USR_INIT.mIsBCTEnabled;
			cbo_languige.Font = new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], cbo_languige.Font.Size, cbo_languige.Font.Style);
			USR_INIT.mLanguage = 2;
			cbo_languige.SelectedIndex = 2;
			cbo_languige.Enabled = false;
			lb_language.Text = "                Language";
			panel_openshape.Enabled = MainForm0.mIsOpenShape_Enabled;
			if (USR_INIT.mTrackSpeedBase == 0)
			{
				USR_INIT.mTrackSpeedBase = 340;
			}
			else if (USR_INIT.mTrackSpeedBase < 200)
			{
				USR_INIT.mTrackSpeedBase = 200;
			}
			else if (USR_INIT.mTrackSpeedBase > 600)
			{
				USR_INIT.mTrackSpeedBase = 600;
			}
			numericUpDown_track_speedbase.Value = USR_INIT.mTrackSpeedBase;
			checkBox_FeederGoodbye.Checked = !USR_INIT.mIsNotFeederGoodbye;
			radioButton_inboard_mode = new RadioButton[3]
			{
				radioButton1,
				radioButton2,
				new RadioButton()
			};
			radioButton_inboard_mode[2].Visible = false;
			if (USR_INIT.mDeviceType == DeviceType.HW_4_42 || USR_INIT.mDeviceType == DeviceType.HW_4_44 || USR_INIT.mDeviceType == DeviceType.HW_4_50 || USR_INIT.mDeviceType == DeviceType.HW_6 || USR_INIT.mDeviceType == DeviceType.HW_6_FLK || USR_INIT.mDeviceType == DeviceType.HW_4SG_44 || USR_INIT.mDeviceType == DeviceType.HW_4SG_50 || USR_INIT.mDeviceType == DeviceType.HW_6_TRAN2 || USR_INIT.mDeviceType == DeviceType.HW_6_TRANSFER || USR_INIT.mDeviceType == DeviceType.HW_6S_TRAN3 || USR_INIT.mDeviceType == DeviceType.HW_6S_TRAN4 || USR_INIT.mDeviceType == DeviceType.HW_8S_TRAN4 || USR_INIT.mDeviceType == DeviceType.HW_8SX_1200 || USR_INIT.mDeviceType == DeviceType.HW_DT408H || USR_INIT.mDeviceType == DeviceType.DSQ800_120F)
			{
				panel_inboard_mode.Visible = false;
			}
			else
			{
				radioButton_inboard_mode[USR_INIT.mInBoard_Mode].Checked = true;
			}
			if (USR_INIT.mDeviceType == DeviceType.HW_8SX_1200 || USR_INIT.mDeviceType == DeviceType.HW_8SP_1200)
			{
				panel_inboard_mode.Enabled = false;
				radioButton_inboard_mode[1].Text = ((USR_INIT.mLanguage == 2) ? "PCB 3 Sectio Mode" : "分段贴板模式(必须安装三个挡板装置)");
			}
			if (USR_INIT.mDeviceType == DeviceType.DSQ800_120F)
			{
				comboBox_SmtSubDevice.Visible = true;
				comboBox_SmtSubDevice.SelectedIndex = USR_INIT.mSmtSubDevice;
			}
			DeviceType[] array = OEM.DevList[1];
			BindingList<string> bindingList = new BindingList<string>();
			cbo_SmtDevice.Items.Clear();
			cbo_SmtDevice.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], cbo_SmtDevice.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], cbo_SmtDevice.Font.Style);
			int num = array.Count();
			for (int i = 0; i < num; i++)
			{
				DeviceType deviceType = array[i];
				string text = "";
				text = STR.DEVICE_YX[(int)deviceType];
				cbo_SmtDevice.Items.Add(text);
				bindingList.Add(text);
			}
			cbo_SmtDevice.MaxLength = num;
			cbo_SmtDevice.SelectedIndex = getIndexFrom_cbo_SmtDevice(USR_INIT.mDeviceType);
			USR.mDeviceType = USR_INIT.mDeviceType;
			USR.mSmtDevice = bindingList[getIndexFrom_cbo_SmtDevice(USR.mDeviceType)];
			cbo_SmtDevice.Text = USR.mSmtDevice;
			if (!USR_INIT.mIsOpenShapeStopRun)
			{
				radioButton_SafeOpenShapeSlow.Checked = true;
			}
			else
			{
				radioButton_SafeOpenShapeStop.Checked = true;
			}
			checkBox_FeederGoodbye.Checked = !USR_INIT.mIsNotFeederGoodbye;
		}

		public int getIndexFrom_cbo_SmtDevice(DeviceType devtype)
		{
			DeviceType[] array = OEM.DevList[1];
			int result = 0;
			int num = array.Count();
			for (int i = 0; i < num; i++)
			{
				if (array[i] == devtype)
				{
					result = i;
				}
			}
			return result;
		}

		private void cbo_languige_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (USR_INIT.mLanguage != cbo_languige.SelectedIndex)
			{
				string[] array = new string[3] { "该操作需要重启软件才能生效，是否继续！", "該操作需要重啟軟件才能生效，是否繼續！", "The operation need software retart, are you continue?" };
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					USR_INIT.mLanguage = cbo_languige.SelectedIndex;
					MainForm0.save_FixedData();
					MainForm0.save_usrProjectData();
					string[] array2 = new string[3] { "软件将自动关闭，请重新启动！", "軟件將自動關閉，請重新啟動！", "Software will close, please restart it!" };
					MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
					Environment.Exit(0);
				}
				else
				{
					cbo_languige.SelectedIndex = USR_INIT.mLanguage;
				}
			}
		}

		private void cbo_SmtDevice_SelectedIndexChanged(object sender, EventArgs e)
		{
			DeviceType[] array = OEM.DevList[1];
			if (array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_6 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_8S || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_8SX || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_8SX_72F || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_8S_PLUS || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_6S || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_6SX || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_4_50 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_4_42 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_8SP_1200 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_6_FLK || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_6_TRANSFER || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_DT408H || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_6_TRAN2 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_8S_TRAN4 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_6S_TRAN4 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_4SG_50 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.HW_4SG_44 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.DUDU_400 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.DUDU_400_64FX || array[cbo_SmtDevice.SelectedIndex] == DeviceType.DUDU_400_50K || array[cbo_SmtDevice.SelectedIndex] == DeviceType.DUDU_800 || array[cbo_SmtDevice.SelectedIndex] == DeviceType.DUDU_800_E || array[cbo_SmtDevice.SelectedIndex] == DeviceType.DSQ800_120F)
			{
				if (USR_INIT.mDeviceType != array[cbo_SmtDevice.SelectedIndex])
				{
					string[] array2 = new string[3] { "该操作需要重启软件才能生效，是否继续！", "該操作需要重啟軟件才能生效，是否繼續！", "The operation need software retart, are you continue?" };
					if (MainForm0.CmMessageBox(array2[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						USR.mSmtDevice = cbo_SmtDevice.Text;
						USR_INIT.mDeviceType = array[cbo_SmtDevice.SelectedIndex];
						MainForm0.save_FixedData_ConfigInit();
						string[] array3 = new string[3] { "软件将自动关闭，请重新启动！", "軟件將自動關閉，請重新啟動！", "Software will close, please restart it!" };
						MainForm0.CmMessageBoxTop_Ok(array3[USR_INIT.mLanguage]);
						Environment.Exit(0);
					}
					else
					{
						cbo_SmtDevice.SelectedIndex = getIndexFrom_cbo_SmtDevice(USR_INIT.mDeviceType);
					}
				}
				else
				{
					USR_INIT.mDeviceStr = cbo_SmtDevice.Text;
					USR_INIT.mDeviceType = array[cbo_SmtDevice.SelectedIndex];
					MainForm0.save_FixedData_ConfigInit();
				}
			}
			else
			{
				string[] array4 = new string[3] { "该机型暂未支持，敬请关注！", "該機型暫未支持，敬請關註！", "This machine type has not supported yet!" };
				MainForm0.CmMessageBoxTop_Ok(array4[USR_INIT.mLanguage]);
				cbo_SmtDevice.SelectedIndex = getIndexFrom_cbo_SmtDevice(USR_INIT.mDeviceType);
			}
		}

		private void radioButton_inboard_mode_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			int num = (int)((RadioButton)sender).Tag;
			if (radioButton.Checked && USR_INIT.mInBoard_Mode != num)
			{
				string[] array = new string[3] { "切换进板贴装模式，需要重启软件，确定切换吗？", "切換進板貼裝模式，需要重啟軟件，確定切換嗎？", "Switch SMT inboard mode need restarting software, are you going？" };
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					USR_INIT.mInBoard_Mode = num;
					MainForm0.save_FixedData();
					Environment.Exit(0);
				}
				else
				{
					radioButton_inboard_mode[USR_INIT.mInBoard_Mode].Checked = true;
				}
			}
		}

		private void radioButton_SafeOpenShape_CheckedChanged(object sender, EventArgs e)
		{
			if (USR_INIT != null)
			{
				USR_INIT.mIsOpenShapeStopRun = !radioButton_SafeOpenShapeSlow.Checked;
				if (MainForm0.mConDev != null && MainForm0.mConDev[0] != null)
				{
					MainForm0.mConDev[0].readOpenShapeStatus();
				}
			}
		}

		private void checkBox_FeederGoodbye_CheckedChanged(object sender, EventArgs e)
		{
			USR_INIT.mIsNotFeederGoodbye = !checkBox_FeederGoodbye.Checked;
			if (!USR_INIT.mIsNotFeederGoodbye && MainForm0.mConDev != null && MainForm0.mConDev[0] != null)
			{
				MainForm0.mConDev[0].readFeederGoodbyeStatus();
			}
		}

		private void button_ParameterSaveAs_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string selectedPath = folderBrowserDialog.SelectedPath;
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "You Select this folder to Backup:" : ("您选择了此文件夹进行备份：" + selectedPath), MessageBoxButtons.OKCancel) != DialogResult.OK)
			{
				return;
			}
			try
			{
				if (Directory.GetFileSystemEntries(selectedPath).Count() > 0)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Please select an empty folder to Backup!" : "您选择的备份文件夹里存在其他文件，请选择一个空的文件夹备份!");
					return;
				}
				File.Copy("..\\configdata\\CONFIG_INIT.bin", selectedPath + "\\CONFIG_INIT.bin", overwrite: true);
				File.Copy("..\\configdata\\" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_FIXED.bin", selectedPath + "\\CONFIG_FIXED.bin", overwrite: true);
				File.Copy("..\\configdata\\" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin", selectedPath + "\\CONFIG_USR2_DEFAULT.bin", overwrite: true);
				File.Copy("..\\configdata\\" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_FACTORY.bin", selectedPath + "\\CONFIG_USR2_FACTORY.bin", overwrite: true);
				File.Copy("..\\configdata\\CONPONENTS_LIB.bin", selectedPath + "\\CONPONENTS_LIB.bin", overwrite: true);
			}
			catch (Exception ex)
			{
				MainForm0.write_to_logFile("类型X: " + ex.Message + Environment.NewLine);
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Backup Fail!" : "备份失败");
			}
			MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Backup Successful!" : "备份成功！");
		}

		private void button_ParameterRestore_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Software needs to restart after loading configuration files!" : "恢复参数之后软件将自动关闭，然后请重新开启！", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string selectedPath = folderBrowserDialog.SelectedPath;
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Configuration data is loaded from this folder:" : ("您正在从此文件夹恢复参数" + selectedPath), MessageBoxButtons.OKCancel) != DialogResult.OK)
			{
				return;
			}
			try
			{
				DeviceType deviceType;
				if (File.Exists(selectedPath + "\\CONFIG_INIT.bin"))
				{
					IFormatter formatter = new BinaryFormatter();
					Stream stream = new FileStream(selectedPath + "\\CONFIG_INIT.bin", FileMode.Open, FileAccess.Read, FileShare.None);
					USR_INIT_DATA uSR_INIT_DATA = (USR_INIT_DATA)formatter.Deserialize(stream);
					stream.Close();
					deviceType = uSR_INIT_DATA.mDeviceType;
				}
				else
				{
					if (!File.Exists(selectedPath + "\\CONFIG_FIXED.bin"))
					{
						MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "The folder losts some important files, loading fail!" : "您选择的文件夹内缺少参数备份文件，恢复操作无法进行！");
						return;
					}
					IFormatter formatter2 = new BinaryFormatter();
					Stream stream2 = new FileStream(selectedPath + "\\CONFIG_FIXED.bin", FileMode.Open, FileAccess.Read, FileShare.None);
					USR_DATA uSR_DATA = (USR_DATA)formatter2.Deserialize(stream2);
					stream2.Close();
					deviceType = MainForm0.GetDeviceType(uSR_DATA.mSmtDevice);
				}
				if (!File.Exists(selectedPath + "\\CONFIG_FIXED.bin") || !File.Exists(selectedPath + "\\CONFIG_USR2_DEFAULT.bin") || !File.Exists(selectedPath + "\\CONFIG_USR2_FACTORY.bin") || !File.Exists(selectedPath + "\\CONPONENTS_LIB.bin"))
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "The folder losts some important files, loading fail!" : "您选择的文件夹内缺少参数备份文件，恢复操作无法进行！");
					return;
				}
				if (File.Exists(selectedPath + "\\CONFIG_INIT.bin"))
				{
					File.Copy(selectedPath + "\\CONFIG_INIT.bin", "..\\configdata\\CONFIG_INIT.bin", overwrite: true);
				}
				else
				{
					USR_INIT_DATA uSR_INIT_DATA2 = new USR_INIT_DATA();
					uSR_INIT_DATA2.mDeviceType = deviceType;
					IFormatter formatter3 = new BinaryFormatter();
					Stream stream3 = new FileStream("..\\configdata\\CONFIG_INIT.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
					formatter3.Serialize(stream3, uSR_INIT_DATA2);
					stream3.Close();
				}
				File.Copy(selectedPath + "\\CONFIG_FIXED.bin", "..\\configdata\\" + STR.DEV_[(int)deviceType] + "_CONFIG_FIXED.bin", overwrite: true);
				File.Copy(selectedPath + "\\CONFIG_USR2_DEFAULT.bin", "..\\configdata\\" + STR.DEV_[(int)deviceType] + "_CONFIG_USR2_DEFAULT.bin", overwrite: true);
				File.Copy(selectedPath + "\\CONFIG_USR2_FACTORY.bin", "..\\configdata\\" + STR.DEV_[(int)deviceType] + "_CONFIG_USR2_FACTORY.bin", overwrite: true);
				File.Copy(selectedPath + "\\CONPONENTS_LIB.bin", "..\\configdata\\CONPONENTS_LIB.bin", overwrite: true);
			}
			catch (Exception ex)
			{
				MainForm0.write_to_logFile("类型X: " + ex.Message + Environment.NewLine);
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Loading Fail!" : "恢复失败");
			}
			MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Loading Successful! Software will close, please re-open it!" : "恢复成功，系统将关闭，请重新开启软件！");
			Environment.Exit(0);
		}

		private void button_modify_engineerpassword_Click(object sender, EventArgs e)
		{
			MainForm0.modify_engineer_password();
		}

		private void button_lock_engineerpassword_Click(object sender, EventArgs e)
		{
			MainForm0.lock_engineer_password();
		}

		private void button_def_channel_Click(object sender, EventArgs e)
		{
			string[] array = new string[3] { "警告：配置相机自定义通道需要配合相机采集卡硬件连线改动，请谨慎操作！", "警告：配置相機自定義通道需要配合相機采集卡硬件連線改動，請謹慎操作！", "Warning: This configuration requires related hardware connection change!" };
			if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				Form_CameraChannelMapping form_CameraChannelMapping = new Form_CameraChannelMapping(USR);
				if (form_CameraChannelMapping.ShowDialog() == DialogResult.OK)
				{
					string[] array2 = new string[3] { "温馨提示：您已经开启了自定义相机通道映射，请确保通道硬件连接的正确！", "溫馨提示：您已經開啟了自定義相機通道映射，請確保通道硬件連接的正確！", "Notice: Customization camera channel mapping is enabled, please make sure the camera cable hardware is correct!" };
					MainForm0.CmMessageBox(array2[USR_INIT.mLanguage], MessageBoxButtons.OK);
				}
			}
		}

		private void button_Library_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Retry;
		}

		private void button_warningalarm_set_Click(object sender, EventArgs e)
		{
			Form_WarningAlarmSetting form_WarningAlarmSetting = new Form_WarningAlarmSetting();
			form_WarningAlarmSetting.ShowDialog();
		}

		private void button_UsedAsTab_Click(object sender, EventArgs e)
		{
			if (MainForm0.mConDevExt == null || MainForm0.mConDevExt[0] == null)
			{
				string[] array = new string[3] { "请先连接设备！", "請先連接設備！", "Please connect device!" };
				MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
			}
			else
			{
				MainForm0.mConDevExt[0].sendTabOnly(1, USR_INIT.mIsBCTEnabled ? 1 : 0, (int)(USR.mTrackDelay * 10f), USR.mTrackSpeed);
				Form_UsedAsTab form_UsedAsTab = new Form_UsedAsTab(USR_INIT.mLanguage);
				form_UsedAsTab.ShowDialog();
				MainForm0.mConDevExt[0].sendTabOnly(0, USR_INIT.mIsBCTEnabled ? 1 : 0, (int)(USR.mTrackDelay * 10f), USR.mTrackSpeed);
			}
		}

		private void checkBox_BCT_CheckedChanged(object sender, EventArgs e)
		{
			USR_INIT.mIsBCTEnabled = checkBox_BCT.Checked;
		}

		private void numericUpDown_track_speedbase_ValueChanged(object sender, EventArgs e)
		{
			USR_INIT.mTrackSpeedBase = (int)numericUpDown_track_speedbase.Value;
			if (USR_INIT.mTrackSpeedBase == 0)
			{
				USR_INIT.mTrackSpeedBase = 340;
			}
			else if (USR_INIT.mTrackSpeedBase < 200)
			{
				USR_INIT.mTrackSpeedBase = 200;
			}
			else if (USR_INIT.mTrackSpeedBase > 600)
			{
				USR_INIT.mTrackSpeedBase = 600;
			}
			numericUpDown_track_speedbase.Value = USR_INIT.mTrackSpeedBase;
			MainForm0.save_FixedData_ConfigInit();
		}

		private void button_track_speedbase_Click(object sender, EventArgs e)
		{
			USR_INIT.mTrackSpeedBase = (int)numericUpDown_track_speedbase.Value;
			if (!MainForm0.mIsSimulation)
			{
				MainForm0.mConDevExt[0].send_trackspeedbase(USR_INIT.mTrackSpeedBase);
			}
		}

		private void button_sw_register_Click(object sender, EventArgs e)
		{
			MainForm0.__wind_button_sw_register_Click();
			label_sw_state.Text = MainForm0.str_wind_sw_state;
			label_keytime.Text = MainForm0.str_wind_keytime;
		}

		private void comboBox_SmtSubDevice_SelectedIndexChanged(object sender, EventArgs e)
		{
			USR_INIT.mSmtSubDevice = comboBox_SmtSubDevice.SelectedIndex;
		}
	}
}
