using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_DebugTool : Form
	{
		private IContainer components;

		private PictureBox pictureBox1;

		private CnButton cnButton_upload;

		private TextBox textBox1;

		private CnButton cnButton_convert2data;

		private CnButton cnButton_clear;

		public Form_DebugTool()
		{
			InitializeComponent();
		}

		private void cnButton_upload_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Bitmap image = new Bitmap(openFileDialog.FileName);
					pictureBox1.Image = image;
				}
				catch (Exception)
				{
					MainForm0.CmMessageBoxTop_Ok("导入图片失败！");
				}
			}
		}

		private void cnButton_convert2data_Click(object sender, EventArgs e)
		{
			Bitmap bitmap = (Bitmap)pictureBox1.Image;
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
			int num = 3;
			if (bitmap.PixelFormat == PixelFormat.Format24bppRgb)
			{
				num = 3;
			}
			else if (bitmap.PixelFormat == PixelFormat.Format32bppRgb)
			{
				num = 4;
			}
			int num2 = bitmap.Width * bitmap.Height * num;
			byte[] array = new byte[num2];
			Marshal.Copy(bitmapData.Scan0, array, 0, num2);
			string text = "";
			for (int i = 0; i < num2; i++)
			{
				if (i % 32 == 0 && i != 0)
				{
					text += Environment.NewLine;
				}
				text = text + "0x" + array[i].ToString("X2") + ",";
			}
			textBox1.Text = text;
			bitmap.UnlockBits(bitmapData);
		}

		private void cnButton_clear_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
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
			pictureBox1 = new System.Windows.Forms.PictureBox();
			textBox1 = new System.Windows.Forms.TextBox();
			cnButton_clear = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_convert2data = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_upload = new QIGN_COMMON.vs_acontrol.CnButton();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			pictureBox1.BackColor = System.Drawing.Color.DimGray;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(12, 52);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(128, 128);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			textBox1.Location = new System.Drawing.Point(146, 52);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(1352, 357);
			textBox1.TabIndex = 2;
			cnButton_clear.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_clear.CnPressDownColor = System.Drawing.Color.White;
			cnButton_clear.Location = new System.Drawing.Point(12, 278);
			cnButton_clear.Name = "cnButton_clear";
			cnButton_clear.Size = new System.Drawing.Size(128, 40);
			cnButton_clear.TabIndex = 4;
			cnButton_clear.Text = "清空";
			cnButton_clear.UseVisualStyleBackColor = true;
			cnButton_clear.Click += new System.EventHandler(cnButton_clear_Click);
			cnButton_convert2data.BackColor = System.Drawing.SystemColors.ActiveBorder;
			cnButton_convert2data.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_convert2data.CnPressDownColor = System.Drawing.Color.White;
			cnButton_convert2data.Location = new System.Drawing.Point(12, 232);
			cnButton_convert2data.Name = "cnButton_convert2data";
			cnButton_convert2data.Size = new System.Drawing.Size(128, 40);
			cnButton_convert2data.TabIndex = 3;
			cnButton_convert2data.Text = "转换";
			cnButton_convert2data.UseVisualStyleBackColor = false;
			cnButton_convert2data.Click += new System.EventHandler(cnButton_convert2data_Click);
			cnButton_upload.BackColor = System.Drawing.SystemColors.ActiveBorder;
			cnButton_upload.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_upload.CnPressDownColor = System.Drawing.Color.White;
			cnButton_upload.Location = new System.Drawing.Point(12, 186);
			cnButton_upload.Name = "cnButton_upload";
			cnButton_upload.Size = new System.Drawing.Size(128, 40);
			cnButton_upload.TabIndex = 1;
			cnButton_upload.Text = "上传";
			cnButton_upload.UseVisualStyleBackColor = false;
			cnButton_upload.Click += new System.EventHandler(cnButton_upload_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(1523, 445);
			base.Controls.Add(cnButton_clear);
			base.Controls.Add(cnButton_convert2data);
			base.Controls.Add(textBox1);
			base.Controls.Add(cnButton_upload);
			base.Controls.Add(pictureBox1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_DebugTool";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
