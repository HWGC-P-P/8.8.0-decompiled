using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_StartSmt : Form
	{
		private IContainer components;

		private Button button_autoSmt;

		private Button button_manualSmt;

		private RadioButton radioButton_rememberMark;

		private RadioButton radioButton_originalMark;

		private Panel panel1;

		private Panel panel2;

		private RadioButton radioButton3;

		private RadioButton radioButton_autoMark;

		private Panel panel_autosmt;

		private Panel panel_manulsmt;

		private Panel panel3;

		private Panel panel4;

		private NumericUpDown numericUpDown1;

		private Label label2;

		private Label label1;

		public USR3_DATA USR3;

		public int mLanguage;

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
			button_autoSmt = new System.Windows.Forms.Button();
			button_manualSmt = new System.Windows.Forms.Button();
			radioButton_rememberMark = new System.Windows.Forms.RadioButton();
			radioButton_originalMark = new System.Windows.Forms.RadioButton();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton_autoMark = new System.Windows.Forms.RadioButton();
			panel_autosmt = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			panel_manulsmt = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel_autosmt.SuspendLayout();
			panel_manulsmt.SuspendLayout();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			SuspendLayout();
			button_autoSmt.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_autoSmt.Location = new System.Drawing.Point(17, 19);
			button_autoSmt.Name = "button_autoSmt";
			button_autoSmt.Size = new System.Drawing.Size(134, 76);
			button_autoSmt.TabIndex = 0;
			button_autoSmt.Text = "全自动贴装";
			button_autoSmt.UseVisualStyleBackColor = true;
			button_autoSmt.Click += new System.EventHandler(button_autoSmt_Click);
			button_manualSmt.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_manualSmt.Location = new System.Drawing.Point(17, 22);
			button_manualSmt.Name = "button_manualSmt";
			button_manualSmt.Size = new System.Drawing.Size(140, 76);
			button_manualSmt.TabIndex = 0;
			button_manualSmt.Text = "手动贴装";
			button_manualSmt.UseVisualStyleBackColor = true;
			button_manualSmt.Click += new System.EventHandler(button_manualSmt_Click);
			radioButton_rememberMark.AutoSize = true;
			radioButton_rememberMark.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton_rememberMark.Location = new System.Drawing.Point(3, 3);
			radioButton_rememberMark.Name = "radioButton_rememberMark";
			radioButton_rememberMark.Size = new System.Drawing.Size(90, 20);
			radioButton_rememberMark.TabIndex = 1;
			radioButton_rememberMark.Text = "记忆Mark";
			radioButton_rememberMark.UseVisualStyleBackColor = true;
			radioButton_originalMark.AutoSize = true;
			radioButton_originalMark.Checked = true;
			radioButton_originalMark.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton_originalMark.Location = new System.Drawing.Point(3, 23);
			radioButton_originalMark.Name = "radioButton_originalMark";
			radioButton_originalMark.Size = new System.Drawing.Size(90, 20);
			radioButton_originalMark.TabIndex = 1;
			radioButton_originalMark.TabStop = true;
			radioButton_originalMark.Text = "原始Mark";
			radioButton_originalMark.UseVisualStyleBackColor = true;
			panel1.Controls.Add(radioButton_originalMark);
			panel1.Controls.Add(radioButton_rememberMark);
			panel1.Location = new System.Drawing.Point(34, 92);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(117, 49);
			panel1.TabIndex = 2;
			panel1.Visible = false;
			panel2.Controls.Add(radioButton3);
			panel2.Controls.Add(radioButton_autoMark);
			panel2.Location = new System.Drawing.Point(40, 95);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(117, 49);
			panel2.TabIndex = 2;
			radioButton3.AutoSize = true;
			radioButton3.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton3.Location = new System.Drawing.Point(3, 23);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(90, 20);
			radioButton3.TabIndex = 1;
			radioButton3.Text = "手动Mark";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton_autoMark.AutoSize = true;
			radioButton_autoMark.Checked = true;
			radioButton_autoMark.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton_autoMark.Location = new System.Drawing.Point(3, 3);
			radioButton_autoMark.Name = "radioButton_autoMark";
			radioButton_autoMark.Size = new System.Drawing.Size(90, 20);
			radioButton_autoMark.TabIndex = 1;
			radioButton_autoMark.TabStop = true;
			radioButton_autoMark.Text = "自动Mark";
			radioButton_autoMark.UseVisualStyleBackColor = true;
			panel_autosmt.Controls.Add(button_autoSmt);
			panel_autosmt.Controls.Add(panel3);
			panel_autosmt.Controls.Add(panel1);
			panel_autosmt.Location = new System.Drawing.Point(94, 36);
			panel_autosmt.Name = "panel_autosmt";
			panel_autosmt.Size = new System.Drawing.Size(164, 143);
			panel_autosmt.TabIndex = 3;
			panel3.Location = new System.Drawing.Point(0, 162);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(336, 36);
			panel3.TabIndex = 5;
			panel_manulsmt.Controls.Add(button_manualSmt);
			panel_manulsmt.Controls.Add(panel2);
			panel_manulsmt.Location = new System.Drawing.Point(273, 33);
			panel_manulsmt.Name = "panel_manulsmt";
			panel_manulsmt.Size = new System.Drawing.Size(171, 146);
			panel_manulsmt.TabIndex = 4;
			panel4.BackColor = System.Drawing.Color.MistyRose;
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel4.Controls.Add(numericUpDown1);
			panel4.Controls.Add(label1);
			panel4.Controls.Add(label2);
			panel4.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel4.Location = new System.Drawing.Point(111, 172);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(319, 59);
			panel4.TabIndex = 6;
			numericUpDown1.DecimalPlaces = 1;
			numericUpDown1.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown1.Location = new System.Drawing.Point(192, 4);
			numericUpDown1.Maximum = new decimal(new int[4] { 50, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(90, 29);
			numericUpDown1.TabIndex = 6;
			numericUpDown1.ValueChanged += new System.EventHandler(numericUpDown1_ValueChanged);
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.LightCoral;
			label1.Font = new System.Drawing.Font("楷体", 11.5f);
			label1.Location = new System.Drawing.Point(13, 36);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(288, 16);
			label1.TabIndex = 5;
			label1.Text = "PCB板上已有器件的最高高度（会保存）";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 13.25f);
			label2.Location = new System.Drawing.Point(52, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(134, 18);
			label2.TabIndex = 5;
			label2.Text = "初始海拔：毫米";
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LightCoral;
			base.ClientSize = new System.Drawing.Size(541, 242);
			base.Controls.Add(panel4);
			base.Controls.Add(panel_manulsmt);
			base.Controls.Add(panel_autosmt);
			Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Form_StartSmt";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel_autosmt.ResumeLayout(false);
			panel_manulsmt.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			ResumeLayout(false);
		}

		public Form_StartSmt(int language, string mode, USR3_DATA usr3)
		{
			InitializeComponent();
			USR3 = usr3;
			mLanguage = language;
			initLanguageTable();
			updateLanguage(mLanguage);
			if (HW.mSmtGenerationNo == 0)
			{
				panel4.Visible = false;
			}
			else
			{
				panel4.Visible = true;
				numericUpDown1.Value = (decimal)USR3.mSmtOriginBaseHeight;
			}
			switch (mode)
			{
			case "section":
			case "continue":
				panel_autosmt.Visible = false;
				panel_manulsmt.Location = new Point(178, panel_manulsmt.Location.Y);
				break;
			}
		}

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
				if (mLanguage2.font != null)
				{
					mLanguage2.ctrl.Font = new Font(mLanguage2.font[mLanguage], mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
					continue;
				}
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
				font = DEF.FONT_2020_TITLE,
				ctrl = button_autoSmt,
				str = new string[3] { "全自动贴装", "全自动贴装", "Auto Smt" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				ctrl = button_manualSmt,
				str = new string[3] { "手动贴装", "手动贴装", "Manual Smt" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				ctrl = radioButton_rememberMark,
				str = new string[3] { "记忆Mark", "记忆Mark", "Remember Mark" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				ctrl = radioButton_originalMark,
				str = new string[3] { "原始Mark", "原始Mark", "Original Mark" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				ctrl = radioButton_autoMark,
				str = new string[3] { "自动Mark", "自动Mark", "Auto Mark" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				ctrl = radioButton3,
				str = new string[3] { "手动Mark", "手动Mark", "Manual Mark" }
			});
		}

		private void button_manualSmt_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button_autoSmt_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		public bool IsRememberMark()
		{
			return radioButton_rememberMark.Checked;
		}

		public bool IsAutoMark()
		{
			return radioButton_autoMark.Checked;
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (USR3 != null)
			{
				USR3.mSmtOriginBaseHeight = (float)numericUpDown1.Value;
			}
		}
	}
}
