using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_SmtArrayIsMount : Form
	{
		public BindingList<ArrayIsMountElement> mArrayIsMountList;

		public BindingList<SmtFeederInstallElement> mFeederInstallList;

		public bool[][] mIsMountStacks;

		public CheckBox[] checkBox_stackMount;

		private int mLanguage;

		public USR3_DATA USR3;

		public BindingList<USR3_DATA> U3;

		public int U3Idx;

		public int mFn;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		public BindingList<Label>[] lb_pcbArray_pcb;

		public BindingList<Label>[] lb_pcbAix_pcb;

		public RadioButton[] radioButton_pcb;

		public Panel[] panel_pcb;

		private IContainer components;

		private Button button_OK;

		private Panel panel_stack;

		private Panel panel_isMountStack;

		private Label label2;

		private CheckBox checkBox_all_stacks;

		private CheckBox checkBox_selectall;

		private Label label46;

		private Label label52;

		private Label label51;

		private Label label47;

		private Label label50;

		private Label label45;

		private Label label1;

		private Panel panel2;

		private Panel panel_ismount;

		private Label label48;

		private Label label18;

		private Label label10;

		private Label label17;

		private Label label6;

		private Label label16;

		private Label label9;

		private Label label15;

		private Label label4;

		private Label label14;

		private Label label8;

		private Label label13;

		private Label label7;

		private Label label12;

		private Label label5;

		private Label label11;

		private Label label3;

		private Label label49;

		private Label label43;

		private Label label44;

		private Panel panel_array;

		private Label label19;

		private Label label61;

		private Panel panel1;

		private Panel panel3;

		public event void_Func_int button_subpcb_sel;

		public Form_SmtArrayIsMount()
		{
			InitializeComponent();
		}

		public Form_SmtArrayIsMount(int fn, BindingList<SmtFeederInstallElement> feederlist, bool[][] ismountstack, USR3_DATA usr3)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mFn = fn;
			mLanguage = MainForm0.USR_INIT.mLanguage;
			initLanguageTable();
			updateLanguage(mLanguage);
			mFeederInstallList = feederlist;
			mIsMountStacks = ismountstack;
			USR3 = usr3;
			U3 = MainForm0.U3[mFn];
			U3Idx = MainForm0.U3Idx[mFn];
			if (mFeederInstallList != null && mIsMountStacks != null)
			{
				checkBox_stackMount = new CheckBox[mFeederInstallList.Count];
				for (int i = 0; i < mFeederInstallList.Count; i++)
				{
					checkBox_stackMount[i] = new CheckBox();
					checkBox_stackMount[i].Tag = i;
					checkBox_stackMount[i].Font = new Font(DEF.FONT_2020_TITLE[mLanguage], 12f, FontStyle.Regular);
					checkBox_stackMount[i].Size = new Size(400, 25);
					checkBox_stackMount[i].AutoSize = true;
					checkBox_stackMount[i].Location = new Point(4, 26 * i);
					checkBox_stackMount[i].Text = STR.PROVIDER_STR[(int)mFeederInstallList[i].Stacktype][mLanguage] + mFeederInstallList[i].Stack_no + " - " + mFeederInstallList[i].Footprint + " " + mFeederInstallList[i].Material_value;
					int stacktype = (int)mFeederInstallList[i].Stacktype;
					int num = mFeederInstallList[i].Stack_no - 1;
					checkBox_stackMount[i].Checked = mIsMountStacks[stacktype][num];
					checkBox_stackMount[i].CheckedChanged += checkBox_stackMount_CheckedChanged;
					panel_isMountStack.Controls.Add(checkBox_stackMount[i]);
				}
			}
		}

		private void checkBox_stackMount_CheckedChanged(object sender, EventArgs e)
		{
			int num = (int)((CheckBox)sender).Tag;
			if (mFeederInstallList != null && mIsMountStacks != null)
			{
				int stacktype = (int)mFeederInstallList[num].Stacktype;
				int num2 = mFeederInstallList[num].Stack_no - 1;
				mIsMountStacks[stacktype][num2] = checkBox_stackMount[num].Checked;
			}
		}

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
				if (mLanguage2.font != null && mLanguage2.fsize != null)
				{
					mLanguage2.ctrl.Font = new Font(mLanguage2.font[mLanguage], mLanguage2.ctrl.Font.Size + mLanguage2.fsize[mLanguage], mLanguage2.ctrl.Font.Style);
					continue;
				}
				switch (mLanguage)
				{
				case 2:
					mLanguage2.ctrl.Font = new Font("Oswald", mLanguage2.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					mLanguage2.ctrl.Font = new Font("微软雅黑", mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
					break;
				}
			}
		}

		private void initLanguageTable()
		{
		}

		private void checkBox_all_stacks_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_stackMount != null)
			{
				for (int i = 0; i < checkBox_stackMount.Count(); i++)
				{
					checkBox_stackMount[i].Checked = checkBox_all_stacks.Checked;
				}
			}
		}

		private void Form_SmtArrayIsMount_Load(object sender, EventArgs e)
		{
			show_ismount_array();
		}

		private void show_ismount_array()
		{
			panel2.Controls.Clear();
			if (U3 == null || U3.Count <= 0 || U3Idx < 0 || U3Idx >= U3.Count)
			{
				return;
			}
			panel_pcb = new Panel[U3.Count];
			radioButton_pcb = new RadioButton[U3.Count];
			lb_pcbArray_pcb = new BindingList<Label>[U3.Count];
			lb_pcbAix_pcb = new BindingList<Label>[U3.Count];
			for (int i = 0; i < U3.Count; i++)
			{
				radioButton_pcb[i] = new RadioButton();
				panel3.Controls.Add(radioButton_pcb[i]);
				radioButton_pcb[i].AutoSize = false;
				radioButton_pcb[i].Size = new Size(60, 23);
				radioButton_pcb[i].Location = new Point(5 + 70 * i, 0);
				radioButton_pcb[i].Text = U3[i].mPcbID;
				radioButton_pcb[i].CheckedChanged += radioButton_pcb_CheckedChanged;
				radioButton_pcb[i].Tag = i;
				panel_pcb[i] = new Panel();
				panel2.Controls.Add(panel_pcb[i]);
				panel_pcb[i].Location = new Point(5, 5);
				panel_pcb[i].Visible = false;
				panel_pcb[i].Controls.Clear();
				panel_pcb[i].Size = new Size(622, 226);
				lb_pcbArray_pcb[i] = new BindingList<Label>();
				lb_pcbAix_pcb[i] = new BindingList<Label>();
				USR3_DATA uSR3_DATA = U3[i];
				if (uSR3_DATA.mIsArrayMount == null || uSR3_DATA.mIsArrayMount.Count() != uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn)
				{
					uSR3_DATA.mIsArrayMount = new bool[uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn];
					for (int j = 0; j < uSR3_DATA.mIsArrayMount.Count(); j++)
					{
						uSR3_DATA.mIsArrayMount[j] = true;
					}
				}
				if (uSR3_DATA.mIsPcbAix && (uSR3_DATA.mIsArrayAixMount == null || uSR3_DATA.mIsArrayAixMount.Count() != uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn))
				{
					uSR3_DATA.mIsArrayAixMount = new bool[uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn];
					for (int k = 0; k < uSR3_DATA.mIsArrayAixMount.Count(); k++)
					{
						uSR3_DATA.mIsArrayAixMount[k] = true;
					}
				}
				int num = 57;
				int num2 = 22;
				int num3 = 4;
				int num4 = (uSR3_DATA.mIsPcbAix ? 20 : 0);
				int num5 = (uSR3_DATA.mIsPcbAix ? 15 : 0);
				int num6 = (num + num3) * uSR3_DATA.mArrayPCBColumn + num3 + num4 * uSR3_DATA.mArrayPCBColumn * (uSR3_DATA.mIsPcbAix ? 1 : 0);
				int num7 = (num2 + num3) * uSR3_DATA.mArrayPCBRow + num3 + num5 * uSR3_DATA.mArrayPCBRow * (uSR3_DATA.mIsPcbAix ? 1 : 0);
				if (num6 + 3 > panel_pcb[i].Size.Width)
				{
					panel_pcb[i].Size = new Size(num6 + 3, panel_pcb[i].Size.Height);
				}
				if (num7 + 3 > panel_pcb[i].Size.Height)
				{
					panel_pcb[i].Size = new Size(panel_pcb[i].Size.Width, num7 + 3);
				}
				for (int l = 0; l < uSR3_DATA.mArrayPCBRow; l++)
				{
					for (int m = 0; m < uSR3_DATA.mArrayPCBColumn; m++)
					{
						Label label = new Label();
						label.AutoSize = false;
						label.Size = new Size(num, num2);
						label.BackColor = (uSR3_DATA.mIsArrayMount[l * uSR3_DATA.mArrayPCBColumn + m] ? Color.SpringGreen : Color.Gray);
						label.Text = l + 1 + "-" + (m + 1);
						label.Location = new Point(num3 + m * (num + num3 + num4), num3 + l * (num2 + num3 + num5));
						label.TextAlign = (USR3.mIsPcbAix ? ContentAlignment.TopLeft : ContentAlignment.MiddleCenter);
						label.BorderStyle = BorderStyle.FixedSingle;
						label.Click += lb_ismount_Click_EventHandler;
						label.Tag = new ButtonTag(i, l * uSR3_DATA.mArrayPCBColumn + m, 0);
						panel_pcb[i].Controls.Add(label);
						lb_pcbArray_pcb[i].Add(label);
						if (uSR3_DATA.mIsPcbAix)
						{
							Label label2 = new Label();
							label2.AutoSize = false;
							label2.Size = new Size(num, 22);
							label2.BackColor = (uSR3_DATA.mIsArrayAixMount[l * uSR3_DATA.mArrayPCBColumn + m] ? Color.Yellow : Color.Gray);
							label2.Text = "*" + (l + 1) + "-" + (m + 1);
							label2.Location = new Point(num3 + num4 + m * (num + num3 + num4), num3 + num5 + l * (num2 + num3 + num5));
							label2.TextAlign = ContentAlignment.BottomRight;
							label2.BorderStyle = BorderStyle.FixedSingle;
							label2.Click += lb_ismount_aix_Click_EventHandler;
							label2.Tag = new ButtonTag(i, l * uSR3_DATA.mArrayPCBColumn + m, 0);
							label2.BringToFront();
							panel_pcb[i].Controls.Add(label2);
							lb_pcbAix_pcb[i].Add(label2);
						}
					}
				}
			}
			radioButton_pcb[U3Idx].Checked = true;
			panel_pcb[U3Idx].Visible = true;
		}

		public void radioButton_pcb_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			int num = (int)radioButton.Tag;
			if (radioButton.Checked)
			{
				panel_pcb[U3Idx].Visible = false;
				panel_pcb[num].Visible = true;
				if (this.button_subpcb_sel != null)
				{
					this.button_subpcb_sel(num);
				}
			}
		}

		public void lb_ismount_Click_EventHandler(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			ButtonTag buttonTag = (ButtonTag)label.Tag;
			USR3_DATA uSR3_DATA = U3[buttonTag.tag];
			uSR3_DATA.mIsArrayMount[buttonTag.tag1] = !uSR3_DATA.mIsArrayMount[buttonTag.tag1];
			label.BackColor = (uSR3_DATA.mIsArrayMount[buttonTag.tag1] ? Color.SpringGreen : Color.Gray);
		}

		public void lb_ismount_aix_Click_EventHandler(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			ButtonTag buttonTag = (ButtonTag)label.Tag;
			USR3_DATA uSR3_DATA = U3[buttonTag.tag];
			uSR3_DATA.mIsArrayAixMount[buttonTag.tag1] = !uSR3_DATA.mIsArrayAixMount[buttonTag.tag1];
			label.BackColor = (uSR3_DATA.mIsArrayAixMount[buttonTag.tag1] ? Color.Yellow : Color.Gray);
		}

		private void checkBox_selectall_CheckedChanged(object sender, EventArgs e)
		{
			USR3_DATA uSR3_DATA = U3[U3Idx];
			for (int i = 0; i < uSR3_DATA.mIsArrayMount.Count(); i++)
			{
				uSR3_DATA.mIsArrayMount[i] = checkBox_selectall.Checked;
				lb_pcbArray_pcb[U3Idx][i].BackColor = (uSR3_DATA.mIsArrayMount[i] ? Color.SpringGreen : Color.Gray);
			}
			if (uSR3_DATA.mIsPcbAix)
			{
				for (int j = 0; j < uSR3_DATA.mIsArrayAixMount.Count(); j++)
				{
					uSR3_DATA.mIsArrayAixMount[j] = checkBox_selectall.Checked;
					lb_pcbAix_pcb[U3Idx][j].BackColor = (uSR3_DATA.mIsArrayAixMount[j] ? Color.Yellow : Color.Gray);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.Form_SmtArrayIsMount));
			button_OK = new System.Windows.Forms.Button();
			panel_stack = new System.Windows.Forms.Panel();
			checkBox_all_stacks = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			panel_isMountStack = new System.Windows.Forms.Panel();
			checkBox_selectall = new System.Windows.Forms.CheckBox();
			label46 = new System.Windows.Forms.Label();
			label52 = new System.Windows.Forms.Label();
			label51 = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			label50 = new System.Windows.Forms.Label();
			label45 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			panel_ismount = new System.Windows.Forms.Panel();
			label48 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			label43 = new System.Windows.Forms.Label();
			label44 = new System.Windows.Forms.Label();
			panel_array = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			panel1 = new System.Windows.Forms.Panel();
			label19 = new System.Windows.Forms.Label();
			label61 = new System.Windows.Forms.Label();
			panel_stack.SuspendLayout();
			panel2.SuspendLayout();
			panel_ismount.SuspendLayout();
			panel_array.SuspendLayout();
			panel3.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			button_OK.BackColor = System.Drawing.Color.PaleTurquoise;
			button_OK.Font = new System.Drawing.Font("楷体", 11.5f);
			button_OK.Location = new System.Drawing.Point(73, 602);
			button_OK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(205, 38);
			button_OK.TabIndex = 152;
			button_OK.Text = "完成";
			button_OK.UseVisualStyleBackColor = false;
			panel_stack.Controls.Add(checkBox_all_stacks);
			panel_stack.Controls.Add(label2);
			panel_stack.Controls.Add(panel_isMountStack);
			panel_stack.Font = new System.Drawing.Font("黑体", 10.5f);
			panel_stack.Location = new System.Drawing.Point(29, 44);
			panel_stack.Name = "panel_stack";
			panel_stack.Size = new System.Drawing.Size(333, 595);
			panel_stack.TabIndex = 153;
			checkBox_all_stacks.AutoSize = true;
			checkBox_all_stacks.Location = new System.Drawing.Point(270, 18);
			checkBox_all_stacks.Name = "checkBox_all_stacks";
			checkBox_all_stacks.Size = new System.Drawing.Size(54, 18);
			checkBox_all_stacks.TabIndex = 155;
			checkBox_all_stacks.Text = "全选";
			checkBox_all_stacks.UseVisualStyleBackColor = true;
			checkBox_all_stacks.CheckedChanged += new System.EventHandler(checkBox_all_stacks_CheckedChanged);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 12.5f);
			label2.Location = new System.Drawing.Point(10, 18);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(143, 17);
			label2.TabIndex = 154;
			label2.Text = "● 料站是否贴装";
			panel_isMountStack.AutoScroll = true;
			panel_isMountStack.BackColor = System.Drawing.Color.White;
			panel_isMountStack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_isMountStack.Location = new System.Drawing.Point(13, 50);
			panel_isMountStack.Name = "panel_isMountStack";
			panel_isMountStack.Size = new System.Drawing.Size(311, 534);
			panel_isMountStack.TabIndex = 0;
			checkBox_selectall.AutoSize = true;
			checkBox_selectall.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_selectall.Location = new System.Drawing.Point(575, 4);
			checkBox_selectall.Name = "checkBox_selectall";
			checkBox_selectall.Size = new System.Drawing.Size(54, 18);
			checkBox_selectall.TabIndex = 165;
			checkBox_selectall.Text = "全选";
			checkBox_selectall.UseVisualStyleBackColor = true;
			checkBox_selectall.CheckedChanged += new System.EventHandler(checkBox_selectall_CheckedChanged);
			label46.AutoSize = true;
			label46.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label46.Location = new System.Drawing.Point(131, 12);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(63, 15);
			label46.TabIndex = 160;
			label46.Text = "-不贴装";
			label52.BackColor = System.Drawing.Color.Yellow;
			label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label52.Location = new System.Drawing.Point(297, 8);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(40, 22);
			label52.TabIndex = 156;
			label52.Text = "*1-1";
			label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label51.AutoSize = true;
			label51.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label51.Location = new System.Drawing.Point(336, 12);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(63, 15);
			label51.TabIndex = 161;
			label51.Text = "-鸳鸯板";
			label47.BackColor = System.Drawing.Color.SpringGreen;
			label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label47.Location = new System.Drawing.Point(206, 8);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(40, 22);
			label47.TabIndex = 155;
			label47.Text = "1-1";
			label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label50.AutoSize = true;
			label50.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label50.Location = new System.Drawing.Point(245, 12);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(47, 15);
			label50.TabIndex = 162;
			label50.Text = "-原板";
			label45.AutoSize = true;
			label45.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label45.Location = new System.Drawing.Point(56, 12);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(47, 15);
			label45.TabIndex = 159;
			label45.Text = "-贴装";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 12.5f);
			label1.Location = new System.Drawing.Point(15, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(251, 17);
			label1.TabIndex = 163;
			label1.Text = "● 拼板是否贴装（单击修改）";
			panel2.AutoScroll = true;
			panel2.BackColor = System.Drawing.Color.White;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel2.Controls.Add(panel_ismount);
			panel2.Location = new System.Drawing.Point(18, 80);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(637, 239);
			panel2.TabIndex = 164;
			panel_ismount.Controls.Add(label48);
			panel_ismount.Controls.Add(label18);
			panel_ismount.Controls.Add(label10);
			panel_ismount.Controls.Add(label17);
			panel_ismount.Controls.Add(label6);
			panel_ismount.Controls.Add(label16);
			panel_ismount.Controls.Add(label9);
			panel_ismount.Controls.Add(label15);
			panel_ismount.Controls.Add(label4);
			panel_ismount.Controls.Add(label14);
			panel_ismount.Controls.Add(label8);
			panel_ismount.Controls.Add(label13);
			panel_ismount.Controls.Add(label7);
			panel_ismount.Controls.Add(label12);
			panel_ismount.Controls.Add(label5);
			panel_ismount.Controls.Add(label11);
			panel_ismount.Controls.Add(label3);
			panel_ismount.Location = new System.Drawing.Point(5, 5);
			panel_ismount.Name = "panel_ismount";
			panel_ismount.Size = new System.Drawing.Size(622, 226);
			panel_ismount.TabIndex = 0;
			label48.BackColor = System.Drawing.Color.Yellow;
			label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label48.Location = new System.Drawing.Point(301, 71);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(57, 22);
			label48.TabIndex = 0;
			label48.Text = "*10-10";
			label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label18.BackColor = System.Drawing.Color.SpringGreen;
			label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label18.Location = new System.Drawing.Point(187, 80);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(57, 22);
			label18.TabIndex = 0;
			label18.Text = "10-10";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label10.BackColor = System.Drawing.Color.SpringGreen;
			label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label10.Location = new System.Drawing.Point(66, 80);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(57, 22);
			label10.TabIndex = 0;
			label10.Text = "10-10";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label17.BackColor = System.Drawing.Color.SpringGreen;
			label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label17.Location = new System.Drawing.Point(187, 30);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(57, 22);
			label17.TabIndex = 0;
			label17.Text = "10-10";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.BackColor = System.Drawing.Color.SpringGreen;
			label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label6.Location = new System.Drawing.Point(66, 30);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(57, 22);
			label6.TabIndex = 0;
			label6.Text = "10-10";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label16.BackColor = System.Drawing.Color.SpringGreen;
			label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label16.Location = new System.Drawing.Point(187, 55);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(57, 22);
			label16.TabIndex = 0;
			label16.Text = "10-10";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label9.BackColor = System.Drawing.Color.SpringGreen;
			label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label9.Location = new System.Drawing.Point(66, 55);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(57, 22);
			label9.TabIndex = 0;
			label9.Text = "10-10";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label15.BackColor = System.Drawing.Color.SpringGreen;
			label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label15.Location = new System.Drawing.Point(187, 5);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(57, 22);
			label15.TabIndex = 0;
			label15.Text = "10-10";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.BackColor = System.Drawing.Color.SpringGreen;
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Location = new System.Drawing.Point(66, 5);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(57, 22);
			label4.TabIndex = 0;
			label4.Text = "10-10";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label14.BackColor = System.Drawing.Color.SpringGreen;
			label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label14.Location = new System.Drawing.Point(126, 80);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(57, 22);
			label14.TabIndex = 0;
			label14.Text = "10-10";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.BackColor = System.Drawing.Color.SpringGreen;
			label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label8.Location = new System.Drawing.Point(5, 80);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(57, 22);
			label8.TabIndex = 0;
			label8.Text = "10-10";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label13.BackColor = System.Drawing.Color.SpringGreen;
			label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label13.Location = new System.Drawing.Point(126, 55);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(57, 22);
			label13.TabIndex = 0;
			label13.Text = "10-10";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label7.BackColor = System.Drawing.Color.SpringGreen;
			label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label7.Location = new System.Drawing.Point(5, 55);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(57, 22);
			label7.TabIndex = 0;
			label7.Text = "10-10";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label12.BackColor = System.Drawing.Color.Gray;
			label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label12.Location = new System.Drawing.Point(126, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(57, 22);
			label12.TabIndex = 0;
			label12.Text = "10-10";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label5.BackColor = System.Drawing.Color.SpringGreen;
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Location = new System.Drawing.Point(5, 30);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(57, 22);
			label5.TabIndex = 0;
			label5.Text = "10-10";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label11.BackColor = System.Drawing.Color.SpringGreen;
			label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label11.Location = new System.Drawing.Point(126, 5);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(57, 22);
			label11.TabIndex = 0;
			label11.Text = "10-10";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.BackColor = System.Drawing.Color.SpringGreen;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.Location = new System.Drawing.Point(5, 5);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(57, 22);
			label3.TabIndex = 0;
			label3.Text = "10-10";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label49.BackColor = System.Drawing.Color.Yellow;
			label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label49.Location = new System.Drawing.Point(32, 8);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(22, 22);
			label49.TabIndex = 154;
			label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label43.BackColor = System.Drawing.Color.SpringGreen;
			label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label43.Location = new System.Drawing.Point(9, 8);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(22, 22);
			label43.TabIndex = 158;
			label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label44.BackColor = System.Drawing.Color.Gray;
			label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label44.Location = new System.Drawing.Point(107, 8);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(22, 22);
			label44.TabIndex = 157;
			label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_array.Controls.Add(panel3);
			panel_array.Controls.Add(panel1);
			panel_array.Controls.Add(label1);
			panel_array.Controls.Add(panel2);
			panel_array.Location = new System.Drawing.Point(367, 46);
			panel_array.Name = "panel_array";
			panel_array.Size = new System.Drawing.Size(673, 593);
			panel_array.TabIndex = 166;
			panel3.BackColor = System.Drawing.Color.White;
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel3.Controls.Add(checkBox_selectall);
			panel3.Font = new System.Drawing.Font("楷体", 11.5f);
			panel3.Location = new System.Drawing.Point(18, 49);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(637, 28);
			panel3.TabIndex = 167;
			panel1.Controls.Add(label46);
			panel1.Controls.Add(label52);
			panel1.Controls.Add(label51);
			panel1.Controls.Add(label47);
			panel1.Controls.Add(label50);
			panel1.Controls.Add(label45);
			panel1.Controls.Add(label49);
			panel1.Controls.Add(label43);
			panel1.Controls.Add(label44);
			panel1.Location = new System.Drawing.Point(272, 5);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(421, 37);
			panel1.TabIndex = 166;
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("黑体", 15.5f);
			label19.Location = new System.Drawing.Point(38, 14);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(98, 21);
			label19.TabIndex = 154;
			label19.Text = "是否贴装";
			label61.BackColor = System.Drawing.Color.Red;
			label61.Location = new System.Drawing.Point(39, 40);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(1000, 4);
			label61.TabIndex = 176;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightBlue;
			base.ClientSize = new System.Drawing.Size(1067, 655);
			base.Controls.Add(label61);
			base.Controls.Add(panel_array);
			base.Controls.Add(label19);
			base.Controls.Add(panel_stack);
			base.Controls.Add(button_OK);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "Form_SmtArrayIsMount";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_SmtArrayIsMount_Load);
			panel_stack.ResumeLayout(false);
			panel_stack.PerformLayout();
			panel2.ResumeLayout(false);
			panel_ismount.ResumeLayout(false);
			panel_array.ResumeLayout(false);
			panel_array.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
