using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_MarkCamPara : Form
	{
		private IContainer components;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Label label3;

		private Panel panel4;

		private Label label2;

		private Panel panel3;

		private Label label4;

		private Panel panel5;

		private Button button_light;

		private Button button_led;

		private Label label5;

		private NumericUpDown numericUpDown_markStillDelay;

		private Panel panel6;

		private int mFn;

		private USR_DATA USR;

		private USR3_DATA USR3;

		private USR_INIT_DATA USR_INIT;

		private TrackBar[] trackBar_led;

		private TrackBar[] trackBar_cam;

		private Label[] label_led;

		private Label[] label_cam;

		private int[] mIsParaIndexChange;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		public event void_Func_void update_button_markpara;

		public event void_Func_bool mark_light_on;

		public event void_Func_bool mark_led_on;

		public event void_Func_bool change_lightonoff_button;

		public event void_Func_int_int mark_lightlevel_set;

		public event void_Func_int_intM set_camera_parameter;

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
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			panel5 = new System.Windows.Forms.Panel();
			button_led = new System.Windows.Forms.Button();
			button_light = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			numericUpDown_markStillDelay = new System.Windows.Forms.NumericUpDown();
			panel6 = new System.Windows.Forms.Panel();
			panel2.SuspendLayout();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_markStillDelay).BeginInit();
			panel6.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.LightBlue;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Location = new System.Drawing.Point(12, 37);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(160, 332);
			panel1.TabIndex = 0;
			label1.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			label1.Location = new System.Drawing.Point(12, 1);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(528, 33);
			label1.TabIndex = 1;
			label1.Text = "Mark相机";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel2.Controls.Add(label3);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(panel3);
			panel2.Location = new System.Drawing.Point(3, 62);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(335, 269);
			panel2.TabIndex = 0;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(7, 138);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(91, 14);
			label3.TabIndex = 1;
			label3.Text = "MARK相机设置";
			panel4.Location = new System.Drawing.Point(10, 155);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(314, 109);
			panel4.TabIndex = 0;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(5, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(91, 14);
			label2.TabIndex = 1;
			label2.Text = "MARK光源设置";
			panel3.Location = new System.Drawing.Point(8, 24);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(316, 111);
			panel3.TabIndex = 0;
			label4.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.Location = new System.Drawing.Point(8, -4);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(323, 34);
			label4.TabIndex = 3;
			label4.Text = "label4";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel5.BackColor = System.Drawing.Color.LightBlue;
			panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel5.Controls.Add(button_led);
			panel5.Controls.Add(button_light);
			panel5.Controls.Add(label4);
			panel5.Controls.Add(panel2);
			panel5.Location = new System.Drawing.Point(189, 37);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(351, 332);
			panel5.TabIndex = 4;
			button_led.Location = new System.Drawing.Point(173, 28);
			button_led.Name = "button_led";
			button_led.Size = new System.Drawing.Size(84, 28);
			button_led.TabIndex = 4;
			button_led.Text = "光源已开";
			button_led.UseVisualStyleBackColor = true;
			button_led.Click += new System.EventHandler(button_led_Click);
			button_light.Location = new System.Drawing.Point(83, 28);
			button_light.Name = "button_light";
			button_light.Size = new System.Drawing.Size(84, 28);
			button_light.TabIndex = 4;
			button_light.Text = "照明已开";
			button_light.UseVisualStyleBackColor = true;
			button_light.Click += new System.EventHandler(button_light_Click);
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label5.Location = new System.Drawing.Point(3, 9);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(161, 14);
			label5.TabIndex = 1;
			label5.Text = "MARK相机拍照延时（ms）";
			numericUpDown_markStillDelay.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_markStillDelay.Location = new System.Drawing.Point(179, 7);
			numericUpDown_markStillDelay.Maximum = new decimal(new int[4] { 2000, 0, 0, 0 });
			numericUpDown_markStillDelay.Name = "numericUpDown_markStillDelay";
			numericUpDown_markStillDelay.Size = new System.Drawing.Size(59, 23);
			numericUpDown_markStillDelay.TabIndex = 5;
			numericUpDown_markStillDelay.ValueChanged += new System.EventHandler(numericUpDown_markStillDelay_ValueChanged);
			panel6.BackColor = System.Drawing.Color.LightBlue;
			panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel6.Controls.Add(label5);
			panel6.Controls.Add(numericUpDown_markStillDelay);
			panel6.Location = new System.Drawing.Point(12, 379);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(528, 37);
			panel6.TabIndex = 6;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(552, 431);
			base.Controls.Add(panel6);
			base.Controls.Add(panel5);
			base.Controls.Add(label1);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new System.Drawing.Point(4, 558);
			base.Name = "Form_MarkCamPara";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Form_MarkCamPara_FormClosed);
			base.Load += new System.EventHandler(Form_MarkCamPara_Load);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDown_markStillDelay).EndInit();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			ResumeLayout(false);
		}

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
				if (mLanguage2.font != null && mLanguage2.fsize != null)
				{
					mLanguage2.ctrl.Font = new Font(mLanguage2.font[USR_INIT.mLanguage], mLanguage2.ctrl.Font.Size + mLanguage2.fsize[USR_INIT.mLanguage], mLanguage2.ctrl.Font.Style);
					continue;
				}
				switch (mLanguage)
				{
				case 2:
					mLanguage2.ctrl.Font = new Font("Oswald", mLanguage2.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					mLanguage2.ctrl.Font = new Font(DEF.FONT_2020[mLanguage], mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
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
				ctrl = label1,
				str = new string[3] { "Mark相机参数", "Mark相机参数", "Mark-Camera Parameter" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "Mark光源设置", "Mark光源设置", "Mark Led Setting" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "Mark相机设置", "Mark相机设置", "Mark Camera Setting" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "Mark相机拍照延时(ms)", "Mark相机拍照延时(ms)", "Mark Camera Capture Delay(ms)" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "", "", "" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_led,
				str = new string[3] { "", "", "" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_light,
				str = new string[3] { "", "", "" }
			});
		}

		public Form_MarkCamPara(int fn, USR_DATA _usr)
		{
			InitializeComponent();
			mFn = fn;
			USR = _usr;
			USR_INIT = MainForm0.USR_INIT;
			initLanguageTable();
			updateLanguage(USR_INIT.mLanguage);
			update_light_led_buttion(USR.mMarkCamParaIndex);
			for (int i = 0; i < 10; i++)
			{
				RadioButton radioButton = new RadioButton();
				panel1.Controls.Add(radioButton);
				radioButton.Location = new Point(4, 4 + i * 25);
				radioButton.Text = STR.MARK_PARA_STR[i][USR_INIT.mLanguage];
				radioButton.Tag = i;
				radioButton.CheckedChanged += radio_checkedChanged;
				radioButton.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], radioButton.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], radioButton.Font.Style);
				if (USR.mMarkCamParaIndex == i)
				{
					radioButton.Checked = true;
					this.label4.Text = radioButton.Text;
				}
			}
			trackBar_led = new TrackBar[4];
			trackBar_cam = new TrackBar[4];
			label_led = new Label[4];
			label_cam = new Label[4];
			for (int j = 0; j < 4; j++)
			{
				Label label = new Label();
				panel3.Controls.Add(label);
				label.Location = new Point(4, 4 + j * 25);
				label.Size = new Size(60, 25);
				label.Text = STR.MARK_LED_PARA_STR[j][USR_INIT.mLanguage];
				label.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], label.Font.Style);
				TrackBar trackBar = new TrackBar();
				panel3.Controls.Add(trackBar);
				trackBar.Location = new Point(64, 4 + j * 25);
				trackBar.Size = new Size(220, 25);
				trackBar.Minimum = 0;
				trackBar.Maximum = 840;
				trackBar.Value = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[j];
				trackBar.Orientation = Orientation.Horizontal;
				trackBar.TickFrequency = 50;
				trackBar.BringToFront();
				trackBar.Tag = j;
				trackBar.ValueChanged += trackbar_led_valueChanged;
				trackBar_led[j] = trackBar;
				Label label2 = new Label();
				panel3.Controls.Add(label2);
				label2.Location = new Point(284, 4 + j * 25);
				label2.Size = new Size(60, 25);
				label2.Text = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[j].ToString();
				label_led[j] = label2;
			}
			for (int k = 0; k < 4; k++)
			{
				Label label3 = new Label();
				panel4.Controls.Add(label3);
				label3.Location = new Point(4, 4 + k * 25);
				label3.Size = new Size(60, 25);
				label3.Text = STR.MARK_CAM_PARA_STR[k][USR_INIT.mLanguage];
				label3.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label3.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], label3.Font.Style);
				TrackBar trackBar2 = new TrackBar();
				panel4.Controls.Add(trackBar2);
				trackBar2.Location = new Point(64, 4 + k * 25);
				trackBar2.Size = new Size(220, 25);
				trackBar2.Minimum = 0;
				trackBar2.Maximum = 255;
				trackBar2.Value = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[k];
				trackBar2.Orientation = Orientation.Horizontal;
				trackBar2.TickFrequency = 50;
				trackBar2.BringToFront();
				trackBar2.Tag = k;
				trackBar2.ValueChanged += trackbar_cam_valueChanged;
				trackBar_cam[k] = trackBar2;
				Label label4 = new Label();
				panel4.Controls.Add(label4);
				label4.Location = new Point(284, 4 + k * 25);
				label4.Size = new Size(60, 25);
				label4.Text = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[k].ToString();
				label_cam[k] = label4;
			}
			int[] array = (mIsParaIndexChange = new int[2]);
		}

		public void radio_checkedChanged(object sender, EventArgs e)
		{
			if (USR == null || trackBar_led == null || label_led == null || trackBar_cam == null || label_cam == null)
			{
				return;
			}
			RadioButton radioButton = (RadioButton)sender;
			int num = (int)radioButton.Tag;
			if (radioButton.Checked)
			{
				mIsParaIndexChange[0] = USR.mMarkCamPara[num].mParaLed[0] - mIsParaIndexChange[0];
				mIsParaIndexChange[1] = USR.mMarkCamPara[num].mParaLed[1] - mIsParaIndexChange[1];
				USR.mMarkCamParaIndex = num;
				label4.Text = STR.MARK_PARA_STR[num][USR_INIT.mLanguage];
				for (int i = 0; i < 4; i++)
				{
					trackBar_led[i].Value = USR.mMarkCamPara[num].mParaLed[i];
					label_led[i].Text = USR.mMarkCamPara[num].mParaLed[i].ToString();
					trackBar_cam[i].Value = USR.mMarkCamPara[num].mParaCam[i];
					label_cam[i].Text = USR.mMarkCamPara[num].mParaCam[i].ToString();
				}
				if (this.update_button_markpara != null)
				{
					this.update_button_markpara();
				}
				MainForm0.mark_light_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
				MainForm0.mark_led_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
				update_light_led_buttion(USR.mMarkCamParaIndex);
			}
			else
			{
				mIsParaIndexChange[0] = USR.mMarkCamPara[num].mParaLed[0] - mIsParaIndexChange[0];
				mIsParaIndexChange[1] = USR.mMarkCamPara[num].mParaLed[1] - mIsParaIndexChange[1];
			}
		}

		public void trackbar_led_valueChanged(object sender, EventArgs e)
		{
			if (USR == null || trackBar_led == null || label_led == null || trackBar_cam == null || label_cam == null)
			{
				return;
			}
			int num = (int)((TrackBar)sender).Tag;
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[num] = trackBar_led[num].Value;
			label_led[num].Text = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[num].ToString();
			bool mLightOn = USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn;
			bool mLedOn = USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn;
			switch (num)
			{
			case 0:
				this.mark_lightlevel_set(num, USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[num]);
				USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn = true;
				MainForm0.mark_light_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
				if (mIsParaIndexChange[num] != 0)
				{
					USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn = mLightOn;
					MainForm0.mark_light_on_ext(mFn, mLightOn);
					mIsParaIndexChange[0] = 0;
				}
				update_light_led_buttion(USR.mMarkCamParaIndex);
				break;
			case 1:
				this.mark_lightlevel_set(num, USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[num]);
				USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn = true;
				MainForm0.mark_led_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
				if (mIsParaIndexChange[num] != 0)
				{
					USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn = mLedOn;
					MainForm0.mark_led_on_ext(mFn, mLedOn);
					mIsParaIndexChange[num] = 0;
				}
				update_light_led_buttion(USR.mMarkCamParaIndex);
				break;
			}
		}

		public void trackbar_cam_valueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				int num = (int)((TrackBar)sender).Tag;
				USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[num] = trackBar_cam[num].Value;
				label_cam[num].Text = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[num].ToString();
				this.set_camera_parameter(HW.mMarkCamItem[mFn].index[0], USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam);
			}
		}

		public void update_light_led_buttion(int index)
		{
			string[] array = new string[3] { "照明已", "照明已", "Light " };
			string[] array2 = new string[3] { "光源已", "光源已", "Led " };
			string[] array3 = new string[3] { "开", "开", "On" };
			string[] array4 = new string[3] { "关", "关", "Off" };
			button_light.BackColor = (USR.mMarkCamPara[index].mLightOn ? Color.LightSalmon : Color.Gray);
			button_led.BackColor = (USR.mMarkCamPara[index].mLedOn ? Color.LightSalmon : Color.Gray);
			button_light.Text = array[USR_INIT.mLanguage] + (USR.mMarkCamPara[index].mLightOn ? array3[USR_INIT.mLanguage] : array4[USR_INIT.mLanguage]);
			button_led.Text = array2[USR_INIT.mLanguage] + (USR.mMarkCamPara[index].mLedOn ? array3[USR_INIT.mLanguage] : array4[USR_INIT.mLanguage]);
		}

		private void Form_MarkCamPara_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.change_lightonoff_button(flag: true);
		}

		private void Form_MarkCamPara_Load(object sender, EventArgs e)
		{
			this.change_lightonoff_button(flag: false);
			MainForm0.mark_light_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
			MainForm0.mark_led_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
			if (USR.mMarkCamStillDelay == 0)
			{
				USR.mMarkCamStillDelay = 100;
			}
			numericUpDown_markStillDelay.Value = USR.mMarkCamStillDelay;
		}

		private void button_light_Click(object sender, EventArgs e)
		{
			USR.mIsMarkLightOn = (USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn = !USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
			MainForm0.mark_light_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
			update_light_led_buttion(USR.mMarkCamParaIndex);
		}

		private void button_led_Click(object sender, EventArgs e)
		{
			USR.mIsMarkLedOn = (USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn = !USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
			MainForm0.mark_led_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
			update_light_led_buttion(USR.mMarkCamParaIndex);
		}

		private void numericUpDown_markStillDelay_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mMarkCamStillDelay = (int)numericUpDown_markStillDelay.Value;
			}
		}
	}
}
