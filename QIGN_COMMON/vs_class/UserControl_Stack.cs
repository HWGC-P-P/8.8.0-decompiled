using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.Properties;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_Stack : UserControl
	{
		private IContainer components;

		private CnButton button_reback;

		private Panel panel_stacknew_visual;

		private Panel panel_isScanR;

		private Label label_scanR;

		private Label label_stacknew_chipHmm;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private Panel panel1;

		private Label label5;

		private Panel panel_feeder;

		private Label label4;

		private Label label3;

		private Panel panel_vibra;

		private Panel panel_plate;

		private TabPage tabPage2;

		private Label label_stacknew_chipWmm;

		private Label label_stacknew_chipLmm;

		private Label label26;

		private CnButton button_visualrunning;

		private CnButton button_collect;

		private CheckBox checkBox_stackCollect;

		private Label label15;

		private Label label23;

		private CheckBox checkBox_isScanR;

		private Panel panel_stacknew_pik;

		private Panel panel_stacknew_mnt;

		private Panel panel_nozzleenable;

		private CnButton button_pikBaseH;

		private Panel panel_context2;

		private CnButton button_PikToHighCam;

		private NumericUpDown numericUpDown_stackCollect;

		private Label label14;

		private CnButton button_campara;

		private CnButton button_visualtest2;

		private CnButton button_PikToFastCam;

		private Label label_stack_visual;

		private Label label17;

		private Label label8;

		private ListBox listBox_StackVibraAll;

		private Label label_stacksel_title;

		private Label label_Vibra;

		private CnButton button_close;

		private CnButton button_stacksel_feeder;

		private Label label1;

		private CnButton button_from_footprintlab_view;

		private Label label30;

		private CnButton button_stacksel_vibra;

		private CnButton button_providerSetting;

		private CnButton button2;

		private CnButton button_stacksel_plate;

		private Panel panel_context3;

		private CnButton button_platexy;

		private Label label10;

		private ListBox listBox_StackPlateAll;

		private Panel panel3;

		private Label label_feederstate;

		private CnButton button_openfeeder;

		private CnButton button_closefeeder;

		private Label label6;

		private Label label_Stack;

		private Label label_StackPlate;

		private Label label_stacknew_chipinfo;

		private CnButton button_stackMoveToXY;

		private CnButton button_stackSaveXY;

		private CnButton button_gotoPrevStack;

		private Label label_stackXY;

		private CnButton button_gotoNextStack;

		private CnButton button_mntBaseH;

		private Panel panel_context4;

		private NumericUpDown numericUpDown_AutoEntTimeDelay;

		private Panel panel_stackplate_autoprovider;

		private CheckBox checkBox_stackplate_AutoEntComponent;

		private Label label13;

		private CnButton button_goto_pikxy_byNozzle;

		private Panel panel_stackselNew_Page;

		private Panel panel_stacktool0;

		private Panel panel_feederdelay;

		private NumericUpDown numericUpDown_feederdelay;

		private Label label28;

		private Label label16;

		private CnButton button_stackCopy;

		private CnButton button_autoPixXY;

		private CheckBox checkBox_is_hcam_special;

		private CnButton button_hcam_specialpara;

		private Label label20;

		private Panel panel2;

		private CnButton button_pikH_Offset_Sync;

		private CnButton button_pikH_Goto;

		private CnButton button_pikH_View;

		private CnButton button_pikH_Save;

		private CnButton button_mntH_Offset_Sync;

		private CnButton button_mntH_View;

		private CnButton button_mntH_Save;

		private CnButton button_mntH_Goto;

		private Panel panel_head;

		private Panel panel_context1;

		private Panel panel_context2_2;

		private TrackBar trackBar_scanR;

		private Panel panel_iscolloect;

		private Panel panel_plateXYlist;

		private Panel panel48;

		private CnButton button_stackplateGenXYlist;

		private Label label_row;

		private CnButton button_stackplateSaveXYS;

		private Label label11;

		private NumericUpDown nud_stackplate_rows;

		private Label label_column;

		private NumericUpDown nud_stackplate_columns;

		private CnButton button_stackplateMoveToXYS;

		private Label label22;

		private Panel panel5;

		private Panel panel_componentarray;

		private ListBox listBox_subPlate;

		private Panel panel45;

		private CheckBox checkBox_addSubPlate;

		private Panel panel_addSubPlate;

		private CnButton button_delSubPlate;

		private CnButton button_addSubPlate;

		private CnButton button_stackplateXY_moveto;

		private CnButton button_stackplateXY_update;

		private CnButton button_platexy_close;

		private Label label21;

		private Label label27;

		private Label label25;

		private Label label24;

		private CnButton button_from_footprintlab;

		private CnButton button_footprint;

		private Label label29;

		private Label label_angle;

		private CnButton button_ledcam_para;

		private CnButton button_curdefault;

		private CnButton button_EnableNozzle;

		private Panel panel4;

		private Label label7;

		private Panel panel6;

		private CnButton button_stackplateXY_moveto_byZn;

		private Label label9;

		private DataGridView dataGridView_stackplateXY;

		private Label label12;

		private Panel panel_enable_Zn;

		private CnButton button_close_enableZn;

		private Label label18;

		private Label label31;

		private Panel panel_chip_hmm;

		private Label label32;

		private Panel panel7;

		private Label label_hcam_special_level;

		private TrackBar trackBar_hcam_special_level;

		private Panel panel_hcam_special;

		private CnButton cnButton_from_other_prj;

		private Panel panel_autopikxy;

		private Panel panel9;

		private Label label_state;

		private CnButton button_savepikxy;

		private CheckBox checkBox_autosave;

		private Panel panel10;

		private NumericUpDown numericUpDown_first_feederin;

		private NumericUpDown numericUpDown_scanr;

		private Label label2;

		private Label label33;

		private Label label34;

		private CnButton button_stop;

		private Label label35;

		private CnButton button_autopik_close;

		private Panel panel11;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private Label label36;

		private CnButton button_autorun_cur;

		private CnButton button_prev;

		private CnButton button_next;

		private CnButton button_all;

		private Label label37;

		private Label label38;

		private CnButton cnButton_saveasdefault;

		private Label label39;

		private CnButton cnButton_stackplate_startIndex;

		private Panel panel8;

		private RadioButton[] radioButton_beltcolor;

		public volatile bool mIs_vsplus_autopikxy_finished;

		private Label[] lb_stackplate_XY;

		public CnButton[] bt_stackplate_XY;

		private USR_INIT_DATA USR_INIT;

		private int mFn;

		private USR_DATA USR;

		private USR2_DATA USR2;

		private USR3_BASE USR3B;

		public BindingList<USR3_DATA> U3;

		public int U3Idx;

		public USR_STACKLIB mStackLib;

		private Label[] label_stack_pikZnName;

		private Label[] label_stack_pikH;

		public CheckBox[] checkBox_stack_nozzleEn;

		private NumericUpDown[][] numericUpDown_stack_pikConfig;

		private NumericUpDown[] numericUpDown_pikoffset;

		private Label label_pikH_head;

		private Label label_mntH_head;

		private TableLayoutPanel tp_mnt;

		public Label[] label_stack_mntZnName;

		public Label[] label_stack_mntH;

		public NumericUpDown[][] numericUpDown_stack_mntConfig;

		private NumericUpDown[] numericUpDown_mntoffset;

		public Label[] label_threshold;

		public Label[] label_stack_nozzleEnName;

		private CnButton[] button_stacksel;

		public static string[][] STACK_SEL_STR = new string[3][]
		{
			new string[3] { "普通飞达", "普通飞达", "Feeder" },
			new string[3] { "托盘料盘", "托盘料盘", "Plate" },
			new string[3] { "振动飞达", "振动飞达", "Vibra Feeder" }
		};

		private float lv_size = 9.5f;

		private TrackBar tbar_threshold;

		public int mCurStackPlateCornerNo;

		public Form_ProviderHeight_Feeder mFormProviderHeight_Feeder;

		public Form_ProviderHeight mFormProviderHeight;

		private Form_provider_from_footprintlab fm_provider_from_footprintlab;

		private Form_provider_from_footprintlab fm_provider_from_footprintlab_mode1;

		private UserControl_CheckH uc_pikCheckH;

		private UserControl_CheckH uc_mntCheckH;

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
			panel_stacknew_visual = new System.Windows.Forms.Panel();
			panel_isScanR = new System.Windows.Forms.Panel();
			label_scanR = new System.Windows.Forms.Label();
			trackBar_scanR = new System.Windows.Forms.TrackBar();
			label_stacknew_chipHmm = new System.Windows.Forms.Label();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			panel1 = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			panel_feeder = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			panel_vibra = new System.Windows.Forms.Panel();
			panel_plate = new System.Windows.Forms.Panel();
			tabPage2 = new System.Windows.Forms.TabPage();
			label_stacknew_chipWmm = new System.Windows.Forms.Label();
			label_stacknew_chipLmm = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			checkBox_stackCollect = new System.Windows.Forms.CheckBox();
			label15 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			checkBox_isScanR = new System.Windows.Forms.CheckBox();
			panel_stacknew_pik = new System.Windows.Forms.Panel();
			panel_stacknew_mnt = new System.Windows.Forms.Panel();
			panel_nozzleenable = new System.Windows.Forms.Panel();
			panel_context2 = new System.Windows.Forms.Panel();
			panel_context2_2 = new System.Windows.Forms.Panel();
			panel_hcam_special = new System.Windows.Forms.Panel();
			label_hcam_special_level = new System.Windows.Forms.Label();
			trackBar_hcam_special_level = new System.Windows.Forms.TrackBar();
			checkBox_is_hcam_special = new System.Windows.Forms.CheckBox();
			label_stack_visual = new System.Windows.Forms.Label();
			panel_iscolloect = new System.Windows.Forms.Panel();
			numericUpDown_stackCollect = new System.Windows.Forms.NumericUpDown();
			label14 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			listBox_StackVibraAll = new System.Windows.Forms.ListBox();
			label_stacksel_title = new System.Windows.Forms.Label();
			label_Vibra = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			panel_context3 = new System.Windows.Forms.Panel();
			label10 = new System.Windows.Forms.Label();
			listBox_StackPlateAll = new System.Windows.Forms.ListBox();
			label_Stack = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			panel6 = new System.Windows.Forms.Panel();
			label_stackXY = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			label_feederstate = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label_StackPlate = new System.Windows.Forms.Label();
			label_stacknew_chipinfo = new System.Windows.Forms.Label();
			panel_context4 = new System.Windows.Forms.Panel();
			panel_chip_hmm = new System.Windows.Forms.Panel();
			numericUpDown_AutoEntTimeDelay = new System.Windows.Forms.NumericUpDown();
			panel_stackplate_autoprovider = new System.Windows.Forms.Panel();
			label13 = new System.Windows.Forms.Label();
			checkBox_stackplate_AutoEntComponent = new System.Windows.Forms.CheckBox();
			panel_stackselNew_Page = new System.Windows.Forms.Panel();
			label12 = new System.Windows.Forms.Label();
			panel_context1 = new System.Windows.Forms.Panel();
			panel_stacktool0 = new System.Windows.Forms.Panel();
			panel_enable_Zn = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			label_angle = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			panel_head = new System.Windows.Forms.Panel();
			label20 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label32 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			panel_feederdelay = new System.Windows.Forms.Panel();
			numericUpDown_feederdelay = new System.Windows.Forms.NumericUpDown();
			label28 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			panel_plateXYlist = new System.Windows.Forms.Panel();
			panel7 = new System.Windows.Forms.Panel();
			listBox_subPlate = new System.Windows.Forms.ListBox();
			label18 = new System.Windows.Forms.Label();
			dataGridView_stackplateXY = new System.Windows.Forms.DataGridView();
			panel45 = new System.Windows.Forms.Panel();
			checkBox_addSubPlate = new System.Windows.Forms.CheckBox();
			panel_addSubPlate = new System.Windows.Forms.Panel();
			label9 = new System.Windows.Forms.Label();
			panel48 = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			panel_componentarray = new System.Windows.Forms.Panel();
			label27 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label_row = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			nud_stackplate_rows = new System.Windows.Forms.NumericUpDown();
			label_column = new System.Windows.Forms.Label();
			nud_stackplate_columns = new System.Windows.Forms.NumericUpDown();
			label22 = new System.Windows.Forms.Label();
			panel_autopikxy = new System.Windows.Forms.Panel();
			panel9 = new System.Windows.Forms.Panel();
			label_state = new System.Windows.Forms.Label();
			checkBox_autosave = new System.Windows.Forms.CheckBox();
			panel10 = new System.Windows.Forms.Panel();
			numericUpDown_first_feederin = new System.Windows.Forms.NumericUpDown();
			numericUpDown_scanr = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			panel11 = new System.Windows.Forms.Panel();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			label36 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			panel8 = new System.Windows.Forms.Panel();
			button_close = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_saveasdefault = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_from_other_prj = new QIGN_COMMON.vs_acontrol.CnButton();
			button_from_footprintlab = new QIGN_COMMON.vs_acontrol.CnButton();
			button_ledcam_para = new QIGN_COMMON.vs_acontrol.CnButton();
			button_from_footprintlab_view = new QIGN_COMMON.vs_acontrol.CnButton();
			button_providerSetting = new QIGN_COMMON.vs_acontrol.CnButton();
			button_savepikxy = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stop = new QIGN_COMMON.vs_acontrol.CnButton();
			button_autopik_close = new QIGN_COMMON.vs_acontrol.CnButton();
			button_autorun_cur = new QIGN_COMMON.vs_acontrol.CnButton();
			button_prev = new QIGN_COMMON.vs_acontrol.CnButton();
			button_next = new QIGN_COMMON.vs_acontrol.CnButton();
			button_all = new QIGN_COMMON.vs_acontrol.CnButton();
			button_delSubPlate = new QIGN_COMMON.vs_acontrol.CnButton();
			button_addSubPlate = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackplateXY_moveto_byZn = new QIGN_COMMON.vs_acontrol.CnButton();
			button_platexy_close = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackplateGenXYlist = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackplateSaveXYS = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackplateMoveToXYS = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackplateXY_moveto = new QIGN_COMMON.vs_acontrol.CnButton();
			button2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_closefeeder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_campara = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackplateXY_update = new QIGN_COMMON.vs_acontrol.CnButton();
			button_hcam_specialpara = new QIGN_COMMON.vs_acontrol.CnButton();
			button_mntH_Goto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pikH_Goto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_mntH_Save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pikH_Save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_mntH_View = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pikH_View = new QIGN_COMMON.vs_acontrol.CnButton();
			button_mntH_Offset_Sync = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pikH_Offset_Sync = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_stackplate_startIndex = new QIGN_COMMON.vs_acontrol.CnButton();
			button_reback = new QIGN_COMMON.vs_acontrol.CnButton();
			button_goto_pikxy_byNozzle = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pikBaseH = new QIGN_COMMON.vs_acontrol.CnButton();
			button_curdefault = new QIGN_COMMON.vs_acontrol.CnButton();
			button_autoPixXY = new QIGN_COMMON.vs_acontrol.CnButton();
			button_openfeeder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_footprint = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackSaveXY = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackMoveToXY = new QIGN_COMMON.vs_acontrol.CnButton();
			button_gotoPrevStack = new QIGN_COMMON.vs_acontrol.CnButton();
			button_gotoNextStack = new QIGN_COMMON.vs_acontrol.CnButton();
			button_EnableNozzle = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stackCopy = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close_enableZn = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stacksel_feeder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stacksel_plate = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stacksel_vibra = new QIGN_COMMON.vs_acontrol.CnButton();
			button_mntBaseH = new QIGN_COMMON.vs_acontrol.CnButton();
			button_visualrunning = new QIGN_COMMON.vs_acontrol.CnButton();
			button_visualtest2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_collect = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PikToHighCam = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PikToFastCam = new QIGN_COMMON.vs_acontrol.CnButton();
			button_platexy = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_isScanR.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_scanR).BeginInit();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			panel1.SuspendLayout();
			panel_feeder.SuspendLayout();
			panel_context2.SuspendLayout();
			panel_context2_2.SuspendLayout();
			panel_hcam_special.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_hcam_special_level).BeginInit();
			panel_iscolloect.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_stackCollect).BeginInit();
			panel_context3.SuspendLayout();
			panel4.SuspendLayout();
			panel6.SuspendLayout();
			panel_context4.SuspendLayout();
			panel_chip_hmm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_AutoEntTimeDelay).BeginInit();
			panel_stackplate_autoprovider.SuspendLayout();
			panel_stackselNew_Page.SuspendLayout();
			panel_context1.SuspendLayout();
			panel_stacktool0.SuspendLayout();
			panel_enable_Zn.SuspendLayout();
			panel2.SuspendLayout();
			panel_head.SuspendLayout();
			panel_feederdelay.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_feederdelay).BeginInit();
			panel_plateXYlist.SuspendLayout();
			panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_stackplateXY).BeginInit();
			panel45.SuspendLayout();
			panel_addSubPlate.SuspendLayout();
			panel48.SuspendLayout();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nud_stackplate_rows).BeginInit();
			((System.ComponentModel.ISupportInitialize)nud_stackplate_columns).BeginInit();
			panel_autopikxy.SuspendLayout();
			panel9.SuspendLayout();
			panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_first_feederin).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_scanr).BeginInit();
			panel11.SuspendLayout();
			panel8.SuspendLayout();
			SuspendLayout();
			panel_stacknew_visual.Location = new System.Drawing.Point(8, 89);
			panel_stacknew_visual.Name = "panel_stacknew_visual";
			panel_stacknew_visual.Size = new System.Drawing.Size(690, 76);
			panel_stacknew_visual.TabIndex = 9;
			panel_isScanR.Controls.Add(label_scanR);
			panel_isScanR.Controls.Add(trackBar_scanR);
			panel_isScanR.Location = new System.Drawing.Point(238, 26);
			panel_isScanR.Name = "panel_isScanR";
			panel_isScanR.Size = new System.Drawing.Size(178, 26);
			panel_isScanR.TabIndex = 12;
			label_scanR.BackColor = System.Drawing.Color.White;
			label_scanR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_scanR.Font = new System.Drawing.Font("黑体", 10.5f);
			label_scanR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_scanR.Location = new System.Drawing.Point(3, 2);
			label_scanR.Name = "label_scanR";
			label_scanR.Size = new System.Drawing.Size(32, 22);
			label_scanR.TabIndex = 6;
			label_scanR.Text = "180";
			label_scanR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			trackBar_scanR.Location = new System.Drawing.Point(30, 2);
			trackBar_scanR.Maximum = 920;
			trackBar_scanR.Name = "trackBar_scanR";
			trackBar_scanR.Size = new System.Drawing.Size(112, 45);
			trackBar_scanR.TabIndex = 7;
			trackBar_scanR.TickFrequency = 30;
			trackBar_scanR.Scroll += new System.EventHandler(trackBar_scanR_Scroll);
			trackBar_scanR.MouseUp += new System.Windows.Forms.MouseEventHandler(trackBar_scanR_MouseUp);
			label_stacknew_chipHmm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stacknew_chipHmm.Font = new System.Drawing.Font("黑体", 11.5f);
			label_stacknew_chipHmm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipHmm.Location = new System.Drawing.Point(64, 2);
			label_stacknew_chipHmm.Name = "label_stacknew_chipHmm";
			label_stacknew_chipHmm.Size = new System.Drawing.Size(57, 22);
			label_stacknew_chipHmm.TabIndex = 6;
			label_stacknew_chipHmm.Tag = "hmm";
			label_stacknew_chipHmm.Text = "100";
			label_stacknew_chipHmm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_stacknew_chipHmm.DoubleClick += new System.EventHandler(label_stacknew_chipLmm_DoubleClick);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Location = new System.Drawing.Point(1351, 258);
			tabControl1.Multiline = true;
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(347, 105);
			tabControl1.TabIndex = 13;
			tabPage1.Controls.Add(panel1);
			tabPage1.Location = new System.Drawing.Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(339, 77);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "视图";
			tabPage1.UseVisualStyleBackColor = true;
			panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			panel1.Controls.Add(label5);
			panel1.Controls.Add(panel_feeder);
			panel1.Location = new System.Drawing.Point(6, 6);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1248, 794);
			panel1.TabIndex = 0;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 13.25f);
			label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			label5.Location = new System.Drawing.Point(572, 19);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(80, 18);
			label5.TabIndex = 1;
			label5.Text = "普通飞达";
			panel_feeder.BackColor = System.Drawing.Color.DimGray;
			panel_feeder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_feeder.Controls.Add(label4);
			panel_feeder.Controls.Add(label3);
			panel_feeder.Controls.Add(panel_vibra);
			panel_feeder.Controls.Add(panel_plate);
			panel_feeder.Location = new System.Drawing.Point(3, 235);
			panel_feeder.Name = "panel_feeder";
			panel_feeder.Size = new System.Drawing.Size(1242, 314);
			panel_feeder.TabIndex = 0;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 13.25f);
			label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label4.Location = new System.Drawing.Point(885, 27);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(80, 18);
			label4.TabIndex = 1;
			label4.Text = "振动飞达";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 13.25f);
			label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label3.Location = new System.Drawing.Point(260, 27);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(98, 18);
			label3.TabIndex = 1;
			label3.Text = "料盘(托盘)";
			panel_vibra.AutoScroll = true;
			panel_vibra.BackColor = System.Drawing.SystemColors.ActiveCaption;
			panel_vibra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_vibra.Location = new System.Drawing.Point(686, 55);
			panel_vibra.Name = "panel_vibra";
			panel_vibra.Size = new System.Drawing.Size(480, 229);
			panel_vibra.TabIndex = 0;
			panel_plate.AutoScroll = true;
			panel_plate.BackColor = System.Drawing.SystemColors.ActiveCaption;
			panel_plate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_plate.Location = new System.Drawing.Point(58, 55);
			panel_plate.Name = "panel_plate";
			panel_plate.Size = new System.Drawing.Size(509, 229);
			panel_plate.TabIndex = 0;
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(339, 79);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "详情";
			tabPage2.UseVisualStyleBackColor = true;
			label_stacknew_chipWmm.BackColor = System.Drawing.Color.White;
			label_stacknew_chipWmm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stacknew_chipWmm.Font = new System.Drawing.Font("黑体", 11.5f);
			label_stacknew_chipWmm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipWmm.Location = new System.Drawing.Point(47, 28);
			label_stacknew_chipWmm.Name = "label_stacknew_chipWmm";
			label_stacknew_chipWmm.Size = new System.Drawing.Size(77, 22);
			label_stacknew_chipWmm.TabIndex = 6;
			label_stacknew_chipWmm.Tag = "wmm";
			label_stacknew_chipWmm.Text = "100";
			label_stacknew_chipWmm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_stacknew_chipWmm.DoubleClick += new System.EventHandler(label_stacknew_chipLmm_DoubleClick);
			label_stacknew_chipLmm.BackColor = System.Drawing.Color.White;
			label_stacknew_chipLmm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stacknew_chipLmm.Font = new System.Drawing.Font("黑体", 11.5f);
			label_stacknew_chipLmm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipLmm.Location = new System.Drawing.Point(47, 4);
			label_stacknew_chipLmm.Name = "label_stacknew_chipLmm";
			label_stacknew_chipLmm.Size = new System.Drawing.Size(77, 22);
			label_stacknew_chipLmm.TabIndex = 6;
			label_stacknew_chipLmm.Tag = "lmm";
			label_stacknew_chipLmm.Text = "100";
			label_stacknew_chipLmm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_stacknew_chipLmm.DoubleClick += new System.EventHandler(label_stacknew_chipLmm_DoubleClick);
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(4, 6);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(63, 14);
			label26.TabIndex = 0;
			label26.Text = "厚度(mm)";
			checkBox_stackCollect.AutoSize = true;
			checkBox_stackCollect.Location = new System.Drawing.Point(131, 5);
			checkBox_stackCollect.Name = "checkBox_stackCollect";
			checkBox_stackCollect.Size = new System.Drawing.Size(82, 18);
			checkBox_stackCollect.TabIndex = 11;
			checkBox_stackCollect.Text = "特征识别";
			checkBox_stackCollect.UseVisualStyleBackColor = true;
			checkBox_stackCollect.CheckedChanged += new System.EventHandler(checkBox_stackCollect_CheckedChanged);
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(2, 33);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(49, 14);
			label15.TabIndex = 0;
			label15.Text = "宽(mm)";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(4, 5);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(84, 14);
			label23.TabIndex = 0;
			label23.Text = "识别容差(%)";
			checkBox_isScanR.AutoSize = true;
			checkBox_isScanR.Location = new System.Drawing.Point(131, 31);
			checkBox_isScanR.Name = "checkBox_isScanR";
			checkBox_isScanR.Size = new System.Drawing.Size(110, 18);
			checkBox_isScanR.TabIndex = 11;
			checkBox_isScanR.Text = "专用扫描半径";
			checkBox_isScanR.UseVisualStyleBackColor = true;
			checkBox_isScanR.CheckedChanged += new System.EventHandler(checkBox_isScanR_CheckedChanged);
			panel_stacknew_pik.Location = new System.Drawing.Point(10, 35);
			panel_stacknew_pik.Name = "panel_stacknew_pik";
			panel_stacknew_pik.Size = new System.Drawing.Size(690, 136);
			panel_stacknew_pik.TabIndex = 9;
			panel_stacknew_mnt.Location = new System.Drawing.Point(11, 33);
			panel_stacknew_mnt.Name = "panel_stacknew_mnt";
			panel_stacknew_mnt.Size = new System.Drawing.Size(690, 145);
			panel_stacknew_mnt.TabIndex = 9;
			panel_nozzleenable.BackColor = System.Drawing.Color.White;
			panel_nozzleenable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_nozzleenable.Location = new System.Drawing.Point(9, 7);
			panel_nozzleenable.Name = "panel_nozzleenable";
			panel_nozzleenable.Size = new System.Drawing.Size(530, 26);
			panel_nozzleenable.TabIndex = 1;
			panel_context2.Controls.Add(panel_stacknew_visual);
			panel_context2.Controls.Add(button_visualrunning);
			panel_context2.Controls.Add(button_visualtest2);
			panel_context2.Controls.Add(panel_context2_2);
			panel_context2.Controls.Add(button_collect);
			panel_context2.Controls.Add(button_PikToHighCam);
			panel_context2.Controls.Add(button_PikToFastCam);
			panel_context2.Location = new System.Drawing.Point(4, 613);
			panel_context2.Name = "panel_context2";
			panel_context2.Size = new System.Drawing.Size(682, 140);
			panel_context2.TabIndex = 9;
			panel_context2_2.Controls.Add(panel_hcam_special);
			panel_context2_2.Controls.Add(checkBox_is_hcam_special);
			panel_context2_2.Controls.Add(label_stack_visual);
			panel_context2_2.Controls.Add(panel_iscolloect);
			panel_context2_2.Controls.Add(panel_isScanR);
			panel_context2_2.Controls.Add(label_stacknew_chipWmm);
			panel_context2_2.Controls.Add(label_stacknew_chipLmm);
			panel_context2_2.Controls.Add(checkBox_stackCollect);
			panel_context2_2.Controls.Add(label15);
			panel_context2_2.Controls.Add(checkBox_isScanR);
			panel_context2_2.Controls.Add(label14);
			panel_context2_2.Location = new System.Drawing.Point(301, -1);
			panel_context2_2.Name = "panel_context2_2";
			panel_context2_2.Size = new System.Drawing.Size(407, 98);
			panel_context2_2.TabIndex = 13;
			panel_hcam_special.Controls.Add(label_hcam_special_level);
			panel_hcam_special.Controls.Add(trackBar_hcam_special_level);
			panel_hcam_special.Location = new System.Drawing.Point(238, 54);
			panel_hcam_special.Name = "panel_hcam_special";
			panel_hcam_special.Size = new System.Drawing.Size(180, 38);
			panel_hcam_special.TabIndex = 26;
			label_hcam_special_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_hcam_special_level.Location = new System.Drawing.Point(3, 4);
			label_hcam_special_level.Name = "label_hcam_special_level";
			label_hcam_special_level.Size = new System.Drawing.Size(32, 22);
			label_hcam_special_level.TabIndex = 24;
			label_hcam_special_level.Text = "300";
			label_hcam_special_level.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			trackBar_hcam_special_level.Location = new System.Drawing.Point(30, 4);
			trackBar_hcam_special_level.Maximum = 840;
			trackBar_hcam_special_level.Name = "trackBar_hcam_special_level";
			trackBar_hcam_special_level.Size = new System.Drawing.Size(112, 45);
			trackBar_hcam_special_level.TabIndex = 25;
			trackBar_hcam_special_level.TickFrequency = 30;
			trackBar_hcam_special_level.Scroll += new System.EventHandler(trackBar_hcam_special_level_Scroll);
			checkBox_is_hcam_special.AutoSize = true;
			checkBox_is_hcam_special.Location = new System.Drawing.Point(131, 59);
			checkBox_is_hcam_special.Name = "checkBox_is_hcam_special";
			checkBox_is_hcam_special.Size = new System.Drawing.Size(110, 18);
			checkBox_is_hcam_special.TabIndex = 10;
			checkBox_is_hcam_special.Text = "专用高清光源";
			checkBox_is_hcam_special.UseVisualStyleBackColor = true;
			checkBox_is_hcam_special.CheckedChanged += new System.EventHandler(checkBox_is_hcam_special_CheckedChanged);
			label_stack_visual.BackColor = System.Drawing.Color.White;
			label_stack_visual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stack_visual.Font = new System.Drawing.Font("黑体", 10.5f);
			label_stack_visual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stack_visual.Location = new System.Drawing.Point(1, 54);
			label_stack_visual.Name = "label_stack_visual";
			label_stack_visual.Size = new System.Drawing.Size(123, 30);
			label_stack_visual.TabIndex = 6;
			label_stack_visual.Text = "标准视觉";
			label_stack_visual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_stack_visual.Click += new System.EventHandler(label_stack_visual_Click);
			panel_iscolloect.Controls.Add(label23);
			panel_iscolloect.Controls.Add(numericUpDown_stackCollect);
			panel_iscolloect.Location = new System.Drawing.Point(230, 1);
			panel_iscolloect.Name = "panel_iscolloect";
			panel_iscolloect.Size = new System.Drawing.Size(161, 25);
			panel_iscolloect.TabIndex = 23;
			numericUpDown_stackCollect.Location = new System.Drawing.Point(89, 1);
			numericUpDown_stackCollect.Name = "numericUpDown_stackCollect";
			numericUpDown_stackCollect.Size = new System.Drawing.Size(52, 23);
			numericUpDown_stackCollect.TabIndex = 8;
			numericUpDown_stackCollect.ValueChanged += new System.EventHandler(numericUpDown_stackCollect_ValueChanged);
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(2, 10);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(49, 14);
			label14.TabIndex = 0;
			label14.Text = "长(mm)";
			label17.Font = new System.Drawing.Font("黑体", 12.75f);
			label17.Location = new System.Drawing.Point(4, 6);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(134, 22);
			label17.TabIndex = 0;
			label17.Text = "● 取料Z轴设置";
			label8.Font = new System.Drawing.Font("黑体", 12.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label8.ForeColor = System.Drawing.Color.Black;
			label8.Location = new System.Drawing.Point(7, 593);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(126, 18);
			label8.TabIndex = 0;
			label8.Text = "● 视觉参数调试";
			listBox_StackVibraAll.ColumnWidth = 30;
			listBox_StackVibraAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			listBox_StackVibraAll.Font = new System.Drawing.Font("楷体", 15f);
			listBox_StackVibraAll.FormattingEnabled = true;
			listBox_StackVibraAll.ItemHeight = 20;
			listBox_StackVibraAll.Items.AddRange(new object[32]
			{
				"01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
				"11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
				"21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
				"31", "32"
			});
			listBox_StackVibraAll.Location = new System.Drawing.Point(803, 572);
			listBox_StackVibraAll.MultiColumn = true;
			listBox_StackVibraAll.Name = "listBox_StackVibraAll";
			listBox_StackVibraAll.Size = new System.Drawing.Size(484, 44);
			listBox_StackVibraAll.TabIndex = 6;
			listBox_StackVibraAll.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox_StackVibraAll_MouseClick);
			listBox_StackVibraAll.DrawItem += new System.Windows.Forms.DrawItemEventHandler(listBox_StackVibraAll_DrawItem);
			label_stacksel_title.AutoSize = true;
			label_stacksel_title.Font = new System.Drawing.Font("黑体", 17.25f);
			label_stacksel_title.Location = new System.Drawing.Point(7, 78);
			label_stacksel_title.Name = "label_stacksel_title";
			label_stacksel_title.Size = new System.Drawing.Size(106, 23);
			label_stacksel_title.TabIndex = 1;
			label_stacksel_title.Text = "普通飞达";
			label_Vibra.BackColor = System.Drawing.Color.Red;
			label_Vibra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_Vibra.Font = new System.Drawing.Font("黑体", 30.25f, System.Drawing.FontStyle.Bold);
			label_Vibra.ForeColor = System.Drawing.Color.White;
			label_Vibra.Location = new System.Drawing.Point(733, 571);
			label_Vibra.Name = "label_Vibra";
			label_Vibra.Size = new System.Drawing.Size(64, 64);
			label_Vibra.TabIndex = 6;
			label_Vibra.Tag = "vibra";
			label_Vibra.Text = "12";
			label_Vibra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_Vibra.MouseHover += new System.EventHandler(label_Stack_MouseHover_1);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 16.25f);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(791, 215);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(98, 22);
			label1.TabIndex = 14;
			label1.Text = "料站参数";
			label30.AutoSize = true;
			label30.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label30.Location = new System.Drawing.Point(1189, 2);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(76, 16);
			label30.TabIndex = 15;
			label30.Text = "供料选择";
			panel_context3.Controls.Add(button_goto_pikxy_byNozzle);
			panel_context3.Controls.Add(panel_stacknew_pik);
			panel_context3.Controls.Add(button_pikBaseH);
			panel_context3.Controls.Add(label17);
			panel_context3.Location = new System.Drawing.Point(1, 250);
			panel_context3.Name = "panel_context3";
			panel_context3.Size = new System.Drawing.Size(703, 175);
			panel_context3.TabIndex = 10;
			label10.Font = new System.Drawing.Font("黑体", 12.25f);
			label10.Location = new System.Drawing.Point(7, 8);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(154, 22);
			label10.TabIndex = 0;
			label10.Text = "● 贴装Z轴设置";
			listBox_StackPlateAll.ColumnWidth = 30;
			listBox_StackPlateAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			listBox_StackPlateAll.Font = new System.Drawing.Font("楷体", 15f);
			listBox_StackPlateAll.FormattingEnabled = true;
			listBox_StackPlateAll.ItemHeight = 20;
			listBox_StackPlateAll.Items.AddRange(new object[35]
			{
				"01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
				"11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
				"21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
				"31", "32", "33", "34", "35"
			});
			listBox_StackPlateAll.Location = new System.Drawing.Point(799, 66);
			listBox_StackPlateAll.MultiColumn = true;
			listBox_StackPlateAll.Name = "listBox_StackPlateAll";
			listBox_StackPlateAll.Size = new System.Drawing.Size(484, 64);
			listBox_StackPlateAll.TabIndex = 6;
			listBox_StackPlateAll.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox_StackPlateAll_MouseClick);
			listBox_StackPlateAll.DrawItem += new System.Windows.Forms.DrawItemEventHandler(listBox_StackPlateAll_DrawItem);
			label_Stack.BackColor = System.Drawing.Color.Red;
			label_Stack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_Stack.Font = new System.Drawing.Font("黑体", 30.25f, System.Drawing.FontStyle.Bold);
			label_Stack.ForeColor = System.Drawing.Color.White;
			label_Stack.Location = new System.Drawing.Point(2, 1);
			label_Stack.Name = "label_Stack";
			label_Stack.Size = new System.Drawing.Size(107, 107);
			label_Stack.TabIndex = 6;
			label_Stack.Tag = "feeder";
			label_Stack.Text = "12";
			label_Stack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_Stack.MouseHover += new System.EventHandler(label_Stack_MouseHover_1);
			panel4.Controls.Add(button_autoPixXY);
			panel4.Controls.Add(button_openfeeder);
			panel4.Controls.Add(button_footprint);
			panel4.Controls.Add(panel6);
			panel4.Controls.Add(button_EnableNozzle);
			panel4.Controls.Add(button_stackCopy);
			panel4.Location = new System.Drawing.Point(107, -2);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(599, 112);
			panel4.TabIndex = 22;
			panel6.Controls.Add(label_stackXY);
			panel6.Controls.Add(button_stackSaveXY);
			panel6.Controls.Add(button_stackMoveToXY);
			panel6.Controls.Add(button_gotoPrevStack);
			panel6.Controls.Add(button_gotoNextStack);
			panel6.Location = new System.Drawing.Point(1, 0);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(392, 56);
			panel6.TabIndex = 13;
			label_stackXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stackXY.Font = new System.Drawing.Font("黑体", 11.5f);
			label_stackXY.Location = new System.Drawing.Point(327, 4);
			label_stackXY.Name = "label_stackXY";
			label_stackXY.Size = new System.Drawing.Size(59, 45);
			label_stackXY.TabIndex = 6;
			label_stackXY.Text = "X00000\r\nY00000";
			label_stackXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_stackXY.DoubleClick += new System.EventHandler(label_stackXY_DoubleClick);
			panel3.BackColor = System.Drawing.Color.White;
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Location = new System.Drawing.Point(1289, 172);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(368, 64);
			panel3.TabIndex = 12;
			label_feederstate.BackColor = System.Drawing.Color.LightCyan;
			label_feederstate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_feederstate.Font = new System.Drawing.Font("黑体", 11f);
			label_feederstate.Location = new System.Drawing.Point(1289, 82);
			label_feederstate.Name = "label_feederstate";
			label_feederstate.Size = new System.Drawing.Size(48, 28);
			label_feederstate.TabIndex = 83;
			label_feederstate.Text = "已关";
			label_feederstate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_feederstate.Click += new System.EventHandler(label_feederstate_Click);
			label6.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label6.Location = new System.Drawing.Point(1362, 133);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(52, 52);
			label6.TabIndex = 82;
			label6.Text = "➠";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_StackPlate.BackColor = System.Drawing.Color.Red;
			label_StackPlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_StackPlate.Font = new System.Drawing.Font("黑体", 30.25f, System.Drawing.FontStyle.Bold);
			label_StackPlate.ForeColor = System.Drawing.Color.White;
			label_StackPlate.Location = new System.Drawing.Point(733, 65);
			label_StackPlate.Name = "label_StackPlate";
			label_StackPlate.Size = new System.Drawing.Size(64, 64);
			label_StackPlate.TabIndex = 6;
			label_StackPlate.Tag = "plate";
			label_StackPlate.Text = "12";
			label_StackPlate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_StackPlate.MouseHover += new System.EventHandler(label_Stack_MouseHover_1);
			label_stacknew_chipinfo.BackColor = System.Drawing.Color.White;
			label_stacknew_chipinfo.Font = new System.Drawing.Font("黑体", 14.5f);
			label_stacknew_chipinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipinfo.Location = new System.Drawing.Point(206, 74);
			label_stacknew_chipinfo.Name = "label_stacknew_chipinfo";
			label_stacknew_chipinfo.Size = new System.Drawing.Size(674, 28);
			label_stacknew_chipinfo.TabIndex = 6;
			label_stacknew_chipinfo.Text = "R0603 100K";
			label_stacknew_chipinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipinfo.DoubleClick += new System.EventHandler(label_stacknew_chipinfo_DoubleClick);
			panel_context4.Controls.Add(panel_chip_hmm);
			panel_context4.Controls.Add(panel_stacknew_mnt);
			panel_context4.Controls.Add(button_mntBaseH);
			panel_context4.Controls.Add(label10);
			panel_context4.Location = new System.Drawing.Point(0, 417);
			panel_context4.Name = "panel_context4";
			panel_context4.Size = new System.Drawing.Size(703, 179);
			panel_context4.TabIndex = 11;
			panel_chip_hmm.Controls.Add(label_stacknew_chipHmm);
			panel_chip_hmm.Controls.Add(label26);
			panel_chip_hmm.Location = new System.Drawing.Point(315, 5);
			panel_chip_hmm.Name = "panel_chip_hmm";
			panel_chip_hmm.Size = new System.Drawing.Size(133, 26);
			panel_chip_hmm.TabIndex = 10;
			numericUpDown_AutoEntTimeDelay.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_AutoEntTimeDelay.Location = new System.Drawing.Point(187, 4);
			numericUpDown_AutoEntTimeDelay.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			numericUpDown_AutoEntTimeDelay.Name = "numericUpDown_AutoEntTimeDelay";
			numericUpDown_AutoEntTimeDelay.Size = new System.Drawing.Size(72, 24);
			numericUpDown_AutoEntTimeDelay.TabIndex = 8;
			numericUpDown_AutoEntTimeDelay.ValueChanged += new System.EventHandler(numericUpDown_AutoEntTimeDelay_ValueChanged);
			panel_stackplate_autoprovider.Controls.Add(numericUpDown_AutoEntTimeDelay);
			panel_stackplate_autoprovider.Controls.Add(label13);
			panel_stackplate_autoprovider.Controls.Add(checkBox_stackplate_AutoEntComponent);
			panel_stackplate_autoprovider.Location = new System.Drawing.Point(0, 4);
			panel_stackplate_autoprovider.Name = "panel_stackplate_autoprovider";
			panel_stackplate_autoprovider.Size = new System.Drawing.Size(258, 33);
			panel_stackplate_autoprovider.TabIndex = 10;
			label13.Font = new System.Drawing.Font("黑体", 11f);
			label13.Location = new System.Drawing.Point(86, 8);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(103, 20);
			label13.TabIndex = 0;
			label13.Text = "换料延时(ms)";
			label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			checkBox_stackplate_AutoEntComponent.AutoSize = true;
			checkBox_stackplate_AutoEntComponent.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_stackplate_AutoEntComponent.Location = new System.Drawing.Point(4, 7);
			checkBox_stackplate_AutoEntComponent.Name = "checkBox_stackplate_AutoEntComponent";
			checkBox_stackplate_AutoEntComponent.Size = new System.Drawing.Size(90, 19);
			checkBox_stackplate_AutoEntComponent.TabIndex = 11;
			checkBox_stackplate_AutoEntComponent.Text = "自动供料";
			checkBox_stackplate_AutoEntComponent.UseVisualStyleBackColor = true;
			checkBox_stackplate_AutoEntComponent.CheckedChanged += new System.EventHandler(checkBox_stackplate_AutoEntComponent_CheckedChanged_1);
			panel_stackselNew_Page.BackColor = System.Drawing.Color.White;
			panel_stackselNew_Page.Controls.Add(cnButton_stackplate_startIndex);
			panel_stackselNew_Page.Controls.Add(button_reback);
			panel_stackselNew_Page.Controls.Add(panel_context3);
			panel_stackselNew_Page.Controls.Add(label_stacknew_chipinfo);
			panel_stackselNew_Page.Controls.Add(button_curdefault);
			panel_stackselNew_Page.Controls.Add(label12);
			panel_stackselNew_Page.Controls.Add(label8);
			panel_stackselNew_Page.Controls.Add(panel_context1);
			panel_stackselNew_Page.Controls.Add(panel_head);
			panel_stackselNew_Page.Controls.Add(panel_context4);
			panel_stackselNew_Page.Controls.Add(panel_context2);
			panel_stackselNew_Page.Controls.Add(label_stacksel_title);
			panel_stackselNew_Page.Controls.Add(label20);
			panel_stackselNew_Page.Controls.Add(button_platexy);
			panel_stackselNew_Page.Controls.Add(label7);
			panel_stackselNew_Page.Location = new System.Drawing.Point(10, 148);
			panel_stackselNew_Page.Name = "panel_stackselNew_Page";
			panel_stackselNew_Page.Size = new System.Drawing.Size(685, 760);
			panel_stackselNew_Page.TabIndex = 17;
			label12.Font = new System.Drawing.Font("黑体", 12.75f);
			label12.Location = new System.Drawing.Point(37, 593);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(126, 22);
			label12.TabIndex = 0;
			label12.Text = "视觉参数调试";
			panel_context1.Controls.Add(label_Stack);
			panel_context1.Controls.Add(panel4);
			panel_context1.Controls.Add(panel_stacktool0);
			panel_context1.Location = new System.Drawing.Point(6, 105);
			panel_context1.Name = "panel_context1";
			panel_context1.Size = new System.Drawing.Size(705, 160);
			panel_context1.TabIndex = 22;
			panel_stacktool0.Controls.Add(panel_enable_Zn);
			panel_stacktool0.Controls.Add(panel2);
			panel_stacktool0.Location = new System.Drawing.Point(-2, 107);
			panel_stacktool0.Name = "panel_stacktool0";
			panel_stacktool0.Size = new System.Drawing.Size(712, 48);
			panel_stacktool0.TabIndex = 7;
			panel_enable_Zn.BackColor = System.Drawing.Color.LightBlue;
			panel_enable_Zn.Controls.Add(button_close_enableZn);
			panel_enable_Zn.Controls.Add(panel_nozzleenable);
			panel_enable_Zn.Location = new System.Drawing.Point(3, 2);
			panel_enable_Zn.Name = "panel_enable_Zn";
			panel_enable_Zn.Size = new System.Drawing.Size(689, 41);
			panel_enable_Zn.TabIndex = 84;
			panel_enable_Zn.Visible = false;
			panel2.BackColor = System.Drawing.Color.White;
			panel2.Controls.Add(label_angle);
			panel2.Controls.Add(label29);
			panel2.Controls.Add(panel_stackplate_autoprovider);
			panel2.Location = new System.Drawing.Point(113, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(476, 40);
			panel2.TabIndex = 11;
			label_angle.BackColor = System.Drawing.Color.White;
			label_angle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_angle.Font = new System.Drawing.Font("黑体", 11f);
			label_angle.Location = new System.Drawing.Point(336, 9);
			label_angle.Name = "label_angle";
			label_angle.Size = new System.Drawing.Size(47, 22);
			label_angle.TabIndex = 23;
			label_angle.Tag = "angle";
			label_angle.Text = "0.0";
			label_angle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_angle.DoubleClick += new System.EventHandler(label_stacknew_chipLmm_DoubleClick);
			label29.Font = new System.Drawing.Font("黑体", 11f);
			label29.Location = new System.Drawing.Point(264, 12);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(71, 20);
			label29.TabIndex = 11;
			label29.Text = "进料角度";
			label29.TextAlign = System.Drawing.ContentAlignment.TopRight;
			panel_head.BackColor = System.Drawing.Color.DimGray;
			panel_head.Controls.Add(button_stacksel_feeder);
			panel_head.Controls.Add(button_stacksel_plate);
			panel_head.Controls.Add(button_stacksel_vibra);
			panel_head.Location = new System.Drawing.Point(0, 0);
			panel_head.Name = "panel_head";
			panel_head.Size = new System.Drawing.Size(704, 65);
			panel_head.TabIndex = 12;
			label20.BackColor = System.Drawing.Color.White;
			label20.Location = new System.Drawing.Point(0, 484);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(712, 6);
			label20.TabIndex = 4;
			label7.BackColor = System.Drawing.Color.Red;
			label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label7.Location = new System.Drawing.Point(-3, 821);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(705, 10);
			label7.TabIndex = 23;
			label7.Visible = false;
			label32.BackColor = System.Drawing.Color.DimGray;
			label32.Font = new System.Drawing.Font("黑体", 16.75f);
			label32.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label32.Location = new System.Drawing.Point(10, 9);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(156, 76);
			label32.TabIndex = 0;
			label32.Text = "料站参数";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label31.BackColor = System.Drawing.Color.White;
			label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label31.Location = new System.Drawing.Point(732, 961);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(800, 283);
			label31.TabIndex = 24;
			panel_feederdelay.Controls.Add(numericUpDown_feederdelay);
			panel_feederdelay.Controls.Add(label28);
			panel_feederdelay.Controls.Add(label16);
			panel_feederdelay.Location = new System.Drawing.Point(829, 152);
			panel_feederdelay.Name = "panel_feederdelay";
			panel_feederdelay.Size = new System.Drawing.Size(273, 33);
			panel_feederdelay.TabIndex = 10;
			numericUpDown_feederdelay.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_feederdelay.Location = new System.Drawing.Point(190, 5);
			numericUpDown_feederdelay.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			numericUpDown_feederdelay.Name = "numericUpDown_feederdelay";
			numericUpDown_feederdelay.Size = new System.Drawing.Size(72, 24);
			numericUpDown_feederdelay.TabIndex = 8;
			numericUpDown_feederdelay.ValueChanged += new System.EventHandler(numericUpDown_feederdelay_ValueChanged);
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("黑体", 11f);
			label28.Location = new System.Drawing.Point(20, 8);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(71, 15);
			label28.TabIndex = 0;
			label28.Text = "连续取料";
			label16.Font = new System.Drawing.Font("黑体", 11f);
			label16.Location = new System.Drawing.Point(89, 8);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(103, 20);
			label16.TabIndex = 0;
			label16.Text = "换料延时(ms)";
			label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			panel_plateXYlist.BackColor = System.Drawing.Color.White;
			panel_plateXYlist.Controls.Add(panel7);
			panel_plateXYlist.Font = new System.Drawing.Font("楷体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_plateXYlist.Location = new System.Drawing.Point(768, 326);
			panel_plateXYlist.Name = "panel_plateXYlist";
			panel_plateXYlist.Size = new System.Drawing.Size(565, 224);
			panel_plateXYlist.TabIndex = 1;
			panel7.BackColor = System.Drawing.Color.DimGray;
			panel7.Controls.Add(listBox_subPlate);
			panel7.Controls.Add(label18);
			panel7.Controls.Add(dataGridView_stackplateXY);
			panel7.Controls.Add(panel45);
			panel7.Controls.Add(button_stackplateXY_moveto_byZn);
			panel7.Controls.Add(button_platexy_close);
			panel7.Controls.Add(label9);
			panel7.Controls.Add(panel48);
			panel7.Controls.Add(button_stackplateXY_moveto);
			panel7.Location = new System.Drawing.Point(5, 6);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(554, 212);
			panel7.TabIndex = 81;
			listBox_subPlate.ColumnWidth = 30;
			listBox_subPlate.Font = new System.Drawing.Font("微软雅黑", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			listBox_subPlate.FormattingEnabled = true;
			listBox_subPlate.ItemHeight = 19;
			listBox_subPlate.Items.AddRange(new object[9] { "1", "2", "3", "4", "5", "22", "222", "8", "9" });
			listBox_subPlate.Location = new System.Drawing.Point(0, 0);
			listBox_subPlate.Name = "listBox_subPlate";
			listBox_subPlate.Size = new System.Drawing.Size(30, 232);
			listBox_subPlate.TabIndex = 5;
			listBox_subPlate.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox_subPlate_MouseClick);
			label18.BackColor = System.Drawing.Color.Red;
			label18.Location = new System.Drawing.Point(351, 22);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(150, 6);
			label18.TabIndex = 80;
			dataGridView_stackplateXY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_stackplateXY.Location = new System.Drawing.Point(317, 34);
			dataGridView_stackplateXY.Name = "dataGridView_stackplateXY";
			dataGridView_stackplateXY.RowTemplate.Height = 23;
			dataGridView_stackplateXY.Size = new System.Drawing.Size(232, 134);
			dataGridView_stackplateXY.TabIndex = 79;
			dataGridView_stackplateXY.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_stackplateXY_CellMouseClick);
			panel45.Controls.Add(checkBox_addSubPlate);
			panel45.Controls.Add(panel_addSubPlate);
			panel45.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			panel45.Location = new System.Drawing.Point(31, 163);
			panel45.Name = "panel45";
			panel45.Size = new System.Drawing.Size(288, 52);
			panel45.TabIndex = 4;
			checkBox_addSubPlate.AutoSize = true;
			checkBox_addSubPlate.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_addSubPlate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			checkBox_addSubPlate.Location = new System.Drawing.Point(6, -2);
			checkBox_addSubPlate.Name = "checkBox_addSubPlate";
			checkBox_addSubPlate.Size = new System.Drawing.Size(250, 19);
			checkBox_addSubPlate.TabIndex = 2;
			checkBox_addSubPlate.Text = "为该料盘添加相同元件的子料盘";
			checkBox_addSubPlate.UseVisualStyleBackColor = true;
			checkBox_addSubPlate.CheckedChanged += new System.EventHandler(checkBox_addSubPlate_CheckedChanged);
			panel_addSubPlate.Controls.Add(button_delSubPlate);
			panel_addSubPlate.Controls.Add(button_addSubPlate);
			panel_addSubPlate.Location = new System.Drawing.Point(-9, 16);
			panel_addSubPlate.Name = "panel_addSubPlate";
			panel_addSubPlate.Size = new System.Drawing.Size(298, 37);
			panel_addSubPlate.TabIndex = 1;
			panel_addSubPlate.Visible = false;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("黑体", 13f);
			label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label9.Location = new System.Drawing.Point(349, 2);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(152, 18);
			label9.TabIndex = 3;
			label9.Text = "料盘取料坐标列表";
			panel48.Controls.Add(panel5);
			panel48.Controls.Add(button_stackplateGenXYlist);
			panel48.Controls.Add(label_row);
			panel48.Controls.Add(button_stackplateSaveXYS);
			panel48.Controls.Add(label11);
			panel48.Controls.Add(nud_stackplate_rows);
			panel48.Controls.Add(label_column);
			panel48.Controls.Add(nud_stackplate_columns);
			panel48.Controls.Add(button_stackplateMoveToXYS);
			panel48.Controls.Add(label22);
			panel48.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			panel48.Location = new System.Drawing.Point(30, 1);
			panel48.Name = "panel48";
			panel48.Size = new System.Drawing.Size(305, 168);
			panel48.TabIndex = 76;
			panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel5.Controls.Add(panel_componentarray);
			panel5.Controls.Add(label27);
			panel5.Controls.Add(label25);
			panel5.Controls.Add(label24);
			panel5.Controls.Add(label21);
			panel5.Location = new System.Drawing.Point(5, 20);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(270, 84);
			panel5.TabIndex = 74;
			panel_componentarray.BackColor = System.Drawing.SystemColors.ActiveCaption;
			panel_componentarray.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			panel_componentarray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_componentarray.Location = new System.Drawing.Point(64, -4);
			panel_componentarray.Name = "panel_componentarray";
			panel_componentarray.Size = new System.Drawing.Size(140, 82);
			panel_componentarray.TabIndex = 0;
			label27.BackColor = System.Drawing.Color.Azure;
			label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label27.Font = new System.Drawing.Font("黑体", 11.5f);
			label27.Location = new System.Drawing.Point(203, 42);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(66, 36);
			label27.TabIndex = 6;
			label27.Text = "X00000\r\nY00000";
			label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.BackColor = System.Drawing.Color.Azure;
			label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label25.Font = new System.Drawing.Font("黑体", 11.5f);
			label25.Location = new System.Drawing.Point(203, -1);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(66, 36);
			label25.TabIndex = 6;
			label25.Text = "X00000\r\nY00000";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label24.BackColor = System.Drawing.Color.Azure;
			label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label24.Font = new System.Drawing.Font("黑体", 11.5f);
			label24.Location = new System.Drawing.Point(-1, 42);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(66, 36);
			label24.TabIndex = 6;
			label24.Text = "X00000\r\nY00000";
			label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label21.BackColor = System.Drawing.Color.Azure;
			label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label21.Font = new System.Drawing.Font("黑体", 11.5f);
			label21.Location = new System.Drawing.Point(-1, -2);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(66, 36);
			label21.TabIndex = 6;
			label21.Text = "X00000\r\nY00000";
			label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_row.AutoSize = true;
			label_row.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_row.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label_row.Location = new System.Drawing.Point(0, 134);
			label_row.Name = "label_row";
			label_row.Size = new System.Drawing.Size(23, 15);
			label_row.TabIndex = 18;
			label_row.Text = "行";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label11.Location = new System.Drawing.Point(76, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(104, 16);
			label11.TabIndex = 3;
			label11.Text = "料盘位置设置";
			nud_stackplate_rows.Font = new System.Drawing.Font("黑体", 10.25f);
			nud_stackplate_rows.Location = new System.Drawing.Point(24, 129);
			nud_stackplate_rows.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_stackplate_rows.Name = "nud_stackplate_rows";
			nud_stackplate_rows.Size = new System.Drawing.Size(46, 23);
			nud_stackplate_rows.TabIndex = 17;
			nud_stackplate_rows.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_stackplate_rows.ValueChanged += new System.EventHandler(nud_stackplate_rows_ValueChanged);
			label_column.AutoSize = true;
			label_column.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_column.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label_column.Location = new System.Drawing.Point(0, 108);
			label_column.Name = "label_column";
			label_column.Size = new System.Drawing.Size(23, 15);
			label_column.TabIndex = 18;
			label_column.Text = "列";
			nud_stackplate_columns.Font = new System.Drawing.Font("黑体", 10.25f);
			nud_stackplate_columns.Location = new System.Drawing.Point(24, 103);
			nud_stackplate_columns.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_stackplate_columns.Name = "nud_stackplate_columns";
			nud_stackplate_columns.Size = new System.Drawing.Size(46, 23);
			nud_stackplate_columns.TabIndex = 19;
			nud_stackplate_columns.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_stackplate_columns.ValueChanged += new System.EventHandler(nud_stackplate_columns_ValueChanged);
			label22.Font = new System.Drawing.Font("微软雅黑", 22.25f);
			label22.Location = new System.Drawing.Point(258, 101);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(37, 42);
			label22.TabIndex = 14;
			label22.Text = "➠";
			label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_autopikxy.BackColor = System.Drawing.Color.White;
			panel_autopikxy.Controls.Add(panel9);
			panel_autopikxy.Location = new System.Drawing.Point(712, 639);
			panel_autopikxy.Name = "panel_autopikxy";
			panel_autopikxy.Size = new System.Drawing.Size(682, 176);
			panel_autopikxy.TabIndex = 84;
			panel9.BackColor = System.Drawing.Color.DimGray;
			panel9.Controls.Add(label_state);
			panel9.Controls.Add(button_savepikxy);
			panel9.Controls.Add(checkBox_autosave);
			panel9.Controls.Add(panel10);
			panel9.Controls.Add(button_stop);
			panel9.Controls.Add(label35);
			panel9.Controls.Add(button_autopik_close);
			panel9.Controls.Add(panel11);
			panel9.Controls.Add(button_autorun_cur);
			panel9.Controls.Add(button_prev);
			panel9.Controls.Add(button_next);
			panel9.Controls.Add(button_all);
			panel9.Controls.Add(label37);
			panel9.Controls.Add(label38);
			panel9.Location = new System.Drawing.Point(5, 6);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(671, 165);
			panel9.TabIndex = 1;
			label_state.BackColor = System.Drawing.Color.White;
			label_state.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_state.Location = new System.Drawing.Point(235, 70);
			label_state.Name = "label_state";
			label_state.Size = new System.Drawing.Size(168, 30);
			label_state.TabIndex = 9;
			label_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_autosave.AutoSize = true;
			checkBox_autosave.ForeColor = System.Drawing.Color.White;
			checkBox_autosave.Location = new System.Drawing.Point(235, 45);
			checkBox_autosave.Name = "checkBox_autosave";
			checkBox_autosave.Size = new System.Drawing.Size(82, 18);
			checkBox_autosave.TabIndex = 10;
			checkBox_autosave.Text = "自动保存";
			checkBox_autosave.UseVisualStyleBackColor = true;
			checkBox_autosave.CheckedChanged += new System.EventHandler(checkBox_autosave_CheckedChanged);
			panel10.Controls.Add(numericUpDown_first_feederin);
			panel10.Controls.Add(numericUpDown_scanr);
			panel10.Controls.Add(label2);
			panel10.Controls.Add(label33);
			panel10.Controls.Add(label34);
			panel10.Location = new System.Drawing.Point(440, 106);
			panel10.Name = "panel10";
			panel10.Size = new System.Drawing.Size(198, 60);
			panel10.TabIndex = 5;
			numericUpDown_first_feederin.Location = new System.Drawing.Point(81, 30);
			numericUpDown_first_feederin.Name = "numericUpDown_first_feederin";
			numericUpDown_first_feederin.Size = new System.Drawing.Size(60, 23);
			numericUpDown_first_feederin.TabIndex = 12;
			numericUpDown_first_feederin.ValueChanged += new System.EventHandler(numericUpDown_first_feederin_ValueChanged);
			numericUpDown_scanr.Location = new System.Drawing.Point(81, 3);
			numericUpDown_scanr.Maximum = new decimal(new int[4] { 360, 0, 0, 0 });
			numericUpDown_scanr.Name = "numericUpDown_scanr";
			numericUpDown_scanr.Size = new System.Drawing.Size(60, 23);
			numericUpDown_scanr.TabIndex = 4;
			numericUpDown_scanr.Visible = false;
			numericUpDown_scanr.ValueChanged += new System.EventHandler(numericUpDown_scanr_ValueChanged);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(0, 14);
			label2.TabIndex = 3;
			label33.AutoSize = true;
			label33.Font = new System.Drawing.Font("黑体", 11f);
			label33.ForeColor = System.Drawing.Color.White;
			label33.Location = new System.Drawing.Point(3, 8);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(71, 15);
			label33.TabIndex = 3;
			label33.Text = "扫描半径";
			label33.Visible = false;
			label34.AutoSize = true;
			label34.Font = new System.Drawing.Font("黑体", 11f);
			label34.ForeColor = System.Drawing.Color.White;
			label34.Location = new System.Drawing.Point(4, 35);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(71, 15);
			label34.TabIndex = 3;
			label34.Text = "额外进料";
			label35.BackColor = System.Drawing.Color.Red;
			label35.Location = new System.Drawing.Point(16, 36);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(227, 6);
			label35.TabIndex = 7;
			panel11.Controls.Add(radioButton3);
			panel11.Controls.Add(radioButton2);
			panel11.Controls.Add(radioButton1);
			panel11.Controls.Add(label36);
			panel11.Location = new System.Drawing.Point(440, 39);
			panel11.Name = "panel11";
			panel11.Size = new System.Drawing.Size(228, 70);
			panel11.TabIndex = 2;
			radioButton3.AutoSize = true;
			radioButton3.Font = new System.Drawing.Font("黑体", 11f);
			radioButton3.ForeColor = System.Drawing.Color.White;
			radioButton3.Location = new System.Drawing.Point(84, 46);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(89, 19);
			radioButton3.TabIndex = 0;
			radioButton3.TabStop = true;
			radioButton3.Text = "透明料带";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Font = new System.Drawing.Font("黑体", 11f);
			radioButton2.ForeColor = System.Drawing.Color.White;
			radioButton2.Location = new System.Drawing.Point(84, 25);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(89, 19);
			radioButton2.TabIndex = 0;
			radioButton2.TabStop = true;
			radioButton2.Text = "黑色料带";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Font = new System.Drawing.Font("黑体", 11f);
			radioButton1.ForeColor = System.Drawing.Color.White;
			radioButton1.Location = new System.Drawing.Point(84, 4);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(89, 19);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "白色料带";
			radioButton1.UseVisualStyleBackColor = true;
			label36.AutoSize = true;
			label36.Font = new System.Drawing.Font("黑体", 11f);
			label36.ForeColor = System.Drawing.Color.White;
			label36.Location = new System.Drawing.Point(6, 6);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(71, 15);
			label36.TabIndex = 3;
			label36.Text = "料带颜色";
			label37.AutoSize = true;
			label37.Font = new System.Drawing.Font("黑体", 13f);
			label37.ForeColor = System.Drawing.Color.White;
			label37.Location = new System.Drawing.Point(485, 14);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(107, 18);
			label37.TabIndex = 0;
			label37.Text = "料站12-参数";
			label38.AutoSize = true;
			label38.Font = new System.Drawing.Font("黑体", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label38.ForeColor = System.Drawing.Color.White;
			label38.Location = new System.Drawing.Point(21, 12);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(209, 20);
			label38.TabIndex = 0;
			label38.Text = "智能自动校正取料坐标";
			label39.BackColor = System.Drawing.Color.White;
			label39.Font = new System.Drawing.Font("黑体", 12.75f);
			label39.Location = new System.Drawing.Point(750, 268);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(696, 22);
			label39.TabIndex = 0;
			label39.Text = "以下设置是全局设置，针对所有的普通飞达/托盘/振动飞达";
			label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel8.BackColor = System.Drawing.Color.White;
			panel8.Controls.Add(cnButton_saveasdefault);
			panel8.Controls.Add(cnButton_from_other_prj);
			panel8.Controls.Add(label32);
			panel8.Controls.Add(button_from_footprintlab);
			panel8.Controls.Add(button_ledcam_para);
			panel8.Controls.Add(button_from_footprintlab_view);
			panel8.Controls.Add(button_providerSetting);
			panel8.Location = new System.Drawing.Point(10, 15);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(639, 95);
			panel8.TabIndex = 86;
			button_close.BackColor = System.Drawing.Color.LightGray;
			button_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close.CnPressDownColor = System.Drawing.Color.White;
			button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
			button_close.ForeColor = System.Drawing.Color.Black;
			button_close.Location = new System.Drawing.Point(655, 15);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(32, 32);
			button_close.TabIndex = 16;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = false;
			button_close.Click += new System.EventHandler(button_close_Click_1);
			cnButton_saveasdefault.BackColor = System.Drawing.Color.Silver;
			cnButton_saveasdefault.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_saveasdefault.CnPressDownColor = System.Drawing.Color.White;
			cnButton_saveasdefault.Font = new System.Drawing.Font("黑体", 11.5f);
			cnButton_saveasdefault.Location = new System.Drawing.Point(477, 58);
			cnButton_saveasdefault.Name = "cnButton_saveasdefault";
			cnButton_saveasdefault.Size = new System.Drawing.Size(150, 28);
			cnButton_saveasdefault.TabIndex = 85;
			cnButton_saveasdefault.Text = "存为默认";
			cnButton_saveasdefault.UseVisualStyleBackColor = false;
			cnButton_from_other_prj.BackColor = System.Drawing.Color.Silver;
			cnButton_from_other_prj.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_from_other_prj.CnPressDownColor = System.Drawing.Color.White;
			cnButton_from_other_prj.Font = new System.Drawing.Font("黑体", 12f);
			cnButton_from_other_prj.Location = new System.Drawing.Point(477, 8);
			cnButton_from_other_prj.Name = "cnButton_from_other_prj";
			cnButton_from_other_prj.Size = new System.Drawing.Size(150, 48);
			cnButton_from_other_prj.TabIndex = 25;
			cnButton_from_other_prj.Text = "参数来自\r\n其他工程";
			cnButton_from_other_prj.UseVisualStyleBackColor = false;
			button_from_footprintlab.BackColor = System.Drawing.Color.Red;
			button_from_footprintlab.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_from_footprintlab.CnPressDownColor = System.Drawing.Color.White;
			button_from_footprintlab.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_from_footprintlab.FlatAppearance.BorderSize = 2;
			button_from_footprintlab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_from_footprintlab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_from_footprintlab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_from_footprintlab.Font = new System.Drawing.Font("黑体", 12f);
			button_from_footprintlab.ForeColor = System.Drawing.Color.White;
			button_from_footprintlab.Location = new System.Drawing.Point(324, 8);
			button_from_footprintlab.Name = "button_from_footprintlab";
			button_from_footprintlab.Size = new System.Drawing.Size(150, 48);
			button_from_footprintlab.TabIndex = 3;
			button_from_footprintlab.Text = "参数来自\r\n封装库";
			button_from_footprintlab.UseVisualStyleBackColor = false;
			button_from_footprintlab.Click += new System.EventHandler(button_from_footprintlab_Click);
			button_ledcam_para.BackColor = System.Drawing.Color.Red;
			button_ledcam_para.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_ledcam_para.CnPressDownColor = System.Drawing.Color.White;
			button_ledcam_para.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_ledcam_para.FlatAppearance.BorderSize = 2;
			button_ledcam_para.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_ledcam_para.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_ledcam_para.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_ledcam_para.Font = new System.Drawing.Font("黑体", 12f);
			button_ledcam_para.ForeColor = System.Drawing.Color.White;
			button_ledcam_para.Location = new System.Drawing.Point(172, 8);
			button_ledcam_para.Name = "button_ledcam_para";
			button_ledcam_para.Size = new System.Drawing.Size(150, 48);
			button_ledcam_para.TabIndex = 4;
			button_ledcam_para.Text = "相机光源\r\n参数";
			button_ledcam_para.UseVisualStyleBackColor = false;
			button_ledcam_para.Click += new System.EventHandler(button_campara_Click);
			button_from_footprintlab_view.BackColor = System.Drawing.Color.Silver;
			button_from_footprintlab_view.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_from_footprintlab_view.CnPressDownColor = System.Drawing.Color.White;
			button_from_footprintlab_view.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_from_footprintlab_view.FlatAppearance.BorderSize = 2;
			button_from_footprintlab_view.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_from_footprintlab_view.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_from_footprintlab_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_from_footprintlab_view.Font = new System.Drawing.Font("黑体", 11.5f);
			button_from_footprintlab_view.Location = new System.Drawing.Point(325, 58);
			button_from_footprintlab_view.Name = "button_from_footprintlab_view";
			button_from_footprintlab_view.Size = new System.Drawing.Size(150, 28);
			button_from_footprintlab_view.TabIndex = 3;
			button_from_footprintlab_view.Text = "刷新结果";
			button_from_footprintlab_view.UseVisualStyleBackColor = false;
			button_from_footprintlab_view.Click += new System.EventHandler(button_from_footprintlab_view_Click);
			button_providerSetting.BackColor = System.Drawing.Color.Silver;
			button_providerSetting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_providerSetting.CnPressDownColor = System.Drawing.Color.White;
			button_providerSetting.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_providerSetting.FlatAppearance.BorderSize = 2;
			button_providerSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_providerSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_providerSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_providerSetting.Font = new System.Drawing.Font("黑体", 11.5f);
			button_providerSetting.Location = new System.Drawing.Point(172, 58);
			button_providerSetting.Name = "button_providerSetting";
			button_providerSetting.Size = new System.Drawing.Size(150, 28);
			button_providerSetting.TabIndex = 3;
			button_providerSetting.Text = "特别配置";
			button_providerSetting.UseVisualStyleBackColor = false;
			button_providerSetting.Click += new System.EventHandler(button_providerSetting_Click);
			button_savepikxy.BackColor = System.Drawing.Color.Gainsboro;
			button_savepikxy.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_savepikxy.CnPressDownColor = System.Drawing.Color.White;
			button_savepikxy.Font = new System.Drawing.Font("黑体", 11.5f);
			button_savepikxy.Location = new System.Drawing.Point(319, 103);
			button_savepikxy.Name = "button_savepikxy";
			button_savepikxy.Size = new System.Drawing.Size(85, 53);
			button_savepikxy.TabIndex = 11;
			button_savepikxy.Text = "保存\r\n取料坐标";
			button_savepikxy.UseVisualStyleBackColor = false;
			button_savepikxy.Visible = false;
			button_savepikxy.Click += new System.EventHandler(button_savepikxy_Click);
			button_stop.BackColor = System.Drawing.Color.Gainsboro;
			button_stop.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stop.CnPressDownColor = System.Drawing.Color.White;
			button_stop.Font = new System.Drawing.Font("黑体", 11.5f);
			button_stop.Location = new System.Drawing.Point(235, 103);
			button_stop.Name = "button_stop";
			button_stop.Size = new System.Drawing.Size(78, 53);
			button_stop.TabIndex = 8;
			button_stop.Text = "停止";
			button_stop.UseVisualStyleBackColor = false;
			button_stop.Visible = false;
			button_stop.Click += new System.EventHandler(button_stop_Click);
			button_autopik_close.BackColor = System.Drawing.Color.LightGray;
			button_autopik_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_autopik_close.CnPressDownColor = System.Drawing.Color.White;
			button_autopik_close.Font = new System.Drawing.Font("MS Reference Sans Serif", 12f);
			button_autopik_close.Location = new System.Drawing.Point(634, 3);
			button_autopik_close.Name = "button_autopik_close";
			button_autopik_close.Size = new System.Drawing.Size(32, 32);
			button_autopik_close.TabIndex = 6;
			button_autopik_close.Text = "X";
			button_autopik_close.UseVisualStyleBackColor = false;
			button_autopik_close.Click += new System.EventHandler(button_autopik_close_Click);
			button_autorun_cur.BackColor = System.Drawing.Color.WhiteSmoke;
			button_autorun_cur.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_autorun_cur.CnPressDownColor = System.Drawing.Color.White;
			button_autorun_cur.Font = new System.Drawing.Font("黑体", 12.5f);
			button_autorun_cur.Location = new System.Drawing.Point(70, 49);
			button_autorun_cur.Name = "button_autorun_cur";
			button_autorun_cur.Size = new System.Drawing.Size(160, 51);
			button_autorun_cur.TabIndex = 1;
			button_autorun_cur.Text = "校正\r\n料站12";
			button_autorun_cur.UseVisualStyleBackColor = false;
			button_autorun_cur.Click += new System.EventHandler(button_autorun_cur_Click);
			button_prev.BackColor = System.Drawing.Color.WhiteSmoke;
			button_prev.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_prev.CnPressDownColor = System.Drawing.Color.White;
			button_prev.Font = new System.Drawing.Font("黑体", 11.5f);
			button_prev.Location = new System.Drawing.Point(70, 103);
			button_prev.Name = "button_prev";
			button_prev.Size = new System.Drawing.Size(78, 53);
			button_prev.TabIndex = 1;
			button_prev.Tag = "prev";
			button_prev.Text = "校正\r\n上一个";
			button_prev.UseVisualStyleBackColor = false;
			button_prev.Click += new System.EventHandler(button_prev_Click);
			button_next.BackColor = System.Drawing.Color.WhiteSmoke;
			button_next.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_next.CnPressDownColor = System.Drawing.Color.White;
			button_next.Font = new System.Drawing.Font("黑体", 11.5f);
			button_next.Location = new System.Drawing.Point(152, 103);
			button_next.Name = "button_next";
			button_next.Size = new System.Drawing.Size(78, 53);
			button_next.TabIndex = 1;
			button_next.Tag = "next";
			button_next.Text = "校正\r\n下一个";
			button_next.UseVisualStyleBackColor = false;
			button_next.Click += new System.EventHandler(button_prev_Click);
			button_all.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Disable;
			button_all.CnPressDownColor = System.Drawing.Color.White;
			button_all.Enabled = false;
			button_all.Font = new System.Drawing.Font("黑体", 12.5f);
			button_all.Location = new System.Drawing.Point(15, 49);
			button_all.Name = "button_all";
			button_all.Size = new System.Drawing.Size(53, 107);
			button_all.TabIndex = 1;
			button_all.Text = "校正\r\n全部";
			button_all.UseVisualStyleBackColor = true;
			button_delSubPlate.BackColor = System.Drawing.Color.Silver;
			button_delSubPlate.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_delSubPlate.CnPressDownColor = System.Drawing.Color.White;
			button_delSubPlate.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_delSubPlate.Location = new System.Drawing.Point(138, 1);
			button_delSubPlate.Name = "button_delSubPlate";
			button_delSubPlate.Size = new System.Drawing.Size(125, 28);
			button_delSubPlate.TabIndex = 0;
			button_delSubPlate.Text = "删除子料盘";
			button_delSubPlate.UseVisualStyleBackColor = false;
			button_delSubPlate.Click += new System.EventHandler(button_delSubPlate_Click);
			button_addSubPlate.BackColor = System.Drawing.Color.Silver;
			button_addSubPlate.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_addSubPlate.CnPressDownColor = System.Drawing.Color.White;
			button_addSubPlate.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_addSubPlate.Location = new System.Drawing.Point(11, 1);
			button_addSubPlate.Name = "button_addSubPlate";
			button_addSubPlate.Size = new System.Drawing.Size(125, 28);
			button_addSubPlate.TabIndex = 0;
			button_addSubPlate.Text = "添加子料盘";
			button_addSubPlate.UseVisualStyleBackColor = false;
			button_addSubPlate.Click += new System.EventHandler(button_addSubPlate_Click);
			button_stackplateXY_moveto_byZn.BackColor = System.Drawing.Color.Silver;
			button_stackplateXY_moveto_byZn.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackplateXY_moveto_byZn.CnPressDownColor = System.Drawing.Color.White;
			button_stackplateXY_moveto_byZn.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_stackplateXY_moveto_byZn.Location = new System.Drawing.Point(441, 179);
			button_stackplateXY_moveto_byZn.Name = "button_stackplateXY_moveto_byZn";
			button_stackplateXY_moveto_byZn.Size = new System.Drawing.Size(91, 28);
			button_stackplateXY_moveto_byZn.TabIndex = 78;
			button_stackplateXY_moveto_byZn.Text = "吸嘴定位";
			button_stackplateXY_moveto_byZn.UseVisualStyleBackColor = false;
			button_stackplateXY_moveto_byZn.Click += new System.EventHandler(button_stackplateXY_moveto_byZn_Click);
			button_platexy_close.BackColor = System.Drawing.Color.LightGray;
			button_platexy_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_platexy_close.CnPressDownColor = System.Drawing.Color.White;
			button_platexy_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
			button_platexy_close.Location = new System.Drawing.Point(518, 3);
			button_platexy_close.Name = "button_platexy_close";
			button_platexy_close.Size = new System.Drawing.Size(28, 28);
			button_platexy_close.TabIndex = 77;
			button_platexy_close.Text = "X";
			button_platexy_close.UseVisualStyleBackColor = false;
			button_platexy_close.Click += new System.EventHandler(button_platexy_close_Click);
			button_stackplateGenXYlist.BackColor = System.Drawing.Color.Silver;
			button_stackplateGenXYlist.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackplateGenXYlist.CnPressDownColor = System.Drawing.Color.White;
			button_stackplateGenXYlist.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_stackplateGenXYlist.Location = new System.Drawing.Point(172, 105);
			button_stackplateGenXYlist.Name = "button_stackplateGenXYlist";
			button_stackplateGenXYlist.Size = new System.Drawing.Size(91, 45);
			button_stackplateGenXYlist.TabIndex = 75;
			button_stackplateGenXYlist.Text = "生成\r\n取料坐标";
			button_stackplateGenXYlist.UseVisualStyleBackColor = false;
			button_stackplateGenXYlist.Click += new System.EventHandler(button_stackplateGenXYlist_Click);
			button_stackplateSaveXYS.BackColor = System.Drawing.Color.Silver;
			button_stackplateSaveXYS.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackplateSaveXYS.CnPressDownColor = System.Drawing.Color.White;
			button_stackplateSaveXYS.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_stackplateSaveXYS.Location = new System.Drawing.Point(122, 105);
			button_stackplateSaveXYS.Name = "button_stackplateSaveXYS";
			button_stackplateSaveXYS.Size = new System.Drawing.Size(48, 45);
			button_stackplateSaveXYS.TabIndex = 24;
			button_stackplateSaveXYS.Text = "保存";
			button_stackplateSaveXYS.UseVisualStyleBackColor = false;
			button_stackplateSaveXYS.Click += new System.EventHandler(button_stackplateSaveXYS_Click);
			button_stackplateMoveToXYS.BackColor = System.Drawing.Color.Silver;
			button_stackplateMoveToXYS.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackplateMoveToXYS.CnPressDownColor = System.Drawing.Color.White;
			button_stackplateMoveToXYS.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_stackplateMoveToXYS.Location = new System.Drawing.Point(72, 105);
			button_stackplateMoveToXYS.Name = "button_stackplateMoveToXYS";
			button_stackplateMoveToXYS.Size = new System.Drawing.Size(48, 45);
			button_stackplateMoveToXYS.TabIndex = 25;
			button_stackplateMoveToXYS.Text = "定位";
			button_stackplateMoveToXYS.UseVisualStyleBackColor = false;
			button_stackplateMoveToXYS.Click += new System.EventHandler(button_stackplateMoveToXYS_Click);
			button_stackplateXY_moveto.BackColor = System.Drawing.Color.Silver;
			button_stackplateXY_moveto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackplateXY_moveto.CnPressDownColor = System.Drawing.Color.White;
			button_stackplateXY_moveto.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_stackplateXY_moveto.Location = new System.Drawing.Point(344, 179);
			button_stackplateXY_moveto.Name = "button_stackplateXY_moveto";
			button_stackplateXY_moveto.Size = new System.Drawing.Size(91, 28);
			button_stackplateXY_moveto.TabIndex = 1;
			button_stackplateXY_moveto.Text = "定位XY";
			button_stackplateXY_moveto.UseVisualStyleBackColor = false;
			button_stackplateXY_moveto.Click += new System.EventHandler(button_stackplateXY_moveto_Click);
			button2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button2.CnPressDownColor = System.Drawing.Color.White;
			button2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button2.Location = new System.Drawing.Point(1289, 123);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(49, 43);
			button2.TabIndex = 3;
			button2.Text = "视图";
			button2.UseVisualStyleBackColor = true;
			button_closefeeder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_closefeeder.CnPressDownColor = System.Drawing.Color.White;
			button_closefeeder.Font = new System.Drawing.Font("黑体", 12.5f);
			button_closefeeder.Location = new System.Drawing.Point(733, 134);
			button_closefeeder.Name = "button_closefeeder";
			button_closefeeder.Size = new System.Drawing.Size(70, 49);
			button_closefeeder.TabIndex = 3;
			button_closefeeder.Text = "关飞达";
			button_closefeeder.UseVisualStyleBackColor = true;
			button_closefeeder.Click += new System.EventHandler(button_closefeeder_Click);
			button_campara.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_campara.CnPressDownColor = System.Drawing.Color.White;
			button_campara.Location = new System.Drawing.Point(1290, 50);
			button_campara.Name = "button_campara";
			button_campara.Size = new System.Drawing.Size(77, 29);
			button_campara.TabIndex = 3;
			button_campara.Text = "相机光源";
			button_campara.UseVisualStyleBackColor = true;
			button_campara.Visible = false;
			button_campara.Click += new System.EventHandler(button_campara_Click);
			button_stackplateXY_update.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			button_stackplateXY_update.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackplateXY_update.CnPressDownColor = System.Drawing.Color.White;
			button_stackplateXY_update.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_stackplateXY_update.Location = new System.Drawing.Point(989, 214);
			button_stackplateXY_update.Name = "button_stackplateXY_update";
			button_stackplateXY_update.Size = new System.Drawing.Size(76, 28);
			button_stackplateXY_update.TabIndex = 1;
			button_stackplateXY_update.Text = "更新XY";
			button_stackplateXY_update.UseVisualStyleBackColor = false;
			button_stackplateXY_update.Visible = false;
			button_stackplateXY_update.Click += new System.EventHandler(button_stackplateXY_update_Click);
			button_hcam_specialpara.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_hcam_specialpara.CnPressDownColor = System.Drawing.Color.White;
			button_hcam_specialpara.Location = new System.Drawing.Point(1289, 17);
			button_hcam_specialpara.Name = "button_hcam_specialpara";
			button_hcam_specialpara.Size = new System.Drawing.Size(78, 25);
			button_hcam_specialpara.TabIndex = 2;
			button_hcam_specialpara.Text = "设置";
			button_hcam_specialpara.UseVisualStyleBackColor = true;
			button_hcam_specialpara.Visible = false;
			button_hcam_specialpara.Click += new System.EventHandler(button_hcam_specialpara_Click);
			button_mntH_Goto.BackColor = System.Drawing.Color.Silver;
			button_mntH_Goto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mntH_Goto.CnPressDownColor = System.Drawing.Color.White;
			button_mntH_Goto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_mntH_Goto.FlatAppearance.BorderSize = 2;
			button_mntH_Goto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_mntH_Goto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_mntH_Goto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_mntH_Goto.Location = new System.Drawing.Point(1108, 224);
			button_mntH_Goto.Name = "button_mntH_Goto";
			button_mntH_Goto.Size = new System.Drawing.Size(78, 25);
			button_mntH_Goto.TabIndex = 2;
			button_mntH_Goto.Tag = "mnt";
			button_mntH_Goto.Text = "定位";
			button_mntH_Goto.UseVisualStyleBackColor = false;
			button_mntH_Goto.Click += new System.EventHandler(button_pikH_Goto_Click);
			button_pikH_Goto.BackColor = System.Drawing.Color.Silver;
			button_pikH_Goto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pikH_Goto.CnPressDownColor = System.Drawing.Color.White;
			button_pikH_Goto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_pikH_Goto.FlatAppearance.BorderSize = 2;
			button_pikH_Goto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_pikH_Goto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_pikH_Goto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_pikH_Goto.Location = new System.Drawing.Point(1108, 172);
			button_pikH_Goto.Name = "button_pikH_Goto";
			button_pikH_Goto.Size = new System.Drawing.Size(78, 25);
			button_pikH_Goto.TabIndex = 2;
			button_pikH_Goto.Tag = "pik";
			button_pikH_Goto.Text = "定位";
			button_pikH_Goto.UseVisualStyleBackColor = false;
			button_pikH_Goto.Click += new System.EventHandler(button_pikH_Goto_Click);
			button_mntH_Save.BackColor = System.Drawing.Color.Silver;
			button_mntH_Save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mntH_Save.CnPressDownColor = System.Drawing.Color.White;
			button_mntH_Save.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_mntH_Save.FlatAppearance.BorderSize = 2;
			button_mntH_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_mntH_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_mntH_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_mntH_Save.Location = new System.Drawing.Point(1192, 224);
			button_mntH_Save.Name = "button_mntH_Save";
			button_mntH_Save.Size = new System.Drawing.Size(78, 25);
			button_mntH_Save.TabIndex = 2;
			button_mntH_Save.Tag = "mnt";
			button_mntH_Save.Text = "保存高度";
			button_mntH_Save.UseVisualStyleBackColor = false;
			button_mntH_Save.Click += new System.EventHandler(button_pikH_Save_Click);
			button_pikH_Save.BackColor = System.Drawing.Color.Silver;
			button_pikH_Save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pikH_Save.CnPressDownColor = System.Drawing.Color.White;
			button_pikH_Save.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_pikH_Save.FlatAppearance.BorderSize = 2;
			button_pikH_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_pikH_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_pikH_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_pikH_Save.Location = new System.Drawing.Point(1192, 172);
			button_pikH_Save.Name = "button_pikH_Save";
			button_pikH_Save.Size = new System.Drawing.Size(78, 25);
			button_pikH_Save.TabIndex = 2;
			button_pikH_Save.Tag = "pik";
			button_pikH_Save.Text = "保存高度";
			button_pikH_Save.UseVisualStyleBackColor = false;
			button_pikH_Save.Click += new System.EventHandler(button_pikH_Save_Click);
			button_mntH_View.BackColor = System.Drawing.Color.Silver;
			button_mntH_View.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mntH_View.CnPressDownColor = System.Drawing.Color.White;
			button_mntH_View.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_mntH_View.FlatAppearance.BorderSize = 2;
			button_mntH_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_mntH_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_mntH_View.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_mntH_View.Location = new System.Drawing.Point(1192, 198);
			button_mntH_View.Name = "button_mntH_View";
			button_mntH_View.Size = new System.Drawing.Size(78, 25);
			button_mntH_View.TabIndex = 2;
			button_mntH_View.Tag = "mnt";
			button_mntH_View.Text = "查看高度";
			button_mntH_View.UseVisualStyleBackColor = false;
			button_mntH_View.Click += new System.EventHandler(button_mntH_View_Click);
			button_pikH_View.BackColor = System.Drawing.Color.Silver;
			button_pikH_View.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pikH_View.CnPressDownColor = System.Drawing.Color.White;
			button_pikH_View.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_pikH_View.FlatAppearance.BorderSize = 2;
			button_pikH_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_pikH_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_pikH_View.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_pikH_View.Location = new System.Drawing.Point(1192, 146);
			button_pikH_View.Name = "button_pikH_View";
			button_pikH_View.Size = new System.Drawing.Size(78, 25);
			button_pikH_View.TabIndex = 2;
			button_pikH_View.Tag = "pik";
			button_pikH_View.Text = "查看高度";
			button_pikH_View.UseVisualStyleBackColor = false;
			button_pikH_View.Click += new System.EventHandler(button_pikH_View_Click);
			button_mntH_Offset_Sync.BackColor = System.Drawing.Color.Silver;
			button_mntH_Offset_Sync.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mntH_Offset_Sync.CnPressDownColor = System.Drawing.Color.White;
			button_mntH_Offset_Sync.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_mntH_Offset_Sync.FlatAppearance.BorderSize = 2;
			button_mntH_Offset_Sync.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_mntH_Offset_Sync.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_mntH_Offset_Sync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_mntH_Offset_Sync.Location = new System.Drawing.Point(1108, 198);
			button_mntH_Offset_Sync.Name = "button_mntH_Offset_Sync";
			button_mntH_Offset_Sync.Size = new System.Drawing.Size(78, 25);
			button_mntH_Offset_Sync.TabIndex = 2;
			button_mntH_Offset_Sync.Text = "同步";
			button_mntH_Offset_Sync.UseVisualStyleBackColor = false;
			button_mntH_Offset_Sync.Click += new System.EventHandler(button_stacknew_Hpara_synctoAllZn_Click);
			button_pikH_Offset_Sync.BackColor = System.Drawing.Color.Silver;
			button_pikH_Offset_Sync.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pikH_Offset_Sync.CnPressDownColor = System.Drawing.Color.White;
			button_pikH_Offset_Sync.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_pikH_Offset_Sync.FlatAppearance.BorderSize = 2;
			button_pikH_Offset_Sync.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_pikH_Offset_Sync.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_pikH_Offset_Sync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_pikH_Offset_Sync.Location = new System.Drawing.Point(1108, 146);
			button_pikH_Offset_Sync.Name = "button_pikH_Offset_Sync";
			button_pikH_Offset_Sync.Size = new System.Drawing.Size(78, 25);
			button_pikH_Offset_Sync.TabIndex = 2;
			button_pikH_Offset_Sync.Text = "同步";
			button_pikH_Offset_Sync.UseVisualStyleBackColor = false;
			button_pikH_Offset_Sync.Click += new System.EventHandler(button_stacknew_Hpara_synctoAllZn_Click);
			cnButton_stackplate_startIndex.BackColor = System.Drawing.Color.Silver;
			cnButton_stackplate_startIndex.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_stackplate_startIndex.CnPressDownColor = System.Drawing.Color.White;
			cnButton_stackplate_startIndex.Font = new System.Drawing.Font("黑体", 11.5f);
			cnButton_stackplate_startIndex.Location = new System.Drawing.Point(577, 78);
			cnButton_stackplate_startIndex.Name = "cnButton_stackplate_startIndex";
			cnButton_stackplate_startIndex.Size = new System.Drawing.Size(228, 40);
			cnButton_stackplate_startIndex.TabIndex = 24;
			cnButton_stackplate_startIndex.Text = "起始索引 1-1";
			cnButton_stackplate_startIndex.UseVisualStyleBackColor = false;
			cnButton_stackplate_startIndex.Click += new System.EventHandler(button_stackplate_startIndex_Click);
			button_reback.BackColor = System.Drawing.Color.Silver;
			button_reback.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_reback.CnPressDownColor = System.Drawing.Color.White;
			button_reback.Enabled = false;
			button_reback.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_reback.FlatAppearance.BorderSize = 2;
			button_reback.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_reback.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_reback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_reback.Font = new System.Drawing.Font("黑体", 11.5f);
			button_reback.Location = new System.Drawing.Point(211, 585);
			button_reback.Name = "button_reback";
			button_reback.Size = new System.Drawing.Size(88, 32);
			button_reback.TabIndex = 3;
			button_reback.Text = "放回";
			button_reback.UseVisualStyleBackColor = false;
			button_reback.Click += new System.EventHandler(button_reback_Click);
			button_goto_pikxy_byNozzle.BackColor = System.Drawing.Color.LightGray;
			button_goto_pikxy_byNozzle.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_goto_pikxy_byNozzle.CnPressDownColor = System.Drawing.Color.White;
			button_goto_pikxy_byNozzle.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_goto_pikxy_byNozzle.FlatAppearance.BorderSize = 2;
			button_goto_pikxy_byNozzle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_goto_pikxy_byNozzle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_goto_pikxy_byNozzle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_goto_pikxy_byNozzle.Font = new System.Drawing.Font("黑体", 11f);
			button_goto_pikxy_byNozzle.Location = new System.Drawing.Point(155, 2);
			button_goto_pikxy_byNozzle.Name = "button_goto_pikxy_byNozzle";
			button_goto_pikxy_byNozzle.Size = new System.Drawing.Size(167, 28);
			button_goto_pikxy_byNozzle.TabIndex = 3;
			button_goto_pikxy_byNozzle.Tag = "1";
			button_goto_pikxy_byNozzle.Text = "吸嘴定位取料坐标";
			button_goto_pikxy_byNozzle.UseVisualStyleBackColor = false;
			button_goto_pikxy_byNozzle.Click += new System.EventHandler(button_stackMoveToXY_Click);
			button_pikBaseH.BackColor = System.Drawing.Color.Red;
			button_pikBaseH.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pikBaseH.CnPressDownColor = System.Drawing.Color.White;
			button_pikBaseH.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_pikBaseH.FlatAppearance.BorderSize = 2;
			button_pikBaseH.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_pikBaseH.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_pikBaseH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_pikBaseH.ForeColor = System.Drawing.Color.White;
			button_pikBaseH.Location = new System.Drawing.Point(329, 2);
			button_pikBaseH.Name = "button_pikBaseH";
			button_pikBaseH.Size = new System.Drawing.Size(131, 29);
			button_pikBaseH.TabIndex = 3;
			button_pikBaseH.Text = "托盘基准高度";
			button_pikBaseH.UseVisualStyleBackColor = false;
			button_pikBaseH.Click += new System.EventHandler(button_pikBaseH_Click);
			button_curdefault.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_curdefault.CnPressDownColor = System.Drawing.Color.White;
			button_curdefault.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_curdefault.FlatAppearance.BorderSize = 2;
			button_curdefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_curdefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_curdefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_curdefault.Font = new System.Drawing.Font("黑体", 10.5f);
			button_curdefault.Location = new System.Drawing.Point(619, 71);
			button_curdefault.Name = "button_curdefault";
			button_curdefault.Size = new System.Drawing.Size(80, 30);
			button_curdefault.TabIndex = 4;
			button_curdefault.Text = "默认参数";
			button_curdefault.UseVisualStyleBackColor = true;
			button_curdefault.Visible = false;
			button_curdefault.Click += new System.EventHandler(button_curdefault_Click);
			button_autoPixXY.BackColor = System.Drawing.Color.Silver;
			button_autoPixXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_autoPixXY.CnPressDownColor = System.Drawing.Color.White;
			button_autoPixXY.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_autoPixXY.FlatAppearance.BorderSize = 2;
			button_autoPixXY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_autoPixXY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_autoPixXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_autoPixXY.Font = new System.Drawing.Font("黑体", 12.5f);
			button_autoPixXY.Location = new System.Drawing.Point(93, 53);
			button_autoPixXY.Name = "button_autoPixXY";
			button_autoPixXY.Size = new System.Drawing.Size(294, 57);
			button_autoPixXY.TabIndex = 0;
			button_autoPixXY.Text = "智能辅助自动校正取料坐标";
			button_autoPixXY.UseVisualStyleBackColor = false;
			button_autoPixXY.Click += new System.EventHandler(button_autoPixXY_Click);
			button_openfeeder.BackColor = System.Drawing.Color.Silver;
			button_openfeeder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_openfeeder.CnPressDownColor = System.Drawing.Color.White;
			button_openfeeder.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_openfeeder.FlatAppearance.BorderSize = 2;
			button_openfeeder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_openfeeder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_openfeeder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_openfeeder.Font = new System.Drawing.Font("黑体", 11.5f);
			button_openfeeder.Location = new System.Drawing.Point(5, 53);
			button_openfeeder.Name = "button_openfeeder";
			button_openfeeder.Size = new System.Drawing.Size(85, 57);
			button_openfeeder.TabIndex = 3;
			button_openfeeder.Text = "开飞达";
			button_openfeeder.UseVisualStyleBackColor = false;
			button_openfeeder.Click += new System.EventHandler(button_openfeeder_Click);
			button_openfeeder.MouseDown += new System.Windows.Forms.MouseEventHandler(button_openfeeder_MouseDown);
			button_footprint.BackColor = System.Drawing.Color.Red;
			button_footprint.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_footprint.CnPressDownColor = System.Drawing.Color.White;
			button_footprint.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_footprint.FlatAppearance.BorderSize = 2;
			button_footprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_footprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_footprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_footprint.Font = new System.Drawing.Font("黑体", 12f);
			button_footprint.ForeColor = System.Drawing.Color.White;
			button_footprint.Location = new System.Drawing.Point(462, 3);
			button_footprint.Name = "button_footprint";
			button_footprint.Size = new System.Drawing.Size(106, 34);
			button_footprint.TabIndex = 0;
			button_footprint.Text = "封装库";
			button_footprint.UseVisualStyleBackColor = false;
			button_footprint.Click += new System.EventHandler(button_footprint_Click);
			button_stackSaveXY.BackColor = System.Drawing.Color.Silver;
			button_stackSaveXY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_stackSaveXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackSaveXY.CnPressDownColor = System.Drawing.Color.White;
			button_stackSaveXY.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_stackSaveXY.FlatAppearance.BorderSize = 2;
			button_stackSaveXY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_stackSaveXY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_stackSaveXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_stackSaveXY.Font = new System.Drawing.Font("黑体", 11f);
			button_stackSaveXY.Location = new System.Drawing.Point(238, 2);
			button_stackSaveXY.Name = "button_stackSaveXY";
			button_stackSaveXY.Size = new System.Drawing.Size(85, 48);
			button_stackSaveXY.TabIndex = 7;
			button_stackSaveXY.Text = "保存\r\n取料坐标";
			button_stackSaveXY.UseVisualStyleBackColor = false;
			button_stackSaveXY.Click += new System.EventHandler(button_stackSaveXY_Click);
			button_stackMoveToXY.BackColor = System.Drawing.Color.Silver;
			button_stackMoveToXY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_stackMoveToXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackMoveToXY.CnPressDownColor = System.Drawing.Color.White;
			button_stackMoveToXY.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_stackMoveToXY.FlatAppearance.BorderSize = 2;
			button_stackMoveToXY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_stackMoveToXY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_stackMoveToXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_stackMoveToXY.Font = new System.Drawing.Font("黑体", 11f);
			button_stackMoveToXY.Location = new System.Drawing.Point(4, 2);
			button_stackMoveToXY.Name = "button_stackMoveToXY";
			button_stackMoveToXY.Size = new System.Drawing.Size(85, 48);
			button_stackMoveToXY.TabIndex = 7;
			button_stackMoveToXY.Tag = "0";
			button_stackMoveToXY.Text = "定位\r\n取料坐标";
			button_stackMoveToXY.UseVisualStyleBackColor = false;
			button_stackMoveToXY.Click += new System.EventHandler(button_stackMoveToXY_Click);
			button_gotoPrevStack.BackColor = System.Drawing.Color.Silver;
			button_gotoPrevStack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_gotoPrevStack.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_gotoPrevStack.CnPressDownColor = System.Drawing.Color.White;
			button_gotoPrevStack.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_gotoPrevStack.FlatAppearance.BorderSize = 2;
			button_gotoPrevStack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_gotoPrevStack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_gotoPrevStack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_gotoPrevStack.Font = new System.Drawing.Font("黑体", 11f);
			button_gotoPrevStack.Location = new System.Drawing.Point(92, 2);
			button_gotoPrevStack.Name = "button_gotoPrevStack";
			button_gotoPrevStack.Size = new System.Drawing.Size(70, 48);
			button_gotoPrevStack.TabIndex = 7;
			button_gotoPrevStack.Tag = "prev";
			button_gotoPrevStack.Text = "←定位";
			button_gotoPrevStack.UseVisualStyleBackColor = false;
			button_gotoPrevStack.Click += new System.EventHandler(button_gotoNextStack_Click);
			button_gotoNextStack.BackColor = System.Drawing.Color.Silver;
			button_gotoNextStack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_gotoNextStack.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_gotoNextStack.CnPressDownColor = System.Drawing.Color.White;
			button_gotoNextStack.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_gotoNextStack.FlatAppearance.BorderSize = 2;
			button_gotoNextStack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_gotoNextStack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_gotoNextStack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_gotoNextStack.Font = new System.Drawing.Font("黑体", 11f);
			button_gotoNextStack.Location = new System.Drawing.Point(165, 2);
			button_gotoNextStack.Name = "button_gotoNextStack";
			button_gotoNextStack.Size = new System.Drawing.Size(70, 48);
			button_gotoNextStack.TabIndex = 7;
			button_gotoNextStack.Tag = "next";
			button_gotoNextStack.Text = "定位→";
			button_gotoNextStack.UseVisualStyleBackColor = false;
			button_gotoNextStack.Click += new System.EventHandler(button_gotoNextStack_Click);
			button_EnableNozzle.BackColor = System.Drawing.Color.Silver;
			button_EnableNozzle.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_EnableNozzle.CnPressDownColor = System.Drawing.Color.White;
			button_EnableNozzle.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_EnableNozzle.FlatAppearance.BorderSize = 2;
			button_EnableNozzle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_EnableNozzle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_EnableNozzle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_EnableNozzle.Font = new System.Drawing.Font("黑体", 12f);
			button_EnableNozzle.Location = new System.Drawing.Point(462, 75);
			button_EnableNozzle.Name = "button_EnableNozzle";
			button_EnableNozzle.Size = new System.Drawing.Size(106, 34);
			button_EnableNozzle.TabIndex = 12;
			button_EnableNozzle.Text = "启用吸嘴";
			button_EnableNozzle.UseVisualStyleBackColor = false;
			button_EnableNozzle.Click += new System.EventHandler(button_EnableNozzle_Click);
			button_stackCopy.BackColor = System.Drawing.Color.Silver;
			button_stackCopy.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stackCopy.CnPressDownColor = System.Drawing.Color.White;
			button_stackCopy.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_stackCopy.FlatAppearance.BorderSize = 2;
			button_stackCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_stackCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_stackCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_stackCopy.Font = new System.Drawing.Font("黑体", 12f);
			button_stackCopy.Location = new System.Drawing.Point(462, 39);
			button_stackCopy.Name = "button_stackCopy";
			button_stackCopy.Size = new System.Drawing.Size(106, 34);
			button_stackCopy.TabIndex = 3;
			button_stackCopy.Text = "批量复制";
			button_stackCopy.UseVisualStyleBackColor = false;
			button_stackCopy.Click += new System.EventHandler(button_stackCopy_Click);
			button_close_enableZn.BackColor = System.Drawing.Color.LightGray;
			button_close_enableZn.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_enableZn.CnPressDownColor = System.Drawing.Color.White;
			button_close_enableZn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			button_close_enableZn.Location = new System.Drawing.Point(640, 4);
			button_close_enableZn.Name = "button_close_enableZn";
			button_close_enableZn.Size = new System.Drawing.Size(30, 30);
			button_close_enableZn.TabIndex = 2;
			button_close_enableZn.Text = "X";
			button_close_enableZn.UseVisualStyleBackColor = false;
			button_close_enableZn.Click += new System.EventHandler(button_close_enableZn_Click);
			button_stacksel_feeder.BackColor = System.Drawing.Color.SteelBlue;
			button_stacksel_feeder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.PressRadio;
			button_stacksel_feeder.CnPressDownColor = System.Drawing.Color.White;
			button_stacksel_feeder.Font = new System.Drawing.Font("黑体", 13f);
			button_stacksel_feeder.ForeColor = System.Drawing.Color.White;
			button_stacksel_feeder.Location = new System.Drawing.Point(1, 24);
			button_stacksel_feeder.Name = "button_stacksel_feeder";
			button_stacksel_feeder.Size = new System.Drawing.Size(130, 36);
			button_stacksel_feeder.TabIndex = 3;
			button_stacksel_feeder.Text = "普通飞达";
			button_stacksel_feeder.UseVisualStyleBackColor = false;
			button_stacksel_plate.BackColor = System.Drawing.Color.SteelBlue;
			button_stacksel_plate.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.PressRadio;
			button_stacksel_plate.CnPressDownColor = System.Drawing.Color.White;
			button_stacksel_plate.Font = new System.Drawing.Font("黑体", 13f);
			button_stacksel_plate.ForeColor = System.Drawing.Color.White;
			button_stacksel_plate.Location = new System.Drawing.Point(134, 24);
			button_stacksel_plate.Name = "button_stacksel_plate";
			button_stacksel_plate.Size = new System.Drawing.Size(130, 36);
			button_stacksel_plate.TabIndex = 3;
			button_stacksel_plate.Text = "托盘料盘";
			button_stacksel_plate.UseVisualStyleBackColor = false;
			button_stacksel_vibra.BackColor = System.Drawing.Color.SteelBlue;
			button_stacksel_vibra.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.PressRadio;
			button_stacksel_vibra.CnPressDownColor = System.Drawing.Color.White;
			button_stacksel_vibra.Font = new System.Drawing.Font("黑体", 13f);
			button_stacksel_vibra.ForeColor = System.Drawing.Color.White;
			button_stacksel_vibra.Location = new System.Drawing.Point(267, 24);
			button_stacksel_vibra.Name = "button_stacksel_vibra";
			button_stacksel_vibra.Size = new System.Drawing.Size(130, 36);
			button_stacksel_vibra.TabIndex = 3;
			button_stacksel_vibra.Text = "振动飞达";
			button_stacksel_vibra.UseVisualStyleBackColor = false;
			button_mntBaseH.BackColor = System.Drawing.Color.LightGray;
			button_mntBaseH.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mntBaseH.CnPressDownColor = System.Drawing.Color.White;
			button_mntBaseH.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_mntBaseH.FlatAppearance.BorderSize = 2;
			button_mntBaseH.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_mntBaseH.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_mntBaseH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_mntBaseH.Location = new System.Drawing.Point(149, 3);
			button_mntBaseH.Name = "button_mntBaseH";
			button_mntBaseH.Size = new System.Drawing.Size(131, 29);
			button_mntBaseH.TabIndex = 3;
			button_mntBaseH.Text = "PCB基准高度";
			button_mntBaseH.UseVisualStyleBackColor = false;
			button_mntBaseH.Visible = false;
			button_visualrunning.BackColor = System.Drawing.Color.Silver;
			button_visualrunning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_visualrunning.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_visualrunning.CnPressDownColor = System.Drawing.Color.White;
			button_visualrunning.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_visualrunning.FlatAppearance.BorderSize = 2;
			button_visualrunning.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_visualrunning.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_visualrunning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_visualrunning.Font = new System.Drawing.Font("黑体", 12f);
			button_visualrunning.Location = new System.Drawing.Point(145, 6);
			button_visualrunning.Name = "button_visualrunning";
			button_visualrunning.Size = new System.Drawing.Size(60, 75);
			button_visualrunning.TabIndex = 2;
			button_visualrunning.Text = "实时\r\n视觉";
			button_visualrunning.UseVisualStyleBackColor = false;
			button_visualrunning.Click += new System.EventHandler(button_visualrunning_Click);
			button_visualtest2.BackColor = System.Drawing.Color.Silver;
			button_visualtest2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_visualtest2.CnPressDownColor = System.Drawing.Color.White;
			button_visualtest2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_visualtest2.FlatAppearance.BorderSize = 2;
			button_visualtest2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_visualtest2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_visualtest2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_visualtest2.Font = new System.Drawing.Font("黑体", 11.5f);
			button_visualtest2.Location = new System.Drawing.Point(207, 44);
			button_visualtest2.Name = "button_visualtest2";
			button_visualtest2.Size = new System.Drawing.Size(88, 37);
			button_visualtest2.TabIndex = 3;
			button_visualtest2.Text = "识别测试";
			button_visualtest2.UseVisualStyleBackColor = false;
			button_visualtest2.Click += new System.EventHandler(button_visualtest2_Click);
			button_collect.BackColor = System.Drawing.Color.Silver;
			button_collect.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_collect.CnPressDownColor = System.Drawing.Color.White;
			button_collect.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_collect.FlatAppearance.BorderSize = 2;
			button_collect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_collect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_collect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_collect.Font = new System.Drawing.Font("黑体", 11.5f);
			button_collect.Location = new System.Drawing.Point(207, 6);
			button_collect.Name = "button_collect";
			button_collect.Size = new System.Drawing.Size(88, 37);
			button_collect.TabIndex = 2;
			button_collect.Text = "采集尺寸";
			button_collect.UseVisualStyleBackColor = false;
			button_collect.Click += new System.EventHandler(button_collect_Click);
			button_PikToHighCam.BackColor = System.Drawing.Color.Silver;
			button_PikToHighCam.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PikToHighCam.CnPressDownColor = System.Drawing.Color.White;
			button_PikToHighCam.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_PikToHighCam.FlatAppearance.BorderSize = 2;
			button_PikToHighCam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_PikToHighCam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_PikToHighCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_PikToHighCam.Font = new System.Drawing.Font("黑体", 11.5f);
			button_PikToHighCam.Location = new System.Drawing.Point(8, 44);
			button_PikToHighCam.Name = "button_PikToHighCam";
			button_PikToHighCam.Size = new System.Drawing.Size(135, 37);
			button_PikToHighCam.TabIndex = 3;
			button_PikToHighCam.Tag = "high";
			button_PikToHighCam.Text = "拾取至高清相机";
			button_PikToHighCam.UseVisualStyleBackColor = false;
			button_PikToHighCam.Click += new System.EventHandler(button_PikToFastCam_Click);
			button_PikToFastCam.BackColor = System.Drawing.Color.Silver;
			button_PikToFastCam.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PikToFastCam.CnPressDownColor = System.Drawing.Color.White;
			button_PikToFastCam.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			button_PikToFastCam.FlatAppearance.BorderSize = 2;
			button_PikToFastCam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			button_PikToFastCam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			button_PikToFastCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button_PikToFastCam.Font = new System.Drawing.Font("黑体", 11.5f);
			button_PikToFastCam.Location = new System.Drawing.Point(8, 6);
			button_PikToFastCam.Name = "button_PikToFastCam";
			button_PikToFastCam.Size = new System.Drawing.Size(135, 37);
			button_PikToFastCam.TabIndex = 3;
			button_PikToFastCam.Tag = "fast";
			button_PikToFastCam.Text = "拾取至快速相机";
			button_PikToFastCam.UseVisualStyleBackColor = false;
			button_PikToFastCam.Click += new System.EventHandler(button_PikToFastCam_Click);
			button_platexy.BackColor = System.Drawing.Color.Silver;
			button_platexy.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_platexy.CnPressDownColor = System.Drawing.Color.White;
			button_platexy.Font = new System.Drawing.Font("黑体", 11.5f);
			button_platexy.Location = new System.Drawing.Point(117, 72);
			button_platexy.Name = "button_platexy";
			button_platexy.Size = new System.Drawing.Size(228, 40);
			button_platexy.TabIndex = 7;
			button_platexy.Text = "取料坐标列表";
			button_platexy.UseVisualStyleBackColor = false;
			button_platexy.Click += new System.EventHandler(button_platexy_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.DimGray;
			base.Controls.Add(button_close);
			base.Controls.Add(label39);
			base.Controls.Add(panel8);
			base.Controls.Add(panel_autopikxy);
			base.Controls.Add(panel_plateXYlist);
			base.Controls.Add(label1);
			base.Controls.Add(label31);
			base.Controls.Add(button2);
			base.Controls.Add(listBox_StackPlateAll);
			base.Controls.Add(listBox_StackVibraAll);
			base.Controls.Add(label_StackPlate);
			base.Controls.Add(label30);
			base.Controls.Add(button_closefeeder);
			base.Controls.Add(label_Vibra);
			base.Controls.Add(button_campara);
			base.Controls.Add(button_stackplateXY_update);
			base.Controls.Add(label_feederstate);
			base.Controls.Add(button_hcam_specialpara);
			base.Controls.Add(label6);
			base.Controls.Add(panel3);
			base.Controls.Add(panel_feederdelay);
			base.Controls.Add(tabControl1);
			base.Controls.Add(button_mntH_Goto);
			base.Controls.Add(button_pikH_Goto);
			base.Controls.Add(button_mntH_Save);
			base.Controls.Add(button_pikH_Save);
			base.Controls.Add(button_mntH_View);
			base.Controls.Add(button_pikH_View);
			base.Controls.Add(button_mntH_Offset_Sync);
			base.Controls.Add(button_pikH_Offset_Sync);
			base.Controls.Add(panel_stackselNew_Page);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.Name = "UserControl_Stack";
			base.Size = new System.Drawing.Size(1419, 1080);
			base.Load += new System.EventHandler(UserControl_Stack_Load);
			panel_isScanR.ResumeLayout(false);
			panel_isScanR.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_scanR).EndInit();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_feeder.ResumeLayout(false);
			panel_feeder.PerformLayout();
			panel_context2.ResumeLayout(false);
			panel_context2_2.ResumeLayout(false);
			panel_context2_2.PerformLayout();
			panel_hcam_special.ResumeLayout(false);
			panel_hcam_special.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_hcam_special_level).EndInit();
			panel_iscolloect.ResumeLayout(false);
			panel_iscolloect.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_stackCollect).EndInit();
			panel_context3.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel6.ResumeLayout(false);
			panel_context4.ResumeLayout(false);
			panel_chip_hmm.ResumeLayout(false);
			panel_chip_hmm.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_AutoEntTimeDelay).EndInit();
			panel_stackplate_autoprovider.ResumeLayout(false);
			panel_stackplate_autoprovider.PerformLayout();
			panel_stackselNew_Page.ResumeLayout(false);
			panel_stackselNew_Page.PerformLayout();
			panel_context1.ResumeLayout(false);
			panel_stacktool0.ResumeLayout(false);
			panel_enable_Zn.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel_head.ResumeLayout(false);
			panel_feederdelay.ResumeLayout(false);
			panel_feederdelay.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_feederdelay).EndInit();
			panel_plateXYlist.ResumeLayout(false);
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_stackplateXY).EndInit();
			panel45.ResumeLayout(false);
			panel45.PerformLayout();
			panel_addSubPlate.ResumeLayout(false);
			panel48.ResumeLayout(false);
			panel48.PerformLayout();
			panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)nud_stackplate_rows).EndInit();
			((System.ComponentModel.ISupportInitialize)nud_stackplate_columns).EndInit();
			panel_autopikxy.ResumeLayout(false);
			panel9.ResumeLayout(false);
			panel9.PerformLayout();
			panel10.ResumeLayout(false);
			panel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_first_feederin).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_scanr).EndInit();
			panel11.ResumeLayout(false);
			panel11.PerformLayout();
			panel8.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private void init_autopik()
		{
			radioButton_beltcolor = new RadioButton[3] { radioButton1, radioButton2, radioButton3 };
			checkBox_autosave.Checked = USR2.mIsAutoPik_AutoSave;
			for (int i = 0; i < 3; i++)
			{
				radioButton_beltcolor[i].Tag = i;
				radioButton_beltcolor[i].CheckedChanged += radioButton_beltcolor_CheckedChanged;
			}
		}

		public void flush_autopik()
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (array[num].mAutoPixXY == null)
			{
				array[num].mAutoPixXY = new AutoFeederPikXY();
			}
			label37.Text = (new string[3] { "料站", "料站", "Stack " })[MainForm0.USR_INIT.mLanguage] + (num + 1) + (new string[3] { "参数", "參數", " Para" })[MainForm0.USR_INIT.mLanguage];
			button_autorun_cur.Text = (new string[3] { "料站", "料站", "Stack " })[MainForm0.USR_INIT.mLanguage] + (num + 1) + (new string[3] { "飞达", "飛達", " Feeder" })[MainForm0.USR_INIT.mLanguage];
			if (array[num].mAutoPixXY.belt_color < 0)
			{
				array[num].mAutoPixXY.belt_color = 0;
			}
			radioButton_beltcolor[array[num].mAutoPixXY.belt_color].Checked = true;
			if ((decimal)array[num].mAutoPixXY.scanr > numericUpDown_scanr.Maximum)
			{
				array[num].mAutoPixXY.scanr = (int)numericUpDown_scanr.Maximum;
			}
			numericUpDown_scanr.Value = array[num].mAutoPixXY.scanr;
			numericUpDown_first_feederin.Value = array[num].mAutoPixXY.first_feederin;
		}

		private void radioButton_beltcolor_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			int num = (int)radioButton.Tag;
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num2 = mStackLib.index[(int)mStackLib.sel];
			if (array[num2].mAutoPixXY == null)
			{
				array[num2].mAutoPixXY = new AutoFeederPikXY();
			}
			int belt_color = array[num2].mAutoPixXY.belt_color;
			if (radioButton.Checked && belt_color != num)
			{
				array[num2].mAutoPixXY.belt_color = num;
				MainForm0.save_usrProjectData();
			}
		}

		private void __button_autorun_cur_Click(object sender, EventArgs e)
		{
			int num = mStackLib.index[(int)mStackLib.sel];
			_ = mStackLib.stacktab[(int)mStackLib.sel];
			MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num, flag: true);
			MainForm0.mIsFeederOn[mFn][num] = true;
			Thread thread = new Thread(thd_auto_pikxy);
			thread.IsBackground = true;
			thread.Start();
			stacksel_new_flushdata();
		}

		private void __button_prev_Click(object sender, EventArgs e)
		{
			string text = (string)((Button)sender).Tag;
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = 0;
			if (mStackLib.sel != 0)
			{
				return;
			}
			array = USR2.mStackLib.stacktab[0];
			MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num, flag: false);
			MainForm0.mIsFeederOn[mFn][num] = false;
			if (text == "next")
			{
				if (num < HW.mStackNum[mFn][0] - 1)
				{
					bool flag = false;
					for (int i = num + 1; i < HW.mStackNum[mFn][0]; i++)
					{
						if (array[i].mSelected)
						{
							flag = true;
							num2 = (num = i);
							break;
						}
					}
					if (!flag)
					{
						stacksel_new_flushdata();
						return;
					}
				}
			}
			else if (text == "prev" && num < HW.mStackNum[mFn][0])
			{
				bool flag2 = false;
				for (int num3 = num - 1; num3 >= 0; num3--)
				{
					if (array[num3].mSelected)
					{
						flag2 = true;
						num2 = (num = num3);
						break;
					}
				}
				if (!flag2)
				{
					stacksel_new_flushdata();
					return;
				}
			}
			MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2, flag: true);
			MainForm0.mIsFeederOn[mFn][num2] = true;
			for (int j = 0; j < array[num2].mAutoPixXY.first_feederin; j++)
			{
				MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2, flag: false);
				MainForm0.mIsFeederOn[mFn][num2] = false;
				MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2, flag: true);
				MainForm0.mIsFeederOn[mFn][num2] = true;
			}
			mStackLib.index[(int)mStackLib.sel] = num2;
			stacksel_new_flushdata();
			stacksel_new_flushZn();
			Thread thread = new Thread(thd_auto_pikxy);
			thread.IsBackground = true;
			thread.Start();
		}

		private void __button_savepikxy_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (!MainForm0.mIsSimulation)
			{
				string text = "";
				bool flag = true;
				if (mStackLib.sel == ProviderType.Feedr)
				{
					if (Math.Abs(MainForm0.mCur[mFn].x - USR.mSlotAllCoord[num].X) >= HW.mSlotPitch / 2)
					{
						text = ((MainForm0.USR_INIT.mLanguage == 2) ? "Current X is much far from the valid slot position, " : "要保存的坐标X方向偏差太大，可能错误!");
						if (MainForm0.CmMessageBox(text, MessageBoxButtons.YesNo) != DialogResult.Yes)
						{
							flag = false;
						}
					}
					if (flag)
					{
						array[num].mXY.X = MainForm0.mCur[mFn].x;
						array[num].mXY.Y = MainForm0.mCur[mFn].y;
						MainForm0.save_usrProjectData();
						button_savepikxy.Visible = false;
						label_state.Text = (new string[3] { "结果已保存", "結果已保存", "Result Saved" })[MainForm0.USR_INIT.mLanguage];
					}
				}
			}
			stacksel_new_flushdata();
		}

		private void __button_stop_Click(object sender, EventArgs e)
		{
			mIs_vsplus_autopikxy_finished = true;
			button_stop.Visible = false;
		}

		private void thd_auto_pikxy()
		{
			mIs_vsplus_autopikxy_finished = false;
			Invoke((MethodInvoker)delegate
			{
				button_all.Enabled = false;
				button_autorun_cur.Enabled = false;
				button_prev.Enabled = false;
				button_next.Enabled = false;
				button_close.Enabled = false;
				button_stop.Visible = true;
				label_state.Text = (new string[3] { "算法运行中...", "算法運行中...", "Algorithms Running... " })[MainForm0.USR_INIT.mLanguage];
			});
			vsplus_autopikxy(USR2);
			while (!mIs_vsplus_autopikxy_finished)
			{
				Thread.Sleep(50);
			}
			try
			{
				Invoke((MethodInvoker)delegate
				{
					StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
					int num = mStackLib.index[(int)mStackLib.sel];
					button_all.Enabled = true;
					button_autorun_cur.Enabled = true;
					button_prev.Enabled = true;
					button_next.Enabled = true;
					button_close.Enabled = true;
					button_stop.Visible = false;
					label_state.Text = (new string[3] { "识别结束", "識別結束", "Running Done" })[MainForm0.USR_INIT.mLanguage];
					button_savepikxy.Visible = true;
					if (Math.Abs(MainForm0.mCur[mFn].x - USR.mSlotAllCoord[num].X) >= HW.mSlotPitch / 2)
					{
						label_state.Text = (new string[3] { "结果不合理", "結果不合理", "Result Invalid" })[MainForm0.USR_INIT.mLanguage];
					}
					if (USR2.mIsAutoPik_AutoSave)
					{
						if (!MainForm0.mIsSimulation)
						{
							string text = "";
							bool flag = true;
							if (mStackLib.sel == ProviderType.Feedr)
							{
								if (Math.Abs(MainForm0.mCur[mFn].x - USR.mSlotAllCoord[num].X) >= HW.mSlotPitch / 2)
								{
									text = ((MainForm0.USR_INIT.mLanguage == 2) ? "Current X is much far from the valid slot position, " : "要保存的坐标X方向偏差太大，可能错误!");
									if (MainForm0.CmMessageBox(text, MessageBoxButtons.YesNo) != DialogResult.Yes)
									{
										flag = false;
									}
								}
								if (flag)
								{
									array[num].mXY.X = MainForm0.mCur[mFn].x;
									array[num].mXY.Y = MainForm0.mCur[mFn].y;
									MainForm0.save_usrProjectData();
									label_state.Text = (new string[3] { "结果已保存", "結果已保存", "Result Saved" })[MainForm0.USR_INIT.mLanguage];
								}
							}
						}
						stacksel_new_flushdata();
					}
				});
			}
			catch (Exception)
			{
			}
		}

		public void vsplus_autopikxy(USR2_DATA usr2)
		{
			Thread thread = new Thread(thd_autopikxy);
			thread.IsBackground = true;
			thread.Start(usr2);
		}

		private void thd_autopikxy(object o)
		{
			USR2_DATA uSR2_DATA = (USR2_DATA)o;
			StackElement[] array = uSR2_DATA.mStackLib.stacktab[(int)uSR2_DATA.mStackLib.sel];
			int num = uSR2_DATA.mStackLib.index[(int)uSR2_DATA.mStackLib.sel];
			MainForm0.moveToXY_andWait(mFn, 32, array[num].mXY);
			if (MainForm0.mIsSimulation)
			{
				string text = "C:\\\\E\\\\hwgcpic\\\\liaozhan\\\\";
				new DirectoryInfo(text);
				if (!Directory.Exists(text))
				{
					return;
				}
				string text2 = text + (num + 1) + ".bmp";
				if (File.Exists(text2))
				{
					int num2 = HW.mMarkCamItem[mFn].index[0];
					MainForm0.mJVSBitmap[num2] = new Bitmap(text2);
					VISUAL_RESULT visual_result = new VISUAL_RESULT();
					visual_result.is_test = true;
					visual_result.set_w_h(array[num].lenght, array[num].width);
					if (MainForm0.ImageVisual(mFn, VISUAL_MODE.AUTODELTA_MARK, CameraType.Mark, VisualType.MarkAutoPikXY, array[num].mAutoPixXY.scanr, array[num].mAutoPixXY.threshold, MainForm0.mZn[mFn], array[num].mAutoPixXY.belt_color, array[num].mAutoPixXY.shape, 0f, ref visual_result) != 0)
					{
						MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "MARK相机识别测试识别失败");
					}
					mIs_vsplus_autopikxy_finished = true;
				}
				return;
			}
			while (!mIs_vsplus_autopikxy_finished)
			{
				int num3 = 1;
				int num4 = 0;
				VISUAL_RESULT visual_result2 = new VISUAL_RESULT();
				visual_result2.set_w_h(array[num].lenght, array[num].width);
				visual_result2.is_test = true;
				if (MainForm0.ImageVisual(mFn, VISUAL_MODE.AUTODELTA_MARK, CameraType.Mark, VisualType.MarkAutoPikXY, array[num].mAutoPixXY.scanr, array[num].mAutoPixXY.threshold, MainForm0.mZn[mFn], array[num].mAutoPixXY.belt_color, array[num].mAutoPixXY.shape, 0f, ref visual_result2) != 0)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "MARK相机识别测试识别失败");
					break;
				}
				if (Math.Abs(visual_result2.move_x) <= num3 && Math.Abs(visual_result2.move_y) <= num3)
				{
					break;
				}
				if (num4++ == 2)
				{
					if (num3 >= 3)
					{
						MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Detect fail, please check the ink Points!" : "识别错误，请检查扎点是否完整！");
						break;
					}
					num4 = 0;
					num3++;
				}
				MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(MainForm0.mCur[mFn].x - visual_result2.move_x, MainForm0.mCur[mFn].y + visual_result2.move_y));
			}
			mIs_vsplus_autopikxy_finished = true;
		}

		public void vsplus_autopikxy_all(USR2_DATA usr2)
		{
			Thread thread = new Thread(thd_autopikxy_all);
			thread.IsBackground = true;
			thread.Start(usr2);
		}

		private void thd_autopikxy_all(object o)
		{
			USR2_DATA uSR2_DATA = (USR2_DATA)o;
			if (!MainForm0.mIsSimulation)
			{
				return;
			}
			StackElement[] array = uSR2_DATA.mStackLib.stacktab[(int)uSR2_DATA.mStackLib.sel];
			for (int i = 0; i < HW.mStackNum[mFn][0]; i++)
			{
				int stackno = i;
				if (!array[stackno].mSelected)
				{
					continue;
				}
				MainForm0.moveToXY_andWait(mFn, 32, array[stackno].mXY);
				string text = "C:\\\\E\\\\hwgcpic\\\\liaozhan\\\\";
				new DirectoryInfo(text);
				if (!Directory.Exists(text))
				{
					break;
				}
				Thread.Sleep(200);
				string text2 = text + (stackno + 1) + ".bmp";
				if (!File.Exists(text2))
				{
					Invoke((MethodInvoker)delegate
					{
						set_provider_from_footprintlab_mode1(stackno, is_match: false);
					});
					continue;
				}
				Invoke((MethodInvoker)delegate
				{
					set_provider_from_footprintlab_mode1(stackno, is_match: true);
				});
				int num = HW.mMarkCamItem[mFn].index[0];
				MainForm0.mJVSBitmap[num] = new Bitmap(text2);
				VISUAL_RESULT visual_result = new VISUAL_RESULT();
				visual_result.set_w_h(array[stackno].lenght, array[stackno].width);
				visual_result.is_test = true;
				if (MainForm0.ImageVisual(mFn, VISUAL_MODE.AUTODELTA_MARK, CameraType.Mark, VisualType.MarkAutoPikXY, array[stackno].mAutoPixXY.scanr, array[stackno].mAutoPixXY.threshold, MainForm0.mZn[mFn], array[stackno].mAutoPixXY.belt_color, array[stackno].mAutoPixXY.shape, 0f, ref visual_result) != 0)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "MARK相机识别测试识别失败");
				}
			}
		}

		private void __numericUpDown_scanr_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (array[num].mAutoPixXY == null)
			{
				array[num].mAutoPixXY = new AutoFeederPikXY();
			}
			int scanr = array[num].mAutoPixXY.scanr;
			if (scanr != (int)numericUpDown_scanr.Value)
			{
				array[num].mAutoPixXY.scanr = (int)numericUpDown_scanr.Value;
				MainForm0.save_usrProjectData();
			}
		}

		private void __numericUpDown_first_feederin_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (array[num].mAutoPixXY == null)
			{
				array[num].mAutoPixXY = new AutoFeederPikXY();
			}
			int first_feederin = array[num].mAutoPixXY.first_feederin;
			if (first_feederin != (int)numericUpDown_first_feederin.Value)
			{
				array[num].mAutoPixXY.first_feederin = (int)numericUpDown_first_feederin.Value;
				MainForm0.save_usrProjectData();
			}
		}

		public void vsplus_pik_to_cam(CameraType cam, USR2_DATA usr2)
		{
			USR2 = usr2;
			if (!MainForm0.mutex_piktocam)
			{
				MainForm0.mutex_piktocam = true;
				Thread thread = new Thread(thd_vsplus_piktoFastCam);
				thread.IsBackground = true;
				thread.Start(cam);
			}
		}

		public void thd_vsplus_piktoFastCam(object o)
		{
			CameraType cameraType = (CameraType)o;
			int num = MainForm0.mZn[mFn];
			StackElement[] array = USR2.mStackLib.stacktab[(int)USR2.mStackLib.sel];
			int num2 = USR2.mStackLib.index[(int)USR2.mStackLib.sel];
			int value = array[num2].mZnData[MainForm0.mZn[mFn]].Pik.Height;
			if (USR2.mIsHOffsetMode)
			{
				float num3 = MainForm0.format_H_to_Hmm(Math.Abs((MainForm0.format_feeder_front_or_back(mFn, num2) == 0) ? USR.mBaseHeight_feeder[num] : USR.mBaseHeight_feederBk[num]));
				if (USR2.mStackLib.sel == ProviderType.Vibra || USR2.mStackLib.sel == ProviderType.Plate)
				{
					num3 = MainForm0.format_H_to_Hmm(Math.Abs(array[num2].mZnData[num].baseH));
				}
				float hmm = num3 + array[num2].mZnData[num].Pik.Offset;
				value = MainForm0.format_Hmm_to_H(hmm) * ((num % 2 != 0) ? 1 : (-1));
				if (HW.mSmtGenerationNo == 2)
				{
					value = Math.Abs(value);
				}
			}
			if (USR2.mStackLib.sel == ProviderType.Plate)
			{
				if (array[num2].mPlt.mXYlist == null && array[num2].mPlt.mXYlist.Count <= 0)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "There is no plate XY list!" : "没有生成取料坐标！");
					goto IL_068f;
				}
				if (array[num2].mPlt.mStartIndex >= array[num2].mPlt.mXYlist.Count)
				{
					if (!array[num2].mPlt.mIsAutoEnt)
					{
						if (MainForm0.CmMessageBoxTop((USR_INIT.mLanguage == 2) ? "Plate is empty, please add chips!" : "该料盘元件已经用完，请更换！", MessageBoxButtons.OKCancel) != DialogResult.OK)
						{
							goto IL_068f;
						}
						array[num2].mPlt.mStartIndex = 0;
					}
					else
					{
						MainForm0.msdelay((int)(array[num2].mPlt.mAutoEntTimeDelay * 1000f));
						array[num2].mPlt.mStartIndex = 0;
					}
				}
				else if (array[num2].mPlt.mStartIndex < 0)
				{
					string[] array2 = new string[3] { "料盘起始索引不正确，请正确指定!", "料盤起始索引不正確，請正確指定!", "Plate Start Index is not correct, please check!" };
					MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
					goto IL_068f;
				}
				MainForm0.moveToZero_ZA_andWait(mFn);
				int mStartIndex = array[num2].mPlt.mStartIndex;
				MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(array[num2].mPlt.mXYlist[mStartIndex].X - USR.mDeltaNozzle[0][num].X, array[num2].mPlt.mXYlist[mStartIndex].Y - USR.mDeltaNozzle[0][num].Y));
				array[num2].mPlt.mStartIndex++;
				Invoke((MethodInvoker)delegate
				{
					update_plate_index_str(format_plate_startindex_str());
				});
			}
			else
			{
				MainForm0.moveToZero_ZA_andWait(mFn);
				MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(array[num2].mXY.X - USR.mDeltaNozzle[0][num].X, array[num2].mXY.Y - USR.mDeltaNozzle[0][num].Y));
				if (USR2.mStackLib.sel == ProviderType.Feedr)
				{
					MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2, flag: true);
				}
			}
			MainForm0.moveToZ_noWait(mFn, num, array[num2].mZnData[num].Pik.DownSpeed, value);
			if (array[num2].mZnData[num].Pik.DownSpeed > 32)
			{
				MainForm0.misc_vacc_onoff(mFn, num, 1);
			}
			MainForm0.WaitComplete_Z(mFn, num);
			if (array[num2].mZnData[num].Pik.DownSpeed <= 32)
			{
				MainForm0.misc_vacc_onoff(mFn, num, 1);
				MainForm0.msdelay(array[num2].mZnData[num].Pik.Delay + 50);
			}
			else
			{
				MainForm0.msdelay(array[num2].mZnData[num].Pik.Delay);
			}
			MainForm0.moveToZ_andWait(mFn, num, array[num2].mZnData[num].Pik.UpSpeed, MainForm0.USR3B[mFn].mGen0SafeZ * (1 - num % 2) * -1);
			MainForm0.moveToZ_noWait(mFn, num, array[num2].mZnData[num].Pik.UpSpeed, 0);
			if (USR2.mStackLib.sel == ProviderType.Feedr)
			{
				MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2, flag: false);
			}
			switch (cameraType)
			{
			case CameraType.Fast:
				MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, USR.mFastCamRecognizeCoord[0]);
				if (MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
				}
				MainForm0.mark_led_on_ext(mFn, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: true);
				break;
			case CameraType.High:
				MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, USR.mHighCamRecognizeCoord[0][num]);
				if (MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.High);
				}
				MainForm0.mark_led_on_ext(mFn, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: true);
				if (USR2 != null && array[num2].mIsHCamSpecialPara)
				{
					MainForm0.hcam_lightlevel_set(mFn, array[num2].HCamSpecial_ledlevel);
				}
				break;
			}
			MainForm0.msdelay(200);
			if (HW.mSmtGenerationNo == 2)
			{
				float hmm2 = MainForm0.format_H_to_Hmm(USR.mBaseHeight_camera[num]) - array[num2].height;
				int num4 = MainForm0.format_Hmm_to_H(hmm2);
				MainForm0.moveToZ_andWait(mFn, num, array[num2].mZnData[num].Pik.UpSpeed, num4);
			}
			MainForm0.thd_vsplus_visual_test(USR2.mStackLib.sel);
			goto IL_068f;
			IL_068f:
			MainForm0.mutex_piktocam = false;
		}

		private void vsplus_collect(USR2_DATA usr2)
		{
			USR2 = usr2;
			if (MainForm0.CmMessageBoxTop((USR_INIT.mLanguage == 2) ? "Does the chip has passed the Test Visual?" : "您已经确保该元件已经通过“识别测试”了吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Thread thread = new Thread(thd_vsplus_collect);
				thread.IsBackground = true;
				thread.Start(USR2.mStackLib.sel);
			}
		}

		private void thd_vsplus_collect(object o)
		{
			if (MainForm0.mCurCam[mFn] != CameraType.Fast && MainForm0.mCurCam[mFn] != CameraType.High)
			{
				return;
			}
			if (MainForm0.mCurCam[mFn] == CameraType.Fast)
			{
				if (MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
				}
				else if (MainForm0.mCurCam[mFn] == CameraType.High && MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.High);
				}
			}
			StackElement[] stacklib = USR2.mStackLib.stacktab[(int)o];
			int stackno = USR2.mStackLib.index[(int)o];
			int cur_range = stacklib[stackno].scanR;
			int threshold = stacklib[stackno].mZnData[MainForm0.mZn[mFn]].threshold;
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			if (!stacklib[stackno].mIsScanR)
			{
				cur_range = ((MainForm0.mCurCam[mFn] != CameraType.High) ? USR2.mFastCamScanRange[0][MainForm0.mZn[mFn]] : USR2.mHighCamScanRange[0][MainForm0.mZn[mFn]]);
			}
			VisualType visualType = stacklib[stackno].visualtype;
			if (visualType >= VisualType.N_A)
			{
				visualType = VisualType.Normal;
			}
			visual_result.is_test = true;
			visual_result.set_w_h(stacklib[stackno].lenght, stacklib[stackno].width);
			if (visualType == VisualType.FootPrint_R)
			{
				PinConfig pinconfig = MainForm0.common_footprint_get_pinconfig(stacklib[stackno].mChipFootprint);
				visual_result.set_pinconfig(pinconfig);
			}
			if (MainForm0.ImageVisual(mFn, VISUAL_MODE.COMMON, MainForm0.mCurCam[mFn], visualType, cur_range, threshold, MainForm0.mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Fail to Collect!" : "采集失败");
				return;
			}
			stacklib[stackno].mCollectL = visual_result.box_width;
			stacklib[stackno].mCollectW = visual_result.box_height;
			stacklib[stackno].lenght = stacklib[stackno].mCollectL * ((MainForm0.mCurCam[mFn] != CameraType.High) ? USR.mFastCamRatio[0][MainForm0.mZn[mFn]] : USR.mHighCamRatio[0]) / 100f;
			stacklib[stackno].width = stacklib[stackno].mCollectW * ((MainForm0.mCurCam[mFn] != CameraType.High) ? USR.mFastCamRatio[0][MainForm0.mZn[mFn]] : USR.mHighCamRatio[0]) / 100f;
			MainForm0.save_usrProjectData();
			Invoke((MethodInvoker)delegate
			{
				set_collect_l_w(stacklib[stackno].lenght, stacklib[stackno].width);
			});
		}

		public UserControl_Stack(int fn, USR_DATA usr, USR2_DATA usr2, USR3_BASE usr3b)
		{
			InitializeComponent();
			mFn = fn;
			USR_INIT = MainForm0.USR_INIT;
			USR = usr;
			USR2 = usr2;
			USR3B = usr3b;
			U3 = MainForm0.U3[mFn];
			U3Idx = MainForm0.U3Idx[mFn];
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			mStackLib = usr2.mStackLib;
			init_view();
			init_stacknew_onlyonce();
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "料站参数", "料站參數", "Provider Para" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stacksel_feeder,
				str = new string[3] { "普通飞达", "普通飛達", "Feeder" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stacksel_plate,
				str = new string[3] { "托盘料盘", "托盤料盤", "Plate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stacksel_vibra,
				str = new string[3] { "振动飞达", "振動飛達", "Vibra" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_stacksel_title,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stackMoveToXY,
				str = new string[3]
				{
					"定位" + Environment.NewLine + "取料坐标",
					"定位" + Environment.NewLine + "取料坐標",
					"Goto" + Environment.NewLine + "Pick Coord XY"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_gotoPrevStack,
				str = new string[3] { "←定位", "←定位", "← Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_gotoNextStack,
				str = new string[3] { "定位→", "定位→", "Goto →" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stackSaveXY,
				str = new string[3]
				{
					"保存" + Environment.NewLine + "取料坐标",
					"保存" + Environment.NewLine + "取料坐標",
					"Save" + Environment.NewLine + "Pick Coord XY"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_openfeeder,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_autoPixXY,
				str = new string[3] { "智能辅助自动校正取料坐标", "智能輔助自動校正取料坐標", "Automatic Correct Pick Coord XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_footprint,
				str = new string[3] { "封装库", "封裝庫", "Footprint Lab" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stackCopy,
				str = new string[3] { "批量复制", "批量復制", "Bulk Copy" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_EnableNozzle,
				str = new string[3] { "吸嘴启用", "吸嘴啟用", "Nozzle Used" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label17,
				str = new string[3] { "● 取料Z轴设置", "● 取料Z軸設置", "● Pick Z Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_goto_pikxy_byNozzle,
				str = new string[3] { "吸嘴定位取料坐标", "吸嘴定位取料坐標", "Nozzle Goto PickXY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pikBaseH,
				str = new string[3] { "托盘基准最高点", "托盤基準最高位", "Plate Highest Base-H" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label10,
				str = new string[3] { "● 贴装Z轴设置", "● 貼裝Z軸設置", "● Mount Z Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label26,
				str = new string[3] { "厚度(mm)", "厚度(mm)", "Height(mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label12,
				str = new string[3] { "视觉参数调试", "視覺參數調試", "Visual Parameters" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PikToFastCam,
				str = new string[3] { "拾取至快速相机", "拾取至快速相機", "Pick to Fast-Cam" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PikToHighCam,
				str = new string[3] { "拾取至高清相机", "拾取至高清相機", "Pcik to High-Cam" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_visualrunning,
				str = new string[3]
				{
					"实时视觉",
					"實時視覺",
					"Real time" + Environment.NewLine + "Visual"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_collect,
				str = new string[3] { "采集", "采集", "Collect" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_visualtest2,
				str = new string[3] { "识别测试", "識別測試", "Visual Test" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label14,
				str = new string[3] { "长(mm)", "長(mm)", "L(mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label15,
				str = new string[3] { "宽(mm)", "寬(mm)", "W(mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_stack_visual,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_stackCollect,
				str = new string[3] { "特征识别", "特征識別", "Match L/W" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_isScanR,
				str = new string[3] { "专用扫描半径", "專用掃描半徑", "Special Scan-R" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label23,
				str = new string[3] { "识别容差(%)", "識別容差(%)", "Tolerance(%)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_reback,
				str = new string[3] { "放回", "放回", "Reback" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label32,
				str = new string[3]
				{
					"飞达/料盘/振动" + Environment.NewLine + "整体设置",
					"飛達/料盤/振動" + Environment.NewLine + "整體設置",
					"Overall Setting"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ledcam_para,
				str = new string[3]
				{
					"光源" + Environment.NewLine + "参数",
					"光源" + Environment.NewLine + "參數",
					"Cam/Led" + Environment.NewLine + "Para"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_from_other_prj,
				str = new string[3]
				{
					"来自" + Environment.NewLine + "其他工程",
					"來自" + Environment.NewLine + "其他工程",
					"From" + Environment.NewLine + "Project"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_from_footprintlab,
				str = new string[3]
				{
					"来自" + Environment.NewLine + "封装库",
					"來自" + Environment.NewLine + "封裝庫",
					"From " + Environment.NewLine + "Footprint Lab"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_from_footprintlab_view,
				str = new string[3] { "刷新结果", "刷新結果", "Flush Result" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_providerSetting,
				str = new string[3] { "特别配置", "特別配置", "Special Config" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_saveasdefault,
				str = new string[3] { "存为默认", "存为默认", "Save as Default" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_openfeeder,
				str = new string[3] { "开飞达", "開飛達", "Open Feeder" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_stackplate_AutoEntComponent,
				str = new string[3] { "自动供料", "自動供料", "Auto Chip In" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label13,
				str = new string[3] { "换料延时", "換料延時", "Chip Delay" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label28,
				str = new string[3] { "连续取料", "連續取料", "Constant Pick" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label16,
				str = new string[3] { "换料延时(ms)", "換料延時(ms)", "Chip Delay(ms)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_platexy,
				str = new string[3] { "取料坐标列表", "取料坐標列表", "Pick Coord XY List" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label29,
				str = new string[3] { "进料角度", "進料角度", "Init Angle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "料盘位置设置", "料盤位置設置", "Plate Location " }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label9,
				str = new string[3] { "料盘取料坐标列表", "料盤取料坐標列表", "Pick Coordinate list" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_column,
				str = new string[3] { "列", "列", "X" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_row,
				str = new string[3] { "行", "行", "Y" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stackplateMoveToXYS,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stackplateSaveXYS,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stackplateGenXYlist,
				str = new string[3] { "生成取料坐标", "生成取料坐標", "Gen Pick XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_addSubPlate,
				str = new string[3] { "为该料盘添加相同元件的子料盘", "為該料盤添加相同元件的子料盤", "Add Sub Plate for Same Chip" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_addSubPlate,
				str = new string[3] { "添加子料盘", "添加子料盤", "Add Sub Plate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_delSubPlate,
				str = new string[3] { "删除子料盘", "删除子料盘", "Del Sub Plate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stackplateXY_moveto,
				str = new string[3] { "定位XY", "定位XY", "Goto XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stackplateXY_moveto_byZn,
				str = new string[3] { "吸嘴定位", "吸嘴定位", "Nozzle Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_is_hcam_special,
				str = new string[3] { "专用高清光源", "專用高清光源", "Special H-Cam Led" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label38,
				str = new string[3] { "智能自动校正取料坐标", "智能自動校正取料坐標", "Auto Correct Pick Coordinate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_all,
				str = new string[3] { "校正全部", "校正全部", "Correct All" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_autorun_cur,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_prev,
				str = new string[3] { "校正上一个", "校正上一個", "Correct Prev" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_next,
				str = new string[3] { "校正下一个", "校正下一個", "Correct Next" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stop,
				str = new string[3] { "停止", "停止", "Stop" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_savepikxy,
				str = new string[3] { "保存取料坐标", "保存取料坐標", "Save PickXY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label37,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label36,
				str = new string[3] { "料带颜色", "料帶顏色", "Tape Color" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton1,
				str = new string[3] { "白色料带", "白色料帶", "White" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton2,
				str = new string[3] { "黑色料带", "黑色料帶", "Black" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton3,
				str = new string[3] { "透明料带", "透明料帶", "Translucent" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label33,
				str = new string[3] { "扫描半径", "掃描半徑", "Scan-R" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label34,
				str = new string[3] { "额外进料", "額外進料", "Chip in more" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_autosave,
				str = new string[3] { "自动保存", "自動保存", "Auto Save" }
			});
			return list;
		}

		private void init_stacknew_onlyonce()
		{
			init_autopik();
			for (int i = 0; i < 3; i++)
			{
				StackElement[] array = mStackLib.stacktab[i];
				for (int j = 0; j < HW.mStackNum[mFn][i]; j++)
				{
					if (array[j].mAutoPixXY == null)
					{
						array[j].mAutoPixXY = new AutoFeederPikXY();
					}
				}
			}
			button_PikToHighCam.Enabled = HW.mHCamEn[mFn];
			panel_stackselNew_Page.Controls.Add(panel_plateXYlist);
			panel_plateXYlist.Location = new Point(button_platexy.Location.X, button_platexy.Location.Y - 4);
			panel_plateXYlist.BringToFront();
			panel_plateXYlist.Visible = false;
			lb_stackplate_XY = new Label[4] { label21, label25, label24, label27 };
			bt_stackplate_XY = new CnButton[4];
			for (int k = 0; k < 4; k++)
			{
				bt_stackplate_XY[k] = new CnButton();
			}
			for (int l = 0; l < 4; l++)
			{
				lb_stackplate_XY[l].Tag = l;
				lb_stackplate_XY[l].Click += lb_stackplate_XYS_Click;
				lb_stackplate_XY[l].DoubleClick += lb_stackplate_XYS_DoubleClick;
				if (l == mCurStackPlateCornerNo)
				{
					lb_stackplate_XY[l].BorderStyle = BorderStyle.Fixed3D;
					lb_stackplate_XY[l].BackColor = Color.White;
					bt_stackplate_XY[l].BackColor = Color.Red;
				}
				else
				{
					lb_stackplate_XY[l].BorderStyle = BorderStyle.Fixed3D;
					lb_stackplate_XY[l].BackColor = Color.Gray;
					bt_stackplate_XY[l].BackColor = Color.FromArgb(120, 100, 0);
				}
			}
			panel_componentarray.Controls.Clear();
			int num = 0;
			for (int m = 0; m < 4; m++)
			{
				for (int n = 0; n < 7; n++)
				{
					if (n == 3)
					{
						Label label = new Label();
						panel_componentarray.Controls.Add(label);
						label.Location = new Point(n * 20, m * 20);
						label.Size = new Size(18, 18);
						label.Text = "……";
						label.TextAlign = ContentAlignment.MiddleCenter;
						continue;
					}
					CnButton cnButton = new CnButton();
					panel_componentarray.Controls.Add(cnButton);
					cnButton.Location = new Point(n * 20, m * 20);
					cnButton.Size = new Size(18, 18);
					cnButton.Enabled = false;
					if ((m == 0 && n == 0) || (m == 0 && n == 6) || (m == 3 && n == 0) || (m == 3 && n == 6))
					{
						cnButton.Enabled = true;
						cnButton.BackColor = Color.FromArgb(120, 100, 0);
						cnButton.Tag = num;
						if (num == mCurStackPlateCornerNo)
						{
							cnButton.BackColor = Color.Red;
						}
						bt_stackplate_XY[num++] = cnButton;
					}
				}
			}
			this.panel2.Controls.Add(panel_feederdelay);
			panel_feederdelay.Location = panel_stackplate_autoprovider.Location;
			label_pikH_head = new Label();
			label_mntH_head = new Label();
			if (mStackLib.sel < ProviderType.Feedr || mStackLib.sel >= ProviderType.Num)
			{
				mStackLib.sel = ProviderType.Feedr;
			}
			button_stacksel = new CnButton[3] { button_stacksel_feeder, button_stacksel_plate, button_stacksel_vibra };
			for (int num2 = 0; num2 < 3; num2++)
			{
				button_stacksel[num2].Tag = num2;
				button_stacksel[num2].CnButtonMode = ButtonModeEn.PressRadio;
				button_stacksel[num2].ForeColor = Color.White;
				button_stacksel[num2].BackColor = Color.DimGray;
				button_stacksel[num2].CnPressDownColor = Color.Red;
				button_stacksel[num2].MouseDown += button_stacksel_MouseDown;
				button_stacksel[num2].CnSetPressDown(num2 == (int)mStackLib.sel);
			}
			listBox_StackVibraAll.Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], listBox_StackVibraAll.Font.Size, FontStyle.Regular);
			listBox_StackPlateAll.Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], listBox_StackPlateAll.Font.Size, FontStyle.Regular);
			panel_context1.Controls.Add(label_Vibra);
			panel_context1.Controls.Add(label_StackPlate);
			Size size3 = (label_Vibra.Size = (label_StackPlate.Size = label_Stack.Size));
			Point point2 = (label_Vibra.Location = (label_StackPlate.Location = label_Stack.Location));
			listBox_StackVibraAll.Size = new Size(484, 44);
			panel4.Controls.Add(button_platexy);
			button_platexy.Location = new Point(button_stackMoveToXY.Location.X, button_stackMoveToXY.Location.Y);
			button_platexy.BringToFront();
			panel4.Controls.Add(cnButton_stackplate_startIndex);
			cnButton_stackplate_startIndex.Location = new Point(button_platexy.Location.X, button_platexy.Location.Y + button_platexy.Height + 2);
			cnButton_stackplate_startIndex.BringToFront();
			listBox_StackPlateAll.Items.Clear();
			for (int num3 = 0; num3 < HW.mStackNum[mFn][1]; num3++)
			{
				listBox_StackPlateAll.Items.Add((StackPlateNo(num3) + 1).ToString());
			}
			label_StackPlate.Text = "P" + (mStackLib.index[1] + 1);
			listBox_StackPlateAll.SelectedIndex = StackPlateListBoxIndex(mStackLib.index[1]);
			label_Vibra.Text = "V" + (mStackLib.index[2] + 1);
			listBox_StackVibraAll.SelectedIndex = mStackLib.index[2];
			label_Stack.Text = (mStackLib.index[0] + 1).ToString();
			panel_nozzleenable.BackColor = Color.White;
			checkBox_stack_nozzleEn = new CheckBox[HW.mZnNum[mFn]];
			for (int num4 = 0; num4 < HW.mZnNum[mFn]; num4++)
			{
				CheckBox checkBox = new CheckBox();
				panel_nozzleenable.Controls.Add(checkBox);
				checkBox.Location = new Point(5 + 64 * num4, 2);
				checkBox.Size = new Size(63, 23);
				checkBox.Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (num4 + 1);
				checkBox.Tag = num4;
				checkBox.BringToFront();
				checkBox.CheckedChanged += checkBox_stack_nozzleEn_CheckedChanged;
				checkBox.Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				checkBox_stack_nozzleEn[num4] = checkBox;
			}
			label_stack_pikH = new Label[8];
			for (int num5 = 0; num5 < 8; num5++)
			{
				label_stack_pikH[num5] = new Label();
			}
			label_stack_pikZnName = new Label[8];
			for (int num6 = 0; num6 < 8; num6++)
			{
				label_stack_pikZnName[num6] = new Label();
			}
			numericUpDown_stack_pikConfig = new NumericUpDown[3][];
			for (int num7 = 0; num7 < 3; num7++)
			{
				numericUpDown_stack_pikConfig[num7] = new NumericUpDown[8];
			}
			for (int num8 = 0; num8 < 3; num8++)
			{
				for (int num9 = 0; num9 < 8; num9++)
				{
					numericUpDown_stack_pikConfig[num8][num9] = new NumericUpDown();
				}
			}
			numericUpDown_pikoffset = new NumericUpDown[8];
			for (int num10 = 0; num10 < 8; num10++)
			{
				numericUpDown_pikoffset[num10] = new NumericUpDown();
			}
			panel_stacknew_pik.Controls.Clear();
			Panel panel = new Panel();
			panel_stacknew_pik.Controls.Add(panel);
			panel.Size = new Size(57 * HW.mZnNum[mFn] + 74, 127);
			panel.BorderStyle = BorderStyle.None;
			panel.Location = new Point(0, 0);
			panel.BackColor = Color.LightGray;
			for (int num11 = 0; num11 < HW.mZnNum[mFn] + 1; num11++)
			{
				if (num11 > 0)
				{
					panel.Controls.Add(label_stack_pikZnName[num11 - 1]);
					label_stack_pikZnName[num11 - 1].Location = new Point(74 + 57 * (num11 - 1), 2);
					label_stack_pikZnName[num11 - 1].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + num11;
					label_stack_pikZnName[num11 - 1].Size = new Size(52, 23);
					label_stack_pikZnName[num11 - 1].AutoSize = false;
					label_stack_pikZnName[num11 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label_stack_pikZnName[num11 - 1].Anchor = AnchorStyles.None;
					label_stack_pikZnName[num11 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_pikZnName[num11 - 1].Tag = num11 - 1;
					label_stack_pikZnName[num11 - 1].MouseClick += stack_label_MouseClick;
					label_stack_pikZnName[num11 - 1].BackColor = Color.LightGray;
				}
				if (num11 == 0)
				{
					panel.Controls.Add(label_pikH_head);
					label_pikH_head.Location = new Point(0, 25);
					label_pikH_head.Text = STR.PIK_H[USR_INIT.mLanguage];
					label_pikH_head.Size = new Size(72, 25);
					label_pikH_head.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label_pikH_head.Anchor = AnchorStyles.None;
					label_pikH_head.TextAlign = ContentAlignment.MiddleLeft;
				}
				else
				{
					panel.Controls.Add(label_stack_pikH[num11 - 1]);
					label_stack_pikH[num11 - 1].Location = new Point(74 + 57 * (num11 - 1), 27);
					label_stack_pikH[num11 - 1].Text = "0";
					label_stack_pikH[num11 - 1].Size = new Size(52, 23);
					label_stack_pikH[num11 - 1].AutoSize = false;
					label_stack_pikH[num11 - 1].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label_stack_pikH[num11 - 1].Anchor = AnchorStyles.None;
					label_stack_pikH[num11 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_pikH[num11 - 1].Tag = num11 - 1;
					label_stack_pikH[num11 - 1].MouseClick += stack_label_MouseClick;
					label_stack_pikH[num11 - 1].DoubleClick += label_stack_PikH_DoubleClick;
					label_stack_pikH[num11 - 1].BackColor = Color.White;
					label_stack_pikH[num11 - 1].BorderStyle = BorderStyle.None;
					label_stack_pikH[num11 - 1].Visible = !USR2.mIsHOffsetMode;
					panel.Controls.Add(numericUpDown_pikoffset[num11 - 1]);
					numericUpDown_pikoffset[num11 - 1].Location = new Point(74 + 57 * (num11 - 1), 27);
					numericUpDown_pikoffset[num11 - 1].BorderStyle = BorderStyle.None;
					numericUpDown_pikoffset[num11 - 1].Minimum = -100m;
					numericUpDown_pikoffset[num11 - 1].Maximum = 100m;
					numericUpDown_pikoffset[num11 - 1].DecimalPlaces = 2;
					numericUpDown_pikoffset[num11 - 1].Value = 1m;
					numericUpDown_pikoffset[num11 - 1].Size = new Size(52, 25);
					numericUpDown_pikoffset[num11 - 1].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					numericUpDown_pikoffset[num11 - 1].Anchor = AnchorStyles.None;
					numericUpDown_pikoffset[num11 - 1].Increment = 0.1m;
					numericUpDown_pikoffset[num11 - 1].Tag = num11 - 1;
					numericUpDown_pikoffset[num11 - 1].MouseClick += stack_numeric_MouseClick;
					numericUpDown_pikoffset[num11 - 1].ValueChanged += numericUpDown_pik_offset_ValueChanged;
					numericUpDown_pikoffset[num11 - 1].MouseUp += nud_stack_Para_MouseUp;
					numericUpDown_pikoffset[num11 - 1].Visible = USR2.mIsHOffsetMode;
				}
				for (int num12 = 0; num12 < 3; num12++)
				{
					if (num11 == 0)
					{
						Label label2 = new Label();
						label2.Location = new Point(0, 25 * (num12 + 2) - 2);
						panel.Controls.Add(label2);
						switch (num12)
						{
						case 0:
							label2.Text = STR.DOWN_SPD[USR_INIT.mLanguage];
							break;
						case 1:
							label2.Text = STR.UP_SPD[USR_INIT.mLanguage];
							break;
						case 2:
							label2.Text = STR.PIK_DLY[USR_INIT.mLanguage];
							break;
						}
						label2.Size = new Size(72, 25);
						label2.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						label2.Anchor = AnchorStyles.None;
						label2.TextAlign = ContentAlignment.MiddleLeft;
					}
					else
					{
						numericUpDown_stack_pikConfig[num12][num11 - 1].BorderStyle = BorderStyle.None;
						numericUpDown_stack_pikConfig[num12][num11 - 1].Minimum = ((num12 == 2) ? 0 : 0);
						numericUpDown_stack_pikConfig[num12][num11 - 1].Maximum = ((num12 == 2) ? 999 : 64);
						numericUpDown_stack_pikConfig[num12][num11 - 1].Value = ((num12 == 2) ? 10 : 64);
						numericUpDown_stack_pikConfig[num12][num11 - 1].Size = new Size(52, 25);
						numericUpDown_stack_pikConfig[num12][num11 - 1].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						numericUpDown_stack_pikConfig[num12][num11 - 1].Anchor = AnchorStyles.None;
						numericUpDown_stack_pikConfig[num12][num11 - 1].Tag = num12 * 8 + num11 - 1;
						numericUpDown_stack_pikConfig[num12][num11 - 1].Visible = true;
						numericUpDown_stack_pikConfig[num12][num11 - 1].Enabled = true;
						numericUpDown_stack_pikConfig[num12][num11 - 1].MouseClick += stack_numeric_MouseClick;
						numericUpDown_stack_pikConfig[num12][num11 - 1].ValueChanged += nud_stack_PikPara_ValueChanged;
						numericUpDown_stack_pikConfig[num12][num11 - 1].MouseUp += nud_stack_Para_MouseUp;
						numericUpDown_stack_pikConfig[num12][num11 - 1].Location = new Point(74 + 57 * (num11 - 1), 25 * (num12 + 2) + 2);
						panel.Controls.Add(numericUpDown_stack_pikConfig[num12][num11 - 1]);
					}
				}
				for (int num13 = 0; num13 < 4; num13++)
				{
					if (num13 != 0)
					{
						CnButton cnButton2 = new CnButton();
						panel_stacknew_pik.Controls.Add(cnButton2);
						cnButton2.Tag = num13 - 1;
						cnButton2.Text = (new string[3] { "同步", "同步", "Sync" })[USR_INIT.mLanguage];
						cnButton2.Size = new Size(55, 24);
						cnButton2.Location = new Point(panel.Size.Width + 2, 25 * (num13 + 1) - 1);
						cnButton2.UseVisualStyleBackColor = true;
						cnButton2.Click += button_stacknew_Hpara_synctoAllZn_Click;
						cnButton2.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						cnButton2.BackColor = Color.Silver;
					}
					else if (num13 == 0)
					{
						panel_stacknew_pik.Controls.Add(button_pikH_Offset_Sync);
						button_pikH_Offset_Sync.Tag = 7;
						button_pikH_Offset_Sync.Text = (new string[3] { "同步", "同步", "Sync" })[USR_INIT.mLanguage];
						button_pikH_Offset_Sync.Size = new Size(55, 24);
						button_pikH_Offset_Sync.Location = new Point(panel.Size.Width + 2, 25 * (num13 + 1) - 1);
						button_pikH_Offset_Sync.UseVisualStyleBackColor = true;
						button_pikH_Offset_Sync.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						panel_stacknew_pik.Controls.Add(button_pikH_Goto);
						button_pikH_Goto.Text = (new string[3] { "定位", "定位", "Goto" })[USR_INIT.mLanguage];
						button_pikH_Goto.Size = new Size(55, 24);
						button_pikH_Goto.Location = new Point(panel.Size.Width + 2, 25 * (num13 + 1) - 1);
						button_pikH_Goto.UseVisualStyleBackColor = true;
						button_pikH_Goto.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						panel_stacknew_pik.Controls.Add(button_pikH_Save);
						button_pikH_Save.Text = (new string[3] { "保存高度", "保存高度", "Save Height" })[USR_INIT.mLanguage];
						button_pikH_Save.Size = new Size(80, 24);
						button_pikH_Save.Location = new Point(panel.Size.Width + 2 + 56, 25 * (num13 + 1) - 1);
						button_pikH_Save.UseVisualStyleBackColor = true;
						button_pikH_Save.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						panel_stacknew_pik.Controls.Add(button_pikH_View);
						button_pikH_View.Tag = num13;
						button_pikH_View.Text = (new string[3] { "查看高度", "查看高度", "Check Height" })[USR_INIT.mLanguage];
						button_pikH_View.Size = new Size(80, 24);
						button_pikH_View.Location = new Point(panel.Size.Width + 2 + 56, 25 * (num13 + 1) - 1);
						button_pikH_View.UseVisualStyleBackColor = true;
						button_pikH_View.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						CnButton cnButton3 = new CnButton();
						panel_stacknew_pik.Controls.Add(cnButton3);
						cnButton3.Tag = 16;
						cnButton3.Text = (new string[3] { "全体同步", "全體同步", "Sync All" })[USR_INIT.mLanguage];
						cnButton3.Size = new Size(80, 74);
						cnButton3.Location = new Point(panel.Size.Width + 2 + 56, 49);
						cnButton3.UseVisualStyleBackColor = true;
						cnButton3.Click += button_stacknew_Hpara_synctoAllZn_Click;
						cnButton3.BackColor = Color.Silver;
						cnButton3.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						panel_stacknew_pik.Controls.Add(button_pikBaseH);
						button_pikBaseH.Size = new Size(136, 24);
						button_pikBaseH.Location = new Point(panel.Size.Width + 2, 25 * num13 - 1);
					}
				}
			}
			label_stack_mntH = new Label[8];
			for (int num14 = 0; num14 < 8; num14++)
			{
				label_stack_mntH[num14] = new Label();
			}
			label_stack_mntZnName = new Label[8];
			for (int num15 = 0; num15 < 8; num15++)
			{
				label_stack_mntZnName[num15] = new Label();
			}
			numericUpDown_stack_mntConfig = new NumericUpDown[3][];
			for (int num16 = 0; num16 < 3; num16++)
			{
				numericUpDown_stack_mntConfig[num16] = new NumericUpDown[8];
			}
			for (int num17 = 0; num17 < 3; num17++)
			{
				for (int num18 = 0; num18 < 8; num18++)
				{
					numericUpDown_stack_mntConfig[num17][num18] = new NumericUpDown();
				}
			}
			numericUpDown_mntoffset = new NumericUpDown[8];
			for (int num19 = 0; num19 < 8; num19++)
			{
				numericUpDown_mntoffset[num19] = new NumericUpDown();
			}
			panel_stacknew_mnt.Controls.Clear();
			Panel panel2 = new Panel();
			panel_stacknew_mnt.Controls.Add(panel2);
			panel2.Size = new Size(57 * HW.mZnNum[mFn] + 74, 127);
			panel2.BorderStyle = BorderStyle.None;
			panel2.BackColor = Color.LightGray;
			panel2.Location = new Point(0, 0);
			for (int num20 = 0; num20 < HW.mZnNum[mFn] + 1; num20++)
			{
				if (num20 > 0)
				{
					panel2.Controls.Add(label_stack_mntZnName[num20 - 1]);
					label_stack_mntZnName[num20 - 1].Location = new Point(74 + 57 * (num20 - 1), 2);
					label_stack_mntZnName[num20 - 1].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + num20;
					label_stack_mntZnName[num20 - 1].Size = new Size(52, 23);
					label_stack_mntZnName[num20 - 1].AutoSize = false;
					label_stack_mntZnName[num20 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label_stack_mntZnName[num20 - 1].Anchor = AnchorStyles.None;
					label_stack_mntZnName[num20 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_mntZnName[num20 - 1].Tag = num20 - 1;
					label_stack_mntZnName[num20 - 1].MouseClick += stack_label_MouseClick;
				}
				if (num20 == 0)
				{
					panel2.Controls.Add(label_mntH_head);
					label_mntH_head.Location = new Point(0, 25);
					label_mntH_head.Text = STR.MNT_H[USR_INIT.mLanguage];
					label_mntH_head.Size = new Size(72, 23);
					label_mntH_head.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label_mntH_head.Anchor = AnchorStyles.None;
					label_mntH_head.TextAlign = ContentAlignment.MiddleLeft;
				}
				else
				{
					panel2.Controls.Add(label_stack_mntH[num20 - 1]);
					label_stack_mntH[num20 - 1].Location = new Point(74 + 57 * (num20 - 1), 27);
					label_stack_mntH[num20 - 1].Text = "0";
					label_stack_mntH[num20 - 1].Size = new Size(52, 23);
					label_stack_mntH[num20 - 1].AutoSize = false;
					label_stack_mntH[num20 - 1].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label_stack_mntH[num20 - 1].Anchor = AnchorStyles.None;
					label_stack_mntH[num20 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_mntH[num20 - 1].Tag = num20 - 1 + 8;
					label_stack_mntH[num20 - 1].MouseClick += stack_label_MouseClick;
					label_stack_mntH[num20 - 1].DoubleClick += label_stack_mntH_DoubleClick;
					label_stack_mntH[num20 - 1].BackColor = Color.WhiteSmoke;
					label_stack_mntH[num20 - 1].BorderStyle = BorderStyle.None;
					panel2.Controls.Add(numericUpDown_mntoffset[num20 - 1]);
					numericUpDown_mntoffset[num20 - 1].Location = new Point(74 + 57 * (num20 - 1), 27);
					numericUpDown_mntoffset[num20 - 1].BorderStyle = BorderStyle.None;
					numericUpDown_mntoffset[num20 - 1].Minimum = -100m;
					numericUpDown_mntoffset[num20 - 1].Maximum = 100m;
					numericUpDown_mntoffset[num20 - 1].DecimalPlaces = 2;
					numericUpDown_mntoffset[num20 - 1].Value = 1m;
					numericUpDown_mntoffset[num20 - 1].Size = new Size(52, 23);
					numericUpDown_mntoffset[num20 - 1].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					numericUpDown_mntoffset[num20 - 1].Anchor = AnchorStyles.None;
					numericUpDown_mntoffset[num20 - 1].Tag = num20 - 1;
					numericUpDown_mntoffset[num20 - 1].Increment = 0.1m;
					numericUpDown_mntoffset[num20 - 1].MouseClick += stack_numeric_MouseClick;
					numericUpDown_mntoffset[num20 - 1].ValueChanged += numericUpDown_mnt_offset_ValueChanged;
					numericUpDown_mntoffset[num20 - 1].MouseUp += nud_stack_Para_MouseUp;
					numericUpDown_mntoffset[num20 - 1].Visible = USR2.mIsHOffsetMode;
				}
				for (int num21 = 0; num21 < 3; num21++)
				{
					if (num20 == 0)
					{
						Label label3 = new Label();
						label3.Location = new Point(0, 25 * (num21 + 2) - 2);
						panel2.Controls.Add(label3);
						switch (num21)
						{
						case 0:
							label3.Text = STR.DOWN_SPD[USR_INIT.mLanguage];
							break;
						case 1:
							label3.Text = STR.UP_SPD[USR_INIT.mLanguage];
							break;
						case 2:
							label3.Text = STR.MNT_DLY[USR_INIT.mLanguage];
							break;
						}
						label3.Size = new Size(72, 20);
						label3.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						label3.Anchor = AnchorStyles.None;
						label3.TextAlign = ContentAlignment.MiddleLeft;
					}
					else
					{
						new NumericUpDown();
						numericUpDown_stack_mntConfig[num21][num20 - 1].BorderStyle = BorderStyle.None;
						numericUpDown_stack_mntConfig[num21][num20 - 1].Minimum = ((num21 == 2) ? 0 : 0);
						numericUpDown_stack_mntConfig[num21][num20 - 1].Maximum = ((num21 == 2) ? 999 : 64);
						numericUpDown_stack_mntConfig[num21][num20 - 1].Value = ((num21 == 2) ? 10 : 64);
						numericUpDown_stack_mntConfig[num21][num20 - 1].Size = new Size(52, 20);
						numericUpDown_stack_mntConfig[num21][num20 - 1].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						numericUpDown_stack_mntConfig[num21][num20 - 1].Anchor = AnchorStyles.None;
						numericUpDown_stack_mntConfig[num21][num20 - 1].Tag = num21 * 8 + num20 - 1 + 24;
						numericUpDown_stack_mntConfig[num21][num20 - 1].Visible = true;
						numericUpDown_stack_mntConfig[num21][num20 - 1].Enabled = true;
						numericUpDown_stack_mntConfig[num21][num20 - 1].MouseClick += stack_numeric_MouseClick;
						numericUpDown_stack_mntConfig[num21][num20 - 1].ValueChanged += nud_stack_PikPara_ValueChanged;
						numericUpDown_stack_mntConfig[num21][num20 - 1].MouseUp += nud_stack_Para_MouseUp;
						numericUpDown_stack_mntConfig[num21][num20 - 1].Location = new Point(74 + 57 * (num20 - 1), 25 * (num21 + 2) + 2);
						panel2.Controls.Add(numericUpDown_stack_mntConfig[num21][num20 - 1]);
					}
				}
				for (int num22 = 0; num22 < 4; num22++)
				{
					if (num22 != 0)
					{
						CnButton cnButton4 = new CnButton();
						panel_stacknew_mnt.Controls.Add(cnButton4);
						cnButton4.Tag = 3 + num22 - 1;
						cnButton4.Text = (new string[3] { "同步", "同步", "Sync" })[USR_INIT.mLanguage];
						cnButton4.Size = new Size(55, 24);
						cnButton4.Location = new Point(panel2.Size.Width + 2, 25 * (num22 + 1) - 1);
						cnButton4.UseVisualStyleBackColor = true;
						cnButton4.Click += button_stacknew_Hpara_synctoAllZn_Click;
						cnButton4.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
						cnButton4.BackColor = Color.Silver;
						continue;
					}
					panel_stacknew_mnt.Controls.Add(panel_chip_hmm);
					panel_chip_hmm.Location = new Point(panel2.Size.Width + 2, -1);
					panel_stacknew_mnt.Controls.Add(button_mntH_Offset_Sync);
					button_mntH_Offset_Sync.Tag = 8;
					button_mntH_Offset_Sync.Text = (new string[3] { "同步", "同步", "Sync" })[USR_INIT.mLanguage];
					button_mntH_Offset_Sync.Size = new Size(55, 24);
					button_mntH_Offset_Sync.Location = new Point(panel2.Size.Width + 2, 25 * (num22 + 1) - 1);
					button_mntH_Offset_Sync.UseVisualStyleBackColor = true;
					button_mntH_Offset_Sync.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					panel_stacknew_mnt.Controls.Add(button_mntH_Goto);
					button_mntH_Goto.Text = (new string[3] { "定位", "定位", "Goto" })[USR_INIT.mLanguage];
					button_mntH_Goto.Size = new Size(55, 24);
					button_mntH_Goto.Location = new Point(panel2.Size.Width + 2, 25 * (num22 + 1) - 1);
					button_mntH_Goto.UseVisualStyleBackColor = true;
					button_mntH_Goto.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					panel_stacknew_mnt.Controls.Add(button_mntH_Save);
					button_mntH_Save.Text = (new string[3] { "保存高度", "保存高度", "Save Height" })[USR_INIT.mLanguage];
					button_mntH_Save.Size = new Size(80, 24);
					button_mntH_Save.Location = new Point(panel2.Size.Width + 2 + 56, 25 * (num22 + 1) - 1);
					button_mntH_Save.UseVisualStyleBackColor = true;
					button_mntH_Save.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					panel_stacknew_mnt.Controls.Add(button_mntH_View);
					button_mntH_View.Tag = num22;
					button_mntH_View.Text = (new string[3] { "查看高度", "查看高度", "Check Height" })[USR_INIT.mLanguage];
					button_mntH_View.Size = new Size(80, 24);
					button_mntH_View.Location = new Point(panel2.Size.Width + 2 + 56, 25 * (num22 + 1) - 1);
					button_mntH_View.UseVisualStyleBackColor = true;
					button_mntH_View.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					CnButton cnButton5 = new CnButton();
					panel_stacknew_mnt.Controls.Add(cnButton5);
					cnButton5.Tag = 17;
					cnButton5.Text = (new string[3] { "全体同步", "全體同步", "Sync All" })[USR_INIT.mLanguage];
					cnButton5.Size = new Size(80, 74);
					cnButton5.BackColor = Color.Silver;
					cnButton5.Location = new Point(panel2.Size.Width + 2 + 56, 49);
					cnButton5.UseVisualStyleBackColor = true;
					cnButton5.Click += button_stacknew_Hpara_synctoAllZn_Click;
					cnButton5.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					panel_stacknew_mnt.Controls.Add(button_mntBaseH);
					button_mntBaseH.Size = new Size(136, 24);
					button_mntBaseH.Location = new Point(panel2.Size.Width + 2, 25 * num22 - 1);
				}
			}
			label_threshold = new Label[8];
			for (int num23 = 0; num23 < 8; num23++)
			{
				label_threshold[num23] = new Label();
			}
			label_stack_nozzleEnName = new Label[8];
			for (int num24 = 0; num24 < 8; num24++)
			{
				label_stack_nozzleEnName[num24] = new Label();
			}
			panel_stacknew_visual.Controls.Clear();
			Panel panel3 = new Panel();
			panel_stacknew_visual.Controls.Add(panel3);
			panel3.Size = new Size(57 * HW.mZnNum[mFn] + 74, 52);
			panel3.BorderStyle = BorderStyle.None;
			panel3.Location = new Point(0, 0);
			panel3.BackColor = Color.LightGray;
			for (int num25 = 0; num25 < HW.mZnNum[mFn] + 1; num25++)
			{
				if (num25 > 0)
				{
					panel3.Controls.Add(label_stack_nozzleEnName[num25 - 1]);
					label_stack_nozzleEnName[num25 - 1].Location = new Point(74 + 57 * (num25 - 1), 2);
					label_stack_nozzleEnName[num25 - 1].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + num25;
					label_stack_nozzleEnName[num25 - 1].Size = new Size(52, 23);
					label_stack_nozzleEnName[num25 - 1].AutoSize = false;
					label_stack_nozzleEnName[num25 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label_stack_nozzleEnName[num25 - 1].Anchor = AnchorStyles.None;
					label_stack_nozzleEnName[num25 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_nozzleEnName[num25 - 1].Tag = num25 - 1;
					label_stack_nozzleEnName[num25 - 1].MouseClick += stack_label_MouseClick;
				}
				if (num25 == 0)
				{
					Label label4 = new Label();
					label4.Location = new Point(0, 26);
					panel3.Controls.Add(label4);
					label4.Text = STR.THRESHOLD[USR_INIT.mLanguage];
					label4.Size = new Size(72, 20);
					label4.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label4.Anchor = AnchorStyles.None;
					label4.TextAlign = ContentAlignment.MiddleLeft;
					label4.AutoSize = false;
					CnButton cnButton6 = new CnButton();
					panel_stacknew_visual.Controls.Add(cnButton6);
					cnButton6.Text = (new string[3] { "同步", "同步", "Sync" })[USR_INIT.mLanguage];
					cnButton6.Size = new Size(50, 26);
					cnButton6.BackColor = Color.Silver;
					cnButton6.Location = new Point(panel3.Size.Width + 2, 25);
					cnButton6.UseVisualStyleBackColor = true;
					cnButton6.Tag = 6;
					cnButton6.Click += button_stacknew_Hpara_synctoAllZn_Click;
					cnButton6.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
				}
				else
				{
					panel3.Controls.Add(label_threshold[num25 - 1]);
					label_threshold[num25 - 1].Text = "0";
					label_threshold[num25 - 1].Location = new Point(74 + 57 * (num25 - 1), 26);
					label_threshold[num25 - 1].Size = new Size(52, 20);
					label_threshold[num25 - 1].AutoSize = false;
					label_threshold[num25 - 1].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], lv_size, FontStyle.Regular);
					label_threshold[num25 - 1].Anchor = AnchorStyles.None;
					label_threshold[num25 - 1].Tag = num25 - 1;
					label_threshold[num25 - 1].MouseClick += label_threshold_MouseClick;
					label_threshold[num25 - 1].MouseHover += label_threshold_MouseHover;
					label_threshold[num25 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_threshold[num25 - 1].BackColor = Color.White;
					label_threshold[num25 - 1].BorderStyle = BorderStyle.None;
				}
			}
			label_pikH_head.Text = (USR2.mIsHOffsetMode ? (new string[3] { "下压(mm)", "下壓(mm)", "Offset(mm)" })[USR_INIT.mLanguage] : (new string[3] { "取料高度", "取料高度", "Pick-H" })[USR_INIT.mLanguage]);
			label_mntH_head.Text = (USR2.mIsHOffsetMode ? (new string[3] { "下压(mm)", "下壓(mm)", "Offset(mm)" })[USR_INIT.mLanguage] : (new string[3] { "贴装高度", "贴装高度", "Mount-H" })[USR_INIT.mLanguage]);
			button_pikH_Offset_Sync.Visible = USR2.mIsHOffsetMode;
			button_pikH_View.Visible = USR2.mIsHOffsetMode;
			button_pikH_Save.Visible = !USR2.mIsHOffsetMode;
			button_pikH_Goto.Visible = !USR2.mIsHOffsetMode;
			button_mntH_Offset_Sync.Visible = USR2.mIsHOffsetMode;
			button_mntH_View.Visible = USR2.mIsHOffsetMode;
			button_mntH_Save.Visible = !USR2.mIsHOffsetMode;
			button_mntH_Goto.Visible = !USR2.mIsHOffsetMode;
			button_pikBaseH.Visible = USR2.mIsHOffsetMode;
			button_mntBaseH.Visible = USR2.mIsHOffsetMode;
			if (mStackLib.sel == ProviderType.Feedr)
			{
				button_pikBaseH.Visible = false;
			}
			for (int num26 = 0; num26 < 8; num26++)
			{
				numericUpDown_pikoffset[num26].Visible = USR2.mIsHOffsetMode;
				label_stack_pikH[num26].Visible = !USR2.mIsHOffsetMode;
				numericUpDown_mntoffset[num26].Visible = USR2.mIsHOffsetMode;
				label_stack_mntH[num26].Visible = !USR2.mIsHOffsetMode;
			}
			button_goto_pikxy_byNozzle.Visible = true;
			button_goto_pikxy_byNozzle.BringToFront();
			stacksel_new_flushpage();
			stacksel_new_flushdata();
			stacksel_new_flushZn();
		}

		public void button_stacksel_MouseDown(object sender, MouseEventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			mStackLib.sel = (ProviderType)cnButton.Tag;
			stacksel_new_flushpage();
			stacksel_new_flushdata();
			stacksel_new_flushZn();
		}

		public void stacksel_new_flushpage()
		{
			label_stacksel_title.Text = STACK_SEL_STR[(int)mStackLib.sel][USR_INIT.mLanguage];
			for (int i = 0; i < 3; i++)
			{
				button_stacksel[i].CnSetPressDown(i == (int)mStackLib.sel);
			}
			label_Stack.Visible = false;
			label_StackPlate.Visible = false;
			label_Vibra.Visible = false;
			listBox_StackVibraAll.Visible = false;
			listBox_StackPlateAll.Visible = false;
			button_platexy.Visible = false;
			cnButton_stackplate_startIndex.Visible = false;
			panel6.Visible = true;
			if (mStackLib.sel == ProviderType.Feedr)
			{
				label_Stack.Visible = true;
				panel_stackplate_autoprovider.Visible = false;
				panel_feederdelay.Visible = true;
				button_goto_pikxy_byNozzle.Visible = true;
				CnButton cnButton = button_openfeeder;
				bool visible = (button_closefeeder.Visible = true);
				cnButton.Visible = visible;
				panel_plateXYlist.Visible = false;
				button_pikBaseH.Visible = false;
				button_mntBaseH.Visible = false;
				button_reback.Visible = false;
				button_autoPixXY.Visible = true;
			}
			else if (mStackLib.sel == ProviderType.Plate)
			{
				panel6.Visible = false;
				listBox_StackPlateAll.Visible = true;
				label_StackPlate.Visible = true;
				button_platexy.Visible = true;
				cnButton_stackplate_startIndex.Visible = true;
				button_reback.Visible = true;
				panel_stackplate_autoprovider.Visible = true;
				panel_feederdelay.Visible = false;
				button_goto_pikxy_byNozzle.Visible = false;
				CnButton cnButton2 = button_openfeeder;
				bool visible2 = (button_closefeeder.Visible = false);
				cnButton2.Visible = visible2;
				button_pikBaseH.Visible = USR2.mIsHOffsetMode;
				button_mntBaseH.Visible = false;
				button_autoPixXY.Visible = false;
			}
			else if (mStackLib.sel == ProviderType.Vibra)
			{
				button_reback.Visible = false;
				listBox_StackVibraAll.Visible = true;
				label_Vibra.Visible = true;
				panel_stackplate_autoprovider.Visible = false;
				panel_feederdelay.Visible = true;
				button_goto_pikxy_byNozzle.Visible = true;
				CnButton cnButton3 = button_openfeeder;
				bool visible3 = (button_closefeeder.Visible = false);
				cnButton3.Visible = visible3;
				panel_plateXYlist.Visible = false;
				button_pikBaseH.Visible = USR2.mIsHOffsetMode;
				button_mntBaseH.Visible = false;
				button_autoPixXY.Visible = false;
			}
		}

		public void stacksel_new_flushdata()
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			label_stacknew_chipinfo.Text = array[num].mChipFootprint + " " + array[num].mChipValue;
			label_stacknew_chipLmm.Text = array[num].lenght.ToString("F2");
			label_stacknew_chipWmm.Text = array[num].width.ToString("F2");
			label_stacknew_chipHmm.Text = array[num].height.ToString("F2");
			label_stackXY.Text = MainForm0.format_XY_label_string(array[num].mXY);
			CheckBox checkBox = checkBox_stackCollect;
			bool @checked = (panel_iscolloect.Visible = array[num].mIsCollect);
			checkBox.Checked = @checked;
			CheckBox checkBox2 = checkBox_isScanR;
			bool checked2 = (panel_isScanR.Visible = array[num].mIsScanR);
			checkBox2.Checked = checked2;
			numericUpDown_stackCollect.Value = (decimal)array[num].mCollectDelta;
			array[num].scanR = array[num].scanR % 921;
			label_scanR.Text = array[num].scanR.ToString();
			checkBox_is_hcam_special.Checked = array[num].mIsHCamSpecialPara;
			button_hcam_specialpara.Visible = array[num].mIsHCamSpecialPara;
			panel_hcam_special.Visible = array[num].mIsHCamSpecialPara;
			label_hcam_special_level.Text = array[num].HCamSpecial_ledlevel.ToString();
			trackBar_hcam_special_level.Value = array[num].HCamSpecial_ledlevel;
			if (array[num].scanR > trackBar_scanR.Maximum)
			{
				array[num].scanR = trackBar_scanR.Maximum;
			}
			trackBar_scanR.Value = array[num].scanR;
			if ((decimal)array[num].mFeederDelay > numericUpDown_feederdelay.Maximum)
			{
				array[num].mFeederDelay = (int)numericUpDown_feederdelay.Maximum;
			}
			if ((decimal)array[num].mFeederDelay < numericUpDown_feederdelay.Minimum)
			{
				array[num].mFeederDelay = (int)numericUpDown_feederdelay.Minimum;
			}
			numericUpDown_feederdelay.Value = array[num].mFeederDelay;
			VisualType visualtype = array[num].visualtype;
			CameraType cameratype = array[num].cameratype;
			label_stack_visual.Text = (new string[3] { "测试:", "測試:", "Test: " })[USR_INIT.mLanguage] + STR.VISUAL_STR[(int)visualtype][USR_INIT.mLanguage];
			button_PikToFastCam.BackColor = Color.Silver;
			button_PikToFastCam.ForeColor = Color.Black;
			button_PikToHighCam.BackColor = Color.Silver;
			button_PikToHighCam.ForeColor = Color.Black;
			switch (cameratype)
			{
			case CameraType.Fast:
				button_PikToFastCam.BackColor = Color.DimGray;
				button_PikToFastCam.ForeColor = Color.White;
				break;
			case CameraType.High:
				button_PikToHighCam.BackColor = Color.DimGray;
				button_PikToHighCam.ForeColor = Color.White;
				break;
			}
			label_angle.Text = array[num].angle.ToString("F2");
			if (mStackLib.sel == ProviderType.Feedr)
			{
				label_Stack.Text = (num + 1).ToString();
				button_pikBaseH.Text = (new string[3] { "飞达基准高度", "飛達基準高度", "Feeder Base-H" })[USR_INIT.mLanguage];
				label_feederstate.Text = (MainForm0.mIsFeederOn[mFn][num] ? (new string[3] { "已开", "已開", "Opened" })[USR_INIT.mLanguage] : (new string[3] { "已关", "已關", "Closed" })[USR_INIT.mLanguage]);
				label_feederstate.BackColor = (MainForm0.mIsFeederOn[mFn][num] ? Color.LightSalmon : Color.LightYellow);
				Label label = label29;
				bool visible = (label_angle.Visible = true);
				label.Visible = visible;
				button_pikBaseH.Visible = false;
				button_openfeeder.CnSetPressDown(MainForm0.mIsFeederOn[mFn][num]);
				if (MainForm0.mIsFeederOn[mFn][num])
				{
					button_openfeeder.Text = (new string[3] { "关飞达", "關飛達", "Close Feeder" })[USR_INIT.mLanguage];
				}
				else
				{
					button_openfeeder.Text = (new string[3] { "开飞达", "開飛達", "Open Feeder" })[USR_INIT.mLanguage];
				}
			}
			else if (mStackLib.sel == ProviderType.Plate)
			{
				label_StackPlate.Text = "P" + (num + 1);
				button_pikBaseH.Text = (new string[3] { "托盘", "托盤", "Plate " })[USR_INIT.mLanguage] + (num + 1) + "-" + (new string[3] { "最高基准点", "最高基準位", "Highest-Base-H" })[USR_INIT.mLanguage];
				Label label2 = label29;
				bool visible2 = (label_angle.Visible = false);
				label2.Visible = visible2;
			}
			else if (mStackLib.sel == ProviderType.Vibra)
			{
				label_Vibra.Text = "V" + (num + 1);
				button_pikBaseH.Text = (new string[3] { "振飞", "振飛", "Vibra " })[USR_INIT.mLanguage] + (num + 1) + "-" + (new string[3] { "最高基准点", "最高基準位", "Highest-Base-H" })[USR_INIT.mLanguage];
				Label label3 = label29;
				bool visible3 = (label_angle.Visible = true);
				label3.Visible = visible3;
			}
			if (mStackLib.sel == ProviderType.Plate)
			{
				checkBox_stackplate_AutoEntComponent.Checked = array[num].mPlt.mIsAutoEnt;
				numericUpDown_AutoEntTimeDelay.Value = (decimal)array[num].mPlt.mAutoEntTimeDelay;
				cnButton_stackplate_startIndex.Text = format_plate_startindex_str();
			}
			if (mStackLib.sel == ProviderType.Feedr)
			{
				flush_autopik();
			}
			else
			{
				panel_autopikxy.Visible = false;
			}
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				checkBox_stack_nozzleEn[i].Checked = array[num].mZnData[i].mEnabled;
				label_stack_pikH[i].Text = Math.Abs(array[num].mZnData[i].Pik.Height).ToString();
				numericUpDown_pikoffset[i].Value = (decimal)array[num].mZnData[i].Pik.Offset;
				label_threshold[i].Text = (Math.Abs(array[num].mZnData[i].threshold) % 256).ToString();
				if ((decimal)array[num].mZnData[i].Pik.DownSpeed > numericUpDown_stack_pikConfig[0][i].Maximum || (decimal)array[num].mZnData[i].Pik.DownSpeed < numericUpDown_stack_pikConfig[0][i].Minimum)
				{
					array[num].mZnData[i].Pik.DownSpeed = 64;
				}
				numericUpDown_stack_pikConfig[0][i].Value = array[num].mZnData[i].Pik.DownSpeed;
				if ((decimal)array[num].mZnData[i].Pik.UpSpeed > numericUpDown_stack_pikConfig[1][i].Maximum || (decimal)array[num].mZnData[i].Pik.UpSpeed < numericUpDown_stack_pikConfig[1][i].Minimum)
				{
					array[num].mZnData[i].Pik.UpSpeed = 64;
				}
				numericUpDown_stack_pikConfig[1][i].Value = array[num].mZnData[i].Pik.UpSpeed;
				if ((decimal)array[num].mZnData[i].Pik.Delay > numericUpDown_stack_pikConfig[2][i].Maximum || (decimal)array[num].mZnData[i].Pik.Delay < numericUpDown_stack_pikConfig[2][i].Minimum)
				{
					array[num].mZnData[i].Pik.Delay = 10;
				}
				numericUpDown_stack_pikConfig[2][i].Value = array[num].mZnData[i].Pik.Delay;
				if (array[num].mZnData[i].Mnt.Height <= -HW.mMaxZ[0])
				{
					array[num].mZnData[i].Mnt.Height = 0;
				}
				label_stack_mntH[i].Text = Math.Abs(array[num].mZnData[i].Mnt.Height).ToString();
				numericUpDown_mntoffset[i].Value = (decimal)array[num].mZnData[i].Mnt.Offset;
				if ((decimal)array[num].mZnData[i].Mnt.DownSpeed > numericUpDown_stack_mntConfig[0][i].Maximum || (decimal)array[num].mZnData[i].Mnt.DownSpeed < numericUpDown_stack_mntConfig[0][i].Minimum)
				{
					array[num].mZnData[i].Mnt.DownSpeed = 64;
				}
				numericUpDown_stack_mntConfig[0][i].Value = array[num].mZnData[i].Mnt.DownSpeed;
				if ((decimal)array[num].mZnData[i].Mnt.UpSpeed > numericUpDown_stack_mntConfig[1][i].Maximum || (decimal)array[num].mZnData[i].Mnt.UpSpeed < numericUpDown_stack_mntConfig[1][i].Minimum)
				{
					array[num].mZnData[i].Mnt.UpSpeed = 64;
				}
				numericUpDown_stack_mntConfig[1][i].Value = array[num].mZnData[i].Mnt.UpSpeed;
				if ((decimal)array[num].mZnData[i].Mnt.Delay > numericUpDown_stack_mntConfig[2][i].Maximum || (decimal)array[num].mZnData[i].Mnt.Delay < numericUpDown_stack_mntConfig[2][i].Minimum)
				{
					array[num].mZnData[i].Mnt.Delay = 10;
				}
				numericUpDown_stack_mntConfig[2][i].Value = array[num].mZnData[i].Mnt.Delay;
			}
			for (int j = 0; j < HW.mZnNum[mFn]; j++)
			{
				if (array[num].mZnData[j].mEnabled && j < HW.mZnNum[mFn])
				{
					MainForm0.radiobt_zn[mFn][j].Checked = true;
					MainForm0.msdelay(1);
					break;
				}
			}
			if (mStackLib.sel == ProviderType.Plate)
			{
				for (int k = 0; k < 4; k++)
				{
					lb_stackplate_XY[k].Text = MainForm0.format_XY_label_string(array[num].mPlt.mXYS[k]);
				}
				nud_stackplate_rows.Value = array[num].mPlt.mRowNum;
				nud_stackplate_columns.Value = array[num].mPlt.mColumnNum;
				if (array[num].mPlt.mXYlist == null)
				{
					array[num].mPlt.mXYlist = new BindingList<StackPlateXYElement>();
				}
				int num2 = 0;
				for (int l = 0; l < array[num].mPlt.mXYlist.Count; l++)
				{
					if (array[num].mPlt.mXYlist[l].mGuid == array[num].mPlt.mGuid)
					{
						num2++;
					}
				}
				array[num].mPlt.mTotalNum = num2;
				checkBox_addSubPlate.Checked = false;
				if (array[num].mPlt.mSubList == null)
				{
					array[num].mPlt.mSubList = new BindingList<sSubPlate>();
				}
				int count = array[num].mPlt.mSubList.Count;
				listBox_subPlate.Items.Clear();
				for (int m = 0; m < count + 1; m++)
				{
					listBox_subPlate.Items.Add(m + 1);
				}
				listBox_subPlate.SelectedIndex = 0;
			}
			if (mFormProviderHeight != null && !mFormProviderHeight.IsDisposed && !mFormProviderHeight.flush_table((int)mStackLib.sel))
			{
				mFormProviderHeight.Close();
				if (mFormProviderHeight_Feeder == null || mFormProviderHeight_Feeder.IsDisposed)
				{
					mFormProviderHeight_Feeder = new Form_ProviderHeight_Feeder(USR, USR2);
					mFormProviderHeight_Feeder.Location = new Point(562, 500);
					mFormProviderHeight_Feeder.Show();
					mFormProviderHeight_Feeder.TopMost = true;
				}
			}
			if (mFormProviderHeight_Feeder != null && !mFormProviderHeight_Feeder.IsDisposed && !mFormProviderHeight_Feeder.flush_table((int)mStackLib.sel))
			{
				mFormProviderHeight_Feeder.Close();
				if (mFormProviderHeight == null || mFormProviderHeight.IsDisposed)
				{
					mFormProviderHeight = new Form_ProviderHeight(USR, USR2);
					mFormProviderHeight.Location = new Point(562, 500);
					mFormProviderHeight.Show();
					mFormProviderHeight.TopMost = true;
				}
			}
			if (uc_pikCheckH != null && !uc_pikCheckH.IsDisposed)
			{
				uc_pikCheckH.Dispose();
			}
			if (uc_mntCheckH != null && !uc_mntCheckH.IsDisposed)
			{
				uc_mntCheckH.Dispose();
			}
		}

		public void stacksel_new_flushZn()
		{
			Color white = Color.White;
			Color whiteSmoke = Color.WhiteSmoke;
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			for (int i = 0; i < 8; i++)
			{
				if (!array[num].mZnData[i].mEnabled || i >= HW.mZnNum[mFn])
				{
					if (uc_pikCheckH != null && !uc_pikCheckH.IsDisposed)
					{
						uc_pikCheckH.set_enable(i, is_enable: false);
					}
					if (uc_mntCheckH != null && !uc_mntCheckH.IsDisposed)
					{
						uc_mntCheckH.set_enable(i, is_enable: false);
					}
					if (uc_pikCheckH != null && !uc_pikCheckH.IsDisposed)
					{
						uc_pikCheckH.set_bold(i, is_bold: false);
					}
					if (uc_mntCheckH != null && !uc_mntCheckH.IsDisposed)
					{
						uc_mntCheckH.set_bold(i, is_bold: false);
					}
					label_threshold[i].BackColor = whiteSmoke;
					label_stack_pikH[i].BackColor = whiteSmoke;
					for (int j = 0; j < 3; j++)
					{
						numericUpDown_stack_pikConfig[j][i].BackColor = whiteSmoke;
					}
					label_stack_mntH[i].BackColor = whiteSmoke;
					for (int k = 0; k < 3; k++)
					{
						numericUpDown_stack_mntConfig[k][i].BackColor = whiteSmoke;
					}
					Color color3 = (numericUpDown_pikoffset[i].BackColor = (numericUpDown_mntoffset[i].BackColor = whiteSmoke));
					label_threshold[i].Enabled = false;
					label_stack_pikH[i].Enabled = false;
					numericUpDown_pikoffset[i].Enabled = false;
					numericUpDown_mntoffset[i].Enabled = false;
					label_stack_pikZnName[i].Enabled = false;
					for (int l = 0; l < 3; l++)
					{
						numericUpDown_stack_pikConfig[l][i].Enabled = false;
					}
					label_stack_mntH[i].Enabled = false;
					label_stack_mntZnName[i].Enabled = false;
					for (int m = 0; m < 3; m++)
					{
						numericUpDown_stack_mntConfig[m][i].Enabled = false;
					}
					label_threshold[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_threshold[i].Font.Size, FontStyle.Regular);
					label_stack_pikH[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_stack_pikH[i].Font.Size, FontStyle.Regular);
					label_stack_pikZnName[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label_stack_pikZnName[i].Font.Size, FontStyle.Regular);
					for (int n = 0; n < 3; n++)
					{
						numericUpDown_stack_pikConfig[n][i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], numericUpDown_stack_pikConfig[n][i].Font.Size, FontStyle.Regular);
					}
					label_stack_mntH[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_stack_mntH[i].Font.Size, FontStyle.Regular);
					label_stack_mntZnName[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label_stack_mntZnName[i].Font.Size, FontStyle.Regular);
					for (int num2 = 0; num2 < 3; num2++)
					{
						numericUpDown_stack_mntConfig[num2][i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], numericUpDown_stack_mntConfig[num2][i].Font.Size, FontStyle.Regular);
					}
					Font font3 = (numericUpDown_pikoffset[i].Font = (numericUpDown_mntoffset[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_stack_pikH[i].Font.Size, FontStyle.Regular)));
					continue;
				}
				if (uc_pikCheckH != null && !uc_pikCheckH.IsDisposed)
				{
					uc_pikCheckH.set_enable(i, is_enable: true);
				}
				if (uc_mntCheckH != null && !uc_mntCheckH.IsDisposed)
				{
					uc_mntCheckH.set_enable(i, is_enable: true);
				}
				label_threshold[i].BackColor = white;
				label_stack_pikH[i].BackColor = white;
				for (int num3 = 0; num3 < 3; num3++)
				{
					numericUpDown_stack_pikConfig[num3][i].BackColor = white;
				}
				label_stack_mntH[i].BackColor = white;
				for (int num4 = 0; num4 < 3; num4++)
				{
					numericUpDown_stack_mntConfig[num4][i].BackColor = white;
				}
				Color color6 = (numericUpDown_pikoffset[i].BackColor = (numericUpDown_mntoffset[i].BackColor = white));
				label_threshold[i].Enabled = true;
				label_stack_pikH[i].Enabled = true;
				numericUpDown_pikoffset[i].Enabled = true;
				numericUpDown_mntoffset[i].Enabled = true;
				label_stack_pikZnName[i].Enabled = true;
				for (int num5 = 0; num5 < 3; num5++)
				{
					numericUpDown_stack_pikConfig[num5][i].Enabled = true;
				}
				label_stack_mntH[i].Enabled = true;
				label_stack_mntZnName[i].Enabled = true;
				for (int num6 = 0; num6 < 3; num6++)
				{
					numericUpDown_stack_mntConfig[num6][i].Enabled = true;
				}
				if (i == MainForm0.mZn[mFn])
				{
					if (uc_pikCheckH != null && !uc_pikCheckH.IsDisposed)
					{
						uc_pikCheckH.set_bold(i, is_bold: true);
					}
					if (uc_mntCheckH != null && !uc_mntCheckH.IsDisposed)
					{
						uc_mntCheckH.set_bold(i, is_bold: true);
					}
					label_threshold[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_threshold[i].Font.Size, FontStyle.Bold);
					label_stack_pikH[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_stack_pikH[i].Font.Size, FontStyle.Bold);
					label_stack_pikZnName[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label_stack_pikZnName[i].Font.Size, FontStyle.Bold);
					for (int num7 = 0; num7 < 3; num7++)
					{
						numericUpDown_stack_pikConfig[num7][i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], numericUpDown_stack_pikConfig[num7][i].Font.Size, FontStyle.Bold);
					}
					label_stack_mntH[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_stack_mntH[i].Font.Size, FontStyle.Bold);
					label_stack_mntZnName[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label_stack_mntZnName[i].Font.Size, FontStyle.Bold);
					for (int num8 = 0; num8 < 3; num8++)
					{
						numericUpDown_stack_mntConfig[num8][i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], numericUpDown_stack_mntConfig[num8][i].Font.Size, FontStyle.Bold);
					}
					Font font6 = (numericUpDown_pikoffset[i].Font = (numericUpDown_mntoffset[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], numericUpDown_pikoffset[i].Font.Size, FontStyle.Bold)));
				}
				else
				{
					if (uc_pikCheckH != null && !uc_pikCheckH.IsDisposed)
					{
						uc_pikCheckH.set_bold(i, is_bold: false);
					}
					if (uc_mntCheckH != null && !uc_mntCheckH.IsDisposed)
					{
						uc_mntCheckH.set_bold(i, is_bold: false);
					}
					label_threshold[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_threshold[i].Font.Size, FontStyle.Regular);
					label_stack_pikH[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_stack_pikH[i].Font.Size, FontStyle.Regular);
					label_stack_pikZnName[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label_stack_pikZnName[i].Font.Size, FontStyle.Regular);
					for (int num9 = 0; num9 < 3; num9++)
					{
						numericUpDown_stack_pikConfig[num9][i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], numericUpDown_stack_pikConfig[num9][i].Font.Size, FontStyle.Regular);
					}
					label_stack_mntH[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], label_stack_mntH[i].Font.Size, FontStyle.Regular);
					label_stack_mntZnName[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label_stack_mntZnName[i].Font.Size, FontStyle.Regular);
					for (int num10 = 0; num10 < 3; num10++)
					{
						numericUpDown_stack_mntConfig[num10][i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], numericUpDown_stack_mntConfig[num10][i].Font.Size, FontStyle.Regular);
					}
					Font font9 = (numericUpDown_pikoffset[i].Font = (numericUpDown_mntoffset[i].Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], numericUpDown_pikoffset[i].Font.Size, FontStyle.Regular)));
				}
			}
			if (mFormProviderHeight != null && !mFormProviderHeight.IsDisposed)
			{
				mFormProviderHeight.flush_zn();
			}
			if (mFormProviderHeight_Feeder != null && !mFormProviderHeight_Feeder.IsDisposed)
			{
				mFormProviderHeight_Feeder.flush_zn();
			}
		}

		private void init_view()
		{
			int num = 23;
			int num2 = 3;
			int num3 = 160;
			for (int i = 0; i < 2; i++)
			{
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				switch (i)
				{
				case 0:
					num4 = panel_feeder.Location.X + num;
					num5 = panel_feeder.Location.Y + panel_feeder.Size.Height + num2;
					num6 = panel_feeder.Location.X + num;
					num7 = panel_feeder.Location.Y + panel_feeder.Size.Height + num2 + num + num2;
					break;
				case 1:
					num4 = panel_feeder.Location.X + num;
					num5 = panel_feeder.Location.Y - num2 - num;
					num6 = panel_feeder.Location.X + num;
					num7 = panel_feeder.Location.Y - num2 - num - num2 - num3;
					break;
				}
				int num8 = HW.malgo2[mFn].len[i] - HW.malgo2[mFn].emp_l[i] - HW.malgo2[mFn].emp_r[i];
				int num9 = panel_feeder.Size.Width / num8;
				for (int j = 0; j < HW.malgo2[mFn].len[i]; j++)
				{
					int num10 = MainForm0.format_stackno(mFn, i, j);
					if (num10 >= 0 && num10 < HW.mStackNum[mFn][0])
					{
						Label label = new Label();
						panel1.Controls.Add(label);
						label.AutoSize = false;
						label.Size = new Size(num, num);
						label.Location = new Point(num4 + num9 * (j - HW.malgo2[mFn].emp_l[i]), num5);
						label.Text = (num10 + 1).ToString();
						label.BorderStyle = BorderStyle.FixedSingle;
						label.BackColor = (mStackLib.stacktab[0][num10].mEnabled ? Color.LightSkyBlue : Color.Gray);
						label.TextAlign = ContentAlignment.MiddleCenter;
						Label label2 = new Label();
						panel1.Controls.Add(label2);
						label2.AutoSize = false;
						label2.Size = new Size(num, num3);
						label2.Location = new Point(num6 + num9 * (j - HW.malgo2[mFn].emp_l[i]), num7);
						label2.BorderStyle = BorderStyle.FixedSingle;
						label2.BackColor = (mStackLib.stacktab[0][num10].mEnabled ? Color.LightSkyBlue : Color.Gray);
						string text = mStackLib.stacktab[0][num10].mChipFootprint + "-" + mStackLib.stacktab[0][num10].mChipValue;
						label2.Text = (mStackLib.stacktab[0][num10].mEnabled ? text : "");
						label2.Visible = mStackLib.stacktab[0][num10].mEnabled;
						label2.TextAlign = ContentAlignment.TopCenter;
						label2.Font = new Font("Lucida Console", 9.5f, FontStyle.Regular);
					}
				}
			}
			num = 23;
			num2 = 3;
			num3 = 160;
			for (int k = 0; k < HW.mStackNum[mFn][1]; k++)
			{
				int num11 = k / (HW.mStackNum[mFn][1] / 2 + HW.mStackNum[mFn][1] % 2);
				int num12 = k % (HW.mStackNum[mFn][1] / 2 + HW.mStackNum[mFn][1] % 2);
				int num13 = panel_plate.Size.Width / 2 * num11 + 10;
				int num14 = (num + num2) * num12 + 10;
				int num15 = num13 + num + num2;
				int num16 = (num + num2) * num12 + 10;
				Label label3 = new Label();
				panel_plate.Controls.Add(label3);
				label3.AutoSize = false;
				label3.Size = new Size(num, num);
				label3.Location = new Point(num13, num14);
				label3.Text = (k + 1).ToString();
				label3.BorderStyle = BorderStyle.FixedSingle;
				label3.BackColor = (mStackLib.stacktab[1][k].mEnabled ? Color.LightSkyBlue : Color.Gray);
				label3.TextAlign = ContentAlignment.MiddleCenter;
				Label label4 = new Label();
				panel_plate.Controls.Add(label4);
				label4.AutoSize = false;
				label4.Size = new Size(num3, num);
				label4.Location = new Point(num15, num16);
				string text2 = mStackLib.stacktab[1][k].mChipFootprint + "-" + mStackLib.stacktab[1][k].mChipValue;
				label4.Text = (mStackLib.stacktab[1][k].mEnabled ? text2 : "");
				label4.BorderStyle = BorderStyle.FixedSingle;
				label4.BackColor = (mStackLib.stacktab[1][k].mEnabled ? Color.LightSkyBlue : Color.Gray);
				label4.Visible = mStackLib.stacktab[1][k].mEnabled;
				label4.TextAlign = ContentAlignment.MiddleLeft;
				label4.Font = new Font("Lucida Console", 9.5f, FontStyle.Regular);
			}
			num = 23;
			num2 = 3;
			num3 = 160;
			for (int l = 0; l < HW.mStackNum[mFn][2]; l++)
			{
				int num17 = l / (HW.mStackNum[mFn][2] / 2 + HW.mStackNum[mFn][2] % 2);
				int num18 = l % (HW.mStackNum[mFn][2] / 2 + HW.mStackNum[mFn][2] % 2);
				int num19 = panel_vibra.Size.Width / 2 * num17 + 10;
				int num20 = (num + num2) * num18 + 10;
				int num21 = num19 + num + num2;
				int num22 = (num + num2) * num18 + 10;
				Label label5 = new Label();
				panel_vibra.Controls.Add(label5);
				label5.AutoSize = false;
				label5.Size = new Size(num, num);
				label5.Location = new Point(num19, num20);
				label5.Text = (l + 1).ToString();
				label5.BorderStyle = BorderStyle.FixedSingle;
				label5.BackColor = (mStackLib.stacktab[2][l].mEnabled ? Color.LightSkyBlue : Color.Gray);
				label5.TextAlign = ContentAlignment.MiddleCenter;
				Label label6 = new Label();
				panel_vibra.Controls.Add(label6);
				label6.AutoSize = false;
				label6.Size = new Size(num3, num);
				label6.Location = new Point(num21, num22);
				string text3 = mStackLib.stacktab[2][l].mChipFootprint + "-" + mStackLib.stacktab[2][l].mChipValue;
				label6.Text = (mStackLib.stacktab[2][l].mEnabled ? text3 : "");
				label6.BorderStyle = BorderStyle.FixedSingle;
				label6.BackColor = (mStackLib.stacktab[2][l].mEnabled ? Color.LightSkyBlue : Color.Gray);
				label6.Visible = mStackLib.stacktab[2][l].mEnabled;
				label6.TextAlign = ContentAlignment.MiddleLeft;
				label6.Font = new Font("Lucida Console", 9.5f, FontStyle.Regular);
			}
		}

		public int StackPlateListBoxIndex(int stackNo)
		{
			return stackNo % (HW.mStackNum[mFn][1] / 3) * 3 + stackNo / (HW.mStackNum[mFn][1] / 3);
		}

		private void listBox_StackPlateAll_MouseClick(object sender, MouseEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			int selectedIndex = listBox.SelectedIndex;
			int num = StackPlateNo(selectedIndex);
			mStackLib.index[1] = num;
			label_StackPlate.Text = "P" + (mStackLib.index[1] + 1);
			stacksel_new_flushdata();
			stacksel_new_flushZn();
		}

		public int StackPlateNo(int index)
		{
			int num = index % 3;
			int num2 = index / 3;
			return num * (HW.mStackNum[mFn][1] / 3) + num2;
		}

		private void listBox_StackPlateAll_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
			{
				return;
			}
			int num = StackPlateNo(e.Index);
			if (num != -1)
			{
				e.DrawBackground();
				if (mStackLib.stacktab[1][num].mSelected)
				{
					Brush black = Brushes.Black;
					e.DrawFocusRectangle();
					e.Graphics.DrawString(listBox_StackPlateAll.Items[e.Index].ToString(), new Font(e.Font, FontStyle.Bold), black, e.Bounds, StringFormat.GenericTypographic);
				}
				else
				{
					Brush black = Brushes.Gray;
					e.DrawFocusRectangle();
					e.Graphics.DrawString(listBox_StackPlateAll.Items[e.Index].ToString(), e.Font, black, e.Bounds, StringFormat.GenericTypographic);
				}
			}
		}

		private void listBox_StackVibraAll_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
			{
				return;
			}
			int index = e.Index;
			if (index != -1)
			{
				e.DrawBackground();
				if (mStackLib.stacktab[2][index].mSelected)
				{
					Brush black = Brushes.Black;
					e.DrawFocusRectangle();
					e.Graphics.DrawString(listBox_StackVibraAll.Items[e.Index].ToString(), new Font(e.Font, FontStyle.Bold), black, e.Bounds, StringFormat.GenericTypographic);
				}
				else
				{
					Brush black = Brushes.Gray;
					e.DrawFocusRectangle();
					e.Graphics.DrawString(listBox_StackVibraAll.Items[e.Index].ToString(), e.Font, black, e.Bounds, StringFormat.GenericTypographic);
				}
			}
		}

		private void listBox_StackVibraAll_MouseClick(object sender, MouseEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			int selectedIndex = listBox.SelectedIndex;
			int num = selectedIndex;
			mStackLib.index[2] = num;
			label_Vibra.Text = "V" + (selectedIndex + 1);
			stacksel_new_flushdata();
			stacksel_new_flushZn();
		}

		public string format_plate_startindex_str()
		{
			StackElement[] array = mStackLib.stacktab[1];
			int num = mStackLib.index[1];
			if (array[num].mPlt.mXYlist == null)
			{
				array[num].mPlt.mXYlist = new BindingList<StackPlateXYElement>();
			}
			if (array[num].mPlt.mStartIndex < array[num].mPlt.mXYlist.Count)
			{
				int sub = 0;
				int r = 0;
				int c = 0;
				startIndex_plate(array[num].mPlt.mStartIndex, ref sub, ref r, ref c);
				return STR.START_IDX[USR_INIT.mLanguage] + (sub + 1) + ": " + (r + 1) + "-" + (c + 1);
			}
			return STR.START_IDX[USR_INIT.mLanguage] + "-" + STR.EMPTY_PLATE[USR_INIT.mLanguage];
		}

		private void startIndex_plate(int startindex, ref int sub, ref int r, ref int c)
		{
			StackElement[] array = mStackLib.stacktab[1];
			int num = mStackLib.index[1];
			sub = 0;
			r = 0;
			c = 0;
			if (array[num].mPlt.mXYlist == null || array[num].mPlt.mXYlist.Count <= 0)
			{
				return;
			}
			if (startindex >= array[num].mPlt.mXYlist.Count)
			{
				MessageBox.Show((USR_INIT.mLanguage == 2) ? "Plate start pick-XY is out of range--!" : "料盘起始取料索引超出有效范围--！");
			}
			else if (startindex < array[num].mPlt.mRowNum * array[num].mPlt.mColumnNum)
			{
				sub = 0;
				r = startindex / array[num].mPlt.mColumnNum;
				c = startindex % array[num].mPlt.mColumnNum;
			}
			else
			{
				if (array[num].mPlt.mSubList == null || array[num].mPlt.mSubList.Count <= 0)
				{
					return;
				}
				int num2 = startindex - array[num].mPlt.mTotalNum;
				sub = 1;
				for (int i = 0; i < array[num].mPlt.mSubList.Count; i++)
				{
					if (num2 < array[num].mPlt.mSubList[i].mTotalNum)
					{
						r = num2 / array[num].mPlt.mSubList[i].mColumnNum;
						c = num2 % array[num].mPlt.mSubList[i].mColumnNum;
						break;
					}
					sub++;
					num2 -= array[num].mPlt.mSubList[i].mTotalNum;
				}
			}
		}

		private int startIndex_plate(int subindex, int r, int c)
		{
			StackElement[] array = mStackLib.stacktab[1];
			int num = mStackLib.index[1];
			int num2 = 0;
			if (array[num].mPlt.mXYlist != null && array[num].mPlt.mXYlist.Count > 0)
			{
				if (subindex == 0)
				{
					num2 = r * array[num].mPlt.mColumnNum + c;
				}
				else if (subindex > 0 && array[num].mPlt.mSubList != null && subindex <= array[num].mPlt.mSubList.Count)
				{
					num2 = array[num].mPlt.mRowNum * array[num].mPlt.mColumnNum;
					for (int i = 0; i < subindex - 1; i++)
					{
						num2 += array[num].mPlt.mSubList[i].mTotalNum;
					}
					num2 += r * array[num].mPlt.mSubList[subindex - 1].mColumnNum + c;
				}
			}
			if (num2 >= array[num].mPlt.mXYlist.Count)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Plate start pick-XY is out of range!" : "料盘起始取料索引超出有效范围！");
				num2 = 0;
			}
			return num2;
		}

		private void label_Stack_MouseHover_1(object sender, EventArgs e)
		{
			UserControl_Stack_feedersel2 userControl_Stack_feedersel = new UserControl_Stack_feedersel2(mStackLib.sel, mStackLib);
			userControl_Stack_feedersel.Location = new Point(350, 50);
			MainForm0.static_this.Controls.Add(userControl_Stack_feedersel);
			userControl_Stack_feedersel.callback_flush_feederno = (void_Func_void)Delegate.Combine(userControl_Stack_feedersel.callback_flush_feederno, new void_Func_void(callback_flush_feederno));
			userControl_Stack_feedersel.BringToFront();
		}

		public void callback_flush_feederno()
		{
			label_Stack.Text = (mStackLib.index[(int)mStackLib.sel] + 1).ToString();
			stacksel_new_flushdata();
			stacksel_new_flushZn();
		}

		private void stack_label_MouseClick(object sender, MouseEventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = (int)((Label)sender).Tag;
			if (num2 != -1)
			{
				num2 %= 8;
				if (num2 >= 0 && num2 < HW.mZnNum[mFn] && array[num].mZnData[num2].mEnabled)
				{
					MainForm0.radiobt_zn[mFn][num2].Checked = true;
					stacksel_new_flushZn();
				}
			}
		}

		private void label_stack_PikH_DoubleClick(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = (int)((Label)sender).Tag;
			if (num2 == -1)
			{
				return;
			}
			num2 %= 8;
			if (num2 < 0 || num2 >= HW.mZnNum[mFn] || !array[num].mZnData[num2].mEnabled)
			{
				return;
			}
			MainForm0.radiobt_zn[mFn][num2].Checked = true;
			stacksel_new_flushZn();
			Form_FillXY form_FillXY = new Form_FillXY(array[num].mZnData[num2].Pik.Height, USR_INIT.mLanguage, "Z");
			form_FillXY.TopMost = true;
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				int value = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 0)
				{
					value = Math.Abs(value) * ((num2 % 2 != 0) ? 1 : (-1));
				}
				array[num].mZnData[num2].Pik.Height = value;
				label_stack_pikH[num2].Text = Math.Abs(value).ToString();
			}
		}

		private void label_stack_mntH_DoubleClick(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = (int)((Label)sender).Tag;
			if (num2 == -1)
			{
				return;
			}
			num2 %= 8;
			if (num2 < 0 || num2 >= HW.mZnNum[mFn] || !array[num].mZnData[num2].mEnabled)
			{
				return;
			}
			MainForm0.radiobt_zn[mFn][num2].Checked = true;
			stacksel_new_flushZn();
			Form_FillXY form_FillXY = new Form_FillXY(array[num].mZnData[num2].Mnt.Height, USR_INIT.mLanguage, "Z");
			form_FillXY.TopMost = true;
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				int value = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 0)
				{
					value = Math.Abs(value) * ((num2 % 2 != 0) ? 1 : (-1));
				}
				array[num].mZnData[num2].Mnt.Height = value;
				label_stack_mntH[num2].Text = Math.Abs(value).ToString();
			}
		}

		private void stack_numeric_MouseClick(object sender, MouseEventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = (int)((NumericUpDown)sender).Tag;
			if (num2 != -1)
			{
				num2 %= 8;
				if (num2 >= 0 && num2 < HW.mZnNum[mFn] && array[num].mZnData[num2].mEnabled)
				{
					MainForm0.radiobt_zn[mFn][num2].Checked = true;
					stacksel_new_flushZn();
				}
			}
		}

		private void label_threshold_MouseClick(object sender, MouseEventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			Label label = (Label)sender;
			int num2 = (int)label.Tag;
			if (num2 == -1)
			{
				return;
			}
			num2 %= 8;
			if (num2 >= 0 && num2 < HW.mZnNum[mFn] && array[num].mZnData[num2].mEnabled)
			{
				if (tbar_threshold != null && !tbar_threshold.IsDisposed)
				{
					tbar_threshold.Dispose();
					tbar_threshold = null;
				}
				tbar_threshold = new TrackBar();
				panel_stackselNew_Page.Controls.Add(tbar_threshold);
				tbar_threshold.Orientation = Orientation.Vertical;
				tbar_threshold.Minimum = 0;
				tbar_threshold.Maximum = 255;
				tbar_threshold.TickFrequency = 20;
				tbar_threshold.Size = new Size(30, 234);
				tbar_threshold.BackColor = Color.Salmon;
				tbar_threshold.MouseLeave += tbar_threshold_MouseLeave;
				tbar_threshold.ValueChanged += tbar_threshold_ValueChanged;
				tbar_threshold.Show();
				tbar_threshold.Location = new Point(panel_context2.Location.X + panel_stacknew_visual.Location.X + 80 + 59 * num2, 510);
				tbar_threshold.BringToFront();
				tbar_threshold.Tag = num2;
				tbar_threshold.Value = array[num].mZnData[num2].threshold % 256;
				MainForm0.radiobt_zn[mFn][num2].Checked = true;
				stacksel_new_flushZn();
			}
		}

		private void label_threshold_MouseHover(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			Label label = (Label)sender;
			int num2 = (int)label.Tag;
			if (num2 == -1)
			{
				return;
			}
			num2 %= 8;
			if (num2 == MainForm0.mZn[mFn] && array[num].mZnData[num2].mEnabled)
			{
				if (tbar_threshold != null && !tbar_threshold.IsDisposed)
				{
					tbar_threshold.Dispose();
					tbar_threshold = null;
				}
				tbar_threshold = new TrackBar();
				panel_stackselNew_Page.Controls.Add(tbar_threshold);
				tbar_threshold.Orientation = Orientation.Vertical;
				tbar_threshold.Minimum = 0;
				tbar_threshold.Maximum = 255;
				tbar_threshold.TickFrequency = 20;
				tbar_threshold.Size = new Size(30, 234);
				tbar_threshold.BackColor = Color.Salmon;
				tbar_threshold.MouseLeave += tbar_threshold_MouseLeave;
				tbar_threshold.Show();
				tbar_threshold.ValueChanged += tbar_threshold_ValueChanged;
				tbar_threshold.Tag = num2;
				tbar_threshold.Location = new Point(panel_context2.Location.X + panel_stacknew_visual.Location.X + 80 + 59 * num2, 510);
				tbar_threshold.Value = array[num].mZnData[num2].threshold % 256;
				tbar_threshold.BringToFront();
			}
		}

		private void tbar_threshold_MouseLeave(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			trackBar.Dispose();
		}

		private void tbar_threshold_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			TrackBar trackBar = (TrackBar)sender;
			int num2 = (int)trackBar.Tag;
			array[num].mZnData[num2].threshold = tbar_threshold.Value;
			label_threshold[num2].Text = array[num].mZnData[num2].threshold.ToString();
		}

		private void nud_stack_PikPara_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			int num2 = (int)numericUpDown.Tag;
			int num3 = num2 / 24;
			num2 %= 24;
			int num4 = num2 / 8;
			int num5 = num2 % 8;
			int num6 = 0;
			switch (num3)
			{
			case 0:
				switch (num4)
				{
				case 0:
					num6 = array[num].mZnData[num5].Pik.DownSpeed;
					break;
				case 1:
					num6 = array[num].mZnData[num5].Pik.UpSpeed;
					break;
				case 2:
					num6 = array[num].mZnData[num5].Pik.Delay;
					break;
				}
				if (num6 != (int)numericUpDown.Value)
				{
					switch (num4)
					{
					case 0:
						array[num].mZnData[num5].Pik.DownSpeed = (int)numericUpDown.Value;
						break;
					case 1:
						array[num].mZnData[num5].Pik.UpSpeed = (int)numericUpDown.Value;
						break;
					case 2:
						array[num].mZnData[num5].Pik.Delay = (int)numericUpDown.Value;
						break;
					}
				}
				break;
			case 1:
				switch (num4)
				{
				case 0:
					num6 = array[num].mZnData[num5].Mnt.DownSpeed;
					break;
				case 1:
					num6 = array[num].mZnData[num5].Mnt.UpSpeed;
					break;
				case 2:
					num6 = array[num].mZnData[num5].Mnt.Delay;
					break;
				}
				if (num6 != (int)numericUpDown.Value)
				{
					switch (num4)
					{
					case 0:
						array[num].mZnData[num5].Mnt.DownSpeed = (int)numericUpDown.Value;
						break;
					case 1:
						array[num].mZnData[num5].Mnt.UpSpeed = (int)numericUpDown.Value;
						break;
					case 2:
						array[num].mZnData[num5].Mnt.Delay = (int)numericUpDown.Value;
						break;
					}
				}
				break;
			}
			_ = (int)numericUpDown.Value;
		}

		private void nud_stack_Para_MouseUp(object sender, EventArgs e)
		{
			MainForm0.save_usrProjectData();
		}

		private void numericUpDown_stack_threshold_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			int num2 = (int)numericUpDown.Tag;
			int threshold = array[num].mZnData[num2].threshold;
			if (threshold != (int)numericUpDown.Value)
			{
				array[num].mZnData[num2].threshold = (int)numericUpDown.Value;
			}
			_ = (int)numericUpDown.Value;
		}

		private void numericUpDown_pik_offset_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			int num2 = (int)numericUpDown.Tag;
			float offset = array[num].mZnData[num2].Pik.Offset;
			if (offset != (float)numericUpDown.Value)
			{
				array[num].mZnData[num2].Pik.Offset = (float)numericUpDown.Value;
			}
			if (offset != (float)numericUpDown.Value && uc_pikCheckH != null && !uc_pikCheckH.IsDisposed)
			{
				uc_pikCheckH.flush_height();
			}
		}

		private void numericUpDown_mnt_offset_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			int num2 = (int)numericUpDown.Tag;
			float offset = array[num].mZnData[num2].Mnt.Offset;
			if (offset != (float)numericUpDown.Value)
			{
				array[num].mZnData[num2].Mnt.Offset = (float)numericUpDown.Value;
			}
			if (offset != (float)numericUpDown.Value && uc_mntCheckH != null && !uc_mntCheckH.IsDisposed)
			{
				uc_mntCheckH.flush_height();
			}
		}

		private void checkBox_stack_nozzleEn_CheckedChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			CheckBox checkBox = (CheckBox)sender;
			int num2 = (int)checkBox.Tag;
			if (checkBox_stack_nozzleEn[num2].Checked != array[num].mZnData[num2].mEnabled)
			{
				array[num].mZnData[num2].mEnabled = checkBox_stack_nozzleEn[num2].Checked;
				MainForm0.save_usrProjectData();
			}
			stacksel_new_flushZn();
		}

		private void button_close_Click_1(object sender, EventArgs e)
		{
			base.Visible = false;
		}

		private void button_openfeeder_Click(object sender, EventArgs e)
		{
		}

		private void button_closefeeder_Click(object sender, EventArgs e)
		{
		}

		private void button_openfeeder_MouseDown(object sender, MouseEventArgs e)
		{
			int num = mStackLib.index[(int)mStackLib.sel];
			MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num, !MainForm0.mIsFeederOn[mFn][num]);
			MainForm0.mIsFeederOn[mFn][num] = !MainForm0.mIsFeederOn[mFn][num];
			button_openfeeder.Text = (MainForm0.mIsFeederOn[mFn][num] ? (new string[3] { "关飞达", "關飛達", "Close Feeder" })[USR_INIT.mLanguage] : (new string[3] { "开飞达", "開飛達", "Open Feeder" })[USR_INIT.mLanguage]);
		}

		private void label_feederstate_Click(object sender, EventArgs e)
		{
		}

		private void button_stackSaveXY_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			string text = "";
			if (mStackLib.sel == ProviderType.Feedr && Math.Abs(MainForm0.mCur[mFn].x - USR.mSlotAllCoord[num].X) >= HW.mSlotPitch / 2)
			{
				text = ((USR_INIT.mLanguage == 2) ? "Current X is much far from the valid slot position, " : "当前坐标和要保存的料站坐标X方向偏差太大，有坐标错误可能，");
			}
			string text2 = ((USR_INIT.mLanguage == 2) ? "Update Feeder" : "确定更新料站") + (num + 1) + ((USR_INIT.mLanguage == 2) ? " XY Pick List?" : "的XY取料坐标列表吗？");
			text2 = text + text2;
			if (MainForm0.CmMessageBox(text2, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				array[num].mXY.X = MainForm0.mCur[mFn].x;
				array[num].mXY.Y = MainForm0.mCur[mFn].y;
				MainForm0.save_usrProjectData();
				label_stackXY.Text = MainForm0.format_XY_label_string(array[num].mXY);
			}
		}

		private void button_stackMoveToXY_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			string text = (string)((Button)sender).Tag;
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: false);
				MainForm0.mark_light_on_ext(mFn, flag: true);
				MainForm0.mark_led_on_ext(mFn, flag: true);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				Coordinate coordinate = new Coordinate(array[num].mXY.X, array[num].mXY.Y);
				if (text == "1")
				{
					coordinate.X -= USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].X;
					coordinate.Y -= USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].Y;
				}
				thread.IsBackground = true;
				thread.Start(coordinate);
			}
		}

		private void label_stackXY_DoubleClick(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			Form_FillXY form_FillXY = new Form_FillXY(array[num].mXY, USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				array[num].mXY.X = fillXY.X;
				array[num].mXY.Y = fillXY.Y;
				MainForm0.save_usrProjectData();
				label_stackXY.Text = MainForm0.format_XY_label_string(array[num].mXY);
			}
		}

		private void button_gotoNextStack_Click(object sender, EventArgs e)
		{
			string text = (string)((Button)sender).Tag;
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = 0;
			if (mStackLib.sel != 0)
			{
				return;
			}
			array = USR2.mStackLib.stacktab[0];
			if (text == "next")
			{
				if (num < HW.mStackNum[mFn][0] - 1)
				{
					bool flag = false;
					for (int i = num + 1; i < HW.mStackNum[mFn][0]; i++)
					{
						if (array[i].mSelected)
						{
							flag = true;
							num2 = (num = i);
							break;
						}
					}
					if (!flag)
					{
						return;
					}
				}
			}
			else if (text == "prev" && num < HW.mStackNum[mFn][0])
			{
				bool flag2 = false;
				for (int num3 = num - 1; num3 >= 0; num3--)
				{
					if (array[num3].mSelected)
					{
						flag2 = true;
						num2 = (num = num3);
						break;
					}
				}
				if (!flag2)
				{
					return;
				}
			}
			mStackLib.index[(int)mStackLib.sel] = num2;
			stacksel_new_flushdata();
			stacksel_new_flushZn();
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				Coordinate parameter = new Coordinate(array[num2].mXY.X, array[num2].mXY.Y);
				thread.IsBackground = true;
				thread.Start(parameter);
			}
		}

		private void numericUpDown_feederdelay_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = (int)numericUpDown_feederdelay.Value;
			if (num2 != array[num].mFeederDelay)
			{
				array[num].mFeederDelay = num2;
				MainForm0.save_usrProjectData();
			}
		}

		private void numericUpDown_AutoEntTimeDelay_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			float num2 = (float)numericUpDown_AutoEntTimeDelay.Value;
			if (num2 != array[num].mPlt.mAutoEntTimeDelay)
			{
				array[num].mPlt.mAutoEntTimeDelay = num2;
				MainForm0.save_usrProjectData();
			}
		}

		private void checkBox_stackplate_AutoEntComponent_CheckedChanged_1(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			bool @checked = checkBox_stackplate_AutoEntComponent.Checked;
			if (@checked != array[num].mPlt.mIsAutoEnt)
			{
				array[num].mPlt.mIsAutoEnt = @checked;
				MainForm0.save_usrProjectData();
			}
		}

		private void button_moreplates_Click(object sender, EventArgs e)
		{
			MainForm0.CmMessageBoxTop_Ok("功能研发中，敬请期待!");
		}

		private void label_stack_visual_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			Form_VisualTab form_VisualTab = new Form_VisualTab(array[num].visualtype, LoopType.OpenLoop);
			if (form_VisualTab.ShowDialog() == DialogResult.OK)
			{
				array[num].visualtype = form_VisualTab.get_visualtype();
				label_stack_visual.Text = ((USR_INIT.mLanguage == 2) ? "Test:" : "测试:") + STR.VISUAL_STR[(int)array[num].visualtype][USR_INIT.mLanguage];
				MainForm0.save_usrProjectData();
			}
		}

		private void button_campara_Click(object sender, EventArgs e)
		{
			MainForm0.vsplus_open_campara();
		}

		private void button_PikToFastCam_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string text = button.Tag.ToString();
			vsplus_pik_to_cam((text == "fast") ? CameraType.Fast : CameraType.High, USR2);
			if (text == "fast" || text == "high")
			{
				button_reback.Enabled = true;
			}
		}

		private void button_visualtest2_Click(object sender, EventArgs e)
		{
			MainForm0.vsplus_visualtest(USR2);
		}

		public void button_visualrunning_Click(object sender, EventArgs e)
		{
			if (MainForm0.mCurCam[mFn] != CameraType.Fast && MainForm0.mCurCam[mFn] != CameraType.High)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Please switch to correct camera!" : "请切换到正确的相机!");
			}
			else if (!MainForm0.mIsVisualRunning)
			{
				if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Start running real time visual" : "开始运行实时视觉算法", MessageBoxButtons.YesNo) != DialogResult.No)
				{
					MainForm0.mIsVisualRunning = true;
					string[] array = new string[3]
					{
						"停止" + Environment.NewLine + "实时" + Environment.NewLine + "视觉",
						"停止" + Environment.NewLine + "实时" + Environment.NewLine + "视觉",
						"Stop " + Environment.NewLine + "Real Time " + Environment.NewLine + "Visual"
					};
					button_visualrunning.Text = array[USR_INIT.mLanguage];
					button_close.Enabled = false;
					panel_head.Enabled = false;
					panel_context1.Enabled = false;
					panel_context3.Enabled = false;
					panel_context4.Enabled = false;
					button_collect.Enabled = false;
					button_PikToFastCam.Enabled = false;
					button_PikToHighCam.Enabled = false;
					button_visualtest2.Enabled = false;
					MainForm0.vsplus_running_visual(USR2);
				}
			}
			else
			{
				MainForm0.mIsVisualRunning = false;
				string[] array2 = new string[3]
				{
					"运行" + Environment.NewLine + "实时" + Environment.NewLine + "视觉",
					"运行" + Environment.NewLine + "实时" + Environment.NewLine + "视觉",
					"Start " + Environment.NewLine + "Real Time " + Environment.NewLine + "Visual"
				};
				button_visualrunning.Text = array2[USR_INIT.mLanguage];
				button_close.Enabled = true;
				panel_head.Enabled = true;
				panel_context1.Enabled = true;
				panel_context3.Enabled = true;
				panel_context4.Enabled = true;
				button_collect.Enabled = true;
				button_PikToFastCam.Enabled = true;
				button_PikToHighCam.Enabled = true;
				button_visualtest2.Enabled = true;
			}
		}

		public void update_plate_index_str(string str)
		{
			cnButton_stackplate_startIndex.Text = str;
		}

		private void button_reback_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (array[num].mPlt.mXYlist == null)
			{
				array[num].mPlt.mXYlist = new BindingList<StackPlateXYElement>();
			}
			if (array[num].mPlt.mStartIndex <= array[num].mPlt.mXYlist.Count)
			{
				int num2 = array[num].mPlt.mStartIndex;
				if (array[num].mPlt.mStartIndex == 0 || array[num].mPlt.mStartIndex == array[num].mPlt.mXYlist.Count)
				{
					num2 = array[num].mPlt.mXYlist.Count - 1;
				}
				num2--;
				if (num2 == -1)
				{
					num2 = array[num].mPlt.mXYlist.Count - 1;
				}
				array[num].mPlt.mStartIndex = num2;
				cnButton_stackplate_startIndex.Text = format_plate_startindex_str();
				Thread thread = new Thread(thd_reback);
				thread.IsBackground = true;
				thread.Start(new Coordinate(array[num].mPlt.mXYlist[num2].X - USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].X, array[num].mPlt.mXYlist[num2].Y - USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].Y));
			}
		}

		private void thd_reback(object o)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			MainForm0.moveToZero_A_andWait(mFn);
			MainForm0.moveToZero_Z_andWait(mFn, array[num].mZnData[MainForm0.mZn[mFn]].Pik.UpSpeed / 2);
			MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed / 2, (Coordinate)o);
			int num2 = MainForm0.mZn[mFn];
			int num3 = array[num].mZnData[num2].Pik.Height;
			if (USR2.mIsHOffsetMode)
			{
				float num4 = MainForm0.format_H_to_Hmm(Math.Abs(array[num].mZnData[num2].baseH));
				float hmm = num4 + array[num].mZnData[num2].Pik.Offset;
				int num5 = MainForm0.format_Hmm_to_H(hmm) * ((num2 % 2 != 0) ? 1 : (-1));
				if (HW.mSmtGenerationNo == 2)
				{
					num5 = Math.Abs(num5);
				}
				num3 = num5;
			}
			MainForm0.moveToZ_andWait(mFn, MainForm0.mZn[mFn], array[num].mZnData[MainForm0.mZn[mFn]].Pik.UpSpeed / 2 + 1, num3 * 15 / 16);
			MainForm0.misc_vacc_onoff(mFn, MainForm0.mZn[mFn], 0);
			MainForm0.msdelay(500);
			MainForm0.moveToZero_Z_andWait(mFn);
			Invoke((MethodInvoker)delegate
			{
				button_reback.Enabled = false;
			});
		}

		private void label_stacknew_chipLmm_DoubleClick(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			Label label = (Label)sender;
			string text = label.Tag.ToString();
			string type = "";
			float @float = 0f;
			switch (text)
			{
			case "lmm":
				type = (new string[3] { "元件长度mm", "元件長度mm", "Chip-L(mm)" })[USR_INIT.mLanguage];
				@float = array[num].lenght;
				break;
			case "wmm":
				type = (new string[3] { "元件宽度mm", "元件寬度mm", "Chip-W(mm)" })[USR_INIT.mLanguage];
				@float = array[num].width;
				break;
			case "hmm":
				type = (new string[3] { "元件厚度mm", "元件厚度mm", "Chip-H(mm)" })[USR_INIT.mLanguage];
				@float = array[num].height;
				break;
			case "angle":
				type = (new string[3] { "进料角度", "進料角度", "Init Angle" })[USR_INIT.mLanguage];
				@float = array[num].angle;
				break;
			}
			Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, type, "float");
			form_Fill.set_float(@float);
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			@float = form_Fill.get_float();
			switch (text)
			{
			case "lmm":
				array[num].lenght = @float;
				break;
			case "wmm":
				array[num].width = @float;
				break;
			case "hmm":
				array[num].height = @float;
				break;
			case "angle":
				array[num].angle = @float;
				break;
			}
			label.Text = @float.ToString("F2");
			if (!(text == "hmm") || USR3B.mPointlistCat == null || MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Sync [chip height] to [category table]?" : "是否将[厚度]同步修改到[分类优化]列表里？", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			string mChipFootprint = array[num].mChipFootprint;
			string mChipValue = array[num].mChipValue;
			for (int i = 0; i < USR3B.mPointlistCat.Count; i++)
			{
				if (mChipFootprint == USR3B.mPointlistCat[i].Footprint && mChipValue == USR3B.mPointlistCat[i].Material_value)
				{
					USR3B.mPointlistCat[i].Height = array[num].height;
				}
			}
			for (int j = 0; j < U3.Count; j++)
			{
				USR3_DATA uSR3_DATA = U3[j];
				if (uSR3_DATA == null || uSR3_DATA.mPointlistCat == null)
				{
					continue;
				}
				for (int k = 0; k < uSR3_DATA.mPointlistCat.Count; k++)
				{
					if (mChipFootprint == uSR3_DATA.mPointlistCat[k].Footprint && mChipValue == uSR3_DATA.mPointlistCat[k].Material_value)
					{
						uSR3_DATA.mPointlistCat[k].Height = array[num].height;
					}
				}
				if (uSR3_DATA == null || uSR3_DATA.mPointlist == null || uSR3_DATA.mPointlistSmt == null)
				{
					continue;
				}
				for (int l = 0; l < uSR3_DATA.mPointlist.Count; l++)
				{
					if (mChipFootprint == uSR3_DATA.mPointlist[l].Footprint && mChipValue == uSR3_DATA.mPointlist[l].Material_value)
					{
						uSR3_DATA.mPointlist[l].height = array[num].height;
					}
				}
			}
			MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Sync[chip height] to [category table] done!" : "已经将[元件厚度]同步修改到[分类优化]里!");
		}

		private void checkBox_isScanR_CheckedChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			bool @checked = checkBox_isScanR.Checked;
			if (@checked != array[num].mIsScanR)
			{
				array[num].mIsScanR = @checked;
				MainForm0.save_usrProjectData();
			}
			panel_isScanR.Visible = checkBox_isScanR.Checked;
		}

		private void checkBox_stackCollect_CheckedChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			bool @checked = checkBox_stackCollect.Checked;
			if (@checked != array[num].mIsCollect)
			{
				array[num].mIsCollect = @checked;
				MainForm0.save_usrProjectData();
			}
			panel_iscolloect.Visible = checkBox_stackCollect.Checked;
		}

		private void checkBox_is_hcam_special_CheckedChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			bool @checked = checkBox_is_hcam_special.Checked;
			if (@checked != array[num].mIsHCamSpecialPara)
			{
				array[num].mIsHCamSpecialPara = @checked;
				MainForm0.save_usrProjectData();
				if (@checked)
				{
					MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: true);
					MainForm0.hcam_lightlevel_set(mFn, array[num].HCamSpecial_ledlevel);
				}
				else
				{
					MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: false);
				}
			}
			button_hcam_specialpara.Visible = @checked;
			panel_hcam_special.Visible = @checked;
		}

		private void trackBar_hcam_special_level_Scroll(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (array[num].HCamSpecial_ledlevel != trackBar_hcam_special_level.Value)
			{
				array[num].HCamSpecial_ledlevel = trackBar_hcam_special_level.Value;
				if (array[num].mIsHCamSpecialPara)
				{
					MainForm0.hcam_lightlevel_set(mFn, array[num].HCamSpecial_ledlevel);
				}
				label_hcam_special_level.Text = array[num].HCamSpecial_ledlevel.ToString();
			}
		}

		private void button_hcam_specialpara_Click(object sender, EventArgs e)
		{
			MainForm0.CmMessageBoxTop_Ok("功能研发中，敬请期待!");
		}

		private void numericUpDown_stackCollect_ValueChanged(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			float num2 = (float)numericUpDown_stackCollect.Value;
			if (num2 != array[num].mCollectDelta)
			{
				array[num].mCollectDelta = num2;
				MainForm0.save_usrProjectData();
			}
		}

		private void trackBar_scanR_Scroll(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int value = trackBar_scanR.Value;
			if (value != array[num].scanR)
			{
				array[num].scanR = value;
			}
			label_scanR.Text = array[num].scanR.ToString();
		}

		private void trackBar_scanR_MouseUp(object sender, MouseEventArgs e)
		{
			MainForm0.save_usrProjectData();
		}

		private void button_platexy_close_Click(object sender, EventArgs e)
		{
			panel_plateXYlist.Visible = false;
		}

		private void button_platexy_Click(object sender, EventArgs e)
		{
			panel_plateXYlist.Visible = true;
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (array[num].mPlt.mXYlist == null)
			{
				array[num].mPlt.mXYlist = new BindingList<StackPlateXYElement>();
			}
			init_stackplate_xytable(dataGridView_stackplateXY, array[num].mPlt.mXYlist);
		}

		private void lb_stackplate_XYS_Click(object sender, EventArgs e)
		{
			int num = 0;
			num = (int)((Label)sender).Tag;
			for (int i = 0; i < 4; i++)
			{
				if (i == num)
				{
					lb_stackplate_XY[i].BorderStyle = BorderStyle.Fixed3D;
					lb_stackplate_XY[i].BackColor = Color.White;
					bt_stackplate_XY[i].BackColor = Color.Red;
					mCurStackPlateCornerNo = num;
				}
				else
				{
					lb_stackplate_XY[i].BorderStyle = BorderStyle.Fixed3D;
					lb_stackplate_XY[i].BackColor = Color.Gray;
					bt_stackplate_XY[i].BackColor = Color.FromArgb(120, 100, 0);
				}
			}
		}

		private void lb_stackplate_XYS_DoubleClick(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			mCurStackPlateCornerNo = (int)((Label)sender).Tag;
			for (int i = 0; i < 4; i++)
			{
				if (i == mCurStackPlateCornerNo)
				{
					lb_stackplate_XY[i].BorderStyle = BorderStyle.Fixed3D;
					lb_stackplate_XY[i].BackColor = Color.White;
					bt_stackplate_XY[i].BackColor = Color.Red;
				}
				else
				{
					lb_stackplate_XY[i].BorderStyle = BorderStyle.FixedSingle;
					lb_stackplate_XY[i].BackColor = Color.Gray;
					bt_stackplate_XY[i].BackColor = Color.FromArgb(120, 100, 0);
				}
			}
			int selectedIndex = listBox_subPlate.SelectedIndex;
			Coordinate coordinate = new Coordinate();
			if (selectedIndex == 0)
			{
				coordinate.X = array[num].mPlt.mXYS[mCurStackPlateCornerNo].X;
				coordinate.Y = array[num].mPlt.mXYS[mCurStackPlateCornerNo].Y;
			}
			else
			{
				if (array[num].mPlt.mSubList == null)
				{
					array[num].mPlt.mSubList = new BindingList<sSubPlate>();
				}
				int count = array[num].mPlt.mSubList.Count;
				if (selectedIndex > 0 && selectedIndex <= count)
				{
					coordinate.X = array[num].mPlt.mSubList[selectedIndex - 1].mXYS[mCurStackPlateCornerNo].X;
					coordinate.Y = array[num].mPlt.mSubList[selectedIndex - 1].mXYS[mCurStackPlateCornerNo].Y;
				}
			}
			Form_FillXY form_FillXY = new Form_FillXY(coordinate, USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			Coordinate fillXY = form_FillXY.Get_FillXY();
			if (selectedIndex == 0)
			{
				array[num].mPlt.mXYS[mCurStackPlateCornerNo].X = fillXY.X;
				array[num].mPlt.mXYS[mCurStackPlateCornerNo].Y = fillXY.Y;
			}
			else
			{
				if (array[num].mPlt.mSubList == null)
				{
					array[num].mPlt.mSubList = new BindingList<sSubPlate>();
				}
				int count2 = array[num].mPlt.mSubList.Count;
				if (selectedIndex > 0 && selectedIndex <= count2)
				{
					array[num].mPlt.mSubList[selectedIndex - 1].mXYS[mCurStackPlateCornerNo].X = fillXY.X;
					array[num].mPlt.mSubList[selectedIndex - 1].mXYS[mCurStackPlateCornerNo].Y = fillXY.Y;
				}
			}
			lb_stackplate_XY[mCurStackPlateCornerNo].Text = MainForm0.format_XY_label_string(fillXY);
			MainForm0.save_usrProjectData();
		}

		private void button_stackplateMoveToXYS_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (mCurStackPlateCornerNo < 0 || mCurStackPlateCornerNo >= 4 || MainForm0.mMutexMoveXYZA)
			{
				return;
			}
			MainForm0.mMutexMoveXYZA = true;
			MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
			int selectedIndex = listBox_subPlate.SelectedIndex;
			if (selectedIndex == 0)
			{
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(array[num].mPlt.mXYS[mCurStackPlateCornerNo]);
				return;
			}
			if (array[num].mPlt.mSubList == null)
			{
				array[num].mPlt.mSubList = new BindingList<sSubPlate>();
			}
			int count = array[num].mPlt.mSubList.Count;
			if (selectedIndex > 0 && selectedIndex <= count)
			{
				Thread thread2 = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread2.IsBackground = true;
				thread2.Start(array[num].mPlt.mSubList[selectedIndex - 1].mXYS[mCurStackPlateCornerNo]);
			}
			else
			{
				MainForm0.mMutexMoveXYZA = false;
			}
		}

		private void button_stackplateSaveXYS_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (mCurStackPlateCornerNo < 0 || mCurStackPlateCornerNo >= 4)
			{
				return;
			}
			int selectedIndex = listBox_subPlate.SelectedIndex;
			string text = "Update Corner XY for Sub Plate " + (selectedIndex + 1) + "(Corner" + (mCurStackPlateCornerNo + 1) + ")？";
			string text2 = "确定更新子料盘" + (selectedIndex + 1) + "四角的XY坐标(角" + (mCurStackPlateCornerNo + 1) + ")？";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text : text2, MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			if (selectedIndex == 0)
			{
				array[num].mPlt.mXYS[mCurStackPlateCornerNo].X = MainForm0.mCur[mFn].x;
				array[num].mPlt.mXYS[mCurStackPlateCornerNo].Y = MainForm0.mCur[mFn].y;
			}
			else
			{
				if (array[num].mPlt.mSubList == null)
				{
					array[num].mPlt.mSubList = new BindingList<sSubPlate>();
				}
				int count = array[num].mPlt.mSubList.Count;
				if (selectedIndex > 0 && selectedIndex <= count)
				{
					array[num].mPlt.mSubList[selectedIndex - 1].mXYS[mCurStackPlateCornerNo].X = MainForm0.mCur[mFn].x;
					array[num].mPlt.mSubList[selectedIndex - 1].mXYS[mCurStackPlateCornerNo].Y = MainForm0.mCur[mFn].y;
				}
			}
			MainForm0.save_usrProjectData();
			lb_stackplate_XY[mCurStackPlateCornerNo].Invoke((MethodInvoker)delegate
			{
				lb_stackplate_XY[mCurStackPlateCornerNo].Text = "X" + MainForm0.mCur[mFn].x + Environment.NewLine + "Y" + MainForm0.mCur[mFn].y;
			});
		}

		private void button_stackplateGenXYlist_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int selectedIndex = listBox_subPlate.SelectedIndex;
			string text = "Update XY list for sub plate " + (selectedIndex + 1) + "? ";
			string text2 = "确定更新子料盘" + (selectedIndex + 1) + "的XY坐标列表吗?";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text : text2, MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			dataGridView_stackplateXY.DataSource = null;
			if (array[num].mPlt.mXYlist == null)
			{
				array[num].mPlt.mXYlist = new BindingList<StackPlateXYElement>();
			}
			if (array[num].mPlt.mSubList == null)
			{
				array[num].mPlt.mSubList = new BindingList<sSubPlate>();
			}
			int count = array[num].mPlt.mSubList.Count;
			string text3 = "";
			int num2 = (int)nud_stackplate_rows.Value;
			int num3 = (int)nud_stackplate_columns.Value;
			int num4 = 0;
			Coordinate[] array2 = null;
			if (selectedIndex == 0)
			{
				text3 = array[num].mPlt.mGuid;
				array[num].mPlt.mRowNum = num2;
				array[num].mPlt.mColumnNum = num3;
				num4 = num2 * num3;
				array2 = array[num].mPlt.mXYS;
				array[num].mPlt.mTotalNum = num4;
			}
			else if (selectedIndex > 0 && selectedIndex <= count)
			{
				text3 = array[num].mPlt.mSubList[selectedIndex - 1].mGuid;
				array[num].mPlt.mSubList[selectedIndex - 1].mRowNum = num2;
				array[num].mPlt.mSubList[selectedIndex - 1].mColumnNum = num3;
				num4 = num2 * num3;
				array2 = array[num].mPlt.mSubList[selectedIndex - 1].mXYS;
				array[num].mPlt.mSubList[selectedIndex - 1].mTotalNum = num2 * num3;
			}
			BindingList<StackPlateXYElement> bindingList = new BindingList<StackPlateXYElement>();
			for (int i = 0; i < array[num].mPlt.mXYlist.Count; i++)
			{
				if (text3 == array[num].mPlt.mXYlist[i].mGuid)
				{
					bindingList.Add(array[num].mPlt.mXYlist[i]);
				}
			}
			for (int j = 0; j < bindingList.Count; j++)
			{
				array[num].mPlt.mXYlist.Remove(bindingList[j]);
			}
			if (num2 == 1 && num3 == 1)
			{
				StackPlateXYElement stackPlateXYElement = new StackPlateXYElement(text3);
				stackPlateXYElement.L = 1 + "-" + 1;
				stackPlateXYElement.X = array2[0].X;
				stackPlateXYElement.Y = array2[0].Y;
				stackPlateXYElement.No = selectedIndex + 1;
				array[num].mPlt.mXYlist.Add(stackPlateXYElement);
			}
			else if (num2 == 1 && num3 > 1)
			{
				for (int k = 0; k < num3; k++)
				{
					StackPlateXYElement stackPlateXYElement2 = new StackPlateXYElement(text3);
					stackPlateXYElement2.L = 1 + "-" + (k + 1);
					stackPlateXYElement2.X = array2[0].X + k * (array2[1].X - array2[0].X) / (num3 - 1);
					stackPlateXYElement2.Y = array2[0].Y + k * (array2[1].Y - array2[0].Y) / (num3 - 1);
					stackPlateXYElement2.No = selectedIndex + 1;
					array[num].mPlt.mXYlist.Add(stackPlateXYElement2);
				}
			}
			else if (num2 > 1 && num3 == 1)
			{
				for (int l = 0; l < num2; l++)
				{
					StackPlateXYElement stackPlateXYElement3 = new StackPlateXYElement(text3);
					stackPlateXYElement3.L = l + 1 + "-" + 1;
					stackPlateXYElement3.X = array2[0].X + l * (array2[2].X - array2[0].X) / (num2 - 1);
					stackPlateXYElement3.Y = array2[0].Y + l * (array2[2].Y - array2[0].Y) / (num2 - 1);
					stackPlateXYElement3.No = selectedIndex + 1;
					array[num].mPlt.mXYlist.Add(stackPlateXYElement3);
				}
			}
			else if (num2 > 1 && num3 > 1)
			{
				for (int m = 0; m < num2; m++)
				{
					long num5 = array2[0].X + m * (array2[2].X - array2[0].X) / (num2 - 1);
					long num6 = array2[1].X + m * (array2[3].X - array2[1].X) / (num2 - 1);
					long num7 = array2[0].Y + m * (array2[2].Y - array2[0].Y) / (num2 - 1);
					long num8 = array2[1].Y + m * (array2[3].Y - array2[1].Y) / (num2 - 1);
					for (int n = 0; n < num3; n++)
					{
						StackPlateXYElement stackPlateXYElement4 = new StackPlateXYElement(text3);
						stackPlateXYElement4.L = m + 1 + "-" + (n + 1);
						stackPlateXYElement4.X = num5 + n * (num6 - num5) / (num3 - 1);
						stackPlateXYElement4.Y = num7 + n * (num8 - num7) / (num3 - 1);
						stackPlateXYElement4.No = selectedIndex + 1;
						array[num].mPlt.mXYlist.Add(stackPlateXYElement4);
					}
				}
			}
			StackPlateXYElement[] array3 = null;
			array3 = array[num].mPlt.mXYlist.OrderBy((StackPlateXYElement a) => a.No).ToArray();
			array[num].mPlt.mXYlist.Clear();
			if (array3 != null)
			{
				for (int num9 = 0; num9 < array3.Count(); num9++)
				{
					array[num].mPlt.mXYlist.Add(array3[num9]);
				}
			}
			init_stackplate_xytable(dataGridView_stackplateXY, array[num].mPlt.mXYlist);
			int num10 = startIndex_plate(selectedIndex, 0, 0);
			dataGridView_stackplateXY.FirstDisplayedScrollingRowIndex = num10;
			for (int num11 = 0; num11 < num4; num11++)
			{
				dataGridView_stackplateXY.Rows[num10 + num11].Selected = true;
			}
			array[num].mPlt.mStartIndex = 0;
			update_StartIndexButton(array[num].mPlt.mStartIndex);
			MainForm0.save_usrProjectData();
			MainForm0.CmMessageBoxTop_Ok(selectedIndex + 1 + ((USR_INIT.mLanguage == 2) ? " Sub Plate XY done!" : "号子料盘XY坐标生成并添加成功！"));
		}

		private void update_StartIndexButton(int startindex)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			array[num].mPlt.mStartIndex = startindex;
			if (array[num].mPlt.mXYlist == null)
			{
				array[num].mPlt.mXYlist = new BindingList<StackPlateXYElement>();
			}
			if (array[num].mPlt.mStartIndex < array[num].mPlt.mXYlist.Count)
			{
				int sub = 0;
				int r = 0;
				int c = 0;
				startIndex_plate(array[num].mPlt.mStartIndex, ref sub, ref r, ref c);
				cnButton_stackplate_startIndex.Text = STR.START_IDX[USR_INIT.mLanguage] + (sub + 1) + ": " + (r + 1) + "-" + (c + 1);
			}
			else
			{
				cnButton_stackplate_startIndex.Text = STR.START_IDX[USR_INIT.mLanguage] + "-" + STR.EMPTY_PLATE[USR_INIT.mLanguage];
			}
		}

		private void init_stackplate_xytable(DataGridView dgv, BindingList<StackPlateXYElement> xylist)
		{
			_ = mStackLib.stacktab[(int)mStackLib.sel];
			_ = mStackLib.index[(int)mStackLib.sel];
			dgv.AllowUserToAddRows = false;
			dgv.ReadOnly = false;
			dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			if (xylist == null)
			{
				xylist = new BindingList<StackPlateXYElement>();
			}
			dgv.DataSource = xylist;
			dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(180, 180, 180);
			dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(180, 180, 180);
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], 11f, FontStyle.Regular);
			dgv.EnableHeadersVisualStyles = false;
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			dgv.RowHeadersWidth = 10;
			dgv.Columns[1].Width = 50;
			dgv.Columns[1].HeaderText = STR.PLATE_CHIP_INDEX[USR_INIT.mLanguage];
			dgv.Columns[2].Width = 60;
			dgv.Columns[2].HeaderText = "X";
			dgv.Columns[3].Width = 60;
			dgv.Columns[3].HeaderText = "Y";
			dgv.Columns[0].Width = 50;
			dgv.Columns[0].HeaderText = STR.PLATE_SUB[USR_INIT.mLanguage];
			dgv.DefaultCellStyle.Font = new Font("黑体", 11f, FontStyle.Regular);
		}

		private void nud_stackplate_columns_ValueChanged(object sender, EventArgs e)
		{
		}

		private void nud_stackplate_rows_ValueChanged(object sender, EventArgs e)
		{
		}

		private void listBox_subPlate_MouseClick(object sender, MouseEventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (array[num].mPlt.mXYlist != null)
			{
				int num2 = 0;
				for (int i = 0; i < array[num].mPlt.mXYlist.Count; i++)
				{
					if (array[num].mPlt.mXYlist[i].mGuid == array[num].mPlt.mGuid)
					{
						num2++;
					}
				}
				array[num].mPlt.mTotalNum = num2;
			}
			ListBox listBox = (ListBox)sender;
			int selectedIndex = listBox.SelectedIndex;
			if (array[num].mPlt.mSubList == null)
			{
				array[num].mPlt.mSubList = new BindingList<sSubPlate>();
			}
			int count = array[num].mPlt.mSubList.Count;
			if (selectedIndex == 0)
			{
				nud_stackplate_rows.Value = array[num].mPlt.mRowNum;
				nud_stackplate_columns.Value = array[num].mPlt.mColumnNum;
				for (int j = 0; j < 4; j++)
				{
					lb_stackplate_XY[j].Text = "X" + array[num].mPlt.mXYS[j].X + Environment.NewLine + "Y" + array[num].mPlt.mXYS[j].Y;
				}
			}
			else if (selectedIndex > 0 && selectedIndex <= count)
			{
				nud_stackplate_rows.Value = array[num].mPlt.mSubList[selectedIndex - 1].mRowNum;
				nud_stackplate_columns.Value = array[num].mPlt.mSubList[selectedIndex - 1].mColumnNum;
				for (int k = 0; k < 4; k++)
				{
					lb_stackplate_XY[k].Text = "X" + array[num].mPlt.mSubList[selectedIndex - 1].mXYS[k].X + Environment.NewLine + "Y" + array[num].mPlt.mSubList[selectedIndex - 1].mXYS[k].Y;
				}
			}
			if (selectedIndex < 0 || selectedIndex > count)
			{
				return;
			}
			int num3 = 0;
			num3 = ((selectedIndex != 0) ? array[num].mPlt.mSubList[selectedIndex - 1].mTotalNum : array[num].mPlt.mTotalNum);
			if (num3 <= 0)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)dataGridView_stackplateXY.Rows)
			{
				item.Selected = false;
			}
			int num4 = startIndex_plate(selectedIndex, 0, 0);
			try
			{
				dataGridView_stackplateXY.FirstDisplayedScrollingRowIndex = num4;
				for (int l = 0; l < num3; l++)
				{
					dataGridView_stackplateXY.Rows[num4 + l].Selected = true;
				}
			}
			catch (Exception)
			{
			}
		}

		private void checkBox_addSubPlate_CheckedChanged(object sender, EventArgs e)
		{
			panel_addSubPlate.Visible = checkBox_addSubPlate.Checked;
		}

		private void button_addSubPlate_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (array[num].mPlt.mSubList == null)
			{
				array[num].mPlt.mSubList = new BindingList<sSubPlate>();
			}
			int count = array[num].mPlt.mSubList.Count;
			sSubPlate item = new sSubPlate();
			array[num].mPlt.mSubList.Add(item);
			listBox_subPlate.Items.Add(count + 1 + 1);
			listBox_subPlate.SelectedIndex = count + 1;
			listBox_subPlate_MouseClick(listBox_subPlate, null);
		}

		private void button_delSubPlate_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int selectedIndex = listBox_subPlate.SelectedIndex;
			if (selectedIndex == 0)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "The First Sub Plate is not allowed to be removed!!" : "子料盘1不允许被删除！");
				return;
			}
			string text = "Delete XY list of sub plate " + (selectedIndex + 1) + "? ";
			string text2 = "确定删除子料盘" + (selectedIndex + 1) + "以及该料盘已经生成的XY坐标吗?";
			if (MessageBox.Show((USR_INIT.mLanguage == 2) ? text : text2, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			if (selectedIndex > 0 && array[num].mPlt.mSubList != null && selectedIndex <= array[num].mPlt.mSubList.Count)
			{
				BindingList<StackPlateXYElement> bindingList = new BindingList<StackPlateXYElement>();
				dataGridView_stackplateXY.DataSource = null;
				for (int i = 0; i < array[num].mPlt.mXYlist.Count; i++)
				{
					if (array[num].mPlt.mXYlist[i].mGuid == array[num].mPlt.mSubList[selectedIndex - 1].mGuid)
					{
						bindingList.Add(array[num].mPlt.mXYlist[i]);
					}
				}
				for (int j = 0; j < bindingList.Count; j++)
				{
					array[num].mPlt.mXYlist.Remove(bindingList[j]);
				}
				array[num].mPlt.mSubList.RemoveAt(selectedIndex - 1);
				listBox_subPlate.Items.Clear();
				for (int k = 0; k < 1 + array[num].mPlt.mSubList.Count; k++)
				{
					listBox_subPlate.Items.Add(k + 1);
				}
				int num2 = array[num].mPlt.mRowNum * array[num].mPlt.mColumnNum;
				for (int l = 0; l < array[num].mPlt.mSubList.Count; l++)
				{
					for (int m = 0; m < array[num].mPlt.mSubList[l].mTotalNum; m++)
					{
						if (array[num].mPlt.mXYlist[num2 + m].mGuid == array[num].mPlt.mSubList[l].mGuid)
						{
							array[num].mPlt.mXYlist[num2 + m].No = 2 + l;
						}
					}
					num2 += array[num].mPlt.mSubList[l].mTotalNum;
				}
				init_stackplate_xytable(dataGridView_stackplateXY, array[num].mPlt.mXYlist);
				array[num].mPlt.mStartIndex = 0;
				update_StartIndexButton(array[num].mPlt.mStartIndex);
			}
			else
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Fail to Delete!" : "删除失败！");
			}
		}

		private void dataGridView_stackplateXY_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (dataGridView_stackplateXY.SelectedCells.Count == 1)
			{
				int rowIndex = dataGridView_stackplateXY.SelectedCells[0].RowIndex;
				dataGridView_stackplateXY.Rows[rowIndex].Selected = true;
			}
		}

		private void button_stackplateXY_update_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (dataGridView_stackplateXY.SelectedRows.Count == 1 && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Update XY?" : "您确定要更新的XY坐标值吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				array[num].mPlt.mXYlist[dataGridView_stackplateXY.SelectedRows[0].Index].X = MainForm0.mCur[mFn].x;
				array[num].mPlt.mXYlist[dataGridView_stackplateXY.SelectedRows[0].Index].Y = MainForm0.mCur[mFn].y;
				dataGridView_stackplateXY.Refresh();
				MainForm0.save_usrProjectData();
			}
		}

		private void button_stackplateXY_moveto_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (dataGridView_stackplateXY.SelectedRows.Count == 1 && !MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				int index = dataGridView_stackplateXY.SelectedRows[0].Index;
				Coordinate parameter = new Coordinate(array[num].mPlt.mXYlist[index].X, array[num].mPlt.mXYlist[index].Y);
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(parameter);
			}
		}

		private void button_stackplateXY_moveto_byZn_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (dataGridView_stackplateXY.SelectedRows.Count == 1 && !MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				int index = dataGridView_stackplateXY.SelectedRows[0].Index;
				Coordinate coordinate = new Coordinate(array[num].mPlt.mXYlist[index].X, array[num].mPlt.mXYlist[index].Y);
				coordinate.X -= USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].X;
				coordinate.Y -= USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].Y;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(coordinate);
			}
		}

		private void UserControl_Stack_Load(object sender, EventArgs e)
		{
			SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			UpdateStyles();
			dataGridView_stackplateXY.DefaultCellStyle.Font = new Font("黑体", 9.25f, FontStyle.Regular);
			init_buttons();
			MainForm0.common_waiting_break();
		}

		private void button_stackplate_startIndex_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			try
			{
				int[] array2 = new int[1] { array[num].mPlt.mStartIndex };
				Form_StackPlateIndexsToo form_StackPlateIndexsToo = new Form_StackPlateIndexsToo(USR_INIT.mLanguage, array[num].mPlt, array2, num);
				if (form_StackPlateIndexsToo.ShowDialog() == DialogResult.OK)
				{
					array[num].mPlt.mStartIndex = array2[0];
					MainForm0.save_usrProjectData();
					cnButton_stackplate_startIndex.Text = format_plate_startindex_str();
				}
			}
			catch (Exception ex)
			{
				MainForm0.write_to_logFile("类型X: " + ex.Message + Environment.NewLine);
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Plate Array set invalid!" : "料盘行列设置不合法，请正确设置！");
			}
		}

		private void button_stacknew_Hpara_synctoAllZn_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int num = (int)button.Tag;
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num2 = mStackLib.index[(int)mStackLib.sel];
			if (!array[num2].mZnData[MainForm0.mZn[mFn]].mEnabled)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Selected nozzle is not enabled, sync to other nozzle fails!" : "选中吸嘴未启用，无法同步到其他吸嘴！");
			}
			else
			{
				if ((num == 16 || num == 17) && MainForm0.CmMessageBox((new string[3] { "是否全体同步？", "是否全體同步？", "Do you want to sync all?" })[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
				for (int i = 0; i < HW.mZnNum[mFn]; i++)
				{
					switch (num)
					{
					case 0:
						numericUpDown_stack_pikConfig[0][i].Value = numericUpDown_stack_pikConfig[0][MainForm0.mZn[mFn]].Value;
						break;
					case 1:
						numericUpDown_stack_pikConfig[1][i].Value = numericUpDown_stack_pikConfig[1][MainForm0.mZn[mFn]].Value;
						break;
					case 2:
						numericUpDown_stack_pikConfig[2][i].Value = numericUpDown_stack_pikConfig[2][MainForm0.mZn[mFn]].Value;
						break;
					case 3:
						numericUpDown_stack_mntConfig[0][i].Value = numericUpDown_stack_mntConfig[0][MainForm0.mZn[mFn]].Value;
						break;
					case 4:
						numericUpDown_stack_mntConfig[1][i].Value = numericUpDown_stack_mntConfig[1][MainForm0.mZn[mFn]].Value;
						break;
					case 5:
						numericUpDown_stack_mntConfig[2][i].Value = numericUpDown_stack_mntConfig[2][MainForm0.mZn[mFn]].Value;
						break;
					case 6:
						array[num2].mZnData[i].threshold = array[num2].mZnData[MainForm0.mZn[mFn]].threshold;
						label_threshold[i].Text = array[num2].mZnData[MainForm0.mZn[mFn]].threshold.ToString();
						break;
					case 7:
						numericUpDown_pikoffset[i].Value = numericUpDown_pikoffset[MainForm0.mZn[mFn]].Value;
						break;
					case 8:
						numericUpDown_mntoffset[i].Value = numericUpDown_mntoffset[MainForm0.mZn[mFn]].Value;
						break;
					case 16:
						numericUpDown_stack_pikConfig[0][i].Value = numericUpDown_stack_pikConfig[0][MainForm0.mZn[mFn]].Value;
						numericUpDown_stack_pikConfig[1][i].Value = numericUpDown_stack_pikConfig[1][MainForm0.mZn[mFn]].Value;
						numericUpDown_stack_pikConfig[2][i].Value = numericUpDown_stack_pikConfig[2][MainForm0.mZn[mFn]].Value;
						numericUpDown_pikoffset[i].Value = numericUpDown_pikoffset[MainForm0.mZn[mFn]].Value;
						break;
					case 17:
						numericUpDown_stack_mntConfig[0][i].Value = numericUpDown_stack_mntConfig[0][MainForm0.mZn[mFn]].Value;
						numericUpDown_stack_mntConfig[1][i].Value = numericUpDown_stack_mntConfig[1][MainForm0.mZn[mFn]].Value;
						numericUpDown_stack_mntConfig[2][i].Value = numericUpDown_stack_mntConfig[2][MainForm0.mZn[mFn]].Value;
						numericUpDown_mntoffset[i].Value = numericUpDown_mntoffset[MainForm0.mZn[mFn]].Value;
						break;
					}
				}
				MainForm0.save_usrProjectData();
			}
		}

		private void button_pikBaseH_Click(object sender, EventArgs e)
		{
			if (mStackLib.sel == ProviderType.Feedr)
			{
				if (mFormProviderHeight_Feeder == null || mFormProviderHeight_Feeder.IsDisposed)
				{
					mFormProviderHeight_Feeder = new Form_ProviderHeight_Feeder(USR, USR2);
					mFormProviderHeight_Feeder.Location = new Point(562, 500);
					mFormProviderHeight_Feeder.Show();
					mFormProviderHeight_Feeder.TopMost = true;
				}
			}
			else if (mFormProviderHeight == null || mFormProviderHeight.IsDisposed)
			{
				mFormProviderHeight = new Form_ProviderHeight(USR, USR2);
				mFormProviderHeight.Location = new Point(562, 500);
				mFormProviderHeight.Show();
				mFormProviderHeight.TopMost = true;
			}
		}

		private void button_collect_Click(object sender, EventArgs e)
		{
			vsplus_collect(USR2);
		}

		public void set_collect_l_w(float lmm, float wmm)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			array[num].lenght = lmm;
			array[num].width = wmm;
			label_stacknew_chipLmm.Text = lmm.ToString("F2");
			label_stacknew_chipWmm.Text = wmm.ToString("F2");
		}

		private void button_stackCopy_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = HW.mStackNum[mFn][(int)mStackLib.sel];
			StackCopySt stackCopySt = default(StackCopySt);
			stackCopySt.nozzle = new bool[HW.mZnNum[mFn]];
			stackCopySt.para = new bool[17];
			stackCopySt.stack = new bool[num2];
			StackCopySt stackcopy = stackCopySt;
			Form_StackCopy form_StackCopy = new Form_StackCopy(USR_INIT.mLanguage, num, (int)mStackLib.sel, array, stackcopy, USR2.mIsHOffsetMode);
			if (form_StackCopy.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			for (int i = 0; i < num2; i++)
			{
				if (!stackcopy.stack[i] || i == num)
				{
					continue;
				}
				for (int j = 0; j < 17; j++)
				{
					if (!stackcopy.para[j])
					{
						continue;
					}
					switch (j)
					{
					case 8:
						array[i].mIsCollect = array[num].mIsCollect;
						break;
					case 9:
						array[i].mCollectDelta = array[num].mCollectDelta;
						break;
					case 10:
						array[i].scanR = array[num].scanR;
						array[i].mIsScanR = array[num].mIsScanR;
						break;
					case 16:
						array[i].mIsHCamSpecialPara = array[num].mIsHCamSpecialPara;
						break;
					case 13:
						array[i].lenght = array[num].lenght;
						break;
					case 14:
						array[i].width = array[num].width;
						break;
					case 15:
						array[i].height = array[num].height;
						break;
					case 12:
						if (mStackLib.sel == ProviderType.Plate)
						{
							array[i].mPlt.mAutoEntTimeDelay = array[num].mPlt.mAutoEntTimeDelay;
							array[i].mPlt.mIsAutoEnt = array[num].mPlt.mIsAutoEnt;
						}
						else
						{
							array[i].mFeederDelay = array[num].mFeederDelay;
						}
						break;
					}
					for (int k = 0; k < HW.mZnNum[mFn]; k++)
					{
						if (!stackcopy.nozzle[k])
						{
							continue;
						}
						switch (j)
						{
						case 0:
							if (USR2.mIsHOffsetMode)
							{
								array[i].mZnData[k].Pik.Offset = array[num].mZnData[k].Pik.Offset;
							}
							else
							{
								array[i].mZnData[k].Pik.Height = array[num].mZnData[k].Pik.Height;
							}
							break;
						case 1:
							array[i].mZnData[k].Pik.Delay = array[num].mZnData[k].Pik.Delay;
							break;
						case 2:
							array[i].mZnData[k].Pik.DownSpeed = array[num].mZnData[k].Pik.DownSpeed;
							break;
						case 3:
							array[i].mZnData[k].Pik.UpSpeed = array[num].mZnData[k].Pik.UpSpeed;
							break;
						case 4:
							if (USR2.mIsHOffsetMode)
							{
								array[i].mZnData[k].Mnt.Offset = array[num].mZnData[k].Mnt.Offset;
							}
							else
							{
								array[i].mZnData[k].Mnt.Height = array[num].mZnData[k].Mnt.Height;
							}
							break;
						case 5:
							array[i].mZnData[k].Mnt.Delay = array[num].mZnData[k].Mnt.Delay;
							break;
						case 6:
							array[i].mZnData[k].Mnt.DownSpeed = array[num].mZnData[k].Mnt.DownSpeed;
							break;
						case 7:
							array[i].mZnData[k].Mnt.UpSpeed = array[num].mZnData[k].Mnt.UpSpeed;
							break;
						case 11:
							array[i].mZnData[k].threshold = array[num].mZnData[k].threshold;
							break;
						}
					}
				}
			}
			MainForm0.save_usrProjectData();
			MainForm0.CmMessageBoxTop_Ok((new string[3] { "参数批量拷贝完成！", "參數批量拷貝完成！", "Complete!" })[USR_INIT.mLanguage]);
		}

		private void button_from_footprintlab_Click(object sender, EventArgs e)
		{
			string[] array = new string[3] { "该操作会覆盖所有用到的料站参数，是否继续?", "該操作會覆蓋所有用到的料站參數，是否繼續?", "This operation will over write all feeder parameters used. Do you want to continue?" };
			if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes && (fm_provider_from_footprintlab == null || fm_provider_from_footprintlab.IsDisposed))
			{
				fm_provider_from_footprintlab = new Form_provider_from_footprintlab(USR, USR2, is_view: false, 0);
				fm_provider_from_footprintlab.stacksel_new_flushpage += stacksel_new_flushpage;
				fm_provider_from_footprintlab.stacksel_new_flushdata += stacksel_new_flushdata;
				fm_provider_from_footprintlab.Location = new Point(4, 10);
				fm_provider_from_footprintlab.Show();
				fm_provider_from_footprintlab.TopMost = true;
			}
		}

		private void button_from_footprintlab_view_Click(object sender, EventArgs e)
		{
			if (fm_provider_from_footprintlab == null || fm_provider_from_footprintlab.IsDisposed)
			{
				fm_provider_from_footprintlab = new Form_provider_from_footprintlab(USR, USR2, is_view: true, 0);
				fm_provider_from_footprintlab.stacksel_new_flushpage += stacksel_new_flushpage;
				fm_provider_from_footprintlab.stacksel_new_flushdata += stacksel_new_flushdata;
				fm_provider_from_footprintlab.Location = new Point(4, 10);
				fm_provider_from_footprintlab.Show();
				fm_provider_from_footprintlab.TopMost = true;
			}
		}

		public void create_provider_from_footprintlab_mode1()
		{
			if (fm_provider_from_footprintlab_mode1 == null || fm_provider_from_footprintlab_mode1.IsDisposed)
			{
				fm_provider_from_footprintlab_mode1 = new Form_provider_from_footprintlab(USR, USR2, is_view: false, 1);
				fm_provider_from_footprintlab_mode1.stacksel_new_flushpage += stacksel_new_flushpage;
				fm_provider_from_footprintlab_mode1.stacksel_new_flushdata += stacksel_new_flushdata;
				fm_provider_from_footprintlab_mode1.Location = new Point(4, 10);
				fm_provider_from_footprintlab_mode1.Show();
				fm_provider_from_footprintlab_mode1.TopMost = true;
			}
		}

		public void set_provider_from_footprintlab_mode1(int stackno, bool is_match)
		{
			if (fm_provider_from_footprintlab_mode1 != null && !fm_provider_from_footprintlab_mode1.IsDisposed)
			{
				fm_provider_from_footprintlab_mode1.set_match(ProviderType.Feedr, stackno, is_match);
			}
		}

		private void button_providerSetting_Click(object sender, EventArgs e)
		{
			Form_ProviderSetting form_ProviderSetting = new Form_ProviderSetting(USR2);
			if (form_ProviderSetting.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			USR2.mIs180DegreeReverse_forbackfeeder = form_ProviderSetting.get_auto180();
			USR2.mIsPrepareVacuumLater = form_ProviderSetting.get_vacuumlater();
			USR2.mIsHOffsetMode = form_ProviderSetting.get_hoffsetmode();
			if (label_pikH_head != null)
			{
				if (USR2.mIsHOffsetMode)
				{
					string[] array = new string[3] { "启用[偏移模式]后, 原填写/保存的[取料高度]和[贴装高度]都将失效，而都由[基准高度]+[下压mm]+[元件厚度]自动生成！", "啟用[偏移模式]後, 原填寫/保存的[取料高度]和[貼裝高度]都將失效，而都由[基準高度]+[下壓mm]+[元件厚度]自動生成！", "If [Offset mode] is enabled, previously filled [Pick-H] and [Mount-H] are invalid. And Base-H + Offset is valid!" };
					MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
				}
				else
				{
					string[] array2 = new string[3] { "禁用[偏移模式]后, [取料高度]和[贴装高度]均已填写/保存的为准！", "禁用[偏移模式]後, [取料高度]和[貼裝高度]均已填寫/保存的為準！", "If [Offset mode] is disabled, [Pick-H] and [Mount-H] are absolute value when saved!" };
					MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
				}
				label_pikH_head.Text = (USR2.mIsHOffsetMode ? (new string[3] { "下压(mm)", "下壓(mm)", "Offset(mm)" })[USR_INIT.mLanguage] : (new string[3] { "取料高度", "取料高度", "Pick-H" })[USR_INIT.mLanguage]);
				label_mntH_head.Text = (USR2.mIsHOffsetMode ? (new string[3] { "下压(mm)", "下壓(mm)", "Offset(mm)" })[USR_INIT.mLanguage] : (new string[3] { "贴装高度", "貼裝高度", "Mount-H" })[USR_INIT.mLanguage]);
				button_pikH_Offset_Sync.Visible = USR2.mIsHOffsetMode;
				button_pikH_View.Visible = USR2.mIsHOffsetMode;
				button_pikH_Save.Visible = !USR2.mIsHOffsetMode;
				button_pikH_Goto.Visible = !USR2.mIsHOffsetMode;
				button_mntH_Offset_Sync.Visible = USR2.mIsHOffsetMode;
				button_mntH_View.Visible = USR2.mIsHOffsetMode;
				button_mntH_Save.Visible = !USR2.mIsHOffsetMode;
				button_mntH_Goto.Visible = !USR2.mIsHOffsetMode;
				button_pikBaseH.Visible = USR2.mIsHOffsetMode;
				button_mntBaseH.Visible = USR2.mIsHOffsetMode;
				if (mStackLib.sel == ProviderType.Feedr)
				{
					button_pikBaseH.Visible = false;
				}
				for (int i = 0; i < 8; i++)
				{
					numericUpDown_pikoffset[i].Visible = USR2.mIsHOffsetMode;
					label_stack_pikH[i].Visible = !USR2.mIsHOffsetMode;
					numericUpDown_mntoffset[i].Visible = USR2.mIsHOffsetMode;
					label_stack_mntH[i].Visible = !USR2.mIsHOffsetMode;
				}
				MainForm0.save_usrProjectData();
			}
		}

		private void button_footprint_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			string mChipFootprint = array[num].mChipFootprint;
			if (MainForm0.FP_PATH.mFootprintLib_NameList == null || MainForm0.FP_PATH.mFootprintLib_NameList.Count <= 0 || MainForm0.FP_PATH.mFootprintLib_Index < 0 || MainForm0.FP_PATH.mFootprintLib_Index > MainForm0.FP_PATH.mFootprintLib_NameList.Count)
			{
				string[] array2 = new string[3] { "封装库文件为空，请先去[封装库]里新建或添加封装库文件!", "封裝庫文件為空，請先去[封裝庫]裏新建或添加封裝庫文件!", "Footprint file is empty. Please goto [Footprint Lab] page to add or create footprint file!" };
				MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
				return;
			}
			int mFootprintLib_Index = 0;
			int num2 = 0;
			int index = 0;
			bool flag = false;
			for (int i = 0; i < MainForm0.FP_PATH.mFootprintLib_NameList.Count; i++)
			{
				USR_LIB uSR_LIB = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[i]);
				if (uSR_LIB.fpcatlist == null)
				{
					uSR_LIB.fpcatlist = new BindingList<FP_CAT>();
				}
				flag = false;
				for (int j = 0; j < uSR_LIB.fpcatlist.Count; j++)
				{
					BindingList<FootPrint> footlist = uSR_LIB.fpcatlist[j].footlist;
					if (footlist == null)
					{
						continue;
					}
					for (int k = 0; k < footlist.Count; k++)
					{
						if (mChipFootprint == footlist[k].name)
						{
							flag = true;
						}
						else if (footlist[k].nick_namelist != null)
						{
							for (int l = 0; l < footlist[k].nick_namelist.Count; l++)
							{
								if (mChipFootprint == footlist[k].nick_namelist[l])
								{
									flag = true;
									break;
								}
							}
						}
						if (flag)
						{
							mFootprintLib_Index = i;
							num2 = j;
							index = k;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			string title = STR.PROVIDER_STR[(int)mStackLib.sel][USR_INIT.mLanguage] + (num + 1) + "  " + (new string[3] { "封装 ", "封裝 ", " Footprint " })[USR_INIT.mLanguage] + array[num].mChipFootprint;
			Form_BoxSel form_BoxSel = new Form_BoxSel(title, (new string[3] { "更新到封装库", "更新到封裝庫", "Update to Footprint Lab" })[USR_INIT.mLanguage], (new string[3] { "来自封装库", "來自封裝庫", "From Footprint Lab" })[USR_INIT.mLanguage], "");
			switch (form_BoxSel.ShowDialog())
			{
			case DialogResult.Yes:
			{
				string title2 = "";
				Form_BoxSel form_BoxSel2 = new Form_BoxSel(title2, (new string[3] { "手动选择", "手動選擇", "Manual" })[USR_INIT.mLanguage], (new string[3] { "自动", "自動", "Auto" })[USR_INIT.mLanguage], "");
				switch (form_BoxSel2.ShowDialog())
				{
				case DialogResult.Yes:
					if (flag)
					{
						MainForm0.FP_PATH.mFootprintLib_Index = mFootprintLib_Index;
						USR_LIB uSR_LIB5 = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[MainForm0.FP_PATH.mFootprintLib_Index]);
						uSR_LIB5.fpcatindex = num2;
						uSR_LIB5.fpcatlist[uSR_LIB5.fpcatindex].index = index;
						FootPrint footPrint4 = uSR_LIB5.fpcatlist[uSR_LIB5.fpcatindex].footlist[index];
						array[num].angle = footPrint4.angle;
						array[num].mCollectDelta = footPrint4.collect_rate;
						if (mStackLib.sel == ProviderType.Plate)
						{
							array[num].mPlt.mAutoEntTimeDelay = footPrint4.feeder_ant_delay;
						}
						else
						{
							array[num].mFeederDelay = (int)footPrint4.feeder_ant_delay;
						}
						array[num].height = footPrint4.height;
						array[num].mIsCollect = footPrint4.iscollect;
						array[num].mIsScanR = footPrint4.isscan_r;
						array[num].width = footPrint4.width;
						array[num].lenght = footPrint4.length;
						float scan_r_mm2 = footPrint4.scan_r_mm;
						if (footPrint4.camera == CameraType.Fast)
						{
							array[num].scanR = (int)(scan_r_mm2 * 100f / USR.mFastCamRatio[0][MainForm0.mZn[mFn]] + 0.5f);
							if (array[num].scanR > 360)
							{
								array[num].scanR = 360;
							}
						}
						else if (footPrint4.camera == CameraType.High)
						{
							array[num].scanR = (int)(scan_r_mm2 * 100f / USR.mHighCamRatio[0] + 0.5f);
							if (array[num].scanR > 900)
							{
								array[num].scanR = 900;
							}
						}
						else
						{
							array[num].scanR = 1;
						}
						for (int num9 = 0; num9 < HW.mZnNum[mFn]; num9++)
						{
							array[num].mZnData[num9].Mnt.Delay = footPrint4.mnt_delay;
							array[num].mZnData[num9].Mnt.DownSpeed = footPrint4.mnt_down_speed;
							array[num].mZnData[num9].Mnt.UpSpeed = footPrint4.mnt_up_speed;
							array[num].mZnData[num9].Mnt.Offset = footPrint4.mnt_offset;
							array[num].mZnData[num9].threshold = footPrint4.threshold;
							array[num].mZnData[num9].Pik.Delay = footPrint4.pik_delay;
							array[num].mZnData[num9].Pik.DownSpeed = footPrint4.pik_down_speed;
							array[num].mZnData[num9].Pik.UpSpeed = footPrint4.pik_up_speed;
							array[num].mZnData[num9].Pik.Offset = footPrint4.pik_offset;
						}
						array[num].mAutoPixXY.first_feederin = footPrint4.first_feederin;
						array[num].mAutoPixXY.scanr = (int)((double)(scan_r_mm2 * 100f / USR.mMarkCamRatio[0]) * 1.2 + 0.5);
						array[num].mAutoPixXY.belt_color = footPrint4.belt_color;
						if (array[num].mAutoPixXY.belt_color == 0)
						{
							array[num].mAutoPixXY.threshold = USR.mAutoPik_threshold_whitebelt;
						}
						else if (array[num].mAutoPixXY.belt_color == 1)
						{
							array[num].mAutoPixXY.threshold = USR.mAutoPik_threshold_blackbelt;
						}
						else
						{
							array[num].mAutoPixXY.threshold = USR.mAutoPik_threshold_toumingbelt;
						}
						MainForm0.save_usrProjectData();
						stacksel_new_flushdata();
						MainForm0.CmMessageBoxTop_Ok((new string[3] { "更新完成!", "更新完成!", "Update Done!" })[USR_INIT.mLanguage]);
					}
					else
					{
						MainForm0.CmMessageBoxTop_Ok((new string[3] { "没找到封装项目!", "沒找到封裝項目!", "Footprint item is not found!" })[USR_INIT.mLanguage]);
					}
					break;
				case DialogResult.OK:
				{
					Form_LabPrintfoot form_LabPrintfoot3 = new Form_LabPrintfoot(MainForm0.USR_INIT, 1);
					form_LabPrintfoot3.StartPosition = FormStartPosition.CenterParent;
					form_LabPrintfoot3.Size = new Size(form_LabPrintfoot3.Size.Width, form_LabPrintfoot3.Size.Height + 60);
					if (form_LabPrintfoot3.ShowDialog() != DialogResult.OK)
					{
						break;
					}
					mFootprintLib_Index = MainForm0.FP_PATH.mFootprintLib_Index;
					USR_LIB uSR_LIB4 = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[MainForm0.FP_PATH.mFootprintLib_Index]);
					num2 = uSR_LIB4.fpcatindex;
					index = uSR_LIB4.fpcatlist[uSR_LIB4.fpcatindex].index;
					FootPrint footPrint3 = uSR_LIB4.fpcatlist[uSR_LIB4.fpcatindex].footlist[index];
					array[num].angle = footPrint3.angle;
					array[num].mCollectDelta = footPrint3.collect_rate;
					if (mStackLib.sel == ProviderType.Plate)
					{
						array[num].mPlt.mAutoEntTimeDelay = footPrint3.feeder_ant_delay;
					}
					else
					{
						array[num].mFeederDelay = (int)footPrint3.feeder_ant_delay;
					}
					array[num].height = footPrint3.height;
					array[num].mIsCollect = footPrint3.iscollect;
					array[num].mIsScanR = footPrint3.isscan_r;
					array[num].width = footPrint3.width;
					array[num].lenght = footPrint3.length;
					float scan_r_mm = footPrint3.scan_r_mm;
					if (footPrint3.camera == CameraType.Fast)
					{
						array[num].scanR = (int)(scan_r_mm * 100f / USR.mFastCamRatio[0][MainForm0.mZn[mFn]] + 0.5f);
						if (array[num].scanR > 360)
						{
							array[num].scanR = 360;
						}
					}
					else if (footPrint3.camera == CameraType.High)
					{
						array[num].scanR = (int)(scan_r_mm * 100f / USR.mHighCamRatio[0] + 0.5f);
						if (array[num].scanR > 900)
						{
							array[num].scanR = 900;
						}
					}
					else
					{
						array[num].scanR = 1;
					}
					for (int num8 = 0; num8 < HW.mZnNum[mFn]; num8++)
					{
						array[num].mZnData[num8].Mnt.Delay = footPrint3.mnt_delay;
						array[num].mZnData[num8].Mnt.DownSpeed = footPrint3.mnt_down_speed;
						array[num].mZnData[num8].Mnt.UpSpeed = footPrint3.mnt_up_speed;
						array[num].mZnData[num8].Mnt.Offset = footPrint3.mnt_offset;
						array[num].mZnData[num8].threshold = footPrint3.threshold;
						array[num].mZnData[num8].Pik.Delay = footPrint3.pik_delay;
						array[num].mZnData[num8].Pik.DownSpeed = footPrint3.pik_down_speed;
						array[num].mZnData[num8].Pik.UpSpeed = footPrint3.pik_up_speed;
						array[num].mZnData[num8].Pik.Offset = footPrint3.pik_offset;
					}
					array[num].mAutoPixXY.first_feederin = footPrint3.first_feederin;
					array[num].mAutoPixXY.scanr = (int)((double)(scan_r_mm * 100f / USR.mMarkCamRatio[0]) * 1.2 + 0.5);
					array[num].mAutoPixXY.belt_color = footPrint3.belt_color;
					if (array[num].mAutoPixXY.belt_color == 0)
					{
						array[num].mAutoPixXY.threshold = USR.mAutoPik_threshold_whitebelt;
					}
					else if (array[num].mAutoPixXY.belt_color == 1)
					{
						array[num].mAutoPixXY.threshold = USR.mAutoPik_threshold_blackbelt;
					}
					else
					{
						array[num].mAutoPixXY.threshold = USR.mAutoPik_threshold_toumingbelt;
					}
					MainForm0.save_usrProjectData();
					stacksel_new_flushdata();
					MainForm0.CmMessageBoxTop_Ok((new string[3] { "更新完成!", "更新完成!", "Update Done!" })[USR_INIT.mLanguage]);
					break;
				}
				}
				break;
			}
			case DialogResult.OK:
			{
				int num3 = -1;
				if (USR3B.mPointlistCat != null)
				{
					for (int m = 0; m < USR3B.mPointlistCat.Count; m++)
					{
						ProviderType providerType = MainForm0.format_feeder_to_providertype(USR3B.mPointlistCat[m].Feedertype);
						if (providerType != mStackLib.sel)
						{
							continue;
						}
						for (int n = 0; n < USR3B.mPointlistCat[m].MultiFeeders; n++)
						{
							if (USR3B.mPointlistCat[m].feeder_no[n] - 1 == num)
							{
								num3 = m;
								break;
							}
						}
						if (num3 != -1)
						{
							break;
						}
					}
				}
				if (num3 == -1)
				{
					string[] array3 = new string[3]
					{
						"[分类优化]表里没有该料站的信息，因此无法更新!" + Environment.NewLine + "请进入[分类优化]界面仔细查看!",
						"[分類優化]表裏沒有該料站的信息，因此無法更新!" + Environment.NewLine + "請進入[分類優化]界面仔細查看!",
						"[Optimize]table does not have this chip information，it cannot update!" + Environment.NewLine + "Please goto [Optimize] page to check!"
					};
					MainForm0.CmMessageBoxTop_Ok(array3[USR_INIT.mLanguage]);
					break;
				}
				if (USR3B.mPointlistCat[num3].Footprint != array[num].mChipFootprint)
				{
					string[] array4 = new string[3]
					{
						"封装名称和分类优化表里该料站的封装名称不相符，因此无法更新!" + Environment.NewLine + "请进入[分类优化]界面仔细查看!",
						"封裝名稱和分類優化表裏該料站的封裝名稱不相符，因此無法更新!" + Environment.NewLine + "請進入[分類優化]界面仔細查看!",
						"Footprint name is different from optimize table, so it cannot update!" + Environment.NewLine + "Please goto [Optimize] page to check!"
					};
					MainForm0.CmMessageBoxTop_Ok(array4[USR_INIT.mLanguage]);
					break;
				}
				if (flag)
				{
					string[] array5 = new string[3]
					{
						"将当前数据覆盖到[封装库-" + mChipFootprint + "]中, 是否继续?",
						"將當前數據覆蓋到[封裝庫-" + mChipFootprint + "]中, 是否繼續?",
						"Overwrite current stack data to [footprint lab -" + mChipFootprint + "], are you continue?"
					};
					if (MainForm0.CmMessageBox(array5[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.No)
					{
						break;
					}
					MainForm0.FP_PATH.mFootprintLib_Index = mFootprintLib_Index;
					USR_LIB uSR_LIB2 = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[MainForm0.FP_PATH.mFootprintLib_Index]);
					uSR_LIB2.fpcatindex = num2;
					uSR_LIB2.fpcatlist[num2].index = index;
					FootPrint footPrint = uSR_LIB2.fpcatlist[num2].footlist[index];
					footPrint.angle = array[num].angle;
					footPrint.collect_rate = array[num].mCollectDelta;
					footPrint.feeder_ant_delay = ((mStackLib.sel == ProviderType.Plate) ? array[num].mPlt.mAutoEntTimeDelay : ((float)array[num].mFeederDelay));
					footPrint.height = array[num].height;
					footPrint.iscollect = array[num].mIsCollect;
					footPrint.isscan_r = array[num].mIsScanR;
					footPrint.width = array[num].width;
					footPrint.length = array[num].lenght;
					footPrint.first_feederin = array[num].mAutoPixXY.first_feederin;
					for (int num4 = 0; num4 < HW.mZnNum[mFn]; num4++)
					{
						if (array[num].mZnData[num4].mEnabled)
						{
							footPrint.mnt_delay = array[num].mZnData[num4].Mnt.Delay;
							footPrint.mnt_down_speed = array[num].mZnData[num4].Mnt.DownSpeed;
							footPrint.mnt_up_speed = array[num].mZnData[num4].Mnt.UpSpeed;
							footPrint.mnt_offset = array[num].mZnData[num4].Mnt.Offset;
							footPrint.threshold = array[num].mZnData[num4].threshold;
							footPrint.pik_delay = array[num].mZnData[num4].Pik.Delay;
							footPrint.pik_down_speed = array[num].mZnData[num4].Pik.DownSpeed;
							footPrint.pik_up_speed = array[num].mZnData[num4].Pik.UpSpeed;
							footPrint.pik_offset = array[num].mZnData[num4].Pik.Offset;
							break;
						}
					}
					footPrint.camera = USR3B.mPointlistCat[num3].Cameratype;
					float num5 = 0f;
					if (footPrint.camera == CameraType.Fast)
					{
						num5 = USR.mFastCamRatio[0][MainForm0.mZn[mFn]];
					}
					else if (footPrint.camera == CameraType.High)
					{
						num5 = USR.mHighCamRatio[0];
					}
					footPrint.scan_r_mm = (float)array[num].scanR * num5 / 100f;
					footPrint.delta = USR3B.mPointlistCat[num3].Delta;
					footPrint.height = USR3B.mPointlistCat[num3].Height;
					footPrint.islowspeed = USR3B.mPointlistCat[num3].IsLowSpeed;
					footPrint.loop = USR3B.mPointlistCat[num3].Looptype;
					footPrint.nozzle = USR3B.mPointlistCat[num3].Nozzletype0;
					footPrint.feedertype = USR3B.mPointlistCat[num3].Feedertype;
					footPrint.providertype = MainForm0.format_feeder_to_providertype(USR3B.mPointlistCat[num3].Feedertype);
					footPrint.visual = USR3B.mPointlistCat[num3].Visualtype;
					MainForm0.save_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[MainForm0.FP_PATH.mFootprintLib_Index], uSR_LIB2);
					Form_LabPrintfoot form_LabPrintfoot = new Form_LabPrintfoot(MainForm0.USR_INIT, 0);
					form_LabPrintfoot.StartPosition = FormStartPosition.CenterParent;
					form_LabPrintfoot.Size = new Size(form_LabPrintfoot.Size.Width, form_LabPrintfoot.Size.Height);
					form_LabPrintfoot.Show();
					string[] array6 = new string[3] { "更新成功！", "更新成功！", "Update Successfully!" };
					MainForm0.CmMessageBoxTop_Ok(array6[MainForm0.USR_INIT.mLanguage]);
					form_LabPrintfoot.Dispose();
				}
				else
				{
					string[] array7 = new string[3]
					{
						"[封装库]中没有[" + mChipFootprint + "]项目, 是否新建?",
						"[封裝庫]中沒有[" + mChipFootprint + "]項目, 是否新建?",
						"[Footprint Lab] does not have [" + mChipFootprint + "] item, are you going to create a new item?"
					};
					if (MainForm0.CmMessageBox(array7[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.No)
					{
						break;
					}
					USR_LIB uSR_LIB3 = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[MainForm0.FP_PATH.mFootprintLib_Index]);
					FootPrint footPrint2 = new FootPrint();
					footPrint2.name = mChipFootprint;
					footPrint2.nick_namelist = new BindingList<string>();
					footPrint2.nick_namelist.Add(mChipFootprint);
					footPrint2.angle = array[num].angle;
					footPrint2.collect_rate = array[num].mCollectDelta;
					footPrint2.feeder_ant_delay = ((mStackLib.sel == ProviderType.Plate) ? array[num].mPlt.mAutoEntTimeDelay : ((float)array[num].mFeederDelay));
					footPrint2.height = array[num].height;
					footPrint2.iscollect = array[num].mIsCollect;
					footPrint2.isscan_r = array[num].mIsScanR;
					footPrint2.width = array[num].width;
					footPrint2.length = array[num].lenght;
					footPrint2.first_feederin = array[num].mAutoPixXY.first_feederin;
					for (int num6 = 0; num6 < HW.mZnNum[mFn]; num6++)
					{
						if (array[num].mZnData[num6].mEnabled)
						{
							footPrint2.mnt_delay = array[num].mZnData[num6].Mnt.Delay;
							footPrint2.mnt_down_speed = array[num].mZnData[num6].Mnt.DownSpeed;
							footPrint2.mnt_up_speed = array[num].mZnData[num6].Mnt.UpSpeed;
							footPrint2.mnt_offset = array[num].mZnData[num6].Mnt.Offset;
							footPrint2.threshold = array[num].mZnData[num6].threshold;
							footPrint2.pik_delay = array[num].mZnData[num6].Pik.Delay;
							footPrint2.pik_down_speed = array[num].mZnData[num6].Pik.DownSpeed;
							footPrint2.pik_up_speed = array[num].mZnData[num6].Pik.UpSpeed;
							footPrint2.pik_offset = array[num].mZnData[num6].Pik.Offset;
							break;
						}
					}
					footPrint2.name = mChipFootprint;
					footPrint2.nick_namelist = new BindingList<string>();
					footPrint2.nick_namelist.Add(mChipFootprint);
					footPrint2.camera = USR3B.mPointlistCat[num3].Cameratype;
					float num7 = 0f;
					if (footPrint2.camera == CameraType.Fast)
					{
						num7 = USR.mFastCamRatio[0][MainForm0.mZn[mFn]];
					}
					else if (footPrint2.camera == CameraType.High)
					{
						num7 = USR.mHighCamRatio[0];
					}
					footPrint2.scan_r_mm = (float)array[num].scanR * num7 / 100f;
					footPrint2.delta = USR3B.mPointlistCat[num3].Delta;
					footPrint2.height = USR3B.mPointlistCat[num3].Height;
					footPrint2.islowspeed = USR3B.mPointlistCat[num3].IsLowSpeed;
					footPrint2.loop = USR3B.mPointlistCat[num3].Looptype;
					footPrint2.nozzle = USR3B.mPointlistCat[num3].Nozzletype0;
					footPrint2.feedertype = USR3B.mPointlistCat[num3].Feedertype;
					footPrint2.providertype = MainForm0.format_feeder_to_providertype(USR3B.mPointlistCat[num3].Feedertype);
					footPrint2.visual = USR3B.mPointlistCat[num3].Visualtype;
					uSR_LIB3.fpcatlist[uSR_LIB3.fpcatindex].footlist.Add(footPrint2);
					uSR_LIB3.fpcatlist[uSR_LIB3.fpcatindex].index = uSR_LIB3.fpcatlist[uSR_LIB3.fpcatindex].footlist.Count - 1;
					MainForm0.save_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[MainForm0.FP_PATH.mFootprintLib_Index], uSR_LIB3);
					Form_LabPrintfoot form_LabPrintfoot2 = new Form_LabPrintfoot(MainForm0.USR_INIT, 1);
					form_LabPrintfoot2.StartPosition = FormStartPosition.CenterParent;
					form_LabPrintfoot2.Size = new Size(form_LabPrintfoot2.Size.Width, form_LabPrintfoot2.Size.Height);
					form_LabPrintfoot2.Show();
					form_LabPrintfoot2.footprint_rename();
				}
				MainForm0.save_usrProjectData();
				stacksel_new_flushdata();
				break;
			}
			}
		}

		private void label_stacknew_chipinfo_DoubleClick(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			Form_Fill_Value_Footprint form_Fill_Value_Footprint = new Form_Fill_Value_Footprint(array[num].mChipValue, array[num].mChipFootprint);
			if (form_Fill_Value_Footprint.ShowDialog() == DialogResult.OK)
			{
				array[num].mChipValue = form_Fill_Value_Footprint.get_value();
				array[num].mChipFootprint = form_Fill_Value_Footprint.get_footprint();
				label_stacknew_chipinfo.Text = array[num].mChipValue + " " + array[num].mChipFootprint;
				MainForm0.save_usrProjectData();
			}
		}

		private void button_pikH_View_Click(object sender, EventArgs e)
		{
			if (uc_pikCheckH == null || uc_pikCheckH.IsDisposed)
			{
				uc_pikCheckH = new UserControl_CheckH(mFn, USR, mStackLib, 0);
				panel_context3.Controls.Add(uc_pikCheckH);
				uc_pikCheckH.Location = new Point(panel_stacknew_pik.Location.X - 4, panel_stacknew_pik.Location.Y + 50);
				uc_pikCheckH.stacksel_new_flushZn += stacksel_new_flushZn;
				uc_pikCheckH.set_offset_numeric += set_offset_numeric;
				uc_pikCheckH.BringToFront();
				uc_pikCheckH.Show();
			}
		}

		private void button_mntH_View_Click(object sender, EventArgs e)
		{
			if (uc_mntCheckH == null || uc_mntCheckH.IsDisposed)
			{
				uc_mntCheckH = new UserControl_CheckH(mFn, USR, mStackLib, 1);
				panel_context4.Controls.Add(uc_mntCheckH);
				uc_mntCheckH.Location = new Point(panel_stacknew_mnt.Location.X - 4, panel_stacknew_mnt.Location.Y + 50);
				uc_mntCheckH.stacksel_new_flushZn += stacksel_new_flushZn;
				uc_mntCheckH.set_offset_numeric += set_offset_numeric;
				uc_mntCheckH.BringToFront();
				uc_mntCheckH.Show();
			}
		}

		private void button_pikH_Goto_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			string text = (string)((Button)sender).Tag;
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				int num2 = array[num].mZnData[MainForm0.mZn[mFn]].Pik.Height;
				if (text == "mnt")
				{
					num2 = array[num].mZnData[MainForm0.mZn[mFn]].Mnt.Height;
				}
				thread.IsBackground = true;
				thread.Start(num2);
			}
		}

		public void set_offset_numeric(int flag, int z, float value)
		{
			switch (flag)
			{
			case 0:
				numericUpDown_pikoffset[MainForm0.mZn[mFn]].Value = (decimal)value;
				break;
			case 1:
				numericUpDown_mntoffset[MainForm0.mZn[mFn]].Value = (decimal)value;
				break;
			}
		}

		private void button_autoPixXY_Click(object sender, EventArgs e)
		{
			panel_autopikxy.Location = new Point(panel_context3.Location.X + 10, panel_context3.Location.Y);
			panel_autopikxy.Visible = true;
		}

		private void button_pikH_Save_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			string text = (string)((Button)sender).Tag;
			int num2 = MainForm0.mZn[mFn];
			int num3 = MainForm0.mCur[mFn].z[num2];
			if (num3 == 0)
			{
				MainForm0.CmMessageBoxTop_Ok((new string[3] { "无法保存0高度!", "無法保存0高度!", "Cannot Save 0 Height!" })[USR_INIT.mLanguage]);
			}
			else if (text == "pik")
			{
				array[num].mZnData[num2].Pik.Height = num3;
				label_stack_pikH[num2].Text = Math.Abs(num3).ToString();
			}
			else if (text == "mnt")
			{
				array[num].mZnData[num2].Mnt.Height = num3;
				label_stack_mntH[num2].Text = Math.Abs(num3).ToString();
			}
		}

		private void button_curdefault_Click(object sender, EventArgs e)
		{
			string[] array = new string[3] { "是否当前料站设置默认值？", "是否當前料站設置默認值？", "Set default value to current stack." };
			if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				StackElement[] array2 = mStackLib.stacktab[(int)mStackLib.sel];
				int num = mStackLib.index[(int)mStackLib.sel];
				array2[num].lenght = 0f;
				array2[num].width = 0f;
				array2[num].height = 0f;
				array2[num].mCollectDelta = 25f;
				array2[num].mIsCollect = false;
				array2[num].mIsScanR = false;
				for (int i = 0; i < HW.mZnNum[mFn]; i++)
				{
					array2[num].mZnData[i].threshold = 127;
					array2[num].mZnData[i].Pik.Offset = 0f;
					array2[num].mZnData[i].Pik.Height = 0;
					array2[num].mZnData[i].Pik.DownSpeed = 64;
					array2[num].mZnData[i].Pik.UpSpeed = 64;
					array2[num].mZnData[i].Pik.Delay = 5;
					array2[num].mZnData[i].Mnt.DownSpeed = 64;
					array2[num].mZnData[i].Mnt.UpSpeed = 64;
					array2[num].mZnData[i].Mnt.Offset = 0f;
					array2[num].mZnData[i].Mnt.Delay = 25;
					array2[num].mZnData[i].Mnt.Height = 0;
				}
				stacksel_new_flushpage();
				stacksel_new_flushdata();
			}
		}

		private void AddButtonPic(Button btn)
		{
			btn.MouseEnter += delegate(object sender, EventArgs e)
			{
				((Button)sender).BackgroundImage = Resources.Button_Red_Up;
			};
			btn.MouseLeave += delegate(object sender, EventArgs e)
			{
				((Button)sender).BackgroundImage = Resources.Button_Red_Gray;
			};
			btn.MouseDown += delegate(object sender, MouseEventArgs e)
			{
				((Button)sender).BackgroundImage = Resources.Button_Red_Down;
			};
			btn.MouseUp += delegate(object sender, MouseEventArgs e)
			{
				((Button)sender).BackgroundImage = Resources.Button_Red_Up;
			};
		}

		private void AddButtonPic(Button btn, Bitmap scan0, Bitmap scan1, Bitmap scan2)
		{
			btn.MouseEnter += delegate(object sender, EventArgs e)
			{
				((Button)sender).BackgroundImage = scan1;
			};
			btn.MouseLeave += delegate(object sender, EventArgs e)
			{
				((Button)sender).BackgroundImage = scan0;
			};
			btn.MouseDown += delegate(object sender, MouseEventArgs e)
			{
				((Button)sender).BackgroundImage = scan2;
			};
			btn.MouseUp += delegate(object sender, MouseEventArgs e)
			{
				((Button)sender).BackgroundImage = scan1;
			};
		}

		private void SelButton_Provider(Button btn)
		{
			Bitmap map0 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData = map0.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap map1 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData2 = map1.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap map2 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData3 = map2.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			MainForm0.moon_qign_button_create(btn.Size.Width, btn.Size.Height, bitmapData.Scan0, 140, 140, 140, bitmapData2.Scan0, 0, 0, 255, bitmapData3.Scan0, 0, 0, 255);
			map0.UnlockBits(bitmapData);
			map1.UnlockBits(bitmapData2);
			map2.UnlockBits(bitmapData3);
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
			if ((ProviderType)btn.Tag != mStackLib.sel)
			{
				btn.BackgroundImage = map0;
			}
			else
			{
				btn.BackgroundImage = map2;
			}
			btn.MouseEnter += delegate(object sender, EventArgs e)
			{
				if ((ProviderType)btn.Tag != mStackLib.sel)
				{
					((Button)sender).BackgroundImage = map1;
				}
			};
			btn.MouseLeave += delegate(object sender, EventArgs e)
			{
				if ((ProviderType)btn.Tag != mStackLib.sel)
				{
					((Button)sender).BackgroundImage = map0;
				}
			};
			btn.MouseDown += delegate(object sender, MouseEventArgs e)
			{
				if ((ProviderType)btn.Tag != mStackLib.sel)
				{
					((Button)sender).BackgroundImage = map2;
				}
			};
			btn.MouseUp += delegate
			{
				for (int i = 0; i < 3; i++)
				{
					if ((int)btn.Tag != i)
					{
						button_stacksel[i].BackgroundImage = map0;
					}
				}
			};
		}

		private void init_buttons()
		{
			_ = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			MainForm0.common_setButton_PressDownMode(button_openfeeder, MainForm0.mIsFeederOn[mFn][num], Color.Silver, Color.Salmon);
		}

		private void button_close_enableZn_Click(object sender, EventArgs e)
		{
			panel_enable_Zn.Visible = false;
		}

		private void button_EnableNozzle_Click(object sender, EventArgs e)
		{
			panel_enable_Zn.BringToFront();
			panel_enable_Zn.Visible = true;
		}

		private void button_autopik_close_Click(object sender, EventArgs e)
		{
			panel_autopikxy.Visible = false;
		}

		private void button_autorun_cur_Click(object sender, EventArgs e)
		{
			__button_autorun_cur_Click(sender, e);
		}

		private void button_prev_Click(object sender, EventArgs e)
		{
			__button_prev_Click(sender, e);
		}

		private void button_savepikxy_Click(object sender, EventArgs e)
		{
			__button_savepikxy_Click(sender, e);
		}

		private void button_stop_Click(object sender, EventArgs e)
		{
			__button_stop_Click(sender, e);
		}

		private void checkBox_autosave_CheckedChanged(object sender, EventArgs e)
		{
			USR2.mIsAutoPik_AutoSave = checkBox_autosave.Checked;
		}

		private void numericUpDown_scanr_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_scanr_ValueChanged(sender, e);
		}

		private void numericUpDown_first_feederin_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_first_feederin_ValueChanged(sender, e);
		}
	}
}
