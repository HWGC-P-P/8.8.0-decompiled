using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_Export : Form
	{
		private IContainer components;

		private Button button_txt;

		private Button button_csv;

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
			button_txt = new System.Windows.Forms.Button();
			button_csv = new System.Windows.Forms.Button();
			SuspendLayout();
			button_txt.Font = new System.Drawing.Font("楷体", 13.5f);
			button_txt.Location = new System.Drawing.Point(84, 61);
			button_txt.Name = "button_txt";
			button_txt.Size = new System.Drawing.Size(174, 61);
			button_txt.TabIndex = 0;
			button_txt.Text = "导出TXT格式";
			button_txt.UseVisualStyleBackColor = true;
			button_txt.Click += new System.EventHandler(button_txt_Click);
			button_csv.Font = new System.Drawing.Font("楷体", 13.5f);
			button_csv.Location = new System.Drawing.Point(348, 61);
			button_csv.Name = "button_csv";
			button_csv.Size = new System.Drawing.Size(175, 61);
			button_csv.TabIndex = 0;
			button_csv.Text = "导出CSV格式";
			button_csv.UseVisualStyleBackColor = true;
			button_csv.Click += new System.EventHandler(button_csv_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(632, 186);
			base.Controls.Add(button_csv);
			base.Controls.Add(button_txt);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_Export";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
		}

		public Form_Export()
		{
			InitializeComponent();
		}

		private void button_txt_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button_csv_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
