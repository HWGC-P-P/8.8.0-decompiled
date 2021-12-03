using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON;

namespace QIGN_MAIN
{
	public class Form_StackPlateIndexsToo : Form
	{
		private int[] mpIndex = new int[1];

		private int mRows = 1;

		private int mColumns = 1;

		private int mCurRow;

		private int mCurColumn;

		private sPlate mPlt;

		private ListBox[] mListbox;

		private ListBox[] mListbox_highlevel;

		private int mLanguage;

		private IContainer components;

		private ListBox listBox_stackplateshow;

		private Panel panel_show;

		private Label label_row_column;

		private Button button_Cancel;

		private Button button_OK;

		private Label label_curStackNo;

		private Label label_title;

		private Button button_disable;

		private Button button_enable;

		public Form_StackPlateIndexsToo()
		{
			InitializeComponent();
		}

		public Form_StackPlateIndexsToo(int language, sPlate plt, int[] pindex, int stack)
		{
			InitializeComponent();
			mLanguage = language;
			base.Icon = MainForm0.GetIcon(1);
			if (mLanguage != 0)
			{
				MainForm0.common_updateLanguage(mLanguage, initLanguageTable());
			}
			mPlt = plt;
			mpIndex = pindex;
			label_curStackNo.Text = "P" + (stack + 1);
			if (mPlt.mSubList == null)
			{
				mPlt.mSubList = new BindingList<sSubPlate>();
			}
			int num = mPlt.mSubList.Count + 1;
			mListbox = new ListBox[num];
			panel_show.AutoScroll = true;
			int num2 = 40;
			int num3 = 56;
			int num4 = 50;
			for (int i = 0; i < num; i++)
			{
				Label label = new Label();
				panel_show.Controls.Add(label);
				label.Location = new Point(num2 - 35, num3 - 45);
				label.Text = ((mLanguage == 2) ? "SUB " : "● 子料盘") + (i + 1);
				label.Font = new Font(DEF.FONT_2020[mLanguage], 12f, FontStyle.Regular);
				Label label2 = new Label();
				panel_show.Controls.Add(label2);
				label2.Location = new Point(num2 - 35 + 110, num3 - 45 + 2);
				label2.Text = ((mLanguage == 2) ? "Angle after pick" : "进料角度");
				label2.AutoSize = false;
				label2.Size = new Size(200, 30);
				label2.Font = new Font(DEF.FONT_2020[mLanguage], 11f, FontStyle.Regular);
				NumericUpDown numericUpDown = new NumericUpDown();
				panel_show.Controls.Add(numericUpDown);
				numericUpDown.DecimalPlaces = 2;
				numericUpDown.Minimum = -180m;
				numericUpDown.Maximum = 180m;
				numericUpDown.Value = (decimal)((i == 0) ? mPlt.mAngle : mPlt.mSubList[i - 1].mAngle);
				numericUpDown.Location = new Point(num2 - 35 + 100 + 110, num3 - 45 - 3);
				numericUpDown.Size = new Size(60, 30);
				numericUpDown.Font = new Font(DEF.FONT_2020[mLanguage], 11f, FontStyle.Regular);
				numericUpDown.ValueChanged += nup_angle_ValueChanged;
				numericUpDown.BringToFront();
				numericUpDown.Tag = i;
				mListbox[i] = new ListBox();
				mListbox[i].Tag = i;
				panel_show.Controls.Add(mListbox[i]);
				mListbox[i].Location = new Point(num2, num3);
				mListbox[i].MultiColumn = true;
				mListbox[i].ColumnWidth = 28;
				mListbox[i].Font = listBox_stackplateshow.Font;
				mListbox[i].BorderStyle = BorderStyle.FixedSingle;
				mListbox[i].Anchor = listBox_stackplateshow.Anchor;
				mListbox[i].MouseClick += listBox_MouseClick;
				int num5 = ((i == 0) ? mPlt.mRowNum : mPlt.mSubList[i - 1].mRowNum);
				int num6 = ((i == 0) ? mPlt.mColumnNum : mPlt.mSubList[i - 1].mColumnNum);
				int num7 = ((num5 < 15) ? (num5 * 30) : (num5 * 29 - num5 / 30 * 24));
				mListbox[i].Size = new Size(num6 * 28 + 2, num7);
				int num8 = ((i == 0) ? mPlt.mTotalNum : mPlt.mSubList[i - 1].mTotalNum);
				if (num8 > 0)
				{
					for (int j = 0; j < num5; j++)
					{
						for (int k = 0; k < num6; k++)
						{
							mListbox[i].Items.Add("▣");
						}
					}
					for (int l = 0; l < num6; l++)
					{
						Label label3 = new Label();
						panel_show.Controls.Add(label3);
						label3.Text = (l + 1).ToString();
						label3.Font = new Font(DEF.FONT_2020_TITLE[mLanguage], 10f, FontStyle.Regular);
						label3.Location = new Point(num2 - 3 + 28 * l, num3 - 24 + 8);
						label3.Size = new Size(28, 20);
					}
					for (int m = 0; m < num5; m++)
					{
						Label label4 = new Label();
						panel_show.Controls.Add(label4);
						label4.Text = (m + 1).ToString();
						label4.Font = new Font(DEF.FONT_2020_TITLE[mLanguage], 10f, FontStyle.Regular);
						label4.Location = new Point(num2 - 35, num3 + 6 + 28 * m);
						label4.Size = new Size(28, 20);
					}
				}
				num3 += num4 + num7;
			}
			update_show(mpIndex[0]);
		}

