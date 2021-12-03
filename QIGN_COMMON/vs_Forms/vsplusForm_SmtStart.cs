using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class vsplusForm_SmtStart : Form
	{
		private IContainer components;

		private Button button_autoloop;

		private Button button_singleloop;

		private Button button_singlepcb;

		private Panel panel1;

		private Label label1;

		private NumericUpDown numericUpDown_init_haiba;

		private Button button_show_loop;

		private Button button_show_pcb;

		private Panel panel_loop;

		private Label label2;

		private Button button7;

		private Label label4;

		private CheckBox checkBox_enterAutomode;

		private NumericUpDown numericUpDown_loop_chip;

		private ComboBox comboBox_loop;

		private Panel panel_pcb;

		private NumericUpDown numericUpDown_pcb_chip;

		private ComboBox comboBox_pcb;

		private Label label3;

		private Label label5;

		private Panel panel_m0;

		private Panel panel_m1;

		private Button button_continueloop;

		private Button button_show_continue;

		private Panel panel_conitnueseting;

		private CheckBox checkBox_enterAutoMode2;

		private Panel panel_continuepcb;

		private Button button_continuepcb;

		private Panel panel_continueloop;

		private CheckBox checkBox_manualmark0;

		private CheckBox checkBox_manualmark1;

		private CheckBox checkBox_manualmark3;

		private CheckBox checkBox_manualmark4;

		private Panel panel2;

		private Panel panel_sel_pcb;

		public BindingList<USR3_DATA> U3;

		public int U3Idx;

		public int mFn;

		public SmtOpMode mOpSmtMode;

		public float msmt_curhaiha;

		public int msmt_continuemode;

		public USR3_BASE USR3B;

		public int mloop_startloop;

		public int mloop_startchip;

		public int mpcb_startchip;

		private RadioButton[] radioButton_selpcb;

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
			button_autoloop = new System.Windows.Forms.Button();
			button_singleloop = new System.Windows.Forms.Button();
			button_singlepcb = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			numericUpDown_init_haiba = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			button_show_loop = new System.Windows.Forms.Button();
			button_show_pcb = new System.Windows.Forms.Button();
			panel_loop = new System.Windows.Forms.Panel();
			checkBox_manualmark0 = new System.Windows.Forms.CheckBox();
			checkBox_enterAutomode = new System.Windows.Forms.CheckBox();
			numericUpDown_loop_chip = new System.Windows.Forms.NumericUpDown();
			comboBox_loop = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel_pcb = new System.Windows.Forms.Panel();
			checkBox_manualmark1 = new System.Windows.Forms.CheckBox();
			numericUpDown_pcb_chip = new System.Windows.Forms.NumericUpDown();
			comboBox_pcb = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			panel_m0 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			panel_m1 = new System.Windows.Forms.Panel();
			panel_continuepcb = new System.Windows.Forms.Panel();
			checkBox_manualmark4 = new System.Windows.Forms.CheckBox();
			button_continuepcb = new System.Windows.Forms.Button();
			panel_continueloop = new System.Windows.Forms.Panel();
			panel_conitnueseting = new System.Windows.Forms.Panel();
			checkBox_manualmark3 = new System.Windows.Forms.CheckBox();
			checkBox_enterAutoMode2 = new System.Windows.Forms.CheckBox();
			button_show_continue = new System.Windows.Forms.Button();
			button_continueloop = new System.Windows.Forms.Button();
			panel_sel_pcb = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_init_haiba).BeginInit();
			panel_loop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_loop_chip).BeginInit();
			panel_pcb.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pcb_chip).BeginInit();
			panel_m0.SuspendLayout();
			panel2.SuspendLayout();
			panel_m1.SuspendLayout();
			panel_continuepcb.SuspendLayout();
			panel_continueloop.SuspendLayout();
			panel_conitnueseting.SuspendLayout();
			SuspendLayout();
			button_autoloop.Font = new System.Drawing.Font("黑体", 15f);
			button_autoloop.Location = new System.Drawing.Point(20, 12);
			button_autoloop.Name = "button_autoloop";
			button_autoloop.Size = new System.Drawing.Size(185, 132);
			button_autoloop.TabIndex = 0;
			button_autoloop.Text = "全自动\r\n板组";
			button_autoloop.UseVisualStyleBackColor = true;
			button_autoloop.Click += new System.EventHandler(button_autoloop_Click);
			button_singleloop.Font = new System.Drawing.Font("黑体", 15f);
			button_singleloop.Location = new System.Drawing.Point(10, 6);
			button_singleloop.Name = "button_singleloop";
			button_singleloop.Size = new System.Drawing.Size(185, 97);
			button_singleloop.TabIndex = 0;
			button_singleloop.Text = "手动单贴\r\n板组";
			button_singleloop.UseVisualStyleBackColor = true;
			button_singleloop.Click += new System.EventHandler(button_singleloop_Click);
			button_singlepcb.Font = new System.Drawing.Font("黑体", 15f);
			button_singlepcb.Location = new System.Drawing.Point(514, 28);
			button_singlepcb.Name = "button_singlepcb";
			button_singlepcb.Size = new System.Drawing.Size(185, 81);
			button_singlepcb.TabIndex = 0;
			button_singlepcb.Text = "单贴\r\n选中PCB";
			button_singlepcb.UseVisualStyleBackColor = true;
			button_singlepcb.Click += new System.EventHandler(button_singlepcb_Click);
			panel1.BackColor = System.Drawing.Color.Snow;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(numericUpDown_init_haiba);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(button7);
			panel1.Location = new System.Drawing.Point(-8, 286);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(809, 65);
			panel1.TabIndex = 1;
			numericUpDown_init_haiba.DecimalPlaces = 2;
			numericUpDown_init_haiba.Font = new System.Drawing.Font("楷体", 11.5f);
			numericUpDown_init_haiba.Location = new System.Drawing.Point(180, 11);
			numericUpDown_init_haiba.Name = "numericUpDown_init_haiba";
			numericUpDown_init_haiba.Size = new System.Drawing.Size(76, 25);
			numericUpDown_init_haiba.TabIndex = 1;
			numericUpDown_init_haiba.ValueChanged += new System.EventHandler(numericUpDown_init_haiba_ValueChanged);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(56, 14);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(120, 16);
			label1.TabIndex = 0;
			label1.Text = "初始海拔(毫米)";
			button7.Font = new System.Drawing.Font("楷体", 12f);
			button7.Location = new System.Drawing.Point(293, 7);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(178, 30);
			button7.TabIndex = 0;
			button7.Text = "什么是海拔？";
			button7.UseVisualStyleBackColor = true;
			button_show_loop.Font = new System.Drawing.Font("黑体", 11f);
			button_show_loop.Location = new System.Drawing.Point(10, 109);
			button_show_loop.Name = "button_show_loop";
			button_show_loop.Size = new System.Drawing.Size(185, 29);
			button_show_loop.TabIndex = 0;
			button_show_loop.Text = "临时设置";
			button_show_loop.UseVisualStyleBackColor = true;
			button_show_loop.Click += new System.EventHandler(button_show_loop_Click);
			button_show_pcb.Font = new System.Drawing.Font("黑体", 11f);
			button_show_pcb.Location = new System.Drawing.Point(514, 115);
			button_show_pcb.Name = "button_show_pcb";
			button_show_pcb.Size = new System.Drawing.Size(185, 29);
			button_show_pcb.TabIndex = 0;
			button_show_pcb.Text = "临时设置";
			button_show_pcb.UseVisualStyleBackColor = true;
			button_show_pcb.Click += new System.EventHandler(button_show_pcb_Click);
			panel_loop.BackColor = System.Drawing.SystemColors.Control;
			panel_loop.Controls.Add(checkBox_manualmark0);
			panel_loop.Controls.Add(checkBox_enterAutomode);
			panel_loop.Controls.Add(numericUpDown_loop_chip);
			panel_loop.Controls.Add(comboBox_loop);
			panel_loop.Controls.Add(label4);
			panel_loop.Controls.Add(label2);
			panel_loop.Location = new System.Drawing.Point(10, 144);
			panel_loop.Name = "panel_loop";
			panel_loop.Size = new System.Drawing.Size(185, 104);
			panel_loop.TabIndex = 2;
			panel_loop.Visible = false;
			checkBox_manualmark0.AutoSize = true;
			checkBox_manualmark0.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_manualmark0.Location = new System.Drawing.Point(6, 59);
			checkBox_manualmark0.Name = "checkBox_manualmark0";
			checkBox_manualmark0.Size = new System.Drawing.Size(90, 19);
			checkBox_manualmark0.TabIndex = 4;
			checkBox_manualmark0.Text = "手动MARK";
			checkBox_manualmark0.UseVisualStyleBackColor = true;
			checkBox_manualmark0.CheckedChanged += new System.EventHandler(checkBox_manualmark0_CheckedChanged);
			checkBox_enterAutomode.AutoSize = true;
			checkBox_enterAutomode.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_enterAutomode.Location = new System.Drawing.Point(6, 81);
			checkBox_enterAutomode.Name = "checkBox_enterAutomode";
			checkBox_enterAutomode.Size = new System.Drawing.Size(154, 19);
			checkBox_enterAutomode.TabIndex = 3;
			checkBox_enterAutomode.Text = "完成后进入全自动";
			checkBox_enterAutomode.UseVisualStyleBackColor = true;
			checkBox_enterAutomode.Visible = false;
			numericUpDown_loop_chip.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_loop_chip.Location = new System.Drawing.Point(78, 29);
			numericUpDown_loop_chip.Name = "numericUpDown_loop_chip";
			numericUpDown_loop_chip.Size = new System.Drawing.Size(97, 24);
			numericUpDown_loop_chip.TabIndex = 2;
			numericUpDown_loop_chip.ValueChanged += new System.EventHandler(numericUpDown_loop_chip_ValueChanged);
			comboBox_loop.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_loop.FormattingEnabled = true;
			comboBox_loop.Location = new System.Drawing.Point(78, 3);
			comboBox_loop.Name = "comboBox_loop";
			comboBox_loop.Size = new System.Drawing.Size(97, 23);
			comboBox_loop.TabIndex = 1;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 11f);
			label4.Location = new System.Drawing.Point(3, 33);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(71, 15);
			label4.TabIndex = 0;
			label4.Text = "起始元件";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 11f);
			label2.Location = new System.Drawing.Point(3, 6);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(63, 15);
			label2.TabIndex = 0;
			label2.Text = "起始PCB";
			panel_pcb.BackColor = System.Drawing.SystemColors.Control;
			panel_pcb.Controls.Add(checkBox_manualmark1);
			panel_pcb.Controls.Add(numericUpDown_pcb_chip);
			panel_pcb.Controls.Add(comboBox_pcb);
			panel_pcb.Controls.Add(label3);
			panel_pcb.Controls.Add(label5);
			panel_pcb.Location = new System.Drawing.Point(514, 150);
			panel_pcb.Name = "panel_pcb";
			panel_pcb.Size = new System.Drawing.Size(185, 104);
			panel_pcb.TabIndex = 2;
			panel_pcb.Visible = false;
			checkBox_manualmark1.AutoSize = true;
			checkBox_manualmark1.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_manualmark1.Location = new System.Drawing.Point(6, 59);
			checkBox_manualmark1.Name = "checkBox_manualmark1";
			checkBox_manualmark1.Size = new System.Drawing.Size(90, 19);
			checkBox_manualmark1.TabIndex = 4;
			checkBox_manualmark1.Text = "手动MARK";
			checkBox_manualmark1.UseVisualStyleBackColor = true;
			checkBox_manualmark1.CheckedChanged += new System.EventHandler(checkBox_manualmark0_CheckedChanged);
			numericUpDown_pcb_chip.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_pcb_chip.Location = new System.Drawing.Point(78, 29);
			numericUpDown_pcb_chip.Name = "numericUpDown_pcb_chip";
			numericUpDown_pcb_chip.Size = new System.Drawing.Size(97, 24);
			numericUpDown_pcb_chip.TabIndex = 2;
			numericUpDown_pcb_chip.ValueChanged += new System.EventHandler(numericUpDown_pcb_chip_ValueChanged);
			comboBox_pcb.Font = new System.Drawing.Font("黑体", 11f);
			comboBox_pcb.FormattingEnabled = true;
			comboBox_pcb.Location = new System.Drawing.Point(78, 3);
			comboBox_pcb.Name = "comboBox_pcb";
			comboBox_pcb.Size = new System.Drawing.Size(97, 23);
			comboBox_pcb.TabIndex = 1;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 11f);
			label3.Location = new System.Drawing.Point(3, 33);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(71, 15);
			label3.TabIndex = 0;
			label3.Text = "起始元件";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 11f);
			label5.Location = new System.Drawing.Point(3, 6);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(63, 15);
			label5.TabIndex = 0;
			label5.Text = "起始PCB";
			panel_m0.Controls.Add(button_singlepcb);
			panel_m0.Controls.Add(panel_sel_pcb);
			panel_m0.Controls.Add(panel2);
			panel_m0.Controls.Add(panel_pcb);
			panel_m0.Controls.Add(button_show_pcb);
			panel_m0.Controls.Add(button_autoloop);
			panel_m0.Location = new System.Drawing.Point(22, 23);
			panel_m0.Name = "panel_m0";
			panel_m0.Size = new System.Drawing.Size(734, 254);
			panel_m0.TabIndex = 3;
			panel_m0.Click += new System.EventHandler(panel_m0_Click);
			panel2.Controls.Add(panel_loop);
			panel2.Controls.Add(button_show_loop);
			panel2.Controls.Add(button_singleloop);
			panel2.Location = new System.Drawing.Point(254, 6);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(206, 287);
			panel2.TabIndex = 3;
			panel_m1.Controls.Add(panel_continuepcb);
			panel_m1.Controls.Add(panel_continueloop);
			panel_m1.Location = new System.Drawing.Point(770, 23);
			panel_m1.Name = "panel_m1";
			panel_m1.Size = new System.Drawing.Size(510, 254);
			panel_m1.TabIndex = 4;
			panel_m1.Click += new System.EventHandler(panel_m1_Click);
			panel_continuepcb.Controls.Add(checkBox_manualmark4);
			panel_continuepcb.Controls.Add(button_continuepcb);
			panel_continuepcb.Location = new System.Drawing.Point(359, 28);
			panel_continuepcb.Name = "panel_continuepcb";
			panel_continuepcb.Size = new System.Drawing.Size(205, 226);
			panel_continuepcb.TabIndex = 3;
			checkBox_manualmark4.AutoSize = true;
			checkBox_manualmark4.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_manualmark4.Location = new System.Drawing.Point(9, 164);
			checkBox_manualmark4.Name = "checkBox_manualmark4";
			checkBox_manualmark4.Size = new System.Drawing.Size(90, 19);
			checkBox_manualmark4.TabIndex = 4;
			checkBox_manualmark4.Text = "手动MARK";
			checkBox_manualmark4.UseVisualStyleBackColor = true;
			checkBox_manualmark4.CheckedChanged += new System.EventHandler(checkBox_manualmark0_CheckedChanged);
			button_continuepcb.Font = new System.Drawing.Font("黑体", 15f);
			button_continuepcb.Location = new System.Drawing.Point(9, 14);
			button_continuepcb.Name = "button_continuepcb";
			button_continuepcb.Size = new System.Drawing.Size(185, 132);
			button_continuepcb.TabIndex = 0;
			button_continuepcb.Text = "续贴\r\n单板PCB";
			button_continuepcb.UseVisualStyleBackColor = true;
			button_continuepcb.Click += new System.EventHandler(button_continuepcb_Click);
			panel_continueloop.Controls.Add(panel_conitnueseting);
			panel_continueloop.Controls.Add(button_show_continue);
			panel_continueloop.Controls.Add(button_continueloop);
			panel_continueloop.Location = new System.Drawing.Point(148, 28);
			panel_continueloop.Name = "panel_continueloop";
			panel_continueloop.Size = new System.Drawing.Size(205, 242);
			panel_continueloop.TabIndex = 3;
			panel_conitnueseting.BackColor = System.Drawing.SystemColors.Control;
			panel_conitnueseting.Controls.Add(checkBox_manualmark3);
			panel_conitnueseting.Controls.Add(checkBox_enterAutoMode2);
			panel_conitnueseting.Location = new System.Drawing.Point(9, 152);
			panel_conitnueseting.Name = "panel_conitnueseting";
			panel_conitnueseting.Size = new System.Drawing.Size(185, 74);
			panel_conitnueseting.TabIndex = 2;
			panel_conitnueseting.Visible = false;
			checkBox_manualmark3.AutoSize = true;
			checkBox_manualmark3.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_manualmark3.Location = new System.Drawing.Point(18, 37);
			checkBox_manualmark3.Name = "checkBox_manualmark3";
			checkBox_manualmark3.Size = new System.Drawing.Size(90, 19);
			checkBox_manualmark3.TabIndex = 4;
			checkBox_manualmark3.Text = "手动MARK";
			checkBox_manualmark3.UseVisualStyleBackColor = true;
			checkBox_manualmark3.CheckedChanged += new System.EventHandler(checkBox_manualmark0_CheckedChanged);
			checkBox_enterAutoMode2.AutoSize = true;
			checkBox_enterAutoMode2.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_enterAutoMode2.Location = new System.Drawing.Point(18, 12);
			checkBox_enterAutoMode2.Name = "checkBox_enterAutoMode2";
			checkBox_enterAutoMode2.Size = new System.Drawing.Size(154, 19);
			checkBox_enterAutoMode2.TabIndex = 0;
			checkBox_enterAutoMode2.Text = "完成后进入全自动";
			checkBox_enterAutoMode2.UseVisualStyleBackColor = true;
			button_show_continue.Font = new System.Drawing.Font("黑体", 11f);
			button_show_continue.Location = new System.Drawing.Point(9, 117);
			button_show_continue.Name = "button_show_continue";
			button_show_continue.Size = new System.Drawing.Size(185, 29);
			button_show_continue.TabIndex = 1;
			button_show_continue.Text = "临时设置";
			button_show_continue.UseVisualStyleBackColor = true;
			button_show_continue.Click += new System.EventHandler(button_show_continue_Click);
			button_continueloop.Font = new System.Drawing.Font("黑体", 15f);
			button_continueloop.Location = new System.Drawing.Point(9, 14);
			button_continueloop.Name = "button_continueloop";
			button_continueloop.Size = new System.Drawing.Size(185, 97);
			button_continueloop.TabIndex = 0;
			button_continueloop.Text = "续贴\r\n板组";
			button_continueloop.UseVisualStyleBackColor = true;
			button_continueloop.Click += new System.EventHandler(button_continueloop_Click);
			panel_sel_pcb.Font = new System.Drawing.Font("黑体", 11.5f);
			panel_sel_pcb.Location = new System.Drawing.Point(516, 2);
			panel_sel_pcb.Name = "panel_sel_pcb";
			panel_sel_pcb.Size = new System.Drawing.Size(183, 26);
			panel_sel_pcb.TabIndex = 4;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Salmon;
			base.ClientSize = new System.Drawing.Size(1292, 330);
			base.Controls.Add(panel_m1);
			base.Controls.Add(panel_m0);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "vsplusForm_SmtStart";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(vsplusForm_SmtStart_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_init_haiba).EndInit();
			panel_loop.ResumeLayout(false);
			panel_loop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_loop_chip).EndInit();
			panel_pcb.ResumeLayout(false);
			panel_pcb.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pcb_chip).EndInit();
			panel_m0.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel_m1.ResumeLayout(false);
			panel_continuepcb.ResumeLayout(false);
			panel_continuepcb.PerformLayout();
			panel_continueloop.ResumeLayout(false);
			panel_conitnueseting.ResumeLayout(false);
			panel_conitnueseting.PerformLayout();
			ResumeLayout(false);
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_autoloop,
				str = new string[3]
				{
					"全自动" + Environment.NewLine + "板组",
					"全自動" + Environment.NewLine + "板組",
					"Auto Run" + Environment.NewLine + "PCBs"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_singleloop,
				str = new string[3]
				{
					"手动单贴" + Environment.NewLine + "板组",
					"手動單貼" + Environment.NewLine + "板組",
					"Manual Run" + Environment.NewLine + "PCBs"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_singlepcb,
				str = new string[3]
				{
					"单贴" + Environment.NewLine + "选中PCB",
					"單貼" + Environment.NewLine + "選中PCB",
					"Manual Run" + Environment.NewLine + "Select PCB"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_continueloop,
				str = new string[3]
				{
					"续贴" + Environment.NewLine + "板组",
					"續貼" + Environment.NewLine + "板組",
					"Continue" + Environment.NewLine + "PCBs"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_continuepcb,
				str = new string[3]
				{
					"续贴" + Environment.NewLine + "单板PCB",
					"續貼" + Environment.NewLine + "單板PCB",
					"Continue" + Environment.NewLine + "Single PCB"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_show_loop,
				str = new string[3] { "临时设置", "臨時設置", "Runtime Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_show_pcb,
				str = new string[3] { "临时设置", "臨時設置", "Runtime Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_show_continue,
				str = new string[3] { "临时设置", "臨時設置", "Runtime Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "起始PCB", "起始PCB", "Start PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "起始PCB", "起始PCB", "Start PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "起始元件", "起始元件", "Start Chip" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "起始元件", "起始元件", "Start Chip" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_manualmark0,
				str = new string[3] { "手动MARK", "手動MARK", "Manual Mark" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_manualmark1,
				str = new string[3] { "手动MARK", "手動MARK", "Manual Mark" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_manualmark3,
				str = new string[3] { "手动MARK", "手動MARK", "Manual Mark" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_manualmark4,
				str = new string[3] { "手动MARK", "手動MARK", "Manual Mark" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_enterAutomode,
				str = new string[3] { "完成后进入全自动", "完成後進入全自動", "Auto mode after this SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_enterAutoMode2,
				str = new string[3] { "完成后进入全自动", "完成後進入全自動", "Auto mode after this SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "初始海拔(毫米)", "初始海拔(毫米)", "Init PCB Height (mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button7,
				str = new string[3] { "什么是海拔？", "什麽是海拔？", "What is PCB Height(mm)?" }
			});
			return list;
		}

		public vsplusForm_SmtStart(int fn, USR3_BASE usr3b, BindingList<USR3_DATA> usr3list, int usr3idx, float haiba, int continuemode)
		{
			InitializeComponent();
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			mFn = fn;
			U3 = usr3list;
			U3Idx = usr3idx;
			USR3B = usr3b;
			msmt_curhaiha = haiba;
			msmt_continuemode = continuemode;
			panel_m1.Location = panel_m0.Location;
			panel_continuepcb.Location = panel_continueloop.Location;
			if (msmt_continuemode == 0)
			{
				panel_m0.Visible = true;
				panel_m1.Visible = false;
				base.Size = new Size(panel_m0.Size.Width + 20 + ((USR3B.mPrjMode == 0) ? (-210) : 0), base.Size.Height);
			}
			else
			{
				panel_m1.Visible = true;
				panel_m0.Visible = false;
				base.Size = new Size(panel_m1.Size.Width + 20, base.Size.Height);
				if (msmt_continuemode == 2)
				{
					panel_continuepcb.Visible = false;
					panel_continueloop.Visible = true;
				}
				else if (msmt_continuemode == 1)
				{
					panel_continuepcb.Visible = true;
					panel_continueloop.Visible = false;
				}
				if (HW.mIsSanduanshi && USR3B.mInBoardMode == 1)
				{
					msmt_continuemode = 1;
					panel_continuepcb.Visible = true;
					panel_continueloop.Visible = false;
				}
			}
			if (USR3B.mPrjMode == 0)
			{
				button_autoloop.Text = (new string[3] { "全自动", "全自動", "Auto Run" })[MainForm0.USR_INIT.mLanguage];
				button_singleloop.Text = (new string[3] { "手动单贴", "手動單貼", "Manual Run" })[MainForm0.USR_INIT.mLanguage];
				button_continueloop.Text = (new string[3] { "手动续贴", "手動續貼", "Manual Continue" })[MainForm0.USR_INIT.mLanguage];
			}
			_ = USR3B.mPrjSmtMode;
			_ = 1;
			USR3B.mIsManualMark = false;
			if (U3 != null && U3.Count > U3Idx)
			{
				if (USR3B.mPrjMode == 0)
				{
					comboBox_loop.Items.Add(U3[U3Idx].mPcbID + " " + U3[U3Idx].mPcbDescription);
					comboBox_loop.SelectedIndex = 0;
					numericUpDown_loop_chip.Value = 1m;
					numericUpDown_loop_chip.Minimum = 1m;
					numericUpDown_loop_chip.Maximum = Math.Max(U3[U3Idx].mPointlistSmt.Count, 1);
					mloop_startloop = 0;
				}
				else if (USR3B.mPrjMode == 1)
				{
					for (int i = 0; i < U3.Count; i++)
					{
						if (U3[i].mIsPcbChecked)
						{
							comboBox_loop.Items.Add(U3[i].mPcbID + " " + U3[i].mPcbDescription);
						}
					}
					if (comboBox_loop.Items.Count > 0)
					{
						comboBox_loop.SelectedIndex = 0;
						numericUpDown_loop_chip.Value = 1m;
						numericUpDown_loop_chip.Minimum = 1m;
						numericUpDown_loop_chip.Maximum = Math.Max(U3[0].mPointlistSmt.Count, 1);
						comboBox_loop.SelectedIndexChanged += comboBox_loop_SelectedIndexChanged;
					}
					if (HW.mIsSanduanshi && USR3B.mInBoardMode == 1)
					{
						panel2.Visible = false;
					}
				}
				button_singlepcb.Text = (new string[3] { "手动单贴", "手動單貼", "Manual Run" })[MainForm0.USR_INIT.mLanguage] + Environment.NewLine + U3[U3Idx].mPcbID + " " + U3[U3Idx].mPcbDescription;
				comboBox_pcb.Items.Add(U3[U3Idx].mPcbID + " " + U3[U3Idx].mPcbDescription);
				comboBox_pcb.SelectedIndex = 0;
				numericUpDown_pcb_chip.Value = 1m;
				numericUpDown_pcb_chip.Minimum = 1m;
				numericUpDown_pcb_chip.Maximum = Math.Max(U3[U3Idx].mPointlistSmt.Count, 1);
			}
			panel1.Visible = HW.mSmtGenerationNo != 0;
			numericUpDown_init_haiba.Value = (decimal)msmt_curhaiha;
		}

		public void comboBox_loop_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (U3 == null || U3.Count <= U3Idx)
			{
				return;
			}
			if (USR3B.mPrjMode == 0)
			{
				mloop_startloop = 0;
				return;
			}
			int selectedIndex = comboBox_loop.SelectedIndex;
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < U3.Count; i++)
			{
				if (U3[i].mIsPcbChecked)
				{
					num2++;
				}
				if (num2 == selectedIndex)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				numericUpDown_loop_chip.Value = 1m;
				numericUpDown_loop_chip.Minimum = 1m;
				numericUpDown_loop_chip.Maximum = Math.Max(U3[num].mPointlistSmt.Count, 1);
			}
			mloop_startloop = selectedIndex;
		}

		private void button_show_loop_Click(object sender, EventArgs e)
		{
			panel_loop.Visible = true;
		}

		private void button_show_pcb_Click(object sender, EventArgs e)
		{
			panel_pcb.Visible = true;
		}

		private void button_show_continue_Click(object sender, EventArgs e)
		{
			panel_conitnueseting.Visible = true;
		}

		private void button_autoloop_Click(object sender, EventArgs e)
		{
			mOpSmtMode = SmtOpMode.AutoRun;
			base.DialogResult = DialogResult.OK;
		}

		private void button_singleloop_Click(object sender, EventArgs e)
		{
			mOpSmtMode = (checkBox_enterAutomode.Checked ? SmtOpMode.CurLoop_AutoRun : SmtOpMode.CurLoop);
			base.DialogResult = DialogResult.Yes;
		}

		private void button_singlepcb_Click(object sender, EventArgs e)
		{
			mOpSmtMode = SmtOpMode.CurPcb;
			base.DialogResult = DialogResult.No;
		}

		private void button_continueloop_Click(object sender, EventArgs e)
		{
			mOpSmtMode = (checkBox_enterAutoMode2.Checked ? SmtOpMode.ContinueLoop_AutoRun : SmtOpMode.ContinueLoop);
			base.DialogResult = DialogResult.Ignore;
		}

		private void button_continuepcb_Click(object sender, EventArgs e)
		{
			mOpSmtMode = SmtOpMode.ContinuePcb;
			base.DialogResult = DialogResult.Abort;
		}

		private void numericUpDown_loop_chip_ValueChanged(object sender, EventArgs e)
		{
			if (U3 != null && U3.Count > U3Idx)
			{
				if (numericUpDown_loop_chip.Value > 1m)
				{
					checkBox_enterAutomode.Visible = true;
				}
				else
				{
					checkBox_enterAutomode.Checked = false;
					checkBox_enterAutomode.Visible = false;
				}
				mloop_startchip = (int)numericUpDown_loop_chip.Value - 1;
			}
		}

		private void panel_m0_Click(object sender, EventArgs e)
		{
			panel_loop.Visible = false;
			panel_pcb.Visible = false;
		}

		private void panel_m1_Click(object sender, EventArgs e)
		{
			panel_conitnueseting.Visible = false;
		}

		private void numericUpDown_pcb_chip_ValueChanged(object sender, EventArgs e)
		{
			if (U3 != null && U3.Count > U3Idx)
			{
				mpcb_startchip = (int)numericUpDown_pcb_chip.Value - 1;
			}
		}

		public SmtOpMode get_smtmode()
		{
			return mOpSmtMode;
		}

		public int get_loop_startloop()
		{
			return mloop_startloop;
		}

		public int get_loop_startchip()
		{
			return mloop_startchip;
		}

		public int get_pcb_startchip()
		{
			return mpcb_startchip;
		}

		public float get_init_haiba()
		{
			return msmt_curhaiha;
		}

		private void numericUpDown_init_haiba_ValueChanged(object sender, EventArgs e)
		{
			msmt_curhaiha = (float)numericUpDown_init_haiba.Value;
		}

		private void checkBox_manualmark0_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mIsManualMark = ((CheckBox)sender).Checked;
		}

		private void vsplusForm_SmtStart_Load(object sender, EventArgs e)
		{
			if (U3 != null && U3.Count > 0)
			{
				radioButton_selpcb = new RadioButton[U3.Count];
				for (int i = 0; i < radioButton_selpcb.Count(); i++)
				{
					RadioButton radioButton = new RadioButton();
					panel_sel_pcb.Controls.Add(radioButton);
					radioButton.Location = new Point(70 * i, 0);
					radioButton.Text = U3[i].mPcbID;
					radioButton_selpcb[i] = radioButton;
					radioButton.Size = new Size(60, 23);
					radioButton.AutoSize = false;
					radioButton.CheckedChanged += radioButton_selpcb_CheckedChanged;
					radioButton.Tag = i;
				}
				if (U3Idx >= 0 && U3Idx < U3.Count)
				{
					radioButton_selpcb[U3Idx].Checked = true;
				}
			}
		}

		private void radioButton_selpcb_CheckedChanged(object sender, EventArgs e)
		{
			if (U3 == null || U3.Count <= 0)
			{
				return;
			}
			RadioButton radioButton = (RadioButton)sender;
			int num = (int)radioButton.Tag;
			if (radioButton.Checked)
			{
				button_singlepcb.Text = (new string[3] { "单贴", "單貼", "Manual" })[MainForm0.USR_INIT.mLanguage] + Environment.NewLine + U3[num].mPcbID;
				if (this.button_subpcb_sel != null)
				{
					this.button_subpcb_sel(num);
				}
			}
		}
	}
}
