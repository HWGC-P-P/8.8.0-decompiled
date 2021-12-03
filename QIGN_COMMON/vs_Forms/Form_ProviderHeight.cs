using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_ProviderHeight : Form
	{
		private IContainer components;

		private Panel panel1;

		private Button button_save;

		private Button button_sync;

		private Button button_goto;

		private Label label2;

		private Label label1;

		private USR_DATA USR;

		private USR2_DATA USR2;

		private USR_INIT_DATA USR_INIT;

		public Label[] label_baseH_Zn;

		public Label[] label_baseH_Zn_V;

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
			button_sync = new System.Windows.Forms.Button();
			button_goto = new System.Windows.Forms.Button();
			button_save = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			SuspendLayout();
			panel1.Controls.Add(button_sync);
			panel1.Controls.Add(button_goto);
			panel1.Controls.Add(button_save);
			panel1.Location = new System.Drawing.Point(76, 69);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(544, 117);
			panel1.TabIndex = 0;
			button_sync.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_sync.Location = new System.Drawing.Point(296, 77);
			button_sync.Name = "button_sync";
			button_sync.Size = new System.Drawing.Size(162, 32);
			button_sync.TabIndex = 0;
			button_sync.Text = "同步到其他吸嘴";
			button_sync.UseVisualStyleBackColor = true;
			button_sync.Click += new System.EventHandler(button_sync_Click);
			button_goto.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_goto.Location = new System.Drawing.Point(192, 77);
			button_goto.Name = "button_goto";
			button_goto.Size = new System.Drawing.Size(98, 32);
			button_goto.TabIndex = 0;
			button_goto.Text = "定位高度";
			button_goto.UseVisualStyleBackColor = true;
			button_goto.Click += new System.EventHandler(button_goto_Click);
			button_save.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_save.Location = new System.Drawing.Point(85, 77);
			button_save.Name = "button_save";
			button_save.Size = new System.Drawing.Size(98, 32);
			button_save.TabIndex = 0;
			button_save.Text = "保存高度";
			button_save.UseVisualStyleBackColor = true;
			button_save.Click += new System.EventHandler(button_save_Click);
			label2.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(72, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(544, 35);
			label2.TabIndex = 2;
			label2.Text = "料盘-1";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label1.BackColor = System.Drawing.Color.Yellow;
			label1.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(76, 35);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(544, 28);
			label1.TabIndex = 2;
			label1.Text = "特别注意：吸嘴刚刚接触到整个托盘的最高处！";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LightBlue;
			base.ClientSize = new System.Drawing.Size(703, 198);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_ProviderHeight";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Load += new System.EventHandler(Form_ProviderHeight_Load);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_save,
				str = new string[3] { "保存高度", "保存高度", "Save Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_goto,
				str = new string[3] { "定位高度", "定位高度", "Goto Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_sync,
				str = new string[3] { "同步到其他吸嘴", "同步到其他吸嘴", "Sync to Other Nozzles" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "特别注意：吸嘴刚刚接触到整个托盘的最高处！", "特别注意：吸嘴刚刚接触到整个托盘的最高处！", "Notice: The Z height that nozzle just touch the highest point of plate!" }
			});
			return list;
		}

		public Form_ProviderHeight(USR_DATA usr, USR2_DATA usr2)
		{
			InitializeComponent();
			USR = usr;
			USR2 = usr2;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			StackElement[] array = USR2.mStackLib.stacktab[(int)USR2.mStackLib.sel];
			int num = USR2.mStackLib.index[(int)USR2.mStackLib.sel];
			TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
			panel1.Controls.Add(tableLayoutPanel);
			tableLayoutPanel.Controls.Clear();
			tableLayoutPanel.RowCount = 2;
			tableLayoutPanel.ColumnCount = 8;
			tableLayoutPanel.Size = new Size(538, 50);
			tableLayoutPanel.BackColor = Color.WhiteSmoke;
			for (int i = 0; i < tableLayoutPanel.RowCount; i++)
			{
				tableLayoutPanel.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.Absolute,
					Height = 22f
				});
			}
			for (int j = 0; j < tableLayoutPanel.ColumnCount; j++)
			{
				tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
				{
					SizeType = SizeType.Absolute,
					Width = 65f
				});
			}
			tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
			tableLayoutPanel.Refresh();
			label_baseH_Zn = new Label[8];
			label_baseH_Zn_V = new Label[8];
			for (int k = 0; k < 8; k++)
			{
				label_baseH_Zn[k] = new Label();
				label_baseH_Zn[k].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (k + 1);
				tableLayoutPanel.Controls.Add(label_baseH_Zn[k], k, 0);
				label_baseH_Zn[k].Size = new Size(60, 20);
				label_baseH_Zn[k].Font = new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label_baseH_Zn[k].Tag = k;
				label_baseH_Zn[k].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_Zn_V[k] = new Label();
				try
				{
					label_baseH_Zn_V[k].Text = Math.Abs(array[num].mZnData[k].baseH).ToString();
				}
				catch (Exception)
				{
					array[num].mZnData[k].baseH = 0;
					label_baseH_Zn_V[k].Text = Math.Abs(array[num].mZnData[k].baseH).ToString();
				}
				tableLayoutPanel.Controls.Add(label_baseH_Zn_V[k], k, 1);
				label_baseH_Zn_V[k].Size = new Size(60, 20);
				label_baseH_Zn_V[k].Font = new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label_baseH_Zn_V[k].Tag = k;
				label_baseH_Zn_V[k].Anchor = AnchorStyles.None;
				label_baseH_Zn_V[k].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_Zn_V[k].DoubleClick += label_baseH_Zn_V_DoubleClick;
			}
			tableLayoutPanel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel, true, null);
			tableLayoutPanel.SuspendLayout();
			flush_zn();
			flush_table();
		}

		private void label_baseH_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			StackElement[] array = USR2.mStackLib.stacktab[(int)USR2.mStackLib.sel];
			int num2 = USR2.mStackLib.index[(int)USR2.mStackLib.sel];
			Form_FillXY form_FillXY = new Form_FillXY(array[num2].mZnData[num].baseH, USR_INIT.mLanguage, "Z");
			form_FillXY.TopMost = true;
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				array[num2].mZnData[num].baseH = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					array[num2].mZnData[num].baseH = Math.Abs(array[num2].mZnData[num].baseH);
				}
				label_baseH_Zn_V[num].Text = Math.Abs(array[num2].mZnData[num].baseH).ToString();
			}
		}

		public bool flush_table()
		{
			StackElement[] array = USR2.mStackLib.stacktab[(int)USR2.mStackLib.sel];
			int num = USR2.mStackLib.index[(int)USR2.mStackLib.sel];
			if (USR2.mStackLib.sel == ProviderType.Feedr)
			{
				return false;
			}
			label2.Text = STR.PROVIDER_STR[(int)USR2.mStackLib.sel][USR_INIT.mLanguage] + "-" + (num + 1) + (new string[3] { " 取料基准高度", " 取料基準高度", " Pick Base-H" })[USR_INIT.mLanguage];
			for (int i = 0; i < 8; i++)
			{
				label_baseH_Zn_V[i].Text = Math.Abs(array[num].mZnData[i].baseH).ToString();
			}
			return true;
		}

		public bool flush_table(int sel)
		{
			if (sel == 0)
			{
				return false;
			}
			StackElement[] array = USR2.mStackLib.stacktab[sel];
			int num = USR2.mStackLib.index[sel];
			label2.Text = STR.PROVIDER_STR[sel][USR_INIT.mLanguage] + "-" + (num + 1) + (new string[3] { " 取料基准高度", " 取料基準高度", " Pick Base-H" })[USR_INIT.mLanguage];
			for (int i = 0; i < 8; i++)
			{
				label_baseH_Zn_V[i].Text = Math.Abs(array[num].mZnData[i].baseH).ToString();
			}
			return true;
		}

		public void flush_zn()
		{
			for (int i = 0; i < 8; i++)
			{
				if (i >= HW.mZnNum[MainForm0.mFn])
				{
					Label obj = label_baseH_Zn[i];
					bool enabled = (label_baseH_Zn_V[i].Enabled = false);
					obj.Enabled = enabled;
					Color color2 = (label_baseH_Zn[i].BackColor = (label_baseH_Zn_V[i].BackColor = Color.Transparent));
				}
				else if (MainForm0.mZn[MainForm0.mFn] == i)
				{
					Font font3 = (label_baseH_Zn[i].Font = (label_baseH_Zn_V[i].Font = new Font(label_baseH_Zn_V[i].Font.FontFamily, label_baseH_Zn_V[i].Font.Size, FontStyle.Bold)));
					Color color4 = (label_baseH_Zn[i].BackColor = (label_baseH_Zn_V[i].BackColor = Color.LightSalmon));
				}
				else
				{
					Font font6 = (label_baseH_Zn[i].Font = (label_baseH_Zn_V[i].Font = new Font(label_baseH_Zn_V[i].Font.FontFamily, label_baseH_Zn_V[i].Font.Size, FontStyle.Regular)));
					Color color6 = (label_baseH_Zn[i].BackColor = (label_baseH_Zn_V[i].BackColor = Color.Transparent));
				}
			}
		}

		private void button_sync_Click(object sender, EventArgs e)
		{
			StackElement[] array = USR2.mStackLib.stacktab[(int)USR2.mStackLib.sel];
			int num = USR2.mStackLib.index[(int)USR2.mStackLib.sel];
			int num2 = MainForm0.mZn[MainForm0.mFn];
			float num3 = Math.Abs(MainForm0.format_H_to_Hmm(array[num].mZnData[num2].baseH));
			float num4 = Math.Abs(MainForm0.format_H_to_Hmm(USR.mBaseHeight[num2]));
			float num5 = num3 - num4;
			for (int i = 0; i < 8; i++)
			{
				if (i != num2)
				{
					float hmm = USR.mBaseHeightmm[i] + num5;
					array[num].mZnData[i].baseH = MainForm0.format_Hmm_to_H(hmm) * ((i % 2 != 0) ? 1 : (-1));
					if (HW.mSmtGenerationNo == 2)
					{
						array[num].mZnData[i].baseH = Math.Abs(array[num].mZnData[i].baseH);
					}
					label_baseH_Zn_V[i].Text = Math.Abs(array[num].mZnData[i].baseH).ToString();
				}
			}
		}

		private void button_save_Click(object sender, EventArgs e)
		{
			StackElement[] array = USR2.mStackLib.stacktab[(int)USR2.mStackLib.sel];
			int num = USR2.mStackLib.index[(int)USR2.mStackLib.sel];
			int num2 = MainForm0.mZn[MainForm0.mFn];
			array[num].mZnData[num2].baseH = MainForm0.mCur[MainForm0.mFn].z[num2];
			label_baseH_Zn_V[num2].Text = Math.Abs(array[num].mZnData[num2].baseH).ToString();
		}

		private void button_goto_Click(object sender, EventArgs e)
		{
			StackElement[] array = USR2.mStackLib.stacktab[(int)USR2.mStackLib.sel];
			int num = USR2.mStackLib.index[(int)USR2.mStackLib.sel];
			_ = (string)((Button)sender).Tag;
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[MainForm0.mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				int num2 = MainForm0.mZn[MainForm0.mFn];
				int baseH = array[num].mZnData[num2].baseH;
				thread.IsBackground = true;
				thread.Start(baseH);
			}
		}

		private void Form_ProviderHeight_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_save);
			MainForm0.CreateAddButtonPic(button_goto);
			MainForm0.CreateAddButtonPic(button_sync);
		}
	}
}