		private void nup_angle_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			int num = (int)numericUpDown.Tag;
			if (num == 0)
			{
				mPlt.mAngle = (float)numericUpDown.Value;
			}
			else if (num > 0)
			{
				int num2 = num - 1;
				if (num2 < mPlt.mSubList.Count)
				{
					mPlt.mSubList[num2].mAngle = (float)numericUpDown.Value;
				}
			}
		}

		private void update_show(int startindex)
		{
			if (startindex < 0 || startindex >= mPlt.mXYlist.Count)
			{
				if (mPlt.mSubList == null)
				{
					mPlt.mSubList = new BindingList<sSubPlate>();
				}
				int num = mPlt.mSubList.Count + 1;
				for (int i = 0; i < num; i++)
				{
					int num2 = ((i == 0) ? mPlt.mTotalNum : mPlt.mSubList[i - 1].mTotalNum);
					if (num2 > 0)
					{
						mListbox[i].ClearSelected();
						for (int j = 0; j < num2; j++)
						{
							mListbox[i].Items[j] = "□";
						}
					}
				}
				label_row_column.Text = ((mLanguage == 2) ? "Empty Plates" : "空料盘");
				return;
			}
			int sub = 0;
			int r = 0;
			int c = 0;
			startIndex_plate(startindex, ref sub, ref r, ref c);
			if (mPlt.mSubList == null)
			{
				mPlt.mSubList = new BindingList<sSubPlate>();
			}
			int num3 = mPlt.mSubList.Count + 1;
			for (int k = 0; k < num3; k++)
			{
				if (k == sub)
				{
					int num4 = ((k == 0) ? mPlt.mRowNum : mPlt.mSubList[k - 1].mRowNum);
					int num5 = ((k == 0) ? mPlt.mColumnNum : mPlt.mSubList[k - 1].mColumnNum);
					int num6 = ((k == 0) ? mPlt.mTotalNum : mPlt.mSubList[k - 1].mTotalNum);
					int num7 = r * num5 + c;
					for (int l = 0; l < num6; l++)
					{
						int num8 = l / num5;
						int num9 = l % num5;
						int index = num9 * num4 + num8;
						mListbox[k].Items[index] = ((l < num7) ? "□" : "▣");
						int num10 = startIndex_plate(sub, num8, num9);
						if (num10 < mPlt.mXYlist.Count && !mPlt.mXYlist[num10].mEnable)
						{
							mListbox[k].Items[index] = " ";
						}
					}
					mListbox[k].SelectedIndex = c * num4 + r;
					label_row_column.Text = sub + 1 + ": " + (r + 1) + "-" + (c + 1);
					continue;
				}
				int num11 = ((k == 0) ? mPlt.mTotalNum : mPlt.mSubList[k - 1].mTotalNum);
				if (num11 <= 0)
				{
					continue;
				}
				mListbox[k].ClearSelected();
				for (int m = 0; m < num11; m++)
				{
					mListbox[k].Items[m] = ((k < sub) ? "□" : "▣");
				}
				int num12 = ((k == 0) ? mPlt.mRowNum : mPlt.mSubList[k - 1].mRowNum);
				int num13 = ((k == 0) ? mPlt.mColumnNum : mPlt.mSubList[k - 1].mColumnNum);
				for (int n = 0; n < num11; n++)
				{
					int num14 = n / num13;
					int num15 = n % num13;
					int index2 = num15 * num12 + num14;
					int num16 = startIndex_plate(k, num14, num15);
					if (num16 < mPlt.mXYlist.Count && !mPlt.mXYlist[num16].mEnable)
					{
						mListbox[k].Items[index2] = " ";
					}
				}
			}
		}

