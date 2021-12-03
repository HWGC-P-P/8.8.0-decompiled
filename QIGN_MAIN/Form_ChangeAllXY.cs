using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON;

namespace QIGN_MAIN
{
	public class Form_ChangeAllXY : Form
	{
		private IContainer components;

		private NumericUpDown numericUpDown_X;

		private NumericUpDown numericUpDown_Y;

		private Label label1;

		private Label label2;

		private Panel panel1;

		private Label label3;

		private Button button_OK;

		private Button button_Cancel;

		private Label label4;

		private Label label5;

		private NumericUpDown numericUpDown_A;

		private BindingList<ChipBoardElement> mPointList;

		private BindingList<int> mSel_List;

		private int mLanguage;

		private bool mIsPcbCheck;

		private USR3_DATA USR3;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		public static string[][] Title1 = new string[2][]
		{
			new string[3] { "选中的元件", "选中的元件", "For Selected Chips" },
			new string[3] { "所有的元件", "所有的元件", "For All Chips" }
		};

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
			numericUpDown_X = new System.Windows.Forms.NumericUpDown();
			numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			numericUpDown_A = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			button_OK = new System.Windows.Forms.Button();
			button_Cancel = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)numericUpDown_X).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_Y).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_A).BeginInit();
			SuspendLayout();
			numericUpDown_X.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_X.Location = new System.Drawing.Point(108, 10);
			numericUpDown_X.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			numericUpDown_X.Maximum = new decimal(new int[4] { 50000, 0, 0, 0 });
			numericUpDown_X.Minimum = new decimal(new int[4] { 50000, 0, 0, -2147483648 });
			numericUpDown_X.Name = "numericUpDown_X";
			numericUpDown_X.Size = new System.Drawing.Size(119, 26);
			numericUpDown_X.TabIndex = 0;
			numericUpDown_Y.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_Y.Location = new System.Drawing.Point(108, 45);
			numericUpDown_Y.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			numericUpDown_Y.Maximum = new decimal(new int[4] { 50000, 0, 0, 0 });
			numericUpDown_Y.Minimum = new decimal(new int[4] { 50000, 0, 0, -2147483648 });
			numericUpDown_Y.Name = "numericUpDown_Y";
			numericUpDown_Y.Size = new System.Drawing.Size(119, 26);
			numericUpDown_Y.TabIndex = 0;
			label1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(10, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(96, 20);
			label1.TabIndex = 1;
			label1.Text = "X坐标搬移量";
			label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label2.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(11, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(96, 20);
			label2.TabIndex = 1;
			label2.Text = "Y坐标搬移量";
			label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			panel1.BackColor = System.Drawing.Color.NavajoWhite;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Controls.Add(numericUpDown_A);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(numericUpDown_Y);
			panel1.Controls.Add(numericUpDown_X);
			panel1.Location = new System.Drawing.Point(31, 72);
			panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(444, 129);
			panel1.TabIndex = 2;
			numericUpDown_A.DecimalPlaces = 2;
			numericUpDown_A.Font = new System.Drawing.Font("楷体", 12f);
			numericUpDown_A.Location = new System.Drawing.Point(107, 80);
			numericUpDown_A.Maximum = new decimal(new int[4] { 180, 0, 0, 0 });
			numericUpDown_A.Minimum = new decimal(new int[4] { 180, 0, 0, -2147483648 });
			numericUpDown_A.Name = "numericUpDown_A";
			numericUpDown_A.Size = new System.Drawing.Size(120, 26);
			numericUpDown_A.TabIndex = 2;
			label5.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label5.Location = new System.Drawing.Point(11, 84);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(96, 20);
			label5.TabIndex = 1;
			label5.Text = "A角度搬移量";
			label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label3.Font = new System.Drawing.Font("楷体", 14.25f);
			label3.Location = new System.Drawing.Point(27, 9);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(433, 21);
			label3.TabIndex = 1;
			label3.Text = "XY坐标和A角度整体搬移";
			button_OK.Location = new System.Drawing.Point(102, 205);
			button_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(101, 28);
			button_OK.TabIndex = 3;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = true;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			button_Cancel.Location = new System.Drawing.Point(285, 205);
			button_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(101, 28);
			button_Cancel.TabIndex = 3;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = true;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.OrangeRed;
			label4.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.ForeColor = System.Drawing.Color.Black;
			label4.Location = new System.Drawing.Point(28, 42);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(109, 19);
			label4.TabIndex = 4;
			label4.Text = "选中的元件";
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.PapayaWhip;
			base.ClientSize = new System.Drawing.Size(500, 244);
			base.Controls.Add(label4);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(button_OK);
			base.Controls.Add(panel1);
			base.Controls.Add(label3);
			Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form_ChangeAllXY";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_ChangeAllXY_Load);
			((System.ComponentModel.ISupportInitialize)numericUpDown_X).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_Y).EndInit();
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDown_A).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_ChangeAllXY(int language, USR3_DATA usr3, BindingList<ChipBoardElement> pointlist, BindingList<int> sel_list, bool is_pcbcheck)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mLanguage = language;
			initLanguageTable();
			updateLanguage(mLanguage);
			USR3 = usr3;
			mPointList = pointlist;
			mSel_List = sel_list;
			mIsPcbCheck = is_pcbcheck;
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			string text = "The operation will modified XY of all items, and cannot be recovery. Still confinue";
			string text2 = "整体搬移会修改所有的或者选中的XY坐标和A角度，并且不可恢复，是否操作？";
			if (MainForm0.CmMessageBox((mLanguage == 2) ? text : text2, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (mPointList != null)
				{
					int num = (int)numericUpDown_X.Value;
					int num2 = (int)numericUpDown_Y.Value;
					float num3 = (float)numericUpDown_A.Value;
					if (mSel_List == null || mSel_List.Count <= 0)
					{
						for (int i = 0; i < mPointList.Count; i++)
						{
							if (mIsPcbCheck)
							{
								mPointList[i].X_Real += num;
								mPointList[i].Y_Real += num2;
								mPointList[i].A_Real += num3;
								Coordinate coordinate = MainForm0.uc_job[MainForm0.mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(mPointList[i].X_Real, mPointList[i].Y_Real));
								mPointList[i].X = coordinate.X;
								mPointList[i].Y = coordinate.Y;
								mPointList[i].A = mPointList[i].A_Real + (float)(MainForm0.uc_job[MainForm0.mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
							}
							else
							{
								mPointList[i].X += num;
								mPointList[i].Y += num2;
								mPointList[i].A += num3;
							}
						}
					}
					else
					{
						for (int j = 0; j < mSel_List.Count; j++)
						{
							if (mIsPcbCheck)
							{
								mPointList[mSel_List[j]].X_Real += num;
								mPointList[mSel_List[j]].Y_Real += num2;
								mPointList[mSel_List[j]].A_Real += num3;
								Coordinate coordinate2 = MainForm0.uc_job[MainForm0.mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(mPointList[mSel_List[j]].X_Real, mPointList[mSel_List[j]].Y_Real));
								mPointList[mSel_List[j]].X = coordinate2.X;
								mPointList[mSel_List[j]].Y = coordinate2.Y;
								mPointList[mSel_List[j]].A = mPointList[mSel_List[j]].A_Real + (float)(MainForm0.uc_job[MainForm0.mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
							}
							else
							{
								mPointList[mSel_List[j]].X += num;
								mPointList[mSel_List[j]].Y += num2;
								mPointList[mSel_List[j]].A += num3;
							}
						}
					}
				}
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
			}
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
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
					mLanguage2.ctrl.Font = new Font(DEF.FONT_2020[mLanguage], mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
					break;
				}
			}
		}

		private void initLanguageTable()
		{
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "XY坐标和A角度整体搬移", "XY坐标和A角度整体搬移", "XY and A Set Offset" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "X坐标搬移量", "X坐标搬移量", "X Offset" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "Y坐标搬移量", "Y坐标搬移量", "Y Offset" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "A角度搬移量", "A角度搬移量", "A Offset" }
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
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "", "", "" }
			});
		}

		private void Form_ChangeAllXY_Load(object sender, EventArgs e)
		{
			if (mSel_List == null || mSel_List.Count <= 0)
			{
				label4.Text = Title1[1][mLanguage];
			}
			else
			{
				label4.Text = Title1[0][mLanguage] + " (";
				int num = Math.Min(5, mSel_List.Count);
				for (int i = 0; i < num; i++)
				{
					Label label = label4;
					label.Text = label.Text + mPointList[mSel_List[i]].Labeltab + ((i != num - 1) ? "," : "...)");
				}
			}
			if (mIsPcbCheck)
			{
				BackColor = Color.LightBlue;
				panel1.BackColor = Color.AliceBlue;
			}
		}
	}
}
