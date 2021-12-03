using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_pcbedit_array : UserControl
	{
		private IContainer components;

		private Panel panel_CoupleArray;

		private CnButton button_DeleteAix;

		private CnButton button_pcbAix_MoveXY;

		private CnButton button_pcbAix_Run;

		private CnButton button_pcbAix_SaveXY;

		private Panel panel_coupleArrayShow;

		private Panel panel_couple_H;

		private Panel panel65;

		private Panel panel79;

		private Panel panel71;

		private Panel panel77;

		private Panel panel75;

		private Panel panel73;

		private Panel panel69;

		private Panel panel67;

		private Panel panel64;

		private Panel panel78;

		private Panel panel70;

		private Panel panel76;

		private Panel panel74;

		private Panel panel72;

		private Panel panel68;

		private Panel panel66;

		private Label label158;

		private Label label157;

		private Label label42;

		private Label label35;

		private Label label38;

		private Label label31;

		private RadioButton radioButton_couple_V;

		private RadioButton radioButton_coupleH;

		private Panel panel_couple_V;

		private Panel panel81;

		private Panel panel82;

		private Panel panel83;

		private Panel panel84;

		private Panel panel85;

		private Panel panel86;

		private Panel panel87;

		private Panel panel88;

		private Panel panel89;

		private Panel panel90;

		private Panel panel91;

		private Panel panel97;

		private Panel panel93;

		private Panel panel94;

		private Panel panel95;

		private Panel panel96;

		private CheckBox checkBox_CoupleArray;

		private Panel panel_PcbArray;

		private CnButton button_deleteArray;

		private Panel panel22;

		private Label label_pcbarray_xy3;

		private Label label_pcbarray_xy1;

		private Label label_pcbarray_xy2;

		private Label label_pcbarray_xy0;

		private Panel panel_ArrayPCB;

		private CnButton button_pcbArray_Done;

		private Panel panel9;

		private Label label111;

		private Label label110;

		private NumericUpDown nud_ArrayPCBColumn;

		private NumericUpDown nud_ArrayPCBRow;

		private CnButton button_pcbArray_MoveToXY;

		private CnButton button_pcbArray_SaveXY;

		private CnButton button_PCBE_Array_Close;

		private Label label109;

		private Panel panel1;

		private Label label1;

		private Label label2;

		private Panel panel_ismount;

		private Label label4;

		private Label label3;

		private Label label6;

		private Label label5;

		private Label label18;

		private Label label10;

		private Label label17;

		private Label label16;

		private Label label9;

		private Label label15;

		private Label label14;

		private Label label8;

		private Label label13;

		private Label label7;

		private Label label12;

		private Label label11;

		private Label label41;

		private Label label34;

		private Label label28;

		private Label label23;

		private Label label40;

		private Label label33;

		private Label label27;

		private Label label22;

		private Label label39;

		private Label label32;

		private Label label26;

		private Label label21;

		private Label label37;

		private Label label30;

		private Label label36;

		private Label label25;

		private Label label29;

		private Label label24;

		private Label label20;

		private Label label19;

		private Label label46;

		private Label label45;

		private Label label43;

		private Label label44;

		private Label label48;

		private Label label47;

		private Label label49;

		private Label label52;

		private Label label51;

		private Label label50;

		private CheckBox checkBox_selectall;

		private Panel panel_arraycheck;

		private Panel panel3;

		private Label label_arraysinglepoint;

		private ComboBox comboBox_arrayno;

		private Label label54;

		private Label label55;

		private CnButton button_GotoSinglePointXY;

		private CnButton button_arraySinglePoint_Gen;

		private CnButton button_arraynext;

		private CnButton button_arrayprev;

		private Label label56;

		private CheckBox checkBox1;

		private Panel panel2;

		private Panel panel4;

		private PictureBox pictureBox2;

		private PictureBox pictureBox1;

		private Label label57;

		private Label label53;

		private CnButton button4;

		private CnButton button2;

		private CnButton button3;

		private CnButton button1;

		public USR_DATA USR;

		public USR3_DATA USR3;

		private USR_INIT_DATA USR_INIT;

		public DataGridView dataGridView_pcbedit;

		public Label[] lb_pcbAixXY;

		public Label[] lb_pcbArrayXY;

		public BindingList<Label> lb_pcbArray;

		public BindingList<Label> lb_pcbAix;

		public int mPcbAixIndex;

		public int mPcbArrayIndex;

		public bool mIsEditEnable;

		public event void_Func_void save_usrProjectData;

		public event void_Func_XY vsplus_pcbedit_gotoxy;

		public event void_Func_int_bool PCBE_List_Show;

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
			panel_CoupleArray = new System.Windows.Forms.Panel();
			panel_coupleArrayShow = new System.Windows.Forms.Panel();
			panel_couple_H = new System.Windows.Forms.Panel();
			panel65 = new System.Windows.Forms.Panel();
			panel79 = new System.Windows.Forms.Panel();
			panel71 = new System.Windows.Forms.Panel();
			panel77 = new System.Windows.Forms.Panel();
			panel75 = new System.Windows.Forms.Panel();
			panel73 = new System.Windows.Forms.Panel();
			panel69 = new System.Windows.Forms.Panel();
			panel67 = new System.Windows.Forms.Panel();
			panel64 = new System.Windows.Forms.Panel();
			panel78 = new System.Windows.Forms.Panel();
			panel70 = new System.Windows.Forms.Panel();
			panel76 = new System.Windows.Forms.Panel();
			panel74 = new System.Windows.Forms.Panel();
			panel72 = new System.Windows.Forms.Panel();
			panel68 = new System.Windows.Forms.Panel();
			panel66 = new System.Windows.Forms.Panel();
			panel_couple_V = new System.Windows.Forms.Panel();
			panel81 = new System.Windows.Forms.Panel();
			panel82 = new System.Windows.Forms.Panel();
			panel83 = new System.Windows.Forms.Panel();
			panel84 = new System.Windows.Forms.Panel();
			panel85 = new System.Windows.Forms.Panel();
			panel86 = new System.Windows.Forms.Panel();
			panel87 = new System.Windows.Forms.Panel();
			panel88 = new System.Windows.Forms.Panel();
			panel89 = new System.Windows.Forms.Panel();
			panel90 = new System.Windows.Forms.Panel();
			panel91 = new System.Windows.Forms.Panel();
			panel97 = new System.Windows.Forms.Panel();
			panel93 = new System.Windows.Forms.Panel();
			panel94 = new System.Windows.Forms.Panel();
			panel95 = new System.Windows.Forms.Panel();
			panel96 = new System.Windows.Forms.Panel();
			button_DeleteAix = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbAix_MoveXY = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbAix_Run = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbAix_SaveXY = new QIGN_COMMON.vs_acontrol.CnButton();
			label158 = new System.Windows.Forms.Label();
			label157 = new System.Windows.Forms.Label();
			label42 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			radioButton_couple_V = new System.Windows.Forms.RadioButton();
			radioButton_coupleH = new System.Windows.Forms.RadioButton();
			checkBox_CoupleArray = new System.Windows.Forms.CheckBox();
			panel_PcbArray = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			button4 = new QIGN_COMMON.vs_acontrol.CnButton();
			button2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button3 = new QIGN_COMMON.vs_acontrol.CnButton();
			button1 = new QIGN_COMMON.vs_acontrol.CnButton();
			label57 = new System.Windows.Forms.Label();
			label53 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			panel_arraycheck = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			button_arraySinglePoint_Gen = new QIGN_COMMON.vs_acontrol.CnButton();
			button_arrayprev = new QIGN_COMMON.vs_acontrol.CnButton();
			button_arraynext = new QIGN_COMMON.vs_acontrol.CnButton();
			button_GotoSinglePointXY = new QIGN_COMMON.vs_acontrol.CnButton();
			label54 = new System.Windows.Forms.Label();
			label55 = new System.Windows.Forms.Label();
			label_arraysinglepoint = new System.Windows.Forms.Label();
			comboBox_arrayno = new System.Windows.Forms.ComboBox();
			label56 = new System.Windows.Forms.Label();
			checkBox_selectall = new System.Windows.Forms.CheckBox();
			label46 = new System.Windows.Forms.Label();
			label52 = new System.Windows.Forms.Label();
			label51 = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			label50 = new System.Windows.Forms.Label();
			label45 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			button_deleteArray = new QIGN_COMMON.vs_acontrol.CnButton();
			panel1 = new System.Windows.Forms.Panel();
			panel_ismount = new System.Windows.Forms.Panel();
			label48 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			panel22 = new System.Windows.Forms.Panel();
			label_pcbarray_xy3 = new System.Windows.Forms.Label();
			label_pcbarray_xy1 = new System.Windows.Forms.Label();
			label_pcbarray_xy2 = new System.Windows.Forms.Label();
			label_pcbarray_xy0 = new System.Windows.Forms.Label();
			panel_ArrayPCB = new System.Windows.Forms.Panel();
			label41 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label40 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			label32 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			label36 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			button_pcbArray_Done = new QIGN_COMMON.vs_acontrol.CnButton();
			panel9 = new System.Windows.Forms.Panel();
			nud_ArrayPCBColumn = new System.Windows.Forms.NumericUpDown();
			nud_ArrayPCBRow = new System.Windows.Forms.NumericUpDown();
			label111 = new System.Windows.Forms.Label();
			label110 = new System.Windows.Forms.Label();
			button_pcbArray_MoveToXY = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbArray_SaveXY = new QIGN_COMMON.vs_acontrol.CnButton();
			label49 = new System.Windows.Forms.Label();
			label43 = new System.Windows.Forms.Label();
			label44 = new System.Windows.Forms.Label();
			label109 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_PCBE_Array_Close = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_CoupleArray.SuspendLayout();
			panel_coupleArrayShow.SuspendLayout();
			panel_couple_H.SuspendLayout();
			panel65.SuspendLayout();
			panel64.SuspendLayout();
			panel_couple_V.SuspendLayout();
			panel81.SuspendLayout();
			panel89.SuspendLayout();
			panel_PcbArray.SuspendLayout();
			panel2.SuspendLayout();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel_arraycheck.SuspendLayout();
			panel3.SuspendLayout();
			panel1.SuspendLayout();
			panel_ismount.SuspendLayout();
			panel22.SuspendLayout();
			panel_ArrayPCB.SuspendLayout();
			panel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nud_ArrayPCBColumn).BeginInit();
			((System.ComponentModel.ISupportInitialize)nud_ArrayPCBRow).BeginInit();
			SuspendLayout();
			panel_CoupleArray.Controls.Add(panel_coupleArrayShow);
			panel_CoupleArray.Controls.Add(panel_couple_V);
			panel_CoupleArray.Controls.Add(button_DeleteAix);
			panel_CoupleArray.Controls.Add(button_pcbAix_MoveXY);
			panel_CoupleArray.Controls.Add(button_pcbAix_Run);
			panel_CoupleArray.Controls.Add(button_pcbAix_SaveXY);
			panel_CoupleArray.Controls.Add(label158);
			panel_CoupleArray.Controls.Add(label157);
			panel_CoupleArray.Controls.Add(label42);
			panel_CoupleArray.Controls.Add(label35);
			panel_CoupleArray.Controls.Add(label38);
			panel_CoupleArray.Controls.Add(label31);
			panel_CoupleArray.Controls.Add(radioButton_couple_V);
			panel_CoupleArray.Controls.Add(radioButton_coupleH);
			panel_CoupleArray.Location = new System.Drawing.Point(24, 46);
			panel_CoupleArray.Name = "panel_CoupleArray";
			panel_CoupleArray.Size = new System.Drawing.Size(678, 179);
			panel_CoupleArray.TabIndex = 20;
			panel_coupleArrayShow.Controls.Add(panel_couple_H);
			panel_coupleArrayShow.Location = new System.Drawing.Point(229, 31);
			panel_coupleArrayShow.Name = "panel_coupleArrayShow";
			panel_coupleArrayShow.Size = new System.Drawing.Size(172, 118);
			panel_coupleArrayShow.TabIndex = 4;
			panel_couple_H.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			panel_couple_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_couple_H.Controls.Add(panel65);
			panel_couple_H.Controls.Add(panel64);
			panel_couple_H.Location = new System.Drawing.Point(0, 13);
			panel_couple_H.Name = "panel_couple_H";
			panel_couple_H.Size = new System.Drawing.Size(172, 93);
			panel_couple_H.TabIndex = 0;
			panel65.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			panel65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel65.Controls.Add(panel79);
			panel65.Controls.Add(panel71);
			panel65.Controls.Add(panel77);
			panel65.Controls.Add(panel75);
			panel65.Controls.Add(panel73);
			panel65.Controls.Add(panel69);
			panel65.Controls.Add(panel67);
			panel65.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel65.Location = new System.Drawing.Point(92, 3);
			panel65.Name = "panel65";
			panel65.Size = new System.Drawing.Size(76, 85);
			panel65.TabIndex = 0;
			panel79.BackColor = System.Drawing.Color.Black;
			panel79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel79.Location = new System.Drawing.Point(18, 43);
			panel79.Name = "panel79";
			panel79.Size = new System.Drawing.Size(25, 25);
			panel79.TabIndex = 0;
			panel71.BackColor = System.Drawing.Color.Black;
			panel71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel71.Location = new System.Drawing.Point(42, 21);
			panel71.Name = "panel71";
			panel71.Size = new System.Drawing.Size(25, 14);
			panel71.TabIndex = 0;
			panel77.BackColor = System.Drawing.Color.Black;
			panel77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel77.Location = new System.Drawing.Point(5, 5);
			panel77.Name = "panel77";
			panel77.Size = new System.Drawing.Size(14, 14);
			panel77.TabIndex = 0;
			panel75.BackColor = System.Drawing.Color.Black;
			panel75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel75.Location = new System.Drawing.Point(35, 5);
			panel75.Name = "panel75";
			panel75.Size = new System.Drawing.Size(14, 14);
			panel75.TabIndex = 0;
			panel73.BackColor = System.Drawing.Color.Yellow;
			panel73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel73.Location = new System.Drawing.Point(53, 5);
			panel73.Name = "panel73";
			panel73.Size = new System.Drawing.Size(14, 14);
			panel73.TabIndex = 0;
			panel69.BackColor = System.Drawing.Color.Black;
			panel69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel69.Location = new System.Drawing.Point(53, 37);
			panel69.Name = "panel69";
			panel69.Size = new System.Drawing.Size(14, 14);
			panel69.TabIndex = 0;
			panel67.BackColor = System.Drawing.Color.Red;
			panel67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel67.Location = new System.Drawing.Point(53, 52);
			panel67.Name = "panel67";
			panel67.Size = new System.Drawing.Size(14, 23);
			panel67.TabIndex = 0;
			panel64.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			panel64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel64.Controls.Add(panel78);
			panel64.Controls.Add(panel70);
			panel64.Controls.Add(panel76);
			panel64.Controls.Add(panel74);
			panel64.Controls.Add(panel72);
			panel64.Controls.Add(panel68);
			panel64.Controls.Add(panel66);
			panel64.Location = new System.Drawing.Point(3, 3);
			panel64.Name = "panel64";
			panel64.Size = new System.Drawing.Size(75, 85);
			panel64.TabIndex = 0;
			panel78.BackColor = System.Drawing.Color.Black;
			panel78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel78.Location = new System.Drawing.Point(28, 16);
			panel78.Name = "panel78";
			panel78.Size = new System.Drawing.Size(25, 25);
			panel78.TabIndex = 0;
			panel70.BackColor = System.Drawing.Color.Black;
			panel70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel70.Location = new System.Drawing.Point(6, 48);
			panel70.Name = "panel70";
			panel70.Size = new System.Drawing.Size(25, 14);
			panel70.TabIndex = 0;
			panel76.BackColor = System.Drawing.Color.Black;
			panel76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel76.Location = new System.Drawing.Point(56, 64);
			panel76.Name = "panel76";
			panel76.Size = new System.Drawing.Size(14, 14);
			panel76.TabIndex = 0;
			panel74.BackColor = System.Drawing.Color.Black;
			panel74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel74.Location = new System.Drawing.Point(26, 64);
			panel74.Name = "panel74";
			panel74.Size = new System.Drawing.Size(14, 14);
			panel74.TabIndex = 0;
			panel72.BackColor = System.Drawing.Color.Yellow;
			panel72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel72.Location = new System.Drawing.Point(6, 64);
			panel72.Name = "panel72";
			panel72.Size = new System.Drawing.Size(14, 14);
			panel72.TabIndex = 0;
			panel68.BackColor = System.Drawing.Color.Black;
			panel68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel68.Location = new System.Drawing.Point(6, 32);
			panel68.Name = "panel68";
			panel68.Size = new System.Drawing.Size(14, 14);
			panel68.TabIndex = 0;
			panel66.BackColor = System.Drawing.Color.Red;
			panel66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel66.Location = new System.Drawing.Point(6, 8);
			panel66.Name = "panel66";
			panel66.Size = new System.Drawing.Size(14, 23);
			panel66.TabIndex = 0;
			panel_couple_V.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			panel_couple_V.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_couple_V.Controls.Add(panel81);
			panel_couple_V.Controls.Add(panel89);
			panel_couple_V.Location = new System.Drawing.Point(235, 31);
			panel_couple_V.Name = "panel_couple_V";
			panel_couple_V.Size = new System.Drawing.Size(159, 118);
			panel_couple_V.TabIndex = 0;
			panel_couple_V.Visible = false;
			panel81.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			panel81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel81.Controls.Add(panel82);
			panel81.Controls.Add(panel83);
			panel81.Controls.Add(panel84);
			panel81.Controls.Add(panel85);
			panel81.Controls.Add(panel86);
			panel81.Controls.Add(panel87);
			panel81.Controls.Add(panel88);
			panel81.Location = new System.Drawing.Point(3, 61);
			panel81.Name = "panel81";
			panel81.Size = new System.Drawing.Size(151, 52);
			panel81.TabIndex = 0;
			panel82.BackColor = System.Drawing.Color.Black;
			panel82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel82.Location = new System.Drawing.Point(97, 19);
			panel82.Name = "panel82";
			panel82.Size = new System.Drawing.Size(25, 25);
			panel82.TabIndex = 0;
			panel83.BackColor = System.Drawing.Color.Black;
			panel83.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel83.Location = new System.Drawing.Point(48, 30);
			panel83.Name = "panel83";
			panel83.Size = new System.Drawing.Size(25, 14);
			panel83.TabIndex = 0;
			panel84.BackColor = System.Drawing.Color.Black;
			panel84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel84.Location = new System.Drawing.Point(129, 2);
			panel84.Name = "panel84";
			panel84.Size = new System.Drawing.Size(14, 14);
			panel84.TabIndex = 0;
			panel85.BackColor = System.Drawing.Color.Black;
			panel85.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel85.Location = new System.Drawing.Point(77, 30);
			panel85.Name = "panel85";
			panel85.Size = new System.Drawing.Size(14, 14);
			panel85.TabIndex = 0;
			panel86.BackColor = System.Drawing.Color.Yellow;
			panel86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel86.Location = new System.Drawing.Point(6, 31);
			panel86.Name = "panel86";
			panel86.Size = new System.Drawing.Size(14, 14);
			panel86.TabIndex = 0;
			panel87.BackColor = System.Drawing.Color.Black;
			panel87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel87.Location = new System.Drawing.Point(26, 10);
			panel87.Name = "panel87";
			panel87.Size = new System.Drawing.Size(14, 14);
			panel87.TabIndex = 0;
			panel88.BackColor = System.Drawing.Color.Red;
			panel88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel88.Location = new System.Drawing.Point(129, 21);
			panel88.Name = "panel88";
			panel88.Size = new System.Drawing.Size(14, 23);
			panel88.TabIndex = 0;
			panel89.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
			panel89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel89.Controls.Add(panel90);
			panel89.Controls.Add(panel91);
			panel89.Controls.Add(panel97);
			panel89.Controls.Add(panel93);
			panel89.Controls.Add(panel94);
			panel89.Controls.Add(panel95);
			panel89.Controls.Add(panel96);
			panel89.Location = new System.Drawing.Point(3, 3);
			panel89.Name = "panel89";
			panel89.Size = new System.Drawing.Size(151, 55);
			panel89.TabIndex = 0;
			panel90.BackColor = System.Drawing.Color.Black;
			panel90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel90.Location = new System.Drawing.Point(26, 6);
			panel90.Name = "panel90";
			panel90.Size = new System.Drawing.Size(25, 25);
			panel90.TabIndex = 0;
			panel91.BackColor = System.Drawing.Color.Black;
			panel91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel91.Location = new System.Drawing.Point(77, 6);
			panel91.Name = "panel91";
			panel91.Size = new System.Drawing.Size(25, 14);
			panel91.TabIndex = 0;
			panel97.BackColor = System.Drawing.Color.Black;
			panel97.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel97.Location = new System.Drawing.Point(104, 26);
			panel97.Name = "panel97";
			panel97.Size = new System.Drawing.Size(14, 14);
			panel97.TabIndex = 0;
			panel93.BackColor = System.Drawing.Color.Black;
			panel93.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel93.Location = new System.Drawing.Point(57, 6);
			panel93.Name = "panel93";
			panel93.Size = new System.Drawing.Size(14, 14);
			panel93.TabIndex = 0;
			panel94.BackColor = System.Drawing.Color.Yellow;
			panel94.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel94.Location = new System.Drawing.Point(129, 6);
			panel94.Name = "panel94";
			panel94.Size = new System.Drawing.Size(14, 14);
			panel94.TabIndex = 0;
			panel95.BackColor = System.Drawing.Color.Black;
			panel95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel95.Location = new System.Drawing.Point(6, 37);
			panel95.Name = "panel95";
			panel95.Size = new System.Drawing.Size(14, 14);
			panel95.TabIndex = 0;
			panel96.BackColor = System.Drawing.Color.Red;
			panel96.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel96.Location = new System.Drawing.Point(6, 6);
			panel96.Name = "panel96";
			panel96.Size = new System.Drawing.Size(14, 23);
			panel96.TabIndex = 0;
			button_DeleteAix.BackColor = System.Drawing.Color.DarkGray;
			button_DeleteAix.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_DeleteAix.CnPressDownColor = System.Drawing.Color.White;
			button_DeleteAix.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_DeleteAix.Location = new System.Drawing.Point(480, 112);
			button_DeleteAix.Name = "button_DeleteAix";
			button_DeleteAix.Size = new System.Drawing.Size(121, 34);
			button_DeleteAix.TabIndex = 6;
			button_DeleteAix.Text = "删除鸳鸯单板";
			button_DeleteAix.UseVisualStyleBackColor = false;
			button_DeleteAix.Click += new System.EventHandler(button_DeleteAix_Click);
			button_pcbAix_MoveXY.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
			button_pcbAix_MoveXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbAix_MoveXY.CnPressDownColor = System.Drawing.Color.White;
			button_pcbAix_MoveXY.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_pcbAix_MoveXY.Location = new System.Drawing.Point(532, 30);
			button_pcbAix_MoveXY.Name = "button_pcbAix_MoveXY";
			button_pcbAix_MoveXY.Size = new System.Drawing.Size(50, 40);
			button_pcbAix_MoveXY.TabIndex = 5;
			button_pcbAix_MoveXY.Text = "定位";
			button_pcbAix_MoveXY.UseVisualStyleBackColor = false;
			button_pcbAix_MoveXY.Click += new System.EventHandler(button_pcbAix_MoveXY_Click);
			button_pcbAix_Run.BackColor = System.Drawing.Color.LightSalmon;
			button_pcbAix_Run.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbAix_Run.CnPressDownColor = System.Drawing.Color.White;
			button_pcbAix_Run.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_pcbAix_Run.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_pcbAix_Run.Location = new System.Drawing.Point(480, 74);
			button_pcbAix_Run.Name = "button_pcbAix_Run";
			button_pcbAix_Run.Size = new System.Drawing.Size(121, 36);
			button_pcbAix_Run.TabIndex = 5;
			button_pcbAix_Run.Text = "生成鸳鸯单板";
			button_pcbAix_Run.UseVisualStyleBackColor = false;
			button_pcbAix_Run.Click += new System.EventHandler(button_pcbAix_Run_Click);
			button_pcbAix_SaveXY.BackColor = System.Drawing.Color.CadetBlue;
			button_pcbAix_SaveXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbAix_SaveXY.CnPressDownColor = System.Drawing.Color.White;
			button_pcbAix_SaveXY.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_pcbAix_SaveXY.Location = new System.Drawing.Point(480, 30);
			button_pcbAix_SaveXY.Name = "button_pcbAix_SaveXY";
			button_pcbAix_SaveXY.Size = new System.Drawing.Size(50, 40);
			button_pcbAix_SaveXY.TabIndex = 5;
			button_pcbAix_SaveXY.Text = "保存";
			button_pcbAix_SaveXY.UseVisualStyleBackColor = false;
			button_pcbAix_SaveXY.Click += new System.EventHandler(button_pcbAix_SaveXY_Click);
			label158.AutoSize = true;
			label158.Font = new System.Drawing.Font("黑体", 12f);
			label158.Location = new System.Drawing.Point(5, 8);
			label158.Name = "label158";
			label158.Size = new System.Drawing.Size(232, 16);
			label158.TabIndex = 3;
			label158.Text = "第一步：设置鸳鸯板的相对位置";
			label157.AutoSize = true;
			label157.Font = new System.Drawing.Font("黑体", 12f);
			label157.Location = new System.Drawing.Point(6, 153);
			label157.Name = "label157";
			label157.Size = new System.Drawing.Size(344, 16);
			label157.TabIndex = 3;
			label157.Text = "第二步：将鸳鸯组合模块作为一个整体进行拼板";
			label42.BackColor = System.Drawing.Color.LightGray;
			label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label42.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label42.Location = new System.Drawing.Point(404, 103);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(66, 42);
			label42.TabIndex = 2;
			label42.Text = "X00000\r\nY00000";
			label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label35.BackColor = System.Drawing.Color.LightGray;
			label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label35.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label35.Location = new System.Drawing.Point(159, 102);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(66, 42);
			label35.TabIndex = 2;
			label35.Text = "X00000\r\nY00000";
			label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label38.BackColor = System.Drawing.Color.LightGray;
			label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label38.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label38.Location = new System.Drawing.Point(404, 31);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(66, 42);
			label38.TabIndex = 2;
			label38.Text = "X00000\r\nY00000";
			label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label31.BackColor = System.Drawing.Color.White;
			label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label31.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label31.Location = new System.Drawing.Point(159, 32);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(66, 42);
			label31.TabIndex = 2;
			label31.Text = "X00000\r\nY00000";
			label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			radioButton_couple_V.AutoSize = true;
			radioButton_couple_V.Font = new System.Drawing.Font("黑体", 12f);
			radioButton_couple_V.Location = new System.Drawing.Point(40, 74);
			radioButton_couple_V.Name = "radioButton_couple_V";
			radioButton_couple_V.Size = new System.Drawing.Size(74, 20);
			radioButton_couple_V.TabIndex = 1;
			radioButton_couple_V.Text = "竖鸳鸯";
			radioButton_couple_V.UseVisualStyleBackColor = true;
			radioButton_couple_V.CheckedChanged += new System.EventHandler(radioButton_couple_V_CheckedChanged);
			radioButton_coupleH.AutoSize = true;
			radioButton_coupleH.Checked = true;
			radioButton_coupleH.Font = new System.Drawing.Font("黑体", 12f);
			radioButton_coupleH.Location = new System.Drawing.Point(40, 44);
			radioButton_coupleH.Name = "radioButton_coupleH";
			radioButton_coupleH.Size = new System.Drawing.Size(74, 20);
			radioButton_coupleH.TabIndex = 1;
			radioButton_coupleH.TabStop = true;
			radioButton_coupleH.Text = "横鸳鸯";
			radioButton_coupleH.UseVisualStyleBackColor = true;
			radioButton_coupleH.CheckedChanged += new System.EventHandler(radioButton_coupleH_CheckedChanged);
			checkBox_CoupleArray.AutoSize = true;
			checkBox_CoupleArray.Font = new System.Drawing.Font("黑体", 12f);
			checkBox_CoupleArray.Location = new System.Drawing.Point(24, 26);
			checkBox_CoupleArray.Name = "checkBox_CoupleArray";
			checkBox_CoupleArray.Size = new System.Drawing.Size(75, 20);
			checkBox_CoupleArray.TabIndex = 19;
			checkBox_CoupleArray.Text = "鸳鸯板";
			checkBox_CoupleArray.UseVisualStyleBackColor = true;
			checkBox_CoupleArray.CheckedChanged += new System.EventHandler(checkBox_CoupleArray_CheckedChanged);
			panel_PcbArray.Controls.Add(panel2);
			panel_PcbArray.Controls.Add(panel_arraycheck);
			panel_PcbArray.Controls.Add(checkBox_selectall);
			panel_PcbArray.Controls.Add(label46);
			panel_PcbArray.Controls.Add(label52);
			panel_PcbArray.Controls.Add(label51);
			panel_PcbArray.Controls.Add(label47);
			panel_PcbArray.Controls.Add(label50);
			panel_PcbArray.Controls.Add(label45);
			panel_PcbArray.Controls.Add(label1);
			panel_PcbArray.Controls.Add(button_deleteArray);
			panel_PcbArray.Controls.Add(panel1);
			panel_PcbArray.Controls.Add(panel22);
			panel_PcbArray.Controls.Add(button_pcbArray_Done);
			panel_PcbArray.Controls.Add(panel9);
			panel_PcbArray.Controls.Add(button_pcbArray_MoveToXY);
			panel_PcbArray.Controls.Add(button_pcbArray_SaveXY);
			panel_PcbArray.Controls.Add(label49);
			panel_PcbArray.Controls.Add(label43);
			panel_PcbArray.Controls.Add(label44);
			panel_PcbArray.Location = new System.Drawing.Point(23, 217);
			panel_PcbArray.Name = "panel_PcbArray";
			panel_PcbArray.Size = new System.Drawing.Size(679, 552);
			panel_PcbArray.TabIndex = 18;
			panel2.BackColor = System.Drawing.Color.White;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(checkBox1);
			panel2.Enabled = false;
			panel2.Location = new System.Drawing.Point(15, 124);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(617, 115);
			panel2.TabIndex = 27;
			panel2.Visible = false;
			panel4.Controls.Add(button4);
			panel4.Controls.Add(button2);
			panel4.Controls.Add(button3);
			panel4.Controls.Add(button1);
			panel4.Controls.Add(label57);
			panel4.Controls.Add(label53);
			panel4.Controls.Add(pictureBox2);
			panel4.Controls.Add(pictureBox1);
			panel4.Enabled = false;
			panel4.Location = new System.Drawing.Point(141, 2);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(471, 108);
			panel4.TabIndex = 20;
			button4.BackColor = System.Drawing.Color.LightGray;
			button4.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button4.CnPressDownColor = System.Drawing.Color.White;
			button4.Location = new System.Drawing.Point(295, 76);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(65, 30);
			button4.TabIndex = 2;
			button4.Text = "定位";
			button4.UseVisualStyleBackColor = false;
			button2.BackColor = System.Drawing.Color.LightGray;
			button2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button2.CnPressDownColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(110, 76);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(65, 30);
			button2.TabIndex = 2;
			button2.Text = "定位";
			button2.UseVisualStyleBackColor = false;
			button3.BackColor = System.Drawing.Color.LightGray;
			button3.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button3.CnPressDownColor = System.Drawing.Color.White;
			button3.Location = new System.Drawing.Point(295, 45);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(65, 30);
			button3.TabIndex = 2;
			button3.Text = "保存";
			button3.UseVisualStyleBackColor = false;
			button1.BackColor = System.Drawing.Color.LightGray;
			button1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button1.CnPressDownColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(110, 45);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(65, 30);
			button1.TabIndex = 2;
			button1.Text = "保存";
			button1.UseVisualStyleBackColor = false;
			label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label57.Location = new System.Drawing.Point(296, 0);
			label57.Name = "label57";
			label57.Size = new System.Drawing.Size(65, 42);
			label57.TabIndex = 1;
			label57.Text = "X11111\r\nY22222";
			label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label53.Location = new System.Drawing.Point(110, 0);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(65, 42);
			label53.TabIndex = 1;
			label53.Text = "X11111\r\nY22222";
			label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			pictureBox2.BackColor = System.Drawing.Color.DarkGray;
			pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox2.Location = new System.Drawing.Point(363, 0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(108, 108);
			pictureBox2.TabIndex = 0;
			pictureBox2.TabStop = false;
			pictureBox1.BackColor = System.Drawing.Color.DarkGray;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(108, 108);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			checkBox1.AutoSize = true;
			checkBox1.Font = new System.Drawing.Font("黑体", 11.5f);
			checkBox1.Location = new System.Drawing.Point(5, 45);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(91, 20);
			checkBox1.TabIndex = 19;
			checkBox1.Text = "单板MARK";
			checkBox1.UseVisualStyleBackColor = true;
			panel_arraycheck.BackColor = System.Drawing.Color.White;
			panel_arraycheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_arraycheck.Controls.Add(panel3);
			panel_arraycheck.Controls.Add(label56);
			panel_arraycheck.Font = new System.Drawing.Font("黑体", 10.5f);
			panel_arraycheck.Location = new System.Drawing.Point(15, 243);
			panel_arraycheck.Name = "panel_arraycheck";
			panel_arraycheck.Size = new System.Drawing.Size(617, 92);
			panel_arraycheck.TabIndex = 26;
			panel3.Controls.Add(button_arraySinglePoint_Gen);
			panel3.Controls.Add(button_arrayprev);
			panel3.Controls.Add(button_arraynext);
			panel3.Controls.Add(button_GotoSinglePointXY);
			panel3.Controls.Add(label54);
			panel3.Controls.Add(label55);
			panel3.Controls.Add(label_arraysinglepoint);
			panel3.Controls.Add(comboBox_arrayno);
			panel3.Location = new System.Drawing.Point(141, -7);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(471, 98);
			panel3.TabIndex = 18;
			button_arraySinglePoint_Gen.BackColor = System.Drawing.Color.LightGray;
			button_arraySinglePoint_Gen.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_arraySinglePoint_Gen.CnPressDownColor = System.Drawing.Color.White;
			button_arraySinglePoint_Gen.Location = new System.Drawing.Point(315, 33);
			button_arraySinglePoint_Gen.Name = "button_arraySinglePoint_Gen";
			button_arraySinglePoint_Gen.Size = new System.Drawing.Size(150, 54);
			button_arraySinglePoint_Gen.TabIndex = 2;
			button_arraySinglePoint_Gen.Text = "保存确认=>校准坐标";
			button_arraySinglePoint_Gen.UseVisualStyleBackColor = false;
			button_arraySinglePoint_Gen.Click += new System.EventHandler(button_arraySinglePoint_Gen_Click);
			button_arrayprev.BackColor = System.Drawing.Color.LightGray;
			button_arrayprev.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_arrayprev.CnPressDownColor = System.Drawing.Color.White;
			button_arrayprev.Location = new System.Drawing.Point(18, 61);
			button_arrayprev.Name = "button_arrayprev";
			button_arrayprev.Size = new System.Drawing.Size(61, 28);
			button_arrayprev.TabIndex = 2;
			button_arrayprev.Tag = "prev";
			button_arrayprev.Text = "上一个";
			button_arrayprev.UseVisualStyleBackColor = false;
			button_arrayprev.Click += new System.EventHandler(button_arrayprev_Click);
			button_arraynext.BackColor = System.Drawing.Color.LightGray;
			button_arraynext.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_arraynext.CnPressDownColor = System.Drawing.Color.White;
			button_arraynext.Location = new System.Drawing.Point(86, 61);
			button_arraynext.Name = "button_arraynext";
			button_arraynext.Size = new System.Drawing.Size(61, 28);
			button_arraynext.TabIndex = 2;
			button_arraynext.Tag = "next";
			button_arraynext.Text = "下一个";
			button_arraynext.UseVisualStyleBackColor = false;
			button_arraynext.Click += new System.EventHandler(button_arrayprev_Click);
			button_GotoSinglePointXY.BackColor = System.Drawing.Color.LightGray;
			button_GotoSinglePointXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_GotoSinglePointXY.CnPressDownColor = System.Drawing.Color.White;
			button_GotoSinglePointXY.Location = new System.Drawing.Point(231, 33);
			button_GotoSinglePointXY.Name = "button_GotoSinglePointXY";
			button_GotoSinglePointXY.Size = new System.Drawing.Size(69, 54);
			button_GotoSinglePointXY.TabIndex = 2;
			button_GotoSinglePointXY.Text = "定位";
			button_GotoSinglePointXY.UseVisualStyleBackColor = false;
			button_GotoSinglePointXY.Click += new System.EventHandler(button_GotoSinglePointXY_Click);
			label54.AutoSize = true;
			label54.Font = new System.Drawing.Font("黑体", 11.5f);
			label54.Location = new System.Drawing.Point(55, 10);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(56, 16);
			label54.TabIndex = 1;
			label54.Text = "拼板号";
			label55.AutoSize = true;
			label55.Font = new System.Drawing.Font("黑体", 11.5f);
			label55.Location = new System.Drawing.Point(195, 10);
			label55.Name = "label55";
			label55.Size = new System.Drawing.Size(88, 16);
			label55.TabIndex = 1;
			label55.Text = "标记点坐标";
			label_arraysinglepoint.BackColor = System.Drawing.Color.White;
			label_arraysinglepoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_arraysinglepoint.Font = new System.Drawing.Font("黑体", 11.5f);
			label_arraysinglepoint.Location = new System.Drawing.Point(160, 33);
			label_arraysinglepoint.Name = "label_arraysinglepoint";
			label_arraysinglepoint.Size = new System.Drawing.Size(66, 54);
			label_arraysinglepoint.TabIndex = 1;
			label_arraysinglepoint.Text = "X00000\r\nY00000";
			label_arraysinglepoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			comboBox_arrayno.Font = new System.Drawing.Font("黑体", 12.5f);
			comboBox_arrayno.FormattingEnabled = true;
			comboBox_arrayno.Location = new System.Drawing.Point(18, 33);
			comboBox_arrayno.Name = "comboBox_arrayno";
			comboBox_arrayno.Size = new System.Drawing.Size(128, 25);
			comboBox_arrayno.TabIndex = 0;
			comboBox_arrayno.SelectedIndexChanged += new System.EventHandler(comboBox_arrayno_SelectedIndexChanged);
			label56.AutoSize = true;
			label56.Font = new System.Drawing.Font("黑体", 11.5f);
			label56.Location = new System.Drawing.Point(17, 34);
			label56.Name = "label56";
			label56.Size = new System.Drawing.Size(104, 16);
			label56.TabIndex = 1;
			label56.Text = "单板精准校对";
			checkBox_selectall.AutoSize = true;
			checkBox_selectall.Location = new System.Drawing.Point(608, 342);
			checkBox_selectall.Name = "checkBox_selectall";
			checkBox_selectall.Size = new System.Drawing.Size(54, 18);
			checkBox_selectall.TabIndex = 25;
			checkBox_selectall.Text = "全选";
			checkBox_selectall.UseVisualStyleBackColor = true;
			checkBox_selectall.CheckedChanged += new System.EventHandler(checkBox_selectall_CheckedChanged);
			label46.AutoSize = true;
			label46.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label46.Location = new System.Drawing.Point(334, 343);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(63, 15);
			label46.TabIndex = 3;
			label46.Text = "-不贴装";
			label52.BackColor = System.Drawing.Color.Yellow;
			label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label52.Location = new System.Drawing.Point(500, 338);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(40, 22);
			label52.TabIndex = 0;
			label52.Text = "*1-1";
			label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label51.AutoSize = true;
			label51.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label51.Location = new System.Drawing.Point(539, 343);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(63, 15);
			label51.TabIndex = 3;
			label51.Text = "-鸳鸯板";
			label47.BackColor = System.Drawing.Color.SpringGreen;
			label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label47.Location = new System.Drawing.Point(409, 338);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(40, 22);
			label47.TabIndex = 0;
			label47.Text = "1-1";
			label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label50.AutoSize = true;
			label50.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label50.Location = new System.Drawing.Point(448, 343);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(47, 15);
			label50.TabIndex = 3;
			label50.Text = "-原板";
			label45.AutoSize = true;
			label45.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label45.Location = new System.Drawing.Point(259, 343);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(47, 15);
			label45.TabIndex = 3;
			label45.Text = "-贴装";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(7, 342);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(199, 15);
			label1.TabIndex = 16;
			label1.Text = "拼板是否贴装（单击修改）";
			button_deleteArray.BackColor = System.Drawing.Color.DarkGray;
			button_deleteArray.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_deleteArray.CnPressDownColor = System.Drawing.Color.White;
			button_deleteArray.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_deleteArray.Location = new System.Drawing.Point(546, 93);
			button_deleteArray.Name = "button_deleteArray";
			button_deleteArray.Size = new System.Drawing.Size(104, 30);
			button_deleteArray.TabIndex = 13;
			button_deleteArray.Text = "删除拼板";
			button_deleteArray.UseVisualStyleBackColor = false;
			button_deleteArray.Click += new System.EventHandler(button_deleteArray_Click);
			panel1.AutoScroll = true;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Controls.Add(panel_ismount);
			panel1.Location = new System.Drawing.Point(8, 366);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(637, 169);
			panel1.TabIndex = 22;
			panel_ismount.Controls.Add(label48);
			panel_ismount.Controls.Add(label18);
			panel_ismount.Controls.Add(label10);
			panel_ismount.Controls.Add(label17);
			panel_ismount.Controls.Add(label6);
			panel_ismount.Controls.Add(label16);
			panel_ismount.Controls.Add(label9);
			panel_ismount.Controls.Add(label15);
			panel_ismount.Controls.Add(label4);
			panel_ismount.Controls.Add(label14);
			panel_ismount.Controls.Add(label8);
			panel_ismount.Controls.Add(label13);
			panel_ismount.Controls.Add(label7);
			panel_ismount.Controls.Add(label12);
			panel_ismount.Controls.Add(label5);
			panel_ismount.Controls.Add(label11);
			panel_ismount.Controls.Add(label3);
			panel_ismount.Location = new System.Drawing.Point(5, 5);
			panel_ismount.Name = "panel_ismount";
			panel_ismount.Size = new System.Drawing.Size(622, 155);
			panel_ismount.TabIndex = 0;
			label48.BackColor = System.Drawing.Color.Yellow;
			label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label48.Location = new System.Drawing.Point(301, 71);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(57, 22);
			label48.TabIndex = 0;
			label48.Text = "*10-10";
			label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label18.BackColor = System.Drawing.Color.SpringGreen;
			label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label18.Location = new System.Drawing.Point(187, 80);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(57, 22);
			label18.TabIndex = 0;
			label18.Text = "10-10";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label10.BackColor = System.Drawing.Color.SpringGreen;
			label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label10.Location = new System.Drawing.Point(66, 80);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(57, 22);
			label10.TabIndex = 0;
			label10.Text = "10-10";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label17.BackColor = System.Drawing.Color.SpringGreen;
			label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label17.Location = new System.Drawing.Point(187, 30);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(57, 22);
			label17.TabIndex = 0;
			label17.Text = "10-10";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.BackColor = System.Drawing.Color.SpringGreen;
			label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label6.Location = new System.Drawing.Point(66, 30);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(57, 22);
			label6.TabIndex = 0;
			label6.Text = "10-10";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label16.BackColor = System.Drawing.Color.SpringGreen;
			label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label16.Location = new System.Drawing.Point(187, 55);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(57, 22);
			label16.TabIndex = 0;
			label16.Text = "10-10";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label9.BackColor = System.Drawing.Color.SpringGreen;
			label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label9.Location = new System.Drawing.Point(66, 55);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(57, 22);
			label9.TabIndex = 0;
			label9.Text = "10-10";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label15.BackColor = System.Drawing.Color.SpringGreen;
			label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label15.Location = new System.Drawing.Point(187, 5);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(57, 22);
			label15.TabIndex = 0;
			label15.Text = "10-10";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.BackColor = System.Drawing.Color.SpringGreen;
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Location = new System.Drawing.Point(66, 5);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(57, 22);
			label4.TabIndex = 0;
			label4.Text = "10-10";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label14.BackColor = System.Drawing.Color.SpringGreen;
			label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label14.Location = new System.Drawing.Point(126, 80);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(57, 22);
			label14.TabIndex = 0;
			label14.Text = "10-10";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.BackColor = System.Drawing.Color.SpringGreen;
			label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label8.Location = new System.Drawing.Point(5, 80);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(57, 22);
			label8.TabIndex = 0;
			label8.Text = "10-10";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label13.BackColor = System.Drawing.Color.SpringGreen;
			label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label13.Location = new System.Drawing.Point(126, 55);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(57, 22);
			label13.TabIndex = 0;
			label13.Text = "10-10";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label7.BackColor = System.Drawing.Color.SpringGreen;
			label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label7.Location = new System.Drawing.Point(5, 55);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(57, 22);
			label7.TabIndex = 0;
			label7.Text = "10-10";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label12.BackColor = System.Drawing.Color.Gray;
			label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label12.Location = new System.Drawing.Point(126, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(57, 22);
			label12.TabIndex = 0;
			label12.Text = "10-10";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label5.BackColor = System.Drawing.Color.SpringGreen;
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Location = new System.Drawing.Point(5, 30);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(57, 22);
			label5.TabIndex = 0;
			label5.Text = "10-10";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label11.BackColor = System.Drawing.Color.SpringGreen;
			label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label11.Location = new System.Drawing.Point(126, 5);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(57, 22);
			label11.TabIndex = 0;
			label11.Text = "10-10";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.BackColor = System.Drawing.Color.SpringGreen;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.Location = new System.Drawing.Point(5, 5);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(57, 22);
			label3.TabIndex = 0;
			label3.Text = "10-10";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel22.BackColor = System.Drawing.Color.NavajoWhite;
			panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel22.Controls.Add(label_pcbarray_xy3);
			panel22.Controls.Add(label_pcbarray_xy1);
			panel22.Controls.Add(label_pcbarray_xy2);
			panel22.Controls.Add(label_pcbarray_xy0);
			panel22.Controls.Add(panel_ArrayPCB);
			panel22.Location = new System.Drawing.Point(135, 7);
			panel22.Name = "panel22";
			panel22.Size = new System.Drawing.Size(405, 115);
			panel22.TabIndex = 12;
			label_pcbarray_xy3.BackColor = System.Drawing.Color.LightGray;
			label_pcbarray_xy3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_pcbarray_xy3.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_pcbarray_xy3.Location = new System.Drawing.Point(331, 64);
			label_pcbarray_xy3.Name = "label_pcbarray_xy3";
			label_pcbarray_xy3.Size = new System.Drawing.Size(66, 42);
			label_pcbarray_xy3.TabIndex = 8;
			label_pcbarray_xy3.Text = "X00000\r\nY00000";
			label_pcbarray_xy3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_pcbarray_xy1.BackColor = System.Drawing.Color.LightGray;
			label_pcbarray_xy1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_pcbarray_xy1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_pcbarray_xy1.Location = new System.Drawing.Point(331, 7);
			label_pcbarray_xy1.Name = "label_pcbarray_xy1";
			label_pcbarray_xy1.Size = new System.Drawing.Size(66, 42);
			label_pcbarray_xy1.TabIndex = 7;
			label_pcbarray_xy1.Text = "X00000\r\nY00000";
			label_pcbarray_xy1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_pcbarray_xy2.BackColor = System.Drawing.Color.Gainsboro;
			label_pcbarray_xy2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_pcbarray_xy2.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_pcbarray_xy2.Location = new System.Drawing.Point(4, 64);
			label_pcbarray_xy2.Name = "label_pcbarray_xy2";
			label_pcbarray_xy2.Size = new System.Drawing.Size(66, 42);
			label_pcbarray_xy2.TabIndex = 6;
			label_pcbarray_xy2.Text = "X00000\r\nY00000";
			label_pcbarray_xy2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_pcbarray_xy0.BackColor = System.Drawing.Color.White;
			label_pcbarray_xy0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_pcbarray_xy0.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_pcbarray_xy0.Location = new System.Drawing.Point(4, 7);
			label_pcbarray_xy0.Name = "label_pcbarray_xy0";
			label_pcbarray_xy0.Size = new System.Drawing.Size(66, 42);
			label_pcbarray_xy0.TabIndex = 5;
			label_pcbarray_xy0.Text = "X00000\r\nY00000";
			label_pcbarray_xy0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_ArrayPCB.BackColor = System.Drawing.Color.Transparent;
			panel_ArrayPCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_ArrayPCB.Controls.Add(label41);
			panel_ArrayPCB.Controls.Add(label34);
			panel_ArrayPCB.Controls.Add(label28);
			panel_ArrayPCB.Controls.Add(label23);
			panel_ArrayPCB.Controls.Add(label40);
			panel_ArrayPCB.Controls.Add(label33);
			panel_ArrayPCB.Controls.Add(label27);
			panel_ArrayPCB.Controls.Add(label22);
			panel_ArrayPCB.Controls.Add(label39);
			panel_ArrayPCB.Controls.Add(label32);
			panel_ArrayPCB.Controls.Add(label26);
			panel_ArrayPCB.Controls.Add(label21);
			panel_ArrayPCB.Controls.Add(label37);
			panel_ArrayPCB.Controls.Add(label30);
			panel_ArrayPCB.Controls.Add(label36);
			panel_ArrayPCB.Controls.Add(label25);
			panel_ArrayPCB.Controls.Add(label29);
			panel_ArrayPCB.Controls.Add(label24);
			panel_ArrayPCB.Controls.Add(label20);
			panel_ArrayPCB.Controls.Add(label19);
			panel_ArrayPCB.Location = new System.Drawing.Point(74, 7);
			panel_ArrayPCB.Name = "panel_ArrayPCB";
			panel_ArrayPCB.Size = new System.Drawing.Size(254, 99);
			panel_ArrayPCB.TabIndex = 0;
			label41.BackColor = System.Drawing.Color.WhiteSmoke;
			label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label41.Location = new System.Drawing.Point(200, 73);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(45, 20);
			label41.TabIndex = 0;
			label41.Text = "PCB";
			label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label34.BackColor = System.Drawing.Color.WhiteSmoke;
			label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label34.Location = new System.Drawing.Point(200, 50);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(45, 20);
			label34.TabIndex = 0;
			label34.Text = "PCB";
			label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.BackColor = System.Drawing.Color.WhiteSmoke;
			label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label28.Location = new System.Drawing.Point(200, 27);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(45, 20);
			label28.TabIndex = 0;
			label28.Text = "PCB";
			label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label23.BackColor = System.Drawing.Color.WhiteSmoke;
			label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label23.Location = new System.Drawing.Point(200, 4);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(45, 20);
			label23.TabIndex = 0;
			label23.Text = "PCB";
			label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label40.BackColor = System.Drawing.Color.WhiteSmoke;
			label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label40.Location = new System.Drawing.Point(152, 73);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(45, 20);
			label40.TabIndex = 0;
			label40.Text = "PCB";
			label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label33.BackColor = System.Drawing.Color.WhiteSmoke;
			label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label33.Location = new System.Drawing.Point(152, 50);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(45, 20);
			label33.TabIndex = 0;
			label33.Text = "PCB";
			label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label27.BackColor = System.Drawing.Color.WhiteSmoke;
			label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label27.Location = new System.Drawing.Point(152, 27);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(45, 20);
			label27.TabIndex = 0;
			label27.Text = "PCB";
			label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label22.BackColor = System.Drawing.Color.WhiteSmoke;
			label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label22.Location = new System.Drawing.Point(152, 4);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(45, 20);
			label22.TabIndex = 0;
			label22.Text = "PCB";
			label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label39.BackColor = System.Drawing.Color.WhiteSmoke;
			label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label39.Location = new System.Drawing.Point(104, 73);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(45, 20);
			label39.TabIndex = 0;
			label39.Text = "PCB";
			label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label32.BackColor = System.Drawing.Color.WhiteSmoke;
			label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label32.Location = new System.Drawing.Point(104, 50);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(45, 20);
			label32.TabIndex = 0;
			label32.Text = "PCB";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.BackColor = System.Drawing.Color.WhiteSmoke;
			label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label26.Location = new System.Drawing.Point(104, 27);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(45, 20);
			label26.TabIndex = 0;
			label26.Text = "PCB";
			label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label21.BackColor = System.Drawing.Color.WhiteSmoke;
			label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label21.Location = new System.Drawing.Point(104, 4);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(45, 20);
			label21.TabIndex = 0;
			label21.Text = "PCB";
			label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label37.BackColor = System.Drawing.Color.WhiteSmoke;
			label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label37.Location = new System.Drawing.Point(56, 73);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(45, 20);
			label37.TabIndex = 0;
			label37.Text = "PCB";
			label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label30.BackColor = System.Drawing.Color.WhiteSmoke;
			label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label30.Location = new System.Drawing.Point(56, 50);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(45, 20);
			label30.TabIndex = 0;
			label30.Text = "PCB";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label36.BackColor = System.Drawing.Color.WhiteSmoke;
			label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label36.Location = new System.Drawing.Point(8, 73);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(45, 20);
			label36.TabIndex = 0;
			label36.Text = "PCB";
			label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.BackColor = System.Drawing.Color.WhiteSmoke;
			label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label25.Location = new System.Drawing.Point(56, 27);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(45, 20);
			label25.TabIndex = 0;
			label25.Text = "PCB";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label29.BackColor = System.Drawing.Color.WhiteSmoke;
			label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label29.Location = new System.Drawing.Point(8, 50);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(45, 20);
			label29.TabIndex = 0;
			label29.Text = "PCB";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label24.BackColor = System.Drawing.Color.WhiteSmoke;
			label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label24.Location = new System.Drawing.Point(8, 27);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(45, 20);
			label24.TabIndex = 0;
			label24.Text = "PCB";
			label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label20.BackColor = System.Drawing.Color.WhiteSmoke;
			label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label20.Location = new System.Drawing.Point(56, 4);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(45, 20);
			label20.TabIndex = 0;
			label20.Text = "PCB";
			label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label19.BackColor = System.Drawing.Color.WhiteSmoke;
			label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label19.Location = new System.Drawing.Point(8, 4);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(45, 20);
			label19.TabIndex = 0;
			label19.Text = "PCB";
			label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_pcbArray_Done.BackColor = System.Drawing.Color.LightSalmon;
			button_pcbArray_Done.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbArray_Done.CnPressDownColor = System.Drawing.Color.White;
			button_pcbArray_Done.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_pcbArray_Done.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_pcbArray_Done.Location = new System.Drawing.Point(546, 54);
			button_pcbArray_Done.Name = "button_pcbArray_Done";
			button_pcbArray_Done.Size = new System.Drawing.Size(104, 36);
			button_pcbArray_Done.TabIndex = 10;
			button_pcbArray_Done.Text = "开始拼板";
			button_pcbArray_Done.UseVisualStyleBackColor = false;
			button_pcbArray_Done.Click += new System.EventHandler(button_pcbArray_Done_Click);
			panel9.Controls.Add(nud_ArrayPCBColumn);
			panel9.Controls.Add(nud_ArrayPCBRow);
			panel9.Controls.Add(label111);
			panel9.Controls.Add(label110);
			panel9.Location = new System.Drawing.Point(7, 14);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(127, 91);
			panel9.TabIndex = 9;
			nud_ArrayPCBColumn.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			nud_ArrayPCBColumn.Location = new System.Drawing.Point(70, 18);
			nud_ArrayPCBColumn.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_ArrayPCBColumn.Name = "nud_ArrayPCBColumn";
			nud_ArrayPCBColumn.Size = new System.Drawing.Size(44, 25);
			nud_ArrayPCBColumn.TabIndex = 2;
			nud_ArrayPCBColumn.Tag = "column";
			nud_ArrayPCBColumn.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_ArrayPCBColumn.ValueChanged += new System.EventHandler(nud_ArrayPCB_ValueChanged);
			nud_ArrayPCBRow.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			nud_ArrayPCBRow.Location = new System.Drawing.Point(70, 58);
			nud_ArrayPCBRow.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_ArrayPCBRow.Name = "nud_ArrayPCBRow";
			nud_ArrayPCBRow.Size = new System.Drawing.Size(44, 25);
			nud_ArrayPCBRow.TabIndex = 2;
			nud_ArrayPCBRow.Tag = "row";
			nud_ArrayPCBRow.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_ArrayPCBRow.ValueChanged += new System.EventHandler(nud_ArrayPCB_ValueChanged);
			label111.Font = new System.Drawing.Font("黑体", 11.25f);
			label111.Location = new System.Drawing.Point(5, 21);
			label111.Name = "label111";
			label111.Size = new System.Drawing.Size(65, 20);
			label111.TabIndex = 3;
			label111.Text = "列数";
			label111.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label110.Font = new System.Drawing.Font("黑体", 11.25f);
			label110.Location = new System.Drawing.Point(5, 61);
			label110.Name = "label110";
			label110.Size = new System.Drawing.Size(65, 20);
			label110.TabIndex = 3;
			label110.Text = "行数";
			label110.TextAlign = System.Drawing.ContentAlignment.TopRight;
			button_pcbArray_MoveToXY.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
			button_pcbArray_MoveToXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbArray_MoveToXY.CnPressDownColor = System.Drawing.Color.White;
			button_pcbArray_MoveToXY.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_pcbArray_MoveToXY.Location = new System.Drawing.Point(598, 10);
			button_pcbArray_MoveToXY.Name = "button_pcbArray_MoveToXY";
			button_pcbArray_MoveToXY.Size = new System.Drawing.Size(50, 40);
			button_pcbArray_MoveToXY.TabIndex = 4;
			button_pcbArray_MoveToXY.Text = "定位";
			button_pcbArray_MoveToXY.UseVisualStyleBackColor = false;
			button_pcbArray_MoveToXY.Click += new System.EventHandler(button_pcbArray_MoveToXY_Click);
			button_pcbArray_SaveXY.BackColor = System.Drawing.Color.CadetBlue;
			button_pcbArray_SaveXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbArray_SaveXY.CnPressDownColor = System.Drawing.Color.White;
			button_pcbArray_SaveXY.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_pcbArray_SaveXY.Location = new System.Drawing.Point(546, 10);
			button_pcbArray_SaveXY.Name = "button_pcbArray_SaveXY";
			button_pcbArray_SaveXY.Size = new System.Drawing.Size(50, 40);
			button_pcbArray_SaveXY.TabIndex = 4;
			button_pcbArray_SaveXY.Text = "保存\r\n";
			button_pcbArray_SaveXY.UseVisualStyleBackColor = false;
			button_pcbArray_SaveXY.Click += new System.EventHandler(button_pcbArray_SaveXY_Click);
			label49.BackColor = System.Drawing.Color.Yellow;
			label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label49.Location = new System.Drawing.Point(235, 338);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(22, 22);
			label49.TabIndex = 0;
			label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label43.BackColor = System.Drawing.Color.SpringGreen;
			label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label43.Location = new System.Drawing.Point(212, 338);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(22, 22);
			label43.TabIndex = 0;
			label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label44.BackColor = System.Drawing.Color.Gray;
			label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label44.Location = new System.Drawing.Point(310, 338);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(22, 22);
			label44.TabIndex = 0;
			label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label109.AutoSize = true;
			label109.Font = new System.Drawing.Font("黑体", 14.25f);
			label109.Location = new System.Drawing.Point(315, 12);
			label109.Name = "label109";
			label109.Size = new System.Drawing.Size(89, 19);
			label109.TabIndex = 16;
			label109.Text = "添加拼板";
			label2.Location = new System.Drawing.Point(-2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(740, 5);
			label2.TabIndex = 23;
			button_PCBE_Array_Close.BackColor = System.Drawing.SystemColors.Control;
			button_PCBE_Array_Close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_Array_Close.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_Array_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_PCBE_Array_Close.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_PCBE_Array_Close.Location = new System.Drawing.Point(662, 2);
			button_PCBE_Array_Close.Name = "button_PCBE_Array_Close";
			button_PCBE_Array_Close.Size = new System.Drawing.Size(32, 32);
			button_PCBE_Array_Close.TabIndex = 17;
			button_PCBE_Array_Close.Text = "X";
			button_PCBE_Array_Close.UseVisualStyleBackColor = false;
			button_PCBE_Array_Close.Click += new System.EventHandler(button_PCBE_Array_Close_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(108, 148, 185);
			base.Controls.Add(button_PCBE_Array_Close);
			base.Controls.Add(label2);
			base.Controls.Add(panel_CoupleArray);
			base.Controls.Add(checkBox_CoupleArray);
			base.Controls.Add(panel_PcbArray);
			base.Controls.Add(label109);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.Name = "UserControl_pcbedit_array";
			base.Size = new System.Drawing.Size(711, 825);
			base.Load += new System.EventHandler(UserControl_pcbedit_array_Load);
			panel_CoupleArray.ResumeLayout(false);
			panel_CoupleArray.PerformLayout();
			panel_coupleArrayShow.ResumeLayout(false);
			panel_couple_H.ResumeLayout(false);
			panel65.ResumeLayout(false);
			panel64.ResumeLayout(false);
			panel_couple_V.ResumeLayout(false);
			panel81.ResumeLayout(false);
			panel89.ResumeLayout(false);
			panel_PcbArray.ResumeLayout(false);
			panel_PcbArray.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel_arraycheck.ResumeLayout(false);
			panel_arraycheck.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel_ismount.ResumeLayout(false);
			panel22.ResumeLayout(false);
			panel_ArrayPCB.ResumeLayout(false);
			panel9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)nud_ArrayPCBColumn).EndInit();
			((System.ComponentModel.ISupportInitialize)nud_ArrayPCBRow).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public UserControl_pcbedit_array(USR_DATA usr, USR3_DATA usr3, DataGridView dgv, bool is_editEnable)
		{
			InitializeComponent();
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			USR3 = usr3;
			dataGridView_pcbedit = dgv;
			mIsEditEnable = is_editEnable;
			MainForm0.mIsOpen_PcbArrayPage = true;
			lb_pcbAixXY = new Label[4] { label31, label38, label35, label42 };
			for (int i = 0; i < 4; i++)
			{
				lb_pcbAixXY[i].Tag = i;
				lb_pcbAixXY[i].Click += label_pcbaix_xy_Click;
				lb_pcbAixXY[i].DoubleClick += label_pcbaix_xy_DoubleClick;
			}
			lb_pcbArrayXY = new Label[4] { label_pcbarray_xy0, label_pcbarray_xy1, label_pcbarray_xy2, label_pcbarray_xy3 };
			for (int j = 0; j < 4; j++)
			{
				lb_pcbArrayXY[j].Tag = j;
				lb_pcbArrayXY[j].Click += label_pcbarray_xy_Click;
				lb_pcbArrayXY[j].DoubleClick += label_pcbarray_xy_DoubleClick;
			}
			checkBox_CoupleArray.Checked = USR3.mIsPcbAix;
			if (USR3.mIsPcbAix)
			{
				panel_CoupleArray.Visible = true;
				panel_PcbArray.Location = new Point(panel_PcbArray.Location.X, panel_CoupleArray.Location.Y + panel_CoupleArray.Size.Height + 2);
			}
			else
			{
				panel_CoupleArray.Visible = false;
				panel_PcbArray.Location = panel_CoupleArray.Location;
			}
			mPcbAixIndex = 0;
			if (USR3.mPcbAixXY == null)
			{
				USR3.mPcbAixXY = new Coordinate[4];
			}
			for (int k = 0; k < 4; k++)
			{
				if (USR3.mPcbAixXY[k] == null)
				{
					USR3.mPcbAixXY[k] = new Coordinate(50000L, 52000L);
				}
				lb_pcbAixXY[k].Text = MainForm0.format_XY_label_string(USR3.mPcbAixXY[k]);
				if (k == mPcbAixIndex)
				{
					lb_pcbAixXY[k].BorderStyle = BorderStyle.Fixed3D;
					lb_pcbAixXY[k].BackColor = Color.White;
				}
				else
				{
					lb_pcbAixXY[k].BorderStyle = BorderStyle.Fixed3D;
					lb_pcbAixXY[k].BackColor = Color.LightGray;
				}
			}
			mPcbArrayIndex = 0;
			if (USR3.mPcbArrayXY == null)
			{
				USR3.mPcbArrayXY = new Coordinate[4];
			}
			for (int l = 0; l < 4; l++)
			{
				if (USR3.mPcbArrayXY[l] == null)
				{
					USR3.mPcbArrayXY[l] = new Coordinate(0L, 0L);
				}
				lb_pcbArrayXY[l].Text = MainForm0.format_XY_label_string(USR3.mPcbArrayXY[l]);
				if (l == mPcbArrayIndex)
				{
					lb_pcbArrayXY[l].BackColor = Color.White;
				}
				else
				{
					lb_pcbArrayXY[l].BackColor = Color.Gray;
				}
			}
			nud_ArrayPCBRow.Value = USR3.mArrayPCBRow;
			nud_ArrayPCBColumn.Value = USR3.mArrayPCBColumn;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label109,
				str = new string[3] { "添加拼板", "添加拼板", "PCB Array" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_CoupleArray,
				str = new string[3] { "鸳鸯板", "鴛鴦板", "Couple PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_coupleH,
				str = new string[3] { "横鸳鸯", "橫鴛鴦", "Horizontal" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton_couple_V,
				str = new string[3] { "竖鸳鸯", "豎鴛鴦", "Vertical" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbAix_SaveXY,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbAix_MoveXY,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbAix_Run,
				str = new string[3] { "生成鸳鸯单板", "生成鴛鴦單板", "Gen Couple PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_DeleteAix,
				str = new string[3] { "删除鸳鸯单板", "刪除鴛鴦單板", "Delete Couple PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label111,
				str = new string[3] { "列数", "列數", "Column(X)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label110,
				str = new string[3] { "行数", "行數", "Row(Y)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbArray_SaveXY,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbArray_MoveToXY,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbArray_Done,
				str = new string[3] { "开始拼板", "開始拼板", "Gen PCB Array" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_deleteArray,
				str = new string[3] { "删除拼板", "刪除拼板", "Delete PCB Array" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label56,
				str = new string[3] { "单板精准校对", "單板精準校對", "Pricise Correct each PCB Coord" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label54,
				str = new string[3] { "拼板号", "拼板號", "Array No." }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_arrayprev,
				str = new string[3] { "上一个", "上壹個", "Prev" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_arraynext,
				str = new string[3] { "下一个", "下壹個", "Next" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label55,
				str = new string[3] { "标记点坐标", "標記點坐標", "Reference Point Coord" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_GotoSinglePointXY,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_arraySinglePoint_Gen,
				str = new string[3] { "保存确认=>校准坐标", "保存確認=>校準坐標", "Save => Correct PCB Coord" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "拼板是否贴装（单击修改）", "拼板是否貼裝（單擊修改）", "Array Is Mount(Click)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label45,
				str = new string[3] { "-贴装", "-貼裝", "-Mount" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label46,
				str = new string[3] { "-不贴装", "-不貼裝", "-Not Mount" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label50,
				str = new string[3] { "-原板", "-原板", "-Original" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label51,
				str = new string[3] { "-鸳鸯板", "-鴛鴦板", "-Couple" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_selectall,
				str = new string[3] { "全选", "全選", "Select All" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label158,
				str = new string[3] { "第一步：设置鸳鸯板的相对位置", "第壹步：設置鴛鴦板的相對位置", "Step 1: Set the related position of couple boards" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label157,
				str = new string[3] { "第二步：将鸳鸯组合模块作为一个整体进行拼板", "第二步：將鴛鴦組合模塊作為壹個整體進行拼板", "Step 2: Convert couple boards to one PCB" }
			});
			return list;
		}

		private void label_pcbarray_xy_Click(object sender, EventArgs e)
		{
			mPcbArrayIndex = (int)((Label)sender).Tag;
			for (int i = 0; i < 4; i++)
			{
				if (i == mPcbArrayIndex)
				{
					lb_pcbArrayXY[i].BackColor = Color.White;
				}
				else
				{
					lb_pcbArrayXY[i].BackColor = Color.Gray;
				}
			}
		}

		private void label_pcbarray_xy_DoubleClick(object sender, EventArgs e)
		{
			mPcbArrayIndex = (int)((Label)sender).Tag;
			for (int i = 0; i < 4; i++)
			{
				if (i == mPcbArrayIndex)
				{
					lb_pcbArrayXY[i].BackColor = Color.White;
				}
				else
				{
					lb_pcbArrayXY[i].BackColor = Color.Gray;
				}
			}
			Form_FillXY form_FillXY = new Form_FillXY(USR3.mPcbArrayXY[mPcbArrayIndex], USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				USR3.mPcbArrayXY[mPcbArrayIndex].X = fillXY.X;
				USR3.mPcbArrayXY[mPcbArrayIndex].Y = fillXY.Y;
				lb_pcbArrayXY[mPcbArrayIndex].Text = MainForm0.format_XY_label_string(USR3.mPcbArrayXY[mPcbArrayIndex]);
			}
		}

		private void label_pcbaix_xy_Click(object sender, EventArgs e)
		{
			mPcbAixIndex = (int)((Label)sender).Tag;
			for (int i = 0; i < 4; i++)
			{
				if (i == mPcbAixIndex)
				{
					lb_pcbAixXY[i].BorderStyle = BorderStyle.Fixed3D;
					lb_pcbAixXY[i].BackColor = Color.White;
				}
				else
				{
					lb_pcbAixXY[i].BorderStyle = BorderStyle.FixedSingle;
					lb_pcbAixXY[i].BackColor = Color.Gray;
				}
			}
		}

		private void label_pcbaix_xy_DoubleClick(object sender, EventArgs e)
		{
			mPcbAixIndex = (int)((Label)sender).Tag;
			for (int i = 0; i < 4; i++)
			{
				if (i == mPcbAixIndex)
				{
					lb_pcbAixXY[i].BorderStyle = BorderStyle.Fixed3D;
					lb_pcbAixXY[i].BackColor = Color.White;
				}
				else
				{
					lb_pcbAixXY[i].BorderStyle = BorderStyle.FixedSingle;
					lb_pcbAixXY[i].BackColor = Color.Gray;
				}
			}
			Form_FillXY form_FillXY = new Form_FillXY(USR3.mPcbAixXY[mPcbAixIndex], USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				USR3.mPcbAixXY[mPcbAixIndex].X = fillXY.X;
				USR3.mPcbAixXY[mPcbAixIndex].Y = fillXY.Y;
				lb_pcbAixXY[mPcbAixIndex].Text = MainForm0.format_XY_label_string(USR3.mPcbAixXY[mPcbAixIndex]);
			}
		}

		private void button_PCBE_Array_Close_Click(object sender, EventArgs e)
		{
			MainForm0.mIsOpen_PcbArrayPage = false;
			Dispose();
		}

		private void checkBox_CoupleArray_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_CoupleArray.Checked)
			{
				panel_CoupleArray.Visible = true;
				panel_PcbArray.Location = new Point(panel_PcbArray.Location.X, panel_CoupleArray.Location.Y + panel_CoupleArray.Size.Height + 2);
			}
			else
			{
				panel_CoupleArray.Visible = false;
				panel_PcbArray.Location = panel_CoupleArray.Location;
			}
		}

		private void radioButton_coupleH_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_coupleH.Checked)
			{
				panel_couple_H.Visible = true;
				panel_couple_V.Visible = false;
			}
		}

		private void radioButton_couple_V_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_couple_V.Checked)
			{
				panel_couple_H.Visible = false;
				panel_couple_V.BringToFront();
				panel_couple_V.Visible = true;
			}
		}

		private void button_pcbAix_SaveXY_Click(object sender, EventArgs e)
		{
			string[] array = new string[4] { "左上", "右上", "左下", "右下" };
			string[] array2 = new string[4] { "Left-Up", "Right-Up", "Left-Down", "Right-Downs" };
			string text = "您确定修改" + array[mPcbAixIndex] + "角定位坐标吗？";
			string text2 = "Are you going to update " + array2[mPcbAixIndex] + "Corner PCB array XY？";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text2 : text, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (MainForm0.mIsSimulation)
				{
					USR3.mPcbAixXY[mPcbAixIndex].X = 45000 + mPcbAixIndex * 3000;
					USR3.mPcbAixXY[mPcbAixIndex].Y = 45000 + mPcbAixIndex * 3000;
				}
				else
				{
					USR3.mPcbAixXY[mPcbAixIndex].X = MainForm0.mCur[MainForm0.mFn].x;
					USR3.mPcbAixXY[mPcbAixIndex].Y = MainForm0.mCur[MainForm0.mFn].y;
				}
				if (this.save_usrProjectData != null)
				{
					this.save_usrProjectData();
				}
				lb_pcbAixXY[mPcbAixIndex].Text = MainForm0.format_XY_label_string(USR3.mPcbAixXY[mPcbAixIndex]);
			}
		}

		private void button_pcbAix_MoveXY_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[MainForm0.mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR3.mPcbAixXY[mPcbAixIndex]);
			}
		}

		private bool is_legal_aixarray()
		{
			int num = MainForm0.moon_isParallelogram(new float[8]
			{
				USR3.mPcbAixXY[0].X,
				USR3.mPcbAixXY[0].Y,
				USR3.mPcbAixXY[1].X,
				USR3.mPcbAixXY[1].Y,
				USR3.mPcbAixXY[3].X,
				USR3.mPcbAixXY[3].Y,
				USR3.mPcbAixXY[2].X,
				USR3.mPcbAixXY[2].Y
			}, 1.5f);
			if (num != 1)
			{
				return false;
			}
			return true;
		}

		private void button_pcbAix_Run_Click(object sender, EventArgs e)
		{
			if (!mIsEditEnable)
			{
				MainForm0.CmMessageBoxTop_Ok((new string[3] { "不可编辑!", "不可編輯!", "Cannot Edit! " })[USR_INIT.mLanguage]);
				return;
			}
			if (!is_legal_aixarray())
			{
				string[] array = new string[3] { "鸳鸯板四点设置可能不精确，是否继续生成？", "鴛鴦板四點設置可能不精確，是否继续生成? ", "Four corner points position are invalid, are you continue? " };
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
			}
			if (USR3.mPointlist == null || USR3.mPointlist.Count <= 0)
			{
				return;
			}
			if (USR3.mArrayPCBColumn > 1 || USR3.mArrayPCBRow > 1)
			{
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Please [Delete Array] Firstly!" : "请先[删除拼板]，再[生成鸳鸯单板]！", MessageBoxButtons.OK);
			}
			else if (USR3.mIsPcbAix)
			{
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Please [Delete Aix] Firstly!" : "请先[删除鸳鸯单板]，再[生成鸳鸯单板]！", MessageBoxButtons.OK);
			}
			else
			{
				if (USR3.mIsGenSmt && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Add new Aix-PCB required a new optimize operation, continue?" : "新增鸳鸯板的轮组吸嘴等信息需要重新执行优化操作，是否继续？", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
				Coordinate coordinate = new Coordinate(0L, 0L);
				for (int i = 0; i < 4; i++)
				{
					coordinate.X += USR3.mPcbAixXY[i].X;
					coordinate.Y += USR3.mPcbAixXY[i].Y;
				}
				coordinate.X /= 4L;
				coordinate.Y /= 4L;
				dataGridView_pcbedit.DataSource = null;
				BindingList<ChipBoardElement> bindingList = new BindingList<ChipBoardElement>();
				for (int j = 0; j < USR3.mPointlist.Count; j++)
				{
					bindingList.Add(USR3.mPointlist[j]);
				}
				USR3.mPointlist.Clear();
				for (int k = 0; k < bindingList.Count; k++)
				{
					if (bindingList[k].Arrayno == 0 && !bindingList[k].isAix)
					{
						USR3.mPointlist.Add(bindingList[k]);
					}
				}
				int count = USR3.mPointlistSmt.Count;
				BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
				for (int l = 0; l < USR3.mPointlistSmt.Count; l++)
				{
					bindingList2.Add(USR3.mPointlistSmt[l]);
				}
				USR3.mPointlistSmt.Clear();
				for (int m = 0; m < bindingList2.Count; m++)
				{
					if (bindingList2[m].Arrayno == 0 && !bindingList2[m].isAix)
					{
						USR3.mPointlistSmt.Add(bindingList2[m]);
					}
				}
				int count2 = USR3.mPointlist.Count;
				for (int n = 0; n < count2; n++)
				{
					ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage, Guid.NewGuid().ToString());
					MainForm0.Copy_ChipBoardElement(chipBoardElement, USR3.mPointlist[n], 0, isguid: true);
					chipBoardElement.X = coordinate.X * 2 - USR3.mPointlist[n].X;
					chipBoardElement.Y = coordinate.Y * 2 - USR3.mPointlist[n].Y;
					chipBoardElement.A = USR3.mPointlist[n].A + 180f;
					chipBoardElement.isAix = true;
					chipBoardElement.Arrayno = 0;
					chipBoardElement.Arrayno_S = (chipBoardElement.isAix ? "*" : "") + "1-1";
					chipBoardElement.Group = count + n;
					chipBoardElement.isOptimization = false;
					USR3.mPointlist.Add(chipBoardElement);
					USR3.mPointlistSmt.Add(chipBoardElement);
					if (chipBoardElement.X < 0 || chipBoardElement.X >= HW.mMaxX[0] || chipBoardElement.Y < 0 || chipBoardElement.Y >= HW.mMaxY[0])
					{
						MainForm0.write_to_logFile("button_pcbAix_Run_Click X或Y超出有效范围！");
					}
					if (chipBoardElement.A >= 360f)
					{
						chipBoardElement.A -= 360f;
					}
				}
				USR3.mPointListOrder = 0;
				MainForm0.pcbsmt_refresh_groups(USR3);
				if (this.PCBE_List_Show != null)
				{
					this.PCBE_List_Show(USR3.mPointListOrder, b: true);
				}
				USR3.mIsPcbAix = true;
				refresh_ismount_array();
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Aix Array Step 1 Complete!" : "鸳鸯生成！", MessageBoxButtons.OK);
				show_ismount_array();
			}
		}

		private void button_DeleteAix_Click(object sender, EventArgs e)
		{
			if (!mIsEditEnable)
			{
				MainForm0.CmMessageBoxTop_Ok((new string[3] { "不可编辑!", "不可編輯!", "Cannot Edit! " })[USR_INIT.mLanguage]);
			}
			else
			{
				if (USR3.mPointlist == null || USR3.mPointlist.Count <= 0)
				{
					return;
				}
				if (USR3.mArrayPCBColumn > 1 || USR3.mArrayPCBRow > 1)
				{
					MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Please [Delete Array] Firstly!" : "请先[删除拼板]，再[删除鸳鸯单板]！", MessageBoxButtons.OK);
				}
				else
				{
					if (USR3.mIsGenSmt && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "After Aix-PCB operation, you need optimize again, continue?" : "操作鸳鸯板之后需要重新执行优化操作，是否继续？", MessageBoxButtons.YesNo) != DialogResult.Yes)
					{
						return;
					}
					dataGridView_pcbedit.DataSource = null;
					BindingList<ChipBoardElement> bindingList = new BindingList<ChipBoardElement>();
					for (int i = 0; i < USR3.mPointlist.Count; i++)
					{
						if (USR3.mPointlist[i].isAix)
						{
							bindingList.Add(USR3.mPointlist[i]);
						}
					}
					for (int j = 0; j < bindingList.Count; j++)
					{
						USR3.mPointlist.Remove(bindingList[j]);
					}
					bindingList.Clear();
					for (int k = 0; k < USR3.mPointlistSmt.Count; k++)
					{
						if (USR3.mPointlistSmt[k].isAix)
						{
							bindingList.Add(USR3.mPointlistSmt[k]);
						}
					}
					for (int l = 0; l < bindingList.Count; l++)
					{
						USR3.mPointlistSmt.Remove(bindingList[l]);
					}
					USR3.mPointListOrder = 0;
					MainForm0.pcbsmt_refresh_groups(USR3);
					if (this.PCBE_List_Show != null)
					{
						this.PCBE_List_Show(USR3.mPointListOrder, b: true);
					}
					USR3.mIsPcbAix = false;
					refresh_ismount_array();
					MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Aix Array Delete Complete!" : "鸳鸯删除成功！", MessageBoxButtons.OK);
					show_ismount_array();
				}
			}
		}

		private void button_pcbArray_SaveXY_Click(object sender, EventArgs e)
		{
			string[] array = new string[4] { "左上", "右上", "左下", "右下" };
			string[] array2 = new string[4] { "Left-Up", "Right-Up", "Left-Down", "Right-Downs" };
			string text = "您确定修改" + array[mPcbArrayIndex] + "角拼板的定位坐标吗？";
			string text2 = "Are you going to update " + array2[mPcbArrayIndex] + "Corner PCB array XY？";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text2 : text, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (MainForm0.mIsSimulation)
				{
					USR3.mPcbArrayXY[mPcbArrayIndex].X = 20000 + mPcbArrayIndex % 2 * 30000;
					USR3.mPcbArrayXY[mPcbArrayIndex].Y = 20000 + mPcbArrayIndex / 2 * 30000;
				}
				else
				{
					USR3.mPcbArrayXY[mPcbArrayIndex].X = MainForm0.mCur[MainForm0.mFn].x;
					USR3.mPcbArrayXY[mPcbArrayIndex].Y = MainForm0.mCur[MainForm0.mFn].y;
				}
				if (this.save_usrProjectData != null)
				{
					this.save_usrProjectData();
				}
				lb_pcbArrayXY[mPcbArrayIndex].Text = MainForm0.format_XY_label_string(USR3.mPcbArrayXY[mPcbArrayIndex]);
			}
		}

		private void button_pcbArray_MoveToXY_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[MainForm0.mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR3.mPcbArrayXY[mPcbArrayIndex]);
			}
		}

		private bool is_legal_array()
		{
			int num = (int)nud_ArrayPCBRow.Value;
			int num2 = (int)nud_ArrayPCBColumn.Value;
			if (num == 1 && num2 == 1)
			{
				return true;
			}
			float num3 = 5f;
			if (num > 1 && num2 == 1)
			{
				double num4 = Math.Atan2(USR3.mPcbArrayXY[2].Y - USR3.mPcbArrayXY[0].Y, USR3.mPcbArrayXY[2].X - USR3.mPcbArrayXY[0].X);
				double num5;
				for (num5 = num4 * 180.0 / 3.1415926; num5 > 180.0; num5 -= 180.0)
				{
				}
				for (; num5 <= -180.0; num5 += 180.0)
				{
				}
				if (Math.Abs(num5 - 90.0) > (double)num3)
				{
					return false;
				}
				double num6 = Math.Atan2(USR3.mPcbArrayXY[3].Y - USR3.mPcbArrayXY[1].Y, USR3.mPcbArrayXY[3].X - USR3.mPcbArrayXY[1].X);
				double num7;
				for (num7 = num6 * 180.0 / 3.1415926; num7 > 180.0; num7 -= 180.0)
				{
				}
				for (; num7 <= -180.0; num7 += 180.0)
				{
				}
				if (Math.Abs(num7 - 90.0) > (double)num3)
				{
					return false;
				}
			}
			if (num == 1 && num2 > 1)
			{
				double num8 = Math.Atan2(USR3.mPcbArrayXY[1].Y - USR3.mPcbArrayXY[0].Y, USR3.mPcbArrayXY[1].X - USR3.mPcbArrayXY[0].X);
				double num9;
				for (num9 = num8 * 180.0 / 3.1415926; num9 > 180.0; num9 -= 180.0)
				{
				}
				for (; num9 <= -180.0; num9 += 180.0)
				{
				}
				if (Math.Abs(num9 - 0.0) > (double)num3)
				{
					return false;
				}
				double num10 = Math.Atan2(USR3.mPcbArrayXY[3].Y - USR3.mPcbArrayXY[2].Y, USR3.mPcbArrayXY[3].X - USR3.mPcbArrayXY[2].X);
				double num11;
				for (num11 = num10 * 180.0 / 3.1415926; num11 > 180.0; num11 -= 180.0)
				{
				}
				for (; num11 <= -180.0; num11 += 180.0)
				{
				}
				if (Math.Abs(num11 - 0.0) > (double)num3)
				{
					return false;
				}
			}
			if (num > 1 && num2 > 1)
			{
				int num12 = MainForm0.moon_isRec(new float[8]
				{
					USR3.mPcbArrayXY[0].X,
					USR3.mPcbArrayXY[0].Y,
					USR3.mPcbArrayXY[1].X,
					USR3.mPcbArrayXY[1].Y,
					USR3.mPcbArrayXY[3].X,
					USR3.mPcbArrayXY[3].Y,
					USR3.mPcbArrayXY[2].X,
					USR3.mPcbArrayXY[2].Y
				}, 1.5f);
				if (num12 != 1)
				{
					return false;
				}
				return true;
			}
			return true;
		}

		private void button_pcbArray_Done_Click(object sender, EventArgs e)
		{
			if (!mIsEditEnable)
			{
				string[] array = new string[3] { "不可编辑!", "不可編輯!", "Cannot Edit! " };
				MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
				return;
			}
			if (!is_legal_array())
			{
				string[] array2 = new string[3] { "拼板的四点坐标设置可能有错误，请仔细检查!", "拼板的四點坐標設置可能有錯誤，請仔細檢查!", "Four corner points position are invalid, please check! " };
				MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
				return;
			}
			int num = (int)nud_ArrayPCBRow.Value;
			int num2 = (int)nud_ArrayPCBColumn.Value;
			if (USR3.mPointlist == null || USR3.mPointlist.Count <= 0 || (num == 1 && num2 == 1))
			{
				return;
			}
			for (int i = 0; i < USR3.mPointlist.Count; i++)
			{
				if (USR3.mPointlist[i].Arrayno > 0)
				{
					MessageBox.Show((USR_INIT.mLanguage == 2) ? "Please delete array firstly!" : "请删除拼板之后，再进行拼板操作！");
					return;
				}
			}
			for (int j = 0; j < USR3.mPointlistSmt.Count; j++)
			{
				if (USR3.mPointlistSmt[j].Arrayno > 0)
				{
					MessageBox.Show((USR_INIT.mLanguage == 2) ? "Please delete array firstly!" : "请删除拼板之后，再进行拼板操作！");
					return;
				}
			}
			if (USR3.mIsGenSmt && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "The operation may break current order and group, you need to optimize again, continue?" : "该操作可能会破坏当前的料站吸嘴建议和贴装轮组，之后建议您重新【优化生成】，继续执行【拼板操作】吗？", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			MainForm0.common_waiting_start((USR_INIT.mLanguage == 2) ? "Array..." : "正在进行拼板", 5);
			int num3 = MainForm0.get_max_importno(USR3.mPointlist);
			int num4 = MainForm0.get_max_group(USR3.mPointlist);
			int count = USR3.mPointlist.Count;
			dataGridView_pcbedit.DataSource = null;
			if (num > 1 || num2 > 1)
			{
				USR3.mArraySinglePoint = new Coordinate[num * num2];
				for (int k = 0; k < num2 * num; k++)
				{
					USR3.mArraySinglePoint[k] = new Coordinate(0L, 0L);
				}
				bool flag = false;
				for (int l = 0; l < num; l++)
				{
					for (int m = 0; m < num2; m++)
					{
						flag = ((!flag) ? true : false);
						if (l == 0 && m == 0)
						{
							USR3.mArraySinglePoint[l * num2 + m].X = USR3.mPcbArrayXY[0].X;
							USR3.mArraySinglePoint[l * num2 + m].Y = USR3.mPcbArrayXY[0].Y;
							continue;
						}
						BindingList<ChipBoardElement> bindingList = new BindingList<ChipBoardElement>();
						for (int n = 0; n < count; n++)
						{
							Coordinate coordinate = new Coordinate(0L, 0L);
							Coordinate coordinate2 = new Coordinate(0L, 0L);
							Coordinate coordinate3 = new Coordinate(0L, 0L);
							if (num == 1)
							{
								coordinate.X = USR3.mPcbArrayXY[0].X;
								coordinate.Y = USR3.mPcbArrayXY[0].Y;
								coordinate3.X = USR3.mPcbArrayXY[1].X;
								coordinate3.Y = USR3.mPcbArrayXY[1].Y;
							}
							else
							{
								coordinate.X = USR3.mPcbArrayXY[0].X + (USR3.mPcbArrayXY[2].X - USR3.mPcbArrayXY[0].X) * l / (num - 1);
								coordinate.Y = USR3.mPcbArrayXY[0].Y + (USR3.mPcbArrayXY[2].Y - USR3.mPcbArrayXY[0].Y) * l / (num - 1);
								coordinate3.X = USR3.mPcbArrayXY[1].X + (USR3.mPcbArrayXY[3].X - USR3.mPcbArrayXY[1].X) * l / (num - 1);
								coordinate3.Y = USR3.mPcbArrayXY[1].Y + (USR3.mPcbArrayXY[3].Y - USR3.mPcbArrayXY[1].Y) * l / (num - 1);
							}
							if (num2 == 1)
							{
								coordinate2.X = 0L;
								coordinate2.Y = 0L;
							}
							else
							{
								coordinate2.X = (coordinate3.X - coordinate.X) * m / (num2 - 1);
								coordinate2.Y = (coordinate3.Y - coordinate.Y) * m / (num2 - 1);
							}
							USR3.mArraySinglePoint[l * num2 + m].X = coordinate.X + coordinate2.X;
							USR3.mArraySinglePoint[l * num2 + m].Y = coordinate.Y + coordinate2.Y;
							ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage, USR3.mPointlist[n].Guid);
							MainForm0.Copy_ChipBoardElement(chipBoardElement, USR3.mPointlist[n], 0, isguid: true);
							chipBoardElement.ImportNo = num3 + 1;
							chipBoardElement.X = USR3.mPointlist[n].X + coordinate.X - USR3.mPcbArrayXY[0].X + coordinate2.X;
							chipBoardElement.Y = USR3.mPointlist[n].Y + coordinate.Y - USR3.mPcbArrayXY[0].Y + coordinate2.Y;
							chipBoardElement.Arrayno_S = (USR3.mPointlist[n].isAix ? "*" : "") + (l + 1) + "-" + (m + 1);
							chipBoardElement.Arrayno = l * num2 + m;
							chipBoardElement.Group = num4 * chipBoardElement.Arrayno + USR3.mPointlist[n].Group;
							chipBoardElement.Guid = USR3.mPointlist[n].Guid;
							bindingList.Add(chipBoardElement);
						}
						for (int num5 = 0; num5 < bindingList.Count; num5++)
						{
							USR3.mPointlist.Add(bindingList[num5]);
						}
						ChipBoardElement[] array3 = bindingList.OrderBy((ChipBoardElement a) => a.Group).ToArray();
						for (int num6 = 0; num6 < array3.Count(); num6++)
						{
							USR3.mPointlistSmt.Add(array3[num6]);
						}
					}
				}
			}
			USR3.mPointListOrder = 0;
			USR3.mArrayPCBRow = num;
			USR3.mArrayPCBColumn = num2;
			flush_arraySignlePoint();
			panel_arraycheck.Enabled = USR3.mArrayPCBRow > 1 || USR3.mArrayPCBColumn > 1;
			MainForm0.pcbsmt_refresh_groups(USR3);
			refresh_ismount_array();
			if (this.PCBE_List_Show != null)
			{
				this.PCBE_List_Show(USR3.mPointListOrder, b: true);
			}
			if (this.save_usrProjectData != null)
			{
				this.save_usrProjectData();
			}
			MainForm0.common_waiting_break();
			show_ismount_array();
		}

		private void button_deleteArray_Click(object sender, EventArgs e)
		{
			if (!mIsEditEnable)
			{
				MainForm0.CmMessageBoxTop_Ok((new string[3] { "不可编辑!", "不可編輯!", "Cannot Edit! " })[USR_INIT.mLanguage]);
			}
			else
			{
				if (USR3.mPointlist == null || USR3.mPointlist.Count <= 0 || (USR3.mArrayPCBRow == 1 && USR3.mArrayPCBColumn == 1) || (USR3.mIsGenSmt && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "This operation will break smt group and order that suggested, you need to optimization again!" : "该可能会破坏当前的料站吸嘴建议和贴装轮组，之后建议您需要重新【优化生成】，确定执行吗？", MessageBoxButtons.YesNo) != DialogResult.Yes))
				{
					return;
				}
				MainForm0.get_max_importno(USR3.mPointlist);
				dataGridView_pcbedit.DataSource = null;
				nud_ArrayPCBRow.Value = (USR3.mArrayPCBRow = 1);
				nud_ArrayPCBColumn.Value = (USR3.mArrayPCBColumn = 1);
				BindingList<ChipBoardElement> bindingList = new BindingList<ChipBoardElement>();
				for (int i = 0; i < USR3.mPointlist.Count; i++)
				{
					if (USR3.mPointlist[i].Arrayno != 0)
					{
						bindingList.Add(USR3.mPointlist[i]);
					}
				}
				for (int j = 0; j < bindingList.Count; j++)
				{
					USR3.mPointlist.Remove(bindingList[j]);
				}
				bindingList.Clear();
				for (int k = 0; k < USR3.mPointlistSmt.Count; k++)
				{
					if (USR3.mPointlistSmt[k].Arrayno != 0)
					{
						bindingList.Add(USR3.mPointlistSmt[k]);
					}
				}
				for (int l = 0; l < bindingList.Count; l++)
				{
					USR3.mPointlistSmt.Remove(bindingList[l]);
				}
				USR3.mPointListOrder = 0;
				MainForm0.pcbsmt_refresh_groups(USR3);
				refresh_ismount_array();
				delete_arraySignlePoint();
				if (this.PCBE_List_Show != null)
				{
					this.PCBE_List_Show(USR3.mPointListOrder, b: true);
				}
				if (this.save_usrProjectData != null)
				{
					this.save_usrProjectData();
				}
				show_ismount_array();
			}
		}

		private void nud_ArrayPCB_ValueChanged(object sender, EventArgs e)
		{
		}

		private void refresh_ismount_array()
		{
			USR3.mIsArrayMount = new bool[USR3.mArrayPCBRow * USR3.mArrayPCBColumn];
			for (int i = 0; i < USR3.mIsArrayMount.Count(); i++)
			{
				USR3.mIsArrayMount[i] = true;
			}
			USR3.mIsArrayAixMount = new bool[USR3.mArrayPCBRow * USR3.mArrayPCBColumn];
			for (int j = 0; j < USR3.mIsArrayAixMount.Count(); j++)
			{
				USR3.mIsArrayAixMount[j] = true;
			}
		}

		private void show_ismount_array()
		{
			if (USR3.mIsArrayMount == null || USR3.mIsArrayMount.Count() != USR3.mArrayPCBRow * USR3.mArrayPCBColumn)
			{
				USR3.mIsArrayMount = new bool[USR3.mArrayPCBRow * USR3.mArrayPCBColumn];
				for (int i = 0; i < USR3.mIsArrayMount.Count(); i++)
				{
					USR3.mIsArrayMount[i] = true;
				}
			}
			if (USR3.mIsPcbAix && (USR3.mIsArrayAixMount == null || USR3.mIsArrayAixMount.Count() != USR3.mArrayPCBRow * USR3.mArrayPCBColumn))
			{
				USR3.mIsArrayAixMount = new bool[USR3.mArrayPCBRow * USR3.mArrayPCBColumn];
				for (int j = 0; j < USR3.mIsArrayAixMount.Count(); j++)
				{
					USR3.mIsArrayAixMount[j] = true;
				}
			}
			panel_ismount.Controls.Clear();
			panel_ismount.Size = new Size(622, 226);
			int num = 57;
			int num2 = 22;
			int num3 = 4;
			int num4 = (USR3.mIsPcbAix ? 20 : 0);
			int num5 = (USR3.mIsPcbAix ? 15 : 0);
			int num6 = (num + num3) * USR3.mArrayPCBColumn + num3 + num4 * USR3.mArrayPCBColumn * (USR3.mIsPcbAix ? 1 : 0);
			int num7 = (num2 + num3) * USR3.mArrayPCBRow + num3 + num5 * USR3.mArrayPCBRow * (USR3.mIsPcbAix ? 1 : 0);
			if (num6 + 3 > panel_ismount.Size.Width)
			{
				panel_ismount.Size = new Size(num6 + 3, panel_ismount.Size.Height);
			}
			if (num7 + 3 > panel_ismount.Size.Height)
			{
				panel_ismount.Size = new Size(panel_ismount.Size.Width, num7 + 3);
			}
			lb_pcbArray = new BindingList<Label>();
			lb_pcbAix = new BindingList<Label>();
			for (int k = 0; k < USR3.mArrayPCBRow; k++)
			{
				for (int l = 0; l < USR3.mArrayPCBColumn; l++)
				{
					Label label = new Label();
					label.AutoSize = false;
					label.Size = new Size(num, num2);
					label.BackColor = (USR3.mIsArrayMount[k * USR3.mArrayPCBColumn + l] ? Color.SpringGreen : Color.Gray);
					label.Text = k + 1 + "-" + (l + 1);
					label.Location = new Point(num3 + l * (num + num3 + num4), num3 + k * (num2 + num3 + num5));
					label.TextAlign = (USR3.mIsPcbAix ? ContentAlignment.TopLeft : ContentAlignment.MiddleCenter);
					label.BorderStyle = BorderStyle.FixedSingle;
					label.Click += lb_ismount_Click_EventHandler;
					label.Tag = k * USR3.mArrayPCBColumn + l;
					panel_ismount.Controls.Add(label);
					lb_pcbArray.Add(label);
					if (USR3.mIsPcbAix)
					{
						Label label2 = new Label();
						label2.AutoSize = false;
						label2.Size = new Size(num, 22);
						label2.BackColor = (USR3.mIsArrayAixMount[k * USR3.mArrayPCBColumn + l] ? Color.Yellow : Color.Gray);
						label2.Text = "*" + (k + 1) + "-" + (l + 1);
						label2.Location = new Point(num3 + num4 + l * (num + num3 + num4), num3 + num5 + k * (num2 + num3 + num5));
						label2.TextAlign = ContentAlignment.BottomRight;
						label2.BorderStyle = BorderStyle.FixedSingle;
						label2.Click += lb_ismount_aix_Click_EventHandler;
						label2.Tag = k * USR3.mArrayPCBColumn + l;
						label2.BringToFront();
						panel_ismount.Controls.Add(label2);
						lb_pcbAix.Add(label2);
					}
				}
			}
		}

		public void lb_ismount_Click_EventHandler(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			int num = (int)label.Tag;
			USR3.mIsArrayMount[num] = !USR3.mIsArrayMount[num];
			label.BackColor = (USR3.mIsArrayMount[num] ? Color.SpringGreen : Color.Gray);
		}

		public void lb_ismount_aix_Click_EventHandler(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			int num = (int)label.Tag;
			USR3.mIsArrayAixMount[num] = !USR3.mIsArrayAixMount[num];
			label.BackColor = (USR3.mIsArrayAixMount[num] ? Color.Yellow : Color.Gray);
		}

		private void UserControl_pcbedit_array_Load(object sender, EventArgs e)
		{
			show_ismount_array();
			set_IsEditEnable(mIsEditEnable);
		}

		public void set_IsEditEnable(bool flag)
		{
			mIsEditEnable = flag;
			panel_arraycheck.Enabled = flag;
			if (USR3.mArrayPCBRow <= 1 && USR3.mArrayPCBColumn <= 1)
			{
				panel_arraycheck.Enabled = false;
			}
			if (USR3.mArraySinglePoint == null)
			{
				panel_arraycheck.Enabled = false;
			}
			if (panel_arraycheck.Enabled)
			{
				flush_arraySignlePoint();
			}
		}

		public void flush_arraySignlePoint()
		{
			comboBox_arrayno.Items.Clear();
			for (int i = 0; i < USR3.mArrayPCBRow; i++)
			{
				for (int j = 0; j < USR3.mArrayPCBColumn; j++)
				{
					comboBox_arrayno.Items.Add(i + 1 + "-" + (j + 1));
				}
			}
		}

		public void delete_arraySignlePoint()
		{
			comboBox_arrayno.Items.Clear();
			comboBox_arrayno.Text = "";
			USR3.mArraySinglePoint = null;
			label_arraysinglepoint.Text = MainForm0.format_XY_label_string(new Coordinate(0L, 0L));
		}

		private void button_pcbArray_exto_subpcb_Click(object sender, EventArgs e)
		{
			string msg = "将[拼板]分解为[PCB板组]，每个子板PCB独立识别Mark点和独立贴装!" + Environment.NewLine + "功能研发中，敬请期待...";
			MainForm0.CmMessageBox(msg, MessageBoxButtons.OK);
		}

		private void checkBox_selectall_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < USR3.mIsArrayMount.Count(); i++)
			{
				USR3.mIsArrayMount[i] = checkBox_selectall.Checked;
				lb_pcbArray[i].BackColor = (USR3.mIsArrayMount[i] ? Color.SpringGreen : Color.Gray);
			}
			if (USR3.mIsPcbAix)
			{
				for (int j = 0; j < USR3.mIsArrayAixMount.Count(); j++)
				{
					USR3.mIsArrayAixMount[j] = checkBox_selectall.Checked;
					lb_pcbAix[j].BackColor = (USR3.mIsArrayAixMount[j] ? Color.Yellow : Color.Gray);
				}
			}
		}

		private void comboBox_arrayno_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (USR3.mArraySinglePoint != null && comboBox_arrayno.SelectedIndex >= 0 && comboBox_arrayno.SelectedIndex < USR3.mArraySinglePoint.Count())
			{
				label_arraysinglepoint.Text = MainForm0.format_XY_label_string(USR3.mArraySinglePoint[comboBox_arrayno.SelectedIndex]);
			}
		}

		private void button_arrayprev_Click(object sender, EventArgs e)
		{
			if (USR3.mArraySinglePoint == null)
			{
				return;
			}
			string text = ((Button)sender).Tag.ToString();
			if (MainForm0.mMutexMoveXYZA)
			{
				return;
			}
			MainForm0.mMutexMoveXYZA = true;
			if (text == "prev")
			{
				if (comboBox_arrayno.SelectedIndex <= 0)
				{
					MainForm0.mMutexMoveXYZA = false;
					return;
				}
				comboBox_arrayno.SelectedIndex--;
			}
			else
			{
				if (!(text == "next"))
				{
					MainForm0.mMutexMoveXYZA = false;
					return;
				}
				if (comboBox_arrayno.SelectedIndex >= USR3.mArraySinglePoint.Count() - 1)
				{
					MainForm0.mMutexMoveXYZA = false;
					return;
				}
				comboBox_arrayno.SelectedIndex++;
			}
			int selectedIndex = comboBox_arrayno.SelectedIndex;
			MainForm0.uc_usroperarion[MainForm0.mFn].switch_to_cam(CameraType.Mark);
			Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
			thread.IsBackground = true;
			thread.Start(USR3.mArraySinglePoint[selectedIndex]);
		}

		private void button_GotoSinglePointXY_Click(object sender, EventArgs e)
		{
			if (USR3.mArraySinglePoint != null)
			{
				int selectedIndex = comboBox_arrayno.SelectedIndex;
				if (selectedIndex >= 0 && selectedIndex < USR3.mArraySinglePoint.Count() && !MainForm0.mMutexMoveXYZA)
				{
					MainForm0.mMutexMoveXYZA = true;
					MainForm0.uc_usroperarion[MainForm0.mFn].switch_to_cam(CameraType.Mark);
					Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
					thread.IsBackground = true;
					thread.Start(USR3.mArraySinglePoint[selectedIndex]);
				}
			}
		}

		private void button_arraySinglePoint_Gen_Click(object sender, EventArgs e)
		{
			if (!mIsEditEnable)
			{
				MainForm0.CmMessageBoxTop_Ok((new string[3] { "不可编辑!", "不可編輯!", "Cannot Edit! " })[USR_INIT.mLanguage]);
			}
			else
			{
				if (USR3.mArraySinglePoint == null)
				{
					return;
				}
				int selectedIndex = comboBox_arrayno.SelectedIndex;
				if (selectedIndex < 0 || selectedIndex >= USR3.mArraySinglePoint.Count())
				{
					return;
				}
				long num = MainForm0.mCur[MainForm0.mFn].x - USR3.mArraySinglePoint[selectedIndex].X;
				long num2 = MainForm0.mCur[MainForm0.mFn].y - USR3.mArraySinglePoint[selectedIndex].Y;
				if (MainForm0.mIsSimulation)
				{
					Form_FillXY form_FillXY = new Form_FillXY(USR3.mArraySinglePoint[selectedIndex], USR_INIT.mLanguage, "XY");
					if (form_FillXY.ShowDialog() == DialogResult.OK)
					{
						Coordinate fillXY = form_FillXY.Get_FillXY();
						num = fillXY.X - USR3.mArraySinglePoint[selectedIndex].X;
						num2 = fillXY.Y - USR3.mArraySinglePoint[selectedIndex].Y;
					}
				}
				if (Math.Abs(num) > 1000 || Math.Abs(num2) > 1000)
				{
					MainForm0.CmMessageBoxTop_Ok((new string[3] { "新坐标不合理，无法保存，请仔细检查!", "新坐標不合理，無法保存，請仔細檢查!", "New Coord invalid, cannot save, please check! " })[USR_INIT.mLanguage]);
					return;
				}
				USR3.mArraySinglePoint[selectedIndex].X += num;
				USR3.mArraySinglePoint[selectedIndex].Y += num2;
				label_arraysinglepoint.Text = MainForm0.format_XY_label_string(USR3.mArraySinglePoint[selectedIndex]);
				for (int i = 0; i < USR3.mPointlist.Count; i++)
				{
					if (USR3.mPointlist[i].Arrayno == selectedIndex)
					{
						USR3.mPointlist[i].X += num;
						USR3.mPointlist[i].Y += num2;
					}
				}
				string[] array = new string[3]
				{
					"正在校准拼板" + comboBox_arrayno.Items[selectedIndex].ToString() + "的坐标",
					"正在校準拼板" + comboBox_arrayno.Items[selectedIndex].ToString() + "的坐標",
					"Correcting the chips coordinate of PCB Array " + comboBox_arrayno.Items[selectedIndex].ToString()
				};
				Thread thread = new Thread(thd_fake_waiting);
				thread.IsBackground = true;
				thread.Start(array[USR_INIT.mLanguage]);
			}
		}

		private void thd_fake_waiting(object o)
		{
			MainForm0.common_waiting_start((string)o, 3);
			Thread.Sleep(500);
			MainForm0.common_waiting_break();
		}
	}
}
