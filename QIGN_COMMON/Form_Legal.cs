using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_Legal : Form
	{
		private IContainer components;

		private TextBox textBox_Msg;

		private Label label1;

		private BindingList<ChipBoardElement> mPointList;

		private string[] mMsg = new string[0];

		private int mLanguage;

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
			textBox_Msg = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			textBox_Msg.BackColor = System.Drawing.Color.Snow;
			textBox_Msg.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox_Msg.Location = new System.Drawing.Point(5, 39);
			textBox_Msg.Multiline = true;
			textBox_Msg.Name = "textBox_Msg";
			textBox_Msg.ReadOnly = true;
			textBox_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_Msg.Size = new System.Drawing.Size(859, 501);
			textBox_Msg.TabIndex = 0;
			label1.BackColor = System.Drawing.Color.Red;
			label1.Font = new System.Drawing.Font("黑体", 14.25f);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(4, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(860, 29);
			label1.TabIndex = 3;
			label1.Text = "合法性检测结果";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightBlue;
			base.ClientSize = new System.Drawing.Size(869, 551);
			base.Controls.Add(label1);
			base.Controls.Add(textBox_Msg);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_Legal";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.TopMost = true;
			base.Load += new System.EventHandler(Form_Legal_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_Legal(int language, BindingList<ChipBoardElement> pointlist, string[] msg)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			mLanguage = language;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			mPointList = pointlist;
			mMsg = msg;
			textBox_Msg.Text = mMsg[0];
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "合法性检测结果", "合法性检测结果", "Validity Checking Result" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = this,
				str = new string[3] { "", "", "" }
			});
			return list;
		}

		private void Form_Legal_Load(object sender, EventArgs e)
		{
		}
	}
}
