using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.Properties;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_SystemSetting : UserControl
	{
		public Label[] lb_delta_zx_name;

		public Label[] lb_delta_hx;

		public Label[] lb_delta2_zx_name;

		public Label[] lb_delta2_hx;

		public Button[][] bt_inkpoint = new Button[4][];

		public Point mCurInkPoint;

		public volatile bool[][] mInkPointConfirmed = new bool[4][];

		private bool[][] mIsCenterConfirmed;

		private int mSlotCornerIndex;

		private int mStackNo;

		private Label[] label_slotxy;

		private Label[] label_baseH_feeder_Zn;

		private Label[] label_baseH_feeder_Zn_V;

		private Label[] label_baseH_feederBk_Zn;

		private Label[] label_baseH_feederBk_Zn_V;

		private int mFn;

		private USR_DATA USR;

		private USR_INIT_DATA USR_INIT;

		private IContainer components;

		private Label label_FixSetting;

		private CnButton button_close;

		private TabPage tabPage_fix_feeder;

		private TabPage tabPage_fix_nozzledelta;

		private CheckBox checkBox_delta_nozzle_singlemode;

		private Label label_fix_nz_manulcheck;

		private Panel panel46;

		private CnButton button_nzdelta_para_check;

		private CnButton button_StartZnDelta;

		private Label label30;

		private Label label33;

		private Label label36;

		private Panel panel_InkPoint;

		private TabControl tabControl2;

		private TabPage tabPage12;

		private CnButton button_center_clear;

		private Label label32;

		private Label label41;

		private CnButton button_center_confirm;

		private CnButton button_deltaDone;

		private TabPage tabPage11;

		private CnButton button_auto_deltaDone_Interupt;

		private CnButton button_auto_deltaDone;

		private Label label55;

		private Label label56;

		private NumericUpDown numericUpDown_test_threshold;

		private Label label124;

		private NumericUpDown numericUpDown_test_scanr;

		private Panel panel_fixnozzle1;

		private Label label18;

		private CnButton button_AutoGen_InkCollectH;

		private CnButton button_MoveToInkPadCollectCoord;

		private Label label_fix_noz_inkXY;

		private Label label17;

		private Label label_fix_noz_writeXY;

		private Label label63;

		private CnButton button_SaveInkPadCollectHeight;

		private Panel panel24;

		private NumericUpDown numericUpDown_InkWrite_Offset;

		private CnButton button_AutoGen_InkWriteH;

		private Label label9;

		private Label label8;

		private Label label_fix_nz_writeH;

		private CnButton button_SaveInkPadWriteHeight;

		private CnButton button_MoveToInkPadWriteHeight;

		private CnButton button_MoveToInkPadCollectHeight;

		private CnButton button_SaveInkPadCollectCoord;

		private Label label_InkPadCollectCoord;

		private Label label_InkPadWriteCoord;

		private CnButton button_SaveInkPadWriteCoord;

		private CnButton button_MoveToInkPadWriteCoord;

		private Label label_fix_nz_inkH;

		private Label label37;

		private Label label6;

		private Label label_fix_nz_warning;

		private Label label_fix_noz_prepare;

		private Panel panel11;

		private Panel panel33;

		private CnButton button_test_previewoffset;

		private CnButton button_previewoffset_reset;

		private Label label137;

		private NumericUpDown numericUpDown_previewoffset_y;

		private Label label135;

		private NumericUpDown numericUpDown_previewoffset_x;

		private NumericUpDown nud_MarkRatio;

		private Label label_pixel_ratio;

		private Label label43;

		private Label label5;

		private TabPage tabPage_fix_cam;

		private Panel panel2;

		private Label label_HighRecognizeCoord;

		private CnButton button_hcam_set;

		private CnButton button_hcam_distortion_para;

		private CnButton button_SingleSetHighCamCoord;

		private CnButton button7;

		private CheckBox checkBox_highcam_oppovisual;

		private CnButton button_AutoSetHighCamCoord;

		private Label label_fix_highcam_note;

		private Label label125;

		private CnButton button_HighCamMoveToCoord;

		private Panel panel_hcam_h;

		private Panel panel_Hcam_baseH;

		private CnButton button_goto_baseHcam_h_allzn;

		private CnButton button_goto_Hcam_baseH;

		private CnButton button_save_Hcam_baseH;

		private Label label143;

		private Label label3;

		private PictureBox pictureBox1;

		private Label label2;

		private Panel panel1;

		private CnButton button_fcam_set;

		private CnButton button_AutoSetFastCamCoord;

		private CnButton button_fcam_distortion_para;

		private CheckBox checkBox_fastcam_oppovisual;

		private CnButton button_FastCamMoveToCoord;

		private Label label_fix_fastcam_note;

		private PictureBox pictureBox7;

		private CnButton button1;

		private Panel panel_fcam_h;

		private Panel panel_nozzlebasicHigh_visual;

		private CnButton button_goto_basecamera_h_allzn;

		private CnButton button_goto_basecamera_h;

		private CnButton button_save_basecamera_h;

		private Label label74;

		private Label label_FastRecognizeCoord;

		private Label label1;

		private Label label140;

		private Label label139;

		private CheckBox checkBox_FCameraCalibrator;

		private CnButton button_fcam_disable;

		private TabPage tabPage_fix_base;

		private Panel panel6;

		private Panel panel_nozzlebasicHigh;

		private CnButton button_baseH_Goto;

		private CnButton button_baseH_Save;

		private Label label7;

		private TabControl tabControl1;

		private Label label10;

		private Label label200;

		private Panel panel110;

		private Label label_slotxy1;

		private Label label_slotxy0;

		private CnButton button_slotxy_to_curUsr2;

		private Panel panel_showfeederxy;

		private CnButton button_SlotsXYGens;

		private CnButton button_slotMoveToXY;

		private CnButton button_slotSaveXY;

		private Label label_slotxy3;

		private Label label_slotxy2;

		private Label label99;

		private Label label70;

		private Panel panel29;

		private Panel panel62;

		private CnButton button_feederBaseBkH_Goto;

		private CnButton button_feederBaseBkH_AutoGen;

		private CnButton button_feederBaseBKH_Save;

		private Panel panel_nozzlebasicHigh_feederBk;

		private Label label_feeder_back_info;

		private Label label130;

		private Label label129;

		private Panel panel61;

		private CnButton button_feederBaseH_Goto;

		private CnButton button_feederBaseH_Save;

		private Label label_feeder_front_info;

		private CnButton button_feederBaseH_AutoGen;

		private Panel panel_nozzlebasicHigh_feeder;

		private Label label73;

		private Label label71;

		private Panel panel14;

		private CnButton button_gotoSlot_byZn;

		private CnButton button_slotOpen;

		private CnButton button_gotoSlot;

		private CnButton button_slotClose;

		private Label label102;

		private Label label103;

		private Label label_stackXY;

		private CnButton button_saveSlot;

		private Panel panel_gen2_H;

		private Panel panel_vaccbreaktime;

		private Label label132;

		private CnButton button_nozzle_clean;

		private Panel panel27;

		private Panel panel31;

		private Label label212;

		private CheckBox checkBox_SafeRunMode;

		private Label label75;

		private Panel panel_nozzlebasicHigh_run;

		private CnButton button_goto_runsafe_h;

		private CnButton button_save_runsafe_h;

		private Label label12;

		private Panel panel3;

		private Label label15;

		private PictureBox pictureBox2;

		private Label label16;

		private Label label19;

		private CnButton button_vacuum_sync;

		private Label label24;

		private Panel panel_fcam_setting;

		private CnButton button_close_fcam_setting;

		private Panel panel_liebian;

		private Label label25;

		private NumericUpDown numericUpDown_fcam__recsize;

		private Label label141;

		private Panel panel_hcam_setting;

		private Label label26;

		private NumericUpDown numericUpDown_hcam_rec_size;

		private Label label218;

		private NumericUpDown numericUpDown_hcam_liebian;

		private CnButton button_close_hcam_setting;

		private Panel panel_fcam_calib;

		private Panel panel_hcam_calib;

		private Panel panel_pausestop;

		private CnButton button_pause;

		private CnButton button_resume;

		private CnButton button_stop;

		private CnButton button11;

		private CnButton button10;

		private Label label21;

		private Panel panel4;

		private Label label27;

		private CnButton button_switchto_basepage;

		private Label label34;

		private Label label35;

		private Label label38;

		private Label label_stackNo;

		private Label label11;

		private Panel panel_baseH_show;

		private Label label39;

		private Label label40;

		private Label label42;

		private Label label44;

		private Panel panel_saveH_shows;

		private Label label45;

		private Label label46;

		private Label label47;

		private Label label48;

		private Label label50;

		private Label label49;

		private Label label51;

		private Label label52;

		private Label label60;

		private CnButton button_tmpXY_Goto;

		private Label label_throwxy;

		private CnButton button_tmpXY_Save;

		private CnButton button_MoveToThrowCoord;

		private Label label_tmpXY;

		private Label label136;

		private CnButton button_SaveThrowCoord;

		private Label label_ThrowCoord;

		private CheckBox checkBox_debug_isSaveErrBitmap;

		private TabPage tabPage_fix_factory;

		private Panel panel58;

		private CnButton button_FactoryTest_AutoFeeder;

		private CheckBox checkBox_AutoFeeder_Inc;

		private Label label13;

		private NumericUpDown numericUpDown_AutoFeeder_Delay;

		private NumericUpDown numericUpDown_factorytest_count;

		private CnButton button_FactoryTestAll_Stop;

		private NumericUpDown numericUpDown_factorytestall_hour;

		private CnButton button_FactoryTestAll_Start;

		private NumericUpDown numericUpDown_FactoryTest_feederNum;

		private ProgressBar progressBar_FactoryTestAll;

		private CnButton button_FactoryTest_Start;

		private ProgressBar progressBar_FactoryTest;

		private CnButton button_FactoryTest_OpenFeeder;

		private CnButton button_FactoryTest_Stop;

		private CnButton button_FactoryTest_CloseFeeder;

		private Label label79;

		private Label label62;

		private Label label64;

		private Panel panel8;

		private Panel panel9;

		private Label label65;

		private Panel panel10;

		private Label label66;

		private NumericUpDown numericUpDown1;

		private CnButton button2;

		private ProgressBar progressBar1;

		private CnButton button3;

		private Panel panel12;

		private Label label67;

		private NumericUpDown numericUpDown2;

		private CnButton button4;

		private ProgressBar progressBar2;

		private CnButton button5;

		private Panel panel19;

		private CnButton button_algorithm_debug_running;

		private CnButton button_algorithm_debug_cur;

		private CnButton button_algorithm_debug_prev;

		private NumericUpDown numericUpDown_pic_idx;

		private TextBox textBox_testfolder;

		private CnButton button_testfolder;

		private CnButton button_algorithm_debugauto;

		private CnButton button_algorithm_debug;

		private NumericUpDown numericUpDown_factoryvisualtest_angle;

		private CheckBox checkBox_factoryDebug;

		private Label label68;

		private CnButton btn_HideSetting;

		private Panel panel_fix_factory;

		private Panel panel_zhadian;

		private Panel panel_collectink;

		private Label label20;

		private Label label29;

		private Label label53;

		private NumericUpDown numericUpDown_fcam_threshold;

		private NumericUpDown numericUpDown_fcam_scanr;

		private CnButton button_fcam_visualtest;

		private CnButton button_hcam_visualtest;

		private NumericUpDown numericUpDown_hcam_threshold;

		private NumericUpDown numericUpDown_hcam_scanr;

		private Label label57;

		private Label label54;

		private CnButton button_fcam_campara;

		private CnButton button_hcam_campara;

		private Label label14;

		private CnButton button_switchto_campage;

		private Label label22;

		private Label label23;

		private Label label28;

		private Label label31;

		private Panel panel_color;

		private TrackBar trackBar_color_b;

		private TrackBar trackBar_color_g;

		private TrackBar trackBar_color_r;

		private CnButton cnButton_tool;

		private Panel panel_saferun_limit;

		private Label label4;

		private Panel panel_baseH_saferun_limited;

		private CnButton cnButton_goto_runsafe_limit_h;

		private CnButton cnButton_save_runsafe_limit_h;

		private bool mIsDeltaNozzle_SingleMode;

		private Label[] label_baseH_Zn;

		private Label[] label_baseH_Zn_V;

		private Label[] label_baseH_saferun_Zn;

		private Label[] label_baseH_saferun_Zn_V;

		private Label[] label_baseH_saferun_limited_Zn;

		private Label[] label_baseH_saferun_limited_Zn_V;

		public Label[] label_vaccdelay_Zn;

		public Label[] label_vaccdelay_Zn_V;

		private Label[] label_baseH_camera_Zn;

		private Label[] label_baseH_camera_Zn_V;

		private Label[] label_baseH_Hcam_Zn;

		private Label[] label_baseH_Hcam_Zn_V;

		private TrackBar[] trackBar_color;

		private int test_pic_num;

		private volatile bool mIsFactoryTest;

		public event void_Func_int vsplus_open_fixcampara;

		public event void_Func_VisualPara vsplus_visual_test;

		public event void_Func_int vsplus_open_visualshow;

		public event void_Func_int vsplus_factory_capture;

		public event bool_Func_void vsplus_nozzledelta_auto_center_loop;

		public event void_Func_int vsplus_restart_camerapreview;

		public event void_Func_int vsplus_test_previewoffset;

		public event void_Func_int vsplus_start_fcam_auto_calibration;

		public event void_Func_int vsplus_start_hcam_auto_calibration;

		public event void_Func_int vsplus_start_hcam_singel_calibration;

		public event void_Func_string vsplus_visual_algorithms_debug;

		public event void_Func_string vsplus_visual_algorithms_running_debug;

		public event bool_Func_string vsplus_visual_algorithms;

		private void init_visual()
		{
			checkBox_debug_isSaveErrBitmap.Checked = USR.mDebug_IsSaveErrBitmap;
			if (USR.mDebug_tmpXY == null)
			{
				USR.mDebug_tmpXY = new Coordinate(0L, 0L);
			}
			label_tmpXY.Text = MainForm0.format_XY_label_string(USR.mDebug_tmpXY);
			label_ThrowCoord.Text = MainForm0.format_XY_label_string(USR.mThrowCoord);
		}

		public void set_visual_picture(Bitmap bp)
		{
		}

		private void __button_cam_set_Click(object sender, EventArgs e)
		{
			if (this.vsplus_open_fixcampara != null)
			{
				this.vsplus_open_fixcampara(0);
			}
		}

		private void __button_factory_capture_Click(object sender, EventArgs e)
		{
			if (this.vsplus_factory_capture != null)
			{
				this.vsplus_factory_capture(0);
			}
		}

		private void __button_factory_capture2_Click(object sender, EventArgs e)
		{
			if (this.vsplus_factory_capture != null)
			{
				this.vsplus_factory_capture(1);
			}
		}

		private void __checkBox_debug_isSaveErrBitmap_CheckedChanged(object sender, EventArgs e)
		{
			USR.mDebug_IsSaveErrBitmap = checkBox_debug_isSaveErrBitmap.Checked;
		}

		private void __button_fcam_disable_Click(object sender, EventArgs e)
		{
			Form_CamDisable form_CamDisable = new Form_CamDisable(USR);
			form_CamDisable.ShowDialog();
		}

		private void __button_SaveThrowCoord_Click(object sender, EventArgs e)
		{
			string text = "Are you making sure to update throw XY?";
			string text2 = "确定更新抛料坐标吗？";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text : text2, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mThrowCoord.X = MainForm0.mCur[MainForm0.mFn].x;
				USR.mThrowCoord.Y = MainForm0.mCur[MainForm0.mFn].y;
				label_ThrowCoord.Text = MainForm0.format_XY_label_string(USR.mThrowCoord);
				MainForm0.save_FixedData();
			}
		}

		private void __button_MoveToThrowCoord_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR.mThrowCoord);
			}
		}

		private void __label_ThrowCoord_DoubleClick(object sender, EventArgs e)
		{
			Form_FillXY form_FillXY = new Form_FillXY(USR.mThrowCoord, USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mThrowCoord = form_FillXY.Get_FillXY();
				label_ThrowCoord.Text = MainForm0.format_XY_label_string(USR.mThrowCoord);
			}
		}

		private void __button_tmpXY_Save_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox("确定保存临时坐标?", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (USR.mDebug_tmpXY == null)
				{
					USR.mDebug_tmpXY = new Coordinate();
				}
				USR.mDebug_tmpXY.X = MainForm0.mCur[MainForm0.mFn].x;
				USR.mDebug_tmpXY.Y = MainForm0.mCur[MainForm0.mFn].y;
				label_tmpXY.Text = MainForm0.format_XY_label_string(USR.mDebug_tmpXY);
				MainForm0.save_FixedData();
			}
		}

		private void __button_tmpXY_Goto_Click(object sender, EventArgs e)
		{
			if (USR.mDebug_tmpXY != null && !MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR.mDebug_tmpXY);
			}
		}

		private void init_nozzledelta()
		{
			if (USR.mcir_nz_scanr == 0)
			{
				USR.mcir_nz_scanr = 10;
			}
			numericUpDown_InkWrite_Offset.Value = (decimal)USR.mInkPad_WriteH_Offset;
			numericUpDown_test_scanr.Value = USR.mcir_nz_scanr;
			numericUpDown_test_threshold.Value = USR.mcir_nz_threshold;
			lb_delta_zx_name = new Label[HW.mZnNum[mFn]];
			lb_delta_hx = new Label[HW.mZnNum[mFn]];
			lb_delta2_zx_name = new Label[HW.mZnNum[mFn]];
			lb_delta2_hx = new Label[HW.mZnNum[mFn]];
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				lb_delta_zx_name[i] = new Label();
				lb_delta_hx[i] = new Label();
				lb_delta2_zx_name[i] = new Label();
				lb_delta2_hx[i] = new Label();
				panel_zhadian.Controls.Add(lb_delta_zx_name[i]);
				panel_zhadian.Controls.Add(lb_delta_hx[i]);
				panel_collectink.Controls.Add(lb_delta2_zx_name[i]);
				panel_collectink.Controls.Add(lb_delta2_hx[i]);
				lb_delta_zx_name[i].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (i + 1);
				lb_delta2_zx_name[i].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (i + 1);
				lb_delta_hx[i].Text = Math.Abs(USR.mInkPad_WriteHeight[i]).ToString();
				lb_delta2_hx[i].Text = Math.Abs(USR.mInkPad_CollectHeight[i]).ToString();
				lb_delta_zx_name[i].AutoSize = false;
				lb_delta2_zx_name[i].AutoSize = false;
				lb_delta_hx[i].AutoSize = false;
				lb_delta2_hx[i].AutoSize = false;
				lb_delta_zx_name[i].Size = new Size(50, 20);
				lb_delta2_zx_name[i].Size = new Size(50, 20);
				lb_delta_hx[i].Size = new Size(50, 20);
				lb_delta2_hx[i].Size = new Size(50, 20);
				lb_delta_zx_name[i].Location = new Point(8 + 60 * i, 3);
				lb_delta2_zx_name[i].Location = new Point(8 + 60 * i, 3);
				lb_delta_hx[i].Location = new Point(8 + 60 * i, 25);
				lb_delta2_hx[i].Location = new Point(8 + 60 * i, 25);
				lb_delta_hx[i].Tag = i;
				lb_delta2_hx[i].Tag = i;
				lb_delta_hx[i].DoubleClick += label_delta_h0_DoubleClick;
				lb_delta2_hx[i].DoubleClick += label_delta2_h0_DoubleClick;
				lb_delta_hx[i].MouseClick += label_Zn_Click;
				lb_delta2_hx[i].MouseClick += label_Zn_Click;
			}
			for (int j = 0; j < 4; j++)
			{
				bt_inkpoint[j] = new Button[HW.mZnNum[mFn]];
				for (int k = 0; k < HW.mZnNum[mFn]; k++)
				{
					bt_inkpoint[j][k] = new Button();
					panel_InkPoint.Controls.Add(bt_inkpoint[j][k]);
					bt_inkpoint[j][k].Location = new Point(10 + j * 25 + k * 30, 10 + j * 25);
					bt_inkpoint[j][k].Size = new Size(15, 15);
					bt_inkpoint[j][k].Tag = new Point(k, j);
					bt_inkpoint[j][k].Click += bt_inkpoint_click;
					bt_inkpoint[j][k].BackColor = Color.White;
				}
				bool[] array = (mInkPointConfirmed[j] = new bool[8]);
			}
			mCurInkPoint = new Point(0, 0);
			if (USR.mInkPad_CollectCoord == null)
			{
				USR.mInkPad_CollectCoord = new Coordinate(42999L, 72942L);
			}
			if (USR.mInkPad_WriteCoord == null)
			{
				USR.mInkPad_WriteCoord = new Coordinate(35659L, 40651L);
			}
			if (USR.mInkPad_WriteHeight == null)
			{
				USR.mInkPad_WriteHeight = new int[8] { -6793, 7079, -7033, 7136, -7231, 7098, -6865, 7005 };
			}
			if (USR.mInkPad_CollectHeight == null)
			{
				USR.mInkPad_CollectHeight = new int[8] { -6115, 6499, -6370, 6643, -6792, 6781, -6492, 6808 };
			}
			label_InkPadCollectCoord.Text = "X" + USR.mInkPad_CollectCoord.X + Environment.NewLine + "Y" + USR.mInkPad_CollectCoord.Y;
			label_InkPadWriteCoord.Text = "X" + USR.mInkPad_WriteCoord.X + Environment.NewLine + "Y" + USR.mInkPad_WriteCoord.Y;
			if (USR.mDeltaNozzle_Detail == null)
			{
				USR.mDeltaNozzle_Detail = new Coordinate[8][];
			}
			for (int l = 0; l < 8; l++)
			{
				if (USR.mDeltaNozzle_Detail[l] == null)
				{
					USR.mDeltaNozzle_Detail[l] = new Coordinate[8];
					for (int m = 0; m < 8; m++)
					{
						USR.mDeltaNozzle_Detail[l][m] = new Coordinate(USR.mDeltaNozzle[0][m].X, USR.mDeltaNozzle[0][m].Y);
					}
				}
			}
		}

		private void label_delta_h0_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mInkPad_WriteHeight[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mInkPad_WriteHeight[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mInkPad_WriteHeight[num] = Math.Abs(USR.mInkPad_WriteHeight[num]);
				}
				lb_delta_hx[num].Text = Math.Abs(USR.mInkPad_WriteHeight[num]).ToString();
			}
		}

		private void label_delta2_h0_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mInkPad_CollectHeight[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mInkPad_CollectHeight[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mInkPad_CollectHeight[num] = Math.Abs(USR.mInkPad_CollectHeight[num]);
				}
				lb_delta2_hx[num].Text = Math.Abs(USR.mInkPad_CollectHeight[num]).ToString();
			}
		}

		private void bt_inkpoint_click(object sender, EventArgs e)
		{
			Thread thread = new Thread(thd_inkpoint);
			thread.IsBackground = true;
			thread.Start(((Button)sender).Tag);
		}

		private void thd_inkpoint(object obj)
		{
			mCurInkPoint = (Point)obj;
			int zn = mCurInkPoint.X;
			int num = mCurInkPoint.Y;
			Invoke((MethodInvoker)delegate
			{
				MainForm0.radiobt_zn[mFn][zn].Checked = true;
			});
			MainForm0.moveToZero_ZA_andWait(mFn);
			if (mIsCenterConfirmed == null || !mIsCenterConfirmed[num][zn])
			{
				long num2 = USR.mDeltaNozzle[0][zn].X;
				long num3 = USR.mDeltaNozzle[0][zn].Y;
				if (num > 0)
				{
					num2 = USR.mDeltaNozzle_Detail[num - 1][zn].X;
					num3 = USR.mDeltaNozzle_Detail[num - 1][zn].Y;
				}
				MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(USR.mInkPad_WriteCoord.X + num2 + num * 1000, USR.mInkPad_WriteCoord.Y + num3 + num * 1000));
			}
			else
			{
				MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(USR.mInkPad_WriteCoord.X + USR.mDeltaNozzle_Detail[num][zn].X + num * 1000, USR.mInkPad_WriteCoord.Y + USR.mDeltaNozzle_Detail[num][zn].Y + num * 1000));
			}
		}

		private void __button_AutoGen_InkWriteH_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				float hmm = USR.mBaseHeightmm[i] + USR.mInkPad_WriteH_Offset;
				int num = USR.mInkPad_WriteHeight[i];
				USR.mInkPad_WriteHeight[i] = MainForm0.format_Hmm_to_H(hmm) * ((i % 2 != 0) ? 1 : (-1));
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mInkPad_WriteHeight[i] = Math.Abs(USR.mInkPad_WriteHeight[i]);
				}
				try
				{
					lb_delta_hx[i].Text = Math.Abs(USR.mInkPad_WriteHeight[i]).ToString();
				}
				catch (Exception)
				{
					USR.mInkPad_WriteHeight[i] = num;
					MainForm0.write_to_logFile_EXCEPTION("请先设置[PCB基准参数]，再做此操作！");
					MainForm0.CmMessageBoxTop_Ok("请先设置[PCB基准参数]，再做此操作！");
					break;
				}
			}
		}

		private void __button_AutoGen_InkCollectH_Click(object sender, EventArgs e)
		{
			float num = Math.Abs(MainForm0.format_H_to_Hmm(USR.mInkPad_CollectHeight[0]));
			float num2 = num - Math.Abs(USR.mBaseHeightmm[0]);
			for (int i = 1; i < HW.mZnNum[mFn]; i++)
			{
				float hmm = USR.mBaseHeightmm[i] + num2;
				USR.mInkPad_CollectHeight[i] = MainForm0.format_Hmm_to_H(hmm) * ((i % 2 != 0) ? 1 : (-1));
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mInkPad_CollectHeight[i] = Math.Abs(USR.mInkPad_CollectHeight[i]);
				}
				lb_delta2_hx[i].Text = Math.Abs(USR.mInkPad_CollectHeight[i]).ToString();
			}
		}

		private void __button_SaveInkPadWriteHeight_Click(object sender, EventArgs e)
		{
			USR.mInkPad_WriteHeight[MainForm0.mZn[mFn]] = MainForm0.mCur[mFn].z[MainForm0.mZn[mFn]];
			lb_delta_hx[MainForm0.mZn[mFn]].Text = Math.Abs(USR.mInkPad_WriteHeight[MainForm0.mZn[mFn]]).ToString();
		}

		private void __button_MoveToInkPadWriteHeight_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(USR.mInkPad_WriteHeight[MainForm0.mZn[mFn]]);
			}
		}

		private void __button_SaveInkPadWriteCoord_Click(object sender, EventArgs e)
		{
			USR.mInkPad_WriteCoord.X = MainForm0.mCur[mFn].x;
			USR.mInkPad_WriteCoord.Y = MainForm0.mCur[mFn].y;
			label_InkPadWriteCoord.Text = "X" + USR.mInkPad_WriteCoord.X + Environment.NewLine + "Y" + USR.mInkPad_WriteCoord.Y;
		}

		private void __button_MoveToInkPadWriteCoord_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				MainForm0.msdelay(10);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR.mInkPad_WriteCoord);
			}
		}

		private void __button_SaveInkPadCollectCoord_Click(object sender, EventArgs e)
		{
			USR.mInkPad_CollectCoord.X = MainForm0.mCur[mFn].x;
			USR.mInkPad_CollectCoord.Y = MainForm0.mCur[mFn].y;
			label_InkPadCollectCoord.Text = "X" + USR.mInkPad_CollectCoord.X + Environment.NewLine + "Y" + USR.mInkPad_CollectCoord.Y;
		}

		private void __button_MoveToInkPadCollectCoord_Click(object sender, EventArgs e)
		{
			MainForm0.write_to_logFile_hand("HAND: button_MoveToInkPadCollectCoord_Click: mMutexMoveXYZA=" + (MainForm0.mMutexMoveXYZA ? "true" : "false") + Environment.NewLine);
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				MainForm0.msdelay(10);
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR.mInkPad_CollectCoord);
			}
		}

		private void __button_SaveInkPadCollectHeight_Click(object sender, EventArgs e)
		{
			USR.mInkPad_CollectHeight[MainForm0.mZn[mFn]] = MainForm0.mCur[mFn].z[MainForm0.mZn[mFn]];
			lb_delta2_hx[MainForm0.mZn[mFn]].Text = Math.Abs(USR.mInkPad_CollectHeight[MainForm0.mZn[mFn]]).ToString();
		}

		private void __button_MoveToInkPadCollectHeight_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(USR.mInkPad_CollectHeight[MainForm0.mZn[mFn]]);
			}
		}

		private void __label_InkPadWriteCoord_DoubleClick(object sender, EventArgs e)
		{
			Form_FillXY form_FillXY = new Form_FillXY(USR.mInkPad_WriteCoord, USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mInkPad_WriteCoord = form_FillXY.Get_FillXY();
				label_InkPadWriteCoord.Text = MainForm0.format_XY_label_string(USR.mInkPad_WriteCoord);
			}
		}

		private void __label_InkPadCollectCoord_DoubleClick(object sender, EventArgs e)
		{
			Form_FillXY form_FillXY = new Form_FillXY(USR.mInkPad_CollectCoord, USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mInkPad_CollectCoord = form_FillXY.Get_FillXY();
				label_InkPadCollectCoord.Text = MainForm0.format_XY_label_string(USR.mInkPad_CollectCoord);
			}
		}

		private void init_feeder()
		{
			label_slotxy = new Label[4] { label_slotxy0, label_slotxy1, label_slotxy2, label_slotxy3 };
			if (USR.mSlot4ConnerCoord == null)
			{
				USR.mSlot4ConnerCoord = new Coordinate[4];
				for (int i = 0; i < 4; i++)
				{
					USR.mSlot4ConnerCoord[i] = new Coordinate(0L, 0L);
				}
			}
			for (int j = 0; j < 4; j++)
			{
				label_slotxy[j].Tag = j;
				label_slotxy[j].Text = MainForm0.format_XY_label_string(USR.mSlot4ConnerCoord[j]);
				label_slotxy[j].DoubleClick += label_slotxy_DoubleClick;
				if (j == mSlotCornerIndex)
				{
					label_slotxy[j].BackColor = Color.WhiteSmoke;
				}
				else
				{
					label_slotxy[j].BackColor = Color.Gray;
				}
				label_slotxy[j].MouseClick += label_slotxy_MouseClick;
			}
			if (USR.mSlotAllCoord == null)
			{
				USR.mSlotAllCoord = new Coordinate[160];
				for (int k = 0; k < 160; k++)
				{
					USR.mSlotAllCoord[k] = new Coordinate(0L, 0L);
				}
			}
			else if (USR.mSlotAllCoord.Count() < 160)
			{
				Coordinate[] array = new Coordinate[USR.mSlotAllCoord.Count()];
				for (int l = 0; l < USR.mSlotAllCoord.Count(); l++)
				{
					array[l] = new Coordinate(USR.mSlotAllCoord[l]);
				}
				USR.mSlotAllCoord = new Coordinate[160];
				for (int m = 0; m < 160; m++)
				{
					if (m < array.Count())
					{
						USR.mSlotAllCoord[m] = new Coordinate(array[m]);
					}
					else
					{
						USR.mSlotAllCoord[m] = new Coordinate(0L, 0L);
					}
				}
			}
			for (int n = 0; n < 160; n++)
			{
				if (USR.mSlotAllCoord[n] == null)
				{
					USR.mSlotAllCoord[n] = new Coordinate(0L, 0L);
				}
			}
			if (mStackNo < 0)
			{
				mStackNo = 0;
			}
			else if (mStackNo >= HW.mStackNum[mFn][0] - 1)
			{
				mStackNo = HW.mStackNum[mFn][0] - 1;
			}
			label_stackNo.Text = (mStackNo + 1).ToString();
			label_stackXY.Text = MainForm0.format_XY_label_string(USR.mSlotAllCoord[mStackNo]);
			string[] array2 = new string[3]
			{
				"前端飞达 (1-" + (HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0]) + "号料站)",
				"前端飛達 (1-" + (HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0]) + "號料站)",
				"Front feeders (No.1 - " + (HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0]) + ")"
			};
			label_feeder_front_info.Text = array2[USR_INIT.mLanguage];
			string[] array3 = new string[3]
			{
				"后端飞达 (" + (HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0] + 1) + "-" + HW.mStackNum[mFn][0] + "号料站)",
				"後端飛達 (" + (HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0] + 1) + "-" + HW.mStackNum[mFn][0] + "號料站)",
				"Back feeders (No." + (HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0] + 1) + " - " + HW.mStackNum[mFn][0] + ")"
			};
			label_feeder_back_info.Text = array3[USR_INIT.mLanguage];
			if (USR.mBaseHeight_feeder == null)
			{
				USR.mBaseHeight_feeder = new int[8] { -6400, 6400, -6400, 6400, -6400, 6400, -6400, 6400 };
			}
			Panel panel = new Panel();
			panel_nozzlebasicHigh_feeder.Controls.Add(panel);
			panel.Size = new Size(502, 50);
			panel.BackColor = Color.AliceBlue;
			panel.BorderStyle = BorderStyle.FixedSingle;
			label_baseH_feeder_Zn = new Label[HW.mZnNum[mFn]];
			label_baseH_feeder_Zn_V = new Label[HW.mZnNum[mFn]];
			for (int num = 0; num < HW.mZnNum[mFn]; num++)
			{
				label_baseH_feeder_Zn[num] = new Label();
				label_baseH_feeder_Zn[num].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (num + 1);
				label_baseH_feeder_Zn[num].AutoSize = false;
				panel.Controls.Add(label_baseH_feeder_Zn[num]);
				label_baseH_feeder_Zn[num].Location = new Point(8 + 60 * num, 0);
				label_baseH_feeder_Zn[num].Size = new Size(60, 20);
				label_baseH_feeder_Zn[num].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label_baseH_feeder_Zn[num].Tag = num;
				label_baseH_feeder_Zn[num].ForeColor = Color.Black;
				label_baseH_feeder_Zn[num].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_feeder_Zn[num].MouseClick += label_Zn_Click;
				label_baseH_feeder_Zn_V[num] = new Label();
				label_baseH_feeder_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_feeder[num]).ToString();
				label_baseH_feeder_Zn_V[num].AutoSize = false;
				panel.Controls.Add(label_baseH_feeder_Zn_V[num]);
				label_baseH_feeder_Zn_V[num].Location = new Point(8 + 60 * num, 25);
				label_baseH_feeder_Zn_V[num].Size = new Size(60, 20);
				label_baseH_feeder_Zn_V[num].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label_baseH_feeder_Zn_V[num].Tag = num;
				label_baseH_feeder_Zn_V[num].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_feeder_Zn_V[num].DoubleClick += label_baseH_feeder_Zn_V_DoubleClick;
				label_baseH_feeder_Zn_V[num].MouseClick += label_Zn_Click;
			}
			label_baseH_feeder_Zn[0].BackColor = Color.AliceBlue;
			label_baseH_feeder_Zn_V[0].BackColor = Color.AliceBlue;
			if (USR.mBaseHeight_feederBk == null)
			{
				USR.mBaseHeight_feederBk = new int[8] { -6400, 6400, -6400, 6400, -6400, 6400, -6400, 6400 };
			}
			Panel panel2 = new Panel();
			panel_nozzlebasicHigh_feederBk.Controls.Add(panel2);
			panel2.Size = new Size(502, 50);
			panel2.BackColor = Color.AliceBlue;
			panel2.BorderStyle = BorderStyle.FixedSingle;
			label_baseH_feederBk_Zn = new Label[HW.mZnNum[mFn]];
			label_baseH_feederBk_Zn_V = new Label[HW.mZnNum[mFn]];
			for (int num2 = 0; num2 < HW.mZnNum[mFn]; num2++)
			{
				label_baseH_feederBk_Zn[num2] = new Label();
				label_baseH_feederBk_Zn[num2].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (num2 + 1);
				panel2.Controls.Add(label_baseH_feederBk_Zn[num2]);
				label_baseH_feederBk_Zn[num2].Location = new Point(8 + 60 * num2, 0);
				label_baseH_feederBk_Zn[num2].Size = new Size(60, 20);
				label_baseH_feederBk_Zn[num2].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label_baseH_feederBk_Zn[num2].Tag = num2;
				label_baseH_feederBk_Zn[num2].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_feederBk_Zn[num2].MouseClick += label_Zn_Click;
				label_baseH_feederBk_Zn_V[num2] = new Label();
				label_baseH_feederBk_Zn_V[num2].Text = Math.Abs(USR.mBaseHeight_feederBk[num2]).ToString();
				panel2.Controls.Add(label_baseH_feederBk_Zn_V[num2]);
				label_baseH_feederBk_Zn_V[num2].Location = new Point(8 + 60 * num2, 25);
				label_baseH_feederBk_Zn_V[num2].Size = new Size(60, 20);
				label_baseH_feederBk_Zn_V[num2].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label_baseH_feederBk_Zn_V[num2].Tag = num2;
				label_baseH_feederBk_Zn_V[num2].Anchor = AnchorStyles.None;
				label_baseH_feederBk_Zn_V[num2].TextAlign = ContentAlignment.MiddleLeft;
				label_baseH_feederBk_Zn_V[num2].DoubleClick += label_baseH_feederBk_Zn_V_DoubleClick;
				label_baseH_feederBk_Zn_V[num2].MouseClick += label_Zn_Click;
			}
			label_baseH_feederBk_Zn[0].BackColor = Color.AliceBlue;
			label_baseH_feederBk_Zn_V[0].BackColor = Color.AliceBlue;
		}

		private void label_slotxy_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mSlot4ConnerCoord[num], USR_INIT.mLanguage, "XY");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				Coordinate fillXY = form_FillXY.Get_FillXY();
				USR.mSlot4ConnerCoord[num].X = fillXY.X;
				USR.mSlot4ConnerCoord[num].Y = fillXY.Y;
				label_slotxy[num].Text = MainForm0.format_XY_label_string(USR.mSlot4ConnerCoord[num]);
			}
		}

		private void label_slotxy_MouseClick(object sender, MouseEventArgs e)
		{
			int num = (mSlotCornerIndex = (int)((Label)sender).Tag);
			for (int i = 0; i < 4; i++)
			{
				if (i == mSlotCornerIndex)
				{
					label_slotxy[i].BackColor = Color.WhiteSmoke;
				}
				else
				{
					label_slotxy[i].BackColor = Color.Gray;
				}
			}
		}

		private void label_baseH_feeder_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight_feeder[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mBaseHeight_feeder[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mBaseHeight_feeder[num] = Math.Abs(USR.mBaseHeight_feeder[num]);
				}
				label_baseH_feeder_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_feeder[num]).ToString();
			}
		}

		private void label_baseH_feederBk_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight_feederBk[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mBaseHeight_feederBk[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mBaseHeight_feederBk[num] = Math.Abs(USR.mBaseHeight_feederBk[num]);
				}
				label_baseH_feederBk_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_feederBk[num]).ToString();
			}
		}

		private void showfeederxy_paint()
		{
			int[] array = new int[2]
			{
				HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].emp_m[0] + HW.malgo2[mFn].slt_r[0],
				HW.malgo2[mFn].slt_l[1] + HW.malgo2[mFn].emp_m[1] + HW.malgo2[mFn].slt_r[1]
			};
			if (array[0] < 1 || array[1] < 1)
			{
				return;
			}
			int num = panel_showfeederxy.Size.Width - 20;
			int num2 = panel_showfeederxy.Size.Height - 20;
			_ = USR.mSlot4ConnerCoord[1].X;
			_ = USR.mSlot4ConnerCoord[0].X;
			_ = USR.mSlot4ConnerCoord[2].Y;
			_ = USR.mSlot4ConnerCoord[0].Y;
			Graphics graphics = panel_showfeederxy.CreateGraphics();
			graphics.Clear(Color.LightBlue);
			SolidBrush solidBrush = new SolidBrush(Color.White);
			SolidBrush brush = new SolidBrush(Color.Red);
			Pen pen = new Pen(Color.Black, 1f);
			int num3 = 0;
			for (int i = 0; i < 2; i++)
			{
				int num4 = num / (array[i] - 1);
				for (int j = 0; j < array[i]; j++)
				{
					int num5 = -1;
					switch (i)
					{
					case 0:
						if (j >= 0 && j < HW.malgo2[mFn].slt_l[i])
						{
							num5 = j;
						}
						else if (j >= HW.malgo2[mFn].slt_l[i] + HW.malgo2[mFn].emp_m[i] && j < array[i])
						{
							num5 = j - HW.malgo2[mFn].emp_m[i];
						}
						break;
					case 1:
						if (j >= 0 && j < HW.malgo2[mFn].slt_l[i])
						{
							num5 = j + HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0];
						}
						else if (j >= HW.malgo2[mFn].slt_l[i] + HW.malgo2[mFn].emp_m[i] && j < array[i])
						{
							num5 = j + HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0] - HW.malgo2[mFn].emp_m[i];
						}
						break;
					}
					if (num5 != -1)
					{
						num3++;
						int num6 = j * num4 + 10;
						int num7 = (1 - i) * (num2 - 15) + 10;
						if (j == 0 || j == array[i] - 1)
						{
							graphics.FillRectangle(brush, num6, num7, 6, 16);
							graphics.DrawString(num3.ToString(), new Font("黑体", 12f, FontStyle.Bold), new SolidBrush(Color.Black), num6 + ((j == 0) ? (-5) : (-12)), num7 + ((i == 0) ? (-20) : 20));
						}
						else
						{
							graphics.FillRectangle(solidBrush, num6, num7, 6, 16);
						}
						graphics.DrawRectangle(pen, num6, num7, 6, 16);
					}
				}
			}
			solidBrush.Dispose();
			pen.Dispose();
			graphics.Dispose();
		}

		private void __button_slotSaveXY_Click(object sender, EventArgs e)
		{
			USR.mSlot4ConnerCoord[mSlotCornerIndex].X = MainForm0.mCur[mFn].x;
			USR.mSlot4ConnerCoord[mSlotCornerIndex].Y = MainForm0.mCur[mFn].y;
			label_slotxy[mSlotCornerIndex].Text = MainForm0.format_XY_label_string(USR.mSlot4ConnerCoord[mSlotCornerIndex]);
			MainForm0.save_FixedData();
		}

		private void __button_slotMoveToXY_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR.mSlot4ConnerCoord[mSlotCornerIndex]);
			}
		}

		private void __button_SlotsXYGens_Click(object sender, EventArgs e)
		{
			int[] array = new int[2]
			{
				HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0] + HW.malgo2[mFn].emp_m[0],
				HW.malgo2[mFn].slt_l[1] + HW.malgo2[mFn].slt_r[1] + ((HW.malgo2[mFn].slt_r[1] != 0) ? HW.malgo2[mFn].emp_m[1] : 0)
			};
			if (array[0] < 1 && array[1] < 1)
			{
				MainForm0.CmMessageBoxTop_Ok("EXIT!");
				return;
			}
			for (int i = 0; i < 2; i++)
			{
				double num = (double)(USR.mSlot4ConnerCoord[1 + (1 - i) * 2].X - USR.mSlot4ConnerCoord[(1 - i) * 2].X) / (double)(array[i] - 1);
				double num2 = (double)(USR.mSlot4ConnerCoord[1 + (1 - i) * 2].Y - USR.mSlot4ConnerCoord[(1 - i) * 2].Y) / (double)(array[i] - 1);
				for (int j = 0; j < array[i]; j++)
				{
					int num3 = -1;
					switch (i)
					{
					case 0:
						if (j >= 0 && j < HW.malgo2[mFn].slt_l[0])
						{
							num3 = j;
						}
						else if (j >= HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].emp_m[0] && j < array[i])
						{
							num3 = j - HW.malgo2[mFn].emp_m[0];
						}
						break;
					case 1:
						if (j >= 0 && j < HW.malgo2[mFn].slt_l[1])
						{
							num3 = j + HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0];
						}
						else if (j >= HW.malgo2[mFn].slt_l[1] + HW.malgo2[mFn].emp_m[1] && j < array[i])
						{
							num3 = j + HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0] - HW.malgo2[mFn].emp_m[1];
						}
						break;
					}
					if (num3 != -1)
					{
						USR.mSlotAllCoord[num3].X = (long)((double)USR.mSlot4ConnerCoord[(1 - i) * 2].X + (double)j * num + 0.5);
						USR.mSlotAllCoord[num3].Y = (long)((double)USR.mSlot4ConnerCoord[(1 - i) * 2].Y + (double)j * num2 + 0.5);
					}
				}
			}
			MainForm0.save_FixedData();
			string path = "../configdata/" + STR.DEV_[(int)MainForm0.USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin";
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
			USR2_DATA uSR2_DATA = (USR2_DATA)formatter.Deserialize(stream);
			stream.Close();
			if (uSR2_DATA != null)
			{
				if (uSR2_DATA.mStackLib == null)
				{
					uSR2_DATA.mStackLib = new USR_STACKLIB();
				}
				if (uSR2_DATA.mStackLib.stacktab[0] != null)
				{
					for (int k = 0; k < HW.mStackNum[mFn][0]; k++)
					{
						uSR2_DATA.mStackLib.stacktab[0][k].mXY.X = USR.mSlotAllCoord[k].X;
						uSR2_DATA.mStackLib.stacktab[0][k].mXY.Y = USR.mSlotAllCoord[k].Y;
					}
					MainForm0.save_FixedData();
				}
			}
			IFormatter formatter2 = new BinaryFormatter();
			Stream stream2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter2.Serialize(stream2, uSR2_DATA);
			stream2.Close();
			MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Complete!" : "完成设置！");
		}

		private void __button_slotxy_to_curUsr2_Click(object sender, EventArgs e)
		{
			if (MainForm0.USR2[mFn] == null)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Invalid operation, since there is not open project!" : "没有打开的工程，此操作无效！");
			}
			else if (MainForm0.USR2[mFn].mStackLib.stacktab[0] != null && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "The operation will modified " : "此操作将修改所有的料站取料坐标，是否继续？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < HW.mStackNum[mFn][0]; i++)
				{
					MainForm0.USR2[mFn].mStackLib.stacktab[0][i].mXY.X = USR.mSlotAllCoord[i].X;
					MainForm0.USR2[mFn].mStackLib.stacktab[0][i].mXY.Y = USR.mSlotAllCoord[i].Y;
				}
				MainForm0.save_usrProjectData();
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Complete!" : "完成同步！");
			}
		}

		private void __label_stackNo_Click(object sender, EventArgs e)
		{
			Form_FillXY form_FillXY = new Form_FillXY(mStackNo + 1, USR_INIT.mLanguage, "V_I", 1, HW.mStackNum[mFn][0], "料站号选择");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				mStackNo = form_FillXY.Get_Fill_V_I() - 1;
				label_stackNo.Text = (mStackNo + 1).ToString();
				string text3 = (label_stackXY.Text = (label_stackXY.Text = MainForm0.format_XY_label_string(USR.mSlotAllCoord[mStackNo])));
			}
		}

		private void __button_gotoSlot_Click(object sender, EventArgs e)
		{
			if (mStackNo >= 0 && mStackNo < HW.mStackNum[mFn][0] && USR.mSlotAllCoord != null && !MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR.mSlotAllCoord[mStackNo]);
			}
		}

		private void __button_gotoSlot_byZn_Click(object sender, EventArgs e)
		{
			if (mStackNo >= 0 && mStackNo < HW.mStackNum[mFn][0] && USR.mSlotAllCoord != null && !MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				Coordinate coordinate = new Coordinate();
				coordinate.X = USR.mSlotAllCoord[mStackNo].X - (int)USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].X;
				coordinate.Y = USR.mSlotAllCoord[mStackNo].Y - (int)USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].Y;
				thread.Start(coordinate);
			}
		}

		private void __button_saveSlot_Click(object sender, EventArgs e)
		{
			if (mStackNo >= 0 && mStackNo < HW.mStackNum[mFn][0] && USR.mSlotAllCoord != null)
			{
				USR.mSlotAllCoord[mStackNo].X = MainForm0.mCur[mFn].x;
				USR.mSlotAllCoord[mStackNo].Y = MainForm0.mCur[mFn].y;
				label_stackXY.Text = MainForm0.format_XY_label_string(USR.mSlotAllCoord[mStackNo]);
				MainForm0.save_FixedData();
			}
		}

		private void __button_slotOpen_Click(object sender, EventArgs e)
		{
			if (mStackNo >= 0 && mStackNo < HW.mStackNum[mFn][0])
			{
				MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, mStackNo, flag: true);
			}
		}

		private void __button_slotClose_Click(object sender, EventArgs e)
		{
			if (mStackNo >= 0 && mStackNo < HW.mStackNum[mFn][0])
			{
				MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, mStackNo, flag: false);
			}
		}

		private void __button_feederBaseH_Save_Click(object sender, EventArgs e)
		{
			string text = (string)((Button)sender).Tag;
			if (text == "front")
			{
				USR.mBaseHeight_feeder[MainForm0.mZn[mFn]] = MainForm0.mCur[mFn].z[MainForm0.mZn[mFn]];
				label_baseH_feeder_Zn_V[MainForm0.mZn[mFn]].Text = Math.Abs(USR.mBaseHeight_feeder[MainForm0.mZn[mFn]]).ToString();
			}
			else if (text == "back")
			{
				USR.mBaseHeight_feederBk[MainForm0.mZn[mFn]] = MainForm0.mCur[mFn].z[MainForm0.mZn[mFn]];
				label_baseH_feederBk_Zn_V[MainForm0.mZn[mFn]].Text = Math.Abs(USR.mBaseHeight_feederBk[MainForm0.mZn[mFn]]).ToString();
			}
		}

		private void __button_feederBaseH_Goto_Click(object sender, EventArgs e)
		{
			string text = (string)((Button)sender).Tag;
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				if (text == "front")
				{
					thread.Start(USR.mBaseHeight_feeder[MainForm0.mZn[mFn]]);
				}
				else if (text == "back")
				{
					thread.Start(USR.mBaseHeight_feederBk[MainForm0.mZn[mFn]]);
				}
			}
		}

		private void __button_feederBaseH_AutoGen_Click(object sender, EventArgs e)
		{
			string text = (string)((Button)sender).Tag;
			if (text == "front")
			{
				float num = Math.Abs(MainForm0.format_H_to_Hmm(USR.mBaseHeight_feeder[0]));
				float num2 = num - Math.Abs(USR.mBaseHeightmm[0]);
				for (int i = 1; i < HW.mZnNum[mFn]; i++)
				{
					float hmm = USR.mBaseHeightmm[i] + num2;
					USR.mBaseHeight_feeder[i] = MainForm0.format_Hmm_to_H(hmm) * ((i % 2 != 0) ? 1 : (-1));
					if (HW.mSmtGenerationNo == 2)
					{
						USR.mBaseHeight_feeder[i] = Math.Abs(USR.mBaseHeight_feeder[i]);
					}
					label_baseH_feeder_Zn_V[i].Text = Math.Abs(USR.mBaseHeight_feeder[i]).ToString();
				}
			}
			else
			{
				if (!(text == "back"))
				{
					return;
				}
				float num3 = Math.Abs(MainForm0.format_H_to_Hmm(USR.mBaseHeight_feederBk[0]));
				float num4 = num3 - Math.Abs(USR.mBaseHeightmm[0]);
				for (int j = 1; j < HW.mZnNum[mFn]; j++)
				{
					float hmm2 = USR.mBaseHeightmm[j] + num4;
					USR.mBaseHeight_feederBk[j] = MainForm0.format_Hmm_to_H(hmm2) * ((j % 2 != 0) ? 1 : (-1));
					if (HW.mSmtGenerationNo == 2)
					{
						USR.mBaseHeight_feederBk[j] = Math.Abs(USR.mBaseHeight_feederBk[j]);
					}
					label_baseH_feederBk_Zn_V[j].Text = Math.Abs(USR.mBaseHeight_feederBk[j]).ToString();
				}
			}
		}

		public UserControl_SystemSetting(int fn, USR_DATA usr)
		{
			InitializeComponent();
			mFn = fn;
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			init_camera();
			init_nozzledelta();
			init_base();
			init_feeder();
			init_visual();
			init_visualdebug();
			init_misc();
			init_factory();
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			base.Visible = false;
		}

		private void UserControl_SystemSetting_Load(object sender, EventArgs e)
		{
			flush_byZn();
			init_button();
			showfeederxy_paint();
			MainForm0.common_waiting_break();
		}

		private void init_button()
		{
		}

		public void flush_byZn()
		{
			int num = MainForm0.mZn[mFn];
			int num2 = MainForm0.mZn_prev[mFn];
			label_HighRecognizeCoord.Text = MainForm0.format_XY_label_string(USR.mHighCamRecognizeCoord[0][num]);
			button_SingleSetHighCamCoord.Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (num + 1) + (new string[3] { "校准", "校準", " Calibration" })[USR_INIT.mLanguage];
			Label obj = label_baseH_camera_Zn[num];
			Label obj2 = label_baseH_camera_Zn_V[num];
			Label obj3 = label_baseH_Hcam_Zn[num];
			Font font2 = (label_baseH_Hcam_Zn_V[num].Font = new Font(label_baseH_Hcam_Zn_V[num].Font.FontFamily, label_baseH_camera_Zn[num].Font.Size, FontStyle.Bold));
			Font font4 = (obj3.Font = font2);
			Font font7 = (obj.Font = (obj2.Font = font4));
			Label obj4 = lb_delta_zx_name[num];
			Label obj5 = lb_delta_hx[num];
			Label obj6 = lb_delta2_zx_name[num];
			Font font9 = (lb_delta2_hx[num].Font = new Font(lb_delta2_hx[num].Font.FontFamily, lb_delta2_hx[num].Font.Size, FontStyle.Bold));
			Font font11 = (obj6.Font = font9);
			Font font14 = (obj4.Font = (obj5.Font = font11));
			Label obj7 = label_baseH_feeder_Zn[num];
			Label obj8 = label_baseH_feeder_Zn_V[num];
			Label obj9 = label_baseH_feederBk_Zn[num];
			Font font16 = (label_baseH_feederBk_Zn_V[num].Font = new Font(label_baseH_feeder_Zn[num].Font.FontFamily, label_baseH_feeder_Zn[num].Font.Size, FontStyle.Bold));
			Font font18 = (obj9.Font = font16);
			Font font21 = (obj7.Font = (obj8.Font = font18));
			Label obj10 = label_baseH_Zn[num];
			Label obj11 = label_baseH_Zn_V[num];
			Label obj12 = label_vaccdelay_Zn[num];
			Label obj13 = label_vaccdelay_Zn_V[num];
			Label obj14 = label_baseH_saferun_Zn[num];
			Label obj15 = label_baseH_saferun_Zn_V[num];
			Label obj16 = label_baseH_saferun_limited_Zn[num];
			Font font23 = (label_baseH_saferun_limited_Zn_V[num].Font = new Font(label_baseH_Zn[num].Font.FontFamily, label_baseH_Zn[num].Font.Size, FontStyle.Bold));
			Font font25 = (obj16.Font = font23);
			Font font27 = (obj15.Font = font25);
			Font font29 = (obj14.Font = font27);
			Font font31 = (obj13.Font = font29);
			Font font33 = (obj12.Font = font31);
			Font font36 = (obj10.Font = (obj11.Font = font33));
			if (num2 != -1)
			{
				Label obj17 = label_baseH_camera_Zn[num2];
				Label obj18 = label_baseH_camera_Zn_V[num2];
				Label obj19 = label_baseH_Hcam_Zn[num2];
				Font font38 = (label_baseH_Hcam_Zn_V[num2].Font = new Font(label_baseH_Hcam_Zn_V[num2].Font.FontFamily, label_baseH_camera_Zn[num2].Font.Size, FontStyle.Regular));
				Font font40 = (obj19.Font = font38);
				Font font43 = (obj17.Font = (obj18.Font = font40));
				Label obj20 = lb_delta_zx_name[num2];
				Label obj21 = lb_delta_hx[num2];
				Label obj22 = lb_delta2_zx_name[num2];
				Font font45 = (lb_delta2_hx[num2].Font = new Font(lb_delta2_hx[num2].Font.FontFamily, lb_delta2_hx[num2].Font.Size, FontStyle.Regular));
				Font font47 = (obj22.Font = font45);
				Font font50 = (obj20.Font = (obj21.Font = font47));
				Label obj23 = label_baseH_feeder_Zn[num2];
				Label obj24 = label_baseH_feeder_Zn_V[num2];
				Label obj25 = label_baseH_feederBk_Zn[num2];
				Font font52 = (label_baseH_feederBk_Zn_V[num2].Font = new Font(label_baseH_feeder_Zn[num2].Font.FontFamily, label_baseH_feeder_Zn[num2].Font.Size, FontStyle.Regular));
				Font font54 = (obj25.Font = font52);
				Font font57 = (obj23.Font = (obj24.Font = font54));
				Label obj26 = label_baseH_Zn[num2];
				Label obj27 = label_baseH_Zn_V[num2];
				Label obj28 = label_vaccdelay_Zn[num2];
				Label obj29 = label_vaccdelay_Zn_V[num2];
				Label obj30 = label_baseH_saferun_Zn[num2];
				Label obj31 = label_baseH_saferun_Zn_V[num2];
				Label obj32 = label_baseH_saferun_limited_Zn[num2];
				Font font59 = (label_baseH_saferun_limited_Zn_V[num2].Font = new Font(label_baseH_Zn[num2].Font.FontFamily, label_baseH_Zn[num2].Font.Size, FontStyle.Regular));
				Font font61 = (obj32.Font = font59);
				Font font63 = (obj31.Font = font61);
				Font font65 = (obj30.Font = font63);
				Font font67 = (obj29.Font = font65);
				Font font69 = (obj28.Font = font67);
				Font font72 = (obj26.Font = (obj27.Font = font69));
			}
		}

		private void button_save_basecamera_h_Click(object sender, EventArgs e)
		{
			__button_save_basecamera_h_Click(sender, e);
		}

		private void button_goto_basecamera_h_Click(object sender, EventArgs e)
		{
			__button_goto_basecamera_h_Click(sender, e);
		}

		private void button_goto_basecamera_h_allzn_Click(object sender, EventArgs e)
		{
			__button_goto_basecamera_h_allzn_Click(sender, e);
		}

		private void button_FastCamMoveToCoord_Click(object sender, EventArgs e)
		{
			__button_FastCamMoveToCoord_Click(sender, e);
		}

		private void button_close_fcam_setting_Click(object sender, EventArgs e)
		{
			panel_fcam_setting.Visible = false;
		}

		private void button_fcam_set_Click(object sender, EventArgs e)
		{
			panel_fcam_setting.Visible = true;
		}

		private void button_fcam_distortion_para_Click(object sender, EventArgs e)
		{
			__button_fcam_distortion_para_Click(sender, e);
		}

		private void checkBox_fastcam_oppovisual_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_fastcam_oppovisual_CheckedChanged(sender, e);
		}

		private void checkBox_FCameraCalibrator_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_FCameraCalibrator_CheckedChanged(sender, e);
		}

		private void numericUpDown_fcam__recsize_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_fcam__recsize_ValueChanged(sender, e);
		}

		private void button_AutoSetFastCamCoord_Click(object sender, EventArgs e)
		{
			__button_AutoSetFastCamCoord_Click(sender, e);
		}

		private void numericUpDown_fcam_scanr_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_fcam_scanr_ValueChanged(sender, e);
		}

		private void numericUpDown_fcam_threshold_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_fcam_threshold_ValueChanged(sender, e);
		}

		private void button_save_Hcam_baseH_Click(object sender, EventArgs e)
		{
			__button_save_Hcam_baseH_Click(sender, e);
		}

		private void button_goto_Hcam_baseH_Click(object sender, EventArgs e)
		{
			__button_goto_Hcam_baseH_Click(sender, e);
		}

		private void button_goto_baseHcam_h_allzn_Click(object sender, EventArgs e)
		{
			__button_goto_baseHcam_h_allzn_Click(sender, e);
		}

		private void button_HighCamMoveToCoord_Click(object sender, EventArgs e)
		{
			__button_HighCamMoveToCoord_Click(sender, e);
		}

		private void button_hcam_set_Click(object sender, EventArgs e)
		{
			panel_hcam_setting.Visible = true;
		}

		private void button_close_hcam_setting_Click(object sender, EventArgs e)
		{
			panel_hcam_setting.Visible = false;
		}

		private void checkBox_highcam_oppovisual_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_highcam_oppovisual_CheckedChanged(sender, e);
		}

		private void button_hcam_distortion_para_Click(object sender, EventArgs e)
		{
			__button_hcam_distortion_para_Click(sender, e);
		}

		private void numericUpDown_hcam_liebian_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_hcam_liebian_ValueChanged(sender, e);
		}

		private void numericUpDown_hcam_rec_size_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_hcam_rec_size_ValueChanged(sender, e);
		}

		private void button_AutoSetHighCamCoord_Click(object sender, EventArgs e)
		{
			__button_AutoSetHighCamCoord_Click(sender, e);
		}

		private void button_SingleSetHighCamCoord_Click(object sender, EventArgs e)
		{
			__button_SingleSetHighCamCoord_Click(sender, e);
		}

		private void numericUpDown_hcam_scanr_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_hcam_scanr_ValueChanged(sender, e);
		}

		private void numericUpDown_hcam_threshold_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_hcam_threshold_ValueChanged(sender, e);
		}

		private void button_fcam_visualtest_Click(object sender, EventArgs e)
		{
			__button_fcam_visualtest_Click(sender, e);
		}

		private void button_hcam_visualtest_Click(object sender, EventArgs e)
		{
			__button_hcam_visualtest_Click(sender, e);
		}

		private void nud_MarkRatio_ValueChanged(object sender, EventArgs e)
		{
			__nud_MarkRatio_ValueChanged(sender, e);
		}

		private void numericUpDown_previewoffset_x_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_previewoffset_x_ValueChanged(sender, e);
		}

		private void button_previewoffset_reset_Click(object sender, EventArgs e)
		{
			__button_previewoffset_reset_Click(sender, e);
		}

		private void button_test_previewoffset_Click(object sender, EventArgs e)
		{
			__button_test_previewoffset_Click(sender, e);
		}

		private void button_AutoGen_InkWriteH_Click(object sender, EventArgs e)
		{
			__button_AutoGen_InkWriteH_Click(sender, e);
		}

		private void button_AutoGen_InkCollectH_Click(object sender, EventArgs e)
		{
			__button_AutoGen_InkCollectH_Click(sender, e);
		}

		private void button_SaveInkPadWriteHeight_Click(object sender, EventArgs e)
		{
			__button_SaveInkPadWriteHeight_Click(sender, e);
		}

		private void button_MoveToInkPadWriteHeight_Click(object sender, EventArgs e)
		{
			__button_MoveToInkPadWriteHeight_Click(sender, e);
		}

		private void button_SaveInkPadWriteCoord_Click(object sender, EventArgs e)
		{
			__button_SaveInkPadWriteCoord_Click(sender, e);
		}

		private void button_MoveToInkPadWriteCoord_Click(object sender, EventArgs e)
		{
			__button_MoveToInkPadWriteCoord_Click(sender, e);
		}

		private void button_SaveInkPadCollectCoord_Click(object sender, EventArgs e)
		{
			__button_SaveInkPadCollectCoord_Click(sender, e);
		}

		private void button_MoveToInkPadCollectCoord_Click(object sender, EventArgs e)
		{
			__button_MoveToInkPadCollectCoord_Click(sender, e);
		}

		private void button_SaveInkPadCollectHeight_Click(object sender, EventArgs e)
		{
			__button_SaveInkPadCollectHeight_Click(sender, e);
		}

		private void button_MoveToInkPadCollectHeight_Click(object sender, EventArgs e)
		{
			__button_MoveToInkPadCollectHeight_Click(sender, e);
		}

		private void numericUpDown_InkWrite_Offset_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mInkPad_WriteH_Offset = (float)numericUpDown_InkWrite_Offset.Value;
			}
		}

		private void label_InkPadWriteCoord_DoubleClick(object sender, EventArgs e)
		{
			__label_InkPadWriteCoord_DoubleClick(sender, e);
		}

		private void label_InkPadCollectCoord_DoubleClick(object sender, EventArgs e)
		{
			__label_InkPadCollectCoord_DoubleClick(sender, e);
		}

		private void checkBox_delta_nozzle_singlemode_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_delta_nozzle_singlemode_CheckedChanged(sender, e);
		}

		private void button_StartZnDelta_Click(object sender, EventArgs e)
		{
			__button_StartZnDelta_Click(sender, e);
		}

		private void button_center_confirm_Click(object sender, EventArgs e)
		{
			__button_center_confirm_Click(sender, e);
		}

		private void button_center_clear_Click(object sender, EventArgs e)
		{
			__button_center_clear_Click(sender, e);
		}

		private void button_deltaDone_Click(object sender, EventArgs e)
		{
			__button_deltaDone_Click(sender, e);
		}

		private void numericUpDown_test_scanr_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mcir_nz_scanr = (int)numericUpDown_test_scanr.Value;
			}
		}

		private void numericUpDown_test_threshold_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mcir_nz_threshold = (int)numericUpDown_test_threshold.Value;
			}
		}

		private void button_auto_deltaDone_Click(object sender, EventArgs e)
		{
			__button_auto_deltaDone_Click(sender, e);
		}

		private void button_auto_deltaDone_Interupt_Click(object sender, EventArgs e)
		{
			__button_auto_deltaDone_Interupt_Click(sender, e);
		}

		private void button_nzdelta_para_check_Click(object sender, EventArgs e)
		{
			__button_nzdelta_para_check_Click(sender, e);
		}

		private void button_switchto_basepage_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 1;
		}

		private void button_slotSaveXY_Click(object sender, EventArgs e)
		{
			__button_slotSaveXY_Click(sender, e);
		}

		private void button_slotMoveToXY_Click(object sender, EventArgs e)
		{
			__button_slotMoveToXY_Click(sender, e);
		}

		private void button_SlotsXYGens_Click(object sender, EventArgs e)
		{
			__button_SlotsXYGens_Click(sender, e);
		}

		private void button_slotxy_to_curUsr2_Click(object sender, EventArgs e)
		{
			__button_slotxy_to_curUsr2_Click(sender, e);
		}

		private void label_stackNo_Click(object sender, EventArgs e)
		{
			__label_stackNo_Click(sender, e);
		}

		private void button_gotoSlot_Click(object sender, EventArgs e)
		{
			__button_gotoSlot_Click(sender, e);
		}

		private void button_gotoSlot_byZn_Click(object sender, EventArgs e)
		{
			__button_gotoSlot_byZn_Click(sender, e);
		}

		private void button_saveSlot_Click(object sender, EventArgs e)
		{
			__button_saveSlot_Click(sender, e);
		}

		private void button_slotOpen_Click(object sender, EventArgs e)
		{
			__button_slotOpen_Click(sender, e);
		}

		private void button_slotClose_Click(object sender, EventArgs e)
		{
			__button_slotClose_Click(sender, e);
		}

		private void button_feederBaseH_Save_Click(object sender, EventArgs e)
		{
			__button_feederBaseH_Save_Click(sender, e);
		}

		private void button_feederBaseH_Goto_Click(object sender, EventArgs e)
		{
			__button_feederBaseH_Goto_Click(sender, e);
		}

		private void button_feederBaseH_AutoGen_Click(object sender, EventArgs e)
		{
			__button_feederBaseH_AutoGen_Click(sender, e);
		}

		private void button_baseH_Save_Click(object sender, EventArgs e)
		{
			__button_baseH_Save_Click(sender, e);
		}

		private void button_baseH_Goto_Click(object sender, EventArgs e)
		{
			__button_baseH_Goto_Click(sender, e);
		}

		private void button_save_runsafe_h_Click(object sender, EventArgs e)
		{
			__button_save_runsafe_h_Click(sender, e);
		}

		private void button_goto_runsafe_h_Click(object sender, EventArgs e)
		{
			__button_goto_runsafe_h_Click(sender, e);
		}

		private void button_vacuum_sync_Click(object sender, EventArgs e)
		{
			__button_vacuum_sync_Click(sender, e);
		}

		private void checkBox_SafeRunMode_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_SafeRunMode_CheckedChanged(sender, e);
		}

		private void button_cam_set_Click(object sender, EventArgs e)
		{
			__button_cam_set_Click(sender, e);
		}

		private void button_factory_capture_Click(object sender, EventArgs e)
		{
			__button_factory_capture_Click(sender, e);
		}

		private void button_factory_capture2_Click(object sender, EventArgs e)
		{
			__button_factory_capture2_Click(sender, e);
		}

		private void checkBox_debug_isSaveErrBitmap_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_debug_isSaveErrBitmap_CheckedChanged(sender, e);
		}

		private void button_fcam_disable_Click(object sender, EventArgs e)
		{
			__button_fcam_disable_Click(sender, e);
		}

		private void button_SaveThrowCoord_Click(object sender, EventArgs e)
		{
			__button_SaveThrowCoord_Click(sender, e);
		}

		private void button_MoveToThrowCoord_Click(object sender, EventArgs e)
		{
			__button_MoveToThrowCoord_Click(sender, e);
		}

		private void label_ThrowCoord_DoubleClick(object sender, EventArgs e)
		{
			__label_ThrowCoord_DoubleClick(sender, e);
		}

		private void button_tmpXY_Save_Click(object sender, EventArgs e)
		{
			__button_tmpXY_Save_Click(sender, e);
		}

		private void button_tmpXY_Goto_Click(object sender, EventArgs e)
		{
			__button_tmpXY_Goto_Click(sender, e);
		}

		private void button_FactoryTestAll_Start_Click(object sender, EventArgs e)
		{
			__button_FactoryTestAll_Start_Click(sender, e);
		}

		private void button_FactoryTestAll_Stop_Click(object sender, EventArgs e)
		{
			__button_FactoryTestAll_Stop_Click(sender, e);
		}

		private void numericUpDown_factorytestall_hour_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_factorytestall_hour_ValueChanged(sender, e);
		}

		private void button_FactoryTest_Start_Click(object sender, EventArgs e)
		{
			__button_FactoryTest_Start_Click(sender, e);
		}

		private void button_FactoryTest_Stop_Click(object sender, EventArgs e)
		{
			__button_FactoryTest_Stop_Click(sender, e);
		}

		private void numericUpDown_factorytest_count_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_factorytest_count_ValueChanged(sender, e);
		}

		private void button_FactoryTest_OpenFeeder_Click(object sender, EventArgs e)
		{
			__button_FactoryTest_OpenFeeder_Click(sender, e);
		}

		private void button_FactoryTest_CloseFeeder_Click(object sender, EventArgs e)
		{
			__button_FactoryTest_CloseFeeder_Click(sender, e);
		}

		private void button_FactoryTest_AutoFeeder_Click(object sender, EventArgs e)
		{
			__button_FactoryTest_AutoFeeder_Click(sender, e);
		}

		private void numericUpDown_FactoryTest_feederNum_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_FactoryTest_feederNum_ValueChanged(sender, e);
		}

		private void numericUpDown_AutoFeeder_Delay_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_AutoFeeder_Delay_ValueChanged(sender, e);
		}

		private void checkBox_AutoFeeder_Inc_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_AutoFeeder_Inc_CheckedChanged(sender, e);
		}

		private void btn_HideSetting_Click(object sender, EventArgs e)
		{
			__btn_HideSetting_Click(sender, e);
		}

		private void button_algorithm_debug_running_Click(object sender, EventArgs e)
		{
			__button_algorithm_debug_running_Click(sender, e);
		}

		private void button_algorithm_debug_Click(object sender, EventArgs e)
		{
			__button_algorithm_debug_Click(sender, e);
		}

		private void button_algorithm_debugauto_Click(object sender, EventArgs e)
		{
			__button_algorithm_debugauto_Click(sender, e);
		}

		private void button_testfolder_Click(object sender, EventArgs e)
		{
			__button_testfolder_Click(sender, e);
		}

		private void checkBox_factoryDebug_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_factoryDebug_CheckedChanged(sender, e);
		}

		private void numericUpDown_factoryvisualtest_angle_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_factoryvisualtest_angle_ValueChanged(sender, e);
		}

		private void numericUpDown_pic_idx_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_pic_idx_ValueChanged(sender, e);
		}

		private void textBox_testfolder_TextChanged(object sender, EventArgs e)
		{
			__textBox_testfolder_TextChanged(sender, e);
		}

		private void label_Zn_Click(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			if (num != -1)
			{
				num %= 8;
				if (num >= 0 && num < HW.mZnNum[MainForm0.mFn])
				{
					MainForm0.radiobt_zn[MainForm0.mFn][num].Checked = true;
				}
			}
		}

		public void set_pausestop_visable(string cmd, bool flag)
		{
			if (flag)
			{
				if (cmd == "cam")
				{
					Invoke((MethodInvoker)delegate
					{
						tabPage_fix_cam.Controls.Add(panel_pausestop);
						panel_pausestop.Location = new Point(-4, 684);
						panel_pausestop.BringToFront();
					});
				}
				else if (cmd == "nozzledelta")
				{
					Invoke((MethodInvoker)delegate
					{
						tabPage_fix_nozzledelta.Controls.Add(panel_pausestop);
						panel_pausestop.Location = new Point(panel46.Location.X, panel46.Location.Y);
						panel_pausestop.BringToFront();
					});
				}
			}
			Invoke((MethodInvoker)delegate
			{
				panel_pausestop.Visible = flag;
			});
		}

		private void button_pause_Click(object sender, EventArgs e)
		{
			MainForm0.mRunDoing[mFn] = 1;
		}

		private void button_resume_Click(object sender, EventArgs e)
		{
			MainForm0.mRunDoing[mFn] = 0;
		}

		private void button_stop_Click(object sender, EventArgs e)
		{
			MainForm0.mRunDoing[mFn] |= 2;
			panel_pausestop.Visible = false;
		}

		private void panel_showfeederxy_Paint(object sender, PaintEventArgs e)
		{
			showfeederxy_paint();
		}

		private void button_switchto_campage_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 0;
		}

		private void button_fcam_campara_Click(object sender, EventArgs e)
		{
			if (this.vsplus_open_fixcampara != null)
			{
				this.vsplus_open_fixcampara(0);
			}
		}

		private void button_hcam_campara_Click(object sender, EventArgs e)
		{
			if (this.vsplus_open_fixcampara != null)
			{
				this.vsplus_open_fixcampara(1);
			}
		}

		private void tabControl1_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.P == e.KeyCode && e.Shift && e.Control && e.Alt)
			{
				panel_fix_factory.Visible = true;
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_FixSetting,
				str = new string[3] { "机器校准", "機器校準", "Device Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label43,
				str = new string[3] { "● MARK相机校准", "● MARK相機校準", "● Mark Camera Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "● 快速相机校准", "● 快速相機校準", "● Fast Camera Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "● 高清相机校准", "● 高清相機校準", "● High Camera Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_pixel_ratio,
				str = new string[3] { "像素比例", "像素比例", "Pixel Ratio" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label135,
				str = new string[3] { "预览偏量 X", "預覽偏量 X", "Preview Offset X" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label137,
				str = new string[3] { "预览偏量 Y", "預覽偏量 Y", "Preview Offset Y" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_test_previewoffset,
				str = new string[3] { "预览偏量测试", "預覽偏量測試", "Preview Offset Test" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_previewoffset_reset,
				str = new string[3] { "重置", "重置", "Reset" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label74,
				str = new string[3] { "视觉基准高度", "視覺基準高度", "Camera Base Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_save_basecamera_h,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_goto_basecamera_h,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_goto_basecamera_h_allzn,
				str = new string[3] { "全部定位", "全部定位", "Goto All" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label139,
				str = new string[3] { "相机校准", "相機校準", "Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label125,
				str = new string[3] { "相机校准", "相機校準", "Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_FastCamMoveToCoord,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_AutoSetFastCamCoord,
				str = new string[3] { "自动校准", "自動校準", "Auto Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_fcam_distortion_para,
				str = new string[3] { "参数查看", "參數查看", "Para View" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label141,
				str = new string[3] { "识别尺寸", "識別尺寸", "Rec Size" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label25,
				str = new string[3] { "视野参数", "視野參數", "View" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label29,
				str = new string[3] { "扫描半径", "掃描半徑", "Scan-R" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label53,
				str = new string[3] { "视觉阈值", "視覺閾值", "Threshold" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_fcam_visualtest,
				str = new string[3]
				{
					"识别" + Environment.NewLine + "测试",
					"識別" + Environment.NewLine + "測試",
					"Visual" + Environment.NewLine + "Test"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_fcam_campara,
				str = new string[3]
				{
					"光源" + Environment.NewLine + "参数",
					"光源" + Environment.NewLine + "參數",
					"Cam" + Environment.NewLine + "Setting"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label143,
				str = new string[3] { "视觉基准高度", "視覺基準高度", "Camera Base Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_save_Hcam_baseH,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_goto_Hcam_baseH,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_goto_baseHcam_h_allzn,
				str = new string[3] { "全部定位", "全部定位", "Goto All" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_HighCamMoveToCoord,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_AutoSetHighCamCoord,
				str = new string[3] { "自动校准", "自動校準", "Auto Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SingleSetHighCamCoord,
				str = new string[3] { "单吸嘴校准", "單吸嘴校準", "Nozzle Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_hcam_distortion_para,
				str = new string[3] { "参数查看", "參數查看", "Para View" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_pause,
				str = new string[3] { "暂停", "暫停", "Pause" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_resume,
				str = new string[3] { "恢复", "恢復", "Resume" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stop,
				str = new string[3] { "停止", "停止", "Stop" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label218,
				str = new string[3] { "识别尺寸", "識別尺寸", "Rec Size" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label26,
				str = new string[3] { "视野参数", "視野參數", "View" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label57,
				str = new string[3] { "扫描半径", "掃描半徑", "Scan-R" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label54,
				str = new string[3] { "视觉阈值", "視覺閾值", "Threshold" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_hcam_visualtest,
				str = new string[3]
				{
					"识别" + Environment.NewLine + "测试",
					"識別" + Environment.NewLine + "測試",
					"Visual" + Environment.NewLine + "Test"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_hcam_campara,
				str = new string[3]
				{
					"光源" + Environment.NewLine + "参数",
					"光源" + Environment.NewLine + "參數",
					"Cam" + Environment.NewLine + "Setting"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label15,
				str = new string[3] { "视觉设置", "視覺設置", "Visual Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_debug_isSaveErrBitmap,
				str = new string[3] { "保存异常照片", "保存異常照片", "Save Error Picture" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_fastcam_oppovisual,
				str = new string[3] { "快速相机反色视觉", "快速相機反色視覺", "Fast Camera Opposite Visual" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_highcam_oppovisual,
				str = new string[3] { "高清相机反色视觉", "高清相機反色視覺", "High Camera Opposite Visual" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_fcam_disable,
				str = new string[3] { "相机吸嘴禁用", "相機吸嘴禁用", "Camera/Nozzle Disable" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_throwxy,
				str = new string[3] { "抛料坐标", "拋料坐標", "Throw Coord" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label136,
				str = new string[3] { "临时坐标", "臨時坐標", "Temp Coord" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveThrowCoord,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_tmpXY_Save,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MoveToThrowCoord,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_tmpXY_Goto,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_fastcam_note,
				str = new string[3] { "说明：所有贴头安装实心吸嘴，然后将1号吸嘴移动到中心附近，点击“自动校准”", "左移", "Note: Please install solid nozzle, and move nozzle 1 to preview center, then automatic calibrate." }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_highcam_note,
				str = new string[3] { "说明：所有贴头安装实心吸嘴，然后将1号吸嘴移动到中心附近，点击“自动校准”", "左移", "Note: Please install solid nozzle, and move nozzle 1 to preview center, then automatic calibrate." }
			});
			LanguageItem languageItem = new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabControl1
			};
			string[] array = (languageItem.str = new string[3]);
			list.Add(languageItem);
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage_fix_cam,
				str = new string[3] { "相机校准", "相機校準", "Camera Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage_fix_base,
				str = new string[3] { "固定参数", "固定參數", "Fixed Parameter" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage_fix_nozzledelta,
				str = new string[3] { "吸嘴偏量", "吸嘴偏量", "Nozzle Delta" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage_fix_feeder,
				str = new string[3] { "料站校准", "料站校準", "Feeder Base" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage_fix_factory,
				str = new string[3] { "出厂测试", "出廠測試", "Factory Test" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label16,
				str = new string[3] { "● PCB基准高度", "● PCB基準高度", "● PCB Base Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label75,
				str = new string[3] { "● 工作安全高度", "● 工作安全高度", "● SMT Safety Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label132,
				str = new string[3] { "● 吸嘴破真空时间", "● 吸嘴破真空時間", "● Nozzle Break Vacuum Time" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label40,
				str = new string[3] { "贴头吸嘴", "貼頭吸嘴", "Nozzles" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label39,
				str = new string[3] { "PCB板", "PCB板", "PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_baseH_Save,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_baseH_Goto,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label47,
				str = new string[3] { "贴头吸嘴", "貼頭吸嘴", "Nozzles" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label49,
				str = new string[3] { "运行障碍物", "運行障礙物", "Obstacle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label48,
				str = new string[3] { "PCB板", "PCB板", "PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_save_runsafe_h,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_goto_runsafe_h,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_SafeRunMode,
				str = new string[3] { "安全模式", "安全模式", "Safety Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_vacuum_sync,
				str = new string[3] { "同步", "同步", "Sync" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "吸嘴刚刚接触到PCB板时的高度 （安装普通工作时吸嘴）", "吸嘴剛剛接觸到PCB板時的高度 （安裝普通工作時吸嘴）", "The height that Nozzle just touch the PCB board. (Install normal nozzle)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label19,
				str = new string[3] { "全自动工作时，XY运行时，吸嘴的安全运行高度", "全自動工作時，XY運行時，吸嘴的安全運行高度", "When Running SMT, the Safety Running Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label212,
				str = new string[3] { "当PCB基准高度，相机视觉高度，飞达托盘高度相差很大时，必须开启安全模式。", "當PCB基準高度，相機視覺高度，飛達托盤高度相差很大時，必須開啟安全模式。", "If distance amount PCB base height, camera height, and feeder/plate height is too large, you have to enable Safety Mode!" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label12,
				str = new string[3] { "警告：工作安全高度设置需非常谨慎！！！必须保证工作时吸嘴要高于行程内最高点，否则会损坏贴装头。敬请重视！", "警告：工作安全高度設置需非常謹慎！！！必須保證工作時吸嘴要高於行程內最高點，否則會損壞貼裝頭。敬請重視！", "Warning: SMT Safety Height is very important!!! You MUST make sure nozzle running higher than the highest point in the valid area, otherwise, break may happen!!!" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label22,
				str = new string[3] { "(如已经设置可跳过)", "(如已經設置可跳過)", "(Skip if already Set)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label35,
				str = new string[3] { "(如已经设置可跳过)", "(如已經設置可跳過)", "(Skip if already Set)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "吸嘴与MARK相机之间的相对偏量", "吸嘴與MARK相機之間的相對偏量", "Distance between Nozzles and Mark-Cam" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_switchto_campage,
				str = new string[3] { "MARK相机预览偏量", "MARK相機預覽偏量", "Mark Cam Preview Offset" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_switchto_basepage,
				str = new string[3] { "PCB基准高度", "PCB基準高度", "PCB Base-H" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_noz_prepare,
				str = new string[3] { "● 准备工作", "● 準備工作", "● Preparation" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_nz_writeH,
				str = new string[3] { "● 扎点高度", "● 紮點高度", "● Write-Point-H" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label8,
				str = new string[3] { "下压偏移(mm)", "下壓偏移(mm)", "Offset(mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label9,
				str = new string[3] { "（扎点高度 = PCB基准高度 +下压偏移）", "（紮點高度 = PCB基準高度 +下壓偏移）", "(Write-Point-H = PCB Base-H + Offset)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_AutoGen_InkWriteH,
				str = new string[3] { "生成所有扎点高度", "生成所有紮點高度", "Gen All Write-Point Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveInkPadWriteHeight,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MoveToInkPadWriteHeight,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_noz_writeXY,
				str = new string[3] { "● 扎点起始坐标", "● 紮點起始坐標", "● Write-Point Start XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveInkPadWriteCoord,
				str = new string[3] { "保存扎点起始", "保存紮點起始", "Save Write-Point XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MoveToInkPadWriteCoord,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_noz_inkXY,
				str = new string[3] { "● 印泥坐标", "● 印泥坐標", "● Dip-Ink Coord XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveInkPadCollectCoord,
				str = new string[3] { "保存印泥坐标", "保存印泥坐標", "Save Ink XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MoveToInkPadCollectCoord,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MoveToInkPadCollectHeight,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			LanguageItem languageItem2 = new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabControl2
			};
			array = (languageItem2.str = new string[3]);
			list.Add(languageItem2);
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_nz_inkH,
				str = new string[3] { "● 采泥高度", "● 采泥高度", "● Dip-Ink Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SaveInkPadCollectHeight,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_AutoGen_InkCollectH,
				str = new string[3] { "生成所有采泥高度", "生成所有采泥高度", "Gen All Dip-Ink Height" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_StartZnDelta,
				str = new string[3] { "开始扎点", "開始紮點", "Start Write Point" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label27,
				str = new string[3] { "设置", "設置", "Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_delta_nozzle_singlemode,
				str = new string[3] { "单吸嘴扎点", "單吸嘴紮點", "Single Nozzle Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_nz_manulcheck,
				str = new string[3] { "● 确认圆心", "● 確認圓心", "● Confirm Center" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_nzdelta_para_check,
				str = new string[3] { "参数查看", "參數查看", "Para View" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_center_confirm,
				str = new string[3] { "圆心确认", "圓心確認", "Center Confirm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_center_clear,
				str = new string[3] { "清除", "清除", "Clear" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_deltaDone,
				str = new string[3] { "全部完成", "全部完成", "Complete" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_auto_deltaDone,
				str = new string[3] { "一键自动确认圆心", "壹鍵自動確認圓心", "Auto Confirm Center" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_auto_deltaDone_Interupt,
				str = new string[3] { "中断", "中斷", "Interrupt" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label55,
				str = new string[3] { "扫描半径", "掃描半徑", "Scan-R" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label56,
				str = new string[3] { "视觉阈值", "視覺閾值", "Threshold" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage12,
				str = new string[3] { "手动确认圆心", "手動確認圓心", "Manual Confirm Center" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage11,
				str = new string[3] { "自动确认圆心", "自動確認圓心", "Auto Confirm Center" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label200,
				str = new string[3] { "● 料站默认坐标", "● 料站默認坐標", "● Feeder Default Coord XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_slotSaveXY,
				str = new string[3] { "保存坐标", "保存坐標", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_slotMoveToXY,
				str = new string[3] { "定位坐标", "定位坐標", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SlotsXYGens,
				str = new string[3] { "生成料站默认坐标", "生成料站默認坐標", "Gen Default Coord XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_slotxy_to_curUsr2,
				str = new string[3] { "同步到当前工程", "同步到當前工程", "Sync to Current Project" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label102,
				str = new string[3] { "料站号", "料站號", "Feeder No" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "默认坐标", "默認坐標", "Default XY" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_gotoSlot,
				str = new string[3] { "定位坐标", "定位坐標", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_saveSlot,
				str = new string[3] { "保存坐标", "保存坐標", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_gotoSlot_byZn,
				str = new string[3] { "吸嘴定位到飞达", "吸嘴定位到飛達", "Nozzle Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_slotOpen,
				str = new string[3] { "开飞达", "開飛達", "Open Feeder" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_slotClose,
				str = new string[3] { "关飞达", "關飛達", "Close Feeder" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_feeder_front_info,
				str = new string[3] { "前端飞达（靠近快速相机的一侧）", "前端飛達（靠近快速相機的壹側）", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_feeder_back_info,
				str = new string[3] { "后端飞达", "後端飛達", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label71,
				str = new string[3] { "设置1号吸嘴到该飞达的高度", "設置1號吸嘴到該飛達的高度", "Set Height between Noz-1 and feeder" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label129,
				str = new string[3] { "设置1号吸嘴到该飞达的高度", "設置1號吸嘴到該飛達的高度", "Set Height between Noz-1 and feeder" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_feederBaseH_Save,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_feederBaseBKH_Save,
				str = new string[3] { "保存", "保存", "Save" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_feederBaseH_Goto,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_feederBaseBkH_Goto,
				str = new string[3] { "定位", "定位", "Goto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_feederBaseH_AutoGen,
				str = new string[3] { "生成前端飞达基准高度", "生成前端飛達基準高度", "Gen Feeder Base-H" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_feederBaseBkH_AutoGen,
				str = new string[3] { "生成后端飞达基准高度", "生成後端飛達基準高度", "Gen Feeder Base-H" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3]
				{
					"1.安装503型号吸嘴到每个贴头上" + Environment.NewLine + "2.放置印泥盒，确保吸嘴XY可以运动到，吸嘴下伸Z可以扎到印泥" + Environment.NewLine + "3.在轨道上放置一个铺有250x150白纸的PCB，夹板",
					"1.安裝503型號吸嘴到每個貼頭上" + Environment.NewLine + "2.放置印泥盒，確保吸嘴XY可以運動到，吸嘴下伸Z可以紮到印泥" + Environment.NewLine + "3.在軌道上放置壹個鋪有250x150白紙的PCB，夾板",
					"1.Install 503 nozzles to each head," + Environment.NewLine + "2.Put ink box to a place, making sure XY can achieve，Z can touch ink" + Environment.NewLine + "3.Place a 250x150 PCB with white paper coverred，then fix board"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_fix_nz_warning,
				str = new string[3] { "警告：本页操作非常重要，不可有误，否则无法准确贴装，甚至损坏设备。敬请重视！", "警告：本頁操作非常重要，不可有誤，否則無法準確貼裝，甚至損壞設備。敬請重視！", "Warning: This page is very important, error parameter will cause incorrect SMT, even the device broken!!!" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label18,
				str = new string[3] { "移动吸嘴1到白纸左上角10mm处，保存坐标", "移動吸嘴1到白紙左上角10mm處，保存坐標", "Move Nozzle 1 to top-left(10mm) of the paper, save coordinate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label17,
				str = new string[3] { "移动吸嘴1到印泥盒中心，保存印泥坐标", "移動吸嘴1到印泥盒中心，保存印泥坐標", "Move Nozzle 1 to center of ink box, save coordinate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label63,
				str = new string[3] { "移动吸嘴1到印泥盒，调整高度使吸嘴轻蘸印泥，保存“采泥高度”", "移動吸嘴1到印泥盒，調整高度使吸嘴輕蘸印泥，保存“采泥高度”", "Move Nozzle 1 to ink box, adjust Z to touch ink, save height." }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label30,
				str = new string[3] { "将自动在PCB上的白纸区域内扎点（共Nx4个印点，N为吸嘴数目）", "將自動在PCB上的白紙區域內紮點（共Nx4個印點，N為吸嘴數目）", "Automatic write points to the paper (Nx4, N is nozzle number)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label124,
				str = new string[3]
				{
					"1. 移动MARK相机，使中心靠近纸上最左上角的点" + Environment.NewLine + "2. 点击“一键自动确认圆形”",
					"1. 移動MARK相機，使中心靠近紙上最左上角的點" + Environment.NewLine + "2. 點擊“壹鍵自動確認圓形”",
					"1. Move Mark-Cam to Top-Left point in paper" + Environment.NewLine + "2. Click Automatic Confirm Center Button"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label32,
				str = new string[3]
				{
					"1. 点击图中圆点，贴片机将移动到相应的扎点附近" + Environment.NewLine + "2. 请手动移动贴装头，圆点中心对准MARK相机十字中心，点击“圆心确认”" + Environment.NewLine + "3. 依次完成每个圆点的确认。",
					"1. 點擊圖中圓點，貼片機將移動到相應的紮點附近" + Environment.NewLine + "2. 請手動移動貼裝頭，圓點中心對準MARK相機十字中心，點擊“圓心確認”" + Environment.NewLine + "3. 依次完成每個圓點的確認。",
					"1. Click left circle moving Mark-Cam to point" + Environment.NewLine + "2. Adjust Mark-Cam center to point manually, then click Center Confirm" + Environment.NewLine + "3. Complete every point center confirm"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label70,
				str = new string[3] { "● 飞达基准高度：吸嘴刚刚接触到飞达料的高度（安装普通工作时吸嘴）", "● 飛達基準高度：吸嘴剛剛接觸到飛達料的高度（安裝普通工作時吸嘴）", "● Feeder Base Height：When Nozzle just touch feeder（install normal nozzle）" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label38,
				str = new string[3] { "说明：在飞达板的四角位置各安装一支已上了料的8mm飞达，然后保存其取料坐标，做所有飞达取料坐标的初始化", "說明：在飛達板的四角位置各安裝壹支已上了料的8mm飛達，然後保存其取料坐標，做所有飛達取料坐標的初始化", "Introduction: Install 8mm feeder at the four corner of machine, save each pick coordinate, then generate all default coordinate XY." }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label99,
				str = new string[3] { "提示：请先完成“相机校准”和“吸嘴校准”再做此页面操作", "提示：請先完成“相機校準”和“吸嘴校準”再做此頁面操作", "Notice: Please complete camera calibration and nozzle delta firstly, then do this page" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label103,
				str = new string[3] { "建议使用8mm胶带元件", "建議使用8mm膠帶元件", "Suggest to use 8mm adhesive tape chips" }
			});
			return list;
		}

		private void cnButton_tool_Click(object sender, EventArgs e)
		{
			Form_DebugTool form_DebugTool = new Form_DebugTool();
			form_DebugTool.ShowDialog();
		}

		private void cnButton_save_runsafe_limit_h_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Be careful to change SAFETY RUNNING limited Height, plase make sure NOZZLE will not hit anything!" : "请慎重修改安全工作高度极限值，确定吸嘴不会碰撞到XY运动有效范围的最高点(包括飞达最高点，导轨最高点等)，是否确定修改？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mBaseHeight_saferun_limit[MainForm0.mZn[MainForm0.mFn]] = MainForm0.mCur[MainForm0.mFn].z[MainForm0.mZn[MainForm0.mFn]];
				label_baseH_saferun_limited_Zn_V[MainForm0.mZn[MainForm0.mFn]].Text = Math.Abs(USR.mBaseHeight_saferun_limit[MainForm0.mZn[MainForm0.mFn]]).ToString();
				MainForm0.save_FixedData();
			}
		}

		private void cnButton_goto_runsafe_limit_h_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(USR.mBaseHeight_saferun_limit[MainForm0.mZn[MainForm0.mFn]]);
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_COMMON.vs_class.UserControl_SystemSetting));
			label_FixSetting = new System.Windows.Forms.Label();
			tabPage_fix_feeder = new System.Windows.Forms.TabPage();
			label23 = new System.Windows.Forms.Label();
			panel29 = new System.Windows.Forms.Panel();
			panel62 = new System.Windows.Forms.Panel();
			panel_nozzlebasicHigh_feederBk = new System.Windows.Forms.Panel();
			label_feeder_back_info = new System.Windows.Forms.Label();
			label130 = new System.Windows.Forms.Label();
			label129 = new System.Windows.Forms.Label();
			panel61 = new System.Windows.Forms.Panel();
			label_feeder_front_info = new System.Windows.Forms.Label();
			panel_nozzlebasicHigh_feeder = new System.Windows.Forms.Panel();
			label73 = new System.Windows.Forms.Label();
			label71 = new System.Windows.Forms.Label();
			panel14 = new System.Windows.Forms.Panel();
			label_stackNo = new System.Windows.Forms.Label();
			label_stackXY = new System.Windows.Forms.Label();
			label103 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label102 = new System.Windows.Forms.Label();
			label70 = new System.Windows.Forms.Label();
			label99 = new System.Windows.Forms.Label();
			label200 = new System.Windows.Forms.Label();
			panel110 = new System.Windows.Forms.Panel();
			label_slotxy1 = new System.Windows.Forms.Label();
			label_slotxy0 = new System.Windows.Forms.Label();
			panel_showfeederxy = new System.Windows.Forms.Panel();
			label_slotxy3 = new System.Windows.Forms.Label();
			label_slotxy2 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			tabPage_fix_nozzledelta = new System.Windows.Forms.TabPage();
			label34 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label_fix_nz_manulcheck = new System.Windows.Forms.Label();
			panel46 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			checkBox_delta_nozzle_singlemode = new System.Windows.Forms.CheckBox();
			label27 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			label36 = new System.Windows.Forms.Label();
			panel_InkPoint = new System.Windows.Forms.Panel();
			tabControl2 = new System.Windows.Forms.TabControl();
			tabPage12 = new System.Windows.Forms.TabPage();
			label32 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			tabPage11 = new System.Windows.Forms.TabPage();
			label55 = new System.Windows.Forms.Label();
			label56 = new System.Windows.Forms.Label();
			numericUpDown_test_threshold = new System.Windows.Forms.NumericUpDown();
			label124 = new System.Windows.Forms.Label();
			numericUpDown_test_scanr = new System.Windows.Forms.NumericUpDown();
			panel_fixnozzle1 = new System.Windows.Forms.Panel();
			panel_collectink = new System.Windows.Forms.Panel();
			label_InkPadWriteCoord = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label_fix_noz_inkXY = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label_fix_noz_writeXY = new System.Windows.Forms.Label();
			label63 = new System.Windows.Forms.Label();
			panel24 = new System.Windows.Forms.Panel();
			panel_zhadian = new System.Windows.Forms.Panel();
			numericUpDown_InkWrite_Offset = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label_fix_nz_writeH = new System.Windows.Forms.Label();
			label_InkPadCollectCoord = new System.Windows.Forms.Label();
			label_fix_nz_inkH = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label_fix_nz_warning = new System.Windows.Forms.Label();
			label_fix_noz_prepare = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			panel11 = new System.Windows.Forms.Panel();
			panel33 = new System.Windows.Forms.Panel();
			label137 = new System.Windows.Forms.Label();
			numericUpDown_previewoffset_y = new System.Windows.Forms.NumericUpDown();
			label135 = new System.Windows.Forms.Label();
			numericUpDown_previewoffset_x = new System.Windows.Forms.NumericUpDown();
			nud_MarkRatio = new System.Windows.Forms.NumericUpDown();
			label_pixel_ratio = new System.Windows.Forms.Label();
			label43 = new System.Windows.Forms.Label();
			tabPage_fix_cam = new System.Windows.Forms.TabPage();
			panel3 = new System.Windows.Forms.Panel();
			panel_color = new System.Windows.Forms.Panel();
			trackBar_color_b = new System.Windows.Forms.TrackBar();
			trackBar_color_g = new System.Windows.Forms.TrackBar();
			trackBar_color_r = new System.Windows.Forms.TrackBar();
			checkBox_debug_isSaveErrBitmap = new System.Windows.Forms.CheckBox();
			label15 = new System.Windows.Forms.Label();
			checkBox_fastcam_oppovisual = new System.Windows.Forms.CheckBox();
			checkBox_highcam_oppovisual = new System.Windows.Forms.CheckBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			label_throwxy = new System.Windows.Forms.Label();
			label60 = new System.Windows.Forms.Label();
			label_tmpXY = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label136 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			panel_pausestop = new System.Windows.Forms.Panel();
			pictureBox7 = new System.Windows.Forms.PictureBox();
			panel_hcam_calib = new System.Windows.Forms.Panel();
			panel_hcam_setting = new System.Windows.Forms.Panel();
			numericUpDown_hcam_rec_size = new System.Windows.Forms.NumericUpDown();
			numericUpDown_hcam_threshold = new System.Windows.Forms.NumericUpDown();
			label218 = new System.Windows.Forms.Label();
			numericUpDown_hcam_liebian = new System.Windows.Forms.NumericUpDown();
			numericUpDown_hcam_scanr = new System.Windows.Forms.NumericUpDown();
			label26 = new System.Windows.Forms.Label();
			label57 = new System.Windows.Forms.Label();
			label54 = new System.Windows.Forms.Label();
			label_fix_highcam_note = new System.Windows.Forms.Label();
			label_HighRecognizeCoord = new System.Windows.Forms.Label();
			label125 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			panel_hcam_h = new System.Windows.Forms.Panel();
			panel_Hcam_baseH = new System.Windows.Forms.Panel();
			label143 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			checkBox_FCameraCalibrator = new System.Windows.Forms.CheckBox();
			label_ThrowCoord = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel_fcam_calib = new System.Windows.Forms.Panel();
			panel_fcam_setting = new System.Windows.Forms.Panel();
			numericUpDown_fcam_threshold = new System.Windows.Forms.NumericUpDown();
			numericUpDown_fcam_scanr = new System.Windows.Forms.NumericUpDown();
			label29 = new System.Windows.Forms.Label();
			label53 = new System.Windows.Forms.Label();
			numericUpDown_fcam__recsize = new System.Windows.Forms.NumericUpDown();
			label141 = new System.Windows.Forms.Label();
			panel_liebian = new System.Windows.Forms.Panel();
			label25 = new System.Windows.Forms.Label();
			label_fix_fastcam_note = new System.Windows.Forms.Label();
			label_FastRecognizeCoord = new System.Windows.Forms.Label();
			label139 = new System.Windows.Forms.Label();
			label140 = new System.Windows.Forms.Label();
			panel_fcam_h = new System.Windows.Forms.Panel();
			panel_nozzlebasicHigh_visual = new System.Windows.Forms.Panel();
			label74 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			tabPage_fix_base = new System.Windows.Forms.TabPage();
			panel_saveH_shows = new System.Windows.Forms.Panel();
			label50 = new System.Windows.Forms.Label();
			label45 = new System.Windows.Forms.Label();
			label46 = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			label48 = new System.Windows.Forms.Label();
			label51 = new System.Windows.Forms.Label();
			panel6 = new System.Windows.Forms.Panel();
			panel_nozzlebasicHigh = new System.Windows.Forms.Panel();
			label7 = new System.Windows.Forms.Label();
			panel_baseH_show = new System.Windows.Forms.Panel();
			label39 = new System.Windows.Forms.Label();
			label44 = new System.Windows.Forms.Label();
			label42 = new System.Windows.Forms.Label();
			label40 = new System.Windows.Forms.Label();
			label75 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			panel_gen2_H = new System.Windows.Forms.Panel();
			label52 = new System.Windows.Forms.Label();
			panel27 = new System.Windows.Forms.Panel();
			label19 = new System.Windows.Forms.Label();
			panel31 = new System.Windows.Forms.Panel();
			label212 = new System.Windows.Forms.Label();
			checkBox_SafeRunMode = new System.Windows.Forms.CheckBox();
			panel_nozzlebasicHigh_run = new System.Windows.Forms.Panel();
			panel_vaccbreaktime = new System.Windows.Forms.Panel();
			label132 = new System.Windows.Forms.Label();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage_fix_factory = new System.Windows.Forms.TabPage();
			panel_fix_factory = new System.Windows.Forms.Panel();
			panel_saferun_limit = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			panel19 = new System.Windows.Forms.Panel();
			label68 = new System.Windows.Forms.Label();
			numericUpDown_pic_idx = new System.Windows.Forms.NumericUpDown();
			textBox_testfolder = new System.Windows.Forms.TextBox();
			numericUpDown_factoryvisualtest_angle = new System.Windows.Forms.NumericUpDown();
			checkBox_factoryDebug = new System.Windows.Forms.CheckBox();
			panel9 = new System.Windows.Forms.Panel();
			label65 = new System.Windows.Forms.Label();
			checkBox_AutoFeeder_Inc = new System.Windows.Forms.CheckBox();
			label64 = new System.Windows.Forms.Label();
			label62 = new System.Windows.Forms.Label();
			numericUpDown_AutoFeeder_Delay = new System.Windows.Forms.NumericUpDown();
			numericUpDown_FactoryTest_feederNum = new System.Windows.Forms.NumericUpDown();
			panel8 = new System.Windows.Forms.Panel();
			progressBar_FactoryTestAll = new System.Windows.Forms.ProgressBar();
			label79 = new System.Windows.Forms.Label();
			numericUpDown_factorytestall_hour = new System.Windows.Forms.NumericUpDown();
			panel10 = new System.Windows.Forms.Panel();
			label66 = new System.Windows.Forms.Label();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			progressBar1 = new System.Windows.Forms.ProgressBar();
			panel12 = new System.Windows.Forms.Panel();
			label67 = new System.Windows.Forms.Label();
			numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			progressBar2 = new System.Windows.Forms.ProgressBar();
			panel58 = new System.Windows.Forms.Panel();
			label13 = new System.Windows.Forms.Label();
			numericUpDown_factorytest_count = new System.Windows.Forms.NumericUpDown();
			progressBar_FactoryTest = new System.Windows.Forms.ProgressBar();
			label28 = new System.Windows.Forms.Label();
			panel_baseH_saferun_limited = new System.Windows.Forms.Panel();
			button_fcam_disable = new QIGN_COMMON.vs_acontrol.CnButton();
			button_tmpXY_Goto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_test_previewoffset = new QIGN_COMMON.vs_acontrol.CnButton();
			button_previewoffset_reset = new QIGN_COMMON.vs_acontrol.CnButton();
			button_tmpXY_Save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MoveToThrowCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveThrowCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button11 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stop = new QIGN_COMMON.vs_acontrol.CnButton();
			button10 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_resume = new QIGN_COMMON.vs_acontrol.CnButton();
			button_pause = new QIGN_COMMON.vs_acontrol.CnButton();
			button_hcam_campara = new QIGN_COMMON.vs_acontrol.CnButton();
			button_hcam_visualtest = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close_hcam_setting = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SingleSetHighCamCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_AutoSetHighCamCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_hcam_set = new QIGN_COMMON.vs_acontrol.CnButton();
			button_HighCamMoveToCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_hcam_distortion_para = new QIGN_COMMON.vs_acontrol.CnButton();
			button7 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_goto_baseHcam_h_allzn = new QIGN_COMMON.vs_acontrol.CnButton();
			button_goto_Hcam_baseH = new QIGN_COMMON.vs_acontrol.CnButton();
			button_save_Hcam_baseH = new QIGN_COMMON.vs_acontrol.CnButton();
			button_fcam_visualtest = new QIGN_COMMON.vs_acontrol.CnButton();
			button_fcam_campara = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close_fcam_setting = new QIGN_COMMON.vs_acontrol.CnButton();
			button1 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_fcam_distortion_para = new QIGN_COMMON.vs_acontrol.CnButton();
			button_AutoSetFastCamCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FastCamMoveToCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_fcam_set = new QIGN_COMMON.vs_acontrol.CnButton();
			button_goto_basecamera_h_allzn = new QIGN_COMMON.vs_acontrol.CnButton();
			button_goto_basecamera_h = new QIGN_COMMON.vs_acontrol.CnButton();
			button_save_basecamera_h = new QIGN_COMMON.vs_acontrol.CnButton();
			button_baseH_Goto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_baseH_Save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_goto_runsafe_h = new QIGN_COMMON.vs_acontrol.CnButton();
			button_save_runsafe_h = new QIGN_COMMON.vs_acontrol.CnButton();
			button_vacuum_sync = new QIGN_COMMON.vs_acontrol.CnButton();
			button_nozzle_clean = new QIGN_COMMON.vs_acontrol.CnButton();
			button_nzdelta_para_check = new QIGN_COMMON.vs_acontrol.CnButton();
			button_switchto_campage = new QIGN_COMMON.vs_acontrol.CnButton();
			button_switchto_basepage = new QIGN_COMMON.vs_acontrol.CnButton();
			button_StartZnDelta = new QIGN_COMMON.vs_acontrol.CnButton();
			button_center_clear = new QIGN_COMMON.vs_acontrol.CnButton();
			button_center_confirm = new QIGN_COMMON.vs_acontrol.CnButton();
			button_deltaDone = new QIGN_COMMON.vs_acontrol.CnButton();
			button_auto_deltaDone_Interupt = new QIGN_COMMON.vs_acontrol.CnButton();
			button_auto_deltaDone = new QIGN_COMMON.vs_acontrol.CnButton();
			button_AutoGen_InkCollectH = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MoveToInkPadCollectCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveInkPadCollectHeight = new QIGN_COMMON.vs_acontrol.CnButton();
			button_AutoGen_InkWriteH = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveInkPadWriteHeight = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MoveToInkPadWriteHeight = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MoveToInkPadCollectHeight = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveInkPadCollectCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SaveInkPadWriteCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MoveToInkPadWriteCoord = new QIGN_COMMON.vs_acontrol.CnButton();
			button_feederBaseBkH_Goto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_feederBaseBkH_AutoGen = new QIGN_COMMON.vs_acontrol.CnButton();
			button_feederBaseBKH_Save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_feederBaseH_Goto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_feederBaseH_Save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_feederBaseH_AutoGen = new QIGN_COMMON.vs_acontrol.CnButton();
			button_gotoSlot_byZn = new QIGN_COMMON.vs_acontrol.CnButton();
			button_slotOpen = new QIGN_COMMON.vs_acontrol.CnButton();
			button_saveSlot = new QIGN_COMMON.vs_acontrol.CnButton();
			button_gotoSlot = new QIGN_COMMON.vs_acontrol.CnButton();
			button_slotClose = new QIGN_COMMON.vs_acontrol.CnButton();
			button_slotxy_to_curUsr2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SlotsXYGens = new QIGN_COMMON.vs_acontrol.CnButton();
			button_slotMoveToXY = new QIGN_COMMON.vs_acontrol.CnButton();
			button_slotSaveXY = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_goto_runsafe_limit_h = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_save_runsafe_limit_h = new QIGN_COMMON.vs_acontrol.CnButton();
			btn_HideSetting = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_tool = new QIGN_COMMON.vs_acontrol.CnButton();
			button_algorithm_debug_running = new QIGN_COMMON.vs_acontrol.CnButton();
			button_algorithm_debug_cur = new QIGN_COMMON.vs_acontrol.CnButton();
			button_algorithm_debug_prev = new QIGN_COMMON.vs_acontrol.CnButton();
			button_testfolder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_algorithm_debugauto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_algorithm_debug = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FactoryTest_AutoFeeder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FactoryTest_OpenFeeder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FactoryTest_CloseFeeder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FactoryTestAll_Start = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FactoryTestAll_Stop = new QIGN_COMMON.vs_acontrol.CnButton();
			button2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button3 = new QIGN_COMMON.vs_acontrol.CnButton();
			button4 = new QIGN_COMMON.vs_acontrol.CnButton();
			button5 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FactoryTest_Start = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FactoryTest_Stop = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close = new QIGN_COMMON.vs_acontrol.CnButton();
			tabPage_fix_feeder.SuspendLayout();
			panel29.SuspendLayout();
			panel62.SuspendLayout();
			panel61.SuspendLayout();
			panel14.SuspendLayout();
			panel110.SuspendLayout();
			tabPage_fix_nozzledelta.SuspendLayout();
			panel46.SuspendLayout();
			panel4.SuspendLayout();
			tabControl2.SuspendLayout();
			tabPage12.SuspendLayout();
			tabPage11.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_test_threshold).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_test_scanr).BeginInit();
			panel_fixnozzle1.SuspendLayout();
			panel24.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_InkWrite_Offset).BeginInit();
			panel11.SuspendLayout();
			panel33.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_previewoffset_y).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_previewoffset_x).BeginInit();
			((System.ComponentModel.ISupportInitialize)nud_MarkRatio).BeginInit();
			tabPage_fix_cam.SuspendLayout();
			panel3.SuspendLayout();
			panel_color.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_color_b).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_color_g).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_color_r).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			panel2.SuspendLayout();
			panel_pausestop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
			panel_hcam_calib.SuspendLayout();
			panel_hcam_setting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_rec_size).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_threshold).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_liebian).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_scanr).BeginInit();
			panel_hcam_h.SuspendLayout();
			panel_Hcam_baseH.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel_fcam_calib.SuspendLayout();
			panel_fcam_setting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_fcam_threshold).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_fcam_scanr).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_fcam__recsize).BeginInit();
			panel_fcam_h.SuspendLayout();
			panel_nozzlebasicHigh_visual.SuspendLayout();
			tabPage_fix_base.SuspendLayout();
			panel_saveH_shows.SuspendLayout();
			panel6.SuspendLayout();
			panel_nozzlebasicHigh.SuspendLayout();
			panel_baseH_show.SuspendLayout();
			panel_gen2_H.SuspendLayout();
			panel27.SuspendLayout();
			panel31.SuspendLayout();
			panel_nozzlebasicHigh_run.SuspendLayout();
			panel_vaccbreaktime.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage_fix_factory.SuspendLayout();
			panel_fix_factory.SuspendLayout();
			panel_saferun_limit.SuspendLayout();
			panel19.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pic_idx).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_factoryvisualtest_angle).BeginInit();
			panel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_AutoFeeder_Delay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_FactoryTest_feederNum).BeginInit();
			panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_factorytestall_hour).BeginInit();
			panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			panel12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
			panel58.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_factorytest_count).BeginInit();
			SuspendLayout();
			label_FixSetting.Font = new System.Drawing.Font("黑体", 16.25f);
			label_FixSetting.ForeColor = System.Drawing.Color.White;
			label_FixSetting.Location = new System.Drawing.Point(11, 1);
			label_FixSetting.Name = "label_FixSetting";
			label_FixSetting.Size = new System.Drawing.Size(656, 35);
			label_FixSetting.TabIndex = 12;
			label_FixSetting.Text = "机器校准";
			label_FixSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			tabPage_fix_feeder.Controls.Add(label23);
			tabPage_fix_feeder.Controls.Add(panel29);
			tabPage_fix_feeder.Controls.Add(label70);
			tabPage_fix_feeder.Controls.Add(label99);
			tabPage_fix_feeder.Controls.Add(label200);
			tabPage_fix_feeder.Controls.Add(panel110);
			tabPage_fix_feeder.Controls.Add(label38);
			tabPage_fix_feeder.Location = new System.Drawing.Point(4, 26);
			tabPage_fix_feeder.Name = "tabPage_fix_feeder";
			tabPage_fix_feeder.Padding = new System.Windows.Forms.Padding(3);
			tabPage_fix_feeder.Size = new System.Drawing.Size(682, 862);
			tabPage_fix_feeder.TabIndex = 3;
			tabPage_fix_feeder.Text = "料站校准";
			tabPage_fix_feeder.UseVisualStyleBackColor = true;
			label23.BackColor = System.Drawing.Color.DimGray;
			label23.Location = new System.Drawing.Point(-5, 300);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(690, 8);
			label23.TabIndex = 164;
			panel29.Controls.Add(panel62);
			panel29.Controls.Add(panel61);
			panel29.Controls.Add(panel14);
			panel29.Location = new System.Drawing.Point(3, 355);
			panel29.Name = "panel29";
			panel29.Size = new System.Drawing.Size(683, 402);
			panel29.TabIndex = 163;
			panel62.Controls.Add(button_feederBaseBkH_Goto);
			panel62.Controls.Add(button_feederBaseBkH_AutoGen);
			panel62.Controls.Add(button_feederBaseBKH_Save);
			panel62.Controls.Add(panel_nozzlebasicHigh_feederBk);
			panel62.Controls.Add(label_feeder_back_info);
			panel62.Controls.Add(label130);
			panel62.Controls.Add(label129);
			panel62.Location = new System.Drawing.Point(11, 240);
			panel62.Name = "panel62";
			panel62.Size = new System.Drawing.Size(641, 148);
			panel62.TabIndex = 164;
			panel_nozzlebasicHigh_feederBk.Location = new System.Drawing.Point(10, 68);
			panel_nozzlebasicHigh_feederBk.Name = "panel_nozzlebasicHigh_feederBk";
			panel_nozzlebasicHigh_feederBk.Size = new System.Drawing.Size(606, 63);
			panel_nozzlebasicHigh_feederBk.TabIndex = 161;
			label_feeder_back_info.AutoSize = true;
			label_feeder_back_info.Font = new System.Drawing.Font("黑体", 13.25f);
			label_feeder_back_info.Location = new System.Drawing.Point(4, 2);
			label_feeder_back_info.Name = "label_feeder_back_info";
			label_feeder_back_info.Size = new System.Drawing.Size(80, 18);
			label_feeder_back_info.TabIndex = 9;
			label_feeder_back_info.Text = "后端飞达";
			label130.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label130.Location = new System.Drawing.Point(292, 13);
			label130.Name = "label130";
			label130.Size = new System.Drawing.Size(52, 52);
			label130.TabIndex = 95;
			label130.Text = "➠";
			label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label129.BackColor = System.Drawing.Color.AliceBlue;
			label129.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label129.Location = new System.Drawing.Point(10, 22);
			label129.Name = "label129";
			label129.Size = new System.Drawing.Size(152, 41);
			label129.TabIndex = 94;
			label129.Text = "设置1号吸嘴到该飞达的高度";
			label129.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel61.Controls.Add(button_feederBaseH_Goto);
			panel61.Controls.Add(button_feederBaseH_Save);
			panel61.Controls.Add(label_feeder_front_info);
			panel61.Controls.Add(button_feederBaseH_AutoGen);
			panel61.Controls.Add(panel_nozzlebasicHigh_feeder);
			panel61.Controls.Add(label73);
			panel61.Controls.Add(label71);
			panel61.Location = new System.Drawing.Point(9, 91);
			panel61.Name = "panel61";
			panel61.Size = new System.Drawing.Size(641, 148);
			panel61.TabIndex = 163;
			label_feeder_front_info.AutoSize = true;
			label_feeder_front_info.Font = new System.Drawing.Font("黑体", 13.25f);
			label_feeder_front_info.Location = new System.Drawing.Point(7, 6);
			label_feeder_front_info.Name = "label_feeder_front_info";
			label_feeder_front_info.Size = new System.Drawing.Size(278, 18);
			label_feeder_front_info.TabIndex = 9;
			label_feeder_front_info.Text = "前端飞达（靠近快速相机的一侧）";
			panel_nozzlebasicHigh_feeder.Location = new System.Drawing.Point(12, 76);
			panel_nozzlebasicHigh_feeder.Name = "panel_nozzlebasicHigh_feeder";
			panel_nozzlebasicHigh_feeder.Size = new System.Drawing.Size(612, 54);
			panel_nozzlebasicHigh_feeder.TabIndex = 93;
			label73.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label73.Location = new System.Drawing.Point(291, 20);
			label73.Name = "label73";
			label73.Size = new System.Drawing.Size(52, 52);
			label73.TabIndex = 95;
			label73.Text = "➠";
			label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label71.BackColor = System.Drawing.Color.AliceBlue;
			label71.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label71.Location = new System.Drawing.Point(12, 29);
			label71.Name = "label71";
			label71.Size = new System.Drawing.Size(151, 41);
			label71.TabIndex = 94;
			label71.Text = "设置1号吸嘴到该飞达的高度";
			label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel14.BackColor = System.Drawing.Color.LightBlue;
			panel14.Controls.Add(label_stackNo);
			panel14.Controls.Add(button_gotoSlot_byZn);
			panel14.Controls.Add(label_stackXY);
			panel14.Controls.Add(button_slotOpen);
			panel14.Controls.Add(button_saveSlot);
			panel14.Controls.Add(button_gotoSlot);
			panel14.Controls.Add(button_slotClose);
			panel14.Controls.Add(label103);
			panel14.Controls.Add(label11);
			panel14.Controls.Add(label102);
			panel14.Location = new System.Drawing.Point(18, 3);
			panel14.Name = "panel14";
			panel14.Size = new System.Drawing.Size(641, 82);
			panel14.TabIndex = 160;
			label_stackNo.BackColor = System.Drawing.Color.Red;
			label_stackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stackNo.Font = new System.Drawing.Font("黑体", 18f);
			label_stackNo.ForeColor = System.Drawing.Color.White;
			label_stackNo.Location = new System.Drawing.Point(11, 36);
			label_stackNo.Name = "label_stackNo";
			label_stackNo.Size = new System.Drawing.Size(40, 40);
			label_stackNo.TabIndex = 161;
			label_stackNo.Text = "12";
			label_stackNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_stackNo.Click += new System.EventHandler(label_stackNo_Click);
			label_stackXY.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			label_stackXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_stackXY.Font = new System.Drawing.Font("楷体", 11f);
			label_stackXY.Location = new System.Drawing.Point(63, 36);
			label_stackXY.Name = "label_stackXY";
			label_stackXY.Size = new System.Drawing.Size(69, 40);
			label_stackXY.TabIndex = 0;
			label_stackXY.Text = "X00000\r\nY00000";
			label_stackXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label103.AutoSize = true;
			label103.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label103.Location = new System.Drawing.Point(396, 48);
			label103.Name = "label103";
			label103.Size = new System.Drawing.Size(159, 15);
			label103.TabIndex = 9;
			label103.Text = "建议使用8mm胶带元件";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("楷体", 10.25f);
			label11.Location = new System.Drawing.Point(69, 12);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(63, 14);
			label11.TabIndex = 9;
			label11.Text = "默认坐标";
			label102.AutoSize = true;
			label102.Font = new System.Drawing.Font("楷体", 10.25f);
			label102.Location = new System.Drawing.Point(9, 12);
			label102.Name = "label102";
			label102.Size = new System.Drawing.Size(49, 14);
			label102.TabIndex = 9;
			label102.Text = "料站号";
			label70.Font = new System.Drawing.Font("黑体", 14f);
			label70.Location = new System.Drawing.Point(-1, 328);
			label70.Name = "label70";
			label70.Size = new System.Drawing.Size(673, 29);
			label70.TabIndex = 162;
			label70.Text = "● 飞达基准高度：吸嘴刚刚接触到飞达料的高度（安装普通工作时吸嘴）";
			label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label99.BackColor = System.Drawing.Color.Yellow;
			label99.Font = new System.Drawing.Font("黑体", 12f);
			label99.Location = new System.Drawing.Point(7, 16);
			label99.Name = "label99";
			label99.Size = new System.Drawing.Size(675, 23);
			label99.TabIndex = 161;
			label99.Text = "提示：请先完成“相机校准”和“吸嘴校准”再做此页面操作";
			label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label200.AutoSize = true;
			label200.Font = new System.Drawing.Font("黑体", 14f);
			label200.Location = new System.Drawing.Point(3, 55);
			label200.Name = "label200";
			label200.Size = new System.Drawing.Size(159, 19);
			label200.TabIndex = 159;
			label200.Text = "● 料站默认坐标";
			panel110.Controls.Add(label_slotxy1);
			panel110.Controls.Add(label_slotxy0);
			panel110.Controls.Add(button_slotxy_to_curUsr2);
			panel110.Controls.Add(panel_showfeederxy);
			panel110.Controls.Add(button_SlotsXYGens);
			panel110.Controls.Add(button_slotMoveToXY);
			panel110.Controls.Add(button_slotSaveXY);
			panel110.Controls.Add(label_slotxy3);
			panel110.Controls.Add(label_slotxy2);
			panel110.Location = new System.Drawing.Point(19, 118);
			panel110.Name = "panel110";
			panel110.Size = new System.Drawing.Size(655, 175);
			panel110.TabIndex = 160;
			label_slotxy1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			label_slotxy1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_slotxy1.Font = new System.Drawing.Font("楷体", 11f);
			label_slotxy1.Location = new System.Drawing.Point(574, 11);
			label_slotxy1.Name = "label_slotxy1";
			label_slotxy1.Size = new System.Drawing.Size(69, 44);
			label_slotxy1.TabIndex = 0;
			label_slotxy1.Text = "X00000\r\nY00000";
			label_slotxy1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_slotxy0.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			label_slotxy0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_slotxy0.Font = new System.Drawing.Font("楷体", 11f);
			label_slotxy0.Location = new System.Drawing.Point(7, 11);
			label_slotxy0.Name = "label_slotxy0";
			label_slotxy0.Size = new System.Drawing.Size(69, 44);
			label_slotxy0.TabIndex = 0;
			label_slotxy0.Text = "X00000\r\nY00000";
			label_slotxy0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_showfeederxy.BackColor = System.Drawing.Color.Gainsboro;
			panel_showfeederxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_showfeederxy.Location = new System.Drawing.Point(79, 11);
			panel_showfeederxy.Name = "panel_showfeederxy";
			panel_showfeederxy.Size = new System.Drawing.Size(492, 115);
			panel_showfeederxy.TabIndex = 159;
			panel_showfeederxy.Paint += new System.Windows.Forms.PaintEventHandler(panel_showfeederxy_Paint);
			label_slotxy3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			label_slotxy3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_slotxy3.Font = new System.Drawing.Font("楷体", 11f);
			label_slotxy3.Location = new System.Drawing.Point(574, 82);
			label_slotxy3.Name = "label_slotxy3";
			label_slotxy3.Size = new System.Drawing.Size(69, 44);
			label_slotxy3.TabIndex = 0;
			label_slotxy3.Text = "X00000\r\nY00000";
			label_slotxy3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_slotxy2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			label_slotxy2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_slotxy2.Font = new System.Drawing.Font("楷体", 11f);
			label_slotxy2.Location = new System.Drawing.Point(7, 82);
			label_slotxy2.Name = "label_slotxy2";
			label_slotxy2.Size = new System.Drawing.Size(69, 44);
			label_slotxy2.TabIndex = 0;
			label_slotxy2.Text = "X00000\r\nY00000";
			label_slotxy2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label38.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label38.Location = new System.Drawing.Point(29, 78);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(643, 48);
			label38.TabIndex = 9;
			label38.Text = "说明：在飞达板的四角位置各安装一支已上了料的8mm飞达，然后保存其取料坐标，做所有飞达取料坐标的初始化";
			tabPage_fix_nozzledelta.Controls.Add(button_nzdelta_para_check);
			tabPage_fix_nozzledelta.Controls.Add(button_switchto_campage);
			tabPage_fix_nozzledelta.Controls.Add(button_switchto_basepage);
			tabPage_fix_nozzledelta.Controls.Add(label34);
			tabPage_fix_nozzledelta.Controls.Add(label21);
			tabPage_fix_nozzledelta.Controls.Add(label6);
			tabPage_fix_nozzledelta.Controls.Add(label_fix_nz_manulcheck);
			tabPage_fix_nozzledelta.Controls.Add(panel46);
			tabPage_fix_nozzledelta.Controls.Add(panel_InkPoint);
			tabPage_fix_nozzledelta.Controls.Add(tabControl2);
			tabPage_fix_nozzledelta.Controls.Add(panel_fixnozzle1);
			tabPage_fix_nozzledelta.Controls.Add(label10);
			tabPage_fix_nozzledelta.Controls.Add(label37);
			tabPage_fix_nozzledelta.Controls.Add(label_fix_nz_warning);
			tabPage_fix_nozzledelta.Controls.Add(label_fix_noz_prepare);
			tabPage_fix_nozzledelta.Controls.Add(label22);
			tabPage_fix_nozzledelta.Controls.Add(label35);
			tabPage_fix_nozzledelta.Controls.Add(label5);
			tabPage_fix_nozzledelta.Location = new System.Drawing.Point(4, 26);
			tabPage_fix_nozzledelta.Name = "tabPage_fix_nozzledelta";
			tabPage_fix_nozzledelta.Padding = new System.Windows.Forms.Padding(3);
			tabPage_fix_nozzledelta.Size = new System.Drawing.Size(682, 862);
			tabPage_fix_nozzledelta.TabIndex = 2;
			tabPage_fix_nozzledelta.Text = "吸嘴偏量";
			tabPage_fix_nozzledelta.UseVisualStyleBackColor = true;
			label34.BackColor = System.Drawing.Color.DimGray;
			label34.Location = new System.Drawing.Point(3, 193);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(690, 8);
			label34.TabIndex = 116;
			label21.BackColor = System.Drawing.Color.DimGray;
			label21.Location = new System.Drawing.Point(-3, 59);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(690, 8);
			label21.TabIndex = 116;
			label6.Font = new System.Drawing.Font("楷体", 10.5f);
			label6.Location = new System.Drawing.Point(132, 204);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(472, 73);
			label6.TabIndex = 104;
			label6.Text = "1.安装503型号吸嘴到每个贴头上\r\n2.放置印泥盒，确保吸嘴XY可以运动到，吸嘴下伸Z可以扎到印泥\r\n3.在轨道上放置一个铺有250x150白纸的PCB，夹板";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_fix_nz_manulcheck.Font = new System.Drawing.Font("黑体", 12.75f);
			label_fix_nz_manulcheck.Location = new System.Drawing.Point(8, 632);
			label_fix_nz_manulcheck.Name = "label_fix_nz_manulcheck";
			label_fix_nz_manulcheck.Size = new System.Drawing.Size(304, 27);
			label_fix_nz_manulcheck.TabIndex = 109;
			label_fix_nz_manulcheck.Text = "● 确认圆心";
			label_fix_nz_manulcheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel46.Controls.Add(panel4);
			panel46.Controls.Add(button_StartZnDelta);
			panel46.Controls.Add(label30);
			panel46.Controls.Add(label33);
			panel46.Controls.Add(label36);
			panel46.Location = new System.Drawing.Point(-1, 544);
			panel46.Name = "panel46";
			panel46.Size = new System.Drawing.Size(682, 78);
			panel46.TabIndex = 108;
			panel4.BackColor = System.Drawing.Color.LightBlue;
			panel4.Controls.Add(checkBox_delta_nozzle_singlemode);
			panel4.Controls.Add(label27);
			panel4.Location = new System.Drawing.Point(12, 16);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(189, 40);
			panel4.TabIndex = 90;
			checkBox_delta_nozzle_singlemode.AutoSize = true;
			checkBox_delta_nozzle_singlemode.Font = new System.Drawing.Font("黑体", 10.5f);
			checkBox_delta_nozzle_singlemode.Location = new System.Drawing.Point(62, 12);
			checkBox_delta_nozzle_singlemode.Name = "checkBox_delta_nozzle_singlemode";
			checkBox_delta_nozzle_singlemode.Size = new System.Drawing.Size(96, 18);
			checkBox_delta_nozzle_singlemode.TabIndex = 24;
			checkBox_delta_nozzle_singlemode.Text = "单吸嘴扎点";
			checkBox_delta_nozzle_singlemode.UseVisualStyleBackColor = false;
			checkBox_delta_nozzle_singlemode.CheckedChanged += new System.EventHandler(checkBox_delta_nozzle_singlemode_CheckedChanged);
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("黑体", 10.5f);
			label27.Location = new System.Drawing.Point(5, 13);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(35, 14);
			label27.TabIndex = 8;
			label27.Text = "设置";
			label30.Font = new System.Drawing.Font("楷体", 10f);
			label30.Location = new System.Drawing.Point(411, 10);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(221, 54);
			label30.TabIndex = 0;
			label30.Text = "将自动在PCB上的白纸区域内扎点（共Nx4个印点，N为吸嘴数目）";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label33.Font = new System.Drawing.Font("微软雅黑", 21.75f, System.Drawing.FontStyle.Bold);
			label33.Location = new System.Drawing.Point(271, -15);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(122, 43);
			label33.TabIndex = 89;
			label33.Text = "⇓⇓⇓";
			label33.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			label36.Font = new System.Drawing.Font("微软雅黑", 21.75f, System.Drawing.FontStyle.Bold);
			label36.Location = new System.Drawing.Point(271, 46);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(122, 43);
			label36.TabIndex = 89;
			label36.Text = "⇓⇓⇓";
			label36.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			panel_InkPoint.BackColor = System.Drawing.Color.LightBlue;
			panel_InkPoint.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_InkPoint.Location = new System.Drawing.Point(8, 661);
			panel_InkPoint.Name = "panel_InkPoint";
			panel_InkPoint.Size = new System.Drawing.Size(319, 134);
			panel_InkPoint.TabIndex = 110;
			tabControl2.Controls.Add(tabPage12);
			tabControl2.Controls.Add(tabPage11);
			tabControl2.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			tabControl2.Location = new System.Drawing.Point(329, 635);
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 0;
			tabControl2.Size = new System.Drawing.Size(347, 163);
			tabControl2.TabIndex = 111;
			tabPage12.BackColor = System.Drawing.Color.White;
			tabPage12.Controls.Add(button_center_clear);
			tabPage12.Controls.Add(label32);
			tabPage12.Controls.Add(label41);
			tabPage12.Controls.Add(button_center_confirm);
			tabPage12.Controls.Add(button_deltaDone);
			tabPage12.Location = new System.Drawing.Point(4, 24);
			tabPage12.Name = "tabPage12";
			tabPage12.Padding = new System.Windows.Forms.Padding(3);
			tabPage12.Size = new System.Drawing.Size(339, 135);
			tabPage12.TabIndex = 1;
			tabPage12.Text = "手动确认圆心";
			label32.Font = new System.Drawing.Font("楷体", 10f);
			label32.Location = new System.Drawing.Point(3, 3);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(327, 86);
			label32.TabIndex = 0;
			label32.Text = "1. 点击图中圆点，贴片机将移动到相应的扎点附近\r\n2. 请手动移动贴装头，圆点中心对准MARK相机十字中心，点击“圆心确认”\r\n3. 依次完成每个圆点的确认。\r\n";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label41.Font = new System.Drawing.Font("微软雅黑", 30f);
			label41.Location = new System.Drawing.Point(158, 81);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(52, 52);
			label41.TabIndex = 84;
			label41.Text = "➠";
			label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			tabPage11.Controls.Add(button_auto_deltaDone_Interupt);
			tabPage11.Controls.Add(button_auto_deltaDone);
			tabPage11.Controls.Add(label55);
			tabPage11.Controls.Add(label56);
			tabPage11.Controls.Add(numericUpDown_test_threshold);
			tabPage11.Controls.Add(label124);
			tabPage11.Controls.Add(numericUpDown_test_scanr);
			tabPage11.Location = new System.Drawing.Point(4, 24);
			tabPage11.Name = "tabPage11";
			tabPage11.Padding = new System.Windows.Forms.Padding(3);
			tabPage11.Size = new System.Drawing.Size(339, 135);
			tabPage11.TabIndex = 0;
			tabPage11.Text = "自动确认圆心";
			tabPage11.UseVisualStyleBackColor = true;
			label55.Font = new System.Drawing.Font("楷体", 10.5f);
			label55.Location = new System.Drawing.Point(6, 68);
			label55.Name = "label55";
			label55.Size = new System.Drawing.Size(63, 20);
			label55.TabIndex = 20;
			label55.Text = "扫描半径";
			label55.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label56.Font = new System.Drawing.Font("楷体", 10.5f);
			label56.Location = new System.Drawing.Point(129, 67);
			label56.Name = "label56";
			label56.Size = new System.Drawing.Size(63, 20);
			label56.TabIndex = 20;
			label56.Text = "视觉阈值";
			label56.TextAlign = System.Drawing.ContentAlignment.TopRight;
			numericUpDown_test_threshold.Font = new System.Drawing.Font("楷体", 10.5f);
			numericUpDown_test_threshold.Location = new System.Drawing.Point(200, 64);
			numericUpDown_test_threshold.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			numericUpDown_test_threshold.Name = "numericUpDown_test_threshold";
			numericUpDown_test_threshold.Size = new System.Drawing.Size(46, 23);
			numericUpDown_test_threshold.TabIndex = 23;
			numericUpDown_test_threshold.Value = new decimal(new int[4] { 128, 0, 0, 0 });
			numericUpDown_test_threshold.ValueChanged += new System.EventHandler(numericUpDown_test_threshold_ValueChanged);
			label124.Font = new System.Drawing.Font("楷体", 10.5f);
			label124.Location = new System.Drawing.Point(4, 3);
			label124.Name = "label124";
			label124.Size = new System.Drawing.Size(327, 58);
			label124.TabIndex = 0;
			label124.Text = "1. 移动MARK相机，使中心靠近纸上最左上角的点\r\n2. 点击“一键自动确认圆形”";
			label124.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			numericUpDown_test_scanr.Font = new System.Drawing.Font("楷体", 10.5f);
			numericUpDown_test_scanr.Location = new System.Drawing.Point(77, 65);
			numericUpDown_test_scanr.Maximum = new decimal(new int[4] { 920, 0, 0, 0 });
			numericUpDown_test_scanr.Name = "numericUpDown_test_scanr";
			numericUpDown_test_scanr.Size = new System.Drawing.Size(46, 23);
			numericUpDown_test_scanr.TabIndex = 23;
			numericUpDown_test_scanr.Value = new decimal(new int[4] { 150, 0, 0, 0 });
			numericUpDown_test_scanr.ValueChanged += new System.EventHandler(numericUpDown_test_scanr_ValueChanged);
			panel_fixnozzle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			panel_fixnozzle1.Controls.Add(panel_collectink);
			panel_fixnozzle1.Controls.Add(label_InkPadWriteCoord);
			panel_fixnozzle1.Controls.Add(label18);
			panel_fixnozzle1.Controls.Add(button_AutoGen_InkCollectH);
			panel_fixnozzle1.Controls.Add(button_MoveToInkPadCollectCoord);
			panel_fixnozzle1.Controls.Add(label_fix_noz_inkXY);
			panel_fixnozzle1.Controls.Add(label17);
			panel_fixnozzle1.Controls.Add(label_fix_noz_writeXY);
			panel_fixnozzle1.Controls.Add(label63);
			panel_fixnozzle1.Controls.Add(button_SaveInkPadCollectHeight);
			panel_fixnozzle1.Controls.Add(panel24);
			panel_fixnozzle1.Controls.Add(button_MoveToInkPadCollectHeight);
			panel_fixnozzle1.Controls.Add(button_SaveInkPadCollectCoord);
			panel_fixnozzle1.Controls.Add(label_InkPadCollectCoord);
			panel_fixnozzle1.Controls.Add(button_SaveInkPadWriteCoord);
			panel_fixnozzle1.Controls.Add(button_MoveToInkPadWriteCoord);
			panel_fixnozzle1.Controls.Add(label_fix_nz_inkH);
			panel_fixnozzle1.Location = new System.Drawing.Point(0, 280);
			panel_fixnozzle1.Name = "panel_fixnozzle1";
			panel_fixnozzle1.Size = new System.Drawing.Size(676, 258);
			panel_fixnozzle1.TabIndex = 106;
			panel_collectink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_collectink.Font = new System.Drawing.Font("楷体", 9.5f);
			panel_collectink.Location = new System.Drawing.Point(33, 203);
			panel_collectink.Name = "panel_collectink";
			panel_collectink.Size = new System.Drawing.Size(496, 42);
			panel_collectink.TabIndex = 21;
			label_InkPadWriteCoord.BackColor = System.Drawing.Color.White;
			label_InkPadWriteCoord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_InkPadWriteCoord.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_InkPadWriteCoord.Location = new System.Drawing.Point(420, 89);
			label_InkPadWriteCoord.Name = "label_InkPadWriteCoord";
			label_InkPadWriteCoord.Size = new System.Drawing.Size(60, 35);
			label_InkPadWriteCoord.TabIndex = 79;
			label_InkPadWriteCoord.Text = "X00000\r\nY00000";
			label_InkPadWriteCoord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_InkPadWriteCoord.DoubleClick += new System.EventHandler(label_InkPadWriteCoord_DoubleClick);
			label18.Font = new System.Drawing.Font("楷体", 10.5f);
			label18.Location = new System.Drawing.Point(149, 89);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(275, 38);
			label18.TabIndex = 0;
			label18.Text = "移动吸嘴1到白纸左上角10mm处，保存坐标";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_fix_noz_inkXY.Font = new System.Drawing.Font("黑体", 12.75f);
			label_fix_noz_inkXY.Location = new System.Drawing.Point(5, 133);
			label_fix_noz_inkXY.Name = "label_fix_noz_inkXY";
			label_fix_noz_inkXY.Size = new System.Drawing.Size(129, 22);
			label_fix_noz_inkXY.TabIndex = 0;
			label_fix_noz_inkXY.Text = "● 印泥坐标";
			label_fix_noz_inkXY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label17.Font = new System.Drawing.Font("楷体", 10.5f);
			label17.Location = new System.Drawing.Point(149, 128);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(268, 38);
			label17.TabIndex = 0;
			label17.Text = "移动吸嘴1到印泥盒中心，保存印泥坐标";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_fix_noz_writeXY.Font = new System.Drawing.Font("黑体", 12.75f);
			label_fix_noz_writeXY.Location = new System.Drawing.Point(5, 94);
			label_fix_noz_writeXY.Name = "label_fix_noz_writeXY";
			label_fix_noz_writeXY.Size = new System.Drawing.Size(152, 22);
			label_fix_noz_writeXY.TabIndex = 0;
			label_fix_noz_writeXY.Text = "● 扎点起始坐标";
			label_fix_noz_writeXY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label63.Font = new System.Drawing.Font("楷体", 10.5f);
			label63.Location = new System.Drawing.Point(116, 168);
			label63.Name = "label63";
			label63.Size = new System.Drawing.Size(425, 38);
			label63.TabIndex = 0;
			label63.Text = "移动吸嘴1到印泥盒，调整高度使吸嘴轻蘸印泥，保存“采泥高度”";
			label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel24.Controls.Add(panel_zhadian);
			panel24.Controls.Add(numericUpDown_InkWrite_Offset);
			panel24.Controls.Add(button_AutoGen_InkWriteH);
			panel24.Controls.Add(label9);
			panel24.Controls.Add(label8);
			panel24.Controls.Add(label_fix_nz_writeH);
			panel24.Controls.Add(button_SaveInkPadWriteHeight);
			panel24.Controls.Add(button_MoveToInkPadWriteHeight);
			panel24.Location = new System.Drawing.Point(2, 5);
			panel24.Name = "panel24";
			panel24.Size = new System.Drawing.Size(672, 80);
			panel24.TabIndex = 85;
			panel_zhadian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_zhadian.Font = new System.Drawing.Font("楷体", 9.5f);
			panel_zhadian.Location = new System.Drawing.Point(31, 35);
			panel_zhadian.Name = "panel_zhadian";
			panel_zhadian.Size = new System.Drawing.Size(496, 42);
			panel_zhadian.TabIndex = 21;
			numericUpDown_InkWrite_Offset.DecimalPlaces = 1;
			numericUpDown_InkWrite_Offset.Font = new System.Drawing.Font("微软雅黑", 9.75f);
			numericUpDown_InkWrite_Offset.Location = new System.Drawing.Point(208, 7);
			numericUpDown_InkWrite_Offset.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_InkWrite_Offset.Minimum = new decimal(new int[4] { 10, 0, 0, -2147483648 });
			numericUpDown_InkWrite_Offset.Name = "numericUpDown_InkWrite_Offset";
			numericUpDown_InkWrite_Offset.Size = new System.Drawing.Size(50, 25);
			numericUpDown_InkWrite_Offset.TabIndex = 18;
			numericUpDown_InkWrite_Offset.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_InkWrite_Offset.ValueChanged += new System.EventHandler(numericUpDown_InkWrite_Offset_ValueChanged);
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("楷体", 10.5f);
			label9.Location = new System.Drawing.Point(264, 12);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(259, 14);
			label9.TabIndex = 19;
			label9.Text = "（扎点高度 = PCB基准高度 +下压偏移）";
			label8.Font = new System.Drawing.Font("楷体", 10.5f);
			label8.Location = new System.Drawing.Point(121, 9);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(91, 24);
			label8.TabIndex = 19;
			label8.Text = "下压偏移(mm)";
			label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label_fix_nz_writeH.Font = new System.Drawing.Font("黑体", 12.75f);
			label_fix_nz_writeH.Location = new System.Drawing.Point(3, 0);
			label_fix_nz_writeH.Name = "label_fix_nz_writeH";
			label_fix_nz_writeH.Size = new System.Drawing.Size(128, 38);
			label_fix_nz_writeH.TabIndex = 0;
			label_fix_nz_writeH.Text = "● 扎点高度";
			label_fix_nz_writeH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_InkPadCollectCoord.BackColor = System.Drawing.Color.White;
			label_InkPadCollectCoord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_InkPadCollectCoord.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_InkPadCollectCoord.Location = new System.Drawing.Point(420, 131);
			label_InkPadCollectCoord.Name = "label_InkPadCollectCoord";
			label_InkPadCollectCoord.Size = new System.Drawing.Size(60, 35);
			label_InkPadCollectCoord.TabIndex = 80;
			label_InkPadCollectCoord.Text = "X00000\r\nY00000";
			label_InkPadCollectCoord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_InkPadCollectCoord.DoubleClick += new System.EventHandler(label_InkPadCollectCoord_DoubleClick);
			label_fix_nz_inkH.Font = new System.Drawing.Font("黑体", 12.75f);
			label_fix_nz_inkH.Location = new System.Drawing.Point(4, 168);
			label_fix_nz_inkH.Name = "label_fix_nz_inkH";
			label_fix_nz_inkH.Size = new System.Drawing.Size(128, 37);
			label_fix_nz_inkH.TabIndex = 0;
			label_fix_nz_inkH.Text = "● 采泥高度";
			label_fix_nz_inkH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label10.Font = new System.Drawing.Font("微软雅黑", 21.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label10.Location = new System.Drawing.Point(203, 110);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(122, 43);
			label10.TabIndex = 107;
			label10.Text = "⇓⇓⇓";
			label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			label37.Font = new System.Drawing.Font("微软雅黑", 21.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label37.Location = new System.Drawing.Point(332, 110);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(122, 43);
			label37.TabIndex = 107;
			label37.Text = "⇓⇓⇓";
			label37.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			label_fix_nz_warning.BackColor = System.Drawing.Color.Yellow;
			label_fix_nz_warning.Font = new System.Drawing.Font("黑体", 12f);
			label_fix_nz_warning.Location = new System.Drawing.Point(327, 6);
			label_fix_nz_warning.Name = "label_fix_nz_warning";
			label_fix_nz_warning.Size = new System.Drawing.Size(346, 48);
			label_fix_nz_warning.TabIndex = 102;
			label_fix_nz_warning.Text = "警告：本页操作非常重要，不可有误，否则无法准确贴装，甚至损坏设备。敬请重视！";
			label_fix_nz_warning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_fix_noz_prepare.Font = new System.Drawing.Font("黑体", 12.75f);
			label_fix_noz_prepare.Location = new System.Drawing.Point(5, 221);
			label_fix_noz_prepare.Name = "label_fix_noz_prepare";
			label_fix_noz_prepare.Size = new System.Drawing.Size(117, 29);
			label_fix_noz_prepare.TabIndex = 103;
			label_fix_noz_prepare.Text = "● 准备工作";
			label_fix_noz_prepare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font("黑体", 10.75f);
			label22.Location = new System.Drawing.Point(430, 87);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(151, 15);
			label22.TabIndex = 100;
			label22.Text = "(如已经设置可跳过)";
			label35.AutoSize = true;
			label35.Font = new System.Drawing.Font("黑体", 10.75f);
			label35.Location = new System.Drawing.Point(428, 158);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(151, 15);
			label35.TabIndex = 100;
			label35.Text = "(如已经设置可跳过)";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 14.75f);
			label5.Location = new System.Drawing.Point(14, 23);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(289, 20);
			label5.TabIndex = 1;
			label5.Text = "吸嘴与MARK相机之间的相对偏量";
			panel11.BackColor = System.Drawing.Color.LightBlue;
			panel11.Controls.Add(panel33);
			panel11.Controls.Add(nud_MarkRatio);
			panel11.Controls.Add(label_pixel_ratio);
			panel11.Location = new System.Drawing.Point(8, 51);
			panel11.Name = "panel11";
			panel11.Size = new System.Drawing.Size(670, 36);
			panel11.TabIndex = 101;
			panel33.Controls.Add(button_test_previewoffset);
			panel33.Controls.Add(button_previewoffset_reset);
			panel33.Controls.Add(label137);
			panel33.Controls.Add(numericUpDown_previewoffset_y);
			panel33.Controls.Add(label135);
			panel33.Controls.Add(numericUpDown_previewoffset_x);
			panel33.Location = new System.Drawing.Point(164, 0);
			panel33.Name = "panel33";
			panel33.Size = new System.Drawing.Size(503, 35);
			panel33.TabIndex = 9;
			label137.AutoSize = true;
			label137.Font = new System.Drawing.Font("黑体", 11f);
			label137.Location = new System.Drawing.Point(155, 9);
			label137.Name = "label137";
			label137.Size = new System.Drawing.Size(87, 15);
			label137.TabIndex = 1;
			label137.Text = "预览偏量 Y";
			numericUpDown_previewoffset_y.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_previewoffset_y.Location = new System.Drawing.Point(246, 6);
			numericUpDown_previewoffset_y.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_previewoffset_y.Name = "numericUpDown_previewoffset_y";
			numericUpDown_previewoffset_y.Size = new System.Drawing.Size(50, 24);
			numericUpDown_previewoffset_y.TabIndex = 0;
			numericUpDown_previewoffset_y.Tag = "y";
			numericUpDown_previewoffset_y.ValueChanged += new System.EventHandler(numericUpDown_previewoffset_x_ValueChanged);
			label135.AutoSize = true;
			label135.Font = new System.Drawing.Font("黑体", 11f);
			label135.Location = new System.Drawing.Point(12, 9);
			label135.Name = "label135";
			label135.Size = new System.Drawing.Size(87, 15);
			label135.TabIndex = 1;
			label135.Text = "预览偏量 X";
			numericUpDown_previewoffset_x.Font = new System.Drawing.Font("黑体", 11f);
			numericUpDown_previewoffset_x.Location = new System.Drawing.Point(103, 7);
			numericUpDown_previewoffset_x.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_previewoffset_x.Name = "numericUpDown_previewoffset_x";
			numericUpDown_previewoffset_x.Size = new System.Drawing.Size(47, 24);
			numericUpDown_previewoffset_x.TabIndex = 0;
			numericUpDown_previewoffset_x.Tag = "x";
			numericUpDown_previewoffset_x.ValueChanged += new System.EventHandler(numericUpDown_previewoffset_x_ValueChanged);
			nud_MarkRatio.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			nud_MarkRatio.DecimalPlaces = 3;
			nud_MarkRatio.Font = new System.Drawing.Font("黑体", 11f);
			nud_MarkRatio.Increment = new decimal(new int[4] { 1, 0, 0, 196608 });
			nud_MarkRatio.Location = new System.Drawing.Point(85, 6);
			nud_MarkRatio.Maximum = new decimal(new int[4] { 9999, 0, 0, 196608 });
			nud_MarkRatio.Minimum = new decimal(new int[4] { 1, 0, 0, 196608 });
			nud_MarkRatio.Name = "nud_MarkRatio";
			nud_MarkRatio.Size = new System.Drawing.Size(77, 24);
			nud_MarkRatio.TabIndex = 6;
			nud_MarkRatio.Value = new decimal(new int[4] { 510, 0, 0, 131072 });
			nud_MarkRatio.ValueChanged += new System.EventHandler(nud_MarkRatio_ValueChanged);
			label_pixel_ratio.AutoSize = true;
			label_pixel_ratio.Font = new System.Drawing.Font("黑体", 11f);
			label_pixel_ratio.Location = new System.Drawing.Point(9, 9);
			label_pixel_ratio.Name = "label_pixel_ratio";
			label_pixel_ratio.Size = new System.Drawing.Size(71, 15);
			label_pixel_ratio.TabIndex = 8;
			label_pixel_ratio.Text = "像素比例";
			label43.AutoSize = true;
			label43.Font = new System.Drawing.Font("黑体", 14f);
			label43.Location = new System.Drawing.Point(7, 25);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(159, 19);
			label43.TabIndex = 100;
			label43.Text = "● MARK相机校准";
			tabPage_fix_cam.BackColor = System.Drawing.Color.White;
			tabPage_fix_cam.Controls.Add(panel3);
			tabPage_fix_cam.Controls.Add(button_tmpXY_Goto);
			tabPage_fix_cam.Controls.Add(panel11);
			tabPage_fix_cam.Controls.Add(pictureBox2);
			tabPage_fix_cam.Controls.Add(label43);
			tabPage_fix_cam.Controls.Add(label_throwxy);
			tabPage_fix_cam.Controls.Add(button_tmpXY_Save);
			tabPage_fix_cam.Controls.Add(button_MoveToThrowCoord);
			tabPage_fix_cam.Controls.Add(label60);
			tabPage_fix_cam.Controls.Add(label_tmpXY);
			tabPage_fix_cam.Controls.Add(label14);
			tabPage_fix_cam.Controls.Add(label20);
			tabPage_fix_cam.Controls.Add(label24);
			tabPage_fix_cam.Controls.Add(label136);
			tabPage_fix_cam.Controls.Add(button_SaveThrowCoord);
			tabPage_fix_cam.Controls.Add(panel2);
			tabPage_fix_cam.Controls.Add(label_ThrowCoord);
			tabPage_fix_cam.Controls.Add(panel1);
			tabPage_fix_cam.Location = new System.Drawing.Point(4, 26);
			tabPage_fix_cam.Name = "tabPage_fix_cam";
			tabPage_fix_cam.Padding = new System.Windows.Forms.Padding(3);
			tabPage_fix_cam.Size = new System.Drawing.Size(682, 862);
			tabPage_fix_cam.TabIndex = 1;
			tabPage_fix_cam.Text = "相机校准";
			panel3.Controls.Add(panel_color);
			panel3.Controls.Add(checkBox_debug_isSaveErrBitmap);
			panel3.Controls.Add(button_fcam_disable);
			panel3.Controls.Add(label15);
			panel3.Controls.Add(checkBox_fastcam_oppovisual);
			panel3.Controls.Add(checkBox_highcam_oppovisual);
			panel3.Location = new System.Drawing.Point(3, 684);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(365, 114);
			panel3.TabIndex = 119;
			panel_color.BackColor = System.Drawing.Color.DarkGray;
			panel_color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_color.Controls.Add(trackBar_color_b);
			panel_color.Controls.Add(trackBar_color_g);
			panel_color.Controls.Add(trackBar_color_r);
			panel_color.Location = new System.Drawing.Point(189, 9);
			panel_color.Name = "panel_color";
			panel_color.Size = new System.Drawing.Size(173, 65);
			panel_color.TabIndex = 174;
			trackBar_color_b.Location = new System.Drawing.Point(-4, 39);
			trackBar_color_b.Maximum = 255;
			trackBar_color_b.Name = "trackBar_color_b";
			trackBar_color_b.Size = new System.Drawing.Size(170, 45);
			trackBar_color_b.TabIndex = 0;
			trackBar_color_b.Tag = "0";
			trackBar_color_b.TickFrequency = 10;
			trackBar_color_g.Location = new System.Drawing.Point(-4, 19);
			trackBar_color_g.Maximum = 255;
			trackBar_color_g.Name = "trackBar_color_g";
			trackBar_color_g.Size = new System.Drawing.Size(170, 45);
			trackBar_color_g.TabIndex = 0;
			trackBar_color_g.Tag = "1";
			trackBar_color_g.TickFrequency = 10;
			trackBar_color_r.Location = new System.Drawing.Point(-4, -1);
			trackBar_color_r.Maximum = 255;
			trackBar_color_r.Name = "trackBar_color_r";
			trackBar_color_r.Size = new System.Drawing.Size(170, 45);
			trackBar_color_r.TabIndex = 0;
			trackBar_color_r.Tag = "0";
			trackBar_color_r.TickFrequency = 10;
			checkBox_debug_isSaveErrBitmap.AutoSize = true;
			checkBox_debug_isSaveErrBitmap.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_debug_isSaveErrBitmap.Location = new System.Drawing.Point(14, 47);
			checkBox_debug_isSaveErrBitmap.Name = "checkBox_debug_isSaveErrBitmap";
			checkBox_debug_isSaveErrBitmap.Size = new System.Drawing.Size(122, 19);
			checkBox_debug_isSaveErrBitmap.TabIndex = 173;
			checkBox_debug_isSaveErrBitmap.Text = "保存异常照片";
			checkBox_debug_isSaveErrBitmap.UseVisualStyleBackColor = true;
			checkBox_debug_isSaveErrBitmap.CheckedChanged += new System.EventHandler(checkBox_debug_isSaveErrBitmap_CheckedChanged);
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("黑体", 14f);
			label15.Location = new System.Drawing.Point(10, 12);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(89, 19);
			label15.TabIndex = 0;
			label15.Text = "视觉设置";
			checkBox_fastcam_oppovisual.AutoSize = true;
			checkBox_fastcam_oppovisual.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_fastcam_oppovisual.Location = new System.Drawing.Point(14, 72);
			checkBox_fastcam_oppovisual.Name = "checkBox_fastcam_oppovisual";
			checkBox_fastcam_oppovisual.Size = new System.Drawing.Size(154, 19);
			checkBox_fastcam_oppovisual.TabIndex = 109;
			checkBox_fastcam_oppovisual.Text = "快速相机反色视觉";
			checkBox_fastcam_oppovisual.UseVisualStyleBackColor = true;
			checkBox_fastcam_oppovisual.CheckedChanged += new System.EventHandler(checkBox_fastcam_oppovisual_CheckedChanged);
			checkBox_highcam_oppovisual.AutoSize = true;
			checkBox_highcam_oppovisual.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_highcam_oppovisual.Location = new System.Drawing.Point(14, 92);
			checkBox_highcam_oppovisual.Name = "checkBox_highcam_oppovisual";
			checkBox_highcam_oppovisual.Size = new System.Drawing.Size(154, 19);
			checkBox_highcam_oppovisual.TabIndex = 121;
			checkBox_highcam_oppovisual.Text = "高清相机反色视觉";
			checkBox_highcam_oppovisual.UseVisualStyleBackColor = true;
			checkBox_highcam_oppovisual.CheckedChanged += new System.EventHandler(checkBox_highcam_oppovisual_CheckedChanged);
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(630, 17);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(40, 32);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 113;
			pictureBox2.TabStop = false;
			label_throwxy.AutoSize = true;
			label_throwxy.Font = new System.Drawing.Font("黑体", 11f);
			label_throwxy.Location = new System.Drawing.Point(408, 715);
			label_throwxy.Name = "label_throwxy";
			label_throwxy.Size = new System.Drawing.Size(71, 15);
			label_throwxy.TabIndex = 174;
			label_throwxy.Text = "抛料坐标";
			label60.BackColor = System.Drawing.Color.DimGray;
			label60.Location = new System.Drawing.Point(395, 675);
			label60.Name = "label60";
			label60.Size = new System.Drawing.Size(8, 164);
			label60.TabIndex = 112;
			label_tmpXY.BackColor = System.Drawing.Color.White;
			label_tmpXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_tmpXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label_tmpXY.Font = new System.Drawing.Font("楷体", 11f);
			label_tmpXY.Location = new System.Drawing.Point(485, 750);
			label_tmpXY.Name = "label_tmpXY";
			label_tmpXY.Size = new System.Drawing.Size(62, 40);
			label_tmpXY.TabIndex = 178;
			label_tmpXY.Text = "0";
			label_tmpXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label14.BackColor = System.Drawing.Color.DimGray;
			label14.Location = new System.Drawing.Point(-5, 97);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(690, 8);
			label14.TabIndex = 112;
			label20.BackColor = System.Drawing.Color.DimGray;
			label20.Location = new System.Drawing.Point(-4, 389);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(690, 8);
			label20.TabIndex = 112;
			label24.BackColor = System.Drawing.Color.DimGray;
			label24.Location = new System.Drawing.Point(-1, 675);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(690, 8);
			label24.TabIndex = 112;
			label136.AutoSize = true;
			label136.Font = new System.Drawing.Font("黑体", 11f);
			label136.Location = new System.Drawing.Point(409, 763);
			label136.Name = "label136";
			label136.Size = new System.Drawing.Size(71, 15);
			label136.TabIndex = 173;
			label136.Text = "临时坐标";
			panel2.Controls.Add(panel_pausestop);
			panel2.Controls.Add(pictureBox7);
			panel2.Controls.Add(panel_hcam_calib);
			panel2.Controls.Add(panel_hcam_h);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(checkBox_FCameraCalibrator);
			panel2.Location = new System.Drawing.Point(0, 397);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(676, 261);
			panel2.TabIndex = 115;
			panel_pausestop.BackColor = System.Drawing.Color.DimGray;
			panel_pausestop.Controls.Add(button11);
			panel_pausestop.Controls.Add(button_stop);
			panel_pausestop.Controls.Add(button10);
			panel_pausestop.Controls.Add(button_resume);
			panel_pausestop.Controls.Add(button_pause);
			panel_pausestop.Location = new System.Drawing.Point(118, 6);
			panel_pausestop.Name = "panel_pausestop";
			panel_pausestop.Size = new System.Drawing.Size(686, 120);
			panel_pausestop.TabIndex = 124;
			panel_pausestop.Visible = false;
			pictureBox7.Image = (System.Drawing.Image)resources.GetObject("pictureBox7.Image");
			pictureBox7.Location = new System.Drawing.Point(628, 4);
			pictureBox7.Name = "pictureBox7";
			pictureBox7.Size = new System.Drawing.Size(40, 32);
			pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox7.TabIndex = 100;
			pictureBox7.TabStop = false;
			panel_hcam_calib.Controls.Add(panel_hcam_setting);
			panel_hcam_calib.Controls.Add(button_SingleSetHighCamCoord);
			panel_hcam_calib.Controls.Add(button_AutoSetHighCamCoord);
			panel_hcam_calib.Controls.Add(button_hcam_set);
			panel_hcam_calib.Controls.Add(button_HighCamMoveToCoord);
			panel_hcam_calib.Controls.Add(label_fix_highcam_note);
			panel_hcam_calib.Controls.Add(label_HighRecognizeCoord);
			panel_hcam_calib.Controls.Add(button_hcam_distortion_para);
			panel_hcam_calib.Controls.Add(label125);
			panel_hcam_calib.Controls.Add(button7);
			panel_hcam_calib.Controls.Add(label3);
			panel_hcam_calib.Location = new System.Drawing.Point(7, 128);
			panel_hcam_calib.Name = "panel_hcam_calib";
			panel_hcam_calib.Size = new System.Drawing.Size(668, 146);
			panel_hcam_calib.TabIndex = 123;
			panel_hcam_setting.BackColor = System.Drawing.Color.LightBlue;
			panel_hcam_setting.Controls.Add(button_hcam_campara);
			panel_hcam_setting.Controls.Add(button_hcam_visualtest);
			panel_hcam_setting.Controls.Add(button_close_hcam_setting);
			panel_hcam_setting.Controls.Add(numericUpDown_hcam_rec_size);
			panel_hcam_setting.Controls.Add(numericUpDown_hcam_threshold);
			panel_hcam_setting.Controls.Add(label218);
			panel_hcam_setting.Controls.Add(numericUpDown_hcam_liebian);
			panel_hcam_setting.Controls.Add(numericUpDown_hcam_scanr);
			panel_hcam_setting.Controls.Add(label26);
			panel_hcam_setting.Controls.Add(label57);
			panel_hcam_setting.Controls.Add(label54);
			panel_hcam_setting.Location = new System.Drawing.Point(1, 69);
			panel_hcam_setting.Name = "panel_hcam_setting";
			panel_hcam_setting.Size = new System.Drawing.Size(663, 58);
			panel_hcam_setting.TabIndex = 120;
			numericUpDown_hcam_rec_size.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_hcam_rec_size.Location = new System.Drawing.Point(69, 4);
			numericUpDown_hcam_rec_size.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			numericUpDown_hcam_rec_size.Name = "numericUpDown_hcam_rec_size";
			numericUpDown_hcam_rec_size.Size = new System.Drawing.Size(62, 23);
			numericUpDown_hcam_rec_size.TabIndex = 105;
			numericUpDown_hcam_rec_size.Value = new decimal(new int[4] { 140, 0, 0, 0 });
			numericUpDown_hcam_rec_size.ValueChanged += new System.EventHandler(numericUpDown_hcam_rec_size_ValueChanged);
			numericUpDown_hcam_threshold.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_hcam_threshold.Location = new System.Drawing.Point(501, 30);
			numericUpDown_hcam_threshold.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			numericUpDown_hcam_threshold.Name = "numericUpDown_hcam_threshold";
			numericUpDown_hcam_threshold.Size = new System.Drawing.Size(46, 23);
			numericUpDown_hcam_threshold.TabIndex = 107;
			numericUpDown_hcam_threshold.ValueChanged += new System.EventHandler(numericUpDown_hcam_threshold_ValueChanged);
			label218.AutoSize = true;
			label218.Font = new System.Drawing.Font("黑体", 10.5f);
			label218.Location = new System.Drawing.Point(6, 8);
			label218.Name = "label218";
			label218.Size = new System.Drawing.Size(63, 14);
			label218.TabIndex = 103;
			label218.Text = "识别尺寸";
			numericUpDown_hcam_liebian.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_hcam_liebian.Location = new System.Drawing.Point(69, 31);
			numericUpDown_hcam_liebian.Maximum = new decimal(new int[4] { 800, 0, 0, 0 });
			numericUpDown_hcam_liebian.Minimum = new decimal(new int[4] { 100, 0, 0, 0 });
			numericUpDown_hcam_liebian.Name = "numericUpDown_hcam_liebian";
			numericUpDown_hcam_liebian.Size = new System.Drawing.Size(62, 23);
			numericUpDown_hcam_liebian.TabIndex = 104;
			numericUpDown_hcam_liebian.Value = new decimal(new int[4] { 500, 0, 0, 0 });
			numericUpDown_hcam_liebian.ValueChanged += new System.EventHandler(numericUpDown_hcam_liebian_ValueChanged);
			numericUpDown_hcam_scanr.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_hcam_scanr.Location = new System.Drawing.Point(501, 5);
			numericUpDown_hcam_scanr.Maximum = new decimal(new int[4] { 900, 0, 0, 0 });
			numericUpDown_hcam_scanr.Name = "numericUpDown_hcam_scanr";
			numericUpDown_hcam_scanr.Size = new System.Drawing.Size(46, 23);
			numericUpDown_hcam_scanr.TabIndex = 107;
			numericUpDown_hcam_scanr.ValueChanged += new System.EventHandler(numericUpDown_hcam_scanr_ValueChanged);
			label26.Font = new System.Drawing.Font("黑体", 10.5f);
			label26.Location = new System.Drawing.Point(6, 28);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(83, 27);
			label26.TabIndex = 102;
			label26.Text = "视野参数";
			label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label57.Font = new System.Drawing.Font("黑体", 10.5f);
			label57.Location = new System.Drawing.Point(431, 4);
			label57.Name = "label57";
			label57.Size = new System.Drawing.Size(83, 27);
			label57.TabIndex = 102;
			label57.Text = "扫描半径";
			label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label54.Font = new System.Drawing.Font("黑体", 10.5f);
			label54.Location = new System.Drawing.Point(431, 29);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(83, 27);
			label54.TabIndex = 102;
			label54.Text = "视觉阈值";
			label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_fix_highcam_note.Font = new System.Drawing.Font("黑体", 10.5f);
			label_fix_highcam_note.ForeColor = System.Drawing.Color.Black;
			label_fix_highcam_note.Location = new System.Drawing.Point(108, 0);
			label_fix_highcam_note.Name = "label_fix_highcam_note";
			label_fix_highcam_note.Size = new System.Drawing.Size(546, 24);
			label_fix_highcam_note.TabIndex = 117;
			label_fix_highcam_note.Text = "说明：所有贴头安装实心吸嘴，然后将1号吸嘴移动到中心附近，点击“自动校准”";
			label_fix_highcam_note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_HighRecognizeCoord.BackColor = System.Drawing.Color.AliceBlue;
			label_HighRecognizeCoord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_HighRecognizeCoord.Font = new System.Drawing.Font("黑体", 11.5f);
			label_HighRecognizeCoord.Location = new System.Drawing.Point(3, 24);
			label_HighRecognizeCoord.Name = "label_HighRecognizeCoord";
			label_HighRecognizeCoord.Size = new System.Drawing.Size(70, 41);
			label_HighRecognizeCoord.TabIndex = 107;
			label_HighRecognizeCoord.Text = "X31802\r\nY58800";
			label_HighRecognizeCoord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label125.Font = new System.Drawing.Font("黑体", 10.5f);
			label125.Location = new System.Drawing.Point(7, 0);
			label125.Name = "label125";
			label125.Size = new System.Drawing.Size(132, 27);
			label125.TabIndex = 118;
			label125.Text = "相机校准";
			label125.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label3.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(190, 14);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(52, 52);
			label3.TabIndex = 110;
			label3.Text = "➠";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_hcam_h.Controls.Add(panel_Hcam_baseH);
			panel_hcam_h.Controls.Add(label143);
			panel_hcam_h.Location = new System.Drawing.Point(7, 42);
			panel_hcam_h.Name = "panel_hcam_h";
			panel_hcam_h.Size = new System.Drawing.Size(665, 84);
			panel_hcam_h.TabIndex = 113;
			panel_Hcam_baseH.Controls.Add(button_goto_baseHcam_h_allzn);
			panel_Hcam_baseH.Controls.Add(button_goto_Hcam_baseH);
			panel_Hcam_baseH.Controls.Add(button_save_Hcam_baseH);
			panel_Hcam_baseH.Location = new System.Drawing.Point(0, 29);
			panel_Hcam_baseH.Name = "panel_Hcam_baseH";
			panel_Hcam_baseH.Size = new System.Drawing.Size(665, 54);
			panel_Hcam_baseH.TabIndex = 95;
			label143.Font = new System.Drawing.Font("黑体", 11f);
			label143.Location = new System.Drawing.Point(4, 1);
			label143.Name = "label143";
			label143.Size = new System.Drawing.Size(474, 29);
			label143.TabIndex = 91;
			label143.Text = "视觉基准高度";
			label143.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 14f);
			label2.Location = new System.Drawing.Point(2, 13);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(159, 19);
			label2.TabIndex = 0;
			label2.Text = "● 高清相机校准";
			checkBox_FCameraCalibrator.AutoSize = true;
			checkBox_FCameraCalibrator.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_FCameraCalibrator.Location = new System.Drawing.Point(532, 15);
			checkBox_FCameraCalibrator.Name = "checkBox_FCameraCalibrator";
			checkBox_FCameraCalibrator.Size = new System.Drawing.Size(122, 19);
			checkBox_FCameraCalibrator.TabIndex = 108;
			checkBox_FCameraCalibrator.Text = "畸变校准补偿";
			checkBox_FCameraCalibrator.UseVisualStyleBackColor = true;
			checkBox_FCameraCalibrator.Visible = false;
			checkBox_FCameraCalibrator.CheckedChanged += new System.EventHandler(checkBox_FCameraCalibrator_CheckedChanged);
			label_ThrowCoord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			label_ThrowCoord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_ThrowCoord.Font = new System.Drawing.Font("楷体", 11f);
			label_ThrowCoord.Location = new System.Drawing.Point(485, 702);
			label_ThrowCoord.Name = "label_ThrowCoord";
			label_ThrowCoord.Size = new System.Drawing.Size(62, 40);
			label_ThrowCoord.TabIndex = 176;
			label_ThrowCoord.Text = "X00000\r\nY00000";
			label_ThrowCoord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_ThrowCoord.DoubleClick += new System.EventHandler(label_ThrowCoord_DoubleClick);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(panel_fcam_calib);
			panel1.Controls.Add(panel_fcam_h);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(2, 105);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(673, 281);
			panel1.TabIndex = 114;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(628, 13);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 32);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 100;
			pictureBox1.TabStop = false;
			panel_fcam_calib.Controls.Add(panel_fcam_setting);
			panel_fcam_calib.Controls.Add(button1);
			panel_fcam_calib.Controls.Add(button_fcam_distortion_para);
			panel_fcam_calib.Controls.Add(button_AutoSetFastCamCoord);
			panel_fcam_calib.Controls.Add(button_FastCamMoveToCoord);
			panel_fcam_calib.Controls.Add(button_fcam_set);
			panel_fcam_calib.Controls.Add(label_fix_fastcam_note);
			panel_fcam_calib.Controls.Add(label_FastRecognizeCoord);
			panel_fcam_calib.Controls.Add(label139);
			panel_fcam_calib.Controls.Add(label140);
			panel_fcam_calib.Location = new System.Drawing.Point(4, 131);
			panel_fcam_calib.Name = "panel_fcam_calib";
			panel_fcam_calib.Size = new System.Drawing.Size(670, 146);
			panel_fcam_calib.TabIndex = 120;
			panel_fcam_setting.BackColor = System.Drawing.Color.LightBlue;
			panel_fcam_setting.Controls.Add(button_fcam_visualtest);
			panel_fcam_setting.Controls.Add(numericUpDown_fcam_threshold);
			panel_fcam_setting.Controls.Add(numericUpDown_fcam_scanr);
			panel_fcam_setting.Controls.Add(label29);
			panel_fcam_setting.Controls.Add(label53);
			panel_fcam_setting.Controls.Add(button_fcam_campara);
			panel_fcam_setting.Controls.Add(numericUpDown_fcam__recsize);
			panel_fcam_setting.Controls.Add(label141);
			panel_fcam_setting.Controls.Add(panel_liebian);
			panel_fcam_setting.Controls.Add(button_close_fcam_setting);
			panel_fcam_setting.Controls.Add(label25);
			panel_fcam_setting.Location = new System.Drawing.Point(2, 76);
			panel_fcam_setting.Name = "panel_fcam_setting";
			panel_fcam_setting.Size = new System.Drawing.Size(663, 68);
			panel_fcam_setting.TabIndex = 113;
			numericUpDown_fcam_threshold.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_fcam_threshold.Location = new System.Drawing.Point(501, 36);
			numericUpDown_fcam_threshold.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			numericUpDown_fcam_threshold.Name = "numericUpDown_fcam_threshold";
			numericUpDown_fcam_threshold.Size = new System.Drawing.Size(46, 23);
			numericUpDown_fcam_threshold.TabIndex = 107;
			numericUpDown_fcam_threshold.ValueChanged += new System.EventHandler(numericUpDown_fcam_threshold_ValueChanged);
			numericUpDown_fcam_scanr.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_fcam_scanr.Location = new System.Drawing.Point(501, 11);
			numericUpDown_fcam_scanr.Maximum = new decimal(new int[4] { 900, 0, 0, 0 });
			numericUpDown_fcam_scanr.Name = "numericUpDown_fcam_scanr";
			numericUpDown_fcam_scanr.Size = new System.Drawing.Size(46, 23);
			numericUpDown_fcam_scanr.TabIndex = 107;
			numericUpDown_fcam_scanr.ValueChanged += new System.EventHandler(numericUpDown_fcam_scanr_ValueChanged);
			label29.Font = new System.Drawing.Font("黑体", 10.5f);
			label29.Location = new System.Drawing.Point(438, 10);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(83, 27);
			label29.TabIndex = 102;
			label29.Text = "扫描半径";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label53.Font = new System.Drawing.Font("黑体", 10.5f);
			label53.Location = new System.Drawing.Point(438, 35);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(83, 27);
			label53.TabIndex = 102;
			label53.Text = "视觉阈值";
			label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			numericUpDown_fcam__recsize.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_fcam__recsize.Location = new System.Drawing.Point(67, 10);
			numericUpDown_fcam__recsize.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			numericUpDown_fcam__recsize.Name = "numericUpDown_fcam__recsize";
			numericUpDown_fcam__recsize.Size = new System.Drawing.Size(64, 23);
			numericUpDown_fcam__recsize.TabIndex = 104;
			numericUpDown_fcam__recsize.Value = new decimal(new int[4] { 140, 0, 0, 0 });
			numericUpDown_fcam__recsize.ValueChanged += new System.EventHandler(numericUpDown_fcam__recsize_ValueChanged);
			label141.AutoSize = true;
			label141.Font = new System.Drawing.Font("黑体", 10.5f);
			label141.Location = new System.Drawing.Point(3, 15);
			label141.Name = "label141";
			label141.Size = new System.Drawing.Size(63, 14);
			label141.TabIndex = 103;
			label141.Text = "识别尺寸";
			panel_liebian.Location = new System.Drawing.Point(64, 35);
			panel_liebian.Name = "panel_liebian";
			panel_liebian.Size = new System.Drawing.Size(382, 30);
			panel_liebian.TabIndex = 24;
			label25.Font = new System.Drawing.Font("黑体", 10.5f);
			label25.Location = new System.Drawing.Point(3, 33);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(83, 27);
			label25.TabIndex = 102;
			label25.Text = "视野参数";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_fix_fastcam_note.Font = new System.Drawing.Font("黑体", 10.5f);
			label_fix_fastcam_note.ForeColor = System.Drawing.Color.Black;
			label_fix_fastcam_note.Location = new System.Drawing.Point(99, -3);
			label_fix_fastcam_note.Name = "label_fix_fastcam_note";
			label_fix_fastcam_note.Size = new System.Drawing.Size(556, 40);
			label_fix_fastcam_note.TabIndex = 101;
			label_fix_fastcam_note.Text = "说明：所有贴头安装实心吸嘴，然后将1号吸嘴移动到中心附近，点击“自动校准”";
			label_fix_fastcam_note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_FastRecognizeCoord.BackColor = System.Drawing.Color.AliceBlue;
			label_FastRecognizeCoord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_FastRecognizeCoord.Font = new System.Drawing.Font("黑体", 11.5f);
			label_FastRecognizeCoord.Location = new System.Drawing.Point(3, 30);
			label_FastRecognizeCoord.Name = "label_FastRecognizeCoord";
			label_FastRecognizeCoord.Size = new System.Drawing.Size(70, 42);
			label_FastRecognizeCoord.TabIndex = 107;
			label_FastRecognizeCoord.Text = "X31802\r\nY58800";
			label_FastRecognizeCoord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label139.Font = new System.Drawing.Font("黑体", 10.5f);
			label139.Location = new System.Drawing.Point(7, 4);
			label139.Name = "label139";
			label139.Size = new System.Drawing.Size(83, 27);
			label139.TabIndex = 102;
			label139.Text = "相机校准";
			label139.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label140.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label140.Location = new System.Drawing.Point(191, 26);
			label140.Name = "label140";
			label140.Size = new System.Drawing.Size(52, 45);
			label140.TabIndex = 110;
			label140.Text = "➠";
			label140.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			panel_fcam_h.Controls.Add(panel_nozzlebasicHigh_visual);
			panel_fcam_h.Controls.Add(label74);
			panel_fcam_h.Location = new System.Drawing.Point(4, 51);
			panel_fcam_h.Name = "panel_fcam_h";
			panel_fcam_h.Size = new System.Drawing.Size(664, 85);
			panel_fcam_h.TabIndex = 98;
			panel_nozzlebasicHigh_visual.Controls.Add(button_goto_basecamera_h_allzn);
			panel_nozzlebasicHigh_visual.Controls.Add(button_goto_basecamera_h);
			panel_nozzlebasicHigh_visual.Controls.Add(button_save_basecamera_h);
			panel_nozzlebasicHigh_visual.Location = new System.Drawing.Point(1, 25);
			panel_nozzlebasicHigh_visual.Name = "panel_nozzlebasicHigh_visual";
			panel_nozzlebasicHigh_visual.Size = new System.Drawing.Size(663, 54);
			panel_nozzlebasicHigh_visual.TabIndex = 93;
			label74.Font = new System.Drawing.Font("黑体", 11f);
			label74.Location = new System.Drawing.Point(0, 0);
			label74.Name = "label74";
			label74.Size = new System.Drawing.Size(474, 29);
			label74.TabIndex = 91;
			label74.Text = "视觉基准高度";
			label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14f);
			label1.Location = new System.Drawing.Point(3, 19);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(159, 19);
			label1.TabIndex = 0;
			label1.Text = "● 快速相机校准";
			tabPage_fix_base.Controls.Add(panel_saveH_shows);
			tabPage_fix_base.Controls.Add(label51);
			tabPage_fix_base.Controls.Add(panel6);
			tabPage_fix_base.Controls.Add(panel_baseH_show);
			tabPage_fix_base.Controls.Add(label75);
			tabPage_fix_base.Controls.Add(label12);
			tabPage_fix_base.Controls.Add(label16);
			tabPage_fix_base.Controls.Add(panel_gen2_H);
			tabPage_fix_base.Location = new System.Drawing.Point(4, 26);
			tabPage_fix_base.Name = "tabPage_fix_base";
			tabPage_fix_base.Padding = new System.Windows.Forms.Padding(3);
			tabPage_fix_base.Size = new System.Drawing.Size(682, 862);
			tabPage_fix_base.TabIndex = 0;
			tabPage_fix_base.Text = "固定参数";
			tabPage_fix_base.UseVisualStyleBackColor = true;
			panel_saveH_shows.Controls.Add(label50);
			panel_saveH_shows.Controls.Add(label45);
			panel_saveH_shows.Controls.Add(label46);
			panel_saveH_shows.Controls.Add(label47);
			panel_saveH_shows.Controls.Add(label49);
			panel_saveH_shows.Controls.Add(label48);
			panel_saveH_shows.Location = new System.Drawing.Point(50, 345);
			panel_saveH_shows.Name = "panel_saveH_shows";
			panel_saveH_shows.Size = new System.Drawing.Size(526, 118);
			panel_saveH_shows.TabIndex = 110;
			label50.AutoSize = true;
			label50.Font = new System.Drawing.Font("黑体", 13.25f);
			label50.Location = new System.Drawing.Point(75, 66);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(26, 18);
			label50.TabIndex = 10;
			label50.Text = "→";
			label45.AutoSize = true;
			label45.Font = new System.Drawing.Font("黑体", 13.25f);
			label45.Location = new System.Drawing.Point(75, 90);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(26, 18);
			label45.TabIndex = 10;
			label45.Text = "→";
			label46.AutoSize = true;
			label46.Font = new System.Drawing.Font("黑体", 13.25f);
			label46.Location = new System.Drawing.Point(75, 21);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(26, 18);
			label46.TabIndex = 10;
			label46.Text = "→";
			label47.Font = new System.Drawing.Font("黑体", 10.25f);
			label47.Location = new System.Drawing.Point(15, 22);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(63, 20);
			label47.TabIndex = 10;
			label47.Text = "贴头吸嘴";
			label47.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label49.Font = new System.Drawing.Font("黑体", 10.25f);
			label49.Location = new System.Drawing.Point(2, 67);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(77, 20);
			label49.TabIndex = 10;
			label49.Text = "运行障碍物";
			label49.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label48.Font = new System.Drawing.Font("黑体", 10.25f);
			label48.Location = new System.Drawing.Point(37, 91);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(42, 20);
			label48.TabIndex = 10;
			label48.Text = "PCB板";
			label48.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label51.BackColor = System.Drawing.Color.DimGray;
			label51.Location = new System.Drawing.Point(-4, 230);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(690, 8);
			label51.TabIndex = 117;
			panel6.Controls.Add(panel_nozzlebasicHigh);
			panel6.Controls.Add(label7);
			panel6.Location = new System.Drawing.Point(0, 135);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(664, 83);
			panel6.TabIndex = 107;
			panel_nozzlebasicHigh.Controls.Add(button_baseH_Goto);
			panel_nozzlebasicHigh.Controls.Add(button_baseH_Save);
			panel_nozzlebasicHigh.Location = new System.Drawing.Point(45, 25);
			panel_nozzlebasicHigh.Name = "panel_nozzlebasicHigh";
			panel_nozzlebasicHigh.Size = new System.Drawing.Size(656, 54);
			panel_nozzlebasicHigh.TabIndex = 92;
			label7.Font = new System.Drawing.Font("黑体", 11.25f);
			label7.Location = new System.Drawing.Point(45, -2);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(636, 29);
			label7.TabIndex = 91;
			label7.Text = "吸嘴刚刚接触到PCB板时的高度 （安装普通工作时吸嘴）";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel_baseH_show.Controls.Add(label39);
			panel_baseH_show.Controls.Add(label44);
			panel_baseH_show.Controls.Add(label42);
			panel_baseH_show.Controls.Add(label40);
			panel_baseH_show.Location = new System.Drawing.Point(47, 53);
			panel_baseH_show.Name = "panel_baseH_show";
			panel_baseH_show.Size = new System.Drawing.Size(506, 82);
			panel_baseH_show.TabIndex = 110;
			label39.Font = new System.Drawing.Font("黑体", 10.25f);
			label39.Location = new System.Drawing.Point(22, 59);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(42, 19);
			label39.TabIndex = 10;
			label39.Text = "PCB板";
			label39.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label44.AutoSize = true;
			label44.Font = new System.Drawing.Font("黑体", 13.25f);
			label44.Location = new System.Drawing.Point(63, 59);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(26, 18);
			label44.TabIndex = 10;
			label44.Text = "→";
			label42.AutoSize = true;
			label42.Font = new System.Drawing.Font("黑体", 13.25f);
			label42.Location = new System.Drawing.Point(63, 28);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(26, 18);
			label42.TabIndex = 10;
			label42.Text = "→";
			label40.Font = new System.Drawing.Font("黑体", 10.25f);
			label40.Location = new System.Drawing.Point(3, 29);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(63, 32);
			label40.TabIndex = 10;
			label40.Text = "贴头吸嘴";
			label40.TextAlign = System.Drawing.ContentAlignment.TopRight;
			label75.Font = new System.Drawing.Font("黑体", 14f);
			label75.Location = new System.Drawing.Point(3, 253);
			label75.Name = "label75";
			label75.Size = new System.Drawing.Size(192, 29);
			label75.TabIndex = 91;
			label75.Text = "● 工作安全高度";
			label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label12.BackColor = System.Drawing.Color.Yellow;
			label12.Font = new System.Drawing.Font("黑体", 14f);
			label12.Location = new System.Drawing.Point(50, 285);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(604, 57);
			label12.TabIndex = 109;
			label12.Text = "警告：工作安全高度设置需非常谨慎！！！必须保证工作时吸嘴要高于行程内最高点，否则会损坏贴装头。敬请重视！";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label16.Font = new System.Drawing.Font("黑体", 14f);
			label16.Location = new System.Drawing.Point(6, 21);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(636, 29);
			label16.TabIndex = 91;
			label16.Text = "● PCB基准高度";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel_gen2_H.Controls.Add(label52);
			panel_gen2_H.Controls.Add(panel27);
			panel_gen2_H.Controls.Add(panel_vaccbreaktime);
			panel_gen2_H.Location = new System.Drawing.Point(-3, 351);
			panel_gen2_H.Name = "panel_gen2_H";
			panel_gen2_H.Size = new System.Drawing.Size(682, 446);
			panel_gen2_H.TabIndex = 108;
			label52.BackColor = System.Drawing.Color.DimGray;
			label52.Location = new System.Drawing.Point(1, 282);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(690, 8);
			label52.TabIndex = 118;
			panel27.Controls.Add(label19);
			panel27.Controls.Add(panel31);
			panel27.Controls.Add(panel_nozzlebasicHigh_run);
			panel27.Location = new System.Drawing.Point(4, 51);
			panel27.Name = "panel27";
			panel27.Size = new System.Drawing.Size(680, 230);
			panel27.TabIndex = 97;
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(44, 67);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(344, 16);
			label19.TabIndex = 94;
			label19.Text = "全自动工作时，XY运行时，吸嘴的安全运行高度";
			panel31.Controls.Add(label212);
			panel31.Controls.Add(checkBox_SafeRunMode);
			panel31.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel31.Location = new System.Drawing.Point(44, 158);
			panel31.Name = "panel31";
			panel31.Size = new System.Drawing.Size(626, 81);
			panel31.TabIndex = 94;
			label212.Font = new System.Drawing.Font("黑体", 12f);
			label212.Location = new System.Drawing.Point(21, 27);
			label212.Name = "label212";
			label212.Size = new System.Drawing.Size(588, 46);
			label212.TabIndex = 2;
			label212.Text = "当PCB基准高度，相机视觉高度，飞达托盘高度相差很大时，必须开启安全模式。";
			checkBox_SafeRunMode.AutoSize = true;
			checkBox_SafeRunMode.Font = new System.Drawing.Font("黑体", 12f);
			checkBox_SafeRunMode.Location = new System.Drawing.Point(6, 5);
			checkBox_SafeRunMode.Name = "checkBox_SafeRunMode";
			checkBox_SafeRunMode.Size = new System.Drawing.Size(91, 20);
			checkBox_SafeRunMode.TabIndex = 1;
			checkBox_SafeRunMode.Text = "安全模式";
			checkBox_SafeRunMode.UseVisualStyleBackColor = true;
			panel_nozzlebasicHigh_run.Controls.Add(button_goto_runsafe_h);
			panel_nozzlebasicHigh_run.Controls.Add(button_save_runsafe_h);
			panel_nozzlebasicHigh_run.Location = new System.Drawing.Point(48, 86);
			panel_nozzlebasicHigh_run.Name = "panel_nozzlebasicHigh_run";
			panel_nozzlebasicHigh_run.Size = new System.Drawing.Size(668, 54);
			panel_nozzlebasicHigh_run.TabIndex = 93;
			panel_vaccbreaktime.Controls.Add(button_vacuum_sync);
			panel_vaccbreaktime.Controls.Add(label132);
			panel_vaccbreaktime.Controls.Add(button_nozzle_clean);
			panel_vaccbreaktime.Font = new System.Drawing.Font("黑体", 9f);
			panel_vaccbreaktime.Location = new System.Drawing.Point(7, 301);
			panel_vaccbreaktime.Name = "panel_vaccbreaktime";
			panel_vaccbreaktime.Size = new System.Drawing.Size(666, 151);
			panel_vaccbreaktime.TabIndex = 171;
			label132.Font = new System.Drawing.Font("黑体", 14f);
			label132.Location = new System.Drawing.Point(4, 5);
			label132.Name = "label132";
			label132.Size = new System.Drawing.Size(545, 29);
			label132.TabIndex = 91;
			label132.Text = "● 吸嘴破真空时间";
			label132.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			tabControl1.Controls.Add(tabPage_fix_cam);
			tabControl1.Controls.Add(tabPage_fix_base);
			tabControl1.Controls.Add(tabPage_fix_nozzledelta);
			tabControl1.Controls.Add(tabPage_fix_feeder);
			tabControl1.Controls.Add(tabPage_fix_factory);
			tabControl1.Font = new System.Drawing.Font("黑体", 12f);
			tabControl1.Location = new System.Drawing.Point(9, 37);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(690, 892);
			tabControl1.TabIndex = 18;
			tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(tabControl1_KeyDown);
			tabPage_fix_factory.BackColor = System.Drawing.Color.Black;
			tabPage_fix_factory.Controls.Add(panel_fix_factory);
			tabPage_fix_factory.Controls.Add(label28);
			tabPage_fix_factory.Location = new System.Drawing.Point(4, 26);
			tabPage_fix_factory.Name = "tabPage_fix_factory";
			tabPage_fix_factory.Padding = new System.Windows.Forms.Padding(3);
			tabPage_fix_factory.Size = new System.Drawing.Size(682, 862);
			tabPage_fix_factory.TabIndex = 4;
			tabPage_fix_factory.Text = "出厂测试";
			panel_fix_factory.Controls.Add(panel_saferun_limit);
			panel_fix_factory.Controls.Add(btn_HideSetting);
			panel_fix_factory.Controls.Add(label31);
			panel_fix_factory.Controls.Add(panel19);
			panel_fix_factory.Controls.Add(panel9);
			panel_fix_factory.Controls.Add(panel8);
			panel_fix_factory.Controls.Add(panel10);
			panel_fix_factory.Controls.Add(panel58);
			panel_fix_factory.Location = new System.Drawing.Point(4, 5);
			panel_fix_factory.Name = "panel_fix_factory";
			panel_fix_factory.Size = new System.Drawing.Size(677, 790);
			panel_fix_factory.TabIndex = 172;
			panel_fix_factory.Visible = false;
			panel_saferun_limit.BackColor = System.Drawing.Color.Red;
			panel_saferun_limit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_saferun_limit.Controls.Add(cnButton_goto_runsafe_limit_h);
			panel_saferun_limit.Controls.Add(cnButton_save_runsafe_limit_h);
			panel_saferun_limit.Controls.Add(panel_baseH_saferun_limited);
			panel_saferun_limit.Controls.Add(label4);
			panel_saferun_limit.Location = new System.Drawing.Point(34, 354);
			panel_saferun_limit.Name = "panel_saferun_limit";
			panel_saferun_limit.Size = new System.Drawing.Size(616, 102);
			panel_saferun_limit.TabIndex = 172;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.ForeColor = System.Drawing.Color.White;
			label4.Location = new System.Drawing.Point(220, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(149, 19);
			label4.TabIndex = 0;
			label4.Text = "安全高度极限值";
			label31.AutoSize = true;
			label31.Font = new System.Drawing.Font("黑体", 18f);
			label31.ForeColor = System.Drawing.Color.White;
			label31.Location = new System.Drawing.Point(259, 16);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(154, 24);
			label31.TabIndex = 162;
			label31.Text = "工厂老化测试";
			label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel19.BackColor = System.Drawing.Color.Black;
			panel19.Controls.Add(cnButton_tool);
			panel19.Controls.Add(label68);
			panel19.Controls.Add(button_algorithm_debug_running);
			panel19.Controls.Add(button_algorithm_debug_cur);
			panel19.Controls.Add(button_algorithm_debug_prev);
			panel19.Controls.Add(numericUpDown_pic_idx);
			panel19.Controls.Add(textBox_testfolder);
			panel19.Controls.Add(button_testfolder);
			panel19.Controls.Add(button_algorithm_debugauto);
			panel19.Controls.Add(button_algorithm_debug);
			panel19.Controls.Add(numericUpDown_factoryvisualtest_angle);
			panel19.Controls.Add(checkBox_factoryDebug);
			panel19.Location = new System.Drawing.Point(4, 615);
			panel19.Name = "panel19";
			panel19.Size = new System.Drawing.Size(662, 164);
			panel19.TabIndex = 170;
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("黑体", 12f);
			label68.ForeColor = System.Drawing.Color.White;
			label68.Location = new System.Drawing.Point(13, 13);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(72, 16);
			label68.TabIndex = 162;
			label68.Text = "视觉调试";
			numericUpDown_pic_idx.Location = new System.Drawing.Point(174, 46);
			numericUpDown_pic_idx.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			numericUpDown_pic_idx.Name = "numericUpDown_pic_idx";
			numericUpDown_pic_idx.Size = new System.Drawing.Size(50, 26);
			numericUpDown_pic_idx.TabIndex = 177;
			numericUpDown_pic_idx.ValueChanged += new System.EventHandler(numericUpDown_pic_idx_ValueChanged);
			textBox_testfolder.Font = new System.Drawing.Font("微软雅黑", 9.5f, System.Drawing.FontStyle.Bold);
			textBox_testfolder.Location = new System.Drawing.Point(9, 74);
			textBox_testfolder.Name = "textBox_testfolder";
			textBox_testfolder.Size = new System.Drawing.Size(494, 24);
			textBox_testfolder.TabIndex = 172;
			textBox_testfolder.Text = "C:/";
			textBox_testfolder.TextChanged += new System.EventHandler(textBox_testfolder_TextChanged);
			numericUpDown_factoryvisualtest_angle.DecimalPlaces = 2;
			numericUpDown_factoryvisualtest_angle.Location = new System.Drawing.Point(522, 45);
			numericUpDown_factoryvisualtest_angle.Maximum = new decimal(new int[4] { 180, 0, 0, 0 });
			numericUpDown_factoryvisualtest_angle.Minimum = new decimal(new int[4] { 180, 0, 0, -2147483648 });
			numericUpDown_factoryvisualtest_angle.Name = "numericUpDown_factoryvisualtest_angle";
			numericUpDown_factoryvisualtest_angle.Size = new System.Drawing.Size(62, 26);
			numericUpDown_factoryvisualtest_angle.TabIndex = 167;
			numericUpDown_factoryvisualtest_angle.ValueChanged += new System.EventHandler(numericUpDown_factoryvisualtest_angle_ValueChanged);
			checkBox_factoryDebug.AutoSize = true;
			checkBox_factoryDebug.ForeColor = System.Drawing.Color.White;
			checkBox_factoryDebug.Location = new System.Drawing.Point(17, 139);
			checkBox_factoryDebug.Name = "checkBox_factoryDebug";
			checkBox_factoryDebug.Size = new System.Drawing.Size(91, 20);
			checkBox_factoryDebug.TabIndex = 158;
			checkBox_factoryDebug.Text = "工厂调试";
			checkBox_factoryDebug.UseVisualStyleBackColor = true;
			checkBox_factoryDebug.CheckedChanged += new System.EventHandler(checkBox_factoryDebug_CheckedChanged);
			panel9.Controls.Add(label65);
			panel9.Controls.Add(button_FactoryTest_AutoFeeder);
			panel9.Controls.Add(button_FactoryTest_OpenFeeder);
			panel9.Controls.Add(checkBox_AutoFeeder_Inc);
			panel9.Controls.Add(label64);
			panel9.Controls.Add(label62);
			panel9.Controls.Add(numericUpDown_AutoFeeder_Delay);
			panel9.Controls.Add(button_FactoryTest_CloseFeeder);
			panel9.Controls.Add(numericUpDown_FactoryTest_feederNum);
			panel9.Font = new System.Drawing.Font("黑体", 11f);
			panel9.Location = new System.Drawing.Point(4, 237);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(662, 111);
			panel9.TabIndex = 169;
			label65.AutoSize = true;
			label65.Font = new System.Drawing.Font("黑体", 12f);
			label65.ForeColor = System.Drawing.Color.White;
			label65.Location = new System.Drawing.Point(22, 10);
			label65.Name = "label65";
			label65.Size = new System.Drawing.Size(128, 16);
			label65.TabIndex = 162;
			label65.Text = "● 飞达老化试验";
			checkBox_AutoFeeder_Inc.AutoSize = true;
			checkBox_AutoFeeder_Inc.ForeColor = System.Drawing.Color.White;
			checkBox_AutoFeeder_Inc.Location = new System.Drawing.Point(485, 46);
			checkBox_AutoFeeder_Inc.Name = "checkBox_AutoFeeder_Inc";
			checkBox_AutoFeeder_Inc.Size = new System.Drawing.Size(138, 19);
			checkBox_AutoFeeder_Inc.TabIndex = 163;
			checkBox_AutoFeeder_Inc.Text = "飞达号自动递增";
			checkBox_AutoFeeder_Inc.UseVisualStyleBackColor = true;
			checkBox_AutoFeeder_Inc.CheckedChanged += new System.EventHandler(checkBox_AutoFeeder_Inc_CheckedChanged);
			label64.AutoSize = true;
			label64.ForeColor = System.Drawing.Color.White;
			label64.Location = new System.Drawing.Point(27, 46);
			label64.Name = "label64";
			label64.Size = new System.Drawing.Size(55, 15);
			label64.TabIndex = 162;
			label64.Text = "飞达号";
			label62.AutoSize = true;
			label62.ForeColor = System.Drawing.Color.White;
			label62.Location = new System.Drawing.Point(326, 83);
			label62.Name = "label62";
			label62.Size = new System.Drawing.Size(135, 15);
			label62.TabIndex = 162;
			label62.Text = "开关时间（毫秒）";
			numericUpDown_AutoFeeder_Delay.Font = new System.Drawing.Font("黑体", 15f);
			numericUpDown_AutoFeeder_Delay.Location = new System.Drawing.Point(468, 78);
			numericUpDown_AutoFeeder_Delay.Maximum = new decimal(new int[4] { 5000, 0, 0, 0 });
			numericUpDown_AutoFeeder_Delay.Minimum = new decimal(new int[4] { 100, 0, 0, 0 });
			numericUpDown_AutoFeeder_Delay.Name = "numericUpDown_AutoFeeder_Delay";
			numericUpDown_AutoFeeder_Delay.Size = new System.Drawing.Size(65, 30);
			numericUpDown_AutoFeeder_Delay.TabIndex = 159;
			numericUpDown_AutoFeeder_Delay.Value = new decimal(new int[4] { 500, 0, 0, 0 });
			numericUpDown_AutoFeeder_Delay.ValueChanged += new System.EventHandler(numericUpDown_AutoFeeder_Delay_ValueChanged);
			numericUpDown_FactoryTest_feederNum.Font = new System.Drawing.Font("黑体", 15f);
			numericUpDown_FactoryTest_feederNum.Location = new System.Drawing.Point(99, 41);
			numericUpDown_FactoryTest_feederNum.Maximum = new decimal(new int[4] { 80, 0, 0, 0 });
			numericUpDown_FactoryTest_feederNum.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_FactoryTest_feederNum.Name = "numericUpDown_FactoryTest_feederNum";
			numericUpDown_FactoryTest_feederNum.Size = new System.Drawing.Size(45, 30);
			numericUpDown_FactoryTest_feederNum.TabIndex = 159;
			numericUpDown_FactoryTest_feederNum.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_FactoryTest_feederNum.ValueChanged += new System.EventHandler(numericUpDown_FactoryTest_feederNum_ValueChanged);
			panel8.Controls.Add(progressBar_FactoryTestAll);
			panel8.Controls.Add(label79);
			panel8.Controls.Add(numericUpDown_factorytestall_hour);
			panel8.Controls.Add(button_FactoryTestAll_Start);
			panel8.Controls.Add(button_FactoryTestAll_Stop);
			panel8.Font = new System.Drawing.Font("黑体", 11f);
			panel8.Location = new System.Drawing.Point(13, 52);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(653, 77);
			panel8.TabIndex = 168;
			progressBar_FactoryTestAll.Location = new System.Drawing.Point(11, 49);
			progressBar_FactoryTestAll.Name = "progressBar_FactoryTestAll";
			progressBar_FactoryTestAll.Size = new System.Drawing.Size(602, 23);
			progressBar_FactoryTestAll.TabIndex = 164;
			label79.AutoSize = true;
			label79.Font = new System.Drawing.Font("黑体", 12f);
			label79.ForeColor = System.Drawing.Color.White;
			label79.Location = new System.Drawing.Point(13, 17);
			label79.Name = "label79";
			label79.Size = new System.Drawing.Size(224, 16);
			label79.TabIndex = 162;
			label79.Text = "● 综合老化试验时间（小时）";
			numericUpDown_factorytestall_hour.DecimalPlaces = 1;
			numericUpDown_factorytestall_hour.Font = new System.Drawing.Font("黑体", 13f);
			numericUpDown_factorytestall_hour.Location = new System.Drawing.Point(271, 14);
			numericUpDown_factorytestall_hour.Maximum = new decimal(new int[4] { 72, 0, 0, 0 });
			numericUpDown_factorytestall_hour.Minimum = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_factorytestall_hour.Name = "numericUpDown_factorytestall_hour";
			numericUpDown_factorytestall_hour.Size = new System.Drawing.Size(62, 27);
			numericUpDown_factorytestall_hour.TabIndex = 159;
			numericUpDown_factorytestall_hour.Value = new decimal(new int[4] { 8, 0, 0, 0 });
			numericUpDown_factorytestall_hour.ValueChanged += new System.EventHandler(numericUpDown_factorytestall_hour_ValueChanged);
			panel10.Controls.Add(label66);
			panel10.Controls.Add(numericUpDown1);
			panel10.Controls.Add(button2);
			panel10.Controls.Add(progressBar1);
			panel10.Controls.Add(button3);
			panel10.Controls.Add(panel12);
			panel10.Enabled = false;
			panel10.Font = new System.Drawing.Font("黑体", 11f);
			panel10.Location = new System.Drawing.Point(4, 462);
			panel10.Name = "panel10";
			panel10.Size = new System.Drawing.Size(662, 91);
			panel10.TabIndex = 167;
			panel10.Visible = false;
			label66.AutoSize = true;
			label66.BackColor = System.Drawing.Color.WhiteSmoke;
			label66.Font = new System.Drawing.Font("黑体", 12f);
			label66.Location = new System.Drawing.Point(22, 19);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(136, 16);
			label66.TabIndex = 162;
			label66.Text = "ZA轴老化试验次数";
			numericUpDown1.Font = new System.Drawing.Font("黑体", 15f);
			numericUpDown1.Location = new System.Drawing.Point(197, 16);
			numericUpDown1.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			numericUpDown1.Minimum = new decimal(new int[4] { 50, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(77, 30);
			numericUpDown1.TabIndex = 159;
			numericUpDown1.Value = new decimal(new int[4] { 50, 0, 0, 0 });
			progressBar1.Location = new System.Drawing.Point(25, 53);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new System.Drawing.Size(628, 23);
			progressBar1.TabIndex = 164;
			panel12.Controls.Add(label67);
			panel12.Controls.Add(numericUpDown2);
			panel12.Controls.Add(button4);
			panel12.Controls.Add(progressBar2);
			panel12.Controls.Add(button5);
			panel12.Enabled = false;
			panel12.Font = new System.Drawing.Font("黑体", 11f);
			panel12.Location = new System.Drawing.Point(16, 19);
			panel12.Name = "panel12";
			panel12.Size = new System.Drawing.Size(662, 94);
			panel12.TabIndex = 167;
			panel12.Visible = false;
			label67.AutoSize = true;
			label67.BackColor = System.Drawing.Color.WhiteSmoke;
			label67.Font = new System.Drawing.Font("黑体", 12f);
			label67.Location = new System.Drawing.Point(22, 19);
			label67.Name = "label67";
			label67.Size = new System.Drawing.Size(136, 16);
			label67.TabIndex = 162;
			label67.Text = "相机老化试验次数";
			numericUpDown2.Font = new System.Drawing.Font("黑体", 15f);
			numericUpDown2.Location = new System.Drawing.Point(197, 16);
			numericUpDown2.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			numericUpDown2.Minimum = new decimal(new int[4] { 50, 0, 0, 0 });
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new System.Drawing.Size(77, 30);
			numericUpDown2.TabIndex = 159;
			numericUpDown2.Value = new decimal(new int[4] { 50, 0, 0, 0 });
			progressBar2.Location = new System.Drawing.Point(25, 53);
			progressBar2.Name = "progressBar2";
			progressBar2.Size = new System.Drawing.Size(628, 23);
			progressBar2.TabIndex = 164;
			panel58.Controls.Add(label13);
			panel58.Controls.Add(numericUpDown_factorytest_count);
			panel58.Controls.Add(button_FactoryTest_Start);
			panel58.Controls.Add(progressBar_FactoryTest);
			panel58.Controls.Add(button_FactoryTest_Stop);
			panel58.Font = new System.Drawing.Font("黑体", 11f);
			panel58.Location = new System.Drawing.Point(4, 144);
			panel58.Name = "panel58";
			panel58.Size = new System.Drawing.Size(662, 100);
			panel58.TabIndex = 167;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("黑体", 12f);
			label13.ForeColor = System.Drawing.Color.White;
			label13.Location = new System.Drawing.Point(22, 19);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(160, 16);
			label13.TabIndex = 162;
			label13.Text = "● XY轴老化试验次数";
			numericUpDown_factorytest_count.Font = new System.Drawing.Font("黑体", 13f);
			numericUpDown_factorytest_count.Location = new System.Drawing.Point(280, 11);
			numericUpDown_factorytest_count.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			numericUpDown_factorytest_count.Minimum = new decimal(new int[4] { 50, 0, 0, 0 });
			numericUpDown_factorytest_count.Name = "numericUpDown_factorytest_count";
			numericUpDown_factorytest_count.Size = new System.Drawing.Size(62, 27);
			numericUpDown_factorytest_count.TabIndex = 159;
			numericUpDown_factorytest_count.Value = new decimal(new int[4] { 50, 0, 0, 0 });
			numericUpDown_factorytest_count.ValueChanged += new System.EventHandler(numericUpDown_factorytest_count_ValueChanged);
			progressBar_FactoryTest.Location = new System.Drawing.Point(20, 49);
			progressBar_FactoryTest.Name = "progressBar_FactoryTest";
			progressBar_FactoryTest.Size = new System.Drawing.Size(602, 23);
			progressBar_FactoryTest.TabIndex = 164;
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("黑体", 25f);
			label28.ForeColor = System.Drawing.Color.White;
			label28.Location = new System.Drawing.Point(191, 260);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(287, 68);
			label28.TabIndex = 162;
			label28.Text = "请输入工厂快捷键\r\n\r\n";
			label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_baseH_saferun_limited.Location = new System.Drawing.Point(9, 27);
			panel_baseH_saferun_limited.Name = "panel_baseH_saferun_limited";
			panel_baseH_saferun_limited.Size = new System.Drawing.Size(488, 54);
			panel_baseH_saferun_limited.TabIndex = 1;
			button_fcam_disable.BackColor = System.Drawing.Color.Silver;
			button_fcam_disable.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_fcam_disable.CnPressDownColor = System.Drawing.Color.White;
			button_fcam_disable.Font = new System.Drawing.Font("黑体", 11f);
			button_fcam_disable.Location = new System.Drawing.Point(189, 79);
			button_fcam_disable.Name = "button_fcam_disable";
			button_fcam_disable.Size = new System.Drawing.Size(173, 32);
			button_fcam_disable.TabIndex = 95;
			button_fcam_disable.Text = "相机吸嘴禁用";
			button_fcam_disable.UseVisualStyleBackColor = false;
			button_fcam_disable.Click += new System.EventHandler(button_fcam_disable_Click);
			button_tmpXY_Goto.BackColor = System.Drawing.Color.Silver;
			button_tmpXY_Goto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_tmpXY_Goto.CnPressDownColor = System.Drawing.Color.White;
			button_tmpXY_Goto.Font = new System.Drawing.Font("黑体", 11f);
			button_tmpXY_Goto.Location = new System.Drawing.Point(604, 749);
			button_tmpXY_Goto.Name = "button_tmpXY_Goto";
			button_tmpXY_Goto.Size = new System.Drawing.Size(52, 42);
			button_tmpXY_Goto.TabIndex = 179;
			button_tmpXY_Goto.Text = "定位";
			button_tmpXY_Goto.UseVisualStyleBackColor = false;
			button_tmpXY_Goto.Click += new System.EventHandler(button_tmpXY_Goto_Click);
			button_test_previewoffset.BackColor = System.Drawing.Color.Silver;
			button_test_previewoffset.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_test_previewoffset.CnPressDownColor = System.Drawing.Color.White;
			button_test_previewoffset.Font = new System.Drawing.Font("黑体", 11f);
			button_test_previewoffset.Location = new System.Drawing.Point(306, 4);
			button_test_previewoffset.Name = "button_test_previewoffset";
			button_test_previewoffset.Size = new System.Drawing.Size(131, 28);
			button_test_previewoffset.TabIndex = 3;
			button_test_previewoffset.Text = "预览偏量测试";
			button_test_previewoffset.UseVisualStyleBackColor = false;
			button_test_previewoffset.Click += new System.EventHandler(button_test_previewoffset_Click);
			button_previewoffset_reset.BackColor = System.Drawing.Color.Silver;
			button_previewoffset_reset.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_previewoffset_reset.CnPressDownColor = System.Drawing.Color.White;
			button_previewoffset_reset.Font = new System.Drawing.Font("黑体", 11f);
			button_previewoffset_reset.Location = new System.Drawing.Point(439, 4);
			button_previewoffset_reset.Name = "button_previewoffset_reset";
			button_previewoffset_reset.Size = new System.Drawing.Size(57, 28);
			button_previewoffset_reset.TabIndex = 2;
			button_previewoffset_reset.Text = "重置";
			button_previewoffset_reset.UseVisualStyleBackColor = false;
			button_previewoffset_reset.Click += new System.EventHandler(button_previewoffset_reset_Click);
			button_tmpXY_Save.BackColor = System.Drawing.Color.Silver;
			button_tmpXY_Save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_tmpXY_Save.CnPressDownColor = System.Drawing.Color.White;
			button_tmpXY_Save.Font = new System.Drawing.Font("黑体", 11f);
			button_tmpXY_Save.Location = new System.Drawing.Point(550, 749);
			button_tmpXY_Save.Name = "button_tmpXY_Save";
			button_tmpXY_Save.Size = new System.Drawing.Size(52, 42);
			button_tmpXY_Save.TabIndex = 180;
			button_tmpXY_Save.Text = "保存";
			button_tmpXY_Save.UseVisualStyleBackColor = false;
			button_tmpXY_Save.Click += new System.EventHandler(button_tmpXY_Save_Click);
			button_MoveToThrowCoord.BackColor = System.Drawing.Color.Silver;
			button_MoveToThrowCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MoveToThrowCoord.CnPressDownColor = System.Drawing.Color.White;
			button_MoveToThrowCoord.Font = new System.Drawing.Font("黑体", 11f);
			button_MoveToThrowCoord.Location = new System.Drawing.Point(604, 701);
			button_MoveToThrowCoord.Name = "button_MoveToThrowCoord";
			button_MoveToThrowCoord.Size = new System.Drawing.Size(52, 42);
			button_MoveToThrowCoord.TabIndex = 177;
			button_MoveToThrowCoord.Text = "定位";
			button_MoveToThrowCoord.UseVisualStyleBackColor = false;
			button_MoveToThrowCoord.Click += new System.EventHandler(button_MoveToThrowCoord_Click);
			button_SaveThrowCoord.BackColor = System.Drawing.Color.Silver;
			button_SaveThrowCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveThrowCoord.CnPressDownColor = System.Drawing.Color.White;
			button_SaveThrowCoord.Font = new System.Drawing.Font("黑体", 11f);
			button_SaveThrowCoord.Location = new System.Drawing.Point(550, 701);
			button_SaveThrowCoord.Name = "button_SaveThrowCoord";
			button_SaveThrowCoord.Size = new System.Drawing.Size(52, 42);
			button_SaveThrowCoord.TabIndex = 175;
			button_SaveThrowCoord.Text = "保存\r\n";
			button_SaveThrowCoord.UseVisualStyleBackColor = false;
			button_SaveThrowCoord.Click += new System.EventHandler(button_SaveThrowCoord_Click);
			button11.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button11.CnPressDownColor = System.Drawing.Color.White;
			button11.Location = new System.Drawing.Point(1170, 183);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(75, 37);
			button11.TabIndex = 0;
			button11.Text = "结束";
			button11.UseVisualStyleBackColor = true;
			button_stop.BackColor = System.Drawing.Color.Silver;
			button_stop.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stop.CnPressDownColor = System.Drawing.Color.White;
			button_stop.Location = new System.Drawing.Point(451, 36);
			button_stop.Name = "button_stop";
			button_stop.Size = new System.Drawing.Size(111, 37);
			button_stop.TabIndex = 0;
			button_stop.Text = "结束";
			button_stop.UseVisualStyleBackColor = false;
			button_stop.Click += new System.EventHandler(button_stop_Click);
			button10.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button10.CnPressDownColor = System.Drawing.Color.White;
			button10.Location = new System.Drawing.Point(1032, 183);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(75, 37);
			button10.TabIndex = 0;
			button10.Text = "恢复";
			button10.UseVisualStyleBackColor = true;
			button_resume.BackColor = System.Drawing.Color.Silver;
			button_resume.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_resume.CnPressDownColor = System.Drawing.Color.White;
			button_resume.Location = new System.Drawing.Point(278, 36);
			button_resume.Name = "button_resume";
			button_resume.Size = new System.Drawing.Size(111, 37);
			button_resume.TabIndex = 0;
			button_resume.Text = "恢复";
			button_resume.UseVisualStyleBackColor = false;
			button_resume.Click += new System.EventHandler(button_resume_Click);
			button_pause.BackColor = System.Drawing.Color.Silver;
			button_pause.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_pause.CnPressDownColor = System.Drawing.Color.White;
			button_pause.Location = new System.Drawing.Point(118, 36);
			button_pause.Name = "button_pause";
			button_pause.Size = new System.Drawing.Size(111, 37);
			button_pause.TabIndex = 0;
			button_pause.Text = "暂停";
			button_pause.UseVisualStyleBackColor = false;
			button_pause.Click += new System.EventHandler(button_pause_Click);
			button_hcam_campara.BackColor = System.Drawing.Color.Silver;
			button_hcam_campara.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_hcam_campara.CnPressDownColor = System.Drawing.Color.White;
			button_hcam_campara.Font = new System.Drawing.Font("黑体", 11f);
			button_hcam_campara.Location = new System.Drawing.Point(601, 4);
			button_hcam_campara.Name = "button_hcam_campara";
			button_hcam_campara.Size = new System.Drawing.Size(60, 50);
			button_hcam_campara.TabIndex = 109;
			button_hcam_campara.Text = "光源\r\n参数";
			button_hcam_campara.UseVisualStyleBackColor = false;
			button_hcam_campara.Click += new System.EventHandler(button_hcam_campara_Click);
			button_hcam_visualtest.BackColor = System.Drawing.Color.Silver;
			button_hcam_visualtest.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_hcam_visualtest.CnPressDownColor = System.Drawing.Color.White;
			button_hcam_visualtest.Font = new System.Drawing.Font("黑体", 11f);
			button_hcam_visualtest.Location = new System.Drawing.Point(548, 4);
			button_hcam_visualtest.Name = "button_hcam_visualtest";
			button_hcam_visualtest.Size = new System.Drawing.Size(52, 50);
			button_hcam_visualtest.TabIndex = 108;
			button_hcam_visualtest.Text = "识别\r\n测试";
			button_hcam_visualtest.UseVisualStyleBackColor = false;
			button_hcam_visualtest.Click += new System.EventHandler(button_hcam_visualtest_Click);
			button_close_hcam_setting.BackColor = System.Drawing.Color.Silver;
			button_close_hcam_setting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_hcam_setting.CnPressDownColor = System.Drawing.Color.White;
			button_close_hcam_setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			button_close_hcam_setting.Location = new System.Drawing.Point(140, 3);
			button_close_hcam_setting.Name = "button_close_hcam_setting";
			button_close_hcam_setting.Size = new System.Drawing.Size(28, 28);
			button_close_hcam_setting.TabIndex = 106;
			button_close_hcam_setting.Text = "X";
			button_close_hcam_setting.UseVisualStyleBackColor = false;
			button_close_hcam_setting.Visible = false;
			button_close_hcam_setting.Click += new System.EventHandler(button_close_hcam_setting_Click);
			button_SingleSetHighCamCoord.BackColor = System.Drawing.Color.Silver;
			button_SingleSetHighCamCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SingleSetHighCamCoord.CnPressDownColor = System.Drawing.Color.White;
			button_SingleSetHighCamCoord.Font = new System.Drawing.Font("黑体", 11f);
			button_SingleSetHighCamCoord.Location = new System.Drawing.Point(334, 23);
			button_SingleSetHighCamCoord.Name = "button_SingleSetHighCamCoord";
			button_SingleSetHighCamCoord.Size = new System.Drawing.Size(105, 43);
			button_SingleSetHighCamCoord.TabIndex = 120;
			button_SingleSetHighCamCoord.Text = "单吸嘴校准";
			button_SingleSetHighCamCoord.UseVisualStyleBackColor = false;
			button_SingleSetHighCamCoord.Click += new System.EventHandler(button_SingleSetHighCamCoord_Click);
			button_AutoSetHighCamCoord.BackColor = System.Drawing.Color.LightSalmon;
			button_AutoSetHighCamCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_AutoSetHighCamCoord.CnPressDownColor = System.Drawing.Color.White;
			button_AutoSetHighCamCoord.Font = new System.Drawing.Font("黑体", 11f);
			button_AutoSetHighCamCoord.Location = new System.Drawing.Point(230, 23);
			button_AutoSetHighCamCoord.Name = "button_AutoSetHighCamCoord";
			button_AutoSetHighCamCoord.Size = new System.Drawing.Size(101, 43);
			button_AutoSetHighCamCoord.TabIndex = 119;
			button_AutoSetHighCamCoord.Text = "全部校准";
			button_AutoSetHighCamCoord.UseVisualStyleBackColor = false;
			button_AutoSetHighCamCoord.Click += new System.EventHandler(button_AutoSetHighCamCoord_Click);
			button_hcam_set.BackColor = System.Drawing.Color.Silver;
			button_hcam_set.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_hcam_set.CnPressDownColor = System.Drawing.Color.White;
			button_hcam_set.Font = new System.Drawing.Font("黑体", 10.5f);
			button_hcam_set.Location = new System.Drawing.Point(153, 22);
			button_hcam_set.Name = "button_hcam_set";
			button_hcam_set.Size = new System.Drawing.Size(44, 44);
			button_hcam_set.TabIndex = 95;
			button_hcam_set.Text = "设置";
			button_hcam_set.UseVisualStyleBackColor = false;
			button_hcam_set.Visible = false;
			button_hcam_set.Click += new System.EventHandler(button_hcam_set_Click);
			button_HighCamMoveToCoord.BackColor = System.Drawing.Color.Silver;
			button_HighCamMoveToCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_HighCamMoveToCoord.CnPressDownColor = System.Drawing.Color.White;
			button_HighCamMoveToCoord.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_HighCamMoveToCoord.Location = new System.Drawing.Point(76, 23);
			button_HighCamMoveToCoord.Name = "button_HighCamMoveToCoord";
			button_HighCamMoveToCoord.Size = new System.Drawing.Size(65, 42);
			button_HighCamMoveToCoord.TabIndex = 115;
			button_HighCamMoveToCoord.Text = "定位";
			button_HighCamMoveToCoord.UseVisualStyleBackColor = false;
			button_HighCamMoveToCoord.Click += new System.EventHandler(button_HighCamMoveToCoord_Click);
			button_hcam_distortion_para.BackColor = System.Drawing.Color.Silver;
			button_hcam_distortion_para.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_hcam_distortion_para.CnPressDownColor = System.Drawing.Color.White;
			button_hcam_distortion_para.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_hcam_distortion_para.Location = new System.Drawing.Point(528, 23);
			button_hcam_distortion_para.Name = "button_hcam_distortion_para";
			button_hcam_distortion_para.Size = new System.Drawing.Size(82, 43);
			button_hcam_distortion_para.TabIndex = 122;
			button_hcam_distortion_para.Text = "参数查看";
			button_hcam_distortion_para.UseVisualStyleBackColor = false;
			button_hcam_distortion_para.Click += new System.EventHandler(button_hcam_distortion_para_Click);
			button7.BackColor = System.Drawing.Color.Silver;
			button7.BackgroundImage = QIGN_COMMON.Properties.Resources.CHESS;
			button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button7.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button7.CnPressDownColor = System.Drawing.Color.White;
			button7.Location = new System.Drawing.Point(612, 23);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(51, 43);
			button7.TabIndex = 99;
			button7.UseVisualStyleBackColor = false;
			button7.Visible = false;
			button_goto_baseHcam_h_allzn.BackColor = System.Drawing.Color.Silver;
			button_goto_baseHcam_h_allzn.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_goto_baseHcam_h_allzn.CnPressDownColor = System.Drawing.Color.White;
			button_goto_baseHcam_h_allzn.Font = new System.Drawing.Font("黑体", 10.5f);
			button_goto_baseHcam_h_allzn.Location = new System.Drawing.Point(610, 0);
			button_goto_baseHcam_h_allzn.Name = "button_goto_baseHcam_h_allzn";
			button_goto_baseHcam_h_allzn.Size = new System.Drawing.Size(52, 50);
			button_goto_baseHcam_h_allzn.TabIndex = 96;
			button_goto_baseHcam_h_allzn.Text = "定位\r\n全部";
			button_goto_baseHcam_h_allzn.UseVisualStyleBackColor = false;
			button_goto_baseHcam_h_allzn.Click += new System.EventHandler(button_goto_baseHcam_h_allzn_Click);
			button_goto_Hcam_baseH.BackColor = System.Drawing.Color.Silver;
			button_goto_Hcam_baseH.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_goto_Hcam_baseH.CnPressDownColor = System.Drawing.Color.White;
			button_goto_Hcam_baseH.Font = new System.Drawing.Font("黑体", 10.5f);
			button_goto_Hcam_baseH.Location = new System.Drawing.Point(557, 0);
			button_goto_Hcam_baseH.Name = "button_goto_Hcam_baseH";
			button_goto_Hcam_baseH.Size = new System.Drawing.Size(52, 50);
			button_goto_Hcam_baseH.TabIndex = 0;
			button_goto_Hcam_baseH.Text = "定位";
			button_goto_Hcam_baseH.UseVisualStyleBackColor = false;
			button_goto_Hcam_baseH.Click += new System.EventHandler(button_goto_Hcam_baseH_Click);
			button_save_Hcam_baseH.BackColor = System.Drawing.Color.Silver;
			button_save_Hcam_baseH.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_save_Hcam_baseH.CnPressDownColor = System.Drawing.Color.White;
			button_save_Hcam_baseH.Font = new System.Drawing.Font("黑体", 10.5f);
			button_save_Hcam_baseH.Location = new System.Drawing.Point(504, 0);
			button_save_Hcam_baseH.Name = "button_save_Hcam_baseH";
			button_save_Hcam_baseH.Size = new System.Drawing.Size(52, 50);
			button_save_Hcam_baseH.TabIndex = 0;
			button_save_Hcam_baseH.Text = "保存";
			button_save_Hcam_baseH.UseVisualStyleBackColor = false;
			button_save_Hcam_baseH.Click += new System.EventHandler(button_save_Hcam_baseH_Click);
			button_fcam_visualtest.BackColor = System.Drawing.Color.Silver;
			button_fcam_visualtest.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_fcam_visualtest.CnPressDownColor = System.Drawing.Color.White;
			button_fcam_visualtest.Font = new System.Drawing.Font("黑体", 11f);
			button_fcam_visualtest.Location = new System.Drawing.Point(548, 10);
			button_fcam_visualtest.Name = "button_fcam_visualtest";
			button_fcam_visualtest.Size = new System.Drawing.Size(52, 50);
			button_fcam_visualtest.TabIndex = 108;
			button_fcam_visualtest.Text = "识别\r\n测试";
			button_fcam_visualtest.UseVisualStyleBackColor = false;
			button_fcam_visualtest.Click += new System.EventHandler(button_fcam_visualtest_Click);
			button_fcam_campara.BackColor = System.Drawing.Color.Silver;
			button_fcam_campara.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_fcam_campara.CnPressDownColor = System.Drawing.Color.White;
			button_fcam_campara.Font = new System.Drawing.Font("黑体", 11f);
			button_fcam_campara.Location = new System.Drawing.Point(601, 10);
			button_fcam_campara.Name = "button_fcam_campara";
			button_fcam_campara.Size = new System.Drawing.Size(60, 50);
			button_fcam_campara.TabIndex = 109;
			button_fcam_campara.Text = "光源\r\n参数";
			button_fcam_campara.UseVisualStyleBackColor = false;
			button_fcam_campara.Click += new System.EventHandler(button_fcam_campara_Click);
			button_close_fcam_setting.BackColor = System.Drawing.Color.Silver;
			button_close_fcam_setting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_fcam_setting.CnPressDownColor = System.Drawing.Color.White;
			button_close_fcam_setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			button_close_fcam_setting.Location = new System.Drawing.Point(135, 7);
			button_close_fcam_setting.Name = "button_close_fcam_setting";
			button_close_fcam_setting.Size = new System.Drawing.Size(28, 28);
			button_close_fcam_setting.TabIndex = 0;
			button_close_fcam_setting.Text = "X";
			button_close_fcam_setting.UseVisualStyleBackColor = false;
			button_close_fcam_setting.Visible = false;
			button_close_fcam_setting.Click += new System.EventHandler(button_close_fcam_setting_Click);
			button1.BackColor = System.Drawing.Color.Silver;
			button1.BackgroundImage = QIGN_COMMON.Properties.Resources.CHESS;
			button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button1.CnPressDownColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(612, 28);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(52, 43);
			button1.TabIndex = 99;
			button1.UseVisualStyleBackColor = false;
			button1.Visible = false;
			button_fcam_distortion_para.BackColor = System.Drawing.Color.Silver;
			button_fcam_distortion_para.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_fcam_distortion_para.CnPressDownColor = System.Drawing.Color.White;
			button_fcam_distortion_para.Font = new System.Drawing.Font("黑体", 11f);
			button_fcam_distortion_para.Location = new System.Drawing.Point(529, 28);
			button_fcam_distortion_para.Name = "button_fcam_distortion_para";
			button_fcam_distortion_para.Size = new System.Drawing.Size(82, 43);
			button_fcam_distortion_para.TabIndex = 111;
			button_fcam_distortion_para.Text = "参数查看";
			button_fcam_distortion_para.UseVisualStyleBackColor = false;
			button_fcam_distortion_para.Click += new System.EventHandler(button_fcam_distortion_para_Click);
			button_AutoSetFastCamCoord.BackColor = System.Drawing.Color.LightSalmon;
			button_AutoSetFastCamCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_AutoSetFastCamCoord.CnPressDownColor = System.Drawing.Color.White;
			button_AutoSetFastCamCoord.Font = new System.Drawing.Font("黑体", 11f);
			button_AutoSetFastCamCoord.Location = new System.Drawing.Point(231, 29);
			button_AutoSetFastCamCoord.Name = "button_AutoSetFastCamCoord";
			button_AutoSetFastCamCoord.Size = new System.Drawing.Size(116, 45);
			button_AutoSetFastCamCoord.TabIndex = 105;
			button_AutoSetFastCamCoord.Text = "自动校准";
			button_AutoSetFastCamCoord.UseVisualStyleBackColor = false;
			button_AutoSetFastCamCoord.Click += new System.EventHandler(button_AutoSetFastCamCoord_Click);
			button_FastCamMoveToCoord.BackColor = System.Drawing.Color.Silver;
			button_FastCamMoveToCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FastCamMoveToCoord.CnPressDownColor = System.Drawing.Color.White;
			button_FastCamMoveToCoord.Font = new System.Drawing.Font("黑体", 10.5f);
			button_FastCamMoveToCoord.Location = new System.Drawing.Point(76, 29);
			button_FastCamMoveToCoord.Name = "button_FastCamMoveToCoord";
			button_FastCamMoveToCoord.Size = new System.Drawing.Size(65, 44);
			button_FastCamMoveToCoord.TabIndex = 106;
			button_FastCamMoveToCoord.Text = "定位";
			button_FastCamMoveToCoord.UseVisualStyleBackColor = false;
			button_FastCamMoveToCoord.Click += new System.EventHandler(button_FastCamMoveToCoord_Click);
			button_fcam_set.BackColor = System.Drawing.Color.Silver;
			button_fcam_set.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_fcam_set.CnPressDownColor = System.Drawing.Color.White;
			button_fcam_set.Font = new System.Drawing.Font("黑体", 10.5f);
			button_fcam_set.Location = new System.Drawing.Point(154, 29);
			button_fcam_set.Name = "button_fcam_set";
			button_fcam_set.Size = new System.Drawing.Size(44, 44);
			button_fcam_set.TabIndex = 95;
			button_fcam_set.Text = "设置";
			button_fcam_set.UseVisualStyleBackColor = false;
			button_fcam_set.Visible = false;
			button_fcam_set.Click += new System.EventHandler(button_fcam_set_Click);
			button_goto_basecamera_h_allzn.BackColor = System.Drawing.Color.Silver;
			button_goto_basecamera_h_allzn.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_goto_basecamera_h_allzn.CnPressDownColor = System.Drawing.Color.White;
			button_goto_basecamera_h_allzn.Font = new System.Drawing.Font("黑体", 10.5f);
			button_goto_basecamera_h_allzn.Location = new System.Drawing.Point(609, 0);
			button_goto_basecamera_h_allzn.Name = "button_goto_basecamera_h_allzn";
			button_goto_basecamera_h_allzn.Size = new System.Drawing.Size(52, 50);
			button_goto_basecamera_h_allzn.TabIndex = 96;
			button_goto_basecamera_h_allzn.Text = "定位\r\n全部";
			button_goto_basecamera_h_allzn.UseVisualStyleBackColor = false;
			button_goto_basecamera_h_allzn.Click += new System.EventHandler(button_goto_basecamera_h_allzn_Click);
			button_goto_basecamera_h.BackColor = System.Drawing.Color.Silver;
			button_goto_basecamera_h.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_goto_basecamera_h.CnPressDownColor = System.Drawing.Color.White;
			button_goto_basecamera_h.Font = new System.Drawing.Font("黑体", 10.5f);
			button_goto_basecamera_h.Location = new System.Drawing.Point(556, 0);
			button_goto_basecamera_h.Name = "button_goto_basecamera_h";
			button_goto_basecamera_h.Size = new System.Drawing.Size(52, 50);
			button_goto_basecamera_h.TabIndex = 93;
			button_goto_basecamera_h.Text = "定位";
			button_goto_basecamera_h.UseVisualStyleBackColor = false;
			button_goto_basecamera_h.Click += new System.EventHandler(button_goto_basecamera_h_Click);
			button_save_basecamera_h.BackColor = System.Drawing.Color.Silver;
			button_save_basecamera_h.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_save_basecamera_h.CnPressDownColor = System.Drawing.Color.White;
			button_save_basecamera_h.Font = new System.Drawing.Font("黑体", 10.5f);
			button_save_basecamera_h.Location = new System.Drawing.Point(503, 0);
			button_save_basecamera_h.Name = "button_save_basecamera_h";
			button_save_basecamera_h.Size = new System.Drawing.Size(52, 50);
			button_save_basecamera_h.TabIndex = 92;
			button_save_basecamera_h.Text = "保存";
			button_save_basecamera_h.UseVisualStyleBackColor = false;
			button_save_basecamera_h.Click += new System.EventHandler(button_save_basecamera_h_Click);
			button_baseH_Goto.BackColor = System.Drawing.Color.Silver;
			button_baseH_Goto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_baseH_Goto.CnPressDownColor = System.Drawing.Color.White;
			button_baseH_Goto.Font = new System.Drawing.Font("黑体", 10.5f);
			button_baseH_Goto.Location = new System.Drawing.Point(566, -1);
			button_baseH_Goto.Name = "button_baseH_Goto";
			button_baseH_Goto.Size = new System.Drawing.Size(52, 50);
			button_baseH_Goto.TabIndex = 91;
			button_baseH_Goto.Text = "定位";
			button_baseH_Goto.UseVisualStyleBackColor = false;
			button_baseH_Goto.Click += new System.EventHandler(button_baseH_Goto_Click);
			button_baseH_Save.BackColor = System.Drawing.Color.Silver;
			button_baseH_Save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_baseH_Save.CnPressDownColor = System.Drawing.Color.White;
			button_baseH_Save.Font = new System.Drawing.Font("黑体", 10.5f);
			button_baseH_Save.Location = new System.Drawing.Point(512, -1);
			button_baseH_Save.Name = "button_baseH_Save";
			button_baseH_Save.Size = new System.Drawing.Size(52, 50);
			button_baseH_Save.TabIndex = 91;
			button_baseH_Save.Text = "保存";
			button_baseH_Save.UseVisualStyleBackColor = false;
			button_baseH_Save.Click += new System.EventHandler(button_baseH_Save_Click);
			button_goto_runsafe_h.BackColor = System.Drawing.Color.Silver;
			button_goto_runsafe_h.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_goto_runsafe_h.CnPressDownColor = System.Drawing.Color.White;
			button_goto_runsafe_h.Font = new System.Drawing.Font("黑体", 10.5f);
			button_goto_runsafe_h.Location = new System.Drawing.Point(562, 0);
			button_goto_runsafe_h.Name = "button_goto_runsafe_h";
			button_goto_runsafe_h.Size = new System.Drawing.Size(52, 50);
			button_goto_runsafe_h.TabIndex = 93;
			button_goto_runsafe_h.Text = "定位";
			button_goto_runsafe_h.UseVisualStyleBackColor = false;
			button_goto_runsafe_h.Click += new System.EventHandler(button_goto_runsafe_h_Click);
			button_save_runsafe_h.BackColor = System.Drawing.Color.Silver;
			button_save_runsafe_h.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_save_runsafe_h.CnPressDownColor = System.Drawing.Color.White;
			button_save_runsafe_h.Font = new System.Drawing.Font("黑体", 10.5f);
			button_save_runsafe_h.Location = new System.Drawing.Point(508, 0);
			button_save_runsafe_h.Name = "button_save_runsafe_h";
			button_save_runsafe_h.Size = new System.Drawing.Size(52, 50);
			button_save_runsafe_h.TabIndex = 92;
			button_save_runsafe_h.Text = "保存";
			button_save_runsafe_h.UseVisualStyleBackColor = false;
			button_save_runsafe_h.Click += new System.EventHandler(button_save_runsafe_h_Click);
			button_vacuum_sync.BackColor = System.Drawing.Color.Silver;
			button_vacuum_sync.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_vacuum_sync.CnPressDownColor = System.Drawing.Color.White;
			button_vacuum_sync.Font = new System.Drawing.Font("黑体", 10.5f);
			button_vacuum_sync.Location = new System.Drawing.Point(553, 34);
			button_vacuum_sync.Name = "button_vacuum_sync";
			button_vacuum_sync.Size = new System.Drawing.Size(52, 51);
			button_vacuum_sync.TabIndex = 92;
			button_vacuum_sync.Text = "同步";
			button_vacuum_sync.UseVisualStyleBackColor = false;
			button_vacuum_sync.Click += new System.EventHandler(button_vacuum_sync_Click);
			button_nozzle_clean.BackColor = System.Drawing.Color.Silver;
			button_nozzle_clean.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_nozzle_clean.CnPressDownColor = System.Drawing.Color.White;
			button_nozzle_clean.Font = new System.Drawing.Font("黑体", 10.5f);
			button_nozzle_clean.Location = new System.Drawing.Point(574, 5);
			button_nozzle_clean.Name = "button_nozzle_clean";
			button_nozzle_clean.Size = new System.Drawing.Size(83, 29);
			button_nozzle_clean.TabIndex = 0;
			button_nozzle_clean.Text = "吸嘴清理";
			button_nozzle_clean.UseVisualStyleBackColor = false;
			button_nozzle_clean.Visible = false;
			button_nzdelta_para_check.BackColor = System.Drawing.Color.Silver;
			button_nzdelta_para_check.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_nzdelta_para_check.CnPressDownColor = System.Drawing.Color.White;
			button_nzdelta_para_check.Font = new System.Drawing.Font("黑体", 10f);
			button_nzdelta_para_check.Location = new System.Drawing.Point(590, 631);
			button_nzdelta_para_check.Name = "button_nzdelta_para_check";
			button_nzdelta_para_check.Size = new System.Drawing.Size(84, 26);
			button_nzdelta_para_check.TabIndex = 112;
			button_nzdelta_para_check.Text = "参数查看";
			button_nzdelta_para_check.UseVisualStyleBackColor = false;
			button_nzdelta_para_check.Click += new System.EventHandler(button_nzdelta_para_check_Click);
			button_switchto_campage.BackColor = System.Drawing.Color.Silver;
			button_switchto_campage.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_switchto_campage.CnPressDownColor = System.Drawing.Color.White;
			button_switchto_campage.Font = new System.Drawing.Font("黑体", 12f);
			button_switchto_campage.Location = new System.Drawing.Point(225, 77);
			button_switchto_campage.Name = "button_switchto_campage";
			button_switchto_campage.Size = new System.Drawing.Size(199, 32);
			button_switchto_campage.TabIndex = 118;
			button_switchto_campage.Text = "MARK相机预览偏量";
			button_switchto_campage.UseVisualStyleBackColor = false;
			button_switchto_campage.Click += new System.EventHandler(button_switchto_campage_Click);
			button_switchto_basepage.BackColor = System.Drawing.Color.Silver;
			button_switchto_basepage.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_switchto_basepage.CnPressDownColor = System.Drawing.Color.White;
			button_switchto_basepage.Font = new System.Drawing.Font("黑体", 12f);
			button_switchto_basepage.Location = new System.Drawing.Point(225, 148);
			button_switchto_basepage.Name = "button_switchto_basepage";
			button_switchto_basepage.Size = new System.Drawing.Size(199, 32);
			button_switchto_basepage.TabIndex = 117;
			button_switchto_basepage.Text = "PCB基准高度";
			button_switchto_basepage.UseVisualStyleBackColor = false;
			button_switchto_basepage.Click += new System.EventHandler(button_switchto_basepage_Click);
			button_StartZnDelta.BackColor = System.Drawing.Color.LightSalmon;
			button_StartZnDelta.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_StartZnDelta.CnPressDownColor = System.Drawing.Color.White;
			button_StartZnDelta.Font = new System.Drawing.Font("黑体", 13.5f);
			button_StartZnDelta.Location = new System.Drawing.Point(240, 16);
			button_StartZnDelta.Name = "button_StartZnDelta";
			button_StartZnDelta.Size = new System.Drawing.Size(170, 40);
			button_StartZnDelta.TabIndex = 12;
			button_StartZnDelta.Text = "开始扎点";
			button_StartZnDelta.UseVisualStyleBackColor = false;
			button_StartZnDelta.Click += new System.EventHandler(button_StartZnDelta_Click);
			button_center_clear.BackColor = System.Drawing.Color.Silver;
			button_center_clear.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_center_clear.CnPressDownColor = System.Drawing.Color.White;
			button_center_clear.Font = new System.Drawing.Font("黑体", 10.5f);
			button_center_clear.Location = new System.Drawing.Point(98, 92);
			button_center_clear.Name = "button_center_clear";
			button_center_clear.Size = new System.Drawing.Size(54, 34);
			button_center_clear.TabIndex = 85;
			button_center_clear.Text = "清除";
			button_center_clear.UseVisualStyleBackColor = false;
			button_center_clear.Click += new System.EventHandler(button_center_clear_Click);
			button_center_confirm.BackColor = System.Drawing.Color.Silver;
			button_center_confirm.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_center_confirm.CnPressDownColor = System.Drawing.Color.White;
			button_center_confirm.Font = new System.Drawing.Font("黑体", 10.5f);
			button_center_confirm.Location = new System.Drawing.Point(3, 91);
			button_center_confirm.Name = "button_center_confirm";
			button_center_confirm.Size = new System.Drawing.Size(93, 35);
			button_center_confirm.TabIndex = 77;
			button_center_confirm.Tag = "1";
			button_center_confirm.Text = "圆心确认";
			button_center_confirm.UseVisualStyleBackColor = false;
			button_center_confirm.Click += new System.EventHandler(button_center_confirm_Click);
			button_deltaDone.BackColor = System.Drawing.Color.Silver;
			button_deltaDone.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_deltaDone.CnPressDownColor = System.Drawing.Color.White;
			button_deltaDone.Enabled = false;
			button_deltaDone.Font = new System.Drawing.Font("黑体", 10.5f);
			button_deltaDone.ForeColor = System.Drawing.SystemColors.ControlText;
			button_deltaDone.Location = new System.Drawing.Point(210, 90);
			button_deltaDone.Name = "button_deltaDone";
			button_deltaDone.Size = new System.Drawing.Size(88, 35);
			button_deltaDone.TabIndex = 83;
			button_deltaDone.Text = "全部完成";
			button_deltaDone.UseVisualStyleBackColor = false;
			button_deltaDone.Click += new System.EventHandler(button_deltaDone_Click);
			button_auto_deltaDone_Interupt.BackColor = System.Drawing.Color.Silver;
			button_auto_deltaDone_Interupt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_auto_deltaDone_Interupt.CnPressDownColor = System.Drawing.Color.White;
			button_auto_deltaDone_Interupt.Font = new System.Drawing.Font("黑体", 10.5f);
			button_auto_deltaDone_Interupt.Location = new System.Drawing.Point(151, 91);
			button_auto_deltaDone_Interupt.Name = "button_auto_deltaDone_Interupt";
			button_auto_deltaDone_Interupt.Size = new System.Drawing.Size(74, 35);
			button_auto_deltaDone_Interupt.TabIndex = 2;
			button_auto_deltaDone_Interupt.Text = "中断";
			button_auto_deltaDone_Interupt.UseVisualStyleBackColor = false;
			button_auto_deltaDone_Interupt.Click += new System.EventHandler(button_auto_deltaDone_Interupt_Click);
			button_auto_deltaDone.BackColor = System.Drawing.Color.Silver;
			button_auto_deltaDone.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_auto_deltaDone.CnPressDownColor = System.Drawing.Color.White;
			button_auto_deltaDone.Font = new System.Drawing.Font("黑体", 10.5f);
			button_auto_deltaDone.Location = new System.Drawing.Point(2, 91);
			button_auto_deltaDone.Name = "button_auto_deltaDone";
			button_auto_deltaDone.Size = new System.Drawing.Size(148, 35);
			button_auto_deltaDone.TabIndex = 1;
			button_auto_deltaDone.Text = "一键自动确认圆心";
			button_auto_deltaDone.UseVisualStyleBackColor = false;
			button_auto_deltaDone.Click += new System.EventHandler(button_auto_deltaDone_Click);
			button_AutoGen_InkCollectH.BackColor = System.Drawing.Color.Silver;
			button_AutoGen_InkCollectH.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_AutoGen_InkCollectH.CnPressDownColor = System.Drawing.Color.White;
			button_AutoGen_InkCollectH.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_AutoGen_InkCollectH.ForeColor = System.Drawing.SystemColors.ControlText;
			button_AutoGen_InkCollectH.Location = new System.Drawing.Point(540, 211);
			button_AutoGen_InkCollectH.Name = "button_AutoGen_InkCollectH";
			button_AutoGen_InkCollectH.Size = new System.Drawing.Size(128, 35);
			button_AutoGen_InkCollectH.TabIndex = 20;
			button_AutoGen_InkCollectH.Text = "生成所有采泥高度";
			button_AutoGen_InkCollectH.UseVisualStyleBackColor = false;
			button_AutoGen_InkCollectH.Click += new System.EventHandler(button_AutoGen_InkCollectH_Click);
			button_MoveToInkPadCollectCoord.BackColor = System.Drawing.Color.Silver;
			button_MoveToInkPadCollectCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MoveToInkPadCollectCoord.CnPressDownColor = System.Drawing.Color.White;
			button_MoveToInkPadCollectCoord.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_MoveToInkPadCollectCoord.Location = new System.Drawing.Point(608, 129);
			button_MoveToInkPadCollectCoord.Name = "button_MoveToInkPadCollectCoord";
			button_MoveToInkPadCollectCoord.Size = new System.Drawing.Size(60, 38);
			button_MoveToInkPadCollectCoord.TabIndex = 16;
			button_MoveToInkPadCollectCoord.Text = "定位";
			button_MoveToInkPadCollectCoord.UseVisualStyleBackColor = false;
			button_MoveToInkPadCollectCoord.Click += new System.EventHandler(button_MoveToInkPadCollectCoord_Click);
			button_SaveInkPadCollectHeight.BackColor = System.Drawing.Color.Silver;
			button_SaveInkPadCollectHeight.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveInkPadCollectHeight.CnPressDownColor = System.Drawing.Color.White;
			button_SaveInkPadCollectHeight.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_SaveInkPadCollectHeight.Location = new System.Drawing.Point(541, 171);
			button_SaveInkPadCollectHeight.Name = "button_SaveInkPadCollectHeight";
			button_SaveInkPadCollectHeight.Size = new System.Drawing.Size(60, 38);
			button_SaveInkPadCollectHeight.TabIndex = 12;
			button_SaveInkPadCollectHeight.Text = "保存";
			button_SaveInkPadCollectHeight.UseVisualStyleBackColor = false;
			button_SaveInkPadCollectHeight.Click += new System.EventHandler(button_SaveInkPadCollectHeight_Click);
			button_AutoGen_InkWriteH.BackColor = System.Drawing.Color.Silver;
			button_AutoGen_InkWriteH.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_AutoGen_InkWriteH.CnPressDownColor = System.Drawing.Color.White;
			button_AutoGen_InkWriteH.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_AutoGen_InkWriteH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_AutoGen_InkWriteH.Location = new System.Drawing.Point(538, 3);
			button_AutoGen_InkWriteH.Name = "button_AutoGen_InkWriteH";
			button_AutoGen_InkWriteH.Size = new System.Drawing.Size(128, 35);
			button_AutoGen_InkWriteH.TabIndex = 20;
			button_AutoGen_InkWriteH.Text = "生成所有扎点高度";
			button_AutoGen_InkWriteH.UseVisualStyleBackColor = false;
			button_AutoGen_InkWriteH.Click += new System.EventHandler(button_AutoGen_InkWriteH_Click);
			button_SaveInkPadWriteHeight.BackColor = System.Drawing.Color.Silver;
			button_SaveInkPadWriteHeight.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveInkPadWriteHeight.CnPressDownColor = System.Drawing.Color.White;
			button_SaveInkPadWriteHeight.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_SaveInkPadWriteHeight.Location = new System.Drawing.Point(539, 40);
			button_SaveInkPadWriteHeight.Name = "button_SaveInkPadWriteHeight";
			button_SaveInkPadWriteHeight.Size = new System.Drawing.Size(60, 38);
			button_SaveInkPadWriteHeight.TabIndex = 12;
			button_SaveInkPadWriteHeight.Text = "保存";
			button_SaveInkPadWriteHeight.UseVisualStyleBackColor = false;
			button_SaveInkPadWriteHeight.Click += new System.EventHandler(button_SaveInkPadWriteHeight_Click);
			button_MoveToInkPadWriteHeight.BackColor = System.Drawing.Color.Silver;
			button_MoveToInkPadWriteHeight.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MoveToInkPadWriteHeight.CnPressDownColor = System.Drawing.Color.White;
			button_MoveToInkPadWriteHeight.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_MoveToInkPadWriteHeight.Location = new System.Drawing.Point(605, 39);
			button_MoveToInkPadWriteHeight.Name = "button_MoveToInkPadWriteHeight";
			button_MoveToInkPadWriteHeight.Size = new System.Drawing.Size(60, 38);
			button_MoveToInkPadWriteHeight.TabIndex = 12;
			button_MoveToInkPadWriteHeight.Text = "定位";
			button_MoveToInkPadWriteHeight.UseVisualStyleBackColor = false;
			button_MoveToInkPadWriteHeight.Click += new System.EventHandler(button_MoveToInkPadWriteHeight_Click);
			button_MoveToInkPadCollectHeight.BackColor = System.Drawing.Color.Silver;
			button_MoveToInkPadCollectHeight.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MoveToInkPadCollectHeight.CnPressDownColor = System.Drawing.Color.White;
			button_MoveToInkPadCollectHeight.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_MoveToInkPadCollectHeight.Location = new System.Drawing.Point(608, 171);
			button_MoveToInkPadCollectHeight.Name = "button_MoveToInkPadCollectHeight";
			button_MoveToInkPadCollectHeight.Size = new System.Drawing.Size(60, 38);
			button_MoveToInkPadCollectHeight.TabIndex = 12;
			button_MoveToInkPadCollectHeight.Text = "定位";
			button_MoveToInkPadCollectHeight.UseVisualStyleBackColor = false;
			button_MoveToInkPadCollectHeight.Click += new System.EventHandler(button_MoveToInkPadCollectHeight_Click);
			button_SaveInkPadCollectCoord.BackColor = System.Drawing.Color.Silver;
			button_SaveInkPadCollectCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveInkPadCollectCoord.CnPressDownColor = System.Drawing.Color.White;
			button_SaveInkPadCollectCoord.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_SaveInkPadCollectCoord.Location = new System.Drawing.Point(486, 129);
			button_SaveInkPadCollectCoord.Name = "button_SaveInkPadCollectCoord";
			button_SaveInkPadCollectCoord.Size = new System.Drawing.Size(115, 38);
			button_SaveInkPadCollectCoord.TabIndex = 15;
			button_SaveInkPadCollectCoord.Text = "保存印泥坐标";
			button_SaveInkPadCollectCoord.UseVisualStyleBackColor = false;
			button_SaveInkPadCollectCoord.Click += new System.EventHandler(button_SaveInkPadCollectCoord_Click);
			button_SaveInkPadWriteCoord.BackColor = System.Drawing.Color.Silver;
			button_SaveInkPadWriteCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SaveInkPadWriteCoord.CnPressDownColor = System.Drawing.Color.White;
			button_SaveInkPadWriteCoord.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_SaveInkPadWriteCoord.Location = new System.Drawing.Point(486, 87);
			button_SaveInkPadWriteCoord.Name = "button_SaveInkPadWriteCoord";
			button_SaveInkPadWriteCoord.Size = new System.Drawing.Size(115, 38);
			button_SaveInkPadWriteCoord.TabIndex = 12;
			button_SaveInkPadWriteCoord.Text = "保存扎点起始";
			button_SaveInkPadWriteCoord.UseVisualStyleBackColor = false;
			button_SaveInkPadWriteCoord.Click += new System.EventHandler(button_SaveInkPadWriteCoord_Click);
			button_MoveToInkPadWriteCoord.BackColor = System.Drawing.Color.Silver;
			button_MoveToInkPadWriteCoord.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MoveToInkPadWriteCoord.CnPressDownColor = System.Drawing.Color.White;
			button_MoveToInkPadWriteCoord.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_MoveToInkPadWriteCoord.Location = new System.Drawing.Point(608, 87);
			button_MoveToInkPadWriteCoord.Name = "button_MoveToInkPadWriteCoord";
			button_MoveToInkPadWriteCoord.Size = new System.Drawing.Size(60, 38);
			button_MoveToInkPadWriteCoord.TabIndex = 12;
			button_MoveToInkPadWriteCoord.Text = "定位";
			button_MoveToInkPadWriteCoord.UseVisualStyleBackColor = false;
			button_MoveToInkPadWriteCoord.Click += new System.EventHandler(button_MoveToInkPadWriteCoord_Click);
			button_feederBaseBkH_Goto.BackColor = System.Drawing.Color.Silver;
			button_feederBaseBkH_Goto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_feederBaseBkH_Goto.CnPressDownColor = System.Drawing.Color.White;
			button_feederBaseBkH_Goto.Font = new System.Drawing.Font("黑体", 11f);
			button_feederBaseBkH_Goto.Location = new System.Drawing.Point(234, 20);
			button_feederBaseBkH_Goto.Name = "button_feederBaseBkH_Goto";
			button_feederBaseBkH_Goto.Size = new System.Drawing.Size(60, 45);
			button_feederBaseBkH_Goto.TabIndex = 162;
			button_feederBaseBkH_Goto.Tag = "back";
			button_feederBaseBkH_Goto.Text = "定位";
			button_feederBaseBkH_Goto.UseVisualStyleBackColor = false;
			button_feederBaseBkH_Goto.Click += new System.EventHandler(button_feederBaseH_Goto_Click);
			button_feederBaseBkH_AutoGen.BackColor = System.Drawing.Color.Silver;
			button_feederBaseBkH_AutoGen.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_feederBaseBkH_AutoGen.CnPressDownColor = System.Drawing.Color.White;
			button_feederBaseBkH_AutoGen.Font = new System.Drawing.Font("黑体", 11f);
			button_feederBaseBkH_AutoGen.Location = new System.Drawing.Point(341, 20);
			button_feederBaseBkH_AutoGen.Name = "button_feederBaseBkH_AutoGen";
			button_feederBaseBkH_AutoGen.Size = new System.Drawing.Size(176, 45);
			button_feederBaseBkH_AutoGen.TabIndex = 162;
			button_feederBaseBkH_AutoGen.Tag = "back";
			button_feederBaseBkH_AutoGen.Text = "生成后端飞达基准高度";
			button_feederBaseBkH_AutoGen.UseVisualStyleBackColor = false;
			button_feederBaseBkH_AutoGen.Click += new System.EventHandler(button_feederBaseH_AutoGen_Click);
			button_feederBaseBKH_Save.BackColor = System.Drawing.Color.Silver;
			button_feederBaseBKH_Save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_feederBaseBKH_Save.CnPressDownColor = System.Drawing.Color.White;
			button_feederBaseBKH_Save.Font = new System.Drawing.Font("黑体", 11f);
			button_feederBaseBKH_Save.Location = new System.Drawing.Point(168, 20);
			button_feederBaseBKH_Save.Name = "button_feederBaseBKH_Save";
			button_feederBaseBKH_Save.Size = new System.Drawing.Size(60, 45);
			button_feederBaseBKH_Save.TabIndex = 162;
			button_feederBaseBKH_Save.Tag = "back";
			button_feederBaseBKH_Save.Text = "保存";
			button_feederBaseBKH_Save.UseVisualStyleBackColor = false;
			button_feederBaseBKH_Save.Click += new System.EventHandler(button_feederBaseH_Save_Click);
			button_feederBaseH_Goto.BackColor = System.Drawing.Color.Silver;
			button_feederBaseH_Goto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_feederBaseH_Goto.CnPressDownColor = System.Drawing.Color.White;
			button_feederBaseH_Goto.Font = new System.Drawing.Font("黑体", 11f);
			button_feederBaseH_Goto.Location = new System.Drawing.Point(235, 27);
			button_feederBaseH_Goto.Name = "button_feederBaseH_Goto";
			button_feederBaseH_Goto.Size = new System.Drawing.Size(60, 45);
			button_feederBaseH_Goto.TabIndex = 98;
			button_feederBaseH_Goto.Tag = "front";
			button_feederBaseH_Goto.Text = "定位";
			button_feederBaseH_Goto.UseVisualStyleBackColor = false;
			button_feederBaseH_Goto.Click += new System.EventHandler(button_feederBaseH_Goto_Click);
			button_feederBaseH_Save.BackColor = System.Drawing.Color.Silver;
			button_feederBaseH_Save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_feederBaseH_Save.CnPressDownColor = System.Drawing.Color.White;
			button_feederBaseH_Save.Font = new System.Drawing.Font("黑体", 11f);
			button_feederBaseH_Save.Location = new System.Drawing.Point(169, 27);
			button_feederBaseH_Save.Name = "button_feederBaseH_Save";
			button_feederBaseH_Save.Size = new System.Drawing.Size(60, 45);
			button_feederBaseH_Save.TabIndex = 97;
			button_feederBaseH_Save.Tag = "front";
			button_feederBaseH_Save.Text = "保存";
			button_feederBaseH_Save.UseVisualStyleBackColor = false;
			button_feederBaseH_Save.Click += new System.EventHandler(button_feederBaseH_Save_Click);
			button_feederBaseH_AutoGen.BackColor = System.Drawing.Color.Silver;
			button_feederBaseH_AutoGen.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_feederBaseH_AutoGen.CnPressDownColor = System.Drawing.Color.White;
			button_feederBaseH_AutoGen.Font = new System.Drawing.Font("黑体", 11f);
			button_feederBaseH_AutoGen.Location = new System.Drawing.Point(340, 27);
			button_feederBaseH_AutoGen.Name = "button_feederBaseH_AutoGen";
			button_feederBaseH_AutoGen.Size = new System.Drawing.Size(176, 45);
			button_feederBaseH_AutoGen.TabIndex = 96;
			button_feederBaseH_AutoGen.Tag = "front";
			button_feederBaseH_AutoGen.Text = "生成前端飞达基准高度";
			button_feederBaseH_AutoGen.UseVisualStyleBackColor = false;
			button_feederBaseH_AutoGen.Click += new System.EventHandler(button_feederBaseH_AutoGen_Click);
			button_gotoSlot_byZn.BackColor = System.Drawing.Color.Silver;
			button_gotoSlot_byZn.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_gotoSlot_byZn.CnPressDownColor = System.Drawing.Color.White;
			button_gotoSlot_byZn.Font = new System.Drawing.Font("楷体", 10.25f);
			button_gotoSlot_byZn.Location = new System.Drawing.Point(239, 7);
			button_gotoSlot_byZn.Name = "button_gotoSlot_byZn";
			button_gotoSlot_byZn.Size = new System.Drawing.Size(132, 30);
			button_gotoSlot_byZn.TabIndex = 160;
			button_gotoSlot_byZn.Text = "吸嘴定位到飞达";
			button_gotoSlot_byZn.UseVisualStyleBackColor = false;
			button_gotoSlot_byZn.Click += new System.EventHandler(button_gotoSlot_byZn_Click);
			button_slotOpen.BackColor = System.Drawing.Color.Silver;
			button_slotOpen.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_slotOpen.CnPressDownColor = System.Drawing.Color.White;
			button_slotOpen.Font = new System.Drawing.Font("楷体", 10.25f);
			button_slotOpen.Location = new System.Drawing.Point(392, 7);
			button_slotOpen.Name = "button_slotOpen";
			button_slotOpen.Size = new System.Drawing.Size(86, 30);
			button_slotOpen.TabIndex = 160;
			button_slotOpen.Text = "开飞达";
			button_slotOpen.UseVisualStyleBackColor = false;
			button_slotOpen.Click += new System.EventHandler(button_slotOpen_Click);
			button_saveSlot.BackColor = System.Drawing.Color.Silver;
			button_saveSlot.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_saveSlot.CnPressDownColor = System.Drawing.Color.White;
			button_saveSlot.Font = new System.Drawing.Font("楷体", 10.25f);
			button_saveSlot.Location = new System.Drawing.Point(143, 43);
			button_saveSlot.Name = "button_saveSlot";
			button_saveSlot.Size = new System.Drawing.Size(90, 30);
			button_saveSlot.TabIndex = 160;
			button_saveSlot.Text = "保存坐标";
			button_saveSlot.UseVisualStyleBackColor = false;
			button_saveSlot.Click += new System.EventHandler(button_saveSlot_Click);
			button_gotoSlot.BackColor = System.Drawing.Color.Silver;
			button_gotoSlot.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_gotoSlot.CnPressDownColor = System.Drawing.Color.White;
			button_gotoSlot.Font = new System.Drawing.Font("楷体", 10.25f);
			button_gotoSlot.Location = new System.Drawing.Point(143, 7);
			button_gotoSlot.Name = "button_gotoSlot";
			button_gotoSlot.Size = new System.Drawing.Size(90, 30);
			button_gotoSlot.TabIndex = 160;
			button_gotoSlot.Text = "定位坐标";
			button_gotoSlot.UseVisualStyleBackColor = false;
			button_gotoSlot.Click += new System.EventHandler(button_gotoSlot_Click);
			button_slotClose.BackColor = System.Drawing.Color.Silver;
			button_slotClose.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_slotClose.CnPressDownColor = System.Drawing.Color.White;
			button_slotClose.Font = new System.Drawing.Font("楷体", 10.25f);
			button_slotClose.Location = new System.Drawing.Point(484, 7);
			button_slotClose.Name = "button_slotClose";
			button_slotClose.Size = new System.Drawing.Size(90, 30);
			button_slotClose.TabIndex = 160;
			button_slotClose.Text = "关飞达";
			button_slotClose.UseVisualStyleBackColor = false;
			button_slotClose.Click += new System.EventHandler(button_slotClose_Click);
			button_slotxy_to_curUsr2.BackColor = System.Drawing.Color.Silver;
			button_slotxy_to_curUsr2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_slotxy_to_curUsr2.CnPressDownColor = System.Drawing.Color.White;
			button_slotxy_to_curUsr2.Font = new System.Drawing.Font("黑体", 12f);
			button_slotxy_to_curUsr2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_slotxy_to_curUsr2.Location = new System.Drawing.Point(411, 129);
			button_slotxy_to_curUsr2.Name = "button_slotxy_to_curUsr2";
			button_slotxy_to_curUsr2.Size = new System.Drawing.Size(160, 38);
			button_slotxy_to_curUsr2.TabIndex = 160;
			button_slotxy_to_curUsr2.Text = "同步到当前工程";
			button_slotxy_to_curUsr2.UseVisualStyleBackColor = false;
			button_slotxy_to_curUsr2.Click += new System.EventHandler(button_slotxy_to_curUsr2_Click);
			button_SlotsXYGens.BackColor = System.Drawing.Color.Silver;
			button_SlotsXYGens.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SlotsXYGens.CnPressDownColor = System.Drawing.Color.White;
			button_SlotsXYGens.Font = new System.Drawing.Font("黑体", 12f);
			button_SlotsXYGens.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			button_SlotsXYGens.Location = new System.Drawing.Point(250, 129);
			button_SlotsXYGens.Name = "button_SlotsXYGens";
			button_SlotsXYGens.Size = new System.Drawing.Size(159, 38);
			button_SlotsXYGens.TabIndex = 2;
			button_SlotsXYGens.Text = "生成料站默认坐标";
			button_SlotsXYGens.UseVisualStyleBackColor = false;
			button_SlotsXYGens.Click += new System.EventHandler(button_SlotsXYGens_Click);
			button_slotMoveToXY.BackColor = System.Drawing.Color.Silver;
			button_slotMoveToXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_slotMoveToXY.CnPressDownColor = System.Drawing.Color.White;
			button_slotMoveToXY.Font = new System.Drawing.Font("黑体", 12f);
			button_slotMoveToXY.Location = new System.Drawing.Point(164, 129);
			button_slotMoveToXY.Name = "button_slotMoveToXY";
			button_slotMoveToXY.Size = new System.Drawing.Size(84, 38);
			button_slotMoveToXY.TabIndex = 2;
			button_slotMoveToXY.Text = "定位坐标";
			button_slotMoveToXY.UseVisualStyleBackColor = false;
			button_slotMoveToXY.Click += new System.EventHandler(button_slotMoveToXY_Click);
			button_slotSaveXY.BackColor = System.Drawing.Color.Silver;
			button_slotSaveXY.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_slotSaveXY.CnPressDownColor = System.Drawing.Color.White;
			button_slotSaveXY.Font = new System.Drawing.Font("黑体", 12f);
			button_slotSaveXY.Location = new System.Drawing.Point(77, 129);
			button_slotSaveXY.Name = "button_slotSaveXY";
			button_slotSaveXY.Size = new System.Drawing.Size(85, 38);
			button_slotSaveXY.TabIndex = 2;
			button_slotSaveXY.Text = "保存坐标";
			button_slotSaveXY.UseVisualStyleBackColor = false;
			button_slotSaveXY.Click += new System.EventHandler(button_slotSaveXY_Click);
			cnButton_goto_runsafe_limit_h.BackColor = System.Drawing.Color.LightGray;
			cnButton_goto_runsafe_limit_h.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_goto_runsafe_limit_h.CnPressDownColor = System.Drawing.Color.White;
			cnButton_goto_runsafe_limit_h.Location = new System.Drawing.Point(557, 27);
			cnButton_goto_runsafe_limit_h.Name = "cnButton_goto_runsafe_limit_h";
			cnButton_goto_runsafe_limit_h.Size = new System.Drawing.Size(52, 50);
			cnButton_goto_runsafe_limit_h.TabIndex = 2;
			cnButton_goto_runsafe_limit_h.Text = "定位\r\nZ轴";
			cnButton_goto_runsafe_limit_h.UseVisualStyleBackColor = false;
			cnButton_goto_runsafe_limit_h.Click += new System.EventHandler(cnButton_goto_runsafe_limit_h_Click);
			cnButton_save_runsafe_limit_h.BackColor = System.Drawing.Color.LightGray;
			cnButton_save_runsafe_limit_h.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_save_runsafe_limit_h.CnPressDownColor = System.Drawing.Color.White;
			cnButton_save_runsafe_limit_h.Location = new System.Drawing.Point(503, 27);
			cnButton_save_runsafe_limit_h.Name = "cnButton_save_runsafe_limit_h";
			cnButton_save_runsafe_limit_h.Size = new System.Drawing.Size(52, 50);
			cnButton_save_runsafe_limit_h.TabIndex = 2;
			cnButton_save_runsafe_limit_h.Text = "保存\r\nZ轴";
			cnButton_save_runsafe_limit_h.UseVisualStyleBackColor = false;
			cnButton_save_runsafe_limit_h.Click += new System.EventHandler(cnButton_save_runsafe_limit_h_Click);
			btn_HideSetting.BackColor = System.Drawing.Color.Silver;
			btn_HideSetting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			btn_HideSetting.CnPressDownColor = System.Drawing.Color.White;
			btn_HideSetting.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_HideSetting.ForeColor = System.Drawing.Color.Black;
			btn_HideSetting.Location = new System.Drawing.Point(235, 565);
			btn_HideSetting.Name = "btn_HideSetting";
			btn_HideSetting.Size = new System.Drawing.Size(178, 44);
			btn_HideSetting.TabIndex = 171;
			btn_HideSetting.Text = "完成老化试验";
			btn_HideSetting.UseVisualStyleBackColor = false;
			btn_HideSetting.Click += new System.EventHandler(btn_HideSetting_Click);
			cnButton_tool.BackColor = System.Drawing.Color.Silver;
			cnButton_tool.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_tool.CnPressDownColor = System.Drawing.Color.White;
			cnButton_tool.Location = new System.Drawing.Point(114, 136);
			cnButton_tool.Name = "cnButton_tool";
			cnButton_tool.Size = new System.Drawing.Size(94, 25);
			cnButton_tool.TabIndex = 179;
			cnButton_tool.Text = "转换工具";
			cnButton_tool.UseVisualStyleBackColor = false;
			cnButton_tool.Click += new System.EventHandler(cnButton_tool_Click);
			button_algorithm_debug_running.BackColor = System.Drawing.Color.Silver;
			button_algorithm_debug_running.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_algorithm_debug_running.CnPressDownColor = System.Drawing.Color.White;
			button_algorithm_debug_running.Location = new System.Drawing.Point(71, 46);
			button_algorithm_debug_running.Name = "button_algorithm_debug_running";
			button_algorithm_debug_running.Size = new System.Drawing.Size(91, 25);
			button_algorithm_debug_running.TabIndex = 178;
			button_algorithm_debug_running.Text = "实时视觉";
			button_algorithm_debug_running.UseVisualStyleBackColor = false;
			button_algorithm_debug_running.Click += new System.EventHandler(button_algorithm_debug_running_Click);
			button_algorithm_debug_cur.BackColor = System.Drawing.Color.Silver;
			button_algorithm_debug_cur.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_algorithm_debug_cur.CnPressDownColor = System.Drawing.Color.White;
			button_algorithm_debug_cur.Location = new System.Drawing.Point(8, 46);
			button_algorithm_debug_cur.Name = "button_algorithm_debug_cur";
			button_algorithm_debug_cur.Size = new System.Drawing.Size(62, 25);
			button_algorithm_debug_cur.TabIndex = 178;
			button_algorithm_debug_cur.Tag = "cur";
			button_algorithm_debug_cur.Text = "视觉";
			button_algorithm_debug_cur.UseVisualStyleBackColor = false;
			button_algorithm_debug_cur.Click += new System.EventHandler(button_algorithm_debug_Click);
			button_algorithm_debug_prev.BackColor = System.Drawing.Color.Silver;
			button_algorithm_debug_prev.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_algorithm_debug_prev.CnPressDownColor = System.Drawing.Color.White;
			button_algorithm_debug_prev.Location = new System.Drawing.Point(231, 45);
			button_algorithm_debug_prev.Name = "button_algorithm_debug_prev";
			button_algorithm_debug_prev.Size = new System.Drawing.Size(85, 25);
			button_algorithm_debug_prev.TabIndex = 178;
			button_algorithm_debug_prev.Tag = "prev";
			button_algorithm_debug_prev.Text = "←视觉";
			button_algorithm_debug_prev.UseVisualStyleBackColor = false;
			button_algorithm_debug_prev.Click += new System.EventHandler(button_algorithm_debug_Click);
			button_testfolder.BackColor = System.Drawing.Color.Silver;
			button_testfolder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_testfolder.CnPressDownColor = System.Drawing.Color.White;
			button_testfolder.Location = new System.Drawing.Point(507, 73);
			button_testfolder.Name = "button_testfolder";
			button_testfolder.Size = new System.Drawing.Size(94, 26);
			button_testfolder.TabIndex = 171;
			button_testfolder.Text = "浏览...";
			button_testfolder.UseVisualStyleBackColor = false;
			button_testfolder.Click += new System.EventHandler(button_testfolder_Click);
			button_algorithm_debugauto.BackColor = System.Drawing.Color.Silver;
			button_algorithm_debugauto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_algorithm_debugauto.CnPressDownColor = System.Drawing.Color.White;
			button_algorithm_debugauto.Location = new System.Drawing.Point(407, 45);
			button_algorithm_debugauto.Name = "button_algorithm_debugauto";
			button_algorithm_debugauto.Size = new System.Drawing.Size(94, 25);
			button_algorithm_debugauto.TabIndex = 169;
			button_algorithm_debugauto.Text = "视觉全部";
			button_algorithm_debugauto.UseVisualStyleBackColor = false;
			button_algorithm_debugauto.Click += new System.EventHandler(button_algorithm_debugauto_Click);
			button_algorithm_debug.BackColor = System.Drawing.Color.Silver;
			button_algorithm_debug.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_algorithm_debug.CnPressDownColor = System.Drawing.Color.White;
			button_algorithm_debug.Location = new System.Drawing.Point(322, 45);
			button_algorithm_debug.Name = "button_algorithm_debug";
			button_algorithm_debug.Size = new System.Drawing.Size(79, 25);
			button_algorithm_debug.TabIndex = 168;
			button_algorithm_debug.Tag = "next";
			button_algorithm_debug.Text = "视觉→";
			button_algorithm_debug.UseVisualStyleBackColor = false;
			button_algorithm_debug.Click += new System.EventHandler(button_algorithm_debug_Click);
			button_FactoryTest_AutoFeeder.BackColor = System.Drawing.Color.Silver;
			button_FactoryTest_AutoFeeder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FactoryTest_AutoFeeder.CnPressDownColor = System.Drawing.Color.White;
			button_FactoryTest_AutoFeeder.Location = new System.Drawing.Point(322, 41);
			button_FactoryTest_AutoFeeder.Name = "button_FactoryTest_AutoFeeder";
			button_FactoryTest_AutoFeeder.Size = new System.Drawing.Size(146, 32);
			button_FactoryTest_AutoFeeder.TabIndex = 161;
			button_FactoryTest_AutoFeeder.Text = "自动开关飞达";
			button_FactoryTest_AutoFeeder.UseVisualStyleBackColor = false;
			button_FactoryTest_AutoFeeder.Click += new System.EventHandler(button_FactoryTest_AutoFeeder_Click);
			button_FactoryTest_OpenFeeder.BackColor = System.Drawing.Color.Silver;
			button_FactoryTest_OpenFeeder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FactoryTest_OpenFeeder.CnPressDownColor = System.Drawing.Color.White;
			button_FactoryTest_OpenFeeder.Location = new System.Drawing.Point(150, 41);
			button_FactoryTest_OpenFeeder.Name = "button_FactoryTest_OpenFeeder";
			button_FactoryTest_OpenFeeder.Size = new System.Drawing.Size(80, 32);
			button_FactoryTest_OpenFeeder.TabIndex = 160;
			button_FactoryTest_OpenFeeder.Text = "开飞达";
			button_FactoryTest_OpenFeeder.UseVisualStyleBackColor = false;
			button_FactoryTest_OpenFeeder.Click += new System.EventHandler(button_FactoryTest_OpenFeeder_Click);
			button_FactoryTest_CloseFeeder.BackColor = System.Drawing.Color.Silver;
			button_FactoryTest_CloseFeeder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FactoryTest_CloseFeeder.CnPressDownColor = System.Drawing.Color.White;
			button_FactoryTest_CloseFeeder.Location = new System.Drawing.Point(236, 41);
			button_FactoryTest_CloseFeeder.Name = "button_FactoryTest_CloseFeeder";
			button_FactoryTest_CloseFeeder.Size = new System.Drawing.Size(80, 32);
			button_FactoryTest_CloseFeeder.TabIndex = 161;
			button_FactoryTest_CloseFeeder.Text = "关飞达";
			button_FactoryTest_CloseFeeder.UseVisualStyleBackColor = false;
			button_FactoryTest_CloseFeeder.Click += new System.EventHandler(button_FactoryTest_CloseFeeder_Click);
			button_FactoryTestAll_Start.BackColor = System.Drawing.Color.Silver;
			button_FactoryTestAll_Start.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FactoryTestAll_Start.CnPressDownColor = System.Drawing.Color.White;
			button_FactoryTestAll_Start.Location = new System.Drawing.Point(354, 13);
			button_FactoryTestAll_Start.Name = "button_FactoryTestAll_Start";
			button_FactoryTestAll_Start.Size = new System.Drawing.Size(80, 29);
			button_FactoryTestAll_Start.TabIndex = 165;
			button_FactoryTestAll_Start.Text = "开始";
			button_FactoryTestAll_Start.UseVisualStyleBackColor = false;
			button_FactoryTestAll_Start.Click += new System.EventHandler(button_FactoryTestAll_Start_Click);
			button_FactoryTestAll_Stop.BackColor = System.Drawing.Color.Silver;
			button_FactoryTestAll_Stop.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FactoryTestAll_Stop.CnPressDownColor = System.Drawing.Color.White;
			button_FactoryTestAll_Stop.Location = new System.Drawing.Point(440, 13);
			button_FactoryTestAll_Stop.Name = "button_FactoryTestAll_Stop";
			button_FactoryTestAll_Stop.Size = new System.Drawing.Size(80, 29);
			button_FactoryTestAll_Stop.TabIndex = 165;
			button_FactoryTestAll_Stop.Text = "停止";
			button_FactoryTestAll_Stop.UseVisualStyleBackColor = false;
			button_FactoryTestAll_Stop.Click += new System.EventHandler(button_FactoryTestAll_Stop_Click);
			button2.BackColor = System.Drawing.Color.Silver;
			button2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button2.CnPressDownColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(280, 15);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(80, 32);
			button2.TabIndex = 160;
			button2.Text = "开始";
			button2.UseVisualStyleBackColor = false;
			button3.BackColor = System.Drawing.Color.Silver;
			button3.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button3.CnPressDownColor = System.Drawing.Color.White;
			button3.Location = new System.Drawing.Point(366, 15);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(80, 32);
			button3.TabIndex = 161;
			button3.Text = "停止";
			button3.UseVisualStyleBackColor = false;
			button4.BackColor = System.Drawing.Color.Silver;
			button4.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button4.CnPressDownColor = System.Drawing.Color.White;
			button4.Location = new System.Drawing.Point(280, 15);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(80, 32);
			button4.TabIndex = 160;
			button4.Text = "开始";
			button4.UseVisualStyleBackColor = false;
			button5.BackColor = System.Drawing.Color.Silver;
			button5.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button5.CnPressDownColor = System.Drawing.Color.White;
			button5.Location = new System.Drawing.Point(366, 15);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(80, 32);
			button5.TabIndex = 161;
			button5.Text = "停止";
			button5.UseVisualStyleBackColor = false;
			button_FactoryTest_Start.BackColor = System.Drawing.Color.Silver;
			button_FactoryTest_Start.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FactoryTest_Start.CnPressDownColor = System.Drawing.Color.White;
			button_FactoryTest_Start.Location = new System.Drawing.Point(363, 10);
			button_FactoryTest_Start.Name = "button_FactoryTest_Start";
			button_FactoryTest_Start.Size = new System.Drawing.Size(80, 29);
			button_FactoryTest_Start.TabIndex = 160;
			button_FactoryTest_Start.Text = "开始";
			button_FactoryTest_Start.UseVisualStyleBackColor = false;
			button_FactoryTest_Start.Click += new System.EventHandler(button_FactoryTest_Start_Click);
			button_FactoryTest_Stop.BackColor = System.Drawing.Color.Silver;
			button_FactoryTest_Stop.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FactoryTest_Stop.CnPressDownColor = System.Drawing.Color.White;
			button_FactoryTest_Stop.Location = new System.Drawing.Point(449, 10);
			button_FactoryTest_Stop.Name = "button_FactoryTest_Stop";
			button_FactoryTest_Stop.Size = new System.Drawing.Size(80, 29);
			button_FactoryTest_Stop.TabIndex = 161;
			button_FactoryTest_Stop.Text = "停止";
			button_FactoryTest_Stop.UseVisualStyleBackColor = false;
			button_FactoryTest_Stop.Click += new System.EventHandler(button_FactoryTest_Stop_Click);
			button_close.BackColor = System.Drawing.Color.Silver;
			button_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close.CnPressDownColor = System.Drawing.Color.White;
			button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
			button_close.Location = new System.Drawing.Point(666, 3);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(30, 30);
			button_close.TabIndex = 17;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = false;
			button_close.Click += new System.EventHandler(button_close_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.DimGray;
			base.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			base.Controls.Add(tabControl1);
			base.Controls.Add(button_close);
			base.Controls.Add(label_FixSetting);
			Font = new System.Drawing.Font("黑体", 10.5f);
			base.Name = "UserControl_SystemSetting";
			base.Size = new System.Drawing.Size(709, 940);
			base.Load += new System.EventHandler(UserControl_SystemSetting_Load);
			tabPage_fix_feeder.ResumeLayout(false);
			tabPage_fix_feeder.PerformLayout();
			panel29.ResumeLayout(false);
			panel62.ResumeLayout(false);
			panel62.PerformLayout();
			panel61.ResumeLayout(false);
			panel61.PerformLayout();
			panel14.ResumeLayout(false);
			panel14.PerformLayout();
			panel110.ResumeLayout(false);
			tabPage_fix_nozzledelta.ResumeLayout(false);
			tabPage_fix_nozzledelta.PerformLayout();
			panel46.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			tabControl2.ResumeLayout(false);
			tabPage12.ResumeLayout(false);
			tabPage11.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDown_test_threshold).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_test_scanr).EndInit();
			panel_fixnozzle1.ResumeLayout(false);
			panel24.ResumeLayout(false);
			panel24.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_InkWrite_Offset).EndInit();
			panel11.ResumeLayout(false);
			panel11.PerformLayout();
			panel33.ResumeLayout(false);
			panel33.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_previewoffset_y).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_previewoffset_x).EndInit();
			((System.ComponentModel.ISupportInitialize)nud_MarkRatio).EndInit();
			tabPage_fix_cam.ResumeLayout(false);
			tabPage_fix_cam.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel_color.ResumeLayout(false);
			panel_color.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_color_b).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_color_g).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_color_r).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel_pausestop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
			panel_hcam_calib.ResumeLayout(false);
			panel_hcam_setting.ResumeLayout(false);
			panel_hcam_setting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_rec_size).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_threshold).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_liebian).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_hcam_scanr).EndInit();
			panel_hcam_h.ResumeLayout(false);
			panel_Hcam_baseH.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel_fcam_calib.ResumeLayout(false);
			panel_fcam_setting.ResumeLayout(false);
			panel_fcam_setting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_fcam_threshold).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_fcam_scanr).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_fcam__recsize).EndInit();
			panel_fcam_h.ResumeLayout(false);
			panel_nozzlebasicHigh_visual.ResumeLayout(false);
			tabPage_fix_base.ResumeLayout(false);
			panel_saveH_shows.ResumeLayout(false);
			panel_saveH_shows.PerformLayout();
			panel6.ResumeLayout(false);
			panel_nozzlebasicHigh.ResumeLayout(false);
			panel_baseH_show.ResumeLayout(false);
			panel_baseH_show.PerformLayout();
			panel_gen2_H.ResumeLayout(false);
			panel27.ResumeLayout(false);
			panel27.PerformLayout();
			panel31.ResumeLayout(false);
			panel31.PerformLayout();
			panel_nozzlebasicHigh_run.ResumeLayout(false);
			panel_vaccbreaktime.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage_fix_factory.ResumeLayout(false);
			tabPage_fix_factory.PerformLayout();
			panel_fix_factory.ResumeLayout(false);
			panel_fix_factory.PerformLayout();
			panel_saferun_limit.ResumeLayout(false);
			panel_saferun_limit.PerformLayout();
			panel19.ResumeLayout(false);
			panel19.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pic_idx).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_factoryvisualtest_angle).EndInit();
			panel9.ResumeLayout(false);
			panel9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_AutoFeeder_Delay).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_FactoryTest_feederNum).EndInit();
			panel8.ResumeLayout(false);
			panel8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_factorytestall_hour).EndInit();
			panel10.ResumeLayout(false);
			panel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			panel12.ResumeLayout(false);
			panel12.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
			panel58.ResumeLayout(false);
			panel58.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_factorytest_count).EndInit();
			ResumeLayout(false);
		}

		private void __checkBox_delta_nozzle_singlemode_CheckedChanged(object sender, EventArgs e)
		{
			mIsDeltaNozzle_SingleMode = checkBox_delta_nozzle_singlemode.Checked;
			flush_zn_delta_nozzle();
		}

		private void flush_zn_delta_nozzle()
		{
			if (bt_inkpoint == null || bt_inkpoint[0] == null || bt_inkpoint[0][0] == null)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < HW.mZnNum[mFn]; j++)
				{
					bt_inkpoint[i][j].Visible = !mIsDeltaNozzle_SingleMode || j == MainForm0.mZn[mFn];
				}
			}
		}

		private void __button_StartZnDelta_Click(object sender, EventArgs e)
		{
			string text = "You must configure all setting before calibration, including MAKR camera, Inkpad etc. ";
			string text2 = "校准前请先设置好相关参数(包括开启Mark相机)，摆好印泥的位置，校准过程中禁止做其他操作！ 是否开始进行校准？";
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? text : text2, MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				if (MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				}
				set_pausestop_visable("nozzledelta", flag: true);
				Thread thread = new Thread(thd_StartCalibration);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		private void thd_StartCalibration()
		{
			Invoke((MethodInvoker)delegate
			{
				checkBox_delta_nozzle_singlemode.Enabled = false;
			});
			MainForm0.thd_ZnAnAlltoZero(mFn);
			if ((MainForm0.mRunDoing[mFn] & 2) == 0)
			{
				panel_InkPoint.Invoke((MethodInvoker)delegate
				{
					panel_InkPoint.Enabled = true;
				});
				for (int c = 0; c < 4; c++)
				{
					int zn3;
					for (zn3 = 0; zn3 < HW.mZnNum[mFn]; zn3++)
					{
						if (!mIsDeltaNozzle_SingleMode || zn3 == MainForm0.mZn[mFn])
						{
							Invoke((MethodInvoker)delegate
							{
								bt_inkpoint[c][zn3].BackColor = Color.White;
							});
						}
					}
				}
				int num = 0;
				num = 0;
				while (true)
				{
					if (num < 4)
					{
						for (int i = 0; i < 4; i++)
						{
							int zn2;
							for (zn2 = 0; zn2 < HW.mZnNum[mFn]; zn2++)
							{
								if (!mIsDeltaNozzle_SingleMode || zn2 == MainForm0.mZn[mFn])
								{
									MainForm0.radiobt_zn[mFn][zn2].Invoke((MethodInvoker)delegate
									{
										MainForm0.radiobt_zn[mFn][zn2].Checked = true;
									});
									DateTime now = DateTime.Now;
									_ = (DateTime.Now - now).TotalMilliseconds;
									MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(USR.mInkPad_CollectCoord.X - 2500 * zn2, USR.mInkPad_CollectCoord.Y));
									if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
									{
										goto end_IL_0735;
									}
									MainForm0.moveToZ_andWait(mFn, MainForm0.mZn[mFn], USR.mZSpeed, USR.mInkPad_CollectHeight[MainForm0.mZn[mFn]]);
									Thread.Sleep(10);
									MainForm0.moveToZ_andWait(mFn, MainForm0.mZn[mFn], USR.mZSpeed, 0);
									if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
									{
										goto end_IL_0735;
									}
									MainForm0.moveToA_noWait(mFn, zn2, USR.mASpeed, (int)Math.Round((double)(90 * i * 128) * 200.0 / 360.0, 0) % (200 * HW.mAaxisSubDivision));
									if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
									{
										goto end_IL_0735;
									}
								}
							}
							MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(USR.mInkPad_WriteCoord.X + num * 1000, USR.mInkPad_WriteCoord.Y + num * 1000));
							if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
							{
								goto end_IL_0735;
							}
							MainForm0.WaitComplete_A(mFn, MainForm0.mZn[mFn]);
							if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
							{
								goto end_IL_0735;
							}
							if (HW.mSmtGenerationNo == 2)
							{
								for (int j = 0; j < HW.mZnNum[mFn]; j++)
								{
									if (!mIsDeltaNozzle_SingleMode || j == MainForm0.mZn[mFn])
									{
										MainForm0.moveToZ_noWait(mFn, j, USR.mZSpeed, USR.mInkPad_WriteHeight[j]);
										if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
										{
											goto end_IL_0735;
										}
									}
								}
								for (int k = 0; k < HW.mZnNum[mFn]; k++)
								{
									if (!mIsDeltaNozzle_SingleMode || k == MainForm0.mZn[mFn])
									{
										MainForm0.WaitComplete_Z(mFn, k);
										bt_inkpoint[num][k].BackColor = Color.FromArgb(255, 225 - i * i * 25, 225 - i * i * 25);
										if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
										{
											goto end_IL_0735;
										}
									}
								}
								MainForm0.msdelay(200);
								for (int l = 0; l < HW.mZnNum[mFn]; l++)
								{
									if (!mIsDeltaNozzle_SingleMode || l == MainForm0.mZn[mFn])
									{
										MainForm0.moveToZ_noWait(mFn, l, USR.mZSpeed, 0);
										if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
										{
											goto end_IL_0735;
										}
									}
								}
								for (int m = 0; m < HW.mZnNum[mFn]; m++)
								{
									if (!mIsDeltaNozzle_SingleMode || m == MainForm0.mZn[mFn])
									{
										MainForm0.WaitComplete_Z(mFn, m);
										if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
										{
											goto end_IL_0735;
										}
									}
								}
								continue;
							}
							int zn;
							for (zn = 0; zn < HW.mZnNum[mFn]; zn++)
							{
								if (!mIsDeltaNozzle_SingleMode || zn == MainForm0.mZn[mFn])
								{
									MainForm0.radiobt_zn[mFn][zn].Invoke((MethodInvoker)delegate
									{
										MainForm0.radiobt_zn[mFn][zn].Checked = true;
									});
									MainForm0.msdelay(100);
									if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
									{
										goto end_IL_0735;
									}
									MainForm0.WaitComplete_XY(mFn);
									if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
									{
										goto end_IL_0735;
									}
									MainForm0.WaitComplete_A(mFn, MainForm0.mZn[mFn]);
									if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
									{
										goto end_IL_0735;
									}
									MainForm0.moveToZ_andWait(mFn, MainForm0.mZn[mFn], USR.mZSpeed, USR.mInkPad_WriteHeight[MainForm0.mZn[mFn]]);
									Thread.Sleep(10);
									MainForm0.moveToZ_andWait(mFn, MainForm0.mZn[mFn], USR.mZSpeed, 0);
									if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
									{
										goto end_IL_0735;
									}
									bt_inkpoint[num][zn].BackColor = Color.FromArgb(255, 225 - i * i * 25, 225 - i * i * 25);
								}
							}
						}
						num++;
						continue;
					}
					MainForm0.thd_ZnAnAlltoZero(mFn);
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						break;
					}
					if (!mIsDeltaNozzle_SingleMode)
					{
						MainForm0.radiobt_zn[mFn][0].Invoke((MethodInvoker)delegate
						{
							MainForm0.radiobt_zn[mFn][0].Checked = true;
						});
						DateTime now2 = DateTime.Now;
						for (double totalMilliseconds = (DateTime.Now - now2).TotalMilliseconds; totalMilliseconds <= 100.0; totalMilliseconds = (DateTime.Now - now2).TotalMilliseconds)
						{
						}
					}
					MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(USR.mInkPad_WriteCoord.X + USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].X, USR.mInkPad_WriteCoord.Y + USR.mDeltaNozzle[0][MainForm0.mZn[mFn]].Y));
					if ((MainForm0.mRunDoing[mFn] & 2) == 0)
					{
						Invoke((MethodInvoker)delegate
						{
							checkBox_delta_nozzle_singlemode.Enabled = true;
						});
					}
					break;
					continue;
					end_IL_0735:
					break;
				}
			}
			MainForm0.thd_ZnAnAlltoZero(mFn);
			set_pausestop_visable("nozzledelta", flag: false);
			MainForm0.mRunDoing[mFn] = 0;
		}

		private void __button_center_confirm_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(thd_CenterConfirm);
			thread.IsBackground = true;
			thread.Start();
		}

		private void thd_CenterConfirm()
		{
			int num = mCurInkPoint.X;
			int num2 = mCurInkPoint.Y;
			Coordinate coordinate = new Coordinate(0L, 0L);
			int num3 = 0;
			USR.mDeltaNozzle_Detail[num2][num].X = MainForm0.mCur[mFn].x - USR.mInkPad_WriteCoord.X - num2 * 1000;
			USR.mDeltaNozzle_Detail[num2][num].Y = MainForm0.mCur[mFn].y - USR.mInkPad_WriteCoord.Y - num2 * 1000;
			mInkPointConfirmed[num2][num] = true;
			for (int i = 0; i < 4; i++)
			{
				if (mInkPointConfirmed[i][num])
				{
					num3++;
					coordinate.X += USR.mDeltaNozzle_Detail[i][num].X;
					coordinate.Y += USR.mDeltaNozzle_Detail[i][num].Y;
				}
			}
			if (num3 != 0)
			{
				USR.mDeltaNozzle[0][num].X = coordinate.X / num3;
				USR.mDeltaNozzle[0][num].Y = coordinate.Y / num3;
			}
			bt_inkpoint[num2][num].BackColor = Color.FromArgb(0, 255, 0);
			bool flag = true;
			for (int j = 0; j < 4; j++)
			{
				for (int k = 0; k < HW.mZnNum[mFn]; k++)
				{
					if ((!mIsDeltaNozzle_SingleMode || num == MainForm0.mZn[mFn]) && !mInkPointConfirmed[j][k])
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				button_deltaDone.Invoke((MethodInvoker)delegate
				{
					button_deltaDone.Enabled = true;
				});
			}
			MainForm0.save_FixedData();
		}

		private void __button_center_clear_Click(object sender, EventArgs e)
		{
			int num = mCurInkPoint.X;
			int num2 = mCurInkPoint.Y;
			mInkPointConfirmed[num2][num] = false;
			bt_inkpoint[num2][num].BackColor = Color.FromArgb(0, 255, 0);
		}

		private void __button_deltaDone_Click(object sender, EventArgs e)
		{
			MainForm0.save_FixedData();
		}

		private void __button_auto_deltaDone_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Move mark camera center around to left up ink point " : "是否已经将MARK相机的十字线中心移动到左上角的印泥点附近？", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			if (mIsCenterConfirmed == null)
			{
				mIsCenterConfirmed = new bool[4][];
				for (int i = 0; i < 4; i++)
				{
					mIsCenterConfirmed[i] = new bool[HW.mZnNum[mFn]];
				}
			}
			for (int j = 0; j < 4; j++)
			{
				for (int k = 0; k < HW.mZnNum[mFn]; k++)
				{
					if (!mIsDeltaNozzle_SingleMode || k == MainForm0.mZn[mFn])
					{
						mIsCenterConfirmed[j][k] = false;
						bt_inkpoint[j][k].BackColor = Color.FromArgb(255, 0, 0);
					}
				}
			}
			MainForm0.mIsVisualRunning = true;
			Thread thread = new Thread(thd_auto_deltaDone);
			thread.IsBackground = true;
			thread.Start();
		}

		private void thd_auto_deltaDone()
		{
			Invoke((MethodInvoker)delegate
			{
				button_auto_deltaDone_Interupt.Visible = true;
				button_auto_deltaDone.Enabled = false;
				checkBox_delta_nozzle_singlemode.Enabled = false;
			});
			MainForm0.moveToZero_ZA_andWait(mFn);
			int i = 0;
			while (true)
			{
				if (i < 4)
				{
					int zn;
					for (zn = 0; zn < HW.mZnNum[mFn]; zn++)
					{
						if (!MainForm0.mIsVisualRunning)
						{
							goto end_IL_039b;
						}
						if (mIsDeltaNozzle_SingleMode && zn != MainForm0.mZn[mFn])
						{
							continue;
						}
						Invoke((MethodInvoker)delegate
						{
							MainForm0.radiobt_zn[mFn][zn].Checked = true;
						});
						MainForm0.msdelay(100);
						bool flag = false;
						if (this.vsplus_nozzledelta_auto_center_loop != null)
						{
							flag = this.vsplus_nozzledelta_auto_center_loop();
						}
						if (!flag || !MainForm0.mIsVisualRunning)
						{
							goto end_IL_039b;
						}
						USR.mDeltaNozzle_Detail[i][zn].X = MainForm0.mCur[mFn].x - USR.mInkPad_WriteCoord.X - i * 1000;
						USR.mDeltaNozzle_Detail[i][zn].Y = MainForm0.mCur[mFn].y - USR.mInkPad_WriteCoord.Y - i * 1000;
						Invoke((MethodInvoker)delegate
						{
							mIsCenterConfirmed[i][zn] = true;
							bt_inkpoint[i][zn].BackColor = Color.FromArgb(0, 255, 0);
						});
						if (mIsDeltaNozzle_SingleMode)
						{
							Coordinate coordinate = new Coordinate();
							coordinate.X = MainForm0.mCur[mFn].x + 1000;
							coordinate.Y = MainForm0.mCur[mFn].y + 1000;
							if (i != 3)
							{
								MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, coordinate);
							}
							continue;
						}
						int num = 2560;
						if (i != 0 || zn != 0)
						{
							num = (int)Math.Abs(USR.mDeltaNozzle_Detail[0][1].X - USR.mDeltaNozzle_Detail[0][0].X);
						}
						Coordinate coordinate2 = new Coordinate();
						coordinate2.X = MainForm0.mCur[mFn].x + num;
						coordinate2.Y = MainForm0.mCur[mFn].y;
						if (zn == HW.mZnNum[mFn] - 1)
						{
							coordinate2.X = MainForm0.mCur[mFn].x - num * (HW.mZnNum[mFn] - 1) + 1000;
							coordinate2.Y = MainForm0.mCur[mFn].y + 1000;
						}
						if (i != 3 || zn != HW.mZnNum[mFn] - 1)
						{
							MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, coordinate2);
						}
					}
					i++;
					continue;
				}
				for (int j = 0; j < HW.mZnNum[mFn]; j++)
				{
					if (!mIsDeltaNozzle_SingleMode || j == MainForm0.mZn[mFn])
					{
						long num2 = 0L;
						for (int k = 0; k < 4; k++)
						{
							num2 += USR.mDeltaNozzle_Detail[k][j].X;
						}
						USR.mDeltaNozzle[0][j].X = num2 / 4;
						long num3 = 0L;
						for (int l = 0; l < 4; l++)
						{
							num3 += USR.mDeltaNozzle_Detail[l][j].Y;
						}
						USR.mDeltaNozzle[0][j].Y = num3 / 4;
					}
				}
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Complete Point Check Done!" : "自动确认圆心完成！");
				break;
				continue;
				end_IL_039b:
				break;
			}
			Invoke((MethodInvoker)delegate
			{
				button_auto_deltaDone_Interupt.Visible = false;
				button_auto_deltaDone.Enabled = true;
				checkBox_delta_nozzle_singlemode.Enabled = true;
			});
		}

		private void __button_auto_deltaDone_Interupt_Click(object sender, EventArgs e)
		{
			MainForm0.mIsVisualRunning = false;
			button_auto_deltaDone_Interupt.Visible = false;
			button_auto_deltaDone.Enabled = true;
		}

		private void __button_nzdelta_para_check_Click(object sender, EventArgs e)
		{
			Form_NozzleDeltaPara form_NozzleDeltaPara = new Form_NozzleDeltaPara(USR);
			form_NozzleDeltaPara.ShowDialog();
		}

		private void init_base()
		{
			checkBox_SafeRunMode.Checked = USR.mIsSafeRunMode;
			checkBox_SafeRunMode.CheckedChanged += checkBox_SafeRunMode_CheckedChanged;
			if (HW.mSmtGenerationNo == 0)
			{
				panel_gen2_H.Visible = false;
				panel_saveH_shows.Visible = false;
				label12.Visible = false;
				label75.Visible = false;
				panel_vaccbreaktime.Visible = false;
				panel_saferun_limit.Visible = false;
			}
			if (USR.mBaseHeight == null)
			{
				USR.mBaseHeight = new int[8] { -6400, 6400, -6400, 6400, -6400, 6400, -6400, 6400 };
			}
			if (USR.mBaseHeightmm == null)
			{
				USR.mBaseHeightmm = new float[8];
				for (int i = 0; i < 8; i++)
				{
					USR.mBaseHeightmm[i] = MainForm0.format_H_to_Hmm(USR.mBaseHeight[i]);
				}
			}
			Panel panel = new Panel();
			panel_nozzlebasicHigh.Controls.Add(panel);
			panel.Size = new Size(506, 50);
			panel.BackColor = Color.AliceBlue;
			panel.BorderStyle = BorderStyle.FixedSingle;
			label_baseH_Zn = new Label[HW.mZnNum[MainForm0.mFn]];
			label_baseH_Zn_V = new Label[HW.mZnNum[MainForm0.mFn]];
			for (int j = 0; j < HW.mZnNum[MainForm0.mFn]; j++)
			{
				label_baseH_Zn[j] = new Label();
				label_baseH_Zn[j].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (j + 1);
				panel.Controls.Add(label_baseH_Zn[j]);
				label_baseH_Zn[j].Location = new Point(8 + 60 * j, 0);
				label_baseH_Zn[j].Size = new Size(50, 20);
				label_baseH_Zn[j].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
				label_baseH_Zn[j].Tag = j;
				label_baseH_Zn[j].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_Zn[j].MouseClick += label_Zn_Click;
				label_baseH_Zn_V[j] = new Label();
				label_baseH_Zn_V[j].Text = Math.Abs(USR.mBaseHeight[j]).ToString();
				panel.Controls.Add(label_baseH_Zn_V[j]);
				label_baseH_Zn_V[j].Location = new Point(8 + 60 * j, 25);
				label_baseH_Zn_V[j].Size = new Size(58, 20);
				label_baseH_Zn_V[j].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.75f, FontStyle.Regular);
				label_baseH_Zn_V[j].Tag = j;
				label_baseH_Zn_V[j].Anchor = AnchorStyles.None;
				label_baseH_Zn_V[j].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_Zn_V[j].DoubleClick += label_baseH_Zn_V_DoubleClick;
				label_baseH_Zn_V[j].MouseClick += label_Zn_Click;
			}
			for (int k = 0; k < HW.mZnNum[MainForm0.mFn]; k++)
			{
				PictureBox pictureBox = new PictureBox();
				pictureBox.Image = Resources.NZ0;
				panel_baseH_show.Controls.Add(pictureBox);
				pictureBox.Size = new Size(40, 80);
				pictureBox.Location = new Point(100 + pictureBox.Size.Width * k, 0);
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
				PictureBox pictureBox2 = new PictureBox();
				pictureBox2.Image = Resources.NZ1;
				panel_saveH_shows.Controls.Add(pictureBox2);
				pictureBox2.Size = new Size(40, 110);
				pictureBox2.Location = new Point(100 + pictureBox2.Size.Width * (k + 1), 0);
				pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
				if (k == 0)
				{
					PictureBox pictureBox3 = new PictureBox();
					pictureBox3.Image = Resources.NZ2;
					panel_saveH_shows.Controls.Add(pictureBox3);
					pictureBox3.Size = new Size(40, 110);
					_ = pictureBox3.Size.Width;
					pictureBox3.Location = new Point(100, 0);
					pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
					PictureBox pictureBox4 = new PictureBox();
					pictureBox4.Image = Resources.NZ2;
					panel_saveH_shows.Controls.Add(pictureBox4);
					pictureBox4.Size = new Size(40, 110);
					pictureBox4.Location = new Point(100 + pictureBox4.Size.Width * (HW.mZnNum[MainForm0.mFn] + 1), 0);
					pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
				}
			}
			if (USR.mBaseHeight_saferun == null)
			{
				int[] array = (USR.mBaseHeight_saferun = new int[8]);
			}
			Panel panel2 = new Panel();
			panel_nozzlebasicHigh_run.Controls.Add(panel2);
			panel2.Size = new Size(506, 50);
			panel2.BackColor = Color.AliceBlue;
			panel2.BorderStyle = BorderStyle.FixedSingle;
			label_baseH_saferun_Zn = new Label[HW.mZnNum[MainForm0.mFn]];
			label_baseH_saferun_Zn_V = new Label[HW.mZnNum[MainForm0.mFn]];
			for (int l = 0; l < HW.mZnNum[MainForm0.mFn]; l++)
			{
				label_baseH_saferun_Zn[l] = new Label();
				label_baseH_saferun_Zn[l].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (l + 1);
				panel2.Controls.Add(label_baseH_saferun_Zn[l]);
				label_baseH_saferun_Zn[l].Location = new Point(8 + 60 * l, 0);
				label_baseH_saferun_Zn[l].Size = new Size(50, 20);
				label_baseH_saferun_Zn[l].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
				label_baseH_saferun_Zn[l].Tag = l;
				label_baseH_saferun_Zn[l].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_saferun_Zn[l].MouseClick += label_Zn_Click;
				label_baseH_saferun_Zn_V[l] = new Label();
				label_baseH_saferun_Zn_V[l].Text = Math.Abs(USR.mBaseHeight_saferun[l]).ToString();
				panel2.Controls.Add(label_baseH_saferun_Zn_V[l]);
				label_baseH_saferun_Zn_V[l].Location = new Point(8 + 60 * l, 25);
				label_baseH_saferun_Zn_V[l].Size = new Size(58, 20);
				label_baseH_saferun_Zn_V[l].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
				label_baseH_saferun_Zn_V[l].Tag = l;
				label_baseH_saferun_Zn_V[l].Anchor = AnchorStyles.None;
				label_baseH_saferun_Zn_V[l].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_saferun_Zn_V[l].DoubleClick += label_baseH_saferun_Zn_V_DoubleClick;
				label_baseH_saferun_Zn_V[l].MouseClick += label_Zn_Click;
			}
			if (USR.mBaseHeight_saferun_limit == null)
			{
				USR.mBaseHeight_saferun_limit = new int[8] { 420, 420, 420, 420, 420, 420, 420, 420 };
			}
			Panel panel3 = new Panel();
			panel_baseH_saferun_limited.Controls.Add(panel3);
			panel3.Size = new Size(506, 50);
			panel3.BackColor = Color.AliceBlue;
			panel3.BorderStyle = BorderStyle.FixedSingle;
			label_baseH_saferun_limited_Zn = new Label[HW.mZnNum[MainForm0.mFn]];
			label_baseH_saferun_limited_Zn_V = new Label[HW.mZnNum[MainForm0.mFn]];
			for (int m = 0; m < HW.mZnNum[MainForm0.mFn]; m++)
			{
				label_baseH_saferun_limited_Zn[m] = new Label();
				label_baseH_saferun_limited_Zn[m].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (m + 1);
				panel3.Controls.Add(label_baseH_saferun_limited_Zn[m]);
				label_baseH_saferun_limited_Zn[m].Location = new Point(8 + 60 * m, 0);
				label_baseH_saferun_limited_Zn[m].Size = new Size(50, 20);
				label_baseH_saferun_limited_Zn[m].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
				label_baseH_saferun_limited_Zn[m].Tag = m;
				label_baseH_saferun_limited_Zn[m].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_saferun_limited_Zn[m].MouseClick += label_Zn_Click;
				label_baseH_saferun_limited_Zn_V[m] = new Label();
				label_baseH_saferun_limited_Zn_V[m].Text = Math.Abs(USR.mBaseHeight_saferun_limit[m]).ToString();
				panel3.Controls.Add(label_baseH_saferun_limited_Zn_V[m]);
				label_baseH_saferun_limited_Zn_V[m].Location = new Point(8 + 60 * m, 25);
				label_baseH_saferun_limited_Zn_V[m].Size = new Size(58, 20);
				label_baseH_saferun_limited_Zn_V[m].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
				label_baseH_saferun_limited_Zn_V[m].Tag = m;
				label_baseH_saferun_limited_Zn_V[m].Anchor = AnchorStyles.None;
				label_baseH_saferun_limited_Zn_V[m].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_saferun_limited_Zn_V[m].DoubleClick += label_baseH_saferun_limit_Zn_V_DoubleClick;
				label_baseH_saferun_limited_Zn_V[m].MouseClick += label_Zn_Click;
			}
			if (HW.mSmtGenerationNo == 2)
			{
				panel_vaccbreaktime.Visible = true;
			}
			else
			{
				panel_vaccbreaktime.Visible = false;
			}
			if (USR.mVaccBreakDelay == null)
			{
				USR.mVaccBreakDelay = new float[8] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f };
			}
			Panel panel4 = new Panel();
			panel_vaccbreaktime.Controls.Add(panel4);
			panel4.Location = new Point(37, 35);
			panel4.Size = new Size(506, 50);
			panel4.BackColor = Color.AliceBlue;
			panel4.BorderStyle = BorderStyle.FixedSingle;
			label_vaccdelay_Zn = new Label[HW.mZnNum[MainForm0.mFn]];
			label_vaccdelay_Zn_V = new Label[HW.mZnNum[MainForm0.mFn]];
			for (int n = 0; n < HW.mZnNum[MainForm0.mFn]; n++)
			{
				label_vaccdelay_Zn[n] = new Label();
				label_vaccdelay_Zn[n].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (n + 1);
				panel4.Controls.Add(label_vaccdelay_Zn[n]);
				label_vaccdelay_Zn[n].Location = new Point(8 + 60 * n, 0);
				label_vaccdelay_Zn[n].Size = new Size(50, 20);
				label_vaccdelay_Zn[n].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label_vaccdelay_Zn[n].Tag = n;
				label_vaccdelay_Zn[n].TextAlign = ContentAlignment.MiddleCenter;
				label_vaccdelay_Zn[n].MouseClick += label_Zn_Click;
				label_vaccdelay_Zn_V[n] = new Label();
				label_vaccdelay_Zn_V[n].Text = Math.Abs(USR.mVaccBreakDelay[n]).ToString();
				panel4.Controls.Add(label_vaccdelay_Zn_V[n]);
				label_vaccdelay_Zn_V[n].Location = new Point(8 + 60 * n, 25);
				label_vaccdelay_Zn_V[n].Size = new Size(50, 20);
				label_vaccdelay_Zn_V[n].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10.5f, FontStyle.Regular);
				label_vaccdelay_Zn_V[n].Tag = n;
				label_vaccdelay_Zn_V[n].Anchor = AnchorStyles.None;
				label_vaccdelay_Zn_V[n].TextAlign = ContentAlignment.MiddleCenter;
				label_vaccdelay_Zn_V[n].DoubleClick += label_vaccdelay_Zn_V_DoubleClick;
				label_vaccdelay_Zn_V[n].MouseClick += label_Zn_Click;
			}
		}

		private void label_vaccdelay_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mVaccBreakDelay[num], USR_INIT.mLanguage, "V_F", 0f, 1000f, "真空破坏时间（毫秒）");
			if (form_FillXY.ShowDialog() == DialogResult.OK)
			{
				USR.mVaccBreakDelay[num] = form_FillXY.Get_Fill_V_F();
				label_vaccdelay_Zn_V[num].Text = Math.Abs(USR.mVaccBreakDelay[num]).ToString();
			}
		}

		private void label_baseH_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() == DialogResult.OK && MessageBox.Show((USR_INIT.mLanguage == 2) ? "Change PCB baseH will impact all generation of place height, continue?" : "修改PCB基准高度会影响整个贴装高度的生成，是否确定修改？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mBaseHeight[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mBaseHeight[num] = Math.Abs(USR.mBaseHeight[num]);
				}
				label_baseH_Zn_V[num].Text = Math.Abs(USR.mBaseHeight[num]).ToString();
				USR.mBaseHeightmm[num] = MainForm0.format_H_to_Hmm(USR.mBaseHeight[num]);
				MainForm0.save_FixedData();
			}
		}

		private void label_baseH_saferun_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight_saferun[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() != DialogResult.OK || MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Be careful to change SAFETY RUNNING Height, please make sure NOZZLES will not hit every thing!" : "请慎重修改安全工作高度，确定吸嘴不会碰撞到XY运动有效范围的最高点(包括飞达最高点，导轨最高点等)，是否确定修改？", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			if (Math.Abs(form_FillXY.Get_FillZ()) > Math.Abs(USR.mBaseHeight_saferun_limit[MainForm0.mZn[MainForm0.mFn]]))
			{
				string[] array = new string[3] { "当前Z轴值已经超越安全高度下限，不能设置了!", "当前Z轴值已经超越安全高度下限，不能设置了!", "Current Z value is override safe run height limited value，set fail!" };
				MainForm0.CmMessageBoxTop_Ok(array[MainForm0.USR_INIT.mLanguage]);
				return;
			}
			USR.mBaseHeight_saferun[num] = form_FillXY.Get_FillZ();
			if (HW.mSmtGenerationNo == 2)
			{
				USR.mBaseHeight_saferun[num] = Math.Abs(USR.mBaseHeight_saferun[num]);
			}
			label_baseH_saferun_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_saferun[num]).ToString();
			MainForm0.save_FixedData();
		}

		private void label_baseH_saferun_limit_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight_saferun_limit[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() == DialogResult.OK && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Be careful to change SAFETY RUNNING limited Height, please make sure NOZZLES will not hit every thing!" : "请慎重修改安全工作高度极限值，确定吸嘴不会碰撞到XY运动有效范围的最高点(包括飞达最高点，导轨最高点等)，是否确定修改？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mBaseHeight_saferun_limit[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mBaseHeight_saferun_limit[num] = Math.Abs(USR.mBaseHeight_saferun_limit[num]);
				}
				label_baseH_saferun_limited_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_saferun_limit[num]).ToString();
				MainForm0.save_FixedData();
			}
		}

		private void __button_baseH_Save_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Change PCB BaseH will impact generating place height, continue?" : "修改PCB基准高度会影响整个贴装高度的生成，是否确定修改？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mBaseHeight[MainForm0.mZn[MainForm0.mFn]] = MainForm0.mCur[MainForm0.mFn].z[MainForm0.mZn[MainForm0.mFn]];
				USR.mBaseHeightmm[MainForm0.mZn[MainForm0.mFn]] = MainForm0.format_H_to_Hmm(USR.mBaseHeight[MainForm0.mZn[MainForm0.mFn]]);
				label_baseH_Zn_V[MainForm0.mZn[MainForm0.mFn]].Text = Math.Abs(USR.mBaseHeight[MainForm0.mZn[MainForm0.mFn]]).ToString();
				MainForm0.save_FixedData();
			}
		}

		private void __button_baseH_Goto_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(USR.mBaseHeight[MainForm0.mZn[MainForm0.mFn]]);
			}
		}

		private void __button_save_runsafe_h_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Be careful to change SAFETY RUNNING Height, please make sure NOZZLE will not hit anything!" : "请慎重修改安全工作高度，确定吸嘴不会碰撞到XY运动有效范围的最高点(包括飞达最高点，导轨最高点等)，是否确定修改？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (Math.Abs(MainForm0.mCur[MainForm0.mFn].z[MainForm0.mZn[MainForm0.mFn]]) > Math.Abs(USR.mBaseHeight_saferun_limit[MainForm0.mZn[MainForm0.mFn]]))
				{
					string[] array = new string[3] { "当前Z轴值已经超越安全高度下限，不能设置了!", "当前Z轴值已经超越安全高度下限，不能设置了!", "Current Z value is override safe run height limited value, set fail!" };
					MainForm0.CmMessageBoxTop_Ok(array[MainForm0.USR_INIT.mLanguage]);
				}
				else
				{
					USR.mBaseHeight_saferun[MainForm0.mZn[MainForm0.mFn]] = MainForm0.mCur[MainForm0.mFn].z[MainForm0.mZn[MainForm0.mFn]];
					label_baseH_saferun_Zn_V[MainForm0.mZn[MainForm0.mFn]].Text = Math.Abs(USR.mBaseHeight_saferun[MainForm0.mZn[MainForm0.mFn]]).ToString();
					MainForm0.save_FixedData();
				}
			}
		}

		private void __button_goto_runsafe_h_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(USR.mBaseHeight_saferun[MainForm0.mZn[MainForm0.mFn]]);
			}
		}

		private void __button_vacuum_sync_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				if (i != MainForm0.mZn[MainForm0.mFn])
				{
					USR.mVaccBreakDelay[i] = USR.mVaccBreakDelay[MainForm0.mZn[MainForm0.mFn]];
					label_vaccdelay_Zn_V[i].Text = USR.mVaccBreakDelay[i].ToString("F2");
				}
			}
		}

		private void __checkBox_SafeRunMode_CheckedChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Safe Run Mode setting should be carefully, continue?" : "安全模式设置需慎重，是否继续？", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					USR.mIsSafeRunMode = checkBox_SafeRunMode.Checked;
					return;
				}
				checkBox_SafeRunMode.CheckedChanged -= checkBox_SafeRunMode_CheckedChanged;
				checkBox_SafeRunMode.Checked = USR.mIsSafeRunMode;
				checkBox_SafeRunMode.CheckedChanged += checkBox_SafeRunMode_CheckedChanged;
			}
		}

		private void init_camera()
		{
			if (HW.mSmtGenerationNo == 0)
			{
				panel_hcam_h.Visible = false;
				panel_fcam_h.Visible = false;
				panel_fcam_calib.Location = panel_fcam_h.Location;
				panel_hcam_calib.Location = panel_hcam_h.Location;
			}
			nud_MarkRatio.Value = (decimal)USR.mMarkCamRatio[0];
			numericUpDown_previewoffset_x.Value = USR.mPreviewOffset_X;
			numericUpDown_previewoffset_y.Value = USR.mPreviewOffset_Y;
			int num = 0;
			int num2 = 0;
			this.panel2.Visible = HW.mHCamEn[mFn];
			if (USR.mBaseHeight_camera == null)
			{
				int[] array = (USR.mBaseHeight_camera = new int[8]);
			}
			Panel panel = new Panel();
			panel_nozzlebasicHigh_visual.Controls.Add(panel);
			panel.Size = new Size(501, 50);
			panel.BackColor = Color.AliceBlue;
			panel.BorderStyle = BorderStyle.FixedSingle;
			label_baseH_camera_Zn = new Label[HW.mZnNum[mFn]];
			label_baseH_camera_Zn_V = new Label[HW.mZnNum[mFn]];
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				label_baseH_camera_Zn[i] = new Label();
				label_baseH_camera_Zn[i].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (i + 1);
				panel.Controls.Add(label_baseH_camera_Zn[i]);
				label_baseH_camera_Zn[i].Location = new Point(8 + 60 * i, 0);
				label_baseH_camera_Zn[i].Size = new Size(50 + num, 20 + num2);
				label_baseH_camera_Zn[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
				label_baseH_camera_Zn[i].Tag = i;
				label_baseH_camera_Zn[i].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_camera_Zn[i].MouseClick += label_Zn_Click;
				label_baseH_camera_Zn_V[i] = new Label();
				label_baseH_camera_Zn_V[i].Text = Math.Abs(USR.mBaseHeight_camera[i]).ToString();
				panel.Controls.Add(label_baseH_camera_Zn_V[i]);
				label_baseH_camera_Zn_V[i].Location = new Point(8 + 60 * i, 25);
				label_baseH_camera_Zn_V[i].Size = new Size(53 + num, 20 + num2);
				label_baseH_camera_Zn_V[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
				label_baseH_camera_Zn_V[i].Tag = i;
				label_baseH_camera_Zn_V[i].Anchor = AnchorStyles.None;
				label_baseH_camera_Zn_V[i].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_camera_Zn_V[i].DoubleClick += label_baseH_camera_Zn_V_DoubleClick;
				label_baseH_camera_Zn_V[i].MouseClick += label_Zn_Click;
			}
			label_FastRecognizeCoord.Text = MainForm0.format_XY_label_string(USR.mFastCamRecognizeCoord[0]);
			checkBox_fastcam_oppovisual.Checked = USR.mIsFastCamOppositeVisual;
			checkBox_FCameraCalibrator.Checked = USR.mCameraCalibrator;
			numericUpDown_fcam__recsize.Value = USR.mfcam_rec_size;
			numericUpDown_fcam_scanr.Value = USR.mfcam_scanr;
			numericUpDown_fcam_threshold.Value = USR.mfcam_threshold;
			if (USR.mFastCamLiebians == null)
			{
				USR.mFastCamLiebians = new int[8] { 400, 400, 400, 400, 400, 400, 400, 400 };
			}
			for (int j = 0; j < 8; j++)
			{
				if (USR.mFastCamLiebians[j] < 100 || USR.mFastCamLiebians[j] > 1000)
				{
					USR.mFastCamLiebians[j] = 400;
				}
				NumericUpDown numericUpDown = new NumericUpDown();
				panel_liebian.Controls.Add(numericUpDown);
				numericUpDown.Location = new Point(2 + 46 * j, 0);
				numericUpDown.Size = new Size(42, 28);
				numericUpDown.Font = new Font("黑体", 10f, FontStyle.Regular);
				numericUpDown.Minimum = 100m;
				numericUpDown.Maximum = 1000m;
				numericUpDown.Value = USR.mFastCamLiebians[j];
				numericUpDown.Tag = j;
				numericUpDown.ValueChanged += numericUpDown_fcam_liebian_ValueChanged;
				if (j < HW.mZnNum[mFn])
				{
					numericUpDown.Enabled = true;
				}
				else
				{
					numericUpDown.Enabled = false;
				}
			}
			if (USR.mBaseHeight_Hcam == null)
			{
				int[] array2 = (USR.mBaseHeight_Hcam = new int[8]);
			}
			Panel panel2 = new Panel();
			panel_Hcam_baseH.Controls.Add(panel2);
			panel2.Size = new Size(501, 50);
			panel2.BackColor = Color.AliceBlue;
			panel2.BorderStyle = BorderStyle.FixedSingle;
			label_baseH_Hcam_Zn = new Label[HW.mZnNum[mFn]];
			label_baseH_Hcam_Zn_V = new Label[HW.mZnNum[mFn]];
			for (int k = 0; k < HW.mZnNum[mFn]; k++)
			{
				label_baseH_Hcam_Zn[k] = new Label();
				label_baseH_Hcam_Zn[k].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (k + 1);
				panel2.Controls.Add(label_baseH_Hcam_Zn[k]);
				label_baseH_Hcam_Zn[k].Location = new Point(8 + 60 * k, 0);
				label_baseH_Hcam_Zn[k].Size = new Size(50, 20);
				label_baseH_Hcam_Zn[k].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
				label_baseH_Hcam_Zn[k].Tag = k;
				label_baseH_Hcam_Zn[k].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_Hcam_Zn[k].MouseClick += label_Zn_Click;
				label_baseH_Hcam_Zn_V[k] = new Label();
				label_baseH_Hcam_Zn_V[k].Text = Math.Abs(USR.mBaseHeight_Hcam[k]).ToString();
				panel2.Controls.Add(label_baseH_Hcam_Zn_V[k]);
				label_baseH_Hcam_Zn_V[k].Location = new Point(8 + 60 * k, 25);
				label_baseH_Hcam_Zn_V[k].Size = new Size(53, 20);
				label_baseH_Hcam_Zn_V[k].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 9.5f, FontStyle.Regular);
				label_baseH_Hcam_Zn_V[k].Tag = k;
				label_baseH_Hcam_Zn_V[k].Anchor = AnchorStyles.None;
				label_baseH_Hcam_Zn_V[k].TextAlign = ContentAlignment.MiddleCenter;
				label_baseH_Hcam_Zn_V[k].DoubleClick += label_baseH_Hcam_Zn_V_DoubleClick;
				label_baseH_Hcam_Zn_V[k].MouseClick += label_Zn_Click;
			}
			label_HighRecognizeCoord.Text = MainForm0.format_XY_label_string(USR.mHighCamRecognizeCoord[0][MainForm0.mZn[mFn]]);
			checkBox_highcam_oppovisual.Checked = USR.mIsHighCamOppositeVisual;
			numericUpDown_hcam_liebian.Value = USR.mHighCamLiebian;
			numericUpDown_hcam_rec_size.Value = USR.mhcam_rec_size;
			numericUpDown_hcam_scanr.Value = USR.mhcam_scanr;
			numericUpDown_hcam_threshold.Value = USR.mhcam_threshold;
		}

		private void label_baseH_camera_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight_camera[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() == DialogResult.OK && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Change camera baseH will impact visual result, contine?" : "修改相机基准高度会影响视觉结果，是否确定修改？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mBaseHeight_camera[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mBaseHeight_camera[num] = Math.Abs(USR.mBaseHeight_camera[num]);
				}
				label_baseH_camera_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_camera[num]).ToString();
				MainForm0.save_FixedData();
			}
		}

		private void label_baseH_Hcam_Zn_V_DoubleClick(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			Form_FillXY form_FillXY = new Form_FillXY(USR.mBaseHeight_Hcam[num], USR_INIT.mLanguage, "Z");
			if (form_FillXY.ShowDialog() == DialogResult.OK && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Change camera baseH will impact visual result, continue?" : "修改相机基准高度会影响视觉结果，是否确定修改？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mBaseHeight_Hcam[num] = form_FillXY.Get_FillZ();
				if (HW.mSmtGenerationNo == 2)
				{
					USR.mBaseHeight_Hcam[num] = Math.Abs(USR.mBaseHeight_Hcam[num]);
				}
				label_baseH_Hcam_Zn_V[num].Text = Math.Abs(USR.mBaseHeight_Hcam[num]).ToString();
				MainForm0.save_FixedData();
			}
		}

		private void __numericUpDown_fcam_scanr_ValueChanged(object sender, EventArgs e)
		{
			USR.mfcam_scanr = (int)numericUpDown_fcam_scanr.Value;
			MainForm0.save_FixedData();
		}

		private void __numericUpDown_fcam_threshold_ValueChanged(object sender, EventArgs e)
		{
			USR.mfcam_threshold = (int)numericUpDown_fcam_threshold.Value;
			MainForm0.save_FixedData();
		}

		private void __numericUpDown_hcam_scanr_ValueChanged(object sender, EventArgs e)
		{
			USR.mhcam_scanr = (int)numericUpDown_hcam_scanr.Value;
			MainForm0.save_FixedData();
		}

		private void __numericUpDown_hcam_threshold_ValueChanged(object sender, EventArgs e)
		{
			USR.mhcam_threshold = (int)numericUpDown_hcam_threshold.Value;
			MainForm0.save_FixedData();
		}

		private void numericUpDown_fcam_liebian_ValueChanged(object sender, EventArgs e)
		{
			int num = (int)((NumericUpDown)sender).Tag;
			USR.mFastCamLiebians[num] = (int)((NumericUpDown)sender).Value;
		}

		private void __button_save_basecamera_h_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Change camera baseH will impact visual result, continue?" : "修改相机基准高度会影响视觉结果，是否确定修改？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mBaseHeight_camera[MainForm0.mZn[mFn]] = MainForm0.mCur[mFn].z[MainForm0.mZn[mFn]];
				label_baseH_camera_Zn_V[MainForm0.mZn[mFn]].Text = Math.Abs(USR.mBaseHeight_camera[MainForm0.mZn[mFn]]).ToString();
				MainForm0.save_FixedData();
			}
		}

		private void __button_goto_basecamera_h_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(USR.mBaseHeight_camera[MainForm0.mZn[mFn]]);
			}
		}

		private void __button_goto_basecamera_h_allzn_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "All nozzles goto fast camera baseH ?" : "确定所有吸嘴同时定位到快速相机高度？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Thread thread = new Thread(thd_moveTo_AllZn);
				thread.IsBackground = false;
				thread.Start(USR.mBaseHeight_camera);
			}
		}

		private void thd_moveTo_AllZn(object o)
		{
			int[] array = (int[])o;
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				MainForm0.moveToZ_noWait(mFn, i, USR.mZSpeed, array[i]);
			}
			for (int j = 0; j < HW.mZnNum[mFn]; j++)
			{
				MainForm0.WaitComplete_Z(mFn, j);
			}
			MainForm0.mMutexMoveXYZA = false;
		}

		private void __button_FastCamMoveToCoord_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR.mFastCamRecognizeCoord[0]);
				if (MainForm0.mCurCam[mFn] != CameraType.Fast)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
				}
				MainForm0.mark_light_on_ext(mFn, flag: false);
				MainForm0.mark_led_on_ext(mFn, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: true);
			}
		}

		private void __button_fcam_distortion_para_Click(object sender, EventArgs e)
		{
			Form_CamDistortionPara form_CamDistortionPara = new Form_CamDistortionPara(USR, CameraType.Fast);
			form_CamDistortionPara.ShowDialog();
		}

		private void __checkBox_fastcam_oppovisual_CheckedChanged(object sender, EventArgs e)
		{
			if (USR != null && checkBox_fastcam_oppovisual.Checked != USR.mIsFastCamOppositeVisual)
			{
				if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Change to opposite visual mode?" : "确定要修改视觉反色模式吗？", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					USR.mIsFastCamOppositeVisual = checkBox_fastcam_oppovisual.Checked;
				}
				else
				{
					checkBox_fastcam_oppovisual.Checked = USR.mIsFastCamOppositeVisual;
				}
			}
		}

		private void __checkBox_FCameraCalibrator_CheckedChanged(object sender, EventArgs e)
		{
			USR.mCameraCalibrator = checkBox_FCameraCalibrator.Checked;
		}

		private void __numericUpDown_fcam__recsize_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mfcam_rec_size = (int)numericUpDown_fcam__recsize.Value;
			}
		}

		private void __button_save_Hcam_baseH_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Change camera base H will impact all visual result, contine?" : "修改相机基准高度会影响视觉结果，是否确定修改？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				USR.mBaseHeight_Hcam[MainForm0.mZn[mFn]] = MainForm0.mCur[mFn].z[MainForm0.mZn[mFn]];
				label_baseH_Hcam_Zn_V[MainForm0.mZn[mFn]].Text = Math.Abs(USR.mBaseHeight_Hcam[MainForm0.mZn[mFn]]).ToString();
				MainForm0.save_FixedData();
			}
		}

		private void __button_goto_Hcam_baseH_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteZOperate);
				thread.IsBackground = true;
				thread.Start(USR.mBaseHeight_Hcam[MainForm0.mZn[mFn]]);
			}
		}

		private void __button_goto_baseHcam_h_allzn_Click(object sender, EventArgs e)
		{
			if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "All nozzles goto high camera baseH ?" : "确定所有吸嘴同时定位到高清相机高度？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Thread thread = new Thread(thd_moveTo_AllZn);
				thread.IsBackground = false;
				thread.Start(USR.mBaseHeight_Hcam);
			}
		}

		private void __button_HighCamMoveToCoord_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(USR.mHighCamRecognizeCoord[0][MainForm0.mZn[mFn]]);
				if (MainForm0.mCurCam[mFn] != CameraType.High)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.High);
				}
				MainForm0.mark_light_on_ext(mFn, flag: false);
				MainForm0.mark_led_on_ext(mFn, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: true);
			}
		}

		private void __checkBox_highcam_oppovisual_CheckedChanged(object sender, EventArgs e)
		{
			if (USR != null && USR.mIsHighCamOppositeVisual != checkBox_highcam_oppovisual.Checked)
			{
				if (MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Change to opposite visual mode?" : "确定要修改视觉反色模式吗？", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					USR.mIsHighCamOppositeVisual = checkBox_highcam_oppovisual.Checked;
				}
				else
				{
					checkBox_highcam_oppovisual.Checked = USR.mIsHighCamOppositeVisual;
				}
			}
		}

		private void __button_hcam_distortion_para_Click(object sender, EventArgs e)
		{
			Form_CamDistortionPara form_CamDistortionPara = new Form_CamDistortionPara(USR, CameraType.High);
			form_CamDistortionPara.ShowDialog();
		}

		private void __numericUpDown_hcam_liebian_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mHighCamLiebian = (int)numericUpDown_hcam_liebian.Value;
			}
		}

		private void __numericUpDown_hcam_rec_size_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mhcam_rec_size = (int)numericUpDown_hcam_rec_size.Value;
			}
		}

		private void __nud_MarkRatio_ValueChanged(object sender, EventArgs e)
		{
			USR.mMarkCamRatio[0] = (float)nud_MarkRatio.Value;
			MainForm0.save_FixedData();
		}

		private void __numericUpDown_previewoffset_x_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			string text = (string)numericUpDown.Tag;
			if (USR == null)
			{
				return;
			}
			if (text == "x" && (int)numericUpDown.Value != USR.mPreviewOffset_X)
			{
				USR.mPreviewOffset_X = (int)numericUpDown.Value;
				if (this.vsplus_restart_camerapreview != null)
				{
					this.vsplus_restart_camerapreview(mFn);
				}
				MainForm0.save_FixedData();
			}
			else if (text == "y" && (int)numericUpDown.Value != USR.mPreviewOffset_Y)
			{
				USR.mPreviewOffset_Y = (int)numericUpDown.Value;
				if (this.vsplus_restart_camerapreview != null)
				{
					this.vsplus_restart_camerapreview(mFn);
				}
				MainForm0.save_FixedData();
			}
		}

		private void __button_previewoffset_reset_Click(object sender, EventArgs e)
		{
			if (USR != null && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Will Restart Software, Continue?" : "修改预览偏量需要重新扎点，是否继续？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (MainForm0.mJvsDriver == JvsDriver.MV360)
				{
					numericUpDown_previewoffset_x.Value = (USR.mPreviewOffset_X = 1);
					numericUpDown_previewoffset_y.Value = (USR.mPreviewOffset_Y = 1);
				}
				else
				{
					numericUpDown_previewoffset_x.Value = (USR.mPreviewOffset_X = 0);
					numericUpDown_previewoffset_y.Value = (USR.mPreviewOffset_Y = -1);
				}
				if (this.vsplus_restart_camerapreview != null)
				{
					this.vsplus_restart_camerapreview(mFn);
				}
				MainForm0.save_FixedData();
			}
		}

		private void __button_test_previewoffset_Click(object sender, EventArgs e)
		{
			if (this.vsplus_test_previewoffset != null)
			{
				this.vsplus_test_previewoffset(mFn);
			}
		}

		private void __button_fcam_visualtest_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexBt)
			{
				MainForm0.mMutexBt = true;
				VisualPara s = new VisualPara(VisualType.Circle, USR.mfcam_scanr, USR.mfcam_threshold, "", USR.mTest_Lmm, USR.mTest_Wmm);
				if (this.vsplus_visual_test != null)
				{
					this.vsplus_visual_test(s);
				}
			}
		}

		private void __button_hcam_visualtest_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexBt)
			{
				MainForm0.mMutexBt = true;
				VisualPara s = new VisualPara(VisualType.Circle, USR.mhcam_scanr, USR.mhcam_threshold, "", USR.mTest_Lmm, USR.mTest_Wmm);
				if (this.vsplus_visual_test != null)
				{
					this.vsplus_visual_test(s);
				}
			}
		}

		private void init_misc()
		{
			if (USR.mColor == null)
			{
				USR.mColor = new int[3] { 100, 157, 180 };
			}
			if ((USR.mColor[0] < 10 && USR.mColor[1] < 10 && USR.mColor[2] < 10) || USR.mColor[0] + USR.mColor[1] + USR.mColor[2] < 30)
			{
				USR.mColor[0] = 100;
				USR.mColor[1] = 157;
				USR.mColor[2] = 180;
			}
			trackBar_color = new TrackBar[3] { trackBar_color_r, trackBar_color_g, trackBar_color_b };
			for (int i = 0; i < 3; i++)
			{
				trackBar_color[i].Value = USR.mColor[i];
				trackBar_color[i].Tag = i;
				trackBar_color[i].ValueChanged += trackBar_color_valueChanged;
			}
			UserControl_UsrOperation obj = MainForm0.uc_usroperarion[MainForm0.mFn];
			Color color2 = (panel_color.BackColor = system_color(USR.mColor));
			obj.set_color(color2);
		}

		public Color system_color(int[] color)
		{
			int[] array = new int[3];
			int[] array2 = array;
			return Color.FromArgb((color[0] + array2[0]) % 256, (color[1] + array2[1]) % 256, (color[2] + array2[2]) % 256);
		}

		private void trackBar_color_valueChanged(object sender, EventArgs e)
		{
			if (USR != null && USR.mColor != null)
			{
				TrackBar trackBar = (TrackBar)sender;
				int num = (int)trackBar.Tag;
				USR.mColor[num] = trackBar.Value;
				Color color = system_color(USR.mColor);
				panel_color.BackColor = color;
				MainForm0.uc_usroperarion[MainForm0.mFn].set_color(color);
			}
		}

		private void __button_AutoSetFastCamCoord_Click(object sender, EventArgs e)
		{
			int num = 0;
			string text = "";
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				if (USR.misfcam_disable[i])
				{
					text += i + 1;
					num++;
				}
			}
			if (num > 0 && num < HW.mZnNum[mFn])
			{
				string[] array = new string[3]
				{
					text + "号快速相机已被禁用，该号相机的参数将不被更新，是否继续？",
					text + "号快速相機已被禁用，該號相機的參數將不被更新，是否繼續？",
					"Fast Cam" + text + " is disabled, so parameter of this camera will not be updated, continue?"
				};
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
			}
			else if (num >= HW.mZnNum[mFn])
			{
				string[] array2 = new string[3] { "所有快速相机均已被禁用，无法进行快速相机校准!", "所有快速相機均已被禁用，無法進行快速相機校準!", "All fast cameras are disabled, calibration can not run!" };
				MainForm0.CmMessageBox(array2[USR_INIT.mLanguage], MessageBoxButtons.OK);
				return;
			}
			string[] array3 = new string[3] { "自动定位应将视觉范围设置合适(建议200-250),相应的吸嘴移动到灯源十字中心位置", "自動定位應將視覺範圍設置合適(建議200-250),相應的吸嘴移動到燈源十字中心位置", "Please move nozzle to view center!" };
			if (MainForm0.CmMessageBox(array3[USR_INIT.mLanguage], MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				if (MainForm0.mCurCam[mFn] != CameraType.Fast && MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
				}
				MainForm0.mark_led_on_ext(mFn, flag: false);
				MainForm0.mark_light_on_ext(mFn, flag: false);
				if (this.vsplus_start_fcam_auto_calibration != null)
				{
					this.vsplus_start_fcam_auto_calibration(mFn);
				}
				label_FastRecognizeCoord.Text = MainForm0.format_XY_label_string(USR.mFastCamRecognizeCoord[0]);
			}
		}

		private void __button_AutoSetHighCamCoord_Click(object sender, EventArgs e)
		{
			string[] array = new string[3] { "全部定位定位匹配，请将1号吸嘴移动到精密相机视野中心附近!", "全部定位定位匹配，請將1號吸嘴移動到精密相機視野中心附近!", "Please move nozzle 1 to view center!" };
			if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				if (MainForm0.mCurCam[mFn] != CameraType.High && MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.High);
				}
				MainForm0.mark_light_on_ext(mFn, flag: false);
				MainForm0.mark_led_on_ext(mFn, flag: false);
				if (this.vsplus_start_hcam_auto_calibration != null)
				{
					this.vsplus_start_hcam_auto_calibration(mFn);
				}
			}
		}

		private void __button_SingleSetHighCamCoord_Click(object sender, EventArgs e)
		{
			string[] array = new string[3] { "单独定位自动匹配,相应的吸嘴移动到精密相机视野十字中心位置!", "單獨定位自動匹配,相應的吸嘴移動到精密相機視野十字中心位置!", "Please move selected nozzle to view center!" };
			if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				if (MainForm0.mCurCam[mFn] != CameraType.High && MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.High);
				}
				MainForm0.mark_led_on_ext(mFn, flag: false);
				MainForm0.mark_light_on_ext(mFn, flag: false);
				if (this.vsplus_start_hcam_singel_calibration != null)
				{
					this.vsplus_start_hcam_singel_calibration(mFn);
				}
			}
		}

		private void init_visualdebug()
		{
			textBox_testfolder.Text = USR.mDebug_PicFolder;
			numericUpDown_pic_idx.Value = USR.mDebug_PicIndex;
			checkBox_factoryDebug.Checked = MainForm0.mDebug_Factory;
		}

		private void __button_algorithm_debug_running_Click(object sender, EventArgs e)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(USR.mDebug_PicFolder);
			if (!Directory.Exists(USR.mDebug_PicFolder))
			{
				return;
			}
			FileInfo[] files = directoryInfo.GetFiles();
			if (files.Count() != 0)
			{
				test_pic_num = files.Count();
				if (USR.mDebug_PicIndex >= test_pic_num)
				{
					USR.mDebug_PicIndex = test_pic_num - 1;
				}
				else if (USR.mDebug_PicIndex < 0)
				{
					USR.mDebug_PicIndex = 0;
				}
				Invoke((MethodInvoker)delegate
				{
					numericUpDown_pic_idx.Value = USR.mDebug_PicIndex;
				});
				string text = USR.mDebug_PicFolder.Substring(USR.mDebug_PicFolder.Length - 1);
				if (text != "\\")
				{
					USR.mDebug_PicFolder += "\\";
				}
				string s = USR.mDebug_PicFolder + files[USR.mDebug_PicIndex];
				if (this.vsplus_visual_algorithms_running_debug != null)
				{
					this.vsplus_visual_algorithms_running_debug(s);
				}
			}
		}

		private void __button_algorithm_debug_Click(object sender, EventArgs e)
		{
			string text = ((Button)sender).Tag.ToString();
			DirectoryInfo directoryInfo = new DirectoryInfo(USR.mDebug_PicFolder);
			if (!Directory.Exists(USR.mDebug_PicFolder))
			{
				return;
			}
			FileInfo[] files = directoryInfo.GetFiles();
			if (files.Count() == 0)
			{
				return;
			}
			BindingList<string> bindingList = new BindingList<string>();
			for (int i = 0; i < files.Count(); i++)
			{
				if (files[i].ToString().Contains(".jpg") || files[i].ToString().Contains(".JPG") || files[i].ToString().Contains(".bmp") || files[i].ToString().Contains(".BMP"))
				{
					bindingList.Add(files[i].ToString());
				}
			}
			if (bindingList.Count != 0)
			{
				if (text == "next")
				{
					USR.mDebug_PicIndex++;
				}
				else if (text == "prev")
				{
					USR.mDebug_PicIndex--;
				}
				if (USR.mDebug_PicIndex >= bindingList.Count)
				{
					USR.mDebug_PicIndex = bindingList.Count - 1;
				}
				else if (USR.mDebug_PicIndex < 0)
				{
					USR.mDebug_PicIndex = 0;
				}
				Invoke((MethodInvoker)delegate
				{
					numericUpDown_pic_idx.Value = USR.mDebug_PicIndex;
				});
				string text2 = USR.mDebug_PicFolder.Substring(USR.mDebug_PicFolder.Length - 1);
				if (text2 != "\\")
				{
					USR.mDebug_PicFolder += "\\";
				}
				string s = USR.mDebug_PicFolder + bindingList[USR.mDebug_PicIndex];
				if (this.vsplus_visual_algorithms_debug != null)
				{
					this.vsplus_visual_algorithms_debug(s);
				}
			}
		}

		private void __button_algorithm_debugauto_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutex_PushButton)
			{
				MainForm0.mMutex_PushButton = true;
				Thread thread = new Thread(thd_algorithms_debugauto);
				thread.IsBackground = false;
				thread.Start(USR.mTest_VisualType);
			}
		}

		private void thd_algorithms_debugauto(object o)
		{
			try
			{
				if (MainForm0.mCurCam[mFn] == CameraType.Fast || MainForm0.mCurCam[mFn] == CameraType.Mark)
				{
					MainForm0.mIsDebug_Visual = true;
					_ = (VisualType)o;
					string text = USR.mDebug_PicFolder.Substring(USR.mDebug_PicFolder.Length - 1);
					if (text != "\\")
					{
						USR.mDebug_PicFolder += "\\";
					}
					DirectoryInfo directoryInfo = new DirectoryInfo(USR.mDebug_PicFolder);
					FileInfo[] files = directoryInfo.GetFiles();
					if (files.Count() == 0)
					{
						return;
					}
					test_pic_num = files.Count();
					int num = 0;
					for (int i = 0; i < test_pic_num; i++)
					{
						string s = USR.mDebug_PicFolder + files[i];
						if (this.vsplus_visual_algorithms != null && !this.vsplus_visual_algorithms(s))
						{
							num++;
						}
						Thread.Sleep(200);
					}
					string msg = "测试样本数量=" + test_pic_num + Environment.NewLine + "   识别成功数量=" + (test_pic_num - num);
					MainForm0.CmMessageBoxTop_Ok(msg);
				}
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile_EXCEPTION(" thd_algorithms_debugauto");
			}
			MainForm0.mMutex_PushButton = false;
			MainForm0.mIsDebug_Visual = false;
		}

		private void __button_testfolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = ((USR_INIT.mLanguage == 2) ? "Please select folder" : "请选择测试图片所在文件夹");
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				if (string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Folder path cannot be empty" : "文件夹路径不能为空");
				}
				else
				{
					textBox_testfolder.Text = (USR.mDebug_PicFolder = folderBrowserDialog.SelectedPath + "\\");
				}
			}
		}

		private void __checkBox_factoryDebug_CheckedChanged(object sender, EventArgs e)
		{
			MainForm0.mDebug_Factory = checkBox_factoryDebug.Checked;
		}

		private void __numericUpDown_factoryvisualtest_angle_ValueChanged(object sender, EventArgs e)
		{
		}

		private void __numericUpDown_pic_idx_ValueChanged(object sender, EventArgs e)
		{
			USR.mDebug_PicIndex = (int)numericUpDown_pic_idx.Value;
		}

		private void __textBox_testfolder_TextChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mDebug_PicFolder = textBox_testfolder.Text;
			}
			if (USR.mDebug_PicFolder.Length > 0)
			{
				string text = USR.mDebug_PicFolder.Substring(USR.mDebug_PicFolder.Length - 1);
				if (text != "\\")
				{
					USR.mDebug_PicFolder += "\\";
				}
			}
		}

		private void init_factory()
		{
			numericUpDown_FactoryTest_feederNum.Minimum = 1m;
			numericUpDown_FactoryTest_feederNum.Maximum = HW.mStackNum[mFn][0];
		}

		private void __btn_HideSetting_Click(object sender, EventArgs e)
		{
			panel_fix_factory.Visible = false;
		}

		private void __button_FactoryTestAll_Start_Click(object sender, EventArgs e)
		{
			USR.mDeltaAlfa = 999.999f;
			if (MainForm0.CmMessageBox("请拆下所有的吸嘴再做老化试验！！！", MessageBoxButtons.YesNo) != DialogResult.No && MainForm0.CmMessageBox("您已经取下所有的吸嘴了吗？？？", MessageBoxButtons.YesNo) != DialogResult.No && MainForm0.CmMessageBox("您真的已经取下所有的吸嘴了吗？？？", MessageBoxButtons.YesNo) != DialogResult.No && !mIsFactoryTest)
			{
				mIsFactoryTest = true;
				UI_ControlEnable_FactoryTest(flag: false);
				progressBar_FactoryTestAll.Minimum = 0;
				progressBar_FactoryTestAll.Maximum = (int)(numericUpDown_factorytestall_hour.Value * 3600m);
				progressBar_FactoryTestAll.Value = 0;
				Thread thread = new Thread(thd_factoryTestAll);
				thread.IsBackground = true;
				thread.Start((int)(numericUpDown_factorytestall_hour.Value * 3600m));
			}
		}

		private void UI_ControlEnable_FactoryTest(bool flag)
		{
		}

		private void thd_factoryTestAll(object o)
		{
			DateTime now = DateTime.Now;
			int num = (int)o;
			MainForm0.moveToZero_ZA_andWait(mFn);
			Random random = new Random();
			int num2 = 0;
			int num3 = 0;
			while (mIsFactoryTest)
			{
				num3++;
				for (int i = 0; i < HW.mZnNum[mFn]; i++)
				{
					MainForm0.moveToA_noWait(mFn, i, USR.mASpeed, random.Next() % 12800);
					Coordinate point = new Coordinate(random.Next() % HW.mMaxX[0], random.Next() % HW.mMaxY[0]);
					MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, point);
					MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2, flag: true);
					MainForm0.misc_vacc_onoff(mFn, i, 1);
					MainForm0.moveToZ_andWait(mFn, i, USR.mZSpeed, random.Next() % HW.mMaxZ[0] * ((i % 2 != 0) ? 1 : (-1)));
					MainForm0.moveToZ_andWait(mFn, i, USR.mZSpeed, 0);
					MainForm0.misc_vacc_onoff(mFn, i, 0);
					MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2, flag: false);
					num2 = ((num2 != HW.mStackNum[mFn][0] - 1) ? (num2 + 1) : 0);
				}
				if (num3 % 2 == 1)
				{
					MainForm0.fhcam_led_on(mFn, CameraType.Fast, flag: true);
				}
				else
				{
					MainForm0.fhcam_led_on(mFn, CameraType.Fast, flag: false);
				}
				for (int j = 0; j < 2; j++)
				{
					Coordinate point2 = new Coordinate(random.Next() % HW.mMaxX[0], random.Next() % HW.mMaxY[0]);
					MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, point2);
					for (int k = 0; k < HW.mZnNum[mFn]; k++)
					{
						if (k % 2 == j)
						{
							MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2 + k / 2, flag: true);
							MainForm0.misc_vacc_onoff(mFn, k, 1);
							MainForm0.moveToZ_noWait(mFn, k, USR.mZSpeed, random.Next() % HW.mMaxZ[0] * ((k % 2 != 0) ? 1 : (-1)));
						}
					}
					for (int l = 0; l < HW.mZnNum[mFn]; l++)
					{
						if (l % 2 == j)
						{
							MainForm0.WaitComplete_Z(mFn, l);
						}
					}
					MainForm0.moveToZero_Z_andWait(mFn);
					for (int m = 0; m < HW.mZnNum[mFn]; m++)
					{
						if (m % 2 == j)
						{
							MainForm0.misc_vacc_onoff(mFn, m, 0);
							MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num2 + m / 2, flag: false);
						}
					}
					num2 += 4;
					if (num2 > HW.mStackNum[mFn][0] - 1)
					{
						num2 -= HW.mStackNum[mFn][0];
					}
					if (j == 0)
					{
						if (num3 % 2 == 1)
						{
							MainForm0.mark_led_on(mFn, flag: true);
						}
						else
						{
							MainForm0.mark_led_on(mFn, flag: false);
						}
					}
					else if (num3 % 2 == 1)
					{
						MainForm0.fhcam_led_on(mFn, CameraType.High, flag: true);
					}
					else
					{
						MainForm0.fhcam_led_on(mFn, CameraType.High, flag: false);
					}
				}
				for (int n = 0; n < HW.mZnNum[mFn]; n++)
				{
					MainForm0.WaitComplete_A(mFn, n);
				}
				DateTime now2 = DateTime.Now;
				int tts = (int)(now2 - now).TotalSeconds;
				if (tts >= num)
				{
					Invoke((MethodInvoker)delegate
					{
						progressBar_FactoryTestAll.Value = progressBar_FactoryTestAll.Maximum;
					});
					mIsFactoryTest = false;
					break;
				}
				Invoke((MethodInvoker)delegate
				{
					progressBar_FactoryTestAll.Value = tts;
				});
				Thread.Sleep(0);
			}
			MainForm0.moveToZero_ZA_andWait(mFn);
			MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(0L, 0L));
			for (int num4 = 0; num4 < HW.mZnNum[mFn]; num4++)
			{
				MainForm0.misc_vacc_onoff(mFn, num4, 0);
			}
			for (int num5 = 0; num5 < HW.mStackNum[mFn][0]; num5++)
			{
				MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, num5, flag: false);
			}
			MainForm0.mark_led_on(mFn, flag: false);
			MainForm0.fhcam_led_on(mFn, CameraType.Fast, flag: false);
			MainForm0.fhcam_led_on(mFn, CameraType.High, flag: false);
			Invoke((MethodInvoker)delegate
			{
				UI_ControlEnable_FactoryTest(flag: true);
				mIsFactoryTest = false;
			});
		}

		private void __button_FactoryTestAll_Stop_Click(object sender, EventArgs e)
		{
			mIsFactoryTest = false;
		}

		private void __numericUpDown_factorytestall_hour_ValueChanged(object sender, EventArgs e)
		{
		}

		private void __button_FactoryTest_Start_Click(object sender, EventArgs e)
		{
			if (!mIsFactoryTest)
			{
				mIsFactoryTest = true;
				UI_ControlEnable_FactoryTest(flag: false);
				progressBar_FactoryTest.Minimum = 0;
				progressBar_FactoryTest.Maximum = (int)numericUpDown_factorytest_count.Value - 1;
				progressBar_FactoryTest.Value = 0;
				Thread thread = new Thread(thd_factoryTest);
				thread.IsBackground = true;
				thread.Start((int)numericUpDown_factorytest_count.Value);
			}
		}

		private void __button_FactoryTest_Stop_Click(object sender, EventArgs e)
		{
			mIsFactoryTest = false;
		}

		private void thd_factoryTest(object o)
		{
			int num = (int)o;
			MainForm0.moveToZero_ZA_andWait(mFn);
			Random random = new Random();
			int i;
			for (i = 0; i < num; i++)
			{
				if (i == num - 1)
				{
					MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, new Coordinate(0L, 0L));
				}
				else
				{
					Coordinate point = new Coordinate(random.Next() % HW.mMaxX[0], random.Next() % HW.mMaxY[0]);
					MainForm0.moveToXY_andWait(mFn, USR.mXYSpeed, point);
				}
				Invoke((MethodInvoker)delegate
				{
					progressBar_FactoryTest.Value = i;
				});
				Thread.Sleep(75);
				if (!mIsFactoryTest)
				{
					break;
				}
			}
			Invoke((MethodInvoker)delegate
			{
				UI_ControlEnable_FactoryTest(flag: true);
				mIsFactoryTest = false;
			});
		}

		private void __numericUpDown_factorytest_count_ValueChanged(object sender, EventArgs e)
		{
		}

		private void __button_FactoryTest_OpenFeeder_Click(object sender, EventArgs e)
		{
			MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, (int)numericUpDown_FactoryTest_feederNum.Value - 1, flag: true);
		}

		private void __button_FactoryTest_CloseFeeder_Click(object sender, EventArgs e)
		{
			MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, (int)numericUpDown_FactoryTest_feederNum.Value - 1, flag: false);
		}

		private void __button_FactoryTest_AutoFeeder_Click(object sender, EventArgs e)
		{
			MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, (int)numericUpDown_FactoryTest_feederNum.Value - 1, flag: true);
			Thread.Sleep((int)numericUpDown_AutoFeeder_Delay.Value);
			MainForm0.misc_feeder_onoff(mFn, ProviderType.Feedr, (int)numericUpDown_FactoryTest_feederNum.Value - 1, flag: false);
			if (checkBox_AutoFeeder_Inc.Checked)
			{
				if (numericUpDown_FactoryTest_feederNum.Value < numericUpDown_FactoryTest_feederNum.Maximum)
				{
					++numericUpDown_FactoryTest_feederNum.Value;
				}
				else
				{
					numericUpDown_FactoryTest_feederNum.Value = 1m;
				}
			}
		}

		private void __numericUpDown_FactoryTest_feederNum_ValueChanged(object sender, EventArgs e)
		{
		}

		private void __numericUpDown_AutoFeeder_Delay_ValueChanged(object sender, EventArgs e)
		{
		}

		private void __checkBox_AutoFeeder_Inc_CheckedChanged(object sender, EventArgs e)
		{
		}
	}
}
