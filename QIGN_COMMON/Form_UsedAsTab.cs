using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON
{
	public class Form_UsedAsTab : Form
	{
		private IContainer components;

		private Label label1;

		private Button button_exit;

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
			label1 = new System.Windows.Forms.Label();
			button_exit = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(162, 78);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(288, 28);
			label1.TabIndex = 0;
			label1.Text = "机器正作为接驳台运行模式 ...";
			button_exit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			button_exit.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			button_exit.Location = new System.Drawing.Point(552, 161);
			button_exit.Name = "button_exit";
			button_exit.Size = new System.Drawing.Size(70, 30);
			button_exit.TabIndex = 1;
			button_exit.Text = "退出";
			button_exit.UseVisualStyleBackColor = false;
			button_exit.Click += new System.EventHandler(button_exit_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.AppWorkspace;
			base.ClientSize = new System.Drawing.Size(634, 203);
			base.Controls.Add(button_exit);
			base.Controls.Add(label1);
			base.Name = "Form_UsedAsTab";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_UsedAsTab(int language)
		{
			InitializeComponent();
			if (language == 2)
			{
				label1.Text = "The Device is working in rail track mode...";
				button_exit.Text = "EXIT";
			}
		}

		private void button_exit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
