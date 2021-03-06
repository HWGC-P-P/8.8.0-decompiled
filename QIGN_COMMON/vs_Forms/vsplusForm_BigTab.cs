using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class vsplusForm_BigTab : Form
	{
		private BindingList<BIGTAB_SUB_PIK_ITEM> mPikList;

		private BindingList<BIGTAB_2_ITEM> mMntList;

		public BindingList<USR3_DATA> mUSR3List;

		public int mUSR3Idx;

		private IContainer components;

		private DataGridView dataGridView1;

		private DataGridView dataGridView2;

		public vsplusForm_BigTab(BindingList<USR3_DATA> usr3list, int usr3idx)
		{
			InitializeComponent();
			mPikList = new BindingList<BIGTAB_SUB_PIK_ITEM>();
			mMntList = new BindingList<BIGTAB_2_ITEM>();
			if (usr3list[usr3idx].mBigTab == null)
			{
				return;
			}
			for (int i = 0; i < usr3list[usr3idx].mBigTab.Count; i++)
			{
				BIGTAB_GROUP bIGTAB_GROUP = usr3list[usr3idx].mBigTab[i];
				if (bIGTAB_GROUP == null)
				{
					continue;
				}
				for (int j = 0; j < bIGTAB_GROUP.pik_arr.Count; j++)
				{
					BIGTAB_1_ITEM bIGTAB_1_ITEM = bIGTAB_GROUP.pik_arr[j];
					if (bIGTAB_1_ITEM != null)
					{
						for (int k = 0; k < bIGTAB_1_ITEM.sync_arr.Count; k++)
						{
							mPikList.Add(bIGTAB_1_ITEM.sync_arr[k]);
						}
					}
				}
				for (int l = 0; l < bIGTAB_GROUP.remain_pik_prepare_z.Count; l++)
				{
					_ = bIGTAB_GROUP.remain_pik_prepare_z[l];
					BIGTAB_SUB_PIK_ITEM item = new BIGTAB_SUB_PIK_ITEM
					{
						group_no = bIGTAB_GROUP.pik_arr[0].sync_arr[0].GroupNo,
						zn = bIGTAB_GROUP.remain_pik_prepare_z[l].zn,
						prepare0_z = bIGTAB_GROUP.remain_pik_prepare_z[l].value0,
						prepare1_z = bIGTAB_GROUP.remain_pik_prepare_z[l].value1
					};
					mPikList.Add(item);
				}
				for (int m = 0; m < bIGTAB_GROUP.mnt_arr.Count; m++)
				{
					mMntList.Add(bIGTAB_GROUP.mnt_arr[m]);
				}
				for (int n = 0; n < bIGTAB_GROUP.remain_mnt_prepare_z.Count; n++)
				{
					_ = bIGTAB_GROUP.remain_mnt_prepare_z[n];
					BIGTAB_2_ITEM item2 = new BIGTAB_2_ITEM
					{
						group_no = bIGTAB_GROUP.mnt_arr[0].GroupNo,
						zn = bIGTAB_GROUP.remain_mnt_prepare_z[n].zn,
						prepare0_z = bIGTAB_GROUP.remain_mnt_prepare_z[n].value0,
						prepare1_z = bIGTAB_GROUP.remain_mnt_prepare_z[n].value1
					};
					mMntList.Add(item2);
				}
			}
		}

		private void vsplusForm_BigTab_Load(object sender, EventArgs e)
		{
			Type type = dataGridView1.GetType();
			PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(dataGridView1, true, null);
			Type type2 = this.dataGridView2.GetType();
			PropertyInfo property2 = type2.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property2.SetValue(this.dataGridView2, true, null);
			DataGridView dataGridView = dataGridView1;
			dataGridView.DataSource = mPikList;
			dataGridView.Columns[0].Width = 25;
			dataGridView.Columns[0].HeaderText = "??????";
			dataGridView.Columns[1].Width = 25;
			dataGridView.Columns[1].HeaderText = "??????";
			dataGridView.Columns[2].Width = 50;
			dataGridView.Columns[2].HeaderText = "??????X";
			dataGridView.Columns[3].Width = 50;
			dataGridView.Columns[3].HeaderText = "??????Y";
			dataGridView.Columns[4].Width = 25;
			dataGridView.Columns[4].HeaderText = "?????????";
			dataGridView.Columns[5].Width = 40;
			dataGridView.Columns[5].HeaderText = "??????";
			dataGridView.Columns[6].Width = 30;
			dataGridView.Columns[6].HeaderText = "?????????";
			dataGridView.Columns[7].Width = 40;
			dataGridView.Columns[7].HeaderText = "??????????????????";
			dataGridView.Columns[8].Width = 35;
			dataGridView.Columns[8].HeaderText = "????????????Z";
			dataGridView.Columns[9].Width = 35;
			dataGridView.Columns[9].HeaderText = "??????????????????";
			dataGridView.Columns[10].Width = 30;
			dataGridView.Columns[10].HeaderText = "????????????";
			dataGridView.Columns[11].Width = 30;
			dataGridView.Columns[11].HeaderText = "??????Z";
			dataGridView.Columns[12].Width = 30;
			dataGridView.Columns[12].HeaderText = "????????????";
			dataGridView.Columns[13].Width = 35;
			dataGridView.Columns[13].HeaderText = "??????????????????";
			dataGridView.Columns[14].Width = 30;
			dataGridView.Columns[14].HeaderText = "????????????";
			dataGridView.Columns[15].Width = 35;
			dataGridView.Columns[15].HeaderText = "????????????Z";
			dataGridView.Columns[16].Width = 30;
			dataGridView.Columns[16].HeaderText = "????????????";
			dataGridView.Columns[17].Width = 30;
			dataGridView.Columns[17].HeaderText = "????????????";
			dataGridView.Columns[18].Width = 40;
			dataGridView.Columns[18].HeaderText = "??????????????????";
			dataGridView.Columns[19].Width = 140;
			dataGridView.Columns[19].HeaderText = "??????";
			for (int i = 0; i < mPikList.Count; i++)
			{
				dataGridView.Rows[i].DefaultCellStyle.BackColor = ((mPikList[i].group_no % 2 == 0) ? Color.FromArgb(170, 170, 170) : Color.FromArgb(220, 220, 220));
			}
			for (int j = 0; j < mPikList.Count; j++)
			{
				for (int k = 1; k < 3; k++)
				{
					if (mPikList[j].syncpik_no > 1)
					{
						dataGridView.Rows[j].Cells[k].Style.BackColor = ((mPikList[j].syncpik_no % 2 == 0) ? Color.FromArgb(255, 130, 130) : Color.FromArgb(255, 220, 220));
					}
				}
			}
			for (int l = 0; l < mPikList.Count; l++)
			{
				int[] array = new int[5] { 8, 9, 11, 13, 15 };
				for (int m = 0; m < array.Count(); m++)
				{
					int index = array[m];
					dataGridView.Rows[l].Cells[index].Style.BackColor = Color.FromArgb(150, 150, 255);
				}
			}
			DataGridView dataGridView2 = this.dataGridView2;
			dataGridView2.DataSource = mMntList;
			dataGridView2.Columns[0].Width = 25;
			dataGridView2.Columns[0].HeaderText = "??????";
			dataGridView2.Columns[1].Width = 50;
			dataGridView2.Columns[1].HeaderText = "??????";
			dataGridView2.Columns[2].Width = 25;
			dataGridView2.Columns[2].HeaderText = "??????";
			dataGridView2.Columns[3].Width = 35;
			dataGridView2.Columns[3].HeaderText = "??????????????????";
			dataGridView2.Columns[4].Width = 50;
			dataGridView2.Columns[4].HeaderText = "??????";
			dataGridView2.Columns[5].Width = 30;
			dataGridView2.Columns[5].HeaderText = "??????";
			dataGridView2.Columns[6].Width = 30;
			dataGridView2.Columns[6].HeaderText = "????????????";
			dataGridView2.Columns[7].Width = 30;
			dataGridView2.Columns[7].HeaderText = "????????????";
			dataGridView2.Columns[8].Width = 30;
			dataGridView2.Columns[8].HeaderText = "????????????";
			dataGridView2.Columns[9].Width = 30;
			dataGridView2.Columns[9].HeaderText = "????????????";
			dataGridView2.Columns[10].Width = 30;
			dataGridView2.Columns[10].HeaderText = "????????????";
			dataGridView2.Columns[11].Width = 40;
			dataGridView2.Columns[11].HeaderText = "???????????????";
			dataGridView2.Columns[12].Width = 40;
			dataGridView2.Columns[12].HeaderText = "???????????????";
			dataGridView2.Columns[13].Width = 35;
			dataGridView2.Columns[13].HeaderText = "????????????";
			dataGridView2.Columns[14].Width = 35;
			dataGridView2.Columns[14].HeaderText = "????????????";
			dataGridView2.Columns[15].Width = 50;
			dataGridView2.Columns[15].HeaderText = "??????X";
			dataGridView2.Columns[16].Width = 50;
			dataGridView2.Columns[16].HeaderText = "??????Y";
			dataGridView2.Columns[17].Width = 40;
			dataGridView2.Columns[17].HeaderText = "??????A";
			dataGridView2.Columns[18].Width = 40;
			dataGridView2.Columns[18].HeaderText = "??????A??????";
			dataGridView2.Columns[19].Width = 35;
			dataGridView2.Columns[19].HeaderText = "??????????????????";
			dataGridView2.Columns[20].Width = 35;
			dataGridView2.Columns[20].HeaderText = "??????????????????";
			dataGridView2.Columns[21].Width = 30;
			dataGridView2.Columns[21].HeaderText = "????????????";
			dataGridView2.Columns[22].Width = 40;
			dataGridView2.Columns[22].HeaderText = "??????Z";
			dataGridView2.Columns[23].Width = 30;
			dataGridView2.Columns[23].HeaderText = "????????????";
			dataGridView2.Columns[24].Width = 35;
			dataGridView2.Columns[24].HeaderText = "??????????????????";
			dataGridView2.Columns[25].Width = 30;
			dataGridView2.Columns[25].HeaderText = "????????????";
			dataGridView2.Columns[26].Width = 35;
			dataGridView2.Columns[26].HeaderText = "??????????????????";
			dataGridView2.Columns[27].Width = 35;
			dataGridView2.Columns[27].HeaderText = "????????????";
			dataGridView2.Columns[28].Width = 25;
			dataGridView2.Columns[28].HeaderText = "????????????";
			dataGridView2.Columns[29].Width = 25;
			dataGridView2.Columns[29].HeaderText = "??????????????????";
			dataGridView2.Columns[30].Width = 25;
			dataGridView2.Columns[30].HeaderText = "????????????";
			dataGridView2.Columns[31].Width = 25;
			dataGridView2.Columns[31].HeaderText = "????????????";
			dataGridView2.Columns[32].Width = 140;
			dataGridView2.Columns[32].HeaderText = "??????";
			for (int n = 0; n < mMntList.Count; n++)
			{
				dataGridView2.Rows[n].DefaultCellStyle.BackColor = ((mMntList[n].group_no % 2 == 0) ? Color.FromArgb(170, 170, 170) : Color.FromArgb(220, 220, 220));
			}
			for (int num = 0; num < mMntList.Count; num++)
			{
				int[] array2 = new int[9] { 3, 13, 14, 19, 20, 22, 24, 26, 27 };
				for (int num2 = 0; num2 < array2.Count(); num2++)
				{
					int index2 = array2[num2];
					dataGridView2.Rows[num].Cells[index2].Style.BackColor = Color.FromArgb(150, 150, 255);
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
			dataGridView1 = new System.Windows.Forms.DataGridView();
			dataGridView2 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
			SuspendLayout();
			dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new System.Drawing.Point(12, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowTemplate.Height = 23;
			dataGridView1.Size = new System.Drawing.Size(579, 900);
			dataGridView1.TabIndex = 0;
			dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView2.Location = new System.Drawing.Point(597, 12);
			dataGridView2.Name = "dataGridView2";
			dataGridView2.RowTemplate.Height = 23;
			dataGridView2.Size = new System.Drawing.Size(665, 900);
			dataGridView2.TabIndex = 0;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(1274, 931);
			base.Controls.Add(dataGridView2);
			base.Controls.Add(dataGridView1);
			Font = new System.Drawing.Font("??????", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "vsplusForm_BigTab";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(vsplusForm_BigTab_Load);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
			ResumeLayout(false);
		}
	}
}
