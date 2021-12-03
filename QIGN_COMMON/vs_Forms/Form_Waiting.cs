using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_Waiting : Form
	{
		private IContainer components;

		private Panel panel1;

		private Label label1;

		private System.Windows.Forms.Timer timer1;

		private Panel panel2;

		private BindingList<Label> label_list;

		private bool mReturn;

		private Form_Waiting mThisForm;

		private int milislots = 3;

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
			components = new System.ComponentModel.Container();
			panel1 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			timer1 = new System.Windows.Forms.Timer(components);
			panel2 = new System.Windows.Forms.Panel();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Location = new System.Drawing.Point(9, 10);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(406, 50);
			panel1.TabIndex = 1;
			label1.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
			label1.Font = new System.Drawing.Font("黑体", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(-5, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(582, 62);
			label1.TabIndex = 2;
			label1.Text = "正在运行，请稍后";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			panel2.BackColor = System.Drawing.Color.White;
			panel2.Controls.Add(panel1);
			panel2.Location = new System.Drawing.Point(63, 96);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(422, 69);
			panel2.TabIndex = 3;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Gray;
			base.ClientSize = new System.Drawing.Size(566, 192);
			base.Controls.Add(panel2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_Waiting";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_Waiting_Load);
			panel2.ResumeLayout(false);
			ResumeLayout(false);
		}

		public Form_Waiting(string str, int ms, int str_lines)
		{
			InitializeComponent();
			mThisForm = this;
			label1.Text = str;
			milislots = ms;
			base.Size = new Size(base.Width, base.Height + (str_lines - 1) * 20);
			label1.Size = new Size(label1.Width, label1.Height + (str_lines - 1) * 20);
			panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + (str_lines - 1) * 20);
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			int num = panel1.Size.Width / 32;
			int num2 = panel1.Size.Height - 4;
			label_list = new BindingList<Label>();
			for (int i = 0; i < 32; i++)
			{
				Label label = new Label();
				panel1.Controls.Add(label);
				label_list.Add(label);
				label.AutoSize = false;
				label.Size = new Size(num, num2);
				label.Location = new Point(1 + (num + 1) * i, 1);
				label.BackColor = Color.White;
				label.BorderStyle = BorderStyle.FixedSingle;
			}
			mReturn = false;
			Thread thread = new Thread(thd_Go);
			thread.IsBackground = true;
			thread.Start();
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			return list;
		}

		private void thd_Go()
		{
			for (int i = 0; i < 100; i++)
			{
				if (mReturn)
				{
					Invoke((MethodInvoker)delegate
					{
						mThisForm.DialogResult = DialogResult.OK;
					});
					return;
				}
				Thread.Sleep(milislots);
				set_process(i);
			}
			Invoke((MethodInvoker)delegate
			{
				mThisForm.DialogResult = DialogResult.OK;
			});
		}

		public void set_process(int index)
		{
			int index2 = index * 32 / 100;
			label_list[index2].BackColor = Color.Salmon;
		}

		public void set_return()
		{
			mReturn = true;
		}

		private void Form_Waiting_Load(object sender, EventArgs e)
		{
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
