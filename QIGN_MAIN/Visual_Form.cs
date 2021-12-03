using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using QIGN_COMMON;

namespace QIGN_MAIN
{
	public class Visual_Form : Form
	{
		private IContainer components;

		private Label label1;

		private PictureBox pictureBox_rawImage;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label_size;

		private TableLayoutPanel tableLayoutPanel1;

		private Label label_sost;

		private Label label_paost;

		private Label label_angle;

		private Label label_post;

		private Label label_state;

		private Label label6;

		private Label label7;

		private Label label8;

		private Button button_clear;

		private Panel panel1;

		private Panel panel_bigsmall;

		private Bitmap mBitmap;

		private int mBigSmall_Mode;

		private Button[] button_bigsmall;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.Visual_Form));
			pictureBox_rawImage = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label_size = new System.Windows.Forms.Label();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			label_state = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label_sost = new System.Windows.Forms.Label();
			label_paost = new System.Windows.Forms.Label();
			label_angle = new System.Windows.Forms.Label();
			label_post = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			button_clear = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			panel_bigsmall = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)pictureBox_rawImage).BeginInit();
			tableLayoutPanel1.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			pictureBox_rawImage.BackColor = System.Drawing.Color.Gray;
			pictureBox_rawImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_rawImage.Location = new System.Drawing.Point(0, 0);
			pictureBox_rawImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			pictureBox_rawImage.Name = "pictureBox_rawImage";
			pictureBox_rawImage.Size = new System.Drawing.Size(550, 550);
			pictureBox_rawImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_rawImage.TabIndex = 0;
			pictureBox_rawImage.TabStop = false;
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 10f);
			label1.Location = new System.Drawing.Point(3, 14);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(105, 14);
			label1.TabIndex = 1;
			label1.Text = "元件外形尺寸：";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 10f);
			label2.Location = new System.Drawing.Point(3, 28);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(105, 14);
			label2.TabIndex = 2;
			label2.Text = "元件型心偏差：";
			label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 10f);
			label3.Location = new System.Drawing.Point(3, 42);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(105, 14);
			label3.TabIndex = 2;
			label3.Text = "元件倾斜角度：";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 10f);
			label4.Location = new System.Drawing.Point(3, 56);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(105, 14);
			label4.TabIndex = 2;
			label4.Text = "纠偏中心偏差：";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 10f);
			label5.Location = new System.Drawing.Point(3, 70);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(98, 14);
			label5.TabIndex = 2;
			label5.Text = "SMT中心偏差：";
			label_size.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label_size.AutoSize = true;
			label_size.Font = new System.Drawing.Font("黑体", 10f);
			label_size.Location = new System.Drawing.Point(115, 14);
			label_size.Name = "label_size";
			label_size.Size = new System.Drawing.Size(126, 14);
			label_size.TabIndex = 3;
			label_size.Text = "0.000 * 0.000 @ 0";
			label_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68f));
			tableLayoutPanel1.Controls.Add(label_state, 1, 0);
			tableLayoutPanel1.Controls.Add(label6, 0, 0);
			tableLayoutPanel1.Controls.Add(label5, 0, 5);
			tableLayoutPanel1.Controls.Add(label4, 0, 4);
			tableLayoutPanel1.Controls.Add(label3, 0, 3);
			tableLayoutPanel1.Controls.Add(label2, 0, 2);
			tableLayoutPanel1.Controls.Add(label1, 0, 1);
			tableLayoutPanel1.Controls.Add(label_sost, 1, 5);
			tableLayoutPanel1.Controls.Add(label_paost, 1, 4);
			tableLayoutPanel1.Controls.Add(label_angle, 1, 3);
			tableLayoutPanel1.Controls.Add(label_post, 1, 2);
			tableLayoutPanel1.Controls.Add(label_size, 1, 1);
			tableLayoutPanel1.Controls.Add(label7, 0, 6);
			tableLayoutPanel1.Controls.Add(label8, 1, 6);
			tableLayoutPanel1.Location = new System.Drawing.Point(1, 554);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 7;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			tableLayoutPanel1.Size = new System.Drawing.Size(350, 111);
			tableLayoutPanel1.TabIndex = 4;
			label_state.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label_state.AutoSize = true;
			label_state.Font = new System.Drawing.Font("黑体", 10f);
			label_state.Location = new System.Drawing.Point(115, 0);
			label_state.Name = "label_state";
			label_state.Size = new System.Drawing.Size(91, 14);
			label_state.TabIndex = 8;
			label_state.Text = "未识别到元件";
			label_state.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("黑体", 10f);
			label6.Location = new System.Drawing.Point(3, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(105, 14);
			label6.TabIndex = 5;
			label6.Text = "元件识别结果：";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_sost.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label_sost.AutoSize = true;
			label_sost.Font = new System.Drawing.Font("黑体", 10f);
			label_sost.Location = new System.Drawing.Point(115, 70);
			label_sost.Name = "label_sost";
			label_sost.Size = new System.Drawing.Size(182, 14);
			label_sost.TabIndex = 7;
			label_sost.Text = "X:0.000 Y:0.000 A:0.000°";
			label_sost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_paost.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label_paost.AutoSize = true;
			label_paost.Font = new System.Drawing.Font("黑体", 10f);
			label_paost.Location = new System.Drawing.Point(115, 56);
			label_paost.Name = "label_paost";
			label_paost.Size = new System.Drawing.Size(112, 14);
			label_paost.TabIndex = 6;
			label_paost.Text = "X:0.000 Y:0.000";
			label_paost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_angle.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label_angle.AutoSize = true;
			label_angle.Font = new System.Drawing.Font("黑体", 10f);
			label_angle.Location = new System.Drawing.Point(115, 42);
			label_angle.Name = "label_angle";
			label_angle.Size = new System.Drawing.Size(56, 14);
			label_angle.TabIndex = 5;
			label_angle.Text = "0.000°";
			label_angle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_post.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label_post.AutoSize = true;
			label_post.Font = new System.Drawing.Font("黑体", 10f);
			label_post.Location = new System.Drawing.Point(115, 28);
			label_post.Name = "label_post";
			label_post.Size = new System.Drawing.Size(112, 14);
			label_post.TabIndex = 4;
			label_post.Text = "X:0.000 Y:0.000";
			label_post.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 10f);
			label7.Location = new System.Drawing.Point(3, 84);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(49, 14);
			label7.TabIndex = 2;
			label7.Text = "阀值：";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("黑体", 10f);
			label8.Location = new System.Drawing.Point(115, 84);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(77, 14);
			label8.TabIndex = 7;
			label8.Text = "THRHD: 128";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button_clear.Font = new System.Drawing.Font("黑体", 11f);
			button_clear.Location = new System.Drawing.Point(476, 624);
			button_clear.Name = "button_clear";
			button_clear.Size = new System.Drawing.Size(75, 28);
			button_clear.TabIndex = 6;
			button_clear.Text = "清除";
			button_clear.UseVisualStyleBackColor = true;
			button_clear.Click += new System.EventHandler(button_clear_Click);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(pictureBox_rawImage);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(550, 550);
			panel1.TabIndex = 7;
			panel_bigsmall.Font = new System.Drawing.Font("黑体", 11f);
			panel_bigsmall.Location = new System.Drawing.Point(359, 554);
			panel_bigsmall.Name = "panel_bigsmall";
			panel_bigsmall.Size = new System.Drawing.Size(191, 38);
			panel_bigsmall.TabIndex = 8;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			BackColor = System.Drawing.Color.LightBlue;
			base.ClientSize = new System.Drawing.Size(551, 661);
			base.Controls.Add(panel_bigsmall);
			base.Controls.Add(panel1);
			base.Controls.Add(button_clear);
			base.Controls.Add(tableLayoutPanel1);
			Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "Visual_Form";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.TopMost = true;
			base.Load += new System.EventHandler(Visual_Form_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox_rawImage).EndInit();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		public Visual_Form(int mLanguage)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			MainForm0.common_updateLanguage(mLanguage, initLanguageTable());
			mBitmap = new Bitmap(pictureBox_rawImage.Size.Width, pictureBox_rawImage.Size.Height);
			mBigSmall_Mode = 0;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_clear,
				str = new string[3] { "清除", "確定", "Clear" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "识别结果", "识别结果", "Visual Result" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "外形尺寸", "外形尺寸", "Chip Size" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "形心偏差", "形心偏差", "Shape Center Delta" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "倾斜角度", "倾斜角度", "Angle Theta" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "纠偏中心偏差", "纠偏中心偏差", "Modifed Center Delta" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "SMT中心偏差", "SMT中心偏差", "SMT Center Delta" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "阈值", "阈值", "Threshold" }
			});
			return list;
		}

		private void Visual_Form_Load(object sender, EventArgs e)
		{
			button_bigsmall = new Button[3];
			string[] array = new string[3] { "尺寸", "尺寸", "Size " };
			for (int i = 0; i < 3; i++)
			{
				button_bigsmall[i] = new Button();
				panel_bigsmall.Controls.Add(button_bigsmall[i]);
				button_bigsmall[i].Location = new Point(66 * i, 0);
				button_bigsmall[i].Size = new Size(60, 28);
				button_bigsmall[i].Text = array[MainForm0.USR_INIT.mLanguage] + i;
				button_bigsmall[i].ForeColor = Color.White;
				button_bigsmall[i].Font = new Font(DEF.FONT_2020[MainForm0.USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				SelButton_radioMode(button_bigsmall[i], i);
				button_bigsmall[i].Click += button_bigsmall_Click;
			}
			button_clear.Size = new Size(60, 28);
			MainForm0.CreateAddButtonPic(button_clear);
		}

		private void button_bigsmall_Click(object sender, EventArgs e)
		{
			ButtonTag buttonTag = (ButtonTag)((Button)sender).Tag;
			int tag = buttonTag.tag;
			if (tag >= 0 && tag < 3)
			{
				mBigSmall_Mode = tag;
				if (mBigSmall_Mode == 0)
				{
					pictureBox_rawImage.Size = new Size(550, 550);
					pictureBox_rawImage.Location = new Point(0, 0);
				}
				else if (mBigSmall_Mode == 1)
				{
					pictureBox_rawImage.Size = new Size(550 + (mBitmap.Size.Width - 550) / 2, 550 + (mBitmap.Size.Height - 550) / 2);
					pictureBox_rawImage.Location = new Point((550 - mBitmap.Size.Width) / 4, (550 - mBitmap.Size.Height) / 4);
				}
				else if (mBigSmall_Mode == 2)
				{
					pictureBox_rawImage.Size = new Size(mBitmap.Size.Width, mBitmap.Size.Height);
					pictureBox_rawImage.Location = new Point((550 - mBitmap.Size.Width) / 2, (550 - mBitmap.Size.Height) / 2);
				}
			}
		}

		private void SelButton_radioMode(Button btn, int init_index)
		{
			Bitmap map0 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData = map0.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap map1 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData2 = map1.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap map2 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData3 = map2.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			MainForm0.moon_qign_button_create(btn.Size.Width, btn.Size.Height, bitmapData.Scan0, 50, 50, 50, bitmapData2.Scan0, 0, 100, 255, bitmapData3.Scan0, 0, 100, 255);
			map0.UnlockBits(bitmapData);
			map1.UnlockBits(bitmapData2);
			map2.UnlockBits(bitmapData3);
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
			if (init_index != mBigSmall_Mode)
			{
				btn.BackgroundImage = map0;
			}
			else
			{
				btn.BackgroundImage = map2;
			}
			ButtonTag buttonTag = new ButtonTag();
			buttonTag.tag = init_index;
			buttonTag.map0 = map0;
			buttonTag.map1 = map1;
			buttonTag.map2 = map2;
			btn.Tag = buttonTag;
			btn.MouseEnter += delegate(object sender, EventArgs e)
			{
				if (((ButtonTag)btn.Tag).tag != mBigSmall_Mode)
				{
					((Button)sender).BackgroundImage = map1;
				}
			};
			btn.MouseLeave += delegate(object sender, EventArgs e)
			{
				if (((ButtonTag)btn.Tag).tag != mBigSmall_Mode)
				{
					((Button)sender).BackgroundImage = map0;
				}
			};
			btn.MouseDown += delegate(object sender, MouseEventArgs e)
			{
				if (((ButtonTag)btn.Tag).tag != mBigSmall_Mode)
				{
					((Button)sender).BackgroundImage = map2;
				}
			};
			btn.MouseUp += delegate
			{
				for (int i = 0; i < 3; i++)
				{
					if (((ButtonTag)btn.Tag).tag != i)
					{
						button_bigsmall[i].BackgroundImage = map0;
					}
				}
			};
		}

		public void ShowDetails(Image bmp, VisualResultString0 str)
		{
			if (bmp != null)
			{
				if (mBitmap != null)
				{
					mBitmap.Dispose();
					mBitmap = null;
				}
				if (mBitmap == null)
				{
					mBitmap = new Bitmap(bmp);
				}
				if (mBigSmall_Mode == 0)
				{
					pictureBox_rawImage.Size = new Size(550, 550);
					pictureBox_rawImage.Location = new Point(0, 0);
				}
				else if (mBigSmall_Mode == 1)
				{
					pictureBox_rawImage.Size = new Size(550 + (mBitmap.Size.Width - 550) / 2, 550 + (mBitmap.Size.Height - 550) / 2);
					pictureBox_rawImage.Location = new Point((550 - mBitmap.Size.Width) / 4, (550 - mBitmap.Size.Height) / 4);
				}
				else if (mBigSmall_Mode == 2)
				{
					pictureBox_rawImage.Size = new Size(mBitmap.Size.Width, mBitmap.Size.Height);
					pictureBox_rawImage.Location = new Point((550 - mBitmap.Size.Width) / 2, (550 - mBitmap.Size.Height) / 2);
				}
				pictureBox_rawImage.Image = mBitmap;
			}
			if (str != null)
			{
				label_state.Text = str.state;
				label_size.Text = str.size;
				label_post.Text = str.post;
				label_angle.Text = str.angle;
				label_paost.Text = str.paost;
				label_sost.Text = str.sost;
				label8.Text = str.threshold;
			}
			else
			{
				label_state.Text = "";
			}
		}

		private void button_clear_Click(object sender, EventArgs e)
		{
			pictureBox_rawImage.Image = null;
		}
	}
}
