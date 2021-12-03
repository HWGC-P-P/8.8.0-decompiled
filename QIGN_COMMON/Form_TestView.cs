using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_TestView : Form
	{
		private IContainer components;

		private Panel panel_all;

		private Panel panel_all2;

		private Panel panel_all3;

		public Form_TestView(BindingList<GpItem>[][] list, BindingList<PikGroup>[][] piklist, BindingList<PikGroup>[] final_piklist)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			int num = 21;
			if (list != null)
			{
				panel_all.AutoScroll = true;
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < 2; j++)
					{
						Label value = new Label
						{
							Text = ((j == 0) ? "A:" : "B:") + list[i][j].Count,
							Size = new Size(60, 20),
							Location = new Point(4 + i * 200 + j * 90, 4),
							AutoSize = false
						};
						panel_all.Controls.Add(value);
						for (int k = 0; k < list[i][j].Count; k++)
						{
							GpItem gpItem = list[i][j][k];
							for (int l = 0; l < HW.mZnNum[MainForm0.mFn] / 2; l++)
							{
								Label label = new Label
								{
									Size = new Size(num, num),
									Location = new Point(4 + i * 200 + j * 90 + (num + 1) * l, 4 + (num + 1) + (num + 1) * k),
									AutoSize = false,
									BorderStyle = BorderStyle.FixedSingle,
									TextAlign = ContentAlignment.MiddleCenter
								};
								if (gpItem.Arr[l] != -1)
								{
									label.Text = (MainForm0.format_stackno(MainForm0.mFn, i, gpItem.Arr[l]) + 1).ToString();
									label.BackColor = Color.Orange;
								}
								else
								{
									label.BackColor = Color.White;
								}
								panel_all.Controls.Add(label);
							}
						}
					}
				}
			}
			if (piklist != null)
			{
				panel_all2.AutoScroll = true;
				for (int m = 0; m < 2; m++)
				{
					for (int n = 0; n < 2; n++)
					{
						Label value2 = new Label
						{
							Text = ((n == 0) ? "A:" : "B:") + piklist[m][n].Count,
							Size = new Size(60, 20),
							Location = new Point(4 + m * 200 + n * 90, 4),
							AutoSize = false
						};
						panel_all2.Controls.Add(value2);
						for (int num2 = 0; num2 < piklist[m][n].Count; num2++)
						{
							PikGroup pikGroup = piklist[m][n][num2];
							for (int num3 = 0; num3 < HW.mZnNum[MainForm0.mFn] / 2; num3++)
							{
								Label label2 = new Label
								{
									Size = new Size(num, num),
									Location = new Point(4 + m * 200 + n * 90 + (num + 1) * num3, 4 + (num + 1) + (num + 1) * num2),
									AutoSize = false,
									BorderStyle = BorderStyle.FixedSingle,
									BackColor = Color.White,
									TextAlign = ContentAlignment.MiddleCenter
								};
								for (int num4 = 0; num4 < pikGroup.gplist.Count; num4++)
								{
									if (pikGroup.gplist[num4].Arr[num3] != -1)
									{
										label2.BackColor = Color.FromArgb(250 - num4 * 30, 160 + num4 * 30, 180 + num4 * 20);
										label2.Text = (1 + MainForm0.format_stackno(MainForm0.mFn, m, pikGroup.gplist[num4].Arr[num3])).ToString();
									}
								}
								panel_all2.Controls.Add(label2);
							}
						}
					}
				}
			}
			if (final_piklist == null)
			{
				return;
			}
			panel_all3.AutoScroll = true;
			for (int num5 = 0; num5 < 2; num5++)
			{
				for (int num6 = 0; num6 < HW.mZnNum[MainForm0.mFn]; num6++)
				{
					Label value3 = new Label
					{
						Size = new Size(num, num),
						Location = new Point(4 + num5 * 200 + num6 * (num + 1), 4),
						Text = (num6 + 1).ToString(),
						TextAlign = ContentAlignment.MiddleCenter
					};
					panel_all3.Controls.Add(value3);
				}
				for (int num7 = 0; num7 < final_piklist[num5].Count; num7++)
				{
					Color[] array = new Color[8]
					{
						Color.Red,
						Color.Green,
						Color.Yellow,
						Color.Pink,
						Color.Orange,
						Color.Blue,
						Color.Brown,
						Color.Gold
					};
					for (int num8 = 0; num8 < HW.mZnNum[MainForm0.mFn]; num8++)
					{
						Label label3 = new Label
						{
							Size = new Size(num, num),
							Location = new Point(4 + num5 * 200 + num8 * (num + 1), 4 + (num + 1) + num7 * (num + 1)),
							BorderStyle = BorderStyle.FixedSingle,
							AutoSize = false,
							TextAlign = ContentAlignment.MiddleCenter,
							BackColor = Color.White
						};
						int num9 = num8 % 2;
						int num10 = num8 / 2;
						for (int num11 = 0; num11 < final_piklist[num5][num7].gplist.Count; num11++)
						{
							if (num9 == final_piklist[num5][num7].gplist[num11].ab && final_piklist[num5][num7].gplist[num11].Arr[num10] != -1)
							{
								label3.BackColor = array[num11];
								label3.Text = (1 + MainForm0.format_stackno(MainForm0.mFn, num5, final_piklist[num5][num7].gplist[num11].Arr[num10])).ToString();
							}
						}
						panel_all3.Controls.Add(label3);
					}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.Form_TestView));
			panel_all = new System.Windows.Forms.Panel();
			panel_all2 = new System.Windows.Forms.Panel();
			panel_all3 = new System.Windows.Forms.Panel();
			SuspendLayout();
			panel_all.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_all.Location = new System.Drawing.Point(6, 18);
			panel_all.Name = "panel_all";
			panel_all.Size = new System.Drawing.Size(409, 568);
			panel_all.TabIndex = 0;
			panel_all2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_all2.Location = new System.Drawing.Point(422, 18);
			panel_all2.Name = "panel_all2";
			panel_all2.Size = new System.Drawing.Size(409, 568);
			panel_all2.TabIndex = 1;
			panel_all3.AutoScroll = true;
			panel_all3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_all3.Location = new System.Drawing.Point(839, 18);
			panel_all3.Name = "panel_all3";
			panel_all3.Size = new System.Drawing.Size(395, 567);
			panel_all3.TabIndex = 2;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LightBlue;
			base.ClientSize = new System.Drawing.Size(1246, 598);
			base.Controls.Add(panel_all3);
			base.Controls.Add(panel_all2);
			base.Controls.Add(panel_all);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form_TestView";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
		}
	}
}
