using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_GenPcbListConfirm : Form
	{
		private IContainer components;

		private Button button_ok;

		private Button button_cancel;

		private Panel panel1;

		private Panel panel_d0;

		private Panel panel5;

		private Panel panel2;

		private Panel panel3;

		private Label label_msg;

		private Label label3;

		private Panel panel_d90;

		private Panel panel9;

		private Panel panel_d180;

		private Panel panel7;

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
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			panel_d0 = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			label_msg = new System.Windows.Forms.Label();
			panel_d180 = new System.Windows.Forms.Panel();
			panel7 = new System.Windows.Forms.Panel();
			panel_d90 = new System.Windows.Forms.Panel();
			panel9 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel_d0.SuspendLayout();
			panel_d180.SuspendLayout();
			panel_d90.SuspendLayout();
			SuspendLayout();
			button_ok.Font = new System.Drawing.Font("楷体", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_ok.Location = new System.Drawing.Point(229, 271);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(268, 56);
			button_ok.TabIndex = 0;
			button_ok.Text = "开始生成";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Font = new System.Drawing.Font("楷体", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_cancel.Location = new System.Drawing.Point(547, 271);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(75, 56);
			button_cancel.TabIndex = 0;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Visible = false;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			panel1.Controls.Add(label_msg);
			panel1.Controls.Add(panel_d90);
			panel1.Controls.Add(panel_d180);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(panel_d0);
			panel1.Controls.Add(panel2);
			panel1.Location = new System.Drawing.Point(12, 12);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(731, 244);
			panel1.TabIndex = 1;
			panel2.BackColor = System.Drawing.Color.DarkSlateGray;
			panel2.Controls.Add(panel3);
			panel2.Location = new System.Drawing.Point(54, 62);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(188, 96);
			panel2.TabIndex = 0;
			panel3.BackColor = System.Drawing.Color.MintCream;
			panel3.Location = new System.Drawing.Point(13, 13);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(21, 24);
			panel3.TabIndex = 0;
			panel_d0.BackColor = System.Drawing.Color.DarkSlateGray;
			panel_d0.Controls.Add(panel5);
			panel_d0.Location = new System.Drawing.Point(441, 62);
			panel_d0.Name = "panel_d0";
			panel_d0.Size = new System.Drawing.Size(201, 96);
			panel_d0.TabIndex = 0;
			panel5.BackColor = System.Drawing.Color.MintCream;
			panel5.Location = new System.Drawing.Point(13, 13);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(21, 24);
			panel5.TabIndex = 0;
			label3.Font = new System.Drawing.Font("微软雅黑", 48f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(307, 62);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(80, 70);
			label3.TabIndex = 22;
			label3.Text = "➨";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_msg.Font = new System.Drawing.Font("楷体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label_msg.Location = new System.Drawing.Point(50, 197);
			label_msg.Name = "label_msg";
			label_msg.Size = new System.Drawing.Size(592, 31);
			label_msg.TabIndex = 23;
			label_msg.Text = "PCB板放置方向与坐标文件一致";
			label_msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_d180.BackColor = System.Drawing.Color.DarkSlateGray;
			panel_d180.Controls.Add(panel7);
			panel_d180.Location = new System.Drawing.Point(457, 59);
			panel_d180.Name = "panel_d180";
			panel_d180.Size = new System.Drawing.Size(201, 99);
			panel_d180.TabIndex = 0;
			panel7.BackColor = System.Drawing.Color.MintCream;
			panel7.Location = new System.Drawing.Point(172, 67);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(21, 24);
			panel7.TabIndex = 0;
			panel_d90.BackColor = System.Drawing.Color.DarkSlateGray;
			panel_d90.Controls.Add(panel9);
			panel_d90.Location = new System.Drawing.Point(470, 20);
			panel_d90.Name = "panel_d90";
			panel_d90.Size = new System.Drawing.Size(104, 174);
			panel_d90.TabIndex = 0;
			panel9.BackColor = System.Drawing.Color.MintCream;
			panel9.Location = new System.Drawing.Point(76, 9);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(21, 24);
			panel9.TabIndex = 0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LightCyan;
			base.ClientSize = new System.Drawing.Size(754, 361);
			base.Controls.Add(panel1);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_GenPcbListConfirm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel_d0.ResumeLayout(false);
			panel_d180.ResumeLayout(false);
			panel_d90.ResumeLayout(false);
			ResumeLayout(false);
		}

		public Form_GenPcbListConfirm(int lan, double theta)
		{
			InitializeComponent();
			label_msg.Font = new Font(DEF.FONT_2020[lan], label_msg.Font.Size + DEF.FSIZE_2020[lan], FontStyle.Regular);
			button_ok.Font = new Font(DEF.FONT_2020[lan], button_ok.Font.Size + DEF.FSIZE_2020[lan], FontStyle.Regular);
			button_cancel.Font = new Font(DEF.FONT_2020[lan], button_cancel.Font.Size + DEF.FSIZE_2020[lan], FontStyle.Regular);
			panel_d0.Visible = false;
			panel_d180.Visible = false;
			panel_d90.Visible = false;
			int num = (int)(theta * 180.0 / 3.1415926);
			num += 1800;
			int num2 = num % 360;
			if (Math.Abs(num2) < 35 || Math.Abs(num2 - 360) < 35)
			{
				panel_d0.Visible = true;
				label_msg.Text = ((lan == 2) ? "PCB Direction is same as imported file! " : "PCB放置方向与导入坐标文件一致！");
			}
			else
			{
				num2 = num % 180;
				if (Math.Abs(num2) < 35 || Math.Abs(num2 - 180) < 35)
				{
					panel_d180.Visible = true;
					label_msg.Text = ((lan == 2) ? "PCB Direction is 180 degrees to imported file! " : "PCB放置方向与坐标文件旋转了180度！");
				}
				else
				{
					num2 = num % 90;
					if (Math.Abs(num2) < 35 || Math.Abs(num2 - 90) < 35)
					{
						panel_d90.Visible = true;
						label_msg.Text = ((lan == 2) ? "PCB Direction is 90 degrees to imported file! " : "PCB放置方向与坐标文件旋转了90度！");
					}
					else
					{
						panel_d90.Visible = true;
						label_msg.Text = ((lan == 2) ? "PCB Direction is not same degrees to imported file! " : "PCB放置方向与坐标文件角度不一致！");
					}
				}
			}
			button_ok.Text = ((lan == 2) ? "Continue" : "开始生成");
			button_cancel.Text = ((lan == 2) ? "Cancel" : "取消");
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}
	}
}
