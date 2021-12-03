using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_pcbedit_mark : UserControl
	{
		private IContainer components;

		private Label label2;

		private CnButton button_PCBE_Mark_OK;

		private Label label_title_mark;

		private Panel panel_setmark;

		private CnButton button_MarkTest;

		private Panel panel10;

		private Label label58;

		private PictureBox pictureBox1;

		private PictureBox pictureBox4;

		private Label label108;

		private Label label105;

		private Label label_Mark0;

		private Label label_Mark1;

		private Panel panel_pricise_mark1;

		private CnButton button_priciseMarkCheck1;

		private CnButton button_priciseMark1;

		private Panel panel_pricise_mark0;

		private CnButton button_priciseMarkCheck0;

		private CnButton button_priciseMark0;

		private Panel panel38;

		private Panel panel_PcbAdjust;

		private CnButton button_adjust_gotoalmostM2;

		private CnButton button_adjust_autoM1;

		private CnButton button_adjust_autoM0;

		private Label label_adjust1XY;

		private Label label_adjust0XY;

		private CnButton button_PcbAdjust;

		private CnButton button_adjust1XY_moveto;

		private CnButton button_adjust1XY_save;

		private CnButton button_adjust0XY_moveto;

		private CnButton button_adjust0XY_save;

		private PictureBox pictureBox_adjust1XY;

		private PictureBox pictureBox_adjust0XY;

		private CheckBox checkBox_PcbAdjust;

		private Label label_priciseMark1_info;

		private Label label_priciseMark0_info;

		private CheckBox checkBox_priciseMark1;

		private CheckBox checkBox_priciseMark0;

		private NumericUpDown numericUpDown_MarkRecognizeRate1;

		private NumericUpDown numericUpDown_MarkRecognizeRate;

		private NumericUpDown numericUpDown_MarkPicSize1;

		private NumericUpDown numericUpDown_MarkPicSize;

		private CnButton button_mark1save;

		private CnButton button_mark1moveto;

		private PictureBox pictureBox_mark1;

		private PictureBox pictureBox_mark0;

		private CnButton button_mark0save;

		private CnButton button_mark0moveto;

		private Panel panel1;

		private Label label1;

		private CnButton button_sdd1;

		private CnButton button_sdd32;

		private Label label5;

		private Label label4;

		private CheckBox checkBox_search_mark0;

		private CheckBox checkBox2;

		private Label label3;

		private Label label7;

		private CnButton button4;

		private CnButton button3;

		private Label label6;

		private CheckBox checkBox_pcbadjust_pricise;

		private CnButton button_pcbadjust_ref0;

		private CnButton button5;

		private Panel panel_pcbadjust_M2;

		private Panel panel_pcbadjust_M1;

		private Label label10;

		private Label label9;

		private Panel panel_pcbadjust_ref1;

		private Label label8;

		private CnButton button7;

		private Label label13;

		private CnButton button6;

		private Label label11;

		private Label label12;

		private Panel panel_pcbadjust_ref2;

		private CnButton button1;

		private Label label14;

		private Label label15;

		private CnButton button2;

		private CnButton button8;

		private Label label16;

		private Label label17;

		private CnButton button9;

		private Label label18;

		private Label label19;

		private CnButton button_pcbadjust_reset;

		private Panel panel_pcbadjust_debug;

		private NumericUpDown numericUpDown_pcbadjust_debug_y_offset;

		private NumericUpDown numericUpDown_pcbadjust_debug_x_offset;

		private Label label21;

		private Label label20;

		private Form_MarkCamParaUSR3 mForm_MarkCamParaUSR3;

		public USR_DATA USR;

		public USR3_DATA USR3;

		public Form_MarkGen mFormMarkGen;

		private PictureBox[] pic_mark;

		private Label[] label_Mark_coord;

		private Panel[] panel_pricise_mark;

		private NumericUpDown[] num_MarkPicSize;

		private NumericUpDown[] num_MarkRecognizeRate;

		private Label[] label_priciseMark_info;

		private CheckBox[] checkBox_priciseMark;

		private CheckBox[] checkBox_search_coord;

		private Label[] label_Search_coord;

		private CnButton[] button_search_save_xy;

		private CnButton[] button_search_goto_xy;

		private PictureBox[] pic_adjust;

		private Label[] label_adjust_coord;

		private USR_INIT_DATA USR_INIT;

		private int mFn;

		public Bitmap Pic_MarkGen_Orgin;

		public Bitmap Pic_MarkGen_Ct;

		public bool saved_lighton;

		public bool saved_ledon;

		public MarkCamPara saved_markpara = new MarkCamPara();

		public Thread mThd_PriciseMarkGen;

		public event void_Func_bool SetEdit_XY;

		public event bool_Func_void GetEdit_XY;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.vs_class.UserControl_pcbedit_mark));
			label2 = new System.Windows.Forms.Label();
			label_title_mark = new System.Windows.Forms.Label();
			panel_setmark = new System.Windows.Forms.Panel();
			button_MarkTest = new QIGN_COMMON.vs_acontrol.CnButton();
			panel1 = new System.Windows.Forms.Panel();
			checkBox2 = new System.Windows.Forms.CheckBox();
			checkBox_search_mark0 = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			numericUpDown_MarkRecognizeRate1 = new System.Windows.Forms.NumericUpDown();
			button4 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_sdd1 = new QIGN_COMMON.vs_acontrol.CnButton();
			numericUpDown_MarkPicSize1 = new System.Windows.Forms.NumericUpDown();
			button3 = new QIGN_COMMON.vs_acontrol.CnButton();
			numericUpDown_MarkRecognizeRate = new System.Windows.Forms.NumericUpDown();
			button_sdd32 = new QIGN_COMMON.vs_acontrol.CnButton();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			numericUpDown_MarkPicSize = new System.Windows.Forms.NumericUpDown();
			panel10 = new System.Windows.Forms.Panel();
			label58 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox4 = new System.Windows.Forms.PictureBox();
			label108 = new System.Windows.Forms.Label();
			label105 = new System.Windows.Forms.Label();
			label_Mark0 = new System.Windows.Forms.Label();
			label_Mark1 = new System.Windows.Forms.Label();
			panel_pricise_mark1 = new System.Windows.Forms.Panel();
			button_priciseMarkCheck1 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_priciseMark1 = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_pricise_mark0 = new System.Windows.Forms.Panel();
			button_priciseMarkCheck0 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_priciseMark0 = new QIGN_COMMON.vs_acontrol.CnButton();
			panel38 = new System.Windows.Forms.Panel();
			panel_pcbadjust_debug = new System.Windows.Forms.Panel();
			numericUpDown_pcbadjust_debug_y_offset = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pcbadjust_debug_x_offset = new System.Windows.Forms.NumericUpDown();
			label21 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			panel_PcbAdjust = new System.Windows.Forms.Panel();
			panel_pcbadjust_ref2 = new System.Windows.Forms.Panel();
			button1 = new QIGN_COMMON.vs_acontrol.CnButton();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			button2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button8 = new QIGN_COMMON.vs_acontrol.CnButton();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			button9 = new QIGN_COMMON.vs_acontrol.CnButton();
			label18 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			panel_pcbadjust_ref1 = new System.Windows.Forms.Panel();
			button5 = new QIGN_COMMON.vs_acontrol.CnButton();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			button_pcbadjust_ref0 = new QIGN_COMMON.vs_acontrol.CnButton();
			button7 = new QIGN_COMMON.vs_acontrol.CnButton();
			label13 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			button6 = new QIGN_COMMON.vs_acontrol.CnButton();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			checkBox_pcbadjust_pricise = new System.Windows.Forms.CheckBox();
			panel_pcbadjust_M2 = new System.Windows.Forms.Panel();
			button_adjust_autoM1 = new QIGN_COMMON.vs_acontrol.CnButton();
			pictureBox_adjust1XY = new System.Windows.Forms.PictureBox();
			button_adjust1XY_save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_adjust1XY_moveto = new QIGN_COMMON.vs_acontrol.CnButton();
			label_adjust1XY = new System.Windows.Forms.Label();
			button_PcbAdjust = new QIGN_COMMON.vs_acontrol.CnButton();
			button_adjust_gotoalmostM2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbadjust_reset = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_pcbadjust_M1 = new System.Windows.Forms.Panel();
			button_adjust_autoM0 = new QIGN_COMMON.vs_acontrol.CnButton();
			pictureBox_adjust0XY = new System.Windows.Forms.PictureBox();
			button_adjust0XY_save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_adjust0XY_moveto = new QIGN_COMMON.vs_acontrol.CnButton();
			label_adjust0XY = new System.Windows.Forms.Label();
			checkBox_PcbAdjust = new System.Windows.Forms.CheckBox();
			label_priciseMark1_info = new System.Windows.Forms.Label();
			label_priciseMark0_info = new System.Windows.Forms.Label();
			checkBox_priciseMark1 = new System.Windows.Forms.CheckBox();
			checkBox_priciseMark0 = new System.Windows.Forms.CheckBox();
			button_mark1save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_mark1moveto = new QIGN_COMMON.vs_acontrol.CnButton();
			pictureBox_mark1 = new System.Windows.Forms.PictureBox();
			pictureBox_mark0 = new System.Windows.Forms.PictureBox();
			button_mark0save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_mark0moveto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBE_Mark_OK = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_setmark.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkRecognizeRate1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkPicSize1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkRecognizeRate).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkPicSize).BeginInit();
			panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			panel_pricise_mark1.SuspendLayout();
			panel_pricise_mark0.SuspendLayout();
			panel38.SuspendLayout();
			panel_pcbadjust_debug.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pcbadjust_debug_y_offset).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pcbadjust_debug_x_offset).BeginInit();
			panel_PcbAdjust.SuspendLayout();
			panel_pcbadjust_ref2.SuspendLayout();
			panel_pcbadjust_ref1.SuspendLayout();
			panel_pcbadjust_M2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_adjust1XY).BeginInit();
			panel_pcbadjust_M1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_adjust0XY).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_mark1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_mark0).BeginInit();
			SuspendLayout();
			label2.Location = new System.Drawing.Point(-15, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(740, 5);
			label2.TabIndex = 24;
			label_title_mark.Font = new System.Drawing.Font("黑体", 14.25f);
			label_title_mark.Location = new System.Drawing.Point(211, 10);
			label_title_mark.Name = "label_title_mark";
			label_title_mark.Size = new System.Drawing.Size(297, 32);
			label_title_mark.TabIndex = 26;
			label_title_mark.Text = "Mark点设置";
			label_title_mark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_setmark.Controls.Add(button_MarkTest);
			panel_setmark.Controls.Add(panel1);
			panel_setmark.Controls.Add(panel10);
			panel_setmark.Controls.Add(panel_pricise_mark1);
			panel_setmark.Controls.Add(panel_pricise_mark0);
			panel_setmark.Controls.Add(panel38);
			panel_setmark.Controls.Add(label_priciseMark1_info);
			panel_setmark.Controls.Add(label_priciseMark0_info);
			panel_setmark.Controls.Add(checkBox_priciseMark1);
			panel_setmark.Controls.Add(checkBox_priciseMark0);
			panel_setmark.Controls.Add(button_mark1save);
			panel_setmark.Controls.Add(button_mark1moveto);
			panel_setmark.Controls.Add(pictureBox_mark1);
			panel_setmark.Controls.Add(pictureBox_mark0);
			panel_setmark.Controls.Add(button_mark0save);
			panel_setmark.Controls.Add(button_mark0moveto);
			panel_setmark.Location = new System.Drawing.Point(20, 45);
			panel_setmark.Name = "panel_setmark";
			panel_setmark.Size = new System.Drawing.Size(659, 678);
			panel_setmark.TabIndex = 25;
			button_MarkTest.BackColor = System.Drawing.SystemColors.Control;
			button_MarkTest.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MarkTest.CnPressDownColor = System.Drawing.Color.White;
			button_MarkTest.Font = new System.Drawing.Font("黑体", 10f);
			button_MarkTest.Location = new System.Drawing.Point(289, 212);
			button_MarkTest.Name = "button_MarkTest";
			button_MarkTest.Size = new System.Drawing.Size(80, 33);
			button_MarkTest.TabIndex = 0;
			button_MarkTest.Text = "MARK测试";
			button_MarkTest.UseVisualStyleBackColor = false;
			button_MarkTest.Click += new System.EventHandler(button_MarkTest_Click);
			panel1.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			panel1.Controls.Add(checkBox2);
			panel1.Controls.Add(checkBox_search_mark0);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(numericUpDown_MarkRecognizeRate1);
			panel1.Controls.Add(button4);
			panel1.Controls.Add(button_sdd1);
			panel1.Controls.Add(numericUpDown_MarkPicSize1);
			panel1.Controls.Add(button3);
			panel1.Controls.Add(numericUpDown_MarkRecognizeRate);
			panel1.Controls.Add(button_sdd32);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(numericUpDown_MarkPicSize);
			panel1.Location = new System.Drawing.Point(0, 254);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(659, 66);
			panel1.TabIndex = 25;
			checkBox2.AutoSize = true;
			checkBox2.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox2.Location = new System.Drawing.Point(364, 6);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(145, 18);
			checkBox2.TabIndex = 21;
			checkBox2.Tag = "1";
			checkBox2.Text = "Mark2自定义搜索点";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox2.CheckedChanged += new System.EventHandler(checkBox_search_mark0_CheckedChanged);
			checkBox_search_mark0.AutoSize = true;
			checkBox_search_mark0.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_search_mark0.Location = new System.Drawing.Point(129, 8);
			checkBox_search_mark0.Name = "checkBox_search_mark0";
			checkBox_search_mark0.Size = new System.Drawing.Size(145, 18);
			checkBox_search_mark0.TabIndex = 21;
			checkBox_search_mark0.Tag = "0";
			checkBox_search_mark0.Text = "Mark1自定义搜索点";
			checkBox_search_mark0.UseVisualStyleBackColor = true;
			checkBox_search_mark0.CheckedChanged += new System.EventHandler(checkBox_search_mark0_CheckedChanged);
			label3.BackColor = System.Drawing.Color.WhiteSmoke;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label3.Enabled = false;
			label3.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(361, 30);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(52, 32);
			label3.TabIndex = 18;
			label3.Tag = "1";
			label3.Text = "X00000\r\nY00000";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label1.BackColor = System.Drawing.Color.WhiteSmoke;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label1.Enabled = false;
			label1.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(126, 31);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(52, 32);
			label1.TabIndex = 18;
			label1.Tag = "0";
			label1.Text = "X00000\r\nY00000";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 10.5f);
			label7.Location = new System.Drawing.Point(535, 37);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(63, 14);
			label7.TabIndex = 2;
			label7.Text = "点识别率";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 10.5f);
			label5.Location = new System.Drawing.Point(0, 40);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(63, 14);
			label5.TabIndex = 2;
			label5.Text = "点识别率";
			numericUpDown_MarkRecognizeRate1.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_MarkRecognizeRate1.Location = new System.Drawing.Point(603, 32);
			numericUpDown_MarkRecognizeRate1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_MarkRecognizeRate1.Name = "numericUpDown_MarkRecognizeRate1";
			numericUpDown_MarkRecognizeRate1.Size = new System.Drawing.Size(49, 23);
			numericUpDown_MarkRecognizeRate1.TabIndex = 1;
			numericUpDown_MarkRecognizeRate1.Tag = "1";
			numericUpDown_MarkRecognizeRate1.Value = new decimal(new int[4] { 50, 0, 0, 0 });
			button4.BackColor = System.Drawing.SystemColors.Control;
			button4.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button4.CnPressDownColor = System.Drawing.Color.White;
			button4.Enabled = false;
			button4.Font = new System.Drawing.Font("黑体", 10f);
			button4.Location = new System.Drawing.Point(417, 31);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(42, 32);
			button4.TabIndex = 17;
			button4.Tag = "1";
			button4.Text = "保存";
			button4.UseVisualStyleBackColor = false;
			button4.Click += new System.EventHandler(button_save_search_xy_Click);
			button_sdd1.BackColor = System.Drawing.SystemColors.Control;
			button_sdd1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_sdd1.CnPressDownColor = System.Drawing.Color.White;
			button_sdd1.Enabled = false;
			button_sdd1.Font = new System.Drawing.Font("黑体", 10f);
			button_sdd1.Location = new System.Drawing.Point(182, 32);
			button_sdd1.Name = "button_sdd1";
			button_sdd1.Size = new System.Drawing.Size(42, 32);
			button_sdd1.TabIndex = 17;
			button_sdd1.Tag = "0";
			button_sdd1.Text = "保存";
			button_sdd1.UseVisualStyleBackColor = false;
			button_sdd1.Click += new System.EventHandler(button_save_search_xy_Click);
			numericUpDown_MarkPicSize1.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_MarkPicSize1.Location = new System.Drawing.Point(603, 5);
			numericUpDown_MarkPicSize1.Maximum = new decimal(new int[4] { 150, 0, 0, 0 });
			numericUpDown_MarkPicSize1.Minimum = new decimal(new int[4] { 50, 0, 0, 0 });
			numericUpDown_MarkPicSize1.Name = "numericUpDown_MarkPicSize1";
			numericUpDown_MarkPicSize1.Size = new System.Drawing.Size(49, 23);
			numericUpDown_MarkPicSize1.TabIndex = 12;
			numericUpDown_MarkPicSize1.Tag = "1";
			numericUpDown_MarkPicSize1.Value = new decimal(new int[4] { 100, 0, 0, 0 });
			button3.BackColor = System.Drawing.SystemColors.Control;
			button3.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button3.CnPressDownColor = System.Drawing.Color.White;
			button3.Enabled = false;
			button3.Font = new System.Drawing.Font("黑体", 10f);
			button3.Location = new System.Drawing.Point(462, 31);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(42, 32);
			button3.TabIndex = 17;
			button3.Tag = "1";
			button3.Text = "定位";
			button3.UseVisualStyleBackColor = false;
			button3.Click += new System.EventHandler(button_goto_search_xy_Click);
			numericUpDown_MarkRecognizeRate.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_MarkRecognizeRate.Location = new System.Drawing.Point(67, 35);
			numericUpDown_MarkRecognizeRate.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_MarkRecognizeRate.Name = "numericUpDown_MarkRecognizeRate";
			numericUpDown_MarkRecognizeRate.Size = new System.Drawing.Size(49, 23);
			numericUpDown_MarkRecognizeRate.TabIndex = 1;
			numericUpDown_MarkRecognizeRate.Tag = "0";
			numericUpDown_MarkRecognizeRate.Value = new decimal(new int[4] { 50, 0, 0, 0 });
			button_sdd32.BackColor = System.Drawing.SystemColors.Control;
			button_sdd32.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_sdd32.CnPressDownColor = System.Drawing.Color.White;
			button_sdd32.Enabled = false;
			button_sdd32.Font = new System.Drawing.Font("黑体", 10f);
			button_sdd32.Location = new System.Drawing.Point(227, 32);
			button_sdd32.Name = "button_sdd32";
			button_sdd32.Size = new System.Drawing.Size(42, 32);
			button_sdd32.TabIndex = 17;
			button_sdd32.Tag = "0";
			button_sdd32.Text = "定位";
			button_sdd32.UseVisualStyleBackColor = false;
			button_sdd32.Click += new System.EventHandler(button_goto_search_xy_Click);
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("黑体", 10.5f);
			label6.Location = new System.Drawing.Point(536, 10);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(63, 14);
			label6.TabIndex = 13;
			label6.Text = "识别大小";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 10.5f);
			label4.Location = new System.Drawing.Point(1, 13);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(63, 14);
			label4.TabIndex = 13;
			label4.Text = "识别大小";
			numericUpDown_MarkPicSize.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_MarkPicSize.Location = new System.Drawing.Point(67, 8);
			numericUpDown_MarkPicSize.Maximum = new decimal(new int[4] { 150, 0, 0, 0 });
			numericUpDown_MarkPicSize.Minimum = new decimal(new int[4] { 50, 0, 0, 0 });
			numericUpDown_MarkPicSize.Name = "numericUpDown_MarkPicSize";
			numericUpDown_MarkPicSize.Size = new System.Drawing.Size(49, 23);
			numericUpDown_MarkPicSize.TabIndex = 12;
			numericUpDown_MarkPicSize.Tag = "0";
			numericUpDown_MarkPicSize.Value = new decimal(new int[4] { 100, 0, 0, 0 });
			panel10.BackColor = System.Drawing.Color.DarkSeaGreen;
			panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel10.Controls.Add(label58);
			panel10.Controls.Add(pictureBox1);
			panel10.Controls.Add(pictureBox4);
			panel10.Controls.Add(label108);
			panel10.Controls.Add(label105);
			panel10.Controls.Add(label_Mark0);
			panel10.Controls.Add(label_Mark1);
			panel10.Location = new System.Drawing.Point(162, 3);
			panel10.Name = "panel10";
			panel10.Size = new System.Drawing.Size(336, 128);
			panel10.TabIndex = 4;
			label58.AutoSize = true;
			label58.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label58.Location = new System.Drawing.Point(145, 48);
			label58.Name = "label58";
			label58.Size = new System.Drawing.Size(50, 26);
			label58.TabIndex = 33;
			label58.Text = "PCB";
			pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			pictureBox1.Location = new System.Drawing.Point(312, 96);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(19, 19);
			pictureBox1.TabIndex = 32;
			pictureBox1.TabStop = false;
			pictureBox4.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox4.BackgroundImage");
			pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			pictureBox4.Location = new System.Drawing.Point(10, 10);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new System.Drawing.Size(19, 19);
			pictureBox4.TabIndex = 31;
			pictureBox4.TabStop = false;
			label108.AutoSize = true;
			label108.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label108.Location = new System.Drawing.Point(249, 96);
			label108.Name = "label108";
			label108.Size = new System.Drawing.Size(60, 19);
			label108.TabIndex = 2;
			label108.Text = "Mark-2";
			label105.AutoSize = true;
			label105.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label105.Location = new System.Drawing.Point(29, 10);
			label105.Name = "label105";
			label105.Size = new System.Drawing.Size(60, 19);
			label105.TabIndex = 0;
			label105.Text = "Mark-1";
			label_Mark0.BackColor = System.Drawing.Color.WhiteSmoke;
			label_Mark0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_Mark0.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_Mark0.Location = new System.Drawing.Point(10, 42);
			label_Mark0.Name = "label_Mark0";
			label_Mark0.Size = new System.Drawing.Size(68, 40);
			label_Mark0.TabIndex = 1;
			label_Mark0.Tag = "0";
			label_Mark0.Text = "X00000\r\nY00000";
			label_Mark0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_Mark1.BackColor = System.Drawing.Color.WhiteSmoke;
			label_Mark1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_Mark1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_Mark1.Location = new System.Drawing.Point(257, 42);
			label_Mark1.Name = "label_Mark1";
			label_Mark1.Size = new System.Drawing.Size(68, 40);
			label_Mark1.TabIndex = 5;
			label_Mark1.Tag = "1";
			label_Mark1.Text = "X00000\r\nY00000";
			label_Mark1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_pricise_mark1.Controls.Add(button_priciseMarkCheck1);
			panel_pricise_mark1.Controls.Add(button_priciseMark1);
			panel_pricise_mark1.Location = new System.Drawing.Point(346, 154);
			panel_pricise_mark1.Name = "panel_pricise_mark1";
			panel_pricise_mark1.Size = new System.Drawing.Size(146, 47);
			panel_pricise_mark1.TabIndex = 24;
			button_priciseMarkCheck1.BackColor = System.Drawing.SystemColors.Control;
			button_priciseMarkCheck1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_priciseMarkCheck1.CnPressDownColor = System.Drawing.Color.White;
			button_priciseMarkCheck1.Font = new System.Drawing.Font("黑体", 10f);
			button_priciseMarkCheck1.Location = new System.Drawing.Point(92, 1);
			button_priciseMarkCheck1.Name = "button_priciseMarkCheck1";
			button_priciseMarkCheck1.Size = new System.Drawing.Size(52, 42);
			button_priciseMarkCheck1.TabIndex = 19;
			button_priciseMarkCheck1.Tag = "1";
			button_priciseMarkCheck1.Text = "查看";
			button_priciseMarkCheck1.UseVisualStyleBackColor = false;
			button_priciseMarkCheck1.Click += new System.EventHandler(button_priciseMarkCheck0_Click);
			button_priciseMark1.BackColor = System.Drawing.SystemColors.Control;
			button_priciseMark1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_priciseMark1.CnPressDownColor = System.Drawing.Color.White;
			button_priciseMark1.Font = new System.Drawing.Font("黑体", 10f);
			button_priciseMark1.Location = new System.Drawing.Point(3, 1);
			button_priciseMark1.Name = "button_priciseMark1";
			button_priciseMark1.Size = new System.Drawing.Size(86, 42);
			button_priciseMark1.TabIndex = 18;
			button_priciseMark1.Tag = "1";
			button_priciseMark1.Text = "开始定制\r\nMark2";
			button_priciseMark1.UseVisualStyleBackColor = false;
			button_priciseMark1.Click += new System.EventHandler(button_priciseMark0_Click);
			panel_pricise_mark0.Controls.Add(button_priciseMarkCheck0);
			panel_pricise_mark0.Controls.Add(button_priciseMark0);
			panel_pricise_mark0.Location = new System.Drawing.Point(159, 155);
			panel_pricise_mark0.Name = "panel_pricise_mark0";
			panel_pricise_mark0.Size = new System.Drawing.Size(148, 47);
			panel_pricise_mark0.TabIndex = 23;
			button_priciseMarkCheck0.BackColor = System.Drawing.SystemColors.Control;
			button_priciseMarkCheck0.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_priciseMarkCheck0.CnPressDownColor = System.Drawing.Color.White;
			button_priciseMarkCheck0.Font = new System.Drawing.Font("黑体", 10f);
			button_priciseMarkCheck0.Location = new System.Drawing.Point(93, 1);
			button_priciseMarkCheck0.Name = "button_priciseMarkCheck0";
			button_priciseMarkCheck0.Size = new System.Drawing.Size(52, 42);
			button_priciseMarkCheck0.TabIndex = 19;
			button_priciseMarkCheck0.Tag = "0";
			button_priciseMarkCheck0.Text = "查看";
			button_priciseMarkCheck0.UseVisualStyleBackColor = false;
			button_priciseMarkCheck0.Click += new System.EventHandler(button_priciseMarkCheck0_Click);
			button_priciseMark0.BackColor = System.Drawing.SystemColors.Control;
			button_priciseMark0.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_priciseMark0.CnPressDownColor = System.Drawing.Color.White;
			button_priciseMark0.Font = new System.Drawing.Font("黑体", 10f);
			button_priciseMark0.Location = new System.Drawing.Point(4, 1);
			button_priciseMark0.Name = "button_priciseMark0";
			button_priciseMark0.Size = new System.Drawing.Size(86, 42);
			button_priciseMark0.TabIndex = 18;
			button_priciseMark0.Tag = "0";
			button_priciseMark0.Text = "开始定制\r\nMark1";
			button_priciseMark0.UseVisualStyleBackColor = false;
			button_priciseMark0.Click += new System.EventHandler(button_priciseMark0_Click);
			panel38.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			panel38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel38.Controls.Add(panel_pcbadjust_debug);
			panel38.Controls.Add(panel_PcbAdjust);
			panel38.Controls.Add(checkBox_PcbAdjust);
			panel38.Location = new System.Drawing.Point(0, 330);
			panel38.Name = "panel38";
			panel38.Size = new System.Drawing.Size(659, 326);
			panel38.TabIndex = 15;
			panel_pcbadjust_debug.Controls.Add(numericUpDown_pcbadjust_debug_y_offset);
			panel_pcbadjust_debug.Controls.Add(numericUpDown_pcbadjust_debug_x_offset);
			panel_pcbadjust_debug.Controls.Add(label21);
			panel_pcbadjust_debug.Controls.Add(label20);
			panel_pcbadjust_debug.Location = new System.Drawing.Point(2, 36);
			panel_pcbadjust_debug.Name = "panel_pcbadjust_debug";
			panel_pcbadjust_debug.Size = new System.Drawing.Size(109, 59);
			panel_pcbadjust_debug.TabIndex = 25;
			numericUpDown_pcbadjust_debug_y_offset.Location = new System.Drawing.Point(46, 32);
			numericUpDown_pcbadjust_debug_y_offset.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
			numericUpDown_pcbadjust_debug_y_offset.Minimum = new decimal(new int[4] { 100000, 0, 0, -2147483648 });
			numericUpDown_pcbadjust_debug_y_offset.Name = "numericUpDown_pcbadjust_debug_y_offset";
			numericUpDown_pcbadjust_debug_y_offset.Size = new System.Drawing.Size(59, 23);
			numericUpDown_pcbadjust_debug_y_offset.TabIndex = 25;
			numericUpDown_pcbadjust_debug_y_offset.Value = new decimal(new int[4] { 500, 0, 0, 0 });
			numericUpDown_pcbadjust_debug_x_offset.Location = new System.Drawing.Point(46, 6);
			numericUpDown_pcbadjust_debug_x_offset.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
			numericUpDown_pcbadjust_debug_x_offset.Minimum = new decimal(new int[4] { 100000, 0, 0, -2147483648 });
			numericUpDown_pcbadjust_debug_x_offset.Name = "numericUpDown_pcbadjust_debug_x_offset";
			numericUpDown_pcbadjust_debug_x_offset.Size = new System.Drawing.Size(59, 23);
			numericUpDown_pcbadjust_debug_x_offset.TabIndex = 25;
			numericUpDown_pcbadjust_debug_x_offset.Value = new decimal(new int[4] { 200, 0, 0, 0 });
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("楷体", 10.5f);
			label21.Location = new System.Drawing.Point(12, 33);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(28, 14);
			label21.TabIndex = 2;
			label21.Text = "Y偏";
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("楷体", 10.5f);
			label20.Location = new System.Drawing.Point(12, 8);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(28, 14);
			label20.TabIndex = 2;
			label20.Text = "X偏";
			panel_PcbAdjust.Controls.Add(panel_pcbadjust_ref2);
			panel_PcbAdjust.Controls.Add(panel_pcbadjust_ref1);
			panel_PcbAdjust.Controls.Add(checkBox_pcbadjust_pricise);
			panel_PcbAdjust.Controls.Add(panel_pcbadjust_M2);
			panel_PcbAdjust.Controls.Add(button_PcbAdjust);
			panel_PcbAdjust.Controls.Add(button_adjust_gotoalmostM2);
			panel_PcbAdjust.Controls.Add(button_pcbadjust_reset);
			panel_PcbAdjust.Controls.Add(panel_pcbadjust_M1);
			panel_PcbAdjust.Location = new System.Drawing.Point(109, 4);
			panel_PcbAdjust.Name = "panel_PcbAdjust";
			panel_PcbAdjust.Size = new System.Drawing.Size(557, 306);
			panel_PcbAdjust.TabIndex = 17;
			panel_PcbAdjust.Visible = false;
			panel_pcbadjust_ref2.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			panel_pcbadjust_ref2.Controls.Add(button1);
			panel_pcbadjust_ref2.Controls.Add(label14);
			panel_pcbadjust_ref2.Controls.Add(label15);
			panel_pcbadjust_ref2.Controls.Add(button2);
			panel_pcbadjust_ref2.Controls.Add(button8);
			panel_pcbadjust_ref2.Controls.Add(label16);
			panel_pcbadjust_ref2.Controls.Add(label17);
			panel_pcbadjust_ref2.Controls.Add(button9);
			panel_pcbadjust_ref2.Controls.Add(label18);
			panel_pcbadjust_ref2.Controls.Add(label19);
			panel_pcbadjust_ref2.Location = new System.Drawing.Point(3, 153);
			panel_pcbadjust_ref2.Name = "panel_pcbadjust_ref2";
			panel_pcbadjust_ref2.Size = new System.Drawing.Size(177, 146);
			panel_pcbadjust_ref2.TabIndex = 24;
			button1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button1.CnPressDownColor = System.Drawing.Color.White;
			button1.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button1.Location = new System.Drawing.Point(7, 117);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(63, 25);
			button1.TabIndex = 19;
			button1.Tag = "1";
			button1.Text = "从列表";
			button1.UseVisualStyleBackColor = true;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("楷体", 10.5f);
			label14.Location = new System.Drawing.Point(79, 85);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(21, 14);
			label14.TabIndex = 2;
			label14.Text = "=>";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("楷体", 10.5f);
			label15.Location = new System.Drawing.Point(13, 35);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(49, 14);
			label15.TabIndex = 2;
			label15.Text = "原坐标";
			button2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button2.CnPressDownColor = System.Drawing.Color.White;
			button2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button2.Location = new System.Drawing.Point(7, 91);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(62, 25);
			button2.TabIndex = 19;
			button2.Tag = "1";
			button2.Text = "从板图";
			button2.UseVisualStyleBackColor = true;
			button8.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button8.CnPressDownColor = System.Drawing.Color.White;
			button8.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button8.Location = new System.Drawing.Point(106, 89);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(63, 26);
			button8.TabIndex = 17;
			button8.Text = "保存M1";
			button8.UseVisualStyleBackColor = true;
			label16.BackColor = System.Drawing.Color.Snow;
			label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label16.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label16.Location = new System.Drawing.Point(8, 5);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(161, 27);
			label16.TabIndex = 20;
			label16.Tag = "0";
			label16.Text = "参考点1 R22";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label17.BackColor = System.Drawing.Color.Silver;
			label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label17.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label17.Location = new System.Drawing.Point(7, 51);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(63, 37);
			label17.TabIndex = 18;
			label17.Text = "X00000\r\nY00000";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button9.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button9.CnPressDownColor = System.Drawing.Color.White;
			button9.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button9.Location = new System.Drawing.Point(106, 116);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(63, 26);
			button9.TabIndex = 17;
			button9.Text = "定位M1";
			button9.UseVisualStyleBackColor = true;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("楷体", 10.5f);
			label18.Location = new System.Drawing.Point(106, 35);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(63, 14);
			label18.TabIndex = 2;
			label18.Text = "校正坐标";
			label19.BackColor = System.Drawing.Color.WhiteSmoke;
			label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label19.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label19.Location = new System.Drawing.Point(106, 50);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(63, 37);
			label19.TabIndex = 18;
			label19.Text = "X00000\r\nY00000";
			label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_pcbadjust_ref1.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
			panel_pcbadjust_ref1.Controls.Add(button5);
			panel_pcbadjust_ref1.Controls.Add(label8);
			panel_pcbadjust_ref1.Controls.Add(label9);
			panel_pcbadjust_ref1.Controls.Add(button_pcbadjust_ref0);
			panel_pcbadjust_ref1.Controls.Add(button7);
			panel_pcbadjust_ref1.Controls.Add(label13);
			panel_pcbadjust_ref1.Controls.Add(label10);
			panel_pcbadjust_ref1.Controls.Add(button6);
			panel_pcbadjust_ref1.Controls.Add(label11);
			panel_pcbadjust_ref1.Controls.Add(label12);
			panel_pcbadjust_ref1.Location = new System.Drawing.Point(360, 3);
			panel_pcbadjust_ref1.Name = "panel_pcbadjust_ref1";
			panel_pcbadjust_ref1.Size = new System.Drawing.Size(174, 146);
			panel_pcbadjust_ref1.TabIndex = 24;
			button5.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button5.CnPressDownColor = System.Drawing.Color.White;
			button5.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button5.Location = new System.Drawing.Point(5, 117);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(63, 25);
			button5.TabIndex = 19;
			button5.Tag = "1";
			button5.Text = "从列表";
			button5.UseVisualStyleBackColor = true;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("楷体", 10.5f);
			label8.Location = new System.Drawing.Point(77, 85);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(21, 14);
			label8.TabIndex = 2;
			label8.Text = "=>";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("楷体", 10.5f);
			label9.Location = new System.Drawing.Point(11, 35);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(49, 14);
			label9.TabIndex = 2;
			label9.Text = "原坐标";
			button_pcbadjust_ref0.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbadjust_ref0.CnPressDownColor = System.Drawing.Color.White;
			button_pcbadjust_ref0.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_pcbadjust_ref0.Location = new System.Drawing.Point(5, 91);
			button_pcbadjust_ref0.Name = "button_pcbadjust_ref0";
			button_pcbadjust_ref0.Size = new System.Drawing.Size(62, 25);
			button_pcbadjust_ref0.TabIndex = 19;
			button_pcbadjust_ref0.Tag = "1";
			button_pcbadjust_ref0.Text = "从板图";
			button_pcbadjust_ref0.UseVisualStyleBackColor = true;
			button7.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button7.CnPressDownColor = System.Drawing.Color.White;
			button7.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button7.Location = new System.Drawing.Point(104, 89);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(63, 26);
			button7.TabIndex = 17;
			button7.Text = "保存M1";
			button7.UseVisualStyleBackColor = true;
			label13.BackColor = System.Drawing.Color.Snow;
			label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label13.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label13.Location = new System.Drawing.Point(6, 5);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(161, 27);
			label13.TabIndex = 20;
			label13.Tag = "0";
			label13.Text = "参考点1 R22";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label10.BackColor = System.Drawing.Color.Silver;
			label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label10.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label10.Location = new System.Drawing.Point(5, 51);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(63, 37);
			label10.TabIndex = 18;
			label10.Text = "X00000\r\nY00000";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button6.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button6.CnPressDownColor = System.Drawing.Color.White;
			button6.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button6.Location = new System.Drawing.Point(104, 116);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(63, 26);
			button6.TabIndex = 17;
			button6.Text = "定位M1";
			button6.UseVisualStyleBackColor = true;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("楷体", 10.5f);
			label11.Location = new System.Drawing.Point(104, 35);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(63, 14);
			label11.TabIndex = 2;
			label11.Text = "校正坐标";
			label12.BackColor = System.Drawing.Color.WhiteSmoke;
			label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label12.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label12.Location = new System.Drawing.Point(104, 50);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(63, 37);
			label12.TabIndex = 18;
			label12.Text = "X00000\r\nY00000";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_pcbadjust_pricise.AutoSize = true;
			checkBox_pcbadjust_pricise.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_pcbadjust_pricise.Location = new System.Drawing.Point(230, 38);
			checkBox_pcbadjust_pricise.Name = "checkBox_pcbadjust_pricise";
			checkBox_pcbadjust_pricise.Size = new System.Drawing.Size(82, 18);
			checkBox_pcbadjust_pricise.TabIndex = 21;
			checkBox_pcbadjust_pricise.Text = "精准校正";
			checkBox_pcbadjust_pricise.UseVisualStyleBackColor = true;
			checkBox_pcbadjust_pricise.Visible = false;
			checkBox_pcbadjust_pricise.CheckedChanged += new System.EventHandler(checkBox_pcbadjust_pricise_CheckedChanged);
			panel_pcbadjust_M2.Controls.Add(button_adjust_autoM1);
			panel_pcbadjust_M2.Controls.Add(pictureBox_adjust1XY);
			panel_pcbadjust_M2.Controls.Add(button_adjust1XY_save);
			panel_pcbadjust_M2.Controls.Add(button_adjust1XY_moveto);
			panel_pcbadjust_M2.Controls.Add(label_adjust1XY);
			panel_pcbadjust_M2.Location = new System.Drawing.Point(355, 159);
			panel_pcbadjust_M2.Name = "panel_pcbadjust_M2";
			panel_pcbadjust_M2.Size = new System.Drawing.Size(182, 139);
			panel_pcbadjust_M2.TabIndex = 23;
			button_adjust_autoM1.BackColor = System.Drawing.SystemColors.Control;
			button_adjust_autoM1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_adjust_autoM1.CnPressDownColor = System.Drawing.Color.White;
			button_adjust_autoM1.Font = new System.Drawing.Font("黑体", 10f);
			button_adjust_autoM1.Location = new System.Drawing.Point(6, 3);
			button_adjust_autoM1.Name = "button_adjust_autoM1";
			button_adjust_autoM1.Size = new System.Drawing.Size(168, 26);
			button_adjust_autoM1.TabIndex = 19;
			button_adjust_autoM1.Tag = "1";
			button_adjust_autoM1.Text = "自动识别至Mark2";
			button_adjust_autoM1.UseVisualStyleBackColor = false;
			button_adjust_autoM1.Click += new System.EventHandler(button_adjust_autoM0_Click);
			pictureBox_adjust1XY.BackColor = System.Drawing.Color.Gray;
			pictureBox_adjust1XY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_adjust1XY.Location = new System.Drawing.Point(74, 33);
			pictureBox_adjust1XY.Name = "pictureBox_adjust1XY";
			pictureBox_adjust1XY.Size = new System.Drawing.Size(100, 100);
			pictureBox_adjust1XY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_adjust1XY.TabIndex = 9;
			pictureBox_adjust1XY.TabStop = false;
			pictureBox_adjust1XY.Tag = "1";
			button_adjust1XY_save.BackColor = System.Drawing.SystemColors.Control;
			button_adjust1XY_save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_adjust1XY_save.CnPressDownColor = System.Drawing.Color.White;
			button_adjust1XY_save.Font = new System.Drawing.Font("黑体", 10f);
			button_adjust1XY_save.Location = new System.Drawing.Point(7, 78);
			button_adjust1XY_save.Name = "button_adjust1XY_save";
			button_adjust1XY_save.Size = new System.Drawing.Size(63, 26);
			button_adjust1XY_save.TabIndex = 17;
			button_adjust1XY_save.Tag = "1";
			button_adjust1XY_save.Text = "保存M2";
			button_adjust1XY_save.UseVisualStyleBackColor = false;
			button_adjust1XY_save.Click += new System.EventHandler(button_adjust0XY_save_Click);
			button_adjust1XY_moveto.BackColor = System.Drawing.SystemColors.Control;
			button_adjust1XY_moveto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_adjust1XY_moveto.CnPressDownColor = System.Drawing.Color.White;
			button_adjust1XY_moveto.Font = new System.Drawing.Font("黑体", 10f);
			button_adjust1XY_moveto.Location = new System.Drawing.Point(7, 107);
			button_adjust1XY_moveto.Name = "button_adjust1XY_moveto";
			button_adjust1XY_moveto.Size = new System.Drawing.Size(63, 26);
			button_adjust1XY_moveto.TabIndex = 17;
			button_adjust1XY_moveto.Tag = "1";
			button_adjust1XY_moveto.Text = "定位M2";
			button_adjust1XY_moveto.UseVisualStyleBackColor = false;
			button_adjust1XY_moveto.Click += new System.EventHandler(button_adjust0XY_moveto_Click);
			label_adjust1XY.BackColor = System.Drawing.Color.WhiteSmoke;
			label_adjust1XY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_adjust1XY.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_adjust1XY.Location = new System.Drawing.Point(7, 34);
			label_adjust1XY.Name = "label_adjust1XY";
			label_adjust1XY.Size = new System.Drawing.Size(63, 37);
			label_adjust1XY.TabIndex = 18;
			label_adjust1XY.Tag = "1";
			label_adjust1XY.Text = "X00000\r\nY00000";
			label_adjust1XY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_PcbAdjust.BackColor = System.Drawing.Color.LightSalmon;
			button_PcbAdjust.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PcbAdjust.CnPressDownColor = System.Drawing.Color.White;
			button_PcbAdjust.Font = new System.Drawing.Font("黑体", 10f);
			button_PcbAdjust.Location = new System.Drawing.Point(223, 89);
			button_PcbAdjust.Name = "button_PcbAdjust";
			button_PcbAdjust.Size = new System.Drawing.Size(89, 45);
			button_PcbAdjust.TabIndex = 15;
			button_PcbAdjust.Text = "开始校正";
			button_PcbAdjust.UseVisualStyleBackColor = false;
			button_PcbAdjust.Click += new System.EventHandler(button_PcbAdjust_Click);
			button_adjust_gotoalmostM2.BackColor = System.Drawing.SystemColors.Control;
			button_adjust_gotoalmostM2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_adjust_gotoalmostM2.CnPressDownColor = System.Drawing.Color.White;
			button_adjust_gotoalmostM2.Font = new System.Drawing.Font("黑体", 10f);
			button_adjust_gotoalmostM2.Location = new System.Drawing.Point(223, 6);
			button_adjust_gotoalmostM2.Name = "button_adjust_gotoalmostM2";
			button_adjust_gotoalmostM2.Size = new System.Drawing.Size(89, 25);
			button_adjust_gotoalmostM2.TabIndex = 20;
			button_adjust_gotoalmostM2.Text = "=>Mark2";
			button_adjust_gotoalmostM2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			button_adjust_gotoalmostM2.UseVisualStyleBackColor = false;
			button_adjust_gotoalmostM2.Click += new System.EventHandler(button_adjust_gotoalmostM2_Click);
			button_pcbadjust_reset.BackColor = System.Drawing.SystemColors.Control;
			button_pcbadjust_reset.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbadjust_reset.CnPressDownColor = System.Drawing.Color.White;
			button_pcbadjust_reset.Font = new System.Drawing.Font("黑体", 10f);
			button_pcbadjust_reset.Location = new System.Drawing.Point(223, 58);
			button_pcbadjust_reset.Name = "button_pcbadjust_reset";
			button_pcbadjust_reset.Size = new System.Drawing.Size(89, 29);
			button_pcbadjust_reset.TabIndex = 20;
			button_pcbadjust_reset.Text = "重置";
			button_pcbadjust_reset.UseVisualStyleBackColor = false;
			button_pcbadjust_reset.Visible = false;
			button_pcbadjust_reset.Click += new System.EventHandler(button_pcbadjust_reset_Click);
			panel_pcbadjust_M1.Controls.Add(button_adjust_autoM0);
			panel_pcbadjust_M1.Controls.Add(pictureBox_adjust0XY);
			panel_pcbadjust_M1.Controls.Add(button_adjust0XY_save);
			panel_pcbadjust_M1.Controls.Add(button_adjust0XY_moveto);
			panel_pcbadjust_M1.Controls.Add(label_adjust0XY);
			panel_pcbadjust_M1.Location = new System.Drawing.Point(6, 3);
			panel_pcbadjust_M1.Name = "panel_pcbadjust_M1";
			panel_pcbadjust_M1.Size = new System.Drawing.Size(182, 146);
			panel_pcbadjust_M1.TabIndex = 22;
			button_adjust_autoM0.BackColor = System.Drawing.SystemColors.Control;
			button_adjust_autoM0.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_adjust_autoM0.CnPressDownColor = System.Drawing.Color.White;
			button_adjust_autoM0.Font = new System.Drawing.Font("黑体", 10f);
			button_adjust_autoM0.Location = new System.Drawing.Point(5, 3);
			button_adjust_autoM0.Name = "button_adjust_autoM0";
			button_adjust_autoM0.Size = new System.Drawing.Size(169, 26);
			button_adjust_autoM0.TabIndex = 19;
			button_adjust_autoM0.Tag = "0";
			button_adjust_autoM0.Text = "自动识别至Mark1";
			button_adjust_autoM0.UseVisualStyleBackColor = false;
			button_adjust_autoM0.Click += new System.EventHandler(button_adjust_autoM0_Click);
			pictureBox_adjust0XY.BackColor = System.Drawing.Color.Gray;
			pictureBox_adjust0XY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_adjust0XY.Location = new System.Drawing.Point(6, 33);
			pictureBox_adjust0XY.Name = "pictureBox_adjust0XY";
			pictureBox_adjust0XY.Size = new System.Drawing.Size(100, 100);
			pictureBox_adjust0XY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_adjust0XY.TabIndex = 9;
			pictureBox_adjust0XY.TabStop = false;
			pictureBox_adjust0XY.Tag = "0";
			button_adjust0XY_save.BackColor = System.Drawing.SystemColors.Control;
			button_adjust0XY_save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_adjust0XY_save.CnPressDownColor = System.Drawing.Color.White;
			button_adjust0XY_save.Font = new System.Drawing.Font("黑体", 10f);
			button_adjust0XY_save.Location = new System.Drawing.Point(111, 77);
			button_adjust0XY_save.Name = "button_adjust0XY_save";
			button_adjust0XY_save.Size = new System.Drawing.Size(63, 26);
			button_adjust0XY_save.TabIndex = 17;
			button_adjust0XY_save.Tag = "0";
			button_adjust0XY_save.Text = "保存M1";
			button_adjust0XY_save.UseVisualStyleBackColor = false;
			button_adjust0XY_save.Click += new System.EventHandler(button_adjust0XY_save_Click);
			button_adjust0XY_moveto.BackColor = System.Drawing.SystemColors.Control;
			button_adjust0XY_moveto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_adjust0XY_moveto.CnPressDownColor = System.Drawing.Color.White;
			button_adjust0XY_moveto.Font = new System.Drawing.Font("黑体", 10f);
			button_adjust0XY_moveto.Location = new System.Drawing.Point(111, 106);
			button_adjust0XY_moveto.Name = "button_adjust0XY_moveto";
			button_adjust0XY_moveto.Size = new System.Drawing.Size(63, 26);
			button_adjust0XY_moveto.TabIndex = 17;
			button_adjust0XY_moveto.Tag = "0";
			button_adjust0XY_moveto.Text = "定位M1";
			button_adjust0XY_moveto.UseVisualStyleBackColor = false;
			button_adjust0XY_moveto.Click += new System.EventHandler(button_adjust0XY_moveto_Click);
			label_adjust0XY.BackColor = System.Drawing.Color.WhiteSmoke;
			label_adjust0XY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_adjust0XY.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_adjust0XY.Location = new System.Drawing.Point(111, 32);
			label_adjust0XY.Name = "label_adjust0XY";
			label_adjust0XY.Size = new System.Drawing.Size(63, 37);
			label_adjust0XY.TabIndex = 18;
			label_adjust0XY.Tag = "0";
			label_adjust0XY.Text = "X00000\r\nY00000";
			label_adjust0XY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_PcbAdjust.AutoSize = true;
			checkBox_PcbAdjust.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_PcbAdjust.Location = new System.Drawing.Point(5, 4);
			checkBox_PcbAdjust.Name = "checkBox_PcbAdjust";
			checkBox_PcbAdjust.Size = new System.Drawing.Size(75, 18);
			checkBox_PcbAdjust.TabIndex = 14;
			checkBox_PcbAdjust.Text = "PCB校正";
			checkBox_PcbAdjust.UseVisualStyleBackColor = true;
			checkBox_PcbAdjust.CheckedChanged += new System.EventHandler(checkBox_PcbAdjust_CheckedChanged);
			label_priciseMark1_info.BackColor = System.Drawing.Color.Snow;
			label_priciseMark1_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_priciseMark1_info.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_priciseMark1_info.Location = new System.Drawing.Point(504, 204);
			label_priciseMark1_info.Name = "label_priciseMark1_info";
			label_priciseMark1_info.Size = new System.Drawing.Size(151, 48);
			label_priciseMark1_info.TabIndex = 20;
			label_priciseMark1_info.Tag = "1";
			label_priciseMark1_info.Text = "ON/OFF\r\n128/128/128/128\r\n840/840";
			label_priciseMark0_info.BackColor = System.Drawing.Color.Snow;
			label_priciseMark0_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_priciseMark0_info.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_priciseMark0_info.Location = new System.Drawing.Point(6, 204);
			label_priciseMark0_info.Name = "label_priciseMark0_info";
			label_priciseMark0_info.Size = new System.Drawing.Size(150, 48);
			label_priciseMark0_info.TabIndex = 20;
			label_priciseMark0_info.Tag = "0";
			label_priciseMark0_info.Text = "ON/OFF\r\n128/128/128/128\r\n840/840";
			checkBox_priciseMark1.AutoSize = true;
			checkBox_priciseMark1.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_priciseMark1.Location = new System.Drawing.Point(342, 134);
			checkBox_priciseMark1.Name = "checkBox_priciseMark1";
			checkBox_priciseMark1.Size = new System.Drawing.Size(145, 18);
			checkBox_priciseMark1.TabIndex = 17;
			checkBox_priciseMark1.Tag = "1";
			checkBox_priciseMark1.Text = "启用Mark2精准识别";
			checkBox_priciseMark1.UseVisualStyleBackColor = false;
			checkBox_priciseMark0.AutoSize = true;
			checkBox_priciseMark0.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_priciseMark0.Location = new System.Drawing.Point(162, 134);
			checkBox_priciseMark0.Name = "checkBox_priciseMark0";
			checkBox_priciseMark0.Size = new System.Drawing.Size(145, 18);
			checkBox_priciseMark0.TabIndex = 17;
			checkBox_priciseMark0.Tag = "0";
			checkBox_priciseMark0.Text = "启用Mark1精准识别";
			checkBox_priciseMark0.UseVisualStyleBackColor = false;
			button_mark1save.BackColor = System.Drawing.Color.LightSalmon;
			button_mark1save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mark1save.CnPressDownColor = System.Drawing.Color.White;
			button_mark1save.Font = new System.Drawing.Font("黑体", 10f);
			button_mark1save.Location = new System.Drawing.Point(579, 156);
			button_mark1save.Name = "button_mark1save";
			button_mark1save.Size = new System.Drawing.Size(72, 42);
			button_mark1save.TabIndex = 11;
			button_mark1save.Tag = "1";
			button_mark1save.Text = "保存\r\nMark2";
			button_mark1save.UseVisualStyleBackColor = false;
			button_mark1save.Click += new System.EventHandler(button_mark0save_Click);
			button_mark1moveto.BackColor = System.Drawing.SystemColors.ControlLight;
			button_mark1moveto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mark1moveto.CnPressDownColor = System.Drawing.Color.White;
			button_mark1moveto.Font = new System.Drawing.Font("黑体", 10f);
			button_mark1moveto.Location = new System.Drawing.Point(503, 156);
			button_mark1moveto.Name = "button_mark1moveto";
			button_mark1moveto.Size = new System.Drawing.Size(72, 42);
			button_mark1moveto.TabIndex = 10;
			button_mark1moveto.Tag = "1";
			button_mark1moveto.Text = "移动到\r\nMark2";
			button_mark1moveto.UseVisualStyleBackColor = false;
			button_mark1moveto.Click += new System.EventHandler(button_mark0moveto_Click);
			pictureBox_mark1.BackColor = System.Drawing.Color.Gray;
			pictureBox_mark1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_mark1.Location = new System.Drawing.Point(504, 3);
			pictureBox_mark1.Name = "pictureBox_mark1";
			pictureBox_mark1.Size = new System.Drawing.Size(150, 150);
			pictureBox_mark1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_mark1.TabIndex = 9;
			pictureBox_mark1.TabStop = false;
			pictureBox_mark0.BackColor = System.Drawing.Color.Gray;
			pictureBox_mark0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_mark0.Location = new System.Drawing.Point(6, 3);
			pictureBox_mark0.Name = "pictureBox_mark0";
			pictureBox_mark0.Size = new System.Drawing.Size(150, 150);
			pictureBox_mark0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_mark0.TabIndex = 9;
			pictureBox_mark0.TabStop = false;
			button_mark0save.BackColor = System.Drawing.Color.LightSalmon;
			button_mark0save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mark0save.CnPressDownColor = System.Drawing.Color.White;
			button_mark0save.Font = new System.Drawing.Font("黑体", 10f);
			button_mark0save.Location = new System.Drawing.Point(81, 156);
			button_mark0save.Name = "button_mark0save";
			button_mark0save.Size = new System.Drawing.Size(72, 42);
			button_mark0save.TabIndex = 4;
			button_mark0save.Tag = "0";
			button_mark0save.Text = "保存\r\nMark1";
			button_mark0save.UseVisualStyleBackColor = false;
			button_mark0save.Click += new System.EventHandler(button_mark0save_Click);
			button_mark0moveto.BackColor = System.Drawing.SystemColors.ControlLight;
			button_mark0moveto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_mark0moveto.CnPressDownColor = System.Drawing.Color.White;
			button_mark0moveto.Font = new System.Drawing.Font("黑体", 10f);
			button_mark0moveto.Location = new System.Drawing.Point(5, 156);
			button_mark0moveto.Name = "button_mark0moveto";
			button_mark0moveto.Size = new System.Drawing.Size(72, 42);
			button_mark0moveto.TabIndex = 4;
			button_mark0moveto.Tag = "0";
			button_mark0moveto.Text = "移动到\r\nMark1";
			button_mark0moveto.UseVisualStyleBackColor = false;
			button_mark0moveto.Click += new System.EventHandler(button_mark0moveto_Click);
			button_PCBE_Mark_OK.BackColor = System.Drawing.SystemColors.Control;
			button_PCBE_Mark_OK.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_Mark_OK.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_Mark_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_PCBE_Mark_OK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_PCBE_Mark_OK.Location = new System.Drawing.Point(662, 3);
			button_PCBE_Mark_OK.Name = "button_PCBE_Mark_OK";
			button_PCBE_Mark_OK.Size = new System.Drawing.Size(32, 32);
			button_PCBE_Mark_OK.TabIndex = 27;
			button_PCBE_Mark_OK.Text = "X";
			button_PCBE_Mark_OK.UseVisualStyleBackColor = false;
			button_PCBE_Mark_OK.Click += new System.EventHandler(button_PCBE_Mark_OK_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(108, 148, 185);
			base.Controls.Add(button_PCBE_Mark_OK);
			base.Controls.Add(label_title_mark);
			base.Controls.Add(panel_setmark);
			base.Controls.Add(label2);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_pcbedit_mark";
			base.Size = new System.Drawing.Size(711, 825);
			base.Load += new System.EventHandler(UserControl_pcbedit_mark_Load);
			panel_setmark.ResumeLayout(false);
			panel_setmark.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkRecognizeRate1).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkPicSize1).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkRecognizeRate).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkPicSize).EndInit();
			panel10.ResumeLayout(false);
			panel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			panel_pricise_mark1.ResumeLayout(false);
			panel_pricise_mark0.ResumeLayout(false);
			panel38.ResumeLayout(false);
			panel38.PerformLayout();
			panel_pcbadjust_debug.ResumeLayout(false);
			panel_pcbadjust_debug.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pcbadjust_debug_y_offset).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pcbadjust_debug_x_offset).EndInit();
			panel_PcbAdjust.ResumeLayout(false);
			panel_PcbAdjust.PerformLayout();
			panel_pcbadjust_ref2.ResumeLayout(false);
			panel_pcbadjust_ref2.PerformLayout();
			panel_pcbadjust_ref1.ResumeLayout(false);
			panel_pcbadjust_ref1.PerformLayout();
			panel_pcbadjust_M2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox_adjust1XY).EndInit();
			panel_pcbadjust_M1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox_adjust0XY).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_mark1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_mark0).EndInit();
			ResumeLayout(false);
		}

		public UserControl_pcbedit_mark(int fn, USR_DATA usr, USR3_DATA usr3)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR3 = usr3;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			pic_mark = new PictureBox[2] { pictureBox_mark0, pictureBox_mark1 };
			label_Mark_coord = new Label[2] { label_Mark0, label_Mark1 };
			panel_pricise_mark = new Panel[2] { panel_pricise_mark0, panel_pricise_mark1 };
			num_MarkPicSize = new NumericUpDown[2] { numericUpDown_MarkPicSize, numericUpDown_MarkPicSize1 };
			num_MarkRecognizeRate = new NumericUpDown[2] { numericUpDown_MarkRecognizeRate, numericUpDown_MarkRecognizeRate1 };
			label_priciseMark_info = new Label[2] { label_priciseMark0_info, label_priciseMark1_info };
			checkBox_priciseMark = new CheckBox[2] { checkBox_priciseMark0, checkBox_priciseMark1 };
			label_Search_coord = new Label[2] { label1, label3 };
			checkBox_search_coord = new CheckBox[2] { checkBox_search_mark0, checkBox2 };
			button_search_save_xy = new CnButton[2] { button_sdd1, button4 };
			button_search_goto_xy = new CnButton[2] { button_sdd32, button3 };
			pic_adjust = new PictureBox[2] { pictureBox_adjust0XY, pictureBox_adjust1XY };
			label_adjust_coord = new Label[2] { label_adjust0XY, label_adjust1XY };
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_title_mark,
				str = new string[3] { "Mark点设置", "Mark點設置", "Mark Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_PcbAdjust,
				str = new string[3] { "PCB校正", "PCB校正", "PCB Correct" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_mark0moveto,
				str = new string[3]
				{
					"移动到" + Environment.NewLine + "Mark1",
					"移動到" + Environment.NewLine + "Mark1",
					"Goto" + Environment.NewLine + "Mark1"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_mark0save,
				str = new string[3]
				{
					"保存" + Environment.NewLine + "Mark1",
					"保存" + Environment.NewLine + "Mark1",
					"Save" + Environment.NewLine + "Mark1"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_priciseMark0,
				str = new string[3] { "启用Mark1精准识别", "啟用Mark1精準識別", "Enable Mark1 Pricise Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_priciseMark0,
				str = new string[3]
				{
					"开始定制" + Environment.NewLine + "Mark1",
					"開始定制" + Environment.NewLine + "Mark1",
					"Start Create" + Environment.NewLine + "Mark1"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "识别大小", "識別大小", "Scan-Size" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "点识别率", "點識別率", "Recog-Rate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_search_mark0,
				str = new string[3] { "Mark1自定义搜索点", "Mark1自定義搜索點", "Mark1 Customize Search Point" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_sdd1,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_sdd32,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_adjust_autoM0,
				str = new string[3] { "自动识别至Mark1", "自動識別至Mark1", "Auto Check and Goto Mark1" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_adjust0XY_save,
				str = new string[3] { "保存M1", "保存M1", "Save M1" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_adjust0XY_moveto,
				str = new string[3] { "定位M1", "定位M1", "Goto M1" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PcbAdjust,
				str = new string[3] { "开始校正", "開始校正", "Start PCB Correct" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_mark1moveto,
				str = new string[3]
				{
					"移动到" + Environment.NewLine + "Mark2",
					"移動到" + Environment.NewLine + "Mark2",
					"Goto" + Environment.NewLine + "Mark2"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_mark1save,
				str = new string[3]
				{
					"保存" + Environment.NewLine + "Mark2",
					"保存" + Environment.NewLine + "Mark2",
					"Save" + Environment.NewLine + "Mark2"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_priciseMark1,
				str = new string[3] { "启用Mark2精准识别", "啟用Mark2精準識別", "Enable Mark2 Pricise Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_priciseMark1,
				str = new string[3]
				{
					"开始定制" + Environment.NewLine + "Mark2",
					"開始定制" + Environment.NewLine + "Mark2",
					"Start Create" + Environment.NewLine + "Mark2"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "识别大小", "識別大小", "Scan-Size" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "点识别率", "點識別率", "Recog-Rate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox2,
				str = new string[3] { "Mark2自定义搜索点", "Mark2自定義搜索點", "Mark2 Customize Search Point" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button4,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button3,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_adjust_autoM1,
				str = new string[3] { "自动识别至Mark2", "自動識別至Mark2", "Auto Check and Goto Mark2" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_adjust1XY_save,
				str = new string[3] { "保存M2", "保存M2", "Save M2" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_adjust1XY_moveto,
				str = new string[3] { "定位M2", "定位M2", "Goto M2" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MarkTest,
				str = new string[3] { "MARK测试", "MARK测试", "Mark Test" }
			});
			return list;
		}

		private void UserControl_pcbedit_mark_Load(object sender, EventArgs e)
		{
			if (USR3.mMarkPara == null)
			{
				USR3.mMarkPara = new MARK_PARA[2];
				for (int i = 0; i < 2; i++)
				{
					USR3.mMarkPara[i] = new MARK_PARA();
				}
			}
			if (USR3.mIsMarkSearch == null)
			{
				bool[] array = (USR3.mIsMarkSearch = new bool[2]);
			}
			if (USR3.mAdjustMark == null)
			{
				USR3.mAdjustMark = new Coordinate[2]
				{
					new Coordinate(0L, 0L),
					new Coordinate(0L, 0L)
				};
			}
			if (USR3.mAdjustPic == null)
			{
				USR3.mAdjustPic = new Bitmap[2];
			}
			mFormMarkGen = null;
			for (int j = 0; j < 2; j++)
			{
				MainForm0.common_addCSLforPicture(pic_mark[j], Color.Yellow);
				label_Mark_coord[j].Tag = j;
				label_Mark_coord[j].DoubleClick += label_mark_xy_DoubleClick;
				label_Mark_coord[j].Text = MainForm0.format_XY_label_string(USR3.mMark[j]);
				label_priciseMark_info[j].Tag = j;
				label_priciseMark_info[j].DoubleClick += label_priciseMark0_info_DoubleClick;
				if (USR3.mMarkPara[j].lightlevel == null)
				{
					USR3.mMarkPara[j].lightlevel = new int[6] { 840, 840, 840, 840, 840, 840 };
				}
				num_MarkPicSize[j].Value = USR3.mMarkPara[j].picsize;
				num_MarkRecognizeRate[j].Value = USR3.mMarkPara[j].recognizeRate;
				checkBox_priciseMark[j].Checked = USR3.mMarkPara[j].mode == MarkModeType.Pricise;
				panel_pricise_mark[j].Visible = checkBox_priciseMark[j].Checked;
				label_Search_coord[j].Text = MainForm0.format_XY_label_string(USR3.mMarkSearch[j]);
				label_Search_coord[j].DoubleClick += label_search_xy_DoubleClick;
				checkBox_search_coord[j].Checked = USR3.mIsMarkSearch[j];
				update_mark_pricise_info(j);
				update_MarkPic(j);
			}
			for (int k = 0; k < 2; k++)
			{
				checkBox_priciseMark[k].CheckedChanged += checkBox_priciseMark0_CheckedChanged;
				num_MarkPicSize[k].ValueChanged += numericUpDown_MarkPicSize_ValueChanged;
				num_MarkRecognizeRate[k].ValueChanged += numericUpDown_MarkRecognizeRate_ValueChanged;
			}
			checkBox_pcbadjust_pricise.Checked = USR3.mIsPcbAdjust_Pricise;
			if (!USR3.mIsPcbAdjust_Pricise)
			{
				Panel panel = panel_pcbadjust_ref1;
				bool visible = (panel_pcbadjust_ref2.Visible = false);
				panel.Visible = visible;
				panel_pcbadjust_M2.Location = new Point(355, 3);
			}
			else
			{
				panel_pcbadjust_ref1.Location = new Point(355, 3);
				panel_pcbadjust_M2.Location = new Point(355, 159);
				Panel panel2 = panel_pcbadjust_ref1;
				bool visible2 = (panel_pcbadjust_ref2.Visible = true);
				panel2.Visible = visible2;
			}
			for (int l = 0; l < 2; l++)
			{
				label_adjust_coord[l].DoubleClick += label_pcbadjust_xy_DoubleClick;
				label_adjust_coord[l].Text = MainForm0.format_XY_label_string(USR3.mAdjustMark[l]);
				pic_adjust[l].Image = ((USR3.mAdjustPic[l] == null) ? null : new Bitmap(USR3.mAdjustPic[l]));
				if (USR3.mAdjustPic[l] == null)
				{
					pic_adjust[l].Image = null;
					continue;
				}
				Bitmap bitmap = new Bitmap(USR3.mAdjustPic[l]);
				bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
				pic_adjust[l].Image = bitmap;
			}
			panel_pcbadjust_debug.Visible = MainForm0.mIsSimulation;
		}

		public void flush_data()
		{
			for (int i = 0; i < 2; i++)
			{
				label_Mark_coord[i].Text = MainForm0.format_XY_label_string(USR3.mMark[i]);
				label_Search_coord[i].Text = MainForm0.format_XY_label_string(USR3.mMarkSearch[i]);
				update_mark_pricise_info(i);
				update_MarkPic(i);
			}
		}

		private void button_PCBE_Mark_OK_Click(object sender, EventArgs e)
		{
			MainForm0.mIsOpen_PcbMarkPage = false;
			Dispose();
		}

		private void label_search_xy_DoubleClick(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			string text = (string)label.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			Form_FillXY form_FillXY = new Form_FillXY(USR3.mMarkSearch[num], USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				USR3.mMarkSearch[num].X = fillXY.X;
				USR3.mMarkSearch[num].Y = fillXY.Y;
				label_Search_coord[num].Text = MainForm0.format_XY_label_string(USR3.mMarkSearch[num]);
				MainForm0.save_usrProjectData();
			}
		}

		private void label_mark_xy_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			for (int i = 0; i < 2; i++)
			{
				label_Mark_coord[i].BackColor = ((i == num) ? Color.White : Color.Gray);
			}
			Form_FillXY form_FillXY = new Form_FillXY(USR3.mMark[num], USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				USR3.mMark[num].X = fillXY.X;
				USR3.mMark[num].Y = fillXY.Y;
				label_Mark_coord[num].Text = MainForm0.format_XY_label_string(USR3.mMark[num]);
				MainForm0.save_usrProjectData();
			}
		}

		private void label_pcbadjust_xy_DoubleClick(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			string text = (string)label.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			Form_FillXY form_FillXY = new Form_FillXY(USR3.mAdjustMark[num], USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				USR3.mAdjustMark[num].X = fillXY.X;
				USR3.mAdjustMark[num].Y = fillXY.Y;
				label_adjust_coord[num].Text = MainForm0.format_XY_label_string(USR3.mAdjustMark[num]);
				MainForm0.save_usrProjectData();
			}
		}

		private void update_mark_pricise_info(int markno)
		{
			if (!USR3.mMarkPara[markno].mPara.mLightOn && !USR3.mMarkPara[markno].mPara.mLedOn && USR3.mMarkPara[markno].mPara.mParaCam[0] == 0 && USR3.mMarkPara[markno].mPara.mParaCam[1] == 0 && USR3.mMarkPara[markno].mPara.mParaCam[2] == 0 && USR3.mMarkPara[markno].mPara.mParaCam[3] == 0 && USR3.mMarkPara[markno].mPara.mParaLed[0] == 0 && USR3.mMarkPara[markno].mPara.mParaLed[1] == 0)
			{
				USR3.mMarkPara[markno].mPara.mLightOn = true;
				USR3.mMarkPara[markno].mPara.mLedOn = true;
				USR3.mMarkPara[markno].mPara.mParaLed[0] = 840;
				USR3.mMarkPara[markno].mPara.mParaLed[1] = 840;
				USR3.mMarkPara[markno].mPara.mParaCam[0] = 20;
				USR3.mMarkPara[markno].mPara.mParaCam[1] = 200;
				USR3.mMarkPara[markno].mPara.mParaCam[2] = 127;
				USR3.mMarkPara[markno].mPara.mParaCam[3] = 127;
			}
			label_priciseMark_info[markno].Text = (USR3.mMarkPara[markno].mPara.mLightOn ? "ON" : "OFF") + "/" + (USR3.mMarkPara[markno].mPara.mLedOn ? "ON" : "OFF") + "    ";
			label_priciseMark_info[markno].Text += Environment.NewLine;
			for (int i = 0; i < 4; i++)
			{
				Label obj = label_priciseMark_info[markno];
				obj.Text = obj.Text + USR3.mMarkPara[markno].mPara.mParaCam[i] + " ";
			}
			label_priciseMark_info[markno].Text += Environment.NewLine;
			for (int j = 0; j < HW.mMarkLedNum; j++)
			{
				Label obj2 = label_priciseMark_info[markno];
				obj2.Text = obj2.Text + USR3.mMarkPara[markno].mPara.mParaLed[j] + " ";
			}
		}

		private void update_MarkPic(int markno)
		{
			if (USR3.mMarkPara[markno].mPicMark == null && USR3.mMarkPic[markno] != null)
			{
				USR3.mMarkPara[markno].mPicMark = new Bitmap(USR3.mMarkPic[markno]);
			}
			if (USR3.mMarkPic[markno] != null)
			{
				Bitmap original = USR3.mMarkPic[markno];
				Bitmap b = new Bitmap(original);
				Graphics graphics = Graphics.FromImage(b);
				graphics.DrawRectangle(new Pen(Color.Yellow, 1f), new Rectangle(new Point((150 - USR3.mMarkPara[markno].picsize) / 2, (150 - USR3.mMarkPara[markno].picsize) / 2), new Size(USR3.mMarkPara[markno].picsize, USR3.mMarkPara[markno].picsize)));
				graphics.Dispose();
				Invoke((MethodInvoker)delegate
				{
					Bitmap bitmap = new Bitmap(b);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					pic_mark[markno].Image = bitmap;
				});
			}
			else
			{
				Invoke((MethodInvoker)delegate
				{
					pic_mark[markno].Image = null;
				});
			}
		}

		private void label_priciseMark0_info_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			if (MainForm0.mForm_MarkCamPara != null && !MainForm0.mForm_MarkCamPara.IsDisposed)
			{
				MainForm0.mForm_MarkCamPara.Close();
				MainForm0.mForm_MarkCamPara = null;
			}
			if (mForm_MarkCamParaUSR3 != null && !mForm_MarkCamParaUSR3.IsDisposed)
			{
				mForm_MarkCamParaUSR3.Close();
				mForm_MarkCamParaUSR3 = null;
			}
			if (mForm_MarkCamParaUSR3 == null || mForm_MarkCamParaUSR3.IsDisposed)
			{
				mForm_MarkCamParaUSR3 = new Form_MarkCamParaUSR3(mFn, USR, USR3, num);
				mForm_MarkCamParaUSR3.update_mark_pricise_info += update_mark_pricise_info;
				mForm_MarkCamParaUSR3.Location = new Point(570 + num * 300, 630);
				mForm_MarkCamParaUSR3.TopMost = true;
				mForm_MarkCamParaUSR3.Show();
			}
		}

		private void checkBox_priciseMark0_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			string text = (string)checkBox.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			if (checkBox.Checked && MainForm0.CmMessageBox("精准算法要求Mark点为空旷的标准圆点，是否继续?", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				checkBox.Checked = false;
				return;
			}
			panel_pricise_mark[num].Visible = checkBox.Checked;
			USR3.mMarkPara[num].mode = (checkBox_priciseMark0.Checked ? MarkModeType.Pricise : MarkModeType.Legacy);
		}

		private void checkBox_search_mark0_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			string text = (string)checkBox.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			Label obj = label_Search_coord[num];
			CnButton obj2 = button_search_goto_xy[num];
			bool flag = (button_search_save_xy[num].Enabled = checkBox.Checked);
			bool enabled = (obj2.Enabled = flag);
			obj.Enabled = enabled;
			USR3.mIsMarkSearch[num] = checkBox.Checked;
		}

		private void button_save_search_xy_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string text = (string)button.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			USR3.mMarkSearch[num].X = MainForm0.mCur[MainForm0.mFn].x;
			USR3.mMarkSearch[num].Y = MainForm0.mCur[MainForm0.mFn].y;
			label_Search_coord[num].Text = MainForm0.format_XY_label_string(USR3.mMarkSearch[num]);
			MainForm0.save_usrProjectData();
		}

		private void button_goto_search_xy_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string text = (string)button.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.vsplus_pcbedit_gotoxy(USR3.mMarkSearch[num]);
			}
		}

		private void button_mark0save_Click(object sender, EventArgs e)
		{
			bool flag = true;
			if (this.GetEdit_XY != null)
			{
				flag = this.GetEdit_XY();
			}
			if (!flag)
			{
				string[] array = new string[3]
				{
					"不可以修改MARK点!" + Environment.NewLine + "如要修改MARK点，请进行PCB校正!",
					"不可以修改MARK點!" + Environment.NewLine + "如要修改MARK點，請進行PCB校正!",
					"Cannot modify Mark Point!" + Environment.NewLine + "Please PCB correct firstly or PCB inboard check!"
				};
				MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
				return;
			}
			Button button = (Button)sender;
			string text = (string)button.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			MainForm0.write_to_logFile_hand("HAND: button_marksave_Click" + Environment.NewLine);
			string text2 = "Save MARK" + (num + 1) + "XY?";
			string text3 = "是否确定保存MARK" + (num + 1);
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text2 : text3, MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			if (MainForm0.mIsSimulation)
			{
				USR3.mMark[num].X = 22000 + num * 20000;
				USR3.mMark[num].Y = 31000 + num * 20000;
			}
			else
			{
				double num2 = MainForm0.format_distance(USR3.mMark[1 - num], new Coordinate(MainForm0.mCur[MainForm0.mFn].x, MainForm0.mCur[MainForm0.mFn].y));
				if (num2 < 1000.0 && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Two marks are too near, continue?" : "两个MARK点距离太近，是否继续保存？", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
				USR3.mMark[num].X = MainForm0.mCur[MainForm0.mFn].x;
				USR3.mMark[num].Y = MainForm0.mCur[MainForm0.mFn].y;
			}
			label_Mark_coord[num].Text = MainForm0.format_XY_label_string(USR3.mMark[num]);
			MainForm0.save_usrProjectData();
			Thread thread = new Thread(thread_mark_capture);
			thread.IsBackground = true;
			thread.Start(num);
			if (USR3.mMarkSearch == null)
			{
				USR3.mMarkSearch = new Coordinate[2];
			}
			USR3.mMarkSearch[num] = new Coordinate(USR3.mMark[num].X, USR3.mMark[num].Y);
			label_Search_coord[num].Text = MainForm0.format_XY_label_string(USR3.mMarkSearch[num]);
		}

		private void thread_mark_capture(object markno)
		{
			int num = HW.mMarkCamItem[mFn].index[0];
			MainForm0.startMarkStill_andWait(mFn);
			int num2 = (int)(150f * (float)MainForm0.mJvs_rawHeight / (float)MainForm0.mJvs_usrHeight);
			Rectangle destRect = new Rectangle(0, 0, 150, 150);
			Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - 150) / 2, (MainForm0.mJvs_rawHeight - num2) / 2, 150, num2);
			Bitmap bitmap = new Bitmap(150, 150);
			if (!MainForm0.mIsSimulation)
			{
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.DrawImage(MainForm0.mJVSBitmap[num], destRect, srcRect, GraphicsUnit.Pixel);
				graphics.Dispose();
			}
			else
			{
				bitmap = new Bitmap(MainForm0.SIGN_PICTURE[(int)markno]);
			}
			Bitmap b = new Bitmap(bitmap);
			Graphics graphics2 = Graphics.FromImage(b);
			int picsize = USR3.mMarkPara[(int)markno].picsize;
			graphics2.DrawRectangle(new Pen(Color.Yellow, 1f), new Rectangle(new Point((150 - picsize) / 2, (150 - picsize) / 2), new Size(picsize, picsize)));
			graphics2.Dispose();
			USR3.mMarkPic[(int)markno] = bitmap;
			USR3.mMarkPara[(int)markno].mPicMark = new Bitmap(bitmap);
			Invoke((MethodInvoker)delegate
			{
				Bitmap bitmap2 = new Bitmap(b);
				bitmap2.RotateFlip(RotateFlipType.Rotate180FlipX);
				pic_mark[(int)markno].Image = bitmap2;
			});
			USR3.mMarkPara[(int)markno].mPara.mLedOn = USR.mIsMarkLedOn;
			USR3.mMarkPara[(int)markno].mPara.mLightOn = USR.mIsMarkLightOn;
			for (int i = 0; i < HW.mMarkLedNum; i++)
			{
				USR3.mMarkPara[(int)markno].mPara.mParaLed[i] = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[i];
			}
			for (int j = 0; j < 4; j++)
			{
				USR3.mMarkPara[(int)markno].mPara.mParaCam[j] = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[j];
			}
			Invoke((MethodInvoker)delegate
			{
				label_Mark_coord[(int)markno].Text = MainForm0.format_XY_label_string(USR3.mMark[(int)markno]);
				update_mark_pricise_info((int)markno);
			});
			MainForm0.save_usrProjectData();
		}

		private void button_mark0moveto_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string text = (string)button.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.vsplus_pcbedit_gotoxy(USR3.mMark[num]);
			}
		}

		private void numericUpDown_MarkPicSize_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			string text = (string)numericUpDown.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			USR3.mMarkPara[num].picsize = (USR3.mMarkPicSize = (int)numericUpDown.Value);
			update_MarkPic(num);
			MainForm0.save_usrProjectData();
		}

		private void numericUpDown_MarkRecognizeRate_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			string text = (string)numericUpDown.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			USR3.mMarkPara[num].recognizeRate = (int)numericUpDown.Value;
			MainForm0.save_usrProjectData();
		}

		private void button_priciseMark0_Click(object sender, EventArgs e)
		{
			if (mThd_PriciseMarkGen == null || !mThd_PriciseMarkGen.IsAlive)
			{
				Button button = (Button)sender;
				string text = (string)button.Tag;
				int num = ((!(text == "0")) ? 1 : 0);
				mThd_PriciseMarkGen = new Thread(thd_priciseMarkGen);
				mThd_PriciseMarkGen.IsBackground = true;
				mThd_PriciseMarkGen.Start(num);
			}
		}

		private void button_priciseMarkCheck0_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string text = (string)button.Tag;
			int markno = ((!(text == "0")) ? 1 : 0);
			process_priciseMarkGen(1, markno);
		}

		private void thd_priciseMarkGen(object o)
		{
			int mode = (int)o / 10;
			int markno = (int)o % 10;
			process_priciseMarkGen(mode, markno);
		}

		private void process_priciseMarkGen(int mode, int markno)
		{
			int cur_threshold = ((mode != 0) ? USR3.mMarkPara[markno].threshold : 0);
			BindingList<BindingList<CvPoint>> ctllist = begin_MarkGen(mode, markno, cur_threshold);
			Invoke((MethodInvoker)delegate
			{
				mFormMarkGen = new Form_MarkGen(USR, USR3, Pic_MarkGen_Orgin, Pic_MarkGen_Ct, ctllist, markno);
				mFormMarkGen.ImageVisual_MarkGen += ImageVisual_MarkGen;
				mFormMarkGen.ImageVisual_MarkMatch += ImageVisual_MarkMatch;
				mFormMarkGen.TopMost = true;
				if (mFormMarkGen.ShowDialog() == DialogResult.OK)
				{
					if (mode == 0)
					{
						USR3.mMarkPara[markno].mPara.mLightOn = saved_lighton;
						USR3.mMarkPara[markno].mPara.mLedOn = saved_ledon;
						if (USR3.mMarkPara[markno].mPara == null)
						{
							USR3.mMarkPara[markno].mPara = new MarkCamPara();
						}
						for (int i = 0; i < HW.mMarkLedNum; i++)
						{
							USR3.mMarkPara[markno].mPara.mParaLed[i] = saved_markpara.mParaLed[i];
						}
						for (int j = 0; j < 4; j++)
						{
							USR3.mMarkPara[markno].mPara.mParaCam[j] = saved_markpara.mParaCam[j];
						}
						USR3.mMark[markno].X = MainForm0.mCur[MainForm0.mFn].x;
						USR3.mMark[markno].Y = MainForm0.mCur[MainForm0.mFn].y;
						label_Mark_coord[markno].Text = MainForm0.format_XY_label_string(USR3.mMark[markno]);
						update_mark_pricise_info(markno);
					}
					if (USR3.mMarkPara[markno].mPicMark == null)
					{
						USR3.mMarkPara[markno].mPicMark = new Bitmap(150, 150);
					}
					USR3.mMarkPic[markno] = new Bitmap(USR3.mMarkPara[markno].mPicMark);
					update_MarkPic(markno);
				}
			});
		}

		public BindingList<BindingList<CvPoint>> ImageVisual_MarkGen(Bitmap newbitmap_des, ref int cur_threshold, int minpno, int maxpno)
		{
			int len = 0;
			BitmapData bitmapData = newbitmap_des.LockBits(new Rectangle(0, 0, newbitmap_des.Width, newbitmap_des.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			int num = MainForm0.moon_Visual_MarkGen(bitmapData.Scan0, 32, new Size(newbitmap_des.Width, newbitmap_des.Height), ref cur_threshold, minpno, maxpno, ref len);
			newbitmap_des.UnlockBits(bitmapData);
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = 0;
			}
			int[] array2 = new int[len * 2];
			for (int j = 0; j < len * 2; j++)
			{
				array2[j] = 0;
			}
			int num2 = MainForm0.moon_Visual_MarkGen_GetData(array, array2);
			BindingList<BindingList<CvPoint>> bindingList = new BindingList<BindingList<CvPoint>>();
			int num3 = 0;
			for (int k = 0; k < num2; k++)
			{
				BindingList<CvPoint> bindingList2 = new BindingList<CvPoint>();
				for (int l = 0; l < array[k]; l++)
				{
					bindingList2.Add(new CvPoint(array2[num3], array2[num3 + 1]));
					num3 += 2;
				}
				bindingList.Add(bindingList2);
			}
			return bindingList;
		}

		public BindingList<BindingList<CvPoint>> begin_MarkGen(int mode, int markno, int cur_threshold)
		{
			Bitmap bitmap2;
			if (mode == 0)
			{
				_ = HW.mMarkCamItem[mFn].index[0];
				MainForm0.startMarkStill_andWait(mFn);
				Rectangle destRect = new Rectangle(0, 0, MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
				Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - MainForm0.mJvs_usrWidth) / 2, 0, MainForm0.mJvs_usrWidth, MainForm0.mJvs_rawHeight);
				Bitmap bitmap = new Bitmap(MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.DrawImage(MainForm0.mJVSBitmap[HW.mMarkCamItem[mFn].index[0]], destRect, srcRect, GraphicsUnit.Pixel);
				graphics.Dispose();
				Pic_MarkGen_Orgin = new Bitmap(bitmap);
				saved_lighton = USR.mIsMarkLightOn;
				saved_ledon = USR.mIsMarkLedOn;
				if (saved_markpara == null)
				{
					saved_markpara = new MarkCamPara();
				}
				for (int i = 0; i < HW.mMarkLedNum; i++)
				{
					saved_markpara.mParaLed[i] = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[i];
				}
				for (int j = 0; j < 4; j++)
				{
					saved_markpara.mParaCam[j] = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[j];
				}
				bitmap2 = new Bitmap(Pic_MarkGen_Orgin);
			}
			else
			{
				if (USR3.mMarkPara[markno].mPic == null)
				{
					USR3.mMarkPara[markno].mPic = new Bitmap(550, 550);
				}
				Pic_MarkGen_Orgin = new Bitmap(USR3.mMarkPara[markno].mPic);
				bitmap2 = new Bitmap(USR3.mMarkPara[markno].mPic);
			}
			BindingList<BindingList<CvPoint>> result = ImageVisual_MarkGen(bitmap2, ref cur_threshold, 10, 500);
			USR3.mMarkPara[markno].threshold = cur_threshold;
			Pic_MarkGen_Ct = new Bitmap(bitmap2);
			return result;
		}

		public int ImageVisual_MarkMatch(Bitmap newbitmap_des, BindingList<CvPoint> cvlist, int cur_threshold, double[] cirs, int max_cirs)
		{
			int count = cvlist.Count;
			if (count <= 0)
			{
				MainForm0.write_to_logFile("未定制精准MARK，请定制之后再使用精准MARK识别");
				return -1;
			}
			int[] array = new int[count * 2];
			for (int i = 0; i < count; i++)
			{
				array[i * 2] = cvlist[i].X;
				array[i * 2 + 1] = cvlist[i].Y;
			}
			BitmapData bitmapData = newbitmap_des.LockBits(new Rectangle(0, 0, newbitmap_des.Width, newbitmap_des.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			int result = MainForm0.moon_Visual_MarkGen_Match(bitmapData.Scan0, array, count, 32, new Size(newbitmap_des.Width, newbitmap_des.Height), cur_threshold, cirs, max_cirs);
			newbitmap_des.UnlockBits(bitmapData);
			return result;
		}

		public double ImageVisual_MarkLegacy(Bitmap newbitmap_des, Bitmap reference_map, int picsize, double[] cirs)
		{
			PointF leftpoint = default(PointF);
			PointF ptf = default(PointF);
			BitmapData bitmapData = reference_map.LockBits(new Rectangle(new Point((150 - picsize) / 2, (150 - picsize) / 2), new Size(picsize, picsize)), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			BitmapData bitmapData2 = newbitmap_des.LockBits(new Rectangle(0, 0, newbitmap_des.Width, newbitmap_des.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			double result = MainForm0.moon_FindMark(bitmapData.Scan0, new Size(picsize, picsize), bitmapData2.Scan0, new Size(newbitmap_des.Width, newbitmap_des.Height), ref leftpoint, ref ptf, 32);
			cirs[0] = (double)leftpoint.X + (double)picsize / 2.0 - (double)(newbitmap_des.Width / 2);
			cirs[1] = (double)leftpoint.Y + (double)picsize / 2.0 - (double)(newbitmap_des.Height / 2);
			reference_map.UnlockBits(bitmapData);
			newbitmap_des.UnlockBits(bitmapData2);
			return result;
		}

		public int ImageVisual_stillAnd_MarkMatch(int markno, double[] offsetxy)
		{
			int num = 0;
			_ = HW.mMarkCamItem[mFn].index[0];
			MainForm0.startMarkStill_andWait(mFn);
			Bitmap bitmap = new Bitmap(MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
			Rectangle destRect = new Rectangle(0, 0, MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
			Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - MainForm0.mJvs_usrWidth) / 2, 0, MainForm0.mJvs_usrWidth, MainForm0.mJvs_rawHeight);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(MainForm0.mJVSBitmap[HW.mMarkCamItem[mFn].index[0]], destRect, srcRect, GraphicsUnit.Pixel);
			graphics.Dispose();
			int num2 = 10;
			double[] array = new double[num2 * 3];
			int num3 = 0;
			double num4 = -1.0;
			if (USR3.mMarkPara[markno].mode == MarkModeType.Pricise)
			{
				num3 = ImageVisual_MarkMatch(bitmap, USR3.mMarkPara[markno].cvlist, USR3.mMarkPara[markno].threshold, array, num2);
			}
			switch (num3)
			{
			case 1:
				offsetxy[0] = array[0] - USR3.mMarkPara[markno].x_offs;
				offsetxy[1] = array[1] - USR3.mMarkPara[markno].y_offs;
				num = 1;
				break;
			case -1:
				return -1;
			default:
				num4 = ImageVisual_MarkLegacy(bitmap, USR3.mMarkPara[markno].mPicMark, USR3.mMarkPara[markno].picsize, offsetxy);
				if (num4 * 100.0 >= (double)USR3.mMarkPara[markno].recognizeRate)
				{
					num = 1;
				}
				break;
			}
			if (num == 0 && USR.mDebug_IsSaveErrBitmap)
			{
				string text = "C:/SmtLog/Mark/err_";
				DateTime now = DateTime.Now;
				string text2 = text;
				text = text2 + (markno + 1) + "_" + now.Year + now.Month.ToString("D2") + now.Day.ToString("D2") + "_" + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2") + "_" + now.Millisecond.ToString("D3") + ".jpg";
				Graphics graphics2 = Graphics.FromImage(MainForm0.mJVSBitmap[HW.mMarkCamItem[mFn].index[0]]);
				string text3 = "legacy  result=" + num + "   rate=" + num4;
				string text4 = "pricise  result=" + num + "    counts=" + num3;
				string s = text4 + Environment.NewLine + text3;
				Brush brush = new SolidBrush(Color.FromArgb(250, 250, 0));
				graphics2.DrawString(s, new Font("", 10.5f), brush, 2f, 2f);
				if (!Directory.Exists("C:/SmtLog/Mark/"))
				{
					Directory.CreateDirectory("C:/SmtLog/Mark/");
				}
				try
				{
					MainForm0.mJVSBitmap[HW.mMarkCamItem[mFn].index[0]].Save(text, ImageFormat.Jpeg);
				}
				catch (Exception)
				{
					MainForm0.write_to_logFile_EXCEPTION(" ImageVisual 1");
				}
				brush.Dispose();
				graphics2.Dispose();
			}
			return num;
		}

		private void checkBox_PcbAdjust_CheckedChanged(object sender, EventArgs e)
		{
			panel_PcbAdjust.Visible = checkBox_PcbAdjust.Checked;
		}

		private void checkBox_pcbadjust_pricise_CheckedChanged(object sender, EventArgs e)
		{
			USR3.mIsPcbAdjust_Pricise = checkBox_pcbadjust_pricise.Checked;
			if (!USR3.mIsPcbAdjust_Pricise)
			{
				Panel panel = panel_pcbadjust_ref1;
				bool visible = (panel_pcbadjust_ref2.Visible = false);
				panel.Visible = visible;
				panel_pcbadjust_M2.Location = new Point(355, 3);
			}
			else
			{
				panel_pcbadjust_ref1.Location = new Point(355, 3);
				panel_pcbadjust_M2.Location = new Point(355, 159);
				Panel panel2 = panel_pcbadjust_ref1;
				bool visible2 = (panel_pcbadjust_ref2.Visible = true);
				panel2.Visible = visible2;
			}
		}

		private void button_adjust_autoM0_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string text = (string)button.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			string msg = ((USR_INIT.mLanguage == 2) ? ("Auto detect to Mark" + (num + 1) + "   Start...") : ("自动识别至MARK" + (num + 1) + "   开始..."));
			MainForm0.CmMessageBox(msg, MessageBoxButtons.OK);
			Thread thread = new Thread(thd_RecognizeToMark);
			thread.IsBackground = true;
			thread.Start(num);
		}

		private void thd_RecognizeToMark(object o)
		{
			int num = (int)o;
			int ch = HW.mMarkCamItem[mFn].index[0];
			MainForm0.moveToZero_Z_andWait(mFn);
			MarkCamPara markCamPara = new MarkCamPara(USR.mMarkCamPara[USR.mMarkCamParaIndex], USR.mIsMarkLightOn, USR.mIsMarkLedOn);
			MainForm0.set_camera_parameter(ch, USR3.mMarkPara[num].mPara.mParaCam);
			MainForm0.mark_lightlevel_set(mFn, USR3.mMarkPara[num].mPara.mParaLed);
			MainForm0.mark_light_on(mFn, USR3.mMarkPara[num].mPara.mLightOn);
			MainForm0.mark_led_on(mFn, USR3.mMarkPara[num].mPara.mLedOn);
			if (MainForm0.uc_job[mFn].mark_recognize2(num, USR3.mMarkPara[num].mode, USR.mXYSpeed, new Coordinate(MainForm0.mCur[mFn].x, MainForm0.mCur[mFn].y), ref MainForm0.uc_job[mFn].mMarkFound[num]))
			{
				if (USR3.mMarkPara[num].mode == MarkModeType.Pricise && USR3.mMarkPara[num].isQuick)
				{
					MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, MainForm0.uc_job[mFn].mMarkFound[num]);
				}
				MainForm0.CmMessageBox("MARK" + (num + 1) + ((USR_INIT.mLanguage == 2) ? " Success! " : " 识别到位！"), MessageBoxButtons.OK);
			}
			else
			{
				MainForm0.CmMessageBox("MARK" + (num + 1) + ((USR_INIT.mLanguage == 2) ? " detect fail several times, please use manual mode confirm!" : "扫描多次，识别失败，自动切换至手动MARK模式"), MessageBoxButtons.OK);
			}
			MainForm0.set_camera_parameter(ch, markCamPara.mParaCam);
			MainForm0.mark_lightlevel_set(mFn, markCamPara.mParaLed);
			MainForm0.mark_light_on(mFn, markCamPara.mLightOn);
			MainForm0.mark_led_on(mFn, markCamPara.mLedOn);
		}

		private void button_adjust0XY_save_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string text = (string)button.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			if (MainForm0.CmMessageBox(((USR_INIT.mLanguage == 2) ? "Save PCB adjust M" : "是否确定保存PCB校正的M") + (num + 1), MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR3.mAdjustMark[num].X = (MainForm0.mIsSimulation ? (USR3.mMark[num].X + (int)numericUpDown_pcbadjust_debug_x_offset.Value) : MainForm0.mCur[mFn].x);
				USR3.mAdjustMark[num].Y = (MainForm0.mIsSimulation ? (USR3.mMark[num].Y + (int)numericUpDown_pcbadjust_debug_y_offset.Value) : MainForm0.mCur[mFn].y);
				label_adjust_coord[num].Text = MainForm0.format_XY_label_string(USR3.mAdjustMark[num]);
				Thread thread = new Thread(thread_adjust_mark_capture);
				thread.IsBackground = true;
				thread.Start(num);
			}
		}

		private void thread_adjust_mark_capture(object o)
		{
			int markno = (int)o;
			int num = HW.mMarkCamItem[mFn].index[0];
			MarkCamPara markCamPara = new MarkCamPara(USR.mMarkCamPara[USR.mMarkCamParaIndex], USR.mIsMarkLightOn, USR.mIsMarkLedOn);
			MainForm0.set_camera_parameter(num, USR3.mMarkPara[markno].mPara.mParaCam);
			MainForm0.mark_lightlevel_set(mFn, USR3.mMarkPara[markno].mPara.mParaLed);
			MainForm0.mark_light_on(mFn, USR3.mMarkPara[markno].mPara.mLightOn);
			MainForm0.mark_led_on(mFn, USR3.mMarkPara[markno].mPara.mLedOn);
			MainForm0.startMarkStill_andWait(mFn);
			Rectangle destRect = new Rectangle(0, 0, 150, 150);
			Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - 150) / 2, (MainForm0.mJvs_rawHeight - 150) / 2, 150, 150);
			Bitmap bitmap = new Bitmap(150, 150);
			if (!MainForm0.mIsSimulation)
			{
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.DrawImage(MainForm0.mJVSBitmap[num], destRect, srcRect, GraphicsUnit.Pixel);
				graphics.Dispose();
			}
			else
			{
				bitmap = new Bitmap(MainForm0.SIGN_PICTURE[markno]);
			}
			Bitmap b = new Bitmap(bitmap);
			Graphics graphics2 = Graphics.FromImage(b);
			int picsize = USR3.mMarkPara[markno].picsize;
			graphics2.DrawRectangle(new Pen(Color.Yellow, 1f), new Rectangle(new Point((150 - picsize) / 2, (150 - picsize) / 2), new Size(picsize, picsize)));
			graphics2.Dispose();
			USR3.mAdjustPic[markno] = bitmap;
			Invoke((MethodInvoker)delegate
			{
				Bitmap bitmap2 = new Bitmap(b);
				bitmap2.RotateFlip(RotateFlipType.Rotate180FlipX);
				pic_adjust[markno].Image = bitmap2;
			});
			MainForm0.set_camera_parameter(num, markCamPara.mParaCam);
			MainForm0.mark_lightlevel_set(mFn, markCamPara.mParaLed);
			MainForm0.mark_light_on(mFn, markCamPara.mLightOn);
			MainForm0.mark_led_on(mFn, markCamPara.mLedOn);
		}

		private void button_adjust0XY_moveto_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string text = (string)button.Tag;
			int num = ((!(text == "0")) ? 1 : 0);
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR3.mAdjustMark[num]);
			}
		}

		private void button_adjust_gotoalmostM2_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(new Coordinate(MainForm0.mCur[mFn].x + USR3.mMark[1].X - USR3.mMark[0].X, MainForm0.mCur[mFn].y + USR3.mMark[1].Y - USR3.mMark[0].Y));
			}
		}

		private void button_pcbadjust_reset_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 2; i++)
			{
				USR3.mAdjustMark[i].X = 0L;
				USR3.mAdjustMark[i].Y = 0L;
				label_adjust_coord[i].Text = MainForm0.format_XY_label_string(USR3.mAdjustMark[i]);
				USR3.mAdjustPic[i] = null;
				pic_adjust[i].Image = null;
			}
		}

		private void button_PcbAdjust_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "This operation will overwrite all smt XY data, cannot recovery, are you continue?" : "该操作会覆盖所有的贴装数据，不可恢复，是否继续操作", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			if (USR3.mAdjustPic[0] == null || USR3.mAdjustPic[1] == null)
			{
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Please set PCB adjust MARK XY firstly!" : "请先确定PCB校正MARK点！", MessageBoxButtons.OK);
				return;
			}
			long num = 0L;
			num = (USR3.mAdjustMark[0].X - USR3.mAdjustMark[1].X) * (USR3.mAdjustMark[0].X - USR3.mAdjustMark[1].X) + (USR3.mAdjustMark[0].Y - USR3.mAdjustMark[1].Y) * (USR3.mAdjustMark[0].Y - USR3.mAdjustMark[1].Y);
			if (num < 40000)
			{
				MessageBox.Show((USR_INIT.mLanguage == 2) ? "Two adjust Marks cannot be too near, please set new adjust Marks?" : "两个MARK点距离太近不合法，请重新设置！");
				return;
			}
			if (USR3.mPointlist != null && USR3.mPointlist.Count > 0)
			{
				for (int i = 0; i < USR3.mPointlist.Count; i++)
				{
					ChipBoardElement chipBoardElement = USR3.mPointlist[i];
					Coordinate coordinate = MainForm0.uc_job[mFn].fun_newxy(USR3.mMark, USR3.mAdjustMark, new Coordinate(chipBoardElement.X, chipBoardElement.Y));
					USR3.mPointlist[i].X = coordinate.X;
					USR3.mPointlist[i].Y = coordinate.Y;
					USR3.mPointlist[i].A += (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mMark, USR3.mAdjustMark) * 180.0 / Math.PI);
				}
			}
			USR3.mMark[0] = new Coordinate(USR3.mAdjustMark[0].X, USR3.mAdjustMark[0].Y);
			USR3.mMark[1] = new Coordinate(USR3.mAdjustMark[1].X, USR3.mAdjustMark[1].Y);
			USR3.mMarkPic[0] = new Bitmap(USR3.mAdjustPic[0]);
			USR3.mMarkPic[1] = new Bitmap(USR3.mAdjustPic[1]);
			USR3.mMarkSearch[0] = new Coordinate(USR3.mAdjustMark[0].X, USR3.mAdjustMark[0].Y);
			label_Search_coord[0].Text = MainForm0.format_XY_label_string(USR3.mMarkSearch[0]);
			USR3.mMarkSearch[1] = new Coordinate(USR3.mAdjustMark[1].X, USR3.mAdjustMark[1].Y);
			label_Search_coord[1].Text = MainForm0.format_XY_label_string(USR3.mMarkSearch[1]);
			if (this.SetEdit_XY != null)
			{
				this.SetEdit_XY(flag: true);
			}
			MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "PCB adjust done!" : "PCB校正完成！", MessageBoxButtons.OK);
			checkBox_PcbAdjust.Checked = false;
		}

		private void button_MarkTest_Click(object sender, EventArgs e)
		{
			MainForm0.uc_job[mFn].vsplus_mark_test(USR3);
		}
	}
}
