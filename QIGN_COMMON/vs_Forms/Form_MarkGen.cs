using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_MarkGen : Form
	{
		private USR_INIT_DATA USR_INIT;

		public USR_DATA USR;

		public USR3_DATA USR3;

		public int mMarkNo;

		public Bitmap mPic;

		public Bitmap mPic_Ct;

		public Bitmap mPic_Mark;

		public volatile BindingList<BindingList<CvPoint>> mCtList;

		public volatile BindingList<CvPoint> mselected_ctlist;

		public int mSavedMarch_Index = -1;

		public PictureBox mCSL_Pic;

		public PictureBox mCSL_Mark;

		public int mThreshold = 127;

		public int mMinPno = 50;

		public int mMaxPno = 500;

		public double mX_offset;

		public double mY_offset;

		public volatile bool mMutex_MarkGen;

		private IContainer components;

		private PictureBox pictureBox1;

		private Panel panel1;

		private TrackBar trackBar1;

		private Label label1;

		private Label label2;

		private TrackBar trackBar_maxpno;

		private TrackBar trackBar_minpno;

		private Label label_maxpno;

		private Label label_minpno;

		private Label label4;

		private Label label3;

		private Label label_mousexy;

		private PictureBox pictureBox2;

		private Button button_matchTest;

		private Panel panel2;

		private Button button_ok;

		private Button button_cancel;

		private Label label_xoffset;

		private Label label_yoffset;

		private Label label_xoffset_v;

		private Label label_yoffset_v;

		private Button button_importPic;

		private Label label5;

		private Label label6;

		private NumericUpDown numericUpDown_MarkPicSize;

		private NumericUpDown numericUpDown_MarkRecognizeRate;

		private Label label7;

		private Label label8;

		private Button button_matchTest0;

		public event llcvPoint_Func_bitmap_rfint_int_int ImageVisual_MarkGen;

		public event int_Func_bitmap_cplist_int_doubleM_int ImageVisual_MarkMatch;

		public Form_MarkGen(USR_DATA usr, USR3_DATA usr3, Bitmap pic, Bitmap pic_ct, BindingList<BindingList<CvPoint>> ctlist, int markno)
		{
			InitializeComponent();
			USR = usr;
			USR3 = usr3;
			USR_INIT = MainForm0.USR_INIT;
			button_ok.Location = new Point(button_ok.Location.X, button_ok.Location.Y - (pictureBox1.Size.Height - MainForm0.mJvs_usrHeight));
			button_cancel.Location = new Point(button_cancel.Location.X, button_cancel.Location.Y - (pictureBox1.Size.Height - MainForm0.mJvs_usrHeight));
			base.Size = new Size(base.Size.Width - (pictureBox1.Size.Width - MainForm0.mJvs_usrWidth), base.Size.Height - (pictureBox1.Size.Height - MainForm0.mJvs_usrHeight));
			pictureBox1.Size = new Size(MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
			label1.Text = STR.THRESHOLD[USR_INIT.mLanguage];
			label3.Text = ((USR_INIT.mLanguage == 2) ? "Min Pixels" : "最小像素");
			label4.Text = ((USR_INIT.mLanguage == 2) ? "Max Pixels" : "最大像素");
			button_ok.Text = ((USR_INIT.mLanguage == 2) ? "Ok" : "确定");
			button_cancel.Text = ((USR_INIT.mLanguage == 2) ? "Cancel" : "取消");
			mMarkNo = markno;
			if (pic == null)
			{
				pic = new Bitmap(MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
			}
			if (USR3.mMarkPara[mMarkNo].mPicMark == null)
			{
				USR3.mMarkPara[mMarkNo].mPicMark = new Bitmap(150, 150);
			}
			mPic = new Bitmap(pic);
			mPic_Mark = new Bitmap(USR3.mMarkPara[mMarkNo].mPicMark);
			mPic_Ct = new Bitmap(pic_ct);
			mThreshold = USR3.mMarkPara[mMarkNo].threshold;
			mMinPno = USR3.mMarkPara[mMarkNo].min_pno;
			mMaxPno = USR3.mMarkPara[mMarkNo].max_pno;
			mX_offset = USR3.mMarkPara[mMarkNo].x_offs;
			mY_offset = USR3.mMarkPara[mMarkNo].y_offs;
			Bitmap bitmap = new Bitmap(pic_ct);
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
			pictureBox1.Image = bitmap;
			Bitmap bitmap2 = new Bitmap(USR3.mMarkPara[mMarkNo].mPicMark);
			bitmap2.RotateFlip(RotateFlipType.Rotate180FlipX);
			pictureBox2.Image = bitmap2;
			mCtList = ctlist;
			mselected_ctlist = USR3.mMarkPara[mMarkNo].cvlist;
			numericUpDown_MarkPicSize.Value = USR3.mMarkPara[mMarkNo].picsize;
			numericUpDown_MarkRecognizeRate.Value = USR3.mMarkPara[mMarkNo].recognizeRate;
		}

		private void button_LunKuo_Click(object sender, EventArgs e)
		{
		}

		private void flush_pictureBox1_picture()
		{
			Bitmap bitmap = new Bitmap(mPic_Ct);
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
			pictureBox1.Image = bitmap;
		}

		private void flush_paint(int sel_index)
		{
			if (mMutex_MarkGen || mCtList == null || mCtList.Count == 0)
			{
				return;
			}
			Graphics graphics = pictureBox1.CreateGraphics();
			Pen pen = new Pen(Color.LightBlue, 2f);
			Pen pen2 = new Pen(Color.Red, 2f);
			for (int i = 0; i < mCtList.Count; i++)
			{
				if (mCtList[i] != null && mCtList[i].Count > 0)
				{
					Point[] array = new Point[mCtList[i].Count];
					for (int j = 0; j < mCtList[i].Count; j++)
					{
						ref Point reference = ref array[j];
						reference = new Point(mCtList[i][j].X, mPic.Size.Height - 1 - mCtList[i][j].Y);
					}
					try
					{
						graphics.DrawCurve((i == sel_index) ? pen2 : pen, array);
					}
					catch (Exception)
					{
					}
				}
			}
			pen.Dispose();
			pen2.Dispose();
			graphics.Dispose();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Form_MarkGen_Load(object sender, EventArgs e)
		{
			trackBar1.Value = mThreshold;
			trackBar_minpno.Value = mMinPno;
			trackBar_maxpno.Value = mMaxPno;
			label_xoffset_v.Text = mX_offset.ToString();
			label_yoffset_v.Text = mY_offset.ToString();
			label2.Text = mThreshold.ToString();
			mCSL_Pic = new PictureBox();
			base.Controls.Add(mCSL_Pic);
			mCSL_Pic.BorderStyle = BorderStyle.FixedSingle;
			mCSL_Pic.Location = pictureBox1.Location;
			mCSL_Pic.Size = new Size(MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
			mCSL_Pic.BringToFront();
			mCSL_Pic.BackColor = Color.Yellow;
			mCSL_Pic.Visible = true;
			mCSL_Pic.Region = getCSLRegion_PictureBox1(mCSL_Pic);
			mCSL_Mark = new PictureBox();
			base.Controls.Add(mCSL_Mark);
			mCSL_Mark.BorderStyle = BorderStyle.FixedSingle;
			mCSL_Mark.Location = pictureBox2.Location;
			mCSL_Mark.Size = pictureBox2.Size;
			mCSL_Mark.BringToFront();
			mCSL_Mark.BackColor = Color.Yellow;
			mCSL_Mark.Visible = true;
			mCSL_Mark.Region = MainForm0.common_getCSLRegion(mCSL_Mark);
		}

		public Region getCSLRegion_PictureBox1(PictureBox pb)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(new Rectangle(0, pb.Height / 2, pb.Width, 1));
			graphicsPath.AddRectangle(new Rectangle(pb.Width / 2, 0, 1, pb.Height));
			int num = (pb.Width - 150) / 2;
			int num2 = (pb.Height - 150) / 2;
			graphicsPath.AddRectangle(new Rectangle(num, num2, 150, 1));
			graphicsPath.AddRectangle(new Rectangle(num, num2, 1, 150));
			graphicsPath.AddRectangle(new Rectangle(num, num2 + 150, 150, 1));
			graphicsPath.AddRectangle(new Rectangle(num + 150, num2, 1, 150));
			graphicsPath.FillMode = FillMode.Winding;
			return new Region(graphicsPath);
		}

		private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
		}

		private int sel_index_from_cvtlist(BindingList<BindingList<CvPoint>> cvlist, CvPoint e)
		{
			int result = -1;
			if (cvlist != null)
			{
				for (int i = 0; i < cvlist.Count; i++)
				{
					if (cvlist[i] == null)
					{
						continue;
					}
					for (int j = 0; j < cvlist[i].Count; j++)
					{
						int num = Math.Abs(cvlist[i][j].X - e.X);
						int num2 = Math.Abs(mPic.Size.Height - 1 - cvlist[i][j].Y - e.Y);
						int num3 = num * num + num2 * num2;
						if (num3 <= 4)
						{
							return i;
						}
					}
				}
			}
			return result;
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			CvPoint e2 = new CvPoint(e.X, e.Y);
			int sel_index = -1;
			if (Math.Abs(e2.X - MainForm0.mJvs_usrWidth / 2) <= 75 && Math.Abs(e2.Y - MainForm0.mJvs_usrHeight / 2) <= 75)
			{
				sel_index = sel_index_from_cvtlist(mCtList, e2);
			}
			label_mousexy.Text = "(" + e2.X + ", " + e2.Y + ")";
			flush_paint(sel_index);
		}

		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			CvPoint e2 = new CvPoint(e.X, e.Y);
			int num = -1;
			if (Math.Abs(e2.X - MainForm0.mJvs_usrWidth / 2) <= 75 && Math.Abs(e2.Y - MainForm0.mJvs_usrHeight / 2) <= 75)
			{
				num = sel_index_from_cvtlist(mCtList, e2);
				if (num != -1 && MessageBox.Show("是否保存为Mark点匹配轮廓?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					mSavedMarch_Index = num;
					mselected_ctlist = mCtList[mSavedMarch_Index];
					Circle circle = MainForm0.FittingCircle(mCtList[mSavedMarch_Index]);
					mX_offset = circle.X - (double)(mPic.Width / 2);
					mY_offset = circle.Y - (double)(mPic.Height / 2);
					label_xoffset_v.Text = mX_offset.ToString();
					label_yoffset_v.Text = mY_offset.ToString();
					mPic_Mark = new Bitmap(150, 150);
					Rectangle destRect = new Rectangle(0, 0, 150, 150);
					int num2 = (mPic.Width - 150) / 2;
					int num3 = (mPic.Height - 150) / 2;
					Rectangle srcRect = new Rectangle(num2, num3, 150, 150);
					Graphics graphics = Graphics.FromImage(mPic_Mark);
					graphics.DrawImage(mPic, destRect, srcRect, GraphicsUnit.Pixel);
					graphics.Dispose();
					Bitmap bitmap = new Bitmap(mPic_Mark);
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
					pictureBox2.Image = bitmap;
				}
			}
		}

		private void trackBar_minpno_Scroll(object sender, EventArgs e)
		{
			if (!mMutex_MarkGen)
			{
				mMutex_MarkGen = true;
				mMinPno = trackBar_minpno.Value;
				label_minpno.Text = mMinPno.ToString();
				mPic_Ct = new Bitmap(mPic);
				mCtList = this.ImageVisual_MarkGen(mPic_Ct, ref mThreshold, mMinPno, mMaxPno);
				mMutex_MarkGen = false;
				flush_pictureBox1_picture();
			}
		}

		private void trackBar_maxpno_Scroll(object sender, EventArgs e)
		{
			if (!mMutex_MarkGen)
			{
				mMutex_MarkGen = true;
				mMaxPno = trackBar_maxpno.Value;
				label_maxpno.Text = mMaxPno.ToString();
				mPic_Ct = new Bitmap(mPic);
				mCtList = this.ImageVisual_MarkGen(mPic_Ct, ref mThreshold, mMinPno, mMaxPno);
				mMutex_MarkGen = false;
				flush_pictureBox1_picture();
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			if (!mMutex_MarkGen)
			{
				mMutex_MarkGen = true;
				mThreshold = trackBar1.Value;
				label2.Text = mThreshold.ToString();
				mPic_Ct = new Bitmap(mPic);
				mCtList = this.ImageVisual_MarkGen(mPic_Ct, ref mThreshold, mMinPno, mMaxPno);
				mMutex_MarkGen = false;
				flush_pictureBox1_picture();
			}
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button_matchTest_Click(object sender, EventArgs e)
		{
			if (mselected_ctlist != null && mselected_ctlist.Count >= 4 && !mMutex_MarkGen)
			{
				mMutex_MarkGen = true;
				mMaxPno = trackBar_maxpno.Value;
				label_maxpno.Text = mMaxPno.ToString();
				mPic_Ct = new Bitmap(mPic);
				int num = 10;
				double[] d = new double[num];
				this.ImageVisual_MarkMatch(mPic_Ct, mselected_ctlist, mThreshold, d, num);
				mMutex_MarkGen = false;
				flush_pictureBox1_picture();
			}
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			USR3.mMarkPara[mMarkNo].mPic = new Bitmap(mPic);
			USR3.mMarkPara[mMarkNo].mPicMark = new Bitmap(mPic_Mark);
			USR3.mMarkPara[mMarkNo].threshold = mThreshold;
			USR3.mMarkPara[mMarkNo].min_pno = mMinPno;
			USR3.mMarkPara[mMarkNo].max_pno = mMaxPno;
			USR3.mMarkPara[mMarkNo].x_offs = mX_offset;
			USR3.mMarkPara[mMarkNo].y_offs = mY_offset;
			USR3.mMarkPara[mMarkNo].cvlist = mselected_ctlist;
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_importPic_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Bitmap bitmap = new Bitmap(openFileDialog.FileName);
					Bitmap bitmap2 = new Bitmap(MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
					Rectangle destRect = new Rectangle(0, 0, MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
					Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - MainForm0.mJvs_usrWidth) / 2, 0, MainForm0.mJvs_usrHeight, MainForm0.mJvs_rawHeight);
					Graphics graphics = Graphics.FromImage(bitmap2);
					graphics.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);
					graphics.Dispose();
					mPic = new Bitmap(bitmap2);
					bitmap2.Dispose();
					bitmap.Dispose();
					mPic_Ct = new Bitmap(mPic);
					mCtList = this.ImageVisual_MarkGen(mPic_Ct, ref mThreshold, mMinPno, mMaxPno);
					flush_pictureBox1_picture();
				}
				catch (Exception)
				{
					MessageBox.Show("导入图片失败！");
				}
			}
		}

		private void button_matchTest0_Click(object sender, EventArgs e)
		{
			PointF leftpointf = default(PointF);
			PointF ptf = default(PointF);
			double num = MainForm0.uc_job[MainForm0.mFn].ImageVisual_MarkLegacy(mPic_Ct, USR3.mMarkPara[mMarkNo].mPicMark, USR3.mMarkPara[mMarkNo].picsize, ref leftpointf, ref ptf);
			if (num * 100.0 >= (double)USR3.mMarkPara[mMarkNo].recognizeRate)
			{
				Graphics graphics = pictureBox1.CreateGraphics();
				graphics.DrawRectangle(new Pen(Color.Red, 2f), new Rectangle((int)leftpointf.X, (int)leftpointf.Y, USR3.mMarkPara[mMarkNo].picsize, USR3.mMarkPara[mMarkNo].picsize));
				graphics.Dispose();
			}
		}

		private void numericUpDown_MarkPicSize_ValueChanged(object sender, EventArgs e)
		{
			USR3.mMarkPara[mMarkNo].picsize = (int)numericUpDown_MarkPicSize.Value;
		}

		private void numericUpDown_MarkRecognizeRate_ValueChanged(object sender, EventArgs e)
		{
			USR3.mMarkPara[mMarkNo].recognizeRate = (int)numericUpDown_MarkRecognizeRate.Value;
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
			panel1 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			trackBar1 = new System.Windows.Forms.TrackBar();
			label_mousexy = new System.Windows.Forms.Label();
			trackBar_maxpno = new System.Windows.Forms.TrackBar();
			trackBar_minpno = new System.Windows.Forms.TrackBar();
			label_maxpno = new System.Windows.Forms.Label();
			label_minpno = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			button_matchTest = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			button_importPic = new System.Windows.Forms.Button();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			label_xoffset = new System.Windows.Forms.Label();
			label_yoffset = new System.Windows.Forms.Label();
			label_xoffset_v = new System.Windows.Forms.Label();
			label_yoffset_v = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			numericUpDown_MarkPicSize = new System.Windows.Forms.NumericUpDown();
			numericUpDown_MarkRecognizeRate = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			button_matchTest0 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_maxpno).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_minpno).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkPicSize).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkRecognizeRate).BeginInit();
			SuspendLayout();
			pictureBox1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(417, 7);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(720, 720);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(pictureBox1_LoadCompleted);
			pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
			pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseClick);
			pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseMove);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(trackBar1);
			panel1.Location = new System.Drawing.Point(12, 125);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(361, 53);
			panel1.TabIndex = 1;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(318, 21);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(31, 14);
			label2.TabIndex = 1;
			label2.Text = "127";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(4, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(67, 14);
			label1.TabIndex = 1;
			label1.Text = "视觉阈值";
			trackBar1.Location = new System.Drawing.Point(77, 13);
			trackBar1.Maximum = 255;
			trackBar1.Name = "trackBar1";
			trackBar1.Size = new System.Drawing.Size(236, 45);
			trackBar1.TabIndex = 0;
			trackBar1.TickFrequency = 10;
			trackBar1.Value = 127;
			trackBar1.Scroll += new System.EventHandler(trackBar1_Scroll);
			label_mousexy.AutoSize = true;
			label_mousexy.Location = new System.Drawing.Point(311, 24);
			label_mousexy.Name = "label_mousexy";
			label_mousexy.Size = new System.Drawing.Size(63, 14);
			label_mousexy.TabIndex = 2;
			label_mousexy.Text = "鼠标位置";
			trackBar_maxpno.Location = new System.Drawing.Point(77, 38);
			trackBar_maxpno.Maximum = 2000;
			trackBar_maxpno.Name = "trackBar_maxpno";
			trackBar_maxpno.Size = new System.Drawing.Size(236, 45);
			trackBar_maxpno.TabIndex = 3;
			trackBar_maxpno.TickFrequency = 500;
			trackBar_maxpno.Value = 500;
			trackBar_maxpno.Scroll += new System.EventHandler(trackBar_maxpno_Scroll);
			trackBar_minpno.Location = new System.Drawing.Point(75, 9);
			trackBar_minpno.Maximum = 100;
			trackBar_minpno.Name = "trackBar_minpno";
			trackBar_minpno.Size = new System.Drawing.Size(236, 45);
			trackBar_minpno.TabIndex = 3;
			trackBar_minpno.TickFrequency = 50;
			trackBar_minpno.Value = 10;
			trackBar_minpno.Scroll += new System.EventHandler(trackBar_minpno_Scroll);
			label_maxpno.AutoSize = true;
			label_maxpno.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label_maxpno.Location = new System.Drawing.Point(319, 38);
			label_maxpno.Name = "label_maxpno";
			label_maxpno.Size = new System.Drawing.Size(31, 14);
			label_maxpno.TabIndex = 1;
			label_maxpno.Text = "500";
			label_minpno.AutoSize = true;
			label_minpno.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label_minpno.Location = new System.Drawing.Point(317, 9);
			label_minpno.Name = "label_minpno";
			label_minpno.Size = new System.Drawing.Size(23, 14);
			label_minpno.TabIndex = 1;
			label_minpno.Text = "10";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label4.Location = new System.Drawing.Point(4, 38);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(67, 14);
			label4.TabIndex = 1;
			label4.Text = "最大像素";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(4, 14);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(67, 14);
			label3.TabIndex = 1;
			label3.Text = "最小像素";
			pictureBox2.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox2.Location = new System.Drawing.Point(261, 275);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(150, 150);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 2;
			pictureBox2.TabStop = false;
			button_matchTest.Location = new System.Drawing.Point(103, 333);
			button_matchTest.Name = "button_matchTest";
			button_matchTest.Size = new System.Drawing.Size(85, 32);
			button_matchTest.TabIndex = 3;
			button_matchTest.Text = "精准匹配";
			button_matchTest.UseVisualStyleBackColor = true;
			button_matchTest.Click += new System.EventHandler(button_matchTest_Click);
			panel2.Controls.Add(trackBar_maxpno);
			panel2.Controls.Add(trackBar_minpno);
			panel2.Controls.Add(label_maxpno);
			panel2.Controls.Add(label_minpno);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label3);
			panel2.Location = new System.Drawing.Point(12, 169);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(361, 72);
			panel2.TabIndex = 4;
			button_importPic.Location = new System.Drawing.Point(12, 258);
			button_importPic.Name = "button_importPic";
			button_importPic.Size = new System.Drawing.Size(85, 43);
			button_importPic.TabIndex = 4;
			button_importPic.Text = "导入图片";
			button_importPic.UseVisualStyleBackColor = true;
			button_importPic.Click += new System.EventHandler(button_importPic_Click);
			button_ok.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_ok.Location = new System.Drawing.Point(28, 680);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(154, 47);
			button_ok.TabIndex = 5;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_cancel.Location = new System.Drawing.Point(224, 680);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(149, 47);
			button_cancel.TabIndex = 5;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			label_xoffset.AutoSize = true;
			label_xoffset.Location = new System.Drawing.Point(16, 372);
			label_xoffset.Name = "label_xoffset";
			label_xoffset.Size = new System.Drawing.Size(49, 14);
			label_xoffset.TabIndex = 2;
			label_xoffset.Text = "X偏移:";
			label_yoffset.AutoSize = true;
			label_yoffset.Location = new System.Drawing.Point(16, 393);
			label_yoffset.Name = "label_yoffset";
			label_yoffset.Size = new System.Drawing.Size(49, 14);
			label_yoffset.TabIndex = 2;
			label_yoffset.Text = "Y偏移:";
			label_xoffset_v.AutoSize = true;
			label_xoffset_v.Location = new System.Drawing.Point(71, 372);
			label_xoffset_v.Name = "label_xoffset_v";
			label_xoffset_v.Size = new System.Drawing.Size(49, 14);
			label_xoffset_v.TabIndex = 2;
			label_xoffset_v.Text = "X偏移:";
			label_yoffset_v.AutoSize = true;
			label_yoffset_v.Location = new System.Drawing.Point(71, 393);
			label_yoffset_v.Name = "label_yoffset_v";
			label_yoffset_v.Size = new System.Drawing.Size(49, 14);
			label_yoffset_v.TabIndex = 2;
			label_yoffset_v.Text = "Y偏移:";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("楷体", 12.5f);
			label5.Location = new System.Drawing.Point(141, 24);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(116, 17);
			label5.TabIndex = 2;
			label5.Text = "精准Mark定制";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("楷体", 11.5f);
			label6.Location = new System.Drawing.Point(23, 64);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(344, 48);
			label6.TabIndex = 2;
			label6.Text = "方法：请调节下面的参数，使得Mark圆点的轮廓\r\n被清晰解析，然后用鼠标选中圆点轮廓，保存为\r\nMark点。";
			numericUpDown_MarkPicSize.Location = new System.Drawing.Point(188, 256);
			numericUpDown_MarkPicSize.Maximum = new decimal(new int[4] { 150, 0, 0, 0 });
			numericUpDown_MarkPicSize.Name = "numericUpDown_MarkPicSize";
			numericUpDown_MarkPicSize.Size = new System.Drawing.Size(62, 23);
			numericUpDown_MarkPicSize.TabIndex = 6;
			numericUpDown_MarkPicSize.ValueChanged += new System.EventHandler(numericUpDown_MarkPicSize_ValueChanged);
			numericUpDown_MarkRecognizeRate.Location = new System.Drawing.Point(188, 285);
			numericUpDown_MarkRecognizeRate.Name = "numericUpDown_MarkRecognizeRate";
			numericUpDown_MarkRecognizeRate.Size = new System.Drawing.Size(62, 23);
			numericUpDown_MarkRecognizeRate.TabIndex = 6;
			numericUpDown_MarkRecognizeRate.ValueChanged += new System.EventHandler(numericUpDown_MarkRecognizeRate_ValueChanged);
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(119, 258);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(63, 14);
			label7.TabIndex = 2;
			label7.Text = "图像大小";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(118, 287);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(63, 14);
			label8.TabIndex = 2;
			label8.Text = "点识别率";
			button_matchTest0.Location = new System.Drawing.Point(12, 333);
			button_matchTest0.Name = "button_matchTest0";
			button_matchTest0.Size = new System.Drawing.Size(85, 32);
			button_matchTest0.TabIndex = 7;
			button_matchTest0.Text = "普通匹配";
			button_matchTest0.UseVisualStyleBackColor = true;
			button_matchTest0.Click += new System.EventHandler(button_matchTest0_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightCyan;
			base.ClientSize = new System.Drawing.Size(1146, 741);
			base.Controls.Add(button_matchTest0);
			base.Controls.Add(numericUpDown_MarkRecognizeRate);
			base.Controls.Add(numericUpDown_MarkPicSize);
			base.Controls.Add(button_importPic);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(label_yoffset_v);
			base.Controls.Add(label_yoffset);
			base.Controls.Add(label_xoffset_v);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label_mousexy);
			base.Controls.Add(label6);
			base.Controls.Add(button_matchTest);
			base.Controls.Add(label5);
			base.Controls.Add(label_xoffset);
			base.Controls.Add(panel2);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(panel1);
			base.Controls.Add(pictureBox1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_MarkGen";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_MarkGen_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_maxpno).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_minpno).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkPicSize).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_MarkRecognizeRate).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
