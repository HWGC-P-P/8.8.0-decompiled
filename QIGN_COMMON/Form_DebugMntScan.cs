using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON
{
	public class Form_DebugMntScan : Form
	{
		private IContainer components;

		private Panel panel1;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		public Form_DebugMntScan(int col, int row, BindingList<bool> result, string msg)
		{
			InitializeComponent();
			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < row; j++)
				{
					Label label = new Label();
					panel1.Controls.Add(label);
					label.Location = new Point(40 + i * 40, 40 + j * 70);
					label.Size = new Size(30, 60);
					label.AutoSize = false;
					label.Text = (result[j * col + i] ? "Y" : "X");
					label.BackColor = (result[j * col + i] ? Color.LightGreen : Color.Red);
					label.TextAlign = ContentAlignment.MiddleCenter;
					label.Font = new Font("微软雅黑", 24f, FontStyle.Bold);
				}
			}
			label2.Text = msg;
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
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			SuspendLayout();
			panel1.Location = new System.Drawing.Point(18, 59);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(479, 484);
			panel1.TabIndex = 0;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(226, 18);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(183, 26);
			label1.TabIndex = 1;
			label1.Text = "贴装点精准扫描结果";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(510, 59);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(95, 20);
			label2.TabIndex = 2;
			label2.Text = "250, 230, 210";
			label3.BackColor = System.Drawing.Color.FromArgb(250, 230, 210);
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.Location = new System.Drawing.Point(611, 41);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(79, 77);
			label3.TabIndex = 3;
			label4.BackColor = System.Drawing.Color.FromArgb(245, 200, 210);
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Location = new System.Drawing.Point(611, 141);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(79, 77);
			label4.TabIndex = 3;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label5.Location = new System.Drawing.Point(510, 171);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(95, 20);
			label5.TabIndex = 2;
			label5.Text = "245, 200, 210";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(930, 557);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label5);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(panel1);
			base.Name = "Form_DebugMntScan";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
