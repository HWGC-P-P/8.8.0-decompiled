using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_Loukong_State_DSQ : Form
	{
		private IContainer components;

		private Label label17;

		private Panel panel4;

		private RadioButton radioButton5;

		private RadioButton radioButton_S3;

		private Panel panel2;

		private RadioButton radioButton2;

		private RadioButton radioButton_S2;

		private CnButton button_cancel;

		private Label label15;

		private CnButton button_ok;

		private Label label16;

		private Panel panel3;

		private RadioButton radioButton3;

		private RadioButton radioButton_S1;

		private Label label13;

		private Label label12;

		private Label label8;

		private Label label_S3;

		private Label label_S2;

		private Label label14;

		private Label label_S1;

		private Label label1;

		private Label label2;

		private Panel panel1;

		private Label label10;

		private Label label9;

		private Label label4;

		private Label label6;

		private Label label5;

		private Label label3;

		private Panel panel5;

		private RadioButton radioButton1;

		private RadioButton radioButton4;

		private Panel panel6;

		private RadioButton radioButton6;

		private RadioButton radioButton7;

		private Label label11;

		private Label label7;

		private bool[] mS_State;

		private RadioButton[] radioButtons_S;

		private RadioButton[] radioButtons_S_;

		private Label[] label_S;

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
			label17 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton_S3 = new System.Windows.Forms.RadioButton();
			panel2 = new System.Windows.Forms.Panel();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton_S2 = new System.Windows.Forms.RadioButton();
			button_cancel = new QIGN_COMMON.vs_acontrol.CnButton();
			label15 = new System.Windows.Forms.Label();
			button_ok = new QIGN_COMMON.vs_acontrol.CnButton();
			label16 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton_S1 = new System.Windows.Forms.RadioButton();
			label13 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label_S3 = new System.Windows.Forms.Label();
			label_S2 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label_S1 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton4 = new System.Windows.Forms.RadioButton();
			panel6 = new System.Windows.Forms.Panel();
			radioButton6 = new System.Windows.Forms.RadioButton();
			radioButton7 = new System.Windows.Forms.RadioButton();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			panel4.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel1.SuspendLayout();
			panel5.SuspendLayout();
			panel6.SuspendLayout();
			SuspendLayout();
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("黑体", 12f);
			label17.Location = new System.Drawing.Point(572, 14);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(88, 16);
			label17.TabIndex = 17;
			label17.Text = "第三段轨道";
			panel4.Controls.Add(radioButton5);
			panel4.Controls.Add(radioButton_S3);
			panel4.Font = new System.Drawing.Font("黑体", 11.5f);
			panel4.Location = new System.Drawing.Point(589, 120);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(71, 49);
			panel4.TabIndex = 15;
			radioButton5.AutoSize = true;
			radioButton5.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton5.Location = new System.Drawing.Point(7, 25);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(58, 20);
			radioButton5.TabIndex = 0;
			radioButton5.Text = "无板";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton_S3.AutoSize = true;
			radioButton_S3.Checked = true;
			radioButton_S3.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton_S3.Location = new System.Drawing.Point(7, 3);
			radioButton_S3.Name = "radioButton_S3";
			radioButton_S3.Size = new System.Drawing.Size(58, 20);
			radioButton_S3.TabIndex = 0;
			radioButton_S3.TabStop = true;
			radioButton_S3.Text = "有板";
			radioButton_S3.UseVisualStyleBackColor = true;
			panel2.Controls.Add(radioButton2);
			panel2.Controls.Add(radioButton_S2);
			panel2.Font = new System.Drawing.Font("黑体", 11.5f);
			panel2.Location = new System.Drawing.Point(385, 120);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(71, 49);
			panel2.TabIndex = 13;
			radioButton2.AutoSize = true;
			radioButton2.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton2.Location = new System.Drawing.Point(7, 25);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(58, 20);
			radioButton2.TabIndex = 0;
			radioButton2.Text = "无板";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton_S2.AutoSize = true;
			radioButton_S2.Checked = true;
			radioButton_S2.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton_S2.Location = new System.Drawing.Point(7, 3);
			radioButton_S2.Name = "radioButton_S2";
			radioButton_S2.Size = new System.Drawing.Size(58, 20);
			radioButton_S2.TabIndex = 0;
			radioButton_S2.TabStop = true;
			radioButton_S2.Text = "有板";
			radioButton_S2.UseVisualStyleBackColor = true;
			button_cancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
			button_cancel.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_cancel.CnPressDownColor = System.Drawing.Color.White;
			button_cancel.Font = new System.Drawing.Font("黑体", 11.5f);
			button_cancel.Location = new System.Drawing.Point(465, 276);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(81, 32);
			button_cancel.TabIndex = 20;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = false;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("黑体", 12f);
			label15.Location = new System.Drawing.Point(79, 14);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(88, 16);
			label15.TabIndex = 21;
			label15.Text = "第一段轨道";
			button_ok.BackColor = System.Drawing.SystemColors.ControlLightLight;
			button_ok.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_ok.CnPressDownColor = System.Drawing.Color.White;
			button_ok.Font = new System.Drawing.Font("黑体", 11.5f);
			button_ok.Location = new System.Drawing.Point(295, 276);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(81, 32);
			button_ok.TabIndex = 18;
			button_ok.Text = "确认";
			button_ok.UseVisualStyleBackColor = false;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("黑体", 12f);
			label16.Location = new System.Drawing.Point(323, 14);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(88, 16);
			label16.TabIndex = 19;
			label16.Text = "第二段轨道";
			panel3.Controls.Add(radioButton3);
			panel3.Controls.Add(radioButton_S1);
			panel3.Font = new System.Drawing.Font("黑体", 11.5f);
			panel3.Location = new System.Drawing.Point(184, 119);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(71, 49);
			panel3.TabIndex = 16;
			radioButton3.AutoSize = true;
			radioButton3.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton3.Location = new System.Drawing.Point(7, 25);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(58, 20);
			radioButton3.TabIndex = 0;
			radioButton3.Text = "无板";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton_S1.AutoSize = true;
			radioButton_S1.Checked = true;
			radioButton_S1.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton_S1.Location = new System.Drawing.Point(7, 3);
			radioButton_S1.Name = "radioButton_S1";
			radioButton_S1.Size = new System.Drawing.Size(58, 20);
			radioButton_S1.TabIndex = 0;
			radioButton_S1.TabStop = true;
			radioButton_S1.Text = "有板";
			radioButton_S1.UseVisualStyleBackColor = true;
			label13.BackColor = System.Drawing.Color.White;
			label13.Location = new System.Drawing.Point(609, 56);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(25, 40);
			label13.TabIndex = 12;
			label12.BackColor = System.Drawing.Color.White;
			label12.Location = new System.Drawing.Point(399, 56);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(25, 40);
			label12.TabIndex = 7;
			label8.BackColor = System.Drawing.Color.White;
			label8.Location = new System.Drawing.Point(209, 56);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(25, 40);
			label8.TabIndex = 4;
			label_S3.BackColor = System.Drawing.Color.ForestGreen;
			label_S3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S3.Location = new System.Drawing.Point(597, 38);
			label_S3.Name = "label_S3";
			label_S3.Size = new System.Drawing.Size(47, 73);
			label_S3.TabIndex = 5;
			label_S2.BackColor = System.Drawing.Color.ForestGreen;
			label_S2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S2.Location = new System.Drawing.Point(388, 38);
			label_S2.Name = "label_S2";
			label_S2.Size = new System.Drawing.Size(47, 73);
			label_S2.TabIndex = 10;
			label14.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label14.Location = new System.Drawing.Point(143, 9);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(568, 35);
			label14.TabIndex = 14;
			label14.Text = "当前轨道上镂空板真实状态确认";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_S1.BackColor = System.Drawing.Color.ForestGreen;
			label_S1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S1.Location = new System.Drawing.Point(198, 38);
			label_S1.Name = "label_S1";
			label_S1.Size = new System.Drawing.Size(47, 73);
			label_S1.TabIndex = 11;
			label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.Location = new System.Drawing.Point(29, 32);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(264, 6);
			label1.TabIndex = 9;
			label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Location = new System.Drawing.Point(29, 111);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(264, 6);
			label2.TabIndex = 6;
			panel1.Controls.Add(label17);
			panel1.Controls.Add(panel5);
			panel1.Controls.Add(panel4);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(label16);
			panel1.Controls.Add(panel6);
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(label13);
			panel1.Controls.Add(label12);
			panel1.Controls.Add(label11);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label_S3);
			panel1.Controls.Add(label_S2);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label_S1);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Location = new System.Drawing.Point(35, 65);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(773, 205);
			panel1.TabIndex = 22;
			panel5.Controls.Add(radioButton1);
			panel5.Controls.Add(radioButton4);
			panel5.Font = new System.Drawing.Font("黑体", 11.5f);
			panel5.Location = new System.Drawing.Point(679, 120);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(71, 49);
			panel5.TabIndex = 15;
			radioButton1.AutoSize = true;
			radioButton1.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton1.Location = new System.Drawing.Point(7, 25);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(58, 20);
			radioButton1.TabIndex = 0;
			radioButton1.Text = "无板";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton4.AutoSize = true;
			radioButton4.Checked = true;
			radioButton4.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton4.Location = new System.Drawing.Point(7, 3);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(58, 20);
			radioButton4.TabIndex = 0;
			radioButton4.TabStop = true;
			radioButton4.Text = "有板";
			radioButton4.UseVisualStyleBackColor = true;
			panel6.Controls.Add(radioButton6);
			panel6.Controls.Add(radioButton7);
			panel6.Font = new System.Drawing.Font("黑体", 11.5f);
			panel6.Location = new System.Drawing.Point(33, 119);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(71, 49);
			panel6.TabIndex = 16;
			radioButton6.AutoSize = true;
			radioButton6.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton6.Location = new System.Drawing.Point(7, 25);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new System.Drawing.Size(58, 20);
			radioButton6.TabIndex = 0;
			radioButton6.Text = "无板";
			radioButton6.UseVisualStyleBackColor = true;
			radioButton7.AutoSize = true;
			radioButton7.Checked = true;
			radioButton7.Font = new System.Drawing.Font("黑体", 11.5f);
			radioButton7.Location = new System.Drawing.Point(7, 3);
			radioButton7.Name = "radioButton7";
			radioButton7.Size = new System.Drawing.Size(58, 20);
			radioButton7.TabIndex = 0;
			radioButton7.TabStop = true;
			radioButton7.Text = "有板";
			radioButton7.UseVisualStyleBackColor = true;
			label10.BackColor = System.Drawing.Color.White;
			label10.Location = new System.Drawing.Point(691, 56);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(25, 40);
			label10.TabIndex = 12;
			label11.BackColor = System.Drawing.Color.White;
			label11.Location = new System.Drawing.Point(40, 56);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(25, 40);
			label11.TabIndex = 4;
			label9.BackColor = System.Drawing.Color.ForestGreen;
			label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label9.Location = new System.Drawing.Point(679, 38);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(47, 73);
			label9.TabIndex = 5;
			label7.BackColor = System.Drawing.Color.ForestGreen;
			label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label7.Location = new System.Drawing.Point(29, 38);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(47, 73);
			label7.TabIndex = 11;
			label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Location = new System.Drawing.Point(462, 32);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(264, 6);
			label4.TabIndex = 9;
			label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label6.Location = new System.Drawing.Point(302, 32);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(154, 6);
			label6.TabIndex = 9;
			label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Location = new System.Drawing.Point(302, 111);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(154, 6);
			label5.TabIndex = 6;
			label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.Location = new System.Drawing.Point(462, 111);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(264, 6);
			label3.TabIndex = 6;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.SystemColors.AppWorkspace;
			base.ClientSize = new System.Drawing.Size(839, 322);
			base.Controls.Add(panel1);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(label14);
			Font = new System.Drawing.Font("黑体", 12f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_Loukong_State_DSQ";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_Loukong_State_DSQ_Load);
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			ResumeLayout(false);
		}

		public Form_Loukong_State_DSQ(bool[] s_state)
		{
			InitializeComponent();
			mS_State = s_state;
			radioButtons_S = new RadioButton[5] { radioButton7, radioButton_S1, radioButton_S2, radioButton_S3, radioButton4 };
			radioButtons_S_ = new RadioButton[5] { radioButton6, radioButton3, radioButton2, radioButton5, radioButton1 };
			label_S = new Label[5] { label7, label_S1, label_S2, label_S3, label9 };
			if (mS_State != null && mS_State.Count() >= 5)
			{
				for (int i = 0; i < 5; i++)
				{
					radioButtons_S[i].Tag = i;
					radioButtons_S_[i].Tag = i;
					radioButtons_S[i].Checked = mS_State[i];
					radioButtons_S_[i].Checked = !mS_State[i];
					radioButtons_S[i].CheckedChanged += radioButton_S1_CheckedChanged;
					label_S[i].BackColor = (mS_State[i] ? Color.ForestGreen : Color.White);
				}
			}
		}

		private void radioButton_S1_CheckedChanged(object sender, EventArgs e)
		{
			int num = (int)((RadioButton)sender).Tag;
			if (mS_State != null)
			{
				mS_State[num] = radioButtons_S[num].Checked;
				label_S[num].BackColor = (mS_State[num] ? Color.ForestGreen : Color.White);
			}
		}

		private void Form_Loukong_State_DSQ_Load(object sender, EventArgs e)
		{
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		public bool[] get_PwState()
		{
			return mS_State;
		}
	}
}
