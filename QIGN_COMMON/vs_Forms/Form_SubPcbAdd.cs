using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_SubPcbAdd : Form
	{
		private BindingList<USR3_DATA> mUSR3List;

		private IContainer components;

		private Label label1;

		private Label label2;

		private TextBox textBox1;

		private Label label3;

		private TextBox textBox2;

		private Button button1;

		private Button button2;

		public Form_SubPcbAdd(BindingList<USR3_DATA> usr3list)
		{
			InitializeComponent();
			mUSR3List = usr3list;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length > 5 || textBox1.Text.Length <= 1)
			{
				MainForm0.CmMessageBox("子工程编号长度必须是1~5个字符, 请重新填写！", MessageBoxButtons.OK);
				return;
			}
			if (textBox2.Text.Length <= 0)
			{
				MainForm0.CmMessageBox("子工程描述不可为空, 请重新填写！", MessageBoxButtons.OK);
				return;
			}
			for (int i = 0; i < mUSR3List.Count; i++)
			{
				if (textBox1.Text == mUSR3List[i].mPcbID)
				{
					MainForm0.CmMessageBox("子工程编号不可重复, 请重新填写！", MessageBoxButtons.OK);
					return;
				}
			}
			base.DialogResult = DialogResult.OK;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		public string get_pcbid()
		{
			return textBox1.Text;
		}

		public string get_pcbdecription()
		{
			return textBox2.Text;
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
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 18f);
			label1.Location = new System.Drawing.Point(262, 26);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(214, 24);
			label1.TabIndex = 0;
			label1.Text = "新建添加PCB子工程";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 13f);
			label2.Location = new System.Drawing.Point(130, 92);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(98, 18);
			label2.TabIndex = 1;
			label2.Text = "子工程编号";
			textBox1.Location = new System.Drawing.Point(231, 88);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(100, 26);
			textBox1.TabIndex = 2;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("楷体", 13f);
			label3.Location = new System.Drawing.Point(357, 91);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 18);
			label3.TabIndex = 1;
			label3.Text = "描述";
			textBox2.Location = new System.Drawing.Point(401, 88);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(193, 26);
			textBox2.TabIndex = 2;
			button1.Location = new System.Drawing.Point(244, 182);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(101, 31);
			button1.TabIndex = 3;
			button1.Text = "确定";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(375, 182);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(101, 31);
			button2.TabIndex = 3;
			button2.Text = "取消";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.PeachPuff;
			base.ClientSize = new System.Drawing.Size(770, 239);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.Name = "Form_SubPcbAdd";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
