using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_ProviderSetting : Form
	{
		private IContainer components;

		private Label label1;

		private CheckBox checkBox_hoffsetmode;

		private CheckBox checkBox_vacuumlater;

		private CheckBox checkBox_auto180;

		private Button button_ok;

		private Button button_cancel;

		public USR2_DATA USR2;

		public bool mIsHOffsetMode;

		public bool mIsVacuumLater;

		public bool mIsAuto180;

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
			checkBox_hoffsetmode = new System.Windows.Forms.CheckBox();
			checkBox_vacuumlater = new System.Windows.Forms.CheckBox();
			checkBox_auto180 = new System.Windows.Forms.CheckBox();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(118, 26);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(129, 20);
			label1.TabIndex = 0;
			label1.Text = "料站特别配置";
			checkBox_hoffsetmode.AutoSize = true;
			checkBox_hoffsetmode.ForeColor = System.Drawing.Color.White;
			checkBox_hoffsetmode.Location = new System.Drawing.Point(60, 89);
			checkBox_hoffsetmode.Name = "checkBox_hoffsetmode";
			checkBox_hoffsetmode.Size = new System.Drawing.Size(187, 20);
			checkBox_hoffsetmode.TabIndex = 1;
			checkBox_hoffsetmode.Text = "取料贴装高度偏移模式";
			checkBox_hoffsetmode.UseVisualStyleBackColor = true;
			checkBox_vacuumlater.AutoSize = true;
			checkBox_vacuumlater.ForeColor = System.Drawing.Color.White;
			checkBox_vacuumlater.Location = new System.Drawing.Point(60, 115);
			checkBox_vacuumlater.Name = "checkBox_vacuumlater";
			checkBox_vacuumlater.Size = new System.Drawing.Size(123, 20);
			checkBox_vacuumlater.TabIndex = 1;
			checkBox_vacuumlater.Text = "不提前备真空";
			checkBox_vacuumlater.UseVisualStyleBackColor = true;
			checkBox_auto180.AutoSize = true;
			checkBox_auto180.ForeColor = System.Drawing.Color.White;
			checkBox_auto180.Location = new System.Drawing.Point(60, 141);
			checkBox_auto180.Name = "checkBox_auto180";
			checkBox_auto180.Size = new System.Drawing.Size(195, 20);
			checkBox_auto180.TabIndex = 1;
			checkBox_auto180.Text = "对侧料站自动旋转180度";
			checkBox_auto180.UseVisualStyleBackColor = true;
			button_ok.Location = new System.Drawing.Point(48, 251);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(93, 35);
			button_ok.TabIndex = 2;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Location = new System.Drawing.Point(209, 251);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(93, 35);
			button_cancel.TabIndex = 2;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(379, 348);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(checkBox_auto180);
			base.Controls.Add(checkBox_vacuumlater);
			base.Controls.Add(checkBox_hoffsetmode);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_ProviderSetting";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_ProviderSetting_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_ProviderSetting(USR2_DATA usr2)
		{
			InitializeComponent();
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			USR2 = usr2;
			checkBox_auto180.Checked = USR2.mIs180DegreeReverse_forbackfeeder;
			checkBox_hoffsetmode.Checked = USR2.mIsHOffsetMode;
			checkBox_vacuumlater.Checked = USR2.mIsPrepareVacuumLater;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "料站特别配置", "料站特別配置", "Special Configuration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_hoffsetmode,
				str = new string[3] { "取料贴装高度偏移模式", "取料貼裝高度偏移模式", "Pick/Mount Height in Offset Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_vacuumlater,
				str = new string[3] { "不提前备真空", "不提前备真空", "Not to open vacuum advanced" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_auto180,
				str = new string[3] { "对侧料站自动旋转180度", "對側料站自動旋轉180度", "Back Feeder auto run 180 degree angle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cancel,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok,
				str = new string[3] { "确定", "確定", "OK" }
			});
			return list;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			mIsHOffsetMode = checkBox_hoffsetmode.Checked;
			mIsVacuumLater = checkBox_vacuumlater.Checked;
			mIsAuto180 = checkBox_auto180.Checked;
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		public bool get_hoffsetmode()
		{
			return mIsHOffsetMode;
		}

		public bool get_vacuumlater()
		{
			return mIsVacuumLater;
		}

		public bool get_auto180()
		{
			return mIsAuto180;
		}

		private void Form_ProviderSetting_Load(object sender, EventArgs e)
		{
		}
	}
}
