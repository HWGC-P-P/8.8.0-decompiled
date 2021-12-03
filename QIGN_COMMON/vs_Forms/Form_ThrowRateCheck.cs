using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_ThrowRateCheck : Form
	{
		private IContainer components;

		private Panel panel1;

		private Label label1;

		private Panel panel_info;

		private Panel panel2;

		private Panel panel_info2;

		private Label label2;

		public Form_ThrowRateCheck(int lan, int[][][] throwlist, int[][][] nonelist)
		{
			InitializeComponent();
			label1.Text = ((lan == 2) ? "Drop Info" : "抛料信息");
			this.label2.Text = ((lan == 2) ? "Empty Info" : "空取信息");
			if (throwlist == null || nonelist == null)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 160; j++)
				{
					for (int k = 0; k < 8; k++)
					{
						throwlist[i][j][k] -= nonelist[i][j][k];
						if (throwlist[i][j][k] < 0)
						{
							throwlist[i][j][k] = 0;
						}
					}
				}
			}
			BindingList<int[]>[] array = new BindingList<int[]>[3];
			for (int l = 0; l < 3; l++)
			{
				array[l] = new BindingList<int[]>();
				for (int m = 0; m < HW.mStackNum[MainForm0.mFn][0]; m++)
				{
					int num = 0;
					for (int n = 0; n < HW.mZnNum[MainForm0.mFn]; n++)
					{
						num += throwlist[l][m][n];
					}
					if (num > 0)
					{
						array[l].Add(throwlist[l][m]);
					}
				}
			}
			int num2 = array[0].Count + array[1].Count + array[2].Count;
			if (num2 * 25 > panel_info.Size.Height)
			{
				panel_info.Size = new Size(panel_info.Size.Width, 23 * num2);
			}
			string[][] array2 = new string[3][]
			{
				new string[3] { "料站", "料盘", "振动" },
				new string[3] { "料站", "料盘", "振动" },
				new string[3] { "Stack-", "Plate-", "Vibra-" }
			};
			int[] array3 = HW.mStackNum[MainForm0.mFn];
			for (int num3 = 0; num3 < HW.mZnNum[MainForm0.mFn]; num3++)
			{
				Label label = new Label();
				panel1.Controls.Add(label);
				label.AutoSize = false;
				label.Size = new Size(50, 25);
				label.Location = new Point(80 + num3 * 60, 0);
				label.Text = STR.NOZZLE_a[lan] + (num3 + 1);
				label.Font = new Font(DEF.FONT_2020[lan], 10.25f, FontStyle.Bold);
			}
			int num4 = 0;
			for (int num5 = 0; num5 < 3; num5++)
			{
				for (int num6 = 0; num6 < array3[num5]; num6++)
				{
					int num7 = 0;
					for (int num8 = 0; num8 < HW.mZnNum[MainForm0.mFn]; num8++)
					{
						num7 += throwlist[num5][num6][num8];
					}
					if (num7 <= 0)
					{
						continue;
					}
					Label label2 = new Label();
					panel_info.Controls.Add(label2);
					label2.AutoSize = false;
					label2.Size = new Size(60, 21);
					label2.Location = new Point(0, 23 * num4);
					label2.Text = array2[lan][num5] + (num6 + 1);
					label2.TextAlign = ContentAlignment.MiddleLeft;
					label2.Font = new Font(DEF.FONT_2020[lan], 10.25f, FontStyle.Bold);
					for (int num9 = 0; num9 < HW.mZnNum[MainForm0.mFn]; num9++)
					{
						Label label3 = new Label();
						panel_info.Controls.Add(label3);
						label3.AutoSize = false;
						label3.Size = new Size(50, 21);
						label3.Location = new Point(80 + num9 * 60, 23 * num4);
						label3.Text = throwlist[num5][num6][num9].ToString();
						label3.Font = new Font(DEF.FONT_2020[lan], 10.25f, FontStyle.Bold);
						label3.TextAlign = ContentAlignment.MiddleCenter;
						if (throwlist[num5][num6][num9] > 0)
						{
							label3.BackColor = Color.LightCoral;
						}
					}
					num4++;
				}
			}
			BindingList<int[]>[] array4 = new BindingList<int[]>[3];
			for (int num10 = 0; num10 < 3; num10++)
			{
				array4[num10] = new BindingList<int[]>();
				for (int num11 = 0; num11 < HW.mStackNum[MainForm0.mFn][0]; num11++)
				{
					int num12 = 0;
					for (int num13 = 0; num13 < HW.mZnNum[MainForm0.mFn]; num13++)
					{
						num12 += nonelist[num10][num11][num13];
					}
					if (num12 > 0)
					{
						array4[num10].Add(nonelist[num10][num11]);
					}
				}
			}
			int num14 = array4[0].Count + array4[1].Count + array4[2].Count;
			if (num14 * 25 > panel_info2.Size.Height)
			{
				panel_info2.Size = new Size(panel_info2.Size.Width, 23 * num14);
			}
			string[][] array5 = new string[3][]
			{
				new string[3] { "料站", "料盘", "振动" },
				new string[3] { "料站", "料盘", "振动" },
				new string[3] { "Stack-", "Plate-", "Vibra-" }
			};
			int[] array6 = HW.mStackNum[MainForm0.mFn];
			for (int num15 = 0; num15 < HW.mZnNum[MainForm0.mFn]; num15++)
			{
				Label label4 = new Label();
				panel2.Controls.Add(label4);
				label4.AutoSize = false;
				label4.Size = new Size(50, 25);
				label4.Location = new Point(80 + num15 * 60, 0);
				label4.Text = STR.NOZZLE_a[lan] + (num15 + 1);
				label4.Font = new Font(DEF.FONT_2020[lan], 10.25f, FontStyle.Bold);
			}
			int num16 = 0;
			for (int num17 = 0; num17 < 3; num17++)
			{
				for (int num18 = 0; num18 < array6[num17]; num18++)
				{
					int num19 = 0;
					for (int num20 = 0; num20 < HW.mZnNum[MainForm0.mFn]; num20++)
					{
						num19 += nonelist[num17][num18][num20];
					}
					if (num19 <= 0)
					{
						continue;
					}
					Label label5 = new Label();
					panel_info2.Controls.Add(label5);
					label5.AutoSize = false;
					label5.Size = new Size(60, 21);
					label5.Location = new Point(0, 23 * num16);
					label5.Text = array5[lan][num17] + (num18 + 1);
					label5.TextAlign = ContentAlignment.MiddleLeft;
					label5.Font = new Font(DEF.FONT_2020[lan], 10.25f, FontStyle.Bold);
					for (int num21 = 0; num21 < HW.mZnNum[MainForm0.mFn]; num21++)
					{
						Label label6 = new Label();
						panel_info2.Controls.Add(label6);
						label6.AutoSize = false;
						label6.Size = new Size(50, 21);
						label6.Location = new Point(80 + num21 * 60, 23 * num16);
						label6.Text = nonelist[num17][num18][num21].ToString();
						label6.Font = new Font(DEF.FONT_2020[lan], 10.25f, FontStyle.Bold);
						label6.TextAlign = ContentAlignment.MiddleCenter;
						if (nonelist[num17][num18][num21] > 0)
						{
							label6.BackColor = Color.LightCoral;
						}
					}
					num16++;
				}
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
			panel1 = new System.Windows.Forms.Panel();
			panel_info = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			panel_info2 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.AutoScroll = true;
			panel1.Controls.Add(panel_info);
			panel1.Location = new System.Drawing.Point(12, 39);
			panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(612, 499);
			panel1.TabIndex = 0;
			panel_info.Location = new System.Drawing.Point(3, 18);
			panel_info.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_info.Name = "panel_info";
			panel_info.Size = new System.Drawing.Size(587, 435);
			panel_info.TabIndex = 0;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(252, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(93, 20);
			label1.TabIndex = 1;
			label1.Text = "抛料信息";
			panel2.AutoScroll = true;
			panel2.Controls.Add(panel_info2);
			panel2.Location = new System.Drawing.Point(630, 39);
			panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(612, 499);
			panel2.TabIndex = 0;
			panel_info2.Location = new System.Drawing.Point(3, 18);
			panel_info2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_info2.Name = "panel_info2";
			panel_info2.Size = new System.Drawing.Size(587, 435);
			panel_info2.TabIndex = 0;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(861, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(93, 20);
			label2.TabIndex = 1;
			label2.Text = "空取信息";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1253, 549);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("楷体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_ThrowRateCheck";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
