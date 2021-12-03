using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_PlateEmpty : Form
	{
		private IContainer components;

		private Label label1;

		private Button button_Continue;

		private Button button_exit;

		private int mFn;

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
			button_Continue = new System.Windows.Forms.Button();
			button_exit = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.Font = new System.Drawing.Font("楷体", 17.5f);
			label1.Location = new System.Drawing.Point(-8, 36);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(734, 43);
			label1.TabIndex = 0;
			label1.Text = "料盘元件用完，请手工上料";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_Continue.Font = new System.Drawing.Font("楷体", 14.5f);
			button_Continue.Location = new System.Drawing.Point(90, 117);
			button_Continue.Name = "button_Continue";
			button_Continue.Size = new System.Drawing.Size(238, 91);
			button_Continue.TabIndex = 1;
			button_Continue.Text = "已上完料，继续贴装";
			button_Continue.UseVisualStyleBackColor = true;
			button_Continue.Click += new System.EventHandler(button_Continue_Click);
			button_exit.Font = new System.Drawing.Font("楷体", 14.5f);
			button_exit.Location = new System.Drawing.Point(392, 117);
			button_exit.Name = "button_exit";
			button_exit.Size = new System.Drawing.Size(234, 91);
			button_exit.TabIndex = 1;
			button_exit.Text = "退出贴装";
			button_exit.UseVisualStyleBackColor = true;
			button_exit.Click += new System.EventHandler(button_exit_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(738, 267);
			base.Controls.Add(button_exit);
			base.Controls.Add(button_Continue);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_PlateEmpty";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
		}

		public Form_PlateEmpty(int fn, int stack_no)
		{
			InitializeComponent();
			mFn = fn;
			string text = "用户操作：" + (stack_no + 1) + "号料盘元件用完，请手工上料！";
			string text2 = "USR OPERATION: PLATE" + (stack_no + 1) + " is empty now, please manual add chips into PLATE!";
			StackElement[] array = MainForm0.USR2[mFn].mStackLib.stacktab[1];
			label1.Text = ((MainForm0.USR_INIT.mLanguage == 2) ? text2 : text) + Environment.NewLine + array[stack_no].mChipFootprint + " " + array[stack_no].mChipValue;
		}

		private void button_Continue_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_exit_Click(object sender, EventArgs e)
		{
			MainForm0.uc_job[mFn].vsplus_stopsmt();
			base.DialogResult = DialogResult.Cancel;
		}
	}
}
