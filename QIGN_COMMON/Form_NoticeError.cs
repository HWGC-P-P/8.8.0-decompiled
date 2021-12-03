using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_NoticeError : Form
	{
		private IContainer components;

		private Label label1;

		private Button button_OK;

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
			label1 = new System.Windows.Forms.Label();
			button_OK = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.Font = new System.Drawing.Font("微软雅黑", 14f, System.Drawing.FontStyle.Bold);
			label1.Location = new System.Drawing.Point(79, 49);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(372, 32);
			label1.TabIndex = 0;
			label1.Text = "系统出现异常，需要重启软件";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_OK.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_OK.Location = new System.Drawing.Point(201, 113);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(126, 37);
			button_OK.TabIndex = 1;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = true;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.AntiqueWhite;
			base.ClientSize = new System.Drawing.Size(533, 173);
			base.Controls.Add(button_OK);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Form_NoticeError";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.TopMost = true;
			ResumeLayout(false);
		}

		public Form_NoticeError(int mLanguage, string str)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			initLanguageTable();
			updateLanguage(mLanguage);
			label1.Text = str;
		}

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
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
				ctrl = label1,
				str = new string[3] { "系统出现异常，需要重启软件", "系统出现异常，需要重启软件", "EXCEPTION HAPPENS, PLEASE RESTART APPICATION" }
			});
			mLanguageList.Add(new LanguageItem
			{
				ctrl = button_OK,
				str = new string[3] { "确定", "确定", "OK" }
			});
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
