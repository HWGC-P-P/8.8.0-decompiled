using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_BoxSel : Form
	{
		private IContainer components;

		private CnButton button1;

		private CnButton button2;

		private Label label1;

		private Label label2;

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
			button1 = new QIGN_COMMON.vs_acontrol.CnButton();
			button2 = new QIGN_COMMON.vs_acontrol.CnButton();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			SuspendLayout();
			button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			button1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button1.CnPressDownColor = System.Drawing.Color.White;
			button1.Font = new System.Drawing.Font("黑体", 15.5f);
			button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			button1.Location = new System.Drawing.Point(75, 104);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(212, 69);
			button1.TabIndex = 0;
			button1.Text = "来自封装库";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			button2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button2.CnPressDownColor = System.Drawing.Color.White;
			button2.Font = new System.Drawing.Font("黑体", 15.5f);
			button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			button2.Location = new System.Drawing.Point(380, 104);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(204, 69);
			button2.TabIndex = 0;
			button2.Text = "更新到封装库";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(button2_Click_1);
			label1.Font = new System.Drawing.Font("黑体", 14.5f);
			label1.Location = new System.Drawing.Point(3, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(680, 80);
			label1.TabIndex = 1;
			label1.Text = "label1";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(72, 213);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 16);
			label2.TabIndex = 2;
			label2.Text = "label2";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(682, 259);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			Font = new System.Drawing.Font("黑体", 11.5f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_BoxSel";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_BoxSel_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_BoxSel(string title, string left, string right, string note)
		{
			InitializeComponent();
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			label1.Text = title;
			button1.Text = left;
			button2.Text = right;
			label2.Text = note;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			LanguageItem languageItem2 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button1
			};
			string[] array2 = (languageItem2.str = new string[3]);
			list.Add(languageItem2);
			LanguageItem languageItem3 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button2
			};
			string[] array3 = (languageItem3.str = new string[3]);
			list.Add(languageItem3);
			LanguageItem languageItem4 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2
			};
			string[] array4 = (languageItem4.str = new string[3]);
			list.Add(languageItem4);
			return list;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void Form_BoxSel_Load(object sender, EventArgs e)
		{
		}
	}
}
