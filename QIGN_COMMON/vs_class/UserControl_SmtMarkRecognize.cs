using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_SmtMarkRecognize : UserControl
	{
		private IContainer components;

		private TableLayoutPanel tableLayoutPanel_SMTMARK;

		private Panel panel37;

		private Button button_smtMark_X;

		private Label label_markbox_title;

		private Label label_MarkRecognizeRate;

		private PictureBox pictureBox_markConfirm;

		private Button button_markCancel;

		private Button button_markOk;

		private Label label1;

		private Button button_debugset;

		private Button button_simulate_fail;

		private USR3_DATA USR3;

		private USR_DATA USR;

		private int mMarkNo;

		private bool mIsAuto;

		private USR_INIT_DATA USR_INIT;

		private int mManualMark_Result;

		private int mFn;

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
			tableLayoutPanel_SMTMARK = new System.Windows.Forms.TableLayoutPanel();
			panel37 = new System.Windows.Forms.Panel();
			button_simulate_fail = new System.Windows.Forms.Button();
			button_debugset = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			button_markCancel = new System.Windows.Forms.Button();
			button_smtMark_X = new System.Windows.Forms.Button();
			button_markOk = new System.Windows.Forms.Button();
			label_markbox_title = new System.Windows.Forms.Label();
			label_MarkRecognizeRate = new System.Windows.Forms.Label();
			pictureBox_markConfirm = new System.Windows.Forms.PictureBox();
			tableLayoutPanel_SMTMARK.SuspendLayout();
			panel37.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_markConfirm).BeginInit();
			SuspendLayout();
			tableLayoutPanel_SMTMARK.BackColor = System.Drawing.Color.LightCoral;
			tableLayoutPanel_SMTMARK.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
			tableLayoutPanel_SMTMARK.ColumnCount = 1;
			tableLayoutPanel_SMTMARK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel_SMTMARK.Controls.Add(panel37, 0, 0);
			tableLayoutPanel_SMTMARK.Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			tableLayoutPanel_SMTMARK.Location = new System.Drawing.Point(1, 5);
			tableLayoutPanel_SMTMARK.Name = "tableLayoutPanel_SMTMARK";
			tableLayoutPanel_SMTMARK.RowCount = 1;
			tableLayoutPanel_SMTMARK.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel_SMTMARK.Size = new System.Drawing.Size(291, 291);
			tableLayoutPanel_SMTMARK.TabIndex = 157;
			panel37.Anchor = System.Windows.Forms.AnchorStyles.None;
			panel37.Controls.Add(button_simulate_fail);
			panel37.Controls.Add(button_debugset);
			panel37.Controls.Add(label1);
			panel37.Controls.Add(button_markCancel);
			panel37.Controls.Add(button_smtMark_X);
			panel37.Controls.Add(button_markOk);
			panel37.Controls.Add(label_markbox_title);
			panel37.Controls.Add(label_MarkRecognizeRate);
			panel37.Controls.Add(pictureBox_markConfirm);
			panel37.Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel37.Location = new System.Drawing.Point(5, 5);
			panel37.Name = "panel37";
			panel37.Size = new System.Drawing.Size(281, 281);
			panel37.TabIndex = 157;
			button_simulate_fail.Location = new System.Drawing.Point(231, 83);
			button_simulate_fail.Name = "button_simulate_fail";
			button_simulate_fail.Size = new System.Drawing.Size(42, 40);
			button_simulate_fail.TabIndex = 150;
			button_simulate_fail.Text = "设定失败";
			button_simulate_fail.UseVisualStyleBackColor = true;
			button_simulate_fail.Visible = false;
			button_simulate_fail.Click += new System.EventHandler(button_simulate_fail_Click);
			button_debugset.Location = new System.Drawing.Point(11, 235);
			button_debugset.Name = "button_debugset";
			button_debugset.Size = new System.Drawing.Size(40, 32);
			button_debugset.TabIndex = 149;
			button_debugset.Text = "修改调试";
			button_debugset.UseVisualStyleBackColor = true;
			button_debugset.Click += new System.EventHandler(button_debugset_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 14f);
			label1.Location = new System.Drawing.Point(117, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 19);
			label1.TabIndex = 148;
			label1.Text = "Mark1";
			button_markCancel.Font = new System.Drawing.Font("楷体", 10f);
			button_markCancel.Location = new System.Drawing.Point(147, 234);
			button_markCancel.Name = "button_markCancel";
			button_markCancel.Size = new System.Drawing.Size(68, 33);
			button_markCancel.TabIndex = 6;
			button_markCancel.Text = "未确认";
			button_markCancel.UseVisualStyleBackColor = true;
			button_markCancel.Click += new System.EventHandler(button_markCancel_Click);
			button_smtMark_X.BackColor = System.Drawing.Color.Goldenrod;
			button_smtMark_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_smtMark_X.Location = new System.Drawing.Point(249, 1);
			button_smtMark_X.Name = "button_smtMark_X";
			button_smtMark_X.Size = new System.Drawing.Size(32, 32);
			button_smtMark_X.TabIndex = 142;
			button_smtMark_X.Text = "X";
			button_smtMark_X.UseVisualStyleBackColor = true;
			button_smtMark_X.Click += new System.EventHandler(button_smtMark_X_Click);
			button_markOk.Font = new System.Drawing.Font("楷体", 10f);
			button_markOk.ForeColor = System.Drawing.Color.DarkRed;
			button_markOk.Location = new System.Drawing.Point(67, 235);
			button_markOk.Name = "button_markOk";
			button_markOk.Size = new System.Drawing.Size(68, 32);
			button_markOk.TabIndex = 5;
			button_markOk.Text = "确认";
			button_markOk.UseVisualStyleBackColor = true;
			button_markOk.Click += new System.EventHandler(button_markOk_Click);
			label_markbox_title.Font = new System.Drawing.Font("楷体", 12.25f);
			label_markbox_title.Location = new System.Drawing.Point(8, 41);
			label_markbox_title.Name = "label_markbox_title";
			label_markbox_title.Size = new System.Drawing.Size(265, 26);
			label_markbox_title.TabIndex = 141;
			label_markbox_title.Text = "自动匹配失败，切换为手动确认";
			label_markbox_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_MarkRecognizeRate.BackColor = System.Drawing.Color.White;
			label_MarkRecognizeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_MarkRecognizeRate.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_MarkRecognizeRate.Location = new System.Drawing.Point(66, 235);
			label_MarkRecognizeRate.Name = "label_MarkRecognizeRate";
			label_MarkRecognizeRate.Size = new System.Drawing.Size(150, 31);
			label_MarkRecognizeRate.TabIndex = 147;
			label_MarkRecognizeRate.Text = "识别率：";
			label_MarkRecognizeRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			pictureBox_markConfirm.BackColor = System.Drawing.Color.Gray;
			pictureBox_markConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_markConfirm.Location = new System.Drawing.Point(67, 83);
			pictureBox_markConfirm.Name = "pictureBox_markConfirm";
			pictureBox_markConfirm.Size = new System.Drawing.Size(150, 150);
			pictureBox_markConfirm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_markConfirm.TabIndex = 7;
			pictureBox_markConfirm.TabStop = false;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(tableLayoutPanel_SMTMARK);
			base.Name = "UserControl_SmtMarkRecognize";
			base.Size = new System.Drawing.Size(295, 296);
			base.Load += new System.EventHandler(UserControl_SmtMarkRecognize_Load);
			tableLayoutPanel_SMTMARK.ResumeLayout(false);
			panel37.ResumeLayout(false);
			panel37.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_markConfirm).EndInit();
			ResumeLayout(false);
		}

		public UserControl_SmtMarkRecognize(int fn, USR_DATA usr, USR3_DATA usr3, int markno, bool isauto)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR3 = usr3;
			USR_INIT = MainForm0.USR_INIT;
			mMarkNo = markno;
			mIsAuto = isauto;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			if (USR3.mMarkPic[markno] != null)
			{
				Bitmap bitmap = new Bitmap(USR3.mMarkPic[markno]);
				bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
				pictureBox_markConfirm.Image = bitmap;
			}
			else
			{
				pictureBox_markConfirm.Image = null;
			}
			label_MarkRecognizeRate.Visible = mIsAuto;
			button_markOk.Visible = !mIsAuto;
			button_markCancel.Visible = !mIsAuto;
			label1.Text = "Mark" + (markno + 1);
			label_markbox_title.Text = (new string[3] { "自动匹配", "自動匹配", "Auto Match" })[USR_INIT.mLanguage];
			button_debugset.Visible = MainForm0.mIsSimulation;
			button_simulate_fail.Visible = MainForm0.mIsSimulation;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_markbox_title,
				str = new string[3] { "自动匹配失败，切换为手动确认", "自動匹配失敗，切換為手動確認", "Auto match fail, switch to manual mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_markOk,
				str = new string[3] { "确定", "確定", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_markCancel,
				str = new string[3] { "未确认", "未確認", "Cancel" }
			});
			return list;
		}

		private void button_smtMark_X_Click(object sender, EventArgs e)
		{
			mManualMark_Result = 2;
			MainForm0.uc_job[MainForm0.mFn].vsplus_stopsmt();
			MainForm0.uc_job[MainForm0.mFn].mbMarkDoneMutex = true;
			base.Visible = false;
		}

		private void button_markOk_Click(object sender, EventArgs e)
		{
			mManualMark_Result = 0;
			MainForm0.uc_job[MainForm0.mFn].mbMarkDoneMutex = true;
			base.Visible = false;
		}

		private void button_markCancel_Click(object sender, EventArgs e)
		{
			mManualMark_Result = 1;
			MainForm0.mRunDoing[mFn] &= 2;
			MainForm0.uc_job[MainForm0.mFn].mbMarkDoneMutex = true;
			base.Visible = false;
		}

		public int get_mark_ok()
		{
			return mManualMark_Result;
		}

		public void set_mark_ok()
		{
			mManualMark_Result = 0;
		}

		public void set_mode(USR3_DATA usr3, int markno, bool is_auto, string str)
		{
			USR3 = usr3;
			mIsAuto = is_auto;
			mMarkNo = markno;
			label_MarkRecognizeRate.Visible = mIsAuto;
			button_markOk.Visible = !mIsAuto;
			button_markCancel.Visible = !mIsAuto;
			label1.Text = "Mark" + (markno + 1);
			label_markbox_title.Text = str;
			if (USR3.mMarkPic[markno] != null)
			{
				Bitmap bitmap = new Bitmap(USR3.mMarkPic[markno]);
				bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
				pictureBox_markConfirm.Image = bitmap;
			}
			else
			{
				pictureBox_markConfirm.Image = null;
			}
		}

		public void set_recognizerate(float rate)
		{
			label_MarkRecognizeRate.Text = (new string[3] { "识别率:", "識別率:", "Match Rate" })[USR_INIT.mLanguage] + rate.ToString("F3");
		}

		private void button_debugset_Click(object sender, EventArgs e)
		{
			Form_FillXY form_FillXY = new Form_FillXY(MainForm0.uc_job[MainForm0.mFn].mMarkFound[mMarkNo], USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				MainForm0.uc_job[MainForm0.mFn].mMarkFound[mMarkNo].X = fillXY.X;
				MainForm0.uc_job[MainForm0.mFn].mMarkFound[mMarkNo].Y = fillXY.Y;
			}
		}

		private void button_simulate_fail_Click(object sender, EventArgs e)
		{
			mManualMark_Result = 1;
		}

		private void UserControl_SmtMarkRecognize_Load(object sender, EventArgs e)
		{
		}
	}
}