		private void listBox_MouseClick(object sender, MouseEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			int num = (int)listBox.Tag;
			int selectedIndex = listBox.SelectedIndex;
			if (num <= 0 || mPlt.mSubList[num - 1].mTotalNum != 0)
			{
				int num2 = ((num == 0) ? mPlt.mRowNum : mPlt.mSubList[num - 1].mRowNum);
				mpIndex[0] = startIndex_plate(num, selectedIndex % num2, selectedIndex / num2);
				update_show(mpIndex[0]);
			}
		}

		private int startIndex_plate(int subindex, int r, int c)
		{
			int num = 0;
			if (mPlt.mXYlist != null && mPlt.mXYlist.Count > 0)
			{
				if (subindex == 0)
				{
					num = r * mPlt.mColumnNum + c;
				}
				else if (subindex > 0 && mPlt.mSubList != null && subindex <= mPlt.mSubList.Count)
				{
					num = mPlt.mRowNum * mPlt.mColumnNum;
					for (int i = 0; i < subindex - 1; i++)
					{
						num += mPlt.mSubList[i].mTotalNum;
					}
					num += r * mPlt.mSubList[subindex - 1].mColumnNum + c;
				}
			}
			if (num >= mPlt.mXYlist.Count)
			{
				MessageBox.Show((mLanguage == 2) ? "Plate start pick-XY is out of range!" : "料盘起始取料索引超出有效范围！");
				num = 0;
			}
			return num;
		}

