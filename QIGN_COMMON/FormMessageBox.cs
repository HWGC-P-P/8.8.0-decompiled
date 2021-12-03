using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON
{
	public class FormMessageBox : Form
	{
		private IContainer components;

		private Button button2;

		private Button button3;

		private Button button4;

		private Panel panel1;

		private Panel panel2;

		private Panel panel3;

		private Button button5;

		private Button button6;

		private Panel panel4;

		private Button button7;

		private Button button8;

		private Panel panel5;

		private Button button10;

		private Label label1;

		public FormMessageBox()
		{
			InitializeComponent();
			base.Size = new Size(430, 216);
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
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			button5 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			panel4 = new System.Windows.Forms.Panel();
			button7 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			panel5 = new System.Windows.Forms.Panel();
			button10 = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			SuspendLayout();
			button2.Location = new System.Drawing.Point(34, 7);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(88, 33);
			button2.TabIndex = 0;
			button2.Text = "YES";
			button2.UseVisualStyleBackColor = true;
			button3.Location = new System.Drawing.Point(255, 7);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(88, 33);
			button3.TabIndex = 0;
			button3.Text = "CANCLE";
			button3.UseVisualStyleBackColor = true;
			button4.Location = new System.Drawing.Point(147, 7);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(88, 33);
			button4.TabIndex = 0;
			button4.Text = "NO";
			button4.UseVisualStyleBackColor = true;
			panel1.Location = new System.Drawing.Point(10, 191);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(408, 52);
			panel1.TabIndex = 1;
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(button3);
			panel2.Location = new System.Drawing.Point(426, 19);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(375, 49);
			panel2.TabIndex = 2;
			panel3.Controls.Add(button5);
			panel3.Controls.Add(button6);
			panel3.Location = new System.Drawing.Point(426, 74);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(375, 49);
			panel3.TabIndex = 2;
			button5.Location = new System.Drawing.Point(213, 8);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(88, 33);
			button5.TabIndex = 0;
			button5.Text = "NO";
			button5.UseVisualStyleBackColor = true;
			button6.Location = new System.Drawing.Point(82, 8);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(88, 33);
			button6.TabIndex = 0;
			button6.Text = "YES";
			button6.UseVisualStyleBackColor = true;
			panel4.Controls.Add(button7);
			panel4.Controls.Add(button8);
			panel4.Location = new System.Drawing.Point(426, 129);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(375, 56);
			panel4.TabIndex = 2;
			button7.Location = new System.Drawing.Point(213, 11);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(88, 33);
			button7.TabIndex = 0;
			button7.Text = "CANCEL";
			button7.UseVisualStyleBackColor = true;
			button8.Location = new System.Drawing.Point(82, 11);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(88, 33);
			button8.TabIndex = 0;
			button8.Text = "OK";
			button8.UseVisualStyleBackColor = true;
			panel5.Controls.Add(button10);
			panel5.Location = new System.Drawing.Point(426, 191);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(375, 52);
			panel5.TabIndex = 2;
			button10.Location = new System.Drawing.Point(147, 9);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(88, 33);
			button10.TabIndex = 0;
			button10.Text = "OK";
			button10.UseVisualStyleBackColor = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(12, 26);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(406, 152);
			label1.TabIndex = 3;
			label1.Text = "label1";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(830, 255);
			base.Controls.Add(label1);
			base.Controls.Add(panel5);
			base.Controls.Add(panel4);
			base.Controls.Add(panel3);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Name = "FormMessageBox";
			panel2.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel5.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
