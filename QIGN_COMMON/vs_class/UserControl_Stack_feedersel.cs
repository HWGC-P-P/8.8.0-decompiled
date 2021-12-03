using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_Stack_feedersel : UserControl
	{
		public void_Func_void callback_flush_feederno;

		public USR_STACKLIB mStackLib;

		private IContainer components;

		private ListBox listBox_StackAll;

		public UserControl_Stack_feedersel(USR_STACKLIB lib)
		{
			InitializeComponent();
			mStackLib = lib;
			base.Location = new Point(9, 257 + HW.malgo2[MainForm0.mFn].emp_m[1] * 5);
			base.Size = new Size(1280, 118);
			listBox_StackAll.Size = new Size(1255, 96);
			listBox_StackAll.Items.Clear();
			int num = HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + 1;
			int num2 = 1;
			for (int i = 0; i < (HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + HW.malgo2[MainForm0.mFn].emp_m[0]) * 4; i++)
			{
				if (i % 4 == 0)
				{
					int num3 = i / 4 + 1;
					if (num3 <= HW.malgo2[MainForm0.mFn].slt_l[1] || (num3 >= HW.malgo2[MainForm0.mFn].slt_l[1] + HW.malgo2[MainForm0.mFn].emp_m[1] + 1 && num3 <= HW.malgo2[MainForm0.mFn].slt_l[1] + HW.malgo2[MainForm0.mFn].emp_m[1] + HW.malgo2[MainForm0.mFn].slt_r[1]))
					{
						listBox_StackAll.Items.Add(num.ToString());
						num++;
					}
					else
					{
						listBox_StackAll.Items.Add(" ");
					}
				}
				else if (i >= 3 && (i - 3) % 4 == 0)
				{
					int num4 = (i - 3) / 4 + 1;
					if (num4 <= HW.malgo2[MainForm0.mFn].slt_l[0] || num4 >= HW.malgo2[MainForm0.mFn].slt_l[0] + 1 + HW.malgo2[MainForm0.mFn].emp_m[0])
					{
						listBox_StackAll.Items.Add(((num4 < 10 || (num4 >= 10 && num2 < 10)) ? "0" : "") + num2);
						num2++;
					}
					else
					{
						listBox_StackAll.Items.Add(" ");
					}
				}
				else
				{
					listBox_StackAll.Items.Add(" ");
				}
			}
			listBox_StackAll.SelectedIndex = StackListBoxIndex(mStackLib.index[0]);
		}

		private void listBox_StackAll_MouseClick(object sender, MouseEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			int selectedIndex = listBox.SelectedIndex;
			int num = StackNo(selectedIndex);
			if (num == -1)
			{
				listBox.SelectedIndex = StackListBoxIndex(mStackLib.index[0]);
				return;
			}
			mStackLib.index[0] = num;
			if (callback_flush_feederno != null)
			{
				callback_flush_feederno();
			}
			Dispose();
		}

		private void Form_LabProvider_feedersel_MouseLeave(object sender, EventArgs e)
		{
			Dispose();
		}

		private void listBox_StackAll_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
			{
				return;
			}
			int num = StackNo(e.Index);
			if (num != -1)
			{
				e.DrawBackground();
				if (mStackLib.stacktab[0][num].mSelected)
				{
					Brush black = Brushes.Black;
					e.DrawFocusRectangle();
					e.Graphics.DrawString(listBox_StackAll.Items[e.Index].ToString(), new Font(e.Font, FontStyle.Bold), black, e.Bounds, StringFormat.GenericTypographic);
				}
				else
				{
					Brush black = Brushes.Gray;
					e.DrawFocusRectangle();
					e.Graphics.DrawString(listBox_StackAll.Items[e.Index].ToString(), e.Font, black, e.Bounds, StringFormat.GenericTypographic);
				}
			}
		}

		public int StackListBoxIndex(int stackNo)
		{
			if (stackNo + 1 >= HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + 1 && stackNo + 1 <= HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + HW.malgo2[MainForm0.mFn].slt_l[1])
			{
				return (stackNo + 1 - (HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + 1)) * 4;
			}
			if (stackNo + 1 >= HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + HW.malgo2[MainForm0.mFn].slt_l[1] + 1)
			{
				return (stackNo + 1 - (HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + 1) + HW.malgo2[MainForm0.mFn].emp_m[1]) * 4;
			}
			if (stackNo + 1 <= HW.malgo2[MainForm0.mFn].slt_l[0])
			{
				return (stackNo + 1 - 1) * 4 + 3;
			}
			return (stackNo + 1 + HW.malgo2[MainForm0.mFn].emp_m[0] - 1) * 4 + 3;
		}

		public int StackNo(int index)
		{
			if (index % 4 == 0)
			{
				int num = index / 4;
				if (num < HW.malgo2[MainForm0.mFn].slt_l[1])
				{
					return HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + num;
				}
				if (num >= HW.malgo2[MainForm0.mFn].slt_l[1] + HW.malgo2[MainForm0.mFn].emp_m[1] && num < HW.malgo2[MainForm0.mFn].slt_l[1] + HW.malgo2[MainForm0.mFn].emp_m[1] + HW.malgo2[MainForm0.mFn].slt_r[1])
				{
					return HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0] + num - HW.malgo2[MainForm0.mFn].emp_m[1];
				}
			}
			else if (index >= 3 && (index - 3) % 4 == 0)
			{
				int num2 = (index - 3) / 4;
				if (num2 < HW.malgo2[MainForm0.mFn].slt_l[0])
				{
					return num2;
				}
				if (num2 >= HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].emp_m[0])
				{
					return num2 - HW.malgo2[MainForm0.mFn].emp_m[0];
				}
			}
			return -1;
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
			listBox_StackAll = new System.Windows.Forms.ListBox();
			SuspendLayout();
			listBox_StackAll.ColumnWidth = 26;
			listBox_StackAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			listBox_StackAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15f);
			listBox_StackAll.FormattingEnabled = true;
			listBox_StackAll.ItemHeight = 23;
			listBox_StackAll.Location = new System.Drawing.Point(12, 11);
			listBox_StackAll.MultiColumn = true;
			listBox_StackAll.Name = "listBox_StackAll";
			listBox_StackAll.Size = new System.Drawing.Size(1250, 73);
			listBox_StackAll.TabIndex = 1;
			listBox_StackAll.MouseClick += new System.Windows.Forms.MouseEventHandler(listBox_StackAll_MouseClick);
			listBox_StackAll.DrawItem += new System.Windows.Forms.DrawItemEventHandler(listBox_StackAll_DrawItem);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			base.Controls.Add(listBox_StackAll);
			base.Name = "UserControl_Stack_feedersel";
			base.Size = new System.Drawing.Size(1274, 94);
			base.MouseLeave += new System.EventHandler(Form_LabProvider_feedersel_MouseLeave);
			ResumeLayout(false);
		}
	}
}
