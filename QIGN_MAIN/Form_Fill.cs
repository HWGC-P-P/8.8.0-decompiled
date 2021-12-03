using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON;

namespace QIGN_MAIN
{
	public class Form_Fill : Form
	{
		public string mdata_string = "";

		public float mdata_float;

		public int mdata_int;

		public ProviderType mdata_provider;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		private IContainer components;

		private TextBox textBox1;

		private Button button_OK;

		private Button button_Cancel;

		private Label label_type;

		private NumericUpDown numericUpDown_float;

		private NumericUpDown numericUpDown_int;

		private ComboBox comboBox_provider;

		public Form_Fill(int mLanguage, string type, string data_type)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			initLanguageTable();
			updateLanguage(mLanguage);
			label_type.Text = type;
			textBox1.Visible = (numericUpDown_float.Visible = (numericUpDown_int.Visible = (comboBox_provider.Visible = false)));
			switch (data_type)
			{
			case "string":
				textBox1.Visible = true;
				break;
			case "float":
				numericUpDown_float.Visible = true;
				break;
			case "int":
				numericUpDown_int.Visible = true;
				break;
			case "provider_int":
			{
				NumericUpDown numericUpDown = numericUpDown_int;
				bool visible = (comboBox_provider.Visible = true);
				numericUpDown.Visible = visible;
				break;
			}
			}
			for (int i = 0; i < 3; i++)
			{
				comboBox_provider.Items.Add(STR.PROVIDER_STR[i][mLanguage]);
			}
			comboBox_provider.SelectedIndex = 0;
			mdata_string = (textBox1.Text = "");
			mdata_float = 0f;
			mdata_int = 0;
		}

		public Form_Fill(int mLanguage, object value, string type, string data_type)
		{
			InitializeComponent();
			base.Icon = MainForm0.GetIcon(1);
			initLanguageTable();
			updateLanguage(mLanguage);
			label_type.Text = type;
			textBox1.Visible = (numericUpDown_float.Visible = (numericUpDown_int.Visible = (comboBox_provider.Visible = false)));
			switch (data_type)
			{
			case "string":
				textBox1.Visible = true;
				textBox1.Text = (string)value;
				break;
			case "float":
				numericUpDown_float.Visible = true;
				numericUpDown_float.Value = (decimal)value;
				break;
			case "int":
				numericUpDown_int.Visible = true;
				numericUpDown_int.Value = (decimal)value;
				break;
			case "provider_int":
			{
				NumericUpDown numericUpDown = numericUpDown_int;
				bool visible = (comboBox_provider.Visible = true);
				numericUpDown.Visible = visible;
				numericUpDown_int.Value = (decimal)value;
				break;
			}
			}
			for (int i = 0; i < 3; i++)
			{
				comboBox_provider.Items.Add(STR.PROVIDER_STR[i][mLanguage]);
			}
			comboBox_provider.SelectedIndex = 0;
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
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_type,
				str = new string[3] { "类型", "类型", "DATA TYPE" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OK,
				str = new string[3] { "确定", "确定", "OK" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Cancel,
				str = new string[3] { "取消", "取消", "CANCEL" }
			});
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			mdata_string = textBox1.Text;
		}

		private void numericUpDown_float_ValueChanged(object sender, EventArgs e)
		{
			mdata_float = (float)numericUpDown_float.Value;
		}

		private void numericUpDown_int_ValueChanged(object sender, EventArgs e)
		{
			mdata_int = (int)numericUpDown_int.Value;
		}

		private void comboBox_provider_SelectedIndexChanged(object sender, EventArgs e)
		{
			mdata_provider = (ProviderType)comboBox_provider.SelectedIndex;
		}

		public string get_string()
		{
			return mdata_string;
		}

		public void set_string(string s)
		{
			textBox1.Text = (mdata_string = s);
		}

		public float get_float()
		{
			return mdata_float;
		}

		public void set_float(float f)
		{
			mdata_float = f;
			numericUpDown_float.Value = (decimal)f;
		}

		public int get_int()
		{
			return mdata_int;
		}

