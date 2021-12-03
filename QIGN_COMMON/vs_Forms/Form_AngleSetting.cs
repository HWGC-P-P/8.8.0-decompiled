using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_AngleSetting : Form
	{
		private USR_DATA USR;

		private USR2_DATA USR2;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		private IContainer components;

		private Label label1;

		private Button button_Angle180_Run;

		private Label label2;

		private Button button_AngleReset;

		private CheckBox checkBox_180degree_forbackfeeder;

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
		}

		public Form_AngleSetting(USR_DATA usr, USR2_DATA usr2)
		{
			InitializeComponent();
			USR = usr;
			USR2 = usr2;
			initLanguageTable();
			updateLanguage(MainForm0.USR_INIT.mLanguage);
			checkBox_180degree_forbackfeeder.Checked = USR2.mIs180DegreeReverse_forbackfeeder;
		}

		private void button_AngleReset_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button_Angle180_Run_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void checkBox_180degree_forbackfeeder_CheckedChanged(object sender, EventArgs e)
		{
			USR2.mIs180DegreeReverse_forbackfeeder = checkBox_180degree_forbackfeeder.Checked;
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
			label1 = new System.Windows.Forms.Label();
			button_Angle180_Run = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			button_AngleReset = new System.Windows.Forms.Button();
			checkBox_180degree_forbackfeeder = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(160, 215);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(339, 19);
			label1.TabIndex = 0;
			label1.Text = "对侧的飞达上的元件添加180度的偏移";
			button_Angle180_Run.BackColor = System.Drawing.Color.Firebrick;
			button_Angle180_Run.Font = new System.Drawing.Font("黑体", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Angle180_Run.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			button_Angle180_Run.Location = new System.Drawing.Point(349, 242);
			button_Angle180_Run.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_Angle180_Run.Name = "button_Angle180_Run";
			button_Angle180_Run.Size = new System.Drawing.Size(177, 39);
			button_Angle180_Run.TabIndex = 1;
			button_Angle180_Run.Text = "一键修改角度";
			button_Angle180_Run.UseVisualStyleBackColor = false;
			button_Angle180_Run.Click += new System.EventHandler(button_Angle180_Run_Click);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 14.25f);
			label2.Location = new System.Drawing.Point(12, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(89, 19);
			label2.TabIndex = 0;
			label2.Text = "角度规则";
			button_AngleReset.Font = new System.Drawing.Font("黑体", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_AngleReset.Location = new System.Drawing.Point(120, 242);
			button_AngleReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_AngleReset.Name = "button_AngleReset";
			button_AngleReset.Size = new System.Drawing.Size(174, 39);
			button_AngleReset.TabIndex = 1;
			button_AngleReset.Text = "一键恢复角度";
			button_AngleReset.UseVisualStyleBackColor = true;
			button_AngleReset.Click += new System.EventHandler(button_AngleReset_Click);
			checkBox_180degree_forbackfeeder.AutoSize = true;
			checkBox_180degree_forbackfeeder.Font = new System.Drawing.Font("楷体", 13.25f);
			checkBox_180degree_forbackfeeder.Location = new System.Drawing.Point(88, 41);
			checkBox_180degree_forbackfeeder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			checkBox_180degree_forbackfeeder.Name = "checkBox_180degree_forbackfeeder";
			checkBox_180degree_forbackfeeder.Size = new System.Drawing.Size(486, 22);
			checkBox_180degree_forbackfeeder.TabIndex = 2;
			checkBox_180degree_forbackfeeder.Text = "取料时，对侧普通飞达自动旋转180度（不配置振动飞达）";
			checkBox_180degree_forbackfeeder.UseVisualStyleBackColor = true;
			checkBox_180degree_forbackfeeder.CheckedChanged += new System.EventHandler(checkBox_180degree_forbackfeeder_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(661, 104);
			base.Controls.Add(checkBox_180degree_forbackfeeder);
			base.Controls.Add(button_AngleReset);
			base.Controls.Add(button_Angle180_Run);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			base.Name = "Form_AngleSetting";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
