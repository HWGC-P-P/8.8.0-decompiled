using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON;
using QIGN_COMMON.vs_acontrol;

namespace QIGN_MAIN
{
	public class Form_PikFail : Form
	{
		private IContainer components;

		private CnButton button_continue;

		private CnButton button_skip;

		private CnButton button_abort;

		private Label label_msg;

		private CnButton button_skip_thiskind;

		private CnButton button_stopbuzzer;

		private PictureBox pictureBox1;

		private ListBox listBox1;

		private Label label1;

		private Label label2;

		public PikFail mPikFail;

		public int mPikFailTimes;

		private int mFn;

		public BindingList<int_2d> m_throwlist;

		public BindingList<ChipBoardElement> mElmList;

		public BIGTAB_GROUP m_biggroup;

		private int mLanguage;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.Form_PikFail));
			label_msg = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			listBox1 = new System.Windows.Forms.ListBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_stopbuzzer = new QIGN_COMMON.vs_acontrol.CnButton();
			button_skip_thiskind = new QIGN_COMMON.vs_acontrol.CnButton();
			button_abort = new QIGN_COMMON.vs_acontrol.CnButton();
			button_skip = new QIGN_COMMON.vs_acontrol.CnButton();
			button_continue = new QIGN_COMMON.vs_acontrol.CnButton();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			label_msg.Font = new System.Drawing.Font("黑体", 14.5f);
			label_msg.Location = new System.Drawing.Point(166, 20);
			label_msg.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label_msg.Name = "label_msg";
			label_msg.Size = new System.Drawing.Size(398, 28);
			label_msg.TabIndex = 2;
			label_msg.Text = "提示消息：三次取料失败!!!";
			label_msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			pictureBox1.BackColor = System.Drawing.Color.DimGray;
			pictureBox1.Location = new System.Drawing.Point(703, 64);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(310, 310);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 6;
			pictureBox1.TabStop = false;
			listBox1.Font = new System.Drawing.Font("黑体", 13.5f);
			listBox1.FormattingEnabled = true;
			listBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			listBox1.ItemHeight = 18;
			listBox1.Items.AddRange(new object[4] { "吸嘴1 料站2 C0805 10K", "吸嘴1 料站2 C0805 10K", "吸嘴1 料站2 C0805 10K", "吸嘴1 料站2 C0805 10K" });
			listBox1.Location = new System.Drawing.Point(25, 64);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(666, 256);
			listBox1.TabIndex = 0;
			listBox1.SelectedIndexChanged += new System.EventHandler(listBox1_SelectedIndexChanged);
			label1.BackColor = System.Drawing.Color.White;
			label1.Font = new System.Drawing.Font("黑体", 15.5f);
			label1.Location = new System.Drawing.Point(26, 15);
			label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(155, 38);
			label1.TabIndex = 2;
			label1.Text = "左机";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label1.Visible = false;
			label2.Font = new System.Drawing.Font("黑体", 13.5f);
			label2.Location = new System.Drawing.Point(703, 15);
			label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(310, 46);
			label2.TabIndex = 2;
			label2.Text = "提示消息：三次取料失败!!!";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_stopbuzzer.BackColor = System.Drawing.Color.LightGray;
			button_stopbuzzer.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stopbuzzer.CnPressDownColor = System.Drawing.Color.White;
			button_stopbuzzer.Location = new System.Drawing.Point(536, 15);
			button_stopbuzzer.Name = "button_stopbuzzer";
			button_stopbuzzer.Size = new System.Drawing.Size(155, 38);
			button_stopbuzzer.TabIndex = 5;
			button_stopbuzzer.Text = "停止报警";
			button_stopbuzzer.UseVisualStyleBackColor = false;
			button_stopbuzzer.Click += new System.EventHandler(button_stopbuzzer_Click);
			button_skip_thiskind.BackColor = System.Drawing.Color.LightGray;
			button_skip_thiskind.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_skip_thiskind.CnPressDownColor = System.Drawing.Color.White;
			button_skip_thiskind.Font = new System.Drawing.Font("黑体", 12.5f);
			button_skip_thiskind.Location = new System.Drawing.Point(366, 335);
			button_skip_thiskind.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			button_skip_thiskind.Name = "button_skip_thiskind";
			button_skip_thiskind.Size = new System.Drawing.Size(155, 38);
			button_skip_thiskind.TabIndex = 4;
			button_skip_thiskind.Text = "不贴此料";
			button_skip_thiskind.UseVisualStyleBackColor = false;
			button_skip_thiskind.Click += new System.EventHandler(button_skip_thiskind_Click);
			button_abort.BackColor = System.Drawing.Color.LightGray;
			button_abort.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_abort.CnPressDownColor = System.Drawing.Color.White;
			button_abort.Font = new System.Drawing.Font("黑体", 12.5f);
			button_abort.Location = new System.Drawing.Point(536, 335);
			button_abort.Margin = new System.Windows.Forms.Padding(5);
			button_abort.Name = "button_abort";
			button_abort.Size = new System.Drawing.Size(155, 38);
			button_abort.TabIndex = 1;
			button_abort.Text = "结束";
			button_abort.UseVisualStyleBackColor = false;
			button_abort.Click += new System.EventHandler(button_abort_Click);
			button_skip.BackColor = System.Drawing.Color.LightGray;
			button_skip.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_skip.CnPressDownColor = System.Drawing.Color.White;
			button_skip.Font = new System.Drawing.Font("黑体", 12.5f);
			button_skip.Location = new System.Drawing.Point(195, 335);
			button_skip.Margin = new System.Windows.Forms.Padding(5);
			button_skip.Name = "button_skip";
			button_skip.Size = new System.Drawing.Size(155, 38);
			button_skip.TabIndex = 1;
			button_skip.Text = "跳过一次";
			button_skip.UseVisualStyleBackColor = false;
			button_skip.Click += new System.EventHandler(button_skip_Click);
			button_continue.BackColor = System.Drawing.Color.LightGray;
			button_continue.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_continue.CnPressDownColor = System.Drawing.Color.White;
			button_continue.Font = new System.Drawing.Font("黑体", 12.5f);
			button_continue.Location = new System.Drawing.Point(26, 335);
			button_continue.Margin = new System.Windows.Forms.Padding(5);
			button_continue.Name = "button_continue";
			button_continue.Size = new System.Drawing.Size(155, 38);
			button_continue.TabIndex = 0;
			button_continue.Text = "继续尝试";
			button_continue.UseVisualStyleBackColor = false;
			button_continue.Click += new System.EventHandler(button_continue_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(1042, 391);
			base.Controls.Add(listBox1);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(button_stopbuzzer);
			base.Controls.Add(button_skip_thiskind);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(label_msg);
			base.Controls.Add(button_abort);
			base.Controls.Add(button_skip);
			base.Controls.Add(button_continue);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(5);
			base.Name = "Form_PikFail";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "  ";
			base.TopMost = true;
			base.Load += new System.EventHandler(Form_PikFail_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		public Form_PikFail(int fn, int language, int failtimes, BindingList<int_2d> throwlist, BIGTAB_GROUP biggroup)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mLanguage = language;
			initLanguageTable();
			updateLanguage(mLanguage);
			mPikFail = PikFail.Exit;
			mFn = fn;
			m_throwlist = throwlist;
			m_biggroup = biggroup;
			base.ControlBox = false;
			label_msg.Text = ((mLanguage == 2) ? "WARNING: " : "报警：连续") + failtimes + ((mLanguage == 2) ? "times pick chip fail" : "次取料失败！！");
			listBox1.Items.Clear();
			if (throwlist == null || throwlist.Count <= 0)
			{
				return;
			}
			string[][] array = new string[2][]
			{
				new string[3] { "[左机]", "[左机]", "[Left]" },
				new string[3] { "[右机]", "[右机]", "[Right]" }
			};
			if (HW.mFnNum == 2)
			{
				label1.Visible = true;
				label1.Text = array[mFn][mLanguage];
			}
			for (int i = 0; i < throwlist.Count; i++)
			{
				int a = throwlist[i].a;
				BIGTAB_2_ITEM bIGTAB_2_ITEM = biggroup.mnt_arr[a];
				string text = "Group " + bIGTAB_2_ITEM.group_no + ", " + STR.PROVIDER_STR[(int)bIGTAB_2_ITEM.providertype][mLanguage] + " No." + (bIGTAB_2_ITEM.stackno + 1).ToString("D2") + ", Noz No." + (bIGTAB_2_ITEM.zn + 1) + ", " + bIGTAB_2_ITEM.materialvalue;
				string text2 = "轮组" + bIGTAB_2_ITEM.group_no + ", " + STR.PROVIDER_STR[(int)bIGTAB_2_ITEM.providertype][mLanguage] + (bIGTAB_2_ITEM.stackno + 1).ToString("D2") + ", 吸嘴" + (bIGTAB_2_ITEM.zn + 1) + ", " + bIGTAB_2_ITEM.materialvalue;
				string text3 = STR.VISUAL_STR[(int)bIGTAB_2_ITEM.visualtype][mLanguage] + " " + STR.LOOP_STR[(int)bIGTAB_2_ITEM.looptype][mLanguage] + ", " + ((mLanguage == 2) ? text : text2);
				if (HW.mFnNum == 2)
				{
					text3 = array[mFn][mLanguage] + text3;
				}
				listBox1.Items.Add(text3);
				if (i == 0)
				{
					pictureBox1.Image = new Bitmap(MainForm0.newBitmaps_des[mFn][bIGTAB_2_ITEM.zn]);
				}
			}
			listBox1.SelectedIndex = 0;
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
					mLanguage2.ctrl.Font = new Font(DEF.FONT_2020_TITLE[mLanguage], mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
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
				ctrl = label_msg,
				str = new string[3] { "提示消息：三次取料失败!!!", "提示消息：三次取料失败!!!", "NOTICE: PICK CHIP FAIL 3 TIMES" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_continue,
				str = new string[3] { "继续尝试", "继续尝试", "TRY AGAIN" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_skip,
				str = new string[3] { "跳过一次", "跳过一次", "SKIP ONCE" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_skip_thiskind,
				str = new string[3] { "不贴此料", "不贴此料", "SKIP ALL" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_abort,
				str = new string[3] { "结束贴装", "结束贴装", "SMT ABORT" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stopbuzzer,
				str = new string[3] { "停止报警", "停止报警", "STOP BUZZER" }
			});
		}

		private void button_abort_Click(object sender, EventArgs e)
		{
			mPikFail = PikFail.Exit;
			base.DialogResult = DialogResult.Abort;
		}

		private void button_skip_Click(object sender, EventArgs e)
		{
			mPikFail = PikFail.SkipOnce;
			base.DialogResult = DialogResult.Ignore;
		}

		private void button_continue_Click(object sender, EventArgs e)
		{
			mPikFail = PikFail.Retry;
			base.DialogResult = DialogResult.Retry;
		}

		private void button_skip_thiskind_Click(object sender, EventArgs e)
		{
			mPikFail = PikFail.SkipChip;
			base.DialogResult = DialogResult.No;
		}

		public PikFail get_pikfail()
		{
			return mPikFail;
		}

		private void Form_PikFail_Load(object sender, EventArgs e)
		{
		}

		private void button_stopbuzzer_Click(object sender, EventArgs e)
		{
			MainForm0.mIsBuzzerWarning[mFn] = false;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = listBox1.SelectedIndex;
			if (m_throwlist != null && selectedIndex >= 0 && selectedIndex < m_throwlist.Count)
			{
				int a = m_throwlist[selectedIndex].a;
				BIGTAB_2_ITEM bIGTAB_2_ITEM = m_biggroup.mnt_arr[a];
				if (bIGTAB_2_ITEM.zn >= 0 && bIGTAB_2_ITEM.zn < HW.mZnNum[mFn])
				{
					label2.Text = listBox1.Items[selectedIndex].ToString();
					pictureBox1.Image = new Bitmap(MainForm0.newBitmaps_des[mFn][bIGTAB_2_ITEM.zn]);
				}
			}
		}
	}
}
