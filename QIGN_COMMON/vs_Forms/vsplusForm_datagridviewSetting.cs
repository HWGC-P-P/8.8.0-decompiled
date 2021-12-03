using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class vsplusForm_datagridviewSetting : Form
	{
		private IContainer components;

		private Label label1;

		private CheckBox checkBox_EditXY;

		private Button button_ok;

		private Button button_cancel;

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
			checkBox_EditXY = new System.Windows.Forms.CheckBox();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14f);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(192, 27);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 19);
			label1.TabIndex = 0;
			label1.Text = "其他设置";
			checkBox_EditXY.AutoSize = true;
			checkBox_EditXY.ForeColor = System.Drawing.Color.White;
			checkBox_EditXY.Location = new System.Drawing.Point(190, 93);
			checkBox_EditXY.Name = "checkBox_EditXY";
			checkBox_EditXY.Size = new System.Drawing.Size(91, 20);
			checkBox_EditXY.TabIndex = 1;
			checkBox_EditXY.Text = "坐标编辑";
			checkBox_EditXY.UseVisualStyleBackColor = true;
			checkBox_EditXY.CheckedChanged += new System.EventHandler(checkBox_EditXY_CheckedChanged);
			button_ok.Location = new System.Drawing.Point(91, 148);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(79, 27);
			button_ok.TabIndex = 2;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Location = new System.Drawing.Point(284, 148);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(79, 27);
			button_cancel.TabIndex = 2;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.DimGray;
			base.ClientSize = new System.Drawing.Size(487, 212);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(checkBox_EditXY);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "vsplusForm_datagridviewSetting";
			base.Load += new System.EventHandler(vsplusForm_datagridviewSetting_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public vsplusForm_datagridviewSetting(bool isedit_xy)
		{
			InitializeComponent();
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			checkBox_EditXY.Checked = isedit_xy;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "其它设置", "其它設置", "Other Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_EditXY,
				str = new string[3] { "元件编辑", "元件編輯", "Chip Edit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok,
				str = new string[3] { "确认", "其它設置", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cancel,
				str = new string[3] { "取消", "其它設置", "Cancel" }
			});
			return list;
		}

		private void checkBox_EditXY_CheckedChanged(object sender, EventArgs e)
		{
		}

		public bool GetEdit_XY()
		{
			return checkBox_EditXY.Checked;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void vsplusForm_datagridviewSetting_Load(object sender, EventArgs e)
		{
		}
	}
}
