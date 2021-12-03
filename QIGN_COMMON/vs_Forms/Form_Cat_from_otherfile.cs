using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_Cat_from_otherfile : Form
	{
		private int line_index;

		private BindingList<Label> label_item_list;

		private BindingList<CheckBox> checkBox_forbidden_list;

		private int mFn;

		private USR_INIT_DATA USR_INIT;

		private IContainer components;

		private Label label1;

		private Panel panel1;

		private CheckBox checkBox_forbidden_all;

		public Form_Cat_from_otherfile(int fn)
		{
			InitializeComponent();
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			line_index = 0;
			label_item_list = new BindingList<Label>();
			checkBox_forbidden_list = new BindingList<CheckBox>();
			mFn = fn;
			if (MainForm0.slotcatitems_from_otherfile_lists[mFn] == null)
			{
				MainForm0.slotcatitems_from_otherfile_lists[mFn] = new BindingList<slot_item_for_catfromotherfile>();
			}
		}

		private void Form_Cat_from_otherfile_Load(object sender, EventArgs e)
		{
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "从其他工程导入料站号和参数情况", "从其他工程导入料站号和参数情况", "Get Stack No and parameter from Other project file" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_forbidden_all,
				str = new string[3] { "禁用所有未匹配料站", "禁用所有未匹配料站", "Forbidden files that does not matched" }
			});
			return list;
		}

		public void clear_slotcatitems_from_otherfile_lists()
		{
			MainForm0.slotcatitems_from_otherfile_lists[mFn].Clear();
		}

		public void create_result(ProviderType provider, int feederno, string mvalue, string footprint, bool is_commit, bool is_forbidden, bool is_takeaway)
		{
			slot_item_for_catfromotherfile slot_item_for_catfromotherfile = new slot_item_for_catfromotherfile();
			slot_item_for_catfromotherfile.provider = provider;
			slot_item_for_catfromotherfile.feederno = feederno;
			slot_item_for_catfromotherfile.mvalue = mvalue;
			slot_item_for_catfromotherfile.footprint = footprint;
			slot_item_for_catfromotherfile.is_commit = is_commit;
			slot_item_for_catfromotherfile.is_takeaway = is_takeaway;
			MainForm0.slotcatitems_from_otherfile_lists[mFn].Add(slot_item_for_catfromotherfile);
			Panel panel = new Panel();
			panel1.Controls.Add(panel);
			panel.Size = new Size(500, 28);
			panel.Location = new Point(500 * (line_index / 30), 28 * (line_index % 30));
			Label label = new Label();
			panel.Controls.Add(label);
			label.Location = new Point(0, 0);
			label.Text = STR.PROVIDER_STR[(int)provider][MainForm0.USR_INIT.mLanguage] + " " + feederno;
			label.AutoSize = false;
			label.Size = new Size(60, 25);
			label.TextAlign = ContentAlignment.MiddleLeft;
			Label label2 = new Label();
			panel.Controls.Add(label2);
			label2.Location = new Point(70, 0);
			label2.Text = footprint + " " + mvalue;
			label2.AutoSize = false;
			label2.Size = new Size(110, 25);
			label2.TextAlign = ContentAlignment.MiddleLeft;
			label_item_list.Add(label2);
			string[] array = new string[3] { "导入成功！", "导入成功！", "Import Success!" };
			string[] array2 = new string[3] { "未匹配", "未匹配", "Not Match!" };
			Label label3 = new Label();
			panel.Controls.Add(label3);
			label3.Location = new Point(190, 0);
			label3.Text = "";
			label3.AutoSize = false;
			label3.Size = new Size(80, 25);
			label3.TextAlign = ContentAlignment.MiddleLeft;
			label3.Text = (is_commit ? array[USR_INIT.mLanguage] : array2[USR_INIT.mLanguage]);
			if (is_commit)
			{
				label2.BackColor = Color.Transparent;
			}
			else
			{
				label2.Visible = !is_takeaway;
				label2.BackColor = Color.LightGray;
				if (provider == ProviderType.Feedr)
				{
					string[] array3 = new string[3] { "是否禁用", "是否禁用", "Is Disabled" };
					CheckBox checkBox = new CheckBox();
					panel.Controls.Add(checkBox);
					checkBox.Location = new Point(260, 0);
					checkBox.AutoSize = false;
					checkBox.Size = new Size(90, 25);
					checkBox.TextAlign = ContentAlignment.MiddleLeft;
					checkBox.Text = array3[USR_INIT.mLanguage];
					checkBox.CheckedChanged += cb_forbidden_CheckedChanged;
					checkBox.Tag = line_index;
					checkBox.BringToFront();
					checkBox_forbidden_list.Add(checkBox);
					int si = 0;
					int p = 0;
					MainForm0.format_stackno(MainForm0.mFn, feederno - 1, ref si, ref p);
					if (MainForm0.USR3B[mFn].isSlotBrkn[si][p] == 1f)
					{
						checkBox.Checked = true;
						label2.BackColor = Color.DimGray;
					}
					else
					{
						checkBox.Checked = false;
					}
					label2.Enabled = !checkBox.Checked;
				}
				string[] array4 = new string[3] { "是否取走", "是否取走", "Is taken away" };
				CheckBox checkBox2 = new CheckBox();
				panel.Controls.Add(checkBox2);
				checkBox2.Location = new Point(340, 0);
				checkBox2.AutoSize = false;
				checkBox2.Size = new Size(90, 25);
				checkBox2.TextAlign = ContentAlignment.MiddleLeft;
				checkBox2.Text = array4[USR_INIT.mLanguage];
				checkBox2.Checked = is_takeaway;
				checkBox2.Tag = line_index;
				checkBox2.BringToFront();
				checkBox2.CheckedChanged += cb_takeaway_CheckedChanged;
			}
			line_index++;
		}

		public void show_allresult()
		{
			if (MainForm0.slotcatitems_from_otherfile_lists[mFn] == null)
			{
				return;
			}
			for (int i = 0; i < MainForm0.slotcatitems_from_otherfile_lists[mFn].Count; i++)
			{
				slot_item_for_catfromotherfile slot_item_for_catfromotherfile = MainForm0.slotcatitems_from_otherfile_lists[mFn][i];
				Panel panel = new Panel();
				panel1.Controls.Add(panel);
				panel.Size = new Size(500, 28);
				panel.Location = new Point(500 * (i / 30), 28 * (i % 30));
				Label label = new Label();
				panel.Controls.Add(label);
				label.Location = new Point(0, 5);
				label.Text = STR.PROVIDER_STR[(int)slot_item_for_catfromotherfile.provider][MainForm0.USR_INIT.mLanguage] + " " + slot_item_for_catfromotherfile.feederno;
				label.AutoSize = false;
				label.Size = new Size(60, 25);
				label.TextAlign = ContentAlignment.MiddleLeft;
				Label label2 = new Label();
				panel.Controls.Add(label2);
				label2.Location = new Point(70, 0);
				label2.Text = slot_item_for_catfromotherfile.footprint + " " + slot_item_for_catfromotherfile.mvalue;
				label2.AutoSize = false;
				label2.Size = new Size(110, 25);
				label2.TextAlign = ContentAlignment.MiddleLeft;
				label_item_list.Add(label2);
				string[] array = new string[3] { "导入成功！", "导入成功！", "Import Success!" };
				string[] array2 = new string[3] { "未匹配", "未匹配", "Not Match!" };
				Label label3 = new Label();
				panel.Controls.Add(label3);
				label3.Location = new Point(190, 0);
				label3.Text = "";
				label3.AutoSize = false;
				label3.Size = new Size(80, 25);
				label3.TextAlign = ContentAlignment.MiddleLeft;
				label3.Text = (slot_item_for_catfromotherfile.is_commit ? array[USR_INIT.mLanguage] : array2[USR_INIT.mLanguage]);
				if (slot_item_for_catfromotherfile.is_commit)
				{
					label2.BackColor = Color.Transparent;
					continue;
				}
				label2.Visible = !slot_item_for_catfromotherfile.is_takeaway;
				label2.BackColor = Color.LightGray;
				if (slot_item_for_catfromotherfile.provider == ProviderType.Feedr)
				{
					string[] array3 = new string[3] { "是否禁用", "是否禁用", "Is Disabled" };
					CheckBox checkBox = new CheckBox();
					panel.Controls.Add(checkBox);
					checkBox.Location = new Point(260, 0);
					checkBox.AutoSize = false;
					checkBox.Size = new Size(90, 25);
					checkBox.TextAlign = ContentAlignment.MiddleLeft;
					checkBox.Text = array3[USR_INIT.mLanguage];
					checkBox.CheckedChanged += cb_forbidden_CheckedChanged;
					checkBox.Tag = i;
					checkBox.BringToFront();
					checkBox_forbidden_list.Add(checkBox);
					int si = 0;
					int p = 0;
					MainForm0.format_stackno(MainForm0.mFn, slot_item_for_catfromotherfile.feederno - 1, ref si, ref p);
					if (MainForm0.USR3B[mFn].isSlotBrkn[si][p] == 1f)
					{
						checkBox.Checked = true;
						label2.BackColor = Color.DimGray;
					}
					else
					{
						checkBox.Checked = false;
					}
					label2.Enabled = !checkBox.Checked;
				}
				string[] array4 = new string[3] { "是否取走", "是否取走", "Is taken away" };
				CheckBox checkBox2 = new CheckBox();
				panel.Controls.Add(checkBox2);
				checkBox2.Location = new Point(340, 0);
				checkBox2.AutoSize = false;
				checkBox2.Size = new Size(90, 25);
				checkBox2.TextAlign = ContentAlignment.MiddleLeft;
				checkBox2.Text = array4[USR_INIT.mLanguage];
				checkBox2.Checked = slot_item_for_catfromotherfile.is_takeaway;
				checkBox2.Tag = i;
				checkBox2.BringToFront();
				checkBox2.CheckedChanged += cb_takeaway_CheckedChanged;
			}
		}

		private void cb_takeaway_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			int index = (int)checkBox.Tag;
			label_item_list[index].Visible = !checkBox.Checked;
			slot_item_for_catfromotherfile slot_item_for_catfromotherfile = MainForm0.slotcatitems_from_otherfile_lists[mFn][index];
			slot_item_for_catfromotherfile.is_takeaway = checkBox.Checked;
		}

		private void cb_forbidden_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			int index = (int)checkBox.Tag;
			int feederno = MainForm0.slotcatitems_from_otherfile_lists[mFn][index].feederno;
			int si = 0;
			int p = 0;
			MainForm0.format_stackno(MainForm0.mFn, feederno - 1, ref si, ref p);
			MainForm0.USR3B[mFn].isSlotBrkn[si][p] = (checkBox.Checked ? 1 : 0);
			label_item_list[index].BackColor = (checkBox.Checked ? Color.DimGray : Color.LightGray);
		}

		private void checkBox_forbidden_all_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_forbidden_list != null)
			{
				for (int i = 0; i < checkBox_forbidden_list.Count; i++)
				{
					checkBox_forbidden_list[i].Checked = checkBox_forbidden_all.Checked;
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
			label1 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			checkBox_forbidden_all = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 15.5f);
			label1.Location = new System.Drawing.Point(46, 19);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(340, 21);
			label1.TabIndex = 0;
			label1.Text = "从其他工程导入料站号和参数情况";
			panel1.Location = new System.Drawing.Point(50, 82);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1167, 850);
			panel1.TabIndex = 1;
			checkBox_forbidden_all.AutoSize = true;
			checkBox_forbidden_all.Font = new System.Drawing.Font("黑体", 12.5f);
			checkBox_forbidden_all.Location = new System.Drawing.Point(361, 55);
			checkBox_forbidden_all.Name = "checkBox_forbidden_all";
			checkBox_forbidden_all.Size = new System.Drawing.Size(189, 21);
			checkBox_forbidden_all.TabIndex = 2;
			checkBox_forbidden_all.Text = "禁用所有未匹配料站";
			checkBox_forbidden_all.UseVisualStyleBackColor = true;
			checkBox_forbidden_all.CheckedChanged += new System.EventHandler(checkBox_forbidden_all_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1274, 944);
			base.Controls.Add(checkBox_forbidden_all);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_Cat_from_otherfile";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_Cat_from_otherfile_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
