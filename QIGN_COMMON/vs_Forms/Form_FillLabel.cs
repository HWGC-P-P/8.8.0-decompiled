using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_FillLabel : Form
	{
		private IContainer components;

		private TextBox textBox1;

		private Label label2;

		private NumericUpDown numericUpDown1;

		private Label label3;

		private Button button_Cancel;

		private Button button_OK;

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
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			button_Cancel = new System.Windows.Forms.Button();
			button_OK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			SuspendLayout();
			textBox1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox1.Location = new System.Drawing.Point(30, 49);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(181, 26);
			textBox1.TabIndex = 1;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 12f);
			label2.Location = new System.Drawing.Point(100, 30);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(40, 16);
			label2.TabIndex = 0;
			label2.Text = "前缀";
			numericUpDown1.Font = new System.Drawing.Font("楷体", 12f);
			numericUpDown1.Location = new System.Drawing.Point(217, 49);
			numericUpDown1.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(96, 26);
			numericUpDown1.TabIndex = 2;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("楷体", 12f);
			label3.Location = new System.Drawing.Point(230, 30);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(72, 16);
			label3.TabIndex = 0;
			label3.Text = "起始序号";
			button_Cancel.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Cancel.Location = new System.Drawing.Point(217, 96);
			button_Cancel.Margin = new System.Windows.Forms.Padding(2);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(73, 28);
			button_Cancel.TabIndex = 4;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = true;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			button_OK.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OK.Location = new System.Drawing.Point(81, 96);
			button_OK.Margin = new System.Windows.Forms.Padding(2);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(73, 28);
			button_OK.TabIndex = 3;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = true;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LightSalmon;
			base.ClientSize = new System.Drawing.Size(377, 135);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(button_OK);
			base.Controls.Add(numericUpDown1);
			base.Controls.Add(textBox1);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			Font = new System.Drawing.Font("楷体", 10.5f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_FillLabel";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_FillLabel()
		{
			InitializeComponent();
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		public string getLabelPreix()
		{
			return textBox1.Text;
		}

		public int getLabelStartIndex()
		{
			return (int)numericUpDown1.Value;
		}
	}
}
