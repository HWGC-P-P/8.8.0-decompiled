using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON;
using QIGN_COMMON.vs_acontrol;

namespace QIGN_MAIN
{
	public class Form_StackCopy : Form
	{
		public int mCurStackNo;

		public int mStack_SelIndex;

		public int mStackNum;

		public string mStackString;

		public StackElement[] mStack;

		public StackCopySt mStackCopy;

		public bool mIsoffsetMode;

		public CheckBox checkbox_allNozzles;

		public CheckBox[] checkbox_nozzle;

		public CheckBox checkbox_allStacks;

		public CheckBox checkbox_allUsedStacks;

		public CheckBox[] checkbox_stack;

		public CheckBox checkbox_para_all;

		public CheckBox[] checkbox_para;

		public int mLanguage;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		private IContainer components;

		private Label label1;

		private Panel panel_parameter;

		private Panel panel_nozzle;

		private Panel panel_stack;

		private CnButton button_OK;

		private CnButton button_Cancel;

		private Label label3;

		private Label label_InfoLeft;

		private Label label_curStackNo;

		private Label label_title;

		private Label label6;

		private Label label_stacktile;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		public Form_StackCopy()
		{
			InitializeComponent();
		}

		public Form_StackCopy(int language, int curstack, int stacksel_index, StackElement[] stacks, StackCopySt stackcopy, bool isoffsetmode)
		{
			InitializeComponent();
			mLanguage = language;
			base.Icon = MainForm0.GetIcon(1);
			initLanguageTable();
			updateLanguage(mLanguage);
			mCurStackNo = curstack;
			mStack_SelIndex = stacksel_index;
			mStack = stacks;
			mStackCopy = stackcopy;
			mIsoffsetMode = isoffsetmode;
			if (mStack_SelIndex == 0)
			{
				mStackString = STR.STACK[mLanguage];
			}
			else if (mStack_SelIndex == 2)
			{
				mStackString = STR.VIBRA[mLanguage];
			}
			else
			{
				if (mStack_SelIndex != 1)
				{
					return;
				}
				mStackString = STR.PLATE[mLanguage];
			}
			mStackNum = HW.mStackNum[MainForm0.mFn][mStack_SelIndex];
			int num = mCurStackNo;
			label_curStackNo.Text = (num + 1).ToString();
			label_title.Text = mStackString + STR.PARA[mLanguage] + STR.BULK_COPY[mLanguage];
			if (mStack[mCurStackNo].mChipValue == null)
			{
				mStack[mCurStackNo].mChipValue = "";
			}
			if (mStack[mCurStackNo].mChipFootprint == null)
			{
				mStack[mCurStackNo].mChipFootprint = "";
			}
			label_InfoLeft.Text = mStackString + STR.NUMINDEX[mLanguage] + ": " + (num + 1) + Environment.NewLine + STR.CHIP_VALUE[mLanguage] + ": " + mStack[mCurStackNo].mChipValue + Environment.NewLine + STR.CHIP_PRINTFOOT[mLanguage] + ": " + mStack[mCurStackNo].mChipFootprint;
			panel_nozzle.Size = new Size(90, 190);
			checkbox_allNozzles = new CheckBox();
			panel_nozzle.Controls.Add(checkbox_allNozzles);
			checkbox_allNozzles.Text = STR.ALL[mLanguage];
			checkbox_allNozzles.Location = new Point(5, 2);
			checkbox_allNozzles.CheckedChanged += checkBox_allNozzles_CheckedChanged;
			checkbox_allNozzles.Font = new Font(STR.LANGUAGE[mLanguage], checkbox_allNozzles.Font.Size + DEF.FSIZE_2020[mLanguage], FontStyle.Regular);
			checkbox_nozzle = new CheckBox[HW.mZnNum[MainForm0.mFn]];
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				checkbox_nozzle[i] = new CheckBox();
				panel_nozzle.Controls.Add(checkbox_nozzle[i]);
				checkbox_nozzle[i].Text = STR.NOZZLE_a[mLanguage] + (i + 1);
				checkbox_nozzle[i].Location = new Point(5, 2 + 20 * (i + 1));
				checkbox_nozzle[i].ForeColor = (mStack[mCurStackNo].mZnData[i].mEnabled ? Color.Black : Color.DimGray);
				checkbox_nozzle[i].Font = new Font(STR.LANGUAGE[mLanguage], checkbox_nozzle[i].Font.Size + DEF.FSIZE_2020[mLanguage], FontStyle.Regular);
			}
			label_stacktile.Text = mStackString + STR.SEL[mLanguage];
			checkbox_allStacks = new CheckBox();
			panel_stack.Controls.Add(checkbox_allStacks);
			checkbox_allStacks.Text = STR.SEL_ALL[mLanguage] + mStackString;
			checkbox_allStacks.Location = new Point(5, 2);
			checkbox_allStacks.Size = new Size(140, 25);
			checkbox_allStacks.CheckedChanged += checkBox_allStacks_CheckedChanged;
			checkbox_allStacks.Font = new Font(STR.LANGUAGE[mLanguage], checkbox_allStacks.Font.Size + DEF.FSIZE_2020[mLanguage], FontStyle.Regular);
			checkbox_allUsedStacks = new CheckBox();
			panel_stack.Controls.Add(checkbox_allUsedStacks);
			checkbox_allUsedStacks.Text = STR.SEL_USE[mLanguage] + mStackString;
			checkbox_allUsedStacks.Location = new Point(165, 2);
			checkbox_allUsedStacks.Size = new Size(140, 25);
			checkbox_allUsedStacks.CheckedChanged += checkBox_allUsedStacks_CheckedChanged;
			checkbox_allUsedStacks.Font = new Font(STR.LANGUAGE[mLanguage], checkbox_allUsedStacks.Font.Size + DEF.FSIZE_2020[mLanguage], FontStyle.Regular);
			checkbox_stack = new CheckBox[mStackNum];
			for (int j = 0; j < mStackNum; j++)
			{
				checkbox_stack[j] = new CheckBox();
				panel_stack.Controls.Add(checkbox_stack[j]);
				checkbox_stack[j].Text = mStackString + (j + 1);
				checkbox_stack[j].Tag = j;
				int num2 = j % 35;
				int num3 = j / 35;
				checkbox_stack[j].Location = new Point(5 + num3 * (((mStack_SelIndex == 2) ? 120 : 80) + 220), 24 + 20 * num2);
				checkbox_stack[j].Size = new Size((mStack_SelIndex == 2) ? 340 : 300, 25);
				checkbox_stack[j].ForeColor = (mStack[j].mSelected ? Color.Black : Color.DimGray);
				checkbox_stack[j].Enabled = ((j != mCurStackNo) ? true : false);
				checkbox_stack[j].Font = new Font(STR.LANGUAGE[mLanguage], checkbox_stack[j].Font.Size + DEF.FSIZE_2020[mLanguage], FontStyle.Regular);
				CheckBox obj = checkbox_stack[j];
				string text = obj.Text;
				obj.Text = text + "  " + mStack[j].mChipFootprint + " " + mStack[j].mChipValue;
			}
			checkbox_para_all = new CheckBox();
			panel_parameter.Controls.Add(checkbox_para_all);
			checkbox_para_all.Text = STR.ALL[mLanguage];
			checkbox_para_all.Location = new Point(5, 2);
			checkbox_para_all.CheckedChanged += checkBox_para_all_CheckedChanged;
			checkbox_para = new CheckBox[17];
			for (int k = 0; k < 17; k++)
			{
				checkbox_para[k] = new CheckBox();
				panel_parameter.Controls.Add(checkbox_para[k]);
				checkbox_para[k].Location = new Point(5, 2 + 20 * (k + 1));
				checkbox_para[k].Tag = k;
				checkbox_para[k].Font = new Font(STR.LANGUAGE[mLanguage], checkbox_para[k].Font.Size + DEF.FSIZE_2020[mLanguage], FontStyle.Regular);
				checkbox_para[k].Size = new Size(160, 25);
				checkbox_para[k].AutoSize = false;
				switch (k)
				{
				case 0:
					checkbox_para[k].Text = (mIsoffsetMode ? "取料下压mm" : STR.PIK_H[mLanguage]);
					break;
				case 1:
					checkbox_para[k].Text = STR.PIK_DLY[mLanguage];
					break;
				case 3:
					checkbox_para[k].Text = STR.PIK_UP_SPD[mLanguage];
					break;
				case 2:
					checkbox_para[k].Text = STR.PIK_DOWN_SPD[mLanguage];
					break;
				case 4:
					checkbox_para[k].Text = (mIsoffsetMode ? "贴装下压mm" : STR.MNT_H[mLanguage]);
					break;
				case 5:
					checkbox_para[k].Text = STR.MNT_DLY[mLanguage];
					break;
				case 7:
					checkbox_para[k].Text = STR.MNT_UP_SPD[mLanguage];
					break;
				case 6:
					checkbox_para[k].Text = STR.MNT_DOWN_SPD[mLanguage];
					break;
				case 8:
					checkbox_para[k].Text = STR.CHAR_REC[mLanguage];
					break;
				case 9:
					checkbox_para[k].Text = STR.CHAR_DELTA[mLanguage];
					break;
				case 10:
					checkbox_para[k].Text = STR.SCAN_R[mLanguage];
					break;
				case 11:
					checkbox_para[k].Text = STR.THRESHOLD[mLanguage];
					break;
				case 12:
					checkbox_para[k].Text = ((mStack_SelIndex == 1) ? "自动供料延时" : "飞达连续换料延时");
					break;
				case 13:
					checkbox_para[k].Text = "元件长";
					break;
				case 14:
					checkbox_para[k].Text = "元件宽";
					break;
				case 15:
					checkbox_para[k].Text = "元件厚";
					break;
				case 16:
					checkbox_para[k].Text = "高清相机特参";
					break;
				}
			}
		}

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
				if (mLanguage2.font != null && mLanguage2.fsize != null)
				{
					mLanguage2.ctrl.Font = new Font(mLanguage2.font[mLanguage], mLanguage2.ctrl.Font.Size + mLanguage2.fsize[mLanguage], mLanguage2.ctrl.Font.Style);
					continue;
				}
				switch (mLanguage)
				{
				case 2:
					mLanguage2.ctrl.Font = new Font("Oswald", mLanguage2.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					mLanguage2.ctrl.Font = new Font("微软雅黑", mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
					break;
				}
			}
		}

