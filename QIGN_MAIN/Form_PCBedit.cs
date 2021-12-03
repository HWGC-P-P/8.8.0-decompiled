using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON;
using QIGN_COMMON.vs_Forms;

namespace QIGN_MAIN
{
	public class Form_PCBedit : Form
	{
		private IContainer components;

		private TextBox textBox_value;

		private Label label1;

		private Label label2;

		private TextBox textBox_footprint;

		private Label label3;

		private NumericUpDown numericUpDown_a;

		private Label label4;

		private ComboBox comboBox_stacktype;

		private Label label5;

		private Label label6;

		private Label label7;

		private ComboBox comboBox_cam;

		private NumericUpDown numericUpDown_x;

		private Label label8;

		private Label label9;

		private NumericUpDown numericUpDown_y;

		private Label label11;

		private Button button_ok;

		private Button button_cancel;

		private TextBox textBox_label;

		private CheckBox checkBox_synctoarray;

		private TextBox textBox_array;

		private Label label10;

		private NumericUpDown numericUpDown_stackno;

		private Label label12;

		private NumericUpDown numericUpDown_nozzle;

		private Label label13;

		private NumericUpDown numericUpDown_group;

		private CheckBox checkBox_lowspeed;

		private Panel panel1;

		private Panel panel_1;

		private Panel panel_0;

		private CheckBox checkBox_change0;

		private CheckBox checkBox_change1;

		private CheckBox checkBox_IsMount;

		private Panel panel2;

		private Button button_visual;

		private Label label14;

		private Label label15;

		public USR3_DATA USR3;

		public BindingList<ChipBoardElement> mOnlyone;

		public CameraType[] mCams = new CameraType[3]
		{
			CameraType.Fast,
			CameraType.High,
			CameraType.None
		};

		public ProviderType[] mProviders = new ProviderType[3]
		{
			ProviderType.Feedr,
			ProviderType.Plate,
			ProviderType.Vibra
		};

		public VisualType m_VisualType;

		public LoopType m_LoopType = LoopType.OpenLoop;

		public int mLanguage;

