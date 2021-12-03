using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_WarningAlarmSetting : Form
	{
		public RadioButton[] radiobutton_warningmode;

		public USR_INIT_DATA USR_INIT;

		private IContainer components;

		private Label label1;

		private Panel panel1;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		public Form_WarningAlarmSetting()
		{
			InitializeComponent();
			USR_INIT = MainForm0.USR_INIT;
			radiobutton_warningmode = new RadioButton[2] { radioButton1, radioButton2 };
			for (int i = 0; i < radiobutton_warningmode.Count(); i++)
			{
				radiobutton_warningmode[i].Tag = i;
			}
			radiobutton_warningmode[USR_INIT.mWarningAlarmMode].Checked = true;
			for (int j = 0; j < radiobutton_warningmode.Count(); j++)
			{
				radiobutton_warningmode[j].CheckedChanged += radioButton1_CheckedChanged;
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			int mWarningAlarmMode = (int)radioButton.Tag;
			if (radioButton.Checked)
			{
				USR_INIT.mWarningAlarmMode = mWarningAlarmMode;
				MainForm0.set_warningalarm_idle();
			}
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
			panel1 = new System.Windows.Forms.Panel();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			panel1.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14.5f);
			label1.Location = new System.Drawing.Point(214, 26);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(109, 20);
			label1.TabIndex = 0;
			label1.Text = "报警灯设置";
			panel1.Controls.Add(radioButton2);
			panel1.Controls.Add(radioButton1);
			panel1.Location = new System.Drawing.Point(51, 72);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(454, 88);
			panel1.TabIndex = 1;
			radioButton2.AutoSize = true;
			radioButton2.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton2.Location = new System.Drawing.Point(28, 43);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(346, 20);
			radioButton2.TabIndex = 0;
			radioButton2.TabStop = true;
			radioButton2.Text = "待机中黄灯亮，运行中绿灯亮，故障中红灯亮";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Checked = true;
			radioButton1.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton1.Location = new System.Drawing.Point(28, 17);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(346, 20);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "待机中绿灯亮，运行中黄灯亮，故障中红灯亮";
			radioButton1.UseVisualStyleBackColor = true;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(550, 223);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_WarningAlarmSetting";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
