using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_feederinstall : UserControl
	{
		private USR_DATA USR;

		private USR3_BASE USR3B;

		private USR_INIT_DATA USR_INIT;

		private int mFeederListCurIndex;

		private int mFn;

		private IContainer components;

		private CnButton button_feederinstall_reflush;

		private CnButton button_export_feedertable;

		private CnButton button_PCBE_feeder_OK;

		private DataGridView dataGridView_nozzleinstall2;

		private Label label_title_feeder_nozzle_plug;

		private DataGridView dataGridView_feederinstall;

		private Label label_feedernumbers;

		private CnButton button_searchfeeder;

		private CnButton button_Simulation;

		private TextBox textBox_searchfeeder;

		public UserControl_feederinstall(int fn, USR_DATA usr, USR3_BASE usr3b)
		{
			InitializeComponent();
			USR = usr;
			mFn = fn;
			USR3B = usr3b;
			USR_INIT = MainForm0.USR_INIT;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			Type type = dataGridView_feederinstall.GetType();
			PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(dataGridView_feederinstall, true, null);
			Type type2 = dataGridView_nozzleinstall2.GetType();
			PropertyInfo property2 = type2.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property2.SetValue(dataGridView_nozzleinstall2, true, null);
			init_pcbedit_smtlist_suggestion_feeder();
			init_pcbedit_smtlist_suggestion_nozzle();
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_title_feeder_nozzle_plug,
				str = new string[3] { "吸嘴飞达安装表", "吸嘴飛達安裝表", "Nozzle and Feeder Install List" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Simulation,
				str = new string[3] { "料站查看", "料站查看", "Feeder Chat" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_export_feedertable,
				str = new string[3] { "导出", "導出", "Export" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_searchfeeder,
				str = new string[3] { "搜索", "搜索", "Search" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_feederinstall_reflush,
				str = new string[3] { "刷新列表", "刷新列表", "Refresh List" }
			});
			return list;
		}

		private void UserControl_feederinstall_Load(object sender, EventArgs e)
		{
			if (USR3B.mFeederInstallList != null)
			{
				for (int i = 0; i < USR3B.mFeederInstallList.Count; i++)
				{
					dataGridView_feederinstall.Rows[i].DefaultCellStyle.BackColor = (USR3B.mFeederInstallList[i].IsInserted ? Color.LightGreen : Color.FromArgb(255, 224, 192));
				}
			}
			MainForm0.CreateAddButtonPic(button_Simulation);
			MainForm0.CreateAddButtonPic(button_export_feedertable);
			MainForm0.CreateAddButtonPic(button_searchfeeder);
			MainForm0.CreateAddButtonPic(button_feederinstall_reflush);
			MainForm0.CreateAddButtonPic(button_PCBE_feeder_OK);
		}

		private void button_PCBE_feeder_OK_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void init_pcbedit_smtlist_suggestion_feeder()
		{
			dataGridView_feederinstall.AllowUserToAddRows = false;
			dataGridView_feederinstall.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_feederinstall.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			if (USR3B.mFeederInstallList == null)
			{
				USR3B.mFeederInstallList = new BindingList<SmtFeederInstallElement>();
			}
			dataGridView_feederinstall.DataSource = USR3B.mFeederInstallList;
			dataGridView_feederinstall.RowHeadersWidth = 30;
			dataGridView_feederinstall.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView_feederinstall.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_feederinstall.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView_feederinstall.ColumnHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
			dataGridView_feederinstall.EnableHeadersVisualStyles = false;
			dataGridView_feederinstall.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
			dataGridView_feederinstall.DefaultCellStyle.Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
			dataGridView_feederinstall.Columns[0].DefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
			for (int i = 0; i < dataGridView_feederinstall.Columns.Count; i++)
			{
				dataGridView_feederinstall.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				if (i != 7)
				{
					dataGridView_feederinstall.Columns[i].ReadOnly = true;
				}
			}
			dataGridView_feederinstall.Columns[0].Width = 60;
			dataGridView_feederinstall.Columns[0].HeaderText = STR.PROVIDER[USR_INIT.mLanguage];
			dataGridView_feederinstall.Columns[1].Width = 60;
			dataGridView_feederinstall.Columns[1].HeaderText = STR.STACK_NO[USR_INIT.mLanguage];
			dataGridView_feederinstall.Columns[2].Width = 60;
			dataGridView_feederinstall.Columns[2].HeaderText = STR.FEEDER_TYPE[USR_INIT.mLanguage];
			dataGridView_feederinstall.Columns[3].Width = 80;
			dataGridView_feederinstall.Columns[3].HeaderText = STR.CHIP_VALUE[USR_INIT.mLanguage];
			dataGridView_feederinstall.Columns[4].Width = 70;
			dataGridView_feederinstall.Columns[4].HeaderText = STR.CHIP_PRINTFOOT[USR_INIT.mLanguage];
			dataGridView_feederinstall.Columns[5].Width = 50;
			dataGridView_feederinstall.Columns[5].HeaderText = STR.COUNT[USR_INIT.mLanguage];
			dataGridView_feederinstall.Columns[6].Width = 50;
			dataGridView_feederinstall.Columns[6].HeaderText = STR.CHIP_H[USR_INIT.mLanguage];
			dataGridView_feederinstall.Columns[6].Visible = false;
			dataGridView_feederinstall.Columns[7].Width = 70;
			dataGridView_feederinstall.Columns[7].HeaderText = STR.INSERT[USR_INIT.mLanguage];
			dataGridView_feederinstall.Columns[7].ReadOnly = false;
			label_feedernumbers.Text = "0/" + USR3B.mFeederInstallList.Count;
			MainForm0.update_usr2_stacks_used_show(mFn);
			MainForm0.update_usr2_stacks_used_nozzles(mFn);
		}

		private void init_pcbedit_smtlist_suggestion_nozzle()
		{
			dataGridView_nozzleinstall2.AllowUserToAddRows = false;
			dataGridView_nozzleinstall2.ReadOnly = true;
			dataGridView_nozzleinstall2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_nozzleinstall2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			if (USR3B.mNozzleInstallList2 == null)
			{
				USR3B.mNozzleInstallList2 = new BindingList<SmtNozzleInstallElement2>();
			}
			for (int i = 0; i < USR3B.mNozzleInstallList2.Count; i++)
			{
				USR3B.mNozzleInstallList2[i].Nozzle_name = ((USR_INIT.mLanguage == 2) ? "Noz " : "吸嘴") + (i + 1);
			}
			dataGridView_nozzleinstall2.DataSource = USR3B.mNozzleInstallList2;
			dataGridView_nozzleinstall2.RowHeadersWidth = 10;
			dataGridView_nozzleinstall2.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView_nozzleinstall2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_nozzleinstall2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView_nozzleinstall2.ColumnHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
			dataGridView_nozzleinstall2.EnableHeadersVisualStyles = false;
			dataGridView_nozzleinstall2.DefaultCellStyle.Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
			for (int j = 0; j < dataGridView_nozzleinstall2.Columns.Count; j++)
			{
				dataGridView_nozzleinstall2.Columns[j].Width = 74;
				dataGridView_nozzleinstall2.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			dataGridView_nozzleinstall2.Columns[0].HeaderText = STR.NOZZLE_NO[USR_INIT.mLanguage];
			dataGridView_nozzleinstall2.Columns[0].Width = 64;
			dataGridView_nozzleinstall2.Columns[1].HeaderText = STR.TYPE[USR_INIT.mLanguage];
			dataGridView_nozzleinstall2.Columns[1].Width = 48;
			dataGridView_nozzleinstall2.ReadOnly = true;
			dataGridView_nozzleinstall2.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
		}

		private void button_Simulation_Click(object sender, EventArgs e)
		{
			Form_FeederShow form_FeederShow = new Form_FeederShow(USR3B.slot_feeder_component, USR3B.isSlotBrkn, USR3B.isSlotOcpy);
			form_FeederShow.ShowDialog();
		}

		private void button_export_feedertable_Click(object sender, EventArgs e)
		{
			if (USR3B == null || USR3B.mFeederInstallList == null || USR3B.mFeederInstallList.Count == 0)
			{
				return;
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = ((USR_INIT.mLanguage == 2) ? "EXCEL（*.csv）|*.csv" : "EXCEL（*.csv）|*.csv");
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
				StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
				streamWriter.Write((USR_INIT.mLanguage == 2) ? "HWQN" : ("华维国创贴片机\t" + Environment.NewLine));
				streamWriter.Write(Environment.NewLine);
				streamWriter.Write((USR_INIT.mLanguage == 2) ? "Device:" : ("机型\t" + STR.DEVICE[(int)HW.mDeviceType] + Environment.NewLine));
				streamWriter.Write((USR_INIT.mLanguage == 2) ? "Project:" : ("工程\t" + MainForm0.mProjectFileName + Environment.NewLine));
				streamWriter.Write(Environment.NewLine);
				for (int i = 0; i < USR3B.mNozzleInstallList2.Count; i++)
				{
					streamWriter.Write(STR.NOZZLE_a[USR_INIT.mLanguage] + (i + 1) + "\t," + USR3B.mNozzleInstallList2[i].Nozzle_type + Environment.NewLine);
				}
				streamWriter.Write(Environment.NewLine);
				streamWriter.Write(STR.PROVIDER[USR_INIT.mLanguage] + "\t\t," + STR.STACK_NO[USR_INIT.mLanguage] + "\t\t," + STR.FEEDER_TYPE[USR_INIT.mLanguage] + "\t," + STR.CHIP_VALUE[USR_INIT.mLanguage] + "\t," + STR.CHIP_PRINTFOOT[USR_INIT.mLanguage] + "\t\t," + STR.COUNT[USR_INIT.mLanguage] + "\t\t" + Environment.NewLine);
				for (int j = 0; j < USR3B.mFeederInstallList.Count; j++)
				{
					streamWriter.Write(USR3B.mFeederInstallList[j].Stack_type_S + "\t" + ((USR3B.mFeederInstallList[j].Stacktype == ProviderType.Vibra) ? "" : "\t") + "," + USR3B.mFeederInstallList[j].Stack_no + "\t\t," + USR3B.mFeederInstallList[j].Feeder_type_S + "\t" + ((USR3B.mFeederInstallList[j].Stacktype == ProviderType.Vibra) ? "" : "\t") + "," + USR3B.mFeederInstallList[j].Material_value + "\t\t," + USR3B.mFeederInstallList[j].Footprint + "\t\t," + USR3B.mFeederInstallList[j].Count + "\t\t" + Environment.NewLine);
					streamWriter.Flush();
				}
				streamWriter.Close();
				fileStream.Close();
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Export Feeder&Nozzle Table Done!" : "导出吸嘴飞达安装列表完成！");
			}
		}

		private void button_searchfeeder_Click(object sender, EventArgs e)
		{
			string value = textBox_searchfeeder.Text;
			if (USR3B.mFeederInstallList == null || USR3B.mFeederInstallList.Count <= 0)
			{
				return;
			}
			int num = mFeederListCurIndex;
			if (num < 0 || num >= USR3B.mFeederInstallList.Count)
			{
				num = 0;
			}
			for (int i = num + 1; i < USR3B.mFeederInstallList.Count + num + 1; i++)
			{
				int num2 = i % USR3B.mFeederInstallList.Count;
				int num3 = 0;
				for (num3 = 0; num3 < dataGridView_feederinstall.Columns.Count; num3++)
				{
					string text = dataGridView_feederinstall.Rows[num2].Cells[num3].Value.ToString();
					if (text.Contains(value))
					{
						dataGridView_feederinstall.Rows[num].Selected = false;
						dataGridView_feederinstall.Rows[num2].Selected = true;
						dataGridView_feederinstall.FirstDisplayedScrollingRowIndex = num2;
						mFeederListCurIndex = num2;
						label_feedernumbers.Text = mFeederListCurIndex + 1 + "/" + USR3B.mFeederInstallList.Count;
						break;
					}
				}
				if (num3 < dataGridView_feederinstall.Columns.Count)
				{
					break;
				}
			}
		}

		private void button_feederinstall_reflush_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Please make sure [Chip category] done!" : "该操作之前需要先完成【元件分类】操作，是否已完成【元件分类】操作？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (feederinstall_reflush() == -1)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "There are invalid feeder types or stack No!" : "存在不合法的飞达类型或者不合法的料站号！");
				}
				else
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Complete feeder install table update!" : "完成飞达安装列表更新！");
				}
			}
		}

		private int feederinstall_reflush()
		{
			BindingList<SmtFeederInstallElement>[] array = new BindingList<SmtFeederInstallElement>[3];
			for (int i = 0; i < 3; i++)
			{
				array[i] = new BindingList<SmtFeederInstallElement>();
			}
			if (USR3B.mPointlistCat == null)
			{
				return -2;
			}
			MainForm0.write_to_logFile("feederinstall_reflush start:");
			for (int j = 0; j < USR3B.mPointlistCat.Count; j++)
			{
				for (int k = 0; k < USR3B.mPointlistCat[j].MultiFeeders; k++)
				{
					SmtFeederInstallElement smtFeederInstallElement = new SmtFeederInstallElement(USR_INIT.mLanguage);
					smtFeederInstallElement.Count = USR3B.mPointlistCat[j].Count;
					smtFeederInstallElement.Feedertype = USR3B.mPointlistCat[j].Feedertype;
					smtFeederInstallElement.Footprint = USR3B.mPointlistCat[j].Footprint;
					smtFeederInstallElement.IsInserted = false;
					smtFeederInstallElement.Material_value = USR3B.mPointlistCat[j].Material_value;
					smtFeederInstallElement.Stack_no = USR3B.mPointlistCat[j].feeder_no[k];
					smtFeederInstallElement.Height = USR3B.mPointlistCat[j].Height;
					smtFeederInstallElement.Stacktype = MainForm0.format_feeder_to_providertype(USR3B.mPointlistCat[j].Feedertype);
					array[(int)smtFeederInstallElement.Stacktype].Add(smtFeederInstallElement);
				}
			}
			MainForm0.write_to_logFile("feederinstall_reflush start II");
			for (int l = 0; l < 3; l++)
			{
				for (int m = 0; m < array[l].Count; m++)
				{
					if (array[l][m].Feedertype == FeederType.N_A || array[l][m].Stack_no <= 0 || array[l][m].Stack_no > HW.mStackNum[MainForm0.mFn][l])
					{
						return -1;
					}
				}
			}
			if (USR3B.mFeederInstallList == null)
			{
				USR3B.mFeederInstallList = new BindingList<SmtFeederInstallElement>();
			}
			USR3B.mFeederInstallList.Clear();
			for (int n = 0; n < 3; n++)
			{
				SmtFeederInstallElement[] array2 = array[n].OrderBy((SmtFeederInstallElement a) => a.Stack_no).ToArray();
				if (array2 != null)
				{
					for (int num = 0; num < array[n].Count; num++)
					{
						USR3B.mFeederInstallList.Add(array2[num]);
					}
				}
			}
			dataGridView_feederinstall.Refresh();
			label_feedernumbers.Text = "0/" + USR3B.mFeederInstallList.Count;
			MainForm0.write_to_logFile("feederinstall_reflush start III");
			MainForm0.update_usr2_stacks_used_show(mFn);
			MainForm0.update_usr2_stacks_used_nozzles(mFn);
			return 0;
		}

		private void dataGridView_feederinstall_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				mFeederListCurIndex = e.RowIndex;
				label_feedernumbers.Text = (mFeederListCurIndex + 1).ToString() + "/" + dataGridView_feederinstall.Rows.Count;
			}
		}

		private void dataGridView_feederinstall_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				mFeederListCurIndex = e.RowIndex;
				label_feedernumbers.Text = (mFeederListCurIndex + 1).ToString() + "/" + dataGridView_feederinstall.Rows.Count;
				if (e.ColumnIndex == 7)
				{
					string text = dataGridView_feederinstall.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
					bool flag = ((text == "False") ? true : false);
					dataGridView_feederinstall.Rows[e.RowIndex].DefaultCellStyle.BackColor = (flag ? Color.LightGreen : Color.FromArgb(255, 224, 192));
					dataGridView_feederinstall.ClearSelection();
					dataGridView_feederinstall.UpdateCellValue(e.ColumnIndex, e.RowIndex);
					dataGridView_feederinstall.Refresh();
					dataGridView_feederinstall.CurrentCell = dataGridView_feederinstall.Rows[e.RowIndex].Cells[0];
					dataGridView_feederinstall.EndEdit();
					dataGridView_feederinstall.Rows[e.RowIndex].Cells[0].Selected = false;
					Thread thread = new Thread(thd_reflush_green);
					thread.IsBackground = true;
					thread.Start();
				}
			}
		}

		private void dataGridView_feederinstall_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				mFeederListCurIndex = e.RowIndex;
				label_feedernumbers.Text = (mFeederListCurIndex + 1).ToString() + "/" + dataGridView_feederinstall.Rows.Count;
				if (e.ColumnIndex == 7)
				{
					dataGridView_feederinstall.CurrentCell = dataGridView_feederinstall.Rows[e.RowIndex].Cells[1];
					dataGridView_feederinstall.EndEdit();
					dataGridView_feederinstall.Rows[e.RowIndex].Cells[1].Selected = false;
					Thread thread = new Thread(thd_reflush_green);
					thread.IsBackground = true;
					thread.Start();
				}
			}
		}

		private void thd_reflush_green()
		{
			Thread.Sleep(50);
			Invoke((MethodInvoker)delegate
			{
				if (USR3B.mFeederInstallList != null && USR3B.mFeederInstallList.Count != 0)
				{
					for (int i = 0; i < USR3B.mFeederInstallList.Count; i++)
					{
						if (USR3B.mFeederInstallList[i].IsInserted)
						{
							dataGridView_feederinstall.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
						}
						else
						{
							dataGridView_feederinstall.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
						}
					}
					dataGridView_feederinstall.Refresh();
				}
			});
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
			button_feederinstall_reflush = new QIGN_COMMON.vs_acontrol.CnButton();
			button_export_feedertable = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBE_feeder_OK = new QIGN_COMMON.vs_acontrol.CnButton();
			dataGridView_nozzleinstall2 = new System.Windows.Forms.DataGridView();
			label_title_feeder_nozzle_plug = new System.Windows.Forms.Label();
			dataGridView_feederinstall = new System.Windows.Forms.DataGridView();
			label_feedernumbers = new System.Windows.Forms.Label();
			button_searchfeeder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_Simulation = new QIGN_COMMON.vs_acontrol.CnButton();
			textBox_searchfeeder = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)dataGridView_nozzleinstall2).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView_feederinstall).BeginInit();
			SuspendLayout();
			button_feederinstall_reflush.BackColor = System.Drawing.Color.Salmon;
			button_feederinstall_reflush.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_feederinstall_reflush.CnPressDownColor = System.Drawing.Color.White;
			button_feederinstall_reflush.Font = new System.Drawing.Font("黑体", 10.5f);
			button_feederinstall_reflush.Location = new System.Drawing.Point(427, 49);
			button_feederinstall_reflush.Name = "button_feederinstall_reflush";
			button_feederinstall_reflush.Size = new System.Drawing.Size(109, 27);
			button_feederinstall_reflush.TabIndex = 33;
			button_feederinstall_reflush.Text = "刷新列表";
			button_feederinstall_reflush.UseVisualStyleBackColor = false;
			button_feederinstall_reflush.Click += new System.EventHandler(button_feederinstall_reflush_Click);
			button_export_feedertable.BackColor = System.Drawing.Color.CadetBlue;
			button_export_feedertable.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_export_feedertable.CnPressDownColor = System.Drawing.Color.White;
			button_export_feedertable.Font = new System.Drawing.Font("黑体", 10.5f);
			button_export_feedertable.Location = new System.Drawing.Point(146, 49);
			button_export_feedertable.Name = "button_export_feedertable";
			button_export_feedertable.Size = new System.Drawing.Size(77, 27);
			button_export_feedertable.TabIndex = 32;
			button_export_feedertable.Text = "导出";
			button_export_feedertable.UseVisualStyleBackColor = true;
			button_export_feedertable.Click += new System.EventHandler(button_export_feedertable_Click);
			button_PCBE_feeder_OK.BackColor = System.Drawing.SystemColors.ControlLight;
			button_PCBE_feeder_OK.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_feeder_OK.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_feeder_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f);
			button_PCBE_feeder_OK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_PCBE_feeder_OK.Location = new System.Drawing.Point(665, 6);
			button_PCBE_feeder_OK.Name = "button_PCBE_feeder_OK";
			button_PCBE_feeder_OK.Size = new System.Drawing.Size(32, 32);
			button_PCBE_feeder_OK.TabIndex = 29;
			button_PCBE_feeder_OK.Text = "X";
			button_PCBE_feeder_OK.UseVisualStyleBackColor = false;
			button_PCBE_feeder_OK.Click += new System.EventHandler(button_PCBE_feeder_OK_Click);
			dataGridView_nozzleinstall2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_nozzleinstall2.Location = new System.Drawing.Point(8, 80);
			dataGridView_nozzleinstall2.Name = "dataGridView_nozzleinstall2";
			dataGridView_nozzleinstall2.Size = new System.Drawing.Size(135, 755);
			dataGridView_nozzleinstall2.TabIndex = 31;
			label_title_feeder_nozzle_plug.Font = new System.Drawing.Font("黑体", 14.25f);
			label_title_feeder_nozzle_plug.Location = new System.Drawing.Point(7, 6);
			label_title_feeder_nozzle_plug.Name = "label_title_feeder_nozzle_plug";
			label_title_feeder_nozzle_plug.Size = new System.Drawing.Size(673, 32);
			label_title_feeder_nozzle_plug.TabIndex = 30;
			label_title_feeder_nozzle_plug.Text = "吸嘴飞达安装表";
			label_title_feeder_nozzle_plug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			dataGridView_feederinstall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_feederinstall.Location = new System.Drawing.Point(147, 80);
			dataGridView_feederinstall.Name = "dataGridView_feederinstall";
			dataGridView_feederinstall.Size = new System.Drawing.Size(545, 755);
			dataGridView_feederinstall.TabIndex = 24;
			dataGridView_feederinstall.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_feederinstall_CellContentClick);
			dataGridView_feederinstall.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_feederinstall_CellContentDoubleClick);
			dataGridView_feederinstall.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_feederinstall_CellMouseDown);
			label_feedernumbers.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_feedernumbers.Location = new System.Drawing.Point(598, 53);
			label_feedernumbers.Name = "label_feedernumbers";
			label_feedernumbers.Size = new System.Drawing.Size(93, 23);
			label_feedernumbers.TabIndex = 26;
			label_feedernumbers.Text = "0/0";
			label_feedernumbers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_searchfeeder.BackColor = System.Drawing.Color.LightBlue;
			button_searchfeeder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_searchfeeder.CnPressDownColor = System.Drawing.Color.White;
			button_searchfeeder.Font = new System.Drawing.Font("黑体", 10.5f);
			button_searchfeeder.Location = new System.Drawing.Point(349, 49);
			button_searchfeeder.Name = "button_searchfeeder";
			button_searchfeeder.Size = new System.Drawing.Size(75, 27);
			button_searchfeeder.TabIndex = 28;
			button_searchfeeder.Text = "搜索";
			button_searchfeeder.UseVisualStyleBackColor = true;
			button_searchfeeder.Click += new System.EventHandler(button_searchfeeder_Click);
			button_Simulation.BackColor = System.Drawing.Color.Salmon;
			button_Simulation.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_Simulation.CnPressDownColor = System.Drawing.Color.White;
			button_Simulation.Font = new System.Drawing.Font("黑体", 10.5f);
			button_Simulation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_Simulation.Location = new System.Drawing.Point(8, 49);
			button_Simulation.Name = "button_Simulation";
			button_Simulation.Size = new System.Drawing.Size(135, 27);
			button_Simulation.TabIndex = 25;
			button_Simulation.Text = "料站查看";
			button_Simulation.UseVisualStyleBackColor = false;
			button_Simulation.Click += new System.EventHandler(button_Simulation_Click);
			textBox_searchfeeder.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_searchfeeder.Location = new System.Drawing.Point(228, 51);
			textBox_searchfeeder.Name = "textBox_searchfeeder";
			textBox_searchfeeder.Size = new System.Drawing.Size(116, 23);
			textBox_searchfeeder.TabIndex = 27;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(108, 148, 185);
			base.Controls.Add(button_feederinstall_reflush);
			base.Controls.Add(button_export_feedertable);
			base.Controls.Add(button_PCBE_feeder_OK);
			base.Controls.Add(dataGridView_nozzleinstall2);
			base.Controls.Add(label_title_feeder_nozzle_plug);
			base.Controls.Add(dataGridView_feederinstall);
			base.Controls.Add(label_feedernumbers);
			base.Controls.Add(button_searchfeeder);
			base.Controls.Add(button_Simulation);
			base.Controls.Add(textBox_searchfeeder);
			Font = new System.Drawing.Font("黑体", 9f);
			base.Name = "UserControl_feederinstall";
			base.Size = new System.Drawing.Size(715, 860);
			base.Load += new System.EventHandler(UserControl_feederinstall_Load);
			((System.ComponentModel.ISupportInitialize)dataGridView_nozzleinstall2).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView_feederinstall).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
