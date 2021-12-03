using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QIGN_COMMON
{
	public class Form_AHD8Test : Form
	{
		private DvrshMethod.RAWSTREAM_DIRECT_CALLBACK imageCallback;

		private DvrshMethod.VIDEOSTATUS_CALLBACK m_VideoStatusCallback;

		public int m_Max_Video_Channels;

		public int m_InitDone;

		public int[] m_hDSP;

		public int m_SupportGray;

		public RECT pre_rect;

		public RadioButton[] rb;

		public int cur_chno;

		public bool SnapshotFLAG;

		public bool rndSnapshotFLAG;

		public Bitmap bmp;

		public IntPtr rgbdata;

		public int totalrno;

		private IContainer components;

		private Label label1;

		private Button button1;

		private Panel panel1;

		private Button button2;

		private PictureBox pictureBox1;

		private Button button3;

		private Timer timer1;

		private Label label2;

		private PictureBox pictureBox_preview;

		private Panel panel2;

		public Form_AHD8Test()
		{
			InitializeComponent();
			m_InitDone = 0;
			m_SupportGray = 0;
			m_hDSP = new int[64];
			for (int i = 0; i < 64; i++)
			{
				m_hDSP[i] = -1;
			}
			pre_rect.left = pictureBox_preview.Left;
			pre_rect.right = pictureBox_preview.Right;
			pre_rect.top = pictureBox_preview.Top;
			pre_rect.bottom = pictureBox_preview.Bottom;
			cur_chno = 0;
			SnapshotFLAG = false;
			rndSnapshotFLAG = false;
			bmp = new Bitmap(1280, 720, PixelFormat.Format24bppRgb);
			rgbdata = Marshal.AllocHGlobal(2764800);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (m_InitDone == 1)
			{
				ExitVideoSys();
			}
			DvrshMethod.SetMax_VideoSize(1280, 720);
			DvrshMethod.InitHwDSPs();
			m_Max_Video_Channels = DvrshMethod.GetVideoTotalChannels();
			if (m_Max_Video_Channels == 0)
			{
				MessageBox.Show("没有采集卡！");
				return;
			}
			for (int i = 0; i < m_Max_Video_Channels; i++)
			{
				m_hDSP[i] = DvrshMethod.VideoChannelOpen(i, 1280, 720, 25);
			}
			rb = new RadioButton[m_Max_Video_Channels];
			for (int j = 0; j < m_Max_Video_Channels; j++)
			{
				rb[j] = new RadioButton();
				rb[j].AutoSize = true;
				rb[j].Location = new Point(10 + j * 50, 10);
				rb[j].Name = (j + 1).ToString();
				rb[j].Size = new Size(95, 16);
				rb[j].TabStop = true;
				rb[j].Text = (j + 1).ToString();
				rb[j].UseVisualStyleBackColor = true;
				rb[j].Tag = j;
				rb[j].Checked = false;
				panel1.Controls.Add(rb[j]);
				rb[j].CheckedChanged += RB_CChanged;
			}
			rb[0].Checked = true;
			imageCallback = CallbackFun;
			DvrshMethod.RegisterRAWDirectCallback(imageCallback, base.Handle);
			m_InitDone = 1;
			timer1.Start();
		}

		private void RB_CChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				int num = (int)radioButton.Tag;
				DvrshMethod.StartVideoPreview(m_hDSP[cur_chno], IntPtr.Zero, ref pre_rect);
				DvrshMethod.StartVideoPreview(m_hDSP[num], pictureBox_preview.Handle, ref pre_rect);
				cur_chno = num;
			}
		}

		public void ExitVideoSys()
		{
			if (m_InitDone == 0)
			{
				return;
			}
			for (int i = 0; i < 64; i++)
			{
				if (m_hDSP[i] != -1)
				{
					DvrshMethod.StopVideoCapture(m_hDSP[i]);
					m_hDSP[i] = -1;
				}
			}
			DvrshMethod.DeInitHwDSPs();
			for (int j = 0; j < m_Max_Video_Channels; j++)
			{
				rb[j].CheckedChanged -= RB_CChanged;
				panel1.Controls.Remove(rb[j]);
			}
			m_InitDone = 0;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			rndSnapshotFLAG = false;
			SnapshotFLAG = true;
		}

		public void CallbackFun(int channelNumber, IntPtr DataBuf, int FrameType, int width, int height, IntPtr context)
		{
			if (SnapshotFLAG && (channelNumber == cur_chno || rndSnapshotFLAG))
			{
				DvrshMethod.ChangeYUVToRGB(DataBuf, rgbdata, width, height);
				UpdateBitmap(bmp, rgbdata, width, height);
				Graphics graphics = Graphics.FromImage(bmp);
				graphics.DrawString(channelNumber + 1 + "   " + totalrno, new Font("黑体", 9f, FontStyle.Italic), new SolidBrush(Color.White), new Point(10, 10));
				graphics.Dispose();
				pictureBox1.Image = bmp;
				SnapshotFLAG = false;
				rndSnapshotFLAG = false;
			}
		}

		public void UpdateBitmap(Bitmap bitmap, IntPtr rgbImageData, int originalWidth, int originalHeight)
		{
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			if (m_SupportGray == 0)
			{
				DvrshMethod.CopyMemory(scan, rgbImageData, (uint)(originalWidth * originalHeight * 3));
			}
			else
			{
				DvrshMethod.CopyMemory(scan, rgbImageData, (uint)(originalWidth * originalHeight));
			}
			bitmap.UnlockBits(bitmapData);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			rndSnapshotFLAG = true;
			SnapshotFLAG = true;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label2.Text = totalrno.ToString();
			if (totalrno % 100 == 0)
			{
				SnapshotFLAG = true;
			}
			totalrno++;
		}

		private void Form_AHD8Test_Load(object sender, EventArgs e)
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
			components = new System.ComponentModel.Container();
			label1 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			button3 = new System.Windows.Forms.Button();
			timer1 = new System.Windows.Forms.Timer(components);
			label2 = new System.Windows.Forms.Label();
			pictureBox_preview = new System.Windows.Forms.PictureBox();
			panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_preview).BeginInit();
			panel2.SuspendLayout();
			SuspendLayout();
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.Location = new System.Drawing.Point(319, 73);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(640, 360);
			label1.TabIndex = 0;
			label1.Text = "预览窗口";
			button1.Location = new System.Drawing.Point(658, 12);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(143, 58);
			button1.TabIndex = 1;
			button1.Text = "开启";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Location = new System.Drawing.Point(12, 389);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(947, 40);
			panel1.TabIndex = 2;
			button2.Location = new System.Drawing.Point(816, 12);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(143, 58);
			button2.TabIndex = 4;
			button2.Text = "通道抓图";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(12, 457);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(640, 360);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 5;
			pictureBox1.TabStop = false;
			button3.Location = new System.Drawing.Point(816, 76);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(143, 58);
			button3.TabIndex = 6;
			button3.Text = "随机抓图";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			timer1.Interval = 40;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(846, 786);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(41, 12);
			label2.TabIndex = 7;
			label2.Text = "label2";
			pictureBox_preview.BackColor = System.Drawing.SystemColors.ControlDark;
			pictureBox_preview.Location = new System.Drawing.Point(-139, 0);
			pictureBox_preview.Name = "pictureBox_preview";
			pictureBox_preview.Size = new System.Drawing.Size(640, 344);
			pictureBox_preview.TabIndex = 8;
			pictureBox_preview.TabStop = false;
			panel2.Controls.Add(pictureBox_preview);
			panel2.Location = new System.Drawing.Point(688, 237);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(360, 441);
			panel2.TabIndex = 9;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1166, 834);
			base.Controls.Add(panel2);
			base.Controls.Add(label2);
			base.Controls.Add(button3);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(button2);
			base.Controls.Add(panel1);
			base.Controls.Add(button1);
			base.Controls.Add(label1);
			base.Name = "Form_AHD8Test";
			Text = "Form1";
			base.Load += new System.EventHandler(Form_AHD8Test_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_preview).EndInit();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
