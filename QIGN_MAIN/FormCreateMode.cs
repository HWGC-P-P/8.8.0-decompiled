using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON;

namespace QIGN_MAIN
{
	public class FormCreateMode : Form
	{
		public delegate void FuntionVoidHandler();

		private IContainer components;

		private Button button_manual;

		private Button button_import;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.FormCreateMode));
			button_manual = new System.Windows.Forms.Button();
			button_import = new System.Windows.Forms.Button();
			SuspendLayout();
			button_manual.Font = new System.Drawing.Font("黑体", 14.25f);
			button_manual.Location = new System.Drawing.Point(61, 104);
			button_manual.Name = "button_manual";
			button_manual.Size = new System.Drawing.Size(225, 62);
			button_manual.TabIndex = 3;
			button_manual.Text = "手工编辑坐标方式";
			button_manual.UseVisualStyleBackColor = true;
			button_manual.Click += new System.EventHandler(button_manual_Click);
			button_import.Font = new System.Drawing.Font("黑体", 14.25f);
			button_import.Location = new System.Drawing.Point(353, 104);
			button_import.Name = "button_import";
			button_import.Size = new System.Drawing.Size(231, 62);
			button_import.TabIndex = 3;
			button_import.Text = "导入坐标文件方式";
			button_import.UseVisualStyleBackColor = true;
			button_import.Click += new System.EventHandler(button_import_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(11f, 25f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(673, 262);
			base.Controls.Add(button_import);
			base.Controls.Add(button_manual);
			Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(6);
			base.Name = "FormCreateMode";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
		}

		public FormCreateMode(int mLanguage)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			initLanguageTable();
			updateLanguage(mLanguage);
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
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_manual,
				str = new string[3] { "手工编辑坐标方式", "手工编辑坐标方式", "MANUAL EDIT" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_import,
				str = new string[3] { "导入坐标文件方式", "导入坐标文件方式", "IMPORT PCB FILE" }
			});
		}

		private void button_manual_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Retry;
		}

		private void button_import_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}
	}
}
