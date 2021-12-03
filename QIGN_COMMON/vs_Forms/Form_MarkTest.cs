using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_MarkTest : Form
	{
		private Bitmap Pic_Raw;

		private IContainer components;

		private Panel panel1;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private Button button_importpic;

		private Button button_savemark;

		private Panel panel2;

		public Form_MarkTest()
		{
			InitializeComponent();
			if (MainForm0.mJvsDriver == JvsDriver.MV360)
			{
				pictureBox1.Size = new Size(960, 540);
			}
			else
			{
				pictureBox1.Size = new Size(MainForm0.mJvs_rawWidth, MainForm0.mJvs_usrHeight);
			}
			MainForm0.common_addCSLforPicture(pictureBox1, Color.Yellow);
			MainForm0.common_addCSLforPicture(pictureBox2, Color.Yellow);
			panel2.Visible = (pictureBox2.Visible = MainForm0.mIsSimulation);
		}

		public Form_MarkTest(Bitmap pic)
		{
			InitializeComponent();
			if (MainForm0.mJvsDriver == JvsDriver.MV360)
			{
				pictureBox1.Size = new Size(960, 540);
			}
			else
			{
				pictureBox1.Size = new Size(MainForm0.mJvs_rawWidth, MainForm0.mJvs_usrHeight);
			}
			MainForm0.common_addCSLforPicture(pictureBox1, Color.Yellow);
			MainForm0.common_addCSLforPicture(pictureBox2, Color.Yellow);
			Pic_Raw = new Bitmap(pic);
			Bitmap bitmap = new Bitmap(Pic_Raw);
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
			pictureBox1.Image = new Bitmap(bitmap);
			bitmap.Dispose();
			panel2.Visible = (pictureBox2.Visible = MainForm0.mIsSimulation);
		}

		public Form_MarkTest(Bitmap pic, Bitmap pic_mark)
		{
			InitializeComponent();
			if (MainForm0.mJvsDriver == JvsDriver.MV360)
			{
				pictureBox1.Size = new Size(960, 540);
			}
			else
			{
				pictureBox1.Size = new Size(MainForm0.mJvs_rawWidth, MainForm0.mJvs_usrHeight);
			}
			MainForm0.common_addCSLforPicture(pictureBox1, Color.Yellow);
			MainForm0.common_addCSLforPicture(pictureBox2, Color.Yellow);
			Pic_Raw = new Bitmap(pic);
			Bitmap bitmap = new Bitmap(Pic_Raw);
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
			pictureBox1.Image = new Bitmap(bitmap);
			bitmap.Dispose();
			Bitmap bitmap2 = new Bitmap(pic_mark);
			bitmap2.RotateFlip(RotateFlipType.Rotate180FlipX);
			pictureBox2.Image = new Bitmap(bitmap2);
			bitmap2.Dispose();
			panel2.Visible = MainForm0.mIsSimulation;
		}

		private void Form_MarkTest_Load(object sender, EventArgs e)
		{
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		private void button_importpic_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Pic_Raw = new Bitmap(openFileDialog.FileName);
					pictureBox1.Image = new Bitmap(Pic_Raw);
				}
				catch (Exception)
				{
					MessageBox.Show("导入图片失败！");
				}
			}
		}

		private void button_savemark_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(thread_mark_capture);
			thread.IsBackground = true;
			thread.Start();
		}

		private void thread_mark_capture(object markno)
		{
			int num = (int)(150f * (float)MainForm0.mJvs_rawWidth / (float)MainForm0.mJvs_usrHeight);
			Rectangle destRect = new Rectangle(0, 0, 150, 150);
			Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - 150) / 2, (MainForm0.mJvs_rawHeight - num) / 2, 150, num);
			Bitmap bitmap = new Bitmap(150, 150);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(Pic_Raw, destRect, srcRect, GraphicsUnit.Pixel);
			graphics.Dispose();
			Bitmap b = new Bitmap(bitmap);
			Graphics graphics2 = Graphics.FromImage(b);
			int num2 = 120;
			graphics2.DrawRectangle(new Pen(Color.Yellow, 1f), new Rectangle(new Point((150 - num2) / 2, (150 - num2) / 2), new Size(num2, num2)));
			graphics2.Dispose();
			Invoke((MethodInvoker)delegate
			{
				Bitmap image = new Bitmap(b);
				pictureBox2.Image = image;
			});
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
			button_importpic = new System.Windows.Forms.Button();
			button_savemark = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Controls.Add(pictureBox1);
			panel1.Location = new System.Drawing.Point(12, 12);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(975, 643);
			panel1.TabIndex = 0;
			pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(3, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(960, 540);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox2.Location = new System.Drawing.Point(993, 12);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(150, 150);
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			button_importpic.Location = new System.Drawing.Point(6, 12);
			button_importpic.Name = "button_importpic";
			button_importpic.Size = new System.Drawing.Size(107, 33);
			button_importpic.TabIndex = 2;
			button_importpic.Text = "导入图片";
			button_importpic.UseVisualStyleBackColor = true;
			button_importpic.Click += new System.EventHandler(button_importpic_Click);
			button_savemark.Location = new System.Drawing.Point(6, 51);
			button_savemark.Name = "button_savemark";
			button_savemark.Size = new System.Drawing.Size(107, 33);
			button_savemark.TabIndex = 2;
			button_savemark.Text = "保存Mark";
			button_savemark.UseVisualStyleBackColor = true;
			button_savemark.Click += new System.EventHandler(button_savemark_Click);
			panel2.Controls.Add(button_importpic);
			panel2.Controls.Add(button_savemark);
			panel2.Location = new System.Drawing.Point(993, 484);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(133, 93);
			panel2.TabIndex = 3;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(1155, 677);
			base.Controls.Add(panel2);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_MarkTest";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_MarkTest_Load);
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