		public void set_int(int f)
		{
			mdata_int = f;
			numericUpDown_int.Value = f;
		}

		public ProviderType get_provider()
		{
			return mdata_provider;
		}

		public void set_provider(ProviderType f)
		{
			mdata_provider = f;
			comboBox_provider.SelectedIndex = (int)f;
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.Form_Fill));
			textBox1 = new System.Windows.Forms.TextBox();
			button_OK = new System.Windows.Forms.Button();
			button_Cancel = new System.Windows.Forms.Button();
			label_type = new System.Windows.Forms.Label();
			numericUpDown_float = new System.Windows.Forms.NumericUpDown();
			numericUpDown_int = new System.Windows.Forms.NumericUpDown();
			comboBox_provider = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)numericUpDown_float).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_int).BeginInit();
			SuspendLayout();
			textBox1.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox1.Location = new System.Drawing.Point(39, 54);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(297, 26);
			textBox1.TabIndex = 0;
			textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
			button_OK.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OK.Location = new System.Drawing.Point(80, 96);
			button_OK.Margin = new System.Windows.Forms.Padding(2);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(73, 28);
			button_OK.TabIndex = 1;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = true;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			button_Cancel.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Cancel.Location = new System.Drawing.Point(216, 96);
			button_Cancel.Margin = new System.Windows.Forms.Padding(2);
			button_Cancel.Name = "button_Cancel";
			button_Cancel.Size = new System.Drawing.Size(73, 28);
			button_Cancel.TabIndex = 1;
			button_Cancel.Text = "取消";
			button_Cancel.UseVisualStyleBackColor = true;
			button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
			label_type.AutoSize = true;
			label_type.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_type.Location = new System.Drawing.Point(36, 15);
			label_type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label_type.Name = "label_type";
			label_type.Size = new System.Drawing.Size(40, 16);
			label_type.TabIndex = 2;
			label_type.Text = "类型";
			numericUpDown_float.DecimalPlaces = 2;
			numericUpDown_float.Font = new System.Drawing.Font("楷体", 12f);
			numericUpDown_float.Location = new System.Drawing.Point(80, 54);
			numericUpDown_float.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
			numericUpDown_float.Minimum = new decimal(new int[4] { 100000, 0, 0, -2147483648 });
			numericUpDown_float.Name = "numericUpDown_float";
			numericUpDown_float.Size = new System.Drawing.Size(228, 26);
			numericUpDown_float.TabIndex = 3;
			numericUpDown_float.ValueChanged += new System.EventHandler(numericUpDown_float_ValueChanged);
			numericUpDown_int.Font = new System.Drawing.Font("楷体", 12f);
			numericUpDown_int.Location = new System.Drawing.Point(81, 54);
			numericUpDown_int.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
			numericUpDown_int.Minimum = new decimal(new int[4] { 100000, 0, 0, -2147483648 });
			numericUpDown_int.Name = "numericUpDown_int";
			numericUpDown_int.Size = new System.Drawing.Size(227, 26);
			numericUpDown_int.TabIndex = 4;
			numericUpDown_int.ValueChanged += new System.EventHandler(numericUpDown_int_ValueChanged);
			comboBox_provider.Font = new System.Drawing.Font("楷体", 12f);
			comboBox_provider.FormattingEnabled = true;
			comboBox_provider.Location = new System.Drawing.Point(208, 15);
			comboBox_provider.Name = "comboBox_provider";
			comboBox_provider.Size = new System.Drawing.Size(100, 24);
			comboBox_provider.TabIndex = 5;
			comboBox_provider.SelectedIndexChanged += new System.EventHandler(comboBox_provider_SelectedIndexChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.LightSalmon;
			base.ClientSize = new System.Drawing.Size(377, 135);
			base.Controls.Add(comboBox_provider);
			base.Controls.Add(numericUpDown_int);
			base.Controls.Add(numericUpDown_float);
			base.Controls.Add(label_type);
			base.Controls.Add(button_Cancel);
			base.Controls.Add(button_OK);
			base.Controls.Add(textBox1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Form_Fill";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)numericUpDown_float).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_int).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
