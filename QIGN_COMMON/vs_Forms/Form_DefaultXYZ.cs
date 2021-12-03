using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_DefaultXYZ : Form
	{
		private IContainer components;

		private Label label1;

		private Label label61;

		private Label label2;

		private Label label3;

		private NumericUpDown numericUpDown1;

		private Panel panel1;

		private Label label4;

		private Panel panel2;

		private Label label5;

		private NumericUpDown numericUpDown2;

		private USR_DATA USR;

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
			label1 = new System.Windows.Forms.Label();
			label61 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			panel1 = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14f);
			label1.Location = new System.Drawing.Point(28, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(129, 19);
			label1.TabIndex = 0;
			label1.Text = "快捷步距设置";
			label61.BackColor = System.Drawing.Color.Red;
			label61.Location = new System.Drawing.Point(29, 37);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(550, 4);
			label61.TabIndex = 176;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 12f);
			label2.Location = new System.Drawing.Point(35, 61);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(104, 16);
			label2.TabIndex = 0;
			label2.Text = "XY轴快捷步距";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 12f);
			label3.Location = new System.Drawing.Point(3, 10);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(48, 16);
			label3.TabIndex = 0;
			label3.Text = "默认1";
			numericUpDown1.Location = new System.Drawing.Point(57, 6);
			numericUpDown1.Maximum = new decimal(new int[4] { 50000, 0, 0, 0 });
			numericUpDown1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(74, 26);
			numericUpDown1.TabIndex = 177;
			numericUpDown1.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			panel1.Controls.Add(label3);
			panel1.Controls.Add(numericUpDown1);
			panel1.Location = new System.Drawing.Point(32, 86);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(537, 39);
			panel1.TabIndex = 178;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 12f);
			label4.Location = new System.Drawing.Point(35, 140);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(96, 16);
			label4.TabIndex = 0;
			label4.Text = "Z轴快捷步距";
			panel2.Controls.Add(label5);
			panel2.Controls.Add(numericUpDown2);
			panel2.Location = new System.Drawing.Point(32, 165);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(537, 39);
			panel2.TabIndex = 178;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 12f);
			label5.Location = new System.Drawing.Point(3, 10);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(48, 16);
			label5.TabIndex = 0;
			label5.Text = "默认1";
			numericUpDown2.Location = new System.Drawing.Point(57, 6);
			numericUpDown2.Maximum = new decimal(new int[4] { 50000, 0, 0, 0 });
			numericUpDown2.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new System.Drawing.Size(74, 26);
			numericUpDown2.TabIndex = 177;
			numericUpDown2.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightBlue;
			base.ClientSize = new System.Drawing.Size(617, 240);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(label61);
			base.Controls.Add(label4);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_DefaultXYZ";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_DefaultXYZ_Load);
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_DefaultXYZ(USR_DATA usr)
		{
			InitializeComponent();
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			USR = usr;
			string[] array = new string[3] { "快捷", "快捷", "Default" };
			panel1.Controls.Clear();
			for (int i = 0; i < 4; i++)
			{
				Label label = new Label();
				panel1.Controls.Add(label);
				label.Text = i + 1 + array[USR_INIT.mLanguage];
				label.Location = new Point(i * 130, 4);
				label.AutoSize = false;
				label.Size = new Size(50, 28);
				NumericUpDown numericUpDown = new NumericUpDown();
				panel1.Controls.Add(numericUpDown);
				numericUpDown.Size = new Size(60, 28);
				numericUpDown.Location = new Point(label.Size.Width + i * 130, 0);
				numericUpDown.Minimum = 1m;
				numericUpDown.Maximum = 50000m;
				numericUpDown.Value = USR.mXYStep_Defaults[i];
				numericUpDown.Tag = i;
				numericUpDown.ValueChanged += nup_default_xy_ValueChanged;
			}
			panel2.Controls.Clear();
			for (int j = 0; j < 4; j++)
			{
				Label label2 = new Label();
				panel2.Controls.Add(label2);
				label2.Text = j + 1 + array[USR_INIT.mLanguage];
				label2.Location = new Point(j * 130, 4);
				label2.AutoSize = false;
				label2.Size = new Size(50, 28);
				NumericUpDown numericUpDown2 = new NumericUpDown();
				panel2.Controls.Add(numericUpDown2);
				numericUpDown2.Size = new Size(60, 28);
				numericUpDown2.Location = new Point(label2.Size.Width + j * 130, 0);
				numericUpDown2.Minimum = 1m;
				numericUpDown2.Maximum = 5000m;
				numericUpDown2.Value = USR.mZStep_Defaults[j];
				numericUpDown2.Tag = j;
				numericUpDown2.ValueChanged += nup_default_z_ValueChanged;
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
				str = new string[3] { "快捷步距设置", "快捷步距设置", "Default Step Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "XY轴快捷步距", "XY轴快捷步距", "XY Default Step" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "Z轴快捷步距", "Z轴快捷步距", "Z Defauld Step" }
			});
			return list;
		}

		private void nup_default_xy_ValueChanged(object sender, EventArgs e)
		{
			int num = (int)((NumericUpDown)sender).Tag;
			USR.mXYStep_Defaults[num] = (int)((NumericUpDown)sender).Value;
		}

		private void nup_default_z_ValueChanged(object sender, EventArgs e)
		{
			int num = (int)((NumericUpDown)sender).Tag;
			USR.mZStep_Defaults[num] = (int)((NumericUpDown)sender).Value;
		}

		private void Form_DefaultXYZ_Load(object sender, EventArgs e)
		{
		}
	}
}
