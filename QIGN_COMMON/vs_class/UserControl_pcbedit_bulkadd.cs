using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.Properties;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_pcbedit_bulkadd : UserControl
	{
		private IContainer components;

		private TableLayoutPanel tableLayoutPanel_bulkAddChips;

		private Panel panel1;

		private Label label27;

		private Label label26;

		private Label label25;

		private Button button_bulkchips_gotoxy;

		private Button button_bulkchips_run;

		private Button button_bulkchips_savexy;

		private Panel panel51;

		private Panel panel60;

		private Label label_bulkchips_xy3;

		private Label label_bulkchips_xy1;

		private Label label_bulkchips_xy2;

		private Label label_bulkchips_xy0;

		private NumericUpDown numericUpDown_bulkchips_row;

		private NumericUpDown numericUpDown_bulkchips_col;

		private Button button_bulkchips_close;

		public Label[] lb_bulkChipsXY;

		public Coordinate[] mBulkChipsXY;

		public int mBulkChipsIndex;

		public BindingList<ChipBoardElement> mSelectedList;

		public DataGridView dataGridView_pcbedit;

		public USR_DATA USR;

		public USR3_DATA USR3;

		private USR_INIT_DATA USR_INIT;

		public event void_Func_XY vsplus_pcbedit_gotoxy;

		public event void_Func_int_bool PCBE_List_Show;

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
			tableLayoutPanel_bulkAddChips = new System.Windows.Forms.TableLayoutPanel();
			panel1 = new System.Windows.Forms.Panel();
			button_bulkchips_gotoxy = new System.Windows.Forms.Button();
			button_bulkchips_run = new System.Windows.Forms.Button();
			button_bulkchips_savexy = new System.Windows.Forms.Button();
			panel51 = new System.Windows.Forms.Panel();
			panel60 = new System.Windows.Forms.Panel();
			label_bulkchips_xy3 = new System.Windows.Forms.Label();
			label_bulkchips_xy1 = new System.Windows.Forms.Label();
			label_bulkchips_xy2 = new System.Windows.Forms.Label();
			label_bulkchips_xy0 = new System.Windows.Forms.Label();
			numericUpDown_bulkchips_row = new System.Windows.Forms.NumericUpDown();
			numericUpDown_bulkchips_col = new System.Windows.Forms.NumericUpDown();
			button_bulkchips_close = new System.Windows.Forms.Button();
			label27 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			tableLayoutPanel_bulkAddChips.SuspendLayout();
			panel1.SuspendLayout();
			panel51.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_bulkchips_row).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_bulkchips_col).BeginInit();
			SuspendLayout();
			tableLayoutPanel_bulkAddChips.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
			tableLayoutPanel_bulkAddChips.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel_bulkAddChips.ColumnCount = 1;
			tableLayoutPanel_bulkAddChips.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel_bulkAddChips.Controls.Add(panel1, 0, 0);
			tableLayoutPanel_bulkAddChips.Location = new System.Drawing.Point(3, 3);
			tableLayoutPanel_bulkAddChips.Name = "tableLayoutPanel_bulkAddChips";
			tableLayoutPanel_bulkAddChips.RowCount = 1;
			tableLayoutPanel_bulkAddChips.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel_bulkAddChips.Size = new System.Drawing.Size(692, 168);
			tableLayoutPanel_bulkAddChips.TabIndex = 0;
			panel1.Controls.Add(button_bulkchips_gotoxy);
			panel1.Controls.Add(button_bulkchips_run);
			panel1.Controls.Add(button_bulkchips_savexy);
			panel1.Controls.Add(panel51);
			panel1.Controls.Add(numericUpDown_bulkchips_row);
			panel1.Controls.Add(numericUpDown_bulkchips_col);
			panel1.Controls.Add(button_bulkchips_close);
			panel1.Controls.Add(label27);
			panel1.Controls.Add(label26);
			panel1.Controls.Add(label25);
			panel1.Location = new System.Drawing.Point(6, 6);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(680, 156);
			panel1.TabIndex = 0;
			button_bulkchips_gotoxy.BackColor = System.Drawing.Color.PowderBlue;
			button_bulkchips_gotoxy.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_bulkchips_gotoxy.Location = new System.Drawing.Point(575, 29);
			button_bulkchips_gotoxy.Name = "button_bulkchips_gotoxy";
			button_bulkchips_gotoxy.Size = new System.Drawing.Size(59, 60);
			button_bulkchips_gotoxy.TabIndex = 11;
			button_bulkchips_gotoxy.Text = "定位";
			button_bulkchips_gotoxy.UseVisualStyleBackColor = false;
			button_bulkchips_gotoxy.Click += new System.EventHandler(button_bulkchips_gotoxy_Click);
			button_bulkchips_run.BackColor = System.Drawing.Color.PeachPuff;
			button_bulkchips_run.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_bulkchips_run.Location = new System.Drawing.Point(511, 102);
			button_bulkchips_run.Name = "button_bulkchips_run";
			button_bulkchips_run.Size = new System.Drawing.Size(123, 52);
			button_bulkchips_run.TabIndex = 12;
			button_bulkchips_run.Text = "开始阵列元件";
			button_bulkchips_run.UseVisualStyleBackColor = false;
			button_bulkchips_run.Click += new System.EventHandler(button_bulkchips_run_Click);
			button_bulkchips_savexy.BackColor = System.Drawing.Color.PowderBlue;
			button_bulkchips_savexy.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_bulkchips_savexy.Location = new System.Drawing.Point(510, 29);
			button_bulkchips_savexy.Name = "button_bulkchips_savexy";
			button_bulkchips_savexy.Size = new System.Drawing.Size(59, 60);
			button_bulkchips_savexy.TabIndex = 13;
			button_bulkchips_savexy.Text = "保存";
			button_bulkchips_savexy.UseVisualStyleBackColor = false;
			button_bulkchips_savexy.Click += new System.EventHandler(button_bulkchips_savexy_Click);
			panel51.BackColor = System.Drawing.Color.LightSteelBlue;
			panel51.Controls.Add(panel60);
			panel51.Controls.Add(label_bulkchips_xy3);
			panel51.Controls.Add(label_bulkchips_xy1);
			panel51.Controls.Add(label_bulkchips_xy2);
			panel51.Controls.Add(label_bulkchips_xy0);
			panel51.Location = new System.Drawing.Point(113, 29);
			panel51.Name = "panel51";
			panel51.Size = new System.Drawing.Size(392, 125);
			panel51.TabIndex = 10;
			panel60.BackgroundImage = QIGN_COMMON.Properties.Resources.bulkchips;
			panel60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel60.Location = new System.Drawing.Point(70, 0);
			panel60.Name = "panel60";
			panel60.Size = new System.Drawing.Size(252, 124);
			panel60.TabIndex = 2;
			label_bulkchips_xy3.BackColor = System.Drawing.Color.LightGray;
			label_bulkchips_xy3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_bulkchips_xy3.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_bulkchips_xy3.Location = new System.Drawing.Point(324, 82);
			label_bulkchips_xy3.Name = "label_bulkchips_xy3";
			label_bulkchips_xy3.Size = new System.Drawing.Size(66, 42);
			label_bulkchips_xy3.TabIndex = 1;
			label_bulkchips_xy3.Text = "X00000\r\nY00000";
			label_bulkchips_xy3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bulkchips_xy1.BackColor = System.Drawing.Color.LightGray;
			label_bulkchips_xy1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_bulkchips_xy1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_bulkchips_xy1.Location = new System.Drawing.Point(324, 0);
			label_bulkchips_xy1.Name = "label_bulkchips_xy1";
			label_bulkchips_xy1.Size = new System.Drawing.Size(66, 42);
			label_bulkchips_xy1.TabIndex = 1;
			label_bulkchips_xy1.Text = "X00000\r\nY00000";
			label_bulkchips_xy1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bulkchips_xy2.BackColor = System.Drawing.Color.LightGray;
			label_bulkchips_xy2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_bulkchips_xy2.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_bulkchips_xy2.Location = new System.Drawing.Point(2, 80);
			label_bulkchips_xy2.Name = "label_bulkchips_xy2";
			label_bulkchips_xy2.Size = new System.Drawing.Size(66, 42);
			label_bulkchips_xy2.TabIndex = 1;
			label_bulkchips_xy2.Text = "X00000\r\nY00000";
			label_bulkchips_xy2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bulkchips_xy0.BackColor = System.Drawing.Color.White;
			label_bulkchips_xy0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_bulkchips_xy0.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_bulkchips_xy0.Location = new System.Drawing.Point(1, 2);
			label_bulkchips_xy0.Name = "label_bulkchips_xy0";
			label_bulkchips_xy0.Size = new System.Drawing.Size(66, 42);
			label_bulkchips_xy0.TabIndex = 1;
			label_bulkchips_xy0.Text = "X00000\r\nY00000";
			label_bulkchips_xy0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_bulkchips_row.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_bulkchips_row.Location = new System.Drawing.Point(53, 88);
			numericUpDown_bulkchips_row.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_bulkchips_row.Name = "numericUpDown_bulkchips_row";
			numericUpDown_bulkchips_row.Size = new System.Drawing.Size(56, 26);
			numericUpDown_bulkchips_row.TabIndex = 8;
			numericUpDown_bulkchips_row.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_bulkchips_col.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_bulkchips_col.Location = new System.Drawing.Point(53, 41);
			numericUpDown_bulkchips_col.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_bulkchips_col.Name = "numericUpDown_bulkchips_col";
			numericUpDown_bulkchips_col.Size = new System.Drawing.Size(56, 26);
			numericUpDown_bulkchips_col.TabIndex = 9;
			numericUpDown_bulkchips_col.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			button_bulkchips_close.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			button_bulkchips_close.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
			button_bulkchips_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_bulkchips_close.Location = new System.Drawing.Point(645, 4);
			button_bulkchips_close.Name = "button_bulkchips_close";
			button_bulkchips_close.Size = new System.Drawing.Size(32, 32);
			button_bulkchips_close.TabIndex = 7;
			button_bulkchips_close.Text = "X";
			button_bulkchips_close.UseVisualStyleBackColor = true;
			button_bulkchips_close.Click += new System.EventHandler(button_bulkchips_close_Click);
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label27.Location = new System.Drawing.Point(13, 45);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(40, 16);
			label27.TabIndex = 5;
			label27.Text = "列数";
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label26.Location = new System.Drawing.Point(13, 89);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(40, 16);
			label26.TabIndex = 6;
			label26.Text = "行数";
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label25.Location = new System.Drawing.Point(3, 4);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(129, 19);
			label25.TabIndex = 4;
			label25.Text = "批量阵列元件";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(tableLayoutPanel_bulkAddChips);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_pcbedit_bulkadd";
			base.Size = new System.Drawing.Size(695, 174);
			tableLayoutPanel_bulkAddChips.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel51.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDown_bulkchips_row).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_bulkchips_col).EndInit();
			ResumeLayout(false);
		}

		public UserControl_pcbedit_bulkadd(USR_DATA usr, USR3_DATA usr3, DataGridView dgv, BindingList<ChipBoardElement> plist)
		{
			InitializeComponent();
			dataGridView_pcbedit = dgv;
			USR = usr;
			USR3 = usr3;
			USR_INIT = MainForm0.USR_INIT;
			mSelectedList = new BindingList<ChipBoardElement>();
			if (plist != null)
			{
				for (int i = 0; i < plist.Count; i++)
				{
					mSelectedList.Add(plist[i]);
				}
			}
			tableLayoutPanel_bulkAddChips.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel_bulkAddChips, true, null);
			tableLayoutPanel_bulkAddChips.SuspendLayout();
			numericUpDown_bulkchips_col.Value = 1m;
			numericUpDown_bulkchips_row.Value = 1m;
			lb_bulkChipsXY = new Label[4] { label_bulkchips_xy0, label_bulkchips_xy1, label_bulkchips_xy2, label_bulkchips_xy3 };
			mBulkChipsIndex = 0;
			mBulkChipsXY = new Coordinate[4];
			for (int j = 0; j < 4; j++)
			{
				mBulkChipsXY[j] = new Coordinate(10000 + j % 2 * 20000, 10000 + j / 2 * 20000);
				lb_bulkChipsXY[j].BackColor = ((j == mBulkChipsIndex) ? Color.White : Color.LightGray);
				lb_bulkChipsXY[j].Click += label_bulkchips_xy_Click;
				lb_bulkChipsXY[j].DoubleClick += label_bulkchips_xy_DoubleClick;
				lb_bulkChipsXY[j].Tag = j;
				lb_bulkChipsXY[j].Text = "X" + mBulkChipsXY[j].X.ToString("D5") + Environment.NewLine + "Y" + mBulkChipsXY[j].Y.ToString("D5");
			}
		}

		private void button_bulkchips_close_Click(object sender, EventArgs e)
		{
			dataGridView_pcbedit.Enabled = true;
			Dispose();
		}

		private void label_bulkchips_xy_Click(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			lb_bulkChipsXY[mBulkChipsIndex].BackColor = Color.LightGray;
			mBulkChipsIndex = (int)label.Tag;
			lb_bulkChipsXY[mBulkChipsIndex].BackColor = Color.White;
		}

		private void label_bulkchips_xy_DoubleClick(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			lb_bulkChipsXY[mBulkChipsIndex].BackColor = Color.LightGray;
			mBulkChipsIndex = (int)label.Tag;
			lb_bulkChipsXY[mBulkChipsIndex].BackColor = Color.White;
			Form_FillXY form_FillXY = new Form_FillXY(mBulkChipsXY[mBulkChipsIndex], USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				mBulkChipsXY[mBulkChipsIndex].X = fillXY.X;
				mBulkChipsXY[mBulkChipsIndex].Y = fillXY.Y;
				lb_bulkChipsXY[mBulkChipsIndex].Text = MainForm0.format_XY_label_string(mBulkChipsXY[mBulkChipsIndex]);
			}
		}

		private void button_bulkchips_savexy_Click(object sender, EventArgs e)
		{
			string[] array = new string[4] { "左上", "右上", "左下", "右下" };
			string[] array2 = new string[4] { "Left-Up", "Right-Up", "Left-Down", "Right-Downs" };
			string text = "您确定修改" + array[mBulkChipsIndex] + "角的坐标吗？";
			string text2 = "Are you going to update " + array2[mBulkChipsIndex] + "Corner XY？";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text2 : text, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				mBulkChipsXY[mBulkChipsIndex].X = MainForm0.mCur[MainForm0.mFn].x;
				mBulkChipsXY[mBulkChipsIndex].Y = MainForm0.mCur[MainForm0.mFn].y;
				lb_bulkChipsXY[mBulkChipsIndex].Text = MainForm0.format_XY_label_string(mBulkChipsXY[mBulkChipsIndex]);
			}
		}

		private void button_bulkchips_gotoxy_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[MainForm0.mFn].switch_to_cam(CameraType.Mark);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(mBulkChipsXY[mBulkChipsIndex]);
			}
		}

		private void button_bulkchips_run_Click(object sender, EventArgs e)
		{
			if (mSelectedList != null && mSelectedList.Count > 0 && (numericUpDown_bulkchips_col.Value > 1m || numericUpDown_bulkchips_row.Value > 1m))
			{
				int num = MainForm0.get_max_importno(USR3.mPointlist);
				dataGridView_pcbedit.DataSource = null;
				int num2 = (int)numericUpDown_bulkchips_col.Value;
				int num3 = (int)numericUpDown_bulkchips_row.Value;
				int count = mSelectedList.Count;
				int num4 = 1;
				if (USR3.mPointlistSmt != null && USR3.mPointlistSmt.Count > 0)
				{
					num4 = USR3.mPointlistSmt[USR3.mPointlistSmt.Count - 1].Group + 1;
				}
				int num5 = 99999;
				for (int i = 0; i < mSelectedList.Count; i++)
				{
					if (mSelectedList[i].Group < num5)
					{
						num5 = mSelectedList[i].Group;
					}
				}
				int num6 = mSelectedList.Count;
				for (int j = 0; j < mSelectedList.Count; j++)
				{
					for (int k = j + 1; k < mSelectedList.Count; k++)
					{
						if (mSelectedList[j].Group == mSelectedList[k].Group)
						{
							num6--;
						}
					}
				}
				BindingList<ChipBoardElement> bindingList = new BindingList<ChipBoardElement>();
				for (int l = 0; l < num3; l++)
				{
					for (int m = 0; m < num2; m++)
					{
						if (l == 0 && m == 0)
						{
							continue;
						}
						for (int n = 0; n < count; n++)
						{
							Coordinate coordinate = new Coordinate(0L, 0L);
							Coordinate coordinate2 = new Coordinate(0L, 0L);
							Coordinate coordinate3 = new Coordinate(0L, 0L);
							if (num3 == 1)
							{
								coordinate.X = mBulkChipsXY[0].X;
								coordinate.Y = mBulkChipsXY[0].Y;
								coordinate3.X = mBulkChipsXY[1].X;
								coordinate3.Y = mBulkChipsXY[1].Y;
							}
							else
							{
								coordinate.X = mBulkChipsXY[0].X + (mBulkChipsXY[2].X - mBulkChipsXY[0].X) * l / (num3 - 1);
								coordinate.Y = mBulkChipsXY[0].Y + (mBulkChipsXY[2].Y - mBulkChipsXY[0].Y) * l / (num3 - 1);
								coordinate3.X = mBulkChipsXY[1].X + (mBulkChipsXY[3].X - mBulkChipsXY[1].X) * l / (num3 - 1);
								coordinate3.Y = mBulkChipsXY[1].Y + (mBulkChipsXY[3].Y - mBulkChipsXY[1].Y) * l / (num3 - 1);
							}
							if (num2 == 1)
							{
								coordinate2.X = 0L;
								coordinate2.Y = 0L;
							}
							else
							{
								coordinate2.X = (coordinate3.X - coordinate.X) * m / (num2 - 1);
								coordinate2.Y = (coordinate3.Y - coordinate.Y) * m / (num2 - 1);
							}
							ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage, Guid.NewGuid().ToString());
							MainForm0.Copy_ChipBoardElement(chipBoardElement, mSelectedList[n], 0, isguid: true);
							chipBoardElement.Labeltab = "";
							chipBoardElement.Footprint = mSelectedList[n].Footprint;
							chipBoardElement.Ismount = mSelectedList[n].Ismount;
							chipBoardElement.Labeltab = mSelectedList[n].Labeltab;
							chipBoardElement.Material_value = mSelectedList[n].Material_value;
							chipBoardElement.A = mSelectedList[n].A;
							chipBoardElement.X = mSelectedList[n].X + coordinate.X - mBulkChipsXY[0].X + coordinate2.X;
							chipBoardElement.Y = mSelectedList[n].Y + coordinate.Y - mBulkChipsXY[0].Y + coordinate2.Y;
							chipBoardElement.Arrayno_S = "1-1";
							chipBoardElement.Arrayno = 0;
							chipBoardElement.Group = num4 + mSelectedList[n].Group - num5 + num6 * (l * num2 + m);
							chipBoardElement.Guid = mSelectedList[n].Guid;
							chipBoardElement.ImportNo = num + 1;
							bindingList.Add(chipBoardElement);
						}
					}
				}
				int num7 = 0;
				for (int num8 = 0; num8 < USR3.mPointlist.Count; num8++)
				{
					if (USR3.mPointlist[num8].Arrayno == 0)
					{
						num7++;
					}
				}
				if (USR3.mArrayPCBColumn * USR3.mArrayPCBRow > 1)
				{
					for (int num9 = 0; num9 < bindingList.Count; num9++)
					{
						USR3.mPointlist.Insert(num7 + num9, bindingList[num9]);
					}
				}
				else
				{
					for (int num10 = 0; num10 < bindingList.Count; num10++)
					{
						USR3.mPointlist.Add(bindingList[num10]);
					}
				}
				for (int num11 = 0; num11 < bindingList.Count; num11++)
				{
					USR3.mPointlistSmt.Add(bindingList[num11]);
				}
				USR3.mPointListOrder = 0;
				MainForm0.pcbsmt_refresh_groups(USR3);
				if (this.PCBE_List_Show != null)
				{
					this.PCBE_List_Show(USR3.mPointListOrder, b: true);
				}
				if (num7 > 0)
				{
					dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = num7 - 1;
					for (int num12 = 0; num12 < count * (num3 * num2 - 1); num12++)
					{
						dataGridView_pcbedit.Rows[num7 + num12].Selected = true;
					}
				}
			}
			dataGridView_pcbedit.Enabled = true;
			Dispose();
		}
	}
}
