using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON
{
	public class Form_NozzleCheckResult : Form
	{
		private IContainer components;

		private Label label1;

		private Button button1;

		public Form_NozzleCheckResult()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
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
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(124, 53);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(518, 31);
			label1.TabIndex = 0;
			label1.Text = "警告！吸嘴有异物或者吸嘴已经磨损，请检查！";
			button1.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button1.Location = new System.Drawing.Point(303, 146);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(137, 42);
			button1.TabIndex = 1;
			button1.Text = "确定";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(767, 220);
			base.Controls.Add(button1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Form_NozzleCheckResult";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
