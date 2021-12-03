using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_datacatcat : Form
	{
		private IContainer components;

		private Label label1;

		private CnButton cnButton_toLeft;

		private CnButton cnButton_toRight;

		private BindingList<ChipCategoryElement>[] mCatLists;

		private DataGridView[] datagridviews_pcbcat;

		private Label[] label_num;

		private int[] mLeadingCurIndex;

		public static HeadString_St[] CAT_HEAD = new HeadString_St[29]
		{
			new HeadString_St(STR.CHIP_VALUE, new int[3] { 76, 76, 76 }),
			new HeadString_St(STR.CHIP_PRINTFOOT, new int[3] { 70, 70, 70 }),
			new HeadString_St(STR.COUNT, new int[3] { 44, 44, 44 }),
			new HeadString_St(STR.PROVIDER, new int[3] { 56, 56, 56 }),
			new HeadString_St(STR.STACK_NO, new int[3] { 120, 120, 120 }),
			new HeadString_St(STR.MULTI_FEEDER, new int[3] { 50, 50, 50 }),
			new HeadString_St(STR.NOZZLE_a, new int[3] { 50, 50, 50 }),
			new HeadString_St(STR.NOZZLE_a, new int[3] { 50, 50, 50 }),
			new HeadString_St(STR.SAMEPIK_DELTA, new int[3] { 60, 60, 60 }),
			new HeadString_St(STR.CAMERA, new int[3] { 64, 64, 64 }),
			new HeadString_St(STR.VISUAL, new int[3] { 68, 68, 68 }),
			new HeadString_St(new string[3] { "识别模式", "识别模式", "Loop Mode" }, new int[3] { 50, 50, 50 }),
			new HeadString_St(STR.LOW_SPEED, new int[3] { 50, 50, 50 }),
			new HeadString_St(STR.SCAN_R, new int[3] { 44, 44, 44 }),
			new HeadString_St(STR.THRESHOLD, new int[3] { 44, 44, 44 }),
			new HeadString_St(STR.L_b, new int[3] { 60, 60, 60 }),
			new HeadString_St(STR.W_b, new int[3] { 60, 60, 60 }),
			new HeadString_St(STR.H_b, new int[3] { 60, 60, 60 }),
			new HeadString_St(new string[3] { "特征识别", "特征识别", "Size Rec" }, new int[3] { 44, 44, 44 }),
			new HeadString_St(new string[3] { "识别容差", "识别容差", "Size Rec Rate" }, new int[3] { 44, 44, 44 }),
			new HeadString_St(new string[3] { "取料下压缓冲", "取料下压缓冲", "Pik H Offset" }, new int[3] { 60, 60, 60 }),
			new HeadString_St(new string[3] { "取料上拉速度", "取料上拉速度", "Pik Up Speed" }, new int[3] { 60, 60, 60 }),
			new HeadString_St(new string[3] { "取料下伸速度", "取料下伸速度", "Pik Down Speed" }, new int[3] { 60, 60, 60 }),
			new HeadString_St(STR.PIK_DLY, new int[3] { 44, 44, 44 }),
			new HeadString_St(new string[3] { "贴装下压缓冲", "贴装下压缓冲", "Mnt H Offset" }, new int[3] { 60, 60, 60 }),
			new HeadString_St(new string[3] { "贴装上拉速度", "贴装上拉速度", "Mnt Up Speed" }, new int[3] { 60, 60, 60 }),
			new HeadString_St(new string[3] { "贴装下伸速度", "贴装下伸速度", "Mnt Up Speed" }, new int[3] { 60, 60, 60 }),
			new HeadString_St(STR.MNT_DLY, new int[3] { 44, 44, 44 }),
			new HeadString_St(STR.IS_HIGH, new int[3] { 44, 44, 44 })
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
			label1 = new System.Windows.Forms.Label();
			cnButton_toLeft = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_toRight = new QIGN_COMMON.vs_acontrol.CnButton();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 18f);
			label1.Location = new System.Drawing.Point(33, 29);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(106, 24);
			label1.TabIndex = 4;
			label1.Text = "数据整理";
			cnButton_toLeft.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_toLeft.CnPressDownColor = System.Drawing.Color.White;
			cnButton_toLeft.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			cnButton_toLeft.Location = new System.Drawing.Point(584, 358);
			cnButton_toLeft.Name = "cnButton_toLeft";
			cnButton_toLeft.Size = new System.Drawing.Size(68, 51);
			cnButton_toLeft.TabIndex = 6;
			cnButton_toLeft.Tag = "toLeft";
			cnButton_toLeft.Text = "<=";
			cnButton_toLeft.UseVisualStyleBackColor = true;
			cnButton_toLeft.Click += new System.EventHandler(cnButton_toRight_Click);
			cnButton_toRight.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_toRight.CnPressDownColor = System.Drawing.Color.White;
			cnButton_toRight.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			cnButton_toRight.Location = new System.Drawing.Point(584, 437);
			cnButton_toRight.Name = "cnButton_toRight";
			cnButton_toRight.Size = new System.Drawing.Size(68, 51);
			cnButton_toRight.TabIndex = 7;
			cnButton_toRight.Tag = "toRight";
			cnButton_toRight.Text = "=>";
			cnButton_toRight.UseVisualStyleBackColor = true;
			cnButton_toRight.Click += new System.EventHandler(cnButton_toRight_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(1274, 771);
			base.Controls.Add(cnButton_toLeft);
			base.Controls.Add(cnButton_toRight);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_datacatcat";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_datacatcat_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_datacatcat()
		{
			InitializeComponent();
			mCatLists = new BindingList<ChipCategoryElement>[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mCatLists[i] = MainForm0.USR3B[i].mPointlistCat;
			}
			datagridviews_pcbcat = new DataGridView[HW.mFnNum];
			label_num = new Label[HW.mFnNum];
			mLeadingCurIndex = new int[HW.mFnNum];
			for (int j = 0; j < HW.mFnNum; j++)
			{
				datagridviews_pcbcat[j] = new DataGridView();
				base.Controls.Add(datagridviews_pcbcat[j]);
				datagridviews_pcbcat[j].Size = new Size(551, 630);
				datagridviews_pcbcat[j].Location = new Point(27 + 640 * j, 90);
				datagridviews_pcbcat[j].Tag = j;
				datagridviews_pcbcat[j].CellMouseUp += dataGridView_pcb_CellMouseUp;
				label_num[j] = new Label();
				base.Controls.Add(label_num[j]);
				label_num[j].Location = new Point(500 + 640 * j, 70);
				label_num[j].Tag = j;
				label_num[j].Text = "0/0";
				Type type = datagridviews_pcbcat[j].GetType();
				PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
				property.SetValue(datagridviews_pcbcat[j], true, null);
			}
		}

		private void dataGridView_pcb_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				DataGridView dataGridView = (DataGridView)sender;
				int num = (int)dataGridView.Tag;
				mLeadingCurIndex[num] = e.RowIndex;
				label_num[num].Text = (mLeadingCurIndex[num] + 1).ToString() + "/" + dataGridView.Rows.Count;
			}
		}

		private void Form_datacatcat_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				init_dataGridView_pcbcat(datagridviews_pcbcat[i], mCatLists[i]);
			}
		}

		private void init_dataGridView_pcbcat(DataGridView dgv, BindingList<ChipCategoryElement> clist)
		{
			dgv.ClearSelection();
			dgv.AllowUserToAddRows = false;
			dgv.ReadOnly = false;
			dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.DataSource = clist;
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				dgv.Columns[i].Width = 50;
				dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				dgv.Columns[i].Visible = true;
				dgv.Columns[i].HeaderText = CAT_HEAD[i].str[MainForm0.USR_INIT.mLanguage];
			}
			dgv.ColumnHeadersHeight = 40;
			dgv.RowHeadersWidth = 50;
			dgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020[MainForm0.USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dgv.RowHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020[MainForm0.USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dgv.EnableHeadersVisualStyles = false;
			dgv.DefaultCellStyle.Font = new Font(DEF.FONT_2020_DATA[MainForm0.USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			for (int j = 0; j < dgv.Columns.Count; j++)
			{
				if (j > 12)
				{
					dgv.Columns[j].Visible = false;
				}
				if (j == 17)
				{
					dgv.Columns[j].Visible = true;
				}
				dgv.Columns[j].Width = CAT_HEAD[j].width[MainForm0.USR_INIT.mLanguage];
				dgv.Columns[j].HeaderText = CAT_HEAD[j].str[MainForm0.USR_INIT.mLanguage];
				if (j == 8 || j == 15 || j == 16 || j == 17)
				{
					DataGridViewColumn dataGridViewColumn = dgv.Columns[j];
					dataGridViewColumn.HeaderText = dataGridViewColumn.HeaderText + Environment.NewLine + STR._MM[MainForm0.USR_INIT.mLanguage];
				}
				if (j != 12 && j != 18)
				{
					dgv.Columns[j].ReadOnly = true;
				}
				if (j >= 13)
				{
					dgv.Columns[j].DefaultCellStyle.BackColor = Color.LightBlue;
				}
				if (j == 1)
				{
					dgv.Columns[j].DefaultCellStyle.BackColor = Color.LightSalmon;
				}
				if (j == 2 || j == 0)
				{
					dgv.Columns[j].DefaultCellStyle.BackColor = Color.LightGray;
				}
				if (j == 3 || j == 6 || j == 7 || j == 9 || j == 10 || j == 11 || j == 8 || j == 12)
				{
					dgv.Columns[j].DefaultCellStyle.BackColor = Color.LightYellow;
				}
			}
			dgv.Refresh();
		}

		private void cnButton_toRight_Click(object sender, EventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			string text = (string)cnButton.Tag;
			int num = 0;
			int num2 = 1;
			if (text == "toRight")
			{
				num = 0;
				num2 = 1;
			}
			else if (text == "toLeft")
			{
				num = 1;
				num2 = 0;
			}
			int count = datagridviews_pcbcat[num].SelectedRows.Count;
			if (count <= 0)
			{
				MainForm0.CmMessageBoxTop_Ok("请选中行");
				return;
			}
			BindingList<ChipCategoryElement> bindingList = mCatLists[num];
			USR3_DATA uSR3_DATA = MainForm0.U3[num][MainForm0.U3Idx[num]];
			BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
			int[] array = new int[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = datagridviews_pcbcat[num].SelectedRows[i].Index;
			}
			Array.Sort(array);
			for (int j = 0; j < array.Count(); j++)
			{
				string material_value = bindingList[array[j]].Material_value;
				string footprint = bindingList[array[j]].Footprint;
				for (int k = 0; k < uSR3_DATA.mPointlist.Count; k++)
				{
					if (uSR3_DATA.mPointlist[k].Material_value == material_value && uSR3_DATA.mPointlist[k].Footprint == footprint)
					{
						bindingList2.Add(uSR3_DATA.mPointlist[k]);
					}
				}
			}
			BindingList<ChipCategoryElement> bindingList3 = mCatLists[num2];
			USR3_DATA uSR3_DATA2 = MainForm0.U3[num2][MainForm0.U3Idx[num2]];
			if (uSR3_DATA2.mPointlist == null)
			{
				uSR3_DATA2.mPointlist = (MainForm0.U3[num2][MainForm0.U3Idx[num2]].mPointlist = new BindingList<ChipBoardElement>());
			}
			if (bindingList3 == null)
			{
				bindingList3 = new BindingList<ChipCategoryElement>();
			}
			if (mLeadingCurIndex[num2] >= bindingList3.Count)
			{
				mLeadingCurIndex[num2] = bindingList3.Count - 1;
			}
			if (mLeadingCurIndex[num2] < 0)
			{
				mLeadingCurIndex[num2] = 0;
			}
			for (int num3 = count - 1; num3 >= 0; num3--)
			{
				bindingList3.Insert(mLeadingCurIndex[num2], bindingList[array[num3]]);
				for (int l = 0; l < bindingList[array[num3]].feeder_no.Count(); l++)
				{
					bindingList[array[num3]].feeder_no[l] = 0;
				}
			}
			for (int m = 0; m < count; m++)
			{
				datagridviews_pcbcat[num2].Rows[mLeadingCurIndex[num2] + m].Selected = true;
			}
			label_num[num2].Text = (mLeadingCurIndex[num2] + 1).ToString() + "/" + datagridviews_pcbcat[num2].Rows.Count;
			for (int n = 0; n < bindingList2.Count; n++)
			{
				bindingList2[n].Stack_no = 0;
				uSR3_DATA2.mPointlist.Add(bindingList2[n]);
				uSR3_DATA2.mPointlistSmt.Add(bindingList2[n]);
			}
			for (int num4 = count - 1; num4 >= 0; num4--)
			{
				bindingList.RemoveAt(array[num4]);
			}
			for (int num5 = 0; num5 < bindingList2.Count; num5++)
			{
				uSR3_DATA.mPointlist.Remove(bindingList2[num5]);
				uSR3_DATA.mPointlistSmt.Remove(bindingList2[num5]);
			}
			for (int num6 = 0; num6 < 2; num6++)
			{
				uSR3_DATA2.mMark[num6].X = uSR3_DATA.mMark[num6].X;
				uSR3_DATA2.mMark[num6].Y = uSR3_DATA.mMark[num6].Y;
				for (int num7 = 0; num7 < 6; num7++)
				{
					uSR3_DATA2.mMarkPara[num6].mPara.mParaCam[num7] = uSR3_DATA.mMarkPara[num6].mPara.mParaCam[num7];
				}
				for (int num8 = 0; num8 < 6; num8++)
				{
					uSR3_DATA2.mMarkPara[num6].mPara.mParaLed[num8] = uSR3_DATA.mMarkPara[num6].mPara.mParaLed[num8];
				}
				uSR3_DATA2.mMarkPara[num6].mPara.mLightOn = uSR3_DATA.mMarkPara[num6].mPara.mLightOn;
				uSR3_DATA2.mMarkPara[num6].mPara.mLedOn = uSR3_DATA.mMarkPara[num6].mPara.mLedOn;
				uSR3_DATA2.mMarkPara[num6].picsize = uSR3_DATA.mMarkPara[num6].picsize;
				uSR3_DATA2.mMarkPara[num6].recognizeRate = uSR3_DATA.mMarkPara[num6].recognizeRate;
				uSR3_DATA2.mMarkPic[num6] = new Bitmap(uSR3_DATA.mMarkPic[num6]);
				uSR3_DATA2.mMarkPara[num6].mPicMark = new Bitmap(uSR3_DATA.mMarkPara[num6].mPicMark);
			}
			uSR3_DATA2.mArrayPCBRow = uSR3_DATA.mArrayPCBRow;
			uSR3_DATA2.mArrayPCBColumn = uSR3_DATA.mArrayPCBColumn;
			uSR3_DATA2.mIsPcbAix = uSR3_DATA.mIsPcbAix;
			for (int num9 = 0; num9 < 4; num9++)
			{
				uSR3_DATA2.mPcbArrayXY[num9].X = uSR3_DATA.mPcbArrayXY[num9].X;
				uSR3_DATA2.mPcbArrayXY[num9].Y = uSR3_DATA.mPcbArrayXY[num9].Y;
				uSR3_DATA2.mPcbAixXY[num9].X = uSR3_DATA.mPcbAixXY[num9].X;
				uSR3_DATA2.mPcbAixXY[num9].Y = uSR3_DATA.mPcbAixXY[num9].Y;
			}
			int num10 = uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn;
			if (uSR3_DATA.mArraySinglePoint != null && uSR3_DATA.mArraySinglePoint.Count() != num10)
			{
				uSR3_DATA.mArraySinglePoint = null;
			}
			if (uSR3_DATA2.mArraySinglePoint != null && uSR3_DATA2.mArraySinglePoint.Count() != num10)
			{
				uSR3_DATA2.mArraySinglePoint = null;
			}
			if (uSR3_DATA.mArraySinglePoint == null)
			{
				uSR3_DATA.mArraySinglePoint = new Coordinate[num10];
				for (int num11 = 0; num11 < num10; num11++)
				{
					uSR3_DATA.mArraySinglePoint[num11] = new Coordinate();
				}
			}
			if (uSR3_DATA2.mArraySinglePoint == null)
			{
				uSR3_DATA2.mArraySinglePoint = new Coordinate[num10];
				for (int num12 = 0; num12 < num10; num12++)
				{
					uSR3_DATA2.mArraySinglePoint[num12] = new Coordinate();
				}
			}
			for (int num13 = 0; num13 < num10; num13++)
			{
				uSR3_DATA2.mArraySinglePoint[num13].X = uSR3_DATA.mArraySinglePoint[num13].X;
				uSR3_DATA2.mArraySinglePoint[num13].Y = uSR3_DATA.mArraySinglePoint[num13].Y;
			}
			int num14 = Math.Min(uSR3_DATA2.mIsArrayAixMount.Count(), uSR3_DATA.mIsArrayAixMount.Count());
			for (int num15 = 0; num15 < num14; num15++)
			{
				uSR3_DATA2.mIsArrayAixMount[num15] = uSR3_DATA.mIsArrayAixMount[num15];
			}
			if (uSR3_DATA.mIsArrayMount != null && uSR3_DATA.mIsArrayMount.Count() != num10)
			{
				uSR3_DATA.mIsArrayMount = null;
			}
			if (uSR3_DATA2.mIsArrayMount != null && uSR3_DATA2.mIsArrayMount.Count() != num10)
			{
				uSR3_DATA2.mIsArrayMount = null;
			}
			if (uSR3_DATA.mIsArrayMount == null)
			{
				uSR3_DATA.mIsArrayMount = new bool[num10];
			}
			if (uSR3_DATA2.mIsArrayMount == null)
			{
				uSR3_DATA2.mIsArrayMount = new bool[num10];
			}
			for (int num16 = 0; num16 < num10; num16++)
			{
				uSR3_DATA2.mIsArrayMount[num16] = uSR3_DATA.mIsArrayMount[num16];
			}
			if (uSR3_DATA.mArrayIsMountList == null)
			{
				uSR3_DATA.mArrayIsMountList = new BindingList<ArrayIsMountElement>();
			}
			if (uSR3_DATA2.mArrayIsMountList == null)
			{
				uSR3_DATA2.mArrayIsMountList = new BindingList<ArrayIsMountElement>();
			}
			uSR3_DATA2.mArrayIsMountList.Clear();
			for (int num17 = 0; num17 < uSR3_DATA.mArrayIsMountList.Count; num17++)
			{
				uSR3_DATA2.mArrayIsMountList.Add(uSR3_DATA.mArrayIsMountList[num17]);
			}
			MainForm0.pcbsmt_refresh_groups(uSR3_DATA);
			MainForm0.pcbsmt_refresh_groups(uSR3_DATA2);
			MainForm0.pcbsmt_refresh_arrays(uSR3_DATA);
			MainForm0.pcbsmt_refresh_arrays(uSR3_DATA2);
			if (mLeadingCurIndex[num] >= bindingList.Count)
			{
				mLeadingCurIndex[num] = bindingList.Count - 1;
			}
			if (mLeadingCurIndex[num] < 0)
			{
				mLeadingCurIndex[num] = 0;
			}
			label_num[num].Text = (mLeadingCurIndex[num] + 1).ToString() + "/" + datagridviews_pcbcat[num].Rows.Count;
		}
	}
}
