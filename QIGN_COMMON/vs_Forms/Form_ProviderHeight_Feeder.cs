using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_ProviderHeight_Feeder : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private Label label3;

		private Panel panel1;

		private Panel panel2;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Button button_saveH_B;

		private Button button_gotoH_B;

		private Button button_syncH_B;

		private Button button_syncH_F;

		private Button button_gotoH_F;

		private Button button_saveH_F;

		private USR_DATA USR;

		private USR2_DATA USR2;

		private USR_INIT_DATA USR_INIT;

		public Label[] label_baseH_B_Zn;

		public Label[] label_baseH_B_Zn_V;

		public Label[] label_baseH_F_Zn;

		public Label[] label_baseH_F_Zn_V;

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
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			button_syncH_B = new System.Windows.Forms.Button();
			button_gotoH_B = new System.Windows.Forms.Button();
			button_saveH_B = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			button_syncH_F = new System.Windows.Forms.Button();
			button_gotoH_F = new System.Windows.Forms.Button();
			button_saveH_F = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			label1.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(16, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(675, 40);
			label1.TabIndex = 2;
			label1.Text = "前后飞达基准高度";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Location = new System.Drawing.Point(67, 83);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(580, 5);
			label2.TabIndex = 3;
			label2.Text = "label2";
			label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.Location = new System.Drawing.Point(67, 83);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(5, 320);
			label3.TabIndex = 3;
			label3.Text = "label2";
			panel1.Controls.Add(button_syncH_B);
			panel1.Controls.Add(button_gotoH_B);
			panel1.Controls.Add(button_saveH_B);
			panel1.Location = new System.Drawing.Point(87, 123);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(544, 107);
			panel1.TabIndex = 4;
			button_syncH_B.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_syncH_B.Location = new System.Drawing.Point(293, 70);
			button_syncH_B.Name = "button_syncH_B";
			button_syncH_B.Size = new System.Drawing.Size(158, 32);
			button_syncH_B.TabIndex = 0;
			button_syncH_B.Text = "同步到其他吸嘴";
			button_syncH_B.UseVisualStyleBackColor = true;
			button_syncH_B.Click += new System.EventHandler(button_syncH_B_Click);
			button_gotoH_B.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_gotoH_B.Location = new System.Drawing.Point(189, 70);
			button_gotoH_B.Name = "button_gotoH_B";
			button_gotoH_B.Size = new System.Drawing.Size(98, 32);
			button_gotoH_B.TabIndex = 0;
			button_gotoH_B.Text = "定位高度";
			button_gotoH_B.UseVisualStyleBackColor = true;
			button_gotoH_B.Click += new System.EventHandler(button_gotoH_B_Click);
			button_saveH_B.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_saveH_B.Location = new System.Drawing.Point(85, 70);
			button_saveH_B.Name = "button_saveH_B";
			button_saveH_B.Size = new System.Drawing.Size(98, 32);
			button_saveH_B.TabIndex = 0;
			button_saveH_B.Text = "保存高度";
			button_saveH_B.UseVisualStyleBackColor = true;
			button_saveH_B.Click += new System.EventHandler(button_saveH_B_Click);
			panel2.Controls.Add(button_syncH_F);
			panel2.Controls.Add(button_gotoH_F);
			panel2.Controls.Add(button_saveH_F);
			panel2.Location = new System.Drawing.Point(86, 298);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(544, 117);
			panel2.TabIndex = 4;
			button_syncH_F.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_syncH_F.Location = new System.Drawing.Point(294, 67);
			button_syncH_F.Name = "button_syncH_F";
			button_syncH_F.Size = new System.Drawing.Size(158, 32);
			button_syncH_F.TabIndex = 0;
			button_syncH_F.Text = "同步到其他吸嘴";
			button_syncH_F.UseVisualStyleBackColor = true;
			button_syncH_F.Click += new System.EventHandler(button_syncH_F_Click);
			button_gotoH_F.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_gotoH_F.Location = new System.Drawing.Point(190, 67);
			button_gotoH_F.Name = "button_gotoH_F";
			button_gotoH_F.Size = new System.Drawing.Size(98, 32);
			button_gotoH_F.TabIndex = 0;
			button_gotoH_F.Text = "定位高度";
			button_gotoH_F.UseVisualStyleBackColor = true;
			button_gotoH_F.Click += new System.EventHandler(button_gotoH_F_Click);
			button_saveH_F.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_saveH_F.Location = new System.Drawing.Point(86, 67);
			button_saveH_F.Name = "button_saveH_F";
			button_saveH_F.Size = new System.Drawing.Size(98, 32);
			button_saveH_F.TabIndex = 0;
			button_saveH_F.Text = "保存高度";
			button_saveH_F.UseVisualStyleBackColor = true;
			button_saveH_F.Click += new System.EventHandler(button_saveH_F_Click);
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 12.25f);
			label4.Location = new System.Drawing.Point(83, 101);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(80, 17);
			label4.TabIndex = 2;
			label4.Text = "后端飞达";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 12.25f);
			label5.Location = new System.Drawing.Point(83, 276);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(80, 17);
			label5.TabIndex = 2;
			label5.Text = "前端飞达";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("黑体", 12.25f);
			label6.Location = new System.Drawing.Point(12, 62);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 2;
			label6.Text = "复位零点";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 24.25f);
			label7.Location = new System.Drawing.Point(12, 154);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(49, 33);
			label7.TabIndex = 2;
			label7.Text = "后";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("黑体", 24.25f);
			label8.Location = new System.Drawing.Point(12, 336);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(49, 33);
			label8.TabIndex = 2;
			label8.Text = "前";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(703, 423);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label5);
			base.Controls.Add(label6);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label4);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_ProviderHeight_Feeder";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
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
				ctrl = label1,
				str = new string[3] { "前后飞达基准高度（所有料站统一修改,系统参数）", "前后飞达基准高度（所有料站统一修改,系统参数）", "Feeder Base Height （for all feeders）" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "复位零点", "复位零点", "Reset Zero Point" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "后", "后", "Back" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label8,
				str = new string[3] { "前", "前", "Front" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "后端飞达", "后端飞达", "Back Feeder" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_saveH_B,
				str = new string[3] { "保存高度", "保存高度", "Save Height" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_gotoH_B,
				str = new string[3] { "定位高度", "定位高度", "Goto Height" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_syncH_B,
				str = new string[3] { "同步到其他吸嘴", "同步到其他吸嘴", "Sync to Other Nozzles" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "前端飞达", "前端飞达", "Front Feeder" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_saveH_F,
				str = new string[3] { "保存高度", "保存高度", "Save Height" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_gotoH_F,
				str = new string[3] { "定位高度", "定位高度", "Goto Height" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_syncH_F,
				str = new string[3] { "同步到其他吸嘴", "同步到其他吸嘴", "Sync to Other Nozzles" }
			});
		}

		public Form_ProviderHeight_Feeder(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			initLanguageTable();
			updateLanguage(USR_INIT.mLanguage);
			init_form();
		}

		public Form_ProviderHeight_Feeder(USR_DATA usr, USR2_DATA usr2)
		{
			InitializeComponent();
			USR = usr;
			USR2 = usr2;
			initLanguageTable();
			updateLanguage(USR_INIT.mLanguage);
			init_form();
		}

		public void init_form()
		{
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
			label_baseH_B_Zn = new Label[8];
			label_baseH_B_Zn_V = new Label[8];
			for (int k = 0; k < 8; k++)
			{
				label_baseH_B_Zn[k] = new Label();
				label_baseH_B_Zn[k].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (k + 1);
				tableLayoutPanel.Controls.Add(label_baseH_B_Zn[k], k, 0);
				label_baseH_B_Zn[k].Size = new Size(60, 20);
				label_baseH_B_Zn[k].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				label_baseH_B_Zn[k].Tag = k;
				label_baseH_B_Zn[k].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_B_Zn_V[k] = new Label();
				label_baseH_B_Zn_V[k].Text = Math.Abs(USR.mBaseHeight_feederBk[k]).ToString();
				tableLayoutPanel.Controls.Add(label_baseH_B_Zn_V[k], k, 1);
				label_baseH_B_Zn_V[k].Size = new Size(60, 20);
				label_baseH_B_Zn_V[k].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				label_baseH_B_Zn_V[k].Tag = k;
				label_baseH_B_Zn_V[k].Anchor = AnchorStyles.None;
				label_baseH_B_Zn_V[k].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_B_Zn_V[k].DoubleClick += label_baseH_Zn_B_V_DoubleClick;
			}
			tableLayoutPanel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel, true, null);
			tableLayoutPanel.SuspendLayout();
			TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
			panel2.Controls.Add(tableLayoutPanel2);
			tableLayoutPanel2.Controls.Clear();
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.ColumnCount = 8;
			tableLayoutPanel2.Size = new Size(538, 50);
			tableLayoutPanel2.BackColor = Color.WhiteSmoke;
			for (int l = 0; l < tableLayoutPanel2.RowCount; l++)
			{
				tableLayoutPanel2.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.Absolute,
					Height = 22f
				});
			}
			for (int m = 0; m < tableLayoutPanel2.ColumnCount; m++)
			{
				tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle
				{
					SizeType = SizeType.Absolute,
					Width = 65f
				});
			}
			tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
			tableLayoutPanel2.Refresh();
			label_baseH_F_Zn = new Label[8];
			label_baseH_F_Zn_V = new Label[8];
			for (int n = 0; n < 8; n++)
			{
				label_baseH_F_Zn[n] = new Label();
				label_baseH_F_Zn[n].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (n + 1);
				tableLayoutPanel2.Controls.Add(label_baseH_F_Zn[n], n, 0);
				label_baseH_F_Zn[n].Size = new Size(60, 20);
				label_baseH_F_Zn[n].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				label_baseH_F_Zn[n].Tag = n;
				label_baseH_F_Zn[n].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_F_Zn_V[n] = new Label();
				label_baseH_F_Zn_V[n].Text = Math.Abs(USR.mBaseHeight_feeder[n]).ToString();
				tableLayoutPanel2.Controls.Add(label_baseH_F_Zn_V[n], n, 1);
				label_baseH_F_Zn_V[n].Size = new Size(60, 20);
				label_baseH_F_Zn_V[n].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				label_baseH_F_Zn_V[n].Tag = n;
				label_baseH_F_Zn_V[n].Anchor = AnchorStyles.None;
				label_baseH_F_Zn_V[n].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_F_Zn_V[n].DoubleClick += label_baseH_Zn_F_V_DoubleClick;
			}
			tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
			tableLayoutPanel2.SuspendLayout();
			flush_zn();
			flush_table();
		}

		private void label_baseH_Zn_B_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight_feederBk[num], USR_INIT.mLanguage, "Z");
			form_FillXY.TopMost = true;
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mBaseHeight_feederBk[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mBaseHeight_feederBk[num] = Math.Abs(USR.mBaseHeight_feederBk[num]);
				}
				label_baseH_B_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_feederBk[num]).ToString();
			}
		}

		private void label_baseH_Zn_F_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight_feeder[num], USR_INIT.mLanguage, "Z");
			form_FillXY.TopMost = true;
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mBaseHeight_feeder[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mBaseHeight_feeder[num] = Math.Abs(USR.mBaseHeight_feeder[num]);
				}
				label_baseH_F_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_feeder[num]).ToString();
			}
		}

		public bool flush_table()
		{
			return false;
		}

		public bool flush_table(int sel)
		{
			if (sel == 0)
			{
				return true;
			}
			return false;
		}

		public void flush_zn()
		{
			for (int i = 0; i < 8; i++)
			{
				if (i >= HW.mZnNum[MainForm0.mFn])
				{
					Label obj = label_baseH_B_Zn[i];
					bool enabled = (label_baseH_B_Zn_V[i].Enabled = false);
					obj.Enabled = enabled;
					Color color2 = (label_baseH_B_Zn[i].BackColor = (label_baseH_B_Zn_V[i].BackColor = Color.Transparent));
					Label obj2 = label_baseH_F_Zn[i];
					bool enabled2 = (label_baseH_F_Zn_V[i].Enabled = false);
					obj2.Enabled = enabled2;
					Color color4 = (label_baseH_F_Zn[i].BackColor = (label_baseH_F_Zn_V[i].BackColor = Color.Transparent));
				}
				else if (MainForm0.mZn[MainForm0.mFn] == i)
				{
					Font font3 = (label_baseH_B_Zn[i].Font = (label_baseH_B_Zn_V[i].Font = new Font(label_baseH_B_Zn_V[i].Font.FontFamily, label_baseH_B_Zn_V[i].Font.Size, FontStyle.Bold)));
					Color color6 = (label_baseH_B_Zn[i].BackColor = (label_baseH_B_Zn_V[i].BackColor = Color.LightSalmon));
					Font font6 = (label_baseH_F_Zn[i].Font = (label_baseH_F_Zn_V[i].Font = new Font(label_baseH_F_Zn_V[i].Font.FontFamily, label_baseH_F_Zn_V[i].Font.Size, FontStyle.Bold)));
					Color color8 = (label_baseH_F_Zn[i].BackColor = (label_baseH_F_Zn_V[i].BackColor = Color.LightSalmon));
				}
				else
				{
					Font font9 = (label_baseH_B_Zn[i].Font = (label_baseH_B_Zn_V[i].Font = new Font(label_baseH_B_Zn_V[i].Font.FontFamily, label_baseH_B_Zn_V[i].Font.Size, FontStyle.Regular)));
					Color color10 = (label_baseH_B_Zn[i].BackColor = (label_baseH_B_Zn_V[i].BackColor = Color.Transparent));
					Font font12 = (label_baseH_F_Zn[i].Font = (label_baseH_F_Zn_V[i].Font = new Font(label_baseH_F_Zn_V[i].Font.FontFamily, label_baseH_F_Zn_V[i].Font.Size, FontStyle.Regular)));
					Color color12 = (label_baseH_F_Zn[i].BackColor = (label_baseH_F_Zn_V[i].BackColor = Color.Transparent));
				}
			}
		}

		private void button_saveH_B_Click(object sender, EventArgs e)
		{
			int num = MainForm0.mZn[MainForm0.mFn];
			USR.mBaseHeight_feederBk[num] = MainForm0.mCur[MainForm0.mFn].z[num];
			label_baseH_B_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_feederBk[num]).ToString();
		}

		private void button_gotoH_B_Click(object sender, EventArgs e)
		{
		}

		private void button_syncH_B_Click(object sender, EventArgs e)
		{
			int num = MainForm0.mZn[MainForm0.mFn];
			float num2 = Math.Abs(MainForm0.format_H_to_Hmm(USR.mBaseHeight_feederBk[num]));
			float num3 = Math.Abs(MainForm0.format_H_to_Hmm(USR.mBaseHeight[num]));
			float num4 = num2 - num3;
			for (int i = 0; i < 8; i++)
			{
				if (i != num)
				{
					float hmm = USR.mBaseHeightmm[i] + num4;
					USR.mBaseHeight_feederBk[i] = MainForm0.format_Hmm_to_H(hmm) * ((i % 2 != 0) ? 1 : (-1));
					if (HW.mSmtGenerationNo == 2)
					{
						USR.mBaseHeight_feederBk[i] = Math.Abs(USR.mBaseHeight_feederBk[i]);
					}
					label_baseH_B_Zn_V[i].Text = Math.Abs(USR.mBaseHeight_feederBk[i]).ToString();
				}
			}
		}

		private void button_saveH_F_Click(object sender, EventArgs e)
		{
			int num = MainForm0.mZn[MainForm0.mFn];
			USR.mBaseHeight_feeder[num] = MainForm0.mCur[MainForm0.mFn].z[num];
			label_baseH_F_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_feeder[num]).ToString();
		}

		private void button_gotoH_F_Click(object sender, EventArgs e)
		{
		}

		private void button_syncH_F_Click(object sender, EventArgs e)
		{
			int num = MainForm0.mZn[MainForm0.mFn];
			float num2 = Math.Abs(MainForm0.format_H_to_Hmm(USR.mBaseHeight_feeder[num]));
			float num3 = Math.Abs(MainForm0.format_H_to_Hmm(USR.mBaseHeight[num]));
			float num4 = num2 - num3;
			for (int i = 0; i < 8; i++)
			{
				if (i != num)
				{
					float hmm = USR.mBaseHeightmm[i] + num4;
					USR.mBaseHeight_feeder[i] = MainForm0.format_Hmm_to_H(hmm) * ((i % 2 != 0) ? 1 : (-1));
					if (HW.mSmtGenerationNo == 2)
					{
						USR.mBaseHeight_feeder[i] = Math.Abs(USR.mBaseHeight_feeder[i]);
					}
					label_baseH_F_Zn_V[i].Text = Math.Abs(USR.mBaseHeight_feeder[i]).ToString();
				}
			}
		}
	}
}
