using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_MarkCamParaUSR3 : Form
	{
		private int mFn;

		private USR_INIT_DATA USR_INIT;

		private USR_DATA USR;

		private USR3_DATA USR3;

		private int mMarkNo;

		private TrackBar[] trackBar_led;

		private TrackBar[] trackBar_cam;

		private Label[] label_led;

		private Label[] label_cam;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		private IContainer components;

		private Panel panel5;

		private Button button_led;

		private Button button_light;

		private Label label4;

		private Panel panel2;

		private Label label3;

		private Panel panel4;

		private Label label2;

		private Panel panel3;

		public event void_Func_int update_mark_pricise_info;

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

		public Form_MarkCamParaUSR3(int fn, USR_DATA usr, USR3_DATA usr3, int markno)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR3 = usr3;
			USR_INIT = MainForm0.USR_INIT;
			mMarkNo = markno;
			initLanguageTable();
			updateLanguage(USR_INIT.mLanguage);
			update_light_led_buttion();
			this.label4.Text = "Mark-" + (markno + 1) + "光源相机参数";
			trackBar_led = new TrackBar[4];
			trackBar_cam = new TrackBar[4];
			label_led = new Label[4];
			label_cam = new Label[4];
			for (int i = 0; i < 4; i++)
			{
				Label label = new Label();
				panel3.Controls.Add(label);
				label.Location = new Point(4, 4 + i * 25);
				label.Size = new Size(60, 25);
				label.Text = STR.MARK_LED_PARA_STR[i][USR_INIT.mLanguage];
				label.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], label.Font.Style);
				TrackBar trackBar = new TrackBar();
				panel3.Controls.Add(trackBar);
				trackBar.Location = new Point(64, 4 + i * 25);
				trackBar.Size = new Size(220, 25);
				trackBar.Minimum = 0;
				trackBar.Maximum = 840;
				trackBar.Value = USR3.mMarkPara[markno].mPara.mParaLed[i];
				trackBar.Orientation = Orientation.Horizontal;
				trackBar.TickFrequency = 50;
				trackBar.BringToFront();
				trackBar.Tag = i;
				trackBar.ValueChanged += trackbar_led_valueChanged;
				trackBar_led[i] = trackBar;
				Label label2 = new Label();
				panel3.Controls.Add(label2);
				label2.Location = new Point(284, 4 + i * 25);
				label2.Size = new Size(60, 25);
				label2.Text = USR3.mMarkPara[markno].mPara.mParaLed[i].ToString();
				label_led[i] = label2;
			}
			for (int j = 0; j < 4; j++)
			{
				Label label3 = new Label();
				panel4.Controls.Add(label3);
				label3.Location = new Point(4, 4 + j * 25);
				label3.Size = new Size(60, 25);
				label3.Text = STR.MARK_CAM_PARA_STR[j][USR_INIT.mLanguage];
				label3.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label3.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], label3.Font.Style);
				TrackBar trackBar2 = new TrackBar();
				panel4.Controls.Add(trackBar2);
				trackBar2.Location = new Point(64, 4 + j * 25);
				trackBar2.Size = new Size(220, 25);
				trackBar2.Minimum = 0;
				trackBar2.Maximum = 255;
				trackBar2.Value = USR3.mMarkPara[markno].mPara.mParaCam[j];
				trackBar2.Orientation = Orientation.Horizontal;
				trackBar2.TickFrequency = 50;
				trackBar2.BringToFront();
				trackBar2.Tag = j;
				trackBar2.ValueChanged += trackbar_cam_valueChanged;
				trackBar_cam[j] = trackBar2;
				Label label4 = new Label();
				panel4.Controls.Add(label4);
				label4.Location = new Point(284, 4 + j * 25);
				label4.Size = new Size(60, 25);
				label4.Text = USR3.mMarkPara[markno].mPara.mParaCam[j].ToString();
				label_cam[j] = label4;
			}
			sync_markpara_to_usr();
		}

		private void Form_MarkCamParaUSR3_Load(object sender, EventArgs e)
		{
			MainForm0.change_button_MarkCamPara_Text();
		}

		public void update_light_led_buttion()
		{
			string[] array = new string[3] { "照明已", "照明已", "Light " };
			string[] array2 = new string[3] { "光源已", "光源已", "Led " };
			string[] array3 = new string[3] { "开", "开", "On" };
			string[] array4 = new string[3] { "关", "关", "Off" };
			button_light.BackColor = (USR3.mMarkPara[mMarkNo].mPara.mLightOn ? Color.LightSalmon : Color.Gray);
			button_led.BackColor = (USR3.mMarkPara[mMarkNo].mPara.mLedOn ? Color.LightSalmon : Color.Gray);
			button_light.Text = array[USR_INIT.mLanguage] + (USR3.mMarkPara[mMarkNo].mPara.mLightOn ? array3[USR_INIT.mLanguage] : array4[USR_INIT.mLanguage]);
			button_led.Text = array2[USR_INIT.mLanguage] + (USR3.mMarkPara[mMarkNo].mPara.mLedOn ? array3[USR_INIT.mLanguage] : array4[USR_INIT.mLanguage]);
		}

		public void sync_markpara_to_usr()
		{
			USR.mMarkCamParaIndex = 8 + mMarkNo;
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn = USR3.mMarkPara[mMarkNo].mPara.mLightOn;
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn = USR3.mMarkPara[mMarkNo].mPara.mLedOn;
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[0] = USR3.mMarkPara[mMarkNo].mPara.mParaLed[0];
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[1] = USR3.mMarkPara[mMarkNo].mPara.mParaLed[1];
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[2] = USR3.mMarkPara[mMarkNo].mPara.mParaLed[2];
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[3] = USR3.mMarkPara[mMarkNo].mPara.mParaLed[3];
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[0] = USR3.mMarkPara[mMarkNo].mPara.mParaCam[0];
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[1] = USR3.mMarkPara[mMarkNo].mPara.mParaCam[1];
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[2] = USR3.mMarkPara[mMarkNo].mPara.mParaCam[2];
			USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[3] = USR3.mMarkPara[mMarkNo].mPara.mParaCam[3];
		}

		public void trackbar_led_valueChanged(object sender, EventArgs e)
		{
			if (USR != null && trackBar_led != null && label_led != null && trackBar_cam != null && label_cam != null)
			{
				int num = (int)((TrackBar)sender).Tag;
				USR3.mMarkPara[mMarkNo].mPara.mParaLed[num] = trackBar_led[num].Value;
				label_led[num].Text = USR3.mMarkPara[mMarkNo].mPara.mParaLed[num].ToString();
				switch (num)
				{
				case 0:
					MainForm0.mark_lightlevel_set(mFn, num, USR3.mMarkPara[mMarkNo].mPara.mParaLed[num]);
					MainForm0.mark_light_on(mFn, USR3.mMarkPara[mMarkNo].mPara.mLightOn);
					break;
				case 1:
					MainForm0.mark_lightlevel_set(mFn, num, USR3.mMarkPara[mMarkNo].mPara.mParaLed[num]);
					MainForm0.mark_led_on(mFn, USR3.mMarkPara[mMarkNo].mPara.mLedOn);
					break;
				}
				if (this.update_mark_pricise_info != null)
				{
					this.update_mark_pricise_info(mMarkNo);
				}
				sync_markpara_to_usr();
			}
		}

		public void trackbar_cam_valueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				int num = (int)((TrackBar)sender).Tag;
				USR3.mMarkPara[mMarkNo].mPara.mParaCam[num] = trackBar_cam[num].Value;
				label_cam[num].Text = USR3.mMarkPara[mMarkNo].mPara.mParaCam[num].ToString();
				MainForm0.set_camera_parameter(HW.mMarkCamItem[mFn].index[0], USR3.mMarkPara[mMarkNo].mPara.mParaCam);
				if (this.update_mark_pricise_info != null)
				{
					this.update_mark_pricise_info(mMarkNo);
				}
				sync_markpara_to_usr();
			}
		}

		private void button_light_Click(object sender, EventArgs e)
		{
			USR3.mMarkPara[mMarkNo].mPara.mLightOn = !USR3.mMarkPara[mMarkNo].mPara.mLightOn;
			MainForm0.mark_light_on(mFn, USR3.mMarkPara[mMarkNo].mPara.mLightOn);
			update_light_led_buttion();
			if (this.update_mark_pricise_info != null)
			{
				this.update_mark_pricise_info(mMarkNo);
			}
			sync_markpara_to_usr();
		}

		private void button_led_Click(object sender, EventArgs e)
		{
			USR3.mMarkPara[mMarkNo].mPara.mLedOn = !USR3.mMarkPara[mMarkNo].mPara.mLedOn;
			MainForm0.mark_led_on(mFn, USR3.mMarkPara[mMarkNo].mPara.mLedOn);
			update_light_led_buttion();
			if (this.update_mark_pricise_info != null)
			{
				this.update_mark_pricise_info(mMarkNo);
			}
			sync_markpara_to_usr();
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
			panel5 = new System.Windows.Forms.Panel();
			button_led = new System.Windows.Forms.Button();
			button_light = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			panel5.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel5.Controls.Add(button_led);
			panel5.Controls.Add(button_light);
			panel5.Controls.Add(label4);
			panel5.Controls.Add(panel2);
			panel5.Location = new System.Drawing.Point(2, 1);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(351, 332);
			panel5.TabIndex = 5;
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
			label4.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.Location = new System.Drawing.Point(8, -4);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(343, 34);
			label4.TabIndex = 3;
			label4.Text = "label4";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.MistyRose;
			base.ClientSize = new System.Drawing.Size(356, 329);
			base.Controls.Add(panel5);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_MarkCamParaUSR3";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Load += new System.EventHandler(Form_MarkCamParaUSR3_Load);
			panel5.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
