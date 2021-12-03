using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_GenPcbListOptional : Form
	{
		private IContainer components;

		private Button button_importadd;

		private Button button_importoverlap;

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
			button_importadd = new System.Windows.Forms.Button();
			button_importoverlap = new System.Windows.Forms.Button();
			SuspendLayout();
			button_importadd.Font = new System.Drawing.Font("黑体", 18f);
			button_importadd.Location = new System.Drawing.Point(123, 65);
			button_importadd.Margin = new System.Windows.Forms.Padding(4);
			button_importadd.Name = "button_importadd";
			button_importadd.Size = new System.Drawing.Size(140, 103);
			button_importadd.TabIndex = 0;
			button_importadd.Text = "追加导入";
			button_importadd.UseVisualStyleBackColor = true;
			button_importadd.Click += new System.EventHandler(button_importadd_Click);
			button_importoverlap.Font = new System.Drawing.Font("黑体", 18f);
			button_importoverlap.Location = new System.Drawing.Point(366, 65);
			button_importoverlap.Margin = new System.Windows.Forms.Padding(4);
			button_importoverlap.Name = "button_importoverlap";
			button_importoverlap.Size = new System.Drawing.Size(142, 103);
			button_importoverlap.TabIndex = 0;
			button_importoverlap.Text = "覆盖导入";
			button_importoverlap.UseVisualStyleBackColor = true;
			button_importoverlap.Click += new System.EventHandler(button_importoverlap_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(673, 237);
			base.Controls.Add(button_importoverlap);
			base.Controls.Add(button_importadd);
			Font = new System.Drawing.Font("楷体", 9.75f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_GenPcbListOptional";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_GenPcbListOptional_Load);
			ResumeLayout(false);
		}

		public Form_GenPcbListOptional(int lan)
		{
			InitializeComponent();
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_importoverlap,
				str = new string[3] { "覆盖导入", "覆蓋導入", "Override Import" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_importadd,
				str = new string[3] { "追加导入", "追加導入", "Add Import" }
			});
			return list;
		}

		private void button_importoverlap_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Retry;
		}

		private void button_importadd_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void Form_GenPcbListOptional_Load(object sender, EventArgs e)
		{
		}
	}
}
