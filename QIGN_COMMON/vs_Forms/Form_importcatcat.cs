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
	public class Form_importcatcat : Form
	{
		private IContainer components;

		private CnButton cnButton_toLeft;

		private CnButton cnButton_toRight;

		private Label label1;

		private BindingList<ImportCat>[] mCatLists;

		private DataGridView[] datagridviews_pcbcat;

		private Label[] label_num;

		private int[] mLeadingCurIndex;

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
			label1.TabIndex = 3;
			label1.Text = "分类整理";
			cnButton_toLeft.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_toLeft.CnPressDownColor = System.Drawing.Color.White;
			cnButton_toLeft.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			cnButton_toLeft.Location = new System.Drawing.Point(584, 358);
			cnButton_toLeft.Name = "cnButton_toLeft";
			cnButton_toLeft.Size = new System.Drawing.Size(68, 51);
			cnButton_toLeft.TabIndex = 4;
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
			cnButton_toRight.TabIndex = 5;
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
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_importcatcat";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_importcatcat_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_importcatcat()
		{
			InitializeComponent();
			mCatLists = new BindingList<ImportCat>[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mCatLists[i] = new BindingList<ImportCat>();
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

		private void Form_importcatcat_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				LD_DATA2 lD = MainForm0.U3[i][MainForm0.U3Idx[i]].LD2;
				run_plisttocat(lD, mCatLists[i]);
				if (mCatLists[i] != null && mCatLists[i].Count > 0)
				{
					label_num[i].Text = mLeadingCurIndex[i] + 1 + "/" + mCatLists[i].Count;
				}
				init_dataGridView_pcbcat(datagridviews_pcbcat[i], mCatLists[i]);
			}
		}

		private void run_plisttocat(LD_DATA2 ld2, BindingList<ImportCat> clist)
		{
			if (ld2 == null || ld2.pointlist == null || ld2.pointlist.Count <= 0 || clist == null)
			{
				return;
			}
			if (ld2.mSnIndex[1] == -1 || ld2.mSnIndex[2] == -1)
			{
				MainForm0.CmMessageBoxTop_Ok("请先回到坐标整理界面标记[封装]和[型号]!");
				return;
			}
			clist.Clear();
			for (int i = 0; i < ld2.pointlist.Count; i++)
			{
				string text = ld2.pointlist[i].sn[ld2.mSnIndex[1]];
				string text2 = ld2.pointlist[i].sn[ld2.mSnIndex[2]];
				bool flag = false;
				for (int j = 0; j < clist.Count; j++)
				{
					if (clist[j].Mvalue == text && clist[j].Footprint == text2)
					{
						clist[j].Count++;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					clist.Add(new ImportCat(text, text2));
				}
			}
		}

		private void init_dataGridView_pcbcat(DataGridView dgv, BindingList<ImportCat> clist)
		{
			string[] array = new string[3] { "型号", "封装", "数量" };
			dgv.ClearSelection();
			dgv.AllowUserToAddRows = false;
			dgv.ReadOnly = false;
			dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.DataSource = clist;
			for (int i = 0; i < dgv.Columns.Count && i < 3; i++)
			{
				dgv.Columns[i].Width = 50;
				dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				dgv.Columns[i].Visible = true;
				dgv.Columns[i].HeaderText = array[i];
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
			int count = datagridviews_pcbcat[num].SelectedRows.Count;
			if (count <= 0)
			{
				MainForm0.CmMessageBoxTop_Ok("请选中行");
				return;
			}
			BindingList<ImportCat> bindingList = mCatLists[num];
			LD_DATA2 lD = MainForm0.U3[num][MainForm0.U3Idx[num]].LD2;
			BindingList<leadinelement> bindingList2 = new BindingList<leadinelement>();
			int[] array = new int[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = datagridviews_pcbcat[num].SelectedRows[i].Index;
			}
			Array.Sort(array);
			for (int j = 0; j < array.Count(); j++)
			{
				string mvalue = bindingList[array[j]].Mvalue;
				string footprint = bindingList[array[j]].Footprint;
				for (int k = 0; k < lD.pointlist.Count; k++)
				{
					if (lD.pointlist[k].sn[lD.mSnIndex[1]] == mvalue && lD.pointlist[k].sn[lD.mSnIndex[2]] == footprint)
					{
						bindingList2.Add(lD.pointlist[k]);
					}
				}
			}
			BindingList<ImportCat> bindingList3 = mCatLists[num2];
			LD_DATA2 lD2 = MainForm0.U3[num2][MainForm0.U3Idx[num2]].LD2;
			if (lD2.pointlist == null)
			{
				lD2.pointlist = (MainForm0.U3[num2][MainForm0.U3Idx[num2]].LD2.pointlist = new BindingList<leadinelement>());
			}
			if (bindingList3 == null)
			{
				bindingList3 = new BindingList<ImportCat>();
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
			}
			for (int l = 0; l < count; l++)
			{
				datagridviews_pcbcat[num2].Rows[mLeadingCurIndex[num2] + l].Selected = true;
			}
			label_num[num2].Text = (mLeadingCurIndex[num2] + 1).ToString() + "/" + datagridviews_pcbcat[num2].Rows.Count;
			for (int m = 0; m < bindingList2.Count; m++)
			{
				lD2.pointlist.Add(bindingList2[m]);
			}
			for (int num4 = count - 1; num4 >= 0; num4--)
			{
				bindingList.RemoveAt(array[num4]);
			}
			for (int n = 0; n < bindingList2.Count; n++)
			{
				lD.pointlist.Remove(bindingList2[n]);
			}
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
