using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace QIGN_COMMON
{
	public class Form_Optimization_Process : Form
	{
		private int mCountMax;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		private IContainer components;

		private ProgressBar progressBar_OP;

		private Label label_OP;

		private Button button_OP;

		public Form_Optimization_Process(int mLanguage, int count)
		{
			InitializeComponent();
			initLanguageTable();
			updateLanguage(mLanguage);
			mCountMax = count;
			button_OP.Visible = false;
			progressBar_OP.Maximum = mCountMax;
			progressBar_OP.Minimum = 0;
			progressBar_OP.ForeColor = Color.Red;
			progressBar_OP.BackColor = Color.Red;
			Thread thread = new Thread(thd_Go);
			thread.IsBackground = true;
			thread.Start();
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
					mLanguage2.ctrl.Font = new Font(DEF.FONT_2020[mLanguage], mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
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
				ctrl = label_OP,
				str = new string[3] { "正在优化，请稍等......", "正在优化，请稍等......", "RUNNING, PLEASE WAIT..." }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OP,
				str = new string[3] { "完成", "完成", "OK" }
			});
		}

		private void thd_Go()
		{
			int index = 0;
			for (index = 0; index <= mCountMax; index++)
			{
				Thread.Sleep(1);
				progressBar_OP.Invoke((MethodInvoker)delegate
				{
					progressBar_OP.Value = index;
				});
			}
			progressBar_OP.Invoke((MethodInvoker)delegate
			{
				progressBar_OP.Value = progressBar_OP.Maximum;
			});
			Thread.Sleep(400);
			base.DialogResult = DialogResult.OK;
		}

		private void thd_return()
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_OP_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.Form_Optimization_Process));
			progressBar_OP = new System.Windows.Forms.ProgressBar();
			label_OP = new System.Windows.Forms.Label();
			button_OP = new System.Windows.Forms.Button();
			SuspendLayout();
			progressBar_OP.Location = new System.Drawing.Point(55, 83);
			progressBar_OP.Name = "progressBar_OP";
			progressBar_OP.Size = new System.Drawing.Size(508, 54);
			progressBar_OP.TabIndex = 0;
			label_OP.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label_OP.Location = new System.Drawing.Point(56, 27);
			label_OP.Name = "label_OP";
			label_OP.Size = new System.Drawing.Size(358, 37);
			label_OP.TabIndex = 1;
			label_OP.Text = "正在优化，请稍等......";
			label_OP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button_OP.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
			button_OP.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OP.Location = new System.Drawing.Point(442, 28);
			button_OP.Name = "button_OP";
			button_OP.Size = new System.Drawing.Size(121, 36);
			button_OP.TabIndex = 2;
			button_OP.Text = "完成";
			button_OP.UseVisualStyleBackColor = false;
			button_OP.Click += new System.EventHandler(button_OP_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			base.ClientSize = new System.Drawing.Size(614, 160);
			base.Controls.Add(button_OP);
			base.Controls.Add(label_OP);
			base.Controls.Add(progressBar_OP);
			Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form_Optimization_Process";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.TopMost = true;
			ResumeLayout(false);
		}
	}
}
