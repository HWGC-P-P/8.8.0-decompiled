using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_pcbedit_datagridview : UserControl
	{
		public UserControl_pcbedit_array uc_pcbedit_array;

		public UserControl_pcbedit_mark uc_pcbedit_mark;

		public UserControl_pcbedit_import uc_pcbedit_import;

		private int mFn;

		private USR_INIT_DATA USR_INIT;

		public USR_DATA USR;

		public USR2_DATA USR2;

		public USR3_DATA USR3;

		public USR3_BASE USR3B;

		public BindingList<ChipBoardElement> point_list;

		public BindingList<ChipBoardElement> point_list_smt;

		public int mPointCurIndex;

		public bool is_all_function = true;

		public bool mIsEditEnable;

		public string mCreateMode = "";

		public bool mIsPcbCheck;

		private IContainer components;

		private DataGridView dataGridView_pcbedit;

		private CnButton button_moveup;

		private CnButton button_pcbedit_additem;

		private CnButton button_pcbedit_deleteitem;

		private CnButton button_PCBE_order_0;

		private ComboBox comboBox_search1;

		private CnButton button_PCBE_order_1;

		private Label label_pcbedit_index;

		private ContextMenuStrip contextMenuStrip_pcbedit_list;

		private ToolStripMenuItem toolStripMenuItem_pcbedit_select;

		private ToolStripMenuItem toolStripMenuItem_pcbedit_select_cancel;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem ToolStripMenuItem_insert_up;

		private ToolStripMenuItem ToolStripMenuItem_insert_down;

		private ToolStripMenuItem ToolStripMenuItem_bulk_add;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem ToolStripMenuItem_group_combine;

		private ToolStripMenuItem ToolStripMenuItem_group_up;

		private ToolStripMenuItem ToolStripMenuItem_group_down;

		private ToolStripMenuItem ToolStripMenuItem_group_end;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem ToolStripMenuItem_delete;

		private ToolStripMenuItem ToolStripMenuItem_smtTest;

		private ToolStripMenuItem ToolStripMenuItem_group_orderbyheight;

		private CnButton button_pcbedit_movetoxy_prev;

		private CnButton button_movedown;

		private CnButton button_pcbedit_movetoxy;

		private CnButton button_pcbedit_movetoxy_next;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripMenuItem ToolStripMenuItem_ChangeAllXY;

		private CnButton button_backto_loadscreen;

		private CnButton button_pcbArray;

		private CnButton button_PCBE_Mark;

		private CnButton button_exportPCBlist;

		private CnButton button_PCBE_fackPCB;

		private ContextMenuStrip contextMenuStrip_pcbedit_cell;

		private ToolStripMenuItem 手动填充ToolStripMenuItem;

		private Panel panel_tools;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripMenuItem ToolStripMenuItem_selectlist;

		private CnButton button_pcbCheck;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripMenuItem ToolStripMenuItem_XboardCheck;

		private ToolStripMenuItem ToolStripMenuItem_MntScan;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripMenuItem toolStripMenuItem_setting;

		private CnSearchBoxEx cnSearchBoxEx1;

		private ToolStripMenuItem ToolStripMenuItem_group_begin;

		public event void_Func_chiplist vsplus_smt_test;

		public event void_Func_USR3_bool cb_pcbcheck_start;

		public UserControl_pcbedit_datagridview(int fn, USR_DATA usr, USR2_DATA usr2, USR3_DATA usr3, BindingList<ChipBoardElement> plist, string mode, bool is_pcbcheck, bool is_editenable)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR2 = usr2;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable2());
			}
			USR3 = usr3;
			point_list = plist;
			point_list_smt = plist;
			panel_tools.Visible = false;
			mCreateMode = mode;
			mIsPcbCheck = is_pcbcheck;
			mIsEditEnable = is_editenable;
			if (mode == "search_list")
			{
				base.Size = new Size(860, 600);
				dataGridView_pcbedit.Size = new Size(830, 460);
			}
			else if (mode == "group_combine")
			{
				base.Size = new Size(860, 310);
				dataGridView_pcbedit.Size = new Size(830, 280);
			}
			dataGridView_pcbedit.Location = new Point(dataGridView_pcbedit.Location.X, dataGridView_pcbedit.Location.Y - 26);
			base.Controls.Add(label_pcbedit_index);
			label_pcbedit_index.Location = new Point(dataGridView_pcbedit.Location.X, label_pcbedit_index.Location.Y);
			comboBox_search1.Items.Clear();
			for (int i = 0; i < 20; i++)
			{
				comboBox_search1.Items.Add(STR.mSearchString[i][USR_INIT.mLanguage]);
			}
			comboBox_search1.SelectedIndex = 0;
			toolStripSeparator1.Visible = false;
			ToolStripMenuItem_insert_up.Visible = false;
			ToolStripMenuItem_insert_down.Visible = false;
			ToolStripMenuItem_bulk_add.Visible = false;
			ToolStripMenuItem_delete.Visible = false;
			toolStripSeparator3.Visible = false;
			ToolStripMenuItem_smtTest.Visible = false;
			ToolStripMenuItem_group_combine.Visible = false;
			ToolStripMenuItem_group_up.Visible = false;
			ToolStripMenuItem_group_down.Visible = false;
			ToolStripMenuItem_group_end.Visible = false;
			ToolStripMenuItem_group_orderbyheight.Visible = false;
			toolStripSeparator2.Visible = false;
			toolStripSeparator6.Visible = false;
			toolStripSeparator7.Visible = false;
			ToolStripMenuItem_XboardCheck.Visible = false;
			ToolStripMenuItem_MntScan.Visible = false;
			toolStripMenuItem_setting.Visible = false;
			is_all_function = false;
			Type type = dataGridView_pcbedit.GetType();
			PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(dataGridView_pcbedit, true, null);
			PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
		}

		public UserControl_pcbedit_datagridview(int fn, USR_DATA usr, USR2_DATA usr2, USR3_DATA usr3, string mode, bool is_pcbcheck)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR2 = usr2;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable2());
			}
			USR3 = usr3;
			point_list = USR3.mPointlist;
			point_list_smt = USR3.mPointlistSmt;
			panel_tools.Visible = false;
			mIsPcbCheck = is_pcbcheck;
			mCreateMode = mode;
			if (mode == "pcb_check")
			{
				int num = 4;
				base.Size = new Size(base.Width, 765);
				dataGridView_pcbedit.Size = new Size(dataGridView_pcbedit.Width, 705);
				base.Controls.Add(button_backto_loadscreen);
				button_backto_loadscreen.Text = (new string[3] { "导入", "導入", "Import" })[USR_INIT.mLanguage];
				button_backto_loadscreen.Size = button_pcbedit_movetoxy_prev.Size;
				button_backto_loadscreen.Location = new Point(5, num);
				button_backto_loadscreen.UseVisualStyleBackColor = true;
				button_backto_loadscreen.Enabled = false;
				base.Controls.Add(button_pcbArray);
				button_pcbArray.Text = (new string[3] { "拼板", "拼板", "Array" })[USR_INIT.mLanguage];
				button_pcbArray.Size = button_pcbedit_movetoxy_prev.Size;
				button_pcbArray.Location = new Point(button_backto_loadscreen.Location.X + button_backto_loadscreen.Width, num);
				button_pcbArray.UseVisualStyleBackColor = true;
				button_pcbArray.Enabled = false;
				base.Controls.Add(button_pcbedit_additem);
				button_pcbedit_additem.Text = (new string[3] { "新增", "新增", "New" })[USR_INIT.mLanguage];
				button_pcbedit_additem.Size = button_pcbedit_movetoxy_prev.Size;
				button_pcbedit_additem.Location = new Point(button_pcbArray.Location.X + button_pcbArray.Width, num);
				button_pcbedit_additem.UseVisualStyleBackColor = true;
				base.Controls.Add(button_pcbedit_movetoxy_prev);
				button_pcbedit_movetoxy_prev.Location = new Point(button_pcbedit_additem.Location.X + button_pcbedit_additem.Width, num);
				base.Controls.Add(button_pcbedit_movetoxy_next);
				button_pcbedit_movetoxy_next.Size = button_pcbedit_movetoxy_prev.Size;
				button_pcbedit_movetoxy_next.Location = new Point(button_pcbedit_movetoxy_prev.Location.X + button_pcbedit_movetoxy_prev.Width, num);
				base.Controls.Add(button_PCBE_order_0);
				button_PCBE_order_0.Location = new Point(button_pcbedit_movetoxy_next.Location.X + 2 + button_pcbedit_movetoxy_next.Width, num);
				base.Controls.Add(button_PCBE_order_1);
				button_PCBE_order_1.Location = new Point(button_PCBE_order_0.Location.X + button_PCBE_order_0.Width, num);
				base.Controls.Add(comboBox_search1);
				base.Controls.Add(cnSearchBoxEx1);
				comboBox_search1.Location = new Point(comboBox_search1.Location.X, label_pcbedit_index.Location.Y);
				cnSearchBoxEx1.Location = new Point(cnSearchBoxEx1.Location.X, label_pcbedit_index.Location.Y - 2);
			}
			dataGridView_pcbedit.Location = new Point(dataGridView_pcbedit.Location.X, dataGridView_pcbedit.Location.Y - 26);
			comboBox_search1.Items.Clear();
			for (int i = 0; i < 20; i++)
			{
				comboBox_search1.Items.Add(STR.mSearchString[i][USR_INIT.mLanguage]);
			}
			comboBox_search1.SelectedIndex = 0;
			ToolStripMenuItem_smtTest.Visible = false;
			toolStripMenuItem_setting.Visible = false;
			is_all_function = true;
			Type type = dataGridView_pcbedit.GetType();
			PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(dataGridView_pcbedit, true, null);
			PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
		}

		public UserControl_pcbedit_datagridview(int fn, USR_DATA usr, USR2_DATA usr2, USR3_DATA usr3, USR3_BASE usr3b, bool is_pcbcheck)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR2 = usr2;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable2());
			}
			USR3 = usr3;
			USR3B = usr3b;
			point_list = USR3.mPointlist;
			point_list_smt = USR3.mPointlistSmt;
			is_all_function = true;
			mIsPcbCheck = is_pcbcheck;
			mCreateMode = "";
			comboBox_search1.Items.Clear();
			for (int i = 0; i < 20; i++)
			{
				comboBox_search1.Items.Add(STR.mSearchString[i][USR_INIT.mLanguage]);
			}
			comboBox_search1.SelectedIndex = 0;
			Type type = dataGridView_pcbedit.GetType();
			PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(dataGridView_pcbedit, true, null);
			PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
			if (point_list_smt != null)
			{
				MainForm0.uc_job[mFn].draw_fakePcbBoard(USR3);
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_backto_loadscreen,
				str = new string[3]
				{
					"导入" + Environment.NewLine + "界面",
					"導入" + Environment.NewLine + "界面",
					"Import" + Environment.NewLine + "Data"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbArray,
				str = new string[3]
				{
					"矩阵拼板",
					"矩陣" + Environment.NewLine + "拼板",
					"PCB" + Environment.NewLine + "Array"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PCBE_Mark,
				str = new string[3]
				{
					"Mark" + Environment.NewLine + "设置",
					"Mark" + Environment.NewLine + "設置",
					"Mark" + Environment.NewLine + "Setting"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PCBE_order_0,
				str = new string[3] { "拼板排序", "拼板排序", "Array Order" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PCBE_order_1,
				str = new string[3] { "贴装排序", "貼裝排序", "Group Order" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PCBE_fackPCB,
				str = new string[3] { "板图", "板圖", "PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_exportPCBlist,
				str = new string[3] { "导出", "導出", "Export" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_moveup,
				str = new string[3] { "上移↑", "上移↑", "Move↑" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_movedown,
				str = new string[3] { "下移↓", "下移↓", "Move↓" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbCheck,
				str = new string[3] { "进板查看", "進板查看", "Inboard Check Chips" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbedit_additem,
				str = new string[3] { "新增", "新增", "New" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbedit_deleteitem,
				str = new string[3] { "删除", "刪除", "Del" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbedit_movetoxy,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbedit_movetoxy_prev,
				str = new string[3] { "定位↑", "定位↑", "Goto↑" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbedit_movetoxy_next,
				str = new string[3] { "定位↓", "定位↓", "Goto↓" }
			});
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = comboBox_search1
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			LanguageItem languageItem2 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnSearchBoxEx1
			};
			string[] array2 = (languageItem2.str = new string[3]);
			list.Add(languageItem2);
			return list;
		}

		private List<LanguageToolStripMenuItem> initLanguageTable2()
		{
			List<LanguageToolStripMenuItem> list = new List<LanguageToolStripMenuItem>();
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_pcbedit_select,
				str = new string[3] { "勾选", "勾選", "Check" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_pcbedit_select_cancel,
				str = new string[3] { "勾选取消", "勾選取消", "UnCheck" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_selectlist,
				str = new string[3] { "选中列表", "選中列表", "Selected List" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_ChangeAllXY,
				str = new string[3] { "整体搬移XYA", "整體搬移XYA", "Adjust XYA" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_bulk_add,
				str = new string[3] { "批量阵列元件", "批量陣列元件", "Bulk Array Chips" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_insert_up,
				str = new string[3] { "向上插入一行", "向上插入壹行", "Insert Up" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_insert_down,
				str = new string[3] { "向下插入一行", "向下插入壹行", "Insert Down" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_delete,
				str = new string[3] { "删除", "刪除", "Delete" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_smtTest,
				str = new string[3] { "元件贴装测试", "元件貼裝測試", "Chip SMT Test" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_group_combine,
				str = new string[3] { "合并轮组", "合並輪組", "Combine to Group" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_group_up,
				str = new string[3] { "轮组上移", "輪組上移", "Group Up" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_group_down,
				str = new string[3] { "轮组下移", "輪組下移", "Group Down" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_group_end,
				str = new string[3] { "轮组移动到末尾", "輪組移動到末尾", "Group to End" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_group_orderbyheight,
				str = new string[3] { "轮组按元件高度排序", "輪組按元件高度排序", "Group Order as Chips Height" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_XboardCheck,
				str = new string[3] { "打叉板检测", "打叉板檢測", "Error X PCB check in PCB Array" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = ToolStripMenuItem_MntScan,
				str = new string[3] { "贴装位全扫", "貼裝位全掃", "Scan all Mount Place in PCB" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_setting,
				str = new string[3] { "其他设置", "其他設置", "Other Setting" }
			});
			return list;
		}

		private void UserControl_pcbedit_datagridview_Load(object sender, EventArgs e)
		{
			MethodInvoker method = delegate
			{
				PCBE_List_Show(USR3.mPointListOrder, is_reflush: false);
			};
			BeginInvoke(method);
		}

		private void null_pcbedit_editlist()
		{
			dataGridView_pcbedit.DataSource = null;
		}

		private void init_pcbedit_editlist(BindingList<ChipBoardElement> pointlist)
		{
			dataGridView_pcbedit.AllowUserToAddRows = false;
			dataGridView_pcbedit.ReadOnly = false;
			dataGridView_pcbedit.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_pcbedit.DataSource = pointlist;
			dataGridView_pcbedit.RowHeadersWidth = (new int[3] { 30, 30, 40 })[USR_INIT.mLanguage];
			dataGridView_pcbedit.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(180, 180, 180);
			dataGridView_pcbedit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_pcbedit.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(180, 180, 180);
			dataGridView_pcbedit.ColumnHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
			dataGridView_pcbedit.DefaultCellStyle.Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dataGridView_pcbedit.EnableHeadersVisualStyles = false;
			dataGridView_pcbedit.TopLeftHeaderCell.Value = (new string[3] { "表头", "表頭", "Head" })[USR_INIT.mLanguage];
			dataGridView_pcbedit.Columns[12].DefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dataGridView_pcbedit.Columns[15].DefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dataGridView_pcbedit.Columns[16].DefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dataGridView_pcbedit.Columns[17].DefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			if (dataGridView_pcbedit.Columns.Count != 39)
			{
				return;
			}
			for (int i = 0; i < 39; i++)
			{
				dataGridView_pcbedit.Columns[i].Width = STR.PCB_HEAD[i].width[USR_INIT.mLanguage];
				dataGridView_pcbedit.Columns[i].HeaderText = STR.PCB_HEAD[i].str[USR_INIT.mLanguage];
				dataGridView_pcbedit.Columns[i].Visible = i < 20;
				dataGridView_pcbedit.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				if (i != 0 && i != 18)
				{
					dataGridView_pcbedit.Columns[i].ReadOnly = true;
				}
			}
			if (mIsPcbCheck)
			{
				dataGridView_pcbedit.Columns[6].Visible = false;
				dataGridView_pcbedit.Columns[7].Visible = false;
				dataGridView_pcbedit.Columns[8].Visible = false;
				dataGridView_pcbedit.Columns[9].Visible = true;
				dataGridView_pcbedit.Columns[10].Visible = true;
				dataGridView_pcbedit.Columns[11].Visible = true;
			}
			else
			{
				dataGridView_pcbedit.Columns[6].Visible = true;
				dataGridView_pcbedit.Columns[7].Visible = true;
				dataGridView_pcbedit.Columns[8].Visible = true;
				dataGridView_pcbedit.Columns[9].Visible = false;
				dataGridView_pcbedit.Columns[10].Visible = false;
				dataGridView_pcbedit.Columns[11].Visible = false;
			}
			label_pcbedit_index.Text = "1/" + pointlist.Count;
		}

		private void button_PCBE_order_0_Click(object sender, EventArgs e)
		{
			MainForm0.pcbsmt_refresh_arrays(USR3);
			PCBE_List_Show(0, is_reflush: true);
		}

		private void button_PCBE_order_1_Click(object sender, EventArgs e)
		{
			PCBE_List_Show(1, is_reflush: true);
		}

		public void PCBE_List_Show(int order, bool is_reflush)
		{
			BindingList<ChipBoardElement> bindingList = ((order == 1) ? point_list_smt : point_list);
			if (bindingList == null)
			{
				return;
			}
			if (is_reflush)
			{
				init_pcbedit_editlist(bindingList);
			}
			for (int i = 0; i < bindingList.Count; i++)
			{
				bool flag = ((order == 1) ? ((bindingList[i].Group - 1) % 2 == 1) : (bindingList[i].Arrayno % 2 == 1));
				Color backColor = ((!bindingList[i].isOptimization) ? (flag ? Color.FromArgb(180, 180, 180) : Color.FromArgb(220, 220, 220)) : (flag ? Color.LightYellow : Color.NavajoWhite));
				if (mIsPcbCheck)
				{
					backColor = (flag ? Color.LightBlue : Color.White);
				}
				dataGridView_pcbedit.Rows[i].DefaultCellStyle.BackColor = backColor;
			}
			USR3.mPointListOrder = order;
			dataGridView_pcbedit.Refresh();
		}

		private void dataGridView_pcbedit_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && dataGridView_pcbedit.SelectedRows.Count > 0)
			{
				contextMenuStrip_pcbedit_list.Show(Control.MousePosition.X, Control.MousePosition.Y);
			}
		}

		private void button_pcbedit_additem_Click(object sender, EventArgs e)
		{
			int num = MainForm0.get_max_importno(point_list);
			int num2 = 0;
			if (USR3.mArrayPCBRow == 1 && USR3.mArrayPCBColumn == 1)
			{
				string text = Guid.NewGuid().ToString();
				ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage, text);
				if (point_list != null && point_list.Count > 0)
				{
					MainForm0.Copy_ChipBoardElement(chipBoardElement, point_list[point_list.Count - 1], 1, isguid: true);
					chipBoardElement.Stack_no = point_list[point_list.Count - 1].Stack_no;
				}
				if (mIsPcbCheck)
				{
					chipBoardElement.X_Real = ((MainForm0.mCur != null) ? MainForm0.mCur[mFn].x : 0);
					chipBoardElement.Y_Real = ((MainForm0.mCur != null) ? MainForm0.mCur[mFn].y : 0);
					Coordinate coordinate = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(chipBoardElement.X_Real, chipBoardElement.Y_Real));
					chipBoardElement.X = (int)coordinate.X;
					chipBoardElement.Y = (int)coordinate.Y;
					chipBoardElement.A = chipBoardElement.A_Real + (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
				}
				else
				{
					chipBoardElement.X = ((MainForm0.mCur != null) ? MainForm0.mCur[mFn].x : 0);
					chipBoardElement.Y = ((MainForm0.mCur != null) ? MainForm0.mCur[mFn].y : 0);
				}
				chipBoardElement.Group = ((point_list_smt.Count <= 0) ? 1 : (point_list_smt[point_list_smt.Count - 1].Group + 1));
				chipBoardElement.Guid = text;
				chipBoardElement.Labeltab = "";
				chipBoardElement.ImportNo = num + 1;
				point_list.Add(chipBoardElement);
				point_list_smt.Add(chipBoardElement);
				num2 = USR3.mPointlist.Count - 1;
				if (USR3.mPointListOrder == 1)
				{
					null_pcbedit_editlist();
				}
				MainForm0.pcbsmt_refresh_groups(USR3);
				PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
				if (USR3.mPointListOrder == 1)
				{
					num2 = USR3.mPointlistSmt.Count - 1;
				}
				dataGridView_pcbedit.ClearSelection();
				dataGridView_pcbedit.Rows[num2].Selected = true;
				dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = num2;
				dataGridView_pcbedit.Refresh();
			}
			else
			{
				string id = Guid.NewGuid().ToString();
				ChipBoardElement chipBoardElement2 = new ChipBoardElement(USR_INIT.mLanguage, id);
				if (mIsPcbCheck)
				{
					chipBoardElement2.X_Real = ((MainForm0.mCur != null) ? MainForm0.mCur[mFn].x : 0);
					chipBoardElement2.Y_Real = ((MainForm0.mCur != null) ? MainForm0.mCur[mFn].y : 0);
					Coordinate coordinate2 = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(chipBoardElement2.X_Real, chipBoardElement2.Y_Real));
					chipBoardElement2.X = (int)coordinate2.X;
					chipBoardElement2.Y = (int)coordinate2.Y;
					chipBoardElement2.A = chipBoardElement2.A_Real + (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
				}
				else
				{
					chipBoardElement2.X = ((MainForm0.mCur != null) ? MainForm0.mCur[mFn].x : 0);
					chipBoardElement2.Y = ((MainForm0.mCur != null) ? MainForm0.mCur[mFn].y : 0);
				}
				chipBoardElement2.ImportNo = num + 1;
				BindingList<ChipBoardElement> bindingList = new BindingList<ChipBoardElement>();
				bindingList.Add(chipBoardElement2);
				Form_PCBedit form_PCBedit = new Form_PCBedit(USR_INIT.mLanguage, bindingList, mIsPcbCheck);
				if (form_PCBedit.ShowDialog() == DialogResult.OK)
				{
					num2 = 0;
					if (USR3.mArrayPCBRow > 1 || USR3.mArrayPCBColumn > 1)
					{
						string[] array = new string[3]
						{
							"是否为其他拼板阵列也添加相同的料？" + Environment.NewLine + "(料站号，吸嘴号，贴装轮组无法同时添加，请通过优化或者手工的方式修改)",
							"是否為其他拼板陣列也添加相同的料？" + Environment.NewLine + "(料站號，吸嘴號，貼裝輪組無法同時添加，請通過優化或者手工的方式修改)",
							"Add same item for other PCB array?"
						};
						DialogResult dialogResult = MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNoCancel);
						if (dialogResult == DialogResult.Yes || dialogResult == DialogResult.No)
						{
							null_pcbedit_editlist();
							long num3 = chipBoardElement2.X - point_list[0].X;
							long num4 = chipBoardElement2.Y - point_list[0].Y;
							if (mIsPcbCheck)
							{
								num3 = chipBoardElement2.X_Real - point_list[0].X_Real;
								num4 = chipBoardElement2.Y_Real - point_list[0].Y_Real;
							}
							int[] array2 = new int[USR3.mArrayPCBRow * USR3.mArrayPCBColumn];
							for (int i = 0; i < USR3.mArrayPCBRow * USR3.mArrayPCBColumn; i++)
							{
								array2[i] = 0;
							}
							int[] array3 = new int[USR3.mArrayPCBRow * USR3.mArrayPCBColumn];
							for (int j = 0; j < USR3.mArrayPCBRow * USR3.mArrayPCBColumn; j++)
							{
								array3[j] = 0;
							}
							for (int k = 0; k < point_list.Count; k++)
							{
								for (int l = 0; l < USR3.mArrayPCBRow * USR3.mArrayPCBColumn; l++)
								{
									if (USR3.mPointlist[k].Arrayno == l)
									{
										array3[l]++;
									}
								}
							}
							array2[1] = array2[0] + array3[0];
							USR3.mPointlist.Insert(array2[1], chipBoardElement2);
							num2 = array2[1];
							array3[0]++;
							array2[1] = array2[0] + array3[0];
							chipBoardElement2.Group = ((point_list_smt.Count <= 0) ? 1 : (point_list_smt[point_list_smt.Count - 1].Group + 1));
							point_list_smt.Add(chipBoardElement2);
							if (dialogResult == DialogResult.Yes)
							{
								for (int m = 1; m < USR3.mArrayPCBRow * USR3.mArrayPCBColumn; m++)
								{
									ChipBoardElement chipBoardElement3 = new ChipBoardElement(USR_INIT.mLanguage, id);
									MainForm0.Copy_ChipBoardElement(chipBoardElement3, chipBoardElement2, 1, isguid: true);
									if (mIsPcbCheck)
									{
										chipBoardElement3.X_Real = point_list[array2[m]].X_Real + num3;
										chipBoardElement3.Y_Real = point_list[array2[m]].Y_Real + num4;
										Coordinate coordinate3 = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(chipBoardElement3.X_Real, chipBoardElement3.Y_Real));
										chipBoardElement3.X = (int)coordinate3.X;
										chipBoardElement3.Y = (int)coordinate3.Y;
										chipBoardElement3.A = chipBoardElement3.A_Real + (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
									}
									else
									{
										chipBoardElement3.X = point_list[array2[m]].X + num3;
										chipBoardElement3.Y = point_list[array2[m]].Y + num4;
									}
									chipBoardElement3.Arrayno = m;
									chipBoardElement3.Arrayno_S = m / USR3.mArrayPCBColumn + 1 + "-" + (m % USR3.mArrayPCBColumn + 1);
									chipBoardElement3.ImportNo = num + 1;
									if (m == USR3.mArrayPCBRow * USR3.mArrayPCBColumn - 1)
									{
										point_list.Add(chipBoardElement3);
										num2 = point_list.Count - 1;
									}
									else
									{
										array2[m + 1] = array2[m] + array3[m];
										point_list.Insert(array2[m + 1], chipBoardElement3);
										num2 = array2[m + 1];
										array3[m]++;
										array2[m + 1] = array2[m] + array3[m];
									}
									chipBoardElement3.Group = ((point_list_smt.Count <= 0) ? 1 : (point_list_smt[point_list_smt.Count - 1].Group + 1));
									point_list_smt.Add(chipBoardElement3);
								}
							}
							MainForm0.pcbsmt_refresh_groups(USR3);
							PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
							if (USR3.mPointListOrder == 1)
							{
								num2 = point_list_smt.Count - 1;
							}
							dataGridView_pcbedit.ClearSelection();
							dataGridView_pcbedit.Rows[num2].Selected = true;
							dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = num2;
						}
					}
					else
					{
						null_pcbedit_editlist();
						chipBoardElement2.Group = ((point_list_smt.Count <= 0) ? 1 : (point_list_smt[point_list_smt.Count - 1].Group + 1));
						point_list.Add(chipBoardElement2);
						point_list_smt.Add(chipBoardElement2);
						MainForm0.pcbsmt_refresh_groups(USR3);
						PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
						num2 = point_list_smt.Count - 1;
						dataGridView_pcbedit.ClearSelection();
						dataGridView_pcbedit.Rows[num2].Selected = true;
						dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = num2;
					}
					MainForm0.uc_job[mFn].draw_fakePcbBoard(USR3);
				}
			}
			label_pcbedit_index.Text = num2 + 1 + "/" + USR3.mPointlist.Count;
			if (point_list_smt != null)
			{
				MainForm0.uc_job[mFn].draw_fakePcbBoard(USR3);
			}
			MainForm0.save_usrProjectData();
		}

		private void button_pcbedit_deleteitem_Click(object sender, EventArgs e)
		{
			if (dataGridView_pcbedit.SelectedRows.Count <= 0)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList;
			if (USR3.mPointListOrder == 1 && point_list_smt != null && point_list_smt.Count > 0)
			{
				bindingList = point_list_smt;
			}
			else
			{
				if (USR3.mPointListOrder != 0)
				{
					string[] array = new string[3] { "无法删除", "無法刪除", "Delete fail!" };
					MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.OK);
					return;
				}
				bindingList = point_list;
			}
			string[] array2 = new string[3]
			{
				"您将要删除元件" + bindingList[dataGridView_pcbedit.SelectedRows[dataGridView_pcbedit.SelectedRows.Count - 1].Index].Material_value + "等" + dataGridView_pcbedit.SelectedRows.Count + "组数据",
				"您將要刪除元件" + bindingList[dataGridView_pcbedit.SelectedRows[dataGridView_pcbedit.SelectedRows.Count - 1].Index].Material_value + "等" + dataGridView_pcbedit.SelectedRows.Count + "組數據",
				"Delete " + bindingList[dataGridView_pcbedit.SelectedRows[dataGridView_pcbedit.SelectedRows.Count - 1].Index].Material_value + "etc. " + dataGridView_pcbedit.SelectedRows.Count + " items?"
			};
			if (MainForm0.CmMessageBox(array2[USR_INIT.mLanguage], MessageBoxButtons.OKCancel) != DialogResult.OK)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
			int num = dataGridView_pcbedit.SelectedRows[0].Index;
			int num2 = -1;
			for (int i = 0; i < dataGridView_pcbedit.SelectedRows.Count; i++)
			{
				bindingList2.Add(bindingList[dataGridView_pcbedit.SelectedRows[i].Index]);
				if (bindingList[dataGridView_pcbedit.SelectedRows[i].Index].isOptimization)
				{
					num2 = dataGridView_pcbedit.SelectedRows[i].Index;
				}
			}
			if (num2 != -1)
			{
				string text = "";
				string text2 = text;
				text = text2 + bindingList[num2].Labeltab + " " + bindingList[num2].Material_value + " " + bindingList[num2].Labeltab + " " + bindingList[num2].Footprint + Environment.NewLine;
				string[] array3 = new string[3] { "是经过优化轮组的元器件， 是否确定删除？", "是經過優化輪組的元器件， 是否確定刪除？", " belong to optimized groups, surely to delete?" };
				if (MainForm0.CmMessageBox(text + array3[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
			}
			null_pcbedit_editlist();
			for (int j = 0; j < bindingList2.Count; j++)
			{
				USR3.mPointlist.Remove(bindingList2[j]);
				if (USR3.mPointlistSmt != null)
				{
					USR3.mPointlistSmt.Remove(bindingList2[j]);
				}
			}
			MainForm0.pcbsmt_refresh_groups(USR3);
			MainForm0.pcbsmt_update_Groups(USR3);
			PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
			if (num >= bindingList.Count)
			{
				num = bindingList.Count - 1;
			}
			if (bindingList.Count > 0)
			{
				dataGridView_pcbedit.ClearSelection();
				dataGridView_pcbedit.Rows[num].Selected = true;
				dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = num;
			}
			if (point_list_smt != null)
			{
				MainForm0.uc_job[mFn].draw_fakePcbBoard(USR3);
			}
			MainForm0.save_usrProjectData();
			label_pcbedit_index.Text = num + 1 + "/" + USR3.mPointlist.Count;
		}

		private void button_ChangeAllXY_Click(object sender, EventArgs e)
		{
			BindingList<ChipBoardElement> pointlist = ((USR3.mPointListOrder == 1) ? point_list_smt : point_list);
			BindingList<int> bindingList = new BindingList<int>();
			int count = dataGridView_pcbedit.SelectedRows.Count;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					bindingList.Add(dataGridView_pcbedit.SelectedRows[i].Index);
				}
			}
			Form_ChangeAllXY form_ChangeAllXY = new Form_ChangeAllXY(USR_INIT.mLanguage, USR3, pointlist, bindingList, mIsPcbCheck);
			if (form_ChangeAllXY.ShowDialog() == DialogResult.OK)
			{
				dataGridView_pcbedit.Refresh();
				MainForm0.save_usrProjectData();
			}
		}

		private void dataGridView_pcbedit_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				label_pcbedit_index.Text = e.RowIndex + 1 + "/" + point_list.Count;
				mPointCurIndex = e.RowIndex;
			}
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
			if (e.RowIndex < 0)
			{
				return;
			}
			if (e.ColumnIndex == 1)
			{
				int group = bindingList[e.RowIndex].Group;
				for (int i = 0; i < bindingList.Count; i++)
				{
					if (bindingList[i].Group == group)
					{
						dataGridView_pcbedit.Rows[i].Selected = true;
					}
				}
				dataGridView_pcbedit.Refresh();
			}
			else if (e.ColumnIndex == 19)
			{
				int importNo = bindingList[e.RowIndex].ImportNo;
				for (int j = 0; j < bindingList.Count; j++)
				{
					if (bindingList[j].ImportNo == importNo)
					{
						dataGridView_pcbedit.Rows[j].Selected = true;
					}
				}
				dataGridView_pcbedit.Refresh();
			}
			else if (e.ColumnIndex == 13 || e.ColumnIndex == 12)
			{
				_ = e.ColumnIndex;
				BindingList<int> bindingList2 = new BindingList<int>();
				for (int k = 0; k < dataGridView_pcbedit.Rows.Count; k++)
				{
					if (dataGridView_pcbedit.Rows[k].Cells[e.ColumnIndex].Selected)
					{
						bindingList2.Add(k);
					}
				}
				dataGridView_pcbedit.ClearSelection();
				for (int l = 0; l < bindingList2.Count; l++)
				{
					int index = bindingList2[l];
					dataGridView_pcbedit.Rows[index].Cells[13].Selected = true;
					dataGridView_pcbedit.Rows[index].Cells[12].Selected = true;
				}
				dataGridView_pcbedit.Refresh();
			}
			else if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
			{
				_ = e.ColumnIndex;
				BindingList<int> bindingList3 = new BindingList<int>();
				for (int m = 0; m < dataGridView_pcbedit.Rows.Count; m++)
				{
					if (dataGridView_pcbedit.Rows[m].Cells[e.ColumnIndex].Selected)
					{
						bindingList3.Add(m);
					}
				}
				dataGridView_pcbedit.ClearSelection();
				for (int n = 0; n < bindingList3.Count; n++)
				{
					int index2 = bindingList3[n];
					dataGridView_pcbedit.Rows[index2].Cells[6].Selected = true;
					dataGridView_pcbedit.Rows[index2].Cells[7].Selected = true;
				}
				dataGridView_pcbedit.Refresh();
			}
			else if (e.ColumnIndex == 9 || e.ColumnIndex == 10)
			{
				_ = e.ColumnIndex;
				BindingList<int> bindingList4 = new BindingList<int>();
				for (int num = 0; num < dataGridView_pcbedit.Rows.Count; num++)
				{
					if (dataGridView_pcbedit.Rows[num].Cells[e.ColumnIndex].Selected)
					{
						bindingList4.Add(num);
					}
				}
				dataGridView_pcbedit.ClearSelection();
				for (int num2 = 0; num2 < bindingList4.Count; num2++)
				{
					int index3 = bindingList4[num2];
					dataGridView_pcbedit.Rows[index3].Cells[9].Selected = true;
					dataGridView_pcbedit.Rows[index3].Cells[10].Selected = true;
				}
				dataGridView_pcbedit.Refresh();
			}
			else
			{
				if (e.ColumnIndex != 16 && e.ColumnIndex != 17)
				{
					return;
				}
				_ = e.ColumnIndex;
				BindingList<int> bindingList5 = new BindingList<int>();
				for (int num3 = 0; num3 < dataGridView_pcbedit.Rows.Count; num3++)
				{
					if (dataGridView_pcbedit.Rows[num3].Cells[e.ColumnIndex].Selected)
					{
						bindingList5.Add(num3);
					}
				}
				dataGridView_pcbedit.ClearSelection();
				for (int num4 = 0; num4 < bindingList5.Count; num4++)
				{
					int index4 = bindingList5[num4];
					dataGridView_pcbedit.Rows[index4].Cells[16].Selected = true;
					dataGridView_pcbedit.Rows[index4].Cells[17].Selected = true;
				}
				dataGridView_pcbedit.Refresh();
			}
		}

		private void dataGridView_pcbedit_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				label_pcbedit_index.Text = e.RowIndex + 1 + "/" + point_list.Count;
				mPointCurIndex = e.RowIndex;
			}
			else if (e.RowIndex == -1)
			{
				if (e.ColumnIndex >= 0)
				{
					dataGridView_pcbedit.ClearSelection();
					for (int i = 0; i < dataGridView_pcbedit.RowCount; i++)
					{
						dataGridView_pcbedit.EndEdit();
						dataGridView_pcbedit.Rows[i].Cells[e.ColumnIndex].Selected = true;
					}
				}
				return;
			}
			if (e.Button != MouseButtons.Right || e.ColumnIndex < 0 || e.RowIndex < 0)
			{
				return;
			}
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			int num = 0;
			Point point = dataGridView_pcbedit.PointToClient(Control.MousePosition);
			int horizontalScrollingOffset = dataGridView_pcbedit.HorizontalScrollingOffset;
			int num2 = dataGridView_pcbedit.RowHeadersWidth;
			for (int j = 0; j < 20; j++)
			{
				num = j;
				if (dataGridView_pcbedit.Columns[j].Visible)
				{
					num2 += dataGridView_pcbedit.Columns[j].Width;
				}
				if (num2 > point.X + horizontalScrollingOffset)
				{
					break;
				}
			}
			BindingList<int> bindingList = new BindingList<int>();
			for (int k = 0; k < dataGridView_pcbedit.Rows.Count; k++)
			{
				if (dataGridView_pcbedit.Rows[k].Cells[num].Selected)
				{
					bindingList.Add(k);
				}
			}
			bool flag = false;
			if (count == 2 && dataGridView_pcbedit.SelectedCells[0].RowIndex == dataGridView_pcbedit.SelectedCells[1].RowIndex)
			{
				int columnIndex = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
				int columnIndex2 = dataGridView_pcbedit.SelectedCells[1].ColumnIndex;
				if ((columnIndex == 4 && columnIndex2 == 5) || (columnIndex == 5 && columnIndex2 == 4))
				{
					flag = true;
				}
			}
			dataGridView_pcbedit.ClearSelection();
			for (int l = 0; l < bindingList.Count; l++)
			{
				int index = bindingList[l];
				dataGridView_pcbedit.Rows[index].Cells[num].Selected = true;
				switch (num)
				{
				case 6:
					dataGridView_pcbedit.Rows[index].Cells[7].Selected = true;
					continue;
				case 7:
					dataGridView_pcbedit.Rows[index].Cells[6].Selected = true;
					continue;
				case 9:
					dataGridView_pcbedit.Rows[index].Cells[10].Selected = true;
					continue;
				case 10:
					dataGridView_pcbedit.Rows[index].Cells[9].Selected = true;
					continue;
				case 13:
					dataGridView_pcbedit.Rows[index].Cells[12].Selected = true;
					continue;
				case 12:
					dataGridView_pcbedit.Rows[index].Cells[13].Selected = true;
					continue;
				case 16:
					dataGridView_pcbedit.Rows[index].Cells[17].Selected = true;
					continue;
				case 17:
					dataGridView_pcbedit.Rows[index].Cells[16].Selected = true;
					continue;
				}
				if (flag && num == 4)
				{
					dataGridView_pcbedit.Rows[index].Cells[5].Selected = true;
				}
				else if (flag && num == 5)
				{
					dataGridView_pcbedit.Rows[index].Cells[4].Selected = true;
				}
			}
			count = dataGridView_pcbedit.SelectedCells.Count;
			contextMenuStrip_pcbedit_cell.Items.Clear();
			contextMenuStrip_pcbedit_cell.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
			switch (num)
			{
			case 4:
			case 5:
			{
				bool flag2 = true;
				for (int n = 0; n < count; n++)
				{
					if (dataGridView_pcbedit.SelectedCells[n].ColumnIndex != dataGridView_pcbedit.SelectedCells[0].ColumnIndex)
					{
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					ToolStripMenuItem toolStripMenuItem12 = new ToolStripMenuItem(STR.SELECT_ALL[USR_INIT.mLanguage]);
					toolStripMenuItem12.Tag = "string";
					toolStripMenuItem12.Click += fill_cells_selectall_click;
					ToolStripMenuItem toolStripMenuItem13 = new ToolStripMenuItem(STR.SELECT_ALL_LIST[USR_INIT.mLanguage]);
					toolStripMenuItem13.Tag = "string_list";
					toolStripMenuItem13.Click += fill_cells_selectall_click;
					ToolStripMenuItem toolStripMenuItem14 = new ToolStripMenuItem(STR.MANUAL_FILL[USR_INIT.mLanguage]);
					toolStripMenuItem14.Tag = "fill";
					toolStripMenuItem14.Click += fill_cells_string_manual_click;
					ToolStripMenuItem toolStripMenuItem15 = new ToolStripMenuItem(STR.CLEAR_EMPTY[USR_INIT.mLanguage]);
					toolStripMenuItem15.Click += fill_clear_manual_click;
					contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[5]
					{
						toolStripMenuItem12,
						toolStripMenuItem13,
						new ToolStripSeparator(),
						toolStripMenuItem14,
						toolStripMenuItem15
					});
					List<string> list = new List<string>();
					for (int num3 = 0; num3 < count; num3++)
					{
						if (dataGridView_pcbedit.SelectedCells[num3].Value != null && !(dataGridView_pcbedit.SelectedCells[num3].Value.ToString() == ""))
						{
							int num4 = 0;
							for (num4 = 0; num4 < list.Count && !(dataGridView_pcbedit.SelectedCells[num3].Value.ToString() == list[num4]); num4++)
							{
							}
							if (num4 == list.Count)
							{
								list.Add(dataGridView_pcbedit.SelectedCells[num3].Value.ToString());
							}
						}
					}
					if (list.Count > 0)
					{
						contextMenuStrip_pcbedit_cell.Items.Add(new ToolStripSeparator());
						for (int num5 = 0; num5 < list.Count; num5++)
						{
							ToolStripMenuItem toolStripMenuItem16 = new ToolStripMenuItem(STR.MANUAL_FILL[USR_INIT.mLanguage] + ":" + list[num5]);
							toolStripMenuItem16.Tag = "fill_ext";
							toolStripMenuItem16.Click += fill_cells_string_manual_click;
							contextMenuStrip_pcbedit_cell.Items.Add(toolStripMenuItem16);
						}
					}
					contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				}
				else if (count == 2)
				{
					ToolStripMenuItem toolStripMenuItem17 = new ToolStripMenuItem(STR.SELECT_ALL[USR_INIT.mLanguage]);
					toolStripMenuItem17.Tag = "string";
					toolStripMenuItem17.Click += fill_cells_selectall_click;
					ToolStripMenuItem toolStripMenuItem18 = new ToolStripMenuItem(STR.SELECT_ALL_LIST[USR_INIT.mLanguage]);
					toolStripMenuItem18.Tag = "string_list";
					toolStripMenuItem18.Click += fill_cells_selectall_click;
					contextMenuStrip_pcbedit_cell.Items.Add(toolStripMenuItem17);
					contextMenuStrip_pcbedit_cell.Items.Add(toolStripMenuItem18);
					contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				}
				break;
			}
			case 2:
			{
				ToolStripMenuItem toolStripMenuItem32 = new ToolStripMenuItem(STR.SELECT_ALL[USR_INIT.mLanguage]);
				toolStripMenuItem32.Tag = "string";
				toolStripMenuItem32.Click += fill_cells_selectall_click;
				ToolStripMenuItem toolStripMenuItem33 = new ToolStripMenuItem(STR.SELECT_ALL_LIST[USR_INIT.mLanguage]);
				toolStripMenuItem33.Tag = "string_list";
				toolStripMenuItem33.Click += fill_cells_selectall_click;
				contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[2] { toolStripMenuItem32, toolStripMenuItem33 });
				contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				break;
			}
			case 3:
			{
				ToolStripMenuItem toolStripMenuItem27 = new ToolStripMenuItem(STR.SELECT_ALL[USR_INIT.mLanguage]);
				toolStripMenuItem27.Tag = "string";
				toolStripMenuItem27.Click += fill_cells_selectall_click;
				ToolStripMenuItem toolStripMenuItem28 = new ToolStripMenuItem(STR.SELECT_ALL_LIST[USR_INIT.mLanguage]);
				toolStripMenuItem28.Tag = "string_list";
				toolStripMenuItem28.Click += fill_cells_selectall_click;
				ToolStripMenuItem toolStripMenuItem29 = new ToolStripMenuItem(STR.MANUAL_FILL[USR_INIT.mLanguage]);
				toolStripMenuItem29.Click += fill_labels_manual_click;
				ToolStripMenuItem toolStripMenuItem30 = new ToolStripMenuItem(STR.CLEAR_EMPTY[USR_INIT.mLanguage]);
				toolStripMenuItem30.Click += fill_clear_manual_click;
				contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[6]
				{
					toolStripMenuItem27,
					toolStripMenuItem28,
					new ToolStripSeparator(),
					toolStripMenuItem29,
					new ToolStripSeparator(),
					toolStripMenuItem30
				});
				contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				break;
			}
			case 14:
			{
				ToolStripMenuItem toolStripMenuItem22 = new ToolStripMenuItem((new string[3] { "顺序从1", "順序從1", "From 1" })[USR_INIT.mLanguage]);
				toolStripMenuItem22.Tag = "from1";
				toolStripMenuItem22.Click += fill_cells_nozzleno_click;
				ToolStripMenuItem toolStripMenuItem23 = new ToolStripMenuItem((new string[3] { "顺序从当前", "順序從當前", "From Cur" })[USR_INIT.mLanguage]);
				toolStripMenuItem23.Tag = "fromcur";
				toolStripMenuItem23.Click += fill_cells_nozzleno_click;
				ToolStripMenuItem toolStripMenuItem24 = new ToolStripMenuItem(STR.SELECT_ALL[USR_INIT.mLanguage]);
				toolStripMenuItem24.Tag = "int";
				toolStripMenuItem24.Click += fill_cells_selectall_click;
				ToolStripMenuItem toolStripMenuItem25 = new ToolStripMenuItem(STR.SELECT_ALL_LIST[USR_INIT.mLanguage]);
				toolStripMenuItem25.Tag = "int_list";
				toolStripMenuItem25.Click += fill_cells_selectall_click;
				ToolStripMenuItem toolStripMenuItem26 = new ToolStripMenuItem(STR.MANUAL_FILL[USR_INIT.mLanguage]);
				toolStripMenuItem26.Tag = "fill";
				toolStripMenuItem26.Click += fill_cells_int_manual_click;
				contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[7]
				{
					toolStripMenuItem24,
					toolStripMenuItem25,
					new ToolStripSeparator(),
					toolStripMenuItem22,
					toolStripMenuItem23,
					new ToolStripSeparator(),
					toolStripMenuItem26
				});
				contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				break;
			}
			case 12:
			case 13:
			{
				ToolStripMenuItem toolStripMenuItem19 = new ToolStripMenuItem(STR.SELECT_ALL[USR_INIT.mLanguage]);
				toolStripMenuItem19.Tag = "int";
				toolStripMenuItem19.Click += fill_cells_selectall_click;
				ToolStripMenuItem toolStripMenuItem20 = new ToolStripMenuItem(STR.SELECT_ALL_LIST[USR_INIT.mLanguage]);
				toolStripMenuItem20.Tag = "int_list";
				toolStripMenuItem20.Click += fill_cells_selectall_click;
				ToolStripMenuItem toolStripMenuItem21 = new ToolStripMenuItem(STR.MANUAL_FILL[USR_INIT.mLanguage]);
				toolStripMenuItem21.Tag = "fill";
				toolStripMenuItem21.Click += fill_cells_int_manual_click;
				contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[4]
				{
					toolStripMenuItem19,
					toolStripMenuItem20,
					new ToolStripSeparator(),
					toolStripMenuItem21
				});
				contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				break;
			}
			case 8:
			case 11:
			{
				ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem(STR.MANUAL_FILL[USR_INIT.mLanguage]);
				toolStripMenuItem6.Tag = "fill";
				toolStripMenuItem6.Click += fill_cells_float_manual_click;
				ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem((new string[3] { "批量加减", "批量加減", "Bulk Modify" })[USR_INIT.mLanguage]);
				toolStripMenuItem7.Tag = "adjust_angle";
				toolStripMenuItem7.Click += fill_cells_float_manual_click;
				contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[3]
				{
					toolStripMenuItem6,
					toolStripMenuItem7,
					new ToolStripSeparator()
				});
				ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem("+90");
				ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem("-90");
				ToolStripMenuItem toolStripMenuItem10 = new ToolStripMenuItem("+180");
				ToolStripMenuItem toolStripMenuItem11 = new ToolStripMenuItem("-180");
				toolStripMenuItem8.Click += fill_cells_float_manual_click;
				toolStripMenuItem9.Click += fill_cells_float_manual_click;
				toolStripMenuItem10.Click += fill_cells_float_manual_click;
				toolStripMenuItem11.Click += fill_cells_float_manual_click;
				toolStripMenuItem8.Tag = "adjust_angle_ext_+90";
				toolStripMenuItem9.Tag = "adjust_angle_ext_-90";
				toolStripMenuItem10.Tag = "adjust_angle_ext_+180";
				toolStripMenuItem11.Tag = "adjust_angle_ext_-180";
				contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[4] { toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10, toolStripMenuItem11 });
				contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				break;
			}
			case 6:
			case 7:
			case 9:
			case 10:
				switch (count)
				{
				case 2:
					if (dataGridView_pcbedit.SelectedCells[0].RowIndex != dataGridView_pcbedit.SelectedCells[1].RowIndex)
					{
						break;
					}
					goto case 1;
				case 1:
					if (mIsEditEnable || mIsPcbCheck)
					{
						ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem((new string[3] { "定位到坐标", "定位到坐標", "Goto XY" })[USR_INIT.mLanguage]);
						toolStripMenuItem3.Tag = 0;
						toolStripMenuItem3.Click += ToolStripMenuItem_movetoxy_Click;
						ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem((new string[3] { "吸嘴定位到坐标", "吸嘴定位到坐標", "Goto XY" })[USR_INIT.mLanguage]);
						toolStripMenuItem4.Tag = 1;
						toolStripMenuItem4.Click += ToolStripMenuItem_movetoxy_Click;
						if (is_all_function)
						{
							ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem((new string[3] { "更新坐标", "更新坐標", "Update XY" })[USR_INIT.mLanguage]);
							toolStripMenuItem5.Click += ToolStripMenuItem_savexy_Click;
							contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[4]
							{
								toolStripMenuItem3,
								toolStripMenuItem4,
								new ToolStripSeparator(),
								toolStripMenuItem5
							});
						}
						else
						{
							contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[3]
							{
								toolStripMenuItem3,
								new ToolStripSeparator(),
								toolStripMenuItem4
							});
						}
						contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
					}
					break;
				}
				break;
			case 15:
			{
				for (int num6 = 1; num6 < 4; num6++)
				{
					ToolStripMenuItem toolStripMenuItem31 = new ToolStripMenuItem(STR.CAMERA_STR[num6][USR_INIT.mLanguage]);
					toolStripMenuItem31.Click += fill_cells_cameratype_manual_click;
					toolStripMenuItem31.Tag = num6;
					contextMenuStrip_pcbedit_cell.Items.Add(toolStripMenuItem31);
				}
				contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				break;
			}
			case 16:
			case 17:
			{
				int rowIndex = dataGridView_pcbedit.SelectedCells[0].RowIndex;
				BindingList<ChipBoardElement> bindingList2 = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
				Form_VisualTab form_VisualTab = new Form_VisualTab(bindingList2[rowIndex].Visualtype, bindingList2[rowIndex].Looptype);
				if (form_VisualTab.ShowDialog() == DialogResult.OK)
				{
					LoopType looptype = form_VisualTab.get_looptype();
					VisualType visualtype = form_VisualTab.get_visualtype();
					for (int m = 0; m < count; m++)
					{
						int rowIndex2 = dataGridView_pcbedit.SelectedCells[m].RowIndex;
						bindingList2[rowIndex2].Looptype = looptype;
						bindingList2[rowIndex2].Visualtype = visualtype;
					}
					dataGridView_pcbedit.Refresh();
				}
				break;
			}
			case 18:
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem((new string[3] { "批量勾选", "批量勾選", "Bulk Check" })[USR_INIT.mLanguage]);
				toolStripMenuItem.Tag = "check";
				toolStripMenuItem.Click += fill_checkbox_manual_click;
				contextMenuStrip_pcbedit_cell.Items.Add(toolStripMenuItem);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem((new string[3] { "批量取消勾选", "批量取消勾選", "Bulk Uncheck" })[USR_INIT.mLanguage]);
				toolStripMenuItem2.Tag = "uncheck";
				toolStripMenuItem2.Click += fill_checkbox_manual_click;
				contextMenuStrip_pcbedit_cell.Items.AddRange(new ToolStripItem[2] { toolStripMenuItem, toolStripMenuItem2 });
				contextMenuStrip_pcbedit_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
				break;
			}
			}
		}

		private void fill_cells_string_manual_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			string text = (string)toolStripMenuItem.Tag;
			string text2 = "";
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			switch (dataGridView_pcbedit.SelectedCells[0].ColumnIndex)
			{
			case 4:
				text2 = STR.CHIP_VALUE[USR_INIT.mLanguage];
				break;
			case 5:
				text2 = STR.CHIP_PRINTFOOT[USR_INIT.mLanguage];
				break;
			default:
				return;
			}
			if (text == "fill")
			{
				Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, text2, "string");
				if (form_Fill.ShowDialog() == DialogResult.OK)
				{
					string @string = form_Fill.get_string();
					for (int i = 0; i < count; i++)
					{
						dataGridView_pcbedit.SelectedCells[i].Value = @string;
					}
					MainForm0.save_usrProjectData();
				}
			}
			else if (text == "fill_ext")
			{
				string text3 = toolStripMenuItem.Text;
				string value = text3.Replace(STR.MANUAL_FILL[USR_INIT.mLanguage] + ":", "");
				for (int j = 0; j < count; j++)
				{
					dataGridView_pcbedit.SelectedCells[j].Value = value;
				}
				MainForm0.save_usrProjectData();
			}
		}

		private void fill_clear_manual_click(object sender, EventArgs e)
		{
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0 || MainForm0.CmMessageBox((new string[3] { "是否清空选中单元格？", "是否清空選中單元格？", "Clear the selected cells?" })[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			int columnIndex = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
			bool flag = ((columnIndex == 3 || columnIndex == 5 || columnIndex == 4) ? true : false);
			for (int i = 0; i < count; i++)
			{
				if (flag)
				{
					dataGridView_pcbedit.SelectedCells[i].Value = "";
				}
				else
				{
					dataGridView_pcbedit.SelectedCells[i].Value = 0;
				}
			}
			MainForm0.save_usrProjectData();
		}

		private void fill_labels_manual_click(object sender, EventArgs e)
		{
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			Form_FillLabel form_FillLabel = new Form_FillLabel();
			if (form_FillLabel.ShowDialog() == DialogResult.OK)
			{
				string labelPreix = form_FillLabel.getLabelPreix();
				int labelStartIndex = form_FillLabel.getLabelStartIndex();
				for (int i = 0; i < count; i++)
				{
					dataGridView_pcbedit.SelectedCells[i].Value = labelPreix + (labelStartIndex + count - i - 1);
				}
				MainForm0.save_usrProjectData();
			}
		}

		private void fill_checkbox_manual_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			string text = (string)toolStripMenuItem.Tag;
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count > 0)
			{
				BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
				int columnIndex = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
				int firstDisplayedScrollingRowIndex = dataGridView_pcbedit.FirstDisplayedScrollingRowIndex;
				BindingList<int> bindingList2 = new BindingList<int>();
				for (int i = 0; i < count; i++)
				{
					int rowIndex = dataGridView_pcbedit.SelectedCells[i].RowIndex;
					bindingList[rowIndex].IsLowSpeed = ((text == "check") ? true : false);
					bindingList2.Add(rowIndex);
				}
				dataGridView_pcbedit.ClearSelection();
				dataGridView_pcbedit.CurrentCell = dataGridView_pcbedit.Rows[bindingList2[0]].Cells[columnIndex + 1];
				for (int j = 0; j < bindingList2.Count; j++)
				{
					int index = bindingList2[j];
					dataGridView_pcbedit.Rows[index].Cells[columnIndex].Selected = true;
				}
				dataGridView_pcbedit.Rows[bindingList2[0]].Cells[columnIndex + 1].Selected = false;
				dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
				dataGridView_pcbedit.Refresh();
				MainForm0.save_usrProjectData();
			}
		}

		private void fill_cells_nozzleno_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			string text = (string)toolStripMenuItem.Tag;
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0 || count > HW.mZnNum[mFn])
			{
				return;
			}
			if (USR3.mPointListOrder != 1)
			{
				MainForm0.CmMessageBox((new string[3] { "请先按照[贴装排序]!", "請先按照[貼裝排序]!", "SMT(Group) Order is required" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
				return;
			}
			int columnIndex = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
			if (columnIndex != 14)
			{
				return;
			}
			if (text == "from1")
			{
				for (int i = 0; i < count; i++)
				{
					dataGridView_pcbedit.SelectedCells[i].Value = count - i;
				}
			}
			else if (text == "fromcur")
			{
				int num = (int)dataGridView_pcbedit.SelectedCells[count - 1].Value - 1;
				for (int j = 0; j < count; j++)
				{
					dataGridView_pcbedit.SelectedCells[count - j - 1].Value = (num + j) % HW.mZnNum[mFn] + 1;
				}
			}
			MainForm0.save_usrProjectData();
		}

		private void fill_cells_float_manual_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			string text = (string)toolStripMenuItem.Tag;
			string type = "";
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
			if (text == "fill" || (text.ToString().Contains("adjust") && !text.ToString().Contains("_ext")))
			{
				Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, type, "float");
				if (form_Fill.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				float @float = form_Fill.get_float();
				if (text == "fill")
				{
					int columnIndex = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
					for (int i = 0; i < count; i++)
					{
						int rowIndex = dataGridView_pcbedit.SelectedCells[i].RowIndex;
						if (columnIndex == 11)
						{
							float num = @float - bindingList[rowIndex].A_Real;
							bindingList[rowIndex].A += num;
							while (bindingList[rowIndex].A > 180f)
							{
								bindingList[rowIndex].A -= 360f;
							}
							while (bindingList[rowIndex].A <= -180f)
							{
								bindingList[rowIndex].A += 360f;
							}
						}
						dataGridView_pcbedit.SelectedCells[i].Value = @float;
					}
				}
				else
				{
					for (int j = 0; j < count; j++)
					{
						if (dataGridView_pcbedit.SelectedCells[j].Value == null)
						{
							dataGridView_pcbedit.SelectedCells[j].Value = 0;
						}
						float num2 = 0f;
						try
						{
							num2 = float.Parse(dataGridView_pcbedit.SelectedCells[j].Value.ToString());
						}
						catch (Exception)
						{
							num2 = 0f;
						}
						num2 += @float;
						if (text == "adjust_angle")
						{
							while (num2 > 180f)
							{
								num2 -= 360f;
							}
							for (; num2 <= -180f; num2 += 360f)
							{
							}
							if (mIsPcbCheck)
							{
								int rowIndex2 = dataGridView_pcbedit.SelectedCells[j].RowIndex;
								bindingList[rowIndex2].A += @float;
								while (bindingList[rowIndex2].A > 180f)
								{
									bindingList[rowIndex2].A -= 360f;
								}
								while (bindingList[rowIndex2].A <= -180f)
								{
									bindingList[rowIndex2].A += 360f;
								}
							}
						}
						dataGridView_pcbedit.SelectedCells[j].Value = num2;
					}
				}
				MainForm0.save_usrProjectData();
			}
			else
			{
				if (!text.Contains("adjust_angle_ext"))
				{
					return;
				}
				float num3 = 0f;
				switch (text)
				{
				case "adjust_angle_ext_+90":
					num3 = 90f;
					break;
				case "adjust_angle_ext_-90":
					num3 = -90f;
					break;
				case "adjust_angle_ext_+180":
					num3 = 180f;
					break;
				case "adjust_angle_ext_-180":
					num3 = -180f;
					break;
				}
				for (int k = 0; k < count; k++)
				{
					if (dataGridView_pcbedit.SelectedCells[k].Value == null)
					{
						dataGridView_pcbedit.SelectedCells[k].Value = 0;
					}
					float num4 = 0f;
					try
					{
						num4 = float.Parse(dataGridView_pcbedit.SelectedCells[k].Value.ToString());
					}
					catch (Exception)
					{
						num4 = 0f;
					}
					for (num4 += num3; num4 > 180f; num4 -= 360f)
					{
					}
					for (; num4 <= -180f; num4 += 360f)
					{
					}
					dataGridView_pcbedit.SelectedCells[k].Value = num4;
					if (mIsPcbCheck)
					{
						int rowIndex3 = dataGridView_pcbedit.SelectedCells[k].RowIndex;
						bindingList[rowIndex3].A += num3;
						while (bindingList[rowIndex3].A > 180f)
						{
							bindingList[rowIndex3].A -= 360f;
						}
						while (bindingList[rowIndex3].A <= -180f)
						{
							bindingList[rowIndex3].A += 360f;
						}
					}
				}
				MainForm0.save_usrProjectData();
			}
		}

		private void fill_cells_cameratype_manual_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			CameraType cameratype = (CameraType)toolStripMenuItem.Tag;
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			int columnIndex = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
			if (columnIndex == 15)
			{
				BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
				for (int i = 0; i < count; i++)
				{
					int rowIndex = dataGridView_pcbedit.SelectedCells[i].RowIndex;
					bindingList[rowIndex].Cameratype = cameratype;
				}
				dataGridView_pcbedit.Refresh();
			}
		}

		private void fill_cells_int_manual_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			string text = (string)toolStripMenuItem.Tag;
			string type = "";
			string data_type = "int";
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			int columnIndex = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
			int rowIndex = dataGridView_pcbedit.SelectedCells[0].RowIndex;
			switch (columnIndex)
			{
			case 14:
				data_type = "int";
				if (USR3.mPointListOrder != 1)
				{
					MainForm0.CmMessageBox((new string[3] { "请先按照[贴装排序]!", "請先按照[貼裝排序]!", "SMT(Group) Order is required" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
					return;
				}
				break;
			case 12:
			case 13:
				data_type = "provider_int";
				break;
			}
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
			if (!(text == "fill"))
			{
				return;
			}
			Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, type, data_type);
			if (count == 2 && dataGridView_pcbedit.SelectedCells[0].RowIndex == dataGridView_pcbedit.SelectedCells[1].RowIndex && (columnIndex == 13 || columnIndex == 12))
			{
				form_Fill.set_provider(bindingList[rowIndex].Stacktype);
			}
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			int @int = form_Fill.get_int();
			if (columnIndex == 14)
			{
				if (@int <= 0 || @int > HW.mZnNum[mFn])
				{
					string[] array = new string[3]
					{
						"将要修改的吸嘴号[" + @int + "]不合理，是否继续修改?",
						"將要修改的吸嘴號[" + @int + "]不合理，是否繼續修改?",
						"The modified nozzle No.[" + @int + "] is invalid，continue?"
					};
					if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.No)
					{
						return;
					}
				}
				int group = point_list_smt[point_list_smt.Count - 1].Group;
				int num = 0;
				bool flag = false;
				for (int i = 0; i <= group; i++)
				{
					int num2 = 0;
					for (int j = num; j < point_list_smt.Count; j++)
					{
						if (point_list_smt[j].Group != i)
						{
							num = j;
							break;
						}
						for (int k = 0; k < dataGridView_pcbedit.SelectedCells.Count; k++)
						{
							if (j == dataGridView_pcbedit.SelectedCells[k].RowIndex)
							{
								num2++;
							}
							else if (point_list_smt[j].Nozzle == @int)
							{
								num2++;
							}
						}
						if (num2 > 1)
						{
							string[] array2 = new string[3]
							{
								"将要修改的吸嘴号[" + @int + "]会导致同一轮组有相同吸嘴号冲突，是否继续修改?",
								"將要修改的吸嘴號[" + @int + "]會導致同壹輪組有相同吸嘴號沖突，是否繼續修改?",
								"The modified Nozzle No.[" + @int + "] will cause nozzle conflict in same group, continue?"
							};
							if (MainForm0.CmMessageBox(array2[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
							{
								flag = true;
								break;
							}
							return;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			for (int l = 0; l < count; l++)
			{
				dataGridView_pcbedit.SelectedCells[l].Value = @int;
			}
			if (columnIndex == 13 || columnIndex == 12)
			{
				ProviderType provider = form_Fill.get_provider();
				for (int m = 0; m < count; m++)
				{
					int rowIndex2 = dataGridView_pcbedit.SelectedCells[m].RowIndex;
					bindingList[rowIndex2].Stacktype = provider;
				}
				dataGridView_pcbedit.Refresh();
			}
			MainForm0.save_usrProjectData();
		}

		private void fill_cells_selectall_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			string text = (string)toolStripMenuItem.Tag;
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
			int count = dataGridView_pcbedit.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			int num = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
			int rowIndex = dataGridView_pcbedit.SelectedCells[0].RowIndex;
			switch (count)
			{
			case 2:
			{
				int columnIndex = dataGridView_pcbedit.SelectedCells[0].ColumnIndex;
				int columnIndex2 = dataGridView_pcbedit.SelectedCells[1].ColumnIndex;
				if ((columnIndex == 13 && columnIndex2 == 12) || (columnIndex == 12 && columnIndex2 == 13))
				{
					num = 13;
					break;
				}
				if ((columnIndex == 4 && columnIndex2 == 5) || (columnIndex == 5 && columnIndex2 == 4))
				{
					num = 5;
					break;
				}
				return;
			}
			default:
				return;
			case 1:
				break;
			}
			BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
			BindingList<int> bindingList3 = new BindingList<int>();
			if (text.Contains("int"))
			{
				int num2 = (int)dataGridView_pcbedit.Rows[rowIndex].Cells[num].Value;
				for (int i = 0; i < dataGridView_pcbedit.Rows.Count; i++)
				{
					bool flag = true;
					if (num == 13 && bindingList[i].Stacktype != bindingList[rowIndex].Stacktype)
					{
						flag = false;
					}
					if ((int)dataGridView_pcbedit.Rows[i].Cells[num].Value == num2 && flag)
					{
						dataGridView_pcbedit.Rows[i].Selected = true;
						if (text.Contains("list"))
						{
							bindingList2.Add(bindingList[i]);
							bindingList3.Add(i);
						}
					}
				}
			}
			else if (text.Contains("string"))
			{
				string text2 = (string)dataGridView_pcbedit.Rows[rowIndex].Cells[num].Value;
				for (int j = 0; j < dataGridView_pcbedit.Rows.Count; j++)
				{
					bool flag2 = true;
					if (count == 2 && num == 5 && bindingList[j].Material_value != bindingList[rowIndex].Material_value)
					{
						flag2 = false;
					}
					if ((string)dataGridView_pcbedit.Rows[j].Cells[num].Value == text2 && flag2)
					{
						dataGridView_pcbedit.Rows[j].Selected = true;
						if (text.Contains("list"))
						{
							bindingList2.Add(bindingList[j]);
							bindingList3.Add(j);
						}
					}
				}
			}
			if (text.Contains("list") && bindingList2.Count > 0)
			{
				Form_SearchExt form_SearchExt = new Form_SearchExt(mFn, USR, USR2, USR3, bindingList2, mIsPcbCheck, mIsEditEnable);
				form_SearchExt.ShowDialog();
				dataGridView_pcbedit.ClearSelection();
				dataGridView_pcbedit.Refresh();
				for (int k = 0; k < bindingList3.Count; k++)
				{
					int index = bindingList3[k];
					dataGridView_pcbedit.Rows[index].Selected = true;
				}
			}
		}

		private void button_pcbedit_movetoxy_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string tag = (string)button.Tag;
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				if (!pcbedit_movetoxy_click(tag))
				{
					MainForm0.mMutexMoveXYZA = false;
				}
			}
		}

		private bool pcbedit_movetoxy_click(string tag)
		{
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 1) ? point_list_smt : point_list);
			if (dataGridView_pcbedit.SelectedRows.Count == 1)
			{
				mPointCurIndex = dataGridView_pcbedit.SelectedRows[0].Index;
			}
			else
			{
				int count = dataGridView_pcbedit.SelectedCells.Count;
				if (count < 1)
				{
					return false;
				}
				int rowIndex = dataGridView_pcbedit.SelectedCells[0].RowIndex;
				for (int i = 0; i < count; i++)
				{
					if (rowIndex != dataGridView_pcbedit.SelectedCells[i].RowIndex)
					{
						return false;
					}
				}
				mPointCurIndex = rowIndex;
			}
			int index = mPointCurIndex;
			if (tag == "next")
			{
				index = ((mPointCurIndex >= dataGridView_pcbedit.RowCount - 1) ? mPointCurIndex : (mPointCurIndex + 1));
			}
			else if (tag == "prev")
			{
				index = ((mPointCurIndex <= 0) ? mPointCurIndex : (mPointCurIndex - 1));
			}
			int num = (int)bindingList[index].X;
			int num2 = (int)bindingList[index].Y;
			float num3 = bindingList[index].A;
			if (mIsPcbCheck)
			{
				num = (int)bindingList[index].X_Real;
				num2 = (int)bindingList[index].Y_Real;
				num3 = bindingList[index].A_Real;
			}
			if (tag.Contains("_byzn"))
			{
				int num4 = bindingList[index].Nozzle - 1;
				if (num4 < 0 || num4 >= HW.mZnNum[mFn])
				{
					MainForm0.CmMessageBoxTop_Ok((new string[3] { "错误吸嘴号!", "錯誤吸嘴號!", "Error Nozzle No.!" })[USR_INIT.mLanguage]);
					return false;
				}
				num -= (int)USR.mDeltaNozzle[0][num4].X;
				num2 -= (int)USR.mDeltaNozzle[0][num4].Y;
				MainForm0.radiobt_zn[mFn][num4].Checked = true;
				Thread.Sleep(15);
			}
			while (num3 > 180f)
			{
				num3 -= 360f;
			}
			for (; num3 <= -180f; num3 += 360f)
			{
			}
			if (num >= 0 && num2 >= 0)
			{
				if (num >= 0 && num2 >= 0)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
					Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
					thread.IsBackground = true;
					thread.Start(new Coordinate(num, num2));
					MainForm0.uc_usroperarion[mFn].set_chipBox(USR.mBoxWidth, USR.mBoxHeight, num3);
				}
				MainForm0.vsplus_pcbedit_gotoxy_post(mFn, num, num2, num3);
				if (tag == "next")
				{
					if (mPointCurIndex >= dataGridView_pcbedit.RowCount - 1)
					{
						dataGridView_pcbedit.Rows[mPointCurIndex].Selected = true;
						dataGridView_pcbedit.Refresh();
					}
					else
					{
						int num5 = mPointCurIndex;
						dataGridView_pcbedit.Rows[num5].Selected = false;
						dataGridView_pcbedit.Rows[num5 + 1].Selected = true;
						mPointCurIndex = num5 + 1;
						label_pcbedit_index.Text = mPointCurIndex + 1 + "/" + dataGridView_pcbedit.RowCount;
						dataGridView_pcbedit.Refresh();
					}
				}
				else if (tag == "prev")
				{
					if (mPointCurIndex <= 0)
					{
						dataGridView_pcbedit.Rows[mPointCurIndex].Selected = true;
						dataGridView_pcbedit.Refresh();
					}
					else
					{
						int num6 = mPointCurIndex;
						dataGridView_pcbedit.Rows[num6].Selected = false;
						dataGridView_pcbedit.Rows[num6 - 1].Selected = true;
						mPointCurIndex = num6 - 1;
						label_pcbedit_index.Text = mPointCurIndex + 1 + "/" + dataGridView_pcbedit.RowCount;
						dataGridView_pcbedit.Refresh();
					}
				}
				else
				{
					dataGridView_pcbedit.Rows[mPointCurIndex].Selected = true;
					dataGridView_pcbedit.Refresh();
				}
				return true;
			}
			return false;
		}

		private void button_PCBE_fackPCB_Click(object sender, EventArgs e)
		{
			if (USR3 != null && point_list != null)
			{
				BindingList<ChipUnit_F> bindingList = new BindingList<ChipUnit_F>();
				for (int i = 0; i < point_list.Count; i++)
				{
					ChipUnit_F chipUnit_F = new ChipUnit_F();
					chipUnit_F.X = point_list[i].X;
					chipUnit_F.Y = point_list[i].Y;
					chipUnit_F.A = point_list[i].A;
					chipUnit_F.Label = point_list[i].Labeltab;
					bindingList.Add(chipUnit_F);
				}
				Form_PcbView form_PcbView = new Form_PcbView(USR_INIT.mLanguage, "pcbedit", bindingList, null, is_priciseimport: false, null, USR3.mMark);
				form_PcbView.ShowDialog();
			}
		}

		private void button_exportPCBlist_Click(object sender, EventArgs e)
		{
			Form_Export form_Export = new Form_Export();
			DialogResult dialogResult = form_Export.ShowDialog();
			if (dialogResult != DialogResult.Yes && dialogResult != DialogResult.OK)
			{
				return;
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (dialogResult == DialogResult.Yes)
			{
				saveFileDialog.Filter = (new string[3] { "文本文件（*.txt）|*.txt", "文本文件（*.txt）|*.txt", "TEXT（*.txt）|*.txt" })[USR_INIT.mLanguage];
			}
			else
			{
				saveFileDialog.Filter = (new string[3] { "表格文件（*.csv）|*.csv", "表格文件（*.csv）|*.csv", "EXCEL（*.csv）|*.csv" })[USR_INIT.mLanguage];
			}
			string text = ((dialogResult == DialogResult.Yes) ? "\t" : ",");
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
				StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.GetEncoding("gb2312"));
				streamWriter.Write("MARK1" + text + "MARK1" + text + "MARK1" + text + USR3.mMark[0].X + text + -USR3.mMark[0].Y + text + "0" + Environment.NewLine);
				streamWriter.Write("MARK2" + text + "MARK2" + text + "MARK2" + text + USR3.mMark[1].X + text + -USR3.mMark[1].Y + text + "0" + Environment.NewLine);
				for (int i = 0; i < point_list.Count; i++)
				{
					streamWriter.Write(point_list[i].Labeltab + text + point_list[i].Material_value + text + point_list[i].Footprint + text + point_list[i].X + text + -point_list[i].Y + text + point_list[i].A + Environment.NewLine);
					streamWriter.Flush();
				}
				streamWriter.Close();
				fileStream.Close();
				MainForm0.CmMessageBox((new string[3] { "导出坐标文件完成！", "導出坐標文件完成！", "Export data list Done!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
			}
		}

		private void button_movedown_Click(object sender, EventArgs e)
		{
			string text = (string)((Button)sender).Tag;
			if (dataGridView_pcbedit.SelectedRows.Count == 1)
			{
				mPointCurIndex = dataGridView_pcbedit.SelectedRows[0].Index;
				int index = ((text == "down") ? (mPointCurIndex + 1) : (mPointCurIndex - 1));
				BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 1) ? point_list_smt : point_list);
				if (bindingList.Count <= 1)
				{
					return;
				}
				if (text == "down")
				{
					if (mPointCurIndex >= bindingList.Count - 1)
					{
						return;
					}
				}
				else if (text == "up" && mPointCurIndex <= 0)
				{
					return;
				}
				if (USR3.mPointListOrder == 1)
				{
					if (bindingList[mPointCurIndex].Group != bindingList[index].Group)
					{
						goto IL_0219;
					}
				}
				else if (bindingList[mPointCurIndex].Arrayno != bindingList[index].Arrayno)
				{
					return;
				}
				ChipBoardElement item = bindingList[mPointCurIndex];
				bindingList.RemoveAt(mPointCurIndex);
				bindingList.Insert(index, item);
				bool flag = ((USR3.mPointListOrder == 1) ? ((bindingList[index].Group - 1) % 2 == 1) : (bindingList[index].Arrayno % 2 == 1));
				Color backColor = ((!bindingList[index].isOptimization) ? (flag ? Color.FromArgb(180, 180, 180) : Color.FromArgb(220, 220, 220)) : (flag ? Color.LightYellow : Color.NavajoWhite));
				dataGridView_pcbedit.Rows[index].DefaultCellStyle.BackColor = backColor;
				dataGridView_pcbedit.Rows[mPointCurIndex].Selected = false;
				dataGridView_pcbedit.Rows[index].Selected = true;
				dataGridView_pcbedit.Refresh();
				MainForm0.save_usrProjectData();
				return;
			}
			goto IL_0219;
			IL_0219:
			itemsub_group_move(text, is_messagebox: false);
		}

		private void toolStripMenuItem_pcbedit_select_Click(object sender, EventArgs e)
		{
			string text = (string)((ToolStripMenuItem)sender).Tag;
			int count = dataGridView_pcbedit.SelectedRows.Count;
			if (count <= 0 || USR3 == null)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
			if (bindingList != null && bindingList.Count > 0)
			{
				int firstDisplayedScrollingRowIndex = dataGridView_pcbedit.FirstDisplayedScrollingRowIndex;
				BindingList<int> bindingList2 = new BindingList<int>();
				for (int i = 0; i < count; i++)
				{
					int index = dataGridView_pcbedit.SelectedRows[i].Index;
					bindingList[index].Ismount = ((text == "check") ? true : false);
					bindingList2.Add(index);
				}
				dataGridView_pcbedit.CurrentCell = dataGridView_pcbedit.Rows[bindingList2[0]].Cells[2];
				for (int j = 0; j < count; j++)
				{
					dataGridView_pcbedit.Rows[bindingList2[j]].Selected = true;
				}
				dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
				dataGridView_pcbedit.Refresh();
				MainForm0.save_usrProjectData();
			}
		}

		private void ToolStripMenuItem_selectlist_Click(object sender, EventArgs e)
		{
			int count = dataGridView_pcbedit.SelectedRows.Count;
			if (count <= 0)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 1) ? point_list_smt : point_list);
			if (bindingList == null && bindingList.Count <= 0)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
			BindingList<int> bindingList3 = new BindingList<int>();
			for (int i = 0; i < count; i++)
			{
				int index = dataGridView_pcbedit.SelectedRows[i].Index;
				bindingList2.Add(bindingList[index]);
				bindingList3.Add(index);
			}
			if (bindingList2.Count > 0)
			{
				Form_SearchExt form_SearchExt = new Form_SearchExt(mFn, USR, USR2, USR3, bindingList2, mIsPcbCheck, mIsEditEnable);
				form_SearchExt.ShowDialog();
				dataGridView_pcbedit.ClearSelection();
				dataGridView_pcbedit.Refresh();
				for (int j = 0; j < bindingList3.Count; j++)
				{
					int index2 = bindingList3[j];
					dataGridView_pcbedit.Rows[index2].Selected = true;
				}
			}
		}

		private void ToolStripMenuItem_movetoxy_Click(object sender, EventArgs e)
		{
			int num = (int)((ToolStripMenuItem)sender).Tag;
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				if (!pcbedit_movetoxy_click((num == 1) ? "cur_byzn" : "cur"))
				{
					MainForm0.mMutexMoveXYZA = false;
				}
			}
		}

		public void SetEdit_XY(bool flag)
		{
			mIsEditEnable = flag;
			if (mIsEditEnable)
			{
				dataGridView_pcbedit.Columns[6].HeaderText = STR.PCB_HEAD[6].str[USR_INIT.mLanguage];
				dataGridView_pcbedit.Columns[7].HeaderText = STR.PCB_HEAD[7].str[USR_INIT.mLanguage];
				button_pcbCheck.Visible = false;
				if (uc_pcbedit_array != null && !uc_pcbedit_array.IsDisposed)
				{
					uc_pcbedit_array.set_IsEditEnable(mIsEditEnable);
				}
				return;
			}
			button_pcbCheck.Visible = true;
			dataGridView_pcbedit.Columns[6].HeaderText = STR.PCB_HEAD[6].str[USR_INIT.mLanguage] + Environment.NewLine + (new string[3] { "锁定", "鎖定", "Locked" })[USR_INIT.mLanguage];
			dataGridView_pcbedit.Columns[7].HeaderText = STR.PCB_HEAD[7].str[USR_INIT.mLanguage] + Environment.NewLine + (new string[3] { "锁定", "鎖定", "Locked" })[USR_INIT.mLanguage];
			if (uc_pcbedit_array != null && !uc_pcbedit_array.IsDisposed)
			{
				uc_pcbedit_array.set_IsEditEnable(mIsEditEnable);
			}
		}

		public bool GetEdit_XY()
		{
			return mIsEditEnable;
		}

		private void ToolStripMenuItem_savexy_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mIsBoardFixed)
			{
				MainForm0.CmMessageBoxTop_Ok((new string[3] { "未夹板!", "未夾板!", "PCB board is not fixed" })[USR_INIT.mLanguage]);
			}
			else if (!mIsEditEnable && !mIsPcbCheck)
			{
				string[] array = new string[3]
				{
					"不可以更新坐标!" + Environment.NewLine + "如要更新坐标，请先进板夹板之后使用[进板查看]功能，或者[PCB校正]功能!",
					"不可以更新坐標!" + Environment.NewLine + "如要更新坐標，請先進板夾板之後使用[進板查看]功能，或者[PCB校正]功能!",
					"Update XY coord fail!" + Environment.NewLine + "PCB inboard check page can update XY coord"
				};
				MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
			}
			else
			{
				if (MainForm0.CmMessageBox((new string[3] { "是否确定更新XY坐标", "是否確定更新XY坐標", "Update XY?" })[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
				BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 1) ? point_list_smt : point_list);
				if (dataGridView_pcbedit.SelectedRows.Count == 1)
				{
					if (mIsPcbCheck)
					{
						Coordinate coordinate = new Coordinate(0L, 0L);
						coordinate.X = MainForm0.mCur[mFn].x;
						coordinate.Y = MainForm0.mCur[mFn].y;
						bindingList[dataGridView_pcbedit.SelectedRows[0].Index].X_Real = coordinate.X;
						bindingList[dataGridView_pcbedit.SelectedRows[0].Index].Y_Real = coordinate.Y;
						Coordinate coordinate2 = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, coordinate);
						bindingList[dataGridView_pcbedit.SelectedRows[0].Index].X = (int)coordinate2.X;
						bindingList[dataGridView_pcbedit.SelectedRows[0].Index].Y = (int)coordinate2.Y;
					}
					else
					{
						bindingList[dataGridView_pcbedit.SelectedRows[0].Index].X = MainForm0.mCur[mFn].x;
						bindingList[dataGridView_pcbedit.SelectedRows[0].Index].Y = MainForm0.mCur[mFn].y;
					}
					dataGridView_pcbedit.Refresh();
				}
				else
				{
					int count = dataGridView_pcbedit.SelectedCells.Count;
					if (count > 0)
					{
						int rowIndex = dataGridView_pcbedit.SelectedCells[0].RowIndex;
						for (int i = 0; i < count; i++)
						{
							if (rowIndex != dataGridView_pcbedit.SelectedCells[i].RowIndex)
							{
								return;
							}
						}
						if (mIsPcbCheck)
						{
							Coordinate coordinate3 = new Coordinate(0L, 0L);
							coordinate3.X = MainForm0.mCur[mFn].x;
							coordinate3.Y = MainForm0.mCur[mFn].y;
							bindingList[rowIndex].X_Real = coordinate3.X;
							bindingList[rowIndex].Y_Real = coordinate3.Y;
							Coordinate coordinate4 = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, coordinate3);
							bindingList[rowIndex].X = (int)coordinate4.X;
							bindingList[rowIndex].Y = (int)coordinate4.Y;
						}
						else
						{
							bindingList[rowIndex].X = MainForm0.mCur[mFn].x;
							bindingList[rowIndex].Y = MainForm0.mCur[mFn].y;
						}
						dataGridView_pcbedit.Rows[rowIndex].Selected = true;
						dataGridView_pcbedit.Refresh();
					}
				}
				MainForm0.save_usrProjectData();
			}
		}

		private void ToolStripMenuItem_group_down_Click(object sender, EventArgs e)
		{
			string tag = (string)((ToolStripMenuItem)sender).Tag;
			itemsub_group_move(tag, is_messagebox: true);
		}

		private void itemsub_group_move(string tag, bool is_messagebox)
		{
			if (USR3.mPointListOrder == 0)
			{
				if (is_messagebox)
				{
					MainForm0.CmMessageBox((new string[3] { "请按照轮组排序!", "請按照輪組排序!", "SMT(Group) Order is Required!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
				}
				return;
			}
			switch (tag)
			{
			case "down":
			case "up":
			case "end":
			case "begin":
			{
				int count = dataGridView_pcbedit.SelectedRows.Count;
				if (count <= 0)
				{
					return;
				}
				int group = point_list_smt[dataGridView_pcbedit.SelectedRows[0].Index].Group;
				int num = dataGridView_pcbedit.SelectedRows[0].Index;
				int num2 = dataGridView_pcbedit.SelectedRows[0].Index;
				for (int i = 0; i < count; i++)
				{
					int index = dataGridView_pcbedit.SelectedRows[i].Index;
					if (index < num)
					{
						num = index;
					}
					if (index > num2)
					{
						num2 = index;
					}
					if (point_list_smt[index].Group != group)
					{
						if (is_messagebox)
						{
							MainForm0.CmMessageBox((new string[3] { "请完整选中整个轮组!", "請完整選中整個輪組!", "Please Select a complete group!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
						}
						return;
					}
				}
				if (num > 0)
				{
					int index2 = num - 1;
					if (point_list_smt[index2].Group == group)
					{
						if (is_messagebox)
						{
							MainForm0.CmMessageBox((new string[3] { "请完整选中整个轮组!", "請完整選中整個輪組!", "Please Select a complete group!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
						}
						return;
					}
				}
				if (num2 < point_list_smt.Count - 1)
				{
					int index3 = num2 + 1;
					if (point_list_smt[index3].Group == group)
					{
						if (is_messagebox)
						{
							MainForm0.CmMessageBox((new string[3] { "请完整选中整个轮组!", "請完整選中整個輪組!", "Please Select a complete group!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
						}
						return;
					}
				}
				int num3 = 0;
				switch (tag)
				{
				case "down":
				case "up":
				{
					num3 = ((tag == "down") ? (group + 1) : (group - 1));
					int num4 = 0;
					if (tag == "down")
					{
						for (int l = num2; l < point_list_smt.Count; l++)
						{
							if (point_list_smt[l].Group == num3)
							{
								num4++;
							}
							else if (point_list_smt[l].Group > num3)
							{
								break;
							}
						}
						if (num4 == 0)
						{
							return;
						}
						for (int m = 0; m < count; m++)
						{
							ChipBoardElement item3 = point_list_smt[num];
							point_list_smt.RemoveAt(num);
							int index6 = num + count + num4 - 1;
							point_list_smt.Insert(index6, item3);
						}
						break;
					}
					for (int num5 = num; num5 >= 0; num5--)
					{
						if (point_list_smt[num5].Group == num3)
						{
							num4++;
						}
						else if (point_list_smt[num5].Group < num3)
						{
							break;
						}
					}
					if (num4 == 0)
					{
						return;
					}
					for (int n = 0; n < count; n++)
					{
						ChipBoardElement item4 = point_list_smt[num2];
						point_list_smt.RemoveAt(num2);
						int index7 = num2 - count - num4 + 1;
						point_list_smt.Insert(index7, item4);
					}
					break;
				}
				case "end":
				{
					int count2 = point_list_smt.Count;
					num3 = point_list_smt[count2 - 1].Group;
					if (group == num3)
					{
						return;
					}
					for (int k = 0; k < count; k++)
					{
						ChipBoardElement item2 = point_list_smt[num];
						point_list_smt.RemoveAt(num);
						int index5 = count2 - 1;
						point_list_smt.Insert(index5, item2);
					}
					break;
				}
				case "begin":
				{
					_ = point_list_smt.Count;
					num3 = 0;
					if (group == 0)
					{
						return;
					}
					for (int j = 0; j < count; j++)
					{
						ChipBoardElement item = point_list_smt[num2];
						point_list_smt.RemoveAt(num2);
						int index4 = 0;
						point_list_smt.Insert(index4, item);
					}
					break;
				}
				}
				int firstDisplayedScrollingRowIndex = dataGridView_pcbedit.FirstDisplayedScrollingRowIndex;
				MainForm0.pcbsmt_refresh_groups(USR3);
				MainForm0.pcbsmt_update_Groups(USR3);
				PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
				dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
				if (tag == "down")
				{
					for (int num6 = num; num6 < point_list_smt.Count; num6++)
					{
						if (point_list_smt[num6].Group == num3)
						{
							dataGridView_pcbedit.Rows[num6].Selected = true;
						}
						else if (point_list_smt[num6].Group > num3)
						{
							break;
						}
					}
					break;
				}
				if (tag == "up")
				{
					for (int num7 = num2; num7 >= 0; num7--)
					{
						if (point_list_smt[num7].Group == num3)
						{
							dataGridView_pcbedit.Rows[num7].Selected = true;
						}
						else if (point_list_smt[num7].Group < num3)
						{
							break;
						}
					}
					break;
				}
				for (int num8 = point_list_smt.Count - 1; num8 >= 0; num8--)
				{
					if (point_list_smt[num8].Group == num3)
					{
						dataGridView_pcbedit.Rows[num8].Selected = true;
					}
					else if (point_list_smt[num8].Group < num3)
					{
						break;
					}
				}
				dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = point_list_smt.Count - 1;
				break;
			}
			}
			MainForm0.save_usrProjectData();
		}

		private void ToolStripMenuItem_group_orderbyheight_Click(object sender, EventArgs e)
		{
			MainForm0.CmMessageBox((new string[3] { "功能研发中，敬请期待!", "功能研發中，敬請期待!", "Function in Developing!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
		}

		private void ToolStripMenuItem_insert_down_Click(object sender, EventArgs e)
		{
			MainForm0.CmMessageBox((new string[3] { "功能研发中，敬请期待!", "功能研發中，敬請期待!", "Function in Developing!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
		}

		private void ToolStripMenuItem_group_combine_Click(object sender, EventArgs e)
		{
			if (USR3.mPointListOrder == 0)
			{
				string[] array = new string[3] { "请点击[按贴装排序]，然后再[合并贴装轮组]!", "請點擊[按貼裝排序]，然後再[合並貼裝輪組]!", "Please click [Order in Group] firstly, and then [Combine Groups]!" };
				MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.OK);
				return;
			}
			int count = dataGridView_pcbedit.SelectedRows.Count;
			if (count >= 1 && count <= HW.mZnNum[mFn])
			{
				BindingList<ChipBoardElement> bindingList = point_list_smt;
				BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
				int num = 0;
				int num2 = point_list_smt.Count - 1;
				int firstDisplayedScrollingRowIndex = dataGridView_pcbedit.FirstDisplayedScrollingRowIndex;
				for (int i = 0; i < count; i++)
				{
					num = dataGridView_pcbedit.SelectedRows[count - i - 1].Index;
					bindingList2.Add(bindingList[num]);
					if (num < num2)
					{
						num2 = num;
					}
				}
				Form_CombinGroups form_CombinGroups = new Form_CombinGroups(mFn, USR, USR2, USR3, bindingList2, USR3B.mFeederInstallList, mIsPcbCheck, mIsEditEnable);
				int group = point_list_smt[point_list_smt.Count - 1].Group + 1;
				int num3 = -10;
				for (int j = 0; j < bindingList2.Count; j++)
				{
					if (bindingList2[j].samePikNo > num3)
					{
						num3 = bindingList2[j].samePikNo;
					}
				}
				num3++;
				if (form_CombinGroups.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				for (int k = 0; k < bindingList2.Count; k++)
				{
					bindingList2[k].Group = group;
				}
				if (form_CombinGroups.get_IsForceSamePik())
				{
					for (int l = 0; l < bindingList2.Count; l++)
					{
						bindingList2[l].samePikNo = num3;
					}
				}
				for (int m = 0; m < bindingList2.Count; m++)
				{
					point_list_smt.Remove(bindingList2[m]);
				}
				for (int num4 = bindingList2.Count - 1; num4 >= 0; num4--)
				{
					point_list_smt.Insert(num2, bindingList2[num4]);
				}
				null_pcbedit_editlist();
				MainForm0.pcbsmt_refresh_groups(USR3);
				PCBE_List_Show(USR3.mPointListOrder, is_reflush: true);
				dataGridView_pcbedit.ClearSelection();
				for (int n = 0; n < bindingList2.Count; n++)
				{
					dataGridView_pcbedit.Rows[num2 + n].Selected = true;
				}
				dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
				MainForm0.save_usrProjectData();
			}
			else
			{
				string[] array2 = new string[3]
				{
					"合并贴装轮组: 必须要选择1个或1个以上,并且" + HW.mZnNum[mFn] + "个或" + HW.mZnNum[mFn] + "个以下的元件条目！",
					"合並貼裝輪組: 必須要選擇1個或1個以上,並且" + HW.mZnNum[mFn] + "個或" + HW.mZnNum[mFn] + "個以下的元件條目！",
					"Combine Groups: need more than 2 items, and less than" + HW.mZnNum[mFn] + " items"
				};
				MainForm0.CmMessageBox(array2[USR_INIT.mLanguage], MessageBoxButtons.OK);
			}
		}

		private void dataGridView_pcbedit_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			int num = -1;
			if (dataGridView_pcbedit.SelectedCells.Count > 0)
			{
				num = dataGridView_pcbedit.SelectedCells[0].RowIndex;
			}
			if (num < 0)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList = new BindingList<ChipBoardElement>();
			ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage);
			bindingList.Add(chipBoardElement);
			ChipBoardElement chipBoardElement2 = ((USR3.mPointListOrder == 0) ? point_list[num] : point_list_smt[num]);
			MainForm0.Copy_ChipBoardElement(chipBoardElement, chipBoardElement2, 0, isguid: true);
			Form_PCBedit form_PCBedit = new Form_PCBedit(USR_INIT.mLanguage, bindingList, mIsPcbCheck);
			if (form_PCBedit.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			if (USR3.mArrayPCBRow > 1 || USR3.mArrayPCBColumn > 1)
			{
				Form_BoxSel form_BoxSel = new Form_BoxSel((new string[3] { "元件项目修改", "元件項目修改", "Chip Item Modify" })[USR_INIT.mLanguage], (new string[3] { "同时修改其他拼板", "同時修改其他拼板", "Modify all boards array chip" })[USR_INIT.mLanguage], (new string[3] { "只修改当前元件", "只修改當前元件", "Only Modify current board chip" })[USR_INIT.mLanguage], (new string[3] { "说明：料站号，吸嘴号，贴装轮组无法同步", "說明：料站號，吸嘴號，貼裝輪組無法同步", "Note: Feeder/Nozzle/Group No.cannot be modified on other array board" })[USR_INIT.mLanguage]);
				switch (form_BoxSel.ShowDialog())
				{
				case DialogResult.OK:
				{
					long num2 = chipBoardElement.X - chipBoardElement2.X;
					long num3 = chipBoardElement.Y - chipBoardElement2.Y;
					if (mIsPcbCheck)
					{
						num2 = chipBoardElement.X_Real - chipBoardElement2.X_Real;
						num3 = chipBoardElement.Y_Real - chipBoardElement2.Y_Real;
						Coordinate coordinate2 = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(chipBoardElement.X_Real, chipBoardElement.Y_Real));
						chipBoardElement.X = coordinate2.X;
						chipBoardElement.Y = coordinate2.Y;
						chipBoardElement.A = chipBoardElement.A_Real + (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
					}
					int arrayno = chipBoardElement2.Arrayno;
					string labeltab = chipBoardElement2.Labeltab;
					string material_value = chipBoardElement2.Material_value;
					string footprint = chipBoardElement2.Footprint;
					string guid = chipBoardElement2.Guid;
					bool isAix = chipBoardElement2.isAix;
					MainForm0.Copy_ChipBoardElement(chipBoardElement2, chipBoardElement, 0, isguid: true);
					for (int i = 0; i < point_list.Count; i++)
					{
						if (material_value == point_list[i].Material_value && footprint == point_list[i].Footprint && labeltab == point_list[i].Labeltab && arrayno != point_list[i].Arrayno && isAix == point_list[i].isAix && guid == point_list[i].Guid)
						{
							long num4 = 0L;
							long num5 = 0L;
							if (mIsPcbCheck)
							{
								num4 = point_list[i].X_Real + num2;
								num5 = point_list[i].Y_Real + num3;
								MainForm0.Copy_ChipBoardElement(point_list[i], chipBoardElement, 1, isguid: true);
								point_list[i].X_Real = num4;
								point_list[i].Y_Real = num5;
								Coordinate coordinate3 = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(num4, num5));
								point_list[i].X = coordinate3.X;
								point_list[i].Y = coordinate3.Y;
								point_list[i].A = point_list[i].A_Real + (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
							}
							else
							{
								num4 = point_list[i].X + num2;
								num5 = point_list[i].Y + num3;
								MainForm0.Copy_ChipBoardElement(point_list[i], chipBoardElement, 1, isguid: true);
								point_list[i].X = num4;
								point_list[i].Y = num5;
							}
						}
					}
					dataGridView_pcbedit.Refresh();
					MainForm0.CmMessageBox((new string[3] { "已完成该元件在所有拼板上的改动！", "已完成該元件在所有拼板上的改動！", "Complete!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
					break;
				}
				case DialogResult.Yes:
					if (mIsPcbCheck)
					{
						Coordinate coordinate = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(chipBoardElement.X_Real, chipBoardElement.Y_Real));
						chipBoardElement.X = coordinate.X;
						chipBoardElement.Y = coordinate.Y;
						chipBoardElement.A = chipBoardElement.A_Real + (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
					}
					MainForm0.Copy_ChipBoardElement(chipBoardElement2, chipBoardElement, 0, isguid: true);
					dataGridView_pcbedit.Refresh();
					break;
				}
			}
			else
			{
				if (mIsPcbCheck)
				{
					Coordinate coordinate4 = MainForm0.uc_job[mFn].fun_newxy(USR3.mPcbCheck.mMark, USR3.mMark, new Coordinate(chipBoardElement.X_Real, chipBoardElement.Y_Real));
					chipBoardElement.X = coordinate4.X;
					chipBoardElement.Y = coordinate4.Y;
					chipBoardElement.A = chipBoardElement.A_Real + (float)(MainForm0.uc_job[mFn].fun_angle(USR3.mPcbCheck.mMark, USR3.mMark) * 180.0 / Math.PI);
				}
				MainForm0.Copy_ChipBoardElement(chipBoardElement2, chipBoardElement, 0, isguid: true);
				dataGridView_pcbedit.Refresh();
			}
			MainForm0.uc_job[mFn].draw_fakePcbBoard(USR3);
		}

		private void ToolStripMenuItem_bulk_add_Click(object sender, EventArgs e)
		{
			if (USR3.mPointListOrder != 0)
			{
				MainForm0.CmMessageBox((new string[3] { "该操作只在“按拼板排序”下才能进行！", "该操作只在“按拼板排序”下才能进行！", "Please click ArrayOrder!" })[USR_INIT.mLanguage], MessageBoxButtons.OK);
				return;
			}
			int count = dataGridView_pcbedit.SelectedRows.Count;
			if (count <= 0)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList = point_list;
			BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
			bindingList2.Clear();
			for (int i = 0; i < count; i++)
			{
				int index = dataGridView_pcbedit.SelectedRows[count - 1 - i].Index;
				if (bindingList[index].Arrayno != 0)
				{
					MainForm0.CmMessageBoxTop_Ok((new string[3] { "只有拼板1-1上的元件才能被批量阵列！", "只有拼板1-1上的元件才能被批量陣列！", "Only chips on PCB 1-1 can be Bulk-Added!" })[USR_INIT.mLanguage]);
					return;
				}
				bindingList2.Add(bindingList[index]);
			}
			dataGridView_pcbedit.Enabled = false;
			UserControl_pcbedit_bulkadd userControl_pcbedit_bulkadd = new UserControl_pcbedit_bulkadd(USR, USR3, dataGridView_pcbedit, bindingList2);
			base.Controls.Add(userControl_pcbedit_bulkadd);
			userControl_pcbedit_bulkadd.PCBE_List_Show += PCBE_List_Show;
			userControl_pcbedit_bulkadd.Location = dataGridView_pcbedit.Location;
			userControl_pcbedit_bulkadd.BringToFront();
			userControl_pcbedit_bulkadd.Show();
			MainForm0.uc_job[mFn].draw_fakePcbBoard(USR3);
		}

		private void button_pcbArray_Click(object sender, EventArgs e)
		{
			open_uc_pcbedit_array();
		}

		public void open_uc_pcbedit_array()
		{
			if (uc_pcbedit_array == null || uc_pcbedit_array.IsDisposed)
			{
				uc_pcbedit_array = new UserControl_pcbedit_array(USR, USR3, dataGridView_pcbedit, mIsEditEnable);
				base.Controls.Add(uc_pcbedit_array);
				uc_pcbedit_array.PCBE_List_Show += PCBE_List_Show;
				uc_pcbedit_array.Location = new Point(0, 0);
				uc_pcbedit_array.BringToFront();
				uc_pcbedit_array.Show();
				MainForm0.mIsOpen_PcbArrayPage = true;
			}
		}

		public void close_uc_pcbedit_array()
		{
			if (uc_pcbedit_array != null && !uc_pcbedit_array.IsDisposed)
			{
				uc_pcbedit_array.Dispose();
				uc_pcbedit_array = null;
				MainForm0.mIsOpen_PcbArrayPage = false;
				MainForm0.uc_job[mFn].draw_fakePcbBoard(USR3);
			}
		}

		private void button_PCBE_Mark_Click(object sender, EventArgs e)
		{
			open_uc_pcbedit_mark();
		}

		public void open_uc_pcbedit_mark()
		{
			if (uc_pcbedit_mark == null || uc_pcbedit_mark.IsDisposed)
			{
				uc_pcbedit_mark = new UserControl_pcbedit_mark(mFn, USR, USR3);
				base.Controls.Add(uc_pcbedit_mark);
				uc_pcbedit_mark.SetEdit_XY += SetEdit_XY;
				uc_pcbedit_mark.GetEdit_XY += GetEdit_XY;
				uc_pcbedit_mark.Location = new Point(0, 0);
				uc_pcbedit_mark.BringToFront();
				uc_pcbedit_mark.Show();
				MainForm0.mIsOpen_PcbMarkPage = true;
			}
		}

		public void update_uc_pcbedit_mark()
		{
			if (uc_pcbedit_mark != null && !uc_pcbedit_mark.IsDisposed)
			{
				uc_pcbedit_mark.flush_data();
			}
		}

		public void close_uc_pcbedit_mark()
		{
			if (uc_pcbedit_mark != null && !uc_pcbedit_mark.IsDisposed)
			{
				uc_pcbedit_mark.Dispose();
				uc_pcbedit_mark = null;
				MainForm0.mIsOpen_PcbMarkPage = false;
			}
		}

		private void button_backto_loadscreen_Click(object sender, EventArgs e)
		{
			display_uc_pcbedit_import(flag: true);
		}

		public void open_uc_pcbedit_import()
		{
			if (uc_pcbedit_import == null || uc_pcbedit_import.IsDisposed)
			{
				uc_pcbedit_import = new UserControl_pcbedit_import(mFn, USR, USR2, USR3);
				base.Controls.Add(uc_pcbedit_import);
				uc_pcbedit_import.null_pcbedit_editlist += null_pcbedit_editlist;
				uc_pcbedit_import.init_pcbedit_editlist += init_pcbedit_editlist;
				uc_pcbedit_import.PCBE_List_Show += PCBE_List_Show;
				uc_pcbedit_import.SetEdit_XY += SetEdit_XY;
				uc_pcbedit_import.Location = new Point(0, 0);
				uc_pcbedit_import.BringToFront();
				uc_pcbedit_import.Show();
				MainForm0.mIsOpen_PcbImportPage = true;
			}
		}

		public void close_uc_pcbedit_import()
		{
			if (uc_pcbedit_import != null && !uc_pcbedit_import.IsDisposed)
			{
				uc_pcbedit_import.Dispose();
				uc_pcbedit_import = null;
				MainForm0.mIsOpen_PcbImportPage = false;
			}
		}

		public void display_uc_pcbedit_import(bool flag)
		{
			if (uc_pcbedit_import != null && !uc_pcbedit_import.IsDisposed)
			{
				uc_pcbedit_import.Visible = flag;
				MainForm0.mIsOpen_PcbImportPage = flag;
				return;
			}
			uc_pcbedit_import = new UserControl_pcbedit_import(mFn, USR, USR2, USR3);
			base.Controls.Add(uc_pcbedit_import);
			uc_pcbedit_import.null_pcbedit_editlist += null_pcbedit_editlist;
			uc_pcbedit_import.init_pcbedit_editlist += init_pcbedit_editlist;
			uc_pcbedit_import.PCBE_List_Show += PCBE_List_Show;
			uc_pcbedit_import.SetEdit_XY += SetEdit_XY;
			uc_pcbedit_import.Location = new Point(0, 0);
			uc_pcbedit_import.Visible = flag;
			uc_pcbedit_import.BringToFront();
			uc_pcbedit_import.Show();
			MainForm0.mIsOpen_PcbImportPage = flag;
		}

		public void ToolStripMenuItem_smtTest_Click(object sender, EventArgs e)
		{
			int count = dataGridView_pcbedit.SelectedRows.Count;
			if (count != 1)
			{
				MainForm0.CmMessageBoxTop_Ok((new string[3] { "请整行选中一颗料!", "請整行選中壹顆料!", "Please select one line item!" })[USR_INIT.mLanguage]);
				return;
			}
			string[] array = new string[3] { "您确定已经设置好[元件信息]，[分类信息]和[料站/料盘/视觉参数]了吗？", "您確定已經設置好[元件信息]，[分類信息]和[料站/料盤/視覺參數]了嗎？", "Please make you have set chip information, category, stacks, camera visual setting done!" };
			if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes || USR3 == null)
			{
				return;
			}
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? USR3.mPointlist : USR3.mPointlistSmt);
			if (bindingList == null || bindingList.Count <= 0)
			{
				return;
			}
			int index = dataGridView_pcbedit.SelectedRows[0].Index;
			if (index >= 0 && index < bindingList.Count)
			{
				BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
				ChipBoardElement chipBoardElement = new ChipBoardElement(bindingList[index]);
				if (mIsPcbCheck)
				{
					chipBoardElement.X = chipBoardElement.X_Real;
					chipBoardElement.Y = chipBoardElement.Y_Real;
					chipBoardElement.A = chipBoardElement.A_Real;
				}
				bindingList2.Add(chipBoardElement);
				if (this.vsplus_smt_test != null)
				{
					this.vsplus_smt_test(bindingList2);
				}
			}
		}

		private void thd_smtTest()
		{
		}

		private bool smtTest_legalcheck(ChipBoardElement emt)
		{
			return true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string[] array = new string[3] { "是否已经进板&夹板?", "是否已經進板&夾板?", "Is PCB board Fixed by track?" };
			if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			Form_BoxSel form_BoxSel = new Form_BoxSel((new string[3] { "进板查看模式选择", "進板查看模式選擇", "PCB Inboard Check Mode Choose" })[USR_INIT.mLanguage], (new string[3] { "自动MARK", "自動MARK", "Auto Mark Recognition" })[USR_INIT.mLanguage], (new string[3] { "手动MARK", "手動MARK", "Manual Mark Recognition" })[USR_INIT.mLanguage], "");
			switch (form_BoxSel.ShowDialog())
			{
			case DialogResult.Yes:
				if (this.cb_pcbcheck_start != null)
				{
					this.cb_pcbcheck_start(USR3, a: false);
				}
				break;
			case DialogResult.OK:
				if (this.cb_pcbcheck_start != null)
				{
					this.cb_pcbcheck_start(USR3, a: true);
				}
				break;
			}
		}

		private void toolStripMenuItem_setting_Click(object sender, EventArgs e)
		{
			vsplusForm_datagridviewSetting vsplusForm_datagridviewSetting = new vsplusForm_datagridviewSetting(mIsEditEnable);
			if (vsplusForm_datagridviewSetting.ShowDialog() == DialogResult.OK)
			{
				mIsEditEnable = vsplusForm_datagridviewSetting.GetEdit_XY();
				SetEdit_XY(mIsEditEnable);
			}
		}

		private void dataGridView_pcbedit_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			DataGridView dataGridView = sender as DataGridView;
			Rectangle bounds = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView.RowHeadersWidth - 4, e.RowBounds.Height);
			TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView.RowHeadersDefaultCellStyle.Font, bounds, dataGridView.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
		}

		private void cnSearchBoxEx1_SearchEvent(object sender, EventArgs e)
		{
			string text = cnSearchBoxEx1.Text;
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 1) ? point_list_smt : point_list);
			if (bindingList == null && bindingList.Count <= 0)
			{
				return;
			}
			if (mPointCurIndex >= bindingList.Count)
			{
				mPointCurIndex = 0;
			}
			if (comboBox_search1.SelectedIndex == 0)
			{
				for (int i = mPointCurIndex + 1; i < bindingList.Count + mPointCurIndex + 1; i++)
				{
					int num = i % bindingList.Count;
					int num2 = 0;
					for (num2 = 0; num2 < 38; num2++)
					{
						if (dataGridView_pcbedit.Rows[num].Cells[num2].Value != null && text == dataGridView_pcbedit.Rows[num].Cells[num2].Value.ToString())
						{
							dataGridView_pcbedit.Rows[mPointCurIndex].Selected = false;
							dataGridView_pcbedit.Rows[num].Selected = true;
							dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = num;
							mPointCurIndex = num;
							label_pcbedit_index.Text = mPointCurIndex + 1 + "/" + bindingList.Count;
							break;
						}
					}
					if (num2 < 38)
					{
						break;
					}
				}
			}
			else
			{
				if (comboBox_search1.SelectedIndex >= 39 || comboBox_search1.SelectedIndex <= 0)
				{
					return;
				}
				int selectedIndex = comboBox_search1.SelectedIndex;
				for (int j = mPointCurIndex + 1; j < bindingList.Count + mPointCurIndex + 1; j++)
				{
					int num3 = j % bindingList.Count;
					if (dataGridView_pcbedit.Rows[num3].Cells[selectedIndex].Value != null && text == dataGridView_pcbedit.Rows[num3].Cells[selectedIndex].Value.ToString())
					{
						dataGridView_pcbedit.Rows[mPointCurIndex].Selected = false;
						dataGridView_pcbedit.Rows[num3].Selected = true;
						dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = num3;
						mPointCurIndex = num3;
						label_pcbedit_index.Text = mPointCurIndex + 1 + "/" + bindingList.Count;
						break;
					}
				}
			}
		}

		private void cnSearchBoxEx1_SearchEventExt(object sender, EventArgs e)
		{
			string text = cnSearchBoxEx1.Text;
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 1) ? point_list_smt : point_list);
			if (bindingList == null && bindingList.Count <= 0)
			{
				return;
			}
			if (mPointCurIndex >= bindingList.Count)
			{
				mPointCurIndex = 0;
			}
			BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
			BindingList<int> bindingList3 = new BindingList<int>();
			if (comboBox_search1.SelectedIndex == 0)
			{
				for (int i = 0; i < bindingList.Count; i++)
				{
					int num = 0;
					for (num = 0; num < 19; num++)
					{
						if (dataGridView_pcbedit.Rows[i].Cells[num].Value != null && text == dataGridView_pcbedit.Rows[i].Cells[num].Value.ToString())
						{
							bindingList2.Add(bindingList[i]);
							bindingList3.Add(i);
							break;
						}
					}
				}
			}
			else if (comboBox_search1.SelectedIndex < 20 && comboBox_search1.SelectedIndex > 0)
			{
				int selectedIndex = comboBox_search1.SelectedIndex;
				for (int j = 0; j < bindingList.Count; j++)
				{
					if (dataGridView_pcbedit.Rows[j].Cells[selectedIndex].Value != null && text == dataGridView_pcbedit.Rows[j].Cells[selectedIndex].Value.ToString())
					{
						bindingList2.Add(bindingList[j]);
						bindingList3.Add(j);
					}
				}
			}
			if (bindingList2.Count > 0)
			{
				Form_SearchExt form_SearchExt = new Form_SearchExt(mFn, USR, USR2, USR3, bindingList2, mIsPcbCheck, mIsEditEnable);
				form_SearchExt.ShowDialog();
				dataGridView_pcbedit.ClearSelection();
				dataGridView_pcbedit.Refresh();
				for (int k = 0; k < bindingList3.Count; k++)
				{
					int index = bindingList3[k];
					dataGridView_pcbedit.Rows[index].Selected = true;
				}
			}
		}

		private void label_pcbedit_index_DoubleClick(object sender, EventArgs e)
		{
			vsplusForm_datagridviewSetting vsplusForm_datagridviewSetting = new vsplusForm_datagridviewSetting(mIsEditEnable);
			if (vsplusForm_datagridviewSetting.ShowDialog() == DialogResult.OK)
			{
				mIsEditEnable = vsplusForm_datagridviewSetting.GetEdit_XY();
				SetEdit_XY(mIsEditEnable);
			}
		}

		public void sel_nearest_chip(Coordinate c)
		{
			BindingList<ChipBoardElement> bindingList = ((USR3.mPointListOrder == 0) ? point_list : point_list_smt);
			if (bindingList == null || bindingList.Count == 0)
			{
				return;
			}
			int num = -1;
			int num2 = (int)(360f * MainForm0.USR[mFn].mMarkCamRatio[0]);
			int num3 = num2 * num2;
			Coordinate coordinate = new Coordinate(0L, 0L);
			for (int i = 0; i < bindingList.Count; i++)
			{
				coordinate.X = bindingList[i].X_Real;
				coordinate.Y = bindingList[i].Y_Real;
				int num4 = MainForm0.format_distance2(c, coordinate);
				if (num4 < num3)
				{
					num3 = num4;
					num = i;
				}
			}
			if (num != -1)
			{
				dataGridView_pcbedit.ClearSelection();
				dataGridView_pcbedit.Refresh();
				dataGridView_pcbedit.Rows[num].Selected = true;
				dataGridView_pcbedit.FirstDisplayedScrollingRowIndex = num;
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
			components = new System.ComponentModel.Container();
			dataGridView_pcbedit = new System.Windows.Forms.DataGridView();
			comboBox_search1 = new System.Windows.Forms.ComboBox();
			label_pcbedit_index = new System.Windows.Forms.Label();
			contextMenuStrip_pcbedit_list = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem_pcbedit_select = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_pcbedit_select_cancel = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_selectlist = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_ChangeAllXY = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_bulk_add = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_insert_up = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_insert_down = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_smtTest = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_group_combine = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_group_up = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_group_down = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_group_end = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_group_orderbyheight = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_XboardCheck = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_MntScan = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_setting = new System.Windows.Forms.ToolStripMenuItem();
			contextMenuStrip_pcbedit_cell = new System.Windows.Forms.ContextMenuStrip(components);
			手动填充ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			panel_tools = new System.Windows.Forms.Panel();
			button_pcbCheck = new QIGN_COMMON.vs_acontrol.CnButton();
			button_backto_loadscreen = new QIGN_COMMON.vs_acontrol.CnButton();
			cnSearchBoxEx1 = new QIGN_COMMON.vs_acontrol.CnSearchBoxEx();
			button_moveup = new QIGN_COMMON.vs_acontrol.CnButton();
			button_exportPCBlist = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBE_fackPCB = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBE_Mark = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBE_order_0 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbedit_movetoxy = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbArray = new QIGN_COMMON.vs_acontrol.CnButton();
			button_movedown = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbedit_additem = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbedit_deleteitem = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBE_order_1 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbedit_movetoxy_prev = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbedit_movetoxy_next = new QIGN_COMMON.vs_acontrol.CnButton();
			ToolStripMenuItem_group_begin = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)dataGridView_pcbedit).BeginInit();
			contextMenuStrip_pcbedit_list.SuspendLayout();
			contextMenuStrip_pcbedit_cell.SuspendLayout();
			panel_tools.SuspendLayout();
			SuspendLayout();
			dataGridView_pcbedit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_pcbedit.Location = new System.Drawing.Point(6, 58);
			dataGridView_pcbedit.Name = "dataGridView_pcbedit";
			dataGridView_pcbedit.RowTemplate.Height = 23;
			dataGridView_pcbedit.Size = new System.Drawing.Size(703, 762);
			dataGridView_pcbedit.TabIndex = 0;
			dataGridView_pcbedit.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcbedit_CellMouseDoubleClick);
			dataGridView_pcbedit.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcbedit_CellMouseDown);
			dataGridView_pcbedit.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcbedit_CellMouseUp);
			dataGridView_pcbedit.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcbedit_RowHeaderMouseClick);
			dataGridView_pcbedit.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dataGridView_pcbedit_RowPostPaint);
			comboBox_search1.Font = new System.Drawing.Font("黑体", 10.5f);
			comboBox_search1.FormattingEnabled = true;
			comboBox_search1.Location = new System.Drawing.Point(544, 28);
			comboBox_search1.Name = "comboBox_search1";
			comboBox_search1.Size = new System.Drawing.Size(57, 22);
			comboBox_search1.TabIndex = 9;
			label_pcbedit_index.Location = new System.Drawing.Point(547, 6);
			label_pcbedit_index.Name = "label_pcbedit_index";
			label_pcbedit_index.Size = new System.Drawing.Size(158, 18);
			label_pcbedit_index.TabIndex = 11;
			label_pcbedit_index.Text = "1000/1000";
			label_pcbedit_index.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_pcbedit_index.DoubleClick += new System.EventHandler(label_pcbedit_index_DoubleClick);
			contextMenuStrip_pcbedit_list.Font = new System.Drawing.Font("楷体", 11f);
			contextMenuStrip_pcbedit_list.Items.AddRange(new System.Windows.Forms.ToolStripItem[25]
			{
				toolStripMenuItem_pcbedit_select, toolStripMenuItem_pcbedit_select_cancel, toolStripSeparator5, ToolStripMenuItem_selectlist, toolStripSeparator4, ToolStripMenuItem_ChangeAllXY, toolStripSeparator1, ToolStripMenuItem_bulk_add, ToolStripMenuItem_insert_up, ToolStripMenuItem_insert_down,
				ToolStripMenuItem_delete, toolStripSeparator3, ToolStripMenuItem_smtTest, toolStripSeparator2, ToolStripMenuItem_group_combine, ToolStripMenuItem_group_up, ToolStripMenuItem_group_down, ToolStripMenuItem_group_begin, ToolStripMenuItem_group_end, ToolStripMenuItem_group_orderbyheight,
				toolStripSeparator6, ToolStripMenuItem_XboardCheck, ToolStripMenuItem_MntScan, toolStripSeparator7, toolStripMenuItem_setting
			});
			contextMenuStrip_pcbedit_list.Name = "contextMenuStrip1";
			contextMenuStrip_pcbedit_list.Size = new System.Drawing.Size(187, 464);
			toolStripMenuItem_pcbedit_select.Name = "toolStripMenuItem_pcbedit_select";
			toolStripMenuItem_pcbedit_select.Size = new System.Drawing.Size(218, 22);
			toolStripMenuItem_pcbedit_select.Tag = "check";
			toolStripMenuItem_pcbedit_select.Text = "勾选";
			toolStripMenuItem_pcbedit_select.Click += new System.EventHandler(toolStripMenuItem_pcbedit_select_Click);
			toolStripMenuItem_pcbedit_select_cancel.Name = "toolStripMenuItem_pcbedit_select_cancel";
			toolStripMenuItem_pcbedit_select_cancel.Size = new System.Drawing.Size(218, 22);
			toolStripMenuItem_pcbedit_select_cancel.Tag = "uncheck";
			toolStripMenuItem_pcbedit_select_cancel.Text = "勾选取消";
			toolStripMenuItem_pcbedit_select_cancel.Click += new System.EventHandler(toolStripMenuItem_pcbedit_select_Click);
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new System.Drawing.Size(215, 6);
			ToolStripMenuItem_selectlist.Name = "ToolStripMenuItem_selectlist";
			ToolStripMenuItem_selectlist.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_selectlist.Text = "选中列表";
			ToolStripMenuItem_selectlist.Click += new System.EventHandler(ToolStripMenuItem_selectlist_Click);
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new System.Drawing.Size(215, 6);
			ToolStripMenuItem_ChangeAllXY.Name = "ToolStripMenuItem_ChangeAllXY";
			ToolStripMenuItem_ChangeAllXY.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_ChangeAllXY.Text = "整体搬移XYA";
			ToolStripMenuItem_ChangeAllXY.Click += new System.EventHandler(button_ChangeAllXY_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
			ToolStripMenuItem_bulk_add.Name = "ToolStripMenuItem_bulk_add";
			ToolStripMenuItem_bulk_add.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_bulk_add.Text = "批量阵列";
			ToolStripMenuItem_bulk_add.Click += new System.EventHandler(ToolStripMenuItem_bulk_add_Click);
			ToolStripMenuItem_insert_up.Name = "ToolStripMenuItem_insert_up";
			ToolStripMenuItem_insert_up.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_insert_up.Tag = "up";
			ToolStripMenuItem_insert_up.Text = "向上插入一行";
			ToolStripMenuItem_insert_up.Click += new System.EventHandler(ToolStripMenuItem_insert_down_Click);
			ToolStripMenuItem_insert_down.Name = "ToolStripMenuItem_insert_down";
			ToolStripMenuItem_insert_down.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_insert_down.Tag = "down";
			ToolStripMenuItem_insert_down.Text = "向下插入一行";
			ToolStripMenuItem_insert_down.Click += new System.EventHandler(ToolStripMenuItem_insert_down_Click);
			ToolStripMenuItem_delete.Name = "ToolStripMenuItem_delete";
			ToolStripMenuItem_delete.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_delete.Text = "删除";
			ToolStripMenuItem_delete.Click += new System.EventHandler(button_pcbedit_deleteitem_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(215, 6);
			ToolStripMenuItem_smtTest.Name = "ToolStripMenuItem_smtTest";
			ToolStripMenuItem_smtTest.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_smtTest.Text = "贴装测试";
			ToolStripMenuItem_smtTest.Click += new System.EventHandler(ToolStripMenuItem_smtTest_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
			ToolStripMenuItem_group_combine.Name = "ToolStripMenuItem_group_combine";
			ToolStripMenuItem_group_combine.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_group_combine.Text = "合并轮组";
			ToolStripMenuItem_group_combine.Click += new System.EventHandler(ToolStripMenuItem_group_combine_Click);
			ToolStripMenuItem_group_up.Name = "ToolStripMenuItem_group_up";
			ToolStripMenuItem_group_up.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_group_up.Tag = "up";
			ToolStripMenuItem_group_up.Text = "轮组上移";
			ToolStripMenuItem_group_up.Click += new System.EventHandler(ToolStripMenuItem_group_down_Click);
			ToolStripMenuItem_group_down.Name = "ToolStripMenuItem_group_down";
			ToolStripMenuItem_group_down.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_group_down.Tag = "down";
			ToolStripMenuItem_group_down.Text = "轮组下移";
			ToolStripMenuItem_group_down.Click += new System.EventHandler(ToolStripMenuItem_group_down_Click);
			ToolStripMenuItem_group_end.Name = "ToolStripMenuItem_group_end";
			ToolStripMenuItem_group_end.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_group_end.Tag = "end";
			ToolStripMenuItem_group_end.Text = "轮组移动到末尾";
			ToolStripMenuItem_group_end.Click += new System.EventHandler(ToolStripMenuItem_group_down_Click);
			ToolStripMenuItem_group_orderbyheight.Name = "ToolStripMenuItem_group_orderbyheight";
			ToolStripMenuItem_group_orderbyheight.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_group_orderbyheight.Text = "轮组按高度排序";
			ToolStripMenuItem_group_orderbyheight.Click += new System.EventHandler(ToolStripMenuItem_group_orderbyheight_Click);
			toolStripSeparator6.Name = "toolStripSeparator6";
			toolStripSeparator6.Size = new System.Drawing.Size(215, 6);
			ToolStripMenuItem_XboardCheck.Name = "ToolStripMenuItem_XboardCheck";
			ToolStripMenuItem_XboardCheck.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_XboardCheck.Text = "打叉板检测";
			ToolStripMenuItem_MntScan.Name = "ToolStripMenuItem_MntScan";
			ToolStripMenuItem_MntScan.Size = new System.Drawing.Size(218, 22);
			ToolStripMenuItem_MntScan.Text = "贴装位全扫";
			toolStripSeparator7.Name = "toolStripSeparator7";
			toolStripSeparator7.Size = new System.Drawing.Size(215, 6);
			toolStripMenuItem_setting.Name = "toolStripMenuItem_setting";
			toolStripMenuItem_setting.Size = new System.Drawing.Size(218, 22);
			toolStripMenuItem_setting.Text = "高级设置";
			toolStripMenuItem_setting.Click += new System.EventHandler(toolStripMenuItem_setting_Click);
			contextMenuStrip_pcbedit_cell.Font = new System.Drawing.Font("楷体", 11f);
			contextMenuStrip_pcbedit_cell.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { 手动填充ToolStripMenuItem });
			contextMenuStrip_pcbedit_cell.Name = "contextMenuStrip_pcbedit_cell";
			contextMenuStrip_pcbedit_cell.Size = new System.Drawing.Size(139, 26);
			手动填充ToolStripMenuItem.Name = "手动填充ToolStripMenuItem";
			手动填充ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			手动填充ToolStripMenuItem.Text = "手动填充";
			panel_tools.Controls.Add(button_pcbCheck);
			panel_tools.Controls.Add(button_backto_loadscreen);
			panel_tools.Controls.Add(cnSearchBoxEx1);
			panel_tools.Controls.Add(button_moveup);
			panel_tools.Controls.Add(button_exportPCBlist);
			panel_tools.Controls.Add(button_PCBE_fackPCB);
			panel_tools.Controls.Add(label_pcbedit_index);
			panel_tools.Controls.Add(button_PCBE_Mark);
			panel_tools.Controls.Add(comboBox_search1);
			panel_tools.Controls.Add(button_PCBE_order_0);
			panel_tools.Controls.Add(button_pcbedit_movetoxy);
			panel_tools.Controls.Add(button_pcbArray);
			panel_tools.Controls.Add(button_movedown);
			panel_tools.Controls.Add(button_pcbedit_additem);
			panel_tools.Controls.Add(button_pcbedit_deleteitem);
			panel_tools.Controls.Add(button_PCBE_order_1);
			panel_tools.Controls.Add(button_pcbedit_movetoxy_prev);
			panel_tools.Controls.Add(button_pcbedit_movetoxy_next);
			panel_tools.Font = new System.Drawing.Font("黑体", 10.5f);
			panel_tools.Location = new System.Drawing.Point(0, 1);
			panel_tools.Name = "panel_tools";
			panel_tools.Size = new System.Drawing.Size(708, 58);
			panel_tools.TabIndex = 12;
			button_pcbCheck.BackColor = System.Drawing.SystemColors.ControlLight;
			button_pcbCheck.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbCheck.CnPressDownColor = System.Drawing.Color.White;
			button_pcbCheck.Location = new System.Drawing.Point(389, 3);
			button_pcbCheck.Name = "button_pcbCheck";
			button_pcbCheck.Size = new System.Drawing.Size(152, 52);
			button_pcbCheck.TabIndex = 12;
			button_pcbCheck.Text = "进板查看";
			button_pcbCheck.UseVisualStyleBackColor = false;
			button_pcbCheck.Click += new System.EventHandler(button1_Click);
			button_backto_loadscreen.BackColor = System.Drawing.SystemColors.ControlLight;
			button_backto_loadscreen.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_backto_loadscreen.CnPressDownColor = System.Drawing.Color.White;
			button_backto_loadscreen.Location = new System.Drawing.Point(7, 3);
			button_backto_loadscreen.Name = "button_backto_loadscreen";
			button_backto_loadscreen.Size = new System.Drawing.Size(60, 52);
			button_backto_loadscreen.TabIndex = 1;
			button_backto_loadscreen.Text = "导入\r\n界面";
			button_backto_loadscreen.UseVisualStyleBackColor = false;
			button_backto_loadscreen.Click += new System.EventHandler(button_backto_loadscreen_Click);
			cnSearchBoxEx1.BackColor = System.Drawing.Color.White;
			cnSearchBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			cnSearchBoxEx1.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			cnSearchBoxEx1.Location = new System.Drawing.Point(604, 27);
			cnSearchBoxEx1.Name = "cnSearchBoxEx1";
			cnSearchBoxEx1.Size = new System.Drawing.Size(100, 26);
			cnSearchBoxEx1.TabIndex = 13;
			cnSearchBoxEx1.SearchEvent += new System.EventHandler(cnSearchBoxEx1_SearchEvent);
			cnSearchBoxEx1.SearchEventExt += new System.EventHandler(cnSearchBoxEx1_SearchEventExt);
			button_moveup.BackColor = System.Drawing.SystemColors.ControlLight;
			button_moveup.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_moveup.CnPressDownColor = System.Drawing.Color.White;
			button_moveup.Location = new System.Drawing.Point(326, 3);
			button_moveup.Name = "button_moveup";
			button_moveup.Size = new System.Drawing.Size(61, 25);
			button_moveup.TabIndex = 1;
			button_moveup.Tag = "up";
			button_moveup.Text = "上移↑";
			button_moveup.UseVisualStyleBackColor = false;
			button_moveup.Click += new System.EventHandler(button_movedown_Click);
			button_exportPCBlist.BackColor = System.Drawing.SystemColors.ControlLight;
			button_exportPCBlist.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_exportPCBlist.CnPressDownColor = System.Drawing.Color.White;
			button_exportPCBlist.Location = new System.Drawing.Point(274, 30);
			button_exportPCBlist.Name = "button_exportPCBlist";
			button_exportPCBlist.Size = new System.Drawing.Size(50, 25);
			button_exportPCBlist.TabIndex = 1;
			button_exportPCBlist.Text = "导出";
			button_exportPCBlist.UseVisualStyleBackColor = false;
			button_exportPCBlist.Click += new System.EventHandler(button_exportPCBlist_Click);
			button_PCBE_fackPCB.BackColor = System.Drawing.SystemColors.ControlLight;
			button_PCBE_fackPCB.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_fackPCB.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_fackPCB.Location = new System.Drawing.Point(274, 3);
			button_PCBE_fackPCB.Name = "button_PCBE_fackPCB";
			button_PCBE_fackPCB.Size = new System.Drawing.Size(50, 25);
			button_PCBE_fackPCB.TabIndex = 1;
			button_PCBE_fackPCB.Text = "板图";
			button_PCBE_fackPCB.UseVisualStyleBackColor = false;
			button_PCBE_fackPCB.Click += new System.EventHandler(button_PCBE_fackPCB_Click);
			button_PCBE_Mark.BackColor = System.Drawing.SystemColors.ControlLight;
			button_PCBE_Mark.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_Mark.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_Mark.Location = new System.Drawing.Point(133, 3);
			button_PCBE_Mark.Name = "button_PCBE_Mark";
			button_PCBE_Mark.Size = new System.Drawing.Size(60, 52);
			button_PCBE_Mark.TabIndex = 1;
			button_PCBE_Mark.Text = "Mark\r\n设置";
			button_PCBE_Mark.UseVisualStyleBackColor = false;
			button_PCBE_Mark.Click += new System.EventHandler(button_PCBE_Mark_Click);
			button_PCBE_order_0.BackColor = System.Drawing.SystemColors.ControlLight;
			button_PCBE_order_0.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_order_0.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_order_0.Location = new System.Drawing.Point(197, 3);
			button_PCBE_order_0.Name = "button_PCBE_order_0";
			button_PCBE_order_0.Size = new System.Drawing.Size(75, 25);
			button_PCBE_order_0.TabIndex = 6;
			button_PCBE_order_0.Text = "拼板排序";
			button_PCBE_order_0.UseVisualStyleBackColor = false;
			button_PCBE_order_0.Click += new System.EventHandler(button_PCBE_order_0_Click);
			button_pcbedit_movetoxy.BackColor = System.Drawing.SystemColors.ControlLight;
			button_pcbedit_movetoxy.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbedit_movetoxy.CnPressDownColor = System.Drawing.Color.White;
			button_pcbedit_movetoxy.Location = new System.Drawing.Point(435, 30);
			button_pcbedit_movetoxy.Name = "button_pcbedit_movetoxy";
			button_pcbedit_movetoxy.Size = new System.Drawing.Size(44, 25);
			button_pcbedit_movetoxy.TabIndex = 1;
			button_pcbedit_movetoxy.Tag = "cur";
			button_pcbedit_movetoxy.Text = "定位";
			button_pcbedit_movetoxy.UseVisualStyleBackColor = false;
			button_pcbedit_movetoxy.Click += new System.EventHandler(button_pcbedit_movetoxy_Click);
			button_pcbArray.BackColor = System.Drawing.SystemColors.ControlLight;
			button_pcbArray.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbArray.CnPressDownColor = System.Drawing.Color.White;
			button_pcbArray.Location = new System.Drawing.Point(70, 3);
			button_pcbArray.Name = "button_pcbArray";
			button_pcbArray.Size = new System.Drawing.Size(60, 52);
			button_pcbArray.TabIndex = 5;
			button_pcbArray.Text = "拼板";
			button_pcbArray.UseVisualStyleBackColor = false;
			button_pcbArray.Click += new System.EventHandler(button_pcbArray_Click);
			button_movedown.BackColor = System.Drawing.SystemColors.ControlLight;
			button_movedown.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_movedown.CnPressDownColor = System.Drawing.Color.White;
			button_movedown.Location = new System.Drawing.Point(326, 30);
			button_movedown.Name = "button_movedown";
			button_movedown.Size = new System.Drawing.Size(61, 25);
			button_movedown.TabIndex = 2;
			button_movedown.Tag = "down";
			button_movedown.Text = "下移↓";
			button_movedown.UseVisualStyleBackColor = false;
			button_movedown.Click += new System.EventHandler(button_movedown_Click);
			button_pcbedit_additem.BackColor = System.Drawing.Color.LightSalmon;
			button_pcbedit_additem.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbedit_additem.CnPressDownColor = System.Drawing.Color.White;
			button_pcbedit_additem.Location = new System.Drawing.Point(389, 3);
			button_pcbedit_additem.Name = "button_pcbedit_additem";
			button_pcbedit_additem.Size = new System.Drawing.Size(44, 52);
			button_pcbedit_additem.TabIndex = 5;
			button_pcbedit_additem.Text = "新增";
			button_pcbedit_additem.UseVisualStyleBackColor = false;
			button_pcbedit_additem.Click += new System.EventHandler(button_pcbedit_additem_Click);
			button_pcbedit_deleteitem.BackColor = System.Drawing.SystemColors.ControlDark;
			button_pcbedit_deleteitem.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbedit_deleteitem.CnPressDownColor = System.Drawing.Color.White;
			button_pcbedit_deleteitem.Location = new System.Drawing.Point(435, 3);
			button_pcbedit_deleteitem.Name = "button_pcbedit_deleteitem";
			button_pcbedit_deleteitem.Size = new System.Drawing.Size(44, 25);
			button_pcbedit_deleteitem.TabIndex = 4;
			button_pcbedit_deleteitem.Text = "删除";
			button_pcbedit_deleteitem.UseVisualStyleBackColor = false;
			button_pcbedit_deleteitem.Click += new System.EventHandler(button_pcbedit_deleteitem_Click);
			button_PCBE_order_1.BackColor = System.Drawing.SystemColors.ControlLight;
			button_PCBE_order_1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_order_1.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_order_1.Location = new System.Drawing.Point(197, 30);
			button_PCBE_order_1.Name = "button_PCBE_order_1";
			button_PCBE_order_1.Size = new System.Drawing.Size(75, 25);
			button_PCBE_order_1.TabIndex = 2;
			button_PCBE_order_1.Text = "贴装排序";
			button_PCBE_order_1.UseVisualStyleBackColor = false;
			button_PCBE_order_1.Click += new System.EventHandler(button_PCBE_order_1_Click);
			button_pcbedit_movetoxy_prev.BackColor = System.Drawing.SystemColors.ControlLight;
			button_pcbedit_movetoxy_prev.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbedit_movetoxy_prev.CnPressDownColor = System.Drawing.Color.White;
			button_pcbedit_movetoxy_prev.Location = new System.Drawing.Point(481, 3);
			button_pcbedit_movetoxy_prev.Name = "button_pcbedit_movetoxy_prev";
			button_pcbedit_movetoxy_prev.Size = new System.Drawing.Size(60, 25);
			button_pcbedit_movetoxy_prev.TabIndex = 1;
			button_pcbedit_movetoxy_prev.Tag = "prev";
			button_pcbedit_movetoxy_prev.Text = "定位↑";
			button_pcbedit_movetoxy_prev.UseVisualStyleBackColor = false;
			button_pcbedit_movetoxy_prev.Click += new System.EventHandler(button_pcbedit_movetoxy_Click);
			button_pcbedit_movetoxy_next.BackColor = System.Drawing.SystemColors.ControlLight;
			button_pcbedit_movetoxy_next.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbedit_movetoxy_next.CnPressDownColor = System.Drawing.Color.White;
			button_pcbedit_movetoxy_next.Location = new System.Drawing.Point(481, 30);
			button_pcbedit_movetoxy_next.Name = "button_pcbedit_movetoxy_next";
			button_pcbedit_movetoxy_next.Size = new System.Drawing.Size(60, 25);
			button_pcbedit_movetoxy_next.TabIndex = 1;
			button_pcbedit_movetoxy_next.Tag = "next";
			button_pcbedit_movetoxy_next.Text = "定位↓";
			button_pcbedit_movetoxy_next.UseVisualStyleBackColor = false;
			button_pcbedit_movetoxy_next.Click += new System.EventHandler(button_pcbedit_movetoxy_Click);
			ToolStripMenuItem_group_begin.Name = "ToolStripMenuItem_group_begin";
			ToolStripMenuItem_group_begin.Size = new System.Drawing.Size(186, 22);
			ToolStripMenuItem_group_begin.Tag = "begin";
			ToolStripMenuItem_group_begin.Text = "轮组移动到开始";
			ToolStripMenuItem_group_begin.Click += new System.EventHandler(ToolStripMenuItem_group_down_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(panel_tools);
			base.Controls.Add(dataGridView_pcbedit);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.Name = "UserControl_pcbedit_datagridview";
			base.Size = new System.Drawing.Size(711, 825);
			base.Load += new System.EventHandler(UserControl_pcbedit_datagridview_Load);
			((System.ComponentModel.ISupportInitialize)dataGridView_pcbedit).EndInit();
			contextMenuStrip_pcbedit_list.ResumeLayout(false);
			contextMenuStrip_pcbedit_cell.ResumeLayout(false);
			panel_tools.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
