using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_Fill_Value_Footprint : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private TextBox textBox1;

		private TextBox textBox2;

		private Button button_cancel;

		private Button button_ok;

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
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			button_cancel = new System.Windows.Forms.Button();
			button_ok = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 12f);
			label1.Location = new System.Drawing.Point(97, 57);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 16);
			label1.TabIndex = 0;
			label1.Text = "元件型号";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 12f);
			label2.Location = new System.Drawing.Point(97, 108);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(72, 16);
			label2.TabIndex = 0;
			label2.Text = "元件封装";
			textBox1.Font = new System.Drawing.Font("黑体", 12f);
			textBox1.Location = new System.Drawing.Point(197, 52);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(187, 26);
			textBox1.TabIndex = 1;
			textBox2.Font = new System.Drawing.Font("黑体", 12f);
			textBox2.Location = new System.Drawing.Point(197, 103);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(187, 26);
			textBox2.TabIndex = 1;
			button_cancel.Location = new System.Drawing.Point(276, 166);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(108, 35);
			button_cancel.TabIndex = 2;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			button_ok.Location = new System.Drawing.Point(100, 166);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(108, 35);
			button_ok.TabIndex = 2;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(519, 235);
			base.Controls.Add(button_ok);
			base.Controls.Add(button_cancel);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_Fill_Value_Footprint";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_Fill_Value_Footprint(string v, string f)
		{
			InitializeComponent();
			textBox1.Text = v;
			textBox2.Text = f;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		public string get_value()
		{
			return textBox1.Text;
		}

		public string get_footprint()
		{
			return textBox2.Text;
		}
	}
}
