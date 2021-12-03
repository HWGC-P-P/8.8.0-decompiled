using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_LoopRegular : UserControl
	{
		public BindingList<USR3_DATA> mUSR3List;

		private IContainer components;

		private Label label1;

		private Button button_close;

		private Panel panel1;

		public UserControl_LoopRegular(BindingList<USR3_DATA> usr3list)
		{
			InitializeComponent();
			mUSR3List = usr3list;
			if (usr3list != null && usr3list.Count > 0)
			{
				for (int i = 0; i < usr3list.Count; i++)
				{
					CheckBox checkBox = new CheckBox();
					panel1.Controls.Add(checkBox);
					checkBox.Location = new Point(0, 25 * i);
					checkBox.Text = usr3list[i].mPcbID + " " + usr3list[i].mPcbDescription;
					checkBox.Checked = usr3list[i].mIsPcbChecked;
					checkBox.CheckedChanged += cb_CheckedChanged;
					checkBox.Tag = i;
				}
			}
		}

		public void cb_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			int num = (int)checkBox.Tag;
			if (mUSR3List != null && num < mUSR3List.Count)
			{
				mUSR3List[num].mIsPcbChecked = checkBox.Checked;
			}
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			Dispose();
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
			button_close = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(15, 13);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(63, 14);
			label1.TabIndex = 0;
			label1.Text = "Loop规则";
			button_close.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_close.Location = new System.Drawing.Point(662, 3);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(28, 28);
			button_close.TabIndex = 1;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = true;
			button_close.Click += new System.EventHandler(button_close_Click);
			panel1.Location = new System.Drawing.Point(18, 40);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(627, 100);
			panel1.TabIndex = 2;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(panel1);
			base.Controls.Add(button_close);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_LoopRegular";
			base.Size = new System.Drawing.Size(692, 160);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
