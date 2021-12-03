using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_OptimizeResult : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private Panel panel1;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label label3;

		private Label label_result;

		private Button button1;

		private Button button2;

		private Panel panel2;

		private BindingList<ChipCategoryElement> mPointlistCat_History;

		private BindingList<ChipCategoryElement> mPointlistCat;

		private int mLanguage;

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
			panel1 = new System.Windows.Forms.Panel();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label_result = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			label1.BackColor = System.Drawing.Color.White;
			label1.Font = new System.Drawing.Font("黑体", 14.25f);
			label1.Location = new System.Drawing.Point(8, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(693, 36);
			label1.TabIndex = 0;
			label1.Text = "优化结果";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 12.25f);
			label2.Location = new System.Drawing.Point(9, 61);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(422, 17);
			label2.TabIndex = 1;
			label2.Text = "说明：具体安装请关闭本框后点击“吸嘴料站安装”";
			panel1.AutoScroll = true;
			panel1.BackColor = System.Drawing.Color.Snow;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label3);
			panel1.Font = new System.Drawing.Font("黑体", 11.25f);
			panel1.Location = new System.Drawing.Point(8, 99);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(693, 624);
			panel1.TabIndex = 2;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("黑体", 12.25f);
			label6.Location = new System.Drawing.Point(477, 7);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 0;
			label6.Text = "结果";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 12.25f);
			label5.Location = new System.Drawing.Point(329, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(62, 17);
			label5.TabIndex = 0;
			label5.Text = "优化后";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 12.25f);
			label4.Location = new System.Drawing.Point(173, 7);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(62, 17);
			label4.TabIndex = 0;
			label4.Text = "优化前";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 12.25f);
			label3.Location = new System.Drawing.Point(10, 7);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(80, 17);
			label3.TabIndex = 0;
			label3.Text = "元件类型";
			label_result.BackColor = System.Drawing.Color.White;
			label_result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_result.Font = new System.Drawing.Font("黑体", 13f);
			label_result.Location = new System.Drawing.Point(433, 53);
			label_result.Name = "label_result";
			label_result.Size = new System.Drawing.Size(267, 34);
			label_result.TabIndex = 3;
			label_result.Text = "结果： 优化成功...";
			label_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button1.Location = new System.Drawing.Point(2, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(200, 34);
			button1.TabIndex = 4;
			button1.Text = "恢复为优化前料站排布";
			button1.UseVisualStyleBackColor = true;
			button2.Location = new System.Drawing.Point(427, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(251, 32);
			button2.TabIndex = 4;
			button2.Text = "将错误的料站号设置为“自动”";
			button2.UseVisualStyleBackColor = true;
			panel2.Controls.Add(button2);
			panel2.Controls.Add(button1);
			panel2.Location = new System.Drawing.Point(6, 716);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(695, 39);
			panel2.TabIndex = 5;
			panel2.Visible = false;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightSalmon;
			base.ClientSize = new System.Drawing.Size(709, 757);
			base.Controls.Add(panel2);
			base.Controls.Add(label_result);
			base.Controls.Add(panel1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			base.Name = "Form_OptimizeResult";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_OptimizeResult_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_OptimizeResult(int language, BindingList<ChipCategoryElement> cat_history, BindingList<ChipCategoryElement> cat)
		{
			InitializeComponent();
			mPointlistCat_History = cat_history;
			mPointlistCat = cat;
			mLanguage = language;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "优化结果", "優化結果", "Optimization Result" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "说明：具体安装请关闭本框后点击“吸嘴料站安装”", "說明：具體安裝請關閉本框後點擊“吸嘴料站安裝”", "Note: Please Close this page!" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "元件类型", "元件類型", "Chip Type" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "优化前", "優化前", "Before Optimize" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "优化后", "優化後", "After Optimize" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "结果", "結果", "Result" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_result,
				str = new string[3] { "", "", "" }
			});
			return list;
		}

		private void Form_OptimizeResult_Load(object sender, EventArgs e)
		{
			Text = "";
			label3.Location = new Point(8, 6);
			label4.Location = new Point(190, 6);
			label5.Location = new Point(350, 6);
			label6.Location = new Point(452, 6);
			if (mPointlistCat_History == null || mPointlistCat == null || mPointlistCat_History.Count != mPointlistCat.Count)
			{
				return;
			}
			string text = ((mLanguage == 2) ? "Optimization Success!!" : "结果：优化成功...");
			for (int i = 0; i < mPointlistCat.Count; i++)
			{
				if (mPointlistCat[i].mOptimizeResult == OptimizeResult.Fail || mPointlistCat[i].mOptimizeResult == OptimizeResult.None)
				{
					text = ((mLanguage == 2) ? "Optimization Fail!!" : "结果：优化失败...");
					break;
				}
			}
			label_result.Text = text;
			int num = 30;
			int num2 = 25;
			int num3 = 2;
			for (int j = 0; j < mPointlistCat.Count; j++)
			{
				Label[] array = new Label[4];
				string text2 = ((mLanguage == 2) ? "Unknown" : "未知");
				if (mPointlistCat[j].Feedertype == FeederType.Plate)
				{
					text2 = STR.PROVIDER_STR[1][mLanguage];
				}
				else if (mPointlistCat[j].Feedertype == FeederType.Vibra)
				{
					text2 = STR.PROVIDER_STR[2][mLanguage];
				}
				else if (mPointlistCat[j].Feedertype >= FeederType.CL8_2_0201 && mPointlistCat[j].Feedertype < FeederType.N_A)
				{
					text2 = STR.PROVIDER_STR[0][mLanguage];
				}
				array[0] = new Label();
				panel1.Controls.Add(array[0]);
				array[0].Location = new Point(8, num + (num2 + num3) * j);
				array[0].AutoSize = false;
				array[0].Size = new Size(180, num2);
				array[0].TextAlign = ContentAlignment.MiddleLeft;
				array[0].Text = text2 + " " + mPointlistCat[j].Material_value + " " + mPointlistCat[j].Footprint;
				array[1] = new Label();
				panel1.Controls.Add(array[1]);
				array[1].Location = new Point(190, num + (num2 + num3) * j);
				array[1].AutoSize = false;
				array[1].Size = new Size(150, num2);
				array[1].TextAlign = ContentAlignment.MiddleLeft;
				array[1].Text = mPointlistCat_History[j].Feeder_no_S;
				array[2] = new Label();
				panel1.Controls.Add(array[2]);
				array[2].Location = new Point(350, num + (num2 + num3) * j);
				array[2].AutoSize = false;
				array[2].Size = new Size(100, num2);
				array[2].TextAlign = ContentAlignment.MiddleLeft;
				array[2].Text = mPointlistCat[j].Feeder_no_S;
				array[3] = new Label();
				panel1.Controls.Add(array[3]);
				array[3].Location = new Point(452, num + (num2 + num3) * j);
				array[3].AutoSize = false;
				array[3].Size = new Size(220, num2);
				array[3].TextAlign = ContentAlignment.MiddleLeft;
				array[3].Text = STR.OPTIMIZE_STR[(int)mPointlistCat[j].mOptimizeResult][mLanguage];
				Color[] array2 = new Color[4]
				{
					Color.LightGray,
					Color.Bisque,
					Color.LightPink,
					Color.Red
				};
				for (int k = 0; k < 4; k++)
				{
					array[k].BackColor = array2[(int)mPointlistCat[j].mOptimizeResult];
					array[k].Font = new Font(STR.LANGUAGE[mLanguage], 11f, FontStyle.Regular);
				}
			}
		}
	}
}