		private void startIndex_plate(int startindex, ref int sub, ref int r, ref int c)
		{
			sub = 0;
			r = 0;
			c = 0;
			if (mPlt.mXYlist == null || mPlt.mXYlist.Count <= 0)
			{
				return;
			}
			if (startindex >= mPlt.mXYlist.Count)
			{
				MessageBox.Show((mLanguage == 2) ? "Plate start pick-XY is out of range--!" : "料盘起始取料索引超出有效范围--！");
			}
			else if (startindex < mPlt.mRowNum * mPlt.mColumnNum)
			{
				sub = 0;
				r = startindex / mPlt.mColumnNum;
				c = startindex % mPlt.mColumnNum;
			}
			else
			{
				if (mPlt.mSubList == null || mPlt.mSubList.Count <= 0)
				{
					return;
				}
				int num = startindex - mPlt.mTotalNum;
				sub = 1;
				for (int i = 0; i < mPlt.mSubList.Count; i++)
				{
					if (num < mPlt.mSubList[i].mTotalNum)
					{
						r = num / mPlt.mSubList[i].mColumnNum;
						c = num % mPlt.mSubList[i].mColumnNum;
						break;
					}
					sub++;
					num -= mPlt.mSubList[i].mTotalNum;
				}
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_title,
				str = new string[3] { "料盘起始索引设置", "料盘起始索引设置", "Plate Start Index" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OK,
				str = new string[3] { "确定", "确定", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Cancel,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_disable,
				str = new string[3] { "禁用选中料位", "禁用選中料位", "Disable Selected Position" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_enable,
				str = new string[3] { "启用选中料位", "啟用選中料位", "Enable Selected Position" }
			});
			return list;
		}

		private void listBox_stackplateshow_MouseClick(object sender, MouseEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			int selectedIndex = listBox.SelectedIndex;
			mCurRow = selectedIndex % mRows;
			mCurColumn = selectedIndex / mRows;
			label_row_column.Text = mCurRow + 1 + "-" + (mCurColumn + 1);
			mpIndex[0] = mCurRow * mColumns + mCurColumn;
			int num = mColumns * mRows;
			for (int i = 0; i < num; i++)
			{
				int num2 = i / mColumns;
				int num3 = i % mColumns;
				int index = num3 * mRows + num2;
				listBox_stackplateshow.Items[index] = ((i < mpIndex[0]) ? "□" : "▣");
			}
		}

		private int get_listbox_Index(int row, int column)
		{
			return column * mRows + row;
		}

		private void listBox_stackplateshow_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				int num = e.Index % mRows;
				int num2 = e.Index / mRows;
				int num3 = num * mColumns + num2;
				e.DrawBackground();
				for (int i = 0; i < num3; i++)
				{
					int num4 = i / mColumns;
					int num5 = i % mColumns;
					int index = num5 * mRows + num4;
					Brush gray = Brushes.Gray;
					e.DrawFocusRectangle();
					e.Graphics.DrawString(listBox_stackplateshow.Items[index].ToString(), new Font(e.Font, FontStyle.Bold), gray, e.Bounds, StringFormat.GenericTypographic);
				}
			}
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_disable_Click(object sender, EventArgs e)
		{
			if (mpIndex[0] < mPlt.mXYlist.Count)
			{
				mPlt.mXYlist[mpIndex[0]].mEnable = false;
				update_show(mpIndex[0]);
			}
		}

		private void button_enable_Click(object sender, EventArgs e)
		{
			if (mpIndex[0] < mPlt.mXYlist.Count)
			{
				mPlt.mXYlist[mpIndex[0]].mEnable = true;
				update_show(mpIndex[0]);
			}
		}

		private void Form_StackPlateIndexsToo_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_OK);
			MainForm0.CreateAddButtonPic(button_Cancel);
			MainForm0.CreateAddButtonPic(button_disable);
			MainForm0.CreateAddButtonPic(button_enable);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.Form_StackPlateIndexsToo));
			listBox_stackplateshow = new System.Windows.Forms.ListBox();
			panel_show = new System.Windows.Forms.Panel();
			label_row_column = new System.Windows.Forms.Label();
			button_Cancel = new System.Windows.Forms.Button();
			button_OK = new System.Windows.Forms.Button();
			label_curStackNo = new System.Windows.Forms.Label();
			label_title = new System.Windows.Forms.Label();
			button_disable = new System.Windows.Forms.Button();
			button_enable = new System.Windows.Forms.Button();
			panel_show.SuspendLayout();
			SuspendLayout();
			listBox_stackplateshow.BackColor = System.Drawing.Color.FromArgb(255, 202, 158);
			listBox_stackplateshow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			listBox_stackplateshow.ColumnWidth = 25;
			listBox_stackplateshow.Font = new System.Drawing.Font("微软雅黑", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			listBox_stackplateshow.FormattingEnabled = true;
			listBox_stackplateshow.ItemHeight = 28;
			listBox_stackplateshow.Location = new System.Drawing.Point(25, 34);
			listBox_stackplateshow.MultiColumn = true;
			listBox_stackplateshow.Name = "listBox_stackplateshow";
			listBox_stackplateshow.Size = new System.Drawing.Size(681, 58);
			listBox_stackplateshow.TabIndex = 1;
			listBox_stackplateshow.Visible = false;
			listBox_stackplateshow.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox_stackplateshow_MouseClick);
			panel_show.AutoScroll = true;
			panel_show.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			panel_show.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_show.Controls.Add(listBox_stackplateshow);
			panel_show.Location = new System.Drawing.Point(12, 50);
			panel_show.Name = "panel_show";
			panel_show.Size = new System.Drawing.Size(885, 500);
			panel_show.TabIndex = 2;
			label_row_column.AutoSize = true;
			label_row_column.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_row_column.Location = new System.Drawing.Point(293, 16);
			label_row_column.Name = "label_row_column";
			label_row_column.Size = new System.Drawing.Size(39, 19);
			label_row_column.TabIndex = 3;
			label_row_column.Text = "1-1";
			button_Cancel.BackColor = System.Drawing.Color.PeachPuff;
			button_Cancel.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Cancel.Location = new System.Drawing.Point(495, 561);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(121, 38);
			button_Cancel.TabIndex = 4;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = false;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			button_OK.BackColor = System.Drawing.Color.FromArgb(255, 202, 158);
			button_OK.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OK.Location = new System.Drawing.Point(271, 561);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(121, 38);
			button_OK.TabIndex = 4;
			button_OK.Text = "确认";
			button_OK.UseVisualStyleBackColor = false;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			label_curStackNo.BackColor = System.Drawing.Color.FromArgb(255, 202, 158);
			label_curStackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_curStackNo.Font = new System.Drawing.Font("黑体", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_curStackNo.Location = new System.Drawing.Point(12, 3);
			label_curStackNo.Name = "label_curStackNo";
			label_curStackNo.Size = new System.Drawing.Size(89, 44);
			label_curStackNo.TabIndex = 11;
			label_curStackNo.Text = "P12";
			label_curStackNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_title.AutoSize = true;
			label_title.Font = new System.Drawing.Font("黑体", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_title.Location = new System.Drawing.Point(118, 15);
			label_title.Name = "label_title";
			label_title.Size = new System.Drawing.Size(169, 20);
			label_title.TabIndex = 12;
			label_title.Text = "料盘起始索引设置";
			button_disable.Font = new System.Drawing.Font("黑体", 11f);
			button_disable.Location = new System.Drawing.Point(628, 11);
			button_disable.Name = "button_disable";
			button_disable.Size = new System.Drawing.Size(131, 30);
			button_disable.TabIndex = 13;
			button_disable.Text = "禁用选中料位";
			button_disable.UseVisualStyleBackColor = true;
			button_disable.Click += new System.EventHandler(button_disable_Click);
			button_enable.Font = new System.Drawing.Font("黑体", 11f);
			button_enable.Location = new System.Drawing.Point(765, 11);
			button_enable.Name = "button_enable";
			button_enable.Size = new System.Drawing.Size(131, 30);
			button_enable.TabIndex = 13;
			button_enable.Text = "启用选中料位";
			button_enable.UseVisualStyleBackColor = true;
			button_enable.Click += new System.EventHandler(button_enable_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			BackColor = System.Drawing.Color.PapayaWhip;
			base.ClientSize = new System.Drawing.Size(909, 608);
			base.Controls.Add(button_enable);
			base.Controls.Add(button_disable);
			base.Controls.Add(label_title);
			base.Controls.Add(label_curStackNo);
			base.Controls.Add(button_OK);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(label_row_column);
			base.Controls.Add(panel_show);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form_StackPlateIndexsToo";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_StackPlateIndexsToo_Load);
			panel_show.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
