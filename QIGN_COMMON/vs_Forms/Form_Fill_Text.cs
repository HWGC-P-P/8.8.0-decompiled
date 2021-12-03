using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_Fill_Text : Form
	{
		private IContainer components;

		private TextBox textBox1;

		private Button button_ok;

		private Button button_cancel;

		private Label label1;

		private BindingList<string> mStrlist;

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
			textBox1 = new System.Windows.Forms.TextBox();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			textBox1.Font = new System.Drawing.Font("黑体", 13.5f);
			textBox1.Location = new System.Drawing.Point(30, 46);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(356, 313);
			textBox1.TabIndex = 0;
			button_ok.Location = new System.Drawing.Point(90, 377);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(81, 35);
			button_ok.TabIndex = 1;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Location = new System.Drawing.Point(227, 377);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(81, 35);
			button_cancel.TabIndex = 1;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14f);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(164, 13);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 19);
			label1.TabIndex = 2;
			label1.Text = "封装别名";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.DimGray;
			base.ClientSize = new System.Drawing.Size(419, 422);
			base.Controls.Add(label1);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(textBox1);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_Fill_Text";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_Fill_Text_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_Fill_Text(BindingList<string> strs)
		{
			InitializeComponent();
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			mStrlist = new BindingList<string>();
			if (strs != null)
			{
				textBox1.Text = "";
				for (int i = 0; i < strs.Count; i++)
				{
					TextBox textBox = textBox1;
					textBox.Text = textBox.Text + strs[i] + Environment.NewLine;
				}
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "封装别名", "封裝別名", "Nick Name" }
			});
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
				ctrl = button_cancel,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			return list;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		public BindingList<string> get_strings()
		{
			for (int i = 0; i < textBox1.Lines.Count(); i++)
			{
				mStrlist.Add(textBox1.Lines[i]);
			}
			return mStrlist;
		}

		private void Form_Fill_Text_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_ok);
			MainForm0.CreateAddButtonPic(button_cancel);
		}
	}
}
