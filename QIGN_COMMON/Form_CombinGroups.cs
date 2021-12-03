using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_class;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_CombinGroups : Form
	{
		public enum PcbHead
		{
			ISMOUNT,
			GROUP,
			ARRAY,
			LABEL,
			VALUE,
			FOOTPRINT,
			X,
			Y,
			A,
			STACKTYPE,
			STACKNO,
			NOZZLE,
			CAM,
			VISUAL,
			LOWSPEED,
			NUM
		}

		private BindingList<ChipBoardElement> mPointGroup;

		private int mLanguage;

		private BindingList<SmtFeederInstallElement> mFeederList;

		private bool isForce_SamePik;

		public USR_DATA USR;

		public USR3_DATA USR3;

		public USR2_DATA USR2;

		private int mFn;

		public string[][] mSearchString = new string[15][]
		{
			STR.ALL,
			STR.GROUP,
			STR.PCB_ARRAY,
			STR.CHIP_LABEL,
			STR.CHIP_VALUE,
			STR.CHIP_PRINTFOOT,
			STR.XCOORDIN,
			STR.YCOORDIN,
			STR.A_b,
			STR.PROVIDER,
			STR.STACK_NO,
			STR.NOZZLE_NO,
			STR.CAMERA,
			STR.VISUAL,
			STR.LOW_SPEED
		};

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		private IContainer components;

		private Label label1;

		private Button button_OK;

		private Button button_Cancel;

		private CheckBox checkBox_samePik;

		private Panel panel1;

		public Form_CombinGroups(int fn, USR_DATA usr, USR2_DATA usr2, USR3_DATA usr3, BindingList<ChipBoardElement> pointgroup, BindingList<SmtFeederInstallElement> feederlist, bool is_pcbcheck, bool is_editenable)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			initLanguageTable();
			mLanguage = usr.mLanguage;
			updateLanguage(mLanguage);
			mPointGroup = pointgroup;
			mFeederList = feederlist;
			mFn = fn;
			UserControl_pcbedit_datagridview userControl_pcbedit_datagridview = new UserControl_pcbedit_datagridview(mFn, usr, usr2, usr3, mPointGroup, "group_combine", is_pcbcheck, is_editenable);
			base.Controls.Add(userControl_pcbedit_datagridview);
			userControl_pcbedit_datagridview.Location = panel1.Location;
			userControl_pcbedit_datagridview.BringToFront();
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private string chip_search_from_feederList(ProviderType stacktype, int stackno)
		{
			string result = "";
			if (mFeederList == null || mFeederList.Count == 0)
			{
				return result;
			}
			for (int i = 0; i < mFeederList.Count; i++)
			{
				if (mFeederList[i].Stacktype == stacktype && mFeederList[i].Stack_no == stackno)
				{
					result = mFeederList[i].Material_value + mFeederList[i].Footprint;
				}
			}
			return result;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
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
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "合并为同一贴装轮组", "合并为同一贴装轮组", "Combin in Same Group" }
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
				ctrl = checkBox_samePik,
				str = new string[3] { "强制同取", "强制同取", "Force Multi-Pick!" }
			});
		}

		private void checkBox_samePik_CheckedChanged(object sender, EventArgs e)
		{
			isForce_SamePik = checkBox_samePik.Checked;
		}

		public bool get_IsForceSamePik()
		{
			return isForce_SamePik;
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
			label1 = new System.Windows.Forms.Label();
			button_OK = new System.Windows.Forms.Button();
			button_Cancel = new System.Windows.Forms.Button();
			checkBox_samePik = new System.Windows.Forms.CheckBox();
			panel1 = new System.Windows.Forms.Panel();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 14.25f);
			label1.Location = new System.Drawing.Point(318, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(229, 19);
			label1.TabIndex = 1;
			label1.Text = "合并元件为同一贴装轮组";
			button_OK.BackColor = System.Drawing.Color.LightSalmon;
			button_OK.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OK.Location = new System.Drawing.Point(280, 387);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(100, 37);
			button_OK.TabIndex = 2;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = false;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			button_Cancel.BackColor = System.Drawing.Color.NavajoWhite;
			button_Cancel.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Cancel.Location = new System.Drawing.Point(511, 387);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(100, 37);
			button_Cancel.TabIndex = 2;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = false;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			checkBox_samePik.AutoSize = true;
			checkBox_samePik.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_samePik.Location = new System.Drawing.Point(701, 20);
			checkBox_samePik.Name = "checkBox_samePik";
			checkBox_samePik.Size = new System.Drawing.Size(91, 20);
			checkBox_samePik.TabIndex = 4;
			checkBox_samePik.Text = "强制同取";
			checkBox_samePik.UseVisualStyleBackColor = true;
			checkBox_samePik.CheckedChanged += new System.EventHandler(checkBox_samePik_CheckedChanged);
			panel1.Location = new System.Drawing.Point(42, 42);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(828, 329);
			panel1.TabIndex = 5;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.PapayaWhip;
			base.ClientSize = new System.Drawing.Size(914, 438);
			base.Controls.Add(panel1);
			base.Controls.Add(checkBox_samePik);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(button_OK);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_CombinGroups";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