		public bool mIsPcbCheck;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.Form_PCBedit));
			textBox_value = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			textBox_footprint = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			numericUpDown_a = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			comboBox_stacktype = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			comboBox_cam = new System.Windows.Forms.ComboBox();
			numericUpDown_x = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			numericUpDown_y = new System.Windows.Forms.NumericUpDown();
			label11 = new System.Windows.Forms.Label();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			textBox_label = new System.Windows.Forms.TextBox();
			checkBox_synctoarray = new System.Windows.Forms.CheckBox();
			textBox_array = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			numericUpDown_stackno = new System.Windows.Forms.NumericUpDown();
			label12 = new System.Windows.Forms.Label();
			numericUpDown_nozzle = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			numericUpDown_group = new System.Windows.Forms.NumericUpDown();
			checkBox_lowspeed = new System.Windows.Forms.CheckBox();
			panel1 = new System.Windows.Forms.Panel();
			checkBox_IsMount = new System.Windows.Forms.CheckBox();
			panel_1 = new System.Windows.Forms.Panel();
			button_visual = new System.Windows.Forms.Button();
			panel_0 = new System.Windows.Forms.Panel();
			checkBox_change0 = new System.Windows.Forms.CheckBox();
			checkBox_change1 = new System.Windows.Forms.CheckBox();
			panel2 = new System.Windows.Forms.Panel();
			label15 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)numericUpDown_a).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_x).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_y).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_stackno).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_nozzle).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_group).BeginInit();
			panel1.SuspendLayout();
			panel_1.SuspendLayout();
			panel_0.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			textBox_value.Location = new System.Drawing.Point(95, 41);
			textBox_value.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox_value.Name = "textBox_value";
			textBox_value.Size = new System.Drawing.Size(95, 25);
			textBox_value.TabIndex = 0;
			label1.Location = new System.Drawing.Point(7, 45);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(85, 20);
			label1.TabIndex = 1;
			label1.Text = "元件型号";
			label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label2.Location = new System.Drawing.Point(7, 75);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(85, 20);
			label2.TabIndex = 1;
			label2.Text = "元件封装";
			label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			textBox_footprint.Location = new System.Drawing.Point(95, 73);
			textBox_footprint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox_footprint.Name = "textBox_footprint";
			textBox_footprint.Size = new System.Drawing.Size(95, 25);
			textBox_footprint.TabIndex = 0;
			label3.Location = new System.Drawing.Point(4, 67);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(85, 20);
			label3.TabIndex = 1;
			label3.Text = "角度";
			label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			numericUpDown_a.DecimalPlaces = 2;
			numericUpDown_a.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
			numericUpDown_a.Location = new System.Drawing.Point(96, 66);
			numericUpDown_a.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_a.Maximum = new decimal(new int[4] { 720, 0, 0, 0 });
			numericUpDown_a.Minimum = new decimal(new int[4] { 720, 0, 0, -2147483648 });
			numericUpDown_a.Name = "numericUpDown_a";
			numericUpDown_a.Size = new System.Drawing.Size(94, 25);
			numericUpDown_a.TabIndex = 2;
			label4.Location = new System.Drawing.Point(-9, 9);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(85, 20);
			label4.TabIndex = 1;
			label4.Text = "供料方式";
			label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			comboBox_stacktype.FormattingEnabled = true;
			comboBox_stacktype.Location = new System.Drawing.Point(80, 7);
			comboBox_stacktype.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			comboBox_stacktype.Name = "comboBox_stacktype";
			comboBox_stacktype.Size = new System.Drawing.Size(111, 23);
			comboBox_stacktype.TabIndex = 3;
			label5.Location = new System.Drawing.Point(57, 49);
			label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(47, 20);
			label5.TabIndex = 1;
			label5.Text = "拼板";
			label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label6.Location = new System.Drawing.Point(-8, 40);
			label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(85, 20);
			label6.TabIndex = 1;
			label6.Text = "相机类型";
			label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label7.Location = new System.Drawing.Point(-8, 76);
			label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(85, 20);
			label7.TabIndex = 1;
			label7.Text = "视觉类型";
			label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			comboBox_cam.FormattingEnabled = true;
			comboBox_cam.Location = new System.Drawing.Point(80, 37);
			comboBox_cam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			comboBox_cam.Name = "comboBox_cam";
			comboBox_cam.Size = new System.Drawing.Size(111, 23);
			comboBox_cam.TabIndex = 3;
			numericUpDown_x.Location = new System.Drawing.Point(96, 7);
			numericUpDown_x.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_x.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
			numericUpDown_x.Name = "numericUpDown_x";
			numericUpDown_x.Size = new System.Drawing.Size(94, 25);
			numericUpDown_x.TabIndex = 5;
			label8.Location = new System.Drawing.Point(4, 11);
			label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(85, 20);
			label8.TabIndex = 4;
			label8.Text = "坐标X";
			label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label9.Location = new System.Drawing.Point(4, 39);
			label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(85, 20);
			label9.TabIndex = 4;
			label9.Text = "坐标Y";
			label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			numericUpDown_y.Location = new System.Drawing.Point(96, 36);
			numericUpDown_y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_y.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
			numericUpDown_y.Name = "numericUpDown_y";
			numericUpDown_y.Size = new System.Drawing.Size(94, 25);
			numericUpDown_y.TabIndex = 5;
			label11.Location = new System.Drawing.Point(7, 12);
			label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(85, 20);
			label11.TabIndex = 1;
			label11.Text = "元件位号";
			label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			button_ok.Location = new System.Drawing.Point(239, 344);
			button_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(87, 29);
			button_ok.TabIndex = 7;
			button_ok.Text = "保存";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Location = new System.Drawing.Point(408, 344);
			button_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(87, 29);
			button_cancel.TabIndex = 7;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			textBox_label.Location = new System.Drawing.Point(95, 9);
			textBox_label.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox_label.Name = "textBox_label";
			textBox_label.Size = new System.Drawing.Size(95, 25);
			textBox_label.TabIndex = 0;
			checkBox_synctoarray.AutoSize = true;
			checkBox_synctoarray.Location = new System.Drawing.Point(245, 62);
			checkBox_synctoarray.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			checkBox_synctoarray.Name = "checkBox_synctoarray";
			checkBox_synctoarray.Size = new System.Drawing.Size(202, 19);
			checkBox_synctoarray.TabIndex = 8;
			checkBox_synctoarray.Text = "是否同步修改到其他拼板";
			checkBox_synctoarray.UseVisualStyleBackColor = true;
			checkBox_synctoarray.Visible = false;
			textBox_array.Enabled = false;
			textBox_array.Location = new System.Drawing.Point(107, 46);
			textBox_array.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox_array.Name = "textBox_array";
			textBox_array.Size = new System.Drawing.Size(111, 25);
			textBox_array.TabIndex = 0;
			label10.Location = new System.Drawing.Point(310, 44);
			label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(85, 20);
			label10.TabIndex = 1;
			label10.Text = "料站号";
			label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			numericUpDown_stackno.Location = new System.Drawing.Point(396, 43);
			numericUpDown_stackno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_stackno.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			numericUpDown_stackno.Name = "numericUpDown_stackno";
			numericUpDown_stackno.Size = new System.Drawing.Size(54, 25);
			numericUpDown_stackno.TabIndex = 2;
			label12.Location = new System.Drawing.Point(309, 17);
			label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(85, 20);
			label12.TabIndex = 1;
			label12.Text = "吸嘴号";
			label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			numericUpDown_nozzle.Location = new System.Drawing.Point(396, 14);
			numericUpDown_nozzle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_nozzle.Name = "numericUpDown_nozzle";
			numericUpDown_nozzle.Size = new System.Drawing.Size(54, 25);
			numericUpDown_nozzle.TabIndex = 2;
			label13.Location = new System.Drawing.Point(230, 49);
			label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(103, 20);
			label13.TabIndex = 1;
			label13.Text = "贴装顺序轮组";
			label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			numericUpDown_group.Enabled = false;
			numericUpDown_group.Location = new System.Drawing.Point(336, 45);
			numericUpDown_group.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_group.Maximum = new decimal(new int[4] { 65535, 0, 0, 0 });
			numericUpDown_group.Name = "numericUpDown_group";
			numericUpDown_group.Size = new System.Drawing.Size(112, 25);
			numericUpDown_group.TabIndex = 2;
			checkBox_lowspeed.AutoSize = true;
			checkBox_lowspeed.Location = new System.Drawing.Point(336, 71);
			checkBox_lowspeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			checkBox_lowspeed.Name = "checkBox_lowspeed";
			checkBox_lowspeed.Size = new System.Drawing.Size(90, 19);
			checkBox_lowspeed.TabIndex = 8;
			checkBox_lowspeed.Text = "降速搬运";
			checkBox_lowspeed.UseVisualStyleBackColor = true;
			panel1.BackColor = System.Drawing.Color.NavajoWhite;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Controls.Add(checkBox_IsMount);
			panel1.Controls.Add(numericUpDown_x);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(checkBox_synctoarray);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(numericUpDown_a);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(numericUpDown_y);
			panel1.Location = new System.Drawing.Point(12, 231);
			panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(690, 99);
			panel1.TabIndex = 9;
			checkBox_IsMount.AutoSize = true;
			checkBox_IsMount.Location = new System.Drawing.Point(245, 9);
			checkBox_IsMount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			checkBox_IsMount.Name = "checkBox_IsMount";
			checkBox_IsMount.Size = new System.Drawing.Size(90, 19);
			checkBox_IsMount.TabIndex = 9;
			checkBox_IsMount.Text = "是否贴装";
			checkBox_IsMount.UseVisualStyleBackColor = true;
			panel_1.BackColor = System.Drawing.Color.NavajoWhite;
			panel_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_1.Controls.Add(button_visual);
			panel_1.Controls.Add(comboBox_cam);
			panel_1.Controls.Add(checkBox_lowspeed);
			panel_1.Controls.Add(comboBox_stacktype);
			panel_1.Controls.Add(numericUpDown_nozzle);
			panel_1.Controls.Add(numericUpDown_stackno);
			panel_1.Controls.Add(label7);
			panel_1.Controls.Add(label6);
			panel_1.Controls.Add(label12);
			panel_1.Controls.Add(label10);
			panel_1.Controls.Add(label4);
			panel_1.Location = new System.Drawing.Point(227, 113);
			panel_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_1.Name = "panel_1";
			panel_1.Size = new System.Drawing.Size(475, 110);
			panel_1.TabIndex = 10;
			button_visual.Location = new System.Drawing.Point(79, 68);
			button_visual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_visual.Name = "button_visual";
			button_visual.Size = new System.Drawing.Size(231, 32);
			button_visual.TabIndex = 10;
			button_visual.Text = "标准视觉";
			button_visual.UseVisualStyleBackColor = true;
			button_visual.Click += new System.EventHandler(button_visual_Click);
			panel_0.BackColor = System.Drawing.Color.NavajoWhite;
			panel_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_0.Controls.Add(label2);
			panel_0.Controls.Add(label11);
			panel_0.Controls.Add(label1);
			panel_0.Controls.Add(textBox_footprint);
			panel_0.Controls.Add(textBox_label);
			panel_0.Controls.Add(textBox_value);
			panel_0.Location = new System.Drawing.Point(12, 113);
			panel_0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_0.Name = "panel_0";
			panel_0.Size = new System.Drawing.Size(204, 110);
			panel_0.TabIndex = 11;
			checkBox_change0.AutoSize = true;
			checkBox_change0.Location = new System.Drawing.Point(21, 91);
			checkBox_change0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			checkBox_change0.Name = "checkBox_change0";
			checkBox_change0.Size = new System.Drawing.Size(58, 19);
			checkBox_change0.TabIndex = 12;
			checkBox_change0.Text = "修改";
			checkBox_change0.UseVisualStyleBackColor = true;
			checkBox_change0.CheckedChanged += new System.EventHandler(checkBox_change0_CheckedChanged);
			checkBox_change1.AutoSize = true;
			checkBox_change1.Location = new System.Drawing.Point(268, 90);
			checkBox_change1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			checkBox_change1.Name = "checkBox_change1";
			checkBox_change1.Size = new System.Drawing.Size(58, 19);
			checkBox_change1.TabIndex = 12;
			checkBox_change1.Text = "修改";
			checkBox_change1.UseVisualStyleBackColor = true;
			checkBox_change1.CheckedChanged += new System.EventHandler(checkBox_change1_CheckedChanged);
			panel2.AutoSize = true;
			panel2.Controls.Add(label15);
			panel2.Controls.Add(label14);
			panel2.Controls.Add(numericUpDown_group);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(label13);
			panel2.Controls.Add(textBox_array);
			panel2.Location = new System.Drawing.Point(12, 5);
			panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(697, 81);
			panel2.TabIndex = 13;
			label15.BackColor = System.Drawing.Color.Red;
			label15.Location = new System.Drawing.Point(13, 36);
			label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(680, 5);
			label15.TabIndex = 1;
			label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("楷体", 15.25f);
			label14.Location = new System.Drawing.Point(17, 10);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(98, 21);
			label14.TabIndex = 3;
			label14.Text = "元件编辑";
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.PapayaWhip;
			base.ClientSize = new System.Drawing.Size(719, 384);
			base.Controls.Add(panel_0);
			base.Controls.Add(panel_1);
			base.Controls.Add(panel2);
			base.Controls.Add(checkBox_change1);
			base.Controls.Add(checkBox_change0);
			base.Controls.Add(panel1);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			base.Name = "Form_PCBedit";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Load += new System.EventHandler(Form_PCBedit_Load);
			((System.ComponentModel.ISupportInitialize)numericUpDown_a).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_x).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_y).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_stackno).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_nozzle).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_group).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_1.ResumeLayout(false);
			panel_1.PerformLayout();
			panel_0.ResumeLayout(false);
			panel_0.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_PCBedit(int language, BindingList<ChipBoardElement> onlyone, bool is_pcbcheck)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mLanguage = language;
			base.Location = new Point(554, 300);
			MainForm0.common_updateLanguage(mLanguage, initLanguageTable());
			comboBox_cam.Items.Clear();
			comboBox_cam.Items.AddRange(new object[3]
			{
				STR.CAMERA_STR[(int)mCams[0]][mLanguage],
				STR.CAMERA_STR[(int)mCams[1]][mLanguage],
				STR.CAMERA_STR[(int)mCams[2]][mLanguage]
			});
			comboBox_stacktype.Items.Clear();
			comboBox_stacktype.Items.AddRange(new object[3]
			{
				STR.PROVIDER_STR[(int)mProviders[0]][mLanguage],
				STR.PROVIDER_STR[(int)mProviders[1]][mLanguage],
				STR.PROVIDER_STR[(int)mProviders[2]][mLanguage]
			});
			mOnlyone = onlyone;
			mIsPcbCheck = is_pcbcheck;
			ChipBoardElement chipBoardElement = mOnlyone[0];
			checkBox_change0.Checked = true;
			checkBox_change1.Checked = true;
			panel_0.Enabled = true;
			panel_1.Enabled = true;
			textBox_array.Text = chipBoardElement.Arrayno_S;
			textBox_label.Text = chipBoardElement.Labeltab;
			textBox_value.Text = chipBoardElement.Material_value;
			textBox_footprint.Text = chipBoardElement.Footprint;
			if (mIsPcbCheck)
			{
				BackColor = Color.LightBlue;
				panel_0.BackColor = Color.AliceBlue;
				panel_1.BackColor = Color.AliceBlue;
				panel1.BackColor = Color.AliceBlue;
				numericUpDown_x.Value = chipBoardElement.X_Real;
				numericUpDown_y.Value = chipBoardElement.Y_Real;
				numericUpDown_a.Value = (decimal)chipBoardElement.A_Real;
			}
			else
			{
				numericUpDown_x.Value = chipBoardElement.X;
				numericUpDown_y.Value = chipBoardElement.Y;
				numericUpDown_a.Value = (decimal)chipBoardElement.A;
			}
			comboBox_cam.Text = STR.CAMERA_STR[(int)chipBoardElement.Cameratype][mLanguage];
			comboBox_stacktype.Text = STR.PROVIDER_STR[(int)chipBoardElement.Stacktype][mLanguage];
			button_visual.Text = STR.VISUAL_STR[(int)chipBoardElement.Visualtype][mLanguage] + " - " + STR.LOOP_STR[(int)chipBoardElement.Looptype][mLanguage];
			m_VisualType = chipBoardElement.Visualtype;
			m_LoopType = chipBoardElement.Looptype;
			numericUpDown_stackno.Value = chipBoardElement.Stack_no;
			numericUpDown_nozzle.Value = chipBoardElement.Nozzle;
			numericUpDown_group.Value = chipBoardElement.Group;
			checkBox_lowspeed.Checked = chipBoardElement.IsLowSpeed;
			checkBox_IsMount.Checked = chipBoardElement.Ismount;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label14,
				str = new string[3] { "元件编辑", "元件编辑", "Chip Edit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "拼板", "拼板", "Array" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label13,
				str = new string[3] { "贴装顺序轮组", "贴装顺序轮组", "SMT Group" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_change0,
				str = new string[3] { "修改", "修改", "Edit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_change1,
				str = new string[3] { "修改", "修改", "Edit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "元件位号", "元件位号", "Label" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "元件型号", "元件型号", "Value" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "元件封装", "元件封装", "Footprint" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "相机类型", "相机类型", "Camera" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "视觉算法", "视觉算法", "Visual" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "供料方式", "供料方式", "Provider" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_lowspeed,
				str = new string[3] { "降速搬运", "降速搬运", "Low Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label12,
				str = new string[3] { "吸嘴号", "吸嘴号", "Nozzle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label10,
				str = new string[3] { "料站号", "料站号", "Feeder" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label8,
				str = new string[3] { "X坐标", "X坐标", "X" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label9,
				str = new string[3] { "Y坐标", "Y坐标", "Y" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "角度", "角度", "Angle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_IsMount,
				str = new string[3] { "是否贴装", "是否贴装", "Is Mount" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_synctoarray,
				str = new string[3] { "是否同步修改到其他拼板", "是否同步修改到其他拼板", "Sync to Other PCB Arrays" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok,
				str = new string[3] { "保存", "保存", "Save" }
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
				ctrl = button_visual
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			LanguageItem languageItem2 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_cam
			};
			string[] array2 = (languageItem2.str = new string[3]);
			list.Add(languageItem2);
			LanguageItem languageItem3 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_stacktype
			};
			string[] array3 = (languageItem3.str = new string[3]);
			list.Add(languageItem3);
			return list;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			ChipBoardElement chipBoardElement = mOnlyone[0];
			chipBoardElement.Labeltab = textBox_label.Text;
			chipBoardElement.Material_value = textBox_value.Text;
			chipBoardElement.Footprint = textBox_footprint.Text;
			if (mIsPcbCheck)
			{
				chipBoardElement.X_Real = (long)numericUpDown_x.Value;
				chipBoardElement.Y_Real = (long)numericUpDown_y.Value;
				chipBoardElement.A_Real = (float)numericUpDown_a.Value;
			}
			else
			{
				chipBoardElement.X = (long)numericUpDown_x.Value;
				chipBoardElement.Y = (long)numericUpDown_y.Value;
				chipBoardElement.A = (float)numericUpDown_a.Value;
			}
			if (comboBox_stacktype.SelectedIndex >= 0)
			{
				chipBoardElement.Stacktype = mProviders[comboBox_stacktype.SelectedIndex];
			}
			if (comboBox_cam.SelectedIndex >= 0)
			{
				chipBoardElement.Cameratype = mCams[comboBox_cam.SelectedIndex];
			}
			chipBoardElement.Visualtype = m_VisualType;
			chipBoardElement.Looptype = m_LoopType;
			chipBoardElement.Stack_no = (int)numericUpDown_stackno.Value;
			chipBoardElement.Nozzle = (int)numericUpDown_nozzle.Value;
			chipBoardElement.Group = (int)numericUpDown_group.Value;
			chipBoardElement.IsLowSpeed = checkBox_lowspeed.Checked;
			chipBoardElement.Ismount = checkBox_IsMount.Checked;
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void checkBox_change0_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_change0.Checked)
			{
				panel_0.Enabled = true;
			}
			else
			{
				panel_0.Enabled = false;
			}
		}

		private void checkBox_change1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_change1.Checked)
			{
				panel_1.Enabled = true;
			}
			else
			{
				panel_1.Enabled = false;
			}
		}

		private void button_visual_Click(object sender, EventArgs e)
		{
			Form_VisualTab form_VisualTab = new Form_VisualTab(m_VisualType, m_LoopType);
			if (form_VisualTab.ShowDialog() == DialogResult.OK)
			{
				m_VisualType = form_VisualTab.get_visualtype();
				m_LoopType = form_VisualTab.get_looptype();
				button_visual.Text = STR.VISUAL_STR[(int)m_VisualType][mLanguage] + " - " + STR.LOOP_STR[(int)m_LoopType][mLanguage];
			}
		}

		private void Form_PCBedit_Load(object sender, EventArgs e)
		{
			if (mIsPcbCheck)
			{
				label8.Text = (new string[3] { "实际", "實際", "Real " })[mLanguage] + label8.Text;
				label9.Text = (new string[3] { "实际", "實際", "Real " })[mLanguage] + label9.Text;
				label3.Text = (new string[3] { "实际", "實際", "Real " })[mLanguage] + label3.Text;
			}
		}
	}
}
