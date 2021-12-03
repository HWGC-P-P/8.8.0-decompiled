using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.Properties;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_DebugUsr : Form
	{
		private USR_DATA USR;

		private IContainer components;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TextBox textBox1;

		private Label label2;

		private Label label1;

		private Panel panel1;

		private Label label_haiba;

		private Label label6;

		private Panel panel2;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private PictureBox pictureBox8;

		private PictureBox pictureBox4;

		private PictureBox pictureBox7;

		private PictureBox pictureBox6;

		private PictureBox pictureBox3;

		private PictureBox pictureBox5;

		private Panel panel3;

		private Label label3;

		private Label label5;

		private Label label4;

		private TabPage tabPage3;

		private NumericUpDown numericUpDown_debug_rate;

		private Label label7;

		public Form_DebugUsr(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
			numericUpDown_debug_rate.Value = (decimal)USR.mDebug_rate;
		}

		public void set_haiba(float haiba)
		{
			int num = label_haiba.Size.Height;
			int num2 = (int)((double)(haiba * 5f) + 0.5);
			label_haiba.Size = new Size(label_haiba.Size.Width, num2);
			label_haiba.Location = new Point(label_haiba.Location.X, label_haiba.Location.Y - (num2 - num));
		}

		private void numericUpDown_debug_rate_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mDebug_rate = (float)numericUpDown_debug_rate.Value;
			}
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
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			textBox1 = new System.Windows.Forms.TextBox();
			tabPage2 = new System.Windows.Forms.TabPage();
			panel3 = new System.Windows.Forms.Panel();
			panel1 = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			pictureBox8 = new System.Windows.Forms.PictureBox();
			pictureBox4 = new System.Windows.Forms.PictureBox();
			pictureBox7 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox6 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			pictureBox5 = new System.Windows.Forms.PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label2 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label_haiba = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			tabPage3 = new System.Windows.Forms.TabPage();
			label7 = new System.Windows.Forms.Label();
			numericUpDown_debug_rate = new System.Windows.Forms.NumericUpDown();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_debug_rate).BeginInit();
			SuspendLayout();
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			tabControl1.Location = new System.Drawing.Point(12, 51);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(865, 579);
			tabControl1.TabIndex = 0;
			tabPage1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			tabPage1.Controls.Add(textBox1);
			tabPage1.Location = new System.Drawing.Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(857, 551);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "输出信息";
			textBox1.BackColor = System.Drawing.SystemColors.ControlDark;
			textBox1.Location = new System.Drawing.Point(0, 0);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(861, 581);
			textBox1.TabIndex = 0;
			tabPage2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			tabPage2.Controls.Add(panel3);
			tabPage2.Location = new System.Drawing.Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(857, 551);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "全自动高度";
			panel3.Controls.Add(panel1);
			panel3.Controls.Add(label3);
			panel3.Controls.Add(panel2);
			panel3.Controls.Add(label2);
			panel3.Controls.Add(label5);
			panel3.Controls.Add(label4);
			panel3.Controls.Add(label_haiba);
			panel3.Controls.Add(label1);
			panel3.Location = new System.Drawing.Point(6, 6);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(833, 413);
			panel3.TabIndex = 4;
			panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel1.Location = new System.Drawing.Point(9, 386);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(813, 89);
			panel1.TabIndex = 0;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label3.Location = new System.Drawing.Point(621, 300);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(40, 16);
			label3.TabIndex = 4;
			label3.Text = "海拔";
			panel2.Controls.Add(pictureBox8);
			panel2.Controls.Add(pictureBox4);
			panel2.Controls.Add(pictureBox7);
			panel2.Controls.Add(pictureBox2);
			panel2.Controls.Add(pictureBox6);
			panel2.Controls.Add(pictureBox3);
			panel2.Controls.Add(pictureBox5);
			panel2.Controls.Add(pictureBox1);
			panel2.Location = new System.Drawing.Point(265, 41);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(321, 107);
			panel2.TabIndex = 3;
			pictureBox8.Image = QIGN_COMMON.Properties.Resources.NOZZLE;
			pictureBox8.Location = new System.Drawing.Point(280, 0);
			pictureBox8.Name = "pictureBox8";
			pictureBox8.Size = new System.Drawing.Size(40, 100);
			pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox8.TabIndex = 2;
			pictureBox8.TabStop = false;
			pictureBox4.Image = QIGN_COMMON.Properties.Resources.NOZZLE;
			pictureBox4.Location = new System.Drawing.Point(120, 0);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new System.Drawing.Size(40, 100);
			pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox4.TabIndex = 2;
			pictureBox4.TabStop = false;
			pictureBox7.Image = QIGN_COMMON.Properties.Resources.NOZZLE;
			pictureBox7.Location = new System.Drawing.Point(200, 0);
			pictureBox7.Name = "pictureBox7";
			pictureBox7.Size = new System.Drawing.Size(40, 100);
			pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox7.TabIndex = 2;
			pictureBox7.TabStop = false;
			pictureBox2.Image = QIGN_COMMON.Properties.Resources.NOZZLE;
			pictureBox2.Location = new System.Drawing.Point(40, 0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(40, 100);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 2;
			pictureBox2.TabStop = false;
			pictureBox6.Image = QIGN_COMMON.Properties.Resources.NOZZLE;
			pictureBox6.Location = new System.Drawing.Point(240, 0);
			pictureBox6.Name = "pictureBox6";
			pictureBox6.Size = new System.Drawing.Size(40, 100);
			pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox6.TabIndex = 2;
			pictureBox6.TabStop = false;
			pictureBox3.Image = QIGN_COMMON.Properties.Resources.NOZZLE;
			pictureBox3.Location = new System.Drawing.Point(80, 0);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(40, 100);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 2;
			pictureBox3.TabStop = false;
			pictureBox5.Image = QIGN_COMMON.Properties.Resources.NOZZLE;
			pictureBox5.Location = new System.Drawing.Point(160, 0);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new System.Drawing.Size(40, 100);
			pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox5.TabIndex = 2;
			pictureBox5.TabStop = false;
			pictureBox1.Image = QIGN_COMMON.Properties.Resources.NOZZLE;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 100);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			label2.BackColor = System.Drawing.Color.LimeGreen;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Location = new System.Drawing.Point(230, 317);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(402, 16);
			label2.TabIndex = 1;
			label5.BackColor = System.Drawing.Color.Black;
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label5.Location = new System.Drawing.Point(631, 317);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(23, 72);
			label5.TabIndex = 1;
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.BackColor = System.Drawing.Color.Black;
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label4.Location = new System.Drawing.Point(209, 316);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(23, 72);
			label4.TabIndex = 1;
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_haiba.BackColor = System.Drawing.Color.Black;
			label_haiba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_haiba.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_haiba.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label_haiba.Location = new System.Drawing.Point(275, 311);
			label_haiba.Name = "label_haiba";
			label_haiba.Size = new System.Drawing.Size(311, 10);
			label_haiba.TabIndex = 1;
			label_haiba.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label1.BackColor = System.Drawing.Color.Brown;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.Location = new System.Drawing.Point(9, 240);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(807, 10);
			label1.TabIndex = 1;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("楷体", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			label6.Location = new System.Drawing.Point(378, 20);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(102, 21);
			label6.TabIndex = 1;
			label6.Text = "调试窗口";
			tabPage3.Controls.Add(numericUpDown_debug_rate);
			tabPage3.Controls.Add(label7);
			tabPage3.Location = new System.Drawing.Point(4, 24);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new System.Windows.Forms.Padding(3);
			tabPage3.Size = new System.Drawing.Size(857, 551);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "调试参数";
			tabPage3.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(17, 22);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(63, 14);
			label7.TabIndex = 0;
			label7.Text = "仿真系数";
			numericUpDown_debug_rate.DecimalPlaces = 2;
			numericUpDown_debug_rate.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_debug_rate.Location = new System.Drawing.Point(86, 20);
			numericUpDown_debug_rate.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_debug_rate.Name = "numericUpDown_debug_rate";
			numericUpDown_debug_rate.Size = new System.Drawing.Size(64, 23);
			numericUpDown_debug_rate.TabIndex = 1;
			numericUpDown_debug_rate.ValueChanged += new System.EventHandler(numericUpDown_debug_rate_ValueChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.ControlDarkDark;
			base.ClientSize = new System.Drawing.Size(889, 642);
			base.Controls.Add(label6);
			base.Controls.Add(tabControl1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_DebugUsr";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_debug_rate).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
