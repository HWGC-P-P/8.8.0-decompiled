using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using QIGN_COMMON.Properties;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_LabPrintfoot : Form
	{
		private IContainer components;

		private Label label1;

		private ListBox listBox1;

		private Panel panel1;

		private Button button_addfile;

		private Button button_removefile;

		private Button button_createfile;

		private Label label_filename;

		private Button button_rem;

		private Button button_add;

		private ListBox listBox2;

		private Panel panel2;

		private Panel panel_foot;

		private CheckBox checkBox_islowspeed;

		private ComboBox comboBox_cameraType;

		private PictureBox pictureBox1;

		private NumericUpDown numericUpDown_delta;

		private NumericUpDown numericUpDown_width;

		private NumericUpDown numericUpDown_length;

		private NumericUpDown numericUpDown_height;

		private Label label207;

		private Button button_collectpic;

		private Label label203;

		private Label label_name;

		private Button button_combinefile;

		private Panel panel3;

		private ComboBox comboBox_provider;

		private ComboBox comboBox_nozzle2;

		private ComboBox comboBox_nozzle;

		private Label label4;

		private Label label3;

		private ComboBox comboBox_feedertype;

		private Label label_visualType;

		private CheckBox checkBox_iscollect;

		private NumericUpDown numericUpDown_collectrate;

		private NumericUpDown numericUpDown_pik_offset;

		private NumericUpDown numericUpDown_mnt_offset;

		private NumericUpDown numericUpDown_threshold;

		private Label label13;

		private NumericUpDown numericUpDown_mnt_downspeed;

		private NumericUpDown numericUpDown_mnt_upspeed;

		private NumericUpDown numericUpDown_pik_downspeed;

		private NumericUpDown numericUpDown_pik_upspeed;

		private NumericUpDown numericUpDown_mnt_delay;

		private NumericUpDown numericUpDown_pik_delay;

		private Button button_clone;

		private Button button_rename;

		private Button button_OK;

		private Button button_cancel;

		private TableLayoutPanel tableLayoutPanel2;

		private Label label8;

		private Label label12;

		private Label label22;

		private Label label23;

		private Label label24;

		private Label label25;

		private Label label26;

		private Label label27;

		private Label label29;

		private Label label32;

		private Label label20;

		private Label label30;

		private NumericUpDown numericUpDown_feederant_delay;

		private TableLayoutPanel tableLayoutPanel3;

		private NumericUpDown numericUpDown_mnt_delay2;

		private NumericUpDown numericUpDown_mnt_downspeed2;

		private NumericUpDown numericUpDown_mnt_upspeed2;

		private NumericUpDown numericUpDown_pik_delay2;

		private NumericUpDown numericUpDown_pik_downspeed2;

		private NumericUpDown numericUpDown_pik_upspeed2;

		private Label label33;

		private Label label34;

		private Label label35;

		private Label label36;

		private Label label37;

		private Label label38;

		private Label label39;

		private NumericUpDown numericUpDown_angle;

		private Label label2;

		private NumericUpDown numericUpDown_chipbox_length;

		private NumericUpDown numericUpDown_chipbox_width;

		private Label label_nickname;

		private CheckBox checkBox_isscanr;

		private Label label7;

		private ComboBox comboBox_beltcolor;

		private Panel panel6;

		private ListBox listBox_cat;

		private Label label9;

		private Label label_cat;

		private Button button_addcat;

		private Button button_delcat;

		private Button button_importpic;

		private Label label14;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem toolStripMenuItem_rename;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem toolStripMenuItem_clone;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem toolStripMenuItem_move;

		private Button button_catrename;

		private Panel panel7;

		private Label label10;

		private NumericUpDown numericUpDown_first_feederin;

		private Button button_nickname;

		private Panel panel8;

		private ComboBox comboBox_pinmode;

		private Label label5;

		private Label label6;

		private PictureBox pictureBox3;

		private Panel panel_pins;

		private Label label11;

		private Label label15;

		private Label label16;

		private NumericUpDown numericUpDown_side_dis;

		private NumericUpDown numericUpDown_pin_width;

		private NumericUpDown numericUpDown_pin_length;

		private Panel panel4;

		private Label label17;

		private NumericUpDown numericUpDown_pin_slot;

		private NumericUpDown numericUpDown_scanr_mm;

		private Label label18;

		private Label label19;

		private Label label21;

		private USR_INIT_DATA USR_INIT;

		private FootPrintPath FP_PATH;

		private USR_LIB mSubLib;

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
			components = new System.ComponentModel.Container();
			label1 = new System.Windows.Forms.Label();
			listBox1 = new System.Windows.Forms.ListBox();
			panel1 = new System.Windows.Forms.Panel();
			button_addfile = new System.Windows.Forms.Button();
			button_removefile = new System.Windows.Forms.Button();
			button_createfile = new System.Windows.Forms.Button();
			label_filename = new System.Windows.Forms.Label();
			button_rem = new System.Windows.Forms.Button();
			button_add = new System.Windows.Forms.Button();
			listBox2 = new System.Windows.Forms.ListBox();
			panel2 = new System.Windows.Forms.Panel();
			panel_foot = new System.Windows.Forms.Panel();
			label18 = new System.Windows.Forms.Label();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			comboBox_feedertype = new System.Windows.Forms.ComboBox();
			comboBox_provider = new System.Windows.Forms.ComboBox();
			label22 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			comboBox_cameraType = new System.Windows.Forms.ComboBox();
			numericUpDown_mnt_offset = new System.Windows.Forms.NumericUpDown();
			label24 = new System.Windows.Forms.Label();
			numericUpDown_pik_offset = new System.Windows.Forms.NumericUpDown();
			numericUpDown_height = new System.Windows.Forms.NumericUpDown();
			numericUpDown_angle = new System.Windows.Forms.NumericUpDown();
			label32 = new System.Windows.Forms.Label();
			label207 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			label_visualType = new System.Windows.Forms.Label();
			numericUpDown_feederant_delay = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			numericUpDown_threshold = new System.Windows.Forms.NumericUpDown();
			label29 = new System.Windows.Forms.Label();
			numericUpDown_collectrate = new System.Windows.Forms.NumericUpDown();
			label20 = new System.Windows.Forms.Label();
			numericUpDown_delta = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			numericUpDown_length = new System.Windows.Forms.NumericUpDown();
			label12 = new System.Windows.Forms.Label();
			numericUpDown_width = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			comboBox_beltcolor = new System.Windows.Forms.ComboBox();
			label10 = new System.Windows.Forms.Label();
			numericUpDown_first_feederin = new System.Windows.Forms.NumericUpDown();
			checkBox_isscanr = new System.Windows.Forms.CheckBox();
			checkBox_islowspeed = new System.Windows.Forms.CheckBox();
			checkBox_iscollect = new System.Windows.Forms.CheckBox();
			numericUpDown_scanr_mm = new System.Windows.Forms.NumericUpDown();
			button_nickname = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			button_collectpic = new System.Windows.Forms.Button();
			label_nickname = new System.Windows.Forms.Label();
			button_importpic = new System.Windows.Forms.Button();
			label_name = new System.Windows.Forms.Label();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			comboBox_nozzle2 = new System.Windows.Forms.ComboBox();
			numericUpDown_mnt_delay2 = new System.Windows.Forms.NumericUpDown();
			comboBox_nozzle = new System.Windows.Forms.ComboBox();
			numericUpDown_mnt_delay = new System.Windows.Forms.NumericUpDown();
			numericUpDown_mnt_downspeed = new System.Windows.Forms.NumericUpDown();
			numericUpDown_mnt_downspeed2 = new System.Windows.Forms.NumericUpDown();
			numericUpDown_mnt_upspeed2 = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_downspeed = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_delay = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_delay2 = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_downspeed2 = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_upspeed2 = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_upspeed = new System.Windows.Forms.NumericUpDown();
			label33 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			label36 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			numericUpDown_mnt_upspeed = new System.Windows.Forms.NumericUpDown();
			label203 = new System.Windows.Forms.Label();
			numericUpDown_chipbox_width = new System.Windows.Forms.NumericUpDown();
			numericUpDown_chipbox_length = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			button_combinefile = new System.Windows.Forms.Button();
			panel3 = new System.Windows.Forms.Panel();
			listBox_cat = new System.Windows.Forms.ListBox();
			panel7 = new System.Windows.Forms.Panel();
			button_catrename = new System.Windows.Forms.Button();
			button_delcat = new System.Windows.Forms.Button();
			button_addcat = new System.Windows.Forms.Button();
			button_OK = new System.Windows.Forms.Button();
			panel6 = new System.Windows.Forms.Panel();
			button_clone = new System.Windows.Forms.Button();
			button_rename = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			label_cat = new System.Windows.Forms.Label();
			button_cancel = new System.Windows.Forms.Button();
			label14 = new System.Windows.Forms.Label();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem_clone = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_rename = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_move = new System.Windows.Forms.ToolStripMenuItem();
			panel8 = new System.Windows.Forms.Panel();
			numericUpDown_pin_slot = new System.Windows.Forms.NumericUpDown();
			panel4 = new System.Windows.Forms.Panel();
			panel_pins = new System.Windows.Forms.Panel();
			numericUpDown_side_dis = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pin_width = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pin_length = new System.Windows.Forms.NumericUpDown();
			comboBox_pinmode = new System.Windows.Forms.ComboBox();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel_foot.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_offset).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_offset).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_height).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_angle).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_feederant_delay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_threshold).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_collectrate).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delta).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_length).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_width).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_first_feederin).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_scanr_mm).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_delay2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_delay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_downspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_downspeed2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_upspeed2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_downspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_delay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_delay2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_downspeed2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_upspeed2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_upspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_upspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_chipbox_width).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_chipbox_length).BeginInit();
			panel3.SuspendLayout();
			panel7.SuspendLayout();
			panel6.SuspendLayout();
			contextMenuStrip1.SuspendLayout();
			panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pin_slot).BeginInit();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_side_dis).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pin_width).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pin_length).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(8, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 24);
			label1.TabIndex = 0;
			label1.Text = "封装库";
			listBox1.Font = new System.Drawing.Font("黑体", 11.5f);
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Items.AddRange(new object[5] { "C:\\aaaa\\footprint1.fplab", "C:\\aaaa\\footprint2.fplab", "C:\\aaaa\\footprint3.fplab", "C:\\aaaa\\footprint4.fplab", "C:\\aaaa\\footprint5.fplab" });
			listBox1.Location = new System.Drawing.Point(3, 2);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(611, 79);
			listBox1.TabIndex = 1;
			listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox1_MouseClick);
			panel1.AutoScroll = true;
			panel1.Controls.Add(listBox1);
			panel1.Location = new System.Drawing.Point(1, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(620, 92);
			panel1.TabIndex = 2;
			button_addfile.Font = new System.Drawing.Font("黑体", 11f);
			button_addfile.Location = new System.Drawing.Point(757, 7);
			button_addfile.Name = "button_addfile";
			button_addfile.Size = new System.Drawing.Size(123, 35);
			button_addfile.TabIndex = 3;
			button_addfile.Text = "添加库文件";
			button_addfile.UseVisualStyleBackColor = true;
			button_addfile.Click += new System.EventHandler(button_addfile_Click);
			button_removefile.Font = new System.Drawing.Font("黑体", 11f);
			button_removefile.Location = new System.Drawing.Point(630, 46);
			button_removefile.Name = "button_removefile";
			button_removefile.Size = new System.Drawing.Size(123, 35);
			button_removefile.TabIndex = 3;
			button_removefile.Text = "移除库文件";
			button_removefile.UseVisualStyleBackColor = true;
			button_removefile.Click += new System.EventHandler(button_removefile_Click);
			button_createfile.Font = new System.Drawing.Font("黑体", 11f);
			button_createfile.Location = new System.Drawing.Point(630, 7);
			button_createfile.Name = "button_createfile";
			button_createfile.Size = new System.Drawing.Size(123, 35);
			button_createfile.TabIndex = 3;
			button_createfile.Text = "新建库文件";
			button_createfile.UseVisualStyleBackColor = true;
			button_createfile.Click += new System.EventHandler(button_createfile_Click);
			label_filename.BackColor = System.Drawing.Color.White;
			label_filename.Font = new System.Drawing.Font("黑体", 11.5f);
			label_filename.Location = new System.Drawing.Point(4, 99);
			label_filename.Name = "label_filename";
			label_filename.Size = new System.Drawing.Size(887, 20);
			label_filename.TabIndex = 4;
			label_filename.Text = "C:\\aaaa\\footprint.fplab";
			label_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_filename.Visible = false;
			button_rem.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_rem.Location = new System.Drawing.Point(2, 47);
			button_rem.Name = "button_rem";
			button_rem.Size = new System.Drawing.Size(60, 35);
			button_rem.TabIndex = 6;
			button_rem.Text = "-";
			button_rem.UseVisualStyleBackColor = true;
			button_rem.Click += new System.EventHandler(button_rem_Click);
			button_add.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_add.Location = new System.Drawing.Point(2, 3);
			button_add.Name = "button_add";
			button_add.Size = new System.Drawing.Size(60, 35);
			button_add.TabIndex = 7;
			button_add.Text = "+";
			button_add.UseVisualStyleBackColor = true;
			button_add.Click += new System.EventHandler(button_add_Click);
			listBox2.Font = new System.Drawing.Font("黑体", 11.5f);
			listBox2.FormattingEnabled = true;
			listBox2.ItemHeight = 15;
			listBox2.Items.AddRange(new object[19]
			{
				"C0201", "C0402", "C0603", "C0805", "C1206", "C3216", "C3528", "C6032", "C7343", "C7845",
				"R0201", "R0402", "R0603", "R0805", "R1206", "R1210", "R1812", "R2010", "R2512"
			});
			listBox2.Location = new System.Drawing.Point(1, 3);
			listBox2.Name = "listBox2";
			listBox2.Size = new System.Drawing.Size(107, 604);
			listBox2.TabIndex = 5;
			listBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox2_MouseClick);
			listBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(listBox2_MouseDown);
			panel2.Controls.Add(listBox2);
			panel2.Location = new System.Drawing.Point(214, 156);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(114, 628);
			panel2.TabIndex = 8;
			panel_foot.BackColor = System.Drawing.Color.White;
			panel_foot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_foot.Controls.Add(label18);
			panel_foot.Controls.Add(pictureBox3);
			panel_foot.Controls.Add(tableLayoutPanel2);
			panel_foot.Controls.Add(button_nickname);
			panel_foot.Controls.Add(pictureBox1);
			panel_foot.Controls.Add(button_collectpic);
			panel_foot.Controls.Add(label_nickname);
			panel_foot.Controls.Add(button_importpic);
			panel_foot.Controls.Add(label_name);
			panel_foot.Controls.Add(tableLayoutPanel3);
			panel_foot.Location = new System.Drawing.Point(339, 122);
			panel_foot.Name = "panel_foot";
			panel_foot.Size = new System.Drawing.Size(552, 641);
			panel_foot.TabIndex = 9;
			label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("黑体", 11f);
			label18.Location = new System.Drawing.Point(230, 367);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(23, 15);
			label18.TabIndex = 1;
			label18.Text = "mm";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox3.Image = QIGN_COMMON.Properties.Resources.CIRCLE;
			pictureBox3.Location = new System.Drawing.Point(267, 332);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(81, 81);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 20;
			pictureBox3.TabStop = false;
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel2.Controls.Add(comboBox_feedertype, 1, 17);
			tableLayoutPanel2.Controls.Add(comboBox_provider, 1, 16);
			tableLayoutPanel2.Controls.Add(label22, 0, 19);
			tableLayoutPanel2.Controls.Add(label23, 0, 18);
			tableLayoutPanel2.Controls.Add(comboBox_cameraType, 1, 7);
			tableLayoutPanel2.Controls.Add(numericUpDown_mnt_offset, 1, 19);
			tableLayoutPanel2.Controls.Add(label24, 0, 17);
			tableLayoutPanel2.Controls.Add(numericUpDown_pik_offset, 1, 18);
			tableLayoutPanel2.Controls.Add(numericUpDown_height, 1, 2);
			tableLayoutPanel2.Controls.Add(numericUpDown_angle, 1, 10);
			tableLayoutPanel2.Controls.Add(label32, 0, 2);
			tableLayoutPanel2.Controls.Add(label207, 0, 10);
			tableLayoutPanel2.Controls.Add(label25, 0, 7);
			tableLayoutPanel2.Controls.Add(label26, 0, 8);
			tableLayoutPanel2.Controls.Add(label27, 0, 16);
			tableLayoutPanel2.Controls.Add(label30, 0, 15);
			tableLayoutPanel2.Controls.Add(label_visualType, 1, 8);
			tableLayoutPanel2.Controls.Add(numericUpDown_feederant_delay, 1, 15);
			tableLayoutPanel2.Controls.Add(label13, 0, 9);
			tableLayoutPanel2.Controls.Add(numericUpDown_threshold, 1, 9);
			tableLayoutPanel2.Controls.Add(label29, 0, 14);
			tableLayoutPanel2.Controls.Add(numericUpDown_collectrate, 1, 14);
			tableLayoutPanel2.Controls.Add(label20, 0, 6);
			tableLayoutPanel2.Controls.Add(numericUpDown_delta, 1, 6);
			tableLayoutPanel2.Controls.Add(label8, 0, 0);
			tableLayoutPanel2.Controls.Add(numericUpDown_length, 1, 0);
			tableLayoutPanel2.Controls.Add(label12, 0, 1);
			tableLayoutPanel2.Controls.Add(numericUpDown_width, 1, 1);
			tableLayoutPanel2.Controls.Add(label7, 0, 4);
			tableLayoutPanel2.Controls.Add(comboBox_beltcolor, 1, 4);
			tableLayoutPanel2.Controls.Add(label10, 0, 5);
			tableLayoutPanel2.Controls.Add(numericUpDown_first_feederin, 1, 5);
			tableLayoutPanel2.Controls.Add(checkBox_isscanr, 0, 11);
			tableLayoutPanel2.Controls.Add(checkBox_islowspeed, 0, 12);
			tableLayoutPanel2.Controls.Add(checkBox_iscollect, 0, 13);
			tableLayoutPanel2.Controls.Add(numericUpDown_scanr_mm, 1, 11);
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 33);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 20;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.Size = new System.Drawing.Size(250, 582);
			tableLayoutPanel2.TabIndex = 12;
			comboBox_feedertype.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_feedertype.FormattingEnabled = true;
			comboBox_feedertype.Location = new System.Drawing.Point(136, 499);
			comboBox_feedertype.Name = "comboBox_feedertype";
			comboBox_feedertype.Size = new System.Drawing.Size(86, 23);
			comboBox_feedertype.TabIndex = 4;
			comboBox_feedertype.SelectedIndexChanged += new System.EventHandler(comboBox_feedertype_SelectedIndexChanged);
			comboBox_provider.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_provider.FormattingEnabled = true;
			comboBox_provider.Location = new System.Drawing.Point(136, 471);
			comboBox_provider.Name = "comboBox_provider";
			comboBox_provider.Size = new System.Drawing.Size(86, 23);
			comboBox_provider.TabIndex = 4;
			comboBox_provider.SelectedIndexChanged += new System.EventHandler(comboBox_provider_SelectedIndexChanged);
			label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font("黑体", 11f);
			label22.Location = new System.Drawing.Point(3, 559);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(127, 15);
			label22.TabIndex = 1;
			label22.Text = "贴装下压偏移/mm";
			label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label23.AutoSize = true;
			label23.Font = new System.Drawing.Font("黑体", 11f);
			label23.Location = new System.Drawing.Point(3, 530);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(127, 15);
			label23.TabIndex = 1;
			label23.Text = "取料下压偏移/mm";
			label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			comboBox_cameraType.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_cameraType.FormattingEnabled = true;
			comboBox_cameraType.Location = new System.Drawing.Point(136, 199);
			comboBox_cameraType.Name = "comboBox_cameraType";
			comboBox_cameraType.Size = new System.Drawing.Size(86, 23);
			comboBox_cameraType.TabIndex = 4;
			comboBox_cameraType.SelectedIndexChanged += new System.EventHandler(comboBox_cameraType_SelectedIndexChanged);
			numericUpDown_mnt_offset.DecimalPlaces = 2;
			numericUpDown_mnt_offset.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_mnt_offset.Location = new System.Drawing.Point(136, 555);
			numericUpDown_mnt_offset.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_mnt_offset.Name = "numericUpDown_mnt_offset";
			numericUpDown_mnt_offset.Size = new System.Drawing.Size(83, 24);
			numericUpDown_mnt_offset.TabIndex = 2;
			numericUpDown_mnt_offset.Value = new decimal(new int[4] { 5, 0, 0, 65536 });
			numericUpDown_mnt_offset.ValueChanged += new System.EventHandler(numericUpDown_mnt_offset_ValueChanged);
			label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font("黑体", 11f);
			label24.Location = new System.Drawing.Point(59, 502);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(71, 15);
			label24.TabIndex = 1;
			label24.Text = "飞达型号";
			label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_pik_offset.BackColor = System.Drawing.Color.LightGray;
			numericUpDown_pik_offset.DecimalPlaces = 2;
			numericUpDown_pik_offset.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pik_offset.Location = new System.Drawing.Point(136, 527);
			numericUpDown_pik_offset.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_pik_offset.Name = "numericUpDown_pik_offset";
			numericUpDown_pik_offset.Size = new System.Drawing.Size(83, 24);
			numericUpDown_pik_offset.TabIndex = 2;
			numericUpDown_pik_offset.Value = new decimal(new int[4] { 5, 0, 0, 65536 });
			numericUpDown_pik_offset.ValueChanged += new System.EventHandler(numericUpDown_pik_offset_ValueChanged);
			numericUpDown_height.DecimalPlaces = 2;
			numericUpDown_height.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_height.Location = new System.Drawing.Point(136, 59);
			numericUpDown_height.Name = "numericUpDown_height";
			numericUpDown_height.Size = new System.Drawing.Size(86, 24);
			numericUpDown_height.TabIndex = 2;
			numericUpDown_height.ValueChanged += new System.EventHandler(numericUpDown_height_ValueChanged);
			numericUpDown_angle.DecimalPlaces = 2;
			numericUpDown_angle.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_angle.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_angle.Location = new System.Drawing.Point(136, 303);
			numericUpDown_angle.Maximum = new decimal(new int[4] { 360, 0, 0, 0 });
			numericUpDown_angle.Minimum = new decimal(new int[4] { 180, 0, 0, -2147483648 });
			numericUpDown_angle.Name = "numericUpDown_angle";
			numericUpDown_angle.Size = new System.Drawing.Size(86, 24);
			numericUpDown_angle.TabIndex = 14;
			numericUpDown_angle.ValueChanged += new System.EventHandler(numericUpDown_angle_ValueChanged);
			label32.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label32.AutoSize = true;
			label32.Font = new System.Drawing.Font("黑体", 11f);
			label32.Location = new System.Drawing.Point(35, 62);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(95, 15);
			label32.TabIndex = 1;
			label32.Text = "元件厚度/mm";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label207.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label207.AutoSize = true;
			label207.Font = new System.Drawing.Font("黑体", 11f);
			label207.Location = new System.Drawing.Point(59, 306);
			label207.Name = "label207";
			label207.Size = new System.Drawing.Size(71, 15);
			label207.TabIndex = 1;
			label207.Text = "进料角度";
			label207.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("黑体", 11f);
			label25.Location = new System.Drawing.Point(59, 202);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(71, 15);
			label25.TabIndex = 1;
			label25.Text = "相机类型";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font("黑体", 11f);
			label26.Location = new System.Drawing.Point(59, 240);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(71, 15);
			label26.TabIndex = 1;
			label26.Text = "视觉类型";
			label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("黑体", 11f);
			label27.Location = new System.Drawing.Point(59, 474);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(71, 15);
			label27.TabIndex = 1;
			label27.Text = "供料类型";
			label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label30.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label30.AutoSize = true;
			label30.Font = new System.Drawing.Font("黑体", 11f);
			label30.Location = new System.Drawing.Point(59, 446);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(71, 15);
			label30.TabIndex = 1;
			label30.Text = "出料延时";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_visualType.BackColor = System.Drawing.Color.SeaShell;
			label_visualType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_visualType.Font = new System.Drawing.Font("黑体", 11f);
			label_visualType.Location = new System.Drawing.Point(136, 224);
			label_visualType.Name = "label_visualType";
			label_visualType.Size = new System.Drawing.Size(97, 48);
			label_visualType.TabIndex = 1;
			label_visualType.Text = "自定义视觉\r\n二阶闭环";
			label_visualType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_visualType.Click += new System.EventHandler(label_visualType_Click);
			numericUpDown_feederant_delay.DecimalPlaces = 2;
			numericUpDown_feederant_delay.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_feederant_delay.Location = new System.Drawing.Point(136, 443);
			numericUpDown_feederant_delay.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_feederant_delay.Name = "numericUpDown_feederant_delay";
			numericUpDown_feederant_delay.Size = new System.Drawing.Size(86, 24);
			numericUpDown_feederant_delay.TabIndex = 2;
			numericUpDown_feederant_delay.Value = new decimal(new int[4] { 5, 0, 0, 65536 });
			numericUpDown_feederant_delay.ValueChanged += new System.EventHandler(numericUpDown_feederant_delay_ValueChanged);
			label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("黑体", 11f);
			label13.Location = new System.Drawing.Point(59, 278);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(71, 15);
			label13.TabIndex = 1;
			label13.Text = "视觉阈值";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_threshold.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_threshold.Location = new System.Drawing.Point(136, 275);
			numericUpDown_threshold.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			numericUpDown_threshold.Name = "numericUpDown_threshold";
			numericUpDown_threshold.Size = new System.Drawing.Size(86, 24);
			numericUpDown_threshold.TabIndex = 2;
			numericUpDown_threshold.Value = new decimal(new int[4] { 127, 0, 0, 0 });
			numericUpDown_threshold.ValueChanged += new System.EventHandler(numericUpDown_threshold_ValueChanged);
			label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label29.AutoSize = true;
			label29.Font = new System.Drawing.Font("黑体", 11f);
			label29.Location = new System.Drawing.Point(11, 418);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(119, 15);
			label29.TabIndex = 1;
			label29.Text = "特征识别容差/%";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_collectrate.DecimalPlaces = 2;
			numericUpDown_collectrate.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_collectrate.Location = new System.Drawing.Point(136, 415);
			numericUpDown_collectrate.Name = "numericUpDown_collectrate";
			numericUpDown_collectrate.Size = new System.Drawing.Size(86, 24);
			numericUpDown_collectrate.TabIndex = 2;
			numericUpDown_collectrate.ValueChanged += new System.EventHandler(numericUpDown_collectrate_ValueChanged);
			label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("黑体", 11f);
			label20.Location = new System.Drawing.Point(35, 174);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(95, 15);
			label20.TabIndex = 1;
			label20.Text = "同取容差/mm";
			label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_delta.DecimalPlaces = 2;
			numericUpDown_delta.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_delta.Location = new System.Drawing.Point(136, 171);
			numericUpDown_delta.Name = "numericUpDown_delta";
			numericUpDown_delta.Size = new System.Drawing.Size(86, 24);
			numericUpDown_delta.TabIndex = 2;
			numericUpDown_delta.ValueChanged += new System.EventHandler(numericUpDown_delta_ValueChanged);
			label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("黑体", 11f);
			label8.Location = new System.Drawing.Point(35, 6);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(95, 15);
			label8.TabIndex = 1;
			label8.Text = "元件长度/mm";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_length.DecimalPlaces = 2;
			numericUpDown_length.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_length.Location = new System.Drawing.Point(136, 3);
			numericUpDown_length.Name = "numericUpDown_length";
			numericUpDown_length.Size = new System.Drawing.Size(86, 24);
			numericUpDown_length.TabIndex = 2;
			numericUpDown_length.ValueChanged += new System.EventHandler(numericUpDown_length_ValueChanged);
			label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("黑体", 11f);
			label12.Location = new System.Drawing.Point(35, 34);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(95, 15);
			label12.TabIndex = 1;
			label12.Text = "元件宽度/mm";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_width.DecimalPlaces = 2;
			numericUpDown_width.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_width.Location = new System.Drawing.Point(136, 31);
			numericUpDown_width.Name = "numericUpDown_width";
			numericUpDown_width.Size = new System.Drawing.Size(86, 24);
			numericUpDown_width.TabIndex = 2;
			numericUpDown_width.ValueChanged += new System.EventHandler(numericUpDown_width_ValueChanged);
			label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 11f);
			label7.Location = new System.Drawing.Point(59, 118);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(71, 15);
			label7.TabIndex = 1;
			label7.Text = "料带颜色";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			comboBox_beltcolor.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_beltcolor.FormattingEnabled = true;
			comboBox_beltcolor.Items.AddRange(new object[3] { "白色料带", "黑色料带", "透明料带" });
			comboBox_beltcolor.Location = new System.Drawing.Point(136, 115);
			comboBox_beltcolor.Name = "comboBox_beltcolor";
			comboBox_beltcolor.Size = new System.Drawing.Size(86, 23);
			comboBox_beltcolor.TabIndex = 16;
			comboBox_beltcolor.SelectedIndexChanged += new System.EventHandler(comboBox_beltcolor_SelectedIndexChanged);
			label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("黑体", 11f);
			label10.Location = new System.Drawing.Point(27, 146);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(103, 15);
			label10.TabIndex = 1;
			label10.Text = "额外进料数量";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_first_feederin.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_first_feederin.Location = new System.Drawing.Point(136, 143);
			numericUpDown_first_feederin.Name = "numericUpDown_first_feederin";
			numericUpDown_first_feederin.Size = new System.Drawing.Size(86, 24);
			numericUpDown_first_feederin.TabIndex = 17;
			numericUpDown_first_feederin.ValueChanged += new System.EventHandler(numericUpDown_first_feederin_ValueChanged);
			checkBox_isscanr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			checkBox_isscanr.AutoSize = true;
			checkBox_isscanr.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_isscanr.Location = new System.Drawing.Point(8, 331);
			checkBox_isscanr.Name = "checkBox_isscanr";
			checkBox_isscanr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			checkBox_isscanr.Size = new System.Drawing.Size(122, 19);
			checkBox_isscanr.TabIndex = 15;
			checkBox_isscanr.Text = "专用扫描半径";
			checkBox_isscanr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_isscanr.UseVisualStyleBackColor = true;
			checkBox_isscanr.CheckedChanged += new System.EventHandler(checkBox_isscanr_CheckedChanged);
			checkBox_islowspeed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			checkBox_islowspeed.AutoSize = true;
			checkBox_islowspeed.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_islowspeed.Location = new System.Drawing.Point(40, 359);
			checkBox_islowspeed.Name = "checkBox_islowspeed";
			checkBox_islowspeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			checkBox_islowspeed.Size = new System.Drawing.Size(90, 19);
			checkBox_islowspeed.TabIndex = 5;
			checkBox_islowspeed.Text = "降速搬运";
			checkBox_islowspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_islowspeed.UseVisualStyleBackColor = true;
			checkBox_islowspeed.CheckedChanged += new System.EventHandler(checkBox_islowspeed_CheckedChanged);
			checkBox_iscollect.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			checkBox_iscollect.AutoSize = true;
			checkBox_iscollect.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_iscollect.Location = new System.Drawing.Point(40, 387);
			checkBox_iscollect.Name = "checkBox_iscollect";
			checkBox_iscollect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			checkBox_iscollect.Size = new System.Drawing.Size(90, 19);
			checkBox_iscollect.TabIndex = 5;
			checkBox_iscollect.Text = "特征识别";
			checkBox_iscollect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_iscollect.UseVisualStyleBackColor = true;
			checkBox_iscollect.CheckedChanged += new System.EventHandler(checkBox_iscollect_CheckedChanged);
			numericUpDown_scanr_mm.DecimalPlaces = 2;
			numericUpDown_scanr_mm.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_scanr_mm.Location = new System.Drawing.Point(136, 331);
			numericUpDown_scanr_mm.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			numericUpDown_scanr_mm.Name = "numericUpDown_scanr_mm";
			numericUpDown_scanr_mm.Size = new System.Drawing.Size(86, 24);
			numericUpDown_scanr_mm.TabIndex = 18;
			numericUpDown_scanr_mm.ValueChanged += new System.EventHandler(numericUpDown_scanr_mm_ValueChanged);
			button_nickname.Location = new System.Drawing.Point(275, 33);
			button_nickname.Name = "button_nickname";
			button_nickname.Size = new System.Drawing.Size(124, 28);
			button_nickname.TabIndex = 19;
			button_nickname.Text = "别名";
			button_nickname.UseVisualStyleBackColor = true;
			button_nickname.Click += new System.EventHandler(button_nickname_Click);
			pictureBox1.BackColor = System.Drawing.Color.Gray;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(405, 33);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(129, 134);
			pictureBox1.TabIndex = 3;
			pictureBox1.TabStop = false;
			button_collectpic.Font = new System.Drawing.Font("黑体", 10.5f);
			button_collectpic.Location = new System.Drawing.Point(405, 171);
			button_collectpic.Name = "button_collectpic";
			button_collectpic.Size = new System.Drawing.Size(62, 28);
			button_collectpic.TabIndex = 0;
			button_collectpic.Text = "采集";
			button_collectpic.UseVisualStyleBackColor = true;
			label_nickname.BackColor = System.Drawing.Color.White;
			label_nickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_nickname.Font = new System.Drawing.Font("楷体", 11.5f);
			label_nickname.Location = new System.Drawing.Point(275, 65);
			label_nickname.Name = "label_nickname";
			label_nickname.Size = new System.Drawing.Size(124, 102);
			label_nickname.TabIndex = 17;
			label_nickname.Text = "R-0603\r\nR_0603\r\n0603R";
			button_importpic.Font = new System.Drawing.Font("黑体", 10.5f);
			button_importpic.Location = new System.Drawing.Point(472, 171);
			button_importpic.Name = "button_importpic";
			button_importpic.Size = new System.Drawing.Size(62, 28);
			button_importpic.TabIndex = 0;
			button_importpic.Text = "导入";
			button_importpic.UseVisualStyleBackColor = true;
			button_importpic.Click += new System.EventHandler(button_importpic_Click);
			label_name.Font = new System.Drawing.Font("楷体", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_name.Location = new System.Drawing.Point(3, -4);
			label_name.Name = "label_name";
			label_name.Size = new System.Drawing.Size(219, 37);
			label_name.TabIndex = 0;
			label_name.Text = "R0603";
			label_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			tableLayoutPanel3.ColumnCount = 3;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.40909f));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.64773f));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.94318f));
			tableLayoutPanel3.Controls.Add(comboBox_nozzle2, 2, 3);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_delay2, 2, 9);
			tableLayoutPanel3.Controls.Add(comboBox_nozzle, 1, 3);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_delay, 1, 9);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_downspeed, 1, 8);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_downspeed2, 2, 8);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_upspeed2, 2, 7);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_downspeed, 1, 5);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_delay, 1, 6);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_delay2, 2, 6);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_downspeed2, 2, 5);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_upspeed2, 2, 4);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_upspeed, 1, 4);
			tableLayoutPanel3.Controls.Add(label33, 0, 6);
			tableLayoutPanel3.Controls.Add(label34, 0, 5);
			tableLayoutPanel3.Controls.Add(label4, 0, 3);
			tableLayoutPanel3.Controls.Add(label3, 1, 2);
			tableLayoutPanel3.Controls.Add(label35, 0, 4);
			tableLayoutPanel3.Controls.Add(label36, 0, 9);
			tableLayoutPanel3.Controls.Add(label37, 0, 8);
			tableLayoutPanel3.Controls.Add(label38, 0, 7);
			tableLayoutPanel3.Controls.Add(label39, 2, 2);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_upspeed, 1, 7);
			tableLayoutPanel3.Location = new System.Drawing.Point(271, 333);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 10;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.Size = new System.Drawing.Size(313, 281);
			tableLayoutPanel3.TabIndex = 13;
			comboBox_nozzle2.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_nozzle2.FormattingEnabled = true;
			comboBox_nozzle2.Location = new System.Drawing.Point(234, 87);
			comboBox_nozzle2.Name = "comboBox_nozzle2";
			comboBox_nozzle2.Size = new System.Drawing.Size(61, 23);
			comboBox_nozzle2.TabIndex = 4;
			comboBox_nozzle2.Visible = false;
			comboBox_nozzle2.SelectedIndexChanged += new System.EventHandler(comboBox_nozzle2_SelectedIndexChanged);
			numericUpDown_mnt_delay2.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_mnt_delay2.Location = new System.Drawing.Point(234, 255);
			numericUpDown_mnt_delay2.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			numericUpDown_mnt_delay2.Name = "numericUpDown_mnt_delay2";
			numericUpDown_mnt_delay2.Size = new System.Drawing.Size(61, 24);
			numericUpDown_mnt_delay2.TabIndex = 2;
			numericUpDown_mnt_delay2.Tag = "1";
			numericUpDown_mnt_delay2.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_mnt_delay2.Visible = false;
			numericUpDown_mnt_delay2.ValueChanged += new System.EventHandler(numericUpDown_mnt_delay_ValueChanged);
			comboBox_nozzle.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_nozzle.FormattingEnabled = true;
			comboBox_nozzle.Location = new System.Drawing.Point(154, 87);
			comboBox_nozzle.Name = "comboBox_nozzle";
			comboBox_nozzle.Size = new System.Drawing.Size(62, 23);
			comboBox_nozzle.TabIndex = 4;
			comboBox_nozzle.SelectedIndexChanged += new System.EventHandler(comboBox_nozzle_SelectedIndexChanged);
			numericUpDown_mnt_delay.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_mnt_delay.Location = new System.Drawing.Point(154, 255);
			numericUpDown_mnt_delay.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			numericUpDown_mnt_delay.Name = "numericUpDown_mnt_delay";
			numericUpDown_mnt_delay.Size = new System.Drawing.Size(62, 24);
			numericUpDown_mnt_delay.TabIndex = 2;
			numericUpDown_mnt_delay.Tag = "0";
			numericUpDown_mnt_delay.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_mnt_delay.ValueChanged += new System.EventHandler(numericUpDown_mnt_delay_ValueChanged);
			numericUpDown_mnt_downspeed.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_mnt_downspeed.Location = new System.Drawing.Point(154, 227);
			numericUpDown_mnt_downspeed.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_downspeed.Name = "numericUpDown_mnt_downspeed";
			numericUpDown_mnt_downspeed.Size = new System.Drawing.Size(62, 24);
			numericUpDown_mnt_downspeed.TabIndex = 2;
			numericUpDown_mnt_downspeed.Tag = "0";
			numericUpDown_mnt_downspeed.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_downspeed.ValueChanged += new System.EventHandler(numericUpDown_mnt_downspeed_ValueChanged);
			numericUpDown_mnt_downspeed2.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_mnt_downspeed2.Location = new System.Drawing.Point(234, 227);
			numericUpDown_mnt_downspeed2.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_downspeed2.Name = "numericUpDown_mnt_downspeed2";
			numericUpDown_mnt_downspeed2.Size = new System.Drawing.Size(61, 24);
			numericUpDown_mnt_downspeed2.TabIndex = 2;
			numericUpDown_mnt_downspeed2.Tag = "1";
			numericUpDown_mnt_downspeed2.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_downspeed2.Visible = false;
			numericUpDown_mnt_downspeed2.ValueChanged += new System.EventHandler(numericUpDown_mnt_downspeed_ValueChanged);
			numericUpDown_mnt_upspeed2.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_mnt_upspeed2.Location = new System.Drawing.Point(234, 199);
			numericUpDown_mnt_upspeed2.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_upspeed2.Name = "numericUpDown_mnt_upspeed2";
			numericUpDown_mnt_upspeed2.Size = new System.Drawing.Size(61, 24);
			numericUpDown_mnt_upspeed2.TabIndex = 2;
			numericUpDown_mnt_upspeed2.Tag = "1";
			numericUpDown_mnt_upspeed2.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_upspeed2.Visible = false;
			numericUpDown_mnt_upspeed2.ValueChanged += new System.EventHandler(numericUpDown_mnt_upspeed_ValueChanged);
			numericUpDown_pik_downspeed.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pik_downspeed.Location = new System.Drawing.Point(154, 143);
			numericUpDown_pik_downspeed.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_downspeed.Name = "numericUpDown_pik_downspeed";
			numericUpDown_pik_downspeed.Size = new System.Drawing.Size(62, 24);
			numericUpDown_pik_downspeed.TabIndex = 2;
			numericUpDown_pik_downspeed.Tag = "0";
			numericUpDown_pik_downspeed.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_downspeed.ValueChanged += new System.EventHandler(numericUpDown_pik_downspeed_ValueChanged);
			numericUpDown_pik_delay.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pik_delay.Location = new System.Drawing.Point(154, 171);
			numericUpDown_pik_delay.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			numericUpDown_pik_delay.Name = "numericUpDown_pik_delay";
			numericUpDown_pik_delay.Size = new System.Drawing.Size(62, 24);
			numericUpDown_pik_delay.TabIndex = 2;
			numericUpDown_pik_delay.Tag = "0";
			numericUpDown_pik_delay.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_pik_delay.ValueChanged += new System.EventHandler(numericUpDown_pik_delay_ValueChanged);
			numericUpDown_pik_delay2.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pik_delay2.Location = new System.Drawing.Point(234, 171);
			numericUpDown_pik_delay2.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			numericUpDown_pik_delay2.Name = "numericUpDown_pik_delay2";
			numericUpDown_pik_delay2.Size = new System.Drawing.Size(61, 24);
			numericUpDown_pik_delay2.TabIndex = 2;
			numericUpDown_pik_delay2.Tag = "1";
			numericUpDown_pik_delay2.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_pik_delay2.Visible = false;
			numericUpDown_pik_delay2.ValueChanged += new System.EventHandler(numericUpDown_pik_delay_ValueChanged);
			numericUpDown_pik_downspeed2.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pik_downspeed2.Location = new System.Drawing.Point(234, 143);
			numericUpDown_pik_downspeed2.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_downspeed2.Name = "numericUpDown_pik_downspeed2";
			numericUpDown_pik_downspeed2.Size = new System.Drawing.Size(61, 24);
			numericUpDown_pik_downspeed2.TabIndex = 2;
			numericUpDown_pik_downspeed2.Tag = "1";
			numericUpDown_pik_downspeed2.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_downspeed2.Visible = false;
			numericUpDown_pik_downspeed2.ValueChanged += new System.EventHandler(numericUpDown_pik_downspeed_ValueChanged);
			numericUpDown_pik_upspeed2.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pik_upspeed2.Location = new System.Drawing.Point(234, 115);
			numericUpDown_pik_upspeed2.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_upspeed2.Name = "numericUpDown_pik_upspeed2";
			numericUpDown_pik_upspeed2.Size = new System.Drawing.Size(61, 24);
			numericUpDown_pik_upspeed2.TabIndex = 2;
			numericUpDown_pik_upspeed2.Tag = "1";
			numericUpDown_pik_upspeed2.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_upspeed2.Visible = false;
			numericUpDown_pik_upspeed2.ValueChanged += new System.EventHandler(numericUpDown_pik_upspeed_ValueChanged);
			numericUpDown_pik_upspeed.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pik_upspeed.Location = new System.Drawing.Point(154, 115);
			numericUpDown_pik_upspeed.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_upspeed.Name = "numericUpDown_pik_upspeed";
			numericUpDown_pik_upspeed.Size = new System.Drawing.Size(62, 24);
			numericUpDown_pik_upspeed.TabIndex = 2;
			numericUpDown_pik_upspeed.Tag = "0";
			numericUpDown_pik_upspeed.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_upspeed.ValueChanged += new System.EventHandler(numericUpDown_pik_upspeed_ValueChanged);
			label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label33.AutoSize = true;
			label33.Font = new System.Drawing.Font("黑体", 11f);
			label33.Location = new System.Drawing.Point(53, 174);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(95, 15);
			label33.TabIndex = 1;
			label33.Text = "取料延时/ms";
			label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label34.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label34.AutoSize = true;
			label34.Font = new System.Drawing.Font("黑体", 11f);
			label34.Location = new System.Drawing.Point(45, 146);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(103, 15);
			label34.TabIndex = 1;
			label34.Text = "取料下伸速度";
			label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 11f);
			label4.Location = new System.Drawing.Point(77, 90);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(71, 15);
			label4.TabIndex = 1;
			label4.Text = "吸嘴类型";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 11f);
			label3.Location = new System.Drawing.Point(154, 56);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(74, 28);
			label3.TabIndex = 1;
			label3.Text = "主吸嘴";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label35.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label35.AutoSize = true;
			label35.Font = new System.Drawing.Font("黑体", 11f);
			label35.Location = new System.Drawing.Point(45, 118);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(103, 15);
			label35.TabIndex = 1;
			label35.Text = "取料上拉速度";
			label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label36.AutoSize = true;
			label36.Font = new System.Drawing.Font("黑体", 11f);
			label36.Location = new System.Drawing.Point(53, 259);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(95, 15);
			label36.TabIndex = 1;
			label36.Text = "贴装延时/ms";
			label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label37.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label37.AutoSize = true;
			label37.Font = new System.Drawing.Font("黑体", 11f);
			label37.Location = new System.Drawing.Point(45, 230);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(103, 15);
			label37.TabIndex = 1;
			label37.Text = "贴装下伸速度";
			label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label38.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label38.AutoSize = true;
			label38.Font = new System.Drawing.Font("黑体", 11f);
			label38.Location = new System.Drawing.Point(45, 202);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(103, 15);
			label38.TabIndex = 1;
			label38.Text = "贴装上拉速度";
			label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label39.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label39.Font = new System.Drawing.Font("黑体", 11f);
			label39.Location = new System.Drawing.Point(234, 56);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(76, 28);
			label39.TabIndex = 1;
			label39.Text = "备用吸嘴";
			label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label39.Visible = false;
			numericUpDown_mnt_upspeed.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_mnt_upspeed.Location = new System.Drawing.Point(154, 199);
			numericUpDown_mnt_upspeed.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_upspeed.Name = "numericUpDown_mnt_upspeed";
			numericUpDown_mnt_upspeed.Size = new System.Drawing.Size(62, 24);
			numericUpDown_mnt_upspeed.TabIndex = 2;
			numericUpDown_mnt_upspeed.Tag = "0";
			numericUpDown_mnt_upspeed.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_upspeed.ValueChanged += new System.EventHandler(numericUpDown_mnt_upspeed_ValueChanged);
			label203.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label203.AutoSize = true;
			label203.Location = new System.Drawing.Point(6, 546);
			label203.Name = "label203";
			label203.Size = new System.Drawing.Size(84, 14);
			label203.TabIndex = 1;
			label203.Text = "料仓长度/mm";
			label203.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label203.Visible = false;
			numericUpDown_chipbox_width.DecimalPlaces = 2;
			numericUpDown_chipbox_width.Location = new System.Drawing.Point(108, 578);
			numericUpDown_chipbox_width.Name = "numericUpDown_chipbox_width";
			numericUpDown_chipbox_width.Size = new System.Drawing.Size(86, 23);
			numericUpDown_chipbox_width.TabIndex = 14;
			numericUpDown_chipbox_width.Visible = false;
			numericUpDown_chipbox_length.DecimalPlaces = 2;
			numericUpDown_chipbox_length.Location = new System.Drawing.Point(108, 549);
			numericUpDown_chipbox_length.Name = "numericUpDown_chipbox_length";
			numericUpDown_chipbox_length.Size = new System.Drawing.Size(86, 23);
			numericUpDown_chipbox_length.TabIndex = 14;
			numericUpDown_chipbox_length.Visible = false;
			label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(6, 575);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(84, 14);
			label2.TabIndex = 1;
			label2.Text = "料仓宽度/mm";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.Visible = false;
			button_combinefile.Enabled = false;
			button_combinefile.Font = new System.Drawing.Font("黑体", 11f);
			button_combinefile.Location = new System.Drawing.Point(757, 46);
			button_combinefile.Name = "button_combinefile";
			button_combinefile.Size = new System.Drawing.Size(123, 35);
			button_combinefile.TabIndex = 3;
			button_combinefile.Text = "合并库文件";
			button_combinefile.UseVisualStyleBackColor = true;
			panel3.Controls.Add(listBox_cat);
			panel3.Controls.Add(panel7);
			panel3.Controls.Add(button_OK);
			panel3.Controls.Add(panel2);
			panel3.Controls.Add(label203);
			panel3.Controls.Add(panel6);
			panel3.Controls.Add(panel_foot);
			panel3.Controls.Add(numericUpDown_chipbox_width);
			panel3.Controls.Add(label9);
			panel3.Controls.Add(label_cat);
			panel3.Controls.Add(numericUpDown_chipbox_length);
			panel3.Controls.Add(button_cancel);
			panel3.Controls.Add(label2);
			panel3.Controls.Add(label_filename);
			panel3.Controls.Add(button_combinefile);
			panel3.Controls.Add(panel1);
			panel3.Controls.Add(label14);
			panel3.Controls.Add(button_removefile);
			panel3.Controls.Add(button_createfile);
			panel3.Controls.Add(button_addfile);
			panel3.Location = new System.Drawing.Point(5, 41);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(896, 868);
			panel3.TabIndex = 10;
			listBox_cat.Font = new System.Drawing.Font("黑体", 12.5f);
			listBox_cat.FormattingEnabled = true;
			listBox_cat.ItemHeight = 17;
			listBox_cat.Items.AddRange(new object[6] { "贴片电容", "贴片电阻", "二极管", "三极管", "钽电容", "其他" });
			listBox_cat.Location = new System.Drawing.Point(3, 148);
			listBox_cat.Name = "listBox_cat";
			listBox_cat.Size = new System.Drawing.Size(134, 276);
			listBox_cat.TabIndex = 11;
			listBox_cat.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox_cat_MouseClick);
			listBox_cat.SelectedIndexChanged += new System.EventHandler(listBox_cat_SelectedIndexChanged);
			listBox_cat.MouseDown += new System.Windows.Forms.MouseEventHandler(listBox_cat_MouseDown);
			panel7.Controls.Add(button_catrename);
			panel7.Controls.Add(button_delcat);
			panel7.Controls.Add(button_addcat);
			panel7.Location = new System.Drawing.Point(-3, 421);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(145, 40);
			panel7.TabIndex = 19;
			button_catrename.Location = new System.Drawing.Point(71, 5);
			button_catrename.Name = "button_catrename";
			button_catrename.Size = new System.Drawing.Size(69, 32);
			button_catrename.TabIndex = 17;
			button_catrename.Text = "改名";
			button_catrename.UseVisualStyleBackColor = true;
			button_catrename.Click += new System.EventHandler(button_catrename_Click);
			button_delcat.Font = new System.Drawing.Font("黑体", 18.5f);
			button_delcat.Location = new System.Drawing.Point(37, 5);
			button_delcat.Name = "button_delcat";
			button_delcat.Size = new System.Drawing.Size(32, 32);
			button_delcat.TabIndex = 0;
			button_delcat.Text = "-";
			button_delcat.UseVisualStyleBackColor = true;
			button_delcat.Click += new System.EventHandler(button_delcat_Click);
			button_addcat.Font = new System.Drawing.Font("黑体", 18.5f);
			button_addcat.Location = new System.Drawing.Point(5, 5);
			button_addcat.Name = "button_addcat";
			button_addcat.Size = new System.Drawing.Size(32, 32);
			button_addcat.TabIndex = 0;
			button_addcat.Text = "+";
			button_addcat.UseVisualStyleBackColor = true;
			button_addcat.Click += new System.EventHandler(button_addcat_Click);
			button_OK.Font = new System.Drawing.Font("黑体", 12.25f);
			button_OK.Location = new System.Drawing.Point(229, 782);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(113, 42);
			button_OK.TabIndex = 11;
			button_OK.Text = "确认";
			button_OK.UseVisualStyleBackColor = true;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			panel6.Controls.Add(button_clone);
			panel6.Controls.Add(button_rename);
			panel6.Controls.Add(button_rem);
			panel6.Controls.Add(button_add);
			panel6.Location = new System.Drawing.Point(151, 156);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(65, 261);
			panel6.TabIndex = 10;
			button_clone.Font = new System.Drawing.Font("黑体", 10.5f);
			button_clone.Location = new System.Drawing.Point(2, 91);
			button_clone.Name = "button_clone";
			button_clone.Size = new System.Drawing.Size(60, 35);
			button_clone.TabIndex = 6;
			button_clone.Text = "克隆";
			button_clone.UseVisualStyleBackColor = true;
			button_clone.Click += new System.EventHandler(button_clone_Click);
			button_rename.Font = new System.Drawing.Font("黑体", 10.5f);
			button_rename.Location = new System.Drawing.Point(2, 135);
			button_rename.Name = "button_rename";
			button_rename.Size = new System.Drawing.Size(60, 35);
			button_rename.TabIndex = 6;
			button_rename.Text = "改名";
			button_rename.UseVisualStyleBackColor = true;
			button_rename.Click += new System.EventHandler(button_rename_Click);
			label9.BackColor = System.Drawing.Color.Black;
			label9.Location = new System.Drawing.Point(150, 146);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(170, 6);
			label9.TabIndex = 18;
			label_cat.Font = new System.Drawing.Font("黑体", 15.75f);
			label_cat.Location = new System.Drawing.Point(180, 123);
			label_cat.Name = "label_cat";
			label_cat.Size = new System.Drawing.Size(125, 21);
			label_cat.TabIndex = 0;
			label_cat.Text = "贴片电容";
			label_cat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_cancel.Font = new System.Drawing.Font("黑体", 12.25f);
			button_cancel.Location = new System.Drawing.Point(540, 782);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(113, 42);
			button_cancel.TabIndex = 11;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			label14.BackColor = System.Drawing.Color.Red;
			label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label14.Font = new System.Drawing.Font("黑体", 13f);
			label14.ForeColor = System.Drawing.Color.White;
			label14.Location = new System.Drawing.Point(3, 123);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(134, 26);
			label14.TabIndex = 1;
			label14.Text = "分类";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			contextMenuStrip1.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { toolStripMenuItem_clone, toolStripSeparator1, toolStripMenuItem_rename, toolStripSeparator2, toolStripMenuItem_move });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(141, 82);
			toolStripMenuItem_clone.Name = "toolStripMenuItem_clone";
			toolStripMenuItem_clone.Size = new System.Drawing.Size(140, 22);
			toolStripMenuItem_clone.Text = "克隆";
			toolStripMenuItem_clone.Click += new System.EventHandler(toolStripMenuItem_clone_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
			toolStripMenuItem_rename.Name = "toolStripMenuItem_rename";
			toolStripMenuItem_rename.Size = new System.Drawing.Size(140, 22);
			toolStripMenuItem_rename.Text = "重命名";
			toolStripMenuItem_rename.Click += new System.EventHandler(toolStripMenuItem_rename_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
			toolStripMenuItem_move.Name = "toolStripMenuItem_move";
			toolStripMenuItem_move.Size = new System.Drawing.Size(140, 22);
			toolStripMenuItem_move.Text = "移动到…";
			toolStripMenuItem_move.Click += new System.EventHandler(toolStripMenuItem_move_Click);
			panel8.BackColor = System.Drawing.Color.White;
			panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel8.Controls.Add(numericUpDown_pin_slot);
			panel8.Controls.Add(panel4);
			panel8.Controls.Add(numericUpDown_side_dis);
			panel8.Controls.Add(numericUpDown_pin_width);
			panel8.Controls.Add(numericUpDown_pin_length);
			panel8.Controls.Add(comboBox_pinmode);
			panel8.Controls.Add(label15);
			panel8.Controls.Add(label16);
			panel8.Controls.Add(label17);
			panel8.Controls.Add(label11);
			panel8.Controls.Add(label5);
			panel8.Controls.Add(label6);
			panel8.Location = new System.Drawing.Point(904, 163);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(296, 641);
			panel8.TabIndex = 17;
			numericUpDown_pin_slot.DecimalPlaces = 2;
			numericUpDown_pin_slot.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pin_slot.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_pin_slot.Location = new System.Drawing.Point(157, 464);
			numericUpDown_pin_slot.Name = "numericUpDown_pin_slot";
			numericUpDown_pin_slot.Size = new System.Drawing.Size(94, 24);
			numericUpDown_pin_slot.TabIndex = 6;
			numericUpDown_pin_slot.ValueChanged += new System.EventHandler(numericUpDown_pin_slot_ValueChanged);
			panel4.BackColor = System.Drawing.Color.Black;
			panel4.Controls.Add(panel_pins);
			panel4.Location = new System.Drawing.Point(14, 65);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(264, 251);
			panel4.TabIndex = 5;
			panel_pins.BackColor = System.Drawing.Color.WhiteSmoke;
			panel_pins.Location = new System.Drawing.Point(26, 22);
			panel_pins.Name = "panel_pins";
			panel_pins.Size = new System.Drawing.Size(211, 205);
			panel_pins.TabIndex = 3;
			panel_pins.Paint += new System.Windows.Forms.PaintEventHandler(panel_pins_Paint);
			numericUpDown_side_dis.DecimalPlaces = 2;
			numericUpDown_side_dis.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_side_dis.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_side_dis.Location = new System.Drawing.Point(157, 436);
			numericUpDown_side_dis.Name = "numericUpDown_side_dis";
			numericUpDown_side_dis.Size = new System.Drawing.Size(94, 24);
			numericUpDown_side_dis.TabIndex = 4;
			numericUpDown_side_dis.ValueChanged += new System.EventHandler(numericUpDown_side_dis_ValueChanged);
			numericUpDown_pin_width.DecimalPlaces = 2;
			numericUpDown_pin_width.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pin_width.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_pin_width.Location = new System.Drawing.Point(157, 408);
			numericUpDown_pin_width.Name = "numericUpDown_pin_width";
			numericUpDown_pin_width.Size = new System.Drawing.Size(94, 24);
			numericUpDown_pin_width.TabIndex = 4;
			numericUpDown_pin_width.ValueChanged += new System.EventHandler(numericUpDown_pin_width_ValueChanged);
			numericUpDown_pin_length.DecimalPlaces = 2;
			numericUpDown_pin_length.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pin_length.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_pin_length.Location = new System.Drawing.Point(157, 381);
			numericUpDown_pin_length.Name = "numericUpDown_pin_length";
			numericUpDown_pin_length.Size = new System.Drawing.Size(94, 24);
			numericUpDown_pin_length.TabIndex = 4;
			numericUpDown_pin_length.ValueChanged += new System.EventHandler(numericUpDown_pin_length_ValueChanged);
			comboBox_pinmode.DisplayMember = "0";
			comboBox_pinmode.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_pinmode.FormattingEnabled = true;
			comboBox_pinmode.Items.AddRange(new object[6] { "无定义", "单引脚", "双引脚", "三引脚", "双排引脚", "四排引脚" });
			comboBox_pinmode.Location = new System.Drawing.Point(157, 331);
			comboBox_pinmode.Name = "comboBox_pinmode";
			comboBox_pinmode.Size = new System.Drawing.Size(121, 23);
			comboBox_pinmode.TabIndex = 2;
			comboBox_pinmode.Text = "单个管脚";
			comboBox_pinmode.SelectedIndexChanged += new System.EventHandler(comboBox_pinmode_SelectedIndexChanged);
			label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("黑体", 11f);
			label15.Location = new System.Drawing.Point(37, 410);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(95, 15);
			label15.TabIndex = 1;
			label15.Text = "引脚宽度/mm";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("黑体", 11f);
			label16.Location = new System.Drawing.Point(37, 439);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(103, 15);
			label16.TabIndex = 1;
			label16.Text = "双侧中心间距";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("黑体", 11f);
			label17.Location = new System.Drawing.Point(37, 468);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(103, 15);
			label17.TabIndex = 1;
			label17.Text = "引脚中心间距";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("黑体", 11f);
			label11.Location = new System.Drawing.Point(37, 382);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(95, 15);
			label11.TabIndex = 1;
			label11.Text = "引脚长度/mm";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 11f);
			label5.Location = new System.Drawing.Point(37, 333);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(71, 15);
			label5.TabIndex = 1;
			label5.Text = "封装模式";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.Font = new System.Drawing.Font("黑体", 13.75f);
			label6.Location = new System.Drawing.Point(10, 3);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(268, 59);
			label6.TabIndex = 0;
			label6.Text = "封装匹配视觉算法设置\r\n（可选）";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Oswald", 32f);
			label19.Location = new System.Drawing.Point(984, 33);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(141, 64);
			label19.TabIndex = 18;
			label19.Text = "HWGC";
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Oswald", 20f);
			label21.Location = new System.Drawing.Point(947, 90);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(214, 40);
			label21.TabIndex = 19;
			label21.Text = "Intelligent System";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightBlue;
			base.ClientSize = new System.Drawing.Size(1224, 821);
			base.Controls.Add(label19);
			base.Controls.Add(label21);
			base.Controls.Add(panel8);
			base.Controls.Add(panel3);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_LabPrintfoot";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Load += new System.EventHandler(Form_LabPrintfoot_Load);
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel_foot.ResumeLayout(false);
			panel_foot.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_offset).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_offset).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_height).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_angle).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_feederant_delay).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_threshold).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_collectrate).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delta).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_length).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_width).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_first_feederin).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_scanr_mm).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_delay2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_delay).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_downspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_downspeed2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_upspeed2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_downspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_delay).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_delay2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_downspeed2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_upspeed2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_upspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_upspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_chipbox_width).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_chipbox_length).EndInit();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel7.ResumeLayout(false);
			panel6.ResumeLayout(false);
			contextMenuStrip1.ResumeLayout(false);
			panel8.ResumeLayout(false);
			panel8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pin_slot).EndInit();
			panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDown_side_dis).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pin_width).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pin_length).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_LabPrintfoot(USR_INIT_DATA usr_init, int mode)
		{
			InitializeComponent();
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			USR_INIT = usr_init;
			FP_PATH = MainForm0.FP_PATH;
			comboBox_cameraType.Items.Add(STR.CAMERA_STR[1][USR_INIT.mLanguage]);
			comboBox_cameraType.Items.Add(STR.CAMERA_STR[2][USR_INIT.mLanguage]);
			comboBox_cameraType.Items.Add(STR.CAMERA_STR[3][USR_INIT.mLanguage]);
			string[] items = new string[10] { "500", "501", "502", "503", "504", "505", "506", "507", "508", "509" };
			comboBox_nozzle.Items.AddRange(items);
			comboBox_nozzle2.Items.AddRange(items);
			comboBox_provider.Items.Add(STR.PROVIDER_STR[0][USR_INIT.mLanguage]);
			comboBox_provider.Items.Add(STR.PROVIDER_STR[1][USR_INIT.mLanguage]);
			comboBox_provider.Items.Add(STR.PROVIDER_STR[2][USR_INIT.mLanguage]);
			comboBox_beltcolor.Items.Clear();
			comboBox_beltcolor.Items.AddRange(new string[3]
			{
				(new string[3] { "白色料带", "白色料帶", "White Belt" })[MainForm0.USR_INIT.mLanguage],
				(new string[3] { "黑色料带", "黑色料帶", "Black Belt" })[MainForm0.USR_INIT.mLanguage],
				(new string[3] { "透明料带", "透明料帶", "Transparent" })[MainForm0.USR_INIT.mLanguage]
			});
			comboBox_pinmode.Items.Clear();
			comboBox_pinmode.Items.AddRange(new string[4]
			{
				(new string[3] { "无定义", "無定義", "None" })[MainForm0.USR_INIT.mLanguage],
				(new string[3] { "单引脚", "單引腳", "Single Pin" })[MainForm0.USR_INIT.mLanguage],
				(new string[3] { "双引脚", "雙引腳", "Double Pins" })[MainForm0.USR_INIT.mLanguage],
				(new string[3] { "三引脚", "三引腳", "Triple Pins" })[MainForm0.USR_INIT.mLanguage]
			});
			for (int i = 0; i < 10; i++)
			{
				comboBox_feedertype.Items.Add(STR.FEEDER_STR[i][USR_INIT.mLanguage]);
			}
			flush_listBox1();
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "封装库", "封裝庫", "Footprint Lab" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label14,
				str = new string[3] { "分类", "分類", "Category" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_createfile,
				str = new string[3] { "新建文件库", "新建文件庫", "Create Lab File" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_addfile,
				str = new string[3] { "添加文件库", "添加文件庫", "Add Lab File" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_removefile,
				str = new string[3] { "移除文件库", "移除文件庫", "Remove Lab File" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_combinefile,
				str = new string[3] { "合并文件库", "合並文件庫", "Combine Lab File" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_catrename,
				str = new string[3] { "改名", "改名", "Rename" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_clone,
				str = new string[3] { "克隆", "克隆", "Clone" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_rename,
				str = new string[3] { "改名", "改名", "Rename" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_nickname,
				str = new string[3] { "别名", "別名", "Nick Name" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_collectpic,
				str = new string[3] { "采集", "采集", "Collect" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_importpic,
				str = new string[3] { "导入", "導入", "Import" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label8,
				str = new string[3] { "元件长度/mm", "元件長度/mm", "Chip Length/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label12,
				str = new string[3] { "元件宽度/mm", "元件寬度/mm", "Chip Width/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label32,
				str = new string[3] { "元件厚度/mm", "元件厚度/mm", "Chip Height/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "料带颜色", "料帶顏色", "Belt Color" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label10,
				str = new string[3] { "额外进料数量", "額外進料數量", "Extra Chips In" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label20,
				str = new string[3] { "同取容差/mm", "同取容差/mm", "Sync-Pick Tolerance/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label25,
				str = new string[3] { "相机类型", "相機類型", "Camera Type" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label26,
				str = new string[3] { "视觉算法", "視覺算法", "Visual Type" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label13,
				str = new string[3] { "视觉阈值", "視覺閾值", "Visual Threshold" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_isscanr,
				str = new string[3] { "专用扫描半径", "專用掃描半徑", "Special Scan-R" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_islowspeed,
				str = new string[3] { "降速搬运", "降速搬運", "Lowspeed Running" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_iscollect,
				str = new string[3] { "特征识别", "特征識別", "Charactors Check" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label29,
				str = new string[3] { "特征识别容差", "特征識別容差", "Charactors Check Tolerance" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label30,
				str = new string[3] { "出料延时", "出料延時", "Chip Out Delay" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label27,
				str = new string[3] { "供料类型", "供料類型", "Provider Type" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label24,
				str = new string[3] { "飞达型号", "飛達型號", "Feeder Type" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label23,
				str = new string[3] { "取料下压偏移/mm", "取料下壓偏移/mm", "Pick-H Pressure offset/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label22,
				str = new string[3] { "贴装下压偏移/mm", "貼裝下壓偏移/mm", "Mount-H Pressure offset/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label207,
				str = new string[3] { "进料角度", "進料角度", "Init Chip Angle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "主吸嘴", "主吸嘴", "Main Nozzle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "吸嘴类型", "吸嘴類型", "Nozzle Type" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label35,
				str = new string[3] { "取料上拉速度", "取料上拉速度", "Pick Up Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label34,
				str = new string[3] { "取料下伸速度", "取料下伸速度", "Pick Down Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label33,
				str = new string[3] { "取料延时/ms", "取料延時/ms", "Pick Delay/ms" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label38,
				str = new string[3] { "贴装上拉速度", "貼裝上拉速度", "Mount Up Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label37,
				str = new string[3] { "贴装下伸速度", "貼裝下伸速度", "Mount Down Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label36,
				str = new string[3] { "贴装延时/ms", "貼裝延時/ms", "Mount Delay/ms" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label39,
				str = new string[3] { "备用吸嘴", "備用吸嘴", "Second Nozzle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "封装匹配视觉算法设置（可选）", "封裝匹配視覺算法設置（可選）", "Footprint Macth Visual Algorithm Config (Optional)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "封装模式", "封裝模式", "Footprint Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "引脚长度/mm", "引腳長度/mm", "Pin Length/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label15,
				str = new string[3] { "引脚宽度/mm", "引腳寬度/mm", "Pin Width/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label16,
				str = new string[3] { "双侧中心间距/mm", "雙側中心間距/mm", "Center Distance/mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OK,
				str = new string[3] { "确认", "確認", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cancel,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_beltcolor
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			LanguageItem languageItem2 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_pinmode
			};
			array = (languageItem2.str = new string[3]);
			list.Add(languageItem2);
			LanguageItem languageItem3 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_provider
			};
			array = (languageItem3.str = new string[3]);
			list.Add(languageItem3);
			LanguageItem languageItem4 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_feedertype
			};
			array = (languageItem4.str = new string[3]);
			list.Add(languageItem4);
			LanguageItem languageItem5 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_visualType
			};
			array = (languageItem5.str = new string[3]);
			list.Add(languageItem5);
			LanguageItem languageItem6 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_nickname
			};
			array = (languageItem6.str = new string[3]);
			list.Add(languageItem6);
			LanguageItem languageItem7 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_cameraType
			};
			array = (languageItem7.str = new string[3]);
			list.Add(languageItem7);
			LanguageItem languageItem8 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_nozzle
			};
			array = (languageItem8.str = new string[3]);
			list.Add(languageItem8);
			LanguageItem languageItem9 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_nozzle2
			};
			array = (languageItem9.str = new string[3]);
			list.Add(languageItem9);
			LanguageItem languageItem10 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_length
			};
			array = (languageItem10.str = new string[3]);
			list.Add(languageItem10);
			LanguageItem languageItem11 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_width
			};
			array = (languageItem11.str = new string[3]);
			list.Add(languageItem11);
			LanguageItem languageItem12 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_height
			};
			array = (languageItem12.str = new string[3]);
			list.Add(languageItem12);
			LanguageItem languageItem13 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_first_feederin
			};
			array = (languageItem13.str = new string[3]);
			list.Add(languageItem13);
			LanguageItem languageItem14 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_delta
			};
			array = (languageItem14.str = new string[3]);
			list.Add(languageItem14);
			LanguageItem languageItem15 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_threshold
			};
			array = (languageItem15.str = new string[3]);
			list.Add(languageItem15);
			LanguageItem languageItem16 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_angle
			};
			array = (languageItem16.str = new string[3]);
			list.Add(languageItem16);
			LanguageItem languageItem17 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_collectrate
			};
			array = (languageItem17.str = new string[3]);
			list.Add(languageItem17);
			LanguageItem languageItem18 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_feederant_delay
			};
			array = (languageItem18.str = new string[3]);
			list.Add(languageItem18);
			LanguageItem languageItem19 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pik_offset
			};
			array = (languageItem19.str = new string[3]);
			list.Add(languageItem19);
			LanguageItem languageItem20 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_mnt_offset
			};
			array = (languageItem20.str = new string[3]);
			list.Add(languageItem20);
			LanguageItem languageItem21 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pik_upspeed
			};
			array = (languageItem21.str = new string[3]);
			list.Add(languageItem21);
			LanguageItem languageItem22 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pik_downspeed
			};
			array = (languageItem22.str = new string[3]);
			list.Add(languageItem22);
			LanguageItem languageItem23 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pik_delay
			};
			array = (languageItem23.str = new string[3]);
			list.Add(languageItem23);
			LanguageItem languageItem24 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_mnt_upspeed
			};
			array = (languageItem24.str = new string[3]);
			list.Add(languageItem24);
			LanguageItem languageItem25 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_mnt_downspeed
			};
			array = (languageItem25.str = new string[3]);
			list.Add(languageItem25);
			LanguageItem languageItem26 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_mnt_delay
			};
			array = (languageItem26.str = new string[3]);
			list.Add(languageItem26);
			LanguageItem languageItem27 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pik_upspeed2
			};
			array = (languageItem27.str = new string[3]);
			list.Add(languageItem27);
			LanguageItem languageItem28 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pik_downspeed2
			};
			array = (languageItem28.str = new string[3]);
			list.Add(languageItem28);
			LanguageItem languageItem29 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pik_delay2
			};
			array = (languageItem29.str = new string[3]);
			list.Add(languageItem29);
			LanguageItem languageItem30 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_mnt_upspeed2
			};
			array = (languageItem30.str = new string[3]);
			list.Add(languageItem30);
			LanguageItem languageItem31 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_mnt_downspeed2
			};
			array = (languageItem31.str = new string[3]);
			list.Add(languageItem31);
			LanguageItem languageItem32 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_mnt_delay2
			};
			array = (languageItem32.str = new string[3]);
			list.Add(languageItem32);
			LanguageItem languageItem33 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pin_length
			};
			array = (languageItem33.str = new string[3]);
			list.Add(languageItem33);
			LanguageItem languageItem34 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_pin_width
			};
			array = (languageItem34.str = new string[3]);
			list.Add(languageItem34);
			LanguageItem languageItem35 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = numericUpDown_side_dis
			};
			array = (languageItem35.str = new string[3]);
			list.Add(languageItem35);
			LanguageItem languageItem36 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = listBox2
			};
			array = (languageItem36.str = new string[3]);
			list.Add(languageItem36);
			LanguageItem languageItem37 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = listBox_cat
			};
			array = (languageItem37.str = new string[3]);
			list.Add(languageItem37);
			LanguageItem languageItem38 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_filename
			};
			array = (languageItem38.str = new string[3]);
			list.Add(languageItem38);
			LanguageItem languageItem39 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_name
			};
			array = (languageItem39.str = new string[3]);
			list.Add(languageItem39);
			return list;
		}

		private void flush_listBox1()
		{
			listBox1.Items.Clear();
			if (FP_PATH.mFootprintLib_NameList == null)
			{
				FP_PATH.mFootprintLib_NameList = new BindingList<string>();
			}
			if (FP_PATH.mFootprintLib_NameList.Count == 0)
			{
				panel7.Enabled = false;
				listBox_cat.Enabled = false;
				panel6.Enabled = false;
				listBox2.Enabled = false;
				panel_foot.Enabled = false;
			}
			for (int i = 0; i < FP_PATH.mFootprintLib_NameList.Count; i++)
			{
				listBox1.Items.Add(FP_PATH.mFootprintLib_NameList[i]);
			}
			if (FP_PATH.mFootprintLib_NameList.Count > 5)
			{
				listBox1.Size = new Size(listBox1.Size.Width, listBox1.Size.Height + (FP_PATH.mFootprintLib_NameList.Count - 5) * 15);
			}
			if (FP_PATH.mFootprintLib_Index >= FP_PATH.mFootprintLib_NameList.Count)
			{
				FP_PATH.mFootprintLib_Index = FP_PATH.mFootprintLib_NameList.Count - 1;
			}
			if (FP_PATH.mFootprintLib_Index >= 0 && FP_PATH.mFootprintLib_NameList.Count > 0)
			{
				panel7.Enabled = true;
				listBox_cat.Enabled = true;
				listBox1.SelectedIndex = FP_PATH.mFootprintLib_Index;
				label_filename.Text = FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index];
				mSubLib = MainForm0.load_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index]);
				flush_listBox2(mSubLib);
			}
			else
			{
				label_filename.Text = "";
				mSubLib = new USR_LIB();
				flush_listBox2(mSubLib);
			}
		}

		private void flush_listBox2(USR_LIB lib)
		{
			listBox_cat.Items.Clear();
			if (lib.fpcatlist == null)
			{
				lib.fpcatlist = new BindingList<FP_CAT>();
			}
			for (int i = 0; i < lib.fpcatlist.Count; i++)
			{
				listBox_cat.Items.Add(lib.fpcatlist[i].description);
			}
			if (lib.fpcatindex >= lib.fpcatlist.Count)
			{
				lib.fpcatindex = lib.fpcatlist.Count - 1;
			}
			if (lib.fpcatindex >= 0 && lib.fpcatindex < lib.fpcatlist.Count)
			{
				listBox_cat.SelectedIndex = lib.fpcatindex;
			}
			listBox2.Items.Clear();
			if (lib.fpcatlist.Count > 0 && lib.fpcatindex >= 0)
			{
				panel6.Enabled = true;
				listBox2.Enabled = true;
				BindingList<FootPrint> bindingList = null;
				int num = -1;
				if (lib.fpcatlist[lib.fpcatindex].footlist == null)
				{
					lib.fpcatlist[lib.fpcatindex].footlist = new BindingList<FootPrint>();
				}
				if (lib.fpcatlist[lib.fpcatindex].index >= lib.fpcatlist[lib.fpcatindex].footlist.Count)
				{
					lib.fpcatlist[lib.fpcatindex].index = lib.fpcatlist[lib.fpcatindex].footlist.Count - 1;
				}
				bindingList = lib.fpcatlist[lib.fpcatindex].footlist;
				num = lib.fpcatlist[lib.fpcatindex].index;
				label_cat.Text = lib.fpcatlist[lib.fpcatindex].description;
				for (int j = 0; j < bindingList.Count; j++)
				{
					listBox2.Items.Add(bindingList[j].name);
				}
				if (num >= 0)
				{
					listBox2.SelectedIndex = num;
				}
				flush_foot(lib);
			}
		}

		private void flush_foot(USR_LIB lib)
		{
			BindingList<FootPrint> bindingList = null;
			int num = -1;
			if (lib == null || lib.fpcatlist == null || (lib.fpcatlist.Count <= 0 && lib.fpcatindex < 0))
			{
				return;
			}
			if (lib.fpcatlist[lib.fpcatindex].footlist == null)
			{
				lib.fpcatlist[lib.fpcatindex].footlist = new BindingList<FootPrint>();
			}
			if (lib.fpcatlist[lib.fpcatindex].index >= lib.fpcatlist[lib.fpcatindex].footlist.Count)
			{
				lib.fpcatlist[lib.fpcatindex].index = lib.fpcatlist[lib.fpcatindex].footlist.Count - 1;
			}
			bindingList = lib.fpcatlist[lib.fpcatindex].footlist;
			num = lib.fpcatlist[lib.fpcatindex].index;
			if (bindingList != null && bindingList.Count > 0 && num >= 0)
			{
				if (num >= bindingList.Count)
				{
					num = (lib.fpcatlist[lib.fpcatindex].index = bindingList.Count - 1);
				}
				panel_foot.Enabled = true;
				label_name.Text = bindingList[num].name;
				numericUpDown_height.Value = (decimal)bindingList[num].height;
				numericUpDown_length.Value = (decimal)bindingList[num].length;
				numericUpDown_width.Value = (decimal)bindingList[num].width;
				numericUpDown_angle.Value = (decimal)bindingList[num].angle;
				numericUpDown_chipbox_length.Value = (decimal)bindingList[num].chipbox_length;
				numericUpDown_chipbox_width.Value = (decimal)bindingList[num].chipbox_width;
				numericUpDown_delta.Value = (decimal)bindingList[num].delta;
				numericUpDown_threshold.Value = bindingList[num].threshold;
				numericUpDown_collectrate.Value = (decimal)bindingList[num].collect_rate;
				numericUpDown_feederant_delay.Value = (decimal)bindingList[num].feeder_ant_delay;
				numericUpDown_scanr_mm.Value = (decimal)bindingList[num].scan_r_mm;
				numericUpDown_pik_offset.Value = (decimal)bindingList[num].pik_offset;
				numericUpDown_pik_upspeed.Value = bindingList[num].pik_up_speed;
				numericUpDown_pik_downspeed.Value = bindingList[num].pik_down_speed;
				numericUpDown_pik_delay.Value = bindingList[num].pik_delay;
				numericUpDown_mnt_offset.Value = (decimal)bindingList[num].mnt_offset;
				numericUpDown_mnt_upspeed.Value = bindingList[num].mnt_up_speed;
				numericUpDown_mnt_downspeed.Value = bindingList[num].mnt_down_speed;
				numericUpDown_mnt_delay.Value = bindingList[num].mnt_delay;
				numericUpDown_pik_upspeed2.Value = bindingList[num].pik_up_speed2;
				numericUpDown_pik_downspeed2.Value = bindingList[num].pik_down_speed2;
				numericUpDown_pik_delay2.Value = bindingList[num].pik_delay2;
				numericUpDown_mnt_upspeed2.Value = bindingList[num].mnt_up_speed2;
				numericUpDown_mnt_downspeed2.Value = bindingList[num].mnt_down_speed2;
				numericUpDown_mnt_delay2.Value = bindingList[num].mnt_delay2;
				numericUpDown_first_feederin.Value = bindingList[num].first_feederin;
				comboBox_cameraType.SelectedIndex = MainForm0.format_cameralist_index(bindingList[num].camera);
				comboBox_provider.SelectedIndex = MainForm0.format_providerlist_index(bindingList[num].providertype);
				comboBox_feedertype.SelectedIndex = MainForm0.format_feederlist_index(bindingList[num].feedertype);
				comboBox_beltcolor.SelectedIndex = bindingList[num].belt_color;
				comboBox_nozzle.SelectedIndex = bindingList[num].nozzle;
				comboBox_nozzle2.SelectedIndex = bindingList[num].nozzle2;
				checkBox_islowspeed.Checked = bindingList[num].islowspeed;
				checkBox_iscollect.Checked = bindingList[num].iscollect;
				checkBox_isscanr.Checked = bindingList[num].isscan_r;
				numericUpDown_pin_length.Value = (decimal)bindingList[num].pin_length;
				numericUpDown_pin_width.Value = (decimal)bindingList[num].pin_width;
				numericUpDown_side_dis.Value = (decimal)bindingList[num].side_dis;
				comboBox_pinmode.SelectedIndex = (int)bindingList[num].pin_mode;
				label_visualType.Text = STR.VISUAL_STR[(int)bindingList[num].visual][USR_INIT.mLanguage] + Environment.NewLine + STR.LOOP_STR[(int)bindingList[num].loop][USR_INIT.mLanguage];
				pictureBox1.Image = bindingList[num].pic;
				if (bindingList[num].nick_namelist == null)
				{
					bindingList[num].nick_namelist = new BindingList<string>();
				}
				label_nickname.Text = "";
				for (int i = 0; i < bindingList[num].nick_namelist.Count; i++)
				{
					Label label = label_nickname;
					label.Text = label.Text + bindingList[num].nick_namelist[i] + Environment.NewLine;
				}
			}
			else
			{
				panel_foot.Enabled = false;
				label_name.Text = "";
			}
		}

		private void button_createfile_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			string[] array = new string[3] { "封装库文件(*.footprint)|*.footprint", "封裝庫文件(*.footprint)|*.footprint", "Footprint Lib File(*.footprint)|*.footprint" };
			saveFileDialog.Filter = array[USR_INIT.mLanguage];
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Stream stream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				stream.Flush();
				stream.Close();
				MainForm0.save_footprint_file(saveFileDialog.FileName, new USR_LIB());
				FP_PATH.mFootprintLib_NameList.Add(saveFileDialog.FileName);
				FP_PATH.mFootprintLib_Index = FP_PATH.mFootprintLib_NameList.Count - 1;
				flush_listBox1();
			}
		}

		private void button_removefile_Click(object sender, EventArgs e)
		{
			if (FP_PATH.mFootprintLib_Index >= 0 && FP_PATH.mFootprintLib_Index < FP_PATH.mFootprintLib_NameList.Count)
			{
				FP_PATH.mFootprintLib_NameList.RemoveAt(FP_PATH.mFootprintLib_Index);
				flush_listBox1();
			}
		}

		private void button_addfile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string[] array = new string[3] { "封装库文件(*.footprint)|*.footprint", "封裝庫文件(*.footprint)|*.footprint", "Footprint Lib File(*.footprint)|*.footprint" };
			openFileDialog.Filter = array[USR_INIT.mLanguage];
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			for (int i = 0; i < FP_PATH.mFootprintLib_NameList.Count; i++)
			{
				if (openFileDialog.FileName == FP_PATH.mFootprintLib_NameList[i])
				{
					string[] array2 = new string[3] { "该库文件已经在列表中了！", "該庫文件已經在列表中了！", "This file has been added already!" };
					MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
					return;
				}
			}
			FP_PATH.mFootprintLib_NameList.Add(openFileDialog.FileName);
			FP_PATH.mFootprintLib_Index = FP_PATH.mFootprintLib_NameList.Count - 1;
			flush_listBox1();
		}

		private void button_add_Click(object sender, EventArgs e)
		{
			if (mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count == 0)
			{
				string[] array = new string[3] { "请新建一个分类", "請新建壹個分類", "Please Create a Catogery!" };
				MainForm0.CmMessageBoxTop_Ok(array[MainForm0.USR_INIT.mLanguage]);
				return;
			}
			if (mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				string[] array2 = new string[3] { "请选择一个分类", "請選擇壹個分類", "Please Select a Catogery!" };
				MainForm0.CmMessageBoxTop_Ok(array2[MainForm0.USR_INIT.mLanguage]);
				return;
			}
			string[] array3 = new string[3] { "新增一个封装", "新增壹個封裝", "Add a New Footprint!" };
			Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, array3[MainForm0.USR_INIT.mLanguage], "string");
			form_Fill.TopMost = true;
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			FootPrint footPrint = new FootPrint();
			footPrint.name = form_Fill.get_string();
			for (int i = 0; i < mSubLib.fpcatlist.Count; i++)
			{
				if (mSubLib.fpcatlist[i].footlist == null)
				{
					mSubLib.fpcatlist[i].footlist = new BindingList<FootPrint>();
				}
				for (int j = 0; j < mSubLib.fpcatlist[i].footlist.Count; j++)
				{
					if (footPrint.name == mSubLib.fpcatlist[i].footlist[j].name)
					{
						string[] array4 = new string[3] { "该封装名称已经存在，新增失败！", "該封裝名稱已經存在，新增失敗！", "Added fail, since this footprint name has been added already!" };
						MainForm0.CmMessageBoxTop_Ok(array4[MainForm0.USR_INIT.mLanguage]);
						return;
					}
					if (mSubLib.fpcatlist[i].footlist[j].nick_namelist == null)
					{
						continue;
					}
					for (int k = 0; k < mSubLib.fpcatlist[i].footlist[j].nick_namelist.Count; k++)
					{
						if (footPrint.name == mSubLib.fpcatlist[i].footlist[j].nick_namelist[k])
						{
							string[] array5 = new string[3]
							{
								"该封装名称已经存在" + mSubLib.fpcatlist[i].footlist[j].name + "的别名中，新增失败！",
								"該封裝名稱已經存在" + mSubLib.fpcatlist[i].footlist[j].name + "的別名中，新增失敗！",
								"Added fail, since this footprint name has been added already!"
							};
							MainForm0.CmMessageBoxTop_Ok(array5[MainForm0.USR_INIT.mLanguage]);
							return;
						}
					}
				}
			}
			mSubLib.fpcatlist[mSubLib.fpcatindex].footlist.Add(footPrint);
			mSubLib.fpcatlist[mSubLib.fpcatindex].index = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist.Count - 1;
			flush_listBox2(mSubLib);
			MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
		}

		private void button_clone_Click(object sender, EventArgs e)
		{
			if (mSubLib == null)
			{
				return;
			}
			if (mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count == 0)
			{
				string[] array = new string[3] { "没有分类！", "沒有分類！", "None Category!" };
				MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
				return;
			}
			if (mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				string[] array2 = new string[3] { "请选择一个分类！", "請選擇壹個分類！", "Please Select a Category!" };
				MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist == null || footlist.Count <= 0 || index < 0 || index >= footlist.Count)
			{
				return;
			}
			string name = footlist[index].name;
			string[] array3 = new string[3]
			{
				"从" + name + "克隆一个新的封装",
				"從" + name + "克隆壹個新的封裝",
				"Clone a new footprint from " + name
			};
			Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, array3[USR_INIT.mLanguage], "string");
			form_Fill.set_string(name + "_?");
			form_Fill.TopMost = true;
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			FootPrint footPrint = new FootPrint(footlist[index]);
			footPrint.name = form_Fill.get_string();
			for (int i = 0; i < mSubLib.fpcatlist.Count; i++)
			{
				if (mSubLib.fpcatlist[i].footlist == null)
				{
					mSubLib.fpcatlist[i].footlist = new BindingList<FootPrint>();
				}
				for (int j = 0; j < mSubLib.fpcatlist[i].footlist.Count; j++)
				{
					if (footPrint.name == mSubLib.fpcatlist[i].footlist[j].name)
					{
						MainForm0.CmMessageBoxTop_Ok(array3[USR_INIT.mLanguage]);
						return;
					}
					if (mSubLib.fpcatlist[i].footlist[j].nick_namelist == null)
					{
						continue;
					}
					for (int k = 0; k < mSubLib.fpcatlist[i].footlist[j].nick_namelist.Count; k++)
					{
						if (footPrint.name == mSubLib.fpcatlist[i].footlist[j].nick_namelist[k])
						{
							_ = "该封装名称已经存在" + mSubLib.fpcatlist[i].footlist[j].name + "的别名中，新增失败！";
							_ = "該封裝名稱已經存在" + mSubLib.fpcatlist[i].footlist[j].name + "的別名中，新增失敗！";
							MainForm0.CmMessageBoxTop_Ok(array3[USR_INIT.mLanguage]);
							return;
						}
					}
				}
			}
			mSubLib.fpcatlist[mSubLib.fpcatindex].footlist.Add(footPrint);
			mSubLib.fpcatlist[mSubLib.fpcatindex].index = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist.Count - 1;
			flush_listBox2(mSubLib);
			MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
		}

		private void toolStripMenuItem_clone_Click(object sender, EventArgs e)
		{
			button_clone_Click(sender, e);
		}

		private void toolStripMenuItem_rename_Click(object sender, EventArgs e)
		{
			footprint_rename();
		}

		private void button_rename_Click(object sender, EventArgs e)
		{
			footprint_rename();
		}

		public void footprint_rename()
		{
			if (mSubLib == null)
			{
				return;
			}
			if (mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count == 0)
			{
				string[] array = new string[3] { "没有分类！", "沒有分類！", "None Category!" };
				MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
				return;
			}
			if (mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				string[] array2 = new string[3] { "请选择一个分类！", "請選擇壹個分類！", "Please Select a Category!" };
				MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist == null || footlist.Count <= 0 || index < 0 || index >= footlist.Count)
			{
				return;
			}
			string name = footlist[index].name;
			string[] array3 = new string[3] { "重命名", "重命名", "Rename!" };
			Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, array3[USR_INIT.mLanguage], "string");
			form_Fill.set_string(name);
			form_Fill.TopMost = true;
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string @string = form_Fill.get_string();
			for (int i = 0; i < mSubLib.fpcatlist.Count; i++)
			{
				if (mSubLib.fpcatlist[i].footlist == null)
				{
					mSubLib.fpcatlist[i].footlist = new BindingList<FootPrint>();
				}
				for (int j = 0; j < mSubLib.fpcatlist[i].footlist.Count; j++)
				{
					if (@string == mSubLib.fpcatlist[i].footlist[j].name)
					{
						MainForm0.CmMessageBoxTop_Ok(array3[USR_INIT.mLanguage]);
						return;
					}
					if (mSubLib.fpcatlist[i].footlist[j].nick_namelist == null)
					{
						continue;
					}
					for (int k = 0; k < mSubLib.fpcatlist[i].footlist[j].nick_namelist.Count; k++)
					{
						if (@string == mSubLib.fpcatlist[i].footlist[j].nick_namelist[k])
						{
							_ = "该封装名称已经存在" + mSubLib.fpcatlist[i].footlist[j].name + "的别名中，新增失败！";
							_ = "該封裝名稱已經存在" + mSubLib.fpcatlist[i].footlist[j].name + "的別名中，新增失敗！";
							MainForm0.CmMessageBoxTop_Ok(array3[USR_INIT.mLanguage]);
							return;
						}
					}
				}
			}
			mSubLib.fpcatlist[mSubLib.fpcatindex].footlist[index].name = @string;
			flush_listBox2(mSubLib);
			MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
		}

		private void button_rem_Click(object sender, EventArgs e)
		{
			if (mSubLib == null)
			{
				return;
			}
			if (mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count == 0)
			{
				string[] array = new string[3] { "没有分类！", "沒有分類！", "None Category!" };
				MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
				return;
			}
			if (mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				string[] array2 = new string[3] { "请选择一个分类！", "請選擇壹個分類！", "Please Select a Category!" };
				MainForm0.CmMessageBoxTop_Ok(array2[USR_INIT.mLanguage]);
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count > 0 && index >= 0 && index < footlist.Count)
			{
				string[] array3 = new string[3]
				{
					"是否删除" + footlist[index].name + "封装?",
					"是否删除" + footlist[index].name + "封装?",
					"Confirm to delete footprint " + footlist[index].name + "?"
				};
				if (MainForm0.CmMessageBox(array3[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					footlist.RemoveAt(index);
					flush_listBox2(mSubLib);
				}
			}
		}

		private void numericUpDown_height_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].height = (float)numericUpDown_height.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_length_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].length = (float)numericUpDown_length.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_width_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].width = (float)numericUpDown_width.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_delta_ValueChanged(object sender, EventArgs e)
		{
			if (USR_INIT != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].delta = (float)numericUpDown_delta.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void comboBox_cameraType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (USR_INIT != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count && comboBox_cameraType.SelectedIndex != -1)
				{
					CameraType[] array = new CameraType[3]
					{
						CameraType.Fast,
						CameraType.High,
						CameraType.None
					};
					footlist[index].camera = array[comboBox_cameraType.SelectedIndex];
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_threshold_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].threshold = (int)numericUpDown_threshold.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_collectrate_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].collect_rate = (float)numericUpDown_collectrate.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void checkBox_islowspeed_CheckedChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].islowspeed = checkBox_islowspeed.Checked;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void checkBox_iscollect_CheckedChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].iscollect = checkBox_iscollect.Checked;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void label_visualType_Click(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				Form_VisualTab form_VisualTab = new Form_VisualTab(footlist[index].visual, footlist[index].loop);
				form_VisualTab.TopMost = true;
				if (form_VisualTab.ShowDialog() == DialogResult.OK)
				{
					footlist[index].visual = form_VisualTab.get_visualtype();
					footlist[index].loop = form_VisualTab.get_looptype();
					label_visualType.Text = STR.VISUAL_STR[(int)footlist[index].visual][USR_INIT.mLanguage] + Environment.NewLine + STR.LOOP_STR[(int)footlist[index].loop][USR_INIT.mLanguage];
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void comboBox_nozzle_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].nozzle = comboBox_nozzle.SelectedIndex;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void comboBox_nozzle2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].nozzle2 = comboBox_nozzle2.SelectedIndex;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void comboBox_provider_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (USR_INIT != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].providertype = (ProviderType)comboBox_provider.SelectedIndex;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void comboBox_feedertype_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (USR_INIT != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].feedertype = (FeederType)comboBox_feedertype.SelectedIndex;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_pik_offset_ValueChanged(object sender, EventArgs e)
		{
			if (USR_INIT != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].pik_offset = (float)numericUpDown_pik_offset.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_mnt_offset_ValueChanged(object sender, EventArgs e)
		{
			if (USR_INIT != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].mnt_offset = (float)numericUpDown_mnt_offset.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_pik_upspeed_ValueChanged(object sender, EventArgs e)
		{
			if (USR_INIT == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				NumericUpDown numericUpDown = (NumericUpDown)sender;
				string text = numericUpDown.Tag.ToString();
				if (text == "0")
				{
					footlist[index].pik_up_speed = (int)numericUpDown.Value;
				}
				else if (text == "1")
				{
					footlist[index].pik_up_speed2 = (int)numericUpDown.Value;
				}
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
		}

		private void numericUpDown_mnt_upspeed_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				NumericUpDown numericUpDown = (NumericUpDown)sender;
				string text = numericUpDown.Tag.ToString();
				if (text == "0")
				{
					footlist[index].mnt_up_speed = (int)numericUpDown.Value;
				}
				else if (text == "1")
				{
					footlist[index].mnt_up_speed2 = (int)numericUpDown.Value;
				}
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
		}

		private void numericUpDown_pik_downspeed_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				NumericUpDown numericUpDown = (NumericUpDown)sender;
				string text = numericUpDown.Tag.ToString();
				if (text == "0")
				{
					footlist[index].pik_down_speed = (int)numericUpDown.Value;
				}
				else if (text == "1")
				{
					footlist[index].pik_down_speed2 = (int)numericUpDown.Value;
				}
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
		}

		private void numericUpDown_mnt_downspeed_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				NumericUpDown numericUpDown = (NumericUpDown)sender;
				string text = numericUpDown.Tag.ToString();
				if (text == "0")
				{
					footlist[index].mnt_down_speed = (int)numericUpDown.Value;
				}
				else if (text == "1")
				{
					footlist[index].mnt_down_speed2 = (int)numericUpDown.Value;
				}
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
		}

		private void numericUpDown_pik_delay_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				NumericUpDown numericUpDown = (NumericUpDown)sender;
				string text = numericUpDown.Tag.ToString();
				if (text == "0")
				{
					footlist[index].pik_delay = (int)numericUpDown.Value;
				}
				else if (text == "1")
				{
					footlist[index].pik_delay2 = (int)numericUpDown.Value;
				}
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
		}

		private void numericUpDown_mnt_delay_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				NumericUpDown numericUpDown = (NumericUpDown)sender;
				string text = numericUpDown.Tag.ToString();
				if (text == "0")
				{
					footlist[index].mnt_delay = (int)numericUpDown.Value;
				}
				else if (text == "1")
				{
					footlist[index].mnt_delay2 = (int)numericUpDown.Value;
				}
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void numericUpDown_feederant_delay_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].feeder_ant_delay = (float)numericUpDown_feederant_delay.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void checkBox_isscanr_CheckedChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].isscan_r = checkBox_isscanr.Checked;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_angle_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].angle = (float)numericUpDown_angle.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void Form_LabPrintfoot_Load(object sender, EventArgs e)
		{
			tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);
			tableLayoutPanel3.SuspendLayout();
			pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			MainForm0.CreateAddButtonPic(button_createfile);
			MainForm0.CreateAddButtonPic(button_addfile);
			MainForm0.CreateAddButtonPic(button_removefile);
			MainForm0.CreateAddButtonPic(button_combinefile);
			MainForm0.CreateAddButtonPic(button_collectpic);
			MainForm0.CreateAddButtonPic(button_add);
			MainForm0.CreateAddButtonPic(button_rem);
			MainForm0.CreateAddButtonPic(button_clone);
			MainForm0.CreateAddButtonPic(button_rename);
			MainForm0.CreateAddButtonPic(button_importpic);
			MainForm0.CreateAddButtonPic(button_addcat);
			MainForm0.CreateAddButtonPic(button_delcat);
			MainForm0.CreateAddButtonPic(button_catrename);
			MainForm0.CreateAddButtonPic(button_nickname);
			MainForm0.CreateAddButtonPic(button_OK);
			MainForm0.CreateAddButtonPic(button_cancel);
		}

		private void numericUpDown_first_feederin_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].first_feederin = (int)numericUpDown_first_feederin.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void comboBox_beltcolor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count && comboBox_beltcolor.SelectedIndex != -1)
				{
					footlist[index].belt_color = comboBox_beltcolor.SelectedIndex;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void button_addcat_Click(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null)
			{
				if (mSubLib.fpcatlist == null)
				{
					mSubLib.fpcatlist = new BindingList<FP_CAT>();
				}
				string[] array = new string[3] { "新增一个分类", "新增一个分类", "Add a new Catogery" };
				Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, array[USR_INIT.mLanguage], "string");
				form_Fill.TopMost = true;
				if (form_Fill.ShowDialog() == DialogResult.OK)
				{
					FP_CAT fP_CAT = new FP_CAT();
					fP_CAT.description = form_Fill.get_string();
					mSubLib.fpcatlist.Add(fP_CAT);
					mSubLib.fpcatindex = mSubLib.fpcatlist.Count - 1;
					flush_listBox2(mSubLib);
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void button_delcat_Click(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				string description = mSubLib.fpcatlist[mSubLib.fpcatindex].description;
				string[] array = new string[3]
				{
					"是否确定删除" + description + "分类?",
					"是否確定刪除" + description + "分類?",
					"Confirm to delete catogery " + description
				};
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					mSubLib.fpcatlist.RemoveAt(mSubLib.fpcatindex);
					flush_listBox2(mSubLib);
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void button_catrename_Click(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null)
			{
				return;
			}
			if (mSubLib.fpcatlist == null)
			{
				mSubLib.fpcatlist = new BindingList<FP_CAT>();
			}
			if (mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				string[] array = new string[3] { "分类重命名", "分類重命名", "Catogery Rename" };
				Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, array[USR_INIT.mLanguage], "string");
				form_Fill.set_string(mSubLib.fpcatlist[mSubLib.fpcatindex].description);
				form_Fill.TopMost = true;
				if (form_Fill.ShowDialog() == DialogResult.OK)
				{
					mSubLib.fpcatlist[mSubLib.fpcatindex].description = form_Fill.get_string();
					flush_listBox2(mSubLib);
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void listBox2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right || FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				toolStripMenuItem_move.DropDownItems.Clear();
				for (int i = 0; i < mSubLib.fpcatlist.Count; i++)
				{
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(mSubLib.fpcatlist[i].description);
					toolStripMenuItem.Click += tp_move_sel;
					toolStripMenuItem.Tag = i;
					toolStripMenuItem_move.DropDownItems.Add(toolStripMenuItem);
				}
				contextMenuStrip1.Show(Control.MousePosition.X, Control.MousePosition.Y);
			}
		}

		private void tp_move_sel(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			int index = (int)toolStripMenuItem.Tag;
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index2 = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index2 >= 0 && index2 < footlist.Count)
				{
					mSubLib.fpcatlist[index].footlist.Add(footlist[index2]);
					footlist.RemoveAt(index2);
					flush_listBox2(mSubLib);
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void listBox_cat_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void listBox1_MouseClick(object sender, MouseEventArgs e)
		{
			FP_PATH.mFootprintLib_Index = listBox1.SelectedIndex;
			if (FP_PATH.mFootprintLib_Index < 0)
			{
				label_filename.Text = "";
				listBox2.Items.Clear();
			}
			else
			{
				label_filename.Text = FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index];
				mSubLib = MainForm0.load_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index]);
				flush_listBox2(mSubLib);
			}
		}

		private void listBox2_MouseClick(object sender, MouseEventArgs e)
		{
			if (mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				mSubLib.fpcatlist[mSubLib.fpcatindex].index = listBox2.SelectedIndex;
				flush_foot(mSubLib);
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
		}

		private void listBox_cat_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && USR_INIT != null && mSubLib != null)
			{
				_ = mSubLib.fpcatlist;
			}
		}

		private void listBox_cat_MouseClick(object sender, MouseEventArgs e)
		{
			if (mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				mSubLib.fpcatindex = listBox_cat.SelectedIndex;
				flush_listBox2(mSubLib);
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
		}

		private void toolStripMenuItem_move_Click(object sender, EventArgs e)
		{
		}

		private void button_importpic_Click(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff|Windows Bitmap(*.bmp)|*.bmp|Windows Icon(*.ico)|*.ico|Graphics Interchange Format (*.gif)|(*.gif)|JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|Portable Network Graphics (*.png)|*.png|Tag Image File Format (*.tif)|*.tif;*.tiff";
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					footlist[index].pic = new Bitmap(openFileDialog.FileName);
					pictureBox1.Image = footlist[index].pic;
					flush_listBox2(mSubLib);
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void button_nickname_Click(object sender, EventArgs e)
		{
			if (FP_PATH == null || mSubLib == null || mSubLib.fpcatlist == null || mSubLib.fpcatlist.Count <= 0 || mSubLib.fpcatindex < 0 || mSubLib.fpcatindex >= mSubLib.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
			int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
			if (footlist == null || footlist.Count == 0 || index < 0 || index >= footlist.Count)
			{
				return;
			}
			Form_Fill_Text form_Fill_Text = new Form_Fill_Text(footlist[index].nick_namelist);
			form_Fill_Text.TopMost = true;
			if (form_Fill_Text.ShowDialog() == DialogResult.OK)
			{
				BindingList<string> strings = form_Fill_Text.get_strings();
				if (footlist[index].nick_namelist == null)
				{
					footlist[index].nick_namelist = new BindingList<string>();
				}
				footlist[index].nick_namelist.Clear();
				label_nickname.Text = "";
				if (strings != null)
				{
					for (int i = 0; i < strings.Count; i++)
					{
						footlist[index].nick_namelist.Add(strings[i]);
						Label label = label_nickname;
						label.Text = label.Text + strings[i] + Environment.NewLine;
					}
				}
				MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
			}
			MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
		}

		private void panel_pins_Paint(object sender, PaintEventArgs e)
		{
			flush_paint();
		}

		private void flush_paint()
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist == null || footlist.Count == 0 || index < 0 || index >= footlist.Count)
				{
					return;
				}
				int num = panel_pins.Size.Width;
				int num2 = panel_pins.Size.Height;
				if (footlist[index].pin_mode == PinMode.SinglePin)
				{
					if (footlist[index].pin_length > 0f && footlist[index].pin_width > 0f)
					{
						Graphics graphics = panel_pins.CreateGraphics();
						graphics.Clear(Color.Black);
						SolidBrush solidBrush = new SolidBrush(Color.LightYellow);
						Pen pen = new Pen(Color.Red, 2f);
						int num3 = 0;
						int num4 = 0;
						if (footlist[index].pin_length * (float)num2 > footlist[index].pin_width * (float)num)
						{
							num3 = num;
							num4 = (int)((float)num3 * footlist[index].pin_width / footlist[index].pin_length);
						}
						else
						{
							num4 = num2;
							num3 = (int)((float)num4 * footlist[index].pin_length / footlist[index].pin_width);
						}
						int num5 = (num - num3) / 2;
						int num6 = (num2 - num4) / 2;
						graphics.FillRectangle(solidBrush, num5, num6, num3, num4);
						graphics.DrawRectangle(pen, num5, num6, num3, num4);
						pen.Dispose();
						solidBrush.Dispose();
						graphics.Dispose();
						return;
					}
				}
				else if (footlist[index].pin_mode == PinMode.DoublePins)
				{
					if (footlist[index].pin_length > 0f && footlist[index].pin_width > 0f)
					{
						Graphics graphics2 = panel_pins.CreateGraphics();
						graphics2.Clear(Color.Black);
						SolidBrush solidBrush2 = new SolidBrush(Color.LightYellow);
						Pen pen2 = new Pen(Color.Red, 2f);
						int num7 = 0;
						int num8 = 0;
						int num9 = 0;
						float num10 = footlist[index].pin_length + footlist[index].side_dis;
						if (num10 * (float)num2 > footlist[index].pin_width * (float)num)
						{
							num9 = num;
							num7 = (int)((float)num9 * footlist[index].pin_length / num10);
							num8 = (int)((float)num * footlist[index].pin_width / num10);
						}
						else
						{
							num8 = num2;
							num9 = (int)((float)num2 * num10 / footlist[index].pin_width);
							num7 = (int)((float)num9 * footlist[index].pin_length / num10);
						}
						int num11 = (num - num9) / 2;
						int num12 = (num - num9) / 2 + (num9 - num7);
						int num13 = (num2 - num8) / 2;
						graphics2.FillRectangle(solidBrush2, num11, num13, num7, num8);
						graphics2.FillRectangle(solidBrush2, num12, num13, num7, num8);
						graphics2.DrawRectangle(pen2, num11, num13, num9, num8);
						pen2.Dispose();
						solidBrush2.Dispose();
						graphics2.Dispose();
						return;
					}
				}
				else if (footlist[index].pin_mode == PinMode.TriblePins && footlist[index].pin_length > 0f && footlist[index].pin_width > 0f)
				{
					Graphics graphics3 = panel_pins.CreateGraphics();
					graphics3.Clear(Color.Black);
					SolidBrush solidBrush3 = new SolidBrush(Color.LightYellow);
					Pen pen3 = new Pen(Color.Red, 2f);
					int num14 = 0;
					int num15 = 0;
					int num16 = 0;
					int num17 = 0;
					float num18 = footlist[index].pin_length + footlist[index].side_dis;
					float num19 = footlist[index].pin_width + footlist[index].pin_slot;
					if (num18 * (float)num2 > num19 * (float)num)
					{
						num16 = num;
						num14 = (int)((float)num16 * footlist[index].pin_length / num18);
						num15 = (int)(footlist[index].pin_width * (float)num14 / footlist[index].pin_length);
						num17 = (int)((float)num * num19 / num18);
					}
					else
					{
						num17 = num2;
						num16 = (int)((float)num2 * num18 / num19);
						num14 = (int)((float)num16 * footlist[index].pin_length / num18);
						num15 = (int)(footlist[index].pin_width * (float)num14 / footlist[index].pin_length);
					}
					int num20 = (num - num16) / 2;
					int num21 = (num2 - num15) / 2;
					int num22 = (num - num16) / 2 + (num16 - num14);
					int num23 = (num2 - num17) / 2;
					int num24 = (num - num16) / 2 + (num16 - num14);
					int num25 = (num2 - num17) / 2 + (num17 - num15);
					int num26 = (num - num16) / 2;
					int num27 = (num2 - num17) / 2;
					graphics3.FillRectangle(solidBrush3, num20, num21, num14, num15);
					graphics3.FillRectangle(solidBrush3, num22, num23, num14, num15);
					graphics3.FillRectangle(solidBrush3, num24, num25, num14, num15);
					graphics3.DrawRectangle(pen3, num26, num27, num16, num17);
					pen3.Dispose();
					solidBrush3.Dispose();
					graphics3.Dispose();
					return;
				}
			}
			Graphics graphics4 = panel_pins.CreateGraphics();
			graphics4.Clear(Color.Black);
			graphics4.Dispose();
		}

		private void numericUpDown_pin_length_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].pin_length = (float)numericUpDown_pin_length.Value;
					flush_paint();
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_pin_width_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].pin_width = (float)numericUpDown_pin_width.Value;
					flush_paint();
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_side_dis_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].side_dis = (float)numericUpDown_side_dis.Value;
					flush_paint();
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void numericUpDown_pin_slot_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].pin_slot = (float)numericUpDown_pin_slot.Value;
					flush_paint();
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void comboBox_pinmode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].pin_mode = (PinMode)comboBox_pinmode.SelectedIndex;
					flush_pinmode_setting(footlist[index].pin_mode);
					flush_paint();
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}

		private void flush_pinmode_setting(PinMode pin_mode)
		{
			switch (pin_mode)
			{
			case PinMode.None:
			{
				NumericUpDown numericUpDown13 = numericUpDown_pin_length;
				bool visible13 = (label11.Visible = false);
				numericUpDown13.Visible = visible13;
				NumericUpDown numericUpDown14 = numericUpDown_pin_width;
				bool visible14 = (label15.Visible = false);
				numericUpDown14.Visible = visible14;
				NumericUpDown numericUpDown15 = numericUpDown_side_dis;
				bool visible15 = (label16.Visible = false);
				numericUpDown15.Visible = visible15;
				NumericUpDown numericUpDown16 = numericUpDown_pin_slot;
				bool visible16 = (label17.Visible = false);
				numericUpDown16.Visible = visible16;
				break;
			}
			case PinMode.SinglePin:
			{
				NumericUpDown numericUpDown9 = numericUpDown_pin_length;
				bool visible9 = (label11.Visible = true);
				numericUpDown9.Visible = visible9;
				NumericUpDown numericUpDown10 = numericUpDown_pin_width;
				bool visible10 = (label15.Visible = true);
				numericUpDown10.Visible = visible10;
				NumericUpDown numericUpDown11 = numericUpDown_side_dis;
				bool visible11 = (label16.Visible = false);
				numericUpDown11.Visible = visible11;
				NumericUpDown numericUpDown12 = numericUpDown_pin_slot;
				bool visible12 = (label17.Visible = false);
				numericUpDown12.Visible = visible12;
				break;
			}
			case PinMode.DoublePins:
			{
				NumericUpDown numericUpDown5 = numericUpDown_pin_length;
				bool visible5 = (label11.Visible = true);
				numericUpDown5.Visible = visible5;
				NumericUpDown numericUpDown6 = numericUpDown_pin_width;
				bool visible6 = (label15.Visible = true);
				numericUpDown6.Visible = visible6;
				NumericUpDown numericUpDown7 = numericUpDown_side_dis;
				bool visible7 = (label16.Visible = true);
				numericUpDown7.Visible = visible7;
				NumericUpDown numericUpDown8 = numericUpDown_pin_slot;
				bool visible8 = (label17.Visible = false);
				numericUpDown8.Visible = visible8;
				break;
			}
			case PinMode.TriblePins:
			{
				NumericUpDown numericUpDown = numericUpDown_pin_length;
				bool visible = (label11.Visible = true);
				numericUpDown.Visible = visible;
				NumericUpDown numericUpDown2 = numericUpDown_pin_width;
				bool visible2 = (label15.Visible = true);
				numericUpDown2.Visible = visible2;
				NumericUpDown numericUpDown3 = numericUpDown_side_dis;
				bool visible3 = (label16.Visible = true);
				numericUpDown3.Visible = visible3;
				NumericUpDown numericUpDown4 = numericUpDown_pin_slot;
				bool visible4 = (label17.Visible = true);
				numericUpDown4.Visible = visible4;
				break;
			}
			}
		}

		private void numericUpDown_scanr_mm_ValueChanged(object sender, EventArgs e)
		{
			if (FP_PATH != null && mSubLib != null && mSubLib.fpcatlist != null && mSubLib.fpcatlist.Count > 0 && mSubLib.fpcatindex >= 0 && mSubLib.fpcatindex < mSubLib.fpcatlist.Count)
			{
				BindingList<FootPrint> footlist = mSubLib.fpcatlist[mSubLib.fpcatindex].footlist;
				int index = mSubLib.fpcatlist[mSubLib.fpcatindex].index;
				if (footlist != null && footlist.Count != 0 && index >= 0 && index < footlist.Count)
				{
					footlist[index].scan_r_mm = (float)numericUpDown_scanr_mm.Value;
					MainForm0.save_footprint_file(FP_PATH.mFootprintLib_NameList[FP_PATH.mFootprintLib_Index], mSubLib);
				}
			}
		}
	}
}
