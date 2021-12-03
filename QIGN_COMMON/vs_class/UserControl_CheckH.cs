using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_CheckH : UserControl
	{
		public int[] mHeight;

		private Label[] label_stack_pikH;

		public USR_STACKLIB mStackLib;

		public int mFlag;

		public int mFn;

		public USR_DATA USR;

		private IContainer components;

		private Label label1;

		private Panel panel1;

		private Button button_close;

		private Button button_Z_down;

		private Button button_Z_up;

		public event void_Func_int_int_float set_offset_numeric;

		public event void_Func_void stacksel_new_flushZn;

		public UserControl_CheckH(int fn, USR_DATA usr, USR_STACKLIB stlb, int flag)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			mStackLib = stlb;
			mFlag = flag;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "查看取料高度", "查看取料高度", "Check Pick Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Z_up,
				str = new string[3] { "Z轴↑", "Z軸↑", "Z↑" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Z_down,
				str = new string[3] { "Z轴↓", "Z軸↓", "Z↓" }
			});
			return list;
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		public void flush_height()
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			mHeight = new int[8];
			if (mFlag == 0)
			{
				bool flag = MainForm0.format_feeder_front_or_back(mFn, num) == 0;
				for (int i = 0; i < HW.mZnNum[mFn]; i++)
				{
					float num2 = MainForm0.format_H_to_Hmm(Math.Abs(flag ? USR.mBaseHeight_feeder[i] : USR.mBaseHeight_feederBk[i]));
					if (mStackLib.sel == ProviderType.Vibra || mStackLib.sel == ProviderType.Plate)
					{
						if (array[num].mZnData[i].baseH < -HW.mMaxZ[mFn])
						{
							array[num].mZnData[i].baseH = 0;
						}
						num2 = MainForm0.format_H_to_Hmm(Math.Abs(array[num].mZnData[i].baseH));
					}
					float hmm = num2 + array[num].mZnData[i].Pik.Offset;
					int num3 = MainForm0.format_Hmm_to_H(hmm) * ((i % 2 != 0) ? 1 : (-1));
					if (HW.mSmtGenerationNo == 2)
					{
						num3 = Math.Abs(num3);
					}
					mHeight[i] = num3;
					label_stack_pikH[i].Text = Math.Abs(num3).ToString();
				}
			}
			else
			{
				if (mFlag != 1)
				{
					return;
				}
				for (int j = 0; j < HW.mZnNum[mFn]; j++)
				{
					float hmm2 = Math.Abs(USR.mBaseHeightmm[j]) + array[num].mZnData[j].Mnt.Offset - array[num].height;
					int num4 = MainForm0.format_Hmm_to_H(hmm2) * ((j % 2 != 0) ? 1 : (-1));
					if (HW.mSmtGenerationNo == 2)
					{
						num4 = Math.Abs(num4);
					}
					mHeight[j] = num4;
					label_stack_pikH[j].Text = Math.Abs(num4).ToString();
				}
			}
		}

		private void UserControl_CheckH_Load(object sender, EventArgs e)
		{
			string[] array = new string[3] { "查看取料高度（飞达/托盘基准高度 + 下压偏移）", "查看取料高度（飛達/托盤基準高度 + 下壓偏移）", "Check Pick-H (Feeder/Plate Base-H + Offset)" };
			string[] array2 = new string[3] { "查看贴装高度（PCB基准高度 - 元件厚度 + 下压偏移）", "查看貼裝高度（PCB基準高度 - 元件厚度 + 下壓偏移）", "Check Mount-H (PCB Base-H - ChipH + Offset)" };
			label1.Text = ((mFlag == 0) ? array[MainForm0.USR_INIT.mLanguage] : array2[MainForm0.USR_INIT.mLanguage]);
			label_stack_pikH = new Label[8];
			for (int i = 0; i < 8; i++)
			{
				label_stack_pikH[i] = new Label();
			}
			TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
			tableLayoutPanel.BackColor = Color.WhiteSmoke;
			tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel, true, null);
			tableLayoutPanel.Controls.Clear();
			tableLayoutPanel.RowCount = 1;
			tableLayoutPanel.ColumnCount = 8;
			tableLayoutPanel.Location = new Point(74, 24);
			tableLayoutPanel.Size = new Size(478, 25);
			for (int j = 0; j < tableLayoutPanel.RowCount; j++)
			{
				tableLayoutPanel.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.AutoSize
				});
			}
			for (int k = 0; k < tableLayoutPanel.ColumnCount; k++)
			{
				if (k == 0)
				{
					tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
				else
				{
					tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
			}
			tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel.Refresh();
			for (int l = 0; l < tableLayoutPanel.ColumnStyles.Count; l++)
			{
				label_stack_pikH[l].Text = "456";
				label_stack_pikH[l].Size = new Size(52, 20);
				label_stack_pikH[l].AutoSize = false;
				label_stack_pikH[l].Font = new Font("黑体", 10.5f, (l == MainForm0.mZn[mFn]) ? FontStyle.Bold : FontStyle.Regular);
				label_stack_pikH[l].Anchor = AnchorStyles.None;
				label_stack_pikH[l].TextAlign = ContentAlignment.MiddleLeft;
				label_stack_pikH[l].Tag = l;
				label_stack_pikH[l].BackColor = Color.White;
				label_stack_pikH[l].BorderStyle = BorderStyle.None;
				label_stack_pikH[l].MouseClick += stack_label_MouseClick;
				tableLayoutPanel.Controls.Add(label_stack_pikH[l], l, 0);
			}
			tableLayoutPanel.SuspendLayout();
			panel1.Controls.Add(tableLayoutPanel);
			Button button = new Button();
			panel1.Controls.Add(button);
			button.Location = new Point(tableLayoutPanel.Location.X + 140, tableLayoutPanel.Location.Y + tableLayoutPanel.Size.Height + 3);
			button.Size = new Size(80, 25);
			button.Text = (new string[3] { "保存", "保存", "Save" })[MainForm0.USR_INIT.mLanguage];
			button.UseVisualStyleBackColor = true;
			button.Click += bt_save_Click;
			MainForm0.CreateAddButtonPic(button);
			Button button2 = new Button();
			panel1.Controls.Add(button2);
			button2.Location = new Point(tableLayoutPanel.Location.X + 140 + 80 + 30, tableLayoutPanel.Location.Y + tableLayoutPanel.Size.Height + 3);
			button2.Size = new Size(80, 25);
			button2.Text = (new string[3] { "定位", "定位", "Goto" })[MainForm0.USR_INIT.mLanguage];
			button2.UseVisualStyleBackColor = true;
			button2.Click += bt_Click;
			MainForm0.CreateAddButtonPic(button2);
			flush_height();
			init_button();
		}

		private void init_button()
		{
			MainForm0.CreateAddButtonPic(button_Z_up);
			MainForm0.CreateAddButtonPic(button_Z_down);
		}

		private void bt_Click(object sender, EventArgs e)
		{
			_ = mStackLib.stacktab[(int)mStackLib.sel];
			_ = mStackLib.index[(int)mStackLib.sel];
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(mHeight[MainForm0.mZn[mFn]]);
			}
		}

		private void bt_save_Click(object sender, EventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = MainForm0.mZn[mFn];
			if (mFlag == 0)
			{
				string[] array2 = new string[3]
				{
					"确定保存" + (num2 + 1) + "号吸嘴[取料高度]?",
					"確定保存" + (num2 + 1) + "號吸嘴[取料高度]?",
					"Are you going to save Pick-H of Nozzle " + (num2 + 1) + " ?"
				};
				if (MainForm0.CmMessageBox(array2[MainForm0.USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					float num3 = MainForm0.format_H_to_Hmm(MainForm0.mCur[mFn].z[num2]);
					float num4 = MainForm0.format_H_to_Hmm(mHeight[num2]);
					mHeight[num2] = MainForm0.mCur[mFn].z[num2];
					label_stack_pikH[MainForm0.mZn[mFn]].Text = Math.Abs(mHeight[num2]).ToString();
					array[num].mZnData[num2].Pik.Offset += num3 - num4;
					if (this.set_offset_numeric != null)
					{
						this.set_offset_numeric(mFlag, num2, array[num].mZnData[num2].Pik.Offset);
					}
				}
			}
			else
			{
				if (mFlag != 1)
				{
					return;
				}
				string[] array3 = new string[3]
				{
					"确定保存" + (num2 + 1) + "号吸嘴[贴装高度]?",
					"確定保存" + (num2 + 1) + "號吸嘴[貼裝高度]?",
					"Are you going to save Mount-H of Nozzle " + (num2 + 1) + " ?"
				};
				if (MainForm0.CmMessageBox(array3[MainForm0.USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					float num5 = MainForm0.format_H_to_Hmm(MainForm0.mCur[mFn].z[num2]);
					float num6 = MainForm0.format_H_to_Hmm(mHeight[num2]);
					mHeight[num2] = MainForm0.mCur[mFn].z[num2];
					label_stack_pikH[MainForm0.mZn[mFn]].Text = Math.Abs(mHeight[num2]).ToString();
					array[num].mZnData[num2].Mnt.Offset += num5 - num6;
					if (this.set_offset_numeric != null)
					{
						this.set_offset_numeric(mFlag, num2, array[num].mZnData[num2].Pik.Offset);
					}
				}
			}
		}

		private void stack_label_MouseClick(object sender, MouseEventArgs e)
		{
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			int num2 = (int)((Label)sender).Tag;
			if (num2 == -1)
			{
				return;
			}
			num2 %= 8;
			if (num2 >= 0 && num2 < HW.mZnNum[mFn] && array[num].mZnData[num2].mEnabled)
			{
				MainForm0.radiobt_zn[mFn][num2].Checked = true;
				if (this.stacksel_new_flushZn != null)
				{
					this.stacksel_new_flushZn();
				}
			}
		}

		public void set_bold(int zn, bool is_bold)
		{
			label_stack_pikH[zn].Font = new Font("黑体", 10.5f, is_bold ? FontStyle.Bold : FontStyle.Regular);
		}

		public void set_enable(int zn, bool is_enable)
		{
			label_stack_pikH[zn].Enabled = is_enable;
		}

		private void button_Z_up_Click(object sender, EventArgs e)
		{
			string text = ((Button)sender).Tag.ToString();
			StackElement[] array = mStackLib.stacktab[(int)mStackLib.sel];
			int num = mStackLib.index[(int)mStackLib.sel];
			if (mFlag == 0)
			{
				int num2 = MainForm0.mZn[mFn];
				if (mHeight[num2] != MainForm0.mCur[mFn].z[num2])
				{
					string[] array2 = new string[3] { "请先[定位]到选中[高度]再进行Z轴上下位移!", "請先[定位]到選中[高度]再進行Z軸上下位移!", "Please goto selected height firstly, and then move Z!" };
					MainForm0.CmMessageBoxTop_Ok(array2[MainForm0.USR_INIT.mLanguage]);
					return;
				}
				array[num].mZnData[MainForm0.mZn[mFn]].Pik.Offset += ((text == "up") ? (-0.1f) : 0.1f);
				if (this.set_offset_numeric != null)
				{
					this.set_offset_numeric(mFlag, MainForm0.mZn[mFn], array[num].mZnData[MainForm0.mZn[mFn]].Pik.Offset);
				}
				float num3 = MainForm0.format_H_to_Hmm(Math.Abs((MainForm0.format_feeder_front_or_back(mFn, num) == 0) ? USR.mBaseHeight_feeder[MainForm0.mZn[mFn]] : USR.mBaseHeight_feederBk[MainForm0.mZn[mFn]]));
				if (mStackLib.sel == ProviderType.Vibra || mStackLib.sel == ProviderType.Plate)
				{
					num3 = MainForm0.format_H_to_Hmm(Math.Abs(array[num].mZnData[MainForm0.mZn[mFn]].baseH));
				}
				float hmm = num3 + array[num].mZnData[MainForm0.mZn[mFn]].Pik.Offset;
				int num4 = MainForm0.format_Hmm_to_H(hmm) * ((MainForm0.mZn[mFn] % 2 != 0) ? 1 : (-1));
				if (HW.mSmtGenerationNo == 2)
				{
					num4 = Math.Abs(num4);
				}
				mHeight[MainForm0.mZn[mFn]] = num4;
				label_stack_pikH[MainForm0.mZn[mFn]].Text = Math.Abs(num4).ToString();
			}
			else if (mFlag == 1)
			{
				int num5 = MainForm0.mZn[mFn];
				if (mHeight[num5] != MainForm0.mCur[mFn].z[num5])
				{
					string[] array3 = new string[3] { "请先[定位]到选中[高度]再进行Z轴上下位移!", "請先[定位]到選中[高度]再進行Z軸上下位移!", "Please goto selected height firstly, and then move Z!" };
					MainForm0.CmMessageBoxTop_Ok(array3[MainForm0.USR_INIT.mLanguage]);
					return;
				}
				array[num].mZnData[MainForm0.mZn[mFn]].Mnt.Offset += ((text == "up") ? (-0.1f) : 0.1f);
				if (this.set_offset_numeric != null)
				{
					this.set_offset_numeric(mFlag, MainForm0.mZn[mFn], array[num].mZnData[MainForm0.mZn[mFn]].Mnt.Offset);
				}
				float hmm2 = Math.Abs(USR.mBaseHeightmm[MainForm0.mZn[mFn]]) + array[num].mZnData[MainForm0.mZn[mFn]].Mnt.Offset - array[num].height;
				int num6 = MainForm0.format_Hmm_to_H(hmm2) * ((MainForm0.mZn[mFn] % 2 != 0) ? 1 : (-1));
				if (HW.mSmtGenerationNo == 2)
				{
					num6 = Math.Abs(num6);
				}
				mHeight[MainForm0.mZn[mFn]] = num6;
				label_stack_pikH[MainForm0.mZn[mFn]].Text = Math.Abs(num6).ToString();
			}
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(mHeight[MainForm0.mZn[mFn]]);
			}
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
			panel1 = new System.Windows.Forms.Panel();
			button_Z_down = new System.Windows.Forms.Button();
			button_Z_up = new System.Windows.Forms.Button();
			button_close = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 12.5f);
			label1.Location = new System.Drawing.Point(99, 3);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(116, 17);
			label1.TabIndex = 0;
			label1.Text = "查看取料高度";
			panel1.BackColor = System.Drawing.Color.LightBlue;
			panel1.Controls.Add(button_Z_down);
			panel1.Controls.Add(button_Z_up);
			panel1.Controls.Add(button_close);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(5, 5);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(662, 80);
			panel1.TabIndex = 0;
			button_Z_down.Location = new System.Drawing.Point(557, 46);
			button_Z_down.Name = "button_Z_down";
			button_Z_down.Size = new System.Drawing.Size(50, 30);
			button_Z_down.TabIndex = 2;
			button_Z_down.Tag = "down";
			button_Z_down.Text = "Z轴↓";
			button_Z_down.UseVisualStyleBackColor = true;
			button_Z_down.Click += new System.EventHandler(button_Z_up_Click);
			button_Z_up.Location = new System.Drawing.Point(557, 14);
			button_Z_up.Name = "button_Z_up";
			button_Z_up.Size = new System.Drawing.Size(50, 30);
			button_Z_up.TabIndex = 2;
			button_Z_up.Tag = "up";
			button_Z_up.Text = "Z轴↑";
			button_Z_up.UseVisualStyleBackColor = true;
			button_Z_up.Click += new System.EventHandler(button_Z_up_Click);
			button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_close.Location = new System.Drawing.Point(623, 3);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(32, 32);
			button_close.TabIndex = 1;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = true;
			button_close.Click += new System.EventHandler(button_close_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Black;
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_CheckH";
			base.Size = new System.Drawing.Size(672, 90);
			base.Load += new System.EventHandler(UserControl_CheckH_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
