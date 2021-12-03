using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_MarkCamPara : UserControl
	{
		public USR_DATA USR;

		private IContainer components;

		private Panel panel1;

		private Button button_light;

		private Label label3;

		private Label label5;

		private Panel panel4;

		private NumericUpDown numericUpDown_markStillDelay;

		private Button button_led;

		private Label label2;

		private Panel panel5;

		private Label label4;

		private Panel panel2;

		private Panel panel3;

		private Label label1;

		private Panel panel6;

		private Button button_close;

		public UserControl_MarkCamPara(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void UserControl_MarkCamPara_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_close);
			MainForm0.CreateAddButtonPic(button_light);
			MainForm0.CreateAddButtonPic(button_led);
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
			panel1 = new System.Windows.Forms.Panel();
			button_light = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			numericUpDown_markStillDelay = new System.Windows.Forms.NumericUpDown();
			button_led = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			panel5 = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			panel6 = new System.Windows.Forms.Panel();
			button_close = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)numericUpDown_markStillDelay).BeginInit();
			panel5.SuspendLayout();
			panel2.SuspendLayout();
			panel6.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.LightBlue;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Location = new System.Drawing.Point(11, 37);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(171, 309);
			panel1.TabIndex = 7;
			button_light.Location = new System.Drawing.Point(66, 24);
			button_light.Name = "button_light";
			button_light.Size = new System.Drawing.Size(84, 28);
			button_light.TabIndex = 4;
			button_light.Text = "照明已开";
			button_light.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(7, 128);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(91, 14);
			label3.TabIndex = 1;
			label3.Text = "MARK相机设置";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label5.Location = new System.Drawing.Point(3, 9);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(161, 14);
			label5.TabIndex = 1;
			label5.Text = "MARK相机拍照延时（ms）";
			panel4.Location = new System.Drawing.Point(10, 145);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(314, 109);
			panel4.TabIndex = 0;
			numericUpDown_markStillDelay.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_markStillDelay.Location = new System.Drawing.Point(179, 7);
			numericUpDown_markStillDelay.Maximum = new decimal(new int[4] { 2000, 0, 0, 0 });
			numericUpDown_markStillDelay.Name = "numericUpDown_markStillDelay";
			numericUpDown_markStillDelay.Size = new System.Drawing.Size(59, 23);
			numericUpDown_markStillDelay.TabIndex = 5;
			button_led.Location = new System.Drawing.Point(174, 24);
			button_led.Name = "button_led";
			button_led.Size = new System.Drawing.Size(84, 28);
			button_led.TabIndex = 4;
			button_led.Text = "光源已开";
			button_led.UseVisualStyleBackColor = true;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(5, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(91, 14);
			label2.TabIndex = 1;
			label2.Text = "MARK光源设置";
			panel5.BackColor = System.Drawing.Color.LightBlue;
			panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel5.Controls.Add(button_led);
			panel5.Controls.Add(button_light);
			panel5.Controls.Add(label4);
			panel5.Controls.Add(panel2);
			panel5.Location = new System.Drawing.Point(188, 37);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(351, 309);
			panel5.TabIndex = 9;
			label4.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.Location = new System.Drawing.Point(8, -4);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(323, 34);
			label4.TabIndex = 3;
			label4.Text = "label4";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel2.Controls.Add(label3);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(panel3);
			panel2.Location = new System.Drawing.Point(3, 53);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(335, 255);
			panel2.TabIndex = 0;
			panel3.Location = new System.Drawing.Point(8, 24);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(316, 102);
			panel3.TabIndex = 0;
			label1.Font = new System.Drawing.Font("黑体", 14.25f);
			label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			label1.Location = new System.Drawing.Point(15, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(528, 33);
			label1.TabIndex = 8;
			label1.Text = "MARK相机";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel6.BackColor = System.Drawing.Color.LightBlue;
			panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel6.Controls.Add(label5);
			panel6.Controls.Add(numericUpDown_markStillDelay);
			panel6.Location = new System.Drawing.Point(11, 349);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(528, 37);
			panel6.TabIndex = 10;
			button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
			button_close.Location = new System.Drawing.Point(510, 4);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(33, 31);
			button_close.TabIndex = 11;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = true;
			button_close.Click += new System.EventHandler(button_close_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.CadetBlue;
			base.Controls.Add(button_close);
			base.Controls.Add(panel1);
			base.Controls.Add(panel5);
			base.Controls.Add(label1);
			base.Controls.Add(panel6);
			Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_MarkCamPara";
			base.Size = new System.Drawing.Size(550, 392);
			base.Load += new System.EventHandler(UserControl_MarkCamPara_Load);
			((System.ComponentModel.ISupportInitialize)numericUpDown_markStillDelay).EndInit();
			panel5.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			ResumeLayout(false);
		}
	}
}
