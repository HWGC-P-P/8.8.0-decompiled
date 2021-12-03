using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_Register : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private Label label3;

		private TextBox textBox1;

		private TextBox textBox2;

		private Button button_register;

		private Button button_cancel;

		private Button button_saveas;

		public int mLanguage;

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
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			button_register = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			button_saveas = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 15.25f);
			label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label1.Location = new System.Drawing.Point(486, 18);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(98, 21);
			label1.TabIndex = 0;
			label1.Text = "软件授权";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 13f);
			label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label2.Location = new System.Drawing.Point(33, 58);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(62, 18);
			label2.TabIndex = 0;
			label2.Text = "机器码";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 13f);
			label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			label3.Location = new System.Drawing.Point(33, 109);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(62, 18);
			label3.TabIndex = 0;
			label3.Text = "授权码";
			textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			textBox1.Font = new System.Drawing.Font("黑体", 12f);
			textBox1.Location = new System.Drawing.Point(140, 52);
			textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new System.Drawing.Size(745, 26);
			textBox1.TabIndex = 1;
			textBox2.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox2.Location = new System.Drawing.Point(140, 105);
			textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(856, 26);
			textBox2.TabIndex = 1;
			button_register.Font = new System.Drawing.Font("黑体", 12f);
			button_register.Location = new System.Drawing.Point(335, 147);
			button_register.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_register.Name = "button_register";
			button_register.Size = new System.Drawing.Size(105, 32);
			button_register.TabIndex = 2;
			button_register.Text = "授权";
			button_register.UseVisualStyleBackColor = true;
			button_register.Click += new System.EventHandler(button_register_Click);
			button_cancel.Font = new System.Drawing.Font("黑体", 12f);
			button_cancel.Location = new System.Drawing.Point(608, 147);
			button_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(105, 32);
			button_cancel.TabIndex = 2;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			button_saveas.Font = new System.Drawing.Font("黑体", 12f);
			button_saveas.Location = new System.Drawing.Point(891, 47);
			button_saveas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_saveas.Name = "button_saveas";
			button_saveas.Size = new System.Drawing.Size(105, 32);
			button_saveas.TabIndex = 2;
			button_saveas.Text = "导出";
			button_saveas.UseVisualStyleBackColor = true;
			button_saveas.Click += new System.EventHandler(button_saveas_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.DimGray;
			base.ClientSize = new System.Drawing.Size(1019, 197);
			base.Controls.Add(button_saveas);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_register);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 13f);
			ForeColor = System.Drawing.SystemColors.ControlText;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			base.Name = "Form_Register";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_Register_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_Register(string devcode, string key, int language)
		{
			InitializeComponent();
			mLanguage = language;
			if (mLanguage != 0)
			{
				MainForm0.common_updateLanguage(mLanguage, initLanguageTable());
			}
			textBox1.Text = devcode;
			textBox2.Text = key;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "软件授权", "軟件授權", "Software Register" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "机器码", "機器碼", "Device Code" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "授权码", "授權碼", "Register Key" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_saveas,
				str = new string[3] { "导出", "導出", "Export" }
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
				ctrl = button_register,
				str = new string[3] { "授权", "授權", "Register" }
			});
			return list;
		}

		public string get_input_key()
		{
			return textBox2.Text;
		}

		public string getDeviceSerialCode()
		{
			ManagementClass managementClass = new ManagementClass("Win32_Processor");
			ManagementObjectCollection instances = managementClass.GetInstances();
			string text = null;
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator())
			{
				if (managementObjectEnumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
					text = managementObject.Properties["ProcessorId"].Value.ToString();
				}
			}
			managementClass = new ManagementClass("Win32_BaseBoard");
			instances = managementClass.GetInstances();
			string text2 = null;
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator2 = instances.GetEnumerator())
			{
				if (managementObjectEnumerator2.MoveNext())
				{
					ManagementObject managementObject2 = (ManagementObject)managementObjectEnumerator2.Current;
					text2 = managementObject2.Properties["SerialNumber"].Value.ToString();
				}
			}
			managementClass = new ManagementClass("Win32_PhysicalMedia");
			instances = managementClass.GetInstances();
			string text3 = null;
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator3 = instances.GetEnumerator())
			{
				if (managementObjectEnumerator3.MoveNext())
				{
					ManagementObject managementObject3 = (ManagementObject)managementObjectEnumerator3.Current;
					text3 = managementObject3.Properties["SerialNumber"].Value.ToString();
				}
			}
			managementClass = new ManagementClass("Win32_BIOS");
			instances = managementClass.GetInstances();
			string text4 = null;
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator4 = instances.GetEnumerator())
			{
				if (managementObjectEnumerator4.MoveNext())
				{
					ManagementObject managementObject4 = (ManagementObject)managementObjectEnumerator4.Current;
					text4 = managementObject4.Properties["SerialNumber"].Value.ToString();
				}
			}
			return text + "-" + text2 + "-" + text3 + "-" + text4;
		}

		private void button_register_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_saveas_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "文本文件(*.txt)|*.txt";
			saveFileDialog.RestoreDirectory = true;
			string[] array = textBox1.Text.Split(' ');
			if (array.Count() == 3)
			{
				saveFileDialog.FileName = array[0] + ".txt";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
					StreamWriter streamWriter = new StreamWriter(fileStream);
					streamWriter.Write(textBox1.Text);
					streamWriter.Flush();
					streamWriter.Close();
					fileStream.Close();
				}
			}
		}

		private void Form_Register_Load(object sender, EventArgs e)
		{
		}
	}
}
