using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_MessageBox : Form
	{
		private IContainer components;

		private Label label_msg;

		private Button button_ok;

		private Button button_cancel;

		private Panel panel_okcancel;

		private Panel panel_yesno;

		private Button button_no;

		private Button button_yes;

		private Panel panel_yesnocancel;

		private Button button_cancel2;

		private Button button_no2;

		private Button button_yes2;

		private Panel panel_ok;

		private Button button_ok2;

		private Label label1;

		private Label label2;

		public Form_MessageBox(string msg, MessageBoxButtons btmode)
		{
			InitializeComponent();
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			base.Size = new Size(629, 203);
			panel_ok.Location = (panel_yesno.Location = (panel_yesnocancel.Location = panel_okcancel.Location));
			panel_ok.Visible = (panel_yesno.Visible = (panel_yesnocancel.Visible = (panel_okcancel.Visible = false)));
			switch (btmode)
			{
			case MessageBoxButtons.OKCancel:
				panel_okcancel.Visible = true;
				break;
			case MessageBoxButtons.OK:
				panel_ok.Visible = true;
				break;
			case MessageBoxButtons.YesNo:
				panel_yesno.Visible = true;
				break;
			case MessageBoxButtons.YesNoCancel:
				panel_yesnocancel.Visible = true;
				break;
			default:
				return;
			}
			label_msg.Text = msg;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_ok2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_cancel2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_yes_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button_yes2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button_no_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
		}

		private void button_no2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok,
				str = new string[3] { "确定", "確定", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok2,
				str = new string[3] { "确定", "確定", "OK" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cancel,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_yes,
				str = new string[3] { "是", "是", "Yes" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_yes2,
				str = new string[3] { "是", "是", "Yes" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_no,
				str = new string[3] { "否", "否", "No" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_no2,
				str = new string[3] { "否", "否", "No" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_msg,
				str = new string[3] { "", "", "" }
			});
			return list;
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
			label_msg = new System.Windows.Forms.Label();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			panel_okcancel = new System.Windows.Forms.Panel();
			panel_yesno = new System.Windows.Forms.Panel();
			button_no = new System.Windows.Forms.Button();
			button_yes = new System.Windows.Forms.Button();
			panel_yesnocancel = new System.Windows.Forms.Panel();
			button_cancel2 = new System.Windows.Forms.Button();
			button_no2 = new System.Windows.Forms.Button();
			button_yes2 = new System.Windows.Forms.Button();
			panel_ok = new System.Windows.Forms.Panel();
			button_ok2 = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel_okcancel.SuspendLayout();
			panel_yesno.SuspendLayout();
			panel_yesnocancel.SuspendLayout();
			panel_ok.SuspendLayout();
			SuspendLayout();
			label_msg.Font = new System.Drawing.Font("楷体", 14.25f);
			label_msg.Location = new System.Drawing.Point(22, 9);
			label_msg.Name = "label_msg";
			label_msg.Size = new System.Drawing.Size(560, 91);
			label_msg.TabIndex = 0;
			label_msg.Text = "是否将[元件厚度]同步到料站库，并修改[贴装高度]？";
			label_msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_ok.Font = new System.Drawing.Font("楷体", 12f);
			button_ok.Location = new System.Drawing.Point(16, 4);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(120, 39);
			button_ok.TabIndex = 1;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Font = new System.Drawing.Font("楷体", 12f);
			button_cancel.Location = new System.Drawing.Point(215, 4);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(120, 39);
			button_cancel.TabIndex = 1;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			panel_okcancel.Controls.Add(button_cancel);
			panel_okcancel.Controls.Add(button_ok);
			panel_okcancel.Location = new System.Drawing.Point(123, 103);
			panel_okcancel.Name = "panel_okcancel";
			panel_okcancel.Size = new System.Drawing.Size(350, 47);
			panel_okcancel.TabIndex = 2;
			panel_yesno.Controls.Add(button_no);
			panel_yesno.Controls.Add(button_yes);
			panel_yesno.Location = new System.Drawing.Point(123, 199);
			panel_yesno.Name = "panel_yesno";
			panel_yesno.Size = new System.Drawing.Size(350, 47);
			panel_yesno.TabIndex = 2;
			button_no.Font = new System.Drawing.Font("楷体", 12f);
			button_no.Location = new System.Drawing.Point(215, 4);
			button_no.Name = "button_no";
			button_no.Size = new System.Drawing.Size(120, 39);
			button_no.TabIndex = 1;
			button_no.Text = "否";
			button_no.UseVisualStyleBackColor = true;
			button_no.Click += new System.EventHandler(button_no_Click);
			button_yes.Font = new System.Drawing.Font("楷体", 12f);
			button_yes.Location = new System.Drawing.Point(16, 4);
			button_yes.Name = "button_yes";
			button_yes.Size = new System.Drawing.Size(120, 39);
			button_yes.TabIndex = 1;
			button_yes.Text = "是";
			button_yes.UseVisualStyleBackColor = true;
			button_yes.Click += new System.EventHandler(button_yes_Click);
			panel_yesnocancel.Controls.Add(button_cancel2);
			panel_yesnocancel.Controls.Add(button_no2);
			panel_yesnocancel.Controls.Add(button_yes2);
			panel_yesnocancel.Location = new System.Drawing.Point(123, 254);
			panel_yesnocancel.Name = "panel_yesnocancel";
			panel_yesnocancel.Size = new System.Drawing.Size(356, 47);
			panel_yesnocancel.TabIndex = 2;
			button_cancel2.Font = new System.Drawing.Font("楷体", 12f);
			button_cancel2.Location = new System.Drawing.Point(260, 3);
			button_cancel2.Name = "button_cancel2";
			button_cancel2.Size = new System.Drawing.Size(90, 39);
			button_cancel2.TabIndex = 1;
			button_cancel2.Text = "取消";
			button_cancel2.UseVisualStyleBackColor = true;
			button_cancel2.Click += new System.EventHandler(button_cancel2_Click);
			button_no2.Font = new System.Drawing.Font("楷体", 12f);
			button_no2.Location = new System.Drawing.Point(133, 3);
			button_no2.Name = "button_no2";
			button_no2.Size = new System.Drawing.Size(90, 39);
			button_no2.TabIndex = 1;
			button_no2.Text = "否";
			button_no2.UseVisualStyleBackColor = true;
			button_no2.Click += new System.EventHandler(button_no2_Click);
			button_yes2.Font = new System.Drawing.Font("楷体", 12f);
			button_yes2.Location = new System.Drawing.Point(3, 3);
			button_yes2.Name = "button_yes2";
			button_yes2.Size = new System.Drawing.Size(90, 39);
			button_yes2.TabIndex = 1;
			button_yes2.Text = "是";
			button_yes2.UseVisualStyleBackColor = true;
			button_yes2.Click += new System.EventHandler(button_yes2_Click);
			panel_ok.Controls.Add(button_ok2);
			panel_ok.Location = new System.Drawing.Point(123, 307);
			panel_ok.Name = "panel_ok";
			panel_ok.Size = new System.Drawing.Size(350, 47);
			panel_ok.TabIndex = 2;
			button_ok2.Font = new System.Drawing.Font("楷体", 12f);
			button_ok2.Location = new System.Drawing.Point(115, 3);
			button_ok2.Name = "button_ok2";
			button_ok2.Size = new System.Drawing.Size(120, 39);
			button_ok2.TabIndex = 1;
			button_ok2.Text = "确定";
			button_ok2.UseVisualStyleBackColor = true;
			button_ok2.Click += new System.EventHandler(button_ok2_Click);
			label1.BackColor = System.Drawing.Color.SlateGray;
			label1.Location = new System.Drawing.Point(-3, -1);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(630, 10);
			label1.TabIndex = 3;
			label2.BackColor = System.Drawing.Color.SlateGray;
			label2.Location = new System.Drawing.Point(-3, 166);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(630, 15);
			label2.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			base.ClientSize = new System.Drawing.Size(623, 383);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(panel_yesnocancel);
			base.Controls.Add(panel_yesno);
			base.Controls.Add(panel_ok);
			base.Controls.Add(panel_okcancel);
			base.Controls.Add(label_msg);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_MessageBox";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			panel_okcancel.ResumeLayout(false);
			panel_yesno.ResumeLayout(false);
			panel_yesnocancel.ResumeLayout(false);
			panel_ok.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
