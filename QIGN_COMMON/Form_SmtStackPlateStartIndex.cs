using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_SmtStackPlateStartIndex : Form
	{
		private IContainer components;

		private ListBox listBox_StackPlateAll;

		private Label label_StackPlate;

		private Button button_OK;

		private Button button_Cancel;

		private Label label_startindex;

		private Label label_title;

		private Label label_info;

		private int mLanguage;

		public int mCurStackPlateNo;

		public StackElement[] mPlate;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.Form_SmtStackPlateStartIndex));
			listBox_StackPlateAll = new System.Windows.Forms.ListBox();
			label_StackPlate = new System.Windows.Forms.Label();
			button_OK = new System.Windows.Forms.Button();
			button_Cancel = new System.Windows.Forms.Button();
			label_startindex = new System.Windows.Forms.Label();
			label_title = new System.Windows.Forms.Label();
			label_info = new System.Windows.Forms.Label();
			SuspendLayout();
			listBox_StackPlateAll.ColumnWidth = 30;
			listBox_StackPlateAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			listBox_StackPlateAll.Font = new System.Drawing.Font("Cambria", 15f);
			listBox_StackPlateAll.FormattingEnabled = true;
			listBox_StackPlateAll.ItemHeight = 23;
			listBox_StackPlateAll.Location = new System.Drawing.Point(122, 89);
			listBox_StackPlateAll.MultiColumn = true;
			listBox_StackPlateAll.Name = "listBox_StackPlateAll";
			listBox_StackPlateAll.Size = new System.Drawing.Size(487, 73);
			listBox_StackPlateAll.TabIndex = 50;
			label_StackPlate.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			label_StackPlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_StackPlate.Font = new System.Drawing.Font("黑体", 30.25f);
			label_StackPlate.Location = new System.Drawing.Point(19, 68);
			label_StackPlate.Name = "label_StackPlate";
			label_StackPlate.Size = new System.Drawing.Size(94, 94);
			label_StackPlate.TabIndex = 51;
			label_StackPlate.Text = "P15";
			label_StackPlate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_OK.BackColor = System.Drawing.Color.LightSalmon;
			button_OK.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OK.Location = new System.Drawing.Point(211, 181);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(140, 50);
			button_OK.TabIndex = 52;
			button_OK.Text = "选择起始料号";
			button_OK.UseVisualStyleBackColor = false;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			button_Cancel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			button_Cancel.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Cancel.Location = new System.Drawing.Point(399, 181);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(74, 50);
			button_Cancel.TabIndex = 52;
			button_Cancel.Text = "完成";
			button_Cancel.UseVisualStyleBackColor = false;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			label_startindex.AutoSize = true;
			label_startindex.Font = new System.Drawing.Font("黑体", 12f);
			label_startindex.Location = new System.Drawing.Point(10, 198);
			label_startindex.Name = "label_startindex";
			label_startindex.Size = new System.Drawing.Size(128, 16);
			label_startindex.TabIndex = 53;
			label_startindex.Text = " ● 起始索引 : ";
			label_title.AutoSize = true;
			label_title.Font = new System.Drawing.Font("黑体", 14.25f);
			label_title.Location = new System.Drawing.Point(19, 18);
			label_title.Name = "label_title";
			label_title.Size = new System.Drawing.Size(169, 19);
			label_title.TabIndex = 55;
			label_title.Text = "料盘起始索引设置";
			label_info.Font = new System.Drawing.Font("黑体", 12.5f);
			label_info.Location = new System.Drawing.Point(122, 66);
			label_info.Name = "label_info";
			label_info.Size = new System.Drawing.Size(487, 21);
			label_info.TabIndex = 56;
			label_info.Text = "C0402 10uF";
			label_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.PapayaWhip;
			base.ClientSize = new System.Drawing.Size(662, 243);
			base.Controls.Add(label_startindex);
			base.Controls.Add(label_info);
			base.Controls.Add(label_title);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(button_OK);
			base.Controls.Add(label_StackPlate);
			base.Controls.Add(listBox_StackPlateAll);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form_SmtStackPlateStartIndex";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_SmtStackPlateStartIndex_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_SmtStackPlateStartIndex()
		{
			InitializeComponent();
		}

		public Form_SmtStackPlateStartIndex(int language, StackElement[] stack)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mLanguage = language;
			initLanguageTable();
			updateLanguage(mLanguage);
			mPlate = stack;
			mCurStackPlateNo = 0;
			label_StackPlate.Text = (mCurStackPlateNo + 1).ToString();
			for (int i = 0; i < HW.mStackNum[MainForm0.mFn][1]; i++)
			{
				listBox_StackPlateAll.Items.Add((StackPlateNo(i) + 1).ToString());
			}
			label_StackPlate.Text = "P" + (mCurStackPlateNo + 1);
			label_info.Text = mPlate[mCurStackPlateNo].mChipFootprint + " " + mPlate[mCurStackPlateNo].mChipValue;
			listBox_StackPlateAll.SelectedIndex = mCurStackPlateNo;
			update_StartIndexButton(mPlate[mCurStackPlateNo].mPlt.mStartIndex);
			listBox_StackPlateAll.MouseClick += listBox_StackPlateAll_MouseClick;
			listBox_StackPlateAll.DrawItem += listBox_StackPlateAll_DrawItem;
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
				str = new string[3] { "料盘起始索引设置", "料盘起始索引设置", "PLATE START INDEX SETTING" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_startindex,
				str = new string[3] { " ● 起始索引", " ● 起始索引", " ● START INDEX" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OK,
				str = new string[3] { "选择起始料号", "选择起始料号", "SELECT START INDEX" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Cancel,
				str = new string[3] { "完成", "完成", "SAVE" }
			});
		}

		private void listBox_StackPlateAll_MouseClick(object sender, MouseEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			int selectedIndex = listBox.SelectedIndex;
			int num = (mCurStackPlateNo = StackPlateNo(selectedIndex));
			label_StackPlate.Text = "P" + (mCurStackPlateNo + 1);
			label_info.Text = mPlate[mCurStackPlateNo].mChipFootprint + " " + mPlate[mCurStackPlateNo].mChipValue;
			update_StartIndexButton(mPlate[mCurStackPlateNo].mPlt.mStartIndex);
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
				if (mPlate[num].mSelected)
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

		public int StackPlateNo(int index)
		{
			int num = index % 3;
			int num2 = index / 3;
			return num * (HW.mStackNum[MainForm0.mFn][1] / 3) + num2;
		}

		public int StackPlateListBoxIndex(int stackNo)
		{
			return stackNo % (HW.mStackNum[MainForm0.mFn][1] / 3) * 3 + stackNo / (HW.mStackNum[MainForm0.mFn][1] / 3);
		}

		private int startIndex_plate(int subindex, int r, int c)
		{
			int num = 0;
			if (mPlate[mCurStackPlateNo].mPlt.mXYlist != null && mPlate[mCurStackPlateNo].mPlt.mXYlist.Count > 0)
			{
				if (subindex == 0)
				{
					num = r * mPlate[mCurStackPlateNo].mPlt.mColumnNum + c;
				}
				else if (subindex > 0 && mPlate[mCurStackPlateNo].mPlt.mSubList != null && subindex <= mPlate[mCurStackPlateNo].mPlt.mSubList.Count)
				{
					num = mPlate[mCurStackPlateNo].mPlt.mRowNum * mPlate[mCurStackPlateNo].mPlt.mColumnNum;
					for (int i = 0; i < subindex - 1; i++)
					{
						num += mPlate[mCurStackPlateNo].mPlt.mSubList[i].mTotalNum;
					}
					num += r * mPlate[mCurStackPlateNo].mPlt.mSubList[subindex - 1].mColumnNum + c;
				}
			}
			if (num >= mPlate[mCurStackPlateNo].mPlt.mXYlist.Count)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Plate start pick XY is out of range!" : "料盘起始取料索引超出有效范围！");
				num = 0;
			}
			return num;
		}

		private void startIndex_plate(int startindex, ref int sub, ref int r, ref int c)
		{
			sub = 0;
			r = 0;
			c = 0;
			if (mPlate[mCurStackPlateNo].mPlt.mXYlist == null || mPlate[mCurStackPlateNo].mPlt.mXYlist.Count <= 0)
			{
				return;
			}
			if (startindex >= mPlate[mCurStackPlateNo].mPlt.mXYlist.Count)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Plate start pick-XY is out of range--!" : "料盘起始取料索引超出有效范围--！");
			}
			else if (startindex < mPlate[mCurStackPlateNo].mPlt.mRowNum * mPlate[mCurStackPlateNo].mPlt.mColumnNum)
			{
				sub = 0;
				r = startindex / mPlate[mCurStackPlateNo].mPlt.mColumnNum;
				c = startindex % mPlate[mCurStackPlateNo].mPlt.mColumnNum;
			}
			else
			{
				if (mPlate[mCurStackPlateNo].mPlt.mSubList == null || mPlate[mCurStackPlateNo].mPlt.mSubList.Count <= 0)
				{
					return;
				}
				int num = startindex - mPlate[mCurStackPlateNo].mPlt.mTotalNum;
				sub = 1;
				for (int i = 0; i < mPlate[mCurStackPlateNo].mPlt.mSubList.Count; i++)
				{
					if (num < mPlate[mCurStackPlateNo].mPlt.mSubList[i].mTotalNum)
					{
						r = num / mPlate[mCurStackPlateNo].mPlt.mSubList[i].mColumnNum;
						c = num % mPlate[mCurStackPlateNo].mPlt.mSubList[i].mColumnNum;
						break;
					}
					sub++;
					num -= mPlate[mCurStackPlateNo].mPlt.mSubList[i].mTotalNum;
				}
			}
		}

		private void update_StartIndexButton(int startindex)
		{
			mPlate[mCurStackPlateNo].mPlt.mStartIndex = startindex;
			if (mPlate[mCurStackPlateNo].mPlt.mXYlist == null)
			{
				mPlate[mCurStackPlateNo].mPlt.mXYlist = new BindingList<StackPlateXYElement>();
			}
			if (mPlate[mCurStackPlateNo].mPlt.mStartIndex < mPlate[mCurStackPlateNo].mPlt.mXYlist.Count)
			{
				int sub = 0;
				int r = 0;
				int c = 0;
				startIndex_plate(mPlate[mCurStackPlateNo].mPlt.mStartIndex, ref sub, ref r, ref c);
				label_startindex.Text = " ● " + STR.START_IDX[mLanguage] + (sub + 1) + ": " + (r + 1) + "-" + (c + 1);
			}
			else
			{
				label_startindex.Text = " ● " + STR.START_IDX[mLanguage] + "-" + STR.EMPTY_PLATE[mLanguage];
			}
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			try
			{
				int[] array = new int[1] { mPlate[mCurStackPlateNo].mPlt.mStartIndex };
				Form_StackPlateIndexsToo form_StackPlateIndexsToo = new Form_StackPlateIndexsToo(mLanguage, mPlate[mCurStackPlateNo].mPlt, array, mCurStackPlateNo);
				if (form_StackPlateIndexsToo.ShowDialog() == DialogResult.OK)
				{
					mPlate[mCurStackPlateNo].mPlt.mStartIndex = array[0];
					update_StartIndexButton(mPlate[mCurStackPlateNo].mPlt.mStartIndex);
				}
			}
			catch (Exception)
			{
				MessageBox.Show((mLanguage == 2) ? "Plate Array set invalid!" : "料盘行列设置不合法，请正确设置！");
			}
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Form_SmtStackPlateStartIndex_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_OK);
			MainForm0.CreateAddButtonPic(button_Cancel);
		}
	}
}
