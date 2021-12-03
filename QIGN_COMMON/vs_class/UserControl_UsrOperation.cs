using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_UsrOperation : UserControl
	{
		private struct LongMoveParaSt
		{
			public QnCommon.MoveTypeEn type;

			public QnCommon.MoveDirEn dir;

			public int zn;
		}

		public class UPDATE_ZA
		{
			public int zn;

			public int value;

			public UPDATE_ZA(int a, int b)
			{
				zn = a;
				value = b;
			}
		}

		private Thread mThread_MoveXYZA;

		private CnButton[] button_cam;

		private RadioButton[] radiobutton_cam;

		private UserControl_MarkCamPara uc_markcampara;

		private IContainer components;

		private Panel panel_camOperation;

		private CnButton button_MarkCamPara;

		private Panel panel_cam;

		private RadioButton rd_FastCam;

		private RadioButton rd_HighCam;

		private RadioButton rd_MarkCam;

		private CnButton button_OpenLed;

		private CnButton button_iLLLED_open;

		private Panel panel_za;

		private Panel panel_usrOperation;

		private Panel panel_boradoperation;

		private CnButton button_PCBAddWidth;

		private CnButton button_PCBReduceWidth;

		private CnButton button_BoardIn;

		private CnButton btn_Throw;

		private CnButton button_BoardOut;

		private CnButton button_VacuunOffAll;

		private CnButton button_BoardFix;

		private CnButton button_BoardRelease;

		private CnButton button_VacuumOnOff;

		private Panel panel56;

		private CnButton bt_back;

		private CnButton bt_up;

		private CnButton bt_left;

		private CnButton bt_down;

		private CnButton bt_reset;

		private CnButton bt_circle;

		private CnButton bt_rightford;

		private CnButton bt_right;

		private CnButton bt_zero;

		private CnButton bt_forward;

		private CnButton bt_leftback;

		private CnButton bt_rightback;

		private CnButton bt_reverse;

		private CnButton bt_leftford;

		private Panel panel_movePara;

		private CheckBox checkBox_ChipBoundary2;

		private Label lbv_railspeed;

		private Label lbv_xyspeed;

		private Label lbv_aspeed;

		private Label lbv_zspeed;

		private Label lb_speed1;

		private Label lb_speed3;

		private Label lb_speed2;

		private TrackBar trb_railspeed;

		private TrackBar trb_aspeed;

		private TrackBar trb_zspeed;

		private Label lb_speed0;

		private TrackBar trb_xyspeed;

		private NumericUpDown nud_railstep;

		private NumericUpDown nud_zstep;

		private NumericUpDown nud_xystep;

		private Label label_prevline_color;

		private CheckBox checkBox_PreviewLine;

		private CheckBox checkBox_ChipBoundary;

		private Label lb_zstep;

		private Label lb_boardstep;

		private NumericUpDown nud_astep;

		private Label lb_xystep;

		private Label lb_astep;

		private Panel panel_nozzle;

		private Panel panel_default_xy;

		private Button button1;

		private Button button4;

		private Button button2;

		private Button button3;

		private Panel panel_default_z;

		private Button button5;

		private Button button6;

		private Button button7;

		private Button button8;

		private CnButton button_defaultxyz_set;

		private System.Windows.Forms.Timer tmr_LongMove;

		private Label lbv_xy;

		private Label label_XY_name;

		private CnButton button_PreviewZoom;

		private Panel panel_ChipBoundary;

		private Label label_chipbox_w;

		private TrackBar trackBar_chipbox_h;

		private TrackBar trackBar_chipbox_w;

		private TrackBar trackBar_chipbox_angle;

		private Label label_chipbox_h;

		private Panel panel_ChipBoundary2;

		private Label label211;

		private TrackBar trackBar_boundary2;

		private CnButton button_close_ChipBoundary;

		private CnButton button_close_ChipBoundary2;

		private Label label_boundary2;

		private Label label_chipbox_angle;

		private Panel panel_inboard_section;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private CnButton button_FeederOffAll;

		private Panel panel_defaultxyz;

		private CnButton button_defaultxyz_close;

		private Panel panel_visual_debug;

		private CnButton button_cam_set;

		private TextBox textBox_footprintname;

		private Label label_footprint;

		private CnButton button_factory_capture2;

		private CnButton button_factory_capture;

		private Label label_visualtype;

		private CnButton button_visualtest;

		private CnButton button_visual_debug_close;

		private CnButton button_visual_debug;

		private Panel panel1;

		private Panel panel2;

		private Panel panel_preview;

		private PictureBox PicBox_Preview;

		private PictureBox pictureBox_visualrunning;

		private PictureBox pictureBox_VisualTest;

		private CnButton button_stop_runningvisual;

		private Panel panel3;

		private Label label2;

		private PictureBox PicBox_Preview2;

		private CnButton button_OpenLed_hcam;

		private CnButton button_OpenLed_fcam;

		private CheckBox checkBox_PreviewLine0;

		private Label label3;

		private Panel panel_markcampara;

		private Panel panel5;

		private Panel panel9;

		private CnButton button_led;

		private CnButton button_light;

		private Label label4;

		private Panel panel7;

		private Label label5;

		private Panel panel6;

		private Label label6;

		private Panel panel8;

		private Panel panel10;

		private Label label7;

		private NumericUpDown numericUpDown_markStillDelay;

		private Label label8;

		private CnButton button_markcampara_close;

		private NumericUpDown numericUpDown_threshold;

		private NumericUpDown numericUpDown_scanr;

		private Label label10;

		private Label label9;

		private Panel panel_visualtest_lw;

		private NumericUpDown numericUpDown_testW;

		private NumericUpDown numericUpDown_testL;

		private Label label213;

		private Label label11;

		private Label label_chipboxcolor;

		private Label label_chipbox2color;

		private Label label12;

		private Label label1;

		private Label label14;

		private Label label16;

		private Label label15;

		private Label label18;

		private Label label17;

		private Label label19;

		private CnButton cnButton_deviceCalibration;

		private Label label20;

		private CnButton cnButton_trackpara;

		private Panel panel_visualtest_para;

		public int mJvs_picboxWidth;

		public int mJvs_picboxHeight;

		public PictureBox PicBoxCSL = new PictureBox();

		public PictureBox PicBoxCSL0 = new PictureBox();

		public PictureBox pb_r2 = new PictureBox();

		public PictureBox pb_r3 = new PictureBox();

		public PictureBox pb_r1 = new PictureBox();

		public bool JK_PrvMove = true;

		private Point Pea1;

		public RadioButton[] radioButton_inboard_s;

		public int inboard_section;

		private TrackBar[] trackBar_led;

		private TrackBar[] trackBar_cam;

		private Label[] label_led;

		private Label[] label_cam;

		private int[] mIsParaIndexChange;

		private int mFn;

		private USR_DATA USR;

		private USR_INIT_DATA USR_INIT;

		private CnButton[] button_nozzle;

		public Label[] lb_zn;

		public Label[] lbv_zn;

		public Label[] lbv_an;

		private Button[] button_default_xy;

		private Button[] button_default_z;

		public event void_Func_int Reset;

		public event void_Func_int_Cam vsplus_switch_to_camera;

		public event void_Func_int vsplus_markCameraPara;

		public event void_Func_int vsplus_reopen_preview;

		public event void_Func_VisualPara vsplus_visual_test;

		public event void_Func_int vsplus_open_visualshow;

		public event void_Func_int vsplus_factory_capture;

		public event void_Func_int vsplus_open_fixcampara;

		public event void_Func_int_int_int_bool misc_board_out;

		private void init_move()
		{
			bt_forward.Tag = QnCommon.MoveDirEn.YPositive;
			bt_back.Tag = QnCommon.MoveDirEn.YReverse;
			bt_left.Tag = QnCommon.MoveDirEn.XReverse;
			bt_right.Tag = QnCommon.MoveDirEn.XPositive;
			bt_leftford.Tag = QnCommon.MoveDirEn.XReverseYPositive;
			bt_leftback.Tag = QnCommon.MoveDirEn.XReverseYReverse;
			bt_rightford.Tag = QnCommon.MoveDirEn.XPositiveYPositive;
			bt_rightback.Tag = QnCommon.MoveDirEn.XPositiveYReverse;
			bt_forward.MouseUp += bt_forward_MouseUp;
			bt_back.MouseUp += bt_forward_MouseUp;
			bt_left.MouseUp += bt_forward_MouseUp;
			bt_right.MouseUp += bt_forward_MouseUp;
			bt_leftford.MouseUp += bt_forward_MouseUp;
			bt_leftback.MouseUp += bt_forward_MouseUp;
			bt_rightford.MouseUp += bt_forward_MouseUp;
			bt_rightback.MouseUp += bt_forward_MouseUp;
			bt_forward.MouseDown += bt_forward_MouseDown;
			bt_back.MouseDown += bt_forward_MouseDown;
			bt_left.MouseDown += bt_forward_MouseDown;
			bt_right.MouseDown += bt_forward_MouseDown;
			bt_leftford.MouseDown += bt_forward_MouseDown;
			bt_leftback.MouseDown += bt_forward_MouseDown;
			bt_rightford.MouseDown += bt_forward_MouseDown;
			bt_rightback.MouseDown += bt_forward_MouseDown;
			bt_up.Tag = QnCommon.MoveDirEn.ZUP;
			bt_down.Tag = QnCommon.MoveDirEn.ZDOWN;
			bt_up.MouseUp += bt_zmove_MouseUp;
			bt_down.MouseUp += bt_zmove_MouseUp;
			bt_up.MouseDown += bt_zmove_MouseDown;
			bt_down.MouseDown += bt_zmove_MouseDown;
			bt_circle.Tag = QnCommon.MoveDirEn.APositive;
			bt_reverse.Tag = QnCommon.MoveDirEn.AReverse;
			bt_circle.MouseUp += bt_amove_MouseUp;
			bt_reverse.MouseUp += bt_amove_MouseUp;
			bt_circle.MouseDown += bt_amove_MouseDown;
			bt_reverse.MouseDown += bt_amove_MouseDown;
			button_PCBAddWidth.MouseUp += button_PCBAddWidth_MouseUp;
			button_PCBReduceWidth.MouseUp += button_PCBAddWidth_MouseUp;
			button_PCBAddWidth.MouseDown += button_PCBAddWidth_MouseDown;
			button_PCBReduceWidth.MouseDown += button_PCBAddWidth_MouseDown;
		}

		private void __tmr_LongMove_Tick(object sender, EventArgs e)
		{
			tmr_LongMove.Stop();
			LongMoveParaSt longMoveParaSt = (LongMoveParaSt)tmr_LongMove.Tag;
			switch (longMoveParaSt.type)
			{
			case QnCommon.MoveTypeEn.MoveXY:
				MainForm0.moveToZero_Z_andWait(mFn);
				MainForm0.mConDev[mFn].sendxyConstantSpeed(longMoveParaSt.dir, USR.mXYSpeed);
				break;
			case QnCommon.MoveTypeEn.MoveZ:
				if (HW.mSmtGenerationNo == 0)
				{
					QnCommon.RunDirEn dir = ((longMoveParaSt.zn % 2 != 0) ? ((longMoveParaSt.dir != QnCommon.MoveDirEn.ZUP) ? QnCommon.RunDirEn.Positive : QnCommon.RunDirEn.Reverse) : ((longMoveParaSt.dir == QnCommon.MoveDirEn.ZUP) ? QnCommon.RunDirEn.Positive : QnCommon.RunDirEn.Reverse));
					if (longMoveParaSt.dir != QnCommon.MoveDirEn.ZUP || MainForm0.mCur[mFn].z[longMoveParaSt.zn] != 0)
					{
						MainForm0.mConDev[mFn].sendzConstantSpeed(dir, longMoveParaSt.zn, USR.mZSpeed);
					}
				}
				else
				{
					if (HW.mSmtGenerationNo != 2)
					{
						break;
					}
					QnCommon.RunDirEn dir = ((longMoveParaSt.dir == QnCommon.MoveDirEn.ZUP) ? QnCommon.RunDirEn.Positive : QnCommon.RunDirEn.Reverse);
					if (longMoveParaSt.dir == QnCommon.MoveDirEn.ZUP)
					{
						if (MainForm0.mCur[mFn].z[longMoveParaSt.zn] == 0)
						{
							break;
						}
					}
					else if (longMoveParaSt.dir == QnCommon.MoveDirEn.ZDOWN && MainForm0.mCur[mFn].z[longMoveParaSt.zn] >= HW.mMaxZ[0])
					{
						break;
					}
					MainForm0.move_z_constant_gen2(mFn, dir, longMoveParaSt.zn, USR.mZSpeed);
				}
				break;
			case QnCommon.MoveTypeEn.MoveA:
			{
				QnCommon.RunDirEn dir = ((longMoveParaSt.dir == QnCommon.MoveDirEn.APositive) ? QnCommon.RunDirEn.Positive : QnCommon.RunDirEn.Reverse);
				MainForm0.move_a_constant(mFn, dir, longMoveParaSt.zn, USR.mASpeed);
				break;
			}
			case QnCommon.MoveTypeEn.MoveRail:
				if (longMoveParaSt.dir == QnCommon.MoveDirEn.YPositive)
				{
					MainForm0.mConDevExt[0].sendTrackConstantSpeed(0, USR.mRailSpeed);
				}
				else
				{
					MainForm0.mConDevExt[0].sendTrackConstantSpeed(1, USR.mRailSpeed);
				}
				break;
			case QnCommon.MoveTypeEn.MoveFLKX:
				MainForm0.moveToZero_Z_andWait(mFn);
				MainForm0.mConDevExt[0].sendxyConstantSpeed_flktab(longMoveParaSt.dir, USR.mRailSpeed);
				break;
			}
		}

		private void bt_forward_MouseDown(object sender, MouseEventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				if (!MainForm0.mMutexBtDown)
				{
					MainForm0.mMutexBtDown = true;
					MainForm0.write_to_logFile_hand("HAND: bt_forward_MouseDown" + Environment.NewLine);
					LongMoveParaSt longMoveParaSt = default(LongMoveParaSt);
					longMoveParaSt.type = QnCommon.MoveTypeEn.MoveXY;
					longMoveParaSt.dir = (QnCommon.MoveDirEn)((Button)sender).Tag;
					tmr_LongMove.Tag = longMoveParaSt;
					tmr_LongMove.Start();
				}
			}
		}

		private void bt_forward_MouseUp(object sender, MouseEventArgs e)
		{
			if (MainForm0.mMutexBtDown)
			{
				MainForm0.mMutexBtDown = false;
				MainForm0.write_to_logFile_hand("HAND: bt_forward_MouseUp" + Environment.NewLine);
				if (tmr_LongMove.Enabled)
				{
					tmr_LongMove.Stop();
					mThread_MoveXYZA = new Thread(thd_Move);
					mThread_MoveXYZA.IsBackground = true;
					mThread_MoveXYZA.Start((Button)sender);
				}
				else
				{
					MainForm0.mConDev[mFn].SendStopMove();
					MainForm0.mMutexMoveXYZA = false;
					MainForm0.pcbcheck_sel_nearestchip(mFn);
				}
			}
		}

		private void thd_Move(object sender)
		{
			MainForm0.mIsXYMoving[mFn] = true;
			if (MainForm0.mIsFeederUp[mFn])
			{
				Thread.Sleep(5);
			}
			else
			{
				MainForm0.moveToZero_Z_andWait(mFn);
				int num = MainForm0.mCur[mFn].x;
				int num2 = MainForm0.mCur[mFn].y;
				int num3 = (int)((Button)sender).Tag;
				QnCommon.MoveDirEn moveDirEn = (QnCommon.MoveDirEn)(num3 & 0xF0);
				QnCommon.MoveDirEn moveDirEn2 = (QnCommon.MoveDirEn)(num3 & 0xF);
				if (USR.mXYStep < 1)
				{
					USR.mXYStep = 1;
				}
				else if (USR.mXYStep > 50000)
				{
					USR.mXYStep = 50000;
				}
				if (moveDirEn == QnCommon.MoveDirEn.XReverse)
				{
					num -= USR.mXYStep;
					if (num < 0)
					{
						num = 0;
					}
					else if (num > HW.mMaxX[mFn])
					{
						goto IL_0210;
					}
				}
				else if (moveDirEn == QnCommon.MoveDirEn.XPositive)
				{
					num += USR.mXYStep;
					if (num > HW.mMaxX[mFn])
					{
						num = HW.mMaxX[mFn];
					}
					else if (num < 0)
					{
						goto IL_0210;
					}
				}
				if (moveDirEn2 == QnCommon.MoveDirEn.YReverse)
				{
					num2 -= USR.mXYStep;
					if (num2 < 0)
					{
						num2 = 0;
					}
					else if (num2 > HW.mMaxY[mFn])
					{
						goto IL_0210;
					}
				}
				else if (moveDirEn2 == QnCommon.MoveDirEn.YPositive)
				{
					num2 += USR.mXYStep;
					if (num2 > HW.mMaxY[mFn])
					{
						num2 = HW.mMaxY[mFn];
					}
					else if (num2 < 0)
					{
						goto IL_0210;
					}
				}
				if (num >= 0 && num <= HW.mMaxX[mFn] && num2 >= 0 && num2 <= HW.mMaxY[mFn])
				{
					MainForm0.mWaitXY[mFn] = new Coordinate(num, num2);
					MainForm0.mConDev[mFn].sendxyCoordinate(num, num2, USR.mXYSpeed);
					MainForm0.Waiting(96, mFn, 0, 15000, 0);
					MainForm0.pcbcheck_sel_nearestchip(mFn);
				}
			}
			goto IL_0210;
			IL_0210:
			MainForm0.mIsXYMoving[mFn] = false;
			MainForm0.mMutexMoveXYZA = false;
		}

		private void bt_zmove_MouseDown(object sender, MouseEventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				if (!MainForm0.mMutexBtDown)
				{
					MainForm0.mMutexBtDown = true;
					MainForm0.write_to_logFile_hand("HAND: bt_zmove_MouseDown" + Environment.NewLine);
					LongMoveParaSt longMoveParaSt = default(LongMoveParaSt);
					longMoveParaSt.type = QnCommon.MoveTypeEn.MoveZ;
					longMoveParaSt.dir = (QnCommon.MoveDirEn)((Button)sender).Tag;
					longMoveParaSt.zn = MainForm0.mZn[mFn];
					tmr_LongMove.Tag = longMoveParaSt;
					tmr_LongMove.Start();
				}
			}
		}

		private void bt_zmove_MouseUp(object sender, MouseEventArgs e)
		{
			if (!MainForm0.mMutexBtDown)
			{
				return;
			}
			MainForm0.mMutexBtDown = false;
			MainForm0.write_to_logFile_hand("HAND: bt_zmove_MouseUp" + Environment.NewLine);
			if (tmr_LongMove.Enabled)
			{
				tmr_LongMove.Stop();
				mThread_MoveXYZA = new Thread(thd_MoveZ);
				mThread_MoveXYZA.IsBackground = true;
				mThread_MoveXYZA.Start((Button)sender);
			}
			else
			{
				if (HW.mSmtGenerationNo == 0)
				{
					MainForm0.mConDev[mFn].SendStopMove();
				}
				else
				{
					MainForm0.move_stop_gen2(mFn);
				}
				MainForm0.mMutexMoveXYZA = false;
			}
		}

		private void thd_MoveZ(object sender)
		{
			int num = MainForm0.mCur[mFn].z[MainForm0.mZn[mFn]];
			QnCommon.MoveDirEn moveDirEn = (QnCommon.MoveDirEn)((Button)sender).Tag;
			if (HW.mSmtGenerationNo == 0)
			{
				_ = MainForm0.mZn[mFn] % 2;
				if (MainForm0.mZn[mFn] % 2 == 0 && moveDirEn == QnCommon.MoveDirEn.ZUP)
				{
					num += USR.mZStep;
					if (num > 0)
					{
						num = 0;
					}
				}
				else if (MainForm0.mZn[mFn] % 2 == 0 && moveDirEn == QnCommon.MoveDirEn.ZDOWN)
				{
					num -= USR.mZStep;
					if (num < -HW.mMaxZ[mFn])
					{
						num = -HW.mMaxZ[mFn];
					}
				}
				else if (MainForm0.mZn[mFn] % 2 == 1 && moveDirEn == QnCommon.MoveDirEn.ZUP)
				{
					num -= USR.mZStep;
					if (num < 0)
					{
						num = 0;
					}
				}
				else if (MainForm0.mZn[mFn] % 2 == 1 && moveDirEn == QnCommon.MoveDirEn.ZDOWN)
				{
					num += USR.mZStep;
					if (num > HW.mMaxZ[mFn])
					{
						num = HW.mMaxZ[mFn];
					}
				}
				MainForm0.mWaitZ[mFn][MainForm0.mZn[mFn]] = num;
				MainForm0.mConDev[mFn].sendzCoordinate(MainForm0.mZn[mFn], num, USR.mZSpeed);
			}
			else if (HW.mSmtGenerationNo == 2)
			{
				if (moveDirEn == QnCommon.MoveDirEn.ZUP)
				{
					num -= USR.mZStep;
					if (num < 0)
					{
						num = 0;
					}
				}
				else
				{
					num += USR.mZStep;
					if (num > HW.mMaxZ[mFn])
					{
						num = HW.mMaxZ[mFn];
					}
				}
				MainForm0.mWaitZ[mFn][MainForm0.mZn[mFn]] = num;
				MainForm0.move_z_coordinate_gen2(mFn, MainForm0.mZn[mFn], num, USR.mZSpeed);
			}
			MainForm0.Waiting(98, mFn, MainForm0.mZn[mFn], 15000, 0);
			MainForm0.mMutexMoveXYZA = false;
		}

		private void bt_amove_MouseDown(object sender, MouseEventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				if (!MainForm0.mMutexBtDown)
				{
					MainForm0.mMutexBtDown = true;
					MainForm0.write_to_logFile_hand("HAND: bt_amove_MouseDown" + Environment.NewLine);
					LongMoveParaSt longMoveParaSt = default(LongMoveParaSt);
					longMoveParaSt.type = QnCommon.MoveTypeEn.MoveA;
					longMoveParaSt.dir = (QnCommon.MoveDirEn)((Button)sender).Tag;
					longMoveParaSt.zn = MainForm0.mZn[mFn];
					tmr_LongMove.Tag = longMoveParaSt;
					tmr_LongMove.Start();
				}
			}
		}

		private void bt_amove_MouseUp(object sender, MouseEventArgs e)
		{
			if (!MainForm0.mMutexBtDown)
			{
				return;
			}
			MainForm0.mMutexBtDown = false;
			MainForm0.write_to_logFile_hand("HAND: bt_amove_MouseUp" + Environment.NewLine);
			if (tmr_LongMove.Enabled)
			{
				tmr_LongMove.Stop();
				if (mThread_MoveXYZA != null && mThread_MoveXYZA.IsAlive)
				{
					MainForm0.mMutexMoveXYZA = false;
					return;
				}
				mThread_MoveXYZA = new Thread(thd_MoveA);
				mThread_MoveXYZA.IsBackground = true;
				mThread_MoveXYZA.Start((Button)sender);
			}
			else
			{
				if (HW.mSmtGenerationNo == 0)
				{
					MainForm0.mConDev[mFn].SendStopMove();
				}
				else
				{
					MainForm0.move_stop_gen2(mFn);
				}
				MainForm0.mMutexMoveXYZA = false;
			}
		}

		private void thd_MoveA(object sender)
		{
			int num = MainForm0.mCur[mFn].a[MainForm0.mZn[mFn]];
			QnCommon.MoveDirEn moveDirEn = (QnCommon.MoveDirEn)((Button)sender).Tag;
			switch ((moveDirEn == QnCommon.MoveDirEn.APositive) ? 1 : (-1))
			{
			case 1:
				num += (int)Math.Round((double)USR.mAStepDegree / (9.0 / 640.0), 0);
				break;
			case -1:
				num -= (int)Math.Round((double)USR.mAStepDegree / (9.0 / 640.0), 0);
				break;
			}
			MainForm0.moveToA_andWait(mFn, MainForm0.mZn[mFn], USR.mASpeed, num);
			MainForm0.mMutexMoveXYZA = false;
		}

		private void button_PCBAddWidth_MouseDown(object sender, MouseEventArgs e)
		{
			if (MainForm0.mMutexMoveXYZA)
			{
				return;
			}
			MainForm0.mMutexMoveXYZA = true;
			LongMoveParaSt longMoveParaSt = default(LongMoveParaSt);
			longMoveParaSt.type = QnCommon.MoveTypeEn.MoveRail;
			if (HW.mDeviceType >= DeviceType.HW_8S)
			{
				if ((int)((Button)sender).Tag == 0)
				{
					longMoveParaSt.dir = QnCommon.MoveDirEn.YPositive;
				}
				else
				{
					longMoveParaSt.dir = QnCommon.MoveDirEn.YReverse;
				}
			}
			else if ((int)((Button)sender).Tag == 0)
			{
				longMoveParaSt.dir = QnCommon.MoveDirEn.YReverse;
			}
			else
			{
				longMoveParaSt.dir = QnCommon.MoveDirEn.YPositive;
			}
			tmr_LongMove.Tag = longMoveParaSt;
			tmr_LongMove.Start();
		}

		private void button_PCBAddWidth_MouseUp(object sender, MouseEventArgs e)
		{
			if (tmr_LongMove.Enabled)
			{
				tmr_LongMove.Stop();
				if (mThread_MoveXYZA != null && mThread_MoveXYZA.IsAlive)
				{
					MainForm0.mMutexMoveXYZA = false;
					return;
				}
				mThread_MoveXYZA = new Thread(thd_MoveRail);
				mThread_MoveXYZA.IsBackground = true;
				mThread_MoveXYZA.Start((Button)sender);
			}
			else
			{
				MainForm0.mConDevExt[0].sendTrackStopMove();
				MainForm0.mMutexMoveXYZA = false;
			}
		}

		private void thd_MoveRail(object sender)
		{
			if (HW.mDeviceType >= DeviceType.HW_8S)
			{
				if ((int)((Button)sender).Tag == 0)
				{
					MainForm0.mConDevExt[0].sendTrackCoordinate(USR.mRailStep, 0, USR.mRailSpeed);
				}
				else
				{
					MainForm0.mConDevExt[0].sendTrackCoordinate(USR.mRailStep, 1, USR.mRailSpeed);
				}
			}
			else if ((int)((Button)sender).Tag == 0)
			{
				MainForm0.mConDevExt[0].sendTrackCoordinate(USR.mRailStep, 1, USR.mRailSpeed);
			}
			else
			{
				MainForm0.mConDevExt[0].sendTrackCoordinate(USR.mRailStep, 0, USR.mRailSpeed);
			}
			MainForm0.mMutexMoveXYZA = false;
		}

		private void __bt_zero_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_ZnAnAlltoZero);
				thread.Start(mFn);
			}
		}

		private void init_cam()
		{
			rd_MarkCam.Tag = CameraType.Mark;
			rd_MarkCam.CheckedChanged += rd_MarkCam_CheckedChanged;
			rd_FastCam.Tag = CameraType.Fast;
			rd_FastCam.CheckedChanged += rd_MarkCam_CheckedChanged;
			rd_HighCam.Tag = CameraType.High;
			rd_HighCam.CheckedChanged += rd_MarkCam_CheckedChanged;
			radiobutton_cam = new RadioButton[3] { rd_MarkCam, rd_FastCam, rd_HighCam };
			button_cam = new CnButton[3];
			for (int i = 0; i < 3; i++)
			{
				button_cam[i] = new CnButton();
				button_cam[i].Size = new Size(132, 30);
				button_cam[i].Font = new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], 12f, FontStyle.Regular);
				button_cam[i].Location = new Point(71 + 138 * i, 515);
				button_cam[i].Text = STR.CAMERA_STR[i][USR_INIT.mLanguage];
				button_cam[i].ForeColor = Color.White;
				button_cam[i].BackColor = Color.DimGray;
				button_cam[i].CnPressDownColor = Color.Red;
				button_cam[i].CnButtonMode = ButtonModeEn.PressRadio;
				button_cam[i].CnSetPressDown(i == (int)MainForm0.mCurCam[mFn]);
				button_cam[i].Tag = i;
				base.Controls.Add(button_cam[i]);
				button_cam[i].BringToFront();
				button_cam[i].MouseDown += button_cam_MouseDown;
			}
			if (!HW.mHCamEn[mFn])
			{
				button_cam[2].Enabled = false;
			}
			hiden_cam_button(flag: true);
		}

		private void button_cam_flush()
		{
			for (int i = 0; i < 3; i++)
			{
				button_cam[i].CnSetPressDown(i == (int)MainForm0.mCurCam[mFn]);
			}
		}

		public void hiden_cam_button(bool flag)
		{
			for (int i = 0; i < 3; i++)
			{
				button_cam[i].Visible = !flag;
			}
		}

		private void button_cam_MouseDown(object sender, MouseEventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			int num = (int)cnButton.Tag;
			if (num >= 0 && num < 3)
			{
				radiobutton_cam[num].Checked = true;
				button_cam_flush();
			}
		}

		private void flush_byCam()
		{
		}

		private void __button_iLLLED_open_Click(object sender, EventArgs e)
		{
			MainForm0.mark_light_on(mFn, !USR.mIsMarkLightOn);
		}

		private void __button_OpenLed_Click(object sender, EventArgs e)
		{
			if (!USR.mIsMarkLedOn)
			{
				MainForm0.mark_led_on(mFn, flag: true);
			}
			else
			{
				MainForm0.mark_led_on(mFn, flag: false);
			}
		}

		private void __button_OpenLed_fcam_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mFastCamLedState[mFn])
			{
				MainForm0.fhcam_led_on(mFn, CameraType.Fast, flag: true);
			}
			else
			{
				MainForm0.fhcam_led_on(mFn, CameraType.Fast, flag: false);
			}
		}

		private void __button_OpenLed_hcam_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mHighCamLedState[mFn])
			{
				MainForm0.fhcam_led_on(mFn, CameraType.High, flag: true);
			}
			else
			{
				MainForm0.fhcam_led_on(mFn, CameraType.High, flag: false);
			}
		}

		private void rd_MarkCam_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
			{
				CameraType cam = (CameraType)((RadioButton)sender).Tag;
				if (this.vsplus_switch_to_camera != null)
				{
					this.vsplus_switch_to_camera(mFn, cam);
				}
				flush_byCam();
			}
		}

		public void switch_to_cam(CameraType cam)
		{
			Invoke((MethodInvoker)delegate
			{
				if (cam == CameraType.Mark)
				{
					rd_MarkCam.Checked = true;
				}
				else if (cam == CameraType.Fast)
				{
					rd_FastCam.Checked = true;
				}
				else if (cam == CameraType.High)
				{
					rd_HighCam.Checked = true;
				}
				button_cam_flush();
			});
		}

		public void update_light_button_state()
		{
			Invoke((MethodInvoker)delegate
			{
				button_iLLLED_open.CnSetPressDown(USR.mIsMarkLightOn);
			});
		}

		public void update_led_button_state(CameraType camtype)
		{
			switch (camtype)
			{
			case CameraType.Mark:
				Invoke((MethodInvoker)delegate
				{
					button_OpenLed.CnSetPressDown(USR.mIsMarkLedOn);
				});
				break;
			case CameraType.Fast:
				Invoke((MethodInvoker)delegate
				{
					button_OpenLed_fcam.CnSetPressDown(MainForm0.mFastCamLedState[mFn]);
				});
				break;
			case CameraType.High:
				Invoke((MethodInvoker)delegate
				{
					button_OpenLed_hcam.CnSetPressDown(MainForm0.mHighCamLedState[mFn]);
				});
				break;
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
			components = new System.ComponentModel.Container();
			panel_camOperation = new System.Windows.Forms.Panel();
			label_prevline_color = new System.Windows.Forms.Label();
			checkBox_ChipBoundary2 = new System.Windows.Forms.CheckBox();
			checkBox_PreviewLine = new System.Windows.Forms.CheckBox();
			panel_cam = new System.Windows.Forms.Panel();
			rd_FastCam = new System.Windows.Forms.RadioButton();
			rd_MarkCam = new System.Windows.Forms.RadioButton();
			rd_HighCam = new System.Windows.Forms.RadioButton();
			checkBox_ChipBoundary = new System.Windows.Forms.CheckBox();
			panel_za = new System.Windows.Forms.Panel();
			label_XY_name = new System.Windows.Forms.Label();
			lbv_xy = new System.Windows.Forms.Label();
			panel_usrOperation = new System.Windows.Forms.Panel();
			panel_boradoperation = new System.Windows.Forms.Panel();
			panel_inboard_section = new System.Windows.Forms.Panel();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			pictureBox_VisualTest = new System.Windows.Forms.PictureBox();
			panel_movePara = new System.Windows.Forms.Panel();
			lb_speed1 = new System.Windows.Forms.Label();
			lb_speed3 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			checkBox_PreviewLine0 = new System.Windows.Forms.CheckBox();
			lb_speed2 = new System.Windows.Forms.Label();
			lb_speed0 = new System.Windows.Forms.Label();
			trb_railspeed = new System.Windows.Forms.TrackBar();
			lbv_railspeed = new System.Windows.Forms.Label();
			trb_aspeed = new System.Windows.Forms.TrackBar();
			lbv_xyspeed = new System.Windows.Forms.Label();
			trb_zspeed = new System.Windows.Forms.TrackBar();
			lbv_aspeed = new System.Windows.Forms.Label();
			trb_xyspeed = new System.Windows.Forms.TrackBar();
			lbv_zspeed = new System.Windows.Forms.Label();
			nud_railstep = new System.Windows.Forms.NumericUpDown();
			nud_zstep = new System.Windows.Forms.NumericUpDown();
			nud_xystep = new System.Windows.Forms.NumericUpDown();
			lb_zstep = new System.Windows.Forms.Label();
			lb_boardstep = new System.Windows.Forms.Label();
			nud_astep = new System.Windows.Forms.NumericUpDown();
			lb_xystep = new System.Windows.Forms.Label();
			lb_astep = new System.Windows.Forms.Label();
			panel56 = new System.Windows.Forms.Panel();
			panel_default_z = new System.Windows.Forms.Panel();
			button5 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			panel_default_xy = new System.Windows.Forms.Panel();
			button4 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel_nozzle = new System.Windows.Forms.Panel();
			tmr_LongMove = new System.Windows.Forms.Timer(components);
			panel_ChipBoundary = new System.Windows.Forms.Panel();
			label16 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label_chipboxcolor = new System.Windows.Forms.Label();
			label_chipbox_h = new System.Windows.Forms.Label();
			label_chipbox_angle = new System.Windows.Forms.Label();
			label_chipbox_w = new System.Windows.Forms.Label();
			trackBar_chipbox_h = new System.Windows.Forms.TrackBar();
			trackBar_chipbox_w = new System.Windows.Forms.TrackBar();
			trackBar_chipbox_angle = new System.Windows.Forms.TrackBar();
			panel_ChipBoundary2 = new System.Windows.Forms.Panel();
			label18 = new System.Windows.Forms.Label();
			label_chipbox2color = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label_boundary2 = new System.Windows.Forms.Label();
			label211 = new System.Windows.Forms.Label();
			trackBar_boundary2 = new System.Windows.Forms.TrackBar();
			panel_defaultxyz = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			panel_visual_debug = new System.Windows.Forms.Panel();
			label14 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel_visualtest_lw = new System.Windows.Forms.Panel();
			numericUpDown_testW = new System.Windows.Forms.NumericUpDown();
			numericUpDown_testL = new System.Windows.Forms.NumericUpDown();
			label11 = new System.Windows.Forms.Label();
			label213 = new System.Windows.Forms.Label();
			numericUpDown_threshold = new System.Windows.Forms.NumericUpDown();
			numericUpDown_scanr = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			textBox_footprintname = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label_footprint = new System.Windows.Forms.Label();
			label_visualtype = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			label19 = new System.Windows.Forms.Label();
			panel_preview = new System.Windows.Forms.Panel();
			PicBox_Preview = new System.Windows.Forms.PictureBox();
			panel_markcampara = new System.Windows.Forms.Panel();
			panel10 = new System.Windows.Forms.Panel();
			label7 = new System.Windows.Forms.Label();
			numericUpDown_markStillDelay = new System.Windows.Forms.NumericUpDown();
			label20 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			panel5 = new System.Windows.Forms.Panel();
			panel9 = new System.Windows.Forms.Panel();
			panel7 = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			panel6 = new System.Windows.Forms.Panel();
			label6 = new System.Windows.Forms.Label();
			panel8 = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			PicBox_Preview2 = new System.Windows.Forms.PictureBox();
			pictureBox_visualrunning = new System.Windows.Forms.PictureBox();
			panel_visualtest_para = new System.Windows.Forms.Panel();
			button_close_ChipBoundary2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_markcampara_close = new QIGN_COMMON.vs_acontrol.CnButton();
			button_led = new QIGN_COMMON.vs_acontrol.CnButton();
			button_light = new QIGN_COMMON.vs_acontrol.CnButton();
			button_visual_debug_close = new QIGN_COMMON.vs_acontrol.CnButton();
			button_factory_capture2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_factory_capture = new QIGN_COMMON.vs_acontrol.CnButton();
			button_cam_set = new QIGN_COMMON.vs_acontrol.CnButton();
			button_visualtest = new QIGN_COMMON.vs_acontrol.CnButton();
			button_stop_runningvisual = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_deviceCalibration = new QIGN_COMMON.vs_acontrol.CnButton();
			btn_Throw = new QIGN_COMMON.vs_acontrol.CnButton();
			button_iLLLED_open = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PreviewZoom = new QIGN_COMMON.vs_acontrol.CnButton();
			button_MarkCamPara = new QIGN_COMMON.vs_acontrol.CnButton();
			button_OpenLed_hcam = new QIGN_COMMON.vs_acontrol.CnButton();
			button_OpenLed_fcam = new QIGN_COMMON.vs_acontrol.CnButton();
			button_visual_debug = new QIGN_COMMON.vs_acontrol.CnButton();
			button_OpenLed = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBAddWidth = new QIGN_COMMON.vs_acontrol.CnButton();
			button_BoardIn = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBReduceWidth = new QIGN_COMMON.vs_acontrol.CnButton();
			button_BoardOut = new QIGN_COMMON.vs_acontrol.CnButton();
			button_VacuunOffAll = new QIGN_COMMON.vs_acontrol.CnButton();
			button_BoardFix = new QIGN_COMMON.vs_acontrol.CnButton();
			button_FeederOffAll = new QIGN_COMMON.vs_acontrol.CnButton();
			button_VacuumOnOff = new QIGN_COMMON.vs_acontrol.CnButton();
			button_BoardRelease = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_trackpara = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_back = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_up = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_left = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_down = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_reset = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_circle = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_rightford = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_right = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_zero = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_forward = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_leftback = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_rightback = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_reverse = new QIGN_COMMON.vs_acontrol.CnButton();
			bt_leftford = new QIGN_COMMON.vs_acontrol.CnButton();
			button_defaultxyz_close = new QIGN_COMMON.vs_acontrol.CnButton();
			button_defaultxyz_set = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close_ChipBoundary = new QIGN_COMMON.vs_acontrol.CnButton();
			panel_za.SuspendLayout();
			panel_usrOperation.SuspendLayout();
			panel_boradoperation.SuspendLayout();
			panel_inboard_section.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_VisualTest).BeginInit();
			panel_movePara.SuspendLayout();
			panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trb_railspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)trb_aspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)trb_zspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)trb_xyspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)nud_railstep).BeginInit();
			((System.ComponentModel.ISupportInitialize)nud_zstep).BeginInit();
			((System.ComponentModel.ISupportInitialize)nud_xystep).BeginInit();
			((System.ComponentModel.ISupportInitialize)nud_astep).BeginInit();
			panel56.SuspendLayout();
			panel_default_z.SuspendLayout();
			panel_default_xy.SuspendLayout();
			panel_ChipBoundary.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_chipbox_h).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_chipbox_w).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_chipbox_angle).BeginInit();
			panel_ChipBoundary2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_boundary2).BeginInit();
			panel_defaultxyz.SuspendLayout();
			panel_visual_debug.SuspendLayout();
			panel_visualtest_lw.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_testW).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_testL).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_threshold).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_scanr).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel_preview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PicBox_Preview).BeginInit();
			panel_markcampara.SuspendLayout();
			panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_markStillDelay).BeginInit();
			panel9.SuspendLayout();
			panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PicBox_Preview2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_visualrunning).BeginInit();
			panel_visualtest_para.SuspendLayout();
			SuspendLayout();
			panel_camOperation.Location = new System.Drawing.Point(583, 308);
			panel_camOperation.Name = "panel_camOperation";
			panel_camOperation.Size = new System.Drawing.Size(550, 67);
			panel_camOperation.TabIndex = 13;
			label_prevline_color.BackColor = System.Drawing.Color.Yellow;
			label_prevline_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_prevline_color.Location = new System.Drawing.Point(136, 24);
			label_prevline_color.Name = "label_prevline_color";
			label_prevline_color.Size = new System.Drawing.Size(22, 22);
			label_prevline_color.TabIndex = 163;
			label_prevline_color.Click += new System.EventHandler(label_prevline_color_Click);
			checkBox_ChipBoundary2.AutoSize = true;
			checkBox_ChipBoundary2.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_ChipBoundary2.ForeColor = System.Drawing.Color.Black;
			checkBox_ChipBoundary2.Location = new System.Drawing.Point(8, 27);
			checkBox_ChipBoundary2.Name = "checkBox_ChipBoundary2";
			checkBox_ChipBoundary2.Size = new System.Drawing.Size(58, 19);
			checkBox_ChipBoundary2.TabIndex = 164;
			checkBox_ChipBoundary2.Text = "圆框";
			checkBox_ChipBoundary2.UseVisualStyleBackColor = true;
			checkBox_ChipBoundary2.CheckedChanged += new System.EventHandler(checkBox_ChipBoundary2_CheckedChanged);
			checkBox_PreviewLine.AutoSize = true;
			checkBox_PreviewLine.Checked = true;
			checkBox_PreviewLine.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_PreviewLine.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_PreviewLine.ForeColor = System.Drawing.Color.Black;
			checkBox_PreviewLine.Location = new System.Drawing.Point(72, 27);
			checkBox_PreviewLine.Name = "checkBox_PreviewLine";
			checkBox_PreviewLine.Size = new System.Drawing.Size(58, 19);
			checkBox_PreviewLine.TabIndex = 3;
			checkBox_PreviewLine.Text = "刻度";
			checkBox_PreviewLine.UseVisualStyleBackColor = true;
			checkBox_PreviewLine.CheckedChanged += new System.EventHandler(checkBox_PreviewLine_CheckedChanged);
			panel_cam.Location = new System.Drawing.Point(584, 381);
			panel_cam.Name = "panel_cam";
			panel_cam.Size = new System.Drawing.Size(549, 59);
			panel_cam.TabIndex = 0;
			rd_FastCam.AutoSize = true;
			rd_FastCam.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			rd_FastCam.Location = new System.Drawing.Point(3, 25);
			rd_FastCam.Name = "rd_FastCam";
			rd_FastCam.Size = new System.Drawing.Size(90, 20);
			rd_FastCam.TabIndex = 1;
			rd_FastCam.Text = "快速相机";
			rd_FastCam.UseVisualStyleBackColor = true;
			rd_MarkCam.AutoSize = true;
			rd_MarkCam.Checked = true;
			rd_MarkCam.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			rd_MarkCam.Location = new System.Drawing.Point(3, 3);
			rd_MarkCam.Name = "rd_MarkCam";
			rd_MarkCam.Size = new System.Drawing.Size(90, 20);
			rd_MarkCam.TabIndex = 0;
			rd_MarkCam.TabStop = true;
			rd_MarkCam.Text = "俯视相机";
			rd_MarkCam.UseVisualStyleBackColor = true;
			rd_HighCam.AutoSize = true;
			rd_HighCam.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			rd_HighCam.Location = new System.Drawing.Point(3, 47);
			rd_HighCam.Name = "rd_HighCam";
			rd_HighCam.Size = new System.Drawing.Size(90, 20);
			rd_HighCam.TabIndex = 2;
			rd_HighCam.Text = "高清相机";
			rd_HighCam.UseVisualStyleBackColor = true;
			checkBox_ChipBoundary.AutoSize = true;
			checkBox_ChipBoundary.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_ChipBoundary.ForeColor = System.Drawing.Color.Black;
			checkBox_ChipBoundary.Location = new System.Drawing.Point(8, 7);
			checkBox_ChipBoundary.Name = "checkBox_ChipBoundary";
			checkBox_ChipBoundary.Size = new System.Drawing.Size(58, 19);
			checkBox_ChipBoundary.TabIndex = 162;
			checkBox_ChipBoundary.Text = "方框";
			checkBox_ChipBoundary.UseVisualStyleBackColor = false;
			checkBox_ChipBoundary.CheckedChanged += new System.EventHandler(checkBox_ChipBoundary_CheckedChanged);
			panel_za.Controls.Add(label_XY_name);
			panel_za.Controls.Add(lbv_xy);
			panel_za.Location = new System.Drawing.Point(2, 341);
			panel_za.Name = "panel_za";
			panel_za.Size = new System.Drawing.Size(550, 57);
			panel_za.TabIndex = 157;
			label_XY_name.AutoSize = true;
			label_XY_name.Font = new System.Drawing.Font("黑体", 11f);
			label_XY_name.ForeColor = System.Drawing.Color.Black;
			label_XY_name.Location = new System.Drawing.Point(488, 1);
			label_XY_name.Name = "label_XY_name";
			label_XY_name.Size = new System.Drawing.Size(55, 15);
			label_XY_name.TabIndex = 0;
			label_XY_name.Text = "XY坐标";
			label_XY_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lbv_xy.Font = new System.Drawing.Font("黑体", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			lbv_xy.ForeColor = System.Drawing.Color.Black;
			lbv_xy.Location = new System.Drawing.Point(479, 20);
			lbv_xy.Name = "lbv_xy";
			lbv_xy.Size = new System.Drawing.Size(70, 40);
			lbv_xy.TabIndex = 160;
			lbv_xy.Text = "X10000\r\nY20000";
			lbv_xy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_usrOperation.Controls.Add(panel_boradoperation);
			panel_usrOperation.Controls.Add(panel_movePara);
			panel_usrOperation.Controls.Add(panel56);
			panel_usrOperation.Location = new System.Drawing.Point(1, 99);
			panel_usrOperation.Name = "panel_usrOperation";
			panel_usrOperation.Size = new System.Drawing.Size(563, 277);
			panel_usrOperation.TabIndex = 159;
			panel_boradoperation.Controls.Add(panel_inboard_section);
			panel_boradoperation.Controls.Add(button_PCBAddWidth);
			panel_boradoperation.Controls.Add(pictureBox_VisualTest);
			panel_boradoperation.Controls.Add(button_BoardIn);
			panel_boradoperation.Controls.Add(button_PCBReduceWidth);
			panel_boradoperation.Controls.Add(button_BoardOut);
			panel_boradoperation.Controls.Add(button_VacuunOffAll);
			panel_boradoperation.Controls.Add(button_BoardFix);
			panel_boradoperation.Controls.Add(button_FeederOffAll);
			panel_boradoperation.Controls.Add(button_VacuumOnOff);
			panel_boradoperation.Controls.Add(button_BoardRelease);
			panel_boradoperation.Location = new System.Drawing.Point(305, 0);
			panel_boradoperation.Name = "panel_boradoperation";
			panel_boradoperation.Size = new System.Drawing.Size(248, 148);
			panel_boradoperation.TabIndex = 167;
			panel_inboard_section.BackColor = System.Drawing.Color.White;
			panel_inboard_section.Controls.Add(radioButton2);
			panel_inboard_section.Controls.Add(radioButton1);
			panel_inboard_section.Location = new System.Drawing.Point(157, 0);
			panel_inboard_section.Name = "panel_inboard_section";
			panel_inboard_section.Size = new System.Drawing.Size(82, 57);
			panel_inboard_section.TabIndex = 4;
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(3, 20);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(60, 18);
			radioButton2.TabIndex = 0;
			radioButton2.TabStop = true;
			radioButton2.Text = "进段2";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton2.CheckedChanged += new System.EventHandler(radioButton_inboard_section);
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(3, 1);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(60, 18);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "进段1";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton1.CheckedChanged += new System.EventHandler(radioButton_inboard_section);
			pictureBox_VisualTest.BackColor = System.Drawing.Color.Gray;
			pictureBox_VisualTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			pictureBox_VisualTest.Location = new System.Drawing.Point(159, 63);
			pictureBox_VisualTest.Name = "pictureBox_VisualTest";
			pictureBox_VisualTest.Size = new System.Drawing.Size(80, 80);
			pictureBox_VisualTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_VisualTest.TabIndex = 172;
			pictureBox_VisualTest.TabStop = false;
			pictureBox_VisualTest.Click += new System.EventHandler(pictureBox_VisualTest_Click);
			panel_movePara.Controls.Add(cnButton_trackpara);
			panel_movePara.Controls.Add(lb_speed1);
			panel_movePara.Controls.Add(lb_speed3);
			panel_movePara.Controls.Add(panel3);
			panel_movePara.Controls.Add(lb_speed2);
			panel_movePara.Controls.Add(lb_speed0);
			panel_movePara.Controls.Add(trb_railspeed);
			panel_movePara.Controls.Add(lbv_railspeed);
			panel_movePara.Controls.Add(trb_aspeed);
			panel_movePara.Controls.Add(lbv_xyspeed);
			panel_movePara.Controls.Add(trb_zspeed);
			panel_movePara.Controls.Add(lbv_aspeed);
			panel_movePara.Controls.Add(trb_xyspeed);
			panel_movePara.Controls.Add(lbv_zspeed);
			panel_movePara.Controls.Add(nud_railstep);
			panel_movePara.Controls.Add(nud_zstep);
			panel_movePara.Controls.Add(nud_xystep);
			panel_movePara.Controls.Add(lb_zstep);
			panel_movePara.Controls.Add(lb_boardstep);
			panel_movePara.Controls.Add(nud_astep);
			panel_movePara.Controls.Add(lb_xystep);
			panel_movePara.Controls.Add(lb_astep);
			panel_movePara.Location = new System.Drawing.Point(4, 147);
			panel_movePara.Name = "panel_movePara";
			panel_movePara.Size = new System.Drawing.Size(549, 94);
			panel_movePara.TabIndex = 15;
			lb_speed1.AutoSize = true;
			lb_speed1.Font = new System.Drawing.Font("黑体", 11f);
			lb_speed1.Location = new System.Drawing.Point(137, 72);
			lb_speed1.Name = "lb_speed1";
			lb_speed1.Size = new System.Drawing.Size(39, 15);
			lb_speed1.TabIndex = 4;
			lb_speed1.Text = "速度";
			lb_speed1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lb_speed3.AutoSize = true;
			lb_speed3.Font = new System.Drawing.Font("黑体", 11f);
			lb_speed3.Location = new System.Drawing.Point(137, 49);
			lb_speed3.Name = "lb_speed3";
			lb_speed3.Size = new System.Drawing.Size(39, 15);
			lb_speed3.TabIndex = 15;
			lb_speed3.Text = "速度";
			lb_speed3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			panel3.Controls.Add(checkBox_PreviewLine0);
			panel3.Controls.Add(label_prevline_color);
			panel3.Controls.Add(checkBox_ChipBoundary2);
			panel3.Controls.Add(checkBox_ChipBoundary);
			panel3.Controls.Add(checkBox_PreviewLine);
			panel3.Location = new System.Drawing.Point(302, 45);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(168, 55);
			panel3.TabIndex = 167;
			checkBox_PreviewLine0.AutoSize = true;
			checkBox_PreviewLine0.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_PreviewLine0.Location = new System.Drawing.Point(72, 7);
			checkBox_PreviewLine0.Name = "checkBox_PreviewLine0";
			checkBox_PreviewLine0.Size = new System.Drawing.Size(58, 19);
			checkBox_PreviewLine0.TabIndex = 168;
			checkBox_PreviewLine0.Text = "十字";
			checkBox_PreviewLine0.UseVisualStyleBackColor = true;
			checkBox_PreviewLine0.CheckedChanged += new System.EventHandler(checkBox_PreviewLine0_CheckedChanged);
			lb_speed2.AutoSize = true;
			lb_speed2.Font = new System.Drawing.Font("黑体", 11f);
			lb_speed2.Location = new System.Drawing.Point(137, 26);
			lb_speed2.Name = "lb_speed2";
			lb_speed2.Size = new System.Drawing.Size(39, 15);
			lb_speed2.TabIndex = 15;
			lb_speed2.Text = "速度";
			lb_speed2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lb_speed0.AutoSize = true;
			lb_speed0.Font = new System.Drawing.Font("黑体", 11f);
			lb_speed0.Location = new System.Drawing.Point(137, 5);
			lb_speed0.Name = "lb_speed0";
			lb_speed0.Size = new System.Drawing.Size(39, 15);
			lb_speed0.TabIndex = 0;
			lb_speed0.Text = "速度";
			lb_speed0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			trb_railspeed.Location = new System.Drawing.Point(172, 72);
			trb_railspeed.Maximum = 64;
			trb_railspeed.Minimum = 1;
			trb_railspeed.Name = "trb_railspeed";
			trb_railspeed.Size = new System.Drawing.Size(106, 45);
			trb_railspeed.TabIndex = 5;
			trb_railspeed.TickFrequency = 8;
			trb_railspeed.Value = 28;
			trb_railspeed.Scroll += new System.EventHandler(trb_railspeed_Scroll);
			lbv_railspeed.AutoSize = true;
			lbv_railspeed.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lbv_railspeed.Location = new System.Drawing.Point(275, 73);
			lbv_railspeed.Name = "lbv_railspeed";
			lbv_railspeed.Size = new System.Drawing.Size(24, 16);
			lbv_railspeed.TabIndex = 3;
			lbv_railspeed.Text = "28";
			lbv_railspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			trb_aspeed.Location = new System.Drawing.Point(171, 49);
			trb_aspeed.Maximum = 64;
			trb_aspeed.Minimum = 1;
			trb_aspeed.Name = "trb_aspeed";
			trb_aspeed.Size = new System.Drawing.Size(106, 45);
			trb_aspeed.TabIndex = 16;
			trb_aspeed.TickFrequency = 8;
			trb_aspeed.Value = 32;
			trb_aspeed.Scroll += new System.EventHandler(trb_aspeed_Scroll);
			lbv_xyspeed.AutoSize = true;
			lbv_xyspeed.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lbv_xyspeed.Location = new System.Drawing.Point(276, 3);
			lbv_xyspeed.Name = "lbv_xyspeed";
			lbv_xyspeed.Size = new System.Drawing.Size(24, 16);
			lbv_xyspeed.TabIndex = 0;
			lbv_xyspeed.Text = "28";
			lbv_xyspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			trb_zspeed.Location = new System.Drawing.Point(171, 25);
			trb_zspeed.Maximum = 64;
			trb_zspeed.Minimum = 1;
			trb_zspeed.Name = "trb_zspeed";
			trb_zspeed.Size = new System.Drawing.Size(106, 45);
			trb_zspeed.TabIndex = 16;
			trb_zspeed.TickFrequency = 8;
			trb_zspeed.Value = 32;
			trb_zspeed.Scroll += new System.EventHandler(trb_zspeed_Scroll);
			lbv_aspeed.AutoSize = true;
			lbv_aspeed.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lbv_aspeed.Location = new System.Drawing.Point(276, 51);
			lbv_aspeed.Name = "lbv_aspeed";
			lbv_aspeed.Size = new System.Drawing.Size(24, 16);
			lbv_aspeed.TabIndex = 14;
			lbv_aspeed.Text = "32";
			lbv_aspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			trb_xyspeed.Location = new System.Drawing.Point(171, 3);
			trb_xyspeed.Maximum = 64;
			trb_xyspeed.Minimum = 1;
			trb_xyspeed.Name = "trb_xyspeed";
			trb_xyspeed.Size = new System.Drawing.Size(106, 45);
			trb_xyspeed.TabIndex = 2;
			trb_xyspeed.TickFrequency = 8;
			trb_xyspeed.Value = 28;
			trb_xyspeed.Scroll += new System.EventHandler(trb_xyspeed_Scroll);
			lbv_zspeed.AutoSize = true;
			lbv_zspeed.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lbv_zspeed.Location = new System.Drawing.Point(276, 26);
			lbv_zspeed.Name = "lbv_zspeed";
			lbv_zspeed.Size = new System.Drawing.Size(24, 16);
			lbv_zspeed.TabIndex = 14;
			lbv_zspeed.Text = "32";
			lbv_zspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nud_railstep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			nud_railstep.Font = new System.Drawing.Font("楷体", 11f);
			nud_railstep.Location = new System.Drawing.Point(73, 70);
			nud_railstep.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nud_railstep.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_railstep.Name = "nud_railstep";
			nud_railstep.Size = new System.Drawing.Size(61, 20);
			nud_railstep.TabIndex = 1;
			nud_railstep.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nud_railstep.ValueChanged += new System.EventHandler(nud_railstep_ValueChanged);
			nud_zstep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			nud_zstep.Font = new System.Drawing.Font("楷体", 11f);
			nud_zstep.Location = new System.Drawing.Point(73, 26);
			nud_zstep.Maximum = new decimal(new int[4] { 5000, 0, 0, 0 });
			nud_zstep.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_zstep.Name = "nud_zstep";
			nud_zstep.Size = new System.Drawing.Size(61, 20);
			nud_zstep.TabIndex = 1;
			nud_zstep.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_zstep.ValueChanged += new System.EventHandler(nud_zstep_ValueChanged);
			nud_xystep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			nud_xystep.Font = new System.Drawing.Font("楷体", 11f);
			nud_xystep.Location = new System.Drawing.Point(73, 4);
			nud_xystep.Maximum = new decimal(new int[4] { 50000, 0, 0, 0 });
			nud_xystep.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_xystep.Name = "nud_xystep";
			nud_xystep.Size = new System.Drawing.Size(61, 20);
			nud_xystep.TabIndex = 1;
			nud_xystep.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			nud_xystep.ValueChanged += new System.EventHandler(nud_xystep_ValueChanged);
			lb_zstep.Font = new System.Drawing.Font("黑体", 11f);
			lb_zstep.Location = new System.Drawing.Point(1, 23);
			lb_zstep.Name = "lb_zstep";
			lb_zstep.Size = new System.Drawing.Size(71, 22);
			lb_zstep.TabIndex = 0;
			lb_zstep.Text = "Z轴步距";
			lb_zstep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lb_zstep.Click += new System.EventHandler(button_defaultxyz_Click);
			lb_boardstep.Font = new System.Drawing.Font("黑体", 11f);
			lb_boardstep.Location = new System.Drawing.Point(2, 69);
			lb_boardstep.Name = "lb_boardstep";
			lb_boardstep.Size = new System.Drawing.Size(71, 22);
			lb_boardstep.TabIndex = 0;
			lb_boardstep.Text = "轨道步距";
			lb_boardstep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lb_boardstep.Click += new System.EventHandler(button_defaultxyz_Click);
			nud_astep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			nud_astep.DecimalPlaces = 2;
			nud_astep.Font = new System.Drawing.Font("楷体", 11f);
			nud_astep.Increment = new decimal(new int[4] { 10, 0, 0, 131072 });
			nud_astep.Location = new System.Drawing.Point(73, 48);
			nud_astep.Maximum = new decimal(new int[4] { 180, 0, 0, 0 });
			nud_astep.Minimum = new decimal(new int[4] { 180, 0, 0, -2147483648 });
			nud_astep.Name = "nud_astep";
			nud_astep.Size = new System.Drawing.Size(61, 20);
			nud_astep.TabIndex = 1;
			nud_astep.Value = new decimal(new int[4] { 10, 0, 0, 131072 });
			nud_astep.ValueChanged += new System.EventHandler(nud_astep_ValueChanged);
			lb_xystep.Font = new System.Drawing.Font("黑体", 11f);
			lb_xystep.Location = new System.Drawing.Point(1, 1);
			lb_xystep.Name = "lb_xystep";
			lb_xystep.Size = new System.Drawing.Size(71, 22);
			lb_xystep.TabIndex = 0;
			lb_xystep.Text = "XY轴步距";
			lb_xystep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lb_xystep.Click += new System.EventHandler(button_defaultxyz_Click);
			lb_astep.Font = new System.Drawing.Font("黑体", 11f);
			lb_astep.Location = new System.Drawing.Point(1, 46);
			lb_astep.Name = "lb_astep";
			lb_astep.Size = new System.Drawing.Size(71, 22);
			lb_astep.TabIndex = 0;
			lb_astep.Text = "A轴步距";
			lb_astep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lb_astep.Click += new System.EventHandler(button_defaultxyz_Click);
			panel56.Controls.Add(bt_back);
			panel56.Controls.Add(bt_up);
			panel56.Controls.Add(bt_left);
			panel56.Controls.Add(bt_down);
			panel56.Controls.Add(bt_reset);
			panel56.Controls.Add(bt_circle);
			panel56.Controls.Add(bt_rightford);
			panel56.Controls.Add(bt_right);
			panel56.Controls.Add(bt_zero);
			panel56.Controls.Add(bt_forward);
			panel56.Controls.Add(bt_leftback);
			panel56.Controls.Add(bt_rightback);
			panel56.Controls.Add(bt_reverse);
			panel56.Controls.Add(bt_leftford);
			panel56.Location = new System.Drawing.Point(-1, -3);
			panel56.Name = "panel56";
			panel56.Size = new System.Drawing.Size(307, 154);
			panel56.TabIndex = 167;
			panel_default_z.Controls.Add(button5);
			panel_default_z.Controls.Add(button6);
			panel_default_z.Controls.Add(button7);
			panel_default_z.Controls.Add(button8);
			panel_default_z.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			panel_default_z.Location = new System.Drawing.Point(1, 29);
			panel_default_z.Name = "panel_default_z";
			panel_default_z.Size = new System.Drawing.Size(208, 26);
			panel_default_z.TabIndex = 21;
			button5.ForeColor = System.Drawing.Color.White;
			button5.Location = new System.Drawing.Point(138, 1);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(45, 23);
			button5.TabIndex = 0;
			button5.Text = "1";
			button5.UseVisualStyleBackColor = false;
			button6.ForeColor = System.Drawing.Color.White;
			button6.Location = new System.Drawing.Point(46, 1);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(45, 23);
			button6.TabIndex = 0;
			button6.Text = "10000";
			button6.UseVisualStyleBackColor = false;
			button7.ForeColor = System.Drawing.Color.White;
			button7.Location = new System.Drawing.Point(91, 1);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(45, 23);
			button7.TabIndex = 0;
			button7.Text = "1";
			button7.UseVisualStyleBackColor = false;
			button8.ForeColor = System.Drawing.Color.White;
			button8.Location = new System.Drawing.Point(0, 1);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(45, 23);
			button8.TabIndex = 0;
			button8.Text = "1";
			button8.UseVisualStyleBackColor = false;
			panel_default_xy.Controls.Add(button4);
			panel_default_xy.Controls.Add(button2);
			panel_default_xy.Controls.Add(button3);
			panel_default_xy.Controls.Add(button1);
			panel_default_xy.Font = new System.Drawing.Font("Arial Narrow", 9f);
			panel_default_xy.Location = new System.Drawing.Point(1, 2);
			panel_default_xy.Name = "panel_default_xy";
			panel_default_xy.Size = new System.Drawing.Size(208, 26);
			panel_default_xy.TabIndex = 21;
			button4.ForeColor = System.Drawing.Color.White;
			button4.Location = new System.Drawing.Point(138, 1);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(45, 23);
			button4.TabIndex = 0;
			button4.Text = "1";
			button4.UseVisualStyleBackColor = false;
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(46, 1);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(45, 23);
			button2.TabIndex = 0;
			button2.Text = "10000";
			button2.UseVisualStyleBackColor = false;
			button3.ForeColor = System.Drawing.Color.White;
			button3.Location = new System.Drawing.Point(91, 1);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(45, 23);
			button3.TabIndex = 0;
			button3.Text = "1";
			button3.UseVisualStyleBackColor = false;
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(0, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(45, 23);
			button1.TabIndex = 0;
			button1.Text = "1";
			button1.UseVisualStyleBackColor = false;
			panel_nozzle.Font = new System.Drawing.Font("黑体", 11.25f);
			panel_nozzle.Location = new System.Drawing.Point(0, 14);
			panel_nozzle.Name = "panel_nozzle";
			panel_nozzle.Size = new System.Drawing.Size(550, 39);
			panel_nozzle.TabIndex = 17;
			tmr_LongMove.Interval = 200;
			tmr_LongMove.Tick += new System.EventHandler(tmr_LongMove_Tick);
			panel_ChipBoundary.BackColor = System.Drawing.Color.DimGray;
			panel_ChipBoundary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_ChipBoundary.Controls.Add(label16);
			panel_ChipBoundary.Controls.Add(label15);
			panel_ChipBoundary.Controls.Add(label_chipboxcolor);
			panel_ChipBoundary.Controls.Add(label_chipbox_h);
			panel_ChipBoundary.Controls.Add(label_chipbox_angle);
			panel_ChipBoundary.Controls.Add(button_close_ChipBoundary);
			panel_ChipBoundary.Controls.Add(label_chipbox_w);
			panel_ChipBoundary.Controls.Add(trackBar_chipbox_h);
			panel_ChipBoundary.Controls.Add(trackBar_chipbox_w);
			panel_ChipBoundary.Controls.Add(trackBar_chipbox_angle);
			panel_ChipBoundary.Location = new System.Drawing.Point(563, 133);
			panel_ChipBoundary.Name = "panel_ChipBoundary";
			panel_ChipBoundary.Size = new System.Drawing.Size(550, 66);
			panel_ChipBoundary.TabIndex = 165;
			panel_ChipBoundary.Visible = false;
			label16.BackColor = System.Drawing.Color.White;
			label16.Location = new System.Drawing.Point(-3, 60);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(556, 10);
			label16.TabIndex = 195;
			label15.BackColor = System.Drawing.Color.White;
			label15.Location = new System.Drawing.Point(-3, -6);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(556, 10);
			label15.TabIndex = 195;
			label_chipboxcolor.BackColor = System.Drawing.Color.Red;
			label_chipboxcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_chipboxcolor.Location = new System.Drawing.Point(487, 36);
			label_chipboxcolor.Name = "label_chipboxcolor";
			label_chipboxcolor.Size = new System.Drawing.Size(22, 22);
			label_chipboxcolor.TabIndex = 164;
			label_chipboxcolor.Click += new System.EventHandler(label_chipboxcolor_Click);
			label_chipbox_h.BackColor = System.Drawing.Color.White;
			label_chipbox_h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_chipbox_h.Font = new System.Drawing.Font("黑体", 11f);
			label_chipbox_h.Location = new System.Drawing.Point(427, 36);
			label_chipbox_h.Name = "label_chipbox_h";
			label_chipbox_h.Size = new System.Drawing.Size(58, 22);
			label_chipbox_h.TabIndex = 2;
			label_chipbox_h.Tag = "h";
			label_chipbox_h.Text = "H:653";
			label_chipbox_h.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_chipbox_h.Click += new System.EventHandler(label_chipbox_w_Click);
			label_chipbox_angle.BackColor = System.Drawing.Color.White;
			label_chipbox_angle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_chipbox_angle.Font = new System.Drawing.Font("黑体", 11f);
			label_chipbox_angle.Location = new System.Drawing.Point(426, 9);
			label_chipbox_angle.Name = "label_chipbox_angle";
			label_chipbox_angle.Size = new System.Drawing.Size(83, 22);
			label_chipbox_angle.TabIndex = 163;
			label_chipbox_angle.Text = "120.15°";
			label_chipbox_angle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_chipbox_angle.Click += new System.EventHandler(label_chipbox_angle_Click);
			label_chipbox_w.BackColor = System.Drawing.Color.White;
			label_chipbox_w.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_chipbox_w.Font = new System.Drawing.Font("黑体", 11f);
			label_chipbox_w.Location = new System.Drawing.Point(201, 34);
			label_chipbox_w.Name = "label_chipbox_w";
			label_chipbox_w.Size = new System.Drawing.Size(60, 22);
			label_chipbox_w.TabIndex = 1;
			label_chipbox_w.Tag = "w";
			label_chipbox_w.Text = "W:123";
			label_chipbox_w.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_chipbox_w.Click += new System.EventHandler(label_chipbox_w_Click);
			trackBar_chipbox_h.Location = new System.Drawing.Point(258, 37);
			trackBar_chipbox_h.Maximum = 401;
			trackBar_chipbox_h.Minimum = 9;
			trackBar_chipbox_h.Name = "trackBar_chipbox_h";
			trackBar_chipbox_h.Size = new System.Drawing.Size(170, 45);
			trackBar_chipbox_h.TabIndex = 0;
			trackBar_chipbox_h.Tag = "h";
			trackBar_chipbox_h.TickFrequency = 10;
			trackBar_chipbox_h.Value = 80;
			trackBar_chipbox_h.Scroll += new System.EventHandler(trackBar_chipbox_w_Scroll);
			trackBar_chipbox_w.Location = new System.Drawing.Point(2, 34);
			trackBar_chipbox_w.Maximum = 401;
			trackBar_chipbox_w.Minimum = 9;
			trackBar_chipbox_w.Name = "trackBar_chipbox_w";
			trackBar_chipbox_w.Size = new System.Drawing.Size(203, 45);
			trackBar_chipbox_w.TabIndex = 0;
			trackBar_chipbox_w.Tag = "w";
			trackBar_chipbox_w.TickFrequency = 10;
			trackBar_chipbox_w.Value = 100;
			trackBar_chipbox_w.Scroll += new System.EventHandler(trackBar_chipbox_w_Scroll);
			trackBar_chipbox_angle.Location = new System.Drawing.Point(2, 11);
			trackBar_chipbox_angle.Maximum = 18000;
			trackBar_chipbox_angle.Minimum = -18000;
			trackBar_chipbox_angle.Name = "trackBar_chipbox_angle";
			trackBar_chipbox_angle.Size = new System.Drawing.Size(426, 45);
			trackBar_chipbox_angle.TabIndex = 0;
			trackBar_chipbox_angle.TickFrequency = 1000;
			trackBar_chipbox_angle.Scroll += new System.EventHandler(trackBar_chipbox_angle_Scroll);
			panel_ChipBoundary2.BackColor = System.Drawing.Color.DimGray;
			panel_ChipBoundary2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_ChipBoundary2.Controls.Add(label18);
			panel_ChipBoundary2.Controls.Add(label_chipbox2color);
			panel_ChipBoundary2.Controls.Add(label17);
			panel_ChipBoundary2.Controls.Add(label_boundary2);
			panel_ChipBoundary2.Controls.Add(button_close_ChipBoundary2);
			panel_ChipBoundary2.Controls.Add(label211);
			panel_ChipBoundary2.Controls.Add(trackBar_boundary2);
			panel_ChipBoundary2.Location = new System.Drawing.Point(563, 216);
			panel_ChipBoundary2.Name = "panel_ChipBoundary2";
			panel_ChipBoundary2.Size = new System.Drawing.Size(550, 66);
			panel_ChipBoundary2.TabIndex = 164;
			label18.BackColor = System.Drawing.Color.White;
			label18.Location = new System.Drawing.Point(-3, 60);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(556, 10);
			label18.TabIndex = 195;
			label_chipbox2color.BackColor = System.Drawing.Color.Red;
			label_chipbox2color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_chipbox2color.Location = new System.Drawing.Point(487, 15);
			label_chipbox2color.Name = "label_chipbox2color";
			label_chipbox2color.Size = new System.Drawing.Size(22, 22);
			label_chipbox2color.TabIndex = 164;
			label_chipbox2color.Click += new System.EventHandler(label_chipbox2color_Click);
			label17.BackColor = System.Drawing.Color.White;
			label17.Location = new System.Drawing.Point(-3, -6);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(556, 10);
			label17.TabIndex = 195;
			label_boundary2.BackColor = System.Drawing.Color.White;
			label_boundary2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_boundary2.Font = new System.Drawing.Font("黑体", 11f);
			label_boundary2.Location = new System.Drawing.Point(427, 15);
			label_boundary2.Name = "label_boundary2";
			label_boundary2.Size = new System.Drawing.Size(58, 22);
			label_boundary2.TabIndex = 4;
			label_boundary2.Text = "10";
			label_boundary2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_boundary2.Click += new System.EventHandler(label_boundary2_Click);
			label211.AutoSize = true;
			label211.Font = new System.Drawing.Font("黑体", 11.5f);
			label211.ForeColor = System.Drawing.Color.White;
			label211.Location = new System.Drawing.Point(8, 13);
			label211.Name = "label211";
			label211.Size = new System.Drawing.Size(72, 16);
			label211.TabIndex = 2;
			label211.Text = "圆框半径";
			trackBar_boundary2.Location = new System.Drawing.Point(80, 9);
			trackBar_boundary2.Maximum = 360;
			trackBar_boundary2.Name = "trackBar_boundary2";
			trackBar_boundary2.Size = new System.Drawing.Size(348, 45);
			trackBar_boundary2.TabIndex = 0;
			trackBar_boundary2.TickFrequency = 10;
			trackBar_boundary2.Scroll += new System.EventHandler(trackBar_boundary2_Scroll);
			panel_defaultxyz.BackColor = System.Drawing.Color.DimGray;
			panel_defaultxyz.Controls.Add(label2);
			panel_defaultxyz.Controls.Add(button_defaultxyz_close);
			panel_defaultxyz.Controls.Add(button_defaultxyz_set);
			panel_defaultxyz.Controls.Add(panel_default_xy);
			panel_defaultxyz.Controls.Add(panel_default_z);
			panel_defaultxyz.Location = new System.Drawing.Point(684, 3);
			panel_defaultxyz.Name = "panel_defaultxyz";
			panel_defaultxyz.Size = new System.Drawing.Size(243, 110);
			panel_defaultxyz.TabIndex = 166;
			panel_defaultxyz.Visible = false;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 12.5f);
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(33, 71);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(80, 17);
			label2.TabIndex = 23;
			label2.Text = "快捷步距";
			panel_visual_debug.BackColor = System.Drawing.Color.DimGray;
			panel_visual_debug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_visual_debug.Controls.Add(button_visual_debug_close);
			panel_visual_debug.Controls.Add(button_factory_capture2);
			panel_visual_debug.Controls.Add(button_factory_capture);
			panel_visual_debug.Controls.Add(panel_visualtest_para);
			panel_visual_debug.Controls.Add(label14);
			panel_visual_debug.Controls.Add(label1);
			panel_visual_debug.Location = new System.Drawing.Point(584, 446);
			panel_visual_debug.Name = "panel_visual_debug";
			panel_visual_debug.Size = new System.Drawing.Size(550, 243);
			panel_visual_debug.TabIndex = 167;
			label14.BackColor = System.Drawing.Color.White;
			label14.Location = new System.Drawing.Point(-7, 237);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(556, 42);
			label14.TabIndex = 194;
			label1.BackColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(-3, -6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(556, 10);
			label1.TabIndex = 194;
			panel_visualtest_lw.Controls.Add(numericUpDown_testW);
			panel_visualtest_lw.Controls.Add(numericUpDown_testL);
			panel_visualtest_lw.Controls.Add(label11);
			panel_visualtest_lw.Controls.Add(label213);
			panel_visualtest_lw.Location = new System.Drawing.Point(7, 149);
			panel_visualtest_lw.Name = "panel_visualtest_lw";
			panel_visualtest_lw.Size = new System.Drawing.Size(214, 48);
			panel_visualtest_lw.TabIndex = 193;
			panel_visualtest_lw.Visible = false;
			numericUpDown_testW.BorderStyle = System.Windows.Forms.BorderStyle.None;
			numericUpDown_testW.DecimalPlaces = 2;
			numericUpDown_testW.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_testW.Location = new System.Drawing.Point(89, 25);
			numericUpDown_testW.Name = "numericUpDown_testW";
			numericUpDown_testW.Size = new System.Drawing.Size(91, 19);
			numericUpDown_testW.TabIndex = 191;
			numericUpDown_testW.ValueChanged += new System.EventHandler(numericUpDown_testW_ValueChanged);
			numericUpDown_testL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			numericUpDown_testL.DecimalPlaces = 2;
			numericUpDown_testL.Font = new System.Drawing.Font("黑体", 10.5f);
			numericUpDown_testL.Location = new System.Drawing.Point(89, 1);
			numericUpDown_testL.Name = "numericUpDown_testL";
			numericUpDown_testL.Size = new System.Drawing.Size(91, 19);
			numericUpDown_testL.TabIndex = 192;
			numericUpDown_testL.ValueChanged += new System.EventHandler(numericUpDown_testL_ValueChanged);
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("黑体", 11.25f);
			label11.ForeColor = System.Drawing.Color.White;
			label11.Location = new System.Drawing.Point(3, 28);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(87, 15);
			label11.TabIndex = 190;
			label11.Text = "元件宽(mm)";
			label213.AutoSize = true;
			label213.Font = new System.Drawing.Font("黑体", 11.25f);
			label213.ForeColor = System.Drawing.Color.White;
			label213.Location = new System.Drawing.Point(3, 5);
			label213.Name = "label213";
			label213.Size = new System.Drawing.Size(87, 15);
			label213.TabIndex = 190;
			label213.Text = "元件长(mm)";
			numericUpDown_threshold.BorderStyle = System.Windows.Forms.BorderStyle.None;
			numericUpDown_threshold.Location = new System.Drawing.Point(96, 57);
			numericUpDown_threshold.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			numericUpDown_threshold.Name = "numericUpDown_threshold";
			numericUpDown_threshold.Size = new System.Drawing.Size(53, 19);
			numericUpDown_threshold.TabIndex = 188;
			numericUpDown_threshold.ValueChanged += new System.EventHandler(numericUpDown_threshold_ValueChanged);
			numericUpDown_scanr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			numericUpDown_scanr.Location = new System.Drawing.Point(96, 33);
			numericUpDown_scanr.Maximum = new decimal(new int[4] { 900, 0, 0, 0 });
			numericUpDown_scanr.Name = "numericUpDown_scanr";
			numericUpDown_scanr.Size = new System.Drawing.Size(53, 19);
			numericUpDown_scanr.TabIndex = 188;
			numericUpDown_scanr.ValueChanged += new System.EventHandler(numericUpDown_scanr_ValueChanged);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("黑体", 14f);
			label3.ForeColor = System.Drawing.Color.White;
			label3.Location = new System.Drawing.Point(65, 5);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(89, 19);
			label3.TabIndex = 186;
			label3.Text = "视觉测试";
			textBox_footprintname.Location = new System.Drawing.Point(95, 123);
			textBox_footprintname.Name = "textBox_footprintname";
			textBox_footprintname.Size = new System.Drawing.Size(120, 23);
			textBox_footprintname.TabIndex = 185;
			textBox_footprintname.TextChanged += new System.EventHandler(textBox_footprintname_TextChanged);
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("黑体", 11f);
			label10.ForeColor = System.Drawing.Color.White;
			label10.Location = new System.Drawing.Point(9, 57);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(71, 15);
			label10.TabIndex = 184;
			label10.Text = "视觉阈值";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("黑体", 11f);
			label9.ForeColor = System.Drawing.Color.White;
			label9.Location = new System.Drawing.Point(9, 34);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(71, 15);
			label9.TabIndex = 184;
			label9.Text = "扫描半径";
			label_footprint.AutoSize = true;
			label_footprint.Font = new System.Drawing.Font("黑体", 11f);
			label_footprint.ForeColor = System.Drawing.Color.White;
			label_footprint.Location = new System.Drawing.Point(10, 126);
			label_footprint.Name = "label_footprint";
			label_footprint.Size = new System.Drawing.Size(71, 15);
			label_footprint.TabIndex = 184;
			label_footprint.Text = "元件封装";
			label_visualtype.BackColor = System.Drawing.Color.White;
			label_visualtype.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_visualtype.Font = new System.Drawing.Font("黑体", 11f);
			label_visualtype.Location = new System.Drawing.Point(95, 80);
			label_visualtype.Name = "label_visualtype";
			label_visualtype.Size = new System.Drawing.Size(119, 39);
			label_visualtype.TabIndex = 181;
			label_visualtype.Text = "标准视觉";
			label_visualtype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_visualtype.Click += new System.EventHandler(label_visualtype_Click);
			panel1.Controls.Add(rd_FastCam);
			panel1.Controls.Add(rd_MarkCam);
			panel1.Controls.Add(rd_HighCam);
			panel1.Location = new System.Drawing.Point(933, 6);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(143, 70);
			panel1.TabIndex = 168;
			panel2.Controls.Add(cnButton_deviceCalibration);
			panel2.Controls.Add(label19);
			panel2.Controls.Add(btn_Throw);
			panel2.Controls.Add(button_iLLLED_open);
			panel2.Controls.Add(panel_za);
			panel2.Controls.Add(button_PreviewZoom);
			panel2.Controls.Add(button_MarkCamPara);
			panel2.Controls.Add(button_OpenLed_hcam);
			panel2.Controls.Add(button_OpenLed_fcam);
			panel2.Controls.Add(button_visual_debug);
			panel2.Controls.Add(button_OpenLed);
			panel2.Controls.Add(panel_nozzle);
			panel2.Controls.Add(panel_usrOperation);
			panel2.Location = new System.Drawing.Point(1, 536);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(556, 450);
			panel2.TabIndex = 169;
			label19.BackColor = System.Drawing.Color.White;
			label19.Location = new System.Drawing.Point(-2, 403);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(656, 10);
			label19.TabIndex = 196;
			panel_preview.BackColor = System.Drawing.Color.Black;
			panel_preview.Controls.Add(button_stop_runningvisual);
			panel_preview.Controls.Add(PicBox_Preview);
			panel_preview.Location = new System.Drawing.Point(0, 0);
			panel_preview.Name = "panel_preview";
			panel_preview.Size = new System.Drawing.Size(550, 550);
			panel_preview.TabIndex = 170;
			PicBox_Preview.BackColor = System.Drawing.Color.DimGray;
			PicBox_Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			PicBox_Preview.Cursor = System.Windows.Forms.Cursors.Cross;
			PicBox_Preview.Location = new System.Drawing.Point(0, 0);
			PicBox_Preview.Name = "PicBox_Preview";
			PicBox_Preview.Size = new System.Drawing.Size(550, 550);
			PicBox_Preview.TabIndex = 0;
			PicBox_Preview.TabStop = false;
			panel_markcampara.BackColor = System.Drawing.Color.CadetBlue;
			panel_markcampara.Controls.Add(panel10);
			panel_markcampara.Controls.Add(label20);
			panel_markcampara.Controls.Add(label12);
			panel_markcampara.Controls.Add(button_markcampara_close);
			panel_markcampara.Controls.Add(panel5);
			panel_markcampara.Controls.Add(panel9);
			panel_markcampara.Controls.Add(label8);
			panel_markcampara.Location = new System.Drawing.Point(571, 756);
			panel_markcampara.Name = "panel_markcampara";
			panel_markcampara.Size = new System.Drawing.Size(550, 390);
			panel_markcampara.TabIndex = 174;
			panel10.Controls.Add(label7);
			panel10.Controls.Add(numericUpDown_markStillDelay);
			panel10.Location = new System.Drawing.Point(23, 321);
			panel10.Name = "panel10";
			panel10.Size = new System.Drawing.Size(528, 27);
			panel10.TabIndex = 15;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 10.5f);
			label7.Location = new System.Drawing.Point(3, 9);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(161, 14);
			label7.TabIndex = 1;
			label7.Text = "MARK相机拍照延时（ms）";
			numericUpDown_markStillDelay.BorderStyle = System.Windows.Forms.BorderStyle.None;
			numericUpDown_markStillDelay.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_markStillDelay.Location = new System.Drawing.Point(179, 5);
			numericUpDown_markStillDelay.Maximum = new decimal(new int[4] { 2000, 0, 0, 0 });
			numericUpDown_markStillDelay.Name = "numericUpDown_markStillDelay";
			numericUpDown_markStillDelay.Size = new System.Drawing.Size(59, 19);
			numericUpDown_markStillDelay.TabIndex = 5;
			numericUpDown_markStillDelay.ValueChanged += new System.EventHandler(numericUpDown_markStillDelay_ValueChanged);
			label20.BackColor = System.Drawing.Color.White;
			label20.Location = new System.Drawing.Point(0, 354);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(550, 8);
			label20.TabIndex = 17;
			label12.BackColor = System.Drawing.Color.White;
			label12.Location = new System.Drawing.Point(0, 0);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(550, 4);
			label12.TabIndex = 17;
			panel5.BackColor = System.Drawing.Color.PowderBlue;
			panel5.Location = new System.Drawing.Point(24, 50);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(147, 264);
			panel5.TabIndex = 12;
			panel9.Controls.Add(panel7);
			panel9.Location = new System.Drawing.Point(174, 41);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(351, 309);
			panel9.TabIndex = 14;
			panel7.BackColor = System.Drawing.Color.PowderBlue;
			panel7.Controls.Add(label4);
			panel7.Controls.Add(button_led);
			panel7.Controls.Add(label5);
			panel7.Controls.Add(button_light);
			panel7.Controls.Add(panel6);
			panel7.Controls.Add(label6);
			panel7.Controls.Add(panel8);
			panel7.Location = new System.Drawing.Point(3, 9);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(335, 264);
			panel7.TabIndex = 0;
			label4.Font = new System.Drawing.Font("黑体", 14.25f);
			label4.Location = new System.Drawing.Point(6, 8);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(193, 23);
			label4.TabIndex = 3;
			label4.Text = "label4";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 10.5f);
			label5.Location = new System.Drawing.Point(7, 154);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(91, 14);
			label5.TabIndex = 1;
			label5.Text = "MARK相机设置";
			panel6.Location = new System.Drawing.Point(10, 171);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(314, 90);
			panel6.TabIndex = 0;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("黑体", 10.5f);
			label6.Location = new System.Drawing.Point(5, 44);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(91, 14);
			label6.TabIndex = 1;
			label6.Text = "MARK光源设置";
			panel8.Location = new System.Drawing.Point(8, 61);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(316, 83);
			panel8.TabIndex = 0;
			label8.Font = new System.Drawing.Font("黑体", 14.25f);
			label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			label8.Location = new System.Drawing.Point(11, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(528, 29);
			label8.TabIndex = 13;
			label8.Text = "MARK相机光源调节";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			PicBox_Preview2.BackColor = System.Drawing.Color.DimGray;
			PicBox_Preview2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			PicBox_Preview2.Cursor = System.Windows.Forms.Cursors.Cross;
			PicBox_Preview2.Location = new System.Drawing.Point(563, 3);
			PicBox_Preview2.Name = "PicBox_Preview2";
			PicBox_Preview2.Size = new System.Drawing.Size(115, 124);
			PicBox_Preview2.TabIndex = 0;
			PicBox_Preview2.TabStop = false;
			pictureBox_visualrunning.BackColor = System.Drawing.Color.Gray;
			pictureBox_visualrunning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox_visualrunning.Location = new System.Drawing.Point(563, 257);
			pictureBox_visualrunning.Name = "pictureBox_visualrunning";
			pictureBox_visualrunning.Size = new System.Drawing.Size(550, 550);
			pictureBox_visualrunning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox_visualrunning.TabIndex = 171;
			pictureBox_visualrunning.TabStop = false;
			pictureBox_visualrunning.Visible = false;
			panel_visualtest_para.Controls.Add(panel_visualtest_lw);
			panel_visualtest_para.Controls.Add(numericUpDown_threshold);
			panel_visualtest_para.Controls.Add(numericUpDown_scanr);
			panel_visualtest_para.Controls.Add(label3);
			panel_visualtest_para.Controls.Add(button_cam_set);
			panel_visualtest_para.Controls.Add(textBox_footprintname);
			panel_visualtest_para.Controls.Add(button_visualtest);
			panel_visualtest_para.Controls.Add(label10);
			panel_visualtest_para.Controls.Add(label9);
			panel_visualtest_para.Controls.Add(label_footprint);
			panel_visualtest_para.Controls.Add(label_visualtype);
			panel_visualtest_para.Location = new System.Drawing.Point(282, 5);
			panel_visualtest_para.Name = "panel_visualtest_para";
			panel_visualtest_para.Size = new System.Drawing.Size(236, 209);
			panel_visualtest_para.TabIndex = 195;
			button_close_ChipBoundary2.BackColor = System.Drawing.SystemColors.Control;
			button_close_ChipBoundary2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_ChipBoundary2.CnPressDownColor = System.Drawing.Color.White;
			button_close_ChipBoundary2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			button_close_ChipBoundary2.Location = new System.Drawing.Point(515, 11);
			button_close_ChipBoundary2.Name = "button_close_ChipBoundary2";
			button_close_ChipBoundary2.Size = new System.Drawing.Size(26, 26);
			button_close_ChipBoundary2.TabIndex = 3;
			button_close_ChipBoundary2.Text = "X";
			button_close_ChipBoundary2.UseVisualStyleBackColor = false;
			button_close_ChipBoundary2.Click += new System.EventHandler(button_close_ChipBoundary2_Click);
			button_markcampara_close.BackColor = System.Drawing.SystemColors.Control;
			button_markcampara_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_markcampara_close.CnPressDownColor = System.Drawing.Color.White;
			button_markcampara_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			button_markcampara_close.Location = new System.Drawing.Point(518, 8);
			button_markcampara_close.Name = "button_markcampara_close";
			button_markcampara_close.Size = new System.Drawing.Size(28, 28);
			button_markcampara_close.TabIndex = 16;
			button_markcampara_close.Text = "X";
			button_markcampara_close.UseVisualStyleBackColor = false;
			button_markcampara_close.Click += new System.EventHandler(button_markcampara_close_Click);
			button_led.BackColor = System.Drawing.SystemColors.Control;
			button_led.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_led.CnPressDownColor = System.Drawing.Color.White;
			button_led.Font = new System.Drawing.Font("黑体", 11f);
			button_led.Location = new System.Drawing.Point(278, 7);
			button_led.Name = "button_led";
			button_led.Size = new System.Drawing.Size(46, 44);
			button_led.TabIndex = 4;
			button_led.Text = "MARK\r\n光源";
			button_led.UseVisualStyleBackColor = false;
			button_led.Click += new System.EventHandler(button_led_Click);
			button_light.BackColor = System.Drawing.SystemColors.Control;
			button_light.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_light.CnPressDownColor = System.Drawing.Color.White;
			button_light.Font = new System.Drawing.Font("黑体", 11f);
			button_light.Location = new System.Drawing.Point(226, 7);
			button_light.Name = "button_light";
			button_light.Size = new System.Drawing.Size(46, 44);
			button_light.TabIndex = 4;
			button_light.Text = "MARK\r\n照明";
			button_light.UseVisualStyleBackColor = false;
			button_light.Click += new System.EventHandler(button_light_Click);
			button_visual_debug_close.BackColor = System.Drawing.SystemColors.Control;
			button_visual_debug_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_visual_debug_close.CnPressDownColor = System.Drawing.Color.White;
			button_visual_debug_close.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button_visual_debug_close.Location = new System.Drawing.Point(514, 9);
			button_visual_debug_close.Name = "button_visual_debug_close";
			button_visual_debug_close.Size = new System.Drawing.Size(28, 28);
			button_visual_debug_close.TabIndex = 187;
			button_visual_debug_close.Text = "X";
			button_visual_debug_close.UseVisualStyleBackColor = false;
			button_visual_debug_close.Click += new System.EventHandler(button_visual_debug_close_Click);
			button_factory_capture2.BackColor = System.Drawing.SystemColors.Control;
			button_factory_capture2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_factory_capture2.CnPressDownColor = System.Drawing.Color.White;
			button_factory_capture2.Font = new System.Drawing.Font("黑体", 11f);
			button_factory_capture2.Location = new System.Drawing.Point(377, 206);
			button_factory_capture2.Name = "button_factory_capture2";
			button_factory_capture2.Size = new System.Drawing.Size(120, 28);
			button_factory_capture2.TabIndex = 183;
			button_factory_capture2.Text = "压缩拍照";
			button_factory_capture2.UseVisualStyleBackColor = false;
			button_factory_capture2.Click += new System.EventHandler(button_factory_capture2_Click);
			button_factory_capture.BackColor = System.Drawing.SystemColors.Control;
			button_factory_capture.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_factory_capture.CnPressDownColor = System.Drawing.Color.White;
			button_factory_capture.Font = new System.Drawing.Font("黑体", 11f);
			button_factory_capture.Location = new System.Drawing.Point(292, 206);
			button_factory_capture.Name = "button_factory_capture";
			button_factory_capture.Size = new System.Drawing.Size(76, 28);
			button_factory_capture.TabIndex = 182;
			button_factory_capture.Text = "拍照";
			button_factory_capture.UseVisualStyleBackColor = false;
			button_factory_capture.Click += new System.EventHandler(button_factory_capture_Click);
			button_cam_set.BackColor = System.Drawing.SystemColors.Control;
			button_cam_set.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_cam_set.CnPressDownColor = System.Drawing.Color.White;
			button_cam_set.Font = new System.Drawing.Font("黑体", 11f);
			button_cam_set.Location = new System.Drawing.Point(155, 33);
			button_cam_set.Name = "button_cam_set";
			button_cam_set.Size = new System.Drawing.Size(59, 44);
			button_cam_set.TabIndex = 180;
			button_cam_set.Text = "光源\r\n参数";
			button_cam_set.UseVisualStyleBackColor = false;
			button_cam_set.Click += new System.EventHandler(button_cam_set_Click);
			button_visualtest.BackColor = System.Drawing.SystemColors.Control;
			button_visualtest.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_visualtest.CnPressDownColor = System.Drawing.Color.White;
			button_visualtest.Font = new System.Drawing.Font("黑体", 10.5f);
			button_visualtest.Location = new System.Drawing.Point(10, 80);
			button_visualtest.Name = "button_visualtest";
			button_visualtest.Size = new System.Drawing.Size(76, 40);
			button_visualtest.TabIndex = 179;
			button_visualtest.Text = "识别\r\n测试";
			button_visualtest.UseVisualStyleBackColor = false;
			button_visualtest.Click += new System.EventHandler(button_visualtest_Click);
			button_stop_runningvisual.BackColor = System.Drawing.Color.PeachPuff;
			button_stop_runningvisual.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_stop_runningvisual.CnPressDownColor = System.Drawing.Color.White;
			button_stop_runningvisual.Font = new System.Drawing.Font("黑体", 12.25f);
			button_stop_runningvisual.Location = new System.Drawing.Point(6, 499);
			button_stop_runningvisual.Name = "button_stop_runningvisual";
			button_stop_runningvisual.Size = new System.Drawing.Size(144, 43);
			button_stop_runningvisual.TabIndex = 173;
			button_stop_runningvisual.Text = "停止实时视觉";
			button_stop_runningvisual.UseVisualStyleBackColor = false;
			button_stop_runningvisual.Visible = false;
			cnButton_deviceCalibration.BackColor = System.Drawing.Color.DimGray;
			cnButton_deviceCalibration.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_deviceCalibration.CnPressDownColor = System.Drawing.Color.White;
			cnButton_deviceCalibration.Font = new System.Drawing.Font("黑体", 11f);
			cnButton_deviceCalibration.ForeColor = System.Drawing.Color.White;
			cnButton_deviceCalibration.Location = new System.Drawing.Point(462, 51);
			cnButton_deviceCalibration.Name = "cnButton_deviceCalibration";
			cnButton_deviceCalibration.Size = new System.Drawing.Size(83, 44);
			cnButton_deviceCalibration.TabIndex = 197;
			cnButton_deviceCalibration.Text = "机器校正";
			cnButton_deviceCalibration.UseVisualStyleBackColor = false;
			cnButton_deviceCalibration.Click += new System.EventHandler(cnButton_deviceCalibration_Click);
			btn_Throw.BackColor = System.Drawing.Color.LightGray;
			btn_Throw.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			btn_Throw.CnPressDownColor = System.Drawing.Color.White;
			btn_Throw.Font = new System.Drawing.Font("黑体", 11f);
			btn_Throw.Location = new System.Drawing.Point(309, 51);
			btn_Throw.Name = "btn_Throw";
			btn_Throw.Size = new System.Drawing.Size(55, 44);
			btn_Throw.TabIndex = 2;
			btn_Throw.Text = "抛料";
			btn_Throw.UseVisualStyleBackColor = false;
			btn_Throw.Click += new System.EventHandler(btn_Throw_Click);
			button_iLLLED_open.BackColor = System.Drawing.Color.DarkGray;
			button_iLLLED_open.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_iLLLED_open.CnPressDownColor = System.Drawing.Color.White;
			button_iLLLED_open.Font = new System.Drawing.Font("黑体", 11f);
			button_iLLLED_open.ForeColor = System.Drawing.SystemColors.ControlText;
			button_iLLLED_open.Location = new System.Drawing.Point(51, 51);
			button_iLLLED_open.Name = "button_iLLLED_open";
			button_iLLLED_open.Size = new System.Drawing.Size(46, 44);
			button_iLLLED_open.TabIndex = 12;
			button_iLLLED_open.Text = "MARK\r\n照明";
			button_iLLLED_open.UseVisualStyleBackColor = false;
			button_iLLLED_open.Click += new System.EventHandler(button_iLLLED_open_Click);
			button_PreviewZoom.BackColor = System.Drawing.Color.DarkGray;
			button_PreviewZoom.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PreviewZoom.CnPressDownColor = System.Drawing.Color.White;
			button_PreviewZoom.Font = new System.Drawing.Font("黑体", 11f);
			button_PreviewZoom.Location = new System.Drawing.Point(255, 51);
			button_PreviewZoom.Name = "button_PreviewZoom";
			button_PreviewZoom.Size = new System.Drawing.Size(46, 44);
			button_PreviewZoom.TabIndex = 166;
			button_PreviewZoom.Text = "Zoom\r\nx2";
			button_PreviewZoom.UseVisualStyleBackColor = false;
			button_PreviewZoom.Click += new System.EventHandler(button_PreviewZoom_Click);
			button_MarkCamPara.BackColor = System.Drawing.Color.LightGray;
			button_MarkCamPara.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_MarkCamPara.CnPressDownColor = System.Drawing.Color.White;
			button_MarkCamPara.Font = new System.Drawing.Font("黑体", 11f);
			button_MarkCamPara.Location = new System.Drawing.Point(2, 51);
			button_MarkCamPara.Name = "button_MarkCamPara";
			button_MarkCamPara.Size = new System.Drawing.Size(46, 44);
			button_MarkCamPara.TabIndex = 164;
			button_MarkCamPara.Text = "MARK\r\n参数";
			button_MarkCamPara.UseVisualStyleBackColor = false;
			button_MarkCamPara.Click += new System.EventHandler(button_MarkCamPara_Click);
			button_OpenLed_hcam.BackColor = System.Drawing.Color.DarkGray;
			button_OpenLed_hcam.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_OpenLed_hcam.CnPressDownColor = System.Drawing.Color.White;
			button_OpenLed_hcam.Font = new System.Drawing.Font("黑体", 11f);
			button_OpenLed_hcam.Location = new System.Drawing.Point(206, 51);
			button_OpenLed_hcam.Name = "button_OpenLed_hcam";
			button_OpenLed_hcam.Size = new System.Drawing.Size(46, 44);
			button_OpenLed_hcam.TabIndex = 0;
			button_OpenLed_hcam.Text = "高相\r\n光源";
			button_OpenLed_hcam.UseVisualStyleBackColor = false;
			button_OpenLed_hcam.Click += new System.EventHandler(button_OpenLed_hcam_Click);
			button_OpenLed_fcam.BackColor = System.Drawing.Color.DarkGray;
			button_OpenLed_fcam.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_OpenLed_fcam.CnPressDownColor = System.Drawing.Color.White;
			button_OpenLed_fcam.Font = new System.Drawing.Font("黑体", 11f);
			button_OpenLed_fcam.Location = new System.Drawing.Point(157, 51);
			button_OpenLed_fcam.Name = "button_OpenLed_fcam";
			button_OpenLed_fcam.Size = new System.Drawing.Size(46, 44);
			button_OpenLed_fcam.TabIndex = 0;
			button_OpenLed_fcam.Text = "快相\r\n光源";
			button_OpenLed_fcam.UseVisualStyleBackColor = false;
			button_OpenLed_fcam.Click += new System.EventHandler(button_OpenLed_fcam_Click);
			button_visual_debug.BackColor = System.Drawing.Color.LightGray;
			button_visual_debug.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_visual_debug.CnPressDownColor = System.Drawing.Color.White;
			button_visual_debug.Font = new System.Drawing.Font("黑体", 11.5f);
			button_visual_debug.Location = new System.Drawing.Point(367, 51);
			button_visual_debug.Name = "button_visual_debug";
			button_visual_debug.Size = new System.Drawing.Size(92, 44);
			button_visual_debug.TabIndex = 23;
			button_visual_debug.Text = "视觉调试";
			button_visual_debug.UseVisualStyleBackColor = false;
			button_visual_debug.Click += new System.EventHandler(button_visual_debug_Click);
			button_OpenLed.BackColor = System.Drawing.Color.DarkGray;
			button_OpenLed.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_OpenLed.CnPressDownColor = System.Drawing.Color.White;
			button_OpenLed.Font = new System.Drawing.Font("黑体", 11f);
			button_OpenLed.ForeColor = System.Drawing.SystemColors.ControlText;
			button_OpenLed.Location = new System.Drawing.Point(100, 51);
			button_OpenLed.Name = "button_OpenLed";
			button_OpenLed.Size = new System.Drawing.Size(46, 44);
			button_OpenLed.TabIndex = 1;
			button_OpenLed.Text = "MARK\r\n光源";
			button_OpenLed.UseVisualStyleBackColor = false;
			button_OpenLed.Click += new System.EventHandler(button_OpenLed_Click);
			button_PCBAddWidth.BackColor = System.Drawing.Color.LightGray;
			button_PCBAddWidth.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBAddWidth.CnPressDownColor = System.Drawing.Color.White;
			button_PCBAddWidth.Font = new System.Drawing.Font("黑体", 11f);
			button_PCBAddWidth.Location = new System.Drawing.Point(3, 72);
			button_PCBAddWidth.Name = "button_PCBAddWidth";
			button_PCBAddWidth.Size = new System.Drawing.Size(55, 34);
			button_PCBAddWidth.TabIndex = 1;
			button_PCBAddWidth.Tag = 0;
			button_PCBAddWidth.Text = "轨道+";
			button_PCBAddWidth.UseVisualStyleBackColor = false;
			button_BoardIn.BackColor = System.Drawing.Color.LightGray;
			button_BoardIn.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_BoardIn.CnPressDownColor = System.Drawing.Color.White;
			button_BoardIn.Font = new System.Drawing.Font("黑体", 11f);
			button_BoardIn.Location = new System.Drawing.Point(61, 0);
			button_BoardIn.Name = "button_BoardIn";
			button_BoardIn.Size = new System.Drawing.Size(92, 34);
			button_BoardIn.TabIndex = 1;
			button_BoardIn.Text = "进板";
			button_BoardIn.UseVisualStyleBackColor = false;
			button_BoardIn.Click += new System.EventHandler(button_BoardIn_Click);
			button_PCBReduceWidth.BackColor = System.Drawing.Color.LightGray;
			button_PCBReduceWidth.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBReduceWidth.CnPressDownColor = System.Drawing.Color.White;
			button_PCBReduceWidth.Font = new System.Drawing.Font("黑体", 11f);
			button_PCBReduceWidth.Location = new System.Drawing.Point(3, 108);
			button_PCBReduceWidth.Name = "button_PCBReduceWidth";
			button_PCBReduceWidth.Size = new System.Drawing.Size(55, 34);
			button_PCBReduceWidth.TabIndex = 1;
			button_PCBReduceWidth.Tag = 1;
			button_PCBReduceWidth.Text = "轨道-";
			button_PCBReduceWidth.UseVisualStyleBackColor = false;
			button_BoardOut.BackColor = System.Drawing.Color.LightGray;
			button_BoardOut.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_BoardOut.CnPressDownColor = System.Drawing.Color.White;
			button_BoardOut.Font = new System.Drawing.Font("黑体", 11f);
			button_BoardOut.Location = new System.Drawing.Point(61, 36);
			button_BoardOut.Name = "button_BoardOut";
			button_BoardOut.Size = new System.Drawing.Size(92, 34);
			button_BoardOut.TabIndex = 1;
			button_BoardOut.Text = "出板";
			button_BoardOut.UseVisualStyleBackColor = false;
			button_BoardOut.Click += new System.EventHandler(button_BoardOut_Click);
			button_VacuunOffAll.BackColor = System.Drawing.Color.LightGray;
			button_VacuunOffAll.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_VacuunOffAll.CnPressDownColor = System.Drawing.Color.White;
			button_VacuunOffAll.Font = new System.Drawing.Font("黑体", 11f);
			button_VacuunOffAll.Location = new System.Drawing.Point(61, 108);
			button_VacuunOffAll.Name = "button_VacuunOffAll";
			button_VacuunOffAll.Size = new System.Drawing.Size(92, 34);
			button_VacuunOffAll.TabIndex = 1;
			button_VacuunOffAll.Text = "全关真空";
			button_VacuunOffAll.UseVisualStyleBackColor = false;
			button_VacuunOffAll.Click += new System.EventHandler(button_VacuunOffAll_Click);
			button_BoardFix.BackColor = System.Drawing.Color.LightGray;
			button_BoardFix.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_BoardFix.CnPressDownColor = System.Drawing.Color.White;
			button_BoardFix.Font = new System.Drawing.Font("黑体", 11f);
			button_BoardFix.Location = new System.Drawing.Point(3, 0);
			button_BoardFix.Name = "button_BoardFix";
			button_BoardFix.Size = new System.Drawing.Size(55, 34);
			button_BoardFix.TabIndex = 1;
			button_BoardFix.Text = "夹板";
			button_BoardFix.UseVisualStyleBackColor = false;
			button_BoardFix.Click += new System.EventHandler(button_BoardFix_Click);
			button_FeederOffAll.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_FeederOffAll.CnPressDownColor = System.Drawing.Color.White;
			button_FeederOffAll.Font = new System.Drawing.Font("黑体", 11f);
			button_FeederOffAll.Location = new System.Drawing.Point(156, 104);
			button_FeederOffAll.Name = "button_FeederOffAll";
			button_FeederOffAll.Size = new System.Drawing.Size(84, 34);
			button_FeederOffAll.TabIndex = 21;
			button_FeederOffAll.Text = "全关飞达";
			button_FeederOffAll.UseVisualStyleBackColor = true;
			button_FeederOffAll.Visible = false;
			button_VacuumOnOff.BackColor = System.Drawing.Color.LightGray;
			button_VacuumOnOff.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_VacuumOnOff.CnPressDownColor = System.Drawing.Color.White;
			button_VacuumOnOff.Font = new System.Drawing.Font("黑体", 11f);
			button_VacuumOnOff.Location = new System.Drawing.Point(61, 72);
			button_VacuumOnOff.Name = "button_VacuumOnOff";
			button_VacuumOnOff.Size = new System.Drawing.Size(92, 34);
			button_VacuumOnOff.TabIndex = 1;
			button_VacuumOnOff.Text = "开真空";
			button_VacuumOnOff.UseVisualStyleBackColor = false;
			button_VacuumOnOff.MouseDown += new System.Windows.Forms.MouseEventHandler(button_VacuumOnOff_MouseDown);
			button_BoardRelease.BackColor = System.Drawing.Color.LightGray;
			button_BoardRelease.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_BoardRelease.CnPressDownColor = System.Drawing.Color.White;
			button_BoardRelease.Font = new System.Drawing.Font("黑体", 11f);
			button_BoardRelease.Location = new System.Drawing.Point(3, 36);
			button_BoardRelease.Name = "button_BoardRelease";
			button_BoardRelease.Size = new System.Drawing.Size(55, 34);
			button_BoardRelease.TabIndex = 1;
			button_BoardRelease.Text = "松板";
			button_BoardRelease.UseVisualStyleBackColor = false;
			button_BoardRelease.Click += new System.EventHandler(button_BoardRelease_Click);
			cnButton_trackpara.BackColor = System.Drawing.Color.DimGray;
			cnButton_trackpara.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_trackpara.CnPressDownColor = System.Drawing.Color.White;
			cnButton_trackpara.Font = new System.Drawing.Font("黑体", 11f);
			cnButton_trackpara.ForeColor = System.Drawing.Color.White;
			cnButton_trackpara.Location = new System.Drawing.Point(304, 1);
			cnButton_trackpara.Name = "cnButton_trackpara";
			cnButton_trackpara.Size = new System.Drawing.Size(150, 44);
			cnButton_trackpara.TabIndex = 168;
			cnButton_trackpara.Text = "轨道设置";
			cnButton_trackpara.UseVisualStyleBackColor = false;
			cnButton_trackpara.Click += new System.EventHandler(cnButton_trackpara_Click);
			bt_back.BackColor = System.Drawing.Color.LightGray;
			bt_back.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_back.CnPressDownColor = System.Drawing.Color.White;
			bt_back.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_back.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			bt_back.Location = new System.Drawing.Point(51, 2);
			bt_back.Name = "bt_back";
			bt_back.Size = new System.Drawing.Size(46, 46);
			bt_back.TabIndex = 0;
			bt_back.Text = "后退";
			bt_back.UseVisualStyleBackColor = false;
			bt_up.BackColor = System.Drawing.Color.LightGray;
			bt_up.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_up.CnPressDownColor = System.Drawing.Color.White;
			bt_up.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_up.Location = new System.Drawing.Point(206, 2);
			bt_up.Name = "bt_up";
			bt_up.Size = new System.Drawing.Size(46, 46);
			bt_up.TabIndex = 0;
			bt_up.Text = "上升";
			bt_up.UseVisualStyleBackColor = false;
			bt_left.BackColor = System.Drawing.Color.LightGray;
			bt_left.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_left.CnPressDownColor = System.Drawing.Color.White;
			bt_left.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_left.Location = new System.Drawing.Point(2, 51);
			bt_left.Name = "bt_left";
			bt_left.Size = new System.Drawing.Size(46, 46);
			bt_left.TabIndex = 0;
			bt_left.Text = "左移";
			bt_left.UseVisualStyleBackColor = false;
			bt_down.BackColor = System.Drawing.Color.LightGray;
			bt_down.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_down.CnPressDownColor = System.Drawing.Color.White;
			bt_down.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_down.Location = new System.Drawing.Point(206, 100);
			bt_down.Name = "bt_down";
			bt_down.Size = new System.Drawing.Size(46, 46);
			bt_down.TabIndex = 0;
			bt_down.Text = "下降";
			bt_down.UseVisualStyleBackColor = false;
			bt_reset.BackColor = System.Drawing.Color.LightGray;
			bt_reset.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_reset.CnPressDownColor = System.Drawing.Color.White;
			bt_reset.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_reset.Location = new System.Drawing.Point(51, 51);
			bt_reset.Name = "bt_reset";
			bt_reset.Size = new System.Drawing.Size(46, 46);
			bt_reset.TabIndex = 0;
			bt_reset.Text = "复位";
			bt_reset.UseVisualStyleBackColor = false;
			bt_reset.Click += new System.EventHandler(bt_reset_Click);
			bt_circle.BackColor = System.Drawing.Color.LightGray;
			bt_circle.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_circle.CnPressDownColor = System.Drawing.Color.White;
			bt_circle.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_circle.Location = new System.Drawing.Point(255, 51);
			bt_circle.Name = "bt_circle";
			bt_circle.Size = new System.Drawing.Size(46, 46);
			bt_circle.TabIndex = 0;
			bt_circle.Text = "正转";
			bt_circle.UseVisualStyleBackColor = false;
			bt_rightford.BackColor = System.Drawing.Color.LightGray;
			bt_rightford.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_rightford.CnPressDownColor = System.Drawing.Color.White;
			bt_rightford.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			bt_rightford.Location = new System.Drawing.Point(100, 100);
			bt_rightford.Name = "bt_rightford";
			bt_rightford.Size = new System.Drawing.Size(46, 46);
			bt_rightford.TabIndex = 0;
			bt_rightford.Text = "↘";
			bt_rightford.UseVisualStyleBackColor = false;
			bt_right.BackColor = System.Drawing.Color.LightGray;
			bt_right.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_right.CnPressDownColor = System.Drawing.Color.White;
			bt_right.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_right.Location = new System.Drawing.Point(100, 51);
			bt_right.Name = "bt_right";
			bt_right.Size = new System.Drawing.Size(46, 46);
			bt_right.TabIndex = 0;
			bt_right.Text = "右移";
			bt_right.UseVisualStyleBackColor = false;
			bt_zero.BackColor = System.Drawing.Color.LightGray;
			bt_zero.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_zero.CnPressDownColor = System.Drawing.Color.White;
			bt_zero.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_zero.Location = new System.Drawing.Point(206, 51);
			bt_zero.Name = "bt_zero";
			bt_zero.Size = new System.Drawing.Size(46, 46);
			bt_zero.TabIndex = 0;
			bt_zero.Text = "归零";
			bt_zero.UseVisualStyleBackColor = false;
			bt_zero.Click += new System.EventHandler(bt_zero_Click);
			bt_forward.BackColor = System.Drawing.Color.LightGray;
			bt_forward.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_forward.CnPressDownColor = System.Drawing.Color.White;
			bt_forward.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_forward.Location = new System.Drawing.Point(51, 100);
			bt_forward.Name = "bt_forward";
			bt_forward.Size = new System.Drawing.Size(46, 46);
			bt_forward.TabIndex = 0;
			bt_forward.Text = "前进";
			bt_forward.UseVisualStyleBackColor = false;
			bt_leftback.BackColor = System.Drawing.Color.LightGray;
			bt_leftback.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_leftback.CnPressDownColor = System.Drawing.Color.White;
			bt_leftback.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			bt_leftback.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			bt_leftback.Location = new System.Drawing.Point(2, 2);
			bt_leftback.Name = "bt_leftback";
			bt_leftback.Size = new System.Drawing.Size(46, 46);
			bt_leftback.TabIndex = 0;
			bt_leftback.Text = "↖";
			bt_leftback.UseVisualStyleBackColor = false;
			bt_rightback.BackColor = System.Drawing.Color.LightGray;
			bt_rightback.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_rightback.CnPressDownColor = System.Drawing.Color.White;
			bt_rightback.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			bt_rightback.Location = new System.Drawing.Point(100, 2);
			bt_rightback.Name = "bt_rightback";
			bt_rightback.Size = new System.Drawing.Size(46, 46);
			bt_rightback.TabIndex = 0;
			bt_rightback.Text = "↗";
			bt_rightback.UseVisualStyleBackColor = false;
			bt_reverse.BackColor = System.Drawing.Color.LightGray;
			bt_reverse.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_reverse.CnPressDownColor = System.Drawing.Color.White;
			bt_reverse.Font = new System.Drawing.Font("黑体", 11.25f);
			bt_reverse.Location = new System.Drawing.Point(157, 51);
			bt_reverse.Name = "bt_reverse";
			bt_reverse.Size = new System.Drawing.Size(46, 46);
			bt_reverse.TabIndex = 0;
			bt_reverse.Text = "反转";
			bt_reverse.UseVisualStyleBackColor = false;
			bt_leftford.BackColor = System.Drawing.Color.LightGray;
			bt_leftford.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			bt_leftford.CnPressDownColor = System.Drawing.Color.White;
			bt_leftford.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			bt_leftford.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			bt_leftford.Location = new System.Drawing.Point(2, 100);
			bt_leftford.Name = "bt_leftford";
			bt_leftford.Size = new System.Drawing.Size(46, 46);
			bt_leftford.TabIndex = 0;
			bt_leftford.Text = "↙";
			bt_leftford.UseVisualStyleBackColor = false;
			button_defaultxyz_close.BackColor = System.Drawing.Color.White;
			button_defaultxyz_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_defaultxyz_close.CnPressDownColor = System.Drawing.Color.White;
			button_defaultxyz_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_defaultxyz_close.Location = new System.Drawing.Point(211, 3);
			button_defaultxyz_close.Name = "button_defaultxyz_close";
			button_defaultxyz_close.Size = new System.Drawing.Size(25, 23);
			button_defaultxyz_close.TabIndex = 22;
			button_defaultxyz_close.Text = "X";
			button_defaultxyz_close.UseVisualStyleBackColor = false;
			button_defaultxyz_close.Click += new System.EventHandler(button_defaultxyz_close_Click);
			button_defaultxyz_set.BackColor = System.Drawing.Color.White;
			button_defaultxyz_set.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_defaultxyz_set.CnPressDownColor = System.Drawing.Color.White;
			button_defaultxyz_set.Location = new System.Drawing.Point(139, 59);
			button_defaultxyz_set.Name = "button_defaultxyz_set";
			button_defaultxyz_set.Size = new System.Drawing.Size(45, 39);
			button_defaultxyz_set.TabIndex = 0;
			button_defaultxyz_set.Text = "设置";
			button_defaultxyz_set.UseVisualStyleBackColor = false;
			button_defaultxyz_set.Click += new System.EventHandler(button_defaultxyz_set_Click);
			button_close_ChipBoundary.BackColor = System.Drawing.SystemColors.Control;
			button_close_ChipBoundary.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_ChipBoundary.CnPressDownColor = System.Drawing.Color.White;
			button_close_ChipBoundary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			button_close_ChipBoundary.Location = new System.Drawing.Point(515, 19);
			button_close_ChipBoundary.Name = "button_close_ChipBoundary";
			button_close_ChipBoundary.Size = new System.Drawing.Size(26, 26);
			button_close_ChipBoundary.TabIndex = 162;
			button_close_ChipBoundary.Text = "X";
			button_close_ChipBoundary.UseVisualStyleBackColor = false;
			button_close_ChipBoundary.Click += new System.EventHandler(button_close_ChipBoundary_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(panel_ChipBoundary2);
			base.Controls.Add(panel_markcampara);
			base.Controls.Add(PicBox_Preview2);
			base.Controls.Add(panel_visual_debug);
			base.Controls.Add(panel_cam);
			base.Controls.Add(panel_camOperation);
			base.Controls.Add(panel_preview);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(panel_defaultxyz);
			base.Controls.Add(panel_ChipBoundary);
			base.Controls.Add(pictureBox_visualrunning);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControl_UsrOperation";
			base.Size = new System.Drawing.Size(1416, 1280);
			base.Load += new System.EventHandler(UserControl_UsrOperation_Load);
			panel_za.ResumeLayout(false);
			panel_za.PerformLayout();
			panel_usrOperation.ResumeLayout(false);
			panel_boradoperation.ResumeLayout(false);
			panel_inboard_section.ResumeLayout(false);
			panel_inboard_section.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_VisualTest).EndInit();
			panel_movePara.ResumeLayout(false);
			panel_movePara.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trb_railspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)trb_aspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)trb_zspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)trb_xyspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)nud_railstep).EndInit();
			((System.ComponentModel.ISupportInitialize)nud_zstep).EndInit();
			((System.ComponentModel.ISupportInitialize)nud_xystep).EndInit();
			((System.ComponentModel.ISupportInitialize)nud_astep).EndInit();
			panel56.ResumeLayout(false);
			panel_default_z.ResumeLayout(false);
			panel_default_xy.ResumeLayout(false);
			panel_ChipBoundary.ResumeLayout(false);
			panel_ChipBoundary.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_chipbox_h).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_chipbox_w).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_chipbox_angle).EndInit();
			panel_ChipBoundary2.ResumeLayout(false);
			panel_ChipBoundary2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_boundary2).EndInit();
			panel_defaultxyz.ResumeLayout(false);
			panel_defaultxyz.PerformLayout();
			panel_visual_debug.ResumeLayout(false);
			panel_visualtest_lw.ResumeLayout(false);
			panel_visualtest_lw.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_testW).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_testL).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_threshold).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_scanr).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel_preview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)PicBox_Preview).EndInit();
			panel_markcampara.ResumeLayout(false);
			panel10.ResumeLayout(false);
			panel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_markStillDelay).EndInit();
			panel9.ResumeLayout(false);
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)PicBox_Preview2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox_visualrunning).EndInit();
			panel_visualtest_para.ResumeLayout(false);
			panel_visualtest_para.PerformLayout();
			ResumeLayout(false);
		}

		private void init_visualtest()
		{
			numericUpDown_scanr.Value = USR.mTest_ScanR;
			numericUpDown_threshold.Value = USR.mTest_Threshold;
			numericUpDown_testL.Value = (decimal)USR.mTest_Lmm;
			numericUpDown_testW.Value = (decimal)USR.mTest_Wmm;
			label_visualtype.Text = STR.VISUAL_STR[(int)USR.mTest_VisualType][USR_INIT.mLanguage];
			if (USR.mTest_FootprintName == null)
			{
				USR.mTest_FootprintName = "";
			}
			textBox_footprintname.Text = USR.mTest_FootprintName;
			Label label = label_footprint;
			bool visible = (textBox_footprintname.Visible = USR.mTest_VisualType == VisualType.FootPrint_R);
			label.Visible = visible;
			panel_visualtest_lw.Location = label_footprint.Location;
			panel_visualtest_lw.Visible = USR.mTest_VisualType == VisualType.TranRec1;
		}

		private void __label_visualtype_Click(object sender, EventArgs e)
		{
			Form_VisualTab form_VisualTab = new Form_VisualTab(USR.mTest_VisualType, LoopType.OpenLoop);
			if (form_VisualTab.ShowDialog() == DialogResult.OK)
			{
				USR.mTest_VisualType = form_VisualTab.get_visualtype();
				label_visualtype.Text = STR.VISUAL_STR[(int)USR.mTest_VisualType][USR_INIT.mLanguage];
				Label label = label_footprint;
				bool visible = (textBox_footprintname.Visible = USR.mTest_VisualType == VisualType.FootPrint_R);
				label.Visible = visible;
				panel_visualtest_lw.Visible = USR.mTest_VisualType == VisualType.TranRec1;
				MainForm0.save_FixedData();
			}
		}

		private void __textBox_footprintname_TextChanged(object sender, EventArgs e)
		{
			USR.mTest_FootprintName = textBox_footprintname.Text;
			MainForm0.save_FixedData();
		}

		private void __numericUpDown_scanr_ValueChanged(object sender, EventArgs e)
		{
			USR.mTest_ScanR = (int)numericUpDown_scanr.Value;
			MainForm0.save_FixedData();
		}

		private void __numericUpDown_threshold_ValueChanged(object sender, EventArgs e)
		{
			USR.mTest_Threshold = (int)numericUpDown_threshold.Value;
			MainForm0.save_FixedData();
		}

		private void __numericUpDown_testL_ValueChanged(object sender, EventArgs e)
		{
			USR.mTest_Lmm = (float)numericUpDown_testL.Value;
			MainForm0.save_FixedData();
		}

		private void __numericUpDown_testW_ValueChanged(object sender, EventArgs e)
		{
			USR.mTest_Wmm = (float)numericUpDown_testW.Value;
			MainForm0.save_FixedData();
		}

		private void __button_visualtest_Click(object sender, EventArgs e)
		{
			if (!MainForm0.mMutexBt)
			{
				MainForm0.mMutexBt = true;
				VisualPara s = new VisualPara(USR.mTest_VisualType, USR.mTest_ScanR, USR.mTest_Threshold, USR.mTest_FootprintName, USR.mTest_Lmm, USR.mTest_Wmm);
				if (this.vsplus_visual_test != null)
				{
					this.vsplus_visual_test(s);
				}
			}
		}

		private void __pictureBox_VisualTest_Click(object sender, EventArgs e)
		{
			if (this.vsplus_open_visualshow != null)
			{
				this.vsplus_open_visualshow(mFn);
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

		private void __button_cam_set_Click(object sender, EventArgs e)
		{
			if (this.vsplus_open_fixcampara != null)
			{
				this.vsplus_open_fixcampara((MainForm0.mCurCam[mFn] == CameraType.High) ? 1 : 0);
			}
		}

		public void set_visualtest_para_visable(bool flag)
		{
			panel_visualtest_para.Visible = flag;
		}

		private void init_preview()
		{
			panel_preview.BackColor = Color.YellowGreen;
			mJvs_picboxWidth = 550;
			mJvs_picboxHeight = 550;
			PicBox_Preview.Size = new Size(mJvs_picboxWidth, mJvs_picboxHeight);
			panel_preview.Controls.Add(PicBox_Preview2);
			PicBox_Preview2.Visible = false;
			PicBox_Preview2.Location = new Point(0, 0);
			PicBox_Preview2.BringToFront();
			panel_preview.Controls.Add(PicBoxCSL0);
			PicBoxCSL0.BorderStyle = BorderStyle.FixedSingle;
			PicBoxCSL0.Location = PicBox_Preview.Location;
			PicBoxCSL0.Size = PicBox_Preview.Size;
			PicBoxCSL0.BringToFront();
			PicBoxCSL0.BackColor = USR.mShiziColor;
			PicBoxCSL0.Visible = true;
			PicBoxCSL0.Region = MainForm0.common_getCSLRegion(PicBoxCSL0);
			panel_preview.Controls.Add(PicBoxCSL);
			PicBoxCSL.BorderStyle = BorderStyle.FixedSingle;
			PicBoxCSL.Location = PicBox_Preview.Location;
			PicBoxCSL.Size = PicBox_Preview.Size;
			PicBoxCSL.BringToFront();
			PicBoxCSL.BackColor = USR.mShiziColor;
			PicBoxCSL.Visible = true;
			PicBoxCSL.Region = MainForm0.GetRegionForPicBoxCSL(PicBoxCSL);
			UI_Enable_Preview(en: true);
			pb_r1 = new PictureBox();
			panel_preview.Controls.Add(pb_r1);
			pb_r1.BorderStyle = BorderStyle.FixedSingle;
			pb_r1.Location = PicBox_Preview.Location;
			pb_r1.Size = PicBox_Preview.Size;
			pb_r1.BringToFront();
			pb_r1.BackColor = Color.Yellow;
			pb_r1.Visible = false;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.FillMode = FillMode.Winding;
			graphicsPath.AddRectangle(new Rectangle(0, 275, 550, 1));
			graphicsPath.AddRectangle(new Rectangle(275, 0, 1, 550));
			pb_r1.Region = new Region(graphicsPath);
			pb_r2 = new PictureBox();
			panel_preview.Controls.Add(pb_r2);
			pb_r2.BorderStyle = BorderStyle.FixedSingle;
			pb_r2.Location = PicBox_Preview.Location;
			pb_r2.Size = PicBox_Preview.Size;
			pb_r2.BringToFront();
			pb_r2.BackColor = Color.Red;
			pb_r2.Visible = false;
			pb_r3 = new PictureBox();
			panel_preview.Controls.Add(pb_r3);
			pb_r3.BorderStyle = BorderStyle.FixedSingle;
			pb_r3.Location = PicBox_Preview.Location;
			pb_r3.Size = PicBox_Preview.Size;
			pb_r3.BringToFront();
			pb_r3.BackColor = Color.Red;
			pb_r3.Visible = false;
			panel_preview.Controls.Add(pictureBox_visualrunning);
			pictureBox_visualrunning.Location = PicBox_Preview.Location;
			pictureBox_visualrunning.Size = PicBox_Preview.Size;
			pictureBox_visualrunning.Visible = false;
			pictureBox_visualrunning.BringToFront();
			panel_preview.Controls.Add(button_stop_runningvisual);
			button_stop_runningvisual.Location = new Point(4, 500);
			button_stop_runningvisual.BringToFront();
			PicBox_Preview.BackColor = Color.Black;
		}

		private void PicBox_Preview_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Pea1 = e.Location;
			}
		}

		private void PicBox_Preview_MouseUp(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			if (e.Button == MouseButtons.Left)
			{
				if (MainForm0.mCurCam[mFn] == CameraType.Mark && JK_PrvMove)
				{
					Coordinate coordinate = new Coordinate();
					coordinate.X = (int)((float)(e.X + pictureBox.Location.X - 275) * USR.mMarkCamRatio[0] * MainForm0.mMarkPreviewRatio / (float)((!MainForm0.mIsPreviewZoom) ? 1 : 2) + 0.5f);
					coordinate.Y = (int)((float)(e.Y + pictureBox.Location.Y - 275) * USR.mMarkCamRatio[0] * MainForm0.mMarkPreviewRatio / (float)((!MainForm0.mIsPreviewZoom) ? 1 : 2) + 0.5f);
					Thread thread = new Thread(MainForm0.thd_MoveXYOperate);
					thread.IsBackground = true;
					thread.Start(coordinate);
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				double num = Math.Atan2(e.Y - Pea1.Y, e.X - Pea1.X);
				num = num * 180.0 / Math.PI;
			}
		}

		public void UI_Enable_Preview(bool en)
		{
			if (en)
			{
				PicBoxCSL0.MouseUp += PicBox_Preview_MouseUp;
				PicBoxCSL.MouseUp += PicBox_Preview_MouseUp;
				PicBox_Preview.MouseUp += PicBox_Preview_MouseUp;
				PicBox_Preview.MouseDown += PicBox_Preview_MouseDown;
				PicBox_Preview2.MouseUp += PicBox_Preview_MouseUp;
				PicBox_Preview2.MouseDown += PicBox_Preview_MouseDown;
			}
			else
			{
				PicBoxCSL0.MouseUp -= PicBox_Preview_MouseUp;
				PicBoxCSL.MouseUp -= PicBox_Preview_MouseUp;
				PicBox_Preview.MouseUp -= PicBox_Preview_MouseUp;
				PicBox_Preview.MouseDown -= PicBox_Preview_MouseDown;
				PicBox_Preview2.MouseUp -= PicBox_Preview_MouseUp;
				PicBox_Preview2.MouseDown -= PicBox_Preview_MouseDown;
			}
		}

		private void __button_PreviewZoom_Click(object sender, EventArgs e)
		{
			MainForm0.mIsPreviewZoom = !MainForm0.mIsPreviewZoom;
			if (this.vsplus_reopen_preview != null)
			{
				this.vsplus_reopen_preview(mFn);
			}
			flush_chipbox();
		}

		private void init_misc()
		{
			panel_inboard_section.Controls.Clear();
			inboard_section = 0;
			if (USR_INIT.mInBoard_Mode == 1)
			{
				radioButton_inboard_s = new RadioButton[HW.mSections];
				for (int i = 0; i < HW.mSections; i++)
				{
					RadioButton radioButton = new RadioButton();
					panel_inboard_section.Controls.Add(radioButton);
					radioButton.Location = new Point(0, i * 18);
					radioButton.Text = ((USR_INIT.mLanguage == 2) ? "Inboard " : "进段") + (i + 1);
					radioButton.Tag = i;
					radioButton.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f, FontStyle.Regular);
					radioButton.CheckedChanged += radioButton_inboard_section;
					radioButton_inboard_s[i] = radioButton;
				}
				radioButton_inboard_s[inboard_section].Checked = true;
			}
			set_inboard_mode();
		}

		public void set_inboard_mode()
		{
			if (HW.mIsSanduanshi && MainForm0.USR_INIT.mInBoard_Mode == 1)
			{
				panel_inboard_section.Visible = true;
			}
			else
			{
				panel_inboard_section.Visible = false;
			}
		}

		private void __radioButton_inboard_section(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			int num = (int)radioButton.Tag;
			if (radioButton.Checked)
			{
				inboard_section = num;
				if (MainForm0.USR3B[mFn] != null)
				{
					MainForm0.uc_job[mFn].button_subpcb_sel(inboard_section);
				}
			}
		}

		public void set_inboard_section(int section)
		{
			if (radioButton_inboard_s != null && section >= 0 && section < radioButton_inboard_s.Count())
			{
				radioButton_inboard_s[section].Checked = true;
			}
		}

		private void __button_BoardIn_Click(object sender, EventArgs e)
		{
			if (MainForm0.USR3B == null || MainForm0.uc_job[mFn].loukong_state_confirm())
			{
				int psd = MainForm0.USR[mFn].mTrackSpeed;
				if (HW.mDeviceType == DeviceType.DSQ800_120F)
				{
					psd = MainForm0.USR_INIT.mTrack.speed;
				}
				if (HW.mIsSanduanshi && MainForm0.USR_INIT.mInBoard_Mode == 1)
				{
					MainForm0.mConDevExt[mFn].sendInBoard(mFn, psd, inboard_section, 0);
				}
				else
				{
					MainForm0.mConDevExt[mFn].sendInBoard(mFn, psd, 0);
				}
				MainForm0.mIsBoardFixed = true;
			}
		}

		private void __button_BoardOut_Click(object sender, EventArgs e)
		{
			if (MainForm0.USR3B == null || MainForm0.uc_job[mFn].loukong_state_confirm())
			{
				int b = MainForm0.USR[mFn].mTrackSpeed;
				float mTrackDelay = MainForm0.USR[mFn].mTrackDelay;
				if (HW.mDeviceType == DeviceType.DSQ800_120F)
				{
					b = MainForm0.USR_INIT.mTrack.speed;
				}
				if (this.misc_board_out != null)
				{
					this.misc_board_out(mFn, b, (int)(mTrackDelay * 10f), USR_INIT.mIsBCTEnabled);
				}
				MainForm0.mIsBoardFixed = false;
				if (MainForm0.uc_job != null)
				{
					MainForm0.uc_job[mFn].set_edit(flag: false);
				}
			}
		}

		private void __button_BoardFix_Click(object sender, EventArgs e)
		{
			MainForm0.mIsBoardFixed = true;
			MainForm0.mConDevExt[0].sendexetueplywood(mFn, 1);
		}

		private void __button_BoardRelease_Click(object sender, EventArgs e)
		{
			if (MainForm0.uc_job != null)
			{
				MainForm0.uc_job[mFn].set_edit(flag: false);
			}
			MainForm0.mIsBoardFixed = false;
			MainForm0.mConDevExt[0].sendexetueplywood(mFn, 0);
		}

		private void __button_VacuumOnOff_MouseDown(object sender, MouseEventArgs e)
		{
			int num = MainForm0.mZn[mFn];
			MainForm0.misc_vacc_onoff(mFn, num, (!MainForm0.mIsVacuumOn[mFn][num]) ? 1 : 0);
			string[] array = new string[3] { "关真空", "關真空", "Vacuum Off" };
			string[] array2 = new string[3] { "开真空", "開真空", "Vacuum On" };
			button_VacuumOnOff.Text = (MainForm0.mIsVacuumOn[mFn][num] ? array[USR_INIT.mLanguage] : array2[USR_INIT.mLanguage]);
		}

		private void __button_VacuunOffAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				MainForm0.misc_vacc_onoff(mFn, i, 0);
			}
			button_VacuumOnOff.CnSetPressDown(flag: false);
			string[] array = new string[3] { "开真空", "開真空", "Vacuum On" };
			button_VacuumOnOff.Text = array[USR_INIT.mLanguage];
		}

		private void __btn_Throw_Click(object sender, EventArgs e)
		{
			string[] array = new string[3] { "确定抛料？", "確定拋料?", "Conform to throw?" };
			if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes && !MainForm0.mMutexMoveXYZA)
			{
				MainForm0.mMutexMoveXYZA = true;
				Thread thread = new Thread(MainForm0.thd_Throw);
				thread.IsBackground = true;
				thread.Start(new int_2d(mFn, MainForm0.mZn[mFn]));
			}
		}

		private void init_markcampara()
		{
			if (USR != null && USR.mMarkCamStillDelay >= (int)numericUpDown_markStillDelay.Minimum && USR.mMarkCamStillDelay <= (int)numericUpDown_markStillDelay.Maximum)
			{
				numericUpDown_markStillDelay.Value = USR.mMarkCamStillDelay;
			}
			for (int i = 0; i < 10; i++)
			{
				RadioButton radioButton = new RadioButton();
				panel5.Controls.Add(radioButton);
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
				panel8.Controls.Add(label);
				label.Location = new Point(4, 4 + j * 22);
				label.Size = new Size(60, 22);
				label.Text = STR.MARK_LED_PARA_STR[j][USR_INIT.mLanguage];
				label.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], label.Font.Style);
				TrackBar trackBar = new TrackBar();
				panel8.Controls.Add(trackBar);
				trackBar.Location = new Point(64, 4 + j * 22);
				trackBar.Size = new Size(220, 22);
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
				panel8.Controls.Add(label2);
				label2.Location = new Point(284, 4 + j * 22);
				label2.Size = new Size(60, 22);
				label2.Text = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[j].ToString();
				label_led[j] = label2;
			}
			for (int k = 0; k < 4; k++)
			{
				Label label3 = new Label();
				panel6.Controls.Add(label3);
				label3.Location = new Point(4, 4 + k * 22);
				label3.Size = new Size(60, 22);
				label3.Text = STR.MARK_CAM_PARA_STR[k][USR_INIT.mLanguage];
				label3.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], label3.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], label3.Font.Style);
				TrackBar trackBar2 = new TrackBar();
				panel6.Controls.Add(trackBar2);
				trackBar2.Location = new Point(64, 4 + k * 22);
				trackBar2.Size = new Size(220, 22);
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
				panel6.Controls.Add(label4);
				label4.Location = new Point(284, 4 + k * 22);
				label4.Size = new Size(60, 22);
				label4.Text = USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam[k].ToString();
				label_cam[k] = label4;
			}
			int[] array = (mIsParaIndexChange = new int[2]);
		}

		private void flush_markcampara()
		{
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
				MainForm0.mark_light_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
				MainForm0.mark_led_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
				markcampara_update_markbuttion(USR.mMarkCamParaIndex);
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
				MainForm0.mark_lightlevel_set(mFn, num, USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[num]);
				USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn = true;
				MainForm0.mark_light_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
				if (mIsParaIndexChange[num] != 0)
				{
					USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn = mLightOn;
					MainForm0.mark_light_on_ext(mFn, mLightOn);
					mIsParaIndexChange[0] = 0;
				}
				markcampara_update_markbuttion(USR.mMarkCamParaIndex);
				break;
			case 1:
				MainForm0.mark_lightlevel_set(mFn, num, USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaLed[num]);
				USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn = true;
				MainForm0.mark_led_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
				if (mIsParaIndexChange[num] != 0)
				{
					USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn = mLedOn;
					MainForm0.mark_led_on_ext(mFn, mLedOn);
					mIsParaIndexChange[num] = 0;
				}
				markcampara_update_markbuttion(USR.mMarkCamParaIndex);
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
				MainForm0.set_camera_parameter(HW.mMarkCamItem[mFn].index[0], USR.mMarkCamPara[USR.mMarkCamParaIndex].mParaCam);
			}
		}

		private void __button_MarkCamPara_Click(object sender, EventArgs e)
		{
			panel_markcampara.Location = new Point(0, 583);
			panel_markcampara.Visible = true;
			panel_markcampara.BringToFront();
			MainForm0.mark_light_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
			MainForm0.mark_led_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
			markcampara_update_markbuttion(USR.mMarkCamParaIndex);
		}

		private void __button_markcampara_close_Click(object sender, EventArgs e)
		{
			panel_markcampara.Visible = false;
		}

		public void markcampara_update_markbuttion(int index)
		{
			button_light.CnSetPressDown(USR.mMarkCamPara[index].mLightOn);
			button_led.CnSetPressDown(USR.mMarkCamPara[index].mLedOn);
		}

		private void __button_light_Click(object sender, EventArgs e)
		{
			USR.mIsMarkLightOn = (USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn = !USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
			MainForm0.mark_light_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn);
			markcampara_update_markbuttion(USR.mMarkCamParaIndex);
		}

		private void __button_led_Click(object sender, EventArgs e)
		{
			USR.mIsMarkLedOn = (USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn = !USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
			MainForm0.mark_led_on_ext(mFn, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn);
			markcampara_update_markbuttion(USR.mMarkCamParaIndex);
		}

		private void __numericUpDown_markStillDelay_ValueChanged(object sender, EventArgs e)
		{
			if (USR != null)
			{
				USR.mMarkCamStillDelay = (int)numericUpDown_markStillDelay.Value;
			}
		}

		public UserControl_UsrOperation(int fn, USR_DATA usr)
		{
			InitializeComponent();
			base.Size = new Size(550, 994);
			mFn = fn;
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
			init_zn_nozzle();
			init_move_para();
			init_move();
			init_cam();
			init_chipbox();
			init_misc();
			init_preview();
			init_markcampara();
			init_visualtest();
		}

		private void UserControl_UsrOperation_Load(object sender, EventArgs e)
		{
			MainForm0.common_setButton_PressDownMode(button_iLLLED_open, USR.mIsMarkLightOn, Color.LightGray, Color.Salmon);
			MainForm0.common_setButton_PressDownMode(button_OpenLed, USR.mIsMarkLedOn, Color.LightGray, Color.Salmon);
			MainForm0.common_setButton_PressDownMode(button_OpenLed_fcam, MainForm0.mFastCamLedState[mFn], Color.LightGray, Color.Salmon);
			MainForm0.common_setButton_PressDownMode(button_OpenLed_hcam, MainForm0.mHighCamLedState[mFn], Color.LightGray, Color.Salmon);
			MainForm0.common_setButton_PressDownMode(button_VacuumOnOff, MainForm0.mIsVacuumOn[mFn][MainForm0.mZn[mFn]], Color.LightGray, Color.Salmon);
			MainForm0.common_setButton_PressDownMode(button_PreviewZoom, MainForm0.mIsPreviewZoom, Color.LightGray, Color.Salmon);
			MainForm0.common_setButton_PressDownMode(button_light, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLightOn, Color.LightGray, Color.Salmon);
			MainForm0.common_setButton_PressDownMode(button_led, USR.mMarkCamPara[USR.mMarkCamParaIndex].mLedOn, Color.LightGray, Color.Salmon);
			flush_byZn();
			flush_byCam();
			flush_chipbox();
			flush_markcampara();
		}

		public void flush_byZn()
		{
			int num = MainForm0.mZn[mFn];
			int num2 = MainForm0.mZn_prev[mFn];
			Label obj = lb_zn[num];
			Label obj2 = lbv_zn[num];
			Font font2 = (lbv_an[num].Font = new Font(lbv_zn[num].Font.FontFamily, lbv_zn[num].Font.Size, FontStyle.Bold));
			Font font5 = (obj.Font = (obj2.Font = font2));
			if (num2 != -1)
			{
				Label obj3 = lb_zn[num2];
				Label obj4 = lbv_zn[num2];
				Font font7 = (lbv_an[num2].Font = new Font(lbv_zn[num2].Font.FontFamily, lbv_zn[num2].Font.Size, FontStyle.Regular));
				Font font10 = (obj3.Font = (obj4.Font = font7));
			}
			button_nozzle_flush();
			button_VacuumOnOff.CnSetPressDown(MainForm0.mIsVacuumOn[mFn][num]);
			if (MainForm0.mIsVacuumOn[mFn][num])
			{
				string[] array = new string[3] { "关真空", "關真空", "Vacuum Off" };
				button_VacuumOnOff.Text = array[USR_INIT.mLanguage];
			}
			else
			{
				string[] array2 = new string[3] { "开真空", "開真空", "Vacuum On" };
				button_VacuumOnOff.Text = array2[USR_INIT.mLanguage];
			}
		}

		private void nud_xystep_ValueChanged(object sender, EventArgs e)
		{
			__nud_xystep_ValueChanged(sender, e);
		}

		private void nud_zstep_ValueChanged(object sender, EventArgs e)
		{
			__nud_zstep_ValueChanged(sender, e);
		}

		private void nud_astep_ValueChanged(object sender, EventArgs e)
		{
			__nud_astep_ValueChanged(sender, e);
		}

		private void nud_railstep_ValueChanged(object sender, EventArgs e)
		{
			__nud_railstep_ValueChanged(sender, e);
		}

		private void trb_xyspeed_Scroll(object sender, EventArgs e)
		{
			__trb_xyspeed_Scroll(sender, e);
		}

		private void trb_zspeed_Scroll(object sender, EventArgs e)
		{
			__trb_zspeed_Scroll(sender, e);
		}

		private void trb_aspeed_Scroll(object sender, EventArgs e)
		{
			__trb_aspeed_Scroll(sender, e);
		}

		private void trb_railspeed_Scroll(object sender, EventArgs e)
		{
			__trb_railspeed_Scroll(sender, e);
		}

		private void button_defaultxyz_set_Click(object sender, EventArgs e)
		{
			__button_defaultxyz_set_Click(sender, e);
		}

		private void tmr_LongMove_Tick(object sender, EventArgs e)
		{
			__tmr_LongMove_Tick(sender, e);
		}

		private void bt_reset_Click(object sender, EventArgs e)
		{
			if (this.Reset != null)
			{
				this.Reset(mFn);
			}
		}

		private void bt_zero_Click(object sender, EventArgs e)
		{
			__bt_zero_Click(sender, e);
		}

		private void button_BoardOut_Click(object sender, EventArgs e)
		{
			__button_BoardOut_Click(sender, e);
		}

		private void button_BoardIn_Click(object sender, EventArgs e)
		{
			__button_BoardIn_Click(sender, e);
		}

		private void button_BoardRelease_Click(object sender, EventArgs e)
		{
			__button_BoardRelease_Click(sender, e);
		}

		private void button_BoardFix_Click(object sender, EventArgs e)
		{
			__button_BoardFix_Click(sender, e);
		}

		private void button_VacuumOnOff_MouseDown(object sender, MouseEventArgs e)
		{
			__button_VacuumOnOff_MouseDown(sender, e);
		}

		private void button_VacuunOffAll_Click(object sender, EventArgs e)
		{
			__button_VacuunOffAll_Click(sender, e);
		}

		private void btn_Throw_Click(object sender, EventArgs e)
		{
			__btn_Throw_Click(sender, e);
		}

		private void button_iLLLED_open_Click(object sender, EventArgs e)
		{
			__button_iLLLED_open_Click(sender, e);
		}

		private void button_OpenLed_Click(object sender, EventArgs e)
		{
			__button_OpenLed_Click(sender, e);
		}

		private void button_OpenLed_fcam_Click(object sender, EventArgs e)
		{
			__button_OpenLed_fcam_Click(sender, e);
		}

		private void button_OpenLed_hcam_Click(object sender, EventArgs e)
		{
			__button_OpenLed_hcam_Click(sender, e);
		}

		private void button_ChipBoundary_Click(object sender, EventArgs e)
		{
			panel_ChipBoundary.Visible = true;
			panel_ChipBoundary.BringToFront();
			checkBox_ChipBoundary.Checked = true;
		}

		private void button_ChipBoundary2_Click(object sender, EventArgs e)
		{
			panel_ChipBoundary2.Visible = true;
			panel_ChipBoundary2.BringToFront();
			checkBox_ChipBoundary2.Checked = true;
		}

		private void button_close_ChipBoundary_Click(object sender, EventArgs e)
		{
			panel_ChipBoundary.Visible = false;
		}

		private void button_close_ChipBoundary2_Click(object sender, EventArgs e)
		{
			panel_ChipBoundary2.Visible = false;
		}

		private void checkBox_ChipBoundary2_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_ChipBoundary2_CheckedChanged(sender, e);
		}

		private void trackBar_boundary2_Scroll(object sender, EventArgs e)
		{
			__trackBar_boundary2_Scroll(sender, e);
		}

		private void label_boundary2_Click(object sender, EventArgs e)
		{
			__label_boundary2_Click(sender, e);
		}

		private void checkBox_ChipBoundary_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_ChipBoundary_CheckedChanged(sender, e);
		}

		private void trackBar_chipbox_angle_Scroll(object sender, EventArgs e)
		{
			__trackBar_chipbox_angle_Scroll(sender, e);
		}

		private void label_chipbox_angle_Click(object sender, EventArgs e)
		{
			__label_chipbox_angle_Click(sender, e);
		}

		private void trackBar_chipbox_w_Scroll(object sender, EventArgs e)
		{
			__trackBar_chipbox_w_Scroll(sender, e);
		}

		private void label_chipbox_w_Click(object sender, EventArgs e)
		{
			__label_chipbox_w_Click(sender, e);
		}

		private void button_PreviewZoom_Click(object sender, EventArgs e)
		{
			__button_PreviewZoom_Click(sender, e);
		}

		private void label_chipboxcolor_Click(object sender, EventArgs e)
		{
			__label_chipboxcolor_Click(sender, e);
		}

		private void label_chipbox2color_Click(object sender, EventArgs e)
		{
			__label_chipbox2color_Click(sender, e);
		}

		private void checkBox_PreviewLine_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_PreviewLine_CheckedChanged(sender, e);
		}

		private void checkBox_PreviewLine0_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_PreviewLine0_CheckedChanged(sender, e);
		}

		private void label_prevline_color_Click(object sender, EventArgs e)
		{
			__label_prevline_color_Click(sender, e);
		}

		private void radioButton_inboard_section(object sender, EventArgs e)
		{
			__radioButton_inboard_section(sender, e);
		}

		private void button_MarkCamPara_Click(object sender, EventArgs e)
		{
			__button_MarkCamPara_Click(sender, e);
		}

		private void button_markcampara_close_Click(object sender, EventArgs e)
		{
			__button_markcampara_close_Click(sender, e);
		}

		private void button_light_Click(object sender, EventArgs e)
		{
			__button_light_Click(sender, e);
		}

		private void button_led_Click(object sender, EventArgs e)
		{
			__button_led_Click(sender, e);
		}

		private void numericUpDown_markStillDelay_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_markStillDelay_ValueChanged(sender, e);
		}

		private void label_visualtype_Click(object sender, EventArgs e)
		{
			__label_visualtype_Click(sender, e);
		}

		private void textBox_footprintname_TextChanged(object sender, EventArgs e)
		{
			__textBox_footprintname_TextChanged(sender, e);
		}

		private void button_visualtest_Click(object sender, EventArgs e)
		{
			__button_visualtest_Click(sender, e);
		}

		private void pictureBox_VisualTest_Click(object sender, EventArgs e)
		{
			__pictureBox_VisualTest_Click(sender, e);
		}

		private void numericUpDown_scanr_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_scanr_ValueChanged(sender, e);
		}

		private void numericUpDown_threshold_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_threshold_ValueChanged(sender, e);
		}

		private void numericUpDown_testL_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_testL_ValueChanged(sender, e);
		}

		private void numericUpDown_testW_ValueChanged(object sender, EventArgs e)
		{
			__numericUpDown_testW_ValueChanged(sender, e);
		}

		private void button_factory_capture_Click(object sender, EventArgs e)
		{
			__button_factory_capture_Click(sender, e);
		}

		private void button_factory_capture2_Click(object sender, EventArgs e)
		{
			__button_factory_capture2_Click(sender, e);
		}

		private void button_cam_set_Click(object sender, EventArgs e)
		{
			__button_cam_set_Click(sender, e);
		}

		private void cnButton_trackpara_Click(object sender, EventArgs e)
		{
			trackpara_click();
		}

		public void trackpara_click()
		{
			Form_TrackPara form_TrackPara = new Form_TrackPara();
			if (form_TrackPara.ShowDialog() == DialogResult.OK)
			{
				if (HW.mDeviceType == DeviceType.DSQ800_120F)
				{
					MainForm0.mConDevExt[0].sendTrackDelay((int)(USR_INIT.mTrack.delayL * 10f), (int)(USR_INIT.mTrack.delayM * 10f), (int)(USR_INIT.mTrack.delayR * 10f));
					MainForm0.mConDevExt[0].sendTrackSpeed(10 - USR_INIT.mTrack.speed);
					MainForm0.mConDevExt[0].send_inboard_mode(USR_INIT.mTrack.mode);
				}
				else
				{
					MainForm0.mConDevExt[0].sendTrackSpeed(10 - MainForm0.USR[0].mTrackSpeed);
					MainForm0.mConDevExt[0].sendTrackDelay((int)(MainForm0.USR[0].mTrackDelay * 10f));
				}
			}
		}

		private void button_defaultxyz_Click(object sender, EventArgs e)
		{
			panel_movePara.Controls.Add(panel_defaultxyz);
			panel_defaultxyz.Location = new Point(306, 0);
			panel_defaultxyz.BringToFront();
			panel_defaultxyz.Visible = true;
		}

		private void button_defaultxyz_close_Click(object sender, EventArgs e)
		{
			panel_defaultxyz.Visible = false;
		}

		private void button_visual_debug_Click(object sender, EventArgs e)
		{
			panel_usrOperation.Controls.Add(panel_visual_debug);
			panel_visual_debug.Controls.Add(pictureBox_VisualTest);
			pictureBox_VisualTest.Size = new Size(237, 237);
			pictureBox_VisualTest.Location = new Point(3, 3);
			panel_visual_debug.Location = panel56.Location;
			panel_visual_debug.Visible = true;
			panel_visual_debug.BringToFront();
		}

		private void button_visual_debug_close_Click(object sender, EventArgs e)
		{
			panel_visual_debug.Visible = false;
			pictureBox_VisualTest.Size = new Size(80, 80);
			panel_boradoperation.Controls.Add(pictureBox_VisualTest);
			pictureBox_VisualTest.Location = new Point(159, 63);
		}

		public void set_color(Color cl)
		{
			BackColor = cl;
		}

		public PictureBox get_preview_picturebox()
		{
			return PicBox_Preview;
		}

		public PictureBox get_preview2_picturebox()
		{
			return PicBox_Preview2;
		}

		public PictureBox get_visualrunning_pictureBox()
		{
			return pictureBox_visualrunning;
		}

		public PictureBox get_visualtest_picturebox()
		{
			return pictureBox_VisualTest;
		}

		public CnButton get_stop_visualrunning_button()
		{
			return button_stop_runningvisual;
		}

		public Panel get_preview_panel()
		{
			return panel_preview;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_left,
				str = new string[3] { "左移", "左移", "Left" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_right,
				str = new string[3] { "右移", "右移", "Right" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_forward,
				str = new string[3] { "前进", "前進", "Fwrd" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_back,
				str = new string[3] { "后退", "後退", "Back" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_reset,
				str = new string[3] { "复位", "復位", "Rst" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_up,
				str = new string[3] { "上移", "上移", "Up" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_down,
				str = new string[3] { "下移", "下移", "Down" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_reverse,
				str = new string[3] { "反转", "反轉", "Rvs" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_circle,
				str = new string[3] { "正转", "正轉", "Cir" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = bt_zero,
				str = new string[3] { "归零", "歸零", "Zero" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_BoardFix,
				str = new string[3] { "夹板", "夾板", "PCB-fix" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_BoardRelease,
				str = new string[3] { "松板", "松板", "PCB-rs" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_BoardIn,
				str = new string[3] { "进板", "進板", "In-Board" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_BoardOut,
				str = new string[3] { "出板", "出板", "Out-Board" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PCBAddWidth,
				str = new string[3] { "轨道+", "軌道+", "Track+" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PCBReduceWidth,
				str = new string[3] { "轨道-", "軌道-", "Track-" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_VacuumOnOff,
				str = new string[3] { "关真空", "關真空", "Vacuum Off" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_VacuunOffAll,
				str = new string[3] { "全关真空", "全關真空", "Vacuum-Off-all" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_visual_debug,
				str = new string[3] { "视觉调试", "視覺調試", "Visual Debug" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = btn_Throw,
				str = new string[3] { "抛料", "抛料", "Throw" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_xystep,
				str = new string[3] { "XY轴步距", "XY軸步距", "XY Step" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_zstep,
				str = new string[3] { "Z轴步距", "Z軸步距", "Z Step" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_astep,
				str = new string[3] { "A轴步距", "A軸步距", "A Step" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_boardstep,
				str = new string[3] { "轨道步距", "軌道步距", "Track Step" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_speed0,
				str = new string[3] { "速度", "速度", "Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_speed1,
				str = new string[3] { "速度", "速度", "Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_speed2,
				str = new string[3] { "速度", "速度", "Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lb_speed3,
				str = new string[3] { "速度", "速度", "Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_XY_name,
				str = new string[3] { "XY坐标", "XY坐標", "XY Coord" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_ChipBoundary,
				str = new string[3] { "方框", "方框", "Rec" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_ChipBoundary2,
				str = new string[3] { "圆框", "圓框", "Circle" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_PreviewLine0,
				str = new string[3] { "十字", "十字", "Cross" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_PreviewLine,
				str = new string[3] { "刻度", "刻度", "Scale" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_MarkCamPara,
				str = new string[3]
				{
					"MARK" + Environment.NewLine + "参数",
					"MARK" + Environment.NewLine + "參數",
					"Mark" + Environment.NewLine + "Para"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_iLLLED_open,
				str = new string[3]
				{
					"MARK" + Environment.NewLine + "照明",
					"MARK" + Environment.NewLine + "照明",
					"Mark" + Environment.NewLine + "Light"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OpenLed,
				str = new string[3]
				{
					"MARK" + Environment.NewLine + "光源",
					"MARK" + Environment.NewLine + "光源",
					"Mark" + Environment.NewLine + "Led"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OpenLed_fcam,
				str = new string[3]
				{
					"快相" + Environment.NewLine + "光源",
					"快相" + Environment.NewLine + "光源",
					"Fcam" + Environment.NewLine + "Led"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_OpenLed_hcam,
				str = new string[3]
				{
					"高相" + Environment.NewLine + "光源",
					"高相" + Environment.NewLine + "光源",
					"Hcam" + Environment.NewLine + "Led"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = lbv_xy,
				str = new string[3]
				{
					"X10000" + Environment.NewLine + "Y10000",
					"X10000" + Environment.NewLine + "Y10000",
					"X10000" + Environment.NewLine + "Y10000"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PreviewZoom,
				str = new string[3]
				{
					"Zoom" + Environment.NewLine + "x2",
					"Zoom" + Environment.NewLine + "x2",
					"Zoom" + Environment.NewLine + "x2"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton1,
				str = new string[3] { "进段1", "進段1", "Section 1" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = radioButton2,
				str = new string[3] { "进段2", "進段2", "Section 2" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label8,
				str = new string[3] { "MARK相机光源调节", "MARK相機光源調節", "Mark Cam Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "Config-1", "Config-1", "Config-1" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label6,
				str = new string[3] { "MARK光源设置", "MARK光源設置", "Mark Led Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "MARK相机设置", "MARK相機設置", "Mark Cam Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label7,
				str = new string[3] { "MARK相机拍照延时（ms）", "MARK相機拍照延時（ms）", "Mark Cam Capture Delay（ms）" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label2,
				str = new string[3] { "快捷步距", "快捷步距", "Quick Step" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_defaultxyz_set,
				str = new string[3] { "设置", "設置", "Set" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_light,
				str = new string[3]
				{
					"MARK" + Environment.NewLine + "照明",
					"MARK" + Environment.NewLine + "照明",
					"Mark" + Environment.NewLine + "Light"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_led,
				str = new string[3]
				{
					"MARK" + Environment.NewLine + "光源",
					"MARK" + Environment.NewLine + "光源",
					"Mark" + Environment.NewLine + "Led"
				}
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label211,
				str = new string[3] { "圆框半径", "圓框半徑", "Radius" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label3,
				str = new string[3] { "视觉测试", "視覺測試", "Visual Debug" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label9,
				str = new string[3] { "扫描半径", "掃描半徑", "Scan-R" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label10,
				str = new string[3] { "视觉阈值", "視覺閾值", "Threshold" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cam_set,
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
				ctrl = button_visualtest,
				str = new string[3] { "识别测试", "識別測試", "Visual Test" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_visualtype,
				str = new string[3] { "标准视觉", "標準視覺", "Vis-Standard" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_footprint,
				str = new string[3] { "元件封装", "元件封裝", "Footprint" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_factory_capture,
				str = new string[3] { "拍照", "拍照", "Capture" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_factory_capture2,
				str = new string[3] { "压缩拍照", "壓縮拍照", "Compress Capture " }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label213,
				str = new string[3] { "元件长(mm)", "元件長(mm)", "Chip-L(mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "元件宽(mm)", "元件寬(mm)", "Chip-W(mm)" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_deviceCalibration,
				str = new string[3] { "机器校正", "機器校正", "Calibration" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = cnButton_trackpara,
				str = new string[3] { "轨道设置", "轨道设置", "Track Configure" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_stop_runningvisual,
				str = new string[3] { "停止实时视觉", "停止实时视觉", "Stop Realtime Visual" }
			});
			return list;
		}

		private void cnButton_deviceCalibration_Click(object sender, EventArgs e)
		{
			if (MainForm0.uc_devicecalibration[mFn] != null)
			{
				MainForm0.uc_devicecalibration[mFn].Visible = true;
				MainForm0.uc_devicecalibration[mFn].BringToFront();
			}
		}

		public void set_throwbutton_color(Color c)
		{
			btn_Throw.BackColor = c;
		}

		private void init_chipbox()
		{
			checkBox_PreviewLine.Checked = true;
			checkBox_PreviewLine0.Checked = true;
			if (USR.mShiziColor.IsEmpty)
			{
				USR.mShiziColor = Color.Red;
			}
			label_prevline_color.BackColor = USR.mShiziColor;
			if (USR.mChipboxColor.IsEmpty)
			{
				USR.mChipboxColor = Color.Red;
			}
			if (USR.mChipbox2Color.IsEmpty)
			{
				USR.mChipbox2Color = Color.Red;
			}
			Color color2 = (pb_r2.BackColor = (label_chipboxcolor.BackColor = USR.mChipboxColor));
			Color color4 = (pb_r3.BackColor = (label_chipbox2color.BackColor = USR.mChipbox2Color));
			panel_ChipBoundary.Location = new Point(0, 876);
			panel_ChipBoundary2.Location = new Point(0, 876);
			panel_ChipBoundary.Visible = false;
			panel_ChipBoundary2.Visible = false;
			USR.mIsChipBox = false;
			USR.mIsChipBox2 = false;
			checkBox_ChipBoundary.Checked = USR.mIsChipBox;
			trackBar_chipbox_angle.Value = (int)(USR.mBoxAngle * 100f);
			label_chipbox_angle.Text = USR.mBoxAngle.ToString("F2") + "°";
			trackBar_chipbox_w.Value = USR.mBoxWidth;
			label_chipbox_w.Text = "W:" + USR.mBoxWidth;
			trackBar_chipbox_h.Value = USR.mBoxHeight;
			label_chipbox_h.Text = "H:" + USR.mBoxHeight;
			if (USR.mBoxWidth >= 10 && USR.mBoxHeight > 10 && USR.mIsChipBox)
			{
				MainForm0.PR_Draw(pb_r2, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), new Size(USR.mBoxWidth, USR.mBoxHeight), USR.mBoxAngle);
				pb_r2.Visible = USR.mIsChipBox;
			}
			checkBox_ChipBoundary2.Checked = USR.mIsChipBox2;
			trackBar_boundary2.Value = USR.mBoxR;
			label_boundary2.Text = USR.mBoxR.ToString();
			if (USR.mBoxR > 5 && USR.mIsChipBox2)
			{
				MainForm0.DU_Draw(pb_r3, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), USR.mBoxR);
				pb_r3.Visible = USR.mIsChipBox2;
			}
		}

		private void flush_chipbox()
		{
			Color color2 = (pb_r2.BackColor = (label_chipboxcolor.BackColor = USR.mChipboxColor));
			if (USR.mBoxWidth >= 10 && USR.mBoxHeight > 10 && USR.mIsChipBox)
			{
				MainForm0.PR_Draw(pb_r2, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), new Size(USR.mBoxWidth, USR.mBoxHeight), USR.mBoxAngle);
				pb_r2.Visible = USR.mIsChipBox;
			}
			Color color4 = (pb_r3.BackColor = (label_chipbox2color.BackColor = USR.mChipbox2Color));
			if (USR.mBoxR > 5 && USR.mIsChipBox2)
			{
				MainForm0.DU_Draw(pb_r3, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), USR.mBoxR);
				pb_r3.Visible = USR.mIsChipBox2;
			}
		}

		private void __checkBox_ChipBoundary_CheckedChanged(object sender, EventArgs e)
		{
			USR.mIsChipBox = checkBox_ChipBoundary.Checked;
			panel_ChipBoundary.Visible = USR.mIsChipBox;
			panel_ChipBoundary.BringToFront();
			checkBox_ChipBoundary.Checked = USR.mIsChipBox;
			if (USR.mBoxWidth >= 10 && USR.mBoxHeight > 10)
			{
				MainForm0.PR_Draw(pb_r2, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), new Size(USR.mBoxWidth, USR.mBoxHeight), USR.mBoxAngle);
				pb_r2.Visible = USR.mIsChipBox;
			}
		}

		private void __trackBar_chipbox_angle_Scroll(object sender, EventArgs e)
		{
			float num = (float)trackBar_chipbox_angle.Value / 100f;
			if (num != USR.mBoxAngle)
			{
				USR.mBoxAngle = num;
				if (USR.mBoxWidth >= 10 && USR.mBoxHeight > 10 && USR.mIsChipBox)
				{
					MainForm0.PR_Draw(pb_r2, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), new Size(USR.mBoxWidth, USR.mBoxHeight), USR.mBoxAngle);
					pb_r2.Visible = USR.mIsChipBox;
					label_chipbox_angle.Text = USR.mBoxAngle.ToString("F2") + "°";
				}
			}
		}

		private void __label_chipbox_angle_Click(object sender, EventArgs e)
		{
			Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, "方框角度(-180°~180°)", "float");
			form_Fill.set_float(USR.mBoxAngle);
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			float @float = form_Fill.get_float();
			if (@float < -180f || @float > 180f)
			{
				MainForm0.CmMessageBoxTop_Ok("数值超出范围，请重新设置！");
				return;
			}
			USR.mBoxAngle = @float;
			trackBar_chipbox_angle.Value = (int)(@float * 100f);
			label_chipbox_angle.Text = @float.ToString("F2") + "°";
			if (USR.mBoxWidth >= 10 && USR.mBoxHeight > 10 && USR.mIsChipBox)
			{
				MainForm0.PR_Draw(pb_r2, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), new Size(USR.mBoxWidth, USR.mBoxHeight), USR.mBoxAngle);
				pb_r2.Visible = USR.mIsChipBox;
			}
		}

		private void __trackBar_chipbox_w_Scroll(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			string text = (string)trackBar.Tag;
			if (text == "w")
			{
				if (trackBar.Value == USR.mBoxWidth)
				{
					return;
				}
				USR.mBoxWidth = trackBar.Value;
				label_chipbox_w.Text = "W:" + USR.mBoxWidth;
			}
			else
			{
				if (!(text == "h") || trackBar.Value == USR.mBoxHeight)
				{
					return;
				}
				USR.mBoxHeight = trackBar.Value;
				label_chipbox_h.Text = "H:" + USR.mBoxHeight;
			}
			if (USR.mBoxWidth >= 10 && USR.mBoxHeight > 10 && USR.mIsChipBox)
			{
				MainForm0.PR_Draw(pb_r2, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), new Size(USR.mBoxWidth, USR.mBoxHeight), USR.mBoxAngle);
				pb_r2.Visible = USR.mIsChipBox;
			}
		}

		private void __label_chipboxcolor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				Color color3 = (pb_r2.BackColor = (label_chipboxcolor.BackColor = (USR.mChipboxColor = colorDialog.Color)));
			}
		}

		public void set_chipBox(int w, int h, float angle)
		{
			if (USR.mIsChipBox)
			{
				int min_w = 9;
				int max_w = 401;
				int min_h = 9;
				int max_h = 401;
				Invoke((MethodInvoker)delegate
				{
					min_w = trackBar_chipbox_w.Minimum;
					max_w = trackBar_chipbox_w.Maximum;
					min_h = trackBar_chipbox_h.Minimum;
					max_h = trackBar_chipbox_h.Maximum;
				});
				if (w >= min_w && w <= max_w)
				{
					USR.mBoxWidth = w;
				}
				if (h >= min_h && h <= max_h)
				{
					USR.mBoxHeight = h;
				}
				if (angle >= -180f || angle <= 180f)
				{
					USR.mBoxAngle = angle;
				}
				Invoke((MethodInvoker)delegate
				{
					trackBar_chipbox_angle.Value = (int)(USR.mBoxAngle * 100f);
					trackBar_chipbox_w.Value = USR.mBoxWidth;
					trackBar_chipbox_h.Value = USR.mBoxHeight;
					label_chipbox_angle.Text = USR.mBoxAngle.ToString("F2");
					label_chipbox_w.Text = "W:" + USR.mBoxWidth;
					label_chipbox_h.Text = "H:" + USR.mBoxHeight;
				});
				if (USR.mBoxWidth >= 10 && USR.mBoxHeight > 10 && USR.mIsChipBox)
				{
					pb_r2.BackColor = USR.mChipboxColor;
					MainForm0.PR_Draw(pb_r2, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), new Size(USR.mBoxWidth, USR.mBoxHeight), USR.mBoxAngle);
					pb_r2.Visible = USR.mIsChipBox;
				}
			}
		}

		private void __label_chipbox_w_Click(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			string text = (string)label.Tag;
			string text2 = "";
			int num = ((text == "w") ? trackBar_chipbox_w.Minimum : trackBar_chipbox_h.Minimum);
			int num2 = ((text == "w") ? trackBar_chipbox_w.Maximum : trackBar_chipbox_h.Maximum);
			if (text == "w")
			{
				text2 = "方框长(" + num + "~" + num2 + ")";
			}
			else
			{
				if (!(text == "h"))
				{
					return;
				}
				text2 = "方框宽(" + num + "~" + num2 + ")";
			}
			Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, text2, "int");
			form_Fill.set_int((text == "w") ? USR.mBoxWidth : USR.mBoxHeight);
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			int @int = form_Fill.get_int();
			if (@int < num || @int > num2)
			{
				MainForm0.CmMessageBoxTop_Ok("数值超出范围，请重新设置！");
				return;
			}
			if (text == "w")
			{
				USR.mBoxWidth = @int;
				trackBar_chipbox_w.Value = @int;
				label_chipbox_w.Text = @int.ToString();
			}
			else if (text == "h")
			{
				USR.mBoxHeight = @int;
				trackBar_chipbox_h.Value = @int;
				label_chipbox_h.Text = @int.ToString();
			}
			if (USR.mBoxWidth >= 10 && USR.mBoxHeight > 10 && USR.mIsChipBox)
			{
				MainForm0.PR_Draw(pb_r2, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), new Size(USR.mBoxWidth, USR.mBoxHeight), USR.mBoxAngle);
				pb_r2.Visible = USR.mIsChipBox;
			}
		}

		private void __checkBox_ChipBoundary2_CheckedChanged(object sender, EventArgs e)
		{
			USR.mIsChipBox2 = checkBox_ChipBoundary2.Checked;
			panel_ChipBoundary2.Visible = USR.mIsChipBox2;
			panel_ChipBoundary2.BringToFront();
			checkBox_ChipBoundary2.Checked = USR.mIsChipBox2;
			if (USR.mBoxR > 5)
			{
				MainForm0.DU_Draw(pb_r3, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), USR.mBoxR);
				pb_r3.Visible = USR.mIsChipBox2;
			}
		}

		private void __trackBar_boundary2_Scroll(object sender, EventArgs e)
		{
			USR.mBoxR = trackBar_boundary2.Value;
			label_boundary2.Text = USR.mBoxR.ToString();
			if (USR.mBoxR > 5 && USR.mIsChipBox2)
			{
				MainForm0.DU_Draw(pb_r3, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), USR.mBoxR);
				pb_r3.Visible = USR.mIsChipBox2;
			}
		}

		private void __label_boundary2_Click(object sender, EventArgs e)
		{
			Form_Fill form_Fill = new Form_Fill(USR_INIT.mLanguage, "圆框半径(" + trackBar_boundary2.Minimum + "~" + trackBar_boundary2.Maximum + ")", "int");
			form_Fill.set_int(USR.mBoxR);
			if (form_Fill.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			int @int = form_Fill.get_int();
			if (@int < trackBar_boundary2.Minimum || @int > trackBar_boundary2.Maximum)
			{
				MainForm0.CmMessageBoxTop_Ok("数值超出范围，请重新设置！");
				return;
			}
			USR.mBoxR = @int;
			trackBar_boundary2.Value = @int;
			label_boundary2.Text = @int.ToString();
			if (USR.mBoxR > 5 && USR.mIsChipBox2)
			{
				MainForm0.DU_Draw(pb_r3, new Point(mJvs_picboxWidth / 2, mJvs_picboxHeight / 2), USR.mBoxR);
				pb_r3.Visible = USR.mIsChipBox2;
			}
		}

		private void __label_chipbox2color_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				Color color3 = (pb_r3.BackColor = (label_chipbox2color.BackColor = (USR.mChipbox2Color = colorDialog.Color)));
			}
		}

		private void __checkBox_PreviewLine_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_PreviewLine.Checked)
			{
				PicBoxCSL.Visible = true;
			}
			else
			{
				PicBoxCSL.Visible = false;
			}
		}

		private void __checkBox_PreviewLine0_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_PreviewLine0.Checked)
			{
				PicBoxCSL0.Visible = true;
			}
			else
			{
				PicBoxCSL0.Visible = false;
			}
		}

		private void __label_prevline_color_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				PictureBox picBoxCSL = PicBoxCSL0;
				PictureBox picBoxCSL2 = PicBoxCSL;
				Color color2 = (label_prevline_color.BackColor = (USR.mShiziColor = colorDialog.Color));
				Color color5 = (picBoxCSL.BackColor = (picBoxCSL2.BackColor = color2));
			}
		}

		private void init_zn_nozzle()
		{
			string[] array = new string[3] { "吸嘴", "吸嘴", "Noz " };
			button_nozzle = new CnButton[8];
			for (int i = 0; i < 8; i++)
			{
				button_nozzle[i] = new CnButton();
				panel_nozzle.Controls.Add(button_nozzle[i]);
				button_nozzle[i].Size = new Size(66, 26);
				button_nozzle[i].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 11f, FontStyle.Regular);
				button_nozzle[i].Location = new Point(4 + 68 * (i + mFn * HW.mZnNum[0]), 3);
				button_nozzle[i].Text = array[USR_INIT.mLanguage] + (i + 1);
				button_nozzle[i].ForeColor = Color.White;
				button_nozzle[i].BackColor = Color.DimGray;
				button_nozzle[i].CnPressDownColor = Color.Red;
				button_nozzle[i].Tag = i;
				if (i < HW.mZnNum[MainForm0.mFn])
				{
					button_nozzle[i].CnButtonMode = ButtonModeEn.PressRadio;
					button_nozzle[i].CnSetPressDown(i == MainForm0.mZn[MainForm0.mFn]);
					button_nozzle[i].MouseDown += button_nozzle_MouseDown;
				}
				else
				{
					button_nozzle[i].CnButtonMode = ButtonModeEn.Disable;
					button_nozzle[i].UseVisualStyleBackColor = false;
					button_nozzle[i].Visible = false;
					button_nozzle[i].ForeColor = Color.Black;
					button_nozzle[i].BackColor = Color.White;
				}
			}
			lb_zn = new Label[8];
			lbv_zn = new Label[8];
			lbv_an = new Label[8];
			Label label = new Label();
			label.Text = STR.H_a[USR_INIT.mLanguage];
			label.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
			label.AutoSize = false;
			label.Size = new Size(50, 18);
			label.TextAlign = ContentAlignment.MiddleCenter;
			label.Location = new Point(0, 20);
			panel_za.Controls.Add(label);
			Label label2 = new Label();
			label2.Text = STR.A_a[USR_INIT.mLanguage];
			label2.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
			label2.AutoSize = false;
			label2.Size = new Size(50, 18);
			label2.TextAlign = ContentAlignment.MiddleCenter;
			label2.Location = new Point(0, 38);
			panel_za.Controls.Add(label2);
			for (int j = 0; j < 8; j++)
			{
				lb_zn[j] = new Label();
				lb_zn[j].AutoSize = false;
				lb_zn[j].Size = new Size(50, 18);
				lb_zn[j].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
				lb_zn[j].TextAlign = ContentAlignment.MiddleCenter;
				lb_zn[j].Anchor = AnchorStyles.None;
				lb_zn[j].Location = new Point(50 + j * 54, 2);
				panel_za.Controls.Add(lb_zn[j]);
				if (j < HW.mZnNum[MainForm0.mFn])
				{
					lb_zn[j].Text = STR.NOZZLE_a[USR_INIT.mLanguage] + (j + 1);
					lb_zn[j].Tag = j;
					lb_zn[j].Click += lb_v_Click;
				}
				lbv_zn[j] = new Label();
				lbv_zn[j].AutoSize = false;
				lbv_zn[j].Size = new Size(55, 18);
				lbv_zn[j].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f, FontStyle.Regular);
				if (j < HW.mZnNum[MainForm0.mFn])
				{
					lbv_zn[j].Text = "00000";
					lbv_zn[j].Tag = j;
					lbv_zn[j].Anchor = AnchorStyles.None;
					lbv_zn[j].Click += lb_v_Click;
					lbv_zn[j].TextAlign = ContentAlignment.MiddleLeft;
				}
				lbv_zn[j].Location = new Point(50 + j * 54, 20);
				panel_za.Controls.Add(lbv_zn[j]);
				lbv_an[j] = new Label();
				lbv_an[j].AutoSize = false;
				lbv_an[j].Size = new Size(55, 18);
				lbv_an[j].Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], 10f, FontStyle.Regular);
				if (j < HW.mZnNum[MainForm0.mFn])
				{
					lbv_an[j].Text = "0.0";
					lbv_an[j].Tag = j;
					lbv_an[j].Anchor = AnchorStyles.None;
					lbv_an[j].Click += lb_v_Click;
					lbv_an[j].TextAlign = ContentAlignment.MiddleLeft;
				}
				lbv_an[j].Location = new Point(50 + j * 54, 38);
				panel_za.Controls.Add(lbv_an[j]);
			}
		}

		private void button_nozzle_flush()
		{
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				button_nozzle[i].CnSetPressDown(i == MainForm0.mZn[MainForm0.mFn]);
			}
		}

		private void lb_v_Click(object sender, EventArgs e)
		{
			int num = (int)((Label)sender).Tag;
			MainForm0.radiobt_zn[MainForm0.mFn][num].Checked = true;
		}

		private void button_nozzle_MouseDown(object sender, MouseEventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			int num = (int)cnButton.Tag;
			if (num >= 0 && num < HW.mZnNum[MainForm0.mFn])
			{
				MainForm0.radiobt_zn[MainForm0.mFn][num].Checked = true;
			}
		}

		public void updateCoordinateXY(int x, int y)
		{
			Thread thread = new Thread(thd_updateXY);
			thread.IsBackground = true;
			thread.Start(new Coordinate(x, y));
		}

		private void thd_updateXY(object o)
		{
			BeginInvoke((MethodInvoker)delegate
			{
				lbv_xy.Text = MainForm0.format_XY_label_string((Coordinate)o);
			});
		}

		public void updateCoordinateZ(int zn, int value)
		{
			Thread thread = new Thread(thd_updateZ);
			thread.IsBackground = true;
			thread.Start(new UPDATE_ZA(zn, value));
		}

		private void thd_updateZ(object o)
		{
			UPDATE_ZA upz = (UPDATE_ZA)o;
			BeginInvoke((MethodInvoker)delegate
			{
				if (upz.value < 0)
				{
					upz.value = -upz.value;
				}
				lbv_zn[upz.zn].Text = upz.value.ToString();
			});
		}

		public void updateCoordinateA(int zn, int value)
		{
			Thread thread = new Thread(thd_updateA);
			thread.IsBackground = true;
			thread.Start(new UPDATE_ZA(zn, value));
		}

		private void thd_updateA(object o)
		{
			UPDATE_ZA upd = (UPDATE_ZA)o;
			BeginInvoke((MethodInvoker)delegate
			{
				float num = (float)((double)(float)upd.value * 1.8 / 128.0);
				if (num <= -100f)
				{
					lbv_an[upd.zn].Text = num.ToString("0.0");
				}
				else
				{
					lbv_an[upd.zn].Text = num.ToString("0.00");
				}
			});
		}

		private void init_move_para()
		{
			nud_xystep.Value = USR.mXYStep;
			nud_zstep.Value = USR.mZStep;
			nud_astep.Value = (decimal)USR.mAStepDegree;
			nud_railstep.Maximum = 30000m;
			nud_railstep.Value = USR.mRailStep;
			trb_xyspeed.Value = USR.mXYSpeed;
			trb_zspeed.Value = USR.mZSpeed;
			trb_aspeed.Value = USR.mASpeed;
			trb_railspeed.Value = USR.mRailSpeed;
			lbv_xyspeed.Text = trb_xyspeed.Value.ToString();
			lbv_zspeed.Text = trb_zspeed.Value.ToString();
			lbv_aspeed.Text = trb_aspeed.Value.ToString();
			lbv_railspeed.Text = trb_railspeed.Value.ToString();
			if (USR.mXYStep_Defaults == null)
			{
				USR.mXYStep_Defaults = new int[10] { 1, 10, 100, 1000, 10000, 1, 1, 1, 1, 1 };
			}
			if (USR.mZStep_Defaults == null)
			{
				USR.mZStep_Defaults = new int[10] { 1, 5, 10, 100, 1, 1, 1, 1, 1, 1 };
			}
			button_default_xy = new Button[4];
			button_default_z = new Button[4];
			panel_default_xy.Controls.Clear();
			panel_default_z.Controls.Clear();
			for (int i = 0; i < 4; i++)
			{
				button_default_xy[i] = new Button();
				button_default_xy[i].Text = USR.mXYStep_Defaults[i].ToString();
				panel_default_xy.Controls.Add(button_default_xy[i]);
				button_default_xy[i].Size = new Size(50, 23);
				button_default_xy[i].Location = new Point((button_default_xy[i].Size.Width + 3) * i, 1);
				button_default_xy[i].Tag = i;
				button_default_xy[i].ForeColor = Color.White;
				button_default_xy[i].Click += button_default_xy_Click;
				button_default_z[i] = new Button();
				button_default_z[i].Text = USR.mZStep_Defaults[i].ToString();
				panel_default_z.Controls.Add(button_default_z[i]);
				button_default_z[i].Size = new Size(50, 23);
				button_default_z[i].Location = new Point((button_default_z[i].Size.Width + 3) * i, 1);
				button_default_z[i].Tag = i;
				button_default_z[i].ForeColor = Color.White;
				button_default_z[i].Click += button_default_z_Click;
			}
		}

		private void button_default_xy_Click(object sender, EventArgs e)
		{
			int num = (int)((Button)sender).Tag;
			nud_xystep.Value = (USR.mXYStep = USR.mXYStep_Defaults[num]);
		}

		private void button_default_z_Click(object sender, EventArgs e)
		{
			int num = (int)((Button)sender).Tag;
			nud_zstep.Value = (USR.mZStep = USR.mZStep_Defaults[num]);
		}

		private void __button_defaultxyz_set_Click(object sender, EventArgs e)
		{
			Form_DefaultXYZ form_DefaultXYZ = new Form_DefaultXYZ(USR);
			form_DefaultXYZ.ShowDialog();
			for (int i = 0; i < 4; i++)
			{
				button_default_xy[i].Text = USR.mXYStep_Defaults[i].ToString();
				button_default_z[i].Text = USR.mZStep_Defaults[i].ToString();
			}
		}

		private void __nud_xystep_ValueChanged(object sender, EventArgs e)
		{
			USR.mXYStep = (int)nud_xystep.Value;
		}

		private void __nud_zstep_ValueChanged(object sender, EventArgs e)
		{
			USR.mZStep = (int)nud_zstep.Value;
		}

		private void __nud_astep_ValueChanged(object sender, EventArgs e)
		{
			USR.mAStepDegree = (float)nud_astep.Value;
		}

		private void __nud_railstep_ValueChanged(object sender, EventArgs e)
		{
			USR.mRailStep = (int)nud_railstep.Value;
		}

		private void __trb_xyspeed_Scroll(object sender, EventArgs e)
		{
			lbv_xyspeed.Text = trb_xyspeed.Value.ToString();
			USR.mXYSpeed = trb_xyspeed.Value;
		}

		private void __trb_zspeed_Scroll(object sender, EventArgs e)
		{
			lbv_zspeed.Text = trb_zspeed.Value.ToString();
			USR.mZSpeed = trb_zspeed.Value;
		}

		private void __trb_aspeed_Scroll(object sender, EventArgs e)
		{
			lbv_aspeed.Text = trb_aspeed.Value.ToString();
			USR.mASpeed = trb_aspeed.Value;
		}

		private void __trb_railspeed_Scroll(object sender, EventArgs e)
		{
			lbv_railspeed.Text = trb_railspeed.Value.ToString();
			USR.mRailSpeed = trb_railspeed.Value;
		}
	}
}
