using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_PikFail_HCamPrecise : Form
	{
		private IContainer components;

		private Panel panel_err_info;

		private Button button_Continue;

		private Button button_Retry;

		private Button button_Ignore;

		private Button button_Exit;

		private Label label_err_info;

		private Label label1;

		private Button button_adjustpara;

		private Button button_IgnorOnce;

		private Button button_stopwarning;

		public PikFail mPikFail;

		public bool is_rebackto_plate;

		public ProviderType mProviderType;

		private int mFn;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.Form_PikFail_HCamPrecise));
			panel_err_info = new System.Windows.Forms.Panel();
			label_err_info = new System.Windows.Forms.Label();
			button_Continue = new System.Windows.Forms.Button();
			button_Retry = new System.Windows.Forms.Button();
			button_Ignore = new System.Windows.Forms.Button();
			button_Exit = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			button_adjustpara = new System.Windows.Forms.Button();
			button_IgnorOnce = new System.Windows.Forms.Button();
			button_stopwarning = new System.Windows.Forms.Button();
			panel_err_info.SuspendLayout();
			SuspendLayout();
			panel_err_info.BackColor = System.Drawing.Color.Linen;
			panel_err_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_err_info.Controls.Add(label_err_info);
			panel_err_info.Location = new System.Drawing.Point(26, 45);
			panel_err_info.Name = "panel_err_info";
			panel_err_info.Size = new System.Drawing.Size(621, 109);
			panel_err_info.TabIndex = 0;
			label_err_info.AutoSize = true;
			label_err_info.Font = new System.Drawing.Font("楷体", 11.5f);
			label_err_info.Location = new System.Drawing.Point(3, 10);
			label_err_info.Name = "label_err_info";
			label_err_info.Size = new System.Drawing.Size(88, 16);
			label_err_info.TabIndex = 0;
			label_err_info.Text = "识别失败: ";
			button_Continue.BackColor = System.Drawing.Color.RosyBrown;
			button_Continue.Font = new System.Drawing.Font("黑体", 11.5f);
			button_Continue.Location = new System.Drawing.Point(26, 160);
			button_Continue.Name = "button_Continue";
			button_Continue.Size = new System.Drawing.Size(98, 38);
			button_Continue.TabIndex = 1;
			button_Continue.Text = "继续视觉";
			button_Continue.UseVisualStyleBackColor = true;
			button_Continue.Click += new System.EventHandler(button_Continue_Click);
			button_Retry.BackColor = System.Drawing.Color.RosyBrown;
			button_Retry.Font = new System.Drawing.Font("黑体", 11.5f);
			button_Retry.Location = new System.Drawing.Point(146, 160);
			button_Retry.Name = "button_Retry";
			button_Retry.Size = new System.Drawing.Size(98, 38);
			button_Retry.TabIndex = 1;
			button_Retry.Text = "重取继续";
			button_Retry.UseVisualStyleBackColor = true;
			button_Retry.Click += new System.EventHandler(button_Retry_Click);
			button_Ignore.BackColor = System.Drawing.Color.RosyBrown;
			button_Ignore.Font = new System.Drawing.Font("黑体", 11.5f);
			button_Ignore.Location = new System.Drawing.Point(391, 160);
			button_Ignore.Name = "button_Ignore";
			button_Ignore.Size = new System.Drawing.Size(98, 38);
			button_Ignore.TabIndex = 1;
			button_Ignore.Text = "不贴此料";
			button_Ignore.UseVisualStyleBackColor = true;
			button_Ignore.Click += new System.EventHandler(button_Ignore_Click);
			button_Exit.BackColor = System.Drawing.Color.RosyBrown;
			button_Exit.Font = new System.Drawing.Font("黑体", 11.5f);
			button_Exit.Location = new System.Drawing.Point(549, 160);
			button_Exit.Name = "button_Exit";
			button_Exit.Size = new System.Drawing.Size(98, 38);
			button_Exit.TabIndex = 1;
			button_Exit.Text = "结束贴装";
			button_Exit.UseVisualStyleBackColor = true;
			button_Exit.Click += new System.EventHandler(button_Exit_Click);
			label1.Font = new System.Drawing.Font("黑体", 13.5f);
			label1.Location = new System.Drawing.Point(23, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(621, 33);
			label1.TabIndex = 0;
			label1.Text = "高清相机精准闭环识别失败";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_adjustpara.Enabled = false;
			button_adjustpara.Font = new System.Drawing.Font("黑体", 11.5f);
			button_adjustpara.Location = new System.Drawing.Point(549, 204);
			button_adjustpara.Name = "button_adjustpara";
			button_adjustpara.Size = new System.Drawing.Size(98, 30);
			button_adjustpara.TabIndex = 2;
			button_adjustpara.Text = "参数调整";
			button_adjustpara.UseVisualStyleBackColor = true;
			button_IgnorOnce.Font = new System.Drawing.Font("黑体", 11.5f);
			button_IgnorOnce.Location = new System.Drawing.Point(267, 160);
			button_IgnorOnce.Name = "button_IgnorOnce";
			button_IgnorOnce.Size = new System.Drawing.Size(98, 38);
			button_IgnorOnce.TabIndex = 3;
			button_IgnorOnce.Text = "跳过一次";
			button_IgnorOnce.UseVisualStyleBackColor = true;
			button_IgnorOnce.Click += new System.EventHandler(button_IgnorOnce_Click);
			button_stopwarning.Font = new System.Drawing.Font("黑体", 11.5f);
			button_stopwarning.Location = new System.Drawing.Point(549, 9);
			button_stopwarning.Name = "button_stopwarning";
			button_stopwarning.Size = new System.Drawing.Size(98, 30);
			button_stopwarning.TabIndex = 4;
			button_stopwarning.Text = "停止报警";
			button_stopwarning.UseVisualStyleBackColor = true;
			button_stopwarning.Click += new System.EventHandler(button_stopwarning_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(677, 245);
			base.Controls.Add(button_stopwarning);
			base.Controls.Add(button_IgnorOnce);
			base.Controls.Add(button_adjustpara);
			base.Controls.Add(label1);
			base.Controls.Add(button_Exit);
			base.Controls.Add(button_Ignore);
			base.Controls.Add(button_Retry);
			base.Controls.Add(button_Continue);
			base.Controls.Add(panel_err_info);
			Font = new System.Drawing.Font("黑体", 9f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form_PikFail_HCamPrecise";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.TopMost = true;
			base.Load += new System.EventHandler(Form_PikFail_HCamPrecise_Load);
			panel_err_info.ResumeLayout(false);
			panel_err_info.PerformLayout();
			ResumeLayout(false);
		}

		public Form_PikFail_HCamPrecise(int fn, string err_msg, int mLanguage, ProviderType providertype)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			initLanguageTable();
			updateLanguage(mLanguage);
			mFn = fn;
			base.ControlBox = false;
			label_err_info.Text = err_msg;
			mProviderType = providertype;
		}

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
				if (mLanguage2.font != null && mLanguage2.fsize != null)
				{
					mLanguage2.ctrl.Font = new Font(mLanguage2.font[mLanguage], mLanguage2.ctrl.Font.Size + mLanguage2.fsize[mLanguage], mLanguage2.ctrl.Font.Style);
					continue;
				}
				switch (mLanguage)
				{
				case 2:
					mLanguage2.ctrl.Font = new Font("Oswald", mLanguage2.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					mLanguage2.ctrl.Font = new Font(DEF.FONT_2020_TITLE[mLanguage], mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
					break;
				}
			}
		}

		private void initLanguageTable()
		{
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = this,
				str = new string[3] { " ", " ", " " }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Continue,
				str = new string[3] { "继续视觉", "继续视觉", "CONTINUE TRY" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Retry,
				str = new string[3] { "重取继续", "重取继续", "RE-PICK AND TRY" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Ignore,
				str = new string[3] { "不贴此料", "不贴此料", "SKIP THE CATEGORY" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Exit,
				str = new string[3] { "结束贴装", "结束贴装", "ABORT SMT" }
			});
		}

		private void button_Continue_Click(object sender, EventArgs e)
		{
			mPikFail = PikFail.Continue;
			base.DialogResult = DialogResult.Yes;
		}

		private void button_Retry_Click(object sender, EventArgs e)
		{
			is_rebackto_plate = false;
			if (mProviderType == ProviderType.Plate && MainForm0.CmMessageBox("是否放回料盘（料盘起始位置会指向下一个）？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				is_rebackto_plate = true;
			}
			mPikFail = PikFail.Retry;
			base.DialogResult = DialogResult.Retry;
		}

		private void button_Ignore_Click(object sender, EventArgs e)
		{
			is_rebackto_plate = false;
			if (mProviderType == ProviderType.Plate && MainForm0.CmMessageBox("是否放回料盘（料盘起始位置会指向下一个）？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				is_rebackto_plate = true;
			}
			mPikFail = PikFail.SkipChip;
			base.DialogResult = DialogResult.Ignore;
		}

		private void button_IgnorOnce_Click(object sender, EventArgs e)
		{
			is_rebackto_plate = false;
			if (mProviderType == ProviderType.Plate && MainForm0.CmMessageBox("是否放回料盘（料盘起始位置会指向下一个）？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				is_rebackto_plate = true;
			}
			mPikFail = PikFail.SkipOnce;
			base.DialogResult = DialogResult.Ignore;
		}

		private void button_Exit_Click(object sender, EventArgs e)
		{
			is_rebackto_plate = false;
			if (mProviderType == ProviderType.Plate && MainForm0.CmMessageBox("是否放回料盘（料盘起始位置会指向下一个）？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				is_rebackto_plate = true;
			}
			mPikFail = PikFail.Exit;
			base.DialogResult = DialogResult.Abort;
		}

		public bool is_RebackChip()
		{
			return is_rebackto_plate;
		}

		public PikFail get_pikfail()
		{
			return mPikFail;
		}

		private void Form_PikFail_HCamPrecise_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_Continue);
			MainForm0.CreateAddButtonPic(button_Retry);
			MainForm0.CreateAddButtonPic(button_IgnorOnce);
			MainForm0.CreateAddButtonPic(button_Ignore);
			MainForm0.CreateAddButtonPic(button_Exit);
			MainForm0.CreateAddButtonPic(button_stopwarning);
			MainForm0.CreateAddButtonPic(button_adjustpara);
		}

		private void button_stopwarning_Click(object sender, EventArgs e)
		{
			MainForm0.mIsBuzzerWarning[mFn] = false;
		}
	}
}
