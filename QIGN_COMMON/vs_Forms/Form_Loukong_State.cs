using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_Loukong_State : Form
	{
		private IContainer components;

		private Label label2;

		private Label label7;

		private Label label8;

		private Label label1;

		private Label label_S1;

		private Label label4;

		private Label label5;

		private Label label_S2;

		private Label label9;

		private Label label10;

		private Label label_S3;

		private Label label12;

		private Label label13;

		private Label label14;

		private Button button_ok;

		private Panel panel1;

		private Button button_cancel;

		private Panel panel2;

		private RadioButton radioButton2;

		private RadioButton radioButton_S2;

		private Label label17;

		private Label label16;

		private Label label15;

		private Panel panel3;

		private RadioButton radioButton3;

		private RadioButton radioButton_S1;

		private Panel panel4;

		private RadioButton radioButton5;

		private RadioButton radioButton_S3;

		private Label label6;

		private Label label3;

		private bool[] mS_State;

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
			label2 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label_S1 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label_S2 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label_S3 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			button_ok = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			label17 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton_S1 = new System.Windows.Forms.RadioButton();
			panel4 = new System.Windows.Forms.Panel();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton_S3 = new System.Windows.Forms.RadioButton();
			panel2 = new System.Windows.Forms.Panel();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton_S2 = new System.Windows.Forms.RadioButton();
			label6 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			button_cancel = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Location = new System.Drawing.Point(13, 106);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(164, 6);
			label2.TabIndex = 0;
			label7.BackColor = System.Drawing.SystemColors.GrayText;
			label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label7.Location = new System.Drawing.Point(17, 33);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(47, 73);
			label7.TabIndex = 0;
			label8.BackColor = System.Drawing.Color.White;
			label8.Location = new System.Drawing.Point(132, 51);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(25, 40);
			label8.TabIndex = 0;
			label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.Location = new System.Drawing.Point(13, 27);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(164, 6);
			label1.TabIndex = 0;
			label_S1.BackColor = System.Drawing.Color.ForestGreen;
			label_S1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S1.Location = new System.Drawing.Point(121, 33);
			label_S1.Name = "label_S1";
			label_S1.Size = new System.Drawing.Size(47, 73);
			label_S1.TabIndex = 0;
			label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Location = new System.Drawing.Point(192, 106);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(195, 6);
			label4.TabIndex = 0;
			label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Location = new System.Drawing.Point(192, 27);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(195, 6);
			label5.TabIndex = 0;
			label_S2.BackColor = System.Drawing.Color.ForestGreen;
			label_S2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S2.Location = new System.Drawing.Point(296, 33);
			label_S2.Name = "label_S2";
			label_S2.Size = new System.Drawing.Size(47, 73);
			label_S2.TabIndex = 0;
			label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label9.Location = new System.Drawing.Point(398, 106);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(134, 6);
			label9.TabIndex = 0;
			label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label10.Location = new System.Drawing.Point(398, 27);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(134, 6);
			label10.TabIndex = 0;
			label_S3.BackColor = System.Drawing.Color.ForestGreen;
			label_S3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_S3.Location = new System.Drawing.Point(472, 33);
			label_S3.Name = "label_S3";
			label_S3.Size = new System.Drawing.Size(47, 73);
			label_S3.TabIndex = 0;
			label12.BackColor = System.Drawing.Color.White;
			label12.Location = new System.Drawing.Point(307, 51);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(25, 40);
			label12.TabIndex = 0;
			label13.BackColor = System.Drawing.Color.White;
			label13.Location = new System.Drawing.Point(484, 51);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(25, 40);
			label13.TabIndex = 0;
			label14.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label14.Location = new System.Drawing.Point(28, 21);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(568, 35);
			label14.TabIndex = 2;
			label14.Text = "当前轨道上镂空板真实状态确认";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_ok.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_ok.Location = new System.Drawing.Point(180, 245);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(81, 32);
			button_ok.TabIndex = 3;
			button_ok.Text = "确认";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			panel1.Controls.Add(label17);
			panel1.Controls.Add(label16);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(panel4);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(label13);
			panel1.Controls.Add(label12);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(label_S3);
			panel1.Controls.Add(label_S2);
			panel1.Controls.Add(label_S1);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label2);
			panel1.Location = new System.Drawing.Point(29, 64);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(568, 173);
			panel1.TabIndex = 4;
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label17.Location = new System.Drawing.Point(432, 9);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(68, 17);
			label17.TabIndex = 3;
			label17.Text = "第三段轨道";
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label16.Location = new System.Drawing.Point(252, 9);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(68, 17);
			label16.TabIndex = 3;
			label16.Text = "第二段轨道";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label15.Location = new System.Drawing.Point(63, 9);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(68, 17);
			label15.TabIndex = 3;
			label15.Text = "第一段轨道";
			panel3.Controls.Add(radioButton3);
			panel3.Controls.Add(radioButton_S1);
			panel3.Location = new System.Drawing.Point(106, 120);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(71, 49);
			panel3.TabIndex = 2;
			radioButton3.AutoSize = true;
			radioButton3.Font = new System.Drawing.Font("微软雅黑", 9.5f, System.Drawing.FontStyle.Bold);
			radioButton3.Location = new System.Drawing.Point(7, 25);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(53, 23);
			radioButton3.TabIndex = 0;
			radioButton3.Text = "无板";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton_S1.AutoSize = true;
			radioButton_S1.Checked = true;
			radioButton_S1.Font = new System.Drawing.Font("微软雅黑", 9.5f, System.Drawing.FontStyle.Bold);
			radioButton_S1.Location = new System.Drawing.Point(7, 3);
			radioButton_S1.Name = "radioButton_S1";
			radioButton_S1.Size = new System.Drawing.Size(53, 23);
			radioButton_S1.TabIndex = 0;
			radioButton_S1.TabStop = true;
			radioButton_S1.Text = "有板";
			radioButton_S1.UseVisualStyleBackColor = true;
			radioButton_S1.CheckedChanged += new System.EventHandler(radioButton_S1_CheckedChanged);
			panel4.Controls.Add(radioButton5);
			panel4.Controls.Add(radioButton_S3);
			panel4.Location = new System.Drawing.Point(461, 121);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(71, 49);
			panel4.TabIndex = 2;
			radioButton5.AutoSize = true;
			radioButton5.Font = new System.Drawing.Font("微软雅黑", 9.5f, System.Drawing.FontStyle.Bold);
			radioButton5.Location = new System.Drawing.Point(7, 25);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(53, 23);
			radioButton5.TabIndex = 0;
			radioButton5.Text = "无板";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton_S3.AutoSize = true;
			radioButton_S3.Checked = true;
			radioButton_S3.Font = new System.Drawing.Font("微软雅黑", 9.5f, System.Drawing.FontStyle.Bold);
			radioButton_S3.Location = new System.Drawing.Point(7, 3);
			radioButton_S3.Name = "radioButton_S3";
			radioButton_S3.Size = new System.Drawing.Size(53, 23);
			radioButton_S3.TabIndex = 0;
			radioButton_S3.TabStop = true;
			radioButton_S3.Text = "有板";
			radioButton_S3.UseVisualStyleBackColor = true;
			radioButton_S3.CheckedChanged += new System.EventHandler(radioButton_S3_CheckedChanged);
			panel2.Controls.Add(radioButton2);
			panel2.Controls.Add(radioButton_S2);
			panel2.Location = new System.Drawing.Point(286, 121);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(71, 49);
			panel2.TabIndex = 2;
			radioButton2.AutoSize = true;
			radioButton2.Font = new System.Drawing.Font("微软雅黑", 9.5f, System.Drawing.FontStyle.Bold);
			radioButton2.Location = new System.Drawing.Point(7, 25);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(53, 23);
			radioButton2.TabIndex = 0;
			radioButton2.Text = "无板";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton_S2.AutoSize = true;
			radioButton_S2.Checked = true;
			radioButton_S2.Font = new System.Drawing.Font("微软雅黑", 9.5f, System.Drawing.FontStyle.Bold);
			radioButton_S2.Location = new System.Drawing.Point(7, 3);
			radioButton_S2.Name = "radioButton_S2";
			radioButton_S2.Size = new System.Drawing.Size(53, 23);
			radioButton_S2.TabIndex = 0;
			radioButton_S2.TabStop = true;
			radioButton_S2.Text = "有板";
			radioButton_S2.UseVisualStyleBackColor = true;
			radioButton_S2.CheckedChanged += new System.EventHandler(radioButton_S2_CheckedChanged);
			label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label6.Location = new System.Drawing.Point(106, 106);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(426, 12);
			label6.TabIndex = 0;
			label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.Location = new System.Drawing.Point(106, 21);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(426, 12);
			label3.TabIndex = 0;
			button_cancel.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_cancel.Location = new System.Drawing.Point(350, 245);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(81, 32);
			button_cancel.TabIndex = 3;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.AppWorkspace;
			base.ClientSize = new System.Drawing.Size(633, 289);
			base.Controls.Add(panel1);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(label14);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "Form_Loukong_State";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_Loukong_State_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		public Form_Loukong_State(bool[] s_state, bool is_saduanshi)
		{
			InitializeComponent();
			mS_State = s_state;
			radioButton_S1.Checked = mS_State[0];
			radioButton_S2.Checked = mS_State[1];
			radioButton_S3.Checked = mS_State[2];
			radioButton3.Checked = !mS_State[0];
			radioButton2.Checked = !mS_State[1];
			radioButton5.Checked = !mS_State[2];
			if (is_saduanshi)
			{
				label3.Visible = false;
				label6.Visible = false;
			}
			else
			{
				label1.Visible = (label2.Visible = (label7.Visible = false));
				label15.Visible = (label16.Visible = (label17.Visible = false));
			}
		}

		private void radioButton_S1_CheckedChanged(object sender, EventArgs e)
		{
			if (mS_State != null)
			{
				mS_State[0] = radioButton_S1.Checked;
				label_S1.BackColor = (mS_State[0] ? Color.ForestGreen : Color.White);
			}
		}

		private void radioButton_S2_CheckedChanged(object sender, EventArgs e)
		{
			if (mS_State != null)
			{
				mS_State[1] = radioButton_S2.Checked;
				label_S2.BackColor = (mS_State[1] ? Color.ForestGreen : Color.White);
			}
		}

		private void radioButton_S3_CheckedChanged(object sender, EventArgs e)
		{
			if (mS_State != null)
			{
				mS_State[2] = radioButton_S3.Checked;
				label_S3.BackColor = (mS_State[2] ? Color.ForestGreen : Color.White);
			}
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

		private void Form_Loukong_State_Load(object sender, EventArgs e)
		{
		}
	}
}
