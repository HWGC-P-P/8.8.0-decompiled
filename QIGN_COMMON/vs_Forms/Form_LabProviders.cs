using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_LabProviders : Form
	{
		private IContainer components;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private Label label1;

		private Panel panel1;

		private Panel panel_feeder;

		private Panel panel_vibra;

		private Panel panel_plate;

		private Label label3;

		private Label label4;

		private Label label5;

		private Button button1;

		private Button button_stacksel_plate;

		private Button button_stacksel_vibra;

		private Button button_stacksel_feeder;

		private Panel panel_stackselNew_Page;

		private Label label2;

		private Label label_stacksel_title;

		private Panel panel_stackselslot_vibra;

		private Label label_Vibra;

		private ListBox listBox_StackVibraAll;

		private Panel panel_stackselslot_plate;

		private ListBox listBox_StackPlateAll;

		private Label label_StackPlate;

		private Panel panel_stackselslot_feeder;

		private Label label_Stack;

		private Panel panel_feeder_vibra_pikxy;

		private Label label7;

		private Label label_stackXY;

		private Button button5;

		private Button button6;

		private Button button7;

		private Button button_stackplate_startIndex;

		private Button button8;

		private Label label9;

		private Panel panel_stacktool0;

		private Label label_stacknew_chipinfo;

		private Label label_stacknew_chipLmm;

		private Label label_stacknew_chipWmm;

		private Label label15;

		private Label label14;

		private Button button11;

		private Button button10;

		private Label label17;

		private Button button13;

		private Button button12;

		private NumericUpDown numericUpDown_mntH_offset;

		private NumericUpDown numericUpDown_pikH_offset;

		private Label label21;

		private Label label20;

		private Panel panel5;

		private Button button14;

		private Button button15;

		private Label label_stack_visual;

		private CheckBox checkBox_stackCollect;

		private NumericUpDown numericUpDown_stackCollect;

		private Label label23;

		private CheckBox checkBox_isScanR;

		private Label label24;

		private Button button_reback;

		private Button button_stackThrow;

		private Button button_closefeeder;

		private Button button_openfeeder;

		private Label label_scanR;

		private Label label_stacknew_chipHmm;

		private Label label26;

		private Button button20;

		private Panel panel_stackplate_autoprovider;

		private CheckBox checkBox_stackplate_AutoEntComponent;

		private Label label13;

		private NumericUpDown numericUpDown_AutoEntTimeDelay;

		private Panel panel_feederdelay;

		private NumericUpDown numericUpDown_feederdelay;

		private Label label28;

		private Label label16;

		private Button button_goto_pikxy_byNozzle;

		private Panel panel8;

		private Panel panel_nozzleenable;

		private Label label30;

		private Button button22;

		private Panel panel10;

		private Panel panel_isScanR;

		private Panel panel_stacknew_pik;

		private Panel panel_stacknew_mnt;

		private Panel panel_stacknew_visual;

		private Button button_close;

		private Panel panel_plate_pikxy;

		private Button button2;

		private Button button9;

		private Button button4;

		private Button button3;

		private Button button16;

		private Button button17;

		private Label label6;

		private Label label8;

		private Label label10;

		private Label label11;

		private Label label18;

		private Label label12;

		private Button button19;

		private Button button18;

		private Label label19;

		private Panel panel3;

		private Label label22;

		private Button button23;

		private Button button_moreplates;

		private USR_INIT_DATA USR_INIT;

		private USR_DATA USR;

		private USR_STACKLIB mStackLib;

		private Label[] label_stack_pikZnName;

		private Label[] label_stack_pikH;

		public CheckBox[] checkBox_stack_nozzleEn;

		private NumericUpDown[][] numericUpDown_stack_pikConfig;

		public Label[] label_stack_mntZnName;

		public Label[] label_stack_mntH;

		public NumericUpDown[][] numericUpDown_stack_mntConfig;

		public NumericUpDown[] numericUpDown_stack_threshold;

		public Label[] label_stack_nozzleEnName;

		private Button[] button_stacksel;

		public static string[][] STACK_SEL_STR = new string[3][]
		{
			new string[3] { "普通飞达", "普通飞达", "FEEDER" },
			new string[3] { "托盘料盘", "托盘料盘", "PLATE" },
			new string[3] { "振动飞达", "振动飞达", "VIBRA FEEDER" }
		};

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
			panel_stackselslot_plate = new System.Windows.Forms.Panel();
			listBox_StackPlateAll = new System.Windows.Forms.ListBox();
			label_StackPlate = new System.Windows.Forms.Label();
			panel_plate_pikxy = new System.Windows.Forms.Panel();
			button8 = new System.Windows.Forms.Button();
			button_stackplate_startIndex = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			panel_stackselslot_feeder = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			label11 = new System.Windows.Forms.Label();
			button_openfeeder = new System.Windows.Forms.Button();
			label22 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			button_closefeeder = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label_Stack = new System.Windows.Forms.Label();
			panel_stackselNew_Page = new System.Windows.Forms.Panel();
			label_stacknew_chipinfo = new System.Windows.Forms.Label();
			panel_feeder_vibra_pikxy = new System.Windows.Forms.Panel();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button17 = new System.Windows.Forms.Button();
			label_stackXY = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			panel10 = new System.Windows.Forms.Panel();
			panel_stacknew_mnt = new System.Windows.Forms.Panel();
			label21 = new System.Windows.Forms.Label();
			numericUpDown_mntH_offset = new System.Windows.Forms.NumericUpDown();
			button13 = new System.Windows.Forms.Button();
			label10 = new System.Windows.Forms.Label();
			panel8 = new System.Windows.Forms.Panel();
			numericUpDown_pikH_offset = new System.Windows.Forms.NumericUpDown();
			panel_stacknew_pik = new System.Windows.Forms.Panel();
			panel_nozzleenable = new System.Windows.Forms.Panel();
			button12 = new System.Windows.Forms.Button();
			label17 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			panel5 = new System.Windows.Forms.Panel();
			button_stackThrow = new System.Windows.Forms.Button();
			button_reback = new System.Windows.Forms.Button();
			panel_stacknew_visual = new System.Windows.Forms.Panel();
			panel_isScanR = new System.Windows.Forms.Panel();
			label_scanR = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label_stacknew_chipHmm = new System.Windows.Forms.Label();
			label_stacknew_chipWmm = new System.Windows.Forms.Label();
			label_stacknew_chipLmm = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			button23 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			checkBox_stackCollect = new System.Windows.Forms.CheckBox();
			label15 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			checkBox_isScanR = new System.Windows.Forms.CheckBox();
			button14 = new System.Windows.Forms.Button();
			numericUpDown_stackCollect = new System.Windows.Forms.NumericUpDown();
			label14 = new System.Windows.Forms.Label();
			button20 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			label_stack_visual = new System.Windows.Forms.Label();
			panel_stacktool0 = new System.Windows.Forms.Panel();
			button19 = new System.Windows.Forms.Button();
			button18 = new System.Windows.Forms.Button();
			button_goto_pikxy_byNozzle = new System.Windows.Forms.Button();
			panel_feederdelay = new System.Windows.Forms.Panel();
			numericUpDown_feederdelay = new System.Windows.Forms.NumericUpDown();
			label28 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			button10 = new System.Windows.Forms.Button();
			panel_stackplate_autoprovider = new System.Windows.Forms.Panel();
			numericUpDown_AutoEntTimeDelay = new System.Windows.Forms.NumericUpDown();
			checkBox_stackplate_AutoEntComponent = new System.Windows.Forms.CheckBox();
			label13 = new System.Windows.Forms.Label();
			label_stacksel_title = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_stacksel_feeder = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button16 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button22 = new System.Windows.Forms.Button();
			button_stacksel_vibra = new System.Windows.Forms.Button();
			button_stacksel_plate = new System.Windows.Forms.Button();
			label30 = new System.Windows.Forms.Label();
			panel_stackselslot_vibra = new System.Windows.Forms.Panel();
			listBox_StackVibraAll = new System.Windows.Forms.ListBox();
			label18 = new System.Windows.Forms.Label();
			label_Vibra = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			button_close = new System.Windows.Forms.Button();
			button_moreplates = new System.Windows.Forms.Button();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			panel1.SuspendLayout();
			panel_feeder.SuspendLayout();
			panel_stackselslot_plate.SuspendLayout();
			panel_plate_pikxy.SuspendLayout();
			panel_stackselslot_feeder.SuspendLayout();
			panel3.SuspendLayout();
			panel_stackselNew_Page.SuspendLayout();
			panel_feeder_vibra_pikxy.SuspendLayout();
			panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mntH_offset).BeginInit();
			panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pikH_offset).BeginInit();
			panel5.SuspendLayout();
			panel_isScanR.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_stackCollect).BeginInit();
			panel_stacktool0.SuspendLayout();
			panel_feederdelay.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_feederdelay).BeginInit();
			panel_stackplate_autoprovider.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_AutoEntTimeDelay).BeginInit();
			panel_stackselslot_vibra.SuspendLayout();
			SuspendLayout();
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Location = new System.Drawing.Point(871, 240);
			tabControl1.Multiline = true;
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(347, 105);
			tabControl1.TabIndex = 0;
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
			panel_stackselslot_plate.Controls.Add(listBox_StackPlateAll);
			panel_stackselslot_plate.Controls.Add(label_StackPlate);
			panel_stackselslot_plate.Location = new System.Drawing.Point(713, 462);
			panel_stackselslot_plate.Name = "panel_stackselslot_plate";
			panel_stackselslot_plate.Size = new System.Drawing.Size(550, 66);
			panel_stackselslot_plate.TabIndex = 5;
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
			listBox_StackPlateAll.Location = new System.Drawing.Point(65, 1);
			listBox_StackPlateAll.MultiColumn = true;
			listBox_StackPlateAll.Name = "listBox_StackPlateAll";
			listBox_StackPlateAll.Size = new System.Drawing.Size(484, 64);
			listBox_StackPlateAll.TabIndex = 6;
			listBox_StackPlateAll.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox_StackPlateAll_MouseClick);
			listBox_StackPlateAll.DrawItem += new System.Windows.Forms.DrawItemEventHandler(listBox_StackPlateAll_DrawItem);
			label_StackPlate.BackColor = System.Drawing.Color.Azure;
			label_StackPlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_StackPlate.Font = new System.Drawing.Font("黑体", 25.5f);
			label_StackPlate.Location = new System.Drawing.Point(0, 1);
			label_StackPlate.Name = "label_StackPlate";
			label_StackPlate.Size = new System.Drawing.Size(64, 64);
			label_StackPlate.TabIndex = 6;
			label_StackPlate.Text = "12";
			label_StackPlate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_plate_pikxy.Controls.Add(button8);
			panel_plate_pikxy.Controls.Add(button_stackplate_startIndex);
			panel_plate_pikxy.Controls.Add(label9);
			panel_plate_pikxy.Location = new System.Drawing.Point(715, 113);
			panel_plate_pikxy.Name = "panel_plate_pikxy";
			panel_plate_pikxy.Size = new System.Drawing.Size(150, 146);
			panel_plate_pikxy.TabIndex = 11;
			button8.Location = new System.Drawing.Point(0, 23);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(145, 42);
			button8.TabIndex = 7;
			button8.Text = "取料坐标列表";
			button8.UseVisualStyleBackColor = true;
			button_stackplate_startIndex.Location = new System.Drawing.Point(0, 64);
			button_stackplate_startIndex.Name = "button_stackplate_startIndex";
			button_stackplate_startIndex.Size = new System.Drawing.Size(145, 57);
			button_stackplate_startIndex.TabIndex = 7;
			button_stackplate_startIndex.Text = "起始索引\r\n1-1";
			button_stackplate_startIndex.UseVisualStyleBackColor = true;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label9.Location = new System.Drawing.Point(38, 4);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(76, 16);
			label9.TabIndex = 0;
			label9.Text = "取料坐标";
			panel_stackselslot_feeder.Controls.Add(panel3);
			panel_stackselslot_feeder.Controls.Add(label7);
			panel_stackselslot_feeder.Controls.Add(label6);
			panel_stackselslot_feeder.Controls.Add(label_Stack);
			panel_stackselslot_feeder.Location = new System.Drawing.Point(6, 131);
			panel_stackselslot_feeder.Name = "panel_stackselslot_feeder";
			panel_stackselslot_feeder.Size = new System.Drawing.Size(547, 66);
			panel_stackselslot_feeder.TabIndex = 5;
			panel3.BackColor = System.Drawing.Color.Tan;
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(label11);
			panel3.Controls.Add(button_openfeeder);
			panel3.Controls.Add(label22);
			panel3.Controls.Add(label19);
			panel3.Controls.Add(button_closefeeder);
			panel3.Location = new System.Drawing.Point(65, 1);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(368, 64);
			panel3.TabIndex = 12;
			label11.BackColor = System.Drawing.Color.LightCyan;
			label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label11.Font = new System.Drawing.Font("楷体", 12.75f);
			label11.Location = new System.Drawing.Point(189, 4);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(59, 55);
			label11.TabIndex = 83;
			label11.Text = "已关";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_openfeeder.Location = new System.Drawing.Point(248, 3);
			button_openfeeder.Name = "button_openfeeder";
			button_openfeeder.Size = new System.Drawing.Size(118, 29);
			button_openfeeder.TabIndex = 3;
			button_openfeeder.Text = "强制开飞达";
			button_openfeeder.UseVisualStyleBackColor = true;
			label22.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label22.Location = new System.Drawing.Point(147, 3);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(52, 52);
			label22.TabIndex = 82;
			label22.Text = "➠";
			label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label19.Location = new System.Drawing.Point(112, 22);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(42, 16);
			label19.TabIndex = 0;
			label19.Text = "状态";
			button_closefeeder.Location = new System.Drawing.Point(248, 31);
			button_closefeeder.Name = "button_closefeeder";
			button_closefeeder.Size = new System.Drawing.Size(118, 29);
			button_closefeeder.TabIndex = 3;
			button_closefeeder.Text = "强制关飞达";
			button_closefeeder.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label7.Location = new System.Drawing.Point(438, 26);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(76, 16);
			label7.TabIndex = 0;
			label7.Text = "取料坐标";
			label6.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label6.Location = new System.Drawing.Point(508, 8);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(52, 52);
			label6.TabIndex = 82;
			label6.Text = "➠";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_Stack.BackColor = System.Drawing.Color.LightSalmon;
			label_Stack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_Stack.Font = new System.Drawing.Font("黑体", 25.5f);
			label_Stack.Location = new System.Drawing.Point(0, 1);
			label_Stack.Name = "label_Stack";
			label_Stack.Size = new System.Drawing.Size(64, 64);
			label_Stack.TabIndex = 6;
			label_Stack.Text = "12";
			label_Stack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_Stack.MouseHover += new System.EventHandler(label_Stack_MouseHover_1);
			panel_stackselNew_Page.BackColor = System.Drawing.Color.CadetBlue;
			panel_stackselNew_Page.Controls.Add(panel_stackselslot_feeder);
			panel_stackselNew_Page.Controls.Add(panel_stacktool0);
			panel_stackselNew_Page.Controls.Add(label_stacknew_chipinfo);
			panel_stackselNew_Page.Controls.Add(panel_feeder_vibra_pikxy);
			panel_stackselNew_Page.Controls.Add(panel10);
			panel_stackselNew_Page.Controls.Add(panel8);
			panel_stackselNew_Page.Controls.Add(panel5);
			panel_stackselNew_Page.Controls.Add(label_stacksel_title);
			panel_stackselNew_Page.Controls.Add(label8);
			panel_stackselNew_Page.Controls.Add(label2);
			panel_stackselNew_Page.Controls.Add(button_stacksel_feeder);
			panel_stackselNew_Page.Controls.Add(button9);
			panel_stackselNew_Page.Controls.Add(button4);
			panel_stackselNew_Page.Controls.Add(button3);
			panel_stackselNew_Page.Controls.Add(button16);
			panel_stackselNew_Page.Controls.Add(button2);
			panel_stackselNew_Page.Controls.Add(button22);
			panel_stackselNew_Page.Controls.Add(button_stacksel_vibra);
			panel_stackselNew_Page.Controls.Add(button_stacksel_plate);
			panel_stackselNew_Page.Location = new System.Drawing.Point(2, 22);
			panel_stackselNew_Page.Name = "panel_stackselNew_Page";
			panel_stackselNew_Page.Size = new System.Drawing.Size(705, 846);
			panel_stackselNew_Page.TabIndex = 4;
			label_stacknew_chipinfo.BackColor = System.Drawing.Color.White;
			label_stacknew_chipinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stacknew_chipinfo.Font = new System.Drawing.Font("黑体", 13.5f);
			label_stacknew_chipinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipinfo.Location = new System.Drawing.Point(6, 108);
			label_stacknew_chipinfo.Name = "label_stacknew_chipinfo";
			label_stacknew_chipinfo.Size = new System.Drawing.Size(692, 23);
			label_stacknew_chipinfo.TabIndex = 6;
			label_stacknew_chipinfo.Text = "R0603 100K";
			label_stacknew_chipinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_feeder_vibra_pikxy.Controls.Add(button6);
			panel_feeder_vibra_pikxy.Controls.Add(button5);
			panel_feeder_vibra_pikxy.Controls.Add(button17);
			panel_feeder_vibra_pikxy.Controls.Add(label_stackXY);
			panel_feeder_vibra_pikxy.Controls.Add(button7);
			panel_feeder_vibra_pikxy.Location = new System.Drawing.Point(555, 132);
			panel_feeder_vibra_pikxy.Name = "panel_feeder_vibra_pikxy";
			panel_feeder_vibra_pikxy.Size = new System.Drawing.Size(144, 133);
			panel_feeder_vibra_pikxy.TabIndex = 6;
			button6.Location = new System.Drawing.Point(71, 32);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(72, 33);
			button6.TabIndex = 7;
			button6.Text = "定位";
			button6.UseVisualStyleBackColor = true;
			button5.Location = new System.Drawing.Point(71, -1);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(72, 34);
			button5.TabIndex = 7;
			button5.Text = "保存";
			button5.UseVisualStyleBackColor = true;
			button17.Location = new System.Drawing.Point(0, 64);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(72, 57);
			button17.TabIndex = 7;
			button17.Text = "定位：上一个有效";
			button17.UseVisualStyleBackColor = true;
			label_stackXY.BackColor = System.Drawing.Color.Azure;
			label_stackXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stackXY.Font = new System.Drawing.Font("黑体", 12.5f);
			label_stackXY.Location = new System.Drawing.Point(1, 0);
			label_stackXY.Name = "label_stackXY";
			label_stackXY.Size = new System.Drawing.Size(70, 64);
			label_stackXY.TabIndex = 6;
			label_stackXY.Text = "X00000\r\nY00000";
			label_stackXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button7.Location = new System.Drawing.Point(71, 64);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(72, 57);
			button7.TabIndex = 7;
			button7.Text = "定位：下一个有效";
			button7.UseVisualStyleBackColor = true;
			panel10.Controls.Add(panel_stacknew_mnt);
			panel10.Controls.Add(label21);
			panel10.Controls.Add(numericUpDown_mntH_offset);
			panel10.Controls.Add(button13);
			panel10.Controls.Add(label10);
			panel10.Location = new System.Drawing.Point(4, 675);
			panel10.Name = "panel10";
			panel10.Size = new System.Drawing.Size(693, 163);
			panel10.TabIndex = 11;
			panel_stacknew_mnt.Location = new System.Drawing.Point(7, 33);
			panel_stacknew_mnt.Name = "panel_stacknew_mnt";
			panel_stacknew_mnt.Size = new System.Drawing.Size(690, 127);
			panel_stacknew_mnt.TabIndex = 9;
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(260, 12);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(119, 14);
			label21.TabIndex = 0;
			label21.Text = "贴装下压偏移(mm)";
			numericUpDown_mntH_offset.DecimalPlaces = 2;
			numericUpDown_mntH_offset.Location = new System.Drawing.Point(381, 7);
			numericUpDown_mntH_offset.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_mntH_offset.Name = "numericUpDown_mntH_offset";
			numericUpDown_mntH_offset.Size = new System.Drawing.Size(60, 23);
			numericUpDown_mntH_offset.TabIndex = 8;
			numericUpDown_mntH_offset.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			button13.Location = new System.Drawing.Point(123, 3);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(131, 29);
			button13.TabIndex = 3;
			button13.Text = "PCB基准高度";
			button13.UseVisualStyleBackColor = true;
			label10.Font = new System.Drawing.Font("黑体", 12.25f, System.Drawing.FontStyle.Bold);
			label10.Location = new System.Drawing.Point(3, 8);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(123, 18);
			label10.TabIndex = 0;
			label10.Text = "贴装Z轴设置";
			panel8.Controls.Add(numericUpDown_pikH_offset);
			panel8.Controls.Add(panel_stacknew_pik);
			panel8.Controls.Add(panel_nozzleenable);
			panel8.Controls.Add(button12);
			panel8.Controls.Add(label17);
			panel8.Controls.Add(label20);
			panel8.Location = new System.Drawing.Point(2, 305);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(696, 186);
			panel8.TabIndex = 10;
			numericUpDown_pikH_offset.DecimalPlaces = 2;
			numericUpDown_pikH_offset.Location = new System.Drawing.Point(366, 4);
			numericUpDown_pikH_offset.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_pikH_offset.Name = "numericUpDown_pikH_offset";
			numericUpDown_pikH_offset.Size = new System.Drawing.Size(60, 23);
			numericUpDown_pikH_offset.TabIndex = 8;
			numericUpDown_pikH_offset.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			panel_stacknew_pik.Location = new System.Drawing.Point(6, 56);
			panel_stacknew_pik.Name = "panel_stacknew_pik";
			panel_stacknew_pik.Size = new System.Drawing.Size(690, 136);
			panel_stacknew_pik.TabIndex = 9;
			panel_nozzleenable.BackColor = System.Drawing.Color.White;
			panel_nozzleenable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_nozzleenable.Location = new System.Drawing.Point(5, 31);
			panel_nozzleenable.Name = "panel_nozzleenable";
			panel_nozzleenable.Size = new System.Drawing.Size(594, 24);
			panel_nozzleenable.TabIndex = 1;
			button12.Location = new System.Drawing.Point(116, 1);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(131, 29);
			button12.TabIndex = 3;
			button12.Text = "托盘基准高度";
			button12.UseVisualStyleBackColor = true;
			label17.Font = new System.Drawing.Font("黑体", 12.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label17.Location = new System.Drawing.Point(1, 6);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(131, 18);
			label17.TabIndex = 0;
			label17.Text = "取料Z轴设置";
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(247, 8);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(119, 14);
			label20.TabIndex = 0;
			label20.Text = "取料下压偏移(mm)";
			panel5.Controls.Add(button_stackThrow);
			panel5.Controls.Add(button_reback);
			panel5.Controls.Add(panel_stacknew_visual);
			panel5.Controls.Add(panel_isScanR);
			panel5.Controls.Add(label_stacknew_chipHmm);
			panel5.Controls.Add(label_stacknew_chipWmm);
			panel5.Controls.Add(label_stacknew_chipLmm);
			panel5.Controls.Add(label26);
			panel5.Controls.Add(button23);
			panel5.Controls.Add(button1);
			panel5.Controls.Add(checkBox_stackCollect);
			panel5.Controls.Add(label15);
			panel5.Controls.Add(label23);
			panel5.Controls.Add(checkBox_isScanR);
			panel5.Controls.Add(button14);
			panel5.Controls.Add(numericUpDown_stackCollect);
			panel5.Controls.Add(label14);
			panel5.Controls.Add(button20);
			panel5.Controls.Add(button15);
			panel5.Controls.Add(button11);
			panel5.Controls.Add(label_stack_visual);
			panel5.Location = new System.Drawing.Point(6, 522);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(696, 146);
			panel5.TabIndex = 9;
			button_stackThrow.Location = new System.Drawing.Point(286, 28);
			button_stackThrow.Name = "button_stackThrow";
			button_stackThrow.Size = new System.Drawing.Size(78, 29);
			button_stackThrow.TabIndex = 3;
			button_stackThrow.Text = "抛料";
			button_stackThrow.UseVisualStyleBackColor = true;
			button_reback.Location = new System.Drawing.Point(286, 56);
			button_reback.Name = "button_reback";
			button_reback.Size = new System.Drawing.Size(78, 29);
			button_reback.TabIndex = 3;
			button_reback.Text = "放回";
			button_reback.UseVisualStyleBackColor = true;
			panel_stacknew_visual.Location = new System.Drawing.Point(2, 85);
			panel_stacknew_visual.Name = "panel_stacknew_visual";
			panel_stacknew_visual.Size = new System.Drawing.Size(690, 60);
			panel_stacknew_visual.TabIndex = 9;
			panel_isScanR.Controls.Add(label_scanR);
			panel_isScanR.Controls.Add(label24);
			panel_isScanR.Location = new System.Drawing.Point(487, 53);
			panel_isScanR.Name = "panel_isScanR";
			panel_isScanR.Size = new System.Drawing.Size(178, 32);
			panel_isScanR.TabIndex = 12;
			label_scanR.BackColor = System.Drawing.Color.Azure;
			label_scanR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_scanR.Font = new System.Drawing.Font("黑体", 10.5f);
			label_scanR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_scanR.Location = new System.Drawing.Point(68, 3);
			label_scanR.Name = "label_scanR";
			label_scanR.Size = new System.Drawing.Size(40, 22);
			label_scanR.TabIndex = 6;
			label_scanR.Text = "180";
			label_scanR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(3, 7);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(63, 14);
			label24.TabIndex = 0;
			label24.Text = "扫描半径";
			label_stacknew_chipHmm.BackColor = System.Drawing.Color.Azure;
			label_stacknew_chipHmm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stacknew_chipHmm.Font = new System.Drawing.Font("黑体", 11.5f);
			label_stacknew_chipHmm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipHmm.Location = new System.Drawing.Point(413, 57);
			label_stacknew_chipHmm.Name = "label_stacknew_chipHmm";
			label_stacknew_chipHmm.Size = new System.Drawing.Size(57, 22);
			label_stacknew_chipHmm.TabIndex = 6;
			label_stacknew_chipHmm.Text = "100";
			label_stacknew_chipHmm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_stacknew_chipWmm.BackColor = System.Drawing.Color.Azure;
			label_stacknew_chipWmm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stacknew_chipWmm.Font = new System.Drawing.Font("黑体", 11.5f);
			label_stacknew_chipWmm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipWmm.Location = new System.Drawing.Point(413, 32);
			label_stacknew_chipWmm.Name = "label_stacknew_chipWmm";
			label_stacknew_chipWmm.Size = new System.Drawing.Size(57, 22);
			label_stacknew_chipWmm.TabIndex = 6;
			label_stacknew_chipWmm.Text = "100";
			label_stacknew_chipWmm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_stacknew_chipLmm.BackColor = System.Drawing.Color.Azure;
			label_stacknew_chipLmm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stacknew_chipLmm.Font = new System.Drawing.Font("黑体", 11.5f);
			label_stacknew_chipLmm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stacknew_chipLmm.Location = new System.Drawing.Point(413, 7);
			label_stacknew_chipLmm.Name = "label_stacknew_chipLmm";
			label_stacknew_chipLmm.Size = new System.Drawing.Size(57, 22);
			label_stacknew_chipLmm.TabIndex = 6;
			label_stacknew_chipLmm.Text = "100";
			label_stacknew_chipLmm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(368, 61);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(49, 14);
			label26.TabIndex = 0;
			label26.Text = "厚(mm)";
			button23.Location = new System.Drawing.Point(207, 28);
			button23.Name = "button23";
			button23.Size = new System.Drawing.Size(80, 57);
			button23.TabIndex = 2;
			button23.Text = "实时视觉";
			button23.UseVisualStyleBackColor = true;
			button1.Location = new System.Drawing.Point(286, 4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(78, 25);
			button1.TabIndex = 2;
			button1.Text = "采集尺寸";
			button1.UseVisualStyleBackColor = true;
			checkBox_stackCollect.AutoSize = true;
			checkBox_stackCollect.Location = new System.Drawing.Point(473, 8);
			checkBox_stackCollect.Name = "checkBox_stackCollect";
			checkBox_stackCollect.Size = new System.Drawing.Size(82, 18);
			checkBox_stackCollect.TabIndex = 11;
			checkBox_stackCollect.Text = "特征识别";
			checkBox_stackCollect.UseVisualStyleBackColor = true;
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(368, 36);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(49, 14);
			label15.TabIndex = 0;
			label15.Text = "宽(mm)";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(554, 9);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(84, 14);
			label23.TabIndex = 0;
			label23.Text = "识别容差(%)";
			checkBox_isScanR.AutoSize = true;
			checkBox_isScanR.Location = new System.Drawing.Point(473, 34);
			checkBox_isScanR.Name = "checkBox_isScanR";
			checkBox_isScanR.Size = new System.Drawing.Size(82, 18);
			checkBox_isScanR.TabIndex = 11;
			checkBox_isScanR.Text = "特殊尺寸";
			checkBox_isScanR.UseVisualStyleBackColor = true;
			button14.Location = new System.Drawing.Point(1, 56);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(131, 29);
			button14.TabIndex = 3;
			button14.Text = "拾取至高清相机";
			button14.UseVisualStyleBackColor = true;
			numericUpDown_stackCollect.Location = new System.Drawing.Point(639, 5);
			numericUpDown_stackCollect.Name = "numericUpDown_stackCollect";
			numericUpDown_stackCollect.Size = new System.Drawing.Size(52, 23);
			numericUpDown_stackCollect.TabIndex = 8;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(368, 11);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(49, 14);
			label14.TabIndex = 0;
			label14.Text = "长(mm)";
			button20.Location = new System.Drawing.Point(1, 4);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(131, 25);
			button20.TabIndex = 3;
			button20.Text = "相机光源";
			button20.UseVisualStyleBackColor = true;
			button15.Location = new System.Drawing.Point(131, 28);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(77, 57);
			button15.TabIndex = 3;
			button15.Text = "识别测试";
			button15.UseVisualStyleBackColor = true;
			button11.Location = new System.Drawing.Point(1, 28);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(131, 29);
			button11.TabIndex = 3;
			button11.Text = "拾取至快速相机";
			button11.UseVisualStyleBackColor = true;
			label_stack_visual.BackColor = System.Drawing.Color.Azure;
			label_stack_visual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stack_visual.Font = new System.Drawing.Font("黑体", 10.5f);
			label_stack_visual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_stack_visual.Location = new System.Drawing.Point(132, 5);
			label_stack_visual.Name = "label_stack_visual";
			label_stack_visual.Size = new System.Drawing.Size(154, 23);
			label_stack_visual.TabIndex = 6;
			label_stack_visual.Text = "标准视觉";
			label_stack_visual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_stacktool0.Controls.Add(button19);
			panel_stacktool0.Controls.Add(button18);
			panel_stacktool0.Controls.Add(button_goto_pikxy_byNozzle);
			panel_stacktool0.Controls.Add(panel_feederdelay);
			panel_stacktool0.Controls.Add(button10);
			panel_stacktool0.Controls.Add(panel_stackplate_autoprovider);
			panel_stacktool0.Location = new System.Drawing.Point(5, 196);
			panel_stacktool0.Name = "panel_stacktool0";
			panel_stacktool0.Size = new System.Drawing.Size(551, 66);
			panel_stacktool0.TabIndex = 7;
			button19.Location = new System.Drawing.Point(315, 28);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(118, 29);
			button19.TabIndex = 84;
			button19.Text = "关吸嘴真空";
			button19.UseVisualStyleBackColor = true;
			button18.Location = new System.Drawing.Point(315, 0);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(118, 29);
			button18.TabIndex = 84;
			button18.Text = "开吸嘴真空";
			button18.UseVisualStyleBackColor = true;
			button_goto_pikxy_byNozzle.Location = new System.Drawing.Point(432, 0);
			button_goto_pikxy_byNozzle.Name = "button_goto_pikxy_byNozzle";
			button_goto_pikxy_byNozzle.Size = new System.Drawing.Size(119, 57);
			button_goto_pikxy_byNozzle.TabIndex = 3;
			button_goto_pikxy_byNozzle.Text = "吸嘴定位到\r\n取料坐标";
			button_goto_pikxy_byNozzle.UseVisualStyleBackColor = true;
			panel_feederdelay.BackColor = System.Drawing.Color.White;
			panel_feederdelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_feederdelay.Controls.Add(numericUpDown_feederdelay);
			panel_feederdelay.Controls.Add(label28);
			panel_feederdelay.Controls.Add(label16);
			panel_feederdelay.Location = new System.Drawing.Point(66, 29);
			panel_feederdelay.Name = "panel_feederdelay";
			panel_feederdelay.Size = new System.Drawing.Size(249, 27);
			panel_feederdelay.TabIndex = 10;
			numericUpDown_feederdelay.Location = new System.Drawing.Point(190, 1);
			numericUpDown_feederdelay.Name = "numericUpDown_feederdelay";
			numericUpDown_feederdelay.Size = new System.Drawing.Size(52, 23);
			numericUpDown_feederdelay.TabIndex = 8;
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(27, 5);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(63, 14);
			label28.TabIndex = 0;
			label28.Text = "连续取料";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(91, 5);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(91, 14);
			label16.TabIndex = 0;
			label16.Text = "换料延时(ms)";
			button10.Location = new System.Drawing.Point(0, 0);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(66, 57);
			button10.TabIndex = 3;
			button10.Text = "参数批量复制";
			button10.UseVisualStyleBackColor = true;
			panel_stackplate_autoprovider.BackColor = System.Drawing.Color.White;
			panel_stackplate_autoprovider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_stackplate_autoprovider.Controls.Add(numericUpDown_AutoEntTimeDelay);
			panel_stackplate_autoprovider.Controls.Add(checkBox_stackplate_AutoEntComponent);
			panel_stackplate_autoprovider.Controls.Add(label13);
			panel_stackplate_autoprovider.Location = new System.Drawing.Point(66, 1);
			panel_stackplate_autoprovider.Name = "panel_stackplate_autoprovider";
			panel_stackplate_autoprovider.Size = new System.Drawing.Size(249, 27);
			panel_stackplate_autoprovider.TabIndex = 10;
			numericUpDown_AutoEntTimeDelay.Location = new System.Drawing.Point(190, 1);
			numericUpDown_AutoEntTimeDelay.Name = "numericUpDown_AutoEntTimeDelay";
			numericUpDown_AutoEntTimeDelay.Size = new System.Drawing.Size(52, 23);
			numericUpDown_AutoEntTimeDelay.TabIndex = 8;
			checkBox_stackplate_AutoEntComponent.AutoSize = true;
			checkBox_stackplate_AutoEntComponent.Location = new System.Drawing.Point(10, 3);
			checkBox_stackplate_AutoEntComponent.Name = "checkBox_stackplate_AutoEntComponent";
			checkBox_stackplate_AutoEntComponent.Size = new System.Drawing.Size(82, 18);
			checkBox_stackplate_AutoEntComponent.TabIndex = 11;
			checkBox_stackplate_AutoEntComponent.Text = "自动供料";
			checkBox_stackplate_AutoEntComponent.UseVisualStyleBackColor = true;
			checkBox_stackplate_AutoEntComponent.CheckedChanged += new System.EventHandler(checkBox_stackplate_AutoEntComponent_CheckedChanged);
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(91, 4);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(91, 14);
			label13.TabIndex = 0;
			label13.Text = "换料延时(ms)";
			label_stacksel_title.AutoSize = true;
			label_stacksel_title.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_stacksel_title.Location = new System.Drawing.Point(301, 79);
			label_stacksel_title.Name = "label_stacksel_title";
			label_stacksel_title.Size = new System.Drawing.Size(89, 19);
			label_stacksel_title.TabIndex = 1;
			label_stacksel_title.Text = "普通飞达";
			label8.Font = new System.Drawing.Font("黑体", 12.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label8.Location = new System.Drawing.Point(4, 501);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(126, 18);
			label8.TabIndex = 0;
			label8.Text = "视觉参数调试";
			label2.BackColor = System.Drawing.Color.IndianRed;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Location = new System.Drawing.Point(1, 60);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(702, 5);
			label2.TabIndex = 4;
			button_stacksel_feeder.BackColor = System.Drawing.Color.SteelBlue;
			button_stacksel_feeder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button_stacksel_feeder.Location = new System.Drawing.Point(3, 3);
			button_stacksel_feeder.Name = "button_stacksel_feeder";
			button_stacksel_feeder.Size = new System.Drawing.Size(51, 52);
			button_stacksel_feeder.TabIndex = 3;
			button_stacksel_feeder.Text = "普通飞达";
			button_stacksel_feeder.UseVisualStyleBackColor = false;
			button9.Font = new System.Drawing.Font("楷体", 10f);
			button9.Location = new System.Drawing.Point(486, 12);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(92, 43);
			button9.TabIndex = 3;
			button9.Text = "导入\r\n从其他工程";
			button9.UseVisualStyleBackColor = true;
			button4.Font = new System.Drawing.Font("楷体", 10f);
			button4.Location = new System.Drawing.Point(380, 12);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(107, 43);
			button4.TabIndex = 3;
			button4.Text = "导入\r\n从料站库文件";
			button4.UseVisualStyleBackColor = true;
			button3.Font = new System.Drawing.Font("楷体", 10f);
			button3.Location = new System.Drawing.Point(286, 12);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(95, 43);
			button3.TabIndex = 3;
			button3.Text = "保存为\r\n本地料站库";
			button3.UseVisualStyleBackColor = true;
			button16.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button16.Location = new System.Drawing.Point(581, 12);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(71, 43);
			button16.TabIndex = 3;
			button16.Text = "分类列表";
			button16.UseVisualStyleBackColor = true;
			button2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button2.Location = new System.Drawing.Point(651, 12);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(53, 43);
			button2.TabIndex = 3;
			button2.Text = "视图";
			button2.UseVisualStyleBackColor = true;
			button22.Font = new System.Drawing.Font("楷体", 10f);
			button22.Location = new System.Drawing.Point(197, 12);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(90, 43);
			button22.TabIndex = 3;
			button22.Text = "导出\r\n料站库文件";
			button22.UseVisualStyleBackColor = true;
			button_stacksel_vibra.BackColor = System.Drawing.Color.SteelBlue;
			button_stacksel_vibra.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button_stacksel_vibra.Location = new System.Drawing.Point(117, 3);
			button_stacksel_vibra.Name = "button_stacksel_vibra";
			button_stacksel_vibra.Size = new System.Drawing.Size(51, 52);
			button_stacksel_vibra.TabIndex = 3;
			button_stacksel_vibra.Text = "振动飞达";
			button_stacksel_vibra.UseVisualStyleBackColor = false;
			button_stacksel_plate.BackColor = System.Drawing.Color.SteelBlue;
			button_stacksel_plate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button_stacksel_plate.Location = new System.Drawing.Point(60, 3);
			button_stacksel_plate.Name = "button_stacksel_plate";
			button_stacksel_plate.Size = new System.Drawing.Size(51, 52);
			button_stacksel_plate.TabIndex = 3;
			button_stacksel_plate.Text = "托盘料盘";
			button_stacksel_plate.UseVisualStyleBackColor = false;
			label30.AutoSize = true;
			label30.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label30.Location = new System.Drawing.Point(54, 4);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(76, 16);
			label30.TabIndex = 1;
			label30.Text = "供料选择";
			panel_stackselslot_vibra.Controls.Add(listBox_StackVibraAll);
			panel_stackselslot_vibra.Controls.Add(label18);
			panel_stackselslot_vibra.Controls.Add(label_Vibra);
			panel_stackselslot_vibra.Controls.Add(label12);
			panel_stackselslot_vibra.Location = new System.Drawing.Point(713, 391);
			panel_stackselslot_vibra.Name = "panel_stackselslot_vibra";
			panel_stackselslot_vibra.Size = new System.Drawing.Size(552, 66);
			panel_stackselslot_vibra.TabIndex = 5;
			listBox_StackVibraAll.ColumnWidth = 30;
			listBox_StackVibraAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			listBox_StackVibraAll.Font = new System.Drawing.Font("楷体", 15f);
			listBox_StackVibraAll.FormattingEnabled = true;
			listBox_StackVibraAll.ItemHeight = 20;
			listBox_StackVibraAll.Items.AddRange(new object[35]
			{
				"01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
				"11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
				"21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
				"31", "32", "33", "34", "35"
			});
			listBox_StackVibraAll.Location = new System.Drawing.Point(65, 1);
			listBox_StackVibraAll.MultiColumn = true;
			listBox_StackVibraAll.Name = "listBox_StackVibraAll";
			listBox_StackVibraAll.Size = new System.Drawing.Size(368, 64);
			listBox_StackVibraAll.TabIndex = 6;
			listBox_StackVibraAll.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox_StackVibraAll_MouseClick);
			listBox_StackVibraAll.DrawItem += new System.Windows.Forms.DrawItemEventHandler(listBox_StackVibraAll_DrawItem);
			label18.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label18.Location = new System.Drawing.Point(508, 8);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(52, 52);
			label18.TabIndex = 82;
			label18.Text = "➠";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_Vibra.BackColor = System.Drawing.Color.Azure;
			label_Vibra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_Vibra.Font = new System.Drawing.Font("黑体", 25.5f);
			label_Vibra.Location = new System.Drawing.Point(0, 1);
			label_Vibra.Name = "label_Vibra";
			label_Vibra.Size = new System.Drawing.Size(64, 64);
			label_Vibra.TabIndex = 6;
			label_Vibra.Text = "12";
			label_Vibra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label12.Location = new System.Drawing.Point(438, 26);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(76, 16);
			label12.TabIndex = 0;
			label12.Text = "取料坐标";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(395, 7);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(109, 19);
			label1.TabIndex = 1;
			label1.Text = "工程料站库";
			button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold);
			button_close.Location = new System.Drawing.Point(674, 0);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(32, 32);
			button_close.TabIndex = 1;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = true;
			button_close.Click += new System.EventHandler(button_close_Click);
			button_moreplates.Location = new System.Drawing.Point(726, 271);
			button_moreplates.Name = "button_moreplates";
			button_moreplates.Size = new System.Drawing.Size(119, 57);
			button_moreplates.TabIndex = 12;
			button_moreplates.Text = "更多料盘……";
			button_moreplates.UseVisualStyleBackColor = true;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(1419, 861);
			base.Controls.Add(button_moreplates);
			base.Controls.Add(panel_stackselslot_plate);
			base.Controls.Add(panel_plate_pikxy);
			base.Controls.Add(label30);
			base.Controls.Add(button_close);
			base.Controls.Add(panel_stackselslot_vibra);
			base.Controls.Add(label1);
			base.Controls.Add(tabControl1);
			base.Controls.Add(panel_stackselNew_Page);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form_LabProviders";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_feeder.ResumeLayout(false);
			panel_feeder.PerformLayout();
			panel_stackselslot_plate.ResumeLayout(false);
			panel_plate_pikxy.ResumeLayout(false);
			panel_plate_pikxy.PerformLayout();
			panel_stackselslot_feeder.ResumeLayout(false);
			panel_stackselslot_feeder.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel_stackselNew_Page.ResumeLayout(false);
			panel_stackselNew_Page.PerformLayout();
			panel_feeder_vibra_pikxy.ResumeLayout(false);
			panel10.ResumeLayout(false);
			panel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mntH_offset).EndInit();
			panel8.ResumeLayout(false);
			panel8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pikH_offset).EndInit();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel_isScanR.ResumeLayout(false);
			panel_isScanR.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_stackCollect).EndInit();
			panel_stacktool0.ResumeLayout(false);
			panel_feederdelay.ResumeLayout(false);
			panel_feederdelay.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_feederdelay).EndInit();
			panel_stackplate_autoprovider.ResumeLayout(false);
			panel_stackplate_autoprovider.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_AutoEntTimeDelay).EndInit();
			panel_stackselslot_vibra.ResumeLayout(false);
			panel_stackselslot_vibra.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_LabProviders(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			mStackLib = MainForm0.load_provider_file(".\\HWGC.provider");
			init_view();
			init_stacknew_onlyonce();
		}

		private void init_stacknew_onlyonce()
		{
			if (mStackLib.sel < ProviderType.Feedr || mStackLib.sel >= ProviderType.Num)
			{
				mStackLib.sel = ProviderType.Feedr;
			}
			button_stacksel = new Button[3] { button_stacksel_feeder, button_stacksel_plate, button_stacksel_vibra };
			for (int i = 0; i < 3; i++)
			{
				button_stacksel[i].Tag = i;
				button_stacksel[i].Click += button_stacksel_Clicked;
				button_stacksel[i].BackColor = ((i == (int)mStackLib.sel) ? Color.Firebrick : Color.DarkSlateGray);
			}
			listBox_StackVibraAll.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], listBox_StackVibraAll.Font.Size, FontStyle.Regular);
			listBox_StackPlateAll.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], listBox_StackPlateAll.Font.Size, FontStyle.Regular);
			panel_stackselNew_Page.Controls.Add(panel_stackselslot_feeder);
			panel_stackselNew_Page.Controls.Add(panel_stackselslot_plate);
			panel_stackselNew_Page.Controls.Add(panel_stackselslot_vibra);
			Point point2 = (panel_stackselslot_vibra.Location = (panel_stackselslot_plate.Location = panel_stackselslot_feeder.Location));
			panel_stackselNew_Page.Controls.Add(panel_plate_pikxy);
			panel_plate_pikxy.Location = panel_feeder_vibra_pikxy.Location;
			panel_stacktool0.Controls.Add(button_goto_pikxy_byNozzle);
			panel_stacktool0.Controls.Add(button_moreplates);
			button_moreplates.Location = button_goto_pikxy_byNozzle.Location;
			button_stackThrow.BringToFront();
			listBox_StackPlateAll.Items.Clear();
			for (int j = 0; j < HW.mStackNum[MainForm0.mFn][1]; j++)
			{
				listBox_StackPlateAll.Items.Add((StackPlateNo(j) + 1).ToString());
			}
			label_StackPlate.Text = (mStackLib.index[1] + 1).ToString();
			listBox_StackPlateAll.SelectedIndex = mStackLib.index[1];
			label_Vibra.Text = (mStackLib.index[2] + 1).ToString();
			listBox_StackVibraAll.SelectedIndex = mStackLib.index[2];
			label_Stack.Text = (mStackLib.index[0] + 1).ToString();
			checkBox_stack_nozzleEn = new CheckBox[8];
			for (int k = 0; k < 8; k++)
			{
				CheckBox checkBox = new CheckBox();
				panel_nozzleenable.Controls.Add(checkBox);
				checkBox.Location = new Point(75 + 65 * k, 0);
				checkBox.Size = new Size(63, 23);
				checkBox.Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (k + 1);
				checkBox.Tag = k;
				checkBox.CheckedChanged += checkBox_stack_nozzleEn_CheckedChanged;
				checkBox_stack_nozzleEn[k] = checkBox;
			}
			label_stack_pikH = new Label[8];
			for (int l = 0; l < 8; l++)
			{
				label_stack_pikH[l] = new Label();
			}
			label_stack_pikZnName = new Label[8];
			for (int m = 0; m < 8; m++)
			{
				label_stack_pikZnName[m] = new Label();
			}
			numericUpDown_stack_pikConfig = new NumericUpDown[3][];
			for (int n = 0; n < 3; n++)
			{
				numericUpDown_stack_pikConfig[n] = new NumericUpDown[8];
			}
			for (int num = 0; num < 3; num++)
			{
				for (int num2 = 0; num2 < 8; num2++)
				{
					numericUpDown_stack_pikConfig[num][num2] = new NumericUpDown();
				}
			}
			TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
			panel_stacknew_pik.Controls.Clear();
			panel_stacknew_pik.Controls.Add(tableLayoutPanel);
			tableLayoutPanel.Controls.Clear();
			tableLayoutPanel.RowCount = 5;
			tableLayoutPanel.ColumnCount = 9;
			tableLayoutPanel.Location = new Point(0, 0);
			tableLayoutPanel.Size = new Size(593, 129);
			for (int num3 = 0; num3 < tableLayoutPanel.RowCount; num3++)
			{
				tableLayoutPanel.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.AutoSize
				});
			}
			for (int num4 = 0; num4 < tableLayoutPanel.ColumnCount; num4++)
			{
				if (num4 == 0)
				{
					tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
				else
				{
					tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
			}
			tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel.Refresh();
			for (int num5 = 0; num5 < tableLayoutPanel.ColumnStyles.Count; num5++)
			{
				if (num5 > 0)
				{
					tableLayoutPanel.Controls.Add(label_stack_pikZnName[num5 - 1], num5, 0);
					label_stack_pikZnName[num5 - 1].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + num5;
					label_stack_pikZnName[num5 - 1].Size = new Size(55, 20);
					label_stack_pikZnName[num5 - 1].AutoSize = false;
					label_stack_pikZnName[num5 - 1].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label_stack_pikZnName[num5 - 1].Anchor = AnchorStyles.None;
					label_stack_pikZnName[num5 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_pikZnName[num5 - 1].Tag = num5 - 1;
					label_stack_pikZnName[num5 - 1].MouseClick += stack_label_MouseClick;
				}
				if (num5 == 0)
				{
					Label label = new Label();
					tableLayoutPanel.Controls.Add(label, num5, 1);
					label.Text = STR.PIK_H[USR_INIT.mLanguage];
					label.Size = new Size(65, 20);
					label.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label.Anchor = AnchorStyles.None;
					label.TextAlign = ContentAlignment.MiddleLeft;
				}
				else
				{
					tableLayoutPanel.Controls.Add(label_stack_pikH[num5 - 1], num5, 1);
					label_stack_pikH[num5 - 1].Text = "0";
					label_stack_pikH[num5 - 1].Size = new Size(55, 20);
					label_stack_pikH[num5 - 1].AutoSize = false;
					label_stack_pikH[num5 - 1].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label_stack_pikH[num5 - 1].Anchor = AnchorStyles.None;
					label_stack_pikH[num5 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_pikH[num5 - 1].Tag = num5 - 1;
					label_stack_pikH[num5 - 1].MouseClick += stack_label_MouseClick;
					label_stack_pikH[num5 - 1].BackColor = Color.White;
					label_stack_pikH[num5 - 1].BorderStyle = BorderStyle.None;
				}
				for (int num6 = 0; num6 < 3; num6++)
				{
					if (num5 == 0)
					{
						Label label2 = new Label();
						tableLayoutPanel.Controls.Add(label2, num5, num6 + 3 - 1);
						switch (num6)
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
						label2.Size = new Size(65, 20);
						label2.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
						label2.Anchor = AnchorStyles.None;
						label2.TextAlign = ContentAlignment.MiddleLeft;
						Button button = new Button();
						panel_stacknew_pik.Controls.Add(button);
						button.Tag = num6;
						button.Text = "同步";
						button.Size = new Size(75, 24);
						button.Location = new Point(tableLayoutPanel.Size.Width + 2, 26 * (num6 + 2) - 1);
						button.UseVisualStyleBackColor = true;
					}
					else
					{
						new NumericUpDown();
						numericUpDown_stack_pikConfig[num6][num5 - 1].BorderStyle = BorderStyle.None;
						numericUpDown_stack_pikConfig[num6][num5 - 1].Minimum = ((num6 == 2) ? 0 : 0);
						numericUpDown_stack_pikConfig[num6][num5 - 1].Maximum = ((num6 == 2) ? 999 : 64);
						numericUpDown_stack_pikConfig[num6][num5 - 1].Value = ((num6 == 2) ? 10 : 64);
						numericUpDown_stack_pikConfig[num6][num5 - 1].Size = new Size(50, 20);
						numericUpDown_stack_pikConfig[num6][num5 - 1].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
						numericUpDown_stack_pikConfig[num6][num5 - 1].Anchor = AnchorStyles.None;
						numericUpDown_stack_pikConfig[num6][num5 - 1].Tag = num6 * 8 + num5 - 1;
						numericUpDown_stack_pikConfig[num6][num5 - 1].Visible = true;
						numericUpDown_stack_pikConfig[num6][num5 - 1].Enabled = true;
						numericUpDown_stack_pikConfig[num6][num5 - 1].MouseClick += stack_numeric_MouseClick;
						numericUpDown_stack_pikConfig[num6][num5 - 1].ValueChanged += nud_stack_PikPara_ValueChanged;
						tableLayoutPanel.Controls.Add(numericUpDown_stack_pikConfig[num6][num5 - 1], num5, num6 + 3 - 1);
					}
				}
			}
			tableLayoutPanel.BackColor = Color.WhiteSmoke;
			tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel, true, null);
			tableLayoutPanel.SuspendLayout();
			label_stack_mntH = new Label[8];
			for (int num7 = 0; num7 < 8; num7++)
			{
				label_stack_mntH[num7] = new Label();
			}
			label_stack_mntZnName = new Label[8];
			for (int num8 = 0; num8 < 8; num8++)
			{
				label_stack_mntZnName[num8] = new Label();
			}
			numericUpDown_stack_mntConfig = new NumericUpDown[3][];
			for (int num9 = 0; num9 < 3; num9++)
			{
				numericUpDown_stack_mntConfig[num9] = new NumericUpDown[8];
			}
			for (int num10 = 0; num10 < 3; num10++)
			{
				for (int num11 = 0; num11 < 8; num11++)
				{
					numericUpDown_stack_mntConfig[num10][num11] = new NumericUpDown();
				}
			}
			TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
			panel_stacknew_mnt.Controls.Clear();
			panel_stacknew_mnt.Controls.Add(tableLayoutPanel2);
			tableLayoutPanel2.Controls.Clear();
			tableLayoutPanel2.RowCount = 5;
			tableLayoutPanel2.ColumnCount = 9;
			tableLayoutPanel2.Location = new Point(0, 0);
			tableLayoutPanel2.Size = new Size(593, 129);
			for (int num12 = 0; num12 < tableLayoutPanel2.RowCount; num12++)
			{
				tableLayoutPanel2.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.AutoSize
				});
			}
			for (int num13 = 0; num13 < tableLayoutPanel2.ColumnCount; num13++)
			{
				if (num13 == 0)
				{
					tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
				else
				{
					tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
			}
			tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel2.Refresh();
			for (int num14 = 0; num14 < tableLayoutPanel2.ColumnStyles.Count; num14++)
			{
				if (num14 > 0)
				{
					tableLayoutPanel2.Controls.Add(label_stack_mntZnName[num14 - 1], num14, 0);
					label_stack_mntZnName[num14 - 1].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + num14;
					label_stack_mntZnName[num14 - 1].Size = new Size(55, 20);
					label_stack_mntZnName[num14 - 1].AutoSize = false;
					label_stack_mntZnName[num14 - 1].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label_stack_mntZnName[num14 - 1].Anchor = AnchorStyles.None;
					label_stack_mntZnName[num14 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_mntZnName[num14 - 1].Tag = num14 - 1;
					label_stack_mntZnName[num14 - 1].MouseClick += stack_label_MouseClick;
				}
				if (num14 == 0)
				{
					Label label3 = new Label();
					tableLayoutPanel2.Controls.Add(label3, num14, 1);
					label3.Text = STR.MNT_H[USR_INIT.mLanguage];
					label3.Size = new Size(65, 20);
					label3.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label3.Anchor = AnchorStyles.None;
					label3.TextAlign = ContentAlignment.MiddleLeft;
				}
				else
				{
					tableLayoutPanel2.Controls.Add(label_stack_mntH[num14 - 1], num14, 1);
					label_stack_mntH[num14 - 1].Text = "0";
					label_stack_mntH[num14 - 1].Size = new Size(55, 20);
					label_stack_mntH[num14 - 1].AutoSize = false;
					label_stack_mntH[num14 - 1].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label_stack_mntH[num14 - 1].Anchor = AnchorStyles.None;
					label_stack_mntH[num14 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_mntH[num14 - 1].Tag = num14 - 1 + 8;
					label_stack_mntH[num14 - 1].MouseClick += stack_label_MouseClick;
					label_stack_mntH[num14 - 1].BackColor = Color.WhiteSmoke;
					label_stack_mntH[num14 - 1].BorderStyle = BorderStyle.None;
				}
				for (int num15 = 0; num15 < 3; num15++)
				{
					if (num14 == 0)
					{
						Label label4 = new Label();
						tableLayoutPanel2.Controls.Add(label4, num14, num15 + 2);
						switch (num15)
						{
						case 0:
							label4.Text = STR.DOWN_SPD[USR_INIT.mLanguage];
							break;
						case 1:
							label4.Text = STR.UP_SPD[USR_INIT.mLanguage];
							break;
						case 2:
							label4.Text = STR.MNT_DLY[USR_INIT.mLanguage];
							break;
						}
						label4.Size = new Size(65, 20);
						label4.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
						label4.Anchor = AnchorStyles.None;
						label4.TextAlign = ContentAlignment.MiddleLeft;
						Button button2 = new Button();
						panel_stacknew_mnt.Controls.Add(button2);
						button2.Tag = num15;
						button2.Text = "同步";
						button2.Size = new Size(75, 24);
						button2.Location = new Point(tableLayoutPanel2.Size.Width + 2, 26 * (num15 + 2) - 1);
						button2.UseVisualStyleBackColor = true;
					}
					else
					{
						new NumericUpDown();
						numericUpDown_stack_mntConfig[num15][num14 - 1].BorderStyle = BorderStyle.None;
						numericUpDown_stack_mntConfig[num15][num14 - 1].Minimum = ((num15 == 2) ? 0 : 0);
						numericUpDown_stack_mntConfig[num15][num14 - 1].Maximum = ((num15 == 2) ? 999 : 64);
						numericUpDown_stack_mntConfig[num15][num14 - 1].Value = ((num15 == 2) ? 10 : 64);
						numericUpDown_stack_mntConfig[num15][num14 - 1].Size = new Size(50, 20);
						numericUpDown_stack_mntConfig[num15][num14 - 1].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
						numericUpDown_stack_mntConfig[num15][num14 - 1].Anchor = AnchorStyles.None;
						numericUpDown_stack_mntConfig[num15][num14 - 1].Tag = num15 * 8 + num14 - 1 + 24;
						numericUpDown_stack_mntConfig[num15][num14 - 1].Visible = true;
						numericUpDown_stack_mntConfig[num15][num14 - 1].Enabled = true;
						numericUpDown_stack_mntConfig[num15][num14 - 1].MouseClick += stack_numeric_MouseClick;
						numericUpDown_stack_mntConfig[num15][num14 - 1].ValueChanged += nud_stack_PikPara_ValueChanged;
						tableLayoutPanel2.Controls.Add(numericUpDown_stack_mntConfig[num15][num14 - 1], num14, num15 + 2);
					}
				}
			}
			tableLayoutPanel2.BackColor = Color.WhiteSmoke;
			tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
			tableLayoutPanel2.SuspendLayout();
			numericUpDown_stack_threshold = new NumericUpDown[8];
			for (int num16 = 0; num16 < 8; num16++)
			{
				numericUpDown_stack_threshold[num16] = new NumericUpDown();
			}
			label_stack_nozzleEnName = new Label[8];
			for (int num17 = 0; num17 < 8; num17++)
			{
				label_stack_nozzleEnName[num17] = new Label();
			}
			TableLayoutPanel tableLayoutPanel3 = new TableLayoutPanel();
			panel_stacknew_visual.Controls.Clear();
			panel_stacknew_visual.Controls.Add(tableLayoutPanel3);
			tableLayoutPanel3.Controls.Clear();
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.ColumnCount = 9;
			tableLayoutPanel3.Location = new Point(0, 0);
			tableLayoutPanel3.Size = new Size(593, 51);
			for (int num18 = 0; num18 < tableLayoutPanel3.RowCount; num18++)
			{
				tableLayoutPanel3.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.AutoSize
				});
			}
			for (int num19 = 0; num19 < tableLayoutPanel3.ColumnCount; num19++)
			{
				if (num19 == 0)
				{
					tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
				else
				{
					tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
			}
			tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel3.Refresh();
			for (int num20 = 0; num20 < tableLayoutPanel3.ColumnStyles.Count; num20++)
			{
				if (num20 > 0)
				{
					tableLayoutPanel3.Controls.Add(label_stack_nozzleEnName[num20 - 1], num20, 0);
					label_stack_nozzleEnName[num20 - 1].Location = new Point(0, 0);
					label_stack_nozzleEnName[num20 - 1].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + num20;
					label_stack_nozzleEnName[num20 - 1].Size = new Size(55, 20);
					label_stack_nozzleEnName[num20 - 1].AutoSize = false;
					label_stack_nozzleEnName[num20 - 1].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label_stack_nozzleEnName[num20 - 1].Anchor = AnchorStyles.None;
					label_stack_nozzleEnName[num20 - 1].TextAlign = ContentAlignment.MiddleLeft;
					label_stack_nozzleEnName[num20 - 1].Tag = num20 - 1;
					label_stack_nozzleEnName[num20 - 1].MouseClick += stack_label_MouseClick;
				}
				if (num20 == 0)
				{
					Label label5 = new Label();
					tableLayoutPanel3.Controls.Add(label5, num20, 1);
					label5.Text = STR.THRESHOLD[USR_INIT.mLanguage];
					label5.Size = new Size(65, 20);
					label5.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label5.Anchor = AnchorStyles.None;
					label5.TextAlign = ContentAlignment.MiddleLeft;
					Button button3 = new Button();
					panel_stacknew_visual.Controls.Add(button3);
					button3.Text = "同步";
					button3.Size = new Size(75, 24);
					button3.Location = new Point(tableLayoutPanel3.Size.Width + 2, 25);
					button3.UseVisualStyleBackColor = true;
				}
				else
				{
					tableLayoutPanel3.Controls.Add(numericUpDown_stack_threshold[num20 - 1], num20, 1);
					numericUpDown_stack_threshold[num20 - 1].Value = 0m;
					numericUpDown_stack_threshold[num20 - 1].Minimum = 0m;
					numericUpDown_stack_threshold[num20 - 1].Maximum = 255m;
					numericUpDown_stack_threshold[num20 - 1].Size = new Size(55, 20);
					numericUpDown_stack_threshold[num20 - 1].AutoSize = false;
					numericUpDown_stack_threshold[num20 - 1].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					numericUpDown_stack_threshold[num20 - 1].Anchor = AnchorStyles.None;
					numericUpDown_stack_threshold[num20 - 1].Tag = num20 - 1;
					numericUpDown_stack_threshold[num20 - 1].MouseClick += stack_numeric_MouseClick;
					numericUpDown_stack_threshold[num20 - 1].ValueChanged += numericUpDown_stack_threshold_ValueChanged;
					numericUpDown_stack_threshold[num20 - 1].BackColor = Color.White;
					numericUpDown_stack_threshold[num20 - 1].BorderStyle = BorderStyle.None;
				}
			}
			tableLayoutPanel3.BackColor = Color.WhiteSmoke;
			tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);
			tableLayoutPanel3.SuspendLayout();
			stacksel_new_flushpage();
			stacksel_new_flushdata();
			stacksel_new_flushZn();
		}

		public void button_stacksel_Clicked(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			mStackLib.sel = (ProviderType)button.Tag;
			stacksel_new_flushpage();
			stacksel_new_flushdata();
			stacksel_new_flushZn();
		}

		public void stacksel_new_flushpage()
		{
			label_stacksel_title.Text = STACK_SEL_STR[(int)mStackLib.sel][USR_INIT.mLanguage];
			for (int i = 0; i < 3; i++)
			{
				button_stacksel[i].BackColor = ((i == (int)mStackLib.sel) ? Color.Firebrick : Color.DarkSlateGray);
			}
			panel_stackselslot_feeder.Visible = false;
			panel_stackselslot_vibra.Visible = false;
			panel_stackselslot_plate.Visible = false;
			if (mStackLib.sel == ProviderType.Feedr)
			{
				panel_stackselslot_feeder.Visible = true;
				panel_feeder_vibra_pikxy.Visible = true;
				panel_plate_pikxy.Visible = false;
				panel_stackplate_autoprovider.Enabled = false;
				panel_feederdelay.Enabled = true;
				button_moreplates.Visible = false;
				button_goto_pikxy_byNozzle.Visible = true;
				Button button = button_openfeeder;
				bool visible = (button_closefeeder.Visible = true);
				button.Visible = visible;
				button_stackThrow.Size = new Size(button_stackThrow.Size.Width, 57);
			}
			else if (mStackLib.sel == ProviderType.Plate)
			{
				panel_stackselslot_plate.Visible = true;
				panel_feeder_vibra_pikxy.Visible = false;
				panel_plate_pikxy.Visible = true;
				panel_stackplate_autoprovider.Enabled = true;
				panel_feederdelay.Enabled = false;
				button_moreplates.Visible = true;
				button_goto_pikxy_byNozzle.Visible = false;
				Button button2 = button_openfeeder;
				bool visible2 = (button_closefeeder.Visible = false);
				button2.Visible = visible2;
				button_stackThrow.Size = new Size(button_stackThrow.Size.Width, 29);
			}
			else if (mStackLib.sel == ProviderType.Vibra)
			{
				panel_stackselslot_vibra.Visible = true;
				panel_feeder_vibra_pikxy.Visible = true;
				panel_plate_pikxy.Visible = false;
				panel_stackplate_autoprovider.Enabled = false;
				panel_feederdelay.Enabled = true;
				button_moreplates.Visible = false;
				button_goto_pikxy_byNozzle.Visible = true;
				Button button3 = button_openfeeder;
				bool visible3 = (button_closefeeder.Visible = false);
				button3.Visible = visible3;
				button_stackThrow.Size = new Size(button_stackThrow.Size.Width, 57);
			}
		}

		public void stacksel_new_flushdata()
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			label_stacknew_chipinfo.Text = array[num].mChipValue + " " + array[num].mChipFootprint;
			label_stacknew_chipLmm.Text = array[num].lenght.ToString("F2");
			label_stacknew_chipWmm.Text = array[num].width.ToString("F2");
			label_stacknew_chipHmm.Text = array[num].height.ToString("F2");
			label_stackXY.Text = MainForm0.format_XY_label_string(array[num].mXY);
			checkBox_stackCollect.Checked = array[num].mIsCollect;
			CheckBox checkBox = checkBox_isScanR;
			bool @checked = (panel_isScanR.Visible = array[num].mIsScanR);
			checkBox.Checked = @checked;
			numericUpDown_stackCollect.Value = (decimal)array[num].mCollectDelta;
			numericUpDown_pikH_offset.Value = (decimal)array[num].pik_HmmOffset;
			numericUpDown_mntH_offset.Value = (decimal)array[num].mnt_HmmOffset;
			array[num].scanR = array[num].scanR % 921;
			label_scanR.Text = array[num].scanR.ToString();
			numericUpDown_feederdelay.Value = array[num].mFeederDelay;
			VisualType visualtype = array[num].visualtype;
			label_stack_visual.Text = STR.VISUAL_STR[(int)visualtype][USR_INIT.mLanguage];
			if (mStackLib.sel == ProviderType.Plate)
			{
				checkBox_stackplate_AutoEntComponent.Checked = array[num].mPlt.mIsAutoEnt;
				numericUpDown_AutoEntTimeDelay.Value = (decimal)array[num].mPlt.mAutoEntTimeDelay;
				button_stackplate_startIndex.Text = format_plate_startindex_str();
			}
			for (int i = 0; i < 8; i++)
			{
				checkBox_stack_nozzleEn[i].Checked = array[num].mZnData[i].mEnabled;
				label_stack_pikH[i].Text = Math.Abs(array[num].mZnData[i].Pik.Height).ToString();
				numericUpDown_stack_threshold[i].Value = Math.Abs(array[num].mZnData[i].threshold) % 256;
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
				label_stack_mntH[i].Text = Math.Abs(array[num].mZnData[i].Mnt.Height).ToString();
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
			for (int j = 0; j < 8; j++)
			{
				if (array[num].mZnData[j].mEnabled && j < HW.mZnNum[MainForm0.mFn])
				{
					MainForm0.radiobt_zn[MainForm0.mFn][j].Checked = true;
					MainForm0.msdelay(1);
					break;
				}
			}
		}

		public void stacksel_new_flushZn()
		{
			Color lightSalmon = Color.LightSalmon;
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			for (int i = 0; i < 8; i++)
			{
				if (!array[num].mZnData[i].mEnabled || i >= HW.mZnNum[MainForm0.mFn])
				{
					label_stack_nozzleEnName[i].BackColor = Color.White;
					numericUpDown_stack_threshold[i].BackColor = Color.White;
					label_stack_pikH[i].BackColor = Color.White;
					label_stack_pikZnName[i].BackColor = Color.White;
					for (int j = 0; j < 3; j++)
					{
						numericUpDown_stack_pikConfig[j][i].BackColor = Color.White;
					}
					label_stack_mntH[i].BackColor = Color.White;
					label_stack_mntZnName[i].BackColor = Color.White;
					for (int k = 0; k < 3; k++)
					{
						numericUpDown_stack_mntConfig[k][i].BackColor = Color.White;
					}
					numericUpDown_stack_threshold[i].Enabled = false;
					label_stack_pikH[i].Enabled = false;
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
					numericUpDown_stack_threshold[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_threshold[i].Font.Size, FontStyle.Regular);
					label_stack_pikH[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_pikH[i].Font.Size, FontStyle.Regular);
					label_stack_pikZnName[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_pikZnName[i].Font.Size, FontStyle.Regular);
					for (int n = 0; n < 3; n++)
					{
						numericUpDown_stack_pikConfig[n][i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_pikConfig[n][i].Font.Size, FontStyle.Regular);
					}
					label_stack_mntH[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_mntH[i].Font.Size, FontStyle.Regular);
					label_stack_mntZnName[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_mntZnName[i].Font.Size, FontStyle.Regular);
					for (int num2 = 0; num2 < 3; num2++)
					{
						numericUpDown_stack_mntConfig[num2][i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_mntConfig[num2][i].Font.Size, FontStyle.Regular);
					}
					continue;
				}
				label_stack_nozzleEnName[i].BackColor = lightSalmon;
				numericUpDown_stack_threshold[i].BackColor = lightSalmon;
				label_stack_pikH[i].BackColor = lightSalmon;
				label_stack_pikZnName[i].BackColor = lightSalmon;
				for (int num3 = 0; num3 < 3; num3++)
				{
					numericUpDown_stack_pikConfig[num3][i].BackColor = lightSalmon;
				}
				label_stack_mntH[i].BackColor = lightSalmon;
				label_stack_mntZnName[i].BackColor = lightSalmon;
				for (int num4 = 0; num4 < 3; num4++)
				{
					numericUpDown_stack_mntConfig[num4][i].BackColor = lightSalmon;
				}
				numericUpDown_stack_threshold[i].Enabled = true;
				label_stack_pikH[i].Enabled = true;
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
				if (i == MainForm0.mZn[MainForm0.mFn])
				{
					numericUpDown_stack_threshold[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_threshold[i].Font.Size, FontStyle.Bold);
					label_stack_pikH[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_pikH[i].Font.Size, FontStyle.Bold);
					label_stack_pikZnName[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_pikZnName[i].Font.Size, FontStyle.Bold);
					for (int num7 = 0; num7 < 3; num7++)
					{
						numericUpDown_stack_pikConfig[num7][i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_pikConfig[num7][i].Font.Size, FontStyle.Bold);
					}
					label_stack_mntH[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_mntH[i].Font.Size, FontStyle.Bold);
					label_stack_mntZnName[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_mntZnName[i].Font.Size, FontStyle.Bold);
					for (int num8 = 0; num8 < 3; num8++)
					{
						numericUpDown_stack_mntConfig[num8][i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_mntConfig[num8][i].Font.Size, FontStyle.Bold);
					}
				}
				else
				{
					numericUpDown_stack_threshold[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_threshold[i].Font.Size, FontStyle.Regular);
					label_stack_pikH[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_pikH[i].Font.Size, FontStyle.Regular);
					label_stack_pikZnName[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_pikZnName[i].Font.Size, FontStyle.Regular);
					for (int num9 = 0; num9 < 3; num9++)
					{
						numericUpDown_stack_pikConfig[num9][i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_pikConfig[num9][i].Font.Size, FontStyle.Regular);
					}
					label_stack_mntH[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_mntH[i].Font.Size, FontStyle.Regular);
					label_stack_mntZnName[i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], label_stack_mntZnName[i].Font.Size, FontStyle.Regular);
					for (int num10 = 0; num10 < 3; num10++)
					{
						numericUpDown_stack_mntConfig[num10][i].Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], numericUpDown_stack_mntConfig[num10][i].Font.Size, FontStyle.Regular);
					}
				}
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
				int num8 = HW.malgo2[MainForm0.mFn].len[i] - HW.malgo2[MainForm0.mFn].emp_l[i] - HW.malgo2[MainForm0.mFn].emp_r[i];
				int num9 = panel_feeder.Size.Width / num8;
				for (int j = 0; j < HW.malgo2[MainForm0.mFn].len[i]; j++)
				{
					int num10 = MainForm0.format_stackno(MainForm0.mFn, i, j);
					if (num10 >= 0 && num10 < HW.mStackNum[MainForm0.mFn][0])
					{
						Label label = new Label();
						panel1.Controls.Add(label);
						label.AutoSize = false;
						label.Size = new Size(num, num);
						label.Location = new Point(num4 + num9 * (j - HW.malgo2[MainForm0.mFn].emp_l[i]), num5);
						label.Text = (num10 + 1).ToString();
						label.BorderStyle = BorderStyle.FixedSingle;
						label.BackColor = (mStackLib.stacktab[0][num10].mEnabled ? Color.LightSkyBlue : Color.Gray);
						label.TextAlign = ContentAlignment.MiddleCenter;
						Label label2 = new Label();
						panel1.Controls.Add(label2);
						label2.AutoSize = false;
						label2.Size = new Size(num, num3);
						label2.Location = new Point(num6 + num9 * (j - HW.malgo2[MainForm0.mFn].emp_l[i]), num7);
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
			for (int k = 0; k < HW.mStackNum[MainForm0.mFn][1]; k++)
			{
				int num11 = k / (HW.mStackNum[MainForm0.mFn][1] / 2 + HW.mStackNum[MainForm0.mFn][1] % 2);
				int num12 = k % (HW.mStackNum[MainForm0.mFn][1] / 2 + HW.mStackNum[MainForm0.mFn][1] % 2);
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
			for (int l = 0; l < HW.mStackNum[MainForm0.mFn][2]; l++)
			{
				int num17 = l / (HW.mStackNum[MainForm0.mFn][2] / 2 + HW.mStackNum[MainForm0.mFn][2] % 2);
				int num18 = l % (HW.mStackNum[MainForm0.mFn][2] / 2 + HW.mStackNum[MainForm0.mFn][2] % 2);
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

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		public int StackPlateListBoxIndex(int stackNo)
		{
			return stackNo % (HW.mStackNum[MainForm0.mFn][1] / 3) * 3 + stackNo / (HW.mStackNum[MainForm0.mFn][1] / 3);
		}

		private void listBox_StackPlateAll_MouseClick(object sender, MouseEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			int selectedIndex = listBox.SelectedIndex;
			int num = StackPlateNo(selectedIndex);
			mStackLib.index[1] = num;
			label_StackPlate.Text = (mStackLib.index[1] + 1).ToString();
			stacksel_new_flushdata();
			stacksel_new_flushZn();
		}

		public int StackPlateNo(int index)
		{
			int num = index % 3;
			int num2 = index / 3;
			return num * (HW.mStackNum[MainForm0.mFn][1] / 3) + num2;
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
			label_Vibra.Text = (selectedIndex + 1).ToString();
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

		private void label_Stack_MouseHover_1(object sender, EventArgs e)
		{
			Form_LabProvider_feedersel form_LabProvider_feedersel = new Form_LabProvider_feedersel(mStackLib);
			form_LabProvider_feedersel.Location = new Point(0, 240 + HW.malgo2[MainForm0.mFn].emp_m[1] * 5);
			form_LabProvider_feedersel.TopMost = true;
			if (form_LabProvider_feedersel.ShowDialog() == DialogResult.OK)
			{
				label_Stack.Text = (mStackLib.index[0] + 1).ToString();
				stacksel_new_flushdata();
				stacksel_new_flushZn();
			}
		}

		private void stack_label_MouseClick(object sender, MouseEventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = (int)((Label)sender).Tag;
			if (num2 != -1)
			{
				num2 %= 8;
				if (num2 >= 0 && num2 < HW.mZnNum[MainForm0.mFn] && array[num].mZnData[num2].mEnabled)
				{
					MainForm0.radiobt_zn[MainForm0.mFn][num2].Checked = true;
					stacksel_new_flushZn();
				}
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
				if (num2 >= 0 && num2 < HW.mZnNum[MainForm0.mFn] && array[num].mZnData[num2].mEnabled)
				{
					MainForm0.radiobt_zn[MainForm0.mFn][num2].Checked = true;
					stacksel_new_flushZn();
				}
			}
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
			if (num6 != (int)numericUpDown.Value)
			{
				MainForm0.save_provider_file(".\\HWGC.provider", mStackLib);
			}
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
			if (threshold != (int)numericUpDown.Value)
			{
				MainForm0.save_provider_file(".\\HWGC.provider", mStackLib);
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
				MainForm0.save_provider_file(".\\HWGC.provider", mStackLib);
			}
			stacksel_new_flushZn();
		}

		private void checkBox_stackplate_AutoEntComponent_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			Dispose();
		}
	}
}
