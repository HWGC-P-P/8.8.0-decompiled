using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_FeederShow : Form
	{
		private IContainer components;

		private Panel panel_side0;

		private Panel panel_side1;

		private Panel panel_all;

		private Label label1;

		private ChipCategoryElement[][] slot_feeder_component = new ChipCategoryElement[2][];

		private Panel[] panel_sides = new Panel[2];

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.Form_FeederShow));
			panel_side0 = new System.Windows.Forms.Panel();
			panel_side1 = new System.Windows.Forms.Panel();
			panel_all = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			panel_all.SuspendLayout();
			SuspendLayout();
			panel_side0.BackColor = System.Drawing.Color.PeachPuff;
			panel_side0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_side0.Font = new System.Drawing.Font("微软雅黑", 8.25f);
			panel_side0.Location = new System.Drawing.Point(12, 315);
			panel_side0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			panel_side0.Name = "panel_side0";
			panel_side0.Size = new System.Drawing.Size(1211, 237);
			panel_side0.TabIndex = 0;
			panel_side1.BackColor = System.Drawing.Color.PeachPuff;
			panel_side1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_side1.Font = new System.Drawing.Font("微软雅黑", 8.25f);
			panel_side1.Location = new System.Drawing.Point(12, 61);
			panel_side1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			panel_side1.Name = "panel_side1";
			panel_side1.Size = new System.Drawing.Size(1211, 227);
			panel_side1.TabIndex = 0;
			panel_all.Controls.Add(panel_side1);
			panel_all.Controls.Add(panel_side0);
			panel_all.Location = new System.Drawing.Point(23, 40);
			panel_all.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			panel_all.Name = "panel_all";
			panel_all.Size = new System.Drawing.Size(1238, 575);
			panel_all.TabIndex = 1;
			label1.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(23, 3);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(1223, 43);
			label1.TabIndex = 1;
			label1.Text = "料站安装视图";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightSalmon;
			base.ClientSize = new System.Drawing.Size(1254, 650);
			base.Controls.Add(label1);
			base.Controls.Add(panel_all);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Form_FeederShow";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_FeederShow_Load);
			panel_all.ResumeLayout(false);
			ResumeLayout(false);
		}

		public Form_FeederShow(ChipCategoryElement[][] arragelist, float[][] broken, float[][] occupy)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			slot_feeder_component = arragelist;
			label1.Text = (new string[3] { "料站安装视图", "料站安裝視圖", "Feeder Installation Chat" })[MainForm0.USR_INIT.mLanguage];
			panel_sides = new Panel[2];
			panel_sides[0] = panel_side0;
			panel_sides[1] = panel_side1;
			int num = 1202;
			int num2 = 186;
			int num3 = 10;
			int num4 = 22;
			int num5 = 2;
			int num6 = num2 - num4 - num5 * 4;
			panel_all.Size = new Size(num + num5 * 2, 618);
			panel_side0.Size = new Size(num, num2);
			panel_side1.Size = new Size(num, num2);
			panel_side0.Location = new Point(0, (num2 + num3) * 2);
			panel_side1.Location = new Point(0, 0);
			int num7 = 0;
			for (int i = 0; i < 2 && arragelist[i] != null; i++)
			{
				for (int j = 0; j < HW.malgo2[MainForm0.mFn].len[i]; j++)
				{
					if (arragelist[i][j] != null && arragelist[i][j].Count > num7)
					{
						num7 = arragelist[i][j].Count;
					}
				}
			}
			Panel[][] array = new Panel[2][]
			{
				new Panel[HW.malgo2[MainForm0.mFn].len[0]],
				new Panel[HW.malgo2[MainForm0.mFn].len[1]]
			};
			for (int k = 0; k < 2; k++)
			{
				Label[] array2 = new Label[HW.malgo2[MainForm0.mFn].len[0]];
				for (int l = 0; l < HW.malgo2[MainForm0.mFn].len[0]; l++)
				{
					if (l < HW.malgo2[MainForm0.mFn].emp_l[k] || l >= HW.malgo2[MainForm0.mFn].len[0] - HW.malgo2[MainForm0.mFn].emp_r[k])
					{
						continue;
					}
					int num8 = MainForm0.format_stackno(MainForm0.mFn, k, l);
					array2[l] = new Label();
					array2[l].Size = new Size(num4, num4);
					array2[l].Location = new Point(num5 + (num4 + num5) * (l - HW.malgo2[MainForm0.mFn].emp_l[k] + 1), num5 + k * (num6 + num5));
					array2[l].AutoSize = false;
					array2[l].BorderStyle = BorderStyle.FixedSingle;
					array2[l].TextAlign = ContentAlignment.MiddleCenter;
					array2[l].Text = ((num8 >= 0) ? (num8 + 1).ToString() : "");
					array2[l].BackColor = ((num8 >= 0) ? Color.Yellow : Color.Gray);
					if (num8 < 0)
					{
						array2[l].Size = new Size(num4 + num5, num4);
						array2[l].BorderStyle = BorderStyle.None;
						if (l == HW.malgo2[MainForm0.mFn].emp_l[k] - 1 || (k == 0 && l == HW.malgo2[MainForm0.mFn].emp_l[k] + HW.malgo2[MainForm0.mFn].emp_m[k] + HW.malgo2[MainForm0.mFn].slt_l[k] - 1) || l == HW.malgo2[MainForm0.mFn].len[k] - 1 || (k == 1 && l == HW.malgo2[MainForm0.mFn].emp_l[k] + HW.malgo2[MainForm0.mFn].emp_m[k] + HW.malgo2[MainForm0.mFn].slt_l[k] - 1))
						{
							array2[l].Size = new Size(num4, num4);
						}
					}
					if (occupy != null && occupy[k] != null && num8 >= 0)
					{
						if (broken[k][l] != 0f)
						{
							array2[l].BackColor = Color.Gray;
						}
						else if (occupy[k][l] == 1f)
						{
							array2[l].BackColor = Color.Orange;
						}
						else if (occupy[k][l] > 1f)
						{
							array2[l].BackColor = Color.Red;
						}
						else if ((double)occupy[k][l] >= 0.5)
						{
							array2[l].BackColor = Color.NavajoWhite;
						}
						else if (occupy[k][l] > 0f)
						{
							array2[l].BackColor = Color.LightGoldenrodYellow;
						}
						else if (occupy[k][l] < 0f)
						{
							array2[l].BackColor = Color.Gray;
						}
					}
					panel_sides[k].Controls.Add(array2[l]);
					array[k][l] = new Panel();
					array[k][l].Size = new Size(num4, num6);
					array[k][l].Location = new Point(num5 + (num4 + num5) * (l - HW.malgo2[MainForm0.mFn].emp_l[k] + 1), num5 + (1 - k) * (num4 + num5));
					array[k][l].AutoSize = false;
					array[k][l].BorderStyle = BorderStyle.None;
					array[k][l].Visible = num8 >= 0;
					panel_sides[k].Controls.Add(array[k][l]);
					if (num7 > 0)
					{
						Label label = new Label();
						if (arragelist[k][l] != null)
						{
							label = new Label();
							int num9 = (num6 - num4 - 4) * arragelist[k][l].Count / num7 + 4;
							label.Size = new Size(num4, num9);
							label.Location = new Point(0, k * (num6 - num9 - num5));
							label.AutoSize = false;
							label.BorderStyle = BorderStyle.FixedSingle;
							label.TextAlign = ContentAlignment.MiddleCenter;
							label.BackColor = Color.Red;
							array[k][l].Controls.Add(label);
							label = new Label
							{
								Size = new Size(num4, num4 * 2 / 3),
								Location = new Point(0, (k == 0) ? (num9 + num5) : (num6 - (num9 + num5) - num4 / 2)),
								AutoSize = false,
								BorderStyle = BorderStyle.None,
								TextAlign = ContentAlignment.MiddleCenter,
								Text = arragelist[k][l].Count.ToString()
							};
							array[k][l].Controls.Add(label);
						}
					}
				}
			}
		}

		private void Form_FeederShow_Load(object sender, EventArgs e)
		{
		}
	}
}
