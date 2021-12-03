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
	public class Form_importcat : Form
	{
		private DataGridView[] datagridviews_pcb;

		private Label[] label_num;

		private int[] mLeadingCurIndex;

		private ToolStripMenuItem[] ts_sn;

		private int mSnColumnCurIndex;

		private IContainer components;

		private Label label1;

		private CnButton cnButton_toRight;

		private CnButton cnButton_toLeft;

		private ContextMenuStrip contextMenuStrip_Sn;

		private CnButton cnButton_cat;

		private CnButton cnButton_pcbview;

		public Form_importcat()
		{
			InitializeComponent();
			datagridviews_pcb = new DataGridView[HW.mFnNum];
			label_num = new Label[HW.mFnNum];
			mLeadingCurIndex = new int[HW.mFnNum];
			mSnColumnCurIndex = 0;
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mLeadingCurIndex[i] = 0;
				datagridviews_pcb[i] = new DataGridView();
				base.Controls.Add(datagridviews_pcb[i]);
				datagridviews_pcb[i].Size = new Size(551, 730);
				datagridviews_pcb[i].Location = new Point(27 + 640 * i, 90);
				datagridviews_pcb[i].Tag = i;
				datagridviews_pcb[i].CellMouseUp += dataGridView_pcb_CellMouseUp;
				datagridviews_pcb[i].ColumnHeaderMouseClick += dataGridView_pcb_ColumnHeaderMouseClick;
				label_num[i] = new Label();
				base.Controls.Add(label_num[i]);
				label_num[i].Location = new Point(500 + 640 * i, 70);
				label_num[i].Tag = i;
				label_num[i].Text = "0/0";
				Type type = datagridviews_pcb[i].GetType();
				PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
				property.SetValue(datagridviews_pcb[i], true, null);
			}
		}

		private void dataGridView_pcb_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			DataGridView dataGridView = (DataGridView)sender;
			_ = (int)dataGridView.Tag;
			mSnColumnCurIndex = e.ColumnIndex;
			int num = 0;
			for (int i = dataGridView.FirstDisplayedScrollingColumnIndex; i < mSnColumnCurIndex; i++)
			{
				if (dataGridView.Columns[i].Visible)
				{
					num += dataGridView.Columns[i].Width;
				}
			}
			contextMenuStrip_Sn.Show(dataGridView, new Point(num + e.X, e.Y));
		}

		private void Form_importcat_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				LD_DATA2 lD = MainForm0.U3[i][MainForm0.U3Idx[i]].LD2;
				BindingList<leadinelement> pointlist = lD.pointlist;
				if (pointlist != null && pointlist.Count > 0)
				{
					label_num[i].Text = mLeadingCurIndex[i] + 1 + "/" + pointlist.Count;
				}
				init_dataGridView_pcb(datagridviews_pcb[i], pointlist);
			}
			contextMenuStrip_Sn.Items.Clear();
			ToolStripMenuItem[] array = new ToolStripMenuItem[6];
			for (int j = 0; j < 6; j++)
			{
				array[j] = new ToolStripMenuItem(STR.LOAD_HEAD_STR[j][MainForm0.USR_INIT.mLanguage]);
				array[j].Click += ToolStripMenuItem_Sn_Click;
				array[j].Tag = j;
			}
			ToolStripMenuItem[] array2 = new ToolStripMenuItem[27];
			for (int k = 6; k < 33; k++)
			{
				array2[k - 6] = new ToolStripMenuItem(STR.LOAD_HEAD_STR[k][MainForm0.USR_INIT.mLanguage]);
				array2[k - 6].Click += ToolStripMenuItem_Sn_Click;
				array2[k - 6].Tag = k;
			}
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem((MainForm0.USR_INIT.mLanguage == 2) ? "Optional" : "选填");
			toolStripMenuItem.DropDownItems.AddRange(array2);
			ts_sn = new ToolStripMenuItem[33];
			for (int l = 0; l < 33; l++)
			{
				if (l < 6)
				{
					ts_sn[l] = array[l];
				}
				else
				{
					ts_sn[l] = array2[l - 6];
				}
			}
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem((MainForm0.USR_INIT.mLanguage == 2) ? "Hiden Current Column" : "隐藏当前列");
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem((MainForm0.USR_INIT.mLanguage == 2) ? "Show All Columns" : "显示所有列");
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem((MainForm0.USR_INIT.mLanguage == 2) ? "Re-Write" : "重写");
			toolStripMenuItem4.Click += ToolStripMenuItem_ClearLabel_Click;
			toolStripMenuItem2.Click += ToolStripMenuItem_HidenCurColumn_Click;
			toolStripMenuItem3.Click += ToolStripMenuItem_ShowAllColumns_Click;
			contextMenuStrip_Sn.Items.AddRange(array);
			contextMenuStrip_Sn.Items.Insert(6, new ToolStripSeparator());
			contextMenuStrip_Sn.Items.Insert(6, toolStripMenuItem3);
			contextMenuStrip_Sn.Items.Insert(6, toolStripMenuItem2);
			contextMenuStrip_Sn.Items.Insert(6, toolStripMenuItem4);
			for (int m = 0; m < HW.mFnNum; m++)
			{
				LD_DATA2 lD2 = MainForm0.U3[m][MainForm0.U3Idx[m]].LD2;
				if (lD2.mSnIndex.Count() < 33)
				{
					int[] array3 = new int[lD2.mSnIndex.Count()];
					for (int n = 0; n < lD2.mSnIndex.Count(); n++)
					{
						array3[n] = lD2.mSnIndex[n];
					}
					lD2.mSnIndex = new int[33];
					for (int num = 0; num < 33; num++)
					{
						if (num < array3.Count())
						{
							lD2.mSnIndex[num] = array3[num];
						}
						else
						{
							lD2.mSnIndex[num] = -1;
						}
					}
				}
				if (lD2.mHidenColumnList == null)
				{
					lD2.mHidenColumnList = new BindingList<int>();
				}
			}
			LD_DATA2 lD3 = MainForm0.U3[0][MainForm0.U3Idx[0]].LD2;
			LD_DATA2 lD4 = MainForm0.U3[1][MainForm0.U3Idx[1]].LD2;
			for (int num2 = 0; num2 < 33; num2++)
			{
				lD4.mSnIndex[num2] = lD3.mSnIndex[num2];
			}
			lD4.mHidenColumnList.Clear();
			for (int num3 = 0; num3 < lD3.mHidenColumnList.Count; num3++)
			{
				int item = lD3.mHidenColumnList[num3];
				lD4.mHidenColumnList.Add(item);
			}
			for (int num4 = 0; num4 < HW.mFnNum; num4++)
			{
				LD_DATA2 lD5 = MainForm0.U3[num4][MainForm0.U3Idx[num4]].LD2;
				for (int num5 = 0; num5 < 33; num5++)
				{
					if (lD5.mSnIndex[num5] != -1)
					{
						datagridviews_pcb[num4].Columns[lD5.mSnIndex[num5]].HeaderText = STR.LOAD_HEAD_STR[num5][MainForm0.USR_INIT.mLanguage];
					}
				}
				refresh_SnHead(lD5);
				for (int num6 = 0; num6 < lD5.mHidenColumnList.Count; num6++)
				{
					if (lD5.mHidenColumnList[num6] >= 0 && lD5.mHidenColumnList[num6] < 40)
					{
						datagridviews_pcb[num4].Columns[lD5.mHidenColumnList[num6]].Visible = false;
					}
				}
			}
		}

		private void init_dataGridView_pcb(DataGridView dgv, BindingList<leadinelement> ldlist)
		{
			dgv.ClearSelection();
			dgv.AllowUserToAddRows = false;
			dgv.ReadOnly = false;
			dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.DataSource = ldlist;
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				dgv.Columns[i].Width = 50;
				dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				dgv.Columns[i].Visible = true;
				dgv.Columns[i].HeaderText = "n";
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
			dgv.Refresh();
		}

		private void ToolStripMenuItem_Sn_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			int num = (int)toolStripMenuItem.Tag;
			for (int i = 0; i < HW.mFnNum; i++)
			{
				datagridviews_pcb[i].Columns[mSnColumnCurIndex].HeaderText = STR.LOAD_HEAD_STR[num][MainForm0.USR_INIT.mLanguage];
				LD_DATA2 lD = MainForm0.U3[i][MainForm0.U3Idx[i]].LD2;
				lD.mSnIndex[num] = mSnColumnCurIndex;
				refresh_toolStripMenuItem_visibility(lD, mSnColumnCurIndex, (SnHead)num);
			}
		}

		private void refresh_toolStripMenuItem_visibility(LD_DATA2 ld2, int override_index, SnHead Sn)
		{
			for (int i = 0; i < 33; i++)
			{
				if (i != (int)Sn && override_index == ld2.mSnIndex[i])
				{
					ld2.mSnIndex[i] = -1;
				}
			}
			refresh_SnHead(ld2);
		}

		private void refresh_SnHead(LD_DATA2 ld2)
		{
			for (int i = 0; i < 33; i++)
			{
				ts_sn[i].Visible = ld2.mSnIndex[i] == -1;
			}
		}

		private void ToolStripMenuItem_ClearLabel_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				datagridviews_pcb[i].Columns[mSnColumnCurIndex].HeaderText = "n";
				LD_DATA2 lD = MainForm0.U3[i][MainForm0.U3Idx[i]].LD2;
				for (int j = 0; j < 33; j++)
				{
					if (lD.mSnIndex[j] == mSnColumnCurIndex && mSnColumnCurIndex != -1)
					{
						lD.mSnIndex[j] = -1;
						refresh_SnHead(lD);
					}
				}
			}
		}

		private void ToolStripMenuItem_HidenCurColumn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				LD_DATA2 lD = MainForm0.U3[i][MainForm0.U3Idx[i]].LD2;
				if (mSnColumnCurIndex >= 0 && mSnColumnCurIndex < 40 && lD != null)
				{
					if (lD.mHidenColumnList == null)
					{
						lD.mHidenColumnList = new BindingList<int>();
					}
					lD.mHidenColumnList.Add(mSnColumnCurIndex);
					datagridviews_pcb[i].Columns[mSnColumnCurIndex].Visible = false;
				}
			}
		}

		private void ToolStripMenuItem_ShowAllColumns_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				LD_DATA2 lD = MainForm0.U3[i][MainForm0.U3Idx[i]].LD2;
				if (lD != null)
				{
					if (lD.mHidenColumnList == null)
					{
						lD.mHidenColumnList = new BindingList<int>();
					}
					lD.mHidenColumnList.Clear();
					for (int j = 0; j < 40; j++)
					{
						datagridviews_pcb[i].Columns[j].Visible = true;
					}
				}
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
			int count = datagridviews_pcb[num].SelectedRows.Count;
			if (count <= 0)
			{
				MainForm0.CmMessageBoxTop_Ok("请选中行");
				return;
			}
			BindingList<leadinelement> pointlist = MainForm0.U3[num][MainForm0.U3Idx[num]].LD2.pointlist;
			int[] array = new int[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = datagridviews_pcb[num].SelectedRows[i].Index;
			}
			Array.Sort(array);
			BindingList<leadinelement> bindingList = MainForm0.U3[num2][MainForm0.U3Idx[num2]].LD2.pointlist;
			if (bindingList == null)
			{
				bindingList = (MainForm0.U3[num2][MainForm0.U3Idx[num2]].LD2.pointlist = new BindingList<leadinelement>());
			}
			if (mLeadingCurIndex[num2] >= bindingList.Count)
			{
				mLeadingCurIndex[num2] = bindingList.Count - 1;
			}
			if (mLeadingCurIndex[num2] < 0)
			{
				mLeadingCurIndex[num2] = 0;
			}
			for (int num3 = count - 1; num3 >= 0; num3--)
			{
				bindingList.Insert(mLeadingCurIndex[num2], pointlist[array[num3]]);
			}
			for (int j = 0; j < count; j++)
			{
				datagridviews_pcb[num2].Rows[mLeadingCurIndex[num2] + j].Selected = true;
			}
			label_num[num2].Text = (mLeadingCurIndex[num2] + 1).ToString() + "/" + datagridviews_pcb[num2].Rows.Count;
			for (int num4 = count - 1; num4 >= 0; num4--)
			{
				pointlist.RemoveAt(array[num4]);
			}
			if (mLeadingCurIndex[num] >= pointlist.Count)
			{
				mLeadingCurIndex[num] = pointlist.Count - 1;
			}
			if (mLeadingCurIndex[num] < 0)
			{
				mLeadingCurIndex[num] = 0;
			}
			label_num[num].Text = (mLeadingCurIndex[num] + 1).ToString() + "/" + datagridviews_pcb[num].Rows.Count;
		}

		private void cnButton_cat_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				LD_DATA2 lD = MainForm0.U3[i][MainForm0.U3Idx[i]].LD2;
				if (lD.mSnIndex[1] == -1 || lD.mSnIndex[2] == -1)
				{
					MainForm0.CmMessageBoxTop_Ok("请先标记[封装]和[型号]!");
					return;
				}
			}
			Form_importcatcat form_importcatcat = new Form_importcatcat();
			form_importcatcat.ShowDialog();
		}

		private void cnButton_pcbview_Click(object sender, EventArgs e)
		{
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
			components = new System.ComponentModel.Container();
			label1 = new System.Windows.Forms.Label();
			contextMenuStrip_Sn = new System.Windows.Forms.ContextMenuStrip(components);
			cnButton_pcbview = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_cat = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_toLeft = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_toRight = new QIGN_COMMON.vs_acontrol.CnButton();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 18f);
			label1.Location = new System.Drawing.Point(33, 29);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(106, 24);
			label1.TabIndex = 1;
			label1.Text = "坐标整理";
			contextMenuStrip_Sn.Name = "contextMenuStrip_Sn";
			contextMenuStrip_Sn.Size = new System.Drawing.Size(61, 4);
			cnButton_pcbview.BackColor = System.Drawing.Color.Salmon;
			cnButton_pcbview.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_pcbview.CnPressDownColor = System.Drawing.Color.White;
			cnButton_pcbview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			cnButton_pcbview.Location = new System.Drawing.Point(488, 23);
			cnButton_pcbview.Name = "cnButton_pcbview";
			cnButton_pcbview.Size = new System.Drawing.Size(123, 41);
			cnButton_pcbview.TabIndex = 4;
			cnButton_pcbview.Text = "视图整理";
			cnButton_pcbview.UseVisualStyleBackColor = false;
			cnButton_pcbview.Click += new System.EventHandler(cnButton_pcbview_Click);
			cnButton_cat.BackColor = System.Drawing.Color.Salmon;
			cnButton_cat.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_cat.CnPressDownColor = System.Drawing.Color.White;
			cnButton_cat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			cnButton_cat.Location = new System.Drawing.Point(359, 23);
			cnButton_cat.Name = "cnButton_cat";
			cnButton_cat.Size = new System.Drawing.Size(123, 41);
			cnButton_cat.TabIndex = 4;
			cnButton_cat.Text = "分类整理";
			cnButton_cat.UseVisualStyleBackColor = false;
			cnButton_cat.Click += new System.EventHandler(cnButton_cat_Click);
			cnButton_toLeft.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_toLeft.CnPressDownColor = System.Drawing.Color.White;
			cnButton_toLeft.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			cnButton_toLeft.Location = new System.Drawing.Point(584, 360);
			cnButton_toLeft.Name = "cnButton_toLeft";
			cnButton_toLeft.Size = new System.Drawing.Size(68, 51);
			cnButton_toLeft.TabIndex = 2;
			cnButton_toLeft.Tag = "toLeft";
			cnButton_toLeft.Text = "<=";
			cnButton_toLeft.UseVisualStyleBackColor = true;
			cnButton_toLeft.Click += new System.EventHandler(cnButton_toRight_Click);
			cnButton_toRight.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_toRight.CnPressDownColor = System.Drawing.Color.White;
			cnButton_toRight.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			cnButton_toRight.Location = new System.Drawing.Point(584, 438);
			cnButton_toRight.Name = "cnButton_toRight";
			cnButton_toRight.Size = new System.Drawing.Size(68, 51);
			cnButton_toRight.TabIndex = 2;
			cnButton_toRight.Tag = "toRight";
			cnButton_toRight.Text = "=>";
			cnButton_toRight.UseVisualStyleBackColor = true;
			cnButton_toRight.Click += new System.EventHandler(cnButton_toRight_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(1274, 861);
			base.Controls.Add(cnButton_pcbview);
			base.Controls.Add(cnButton_cat);
			base.Controls.Add(cnButton_toLeft);
			base.Controls.Add(cnButton_toRight);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_importcat";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_importcat_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
