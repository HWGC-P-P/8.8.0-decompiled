using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_VisualShow : Form
	{
		private IContainer components;

		private Panel panel_0;

		private Button button1;

		private Button button2;

		private PictureBox[] mInternalPicBox;

		private Label[] label_info;

		private int ZnNum = 8;

		private Bitmap[] mBitmap;

		private int mShowMode;

		private int mLanguage;

		private USR_INIT_DATA USR_INIT;

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
			panel_0 = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			SuspendLayout();
			panel_0.Location = new System.Drawing.Point(-1, 28);
			panel_0.Name = "panel_0";
			panel_0.Size = new System.Drawing.Size(1278, 730);
			panel_0.TabIndex = 1;
			button1.Location = new System.Drawing.Point(2, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 25);
			button1.TabIndex = 2;
			button1.Text = "横显";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(78, 1);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 25);
			button2.TabIndex = 2;
			button2.Text = "竖显";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.PapayaWhip;
			base.ClientSize = new System.Drawing.Size(1274, 761);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(panel_0);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_VisualShow";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Load += new System.EventHandler(Form_VisualShow_Load);
			ResumeLayout(false);
		}

		public Form_VisualShow(int lan, int znNum)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			ZnNum = znNum;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			mInternalPicBox = new PictureBox[ZnNum];
			label_info = new Label[ZnNum];
			mBitmap = new Bitmap[ZnNum];
			mShowMode = 1;
			mLanguage = lan;
			for (int i = 0; i < ZnNum; i++)
			{
				mInternalPicBox[i] = new PictureBox();
				panel_0.Controls.Add(mInternalPicBox[i]);
				mInternalPicBox[i].Size = new Size(318, 318);
				mInternalPicBox[i].Location = new Point(i % (ZnNum / 2) * 320, i / (ZnNum / 2) * 355);
				mInternalPicBox[i].BackColor = Color.Gray;
				mInternalPicBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
				label_info[i] = new Label();
				panel_0.Controls.Add(label_info[i]);
				label_info[i].Size = new Size(60, 24);
				label_info[i].Location = new Point(150 + i % (ZnNum / 2) * 320, 320 + i / (ZnNum / 2) * 355);
				label_info[i].Font = new Font(DEF.FONT_2020[mLanguage], 11f, FontStyle.Regular);
				label_info[i].AutoSize = true;
				label_info[i].TextAlign = ContentAlignment.TopLeft;
				label_info[i].Text = STR.NOZZLE_a[mLanguage] + (i + 1);
				mBitmap[i] = new Bitmap(mInternalPicBox[i].Size.Width, mInternalPicBox[i].Size.Height);
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button1,
				str = new string[3] { "横显", "横显", "Horizontal" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button2,
				str = new string[3] { "竖显", "竖显", "Vertical" }
			});
			return list;
		}

		public void set_show_mode(int showmode)
		{
			mShowMode = showmode;
			switch (showmode)
			{
			case 0:
			{
				base.Size = new Size(1280, 780);
				base.Location = new Point(0, 160);
				panel_0.Size = new Size(1280, 730);
				for (int j = 0; j < ZnNum; j++)
				{
					mInternalPicBox[j].Size = new Size(318, 318);
					mInternalPicBox[j].Location = new Point(j % (ZnNum / 2) * 320, j / (ZnNum / 2) * 355);
					label_info[j].Location = new Point(150 + j % (ZnNum / 2) * 320, 320 + j / (ZnNum / 2) * 355);
					label_info[j].Font = new Font(STR.LANGUAGE[mLanguage], 12f, FontStyle.Regular);
					mBitmap[j] = new Bitmap(mInternalPicBox[j].Size.Width, mInternalPicBox[j].Size.Height);
				}
				break;
			}
			case 1:
			{
				base.Size = new Size(535, 1080);
				base.Location = new Point(0, 0);
				panel_0.Size = new Size(550, 1050);
				for (int i = 0; i < ZnNum; i++)
				{
					mInternalPicBox[i].Size = new Size(250, 250);
					mInternalPicBox[i].Location = new Point(i / (ZnNum / 2) * 252, i % (ZnNum / 2) * 252);
					label_info[i].Location = new Point(4 + i / (ZnNum / 2) * 252, 4 + i % (ZnNum / 2) * 252);
					label_info[i].Font = new Font(STR.LANGUAGE[mLanguage], 12f, FontStyle.Regular);
					label_info[i].BringToFront();
					mBitmap[i] = new Bitmap(mInternalPicBox[i].Size.Width, mInternalPicBox[i].Size.Height);
				}
				break;
			}
			}
		}

		public void ShowDetails(Image bmp, int zn, string visinfo, bool isfull)
		{
			if (bmp != null)
			{
				int num = ((!isfull) ? 20 : 0);
				int num2 = ((!isfull) ? 20 : 0);
				Rectangle destRect = new Rectangle(0, 0, mBitmap[zn].Size.Width, mBitmap[zn].Size.Height);
				Rectangle srcRect = new Rectangle(num, num2, bmp.Size.Width - num * 2, bmp.Size.Height - num2 * 2);
				Graphics graphics = Graphics.FromImage(mBitmap[zn]);
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.DrawImage(bmp, destRect, srcRect, GraphicsUnit.Pixel);
				graphics.Dispose();
				mInternalPicBox[zn].Image = mBitmap[zn];
			}
			Invoke((MethodInvoker)delegate
			{
				label_info[zn].Text = STR.NOZZLE_a[mLanguage] + (zn + 1) + Environment.NewLine + visinfo;
			});
		}

		private void Form_VisualShow_Load(object sender, EventArgs e)
		{
			set_show_mode(mShowMode);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			set_show_mode(0);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			set_show_mode(1);
		}
	}
}
