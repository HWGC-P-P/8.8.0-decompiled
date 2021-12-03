using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_EngineerPassword : Form
	{
		private IContainer components;

		private Panel panel1;

		private TextBox textBox_inputpassword;

		private Button button_ok0;

		private Button button_cancel0;

		private Label label1;

		private Panel panel2;

		private Button button_ok1;

		private Button button_cancel1;

		private Label label5;

		private Label label4;

		private Label label3;

		private TextBox textBox_newpassword;

		private Label label2;

		private TextBox textBox_oldpassword;

		private TextBox textBox_newpassword2;

		private Label label_initpassword0000;

		private Button button_modifypassword;

		private Button button_delete_engineerpassword;

		public string mEngineerPassword;

		public int mLanguage;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

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
			button_modifypassword = new System.Windows.Forms.Button();
			button_ok0 = new System.Windows.Forms.Button();
			button_cancel0 = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			textBox_inputpassword = new System.Windows.Forms.TextBox();
			panel2 = new System.Windows.Forms.Panel();
			button_ok1 = new System.Windows.Forms.Button();
			button_delete_engineerpassword = new System.Windows.Forms.Button();
			button_cancel1 = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			textBox_newpassword2 = new System.Windows.Forms.TextBox();
			textBox_newpassword = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox_oldpassword = new System.Windows.Forms.TextBox();
			label_initpassword0000 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Controls.Add(button_modifypassword);
			panel1.Controls.Add(button_ok0);
			panel1.Controls.Add(button_cancel0);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox_inputpassword);
			panel1.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel1.Location = new System.Drawing.Point(83, 11);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(418, 149);
			panel1.TabIndex = 0;
			button_modifypassword.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_modifypassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_modifypassword.Location = new System.Drawing.Point(39, 92);
			button_modifypassword.Name = "button_modifypassword";
			button_modifypassword.Size = new System.Drawing.Size(98, 32);
			button_modifypassword.TabIndex = 2;
			button_modifypassword.Text = "修改密码";
			button_modifypassword.UseVisualStyleBackColor = true;
			button_modifypassword.Click += new System.EventHandler(button_modifypassword_Click);
			button_ok0.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_ok0.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_ok0.Location = new System.Drawing.Point(301, 92);
			button_ok0.Name = "button_ok0";
			button_ok0.Size = new System.Drawing.Size(68, 32);
			button_ok0.TabIndex = 2;
			button_ok0.Text = "确定";
			button_ok0.UseVisualStyleBackColor = true;
			button_ok0.Click += new System.EventHandler(button_ok0_Click);
			button_cancel0.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_cancel0.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_cancel0.Location = new System.Drawing.Point(227, 92);
			button_cancel0.Name = "button_cancel0";
			button_cancel0.Size = new System.Drawing.Size(68, 32);
			button_cancel0.TabIndex = 2;
			button_cancel0.Text = "取消";
			button_cancel0.UseVisualStyleBackColor = true;
			button_cancel0.Click += new System.EventHandler(button_cancel0_Click);
			label1.Font = new System.Drawing.Font("黑体", 14.25f);
			label1.Location = new System.Drawing.Point(39, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(330, 54);
			label1.TabIndex = 1;
			label1.Text = "输入工程师密码";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			textBox_inputpassword.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_inputpassword.Location = new System.Drawing.Point(39, 56);
			textBox_inputpassword.Name = "textBox_inputpassword";
			textBox_inputpassword.PasswordChar = '*';
			textBox_inputpassword.Size = new System.Drawing.Size(330, 33);
			textBox_inputpassword.TabIndex = 0;
			panel2.Controls.Add(button_ok1);
			panel2.Controls.Add(button_delete_engineerpassword);
			panel2.Controls.Add(button_cancel1);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(textBox_newpassword2);
			panel2.Controls.Add(textBox_newpassword);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(textBox_oldpassword);
			panel2.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel2.Location = new System.Drawing.Point(83, 201);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(418, 217);
			panel2.TabIndex = 0;
			button_ok1.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_ok1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_ok1.Location = new System.Drawing.Point(301, 171);
			button_ok1.Name = "button_ok1";
			button_ok1.Size = new System.Drawing.Size(68, 32);
			button_ok1.TabIndex = 2;
			button_ok1.Text = "确定";
			button_ok1.UseVisualStyleBackColor = true;
			button_ok1.Click += new System.EventHandler(button_ok1_Click);
			button_delete_engineerpassword.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_delete_engineerpassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_delete_engineerpassword.Location = new System.Drawing.Point(39, 171);
			button_delete_engineerpassword.Name = "button_delete_engineerpassword";
			button_delete_engineerpassword.Size = new System.Drawing.Size(98, 32);
			button_delete_engineerpassword.TabIndex = 2;
			button_delete_engineerpassword.Text = "删除密码";
			button_delete_engineerpassword.UseVisualStyleBackColor = true;
			button_delete_engineerpassword.Click += new System.EventHandler(button_delete_engineerpassword_Click);
			button_cancel1.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_cancel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_cancel1.Location = new System.Drawing.Point(204, 171);
			button_cancel1.Name = "button_cancel1";
			button_cancel1.Size = new System.Drawing.Size(68, 32);
			button_cancel1.TabIndex = 2;
			button_cancel1.Text = "取消";
			button_cancel1.UseVisualStyleBackColor = true;
			button_cancel1.Click += new System.EventHandler(button_cancel1_Click);
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("楷体", 12.5f);
			label5.Location = new System.Drawing.Point(15, 136);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(98, 17);
			label5.TabIndex = 1;
			label5.Text = "确认新密码";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("楷体", 12.5f);
			label4.Location = new System.Drawing.Point(15, 102);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(98, 17);
			label4.TabIndex = 1;
			label4.Text = "输入新密码";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("楷体", 12.5f);
			label3.Location = new System.Drawing.Point(15, 69);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(98, 17);
			label3.TabIndex = 1;
			label3.Text = "输入旧密码";
			textBox_newpassword2.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_newpassword2.Location = new System.Drawing.Point(184, 129);
			textBox_newpassword2.Name = "textBox_newpassword2";
			textBox_newpassword2.PasswordChar = '*';
			textBox_newpassword2.Size = new System.Drawing.Size(219, 33);
			textBox_newpassword2.TabIndex = 0;
			textBox_newpassword.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_newpassword.Location = new System.Drawing.Point(184, 94);
			textBox_newpassword.Name = "textBox_newpassword";
			textBox_newpassword.PasswordChar = '*';
			textBox_newpassword.Size = new System.Drawing.Size(219, 33);
			textBox_newpassword.TabIndex = 0;
			label2.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(27, 3);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(342, 50);
			label2.TabIndex = 1;
			label2.Text = "设置工程师密码";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			textBox_oldpassword.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_oldpassword.Location = new System.Drawing.Point(184, 59);
			textBox_oldpassword.Name = "textBox_oldpassword";
			textBox_oldpassword.PasswordChar = '*';
			textBox_oldpassword.Size = new System.Drawing.Size(219, 33);
			textBox_oldpassword.TabIndex = 0;
			label_initpassword0000.AutoSize = true;
			label_initpassword0000.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label_initpassword0000.Location = new System.Drawing.Point(3, 8);
			label_initpassword0000.Name = "label_initpassword0000";
			label_initpassword0000.Size = new System.Drawing.Size(113, 19);
			label_initpassword0000.TabIndex = 1;
			label_initpassword0000.Text = "初始密码为: 0000";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.ControlDarkDark;
			base.ClientSize = new System.Drawing.Size(589, 426);
			base.Controls.Add(label_initpassword0000);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			ForeColor = System.Drawing.SystemColors.ControlLight;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_EngineerPassword";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_EngineerPassword()
		{
			InitializeComponent();
		}

		public Form_EngineerPassword(int lan, int mode, string password)
		{
			InitializeComponent();
			mLanguage = lan;
			initLanguageTable();
			updateLanguage(lan);
			label_initpassword0000.Visible = ((password == "0000") ? true : false);
			textBox_oldpassword.Enabled = ((!(password == "")) ? true : false);
			panel2.Location = panel1.Location;
			mEngineerPassword = password;
			switch (mode)
			{
			case 0:
				panel2.Visible = false;
				panel1.Visible = true;
				base.Size = new Size(595, 226);
				break;
			case 1:
				panel1.Visible = false;
				panel2.Visible = true;
				base.Size = new Size(595, 300);
				break;
			}
		}

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
				if (mLanguage2.font != null && mLanguage2.fsize != null)
				{
					mLanguage2.ctrl.Font = new Font(mLanguage2.font[mLanguage], mLanguage2.ctrl.Font.Size + mLanguage2.fsize[mLanguage], mLanguage2.ctrl.Font.Style);
					continue;
				}
				switch (mLanguage)
				{
				case 2:
					mLanguage2.ctrl.Font = new Font("Oswald", mLanguage2.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					mLanguage2.ctrl.Font = new Font("微软雅黑", mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
					break;
				}
			}
		}

		private void initLanguageTable()
		{
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "输入工程师密码", "输入工程师密码", "Enter Engineer Password" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_modifypassword,
				str = new string[3] { "修改密码", "修改密码", "Change Password" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_delete_engineerpassword,
				str = new string[3] { "删除密码", "删除密码", "Delete Password" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "设置工程师密码", "设置工程师密码", "Change Engineer Password" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "输入旧密码", "输入旧密码", "Enter Old Password" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "输入新密码", "输入新密码", "Enter New Password" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "确认新密码", "确认新密码", "Confirm New Password" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cancel0,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok0,
				str = new string[3] { "确定", "确定", "OK" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cancel1,
				str = new string[3] { "取消", "取消", "Cancel" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok1,
				str = new string[3] { "确定", "确定", "OK" }
			});
		}

		private void button_modifypassword_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button_cancel0_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_ok0_Click(object sender, EventArgs e)
		{
			if (textBox_inputpassword.Text != mEngineerPassword)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Error Password!" : "密码错误，请重新输入！");
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}

		private void button_cancel1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_ok1_Click(object sender, EventArgs e)
		{
			if (textBox_oldpassword.Text != mEngineerPassword)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Old password error!" : "旧密码输入错误！");
				return;
			}
			if (textBox_newpassword.Text != textBox_newpassword2.Text)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "New password is not correct!" : "两次新密码输入不一样！");
				return;
			}
			mEngineerPassword = textBox_newpassword.Text;
			base.DialogResult = DialogResult.OK;
		}

		public string get_form_engineer_password()
		{
			return mEngineerPassword;
		}

		private void button_delete_engineerpassword_Click(object sender, EventArgs e)
		{
			if (textBox_oldpassword.Text != mEngineerPassword)
			{
				MainForm0.CmMessageBoxTop_Ok((mLanguage == 2) ? "Old password error!" : "旧密码输入错误！");
				return;
			}
			mEngineerPassword = "";
			base.DialogResult = DialogResult.No;
		}
	}
}
