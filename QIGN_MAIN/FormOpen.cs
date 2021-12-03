using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON;

namespace QIGN_MAIN
{
	public class FormOpen : Form
	{
		private IContainer components;

		private Button button_open;

		private Button button_create;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.FormOpen));
			button_open = new System.Windows.Forms.Button();
			button_create = new System.Windows.Forms.Button();
			SuspendLayout();
			button_open.Font = new System.Drawing.Font("黑体", 14.25f);
			button_open.Location = new System.Drawing.Point(422, 58);
			button_open.Name = "button_open";
			button_open.Size = new System.Drawing.Size(136, 117);
			button_open.TabIndex = 2;
			button_open.Text = "打开工程";
			button_open.UseVisualStyleBackColor = true;
			button_open.Click += new System.EventHandler(button_open_Click);
			button_create.Font = new System.Drawing.Font("黑体", 14.25f);
			button_create.Location = new System.Drawing.Point(126, 58);
			button_create.Name = "button_create";
			button_create.Size = new System.Drawing.Size(136, 117);
			button_create.TabIndex = 2;
			button_create.Text = "新建工程";
			button_create.UseVisualStyleBackColor = true;
			button_create.Click += new System.EventHandler(button_create_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(716, 236);
			base.Controls.Add(button_create);
			base.Controls.Add(button_open);
			Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "FormOpen";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
		}

		public FormOpen(int mLanguage)
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
				ctrl = button_create,
				str = new string[3]
				{
					"创建工程",
					"創建工程",
					"CREATE" + Environment.NewLine + "PRJECT"
				}
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_open,
				str = new string[3]
				{
					"打开工程",
					"打開工程",
					"OPEN" + Environment.NewLine + "PROJECT"
				}
			});
		}

		private void button_open_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button_create_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Retry;
		}
	}
}
