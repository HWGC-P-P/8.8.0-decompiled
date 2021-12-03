using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_VisualShow : UserControl
	{
		private PictureBox[] mInternalPicBox;

		private Label[] label_info;

		private int ZnNum = 8;

		private Bitmap[] mBitmap;

		private int mLanguage;

		private USR_INIT_DATA USR_INIT;

		private int mFn;

		private IContainer components;

		private Panel panel_0;

		private CnButton cnButton_close;

		public UserControl_VisualShow(int fn)
		{
			InitializeComponent();
			base.Size = new Size(550, 994);
			mFn = fn;
			ZnNum = HW.mZnNum[mFn];
			USR_INIT = MainForm0.USR_INIT;
			mLanguage = USR_INIT.mLanguage;
			mInternalPicBox = new PictureBox[ZnNum];
			label_info = new Label[ZnNum];
			mBitmap = new Bitmap[ZnNum];
			for (int i = 0; i < ZnNum; i++)
			{
				mInternalPicBox[i] = new PictureBox();
				panel_0.Controls.Add(mInternalPicBox[i]);
				mInternalPicBox[i].Size = new Size(318, 318);
				mInternalPicBox[i].Location = new Point(i % (ZnNum / 2) * 320, i / (ZnNum / 2) * 355);
				mInternalPicBox[i].BackColor = Color.DimGray;
				mInternalPicBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
				label_info[i] = new Label();
				panel_0.Controls.Add(label_info[i]);
				label_info[i].Size = new Size(60, 24);
				label_info[i].Location = new Point(150 + i % (ZnNum / 2) * 320, 320 + i / (ZnNum / 2) * 355);
				label_info[i].Font = new Font(DEF.FONT_2020[mLanguage], 11f, FontStyle.Regular);
				label_info[i].AutoSize = true;
				label_info[i].TextAlign = ContentAlignment.TopLeft;
				label_info[i].Text = STR.NOZZLE_a[mLanguage] + (i + 1);
				label_info[i].BackColor = Color.White;
				mBitmap[i] = new Bitmap(mInternalPicBox[i].Size.Width, mInternalPicBox[i].Size.Height);
			}
			base.Size = new Size(550, 940);
			base.Location = new Point(0, 0);
			panel_0.Size = new Size(550, 936);
			for (int j = 0; j < ZnNum; j++)
			{
				mInternalPicBox[j].Size = new Size(250, 250);
				Panel panel = new Panel();
				panel_0.Controls.Add(panel);
				panel.Size = new Size(250, 232);
				panel.Location = new Point(j / (ZnNum / 2) * 252, j % (ZnNum / 2) * 234);
				panel.Controls.Add(mInternalPicBox[j]);
				mInternalPicBox[j].Location = new Point(0, -9);
				panel.Controls.Add(label_info[j]);
				label_info[j].Location = new Point(0, 0);
				label_info[j].Font = new Font(STR.LANGUAGE[mLanguage], 12f, FontStyle.Regular);
				label_info[j].BringToFront();
				mBitmap[j] = new Bitmap(mInternalPicBox[j].Size.Width, mInternalPicBox[j].Size.Height);
			}
		}

		public void set_mode(int mode)
		{
			switch (mode)
			{
			case 0:
				base.Size = new Size(550, 940);
				panel_0.Size = new Size(550, 936);
				panel_0.Location = new Point(1, 2);
				break;
			case 1:
				base.Size = new Size(633, 940);
				panel_0.Size = new Size(550, 936);
				panel_0.Location = new Point(37, 2);
				break;
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
				Brush brush = new SolidBrush(Color.White);
				graphics.DrawString(visinfo, new Font(DEF.FONT_2020_DATA[mLanguage], 11f, FontStyle.Regular), brush, new PointF(0f, 32f));
				graphics.Dispose();
				mInternalPicBox[zn].Image = mBitmap[zn];
			}
			Invoke((MethodInvoker)delegate
			{
				label_info[zn].Text = STR.NOZZLE_a[mLanguage] + (zn + 1);
			});
		}

		private void cnButton_close_Click(object sender, EventArgs e)
		{
			base.Visible = false;
		}

		private void UserControl_VisualShow_Load(object sender, EventArgs e)
		{
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
			panel_0 = new System.Windows.Forms.Panel();
			cnButton_close = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_0.SuspendLayout();
			SuspendLayout();
			panel_0.Controls.Add(cnButton_close);
			panel_0.Location = new System.Drawing.Point(1, 2);
			panel_0.Name = "panel_0";
			panel_0.Size = new System.Drawing.Size(544, 954);
			panel_0.TabIndex = 0;
			cnButton_close.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			cnButton_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_close.CnPressDownColor = System.Drawing.Color.White;
			cnButton_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cnButton_close.Location = new System.Drawing.Point(510, 3);
			cnButton_close.Name = "cnButton_close";
			cnButton_close.Size = new System.Drawing.Size(31, 31);
			cnButton_close.TabIndex = 1;
			cnButton_close.Text = "X";
			cnButton_close.UseVisualStyleBackColor = false;
			cnButton_close.Click += new System.EventHandler(cnButton_close_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(panel_0);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_VisualShow";
			base.Size = new System.Drawing.Size(550, 994);
			base.Load += new System.EventHandler(UserControl_VisualShow_Load);
			panel_0.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
