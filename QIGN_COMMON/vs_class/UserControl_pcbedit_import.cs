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
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_pcbedit_import : UserControl
	{
		private const int LeadingColumnNum = 11;

		private USR_INIT_DATA USR_INIT;

		private USR_DATA USR;

		private USR3_DATA USR3;

		private USR2_DATA USR2;

		private LD_DATA2 LD2;

		private int mFn;

		public BindingList<ChipBoardElement> importList;

		private int selectrowindex = -1;

		private int index = -1;

		private int mLeadingCurIndex;

		private ToolStripMenuItem[] ts_sn;

		private ToolStripMenuItem[] toolStripMenuItem_SetMark;

		private TextBox[] textBox_mark;

		private Label[] label_titles_mark;

		private Label[] label_xy_mark;

		private CnButton[] button_mark_save;

		private CnButton[] button_mark_goto;

		private PictureBox[] pictureBox_Sign;

		private Coordinate[] fill_signxy;

		private Coordinate smtmark_offset = new Coordinate();

		private double MarkAngle;

		private double MarkSin;

		private double MarkCos;

		private double MarkA;

		private CoordinateDouble[] mFakeMk23;

		private CoordinateDouble[] mFakeMk23_r;

		private IContainer components;

		private Label label2;

		private CnButton button_importAngle;

		private CnButton button_pcbview;

		private CnButton button_importLegal;

		private CnButton button_addBom;

		private Label label_loadcomponent_page;

		private CnButton button_LoadComponentFile;

		private DataGridView dataGridView_pcb;

		private Panel panel21;

		private CheckBox checkBox_oppoPcb_debug;

		private CnButton button_GenerateList0;

		private Panel panel104;

		private CnButton button23;

		private CnButton button21;

		private Label label179;

		private CheckBox checkBox_PreciseImport;

		private Panel panel102;

		private TextBox textBox_ref0_x;

		private TextBox textBox_ref1_y;

		private Label label_ref0;

		private TextBox textBox_ref1_x;

		private Label label175;

		private Label label171;

		private TextBox textBox_ref0_y;

		private Label label_ref1;

		private Label label60;

		private Label label174;

		private Label label173;

		private TextBox textBox_mark2y_location;

		private CnButton button_runSign;

		private TextBox textBox_mark2x_location;

		private Panel panel_loadsetsign;

		private PictureBox pictureBox5;

		private Panel panel2;

		private Panel panel106;

		private Label label176;

		private CnButton button3;

		private Panel panel105;

		private CnButton button13;

		private Label label177;

		private CnButton button27;

		private CnButton button32;

		private Label label72;

		private Label label_signp2;

		private Label label_signp1;

		private Panel panel103;

		private CnButton button15;

		private CnButton button14;

		private Label label178;

		private PictureBox pictureBox_Sign2;

		private PictureBox pictureBox3;

		private PictureBox pictureBox_Sign1;

		private Label label_Sign2;

		private CnButton button_MoveToSign1;

		private CnButton button_MoveToSign2;

		private Label label_Sign1;

		private CnButton button_SaveSign1;

		private CnButton button_SaveSign2;

		private TextBox textBox_mark1y_location;

		private Label label3;

		private Label label10;

		private Label label_signpcb;

		private Label label65;

		private Label label_signdevice;

		private TextBox textBox_mark1x_location;

		private Label label_signtitle0;

		private Label label_signtitile1;

		private Label label68;

		private Label label67;

		private CnButton button_PCBE_Import_Close;

		private ContextMenuStrip contextMenuStrip2;

		private ToolStripMenuItem ToolStripMenuItem_delete;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripMenuItem ToolStripMenuItem_SetMark1;

		private ToolStripMenuItem ToolStripMenuItem_SetMark2;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripMenuItem toolStripMenuItem_SetRef0;

		private ToolStripMenuItem toolStripMenuItem_SetRef1;

		private ContextMenuStrip contextMenuStrip_Sn;

		private ToolStripMenuItem ToolStripMenuItem_Name;

		private ToolStripMenuItem ToolStripMenuItem_Value;

		private ToolStripMenuItem ToolStripMenuItem_FootPrint;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripMenuItem ToolStripMenuItem_X;

		private ToolStripMenuItem ToolStripMenuItem_Y;

		private ToolStripMenuItem ToolStripMenuItem_Angle;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripMenuItem ToolStripMenuItem_Layer;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem ToolStripMenuItem_Hide;

		private CnSearchBox cnSearchBox1;

		private CnButton cnButton_cat;

		private CnButton cnButton_importmirror;

		public event void_Func_void null_pcbedit_editlist;

		public event void_Func_chiplist init_pcbedit_editlist;

		public event void_Func_int_bool PCBE_List_Show;

		public event void_Func_bool SetEdit_XY;

		public UserControl_pcbedit_import(int fn, USR_DATA usr, USR2_DATA usr2, USR3_DATA usr3)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR2 = usr2;
			USR3 = usr3;
			USR_INIT = MainForm0.USR_INIT;
			LD2 = usr3.LD2;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			MainForm0.mIsOpen_PcbImportPage = true;
			Type type = dataGridView_pcb.GetType();
			PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(dataGridView_pcb, true, null);
			fill_signxy = new Coordinate[4]
			{
				new Coordinate(0L, 0L),
				new Coordinate(0L, 0L),
				new Coordinate(0L, 0L),
				new Coordinate(0L, 0L)
			};
			toolStripMenuItem_SetMark = new ToolStripMenuItem[4] { ToolStripMenuItem_SetMark1, ToolStripMenuItem_SetMark2, toolStripMenuItem_SetRef0, toolStripMenuItem_SetRef1 };
			for (int i = 0; i < 4; i++)
			{
				toolStripMenuItem_SetMark[i].Tag = i;
				toolStripMenuItem_SetMark[i].Click += ToolStripMenuItem_SetMark_Click;
			}
			textBox_mark = new TextBox[8] { textBox_mark1x_location, textBox_mark1y_location, textBox_mark2x_location, textBox_mark2y_location, textBox_ref0_x, textBox_ref0_y, textBox_ref1_x, textBox_ref1_y };
			label_titles_mark = new Label[4] { label_signtitle0, label_signtitile1, label_ref0, label_ref1 };
			Button[] array = new Button[4] { button32, button27, button3, button13 };
			for (int j = 0; j < 4; j++)
			{
				Color color3 = (label_titles_mark[j].BackColor = (array[j].BackColor = DEF.COLOR_MARK[j]));
				label_titles_mark[j].Tag = j;
				label_titles_mark[j].Click += label_signtitle_Click;
			}
			label_xy_mark = new Label[4] { label_Sign1, label_Sign2, label179, label178 };
			button_mark_save = new CnButton[4] { button_SaveSign1, button_SaveSign2, button21, button14 };
			button_mark_goto = new CnButton[4] { button_MoveToSign1, button_MoveToSign2, button23, button15 };
			for (int k = 0; k < 4; k++)
			{
				label_xy_mark[k].BackColor = DEF.COLOR_MARK[k];
				label_xy_mark[k].Tag = k;
				label_xy_mark[k].DoubleClick += label_signxy_DoubleClick;
				button_mark_save[k].BackColor = DEF.COLOR_MARK[k];
				button_mark_goto[k].BackColor = DEF.COLOR_MARK[k];
				button_mark_save[k].Tag = k;
				button_mark_goto[k].Tag = k;
				button_mark_save[k].Click += button_mark_save_Click;
				button_mark_goto[k].Click += button_mark_goto_Click;
			}
			pictureBox_Sign = new PictureBox[4] { pictureBox_Sign1, pictureBox_Sign2, pictureBox5, pictureBox3 };
			ToolStripMenuItem[] array2 = new ToolStripMenuItem[27];
			for (int l = 6; l < 33; l++)
			{
				array2[l - 6] = new ToolStripMenuItem(STR.LOAD_HEAD_STR[l][USR_INIT.mLanguage]);
				array2[l - 6].Click += ToolStripMenuItem_Sn_Click;
				array2[l - 6].Tag = l;
			}
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem((USR_INIT.mLanguage == 2) ? "Optional" : "选填");
			toolStripMenuItem.DropDownItems.AddRange(array2);
			contextMenuStrip_Sn.Items.Clear();
			ToolStripMenuItem[] array3 = new ToolStripMenuItem[6];
			for (int m = 0; m < 6; m++)
			{
				array3[m] = new ToolStripMenuItem(STR.LOAD_HEAD_STR[m][USR_INIT.mLanguage]);
				array3[m].Click += ToolStripMenuItem_Sn_Click;
				array3[m].Tag = m;
			}
			ts_sn = new ToolStripMenuItem[33];
			for (int n = 0; n < 33; n++)
			{
				if (n < 6)
				{
					ts_sn[n] = array3[n];
				}
				else
				{
					ts_sn[n] = array2[n - 6];
				}
			}
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem((USR_INIT.mLanguage == 2) ? "Hiden Current Column" : "隐藏当前列");
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem((USR_INIT.mLanguage == 2) ? "Show All Columns" : "显示所有列");
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem((USR_INIT.mLanguage == 2) ? "Re-Write" : "重写");
			toolStripMenuItem4.Click += ToolStripMenuItem_ClearLabel_Click;
			toolStripMenuItem2.Click += ToolStripMenuItem_HidenCurColumn_Click;
			toolStripMenuItem3.Click += ToolStripMenuItem_ShowAllColumns_Click;
			contextMenuStrip_Sn.Items.AddRange(array3);
			contextMenuStrip_Sn.Items.Insert(6, toolStripMenuItem);
			contextMenuStrip_Sn.Items.Insert(6, new ToolStripSeparator());
			contextMenuStrip_Sn.Items.Insert(6, toolStripMenuItem3);
			contextMenuStrip_Sn.Items.Insert(6, toolStripMenuItem2);
			contextMenuStrip_Sn.Items.Insert(6, toolStripMenuItem4);
			contextMenuStrip_Sn.Items.Insert(6, new ToolStripSeparator());
			checkBox_oppoPcb_debug.Visible = MainForm0.mIsSimulation;
			init_dataGridView_pcb(LD2.pointlist);
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_addBom,
				str = new string[3] { "导入BOM", "導入BOM", "Import BOM" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pcbview,
				str = new string[3] { "板图", "板圖", "PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_importLegal,
				str = new string[3] { "诊断", "診斷", "Check" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_importAngle,
				str = new string[3] { "角度", "角度", "Angle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_signpcb,
				str = new string[3] { "标记点-在PCB上XY(毫米)", "標記點-在PCB上XY(毫米)", "Sign in PCB XY (mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_signdevice,
				str = new string[3] { "标记点-在机器上XY(步)", "標記點-在機器上XY(步)", "Sign in Machine XY (step)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_runSign,
				str = new string[3] { "自动获取", "自動獲取", "Auto Get Sign" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_PreciseImport,
				str = new string[3] { "精准生成", "精準生成", "Pricise Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_signtitle0,
				str = new string[3] { "标记点1", "標記點1", "Sign 1" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_signtitile1,
				str = new string[3] { "标记点2", "標記點2", "Sign 2" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_ref0,
				str = new string[3] { "标记点3", "標記點3", "Sign 3" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_ref1,
				str = new string[3] { "标记点4", "標記點4", "Sign 4" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_signp1,
				str = new string[3] { "标记点1", "標記點1", "Sign 1" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_signp2,
				str = new string[3] { "标记点2", "標記點2", "Sign 2" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label176,
				str = new string[3] { "标记点3", "標記點3", "Sign 3" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label177,
				str = new string[3] { "标记点4", "標記點4", "Sign 4" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveSign1,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveSign2,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button21,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button14,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MoveToSign1,
				str = new string[3] { "定位", "定位", "goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MoveToSign2,
				str = new string[3] { "定位", "定位", "goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button23,
				str = new string[3] { "定位", "定位", "goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button15,
				str = new string[3] { "定位", "定位", "goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_GenerateList0,
				str = new string[3] { "坐标映射生成", "坐標映射生成", "Generate PCB data" }
			});
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = contextMenuStrip2
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			LanguageItem languageItem2 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = contextMenuStrip_Sn
			};
			string[] array2 = (languageItem2.str = new string[3]);
			list.Add(languageItem2);
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_LoadComponentFile,
				str = new string[3] { "导入坐标", "导入坐标", "Import Data" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_cat,
				str = new string[3] { "坐标整理", "坐标整理", "Data Assembly" }
			});
			return list;
		}

		private void button_PCBE_Import_Close_Click(object sender, EventArgs e)
		{
			base.Visible = false;
			MainForm0.mIsOpen_PcbImportPage = false;
		}

		public void UserControl_pcbedit_import_Load(object sender, EventArgs e)
		{
			if (HW.mFnNum >= 2)
			{
				cnButton_cat.Visible = true;
			}
			BeginInvoke((MethodInvoker)delegate
			{
				loadcomponent_update_parameter(0);
			});
		}

		private void loadcomponent_update_parameter(int mode)
		{
			bool flag = true;
			if (LD2.pointlist == null)
			{
				flag = false;
			}
			if (!flag)
			{
				loadcomponent_reset();
			}
			else if (mode == 1)
			{
				init_dataGridView_pcb(LD2.pointlist);
			}
			selectrowindex = -1;
			label_loadcomponent_page.Text = "0/" + LD2.pointlist.Count;
			int i;
			for (i = 0; i < 4; i++)
			{
				Invoke((MethodInvoker)delegate
				{
					if (LD2.mSignPic[i] != null)
					{
						Bitmap bitmap = new Bitmap(new Bitmap(LD2.mSignPic[i]));
						bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
						pictureBox_Sign[i].Image = bitmap;
					}
					else
					{
						pictureBox_Sign[i].Image = null;
					}
				});
			}
			if (LD2.mSnIndex.Count() < 33)
			{
				int[] array = new int[LD2.mSnIndex.Count()];
				for (int j = 0; j < LD2.mSnIndex.Count(); j++)
				{
					array[j] = LD2.mSnIndex[j];
				}
				LD2.mSnIndex = new int[33];
				for (int k = 0; k < 33; k++)
				{
					if (k < array.Count())
					{
						LD2.mSnIndex[k] = array[k];
					}
					else
					{
						LD2.mSnIndex[k] = -1;
					}
				}
			}
			checkBox_PreciseImport.Checked = LD2.isPrecise;
			pictureBox_Sign[2].Visible = LD2.isPrecise;
			pictureBox_Sign[3].Visible = LD2.isPrecise;
			for (int l = 0; l < 4; l++)
			{
				if (LD2.record_mark[l] != -1)
				{
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[l], DEF.COLOR_MARK[l]);
					dataGridView_pcb.Rows[LD2.record_mark[l]].HeaderCell.Value = "S" + (l + 1);
				}
				label_xy_mark[l].Text = MainForm0.format_XY_label_string(LD2.mSignXY[l]);
				textBox_mark[l * 2].Text = LD2.mFill_SignXY[l * 2];
				textBox_mark[l * 2 + 1].Text = LD2.mFill_SignXY[l * 2 + 1];
				if (!LD2.isPrecise && l == 1)
				{
					break;
				}
			}
			for (int m = 0; m < 33; m++)
			{
				if (LD2.mSnIndex[m] != -1)
				{
					dataGridView_pcb.Columns[LD2.mSnIndex[m]].HeaderText = STR.LOAD_HEAD_STR[m][USR_INIT.mLanguage];
				}
			}
			refresh_SnHead();
			if (LD2.mHidenColumnList == null)
			{
				LD2.mHidenColumnList = new BindingList<int>();
			}
			for (int n = 0; n < LD2.mHidenColumnList.Count; n++)
			{
				if (LD2.mHidenColumnList[n] >= 0 && LD2.mHidenColumnList[n] < 40)
				{
					dataGridView_pcb.Columns[LD2.mHidenColumnList[n]].Visible = false;
				}
			}
		}

		private void loadcomponent_reset()
		{
			LD2.pointlist.Clear();
			dataGridView_pcb.Refresh();
			loadcomponent_reset_parameter();
			button_LoadComponentFile.Enabled = true;
		}

		private void loadcomponent_reset_parameter()
		{
			label_loadcomponent_page.Text = "0/0";
			if (LD2 == null)
			{
				LD2 = new LD_DATA2();
			}
			if (pictureBox_Sign == null)
			{
				pictureBox_Sign = new PictureBox[4] { pictureBox_Sign1, pictureBox_Sign2, pictureBox5, pictureBox3 };
			}
			for (int i = 0; i < 4; i++)
			{
				LD2.mSignPic[i] = null;
				pictureBox_Sign[i].Image = null;
			}
			try
			{
				for (int j = 0; j < 33; j++)
				{
					LD2.mSnIndex[j] = -1;
				}
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile_EXCEPTION(" loadcomponent_reset_parameter 0");
				LD2.mSnIndex = new int[33];
				for (int k = 0; k < 33; k++)
				{
					LD2.mSnIndex[k] = -1;
				}
			}
			refresh_SnHead();
			try
			{
				checkBox_PreciseImport.Checked = true;
				for (int l = 0; l < 4; l++)
				{
					LD2.record_mark[l] = -1;
				}
				for (int m = 0; m < 8; m++)
				{
					textBox_mark[m].Text = (LD2.mFill_SignXY[m] = "");
				}
				for (int n = 0; n < 4; n++)
				{
					LD2.mSignXY[n] = new Coordinate(0L, 0L);
				}
				for (int num = 0; num < 4; num++)
				{
					label_xy_mark[num].Text = MainForm0.format_XY_label_string(LD2.mSignXY[num]);
				}
				LD2.pointlist.Clear();
				init_dataGridView_pcb(LD2.pointlist);
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile_EXCEPTION(" loadcomponent_reset_parameter 1");
			}
		}

		private void init_dataGridView_pcb(BindingList<leadinelement> ldlist)
		{
			dataGridView_pcb.ClearSelection();
			dataGridView_pcb.AllowUserToAddRows = false;
			dataGridView_pcb.ReadOnly = false;
			dataGridView_pcb.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_pcb.DataSource = ldlist;
			for (int i = 0; i < dataGridView_pcb.Columns.Count; i++)
			{
				dataGridView_pcb.Columns[i].Width = 50;
				dataGridView_pcb.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridView_pcb.Columns[i].Visible = true;
				dataGridView_pcb.Columns[i].HeaderText = "n";
			}
			dataGridView_pcb.ColumnHeadersHeight = 40;
			dataGridView_pcb.RowHeadersWidth = 50;
			dataGridView_pcb.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView_pcb.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_pcb.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView_pcb.ColumnHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dataGridView_pcb.RowHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dataGridView_pcb.EnableHeadersVisualStyles = false;
			dataGridView_pcb.DefaultCellStyle.Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
			dataGridView_pcb.Refresh();
		}

		private void ToolStripMenuItem_SetMark_Click(object sender, EventArgs e)
		{
			if (LD2.mSnIndex[3] == -1)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Set X Coordinate" : "标定X坐标");
				return;
			}
			if (LD2.mSnIndex[4] == -1)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Set Y Coordinate" : "标定Y坐标");
				return;
			}
			int num = (int)((ToolStripMenuItem)sender).Tag;
			if (LD2.record_mark[num] != -1)
			{
				MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[num], Color.White);
				dataGridView_pcb.Rows[LD2.record_mark[num]].HeaderCell.Value = "";
			}
			dataGridView_pcb.Refresh();
			LD2.record_mark[num] = selectrowindex;
			if (LD2.record_mark[num] == -1)
			{
				return;
			}
			MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[num], DEF.COLOR_MARK[num]);
			dataGridView_pcb.Rows[LD2.record_mark[num]].HeaderCell.Value = "S" + (num + 1);
			textBox_mark[2 * num].Text = (LD2.mFill_SignXY[num * 2] = dataGridView_pcb.Rows[LD2.record_mark[num]].Cells[LD2.mSnIndex[3]].Value.ToString());
			textBox_mark[2 * num + 1].Text = (LD2.mFill_SignXY[num * 2 + 1] = dataGridView_pcb.Rows[LD2.record_mark[num]].Cells[LD2.mSnIndex[4]].Value.ToString());
			for (int i = 0; i < 4; i++)
			{
				if (i != num && LD2.record_mark[i] == LD2.record_mark[num])
				{
					LD2.record_mark[i] = -1;
					textBox_mark[2 * i].Text = (LD2.mFill_SignXY[2 * i] = "");
					textBox_mark[2 * i + 1].Text = (LD2.mFill_SignXY[2 * i + 1] = "");
				}
			}
		}

		private void label_signtitle_Click(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			if (LD2.record_mark[num] != -1)
			{
				int count = dataGridView_pcb.SelectedRows.Count;
				for (int i = 0; i < count; i++)
				{
					dataGridView_pcb.SelectedRows[0].Selected = false;
				}
				dataGridView_pcb.Rows[LD2.record_mark[num]].Selected = true;
				dataGridView_pcb.FirstDisplayedScrollingRowIndex = LD2.record_mark[num];
			}
		}

		private void label_signxy_DoubleClick(object sender, EventArgs e)
		{
			if (LD2 != null && LD2.mSignXY != null)
			{
				int num = (int)((Label)sender).Tag;
				Form_FillXY form_FillXY = new Form_FillXY(LD2.mSignXY[num], USR_INIT.mLanguage, "XY");
				if (form_FillXY.ShowDialog() == DialogResult.OK)
				{
					LD2.mSignXY[num] = form_FillXY.Get_FillXY();
					label_xy_mark[num].Text = MainForm0.format_XY_label_string(LD2.mSignXY[num]);
				}
			}
		}

		private void button_mark_save_Click(object sender, EventArgs e)
		{
			int r = (int)((Button)sender).Tag;
			if (MainForm0.CmMessageBox(((USR_INIT.mLanguage == 2) ? "Are you going to Save Sign " : "是否确定保存标记点") + (r + 1) + "?", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			if (LD2.mSignPara == null)
			{
				LD2.mSignPara = new MARK_PARA[4];
				for (int i = 0; i < 4; i++)
				{
					LD2.mSignPara[i] = new MARK_PARA();
				}
			}
			_ = HW.mMarkCamItem[mFn].index[0];
			if (LD2.mSignPara[r].mPara == null)
			{
				LD2.mSignPara[r].mPara = new MarkCamPara();
			}
			LD2.mSignPara[r].mPara.mLedOn = USR.mIsMarkLedOn;
			LD2.mSignPara[r].mPara.mLightOn = USR.mIsMarkLightOn;
			for (int j = 0; j < HW.mMarkLedNum; j++)
			{
				LD2.mSignPara[r].mPara.mParaLed[j] = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[j];
			}
			for (int k = 0; k < 4; k++)
			{
				LD2.mSignPara[r].mPara.mParaCam[k] = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[k];
			}
			if (MainForm0.mIsSimulation)
			{
				if (r == 0)
				{
					LD2.mSignXY[0].X = 30000 + MainForm0.U3Idx[mFn] * 10000 + (checkBox_oppoPcb_debug.Checked ? 20000 : 20000);
					LD2.mSignXY[0].Y = 30000 + MainForm0.U3Idx[mFn] * 10000 + (checkBox_oppoPcb_debug.Checked ? 20000 : 20000);
					LD2.mSignPic[0] = new Bitmap(MainForm0.SIGN_PICTURE[r]);
					Invoke((MethodInvoker)delegate
					{
						Bitmap bitmap3 = new Bitmap(LD2.mSignPic[0]);
						bitmap3.RotateFlip(RotateFlipType.Rotate180FlipX);
						pictureBox_Sign[0].Image = bitmap3;
					});
					label_xy_mark[r].Text = MainForm0.format_XY_label_string(LD2.mSignXY[0]);
				}
				else if (r == 1)
				{
					float num = 4000f;
					float num2 = 0f;
					try
					{
						float num3 = float.Parse(textBox_mark[0].Text.ToString());
						float num4 = float.Parse(textBox_mark[2].Text.ToString());
						float num5 = float.Parse(textBox_mark[1].Text.ToString());
						float num6 = float.Parse(textBox_mark[3].Text.ToString());
						num *= (float)((num3 <= num4) ? 1 : (-1));
						num2 = num * (0f - (num6 - num5)) / (num4 - num3);
					}
					catch (Exception)
					{
						MainForm0.write_to_logFile_EXCEPTION(" button_mark_save_Click 0");
						MessageBox.Show((USR_INIT.mLanguage == 2) ? "Error!" : "错误");
						return;
					}
					LD2.mSignXY[1].X = LD2.mSignXY[0].X + (int)((double)num + 0.5) * ((!checkBox_oppoPcb_debug.Checked) ? 1 : (-1));
					LD2.mSignXY[1].Y = LD2.mSignXY[0].Y + (int)((double)num2 + 0.5) * ((!checkBox_oppoPcb_debug.Checked) ? 1 : (-1));
					LD2.mSignPic[1] = new Bitmap(MainForm0.SIGN_PICTURE[r]);
					Invoke((MethodInvoker)delegate
					{
						Bitmap bitmap2 = new Bitmap(LD2.mSignPic[1]);
						bitmap2.RotateFlip(RotateFlipType.Rotate180FlipX);
						pictureBox_Sign[1].Image = bitmap2;
					});
					label_xy_mark[r].Text = MainForm0.format_XY_label_string(LD2.mSignXY[1]);
				}
				else
				{
					if (r != 2 && r != 3)
					{
						return;
					}
					try
					{
						float num7 = float.Parse(textBox_mark[0].Text.ToString());
						float num8 = float.Parse(textBox_mark[1].Text.ToString());
						float num9 = float.Parse(textBox_mark[2].Text.ToString());
						float num10 = float.Parse(textBox_mark[3].Text.ToString());
						float num11 = float.Parse(textBox_mark[r * 2].Text.ToString());
						float num12 = float.Parse(textBox_mark[r * 2 + 1].Text.ToString());
						LD2.mSignXY[r].X = LD2.mSignXY[0].X + (int)((double)((num11 - num7) * ((float)LD2.mSignXY[1].X - (float)LD2.mSignXY[0].X) / (num9 - num7)) + 0.5);
						LD2.mSignXY[r].Y = LD2.mSignXY[0].Y + (int)((double)((num12 - num8) * ((float)LD2.mSignXY[1].Y - (float)LD2.mSignXY[0].Y) / (num10 - num8)) + 0.5);
						LD2.mSignPic[r] = new Bitmap(MainForm0.SIGN_PICTURE[r]);
						Invoke((MethodInvoker)delegate
						{
							Bitmap bitmap = new Bitmap(LD2.mSignPic[r]);
							bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
							pictureBox_Sign[r].Image = bitmap;
						});
						label_xy_mark[r].Text = MainForm0.format_XY_label_string(LD2.mSignXY[r]);
					}
					catch (Exception)
					{
						MessageBox.Show((USR_INIT.mLanguage == 2) ? "please complete sign point and ref point setting!" : "请完成标记点和参考点的设置！");
					}
				}
			}
			else
			{
				LD2.mSignXY[r].X = MainForm0.mCur[MainForm0.mFn].x;
				LD2.mSignXY[r].Y = MainForm0.mCur[MainForm0.mFn].y;
				label_xy_mark[r].Text = MainForm0.format_XY_label_string(LD2.mSignXY[r]);
				Thread thread = new Thread(thread_sign_capture);
				thread.IsBackground = true;
				thread.Start(r);
			}
		}

		private void button_mark_goto_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				int num = (int)((Button)sender).Tag;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(LD2.mSignXY[num]);
			}
		}

		private void thread_sign_capture(object signno)
		{
			MainForm0.startMarkStill_andWait(mFn);
			Rectangle destRect = new Rectangle(0, 0, 150, 150);
			Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - 150) / 2, (MainForm0.mJvs_rawHeight - 150) / 2, 150, 150);
			Bitmap bitmap = new Bitmap(150, 150);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(MainForm0.mJVSBitmap[HW.mMarkCamItem[mFn].index[0]], destRect, srcRect, GraphicsUnit.Pixel);
			graphics.Dispose();
			Bitmap b = new Bitmap(bitmap);
			LD2.mSignPic[(int)signno] = bitmap;
			MethodInvoker method = delegate
			{
				Bitmap bitmap2 = new Bitmap(b);
				bitmap2.RotateFlip(RotateFlipType.Rotate180FlipX);
				pictureBox_Sign[(int)signno].Image = bitmap2;
			};
			Invoke(method);
		}

		private void ToolStripMenuItem_Sn_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			int num = (int)toolStripMenuItem.Tag;
			dataGridView_pcb.Columns[index].HeaderText = STR.LOAD_HEAD_STR[num][USR_INIT.mLanguage];
			LD2.mSnIndex[num] = index;
			refresh_toolStripMenuItem_visibility(index, (SnHead)num);
		}

		private void ToolStripMenuItem_ClearLabel_Click(object sender, EventArgs e)
		{
			dataGridView_pcb.Columns[index].HeaderText = "n";
			for (int i = 0; i < 33; i++)
			{
				if (LD2.mSnIndex[i] == index && index != -1)
				{
					LD2.mSnIndex[i] = -1;
					refresh_SnHead();
				}
			}
		}

		private void refresh_SnHead()
		{
			for (int i = 0; i < 33; i++)
			{
				ts_sn[i].Visible = LD2.mSnIndex[i] == -1;
			}
		}

		private void refresh_toolStripMenuItem_visibility(int override_index, SnHead Sn)
		{
			for (int i = 0; i < 33; i++)
			{
				if (i != (int)Sn && override_index == LD2.mSnIndex[i])
				{
					LD2.mSnIndex[i] = -1;
				}
			}
			refresh_SnHead();
		}

		private void ToolStripMenuItem_HidenCurColumn_Click(object sender, EventArgs e)
		{
			if (index >= 0 && index < 40 && LD2 != null)
			{
				if (LD2.mHidenColumnList == null)
				{
					LD2.mHidenColumnList = new BindingList<int>();
				}
				LD2.mHidenColumnList.Add(index);
				dataGridView_pcb.Columns[index].Visible = false;
			}
		}

		private void ToolStripMenuItem_ShowAllColumns_Click(object sender, EventArgs e)
		{
			if (LD2 != null)
			{
				if (LD2.mHidenColumnList == null)
				{
					LD2.mHidenColumnList = new BindingList<int>();
				}
				LD2.mHidenColumnList.Clear();
				for (int i = 0; i < 40; i++)
				{
					dataGridView_pcb.Columns[i].Visible = true;
				}
			}
		}

		private void checkBox_PreciseImport_CheckedChanged(object sender, EventArgs e)
		{
			if (LD2 == null)
			{
				return;
			}
			bool @checked = checkBox_PreciseImport.Checked;
			panel102.Visible = @checked;
			panel103.Visible = @checked;
			panel104.Visible = @checked;
			panel105.Visible = @checked;
			panel106.Visible = @checked;
			toolStripSeparator7.Visible = @checked;
			toolStripMenuItem_SetRef0.Visible = @checked;
			toolStripMenuItem_SetRef1.Visible = @checked;
			PictureBox pictureBox = pictureBox5;
			bool visible = (pictureBox3.Visible = @checked);
			pictureBox.Visible = visible;
			LD2.isPrecise = checkBox_PreciseImport.Checked;
			for (int i = 2; i < 4; i++)
			{
				if (LD2.record_mark[i] != -1)
				{
					dataGridView_pcb.Rows[LD2.record_mark[i]].HeaderCell.Value = (@checked ? ("S" + (i + 1)) : "");
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[i], @checked ? DEF.COLOR_MARK[i] : Color.White);
				}
			}
		}

		private void dataGridView_pcb_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			index = e.ColumnIndex;
			int num = 0;
			for (int i = dataGridView_pcb.FirstDisplayedScrollingColumnIndex; i < index; i++)
			{
				if (dataGridView_pcb.Columns[i].Visible)
				{
					num += dataGridView_pcb.Columns[i].Width;
				}
			}
			contextMenuStrip_Sn.Show(dataGridView_pcb, new Point(num + e.X, e.Y));
		}

		private void dataGridView_pcb_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			dataGridView_pcb.Rows[e.RowIndex].Selected = true;
			if (e.Button == MouseButtons.Right && e.RowIndex != -1)
			{
				selectrowindex = e.RowIndex;
				mLeadingCurIndex = e.RowIndex;
				for (int i = 0; i < 4; i++)
				{
					toolStripMenuItem_SetMark[i].Text = STR.IMPORT_SET_AS_SIGN[USR_INIT.mLanguage] + (i + 1) + "(S" + (i + 1) + ")";
				}
				ToolStripMenuItem_delete.Text = STR.DELETE[USR_INIT.mLanguage];
				contextMenuStrip2.Show(new Point(Control.MousePosition.X, Control.MousePosition.Y));
			}
			if (e.Button == MouseButtons.Left)
			{
				mLeadingCurIndex = e.RowIndex;
			}
			label_loadcomponent_page.Text = (e.RowIndex + 1).ToString() + "/" + dataGridView_pcb.Rows.Count;
		}

		private void button_LoadComponentFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = ((USR_INIT.mLanguage == 2) ? "Text|*.txt;*.csv" : "坐标文件|*.txt;*.csv");
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			MainForm0.uc_usroperarion[MainForm0.mFn].switch_to_cam(CameraType.Mark);
			loadcomponent_reset_parameter();
			string fileName = openFileDialog.FileName;
			switch (fileName.Substring(fileName.LastIndexOf(".") + 1, fileName.Length - fileName.LastIndexOf(".") - 1))
			{
			case "txt":
			case "TXT":
			{
				StreamReader streamReader2 = new StreamReader(fileName, Encoding.Default);
				int num3 = 0;
				int num4 = -1;
				string text2;
				while ((text2 = streamReader2.ReadLine()) != null)
				{
					text2 = text2.Replace("\t", " ");
					string[] array3 = text2.Split(' ');
					List<string> list3 = new List<string>(array3);
					list3.Remove("");
					if (array3 != null)
					{
						num3 = array3.Length;
						while (list3.Contains(""))
						{
							list3.Remove("");
						}
						if (num4 < list3.Count)
						{
							num4 = list3.Count;
						}
					}
					num3++;
				}
				streamReader2.Close();
				streamReader2.Dispose();
				for (int l = 2; l < dataGridView_pcb.Columns.Count - 2; l++)
				{
					if (l - 2 >= num4)
					{
						dataGridView_pcb.Columns[l].Visible = false;
					}
				}
				dataGridView_pcb.Columns[dataGridView_pcb.Columns.Count - 1].Visible = true;
				streamReader2 = new StreamReader(fileName, Encoding.Default);
				while ((text2 = streamReader2.ReadLine()) != null)
				{
					text2 = text2.Replace("\t", " ");
					string[] array4 = text2.Split(' ');
					List<string> list4 = new List<string>(array4);
					list4.Remove("");
					if (array4 != null)
					{
						num3 = array4.Length;
						while (list4.Contains(""))
						{
							list4.Remove("");
						}
						leadinelement leadinelement2 = new leadinelement();
						for (int m = 0; m < 40; m++)
						{
							if (m < list4.Count)
							{
								leadinelement2.sn[m] = list4[m].Replace("mm", "").Replace("mil", "").Replace(",", "");
							}
							else
							{
								leadinelement2.sn[m] = "";
							}
						}
						LD2.pointlist.Add(leadinelement2);
					}
					num3++;
				}
				break;
			}
			case "csv":
			case "CSV":
			{
				StreamReader streamReader;
				try
				{
					streamReader = new StreamReader(fileName, Encoding.Default);
				}
				catch (Exception)
				{
					MainForm0.write_to_logFile_EXCEPTION("导入文件打开失败");
					MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Open file fail!" : "文件打开失败！", MessageBoxButtons.OK);
					return;
				}
				int num = 0;
				int num2 = -1;
				string text;
				while ((text = streamReader.ReadLine()) != null)
				{
					text = text.Replace("\t", " ");
					string[] array = text.Split(',');
					List<string> list = new List<string>(array);
					if (array != null)
					{
						num = array.Length;
						if (num2 < list.Count)
						{
							num2 = list.Count;
						}
					}
					num++;
				}
				streamReader.Close();
				streamReader.Dispose();
				for (int i = 2; i < dataGridView_pcb.Columns.Count - 2; i++)
				{
					if (i - 2 >= num2)
					{
						dataGridView_pcb.Columns[i].Visible = false;
					}
				}
				dataGridView_pcb.Columns[dataGridView_pcb.Columns.Count - 1].Visible = true;
				streamReader = new StreamReader(fileName, Encoding.Default);
				while ((text = streamReader.ReadLine()) != null)
				{
					text = text.Replace("\t", " ");
					string[] array2 = text.Split(',');
					if (array2 != null)
					{
						for (int j = 0; j < array2.Count(); j++)
						{
							array2[j] = array2[j].Replace("\"", "");
						}
					}
					List<string> list2 = new List<string>(array2);
					if (array2 != null)
					{
						num = array2.Length;
						leadinelement leadinelement = new leadinelement();
						for (int k = 0; k < 40; k++)
						{
							if (k < list2.Count)
							{
								leadinelement.sn[k] = list2[k].Replace("mm", "").Replace("mil", "").Replace(",", "");
							}
							else
							{
								leadinelement.sn[k] = "";
							}
						}
						LD2.pointlist.Add(leadinelement);
					}
					num++;
				}
				break;
			}
			}
			if (LD2.pointlist.Count == 0)
			{
				MainForm0.CmMessageBoxTop_Ok("导入文件格式不正确!");
				return;
			}
			for (int n = 0; n < dataGridView_pcb.ColumnCount; n++)
			{
				SnHead snHead = check_return_snhead(LD2.pointlist[0].sn[n]);
				if (snHead < SnHead.NUM)
				{
					LD2.mSnIndex[(int)snHead] = n;
					dataGridView_pcb.Columns[n].HeaderText = STR.LOAD_HEAD_STR[(int)snHead][USR_INIT.mLanguage];
				}
			}
			refresh_SnHead();
			if (LD2.pointlist != null && LD2.pointlist.Count != 0)
			{
				label_loadcomponent_page.Text = "0/" + LD2.pointlist.Count;
			}
			else
			{
				label_loadcomponent_page.Text = "0/0";
			}
		}

		public SnHead check_return_snhead(string str)
		{
			if (str == "位号" || str == "位置号")
			{
				return SnHead.LABEL;
			}
			if (str == "封装")
			{
				return SnHead.FOOTPRINT;
			}
			if (str == "型号" || str == "值")
			{
				return SnHead.VALUE;
			}
			if (str == "X" || str == "X坐标" || str == "X中心")
			{
				return SnHead.X;
			}
			if (str == "Y" || str == "Y坐标" || str == "Y中心")
			{
				return SnHead.Y;
			}
			if (str == "A" || str == "角度")
			{
				return SnHead.A;
			}
			if (str == "供料器" || str == "供料器型号" || str == "供料器类型" || str == "飞达" || str == "飞达型号" || str == "飞达类型")
			{
				return SnHead.FEEDERTYPE;
			}
			if (str == "料站号" || str == "飞达号" || str == "料站编号" || str == "飞达编号")
			{
				return SnHead.STACKNO;
			}
			if (str == "吸嘴类型" || str == "吸嘴型号")
			{
				return SnHead.NOZZLETYPE;
			}
			if (str == "吸嘴号" || str == "吸嘴编号")
			{
				return SnHead.NOZZLENO;
			}
			if (str == "相机" || str == "相机类型" || str == "相机型号")
			{
				return SnHead.CAMERA;
			}
			if (str == "视觉" || str == "视觉类型" || str == "识别类型" || str == "识别算法" || str == "视觉算法")
			{
				return SnHead.VISUAL;
			}
			if (str == "精准闭环" || str == "精准模式" || str == "闭环模式")
			{
				return SnHead.ISPRICISE;
			}
			if (str == "扫描半径")
			{
				return SnHead.SCANR;
			}
			if (str == "视觉阈值")
			{
				return SnHead.THRESHOLD;
			}
			if (str == "长度" || str == "长" || str == "元件长度")
			{
				return SnHead.LENGHT;
			}
			if (str == "宽度" || str == "宽" || str == "元件宽度")
			{
				return SnHead.WIDTH;
			}
			if (str == "高度" || str == "高" || str == "元件高度")
			{
				return SnHead.HEIGHT;
			}
			if (str == "特征识别")
			{
				return SnHead.ISCOLLECT;
			}
			if (str == "识别容差")
			{
				return SnHead.COLLECT_DELTA;
			}
			if (str == "取料下压偏移" || str == "取料下压缓冲" || str == "拾取下压偏移" || str == "取料下压缓冲")
			{
				return SnHead.PIK_H_OFFSET;
			}
			if (str == "取料上拉速度" || str == "取料Z上拉速度" || str == "取料Z轴上拉速度")
			{
				return SnHead.SPEEDZ_UP;
			}
			if (str == "取料下伸速度" || str == "取料Z下伸速度" || str == "取料Z轴下伸速度")
			{
				return SnHead.SPEEDZ_DOWN;
			}
			if (str == "取料延时")
			{
				return SnHead.PIK_DELAY;
			}
			if (!(str == "贴装下压偏移") && !(str == "贴装下压缓冲"))
			{
				switch (str)
				{
				case "贴装下压偏移":
				case "贴装下压缓冲":
					break;
				case "贴装上拉速度":
				case "贴装Z上拉速度":
				case "贴装Z轴上拉速度":
					return SnHead.ZMNT_UP_SPEED;
				case "贴装下伸速度":
				case "贴装Z下伸速度":
				case "贴装Z轴下伸速度":
					return SnHead.ZMNT_DOWN_SPEED;
				case "贴装延时":
					return SnHead.MNT_DELAY;
				case "同取容差":
					return SnHead.SAMPIK;
				case "是否贴装":
				case "贴装":
					return SnHead.ISMOUNT;
				case "降速搬运":
				case "是否降速搬运":
				case "降速":
					return SnHead.ISLOWSPEED;
				case "是否高料":
				case "高料":
					return SnHead.ISHIGH;
				default:
					return SnHead.NUM;
				}
			}
			return SnHead.MNT_H_OFFSET;
		}

		private void button_addBom_Click(object sender, EventArgs e)
		{
			if (LD2.mSnIndex[0] == -1 || LD2.mSnIndex[1] == -1 || LD2.mSnIndex[2] == -1)
			{
				MessageBox.Show((USR_INIT.mLanguage == 2) ? "Please Complete Lable/Value/Footprint Title" : "请标记位号/型号/封装！");
				return;
			}
			if (LD2.bom == null)
			{
				LD2.bom = new BOM_DATA();
			}
			Form_AddBom form_AddBom = new Form_AddBom(USR_INIT.mLanguage, LD2.bom);
			if (form_AddBom.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			BindingList<BomInfo> bom_output = LD2.bom.bom_output;
			if (bom_output.Count <= 0)
			{
				return;
			}
			leadinelement[] array = null;
			array = LD2.pointlist.OrderByDescending((leadinelement a) => a.sn[LD2.mSnIndex[0]].Length).ToArray();
			for (int i = 0; i < array.Count(); i++)
			{
				string text = array[i].sn[LD2.mSnIndex[0]];
				for (int j = 0; j < bom_output.Count; j++)
				{
					if ((" " + bom_output[j].Label + " ").Contains(" " + text + " "))
					{
						bom_output[j].Label = (" " + bom_output[j].Label + " ").Replace(" " + text + " ", "  ");
						array[i].sn[LD2.mSnIndex[1]] = bom_output[j].Value;
						array[i].sn[LD2.mSnIndex[2]] = bom_output[j].Footprint;
						break;
					}
				}
			}
			dataGridView_pcb.Refresh();
			dataGridView_pcb.ClearSelection();
			for (int k = 0; k < dataGridView_pcb.Rows.Count; k++)
			{
				dataGridView_pcb.Rows[k].Cells[LD2.mSnIndex[2]].Selected = true;
				dataGridView_pcb.Rows[k].Cells[LD2.mSnIndex[1]].Selected = true;
			}
		}

		private void button_pcbview_Click(object sender, EventArgs e)
		{
			if (!check_legal("run") || LD2 == null || LD2.pointlist == null || LD2.pointlist.Count < 4)
			{
				return;
			}
			BindingList<ChipUnit_F> bindingList = new BindingList<ChipUnit_F>();
			for (int i = 0; i < LD2.pointlist.Count; i++)
			{
				ChipUnit_F chipUnit_F = new ChipUnit_F();
				chipUnit_F.X = float.Parse(LD2.pointlist[i].sn[LD2.mSnIndex[3]].ToString());
				chipUnit_F.Y = float.Parse(LD2.pointlist[i].sn[LD2.mSnIndex[4]].ToString()) * -1f;
				chipUnit_F.A = float.Parse(LD2.pointlist[i].sn[LD2.mSnIndex[5]].ToString());
				if (LD2.mSnIndex[0] != -1)
				{
					chipUnit_F.Label = LD2.pointlist[i].sn[LD2.mSnIndex[0]];
				}
				bindingList.Add(chipUnit_F);
			}
			Form_PcbView form_PcbView = new Form_PcbView(USR_INIT.mLanguage, "import", bindingList, LD2.record_mark, LD2.isPrecise, mFakeMk23, null);
			form_PcbView.ShowDialog();
			BindingList<int> original_signindex = form_PcbView.get_original_signindex();
			for (int j = 0; j < 4 && (j < 2 || LD2.isPrecise); j++)
			{
				if (original_signindex[j] != -1)
				{
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, original_signindex[j], Color.White);
					dataGridView_pcb.Rows[original_signindex[j]].HeaderCell.Value = "";
					textBox_mark[2 * j].Text = (LD2.mFill_SignXY[2 * j] = "");
					textBox_mark[2 * j + 1].Text = (LD2.mFill_SignXY[2 * j + 1] = "");
				}
			}
			for (int k = 0; k < 4 && (k < 2 || LD2.isPrecise); k++)
			{
				if (LD2.record_mark[k] != -1)
				{
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[k], DEF.COLOR_MARK[k]);
					dataGridView_pcb.Rows[LD2.record_mark[k]].HeaderCell.Value = "S" + (k + 1);
					textBox_mark[2 * k].Text = (LD2.mFill_SignXY[k * 2] = dataGridView_pcb.Rows[LD2.record_mark[k]].Cells[LD2.mSnIndex[3]].Value.ToString());
					textBox_mark[2 * k + 1].Text = (LD2.mFill_SignXY[k * 2 + 1] = dataGridView_pcb.Rows[LD2.record_mark[k]].Cells[LD2.mSnIndex[4]].Value.ToString());
				}
			}
		}

		private bool check_legal(string mode)
		{
			if (LD2.mSnIndex[3] == -1 || LD2.mSnIndex[4] == -1 || LD2.mSnIndex[5] == -1)
			{
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "SET X" : "请标定X坐标/Y坐标/角度", MessageBoxButtons.OK);
				return false;
			}
			for (int i = 0; i < dataGridView_pcb.Rows.Count; i++)
			{
				MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, i, Color.FromArgb(255, 255, 255));
			}
			for (int j = 0; j < 4; j++)
			{
				if (LD2.record_mark[j] != -1)
				{
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[j], DEF.COLOR_MARK[j]);
				}
				if (!LD2.isPrecise && j == 1)
				{
					break;
				}
			}
			BindingList<BindingList<int>> bindingList = new BindingList<BindingList<int>>();
			BindingList<BindingList<int>> bindingList2 = new BindingList<BindingList<int>>();
			for (int k = 0; k < dataGridView_pcb.Rows.Count; k++)
			{
				BindingList<int> bindingList3 = new BindingList<int>();
				bindingList3.Add(k);
				BindingList<int> bindingList4 = new BindingList<int>();
				bindingList4.Add(k);
				for (int l = 0; l < 33; l++)
				{
					if (LD2.mSnIndex[l] < 0 || LD2.mSnIndex[l] >= 33)
					{
						continue;
					}
					switch (l)
					{
					case 7:
						if (FeederType.N_A == check_return_feedertype(dataGridView_pcb.Rows[k].Cells[LD2.mSnIndex[l]].Value.ToString()))
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						continue;
					case 9:
						if (-1 == check_return_nozzletype(dataGridView_pcb.Rows[k].Cells[LD2.mSnIndex[l]].Value.ToString()))
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						continue;
					case 11:
						if (CameraType.N_A == check_return_cameratype(dataGridView_pcb.Rows[k].Cells[LD2.mSnIndex[l]].Value.ToString()))
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						continue;
					case 12:
						if (VisualType.N_A == check_return_visualtype(dataGridView_pcb.Rows[k].Cells[LD2.mSnIndex[l]].Value.ToString()))
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						continue;
					case 0:
					case 1:
					case 2:
					case 6:
					case 13:
					case 19:
					case 30:
					case 31:
					case 32:
						continue;
					}
					float num = 0f;
					try
					{
						num = float.Parse(dataGridView_pcb.Rows[k].Cells[LD2.mSnIndex[l]].Value.ToString());
					}
					catch (Exception)
					{
						MainForm0.write_to_logFile("EXCEPTION: 导入坐标表格数据不合法：行" + (k + 1) + " 列" + (LD2.mSnIndex[l] + 1));
						if (l == 3 || l == 4 || l == 5)
						{
							bindingList4.Add(LD2.mSnIndex[l]);
						}
						else
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						continue;
					}
					switch (l)
					{
					case 8:
						if ((int)num < 0 || (int)num > HW.mStackNum[MainForm0.mFn][0])
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 10:
						if ((int)num <= 0 || (int)num > HW.mZnNum[MainForm0.mFn])
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 14:
						if ((int)num < 0 || (int)num > 920)
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 15:
						if ((int)num < 0 || (int)num > 255)
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 16:
					case 17:
					case 18:
						if (num < 0f)
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 20:
						if (num < 0f || num > 100f)
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 21:
					case 25:
						if (num < -20f || (int)num > 20)
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 22:
					case 23:
					case 26:
					case 27:
						if (num <= 0f || (int)num > 64)
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 24:
					case 28:
						if (num <= 0f || (int)num > 1000)
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					case 29:
						if (num < 0f || (int)num > 10)
						{
							bindingList3.Add(LD2.mSnIndex[l]);
						}
						break;
					}
				}
				if (bindingList4.Count > 1)
				{
					bindingList.Add(bindingList4);
				}
				if (bindingList3.Count > 1)
				{
					bindingList2.Add(bindingList3);
				}
			}
			if (bindingList2.Count > 0)
			{
				for (int m = 0; m < bindingList2.Count; m++)
				{
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, bindingList2[m][0], Color.FromArgb(150, 150, 255));
					for (int n = 1; n < bindingList2[m].Count; n++)
					{
						dataGridView_pcb.Rows[bindingList2[m][0]].Cells[bindingList2[m][n]].Style.BackColor = Color.FromArgb(50, 50, 255);
					}
				}
			}
			if (bindingList.Count > 0)
			{
				for (int num2 = 0; num2 < bindingList.Count; num2++)
				{
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, bindingList[num2][0], Color.FromArgb(255, 150, 150));
					for (int num3 = 1; num3 < bindingList[num2].Count; num3++)
					{
						dataGridView_pcb.Rows[bindingList[num2][0]].Cells[bindingList[num2][num3]].Style.BackColor = Color.FromArgb(255, 50, 50);
					}
				}
			}
			if (mode == "button")
			{
				int num4 = 0;
				int num5 = 0;
				for (int num6 = 0; num6 < bindingList.Count; num6++)
				{
					num4 += bindingList[num6].Count - 1;
				}
				for (int num7 = 0; num7 < bindingList2.Count; num7++)
				{
					num5 += bindingList2[num7].Count - 1;
				}
				string text = "检测结果：" + Environment.NewLine + "错误数量 " + num4 + Environment.NewLine + "警告数量 " + num5;
				string text2 = "Check result: " + Environment.NewLine + "Error Num " + num4 + Environment.NewLine + "Warning Num " + num5;
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text2 : text, MessageBoxButtons.OK);
			}
			else if (mode == "run" && bindingList.Count > 0)
			{
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Please change invalid data!" : "请修正非法数据！", MessageBoxButtons.OK);
			}
			if (bindingList.Count > 0)
			{
				return false;
			}
			return true;
		}

		public FeederType check_return_feedertype(string str)
		{
			switch (str)
			{
			case "CL8_2_0201":
			case "CL8-2-0201":
				return FeederType.CL8_2_0201;
			case "CL8_2":
			case "CL8-2":
				return FeederType.CL8_2;
			case "CL8_4":
			case "CL8-4":
				return FeederType.CL8_4;
			case "CL12":
				return FeederType.CL12;
			case "CL16":
				return FeederType.CL16;
			case "CL24":
				return FeederType.CL24;
			case "CL32":
				return FeederType.CL32;
			case "CL44":
				return FeederType.CL44;
			case "料盘":
				return FeederType.Plate;
			case "震动飞达":
			case "振动飞达":
				return FeederType.Vibra;
			default:
				return FeederType.N_A;
			}
		}

		public ProviderType check_return_providertype(string str)
		{
			switch (str)
			{
			case "CL8_2_0201":
			case "CL8-2-0201":
				return ProviderType.Feedr;
			case "CL8_2":
			case "CL8-2":
				return ProviderType.Feedr;
			case "CL8_4":
			case "CL8-4":
				return ProviderType.Feedr;
			case "CL12":
				return ProviderType.Feedr;
			case "CL16":
				return ProviderType.Feedr;
			case "CL24":
				return ProviderType.Feedr;
			case "料盘":
				return ProviderType.Plate;
			case "震动飞达":
			case "振动飞达":
				return ProviderType.Vibra;
			default:
				return ProviderType.Feedr;
			}
		}

		public static ProviderType check_return_providertype(FeederType fd)
		{
			return fd switch
			{
				FeederType.Vibra => ProviderType.Vibra, 
				FeederType.Plate => ProviderType.Plate, 
				_ => ProviderType.Feedr, 
			};
		}

		public int check_return_intno(string str)
		{
			float num = 0f;
			try
			{
				num = float.Parse(str);
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile("EXCEPTION:check_return_intno " + str);
				num = 0f;
			}
			return (int)num;
		}

		public float check_return_floatvalue(string str)
		{
			float num = 0f;
			try
			{
				return float.Parse(str);
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile("EXCEPTION:check_return_floatvalue " + str);
				return 0f;
			}
		}

		public int check_return_nozzletype(string str)
		{
			return str switch
			{
				"500" => 0, 
				"501" => 1, 
				"502" => 2, 
				"503" => 3, 
				"504" => 4, 
				"505" => 5, 
				"506" => 6, 
				"507" => 7, 
				"508" => 8, 
				"509" => 9, 
				_ => -1, 
			};
		}

		public CameraType check_return_cameratype(string str)
		{
			switch (str)
			{
			case "普通相机":
			case "快速相机":
				return CameraType.Fast;
			case "高清相机":
				return CameraType.High;
			case "无相机":
				return CameraType.None;
			default:
				return CameraType.N_A;
			}
		}

		public VisualType check_return_visualtype(string str)
		{
			switch (str)
			{
			case "普通视觉":
			case "普通识别":
			case "标准视觉":
			case "标准识别":
				return VisualType.Normal;
			case "模糊视觉":
			case "模糊识别":
				return VisualType.Draft;
			case "三角透镜":
				return VisualType.TriAG;
			case "忽略角度":
				return VisualType.NoAngle;
			case "半角补偿":
			case "半角识别":
				return VisualType.D45Angle;
			case "多体识别":
				return VisualType.MultiRec;
			case "降噪处理":
				return VisualType.NormalNew1;
			case "SOT23-3":
				return VisualType.SOT23_3;
			case "大功率灯":
				return VisualType.Ellipe;
			case "精准BGA":
				return VisualType.ConvexBGA;
			case "矩形玻璃片":
				return VisualType.TranRec0;
			case "无极性电感":
				return VisualType.NonpolarHn;
			case "ICNT7183":
				return VisualType.YIX_ICNT7183;
			case "BF5325":
				return VisualType.YIX_BF5325;
			case "标准矩形":
				return VisualType.Rectangle;
			default:
				return VisualType.N_A;
			}
		}

		public LoopType check_return_looptype(string str)
		{
			switch (str)
			{
			case "开环":
			case "普通开环":
			case "标准开环":
				return LoopType.OpenLoop;
			case "二阶闭环":
				return LoopType.HalfLoop;
			case "精准闭环":
			case "全闭环":
				return LoopType.CloseLoop;
			default:
				return LoopType.N_A;
			}
		}

		public bool check_return_ismount(string str)
		{
			switch (str)
			{
			case "不贴装":
			case "不贴":
			case "跳空":
			case "人工跳空":
			case "否":
				return false;
			default:
				return true;
			}
		}

		public bool check_return_islowspeed(string str)
		{
			switch (str)
			{
			case "降速搬运":
			case "降速":
			case "是":
				return true;
			default:
				return false;
			}
		}

		public bool check_return_iscollect(string str)
		{
			if (str == "是")
			{
				return true;
			}
			return false;
		}

		public bool check_return_ispricise(string str)
		{
			if (str == "精准闭环" || str == "精准模式" || str == "精准识别" || str == "精准视觉" || str == "精准识别" || str == "是" || str == "闭环" || str == "闭环")
			{
				return true;
			}
			return false;
		}

		public bool check_return_ishigh(string str)
		{
			switch (str)
			{
			case "高料":
			case "是高料":
			case "是":
				return true;
			default:
				return false;
			}
		}

		private void button_importLegal_Click(object sender, EventArgs e)
		{
			check_legal("button");
		}

		private void button_importAngle_Click(object sender, EventArgs e)
		{
			if (LD2 == null || LD2.mSnIndex == null)
			{
				return;
			}
			if (LD2.mSnIndex[5] < 0)
			{
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Please confirm Angle!" : "请确认角度所在列!", MessageBoxButtons.OK);
				return;
			}
			Form_ImportAngle form_ImportAngle = new Form_ImportAngle(USR);
			if (form_ImportAngle.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			int num = LD2.mSnIndex[5];
			for (int i = 0; i < dataGridView_pcb.RowCount; i++)
			{
				float num2 = 0f;
				try
				{
					num2 = float.Parse(dataGridView_pcb.Rows[i].Cells[num].Value.ToString());
				}
				catch (Exception)
				{
					continue;
				}
				for (num2 = 360f - num2; num2 > 180f; num2 -= 360f)
				{
				}
				for (; num2 <= -180f; num2 += 360f)
				{
				}
				dataGridView_pcb.Rows[i].Cells[num].Value = num2.ToString();
				LD2.pointlist[i].sn[num] = num2.ToString();
			}
		}

		private void button_runSign_Click(object sender, EventArgs e)
		{
			if (check_legal("run"))
			{
				autofindmark();
			}
		}

		private void autofindmark()
		{
			if (LD2.pointlist.Count < 4)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (LD2.record_mark[i] != -1)
				{
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[i], Color.White);
					dataGridView_pcb.Rows[LD2.record_mark[i]].HeaderCell.Value = "";
				}
				textBox_mark[i * 2].Text = (LD2.mFill_SignXY[i * 2] = "");
				textBox_mark[i * 2 + 1].Text = (LD2.mFill_SignXY[i * 2 + 1] = "");
				LD2.record_mark[i] = -1;
				if (!LD2.isPrecise && i == 1)
				{
					break;
				}
			}
			BindingList<CoordinateFloat> bindingList = new BindingList<CoordinateFloat>();
			for (int j = 0; j < LD2.pointlist.Count; j++)
			{
				CoordinateFloat coordinateFloat = new CoordinateFloat();
				coordinateFloat.X = float.Parse(dataGridView_pcb.Rows[j].Cells[LD2.mSnIndex[3]].Value.ToString());
				coordinateFloat.Y = float.Parse(dataGridView_pcb.Rows[j].Cells[LD2.mSnIndex[4]].Value.ToString());
				bindingList.Add(coordinateFloat);
			}
			int num = -1;
			int num2 = -1;
			float num3 = 0f;
			for (int k = 0; k < bindingList.Count; k++)
			{
				for (int l = k + 1; l < bindingList.Count; l++)
				{
					float num4 = (bindingList[k].X - bindingList[l].X) * (bindingList[k].X - bindingList[l].X) + (bindingList[k].Y - bindingList[l].Y) * (bindingList[k].Y - bindingList[l].Y);
					if (num4 > num3)
					{
						num = k;
						num2 = l;
						num3 = num4;
					}
				}
			}
			if (num != -1 && num2 != -1)
			{
				if (bindingList[num].X > bindingList[num2].X)
				{
					int num5 = num;
					num = num2;
					num2 = num5;
				}
				LD2.record_mark[0] = num;
				LD2.record_mark[1] = num2;
				if (LD2.isPrecise)
				{
					int num6 = -1;
					int num7 = -1;
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = Math.Atan2(bindingList[num2].Y - bindingList[num].Y, bindingList[num2].X - bindingList[num].X);
					for (int m = 0; m < bindingList.Count; m++)
					{
						if (m == num || m == num2)
						{
							continue;
						}
						double num11 = Math.Sqrt((bindingList[m].X - bindingList[num].X) * (bindingList[m].X - bindingList[num].X) + (bindingList[m].Y - bindingList[num].Y) * (bindingList[m].Y - bindingList[num].Y));
						double num12 = Math.Sqrt((bindingList[m].X - bindingList[num2].X) * (bindingList[m].X - bindingList[num2].X) + (bindingList[m].Y - bindingList[num2].Y) * (bindingList[m].Y - bindingList[num2].Y));
						double num13 = num11 + num12;
						double num14 = Math.Atan2(bindingList[m].Y - bindingList[num].Y, bindingList[m].X - bindingList[num].X) - num10;
						if (num14 >= 0.0)
						{
							if (num13 > num8)
							{
								num8 = num13;
								num6 = m;
							}
						}
						else if (num13 > num9)
						{
							num9 = num13;
							num7 = m;
						}
					}
					if (num6 == -1 || num7 == -1)
					{
						int num15 = -1;
						int num16 = -1;
						double num17 = 0.0;
						num15 = ((num6 != -1) ? num6 : num7);
						for (int n = 0; n < bindingList.Count; n++)
						{
							if (n != num && n != num2 && n != num15)
							{
								double num18 = Math.Sqrt((bindingList[n].X - bindingList[num].X) * (bindingList[n].X - bindingList[num].X) + (bindingList[n].Y - bindingList[num].Y) * (bindingList[n].Y - bindingList[num].Y));
								double num19 = Math.Sqrt((bindingList[n].X - bindingList[num2].X) * (bindingList[n].X - bindingList[num2].X) + (bindingList[n].Y - bindingList[num2].Y) * (bindingList[n].Y - bindingList[num2].Y));
								double num20 = Math.Sqrt((bindingList[n].X - bindingList[num15].X) * (bindingList[n].X - bindingList[num15].X) + (bindingList[n].Y - bindingList[num15].Y) * (bindingList[n].Y - bindingList[num15].Y));
								double num21 = num18 + num19 + num20;
								if (num21 > num17)
								{
									num17 = num21;
									num16 = n;
								}
							}
						}
						if (num6 == -1)
						{
							num6 = num16;
						}
						else
						{
							num7 = num16;
						}
					}
					LD2.record_mark[2] = num6;
					LD2.record_mark[3] = num7;
					BindingList<int> bindingList2 = new BindingList<int>();
					for (int num22 = 0; num22 < 4; num22++)
					{
						bindingList2.Add(LD2.record_mark[num22]);
					}
					int num23 = 10;
					while (true)
					{
						int num24 = 0;
						for (int num25 = 0; num25 < 4 && Math.Abs(bindingList[bindingList2[num25]].X) < (float)num23 && Math.Abs(bindingList[bindingList2[num25]].Y) < (float)num23; num25++)
						{
							num24++;
						}
						if (num24 == 4)
						{
							break;
						}
						num23 *= 10;
					}
					double[] array = new double[4];
					double[] array2 = array;
					BindingList<double> bindingList3 = new BindingList<double>();
					for (int num26 = 0; num26 < 4; num26++)
					{
						bindingList[bindingList2[num26]].X += num23;
						bindingList[bindingList2[num26]].Y *= -1f;
						bindingList[bindingList2[num26]].Y += num23;
						array2[num26] = Math.Sqrt(bindingList[bindingList2[num26]].X * bindingList[bindingList2[num26]].X + bindingList[bindingList2[num26]].Y * bindingList[bindingList2[num26]].Y);
						bindingList3.Add(array2[num26]);
					}
					double[] array3 = bindingList3.OrderBy((double a) => a).ToArray();
					bindingList3.Clear();
					for (int num27 = 0; num27 < array3.Count(); num27++)
					{
						bindingList3.Add(array3[num27]);
					}
					for (int num28 = 0; num28 < 4; num28++)
					{
						if (bindingList3[0] == array2[num28])
						{
							LD2.record_mark[0] = bindingList2[num28];
							LD2.record_mark[1] = bindingList2[num28 / 2 * 2 + (1 - num28 % 2)];
							bindingList2.Remove(LD2.record_mark[0]);
							bindingList2.Remove(LD2.record_mark[1]);
							double num29 = Math.Atan2(bindingList[LD2.record_mark[1]].Y - bindingList[LD2.record_mark[0]].Y, bindingList[LD2.record_mark[1]].X - bindingList[LD2.record_mark[0]].X);
							double num30 = Math.Atan2(bindingList[bindingList2[0]].Y - bindingList[LD2.record_mark[0]].Y, bindingList[bindingList2[0]].X - bindingList[LD2.record_mark[0]].X);
							if (num30 < num29)
							{
								LD2.record_mark[2] = bindingList2[0];
								LD2.record_mark[3] = bindingList2[1];
							}
							else
							{
								LD2.record_mark[2] = bindingList2[1];
								LD2.record_mark[3] = bindingList2[0];
							}
							break;
						}
					}
				}
				for (int num31 = 0; num31 < 4; num31++)
				{
					LD2.mSignPic[num31] = null;
					LD2.mSignXY[num31] = new Coordinate(0L, 0L);
					pictureBox_Sign[num31].Image = null;
					label_xy_mark[num31].Text = MainForm0.format_XY_label_string(LD2.mSignXY[num31]);
					if (LD2.record_mark[num31] != -1)
					{
						dataGridView_pcb.Rows[LD2.record_mark[num31]].HeaderCell.Value = "S" + (num31 + 1);
						textBox_mark[num31 * 2].Text = (LD2.mFill_SignXY[num31 * 2] = dataGridView_pcb.Rows[LD2.record_mark[num31]].Cells[LD2.mSnIndex[3]].Value.ToString());
						textBox_mark[num31 * 2 + 1].Text = (LD2.mFill_SignXY[num31 * 2 + 1] = dataGridView_pcb.Rows[LD2.record_mark[num31]].Cells[LD2.mSnIndex[4]].Value.ToString());
						MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[num31], DEF.COLOR_MARK[num31]);
					}
					if (!LD2.isPrecise && num31 == 1)
					{
						break;
					}
				}
			}
			else
			{
				MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Fail to Auto find Mark!" : "自动寻找mark点失败！", MessageBoxButtons.OK);
			}
		}

		private void ToolStripMenuItem_delete_Click(object sender, EventArgs e)
		{
			int count = dataGridView_pcb.SelectedRows.Count;
			if (count > 0 && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Delete the select item?" : "确定要删除选中行吗？", MessageBoxButtons.YesNo) != DialogResult.No)
			{
				int[] array = new int[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = dataGridView_pcb.SelectedRows[i].Index;
				}
				Array.Sort(array);
				remove_mark_all();
				for (int num = count - 1; num >= 0; num--)
				{
					LD2.pointlist.RemoveAt(array[num]);
				}
				selectrowindex = -1;
			}
		}

		private void remove_mark_all()
		{
			for (int i = 0; i < 4; i++)
			{
				if (LD2.record_mark[i] != -1)
				{
					MainForm0.datagridview_set_row_backcolor(dataGridView_pcb, LD2.record_mark[i], Color.White);
					dataGridView_pcb.Rows[LD2.record_mark[i]].HeaderCell.Value = "";
					textBox_mark[i * 2].Text = (LD2.mFill_SignXY[i * 2] = "");
					textBox_mark[i * 2 + 1].Text = (LD2.mFill_SignXY[i * 2 + 1] = "");
					LD2.record_mark[i] = -1;
				}
			}
		}

		private void button_GenerateList0_Click(object sender, EventArgs e)
		{
			if (MainForm0.mIsSecurityTest)
			{
				switch (MainForm0.__wind_checkget_software_state(0))
				{
				case 2:
				case 3:
				case 4:
					return;
				case 0:
					if (dataGridView_pcb.Rows.Count > 150)
					{
						MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Trail version: Max import chip num is:" : ("试用版本限制：导入元件数量不超过" + 150), MessageBoxButtons.OK);
						return;
					}
					break;
				}
			}
			try
			{
				for (int i = 0; i < 4; i++)
				{
					if (textBox_mark[i].Text == null || textBox_mark[i].Text == "")
					{
						MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Sign cannot be empty" : "定位点的坐标不能为空", MessageBoxButtons.OK);
						return;
					}
				}
				if (MainForm0.mIsSimulation)
				{
					if (LD2.mSignXY[0].X == 0 && LD2.mSignXY[0].Y == 0 && LD2.mSignXY[1].X == 0 && LD2.mSignXY[1].Y == 0)
					{
						MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Sign 1 Coordinate in device cannot be empty" : "定位点在机器上的坐标不能为空", MessageBoxButtons.OK);
						return;
					}
				}
				else if (LD2.mSignPic[0] == null || LD2.mSignPic[1] == null)
				{
					MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Sign 1 Coordinate in device cannot be empty" : "定位点在机器上的坐标不能为空", MessageBoxButtons.OK);
					return;
				}
				if ((int)float.Parse(textBox_mark[0].Text) == (int)float.Parse(textBox_mark[2].Text) && (int)float.Parse(textBox_mark[1].Text) == (int)float.Parse(textBox_mark[3].Text))
				{
					MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Sign 1 and Sign 2 cannot be the same" : "定位点1和定位点2的坐标不能为同一点", MessageBoxButtons.OK);
					return;
				}
				if (dataGridView_pcb.Rows.Count < 2)
				{
					MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Items number should be more than 1 !" : "导入数量太少，暂不支持", MessageBoxButtons.OK);
					return;
				}
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile("EXCEPTION: button_GenerateList0_Click 0");
				return;
			}
			if (check_legal("run"))
			{
				button_GenerateList0.Enabled = false;
				if (checkBox_PreciseImport.Checked)
				{
					generate_precise_import2_2();
				}
				else
				{
					generate_normal_import();
				}
				base.Visible = false;
				MainForm0.mIsOpen_PcbImportPage = false;
				button_GenerateList0.Enabled = true;
				if (this.SetEdit_XY != null)
				{
					this.SetEdit_XY(flag: true);
				}
			}
		}

		private void generate_normal_import()
		{
			BindingList<ChipBoardElement> bindingList = new BindingList<ChipBoardElement>();
			for (int i = 0; i < dataGridView_pcb.Rows.Count; i++)
			{
				ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage, Guid.NewGuid().ToString());
				try
				{
					chipBoardElement.X = (int)(check_return_floatvalue(dataGridView_pcb.Rows[i].Cells[LD2.mSnIndex[3]].Value.ToString()) * 10000f + 0.5f);
					chipBoardElement.Y = (int)(check_return_floatvalue(dataGridView_pcb.Rows[i].Cells[LD2.mSnIndex[4]].Value.ToString()) * 10000f + 0.5f);
					chipBoardElement.A = 360f - check_return_floatvalue(dataGridView_pcb.Rows[i].Cells[LD2.mSnIndex[5]].Value.ToString());
					bindingList.Add(chipBoardElement);
				}
				catch (Exception ex)
				{
					MainForm0.write_to_logFile("类型X: " + ex.Message + Environment.NewLine);
				}
			}
			try
			{
				for (int j = 0; j < 2; j++)
				{
					fill_signxy[j].X = (int)(float.Parse(textBox_mark[j * 2].Text) * 10000f + 0.5f);
					fill_signxy[j].Y = (int)(float.Parse(textBox_mark[j * 2 + 1].Text) * 10000f + 0.5f);
				}
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile_EXCEPTION(" generate_normal_import");
				return;
			}
			importList = bindingList;
			BindingList<ChipBoardElement> value = new BindingList<ChipBoardElement>();
			USR.mDeltaAlfa = (float)GetMarkToNewPosition(importList, ref value);
			Form_GenPcbListConfirm form_GenPcbListConfirm = new Form_GenPcbListConfirm(USR_INIT.mLanguage, USR.mDeltaAlfa);
			if (form_GenPcbListConfirm.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			bool flag = true;
			if (USR3.mPointlist != null && USR3.mPointlist.Count > 0)
			{
				Form_GenPcbListOptional form_GenPcbListOptional = new Form_GenPcbListOptional(USR_INIT.mLanguage);
				switch (form_GenPcbListOptional.ShowDialog())
				{
				case DialogResult.Retry:
					flag = true;
					break;
				case DialogResult.Yes:
					flag = false;
					break;
				default:
					return;
				}
			}
			int num = -1;
			int num2 = 0;
			if (!flag)
			{
				num = MainForm0.get_max_importno(USR3.mPointlist);
				num2 = MainForm0.get_max_group(USR3.mPointlist);
			}
			if (USR3.mPointlistSmt == null)
			{
				USR3.mPointlistSmt = new BindingList<ChipBoardElement>();
			}
			if (flag)
			{
				USR3.mPointlist.Clear();
				USR3.mPointlistSmt.Clear();
				USR3.mArrayPCBRow = 1;
				USR3.mArrayPCBColumn = 1;
			}
			for (int k = 0; k < value.Count; k++)
			{
				ChipBoardElement element = new ChipBoardElement(USR_INIT.mLanguage, Guid.NewGuid().ToString());
				element.X = value[k].X;
				element.Y = value[k].Y;
				element.A = value[k].A;
				element.Arrayno = 0;
				element.Arrayno_S = "1-1";
				element.Group = num2 + k + 1;
				element.ImportNo = num + 1;
				element.Cameratype = CameraType.N_A;
				element.Visualtype = VisualType.N_A;
				element.Feedertype = FeederType.N_A;
				element.Nozzletype = -1;
				if (fill_chipboardelement_value_from_stringinfo(ref element, k))
				{
					while (element.A > 180f)
					{
						element.A -= 360f;
					}
					while (element.A <= -180f)
					{
						element.A += 360f;
					}
					USR3.mPointlist.Add(element);
					USR3.mPointlistSmt.Add(element);
				}
			}
			if (this.null_pcbedit_editlist != null)
			{
				this.null_pcbedit_editlist();
			}
			if (this.init_pcbedit_editlist != null)
			{
				this.init_pcbedit_editlist(USR3.mPointlist);
			}
			sub_loadcomponent_update_usr2();
			if (this.PCBE_List_Show != null)
			{
				this.PCBE_List_Show(0, b: true);
			}
			MainForm0.pcblist_to_cat(mFn);
		}

		private void generate_precise_import2_2()
		{
			BindingList<ChipBoardElement>[] array = new BindingList<ChipBoardElement>[2];
			for (int i = 0; i < 2; i++)
			{
				array[i] = new BindingList<ChipBoardElement>();
			}
			try
			{
				if (dataGridView_pcb.Rows.Count <= 0)
				{
					return;
				}
				CoordinateDouble[] array2 = new CoordinateDouble[4];
				CoordinateDouble[] array3 = new CoordinateDouble[4];
				for (int j = 0; j < 4; j++)
				{
					array2[j] = default(CoordinateDouble);
				}
				for (int k = 0; k < 4; k++)
				{
					array3[k] = default(CoordinateDouble);
				}
				array2[0].x = float.Parse(textBox_mark[0].Text.ToString());
				array2[0].y = 0.0 - (double)float.Parse(textBox_mark[1].Text.ToString());
				array2[1].x = float.Parse(textBox_mark[2].Text.ToString());
				array2[1].y = 0.0 - (double)float.Parse(textBox_mark[3].Text.ToString());
				array2[2].x = float.Parse(textBox_mark[4].Text.ToString());
				array2[2].y = 0.0 - (double)float.Parse(textBox_mark[5].Text.ToString());
				array2[3].x = float.Parse(textBox_mark[6].Text.ToString());
				array2[3].y = 0.0 - (double)float.Parse(textBox_mark[7].Text.ToString());
				array3[0].x = LD2.mSignXY[0].X;
				array3[0].y = LD2.mSignXY[0].Y;
				array3[1].x = LD2.mSignXY[1].X;
				array3[1].y = LD2.mSignXY[1].Y;
				array3[2].x = LD2.mSignXY[2].X;
				array3[2].y = LD2.mSignXY[2].Y;
				array3[3].x = LD2.mSignXY[3].X;
				array3[3].y = LD2.mSignXY[3].Y;
				int count = dataGridView_pcb.Rows.Count;
				CoordinateDouble[] array4 = new CoordinateDouble[count];
				CoordinateDouble[] array5 = new CoordinateDouble[count];
				for (int l = 0; l < count; l++)
				{
					array4[l] = default(CoordinateDouble);
					array4[l].x = float.Parse(dataGridView_pcb.Rows[l].Cells[LD2.mSnIndex[3]].Value.ToString());
					array4[l].y = 0.0 - (double)float.Parse(dataGridView_pcb.Rows[l].Cells[LD2.mSnIndex[4]].Value.ToString());
					array4[l].a = 360.0 - (double)float.Parse(dataGridView_pcb.Rows[l].Cells[LD2.mSnIndex[5]].Value.ToString());
					array5[l] = default(CoordinateDouble);
				}
				mFakeMk23 = new CoordinateDouble[5];
				for (int m = 0; m < mFakeMk23.Count(); m++)
				{
					mFakeMk23[m] = default(CoordinateDouble);
				}
				mFakeMk23_r = new CoordinateDouble[5];
				for (int n = 0; n < mFakeMk23_r.Count(); n++)
				{
					mFakeMk23_r[n] = default(CoordinateDouble);
				}
				USR.mDeltaAlfa = MainForm0.moon_function_pcbload2(array2, array3, array4, ref array5[0], ref mFakeMk23[0], ref mFakeMk23_r[0], count, 1);
				Form_GenPcbListConfirm form_GenPcbListConfirm = new Form_GenPcbListConfirm(USR_INIT.mLanguage, USR.mDeltaAlfa);
				if (form_GenPcbListConfirm.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				for (int num = 0; num < dataGridView_pcb.Rows.Count; num++)
				{
					ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage, Guid.NewGuid().ToString());
					try
					{
						chipBoardElement.X = (int)(array5[num].x + 0.5);
						chipBoardElement.Y = (int)(array5[num].y + 0.5);
						chipBoardElement.A = (float)Math.Round(array5[num].a, 2);
						array[0].Add(chipBoardElement);
					}
					catch (Exception ex)
					{
						MainForm0.write_to_logFile("类型X: " + ex.Message + Environment.NewLine);
					}
				}
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile_EXCEPTION(" generate_precise_import2_2 0");
				MessageBox.Show((USR_INIT.mLanguage == 2) ? "Please complete setting!" : "请完成配置！");
				return;
			}
			bool flag = true;
			if (USR3.mPointlist != null && USR3.mPointlist.Count > 0)
			{
				Form_GenPcbListOptional form_GenPcbListOptional = new Form_GenPcbListOptional(USR_INIT.mLanguage);
				switch (form_GenPcbListOptional.ShowDialog())
				{
				case DialogResult.Retry:
					flag = true;
					break;
				case DialogResult.Yes:
					flag = false;
					break;
				default:
					return;
				}
			}
			int num2 = -1;
			int num3 = 0;
			if (!flag)
			{
				num2 = MainForm0.get_max_importno(USR3.mPointlist);
				num3 = MainForm0.get_max_group(USR3.mPointlist);
			}
			if (this.null_pcbedit_editlist != null)
			{
				this.null_pcbedit_editlist();
			}
			if (USR3.mPointlistSmt == null)
			{
				USR3.mPointlistSmt = new BindingList<ChipBoardElement>();
			}
			if (flag)
			{
				USR3.mPointlist.Clear();
				USR3.mPointlistSmt.Clear();
				USR3.mArrayPCBRow = 1;
				USR3.mArrayPCBColumn = 1;
			}
			for (int num4 = 0; num4 < array[0].Count; num4++)
			{
				ChipBoardElement element = new ChipBoardElement(USR_INIT.mLanguage, Guid.NewGuid().ToString());
				element.X = array[0][num4].X;
				element.Y = array[0][num4].Y;
				element.A = array[0][num4].A;
				element.Arrayno = 0;
				element.Arrayno_S = "1-1";
				element.Group = num3 + num4 + 1;
				element.ImportNo = num2 + 1;
				element.Cameratype = CameraType.N_A;
				element.Visualtype = VisualType.N_A;
				element.Feedertype = FeederType.N_A;
				element.Nozzletype = -1;
				if (fill_chipboardelement_value_from_stringinfo(ref element, num4))
				{
					while (element.A > 180f)
					{
						element.A -= 360f;
					}
					while (element.A <= -180f)
					{
						element.A += 360f;
					}
					USR3.mPointlist.Add(element);
					USR3.mPointlistSmt.Add(element);
				}
			}
			if (this.null_pcbedit_editlist != null)
			{
				this.null_pcbedit_editlist();
			}
			if (this.init_pcbedit_editlist != null)
			{
				this.init_pcbedit_editlist(USR3.mPointlist);
			}
			sub_loadcomponent_update_usr2();
			if (this.PCBE_List_Show != null)
			{
				this.PCBE_List_Show(0, b: true);
			}
			MainForm0.pcblist_to_cat(mFn);
		}

		private double GetMarkToNewPosition(BindingList<ChipBoardElement> original, ref BindingList<ChipBoardElement> value)
		{
			try
			{
				value = new BindingList<ChipBoardElement>();
				smtmark_offset.X = 0L;
				smtmark_offset.Y = 0L;
				SizeF sizeF = default(SizeF);
				SizeF sizeF2 = default(SizeF);
				sizeF.Width = Math.Abs(LD2.mSignXY[1].X - LD2.mSignXY[0].X);
				sizeF.Height = Math.Abs(LD2.mSignXY[1].Y - LD2.mSignXY[0].Y);
				sizeF2.Width = Math.Abs(fill_signxy[1].X - fill_signxy[0].X);
				sizeF2.Height = Math.Abs(fill_signxy[1].Y - fill_signxy[0].Y);
				double num = Math.Sqrt(sizeF.Width * sizeF.Width + sizeF.Height * sizeF.Height);
				double num2 = Math.Sqrt(sizeF2.Width * sizeF2.Width + sizeF2.Height * sizeF2.Height);
				double num3 = num / num2;
				double num4 = (MarkA = Math.Atan2(LD2.mSignXY[1].Y - LD2.mSignXY[0].Y, LD2.mSignXY[1].X - LD2.mSignXY[0].X) - Math.Atan2(-fill_signxy[1].Y + fill_signxy[0].Y, fill_signxy[1].X - fill_signxy[0].X));
				MarkSin = Math.Sin(num4);
				MarkCos = Math.Cos(num4);
				MarkAngle = num4 * 180.0 / Math.PI;
				PointF pointF = default(PointF);
				for (int i = 0; i < original.Count; i++)
				{
					ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage, Guid.NewGuid().ToString());
					chipBoardElement.Material_value = original[i].Material_value;
					chipBoardElement.Footprint = original[i].Footprint;
					chipBoardElement.Ismount = original[i].Ismount;
					chipBoardElement.Arrayno_S = original[i].Arrayno_S;
					chipBoardElement.Arrayno = original[i].Arrayno;
					chipBoardElement.Labeltab = original[i].Labeltab;
					chipBoardElement.Guid = original[i].Guid;
					pointF.X = (float)LD2.mSignXY[0].X + (float)((double)(-fill_signxy[0].X + original[i].X) * num3) + (float)smtmark_offset.X + 0.5f;
					pointF.Y = (float)LD2.mSignXY[0].Y - (float)((double)(-fill_signxy[0].Y + original[i].Y) * num3) + (float)smtmark_offset.Y + 0.5f;
					chipBoardElement.X = (int)((double)(pointF.X - (float)LD2.mSignXY[0].X) * Math.Cos(MarkA) - (double)(pointF.Y - (float)LD2.mSignXY[0].Y) * Math.Sin(MarkA) + (double)LD2.mSignXY[0].X + 0.5);
					chipBoardElement.Y = (int)((double)(pointF.X - (float)LD2.mSignXY[0].X) * Math.Sin(MarkA) + (double)(pointF.Y - (float)LD2.mSignXY[0].Y) * Math.Cos(MarkA) + (double)LD2.mSignXY[0].Y + 0.5);
					chipBoardElement.A = (float)Math.Round((double)original[i].A + MarkA * 180.0 / Math.PI, 2);
					value.Add(chipBoardElement);
				}
				return MarkA;
			}
			catch (Exception ex)
			{
				MainForm0.write_to_logFile("类型X: " + ex.Message + Environment.NewLine);
				return 0.0;
			}
		}

		private bool fill_chipboardelement_value_from_stringinfo(ref ChipBoardElement element, int row)
		{
			try
			{
				if (LD2.mSnIndex[0] != -1)
				{
					element.Labeltab = dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[0]].Value.ToString();
				}
				if (LD2.mSnIndex[1] != -1)
				{
					element.Material_value = dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[1]].Value.ToString();
				}
				if (LD2.mSnIndex[2] != -1)
				{
					element.Footprint = dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[2]].Value.ToString();
				}
				if (LD2.mSnIndex[7] != -1)
				{
					element.Feedertype = check_return_feedertype(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[7]].Value.ToString());
				}
				if (LD2.mSnIndex[8] != -1)
				{
					element.Stack_no = check_return_intno(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[8]].Value.ToString());
				}
				if (LD2.mSnIndex[9] != -1)
				{
					element.Nozzletype = check_return_nozzletype(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[9]].Value.ToString());
				}
				if (LD2.mSnIndex[10] != -1)
				{
					element.Nozzle = check_return_intno(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[10]].Value.ToString());
				}
				if (LD2.mSnIndex[11] != -1)
				{
					element.Cameratype = check_return_cameratype(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[11]].Value.ToString());
				}
				if (LD2.mSnIndex[12] != -1)
				{
					element.Visualtype = check_return_visualtype(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[12]].Value.ToString());
				}
				if (LD2.mSnIndex[13] != -1)
				{
					element.Looptype = check_return_looptype(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[13]].Value.ToString());
				}
				if (LD2.mSnIndex[14] != -1)
				{
					element.scanR = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[14]].Value.ToString());
				}
				if (LD2.mSnIndex[15] != -1)
				{
					element.threshold = check_return_intno(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[15]].Value.ToString());
				}
				if (LD2.mSnIndex[16] != -1)
				{
					element.length = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[16]].Value.ToString());
				}
				if (LD2.mSnIndex[17] != -1)
				{
					element.width = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[17]].Value.ToString());
				}
				if (LD2.mSnIndex[18] != -1)
				{
					element.height = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[18]].Value.ToString());
				}
				if (LD2.mSnIndex[19] != -1)
				{
					element.is_collect = check_return_iscollect(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[19]].Value.ToString());
				}
				if (LD2.mSnIndex[20] != -1)
				{
					element.collectdelta = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[20]].Value.ToString());
				}
				if (LD2.mSnIndex[21] != -1)
				{
					element.pik_h_offset = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[21]].Value.ToString());
				}
				if (LD2.mSnIndex[22] != -1)
				{
					element.zup_speed = check_return_intno(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[22]].Value.ToString());
				}
				if (LD2.mSnIndex[23] != -1)
				{
					element.zdown_speed = check_return_intno(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[23]].Value.ToString());
				}
				if (LD2.mSnIndex[24] != -1)
				{
					element.zpik_delay = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[24]].Value.ToString());
				}
				if (LD2.mSnIndex[25] != -1)
				{
					element.mnt_h_offset = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[25]].Value.ToString());
				}
				if (LD2.mSnIndex[26] != -1)
				{
					element.zup_speed = check_return_intno(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[26]].Value.ToString());
				}
				if (LD2.mSnIndex[27] != -1)
				{
					element.zdown_speed = check_return_intno(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[27]].Value.ToString());
				}
				if (LD2.mSnIndex[28] != -1)
				{
					element.zmnt_delay = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[28]].Value.ToString());
				}
				if (LD2.mSnIndex[29] != -1)
				{
					element.sampik_delta = check_return_floatvalue(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[29]].Value.ToString());
				}
				if (LD2.mSnIndex[30] != -1)
				{
					element.Ismount = check_return_ismount(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[30]].Value.ToString());
				}
				if (LD2.mSnIndex[31] != -1)
				{
					element.IsLowSpeed = check_return_islowspeed(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[31]].Value.ToString());
				}
				if (LD2.mSnIndex[32] != -1)
				{
					element.is_high = check_return_ishigh(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[32]].Value.ToString());
				}
				if (LD2.mSnIndex[7] != -1)
				{
					element.Stacktype = check_return_providertype(dataGridView_pcb.Rows[row].Cells[LD2.mSnIndex[7]].Value.ToString());
				}
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile_EXCEPTION(" fill_chipboardelement_value_from_stringinfo");
				return false;
			}
			return true;
		}

		private void sub_loadcomponent_update_usr2()
		{
			if (USR2 == null || USR3 == null || USR3.mPointlist == null || LD2.mSnIndex[7] == -1 || LD2.mSnIndex[8] == -1)
			{
				return;
			}
			for (int i = 0; i < USR3.mPointlist.Count; i++)
			{
				StackElement[] array;
				if (USR3.mPointlist[i].Stacktype == ProviderType.Feedr)
				{
					array = USR2.mStackLib.stacktab[0];
				}
				else if (USR3.mPointlist[i].Stacktype == ProviderType.Vibra)
				{
					array = USR2.mStackLib.stacktab[2];
				}
				else
				{
					if (USR3.mPointlist[i].Stacktype != ProviderType.Plate)
					{
						continue;
					}
					array = USR2.mStackLib.stacktab[1];
				}
				int num = HW.mStackNum[MainForm0.mFn][(int)USR3.mPointlist[i].Stacktype];
				int num2 = USR3.mPointlist[i].Stack_no - 1;
				if (num2 < 0 || num2 >= num)
				{
					continue;
				}
				for (int j = 0; j < HW.mZnNum[MainForm0.mFn]; j++)
				{
					if (USR3.mPointlist[i].zpik_delay > 0f)
					{
						array[num2].mZnData[j].Pik.Delay = (int)USR3.mPointlist[i].zpik_delay;
					}
					if (USR3.mPointlist[i].zmnt_delay > 0f)
					{
						array[num2].mZnData[j].Mnt.Delay = (int)USR3.mPointlist[i].zmnt_delay;
					}
					if (USR3.mPointlist[i].zup_speed > 0)
					{
						array[num2].mZnData[j].Pik.UpSpeed = USR3.mPointlist[i].zup_speed;
					}
					if (USR3.mPointlist[i].zdown_speed > 0)
					{
						array[num2].mZnData[j].Pik.DownSpeed = USR3.mPointlist[i].zdown_speed;
					}
					if (USR3.mPointlist[i].zmnt_up_speed > 0)
					{
						array[num2].mZnData[j].Mnt.UpSpeed = USR3.mPointlist[i].zmnt_up_speed;
					}
					if (USR3.mPointlist[i].zmnt_down_speed > 0)
					{
						array[num2].mZnData[j].Mnt.DownSpeed = USR3.mPointlist[i].zmnt_down_speed;
					}
					if (USR3.mPointlist[i].threshold > 0)
					{
						array[num2].mZnData[j].threshold = Math.Abs(USR3.mPointlist[i].threshold) % 256;
					}
				}
				if (USR3.mPointlist[i].length > 0f)
				{
					array[num2].lenght = USR3.mPointlist[i].length;
				}
				if (USR3.mPointlist[i].width > 0f)
				{
					array[num2].width = USR3.mPointlist[i].width;
				}
				if (USR3.mPointlist[i].length > 0f)
				{
					array[num2].mCollectL = array[num2].lenght * 100f / ((USR3.mPointlist[i].Cameratype != CameraType.High) ? USR.mFastCamRatio[0][0] : USR.mHighCamRatio[0]);
				}
				if (USR3.mPointlist[i].width > 0f)
				{
					array[num2].mCollectW = array[num2].width * 100f / ((USR3.mPointlist[i].Cameratype != CameraType.High) ? USR.mFastCamRatio[0][0] : USR.mHighCamRatio[0]);
				}
				if (USR3.mPointlist[i].height > 0f)
				{
					array[num2].height = USR3.mPointlist[i].height;
				}
				if (USR3.mPointlist[i].scanR > 0f)
				{
					array[num2].scanR = Math.Abs((int)USR3.mPointlist[i].scanR % 921);
				}
				array[num2].mIsCollect = USR3.mPointlist[i].is_collect;
				array[num2].mCollectDelta = USR3.mPointlist[i].collectdelta;
				array[num2].pik_HmmOffset = USR3.mPointlist[i].pik_h_offset;
				array[num2].mnt_HmmOffset = USR3.mPointlist[i].mnt_h_offset;
			}
		}

		private void dataGridView_pcb_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
		}

		private void cnSearchBox1_SearchEvent(object sender, EventArgs e)
		{
			string text = cnSearchBox1.Text;
			if (LD2.pointlist == null || LD2.pointlist.Count <= 0)
			{
				return;
			}
			int num = mLeadingCurIndex;
			if (num == -1)
			{
				num = 0;
			}
			for (int i = num + 1; i < LD2.pointlist.Count + num + 1; i++)
			{
				int firstDisplayedScrollingRowIndex = i % LD2.pointlist.Count;
				int num2 = 0;
				for (num2 = 0; num2 < 11; num2++)
				{
					if (text == dataGridView_pcb.Rows[firstDisplayedScrollingRowIndex].Cells[num2].Value.ToString())
					{
						dataGridView_pcb.Rows[num].Selected = false;
						dataGridView_pcb.Rows[firstDisplayedScrollingRowIndex].Selected = true;
						dataGridView_pcb.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
						mLeadingCurIndex = firstDisplayedScrollingRowIndex;
						label_loadcomponent_page.Text = mLeadingCurIndex + 1 + "/" + LD2.pointlist.Count;
						break;
					}
				}
				if (num2 < 11)
				{
					break;
				}
			}
		}

		private void cnButton_cat_Click(object sender, EventArgs e)
		{
			Form_importcat form_importcat = new Form_importcat();
			form_importcat.ShowDialog();
			if (HW.mFnNum >= 2)
			{
				for (int i = 0; i < HW.mFnNum; i++)
				{
					MainForm0.uc_job[i].uc_dgv_list[MainForm0.U3Idx[i]].uc_pcbedit_import.flush_sn();
				}
			}
		}

		public void flush_sn()
		{
			for (int i = 0; i < dataGridView_pcb.Columns.Count; i++)
			{
				dataGridView_pcb.Columns[i].HeaderText = "n";
			}
			for (int j = 0; j < 33; j++)
			{
				if (LD2.mSnIndex[j] != -1)
				{
					dataGridView_pcb.Columns[LD2.mSnIndex[j]].HeaderText = STR.LOAD_HEAD_STR[j][MainForm0.USR_INIT.mLanguage];
				}
			}
			refresh_SnHead();
			for (int k = 0; k < 40; k++)
			{
				dataGridView_pcb.Columns[k].Visible = true;
			}
			for (int l = 0; l < LD2.mHidenColumnList.Count; l++)
			{
				if (LD2.mHidenColumnList[l] >= 0 && LD2.mHidenColumnList[l] < 40)
				{
					dataGridView_pcb.Columns[LD2.mHidenColumnList[l]].Visible = false;
				}
			}
		}

		private void cnButton_importmirror_Click(object sender, EventArgs e)
		{
			if (!check_legal("run") || LD2 == null || LD2.pointlist == null || LD2.pointlist.Count < 4)
			{
				return;
			}
			int num = LD2.mSnIndex[3];
			for (int i = 0; i < LD2.pointlist.Count; i++)
			{
				string text = LD2.pointlist[i].sn[num];
				if (text.Length >= 1)
				{
					char c = text.First();
					text = ((c != '-') ? ("-" + text) : text.Replace("-", ""));
					LD2.pointlist[i].sn[num] = text;
				}
			}
			dataGridView_pcb.Refresh();
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
			label2 = new System.Windows.Forms.Label();
			label_loadcomponent_page = new System.Windows.Forms.Label();
			dataGridView_pcb = new System.Windows.Forms.DataGridView();
			panel21 = new System.Windows.Forms.Panel();
			checkBox_oppoPcb_debug = new System.Windows.Forms.CheckBox();
			panel104 = new System.Windows.Forms.Panel();
			label179 = new System.Windows.Forms.Label();
			checkBox_PreciseImport = new System.Windows.Forms.CheckBox();
			panel102 = new System.Windows.Forms.Panel();
			textBox_ref0_x = new System.Windows.Forms.TextBox();
			textBox_ref1_y = new System.Windows.Forms.TextBox();
			label_ref0 = new System.Windows.Forms.Label();
			textBox_ref1_x = new System.Windows.Forms.TextBox();
			label175 = new System.Windows.Forms.Label();
			label171 = new System.Windows.Forms.Label();
			textBox_ref0_y = new System.Windows.Forms.TextBox();
			label_ref1 = new System.Windows.Forms.Label();
			label60 = new System.Windows.Forms.Label();
			label174 = new System.Windows.Forms.Label();
			label173 = new System.Windows.Forms.Label();
			textBox_mark2y_location = new System.Windows.Forms.TextBox();
			textBox_mark2x_location = new System.Windows.Forms.TextBox();
			panel_loadsetsign = new System.Windows.Forms.Panel();
			pictureBox5 = new System.Windows.Forms.PictureBox();
			panel2 = new System.Windows.Forms.Panel();
			panel106 = new System.Windows.Forms.Panel();
			label176 = new System.Windows.Forms.Label();
			panel105 = new System.Windows.Forms.Panel();
			label177 = new System.Windows.Forms.Label();
			label72 = new System.Windows.Forms.Label();
			label_signp2 = new System.Windows.Forms.Label();
			label_signp1 = new System.Windows.Forms.Label();
			panel103 = new System.Windows.Forms.Panel();
			label178 = new System.Windows.Forms.Label();
			pictureBox_Sign2 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			pictureBox_Sign1 = new System.Windows.Forms.PictureBox();
			label_Sign2 = new System.Windows.Forms.Label();
			label_Sign1 = new System.Windows.Forms.Label();
			textBox_mark1y_location = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label_signpcb = new System.Windows.Forms.Label();
			label65 = new System.Windows.Forms.Label();
			label_signdevice = new System.Windows.Forms.Label();
			textBox_mark1x_location = new System.Windows.Forms.TextBox();
			label_signtitle0 = new System.Windows.Forms.Label();
			label_signtitile1 = new System.Windows.Forms.Label();
			label68 = new System.Windows.Forms.Label();
			label67 = new System.Windows.Forms.Label();
			contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
			ToolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_SetMark1 = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_SetMark2 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_SetRef0 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_SetRef1 = new System.Windows.Forms.ToolStripMenuItem();
			contextMenuStrip_Sn = new System.Windows.Forms.ContextMenuStrip(components);
			ToolStripMenuItem_Name = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_Value = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_FootPrint = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_X = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_Y = new System.Windows.Forms.ToolStripMenuItem();
			ToolStripMenuItem_Angle = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_Layer = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripMenuItem_Hide = new System.Windows.Forms.ToolStripMenuItem();
			cnButton_importmirror = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_cat = new QIGN_COMMON.vs_acontrol.CnButton();
			cnSearchBox1 = new QIGN_COMMON.vs_acontrol.CnSearchBox();
			button_PCBE_Import_Close = new QIGN_COMMON.vs_acontrol.CnButton();
			button23 = new QIGN_COMMON.vs_acontrol.CnButton();
			button21 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_runSign = new QIGN_COMMON.vs_acontrol.CnButton();
			button_GenerateList0 = new QIGN_COMMON.vs_acontrol.CnButton();
			button3 = new QIGN_COMMON.vs_acontrol.CnButton();
			button13 = new QIGN_COMMON.vs_acontrol.CnButton();
			button27 = new QIGN_COMMON.vs_acontrol.CnButton();
			button32 = new QIGN_COMMON.vs_acontrol.CnButton();
			button15 = new QIGN_COMMON.vs_acontrol.CnButton();
			button14 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MoveToSign1 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MoveToSign2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveSign1 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveSign2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_importAngle = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pcbview = new QIGN_COMMON.vs_acontrol.CnButton();
			button_importLegal = new QIGN_COMMON.vs_acontrol.CnButton();
			button_addBom = new QIGN_COMMON.vs_acontrol.CnButton();
			button_LoadComponentFile = new QIGN_COMMON.vs_acontrol.CnButton();
			((System.ComponentModel.ISupportInitialize)dataGridView_pcb).BeginInit();
			panel21.SuspendLayout();
			panel104.SuspendLayout();
			panel102.SuspendLayout();
			panel_loadsetsign.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			panel2.SuspendLayout();
			panel106.SuspendLayout();
			panel105.SuspendLayout();
			panel103.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_Sign2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_Sign1).BeginInit();
			contextMenuStrip2.SuspendLayout();
			contextMenuStrip_Sn.SuspendLayout();
			SuspendLayout();
			label2.Location = new System.Drawing.Point(-3, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(740, 5);
			label2.TabIndex = 24;
			label_loadcomponent_page.Font = new System.Drawing.Font("黑体", 10.5f);
			label_loadcomponent_page.Location = new System.Drawing.Point(300, 16);
			label_loadcomponent_page.Name = "label_loadcomponent_page";
			label_loadcomponent_page.Size = new System.Drawing.Size(68, 17);
			label_loadcomponent_page.TabIndex = 33;
			label_loadcomponent_page.Text = "0/0";
			label_loadcomponent_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			dataGridView_pcb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_pcb.Location = new System.Drawing.Point(5, 42);
			dataGridView_pcb.Name = "dataGridView_pcb";
			dataGridView_pcb.RowTemplate.Height = 23;
			dataGridView_pcb.Size = new System.Drawing.Size(683, 522);
			dataGridView_pcb.TabIndex = 31;
			dataGridView_pcb.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcb_CellMouseUp);
			dataGridView_pcb.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcb_ColumnHeaderMouseClick);
			panel21.Controls.Add(checkBox_oppoPcb_debug);
			panel21.Controls.Add(panel104);
			panel21.Controls.Add(checkBox_PreciseImport);
			panel21.Controls.Add(panel102);
			panel21.Controls.Add(textBox_mark2y_location);
			panel21.Controls.Add(button_runSign);
			panel21.Controls.Add(textBox_mark2x_location);
			panel21.Controls.Add(panel_loadsetsign);
			panel21.Controls.Add(textBox_mark1y_location);
			panel21.Controls.Add(label3);
			panel21.Controls.Add(label10);
			panel21.Controls.Add(label_signpcb);
			panel21.Controls.Add(label65);
			panel21.Controls.Add(label_signdevice);
			panel21.Controls.Add(textBox_mark1x_location);
			panel21.Controls.Add(label_signtitle0);
			panel21.Controls.Add(label_signtitile1);
			panel21.Controls.Add(label68);
			panel21.Controls.Add(label67);
			panel21.Location = new System.Drawing.Point(3, 539);
			panel21.Name = "panel21";
			panel21.Size = new System.Drawing.Size(699, 278);
			panel21.TabIndex = 41;
			checkBox_oppoPcb_debug.AutoSize = true;
			checkBox_oppoPcb_debug.Font = new System.Drawing.Font("黑体", 11.25f);
			checkBox_oppoPcb_debug.Location = new System.Drawing.Point(574, 34);
			checkBox_oppoPcb_debug.Name = "checkBox_oppoPcb_debug";
			checkBox_oppoPcb_debug.Size = new System.Drawing.Size(114, 19);
			checkBox_oppoPcb_debug.TabIndex = 12;
			checkBox_oppoPcb_debug.Text = "旋转180放置";
			checkBox_oppoPcb_debug.UseVisualStyleBackColor = true;
			checkBox_oppoPcb_debug.Visible = false;
			panel104.Controls.Add(button23);
			panel104.Controls.Add(button21);
			panel104.Controls.Add(label179);
			panel104.Location = new System.Drawing.Point(506, 59);
			panel104.Name = "panel104";
			panel104.Size = new System.Drawing.Size(106, 53);
			panel104.TabIndex = 12;
			panel104.Visible = false;
			label179.BackColor = System.Drawing.Color.LightGray;
			label179.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label179.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label179.Location = new System.Drawing.Point(52, 9);
			label179.Name = "label179";
			label179.Size = new System.Drawing.Size(53, 37);
			label179.TabIndex = 6;
			label179.Text = "X00000\r\nY00000";
			label179.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			checkBox_PreciseImport.AutoSize = true;
			checkBox_PreciseImport.Font = new System.Drawing.Font("黑体", 11.25f);
			checkBox_PreciseImport.Location = new System.Drawing.Point(139, 66);
			checkBox_PreciseImport.Name = "checkBox_PreciseImport";
			checkBox_PreciseImport.Size = new System.Drawing.Size(90, 19);
			checkBox_PreciseImport.TabIndex = 8;
			checkBox_PreciseImport.Text = "精准生成";
			checkBox_PreciseImport.UseVisualStyleBackColor = true;
			checkBox_PreciseImport.CheckedChanged += new System.EventHandler(checkBox_PreciseImport_CheckedChanged);
			panel102.Controls.Add(textBox_ref0_x);
			panel102.Controls.Add(textBox_ref1_y);
			panel102.Controls.Add(label_ref0);
			panel102.Controls.Add(textBox_ref1_x);
			panel102.Controls.Add(label175);
			panel102.Controls.Add(label171);
			panel102.Controls.Add(textBox_ref0_y);
			panel102.Controls.Add(label_ref1);
			panel102.Controls.Add(label60);
			panel102.Controls.Add(label174);
			panel102.Controls.Add(label173);
			panel102.Location = new System.Drawing.Point(5, 152);
			panel102.Name = "panel102";
			panel102.Size = new System.Drawing.Size(297, 60);
			panel102.TabIndex = 8;
			panel102.Visible = false;
			textBox_ref0_x.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_ref0_x.Location = new System.Drawing.Point(94, 3);
			textBox_ref0_x.Name = "textBox_ref0_x";
			textBox_ref0_x.Size = new System.Drawing.Size(61, 23);
			textBox_ref0_x.TabIndex = 3;
			textBox_ref1_y.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_ref1_y.Location = new System.Drawing.Point(171, 33);
			textBox_ref1_y.Name = "textBox_ref1_y";
			textBox_ref1_y.Size = new System.Drawing.Size(61, 23);
			textBox_ref1_y.TabIndex = 6;
			label_ref0.BackColor = System.Drawing.Color.LightGray;
			label_ref0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_ref0.Font = new System.Drawing.Font("黑体", 10.5f);
			label_ref0.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label_ref0.Location = new System.Drawing.Point(1, 0);
			label_ref0.Name = "label_ref0";
			label_ref0.Size = new System.Drawing.Size(70, 26);
			label_ref0.TabIndex = 0;
			label_ref0.Text = "标记点3";
			label_ref0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			textBox_ref1_x.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_ref1_x.Location = new System.Drawing.Point(94, 33);
			textBox_ref1_x.Name = "textBox_ref1_x";
			textBox_ref1_x.Size = new System.Drawing.Size(61, 23);
			textBox_ref1_x.TabIndex = 7;
			label175.AutoSize = true;
			label175.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label175.Location = new System.Drawing.Point(155, 34);
			label175.Name = "label175";
			label175.Size = new System.Drawing.Size(15, 15);
			label175.TabIndex = 4;
			label175.Text = "Y";
			label171.AutoSize = true;
			label171.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label171.Location = new System.Drawing.Point(78, 4);
			label171.Name = "label171";
			label171.Size = new System.Drawing.Size(15, 15);
			label171.TabIndex = 0;
			label171.Text = "X";
			textBox_ref0_y.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_ref0_y.Location = new System.Drawing.Point(171, 3);
			textBox_ref0_y.Name = "textBox_ref0_y";
			textBox_ref0_y.Size = new System.Drawing.Size(61, 23);
			textBox_ref0_y.TabIndex = 3;
			label_ref1.BackColor = System.Drawing.Color.Gray;
			label_ref1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_ref1.Font = new System.Drawing.Font("黑体", 10.5f);
			label_ref1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label_ref1.Location = new System.Drawing.Point(1, 31);
			label_ref1.Name = "label_ref1";
			label_ref1.Size = new System.Drawing.Size(70, 26);
			label_ref1.TabIndex = 0;
			label_ref1.Text = "标记点4";
			label_ref1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label60.Font = new System.Drawing.Font("微软雅黑", 30f);
			label60.Location = new System.Drawing.Point(243, 3);
			label60.Name = "label60";
			label60.Size = new System.Drawing.Size(44, 52);
			label60.TabIndex = 21;
			label60.Text = "➨";
			label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label174.AutoSize = true;
			label174.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label174.Location = new System.Drawing.Point(155, 5);
			label174.Name = "label174";
			label174.Size = new System.Drawing.Size(15, 15);
			label174.TabIndex = 0;
			label174.Text = "Y";
			label173.AutoSize = true;
			label173.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label173.Location = new System.Drawing.Point(78, 35);
			label173.Name = "label173";
			label173.Size = new System.Drawing.Size(15, 15);
			label173.TabIndex = 5;
			label173.Text = "X";
			textBox_mark2y_location.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_mark2y_location.Location = new System.Drawing.Point(176, 123);
			textBox_mark2y_location.Name = "textBox_mark2y_location";
			textBox_mark2y_location.Size = new System.Drawing.Size(61, 23);
			textBox_mark2y_location.TabIndex = 6;
			textBox_mark2x_location.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_mark2x_location.Location = new System.Drawing.Point(99, 123);
			textBox_mark2x_location.Name = "textBox_mark2x_location";
			textBox_mark2x_location.Size = new System.Drawing.Size(61, 23);
			textBox_mark2x_location.TabIndex = 7;
			panel_loadsetsign.Controls.Add(button_GenerateList0);
			panel_loadsetsign.Controls.Add(pictureBox5);
			panel_loadsetsign.Controls.Add(panel2);
			panel_loadsetsign.Controls.Add(panel103);
			panel_loadsetsign.Controls.Add(pictureBox_Sign2);
			panel_loadsetsign.Controls.Add(pictureBox3);
			panel_loadsetsign.Controls.Add(pictureBox_Sign1);
			panel_loadsetsign.Controls.Add(label_Sign2);
			panel_loadsetsign.Controls.Add(button_MoveToSign1);
			panel_loadsetsign.Controls.Add(button_MoveToSign2);
			panel_loadsetsign.Controls.Add(label_Sign1);
			panel_loadsetsign.Controls.Add(button_SaveSign1);
			panel_loadsetsign.Controls.Add(button_SaveSign2);
			panel_loadsetsign.Location = new System.Drawing.Point(308, 59);
			panel_loadsetsign.Name = "panel_loadsetsign";
			panel_loadsetsign.Size = new System.Drawing.Size(397, 216);
			panel_loadsetsign.TabIndex = 20;
			pictureBox5.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox5.Location = new System.Drawing.Point(305, 2);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new System.Drawing.Size(72, 72);
			pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox5.TabIndex = 9;
			pictureBox5.TabStop = false;
			panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(panel106);
			panel2.Controls.Add(panel105);
			panel2.Controls.Add(button27);
			panel2.Controls.Add(button32);
			panel2.Controls.Add(label72);
			panel2.Controls.Add(label_signp2);
			panel2.Controls.Add(label_signp1);
			panel2.Location = new System.Drawing.Point(74, 54);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(230, 58);
			panel2.TabIndex = 5;
			panel106.Controls.Add(label176);
			panel106.Controls.Add(button3);
			panel106.Location = new System.Drawing.Point(155, -1);
			panel106.Name = "panel106";
			panel106.Size = new System.Drawing.Size(71, 22);
			panel106.TabIndex = 37;
			panel106.Visible = false;
			label176.AutoSize = true;
			label176.Font = new System.Drawing.Font("黑体", 10f);
			label176.Location = new System.Drawing.Point(-3, 4);
			label176.Name = "label176";
			label176.Size = new System.Drawing.Size(56, 14);
			label176.TabIndex = 0;
			label176.Text = "标记点3";
			panel105.Controls.Add(button13);
			panel105.Controls.Add(label177);
			panel105.Location = new System.Drawing.Point(2, 35);
			panel105.Name = "panel105";
			panel105.Size = new System.Drawing.Size(69, 23);
			panel105.TabIndex = 36;
			panel105.Visible = false;
			label177.AutoSize = true;
			label177.Font = new System.Drawing.Font("黑体", 10f);
			label177.Location = new System.Drawing.Point(18, 5);
			label177.Name = "label177";
			label177.Size = new System.Drawing.Size(56, 14);
			label177.TabIndex = 0;
			label177.Text = "标记点4";
			label72.AutoSize = true;
			label72.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label72.Location = new System.Drawing.Point(90, 16);
			label72.Name = "label72";
			label72.Size = new System.Drawing.Size(50, 26);
			label72.TabIndex = 33;
			label72.Text = "PCB";
			label_signp2.AutoSize = true;
			label_signp2.Font = new System.Drawing.Font("黑体", 10f);
			label_signp2.Location = new System.Drawing.Point(152, 39);
			label_signp2.Name = "label_signp2";
			label_signp2.Size = new System.Drawing.Size(56, 14);
			label_signp2.TabIndex = 2;
			label_signp2.Text = "标记点2";
			label_signp1.AutoSize = true;
			label_signp1.Font = new System.Drawing.Font("黑体", 10f);
			label_signp1.Location = new System.Drawing.Point(20, 2);
			label_signp1.Name = "label_signp1";
			label_signp1.Size = new System.Drawing.Size(56, 14);
			label_signp1.TabIndex = 0;
			label_signp1.Text = "标记点1";
			panel103.Controls.Add(button15);
			panel103.Controls.Add(button14);
			panel103.Controls.Add(label178);
			panel103.Location = new System.Drawing.Point(76, 110);
			panel103.Name = "panel103";
			panel103.Size = new System.Drawing.Size(110, 55);
			panel103.TabIndex = 11;
			panel103.Visible = false;
			label178.BackColor = System.Drawing.Color.Gray;
			label178.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label178.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label178.ForeColor = System.Drawing.Color.Black;
			label178.Location = new System.Drawing.Point(0, 7);
			label178.Name = "label178";
			label178.Size = new System.Drawing.Size(53, 37);
			label178.TabIndex = 6;
			label178.Text = "X00000\r\nY00000";
			label178.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			pictureBox_Sign2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			pictureBox_Sign2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_Sign2.Location = new System.Drawing.Point(305, 87);
			pictureBox_Sign2.Name = "pictureBox_Sign2";
			pictureBox_Sign2.Size = new System.Drawing.Size(72, 72);
			pictureBox_Sign2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_Sign2.TabIndex = 9;
			pictureBox_Sign2.TabStop = false;
			pictureBox3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox3.Location = new System.Drawing.Point(1, 88);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(72, 72);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 9;
			pictureBox3.TabStop = false;
			pictureBox_Sign1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			pictureBox_Sign1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_Sign1.Location = new System.Drawing.Point(1, 1);
			pictureBox_Sign1.Name = "pictureBox_Sign1";
			pictureBox_Sign1.Size = new System.Drawing.Size(72, 72);
			pictureBox_Sign1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_Sign1.TabIndex = 9;
			pictureBox_Sign1.TabStop = false;
			label_Sign2.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
			label_Sign2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_Sign2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_Sign2.Location = new System.Drawing.Point(250, 116);
			label_Sign2.Name = "label_Sign2";
			label_Sign2.Size = new System.Drawing.Size(54, 38);
			label_Sign2.TabIndex = 6;
			label_Sign2.Text = "X00000\r\nY00000";
			label_Sign2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_Sign1.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			label_Sign1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_Sign1.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_Sign1.Location = new System.Drawing.Point(74, 9);
			label_Sign1.Name = "label_Sign1";
			label_Sign1.Size = new System.Drawing.Size(53, 37);
			label_Sign1.TabIndex = 6;
			label_Sign1.Text = "X00000\r\nY00000";
			label_Sign1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			textBox_mark1y_location.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_mark1y_location.Location = new System.Drawing.Point(176, 93);
			textBox_mark1y_location.Name = "textBox_mark1y_location";
			textBox_mark1y_location.Size = new System.Drawing.Size(61, 23);
			textBox_mark1y_location.TabIndex = 3;
			label3.Font = new System.Drawing.Font("微软雅黑", 30f);
			label3.Location = new System.Drawing.Point(248, 93);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 52);
			label3.TabIndex = 21;
			label3.Text = "➨";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label10.Location = new System.Drawing.Point(160, 123);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(15, 15);
			label10.TabIndex = 4;
			label10.Text = "Y";
			label_signpcb.Font = new System.Drawing.Font("黑体", 11.25f);
			label_signpcb.Location = new System.Drawing.Point(18, 33);
			label_signpcb.Name = "label_signpcb";
			label_signpcb.Size = new System.Drawing.Size(222, 23);
			label_signpcb.TabIndex = 19;
			label_signpcb.Text = "标记点-在PCB上XY(毫米)";
			label_signpcb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label65.AutoSize = true;
			label65.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label65.Location = new System.Drawing.Point(83, 125);
			label65.Name = "label65";
			label65.Size = new System.Drawing.Size(15, 15);
			label65.TabIndex = 5;
			label65.Text = "X";
			label_signdevice.Font = new System.Drawing.Font("黑体", 11.25f);
			label_signdevice.Location = new System.Drawing.Point(274, 32);
			label_signdevice.Name = "label_signdevice";
			label_signdevice.Size = new System.Drawing.Size(414, 23);
			label_signdevice.TabIndex = 19;
			label_signdevice.Text = "标记点-在机器上XY(步)";
			label_signdevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			textBox_mark1x_location.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_mark1x_location.Location = new System.Drawing.Point(99, 93);
			textBox_mark1x_location.Name = "textBox_mark1x_location";
			textBox_mark1x_location.Size = new System.Drawing.Size(61, 23);
			textBox_mark1x_location.TabIndex = 3;
			label_signtitle0.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			label_signtitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_signtitle0.Font = new System.Drawing.Font("黑体", 10.5f);
			label_signtitle0.Location = new System.Drawing.Point(6, 90);
			label_signtitle0.Name = "label_signtitle0";
			label_signtitle0.Size = new System.Drawing.Size(70, 26);
			label_signtitle0.TabIndex = 0;
			label_signtitle0.Text = "标记点1";
			label_signtitle0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_signtitile1.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
			label_signtitile1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_signtitile1.Font = new System.Drawing.Font("黑体", 10.5f);
			label_signtitile1.Location = new System.Drawing.Point(6, 121);
			label_signtitile1.Name = "label_signtitile1";
			label_signtitile1.Size = new System.Drawing.Size(70, 26);
			label_signtitile1.TabIndex = 0;
			label_signtitile1.Text = "标记点2";
			label_signtitile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label68.Location = new System.Drawing.Point(83, 94);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(15, 15);
			label68.TabIndex = 0;
			label68.Text = "X";
			label67.AutoSize = true;
			label67.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label67.Location = new System.Drawing.Point(160, 94);
			label67.Name = "label67";
			label67.Size = new System.Drawing.Size(15, 15);
			label67.TabIndex = 0;
			label67.Text = "Y";
			contextMenuStrip2.Font = new System.Drawing.Font("楷体", 10.5f);
			contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { ToolStripMenuItem_delete, toolStripSeparator6, ToolStripMenuItem_SetMark1, ToolStripMenuItem_SetMark2, toolStripSeparator7, toolStripMenuItem_SetRef0, toolStripMenuItem_SetRef1 });
			contextMenuStrip2.Name = "contextMenuStrip2";
			contextMenuStrip2.Size = new System.Drawing.Size(180, 126);
			ToolStripMenuItem_delete.Name = "ToolStripMenuItem_delete";
			ToolStripMenuItem_delete.Size = new System.Drawing.Size(179, 22);
			ToolStripMenuItem_delete.Text = "删除";
			ToolStripMenuItem_delete.Click += new System.EventHandler(ToolStripMenuItem_delete_Click);
			toolStripSeparator6.Name = "toolStripSeparator6";
			toolStripSeparator6.Size = new System.Drawing.Size(176, 6);
			ToolStripMenuItem_SetMark1.Name = "ToolStripMenuItem_SetMark1";
			ToolStripMenuItem_SetMark1.Size = new System.Drawing.Size(179, 22);
			ToolStripMenuItem_SetMark1.Text = "设为标记点1(S1)";
			ToolStripMenuItem_SetMark2.Name = "ToolStripMenuItem_SetMark2";
			ToolStripMenuItem_SetMark2.Size = new System.Drawing.Size(179, 22);
			ToolStripMenuItem_SetMark2.Text = "设为标记点2(S2)";
			toolStripSeparator7.Name = "toolStripSeparator7";
			toolStripSeparator7.Size = new System.Drawing.Size(176, 6);
			toolStripSeparator7.Visible = false;
			toolStripMenuItem_SetRef0.Name = "toolStripMenuItem_SetRef0";
			toolStripMenuItem_SetRef0.Size = new System.Drawing.Size(179, 22);
			toolStripMenuItem_SetRef0.Text = "设为标记点3(S3)";
			toolStripMenuItem_SetRef0.Visible = false;
			toolStripMenuItem_SetRef1.Name = "toolStripMenuItem_SetRef1";
			toolStripMenuItem_SetRef1.Size = new System.Drawing.Size(179, 22);
			toolStripMenuItem_SetRef1.Text = "设为标记点4(S4)";
			toolStripMenuItem_SetRef1.Visible = false;
			contextMenuStrip_Sn.Font = new System.Drawing.Font("楷体", 10.5f);
			contextMenuStrip_Sn.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				ToolStripMenuItem_Name, ToolStripMenuItem_Value, ToolStripMenuItem_FootPrint, toolStripSeparator4, ToolStripMenuItem_X, ToolStripMenuItem_Y, ToolStripMenuItem_Angle, toolStripSeparator5, ToolStripMenuItem_Layer, toolStripSeparator2,
				ToolStripMenuItem_Hide
			});
			contextMenuStrip_Sn.Name = "contextMenuStrip1";
			contextMenuStrip_Sn.Size = new System.Drawing.Size(68, 198);
			ToolStripMenuItem_Name.Name = "ToolStripMenuItem_Name";
			ToolStripMenuItem_Name.Size = new System.Drawing.Size(67, 22);
			ToolStripMenuItem_Value.Name = "ToolStripMenuItem_Value";
			ToolStripMenuItem_Value.Size = new System.Drawing.Size(67, 22);
			ToolStripMenuItem_FootPrint.Name = "ToolStripMenuItem_FootPrint";
			ToolStripMenuItem_FootPrint.Size = new System.Drawing.Size(67, 22);
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new System.Drawing.Size(64, 6);
			ToolStripMenuItem_X.Name = "ToolStripMenuItem_X";
			ToolStripMenuItem_X.Size = new System.Drawing.Size(67, 22);
			ToolStripMenuItem_Y.Name = "ToolStripMenuItem_Y";
			ToolStripMenuItem_Y.Size = new System.Drawing.Size(67, 22);
			ToolStripMenuItem_Angle.Name = "ToolStripMenuItem_Angle";
			ToolStripMenuItem_Angle.Size = new System.Drawing.Size(67, 22);
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new System.Drawing.Size(64, 6);
			ToolStripMenuItem_Layer.Name = "ToolStripMenuItem_Layer";
			ToolStripMenuItem_Layer.Size = new System.Drawing.Size(67, 22);
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(64, 6);
			ToolStripMenuItem_Hide.Name = "ToolStripMenuItem_Hide";
			ToolStripMenuItem_Hide.Size = new System.Drawing.Size(67, 22);
			cnButton_importmirror.BackColor = System.Drawing.SystemColors.Control;
			cnButton_importmirror.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_importmirror.CnPressDownColor = System.Drawing.Color.White;
			cnButton_importmirror.Location = new System.Drawing.Point(613, 11);
			cnButton_importmirror.Name = "cnButton_importmirror";
			cnButton_importmirror.Size = new System.Drawing.Size(48, 26);
			cnButton_importmirror.TabIndex = 45;
			cnButton_importmirror.Text = "镜像";
			cnButton_importmirror.UseVisualStyleBackColor = false;
			cnButton_importmirror.Click += new System.EventHandler(cnButton_importmirror_Click);
			cnButton_cat.BackColor = System.Drawing.Color.LightSalmon;
			cnButton_cat.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_cat.CnPressDownColor = System.Drawing.Color.White;
			cnButton_cat.Location = new System.Drawing.Point(201, 7);
			cnButton_cat.Name = "cnButton_cat";
			cnButton_cat.Size = new System.Drawing.Size(95, 30);
			cnButton_cat.TabIndex = 44;
			cnButton_cat.Text = "坐标整理";
			cnButton_cat.UseVisualStyleBackColor = false;
			cnButton_cat.Visible = false;
			cnButton_cat.Click += new System.EventHandler(cnButton_cat_Click);
			cnSearchBox1.BackColor = System.Drawing.Color.White;
			cnSearchBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			cnSearchBox1.Location = new System.Drawing.Point(369, 10);
			cnSearchBox1.Name = "cnSearchBox1";
			cnSearchBox1.Size = new System.Drawing.Size(85, 27);
			cnSearchBox1.TabIndex = 43;
			cnSearchBox1.SearchEvent += new System.EventHandler(cnSearchBox1_SearchEvent);
			button_PCBE_Import_Close.BackColor = System.Drawing.SystemColors.Control;
			button_PCBE_Import_Close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_Import_Close.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_Import_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_PCBE_Import_Close.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_PCBE_Import_Close.Location = new System.Drawing.Point(670, 4);
			button_PCBE_Import_Close.Name = "button_PCBE_Import_Close";
			button_PCBE_Import_Close.Size = new System.Drawing.Size(32, 32);
			button_PCBE_Import_Close.TabIndex = 42;
			button_PCBE_Import_Close.Text = "X";
			button_PCBE_Import_Close.UseVisualStyleBackColor = false;
			button_PCBE_Import_Close.Click += new System.EventHandler(button_PCBE_Import_Close_Click);
			button23.BackColor = System.Drawing.SystemColors.Control;
			button23.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button23.CnPressDownColor = System.Drawing.Color.White;
			button23.Font = new System.Drawing.Font("黑体", 10.5f);
			button23.Location = new System.Drawing.Point(4, 27);
			button23.Name = "button23";
			button23.Size = new System.Drawing.Size(48, 26);
			button23.TabIndex = 10;
			button23.Text = "定位";
			button23.UseVisualStyleBackColor = false;
			button21.BackColor = System.Drawing.SystemColors.Control;
			button21.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button21.CnPressDownColor = System.Drawing.Color.White;
			button21.Font = new System.Drawing.Font("黑体", 10.5f);
			button21.Location = new System.Drawing.Point(4, 2);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(48, 26);
			button21.TabIndex = 10;
			button21.Text = "保存";
			button21.UseVisualStyleBackColor = false;
			button_runSign.BackColor = System.Drawing.Color.Moccasin;
			button_runSign.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_runSign.CnPressDownColor = System.Drawing.Color.White;
			button_runSign.Font = new System.Drawing.Font("黑体", 10.5f);
			button_runSign.Location = new System.Drawing.Point(5, 61);
			button_runSign.Name = "button_runSign";
			button_runSign.Size = new System.Drawing.Size(127, 28);
			button_runSign.TabIndex = 9;
			button_runSign.Text = "自动获取";
			button_runSign.UseVisualStyleBackColor = true;
			button_runSign.Click += new System.EventHandler(button_runSign_Click);
			button_GenerateList0.BackColor = System.Drawing.Color.LightSalmon;
			button_GenerateList0.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_GenerateList0.CnPressDownColor = System.Drawing.Color.White;
			button_GenerateList0.Font = new System.Drawing.Font("黑体", 12.25f);
			button_GenerateList0.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_GenerateList0.Location = new System.Drawing.Point(86, 172);
			button_GenerateList0.Name = "button_GenerateList0";
			button_GenerateList0.Size = new System.Drawing.Size(204, 36);
			button_GenerateList0.TabIndex = 16;
			button_GenerateList0.Text = "坐标映射生成";
			button_GenerateList0.UseVisualStyleBackColor = false;
			button_GenerateList0.Click += new System.EventHandler(button_GenerateList0_Click);
			button3.BackColor = System.Drawing.Color.LightGray;
			button3.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button3.CnPressDownColor = System.Drawing.Color.White;
			button3.Location = new System.Drawing.Point(53, 2);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(18, 18);
			button3.TabIndex = 34;
			button3.UseVisualStyleBackColor = false;
			button13.BackColor = System.Drawing.Color.Gray;
			button13.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button13.CnPressDownColor = System.Drawing.Color.White;
			button13.Location = new System.Drawing.Point(1, 2);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(18, 18);
			button13.TabIndex = 34;
			button13.UseVisualStyleBackColor = false;
			button27.BackColor = System.Drawing.Color.Lime;
			button27.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button27.CnPressDownColor = System.Drawing.Color.White;
			button27.Location = new System.Drawing.Point(208, 36);
			button27.Name = "button27";
			button27.Size = new System.Drawing.Size(18, 18);
			button27.TabIndex = 35;
			button27.UseVisualStyleBackColor = false;
			button32.BackColor = System.Drawing.Color.Yellow;
			button32.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button32.CnPressDownColor = System.Drawing.Color.White;
			button32.Location = new System.Drawing.Point(2, 0);
			button32.Name = "button32";
			button32.Size = new System.Drawing.Size(18, 18);
			button32.TabIndex = 34;
			button32.UseVisualStyleBackColor = false;
			button15.BackColor = System.Drawing.SystemColors.Control;
			button15.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button15.CnPressDownColor = System.Drawing.Color.White;
			button15.Font = new System.Drawing.Font("黑体", 10.5f);
			button15.Location = new System.Drawing.Point(54, 26);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(48, 26);
			button15.TabIndex = 10;
			button15.Text = "定位";
			button15.UseVisualStyleBackColor = false;
			button14.BackColor = System.Drawing.SystemColors.Control;
			button14.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button14.CnPressDownColor = System.Drawing.Color.White;
			button14.Font = new System.Drawing.Font("黑体", 10.5f);
			button14.Location = new System.Drawing.Point(54, 1);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(48, 26);
			button14.TabIndex = 10;
			button14.Text = "保存";
			button14.UseVisualStyleBackColor = false;
			button_MoveToSign1.BackColor = System.Drawing.Color.BurlyWood;
			button_MoveToSign1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MoveToSign1.CnPressDownColor = System.Drawing.Color.White;
			button_MoveToSign1.Font = new System.Drawing.Font("黑体", 10.5f);
			button_MoveToSign1.Location = new System.Drawing.Point(127, 27);
			button_MoveToSign1.Name = "button_MoveToSign1";
			button_MoveToSign1.Size = new System.Drawing.Size(48, 26);
			button_MoveToSign1.TabIndex = 7;
			button_MoveToSign1.Text = "定位";
			button_MoveToSign1.UseVisualStyleBackColor = true;
			button_MoveToSign2.BackColor = System.Drawing.Color.BurlyWood;
			button_MoveToSign2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MoveToSign2.CnPressDownColor = System.Drawing.Color.White;
			button_MoveToSign2.Font = new System.Drawing.Font("黑体", 10.5f);
			button_MoveToSign2.Location = new System.Drawing.Point(202, 136);
			button_MoveToSign2.Name = "button_MoveToSign2";
			button_MoveToSign2.Size = new System.Drawing.Size(48, 26);
			button_MoveToSign2.TabIndex = 7;
			button_MoveToSign2.Text = "定位";
			button_MoveToSign2.UseVisualStyleBackColor = true;
			button_SaveSign1.BackColor = System.Drawing.Color.SandyBrown;
			button_SaveSign1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveSign1.CnPressDownColor = System.Drawing.Color.White;
			button_SaveSign1.Font = new System.Drawing.Font("黑体", 10.5f);
			button_SaveSign1.Location = new System.Drawing.Point(127, 2);
			button_SaveSign1.Name = "button_SaveSign1";
			button_SaveSign1.Size = new System.Drawing.Size(48, 26);
			button_SaveSign1.TabIndex = 7;
			button_SaveSign1.Text = "保存";
			button_SaveSign1.UseVisualStyleBackColor = true;
			button_SaveSign2.BackColor = System.Drawing.Color.SandyBrown;
			button_SaveSign2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveSign2.CnPressDownColor = System.Drawing.Color.White;
			button_SaveSign2.Font = new System.Drawing.Font("黑体", 10.5f);
			button_SaveSign2.Location = new System.Drawing.Point(202, 111);
			button_SaveSign2.Name = "button_SaveSign2";
			button_SaveSign2.Size = new System.Drawing.Size(48, 26);
			button_SaveSign2.TabIndex = 7;
			button_SaveSign2.Text = "保存";
			button_SaveSign2.UseVisualStyleBackColor = true;
			button_importAngle.BackColor = System.Drawing.SystemColors.Control;
			button_importAngle.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_importAngle.CnPressDownColor = System.Drawing.Color.White;
			button_importAngle.Font = new System.Drawing.Font("黑体", 10.5f);
			button_importAngle.Location = new System.Drawing.Point(562, 11);
			button_importAngle.Name = "button_importAngle";
			button_importAngle.Size = new System.Drawing.Size(48, 26);
			button_importAngle.TabIndex = 40;
			button_importAngle.Text = "角度";
			button_importAngle.UseVisualStyleBackColor = false;
			button_importAngle.Click += new System.EventHandler(button_importAngle_Click);
			button_pcbview.BackColor = System.Drawing.Color.Red;
			button_pcbview.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pcbview.CnPressDownColor = System.Drawing.Color.White;
			button_pcbview.Font = new System.Drawing.Font("黑体", 10.5f);
			button_pcbview.ForeColor = System.Drawing.Color.White;
			button_pcbview.Location = new System.Drawing.Point(460, 11);
			button_pcbview.Name = "button_pcbview";
			button_pcbview.Size = new System.Drawing.Size(48, 26);
			button_pcbview.TabIndex = 39;
			button_pcbview.Text = "板图";
			button_pcbview.UseVisualStyleBackColor = false;
			button_pcbview.Click += new System.EventHandler(button_pcbview_Click);
			button_importLegal.BackColor = System.Drawing.SystemColors.Control;
			button_importLegal.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_importLegal.CnPressDownColor = System.Drawing.Color.White;
			button_importLegal.Font = new System.Drawing.Font("黑体", 10.5f);
			button_importLegal.Location = new System.Drawing.Point(511, 11);
			button_importLegal.Name = "button_importLegal";
			button_importLegal.Size = new System.Drawing.Size(48, 26);
			button_importLegal.TabIndex = 38;
			button_importLegal.Text = "检测";
			button_importLegal.UseVisualStyleBackColor = false;
			button_importLegal.Click += new System.EventHandler(button_importLegal_Click);
			button_addBom.BackColor = System.Drawing.Color.LightSalmon;
			button_addBom.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_addBom.CnPressDownColor = System.Drawing.Color.White;
			button_addBom.Font = new System.Drawing.Font("黑体", 10.5f);
			button_addBom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_addBom.Location = new System.Drawing.Point(103, 7);
			button_addBom.Name = "button_addBom";
			button_addBom.Size = new System.Drawing.Size(95, 30);
			button_addBom.TabIndex = 36;
			button_addBom.Text = "导入BOM";
			button_addBom.UseVisualStyleBackColor = false;
			button_addBom.Click += new System.EventHandler(button_addBom_Click);
			button_LoadComponentFile.BackColor = System.Drawing.Color.LightSalmon;
			button_LoadComponentFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_LoadComponentFile.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_LoadComponentFile.CnPressDownColor = System.Drawing.Color.White;
			button_LoadComponentFile.Font = new System.Drawing.Font("黑体", 10.5f);
			button_LoadComponentFile.ForeColor = System.Drawing.Color.Black;
			button_LoadComponentFile.Location = new System.Drawing.Point(5, 7);
			button_LoadComponentFile.Name = "button_LoadComponentFile";
			button_LoadComponentFile.Size = new System.Drawing.Size(95, 30);
			button_LoadComponentFile.TabIndex = 32;
			button_LoadComponentFile.Text = "导入坐标";
			button_LoadComponentFile.UseVisualStyleBackColor = false;
			button_LoadComponentFile.Click += new System.EventHandler(button_LoadComponentFile_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.FromArgb(108, 148, 185);
			base.Controls.Add(cnButton_importmirror);
			base.Controls.Add(cnButton_cat);
			base.Controls.Add(cnSearchBox1);
			base.Controls.Add(dataGridView_pcb);
			base.Controls.Add(button_PCBE_Import_Close);
			base.Controls.Add(panel21);
			base.Controls.Add(button_importAngle);
			base.Controls.Add(button_pcbview);
			base.Controls.Add(button_importLegal);
			base.Controls.Add(button_addBom);
			base.Controls.Add(label_loadcomponent_page);
			base.Controls.Add(button_LoadComponentFile);
			base.Controls.Add(label2);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.Name = "UserControl_pcbedit_import";
			base.Size = new System.Drawing.Size(711, 825);
			base.Load += new System.EventHandler(UserControl_pcbedit_import_Load);
			((System.ComponentModel.ISupportInitialize)dataGridView_pcb).EndInit();
			panel21.ResumeLayout(false);
			panel21.PerformLayout();
			panel104.ResumeLayout(false);
			panel102.ResumeLayout(false);
			panel102.PerformLayout();
			panel_loadsetsign.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel106.ResumeLayout(false);
			panel106.PerformLayout();
			panel105.ResumeLayout(false);
			panel105.PerformLayout();
			panel103.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox_Sign2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_Sign1).EndInit();
			contextMenuStrip2.ResumeLayout(false);
			contextMenuStrip_Sn.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
