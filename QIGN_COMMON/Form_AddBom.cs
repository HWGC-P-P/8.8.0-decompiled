using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_AddBom : Form
	{
		private IContainer components;

		private DataGridView dataGridView_bom;

		private Button button_ok;

		private Label label1;

		private Button button_Cancel;

		private Button button_importBom;

		private OpenFileDialog openFileDialog_bom;

		private ContextMenuStrip contextMenuStrip_item;

		private ToolStripMenuItem toolStripMenuItem_label;

		private ToolStripMenuItem toolStripMenuItem_value;

		private ToolStripMenuItem toolStripMenuItem_footprint;

		private ToolStripMenuItem toolStripMenuItem_count;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem toolStripMenuItem_reset;

		private Button button_Xm_Xn;

		private Button button_Descript_X;

		private ToolStripMenuItem toolStripMenuItem_descrip;

		private Label label138;

		private Label label2;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem toolStripMenuItem_hiden;

		private ToolStripMenuItem toolStripMenuItem_showall;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem toolStripMenuItem_clearcolumn;

		private Button button_search;

		private TextBox textBox_search;

		private CheckBox checkBox_autoH;

		private ContextMenuStrip contextMenuStrip_func;

		private ToolStripMenuItem toolStripMenuItem_delete;

		private Label label_filename;

		private ToolStripMenuItem toolStripMenuItem_insert;

		private ToolStripSeparator toolStripSeparator4;

		private Button button_export;

		public int mColumnIndex;

		public BOM_DATA mBom;

		public int mLanguage;

		private int mSearchIdx = -1;

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
			dataGridView_bom = new System.Windows.Forms.DataGridView();
			button_ok = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			button_Cancel = new System.Windows.Forms.Button();
			button_importBom = new System.Windows.Forms.Button();
			openFileDialog_bom = new System.Windows.Forms.OpenFileDialog();
			contextMenuStrip_item = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem_label = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_value = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_footprint = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_descrip = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_count = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_reset = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_showall = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_hiden = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_clearcolumn = new System.Windows.Forms.ToolStripMenuItem();
			button_Xm_Xn = new System.Windows.Forms.Button();
			button_Descript_X = new System.Windows.Forms.Button();
			label138 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_search = new System.Windows.Forms.Button();
			textBox_search = new System.Windows.Forms.TextBox();
			checkBox_autoH = new System.Windows.Forms.CheckBox();
			contextMenuStrip_func = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem_insert = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
			label_filename = new System.Windows.Forms.Label();
			button_export = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)dataGridView_bom).BeginInit();
			contextMenuStrip_item.SuspendLayout();
			contextMenuStrip_func.SuspendLayout();
			SuspendLayout();
			dataGridView_bom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_bom.Location = new System.Drawing.Point(22, 93);
			dataGridView_bom.Margin = new System.Windows.Forms.Padding(4);
			dataGridView_bom.Name = "dataGridView_bom";
			dataGridView_bom.RowTemplate.Height = 23;
			dataGridView_bom.Size = new System.Drawing.Size(1200, 631);
			dataGridView_bom.TabIndex = 0;
			dataGridView_bom.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_bom_CellMouseDown);
			dataGridView_bom.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_bom_ColumnHeaderMouseClick);
			dataGridView_bom.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(dataGridView_bom_ColumnWidthChanged);
			dataGridView_bom.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_bom_RowHeaderMouseClick);
			dataGridView_bom.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dataGridView_bom_RowPostPaint);
			button_ok.BackColor = System.Drawing.Color.Coral;
			button_ok.Font = new System.Drawing.Font("黑体", 14.25f);
			button_ok.Location = new System.Drawing.Point(350, 736);
			button_ok.Margin = new System.Windows.Forms.Padding(4);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(120, 42);
			button_ok.TabIndex = 1;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = false;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			label1.Font = new System.Drawing.Font("黑体", 16.25f, System.Drawing.FontStyle.Bold);
			label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label1.Location = new System.Drawing.Point(22, 11);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(181, 27);
			label1.TabIndex = 2;
			label1.Text = "PCB元件BOM列表";
			button_Cancel.BackColor = System.Drawing.Color.DarkSalmon;
			button_Cancel.Font = new System.Drawing.Font("黑体", 14.25f);
			button_Cancel.Location = new System.Drawing.Point(724, 736);
			button_Cancel.Margin = new System.Windows.Forms.Padding(4);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(120, 42);
			button_Cancel.TabIndex = 1;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = false;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			button_importBom.BackColor = System.Drawing.Color.Coral;
			button_importBom.Font = new System.Drawing.Font("黑体", 12f);
			button_importBom.Location = new System.Drawing.Point(23, 46);
			button_importBom.Margin = new System.Windows.Forms.Padding(4);
			button_importBom.Name = "button_importBom";
			button_importBom.Size = new System.Drawing.Size(151, 40);
			button_importBom.TabIndex = 1;
			button_importBom.Text = "导入BOM文件";
			button_importBom.UseVisualStyleBackColor = false;
			button_importBom.Click += new System.EventHandler(button_importBom_Click);
			openFileDialog_bom.FileName = "openFileDialog1";
			contextMenuStrip_item.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			contextMenuStrip_item.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
			{
				toolStripMenuItem_label, toolStripMenuItem_value, toolStripMenuItem_footprint, toolStripMenuItem_descrip, toolStripMenuItem_count, toolStripSeparator1, toolStripMenuItem_reset, toolStripSeparator2, toolStripMenuItem_showall, toolStripMenuItem_hiden,
				toolStripSeparator3, toolStripMenuItem_clearcolumn
			});
			contextMenuStrip_item.Name = "contextMenuStrip_item";
			contextMenuStrip_item.Size = new System.Drawing.Size(145, 220);
			toolStripMenuItem_label.Name = "toolStripMenuItem_label";
			toolStripMenuItem_label.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_label.Text = "位号";
			toolStripMenuItem_label.Click += new System.EventHandler(toolStripMenuItem_label_Click);
			toolStripMenuItem_value.Name = "toolStripMenuItem_value";
			toolStripMenuItem_value.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_value.Text = "型号";
			toolStripMenuItem_value.Click += new System.EventHandler(toolStripMenuItem_value_Click);
			toolStripMenuItem_footprint.Name = "toolStripMenuItem_footprint";
			toolStripMenuItem_footprint.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_footprint.Text = "封装";
			toolStripMenuItem_footprint.Click += new System.EventHandler(toolStripMenuItem_footprint_Click);
			toolStripMenuItem_descrip.Name = "toolStripMenuItem_descrip";
			toolStripMenuItem_descrip.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_descrip.Text = "描述";
			toolStripMenuItem_descrip.Click += new System.EventHandler(toolStripMenuItem_descrip_Click);
			toolStripMenuItem_count.Name = "toolStripMenuItem_count";
			toolStripMenuItem_count.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_count.Text = "数量";
			toolStripMenuItem_count.Click += new System.EventHandler(toolStripMenuItem_count_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
			toolStripMenuItem_reset.Name = "toolStripMenuItem_reset";
			toolStripMenuItem_reset.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_reset.Text = "重置";
			toolStripMenuItem_reset.Click += new System.EventHandler(toolStripMenuItem_reset_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
			toolStripMenuItem_showall.Name = "toolStripMenuItem_showall";
			toolStripMenuItem_showall.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_showall.Text = "显示全部列";
			toolStripMenuItem_showall.Click += new System.EventHandler(toolStripMenuItem_showall_Click);
			toolStripMenuItem_hiden.Name = "toolStripMenuItem_hiden";
			toolStripMenuItem_hiden.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_hiden.Text = "隐藏当前列";
			toolStripMenuItem_hiden.Click += new System.EventHandler(toolStripMenuItem_hiden_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
			toolStripMenuItem_clearcolumn.Name = "toolStripMenuItem_clearcolumn";
			toolStripMenuItem_clearcolumn.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem_clearcolumn.Text = "清空当前列";
			toolStripMenuItem_clearcolumn.Click += new System.EventHandler(toolStripMenuItem_clearcolumn_Click);
			button_Xm_Xn.Font = new System.Drawing.Font("黑体", 11.25f);
			button_Xm_Xn.Location = new System.Drawing.Point(220, 46);
			button_Xm_Xn.Margin = new System.Windows.Forms.Padding(4);
			button_Xm_Xn.Name = "button_Xm_Xn";
			button_Xm_Xn.Size = new System.Drawing.Size(185, 40);
			button_Xm_Xn.TabIndex = 3;
			button_Xm_Xn.Text = "位号解析Xm-Xn";
			button_Xm_Xn.UseVisualStyleBackColor = true;
			button_Xm_Xn.Click += new System.EventHandler(button_Xm_Xn_Click);
			button_Descript_X.Font = new System.Drawing.Font("黑体", 11.25f);
			button_Descript_X.Location = new System.Drawing.Point(450, 47);
			button_Descript_X.Name = "button_Descript_X";
			button_Descript_X.Size = new System.Drawing.Size(200, 40);
			button_Descript_X.TabIndex = 4;
			button_Descript_X.Text = "描述解析-型号-封装";
			button_Descript_X.UseVisualStyleBackColor = true;
			button_Descript_X.Click += new System.EventHandler(button_Descript_X_Click);
			label138.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label138.Location = new System.Drawing.Point(180, 41);
			label138.Name = "label138";
			label138.Size = new System.Drawing.Size(37, 42);
			label138.TabIndex = 15;
			label138.Text = "➠";
			label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(414, 40);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(37, 42);
			label2.TabIndex = 15;
			label2.Text = "➠";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_search.Font = new System.Drawing.Font("黑体", 10.5f);
			button_search.Location = new System.Drawing.Point(888, 58);
			button_search.Name = "button_search";
			button_search.Size = new System.Drawing.Size(75, 26);
			button_search.TabIndex = 16;
			button_search.Text = "搜索";
			button_search.UseVisualStyleBackColor = true;
			button_search.Click += new System.EventHandler(button1_Click);
			textBox_search.Location = new System.Drawing.Point(965, 58);
			textBox_search.Name = "textBox_search";
			textBox_search.Size = new System.Drawing.Size(123, 25);
			textBox_search.TabIndex = 17;
			checkBox_autoH.AutoSize = true;
			checkBox_autoH.Location = new System.Drawing.Point(1094, 62);
			checkBox_autoH.Name = "checkBox_autoH";
			checkBox_autoH.Size = new System.Drawing.Size(123, 20);
			checkBox_autoH.TabIndex = 18;
			checkBox_autoH.Text = "高度自动对齐";
			checkBox_autoH.UseVisualStyleBackColor = true;
			checkBox_autoH.CheckedChanged += new System.EventHandler(checkBox_autoH_CheckedChanged);
			contextMenuStrip_func.Font = new System.Drawing.Font("黑体", 10.5f);
			contextMenuStrip_func.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem_insert, toolStripSeparator4, toolStripMenuItem_delete });
			contextMenuStrip_func.Name = "contextMenuStrip_func";
			contextMenuStrip_func.Size = new System.Drawing.Size(103, 54);
			toolStripMenuItem_insert.Name = "toolStripMenuItem_insert";
			toolStripMenuItem_insert.Size = new System.Drawing.Size(102, 22);
			toolStripMenuItem_insert.Text = "插入";
			toolStripMenuItem_insert.Click += new System.EventHandler(toolStripMenuItem_insert_Click);
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new System.Drawing.Size(99, 6);
			toolStripMenuItem_delete.Name = "toolStripMenuItem_delete";
			toolStripMenuItem_delete.Size = new System.Drawing.Size(102, 22);
			toolStripMenuItem_delete.Text = "删除";
			toolStripMenuItem_delete.Click += new System.EventHandler(toolStripMenuItem_delete_Click);
			label_filename.AutoSize = true;
			label_filename.ForeColor = System.Drawing.Color.White;
			label_filename.Location = new System.Drawing.Point(228, 16);
			label_filename.Name = "label_filename";
			label_filename.Size = new System.Drawing.Size(72, 16);
			label_filename.TabIndex = 20;
			label_filename.Text = "filename";
			label_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button_export.Location = new System.Drawing.Point(1121, 16);
			button_export.Name = "button_export";
			button_export.Size = new System.Drawing.Size(96, 28);
			button_export.TabIndex = 21;
			button_export.Text = "导出";
			button_export.UseVisualStyleBackColor = true;
			button_export.Click += new System.EventHandler(button_export_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightSlateGray;
			base.ClientSize = new System.Drawing.Size(1244, 788);
			base.Controls.Add(button_export);
			base.Controls.Add(label_filename);
			base.Controls.Add(checkBox_autoH);
			base.Controls.Add(textBox_search);
			base.Controls.Add(button_search);
			base.Controls.Add(label2);
			base.Controls.Add(label138);
			base.Controls.Add(button_Descript_X);
			base.Controls.Add(button_Xm_Xn);
			base.Controls.Add(label1);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(button_importBom);
			base.Controls.Add(button_ok);
			base.Controls.Add(dataGridView_bom);
			Font = new System.Drawing.Font("黑体", 11.5f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_AddBom";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_AddBom_Load);
			((System.ComponentModel.ISupportInitialize)dataGridView_bom).EndInit();
			contextMenuStrip_item.ResumeLayout(false);
			contextMenuStrip_func.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_AddBom(int lan, BOM_DATA bom)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mBom = bom;
			mLanguage = lan;
			if (mLanguage != 0)
			{
				MainForm0.common_updateLanguage(mLanguage, initLanguageTable());
			}
			if (mLanguage != 0)
			{
				MainForm0.common_updateLanguage(mLanguage, initLanguageTable2());
			}
			init_bom();
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "PCB元件BOM列表", "PCB元件BOM列表", "PCB BOM List" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_importBom,
				str = new string[3] { "导入BOM文件", "導入BOM文件", "Import BOM file" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok,
				str = new string[3] { "确定", "確定", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Cancel,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Xm_Xn,
				str = new string[3] { "位号解析Xm-Xn", "位號解析Xm-Xn", "Label Parser Xm-Xn" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Descript_X,
				str = new string[3] { "描述解析-型号-封装", "描述解析-型號-封裝", "Description Parser Footprint/Value " }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_search,
				str = new string[3] { "搜索", "搜索", "Search" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_export,
				str = new string[3] { "导出", "導出", "Export" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_autoH,
				str = new string[3] { "高度对齐", "高度對齊", "Cell Height Align" }
			});
			return list;
		}

		private List<LanguageToolStripMenuItem> initLanguageTable2()
		{
			List<LanguageToolStripMenuItem> list = new List<LanguageToolStripMenuItem>();
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_label,
				str = new string[3] { "位号", "位號", "Label" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_value,
				str = new string[3] { "型号", "型號", "Value" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_footprint,
				str = new string[3] { "封装", "封裝", "FootPrint" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_count,
				str = new string[3] { "数量", "數量", "Count" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_descrip,
				str = new string[3] { "描述", "描述", "Description" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_reset,
				str = new string[3] { "重置", "描述", "Reset" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_showall,
				str = new string[3] { "显示全部列", "顯示全部列", "Visible All Columns" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_hiden,
				str = new string[3] { "隐藏当前列", "隱藏當前列", "Hide Current Column" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_clearcolumn,
				str = new string[3] { "清空当前列", "清空當前列", "Clear Current Column" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_insert,
				str = new string[3] { "插入", "插入", "Insert" }
			});
			list.Add(new LanguageToolStripMenuItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = toolStripMenuItem_delete,
				str = new string[3] { "删除", "刪除", "Delete" }
			});
			return list;
		}

		private void init_bom()
		{
			if (mBom.sn_index == null)
			{
				mBom.sn_index = new int[5] { -1, -1, -1, -1, -1 };
			}
			dataGridView_bom.AllowUserToAddRows = false;
			dataGridView_bom.ReadOnly = false;
			dataGridView_bom.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_bom.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_bom.DataSource = mBom.bomlist;
			dataGridView_bom.RowHeadersWidth = 50;
			dataGridView_bom.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			for (int i = 0; i < dataGridView_bom.Columns.Count; i++)
			{
				dataGridView_bom.Columns[i].Visible = ((!mBom.is_hiden[i]) ? true : false);
				dataGridView_bom.Columns[i].Width = mBom.col_width[i];
				dataGridView_bom.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
				dataGridView_bom.Columns[i].HeaderText = "Sn";
			}
			if (mBom.is_autoH)
			{
				dataGridView_bom.AutoResizeRows();
			}
			else
			{
				for (int j = 0; j < dataGridView_bom.Rows.Count; j++)
				{
					dataGridView_bom.Rows[j].Height = 23;
				}
			}
			checkBox_autoH.Checked = mBom.is_autoH;
			if (mBom.filename == null)
			{
				mBom.filename = "";
			}
			label_filename.Text = mBom.filename;
			toolStrip_refresh();
			mSearchIdx = -1;
		}

		private void button_importBom_Click(object sender, EventArgs e)
		{
			openFileDialog_bom.Filter = "BOM | *.csv";
			if (openFileDialog_bom.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string fileName = openFileDialog_bom.FileName;
			StreamReader streamReader;
			try
			{
				streamReader = new StreamReader(fileName, Encoding.Default);
			}
			catch (Exception)
			{
				MainForm0.CmMessageBoxTop_Ok("软件无法打开BOM文件，可能该文件正被其他软件打开!");
				return;
			}
			mBom.filename = fileName;
			mBom.bomlist.Clear();
			mBom.bom_output.Clear();
			for (int i = 0; i < 12; i++)
			{
				mBom.is_hiden[i] = false;
				mBom.col_width[i] = 60;
			}
			mBom.sn_index = new int[5];
			for (int j = 0; j < 5; j++)
			{
				mBom.sn_index[j] = -1;
			}
			init_bom();
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				text = text.Replace("\t", " ");
				string[] array = text.Split('"');
				if (array != null && array.Count() >= 3)
				{
					text = "";
					for (int k = 0; k < array.Count(); k++)
					{
						if (k % 2 == 1)
						{
							array[k] = array[k].Replace(",", " ");
							array[k] = array[k].Replace("，", " ");
						}
						text += array[k];
					}
				}
				string[] array2 = text.Split(',');
				List<string> list = new List<string>(array2);
				UnknownCvs unknownCvs = new UnknownCvs();
				if (array2 != null)
				{
					if (list.Count > 0)
					{
						unknownCvs.S1 = list[0];
					}
					else
					{
						unknownCvs.S1 = "";
					}
					if (list.Count > 1)
					{
						unknownCvs.S2 = list[1];
					}
					else
					{
						unknownCvs.S2 = "";
					}
					if (list.Count > 2)
					{
						unknownCvs.S3 = list[2];
					}
					else
					{
						unknownCvs.S3 = "";
					}
					if (list.Count > 3)
					{
						unknownCvs.S4 = list[3];
					}
					else
					{
						unknownCvs.S4 = "";
					}
					if (list.Count > 4)
					{
						unknownCvs.S5 = list[4];
					}
					else
					{
						unknownCvs.S5 = "";
					}
					if (list.Count > 5)
					{
						unknownCvs.S6 = list[5];
					}
					else
					{
						unknownCvs.S6 = "";
					}
					if (list.Count > 6)
					{
						unknownCvs.S7 = list[6];
					}
					else
					{
						unknownCvs.S7 = "";
					}
					if (list.Count > 7)
					{
						unknownCvs.S8 = list[7];
					}
					else
					{
						unknownCvs.S8 = "";
					}
					if (list.Count > 8)
					{
						unknownCvs.S9 = list[8];
					}
					else
					{
						unknownCvs.S9 = "";
					}
					if (list.Count > 9)
					{
						unknownCvs.S10 = list[9];
					}
					else
					{
						unknownCvs.S10 = "";
					}
				}
				mBom.bomlist.Add(unknownCvs);
			}
		}

		private void dataGridView_bom_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				mColumnIndex = e.ColumnIndex;
				contextMenuStrip_item.Show(Control.MousePosition.X, Control.MousePosition.Y);
			}
			else if (e.ColumnIndex >= 0 && e.ColumnIndex < 12)
			{
				mColumnIndex = e.ColumnIndex;
				mBom.col_width[mColumnIndex] = dataGridView_bom.Columns[mColumnIndex].Width;
				dataGridView_bom.ClearSelection();
				for (int i = 0; i < dataGridView_bom.RowCount; i++)
				{
					dataGridView_bom.Rows[i].Cells[mColumnIndex].Selected = true;
				}
			}
		}

		private void dataGridView_bom_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				contextMenuStrip_func.Show(Control.MousePosition.X, Control.MousePosition.Y);
			}
		}

		private void dataGridView_bom_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if (mBom != null && mBom.col_width != null && e.Column.Index >= 0 && e.Column.Index < 12)
			{
				mBom.col_width[e.Column.Index] = dataGridView_bom.Columns[e.Column.Index].Width;
				if (mBom.is_autoH)
				{
					dataGridView_bom.AutoResizeRows();
				}
			}
		}

		private void toolStrip_refresh()
		{
			toolStripMenuItem_label.Visible = mBom.sn_index[0] == -1;
			toolStripMenuItem_value.Visible = mBom.sn_index[1] == -1;
			toolStripMenuItem_footprint.Visible = mBom.sn_index[2] == -1;
			toolStripMenuItem_count.Visible = mBom.sn_index[3] == -1;
			toolStripMenuItem_descrip.Visible = mBom.sn_index[4] == -1;
			if (mBom.sn_index[0] != -1)
			{
				dataGridView_bom.Columns[mBom.sn_index[0]].HeaderText = ((mLanguage == 2) ? "Label" : "位号");
			}
			if (mBom.sn_index[1] != -1)
			{
				dataGridView_bom.Columns[mBom.sn_index[1]].HeaderText = ((mLanguage == 2) ? "Value" : "型号");
			}
			if (mBom.sn_index[2] != -1)
			{
				dataGridView_bom.Columns[mBom.sn_index[2]].HeaderText = ((mLanguage == 2) ? "Footprint" : "封装");
			}
			if (mBom.sn_index[3] != -1)
			{
				dataGridView_bom.Columns[mBom.sn_index[3]].HeaderText = ((mLanguage == 2) ? "Count" : "数量");
			}
			if (mBom.sn_index[4] != -1)
			{
				dataGridView_bom.Columns[mBom.sn_index[4]].HeaderText = ((mLanguage == 2) ? "Description" : "描述");
			}
		}

		private void toolStripMenuItem_label_Click(object sender, EventArgs e)
		{
			mBom.sn_index[0] = mColumnIndex;
			toolStrip_refresh();
		}

		private void toolStripMenuItem_value_Click(object sender, EventArgs e)
		{
			mBom.sn_index[1] = mColumnIndex;
			toolStrip_refresh();
		}

		private void toolStripMenuItem_footprint_Click(object sender, EventArgs e)
		{
			mBom.sn_index[2] = mColumnIndex;
			toolStrip_refresh();
		}

		private void toolStripMenuItem_count_Click(object sender, EventArgs e)
		{
			mBom.sn_index[3] = mColumnIndex;
			toolStrip_refresh();
		}

		private void toolStripMenuItem_descrip_Click(object sender, EventArgs e)
		{
			mBom.sn_index[4] = mColumnIndex;
			toolStrip_refresh();
		}

		private void toolStripMenuItem_hiden_Click(object sender, EventArgs e)
		{
			mBom.is_hiden[mColumnIndex] = true;
			dataGridView_bom.Columns[mColumnIndex].Visible = !mBom.is_hiden[mColumnIndex];
		}

		private void toolStripMenuItem_showall_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 12; i++)
			{
				mBom.is_hiden[i] = false;
				dataGridView_bom.Columns[i].Visible = !mBom.is_hiden[mColumnIndex];
			}
		}

		private void toolStripMenuItem_reset_Click(object sender, EventArgs e)
		{
			dataGridView_bom.Columns[mColumnIndex].HeaderText = ((mLanguage == 2) ? "Sn" : "Sn");
			for (int i = 0; i < 5; i++)
			{
				if (mBom.sn_index[i] == mColumnIndex)
				{
					mBom.sn_index[i] = -1;
					toolStrip_refresh();
				}
			}
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			if (mBom.sn_index[0] == -1 || mBom.sn_index[1] == -1 || mBom.sn_index[2] == -1)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Please Complete Label/Value/Footprint Titles!" : "请标记元件位号/型号/封装！");
				return;
			}
			mBom.bom_output.Clear();
			for (int i = 0; i < mBom.bomlist.Count; i++)
			{
				BomInfo bomInfo = new BomInfo();
				if (dataGridView_bom.Rows[i].Cells[mBom.sn_index[0]].Value == null)
				{
					dataGridView_bom.Rows[i].Cells[mBom.sn_index[0]].Value = "";
				}
				if (dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value == null)
				{
					dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value = "";
				}
				if (dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value == null)
				{
					dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value = "";
				}
				bomInfo.Label = dataGridView_bom.Rows[i].Cells[mBom.sn_index[0]].Value.ToString();
				bomInfo.Value = dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value.ToString();
				bomInfo.Footprint = dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value.ToString();
				mBom.bom_output.Add(bomInfo);
			}
			BindingList<string> bindingList = new BindingList<string>();
			for (int j = 0; j < mBom.bom_output.Count; j++)
			{
				string[] array = mBom.bom_output[j].Label.Split(' ');
				if (array == null)
				{
					continue;
				}
				for (int k = 0; k < array.Count(); k++)
				{
					if (array[k] != " " && array[k] != "")
					{
						bindingList.Add(array[k]);
					}
				}
			}
			if (bindingList.Count >= 2)
			{
				for (int l = 0; l < bindingList.Count - 1; l++)
				{
					for (int m = l + 1; m < bindingList.Count; m++)
					{
						if (bindingList[l] == bindingList[m])
						{
							MainForm0.CmMessageBoxTop_Ok("位号" + bindingList[l] + "存在重复定义，请检查BOM！");
							return;
						}
					}
				}
			}
			base.DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_Xm_Xn_Click(object sender, EventArgs e)
		{
			if (mBom.bomlist == null || mBom.bomlist.Count <= 0)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Please import bom list firstly!" : "请先导入PCB元件BOM列表！");
				return;
			}
			if (mBom.sn_index[0] == -1)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Please mark chip label firstly!" : "请先标记哪一列是元件位号！");
				return;
			}
			for (int i = 0; i < mBom.bomlist.Count; i++)
			{
				if (dataGridView_bom.Rows[i].Cells[mBom.sn_index[0]].Value == null)
				{
					dataGridView_bom.Rows[i].Cells[mBom.sn_index[0]].Value = "";
				}
				string text = dataGridView_bom.Rows[i].Cells[mBom.sn_index[0]].Value.ToString();
				string text2 = "";
				text = text.Replace("，", " ");
				string[] array = text.Split(' ');
				if (array == null || array.Count() <= 0)
				{
					continue;
				}
				for (int j = 0; j < array.Count(); j++)
				{
					if (array[j].Contains("-"))
					{
						string[] array2 = array[j].Split('-');
						if (array2 != null && array2.Count() == 2)
						{
							string[] array3 = new string[2] { "", "" };
							string[] array4 = new string[2] { "2", "1" };
							int[] array5 = new int[2] { -1, -1 };
							for (int k = 0; k < 2; k++)
							{
								byte[] bytes = Encoding.Default.GetBytes(array2[k]);
								if (bytes != null && bytes.Count() >= 2)
								{
									int num = 0;
									num = bytes.Count() - 1;
									while (num >= 0 && bytes[num] >= 48 && bytes[num] <= 57)
									{
										num--;
									}
									array3[k] = Encoding.Default.GetString(bytes, 0, num + 1);
									array4[k] = Encoding.Default.GetString(bytes, num + 1, bytes.Count() - (num + 1));
									try
									{
										array5[k] = (int)float.Parse(array4[k]);
									}
									catch (Exception)
									{
										array5[k] = -1;
										break;
									}
								}
							}
							if (array3[0] != "" && array3[1] != "" && array3[0] == array3[1] && array5[0] >= 0 && array5[1] >= 0 && array5[0] < array5[1])
							{
								for (int l = array5[0]; l <= array5[1]; l++)
								{
									text2 = text2 + array3[0] + l + " ";
								}
								dataGridView_bom.Rows[i].Cells[mBom.sn_index[0]].Style.BackColor = Color.LightCoral;
								continue;
							}
						}
					}
					text2 = text2 + array[j] + " ";
				}
				dataGridView_bom.Rows[i].Cells[mBom.sn_index[0]].Value = text2;
			}
			dataGridView_bom.ClearSelection();
			for (int m = 0; m < dataGridView_bom.Rows.Count; m++)
			{
				dataGridView_bom.Rows[m].Cells[mBom.sn_index[0]].Selected = true;
			}
		}

		private void button_Descript_X_Click(object sender, EventArgs e)
		{
			if (mBom.bomlist == null || mBom.bomlist.Count <= 0)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Please import bom list firstly!" : "请先导入PCB元件BOM列表！");
				return;
			}
			if (mBom.sn_index[4] == -1)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Please mark chip label firstly!" : "请先标[描述]列");
				return;
			}
			if (mBom.sn_index[1] == -1 || mBom.sn_index[2] == -1)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Please mark chip label firstly!" : "请选择两个空白列分别标记为[型号]和[封装]");
				return;
			}
			for (int i = 0; i < mBom.bomlist.Count; i++)
			{
				string text = dataGridView_bom.Rows[i].Cells[mBom.sn_index[4]].Value.ToString();
				text = text.Replace("+/-", "±");
				text = text.Replace("，", " ");
				text = text.Replace(",", " ");
				text = text.Replace("/", " ");
				text = text.Replace(":", " ");
				text = text.Replace("：", " ");
				text = text.Replace("(", " ");
				text = text.Replace(")", " ");
				text = text.Replace("SMD", " ");
				text = text.Replace("（", " ");
				text = text.Replace("）", " ");
				string[] array = text.Split(' ');
				FootprintType footprintType = FootprintType.None;
				if (text.Contains("晶体") || text.Contains("晶振") || text.Contains("XTLO") || text.Contains("XTAL"))
				{
					footprintType = FootprintType.Crystal;
				}
				else if (text.Contains("电容") || text.Contains("CAP"))
				{
					footprintType = FootprintType.Cap;
				}
				else if (text.Contains("电阻") || text.Contains("RES"))
				{
					footprintType = FootprintType.Res;
				}
				else if (text.Contains("磁珠"))
				{
					footprintType = FootprintType.CiZhu;
				}
				else if (text.Contains("电感") || text.Contains("IDCTR"))
				{
					footprintType = FootprintType.LnH;
				}
				else if (text.Contains("灯") || text.Contains("LED") || text.Contains("led") || text.Contains("Led"))
				{
					footprintType = FootprintType.Led;
				}
				string text2 = "";
				string text3 = "";
				string text4 = "";
				if (array == null || array.Count() <= 0)
				{
					continue;
				}
				int num = -1;
				int num2 = -1;
				for (int j = 0; j < array.Count(); j++)
				{
					for (int k = 0; k < FOOTPRINT.CORE.Count(); k++)
					{
						if (!array[j].Contains(FOOTPRINT.CORE[k]))
						{
							continue;
						}
						if (k <= 10)
						{
							if (array[j].Replace(FOOTPRINT.CORE[k], "").Length >= 5)
							{
								continue;
							}
							string[] array2 = array[j].Split('-');
							for (int l = 0; l < array2.Count(); l++)
							{
								if (array2[l].Contains(FOOTPRINT.CORE[k]))
								{
									array[j] = array2[l];
									break;
								}
							}
						}
						text4 = array[j];
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value = text4;
						num = j;
						num2 = k;
						text = text.Replace(array[j], "");
						break;
					}
					if (num != -1)
					{
						break;
					}
				}
				for (int m = 0; m < array.Count(); m++)
				{
					if ((array[m].Contains("*") || array[m].Contains("x") || array[m].Contains("X")) && IsNumeric(array[m].Replace("MM", "").Replace("mm", "").Replace("*", "")
						.Replace(".", "")
						.Replace("x", "")
						.Replace("X", "")))
					{
						text4 = array[m];
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value = text4;
						num = m;
						text = text.Replace(array[m], "");
						break;
					}
				}
				text = text.Replace("-", " ");
				array = text.Split(' ');
				if (footprintType == FootprintType.Led && num2 >= 0 && num2 <= 10)
				{
					dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value = "LED" + text4;
				}
				if (footprintType == FootprintType.None && text.Contains("Hz"))
				{
					for (int n = 0; n < FOOTPRINT.RES.Count(); n++)
					{
						if (text.Contains(FOOTPRINT.RES[n]))
						{
							footprintType = FootprintType.CiZhu;
							break;
						}
					}
					if (footprintType == FootprintType.None)
					{
						footprintType = FootprintType.Crystal;
					}
				}
				if (footprintType == FootprintType.Crystal)
				{
					for (int num3 = 0; num3 < array.Count(); num3++)
					{
						if (array[num3].Contains("Hz") || array[num3].Contains("hz") || array[num3].Contains("HZ"))
						{
							text3 = text3 + array[num3] + " ";
						}
						else if (array[num3].Contains("%"))
						{
							text3 = text3 + array[num3] + " ";
						}
						else if (array[num3].Contains("±"))
						{
							text3 = text3 + array[num3] + " ";
						}
					}
					if (text3 == "")
					{
						for (int num4 = 0; num4 < array.Count(); num4++)
						{
							text3 = text3 + array[num4] + " ";
						}
					}
					dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value = text3;
					continue;
				}
				if (num2 >= 0 && num2 <= 10)
				{
					for (int num5 = 0; num5 < array.Count(); num5++)
					{
						if (array[num5].Contains("V"))
						{
							text3 = text3 + array[num5].Replace("C", "") + " ";
						}
						else if (array[num5].Contains("%"))
						{
							text3 = text3 + array[num5] + " ";
						}
						else if (array[num5].Contains("±"))
						{
							text3 = text3 + array[num5] + " ";
						}
						else if (array[num5].Contains("Hz"))
						{
							text3 = text3 + array[num5] + " ";
						}
						else if (IsRes(array[num5]))
						{
							text3 = text3 + array[num5] + " ";
						}
						else if (IsCap(array[num5]))
						{
							text3 = text3 + array[num5] + " ";
						}
						else if (IsLnH(array[num5]))
						{
							text3 = text3 + array[num5] + " ";
						}
					}
					switch (footprintType)
					{
					case FootprintType.CiZhu:
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value = text3;
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value = "L" + text4;
						continue;
					case FootprintType.None:
					{
						for (int num6 = 0; num6 < array.Count(); num6++)
						{
							if (IsCap(array[num6]))
							{
								footprintType = FootprintType.Cap;
								break;
							}
						}
						break;
					}
					}
					switch (footprintType)
					{
					case FootprintType.Cap:
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value = "C" + dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value;
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value = text3;
						continue;
					case FootprintType.None:
					{
						for (int num7 = 0; num7 < array.Count(); num7++)
						{
							for (int num8 = 0; num8 < FOOTPRINT.RES.Count(); num8++)
							{
								if (IsRes(array[num7]))
								{
									footprintType = FootprintType.Res;
									break;
								}
							}
						}
						break;
					}
					}
					switch (footprintType)
					{
					case FootprintType.Res:
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value = "R" + dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value;
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value = text3;
						continue;
					case FootprintType.None:
					{
						for (int num9 = 0; num9 < array.Count(); num9++)
						{
							for (int num10 = 0; num10 < FOOTPRINT.RES.Count(); num10++)
							{
								if (IsLnH(array[num9]))
								{
									footprintType = FootprintType.LnH;
									break;
								}
							}
						}
						break;
					}
					}
					if (footprintType == FootprintType.LnH)
					{
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value = "L" + dataGridView_bom.Rows[i].Cells[mBom.sn_index[2]].Value;
						dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value = text3;
						continue;
					}
				}
				footprintType = FootprintType.Other;
				for (int num11 = 0; num11 < array.Count(); num11++)
				{
					bool flag = false;
					for (int num12 = 0; num12 < FOOTPRINT.REM.Count(); num12++)
					{
						if (array[num11] == FOOTPRINT.REM[num12])
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						text2 += array[num11];
					}
					if (!flag && num11 != array.Count() - 1)
					{
						text2 += " ";
					}
				}
				dataGridView_bom.Rows[i].Cells[mBom.sn_index[1]].Value = text2;
			}
			dataGridView_bom.ClearSelection();
			for (int num13 = 0; num13 < dataGridView_bom.Rows.Count; num13++)
			{
				dataGridView_bom.Rows[num13].Cells[mBom.sn_index[2]].Selected = true;
				dataGridView_bom.Rows[num13].Cells[mBom.sn_index[1]].Selected = true;
			}
		}

		public static bool IsNumeric(string value)
		{
			return Regex.IsMatch(value, "^[+-]?\\d*[.]?\\d*$");
		}

		public static bool IsCap(string value)
		{
			for (int i = 0; i < FOOTPRINT.CAP.Count(); i++)
			{
				if (value.Contains(FOOTPRINT.CAP[i]))
				{
					int startIndex = value.IndexOf(FOOTPRINT.CAP[i]);
					string value2 = value.Remove(startIndex, FOOTPRINT.CAP[i].Length).Replace("C", "");
					if (IsNumeric(value2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool IsRes(string value)
		{
			for (int i = 0; i < FOOTPRINT.RES.Count(); i++)
			{
				if (value.Contains(FOOTPRINT.RES[i]))
				{
					int startIndex = value.IndexOf(FOOTPRINT.RES[i]);
					string value2 = value.Remove(startIndex, FOOTPRINT.RES[i].Length).Replace("R", "");
					if (IsNumeric(value2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool IsLnH(string value)
		{
			for (int i = 0; i < FOOTPRINT.LH.Count(); i++)
			{
				if (value.Contains(FOOTPRINT.LH[i]))
				{
					int startIndex = value.IndexOf(FOOTPRINT.LH[i]);
					string value2 = value.Remove(startIndex, FOOTPRINT.LH[i].Length);
					if (IsNumeric(value2))
					{
						return true;
					}
				}
			}
			return false;
		}

		private void toolStripMenuItem_clearcolumn_Click(object sender, EventArgs e)
		{
			if (mColumnIndex >= 0 && mColumnIndex < 12 && MainForm0.CmMessageBox("确定清空当前列数据？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridView_bom.RowCount; i++)
				{
					dataGridView_bom.Rows[i].Cells[mColumnIndex].Value = "";
				}
			}
		}

		private void checkBox_autoH_CheckedChanged(object sender, EventArgs e)
		{
			mBom.is_autoH = checkBox_autoH.Checked;
			if (mBom.is_autoH)
			{
				dataGridView_bom.AutoResizeRows();
				return;
			}
			for (int i = 0; i < dataGridView_bom.Rows.Count; i++)
			{
				dataGridView_bom.Rows[i].Height = 23;
			}
		}

		private void toolStripMenuItem_delete_Click(object sender, EventArgs e)
		{
			int count = dataGridView_bom.SelectedRows.Count;
			if (count <= 0)
			{
				MainForm0.CmMessageBoxTop_Ok("请选中要删除的行!");
			}
			else if (MainForm0.CmMessageBox("确定要删除选定行吗?", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				BindingList<UnknownCvs> bindingList = new BindingList<UnknownCvs>();
				for (int i = 0; i < count; i++)
				{
					int index = dataGridView_bom.SelectedRows[i].Index;
					bindingList.Add(mBom.bomlist[index]);
				}
				for (int j = 0; j < bindingList.Count; j++)
				{
					mBom.bomlist.Remove(bindingList[j]);
				}
				dataGridView_bom.Refresh();
			}
		}

		private void toolStripMenuItem_insert_Click(object sender, EventArgs e)
		{
			int count = dataGridView_bom.SelectedRows.Count;
			if (count <= 0)
			{
				MainForm0.CmMessageBoxTop_Ok("请选中要删除的行!");
			}
			else if (count == 1)
			{
				int index = dataGridView_bom.SelectedRows[0].Index;
				UnknownCvs item = new UnknownCvs();
				mBom.bomlist.Insert(index, item);
				dataGridView_bom.Refresh();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			mSearchIdx++;
			dataGridView_bom.ClearSelection();
			if (mSearchIdx < 0)
			{
				mSearchIdx = 0;
			}
			if (mSearchIdx >= dataGridView_bom.Rows.Count * 12)
			{
				mSearchIdx = 0;
			}
			string value = textBox_search.Text;
			int num = 0;
			for (int i = 0; i < dataGridView_bom.Rows.Count; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					if (num++ >= mSearchIdx && !mBom.is_hiden[j])
					{
						if (dataGridView_bom.Rows[i].Cells[j].Value == null)
						{
							dataGridView_bom.Rows[i].Cells[j].Value = "";
						}
						string text = dataGridView_bom.Rows[i].Cells[j].Value.ToString();
						if (text.Contains(value))
						{
							mSearchIdx = num;
							dataGridView_bom.Rows[i].Cells[j].Selected = true;
							dataGridView_bom.FirstDisplayedScrollingRowIndex = i;
							return;
						}
					}
				}
			}
			mSearchIdx = 0;
			num = 0;
			for (int k = 0; k < dataGridView_bom.Rows.Count; k++)
			{
				for (int l = 0; l < 12; l++)
				{
					if (num++ >= mSearchIdx && !mBom.is_hiden[l])
					{
						if (dataGridView_bom.Rows[k].Cells[l].Value == null)
						{
							dataGridView_bom.Rows[k].Cells[l].Value = "";
						}
						string text2 = dataGridView_bom.Rows[k].Cells[l].Value.ToString();
						if (text2.Contains(value))
						{
							mSearchIdx = num;
							dataGridView_bom.Rows[k].Cells[l].Selected = true;
							dataGridView_bom.FirstDisplayedScrollingRowIndex = k;
							return;
						}
					}
				}
			}
		}

		private void dataGridView_bom_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (dataGridView_bom.CurrentCell != null)
			{
				int columnIndex = dataGridView_bom.CurrentCell.ColumnIndex;
				int rowIndex = dataGridView_bom.CurrentCell.RowIndex;
				mColumnIndex = columnIndex;
				mSearchIdx = rowIndex * 12 + columnIndex;
			}
		}

		private void button_export_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = ((MainForm0.USR_INIT.mLanguage == 2) ? "EXCEL（*.csv）|*.csv" : "EXCEL（*.csv）|*.csv");
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
			string[] array = new string[5] { "位号", "型号", "封装", "数量", "描述" };
			string text = "";
			for (int i = 0; i < 5; i++)
			{
				int num = mBom.sn_index[i];
				if (num != -1 && !mBom.is_hiden[num])
				{
					text = text + array[i] + ", ";
				}
			}
			text += Environment.NewLine;
			streamWriter.Write(text);
			streamWriter.Flush();
			for (int j = 0; j < dataGridView_bom.Rows.Count; j++)
			{
				string text2 = "";
				for (int k = 0; k < 5; k++)
				{
					int num2 = mBom.sn_index[k];
					if (num2 != -1 && !mBom.is_hiden[num2])
					{
						text2 = text2 + dataGridView_bom.Rows[j].Cells[num2].Value.ToString() + ", ";
					}
				}
				text2 += Environment.NewLine;
				streamWriter.Write(text2);
				streamWriter.Flush();
			}
			streamWriter.Close();
			fileStream.Close();
			MainForm0.CmMessageBoxTop_Ok((MainForm0.USR_INIT.mLanguage == 2) ? "Export Done!" : "导出BOM文件完成！");
		}

		private void Form_AddBom_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_importBom);
			MainForm0.CreateAddButtonPic(button_Xm_Xn);
			MainForm0.CreateAddButtonPic(button_Descript_X);
			MainForm0.CreateAddButtonPic(button_export);
			MainForm0.CreateAddButtonPic(button_search);
			MainForm0.CreateAddButtonPic(button_ok);
			MainForm0.CreateAddButtonPic(button_Cancel);
		}

		private void dataGridView_bom_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			DataGridView dataGridView = sender as DataGridView;
			Rectangle bounds = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView.RowHeadersWidth - 4, e.RowBounds.Height);
			TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView.RowHeadersDefaultCellStyle.Font, bounds, dataGridView.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
		}
	}
}
