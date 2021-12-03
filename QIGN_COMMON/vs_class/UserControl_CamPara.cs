using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_CamPara : UserControl
	{
		private int mFn;

		private USR_DATA USR;

		private USR2_DATA USR2;

		private USR_INIT_DATA USR_INIT;

		private Color[] FRAME_COLOR = new Color[2]
		{
			Color.CadetBlue,
			Color.RosyBrown
		};

		private NumericUpDown[] numericUpDown_fcam_led_v;

		private TrackBar[] trackBar_fcam_led_v;

		private TrackBar[] trackBar_fcam_para_v;

		private Label[] label_fcam_para_v;

		private RadioButton[] radioButton_fcamnz;

		public Label[] lb_fcam_zname;

		public Label[] lb_fcam_scanR;

		public Label[] lb_fcam_pno;

		public Label[] lb_hcam_zname;

		public Label[] lb_hcam_scanR;

		public Label[] lb_hcam_pno;

		public Label[] lb_hcam_delay;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		private IContainer components;

		private Panel panel_hcam_a;

		private NumericUpDown numericUpDown_hcam_stilldelay;

		private Label label9;

		private Label label_hcam_lightlevel_v;

		private Label label6;

		private Panel panel_hcam_light;

		private TrackBar trackBar_hcam_lightlevel_v;

		private Panel panel_for_usr;

		private CnButton button_fcampara_reset;

		private Panel panel_fcam_nz;

		private Panel panel_fcampara;

		private Label label_fcampara;

		private NumericUpDown numericUpDown_hCamPricise_tryNum;

		private Panel panel_usr2_hcambihuan;

		private NumericUpDown numericUpDown_hCamPricise_delta_XY;

		private NumericUpDown numericUpDown_hCamPricise_delta_A;

		private Label label12;

		private Label label11;

		private Label label10;

		private Label label_hcam_notice;

		private Label label_title;

		private NumericUpDown numericUpDown_usr_fcamstilldelay;

		private Panel panel_usr2para_h;

		private CheckBox checkBox_changelight_all;

		private NumericUpDown numericUpDown_microstep;

		private TabPage tabPage1;

		private CheckBox checkBox_usr_changecampara;

		private Label label_microstep;

		private Panel panel_usr_a;

		private Label label4;

		private Label label_notice;

		private Panel panel_for_usr2;

		private CnButton button_fcam_autopno;

		private NumericUpDown numericUpDown_usr2_fcamstilldelay;

		private Panel panel_usr2para;

		private Label label5;

		private Panel panel_fcam_led;

		private TabControl tabControl1;

		private TabPage tabPage2;

		private Panel panel_usr2_hcampara;

		private CnButton button_close;

		private CnButton button_saveas_default;

		private Label label1;

		private Label label2;

		public UserControl_CamPara()
		{
			InitializeComponent();
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
				ctrl = button_saveas_default,
				str = new string[3] { "保存为默认光源", "保存為默認光源", "Save as Default Led-V" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage1,
				str = STR.FAST_CAM
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage2,
				str = STR.HIGH_CAM
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_usr_changecampara,
				str = new string[3] { "修改相机参数", "修改相机参数", "Modify Base Para" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = STR.STILLDELAY
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label9,
				str = STR.STILLDELAY
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = STR.STILLDELAY
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_microstep,
				str = new string[3] { "微调步长", "微调步长", "Micro Step" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "高清相机视觉亮度", "高清相机视觉亮度", "High Camera Led Level" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_notice,
				str = new string[3] { "光源影响所有元件识别，谨慎修改！", "光源影响所有元件识别，谨慎修改！！", "Modification will impact all chips visual!" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_title,
				str = new string[3] { "", "", "" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label10,
				str = new string[3] { "精准闭环角度容差", "精准闭环角度容差", "Pricise mode angle delta" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "精准闭环XY容差", "精准闭环XY容差", "Pricise Mode XY delta" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label12,
				str = new string[3] { "精准闭环重试次数", "精准闭环重试次数", "Pricise mode retry times" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_fcampara_reset,
				str = new string[3] { "恢复默认值", "恢复默认值", "Reset Factory" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fcampara,
				str = new string[3] { "", "", "" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabControl1,
				str = new string[3] { "", "", "" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_changelight_all,
				str = new string[3] { "光源整体调节", "光源整体调节", "Adjust Led All" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_hcam_notice,
				str = new string[3] { "提示：修改光源会影响所有料站/料盘/振动飞达的快速相机识别，请谨慎！", "提示：修改光源会影响所有料站/料盘/振动飞达的快速相机识别，请谨慎！", "Notice: Change light will impact visual recognition of all chips!" }
			});
		}

		public UserControl_CamPara(int fn, USR_DATA usr, USR2_DATA usr2)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR2 = usr2;
			USR_INIT = MainForm0.USR_INIT;
			initLanguageTable();
			updateLanguage(USR_INIT.mLanguage);
			string text = ((USR_INIT.mLanguage == 2) ? "Camera Para - Debug" : "相机参数-设备调试");
			string text2 = ((USR_INIT.mLanguage == 2) ? "Camera Para - Project" : "相机参数-工程数据");
			label_title.Text = ((USR2 == null) ? text : text2);
			button_saveas_default.Visible = USR2 != null;
			tabPage1.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], tabPage1.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
			tabPage2.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], tabPage2.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
			base.Size = new Size(558, 418);
			tabPage1.Controls.Add(panel_for_usr);
			panel_for_usr.Location = panel_for_usr2.Location;
			checkBox_usr_changecampara.Visible = (panel_hcam_a.Visible = (panel_for_usr.Visible = USR2 == null));
			label_notice.Visible = (panel_for_usr2.Visible = USR2 != null);
			label_hcam_notice.Visible = (panel_usr2_hcambihuan.Visible = (panel_usr2_hcampara.Visible = USR2 != null));
			panel_usr2_hcambihuan.BackColor = (panel_usr2_hcampara.BackColor = (panel_for_usr2.BackColor = (panel_hcam_light.BackColor = (panel_fcam_led.BackColor = (BackColor = ((USR2 == null) ? FRAME_COLOR[0] : FRAME_COLOR[1]))))));
			tabPage2.Controls.Add(panel_usr2_hcambihuan);
			panel_usr2_hcambihuan.Location = new Point(panel_hcam_a.Location.X - (panel_usr2_hcambihuan.Size.Width - panel_hcam_a.Size.Width), panel_hcam_a.Location.Y);
			if (USR2 != null)
			{
				panel_hcam_light.Size = new Size(panel_hcam_light.Size.Width - (panel_usr2_hcambihuan.Size.Width - panel_hcam_a.Size.Width), panel_hcam_light.Size.Height);
			}
			panel_for_usr.Visible = false;
			checkBox_usr_changecampara.Checked = false;
			numericUpDown_fcam_led_v = new NumericUpDown[HW.mFastLedNum];
			trackBar_fcam_led_v = new TrackBar[HW.mFastLedNum];
			int num = panel_fcam_led.Width / HW.mFastLedNum;
			for (int i = 0; i < HW.mFastLedNum; i++)
			{
				int num2 = ((USR2 == null) ? USR.mFastCamLightLevel[i] : USR2.mFastCamLightLevel[0][i]);
				NumericUpDown numericUpDown = new NumericUpDown();
				panel_fcam_led.Controls.Add(numericUpDown);
				numericUpDown.Size = new Size(40, 44);
				numericUpDown.AutoSize = false;
				numericUpDown.Location = new Point(5 + i * num, 5);
				numericUpDown.Minimum = 1m;
				numericUpDown.Maximum = 840m;
				numericUpDown.Value = ((num2 < 1) ? 1 : ((num2 > 840) ? 840 : num2));
				numericUpDown.Increment = 5m;
				numericUpDown.Tag = i;
				numericUpDown.BackColor = Color.LightSalmon;
				numericUpDown.BorderStyle = BorderStyle.None;
				numericUpDown.ValueChanged += numericUpDown_fcam_led_ValueChanged;
				numericUpDown.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				numericUpDown_fcam_led_v[i] = numericUpDown;
				TrackBar trackBar = new TrackBar();
				panel_fcam_led.Controls.Add(trackBar);
				trackBar.Orientation = Orientation.Vertical;
				trackBar.Size = new Size(40, 119);
				trackBar.Location = new Point(10 + i * num, 21);
				trackBar.Minimum = 1;
				trackBar.Maximum = 840;
				trackBar.TickFrequency = 50;
				trackBar.TickStyle = TickStyle.BottomRight;
				trackBar.Tag = i;
				trackBar.Value = ((num2 < 1) ? 1 : ((num2 > 840) ? 840 : num2));
				trackBar.Scroll += tbar_fcamled_Scroll;
				trackBar_fcam_led_v[i] = trackBar;
				Label label = new Label();
				panel_fcam_led.Controls.Add(label);
				label.Size = new Size(55, 30);
				label.AutoSize = false;
				label.Location = new Point(1 + i * num - (i + 1) / 10 * 2, 138);
				label.Text = STR.LIGHT_a[USR_INIT.mLanguage] + "-" + (i + 1);
				if (HW.mZnNum[mFn] == 6)
				{
					label.Text = STR.LIGHT_a6[USR_INIT.mLanguage] + (i + 1);
				}
				label.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				trackBar.BringToFront();
				numericUpDown.BringToFront();
				label.BringToFront();
			}
			if (USR.mfcam_scanr == 0)
			{
				USR.mfcam_scanr = 160;
			}
			if (USR.mfcam_stilldelay == 0)
			{
				USR.mfcam_stilldelay = 100;
			}
			numericUpDown_usr_fcamstilldelay.Value = USR.mfcam_stilldelay;
			panel_usr_a.Visible = USR2 == null;
			radioButton_fcamnz = new RadioButton[HW.mZnNum[mFn]];
			for (int j = 0; j < HW.mZnNum[mFn]; j++)
			{
				RadioButton radioButton = new RadioButton();
				panel_fcam_nz.Controls.Add(radioButton);
				radioButton.Size = new Size(120, 24);
				radioButton.Location = new Point(j / 4 * 120, j % 4 * 22);
				radioButton.AutoSize = false;
				radioButton.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 11f + DEF.FSIZE_2020[USR_INIT.mLanguage], (j == MainForm0.mZn[mFn]) ? FontStyle.Bold : FontStyle.Regular);
				radioButton.Tag = j;
				radioButton.Text = STR.FAST_CAM[USR_INIT.mLanguage] + "-" + (j + 1);
				radioButton.Checked = ((j == MainForm0.mZn[mFn]) ? true : false);
				radioButton.CheckedChanged += radio_fcamnz_CheckedChanged;
				radioButton_fcamnz[j] = radioButton;
			}
			panel_fcam_nz.Visible = USR2 == null;
			label_fcampara.Text = STR.FAST_CAM[USR_INIT.mLanguage] + "-" + (MainForm0.mZn[mFn] + 1);
			label_fcampara.Visible = USR2 == null;
			panel_fcampara.Visible = USR2 == null;
			button_fcampara_reset.Visible = USR2 == null;
			if (USR.mfcam_para == null)
			{
				USR.mfcam_para = new int[8][];
				for (int k = 0; k < 8; k++)
				{
					USR.mfcam_para[k] = new int[6];
					for (int l = 0; l < 6; l++)
					{
						USR.mfcam_para[k][l] = DEF.FCAM_PARA_DEFAULT[l];
					}
				}
			}
			trackBar_fcam_para_v = new TrackBar[4];
			label_fcam_para_v = new Label[4];
			int num3 = 5;
			for (int m = 0; m < 4; m++)
			{
				Label label2 = new Label();
				panel_fcampara.Controls.Add(label2);
				label2.Location = new Point(4 + num3, 24 + m * 22 + num3);
				label2.Size = new Size(60, 25);
				label2.Text = STR.MARK_CAM_PARA_STR[m][USR_INIT.mLanguage];
				label2.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				label2.BringToFront();
				TrackBar trackBar2 = new TrackBar();
				panel_fcampara.Controls.Add(trackBar2);
				trackBar2.Location = new Point(64 + num3, 24 + m * 22 + num3);
				trackBar2.Size = new Size(180, 25);
				trackBar2.Minimum = 0;
				trackBar2.Maximum = 255;
				trackBar2.Value = USR.mfcam_para[MainForm0.mZn[mFn]][m];
				trackBar2.Orientation = Orientation.Horizontal;
				trackBar2.TickFrequency = 50;
				trackBar2.BringToFront();
				trackBar2.Tag = m;
				trackBar2.ValueChanged += trackBar_fcam_para_valueChanged;
				trackBar2.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				trackBar_fcam_para_v[m] = trackBar2;
				Label label3 = new Label();
				panel_fcampara.Controls.Add(label3);
				label3.Location = new Point(244 + num3, 24 + m * 22 + num3);
				label3.Size = new Size(60, 25);
				label3.Text = USR.mfcam_para[MainForm0.mZn[mFn]][m].ToString();
				label3.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				label3.BringToFront();
				label_fcam_para_v[m] = label3;
			}
			trackBar_hcam_lightlevel_v.Value = ((USR2 == null) ? USR.mHighCamLightLevel : USR2.mHighCamLightLevel[0]);
			label_hcam_lightlevel_v.Text = trackBar_hcam_lightlevel_v.Value.ToString();
			panel_hcam_a.Visible = USR2 == null;
			numericUpDown_hcam_stilldelay.Value = USR.mhcam_stilldelay;
			if (USR2 != null)
			{
				lb_fcam_scanR = new Label[8];
				for (int n = 0; n < 8; n++)
				{
					lb_fcam_scanR[n] = new Label();
				}
				lb_fcam_pno = new Label[8];
				for (int num4 = 0; num4 < 8; num4++)
				{
					lb_fcam_pno[num4] = new Label();
				}
				lb_fcam_zname = new Label[8];
				for (int num5 = 0; num5 < 8; num5++)
				{
					lb_fcam_zname[num5] = new Label();
				}
				int num6 = 76;
				int num7 = 45;
				int num8 = 25;
				TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
				panel_usr2para.Controls.Clear();
				panel_usr2para.Controls.Add(tableLayoutPanel);
				tableLayoutPanel.Controls.Clear();
				tableLayoutPanel.RowCount = 3;
				tableLayoutPanel.ColumnCount = 9;
				tableLayoutPanel.Location = new Point(0, 0);
				tableLayoutPanel.Size = new Size(num7 * 8 + num6 + 78 + 5, num8 * 3 + 15);
				for (int num9 = 0; num9 < tableLayoutPanel.RowCount; num9++)
				{
					tableLayoutPanel.RowStyles.Add(new RowStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
				for (int num10 = 0; num10 < tableLayoutPanel.ColumnCount; num10++)
				{
					if (num10 == 0)
					{
						tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
						{
							SizeType = SizeType.AutoSize
						});
					}
					else
					{
						tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
						{
							SizeType = SizeType.AutoSize
						});
					}
				}
				tableLayoutPanel.Refresh();
				for (int num11 = 0; num11 < tableLayoutPanel.ColumnStyles.Count; num11++)
				{
					if (num11 > 0)
					{
						tableLayoutPanel.Controls.Add(lb_fcam_zname[num11 - 1], num11, 0);
						lb_fcam_zname[num11 - 1].Location = new Point(0, 0);
						lb_fcam_zname[num11 - 1].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + num11;
						lb_fcam_zname[num11 - 1].Size = new Size(num7, num8);
						lb_fcam_zname[num11 - 1].AutoSize = false;
						lb_fcam_zname[num11 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
						lb_fcam_zname[num11 - 1].Anchor = AnchorStyles.None;
						lb_fcam_zname[num11 - 1].TextAlign = ContentAlignment.MiddleLeft;
						lb_fcam_zname[num11 - 1].Tag = num11 - 1;
					}
					if (num11 == 0)
					{
						Label label4 = new Label();
						tableLayoutPanel.Controls.Add(label4, num11, 1);
						label4.Text = STR.SCAN_R[USR_INIT.mLanguage];
						label4.Size = new Size(num6, num8);
						label4.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
						label4.Anchor = AnchorStyles.None;
						label4.TextAlign = ContentAlignment.MiddleLeft;
					}
					else
					{
						tableLayoutPanel.Controls.Add(lb_fcam_scanR[num11 - 1], num11, 1);
						lb_fcam_scanR[num11 - 1].Text = USR2.mFastCamScanRange[0][num11 - 1].ToString();
						lb_fcam_scanR[num11 - 1].Size = new Size(num7, num8);
						lb_fcam_scanR[num11 - 1].AutoSize = false;
						lb_fcam_scanR[num11 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
						lb_fcam_scanR[num11 - 1].Anchor = AnchorStyles.None;
						lb_fcam_scanR[num11 - 1].TextAlign = ContentAlignment.MiddleLeft;
						lb_fcam_scanR[num11 - 1].Tag = num11 - 1;
						lb_fcam_scanR[num11 - 1].DoubleClick += label_fcam_scanR_DoubleClick;
						lb_fcam_scanR[num11 - 1].BackColor = Color.White;
						lb_fcam_scanR[num11 - 1].BorderStyle = BorderStyle.None;
					}
					if (num11 == 0)
					{
						Label label5 = new Label();
						tableLayoutPanel.Controls.Add(label5, num11, 2);
						label5.Text = STR.PNO[USR_INIT.mLanguage];
						label5.Size = new Size(num6, num8);
						label5.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
						label5.Anchor = AnchorStyles.None;
						label5.TextAlign = ContentAlignment.MiddleLeft;
					}
					else
					{
						tableLayoutPanel.Controls.Add(lb_fcam_pno[num11 - 1], num11, 2);
						lb_fcam_pno[num11 - 1].Text = USR2.mFastCamMinValidPixel[0][num11 - 1].ToString();
						lb_fcam_pno[num11 - 1].Size = new Size(num7, num8);
						lb_fcam_pno[num11 - 1].AutoSize = false;
						lb_fcam_pno[num11 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
						lb_fcam_pno[num11 - 1].Anchor = AnchorStyles.None;
						lb_fcam_pno[num11 - 1].TextAlign = ContentAlignment.MiddleLeft;
						lb_fcam_pno[num11 - 1].Tag = num11 - 1;
						lb_fcam_pno[num11 - 1].DoubleClick += label_fcam_pno_DoubleClick;
						lb_fcam_pno[num11 - 1].BackColor = Color.White;
						lb_fcam_pno[num11 - 1].BorderStyle = BorderStyle.None;
					}
				}
				tableLayoutPanel.BackColor = Color.White;
				tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
				tableLayoutPanel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel, true, null);
				tableLayoutPanel.SuspendLayout();
				numericUpDown_usr2_fcamstilldelay.Value = USR2.mFastCamStillDelay[0];
			}
			if (USR2 == null)
			{
				return;
			}
			lb_hcam_scanR = new Label[8];
			for (int num12 = 0; num12 < 8; num12++)
			{
				lb_hcam_scanR[num12] = new Label();
			}
			lb_hcam_pno = new Label[8];
			for (int num13 = 0; num13 < 8; num13++)
			{
				lb_hcam_pno[num13] = new Label();
			}
			lb_hcam_zname = new Label[8];
			for (int num14 = 0; num14 < 8; num14++)
			{
				lb_hcam_zname[num14] = new Label();
			}
			lb_hcam_delay = new Label[8];
			for (int num15 = 0; num15 < 8; num15++)
			{
				lb_hcam_delay[num15] = new Label();
			}
			int num16 = 76;
			int num17 = 45;
			int num18 = 25;
			TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
			panel_usr2para_h.Controls.Clear();
			panel_usr2para_h.Controls.Add(tableLayoutPanel2);
			tableLayoutPanel2.Controls.Clear();
			tableLayoutPanel2.RowCount = 4;
			tableLayoutPanel2.ColumnCount = 9;
			tableLayoutPanel2.Location = new Point(0, 0);
			tableLayoutPanel2.Size = new Size(num17 * 8 + num16 + 78 + 5, num18 * 4 + 15);
			for (int num19 = 0; num19 < tableLayoutPanel2.RowCount; num19++)
			{
				tableLayoutPanel2.RowStyles.Add(new RowStyle
				{
					SizeType = SizeType.AutoSize
				});
			}
			for (int num20 = 0; num20 < tableLayoutPanel2.ColumnCount; num20++)
			{
				if (num20 == 0)
				{
					tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
				else
				{
					tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle
					{
						SizeType = SizeType.AutoSize
					});
				}
			}
			tableLayoutPanel2.Refresh();
			for (int num21 = 0; num21 < tableLayoutPanel2.ColumnStyles.Count; num21++)
			{
				if (num21 > 0)
				{
					tableLayoutPanel2.Controls.Add(lb_hcam_zname[num21 - 1], num21, 0);
					lb_hcam_zname[num21 - 1].Location = new Point(0, 0);
					lb_hcam_zname[num21 - 1].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + num21;
					lb_hcam_zname[num21 - 1].Size = new Size(num17, num18);
					lb_hcam_zname[num21 - 1].AutoSize = false;
					lb_hcam_zname[num21 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
					lb_hcam_zname[num21 - 1].Anchor = AnchorStyles.None;
					lb_hcam_zname[num21 - 1].TextAlign = ContentAlignment.MiddleLeft;
					lb_hcam_zname[num21 - 1].Tag = num21 - 1;
				}
				if (num21 == 0)
				{
					Label label6 = new Label();
					tableLayoutPanel2.Controls.Add(label6, num21, 1);
					label6.Text = STR.SCAN_R[USR_INIT.mLanguage];
					label6.Size = new Size(num16, num18);
					label6.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
					label6.Anchor = AnchorStyles.None;
					label6.TextAlign = ContentAlignment.MiddleLeft;
				}
				else
				{
					tableLayoutPanel2.Controls.Add(lb_hcam_scanR[num21 - 1], num21, 1);
					lb_hcam_scanR[num21 - 1].Text = USR2.mHighCamScanRange[0][num21 - 1].ToString();
					lb_hcam_scanR[num21 - 1].Size = new Size(num17, num18);
					lb_hcam_scanR[num21 - 1].AutoSize = false;
					lb_hcam_scanR[num21 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
					lb_hcam_scanR[num21 - 1].Anchor = AnchorStyles.None;
					lb_hcam_scanR[num21 - 1].TextAlign = ContentAlignment.MiddleLeft;
					lb_hcam_scanR[num21 - 1].Tag = num21 - 1;
					lb_hcam_scanR[num21 - 1].DoubleClick += label_hcam_scanR_DoubleClick;
					lb_hcam_scanR[num21 - 1].BackColor = Color.White;
					lb_hcam_scanR[num21 - 1].BorderStyle = BorderStyle.None;
				}
				if (num21 == 0)
				{
					Label label7 = new Label();
					tableLayoutPanel2.Controls.Add(label7, num21, 2);
					label7.Text = STR.PNO[USR_INIT.mLanguage];
					label7.Size = new Size(num16, num18);
					label7.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
					label7.Anchor = AnchorStyles.None;
					label7.TextAlign = ContentAlignment.MiddleLeft;
				}
				else
				{
					tableLayoutPanel2.Controls.Add(lb_hcam_pno[num21 - 1], num21, 2);
					lb_hcam_pno[num21 - 1].Text = USR2.mHighCamMinValidPixel[0][num21 - 1].ToString();
					lb_hcam_pno[num21 - 1].Size = new Size(num17, num18);
					lb_hcam_pno[num21 - 1].AutoSize = false;
					lb_hcam_pno[num21 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
					lb_hcam_pno[num21 - 1].Anchor = AnchorStyles.None;
					lb_hcam_pno[num21 - 1].TextAlign = ContentAlignment.MiddleLeft;
					lb_hcam_pno[num21 - 1].Tag = num21 - 1;
					lb_hcam_pno[num21 - 1].DoubleClick += label_hcam_pno_DoubleClick;
					lb_hcam_pno[num21 - 1].BackColor = Color.White;
					lb_hcam_pno[num21 - 1].BorderStyle = BorderStyle.None;
				}
				if (num21 == 0)
				{
					Label label8 = new Label();
					tableLayoutPanel2.Controls.Add(label8, num21, 3);
					label8.Text = STR.STILLDELAY[USR_INIT.mLanguage];
					label8.Size = new Size(num16, num18);
					label8.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
					label8.Anchor = AnchorStyles.None;
					label8.TextAlign = ContentAlignment.MiddleLeft;
				}
				else
				{
					tableLayoutPanel2.Controls.Add(lb_hcam_delay[num21 - 1], num21, 3);
					lb_hcam_delay[num21 - 1].Text = USR2.mHighCamStillDelay[0][num21 - 1].ToString();
					lb_hcam_delay[num21 - 1].Size = new Size(num17, 25);
					lb_hcam_delay[num21 - 1].AutoSize = false;
					lb_hcam_delay[num21 - 1].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f, FontStyle.Regular);
					lb_hcam_delay[num21 - 1].Anchor = AnchorStyles.None;
					lb_hcam_delay[num21 - 1].TextAlign = ContentAlignment.MiddleLeft;
					lb_hcam_delay[num21 - 1].Tag = num21 - 1;
					lb_hcam_delay[num21 - 1].DoubleClick += label_hcam_stilldelay_DoubleClick;
					lb_hcam_delay[num21 - 1].BackColor = Color.White;
					lb_hcam_delay[num21 - 1].BorderStyle = BorderStyle.None;
				}
			}
			tableLayoutPanel2.BackColor = Color.White;
			tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
			tableLayoutPanel2.SuspendLayout();
			numericUpDown_hCamPricise_delta_A.Value = (decimal)USR2.mHCamPrisice_DeltaA;
			numericUpDown_hCamPricise_delta_XY.Value = (decimal)USR2.mHCamPrisice_DeltaXY;
			numericUpDown_hCamPricise_tryNum.Value = USR2.mHCamPrisice_TryNum;
		}

		public void sel_pagenum(int arg)
		{
			tabControl1.SelectedIndex = arg;
		}

		public void numericUpDown_fcam_led_ValueChanged(object sender, EventArgs e)
		{
			int num = (int)((NumericUpDown)sender).Tag;
			int num2 = (int)((NumericUpDown)sender).Value;
			trackBar_fcam_led_v[num].Value = num2;
			MainForm0.fcam_lightlevel_set(mFn, num, num2);
			int num3 = 0;
			if (USR2 != null)
			{
				num3 = num2 - USR2.mFastCamLightLevel[0][num];
				USR2.mFastCamLightLevel[0][num] = num2;
			}
			else
			{
				num3 = num2 - USR.mFastCamLightLevel[num];
				USR.mFastCamLightLevel[num] = num2;
			}
			if (!checkBox_changelight_all.Checked)
			{
				return;
			}
			for (int i = 0; i < HW.mFastLedNum; i++)
			{
				if (i == num)
				{
					continue;
				}
				if (USR2 != null)
				{
					USR2.mFastCamLightLevel[0][i] += num3;
					if (USR2.mFastCamLightLevel[0][i] < 1)
					{
						USR2.mFastCamLightLevel[0][i] = 1;
					}
					else if (USR2.mFastCamLightLevel[0][i] > 840)
					{
						USR2.mFastCamLightLevel[0][i] = 840;
					}
					num2 = USR2.mFastCamLightLevel[0][i];
				}
				else
				{
					USR.mFastCamLightLevel[i] += num3;
					if (USR.mFastCamLightLevel[i] < 1)
					{
						USR.mFastCamLightLevel[i] = 1;
					}
					else if (USR.mFastCamLightLevel[i] > 840)
					{
						USR.mFastCamLightLevel[i] = 840;
					}
					num2 = USR.mFastCamLightLevel[i];
				}
				numericUpDown_fcam_led_v[i].Value = num2;
				trackBar_fcam_led_v[i].Value = num2;
				MainForm0.fcam_lightlevel_set(mFn, i, num2);
			}
		}

		private void tbar_fcamled_Scroll(object sender, EventArgs e)
		{
			int num = (int)((TrackBar)sender).Tag;
			int value = ((TrackBar)sender).Value;
			numericUpDown_fcam_led_v[num].Value = value;
			MainForm0.fcam_lightlevel_set(mFn, num, value);
			int num2 = 0;
			if (USR2 != null)
			{
				num2 = value - USR2.mFastCamLightLevel[0][num];
				USR2.mFastCamLightLevel[0][num] = value;
			}
			else
			{
				num2 = value - USR.mFastCamLightLevel[num];
				USR.mFastCamLightLevel[num] = value;
			}
			if (!checkBox_changelight_all.Checked)
			{
				return;
			}
			for (int i = 0; i < HW.mFastLedNum; i++)
			{
				if (i == num)
				{
					continue;
				}
				if (USR2 != null)
				{
					USR2.mFastCamLightLevel[0][i] += num2;
					if (USR2.mFastCamLightLevel[0][i] < 1)
					{
						USR2.mFastCamLightLevel[0][i] = 1;
					}
					else if (USR2.mFastCamLightLevel[0][i] > 840)
					{
						USR2.mFastCamLightLevel[0][i] = 840;
					}
					value = USR2.mFastCamLightLevel[0][i];
				}
				else
				{
					USR.mFastCamLightLevel[i] += num2;
					if (USR.mFastCamLightLevel[i] < 1)
					{
						USR.mFastCamLightLevel[i] = 1;
					}
					else if (USR.mFastCamLightLevel[i] > 840)
					{
						USR.mFastCamLightLevel[i] = 840;
					}
					value = USR.mFastCamLightLevel[i];
				}
				numericUpDown_fcam_led_v[i].Value = value;
				trackBar_fcam_led_v[i].Value = value;
				MainForm0.fcam_lightlevel_set(mFn, i, value);
			}
		}

		private void numericUpDown_usr_fcamstilldelay_ValueChanged(object sender, EventArgs e)
		{
			USR.mfcam_stilldelay = (int)numericUpDown_usr_fcamstilldelay.Value;
		}

		public void radio_fcamnz_CheckedChanged(object sender, EventArgs e)
		{
			int num = (int)((RadioButton)sender).Tag;
			if (USR.mfcam_para == null)
			{
				USR.mfcam_para = new int[8][];
				for (int i = 0; i < 8; i++)
				{
					USR.mfcam_para[i] = new int[6];
					for (int j = 0; j < 6; j++)
					{
						USR.mfcam_para[i][j] = DEF.FCAM_PARA_DEFAULT[j];
					}
				}
			}
			if (radioButton_fcamnz[num].Checked)
			{
				MainForm0.radiobt_zn[mFn][num].Checked = radioButton_fcamnz[num].Checked;
				for (int k = 0; k < 4; k++)
				{
					trackBar_fcam_para_v[k].Value = USR.mfcam_para[num][k];
					label_fcam_para_v[k].Text = USR.mfcam_para[num][k].ToString();
				}
				radioButton_fcamnz[num].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 11f, FontStyle.Bold);
				label_fcampara.Text = STR.FAST_CAM[USR_INIT.mLanguage] + "-" + (num + 1);
			}
			else
			{
				radioButton_fcamnz[num].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 11f, FontStyle.Regular);
			}
		}

		private void trackBar_fcam_para_valueChanged(object sender, EventArgs e)
		{
			int num = (int)((TrackBar)sender).Tag;
			int value = ((TrackBar)sender).Value;
			if (USR.mfcam_para == null)
			{
				USR.mfcam_para = new int[8][];
				for (int i = 0; i < 8; i++)
				{
					USR.mfcam_para[i] = new int[6];
					for (int j = 0; j < 6; j++)
					{
						USR.mfcam_para[i][j] = DEF.FCAM_PARA_DEFAULT[j];
					}
				}
			}
			USR.mfcam_para[MainForm0.mZn[mFn]][num] = value;
			label_fcam_para_v[num].Text = value.ToString();
			int ch = HW.mFastCamItem[mFn].index[MainForm0.mZn[mFn]];
			MainForm0.set_camera_parameter(ch, USR.mfcam_para[MainForm0.mZn[mFn]]);
		}

		public void set_radioNz()
		{
			radioButton_fcamnz[MainForm0.mZn[mFn]].Checked = true;
		}

		private void button_fcampara_reset_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox("确定要将快速相机" + (MainForm0.mZn[mFn] + 1) + "的相机参数设置为默认值吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < 4; i++)
				{
					trackBar_fcam_para_v[i].Value = DEF.FCAM_PARA_DEFAULT[i];
				}
			}
		}

		private void label_fcam_scanR_DoubleClick(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				int num = (int)((Label)sender).Tag;
				num %= 8;
				Form_FillXY form_FillXY = new Form_FillXY(USR2.mFastCamScanRange[0][num], USR_INIT.mLanguage, "V_I", 0, 360, STR.SCAN_RT[USR_INIT.mLanguage]);
				form_FillXY.TopMost = true;
				if (form_FillXY.ShowDialog() == DialogResult.OK)
				{
					int fill_V_I = form_FillXY.Get_Fill_V_I();
					USR2.mFastCamScanRange[0][num] = fill_V_I;
					lb_fcam_scanR[num].Text = fill_V_I.ToString();
				}
			}
		}

		private void label_fcam_pno_DoubleClick(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				int num = (int)((Label)sender).Tag;
				num %= 8;
				Form_FillXY form_FillXY = new Form_FillXY(USR2.mFastCamMinValidPixel[0][num], USR_INIT.mLanguage, "V_I", 0, 50000, STR.PNO[USR_INIT.mLanguage]);
				form_FillXY.TopMost = true;
				if (form_FillXY.ShowDialog() == DialogResult.OK)
				{
					int fill_V_I = form_FillXY.Get_Fill_V_I();
					USR2.mFastCamMinValidPixel[0][num] = fill_V_I;
					lb_fcam_pno[num].Text = fill_V_I.ToString();
				}
			}
		}

		private void numericUpDown_usr2_fcamstilldelay_ValueChanged(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				USR2.mFastCamStillDelay[0] = (int)numericUpDown_usr2_fcamstilldelay.Value;
			}
		}

		private void button_fcam_autopno_Click(object sender, EventArgs e)
		{
		}

		private void numericUpDown_hcam_stilldelay_ValueChanged(object sender, EventArgs e)
		{
			USR.mhcam_stilldelay = (int)numericUpDown_hcam_stilldelay.Value;
		}

		private void trackBar_hcam_lightlevel_v_Scroll(object sender, EventArgs e)
		{
			int value = trackBar_hcam_lightlevel_v.Value;
			if (USR2 != null)
			{
				USR2.mHighCamLightLevel[0] = value;
			}
			else
			{
				USR.mHighCamLightLevel = value;
			}
			label_hcam_lightlevel_v.Text = value.ToString();
			MainForm0.hcam_lightlevel_set(mFn, value);
		}

		private void label_hcam_scanR_DoubleClick(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				int num = (int)((Label)sender).Tag;
				num %= 8;
				Form_FillXY form_FillXY = new Form_FillXY(USR2.mHighCamScanRange[0][num], USR_INIT.mLanguage, "V_I", 0, 920, STR.SCAN_RT[USR_INIT.mLanguage]);
				form_FillXY.TopMost = true;
				if (form_FillXY.ShowDialog() == DialogResult.OK)
				{
					int fill_V_I = form_FillXY.Get_Fill_V_I();
					USR2.mHighCamScanRange[0][num] = fill_V_I;
					lb_hcam_scanR[num].Text = fill_V_I.ToString();
				}
			}
		}

		private void label_hcam_pno_DoubleClick(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				int num = (int)((Label)sender).Tag;
				num %= 8;
				Form_FillXY form_FillXY = new Form_FillXY(USR2.mHighCamMinValidPixel[0][num], USR_INIT.mLanguage, "V_I", 0, 50000, STR.PNO[USR_INIT.mLanguage]);
				form_FillXY.TopMost = true;
				if (form_FillXY.ShowDialog() == DialogResult.OK)
				{
					int fill_V_I = form_FillXY.Get_Fill_V_I();
					USR2.mHighCamMinValidPixel[0][num] = fill_V_I;
					lb_hcam_pno[num].Text = fill_V_I.ToString();
				}
			}
		}

		private void label_hcam_stilldelay_DoubleClick(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				int num = (int)((Label)sender).Tag;
				num %= 8;
				Form_FillXY form_FillXY = new Form_FillXY(USR2.mHighCamStillDelay[0][num], USR_INIT.mLanguage, "V_I", 0, 5000, STR.STILLDELAY[USR_INIT.mLanguage]);
				form_FillXY.TopMost = true;
				if (form_FillXY.ShowDialog() == DialogResult.OK)
				{
					int fill_V_I = form_FillXY.Get_Fill_V_I();
					USR2.mHighCamStillDelay[0][num] = fill_V_I;
					lb_hcam_delay[num].Text = fill_V_I.ToString();
				}
			}
		}

		private void numericUpDown_hCamPricise_delta_A_ValueChanged(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				USR2.mHCamPrisice_DeltaA = (float)numericUpDown_hCamPricise_delta_A.Value;
			}
		}

		private void numericUpDown_hCamPricise_delta_XY_ValueChanged(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				USR2.mHCamPrisice_DeltaXY = (float)numericUpDown_hCamPricise_delta_XY.Value;
			}
		}

		private void numericUpDown_hCamPricise_tryNum_ValueChanged(object sender, EventArgs e)
		{
			if (USR2 != null)
			{
				USR2.mHCamPrisice_TryNum = (int)numericUpDown_hCamPricise_tryNum.Value;
			}
		}

		private void checkBox_usr_changecampara_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_usr_changecampara.Checked)
			{
				string[] array = new string[3] { "修改相机参数可能会影响已有工程的视觉结果，是否继续?", "修改相機參數可能會影響已有工程的視覺結果，是否繼續??", "Modification of Camera Parameter will impact the visual recognition result for the project, still continue?" };
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					panel_for_usr.Visible = true;
				}
				else
				{
					checkBox_usr_changecampara.Checked = false;
				}
			}
			else
			{
				panel_for_usr.Visible = false;
			}
		}

		private void numericUpDown_microstep_ValueChanged(object sender, EventArgs e)
		{
			if (numericUpDown_fcam_led_v != null)
			{
				for (int i = 0; i < HW.mFastLedNum && numericUpDown_fcam_led_v[i] != null; i++)
				{
					numericUpDown_fcam_led_v[i].Increment = numericUpDown_microstep.Value;
				}
			}
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void button_saveas_default_Click(object sender, EventArgs e)
		{
			if (USR2 == null || MainForm0.CmMessageBox("是否保存为默认光源，供下次新建工程使用？", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			string path = "../configdata/" + STR.DEV_[(int)MainForm0.USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin";
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
			USR2_DATA uSR2_DATA = (USR2_DATA)formatter.Deserialize(stream);
			stream.Close();
			if (uSR2_DATA != null)
			{
				if (uSR2_DATA.mHighCamScanRange == null)
				{
					uSR2_DATA.mHighCamScanRange = new int[2][];
					for (int i = 0; i < 2; i++)
					{
						uSR2_DATA.mHighCamScanRange[i] = new int[8] { 450, 450, 450, 450, 450, 450, 450, 450 };
					}
				}
				for (int j = 0; j < HW.mZnNum[mFn]; j++)
				{
					uSR2_DATA.mFastCamMinValidPixel[0][j] = USR2.mFastCamMinValidPixel[0][j];
					uSR2_DATA.mFastCamScanRange[0][j] = USR2.mFastCamScanRange[0][j];
					uSR2_DATA.mHighCamMinValidPixel[0][j] = USR2.mHighCamMinValidPixel[0][j];
					uSR2_DATA.mHighCamScanRange[0][j] = USR2.mHighCamScanRange[0][j];
					uSR2_DATA.mHighCamStillDelay[0][j] = USR2.mHighCamStillDelay[0][j];
				}
				for (int k = 0; k < HW.mFastLedNum; k++)
				{
					uSR2_DATA.mFastCamLightLevel[0][k] = USR2.mFastCamLightLevel[0][k];
				}
				uSR2_DATA.mFastCamStillDelay[0] = USR2.mFastCamStillDelay[0];
				uSR2_DATA.mHighCamLightLevel[0] = USR2.mHighCamLightLevel[0];
				uSR2_DATA.mHCamPrisice_DeltaA = USR2.mHCamPrisice_DeltaA;
				uSR2_DATA.mHCamPrisice_DeltaXY = USR2.mHCamPrisice_DeltaXY;
				uSR2_DATA.mHCamPrisice_TryNum = USR2.mHCamPrisice_TryNum;
			}
			IFormatter formatter2 = new BinaryFormatter();
			Stream stream2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter2.Serialize(stream2, uSR2_DATA);
			stream2.Close();
			MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Complete!" : "完成！");
		}

		private void UserControl_CamPara_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_saveas_default);
			MainForm0.CreateAddButtonPic(button_fcampara_reset);
			MainForm0.CreateAddButtonPic(button_close);
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
			panel_hcam_a = new System.Windows.Forms.Panel();
			numericUpDown_hcam_stilldelay = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			label_hcam_lightlevel_v = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			panel_hcam_light = new System.Windows.Forms.Panel();
			trackBar_hcam_lightlevel_v = new System.Windows.Forms.TrackBar();
			panel_for_usr = new System.Windows.Forms.Panel();
			panel_fcam_nz = new System.Windows.Forms.Panel();
			panel_fcampara = new System.Windows.Forms.Panel();
			label_fcampara = new System.Windows.Forms.Label();
			numericUpDown_hCamPricise_tryNum = new System.Windows.Forms.NumericUpDown();
			panel_usr2_hcambihuan = new System.Windows.Forms.Panel();
			numericUpDown_hCamPricise_delta_XY = new System.Windows.Forms.NumericUpDown();
			numericUpDown_hCamPricise_delta_A = new System.Windows.Forms.NumericUpDown();
			label12 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label_hcam_notice = new System.Windows.Forms.Label();
			label_title = new System.Windows.Forms.Label();
			numericUpDown_usr_fcamstilldelay = new System.Windows.Forms.NumericUpDown();
			panel_usr2para_h = new System.Windows.Forms.Panel();
			checkBox_changelight_all = new System.Windows.Forms.CheckBox();
			numericUpDown_microstep = new System.Windows.Forms.NumericUpDown();
			tabPage1 = new System.Windows.Forms.TabPage();
			checkBox_usr_changecampara = new System.Windows.Forms.CheckBox();
			label_microstep = new System.Windows.Forms.Label();
			panel_usr_a = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			label_notice = new System.Windows.Forms.Label();
			panel_for_usr2 = new System.Windows.Forms.Panel();
			numericUpDown_usr2_fcamstilldelay = new System.Windows.Forms.NumericUpDown();
			panel_usr2para = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			panel_fcam_led = new System.Windows.Forms.Panel();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage2 = new System.Windows.Forms.TabPage();
			panel_usr2_hcampara = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_fcam_autopno = new QIGN_COMMON.vs_acontrol.CnButton();
			button_saveas_default = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close = new QIGN_COMMON.vs_acontrol.CnButton();
			button_fcampara_reset = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_hcam_a.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_stilldelay).BeginInit();
			panel_hcam_light.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_hcam_lightlevel_v).BeginInit();
			panel_for_usr.SuspendLayout();
			panel_fcampara.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hCamPricise_tryNum).BeginInit();
			panel_usr2_hcambihuan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hCamPricise_delta_XY).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hCamPricise_delta_A).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_usr_fcamstilldelay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_microstep).BeginInit();
			tabPage1.SuspendLayout();
			panel_usr_a.SuspendLayout();
			panel_for_usr2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_usr2_fcamstilldelay).BeginInit();
			tabControl1.SuspendLayout();
			tabPage2.SuspendLayout();
			panel_usr2_hcampara.SuspendLayout();
			SuspendLayout();
			panel_hcam_a.BackColor = System.Drawing.Color.CadetBlue;
			panel_hcam_a.Controls.Add(numericUpDown_hcam_stilldelay);
			panel_hcam_a.Controls.Add(label9);
			panel_hcam_a.Location = new System.Drawing.Point(460, 2);
			panel_hcam_a.Name = "panel_hcam_a";
			panel_hcam_a.Size = new System.Drawing.Size(75, 158);
			panel_hcam_a.TabIndex = 2;
			numericUpDown_hcam_stilldelay.Font = new System.Drawing.Font("楷体", 11f);
			numericUpDown_hcam_stilldelay.Location = new System.Drawing.Point(7, 116);
			numericUpDown_hcam_stilldelay.Maximum = new decimal(new int[4] { 5000, 0, 0, 0 });
			numericUpDown_hcam_stilldelay.Name = "numericUpDown_hcam_stilldelay";
			numericUpDown_hcam_stilldelay.Size = new System.Drawing.Size(58, 24);
			numericUpDown_hcam_stilldelay.TabIndex = 2;
			numericUpDown_hcam_stilldelay.Value = new decimal(new int[4] { 100, 0, 0, 0 });
			numericUpDown_hcam_stilldelay.ValueChanged += new System.EventHandler(numericUpDown_hcam_stilldelay_ValueChanged);
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("楷体", 11f);
			label9.Location = new System.Drawing.Point(3, 97);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(71, 15);
			label9.TabIndex = 1;
			label9.Text = "拍照延时";
			label_hcam_lightlevel_v.AutoSize = true;
			label_hcam_lightlevel_v.Font = new System.Drawing.Font("楷体", 11f);
			label_hcam_lightlevel_v.Location = new System.Drawing.Point(335, 66);
			label_hcam_lightlevel_v.Name = "label_hcam_lightlevel_v";
			label_hcam_lightlevel_v.Size = new System.Drawing.Size(31, 15);
			label_hcam_lightlevel_v.TabIndex = 1;
			label_hcam_lightlevel_v.Text = "300";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("楷体", 12f);
			label6.Location = new System.Drawing.Point(120, 31);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(144, 16);
			label6.TabIndex = 1;
			label6.Text = "高清相机 光源亮度";
			panel_hcam_light.BackColor = System.Drawing.Color.CadetBlue;
			panel_hcam_light.Controls.Add(label6);
			panel_hcam_light.Controls.Add(label_hcam_lightlevel_v);
			panel_hcam_light.Controls.Add(trackBar_hcam_lightlevel_v);
			panel_hcam_light.Location = new System.Drawing.Point(1, 2);
			panel_hcam_light.Name = "panel_hcam_light";
			panel_hcam_light.Size = new System.Drawing.Size(458, 158);
			panel_hcam_light.TabIndex = 0;
			trackBar_hcam_lightlevel_v.Location = new System.Drawing.Point(5, 63);
			trackBar_hcam_lightlevel_v.Maximum = 840;
			trackBar_hcam_lightlevel_v.Name = "trackBar_hcam_lightlevel_v";
			trackBar_hcam_lightlevel_v.Size = new System.Drawing.Size(334, 45);
			trackBar_hcam_lightlevel_v.TabIndex = 0;
			trackBar_hcam_lightlevel_v.TickFrequency = 50;
			trackBar_hcam_lightlevel_v.Scroll += new System.EventHandler(trackBar_hcam_lightlevel_v_Scroll);
			panel_for_usr.BackColor = System.Drawing.Color.CadetBlue;
			panel_for_usr.Controls.Add(panel_fcam_nz);
			panel_for_usr.Controls.Add(panel_fcampara);
			panel_for_usr.Location = new System.Drawing.Point(11, 436);
			panel_for_usr.Name = "panel_for_usr";
			panel_for_usr.Size = new System.Drawing.Size(534, 141);
			panel_for_usr.TabIndex = 5;
			panel_fcam_nz.Location = new System.Drawing.Point(4, 12);
			panel_fcam_nz.Name = "panel_fcam_nz";
			panel_fcam_nz.Size = new System.Drawing.Size(236, 116);
			panel_fcam_nz.TabIndex = 2;
			panel_fcampara.BackColor = System.Drawing.Color.White;
			panel_fcampara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_fcampara.Controls.Add(button_fcampara_reset);
			panel_fcampara.Controls.Add(label_fcampara);
			panel_fcampara.Location = new System.Drawing.Point(246, 5);
			panel_fcampara.Name = "panel_fcampara";
			panel_fcampara.Size = new System.Drawing.Size(282, 123);
			panel_fcampara.TabIndex = 0;
			label_fcampara.AutoSize = true;
			label_fcampara.Font = new System.Drawing.Font("黑体", 11.5f);
			label_fcampara.Location = new System.Drawing.Point(4, 6);
			label_fcampara.Name = "label_fcampara";
			label_fcampara.Size = new System.Drawing.Size(120, 16);
			label_fcampara.TabIndex = 1;
			label_fcampara.Text = "相机参数-吸嘴1";
			numericUpDown_hCamPricise_tryNum.Font = new System.Drawing.Font("楷体", 11f);
			numericUpDown_hCamPricise_tryNum.Location = new System.Drawing.Point(6, 116);
			numericUpDown_hCamPricise_tryNum.Name = "numericUpDown_hCamPricise_tryNum";
			numericUpDown_hCamPricise_tryNum.Size = new System.Drawing.Size(93, 24);
			numericUpDown_hCamPricise_tryNum.TabIndex = 3;
			numericUpDown_hCamPricise_tryNum.ValueChanged += new System.EventHandler(numericUpDown_hCamPricise_tryNum_ValueChanged);
			panel_usr2_hcambihuan.BackColor = System.Drawing.Color.CadetBlue;
			panel_usr2_hcambihuan.Controls.Add(numericUpDown_hCamPricise_tryNum);
			panel_usr2_hcambihuan.Controls.Add(numericUpDown_hCamPricise_delta_XY);
			panel_usr2_hcambihuan.Controls.Add(numericUpDown_hCamPricise_delta_A);
			panel_usr2_hcambihuan.Controls.Add(label12);
			panel_usr2_hcambihuan.Controls.Add(label11);
			panel_usr2_hcambihuan.Controls.Add(label10);
			panel_usr2_hcambihuan.Font = new System.Drawing.Font("黑体", 9f);
			panel_usr2_hcambihuan.Location = new System.Drawing.Point(554, 90);
			panel_usr2_hcambihuan.Name = "panel_usr2_hcambihuan";
			panel_usr2_hcambihuan.Size = new System.Drawing.Size(133, 158);
			panel_usr2_hcambihuan.TabIndex = 6;
			numericUpDown_hCamPricise_delta_XY.DecimalPlaces = 2;
			numericUpDown_hCamPricise_delta_XY.Font = new System.Drawing.Font("楷体", 11f);
			numericUpDown_hCamPricise_delta_XY.Location = new System.Drawing.Point(6, 70);
			numericUpDown_hCamPricise_delta_XY.Name = "numericUpDown_hCamPricise_delta_XY";
			numericUpDown_hCamPricise_delta_XY.Size = new System.Drawing.Size(93, 24);
			numericUpDown_hCamPricise_delta_XY.TabIndex = 2;
			numericUpDown_hCamPricise_delta_XY.ValueChanged += new System.EventHandler(numericUpDown_hCamPricise_delta_XY_ValueChanged);
			numericUpDown_hCamPricise_delta_A.DecimalPlaces = 2;
			numericUpDown_hCamPricise_delta_A.Font = new System.Drawing.Font("楷体", 11f);
			numericUpDown_hCamPricise_delta_A.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
			numericUpDown_hCamPricise_delta_A.Location = new System.Drawing.Point(6, 24);
			numericUpDown_hCamPricise_delta_A.Maximum = new decimal(new int[4] { 5, 0, 0, 65536 });
			numericUpDown_hCamPricise_delta_A.Name = "numericUpDown_hCamPricise_delta_A";
			numericUpDown_hCamPricise_delta_A.Size = new System.Drawing.Size(93, 24);
			numericUpDown_hCamPricise_delta_A.TabIndex = 2;
			numericUpDown_hCamPricise_delta_A.ValueChanged += new System.EventHandler(numericUpDown_hCamPricise_delta_A_ValueChanged);
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("黑体", 11f);
			label12.Location = new System.Drawing.Point(3, 97);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(135, 15);
			label12.TabIndex = 1;
			label12.Text = "精准闭环重试次数";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("黑体", 11f);
			label11.Location = new System.Drawing.Point(3, 50);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(119, 15);
			label11.TabIndex = 1;
			label11.Text = "精准闭环XY容差";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("黑体", 11f);
			label10.Location = new System.Drawing.Point(3, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(135, 15);
			label10.TabIndex = 1;
			label10.Text = "精准闭环角度容差";
			label_hcam_notice.AutoSize = true;
			label_hcam_notice.Font = new System.Drawing.Font("楷体", 11f);
			label_hcam_notice.Location = new System.Drawing.Point(3, 167);
			label_hcam_notice.Name = "label_hcam_notice";
			label_hcam_notice.Size = new System.Drawing.Size(535, 15);
			label_hcam_notice.TabIndex = 3;
			label_hcam_notice.Text = "提示：修改光源会影响所有料站/料盘/振动飞达的快速相机识别，请谨慎！";
			label_title.AutoSize = true;
			label_title.Font = new System.Drawing.Font("黑体", 14.25f);
			label_title.Location = new System.Drawing.Point(172, 14);
			label_title.Name = "label_title";
			label_title.Size = new System.Drawing.Size(179, 19);
			label_title.TabIndex = 3;
			label_title.Text = "相机设置 设备调试";
			label_title.Visible = false;
			numericUpDown_usr_fcamstilldelay.Font = new System.Drawing.Font("楷体", 11f);
			numericUpDown_usr_fcamstilldelay.Location = new System.Drawing.Point(7, 116);
			numericUpDown_usr_fcamstilldelay.Maximum = new decimal(new int[4] { 5000, 0, 0, 0 });
			numericUpDown_usr_fcamstilldelay.Name = "numericUpDown_usr_fcamstilldelay";
			numericUpDown_usr_fcamstilldelay.Size = new System.Drawing.Size(58, 24);
			numericUpDown_usr_fcamstilldelay.TabIndex = 2;
			numericUpDown_usr_fcamstilldelay.Value = new decimal(new int[4] { 85, 0, 0, 0 });
			numericUpDown_usr_fcamstilldelay.ValueChanged += new System.EventHandler(numericUpDown_usr_fcamstilldelay_ValueChanged);
			panel_usr2para_h.Location = new System.Drawing.Point(4, 4);
			panel_usr2para_h.Name = "panel_usr2para_h";
			panel_usr2para_h.Size = new System.Drawing.Size(522, 116);
			panel_usr2para_h.TabIndex = 0;
			checkBox_changelight_all.AutoSize = true;
			checkBox_changelight_all.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_changelight_all.Location = new System.Drawing.Point(285, 164);
			checkBox_changelight_all.Name = "checkBox_changelight_all";
			checkBox_changelight_all.Size = new System.Drawing.Size(122, 19);
			checkBox_changelight_all.TabIndex = 5;
			checkBox_changelight_all.Text = "光源整体调节";
			checkBox_changelight_all.UseVisualStyleBackColor = true;
			numericUpDown_microstep.Font = new System.Drawing.Font("楷体", 11f);
			numericUpDown_microstep.Location = new System.Drawing.Point(490, 160);
			numericUpDown_microstep.Name = "numericUpDown_microstep";
			numericUpDown_microstep.Size = new System.Drawing.Size(41, 24);
			numericUpDown_microstep.TabIndex = 7;
			numericUpDown_microstep.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			numericUpDown_microstep.ValueChanged += new System.EventHandler(numericUpDown_microstep_ValueChanged);
			tabPage1.Controls.Add(numericUpDown_microstep);
			tabPage1.Controls.Add(checkBox_changelight_all);
			tabPage1.Controls.Add(checkBox_usr_changecampara);
			tabPage1.Controls.Add(label_microstep);
			tabPage1.Controls.Add(panel_usr_a);
			tabPage1.Controls.Add(label_notice);
			tabPage1.Controls.Add(panel_for_usr2);
			tabPage1.Controls.Add(panel_fcam_led);
			tabPage1.Font = new System.Drawing.Font("楷体", 10.5f);
			tabPage1.Location = new System.Drawing.Point(4, 25);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(537, 316);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "快速相机";
			tabPage1.UseVisualStyleBackColor = true;
			checkBox_usr_changecampara.AutoSize = true;
			checkBox_usr_changecampara.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_usr_changecampara.Location = new System.Drawing.Point(3, 164);
			checkBox_usr_changecampara.Name = "checkBox_usr_changecampara";
			checkBox_usr_changecampara.Size = new System.Drawing.Size(122, 19);
			checkBox_usr_changecampara.TabIndex = 4;
			checkBox_usr_changecampara.Text = "修改相机参数";
			checkBox_usr_changecampara.UseVisualStyleBackColor = true;
			checkBox_usr_changecampara.CheckedChanged += new System.EventHandler(checkBox_usr_changecampara_CheckedChanged);
			label_microstep.AutoSize = true;
			label_microstep.Font = new System.Drawing.Font("黑体", 11f);
			label_microstep.Location = new System.Drawing.Point(415, 165);
			label_microstep.Name = "label_microstep";
			label_microstep.Size = new System.Drawing.Size(71, 15);
			label_microstep.TabIndex = 6;
			label_microstep.Text = "微调步距";
			panel_usr_a.BackColor = System.Drawing.Color.CadetBlue;
			panel_usr_a.Controls.Add(numericUpDown_usr_fcamstilldelay);
			panel_usr_a.Controls.Add(label4);
			panel_usr_a.Location = new System.Drawing.Point(460, 2);
			panel_usr_a.Name = "panel_usr_a";
			panel_usr_a.Size = new System.Drawing.Size(75, 158);
			panel_usr_a.TabIndex = 1;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 11f);
			label4.Location = new System.Drawing.Point(3, 97);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(71, 15);
			label4.TabIndex = 1;
			label4.Text = "拍照延时";
			label_notice.AutoSize = true;
			label_notice.BackColor = System.Drawing.Color.NavajoWhite;
			label_notice.Font = new System.Drawing.Font("黑体", 11f);
			label_notice.Location = new System.Drawing.Point(3, 165);
			label_notice.Name = "label_notice";
			label_notice.Size = new System.Drawing.Size(263, 15);
			label_notice.TabIndex = 2;
			label_notice.Text = "光源影响所有元件识别，谨慎修改！";
			panel_for_usr2.BackColor = System.Drawing.Color.CadetBlue;
			panel_for_usr2.Controls.Add(numericUpDown_usr2_fcamstilldelay);
			panel_for_usr2.Controls.Add(panel_usr2para);
			panel_for_usr2.Controls.Add(label5);
			panel_for_usr2.Location = new System.Drawing.Point(1, 184);
			panel_for_usr2.Name = "panel_for_usr2";
			panel_for_usr2.Size = new System.Drawing.Size(534, 179);
			panel_for_usr2.TabIndex = 1;
			numericUpDown_usr2_fcamstilldelay.Font = new System.Drawing.Font("楷体", 11f);
			numericUpDown_usr2_fcamstilldelay.Location = new System.Drawing.Point(104, 99);
			numericUpDown_usr2_fcamstilldelay.Maximum = new decimal(new int[4] { 5000, 0, 0, 0 });
			numericUpDown_usr2_fcamstilldelay.Name = "numericUpDown_usr2_fcamstilldelay";
			numericUpDown_usr2_fcamstilldelay.Size = new System.Drawing.Size(58, 24);
			numericUpDown_usr2_fcamstilldelay.TabIndex = 2;
			numericUpDown_usr2_fcamstilldelay.Value = new decimal(new int[4] { 85, 0, 0, 0 });
			numericUpDown_usr2_fcamstilldelay.ValueChanged += new System.EventHandler(numericUpDown_usr2_fcamstilldelay_ValueChanged);
			panel_usr2para.Location = new System.Drawing.Point(4, 4);
			panel_usr2para.Name = "panel_usr2para";
			panel_usr2para.Size = new System.Drawing.Size(527, 90);
			panel_usr2para.TabIndex = 0;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 11f);
			label5.Location = new System.Drawing.Point(3, 103);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(103, 15);
			label5.TabIndex = 1;
			label5.Text = "拍照延时(ms)";
			panel_fcam_led.BackColor = System.Drawing.Color.CadetBlue;
			panel_fcam_led.Location = new System.Drawing.Point(1, 2);
			panel_fcam_led.Name = "panel_fcam_led";
			panel_fcam_led.Size = new System.Drawing.Size(458, 158);
			panel_fcam_led.TabIndex = 0;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Font = new System.Drawing.Font("黑体", 11.5f);
			tabControl1.Location = new System.Drawing.Point(3, 12);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(545, 345);
			tabControl1.TabIndex = 4;
			tabPage2.Controls.Add(panel_usr2_hcampara);
			tabPage2.Controls.Add(label_hcam_notice);
			tabPage2.Controls.Add(panel_hcam_a);
			tabPage2.Controls.Add(panel_hcam_light);
			tabPage2.Font = new System.Drawing.Font("楷体", 10.5f);
			tabPage2.Location = new System.Drawing.Point(4, 25);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(537, 316);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "高清相机";
			tabPage2.UseVisualStyleBackColor = true;
			panel_usr2_hcampara.BackColor = System.Drawing.Color.CadetBlue;
			panel_usr2_hcampara.Controls.Add(panel_usr2para_h);
			panel_usr2_hcampara.Location = new System.Drawing.Point(1, 188);
			panel_usr2_hcampara.Name = "panel_usr2_hcampara";
			panel_usr2_hcampara.Size = new System.Drawing.Size(534, 179);
			panel_usr2_hcampara.TabIndex = 4;
			label1.BackColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(-1, -1);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(600, 6);
			label1.TabIndex = 9;
			label2.BackColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(-31, 364);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(600, 14);
			label2.TabIndex = 9;
			button_fcam_autopno.BackColor = System.Drawing.Color.LightSteelBlue;
			button_fcam_autopno.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_fcam_autopno.CnPressDownColor = System.Drawing.Color.White;
			button_fcam_autopno.Font = new System.Drawing.Font("楷体", 11f);
			button_fcam_autopno.Location = new System.Drawing.Point(617, 433);
			button_fcam_autopno.Name = "button_fcam_autopno";
			button_fcam_autopno.Size = new System.Drawing.Size(182, 32);
			button_fcam_autopno.TabIndex = 3;
			button_fcam_autopno.Text = "一键设置有效像素下限";
			button_fcam_autopno.UseVisualStyleBackColor = false;
			button_fcam_autopno.Visible = false;
			button_fcam_autopno.Click += new System.EventHandler(button_fcam_autopno_Click);
			button_saveas_default.BackColor = System.Drawing.Color.LightSteelBlue;
			button_saveas_default.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_saveas_default.CnPressDownColor = System.Drawing.Color.White;
			button_saveas_default.Font = new System.Drawing.Font("黑体", 10f);
			button_saveas_default.Location = new System.Drawing.Point(366, 9);
			button_saveas_default.Name = "button_saveas_default";
			button_saveas_default.Size = new System.Drawing.Size(129, 28);
			button_saveas_default.TabIndex = 8;
			button_saveas_default.Text = "保存为默认光源";
			button_saveas_default.UseVisualStyleBackColor = false;
			button_saveas_default.Click += new System.EventHandler(button_saveas_default_Click);
			button_close.BackColor = System.Drawing.SystemColors.ControlLight;
			button_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close.CnPressDownColor = System.Drawing.Color.White;
			button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			button_close.Location = new System.Drawing.Point(520, 8);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(28, 28);
			button_close.TabIndex = 7;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = false;
			button_close.Click += new System.EventHandler(button_close_Click);
			button_fcampara_reset.BackColor = System.Drawing.Color.LightSteelBlue;
			button_fcampara_reset.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_fcampara_reset.CnPressDownColor = System.Drawing.Color.White;
			button_fcampara_reset.Font = new System.Drawing.Font("黑体", 11f);
			button_fcampara_reset.Location = new System.Drawing.Point(155, 2);
			button_fcampara_reset.Name = "button_fcampara_reset";
			button_fcampara_reset.Size = new System.Drawing.Size(119, 26);
			button_fcampara_reset.TabIndex = 3;
			button_fcampara_reset.Text = "恢复默认值";
			button_fcampara_reset.UseVisualStyleBackColor = false;
			button_fcampara_reset.Click += new System.EventHandler(button_fcampara_reset_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.CadetBlue;
			base.Controls.Add(button_fcam_autopno);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(button_saveas_default);
			base.Controls.Add(button_close);
			base.Controls.Add(panel_for_usr);
			base.Controls.Add(panel_usr2_hcambihuan);
			base.Controls.Add(label_title);
			base.Controls.Add(tabControl1);
			base.Name = "UserControl_CamPara";
			base.Size = new System.Drawing.Size(846, 666);
			base.Load += new System.EventHandler(UserControl_CamPara_Load);
			panel_hcam_a.ResumeLayout(false);
			panel_hcam_a.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_stilldelay).EndInit();
			panel_hcam_light.ResumeLayout(false);
			panel_hcam_light.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_hcam_lightlevel_v).EndInit();
			panel_for_usr.ResumeLayout(false);
			panel_fcampara.ResumeLayout(false);
			panel_fcampara.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hCamPricise_tryNum).EndInit();
			panel_usr2_hcambihuan.ResumeLayout(false);
			panel_usr2_hcambihuan.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hCamPricise_delta_XY).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hCamPricise_delta_A).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_usr_fcamstilldelay).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_microstep).EndInit();
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			panel_usr_a.ResumeLayout(false);
			panel_usr_a.PerformLayout();
			panel_for_usr2.ResumeLayout(false);
			panel_for_usr2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_usr2_fcamstilldelay).EndInit();
			tabControl1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			panel_usr2_hcampara.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
