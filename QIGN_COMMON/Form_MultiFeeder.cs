using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_MultiFeeder : Form
	{
		private int mMultifeeders = 1;

		private int[] mFeeder_No;

		private NumericUpDown[] nud_feederno;

		private ChipCategoryElement mElm;

		private int mMaxMulti = 4;

		private Panel[] panel_feederno;

		private CheckBox[] checkbox_feederno;

		private int mLanguage;

		private IContainer components;

		private NumericUpDown numericUpDown_multifeeder;

		private Label label1;

		private Panel panel_0;

		private Button button_OK;

		private Button button_Cancel;

		private Label label2;

		public Form_MultiFeeder(int language, ChipCategoryElement elm, int maxMulti, bool is_auto)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mLanguage = language;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			mMaxMulti = maxMulti;
			mElm = elm;
			mMultifeeders = elm.MultiFeeders;
			if (mMultifeeders < 1 || mMultifeeders > mMaxMulti)
			{
				mMultifeeders = 1;
			}
			numericUpDown_multifeeder.Maximum = mMaxMulti;
			numericUpDown_multifeeder.Value = mMultifeeders;
			mFeeder_No = new int[mMaxMulti];
			for (int i = 0; i < mMultifeeders; i++)
			{
				mFeeder_No[i] = 0;
			}
			nud_feederno = new NumericUpDown[mMaxMulti];
			panel_feederno = new Panel[mMaxMulti];
			checkbox_feederno = new CheckBox[mMaxMulti];
			for (int j = 0; j < mMaxMulti; j++)
			{
				Panel panel = new Panel();
				panel_0.Controls.Add(panel);
				panel.Size = new Size(300, 35);
				panel.Location = new Point(2, 38 * j);
				panel.BackColor = Color.NavajoWhite;
				panel.BorderStyle = BorderStyle.Fixed3D;
				panel.Visible = false;
				panel_feederno[j] = panel;
				Label label = new Label();
				panel.Controls.Add(label);
				label.Location = new Point(0, 0);
				label.Size = new Size(100, 25);
				label.Text = (new string[3] { "设置料站号", "設置料站號", "Set Feeder No" })[mLanguage];
				label.AutoSize = false;
				label.Font = new Font(DEF.FONT_2020[mLanguage], 12f, FontStyle.Regular);
				label.TextAlign = ContentAlignment.MiddleLeft;
				NumericUpDown numericUpDown = new NumericUpDown();
				panel.Controls.Add(numericUpDown);
				numericUpDown.Location = new Point(100, 0);
				numericUpDown.Value = 1m;
				numericUpDown.Enabled = false;
				numericUpDown.Size = new Size(80, 25);
				numericUpDown.Font = new Font(DEF.FONT_2020[mLanguage], 12f, FontStyle.Regular);
				nud_feederno[j] = numericUpDown;
				CheckBox checkBox = new CheckBox();
				panel.Controls.Add(checkBox);
				checkBox.Location = new Point(190, 0);
				checkBox.Size = new Size(120, 25);
				checkBox.AutoSize = false;
				checkBox.Text = (new string[3] { "自动优化", "自動優化", "Auto Assign" })[mLanguage];
				checkBox.Checked = true;
				checkBox.Tag = j;
				checkBox.Font = new Font(STR.LANGUAGE[mLanguage], 12f, FontStyle.Regular);
				checkBox.TextAlign = ContentAlignment.MiddleLeft;
				checkBox.CheckedChanged += cb_CheckedChanged;
				checkbox_feederno[j] = checkBox;
				mFeeder_No[j] = elm.feeder_no[j];
			}
			for (int k = 0; k < mMaxMulti; k++)
			{
				if (k < mMultifeeders)
				{
					checkbox_feederno[k].Checked = ((mElm.feeder_no[k] == 0) ? true : false);
					nud_feederno[k].Enabled = ((mElm.feeder_no[k] != 0) ? true : false);
					nud_feederno[k].Value = ((mElm.feeder_no[k] == 0) ? 1 : mElm.feeder_no[k]);
				}
				else
				{
					checkbox_feederno[k].Checked = true;
					nud_feederno[k].Enabled = false;
					nud_feederno[k].Value = 1m;
				}
				if (is_auto)
				{
					checkbox_feederno[k].Checked = false;
					checkbox_feederno[k].Enabled = false;
					nud_feederno[k].Enabled = false;
					nud_feederno[k].Value = 0m;
				}
			}
			for (int l = 0; l < mMaxMulti; l++)
			{
				panel_feederno[l].Visible = ((l < mMultifeeders) ? true : false);
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "多组供料", "多组供料", "Multi Feeders" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OK,
				str = new string[3] { "确定", "确定", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Cancel,
				str = new string[3] { "取消", "取消", "CANCEL" }
			});
			return list;
		}

		private void cb_CheckedChanged(object sender, EventArgs e)
		{
			int num = (int)((CheckBox)sender).Tag;
			if (((CheckBox)sender).Checked)
			{
				nud_feederno[num].Enabled = false;
			}
			else
			{
				nud_feederno[num].Enabled = true;
			}
		}

		private void numericUpDown_multifeeder_ValueChanged(object sender, EventArgs e)
		{
			if (panel_feederno != null)
			{
				mMultifeeders = (int)numericUpDown_multifeeder.Value;
				for (int i = 0; i < mMaxMulti; i++)
				{
					panel_feederno[i].Visible = ((i < mMultifeeders) ? true : false);
				}
			}
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			mElm.MultiFeeders = (int)numericUpDown_multifeeder.Value;
			for (int i = 0; i < mElm.MultiFeeders; i++)
			{
				mElm.feeder_no[i] = ((!checkbox_feederno[i].Checked) ? ((int)nud_feederno[i].Value) : 0);
			}
			base.DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Form_MultiFeeder_Load(object sender, EventArgs e)
		{
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
			numericUpDown_multifeeder = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			panel_0 = new System.Windows.Forms.Panel();
			button_OK = new System.Windows.Forms.Button();
			button_Cancel = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)numericUpDown_multifeeder).BeginInit();
			SuspendLayout();
			numericUpDown_multifeeder.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_multifeeder.Location = new System.Drawing.Point(15, 61);
			numericUpDown_multifeeder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			numericUpDown_multifeeder.Maximum = new decimal(new int[4] { 4, 0, 0, 0 });
			numericUpDown_multifeeder.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_multifeeder.Name = "numericUpDown_multifeeder";
			numericUpDown_multifeeder.Size = new System.Drawing.Size(77, 26);
			numericUpDown_multifeeder.TabIndex = 0;
			numericUpDown_multifeeder.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_multifeeder.ValueChanged += new System.EventHandler(numericUpDown_multifeeder_ValueChanged);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 15f);
			label1.Location = new System.Drawing.Point(22, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 20);
			label1.TabIndex = 1;
			label1.Text = "多组供料";
			panel_0.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_0.Location = new System.Drawing.Point(109, 61);
			panel_0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_0.Name = "panel_0";
			panel_0.Size = new System.Drawing.Size(339, 298);
			panel_0.TabIndex = 2;
			button_OK.Location = new System.Drawing.Point(132, 374);
			button_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(101, 28);
			button_OK.TabIndex = 3;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = true;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			button_Cancel.Location = new System.Drawing.Point(297, 374);
			button_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(101, 28);
			button_Cancel.TabIndex = 3;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = true;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			label2.BackColor = System.Drawing.Color.Red;
			label2.Location = new System.Drawing.Point(12, 47);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(501, 5);
			label2.TabIndex = 4;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.PapayaWhip;
			base.ClientSize = new System.Drawing.Size(533, 423);
			base.Controls.Add(label2);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(button_OK);
			base.Controls.Add(panel_0);
			base.Controls.Add(label1);
			base.Controls.Add(numericUpDown_multifeeder);
			Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			base.Name = "Form_MultiFeeder";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_MultiFeeder_Load);
			((System.ComponentModel.ISupportInitialize)numericUpDown_multifeeder).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
