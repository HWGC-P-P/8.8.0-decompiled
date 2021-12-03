using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_NozzleDeltaPara : Form
	{
		private IContainer components;

		private Label label1;

		private Panel panel1;

		private Panel panel2;

		public USR_DATA USR;

		private USR_INIT_DATA USR_INIT;

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
			panel2 = new System.Windows.Forms.Panel();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 15.5f);
			label1.Location = new System.Drawing.Point(298, 14);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(186, 21);
			label1.TabIndex = 0;
			label1.Text = "吸嘴校准参数查看";
			panel1.BackColor = System.Drawing.Color.White;
			panel1.Location = new System.Drawing.Point(42, 48);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(756, 361);
			panel1.TabIndex = 1;
			panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			panel2.Location = new System.Drawing.Point(42, 415);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(756, 251);
			panel2.TabIndex = 2;
			panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(839, 678);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_NozzleDeltaPara";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_NozzleDeltaPara(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			string[] array = new string[10] { "line1-X", "line1-Y", "line2-X", "line2-Y", "line3-X", "line3-Y", "line4-X", "line4-Y", "ave-X", "ave-Y" };
			label1.Text = ((USR_INIT.mLanguage == 2) ? "Nozzle Delta Parameter" : "吸嘴校准参数查看");
			TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
			panel1.Controls.Clear();
			panel1.Controls.Add(tableLayoutPanel);
			tableLayoutPanel.Controls.Clear();
			tableLayoutPanel.RowCount = 11;
			tableLayoutPanel.ColumnCount = HW.mZnNum[MainForm0.mFn] + 1;
			tableLayoutPanel.Location = new Point(15, 15);
			int num = 60;
			tableLayoutPanel.Size = new Size(num * HW.mZnNum[MainForm0.mFn] + 110 + 80, tableLayoutPanel.RowCount * 27 + 2);
			for (int i = 0; i < tableLayoutPanel.RowCount; i++)
			{
				tableLayoutPanel.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.AutoSize
				});
			}
			for (int j = 0; j < tableLayoutPanel.ColumnCount; j++)
			{
				if (j == 0)
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
			for (int k = 0; k < tableLayoutPanel.ColumnStyles.Count; k++)
			{
				if (k > 0)
				{
					Label label = new Label();
					tableLayoutPanel.Controls.Add(label, k, 0);
					label.Text = "Noz" + k;
					label.Size = new Size(num, 25);
					label.AutoSize = false;
					label.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label.Anchor = AnchorStyles.None;
					label.TextAlign = ContentAlignment.MiddleLeft;
				}
				for (int l = 1; l < tableLayoutPanel.RowCount; l++)
				{
					if (k == 0)
					{
						Label label2 = new Label();
						tableLayoutPanel.Controls.Add(label2, k, l);
						label2.Text = array[l - 1];
						label2.Size = new Size(100, 24);
						label2.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Bold);
						label2.Anchor = AnchorStyles.None;
						label2.TextAlign = ContentAlignment.MiddleLeft;
						continue;
					}
					Label label3 = new Label();
					tableLayoutPanel.Controls.Add(label3, k, l);
					int num2 = l - 1;
					int num3 = k - 1;
					if (num2 < 8)
					{
						if (num2 % 2 == 0)
						{
							label3.Text = USR.mDeltaNozzle_Detail[num2 / 2][num3].X.ToString();
						}
						else
						{
							label3.Text = USR.mDeltaNozzle_Detail[num2 / 2][num3].Y.ToString();
						}
					}
					else if (num2 % 2 == 0)
					{
						label3.Text = USR.mDeltaNozzle[0][num3].X.ToString();
					}
					else
					{
						label3.Text = USR.mDeltaNozzle[0][num3].Y.ToString();
					}
					label3.Size = new Size(num, 24);
					label3.AutoSize = false;
					label3.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label3.Anchor = AnchorStyles.None;
					label3.TextAlign = ContentAlignment.MiddleLeft;
					label3.Tag = k - 1;
					label3.BackColor = Color.White;
					label3.BorderStyle = BorderStyle.None;
				}
			}
			tableLayoutPanel.BackColor = Color.WhiteSmoke;
			tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel, true, null);
			tableLayoutPanel.SuspendLayout();
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			int num = panel2.Size.Width / 9;
			int num2 = num;
			int num3 = panel2.Size.Height * 2 / 5;
			int num4 = 37;
			int num5 = 15;
			float num6 = 0.1f;
			float num7 = 0.1f;
			int num8 = 0;
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				num8 += (int)USR.mDeltaNozzle[0][i].Y;
			}
			num8 = (int)((float)num8 / (float)HW.mZnNum[MainForm0.mFn] + 0.5f);
			int num9 = (int)((float)(USR.mDeltaNozzle[0][HW.mZnNum[MainForm0.mFn] - 1].X - USR.mDeltaNozzle[0][0].X) / (float)(HW.mZnNum[MainForm0.mFn] - 1) + 0.5f);
			Graphics graphics = panel2.CreateGraphics();
			SolidBrush solidBrush = new SolidBrush(Color.Black);
			SolidBrush solidBrush2 = new SolidBrush(Color.White);
			Pen pen = new Pen(Color.Black, 1f);
			Pen pen2 = new Pen(Color.Red, 1f);
			for (int j = 0; j < HW.mZnNum[MainForm0.mFn]; j++)
			{
				int num10 = num2 + j * num - num4 / 2 + (int)((double)((float)(USR.mDeltaNozzle[0][j].X - USR.mDeltaNozzle[0][0].X - num9 * j) * num7) + 0.5);
				int num11 = (int)((float)(num3 - num4 / 2) + (float)(USR.mDeltaNozzle[0][j].Y - num8) * num6);
				graphics.FillEllipse(solidBrush, num10, num11, num4, num4);
				graphics.DrawEllipse(pen, num10, num11, num4, num4);
				int num12 = num10 + (num4 - num5) / 2;
				int num13 = num11 + (num4 - num5) / 2;
				graphics.FillEllipse(solidBrush2, num12, num13, num5, num5);
				graphics.DrawEllipse(pen, num12, num13, num5, num5);
				num12 = num10 + num4 / 2;
				num13 = (int)((float)num3 + (float)(USR.mDeltaNozzle[0][j].Y - num8) * num6);
				int x = num12;
				int y = num3 + num4 * 4 - num4 / 2;
				graphics.DrawLine(pen2, num12, num13, x, y);
				num12 = num10 + num4 / 2 - 5;
				num13 = num3 + num4 * 2 + num4 / 2 + 3 + num4 / 2;
				x = num12 + 11;
				y = num13;
				graphics.DrawLine(pen2, num12, num13, x, y);
				if (j != HW.mZnNum[MainForm0.mFn] - 1)
				{
					int num14 = (int)(USR.mDeltaNozzle[0][j + 1].X - USR.mDeltaNozzle[0][j].X);
					float num15 = (float)num14 / 100f;
					num12 += 11;
					num13 -= num4 / 2;
					string s = " X:" + num14 + Environment.NewLine + "(" + num15.ToString("F2") + "mm)";
					graphics.DrawString(s, Font, solidBrush, num12, num13);
				}
				int num16 = (int)((double)(USR.mDeltaNozzle[0][j].Y - num8) + 0.5);
				float num17 = (float)num16 / 100f;
				string s2 = " Y:" + num16 + Environment.NewLine + "(" + num17.ToString("F2") + "mm)";
				graphics.DrawString(s2, Font, solidBrush, num10 - num4 / 2, num11 - num4);
			}
			int num18 = num2 - num / 2;
			int num19 = num3;
			graphics.DrawLine(pen2, num18, num19, num18 + num * HW.mZnNum[MainForm0.mFn], num19);
			pen.Dispose();
			pen2.Dispose();
			solidBrush.Dispose();
			solidBrush2.Dispose();
			graphics.Dispose();
		}
	}
}
