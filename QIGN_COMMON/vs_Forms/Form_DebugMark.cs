using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_DebugMark : Form
	{
		private IContainer components;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private PictureBox pictureBox3;

		private Button button1;

		private Button button2;

		private Button button4;

		private PictureBox pictureBox4;

		private Button button5;

		private TextBox textBox1;

		private Button button6;

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
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			pictureBox4 = new System.Windows.Forms.PictureBox();
			button5 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			button6 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			SuspendLayout();
			pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(27, 56);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(704, 550);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox2.Location = new System.Drawing.Point(766, 56);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(150, 150);
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			pictureBox3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox3.Location = new System.Drawing.Point(950, 56);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(150, 150);
			pictureBox3.TabIndex = 1;
			pictureBox3.TabStop = false;
			button1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button1.Location = new System.Drawing.Point(27, 19);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(103, 28);
			button1.TabIndex = 2;
			button1.Text = "导入图片";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button2.Location = new System.Drawing.Point(766, 20);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(150, 28);
			button2.TabIndex = 2;
			button2.Text = "导入MARK图片";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button4.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button4.Location = new System.Drawing.Point(766, 228);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(150, 28);
			button4.TabIndex = 3;
			button4.Text = "开始匹配";
			button4.UseVisualStyleBackColor = true;
			pictureBox4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox4.Location = new System.Drawing.Point(766, 264);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new System.Drawing.Size(150, 150);
			pictureBox4.TabIndex = 1;
			pictureBox4.TabStop = false;
			button5.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button5.Location = new System.Drawing.Point(950, 19);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(150, 28);
			button5.TabIndex = 3;
			button5.Text = "提取特征";
			button5.UseVisualStyleBackColor = true;
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			textBox1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			textBox1.Location = new System.Drawing.Point(136, 20);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(486, 26);
			textBox1.TabIndex = 4;
			button6.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button6.Location = new System.Drawing.Point(628, 19);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(103, 28);
			button6.TabIndex = 2;
			button6.Text = "下一张";
			button6.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1274, 675);
			base.Controls.Add(textBox1);
			base.Controls.Add(button5);
			base.Controls.Add(button4);
			base.Controls.Add(button2);
			base.Controls.Add(button6);
			base.Controls.Add(button1);
			base.Controls.Add(pictureBox3);
			base.Controls.Add(pictureBox4);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(pictureBox1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_DebugMark";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_DebugMark()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}
	}
}
