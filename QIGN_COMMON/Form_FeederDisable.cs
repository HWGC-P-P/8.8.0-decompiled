using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_FeederDisable : Form
	{
		private IContainer components;

		private Panel panel_all;

		private Panel panel_side0;

		private Panel panel_side1;

		private Label label1;

		private Label label2;

		private Button button_OK;

		private Button button_Cancel;

		private Panel panel_okcancel;

		private Panel panel_0;

		private Label label3;

		private Label label4;

		private Panel[] panel_sides = new Panel[2];

		private float[][] mIsBroken;

		private float[][] mIsBroken_Temp;

		private Label[][] label_s;

		private int mLanguage;

		public int[] mNozzleState;

		public int[] mNozzleState_BackToAPP;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.Form_FeederDisable));
			panel_all = new System.Windows.Forms.Panel();
			panel_side1 = new System.Windows.Forms.Panel();
			panel_side0 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_OK = new System.Windows.Forms.Button();
			button_Cancel = new System.Windows.Forms.Button();
			panel_okcancel = new System.Windows.Forms.Panel();
			panel_0 = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			panel_all.SuspendLayout();
			panel_okcancel.SuspendLayout();
			SuspendLayout();
			panel_all.BackColor = System.Drawing.Color.Moccasin;
			panel_all.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_all.Controls.Add(panel_side1);
			panel_all.Controls.Add(panel_side0);
			panel_all.Location = new System.Drawing.Point(10, 192);
			panel_all.Name = "panel_all";
			panel_all.Size = new System.Drawing.Size(1148, 172);
			panel_all.TabIndex = 0;
			panel_side1.Location = new System.Drawing.Point(13, 24);
			panel_side1.Name = "panel_side1";
			panel_side1.Size = new System.Drawing.Size(1038, 48);
			panel_side1.TabIndex = 0;
			panel_side0.Location = new System.Drawing.Point(13, 103);
			panel_side0.Name = "panel_side0";
			panel_side0.Size = new System.Drawing.Size(1038, 48);
			panel_side0.TabIndex = 0;
			label1.BackColor = System.Drawing.Color.LemonChiffon;
			label1.Font = new System.Drawing.Font("黑体", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(5, 154);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(132, 31);
			label1.TabIndex = 1;
			label1.Text = "料槽禁用设置";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(203, 163);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(264, 16);
			label2.TabIndex = 2;
			label2.Text = "双击料槽号，使其变灰，禁用该料槽";
			button_OK.BackColor = System.Drawing.Color.Coral;
			button_OK.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OK.Location = new System.Drawing.Point(375, 10);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(135, 49);
			button_OK.TabIndex = 3;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = false;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			button_Cancel.BackColor = System.Drawing.Color.Moccasin;
			button_Cancel.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Cancel.Location = new System.Drawing.Point(670, 10);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(136, 49);
			button_Cancel.TabIndex = 3;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = false;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			panel_okcancel.Controls.Add(button_Cancel);
			panel_okcancel.Controls.Add(button_OK);
			panel_okcancel.Location = new System.Drawing.Point(10, 370);
			panel_okcancel.Name = "panel_okcancel";
			panel_okcancel.Size = new System.Drawing.Size(1146, 72);
			panel_okcancel.TabIndex = 4;
			panel_0.Location = new System.Drawing.Point(10, 59);
			panel_0.Name = "panel_0";
			panel_0.Size = new System.Drawing.Size(490, 93);
			panel_0.TabIndex = 5;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(203, 23);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(264, 16);
			label3.TabIndex = 7;
			label3.Text = "双击吸嘴号，使其变灰，禁用该吸嘴";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.Location = new System.Drawing.Point(7, 20);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(129, 20);
			label4.TabIndex = 6;
			label4.Text = "吸嘴禁用设置";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LemonChiffon;
			base.ClientSize = new System.Drawing.Size(1173, 445);
			base.Controls.Add(label3);
			base.Controls.Add(label4);
			base.Controls.Add(panel_0);
			base.Controls.Add(panel_okcancel);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(panel_all);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form_FeederDisable";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			panel_all.ResumeLayout(false);
			panel_okcancel.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public void nozzle_init(int[] nzstate)
		{
			mNozzleState = new int[HW.mZnNum[MainForm0.mFn]];
			mNozzleState_BackToAPP = nzstate;
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				mNozzleState[i] = nzstate[i];
			}
			for (int j = 0; j < HW.mZnNum[MainForm0.mFn]; j++)
			{
				Label label = new Label();
				label.Size = new Size(36, 36);
				label.Location = new Point(5 + j * 46, 5);
				label.BorderStyle = BorderStyle.FixedSingle;
				label.BackColor = ((mNozzleState_BackToAPP[j] == 1) ? Color.LightPink : Color.Gray);
				label.Tag = j;
				label.Text = (j + 1).ToString();
				label.TextAlign = ContentAlignment.MiddleCenter;
				label.Font = new Font(STR.LANGUAGE[mLanguage], 12f + DEF.FSIZE_2020[mLanguage], FontStyle.Regular);
				label.MouseClick += label_n_MouseClick;
				panel_0.Controls.Add(label);
			}
		}

		private void label_n_MouseClick(object sender, MouseEventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			if (mNozzleState[num] == 1)
			{
				mNozzleState[num] = 0;
				((Label)sender).BackColor = Color.Gray;
			}
			else
			{
				mNozzleState[num] = 1;
				((Label)sender).BackColor = Color.LightPink;
			}
		}

		public Form_FeederDisable(int language, float[][] isbroken, int[] nzstate)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mLanguage = language;
			initLanguageTable();
			updateLanguage(mLanguage);
			nozzle_init(nzstate);
			mIsBroken = isbroken;
			mIsBroken_Temp = new float[2][];
			for (int i = 0; i < 2; i++)
			{
				mIsBroken_Temp[i] = new float[HW.malgo2[MainForm0.mFn].len[i]];
				for (int j = 0; j < HW.malgo2[MainForm0.mFn].len[i]; j++)
				{
					mIsBroken_Temp[i][j] = mIsBroken[i][j];
				}
			}
			label_s = new Label[2][];
			panel_sides = new Panel[2];
			panel_sides[0] = panel_side0;
			panel_sides[1] = panel_side1;
			int num = 1156;
			int num2 = 48;
			int num3 = 10;
			int num4 = 22;
			int num5 = 2;
			panel_side0.Size = new Size(num, num2);
			panel_side1.Size = new Size(num, num2);
			panel_side0.Location = new Point(0, (num2 + num3) * 2);
			panel_side1.Location = new Point(0, num4);
			panel_all.Size = new Size(num + num5, num2 * 3 + num4);
			panel_okcancel.Location = new Point(panel_all.Location.X, panel_all.Location.Y + panel_all.Size.Height);
			for (int k = 0; k < 2; k++)
			{
				label_s[k] = new Label[HW.malgo2[MainForm0.mFn].len[k]];
				for (int l = 0; l < HW.malgo2[MainForm0.mFn].len[k]; l++)
				{
					if (l < HW.malgo2[MainForm0.mFn].emp_l[k] || l >= HW.malgo2[MainForm0.mFn].len[k] - HW.malgo2[MainForm0.mFn].emp_r[k])
					{
						continue;
					}
					int num6 = MainForm0.format_stackno(MainForm0.mFn, k, l);
					label_s[k][l] = new Label();
					label_s[k][l].Size = new Size(num4, num4);
					label_s[k][l].Location = new Point(num5 + (num4 + num5) * (l - HW.malgo2[MainForm0.mFn].emp_l[k]), num5);
					label_s[k][l].AutoSize = false;
					label_s[k][l].BorderStyle = BorderStyle.FixedSingle;
					label_s[k][l].TextAlign = ContentAlignment.MiddleCenter;
					label_s[k][l].Text = ((num6 >= 0) ? (num6 + 1).ToString() : "");
					label_s[k][l].BackColor = ((num6 >= 0) ? Color.Yellow : Color.Gray);
					label_s[k][l].Tag = k * 1000 + l;
					label_s[k][l].Font = new Font("黑体", 9f, FontStyle.Regular);
					if (num6 < 0)
					{
						label_s[k][l].Size = new Size(num4 + num5, num4);
						label_s[k][l].BorderStyle = BorderStyle.None;
						if (l == HW.malgo2[MainForm0.mFn].emp_l[k] - 1 || (k == 0 && l == HW.malgo2[MainForm0.mFn].emp_l[k] + HW.malgo2[MainForm0.mFn].emp_m[k] + HW.malgo2[MainForm0.mFn].slt_l[k] - 1) || l == HW.malgo2[MainForm0.mFn].len[k] - 1 || (k == 1 && l == HW.malgo2[MainForm0.mFn].emp_l[k] + HW.malgo2[MainForm0.mFn].emp_m[k] + HW.malgo2[MainForm0.mFn].emp_l[k] - 1))
						{
							label_s[k][l].Size = new Size(num4, num4);
						}
					}
					if (isbroken != null && isbroken[k] != null && num6 >= 0)
					{
						if (isbroken[k][l] == 1f)
						{
							label_s[k][l].BackColor = Color.Gray;
						}
						else if (isbroken[k][l] == 0f)
						{
							label_s[k][l].BackColor = Color.Yellow;
						}
						label_s[k][l].MouseClick += label_s_MouseClick;
					}
					panel_sides[k].Controls.Add(label_s[k][l]);
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
				ctrl = label4,
				str = new string[3] { "吸嘴禁用设置", "吸嘴禁用设置", "NOZZLE DISABLE" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "料槽禁用设置", "料槽禁用设置", "SLOTS DISABLE" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "单击吸嘴号，使其变灰，禁用该吸嘴", "单击吸嘴号，使其变灰，禁用该吸嘴", "Click to disable/enable nozzle" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "单击料槽号，使其变灰，禁用该料槽", "单击料槽号，使其变灰，禁用该料槽", "Click to disable/enable slot" }
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
		}

		private void label_s_MouseClick(object sender, MouseEventArgs e)
		{
			int num = (int)((Label)sender).Tag / 1000;
			int num2 = (int)((Label)sender).Tag % 1000;
			int num3 = MainForm0.format_stackno(MainForm0.mFn, num, num2);
			if (num3 >= 0)
			{
				if (mIsBroken_Temp[num][num2] == 0f)
				{
					mIsBroken_Temp[num][num2] = 1f;
					((Label)sender).BackColor = Color.Gray;
				}
				else
				{
					mIsBroken_Temp[num][num2] = 0f;
					((Label)sender).BackColor = Color.Yellow;
				}
			}
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			string text = "You have to re-run generate smt list function feeder/nozzle disable/enable change! ";
			string text2 = "修改禁用表之后需要重新一键生成，是否继续？";
			if (MainForm0.CmMessageBox((mLanguage == 2) ? text : text2, MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				mNozzleState_BackToAPP[i] = mNozzleState[i];
			}
			for (int j = 0; j < 2; j++)
			{
				for (int k = 0; k < HW.malgo2[MainForm0.mFn].len[j]; k++)
				{
					mIsBroken[j][k] = mIsBroken_Temp[j][k];
				}
			}
			base.DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}
	}
}
