using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_CamDisable : Form
	{
		public USR_DATA USR;

		private IContainer components;

		private Label label1;

		private Panel panel1;

		public Form_CamDisable(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
			_ = panel1.Size.Width;
			int num = 40;
			int num2 = 15;
			int num3 = (panel1.Size.Width - (num * HW.mZnNum[MainForm0.mFn] + num2 * (HW.mZnNum[MainForm0.mFn] - 1))) / 2;
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				Label label = new Label();
				panel1.Controls.Add(label);
				label.AutoSize = false;
				label.BorderStyle = BorderStyle.FixedSingle;
				label.Size = new Size(num, num);
				label.Location = new Point(num3 + i * (num + num2), 20);
				label.TextAlign = ContentAlignment.MiddleCenter;
				label.BackColor = (USR.misfcam_disable[i] ? Color.Gray : Color.Moccasin);
				label.Text = (USR.misfcam_disable[i] ? "禁用" : "启用");
				label.Tag = i;
				label.Click += label_fcam_disable_Click;
				Label label2 = new Label();
				panel1.Controls.Add(label2);
				label2.AutoSize = false;
				label2.Text = "相机" + (i + 1);
				label2.Location = new Point(num3 + i * (num + num2), 65);
				label2.Size = new Size(60, 25);
			}
		}

		private void label_fcam_disable_Click(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			int num = (int)label.Tag;
			USR.misfcam_disable[num] = !USR.misfcam_disable[num];
			label.BackColor = (USR.misfcam_disable[num] ? Color.Gray : Color.Moccasin);
			label.Text = (USR.misfcam_disable[num] ? "禁用" : "启用");
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
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(213, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(129, 19);
			label1.TabIndex = 0;
			label1.Text = "快速相机禁用";
			panel1.Location = new System.Drawing.Point(40, 45);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(494, 106);
			panel1.TabIndex = 1;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(581, 173);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_CamDisable";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
