using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_CamDistortionPara : Form
	{
		public USR_DATA USR;

		private USR_INIT_DATA USR_INIT;

		public Label label_h_pr;

		private IContainer components;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TabPage tabPage3;

		private Label label1;

		public Form_CamDistortionPara(USR_DATA usr, CameraType cam)
		{
			InitializeComponent();
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			switch (cam)
			{
			case CameraType.Fast:
				tabControl1.SelectedIndex = 1;
				break;
			case CameraType.High:
				tabControl1.SelectedIndex = 2;
				break;
			default:
				tabControl1.SelectedIndex = 0;
				break;
			}
			string[] array = new string[16]
			{
				"xxb", "cdb1", "cdb2", "cdb3", "cdb4", "cdb5", "cdb6", "cdb7", "cdb8", "cdb9",
				"cdb10", "pr", "ca", "coff", "pos-x", "pos-y"
			};
			TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
			tabPage2.Controls.Clear();
			tabPage2.Controls.Add(tableLayoutPanel);
			tableLayoutPanel.Controls.Clear();
			tableLayoutPanel.RowCount = 7;
			tableLayoutPanel.ColumnCount = HW.mZnNum[MainForm0.mFn] + 1;
			tableLayoutPanel.Location = new Point(15, 15);
			int num = 80;
			tableLayoutPanel.Size = new Size(num * HW.mZnNum[MainForm0.mFn] + 60 + 80, tableLayoutPanel.RowCount * 27 + 2);
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
					label.Text = "Cam" + k;
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
						if (l - 1 >= 1)
						{
							label2.Text = array[l - 1 + 10];
						}
						label2.Size = new Size(60, 24);
						label2.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Bold);
						label2.Anchor = AnchorStyles.None;
						label2.TextAlign = ContentAlignment.MiddleLeft;
						continue;
					}
					Label label3 = new Label();
					tableLayoutPanel.Controls.Add(label3, k, l);
					if (l - 1 < 1)
					{
						label3.Text = USR.mFastCamDistortion[k - 1][l - 1].ToString("F4");
					}
					else
					{
						switch (l)
						{
						case 2:
							label3.Text = USR.mFastCamRatio[0][k - 1].ToString("F5");
							break;
						case 3:
							label3.Text = USR.mFastCamRatioExt[0][k - 1].ToString("F5");
							break;
						case 4:
							label3.Text = USR.mFastCamCenterDeltaX[0][k - 1].ToString("F4");
							break;
						case 5:
							label3.Text = USR.mFastCamCenterPosition[0][k - 1].X.ToString();
							break;
						case 6:
							label3.Text = USR.mFastCamCenterPosition[0][k - 1].Y.ToString();
							break;
						}
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
			TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
			tabPage3.Controls.Clear();
			tabPage3.Controls.Add(tableLayoutPanel2);
			tableLayoutPanel2.Controls.Clear();
			tableLayoutPanel2.RowCount = 5;
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.Location = new Point(15, 15);
			int num2 = 80;
			tableLayoutPanel2.Size = new Size(num2 + 60 + 80, tableLayoutPanel2.RowCount * 27 + 2);
			for (int m = 0; m < tableLayoutPanel2.RowCount; m++)
			{
				tableLayoutPanel2.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.AutoSize
				});
			}
			for (int n = 0; n < tableLayoutPanel2.ColumnCount; n++)
			{
				if (n == 0)
				{
					tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
				else
				{
					tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
			}
			tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel2.Refresh();
			for (int num3 = 0; num3 < tableLayoutPanel2.ColumnStyles.Count; num3++)
			{
				if (num3 > 0)
				{
					Label label4 = new Label();
					tableLayoutPanel2.Controls.Add(label4, num3, 0);
					label4.Text = "Cam" + num3;
					label4.Size = new Size(num2, 25);
					label4.AutoSize = false;
					label4.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label4.Anchor = AnchorStyles.None;
					label4.TextAlign = ContentAlignment.MiddleLeft;
				}
				for (int num4 = 1; num4 < tableLayoutPanel2.RowCount; num4++)
				{
					if (num3 == 0)
					{
						Label label5 = new Label();
						tableLayoutPanel2.Controls.Add(label5, num3, num4);
						label5.Text = array[num4 - 1];
						if (num4 - 1 >= 1)
						{
							label5.Text = array[num4 - 1 + 10];
						}
						label5.Size = new Size(60, 24);
						label5.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Bold);
						label5.Anchor = AnchorStyles.None;
						label5.TextAlign = ContentAlignment.MiddleLeft;
						continue;
					}
					Label label6 = new Label();
					tableLayoutPanel2.Controls.Add(label6, num3, num4);
					if (num4 - 1 < 1)
					{
						label6.Text = USR.mHighCamDistortion[num4 - 1].ToString("F5");
					}
					else
					{
						switch (num4)
						{
						case 2:
							label6.Text = USR.mHighCamRatio[num3 - 1].ToString("F5");
							label_h_pr = label6;
							label6.DoubleClick += label_h_pr_DoubleClick;
							break;
						case 3:
							label6.Text = USR.mHighCamRatioExt[num3 - 1].ToString("F5");
							break;
						case 4:
							label6.Text = 0.ToString("F4");
							break;
						}
					}
					label6.Size = new Size(num2, 24);
					label6.AutoSize = false;
					label6.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label6.Anchor = AnchorStyles.None;
					label6.TextAlign = ContentAlignment.MiddleLeft;
					label6.Tag = num3 - 1;
					label6.BackColor = Color.White;
					label6.BorderStyle = BorderStyle.None;
				}
			}
			tableLayoutPanel2.BackColor = Color.WhiteSmoke;
			tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
			tableLayoutPanel2.SuspendLayout();
			TableLayoutPanel tableLayoutPanel3 = new TableLayoutPanel();
			tabPage3.Controls.Add(tableLayoutPanel3);
			tableLayoutPanel3.Controls.Clear();
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.ColumnCount = HW.mZnNum[MainForm0.mFn];
			tableLayoutPanel3.Location = new Point(15, 315);
			tableLayoutPanel3.Size = new Size(70 * HW.mZnNum[MainForm0.mFn] + 20, 75);
			tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel3.Refresh();
			tableLayoutPanel3.BackColor = Color.WhiteSmoke;
			for (int num5 = 0; num5 < HW.mZnNum[MainForm0.mFn]; num5++)
			{
				Label label7 = new Label();
				tableLayoutPanel3.Controls.Add(label7, num5, 0);
				label7.Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (num5 + 1);
				label7.Size = new Size(62, 25);
				label7.AutoSize = false;
				label7.Font = new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label7.Anchor = AnchorStyles.None;
				label7.TextAlign = ContentAlignment.MiddleLeft;
				Label label8 = new Label();
				tableLayoutPanel3.Controls.Add(label8, num5, 1);
				label8.Text = MainForm0.format_XY_label_string(USR.mHighCamRecognizeCoord[0][num5]);
				label8.Size = new Size(62, 40);
				label8.AutoSize = false;
				label8.Font = new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label8.Anchor = AnchorStyles.None;
				label8.TextAlign = ContentAlignment.MiddleLeft;
			}
			tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);
			tableLayoutPanel3.SuspendLayout();
			TableLayoutPanel tableLayoutPanel4 = new TableLayoutPanel();
			tabPage1.Controls.Clear();
			tabPage1.Controls.Add(tableLayoutPanel4);
			tableLayoutPanel4.Controls.Clear();
			tableLayoutPanel4.RowCount = 5;
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.Location = new Point(15, 15);
			int num6 = 80;
			tableLayoutPanel4.Size = new Size(num6 + 60 + 80, tableLayoutPanel4.RowCount * 27 + 2);
			for (int num7 = 0; num7 < tableLayoutPanel4.RowCount; num7++)
			{
				tableLayoutPanel4.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.AutoSize
				});
			}
			for (int num8 = 0; num8 < tableLayoutPanel4.ColumnCount; num8++)
			{
				if (num8 == 0)
				{
					tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
				else
				{
					tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
			}
			tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel4.Refresh();
			for (int num9 = 0; num9 < tableLayoutPanel4.ColumnStyles.Count; num9++)
			{
				if (num9 > 0)
				{
					Label label9 = new Label();
					tableLayoutPanel4.Controls.Add(label9, num9, 0);
					label9.Text = "Cam" + num9;
					label9.Size = new Size(num6, 25);
					label9.AutoSize = false;
					label9.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label9.Anchor = AnchorStyles.None;
					label9.TextAlign = ContentAlignment.MiddleLeft;
				}
				for (int num10 = 1; num10 < tableLayoutPanel4.RowCount; num10++)
				{
					if (num9 == 0)
					{
						Label label10 = new Label();
						tableLayoutPanel4.Controls.Add(label10, num9, num10);
						label10.Text = array[num10 - 1];
						if (num10 - 1 >= 1)
						{
							label10.Text = array[num10 - 1 + 10];
						}
						label10.Size = new Size(60, 24);
						label10.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Bold);
						label10.Anchor = AnchorStyles.None;
						label10.TextAlign = ContentAlignment.MiddleLeft;
						continue;
					}
					Label label11 = new Label();
					tableLayoutPanel4.Controls.Add(label11, num9, num10);
					if (num10 - 1 < 1)
					{
						label11.Text = USR.mMarkCamDistortion[num10 - 1].ToString("F5");
					}
					else
					{
						switch (num10)
						{
						case 2:
							label11.Text = USR.mMarkCamRatio[num9 - 1].ToString("F5");
							break;
						case 3:
							label11.Text = 0.ToString("F5");
							break;
						case 4:
							label11.Text = 0.ToString("F4");
							break;
						}
					}
					label11.Size = new Size(num6, 24);
					label11.AutoSize = false;
					label11.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
					label11.Anchor = AnchorStyles.None;
					label11.TextAlign = ContentAlignment.MiddleLeft;
					label11.Tag = num9 - 1;
					label11.BackColor = Color.White;
					label11.BorderStyle = BorderStyle.None;
				}
			}
			tableLayoutPanel4.BackColor = Color.WhiteSmoke;
			tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel4.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel4, true, null);
			tableLayoutPanel4.SuspendLayout();
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "相机校准参数查看", "相機校準參數查看", "Camera Calibration Para View" }
			});
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabControl1
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage1,
				str = new string[3] { "Mark相机", "Mark相機", "Mark Cam" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage2,
				str = new string[3] { "快速相机", "快速相機", "Fast Cam" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage3,
				str = new string[3] { "高清相机", "高清相機", "High Cam" }
			});
			return list;
		}

		private void label_h_pr_DoubleClick(object sender, EventArgs e)
		{
			_ = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mHighCamRatio[0], USR_INIT.mLanguage, "V_F", 0f, 20f, "");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mHighCamRatio[0] = form_FillXY.Get_Fill_V_F();
				label_h_pr.Text = USR.mHighCamRatio[0].ToString("F5");
			}
		}

		private void Form_CamDistortionPara_Load(object sender, EventArgs e)
		{
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
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
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			tabPage3 = new System.Windows.Forms.TabPage();
			label1 = new System.Windows.Forms.Label();
			tabControl1.SuspendLayout();
			SuspendLayout();
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Location = new System.Drawing.Point(12, 31);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(827, 541);
			tabControl1.TabIndex = 1;
			tabPage1.Location = new System.Drawing.Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(819, 513);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Mark相机";
			tabPage1.UseVisualStyleBackColor = true;
			tabPage2.Location = new System.Drawing.Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(819, 513);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "快速相机";
			tabPage2.UseVisualStyleBackColor = true;
			tabPage3.Location = new System.Drawing.Point(4, 24);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new System.Windows.Forms.Padding(3);
			tabPage3.Size = new System.Drawing.Size(819, 513);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "高清相机";
			tabPage3.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14.25f);
			label1.Location = new System.Drawing.Point(326, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(169, 19);
			label1.TabIndex = 2;
			label1.Text = "相机校准参数查看";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(851, 584);
			base.Controls.Add(label1);
			base.Controls.Add(tabControl1);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_CamDistortionPara";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_CamDistortionPara_Load);
			tabControl1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
