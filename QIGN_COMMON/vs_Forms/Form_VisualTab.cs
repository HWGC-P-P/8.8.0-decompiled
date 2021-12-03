using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_VisualTab : Form
	{
		private IContainer components;

		private PictureBox pictureBox1;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private CnButton cnButton_ok;

		private CnButton cnButton_cancel;

		private Label label2;

		private VisualType m_VisualType;

		private LoopType m_LoopType;

		private RadioButton[] radioButtons_vis;

		private RadioButton[] radioButtons_loop;

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
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			label2 = new System.Windows.Forms.Label();
			cnButton_cancel = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_ok = new QIGN_COMMON.vs_acontrol.CnButton();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel2.SuspendLayout();
			SuspendLayout();
			pictureBox1.BackColor = System.Drawing.Color.DimGray;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(49, 103);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(128, 128);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			panel1.Location = new System.Drawing.Point(199, 25);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(606, 228);
			panel1.TabIndex = 1;
			label1.Font = new System.Drawing.Font("黑体", 16f);
			label1.Location = new System.Drawing.Point(29, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(164, 56);
			label1.TabIndex = 2;
			label1.Text = "标准视觉";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel2.Controls.Add(radioButton3);
			panel2.Controls.Add(radioButton2);
			panel2.Controls.Add(radioButton1);
			panel2.Location = new System.Drawing.Point(49, 259);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(756, 90);
			panel2.TabIndex = 3;
			radioButton3.AutoSize = true;
			radioButton3.Font = new System.Drawing.Font("黑体", 12f);
			radioButton3.Location = new System.Drawing.Point(14, 35);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(90, 20);
			radioButton3.TabIndex = 3;
			radioButton3.TabStop = true;
			radioButton3.Text = "二阶闭环";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Font = new System.Drawing.Font("黑体", 12f);
			radioButton2.Location = new System.Drawing.Point(14, 57);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(378, 20);
			radioButton2.TabIndex = 2;
			radioButton2.TabStop = true;
			radioButton2.Text = "精准闭环（高清相机有效，普通相机同二阶闭环）";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Font = new System.Drawing.Font("黑体", 12f);
			radioButton1.Location = new System.Drawing.Point(14, 14);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(90, 20);
			radioButton1.TabIndex = 1;
			radioButton1.TabStop = true;
			radioButton1.Text = "普通开环";
			radioButton1.UseVisualStyleBackColor = true;
			label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Location = new System.Drawing.Point(49, 256);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(781, 4);
			label2.TabIndex = 5;
			cnButton_cancel.BackColor = System.Drawing.SystemColors.ControlDark;
			cnButton_cancel.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_cancel.CnPressDownColor = System.Drawing.Color.White;
			cnButton_cancel.Location = new System.Drawing.Point(459, 355);
			cnButton_cancel.Name = "cnButton_cancel";
			cnButton_cancel.Size = new System.Drawing.Size(99, 31);
			cnButton_cancel.TabIndex = 4;
			cnButton_cancel.Text = "取消";
			cnButton_cancel.UseVisualStyleBackColor = false;
			cnButton_cancel.Click += new System.EventHandler(cnButton_cancel_Click);
			cnButton_ok.BackColor = System.Drawing.SystemColors.ControlDark;
			cnButton_ok.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_ok.CnPressDownColor = System.Drawing.Color.White;
			cnButton_ok.Location = new System.Drawing.Point(265, 355);
			cnButton_ok.Name = "cnButton_ok";
			cnButton_ok.Size = new System.Drawing.Size(99, 31);
			cnButton_ok.TabIndex = 4;
			cnButton_ok.Text = "确定";
			cnButton_ok.UseVisualStyleBackColor = false;
			cnButton_ok.Click += new System.EventHandler(cnButton_ok_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(870, 407);
			base.Controls.Add(label2);
			base.Controls.Add(cnButton_cancel);
			base.Controls.Add(cnButton_ok);
			base.Controls.Add(panel2);
			base.Controls.Add(label1);
			base.Controls.Add(panel1);
			base.Controls.Add(pictureBox1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_VisualTab";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_VisualTab_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		public Form_VisualTab(VisualType vistype, LoopType looptype)
		{
			InitializeComponent();
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			radioButtons_loop = new RadioButton[3] { radioButton1, radioButton3, radioButton2 };
			for (int i = 0; i < 3; i++)
			{
				radioButtons_loop[i].Tag = i;
				radioButtons_loop[i].CheckedChanged += radioButton_loop_CheckedChanged;
				radioButtons_loop[i].Checked = ((i == (int)(looptype - 1)) ? true : false);
			}
			m_LoopType = looptype;
			int vmtab_viscounts = MainForm0.get_vmtab_viscounts();
			if (vmtab_viscounts <= 0)
			{
				return;
			}
			radioButtons_vis = new RadioButton[vmtab_viscounts];
			int num = 0;
			for (int j = 0; j < MainForm0.vmLib.Count(); j++)
			{
				if (MainForm0.vmLib[j].vTab == null)
				{
					continue;
				}
				for (int k = 0; k < MainForm0.vmLib[j].vTab.Count(); k++)
				{
					radioButtons_vis[num] = new RadioButton();
					panel1.Controls.Add(radioButtons_vis[num]);
					radioButtons_vis[num].Location = new Point(num / 8 * 130, num % 8 * 28);
					radioButtons_vis[num].AutoSize = false;
					radioButtons_vis[num].Size = new Size(120, 25);
					radioButtons_vis[num].CheckedChanged += radioButtons_vis_CheckedChanged;
					radioButtons_vis[num].Tag = MainForm0.vmLib[j].vTab[k].vistype;
					radioButtons_vis[num].Text = MainForm0.vmLib[j].vTab[k].name;
					if (MainForm0.vmLib[j].vTab[k].vistype == vistype)
					{
						radioButtons_vis[num].Checked = true;
					}
					num++;
				}
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton1,
				str = new string[3] { "普通开环", "普通开环", "Open Loop" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton3,
				str = new string[3] { "二阶闭环", "二阶闭环", "Half Loop" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton2,
				str = new string[3] { "精准闭环（高清相机有效，普通相机同二阶闭环）", "精准闭环（高清相机有效，普通相机同二阶闭环）", "Close Loop (Only for H-Cam)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_ok,
				str = new string[3] { "确定", "确定", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_cancel,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "标准视觉", "标准视觉", "Standard Algorithoms" }
			});
			return list;
		}

		private void radioButton_loop_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			int num = (int)((RadioButton)sender).Tag;
			if (radioButton.Checked)
			{
				m_LoopType = (LoopType)(num + 1);
			}
		}

		private void radioButtons_vis_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			VisualType visualType = (VisualType)radioButton.Tag;
			if (radioButton.Checked)
			{
				int_2d int_2d = MainForm0.get_vmtab_visindex(visualType);
				if (int_2d.a != -1 && int_2d.b != -1)
				{
					pictureBox1.Image = MainForm0.vmLib[int_2d.a].vTab[int_2d.b].pic;
					label1.Text = MainForm0.vmLib[int_2d.a].vTab[int_2d.b].name;
					m_VisualType = visualType;
				}
			}
		}

		private void Form_VisualTab_Load(object sender, EventArgs e)
		{
		}

		public VisualType get_visualtype()
		{
			return m_VisualType;
		}

		public LoopType get_looptype()
		{
			return m_LoopType;
		}

		private void cnButton_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void cnButton_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}
	}
}
