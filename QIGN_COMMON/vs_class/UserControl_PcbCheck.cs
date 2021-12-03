using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_PcbCheck : UserControl
	{
		private IContainer components;

		private PictureBox pictureBox2;

		private Panel panel1;

		private PictureBox pictureBox1;

		private Label label1;

		private CnButton button_close;

		private Label label_XY0;

		private CnButton button_GotoXY0;

		private CheckBox checkBox_MultiEdit;

		private CnButton button_SaveXY0;

		private CnButton button_CheckOriginalMark;

		private Label label4;

		private Label label5;

		private CnButton button_MarkRecRun;

		private Label label_RecRate0;

		private Label label_RecRate1;

		private CnButton button_SaveXY1;

		private CnButton button_GotoXY1;

		private Label label_XY1;

		private Label label_BoardAngle;

		private Panel panel3;

		private CnButton button_GenAll;

		private Panel panel4;

		private Label label2;

		private CheckBox checkBox_autoselect_nearestMark;

		public int mFn;

		public USR_DATA USR;

		public USR2_DATA USR2;

		public USR3_DATA USR3;

		public USR3_BASE USR3B;

		private USR_INIT_DATA USR_INIT;

		public BindingList<ChipBoardElement> mPointList;

		public PictureBox[] pic_mark;

		public Label[] label_XY;

		public CnButton[] button_SaveXY;

		public CnButton[] button_GotoXY;

		public Label[] label_RecRate;

		public bool mIsInitMarkSuccess;

		public UserControl_pcbedit_datagridview uc_pcbedit_datagridview;

		public event void_Func_USR3_bool cb_pcbcheck_start;

		public event void_Func_bool SetEdit_XY;

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
			panel1 = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			label_RecRate1 = new System.Windows.Forms.Label();
			label_BoardAngle = new System.Windows.Forms.Label();
			label_RecRate0 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			checkBox_MultiEdit = new System.Windows.Forms.CheckBox();
			label_XY1 = new System.Windows.Forms.Label();
			label_XY0 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			button_GotoXY1 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveXY1 = new QIGN_COMMON.vs_acontrol.CnButton();
			label2 = new System.Windows.Forms.Label();
			button_SaveXY0 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_GotoXY0 = new QIGN_COMMON.vs_acontrol.CnButton();
			panel4 = new System.Windows.Forms.Panel();
			button_GenAll = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MarkRecRun = new QIGN_COMMON.vs_acontrol.CnButton();
			button_CheckOriginalMark = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close = new QIGN_COMMON.vs_acontrol.CnButton();
			checkBox_autoselect_nearestMark = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			SuspendLayout();
			panel1.Location = new System.Drawing.Point(-3, 195);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(710, 740);
			panel1.TabIndex = 3;
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.White;
			label5.Font = new System.Drawing.Font("黑体", 10.5f);
			label5.Location = new System.Drawing.Point(373, 5);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(42, 14);
			label5.TabIndex = 4;
			label5.Text = "MARK2";
			label_RecRate1.AutoSize = true;
			label_RecRate1.Font = new System.Drawing.Font("黑体", 10.5f);
			label_RecRate1.Location = new System.Drawing.Point(293, 13);
			label_RecRate1.Name = "label_RecRate1";
			label_RecRate1.Size = new System.Drawing.Size(49, 28);
			label_RecRate1.TabIndex = 4;
			label_RecRate1.Text = "识别率\r\n60%";
			label_RecRate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_BoardAngle.AutoSize = true;
			label_BoardAngle.Font = new System.Drawing.Font("黑体", 10.5f);
			label_BoardAngle.Location = new System.Drawing.Point(230, 45);
			label_BoardAngle.Name = "label_BoardAngle";
			label_BoardAngle.Size = new System.Drawing.Size(49, 28);
			label_BoardAngle.TabIndex = 4;
			label_BoardAngle.Text = "板偏角\r\n1.1";
			label_BoardAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_RecRate0.AutoSize = true;
			label_RecRate0.Font = new System.Drawing.Font("黑体", 10.5f);
			label_RecRate0.Location = new System.Drawing.Point(156, 13);
			label_RecRate0.Name = "label_RecRate0";
			label_RecRate0.Size = new System.Drawing.Size(49, 28);
			label_RecRate0.TabIndex = 4;
			label_RecRate0.Text = "识别率\r\n60%";
			label_RecRate0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.White;
			label4.Font = new System.Drawing.Font("黑体", 10.5f);
			label4.Location = new System.Drawing.Point(3, 4);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 14);
			label4.TabIndex = 4;
			label4.Text = "MARK1";
			checkBox_MultiEdit.AutoSize = true;
			checkBox_MultiEdit.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_MultiEdit.Location = new System.Drawing.Point(217, 99);
			checkBox_MultiEdit.Name = "checkBox_MultiEdit";
			checkBox_MultiEdit.Size = new System.Drawing.Size(82, 32);
			checkBox_MultiEdit.TabIndex = 3;
			checkBox_MultiEdit.Text = "修改原始\r\nMARK图片\r\n";
			checkBox_MultiEdit.UseVisualStyleBackColor = true;
			checkBox_MultiEdit.CheckedChanged += new System.EventHandler(checkBox_MultiEdit_CheckedChanged);
			label_XY1.BackColor = System.Drawing.Color.White;
			label_XY1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_XY1.Font = new System.Drawing.Font("黑体", 11.5f);
			label_XY1.Location = new System.Drawing.Point(301, 54);
			label_XY1.Name = "label_XY1";
			label_XY1.Size = new System.Drawing.Size(62, 40);
			label_XY1.TabIndex = 1;
			label_XY1.Text = "X11111\r\nY22222";
			label_XY1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_XY0.BackColor = System.Drawing.Color.White;
			label_XY0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_XY0.Font = new System.Drawing.Font("黑体", 11.5f);
			label_XY0.Location = new System.Drawing.Point(152, 54);
			label_XY0.Name = "label_XY0";
			label_XY0.Size = new System.Drawing.Size(62, 40);
			label_XY0.TabIndex = 1;
			label_XY0.Text = "X11111\r\nY22222";
			label_XY0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox2.Location = new System.Drawing.Point(364, 0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(150, 150);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 0;
			pictureBox2.TabStop = false;
			pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(150, 150);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 17.25f);
			label1.Location = new System.Drawing.Point(6, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(142, 23);
			label1.TabIndex = 5;
			label1.Text = "PCB进板查看";
			panel3.BackColor = System.Drawing.Color.White;
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(button_GotoXY1);
			panel3.Controls.Add(button_SaveXY1);
			panel3.Controls.Add(label5);
			panel3.Controls.Add(label4);
			panel3.Controls.Add(pictureBox2);
			panel3.Controls.Add(label2);
			panel3.Controls.Add(pictureBox1);
			panel3.Controls.Add(checkBox_MultiEdit);
			panel3.Controls.Add(label_BoardAngle);
			panel3.Controls.Add(label_RecRate1);
			panel3.Controls.Add(label_RecRate0);
			panel3.Controls.Add(button_SaveXY0);
			panel3.Controls.Add(label_XY1);
			panel3.Controls.Add(button_GotoXY0);
			panel3.Controls.Add(label_XY0);
			panel3.Location = new System.Drawing.Point(180, 37);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(516, 152);
			panel3.TabIndex = 5;
			button_GotoXY1.BackColor = System.Drawing.SystemColors.ControlLight;
			button_GotoXY1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_GotoXY1.CnPressDownColor = System.Drawing.Color.White;
			button_GotoXY1.Font = new System.Drawing.Font("黑体", 10.5f);
			button_GotoXY1.Location = new System.Drawing.Point(300, 96);
			button_GotoXY1.Name = "button_GotoXY1";
			button_GotoXY1.Size = new System.Drawing.Size(64, 26);
			button_GotoXY1.TabIndex = 2;
			button_GotoXY1.Tag = "";
			button_GotoXY1.Text = "定位";
			button_GotoXY1.UseVisualStyleBackColor = false;
			button_GotoXY1.Click += new System.EventHandler(button_GotoXY0_Click);
			button_SaveXY1.BackColor = System.Drawing.SystemColors.ControlLight;
			button_SaveXY1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveXY1.CnPressDownColor = System.Drawing.Color.White;
			button_SaveXY1.Font = new System.Drawing.Font("黑体", 10.5f);
			button_SaveXY1.Location = new System.Drawing.Point(300, 123);
			button_SaveXY1.Name = "button_SaveXY1";
			button_SaveXY1.Size = new System.Drawing.Size(64, 26);
			button_SaveXY1.TabIndex = 2;
			button_SaveXY1.Tag = "";
			button_SaveXY1.Text = "更新";
			button_SaveXY1.UseVisualStyleBackColor = false;
			button_SaveXY1.Click += new System.EventHandler(button_SaveXY0_Click);
			label2.BackColor = System.Drawing.Color.White;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Font = new System.Drawing.Font("黑体", 10.5f);
			label2.Location = new System.Drawing.Point(217, -1);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(70, 24);
			label2.TabIndex = 4;
			label2.Text = "识别结果";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_SaveXY0.BackColor = System.Drawing.SystemColors.ControlLight;
			button_SaveXY0.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveXY0.CnPressDownColor = System.Drawing.Color.White;
			button_SaveXY0.Font = new System.Drawing.Font("黑体", 10.5f);
			button_SaveXY0.Location = new System.Drawing.Point(151, 123);
			button_SaveXY0.Name = "button_SaveXY0";
			button_SaveXY0.Size = new System.Drawing.Size(64, 26);
			button_SaveXY0.TabIndex = 2;
			button_SaveXY0.Tag = "";
			button_SaveXY0.Text = "更新";
			button_SaveXY0.UseVisualStyleBackColor = false;
			button_SaveXY0.Click += new System.EventHandler(button_SaveXY0_Click);
			button_GotoXY0.BackColor = System.Drawing.SystemColors.ControlLight;
			button_GotoXY0.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_GotoXY0.CnPressDownColor = System.Drawing.Color.White;
			button_GotoXY0.Font = new System.Drawing.Font("黑体", 10.5f);
			button_GotoXY0.Location = new System.Drawing.Point(151, 96);
			button_GotoXY0.Name = "button_GotoXY0";
			button_GotoXY0.Size = new System.Drawing.Size(64, 26);
			button_GotoXY0.TabIndex = 2;
			button_GotoXY0.Tag = "";
			button_GotoXY0.Text = "定位";
			button_GotoXY0.UseVisualStyleBackColor = false;
			button_GotoXY0.Click += new System.EventHandler(button_GotoXY0_Click);
			panel4.Controls.Add(button_GenAll);
			panel4.Controls.Add(button_MarkRecRun);
			panel4.Controls.Add(button_CheckOriginalMark);
			panel4.Location = new System.Drawing.Point(11, 49);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(164, 135);
			panel4.TabIndex = 6;
			button_GenAll.BackColor = System.Drawing.SystemColors.ControlLight;
			button_GenAll.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_GenAll.CnPressDownColor = System.Drawing.Color.White;
			button_GenAll.Font = new System.Drawing.Font("黑体", 10.5f);
			button_GenAll.Location = new System.Drawing.Point(2, 88);
			button_GenAll.Name = "button_GenAll";
			button_GenAll.Size = new System.Drawing.Size(158, 38);
			button_GenAll.TabIndex = 2;
			button_GenAll.Text = "更新为原始列表";
			button_GenAll.UseVisualStyleBackColor = false;
			button_GenAll.Click += new System.EventHandler(button_GenAll_Click);
			button_MarkRecRun.BackColor = System.Drawing.SystemColors.ControlLight;
			button_MarkRecRun.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MarkRecRun.CnPressDownColor = System.Drawing.Color.White;
			button_MarkRecRun.Font = new System.Drawing.Font("黑体", 10.5f);
			button_MarkRecRun.Location = new System.Drawing.Point(2, 4);
			button_MarkRecRun.Name = "button_MarkRecRun";
			button_MarkRecRun.Size = new System.Drawing.Size(158, 38);
			button_MarkRecRun.TabIndex = 2;
			button_MarkRecRun.Text = "MARK识别→刷新数据";
			button_MarkRecRun.UseVisualStyleBackColor = false;
			button_MarkRecRun.Click += new System.EventHandler(button_MarkRecRun_Click);
			button_CheckOriginalMark.BackColor = System.Drawing.SystemColors.ControlLight;
			button_CheckOriginalMark.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_CheckOriginalMark.CnPressDownColor = System.Drawing.Color.White;
			button_CheckOriginalMark.Font = new System.Drawing.Font("黑体", 10.5f);
			button_CheckOriginalMark.Location = new System.Drawing.Point(2, 46);
			button_CheckOriginalMark.Name = "button_CheckOriginalMark";
			button_CheckOriginalMark.Size = new System.Drawing.Size(158, 38);
			button_CheckOriginalMark.TabIndex = 2;
			button_CheckOriginalMark.Text = "原始MARK查看";
			button_CheckOriginalMark.UseVisualStyleBackColor = false;
			button_CheckOriginalMark.Click += new System.EventHandler(button_CheckOriginalMark_Click);
			button_close.BackColor = System.Drawing.SystemColors.ControlLight;
			button_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close.CnPressDownColor = System.Drawing.SystemColors.ControlLight;
			button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_close.Location = new System.Drawing.Point(672, 2);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(32, 32);
			button_close.TabIndex = 6;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = false;
			button_close.Click += new System.EventHandler(button_close_Click);
			checkBox_autoselect_nearestMark.AutoSize = true;
			checkBox_autoselect_nearestMark.Font = new System.Drawing.Font("黑体", 11.5f);
			checkBox_autoselect_nearestMark.Location = new System.Drawing.Point(180, 11);
			checkBox_autoselect_nearestMark.Name = "checkBox_autoselect_nearestMark";
			checkBox_autoselect_nearestMark.Size = new System.Drawing.Size(283, 20);
			checkBox_autoselect_nearestMark.TabIndex = 7;
			checkBox_autoselect_nearestMark.Text = "离MARK相机中心最近的元件自动选中";
			checkBox_autoselect_nearestMark.UseVisualStyleBackColor = true;
			checkBox_autoselect_nearestMark.CheckedChanged += new System.EventHandler(checkBox_autoselect_nearestMark_CheckedChanged);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(checkBox_autoselect_nearestMark);
			base.Controls.Add(panel3);
			base.Controls.Add(panel4);
			base.Controls.Add(button_close);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.Name = "UserControl_PcbCheck";
			base.Size = new System.Drawing.Size(717, 954);
			base.Load += new System.EventHandler(UserControl_PcbCheck_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public UserControl_PcbCheck(int fn, USR_DATA usr, USR2_DATA usr2, USR3_DATA usr3, USR3_BASE usr3b, BindingList<ChipBoardElement> plist, bool is_initmarksuccess)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR2 = usr2;
			USR3 = usr3;
			USR3B = usr3b;
			USR_INIT = MainForm0.USR_INIT;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			mPointList = plist;
			pic_mark = new PictureBox[2] { pictureBox1, pictureBox2 };
			label_XY = new Label[2] { label_XY0, label_XY1 };
			label_RecRate = new Label[2] { label_RecRate0, label_RecRate1 };
			button_GotoXY = new CnButton[2] { button_GotoXY0, button_GotoXY1 };
			button_SaveXY = new CnButton[2] { button_SaveXY0, button_SaveXY1 };
			mIsInitMarkSuccess = is_initmarksuccess;
			MainForm0.mIsAutoSelect_PcbCheck_NearestMarkChip[fn] = false;
			checkBox_autoselect_nearestMark.Checked = false;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "PCB进板查看", "PCB進板查看", "PCB Inboard Check" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MarkRecRun,
				str = new string[3] { "MARK识别→刷新数据", "MARK識別→刷新數據", "Mark Match -> Update Data" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_CheckOriginalMark,
				str = new string[3] { "原始MARK查看", "原始MARK查看", "Original Mark Check" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_GenAll,
				str = new string[3] { "更新为原始列表", "更新為原始列表", "Update to PCB Edit Table" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "识别结果", "識別結果", "Match Result" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_GotoXY0,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_GotoXY1,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveXY0,
				str = new string[3] { "更新", "更新", "Update" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveXY1,
				str = new string[3] { "更新", "更新", "Update" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_MultiEdit,
				str = new string[3]
				{
					"修改原始" + Environment.NewLine + "MARK图片",
					"修改原始" + Environment.NewLine + Environment.NewLine + "MARK圖片",
					"Change" + Environment.NewLine + "Mark Picture"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_RecRate0,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_RecRate1,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_BoardAngle,
				str = new string[3] { "", "", "" }
			});
			return list;
		}

		private void UserControl_PcbCheck_Load(object sender, EventArgs e)
		{
			MainForm0.write_to_logFile("pcb-check Fn = " + (mFn + 1));
			for (int i = 0; i < 2; i++)
			{
				MainForm0.common_addCSLforPicture(pic_mark[i], Color.Yellow);
				button_SaveXY[i].Visible = false;
				button_SaveXY[i].Tag = i;
				button_GotoXY[i].Tag = i;
			}
			pcbCheck_flushDataGridview(mIsInitMarkSuccess);
		}

		public void pcbCheck_flushDataGridview(bool is_initmarksucce)
		{
			if (!is_initmarksucce)
			{
				return;
			}
			for (int i = 0; i < 2; i++)
			{
				if (USR3.mPcbCheck.mMarkPic[i] != null)
				{
					Bitmap bitmap = new Bitmap(USR3.mPcbCheck.mMarkPic[i]);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					pic_mark[i].Image = bitmap;
				}
				label_XY[i].Text = MainForm0.format_XY_label_string(USR3.mPcbCheck.mMark[i]);
				label_RecRate[i].Text = (new string[3] { "识别率", "識別率", "Match Rate" })[USR_INIT.mLanguage] + Environment.NewLine + USR3.mPcbCheck.mMarkRecRate[i].ToString("F2");
				label_BoardAngle.Text = (new string[3] { "板偏角", "板偏角", "Board Angle" })[USR_INIT.mLanguage] + Environment.NewLine + USR3.mPcbCheck.mAngle.ToString("F2");
			}
			if (uc_pcbedit_datagridview == null || uc_pcbedit_datagridview.IsDisposed)
			{
				uc_pcbedit_datagridview = new UserControl_pcbedit_datagridview(mFn, USR, USR2, USR3, "pcb_check", is_pcbcheck: true);
				panel1.Controls.Add(uc_pcbedit_datagridview);
				uc_pcbedit_datagridview.Show();
			}
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void checkBox_MultiEdit_CheckedChanged(object sender, EventArgs e)
		{
			button_SaveXY[0].Visible = checkBox_MultiEdit.Checked;
			button_SaveXY[1].Visible = checkBox_MultiEdit.Checked;
		}

		private void button_SaveXY0_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int num = (((int)button.Tag != 0) ? 1 : 0);
			string text = "Save MARK" + (num + 1) + "XY?";
			string text2 = "该操作会更新原始MARK" + (num + 1) + "图片，是否继续?";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text : text2, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (MainForm0.mIsSimulation)
				{
					USR3.mPcbCheck.mMark[num].X = 22000 + num * 20000;
					USR3.mPcbCheck.mMark[num].Y = 31000 + num * 20000;
				}
				else
				{
					MainForm0.uc_job[mFn].mMarkFound[num].X = MainForm0.mCur[mFn].x;
					MainForm0.uc_job[mFn].mMarkFound[num].Y = MainForm0.mCur[mFn].y;
					Coordinate coordinate = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, MainForm0.uc_job[mFn].mMarkFound[num]);
					USR3.mMark[num].X = (int)coordinate.X;
					USR3.mMark[num].Y = (int)coordinate.Y;
					USR3.mMarkSearch[num].X = MainForm0.mCur[mFn].x;
					USR3.mMarkSearch[num].Y = MainForm0.mCur[mFn].y;
					USR3.mPcbCheck.mMark[num].X = MainForm0.uc_job[mFn].mMarkFound[num].X;
					USR3.mPcbCheck.mMark[num].Y = MainForm0.uc_job[mFn].mMarkFound[num].Y;
				}
				label_XY[num].Text = MainForm0.format_XY_label_string(USR3.mPcbCheck.mMark[num]);
				MainForm0.save_usrProjectData();
				Thread thread = new Thread(thread_mark_capture);
				thread.IsBackground = true;
				thread.Start(num);
			}
		}

		private void thread_mark_capture(object markno)
		{
			int num = HW.mMarkCamItem[mFn].index[0];
			MainForm0.startMarkStill_andWait(mFn);
			int num2 = (int)(150f * (float)MainForm0.mJvs_rawHeight / (float)MainForm0.mJvs_usrHeight);
			Rectangle destRect = new Rectangle(0, 0, 150, 150);
			Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - 150) / 2, (MainForm0.mJvs_rawHeight - num2) / 2, 150, num2);
			Bitmap newbitmap_des = new Bitmap(150, 150);
			if (!MainForm0.mIsSimulation)
			{
				Graphics graphics = Graphics.FromImage(newbitmap_des);
				graphics.DrawImage(MainForm0.mJVSBitmap[num], destRect, srcRect, GraphicsUnit.Pixel);
				graphics.Dispose();
			}
			else
			{
				newbitmap_des = new Bitmap(MainForm0.SIGN_PICTURE[(int)markno]);
			}
			USR3.mPcbCheck.mMarkPic[(int)markno] = newbitmap_des;
			Invoke((MethodInvoker)delegate
			{
				Bitmap bitmap = new Bitmap(newbitmap_des);
				bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
				pic_mark[(int)markno].Image = bitmap;
			});
			if (USR3.mPcbCheck.mMarkPara == null)
			{
				USR3.mPcbCheck.mMarkPara = new MARK_PARA[2]
				{
					new MARK_PARA(),
					new MARK_PARA()
				};
			}
			USR3.mPcbCheck.mMarkPara[(int)markno].mPara.mLedOn = USR.mIsMarkLedOn;
			USR3.mPcbCheck.mMarkPara[(int)markno].mPara.mLightOn = USR.mIsMarkLightOn;
			for (int i = 0; i < HW.mMarkLedNum; i++)
			{
				USR3.mPcbCheck.mMarkPara[(int)markno].mPara.mParaLed[i] = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[i];
			}
			for (int j = 0; j < 4; j++)
			{
				USR3.mPcbCheck.mMarkPara[(int)markno].mPara.mParaCam[j] = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[j];
			}
			Invoke((MethodInvoker)delegate
			{
				label_XY[(int)markno].Text = MainForm0.format_XY_label_string(USR3.mPcbCheck.mMark[(int)markno]);
			});
			USR3.mMarkPic[(int)markno] = new Bitmap(newbitmap_des);
			USR3.mMarkPara[(int)markno].mPicMark = new Bitmap(newbitmap_des);
			USR3.mMarkPara[(int)markno].mPara.mLedOn = USR3.mPcbCheck.mMarkPara[(int)markno].mPara.mLedOn;
			USR3.mMarkPara[(int)markno].mPara.mLightOn = USR3.mPcbCheck.mMarkPara[(int)markno].mPara.mLightOn;
			for (int k = 0; k < HW.mMarkLedNum; k++)
			{
				USR3.mMarkPara[(int)markno].mPara.mParaLed[k] = USR3.mPcbCheck.mMarkPara[(int)markno].mPara.mParaLed[k];
			}
			for (int l = 0; l < 4; l++)
			{
				USR3.mMarkPara[(int)markno].mPara.mParaCam[l] = USR3.mPcbCheck.mMarkPara[(int)markno].mPara.mParaCam[l];
			}
			Invoke((MethodInvoker)delegate
			{
				if (uc_pcbedit_datagridview != null)
				{
					uc_pcbedit_datagridview.update_uc_pcbedit_mark();
				}
			});
			MainForm0.save_usrProjectData();
		}

		private void button_GotoXY0_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int num = (((int)button.Tag != 0) ? 1 : 0);
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR3.mPcbCheck.mMark[num]);
			}
		}

		public void thd_manual_mark()
		{
			bool issuccess = false;
			UserControl_SmtMarkRecognize uc_smtMark = null;
			Invoke((MethodInvoker)delegate
			{
				if (uc_smtMark == null || uc_smtMark.IsDisposed)
				{
					uc_smtMark = new UserControl_SmtMarkRecognize(mFn, USR, USR3, 0, isauto: true);
					base.Controls.Add(uc_smtMark);
					uc_smtMark.Visible = true;
					uc_smtMark.Location = new Point(217, 6);
					uc_smtMark.BringToFront();
				}
			});
			int markno;
			Bitmap newbitmap_des;
			for (markno = 0; markno < 2; markno++)
			{
				MainForm0.uc_job[mFn].mMarkFound[markno].X = USR3.mMark[markno].X;
				MainForm0.uc_job[mFn].mMarkFound[markno].Y = USR3.mMark[markno].Y;
				bool is_automark = false;
				Invoke((MethodInvoker)delegate
				{
					uc_smtMark.set_mode(USR3, markno, is_automark, is_automark ? (new string[3] { "自动匹配", "自動匹配", "Auto Match" })[USR_INIT.mLanguage] : (new string[3] { "手动确认", "手動確認", "Manual Confirm" })[USR_INIT.mLanguage]);
					uc_smtMark.Visible = true;
					uc_smtMark.BringToFront();
				});
				MainForm0.uc_job[mFn].mbMarkDoneMutex = false;
				MainForm0.moveToXY_andWait_Smt(mFn, USR3B.mSmtXYSpeed, USR3.mMarkSearch[markno]);
				while (!MainForm0.uc_job[mFn].mbMarkDoneMutex)
				{
					Thread.Sleep(2);
				}
				int num = 2;
				if (uc_smtMark != null)
				{
					num = uc_smtMark.get_mark_ok();
				}
				switch (num)
				{
				case 0:
					issuccess = true;
					if (!MainForm0.mIsSimulation)
					{
						MainForm0.uc_job[mFn].mMarkFound[markno].X = MainForm0.mCur[mFn].x;
						MainForm0.uc_job[mFn].mMarkFound[markno].Y = MainForm0.mCur[mFn].y;
						USR3.mPcbCheck.mMark[markno].X = MainForm0.mCur[mFn].x;
						USR3.mPcbCheck.mMark[markno].Y = MainForm0.mCur[mFn].y;
						int num2 = HW.mMarkCamItem[mFn].index[0];
						MainForm0.startMarkStill_andWait(mFn);
						int num3 = (int)(150f * (float)MainForm0.mJvs_rawHeight / (float)MainForm0.mJvs_usrHeight);
						Rectangle destRect = new Rectangle(0, 0, 150, 150);
						Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - 150) / 2, (MainForm0.mJvs_rawHeight - num3) / 2, 150, num3);
						newbitmap_des = new Bitmap(150, 150);
						if (!MainForm0.mIsSimulation)
						{
							Graphics graphics = Graphics.FromImage(newbitmap_des);
							graphics.DrawImage(MainForm0.mJVSBitmap[num2], destRect, srcRect, GraphicsUnit.Pixel);
							graphics.Dispose();
						}
						else
						{
							newbitmap_des = new Bitmap(MainForm0.SIGN_PICTURE[markno]);
						}
						USR3.mPcbCheck.mMarkPic[markno] = newbitmap_des;
						Invoke((MethodInvoker)delegate
						{
							Bitmap bitmap = new Bitmap(newbitmap_des);
							bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
							pic_mark[markno].Image = bitmap;
						});
						Invoke((MethodInvoker)delegate
						{
							label_XY[markno].Text = MainForm0.format_XY_label_string(USR3.mPcbCheck.mMark[markno]);
						});
						MainForm0.save_usrProjectData();
					}
					continue;
				case 1:
					MainForm0.mRunDoing[mFn] = 0;
					issuccess = false;
					break;
				case 2:
					issuccess = false;
					break;
				default:
					continue;
				}
				break;
			}
			if (!issuccess)
			{
				return;
			}
			if (!MainForm0.uc_job[mFn].fun_isNewMarkReasonable(USR3.mMark, MainForm0.uc_job[mFn].mMarkFound) && !MainForm0.mIsSimulation)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Current MARK is far different from PCB MARK, please check!" : "系统发现当前确认的Mark点，与工程板的Mark点位置关系差异过大，请检查！");
				return;
			}
			MainForm0.common_waiting_start("正在更新数据列表...", 30);
			USR3.mPcbCheck.mAngle = (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mMark, MainForm0.uc_job[mFn].mMarkFound) * 180.0 / Math.PI);
			for (int i = 0; i < USR3.mPointlist.Count; i++)
			{
				ChipBoardElement chipBoardElement = USR3.mPointlist[i];
				Coordinate coordinate = MainForm0.uc_job[mFn].fun_newxy(USR3.mMark, MainForm0.uc_job[mFn].mMarkFound, new Coordinate(chipBoardElement.X, chipBoardElement.Y));
				if (coordinate.X < 0)
				{
					coordinate.X = 0L;
				}
				if (coordinate.Y < 0)
				{
					coordinate.Y = 0L;
				}
				chipBoardElement.X_Real = (int)coordinate.X;
				chipBoardElement.Y_Real = (int)coordinate.Y;
				chipBoardElement.A_Real = chipBoardElement.A + USR3.mPcbCheck.mAngle;
			}
			Invoke((MethodInvoker)delegate
			{
				pcbCheck_flushDataGridview(issuccess);
			});
			MainForm0.common_waiting_break();
		}

		private void button_MarkRecRun_Click(object sender, EventArgs e)
		{
			Form_BoxSel form_BoxSel = new Form_BoxSel("MARK点识别=>数据列表", "自动MARK", "手动MARK", "");
			switch (form_BoxSel.ShowDialog())
			{
			case DialogResult.OK:
				if (this.cb_pcbcheck_start != null)
				{
					this.cb_pcbcheck_start(USR3, a: true);
				}
				break;
			case DialogResult.Yes:
			{
				Thread thread = new Thread(thd_manual_mark);
				thread.IsBackground = true;
				thread.Start();
				break;
			}
			}
		}

		private void button_CheckOriginalMark_Click(object sender, EventArgs e)
		{
			Form_MarkCheck form_MarkCheck = new Form_MarkCheck(USR3);
			form_MarkCheck.Show();
			form_MarkCheck.TopMost = true;
			form_MarkCheck.Location = new Point(660, 326);
		}

		private void button_GenAll_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox("是否将当前的数据列表和MARK都更新到原始列表中? 不可恢复！", MessageBoxButtons.YesNo) == DialogResult.Yes && USR3.mPointlist != null)
			{
				MainForm0.common_waiting_start("正在更新数据列表...", 30);
				USR3.mMark[0].X = USR3.mPcbCheck.mMark[0].X;
				USR3.mMark[0].Y = USR3.mPcbCheck.mMark[0].Y;
				USR3.mMark[1].X = USR3.mPcbCheck.mMark[1].X;
				USR3.mMark[1].Y = USR3.mPcbCheck.mMark[1].Y;
				if (USR3.mPcbCheck.mMarkPic[0] != null)
				{
					USR3.mMarkPic[0] = new Bitmap(USR3.mPcbCheck.mMarkPic[0]);
				}
				if (USR3.mPcbCheck.mMarkPic[1] != null)
				{
					USR3.mMarkPic[1] = new Bitmap(USR3.mPcbCheck.mMarkPic[1]);
				}
				if (USR3.mPcbCheck.mMarkPic[0] != null)
				{
					USR3.mMarkPara[0].mPicMark = new Bitmap(USR3.mPcbCheck.mMarkPic[0]);
				}
				if (USR3.mPcbCheck.mMarkPic[1] != null)
				{
					USR3.mMarkPara[1].mPicMark = new Bitmap(USR3.mPcbCheck.mMarkPic[1]);
				}
				for (int i = 0; i < USR3.mPointlist.Count; i++)
				{
					USR3.mPointlist[i].X = USR3.mPointlist[i].X_Real;
					USR3.mPointlist[i].Y = USR3.mPointlist[i].Y_Real;
					USR3.mPointlist[i].A = USR3.mPointlist[i].A_Real;
				}
				MainForm0.uc_job[mFn].set_edit_curpcb(flag: true);
				MainForm0.common_waiting_break();
				Dispose();
			}
		}

		private void checkBox_autoselect_nearestMark_CheckedChanged(object sender, EventArgs e)
		{
			MainForm0.mIsAutoSelect_PcbCheck_NearestMarkChip[mFn] = checkBox_autoselect_nearestMark.Checked;
		}

		public void pcbcheck_sel_mark_nearest_chip(Coordinate c)
		{
			if (uc_pcbedit_datagridview != null)
			{
				uc_pcbedit_datagridview.sel_nearest_chip(c);
			}
		}
	}
}
