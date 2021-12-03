using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_PcbView : Form
	{
		public const int SCROLL_W = 4000;

		public const int SCROLL_H = 3000;

		private IContainer components;

		private Panel panel_outArea;

		private Panel panel_inArea;

		private Panel panel_op;

		private CheckBox checkBox1;

		public BindingList<ChipUnit_F> mpFlist;

		public volatile int[] mpSignIndex;

		public BindingList<int> mOriginalSignIndex;

		public bool mIsPriciseImport;

		public string mModeS = "";

		public CoordinateDouble[] mFakeMk23;

		public Coordinate[] mMark;

		public volatile bool mIsGotoCenter;

		public volatile bool mIsDisplay_ChipLabel;

		public ContextMenuStrip contextMenuStrip_SetSign = new ContextMenuStrip();

		public Point mCurPoint = default(Point);

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
			panel_outArea = new System.Windows.Forms.Panel();
			panel_inArea = new System.Windows.Forms.Panel();
			panel_op = new System.Windows.Forms.Panel();
			checkBox1 = new System.Windows.Forms.CheckBox();
			panel_outArea.SuspendLayout();
			panel_inArea.SuspendLayout();
			panel_op.SuspendLayout();
			SuspendLayout();
			panel_outArea.AutoScroll = true;
			panel_outArea.BackColor = System.Drawing.Color.AntiqueWhite;
			panel_outArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_outArea.Controls.Add(panel_inArea);
			panel_outArea.Location = new System.Drawing.Point(0, 0);
			panel_outArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_outArea.Name = "panel_outArea";
			panel_outArea.Size = new System.Drawing.Size(1011, 706);
			panel_outArea.TabIndex = 0;
			panel_inArea.Controls.Add(panel_op);
			panel_inArea.Location = new System.Drawing.Point(1, 1);
			panel_inArea.Name = "panel_inArea";
			panel_inArea.Size = new System.Drawing.Size(4000, 3000);
			panel_inArea.TabIndex = 0;
			panel_inArea.Paint += new System.Windows.Forms.PaintEventHandler(panel_inArea_Paint);
			panel_inArea.MouseClick += new System.Windows.Forms.MouseEventHandler(panel_inArea_MouseClick);
			panel_op.BackColor = System.Drawing.Color.DimGray;
			panel_op.Controls.Add(checkBox1);
			panel_op.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_op.Location = new System.Drawing.Point(0, 60);
			panel_op.Name = "panel_op";
			panel_op.Size = new System.Drawing.Size(996, 28);
			panel_op.TabIndex = 0;
			checkBox1.AutoSize = true;
			checkBox1.ForeColor = System.Drawing.Color.White;
			checkBox1.Location = new System.Drawing.Point(197, 6);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(91, 20);
			checkBox1.TabIndex = 0;
			checkBox1.Text = "显示位号";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.RosyBrown;
			base.ClientSize = new System.Drawing.Size(1010, 705);
			base.Controls.Add(panel_outArea);
			Font = new System.Drawing.Font("楷体", 10f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			base.Name = "Form_PcbView";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			panel_outArea.ResumeLayout(false);
			panel_inArea.ResumeLayout(false);
			panel_op.ResumeLayout(false);
			panel_op.PerformLayout();
			ResumeLayout(false);
		}

		public Form_PcbView(int lan, string mode, BindingList<ChipUnit_F> fchip_list, int[] record_mark, bool is_priciseimport, CoordinateDouble[] fakemk23, Coordinate[] markpoint)
		{
			InitializeComponent();
			mIsDisplay_ChipLabel = false;
			base.Controls.Add(panel_op);
			panel_op.Location = new Point(-1, -1);
			panel_op.BringToFront();
			try
			{
				mpFlist = fchip_list;
				panel_inArea.Size = new Size(4000, 3000);
				mpSignIndex = record_mark;
				mIsPriciseImport = is_priciseimport;
				mModeS = mode;
				mFakeMk23 = fakemk23;
				mMark = markpoint;
				mCurPoint = new Point(0, 0);
				mIsGotoCenter = false;
				if (mpSignIndex != null)
				{
					mOriginalSignIndex = new BindingList<int>();
					for (int i = 0; i < 4; i++)
					{
						mOriginalSignIndex.Add(mpSignIndex[i]);
					}
					contextMenuStrip_SetSign = new ContextMenuStrip();
					ToolStripMenuItem[] array = new ToolStripMenuItem[4];
					for (int j = 0; j < 4; j++)
					{
						array[j] = new ToolStripMenuItem(STR.IMPORT_SET_AS_SIGN[lan] + (j + 1));
						array[j].Font = new Font(DEF.FONT_2020[lan], 10.5f, FontStyle.Bold);
						array[j].Click += ToolStripMenuItem_FuncSign_Click;
						array[j].Tag = j;
					}
					contextMenuStrip_SetSign.Items.AddRange(array);
				}
				checkBox1.Checked = mIsDisplay_ChipLabel;
			}
			catch (Exception ex)
			{
				MainForm0.CmMessageBoxTop_Ok(ex.ToString());
				MainForm0.CmMessageBoxTop_Ok(ex.Message.ToString());
			}
		}

		public BindingList<int> get_original_signindex()
		{
			return mOriginalSignIndex;
		}

		private void ToolStripMenuItem_FuncSign_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			int num = (int)toolStripMenuItem.Tag;
			int num2 = 999999;
			int num3 = 0;
			if (mpFlist == null)
			{
				return;
			}
			for (int i = 0; i < mpFlist.Count; i++)
			{
				int num4 = (int)Math.Sqrt((mpFlist[i].pix.X - mCurPoint.X) * (mpFlist[i].pix.X - mCurPoint.X) + (mpFlist[i].pix.Y - mCurPoint.Y) * (mpFlist[i].pix.Y - mCurPoint.Y));
				if (num4 < num2)
				{
					num2 = num4;
					num3 = i;
				}
			}
			mpSignIndex[num] = num3;
			for (int j = 0; j < 4; j++)
			{
				if (j != num && mpSignIndex[j] == mpSignIndex[num])
				{
					mpSignIndex[j] = -1;
				}
			}
			Graphics graphics = panel_inArea.CreateGraphics();
			graphics.Clear(Color.AntiqueWhite);
			graphics.Dispose();
			flush_paint();
		}

		private void flush_paint()
		{
			try
			{
				if (mpFlist == null)
				{
					return;
				}
				int num = panel_outArea.Size.Width - 100;
				int num2 = panel_outArea.Size.Height - 100;
				int num3 = 6;
				double num4 = -99999.0;
				double num5 = -99999.0;
				double num6 = 99999.0;
				double num7 = 99999.0;
				double num8 = 0.0;
				double num9 = 0.0;
				double num10 = 1.0;
				double num11 = 1.0;
				double num12 = 1.0;
				double num13 = 9999999.0;
				for (int i = 0; i < mpFlist.Count; i++)
				{
					if ((double)mpFlist[i].X > num5)
					{
						num5 = mpFlist[i].X;
					}
					if ((double)mpFlist[i].Y > num4)
					{
						num4 = mpFlist[i].Y;
					}
					if ((double)mpFlist[i].X < num7)
					{
						num7 = mpFlist[i].X;
					}
					if ((double)mpFlist[i].Y < num6)
					{
						num6 = mpFlist[i].Y;
					}
					for (int j = i + 1; j < mpFlist.Count; j++)
					{
						double num14 = mpFlist[i].X - mpFlist[j].X;
						double num15 = mpFlist[i].Y - mpFlist[j].Y;
						double num16 = Math.Sqrt(num14 * num14 + num15 * num15);
						if (num16 < num13 && num16 > 0.0)
						{
							num13 = num16;
						}
					}
				}
				num8 = num5 - num7;
				num9 = num4 - num6;
				num10 = (float)num8 / (float)num;
				num11 = (float)num9 / (float)num2;
				num12 = ((!(num10 > num11)) ? num11 : num10);
				if ((double)(float)num13 / num12 < (double)num3)
				{
					num12 = (float)num13 / (float)num3;
					num = (int)((double)(float)num8 / num12) + 60;
					num2 = (int)((double)(float)num9 / num12) + 60;
					float val = 1f;
					float val2 = 1f;
					if (num > 4000)
					{
						val = (float)num / 3200f;
					}
					if (num2 > 3000)
					{
						val2 = (float)num2 / 2400f;
					}
					float num17 = Math.Max(val, val2);
					num12 *= (double)num17;
					num = (int)((double)(float)num8 / num12) + 60;
					num2 = (int)((double)(float)num9 / num12) + 60;
				}
				Graphics graphics = panel_inArea.CreateGraphics();
				SolidBrush solidBrush = new SolidBrush(Color.DarkSeaGreen);
				Pen pen = new Pen(Color.Black, 1f);
				int num18 = (int)((double)(float)(num5 - num7) / num12) + 40;
				int num19 = (int)((double)(float)(num4 - num6) / num12) + 40;
				int num20 = (4000 - num18) / 2;
				int num21 = (3000 - num19) / 2;
				graphics.FillRectangle(solidBrush, num20, num21, num18, num19);
				graphics.DrawRectangle(pen, num20, num21, num18, num19);
				int num22 = num20;
				int num23 = num21;
				if (mModeS == "import" || mModeS == "import_debug")
				{
					if (mpSignIndex != null)
					{
						if (mModeS == "import_debug" && mFakeMk23 != null)
						{
							for (int k = 0; k < mFakeMk23.Count(); k++)
							{
								SolidBrush solidBrush2 = new SolidBrush(Color.Gray);
								int num24 = num22 + (int)((mFakeMk23[k].x - num7) / num12) - 2;
								int num25 = num23 + (int)((mFakeMk23[k].y - num6) / num12) - 2;
								int num26 = 30;
								graphics.FillEllipse(solidBrush2, num24, num25, num26, num26);
								graphics.DrawEllipse(pen, num24, num25, num26, num26);
								graphics.DrawString("FAKE" + (k + 1), new Font("楷体", 12f, FontStyle.Bold), new SolidBrush(Color.Black), num24 + 10 - 25, num25 + 30);
								solidBrush2.Dispose();
							}
						}
						for (int l = 0; l < 4; l++)
						{
							if (mpSignIndex[l] >= 0 && mpSignIndex[l] < mpFlist.Count)
							{
								SolidBrush solidBrush3 = new SolidBrush(DEF.COLOR_MARK[l]);
								int num27 = num22 + (int)(((double)mpFlist[mpSignIndex[l]].X - num7) / num12) - 2;
								int num28 = num23 + (int)(((double)mpFlist[mpSignIndex[l]].Y - num6) / num12) - 2;
								int num29 = 30;
								graphics.FillEllipse(solidBrush3, num27, num28, num29, num29);
								graphics.DrawEllipse(pen, num27, num28, num29, num29);
								string label = mpFlist[mpSignIndex[l]].Label;
								graphics.DrawString("[S" + (l + 1) + "]:" + label, new Font("楷体", 12f, FontStyle.Bold), new SolidBrush(Color.Black), num27 + 10 - 5 - label.Length * 10, num28 + 30);
								solidBrush3.Dispose();
							}
							if (!mIsPriciseImport && l == 1)
							{
								break;
							}
						}
					}
				}
				else if (mModeS == "pcbedit" || mModeS == "pcbedit_debug")
				{
					if (mModeS == "pcbedit_debug" && mFakeMk23 != null)
					{
						for (int m = 0; m < mFakeMk23.Count(); m++)
						{
							SolidBrush solidBrush4 = new SolidBrush(Color.Gray);
							int num30 = num22 + (int)((mFakeMk23[m].x - num7) / num12) - 2;
							int num31 = num23 + (int)((mFakeMk23[m].y - num6) / num12) - 2;
							int num32 = 30;
							graphics.FillEllipse(solidBrush4, num30, num31, num32, num32);
							graphics.DrawEllipse(pen, num30, num31, num32, num32);
							graphics.DrawString("FAKE" + (m + 1), new Font("楷体", 12f, FontStyle.Bold), new SolidBrush(Color.Black), num30 + 10 - 25, num31 + 30);
							solidBrush4.Dispose();
						}
					}
					if (mMark != null)
					{
						for (int n = 0; n < mMark.Count(); n++)
						{
							SolidBrush solidBrush5 = new SolidBrush(Color.Salmon);
							int num33 = num22 + (int)(((double)mMark[n].X - num7) / num12) - 2;
							int num34 = num23 + (int)(((double)mMark[n].Y - num6) / num12) - 2;
							int num35 = 30;
							graphics.FillEllipse(solidBrush5, num33, num34, num35, num35);
							graphics.DrawEllipse(pen, num33, num34, num35, num35);
							solidBrush5.Dispose();
							string s = "Mark-" + (n + 1);
							graphics.DrawString(s, new Font("楷体", 12f, FontStyle.Bold), new SolidBrush(Color.Black), num33 + 10 - 25, num34 + 30);
							solidBrush5.Dispose();
						}
					}
				}
				if (mIsDisplay_ChipLabel)
				{
					for (int num36 = 0; num36 < mpFlist.Count; num36++)
					{
						bool flag = true;
						if (mpSignIndex != null)
						{
							for (int num37 = 0; num37 < mpSignIndex.Count(); num37++)
							{
								if (mIsPriciseImport)
								{
									if (num37 >= 4)
									{
										break;
									}
								}
								else if (num37 >= 2)
								{
									break;
								}
								if (num36 == mpSignIndex[num37])
								{
									flag = false;
									break;
								}
							}
						}
						if (flag)
						{
							int num38 = num22 + (int)(((double)mpFlist[num36].X - num7) / num12) - 2;
							int num39 = num23 + (int)(((double)mpFlist[num36].Y - num6) / num12) - 2;
							string label2 = mpFlist[num36].Label;
							graphics.DrawString(label2, new Font("楷体", 12f, FontStyle.Bold), new SolidBrush(Color.Black), num38 + 10 - 5 - label2.Length * 5, num39 + 30);
						}
					}
				}
				SolidBrush solidBrush6 = new SolidBrush(Color.White);
				Pen pen2 = new Pen(Color.Black, 1f);
				for (int num40 = 0; num40 < mpFlist.Count; num40++)
				{
					float a = mpFlist[num40].A;
					float num41 = 5f;
					float num42 = 10 + num22 + (int)(((double)mpFlist[num40].X - num7) / num12) + 4;
					float num43 = 10 + num23 + (int)(((double)mpFlist[num40].Y - num6) / num12) + 4;
					double num44 = ((double)(num41 * 2f) * Math.Cos((double)a * 3.1415926 / 180.0) + (double)num41 * Math.Sin((double)a * 3.1415926 / 180.0)) / 2.0;
					double num45 = ((double)(num41 * 2f) * Math.Sin((double)a * 3.1415926 / 180.0) - (double)num41 * Math.Cos((double)a * 3.1415926 / 180.0)) / 2.0;
					double num46 = 0.0 - num44;
					double num47 = 0.0 - num45;
					double num48 = ((double)(num41 * 2f) * Math.Cos((double)a * 3.1415926 / 180.0) - (double)num41 * Math.Sin((double)a * 3.1415926 / 180.0)) / 2.0;
					double num49 = ((double)(num41 * 2f) * Math.Sin((double)a * 3.1415926 / 180.0) + (double)num41 * Math.Cos((double)a * 3.1415926 / 180.0)) / 2.0;
					double num50 = 0.0 - num48;
					double num51 = 0.0 - num49;
					mpFlist[num40].pix.X = (int)((num44 + num48 + num46 + num50) / 4.0 + (double)num42 + 0.5);
					mpFlist[num40].pix.Y = (int)((num45 + num49 + num47 + num51) / 4.0 + (double)num43 + 0.5);
					Point[] points = new Point[4]
					{
						new Point((int)(num44 + (double)num42 + 0.5), (int)(num45 + (double)num43 + 0.5)),
						new Point((int)(num48 + (double)num42 + 0.5), (int)(num49 + (double)num43 + 0.5)),
						new Point((int)(num46 + (double)num42 + 0.5), (int)(num47 + (double)num43 + 0.5)),
						new Point((int)(num50 + (double)num42 + 0.5), (int)(num51 + (double)num43 + 0.5))
					};
					graphics.FillPolygon(solidBrush6, points);
				}
				pen.Dispose();
				pen2.Dispose();
				solidBrush.Dispose();
				solidBrush6.Dispose();
				graphics.Dispose();
				if (!mIsGotoCenter)
				{
					mIsGotoCenter = true;
					panel_outArea.AutoScrollPosition = new Point(1505, 1160);
				}
			}
			catch (Exception)
			{
			}
		}

		private void panel_inArea_Paint(object sender, PaintEventArgs e)
		{
			flush_paint();
		}

		private void panel_inArea_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && (mModeS == "import" || mModeS == "import_debug"))
			{
				mCurPoint.X = e.X;
				mCurPoint.Y = e.Y;
				contextMenuStrip_SetSign.Show(panel_inArea, new Point(e.X, e.Y));
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			mIsDisplay_ChipLabel = checkBox1.Checked;
			flush_paint();
		}
	}
}