		private void initLanguageTable()
		{
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_title,
				str = new string[3] { "料站参数批量拷贝", "料站参数批量拷贝", "PARAMETER BULK COPY" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "吸嘴号", "吸嘴号", "NOZZLE" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "拷贝参数", "拷贝参数", "BULK COPY" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_stacktile,
				str = new string[3] { "料站号", "料站号", "STACK" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OK,
				str = new string[3] { "确定", "确定", "OK" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Cancel,
				str = new string[3] { "取消", "取消", "CANCEL" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_InfoLeft,
				str = new string[3] { "", "", "" }
			});
		}

		private void checkBox_para_all_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < 17; i++)
			{
				checkbox_para[i].Checked = checkbox_para_all.Checked;
			}
		}

		private void checkBox_allNozzles_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				checkbox_nozzle[i].Checked = checkbox_allNozzles.Checked;
			}
		}

		private void checkBox_allStacks_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < mStackNum; i++)
			{
				if (i != mCurStackNo)
				{
					checkbox_stack[i].Checked = checkbox_allStacks.Checked;
				}
			}
		}

		private void checkBox_allUsedStacks_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < mStackNum; i++)
			{
				if (mStack[i].mSelected && i != mCurStackNo)
				{
					checkbox_stack[i].Checked = checkbox_allUsedStacks.Checked;
				}
			}
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				mStackCopy.nozzle[i] = checkbox_nozzle[i].Checked;
			}
			for (int j = 0; j < 17; j++)
			{
				mStackCopy.para[j] = checkbox_para[j].Checked;
			}
			for (int k = 0; k < mStackNum; k++)
			{
				mStackCopy.stack[k] = checkbox_stack[k].Checked;
			}
			base.DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Form_StackCopy_Load(object sender, EventArgs e)
		{
		}

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.Form_StackCopy));
			label1 = new System.Windows.Forms.Label();
			panel_parameter = new System.Windows.Forms.Panel();
			panel_nozzle = new System.Windows.Forms.Panel();
			panel_stack = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			label_InfoLeft = new System.Windows.Forms.Label();
			label_curStackNo = new System.Windows.Forms.Label();
			label_title = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label_stacktile = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			button_Cancel = new QIGN_COMMON.vs_acontrol.CnButton();
			button_OK = new QIGN_COMMON.vs_acontrol.CnButton();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 12f);
			label1.Location = new System.Drawing.Point(11, 13);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 16);
			label1.TabIndex = 0;
			label1.Text = "吸嘴号";
			panel_parameter.BackColor = System.Drawing.Color.NavajoWhite;
			panel_parameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_parameter.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_parameter.Location = new System.Drawing.Point(112, 35);
			panel_parameter.Name = "panel_parameter";
			panel_parameter.Size = new System.Drawing.Size(165, 450);
			panel_parameter.TabIndex = 4;
			panel_nozzle.BackColor = System.Drawing.Color.NavajoWhite;
			panel_nozzle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_nozzle.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_nozzle.Location = new System.Drawing.Point(15, 35);
			panel_nozzle.Name = "panel_nozzle";
			panel_nozzle.Size = new System.Drawing.Size(91, 450);
			panel_nozzle.TabIndex = 6;
			panel_stack.BackColor = System.Drawing.Color.NavajoWhite;
			panel_stack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			panel_stack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_stack.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_stack.Location = new System.Drawing.Point(6, 33);
			panel_stack.Name = "panel_stack";
			panel_stack.Size = new System.Drawing.Size(895, 734);
			panel_stack.TabIndex = 7;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 12f);
			label3.Location = new System.Drawing.Point(112, 13);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(72, 16);
			label3.TabIndex = 9;
			label3.Text = "复制参数";
			label_InfoLeft.AutoSize = true;
			label_InfoLeft.Font = new System.Drawing.Font("黑体", 12f);
			label_InfoLeft.Location = new System.Drawing.Point(21, 535);
			label_InfoLeft.Name = "label_InfoLeft";
			label_InfoLeft.Size = new System.Drawing.Size(96, 32);
			label_InfoLeft.TabIndex = 10;
			label_InfoLeft.Text = "元件名称 : \r\n元件封装 : ";
			label_curStackNo.BackColor = System.Drawing.Color.NavajoWhite;
			label_curStackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_curStackNo.Font = new System.Drawing.Font("微软雅黑", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_curStackNo.Location = new System.Drawing.Point(27, 4);
			label_curStackNo.Name = "label_curStackNo";
			label_curStackNo.Size = new System.Drawing.Size(65, 44);
			label_curStackNo.TabIndex = 10;
			label_curStackNo.Text = "68";
			label_curStackNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_title.AutoSize = true;
			label_title.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_title.Location = new System.Drawing.Point(95, 11);
			label_title.Name = "label_title";
			label_title.Size = new System.Drawing.Size(169, 19);
			label_title.TabIndex = 11;
			label_title.Text = "料站参数批量拷贝";
			label6.Font = new System.Drawing.Font("微软雅黑", 42f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label6.Location = new System.Drawing.Point(301, 132);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(62, 77);
			label6.TabIndex = 13;
			label6.Text = "➠";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			groupBox1.Controls.Add(label_stacktile);
			groupBox1.Controls.Add(panel_stack);
			groupBox1.Font = new System.Drawing.Font("黑体", 10.5f);
			groupBox1.Location = new System.Drawing.Point(355, 43);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(907, 773);
			groupBox1.TabIndex = 15;
			groupBox1.TabStop = false;
			label_stacktile.AutoSize = true;
			label_stacktile.Font = new System.Drawing.Font("黑体", 12f);
			label_stacktile.Location = new System.Drawing.Point(6, 12);
			label_stacktile.Name = "label_stacktile";
			label_stacktile.Size = new System.Drawing.Size(56, 16);
			label_stacktile.TabIndex = 9;
			label_stacktile.Text = "料站号";
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(panel_nozzle);
			groupBox2.Controls.Add(label_InfoLeft);
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(panel_parameter);
			groupBox2.Font = new System.Drawing.Font("黑体", 10.5f);
			groupBox2.Location = new System.Drawing.Point(12, 43);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(283, 621);
			groupBox2.TabIndex = 16;
			groupBox2.TabStop = false;
			button_Cancel.BackColor = System.Drawing.Color.NavajoWhite;
			button_Cancel.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_Cancel.CnPressDownColor = System.Drawing.Color.White;
			button_Cancel.Font = new System.Drawing.Font("黑体", 12f);
			button_Cancel.Location = new System.Drawing.Point(738, 822);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(103, 39);
			button_Cancel.TabIndex = 8;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = false;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			button_OK.BackColor = System.Drawing.Color.Tan;
			button_OK.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_OK.CnPressDownColor = System.Drawing.Color.White;
			button_OK.Font = new System.Drawing.Font("黑体", 12f);
			button_OK.Location = new System.Drawing.Point(531, 822);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(105, 39);
			button_OK.TabIndex = 8;
			button_OK.Text = " 确定";
			button_OK.UseVisualStyleBackColor = false;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.PapayaWhip;
			base.ClientSize = new System.Drawing.Size(1274, 871);
			base.Controls.Add(label_curStackNo);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(label6);
			base.Controls.Add(label_title);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(button_OK);
			Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Form_StackCopy";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_StackCopy_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
