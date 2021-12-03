using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_optimizeNotice : Form
	{
		private IContainer components;

		private Button button_all;

		private Button button_some;

		private Button button_cancle;

		private Label label1;

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
			button_all = new System.Windows.Forms.Button();
			button_some = new System.Windows.Forms.Button();
			button_cancle = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			button_all.BackColor = System.Drawing.Color.PeachPuff;
			button_all.Font = new System.Drawing.Font("黑体", 13f);
			button_all.Location = new System.Drawing.Point(56, 110);
			button_all.Name = "button_all";
			button_all.Size = new System.Drawing.Size(110, 68);
			button_all.TabIndex = 0;
			button_all.Text = "所有项目重新优化";
			button_all.UseVisualStyleBackColor = false;
			button_all.Click += new System.EventHandler(button_all_Click);
			button_some.BackColor = System.Drawing.Color.PeachPuff;
			button_some.Font = new System.Drawing.Font("黑体", 13f);
			button_some.Location = new System.Drawing.Point(196, 110);
			button_some.Name = "button_some";
			button_some.Size = new System.Drawing.Size(296, 68);
			button_some.TabIndex = 0;
			button_some.Text = "对未分配料站的项目进行优化";
			button_some.UseVisualStyleBackColor = false;
			button_some.Click += new System.EventHandler(button_some_Click);
			button_cancle.BackColor = System.Drawing.Color.LightSteelBlue;
			button_cancle.Font = new System.Drawing.Font("黑体", 13f);
			button_cancle.Location = new System.Drawing.Point(519, 110);
			button_cancle.Name = "button_cancle";
			button_cancle.Size = new System.Drawing.Size(89, 68);
			button_cancle.TabIndex = 0;
			button_cancle.Text = "取消";
			button_cancle.UseVisualStyleBackColor = false;
			button_cancle.Click += new System.EventHandler(button_cancle_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14f);
			label1.Location = new System.Drawing.Point(52, 46);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(429, 19);
			label1.TabIndex = 1;
			label1.Text = "部分料站已分配好，请选择以下不同的优化方式";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LightSalmon;
			base.ClientSize = new System.Drawing.Size(673, 213);
			base.Controls.Add(label1);
			base.Controls.Add(button_cancle);
			base.Controls.Add(button_some);
			base.Controls.Add(button_all);
			Font = new System.Drawing.Font("楷体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_optimizeNotice";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_optimizeNotice_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_optimizeNotice(int mLanguage)
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
					mLanguage2.ctrl.Font = new Font(mLanguage2.font[mLanguage], mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
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
				ctrl = label1,
				str = new string[3] { "部分料站已分配好，请选择以下不同的优化方式", "部分料站已分配好，请选择以下不同的优化方式", "Please select different option:" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_all,
				str = new string[3]
				{
					"所有项目" + Environment.NewLine + "重新优化",
					"所有项目" + Environment.NewLine + "重新优化",
					"Optimize " + Environment.NewLine + "All Items"
				}
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_some,
				str = new string[3]
				{
					"未分配料站的项目" + Environment.NewLine + "进行优化",
					"未分配料站的项目" + Environment.NewLine + "进行优化",
					"Optimize " + Environment.NewLine + "Un-Assigned Items"
				}
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cancle,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
		}

		private void button_all_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button_some_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
		}

		private void button_cancle_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Form_optimizeNotice_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_all);
			MainForm0.CreateAddButtonPic(button_some);
			MainForm0.CreateAddButtonPic(button_cancle);
		}
	}
}
