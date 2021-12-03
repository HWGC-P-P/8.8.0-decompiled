using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_MarkCheck : Form
	{
		public PictureBox[] pic_mark;

		public USR3_DATA USR3;

		private IContainer components;

		private Panel panel1;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private Label label1;

		public Form_MarkCheck(USR3_DATA usr3)
		{
			InitializeComponent();
			USR3 = usr3;
			pic_mark = new PictureBox[2] { pictureBox1, pictureBox2 };
		}

		private void Form_MarkCheck_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 2; i++)
			{
				MainForm0.common_addCSLforPicture(pic_mark[i], Color.Yellow);
				if (USR3.mMarkPic[i] != null)
				{
					Bitmap bitmap = new Bitmap(USR3.mMarkPic[i]);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					pic_mark[i].Image = bitmap;
				}
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
			panel1 = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			panel1.Controls.Add(pictureBox2);
			panel1.Controls.Add(pictureBox1);
			panel1.Location = new System.Drawing.Point(32, 61);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(516, 152);
			panel1.TabIndex = 0;
			pictureBox1.BackColor = System.Drawing.Color.Gray;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(1, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(150, 150);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox2.BackColor = System.Drawing.Color.Gray;
			pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox2.Location = new System.Drawing.Point(366, 1);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(150, 150);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 0;
			pictureBox2.TabStop = false;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(246, 27);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 19);
			label1.TabIndex = 1;
			label1.Text = "原始MARK";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightSalmon;
			base.ClientSize = new System.Drawing.Size(579, 239);
			base.Controls.Add(label1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_MarkCheck";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Load += new System.EventHandler(Form_MarkCheck_Load);
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
