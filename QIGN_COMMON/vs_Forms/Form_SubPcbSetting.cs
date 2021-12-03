using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_SubPcbSetting : Form
	{
		private BindingList<USR3_DATA> mUSR3List;

		private BindingList<TextBox> textBox_id;

		private BindingList<TextBox> textBox_decrition;

		private BindingList<CheckBox> checkBox_ismount;

		private BindingList<Panel> panel_list;

		private IContainer components;

		private Label label1;

		private Panel panel1;

		private Button button_ok;

		private Button button_cancel;

		private Label label2;

		private Panel panel2;

		private TextBox textBox1;

		private TextBox textBox2;

		private Label label3;

		private CheckBox checkBox1;

		private Panel panel3;

		public Form_SubPcbSetting(BindingList<USR3_DATA> usr3list)
		{
			InitializeComponent();
			mUSR3List = usr3list;
			panel1.Controls.Clear();
			textBox_id = new BindingList<TextBox>();
			textBox_decrition = new BindingList<TextBox>();
			checkBox_ismount = new BindingList<CheckBox>();
			panel_list = new BindingList<Panel>();
			int num = 2;
			for (int i = 0; i < mUSR3List.Count; i++)
			{
				Panel panel = new Panel
				{
					Location = new Point(2, i * 31 + 6)
				};
				panel1.Controls.Add(panel);
				panel.Size = new Size(panel1.Size.Width - 2, 30);
				Label label = new Label
				{
					Text = "子工程" + (i + 1).ToString("D2") + " 编号",
					AutoSize = false,
					Location = new Point(2, 3 + num),
					Size = new Size(120, 25)
				};
				panel.Controls.Add(label);
				TextBox textBox = new TextBox
				{
					Size = new Size(60, 25),
					Location = new Point(label.Location.X + label.Size.Width + 2, num)
				};
				panel.Controls.Add(textBox);
				textBox_id.Add(textBox);
				textBox.Text = mUSR3List[i].mPcbID;
				Label label2 = new Label
				{
					Text = "描述",
					AutoSize = false,
					Size = new Size(50, 25),
					Location = new Point(textBox.Location.X + textBox.Size.Width + 8, 3 + num)
				};
				panel.Controls.Add(label2);
				TextBox textBox2 = new TextBox
				{
					Size = new Size(220, 25),
					Location = new Point(label2.Location.X + label2.Size.Width + 1, num)
				};
				panel.Controls.Add(textBox2);
				textBox_decrition.Add(textBox2);
				textBox2.Text = mUSR3List[i].mPcbDescription;
				CheckBox checkBox = new CheckBox
				{
					Size = new Size(80, 25),
					Location = new Point(textBox2.Location.X + textBox2.Size.Width + 6, num)
				};
				panel.Controls.Add(checkBox);
				checkBox_ismount.Add(checkBox);
				checkBox.Checked = mUSR3List[i].mIsPcbChecked;
				checkBox.Text = "贴装";
				checkBox.CheckedChanged += checkBox_ismount_CheckedChanged;
				checkBox.Tag = i;
				panel.BackColor = (mUSR3List[i].mIsPcbChecked ? Color.PeachPuff : Color.LightGray);
				Color color3 = (textBox_decrition[i].BackColor = (textBox_id[i].BackColor = (mUSR3List[i].mIsPcbChecked ? Color.White : Color.LightGray)));
				panel_list.Add(panel);
			}
		}

		private void checkBox_ismount_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			int index = (int)checkBox.Tag;
			mUSR3List[index].mIsPcbChecked = checkBox.Checked;
			panel_list[index].BackColor = (mUSR3List[index].mIsPcbChecked ? Color.PeachPuff : Color.LightGray);
			Color color3 = (textBox_decrition[index].BackColor = (textBox_id[index].BackColor = (mUSR3List[index].mIsPcbChecked ? Color.White : Color.LightGray)));
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < mUSR3List.Count; i++)
			{
				if (textBox_id[i].Text.Length > 5 || textBox_id[i].Text.Length <= 1)
				{
					MainForm0.CmMessageBox("子工程编号长度必须是1~5个字符, 请重新填写！", MessageBoxButtons.OK);
					return;
				}
			}
			BindingList<string> bindingList = new BindingList<string>();
			for (int j = 0; j < mUSR3List.Count; j++)
			{
				bindingList.Add(textBox_id[j].Text);
			}
			if (!MainForm0.common_is_string_alldifferent(bindingList))
			{
				MainForm0.CmMessageBox("不可以有相同的子工程编号, 请重新填写！", MessageBoxButtons.OK);
				return;
			}
			for (int k = 0; k < mUSR3List.Count; k++)
			{
				mUSR3List[k].mPcbID = textBox_id[k].Text;
				mUSR3List[k].mPcbDescription = textBox_decrition[k].Text;
			}
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Form_SubPcbSetting_Load(object sender, EventArgs e)
		{
			panel1.Size = new Size(panel1.Width, panel1.Height * (1 + (mUSR3List.Count - 1) / 12));
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
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox2 = new System.Windows.Forms.TextBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			panel3 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 16f);
			label1.Location = new System.Drawing.Point(281, 14);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(175, 22);
			label1.TabIndex = 0;
			label1.Text = "PCB板组描述设置";
			panel1.BackColor = System.Drawing.Color.PeachPuff;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Controls.Add(panel2);
			panel1.Location = new System.Drawing.Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(669, 376);
			panel1.TabIndex = 1;
			panel2.Controls.Add(checkBox1);
			panel2.Controls.Add(textBox2);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(label2);
			panel2.Location = new System.Drawing.Point(3, 3);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(540, 35);
			panel2.TabIndex = 1;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(454, 8);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(59, 20);
			checkBox1.TabIndex = 2;
			checkBox1.Text = "贴装";
			checkBox1.UseVisualStyleBackColor = true;
			textBox2.Location = new System.Drawing.Point(225, 6);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(223, 26);
			textBox2.TabIndex = 1;
			textBox1.Location = new System.Drawing.Point(107, 6);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(68, 26);
			textBox1.TabIndex = 1;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(179, 10);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(40, 16);
			label3.TabIndex = 0;
			label3.Text = "描述";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 10);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(104, 16);
			label2.TabIndex = 0;
			label2.Text = "子工程1 编号";
			button_ok.Location = new System.Drawing.Point(210, 435);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(75, 34);
			button_ok.TabIndex = 2;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Location = new System.Drawing.Point(432, 435);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(75, 34);
			button_cancel.TabIndex = 2;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			panel3.AutoScroll = true;
			panel3.Controls.Add(panel1);
			panel3.Location = new System.Drawing.Point(32, 42);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(687, 387);
			panel3.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LightSalmon;
			base.ClientSize = new System.Drawing.Size(736, 475);
			base.Controls.Add(panel3);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_SubPcbSetting";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_SubPcbSetting_Load);
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
