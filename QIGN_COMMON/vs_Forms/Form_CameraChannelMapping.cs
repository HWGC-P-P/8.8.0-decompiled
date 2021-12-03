using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_CameraChannelMapping : Form
	{
		private IContainer components;

		private CheckBox checkBox1;

		private Panel panel1;

		private Button button_ok;

		private Button button_cancel;

		private Label label1;

		private USR_DATA USR;

		private USR_INIT_DATA USR_INIT;

		private NumericUpDown[] numericupdown_mapping;

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
			checkBox1 = new System.Windows.Forms.CheckBox();
			panel1 = new System.Windows.Forms.Panel();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			checkBox1.AutoSize = true;
			checkBox1.Font = new System.Drawing.Font("黑体", 11.5f);
			checkBox1.ForeColor = System.Drawing.Color.White;
			checkBox1.Location = new System.Drawing.Point(45, 71);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(203, 20);
			checkBox1.TabIndex = 1;
			checkBox1.Text = "启用自定义相机通道映射";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
			panel1.ForeColor = System.Drawing.Color.White;
			panel1.Location = new System.Drawing.Point(45, 119);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(216, 261);
			panel1.TabIndex = 2;
			button_ok.Location = new System.Drawing.Point(62, 404);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(75, 26);
			button_ok.TabIndex = 3;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Location = new System.Drawing.Point(157, 404);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(75, 26);
			button_cancel.TabIndex = 3;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			label1.Font = new System.Drawing.Font("黑体", 13f);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(-2, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(295, 22);
			label1.TabIndex = 4;
			label1.Text = "自定义相机通道";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.WindowFrame;
			base.ClientSize = new System.Drawing.Size(296, 447);
			base.Controls.Add(label1);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(panel1);
			base.Controls.Add(checkBox1);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_CameraChannelMapping";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(Form_CameraChannelMapping_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_CameraChannelMapping(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox1,
				str = new string[3] { "启用自定义相机通道映射", "啟用自定義相機通道映射", "Enable Function" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok,
				str = new string[3] { "确认", "確認", "OK" }
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
				ctrl = label1,
				str = new string[3] { "自定义相机通道", "自定義相機通道", "Customization Camera Channel Mapping" }
			});
			return list;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			panel1.Enabled = checkBox1.Checked;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			USR_INIT.misfcam_def_channel = checkBox1.Checked;
			for (int i = 0; i < numericupdown_mapping.Count() - 1; i++)
			{
				for (int j = i + 1; j < numericupdown_mapping.Count(); j++)
				{
					if (numericupdown_mapping[i].Value == numericupdown_mapping[j].Value)
					{
						string[] array = new string[3] { "通道号设置有重复，冲突！请重新设置！", "通道號設置有重復，沖突！請重新設置！", "Channel numbers conflict, please check!" };
						MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
						return;
					}
				}
			}
			for (int k = 0; k < numericupdown_mapping.Count() - 1; k++)
			{
				USR_INIT.fcam_def_channel[k] = (int)numericupdown_mapping[k].Value;
			}
			USR_INIT.mark_def_channel = (int)numericupdown_mapping[HW.mZnNum[MainForm0.mFn]].Value;
			if (checkBox1.Checked)
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.No;
			}
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Form_CameraChannelMapping_Load(object sender, EventArgs e)
		{
			checkBox1.Checked = USR_INIT.misfcam_def_channel;
			panel1.Enabled = USR_INIT.misfcam_def_channel;
			if (USR_INIT.fcam_def_channel == null)
			{
				USR_INIT.fcam_def_channel = new int[8];
				for (int i = 0; i < 8; i++)
				{
					USR_INIT.fcam_def_channel[i] = i;
				}
				USR_INIT.mark_def_channel = 8;
			}
			numericupdown_mapping = new NumericUpDown[HW.mZnNum[MainForm0.mFn] + 1];
			for (int j = 0; j < HW.mZnNum[MainForm0.mFn] + 1; j++)
			{
				Label label = new Label();
				panel1.Controls.Add(label);
				label.AutoSize = false;
				label.Location = new Point(5, j * 28);
				label.Size = new Size(70, 25);
				label.ForeColor = Color.White;
				Label label2 = new Label();
				panel1.Controls.Add(label2);
				label2.AutoSize = false;
				label2.Location = new Point(80, j * 28);
				label2.Size = new Size(40, 25);
				label2.Text = (new string[3] { "通道", "通道", "Ch- " })[USR_INIT.mLanguage];
				label2.ForeColor = Color.White;
				NumericUpDown numericUpDown = new NumericUpDown();
				panel1.Controls.Add(numericUpDown);
				numericUpDown.Minimum = 0m;
				numericUpDown.Maximum = 15m;
				numericUpDown.Location = new Point(120, j * 28);
				numericUpDown.Size = new Size(50, 25);
				numericupdown_mapping[j] = numericUpDown;
				if (j == HW.mZnNum[MainForm0.mFn])
				{
					label.Text = "MARK" + (new string[3] { "相机", "相機", " Cam " })[USR_INIT.mLanguage];
					numericUpDown.Value = USR_INIT.mark_def_channel;
				}
				else
				{
					label.Text = (new string[3] { "快速相机", "快速相機", "Fast Cam " })[USR_INIT.mLanguage] + (j + 1);
					numericUpDown.Value = USR_INIT.fcam_def_channel[j];
				}
			}
		}
	}
}
