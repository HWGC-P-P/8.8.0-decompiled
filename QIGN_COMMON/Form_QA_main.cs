using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON
{
	public class Form_QA_main : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private Label label9;

		private Label label10;

		private Label label4;

		private Label label11;

		private Label label12;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button4;

		private Button button5;

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
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.BackColor = System.Drawing.Color.White;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(13, 9);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 33);
			label1.TabIndex = 1;
			label1.Text = "?";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(53, 13);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(50, 25);
			label2.TabIndex = 2;
			label2.Text = "帮助";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("微软雅黑", 36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(163, 136);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(72, 62);
			label9.TabIndex = 3;
			label9.Text = "➠";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(13, 78);
			label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(525, 25);
			label10.TabIndex = 2;
			label10.Text = "当您第一次拿到机器，您必须按照以下步骤来使用您的机器！";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("微软雅黑", 36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(341, 136);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(72, 62);
			label4.TabIndex = 3;
			label4.Text = "➠";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("微软雅黑", 36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(565, 137);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(72, 62);
			label11.TabIndex = 3;
			label11.Text = "➠";
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("微软雅黑", 36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(801, 137);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(72, 62);
			label12.TabIndex = 3;
			label12.Text = "➠";
			button1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button1.Location = new System.Drawing.Point(7, 142);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(150, 66);
			button1.TabIndex = 4;
			button1.Text = "机型和语言设置";
			button1.UseVisualStyleBackColor = true;
			button2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button2.Location = new System.Drawing.Point(227, 142);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(99, 66);
			button2.TabIndex = 4;
			button2.Text = "连接设备";
			button2.UseVisualStyleBackColor = true;
			button3.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button3.Location = new System.Drawing.Point(406, 142);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(165, 66);
			button3.TabIndex = 4;
			button3.Text = "设备误差校准";
			button3.UseVisualStyleBackColor = true;
			button4.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button4.Location = new System.Drawing.Point(630, 142);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(165, 66);
			button4.TabIndex = 4;
			button4.Text = "用户工程建立编辑";
			button4.UseVisualStyleBackColor = true;
			button5.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button5.Location = new System.Drawing.Point(867, 142);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(99, 66);
			button5.TabIndex = 4;
			button5.Text = "贴装运行";
			button5.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 19f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.GhostWhite;
			base.ClientSize = new System.Drawing.Size(1021, 274);
			base.Controls.Add(button4);
			base.Controls.Add(button3);
			base.Controls.Add(button5);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(label12);
			base.Controls.Add(label11);
			base.Controls.Add(label4);
			base.Controls.Add(label9);
			base.Controls.Add(label10);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_QA_main";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_QA_main(int mLanguage)
		{
			InitializeComponent();
			initLanguageTable();
			updateLanguage(mLanguage);
		}

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
				switch (mLanguage)
				{
				case 2:
					mLanguage2.ctrl.Font = new Font("Oswald", mLanguage2.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					mLanguage2.ctrl.Font = new Font("微软雅黑", mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
					break;
				}
			}
		}

		private void initLanguageTable()
		{
			mLanguageList.Add(new LanguageItem
			{
				ctrl = label2,
				str = new string[3] { "帮助", "帮助", "HELP" }
			});
			mLanguageList.Add(new LanguageItem
			{
				ctrl = label10,
				str = new string[3] { "当您第一次拿到机器，您必须按照以下步骤来使用您的机器！", "当您第一次拿到机器，您必须按照以下步骤来使用您的机器！", "If it is a new machine, you have to do the following steps to start your machine!" }
			});
			mLanguageList.Add(new LanguageItem
			{
				ctrl = button1,
				str = new string[3] { "机型和语言设置", "机型和语言设置", "Device Type and Language" }
			});
			mLanguageList.Add(new LanguageItem
			{
				ctrl = button2,
				str = new string[3] { "连接设备", "连接设备", "Connect Device" }
			});
			mLanguageList.Add(new LanguageItem
			{
				ctrl = button3,
				str = new string[3] { "设备误差校准", "设备误差校准", "Calibration" }
			});
			mLanguageList.Add(new LanguageItem
			{
				ctrl = button4,
				str = new string[3] { "用户工程建立编辑", "用户工程建立编辑", "User Project Create and Edit" }
			});
			mLanguageList.Add(new LanguageItem
			{
				ctrl = button5,
				str = new string[3] { "贴装运行", "贴装运行", "Run SMT" }
			});
		}
	}
}
