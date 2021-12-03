using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_TrackNotice : Form
	{
		private IContainer components;

		private Label label1;

		private CnButton cnButton1;

		private CnButton cnButton2;

		private Label label2;

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
			cnButton1 = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton2 = new QIGN_COMMON.vs_acontrol.CnButton();
			label2 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 18.5f);
			label1.Location = new System.Drawing.Point(238, 44);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(376, 25);
			label1.TabIndex = 0;
			label1.Text = "您是否已经正确设置轨道参数？";
			cnButton1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			cnButton1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton1.CnPressDownColor = System.Drawing.Color.White;
			cnButton1.Font = new System.Drawing.Font("黑体", 16.5f);
			cnButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			cnButton1.Location = new System.Drawing.Point(458, 193);
			cnButton1.Name = "cnButton1";
			cnButton1.Size = new System.Drawing.Size(195, 85);
			cnButton1.TabIndex = 1;
			cnButton1.Text = "确定\r\n继续编辑工程";
			cnButton1.UseVisualStyleBackColor = false;
			cnButton1.Click += new System.EventHandler(cnButton1_Click);
			cnButton2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			cnButton2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton2.CnPressDownColor = System.Drawing.Color.White;
			cnButton2.Font = new System.Drawing.Font("黑体", 16.5f);
			cnButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			cnButton2.Location = new System.Drawing.Point(191, 193);
			cnButton2.Name = "cnButton2";
			cnButton2.Size = new System.Drawing.Size(185, 85);
			cnButton2.TabIndex = 1;
			cnButton2.Text = "返回\r\n设置轨道参数";
			cnButton2.UseVisualStyleBackColor = false;
			cnButton2.Click += new System.EventHandler(cnButton2_Click);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 15.5f);
			label2.Location = new System.Drawing.Point(107, 118);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(626, 42);
			label2.TabIndex = 0;
			label2.Text = "1. 放置要贴装的PCB板在机器入口\r\n2. 执行进板/出板等功能，测试传板延时、速度等参数是否合适";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(868, 326);
			base.Controls.Add(cnButton2);
			base.Controls.Add(cnButton1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12.5f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_TrackNotice";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_TrackNotice()
		{
			InitializeComponent();
		}

		private void cnButton1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void cnButton2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
