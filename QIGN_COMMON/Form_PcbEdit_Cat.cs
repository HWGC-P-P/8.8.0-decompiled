using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_PcbEdit_Cat : Form
	{
		private IContainer components;

		private CnButton button_Delete;

		private ContextMenuStrip contextMenuStrip_pcbcat_cell;

		private Label label1;

		private CnButton button_OKtoGen;

		private CnButton button_preSlotDisable;

		private CnButton button_SaveExit;

		private Label label2;

		private Label label_index_num;

		private CnButton button_OptimizeHistory;

		private CnButton button_importStackNo;

		private CnButton button_OverridetoUSR2;

		private Label label3;

		private DataGridView dataGridView_pcbcat;

		private Panel panel1;

		private CnButton button_updatefromFootprintLib;

		private CnButton button1;

		private CnButton button2;

		private CnButton button3;

		private CnButton button_saveas_libprovider;

		private CheckBox checkBox_is_backup_nozzle;

		private Label label61;

		public int mCatlist_index;

		private BindingList<ChipCategoryElement> tempCatlist = new BindingList<ChipCategoryElement>();

		public BindingList<ChipCategoryElement> mPointlistCat;

		public BindingList<ChipCategoryElement> mPointlistCat_History;

		public USR2_DATA USR2;

		public USR_DATA USR;

		private USR_INIT_DATA USR_INIT;

		public BindingList<USR3_DATA> mUSR3List;

		public USR_PRJ_DATA usr_prj;

		public USR_PRJ_EX_DATA usr_prj_ex;

		public float[][] isSlotBrkn;

		public int[] mNozzleEnable;

		public int mLanguage;

		public int mFn;

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

		private Form_Cat_from_otherfile fm_cat_from_otherfile;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.Form_PcbEdit_Cat));
			button_Delete = new QIGN_COMMON.vs_acontrol.CnButton();
			contextMenuStrip_pcbcat_cell = new System.Windows.Forms.ContextMenuStrip(components);
			label1 = new System.Windows.Forms.Label();
			button_OKtoGen = new QIGN_COMMON.vs_acontrol.CnButton();
			button_preSlotDisable = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveExit = new QIGN_COMMON.vs_acontrol.CnButton();
			label2 = new System.Windows.Forms.Label();
			label_index_num = new System.Windows.Forms.Label();
			button_OptimizeHistory = new QIGN_COMMON.vs_acontrol.CnButton();
			button_importStackNo = new QIGN_COMMON.vs_acontrol.CnButton();
			button_OverridetoUSR2 = new QIGN_COMMON.vs_acontrol.CnButton();
			label3 = new System.Windows.Forms.Label();
			dataGridView_pcbcat = new System.Windows.Forms.DataGridView();
			panel1 = new System.Windows.Forms.Panel();
			button_updatefromFootprintLib = new QIGN_COMMON.vs_acontrol.CnButton();
			button1 = new QIGN_COMMON.vs_acontrol.CnButton();
			button2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button3 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_saveas_libprovider = new QIGN_COMMON.vs_acontrol.CnButton();
			checkBox_is_backup_nozzle = new System.Windows.Forms.CheckBox();
			label61 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)dataGridView_pcbcat).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			button_Delete.BackColor = System.Drawing.SystemColors.ControlLight;
			button_Delete.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_Delete.CnPressDownColor = System.Drawing.Color.White;
			button_Delete.Font = new System.Drawing.Font("黑体", 11f);
			button_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_Delete.Location = new System.Drawing.Point(18, 94);
			button_Delete.Name = "button_Delete";
			button_Delete.Size = new System.Drawing.Size(98, 32);
			button_Delete.TabIndex = 1;
			button_Delete.Text = "删除选定";
			button_Delete.UseVisualStyleBackColor = false;
			button_Delete.Click += new System.EventHandler(button_Delete_Click);
			contextMenuStrip_pcbcat_cell.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			contextMenuStrip_pcbcat_cell.Name = "contextMenuStrip_pcbcat_cell";
			contextMenuStrip_pcbcat_cell.Size = new System.Drawing.Size(61, 4);
			label1.Font = new System.Drawing.Font("黑体", 14.25f);
			label1.Location = new System.Drawing.Point(15, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(870, 41);
			label1.TabIndex = 3;
			label1.Text = "分类设置 优化生成贴装列表";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_OKtoGen.BackColor = System.Drawing.Color.LightSalmon;
			button_OKtoGen.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_OKtoGen.CnPressDownColor = System.Drawing.Color.White;
			button_OKtoGen.Font = new System.Drawing.Font("黑体", 14f);
			button_OKtoGen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_OKtoGen.Location = new System.Drawing.Point(598, 60);
			button_OKtoGen.Name = "button_OKtoGen";
			button_OKtoGen.Size = new System.Drawing.Size(181, 66);
			button_OKtoGen.TabIndex = 4;
			button_OKtoGen.Text = "一键生成";
			button_OKtoGen.UseVisualStyleBackColor = false;
			button_OKtoGen.Click += new System.EventHandler(button_OK_Click);
			button_preSlotDisable.BackColor = System.Drawing.SystemColors.ControlLight;
			button_preSlotDisable.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_preSlotDisable.CnPressDownColor = System.Drawing.Color.White;
			button_preSlotDisable.Font = new System.Drawing.Font("黑体", 11f);
			button_preSlotDisable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_preSlotDisable.Location = new System.Drawing.Point(19, 60);
			button_preSlotDisable.Name = "button_preSlotDisable";
			button_preSlotDisable.Size = new System.Drawing.Size(284, 32);
			button_preSlotDisable.TabIndex = 5;
			button_preSlotDisable.Text = "料槽吸嘴禁用设置";
			button_preSlotDisable.UseVisualStyleBackColor = false;
			button_preSlotDisable.Click += new System.EventHandler(button_preSlotDisable_Click);
			button_SaveExit.BackColor = System.Drawing.Color.PaleTurquoise;
			button_SaveExit.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveExit.CnPressDownColor = System.Drawing.Color.White;
			button_SaveExit.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_SaveExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_SaveExit.Location = new System.Drawing.Point(343, 198);
			button_SaveExit.Name = "button_SaveExit";
			button_SaveExit.Size = new System.Drawing.Size(78, 30);
			button_SaveExit.TabIndex = 5;
			button_SaveExit.Text = "保存退出";
			button_SaveExit.UseVisualStyleBackColor = false;
			button_SaveExit.Visible = false;
			button_SaveExit.Click += new System.EventHandler(button_SaveExit_Click);
			label2.Font = new System.Drawing.Font("微软雅黑", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(10, 33);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(52, 52);
			label2.TabIndex = 15;
			label2.Text = "➠";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_index_num.Font = new System.Drawing.Font("黑体", 11f);
			label_index_num.Location = new System.Drawing.Point(316, 93);
			label_index_num.Name = "label_index_num";
			label_index_num.Size = new System.Drawing.Size(151, 26);
			label_index_num.TabIndex = 18;
			label_index_num.Text = "0/0";
			label_index_num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_OptimizeHistory.BackColor = System.Drawing.SystemColors.ControlLight;
			button_OptimizeHistory.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_OptimizeHistory.CnPressDownColor = System.Drawing.Color.White;
			button_OptimizeHistory.Font = new System.Drawing.Font("黑体", 11f);
			button_OptimizeHistory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_OptimizeHistory.Location = new System.Drawing.Point(783, 94);
			button_OptimizeHistory.Name = "button_OptimizeHistory";
			button_OptimizeHistory.Size = new System.Drawing.Size(119, 32);
			button_OptimizeHistory.TabIndex = 19;
			button_OptimizeHistory.Text = "优化结果";
			button_OptimizeHistory.UseVisualStyleBackColor = false;
			button_OptimizeHistory.Click += new System.EventHandler(button_OptimizeHistory_Click);
			button_importStackNo.BackColor = System.Drawing.SystemColors.ControlLight;
			button_importStackNo.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_importStackNo.CnPressDownColor = System.Drawing.Color.White;
			button_importStackNo.Font = new System.Drawing.Font("黑体", 11f);
			button_importStackNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_importStackNo.Location = new System.Drawing.Point(118, 94);
			button_importStackNo.Name = "button_importStackNo";
			button_importStackNo.Size = new System.Drawing.Size(185, 32);
			button_importStackNo.TabIndex = 20;
			button_importStackNo.Text = "从其他工程导入料站号";
			button_importStackNo.UseVisualStyleBackColor = false;
			button_importStackNo.Click += new System.EventHandler(button_importStackNo_Click);
			button_OverridetoUSR2.BackColor = System.Drawing.Color.CornflowerBlue;
			button_OverridetoUSR2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_OverridetoUSR2.CnPressDownColor = System.Drawing.Color.White;
			button_OverridetoUSR2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OverridetoUSR2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_OverridetoUSR2.Location = new System.Drawing.Point(133, 270);
			button_OverridetoUSR2.Name = "button_OverridetoUSR2";
			button_OverridetoUSR2.Size = new System.Drawing.Size(185, 30);
			button_OverridetoUSR2.TabIndex = 21;
			button_OverridetoUSR2.Text = "覆盖到料站参数";
			button_OverridetoUSR2.UseVisualStyleBackColor = true;
			button_OverridetoUSR2.Visible = false;
			button_OverridetoUSR2.Click += new System.EventHandler(button_OverridetoUSR2_Click);
			label3.Font = new System.Drawing.Font("微软雅黑", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(11, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(52, 52);
			label3.TabIndex = 15;
			label3.Text = "➠";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			dataGridView_pcbcat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_pcbcat.Location = new System.Drawing.Point(19, 131);
			dataGridView_pcbcat.Margin = new System.Windows.Forms.Padding(4);
			dataGridView_pcbcat.Name = "dataGridView_pcbcat";
			dataGridView_pcbcat.RowTemplate.Height = 23;
			dataGridView_pcbcat.Size = new System.Drawing.Size(882, 710);
			dataGridView_pcbcat.TabIndex = 0;
			dataGridView_pcbcat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_pcbcat_CellContentClick);
			dataGridView_pcbcat.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_pcbcat_CellDoubleClick);
			dataGridView_pcbcat.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcbcat_CellMouseClick);
			dataGridView_pcbcat.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcbcat_CellMouseDown);
			dataGridView_pcbcat.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcbcat_CellMouseUp);
			dataGridView_pcbcat.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_pcbcat_ColumnHeaderMouseDoubleClick);
			dataGridView_pcbcat.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dataGridView_pcbcat_RowPostPaint);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Location = new System.Drawing.Point(440, 262);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(71, 85);
			panel1.TabIndex = 22;
			panel1.Visible = false;
			button_updatefromFootprintLib.BackColor = System.Drawing.SystemColors.ControlLight;
			button_updatefromFootprintLib.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_updatefromFootprintLib.CnPressDownColor = System.Drawing.Color.White;
			button_updatefromFootprintLib.Font = new System.Drawing.Font("黑体", 13f);
			button_updatefromFootprintLib.Location = new System.Drawing.Point(471, 60);
			button_updatefromFootprintLib.Name = "button_updatefromFootprintLib";
			button_updatefromFootprintLib.Size = new System.Drawing.Size(123, 66);
			button_updatefromFootprintLib.TabIndex = 24;
			button_updatefromFootprintLib.Text = "来自\r\n封装库";
			button_updatefromFootprintLib.UseVisualStyleBackColor = false;
			button_updatefromFootprintLib.Click += new System.EventHandler(button_updatefromFootprintLib_Click);
			button1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button1.CnPressDownColor = System.Drawing.Color.White;
			button1.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button1.Location = new System.Drawing.Point(199, 234);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(119, 30);
			button1.TabIndex = 25;
			button1.Text = "来自本地料站库";
			button1.UseVisualStyleBackColor = true;
			button1.Visible = false;
			button2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button2.CnPressDownColor = System.Drawing.Color.White;
			button2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button2.Location = new System.Drawing.Point(74, 198);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(119, 30);
			button2.TabIndex = 26;
			button2.Text = "封装库";
			button2.UseVisualStyleBackColor = true;
			button2.Visible = false;
			button3.BackColor = System.Drawing.SystemColors.ControlLight;
			button3.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button3.CnPressDownColor = System.Drawing.Color.White;
			button3.Font = new System.Drawing.Font("黑体", 11f);
			button3.Location = new System.Drawing.Point(783, 60);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(119, 32);
			button3.TabIndex = 26;
			button3.Text = "本地料站库";
			button3.UseVisualStyleBackColor = false;
			button_saveas_libprovider.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_saveas_libprovider.CnPressDownColor = System.Drawing.Color.White;
			button_saveas_libprovider.Font = new System.Drawing.Font("黑体", 11f);
			button_saveas_libprovider.Location = new System.Drawing.Point(147, 315);
			button_saveas_libprovider.Name = "button_saveas_libprovider";
			button_saveas_libprovider.Size = new System.Drawing.Size(155, 30);
			button_saveas_libprovider.TabIndex = 27;
			button_saveas_libprovider.Text = "保存为本地料站库";
			button_saveas_libprovider.UseVisualStyleBackColor = true;
			button_saveas_libprovider.Visible = false;
			button_saveas_libprovider.Click += new System.EventHandler(button_saveas_libprovider_Click);
			checkBox_is_backup_nozzle.AutoSize = true;
			checkBox_is_backup_nozzle.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_is_backup_nozzle.Location = new System.Drawing.Point(331, 68);
			checkBox_is_backup_nozzle.Name = "checkBox_is_backup_nozzle";
			checkBox_is_backup_nozzle.Size = new System.Drawing.Size(122, 19);
			checkBox_is_backup_nozzle.TabIndex = 29;
			checkBox_is_backup_nozzle.Text = "开启备用吸嘴";
			checkBox_is_backup_nozzle.UseVisualStyleBackColor = true;
			checkBox_is_backup_nozzle.CheckedChanged += new System.EventHandler(checkBox_is_backup_nozzle_CheckedChanged);
			label61.BackColor = System.Drawing.Color.Red;
			label61.Location = new System.Drawing.Point(17, 45);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(880, 4);
			label61.TabIndex = 177;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Wheat;
			base.ClientSize = new System.Drawing.Size(914, 861);
			base.Controls.Add(label61);
			base.Controls.Add(checkBox_is_backup_nozzle);
			base.Controls.Add(button_SaveExit);
			base.Controls.Add(button_saveas_libprovider);
			base.Controls.Add(button3);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(button_updatefromFootprintLib);
			base.Controls.Add(panel1);
			base.Controls.Add(button_OKtoGen);
			base.Controls.Add(button_preSlotDisable);
			base.Controls.Add(button_OverridetoUSR2);
			base.Controls.Add(button_importStackNo);
			base.Controls.Add(button_OptimizeHistory);
			base.Controls.Add(label_index_num);
			base.Controls.Add(label1);
			base.Controls.Add(button_Delete);
			base.Controls.Add(dataGridView_pcbcat);
			Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_PcbEdit_Cat";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_PcbEdit_Cat_FormClosing);
			base.Load += new System.EventHandler(Form_PcbEdit_Cat_Load);
			((System.ComponentModel.ISupportInitialize)dataGridView_pcbcat).EndInit();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_PcbEdit_Cat(int fn, USR_DATA usr, USR2_DATA usr2, BindingList<USR3_DATA> musr3list, BindingList<ChipCategoryElement> catlist, BindingList<ChipCategoryElement> catlist_hisotry, float[][] isbroken, int[] nzstate)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mFn = fn;
			USR = usr;
			USR2 = usr2;
			USR_INIT = MainForm0.USR_INIT;
			mUSR3List = musr3list;
			mLanguage = USR_INIT.mLanguage;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			mPointlistCat = catlist;
			mPointlistCat_History = catlist_hisotry;
			isSlotBrkn = isbroken;
			mNozzleEnable = nzstate;
			init_pcbedit_editlistcat();
		}

		private void Form_PcbEdit_Cat_Load(object sender, EventArgs e)
		{
			Type type = dataGridView_pcbcat.GetType();
			PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(dataGridView_pcbcat, true, null);
			checkBox_is_backup_nozzle.Checked = MainForm0.USR3B[mFn].mIsEnableBackupNozzle;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "分类设置 优化生成贴装列表", "分類設置 優化生成貼裝列表", "Classification and Optimization of SMT" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_preSlotDisable,
				str = new string[3] { "料槽吸嘴禁用设置", "料槽吸嘴禁用設置", "Feeder Slot and Nozzle Disable" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Delete,
				str = new string[3] { "删除选定", "刪除選定", "Delete" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_importStackNo,
				str = new string[3] { "从其他工程导入料站号", "從其他工程導入料站號", "Load Feeder No From Other Prject" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_is_backup_nozzle,
				str = new string[3] { "开启备用吸嘴", "開啟備用吸嘴", "Enable Backup Nozzle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_updatefromFootprintLib,
				str = new string[3]
				{
					"来自" + Environment.NewLine + "封装库",
					"來自" + Environment.NewLine + "封裝庫",
					"From" + Environment.NewLine + "Footprint Lab"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OKtoGen,
				str = new string[3] { "一键生成", "一鍵生成", "Optimization" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button3,
				str = new string[3] { "本地料站库", "本地料站庫", "Local Feeder Lab" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OptimizeHistory,
				str = new string[3] { "优化结果", "優化結果", "Result" }
			});
			return list;
		}

		private void init_pcbedit_editlistcat()
		{
			dataGridView_pcbcat.AllowUserToAddRows = false;
			dataGridView_pcbcat.ReadOnly = false;
			dataGridView_pcbcat.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_pcbcat.DataSource = mPointlistCat;
			dataGridView_pcbcat.RowHeadersWidth = 50;
			dataGridView_pcbcat.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView_pcbcat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_pcbcat.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView_pcbcat.ColumnHeadersDefaultCellStyle.Font = new Font(DEF.FONT_2020[mLanguage], 10f, FontStyle.Regular);
			dataGridView_pcbcat.DefaultCellStyle.Font = new Font(DEF.FONT_2020[mLanguage], 10f, FontStyle.Regular);
			dataGridView_pcbcat.EnableHeadersVisualStyles = false;
			dataGridView_pcbcat.TopLeftHeaderCell.Value = (new string[3] { "表头", "表頭", "Head" })[USR_INIT.mLanguage];
			dataGridView_pcbcat.DefaultCellStyle.Font = new Font(DEF.FONT_2020_DATA[USR_INIT.mLanguage], 10f, FontStyle.Regular);
			dataGridView_pcbcat.Columns[9].DefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f, FontStyle.Regular);
			dataGridView_pcbcat.Columns[10].DefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f, FontStyle.Regular);
			dataGridView_pcbcat.Columns[11].DefaultCellStyle.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f, FontStyle.Regular);
			foreach (DataGridViewColumn column in dataGridView_pcbcat.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			dataGridView_pcbcat.Columns[7].Visible = MainForm0.USR3B[mFn].mIsEnableBackupNozzle;
			dataGridView_pcbcat.Columns[28].Visible = false;
			for (int i = 0; i < 29; i++)
			{
				if (i > 12)
				{
					dataGridView_pcbcat.Columns[i].Visible = false;
				}
				if (i == 17)
				{
					dataGridView_pcbcat.Columns[i].Visible = true;
				}
				dataGridView_pcbcat.Columns[i].Width = CAT_HEAD[i].width[mLanguage];
				dataGridView_pcbcat.Columns[i].HeaderText = CAT_HEAD[i].str[mLanguage];
				if (i == 8 || i == 15 || i == 16 || i == 17)
				{
					DataGridViewColumn dataGridViewColumn2 = dataGridView_pcbcat.Columns[i];
					dataGridViewColumn2.HeaderText = dataGridViewColumn2.HeaderText + Environment.NewLine + STR._MM[mLanguage];
				}
				if (i != 12 && i != 18)
				{
					dataGridView_pcbcat.Columns[i].ReadOnly = true;
				}
				if (i >= 13)
				{
					dataGridView_pcbcat.Columns[i].DefaultCellStyle.BackColor = Color.LightBlue;
				}
				if (i == 1)
				{
					dataGridView_pcbcat.Columns[i].DefaultCellStyle.BackColor = Color.LightSalmon;
				}
				if (i == 2 || i == 0)
				{
					dataGridView_pcbcat.Columns[i].DefaultCellStyle.BackColor = Color.LightGray;
				}
				if (i == 3 || i == 6 || i == 7 || i == 9 || i == 10 || i == 11 || i == 8 || i == 12)
				{
					dataGridView_pcbcat.Columns[i].DefaultCellStyle.BackColor = Color.LightYellow;
				}
			}
			label_index_num.Text = "1/" + mPointlistCat.Count;
		}

		private void dataGridView_pcbcat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (dataGridView_pcbcat.SelectedCells.Count > 0)
				{
					_ = dataGridView_pcbcat.SelectedCells[0].RowIndex;
					int columnIndex = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
					for (int i = 0; i < dataGridView_pcbcat.SelectedCells.Count && columnIndex == dataGridView_pcbcat.SelectedCells[i].ColumnIndex; i++)
					{
					}
				}
			}
			else if (e.RowIndex >= 0)
			{
				mCatlist_index = e.RowIndex;
				label_index_num.Text = mCatlist_index + 1 + "/" + mPointlistCat.Count;
				if (e.ColumnIndex == 10)
				{
					dataGridView_pcbcat.Rows[mCatlist_index].Cells[11].Selected = true;
				}
				else if (e.ColumnIndex == 11)
				{
					dataGridView_pcbcat.Rows[mCatlist_index].Cells[10].Selected = true;
				}
			}
		}

		private void dataGridView_pcbcat_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left || dataGridView_pcbcat.SelectedCells.Count <= 0)
			{
				return;
			}
			BindingList<Point> bindingList = new BindingList<Point>();
			for (int i = 0; i < dataGridView_pcbcat.SelectedCells.Count; i++)
			{
				switch (dataGridView_pcbcat.SelectedCells[i].ColumnIndex)
				{
				case 10:
					bindingList.Add(new Point(dataGridView_pcbcat.SelectedCells[i].RowIndex, 11));
					break;
				case 11:
					bindingList.Add(new Point(dataGridView_pcbcat.SelectedCells[i].RowIndex, 10));
					break;
				}
			}
			for (int j = 0; j < bindingList.Count; j++)
			{
				dataGridView_pcbcat.Rows[bindingList[j].X].Cells[bindingList[j].Y].Selected = true;
			}
		}

		private void fill_catcells_manual_click(object sender, EventArgs e)
		{
			string type = "";
			string text = "float";
			object value = 0;
			int count = dataGridView_pcbcat.SelectedCells.Count;
			if (count > 0)
			{
				int columnIndex = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
				for (int i = 0; i < count; i++)
				{
					if (columnIndex != 8 && columnIndex != 0 && columnIndex != 1 && columnIndex != 15 && columnIndex != 16 && columnIndex != 17 && columnIndex != 13 && columnIndex != 14 && columnIndex != 19 && columnIndex != 20 && columnIndex != 24 && columnIndex != 21 && columnIndex != 22 && columnIndex != 23 && columnIndex != 25 && columnIndex != 26 && columnIndex != 27)
					{
						continue;
					}
					type = CAT_HEAD[columnIndex].str[mLanguage];
					switch (columnIndex)
					{
					case 0:
					case 1:
						text = "string";
						break;
					case 8:
					case 15:
					case 16:
					case 17:
					case 19:
					case 20:
					case 24:
						text = "float";
						break;
					default:
						text = "int";
						break;
					}
					if (text == "string")
					{
						value = dataGridView_pcbcat.SelectedCells[0].Value;
						continue;
					}
					string s = dataGridView_pcbcat.SelectedCells[0].Value.ToString();
					try
					{
						float num = float.Parse(s);
						if (text == "float")
						{
							value = num;
						}
						else if (text == "int")
						{
							value = (int)num;
						}
					}
					catch (Exception)
					{
					}
				}
			}
			Form_Fill form_Fill = ((!(text == "string")) ? new Form_Fill(mLanguage, type, text) : new Form_Fill(mLanguage, value, type, text));
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			int count2 = dataGridView_pcbcat.SelectedCells.Count;
			if (count2 <= 0)
			{
				return;
			}
			int columnIndex2 = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
			for (int j = 0; j < count2; j++)
			{
				if (columnIndex2 == 0 || columnIndex2 == 1)
				{
					int rowIndex = dataGridView_pcbcat.SelectedCells[j].RowIndex;
					string material_value = mPointlistCat[rowIndex].Material_value;
					string footprint = mPointlistCat[rowIndex].Footprint;
					for (int k = 0; k < mUSR3List.Count; k++)
					{
						BindingList<ChipBoardElement> mPointlist = mUSR3List[k].mPointlist;
						if (mPointlist == null)
						{
							continue;
						}
						for (int l = 0; l < mPointlist.Count; l++)
						{
							if (mPointlist[l].Material_value == material_value && mPointlist[l].Footprint == footprint)
							{
								switch (columnIndex2)
								{
								case 0:
									mPointlist[l].Material_value = form_Fill.get_string();
									break;
								case 1:
									mPointlist[l].Footprint = form_Fill.get_string();
									break;
								}
							}
						}
						BindingList<ChipCategoryElement> bindingList = mUSR3List[k].mPointlistCat;
						if (bindingList == null)
						{
							continue;
						}
						for (int m = 0; m < bindingList.Count; m++)
						{
							if (bindingList[m].Material_value == material_value && bindingList[m].Footprint == footprint)
							{
								switch (columnIndex2)
								{
								case 0:
									bindingList[m].Material_value = form_Fill.get_string();
									break;
								case 1:
									bindingList[m].Footprint = form_Fill.get_string();
									break;
								}
							}
						}
					}
					dataGridView_pcbcat.SelectedCells[j].Value = form_Fill.get_string();
					switch (columnIndex2)
					{
					case 0:
						mPointlistCat[rowIndex].Material_value = form_Fill.get_string();
						break;
					case 1:
						mPointlistCat[rowIndex].Footprint = form_Fill.get_string();
						break;
					}
					continue;
				}
				int rowIndex2 = dataGridView_pcbcat.SelectedCells[j].RowIndex;
				string material_value2 = mPointlistCat[rowIndex2].Material_value;
				string footprint2 = mPointlistCat[rowIndex2].Footprint;
				float @float = form_Fill.get_float();
				int @int = form_Fill.get_int();
				for (int n = 0; n < mUSR3List.Count; n++)
				{
					BindingList<ChipCategoryElement> bindingList2 = mUSR3List[n].mPointlistCat;
					if (bindingList2 == null)
					{
						continue;
					}
					for (int num2 = 0; num2 < bindingList2.Count; num2++)
					{
						if (bindingList2[num2].Material_value == material_value2 && bindingList2[num2].Footprint == footprint2)
						{
							switch (columnIndex2)
							{
							case 8:
								bindingList2[num2].Delta = @float;
								break;
							case 15:
								bindingList2[num2].Lenght = @float;
								break;
							case 16:
								bindingList2[num2].Width = @float;
								break;
							case 17:
								bindingList2[num2].Height = @float;
								break;
							case 13:
								bindingList2[num2].scan_r = @int;
								break;
							case 14:
								bindingList2[num2].threshold = @int;
								break;
							case 19:
								bindingList2[num2].collectdelta = @float;
								break;
							case 20:
								bindingList2[num2].pik_h_offset = @float;
								break;
							case 24:
								bindingList2[num2].mnt_h_offset = @float;
								break;
							case 21:
								bindingList2[num2].zup_speed = @int;
								break;
							case 22:
								bindingList2[num2].zdown_speed = @int;
								break;
							case 23:
								bindingList2[num2].zpik_delay = @int;
								break;
							case 25:
								bindingList2[num2].zmnt_up_speed = @int;
								break;
							case 26:
								bindingList2[num2].zmnt_down_speed = @int;
								break;
							case 27:
								bindingList2[num2].zmnt_delay = @int;
								break;
							}
						}
					}
					dataGridView_pcbcat.SelectedCells[j].Value = ((text == "float") ? @float : ((float)@int));
				}
			}
			if ((columnIndex2 == 0 || columnIndex2 == 1) && mPointlistCat.Count > 1)
			{
				bool flag = false;
				for (int num3 = 0; num3 < mPointlistCat.Count - 1; num3++)
				{
					for (int num4 = num3 + 1; num4 < mPointlistCat.Count; num4++)
					{
						if (mPointlistCat[num3].Material_value == mPointlistCat[num4].Material_value && mPointlistCat[num3].Footprint == mPointlistCat[num4].Footprint)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					pcblist_to_cat();
				}
			}
			if (columnIndex2 != 17 || MainForm0.CmMessageBox("是否将元件厚度同步到相应的料站参数，并更新贴装高度？", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			StackElement[][] stacktab = USR2.mStackLib.stacktab;
			int[] array = HW.mStackNum[MainForm0.mFn];
			string text2 = "已完成：";
			for (int num5 = 0; num5 < count2; num5++)
			{
				int rowIndex3 = dataGridView_pcbcat.SelectedCells[num5].RowIndex;
				ProviderType providerType = MainForm0.common_get_providertype(mPointlistCat[rowIndex3].Feedertype);
				if (providerType >= ProviderType.Num)
				{
					continue;
				}
				for (int num6 = 0; num6 < mPointlistCat[rowIndex3].MultiFeeders; num6++)
				{
					int num7 = mPointlistCat[rowIndex3].feeder_no[num6] - 1;
					if (num7 >= 0 && num7 < array[(int)providerType])
					{
						float num8 = mPointlistCat[rowIndex3].Height - stacktab[(int)providerType][num7].height;
						stacktab[(int)providerType][num7].height = mPointlistCat[rowIndex3].Height;
						for (int num9 = 0; num9 < HW.mZnNum[MainForm0.mFn]; num9++)
						{
							float num10 = MainForm0.format_H_to_Hmm(stacktab[(int)providerType][num7].mZnData[num9].Mnt.Height);
							stacktab[(int)providerType][num7].mZnData[num9].Mnt.Height = MainForm0.format_Hmm_to_H(num10 + num8);
						}
						text2 = text2 + STR.PROVIDER_STR[(int)providerType][mLanguage] + (num7 + 1) + " ";
					}
				}
			}
			text2 += "元件厚度和贴装高度的更新，请到料站参数里查询！";
			MainForm0.CmMessageBox(text2, MessageBoxButtons.OK);
		}

		public bool pcblist_to_cat()
		{
			bool result = false;
			bool flag = false;
			if (mPointlistCat == null)
			{
				mPointlistCat = new BindingList<ChipCategoryElement>();
			}
			mPointlistCat.Clear();
			for (int i = 0; i < mUSR3List.Count; i++)
			{
				USR3_DATA uSR3_DATA = mUSR3List[i];
				if (uSR3_DATA == null || uSR3_DATA.mPointlist == null)
				{
					continue;
				}
				if (uSR3_DATA.mPointlistCat == null)
				{
					uSR3_DATA.mPointlistCat = new BindingList<ChipCategoryElement>();
				}
				uSR3_DATA.mPointlistCat.Clear();
				for (int j = 0; j < uSR3_DATA.mPointlist.Count; j++)
				{
					bool flag2 = false;
					for (int k = 0; k < uSR3_DATA.mPointlistCat.Count; k++)
					{
						if (!(uSR3_DATA.mPointlist[j].Material_value == uSR3_DATA.mPointlistCat[k].Material_value) || !(uSR3_DATA.mPointlist[j].Footprint == uSR3_DATA.mPointlistCat[k].Footprint))
						{
							continue;
						}
						uSR3_DATA.mPointlistCat[k].Count++;
						if (uSR3_DATA.mPointlist[j].Feedertype != uSR3_DATA.mPointlistCat[k].Feedertype)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Feedertype = FeederType.N_A;
						}
						if (uSR3_DATA.mPointlist[j].Nozzletype != uSR3_DATA.mPointlistCat[k].Nozzletype0)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Nozzletype0 = (uSR3_DATA.mPointlistCat[k].Nozzletype1 = -1);
						}
						if (uSR3_DATA.mPointlist[j].Cameratype != uSR3_DATA.mPointlistCat[k].Cameratype)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Cameratype = CameraType.N_A;
						}
						if (uSR3_DATA.mPointlist[j].Visualtype != uSR3_DATA.mPointlistCat[k].Visualtype)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Visualtype = VisualType.N_A;
						}
						if (uSR3_DATA.mPointlist[j].Looptype != uSR3_DATA.mPointlistCat[k].Looptype)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Looptype = LoopType.N_A;
						}
						if (uSR3_DATA.mPointlist[j].sampik_delta != uSR3_DATA.mPointlistCat[k].Delta)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Delta = 0.5f;
						}
						if (uSR3_DATA.mPointlist[j].scanR != uSR3_DATA.mPointlistCat[k].scan_r)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].scan_r = 0f;
						}
						if (uSR3_DATA.mPointlist[j].threshold != uSR3_DATA.mPointlistCat[k].threshold)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].threshold = 0;
						}
						if (uSR3_DATA.mPointlist[j].length != uSR3_DATA.mPointlistCat[k].Lenght)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Lenght = 0f;
						}
						if (uSR3_DATA.mPointlist[j].width != uSR3_DATA.mPointlistCat[k].Width)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Width = 0f;
						}
						if (uSR3_DATA.mPointlist[j].height != uSR3_DATA.mPointlistCat[k].Height)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].Height = 0f;
						}
						if (uSR3_DATA.mPointlist[j].is_collect != uSR3_DATA.mPointlistCat[k].is_collect)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].is_collect = false;
						}
						if (uSR3_DATA.mPointlist[j].collectdelta != uSR3_DATA.mPointlistCat[k].collectdelta)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].collectdelta = 30f;
						}
						if (uSR3_DATA.mPointlist[j].pik_h_offset != uSR3_DATA.mPointlistCat[k].pik_h_offset)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].pik_h_offset = 0.5f;
						}
						if (uSR3_DATA.mPointlist[j].mnt_h_offset != uSR3_DATA.mPointlistCat[k].mnt_h_offset)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].mnt_h_offset = 0.5f;
						}
						if (uSR3_DATA.mPointlist[j].zup_speed != uSR3_DATA.mPointlistCat[k].zup_speed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].zup_speed = 0;
						}
						if (uSR3_DATA.mPointlist[j].zdown_speed != uSR3_DATA.mPointlistCat[k].zdown_speed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].zdown_speed = 0;
						}
						if (uSR3_DATA.mPointlist[j].zpik_delay != uSR3_DATA.mPointlistCat[k].zpik_delay)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].zpik_delay = 0f;
						}
						if (uSR3_DATA.mPointlist[j].zmnt_up_speed != uSR3_DATA.mPointlistCat[k].zmnt_up_speed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].zmnt_up_speed = 0;
						}
						if (uSR3_DATA.mPointlist[j].zmnt_down_speed != uSR3_DATA.mPointlistCat[k].zmnt_down_speed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].zmnt_down_speed = 0;
						}
						if (uSR3_DATA.mPointlist[j].zmnt_delay != uSR3_DATA.mPointlistCat[k].zmnt_delay)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].zmnt_delay = 0f;
						}
						if (uSR3_DATA.mPointlist[j].IsLowSpeed != uSR3_DATA.mPointlistCat[k].IsLowSpeed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].IsLowSpeed = false;
						}
						if (uSR3_DATA.mPointlist[j].is_high != uSR3_DATA.mPointlistCat[k].is_high)
						{
							result = true;
							uSR3_DATA.mPointlistCat[k].is_high = false;
						}
						bool flag3 = false;
						for (int l = 0; l < uSR3_DATA.mPointlistCat[k].MultiFeeders; l++)
						{
							if (uSR3_DATA.mPointlist[j].Stack_no == uSR3_DATA.mPointlistCat[k].feeder_no[l])
							{
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							if (uSR3_DATA.mPointlistCat[k].MultiFeeders < HW.mMaxMultiFeederNum[MainForm0.mFn])
							{
								uSR3_DATA.mPointlistCat[k].feeder_no[uSR3_DATA.mPointlistCat[k].MultiFeeders] = uSR3_DATA.mPointlist[j].Stack_no;
								uSR3_DATA.mPointlistCat[k].MultiFeeders++;
							}
							else
							{
								flag = true;
							}
						}
						flag2 = true;
					}
					if (!flag2)
					{
						ChipCategoryElement chipCategoryElement = new ChipCategoryElement(mLanguage);
						MainForm0.common_copy_emt_to_cat(chipCategoryElement, uSR3_DATA.mPointlist[j]);
						chipCategoryElement.Count = 1;
						chipCategoryElement.MultiFeeders = 1;
						chipCategoryElement.feeder_no[0] = uSR3_DATA.mPointlist[j].Stack_no;
						uSR3_DATA.mPointlistCat.Add(chipCategoryElement);
					}
					flag2 = false;
					for (int m = 0; m < mPointlistCat.Count; m++)
					{
						if (!(uSR3_DATA.mPointlist[j].Material_value == mPointlistCat[m].Material_value) || !(uSR3_DATA.mPointlist[j].Footprint == mPointlistCat[m].Footprint))
						{
							continue;
						}
						mPointlistCat[m].Count++;
						if (uSR3_DATA.mPointlist[j].Feedertype != mPointlistCat[m].Feedertype)
						{
							result = true;
							mPointlistCat[m].Feedertype = FeederType.N_A;
						}
						if (uSR3_DATA.mPointlist[j].Nozzletype != mPointlistCat[m].Nozzletype0)
						{
							result = true;
							mPointlistCat[m].Nozzletype0 = (uSR3_DATA.mPointlistCat[m].Nozzletype1 = -1);
						}
						if (uSR3_DATA.mPointlist[j].Cameratype != mPointlistCat[m].Cameratype)
						{
							result = true;
							mPointlistCat[m].Cameratype = CameraType.N_A;
						}
						if (uSR3_DATA.mPointlist[j].Visualtype != mPointlistCat[m].Visualtype)
						{
							result = true;
							mPointlistCat[m].Visualtype = VisualType.N_A;
						}
						if (uSR3_DATA.mPointlist[j].Looptype != mPointlistCat[m].Looptype)
						{
							result = true;
							mPointlistCat[m].Looptype = LoopType.N_A;
						}
						if (uSR3_DATA.mPointlist[j].sampik_delta != mPointlistCat[m].Delta)
						{
							result = true;
							mPointlistCat[m].Delta = 0.5f;
						}
						if (uSR3_DATA.mPointlist[j].scanR != mPointlistCat[m].scan_r)
						{
							result = true;
							mPointlistCat[m].scan_r = 0f;
						}
						if (uSR3_DATA.mPointlist[j].threshold != mPointlistCat[m].threshold)
						{
							result = true;
							mPointlistCat[m].threshold = 0;
						}
						if (uSR3_DATA.mPointlist[j].length != mPointlistCat[m].Lenght)
						{
							result = true;
							mPointlistCat[m].Lenght = 0f;
						}
						if (uSR3_DATA.mPointlist[j].width != mPointlistCat[m].Width)
						{
							result = true;
							mPointlistCat[m].Width = 0f;
						}
						if (uSR3_DATA.mPointlist[j].height != mPointlistCat[m].Height)
						{
							result = true;
							mPointlistCat[m].Height = 0f;
						}
						if (uSR3_DATA.mPointlist[j].is_collect != mPointlistCat[m].is_collect)
						{
							result = true;
							mPointlistCat[m].is_collect = false;
						}
						if (uSR3_DATA.mPointlist[j].collectdelta != mPointlistCat[m].collectdelta)
						{
							result = true;
							mPointlistCat[m].collectdelta = 30f;
						}
						if (uSR3_DATA.mPointlist[j].pik_h_offset != mPointlistCat[m].pik_h_offset)
						{
							result = true;
							mPointlistCat[m].pik_h_offset = 1f;
						}
						if (uSR3_DATA.mPointlist[j].mnt_h_offset != mPointlistCat[m].mnt_h_offset)
						{
							result = true;
							mPointlistCat[m].mnt_h_offset = 1f;
						}
						if (uSR3_DATA.mPointlist[j].zup_speed != mPointlistCat[m].zup_speed)
						{
							result = true;
							mPointlistCat[m].zup_speed = 0;
						}
						if (uSR3_DATA.mPointlist[j].zdown_speed != mPointlistCat[m].zdown_speed)
						{
							result = true;
							mPointlistCat[m].zdown_speed = 0;
						}
						if (uSR3_DATA.mPointlist[j].zpik_delay != mPointlistCat[m].zpik_delay)
						{
							result = true;
							mPointlistCat[m].zpik_delay = 0f;
						}
						if (uSR3_DATA.mPointlist[j].zmnt_up_speed != mPointlistCat[m].zmnt_up_speed)
						{
							result = true;
							mPointlistCat[m].zmnt_up_speed = 0;
						}
						if (uSR3_DATA.mPointlist[j].zmnt_down_speed != mPointlistCat[m].zmnt_down_speed)
						{
							result = true;
							mPointlistCat[m].zmnt_down_speed = 0;
						}
						if (uSR3_DATA.mPointlist[j].zmnt_delay != mPointlistCat[m].zmnt_delay)
						{
							result = true;
							mPointlistCat[m].zmnt_delay = 0f;
						}
						if (uSR3_DATA.mPointlist[j].IsLowSpeed != mPointlistCat[m].IsLowSpeed)
						{
							result = true;
							mPointlistCat[m].IsLowSpeed = false;
						}
						if (uSR3_DATA.mPointlist[j].is_high != mPointlistCat[m].is_high)
						{
							result = true;
							mPointlistCat[m].is_high = false;
						}
						bool flag4 = false;
						for (int n = 0; n < mPointlistCat[m].MultiFeeders; n++)
						{
							if (uSR3_DATA.mPointlist[j].Stack_no == mPointlistCat[m].feeder_no[n])
							{
								flag4 = true;
								break;
							}
						}
						if (!flag4)
						{
							if (mPointlistCat[m].MultiFeeders < HW.mMaxMultiFeederNum[MainForm0.mFn])
							{
								mPointlistCat[m].feeder_no[mPointlistCat[m].MultiFeeders] = uSR3_DATA.mPointlist[j].Stack_no;
								mPointlistCat[m].MultiFeeders++;
							}
							else
							{
								flag = true;
							}
						}
						flag2 = true;
					}
					if (!flag2)
					{
						ChipCategoryElement chipCategoryElement2 = new ChipCategoryElement(mLanguage);
						MainForm0.common_copy_emt_to_cat(chipCategoryElement2, uSR3_DATA.mPointlist[j]);
						chipCategoryElement2.Count = 1;
						chipCategoryElement2.feeder_no[0] = uSR3_DATA.mPointlist[j].Stack_no;
						mPointlistCat.Add(chipCategoryElement2);
					}
				}
			}
			MainForm0.pcbcat_order(PcatHead.FOOTPRINT, SortOrder.Ascending, mPointlistCat);
			if (flag)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "multi feeder counts is our of range: " : ("一些多组供料的feeder数量太多，已超过最大值：" + HW.mMaxMultiFeederNum.ToString()));
			}
			return result;
		}

		private void dataGridView_pcbcat_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (e.RowIndex == -1 && e.ColumnIndex >= 0)
				{
					dataGridView_pcbcat.ClearSelection();
					for (int i = 0; i < dataGridView_pcbcat.RowCount; i++)
					{
						dataGridView_pcbcat.EndEdit();
						dataGridView_pcbcat.Rows[i].Cells[e.ColumnIndex].Selected = true;
					}
				}
			}
			else
			{
				if (e.Button != MouseButtons.Right || e.RowIndex < 0)
				{
					return;
				}
				int count = dataGridView_pcbcat.SelectedCells.Count;
				if (count <= 0)
				{
					return;
				}
				int columnIndex = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
				if (columnIndex == 10 || columnIndex == 11)
				{
					for (int j = 0; j < count; j++)
					{
						int columnIndex2 = dataGridView_pcbcat.SelectedCells[j].ColumnIndex;
						if (columnIndex2 != 10 && columnIndex2 != 11)
						{
							return;
						}
					}
				}
				else
				{
					BindingList<int> bindingList = new BindingList<int>();
					bindingList.Add(columnIndex);
					for (int k = 0; k < count; k++)
					{
						int num = 0;
						for (num = 0; num < bindingList.Count && dataGridView_pcbcat.SelectedCells[k].ColumnIndex != bindingList[num]; num++)
						{
						}
						if (num == bindingList.Count)
						{
							bindingList.Add(dataGridView_pcbcat.SelectedCells[k].ColumnIndex);
						}
					}
					if (bindingList.Count != 1 && (bindingList.Count != 2 || ((bindingList[0] != 6 || bindingList[1] != 7) && (bindingList[0] != 7 || bindingList[1] != 6))))
					{
						return;
					}
				}
				switch (columnIndex)
				{
				case 1:
				{
					contextMenuStrip_pcbcat_cell.Items.Clear();
					ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem((mLanguage == 2) ? "Manual Edit" : "手动修改");
					toolStripMenuItem5.Click += fill_catcells_manual_click;
					ToolStripSeparator toolStripSeparator3 = new ToolStripSeparator();
					ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem((mLanguage == 2) ? "From Footprint Lib (Auto)" : "自动-来自封装库");
					toolStripMenuItem6.Click += ts_from_footprint_lib_auto_click;
					ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem((mLanguage == 2) ? "From Footprint Lib (Manual)" : "手动-来自封装库");
					toolStripMenuItem7.Click += ts_from_footprint_lib_manual_click;
					contextMenuStrip_pcbcat_cell.Items.AddRange(new ToolStripItem[4] { toolStripMenuItem5, toolStripSeparator3, toolStripMenuItem6, toolStripMenuItem7 });
					contextMenuStrip_pcbcat_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
					break;
				}
				default:
					switch (columnIndex)
					{
					case 1:
					case 8:
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:
					case 19:
					case 20:
					case 21:
					case 22:
					case 23:
					case 24:
					case 25:
					case 26:
					case 27:
						break;
					case 12:
					case 18:
					case 28:
					{
						contextMenuStrip_pcbcat_cell.Items.Clear();
						ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem((mLanguage == 2) ? "Check" : "批量选中");
						toolStripMenuItem2.Tag = 1;
						toolStripMenuItem2.Click += fill_checkbox_manual_click;
						ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem((mLanguage == 2) ? "UnCheck" : "批量取消");
						toolStripMenuItem3.Tag = 0;
						toolStripMenuItem3.Click += fill_checkbox_manual_click;
						contextMenuStrip_pcbcat_cell.Items.AddRange(new ToolStripItem[2] { toolStripMenuItem2, toolStripMenuItem3 });
						contextMenuStrip_pcbcat_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
						return;
					}
					case 4:
					case 5:
					{
						contextMenuStrip_pcbcat_cell.Items.Clear();
						ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem((mLanguage == 2) ? "Manual Edit" : "修改设置");
						toolStripMenuItem.Click += fill_feedernos_manual_click;
						ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
						contextMenuStrip_pcbcat_cell.Items.AddRange(new ToolStripItem[2] { toolStripMenuItem, toolStripSeparator });
						contextMenuStrip_pcbcat_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
						return;
					}
					case 3:
					{
						contextMenuStrip_pcbcat_cell.Items.Clear();
						FeederType[] array = new FeederType[10]
						{
							FeederType.CL8_2_0201,
							FeederType.CL8_2,
							FeederType.CL8_4,
							FeederType.CL12,
							FeederType.CL16,
							FeederType.CL24,
							FeederType.CL32,
							FeederType.CL44,
							FeederType.Plate,
							FeederType.Vibra
						};
						ToolStripMenuItem[] array2 = new ToolStripMenuItem[10];
						for (int num2 = 0; num2 < 10; num2++)
						{
							array2[num2] = new ToolStripMenuItem(STR.FEEDER_STR[(int)array[num2]][mLanguage]);
							array2[num2].Click += pcbcat_fill_cells_feeder_click;
							array2[num2].Tag = array[num2];
						}
						contextMenuStrip_pcbcat_cell.Items.AddRange(array2);
						contextMenuStrip_pcbcat_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
						return;
					}
					case 6:
					case 7:
					{
						contextMenuStrip_pcbcat_cell.Items.Clear();
						string[] array3 = new string[10] { "500", "501", "502", "503", "504", "505", "506", "507", "508", "509" };
						ToolStripMenuItem[] array4 = new ToolStripMenuItem[10];
						for (int num3 = 0; num3 < 10; num3++)
						{
							array4[num3] = new ToolStripMenuItem(array3[num3]);
							array4[num3].Click += pcbcat_fill_cells_nozzle_click;
							array4[num3].Tag = num3;
						}
						contextMenuStrip_pcbcat_cell.Items.AddRange(array4);
						contextMenuStrip_pcbcat_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
						return;
					}
					case 9:
					{
						contextMenuStrip_pcbcat_cell.Items.Clear();
						CameraType[] array5 = new CameraType[3]
						{
							CameraType.Fast,
							CameraType.High,
							CameraType.None
						};
						ToolStripMenuItem[] array6 = new ToolStripMenuItem[3];
						for (int num4 = 0; num4 < 3; num4++)
						{
							array6[num4] = new ToolStripMenuItem(STR.CAMERA_STR[(int)array5[num4]][mLanguage]);
							array6[num4].Click += pcbcat_fill_cells_camera_click;
							array6[num4].Tag = array5[num4];
						}
						contextMenuStrip_pcbcat_cell.Items.AddRange(array6);
						contextMenuStrip_pcbcat_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
						return;
					}
					case 10:
					case 11:
					{
						int rowIndex = dataGridView_pcbcat.SelectedCells[0].RowIndex;
						string str = (string)dataGridView_pcbcat.Rows[rowIndex].Cells[10].Value;
						string str2 = (string)dataGridView_pcbcat.Rows[rowIndex].Cells[11].Value;
						VisualType vistype = MainForm0.common_get_visual_from_str(str);
						LoopType looptype = MainForm0.common_get_loop_from_str(str2);
						Form_VisualTab form_VisualTab = new Form_VisualTab(vistype, looptype);
						if (form_VisualTab.ShowDialog() != DialogResult.OK)
						{
							return;
						}
						VisualType visualtype = form_VisualTab.get_visualtype();
						LoopType looptype2 = form_VisualTab.get_looptype();
						for (int l = 0; l < count; l++)
						{
							dataGridView_pcbcat.SelectedCells[l].Value = STR.VISUAL_STR[(int)visualtype][mLanguage];
							int rowIndex2 = dataGridView_pcbcat.SelectedCells[l].RowIndex;
							mPointlistCat[rowIndex2].Visualtype = visualtype;
							mPointlistCat[rowIndex2].Looptype = looptype2;
							for (int m = 0; m < mUSR3List.Count; m++)
							{
								USR3_DATA uSR3_DATA = mUSR3List[m];
								for (int n = 0; n < uSR3_DATA.mPointlistCat.Count; n++)
								{
									if (uSR3_DATA.mPointlistCat[n].Material_value == mPointlistCat[rowIndex2].Material_value && uSR3_DATA.mPointlistCat[n].Footprint == mPointlistCat[rowIndex2].Footprint)
									{
										uSR3_DATA.mPointlistCat[n].Visualtype = visualtype;
										uSR3_DATA.mPointlistCat[n].Looptype = looptype2;
									}
								}
							}
						}
						dataGridView_pcbcat.Refresh();
						return;
					}
					default:
						return;
					}
					goto case 0;
				case 0:
				{
					contextMenuStrip_pcbcat_cell.Items.Clear();
					ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem((mLanguage == 2) ? "Manual Edit" : "手动修改");
					toolStripMenuItem4.Click += fill_catcells_manual_click;
					ToolStripSeparator toolStripSeparator2 = new ToolStripSeparator();
					contextMenuStrip_pcbcat_cell.Items.AddRange(new ToolStripItem[2] { toolStripMenuItem4, toolStripSeparator2 });
					contextMenuStrip_pcbcat_cell.Show(Control.MousePosition.X, Control.MousePosition.Y);
					break;
				}
				}
			}
		}

		private void pcbcat_fill_cells_nozzle_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			int count = dataGridView_pcbcat.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			_ = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
			for (int i = 0; i < count; i++)
			{
				dataGridView_pcbcat.SelectedCells[i].Value = "50" + (int)toolStripMenuItem.Tag;
				int rowIndex = dataGridView_pcbcat.SelectedCells[i].RowIndex;
				int columnIndex = dataGridView_pcbcat.SelectedCells[i].ColumnIndex;
				switch (columnIndex)
				{
				case 6:
					mPointlistCat[rowIndex].Nozzletype0 = (int)toolStripMenuItem.Tag;
					break;
				case 7:
					mPointlistCat[rowIndex].Nozzletype1 = (int)toolStripMenuItem.Tag;
					break;
				}
				for (int j = 0; j < mUSR3List.Count; j++)
				{
					USR3_DATA uSR3_DATA = mUSR3List[j];
					for (int k = 0; k < uSR3_DATA.mPointlistCat.Count; k++)
					{
						if (uSR3_DATA.mPointlistCat[k].Material_value == mPointlistCat[rowIndex].Material_value && uSR3_DATA.mPointlistCat[k].Footprint == mPointlistCat[rowIndex].Footprint)
						{
							switch (columnIndex)
							{
							case 6:
								uSR3_DATA.mPointlistCat[k].Nozzletype0 = (int)toolStripMenuItem.Tag;
								break;
							case 7:
								uSR3_DATA.mPointlistCat[k].Nozzletype1 = (int)toolStripMenuItem.Tag;
								break;
							}
						}
					}
				}
			}
		}

		private void pcbcat_fill_cells_feeder_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			int count = dataGridView_pcbcat.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			_ = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
			for (int i = 0; i < count; i++)
			{
				dataGridView_pcbcat.SelectedCells[i].Value = STR.FEEDER_STR[(int)toolStripMenuItem.Tag][mLanguage];
				int rowIndex = dataGridView_pcbcat.SelectedCells[i].RowIndex;
				mPointlistCat[rowIndex].Feedertype = (FeederType)toolStripMenuItem.Tag;
				for (int j = 0; j < mUSR3List.Count; j++)
				{
					USR3_DATA uSR3_DATA = mUSR3List[j];
					for (int k = 0; k < uSR3_DATA.mPointlistCat.Count; k++)
					{
						if (uSR3_DATA.mPointlistCat[k].Material_value == mPointlistCat[rowIndex].Material_value && uSR3_DATA.mPointlistCat[k].Footprint == mPointlistCat[rowIndex].Footprint)
						{
							uSR3_DATA.mPointlistCat[k].Feedertype = (FeederType)toolStripMenuItem.Tag;
						}
					}
				}
			}
		}

		private void pcbcat_fill_cells_camera_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			int count = dataGridView_pcbcat.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			_ = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
			for (int i = 0; i < count; i++)
			{
				dataGridView_pcbcat.SelectedCells[i].Value = STR.CAMERA_STR[(int)toolStripMenuItem.Tag][mLanguage];
				int rowIndex = dataGridView_pcbcat.SelectedCells[i].RowIndex;
				mPointlistCat[rowIndex].Cameratype = (CameraType)toolStripMenuItem.Tag;
				for (int j = 0; j < mUSR3List.Count; j++)
				{
					USR3_DATA uSR3_DATA = mUSR3List[j];
					for (int k = 0; k < uSR3_DATA.mPointlistCat.Count; k++)
					{
						if (uSR3_DATA.mPointlistCat[k].Material_value == mPointlistCat[rowIndex].Material_value && uSR3_DATA.mPointlistCat[k].Footprint == mPointlistCat[rowIndex].Footprint)
						{
							uSR3_DATA.mPointlistCat[k].Cameratype = (CameraType)toolStripMenuItem.Tag;
						}
					}
				}
			}
		}

		private void pcbcat_fill_cells_visual_click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			int count = dataGridView_pcbcat.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			_ = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
			for (int i = 0; i < count; i++)
			{
				dataGridView_pcbcat.SelectedCells[i].Value = STR.VISUAL_STR[(int)toolStripMenuItem.Tag][mLanguage];
				int rowIndex = dataGridView_pcbcat.SelectedCells[i].RowIndex;
				mPointlistCat[rowIndex].Visualtype = (VisualType)toolStripMenuItem.Tag;
				for (int j = 0; j < mUSR3List.Count; j++)
				{
					USR3_DATA uSR3_DATA = mUSR3List[j];
					for (int k = 0; k < uSR3_DATA.mPointlistCat.Count; k++)
					{
						if (uSR3_DATA.mPointlistCat[k].Material_value == mPointlistCat[rowIndex].Material_value && uSR3_DATA.mPointlistCat[k].Footprint == mPointlistCat[rowIndex].Footprint)
						{
							uSR3_DATA.mPointlistCat[k].Visualtype = (VisualType)toolStripMenuItem.Tag;
						}
					}
				}
			}
		}

		private void dataGridView_pcbcat_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			dataGridView_pcbcat.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;
			switch (dataGridView_pcbcat.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
			{
			case SortOrder.None:
			case SortOrder.Ascending:
				MainForm0.pcbcat_order((PcatHead)e.ColumnIndex, SortOrder.Descending, mPointlistCat);
				if (dataGridView_pcbcat.Columns.Count > 0)
				{
					dataGridView_pcbcat.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				}
				break;
			case SortOrder.Descending:
				MainForm0.pcbcat_order((PcatHead)e.ColumnIndex, SortOrder.Ascending, mPointlistCat);
				if (dataGridView_pcbcat.Columns.Count > 0)
				{
					dataGridView_pcbcat.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				break;
			}
		}

		private void button_Delete_Click(object sender, EventArgs e)
		{
			if (dataGridView_pcbcat.SelectedRows.Count <= 0)
			{
				return;
			}
			string text = "You are going to delete " + mPointlistCat[dataGridView_pcbcat.SelectedRows[dataGridView_pcbcat.SelectedRows.Count - 1].Index].Material_value + " etc. " + dataGridView_pcbcat.SelectedRows.Count + "items";
			string text2 = "您将要删除元件" + mPointlistCat[dataGridView_pcbcat.SelectedRows[dataGridView_pcbcat.SelectedRows.Count - 1].Index].Material_value + "等" + dataGridView_pcbcat.SelectedRows.Count + "组数据";
			if (MainForm0.CmMessageBox((mLanguage == 2) ? text : text2, MessageBoxButtons.OKCancel) != DialogResult.OK)
			{
				return;
			}
			int count = dataGridView_pcbcat.SelectedRows.Count;
			BindingList<ChipCategoryElement> bindingList = new BindingList<ChipCategoryElement>();
			BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
			for (int i = 0; i < count; i++)
			{
				bindingList.Add(mPointlistCat[dataGridView_pcbcat.SelectedRows[i].Index]);
			}
			for (int j = 0; j < mUSR3List.Count; j++)
			{
				BindingList<ChipBoardElement> mPointlist = mUSR3List[j].mPointlist;
				if (mPointlist == null)
				{
					continue;
				}
				for (int k = 0; k < bindingList.Count; k++)
				{
					mPointlistCat.Remove(bindingList[k]);
					for (int l = 0; l < mPointlist.Count; l++)
					{
						if (mPointlist[l].Material_value == bindingList[k].Material_value && mPointlist[l].Footprint == bindingList[k].Footprint)
						{
							bindingList2.Add(mPointlist[l]);
						}
					}
				}
				for (int m = 0; m < bindingList2.Count; m++)
				{
					mPointlist.Remove(bindingList2[m]);
				}
			}
		}

		private void Form_PcbEdit_Cat_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			bool flag = false;
			for (int i = 0; i < mPointlistCat.Count; i++)
			{
				if (mPointlistCat[i].Feedertype == FeederType.Vibra)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				Form_BoxSel form_BoxSel = new Form_BoxSel("振动飞达占用的普通飞达料位需要手动禁用", "料位禁用", "继续优化", "");
				while (true)
				{
					switch (form_BoxSel.ShowDialog())
					{
					case DialogResult.OK:
						goto IL_0058;
					default:
						return;
					case DialogResult.Yes:
						break;
					}
					break;
					IL_0058:
					Form_FeederDisable form_FeederDisable = new Form_FeederDisable(mLanguage, isSlotBrkn, mNozzleEnable);
					form_FeederDisable.ShowDialog();
				}
			}
			bool flag2 = false;
			for (int j = 0; j < mPointlistCat.Count; j++)
			{
				if (mPointlistCat[j].Feedertype == FeederType.Plate || mPointlistCat[j].Feedertype == FeederType.Vibra)
				{
					continue;
				}
				int num = 0;
				while (num < mPointlistCat[j].MultiFeeders)
				{
					if (mPointlistCat[j].feeder_no == null)
					{
						mPointlistCat[j].feeder_no = new int[4];
						for (int k = 0; k < 4; k++)
						{
							mPointlistCat[j].feeder_no[k] = 0;
						}
					}
					if (mPointlistCat[j].feeder_no[num] <= 0)
					{
						num++;
						continue;
					}
					goto IL_012a;
				}
				continue;
				IL_012a:
				flag2 = true;
				break;
			}
			if (flag2)
			{
				Form_optimizeNotice form_optimizeNotice = new Form_optimizeNotice(mLanguage);
				DialogResult dialogResult = form_optimizeNotice.ShowDialog();
				if ((dialogResult == DialogResult.Yes || dialogResult == DialogResult.No) && mPointlistCat_History != null)
				{
					mPointlistCat_History.Clear();
					for (int l = 0; l < mPointlistCat.Count; l++)
					{
						ChipCategoryElement chipCategoryElement = new ChipCategoryElement(mPointlistCat[l]);
						chipCategoryElement.mOptimizeResult = OptimizeResult.None;
						mPointlistCat_History.Add(chipCategoryElement);
					}
				}
				switch (dialogResult)
				{
				case DialogResult.Yes:
				{
					for (int num4 = 0; num4 < mPointlistCat.Count; num4++)
					{
						for (int num5 = 0; num5 < mPointlistCat[num4].MultiFeeders; num5++)
						{
							mPointlistCat[num4].feeder_no[num5] = 0;
						}
					}
					break;
				}
				case DialogResult.No:
				{
					bool flag3 = true;
					BindingList<int_2d> bindingList = new BindingList<int_2d>();
					for (int m = 0; m < mPointlistCat.Count; m++)
					{
						for (int n = 0; n < mPointlistCat[m].MultiFeeders; n++)
						{
							if (mPointlistCat[m].feeder_no[n] != 0)
							{
								int_2d item = new int_2d((int)MainForm0.common_get_providertype(mPointlistCat[m].Feedertype), mPointlistCat[m].feeder_no[n]);
								bindingList.Add(item);
							}
						}
					}
					if (bindingList.Count > 1)
					{
						for (int num2 = 0; num2 < bindingList.Count - 1; num2++)
						{
							for (int num3 = num2 + 1; num3 < bindingList.Count; num3++)
							{
								if (bindingList[num2].b == bindingList[num3].b && bindingList[num2].a == bindingList[num3].a)
								{
									flag3 = false;
									MainForm0.CmMessageBoxTop_Ok(STR.PROVIDER_STR[bindingList[num2].a][mLanguage] + bindingList[num2].b + "有重复指定，请重新指定!");
									break;
								}
							}
							if (!flag3)
							{
								break;
							}
						}
					}
					if (!flag3)
					{
						return;
					}
					break;
				}
				default:
					return;
				}
			}
			else if (mPointlistCat_History != null)
			{
				mPointlistCat_History.Clear();
				for (int num6 = 0; num6 < mPointlistCat.Count; num6++)
				{
					ChipCategoryElement chipCategoryElement2 = new ChipCategoryElement(mPointlistCat[num6]);
					chipCategoryElement2.mOptimizeResult = OptimizeResult.None;
					mPointlistCat_History.Add(chipCategoryElement2);
				}
			}
			base.DialogResult = DialogResult.OK;
		}

		private void button_preSlotDisable_Click(object sender, EventArgs e)
		{
			Form_FeederDisable form_FeederDisable = new Form_FeederDisable(mLanguage, isSlotBrkn, mNozzleEnable);
			form_FeederDisable.ShowDialog();
		}

		private void button_SaveExit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void dataGridView_pcbcat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			fill_feedernos_manual_click(sender, e);
		}

		private void fill_feedernos_manual_click(object sender, EventArgs e)
		{
			int count = dataGridView_pcbcat.SelectedCells.Count;
			if (count <= 0)
			{
				return;
			}
			int columnIndex = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
			if (count == 1)
			{
				int rowIndex = dataGridView_pcbcat.SelectedCells[0].RowIndex;
				if (rowIndex >= 0 && rowIndex < mPointlistCat.Count && (columnIndex == 5 || columnIndex == 4))
				{
					Form_MultiFeeder form_MultiFeeder = new Form_MultiFeeder(mLanguage, mPointlistCat[rowIndex], HW.mMaxMultiFeederNum[MainForm0.mFn], is_auto: false);
					if (form_MultiFeeder.ShowDialog() == DialogResult.OK)
					{
						dataGridView_pcbcat.Refresh();
					}
				}
			}
			else
			{
				if (count <= 1)
				{
					return;
				}
				if (columnIndex == 5)
				{
					ChipCategoryElement chipCategoryElement = new ChipCategoryElement(mLanguage);
					if (columnIndex != 5 && columnIndex != 4)
					{
						return;
					}
					Form_MultiFeeder form_MultiFeeder2 = new Form_MultiFeeder(mLanguage, chipCategoryElement, HW.mMaxMultiFeederNum[MainForm0.mFn], is_auto: true);
					if (form_MultiFeeder2.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					for (int i = 0; i < count; i++)
					{
						_ = dataGridView_pcbcat.SelectedCells[i].ColumnIndex;
						int rowIndex2 = dataGridView_pcbcat.SelectedCells[i].RowIndex;
						mPointlistCat[rowIndex2].MultiFeeders = chipCategoryElement.MultiFeeders;
						for (int j = 0; j < mPointlistCat[rowIndex2].MultiFeeders; j++)
						{
							mPointlistCat[rowIndex2].feeder_no[j] = 0;
						}
						for (int k = 0; k < mUSR3List.Count; k++)
						{
							USR3_DATA uSR3_DATA = mUSR3List[k];
							for (int l = 0; l < uSR3_DATA.mPointlistCat.Count; l++)
							{
								if (uSR3_DATA.mPointlistCat[l].Material_value == mPointlistCat[rowIndex2].Material_value && uSR3_DATA.mPointlistCat[l].Footprint == mPointlistCat[rowIndex2].Footprint)
								{
									uSR3_DATA.mPointlistCat[rowIndex2].MultiFeeders = chipCategoryElement.MultiFeeders;
									for (int m = 0; m < mPointlistCat[rowIndex2].MultiFeeders; m++)
									{
										uSR3_DATA.mPointlistCat[l].feeder_no[m] = 0;
									}
								}
							}
						}
					}
					dataGridView_pcbcat.Refresh();
				}
				else
				{
					if (MainForm0.CmMessageBox("批量修改料站号只能全部改成[自动]，是否继续？", MessageBoxButtons.YesNo) != DialogResult.Yes)
					{
						return;
					}
					for (int n = 0; n < count; n++)
					{
						int columnIndex2 = dataGridView_pcbcat.SelectedCells[n].ColumnIndex;
						int rowIndex3 = dataGridView_pcbcat.SelectedCells[n].RowIndex;
						if (rowIndex3 < 0 || rowIndex3 >= mPointlistCat.Count || columnIndex2 != 4)
						{
							continue;
						}
						for (int num = 0; num < mPointlistCat[rowIndex3].MultiFeeders; num++)
						{
							mPointlistCat[rowIndex3].feeder_no[num] = 0;
						}
						for (int num2 = 0; num2 < mUSR3List.Count; num2++)
						{
							USR3_DATA uSR3_DATA2 = mUSR3List[num2];
							for (int num3 = 0; num3 < uSR3_DATA2.mPointlistCat.Count; num3++)
							{
								if (uSR3_DATA2.mPointlistCat[num3].Material_value == mPointlistCat[rowIndex3].Material_value && uSR3_DATA2.mPointlistCat[num3].Footprint == mPointlistCat[rowIndex3].Footprint)
								{
									for (int num4 = 0; num4 < mPointlistCat[rowIndex3].MultiFeeders; num4++)
									{
										uSR3_DATA2.mPointlistCat[num3].feeder_no[num4] = 0;
									}
								}
							}
						}
					}
					dataGridView_pcbcat.Refresh();
				}
			}
		}

		private void button_updatefromFootprintLib_Click(object sender, EventArgs e)
		{
			auto_from_footprint_lib(0);
		}

		private void ts_from_footprint_lib_auto_click(object sender, EventArgs e)
		{
			auto_from_footprint_lib(1);
		}

		private void auto_from_footprint_lib(int select_mode)
		{
			if (MainForm0.mForm_LabPrintfoot != null && !MainForm0.mForm_LabPrintfoot.IsDisposed)
			{
				MainForm0.mForm_LabPrintfoot.Close();
				MainForm0.mForm_LabPrintfoot = null;
			}
			int num = ((select_mode == 0) ? mPointlistCat.Count : dataGridView_pcbcat.SelectedCells.Count);
			if (num < 1)
			{
				return;
			}
			string text = "是否将选中项目从封装全部自动更新?";
			string text2 = "Confirm to update all selected item from footprint lib?";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text2 : text, MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			MainForm0.common_waiting_start("来自封装库...", 10);
			int[][] array = new int[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = new int[3] { -1, -1, -1 };
			}
			for (int j = 0; j < num; j++)
			{
				if (array[j][0] != -1)
				{
					continue;
				}
				int num2 = ((select_mode == 0) ? j : dataGridView_pcbcat.SelectedCells[j].RowIndex);
				if (num2 < 0 || num2 >= mPointlistCat.Count)
				{
					continue;
				}
				string footprint = mPointlistCat[num2].Footprint;
				BindingList<int[]> bindingList = new BindingList<int[]>();
				if (MainForm0.FP_PATH.mFootprintLib_NameList == null || MainForm0.FP_PATH.mFootprintLib_NameList.Count <= 0)
				{
					return;
				}
				bool flag = false;
				for (int k = 0; k < MainForm0.FP_PATH.mFootprintLib_NameList.Count; k++)
				{
					USR_LIB uSR_LIB = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[k]);
					if (uSR_LIB == null || uSR_LIB.fpcatlist == null || uSR_LIB.fpcatlist.Count <= 0)
					{
						continue;
					}
					for (int l = 0; l < uSR_LIB.fpcatlist.Count; l++)
					{
						BindingList<FootPrint> footlist = uSR_LIB.fpcatlist[l].footlist;
						if (footlist == null || footlist.Count <= 0)
						{
							continue;
						}
						for (int m = 0; m < footlist.Count; m++)
						{
							if (MainForm0.is_match_footprint(footlist[m], footprint))
							{
								bindingList.Add(new int[3] { k, l, m });
								flag = true;
							}
							if (flag)
							{
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				int num3 = 0;
				if (bindingList.Count == 1)
				{
					num3 = 0;
				}
				else if (bindingList.Count > 1)
				{
					Form_LabPrintfoot_Conflict form_LabPrintfoot_Conflict = new Form_LabPrintfoot_Conflict(USR, footprint, bindingList);
					num3 = ((form_LabPrintfoot_Conflict.ShowDialog() != DialogResult.OK) ? (-1) : form_LabPrintfoot_Conflict.get_selectedindex());
				}
				else
				{
					num3 = -1;
				}
				for (int n = 0; n < num; n++)
				{
					int index = ((select_mode == 0) ? n : dataGridView_pcbcat.SelectedCells[n].RowIndex);
					if (footprint == mPointlistCat[index].Footprint)
					{
						if (num3 < 0)
						{
							array[n][0] = 0;
							array[n][1] = -1;
							array[n][2] = -1;
						}
						else
						{
							array[n][0] = bindingList[num3][0];
							array[n][1] = bindingList[num3][1];
							array[n][2] = bindingList[num3][2];
						}
					}
				}
			}
			BindingList<int> bindingList2 = new BindingList<int>();
			for (int num4 = 0; num4 < num; num4++)
			{
				if (array[num4][0] < 0 || array[num4][1] < 0 || array[num4][2] < 0)
				{
					continue;
				}
				USR_LIB uSR_LIB2 = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[array[num4][0]]);
				FootPrint footPrint = uSR_LIB2.fpcatlist[array[num4][1]].footlist[array[num4][2]];
				for (int num5 = num4; num5 < num; num5++)
				{
					int num6 = ((select_mode == 0) ? num5 : dataGridView_pcbcat.SelectedCells[num5].RowIndex);
					if (!MainForm0.is_match_footprint(footPrint, mPointlistCat[num6].Footprint))
					{
						continue;
					}
					for (int num7 = 0; num7 < mUSR3List.Count; num7++)
					{
						USR3_DATA uSR3_DATA = mUSR3List[num7];
						for (int num8 = 0; num8 < uSR3_DATA.mPointlist.Count; num8++)
						{
							if (uSR3_DATA.mPointlist[num8].Material_value == mPointlistCat[num6].Material_value && uSR3_DATA.mPointlist[num8].Footprint == mPointlistCat[num6].Footprint)
							{
								MainForm0.common_copy_footprint_to_emt(uSR3_DATA.mPointlist[num8], footPrint, 0);
							}
						}
					}
					for (int num9 = 0; num9 < mUSR3List.Count; num9++)
					{
						USR3_DATA uSR3_DATA2 = mUSR3List[num9];
						for (int num10 = 0; num10 < uSR3_DATA2.mPointlistCat.Count; num10++)
						{
							if (uSR3_DATA2.mPointlistCat[num10].Material_value == mPointlistCat[num6].Material_value && uSR3_DATA2.mPointlistCat[num10].Footprint == mPointlistCat[num6].Footprint)
							{
								MainForm0.common_copy_footprint_to_cat(uSR3_DATA2.mPointlistCat[num10], footPrint, 0);
							}
						}
					}
					MainForm0.common_copy_footprint_to_cat(mPointlistCat[num6], footPrint, 0);
					array[num5][0] = 0;
					array[num5][1] = -1;
					array[num5][2] = -1;
					bindingList2.Add(num6);
				}
			}
			for (int num11 = 0; num11 < bindingList2.Count; num11++)
			{
				dataGridView_pcbcat.Rows[bindingList2[num11]].Selected = true;
			}
			dataGridView_pcbcat.Refresh();
		}

		private void ts_from_footprint_lib_manual_click(object sender, EventArgs e)
		{
			if (MainForm0.mForm_LabPrintfoot != null && !MainForm0.mForm_LabPrintfoot.IsDisposed)
			{
				MainForm0.mForm_LabPrintfoot.Close();
				MainForm0.mForm_LabPrintfoot = null;
			}
			Form_LabPrintfoot form_LabPrintfoot = new Form_LabPrintfoot(MainForm0.USR_INIT, 1);
			form_LabPrintfoot.StartPosition = FormStartPosition.CenterParent;
			if (form_LabPrintfoot.ShowDialog() != DialogResult.OK || MainForm0.FP_PATH.mFootprintLib_NameList == null || MainForm0.FP_PATH.mFootprintLib_NameList.Count <= 0 || MainForm0.FP_PATH.mFootprintLib_Index < 0 || MainForm0.FP_PATH.mFootprintLib_Index > MainForm0.FP_PATH.mFootprintLib_NameList.Count)
			{
				return;
			}
			USR_LIB uSR_LIB = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[MainForm0.FP_PATH.mFootprintLib_Index]);
			if (uSR_LIB == null || uSR_LIB.fpcatlist == null || uSR_LIB.fpcatlist.Count <= 0 || uSR_LIB.fpcatindex < 0 || uSR_LIB.fpcatindex >= uSR_LIB.fpcatlist.Count)
			{
				return;
			}
			BindingList<FootPrint> footlist = uSR_LIB.fpcatlist[uSR_LIB.fpcatindex].footlist;
			int index = uSR_LIB.fpcatlist[uSR_LIB.fpcatindex].index;
			if (footlist == null || footlist.Count <= 0 || index < 0 || index >= footlist.Count)
			{
				return;
			}
			FootPrint footPrint = footlist[index];
			int count = dataGridView_pcbcat.SelectedCells.Count;
			if (count < 1)
			{
				return;
			}
			string text = "是否将选中项目全部更新为封装 " + footPrint.name + "?";
			string text2 = "Confirm to update all selected item to footprint:  " + footPrint.name + "?";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text2 : text, MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				int rowIndex = dataGridView_pcbcat.SelectedCells[i].RowIndex;
				if (rowIndex < 0 || rowIndex >= mPointlistCat.Count)
				{
					continue;
				}
				for (int j = 0; j < mUSR3List.Count; j++)
				{
					USR3_DATA uSR3_DATA = mUSR3List[j];
					for (int k = 0; k < uSR3_DATA.mPointlist.Count; k++)
					{
						if (uSR3_DATA.mPointlist[k].Material_value == mPointlistCat[rowIndex].Material_value && uSR3_DATA.mPointlist[k].Footprint == mPointlistCat[rowIndex].Footprint)
						{
							MainForm0.common_copy_footprint_to_emt(uSR3_DATA.mPointlist[k], footPrint, 0);
						}
					}
				}
				for (int l = 0; l < mUSR3List.Count; l++)
				{
					USR3_DATA uSR3_DATA2 = mUSR3List[l];
					for (int m = 0; m < uSR3_DATA2.mPointlistCat.Count; m++)
					{
						if (uSR3_DATA2.mPointlistCat[m].Material_value == mPointlistCat[rowIndex].Material_value && uSR3_DATA2.mPointlistCat[m].Footprint == mPointlistCat[rowIndex].Footprint)
						{
							MainForm0.common_copy_footprint_to_cat(uSR3_DATA2.mPointlistCat[m], footPrint, 0);
						}
					}
				}
				MainForm0.common_copy_footprint_to_cat(mPointlistCat[rowIndex], footPrint, 0);
			}
			dataGridView_pcbcat.Refresh();
		}

		private void fill_checkbox_manual_click(object sender, EventArgs e)
		{
			int num = (int)((ToolStripMenuItem)sender).Tag;
			int count = dataGridView_pcbcat.SelectedCells.Count;
			if (count < 1)
			{
				return;
			}
			BindingList<int> bindingList = new BindingList<int>();
			int columnIndex = dataGridView_pcbcat.SelectedCells[0].ColumnIndex;
			for (int i = 0; i < count; i++)
			{
				int rowIndex = dataGridView_pcbcat.SelectedCells[i].RowIndex;
				if (rowIndex >= 0 && rowIndex < mPointlistCat.Count)
				{
					switch (columnIndex)
					{
					case 12:
						mPointlistCat[rowIndex].IsLowSpeed = ((num != 0) ? true : false);
						break;
					case 28:
						mPointlistCat[rowIndex].is_high = ((num != 0) ? true : false);
						break;
					case 18:
						mPointlistCat[rowIndex].is_collect = ((num != 0) ? true : false);
						break;
					}
					bindingList.Add(rowIndex);
				}
			}
			for (int j = 0; j < count; j++)
			{
				dataGridView_pcbcat.Rows[bindingList[j]].Cells[columnIndex].Selected = false;
			}
			dataGridView_pcbcat.CurrentCell = dataGridView_pcbcat.Rows[0].Cells[0];
			dataGridView_pcbcat.CurrentCell = dataGridView_pcbcat.Rows[bindingList[0]].Cells[columnIndex];
			for (int k = 0; k < count; k++)
			{
				dataGridView_pcbcat.Rows[bindingList[k]].Cells[columnIndex].Selected = true;
			}
			dataGridView_pcbcat.Refresh();
		}

		private void button_OptimizeHistory_Click(object sender, EventArgs e)
		{
			if (mPointlistCat_History != null && mPointlistCat != null && mPointlistCat_History.Count == mPointlistCat.Count)
			{
				Form_OptimizeResult form_OptimizeResult = new Form_OptimizeResult(mLanguage, mPointlistCat_History, mPointlistCat);
				form_OptimizeResult.ShowDialog();
			}
		}

		private void button_importStackNo_Click(object sender, EventArgs e)
		{
			string[][] array = new string[3][]
			{
				new string[3] { "从其他工程导入料站号和相应参数", "导入文件", "查看历史" },
				new string[3] { "从其他工程导入料站号和相应参数", "导入文件", "查看历史" },
				new string[3] { "Fill Stack No and parameter from other project file", "Import File", "History Check" }
			};
			Form_BoxSel form_BoxSel = new Form_BoxSel(array[USR_INIT.mLanguage][0], array[USR_INIT.mLanguage][1], array[USR_INIT.mLanguage][2], "");
			switch (form_BoxSel.ShowDialog())
			{
			case DialogResult.Yes:
				if (fm_cat_from_otherfile != null)
				{
					if (!fm_cat_from_otherfile.IsDisposed)
					{
						fm_cat_from_otherfile.Dispose();
					}
					fm_cat_from_otherfile = null;
				}
				fm_cat_from_otherfile = new Form_Cat_from_otherfile(mFn);
				fm_cat_from_otherfile.Show();
				fm_cat_from_otherfile.TopMost = true;
				fm_cat_from_otherfile.show_allresult();
				break;
			case DialogResult.OK:
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = ((mLanguage == 2) ? "Project Files(*.qn)|*.qn" : "工程文件(*.qn)|*.qn");
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() != DialogResult.OK || !File.Exists(openFileDialog.FileName))
				{
					break;
				}
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
				USR2_DATA uSR2_DATA;
				BindingList<ChipCategoryElement> bindingList;
				try
				{
					usr_prj_ex = (USR_PRJ_EX_DATA)formatter.Deserialize(stream);
					stream.Close();
					if (usr_prj_ex.USR3B == null || usr_prj_ex.USR3B.mPointlistCat == null || usr_prj_ex.USR3B.mPointlistCat.Count == 0 || usr_prj_ex.USR2 == null || usr_prj_ex.USR2.mStackLib == null || usr_prj_ex.USR2.mStackLib.stacktab == null)
					{
						MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Invalid File！" : "无效的文件！");
						break;
					}
					uSR2_DATA = usr_prj_ex.USR2;
					bindingList = usr_prj_ex.USR3B.mPointlistCat;
					if (HW.mFnNum == 2 && mFn == 1)
					{
						if (usr_prj_ex.mExPRJ != null)
						{
							uSR2_DATA = usr_prj_ex.mExPRJ.USR2;
						}
						if (uSR2_DATA == null)
						{
							uSR2_DATA = new USR2_DATA();
						}
						USR3_BASE uSR3_BASE = usr_prj_ex.USR3B;
						if (usr_prj_ex.mExPRJ != null)
						{
							uSR3_BASE = usr_prj_ex.mExPRJ.USR3B;
						}
						if (uSR3_BASE == null)
						{
							uSR3_BASE = new USR3_BASE();
						}
						bindingList = uSR3_BASE.mPointlistCat;
					}
				}
				catch (Exception)
				{
					stream.Close();
					stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
					usr_prj = (USR_PRJ_DATA)formatter.Deserialize(stream);
					stream.Close();
					if (usr_prj.USR3 == null || usr_prj.USR3.mPointlistCat == null || usr_prj.USR3.mPointlistCat.Count == 0 || usr_prj.USR2 == null || usr_prj.USR2.mStackLib == null || usr_prj.USR2.mStackLib.stacktab == null)
					{
						MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Invalid File！" : "无效的文件！");
						break;
					}
					uSR2_DATA = usr_prj.USR2;
					bindingList = usr_prj.USR3.mPointlistCat;
				}
				if (mPointlistCat == null || mPointlistCat.Count == 0)
				{
					MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Current project empty！" : "当前工程的元件分类列表为空，无法从其他工程导入！");
					break;
				}
				if (fm_cat_from_otherfile != null)
				{
					if (!fm_cat_from_otherfile.IsDisposed)
					{
						fm_cat_from_otherfile.Dispose();
					}
					fm_cat_from_otherfile = null;
				}
				fm_cat_from_otherfile = new Form_Cat_from_otherfile(mFn);
				fm_cat_from_otherfile.Show();
				fm_cat_from_otherfile.TopMost = true;
				fm_cat_from_otherfile.clear_slotcatitems_from_otherfile_lists();
				for (int i = 0; i < bindingList.Count; i++)
				{
					ChipCategoryElement chipCategoryElement = bindingList[i];
					int j;
					for (j = 0; j < mPointlistCat.Count; j++)
					{
						ChipCategoryElement chipCategoryElement2 = mPointlistCat[j];
						if (!(chipCategoryElement2.Material_value == chipCategoryElement.Material_value) || !(chipCategoryElement2.Footprint == chipCategoryElement.Footprint))
						{
							continue;
						}
						chipCategoryElement2.Cameratype = chipCategoryElement.Cameratype;
						chipCategoryElement2.Visualtype = chipCategoryElement.Visualtype;
						chipCategoryElement2.Feedertype = chipCategoryElement.Feedertype;
						chipCategoryElement2.Delta = chipCategoryElement.Delta;
						chipCategoryElement2.Lenght = chipCategoryElement.Lenght;
						chipCategoryElement2.Width = chipCategoryElement.Width;
						chipCategoryElement2.Height = chipCategoryElement.Height;
						chipCategoryElement2.IsLowSpeed = chipCategoryElement.IsLowSpeed;
						chipCategoryElement2.MultiFeeders = chipCategoryElement.MultiFeeders;
						chipCategoryElement2.Nozzletype0 = chipCategoryElement.Nozzletype0;
						chipCategoryElement2.Nozzletype1 = chipCategoryElement.Nozzletype1;
						chipCategoryElement2.scan_r = chipCategoryElement.scan_r;
						chipCategoryElement2.is_collect = chipCategoryElement.is_collect;
						chipCategoryElement2.collectdelta = chipCategoryElement.collectdelta;
						chipCategoryElement2.pik_h_offset = chipCategoryElement.pik_h_offset;
						chipCategoryElement2.mnt_h_offset = chipCategoryElement.mnt_h_offset;
						chipCategoryElement2.zup_speed = chipCategoryElement.zup_speed;
						chipCategoryElement2.zdown_speed = chipCategoryElement.zdown_speed;
						chipCategoryElement2.zpik_delay = chipCategoryElement.zpik_delay;
						chipCategoryElement2.zmnt_up_speed = chipCategoryElement.zmnt_up_speed;
						chipCategoryElement2.zmnt_down_speed = chipCategoryElement.zmnt_down_speed;
						chipCategoryElement2.zmnt_delay = chipCategoryElement.zmnt_delay;
						chipCategoryElement2.is_high = chipCategoryElement.is_high;
						if (chipCategoryElement2.feeder_no == null)
						{
							chipCategoryElement2.feeder_no = new int[8];
						}
						for (int k = 0; k < chipCategoryElement.MultiFeeders; k++)
						{
							if (chipCategoryElement.feeder_no == null || chipCategoryElement.feeder_no[k] == 0 || chipCategoryElement.feeder_no[k] > HW.mStackNum[MainForm0.mFn][0])
							{
								MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Invalid Stack No！" : "正在导入一个无效的料站号！");
								return;
							}
							chipCategoryElement2.feeder_no[k] = chipCategoryElement.feeder_no[k];
						}
						if (chipCategoryElement.Feedertype == FeederType.Vibra)
						{
							for (int l = 0; l < chipCategoryElement.MultiFeeders; l++)
							{
								USR2.mStackLib.stacktab[2][chipCategoryElement.feeder_no[l] - 1] = uSR2_DATA.mStackLib.stacktab[2][chipCategoryElement.feeder_no[l] - 1];
							}
						}
						else if (chipCategoryElement.Feedertype == FeederType.Plate)
						{
							for (int m = 0; m < chipCategoryElement.MultiFeeders; m++)
							{
								USR2.mStackLib.stacktab[1][chipCategoryElement.feeder_no[m] - 1] = uSR2_DATA.mStackLib.stacktab[1][chipCategoryElement.feeder_no[m] - 1];
							}
						}
						else if (chipCategoryElement.Feedertype != FeederType.Plate && chipCategoryElement.Feedertype < FeederType.N_A && chipCategoryElement.Feedertype >= FeederType.CL8_2_0201)
						{
							for (int n = 0; n < chipCategoryElement.MultiFeeders; n++)
							{
								USR2.mStackLib.stacktab[0][chipCategoryElement.feeder_no[n] - 1] = uSR2_DATA.mStackLib.stacktab[0][chipCategoryElement.feeder_no[n] - 1];
							}
						}
						for (int num = 0; num < chipCategoryElement.MultiFeeders; num++)
						{
							fm_cat_from_otherfile.create_result(MainForm0.format_feeder_to_providertype(chipCategoryElement.Feedertype), chipCategoryElement.feeder_no[num], chipCategoryElement.Material_value, chipCategoryElement.Footprint, is_commit: true, is_forbidden: false, is_takeaway: false);
						}
						break;
					}
					if (j != mPointlistCat.Count || chipCategoryElement.Feedertype == FeederType.Plate || chipCategoryElement.Feedertype == FeederType.Vibra)
					{
						continue;
					}
					for (int num2 = 0; num2 < chipCategoryElement.MultiFeeders; num2++)
					{
						if (chipCategoryElement.feeder_no[num2] == 0 || chipCategoryElement.feeder_no[num2] > HW.mStackNum[MainForm0.mFn][0])
						{
							MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Invalid Stack No！" : "正在导入一个无效的料站号！");
							return;
						}
						fm_cat_from_otherfile.create_result(MainForm0.format_feeder_to_providertype(chipCategoryElement.Feedertype), chipCategoryElement.feeder_no[num2], chipCategoryElement.Material_value, chipCategoryElement.Footprint, is_commit: false, is_forbidden: false, is_takeaway: false);
					}
				}
				dataGridView_pcbcat.Refresh();
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Complete!" : "导入完成！");
				break;
			}
			}
		}

		private void button_OverridetoUSR2_Click(object sender, EventArgs e)
		{
			if (USR2 == null || mPointlistCat == null)
			{
				return;
			}
			int count = dataGridView_pcbcat.SelectedRows.Count;
			if (count <= 0)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Please select items!" : "请选中需要覆盖的元件条目！");
				return;
			}
			Form_Cat_to_USR2 form_Cat_to_USR = new Form_Cat_to_USR2(USR_INIT.mLanguage);
			if (form_Cat_to_USR.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			bool is_onlyvaliddata = form_Cat_to_USR.get_is_onlyvaliddata();
			bool is_updatepikmntH = form_Cat_to_USR.get_is_updatepikmntH();
			BindingList<PcatHead> overidelist = form_Cat_to_USR.get_overidelist();
			for (int i = 0; i < count; i++)
			{
				int index = dataGridView_pcbcat.SelectedRows[i].Index;
				ProviderType providerType = MainForm0.check_return_providertype(mPointlistCat[index].Feedertype);
				StackElement[] array;
				if (providerType == ProviderType.Feedr)
				{
					array = USR2.mStackLib.stacktab[0];
				}
				else if (providerType == ProviderType.Vibra)
				{
					array = USR2.mStackLib.stacktab[2];
				}
				else
				{
					if (providerType != ProviderType.Plate)
					{
						continue;
					}
					array = USR2.mStackLib.stacktab[1];
				}
				int num = HW.mStackNum[MainForm0.mFn][(int)providerType];
				for (int j = 0; j < mPointlistCat[index].MultiFeeders; j++)
				{
					if (mPointlistCat[index].feeder_no[j] == 0)
					{
						continue;
					}
					int num2 = mPointlistCat[index].feeder_no[j] - 1;
					if (num2 >= num || num2 < 0)
					{
						continue;
					}
					for (int k = 0; k < overidelist.Count; k++)
					{
						if (overidelist[k] == PcatHead.SCANR && (!is_onlyvaliddata || !(mPointlistCat[index].scan_r <= 0f)))
						{
							array[num2].scanR = Math.Abs((int)mPointlistCat[index].scan_r % 921);
						}
						if (overidelist[k] == PcatHead.LENGHT && (!is_onlyvaliddata || !(mPointlistCat[index].Lenght <= 0f)))
						{
							array[num2].lenght = mPointlistCat[index].Lenght;
						}
						if (overidelist[k] == PcatHead.WIDTH && (!is_onlyvaliddata || !(mPointlistCat[index].Width <= 0f)))
						{
							array[num2].width = mPointlistCat[index].Width;
						}
						if (overidelist[k] == PcatHead.HEIGHT && (!is_onlyvaliddata || !(mPointlistCat[index].Height <= 0f)))
						{
							array[num2].height = mPointlistCat[index].Height;
						}
						if (overidelist[k] == PcatHead.ISCOLLECT)
						{
							array[num2].mIsCollect = mPointlistCat[index].is_collect;
						}
						if (overidelist[k] == PcatHead.COLLECT_DELTA && (!is_onlyvaliddata || !(mPointlistCat[index].collectdelta <= 0f)))
						{
							array[num2].mCollectDelta = mPointlistCat[index].collectdelta;
						}
						if (overidelist[k] == PcatHead.PIK_H_OFFSET && (!is_onlyvaliddata || !(mPointlistCat[index].pik_h_offset <= 0f)))
						{
							array[num2].pik_HmmOffset = mPointlistCat[index].pik_h_offset;
						}
						if (overidelist[k] == PcatHead.MNT_H_OFFSET && (!is_onlyvaliddata || !(mPointlistCat[index].mnt_h_offset <= 0f)))
						{
							array[num2].mnt_HmmOffset = mPointlistCat[index].mnt_h_offset;
						}
						for (int l = 0; l < HW.mZnNum[MainForm0.mFn]; l++)
						{
							if (overidelist[k] == PcatHead.THRESHOLD && (!is_onlyvaliddata || mPointlistCat[index].threshold > 0))
							{
								array[num2].mZnData[l].threshold = Math.Abs(mPointlistCat[index].threshold) % 256;
							}
							if (overidelist[k] == PcatHead.ZUP_SPEED && (!is_onlyvaliddata || mPointlistCat[index].zup_speed > 0))
							{
								array[num2].mZnData[l].Pik.UpSpeed = mPointlistCat[index].zup_speed;
							}
							if (overidelist[k] == PcatHead.ZDOWN_SPEED && (!is_onlyvaliddata || mPointlistCat[index].zdown_speed > 0))
							{
								array[num2].mZnData[l].Pik.DownSpeed = mPointlistCat[index].zdown_speed;
							}
							if (overidelist[k] == PcatHead.ZPIK_DELAY && (!is_onlyvaliddata || !(mPointlistCat[index].zpik_delay <= 0f)))
							{
								array[num2].mZnData[l].Pik.Delay = (int)mPointlistCat[index].zpik_delay;
							}
							if (overidelist[k] == PcatHead.ZMNT_UP_SPEED && (!is_onlyvaliddata || mPointlistCat[index].zmnt_up_speed > 0))
							{
								array[num2].mZnData[l].Mnt.UpSpeed = mPointlistCat[index].zmnt_up_speed;
							}
							if (overidelist[k] == PcatHead.ZMNT_DOWN_SPEED && (!is_onlyvaliddata || mPointlistCat[index].zmnt_down_speed > 0))
							{
								array[num2].mZnData[l].Mnt.DownSpeed = mPointlistCat[index].zmnt_down_speed;
							}
							if (overidelist[k] == PcatHead.ZMNT_DELAY && (!is_onlyvaliddata || !(mPointlistCat[index].zmnt_delay <= 0f)))
							{
								array[num2].mZnData[l].Mnt.Delay = (int)mPointlistCat[index].zmnt_delay;
							}
						}
						if (overidelist[k] == PcatHead.LENGHT && (!is_onlyvaliddata || !(mPointlistCat[index].Lenght <= 0f)))
						{
							array[num2].mCollectL = array[num2].lenght * 100f / ((mPointlistCat[index].Cameratype != CameraType.High) ? USR.mFastCamRatio[0][0] : USR.mHighCamRatio[0]);
						}
						if (overidelist[k] == PcatHead.WIDTH && (!is_onlyvaliddata || !(mPointlistCat[index].Width <= 0f)))
						{
							array[num2].mCollectW = array[num2].width * 100f / ((mPointlistCat[index].Cameratype != CameraType.High) ? USR.mFastCamRatio[0][0] : USR.mHighCamRatio[0]);
						}
					}
					if (!is_updatepikmntH)
					{
						continue;
					}
					for (int m = 0; m < HW.mZnNum[MainForm0.mFn]; m++)
					{
						float num3 = MainForm0.format_H_to_Hmm(Math.Abs((MainForm0.format_feeder_front_or_back(MainForm0.mFn, num2) == 0) ? USR.mBaseHeight_feeder[m] : USR.mBaseHeight_feederBk[m]));
						float hmm = num3 + array[num2].pik_HmmOffset;
						int value = MainForm0.format_Hmm_to_H(hmm) * ((m % 2 != 0) ? 1 : (-1));
						if (HW.mSmtGenerationNo == 2)
						{
							value = Math.Abs(value);
						}
						array[num2].mZnData[m].Pik.Height = value;
					}
					for (int n = 0; n < HW.mZnNum[MainForm0.mFn]; n++)
					{
						float hmm2 = Math.Abs(USR.mBaseHeightmm[n]) + array[num2].mnt_HmmOffset - array[num2].height;
						int value2 = MainForm0.format_Hmm_to_H(hmm2) * ((n % 2 != 0) ? 1 : (-1));
						if (HW.mSmtGenerationNo == 2)
						{
							value2 = Math.Abs(value2);
						}
						array[num2].mZnData[n].Mnt.Height = value2;
					}
				}
			}
			MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Overide done!" : "覆盖完成！");
		}

		private void button_saveas_libprovider_Click(object sender, EventArgs e)
		{
			USR_STACKLIB uSR_STACKLIB = new USR_STACKLIB();
			uSR_STACKLIB.index[0] = USR2.mStackLib.index[0];
			uSR_STACKLIB.index[1] = USR2.mStackLib.index[1];
			uSR_STACKLIB.index[2] = USR2.mStackLib.index[2];
			uSR_STACKLIB.sel = USR2.mStackLib.sel;
			for (int i = 0; i < Math.Min(USR2.mStackLib.stacktab[0].Count(), uSR_STACKLIB.stacktab[0].Count()); i++)
			{
				MainForm0.common_copy_stackemt(uSR_STACKLIB.stacktab[0][i], USR2.mStackLib.stacktab[0][i]);
				uSR_STACKLIB.stacktab[0][i].mEnabled = USR2.mStackLib.stacktab[0][i].mSelected;
			}
			for (int j = 0; j < Math.Min(USR2.mStackLib.stacktab[1].Count(), uSR_STACKLIB.stacktab[1].Count()); j++)
			{
				MainForm0.common_copy_stackemt(uSR_STACKLIB.stacktab[1][j], USR2.mStackLib.stacktab[1][j]);
				uSR_STACKLIB.stacktab[1][j].mEnabled = USR2.mStackLib.stacktab[1][j].mSelected;
			}
			for (int k = 0; k < Math.Min(USR2.mStackLib.stacktab[2].Count(), uSR_STACKLIB.stacktab[2].Count()); k++)
			{
				MainForm0.common_copy_stackemt(uSR_STACKLIB.stacktab[2][k], USR2.mStackLib.stacktab[2][k]);
				uSR_STACKLIB.stacktab[2][k].mEnabled = USR2.mStackLib.stacktab[2][k].mSelected;
			}
			MainForm0.save_provider_file(".\\HWGC.provider", uSR_STACKLIB);
			MainForm0.CmMessageBox("功能研发中，敬请期待!", MessageBoxButtons.OK);
		}

		private void checkBox_is_backup_nozzle_CheckedChanged(object sender, EventArgs e)
		{
			MainForm0.USR3B[mFn].mIsEnableBackupNozzle = checkBox_is_backup_nozzle.Checked;
			dataGridView_pcbcat.Columns[7].Visible = MainForm0.USR3B[mFn].mIsEnableBackupNozzle;
			dataGridView_pcbcat.Refresh();
		}

		private void dataGridView_pcbcat_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 12)
			{
				int columnIndex = e.ColumnIndex;
				int rowIndex = e.RowIndex;
				if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
				{
					dataGridView_pcbcat.Rows[0].Cells[0].Selected = true;
					dataGridView_pcbcat.ClearSelection();
					dataGridView_pcbcat.UpdateCellValue(e.ColumnIndex, e.RowIndex);
					dataGridView_pcbcat.Refresh();
					dataGridView_pcbcat.CurrentCell = dataGridView_pcbcat.Rows[rowIndex].Cells[columnIndex];
					dataGridView_pcbcat.EndEdit();
				}
			}
		}

		private void dataGridView_pcbcat_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			DataGridView dataGridView = sender as DataGridView;
			Rectangle bounds = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView.RowHeadersWidth - 4, e.RowBounds.Height);
			TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView.RowHeadersDefaultCellStyle.Font, bounds, dataGridView.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
		}
	}
}
