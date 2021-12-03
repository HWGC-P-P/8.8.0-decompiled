using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using QIGN_COMMON.Properties;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_Forms;
using QIGN_COMMON.vs_Forms.Form_Debug;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_job : UserControl
	{
		public Thread mthd_autoRun;

		public Thread mthd_stop;

		public Thread mthd_smtRun;

		public Thread mthd_youxianpik;

		public Thread mthd_aftersmtdone;

		public volatile bool mIsChipsOnHead;

		public int mCurSaved_fromBigTab_pcbIdx;

		public int mCurSaved_fromBigTab_groupIdx;

		private int s_inborad;

		public UserControl_PcbCheck uc_PcbCheck;

		public bool bIsFinishAutoRun;

		public BindingList<int> mloop;

		public int mloop_idx;

		public BindingList<int_2d> mthrowlist = new BindingList<int_2d>();

		public SmtOpMode msmt_mode;

		public int msmtgroup_idx_raw;

		public int msmtchip_idx_raw;

		public int msmtchip_idx;

		public int mis_maybe_continue;

		public float msmt_curhaiba;

		public int msmt_real_chips;

		public int msmt_real_loops;

		public DateTime msmt_starttime = DateTime.Now;

		public double msmt_preparetime;

		public double msmt_max_hourspeed;

		public double msmt_hourspeed;

		public int msmt_last_all_no;

		public UserControl_SmtMarkRecognize uc_smtMarkRecognition;

		public Coordinate[] mMarkFound = new Coordinate[2];

		public volatile bool mbMarkDoneMutex;

		public volatile bool mManualMarkSycn;

		public bool mIsMarkRecSuccess;

		public bool mIsMarkTest;

		public Bitmap Pic_MarkGen_Orgin;

		public Bitmap Pic_MarkGen_Ct;

		public bool saved_lighton;

		public bool saved_ledon;

		public MarkCamPara saved_markpara = new MarkCamPara();

		public Form_MarkGen mFormMarkGen;

		public Thread mThd_PriciseMarkGen;

		public volatile int[] mXref = new int[8];

		public volatile int[] mYref = new int[8];

		public volatile float[] mAngleref = new float[8];

		public volatile int[] mPnoref = new int[8];

		public volatile SMT_VISUAL_STATE[] mSmtVisualDone = new SMT_VISUAL_STATE[8];

		public int XY_SPEED;

		public int A_SPEED;

		public bool LOW_SPEED;

		public volatile bool[] mSyncpik_SmtMask;

		public volatile int mJvsStill_SmtMask;

		public Form_PikFail_HCamPrecise mForm_PikFail_H;

		public ChipCategoryElement[][] slot_feeder_component = new ChipCategoryElement[2][];

		public float[][] isSlotOcpy = new float[2][];

		public float[][] isSlotBrkn = new float[2][];

		private Label[] label_smt_chips_byzn;

		private Label[] label_smt_drops_byzn;

		private Label[] label_smt_droprate_byzn;

		private Label[] label_smt_nones_byzn;

		private DateTime m_start_smt_time;

		private USR_INIT_DATA USR_INIT;

		public USR_DATA USR;

		public USR2_DATA USR2;

		public USR3_BASE USR3B;

		public BindingList<USR3_DATA> mUSR3List;

		public int mUSR3Idx;

		public int mUSR3Idx_Prev;

		public USR3_DATA USR3;

		public BindingList<UserControl_pcbedit_datagridview> uc_dgv_list;

		public BindingList<Panel> mPanel_fakepcb_list;

		public UserControl_feederinstall uc_feederinstall;

		public UserControl_Stack uc_stack;

		public UserControl_SmtSetting uc_smtsetting;

		public int mFn;

		public BindingList<CnButton> button_subpcb;

		public int youxian_pik;

		public volatile bool Is_YouXian_Pik_Done;

		private IContainer components;

		private TabControl tabControl_mainwork;

		private TabPage tabPage_main_pcbedit;

		private Panel panel_subpcb;

		private CnButton button_subpcb_select;

		private Label label_subpcb_title;

		private Label label26;

		private Panel panel_subpcblist;

		private CnButton button24;

		private CnButton button18;

		private CnButton button22;

		private CnButton button17;

		private CnButton button20;

		private CnButton button16;

		private CnButton button_del_subpcb;

		private CnButton button_subpcb_setting;

		private CnButton button_add_subpcb;

		private Panel panel_PcbEditPage;

		private Panel panel_PCBE_OP;

		private CnButton button_openFeederPage_vsplus;

		private CnButton button_smtTest;

		private CnButton button_PCBE_feeder;

		private CnButton button_goto_PCBEdit;

		private CnButton button_Legal;

		private CnButton button_openFeederPage;

		private CnButton button_Cat;

		private Label label87;

		private Label label144;

		private Label label86;

		private Label label85;

		private Label label138;

		private Label label19;

		private Panel panel_PCBE;

		private TabPage tabPage_main_smt;

		private Panel panel_SmtProducePage;

		private CnButton button_vsplus_startsmt;

		private CnButton button_vsplus_startsmt2;

		private CheckBox checkBox_simulate_visualpass;

		private CheckBox checkBox_simulator;

		private CnButton button_bigtab;

		private Label label_title_smt;

		private CnButton button_vsplus_continuesmt;

		private CnButton button_vsplus_setsmt;

		private Panel panel_vsplus_pausestop;

		private CnButton button_PauseSmt;

		private CnButton button_vsplus_stopsmt;

		private Panel panel_smtshoware;

		private Panel panel100;

		private CnButton button_Loukong_clearS3;

		private CheckBox checkBox_flashlight;

		private Panel panel3;

		private CheckBox checkBox_smtxyaspeed_edit;

		private CheckBox checkBox_FinishAutoSmt;

		private CnButton button_vsplus_smtinfo;

		private Panel panel32;

		private Label label_smtASpeed;

		private TrackBar trackBar_smtASpeed;

		private Label label_smt_XYspeed;

		private Label label_smtXYSpeed;

		private TrackBar trackBar_smtXYSpeed;

		private Label label_smt_Aspeed;

		private CnButton button_SmtVisualShow;

		private CnButton button_smt_showfackpcb;

		private ProgressBar progressBar_Process;

		private Panel panel30;

		private Label label_haiba;

		private Label label40;

		private Label label_SmtIndexNo;

		private Label label_All_CurChipIndex;

		private Label label_everyhour_speed;

		private Label label_everyhour_maxspeed;

		private Label label215;

		private Label label208;

		private Label label210;

		private Label label209;

		private Label label207;

		private Label label_All_PCBSmted;

		private Label label_vsplus_smtmode;

		private Label label_SmtState;

		private Panel panel_fakepcb_smt;

		private Panel panel2;

		private Panel panel_marksetting;

		private CnButton button_close_marksetting;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private RadioButton radioButton5;

		private RadioButton radioButton6;

		private CheckBox checkBox_AutoFail_ToManual;

		private CheckBox checkBox_Memory_Mark;

		private CheckBox checkBox_No_Mark;

		private Label label6;

		private CnButton button_marksetting;

		private CnButton button_youxian_pik;

		private Label label12;

		private Panel panel_youxianpik;

		private CnButton button_close_youxianpik;

		private RadioButton radioButton_none_aftersmtdone;

		private RadioButton radioButton_gotodefine_aftersmtdone;

		private CheckBox checkBox_youxian_visual;

		private RadioButton radioButton_gotopik_aftersmtdone;

		private Label label13;

		private Label label_gotodefinexy_aftersmtdone;

		private CheckBox checkBox_afteryouxian_gotomark1;

		private CnButton button_gotodefinexy_Save;

		private CnButton button_gotodefinexy_Goto;

		private CheckBox checkBox_youxian_pik;

		private CheckBox checkBox_preparevacuum_veryearly;

		private CheckBox checkBox_gen0_raisespeed;

		private Panel panel4;

		private RadioButton radioButton_prjmode1;

		private RadioButton radioButton_prjmode0;

		private Label label2;

		private Panel panel_safespace;

		private PictureBox pictureBox2;

		private NumericUpDown numericUpDown_safespace;

		private Label label123;

		private Label label122;

		private Label label7;

		private Panel panel1;

		private RadioButton radioButton1;

		private RadioButton radioButton_visualfailretry_afterfinish;

		private RadioButton radioButton_visualfailretry_rightnow;

		private Label label1;

		private NumericUpDown numericUpDown_failretryNum;

		private CheckBox checkBox5;

		private CheckBox checkBox_ischeckNozzle;

		private CheckBox checkBox_Loukong;

		private CnButton button_StackIsMount;

		private CnButton button_close;

		private CnButton button_SmtStackPlateStartNo;

		private Label label3;

		private Panel panel_smtinfo;

		private TextBox textBox_infolog;

		private CnButton button_throwrate_check;

		private CnButton button_Infologfile_browse;

		private CnButton button_info_clear;

		private Panel panel6;

		private Label label104;

		private Label label11;

		private Label label_infototalexceptions;

		private Label label4;

		private Label label_infototaldroprate;

		private Label label9;

		private Label label_infototalnones;

		private Label label5;

		private Label label_infototaldrops;

		private Label label8;

		private Label label_infototalchips;

		private CheckBox checkBox_onlyAutoMode;

		private Label label114;

		private Label label10;

		private Label label91;

		private Label label_infodate;

		private Label label_infocycletime;

		private Label label_infototalpcbs;

		private Label label112;

		private Label label14;

		private Label label_smtloopmode;

		private Panel panel5;

		private Panel panel7;

		private CnButton cnButton_vsplus_setsmt;

		private CnButton cnButton_vsplus_startsmt;

		private Label label15;

		private Label label16;

		private Label label17;

		public bool is_ignore_visualfail;

		private void __button_smtTest_Click(object sender, EventArgs e)
		{
			tabControl_mainwork.SelectedIndex = 1;
		}

		public void vsplus_smt_test(BindingList<ChipBoardElement> emtlist)
		{
			if (emtlist != null && emtlist.Count > 0)
			{
				Thread thread = new Thread(thd_vsplus_smt_test);
				thread.IsBackground = true;
				thread.Start(emtlist[0]);
			}
		}

		public void thd_vsplus_smt_test(object o)
		{
			Is_YouXian_Pik_Done = false;
			mSyncpik_SmtMask = new bool[HW.mZnNum[mFn]];
			ChipBoardElement chipBoardElement = (ChipBoardElement)o;
			BIGTAB_GROUP biggroup = vsplus_smt_test_bigtab((ChipBoardElement)o);
			BindingList<int_2d> throwlist = new BindingList<int_2d>();
			PikFail pikFail = vsplus_group(biggroup, throwlist, 0, 0);
			if (pikFail == PikFail.Success)
			{
				if (MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				}
				MainForm0.moveToXY_andWait_Smt(mFn, USR3B.mSmtXYSpeed, new Coordinate(chipBoardElement.X, chipBoardElement.Y));
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Smt test done!" : "贴装测试完毕!");
			}
			else
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Smt test fail!" : "贴装测试失败!");
			}
		}

		public BIGTAB_GROUP vsplus_smt_test_bigtab(ChipBoardElement emt)
		{
			float num = 0f;
			BIGTAB_GROUP bIGTAB_GROUP = new BIGTAB_GROUP();
			bIGTAB_GROUP.is_smt_test = true;
			bIGTAB_GROUP.gen = HW.mSmtGenerationNo;
			bIGTAB_GROUP.cameratype = emt.Cameratype;
			bIGTAB_GROUP.provider = emt.Stacktype;
			bIGTAB_GROUP.islowspeed = emt.IsLowSpeed;
			bIGTAB_GROUP.is_overclimb = false;
			StackElement[] array;
			if (bIGTAB_GROUP.provider == ProviderType.Feedr)
			{
				array = USR2.mStackLib.stacktab[0];
			}
			else if (bIGTAB_GROUP.provider == ProviderType.Vibra)
			{
				array = USR2.mStackLib.stacktab[2];
			}
			else
			{
				if (bIGTAB_GROUP.provider != ProviderType.Plate)
				{
					return null;
				}
				array = USR2.mStackLib.stacktab[1];
			}
			if (bIGTAB_GROUP.cameratype == CameraType.None)
			{
				bIGTAB_GROUP.is_overclimb = true;
			}
			else if (bIGTAB_GROUP.cameratype == CameraType.Fast)
			{
				if (bIGTAB_GROUP.provider == ProviderType.Feedr)
				{
					int num2 = emt.Stack_no - 1;
					int num3 = (int)(emt.Y - USR.mFastCamRecognizeCoord[0].Y);
					int num4 = (int)(emt.Y - array[num2].mXY.Y);
					bIGTAB_GROUP.is_overclimb = num3 * num4 < 0;
				}
				else
				{
					bIGTAB_GROUP.is_overclimb = true;
				}
			}
			else if (bIGTAB_GROUP.cameratype == CameraType.High)
			{
				if (bIGTAB_GROUP.provider == ProviderType.Feedr)
				{
					int num5 = emt.Stack_no - 1;
					int num6 = emt.Nozzle - 1;
					int num7 = (int)(emt.Y - USR.mHighCamRecognizeCoord[0][num6].Y);
					int num8 = (int)(emt.Y - array[num5].mXY.Y);
					bIGTAB_GROUP.is_overclimb = num7 * num8 < 0;
				}
				else
				{
					bIGTAB_GROUP.is_overclimb = true;
				}
			}
			bool flag = false;
			if (bIGTAB_GROUP.provider == ProviderType.Feedr)
			{
				int num9 = emt.Stack_no - 1;
				flag = ((num9 < HW.malgo2[mFn].slt_l[0] + HW.malgo2[mFn].slt_r[0]) ? true : false);
			}
			float[] array2 = new float[HW.mZnNum[mFn]];
			float[] array3 = new float[HW.mZnNum[mFn]];
			BIGTAB_2_ITEM bIGTAB_2_ITEM = new BIGTAB_2_ITEM();
			bIGTAB_GROUP.mnt_arr.Add(bIGTAB_2_ITEM);
			int num10 = emt.Stack_no - 1;
			bIGTAB_2_ITEM.materialvalue = emt.Material_value;
			bIGTAB_2_ITEM.providertype = bIGTAB_GROUP.provider;
			bIGTAB_2_ITEM.stackno = num10;
			bIGTAB_2_ITEM.group_no = emt.Group;
			bIGTAB_2_ITEM.cameratype = emt.Cameratype;
			bIGTAB_2_ITEM.zn = emt.Nozzle - 1;
			bIGTAB_2_ITEM.camera_z = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_camera[bIGTAB_2_ITEM.zn]) - array[num10].height);
			bIGTAB_2_ITEM.pik_speed_z_up = array[num10].mZnData[bIGTAB_2_ITEM.zn].Pik.UpSpeed;
			bIGTAB_2_ITEM.pik_speed_z_down = array[num10].mZnData[bIGTAB_2_ITEM.zn].Pik.DownSpeed;
			bIGTAB_2_ITEM.visualtype = emt.Visualtype;
			bIGTAB_2_ITEM.looptype = emt.Looptype;
			bIGTAB_2_ITEM.scan_r = (array[num10].mIsScanR ? array[num10].scanR : ((bIGTAB_2_ITEM.cameratype == CameraType.High) ? USR2.mHighCamScanRange[0][bIGTAB_2_ITEM.zn] : USR2.mFastCamScanRange[0][bIGTAB_2_ITEM.zn]));
			bIGTAB_2_ITEM.threshold = array[num10].mZnData[bIGTAB_2_ITEM.zn].threshold;
			bIGTAB_2_ITEM.pno = USR2.mFastCamMinValidPixel[0][bIGTAB_2_ITEM.zn];
			bIGTAB_2_ITEM.is_collect = array[num10].mIsCollect;
			bIGTAB_2_ITEM.delta = array[num10].mCollectDelta;
			bIGTAB_2_ITEM.l_ref_mm = array[num10].lenght;
			bIGTAB_2_ITEM.w_ref_mm = array[num10].width;
			bIGTAB_2_ITEM.l_ref_pix = (int)(array[num10].lenght * 100f / ((bIGTAB_2_ITEM.cameratype != CameraType.High) ? USR.mFastCamRatio[0][bIGTAB_2_ITEM.zn] : USR.mHighCamRatio[0]));
			bIGTAB_2_ITEM.w_ref_pix = (int)(array[num10].width * 100f / ((bIGTAB_2_ITEM.cameratype != CameraType.High) ? USR.mFastCamRatio[0][bIGTAB_2_ITEM.zn] : USR.mHighCamRatio[0]));
			bIGTAB_2_ITEM.chip_hmm = array[num10].height;
			bIGTAB_2_ITEM.haiba0_hmm = num;
			bIGTAB_2_ITEM.mnt_x_org = (bIGTAB_2_ITEM.mnt_x = (int)(emt.X - USR.mDeltaNozzle[0][bIGTAB_2_ITEM.zn].X));
			bIGTAB_2_ITEM.mnt_y_org = (bIGTAB_2_ITEM.mnt_y = (int)(emt.Y - USR.mDeltaNozzle[0][bIGTAB_2_ITEM.zn].Y));
			bIGTAB_2_ITEM.mnt_a_org = (bIGTAB_2_ITEM.mnt_a = emt.A);
			bIGTAB_2_ITEM.mnt_a_step_org = (bIGTAB_2_ITEM.mnt_a_step = 0);
			bIGTAB_2_ITEM.prepare1_z = 0;
			bIGTAB_2_ITEM.up1_z = 0;
			bIGTAB_2_ITEM.speed_z_down = array[num10].mZnData[bIGTAB_2_ITEM.zn].Mnt.DownSpeed;
			bIGTAB_2_ITEM.mnt_z = array[num10].mZnData[bIGTAB_2_ITEM.zn].Mnt.Height;
			if (USR2.mIsHOffsetMode)
			{
				float hmm = Math.Abs(USR.mBaseHeightmm[bIGTAB_2_ITEM.zn]) + array[num10].mZnData[bIGTAB_2_ITEM.zn].Mnt.Offset - array[num10].height;
				int num11 = MainForm0.format_Hmm_to_H(hmm) * ((bIGTAB_2_ITEM.zn % 2 != 0) ? 1 : (-1));
				if (HW.mSmtGenerationNo == 2)
				{
					num11 = Math.Abs(num11);
				}
				bIGTAB_2_ITEM.mnt_z = num11;
			}
			bIGTAB_2_ITEM.mntdelay = array[num10].mZnData[bIGTAB_2_ITEM.zn].Mnt.Delay;
			bIGTAB_2_ITEM.up0_z = 0;
			bIGTAB_2_ITEM.speed_z_up = array[num10].mZnData[bIGTAB_2_ITEM.zn].Mnt.UpSpeed;
			bIGTAB_2_ITEM.prepare0_z = 0;
			array2[bIGTAB_2_ITEM.zn] = num;
			num = Math.Max(num, bIGTAB_2_ITEM.chip_hmm);
			array3[bIGTAB_2_ITEM.zn] = num;
			bIGTAB_2_ITEM.haiba1_hmm = num;
			bIGTAB_2_ITEM.no = 0;
			bIGTAB_2_ITEM.all_no = 0;
			bIGTAB_2_ITEM.raw_no = emt.pointSmtIndex;
			bIGTAB_2_ITEM.is_overclimb = bIGTAB_GROUP.is_overclimb;
			bIGTAB_GROUP.is_cam2mnt_up = false;
			BIGTAB_2_ITEM bIGTAB_2_ITEM2 = bIGTAB_GROUP.mnt_arr[0];
			int num12 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_2_ITEM2.zn]) - array2[bIGTAB_2_ITEM2.zn] - bIGTAB_2_ITEM2.chip_hmm - USR3B.mSmtSafeSpace);
			int val = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_2_ITEM2.zn]) - bIGTAB_2_ITEM2.chip_hmm);
			bIGTAB_2_ITEM2.prepare1_z = Math.Min(num12, val);
			bIGTAB_2_ITEM2.up1_z = num12;
			int num13 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_2_ITEM2.zn]) - num - USR3B.mSmtSafeSpace);
			int val2 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_2_ITEM2.zn]));
			bIGTAB_2_ITEM2.prepare0_z = Math.Min(num13, val2);
			bIGTAB_2_ITEM2.up0_z = num13;
			if (!bIGTAB_GROUP.is_cam2mnt_up)
			{
				int num14 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_camera[bIGTAB_2_ITEM2.zn]) - bIGTAB_2_ITEM2.chip_hmm);
				if (bIGTAB_2_ITEM2.prepare1_z < num14)
				{
					bIGTAB_GROUP.is_cam2mnt_up = true;
				}
			}
			int[] array4 = remain_zn_arr(bIGTAB_GROUP.mnt_arr);
			for (int i = 0; i < array4.Count(); i++)
			{
				BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z = new BIGTAB_SUB_REMAIN_Z();
				bIGTAB_GROUP.remain_mnt_prepare_z.Add(bIGTAB_SUB_REMAIN_Z);
				bIGTAB_SUB_REMAIN_Z.zn = array4[i];
				int val3 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_SUB_REMAIN_Z.zn]) - num - USR3B.mSmtSafeSpace);
				int val4 = USR.mBaseHeight_saferun[bIGTAB_SUB_REMAIN_Z.zn];
				bIGTAB_SUB_REMAIN_Z.value1 = Math.Min(val3, val4);
				bIGTAB_SUB_REMAIN_Z.value0 = Math.Min(val3, val4);
			}
			bIGTAB_GROUP.is_pik2cam_up = true;
			BIGTAB_1_ITEM bIGTAB_1_ITEM = new BIGTAB_1_ITEM();
			bIGTAB_GROUP.pik_arr.Add(bIGTAB_1_ITEM);
			int num15 = 1;
			int num16 = 0;
			int num17 = 0;
			BIGTAB_SUB_PIK_ITEM bIGTAB_SUB_PIK_ITEM = new BIGTAB_SUB_PIK_ITEM();
			bIGTAB_1_ITEM.sync_arr.Add(bIGTAB_SUB_PIK_ITEM);
			bIGTAB_SUB_PIK_ITEM.group_no = emt.Group;
			bIGTAB_SUB_PIK_ITEM.syncpik_no = 1;
			bIGTAB_SUB_PIK_ITEM.zn = emt.Nozzle - 1;
			bIGTAB_SUB_PIK_ITEM.provider = emt.Stacktype;
			bIGTAB_SUB_PIK_ITEM.stackno = emt.Stack_no - 1;
			bIGTAB_SUB_PIK_ITEM.pikdelay = array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.Delay;
			bIGTAB_SUB_PIK_ITEM.speed_up = array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.UpSpeed;
			bIGTAB_SUB_PIK_ITEM.speed_down = array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.DownSpeed;
			bIGTAB_SUB_PIK_ITEM.pik_z = array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.Height;
			bIGTAB_SUB_PIK_ITEM.raw_no = emt.pointSmtIndex;
			bIGTAB_SUB_PIK_ITEM.zero_a = 0f;
			bIGTAB_SUB_PIK_ITEM.zero_a_step = 0;
			bIGTAB_SUB_PIK_ITEM.mnt_a = MainForm0.format_angle(emt.A, -180f, 180f, 360f);
			bIGTAB_SUB_PIK_ITEM.mnt_a_step = MainForm0.AngleToSteps(bIGTAB_SUB_PIK_ITEM.mnt_a);
			bIGTAB_SUB_PIK_ITEM.pik_a = 0f;
			bIGTAB_SUB_PIK_ITEM.pik_a_step = 0;
			bIGTAB_SUB_PIK_ITEM.is_preprarevacuum_later = USR2.mIsPrepareVacuumLater;
			bIGTAB_SUB_PIK_ITEM.materialvalue = emt.Labeltab + "-" + emt.Material_value + "-" + emt.Footprint;
			bIGTAB_SUB_PIK_ITEM.visualtype = emt.Visualtype;
			bIGTAB_SUB_PIK_ITEM.looptype = emt.Looptype;
			if (bIGTAB_GROUP.provider != ProviderType.Plate)
			{
				num16 += (int)(array[bIGTAB_SUB_PIK_ITEM.stackno].mXY.X - USR.mDeltaNozzle[0][bIGTAB_SUB_PIK_ITEM.zn].X);
				num17 += (int)(array[bIGTAB_SUB_PIK_ITEM.stackno].mXY.Y - USR.mDeltaNozzle[0][bIGTAB_SUB_PIK_ITEM.zn].Y);
			}
			if (USR2.mIsHOffsetMode)
			{
				float num18 = MainForm0.format_H_to_Hmm(Math.Abs(flag ? USR.mBaseHeight_feeder[bIGTAB_SUB_PIK_ITEM.zn] : USR.mBaseHeight_feederBk[bIGTAB_SUB_PIK_ITEM.zn]));
				if (bIGTAB_SUB_PIK_ITEM.provider == ProviderType.Vibra || bIGTAB_SUB_PIK_ITEM.provider == ProviderType.Plate)
				{
					num18 = MainForm0.format_H_to_Hmm(Math.Abs(array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].baseH));
				}
				float hmm2 = num18 + array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.Offset;
				int num19 = MainForm0.format_Hmm_to_H(hmm2) * ((bIGTAB_SUB_PIK_ITEM.zn % 2 != 0) ? 1 : (-1));
				if (HW.mSmtGenerationNo == 2)
				{
					num19 = Math.Abs(num19);
				}
				bIGTAB_SUB_PIK_ITEM.pik_z = num19;
			}
			if (bIGTAB_GROUP.provider == ProviderType.Feedr && !flag && USR2.mIs180DegreeReverse_forbackfeeder)
			{
				bIGTAB_SUB_PIK_ITEM.zero_a = 180f;
			}
			if (bIGTAB_GROUP.cameratype == CameraType.None || emt.Looptype == LoopType.HalfLoop || emt.Looptype == LoopType.CloseLoop)
			{
				bIGTAB_SUB_PIK_ITEM.pik_a = bIGTAB_SUB_PIK_ITEM.zero_a + bIGTAB_SUB_PIK_ITEM.mnt_a;
			}
			bIGTAB_SUB_PIK_ITEM.zero_a = MainForm0.format_angle(bIGTAB_SUB_PIK_ITEM.zero_a, -180f, 180f, 360f);
			bIGTAB_SUB_PIK_ITEM.zero_a_step = MainForm0.AngleToSteps(bIGTAB_SUB_PIK_ITEM.zero_a);
			bIGTAB_SUB_PIK_ITEM.pik_a = MainForm0.format_angle(bIGTAB_SUB_PIK_ITEM.pik_a, -180f, 180f, 360f);
			bIGTAB_SUB_PIK_ITEM.pik_a_step = MainForm0.AngleToSteps(bIGTAB_SUB_PIK_ITEM.pik_a);
			vsplus_change_bigtabgroup_mnt_zero_a(bIGTAB_GROUP, bIGTAB_SUB_PIK_ITEM.zn, bIGTAB_SUB_PIK_ITEM.zero_a);
			float num20 = array[bIGTAB_SUB_PIK_ITEM.stackno].height;
			float num21 = ((bIGTAB_GROUP.cameratype == CameraType.None) ? array2[bIGTAB_SUB_PIK_ITEM.zn] : array2[emt.Nozzle - 1]);
			int val5 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_SUB_PIK_ITEM.zn]) - num21 - USR3B.mSmtSafeSpace);
			int val6 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]));
			bIGTAB_SUB_PIK_ITEM.prepare0_z = Math.Min(val5, val6);
			int val7 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_SUB_PIK_ITEM.zn]) - num21 - num20 - USR3B.mSmtSafeSpace);
			int val8 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]) - num20);
			bIGTAB_SUB_PIK_ITEM.prepare1_z = Math.Min(val7, val8);
			if (bIGTAB_GROUP.provider == ProviderType.Feedr)
			{
				if (flag)
				{
					bIGTAB_SUB_PIK_ITEM.up0_z = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]));
					bIGTAB_SUB_PIK_ITEM.up1_z = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]) - num20);
				}
				else
				{
					bIGTAB_SUB_PIK_ITEM.up0_z = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]));
					bIGTAB_SUB_PIK_ITEM.up1_z = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]) - num20);
				}
				if (bIGTAB_SUB_PIK_ITEM.up0_z < bIGTAB_SUB_PIK_ITEM.prepare0_z)
				{
					bIGTAB_SUB_PIK_ITEM.up0_z = bIGTAB_SUB_PIK_ITEM.prepare0_z;
				}
				if (bIGTAB_SUB_PIK_ITEM.up1_z < bIGTAB_SUB_PIK_ITEM.prepare1_z)
				{
					bIGTAB_SUB_PIK_ITEM.up1_z = bIGTAB_SUB_PIK_ITEM.prepare1_z;
				}
			}
			else
			{
				bIGTAB_SUB_PIK_ITEM.up0_z = bIGTAB_SUB_PIK_ITEM.prepare0_z;
				bIGTAB_SUB_PIK_ITEM.up1_z = bIGTAB_SUB_PIK_ITEM.prepare1_z;
			}
			if (bIGTAB_GROUP.is_pik2cam_up)
			{
				int num22 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_camera[bIGTAB_SUB_PIK_ITEM.zn]) - array[bIGTAB_SUB_PIK_ITEM.stackno].height);
				if (bIGTAB_SUB_PIK_ITEM.prepare1_z < num22)
				{
					bIGTAB_GROUP.is_pik2cam_up = false;
				}
			}
			bIGTAB_1_ITEM.pik_x = num16 / num15;
			bIGTAB_1_ITEM.pik_y = num17 / num15;
			for (int j = 0; j < bIGTAB_1_ITEM.sync_arr.Count; j++)
			{
				bIGTAB_1_ITEM.sync_arr[j].pik_x = bIGTAB_1_ITEM.pik_x;
				bIGTAB_1_ITEM.sync_arr[j].pik_y = bIGTAB_1_ITEM.pik_y;
			}
			for (int k = 0; k < array4.Count(); k++)
			{
				BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z2 = new BIGTAB_SUB_REMAIN_Z();
				bIGTAB_SUB_REMAIN_Z2.zn = array4[k];
				bIGTAB_GROUP.remain_pik_prepare_z.Add(bIGTAB_SUB_REMAIN_Z2);
				float num23 = ((bIGTAB_GROUP.cameratype == CameraType.None) ? num : array2[emt.Nozzle - 1]);
				int val9 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[array4[k]]) - num23 - USR3B.mSmtSafeSpace);
				int val10 = USR.mBaseHeight_saferun[array4[k]];
				bIGTAB_SUB_REMAIN_Z2.value1 = Math.Min(val9, val10);
				bIGTAB_SUB_REMAIN_Z2.value0 = Math.Min(val9, val10);
			}
			return bIGTAB_GROUP;
		}

		private void __button_vsplus_stopsmt_Click(object sender, EventArgs e)
		{
			vsplus_stopsmt();
		}

		public void vsplus_stopsmt()
		{
			if (mthd_stop == null || !mthd_stop.IsAlive)
			{
				mthd_stop = new Thread(thd_vsplus_stopsmt);
				mthd_stop.IsBackground = true;
				mthd_stop.Start();
			}
		}

		public void thd_vsplus_stopsmt()
		{
			MainForm0.write_to_logFile("thd_vsplus_stopsmt");
			MainForm0.mRunDoing[mFn] |= 2;
			_ = USR3B.mIsYouxianPik;
			if (mthd_smtRun != null)
			{
				_ = mthd_smtRun.IsAlive;
			}
			if (mthd_smtRun != null)
			{
				while (mthd_smtRun.IsAlive)
				{
					Thread.Sleep(5);
				}
			}
			mthd_smtRun = null;
			if (mthd_autoRun != null)
			{
				while (mthd_autoRun.IsAlive)
				{
					Thread.Sleep(5);
				}
			}
			mthd_autoRun = null;
			MainForm0.mRunDoing[mFn] = 0;
			if (mIsChipsOnHead)
			{
				vsplus_smt_throw();
			}
			else
			{
				MainForm0.moveToZero_ZA_andWait(mFn);
			}
			Thread.Sleep(200);
			MainForm0.write_to_logFile("thd_vsplus_stopsmt gc_collect");
		}

		public void vsplus_smt_throw()
		{
			int num = USR3B.mSmtXYSpeed;
			int mSmtASpeed = USR3B.mSmtASpeed;
			MainForm0.moveToZero_Z_andWait(mFn);
			MainForm0.moveToXY_andWait(mFn, num, new Coordinate(USR.mThrowCoord.X - USR.mDeltaNozzle[0][0].X, USR.mThrowCoord.Y - USR.mDeltaNozzle[0][0].Y));
			if (HW.mSmtGenerationNo == 0)
			{
				MainForm0.moveToZero_Z_andWait(mFn);
			}
			else if (HW.mSmtGenerationNo == 2)
			{
				bool flag = false;
				if (mUSR3List != null && mCurSaved_fromBigTab_pcbIdx >= 0 && mCurSaved_fromBigTab_pcbIdx < mUSR3List.Count)
				{
					BindingList<BIGTAB_GROUP> mBigTab = mUSR3List[mCurSaved_fromBigTab_pcbIdx].mBigTab;
					if (mBigTab != null && mCurSaved_fromBigTab_groupIdx >= 0 && mCurSaved_fromBigTab_groupIdx < mBigTab.Count)
					{
						BIGTAB_GROUP bIGTAB_GROUP = mBigTab[mCurSaved_fromBigTab_groupIdx];
						for (int i = 0; i < bIGTAB_GROUP.mnt_arr.Count; i++)
						{
							BIGTAB_2_ITEM bIGTAB_2_ITEM = bIGTAB_GROUP.mnt_arr[i];
							MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_2_ITEM.zn, bIGTAB_2_ITEM.pik_speed_z_up, bIGTAB_2_ITEM.prepare1_z);
						}
						for (int j = 0; j < bIGTAB_GROUP.remain_mnt_prepare_z.Count; j++)
						{
							BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z = bIGTAB_GROUP.remain_mnt_prepare_z[j];
							MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_SUB_REMAIN_Z.zn, 60, bIGTAB_SUB_REMAIN_Z.value1);
						}
						for (int k = 0; k < HW.mZnNum[mFn]; k++)
						{
							MainForm0.WaitComplete_Z(mFn, k);
						}
						flag = true;
						num = (bIGTAB_GROUP.islowspeed ? (num / 2) : num);
						mSmtASpeed = (bIGTAB_GROUP.islowspeed ? (mSmtASpeed / 2) : mSmtASpeed);
					}
				}
				if (!flag)
				{
					MainForm0.moveToZero_Z_andWait(mFn);
				}
			}
			for (int l = 0; l < HW.mZnNum[mFn]; l++)
			{
				MainForm0.moveToXY_andWait(mFn, num, new Coordinate(USR.mThrowCoord.X - USR.mDeltaNozzle[0][l].X, USR.mThrowCoord.Y - USR.mDeltaNozzle[0][l].Y));
				MainForm0.misc_vacc_onoff(mFn, l, 0);
			}
			MainForm0.moveToZero_ZA_andWait(mFn);
			MainForm0.mMutexMoveXYZA = false;
			mIsChipsOnHead = false;
		}

		private void thd_SmtLoop(object o)
		{
			Thread.Sleep(10);
			mCurSaved_fromBigTab_pcbIdx = -1;
			mCurSaved_fromBigTab_groupIdx = -1;
			BindingList<int> bindingList = (BindingList<int>)o;
			if (bindingList != null)
			{
				_ = bindingList.Count;
				_ = 0;
			}
			int all_dabiao_lens = bigtab_count(mloop);
			BeginInvoke((MethodInvoker)delegate
			{
				MainForm0.uc_VisualShowSmt[mFn].Visible = true;
				MainForm0.uc_VisualShowSmt[mFn].BringToFront();
				progressBar_Process.Minimum = 0;
				progressBar_Process.Value = 0;
				progressBar_Process.Maximum = all_dabiao_lens;
				if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
				{
					MainForm0.uc_smtRunning.set_progress_bar_minvmax(mFn, 0, 0, all_dabiao_lens);
				}
				if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
				{
					MainForm0.uc_smtRunning.set_label_SmtState(mFn, "正在贴装");
				}
			});
			if (mthd_aftersmtdone != null)
			{
				while (mthd_aftersmtdone.IsAlive)
				{
					Thread.Sleep(5);
				}
				mthd_aftersmtdone = null;
			}
			if (msmt_mode == SmtOpMode.AutoRun)
			{
				if (youxian_pik != 0)
				{
					while (!Is_YouXian_Pik_Done)
					{
						Thread.Sleep(5);
						if ((MainForm0.mRunDoing[mFn] & 2) == 0)
						{
							continue;
						}
						goto IL_07a8;
					}
				}
				else
				{
					msmt_preparetime = 0.0;
				}
			}
			else
			{
				youxian_pik = 0;
				msmt_preparetime = 0.0;
			}
			smtnew_resetandflush_runningdata();
			int num = mloop_idx;
			int num2 = num;
			while (true)
			{
				if (num2 < bindingList.Count)
				{
					mloop_idx = num2;
					msmtchip_idx = 0;
					int num3 = (mCurSaved_fromBigTab_pcbIdx = bindingList[num2]);
					USR3_DATA uSR3_DATA = mUSR3List[num3];
					bigtab_count(uSR3_DATA.mBigTab);
					if (mUSR3Idx != num3)
					{
						mUSR3Idx_Prev = mUSR3Idx;
						mUSR3Idx = num3;
						BeginInvoke((MethodInvoker)delegate
						{
							button_subpcb[mUSR3Idx].CnSetPressDown(flag: true);
							button_subpcb[mUSR3Idx_Prev].CnSetPressDown(flag: false);
						});
						thd_subpcb_flush_allpages();
						Thread.Sleep(10);
					}
					if (mis_maybe_continue == 0)
					{
						draw_fakechip_all(mUSR3Idx, isdone: false);
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.draw_fakechip_all(mFn, mUSR3Idx, isdone: false);
						}
					}
					if (!USR3B.mIsDisableMark && !vsplus_automark(uSR3_DATA))
					{
						if (USR3B.mMarkFailtoDo == MarkFailtoDo.EndLoop_andExit)
						{
							if ((MainForm0.mRunDoing[mFn] & 2) == 0)
							{
								vsplus_stopsmt();
							}
						}
						else
						{
							if (USR3B.mMarkFailtoDo == MarkFailtoDo.EndLoop_andContinue)
							{
								goto IL_069b;
							}
							if (USR3B.mMarkFailtoDo == MarkFailtoDo.EndPcb_ContinueLoop_andExit)
							{
								Invoke((MethodInvoker)delegate
								{
									checkBox_FinishAutoSmt.Checked = true;
								});
								if (msmt_mode == SmtOpMode.CurLoop_AutoRun)
								{
									msmt_mode = SmtOpMode.CurLoop;
								}
								else if (msmt_mode == SmtOpMode.ContinueLoop_AutoRun)
								{
									msmt_mode = SmtOpMode.ContinueLoop;
								}
								goto IL_068b;
							}
							if (USR3B.mMarkFailtoDo == MarkFailtoDo.EndPcb_ContinueLoop_andContinue)
							{
								goto IL_068b;
							}
						}
					}
					if (num2 == num)
					{
						msmt_max_hourspeed = 0.0;
					}
					msmt_starttime = DateTime.Now;
					mthrowlist = new BindingList<int_2d>();
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						break;
					}
					for (int i = 0; i < uSR3_DATA.mBigTab.Count; i++)
					{
						mCurSaved_fromBigTab_groupIdx = i;
						BIGTAB_GROUP bIGTAB_GROUP = uSR3_DATA.mBigTab[i];
						mthrowlist.Clear();
						PikFail pikFail = vsplus_group(bIGTAB_GROUP, mthrowlist, (num2 == num && i == 0) ? youxian_pik : 0, 1);
						PikFail pikfail;
						if (mthrowlist.Count > 0)
						{
							if (bIGTAB_GROUP.cameratype == CameraType.High && ((bIGTAB_GROUP.mnt_arr.Count > 0) & (bIGTAB_GROUP.mnt_arr[0].looptype == LoopType.CloseLoop)))
							{
								while (pikFail != PikFail.SkipOnce)
								{
									if (pikFail == PikFail.Exit)
									{
										vsplus_stopsmt();
										goto end_IL_068f;
									}
									switch (pikFail)
									{
									case PikFail.SkipChip:
									{
										for (int j = 0; j < mthrowlist.Count; j++)
										{
											msmtchip_idx++;
										}
										msmt_last_all_no = uSR3_DATA.mBigTab[i].mnt_arr[uSR3_DATA.mBigTab[i].mnt_arr.Count() - 1].all_no;
										vsplus_skip_chipcats(bIGTAB_GROUP, mthrowlist, bindingList, mloop_idx, mCurSaved_fromBigTab_groupIdx + 1);
										mthrowlist.Clear();
										break;
									}
									case PikFail.Retry:
										goto IL_040b;
									}
									goto IL_065d;
									IL_040b:
									bIGTAB_GROUP = vsplus_create_biggroup(bIGTAB_GROUP, mthrowlist);
									mthrowlist.Clear();
									pikFail = vsplus_group(bIGTAB_GROUP, mthrowlist, 0, 0);
									if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
									{
										goto end_IL_068f;
									}
								}
								continue;
							}
							if (!USR3B.mIsPikRetry_AfterFinish)
							{
								int num4 = 0;
								while (true)
								{
									if (num4 < USR3B.mSmtPikRetryNum - 1)
									{
										bIGTAB_GROUP = vsplus_create_biggroup(bIGTAB_GROUP, mthrowlist);
										mthrowlist.Clear();
										vsplus_group(bIGTAB_GROUP, mthrowlist, 0, 0);
										if (mthrowlist.Count != 0)
										{
											if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
											{
												break;
											}
											num4++;
											continue;
										}
									}
									if (num4 == USR3B.mSmtPikRetryNum - 1)
									{
										MainForm0.start_buzzer_warning(mFn);
										Form_PikFail fm = new Form_PikFail(mFn, USR_INIT.mLanguage, USR3B.mSmtPikRetryNum, mthrowlist, bIGTAB_GROUP);
										Invoke((MethodInvoker)delegate
										{
											fm.ShowDialog();
										});
										pikfail = fm.get_pikfail();
										MainForm0.stop_buzzer_warning(mFn);
										if (pikfail == PikFail.SkipOnce)
										{
											goto IL_055d;
										}
										if (pikfail == PikFail.Retry)
										{
											num4 = -1;
											continue;
										}
										goto IL_05a2;
									}
									goto IL_0648;
								}
								goto end_IL_068f;
							}
						}
						goto IL_065d;
						IL_0648:
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							goto end_IL_068f;
						}
						goto IL_065d;
						IL_055d:
						for (int k = 0; k < mthrowlist.Count; k++)
						{
							msmtchip_idx++;
						}
						mthrowlist.Clear();
						continue;
						IL_05a2:
						if (pikfail == PikFail.SkipChip)
						{
							for (int l = 0; l < mthrowlist.Count; l++)
							{
								msmtchip_idx++;
							}
							msmt_last_all_no = uSR3_DATA.mBigTab[i].mnt_arr[uSR3_DATA.mBigTab[i].mnt_arr.Count() - 1].all_no;
							vsplus_skip_chipcats(bIGTAB_GROUP, mthrowlist, bindingList, mloop_idx, mCurSaved_fromBigTab_groupIdx + 1);
							mthrowlist.Clear();
						}
						else if (pikfail == PikFail.Exit)
						{
							vsplus_stopsmt();
							goto end_IL_068f;
						}
						goto IL_0648;
						IL_065d:
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							goto end_IL_068f;
						}
					}
					goto IL_068b;
				}
				goto IL_069b;
				IL_068b:
				num2++;
				continue;
				IL_069b:
				smtinfo_update_mountPcbs_plusplus();
				msmt_real_loops++;
				BeginInvoke((Action)delegate
				{
					set_label_all_pcbs(msmt_real_loops);
				});
				vsplus_aftersmtdone(bindingList[num]);
				MainForm0.moon_wind_update_current_miles(MainForm0.mSmtMiles);
				if (msmt_mode == SmtOpMode.CurPcb || msmt_mode == SmtOpMode.ContinuePcb || msmt_mode == SmtOpMode.CurLoop || msmt_mode == SmtOpMode.ContinueLoop)
				{
					break;
				}
				if (msmt_mode == SmtOpMode.CurLoop_AutoRun || msmt_mode == SmtOpMode.ContinueLoop_AutoRun)
				{
					msmt_mode = SmtOpMode.AutoRun;
					BeginInvoke((Action)delegate
					{
						label_vsplus_smtmode.Text = "全自动运行";
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text);
						}
					});
					if (!mloop_update())
					{
						break;
					}
					if (mthd_autoRun != null && mthd_autoRun.IsAlive)
					{
						mthd_autoRun.Abort();
					}
					mthd_autoRun = new Thread(thd_AutoRun);
					mthd_autoRun.IsBackground = true;
					mthd_autoRun.Start();
					mis_maybe_continue = 0;
				}
				else if (msmt_mode != SmtOpMode.AutoRun)
				{
					break;
				}
				return;
				continue;
				end_IL_068f:
				break;
			}
			goto IL_07a8;
			IL_07a8:
			MainForm0.write_to_logFile("thd_smtRun exit");
			Invoke((MethodInvoker)delegate
			{
				if (msmt_last_all_no == progressBar_Process.Maximum - 1)
				{
					mis_maybe_continue = 0;
				}
			});
			if (mis_maybe_continue != 0 && !bigtab_continue_raw_no())
			{
				mis_maybe_continue = 0;
			}
			Invoke((MethodInvoker)delegate
			{
				button_vsplus_startsmt.Visible = ((mis_maybe_continue == 0) ? true : false);
				if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
				{
					MainForm0.uc_smtRunning.set_cnButton_vsplus_startsmt_visiable(mFn, (mis_maybe_continue == 0) ? true : false);
				}
				label_vsplus_smtmode.Visible = false;
				if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
				{
					MainForm0.uc_smtRunning.set_label_vsplus_smtmode_visiable(mFn, flag: false);
				}
				MainForm0.set_warningalarm_idle();
				panel_vsplus_pausestop.Visible = false;
				if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
				{
					MainForm0.uc_smtRunning.set_pause_stop_button_visiable(mFn, flag: false);
				}
				label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IDLE..." : "空闲");
				if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
				{
					MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
				}
				checkBox_FinishAutoSmt.Visible = false;
				MainForm0.uc_VisualShowSmt[mFn].Visible = false;
			});
			msmt_mode = SmtOpMode.Idle;
			MainForm0.static_this.UI_Enable_SMT(mFn, flag: true);
			BeginInvoke((MethodInvoker)delegate
			{
				MainForm0.mark_light_on_ext(mFn, flag: true);
				MainForm0.mark_led_on_ext(mFn, flag: true);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: false);
			});
			Thread.Sleep(100);
			MainForm0.write_to_logFile("thd_smtRun gc_collect");
		}

		private void vsplus_skip_chipcats(BIGTAB_GROUP skipped_biggroup, BindingList<int_2d> throwlist, BindingList<int> loop, int cur_loopidx, int cur_groupidx)
		{
			BindingList<int_2d> bindingList = new BindingList<int_2d>();
			for (int i = 0; i < throwlist.Count; i++)
			{
				int_2d item = new int_2d((int)skipped_biggroup.mnt_arr[throwlist[i].a].providertype, skipped_biggroup.mnt_arr[throwlist[i].a].stackno);
				bindingList.Add(item);
			}
			int count = bindingList.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				int a = bindingList[num].a;
				int b = bindingList[num].b;
				for (int j = 0; j < num; j++)
				{
					if (bindingList[j].a == a && bindingList[j].b == b)
					{
						bindingList.RemoveAt(num);
						break;
					}
				}
			}
			int butie_count = 0;
			int num2 = 0;
			if (cur_loopidx == 0)
			{
				num2 = 0;
			}
			else if (cur_loopidx > 0)
			{
				int index = loop[cur_loopidx - 1];
				USR3_DATA uSR3_DATA = mUSR3List[index];
				if (uSR3_DATA.mBigTab.Count > 0)
				{
					BIGTAB_GROUP bIGTAB_GROUP = uSR3_DATA.mBigTab[uSR3_DATA.mBigTab.Count - 1];
					if (bIGTAB_GROUP.mnt_arr.Count() > 0)
					{
						num2 = bIGTAB_GROUP.mnt_arr[bIGTAB_GROUP.mnt_arr.Count() - 1].all_no + 1;
					}
				}
			}
			for (int k = cur_loopidx; k < loop.Count; k++)
			{
				int index2 = loop[k];
				USR3_DATA uSR3_DATA2 = mUSR3List[index2];
				int num3 = ((k == cur_loopidx) ? cur_groupidx : 0);
				for (int l = num3; l < uSR3_DATA2.mBigTab.Count; l++)
				{
					BIGTAB_GROUP bIGTAB_GROUP2 = uSR3_DATA2.mBigTab[l];
					int count2 = bIGTAB_GROUP2.mnt_arr.Count;
					for (int num4 = count2 - 1; num4 >= 0; num4--)
					{
						if (is_match_stacklist(bindingList, bIGTAB_GROUP2.mnt_arr[num4].providertype, bIGTAB_GROUP2.mnt_arr[num4].stackno))
						{
							BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z = new BIGTAB_SUB_REMAIN_Z();
							bIGTAB_SUB_REMAIN_Z.zn = bIGTAB_GROUP2.mnt_arr[num4].zn;
							bIGTAB_SUB_REMAIN_Z.value0 = bIGTAB_GROUP2.mnt_arr[num4].prepare0_z;
							bIGTAB_SUB_REMAIN_Z.value1 = bIGTAB_GROUP2.mnt_arr[num4].prepare1_z;
							bIGTAB_GROUP2.mnt_arr.RemoveAt(num4);
							bIGTAB_GROUP2.remain_mnt_prepare_z.Add(bIGTAB_SUB_REMAIN_Z);
							butie_count++;
						}
					}
					for (int m = 0; m < bIGTAB_GROUP2.pik_arr.Count; m++)
					{
						BindingList<BIGTAB_SUB_PIK_ITEM> sync_arr = bIGTAB_GROUP2.pik_arr[m].sync_arr;
						int count3 = sync_arr.Count;
						for (int num5 = count3 - 1; num5 >= 0; num5--)
						{
							if (is_match_stacklist(bindingList, bIGTAB_GROUP2.provider, sync_arr[num5].stackno))
							{
								BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z2 = new BIGTAB_SUB_REMAIN_Z();
								bIGTAB_SUB_REMAIN_Z2.zn = sync_arr[num5].zn;
								bIGTAB_SUB_REMAIN_Z2.value0 = sync_arr[num5].prepare0_z;
								bIGTAB_SUB_REMAIN_Z2.value1 = sync_arr[num5].prepare1_z;
								sync_arr.RemoveAt(num5);
								bIGTAB_GROUP2.remain_pik_prepare_z.Add(bIGTAB_SUB_REMAIN_Z2);
							}
						}
					}
				}
				for (int num6 = uSR3_DATA2.mBigTab.Count - 1; num6 >= 0; num6--)
				{
					BIGTAB_GROUP bIGTAB_GROUP3 = uSR3_DATA2.mBigTab[num6];
					if (bIGTAB_GROUP3.mnt_arr.Count == 0 || bIGTAB_GROUP3.pik_arr.Count == 0)
					{
						uSR3_DATA2.mBigTab.RemoveAt(num6);
					}
					else
					{
						for (int num7 = bIGTAB_GROUP3.pik_arr.Count - 1; num7 >= 0; num7--)
						{
							BindingList<BIGTAB_SUB_PIK_ITEM> sync_arr2 = bIGTAB_GROUP3.pik_arr[num7].sync_arr;
							if (sync_arr2.Count == 0)
							{
								bIGTAB_GROUP3.pik_arr.RemoveAt(num7);
							}
						}
					}
				}
				int num8 = 0;
				for (int n = 0; n < uSR3_DATA2.mBigTab.Count; n++)
				{
					BIGTAB_GROUP bIGTAB_GROUP4 = uSR3_DATA2.mBigTab[n];
					for (int num9 = 0; num9 < bIGTAB_GROUP4.mnt_arr.Count(); num9++)
					{
						bIGTAB_GROUP4.mnt_arr[num9].no = num8++;
						bIGTAB_GROUP4.mnt_arr[num9].all_no = num2++;
					}
				}
			}
			for (int num10 = 0; num10 < bindingList.Count; num10++)
			{
				USR3B.mIsMountStacksNew[bindingList[num10].a][bindingList[num10].b] = false;
			}
			Invoke((MethodInvoker)delegate
			{
				int maximum = progressBar_Process.Maximum;
				progressBar_Process.Maximum = maximum - butie_count;
			});
			if (msmt_mode == SmtOpMode.AutoRun)
			{
				Invoke((MethodInvoker)delegate
				{
					set_finishautorun(v: true);
				});
			}
		}

		public bool is_match_stacklist(BindingList<int_2d> skiplist, ProviderType providertype, int stackno)
		{
			for (int i = 0; i < skiplist.Count; i++)
			{
				if (skiplist[i].a == (int)providertype && skiplist[i].b == stackno)
				{
					return true;
				}
			}
			return false;
		}

		public void vsplus_aftersmtdone(int start_pcbidx)
		{
			if (mthd_aftersmtdone != null && mthd_aftersmtdone.IsAlive)
			{
				mthd_aftersmtdone.Abort();
				while (mthd_aftersmtdone.IsAlive)
				{
					Thread.Sleep(5);
				}
			}
			mthd_aftersmtdone = new Thread(thd_vsplus_aftersmtdone);
			mthd_aftersmtdone.IsBackground = true;
			mthd_aftersmtdone.Start(start_pcbidx);
		}

		public void thd_vsplus_aftersmtdone(object o)
		{
			if (msmt_mode == SmtOpMode.AutoRun)
			{
				MainForm0.mark_led_on(mFn, flag: false);
				MainForm0.mark_light_on(mFn, flag: false);
			}
			MainForm0.moveToZero_Z_andWait(mFn);
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				MainForm0.WaitComplete_A(mFn, i);
			}
			int[] array = null;
			if (USR3B.mGotoXYafterSmtDone_v != 0 && msmt_mode == SmtOpMode.AutoRun && USR3B.mInBoardMode == 0 && HW.mIsSanduanshi)
			{
				USR3_DATA uSR3_DATA = mUSR3List[(int)o];
				for (int j = 0; j < HW.mZnNum[mFn]; j++)
				{
					MainForm0.WaitComplete_Z(mFn, j);
				}
				Coordinate coordinate = new Coordinate(0L, 0L);
				if (USR3B.mGotoXYafterSmtDone_v == 1 && !USR3B.mIsYouxianPik)
				{
					coordinate.X = uSR3_DATA.mMark[0].X;
					coordinate.Y = uSR3_DATA.mMark[0].Y;
					if (uSR3_DATA.mIsMarkSearch[0])
					{
						coordinate.X = uSR3_DATA.mMarkSearch[0].X;
						coordinate.Y = uSR3_DATA.mMarkSearch[0].Y;
					}
					MainForm0.moveToXY_andWait_Smt(mFn, USR3B.mSmtXYSpeed, coordinate);
				}
				else if (USR3B.mGotoXYafterSmtDone_v == 1 && USR3B.mIsYouxianPik)
				{
					if (uSR3_DATA.mBigTab.Count >= 1 && uSR3_DATA.mBigTab[0].pik_arr.Count > 0)
					{
						coordinate.X = uSR3_DATA.mBigTab[0].pik_arr[0].pik_x;
						coordinate.Y = uSR3_DATA.mBigTab[0].pik_arr[0].pik_y;
						MainForm0.moveToXY_andWait_Smt(mFn, USR3B.mSmtXYSpeed, coordinate);
						array = new int[HW.mZnNum[mFn]];
						for (int k = 0; k < uSR3_DATA.mBigTab[0].pik_arr.Count; k++)
						{
							BIGTAB_1_ITEM bIGTAB_1_ITEM = uSR3_DATA.mBigTab[0].pik_arr[k];
							if (bIGTAB_1_ITEM.sync_arr != null && bIGTAB_1_ITEM.sync_arr.Count > 0)
							{
								for (int l = 0; l < bIGTAB_1_ITEM.sync_arr.Count; l++)
								{
									BIGTAB_SUB_PIK_ITEM bIGTAB_SUB_PIK_ITEM = bIGTAB_1_ITEM.sync_arr[l];
									array[bIGTAB_SUB_PIK_ITEM.zn] = bIGTAB_SUB_PIK_ITEM.prepare0_z;
								}
							}
						}
						for (int m = 0; m < uSR3_DATA.mBigTab[0].remain_pik_prepare_z.Count; m++)
						{
							BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z = uSR3_DATA.mBigTab[0].remain_pik_prepare_z[m];
							array[bIGTAB_SUB_REMAIN_Z.zn] = bIGTAB_SUB_REMAIN_Z.value0;
						}
					}
				}
				else if (USR3B.mGotoXYafterSmtDone_v == 2)
				{
					if (USR3B.mGotoXYafterSmtDone_Define == null)
					{
						USR3B.mGotoXYafterSmtDone_Define = new Coordinate(0L, 0L);
					}
					if (USR3B.mGotoXYafterSmtDone_Define.X != 0 || USR3B.mGotoXYafterSmtDone_Define.Y != 0)
					{
						MainForm0.moveToXY_andWait_Smt(mFn, USR3B.mSmtXYSpeed, USR3B.mGotoXYafterSmtDone_Define);
					}
				}
			}
			if (HW.mSmtGenerationNo == 0)
			{
				return;
			}
			vsplus_smt_reset_Z_Gen2();
			if (array != null)
			{
				for (int n = 0; n < HW.mZnNum[mFn]; n++)
				{
					MainForm0.moveToZ_noWait_Smt(mFn, n, 60, array[n]);
				}
				for (int num = 0; num < HW.mZnNum[mFn]; num++)
				{
					MainForm0.WaitComplete_Z(mFn, num);
				}
			}
		}

		public void vsplus_smt_reset_Z_Gen2()
		{
			MainForm0.mResetState2[0] = ResetState.Unknown;
			MainForm0.mResetState2[1] = ResetState.Unknown;
			MainForm0.mConDev[mFn].sendReset(1);
			if (HW.mDeviceType == DeviceType.DUDU_800)
			{
				MainForm0.mConDev2[0].sendReset(1);
				while (MainForm0.mResetState2[0] == ResetState.Unknown || MainForm0.mResetState2[1] == ResetState.Unknown)
				{
					Thread.Sleep(1);
				}
			}
			else
			{
				if (MainForm0.mIsSimulation)
				{
					Thread.Sleep(50);
					MainForm0.mResetState2[mFn] = ResetState.Success;
				}
				while (MainForm0.mResetState2[mFn] == ResetState.Unknown)
				{
					Thread.Sleep(1);
				}
			}
			if (MainForm0.mResetState2[0] == ResetState.Fail)
			{
				MainForm0.write_to_logFile("FAIL: 第一块主板ZA复位失败，请重启机器！");
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "第一块主板ZA复位失败，请重启机器！");
				Environment.Exit(0);
			}
			else if (MainForm0.mResetState2[1] == ResetState.Fail)
			{
				MainForm0.write_to_logFile("FAIL: 第二块主板ZA复位失败，请重启机器！");
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "第二块主板ZA复位失败，请重启机器！");
				Environment.Exit(0);
			}
		}

		private void thd_AutoRun()
		{
			if (mloop_update() || USR3B.mIsJieBoTaiMode)
			{
				Invoke((Action)delegate
				{
					label_vsplus_smtmode.Text = (new string[3] { "全自动运行", "全自動運行", "Auto Running" })[USR_INIT.mLanguage];
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text);
					}
					checkBox_FinishAutoSmt.Visible = true;
					checkBox_FinishAutoSmt.Enabled = true;
				});
				MainForm0.static_this.UI_Enable_SMT(mFn, flag: false);
				bool is_error = false;
				mloop_idx = 0;
				msmtchip_idx_raw = 0;
				msmtchip_idx = 0;
				mis_maybe_continue = 0;
				int num = mloop_calcBigTab();
				if (num != -1 || MainForm0.CmMessageBox("Z轴有超行程的厚元器件，贴装会产生风险，是否继续?", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					youxian_pik = 0;
					if (msmt_mode == SmtOpMode.AutoRun && !QnCommon.mIsShapeOpen[mFn])
					{
						if (USR3B.mIsYouxianPik && USR3B.mIsYouxianVisual)
						{
							youxian_pik = 2;
						}
						else if (USR3B.mIsYouxianPik && !USR3B.mIsYouxianVisual)
						{
							youxian_pik = 1;
						}
					}
					QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					int num2 = 0;
					if (HW.mDeviceType == DeviceType.HW_8S_TRAN4 || HW.mDeviceType == DeviceType.HW_6S_TRAN4)
					{
						num2 = s_auto_smt_tran4();
					}
					else if (HW.mDeviceType == DeviceType.DSQ800_120F)
					{
						num2 = ((!USR3B.mIsJieBoTaiMode) ? s_auto_smt_3dsq400_fn0() : s_auto_smt_3dsq400_jiebotai());
					}
					else if (HW.mIsSanduanshi)
					{
						if (USR3B.mInBoardMode == 1)
						{
							if (HW.mSections == 2)
							{
								num2 = s_auto_smt_2inboard();
							}
							else if (HW.mSections == 3)
							{
								num2 = s_auto_smt_3inboard();
							}
						}
						else
						{
							num2 = s_auto_smt_3duanshi();
						}
					}
					else
					{
						num2 = s_auto_smt_1duanshi();
					}
					if (num2 == -2)
					{
						goto IL_01ad;
					}
					if (num2 != -1)
					{
						if (num2 != -3)
						{
							goto IL_01ad;
						}
						is_error = true;
					}
				}
				MainForm0.write_to_logFile("thd_AutoRun exit");
				QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Unknown);
				}
				QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Unknown);
				}
				Invoke((MethodInvoker)delegate
				{
					MainForm0.static_this.UI_Enable_SMT(mFn, flag: true);
					if (!is_error)
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IDLE..." : "空闲");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					}
					button_vsplus_startsmt.Visible = ((mis_maybe_continue == 0) ? true : false);
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_cnButton_vsplus_startsmt_visiable(mFn, (mis_maybe_continue == 0) ? true : false);
					}
					label_vsplus_smtmode.Visible = false;
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_label_vsplus_smtmode_visiable(mFn, flag: false);
					}
					MainForm0.set_warningalarm_idle();
					panel_vsplus_pausestop.Visible = false;
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_pause_stop_button_visiable(mFn, flag: false);
					}
					panel_PCBE_OP.Enabled = true;
					panel_PcbEditPage.Enabled = true;
					set_finishautorun(v: false);
					checkBox_FinishAutoSmt.Visible = false;
					MainForm0.uc_VisualShowSmt[mFn].Visible = false;
				});
				BeginInvoke((MethodInvoker)delegate
				{
					MainForm0.mark_light_on_ext(mFn, flag: true);
					MainForm0.mark_led_on_ext(mFn, flag: true);
					MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: false);
					MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: false);
				});
				msmt_mode = SmtOpMode.Idle;
				return;
			}
			goto IL_01ad;
			IL_01ad:
			MainForm0.write_to_logFile("thd_AutoRun return");
			MainForm0.static_this.UI_Enable_SMT(mFn, flag: true);
			BeginInvoke((MethodInvoker)delegate
			{
				MainForm0.mark_light_on_ext(mFn, flag: true);
				MainForm0.mark_led_on_ext(mFn, flag: true);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: false);
				set_finishautorun(v: false);
				checkBox_FinishAutoSmt.Visible = false;
				MainForm0.uc_VisualShowSmt[mFn].Visible = false;
			});
		}

		private bool vsplus_smtbusy()
		{
			bool result = false;
			if (mthd_smtRun != null && mthd_smtRun.IsAlive)
			{
				result = true;
			}
			return result;
		}

		private void data_catcat()
		{
			bool flag = false;
			for (int i = 0; i < HW.mFnNum; i++)
			{
				flag = MainForm0.pcblist_to_cat(i);
				if (MainForm0.USR3B[i].mPointlistCat_History == null)
				{
					MainForm0.USR3B[i].mPointlistCat_History = new BindingList<ChipCategoryElement>();
				}
			}
			if (flag)
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Same chip type has different parameters, the table will set default value" : "相同元件的某些参数不一致，分类表格会将其呈现默认值！");
			}
			Form_datacatcat form_datacatcat = new Form_datacatcat();
			form_datacatcat.ShowDialog();
		}

		private int s_auto_smt_2inboard()
		{
			while (true)
			{
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return -1;
				}
				QnCommon.mPlayWoodState_Sensor = -1;
				MainForm0.mConDevExt[0].readPlayWoodState();
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					MainForm0.mDebugForm.readPlayWoodState();
				}
				int num = 100;
				while (true)
				{
					DateTime now = DateTime.Now;
					double num2 = 0.0;
					do
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						if (QnCommon.mPlayWoodState_Sensor != -1)
						{
							break;
						}
						Thread.Sleep(0);
						num2 = (DateTime.Now - now).TotalMilliseconds;
					}
					while (num2 < (double)num);
					if (num2 < (double)num)
					{
						break;
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].readPlayWoodState();
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						QnCommon.mPlayWoodState_Sensor = MainForm0.mDebugForm.get_S();
					}
				}
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					QnCommon.mInBoardState[mFn] = MainForm0.mDebugForm.get_InB();
					QnCommon.mOutBoardState[mFn] = MainForm0.mDebugForm.get_OutB();
				}
				if (QnCommon.mInBoardState[mFn] != 0 || QnCommon.mOutBoardState[mFn] != 0)
				{
					continue;
				}
				if ((QnCommon.mPlayWoodState_Sensor & 1) == 0 && (QnCommon.mPlayWoodState_Sensor & 4) == 0 && (QnCommon.mPlayWoodState_Sensor & 0x20) == 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(1);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IDLE" : "空闲状态");
					});
					continue;
				}
				if (((uint)QnCommon.mPlayWoodState_Sensor & 8u) != 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "PLS take away completed PCB!" : "出板位置检测到有板，请取走");
					});
					continue;
				}
				if (((uint)QnCommon.mPlayWoodState_Sensor & 0x20u) != 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0 && USR_INIT.mIsBCTEnabled && (QnCommon.mPlayWoodState_Sensor & 0x10) == 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "PLS clear back-end connect station!" : "后端接驳台不允许出板，请处理");
					});
					continue;
				}
				if (((uint)QnCommon.mPlayWoodState_Sensor & 0x20u) != 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0 && (!USR_INIT.mIsBCTEnabled || (USR_INIT.mIsBCTEnabled && ((uint)QnCommon.mPlayWoodState_Sensor & 0x10u) != 0)))
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD..." : "正在出板..");
					});
					QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Busy;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Busy);
					}
					MainForm0.static_this.misc_board_out(mFn, USR3B.mTrackSpeed, (int)(USR3B.mTrackDelay * 10f), USR_INIT.mIsBCTEnabled);
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.sendOutBoard();
					}
					DateTime now2 = DateTime.Now;
					double num3 = 0.0;
					while (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Busy && num3 <= 15000.0)
					{
						Thread.Sleep(10);
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						num3 = (DateTime.Now - now2).TotalMilliseconds;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							QnCommon.mOutBoardState[mFn] = MainForm0.mDebugForm.get_OutB();
						}
					}
					if (num3 > 15000.0)
					{
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD TIMEOUT..." : "出板超时..");
						});
						MainForm0.write_to_logFile("出板超时.." + Environment.NewLine);
						return -3;
					}
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -3;
						}
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD TIMEOUT..." : "出板失败，请务必检查并清理！");
						});
						return -3;
					}
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Ok)
					{
						QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Unknown);
						}
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD OK" : "出板成功");
						});
					}
					continue;
				}
				MainForm0.write_to_logFile(QnCommon.mPlayWoodState_Sensor.ToString("X2"));
				s_inborad = 0;
				if (((uint)QnCommon.mPlayWoodState_Sensor & (true ? 1u : 0u)) != 0 && (QnCommon.mPlayWoodState_Sensor & 4) == 0 && (QnCommon.mPlayWoodState_Sensor & 0x20) == 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					s_inborad = 1;
				}
				else if (((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0 && (QnCommon.mPlayWoodState_Sensor & 0x20) == 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					s_inborad = 2;
				}
				if (s_inborad != 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = "PCB" + s_inborad + ((USR_INIT.mLanguage == 2) ? "IN BOARD..." : "进板中...");
					});
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Busy;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Busy);
					}
					MainForm0.mConDevExt[0].sendInBoard(mFn, USR3B.mTrackSpeed, s_inborad - 1, 0);
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.sendInBoard();
					}
					DateTime now3 = DateTime.Now;
					double num4 = 0.0;
					while (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Busy && num4 <= 15000.0)
					{
						Thread.Sleep(10);
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						num4 = (DateTime.Now - now3).TotalMilliseconds;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							QnCommon.mInBoardState[mFn] = MainForm0.mDebugForm.get_InB();
						}
					}
					if (num4 > 15000.0)
					{
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = "PCB" + s_inborad + ((USR_INIT.mLanguage == 2) ? "IN BOARD TIMEOUT..." : "进板超时...");
						});
						MainForm0.write_to_logFile("PCB" + s_inborad + "进板超时.." + Environment.NewLine);
						return -3;
					}
					if (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -3;
						}
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = "PCB" + s_inborad + ((USR_INIT.mLanguage == 2) ? "IN BOARD TIMEOUT..." : "进板失败，请务必检查并清理！");
						});
						return -3;
					}
					if (QnCommon.mInBoardState[mFn] != QnCommon.BoardStateEn.Ok)
					{
						continue;
					}
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Unknown);
					}
					label_SmtState.Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = "PCB" + s_inborad + ((USR_INIT.mLanguage == 2) ? "IN BOARD OK, RUNING" : "进板成功，开始贴装");
					});
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					msmtchip_idx_raw = 0;
					msmtchip_idx = 0;
					mis_maybe_continue = 0;
					if (mthd_smtRun != null && mthd_smtRun.IsAlive)
					{
						mthd_smtRun.Abort();
						Thread.Sleep(100);
					}
					BindingList<int> bindingList = new BindingList<int>();
					bindingList.Add(mloop[s_inborad - 1]);
					mthd_smtRun = new Thread(thd_SmtLoop);
					mthd_smtRun.IsBackground = true;
					mthd_smtRun.Start(bindingList);
					MainForm0.static_this.UI_Enable_SMT(mFn, flag: false);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，正在贴装..");
					});
					Thread.Sleep(300);
					while (vsplus_smtbusy() || MainForm0.mRunDoing[mFn] != 0)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -2;
						}
						Thread.Sleep(100);
					}
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "贴装完成，等待出板..");
					});
					if (s_inborad == 2 && bIsFinishAutoRun)
					{
						break;
					}
				}
				else
				{
					Thread.Sleep(100);
				}
			}
			return -1;
		}

		public void pcbcheck_start(USR3_DATA usr3, bool is_automark)
		{
			if (is_automark)
			{
				Thread thread = new Thread(thd_pcbCheck);
				thread.IsBackground = true;
				thread.Start(usr3);
			}
			else
			{
				Thread thread2 = new Thread(thd_pcbCheck_manual);
				thread2.IsBackground = true;
				thread2.Start(usr3);
			}
		}

		public void thd_pcbCheck(object o)
		{
			MainForm0.common_waiting_start("开始识别Mark点...", 30);
			USR3_DATA usr3 = (USR3_DATA)o;
			mIsMarkTest = false;
			mIsMarkRecSuccess = false;
			thd_MarkTest(o);
			if (uc_PcbCheck == null || uc_PcbCheck.IsDisposed)
			{
				Invoke((MethodInvoker)delegate
				{
					MainForm0.write_to_logFile("Fn = " + (mFn + 1));
					uc_PcbCheck = new UserControl_PcbCheck(mFn, USR, USR2, usr3, USR3B, (usr3.mPointListOrder == 1) ? usr3.mPointlistSmt : usr3.mPointlist, mIsMarkRecSuccess);
					base.Controls.Add(uc_PcbCheck);
					uc_PcbCheck.cb_pcbcheck_start += pcbcheck_start;
					uc_PcbCheck.Location = new Point(0, 0);
					uc_PcbCheck.BringToFront();
				});
				MainForm0.common_waiting_break();
			}
			else
			{
				Invoke((MethodInvoker)delegate
				{
					uc_PcbCheck.pcbCheck_flushDataGridview(mIsMarkRecSuccess);
				});
				MainForm0.common_waiting_break();
			}
		}

		public void thd_pcbCheck_manual(object o)
		{
			USR3_DATA usr3 = (USR3_DATA)o;
			if (usr3.mPcbCheck == null)
			{
				usr3.mPcbCheck = new PCB_CHECK();
			}
			if (uc_PcbCheck == null || uc_PcbCheck.IsDisposed)
			{
				MainForm0.write_to_logFile("Fn = " + (mFn + 1));
				Invoke((MethodInvoker)delegate
				{
					uc_PcbCheck = new UserControl_PcbCheck(mFn, USR, USR2, usr3, USR3B, (usr3.mPointListOrder == 1) ? usr3.mPointlistSmt : usr3.mPointlist, MainForm0.uc_job[MainForm0.mFn].mIsMarkRecSuccess);
					base.Controls.Add(uc_PcbCheck);
					uc_PcbCheck.cb_pcbcheck_start += pcbcheck_start;
					uc_PcbCheck.Location = new Point(0, 0);
					uc_PcbCheck.BringToFront();
				});
			}
			else
			{
				Invoke((MethodInvoker)delegate
				{
					uc_PcbCheck.pcbCheck_flushDataGridview(MainForm0.uc_job[MainForm0.mFn].mIsMarkRecSuccess);
				});
			}
			if (uc_PcbCheck != null && !uc_PcbCheck.IsDisposed)
			{
				uc_PcbCheck.thd_manual_mark();
			}
		}

		public void set_edit(bool flag)
		{
			if (uc_dgv_list != null)
			{
				for (int i = 0; i < uc_dgv_list.Count; i++)
				{
					uc_dgv_list[i].SetEdit_XY(flag);
				}
			}
		}

		public void set_edit_curpcb(bool flag)
		{
			if (uc_dgv_list != null && mUSR3Idx >= 0 && mUSR3Idx < uc_dgv_list.Count)
			{
				uc_dgv_list[mUSR3Idx].SetEdit_XY(flag);
			}
		}

		public void sel_nearest_chip(Coordinate c)
		{
			uc_PcbCheck.pcbcheck_sel_mark_nearest_chip(c);
		}

		private int s_auto_smt_1duanshi()
		{
			while (true)
			{
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return -1;
				}
				QnCommon.mPlayWoodState_Sensor = -1;
				if (!MainForm0.mIsSimulation)
				{
					MainForm0.mConDevExt[0].readPlayWoodState();
				}
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					MainForm0.mDebugForm.readPlayWoodState();
				}
				int num = 100;
				while (true)
				{
					DateTime now = DateTime.Now;
					double num2 = 0.0;
					do
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						if (QnCommon.mPlayWoodState_Sensor != -1)
						{
							break;
						}
						Thread.Sleep(0);
						num2 = (DateTime.Now - now).TotalMilliseconds;
					}
					while (num2 < (double)num);
					if (num2 < (double)num)
					{
						break;
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].readPlayWoodState();
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						QnCommon.mPlayWoodState_Sensor = MainForm0.mDebugForm.get_S();
					}
				}
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					QnCommon.mInBoardState[mFn] = MainForm0.mDebugForm.get_InB();
					QnCommon.mOutBoardState[mFn] = MainForm0.mDebugForm.get_OutB();
				}
				if (QnCommon.mInBoardState[mFn] != 0 || QnCommon.mOutBoardState[mFn] != 0)
				{
					continue;
				}
				if ((QnCommon.mPlayWoodState_Sensor & 2) == 0 && (QnCommon.mPlayWoodState_Sensor & 4) == 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(1);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IDLE" : "空闲状态");
					});
				}
				else if (((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0 && ((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "PLS take away PCB from ENTRY!" : "进板和贴装处都有板，请先清理进板处");
					});
				}
				else if (((uint)QnCommon.mPlayWoodState_Sensor & 8u) != 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "PLS take away completed PCB!" : "出板位置检测到有板，请取走");
					});
				}
				else if ((QnCommon.mPlayWoodState_Sensor & 2) == 0 && ((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0 && USR_INIT.mIsBCTEnabled && ((uint)QnCommon.mPlayWoodState_Sensor & 0x10u) != 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "PLS clear back-end connect station!" : "后端接驳台不允许出板，请处理");
					});
				}
				else if ((QnCommon.mPlayWoodState_Sensor & 2) == 0 && ((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0 && (!USR_INIT.mIsBCTEnabled || (USR_INIT.mIsBCTEnabled && (QnCommon.mPlayWoodState_Sensor & 0x10) == 0)))
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					if (!MainForm0.mIsSimulation)
					{
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					}
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD..." : "正在出板..");
					});
					QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Busy;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Busy);
					}
					MainForm0.static_this.misc_board_out(mFn, USR3B.mTrackSpeed, (int)(USR3B.mTrackDelay * 10f), USR_INIT.mIsBCTEnabled);
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.sendOutBoard();
					}
					DateTime now2 = DateTime.Now;
					double num3 = 0.0;
					while (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Busy && num3 <= 15000.0)
					{
						Thread.Sleep(10);
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						num3 = (DateTime.Now - now2).TotalMilliseconds;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							QnCommon.mOutBoardState[mFn] = MainForm0.mDebugForm.get_OutB();
						}
					}
					if (num3 > 15000.0)
					{
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD TIMEOUT..." : "出板超时..");
						});
						MainForm0.write_to_logFile("出板超时.." + Environment.NewLine);
						return -3;
					}
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -3;
						}
						if (!MainForm0.mIsSimulation)
						{
							MainForm0.mConDevExt[0].sendSwitchSMTready(0);
						}
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD TIMEOUT..." : "出板失败，请务必检查并清理！");
						});
						return -3;
					}
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Ok)
					{
						QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Unknown);
						}
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						if (!MainForm0.mIsSimulation)
						{
							MainForm0.mConDevExt[0].sendSwitchSMTready(0);
						}
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD OK" : "出板成功");
						});
					}
				}
				else if (((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0 && (QnCommon.mPlayWoodState_Sensor & 4) == 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					if (!MainForm0.mIsSimulation)
					{
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					}
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD..." : "进板中...");
					});
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Busy;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Busy);
					}
					if (!MainForm0.mIsSimulation)
					{
						MainForm0.mConDevExt[0].sendInBoard(mFn, USR3B.mTrackSpeed, 0);
					}
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.sendInBoard();
					}
					DateTime now3 = DateTime.Now;
					double num4 = 0.0;
					while (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Busy && num4 <= 15000.0)
					{
						Thread.Sleep(10);
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						num4 = (DateTime.Now - now3).TotalMilliseconds;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							QnCommon.mInBoardState[mFn] = MainForm0.mDebugForm.get_InB();
						}
					}
					if (num4 > 15000.0)
					{
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD TIMEOUT..." : "进板超时...");
						});
						MainForm0.write_to_logFile("进板超时.." + Environment.NewLine);
						return -3;
					}
					if (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -3;
						}
						if (!MainForm0.mIsSimulation)
						{
							MainForm0.mConDevExt[0].sendSwitchSMTready(0);
						}
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD TIMEOUT..." : "进板失败，请务必检查并清理！");
						});
						return -3;
					}
					if (QnCommon.mInBoardState[mFn] != QnCommon.BoardStateEn.Ok)
					{
						continue;
					}
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Unknown);
					}
					label_SmtState.Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD OK, RUNING" : "进板成功，开始贴装");
					});
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					mloop_idx = 0;
					msmtchip_idx_raw = 0;
					msmtchip_idx = 0;
					mis_maybe_continue = 0;
					if (mthd_smtRun != null && mthd_smtRun.IsAlive)
					{
						mthd_smtRun.Abort();
						Thread.Sleep(100);
					}
					mthd_smtRun = new Thread(thd_SmtLoop);
					mthd_smtRun.IsBackground = true;
					mthd_smtRun.Start(mloop);
					MainForm0.static_this.UI_Enable_SMT(mFn, flag: false);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，正在贴装..");
					});
					Thread.Sleep(300);
					while (vsplus_smtbusy() || MainForm0.mRunDoing[mFn] != 0)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -2;
						}
						Thread.Sleep(100);
					}
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "贴装完成，等待出板..");
					});
					if (bIsFinishAutoRun)
					{
						break;
					}
				}
				else
				{
					Thread.Sleep(100);
				}
			}
			return -1;
		}

		private void __button_PauseSmt_Click(object sender, EventArgs e)
		{
			if ((string)button_PauseSmt.Tag == "pause")
			{
				MainForm0.mRunDoing[mFn] |= 1;
				button_PauseSmt.Text = ((USR_INIT.mLanguage == 2) ? "Resume" : "恢复");
				button_PauseSmt.Tag = "resume";
			}
			else if ((string)button_PauseSmt.Tag == "resume")
			{
				MainForm0.mRunDoing[mFn] = 0;
				button_PauseSmt.Text = ((USR_INIT.mLanguage == 2) ? "Pause" : "暂停");
				button_PauseSmt.Tag = "pause";
			}
		}

		private void __button_vsplus_startsmt_Click(object sender, EventArgs e)
		{
			vsplus_startsmt(0, 0f, SmtOpMode.Idle);
		}

		private void __button_vsplus_continuesmt_Click(object sender, EventArgs e)
		{
			vsplus_continuesmt();
		}

		public void vsplus_continuesmt()
		{
			vsplus_startsmt(mis_maybe_continue, msmt_curhaiba, SmtOpMode.Idle);
		}

		public void clear_continuemode()
		{
			mis_maybe_continue = 0;
			Invoke((MethodInvoker)delegate
			{
				button_vsplus_startsmt.Visible = ((mis_maybe_continue == 0) ? true : false);
				if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
				{
					MainForm0.uc_smtRunning.set_cnButton_vsplus_startsmt_visiable(mFn, (mis_maybe_continue == 0) ? true : false);
				}
			});
		}

		public void vsplus_startsmt(int continue_mode, float haiba, SmtOpMode ipsmtmode)
		{
			switch (MainForm0.__wind_checkget_software_state(1))
			{
			case 2:
			case 3:
			case 4:
				return;
			case 0:
				if (USR3.mPointlist.Count > 150)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Trail version, max place chip count is " : ("试用版本限制，一次贴装芯片数量最多不超过" + 150));
					return;
				}
				if (msmt_real_loops >= 10)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Trail version, max place PCB count is " : ("试用版本限制，贴装PCB数量超过" + 10 + ", 请手动重启软件才能继续贴装"));
					return;
				}
				if (MainForm0.mSmtMiles >= 120000)
				{
					MainForm0.CmMessageBoxTop_Ok(((USR_INIT.mLanguage == 2) ? "Override Max place miles " : "已超过最高贴装里程") + 120000 + ((USR_INIT.mLanguage == 2) ? "Trail End, please contact with HWGC" : ", 试用结束，请联系厂家获得授权"));
					return;
				}
				break;
			}
			if (MainForm0.pcbsmt_legalcheck(mFn, must_show: false) != 0 && !USR3B.mIsJieBoTaiMode)
			{
				return;
			}
			if (HW.mDeviceType != DeviceType.HW_4SG_44 && HW.mDeviceType != DeviceType.HW_4SG_50 && HW.mDeviceType != DeviceType.HW_4_42 && HW.mDeviceType != 0 && HW.mDeviceType != DeviceType.HW_6 && HW.mDeviceType != DeviceType.DUDU_400_50K && HW.mDeviceType != DeviceType.DUDU_400 && HW.mDeviceType != DeviceType.DUDU_800 && HW.mDeviceType != DeviceType.DUDU_800_E && HW.mDeviceType != DeviceType.DSQ800_120F && USR_INIT.mIsNotFeederGoodbye)
			{
				string[] array = new string[3]
				{
					"警告：\"飞达防撞\"选项未勾选，存在安全隐患，是否继续？" + Environment.NewLine + "（设备安装了飞达防撞传感器硬件，功能才生效）",
					"警告：\"飞达防撞\"选项未勾选，存在安全隐患，是否继续？" + Environment.NewLine + "（设备安装了飞达防撞传感器硬件，功能才生效）",
					"Warning: [Feeder Collision Avoidance] option is not selected in System Setting Page, continue?"
				};
				if (MainForm0.CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
			}
			if (USR.mDebug_IsSaveErrBitmap && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Notice: Save Err Picture mode is opened, still continue?" : "友情提示：\"保存错误图片\"调试模式被勾选，请知悉！", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			if (USR3B.mIsMountStacksNew != null)
			{
				bool flag = false;
				if (USR3B.mFeederInstallList != null)
				{
					for (int i = 0; i < USR3B.mFeederInstallList.Count; i++)
					{
						int stacktype = (int)USR3B.mFeederInstallList[i].Stacktype;
						int num = USR3B.mFeederInstallList[i].Stack_no - 1;
						if (USR3B.mIsMountStacksNew[stacktype] != null && num < USR3B.mIsMountStacksNew[stacktype].Count() && !USR3B.mIsMountStacksNew[stacktype][num])
						{
							flag = true;
							break;
						}
					}
				}
				if (flag && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Notice: There is array boards not going to be mounted" : "友情提示：有部分料站/料盘在“是否贴装”里被设置为不贴装，是否继续？", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
				flag = false;
				for (int j = 0; j < mUSR3List.Count; j++)
				{
					USR3_DATA uSR3_DATA = mUSR3List[j];
					for (int k = 0; k < uSR3_DATA.mIsArrayMount.Count(); k++)
					{
						if (!uSR3_DATA.mIsArrayMount[k])
						{
							flag = true;
							break;
						}
						if (uSR3_DATA.mIsPcbAix && !uSR3_DATA.mIsArrayAixMount[k])
						{
							flag = true;
							break;
						}
					}
				}
				if (flag && MainForm0.CmMessageBox((USR_INIT.mLanguage == 2) ? "Notice: There is array boards not going to be mounted" : "友情提示：有部分拼板在“是否贴装”里被设置为不贴装，是否继续？", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
			}
			vsplusForm_SmtStart vsplusForm_SmtStart = new vsplusForm_SmtStart(mFn, USR3B, mUSR3List, mUSR3Idx, haiba, continue_mode);
			switch (ipsmtmode)
			{
			case SmtOpMode.CurLoop:
				msmt_curhaiba = 0f;
				msmt_mode = SmtOpMode.CurLoop;
				break;
			case SmtOpMode.AutoRun:
				msmt_curhaiba = 0f;
				msmt_mode = SmtOpMode.AutoRun;
				break;
			case SmtOpMode.ContinueLoop:
				msmt_mode = SmtOpMode.ContinueLoop;
				break;
			case SmtOpMode.Idle:
				vsplusForm_SmtStart.button_subpcb_sel += button_subpcb_sel;
				if (HW.mFnNum == 2)
				{
					vsplusForm_SmtStart.StartPosition = FormStartPosition.Manual;
					vsplusForm_SmtStart.Location = new Point((640 - vsplusForm_SmtStart.Size.Width) / 2 + 620 * mFn, (990 - vsplusForm_SmtStart.Size.Height) / 2);
				}
				if (vsplusForm_SmtStart.ShowDialog() == DialogResult.Cancel)
				{
					return;
				}
				msmt_mode = vsplusForm_SmtStart.get_smtmode();
				msmt_curhaiba = vsplusForm_SmtStart.get_init_haiba();
				break;
			}
			if (msmt_mode == SmtOpMode.CurPcb && !mUSR3List[mUSR3Idx].mIsPcbChecked)
			{
				MainForm0.CmMessageBoxTop_Ok("当前PCB板已被设置为不贴装!");
				return;
			}
			label_vsplus_smtmode.BringToFront();
			label_vsplus_smtmode.Visible = true;
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_label_vsplus_smtmode_visiable(mFn, flag: true);
			}
			button_vsplus_startsmt.Visible = false;
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_cnButton_vsplus_startsmt_visiable(mFn, flag: false);
			}
			panel_vsplus_pausestop.Visible = true;
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_pause_stop_button_visiable(mFn, flag: true);
			}
			MainForm0.set_warningalarm_run();
			mIsChipsOnHead = false;
			Is_YouXian_Pik_Done = false;
			mSyncpik_SmtMask = new bool[HW.mZnNum[mFn]];
			BeginInvoke((MethodInvoker)delegate
			{
				MainForm0.mark_light_on_ext(mFn, flag: false);
				MainForm0.mark_led_on_ext(mFn, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: false);
			});
			MainForm0.moveToZero_ZA_andWait(mFn);
			if (msmt_mode == SmtOpMode.AutoRun)
			{
				if ((mloop_update() || USR3B.mIsJieBoTaiMode) && (ipsmtmode != 0 || loukong_state_confirm()))
				{
					if (QnCommon.mIsShapeOpen[mFn] && USR3B.mIsYouxianPik)
					{
						MainForm0.CmMessageBoxTop_Ok("开盖状态下不支持优先取料!");
					}
					label_vsplus_smtmode.Text = (new string[3] { "全自动运行", "全自動運行", "Auto Running" })[USR_INIT.mLanguage];
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text);
					}
					if (mthd_autoRun != null && mthd_autoRun.IsAlive)
					{
						mthd_autoRun.Abort();
					}
					mthd_autoRun = new Thread(thd_AutoRun);
					mthd_autoRun.IsBackground = true;
					mthd_autoRun.Start();
					mis_maybe_continue = 0;
					return;
				}
			}
			else
			{
				if (msmt_mode == SmtOpMode.CurPcb)
				{
					if (mloop == null)
					{
						mloop = new BindingList<int>();
					}
					mloop.Clear();
					mloop.Add(mUSR3Idx);
					mloop_idx = 0;
					msmtchip_idx_raw = vsplusForm_SmtStart.get_pcb_startchip();
					mis_maybe_continue = 0;
					msmtgroup_idx_raw = -1;
					label_vsplus_smtmode.Text = (new string[3] { "单贴 ", "單貼 ", "Run " })[USR_INIT.mLanguage] + mUSR3List[mloop[mloop_idx]].mPcbID;
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text);
					}
				}
				else if (msmt_mode == SmtOpMode.ContinuePcb)
				{
					if (USR3B.mInBoardMode == 1)
					{
						mloop.Clear();
						mloop.Add(mUSR3Idx);
						label_vsplus_smtmode.Text = (new string[3] { "续贴 ", "續貼 ", "Continue " })[USR_INIT.mLanguage] + mUSR3List[mloop[mloop_idx]].mPcbID;
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text);
						}
					}
					else
					{
						label_vsplus_smtmode.Text = (new string[3] { "续贴 ", "續貼 ", "Continue " })[USR_INIT.mLanguage] + mUSR3List[mloop[mloop_idx]].mPcbID;
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text);
						}
					}
				}
				else if (msmt_mode == SmtOpMode.CurLoop || msmt_mode == SmtOpMode.CurLoop_AutoRun)
				{
					if (!mloop_update())
					{
						goto IL_0d18;
					}
					mloop_idx = vsplusForm_SmtStart.get_loop_startloop();
					msmtchip_idx_raw = vsplusForm_SmtStart.get_loop_startchip();
					mis_maybe_continue = 0;
					msmtgroup_idx_raw = -1;
					label_vsplus_smtmode.Text = (new string[3] { "手动单贴", "手動單貼", "Manual Run" })[USR_INIT.mLanguage];
					if (USR3B.mPrjMode == 1)
					{
						label_vsplus_smtmode.Text += (new string[3] { " 板组", " 板組", " PCBs" })[USR_INIT.mLanguage];
					}
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text);
					}
					if (msmt_mode == SmtOpMode.CurLoop_AutoRun)
					{
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text + " " + (new string[3] { "+ 全自动", "+ 全自動", "+ Auto Run" })[USR_INIT.mLanguage]);
						}
						Label label = label_vsplus_smtmode;
						label.Text = label.Text + Environment.NewLine + (new string[3] { "+ 全自动", "+ 全自動", "+ Auto Run" })[USR_INIT.mLanguage];
					}
				}
				else if (msmt_mode == SmtOpMode.ContinueLoop || msmt_mode == SmtOpMode.ContinueLoop_AutoRun)
				{
					if (!mloop_update())
					{
						goto IL_0d18;
					}
					label_vsplus_smtmode.Text = (new string[3] { "手动续贴", "手動續貼", "Manual Continue" })[USR_INIT.mLanguage];
					if (USR3B.mPrjMode == 1)
					{
						label_vsplus_smtmode.Text += (new string[3] { " 板组", " 板組", " PCBs" })[USR_INIT.mLanguage];
					}
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text);
					}
					if (msmt_mode == SmtOpMode.ContinueLoop_AutoRun)
					{
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_vsplus_smtmode_string(mFn, label_vsplus_smtmode.Text + " " + (new string[3] { "+ 全自动", "+ 全自動", "+ Auto Run" })[USR_INIT.mLanguage]);
						}
						Label label2 = label_vsplus_smtmode;
						label2.Text = label2.Text + Environment.NewLine + (new string[3] { "+ 全自动", "+ 全自動", "+ Auto Run" })[USR_INIT.mLanguage];
					}
				}
				int num2 = mloop_calcBigTab();
				if (num2 != -1 || MainForm0.CmMessageBox("有超行程的元器件，贴装会产生风险，是否继续?", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					msmtchip_idx = 0;
					if (mthd_smtRun != null && mthd_smtRun.IsAlive)
					{
						mthd_smtRun.Abort();
						Thread.Sleep(100);
					}
					mthd_smtRun = new Thread(thd_SmtLoop);
					mthd_smtRun.IsBackground = true;
					mthd_smtRun.Start(mloop);
					MainForm0.static_this.UI_Enable_SMT(mFn, flag: false);
					return;
				}
			}
			goto IL_0d18;
			IL_0d18:
			button_vsplus_startsmt.Visible = ((mis_maybe_continue == 0) ? true : false);
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_cnButton_vsplus_startsmt_visiable(mFn, (mis_maybe_continue == 0) ? true : false);
			}
			label_vsplus_smtmode.Visible = false;
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_label_vsplus_smtmode_visiable(mFn, flag: false);
			}
			MainForm0.set_warningalarm_idle();
			panel_vsplus_pausestop.Visible = false;
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_pause_stop_button_visiable(mFn, flag: false);
			}
			label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "Idle ..." : "空闲");
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
			}
			checkBox_FinishAutoSmt.Visible = false;
			msmt_mode = SmtOpMode.Idle;
			BeginInvoke((MethodInvoker)delegate
			{
				MainForm0.mark_light_on_ext(mFn, flag: true);
				MainForm0.mark_led_on_ext(mFn, flag: true);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.Fast, flag: false);
				MainForm0.fhcam_led_on_ext(mFn, CameraType.High, flag: false);
			});
		}

		private bool mloop_update()
		{
			if (mloop == null)
			{
				mloop = new BindingList<int>();
			}
			mloop.Clear();
			if (USR3B.mPrjMode == 0)
			{
				if (mUSR3List != null && mUSR3List.Count >= 0 && mUSR3Idx < mUSR3List.Count && mUSR3Idx >= 0 && mUSR3List[mUSR3Idx].mPointlistSmt.Count > 0)
				{
					mloop.Add(mUSR3Idx);
				}
			}
			else if (USR3B.mPrjMode == 1 && mUSR3List != null && mUSR3List.Count >= 0)
			{
				for (int i = 0; i < mUSR3List.Count; i++)
				{
					if (mUSR3List[i].mIsPcbChecked && mUSR3List[i].mPointlistSmt.Count > 0)
					{
						mloop.Add(i);
					}
				}
			}
			if (mloop.Count == 0 && !USR3B.mIsJieBoTaiMode)
			{
				MainForm0.CmMessageBoxTop_Ok("没有可贴的PCB工程!");
			}
			if (mloop.Count <= 0)
			{
				return false;
			}
			return true;
		}

		private bool vsplus_automark(USR3_DATA usr3)
		{
			bool result = false;
			MainForm0.mConDevExt[mFn].sendexetueplywood(mFn, 1);
			if (MainForm0.mCurCam[mFn] != 0)
			{
				if (MainForm0.uc_usroperarion != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
				{
					MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
				}
				Thread.Sleep(50);
			}
			if ((MainForm0.mRunDoing[mFn] & 2) == 0)
			{
				if (mMarkFound == null)
				{
					mMarkFound = new Coordinate[2];
				}
				Invoke((MethodInvoker)delegate
				{
					if (uc_smtMarkRecognition != null)
					{
						if (!uc_smtMarkRecognition.IsDisposed)
						{
							uc_smtMarkRecognition.Dispose();
						}
						uc_smtMarkRecognition = null;
					}
					if (uc_smtMarkRecognition == null || uc_smtMarkRecognition.IsDisposed)
					{
						uc_smtMarkRecognition = new UserControl_SmtMarkRecognize(mFn, USR, usr3, 0, isauto: true);
						uc_smtMarkRecognition.Visible = false;
					}
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed && MainForm0.uc_smtRunning.Visible)
					{
						MainForm0.uc_smtRunning.ucs_singlesmt[mFn].Controls.Add(uc_smtMarkRecognition);
						uc_smtMarkRecognition.Location = new Point(337, 6);
					}
					else
					{
						panel_SmtProducePage.Controls.Add(uc_smtMarkRecognition);
						uc_smtMarkRecognition.Location = new Point(217, 6);
					}
					uc_smtMarkRecognition.BringToFront();
				});
				int ch = HW.mMarkCamItem[mFn].index[0];
				int markno = 0;
				while (true)
				{
					if (markno < 2)
					{
						mMarkFound[markno].X = usr3.mMark[markno].X;
						mMarkFound[markno].Y = usr3.mMark[markno].Y;
						if (usr3.mIsMarkSearch[markno])
						{
							mMarkFound[markno].X = usr3.mMarkSearch[markno].X;
							mMarkFound[markno].Y = usr3.mMarkSearch[markno].Y;
						}
						MainForm0.set_camera_parameter(ch, usr3.mMarkPara[markno].mPara.mParaCam);
						MainForm0.mark_lightlevel_set(mFn, usr3.mMarkPara[markno].mPara.mParaLed);
						MainForm0.mark_light_on(mFn, usr3.mMarkPara[markno].mPara.mLightOn);
						MainForm0.mark_led_on(mFn, usr3.mMarkPara[markno].mPara.mLedOn);
						bool is_automark = !USR3B.mIsManualMark;
						Invoke((MethodInvoker)delegate
						{
							uc_smtMarkRecognition.set_mode(usr3, markno, is_automark, is_automark ? "自动匹配" : "手动确认");
							uc_smtMarkRecognition.Visible = true;
							uc_smtMarkRecognition.BringToFront();
						});
						mbMarkDoneMutex = false;
						if (is_automark)
						{
							bool flag = mark_recognize2(markno, usr3.mMarkPara[markno].mode, USR3B.mSmtXYSpeed, usr3.mMarkSearch[markno], ref mMarkFound[markno]);
							if (uc_smtMarkRecognition.get_mark_ok() != 0)
							{
								flag = false;
							}
							if (MainForm0.mIsSimulation)
							{
								flag = true;
							}
							if (flag)
							{
								result = true;
								mbMarkDoneMutex = true;
								Invoke((MethodInvoker)delegate
								{
									uc_smtMarkRecognition.set_mark_ok();
									uc_smtMarkRecognition.Visible = false;
								});
								MainForm0.write_to_logFile("自动MARK" + (markno + 1) + "成功");
							}
							else
							{
								MainForm0.write_to_logFile("自动MARK" + (markno + 1) + "失败");
								if ((mthd_stop != null && mthd_stop.IsAlive) || !USR3B.mIsAutoFail_then_ManualMark)
								{
									result = false;
									break;
								}
								MainForm0.start_buzzer_warning(mFn);
								is_automark = false;
								Invoke((MethodInvoker)delegate
								{
									MainForm0.write_to_logFile("切换为手动MARK");
									uc_smtMarkRecognition.set_mode(usr3, markno, is_automark, "自动匹配失败，切换为手动确认");
									uc_smtMarkRecognition.BringToFront();
								});
								if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed && MainForm0.uc_smtRunning.Visible)
								{
									if (HW.mFnNum == 2)
									{
										while (MainForm0.uc_job[1 - mFn].mManualMarkSycn)
										{
											if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
											{
												goto end_IL_0601;
											}
											Thread.Sleep(50);
										}
										mManualMarkSycn = true;
									}
									Invoke((MethodInvoker)delegate
									{
										MainForm0.uc_smtRunning.Visible = false;
										panel_SmtProducePage.Controls.Add(uc_smtMarkRecognition);
										uc_smtMarkRecognition.Location = new Point(217, 6);
										uc_smtMarkRecognition.BringToFront();
										MainForm0.static_this.set_tabControl_dsq(mFn);
										MainForm0.uc_job[mFn].tabControl_mainwork.SelectedIndex = 1;
									});
								}
								MainForm0.static_this.UI_Enable_SMT(mFn, flag: true);
							}
						}
						else
						{
							if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed && MainForm0.uc_smtRunning.Visible)
							{
								if (HW.mFnNum == 2)
								{
									while (MainForm0.uc_job[1 - mFn].mManualMarkSycn)
									{
										if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
										{
											goto end_IL_0601;
										}
										Thread.Sleep(50);
									}
									mManualMarkSycn = true;
								}
								Invoke((MethodInvoker)delegate
								{
									MainForm0.uc_smtRunning.Visible = false;
									panel_SmtProducePage.Controls.Add(uc_smtMarkRecognition);
									uc_smtMarkRecognition.Location = new Point(217, 6);
									uc_smtMarkRecognition.BringToFront();
									MainForm0.static_this.set_tabControl_dsq(mFn);
									MainForm0.uc_job[mFn].tabControl_mainwork.SelectedIndex = 1;
								});
							}
							MainForm0.moveToXY_andWait_Smt(mFn, USR3B.mSmtXYSpeed, usr3.mMarkSearch[markno]);
							MainForm0.static_this.UI_Enable_SMT(mFn, flag: true);
						}
						while (!mbMarkDoneMutex)
						{
							Thread.Sleep(2);
						}
						MainForm0.stop_buzzer_warning(mFn);
						switch (uc_smtMarkRecognition.get_mark_ok())
						{
						case 0:
							result = true;
							if (!MainForm0.mIsSimulation)
							{
								mMarkFound[markno].X = MainForm0.mCur[mFn].x;
								mMarkFound[markno].Y = MainForm0.mCur[mFn].y;
							}
							goto IL_05f2;
						case 1:
							MainForm0.mRunDoing[mFn] = 0;
							result = false;
							break;
						case 2:
							result = false;
							break;
						default:
							goto IL_05f2;
						}
						break;
					}
					if (!fun_isNewMarkReasonable(USR3.mMark, mMarkFound) && !MainForm0.mIsSimulation)
					{
						MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Current MARK is far different from PCB MARK, please check!" : "系统发现当前确认的Mark点，与工程板的Mark点位置关系差异过大，请检查！");
						result = false;
						break;
					}
					MainForm0.write_to_logFile("Mark1:" + MainForm0.format_XY_label_string(mMarkFound[0]));
					MainForm0.write_to_logFile("Mark2:" + MainForm0.format_XY_label_string(mMarkFound[1]));
					for (int i = 0; i < usr3.mBigTab.Count; i++)
					{
						BIGTAB_GROUP bIGTAB_GROUP = usr3.mBigTab[i];
						for (int j = 0; j < bIGTAB_GROUP.mnt_arr.Count; j++)
						{
							BIGTAB_2_ITEM bIGTAB_2_ITEM = bIGTAB_GROUP.mnt_arr[j];
							Coordinate coordinate = fun_newxy(usr3.mMark, mMarkFound, new Coordinate(bIGTAB_2_ITEM.mnt_x_org, bIGTAB_2_ITEM.mnt_y_org));
							bIGTAB_2_ITEM.mnt_x_m = (int)coordinate.X;
							bIGTAB_2_ITEM.mnt_y_m = (int)coordinate.Y;
							bIGTAB_2_ITEM.mnt_x = (int)(coordinate.X - USR.mDeltaNozzle[0][bIGTAB_2_ITEM.zn].X);
							bIGTAB_2_ITEM.mnt_y = (int)(coordinate.Y - USR.mDeltaNozzle[0][bIGTAB_2_ITEM.zn].Y);
							bIGTAB_2_ITEM.mnt_a = bIGTAB_2_ITEM.mnt_a_org + (float)(fun_angle(usr3.mMark, mMarkFound) * 180.0 / Math.PI);
						}
					}
					break;
					IL_05f2:
					markno++;
					continue;
					end_IL_0601:
					break;
				}
			}
			BeginInvoke((MethodInvoker)delegate
			{
				MainForm0.static_this.UI_ControlEnable(mFn, flag: false, MainForm0.UI_ENABLE.SMT);
				if (uc_smtMarkRecognition != null && !uc_smtMarkRecognition.IsDisposed)
				{
					uc_smtMarkRecognition.Visible = false;
				}
				if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed && !MainForm0.uc_smtRunning.Visible)
				{
					MainForm0.uc_smtRunning.Visible = true;
				}
			});
			mManualMarkSycn = false;
			return result;
		}

		public bool mark_recognize2(int markno, MarkModeType marktype, int speed, Coordinate startPoint, ref Coordinate resultPoint)
		{
			if (MainForm0.uc_usroperarion[mFn] != null && !MainForm0.uc_usroperarion[mFn].IsDisposed)
			{
				MainForm0.uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
			}
			MainForm0.moveToXY_andWait(mFn, speed, startPoint);
			Coordinate coordinate = new Coordinate(1L, 1L);
			int num = 20;
			int num2 = 5;
			double num3 = 1.0;
			do
			{
				double[] array = new double[2];
				switch (ImageVisual_stillAnd_MarkMatch(markno, array))
				{
				case 1:
				{
					num2 = 1;
					double num4 = Math.Pow(array[0], 2.0) + Math.Pow(array[1], 2.0);
					if (num4 < num3)
					{
						resultPoint.X = MainForm0.mCur[mFn].x;
						resultPoint.Y = MainForm0.mCur[mFn].y;
						MainForm0.write_to_logFile("Mark 进行成功 count=" + num + " d_2=" + num4);
						return true;
					}
					if (num > 17)
					{
						coordinate.X = (long)((double)MainForm0.mCur[mFn].x + (array[0] + 0.5) * (double)USR.mMarkCamRatio[0]);
						coordinate.Y = (long)((double)MainForm0.mCur[mFn].y - (array[1] + 0.5) * (double)USR.mMarkCamRatio[0]);
					}
					else
					{
						double num5 = array[0];
						double num6 = array[1];
						coordinate.X = (long)((double)MainForm0.mCur[mFn].x + ((Math.Abs(num5) < 2.0) ? ((double)((num5 > 0.0) ? 1 : ((num5 < 0.0) ? (-1) : 0))) : num5) + 0.5);
						coordinate.Y = (long)((double)MainForm0.mCur[mFn].y - ((Math.Abs(num6) < 2.0) ? ((double)((num6 > 0.0) ? 1 : ((num6 < 0.0) ? (-1) : 0))) : num6) + 0.5);
					}
					MainForm0.moveToXY_andWait(mFn, speed, coordinate);
					MainForm0.write_to_logFile("Mark 进行 count=" + num + " d_2=" + num4);
					break;
				}
				case 0:
					if (num2 > 0)
					{
						num2--;
						break;
					}
					MainForm0.write_to_logFile("未识别到Mark点！");
					return false;
				case -1:
					MainForm0.CmMessageBoxTop_Ok("未定制精准MARK，请定制之后再使用MARK精准识别，或者使用MARK普通识别方式！");
					return false;
				}
				if (num <= 1 && num3 < 2.0)
				{
					num3 += 1.0;
					num = 20;
				}
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return false;
				}
			}
			while (num-- > 0);
			return false;
		}

		public bool fun_isNewMarkReasonable(Coordinate[] Mark, Coordinate[] newMark)
		{
			double num = Math.Sqrt((Mark[0].X - Mark[1].X) * (Mark[0].X - Mark[1].X) + (Mark[0].Y - Mark[1].Y) * (Mark[0].Y - Mark[1].Y));
			double num2 = Math.Sqrt((newMark[0].X - newMark[1].X) * (newMark[0].X - newMark[1].X) + (newMark[0].Y - newMark[1].Y) * (newMark[0].Y - newMark[1].Y));
			if (!(Math.Abs(num2 - num) < 200.0))
			{
				return false;
			}
			return true;
		}

		public double fun_angle(Coordinate[] Mark, Coordinate[] newMark)
		{
			return Math.Atan2(newMark[1].Y - newMark[0].Y, newMark[1].X - newMark[0].X) - Math.Atan2(Mark[1].Y - Mark[0].Y, Mark[1].X - Mark[0].X);
		}

		public Coordinate fun_newxy(Coordinate[] Mark, Coordinate[] newMark, Coordinate P)
		{
			Coordinate coordinate = new Coordinate();
			long num = (Mark[0].X - Mark[1].X) * (Mark[0].X - Mark[1].X) + (Mark[0].Y - Mark[1].Y) * (Mark[0].Y - Mark[1].Y);
			long num2 = (newMark[0].X - newMark[1].X) * (newMark[0].X - newMark[1].X) + (newMark[0].Y - newMark[1].Y) * (newMark[0].Y - newMark[1].Y);
			long num3 = newMark[0].X;
			long num4 = newMark[0].Y;
			long num5 = newMark[1].X;
			long num6 = newMark[1].Y;
			long num7 = (Mark[0].X - P.X) * (Mark[0].X - P.X) + (Mark[0].Y - P.Y) * (Mark[0].Y - P.Y);
			long num8 = (Mark[1].X - P.X) * (Mark[1].X - P.X) + (Mark[1].Y - P.Y) * (Mark[1].Y - P.Y);
			double num9 = Math.Sqrt((double)num7 * (double)num2 / (double)num);
			double num10 = Math.Sqrt((double)num8 * (double)num2 / (double)num);
			double num11 = Math.Atan2(Mark[1].Y - Mark[0].Y, Mark[1].X - Mark[0].X);
			double num12 = Math.Atan2(newMark[1].Y - newMark[0].Y, newMark[1].X - newMark[0].X);
			double num13 = Math.Atan2(P.Y - Mark[0].Y, P.X - Mark[0].X);
			double num14 = num13 - num11;
			double num15 = num12 + num14;
			double num16 = num9 * Math.Cos(num15) + (double)num3;
			double num17 = num9 * Math.Sin(num15) + (double)num4;
			double num18 = Math.Atan2(P.Y - Mark[1].Y, P.X - Mark[1].X);
			double num19 = num18 - num11;
			double num20 = num12 + num19;
			double num21 = num10 * Math.Cos(num20) + (double)num5;
			double num22 = num10 * Math.Sin(num20) + (double)num6;
			coordinate.X = (long)((num16 + num21) / 2.0 + 0.5);
			coordinate.Y = (long)((num17 + num22) / 2.0 + 0.5);
			return coordinate;
		}

		public void vsplus_mark_test(USR3_DATA usr3)
		{
			mIsMarkTest = true;
			Thread thread = new Thread(thd_MarkTest);
			thread.IsBackground = true;
			thread.Start(usr3);
		}

		public void thd_MarkTest(object o)
		{
			USR3_DATA uSR3_DATA = (USR3_DATA)o;
			int num = HW.mMarkCamItem[mFn].index[0];
			Coordinate[] array = new Coordinate[2]
			{
				new Coordinate(uSR3_DATA.mMark[0].X, uSR3_DATA.mMark[0].Y),
				new Coordinate(uSR3_DATA.mMark[1].X, uSR3_DATA.mMark[1].Y)
			};
			mIsMarkRecSuccess = false;
			if (USR3.mIsMarkSearch[0])
			{
				array[0] = new Coordinate(uSR3_DATA.mMarkSearch[0].X, uSR3_DATA.mMarkSearch[0].Y);
			}
			if (USR3.mIsMarkSearch[1])
			{
				array[1] = new Coordinate(uSR3_DATA.mMarkSearch[1].X, uSR3_DATA.mMarkSearch[1].Y);
			}
			MainForm0.moveToZero_Z_andWait(mFn);
			MarkCamPara markCamPara = new MarkCamPara(USR.mMarkCamPara[USR.mMarkCamParaIndex], USR.mIsMarkLightOn, USR.mIsMarkLedOn);
			if (uSR3_DATA.mPcbCheck == null)
			{
				uSR3_DATA.mPcbCheck = new PCB_CHECK();
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < 2)
				{
					if (mIsMarkTest)
					{
						MainForm0.CmMessageBoxTop_Ok("MARK" + (num2 + 1) + ((USR_INIT.mLanguage == 2) ? " Test Start... " : " 识别测试 开始..."));
					}
					MainForm0.set_camera_parameter(num, uSR3_DATA.mMarkPara[num2].mPara.mParaCam);
					MainForm0.mark_lightlevel_set(mFn, uSR3_DATA.mMarkPara[num2].mPara.mParaLed);
					MainForm0.mark_light_on(mFn, uSR3_DATA.mMarkPara[num2].mPara.mLightOn);
					MainForm0.mark_led_on(mFn, uSR3_DATA.mMarkPara[num2].mPara.mLedOn);
					if (num2 == 1)
					{
						array[1] = new Coordinate(mMarkFound[0].X + uSR3_DATA.mMark[1].X - uSR3_DATA.mMark[0].X, mMarkFound[0].Y + uSR3_DATA.mMark[1].Y - uSR3_DATA.mMark[0].Y);
					}
					if (mark_recognize2(num2, uSR3_DATA.mMarkPara[num2].mode, USR.mXYSpeed, array[num2], ref mMarkFound[num2]))
					{
						int num3 = (int)(150f * (float)MainForm0.mJvs_rawHeight / (float)MainForm0.mJvs_usrHeight);
						Rectangle destRect = new Rectangle(0, 0, 150, 150);
						Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - 150) / 2, (MainForm0.mJvs_rawHeight - num3) / 2, 150, num3);
						Bitmap bitmap = new Bitmap(150, 150);
						if (!MainForm0.mIsSimulation)
						{
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.DrawImage(MainForm0.mJVSBitmap[num], destRect, srcRect, GraphicsUnit.Pixel);
							graphics.Dispose();
						}
						else
						{
							bitmap = new Bitmap(MainForm0.SIGN_PICTURE[num2]);
						}
						uSR3_DATA.mPcbCheck.mMarkPic[num2] = bitmap;
						uSR3_DATA.mPcbCheck.mMark[num2].X = mMarkFound[num2].X;
						uSR3_DATA.mPcbCheck.mMark[num2].Y = mMarkFound[num2].Y;
						mIsMarkRecSuccess = true;
						if (mIsMarkTest)
						{
							MainForm0.CmMessageBoxTop_Ok("MARK" + (num2 + 1) + ((USR_INIT.mLanguage == 2) ? " Success! " : " 识别成功！"));
						}
						num2++;
						continue;
					}
					mIsMarkRecSuccess = false;
					if (mIsMarkTest)
					{
						MainForm0.CmMessageBoxTop_Ok("MARK" + (num2 + 1) + ((USR_INIT.mLanguage == 2) ? " detect fail several times, please use manual mode confirm!" : "扫描多次，识别失败，自动切换至手动MARK模式"));
					}
					break;
				}
				if (!fun_isNewMarkReasonable(uSR3_DATA.mMark, mMarkFound) && !MainForm0.mIsSimulation)
				{
					if (mIsMarkTest)
					{
						MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Current MARK is far different from PCB MARK, please check!" : "系统发现当前确认的Mark点，与工程板的Mark点位置关系差异过大，请检查！");
					}
				}
				else
				{
					if (mIsMarkTest)
					{
						break;
					}
					uSR3_DATA.mPcbCheck.mAngle = (float)(fun_angle(uSR3_DATA.mMark, mMarkFound) * 180.0 / Math.PI);
					for (int i = 0; i < uSR3_DATA.mPointlist.Count; i++)
					{
						ChipBoardElement chipBoardElement = uSR3_DATA.mPointlist[i];
						Coordinate coordinate = fun_newxy(uSR3_DATA.mMark, mMarkFound, new Coordinate(chipBoardElement.X, chipBoardElement.Y));
						if (coordinate.X < 0)
						{
							coordinate.X = 0L;
						}
						if (coordinate.Y < 0)
						{
							coordinate.Y = 0L;
						}
						chipBoardElement.X_Real = (int)coordinate.X;
						chipBoardElement.Y_Real = (int)coordinate.Y;
						chipBoardElement.A_Real = chipBoardElement.A + uSR3_DATA.mPcbCheck.mAngle;
					}
				}
				break;
			}
			MainForm0.set_camera_parameter(num, markCamPara.mParaCam);
			MainForm0.mark_lightlevel_set(mFn, markCamPara.mParaLed);
			MainForm0.mark_light_on(mFn, markCamPara.mLightOn);
			MainForm0.mark_led_on(mFn, markCamPara.mLedOn);
			if (!mIsMarkRecSuccess)
			{
				MainForm0.CmMessageBoxTop_Ok("Mark点识别失败，没有生成数据!");
			}
		}

		public int ImageVisual_MarkMatch(Bitmap newbitmap_des, BindingList<CvPoint> cvlist, int cur_threshold, double[] cirs, int max_cirs)
		{
			int count = cvlist.Count;
			if (count <= 0)
			{
				MainForm0.write_to_logFile("未定制精准MARK，请定制之后再使用精准MARK识别");
				return -1;
			}
			int[] array = new int[count * 2];
			for (int i = 0; i < count; i++)
			{
				array[i * 2] = cvlist[i].X;
				array[i * 2 + 1] = cvlist[i].Y;
			}
			BitmapData bitmapData = newbitmap_des.LockBits(new Rectangle(0, 0, newbitmap_des.Width, newbitmap_des.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			int result = MainForm0.moon_Visual_MarkGen_Match(bitmapData.Scan0, array, count, 32, new Size(newbitmap_des.Width, newbitmap_des.Height), cur_threshold, cirs, max_cirs);
			newbitmap_des.UnlockBits(bitmapData);
			return result;
		}

		public double ImageVisual_MarkLegacy(Bitmap newbitmap_des, Bitmap reference_map, int picsize, double[] cirs)
		{
			PointF leftpoint = default(PointF);
			PointF ptf = default(PointF);
			BitmapData bitmapData = reference_map.LockBits(new Rectangle(new Point((150 - picsize) / 2, (150 - picsize) / 2), new Size(picsize, picsize)), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			BitmapData bitmapData2 = newbitmap_des.LockBits(new Rectangle(0, 0, newbitmap_des.Width, newbitmap_des.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			double result = MainForm0.moon_FindMark(bitmapData.Scan0, new Size(picsize, picsize), bitmapData2.Scan0, new Size(newbitmap_des.Width, newbitmap_des.Height), ref leftpoint, ref ptf, 32);
			cirs[0] = (double)leftpoint.X + (double)picsize / 2.0 - (double)(newbitmap_des.Width / 2);
			cirs[1] = (double)leftpoint.Y + (double)picsize / 2.0 - (double)(newbitmap_des.Height / 2);
			reference_map.UnlockBits(bitmapData);
			newbitmap_des.UnlockBits(bitmapData2);
			return result;
		}

		public double ImageVisual_MarkLegacy(Bitmap newbitmap_des, Bitmap reference_map, int picsize, ref PointF leftpointf, ref PointF ptf)
		{
			BitmapData bitmapData = reference_map.LockBits(new Rectangle(new Point((150 - picsize) / 2, (150 - picsize) / 2), new Size(picsize, picsize)), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			BitmapData bitmapData2 = newbitmap_des.LockBits(new Rectangle(0, 0, newbitmap_des.Width, newbitmap_des.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			double result = MainForm0.moon_FindMark(bitmapData.Scan0, new Size(picsize, picsize), bitmapData2.Scan0, new Size(newbitmap_des.Width, newbitmap_des.Height), ref leftpointf, ref ptf, 32);
			reference_map.UnlockBits(bitmapData);
			newbitmap_des.UnlockBits(bitmapData2);
			return result;
		}

		public int ImageVisual_stillAnd_MarkMatch(int markno, double[] offsetxy)
		{
			int num = 0;
			int num2 = HW.mMarkCamItem[mFn].index[0];
			MainForm0.startMarkStill_andWait(mFn);
			if (MainForm0.mIsSimulation)
			{
				string text = "D:\\Smt\\Customer\\2020_new4\\dingzong_markfail\\mark" + markno + ".jpg";
				if (File.Exists(text))
				{
					MainForm0.mJVSBitmap[num2] = new Bitmap(text);
				}
			}
			Bitmap bitmap = new Bitmap(MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
			Rectangle destRect = new Rectangle(0, 0, MainForm0.mJvs_usrWidth, MainForm0.mJvs_usrHeight);
			Rectangle srcRect = new Rectangle((MainForm0.mJvs_rawWidth - MainForm0.mJvs_usrWidth) / 2, 0, MainForm0.mJvs_usrWidth, MainForm0.mJvs_rawHeight);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(MainForm0.mJVSBitmap[HW.mMarkCamItem[mFn].index[0]], destRect, srcRect, GraphicsUnit.Pixel);
			graphics.Dispose();
			int num3 = 10;
			double[] array = new double[num3 * 3];
			int num4 = 0;
			double rate = -1.0;
			if (USR3.mMarkPara[markno].mode == MarkModeType.Pricise)
			{
				num4 = ImageVisual_MarkMatch(bitmap, USR3.mMarkPara[markno].cvlist, USR3.mMarkPara[markno].threshold, array, num3);
			}
			switch (num4)
			{
			case 1:
				offsetxy[0] = array[0] - USR3.mMarkPara[markno].x_offs;
				offsetxy[1] = array[1] - USR3.mMarkPara[markno].y_offs;
				num = 1;
				break;
			case -1:
				return -1;
			default:
				rate = ImageVisual_MarkLegacy(bitmap, USR3.mMarkPara[markno].mPicMark, USR3.mMarkPara[markno].picsize, offsetxy);
				if (rate * 100.0 >= (double)USR3.mMarkPara[markno].recognizeRate)
				{
					num = 1;
				}
				BeginInvoke((MethodInvoker)delegate
				{
					if (uc_smtMarkRecognition != null && !uc_smtMarkRecognition.IsDisposed)
					{
						uc_smtMarkRecognition.set_recognizerate((float)rate * 100f);
					}
				});
				if (USR3.mPcbCheck != null)
				{
					USR3.mPcbCheck.mMarkRecRate[markno] = (float)rate * 100f;
				}
				break;
			}
			if (num == 0 && USR.mDebug_IsSaveErrBitmap)
			{
				string text2 = "C:/SmtLog/Mark/err_";
				DateTime now = DateTime.Now;
				string text3 = text2;
				text2 = text3 + (markno + 1) + "_" + now.Year + now.Month.ToString("D2") + now.Day.ToString("D2") + "_" + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2") + "_" + now.Millisecond.ToString("D3") + ".jpg";
				Graphics graphics2 = Graphics.FromImage(MainForm0.mJVSBitmap[HW.mMarkCamItem[mFn].index[0]]);
				string text4 = "legacy  result=" + num + "   rate=" + rate;
				string text5 = "pricise  result=" + num + "    counts=" + num4;
				string s = text5 + Environment.NewLine + text4;
				Brush brush = new SolidBrush(Color.FromArgb(250, 250, 0));
				graphics2.DrawString(s, new Font("", 10.5f), brush, 2f, 2f);
				if (!Directory.Exists("C:/SmtLog/Mark/"))
				{
					Directory.CreateDirectory("C:/SmtLog/Mark/");
				}
				MainForm0.mJVSBitmap[HW.mMarkCamItem[mFn].index[0]].Save(text2, ImageFormat.Jpeg);
				brush.Dispose();
				graphics2.Dispose();
			}
			return num;
		}

		public PikFail vsplus_group(BIGTAB_GROUP biggroup, BindingList<int_2d> throwlist, int youxian_pik, int youxian_v)
		{
			PikFail result = PikFail.Exit;
			bool flag = false;
			if (biggroup.pik_arr.Count == 0)
			{
				return result;
			}
			for (int i = 0; i < biggroup.mnt_arr.Count; i++)
			{
				int_2d item2 = new int_2d(i, biggroup.mnt_arr[i].zn);
				throwlist.Add(item2);
			}
			msmtgroup_idx_raw = biggroup.pik_arr[0].sync_arr[0].group_no;
			if (biggroup.cameratype != CameraType.None && (youxian_pik != 1 || youxian_v != 0) && (youxian_pik != 2 || youxian_v != 1))
			{
				BeginInvoke((MethodInvoker)delegate
				{
					MainForm0.mark_light_on(mFn, flag: false);
					MainForm0.mark_led_on(mFn, flag: false);
					if (biggroup.cameratype == CameraType.Fast)
					{
						MainForm0.fhcam_led_on(mFn, CameraType.Fast, flag: true);
					}
					if (biggroup.cameratype == CameraType.High)
					{
						MainForm0.fhcam_led_on(mFn, CameraType.High, flag: true);
					}
				});
			}
			if (youxian_pik == 1 && youxian_v == 1 && Is_YouXian_Pik_Done)
			{
				Is_YouXian_Pik_Done = false;
			}
			else
			{
				if (youxian_pik == 2 && youxian_v == 1 && Is_YouXian_Pik_Done)
				{
					Is_YouXian_Pik_Done = false;
					goto IL_11e4;
				}
				XY_SPEED = (biggroup.islowspeed ? (USR3B.mSmtXYSpeed / 2) : USR3B.mSmtXYSpeed);
				A_SPEED = (biggroup.islowspeed ? (USR3B.mSmtASpeed / 2) : USR3B.mSmtASpeed);
				LOW_SPEED = biggroup.islowspeed;
				mIsChipsOnHead = true;
				for (int j = 0; j < biggroup.pik_arr.Count; j++)
				{
					if (j == 0)
					{
						for (int k = 0; k < HW.mZnNum[mFn]; k++)
						{
							MainForm0.WaitComplete_Z(mFn, k);
						}
					}
					if (biggroup.provider == ProviderType.Plate)
					{
						BIGTAB_1_ITEM bIGTAB_1_ITEM = biggroup.pik_arr[j];
						if (bIGTAB_1_ITEM.sync_arr != null && bIGTAB_1_ITEM.sync_arr.Count > 0)
						{
							long num = 0L;
							long num2 = 0L;
							for (int l = 0; l < bIGTAB_1_ITEM.sync_arr.Count; l++)
							{
								BIGTAB_SUB_PIK_ITEM item = bIGTAB_1_ITEM.sync_arr[l];
								while (true)
								{
									IL_023c:
									if (USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex >= USR2.mStackLib.stacktab[1][item.stackno].mPlt.mXYlist.Count)
									{
										if (USR2.mStackLib.stacktab[1][item.stackno].mPlt.mIsAutoEnt)
										{
											MainForm0.msdelay((int)(USR2.mStackLib.stacktab[1][item.stackno].mPlt.mAutoEntTimeDelay * 1000f));
										}
										else
										{
											DialogResult plateempty_state = DialogResult.OK;
											Invoke((MethodInvoker)delegate
											{
												MainForm0.start_buzzer_warning(mFn);
												Form_PlateEmpty form_PlateEmpty = new Form_PlateEmpty(mFn, item.stackno);
												plateempty_state = form_PlateEmpty.ShowDialog();
												MainForm0.stop_buzzer_warning(mFn);
											});
											if (plateempty_state != DialogResult.OK)
											{
												return result;
											}
										}
										USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex = 0;
									}
									while (!USR2.mStackLib.stacktab[1][item.stackno].mPlt.mXYlist[USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex].mEnable)
									{
										USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex++;
										if (USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex >= USR2.mStackLib.stacktab[1][item.stackno].mPlt.mXYlist.Count)
										{
											goto IL_023c;
										}
									}
									break;
								}
								num += USR2.mStackLib.stacktab[1][item.stackno].mPlt.mXYlist[USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex].X - USR.mDeltaNozzle[0][item.zn].X;
								num2 += USR2.mStackLib.stacktab[1][item.stackno].mPlt.mXYlist[USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex].Y - USR.mDeltaNozzle[0][item.zn].Y;
								int num3 = startIndex_plate(item.stackno, USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex);
								float zero_a = ((num3 == 0) ? USR2.mStackLib.stacktab[1][item.stackno].mPlt.mAngle : USR2.mStackLib.stacktab[1][item.stackno].mPlt.mSubList[num3 - 1].mAngle);
								item.zero_a = zero_a;
								item.zero_a_step = MainForm0.AngleToSteps(item.zero_a);
								if (item.looptype == LoopType.HalfLoop || item.looptype == LoopType.CloseLoop)
								{
									item.pik_a = MainForm0.format_angle(item.mnt_a + item.zero_a, -180f, 180f, 360f);
								}
								else
								{
									item.pik_a = MainForm0.format_angle(item.zero_a, -180f, 180f, 360f);
								}
								item.pik_a_step = MainForm0.AngleToSteps(item.pik_a);
								vsplus_change_bigtabgroup_mnt_zero_a(biggroup, item.zn, item.zero_a);
								USR2.mStackLib.stacktab[1][item.stackno].mPlt.mStartIndex++;
							}
							biggroup.pik_arr[j].pik_x = (int)(num / bIGTAB_1_ITEM.sync_arr.Count);
							biggroup.pik_arr[j].pik_y = (int)(num2 / bIGTAB_1_ITEM.sync_arr.Count);
						}
					}
					MainForm0.moveToXY_noWait_Smt(mFn, USR3B.mSmtXYSpeed, new Coordinate(biggroup.pik_arr[j].pik_x, biggroup.pik_arr[j].pik_y));
					if (USR3B.mIsPrepareVacuum_veryEarly)
					{
						for (int m = 0; m < biggroup.pik_arr[j].sync_arr.Count; m++)
						{
							BIGTAB_SUB_PIK_ITEM bIGTAB_SUB_PIK_ITEM = biggroup.pik_arr[j].sync_arr[m];
							if (!bIGTAB_SUB_PIK_ITEM.is_preprarevacuum_later)
							{
								MainForm0.misc_vacc_onoff(mFn, bIGTAB_SUB_PIK_ITEM.zn, 1);
							}
						}
					}
					if (j == 0)
					{
						for (int n = 0; n < HW.mZnNum[mFn]; n++)
						{
							MainForm0.WaitComplete_A(mFn, n);
						}
					}
					MainForm0.WaitComplete_XY(mFn);
					for (int num4 = 0; num4 < biggroup.pik_arr[j].sync_arr.Count; num4++)
					{
						mSyncpik_SmtMask[biggroup.pik_arr[j].sync_arr[num4].zn] = true;
					}
					for (int num5 = 0; num5 < biggroup.pik_arr[j].sync_arr.Count; num5++)
					{
						Thread thread = new Thread(thd_pik);
						thread.IsBackground = true;
						thread.Start(biggroup.pik_arr[j].sync_arr[num5]);
					}
					if (HW.mSmtGenerationNo != 0 && j == 0)
					{
						for (int num6 = 1; num6 < biggroup.pik_arr.Count; num6++)
						{
							for (int num7 = 0; num7 < biggroup.pik_arr[num6].sync_arr.Count; num7++)
							{
								BIGTAB_SUB_PIK_ITEM bIGTAB_SUB_PIK_ITEM2 = biggroup.pik_arr[num6].sync_arr[num7];
								MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_SUB_PIK_ITEM2.zn, bIGTAB_SUB_PIK_ITEM2.speed_down, bIGTAB_SUB_PIK_ITEM2.up0_z);
							}
						}
					}
					for (int num8 = 0; num8 < biggroup.pik_arr[j].sync_arr.Count; num8++)
					{
						int zn = biggroup.pik_arr[j].sync_arr[num8].zn;
						while (mSyncpik_SmtMask[zn])
						{
							Thread.Sleep(1);
							if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
							{
								return result;
							}
						}
					}
				}
				if (youxian_pik == 1 && youxian_v == 0)
				{
					for (int num9 = 0; num9 < HW.mZnNum[mFn]; num9++)
					{
						MainForm0.WaitComplete_Z(mFn, num9);
					}
					Is_YouXian_Pik_Done = true;
					return PikFail.Success;
				}
			}
			if (biggroup.cameratype != CameraType.None)
			{
				if (biggroup.cameratype == CameraType.Fast)
				{
					if (HW.mSmtGenerationNo != 0 && (USR.mIsSafeRunMode || biggroup.is_overclimb))
					{
						for (int num10 = 0; num10 < HW.mZnNum[mFn]; num10++)
						{
							MainForm0.WaitComplete_Z(mFn, num10);
						}
					}
					MainForm0.moveToXY_noWait_Smt(mFn, XY_SPEED, USR.mFastCamRecognizeCoord[0]);
					bool flag2 = true;
					if (HW.mSmtGenerationNo != 0)
					{
						if (biggroup.is_overclimb)
						{
							flag2 = biggroup.is_pik2cam_up;
						}
						if (USR.mIsSafeRunMode)
						{
							flag2 = false;
						}
						if (!flag2)
						{
							MainForm0.WaitComplete_XY(mFn);
						}
						for (int num11 = 0; num11 < biggroup.mnt_arr.Count; num11++)
						{
							BIGTAB_2_ITEM bIGTAB_2_ITEM = biggroup.mnt_arr[num11];
							MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_2_ITEM.zn, bIGTAB_2_ITEM.pik_speed_z_up, bIGTAB_2_ITEM.camera_z);
						}
						for (int num12 = 0; num12 < biggroup.mnt_arr.Count; num12++)
						{
							BIGTAB_2_ITEM bIGTAB_2_ITEM2 = biggroup.mnt_arr[num12];
							MainForm0.WaitComplete_Z(mFn, bIGTAB_2_ITEM2.zn);
						}
					}
					if (flag2)
					{
						MainForm0.WaitComplete_XY(mFn);
					}
					vsplus_fastcam_stillall_andvisual(biggroup);
				}
				else if (biggroup.cameratype == CameraType.High)
				{
					if (HW.mSmtGenerationNo != 0 && biggroup.is_overclimb)
					{
						for (int num13 = 0; num13 < HW.mZnNum[mFn]; num13++)
						{
							MainForm0.WaitComplete_Z(mFn, num13);
						}
					}
					BindingList<BIGTAB_2_ITEM> bindingList = new BindingList<BIGTAB_2_ITEM>();
					for (int num14 = 0; num14 < biggroup.mnt_arr.Count; num14++)
					{
						bindingList.Add(biggroup.mnt_arr[num14]);
					}
					BIGTAB_2_ITEM[] array = bindingList.OrderBy((BIGTAB_2_ITEM a) => a.zn).ToArray();
					for (int num15 = 0; num15 < array.Count(); num15++)
					{
						BIGTAB_2_ITEM bIGTAB_2_ITEM3 = array[num15];
						if (USR2.mStackLib.stacktab[(int)bIGTAB_2_ITEM3.providertype][bIGTAB_2_ITEM3.stackno].mIsHCamSpecialPara)
						{
							MainForm0.hcam_lightlevel_set(mFn, USR2.mStackLib.stacktab[(int)bIGTAB_2_ITEM3.providertype][bIGTAB_2_ITEM3.stackno].HCamSpecial_ledlevel);
						}
						MainForm0.moveToXY_noWait_Smt(mFn, XY_SPEED, USR.mHighCamRecognizeCoord[0][bIGTAB_2_ITEM3.zn]);
						if (HW.mSmtGenerationNo != 0)
						{
							if (num15 == 0)
							{
								bool flag3 = true;
								if (biggroup.is_overclimb)
								{
									flag3 = biggroup.is_pik2cam_up;
								}
								if (USR.mIsSafeRunMode)
								{
									flag3 = false;
								}
								if (!flag3)
								{
									MainForm0.WaitComplete_XY(mFn);
								}
								for (int num16 = 0; num16 < array.Count(); num16++)
								{
									BIGTAB_2_ITEM bIGTAB_2_ITEM4 = array[num16];
									MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_2_ITEM4.zn, bIGTAB_2_ITEM4.speed_z_up, bIGTAB_2_ITEM4.camera_z);
								}
								MainForm0.WaitComplete_Z(mFn, bIGTAB_2_ITEM3.zn);
								if (USR.mIsSafeRunMode)
								{
									for (int num17 = 0; num17 < array.Count(); num17++)
									{
										BIGTAB_2_ITEM bIGTAB_2_ITEM5 = array[num17];
										MainForm0.WaitComplete_Z(mFn, bIGTAB_2_ITEM5.zn);
									}
								}
								if (flag3)
								{
									MainForm0.WaitComplete_XY(mFn);
								}
							}
							else
							{
								MainForm0.WaitComplete_Z(mFn, bIGTAB_2_ITEM3.zn);
								MainForm0.WaitComplete_XY(mFn);
							}
						}
						else
						{
							MainForm0.WaitComplete_XY(mFn);
						}
						if (MainForm0.mIsSimulation)
						{
							string text = "C:\\E\\hwgcpic\\highcam.bmp";
							if (File.Exists(text))
							{
								Bitmap bitmap = new Bitmap(text);
								BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, 1944, 1944), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
								Marshal.Copy(bitmapData.Scan0, MainForm0.pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 0, 11337408);
								bitmap.UnlockBits(bitmapData);
								if (bIGTAB_2_ITEM3.looptype == LoopType.CloseLoop || bIGTAB_2_ITEM3.looptype == LoopType.HalfLoop)
								{
									MainForm0.moon_buffer_move_angel(MainForm0.pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 24, new Size(1944, 1944), new Point(972, 972), bIGTAB_2_ITEM3.scan_r, bIGTAB_2_ITEM3.mnt_a);
								}
							}
						}
						MainForm0.WaitComplete_A(mFn, bIGTAB_2_ITEM3.zn);
						if (bIGTAB_2_ITEM3.looptype == LoopType.CloseLoop)
						{
							MainForm0.bKSJCameraRecived[bIGTAB_2_ITEM3.zn] = false;
							result = vsplus_pricisevisual(bIGTAB_2_ITEM3);
							if (mSmtVisualDone[bIGTAB_2_ITEM3.zn] == SMT_VISUAL_STATE.FAIL)
							{
								flag = mForm_PikFail_H.is_RebackChip();
								MainForm0.moveToA_noWait_Smt(mFn, bIGTAB_2_ITEM3.zn, A_SPEED, 0);
								if (flag)
								{
									vsplus_reback2plate(biggroup, throwlist);
								}
								return result;
							}
							continue;
						}
						MainForm0.bKSJCameraRecived[bIGTAB_2_ITEM3.zn] = false;
						Thread thread2 = new Thread(thd_jvsvisual);
						thread2.IsBackground = true;
						thread2.Priority = ((num15 == 0) ? ThreadPriority.Highest : ThreadPriority.AboveNormal);
						thread2.Start(array[num15]);
						if (MainForm0.mIsSimulation)
						{
							MainForm0.bKSJCameraRecived[bIGTAB_2_ITEM3.zn] = true;
						}
						while (!MainForm0.bKSJCameraRecived[bIGTAB_2_ITEM3.zn])
						{
							Thread.Sleep(1);
							if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
							{
								return result;
							}
						}
					}
				}
			}
			if (biggroup.cameratype != CameraType.None)
			{
				BeginInvoke((MethodInvoker)delegate
				{
					MainForm0.mark_light_on(mFn, flag: true);
					MainForm0.mark_led_on(mFn, flag: true);
					if (USR3B.mIsFlashlightMode)
					{
						if (biggroup.cameratype == CameraType.Fast)
						{
							MainForm0.fhcam_led_on(mFn, CameraType.Fast, flag: false);
						}
						if (biggroup.cameratype == CameraType.High)
						{
							MainForm0.fhcam_led_on(mFn, CameraType.High, flag: false);
						}
					}
				});
			}
			if (youxian_pik == 2 && youxian_v == 0)
			{
				Is_YouXian_Pik_Done = true;
				if (HW.mSmtGenerationNo != 0)
				{
					for (int num18 = 0; num18 < biggroup.mnt_arr.Count; num18++)
					{
						BIGTAB_2_ITEM bIGTAB_2_ITEM6 = biggroup.mnt_arr[num18];
						int zn2 = bIGTAB_2_ITEM6.zn;
						MainForm0.moveToZ_noWait_Smt(mFn, zn2, bIGTAB_2_ITEM6.pik_speed_z_down, bIGTAB_2_ITEM6.prepare1_z);
					}
					for (int num19 = 0; num19 < biggroup.remain_mnt_prepare_z.Count; num19++)
					{
						BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z = biggroup.remain_mnt_prepare_z[num19];
						int zn3 = bIGTAB_SUB_REMAIN_Z.zn;
						MainForm0.moveToZ_noWait_Smt(mFn, zn3, 60, bIGTAB_SUB_REMAIN_Z.value1);
					}
					if (USR.mIsSafeRunMode)
					{
						for (int num20 = 0; num20 < HW.mZnNum[mFn]; num20++)
						{
							MainForm0.WaitComplete_Z(mFn, num20);
						}
					}
				}
				return PikFail.Success;
			}
			goto IL_11e4;
			IL_11e4:
			if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
			{
				return result;
			}
			for (int num21 = 0; num21 < biggroup.mnt_arr.Count; num21++)
			{
				BIGTAB_2_ITEM bIGTAB_2_ITEM7 = biggroup.mnt_arr[num21];
				int zn4 = bIGTAB_2_ITEM7.zn;
				if (num21 == 0)
				{
					if (HW.mSmtGenerationNo != 0 && biggroup.is_cam2mnt_up)
					{
						int speed = 60;
						for (int num22 = 0; num22 < biggroup.mnt_arr.Count; num22++)
						{
							BIGTAB_2_ITEM bIGTAB_2_ITEM8 = biggroup.mnt_arr[num22];
							MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_2_ITEM8.zn, bIGTAB_2_ITEM8.pik_speed_z_up, bIGTAB_2_ITEM8.prepare1_z);
							speed = bIGTAB_2_ITEM8.pik_speed_z_up;
						}
						for (int num23 = 0; num23 < biggroup.remain_mnt_prepare_z.Count; num23++)
						{
							BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z2 = biggroup.remain_mnt_prepare_z[num23];
							if (MainForm0.mCur[mFn].z[bIGTAB_SUB_REMAIN_Z2.zn] > bIGTAB_SUB_REMAIN_Z2.value1)
							{
								MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_SUB_REMAIN_Z2.zn, speed, bIGTAB_SUB_REMAIN_Z2.value1);
							}
						}
						for (int num24 = 0; num24 < HW.mZnNum[mFn]; num24++)
						{
							MainForm0.WaitComplete_Z(mFn, num24);
						}
					}
					MainForm0.moveToXY_noWait_Smt(mFn, XY_SPEED, new Coordinate(biggroup.mnt_arr[0].mnt_x, biggroup.mnt_arr[0].mnt_y));
					if (HW.mSmtGenerationNo != 0)
					{
						if (USR.mIsSafeRunMode)
						{
							MainForm0.WaitComplete_XY(mFn);
						}
						int speed2 = 60;
						if (!biggroup.is_cam2mnt_up)
						{
							for (int num25 = 0; num25 < biggroup.mnt_arr.Count; num25++)
							{
								BIGTAB_2_ITEM bIGTAB_2_ITEM9 = biggroup.mnt_arr[num25];
								MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_2_ITEM9.zn, bIGTAB_2_ITEM9.speed_z_down, bIGTAB_2_ITEM9.prepare1_z);
								speed2 = bIGTAB_2_ITEM9.speed_z_down;
							}
							for (int num26 = 0; num26 < biggroup.remain_mnt_prepare_z.Count; num26++)
							{
								BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z3 = biggroup.remain_mnt_prepare_z[num26];
								if (MainForm0.mCur[mFn].z[bIGTAB_SUB_REMAIN_Z3.zn] > bIGTAB_SUB_REMAIN_Z3.value1)
								{
									MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_SUB_REMAIN_Z3.zn, speed2, bIGTAB_SUB_REMAIN_Z3.value1);
								}
							}
						}
						if (USR.mIsSafeRunMode)
						{
							for (int num27 = 0; num27 < HW.mZnNum[mFn]; num27++)
							{
								MainForm0.WaitComplete_Z(mFn, num27);
							}
						}
					}
				}
				if (bIGTAB_2_ITEM7.cameratype != CameraType.None)
				{
					while (mSmtVisualDone[zn4] == SMT_VISUAL_STATE.NOT_COMPLETE)
					{
						Thread.Sleep(1);
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return result;
						}
					}
				}
				if (bIGTAB_2_ITEM7.cameratype == CameraType.None || mSmtVisualDone[zn4] == SMT_VISUAL_STATE.SUCCESS)
				{
					if (num21 == 0)
					{
						MainForm0.WaitComplete_XY(mFn);
					}
					MainForm0.moveToXY_noWait_Smt(mFn, XY_SPEED, new Coordinate(bIGTAB_2_ITEM7.mnt_x + mXref[zn4], bIGTAB_2_ITEM7.mnt_y + mYref[zn4]));
					mXref[zn4] = 0;
					mYref[zn4] = 0;
					mAngleref[zn4] = 0f;
					MainForm0.WaitComplete_XY(mFn);
					MainForm0.WaitComplete_A(mFn, zn4);
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return result;
					}
					MainForm0.moveToZ_noWait_Smt(mFn, zn4, bIGTAB_2_ITEM7.speed_z_down, bIGTAB_2_ITEM7.mnt_z);
					if (HW.mSmtGenerationNo != 0 && num21 == 0)
					{
						for (int num28 = 1; num28 < biggroup.mnt_arr.Count; num28++)
						{
							BIGTAB_2_ITEM bIGTAB_2_ITEM10 = biggroup.mnt_arr[num28];
							MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_2_ITEM10.zn, bIGTAB_2_ITEM10.speed_z_down, bIGTAB_2_ITEM10.up1_z);
						}
					}
					MainForm0.WaitComplete_Z(mFn, zn4);
					for (int num29 = 0; num29 < throwlist.Count; num29++)
					{
						if (throwlist[num29].a == num21)
						{
							throwlist.RemoveAt(num29);
							break;
						}
					}
					MainForm0.misc_vacc_onoff(mFn, zn4, 0);
					MainForm0.msdelay(bIGTAB_2_ITEM7.mntdelay);
					if (HW.mSmtGenerationNo == 0)
					{
						MainForm0.moveToZ_noWait_Smt(mFn, zn4, bIGTAB_2_ITEM7.speed_z_up, USR3B.mGen0SafeZ * ((zn4 % 2 != 0) ? 1 : (-1)));
					}
					else
					{
						MainForm0.moveToZ_noWait_Smt(mFn, zn4, bIGTAB_2_ITEM7.speed_z_up, bIGTAB_2_ITEM7.up0_z);
					}
					if (!biggroup.is_smt_test)
					{
						int raw_no = bIGTAB_2_ITEM7.raw_no;
						int all_no = ((USR3B.mInBoardMode == 2) ? bIGTAB_2_ITEM7.no : bIGTAB_2_ITEM7.all_no);
						draw_fakechip(mUSR3Idx, raw_no, isdone: true);
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.draw_fakechip(mFn, mUSR3Idx, raw_no, isdone: true);
						}
						BeginInvoke((Action)delegate
						{
							set_progress_bar(all_no + 1);
						});
						msmt_curhaiba = bIGTAB_2_ITEM7.haiba1_hmm;
						msmtchip_idx++;
						msmt_real_chips++;
						MainForm0.mSmtMiles++;
						BeginInvoke((Action)delegate
						{
							set_label_all_curchipindex(msmt_real_chips);
							set_label_smt_index_no(msmtchip_idx);
							set_label_haiba(msmt_curhaiba);
						});
						BeginInvoke((Action)delegate
						{
							if (all_no >= 0)
							{
								if (msmt_mode == SmtOpMode.CurPcb || msmt_mode == SmtOpMode.ContinuePcb)
								{
									mis_maybe_continue = 1;
								}
								else
								{
									mis_maybe_continue = 2;
								}
							}
							int progress_bar_max_v = get_progress_bar_max_v();
							if (all_no == progress_bar_max_v - 1)
							{
								mis_maybe_continue = 0;
							}
							msmt_last_all_no = all_no;
						});
						smtinfo_update_mountChips_plusplus(8);
						smtinfo_update_mountChips_plusplus(zn4);
						if (num21 == biggroup.mnt_arr.Count - 1)
						{
							double num30 = (DateTime.Now - msmt_starttime).TotalMilliseconds + msmt_preparetime;
							double num31 = (double)msmtchip_idx / num30;
							msmt_hourspeed = num31 * 1000.0 * 60.0 * 60.0 * 1.1;
							if (HW.mSmtGenerationNo == 0)
							{
								msmt_hourspeed *= 1.1;
							}
							else
							{
								msmt_hourspeed *= 1.0;
							}
							if (msmt_hourspeed > msmt_max_hourspeed)
							{
								msmt_max_hourspeed = msmt_hourspeed;
							}
							float show_rate = 1f;
							if (HW.mFnNum == 2)
							{
								MainForm0.total_avespeed = msmt_hourspeed + MainForm0.uc_job[1 - mFn].msmt_hourspeed;
								if (MainForm0.total_avespeed > MainForm0.total_maxspeed)
								{
									MainForm0.total_maxspeed = MainForm0.total_avespeed;
								}
								BeginInvoke((Action)delegate
								{
									if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
									{
										MainForm0.uc_smtRunning.set_total_speed((int)MainForm0.total_avespeed, (int)MainForm0.total_maxspeed);
									}
								});
							}
							BeginInvoke((Action)delegate
							{
								set_label_everyhour_avespeed((int)(msmt_hourspeed * (double)show_rate));
								set_label_everyhour_maxspeed((int)(msmt_max_hourspeed * (double)show_rate));
							});
						}
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return result;
					}
					MainForm0.WaitComplete_Z(mFn, zn4);
					if (HW.mSmtGenerationNo == 0)
					{
						MainForm0.moveToZ_noWait_Smt(mFn, zn4, bIGTAB_2_ITEM7.speed_z_up, 0);
					}
					else
					{
						MainForm0.moveToZ_noWait_Smt(mFn, zn4, bIGTAB_2_ITEM7.speed_z_up, bIGTAB_2_ITEM7.prepare0_z);
					}
					MainForm0.moveToA_noWait_Smt(mFn, zn4, USR3B.mSmtASpeed, 0);
					if (HW.mSmtGenerationNo != 0 && USR.mIsSafeRunMode)
					{
						MainForm0.WaitComplete_Z(mFn, zn4);
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return result;
					}
				}
				else if (mSmtVisualDone[zn4] == SMT_VISUAL_STATE.FAIL)
				{
					MainForm0.moveToA_noWait(mFn, zn4, A_SPEED, 0);
				}
				mSmtVisualDone[zn4] = SMT_VISUAL_STATE.NOT_COMPLETE;
			}
			if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
			{
				return result;
			}
			if (throwlist.Count > 0)
			{
				result = PikFail.Retry;
				if (!flag)
				{
					MainForm0.write_to_logFile("抛料");
					for (int num32 = 0; num32 < HW.mZnNum[mFn]; num32++)
					{
						MainForm0.WaitComplete_Z(mFn, num32);
					}
					if (HW.mSmtGenerationNo == 0)
					{
						MainForm0.moveToZero_Z_andWait(mFn);
					}
					else
					{
						int speed3 = 60;
						for (int num33 = 0; num33 < biggroup.mnt_arr.Count; num33++)
						{
							BIGTAB_2_ITEM bIGTAB_2_ITEM11 = biggroup.mnt_arr[num33];
							MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_2_ITEM11.zn, bIGTAB_2_ITEM11.pik_speed_z_up, bIGTAB_2_ITEM11.prepare1_z);
							speed3 = bIGTAB_2_ITEM11.pik_speed_z_up;
						}
						for (int num34 = 0; num34 < biggroup.remain_mnt_prepare_z.Count; num34++)
						{
							BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z4 = biggroup.remain_mnt_prepare_z[num34];
							if (MainForm0.mCur[mFn].z[bIGTAB_SUB_REMAIN_Z4.zn] > bIGTAB_SUB_REMAIN_Z4.value1)
							{
								MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_SUB_REMAIN_Z4.zn, speed3, bIGTAB_SUB_REMAIN_Z4.value1);
							}
						}
						for (int num35 = 0; num35 < HW.mZnNum[mFn]; num35++)
						{
							MainForm0.WaitComplete_Z(mFn, num35);
						}
					}
					for (int num36 = 0; num36 < throwlist.Count; num36++)
					{
						BIGTAB_2_ITEM bIGTAB_2_ITEM12 = biggroup.mnt_arr[throwlist[num36].a];
						int zn5 = bIGTAB_2_ITEM12.zn;
						MainForm0.moveToA_noWait_Smt(mFn, zn5, USR3B.mSmtASpeed, 0);
						MainForm0.moveToXY_andWait(mFn, XY_SPEED, new Coordinate(USR.mThrowCoord.X - USR.mDeltaNozzle[0][zn5].X, USR.mThrowCoord.Y - USR.mDeltaNozzle[0][zn5].Y));
						MainForm0.misc_vacc_onoff(mFn, zn5, 0);
					}
					if (USR3B.mIsPrepareVacuum_veryEarly)
					{
						Thread.Sleep(200);
					}
				}
			}
			else
			{
				result = PikFail.Success;
			}
			mIsChipsOnHead = false;
			return result;
		}

		public void vsplus_change_bigtabgroup_mnt_zero_a(BIGTAB_GROUP biggroup, int zn, float angle)
		{
			for (int i = 0; i < biggroup.mnt_arr.Count; i++)
			{
				BIGTAB_2_ITEM bIGTAB_2_ITEM = biggroup.mnt_arr[i];
				if (bIGTAB_2_ITEM.zn == zn)
				{
					bIGTAB_2_ITEM.zero_a = angle;
					bIGTAB_2_ITEM.zero_a = MainForm0.format_angle(bIGTAB_2_ITEM.zero_a, -180f, 180f, 360f);
					bIGTAB_2_ITEM.zero_a_step = MainForm0.AngleToSteps(bIGTAB_2_ITEM.zero_a);
					break;
				}
			}
		}

		public void thd_pik(object o)
		{
			BIGTAB_SUB_PIK_ITEM bIGTAB_SUB_PIK_ITEM = (BIGTAB_SUB_PIK_ITEM)o;
			if (MainForm0.mIsFeederReady[mFn][(int)bIGTAB_SUB_PIK_ITEM.provider][bIGTAB_SUB_PIK_ITEM.stackno])
			{
				MainForm0.moveToZ_noWait(mFn, bIGTAB_SUB_PIK_ITEM.zn, bIGTAB_SUB_PIK_ITEM.speed_down, bIGTAB_SUB_PIK_ITEM.pik_z);
				MainForm0.misc_feeder_onoff(mFn, bIGTAB_SUB_PIK_ITEM.provider, bIGTAB_SUB_PIK_ITEM.stackno, flag: true);
			}
			else
			{
				MainForm0.misc_feeder_onoff(mFn, bIGTAB_SUB_PIK_ITEM.provider, bIGTAB_SUB_PIK_ITEM.stackno, flag: true);
				MainForm0.moveToZ_noWait(mFn, bIGTAB_SUB_PIK_ITEM.zn, bIGTAB_SUB_PIK_ITEM.speed_down, bIGTAB_SUB_PIK_ITEM.pik_z);
			}
			if (!bIGTAB_SUB_PIK_ITEM.is_preprarevacuum_later && !USR3B.mIsPrepareVacuum_veryEarly)
			{
				MainForm0.misc_vacc_onoff(mFn, bIGTAB_SUB_PIK_ITEM.zn, 1);
			}
			MainForm0.WaitComplete_Z(mFn, bIGTAB_SUB_PIK_ITEM.zn);
			if (bIGTAB_SUB_PIK_ITEM.is_preprarevacuum_later)
			{
				MainForm0.misc_vacc_onoff(mFn, bIGTAB_SUB_PIK_ITEM.zn, 1);
			}
			MainForm0.msdelay(bIGTAB_SUB_PIK_ITEM.pikdelay);
			if (HW.mSmtGenerationNo == 0)
			{
				MainForm0.moveToZ_andWait(mFn, bIGTAB_SUB_PIK_ITEM.zn, bIGTAB_SUB_PIK_ITEM.speed_up, USR3B.mGen0SafeZ * ((bIGTAB_SUB_PIK_ITEM.zn % 2 != 0) ? 1 : (-1)));
				MainForm0.moveToZ_noWait(mFn, bIGTAB_SUB_PIK_ITEM.zn, bIGTAB_SUB_PIK_ITEM.speed_up, 0);
			}
			else
			{
				MainForm0.moveToZ_andWait_Smt(mFn, bIGTAB_SUB_PIK_ITEM.zn, bIGTAB_SUB_PIK_ITEM.speed_up, bIGTAB_SUB_PIK_ITEM.up1_z);
				MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_SUB_PIK_ITEM.zn, bIGTAB_SUB_PIK_ITEM.speed_up, bIGTAB_SUB_PIK_ITEM.prepare1_z);
			}
			mSyncpik_SmtMask[bIGTAB_SUB_PIK_ITEM.zn] = false;
			MainForm0.misc_feeder_onoff(mFn, bIGTAB_SUB_PIK_ITEM.provider, bIGTAB_SUB_PIK_ITEM.stackno, flag: false);
			MainForm0.moveToA_noWait_Smt(mFn, bIGTAB_SUB_PIK_ITEM.zn, A_SPEED, bIGTAB_SUB_PIK_ITEM.pik_a_step);
		}

		private int s_auto_smt_tran4()
		{
			if (USR3B.mPrjSmtMode == 1 && mUSR3List.Count == HW.mSections && !is_tran4_can_youxianpik(mUSR3List))
			{
				youxian_pik = 0;
			}
			if (youxian_pik != 0)
			{
				mloop_idx = 0;
				msmtchip_idx_raw = 0;
				msmtchip_idx = 0;
				mis_maybe_continue = 0;
				Thread thread = new Thread(thd_SmtLoop_YouxianPik);
				thread.IsBackground = true;
				thread.Start(mloop);
			}
			while (true)
			{
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return -1;
				}
				QnCommon.mPlayWoodState_Sensor = -1;
				if (!MainForm0.mIsSimulation)
				{
					MainForm0.mConDevExt[0].readPlayWoodState();
				}
				if (is_sim_tran4())
				{
					MainForm0.mDebugFormTRAN4.readPlayWoodState();
				}
				int num = 100;
				while (true)
				{
					DateTime now = DateTime.Now;
					double num2 = 0.0;
					do
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						if (QnCommon.mPlayWoodState_Sensor != -1)
						{
							break;
						}
						Thread.Sleep(0);
						num2 = (DateTime.Now - now).TotalMilliseconds;
					}
					while (num2 < (double)num);
					if (num2 < (double)num)
					{
						break;
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					if (!MainForm0.mIsSimulation)
					{
						MainForm0.mConDevExt[0].readPlayWoodState();
					}
					if (is_sim_tran4())
					{
						QnCommon.mPlayWoodState_Sensor = MainForm0.mDebugFormTRAN4.get_S();
					}
				}
				if (((uint)QnCommon.mPlayWoodState_Sensor & (true ? 1u : 0u)) != 0 || ((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0)
				{
					BeginInvoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，开始贴装..");
					});
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					int ab = 0;
					if (((uint)QnCommon.mPlayWoodState_Sensor & (true ? 1u : 0u)) != 0 && (QnCommon.mPlayWoodState_Sensor & 2) == 0)
					{
						mloop.Clear();
						mloop.Add(0);
						ab = 0;
					}
					else if ((QnCommon.mPlayWoodState_Sensor & 1) == 0 && ((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0)
					{
						mloop.Clear();
						mloop.Add(1);
						ab = 1;
					}
					else if (mloop[0] == 0)
					{
						mloop.Clear();
						mloop.Add(1);
						ab = 1;
					}
					else if (mloop[0] == 1)
					{
						mloop.Clear();
						mloop.Add(0);
						ab = 0;
					}
					if (youxian_pik == 0)
					{
						mloop_idx = 0;
						msmtchip_idx_raw = 0;
						msmtchip_idx = 0;
						mis_maybe_continue = 0;
					}
					if (mthd_smtRun != null && mthd_smtRun.IsAlive)
					{
						mthd_smtRun.Abort();
						Thread.Sleep(100);
					}
					mthd_smtRun = new Thread(thd_SmtLoop);
					mthd_smtRun.IsBackground = true;
					mthd_smtRun.Start(mloop);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，正在贴装..");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					Thread.Sleep(300);
					while (vsplus_smtbusy() || MainForm0.mRunDoing[mFn] != 0)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -2;
						}
						Thread.Sleep(100);
					}
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "贴装完成，等待出板..");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
						if (is_sim_tran4())
						{
							MainForm0.mDebugFormTRAN4.sendOutBoard(ab);
						}
					});
					sub_transter_4_boardsmt_finish(mloop[0]);
					if (bIsFinishAutoRun)
					{
						break;
					}
					if (USR3B.mPrjSmtMode == 1 && mUSR3List.Count == HW.mSections && !is_tran4_can_youxianpik(mUSR3List))
					{
						youxian_pik = 0;
					}
					if (youxian_pik != 0)
					{
						mloop_idx = 0;
						msmtchip_idx_raw = 0;
						msmtchip_idx = 0;
						mis_maybe_continue = 0;
						Thread thread2 = new Thread(thd_SmtLoop_YouxianPik);
						thread2.IsBackground = true;
						thread2.Start(mloop);
					}
				}
				Thread.Sleep(100);
			}
			return -1;
		}

		private bool is_sim_tran4()
		{
			if (MainForm0.mIsSimulation && MainForm0.mDebugFormTRAN4 != null)
			{
				return !MainForm0.mDebugFormTRAN4.IsDisposed;
			}
			return false;
		}

		private void sub_transter_4_boardsmt_finish(int boardno)
		{
			if (!MainForm0.mIsSimulation)
			{
				MainForm0.mConDevExt[0].send_tran4_smt_finish(boardno, 1);
			}
			MainForm0.msdelay(USR3B.mOem.tran4_waitnewsignal_delay);
			Thread thread = new Thread(thd_transter_4_boardsmt_finish_signal_close);
			thread.IsBackground = true;
			thread.Start(boardno);
		}

		private void thd_transter_4_boardsmt_finish_signal_close(object o)
		{
			MainForm0.msdelay(USR3B.mOem.tran4_finishsignal_delay);
			if (!MainForm0.mIsSimulation)
			{
				MainForm0.mConDevExt[0].send_tran4_smt_finish((int)o, 0);
			}
		}

		private bool is_tran4_can_youxianpik(BindingList<USR3_DATA> musr3list)
		{
			if (musr3list == null || musr3list.Count == 0)
			{
				return false;
			}
			if (musr3list.Count == 1)
			{
				return true;
			}
			if (musr3list.Count > 2)
			{
				return false;
			}
			if (musr3list.Count == 2)
			{
				if (musr3list[0].mPointlistSmt == null || musr3list[1].mPointlistSmt == null)
				{
					return false;
				}
				if (musr3list[0].mPointlistSmt.Count != musr3list[1].mPointlistSmt.Count)
				{
					return false;
				}
				int count = musr3list[0].mPointlistSmt.Count;
				for (int i = 0; i < count; i++)
				{
					if (musr3list[0].mPointlistSmt[i].Material_value != musr3list[1].mPointlistSmt[i].Material_value)
					{
						return false;
					}
					if (musr3list[0].mPointlistSmt[i].Footprint != musr3list[1].mPointlistSmt[i].Footprint)
					{
						return false;
					}
					if (musr3list[0].mPointlistSmt[i].Feedertype != musr3list[1].mPointlistSmt[i].Feedertype)
					{
						return false;
					}
					if (musr3list[0].mPointlistSmt[i].Stack_no != musr3list[1].mPointlistSmt[i].Stack_no)
					{
						return false;
					}
					if (musr3list[0].mPointlistSmt[i].Group != musr3list[1].mPointlistSmt[i].Group)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public void init_pcbedit_smtlist(int f)
		{
			MainForm0.mLegal_Msg = new string[1];
			MainForm0.mLegal_Msg[0] = "";
			msmt_real_chips = 0;
			msmt_real_loops = 0;
			Invoke((MethodInvoker)delegate
			{
				set_label_all_curchipindex(msmt_real_chips);
				set_label_all_pcbs(msmt_real_loops);
			});
			if (USR3B.mNozzles == null || USR3B.mNozzles.Count() != HW.mZnNum[MainForm0.mFn])
			{
				USR3B.mNozzles = new string[HW.mZnNum[MainForm0.mFn]];
			}
			if (USR3B.mNozzleEnable == null || USR3B.mNozzleEnable.Count() != HW.mZnNum[MainForm0.mFn])
			{
				USR3B.mNozzleEnable = new int[HW.mZnNum[MainForm0.mFn]];
				for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
				{
					USR3B.mNozzleEnable[i] = 1;
				}
			}
			isSlotOcpy = new float[2][];
			isSlotBrkn = new float[2][];
			slot_feeder_component = new ChipCategoryElement[2][];
			for (int j = 0; j < 2; j++)
			{
				isSlotOcpy[j] = new float[100];
				isSlotBrkn[j] = new float[100];
				slot_feeder_component[j] = new ChipCategoryElement[100];
				for (int k = 0; k < HW.malgo2[f].len[j]; k++)
				{
					isSlotOcpy[j][k] = 0f;
					if ((k >= HW.malgo2[f].emp_l[j] && k < HW.malgo2[f].emp_l[j] + HW.malgo2[f].slt_l[j]) || (k >= HW.malgo2[f].emp_l[j] + HW.malgo2[f].slt_l[j] + HW.malgo2[f].emp_m[j] && k < HW.malgo2[f].emp_l[j] + HW.malgo2[f].slt_l[j] + HW.malgo2[f].emp_m[j] + HW.malgo2[f].slt_r[j]))
					{
						isSlotBrkn[j][k] = 0f;
					}
					else
					{
						isSlotBrkn[j][k] = 1f;
					}
					slot_feeder_component[j][k] = null;
				}
			}
			if (USR3B.mSmtDevice != USR.mSmtDevice)
			{
				USR3B.isSlotOcpy = null;
				USR3B.isSlotBrkn = null;
				USR3B.slot_feeder_component = null;
				USR3B.mPlateInstallList = null;
				USR3B.mVibraInstallList = null;
				USR3.mPikGroups = null;
				USR3.mQQList = null;
				USR3B.mSmtDevice = USR.mSmtDevice;
			}
			if (USR3B.isSlotOcpy == null || USR3B.isSlotOcpy[0].Count() < isSlotOcpy[0].Count())
			{
				USR3B.isSlotOcpy = isSlotOcpy;
			}
			if (USR3B.isSlotBrkn == null || USR3B.isSlotBrkn[0].Count() < isSlotBrkn[0].Count())
			{
				USR3B.isSlotBrkn = isSlotBrkn;
			}
			if (USR3B.slot_feeder_component == null || USR3B.slot_feeder_component[0].Count() < slot_feeder_component[0].Count())
			{
				USR3B.slot_feeder_component = slot_feeder_component;
			}
			if (USR3B.mPlateInstallList == null)
			{
				USR3B.mPlateInstallList = new BindingList<SmtFeederInstallElement>();
			}
			if (USR3B.mVibraInstallList == null)
			{
				USR3B.mVibraInstallList = new BindingList<SmtFeederInstallElement>();
			}
			mMarkFound[0] = new Coordinate();
			mMarkFound[1] = new Coordinate();
		}

		public BindingList<BindingList<ChipBoardElement>> syncPikList(BindingList<ChipBoardElement> smtlist_input, int isMountMask)
		{
			BindingList<BindingList<ChipBoardElement>> bindingList = new BindingList<BindingList<ChipBoardElement>>();
			BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
			for (int i = 0; i < smtlist_input.Count; i++)
			{
				if (((uint)(isMountMask >> i) & (true ? 1u : 0u)) != 0)
				{
					bindingList2.Add(smtlist_input[i]);
				}
			}
			BindingList<ChipBoardElement> bindingList3 = new BindingList<ChipBoardElement>();
			ChipBoardElement[] array = bindingList2.OrderBy((ChipBoardElement a) => a.samePikNo).ToArray();
			for (int j = 0; j < bindingList2.Count; j++)
			{
				bindingList3.Add(array[j]);
			}
			for (int k = 0; k < bindingList3.Count; k++)
			{
				if (bindingList3[k].samePikNo == -1)
				{
					BindingList<ChipBoardElement> bindingList4 = new BindingList<ChipBoardElement>();
					bindingList4.Add(bindingList3[k]);
					bindingList.Add(bindingList4);
					continue;
				}
				bool flag = false;
				for (int l = 0; l < bindingList.Count; l++)
				{
					for (int m = 0; m < bindingList[l].Count; m++)
					{
						if (bindingList3[k].samePikNo == bindingList[l][m].samePikNo)
						{
							flag = true;
							bindingList[l].Add(bindingList3[k]);
							break;
						}
					}
				}
				if (!flag)
				{
					BindingList<ChipBoardElement> bindingList5 = new BindingList<ChipBoardElement>();
					bindingList5.Add(bindingList3[k]);
					bindingList.Add(bindingList5);
				}
			}
			BindingList<BindingList<ChipBoardElement>> bindingList6 = new BindingList<BindingList<ChipBoardElement>>();
			if (smtlist_input[0].Stacktype != 0)
			{
				return bindingList;
			}
			for (int n = 0; n < bindingList.Count; n++)
			{
				int count = bindingList[n].Count;
				int[] array2 = new int[count];
				for (int num = 0; num < count; num++)
				{
					array2[num] = 1;
				}
				while (count > 0)
				{
					BindingList<int[]> bindingList7 = common_sub_mask(count);
					for (int num2 = 0; num2 < bindingList7.Count; num2++)
					{
						int num3 = 0;
						float num4 = 0f;
						float num5 = 0f;
						int num6 = 0;
						for (num6 = 0; num6 < count; num6++)
						{
							if (bindingList7[num2][num6] == 1)
							{
								int num7 = bindingList[n][num6].Nozzle - 1;
								num3++;
								num4 += (float)(USR2.mStackLib.stacktab[0][bindingList[n][num6].Stack_no - 1].mXY.X - USR.mDeltaNozzle[0][num7].X);
								num5 += (float)(USR2.mStackLib.stacktab[0][bindingList[n][num6].Stack_no - 1].mXY.Y - USR.mDeltaNozzle[0][num7].Y);
							}
						}
						if (num3 == 0)
						{
							continue;
						}
						num4 /= (float)num3;
						num5 /= (float)num3;
						for (num6 = 0; num6 < count; num6++)
						{
							if (bindingList7[num2][num6] == 1)
							{
								int num8 = bindingList[n][num6].Nozzle - 1;
								float num9 = Math.Abs(num4 - (float)(USR2.mStackLib.stacktab[0][bindingList[n][num6].Stack_no - 1].mXY.X - USR.mDeltaNozzle[0][num8].X));
								float num10 = Math.Abs(num5 - (float)(USR2.mStackLib.stacktab[0][bindingList[n][num6].Stack_no - 1].mXY.Y - USR.mDeltaNozzle[0][num8].Y));
								float num11 = get_SyncPikDelta(bindingList[n][num6].Material_value, bindingList[n][num6].Footprint);
								if (num9 > num11 * 100f || num10 > num11 * 100f)
								{
									break;
								}
							}
						}
						if (num6 != count)
						{
							continue;
						}
						BindingList<ChipBoardElement> bindingList8 = new BindingList<ChipBoardElement>();
						for (num6 = 0; num6 < count; num6++)
						{
							if (bindingList7[num2][num6] == 1)
							{
								bindingList8.Add(bindingList[n][num6]);
							}
						}
						bindingList6.Add(bindingList8);
						for (int num12 = 0; num12 < bindingList8.Count; num12++)
						{
							bindingList[n].Remove(bindingList8[num12]);
						}
						count = bindingList[n].Count;
					}
				}
			}
			return bindingList6;
		}

		private float get_SyncPikDelta(string value, string foot_print)
		{
			for (int i = 0; i < USR3B.mPointlistCat.Count; i++)
			{
				if (value == USR3B.mPointlistCat[i].Material_value && foot_print == USR3B.mPointlistCat[i].Footprint)
				{
					return USR3B.mPointlistCat[i].Delta;
				}
			}
			return 0f;
		}

		private BindingList<int[]> common_sub_mask(int length)
		{
			BindingList<int[]> bindingList = new BindingList<int[]>();
			int num = (1 << length) - 1;
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j <= num; j++)
				{
					if (zeroBitNum(j, length) == i)
					{
						int[] item = int_array_from_bit(j, length);
						bindingList.Add(item);
					}
				}
			}
			return bindingList;
		}

		private int zeroBitNum(int inputvalue, int len)
		{
			int num = 0;
			for (int i = 0; i < len; i++)
			{
				if (((inputvalue >> i) & 1) == 0)
				{
					num++;
				}
			}
			return num;
		}

		private int[] int_array_from_bit(int value, int len)
		{
			int[] array = new int[len];
			for (int i = 0; i < len; i++)
			{
				array[i] = (value >> i) & 1;
			}
			return array;
		}

		private void init_smtinfo()
		{
			checkBox_simulate_visualpass.Checked = is_ignore_visualfail;
			label_smt_chips_byzn = new Label[HW.mZnNum[mFn]];
			label_smt_drops_byzn = new Label[HW.mZnNum[mFn]];
			label_smt_droprate_byzn = new Label[HW.mZnNum[mFn]];
			label_smt_nones_byzn = new Label[HW.mZnNum[mFn]];
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				Label label = label104;
				Label label2 = new Label();
				panel6.Controls.Add(label2);
				int num = label.Location.Y + 26 + 8;
				label2.Location = new Point(label.Location.X, num + i * 28);
				label2.Size = label.Size;
				label2.AutoSize = false;
				label2.Font = label.Font;
				label2.Text = STR.NOZZLE_a[MainForm0.USR_INIT.mLanguage] + (i + 1);
				label2.BackColor = label.BackColor;
				label2.BorderStyle = label.BorderStyle;
				label2.TextAlign = ContentAlignment.MiddleCenter;
				Label label3 = this.label8;
				Label label4 = new Label();
				panel6.Controls.Add(label4);
				int num2 = label3.Location.Y + 26 + 8;
				label4.Location = new Point(label3.Location.X, num2 + i * 28);
				label4.Size = label3.Size;
				label4.AutoSize = false;
				label4.Font = label3.Font;
				label4.Text = (new string[3] { "贴片数量", "貼片數量", "Smt Counts" })[MainForm0.USR_INIT.mLanguage];
				label4.BorderStyle = label3.BorderStyle;
				label4.TextAlign = ContentAlignment.MiddleCenter;
				Label label5 = label_infototalchips;
				Label label6 = new Label();
				panel6.Controls.Add(label6);
				int num3 = label5.Location.Y + 26 + 8;
				label6.Location = new Point(label5.Location.X, num3 + i * 28);
				label6.Size = label5.Size;
				label6.AutoSize = false;
				label6.Font = label5.Font;
				label6.Text = "0";
				label6.BackColor = label5.BackColor;
				label6.ForeColor = Color.DarkGray;
				label6.BorderStyle = label5.BorderStyle;
				label6.TextAlign = ContentAlignment.MiddleCenter;
				label_smt_chips_byzn[i] = label6;
				Label label7 = this.label9;
				Label label8 = new Label();
				panel6.Controls.Add(label8);
				int num4 = label7.Location.Y + 26 + 8;
				label8.Location = new Point(label7.Location.X, num4 + i * 28);
				label8.Size = label7.Size;
				label8.AutoSize = false;
				label8.Font = label7.Font;
				label8.Text = (new string[3] { "空取", "空取", "Pick None" })[MainForm0.USR_INIT.mLanguage];
				label8.BorderStyle = label7.BorderStyle;
				label8.TextAlign = ContentAlignment.MiddleCenter;
				label8.Visible = false;
				Label label9 = label_infototalnones;
				Label label10 = new Label();
				panel6.Controls.Add(label10);
				int num5 = label9.Location.Y + 26 + 8;
				label10.Location = new Point(label9.Location.X, num5 + i * 28);
				label10.Size = label9.Size;
				label10.AutoSize = false;
				label10.Font = label9.Font;
				label10.Text = "0";
				label10.BackColor = label9.BackColor;
				label10.BorderStyle = label9.BorderStyle;
				label10.ForeColor = Color.DarkGray;
				label10.TextAlign = ContentAlignment.MiddleCenter;
				label_smt_nones_byzn[i] = label10;
				label10.Visible = false;
				Label label11 = this.label5;
				Label label12 = new Label();
				panel6.Controls.Add(label12);
				int num6 = label11.Location.Y + 26 + 8;
				label12.Location = new Point(label11.Location.X, num6 + i * 28);
				label12.Size = label11.Size;
				label12.AutoSize = false;
				label12.Font = label11.Font;
				label12.Text = (new string[3] { "抛料", "拋料", "Drop" })[MainForm0.USR_INIT.mLanguage];
				label12.BorderStyle = label11.BorderStyle;
				label12.TextAlign = ContentAlignment.MiddleCenter;
				Label label13 = label_infototaldrops;
				Label label14 = new Label();
				panel6.Controls.Add(label14);
				int num7 = label13.Location.Y + 26 + 8;
				label14.Location = new Point(label13.Location.X, num7 + i * 28);
				label14.Size = label13.Size;
				label14.AutoSize = false;
				label14.Font = label13.Font;
				label14.Text = "0";
				label14.BackColor = label13.BackColor;
				label14.ForeColor = Color.DarkGray;
				label14.BorderStyle = label13.BorderStyle;
				label14.TextAlign = ContentAlignment.MiddleCenter;
				label_smt_drops_byzn[i] = label14;
				Label label15 = this.label4;
				Label label16 = new Label();
				panel6.Controls.Add(label16);
				int num8 = label15.Location.Y + 26 + 8;
				label16.Location = new Point(label15.Location.X, num8 + i * 28);
				label16.Size = label15.Size;
				label16.AutoSize = false;
				label16.Font = label15.Font;
				label16.Text = (new string[3] { "抛料率", "拋料率", "Drop Rate" })[MainForm0.USR_INIT.mLanguage];
				label16.BorderStyle = label15.BorderStyle;
				label16.TextAlign = ContentAlignment.MiddleCenter;
				Label label17 = label_infototaldroprate;
				Label label18 = new Label();
				panel6.Controls.Add(label18);
				int num9 = label17.Location.Y + 26 + 8;
				label18.Location = new Point(label17.Location.X, num9 + i * 28);
				label18.Size = label17.Size;
				label18.AutoSize = false;
				label18.Font = label17.Font;
				label18.Text = "0.0%";
				label18.ForeColor = Color.DarkGray;
				label18.BackColor = label17.BackColor;
				label18.BorderStyle = label17.BorderStyle;
				label18.TextAlign = ContentAlignment.MiddleCenter;
				label_smt_droprate_byzn[i] = label18;
				Label label19 = this.label11;
				Label label20 = new Label();
				panel6.Controls.Add(label20);
				int num10 = label19.Location.Y + 26 + 8;
				label20.Location = new Point(label19.Location.X, num10 + i * 28);
				label20.Size = label19.Size;
				label20.AutoSize = false;
				label20.Font = label19.Font;
				label20.Text = (new string[3] { "异常", "異常", "Abnornal" })[MainForm0.USR_INIT.mLanguage];
				label20.BorderStyle = label19.BorderStyle;
				label20.TextAlign = ContentAlignment.MiddleCenter;
				label20.Visible = false;
				Label label21 = label_infototalexceptions;
				Label label22 = new Label();
				panel6.Controls.Add(label22);
				int num11 = label21.Location.Y + 26 + 8;
				label22.Location = new Point(label21.Location.X, num11 + i * 28);
				label22.Size = label21.Size;
				label22.AutoSize = false;
				label22.Font = label21.Font;
				label22.ForeColor = Color.DarkGray;
				label22.Text = "0";
				label22.BackColor = label21.BackColor;
				label22.BorderStyle = label21.BorderStyle;
				label22.TextAlign = ContentAlignment.MiddleCenter;
				label22.Visible = false;
			}
		}

		public void smtinfo_update_drops_plusplus(int mode, ProviderType providertype, int stackno, int zn)
		{
			bool flag = true;
			if (USR3B.mInfo_OnlyAutoMode && msmt_mode != SmtOpMode.AutoRun)
			{
				flag = false;
			}
			if (USR3B.mInfo.none_chips == null)
			{
				USR3B.mInfo = new SmtInfo();
			}
			if (!flag)
			{
				return;
			}
			switch (mode)
			{
			case 0:
				USR3B.mInfo.drop_chips[zn]++;
				break;
			case 1:
				USR3B.mInfo.none_chips[zn]++;
				break;
			}
			switch (mode)
			{
			case 0:
				USR3B.mInfo.dropChips++;
				break;
			case 1:
				USR3B.mInfo.noneChips++;
				break;
			}
			USR3B.mInfo.drop_rate[zn] = USR3B.mInfo.Calc_droprate(zn);
			USR3B.mInfo.none_rate[zn] = USR3B.mInfo.Calc_nonerate(zn);
			USR3B.mInfo.droprate = USR3B.mInfo.Calc_droprate();
			USR3B.mInfo.nonerate = USR3B.mInfo.Calc_nonerate();
			if (base.Visible)
			{
				Invoke((MethodInvoker)delegate
				{
					label_smt_drops_byzn[zn].Text = USR3B.mInfo.drop_chips[zn].ToString();
					label_smt_droprate_byzn[zn].Text = USR3B.mInfo.drop_rate[zn].ToString("F1") + "%";
					label_infototaldrops.Text = USR3B.mInfo.dropChips.ToString();
					label_infototaldroprate.Text = USR3B.mInfo.droprate.ToString("F1") + "%";
					label_infototalnones.Text = USR3B.mInfo.noneChips.ToString();
				});
			}
			switch (mode)
			{
			case 0:
			{
				int[][] array2 = USR3B.mThrowRateCheckList[(int)providertype];
				array2[stackno][zn]++;
				break;
			}
			case 1:
			{
				int[][] array = USR3B.mNoneChipRateCheckList[(int)providertype];
				array[stackno][zn]++;
				break;
			}
			}
		}

		public void smtnew_resetandflush_runningdata()
		{
			Invoke((MethodInvoker)delegate
			{
				m_start_smt_time = DateTime.Now;
			});
		}

		public void smtnew_flushdata()
		{
			checkBox_onlyAutoMode.Checked = USR3B.mInfo_OnlyAutoMode;
			DateTime now = DateTime.Now;
			label_infodate.Text = now.Year + "/" + now.Month + "/" + now.Day;
			label_infototalpcbs.Text = USR3B.mInfo.mountPcbs.ToString();
			label_infototalchips.Text = USR3B.mInfo.mountChips.ToString();
			label_infototaldrops.Text = USR3B.mInfo.dropChips.ToString();
			label_infototaldroprate.Text = USR3B.mInfo.droprate + "%";
			label_infototalexceptions.Text = USR3B.mInfo.exceptions.ToString();
			label_infototalnones.Text = USR3B.mInfo.noneChips.ToString();
			textBox_infolog.Text = USR3B.mInfoFileDir;
			try
			{
				for (int i = 0; i < HW.mZnNum[mFn]; i++)
				{
					label_smt_chips_byzn[i].Text = USR3B.mInfo.mnt_chips[i].ToString();
					label_smt_nones_byzn[i].Text = USR3B.mInfo.none_chips[i].ToString();
					label_smt_drops_byzn[i].Text = USR3B.mInfo.drop_chips[i].ToString();
					label_smt_droprate_byzn[i].Text = USR3B.mInfo.drop_rate[i] + "%";
				}
			}
			catch (Exception)
			{
				MainForm0.write_to_logFile_EXCEPTION(" smtnew_flushdata ");
				USR3B.mInfo.mnt_chips = new int[160];
				for (int j = 0; j < 160; j++)
				{
					USR3B.mInfo.mnt_chips[j] = 0;
				}
				USR3B.mInfo.none_chips = new int[160];
				for (int k = 0; k < 160; k++)
				{
					USR3B.mInfo.none_chips[k] = 0;
				}
				USR3B.mInfo.none_rate = new float[160];
				for (int l = 0; l < 160; l++)
				{
					USR3B.mInfo.none_rate[l] = 0f;
				}
				USR3B.mInfo.drop_chips = new int[160];
				for (int m = 0; m < 160; m++)
				{
					USR3B.mInfo.drop_chips[m] = 0;
				}
				USR3B.mInfo.drop_rate = new float[160];
				for (int n = 0; n < 160; n++)
				{
					USR3B.mInfo.drop_rate[n] = 0f;
				}
				for (int num = 0; num < HW.mZnNum[mFn]; num++)
				{
					label_smt_chips_byzn[num].Text = USR3B.mInfo.mnt_chips[num].ToString();
					label_smt_drops_byzn[num].Text = USR3B.mInfo.drop_chips[num].ToString();
					label_smt_nones_byzn[num].Text = USR3B.mInfo.none_chips[num].ToString();
					label_smt_droprate_byzn[num].Text = USR3B.mInfo.drop_rate[num].ToString("F1") + "%";
				}
			}
			if (USR3B.mThrowRateCheckList == null)
			{
				USR3B.mThrowRateCheckList = new int[3][][];
				for (int num2 = 0; num2 < 3; num2++)
				{
					USR3B.mThrowRateCheckList[num2] = new int[160][];
					for (int num3 = 0; num3 < 160; num3++)
					{
						USR3B.mThrowRateCheckList[num2][num3] = new int[8];
						for (int num4 = 0; num4 < 8; num4++)
						{
							USR3B.mThrowRateCheckList[num2][num3][num4] = 0;
						}
					}
				}
			}
			if (USR3B.mNoneChipRateCheckList != null)
			{
				return;
			}
			USR3B.mNoneChipRateCheckList = new int[3][][];
			for (int num5 = 0; num5 < 3; num5++)
			{
				USR3B.mNoneChipRateCheckList[num5] = new int[160][];
				for (int num6 = 0; num6 < 160; num6++)
				{
					USR3B.mNoneChipRateCheckList[num5][num6] = new int[8];
					for (int num7 = 0; num7 < 8; num7++)
					{
						USR3B.mNoneChipRateCheckList[num5][num6][num7] = 0;
					}
				}
			}
		}

		public void smtinfo_update_mountChips_plusplus(int zn)
		{
			bool flag = true;
			if (USR3B.mInfo_OnlyAutoMode && msmt_mode != SmtOpMode.AutoRun)
			{
				flag = false;
			}
			if (!flag)
			{
				return;
			}
			if (zn == 8)
			{
				USR3B.mInfo.mountChips++;
				USR3B.mInfo.nonerate = USR3B.mInfo.Calc_nonerate();
				USR3B.mInfo.droprate = USR3B.mInfo.Calc_droprate();
				if (base.Visible)
				{
					Invoke((MethodInvoker)delegate
					{
						label_infototalchips.Text = USR3B.mInfo.mountChips.ToString();
						label_infototaldroprate.Text = USR3B.mInfo.droprate.ToString("F1") + "%";
					});
				}
				return;
			}
			USR3B.mInfo.mnt_chips[zn]++;
			USR3B.mInfo.drop_rate[zn] = USR3B.mInfo.Calc_droprate(zn);
			USR3B.mInfo.none_rate[zn] = USR3B.mInfo.Calc_nonerate(zn);
			if (base.Visible)
			{
				Invoke((MethodInvoker)delegate
				{
					label_smt_chips_byzn[zn].Text = USR3B.mInfo.mnt_chips[zn].ToString();
					label_smt_droprate_byzn[zn].Text = USR3B.mInfo.drop_rate[zn].ToString("F1") + "%";
				});
			}
		}

		public void smtinfo_update_mountPcbs_plusplus()
		{
			if (USR3B.mInfo_OnlyAutoMode)
			{
				_ = msmt_mode;
				_ = 4;
			}
			USR3B.mInfo.mountPcbs++;
			if (base.Visible)
			{
				Invoke((MethodInvoker)delegate
				{
					label_infototalpcbs.Text = USR3B.mInfo.mountPcbs.ToString();
				});
			}
			DateTime now = DateTime.Now;
			if (base.Visible)
			{
				label_infodate.Text = now.Year + "/" + now.Month + "/" + now.Day;
			}
			double time_dury = (DateTime.Now - m_start_smt_time).TotalMilliseconds;
			if (time_dury / 1000.0 > 1000000.0)
			{
				time_dury = 0.0;
			}
			if (base.Visible)
			{
				Invoke((MethodInvoker)delegate
				{
					label_infocycletime.Text = (time_dury * 0.95 / 1000.0).ToString("0.00") + "S";
				});
			}
		}

		private void __checkBox_onlyAutoMode_CheckedChanged(object sender, EventArgs e)
		{
			USR3B.mInfo_OnlyAutoMode = checkBox_onlyAutoMode.Checked;
		}

		private void __button_Infologfile_browse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = ((USR_INIT.mLanguage == 2) ? "Please select file path " : "请选择文件路径");
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				string selectedPath = folderBrowserDialog.SelectedPath;
				textBox_infolog.Text = selectedPath;
				USR3B.mInfoFileDir = selectedPath;
				MessageBox.Show(((USR_INIT.mLanguage == 2) ? "Selected folder:" : "已选择文件夹:") + selectedPath, (USR_INIT.mLanguage == 2) ? "Notice" : "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void __button_throwrate_check_Click(object sender, EventArgs e)
		{
			Form_ThrowRateCheck form_ThrowRateCheck = new Form_ThrowRateCheck(USR_INIT.mLanguage, USR3B.mThrowRateCheckList, USR3B.mNoneChipRateCheckList);
			form_ThrowRateCheck.ShowDialog();
		}

		private void __button_info_clear_Click(object sender, EventArgs e)
		{
			USR3B.mInfo.clear();
			smtnew_flushdata();
			smtnew_resetandflush_runningdata();
			if (USR3B.mThrowRateCheckList == null)
			{
				USR3B.mThrowRateCheckList = new int[3][][];
			}
			if (USR3B.mNoneChipRateCheckList == null)
			{
				USR3B.mNoneChipRateCheckList = new int[3][][];
			}
			for (int i = 0; i < 3; i++)
			{
				USR3B.mThrowRateCheckList[i] = new int[160][];
				USR3B.mNoneChipRateCheckList[i] = new int[160][];
				for (int j = 0; j < 160; j++)
				{
					USR3B.mThrowRateCheckList[i][j] = new int[8];
					USR3B.mNoneChipRateCheckList[i][j] = new int[8];
					for (int k = 0; k < 8; k++)
					{
						USR3B.mThrowRateCheckList[i][j][k] = 0;
						USR3B.mNoneChipRateCheckList[i][j][k] = 0;
					}
				}
			}
		}

		private void panel_vsplus_fakepcb_Paint(object sender, PaintEventArgs e)
		{
			Panel panel = (Panel)sender;
			string text = (string)panel.Tag;
			int num = -1;
			if (mPanel_fakepcb_list == null || mUSR3List == null)
			{
				return;
			}
			for (int i = 0; i < mPanel_fakepcb_list.Count; i++)
			{
				if (text == (string)mPanel_fakepcb_list[i].Tag)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				draw_fakepcb(panel, panel_fakepcb_smt.Size, mUSR3List[num].mPointlistSmt);
			}
		}

		public void draw_fakePcbBoard(USR3_DATA usr3)
		{
			if (usr3 == null || usr3.mPointlistSmt == null || mPanel_fakepcb_list == null)
			{
				return;
			}
			usr3.draw_chipinfo_list = new BindingList<DrawFakeChip>();
			for (int i = 0; i < usr3.mPointlistSmt.Count; i++)
			{
				DrawFakeChip item = new DrawFakeChip();
				usr3.draw_chipinfo_list.Add(item);
			}
			int num = -1;
			for (int j = 0; j < mPanel_fakepcb_list.Count; j++)
			{
				if (mPanel_fakepcb_list[j].Tag == usr3.mPcbID)
				{
					num = j;
					break;
				}
			}
			if (num != -1)
			{
				draw_fakepcb(mPanel_fakepcb_list[num], panel_fakepcb_smt.Size, usr3.mPointlistSmt);
			}
		}

		public void draw_fakechip(int usr3idx, int index, bool isdone)
		{
			USR3_DATA usr3 = mUSR3List[usr3idx];
			Panel panelfake = mPanel_fakepcb_list[usr3idx];
			if (usr3.draw_chipinfo_list != null && usr3.draw_chipinfo_list.Count != 0 && usr3.draw_chipinfo_list.Count > 1 && index < usr3.draw_chipinfo_list.Count)
			{
				BeginInvoke((MethodInvoker)delegate
				{
					Graphics graphics = panelfake.CreateGraphics();
					SolidBrush solidBrush = new SolidBrush(Color.Black);
					SolidBrush solidBrush2 = new SolidBrush(Color.White);
					usr3.draw_chipinfo_list[index].isdone = isdone;
					graphics.FillRectangle(isdone ? solidBrush : solidBrush2, usr3.draw_chipinfo_list[index].draw_smt_x, usr3.draw_chipinfo_list[index].draw_smt_y, usr3.draw_chipinfo_list[index].draw_smt_w, usr3.draw_chipinfo_list[index].draw_smt_h);
					solidBrush.Dispose();
					solidBrush2.Dispose();
					graphics.Dispose();
				});
			}
		}

		public void draw_fakepcb(Panel panel_fake, Size panel_size, BindingList<ChipBoardElement> pointlist)
		{
			if (USR3 == null || pointlist == null || pointlist.Count == 0)
			{
				panel_fake.Controls.Clear();
				Graphics graphics = panel_fake.CreateGraphics();
				graphics.Clear(panel_fake.BackColor);
				graphics.Dispose();
				return;
			}
			int num = panel_size.Width;
			int num2 = panel_size.Height;
			int num3 = 6;
			int num4 = 4;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 99999f;
			float num8 = 99999f;
			float num9 = 1f;
			float num10 = 1f;
			float num11 = 1f;
			int num12 = 99999;
			for (int i = 0; i < pointlist.Count; i++)
			{
				if ((float)pointlist[i].X > num6)
				{
					num6 = (int)pointlist[i].X;
				}
				if ((float)pointlist[i].Y > num5)
				{
					num5 = (int)pointlist[i].Y;
				}
				if ((float)pointlist[i].X < num8)
				{
					num8 = (int)pointlist[i].X;
				}
				if ((float)pointlist[i].Y < num7)
				{
					num7 = (int)pointlist[i].Y;
				}
			}
			float num13 = (num6 - num8) / 10f;
			float num14 = (num5 - num7) / 10f;
			float num15 = num6;
			float num16 = num8;
			float num17 = num5;
			float num18 = num7;
			if (USR3.mArrayPCBRow > 1)
			{
				num17 = 0f;
				num18 = 99999f;
				for (int j = 0; j < pointlist.Count; j++)
				{
					if (pointlist[j].Arrayno == 0)
					{
						if ((float)pointlist[j].Y > num17)
						{
							num17 = pointlist[j].Y;
						}
						if ((float)pointlist[j].Y < num18)
						{
							num18 = pointlist[j].Y;
						}
					}
				}
				num14 = (num5 - num7 - (num17 - num18) * (float)USR3.mArrayPCBRow) / (float)(USR3.mArrayPCBRow - 1);
			}
			if (USR3.mArrayPCBColumn > 1)
			{
				num15 = 0f;
				num16 = 99999f;
				for (int k = 0; k < pointlist.Count; k++)
				{
					if (pointlist[k].Arrayno == 0)
					{
						if ((float)pointlist[k].X > num15)
						{
							num15 = pointlist[k].X;
						}
						if ((float)pointlist[k].X < num16)
						{
							num16 = pointlist[k].X;
						}
					}
				}
				num13 = (num6 - num8 - (num15 - num16) * (float)USR3.mArrayPCBColumn) / (float)(USR3.mArrayPCBColumn - 1);
			}
			num9 = (num6 - num8 + num13 * 4f / 5f) / (float)(num - num4 * 2);
			num10 = (num5 - num7 + num14 * 4f / 5f) / (float)(num2 - num4 * 2);
			num11 = ((!(num9 > num10)) ? num10 : num9);
			if ((double)num11 <= 1E-06)
			{
				return;
			}
			for (int l = 0; l < pointlist.Count; l++)
			{
				for (int m = l + 1; m < pointlist.Count; m++)
				{
					int num19 = (int)(pointlist[l].X - pointlist[m].X);
					int num20 = (int)(pointlist[l].Y - pointlist[m].Y);
					int num21 = (int)Math.Sqrt(num19 * num19 + num20 * num20);
					if (num21 < num12 && num21 > 0)
					{
						num12 = num21;
					}
				}
			}
			if ((float)num12 / num11 < (float)num3)
			{
				num11 = (float)num12 / (float)num3;
				num = (int)((num6 - num8 + num13 * 4f / 5f) / num11) + num4 * 2;
				num2 = (int)((num5 - num7 + num14 * 4f / 5f) / num11) + num4 * 2;
				panel_fake.Size = new Size(num, num2);
			}
			else
			{
				panel_fake.Size = new Size(panel_size.Width, panel_size.Height);
			}
			Graphics graphics2 = panel_fake.CreateGraphics();
			SolidBrush solidBrush = new SolidBrush(Color.DarkSeaGreen);
			SolidBrush solidBrush2 = new SolidBrush(Color.White);
			SolidBrush solidBrush3 = new SolidBrush(Color.Black);
			Pen pen = new Pen(Color.Black, 1f);
			int num22 = (num - (int)((double)((num6 - num8 + num13 * 4f / 5f) / num11) + 0.5)) / 2;
			int num23 = (num2 - (int)((double)((num5 - num7 + num14 * 4f / 5f) / num11) + 0.5)) / 2;
			int num24 = 5;
			int num25 = (int)((double)((num15 - num16 + num13 * 4f / 5f) / num11) + 0.5);
			int num26 = (int)((double)((num17 - num18 + num14 * 4f / 5f) / num11) + 0.5);
			int num27 = 0;
			int num28 = 0;
			if (num25 < 30)
			{
				num25 = 30;
				num27 = -13;
			}
			if (num26 < 30)
			{
				num26 = 30;
				num28 = -13;
			}
			for (int n = 0; n < USR3.mArrayPCBRow; n++)
			{
				for (int num29 = 0; num29 < USR3.mArrayPCBColumn; num29++)
				{
					int num30 = num22 + (int)((double)((float)num29 * (num15 - num16 + num13) / num11) + 0.5) + num27;
					int num31 = num23 + (int)((double)((float)n * (num17 - num18 + num14) / num11) + 0.5) + num28;
					graphics2.FillRectangle(solidBrush, num30, num31, num25, num26);
					graphics2.DrawRectangle(pen, num30, num31, num25, num26);
				}
			}
			for (int num32 = 0; num32 < pointlist.Count; num32++)
			{
				int draw_smt_x = num22 - num24 / 2 - 1 + (int)((double)(((float)pointlist[num32].X - num8 + num13 * 2f / 5f) / num11) + 0.5);
				int draw_smt_y = num23 - num24 / 2 - 1 + (int)((double)(((float)pointlist[num32].Y - num7 + num14 * 2f / 5f) / num11) + 0.5);
				int draw_smt_w = (int)((double)num24 + (double)num24 * Math.Abs(Math.Cos((double)pointlist[num32].A * 3.1415926 / 180.0)));
				int draw_smt_h = (int)((double)num24 + (double)num24 * Math.Abs(Math.Sin((double)pointlist[num32].A * 3.1415926 / 180.0)));
				SolidBrush brush = solidBrush2;
				if (pointlist == USR3.mPointlistSmt && USR3.draw_chipinfo_list != null && num32 < USR3.draw_chipinfo_list.Count())
				{
					USR3.draw_chipinfo_list[num32].draw_smt_x = draw_smt_x;
					USR3.draw_chipinfo_list[num32].draw_smt_y = draw_smt_y;
					USR3.draw_chipinfo_list[num32].draw_smt_w = draw_smt_w;
					USR3.draw_chipinfo_list[num32].draw_smt_h = draw_smt_h;
					brush = (USR3.draw_chipinfo_list[num32].isdone ? solidBrush3 : solidBrush2);
				}
				graphics2.FillRectangle(brush, draw_smt_x, draw_smt_y, draw_smt_w, draw_smt_h);
			}
			solidBrush.Dispose();
			solidBrush2.Dispose();
			solidBrush3.Dispose();
			pen.Dispose();
			graphics2.Dispose();
		}

		private void draw_fakechip_all(int usr3idx, bool isdone)
		{
			USR3_DATA usr3 = mUSR3List[usr3idx];
			_ = mPanel_fakepcb_list[usr3idx];
			if (usr3.draw_chipinfo_list == null || usr3.draw_chipinfo_list.Count == 0 || usr3.draw_chipinfo_list.Count <= 1)
			{
				return;
			}
			Invoke((MethodInvoker)delegate
			{
				Graphics graphics = panel_fakepcb_smt.CreateGraphics();
				SolidBrush solidBrush = new SolidBrush(Color.Black);
				SolidBrush solidBrush2 = new SolidBrush(Color.White);
				for (int i = 0; i < usr3.draw_chipinfo_list.Count; i++)
				{
					usr3.draw_chipinfo_list[i].isdone = isdone;
					graphics.FillRectangle(isdone ? solidBrush : solidBrush2, usr3.draw_chipinfo_list[i].draw_smt_x, usr3.draw_chipinfo_list[i].draw_smt_y, usr3.draw_chipinfo_list[i].draw_smt_w, usr3.draw_chipinfo_list[i].draw_smt_h);
				}
				solidBrush.Dispose();
				solidBrush2.Dispose();
				graphics.Dispose();
			});
		}

		public UserControl_job(int fn)
		{
			InitializeComponent();
			base.Size = new Size(719, 934);
			panel_SmtProducePage.Controls.Add(panel_smtinfo);
			panel_smtinfo.Location = panel_smtshoware.Location;
			mFn = fn;
			MainForm0.write_to_logFile("uc-job Fn = " + (mFn + 1));
			USR_INIT = MainForm0.USR_INIT;
			if (MainForm0.USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(MainForm0.USR_INIT.mLanguage, initLanguageTable());
			}
			if (HW.mFnNum == 2)
			{
				panel5.Visible = false;
				panel7.Visible = true;
				panel_SmtProducePage.Controls.Add(panel7);
				panel7.Location = new Point(0, 0);
				label17.Text = ((fn == 0) ? "左机-贴装生产" : "右机-贴装生产");
				panel7.BringToFront();
				panel7.Controls.Add(button_smt_showfackpcb);
				button_smt_showfackpcb.Location = new Point(4, 209);
				panel7.Controls.Add(button_vsplus_smtinfo);
				button_vsplus_smtinfo.Location = new Point(73, 209);
			}
			init_smtinfo();
		}

		public void instantiation(USR_DATA usr, USR2_DATA usr2, USR3_BASE usr3b, BindingList<USR3_DATA> usr3list, int usr3idx)
		{
			USR = usr;
			USR2 = usr2;
			USR3B = usr3b;
			mUSR3List = usr3list;
			mUSR3Idx = usr3idx;
			if (mUSR3List != null && mUSR3Idx >= 0 && mUSR3Idx < mUSR3List.Count)
			{
				USR3 = mUSR3List[mUSR3Idx];
				mPanel_fakepcb_list = new BindingList<Panel>();
				for (int i = 0; i < mUSR3List.Count; i++)
				{
					Panel panel = new Panel();
					panel_smtshoware.Controls.Add(panel);
					panel.Location = panel_fakepcb_smt.Location;
					panel.Size = panel_fakepcb_smt.Size;
					panel.Tag = mUSR3List[i].mPcbID;
					panel.Paint += panel_vsplus_fakepcb_Paint;
					panel.BringToFront();
					panel.Visible = false;
					mPanel_fakepcb_list.Add(panel);
				}
				uc_dgv_list = new BindingList<UserControl_pcbedit_datagridview>();
				for (int j = 0; j < mUSR3List.Count; j++)
				{
					UserControl_pcbedit_datagridview userControl_pcbedit_datagridview = new UserControl_pcbedit_datagridview(mFn, USR, USR2, mUSR3List[j], USR3B, is_pcbcheck: false);
					panel_PcbEditPage.Controls.Add(userControl_pcbedit_datagridview);
					userControl_pcbedit_datagridview.cb_pcbcheck_start += pcbcheck_start;
					userControl_pcbedit_datagridview.vsplus_smt_test += MainForm0.uc_job[mFn].vsplus_smt_test;
					userControl_pcbedit_datagridview.Location = panel_PCBE.Location;
					userControl_pcbedit_datagridview.BringToFront();
					uc_dgv_list.Add(userControl_pcbedit_datagridview);
					userControl_pcbedit_datagridview.open_uc_pcbedit_import();
					userControl_pcbedit_datagridview.display_uc_pcbedit_import(flag: false);
				}
				panel_PcbEditPage.Controls.Add(panel_subpcb);
				panel_subpcb.BringToFront();
				if (USR3B.mPrjMode == 1)
				{
					panel_subpcb.Visible = true;
				}
				if (uc_stack == null || uc_stack.IsDisposed)
				{
					uc_stack = new UserControl_Stack(mFn, USR, USR2, USR3B);
					base.Controls.Add(uc_stack);
					uc_stack.BackColor = Color.DimGray;
					uc_stack.Visible = false;
					uc_stack.Location = new Point(0, 0);
					uc_stack.BringToFront();
				}
				MainForm0.uc_VisualShowSmt[mFn] = new UserControl_VisualShow(mFn);
				MainForm0.static_tabControl_dsq.TabPages[mFn].Controls.Add(MainForm0.uc_VisualShowSmt[mFn]);
				MainForm0.uc_VisualShowSmt[mFn].Visible = false;
				MainForm0.uc_VisualShowSmt[mFn].BringToFront();
				MainForm0.uc_VisualShowSmt[mFn].Location = new Point(4, 2);
				smtnew_flushdata();
			}
		}

		public void display_pcbedit_import(bool flag)
		{
			if (uc_dgv_list != null)
			{
				for (int i = 0; i < uc_dgv_list.Count; i++)
				{
					uc_dgv_list[i].display_uc_pcbedit_import(flag);
				}
			}
		}

		public void set_enable(bool flag)
		{
			button_openFeederPage_vsplus.Enabled = flag;
			panel_PcbEditPage.Enabled = flag;
			cnButton_vsplus_setsmt.Enabled = flag;
		}

		public void uninstantiation()
		{
			if (uc_PcbCheck != null && !uc_PcbCheck.IsDisposed)
			{
				uc_PcbCheck.Dispose();
				uc_PcbCheck = null;
			}
			if (uc_dgv_list != null)
			{
				for (int i = 0; i < uc_dgv_list.Count; i++)
				{
					uc_dgv_list[i].SetEdit_XY(flag: false);
					uc_dgv_list[i].Dispose();
				}
				uc_dgv_list.Clear();
				uc_dgv_list = null;
			}
			if (mPanel_fakepcb_list != null)
			{
				for (int j = 0; j < mPanel_fakepcb_list.Count; j++)
				{
					mPanel_fakepcb_list[j].Dispose();
				}
				mPanel_fakepcb_list.Clear();
				mPanel_fakepcb_list = null;
			}
			if (uc_feederinstall != null && !uc_feederinstall.IsDisposed)
			{
				uc_feederinstall.Dispose();
			}
			if (uc_stack != null && !uc_stack.IsDisposed)
			{
				uc_stack.Dispose();
			}
		}

		public void load_data()
		{
			trackBar_smtXYSpeed.Value = USR3B.mSmtXYSpeed;
			label_smtXYSpeed.Text = USR3B.mSmtXYSpeed.ToString();
			trackBar_smtASpeed.Value = USR3B.mSmtASpeed;
			label_smtASpeed.Text = USR3B.mSmtASpeed.ToString();
			checkBox_flashlight.Checked = USR3B.mIsFlashlightMode;
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_openFeederPage,
				str = new string[3] { "料站参数", "料站参数", "Feeders" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Cat,
				str = new string[3] { "一键优化", "一键优化", "Optimize" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PCBE_feeder,
				str = new string[3] { "飞达安装", "飞达安装", "Feeder Plug" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Legal,
				str = new string[3] { "诊断检测", "诊断检测", "Diagnosis" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_goto_PCBEdit,
				str = new string[3] { "PCB编辑", "PCB編輯", "PCB Edit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_openFeederPage,
				str = new string[3] { "料站参数", "料站参数", "Feeder Para" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_openFeederPage_vsplus,
				str = new string[3] { "料站参数", "料站参数", "Feeder Para" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_smtTest,
				str = new string[3] { "贴装生产", "貼裝生產", "SMT Run" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_smtloopmode,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_vsplus_startsmt,
				str = new string[3] { "开始贴装", "開始貼裝", "Start" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PauseSmt,
				str = new string[3] { "暂停", "暫停", "Pause" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_PauseSmt,
				str = new string[3] { "暂停", "暂停", "PAUSE" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_vsplus_stopsmt,
				str = new string[3] { "结束", "結束", "Stop" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_vsplus_startsmt2,
				str = new string[3] { "开始贴装", "開始貼裝", "Start" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_vsplus_continuesmt,
				str = new string[3] { "续贴", "續貼", "Continue" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_smt_Aspeed,
				str = new string[3] { "旋转速度", "旋转速度", "Angle Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_smt_XYspeed,
				str = new string[3] { "XY速度", "XY速度", "XY Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_flashlight,
				str = new string[3] { "闪灯模式", "闪灯模式", "Flash Led" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_SmtVisualShow,
				str = new string[3] { "视觉", "视觉", "Visual" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_FinishAutoSmt,
				str = new string[3] { "结束全自动", "结束全自动", "Exit Auto" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_SmtState,
				str = new string[3] { "空闲状态", "空闲状态", "Idle Status" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_SmtIndexNo,
				str = new string[3] { "--", "--", "--" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_smt_showfackpcb,
				str = new string[3] { "板图", "板图", "View" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Loukong_clearS3,
				str = new string[3] { "出口位置PCB取走确认", "出口位置PCB取走确认", "Confirm take away PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_simulator,
				str = new string[3] { "仿真器", "仿真器", "Simulator" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_vsplus_smtinfo,
				str = new string[3] { "信息", "信息", "Info" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_vsplus_setsmt,
				str = new string[3] { "生产设置", "生產設置", "Smt Setting" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_smtxyaspeed_edit,
				str = new string[3] { "修改XY和A轴速度", "修改XY和A軸速度", "Edit XY/A Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label215,
				str = new string[3] { "当前标号", "當前標號", "Current No" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label40,
				str = new string[3] { "当前海拔(mm)", "當前海拔(mm)", "Current H-mm" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label207,
				str = new string[3] { "已贴板组", "已贴板组", "Smt PCBs" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label208,
				str = new string[3] { "已贴元件", "已贴元件", "Smt Chips" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label209,
				str = new string[3] { "最大速度(cph)", "最大速度(cph)", "Max Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label210,
				str = new string[3] { "平均速度(cph)", "平均速度(cph)", "Ave Speed" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabControl_mainwork,
				str = new string[3] { "", "", "" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage_main_pcbedit,
				str = new string[3] { "PCB编辑", "PCB编辑", "PCB Edit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label19,
				str = new string[3] { "PCB编辑", "PCB编辑", "PCB Edit" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_title_smt,
				str = new string[3] { "SMT贴装生产", "SMT贴装生产", "SMT RUN" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = tabPage_main_smt,
				str = new string[3] { "SMT生产", "SMT生產", "SMT Run" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_info_clear,
				str = new string[3] { "计数清零", "計數清零", "Clean" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_throwrate_check,
				str = new string[3] { "详细信息", "詳細信息", "Details" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label10,
				str = new string[3] { "贴装日志", "貼裝日誌", "Log File" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_Infologfile_browse,
				str = new string[3] { "浏览", "瀏覽", "Browser" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label112,
				str = new string[3] { "生产日期", "生產日期", "Smt Date" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label114,
				str = new string[3] { "单板时间", "單板時間", "Cycle Time" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label91,
				str = new string[3] { "贴板总数", "貼板總數", "Total PCB" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = checkBox_onlyAutoMode,
				str = new string[3] { "是否只统计全自动", "是否只統計全自動", "Only For Auto Mode" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label104,
				str = new string[3] { "总数", "總數", "Total" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label8,
				str = new string[3] { "贴片总数", "貼片總數", "Smt Chips" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "抛料", "拋料", "Drops" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "抛料率", "拋料率", "Drops Rate" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label11,
				str = new string[3] { "异常", "異常", "Exception" }
			});
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label9,
				str = new string[3] { "空取", "空取", "Empty Pick" }
			});
			return list;
		}

		public void flush_proj_mode()
		{
			if (USR3B.mPrjMode != 0)
			{
				panel_subpcb.Visible = true;
			}
			else
			{
				panel_subpcb.Visible = false;
			}
		}

		public void set_tab_index(int idx)
		{
			tabControl_mainwork.SelectedIndex = idx;
		}

		private void UserControl_job_Load(object sender, EventArgs e)
		{
		}

		private void tabControl_mainwork_DrawItem_1(object sender, DrawItemEventArgs e)
		{
			SolidBrush solidBrush = new SolidBrush(Color.Salmon);
			SolidBrush solidBrush2 = new SolidBrush(Color.LightGray);
			SolidBrush solidBrush3 = new SolidBrush(Color.Black);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			for (int i = 0; i < tabControl_mainwork.TabPages.Count; i++)
			{
				Rectangle tabRect = tabControl_mainwork.GetTabRect(i);
				if (i == tabControl_mainwork.SelectedIndex)
				{
					e.Graphics.FillRectangle(solidBrush, tabRect);
				}
				else
				{
					e.Graphics.FillRectangle(solidBrush2, tabRect);
				}
				tabRect.Y += 2;
				e.Graphics.DrawString(tabControl_mainwork.TabPages[i].Text, new Font(DEF.FONT_2020_TITLE[MainForm0.USR_INIT.mLanguage], 13f, (MainForm0.USR_INIT.mLanguage != 2) ? FontStyle.Bold : FontStyle.Regular), solidBrush3, tabRect, stringFormat);
			}
			solidBrush.Dispose();
			solidBrush2.Dispose();
			solidBrush3.Dispose();
			stringFormat.Dispose();
		}

		public void set_inboradmode(int inboardmode)
		{
			switch (inboardmode)
			{
			case 1:
				button_add_subpcb.Enabled = false;
				button_del_subpcb.Enabled = false;
				label_smtloopmode.Text = (new string[3] { "分两段贴板模式", "分兩段貼板模式", "PCB 2-Section Mode" })[MainForm0.USR_INIT.mLanguage];
				if (HW.mSections == 3)
				{
					label_smtloopmode.Text = (new string[3] { "分三段贴板模式", "分三段貼板模式", "PCB 3-Section Mode" })[MainForm0.USR_INIT.mLanguage];
				}
				break;
			case 2:
				button_add_subpcb.Enabled = false;
				button_del_subpcb.Enabled = false;
				label_smtloopmode.Text = (new string[3] { "双轨AB板贴装模式", "双轨AB板贴装模式", "PCB 2-Rails Mode" })[MainForm0.USR_INIT.mLanguage];
				break;
			default:
				label_smtloopmode.Text = (new string[3] { "标准贴板模式", "標準貼板模式", "PCB Standard Mode" })[MainForm0.USR_INIT.mLanguage];
				break;
			}
			if (HW.mFnNum == 2)
			{
				string[][] array = new string[2][]
				{
					new string[3] { "【左机】", "【左机】", "[Left] " },
					new string[3] { "【右机】", "【右机】", "[Right] " }
				};
				label_smtloopmode.Text = array[mFn][USR_INIT.mLanguage] + label_smtloopmode.Text;
			}
		}

		private void button_goto_PCBEdit_Click(object sender, EventArgs e)
		{
			if (uc_feederinstall != null && !uc_feederinstall.IsDisposed)
			{
				uc_feederinstall.Dispose();
				uc_feederinstall = null;
			}
			if (mUSR3List.Count > 0 && mUSR3Idx < mUSR3List.Count)
			{
				uc_dgv_list[mUSR3Idx].display_uc_pcbedit_import(flag: false);
				uc_dgv_list[mUSR3Idx].close_uc_pcbedit_array();
				uc_dgv_list[mUSR3Idx].close_uc_pcbedit_mark();
			}
		}

		private void button_Cat_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (MainForm0.mIsSecurityTest)
			{
				num = MainForm0.__wind_checkget_software_state(1);
				if (num == 2 || num == 3 || num == 4)
				{
					return;
				}
			}
			if (mUSR3List != null)
			{
				USR3_DATA uSR3_DATA = mUSR3List[mUSR3Idx];
				bool flag = true;
				if (uSR3_DATA.mMarkPic[0] == null || uSR3_DATA.mMarkPic[1] == null)
				{
					flag = false;
				}
				if (uSR3_DATA.mMark[0].X == 0 && uSR3_DATA.mMark[0].Y == 0)
				{
					flag = false;
				}
				if (uSR3_DATA.mMark[1].X == 0 && uSR3_DATA.mMark[1].Y == 0)
				{
					flag = false;
				}
				if (!flag)
				{
					string[] array = new string[3] { "请先设置MARK点!", "请先设置MARK点!", "Please Set MARK firstly!" };
					MainForm0.CmMessageBoxTop_Ok(array[USR_INIT.mLanguage]);
					return;
				}
			}
			if (HW.mFnNum > 1)
			{
				Form_BoxSel form_BoxSel = new Form_BoxSel("", "数据整理", "分类优化", "");
				switch (form_BoxSel.ShowDialog())
				{
				case DialogResult.OK:
					data_catcat();
					return;
				default:
					return;
				case DialogResult.Yes:
					break;
				}
			}
			if (MainForm0.pcblist_to_cat(mFn))
			{
				MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Same chip type has different parameters, the table will set default value" : "相同元件的某些参数不一致，分类表格会将其呈现默认值！");
			}
			if (USR3B.mPointlistCat_History == null)
			{
				USR3B.mPointlistCat_History = new BindingList<ChipCategoryElement>();
			}
			Form_PcbEdit_Cat form_PcbEdit_Cat = new Form_PcbEdit_Cat(mFn, USR, USR2, mUSR3List, USR3B.mPointlistCat, USR3B.mPointlistCat_History, USR3B.isSlotBrkn, USR3B.mNozzleEnable);
			DialogResult dialogResult = form_PcbEdit_Cat.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				if (MainForm0.mIsSecurityTest && num == 0 && USR3B.mPointlistCat.Count > 5)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Trail version, Max optimization chip kinds number: " : ("试用版本限制，最多优化芯片种类数量：" + 5));
				}
				else if (USR3B.mPointlistCat.Count > 0)
				{
					MainForm0.catlist_to_pointlist(mFn);
					if (MainForm0.moon_kk_Init(mFn))
					{
						MainForm0.common_waiting_start((USR_INIT.mLanguage == 2) ? "Optimize..." : "正在优化, 请稍后", 15);
						MainForm0.moon_kk_Optimization(mFn);
						MainForm0.save_usrProjectData();
						for (int i = 0; i < uc_dgv_list.Count; i++)
						{
							uc_dgv_list[i].PCBE_List_Show(1, is_reflush: true);
						}
						MainForm0.common_waiting_break();
						if (USR3B.mPointlistCat_History != null && USR3B.mPointlistCat != null && USR3B.mPointlistCat_History.Count == USR3B.mPointlistCat.Count)
						{
							Form_FeederShow form_FeederShow = new Form_FeederShow(USR3B.slot_feeder_component, USR3B.isSlotBrkn, USR3B.isSlotOcpy);
							form_FeederShow.TopMost = true;
							Form_OptimizeResult form_OptimizeResult = new Form_OptimizeResult(USR_INIT.mLanguage, USR3B.mPointlistCat_History, USR3B.mPointlistCat);
							form_OptimizeResult.TopMost = true;
							form_FeederShow.Show();
							form_OptimizeResult.Show();
						}
						MainForm0.feederinstall_reflush(mFn);
						return;
					}
				}
				for (int j = 0; j < uc_dgv_list.Count; j++)
				{
					uc_dgv_list[j].PCBE_List_Show(mUSR3List[j].mPointListOrder, is_reflush: true);
				}
			}
			else
			{
				MainForm0.catlist_to_pointlist(mFn);
				for (int k = 0; k < uc_dgv_list.Count; k++)
				{
					uc_dgv_list[k].PCBE_List_Show(mUSR3List[k].mPointListOrder, is_reflush: true);
				}
				MainForm0.feederinstall_reflush(mFn);
			}
		}

		private void button_PCBE_feeder_Click(object sender, EventArgs e)
		{
			MainForm0.write_to_logFile_hand("HAND: button_PCBE_feeder_Click" + Environment.NewLine);
			if (uc_feederinstall == null || uc_feederinstall.IsDisposed)
			{
				uc_feederinstall = new UserControl_feederinstall(mFn, USR, USR3B);
				panel_PcbEditPage.Controls.Add(uc_feederinstall);
				uc_feederinstall.Location = new Point(label19.Location.X, label19.Location.Y + 4);
				uc_feederinstall.BringToFront();
				uc_feederinstall.Show();
			}
		}

		private void button_openFeederPage_vsplus_Click(object sender, EventArgs e)
		{
			MainForm0.write_to_logFile_hand("HAND: button_openFeederPage_vsplus_Click" + Environment.NewLine);
			if (MainForm0.is_engineer_password_correct())
			{
				if (uc_stack == null || uc_stack.IsDisposed)
				{
					uc_stack = new UserControl_Stack(mFn, USR, USR2, USR3B);
					uc_stack.BackColor = Color.DimGray;
					base.Controls.Add(uc_stack);
					uc_stack.Location = new Point(0, 0);
					uc_stack.BringToFront();
				}
				else
				{
					uc_stack.stacksel_new_flushdata();
					uc_stack.BringToFront();
					uc_stack.Visible = true;
					uc_stack.Show();
				}
			}
		}

		private void button_openFeederPage_Click(object sender, EventArgs e)
		{
			button_openFeederPage_vsplus_Click(sender, e);
		}

		private void button_Legal_Click(object sender, EventArgs e)
		{
			MainForm0.write_to_logFile_hand("HAND: button_Legal_Click" + Environment.NewLine);
			MainForm0.pcbsmt_legalcheck(MainForm0.mFn, must_show: true);
		}

		private void button_add_subpcb_Click(object sender, EventArgs e)
		{
			__button_add_subpcb_Click(sender, e);
		}

		private void button_del_subpcb_Click(object sender, EventArgs e)
		{
			__button_del_subpcb_Click(sender, e);
		}

		private void button_subpcb_setting_Click(object sender, EventArgs e)
		{
			__button_subpcb_setting_Click(sender, e);
		}

		private void button_subpcb_select_Click(object sender, EventArgs e)
		{
			__button_subpcb_select_Click(sender, e);
		}

		private void button_vsplus_setsmt_Click(object sender, EventArgs e)
		{
			vsplus_setsmt();
		}

		public void vsplus_setsmt()
		{
			tabControl_mainwork.SelectedIndex = 1;
			if (uc_smtsetting == null || uc_smtsetting.IsDisposed)
			{
				uc_smtsetting = new UserControl_SmtSetting(mFn, USR, USR2, USR3B);
				uc_smtsetting.button_subpcb_sel += button_subpcb_sel;
				panel_SmtProducePage.Controls.Add(uc_smtsetting);
				uc_smtsetting.Location = new Point(0, panel5.Location.Y);
				if (HW.mFnNum == 2)
				{
					uc_smtsetting.Location = new Point(0, 65);
				}
				uc_smtsetting.BringToFront();
			}
		}

		private void button_smt_showfackpcb_Click(object sender, EventArgs e)
		{
			panel_smtshoware.Visible = true;
			panel_smtshoware.BringToFront();
		}

		private void button_vsplus_smtinfo_Click(object sender, EventArgs e)
		{
			panel_smtinfo.Visible = true;
			panel_smtinfo.BringToFront();
		}

		private void button_SmtVisualShow_Click(object sender, EventArgs e)
		{
			if (!MainForm0.uc_VisualShowSmt[mFn].Visible)
			{
				MainForm0.uc_VisualShowSmt[mFn].BringToFront();
				MainForm0.uc_VisualShowSmt[mFn].Visible = true;
			}
			else
			{
				MainForm0.uc_VisualShowSmt[mFn].Visible = false;
			}
		}

		private void button_info_clear_Click(object sender, EventArgs e)
		{
			__button_info_clear_Click(sender, e);
		}

		private void button_throwrate_check_Click(object sender, EventArgs e)
		{
			__button_throwrate_check_Click(sender, e);
		}

		private void button_Infologfile_browse_Click(object sender, EventArgs e)
		{
			__button_Infologfile_browse_Click(sender, e);
		}

		private void checkBox_onlyAutoMode_CheckedChanged(object sender, EventArgs e)
		{
			__checkBox_onlyAutoMode_CheckedChanged(sender, e);
		}

		private void trackBar_smtXYSpeed_Scroll(object sender, EventArgs e)
		{
			USR3B.mSmtXYSpeed = trackBar_smtXYSpeed.Value;
			label_smtXYSpeed.Text = USR3B.mSmtXYSpeed.ToString();
			if (LOW_SPEED)
			{
				XY_SPEED = USR3B.mSmtXYSpeed / 2;
			}
		}

		private void trackBar_smtASpeed_Scroll(object sender, EventArgs e)
		{
			USR3B.mSmtASpeed = trackBar_smtASpeed.Value;
			label_smtASpeed.Text = USR3B.mSmtASpeed.ToString();
			if (LOW_SPEED)
			{
				A_SPEED = USR3B.mSmtASpeed / 2;
			}
		}

		private void checkBox_flashlight_CheckedChanged(object sender, EventArgs e)
		{
			if (USR3B != null)
			{
				USR3B.mIsFlashlightMode = checkBox_flashlight.Checked;
			}
		}

		private void checkBox_smtxyaspeed_edit_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_smtxyaspeed_edit.Checked)
			{
				if (!MainForm0.is_engineer_password_correct())
				{
					checkBox_smtxyaspeed_edit.Checked = false;
					return;
				}
				trackBar_smtXYSpeed.Enabled = true;
				trackBar_smtASpeed.Enabled = true;
			}
			else
			{
				trackBar_smtXYSpeed.Enabled = false;
				trackBar_smtASpeed.Enabled = false;
			}
		}

		public void set_finishautorun(bool v)
		{
			checkBox_FinishAutoSmt.Checked = v;
			if (HW.mFnNum == 2 && MainForm0.uc_smtRunning != null)
			{
				MainForm0.uc_smtRunning.set_finishauto(mFn, v);
			}
		}

		private void checkBox_FinishAutoSmt_CheckedChanged(object sender, EventArgs e)
		{
			bIsFinishAutoRun = checkBox_FinishAutoSmt.Checked;
		}

		private void button_vsplus_stopsmt_Click(object sender, EventArgs e)
		{
			__button_vsplus_stopsmt_Click(sender, e);
		}

		private void button_PauseSmt_Click(object sender, EventArgs e)
		{
			__button_PauseSmt_Click(sender, e);
		}

		private void button_vsplus_startsmt_Click(object sender, EventArgs e)
		{
			__button_vsplus_startsmt_Click(sender, e);
		}

		private void button_Loukong_clearS3_Click(object sender, EventArgs e)
		{
			__button_Loukong_clearS3_Click(sender, e);
		}

		private void checkBox_simulator_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_simulator.Checked)
			{
				if (HW.mDeviceType == DeviceType.HW_8S_TRAN4 || HW.mDeviceType == DeviceType.HW_6S_TRAN4)
				{
					MainForm0.mDebugFormTRAN4 = new Form_DebugTRAN4();
					MainForm0.mDebugFormTRAN4.Show();
				}
				else if (MainForm0.mDebugForm == null || MainForm0.mDebugForm.IsDisposed)
				{
					MainForm0.mDebugForm = new Form_Debug(mFn, HW.mIsSanduanshi, USR_INIT.mIsBCTEnabled);
					MainForm0.mDebugForm.Show();
				}
			}
		}

		private void checkBox_simulate_visualpass_CheckedChanged(object sender, EventArgs e)
		{
			is_ignore_visualfail = checkBox_simulate_visualpass.Checked;
		}

		private void button_bigtab_Click(object sender, EventArgs e)
		{
			vsplusForm_BigTab vsplusForm_BigTab = new vsplusForm_BigTab(mUSR3List, mUSR3Idx);
			vsplusForm_BigTab.ShowDialog();
		}

		public void set_simulation()
		{
			checkBox_simulator.Visible = true;
			button_bigtab.Visible = true;
			checkBox_simulate_visualpass.Visible = true;
		}

		private void button_vsplus_continuesmt_Click(object sender, EventArgs e)
		{
			__button_vsplus_continuesmt_Click(sender, e);
		}

		private void button_smtTest_Click(object sender, EventArgs e)
		{
			__button_smtTest_Click(sender, e);
		}

		private void cnButton_vsplus_startsmt_Click(object sender, EventArgs e)
		{
			if (MainForm0.uc_smtRunning == null || MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning = new UserControl_SmtRunning();
				MainForm0.static_this.Controls.Add(MainForm0.uc_smtRunning);
				MainForm0.uc_smtRunning.Location = new Point(0, 50);
				MainForm0.uc_smtRunning.Show();
				MainForm0.uc_smtRunning.BringToFront();
			}
			else
			{
				MainForm0.uc_smtRunning.Visible = true;
			}
		}

		private int s_auto_smt_3duanshi()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			while (true)
			{
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return -1;
				}
				QnCommon.mPlayWoodState_Sensor = -1;
				QnCommon.mPlayWoodState_Motor = -1;
				MainForm0.mConDevExt[0].readPlayWoodState();
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					MainForm0.mDebugForm.readPlayWoodState();
				}
				int num = 100;
				while (true)
				{
					DateTime now = DateTime.Now;
					double num2 = 0.0;
					do
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						if (QnCommon.mPlayWoodState_Sensor != -1 && QnCommon.mPlayWoodState_Motor != -1)
						{
							break;
						}
						Thread.Sleep(0);
						num2 = (DateTime.Now - now).TotalMilliseconds;
					}
					while (num2 < (double)num);
					if (num2 < (double)num)
					{
						break;
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].readPlayWoodState();
					Thread.Sleep(10);
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						QnCommon.mPlayWoodState_Sensor = MainForm0.mDebugForm.get_S();
						QnCommon.mPlayWoodState_Motor = MainForm0.mDebugForm.get_M();
					}
				}
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					QnCommon.mInBoardState[mFn] = MainForm0.mDebugForm.get_InB();
					QnCommon.mOutBoardState[mFn] = MainForm0.mDebugForm.get_OutB();
				}
				if (((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0 && (QnCommon.mPlayWoodState_Motor & 6) == 0 && !flag2 && !flag3)
				{
					flag2 = true;
					QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					BeginInvoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD..." : "出板中...");
					});
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Unknown);
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.static_this.misc_board_out(mFn, USR3B.mTrackSpeed, (int)(USR3B.mTrackDelay * 10f), USR_INIT.mIsBCTEnabled);
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.sendOutBoard();
					}
				}
				if ((QnCommon.mPlayWoodState_Sensor & 4) == 0 && ((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0 && (QnCommon.mPlayWoodState_Motor & 3) == 0 && !flag)
				{
					flag = true;
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					BeginInvoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD..." : "进板中...");
					});
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Unknown);
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].sendInBoard(mFn, USR3.mTrackSpeed, 0);
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.sendInBoard();
					}
					flag3 = true;
					if (youxian_pik != 0)
					{
						mloop_idx = 0;
						msmtchip_idx_raw = 0;
						msmtchip_idx = 0;
						mis_maybe_continue = 0;
						Thread thread = new Thread(thd_SmtLoop_YouxianPik);
						thread.IsBackground = true;
						thread.Start(mloop);
					}
				}
				if (QnCommon.mOutBoardState[mFn] != 0)
				{
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Ok)
					{
						QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Unknown);
						}
						BeginInvoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD SUCCESSFUL" : "出板成功，等待下一板组..");
							if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
							{
								MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
							}
						});
						flag2 = false;
					}
					else if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						BeginInvoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD FAIL, PLEASE CHECK" : "出板失败，请处理");
							if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
							{
								MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
							}
						});
						return -3;
					}
				}
				if (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Ok)
				{
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Unknown);
					}
					BeginInvoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，开始贴装..");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					mloop_idx = 0;
					msmtchip_idx_raw = 0;
					msmtchip_idx = 0;
					mis_maybe_continue = 0;
					if (mthd_smtRun != null && mthd_smtRun.IsAlive)
					{
						mthd_smtRun.Abort();
						Thread.Sleep(100);
					}
					mthd_smtRun = new Thread(thd_SmtLoop);
					mthd_smtRun.IsBackground = true;
					mthd_smtRun.Start(mloop);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，正在贴装..");
					});
					Thread.Sleep(300);
					while (vsplus_smtbusy() || MainForm0.mRunDoing[mFn] != 0)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -2;
						}
						Thread.Sleep(100);
					}
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "贴装完成，等待出板..");
					});
					if (bIsFinishAutoRun)
					{
						return -1;
					}
					flag = false;
					flag3 = false;
				}
				if (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Fail)
				{
					break;
				}
				Thread.Sleep(100);
			}
			Invoke((MethodInvoker)delegate
			{
				label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD FAIL, PLEASE CHECK" : "进板失败，请处理");
			});
			return -3;
		}

		public void subpcb_flush_sectionhead(string cmd)
		{
			switch (cmd)
			{
			case "init":
			{
				panel_subpcblist.Controls.Clear();
				if (button_subpcb == null)
				{
					button_subpcb = new BindingList<CnButton>();
				}
				button_subpcb.Clear();
				for (int j = 0; j < mUSR3List.Count; j++)
				{
					CnButton cnButton = new CnButton();
					panel_subpcblist.Controls.Add(cnButton);
					button_subpcb.Add(cnButton);
					cnButton.Size = new Size(50, 26);
					cnButton.Location = new Point(1 + 51 * j, 1);
					cnButton.Font = new Font("楷体", 10.5f, FontStyle.Regular);
					cnButton.Visible = true;
					cnButton.CnButtonMode = ButtonModeEn.PressRadio;
					cnButton.ForeColor = Color.White;
					cnButton.BackColor = Color.DimGray;
					cnButton.CnPressDownColor = Color.Red;
					cnButton.Tag = j;
					cnButton.MouseDown += button_subpcb_Click;
					if (mUSR3List[j].mPcbID == null || mUSR3List[j].mPcbID == "")
					{
						mUSR3List[j].mPcbID = "PCB" + (j + 1);
					}
					cnButton.Text = mUSR3List[j].mPcbID;
				}
				break;
			}
			case "add":
			{
				if (mUSR3Idx_Prev != -1)
				{
					button_subpcb[mUSR3Idx_Prev].CnSetPressDown(flag: false);
				}
				CnButton cnButton2 = new CnButton();
				panel_subpcblist.Controls.Add(cnButton2);
				button_subpcb.Add(cnButton2);
				cnButton2.Size = new Size(50, 26);
				cnButton2.Location = new Point(1 + 51 * mUSR3Idx, 1);
				cnButton2.Font = new Font("楷体", 10.5f, FontStyle.Regular);
				cnButton2.Visible = true;
				cnButton2.CnButtonMode = ButtonModeEn.PressRadio;
				cnButton2.ForeColor = Color.White;
				cnButton2.BackColor = Color.DimGray;
				cnButton2.CnPressDownColor = Color.Red;
				cnButton2.MouseDown += button_subpcb_Click;
				if (mUSR3List[mUSR3Idx].mPcbID == null || mUSR3List[mUSR3Idx].mPcbID == "")
				{
					mUSR3List[mUSR3Idx].mPcbID = "PCB" + (mUSR3Idx + 1);
				}
				cnButton2.Text = mUSR3List[mUSR3Idx].mPcbID;
				cnButton2.Tag = mUSR3Idx;
				break;
			}
			case "del":
			{
				panel_subpcblist.Controls.Remove(button_subpcb[mUSR3Idx_Prev]);
				button_subpcb.RemoveAt(mUSR3Idx_Prev);
				mUSR3Idx_Prev = 0;
				for (int i = mUSR3Idx; i < button_subpcb.Count; i++)
				{
					button_subpcb[i].Location = new Point(1 + 51 * i, 1);
					button_subpcb[i].Tag = i;
				}
				break;
			}
			}
			flush_subpcb_button();
		}

		private void flush_subpcb_button()
		{
			if (button_subpcb != null && mUSR3Idx >= 0 && mUSR3Idx < button_subpcb.Count)
			{
				for (int i = 0; i < button_subpcb.Count; i++)
				{
					button_subpcb[i].CnSetPressDown(mUSR3Idx == i);
				}
			}
		}

		private void button_subpcb_Click(object sender, MouseEventArgs e)
		{
			CnButton cnButton = (CnButton)sender;
			int num = (int)cnButton.Tag;
			if (num != mUSR3Idx && !MainForm0.mMutexBt)
			{
				MainForm0.mMutexBt = true;
				mUSR3Idx_Prev = mUSR3Idx;
				mUSR3Idx = num;
				flush_subpcb_button();
				Invoke((MethodInvoker)delegate
				{
					MainForm0.uc_usroperarion[MainForm0.mFn].set_inboard_section(mUSR3Idx);
				});
				Thread thread = new Thread(thd_subpcb_flush_allpages);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		private void thd_subpcb_flush_allpages()
		{
			Invoke((MethodInvoker)delegate
			{
				subpcb_flush_all();
				MainForm0.mMutexBt = false;
			});
		}

		public void subpcb_flush_all()
		{
			USR3 = mUSR3List[mUSR3Idx];
			subpcb_flush_pcbtable();
			subpcb_flush_fakepcb();
			if (MainForm0.mIsOpen_PcbArrayPage)
			{
				uc_dgv_list[mUSR3Idx].open_uc_pcbedit_array();
			}
			else
			{
				uc_dgv_list[mUSR3Idx].close_uc_pcbedit_array();
			}
			if (MainForm0.mIsOpen_PcbMarkPage)
			{
				uc_dgv_list[mUSR3Idx].open_uc_pcbedit_mark();
			}
			else
			{
				uc_dgv_list[mUSR3Idx].close_uc_pcbedit_mark();
			}
			if (MainForm0.mIsOpen_PcbImportPage)
			{
				uc_dgv_list[mUSR3Idx].display_uc_pcbedit_import(flag: true);
			}
			else
			{
				uc_dgv_list[mUSR3Idx].display_uc_pcbedit_import(flag: false);
			}
			uc_dgv_list[mUSR3Idx].BringToFront();
			if (mUSR3Idx_Prev != mUSR3Idx)
			{
				mPanel_fakepcb_list[mUSR3Idx_Prev].Visible = false;
			}
			mPanel_fakepcb_list[mUSR3Idx].Visible = true;
			mPanel_fakepcb_list[mUSR3Idx].BringToFront();
		}

		public void subpcb_flush_pcbtable()
		{
			label_subpcb_title.Text = USR3.mPcbID + " " + USR3.mPcbDescription;
		}

		public void subpcb_flush_fakepcb()
		{
			if (mUSR3List[mUSR3Idx] == null || mUSR3List[mUSR3Idx].mPointlistSmt == null)
			{
				return;
			}
			if (mUSR3List[mUSR3Idx].draw_chipinfo_list == null)
			{
				mUSR3List[mUSR3Idx].draw_chipinfo_list = new BindingList<DrawFakeChip>();
				for (int i = 0; i < mUSR3List[mUSR3Idx].mPointlistSmt.Count; i++)
				{
					DrawFakeChip item = new DrawFakeChip();
					mUSR3List[mUSR3Idx].draw_chipinfo_list.Add(item);
				}
			}
			mPanel_fakepcb_list[mUSR3Idx].Controls.Clear();
			Graphics graphics = mPanel_fakepcb_list[mUSR3Idx].CreateGraphics();
			graphics.Clear(mPanel_fakepcb_list[mUSR3Idx].BackColor);
			graphics.Dispose();
			mPanel_fakepcb_list[mUSR3Idx].Update();
			draw_fakepcb(mPanel_fakepcb_list[mUSR3Idx], panel_fakepcb_smt.Size, USR3.mPointlistSmt);
			mPanel_fakepcb_list[mUSR3Idx].Update();
			Update();
		}

		private void __button_add_subpcb_Click(object sender, EventArgs e)
		{
			if (USR3B.mPrjSmtMode != 1 || mUSR3List.Count < 2)
			{
				Form_SubPcbAdd form_SubPcbAdd = new Form_SubPcbAdd(mUSR3List);
				if (form_SubPcbAdd.ShowDialog() == DialogResult.OK)
				{
					USR3_DATA uSR3_DATA = new USR3_DATA();
					uSR3_DATA.mPcbID = form_SubPcbAdd.get_pcbid();
					uSR3_DATA.mPcbDescription = form_SubPcbAdd.get_pcbdecription();
					mUSR3List.Add(uSR3_DATA);
					mUSR3Idx_Prev = mUSR3Idx;
					mUSR3Idx = mUSR3List.Count - 1;
					UserControl_pcbedit_datagridview userControl_pcbedit_datagridview = new UserControl_pcbedit_datagridview(mFn, USR, USR2, mUSR3List[mUSR3Idx], USR3B, is_pcbcheck: false);
					panel_PcbEditPage.Controls.Add(userControl_pcbedit_datagridview);
					userControl_pcbedit_datagridview.Location = panel_PCBE.Location;
					userControl_pcbedit_datagridview.BringToFront();
					uc_dgv_list.Add(userControl_pcbedit_datagridview);
					Panel panel = new Panel();
					panel_smtshoware.Controls.Add(panel);
					panel.Location = panel_fakepcb_smt.Location;
					panel.Size = panel_fakepcb_smt.Size;
					panel.Tag = mUSR3List[mUSR3Idx].mPcbID;
					panel.Paint += panel_vsplus_fakepcb_Paint;
					panel.BringToFront();
					panel.Visible = false;
					mPanel_fakepcb_list.Add(panel);
					subpcb_flush_sectionhead("add");
					Thread thread = new Thread(thd_subpcb_flush_allpages);
					thread.IsBackground = true;
					thread.Start();
					MainForm0.common_waiting_start((USR_INIT.mLanguage == 2) ? "Loading..." : "正在加载数据...", 10);
				}
			}
		}

		private void __button_del_subpcb_Click(object sender, EventArgs e)
		{
			if (mUSR3List.Count > 1 && mUSR3Idx >= 0 && mUSR3Idx < mUSR3List.Count && MainForm0.CmMessageBox("是否要删除当前PCB子工程?" + Environment.NewLine + mUSR3List[mUSR3Idx].mPcbID + " " + mUSR3List[mUSR3Idx].mPcbDescription, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				mPanel_fakepcb_list[mUSR3Idx].Dispose();
				mPanel_fakepcb_list.RemoveAt(mUSR3Idx);
				uc_dgv_list[mUSR3Idx].Dispose();
				uc_dgv_list.RemoveAt(mUSR3Idx);
				mUSR3List.RemoveAt(mUSR3Idx);
				mUSR3Idx_Prev = mUSR3Idx;
				if (mUSR3Idx >= mUSR3List.Count)
				{
					mUSR3Idx = mUSR3List.Count - 1;
				}
				subpcb_flush_sectionhead("del");
				flush_subpcb_button();
				Thread thread = new Thread(thd_subpcb_flush_allpages);
				thread.IsBackground = true;
				thread.Start();
				MainForm0.common_waiting_start((USR_INIT.mLanguage == 2) ? "Loading..." : "正在加载数据...", 10);
			}
		}

		private void __button_subpcb_setting_Click(object sender, EventArgs e)
		{
			if (mUSR3List == null || mUSR3List.Count == 0)
			{
				return;
			}
			Form_SubPcbSetting form_SubPcbSetting = new Form_SubPcbSetting(mUSR3List);
			if (form_SubPcbSetting.ShowDialog() == DialogResult.OK)
			{
				label_subpcb_title.Text = mUSR3List[mUSR3Idx].mPcbID + " " + mUSR3List[mUSR3Idx].mPcbDescription;
				for (int i = 0; i < button_subpcb.Count; i++)
				{
					button_subpcb[i].Text = mUSR3List[i].mPcbID;
				}
			}
		}

		private void __button_subpcb_select_Click(object sender, EventArgs e)
		{
			Form_subpcb form_subpcb = new Form_subpcb(mFn);
			if (form_subpcb.ShowDialog() == DialogResult.OK)
			{
				mUSR3Idx_Prev = mUSR3Idx;
				mUSR3Idx = form_subpcb.get_selectedindex();
				flush_subpcb_button();
				Invoke((MethodInvoker)delegate
				{
					MainForm0.uc_usroperarion[MainForm0.mFn].set_inboard_section(mUSR3Idx);
				});
				Thread thread = new Thread(thd_subpcb_flush_allpages);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		public void button_subpcb_sel(int idx)
		{
			if (idx != mUSR3Idx && !MainForm0.mMutexBt)
			{
				MainForm0.mMutexBt = true;
				mUSR3Idx_Prev = mUSR3Idx;
				mUSR3Idx = idx;
				flush_subpcb_button();
				Invoke((MethodInvoker)delegate
				{
					MainForm0.uc_usroperarion[mFn].set_inboard_section(mUSR3Idx);
				});
				Thread thread = new Thread(thd_subpcb_flush_allpages);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		public void vsplus_fastcam_stillall_andvisual(BIGTAB_GROUP biggroup)
		{
			MainForm0.msdelay(USR2.mFastCamStillDelay[0]);
			mJvsStill_SmtMask = 0;
			for (int i = 0; i < biggroup.mnt_arr.Count; i++)
			{
				BIGTAB_2_ITEM bIGTAB_2_ITEM = biggroup.mnt_arr[i];
				int zn = bIGTAB_2_ITEM.zn;
				int num = HW.mFastCamItem[mFn].index[zn];
				mSmtVisualDone[zn] = SMT_VISUAL_STATE.NOT_COMPLETE;
				MainForm0.WaitComplete_A(mFn, zn);
				if (!MainForm0.startFastStill_noWait(CameraType.Fast, mFn, zn))
				{
					MainForm0.write_to_logFile("JVS_GetBitmap fail: zn:" + num);
				}
				mJvsStill_SmtMask |= 1 << i;
			}
			while (mJvsStill_SmtMask != 0)
			{
				int num2 = mJvsStill_SmtMask;
				int num3 = 0;
				while (num2 != 0)
				{
					if ((num2 & 1) == 1)
					{
						int zn2 = biggroup.mnt_arr[num3].zn;
						int num4 = HW.mFastCamItem[mFn].index[zn2];
						if (MainForm0.bJVSCameraRecived[num4])
						{
							if (MainForm0.checkJVSStill_IsAA55(num4))
							{
								if (!MainForm0.startFastStill_noWait(CameraType.Fast, mFn, zn2))
								{
									MainForm0.write_to_logFile("JVS_GetBitmap fail: channel:" + num4);
								}
							}
							else
							{
								MainForm0.jvsstill_UnlockBitmap(num4);
								mJvsStill_SmtMask &= ~(1 << num3);
								if (MainForm0.mIsSimulation && File.Exists("C:\\E\\hwgcpic\\fastcam.bmp"))
								{
									MainForm0.mJVSBitmap[num4] = new Bitmap("C:\\E\\hwgcpic\\fastcam.bmp");
								}
								biggroup.mnt_arr[num3].is_first_ingroup = ((num3 == 0) ? true : false);
								Thread thread = new Thread(thd_jvsvisual);
								thread.IsBackground = true;
								thread.Priority = ((num3 == 0) ? ThreadPriority.Highest : ThreadPriority.AboveNormal);
								thread.Start(biggroup.mnt_arr[num3]);
							}
						}
					}
					num2 >>= 1;
					num3++;
				}
			}
		}

		public void thd_jvsvisual(object o)
		{
			BIGTAB_2_ITEM bIGTAB_2_ITEM = (BIGTAB_2_ITEM)o;
			int zn = bIGTAB_2_ITEM.zn;
			mSmtVisualDone[bIGTAB_2_ITEM.zn] = SMT_VISUAL_STATE.NOT_COMPLETE;
			if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
			{
				return;
			}
			if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
			{
				mSmtVisualDone[zn] = (MainForm0.mDebugForm.get_visual(bIGTAB_2_ITEM.zn) ? SMT_VISUAL_STATE.SUCCESS : SMT_VISUAL_STATE.FAIL);
				return;
			}
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			VISUAL_MODE vISUAL_MODE = ((bIGTAB_2_ITEM.cameratype == CameraType.High) ? VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE : VISUAL_MODE.NOSTILL);
			if (bIGTAB_2_ITEM.cameratype == CameraType.High)
			{
				vISUAL_MODE = VISUAL_MODE.COMMON;
			}
			if (bIGTAB_2_ITEM.looptype == LoopType.HalfLoop)
			{
				vISUAL_MODE |= VISUAL_MODE.LOOP_HALF_COMMON;
			}
			if (!bIGTAB_2_ITEM.is_first_ingroup)
			{
				Thread.Sleep(30);
			}
			visual_result.set_w_h(bIGTAB_2_ITEM.l_ref_mm, bIGTAB_2_ITEM.w_ref_mm);
			if (bIGTAB_2_ITEM.visualtype == VisualType.FootPrint_R)
			{
				visual_result.set_pinconfig(bIGTAB_2_ITEM.pinconfig2);
			}
			ImageVisual_Result imageVisual_Result = ImageVisual_Result.Err;
			string visinfo = STR.PROVIDER_STR[(int)bIGTAB_2_ITEM.providertype][MainForm0.USR_INIT.mLanguage] + (bIGTAB_2_ITEM.stackno + 1) + Environment.NewLine + bIGTAB_2_ITEM.materialvalue + Environment.NewLine + STR.VISUAL_STR[(int)bIGTAB_2_ITEM.visualtype][MainForm0.USR_INIT.mLanguage];
			visual_result.set_visinfo(visinfo);
			imageVisual_Result = ((!MainForm0.mIsSimulation || !is_ignore_visualfail) ? MainForm0.ImageVisual(mFn, vISUAL_MODE, bIGTAB_2_ITEM.cameratype, bIGTAB_2_ITEM.visualtype, bIGTAB_2_ITEM.scan_r, bIGTAB_2_ITEM.threshold, bIGTAB_2_ITEM.zn, 0, 0, bIGTAB_2_ITEM.mnt_a, ref visual_result) : ImageVisual_Result.OK);
			if (imageVisual_Result == ImageVisual_Result.OK)
			{
				mXref[zn] = visual_result.move_x;
				mYref[zn] = visual_result.move_y;
				mAngleref[zn] = visual_result.move_angle;
				mPnoref[zn] = visual_result.pno;
				if (bIGTAB_2_ITEM.visualtype == VisualType.Draft)
				{
					mXref[zn] = 0;
					mYref[zn] = 0;
					mAngleref[zn] = 0f;
				}
				if (bIGTAB_2_ITEM.is_collect && bIGTAB_2_ITEM.l_ref_pix != 0 && bIGTAB_2_ITEM.w_ref_pix != 0 && bIGTAB_2_ITEM.delta != 0f && !MainForm0.common_is_size_match(visual_result.box_width, visual_result.box_height, bIGTAB_2_ITEM.l_ref_pix, bIGTAB_2_ITEM.w_ref_pix, bIGTAB_2_ITEM.delta))
				{
					if (!MainForm0.mIsSimulation || !is_ignore_visualfail)
					{
						mSmtVisualDone[zn] = SMT_VISUAL_STATE.FAIL;
						if (!MainForm0.mIsSimulation)
						{
							smtinfo_update_drops_plusplus(0, bIGTAB_2_ITEM.providertype, bIGTAB_2_ITEM.stackno, zn);
						}
						return;
					}
					mSmtVisualDone[zn] = SMT_VISUAL_STATE.SUCCESS;
				}
				float input_angle = ((bIGTAB_2_ITEM.looptype == LoopType.HalfLoop) ? mAngleref[zn] : (bIGTAB_2_ITEM.mnt_a + mAngleref[zn]));
				input_angle = MainForm0.format_angle(input_angle, -180f, 180f, 360f);
				MainForm0.moveToA_noWait_Smt(mFn, zn, A_SPEED, MainForm0.mCur[mFn].a[zn] + MainForm0.AngleToSteps(input_angle));
				mSmtVisualDone[zn] = SMT_VISUAL_STATE.SUCCESS;
			}
			else
			{
				mSmtVisualDone[zn] = SMT_VISUAL_STATE.FAIL;
				if (!MainForm0.mIsSimulation)
				{
					smtinfo_update_drops_plusplus((imageVisual_Result == ImageVisual_Result.NoneChip) ? 1 : 0, bIGTAB_2_ITEM.providertype, bIGTAB_2_ITEM.stackno, zn);
				}
			}
		}

		public PikFail vsplus_pricisevisual(BIGTAB_2_ITEM item)
		{
			PikFail pikFail = PikFail.Exit;
			int zn = item.zn;
			VISUAL_RESULT visual_result = new VISUAL_RESULT(item.l_ref_mm, item.w_ref_mm);
			VISUAL_MODE mode = ((item.cameratype == CameraType.High) ? VISUAL_MODE.LOOP_HALF_HIGHCAM_SMT_AUTOSIZE : VISUAL_MODE.NOSTILL);
			if (item.cameratype == CameraType.High)
			{
				mode = VISUAL_MODE.LOOP_HALF_COMMON;
			}
			mSmtVisualDone[zn] = SMT_VISUAL_STATE.NOT_COMPLETE;
			if (item.visualtype == VisualType.FootPrint_R)
			{
				visual_result.set_pinconfig(item.pinconfig2);
			}
			string visinfo = STR.PROVIDER_STR[(int)item.providertype][MainForm0.USR_INIT.mLanguage] + (item.stackno + 1) + Environment.NewLine + item.materialvalue + Environment.NewLine + STR.VISUAL_STR[(int)item.visualtype][MainForm0.USR_INIT.mLanguage];
			visual_result.set_visinfo(visinfo);
			string msg_err = "识别失败: ";
			msg_err = msg_err + " 元件号" + (item.raw_no + 1);
			msg_err = msg_err + " " + STR.PROVIDER_STR[(int)item.providertype][USR_INIT.mLanguage] + (item.stackno + 1);
			msg_err = msg_err + " " + item.materialvalue;
			msg_err = msg_err + " 吸嘴" + (zn + 1);
			msg_err += Environment.NewLine;
			msg_err = msg_err + "精准闭环: " + STR.VISUAL_STR[(int)item.visualtype][USR_INIT.mLanguage];
			while (true)
			{
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return pikFail;
				}
				string msg = "LABEL_RETRY1: 视觉（" + item.visualtype.ToString() + "）  目标角度（" + item.mnt_a + "）";
				MainForm0.write_to_logFile(msg);
				if (MainForm0.ImageVisual(mFn, mode, item.cameratype, item.visualtype, item.scan_r, item.threshold, item.zn, 0, 0, item.mnt_a, ref visual_result) == ImageVisual_Result.OK)
				{
					if (item.is_collect && item.l_ref_pix != 0 && item.w_ref_pix != 0 && item.delta != 0f && !MainForm0.common_is_size_match(visual_result.box_width, visual_result.box_height, item.l_ref_pix, item.w_ref_pix, item.delta))
					{
						bool is_ignore_visualfail = false;
						if (MainForm0.mIsSimulation)
						{
							Invoke((MethodInvoker)delegate
							{
								is_ignore_visualfail = get_simulate_visualpass();
							});
						}
						if (!is_ignore_visualfail)
						{
							mSmtVisualDone[item.zn] = SMT_VISUAL_STATE.FAIL;
							msg = "LABEL_RETRY1: 特征识别尺寸错误（" + visual_result.box_width + "," + visual_result.box_height + "）";
							MainForm0.write_to_logFile(msg);
							Invoke((MethodInvoker)delegate
							{
								MainForm0.start_buzzer_warning(mFn);
								mForm_PikFail_H = new Form_PikFail_HCamPrecise(mFn, msg_err, USR_INIT.mLanguage, item.providertype);
								mForm_PikFail_H.ShowDialog();
								MainForm0.stop_buzzer_warning(mFn);
							});
							pikFail = mForm_PikFail_H.get_pikfail();
							if (pikFail != PikFail.Continue)
							{
								return pikFail;
							}
							continue;
						}
					}
					mXref[zn] = visual_result.move_x;
					mYref[zn] = visual_result.move_y;
					mAngleref[zn] = visual_result.move_angle;
					mPnoref[zn] = visual_result.pno;
					MainForm0.moveToA_noWait_Smt(mFn, zn, A_SPEED, MainForm0.mCur[mFn].a[zn] + MainForm0.AngleToSteps(mAngleref[zn]));
					MainForm0.moveToXY_noWait_Smt(mFn, XY_SPEED, new Coordinate(MainForm0.mCur[mFn].x + mXref[zn], MainForm0.mCur[mFn].y + mYref[zn]));
					msg = "LABEL_RETRY1: 识别  旋转角度（" + visual_result.move_angle + "）";
					if (MainForm0.mIsSimulation)
					{
						MainForm0.moon_buffer_move_angel(MainForm0.pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 24, new Size(1944, 1944), new Point(972, 972), item.scan_r, mAngleref[zn]);
						MainForm0.moon_buffer_move_xy(MainForm0.pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 24, new Size(1944, 1944), new Point(972, 972), item.scan_r, 0f - visual_result.px, 0f - visual_result.py);
					}
					MainForm0.write_to_logFile(msg);
					MainForm0.WaitComplete_XY(mFn);
					MainForm0.WaitComplete_A(mFn, zn);
					int mHCamPrisice_TryNum = USR2.mHCamPrisice_TryNum;
					break;
				}
				msg = "LABEL_RETRY1: 未识别";
				MainForm0.write_to_logFile(msg);
				mSmtVisualDone[zn] = SMT_VISUAL_STATE.FAIL;
				Invoke((MethodInvoker)delegate
				{
					MainForm0.start_buzzer_warning(mFn);
					mForm_PikFail_H = new Form_PikFail_HCamPrecise(mFn, msg_err, USR_INIT.mLanguage, item.providertype);
					mForm_PikFail_H.ShowDialog();
					MainForm0.stop_buzzer_warning(mFn);
				});
				pikFail = mForm_PikFail_H.get_pikfail();
				if (pikFail != PikFail.Continue)
				{
					return pikFail;
				}
			}
			DialogResult ret;
			do
			{
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return pikFail;
				}
				mode = VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE_PRICISE_SECOND;
				mode = VISUAL_MODE.HIGHCAM_SMT_PRICISE_SECOND;
				int mHCamPrisice_TryNum = USR2.mHCamPrisice_TryNum;
				while (mHCamPrisice_TryNum-- > 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return pikFail;
					}
					string msg = "LABEL_RETRY2:";
					MainForm0.write_to_logFile(msg);
					visual_result.set_w_h(item.l_ref_mm, item.w_ref_mm);
					if (MainForm0.ImageVisual(mFn, mode, item.cameratype, item.visualtype, item.scan_r, item.threshold, zn, 0, 0, item.mnt_a, ref visual_result) != 0)
					{
						continue;
					}
					msg = "LABEL_RETRY2: 识别  输出旋转角度（" + visual_result.move_angle + "）";
					MainForm0.write_to_logFile(msg);
					float num = (item.mnt_a % 90f - 90f) % 90f;
					float num2 = num + visual_result.move_angle;
					if (Math.Abs(num2) >= 45f)
					{
						num2 = ((!(num2 >= 0f)) ? (num2 + 90f) : (num2 - 90f));
					}
					if (Math.Abs(num2) > USR2.mHCamPrisice_DeltaA)
					{
						float num3 = Math.Abs(num2);
						if (num3 < 0.16f)
						{
							if (num3 * 3f / 4f > 0.014063f)
							{
								num3 = num2 * 3f / 4f;
							}
							else if (num2 > 0f)
							{
								num3 = 0.014063f;
							}
							else if (num2 < 0f)
							{
								num3 = -0.014063f;
							}
							msg = "LABEL_RETRY2: 识别 当前角度（" + MainForm0.mCur[mFn].a[zn] + "） 实际旋转角度（" + num3 + "）";
							MainForm0.write_to_logFile(msg);
							if (MainForm0.mIsSimulation)
							{
								MainForm0.moon_buffer_move_angel(MainForm0.pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 24, new Size(1944, 1944), new Point(972, 972), item.scan_r, num3);
							}
							MainForm0.moveToA_andWait_Smt(mFn, zn, A_SPEED, MainForm0.mCur[mFn].a[zn] + MainForm0.AngleToSteps(num3));
						}
						else
						{
							msg = "LABEL_RETRY2: 识别 当前角度（" + MainForm0.mCur[mFn].a[zn] + "） 实际旋转角度（" + num2 + "）";
							MainForm0.write_to_logFile(msg);
							if (MainForm0.mIsSimulation)
							{
								MainForm0.moon_buffer_move_angel(MainForm0.pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 24, new Size(1944, 1944), new Point(972, 972), item.scan_r, num2);
							}
							MainForm0.moveToA_andWait_Smt(mFn, zn, A_SPEED, MainForm0.mCur[mFn].a[zn] + MainForm0.AngleToSteps(num2));
						}
					}
					else
					{
						if (!((float)Math.Abs(visual_result.move_x) > USR2.mHCamPrisice_DeltaXY) && !((float)Math.Abs(visual_result.move_y) >= USR2.mHCamPrisice_DeltaXY))
						{
							mXref[zn] = (int)(MainForm0.mCur[mFn].x - USR.mHighCamRecognizeCoord[0][zn].X);
							mYref[zn] = (int)(MainForm0.mCur[mFn].y - USR.mHighCamRecognizeCoord[0][zn].Y);
							break;
						}
						MainForm0.moveToXY_andWait_Smt(mFn, XY_SPEED, new Coordinate(MainForm0.mCur[mFn].x + visual_result.move_x, MainForm0.mCur[mFn].y + visual_result.move_y));
						if (MainForm0.mIsSimulation)
						{
							MainForm0.moon_buffer_move_xy(MainForm0.pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 24, new Size(1944, 1944), new Point(972, 972), item.scan_r, 0f - visual_result.px, 0f - visual_result.py);
						}
					}
				}
				mSmtVisualDone[zn] = ((mHCamPrisice_TryNum > 0) ? SMT_VISUAL_STATE.SUCCESS : SMT_VISUAL_STATE.FAIL);
				if (mSmtVisualDone[zn] != SMT_VISUAL_STATE.FAIL)
				{
					break;
				}
				Invoke((MethodInvoker)delegate
				{
					MainForm0.start_buzzer_warning(mFn);
					mForm_PikFail_H = new Form_PikFail_HCamPrecise(mFn, msg_err, USR_INIT.mLanguage, item.providertype);
					ret = mForm_PikFail_H.ShowDialog();
					MainForm0.stop_buzzer_warning(mFn);
				});
				pikFail = mForm_PikFail_H.get_pikfail();
			}
			while (pikFail == PikFail.Continue);
			return pikFail;
		}

		private void thd_SmtLoop_YouxianPik(object o)
		{
			if (mthd_aftersmtdone != null)
			{
				while (mthd_aftersmtdone.IsAlive)
				{
					Thread.Sleep(5);
				}
				mthd_aftersmtdone = null;
			}
			Thread.Sleep(10);
			BindingList<int> bindingList = (BindingList<int>)o;
			if (bindingList == null || bindingList.Count <= 0)
			{
				return;
			}
			youxian_pik = 0;
			if (msmt_mode == SmtOpMode.AutoRun)
			{
				if (USR3B.mIsYouxianPik && USR3B.mIsYouxianVisual)
				{
					youxian_pik = 2;
				}
				else if (USR3B.mIsYouxianPik && !USR3B.mIsYouxianVisual)
				{
					youxian_pik = 1;
				}
				if (USR3B.mPrjSmtMode == 1 && mUSR3List.Count == HW.mSections && !is_tran4_can_youxianpik(mUSR3List))
				{
					youxian_pik = 0;
				}
			}
			int num = bindingList[mloop_idx];
			USR3_DATA uSR3_DATA = mUSR3List[num];
			if (mUSR3Idx != num)
			{
				mUSR3Idx_Prev = mUSR3Idx;
				mUSR3Idx = num;
				BeginInvoke((MethodInvoker)delegate
				{
					button_subpcb[mUSR3Idx].CnSetPressDown(flag: true);
					button_subpcb[mUSR3Idx_Prev].CnSetPressDown(flag: false);
				});
				thd_subpcb_flush_allpages();
				Thread.Sleep(10);
			}
			mCurSaved_fromBigTab_pcbIdx = num;
			mCurSaved_fromBigTab_groupIdx = 0;
			draw_fakechip_all(mUSR3Idx, isdone: false);
			msmt_preparetime = 0.0;
			msmt_starttime = DateTime.Now;
			if (uSR3_DATA.mBigTab.Count <= 0)
			{
				return;
			}
			mthrowlist = new BindingList<int_2d>();
			mthrowlist.Clear();
			vsplus_group(uSR3_DATA.mBigTab[0], mthrowlist, youxian_pik, 0);
			msmt_preparetime = (DateTime.Now - msmt_starttime).TotalMilliseconds;
			if (USR3B.mIsAfterYouxianPikGotoMark1)
			{
				MainForm0.WaitComplete_XY(mFn);
				Coordinate coordinate = new Coordinate(0L, 0L);
				coordinate.X = uSR3_DATA.mMark[0].X;
				coordinate.Y = uSR3_DATA.mMark[0].Y;
				if (uSR3_DATA.mIsMarkSearch[0])
				{
					coordinate.X = uSR3_DATA.mMarkSearch[0].X;
					coordinate.Y = uSR3_DATA.mMarkSearch[0].Y;
				}
				MainForm0.moveToXY_andWait_Smt(mFn, XY_SPEED, coordinate);
			}
		}

		private int s_auto_smt_3dsq400_fn0()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int num = -1;
			int num2 = -1;
			while (true)
			{
				if ((MainForm0.mRunDoing[mFn] & 2) == 0)
				{
					int num3 = 3000;
					while (MainForm0.mutex_readplaywood)
					{
						Thread.Sleep(1);
						if (num3-- == 0)
						{
							MainForm0.mutex_readplaywood = false;
						}
						if ((MainForm0.mRunDoing[mFn] & 2) == 0)
						{
							continue;
						}
						goto IL_06c4;
					}
					MainForm0.mutex_readplaywood = true;
					QnCommon.mPlayWoodState_Sensor = -1;
					num = -1;
					QnCommon.mPlayWoodState_Motor = -1;
					num2 = -1;
					MainForm0.mConDevExt[0].readPlayWoodState();
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.readPlayWoodState();
					}
					int num4 = 100;
					while (true)
					{
						DateTime now = DateTime.Now;
						double num5 = 0.0;
						while ((MainForm0.mRunDoing[mFn] & 2) == 0)
						{
							if (is_sim_dsq())
							{
								QnCommon.mPlayWoodState_Sensor = MainForm0.mDebugFormDSQ.get_S();
								QnCommon.mPlayWoodState_Motor = MainForm0.mDebugFormDSQ.get_M();
							}
							if (QnCommon.mPlayWoodState_Sensor == -1 || QnCommon.mPlayWoodState_Motor == -1)
							{
								Thread.Sleep(0);
								num5 = (DateTime.Now - now).TotalMilliseconds;
								if (num5 < (double)num4)
								{
									continue;
								}
							}
							goto IL_013f;
						}
						break;
						IL_013f:
						if (!(num5 < (double)num4))
						{
							if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
							{
								break;
							}
							MainForm0.mConDevExt[0].readPlayWoodState();
							if (is_sim_dsq())
							{
								MainForm0.mDebugFormDSQ.readPlayWoodState();
							}
							Thread.Sleep(10);
							continue;
						}
						goto IL_0186;
					}
				}
				goto IL_06c4;
				IL_0663:
				if (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Fail)
				{
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD FAIL, PLEASE CHECK" : "进板失败，请处理");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					break;
				}
				Thread.Sleep(100);
				continue;
				IL_0186:
				if (is_sim_dsq())
				{
					QnCommon.mInBoardState[mFn] = MainForm0.mDebugFormDSQ.get_InB(mFn);
					QnCommon.mOutBoardState[mFn] = MainForm0.mDebugFormDSQ.get_OutB(mFn);
				}
				MainForm0.mutex_readplaywood = false;
				num = QnCommon.mPlayWoodState_Sensor;
				num2 = QnCommon.mPlayWoodState_Motor;
				bool flag4 = false;
				if (mFn == 0)
				{
					flag4 = ((uint)num & 2u) != 0 && (num & 4) == 0 && (num2 & 3) == 0 && !flag2 && !flag3;
				}
				else if (mFn == 1)
				{
					flag4 = ((MainForm0.USR_INIT.mTrack.mode != 0) ? ((((uint)num & 8u) != 0 || ((uint)num & 0x10u) != 0) && (num2 & 4) == 0 && !flag2 && !flag3 && (num & 0x20) != 0) : (((uint)num & 8u) != 0 && (num & 0x10) == 0 && (num2 & 4) == 0 && !flag2 && !flag3));
				}
				if (flag4)
				{
					flag2 = true;
					QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					BeginInvoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD..." : "出板中...");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.set_OutB(mFn, QnCommon.BoardStateEn.Unknown);
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						goto IL_06c4;
					}
					MainForm0.static_this.misc_board_out(mFn, 0, 0, useBTC: false);
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.sendOutBoard(mFn);
					}
				}
				if (mFn == 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						goto IL_06c4;
					}
					if ((num & 2) == 0 && (num & 1) == 0 && (num2 & 1) == 0)
					{
						MainForm0.mConDevExt[0].sendSwitchSMTready(1);
					}
					else
					{
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					}
				}
				bool flag5 = false;
				if (mFn == 0)
				{
					flag5 = (num & 2) == 0 && ((uint)num & (true ? 1u : 0u)) != 0 && (num2 & 1) == 0 && !flag;
				}
				else if (mFn == 1)
				{
					flag5 = (num & 8) == 0 && (num & 0x10) == 0 && ((uint)num & 4u) != 0 && (num2 & 6) == 0 && !flag;
				}
				if (flag5)
				{
					flag = true;
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					BeginInvoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD..." : "进板中...");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.set_InB(mFn, QnCommon.BoardStateEn.Unknown);
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						goto IL_06c4;
					}
					MainForm0.mConDevExt[0].sendInBoard(mFn, 0, 0);
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.sendInBoard(mFn);
					}
					flag3 = true;
					if (youxian_pik != 0)
					{
						mloop_idx = 0;
						msmtchip_idx_raw = 0;
						msmtchip_idx = 0;
						mis_maybe_continue = 0;
						Thread thread = new Thread(thd_SmtLoop_YouxianPik);
						thread.IsBackground = true;
						thread.Start(mloop);
					}
				}
				if (QnCommon.mOutBoardState[mFn] != 0)
				{
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Ok)
					{
						QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
						if (is_sim_dsq())
						{
							MainForm0.mDebugFormDSQ.set_OutB(mFn, QnCommon.BoardStateEn.Unknown);
						}
						BeginInvoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD SUCCESSFUL" : "出板成功，等待下一板组..");
							if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
							{
								MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
							}
						});
						flag2 = false;
					}
					else if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						BeginInvoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD FAIL, PLEASE CHECK" : "出板失败，请处理");
							if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
							{
								MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
							}
						});
						break;
					}
				}
				if (QnCommon.mInBoardState[mFn] != QnCommon.BoardStateEn.Ok)
				{
					goto IL_0663;
				}
				QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
				if (is_sim_dsq())
				{
					MainForm0.mDebugFormDSQ.set_InB(mFn, QnCommon.BoardStateEn.Unknown);
				}
				BeginInvoke((MethodInvoker)delegate
				{
					label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，开始贴装..");
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
					}
				});
				if ((MainForm0.mRunDoing[mFn] & 2) == 0)
				{
					mloop_idx = 0;
					msmtchip_idx_raw = 0;
					msmtchip_idx = 0;
					mis_maybe_continue = 0;
					if (mthd_smtRun != null && mthd_smtRun.IsAlive)
					{
						mthd_smtRun.Abort();
						Thread.Sleep(100);
					}
					mthd_smtRun = new Thread(thd_SmtLoop);
					mthd_smtRun.IsBackground = true;
					mthd_smtRun.Start(mloop);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，正在贴装..");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					while (vsplus_smtbusy() || MainForm0.mRunDoing[mFn] != 0)
					{
						if ((MainForm0.mRunDoing[mFn] & 2) == 0)
						{
							Thread.Sleep(100);
							continue;
						}
						MainForm0.mutex_readplaywood = false;
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
						return -2;
					}
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "贴装完成，等待出板..");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					if (!bIsFinishAutoRun)
					{
						flag = false;
						flag3 = false;
						goto IL_0663;
					}
				}
				goto IL_06c4;
				IL_06c4:
				MainForm0.mutex_readplaywood = false;
				MainForm0.mConDevExt[0].sendSwitchSMTready(0);
				return -1;
			}
			MainForm0.mutex_readplaywood = false;
			MainForm0.mConDevExt[0].sendSwitchSMTready(0);
			return -3;
		}

		private int s_auto_smt_3dsq400_jiebotai()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int num = -1;
			int num2 = -1;
			while (true)
			{
				if ((MainForm0.mRunDoing[mFn] & 2) == 0)
				{
					int num3 = 3000;
					while (MainForm0.mutex_readplaywood)
					{
						Thread.Sleep(1);
						if (num3-- == 0)
						{
							MainForm0.mutex_readplaywood = false;
						}
						if ((MainForm0.mRunDoing[mFn] & 2) == 0)
						{
							continue;
						}
						goto IL_055d;
					}
					MainForm0.mutex_readplaywood = true;
					QnCommon.mPlayWoodState_Sensor = -1;
					num = -1;
					QnCommon.mPlayWoodState_Motor = -1;
					num2 = -1;
					MainForm0.mConDevExt[0].readPlayWoodState();
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.readPlayWoodState();
					}
					int num4 = 100;
					while (true)
					{
						DateTime now = DateTime.Now;
						double num5 = 0.0;
						while ((MainForm0.mRunDoing[mFn] & 2) == 0)
						{
							if (QnCommon.mPlayWoodState_Sensor == -1 || QnCommon.mPlayWoodState_Motor == -1)
							{
								Thread.Sleep(0);
								num5 = (DateTime.Now - now).TotalMilliseconds;
								if (num5 < (double)num4)
								{
									continue;
								}
							}
							goto IL_010f;
						}
						break;
						IL_010f:
						if (!(num5 < (double)num4))
						{
							if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
							{
								break;
							}
							MainForm0.mConDevExt[0].readPlayWoodState();
							Thread.Sleep(10);
							if (is_sim_dsq())
							{
								QnCommon.mPlayWoodState_Sensor = MainForm0.mDebugFormDSQ.get_S();
								QnCommon.mPlayWoodState_Motor = MainForm0.mDebugFormDSQ.get_M();
							}
							continue;
						}
						goto IL_0171;
					}
				}
				goto IL_055d;
				IL_0523:
				if (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Fail)
				{
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD FAIL, PLEASE CHECK" : "进板失败，请处理");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					break;
				}
				Thread.Sleep(100);
				continue;
				IL_0171:
				if (is_sim_dsq())
				{
					QnCommon.mInBoardState[mFn] = MainForm0.mDebugFormDSQ.get_InB(mFn);
					QnCommon.mOutBoardState[mFn] = MainForm0.mDebugFormDSQ.get_OutB(mFn);
				}
				MainForm0.mutex_readplaywood = false;
				num = QnCommon.mPlayWoodState_Sensor;
				num2 = QnCommon.mPlayWoodState_Motor;
				bool flag4 = false;
				if (mFn == 0)
				{
					flag4 = ((uint)num & 2u) != 0 && (num & 4) == 0 && (num2 & 3) == 0 && !flag2 && !flag3;
				}
				else if (mFn == 1)
				{
					flag4 = ((MainForm0.USR_INIT.mTrack.mode != 0) ? ((((uint)num & 8u) != 0 || ((uint)num & 0x10u) != 0) && (num2 & 4) == 0 && !flag2 && !flag3 && (num & 0x20) != 0) : (((uint)num & 8u) != 0 && (num & 0x10) == 0 && (num2 & 4) == 0 && !flag2 && !flag3));
				}
				if (flag4)
				{
					flag2 = true;
					QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					BeginInvoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD..." : "出板中...");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.set_OutB(mFn, QnCommon.BoardStateEn.Unknown);
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						goto IL_055d;
					}
					MainForm0.static_this.misc_board_out(mFn, 0, 0, useBTC: false);
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.sendOutBoard(mFn);
					}
				}
				if (mFn == 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						goto IL_055d;
					}
					if ((num & 2) == 0 && (num & 1) == 0 && (num2 & 1) == 0)
					{
						MainForm0.mConDevExt[0].sendSwitchSMTready(1);
					}
					else
					{
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
					}
				}
				bool flag5 = false;
				if (mFn == 0)
				{
					flag5 = (num & 2) == 0 && ((uint)num & (true ? 1u : 0u)) != 0 && (num2 & 1) == 0 && !flag;
				}
				else if (mFn == 1)
				{
					flag5 = (num & 8) == 0 && (num & 0x10) == 0 && ((uint)num & 4u) != 0 && (num2 & 6) == 0 && !flag;
				}
				if (flag5)
				{
					flag = true;
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					BeginInvoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD..." : "进板中...");
						if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
						{
							MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
						}
					});
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.set_InB(mFn, QnCommon.BoardStateEn.Unknown);
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						goto IL_055d;
					}
					MainForm0.mConDevExt[0].sendInBoard(mFn, 0, 1);
					if (is_sim_dsq())
					{
						MainForm0.mDebugFormDSQ.sendInBoard(mFn);
					}
					flag3 = true;
				}
				if (QnCommon.mOutBoardState[mFn] != 0)
				{
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Ok)
					{
						QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
						if (is_sim_dsq())
						{
							MainForm0.mDebugFormDSQ.set_OutB(mFn, QnCommon.BoardStateEn.Unknown);
						}
						BeginInvoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD SUCCESSFUL" : "出板成功，等待下一板组..");
							if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
							{
								MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
							}
						});
						flag2 = false;
					}
					else if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						BeginInvoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD FAIL, PLEASE CHECK" : "出板失败，请处理");
							if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
							{
								MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
							}
						});
						break;
					}
				}
				if (QnCommon.mInBoardState[mFn] != QnCommon.BoardStateEn.Ok)
				{
					goto IL_0523;
				}
				QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
				if (is_sim_dsq())
				{
					MainForm0.mDebugFormDSQ.set_InB(mFn, QnCommon.BoardStateEn.Unknown);
				}
				BeginInvoke((MethodInvoker)delegate
				{
					label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL..." : "进板成功..");
					if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
					{
						MainForm0.uc_smtRunning.set_label_SmtState(mFn, label_SmtState.Text);
					}
				});
				if ((MainForm0.mRunDoing[mFn] & 2) == 0)
				{
					Thread.Sleep(300);
					if (!bIsFinishAutoRun)
					{
						flag = false;
						flag3 = false;
						goto IL_0523;
					}
				}
				goto IL_055d;
				IL_055d:
				MainForm0.mConDevExt[0].sendSwitchSMTready(0);
				return -1;
			}
			MainForm0.mConDevExt[0].sendSwitchSMTready(0);
			return -3;
		}

		private bool is_sim_dsq()
		{
			if (MainForm0.mIsSimulation && MainForm0.mDebugFormDSQ != null)
			{
				return !MainForm0.mDebugFormDSQ.IsDisposed;
			}
			return false;
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
			tabControl_mainwork = new System.Windows.Forms.TabControl();
			tabPage_main_pcbedit = new System.Windows.Forms.TabPage();
			panel_subpcb = new System.Windows.Forms.Panel();
			label_subpcb_title = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			panel_subpcblist = new System.Windows.Forms.Panel();
			panel_PcbEditPage = new System.Windows.Forms.Panel();
			panel_PCBE_OP = new System.Windows.Forms.Panel();
			label87 = new System.Windows.Forms.Label();
			label144 = new System.Windows.Forms.Label();
			label86 = new System.Windows.Forms.Label();
			label85 = new System.Windows.Forms.Label();
			label138 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			panel_PCBE = new System.Windows.Forms.Panel();
			tabPage_main_smt = new System.Windows.Forms.TabPage();
			panel_SmtProducePage = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			panel_vsplus_pausestop = new System.Windows.Forms.Panel();
			panel100 = new System.Windows.Forms.Panel();
			checkBox_flashlight = new System.Windows.Forms.CheckBox();
			panel3 = new System.Windows.Forms.Panel();
			checkBox_smtxyaspeed_edit = new System.Windows.Forms.CheckBox();
			checkBox_FinishAutoSmt = new System.Windows.Forms.CheckBox();
			panel32 = new System.Windows.Forms.Panel();
			label_smtASpeed = new System.Windows.Forms.Label();
			trackBar_smtASpeed = new System.Windows.Forms.TrackBar();
			label_smt_XYspeed = new System.Windows.Forms.Label();
			label_smtXYSpeed = new System.Windows.Forms.Label();
			trackBar_smtXYSpeed = new System.Windows.Forms.TrackBar();
			label_smt_Aspeed = new System.Windows.Forms.Label();
			progressBar_Process = new System.Windows.Forms.ProgressBar();
			panel30 = new System.Windows.Forms.Panel();
			label_haiba = new System.Windows.Forms.Label();
			label40 = new System.Windows.Forms.Label();
			label_SmtIndexNo = new System.Windows.Forms.Label();
			label_All_CurChipIndex = new System.Windows.Forms.Label();
			label_everyhour_speed = new System.Windows.Forms.Label();
			label_everyhour_maxspeed = new System.Windows.Forms.Label();
			label215 = new System.Windows.Forms.Label();
			label208 = new System.Windows.Forms.Label();
			label210 = new System.Windows.Forms.Label();
			label209 = new System.Windows.Forms.Label();
			label207 = new System.Windows.Forms.Label();
			label_All_PCBSmted = new System.Windows.Forms.Label();
			label_vsplus_smtmode = new System.Windows.Forms.Label();
			label_SmtState = new System.Windows.Forms.Label();
			checkBox_simulate_visualpass = new System.Windows.Forms.CheckBox();
			checkBox_simulator = new System.Windows.Forms.CheckBox();
			label_title_smt = new System.Windows.Forms.Label();
			panel_smtshoware = new System.Windows.Forms.Panel();
			panel_fakepcb_smt = new System.Windows.Forms.Panel();
			panel7 = new System.Windows.Forms.Panel();
			label16 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			panel_youxianpik = new System.Windows.Forms.Panel();
			radioButton_none_aftersmtdone = new System.Windows.Forms.RadioButton();
			radioButton_gotodefine_aftersmtdone = new System.Windows.Forms.RadioButton();
			checkBox_youxian_visual = new System.Windows.Forms.CheckBox();
			radioButton_gotopik_aftersmtdone = new System.Windows.Forms.RadioButton();
			label13 = new System.Windows.Forms.Label();
			label_gotodefinexy_aftersmtdone = new System.Windows.Forms.Label();
			checkBox_afteryouxian_gotomark1 = new System.Windows.Forms.CheckBox();
			panel_marksetting = new System.Windows.Forms.Panel();
			radioButton4 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton6 = new System.Windows.Forms.RadioButton();
			checkBox_AutoFail_ToManual = new System.Windows.Forms.CheckBox();
			checkBox_Memory_Mark = new System.Windows.Forms.CheckBox();
			checkBox_No_Mark = new System.Windows.Forms.CheckBox();
			label6 = new System.Windows.Forms.Label();
			checkBox_gen0_raisespeed = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			checkBox_youxian_pik = new System.Windows.Forms.CheckBox();
			checkBox_preparevacuum_veryearly = new System.Windows.Forms.CheckBox();
			panel4 = new System.Windows.Forms.Panel();
			radioButton_prjmode1 = new System.Windows.Forms.RadioButton();
			radioButton_prjmode0 = new System.Windows.Forms.RadioButton();
			label2 = new System.Windows.Forms.Label();
			panel_safespace = new System.Windows.Forms.Panel();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			numericUpDown_safespace = new System.Windows.Forms.NumericUpDown();
			label123 = new System.Windows.Forms.Label();
			label122 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton_visualfailretry_afterfinish = new System.Windows.Forms.RadioButton();
			radioButton_visualfailretry_rightnow = new System.Windows.Forms.RadioButton();
			label1 = new System.Windows.Forms.Label();
			numericUpDown_failretryNum = new System.Windows.Forms.NumericUpDown();
			checkBox5 = new System.Windows.Forms.CheckBox();
			checkBox_ischeckNozzle = new System.Windows.Forms.CheckBox();
			checkBox_Loukong = new System.Windows.Forms.CheckBox();
			panel_smtinfo = new System.Windows.Forms.Panel();
			textBox_infolog = new System.Windows.Forms.TextBox();
			panel6 = new System.Windows.Forms.Panel();
			label104 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label_infototalexceptions = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label_infototaldroprate = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label_infototalnones = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label_infototaldrops = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label_infototalchips = new System.Windows.Forms.Label();
			checkBox_onlyAutoMode = new System.Windows.Forms.CheckBox();
			label114 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label91 = new System.Windows.Forms.Label();
			label_infodate = new System.Windows.Forms.Label();
			label_infocycletime = new System.Windows.Forms.Label();
			label_infototalpcbs = new System.Windows.Forms.Label();
			label112 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label_smtloopmode = new System.Windows.Forms.Label();
			button_throwrate_check = new QIGN_COMMON.vs_acontrol.CnButton();
			button_Infologfile_browse = new QIGN_COMMON.vs_acontrol.CnButton();
			button_info_clear = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close_youxianpik = new QIGN_COMMON.vs_acontrol.CnButton();
			button_gotodefinexy_Save = new QIGN_COMMON.vs_acontrol.CnButton();
			button_gotodefinexy_Goto = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close_marksetting = new QIGN_COMMON.vs_acontrol.CnButton();
			button_marksetting = new QIGN_COMMON.vs_acontrol.CnButton();
			button_youxian_pik = new QIGN_COMMON.vs_acontrol.CnButton();
			button_StackIsMount = new QIGN_COMMON.vs_acontrol.CnButton();
			button_close = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SmtStackPlateStartNo = new QIGN_COMMON.vs_acontrol.CnButton();
			button_openFeederPage_vsplus = new QIGN_COMMON.vs_acontrol.CnButton();
			button_subpcb_select = new QIGN_COMMON.vs_acontrol.CnButton();
			button24 = new QIGN_COMMON.vs_acontrol.CnButton();
			button18 = new QIGN_COMMON.vs_acontrol.CnButton();
			button22 = new QIGN_COMMON.vs_acontrol.CnButton();
			button17 = new QIGN_COMMON.vs_acontrol.CnButton();
			button20 = new QIGN_COMMON.vs_acontrol.CnButton();
			button16 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_del_subpcb = new QIGN_COMMON.vs_acontrol.CnButton();
			button_subpcb_setting = new QIGN_COMMON.vs_acontrol.CnButton();
			button_add_subpcb = new QIGN_COMMON.vs_acontrol.CnButton();
			button_smtTest = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PCBE_feeder = new QIGN_COMMON.vs_acontrol.CnButton();
			button_goto_PCBEdit = new QIGN_COMMON.vs_acontrol.CnButton();
			button_Legal = new QIGN_COMMON.vs_acontrol.CnButton();
			button_openFeederPage = new QIGN_COMMON.vs_acontrol.CnButton();
			button_Cat = new QIGN_COMMON.vs_acontrol.CnButton();
			button_vsplus_startsmt = new QIGN_COMMON.vs_acontrol.CnButton();
			button_vsplus_startsmt2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_vsplus_continuesmt = new QIGN_COMMON.vs_acontrol.CnButton();
			button_vsplus_setsmt = new QIGN_COMMON.vs_acontrol.CnButton();
			button_PauseSmt = new QIGN_COMMON.vs_acontrol.CnButton();
			button_vsplus_stopsmt = new QIGN_COMMON.vs_acontrol.CnButton();
			button_Loukong_clearS3 = new QIGN_COMMON.vs_acontrol.CnButton();
			button_vsplus_smtinfo = new QIGN_COMMON.vs_acontrol.CnButton();
			button_SmtVisualShow = new QIGN_COMMON.vs_acontrol.CnButton();
			button_smt_showfackpcb = new QIGN_COMMON.vs_acontrol.CnButton();
			button_bigtab = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_vsplus_startsmt = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_vsplus_setsmt = new QIGN_COMMON.vs_acontrol.CnButton();
			tabControl_mainwork.SuspendLayout();
			tabPage_main_pcbedit.SuspendLayout();
			panel_subpcb.SuspendLayout();
			panel_subpcblist.SuspendLayout();
			panel_PcbEditPage.SuspendLayout();
			panel_PCBE_OP.SuspendLayout();
			tabPage_main_smt.SuspendLayout();
			panel_SmtProducePage.SuspendLayout();
			panel5.SuspendLayout();
			panel_vsplus_pausestop.SuspendLayout();
			panel100.SuspendLayout();
			panel3.SuspendLayout();
			panel32.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_smtASpeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_smtXYSpeed).BeginInit();
			panel30.SuspendLayout();
			panel_smtshoware.SuspendLayout();
			panel_fakepcb_smt.SuspendLayout();
			panel7.SuspendLayout();
			panel2.SuspendLayout();
			panel_youxianpik.SuspendLayout();
			panel_marksetting.SuspendLayout();
			panel4.SuspendLayout();
			panel_safespace.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_safespace).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_failretryNum).BeginInit();
			panel_smtinfo.SuspendLayout();
			panel6.SuspendLayout();
			SuspendLayout();
			tabControl_mainwork.Controls.Add(tabPage_main_pcbedit);
			tabControl_mainwork.Controls.Add(tabPage_main_smt);
			tabControl_mainwork.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			tabControl_mainwork.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tabControl_mainwork.ItemSize = new System.Drawing.Size(160, 28);
			tabControl_mainwork.Location = new System.Drawing.Point(0, 0);
			tabControl_mainwork.Name = "tabControl_mainwork";
			tabControl_mainwork.SelectedIndex = 0;
			tabControl_mainwork.Size = new System.Drawing.Size(719, 952);
			tabControl_mainwork.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tabControl_mainwork.TabIndex = 1;
			tabControl_mainwork.DrawItem += new System.Windows.Forms.DrawItemEventHandler(tabControl_mainwork_DrawItem_1);
			tabPage_main_pcbedit.BackColor = System.Drawing.Color.Bisque;
			tabPage_main_pcbedit.Controls.Add(panel_subpcb);
			tabPage_main_pcbedit.Controls.Add(panel_PcbEditPage);
			tabPage_main_pcbedit.Location = new System.Drawing.Point(4, 32);
			tabPage_main_pcbedit.Name = "tabPage_main_pcbedit";
			tabPage_main_pcbedit.Padding = new System.Windows.Forms.Padding(3);
			tabPage_main_pcbedit.Size = new System.Drawing.Size(711, 916);
			tabPage_main_pcbedit.TabIndex = 0;
			tabPage_main_pcbedit.Text = "PCB编辑";
			panel_subpcb.BackColor = System.Drawing.Color.White;
			panel_subpcb.Controls.Add(button_subpcb_select);
			panel_subpcb.Controls.Add(label_subpcb_title);
			panel_subpcb.Controls.Add(label26);
			panel_subpcb.Controls.Add(panel_subpcblist);
			panel_subpcb.Controls.Add(button_del_subpcb);
			panel_subpcb.Controls.Add(button_subpcb_setting);
			panel_subpcb.Controls.Add(button_add_subpcb);
			panel_subpcb.Font = new System.Drawing.Font("楷体", 10.5f);
			panel_subpcb.Location = new System.Drawing.Point(0, 50);
			panel_subpcb.Name = "panel_subpcb";
			panel_subpcb.Size = new System.Drawing.Size(723, 32);
			panel_subpcb.TabIndex = 18;
			panel_subpcb.Visible = false;
			label_subpcb_title.Font = new System.Drawing.Font("黑体", 12.75f);
			label_subpcb_title.Location = new System.Drawing.Point(373, 2);
			label_subpcb_title.Name = "label_subpcb_title";
			label_subpcb_title.Size = new System.Drawing.Size(332, 27);
			label_subpcb_title.TabIndex = 14;
			label_subpcb_title.Text = "PCB3无线模块";
			label_subpcb_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.BackColor = System.Drawing.Color.White;
			label26.Location = new System.Drawing.Point(-3, 30);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(747, 10);
			label26.TabIndex = 0;
			panel_subpcblist.Controls.Add(button24);
			panel_subpcblist.Controls.Add(button18);
			panel_subpcblist.Controls.Add(button22);
			panel_subpcblist.Controls.Add(button17);
			panel_subpcblist.Controls.Add(button20);
			panel_subpcblist.Controls.Add(button16);
			panel_subpcblist.Location = new System.Drawing.Point(113, 3);
			panel_subpcblist.Name = "panel_subpcblist";
			panel_subpcblist.Size = new System.Drawing.Size(254, 27);
			panel_subpcblist.TabIndex = 3;
			panel_PcbEditPage.BackColor = System.Drawing.Color.FromArgb(108, 148, 185);
			panel_PcbEditPage.Controls.Add(panel_PCBE_OP);
			panel_PcbEditPage.Controls.Add(label19);
			panel_PcbEditPage.Controls.Add(panel_PCBE);
			panel_PcbEditPage.Location = new System.Drawing.Point(1, 0);
			panel_PcbEditPage.Name = "panel_PcbEditPage";
			panel_PcbEditPage.Size = new System.Drawing.Size(720, 930);
			panel_PcbEditPage.TabIndex = 13;
			panel_PCBE_OP.Controls.Add(button_smtTest);
			panel_PCBE_OP.Controls.Add(button_PCBE_feeder);
			panel_PCBE_OP.Controls.Add(button_goto_PCBEdit);
			panel_PCBE_OP.Controls.Add(button_Legal);
			panel_PCBE_OP.Controls.Add(button_openFeederPage);
			panel_PCBE_OP.Controls.Add(button_Cat);
			panel_PCBE_OP.Controls.Add(label87);
			panel_PCBE_OP.Controls.Add(label144);
			panel_PCBE_OP.Controls.Add(label86);
			panel_PCBE_OP.Controls.Add(label85);
			panel_PCBE_OP.Controls.Add(label138);
			panel_PCBE_OP.Location = new System.Drawing.Point(-2, 0);
			panel_PCBE_OP.Name = "panel_PCBE_OP";
			panel_PCBE_OP.Size = new System.Drawing.Size(720, 50);
			panel_PCBE_OP.TabIndex = 16;
			label87.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label87.Location = new System.Drawing.Point(570, 0);
			label87.Name = "label87";
			label87.Size = new System.Drawing.Size(37, 42);
			label87.TabIndex = 14;
			label87.Text = "➠";
			label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label144.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label144.Location = new System.Drawing.Point(451, 1);
			label144.Name = "label144";
			label144.Size = new System.Drawing.Size(37, 42);
			label144.TabIndex = 14;
			label144.Text = "➠";
			label144.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label86.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label86.Location = new System.Drawing.Point(333, 1);
			label86.Name = "label86";
			label86.Size = new System.Drawing.Size(37, 42);
			label86.TabIndex = 14;
			label86.Text = "➠";
			label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label85.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label85.Location = new System.Drawing.Point(216, 2);
			label85.Name = "label85";
			label85.Size = new System.Drawing.Size(37, 42);
			label85.TabIndex = 14;
			label85.Text = "➠";
			label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label138.Font = new System.Drawing.Font("微软雅黑", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label138.Location = new System.Drawing.Point(98, 1);
			label138.Name = "label138";
			label138.Size = new System.Drawing.Size(37, 42);
			label138.TabIndex = 14;
			label138.Text = "➠";
			label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label19.BackColor = System.Drawing.Color.White;
			label19.Font = new System.Drawing.Font("黑体", 14.25f);
			label19.Location = new System.Drawing.Point(-2, 50);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(711, 32);
			label19.TabIndex = 18;
			label19.Text = "PCB编辑";
			label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_PCBE.Location = new System.Drawing.Point(-2, 84);
			panel_PCBE.Name = "panel_PCBE";
			panel_PCBE.Size = new System.Drawing.Size(705, 718);
			panel_PCBE.TabIndex = 17;
			tabPage_main_smt.BackColor = System.Drawing.Color.RosyBrown;
			tabPage_main_smt.Controls.Add(panel_SmtProducePage);
			tabPage_main_smt.Location = new System.Drawing.Point(4, 32);
			tabPage_main_smt.Name = "tabPage_main_smt";
			tabPage_main_smt.Padding = new System.Windows.Forms.Padding(3);
			tabPage_main_smt.Size = new System.Drawing.Size(711, 916);
			tabPage_main_smt.TabIndex = 1;
			tabPage_main_smt.Text = "SMT生产";
			panel_SmtProducePage.BackColor = System.Drawing.Color.FromArgb(108, 148, 185);
			panel_SmtProducePage.Controls.Add(panel5);
			panel_SmtProducePage.Controls.Add(checkBox_simulate_visualpass);
			panel_SmtProducePage.Controls.Add(checkBox_simulator);
			panel_SmtProducePage.Controls.Add(button_bigtab);
			panel_SmtProducePage.Controls.Add(label_title_smt);
			panel_SmtProducePage.Controls.Add(panel_smtshoware);
			panel_SmtProducePage.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			panel_SmtProducePage.Location = new System.Drawing.Point(1, 1);
			panel_SmtProducePage.Name = "panel_SmtProducePage";
			panel_SmtProducePage.Size = new System.Drawing.Size(720, 919);
			panel_SmtProducePage.TabIndex = 13;
			panel5.Controls.Add(button_vsplus_startsmt);
			panel5.Controls.Add(button_vsplus_startsmt2);
			panel5.Controls.Add(button_vsplus_continuesmt);
			panel5.Controls.Add(button_vsplus_setsmt);
			panel5.Controls.Add(panel_vsplus_pausestop);
			panel5.Controls.Add(panel100);
			panel5.Controls.Add(progressBar_Process);
			panel5.Controls.Add(panel30);
			panel5.Controls.Add(label_vsplus_smtmode);
			panel5.Controls.Add(label_SmtState);
			panel5.Location = new System.Drawing.Point(0, 41);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(724, 224);
			panel5.TabIndex = 173;
			panel_vsplus_pausestop.Controls.Add(button_PauseSmt);
			panel_vsplus_pausestop.Controls.Add(button_vsplus_stopsmt);
			panel_vsplus_pausestop.Location = new System.Drawing.Point(255, 143);
			panel_vsplus_pausestop.Name = "panel_vsplus_pausestop";
			panel_vsplus_pausestop.Size = new System.Drawing.Size(203, 47);
			panel_vsplus_pausestop.TabIndex = 170;
			panel_vsplus_pausestop.Visible = false;
			panel100.BackColor = System.Drawing.Color.White;
			panel100.Controls.Add(button_Loukong_clearS3);
			panel100.Controls.Add(checkBox_flashlight);
			panel100.Controls.Add(panel3);
			panel100.Controls.Add(checkBox_FinishAutoSmt);
			panel100.Controls.Add(button_vsplus_smtinfo);
			panel100.Controls.Add(panel32);
			panel100.Controls.Add(button_SmtVisualShow);
			panel100.Controls.Add(button_smt_showfackpcb);
			panel100.Location = new System.Drawing.Point(2, 35);
			panel100.Name = "panel100";
			panel100.Size = new System.Drawing.Size(220, 160);
			panel100.TabIndex = 165;
			checkBox_flashlight.AutoSize = true;
			checkBox_flashlight.Checked = true;
			checkBox_flashlight.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_flashlight.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_flashlight.Location = new System.Drawing.Point(14, 110);
			checkBox_flashlight.Name = "checkBox_flashlight";
			checkBox_flashlight.Size = new System.Drawing.Size(82, 18);
			checkBox_flashlight.TabIndex = 160;
			checkBox_flashlight.Text = "闪光模式";
			checkBox_flashlight.UseVisualStyleBackColor = true;
			checkBox_flashlight.CheckedChanged += new System.EventHandler(checkBox_flashlight_CheckedChanged);
			panel3.BackColor = System.Drawing.Color.Gainsboro;
			panel3.Controls.Add(checkBox_smtxyaspeed_edit);
			panel3.Location = new System.Drawing.Point(6, 81);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(202, 23);
			panel3.TabIndex = 164;
			checkBox_smtxyaspeed_edit.AutoSize = true;
			checkBox_smtxyaspeed_edit.Font = new System.Drawing.Font("黑体", 10.25f);
			checkBox_smtxyaspeed_edit.Location = new System.Drawing.Point(8, 3);
			checkBox_smtxyaspeed_edit.Name = "checkBox_smtxyaspeed_edit";
			checkBox_smtxyaspeed_edit.Size = new System.Drawing.Size(131, 18);
			checkBox_smtxyaspeed_edit.TabIndex = 0;
			checkBox_smtxyaspeed_edit.Text = "修改XY和A轴速度";
			checkBox_smtxyaspeed_edit.UseVisualStyleBackColor = true;
			checkBox_smtxyaspeed_edit.CheckedChanged += new System.EventHandler(checkBox_smtxyaspeed_edit_CheckedChanged);
			checkBox_FinishAutoSmt.AutoSize = true;
			checkBox_FinishAutoSmt.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_FinishAutoSmt.Location = new System.Drawing.Point(14, 130);
			checkBox_FinishAutoSmt.Name = "checkBox_FinishAutoSmt";
			checkBox_FinishAutoSmt.Size = new System.Drawing.Size(96, 18);
			checkBox_FinishAutoSmt.TabIndex = 163;
			checkBox_FinishAutoSmt.Text = "结束全自动";
			checkBox_FinishAutoSmt.UseVisualStyleBackColor = true;
			checkBox_FinishAutoSmt.Visible = false;
			checkBox_FinishAutoSmt.CheckedChanged += new System.EventHandler(checkBox_FinishAutoSmt_CheckedChanged);
			panel32.BackColor = System.Drawing.Color.Gainsboro;
			panel32.Controls.Add(label_smtASpeed);
			panel32.Controls.Add(trackBar_smtASpeed);
			panel32.Controls.Add(label_smt_XYspeed);
			panel32.Controls.Add(label_smtXYSpeed);
			panel32.Controls.Add(trackBar_smtXYSpeed);
			panel32.Controls.Add(label_smt_Aspeed);
			panel32.Font = new System.Drawing.Font("微软雅黑", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel32.Location = new System.Drawing.Point(6, 33);
			panel32.Name = "panel32";
			panel32.Size = new System.Drawing.Size(202, 55);
			panel32.TabIndex = 0;
			label_smtASpeed.AutoSize = true;
			label_smtASpeed.Font = new System.Drawing.Font("楷体", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smtASpeed.Location = new System.Drawing.Point(170, 28);
			label_smtASpeed.Name = "label_smtASpeed";
			label_smtASpeed.Size = new System.Drawing.Size(21, 13);
			label_smtASpeed.TabIndex = 11;
			label_smtASpeed.Text = "64";
			trackBar_smtASpeed.Enabled = false;
			trackBar_smtASpeed.Location = new System.Drawing.Point(72, 24);
			trackBar_smtASpeed.Maximum = 64;
			trackBar_smtASpeed.Minimum = 1;
			trackBar_smtASpeed.Name = "trackBar_smtASpeed";
			trackBar_smtASpeed.Size = new System.Drawing.Size(104, 45);
			trackBar_smtASpeed.TabIndex = 10;
			trackBar_smtASpeed.TickFrequency = 8;
			trackBar_smtASpeed.Value = 1;
			trackBar_smtASpeed.Scroll += new System.EventHandler(trackBar_smtASpeed_Scroll);
			label_smt_XYspeed.AutoSize = true;
			label_smt_XYspeed.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smt_XYspeed.Location = new System.Drawing.Point(6, 5);
			label_smt_XYspeed.Name = "label_smt_XYspeed";
			label_smt_XYspeed.Size = new System.Drawing.Size(56, 14);
			label_smt_XYspeed.TabIndex = 6;
			label_smt_XYspeed.Text = "X-Y速度";
			label_smtXYSpeed.AutoSize = true;
			label_smtXYSpeed.Font = new System.Drawing.Font("楷体", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smtXYSpeed.Location = new System.Drawing.Point(170, 4);
			label_smtXYSpeed.Name = "label_smtXYSpeed";
			label_smtXYSpeed.Size = new System.Drawing.Size(21, 13);
			label_smtXYSpeed.TabIndex = 11;
			label_smtXYSpeed.Text = "64";
			trackBar_smtXYSpeed.Enabled = false;
			trackBar_smtXYSpeed.Location = new System.Drawing.Point(72, 2);
			trackBar_smtXYSpeed.Maximum = 64;
			trackBar_smtXYSpeed.Minimum = 1;
			trackBar_smtXYSpeed.Name = "trackBar_smtXYSpeed";
			trackBar_smtXYSpeed.Size = new System.Drawing.Size(104, 45);
			trackBar_smtXYSpeed.TabIndex = 10;
			trackBar_smtXYSpeed.TickFrequency = 8;
			trackBar_smtXYSpeed.Value = 1;
			trackBar_smtXYSpeed.Scroll += new System.EventHandler(trackBar_smtXYSpeed_Scroll);
			label_smt_Aspeed.AutoSize = true;
			label_smt_Aspeed.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smt_Aspeed.Location = new System.Drawing.Point(4, 26);
			label_smt_Aspeed.Name = "label_smt_Aspeed";
			label_smt_Aspeed.Size = new System.Drawing.Size(63, 14);
			label_smt_Aspeed.TabIndex = 6;
			label_smt_Aspeed.Text = "旋转速度";
			progressBar_Process.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			progressBar_Process.Location = new System.Drawing.Point(2, 195);
			progressBar_Process.Name = "progressBar_Process";
			progressBar_Process.Size = new System.Drawing.Size(700, 21);
			progressBar_Process.TabIndex = 14;
			panel30.BackColor = System.Drawing.Color.Gainsboro;
			panel30.Controls.Add(label_haiba);
			panel30.Controls.Add(label40);
			panel30.Controls.Add(label_SmtIndexNo);
			panel30.Controls.Add(label_All_CurChipIndex);
			panel30.Controls.Add(label_everyhour_speed);
			panel30.Controls.Add(label_everyhour_maxspeed);
			panel30.Controls.Add(label215);
			panel30.Controls.Add(label208);
			panel30.Controls.Add(label210);
			panel30.Controls.Add(label209);
			panel30.Controls.Add(label207);
			panel30.Controls.Add(label_All_PCBSmted);
			panel30.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			panel30.Location = new System.Drawing.Point(483, 35);
			panel30.Name = "panel30";
			panel30.Size = new System.Drawing.Size(217, 160);
			panel30.TabIndex = 159;
			label_haiba.BackColor = System.Drawing.Color.White;
			label_haiba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_haiba.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_haiba.Location = new System.Drawing.Point(112, 111);
			label_haiba.Name = "label_haiba";
			label_haiba.Size = new System.Drawing.Size(94, 28);
			label_haiba.TabIndex = 12;
			label_haiba.Text = "0.00";
			label_haiba.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label40.Font = new System.Drawing.Font("黑体", 11.25f);
			label40.Location = new System.Drawing.Point(105, 133);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(112, 30);
			label40.TabIndex = 43;
			label40.Text = "当前海拔(mm)";
			label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_SmtIndexNo.BackColor = System.Drawing.Color.White;
			label_SmtIndexNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_SmtIndexNo.Font = new System.Drawing.Font("微软雅黑", 12f);
			label_SmtIndexNo.Location = new System.Drawing.Point(11, 111);
			label_SmtIndexNo.Name = "label_SmtIndexNo";
			label_SmtIndexNo.Size = new System.Drawing.Size(93, 28);
			label_SmtIndexNo.TabIndex = 12;
			label_SmtIndexNo.Text = "--";
			label_SmtIndexNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_All_CurChipIndex.BackColor = System.Drawing.Color.White;
			label_All_CurChipIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_All_CurChipIndex.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_All_CurChipIndex.ForeColor = System.Drawing.Color.Black;
			label_All_CurChipIndex.Location = new System.Drawing.Point(10, 57);
			label_All_CurChipIndex.Name = "label_All_CurChipIndex";
			label_All_CurChipIndex.Size = new System.Drawing.Size(94, 28);
			label_All_CurChipIndex.TabIndex = 41;
			label_All_CurChipIndex.Text = "200";
			label_All_CurChipIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_everyhour_speed.BackColor = System.Drawing.Color.White;
			label_everyhour_speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_everyhour_speed.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_everyhour_speed.ForeColor = System.Drawing.Color.Black;
			label_everyhour_speed.Location = new System.Drawing.Point(112, 57);
			label_everyhour_speed.Name = "label_everyhour_speed";
			label_everyhour_speed.Size = new System.Drawing.Size(94, 28);
			label_everyhour_speed.TabIndex = 41;
			label_everyhour_speed.Text = "15000";
			label_everyhour_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_everyhour_maxspeed.BackColor = System.Drawing.Color.White;
			label_everyhour_maxspeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_everyhour_maxspeed.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_everyhour_maxspeed.ForeColor = System.Drawing.Color.Black;
			label_everyhour_maxspeed.Location = new System.Drawing.Point(112, 4);
			label_everyhour_maxspeed.Name = "label_everyhour_maxspeed";
			label_everyhour_maxspeed.Size = new System.Drawing.Size(94, 28);
			label_everyhour_maxspeed.TabIndex = 42;
			label_everyhour_maxspeed.Text = "18000";
			label_everyhour_maxspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label215.Font = new System.Drawing.Font("黑体", 11.25f);
			label215.Location = new System.Drawing.Point(10, 133);
			label215.Name = "label215";
			label215.Size = new System.Drawing.Size(92, 30);
			label215.TabIndex = 43;
			label215.Text = "当前标号";
			label215.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label208.Font = new System.Drawing.Font("黑体", 11.25f);
			label208.Location = new System.Drawing.Point(7, 80);
			label208.Name = "label208";
			label208.Size = new System.Drawing.Size(96, 30);
			label208.TabIndex = 43;
			label208.Text = "已贴元件";
			label208.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label210.Font = new System.Drawing.Font("黑体", 11.25f);
			label210.Location = new System.Drawing.Point(104, 80);
			label210.Name = "label210";
			label210.Size = new System.Drawing.Size(119, 30);
			label210.TabIndex = 43;
			label210.Text = "平均速度(cph)";
			label210.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label209.Font = new System.Drawing.Font("黑体", 11.25f);
			label209.Location = new System.Drawing.Point(108, 28);
			label209.Name = "label209";
			label209.Size = new System.Drawing.Size(111, 30);
			label209.TabIndex = 43;
			label209.Text = "最大速度(cph)";
			label209.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label207.Font = new System.Drawing.Font("黑体", 11.25f);
			label207.ForeColor = System.Drawing.Color.Black;
			label207.Location = new System.Drawing.Point(8, 32);
			label207.Name = "label207";
			label207.Size = new System.Drawing.Size(96, 22);
			label207.TabIndex = 43;
			label207.Text = "已贴板组";
			label207.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_All_PCBSmted.BackColor = System.Drawing.Color.White;
			label_All_PCBSmted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_All_PCBSmted.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_All_PCBSmted.ForeColor = System.Drawing.Color.Black;
			label_All_PCBSmted.Location = new System.Drawing.Point(10, 4);
			label_All_PCBSmted.Name = "label_All_PCBSmted";
			label_All_PCBSmted.Size = new System.Drawing.Size(94, 28);
			label_All_PCBSmted.TabIndex = 41;
			label_All_PCBSmted.Text = "100";
			label_All_PCBSmted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_vsplus_smtmode.Font = new System.Drawing.Font("黑体", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_vsplus_smtmode.Location = new System.Drawing.Point(228, 37);
			label_vsplus_smtmode.Name = "label_vsplus_smtmode";
			label_vsplus_smtmode.Size = new System.Drawing.Size(249, 108);
			label_vsplus_smtmode.TabIndex = 167;
			label_vsplus_smtmode.Text = "全自动贴装";
			label_vsplus_smtmode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_vsplus_smtmode.Visible = false;
			label_SmtState.BackColor = System.Drawing.Color.SeaShell;
			label_SmtState.Font = new System.Drawing.Font("黑体", 13.25f);
			label_SmtState.Location = new System.Drawing.Point(2, 8);
			label_SmtState.Name = "label_SmtState";
			label_SmtState.Size = new System.Drawing.Size(698, 26);
			label_SmtState.TabIndex = 165;
			label_SmtState.Text = "SMT空闲状态";
			label_SmtState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_simulate_visualpass.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_simulate_visualpass.Location = new System.Drawing.Point(76, 12);
			checkBox_simulate_visualpass.Name = "checkBox_simulate_visualpass";
			checkBox_simulate_visualpass.Size = new System.Drawing.Size(112, 19);
			checkBox_simulate_visualpass.TabIndex = 168;
			checkBox_simulate_visualpass.Text = "忽略识别失败";
			checkBox_simulate_visualpass.UseVisualStyleBackColor = true;
			checkBox_simulate_visualpass.Visible = false;
			checkBox_simulate_visualpass.CheckedChanged += new System.EventHandler(checkBox_simulate_visualpass_CheckedChanged);
			checkBox_simulator.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_simulator.Location = new System.Drawing.Point(3, 12);
			checkBox_simulator.Name = "checkBox_simulator";
			checkBox_simulator.Size = new System.Drawing.Size(80, 19);
			checkBox_simulator.TabIndex = 161;
			checkBox_simulator.Text = "仿真";
			checkBox_simulator.UseVisualStyleBackColor = true;
			checkBox_simulator.Visible = false;
			checkBox_simulator.CheckedChanged += new System.EventHandler(checkBox_simulator_CheckedChanged);
			label_title_smt.Font = new System.Drawing.Font("黑体", 16.25f);
			label_title_smt.Location = new System.Drawing.Point(3, 12);
			label_title_smt.Name = "label_title_smt";
			label_title_smt.Size = new System.Drawing.Size(698, 29);
			label_title_smt.TabIndex = 156;
			label_title_smt.Text = "贴装生产";
			label_title_smt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_smtshoware.AutoScroll = true;
			panel_smtshoware.Controls.Add(panel_fakepcb_smt);
			panel_smtshoware.Location = new System.Drawing.Point(-3, 260);
			panel_smtshoware.Name = "panel_smtshoware";
			panel_smtshoware.Size = new System.Drawing.Size(707, 649);
			panel_smtshoware.TabIndex = 15;
			panel_fakepcb_smt.Controls.Add(panel7);
			panel_fakepcb_smt.Location = new System.Drawing.Point(11, 11);
			panel_fakepcb_smt.Name = "panel_fakepcb_smt";
			panel_fakepcb_smt.Size = new System.Drawing.Size(681, 605);
			panel_fakepcb_smt.TabIndex = 1;
			panel7.BackColor = System.Drawing.Color.FromArgb(108, 148, 185);
			panel7.Controls.Add(cnButton_vsplus_startsmt);
			panel7.Controls.Add(cnButton_vsplus_setsmt);
			panel7.Controls.Add(label16);
			panel7.Controls.Add(label15);
			panel7.Controls.Add(label17);
			panel7.Location = new System.Drawing.Point(5, 8);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(724, 260);
			panel7.TabIndex = 0;
			panel7.Visible = false;
			label16.BackColor = System.Drawing.Color.White;
			label16.Font = new System.Drawing.Font("黑体", 15.25f);
			label16.Location = new System.Drawing.Point(-6, 240);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(736, 8);
			label16.TabIndex = 156;
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label15.BackColor = System.Drawing.Color.White;
			label15.Font = new System.Drawing.Font("黑体", 15.25f);
			label15.Location = new System.Drawing.Point(-11, 67);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(736, 8);
			label15.TabIndex = 156;
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label17.Font = new System.Drawing.Font("黑体", 19.25f);
			label17.Location = new System.Drawing.Point(97, 20);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(475, 29);
			label17.TabIndex = 156;
			label17.Text = "贴装生产";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel2.BackColor = System.Drawing.Color.DimGray;
			panel2.Controls.Add(panel_youxianpik);
			panel2.Controls.Add(panel_marksetting);
			panel2.Controls.Add(checkBox_gen0_raisespeed);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(button_marksetting);
			panel2.Controls.Add(button_youxian_pik);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(checkBox_youxian_pik);
			panel2.Controls.Add(checkBox_preparevacuum_veryearly);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(panel_safespace);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(panel1);
			panel2.Controls.Add(checkBox5);
			panel2.Controls.Add(checkBox_ischeckNozzle);
			panel2.Controls.Add(checkBox_Loukong);
			panel2.Controls.Add(button_StackIsMount);
			panel2.Controls.Add(button_close);
			panel2.Controls.Add(button_SmtStackPlateStartNo);
			panel2.Font = new System.Drawing.Font("黑体", 9f);
			panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			panel2.Location = new System.Drawing.Point(748, 3);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(712, 350);
			panel2.TabIndex = 190;
			panel_youxianpik.BackColor = System.Drawing.Color.White;
			panel_youxianpik.Controls.Add(button_close_youxianpik);
			panel_youxianpik.Controls.Add(radioButton_none_aftersmtdone);
			panel_youxianpik.Controls.Add(radioButton_gotodefine_aftersmtdone);
			panel_youxianpik.Controls.Add(checkBox_youxian_visual);
			panel_youxianpik.Controls.Add(radioButton_gotopik_aftersmtdone);
			panel_youxianpik.Controls.Add(label13);
			panel_youxianpik.Controls.Add(label_gotodefinexy_aftersmtdone);
			panel_youxianpik.Controls.Add(checkBox_afteryouxian_gotomark1);
			panel_youxianpik.Controls.Add(button_gotodefinexy_Save);
			panel_youxianpik.Controls.Add(button_gotodefinexy_Goto);
			panel_youxianpik.Font = new System.Drawing.Font("黑体", 10f);
			panel_youxianpik.ForeColor = System.Drawing.Color.Black;
			panel_youxianpik.Location = new System.Drawing.Point(6, 142);
			panel_youxianpik.Name = "panel_youxianpik";
			panel_youxianpik.Size = new System.Drawing.Size(262, 197);
			panel_youxianpik.TabIndex = 185;
			panel_youxianpik.Visible = false;
			radioButton_none_aftersmtdone.AutoSize = true;
			radioButton_none_aftersmtdone.Location = new System.Drawing.Point(8, 77);
			radioButton_none_aftersmtdone.Name = "radioButton_none_aftersmtdone";
			radioButton_none_aftersmtdone.Size = new System.Drawing.Size(95, 18);
			radioButton_none_aftersmtdone.TabIndex = 27;
			radioButton_none_aftersmtdone.TabStop = true;
			radioButton_none_aftersmtdone.Text = "无额外动作";
			radioButton_none_aftersmtdone.UseVisualStyleBackColor = true;
			radioButton_gotodefine_aftersmtdone.AutoSize = true;
			radioButton_gotodefine_aftersmtdone.Location = new System.Drawing.Point(8, 134);
			radioButton_gotodefine_aftersmtdone.Name = "radioButton_gotodefine_aftersmtdone";
			radioButton_gotodefine_aftersmtdone.Size = new System.Drawing.Size(137, 18);
			radioButton_gotodefine_aftersmtdone.TabIndex = 27;
			radioButton_gotodefine_aftersmtdone.TabStop = true;
			radioButton_gotodefine_aftersmtdone.Text = "定位到自定义坐标";
			radioButton_gotodefine_aftersmtdone.UseVisualStyleBackColor = true;
			checkBox_youxian_visual.AutoSize = true;
			checkBox_youxian_visual.Location = new System.Drawing.Point(9, 11);
			checkBox_youxian_visual.Name = "checkBox_youxian_visual";
			checkBox_youxian_visual.Size = new System.Drawing.Size(166, 18);
			checkBox_youxian_visual.TabIndex = 3;
			checkBox_youxian_visual.Text = "提前取料后，直接视觉";
			checkBox_youxian_visual.UseVisualStyleBackColor = true;
			radioButton_gotopik_aftersmtdone.AutoSize = true;
			radioButton_gotopik_aftersmtdone.Location = new System.Drawing.Point(8, 98);
			radioButton_gotopik_aftersmtdone.Name = "radioButton_gotopik_aftersmtdone";
			radioButton_gotopik_aftersmtdone.Size = new System.Drawing.Size(235, 32);
			radioButton_gotopik_aftersmtdone.TabIndex = 27;
			radioButton_gotopik_aftersmtdone.TabStop = true;
			radioButton_gotopik_aftersmtdone.Text = "定位到首轮取料坐标（提前取料）\r\n或MARK1（不提前取料）";
			radioButton_gotopik_aftersmtdone.UseVisualStyleBackColor = true;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("黑体", 11f);
			label13.Location = new System.Drawing.Point(58, 58);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(119, 15);
			label13.TabIndex = 6;
			label13.Text = "贴完一块板之后";
			label_gotodefinexy_aftersmtdone.BackColor = System.Drawing.Color.White;
			label_gotodefinexy_aftersmtdone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_gotodefinexy_aftersmtdone.Enabled = false;
			label_gotodefinexy_aftersmtdone.Location = new System.Drawing.Point(41, 158);
			label_gotodefinexy_aftersmtdone.Name = "label_gotodefinexy_aftersmtdone";
			label_gotodefinexy_aftersmtdone.Size = new System.Drawing.Size(58, 32);
			label_gotodefinexy_aftersmtdone.TabIndex = 1;
			label_gotodefinexy_aftersmtdone.Text = "X00000\r\nY00000";
			label_gotodefinexy_aftersmtdone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_afteryouxian_gotomark1.AutoSize = true;
			checkBox_afteryouxian_gotomark1.Location = new System.Drawing.Point(9, 30);
			checkBox_afteryouxian_gotomark1.Name = "checkBox_afteryouxian_gotomark1";
			checkBox_afteryouxian_gotomark1.Size = new System.Drawing.Size(229, 18);
			checkBox_afteryouxian_gotomark1.TabIndex = 181;
			checkBox_afteryouxian_gotomark1.Text = "提前取料或视觉后，定位到Mark1";
			checkBox_afteryouxian_gotomark1.UseVisualStyleBackColor = true;
			panel_marksetting.BackColor = System.Drawing.Color.White;
			panel_marksetting.Controls.Add(button_close_marksetting);
			panel_marksetting.Controls.Add(radioButton4);
			panel_marksetting.Controls.Add(radioButton3);
			panel_marksetting.Controls.Add(radioButton5);
			panel_marksetting.Controls.Add(radioButton6);
			panel_marksetting.Controls.Add(checkBox_AutoFail_ToManual);
			panel_marksetting.Controls.Add(checkBox_Memory_Mark);
			panel_marksetting.Controls.Add(checkBox_No_Mark);
			panel_marksetting.Controls.Add(label6);
			panel_marksetting.Font = new System.Drawing.Font("黑体", 10f);
			panel_marksetting.ForeColor = System.Drawing.Color.Black;
			panel_marksetting.Location = new System.Drawing.Point(274, 142);
			panel_marksetting.Name = "panel_marksetting";
			panel_marksetting.Size = new System.Drawing.Size(431, 197);
			panel_marksetting.TabIndex = 10;
			panel_marksetting.Visible = false;
			radioButton4.AutoSize = true;
			radioButton4.Checked = true;
			radioButton4.Location = new System.Drawing.Point(8, 77);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(277, 18);
			radioButton4.TabIndex = 3;
			radioButton4.TabStop = true;
			radioButton4.Text = "Mark失败，结束当前板组，并退出全自动\r\n";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Enabled = false;
			radioButton3.Location = new System.Drawing.Point(8, 95);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(277, 18);
			radioButton3.TabIndex = 3;
			radioButton3.Text = "Mark失败，跳过当前板组，并继续全自动\r\n";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton5.AutoSize = true;
			radioButton5.Location = new System.Drawing.Point(8, 130);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(410, 18);
			radioButton5.TabIndex = 3;
			radioButton5.Text = "Mark失败，跳过当前子PCB，继续完成当前板组，并继续全自动\r\n";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton6.AutoSize = true;
			radioButton6.Location = new System.Drawing.Point(8, 112);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new System.Drawing.Size(410, 18);
			radioButton6.TabIndex = 3;
			radioButton6.Text = "Mark失败，跳过当前子PCB，继续完成当前板组，并退出全自动\r\n";
			radioButton6.UseVisualStyleBackColor = true;
			checkBox_AutoFail_ToManual.AutoSize = true;
			checkBox_AutoFail_ToManual.Location = new System.Drawing.Point(8, 35);
			checkBox_AutoFail_ToManual.Name = "checkBox_AutoFail_ToManual";
			checkBox_AutoFail_ToManual.Size = new System.Drawing.Size(208, 18);
			checkBox_AutoFail_ToManual.TabIndex = 8;
			checkBox_AutoFail_ToManual.Text = "自动Mark失败就立即手动Mark";
			checkBox_AutoFail_ToManual.UseVisualStyleBackColor = true;
			checkBox_Memory_Mark.AutoSize = true;
			checkBox_Memory_Mark.Location = new System.Drawing.Point(8, 55);
			checkBox_Memory_Mark.Name = "checkBox_Memory_Mark";
			checkBox_Memory_Mark.Size = new System.Drawing.Size(110, 18);
			checkBox_Memory_Mark.TabIndex = 9;
			checkBox_Memory_Mark.Text = "全自动时记忆";
			checkBox_Memory_Mark.UseVisualStyleBackColor = true;
			checkBox_Memory_Mark.Visible = false;
			checkBox_No_Mark.AutoSize = true;
			checkBox_No_Mark.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			checkBox_No_Mark.Location = new System.Drawing.Point(8, 167);
			checkBox_No_Mark.Name = "checkBox_No_Mark";
			checkBox_No_Mark.Size = new System.Drawing.Size(166, 18);
			checkBox_No_Mark.TabIndex = 7;
			checkBox_No_Mark.Text = "不用Mark（谨慎修改）";
			checkBox_No_Mark.UseVisualStyleBackColor = true;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label6.Location = new System.Drawing.Point(138, 11);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(119, 14);
			label6.TabIndex = 6;
			label6.Text = "MARK规则高级配置";
			checkBox_gen0_raisespeed.AutoSize = true;
			checkBox_gen0_raisespeed.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_gen0_raisespeed.ForeColor = System.Drawing.Color.White;
			checkBox_gen0_raisespeed.Location = new System.Drawing.Point(12, 237);
			checkBox_gen0_raisespeed.Name = "checkBox_gen0_raisespeed";
			checkBox_gen0_raisespeed.Size = new System.Drawing.Size(130, 19);
			checkBox_gen0_raisespeed.TabIndex = 180;
			checkBox_gen0_raisespeed.Text = "T系列机型提速";
			checkBox_gen0_raisespeed.UseVisualStyleBackColor = true;
			checkBox_gen0_raisespeed.Visible = false;
			label3.BackColor = System.Drawing.Color.White;
			label3.Location = new System.Drawing.Point(0, -2);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(720, 6);
			label3.TabIndex = 189;
			label12.BackColor = System.Drawing.Color.Red;
			label12.Location = new System.Drawing.Point(6, 36);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(227, 6);
			label12.TabIndex = 186;
			checkBox_youxian_pik.AutoSize = true;
			checkBox_youxian_pik.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_youxian_pik.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			checkBox_youxian_pik.Location = new System.Drawing.Point(12, 142);
			checkBox_youxian_pik.Name = "checkBox_youxian_pik";
			checkBox_youxian_pik.Size = new System.Drawing.Size(218, 19);
			checkBox_youxian_pik.TabIndex = 3;
			checkBox_youxian_pik.Text = "提前取料（全自动运行时）";
			checkBox_youxian_pik.UseVisualStyleBackColor = true;
			checkBox_preparevacuum_veryearly.AutoSize = true;
			checkBox_preparevacuum_veryearly.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_preparevacuum_veryearly.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			checkBox_preparevacuum_veryearly.Location = new System.Drawing.Point(12, 124);
			checkBox_preparevacuum_veryearly.Name = "checkBox_preparevacuum_veryearly";
			checkBox_preparevacuum_veryearly.Size = new System.Drawing.Size(170, 19);
			checkBox_preparevacuum_veryearly.TabIndex = 182;
			checkBox_preparevacuum_veryearly.Text = "取料时，超前备真空";
			checkBox_preparevacuum_veryearly.UseVisualStyleBackColor = true;
			panel4.BackColor = System.Drawing.Color.White;
			panel4.Controls.Add(radioButton_prjmode1);
			panel4.Controls.Add(radioButton_prjmode0);
			panel4.Controls.Add(label2);
			panel4.Font = new System.Drawing.Font("黑体", 11f);
			panel4.Location = new System.Drawing.Point(12, 260);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(209, 73);
			panel4.TabIndex = 179;
			radioButton_prjmode1.AutoSize = true;
			radioButton_prjmode1.Font = new System.Drawing.Font("黑体", 11f);
			radioButton_prjmode1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			radioButton_prjmode1.Location = new System.Drawing.Point(19, 42);
			radioButton_prjmode1.Name = "radioButton_prjmode1";
			radioButton_prjmode1.Size = new System.Drawing.Size(145, 19);
			radioButton_prjmode1.TabIndex = 180;
			radioButton_prjmode1.Text = "多种PCB板组模式";
			radioButton_prjmode1.UseVisualStyleBackColor = true;
			radioButton_prjmode0.AutoSize = true;
			radioButton_prjmode0.Checked = true;
			radioButton_prjmode0.Font = new System.Drawing.Font("黑体", 11f);
			radioButton_prjmode0.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			radioButton_prjmode0.Location = new System.Drawing.Point(19, 24);
			radioButton_prjmode0.Name = "radioButton_prjmode0";
			radioButton_prjmode0.Size = new System.Drawing.Size(129, 19);
			radioButton_prjmode0.TabIndex = 180;
			radioButton_prjmode0.TabStop = true;
			radioButton_prjmode0.Text = "单种PCB板模式";
			radioButton_prjmode0.UseVisualStyleBackColor = true;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 11f);
			label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label2.Location = new System.Drawing.Point(3, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(167, 15);
			label2.TabIndex = 6;
			label2.Text = "工程模式（谨慎修改）";
			panel_safespace.Controls.Add(pictureBox2);
			panel_safespace.Controls.Add(numericUpDown_safespace);
			panel_safespace.Controls.Add(label123);
			panel_safespace.Controls.Add(label122);
			panel_safespace.Location = new System.Drawing.Point(274, 200);
			panel_safespace.Name = "panel_safespace";
			panel_safespace.Size = new System.Drawing.Size(315, 134);
			panel_safespace.TabIndex = 177;
			pictureBox2.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox2.Image = QIGN_COMMON.Properties.Resources.SAFE_SPACE;
			pictureBox2.Location = new System.Drawing.Point(3, 3);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(124, 128);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 170;
			pictureBox2.TabStop = false;
			numericUpDown_safespace.DecimalPlaces = 1;
			numericUpDown_safespace.Font = new System.Drawing.Font("楷体", 10.5f);
			numericUpDown_safespace.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
			numericUpDown_safespace.Location = new System.Drawing.Point(132, 104);
			numericUpDown_safespace.Maximum = new decimal(new int[4] { 25, 0, 0, 0 });
			numericUpDown_safespace.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
			numericUpDown_safespace.Name = "numericUpDown_safespace";
			numericUpDown_safespace.Size = new System.Drawing.Size(57, 23);
			numericUpDown_safespace.TabIndex = 169;
			numericUpDown_safespace.Value = new decimal(new int[4] { 2, 0, 0, 0 });
			label123.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			label123.Font = new System.Drawing.Font("黑体", 10.5f);
			label123.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			label123.Location = new System.Drawing.Point(130, 5);
			label123.Name = "label123";
			label123.Size = new System.Drawing.Size(176, 62);
			label123.TabIndex = 167;
			label123.Text = "请务必正确填写基准高度，\r\n相机高度，元件厚度等，\r\n综合考虑贴装情况，来设置\r\n\"贴装安全间隙\"";
			label122.AutoSize = true;
			label122.Font = new System.Drawing.Font("黑体", 11.25f);
			label122.ForeColor = System.Drawing.Color.White;
			label122.Location = new System.Drawing.Point(128, 82);
			label122.Name = "label122";
			label122.Size = new System.Drawing.Size(135, 15);
			label122.TabIndex = 167;
			label122.Text = "贴装安全间隙(mm)";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("黑体", 15f);
			label7.Location = new System.Drawing.Point(77, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(89, 20);
			label7.TabIndex = 1;
			label7.Text = "生产设置\r\n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel1.Controls.Add(radioButton1);
			panel1.Controls.Add(radioButton_visualfailretry_afterfinish);
			panel1.Controls.Add(radioButton_visualfailretry_rightnow);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(numericUpDown_failretryNum);
			panel1.Font = new System.Drawing.Font("黑体", 10.5f);
			panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			panel1.Location = new System.Drawing.Point(274, 37);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(410, 58);
			panel1.TabIndex = 4;
			radioButton1.AutoSize = true;
			radioButton1.Enabled = false;
			radioButton1.Location = new System.Drawing.Point(3, 39);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(291, 18);
			radioButton1.TabIndex = 0;
			radioButton1.Text = "元件识别失败，从多组供料的其他料站取料";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton1.Visible = false;
			radioButton_visualfailretry_afterfinish.AutoSize = true;
			radioButton_visualfailretry_afterfinish.Enabled = false;
			radioButton_visualfailretry_afterfinish.Location = new System.Drawing.Point(3, 22);
			radioButton_visualfailretry_afterfinish.Name = "radioButton_visualfailretry_afterfinish";
			radioButton_visualfailretry_afterfinish.Size = new System.Drawing.Size(284, 18);
			radioButton_visualfailretry_afterfinish.TabIndex = 0;
			radioButton_visualfailretry_afterfinish.Text = "元件识别失败，完成单PCB贴装后统一补料";
			radioButton_visualfailretry_afterfinish.UseVisualStyleBackColor = true;
			radioButton_visualfailretry_rightnow.AutoSize = true;
			radioButton_visualfailretry_rightnow.Checked = true;
			radioButton_visualfailretry_rightnow.Location = new System.Drawing.Point(3, 4);
			radioButton_visualfailretry_rightnow.Name = "radioButton_visualfailretry_rightnow";
			radioButton_visualfailretry_rightnow.Size = new System.Drawing.Size(207, 18);
			radioButton_visualfailretry_rightnow.TabIndex = 0;
			radioButton_visualfailretry_rightnow.TabStop = true;
			radioButton_visualfailretry_rightnow.Text = "元件识别失败，立即抛料重取";
			radioButton_visualfailretry_rightnow.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(253, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(63, 14);
			label1.TabIndex = 1;
			label1.Text = "重取次数";
			numericUpDown_failretryNum.Location = new System.Drawing.Point(328, 0);
			numericUpDown_failretryNum.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_failretryNum.Name = "numericUpDown_failretryNum";
			numericUpDown_failretryNum.Size = new System.Drawing.Size(45, 23);
			numericUpDown_failretryNum.TabIndex = 2;
			numericUpDown_failretryNum.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			checkBox5.AutoSize = true;
			checkBox5.Font = new System.Drawing.Font("黑体", 11f);
			checkBox5.ForeColor = System.Drawing.Color.White;
			checkBox5.Location = new System.Drawing.Point(12, 199);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(170, 19);
			checkBox5.TabIndex = 3;
			checkBox5.Text = "高阶闭环，人工干预";
			checkBox5.UseVisualStyleBackColor = true;
			checkBox5.Visible = false;
			checkBox_ischeckNozzle.AutoSize = true;
			checkBox_ischeckNozzle.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_ischeckNozzle.ForeColor = System.Drawing.Color.White;
			checkBox_ischeckNozzle.Location = new System.Drawing.Point(12, 218);
			checkBox_ischeckNozzle.Name = "checkBox_ischeckNozzle";
			checkBox_ischeckNozzle.Size = new System.Drawing.Size(154, 19);
			checkBox_ischeckNozzle.TabIndex = 3;
			checkBox_ischeckNozzle.Text = "吸嘴异物检测报警";
			checkBox_ischeckNozzle.UseVisualStyleBackColor = true;
			checkBox_ischeckNozzle.Visible = false;
			checkBox_Loukong.AutoSize = true;
			checkBox_Loukong.Font = new System.Drawing.Font("黑体", 11f);
			checkBox_Loukong.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			checkBox_Loukong.Location = new System.Drawing.Point(12, 106);
			checkBox_Loukong.Name = "checkBox_Loukong";
			checkBox_Loukong.Size = new System.Drawing.Size(74, 19);
			checkBox_Loukong.TabIndex = 3;
			checkBox_Loukong.Text = "镂空板";
			checkBox_Loukong.UseVisualStyleBackColor = true;
			panel_smtinfo.Controls.Add(textBox_infolog);
			panel_smtinfo.Controls.Add(button_throwrate_check);
			panel_smtinfo.Controls.Add(button_Infologfile_browse);
			panel_smtinfo.Controls.Add(button_info_clear);
			panel_smtinfo.Controls.Add(panel6);
			panel_smtinfo.Controls.Add(checkBox_onlyAutoMode);
			panel_smtinfo.Controls.Add(label114);
			panel_smtinfo.Controls.Add(label10);
			panel_smtinfo.Controls.Add(label91);
			panel_smtinfo.Controls.Add(label_infodate);
			panel_smtinfo.Controls.Add(label_infocycletime);
			panel_smtinfo.Controls.Add(label_infototalpcbs);
			panel_smtinfo.Controls.Add(label112);
			panel_smtinfo.Controls.Add(label14);
			panel_smtinfo.Font = new System.Drawing.Font("黑体", 9f);
			panel_smtinfo.Location = new System.Drawing.Point(740, 279);
			panel_smtinfo.Name = "panel_smtinfo";
			panel_smtinfo.Size = new System.Drawing.Size(717, 673);
			panel_smtinfo.TabIndex = 191;
			textBox_infolog.Font = new System.Drawing.Font("黑体", 10f);
			textBox_infolog.Location = new System.Drawing.Point(86, 515);
			textBox_infolog.Name = "textBox_infolog";
			textBox_infolog.Size = new System.Drawing.Size(499, 23);
			textBox_infolog.TabIndex = 12;
			panel6.Controls.Add(label104);
			panel6.Controls.Add(label11);
			panel6.Controls.Add(label_infototalexceptions);
			panel6.Controls.Add(label4);
			panel6.Controls.Add(label_infototaldroprate);
			panel6.Controls.Add(label9);
			panel6.Controls.Add(label_infototalnones);
			panel6.Controls.Add(label5);
			panel6.Controls.Add(label_infototaldrops);
			panel6.Controls.Add(label8);
			panel6.Controls.Add(label_infototalchips);
			panel6.Location = new System.Drawing.Point(14, 138);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(700, 320);
			panel6.TabIndex = 10;
			label104.BackColor = System.Drawing.Color.Moccasin;
			label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label104.Font = new System.Drawing.Font("黑体", 10.5f);
			label104.Location = new System.Drawing.Point(0, 0);
			label104.Name = "label104";
			label104.Size = new System.Drawing.Size(70, 26);
			label104.TabIndex = 5;
			label104.Text = "总计";
			label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("黑体", 10.5f);
			label11.Location = new System.Drawing.Point(460, 6);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(35, 14);
			label11.TabIndex = 0;
			label11.Text = "异常";
			label11.Visible = false;
			label_infototalexceptions.BackColor = System.Drawing.Color.Snow;
			label_infototalexceptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_infototalexceptions.Font = new System.Drawing.Font("楷体", 10.5f);
			label_infototalexceptions.Location = new System.Drawing.Point(518, 0);
			label_infototalexceptions.Name = "label_infototalexceptions";
			label_infototalexceptions.Size = new System.Drawing.Size(59, 26);
			label_infototalexceptions.TabIndex = 3;
			label_infototalexceptions.Text = "0";
			label_infototalexceptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_infototalexceptions.Visible = false;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("黑体", 10.5f);
			label4.Location = new System.Drawing.Point(316, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(49, 14);
			label4.TabIndex = 0;
			label4.Text = "抛料率";
			label_infototaldroprate.BackColor = System.Drawing.Color.Snow;
			label_infototaldroprate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_infototaldroprate.Font = new System.Drawing.Font("楷体", 10.5f);
			label_infototaldroprate.Location = new System.Drawing.Point(376, 0);
			label_infototaldroprate.Name = "label_infototaldroprate";
			label_infototaldroprate.Size = new System.Drawing.Size(74, 26);
			label_infototaldroprate.TabIndex = 3;
			label_infototaldroprate.Text = "0";
			label_infototaldroprate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("黑体", 10.5f);
			label9.Location = new System.Drawing.Point(598, 6);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(35, 14);
			label9.TabIndex = 0;
			label9.Text = "空取";
			label9.Visible = false;
			label_infototalnones.BackColor = System.Drawing.Color.Snow;
			label_infototalnones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_infototalnones.Font = new System.Drawing.Font("楷体", 10.5f);
			label_infototalnones.Location = new System.Drawing.Point(634, 0);
			label_infototalnones.Name = "label_infototalnones";
			label_infototalnones.Size = new System.Drawing.Size(64, 26);
			label_infototalnones.TabIndex = 3;
			label_infototalnones.Text = "0";
			label_infototalnones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_infototalnones.Visible = false;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("黑体", 10.5f);
			label5.Location = new System.Drawing.Point(210, 6);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(35, 14);
			label5.TabIndex = 0;
			label5.Text = "抛料";
			label_infototaldrops.BackColor = System.Drawing.Color.Snow;
			label_infototaldrops.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_infototaldrops.Font = new System.Drawing.Font("楷体", 10.5f);
			label_infototaldrops.Location = new System.Drawing.Point(246, 0);
			label_infototaldrops.Name = "label_infototaldrops";
			label_infototaldrops.Size = new System.Drawing.Size(64, 26);
			label_infototaldrops.TabIndex = 3;
			label_infototaldrops.Text = "0";
			label_infototaldrops.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("黑体", 10.5f);
			label8.Location = new System.Drawing.Point(76, 6);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(63, 14);
			label8.TabIndex = 0;
			label8.Text = "贴片数量";
			label_infototalchips.BackColor = System.Drawing.Color.Snow;
			label_infototalchips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_infototalchips.Font = new System.Drawing.Font("楷体", 10.5f);
			label_infototalchips.Location = new System.Drawing.Point(140, 0);
			label_infototalchips.Name = "label_infototalchips";
			label_infototalchips.Size = new System.Drawing.Size(64, 26);
			label_infototalchips.TabIndex = 3;
			label_infototalchips.Text = "0";
			label_infototalchips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBox_onlyAutoMode.AutoSize = true;
			checkBox_onlyAutoMode.Checked = true;
			checkBox_onlyAutoMode.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_onlyAutoMode.Font = new System.Drawing.Font("黑体", 11.5f);
			checkBox_onlyAutoMode.Location = new System.Drawing.Point(260, 99);
			checkBox_onlyAutoMode.Name = "checkBox_onlyAutoMode";
			checkBox_onlyAutoMode.Size = new System.Drawing.Size(155, 20);
			checkBox_onlyAutoMode.TabIndex = 9;
			checkBox_onlyAutoMode.Text = "是否只统计全自动";
			checkBox_onlyAutoMode.UseVisualStyleBackColor = true;
			checkBox_onlyAutoMode.CheckedChanged += new System.EventHandler(checkBox_onlyAutoMode_CheckedChanged);
			label114.BackColor = System.Drawing.Color.NavajoWhite;
			label114.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label114.Font = new System.Drawing.Font("黑体", 10.5f);
			label114.Location = new System.Drawing.Point(13, 66);
			label114.Name = "label114";
			label114.Size = new System.Drawing.Size(70, 26);
			label114.TabIndex = 7;
			label114.Text = "单板时间";
			label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label10.BackColor = System.Drawing.Color.NavajoWhite;
			label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label10.Font = new System.Drawing.Font("黑体", 10.5f);
			label10.Location = new System.Drawing.Point(14, 515);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(70, 23);
			label10.TabIndex = 8;
			label10.Text = "贴装日志";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label91.BackColor = System.Drawing.Color.NavajoWhite;
			label91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label91.Font = new System.Drawing.Font("黑体", 10.5f);
			label91.Location = new System.Drawing.Point(13, 94);
			label91.Name = "label91";
			label91.Size = new System.Drawing.Size(70, 26);
			label91.TabIndex = 8;
			label91.Text = "贴板总数";
			label91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_infodate.BackColor = System.Drawing.Color.Snow;
			label_infodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_infodate.Font = new System.Drawing.Font("楷体", 10.5f);
			label_infodate.Location = new System.Drawing.Point(85, 38);
			label_infodate.Name = "label_infodate";
			label_infodate.Size = new System.Drawing.Size(162, 26);
			label_infodate.TabIndex = 6;
			label_infodate.Text = "0";
			label_infodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_infocycletime.BackColor = System.Drawing.Color.Snow;
			label_infocycletime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_infocycletime.Font = new System.Drawing.Font("楷体", 10.5f);
			label_infocycletime.Location = new System.Drawing.Point(85, 66);
			label_infocycletime.Name = "label_infocycletime";
			label_infocycletime.Size = new System.Drawing.Size(162, 26);
			label_infocycletime.TabIndex = 4;
			label_infocycletime.Text = "0";
			label_infocycletime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label_infototalpcbs.BackColor = System.Drawing.Color.Snow;
			label_infototalpcbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_infototalpcbs.Font = new System.Drawing.Font("楷体", 10.5f);
			label_infototalpcbs.Location = new System.Drawing.Point(85, 94);
			label_infototalpcbs.Name = "label_infototalpcbs";
			label_infototalpcbs.Size = new System.Drawing.Size(162, 26);
			label_infototalpcbs.TabIndex = 3;
			label_infototalpcbs.Text = "0";
			label_infototalpcbs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label112.BackColor = System.Drawing.Color.NavajoWhite;
			label112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label112.Font = new System.Drawing.Font("黑体", 10.5f);
			label112.Location = new System.Drawing.Point(13, 38);
			label112.Name = "label112";
			label112.Size = new System.Drawing.Size(70, 26);
			label112.TabIndex = 2;
			label112.Text = "生产日期";
			label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("黑体", 12f);
			label14.Location = new System.Drawing.Point(267, 66);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(72, 16);
			label14.TabIndex = 0;
			label14.Text = "生产信息";
			label14.Visible = false;
			label_smtloopmode.BackColor = System.Drawing.SystemColors.Control;
			label_smtloopmode.Font = new System.Drawing.Font("黑体", 13f);
			label_smtloopmode.Location = new System.Drawing.Point(366, 1);
			label_smtloopmode.Name = "label_smtloopmode";
			label_smtloopmode.Size = new System.Drawing.Size(196, 30);
			label_smtloopmode.TabIndex = 192;
			label_smtloopmode.Text = "两段贴板模式";
			label_smtloopmode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_throwrate_check.BackColor = System.Drawing.Color.Silver;
			button_throwrate_check.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_throwrate_check.CnPressDownColor = System.Drawing.Color.Empty;
			button_throwrate_check.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_throwrate_check.Location = new System.Drawing.Point(106, 473);
			button_throwrate_check.Name = "button_throwrate_check";
			button_throwrate_check.Size = new System.Drawing.Size(86, 30);
			button_throwrate_check.TabIndex = 11;
			button_throwrate_check.Text = "详细信息";
			button_throwrate_check.UseVisualStyleBackColor = false;
			button_throwrate_check.Click += new System.EventHandler(button_throwrate_check_Click);
			button_Infologfile_browse.BackColor = System.Drawing.Color.Silver;
			button_Infologfile_browse.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_Infologfile_browse.CnPressDownColor = System.Drawing.Color.Empty;
			button_Infologfile_browse.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Infologfile_browse.Location = new System.Drawing.Point(591, 513);
			button_Infologfile_browse.Name = "button_Infologfile_browse";
			button_Infologfile_browse.Size = new System.Drawing.Size(80, 25);
			button_Infologfile_browse.TabIndex = 11;
			button_Infologfile_browse.Text = "浏览";
			button_Infologfile_browse.UseVisualStyleBackColor = false;
			button_Infologfile_browse.Click += new System.EventHandler(button_Infologfile_browse_Click);
			button_info_clear.BackColor = System.Drawing.Color.Silver;
			button_info_clear.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_info_clear.CnPressDownColor = System.Drawing.Color.Empty;
			button_info_clear.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_info_clear.Location = new System.Drawing.Point(14, 473);
			button_info_clear.Name = "button_info_clear";
			button_info_clear.Size = new System.Drawing.Size(86, 30);
			button_info_clear.TabIndex = 11;
			button_info_clear.Text = "计数清零";
			button_info_clear.UseVisualStyleBackColor = false;
			button_info_clear.Click += new System.EventHandler(button_info_clear_Click);
			button_close_youxianpik.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_youxianpik.CnPressDownColor = System.Drawing.Color.White;
			button_close_youxianpik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button_close_youxianpik.Location = new System.Drawing.Point(230, 2);
			button_close_youxianpik.Name = "button_close_youxianpik";
			button_close_youxianpik.Size = new System.Drawing.Size(30, 30);
			button_close_youxianpik.TabIndex = 189;
			button_close_youxianpik.Text = "X";
			button_close_youxianpik.UseVisualStyleBackColor = true;
			button_gotodefinexy_Save.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_gotodefinexy_Save.CnPressDownColor = System.Drawing.Color.White;
			button_gotodefinexy_Save.Enabled = false;
			button_gotodefinexy_Save.Location = new System.Drawing.Point(103, 158);
			button_gotodefinexy_Save.Name = "button_gotodefinexy_Save";
			button_gotodefinexy_Save.Size = new System.Drawing.Size(45, 32);
			button_gotodefinexy_Save.TabIndex = 0;
			button_gotodefinexy_Save.Text = "保存";
			button_gotodefinexy_Save.UseVisualStyleBackColor = true;
			button_gotodefinexy_Goto.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_gotodefinexy_Goto.CnPressDownColor = System.Drawing.Color.White;
			button_gotodefinexy_Goto.Enabled = false;
			button_gotodefinexy_Goto.Location = new System.Drawing.Point(149, 158);
			button_gotodefinexy_Goto.Name = "button_gotodefinexy_Goto";
			button_gotodefinexy_Goto.Size = new System.Drawing.Size(45, 32);
			button_gotodefinexy_Goto.TabIndex = 0;
			button_gotodefinexy_Goto.Text = "定位";
			button_gotodefinexy_Goto.UseVisualStyleBackColor = true;
			button_close_marksetting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close_marksetting.CnPressDownColor = System.Drawing.Color.White;
			button_close_marksetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button_close_marksetting.Location = new System.Drawing.Point(388, 4);
			button_close_marksetting.Name = "button_close_marksetting";
			button_close_marksetting.Size = new System.Drawing.Size(30, 30);
			button_close_marksetting.TabIndex = 189;
			button_close_marksetting.Text = "X";
			button_close_marksetting.UseVisualStyleBackColor = true;
			button_marksetting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_marksetting.CnPressDownColor = System.Drawing.Color.White;
			button_marksetting.Font = new System.Drawing.Font("黑体", 11f);
			button_marksetting.ForeColor = System.Drawing.Color.Black;
			button_marksetting.Location = new System.Drawing.Point(277, 100);
			button_marksetting.Name = "button_marksetting";
			button_marksetting.Size = new System.Drawing.Size(189, 31);
			button_marksetting.TabIndex = 188;
			button_marksetting.Text = "MARK规则高级配置";
			button_marksetting.UseVisualStyleBackColor = true;
			button_youxian_pik.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_youxian_pik.CnPressDownColor = System.Drawing.Color.White;
			button_youxian_pik.Font = new System.Drawing.Font("黑体", 11f);
			button_youxian_pik.ForeColor = System.Drawing.Color.Black;
			button_youxian_pik.Location = new System.Drawing.Point(12, 163);
			button_youxian_pik.Name = "button_youxian_pik";
			button_youxian_pik.Size = new System.Drawing.Size(196, 31);
			button_youxian_pik.TabIndex = 187;
			button_youxian_pik.Text = "高级配置详情";
			button_youxian_pik.UseVisualStyleBackColor = true;
			button_StackIsMount.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_StackIsMount.CnPressDownColor = System.Drawing.Color.White;
			button_StackIsMount.Font = new System.Drawing.Font("黑体", 11.5f);
			button_StackIsMount.ForeColor = System.Drawing.Color.Black;
			button_StackIsMount.Location = new System.Drawing.Point(10, 45);
			button_StackIsMount.Name = "button_StackIsMount";
			button_StackIsMount.Size = new System.Drawing.Size(101, 50);
			button_StackIsMount.TabIndex = 0;
			button_StackIsMount.Text = "是否贴装";
			button_StackIsMount.UseVisualStyleBackColor = true;
			button_close.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_close.CnPressDownColor = System.Drawing.Color.White;
			button_close.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_close.ForeColor = System.Drawing.Color.Black;
			button_close.Location = new System.Drawing.Point(674, 3);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(28, 28);
			button_close.TabIndex = 0;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = true;
			button_SmtStackPlateStartNo.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SmtStackPlateStartNo.CnPressDownColor = System.Drawing.Color.White;
			button_SmtStackPlateStartNo.Font = new System.Drawing.Font("黑体", 11.5f);
			button_SmtStackPlateStartNo.ForeColor = System.Drawing.Color.Black;
			button_SmtStackPlateStartNo.Location = new System.Drawing.Point(121, 45);
			button_SmtStackPlateStartNo.Name = "button_SmtStackPlateStartNo";
			button_SmtStackPlateStartNo.Size = new System.Drawing.Size(101, 50);
			button_SmtStackPlateStartNo.TabIndex = 0;
			button_SmtStackPlateStartNo.Text = "料盘起始";
			button_SmtStackPlateStartNo.UseVisualStyleBackColor = true;
			button_openFeederPage_vsplus.BackColor = System.Drawing.SystemColors.ControlLight;
			button_openFeederPage_vsplus.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_openFeederPage_vsplus.CnPressDownColor = System.Drawing.Color.White;
			button_openFeederPage_vsplus.Font = new System.Drawing.Font("黑体", 11.5f);
			button_openFeederPage_vsplus.ForeColor = System.Drawing.Color.Black;
			button_openFeederPage_vsplus.Location = new System.Drawing.Point(605, 3);
			button_openFeederPage_vsplus.Name = "button_openFeederPage_vsplus";
			button_openFeederPage_vsplus.Size = new System.Drawing.Size(100, 28);
			button_openFeederPage_vsplus.TabIndex = 0;
			button_openFeederPage_vsplus.Text = "料站参数";
			button_openFeederPage_vsplus.UseVisualStyleBackColor = false;
			button_openFeederPage_vsplus.Click += new System.EventHandler(button_openFeederPage_vsplus_Click);
			button_subpcb_select.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_subpcb_select.CnPressDownColor = System.Drawing.Color.White;
			button_subpcb_select.Font = new System.Drawing.Font("黑体", 8f);
			button_subpcb_select.Location = new System.Drawing.Point(82, 4);
			button_subpcb_select.Name = "button_subpcb_select";
			button_subpcb_select.Size = new System.Drawing.Size(26, 26);
			button_subpcb_select.TabIndex = 1;
			button_subpcb_select.Text = "..";
			button_subpcb_select.UseVisualStyleBackColor = true;
			button_subpcb_select.Click += new System.EventHandler(button_subpcb_select_Click);
			button24.BackColor = System.Drawing.Color.Azure;
			button24.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button24.CnPressDownColor = System.Drawing.Color.White;
			button24.Font = new System.Drawing.Font("楷体", 10.5f);
			button24.Location = new System.Drawing.Point(147, 1);
			button24.Name = "button24";
			button24.Size = new System.Drawing.Size(50, 26);
			button24.TabIndex = 0;
			button24.Text = "PCB4";
			button24.UseVisualStyleBackColor = true;
			button18.BackColor = System.Drawing.Color.Azure;
			button18.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button18.CnPressDownColor = System.Drawing.Color.White;
			button18.Font = new System.Drawing.Font("楷体", 10.5f);
			button18.Location = new System.Drawing.Point(0, 1);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(50, 26);
			button18.TabIndex = 0;
			button18.Text = "PCB1";
			button18.UseVisualStyleBackColor = true;
			button22.BackColor = System.Drawing.Color.Azure;
			button22.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button22.CnPressDownColor = System.Drawing.Color.White;
			button22.Font = new System.Drawing.Font("楷体", 10.5f);
			button22.Location = new System.Drawing.Point(566, 0);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(43, 26);
			button22.TabIndex = 0;
			button22.Text = "……";
			button22.UseVisualStyleBackColor = true;
			button17.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
			button17.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button17.CnPressDownColor = System.Drawing.Color.White;
			button17.Font = new System.Drawing.Font("楷体", 10.5f);
			button17.Location = new System.Drawing.Point(98, 1);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(50, 26);
			button17.TabIndex = 0;
			button17.Text = "PCB3";
			button17.UseVisualStyleBackColor = false;
			button20.BackColor = System.Drawing.Color.Azure;
			button20.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button20.CnPressDownColor = System.Drawing.Color.White;
			button20.Font = new System.Drawing.Font("楷体", 10.5f);
			button20.Location = new System.Drawing.Point(196, 1);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(50, 26);
			button20.TabIndex = 0;
			button20.Text = "PCB5";
			button20.UseVisualStyleBackColor = true;
			button16.BackColor = System.Drawing.Color.Azure;
			button16.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button16.CnPressDownColor = System.Drawing.Color.White;
			button16.Font = new System.Drawing.Font("楷体", 10.5f);
			button16.Location = new System.Drawing.Point(49, 1);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(50, 26);
			button16.TabIndex = 0;
			button16.Text = "PCB2";
			button16.UseVisualStyleBackColor = true;
			button_del_subpcb.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_del_subpcb.CnPressDownColor = System.Drawing.Color.White;
			button_del_subpcb.Font = new System.Drawing.Font("楷体", 14f);
			button_del_subpcb.Location = new System.Drawing.Point(30, 4);
			button_del_subpcb.Name = "button_del_subpcb";
			button_del_subpcb.Size = new System.Drawing.Size(26, 26);
			button_del_subpcb.TabIndex = 0;
			button_del_subpcb.Text = "-";
			button_del_subpcb.UseVisualStyleBackColor = true;
			button_del_subpcb.Click += new System.EventHandler(button_del_subpcb_Click);
			button_subpcb_setting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_subpcb_setting.CnPressDownColor = System.Drawing.Color.White;
			button_subpcb_setting.Font = new System.Drawing.Font("楷体", 14f);
			button_subpcb_setting.Location = new System.Drawing.Point(56, 4);
			button_subpcb_setting.Name = "button_subpcb_setting";
			button_subpcb_setting.Size = new System.Drawing.Size(26, 26);
			button_subpcb_setting.TabIndex = 0;
			button_subpcb_setting.Text = "♜";
			button_subpcb_setting.UseVisualStyleBackColor = true;
			button_subpcb_setting.Click += new System.EventHandler(button_subpcb_setting_Click);
			button_add_subpcb.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_add_subpcb.CnPressDownColor = System.Drawing.Color.White;
			button_add_subpcb.Font = new System.Drawing.Font("楷体", 14f);
			button_add_subpcb.Location = new System.Drawing.Point(4, 4);
			button_add_subpcb.Name = "button_add_subpcb";
			button_add_subpcb.Size = new System.Drawing.Size(26, 26);
			button_add_subpcb.TabIndex = 0;
			button_add_subpcb.Text = "+";
			button_add_subpcb.UseVisualStyleBackColor = true;
			button_add_subpcb.Click += new System.EventHandler(button_add_subpcb_Click);
			button_smtTest.BackColor = System.Drawing.SystemColors.ControlLight;
			button_smtTest.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_smtTest.CnPressDownColor = System.Drawing.Color.White;
			button_smtTest.Font = new System.Drawing.Font("黑体", 12f);
			button_smtTest.ForeColor = System.Drawing.Color.Black;
			button_smtTest.Location = new System.Drawing.Point(602, 9);
			button_smtTest.Name = "button_smtTest";
			button_smtTest.Size = new System.Drawing.Size(100, 32);
			button_smtTest.TabIndex = 18;
			button_smtTest.Text = "贴装生产";
			button_smtTest.UseVisualStyleBackColor = false;
			button_smtTest.Click += new System.EventHandler(button_smtTest_Click);
			button_PCBE_feeder.BackColor = System.Drawing.SystemColors.ControlLight;
			button_PCBE_feeder.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PCBE_feeder.CnPressDownColor = System.Drawing.Color.White;
			button_PCBE_feeder.Font = new System.Drawing.Font("黑体", 12f);
			button_PCBE_feeder.ForeColor = System.Drawing.Color.Black;
			button_PCBE_feeder.Location = new System.Drawing.Point(246, 9);
			button_PCBE_feeder.Name = "button_PCBE_feeder";
			button_PCBE_feeder.Size = new System.Drawing.Size(100, 32);
			button_PCBE_feeder.TabIndex = 0;
			button_PCBE_feeder.Text = "飞达安装";
			button_PCBE_feeder.UseVisualStyleBackColor = false;
			button_PCBE_feeder.Click += new System.EventHandler(button_PCBE_feeder_Click);
			button_goto_PCBEdit.BackColor = System.Drawing.SystemColors.ControlLight;
			button_goto_PCBEdit.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_goto_PCBEdit.CnPressDownColor = System.Drawing.Color.White;
			button_goto_PCBEdit.Font = new System.Drawing.Font("黑体", 12f);
			button_goto_PCBEdit.ForeColor = System.Drawing.Color.Black;
			button_goto_PCBEdit.Location = new System.Drawing.Point(11, 9);
			button_goto_PCBEdit.Name = "button_goto_PCBEdit";
			button_goto_PCBEdit.Size = new System.Drawing.Size(100, 32);
			button_goto_PCBEdit.TabIndex = 17;
			button_goto_PCBEdit.Text = "PCB编辑\r\n";
			button_goto_PCBEdit.UseVisualStyleBackColor = false;
			button_goto_PCBEdit.Click += new System.EventHandler(button_goto_PCBEdit_Click);
			button_Legal.BackColor = System.Drawing.SystemColors.ControlLight;
			button_Legal.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_Legal.CnPressDownColor = System.Drawing.Color.White;
			button_Legal.Font = new System.Drawing.Font("黑体", 12f);
			button_Legal.ForeColor = System.Drawing.Color.Black;
			button_Legal.Location = new System.Drawing.Point(483, 9);
			button_Legal.Name = "button_Legal";
			button_Legal.Size = new System.Drawing.Size(100, 32);
			button_Legal.TabIndex = 16;
			button_Legal.Text = "诊断检测";
			button_Legal.UseVisualStyleBackColor = false;
			button_Legal.Click += new System.EventHandler(button_Legal_Click);
			button_openFeederPage.BackColor = System.Drawing.SystemColors.ControlLight;
			button_openFeederPage.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_openFeederPage.CnPressDownColor = System.Drawing.Color.White;
			button_openFeederPage.Font = new System.Drawing.Font("黑体", 12f);
			button_openFeederPage.ForeColor = System.Drawing.Color.Black;
			button_openFeederPage.Location = new System.Drawing.Point(364, 9);
			button_openFeederPage.Name = "button_openFeederPage";
			button_openFeederPage.Size = new System.Drawing.Size(100, 32);
			button_openFeederPage.TabIndex = 0;
			button_openFeederPage.Text = "料站参数";
			button_openFeederPage.UseVisualStyleBackColor = false;
			button_openFeederPage.Click += new System.EventHandler(button_openFeederPage_Click);
			button_Cat.BackColor = System.Drawing.SystemColors.ControlLight;
			button_Cat.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_Cat.CnPressDownColor = System.Drawing.Color.White;
			button_Cat.Font = new System.Drawing.Font("黑体", 12f);
			button_Cat.ForeColor = System.Drawing.Color.Black;
			button_Cat.Location = new System.Drawing.Point(129, 9);
			button_Cat.Name = "button_Cat";
			button_Cat.Size = new System.Drawing.Size(100, 32);
			button_Cat.TabIndex = 11;
			button_Cat.Text = "分类优化";
			button_Cat.UseVisualStyleBackColor = false;
			button_Cat.Click += new System.EventHandler(button_Cat_Click);
			button_vsplus_startsmt.BackColor = System.Drawing.SystemColors.ControlLight;
			button_vsplus_startsmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_vsplus_startsmt.CnPressDownColor = System.Drawing.Color.White;
			button_vsplus_startsmt.Font = new System.Drawing.Font("黑体", 14f);
			button_vsplus_startsmt.Location = new System.Drawing.Point(263, 87);
			button_vsplus_startsmt.Name = "button_vsplus_startsmt";
			button_vsplus_startsmt.Size = new System.Drawing.Size(180, 51);
			button_vsplus_startsmt.TabIndex = 168;
			button_vsplus_startsmt.Text = "开始贴装";
			button_vsplus_startsmt.UseVisualStyleBackColor = false;
			button_vsplus_startsmt.Click += new System.EventHandler(button_vsplus_startsmt_Click);
			button_vsplus_startsmt2.BackColor = System.Drawing.Color.Salmon;
			button_vsplus_startsmt2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_vsplus_startsmt2.CnPressDownColor = System.Drawing.Color.White;
			button_vsplus_startsmt2.Font = new System.Drawing.Font("黑体", 13f);
			button_vsplus_startsmt2.Location = new System.Drawing.Point(263, 87);
			button_vsplus_startsmt2.Name = "button_vsplus_startsmt2";
			button_vsplus_startsmt2.Size = new System.Drawing.Size(84, 51);
			button_vsplus_startsmt2.TabIndex = 172;
			button_vsplus_startsmt2.Text = "开始\r\n贴装";
			button_vsplus_startsmt2.UseVisualStyleBackColor = false;
			button_vsplus_startsmt2.Click += new System.EventHandler(button_vsplus_startsmt_Click);
			button_vsplus_continuesmt.BackColor = System.Drawing.Color.Salmon;
			button_vsplus_continuesmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_vsplus_continuesmt.CnPressDownColor = System.Drawing.Color.White;
			button_vsplus_continuesmt.Font = new System.Drawing.Font("黑体", 13f);
			button_vsplus_continuesmt.Location = new System.Drawing.Point(359, 87);
			button_vsplus_continuesmt.Name = "button_vsplus_continuesmt";
			button_vsplus_continuesmt.Size = new System.Drawing.Size(84, 51);
			button_vsplus_continuesmt.TabIndex = 171;
			button_vsplus_continuesmt.Text = "续贴";
			button_vsplus_continuesmt.UseVisualStyleBackColor = false;
			button_vsplus_continuesmt.Click += new System.EventHandler(button_vsplus_continuesmt_Click);
			button_vsplus_setsmt.BackColor = System.Drawing.SystemColors.ControlLight;
			button_vsplus_setsmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_vsplus_setsmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_vsplus_setsmt.CnPressDownColor = System.Drawing.Color.White;
			button_vsplus_setsmt.Font = new System.Drawing.Font("黑体", 14f);
			button_vsplus_setsmt.Location = new System.Drawing.Point(263, 43);
			button_vsplus_setsmt.Name = "button_vsplus_setsmt";
			button_vsplus_setsmt.Size = new System.Drawing.Size(180, 38);
			button_vsplus_setsmt.TabIndex = 169;
			button_vsplus_setsmt.Text = "生产设置";
			button_vsplus_setsmt.UseVisualStyleBackColor = false;
			button_vsplus_setsmt.Click += new System.EventHandler(button_vsplus_setsmt_Click);
			button_PauseSmt.BackColor = System.Drawing.SystemColors.ControlLight;
			button_PauseSmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_PauseSmt.CnPressDownColor = System.Drawing.Color.White;
			button_PauseSmt.Font = new System.Drawing.Font("黑体", 12.25f);
			button_PauseSmt.Location = new System.Drawing.Point(8, 5);
			button_PauseSmt.Name = "button_PauseSmt";
			button_PauseSmt.Size = new System.Drawing.Size(84, 38);
			button_PauseSmt.TabIndex = 145;
			button_PauseSmt.Tag = "pause";
			button_PauseSmt.Text = "暂停";
			button_PauseSmt.UseVisualStyleBackColor = false;
			button_PauseSmt.Click += new System.EventHandler(button_PauseSmt_Click);
			button_vsplus_stopsmt.BackColor = System.Drawing.SystemColors.ControlLight;
			button_vsplus_stopsmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_vsplus_stopsmt.CnPressDownColor = System.Drawing.Color.White;
			button_vsplus_stopsmt.Font = new System.Drawing.Font("黑体", 12.25f);
			button_vsplus_stopsmt.Location = new System.Drawing.Point(105, 5);
			button_vsplus_stopsmt.Name = "button_vsplus_stopsmt";
			button_vsplus_stopsmt.Size = new System.Drawing.Size(84, 38);
			button_vsplus_stopsmt.TabIndex = 0;
			button_vsplus_stopsmt.Text = "结束";
			button_vsplus_stopsmt.UseVisualStyleBackColor = false;
			button_vsplus_stopsmt.Click += new System.EventHandler(button_vsplus_stopsmt_Click);
			button_Loukong_clearS3.BackColor = System.Drawing.Color.RosyBrown;
			button_Loukong_clearS3.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_Loukong_clearS3.CnPressDownColor = System.Drawing.Color.White;
			button_Loukong_clearS3.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_Loukong_clearS3.Location = new System.Drawing.Point(108, 107);
			button_Loukong_clearS3.Name = "button_Loukong_clearS3";
			button_Loukong_clearS3.Size = new System.Drawing.Size(101, 44);
			button_Loukong_clearS3.TabIndex = 167;
			button_Loukong_clearS3.Text = "出口位置PCB\r\n取走确认";
			button_Loukong_clearS3.UseVisualStyleBackColor = false;
			button_Loukong_clearS3.Visible = false;
			button_Loukong_clearS3.Click += new System.EventHandler(button_Loukong_clearS3_Click);
			button_vsplus_smtinfo.BackColor = System.Drawing.SystemColors.ControlLight;
			button_vsplus_smtinfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_vsplus_smtinfo.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_vsplus_smtinfo.CnPressDownColor = System.Drawing.Color.White;
			button_vsplus_smtinfo.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_vsplus_smtinfo.Location = new System.Drawing.Point(74, 3);
			button_vsplus_smtinfo.Name = "button_vsplus_smtinfo";
			button_vsplus_smtinfo.Size = new System.Drawing.Size(66, 28);
			button_vsplus_smtinfo.TabIndex = 170;
			button_vsplus_smtinfo.Text = "信息";
			button_vsplus_smtinfo.UseVisualStyleBackColor = false;
			button_vsplus_smtinfo.Click += new System.EventHandler(button_vsplus_smtinfo_Click);
			button_SmtVisualShow.BackColor = System.Drawing.SystemColors.ControlLight;
			button_SmtVisualShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_SmtVisualShow.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_SmtVisualShow.CnPressDownColor = System.Drawing.Color.White;
			button_SmtVisualShow.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_SmtVisualShow.Location = new System.Drawing.Point(142, 3);
			button_SmtVisualShow.Name = "button_SmtVisualShow";
			button_SmtVisualShow.Size = new System.Drawing.Size(66, 28);
			button_SmtVisualShow.TabIndex = 164;
			button_SmtVisualShow.Text = "视觉";
			button_SmtVisualShow.UseVisualStyleBackColor = false;
			button_SmtVisualShow.Click += new System.EventHandler(button_SmtVisualShow_Click);
			button_smt_showfackpcb.BackColor = System.Drawing.SystemColors.ControlLight;
			button_smt_showfackpcb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			button_smt_showfackpcb.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_smt_showfackpcb.CnPressDownColor = System.Drawing.Color.White;
			button_smt_showfackpcb.Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_smt_showfackpcb.Location = new System.Drawing.Point(5, 3);
			button_smt_showfackpcb.Name = "button_smt_showfackpcb";
			button_smt_showfackpcb.Size = new System.Drawing.Size(66, 28);
			button_smt_showfackpcb.TabIndex = 166;
			button_smt_showfackpcb.Text = "板图";
			button_smt_showfackpcb.UseVisualStyleBackColor = false;
			button_smt_showfackpcb.Click += new System.EventHandler(button_smt_showfackpcb_Click);
			button_bigtab.BackColor = System.Drawing.SystemColors.ControlLight;
			button_bigtab.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_bigtab.CnPressDownColor = System.Drawing.Color.White;
			button_bigtab.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_bigtab.Location = new System.Drawing.Point(662, 8);
			button_bigtab.Name = "button_bigtab";
			button_bigtab.Size = new System.Drawing.Size(38, 27);
			button_bigtab.TabIndex = 171;
			button_bigtab.Text = "B";
			button_bigtab.UseVisualStyleBackColor = false;
			button_bigtab.Visible = false;
			button_bigtab.Click += new System.EventHandler(button_bigtab_Click);
			cnButton_vsplus_startsmt.BackColor = System.Drawing.Color.Salmon;
			cnButton_vsplus_startsmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_vsplus_startsmt.CnPressDownColor = System.Drawing.Color.White;
			cnButton_vsplus_startsmt.Font = new System.Drawing.Font("黑体", 15.25f);
			cnButton_vsplus_startsmt.Location = new System.Drawing.Point(351, 105);
			cnButton_vsplus_startsmt.Name = "cnButton_vsplus_startsmt";
			cnButton_vsplus_startsmt.Size = new System.Drawing.Size(181, 63);
			cnButton_vsplus_startsmt.TabIndex = 0;
			cnButton_vsplus_startsmt.Text = "贴装生产";
			cnButton_vsplus_startsmt.UseVisualStyleBackColor = false;
			cnButton_vsplus_startsmt.Click += new System.EventHandler(cnButton_vsplus_startsmt_Click);
			cnButton_vsplus_setsmt.BackColor = System.Drawing.Color.Gainsboro;
			cnButton_vsplus_setsmt.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_vsplus_setsmt.CnPressDownColor = System.Drawing.Color.White;
			cnButton_vsplus_setsmt.Font = new System.Drawing.Font("黑体", 15.25f);
			cnButton_vsplus_setsmt.Location = new System.Drawing.Point(131, 105);
			cnButton_vsplus_setsmt.Name = "cnButton_vsplus_setsmt";
			cnButton_vsplus_setsmt.Size = new System.Drawing.Size(181, 63);
			cnButton_vsplus_setsmt.TabIndex = 0;
			cnButton_vsplus_setsmt.Text = "生产设置";
			cnButton_vsplus_setsmt.UseVisualStyleBackColor = false;
			cnButton_vsplus_setsmt.Click += new System.EventHandler(button_vsplus_setsmt_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(label_smtloopmode);
			base.Controls.Add(panel_smtinfo);
			base.Controls.Add(panel2);
			base.Controls.Add(button_openFeederPage_vsplus);
			base.Controls.Add(tabControl_mainwork);
			base.Name = "UserControl_job";
			base.Size = new System.Drawing.Size(1491, 1292);
			base.Load += new System.EventHandler(UserControl_job_Load);
			tabControl_mainwork.ResumeLayout(false);
			tabPage_main_pcbedit.ResumeLayout(false);
			panel_subpcb.ResumeLayout(false);
			panel_subpcblist.ResumeLayout(false);
			panel_PcbEditPage.ResumeLayout(false);
			panel_PCBE_OP.ResumeLayout(false);
			tabPage_main_smt.ResumeLayout(false);
			panel_SmtProducePage.ResumeLayout(false);
			panel5.ResumeLayout(false);
			panel_vsplus_pausestop.ResumeLayout(false);
			panel100.ResumeLayout(false);
			panel100.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel32.ResumeLayout(false);
			panel32.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_smtASpeed).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_smtXYSpeed).EndInit();
			panel30.ResumeLayout(false);
			panel_smtshoware.ResumeLayout(false);
			panel_fakepcb_smt.ResumeLayout(false);
			panel7.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel_youxianpik.ResumeLayout(false);
			panel_youxianpik.PerformLayout();
			panel_marksetting.ResumeLayout(false);
			panel_marksetting.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel_safespace.ResumeLayout(false);
			panel_safespace.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_safespace).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_failretryNum).EndInit();
			panel_smtinfo.ResumeLayout(false);
			panel_smtinfo.PerformLayout();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			ResumeLayout(false);
		}

		private int s_auto_smt_3inboard()
		{
			while (true)
			{
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return -1;
				}
				QnCommon.mPlayWoodState_Sensor = -1;
				MainForm0.mConDevExt[mFn].readPlayWoodState();
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					MainForm0.mDebugForm.readPlayWoodState();
				}
				int num = 100;
				while (true)
				{
					DateTime now = DateTime.Now;
					double num2 = 0.0;
					do
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						if (QnCommon.mPlayWoodState_Sensor != -1)
						{
							break;
						}
						Thread.Sleep(0);
						num2 = (DateTime.Now - now).TotalMilliseconds;
					}
					while (num2 < (double)num);
					if (num2 < (double)num)
					{
						break;
					}
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[0].readPlayWoodState();
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						QnCommon.mPlayWoodState_Sensor = MainForm0.mDebugForm.get_S();
					}
				}
				if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
				{
					QnCommon.mInBoardState[mFn] = MainForm0.mDebugForm.get_InB();
					QnCommon.mOutBoardState[mFn] = MainForm0.mDebugForm.get_OutB();
				}
				if (QnCommon.mInBoardState[mFn] != 0 || QnCommon.mOutBoardState[mFn] != 0)
				{
					continue;
				}
				if ((QnCommon.mPlayWoodState_Sensor & 1) == 0 && (QnCommon.mPlayWoodState_Sensor & 2) == 0 && (QnCommon.mPlayWoodState_Sensor & 4) == 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					MainForm0.mConDevExt[mFn].sendSwitchSMTready(1);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IDLE" : "空闲状态");
					});
					continue;
				}
				if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
				{
					return -1;
				}
				MainForm0.mConDevExt[mFn].sendSwitchSMTready(0);
				if (((uint)QnCommon.mPlayWoodState_Sensor & 8u) != 0 && USR_INIT.mIsBCTEnabled && (QnCommon.mPlayWoodState_Sensor & 0x10) == 0)
				{
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD..." : "正在出板..");
					});
					QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Busy;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Busy);
					}
					MainForm0.static_this.misc_board_out(mFn, USR3B.mTrackSpeed, (int)(USR3B.mTrackDelay * 10f), USR_INIT.mIsBCTEnabled);
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.sendOutBoard();
					}
					DateTime now2 = DateTime.Now;
					double num3 = 0.0;
					while (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Busy && num3 <= 15000.0)
					{
						Thread.Sleep(10);
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						num3 = (DateTime.Now - now2).TotalMilliseconds;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							QnCommon.mOutBoardState[mFn] = MainForm0.mDebugForm.get_OutB();
						}
					}
					if (num3 > 15000.0)
					{
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD TIMEOUT..." : "出板超时..");
						});
						MainForm0.write_to_logFile("出板超时.." + Environment.NewLine);
						return -3;
					}
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -3;
						}
						MainForm0.mConDevExt[0].sendSwitchSMTready(0);
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD TIMEOUT..." : "出板失败，请务必检查并清理！");
						});
						return -3;
					}
					if (QnCommon.mOutBoardState[mFn] == QnCommon.BoardStateEn.Ok)
					{
						QnCommon.mOutBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							MainForm0.mDebugForm.set_OutB(QnCommon.BoardStateEn.Unknown);
						}
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						MainForm0.mConDevExt[mFn].sendSwitchSMTready(0);
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "OUT BOARD OK" : "出板成功");
						});
					}
					continue;
				}
				MainForm0.write_to_logFile(QnCommon.mPlayWoodState_Sensor.ToString("X2"));
				s_inborad = 0;
				if (((uint)QnCommon.mPlayWoodState_Sensor & (true ? 1u : 0u)) != 0 && (QnCommon.mPlayWoodState_Sensor & 2) == 0 && (QnCommon.mPlayWoodState_Sensor & 4) == 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					s_inborad = 1;
				}
				else if (((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0 && (QnCommon.mPlayWoodState_Sensor & 4) == 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					s_inborad = 2;
				}
				else if (((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0 && (QnCommon.mPlayWoodState_Sensor & 8) == 0)
				{
					s_inborad = 3;
				}
				if (s_inborad != 0)
				{
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = "PCB" + s_inborad + ((USR_INIT.mLanguage == 2) ? "IN BOARD..." : "进板中...");
					});
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Busy;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Busy);
					}
					MainForm0.mConDevExt[0].sendInBoard(mFn, USR3B.mTrackSpeed, s_inborad - 1, 0);
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.sendInBoard();
					}
					DateTime now3 = DateTime.Now;
					double num4 = 0.0;
					while (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Busy && num4 <= 15000.0)
					{
						Thread.Sleep(10);
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -1;
						}
						num4 = (DateTime.Now - now3).TotalMilliseconds;
						if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
						{
							QnCommon.mInBoardState[mFn] = MainForm0.mDebugForm.get_InB();
						}
					}
					if (num4 > 15000.0)
					{
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = "PCB" + s_inborad + ((USR_INIT.mLanguage == 2) ? "IN BOARD TIMEOUT..." : "进板超时...");
						});
						MainForm0.write_to_logFile("PCB" + s_inborad + "进板超时.." + Environment.NewLine);
						return -3;
					}
					if (QnCommon.mInBoardState[mFn] == QnCommon.BoardStateEn.Fail)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -3;
						}
						MainForm0.mConDevExt[mFn].sendSwitchSMTready(0);
						Invoke((MethodInvoker)delegate
						{
							label_SmtState.Text = "PCB" + s_inborad + ((USR_INIT.mLanguage == 2) ? "IN BOARD TIMEOUT..." : "进板失败，请务必检查并清理！");
						});
						return -3;
					}
					if (QnCommon.mInBoardState[mFn] != QnCommon.BoardStateEn.Ok)
					{
						continue;
					}
					QnCommon.mInBoardState[mFn] = QnCommon.BoardStateEn.Unknown;
					if (MainForm0.mIsSimulation && MainForm0.mDebugForm != null && !MainForm0.mDebugForm.IsDisposed)
					{
						MainForm0.mDebugForm.set_InB(QnCommon.BoardStateEn.Unknown);
					}
					label_SmtState.Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = "PCB" + s_inborad + ((USR_INIT.mLanguage == 2) ? "IN BOARD OK, RUNING" : "进板成功，开始贴装");
					});
					if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
					{
						return -1;
					}
					msmtchip_idx_raw = 0;
					msmtchip_idx = 0;
					mis_maybe_continue = 0;
					if (mthd_smtRun != null && mthd_smtRun.IsAlive)
					{
						mthd_smtRun.Abort();
						Thread.Sleep(100);
					}
					BindingList<int> bindingList = new BindingList<int>();
					bindingList.Add(mloop[s_inborad - 1]);
					mthd_smtRun = new Thread(thd_SmtLoop);
					mthd_smtRun.IsBackground = true;
					mthd_smtRun.Start(bindingList);
					MainForm0.static_this.UI_Enable_SMT(mFn, flag: false);
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "进板成功，正在贴装..");
					});
					Thread.Sleep(300);
					while (vsplus_smtbusy() || MainForm0.mRunDoing[mFn] != 0)
					{
						if ((MainForm0.mRunDoing[mFn] & 2u) != 0)
						{
							return -2;
						}
						Thread.Sleep(100);
					}
					Invoke((MethodInvoker)delegate
					{
						label_SmtState.Text = ((USR_INIT.mLanguage == 2) ? "IN BOARD SUCCESSFUL, START SMT..." : "贴装完成，等待出板..");
					});
					if (s_inborad == HW.mSections && bIsFinishAutoRun)
					{
						break;
					}
				}
				else
				{
					Thread.Sleep(100);
				}
			}
			return -1;
		}

		public void vsplus_reback2plate(BIGTAB_GROUP biggroup, BindingList<int_2d> throwlist)
		{
			for (int i = 0; i < HW.mZnNum[mFn]; i++)
			{
				MainForm0.WaitComplete_Z(mFn, i);
			}
			if (HW.mSmtGenerationNo == 0)
			{
				BIGTAB_2_ITEM bIGTAB_2_ITEM = biggroup.mnt_arr[0];
				for (int j = 0; j < HW.mZnNum[mFn]; j++)
				{
					MainForm0.moveToZ_noWait_Smt(mFn, j, bIGTAB_2_ITEM.pik_speed_z_up, 0);
				}
			}
			else
			{
				for (int k = 0; k < biggroup.mnt_arr.Count; k++)
				{
					BIGTAB_2_ITEM bIGTAB_2_ITEM2 = biggroup.mnt_arr[k];
					if (MainForm0.mCur[mFn].z[bIGTAB_2_ITEM2.zn] > bIGTAB_2_ITEM2.prepare1_z)
					{
						MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_2_ITEM2.zn, bIGTAB_2_ITEM2.pik_speed_z_up, bIGTAB_2_ITEM2.prepare1_z);
					}
				}
				for (int l = 0; l < biggroup.remain_mnt_prepare_z.Count; l++)
				{
					BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z = biggroup.remain_mnt_prepare_z[l];
					if (MainForm0.mCur[mFn].z[bIGTAB_SUB_REMAIN_Z.zn] > bIGTAB_SUB_REMAIN_Z.value1)
					{
						MainForm0.moveToZ_noWait_Smt(mFn, bIGTAB_SUB_REMAIN_Z.zn, 60, bIGTAB_SUB_REMAIN_Z.value1);
					}
				}
			}
			for (int m = 0; m < HW.mZnNum[mFn]; m++)
			{
				MainForm0.WaitComplete_Z(mFn, m);
			}
			BindingList<BIGTAB_2_ITEM> bindingList = new BindingList<BIGTAB_2_ITEM>();
			for (int n = 0; n < throwlist.Count; n++)
			{
				int a = throwlist[n].a;
				bindingList.Add(biggroup.mnt_arr[a]);
			}
			for (int num = 0; num < bindingList.Count; num++)
			{
				if (bindingList[num].providertype == ProviderType.Plate)
				{
					smt_reback_chip(bindingList[num].zn, bindingList[num].stackno);
				}
			}
		}

		public bool smt_reback_chip(int zn, int plateNo)
		{
			StackElement[] array = USR2.mStackLib.stacktab[1];
			if (array[plateNo].mPlt.mXYlist == null)
			{
				array[plateNo].mPlt.mXYlist = new BindingList<StackPlateXYElement>();
			}
			if (array[plateNo].mPlt.mStartIndex > array[plateNo].mPlt.mXYlist.Count)
			{
				return false;
			}
			int num = array[plateNo].mPlt.mXYlist.Count;
			int num2 = array[plateNo].mPlt.mStartIndex - 1;
			num2 = ((array[plateNo].mPlt.mStartIndex != 0 && array[plateNo].mPlt.mStartIndex != array[plateNo].mPlt.mXYlist.Count) ? (array[plateNo].mPlt.mStartIndex - 1) : (array[plateNo].mPlt.mXYlist.Count - 1));
			while (!array[plateNo].mPlt.mXYlist[num2].mEnable)
			{
				num2 = ((num2 <= 0) ? (array[plateNo].mPlt.mXYlist.Count - 1) : (num2 - 1));
				if (--num <= 0)
				{
					break;
				}
			}
			if (num > 0)
			{
				Coordinate point = new Coordinate(array[plateNo].mPlt.mXYlist[num2].X - USR.mDeltaNozzle[0][zn].X, array[plateNo].mPlt.mXYlist[num2].Y - USR.mDeltaNozzle[0][zn].Y);
				MainForm0.moveToA_andWait_Smt(mFn, zn, USR3B.mSmtASpeed / 2, 0);
				int num3 = MainForm0.mCur[mFn].z[zn];
				int num4 = array[plateNo].mZnData[zn].Pik.Height;
				if (USR2.mIsHOffsetMode)
				{
					float num5 = MainForm0.format_H_to_Hmm(Math.Abs(array[plateNo].mZnData[zn].baseH));
					float hmm = num5 + array[plateNo].mZnData[zn].Pik.Offset;
					int num6 = MainForm0.format_Hmm_to_H(hmm) * ((zn % 2 != 0) ? 1 : (-1));
					if (HW.mSmtGenerationNo == 2)
					{
						num6 = Math.Abs(num6);
					}
					num4 = num6;
				}
				MainForm0.moveToXY_andWait_Smt(mFn, USR.mXYSpeed / 2, point);
				MainForm0.moveToZ_andWait_Smt(mFn, zn, array[plateNo].mZnData[zn].Pik.UpSpeed / 2 + 1, num4 * 15 / 16);
				MainForm0.misc_vacc_onoff(mFn, zn, 0);
				MainForm0.msdelay(array[plateNo].mZnData[zn].Pik.Delay);
				MainForm0.moveToZ_andWait_Smt(mFn, zn, array[plateNo].mZnData[zn].Pik.UpSpeed / 2 + 1, num3);
				return true;
			}
			return false;
		}

		public int startIndex_plate(int stackno, int startindex)
		{
			StackElement[] array = USR2.mStackLib.stacktab[1];
			int num = 0;
			if (array[stackno].mPlt.mXYlist != null && array[stackno].mPlt.mXYlist.Count > 0)
			{
				if (startindex >= array[stackno].mPlt.mXYlist.Count)
				{
					MainForm0.CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Plate start pick-XY is out of range--!" : "料盘起始取料索引超出有效范围--！");
					return 0;
				}
				if (startindex < array[stackno].mPlt.mRowNum * array[stackno].mPlt.mColumnNum)
				{
					num = 0;
					_ = startindex / array[stackno].mPlt.mColumnNum;
					_ = startindex % array[stackno].mPlt.mColumnNum;
				}
				else if (array[stackno].mPlt.mSubList != null && array[stackno].mPlt.mSubList.Count > 0)
				{
					int num2 = startindex - array[stackno].mPlt.mTotalNum;
					num = 1;
					for (int i = 0; i < array[stackno].mPlt.mSubList.Count; i++)
					{
						if (num2 < array[stackno].mPlt.mSubList[i].mTotalNum)
						{
							_ = num2 / array[stackno].mPlt.mSubList[i].mColumnNum;
							_ = num2 % array[stackno].mPlt.mSubList[i].mColumnNum;
							break;
						}
						num++;
						num2 -= array[stackno].mPlt.mSubList[i].mTotalNum;
					}
				}
			}
			return num;
		}

		public int mloop_calcBigTab()
		{
			int result = 1;
			if (mloop == null || mloop.Count == 0)
			{
				return 0;
			}
			int num = 0;
			float num2 = msmt_curhaiba;
			for (int i = 0; i < mloop.Count; i++)
			{
				int index = mloop[i];
				USR3_DATA uSR3_DATA = mUSR3List[index];
				if (mUSR3List[index].mBigTab == null)
				{
					mUSR3List[index].mBigTab = new BindingList<BIGTAB_GROUP>();
				}
				mUSR3List[index].mBigTab.Clear();
				if (i < mloop_idx)
				{
					continue;
				}
				BindingList<BindingList<ChipBoardElement>> mPointlistSmtGroup = mUSR3List[index].mPointlistSmtGroup;
				if (mPointlistSmtGroup == null)
				{
					continue;
				}
				int num3 = 0;
				int num4 = 0;
				for (int j = 0; j < mPointlistSmtGroup.Count; j++)
				{
					BindingList<ChipBoardElement> bindingList = mPointlistSmtGroup[j];
					if (bindingList == null || bindingList.Count == 0)
					{
						continue;
					}
					for (int k = 0; k < bindingList.Count; k++)
					{
						bindingList[k].pointSmtIndex = num4++;
					}
					BindingList<ChipBoardElement> bindingList2 = new BindingList<ChipBoardElement>();
					for (int l = 0; l < bindingList.Count; l++)
					{
						bindingList2.Add(bindingList[l]);
					}
					int count = bindingList2.Count;
					if (i == mloop_idx)
					{
						if (mis_maybe_continue == 0 || bindingList2[0].Group != msmtgroup_idx_raw)
						{
							for (int num5 = count - 1; num5 >= 0; num5--)
							{
								if (bindingList2[num5].pointSmtIndex < msmtchip_idx_raw)
								{
									bindingList2.RemoveAt(num5);
								}
							}
						}
						else
						{
							for (int num6 = count - 1; num6 >= 0; num6--)
							{
								int num7 = 0;
								for (num7 = 0; num7 < mthrowlist.Count && bindingList2[num6].Nozzle - 1 != mthrowlist[num7].b; num7++)
								{
								}
								if (num7 == mthrowlist.Count)
								{
									bindingList2.RemoveAt(num6);
								}
							}
						}
					}
					count = bindingList2.Count;
					for (int num8 = count - 1; num8 >= 0; num8--)
					{
						if (!bindingList2[num8].Ismount)
						{
							bindingList2.RemoveAt(num8);
						}
					}
					count = bindingList2.Count;
					for (int num9 = count - 1; num9 >= 0; num9--)
					{
						int arrayno = bindingList2[num9].Arrayno;
						bool isAix = bindingList2[num9].isAix;
						if (uSR3_DATA.mIsPcbAix)
						{
							if (!isAix && !uSR3_DATA.mIsArrayMount[arrayno])
							{
								bindingList2.RemoveAt(num9);
							}
							else if (isAix && !uSR3_DATA.mIsArrayAixMount[arrayno])
							{
								bindingList2.RemoveAt(num9);
							}
						}
						else if (!uSR3_DATA.mIsArrayMount[arrayno])
						{
							bindingList2.RemoveAt(num9);
						}
					}
					if (USR3B.mIsMountStacksNew != null)
					{
						count = bindingList2.Count;
						for (int num10 = count - 1; num10 >= 0; num10--)
						{
							ProviderType stacktype = bindingList2[num10].Stacktype;
							int num11 = bindingList2[num10].Stack_no - 1;
							if (!USR3B.mIsMountStacksNew[(int)stacktype][num11])
							{
								bindingList2.RemoveAt(num10);
							}
						}
					}
					if (bindingList2.Count == 0)
					{
						continue;
					}
					BIGTAB_GROUP bIGTAB_GROUP = new BIGTAB_GROUP();
					mUSR3List[index].mBigTab.Add(bIGTAB_GROUP);
					bIGTAB_GROUP.is_smt_test = false;
					bIGTAB_GROUP.gen = HW.mSmtGenerationNo;
					bIGTAB_GROUP.cameratype = bindingList2[0].Cameratype;
					bIGTAB_GROUP.provider = bindingList2[0].Stacktype;
					bIGTAB_GROUP.islowspeed = bindingList2[0].IsLowSpeed;
					bIGTAB_GROUP.is_overclimb = false;
					StackElement[] array;
					if (bIGTAB_GROUP.provider == ProviderType.Feedr)
					{
						array = USR2.mStackLib.stacktab[0];
					}
					else if (bIGTAB_GROUP.provider == ProviderType.Vibra)
					{
						array = USR2.mStackLib.stacktab[2];
					}
					else
					{
						if (bIGTAB_GROUP.provider != ProviderType.Plate)
						{
							return 0;
						}
						array = USR2.mStackLib.stacktab[1];
					}
					if (bIGTAB_GROUP.cameratype == CameraType.None)
					{
						bIGTAB_GROUP.is_overclimb = true;
					}
					else if (bIGTAB_GROUP.cameratype == CameraType.Fast)
					{
						if (bIGTAB_GROUP.provider == ProviderType.Feedr)
						{
							int num12 = bindingList2[0].Stack_no - 1;
							int num13 = (int)(bindingList2[0].Y - USR.mFastCamRecognizeCoord[0].Y);
							int num14 = (int)(bindingList2[0].Y - array[num12].mXY.Y);
							bIGTAB_GROUP.is_overclimb = num13 * num14 < 0;
						}
						else
						{
							bIGTAB_GROUP.is_overclimb = true;
						}
					}
					else if (bIGTAB_GROUP.cameratype == CameraType.High)
					{
						if (bIGTAB_GROUP.provider == ProviderType.Feedr)
						{
							int num15 = bindingList2[0].Stack_no - 1;
							int num16 = bindingList2[0].Nozzle - 1;
							int num17 = (int)(bindingList2[0].Y - USR.mHighCamRecognizeCoord[0][num16].Y);
							int num18 = (int)(bindingList2[0].Y - array[num15].mXY.Y);
							bIGTAB_GROUP.is_overclimb = num17 * num18 < 0;
						}
						else
						{
							bIGTAB_GROUP.is_overclimb = true;
						}
					}
					bool flag = false;
					if (bIGTAB_GROUP.provider == ProviderType.Feedr)
					{
						int num19 = bindingList2[0].Stack_no - 1;
						flag = ((num19 < HW.malgo2[MainForm0.mFn].slt_l[0] + HW.malgo2[MainForm0.mFn].slt_r[0]) ? true : false);
					}
					float[] array2 = new float[HW.mZnNum[MainForm0.mFn]];
					float[] array3 = new float[HW.mZnNum[MainForm0.mFn]];
					for (int m = 0; m < bindingList2.Count; m++)
					{
						BIGTAB_2_ITEM bIGTAB_2_ITEM = new BIGTAB_2_ITEM();
						bIGTAB_GROUP.mnt_arr.Add(bIGTAB_2_ITEM);
						int num20 = bindingList2[m].Stack_no - 1;
						bIGTAB_2_ITEM.materialvalue = bindingList2[m].Footprint + " " + bindingList2[m].Material_value + ", " + bindingList2[m].Labeltab;
						bIGTAB_2_ITEM.providertype = bIGTAB_GROUP.provider;
						bIGTAB_2_ITEM.stackno = num20;
						bIGTAB_2_ITEM.group_no = bindingList2[m].Group;
						bIGTAB_2_ITEM.cameratype = bindingList2[m].Cameratype;
						bIGTAB_2_ITEM.zn = bindingList2[m].Nozzle - 1;
						float num21 = MainForm0.format_H_to_Hmm(USR.mBaseHeight_camera[bIGTAB_2_ITEM.zn]) - array[num20].height;
						if (num21 < 0f)
						{
							num21 = 0f;
							if (HW.mSmtGenerationNo != 0)
							{
								result = -1;
							}
						}
						bIGTAB_2_ITEM.camera_z = MainForm0.format_Hmm_to_H(num21);
						bIGTAB_2_ITEM.pik_speed_z_up = array[num20].mZnData[bIGTAB_2_ITEM.zn].Pik.UpSpeed;
						bIGTAB_2_ITEM.pik_speed_z_down = array[num20].mZnData[bIGTAB_2_ITEM.zn].Pik.DownSpeed;
						bIGTAB_2_ITEM.visualtype = bindingList2[m].Visualtype;
						bIGTAB_2_ITEM.looptype = bindingList2[m].Looptype;
						bIGTAB_2_ITEM.scan_r = (array[num20].mIsScanR ? array[num20].scanR : ((bIGTAB_2_ITEM.cameratype == CameraType.High) ? USR2.mHighCamScanRange[0][bIGTAB_2_ITEM.zn] : USR2.mFastCamScanRange[0][bIGTAB_2_ITEM.zn]));
						bIGTAB_2_ITEM.threshold = array[num20].mZnData[bIGTAB_2_ITEM.zn].threshold;
						bIGTAB_2_ITEM.pno = USR2.mFastCamMinValidPixel[0][bIGTAB_2_ITEM.zn];
						bIGTAB_2_ITEM.is_collect = array[num20].mIsCollect;
						bIGTAB_2_ITEM.delta = array[num20].mCollectDelta;
						bIGTAB_2_ITEM.l_ref_mm = array[num20].lenght;
						bIGTAB_2_ITEM.w_ref_mm = array[num20].width;
						bIGTAB_2_ITEM.l_ref_pix = (int)(array[num20].lenght * 100f / ((bIGTAB_2_ITEM.cameratype != CameraType.High) ? USR.mFastCamRatio[0][bIGTAB_2_ITEM.zn] : USR.mHighCamRatio[0]));
						bIGTAB_2_ITEM.w_ref_pix = (int)(array[num20].width * 100f / ((bIGTAB_2_ITEM.cameratype != CameraType.High) ? USR.mFastCamRatio[0][bIGTAB_2_ITEM.zn] : USR.mHighCamRatio[0]));
						bIGTAB_2_ITEM.chip_hmm = array[num20].height;
						bIGTAB_2_ITEM.haiba0_hmm = num2;
						bIGTAB_2_ITEM.mnt_x = (int)(bindingList2[m].X - USR.mDeltaNozzle[0][bIGTAB_2_ITEM.zn].X);
						bIGTAB_2_ITEM.mnt_y = (int)(bindingList2[m].Y - USR.mDeltaNozzle[0][bIGTAB_2_ITEM.zn].Y);
						bIGTAB_2_ITEM.mnt_x_org = (int)bindingList2[m].X;
						bIGTAB_2_ITEM.mnt_y_org = (int)bindingList2[m].Y;
						bIGTAB_2_ITEM.mnt_a_org = (bIGTAB_2_ITEM.mnt_a = bindingList2[m].A);
						bIGTAB_2_ITEM.mnt_a_step_org = (bIGTAB_2_ITEM.mnt_a_step = 0);
						bIGTAB_2_ITEM.prepare1_z = 0;
						bIGTAB_2_ITEM.up1_z = 0;
						bIGTAB_2_ITEM.speed_z_down = array[num20].mZnData[bIGTAB_2_ITEM.zn].Mnt.DownSpeed;
						bIGTAB_2_ITEM.mnt_z = array[num20].mZnData[bIGTAB_2_ITEM.zn].Mnt.Height;
						if (USR2.mIsHOffsetMode)
						{
							float num22 = Math.Abs(USR.mBaseHeightmm[bIGTAB_2_ITEM.zn]) + array[num20].mZnData[bIGTAB_2_ITEM.zn].Mnt.Offset - array[num20].height;
							if (num22 < 0f)
							{
								num22 = 0f;
								result = -1;
							}
							int num23 = MainForm0.format_Hmm_to_H(num22) * ((bIGTAB_2_ITEM.zn % 2 != 0) ? 1 : (-1));
							if (HW.mSmtGenerationNo == 2)
							{
								num23 = Math.Abs(num23);
							}
							bIGTAB_2_ITEM.mnt_z = num23;
						}
						bIGTAB_2_ITEM.mntdelay = array[num20].mZnData[bIGTAB_2_ITEM.zn].Mnt.Delay;
						bIGTAB_2_ITEM.up0_z = 0;
						bIGTAB_2_ITEM.speed_z_up = array[num20].mZnData[bIGTAB_2_ITEM.zn].Mnt.UpSpeed;
						bIGTAB_2_ITEM.prepare0_z = 0;
						array2[bIGTAB_2_ITEM.zn] = num2;
						num2 = Math.Max(num2, bIGTAB_2_ITEM.chip_hmm);
						array3[bIGTAB_2_ITEM.zn] = num2;
						bIGTAB_2_ITEM.haiba1_hmm = num2;
						bIGTAB_2_ITEM.no = num3++;
						bIGTAB_2_ITEM.all_no = num++;
						bIGTAB_2_ITEM.raw_no = bindingList2[m].pointSmtIndex;
						bIGTAB_2_ITEM.is_overclimb = bIGTAB_GROUP.is_overclimb;
						if (bIGTAB_2_ITEM.visualtype == VisualType.FootPrint_R)
						{
							bIGTAB_2_ITEM.pinconfig2 = MainForm0.common_footprint_get_pinconfig(bindingList2[m].Footprint);
						}
					}
					bIGTAB_GROUP.is_cam2mnt_up = false;
					for (int n = 0; n < bindingList2.Count; n++)
					{
						BIGTAB_2_ITEM bIGTAB_2_ITEM2 = bIGTAB_GROUP.mnt_arr[n];
						if (HW.mSmtGenerationNo != 0)
						{
							float num24 = MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_2_ITEM2.zn]) - array2[bIGTAB_2_ITEM2.zn] - bIGTAB_2_ITEM2.chip_hmm - USR3B.mSmtSafeSpace;
							if (num24 < 0f)
							{
								num24 = 0f;
								result = -1;
							}
							int num25 = MainForm0.format_Hmm_to_H(num24);
							float num26 = MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_2_ITEM2.zn]) - bIGTAB_2_ITEM2.chip_hmm;
							if (num26 < 0f)
							{
								num26 = 0f;
								result = -1;
							}
							int val = MainForm0.format_Hmm_to_H(num26);
							bIGTAB_2_ITEM2.prepare1_z = Math.Min(num25, val);
							bIGTAB_2_ITEM2.up1_z = num25;
						}
						if (HW.mSmtGenerationNo != 0)
						{
							int num27 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_2_ITEM2.zn]) - num2 - USR3B.mSmtSafeSpace);
							int val2 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_2_ITEM2.zn]));
							bIGTAB_2_ITEM2.prepare0_z = Math.Min(num27, val2);
							bIGTAB_2_ITEM2.up0_z = num27;
						}
						if (bIGTAB_GROUP.is_cam2mnt_up)
						{
							continue;
						}
						float num28 = MainForm0.format_H_to_Hmm(USR.mBaseHeight_camera[bIGTAB_2_ITEM2.zn]) - bIGTAB_2_ITEM2.chip_hmm;
						if (num28 < 0f)
						{
							num28 = 0f;
							if (HW.mSmtGenerationNo != 0)
							{
								result = -1;
							}
						}
						int num29 = MainForm0.format_Hmm_to_H(num28);
						if (bIGTAB_2_ITEM2.prepare1_z < num29)
						{
							bIGTAB_GROUP.is_cam2mnt_up = true;
						}
					}
					int[] array4 = remain_zn_arr(bIGTAB_GROUP.mnt_arr);
					for (int num30 = 0; num30 < array4.Count(); num30++)
					{
						BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z = new BIGTAB_SUB_REMAIN_Z();
						bIGTAB_GROUP.remain_mnt_prepare_z.Add(bIGTAB_SUB_REMAIN_Z);
						bIGTAB_SUB_REMAIN_Z.zn = array4[num30];
						int val3 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_SUB_REMAIN_Z.zn]) - num2 - USR3B.mSmtSafeSpace);
						int val4 = USR.mBaseHeight_saferun[bIGTAB_SUB_REMAIN_Z.zn];
						bIGTAB_SUB_REMAIN_Z.value1 = Math.Min(val3, val4);
						bIGTAB_SUB_REMAIN_Z.value0 = Math.Min(val3, val4);
					}
					if (HW.mSmtGenerationNo == 0 && USR3B.mIsGen0RaiseSpeed)
					{
						for (int num31 = 0; num31 < bIGTAB_GROUP.mnt_arr.Count; num31++)
						{
							int num32 = gen0_conjugate_zn(bIGTAB_GROUP.mnt_arr[num31].zn);
							bIGTAB_GROUP.mnt_arr[num31].is_gen0_later_conjugate_zn = false;
							for (int num33 = num31 + 1; num33 < bIGTAB_GROUP.mnt_arr.Count; num33++)
							{
								if (bIGTAB_GROUP.mnt_arr[num33].zn == num32)
								{
									bIGTAB_GROUP.mnt_arr[num31].is_gen0_later_conjugate_zn = true;
									break;
								}
							}
						}
					}
					bIGTAB_GROUP.is_pik2cam_up = true;
					BindingList<BindingList<ChipBoardElement>> bindingList3 = syncPikList(bindingList2, 65535);
					for (int num34 = 0; num34 < bindingList3.Count; num34++)
					{
						BIGTAB_1_ITEM bIGTAB_1_ITEM = new BIGTAB_1_ITEM();
						bIGTAB_GROUP.pik_arr.Add(bIGTAB_1_ITEM);
						int count2 = bindingList3[num34].Count;
						int num35 = 0;
						int num36 = 0;
						for (int num37 = 0; num37 < bindingList3[num34].Count; num37++)
						{
							BIGTAB_SUB_PIK_ITEM bIGTAB_SUB_PIK_ITEM = new BIGTAB_SUB_PIK_ITEM();
							bIGTAB_1_ITEM.sync_arr.Add(bIGTAB_SUB_PIK_ITEM);
							bIGTAB_SUB_PIK_ITEM.group_no = bindingList3[num34][num37].Group;
							bIGTAB_SUB_PIK_ITEM.syncpik_no = num34 + 1;
							bIGTAB_SUB_PIK_ITEM.zn = bindingList3[num34][num37].Nozzle - 1;
							bIGTAB_SUB_PIK_ITEM.provider = bindingList3[num34][num37].Stacktype;
							bIGTAB_SUB_PIK_ITEM.stackno = bindingList3[num34][num37].Stack_no - 1;
							bIGTAB_SUB_PIK_ITEM.pikdelay = array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.Delay;
							bIGTAB_SUB_PIK_ITEM.speed_up = array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.UpSpeed;
							bIGTAB_SUB_PIK_ITEM.speed_down = array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.DownSpeed;
							bIGTAB_SUB_PIK_ITEM.pik_z = array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.Height;
							bIGTAB_SUB_PIK_ITEM.raw_no = bindingList3[num34][num37].pointSmtIndex;
							bIGTAB_SUB_PIK_ITEM.zero_a = 0f;
							bIGTAB_SUB_PIK_ITEM.zero_a_step = 0;
							bIGTAB_SUB_PIK_ITEM.mnt_a = MainForm0.format_angle(bindingList3[num34][num37].A, -180f, 180f, 360f);
							bIGTAB_SUB_PIK_ITEM.mnt_a_step = MainForm0.AngleToSteps(bIGTAB_SUB_PIK_ITEM.mnt_a);
							bIGTAB_SUB_PIK_ITEM.pik_a = 0f;
							bIGTAB_SUB_PIK_ITEM.pik_a_step = 0;
							bIGTAB_SUB_PIK_ITEM.is_preprarevacuum_later = USR2.mIsPrepareVacuumLater;
							bIGTAB_SUB_PIK_ITEM.materialvalue = bindingList3[num34][num37].Labeltab + "-" + bindingList3[num34][num37].Material_value + "-" + bindingList3[num34][num37].Footprint;
							bIGTAB_SUB_PIK_ITEM.visualtype = bindingList3[num34][num37].Visualtype;
							bIGTAB_SUB_PIK_ITEM.looptype = bindingList3[num34][num37].Looptype;
							if (bIGTAB_GROUP.provider != ProviderType.Plate)
							{
								num35 += (int)(array[bIGTAB_SUB_PIK_ITEM.stackno].mXY.X - USR.mDeltaNozzle[0][bIGTAB_SUB_PIK_ITEM.zn].X);
								num36 += (int)(array[bIGTAB_SUB_PIK_ITEM.stackno].mXY.Y - USR.mDeltaNozzle[0][bIGTAB_SUB_PIK_ITEM.zn].Y);
							}
							if (USR2.mIsHOffsetMode)
							{
								float num38 = MainForm0.format_H_to_Hmm(Math.Abs(flag ? USR.mBaseHeight_feeder[bIGTAB_SUB_PIK_ITEM.zn] : USR.mBaseHeight_feederBk[bIGTAB_SUB_PIK_ITEM.zn]));
								if (bIGTAB_SUB_PIK_ITEM.provider == ProviderType.Vibra || bIGTAB_SUB_PIK_ITEM.provider == ProviderType.Plate)
								{
									num38 = MainForm0.format_H_to_Hmm(Math.Abs(array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].baseH));
								}
								float hmm = num38 + array[bIGTAB_SUB_PIK_ITEM.stackno].mZnData[bIGTAB_SUB_PIK_ITEM.zn].Pik.Offset;
								int num39 = MainForm0.format_Hmm_to_H(hmm) * ((bIGTAB_SUB_PIK_ITEM.zn % 2 != 0) ? 1 : (-1));
								if (HW.mSmtGenerationNo == 2)
								{
									num39 = Math.Abs(num39);
								}
								bIGTAB_SUB_PIK_ITEM.pik_z = num39;
							}
							if (bIGTAB_GROUP.provider == ProviderType.Feedr || bIGTAB_GROUP.provider == ProviderType.Vibra)
							{
								bIGTAB_SUB_PIK_ITEM.zero_a = array[bIGTAB_SUB_PIK_ITEM.stackno].angle;
							}
							if (bIGTAB_GROUP.provider == ProviderType.Feedr && !flag && USR2.mIs180DegreeReverse_forbackfeeder)
							{
								bIGTAB_SUB_PIK_ITEM.zero_a += 180f;
							}
							if (bIGTAB_GROUP.cameratype == CameraType.None || bindingList3[num34][num37].Looptype == LoopType.HalfLoop || bindingList3[num34][num37].Looptype == LoopType.CloseLoop)
							{
								bIGTAB_SUB_PIK_ITEM.pik_a = bIGTAB_SUB_PIK_ITEM.zero_a + bIGTAB_SUB_PIK_ITEM.mnt_a;
							}
							bIGTAB_SUB_PIK_ITEM.zero_a = MainForm0.format_angle(bIGTAB_SUB_PIK_ITEM.zero_a, -180f, 180f, 360f);
							bIGTAB_SUB_PIK_ITEM.zero_a_step = MainForm0.AngleToSteps(bIGTAB_SUB_PIK_ITEM.zero_a);
							bIGTAB_SUB_PIK_ITEM.pik_a = MainForm0.format_angle(bIGTAB_SUB_PIK_ITEM.pik_a, -180f, 180f, 360f);
							bIGTAB_SUB_PIK_ITEM.pik_a_step = MainForm0.AngleToSteps(bIGTAB_SUB_PIK_ITEM.pik_a);
							vsplus_change_bigtabgroup_mnt_zero_a(bIGTAB_GROUP, bIGTAB_SUB_PIK_ITEM.zn, bIGTAB_SUB_PIK_ITEM.zero_a);
							float num40 = array[bIGTAB_SUB_PIK_ITEM.stackno].height;
							float num41 = ((bIGTAB_GROUP.cameratype == CameraType.None) ? array2[bIGTAB_SUB_PIK_ITEM.zn] : array2[bindingList2[0].Nozzle - 1]);
							if (HW.mSmtGenerationNo != 0)
							{
								int val5 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_SUB_PIK_ITEM.zn]) - num41 - USR3B.mSmtSafeSpace);
								int val6 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]));
								bIGTAB_SUB_PIK_ITEM.prepare0_z = Math.Min(val5, val6);
							}
							if (HW.mSmtGenerationNo != 0)
							{
								float num42 = MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_SUB_PIK_ITEM.zn]) - num41 - num40 - USR3B.mSmtSafeSpace;
								if (num42 < 0f)
								{
									num42 = 0f;
									result = -1;
								}
								int val7 = MainForm0.format_Hmm_to_H(num42);
								float num43 = MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]) - num40;
								if (num43 < 0f)
								{
									num43 = 0f;
									result = -1;
								}
								int val8 = MainForm0.format_Hmm_to_H(num43);
								bIGTAB_SUB_PIK_ITEM.prepare1_z = Math.Min(val7, val8);
							}
							if (HW.mSmtGenerationNo != 0)
							{
								if (bIGTAB_GROUP.provider == ProviderType.Feedr)
								{
									if (flag)
									{
										bIGTAB_SUB_PIK_ITEM.up0_z = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]));
										float num44 = MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]) - num40;
										if (num44 < 0f)
										{
											num44 = 0f;
											result = -1;
										}
										bIGTAB_SUB_PIK_ITEM.up1_z = MainForm0.format_Hmm_to_H(num44);
									}
									else
									{
										bIGTAB_SUB_PIK_ITEM.up0_z = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]));
										float num45 = MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_SUB_PIK_ITEM.zn]) - num40;
										if (num45 < 0f)
										{
											num45 = 0f;
											result = -1;
										}
										bIGTAB_SUB_PIK_ITEM.up1_z = MainForm0.format_Hmm_to_H(num45);
									}
									if (bIGTAB_SUB_PIK_ITEM.up0_z < bIGTAB_SUB_PIK_ITEM.prepare0_z)
									{
										bIGTAB_SUB_PIK_ITEM.up0_z = bIGTAB_SUB_PIK_ITEM.prepare0_z;
									}
									if (bIGTAB_SUB_PIK_ITEM.up1_z < bIGTAB_SUB_PIK_ITEM.prepare1_z)
									{
										bIGTAB_SUB_PIK_ITEM.up1_z = bIGTAB_SUB_PIK_ITEM.prepare1_z;
									}
								}
								else
								{
									bIGTAB_SUB_PIK_ITEM.up0_z = bIGTAB_SUB_PIK_ITEM.prepare0_z;
									bIGTAB_SUB_PIK_ITEM.up1_z = bIGTAB_SUB_PIK_ITEM.prepare1_z;
								}
							}
							if (!bIGTAB_GROUP.is_pik2cam_up)
							{
								continue;
							}
							float num46 = MainForm0.format_H_to_Hmm(USR.mBaseHeight_camera[bIGTAB_SUB_PIK_ITEM.zn]) - array[bIGTAB_SUB_PIK_ITEM.stackno].height;
							if (num46 < 0f)
							{
								num46 = 0f;
								if (HW.mSmtGenerationNo != 0)
								{
									result = -1;
								}
							}
							int num47 = MainForm0.format_Hmm_to_H(num46);
							if (bIGTAB_SUB_PIK_ITEM.prepare1_z < num47)
							{
								bIGTAB_GROUP.is_pik2cam_up = false;
							}
						}
						bIGTAB_1_ITEM.pik_x = num35 / count2;
						bIGTAB_1_ITEM.pik_y = num36 / count2;
						for (int num48 = 0; num48 < bIGTAB_1_ITEM.sync_arr.Count; num48++)
						{
							bIGTAB_1_ITEM.sync_arr[num48].pik_x = bIGTAB_1_ITEM.pik_x;
							bIGTAB_1_ITEM.sync_arr[num48].pik_y = bIGTAB_1_ITEM.pik_y;
						}
					}
					for (int num49 = 0; num49 < array4.Count(); num49++)
					{
						BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z2 = new BIGTAB_SUB_REMAIN_Z();
						bIGTAB_SUB_REMAIN_Z2.zn = array4[num49];
						bIGTAB_GROUP.remain_pik_prepare_z.Add(bIGTAB_SUB_REMAIN_Z2);
						float num50 = ((bIGTAB_GROUP.cameratype == CameraType.None) ? num2 : array2[bindingList2[0].Nozzle - 1]);
						int val9 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[array4[num49]]) - num50 - USR3B.mSmtSafeSpace);
						int val10 = USR.mBaseHeight_saferun[array4[num49]];
						bIGTAB_SUB_REMAIN_Z2.value1 = Math.Min(val9, val10);
						bIGTAB_SUB_REMAIN_Z2.value0 = Math.Min(val9, val10);
					}
					if (HW.mSmtGenerationNo != 0 || !USR3B.mIsGen0RaiseSpeed)
					{
						continue;
					}
					for (int num51 = 0; num51 < bIGTAB_GROUP.pik_arr.Count; num51++)
					{
						BIGTAB_1_ITEM bIGTAB_1_ITEM2 = bIGTAB_GROUP.pik_arr[num51];
						for (int num52 = 0; num52 < bIGTAB_1_ITEM2.sync_arr.Count; num52++)
						{
							int num53 = gen0_conjugate_zn(bIGTAB_1_ITEM2.sync_arr[num52].zn);
							bIGTAB_1_ITEM2.sync_arr[num52].is_gen0_later_conjugate_zn = false;
							for (int num54 = num51 + 1; num54 < bIGTAB_GROUP.pik_arr.Count; num54++)
							{
								BIGTAB_1_ITEM bIGTAB_1_ITEM3 = bIGTAB_GROUP.pik_arr[num54];
								for (int num55 = 0; num55 < bIGTAB_1_ITEM3.sync_arr.Count; num55++)
								{
									if (bIGTAB_1_ITEM3.sync_arr[num55].zn == num53)
									{
										bIGTAB_1_ITEM2.sync_arr[num52].is_gen0_later_conjugate_zn = true;
										break;
									}
								}
								if (bIGTAB_1_ITEM2.sync_arr[num52].is_gen0_later_conjugate_zn)
								{
									break;
								}
							}
						}
					}
				}
			}
			return result;
		}

		private BIGTAB_GROUP vsplus_create_biggroup(BIGTAB_GROUP biggroup_org, BindingList<int_2d> throwlist)
		{
			BIGTAB_GROUP bIGTAB_GROUP = new BIGTAB_GROUP(biggroup_org);
			BindingList<int> bindingList = new BindingList<int>();
			BindingList<BIGTAB_2_ITEM> bindingList2 = new BindingList<BIGTAB_2_ITEM>();
			for (int i = 0; i < throwlist.Count; i++)
			{
				int a = throwlist[i].a;
				bindingList.Add(bIGTAB_GROUP.mnt_arr[a].raw_no);
				bindingList2.Add(bIGTAB_GROUP.mnt_arr[a]);
			}
			for (int num = throwlist.Count - 1; num >= 0; num--)
			{
				int a2 = throwlist[num].a;
				bIGTAB_GROUP.mnt_arr.Remove(bIGTAB_GROUP.mnt_arr[a2]);
			}
			float num2 = bindingList2[bindingList2.Count - 1].haiba1_hmm;
			if (bIGTAB_GROUP.mnt_arr.Count > 0)
			{
				num2 = bIGTAB_GROUP.mnt_arr[bIGTAB_GROUP.mnt_arr.Count - 1].haiba1_hmm;
			}
			for (int j = 0; j < bindingList2.Count; j++)
			{
				BIGTAB_2_ITEM bIGTAB_2_ITEM = bindingList2[j];
				bIGTAB_2_ITEM.haiba0_hmm = num2;
				num2 = (bIGTAB_2_ITEM.haiba1_hmm = Math.Max(num2, bIGTAB_2_ITEM.chip_hmm));
			}
			for (int k = 0; k < bindingList2.Count; k++)
			{
				BIGTAB_2_ITEM bIGTAB_2_ITEM2 = bindingList2[k];
				if (HW.mSmtGenerationNo != 0)
				{
					int num3 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_2_ITEM2.zn]) - num2 - bIGTAB_2_ITEM2.chip_hmm - 1f);
					int val = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_2_ITEM2.zn]) - bIGTAB_2_ITEM2.chip_hmm);
					bIGTAB_2_ITEM2.prepare1_z = Math.Min(num3, val);
					bIGTAB_2_ITEM2.up1_z = num3;
				}
				if (HW.mSmtGenerationNo != 0)
				{
					int num4 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_2_ITEM2.zn]) - num2 - 1f);
					int val2 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight_saferun[bIGTAB_2_ITEM2.zn]));
					bIGTAB_2_ITEM2.prepare0_z = Math.Min(num4, val2);
					bIGTAB_2_ITEM2.up0_z = num4;
				}
			}
			bIGTAB_GROUP.mnt_arr.Clear();
			for (int l = 0; l < bindingList2.Count; l++)
			{
				bIGTAB_GROUP.mnt_arr.Add(bindingList2[l]);
			}
			int[] array = remain_zn_arr(bIGTAB_GROUP.mnt_arr);
			for (int m = 0; m < array.Count(); m++)
			{
				BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z = new BIGTAB_SUB_REMAIN_Z();
				bIGTAB_GROUP.remain_mnt_prepare_z.Add(bIGTAB_SUB_REMAIN_Z);
				bIGTAB_SUB_REMAIN_Z.zn = array[m];
				int val3 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[bIGTAB_SUB_REMAIN_Z.zn]) - num2 - 1f);
				int val4 = USR.mBaseHeight_saferun[bIGTAB_SUB_REMAIN_Z.zn];
				bIGTAB_SUB_REMAIN_Z.value1 = Math.Min(val3, val4);
				bIGTAB_SUB_REMAIN_Z.value0 = Math.Min(val3, val4);
			}
			if (HW.mSmtGenerationNo == 0 && USR3B.mIsGen0RaiseSpeed)
			{
				for (int n = 0; n < bIGTAB_GROUP.mnt_arr.Count; n++)
				{
					int zn = bIGTAB_GROUP.mnt_arr[n].zn;
					bIGTAB_GROUP.mnt_arr[n].is_gen0_later_conjugate_zn = false;
					for (int num5 = n + 1; num5 < bIGTAB_GROUP.mnt_arr.Count; num5++)
					{
						if (bIGTAB_GROUP.mnt_arr[num5].zn == zn)
						{
							bIGTAB_GROUP.mnt_arr[n].is_gen0_later_conjugate_zn = true;
							break;
						}
					}
				}
			}
			for (int num6 = bIGTAB_GROUP.pik_arr.Count - 1; num6 >= 0; num6--)
			{
				for (int num7 = bIGTAB_GROUP.pik_arr[num6].sync_arr.Count - 1; num7 >= 0; num7--)
				{
					int raw_no = bIGTAB_GROUP.pik_arr[num6].sync_arr[num7].raw_no;
					bool flag = true;
					for (int num8 = 0; num8 < bindingList.Count; num8++)
					{
						if (raw_no == bindingList[num8])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						bIGTAB_GROUP.pik_arr[num6].sync_arr.RemoveAt(num7);
					}
				}
				if (bIGTAB_GROUP.pik_arr[num6].sync_arr.Count == 0)
				{
					bIGTAB_GROUP.pik_arr.RemoveAt(num6);
				}
			}
			for (int num9 = 0; num9 < array.Count(); num9++)
			{
				BIGTAB_SUB_REMAIN_Z bIGTAB_SUB_REMAIN_Z2 = new BIGTAB_SUB_REMAIN_Z();
				bIGTAB_SUB_REMAIN_Z2.zn = array[num9];
				bIGTAB_GROUP.remain_pik_prepare_z.Add(bIGTAB_SUB_REMAIN_Z2);
				float num10 = num2;
				int val5 = MainForm0.format_Hmm_to_H(MainForm0.format_H_to_Hmm(USR.mBaseHeight[array[num9]]) - num10 - USR3B.mSmtSafeSpace);
				int val6 = USR.mBaseHeight_saferun[array[num9]];
				bIGTAB_SUB_REMAIN_Z2.value1 = Math.Min(val5, val6);
				bIGTAB_SUB_REMAIN_Z2.value0 = Math.Min(val5, val6);
			}
			if (HW.mSmtGenerationNo == 0 && USR3B.mIsGen0RaiseSpeed)
			{
				for (int num11 = 0; num11 < bIGTAB_GROUP.pik_arr.Count; num11++)
				{
					BIGTAB_1_ITEM bIGTAB_1_ITEM = bIGTAB_GROUP.pik_arr[num11];
					for (int num12 = 0; num12 < bIGTAB_1_ITEM.sync_arr.Count; num12++)
					{
						int zn2 = bIGTAB_1_ITEM.sync_arr[num12].zn;
						bIGTAB_1_ITEM.sync_arr[num12].is_gen0_later_conjugate_zn = false;
						for (int num13 = num11 + 1; num13 < bIGTAB_GROUP.pik_arr.Count; num13++)
						{
							BIGTAB_1_ITEM bIGTAB_1_ITEM2 = bIGTAB_GROUP.pik_arr[num13];
							for (int num14 = 0; num14 < bIGTAB_1_ITEM2.sync_arr.Count; num14++)
							{
								if (bIGTAB_1_ITEM2.sync_arr[num14].zn == zn2)
								{
									bIGTAB_1_ITEM.sync_arr[num12].is_gen0_later_conjugate_zn = true;
									break;
								}
							}
							if (bIGTAB_1_ITEM.sync_arr[num12].is_gen0_later_conjugate_zn)
							{
								break;
							}
						}
					}
				}
			}
			return bIGTAB_GROUP;
		}

		public int[] remain_zn_arr(BindingList<BIGTAB_2_ITEM> mnt_arr)
		{
			BindingList<int> bindingList = new BindingList<int>();
			for (int i = 0; i < HW.mZnNum[MainForm0.mFn]; i++)
			{
				bindingList.Add(i);
			}
			if (mnt_arr != null)
			{
				for (int j = 0; j < mnt_arr.Count; j++)
				{
					bindingList.Remove(mnt_arr[j].zn);
				}
			}
			int[] array = new int[bindingList.Count];
			for (int k = 0; k < bindingList.Count; k++)
			{
				array[k] = bindingList[k];
			}
			return array;
		}

		private int bigtab_count(BindingList<BIGTAB_GROUP> bigtab)
		{
			if (bigtab == null || bigtab.Count == 0)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < bigtab.Count; i++)
			{
				BIGTAB_GROUP bIGTAB_GROUP = bigtab[i];
				num = ((bIGTAB_GROUP != null && bIGTAB_GROUP.mnt_arr != null) ? (num + bIGTAB_GROUP.mnt_arr.Count) : num);
			}
			return num;
		}

		private bool bigtab_continue_raw_no()
		{
			USR3_DATA uSR3_DATA = mUSR3List[mloop[mloop_idx]];
			int num = 0;
			for (int i = 0; i < uSR3_DATA.mBigTab.Count; i++)
			{
				BIGTAB_GROUP bIGTAB_GROUP = uSR3_DATA.mBigTab[i];
				num += bIGTAB_GROUP.mnt_arr.Count;
				if (msmtchip_idx >= num)
				{
					continue;
				}
				for (int j = 0; j < bIGTAB_GROUP.mnt_arr.Count; j++)
				{
					if (bIGTAB_GROUP.mnt_arr[j].no == msmtchip_idx)
					{
						msmtchip_idx_raw = bIGTAB_GROUP.mnt_arr[j].raw_no;
						break;
					}
				}
				return true;
			}
			if (msmtchip_idx == num)
			{
				mloop_idx++;
				if (mloop_idx == mloop.Count)
				{
					mloop_idx = 0;
				}
				msmtchip_idx = 0;
				uSR3_DATA = mUSR3List[mloop[mloop_idx]];
				if (uSR3_DATA.mBigTab.Count == 0)
				{
					return false;
				}
				msmtchip_idx_raw = uSR3_DATA.mBigTab[0].mnt_arr[0].raw_no;
				return true;
			}
			return false;
		}

		private int bigtab_count(BindingList<int> loop)
		{
			int num = 0;
			for (int i = 0; i < loop.Count; i++)
			{
				int index = loop[i];
				USR3_DATA uSR3_DATA = mUSR3List[index];
				num += bigtab_count(uSR3_DATA.mBigTab);
			}
			return num;
		}

		public int gen0_conjugate_zn(int zn)
		{
			int num = zn / 2;
			int num2 = zn % 2;
			return num * 2 + (1 - num2);
		}

		public void set_loukong_takeaway_visiable(bool flag)
		{
			button_Loukong_clearS3.Visible = flag;
		}

		private void __button_Loukong_clearS3_Click(object sender, EventArgs e)
		{
			if (USR3B != null)
			{
				button_Loukong_clearS3.Visible = false;
				if (MainForm0.mConDevExt != null && MainForm0.mConDevExt[0] != null)
				{
					MainForm0.mConDevExt[0].send_loukong_clearS3();
				}
			}
		}

		public bool loukong_state_confirm()
		{
			if (HW.mFnNum >= 2 && MainForm0.USR3_INIT != null && MainForm0.USR3_INIT.mIsLoukong)
			{
				QnCommon.mPlayWoodState_Sensor = -1;
				QnCommon.mPlayWoodState_Motor = -1;
				if (!MainForm0.mIsSimulation)
				{
					MainForm0.mConDevExt[0].readPlayWoodState();
				}
				if (is_sim_dsq())
				{
					MainForm0.mDebugFormDSQ.readPlayWoodState();
				}
				int num = 1000;
				DateTime now = DateTime.Now;
				double num2;
				for (num2 = 0.0; num2 < (double)num; num2 = (DateTime.Now - now).TotalMilliseconds)
				{
					if (MainForm0.mIsSimulation)
					{
						if (is_sim_dsq())
						{
							QnCommon.mPlayWoodState_Sensor = MainForm0.mDebugFormDSQ.get_S();
							QnCommon.mPlayWoodState_Motor = MainForm0.mDebugFormDSQ.get_M();
						}
						else
						{
							QnCommon.mPlayWoodState_Sensor = 0;
							QnCommon.mPlayWoodState_Motor = 0;
						}
					}
					if (QnCommon.mPlayWoodState_Sensor != -1 && QnCommon.mPlayWoodState_Motor != -1)
					{
						break;
					}
					Thread.Sleep(1);
				}
				if (num2 >= (double)num)
				{
					return false;
				}
				bool[] array = new bool[5];
				bool[] array2 = array;
				array2[0] = ((((uint)QnCommon.mPlayWoodState_Sensor & (true ? 1u : 0u)) != 0) ? true : false);
				array2[1] = ((((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0) ? true : false);
				array2[2] = ((((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0) ? true : false);
				array2[3] = ((((uint)QnCommon.mPlayWoodState_Sensor & 8u) != 0) ? true : false);
				array2[4] = ((((uint)QnCommon.mPlayWoodState_Sensor & 0x10u) != 0) ? true : false);
				Form_Loukong_State_DSQ form_Loukong_State_DSQ = new Form_Loukong_State_DSQ(array2);
				if (form_Loukong_State_DSQ.ShowDialog() == DialogResult.OK)
				{
					bool[] pwState = form_Loukong_State_DSQ.get_PwState();
					if (!MainForm0.mIsSimulation)
					{
						MainForm0.mConDevExt[0].send_loukong_setstate_dsq(pwState[0] ? 1 : 0, pwState[1] ? 1 : 0, pwState[2] ? 1 : 0, pwState[3] ? 1 : 0, pwState[4] ? 1 : 0);
					}
					return true;
				}
				return false;
			}
			if (USR3B != null && USR3B.mIsLoukongPCB)
			{
				if (HW.mIsSanduanshi)
				{
					QnCommon.mPlayWoodState_Sensor = -1;
					QnCommon.mPlayWoodState_Motor = -1;
					if (!MainForm0.mIsSimulation)
					{
						MainForm0.mConDevExt[mFn].readPlayWoodState();
					}
					if (!MainForm0.mIsSimulation)
					{
						int num3 = 1000;
						DateTime now2 = DateTime.Now;
						double num4 = 0.0;
						while (num4 < (double)num3 && (QnCommon.mPlayWoodState_Sensor == -1 || QnCommon.mPlayWoodState_Motor == -1))
						{
							Thread.Sleep(1);
							num4 = (DateTime.Now - now2).TotalMilliseconds;
						}
						if (num4 >= (double)num3)
						{
							return false;
						}
					}
					else
					{
						QnCommon.mPlayWoodState_Sensor = 0;
						QnCommon.mPlayWoodState_Motor = 0;
					}
					bool[] array3 = new bool[3];
					bool[] array4 = array3;
					array4[0] = ((((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0) ? true : false);
					array4[1] = ((((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0) ? true : false);
					array4[2] = ((((uint)QnCommon.mPlayWoodState_Sensor & 8u) != 0) ? true : false);
					Form_Loukong_State form_Loukong_State = new Form_Loukong_State(array4, HW.mIsSanduanshi);
					if (form_Loukong_State.ShowDialog() == DialogResult.OK)
					{
						bool[] pwState2 = form_Loukong_State.get_PwState();
						if (!MainForm0.mIsSimulation)
						{
							MainForm0.mConDevExt[0].send_loukong_setstate(pwState2[0] ? 1 : 0, pwState2[1] ? 1 : 0, pwState2[2] ? 1 : 0);
						}
						return true;
					}
					return false;
				}
				QnCommon.mPlayWoodState_Sensor = -1;
				if (!MainForm0.mIsSimulation)
				{
					MainForm0.mConDevExt[0].readPlayWoodState();
				}
				if (!MainForm0.mIsSimulation)
				{
					int num5 = 1000;
					DateTime now3 = DateTime.Now;
					double num6 = 0.0;
					while (num6 < (double)num5 && QnCommon.mPlayWoodState_Sensor == -1)
					{
						Thread.Sleep(1);
						num6 = (DateTime.Now - now3).TotalMilliseconds;
					}
					if (num6 >= (double)num5)
					{
						return false;
					}
				}
				else
				{
					QnCommon.mPlayWoodState_Sensor = 0;
				}
				bool[] array5 = new bool[3];
				bool[] array6 = array5;
				array6[0] = ((((uint)QnCommon.mPlayWoodState_Sensor & 2u) != 0) ? true : false);
				array6[1] = ((((uint)QnCommon.mPlayWoodState_Sensor & 4u) != 0) ? true : false);
				array6[2] = ((((uint)QnCommon.mPlayWoodState_Sensor & 8u) != 0) ? true : false);
				Form_Loukong_State form_Loukong_State2 = new Form_Loukong_State(array6, HW.mIsSanduanshi);
				if (form_Loukong_State2.ShowDialog() == DialogResult.OK)
				{
					bool[] pwState3 = form_Loukong_State2.get_PwState();
					if (!MainForm0.mIsSimulation)
					{
						MainForm0.mConDevExt[mFn].send_loukong_setstate(pwState3[0] ? 1 : 0, pwState3[1] ? 1 : 0, pwState3[2] ? 1 : 0);
					}
					return true;
				}
				return false;
			}
			return true;
		}

		public bool get_simulate_visualpass()
		{
			return is_ignore_visualfail;
		}

		public void set_label_everyhour_avespeed(int value)
		{
			label_everyhour_speed.Text = value.ToString();
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_avespeed(mFn, value);
			}
		}

		public void set_label_everyhour_maxspeed(int value)
		{
			label_everyhour_maxspeed.Text = value.ToString();
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_maxspeed(mFn, value);
			}
		}

		public void set_label_all_curchipindex(int value)
		{
			label_All_CurChipIndex.Text = value.ToString();
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_chips(mFn, value);
			}
		}

		public void set_label_all_pcbs(int value)
		{
			label_All_PCBSmted.Text = value.ToString();
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_pcbs(mFn, value);
			}
		}

		public void set_label_smt_index_no(int value)
		{
			label_SmtIndexNo.Text = mUSR3List[mUSR3Idx].mPcbID + " " + value;
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_SmtIndexNo(mFn, mUSR3List[mUSR3Idx].mPcbID + " " + value);
			}
		}

		public void set_label_haiba(float value)
		{
			label_haiba.Text = value.ToString("F2");
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_haiba(mFn, value);
			}
		}

		public void init_pregress_bar(int min_v, int max_v, int value)
		{
		}

		public void set_progress_bar(int value)
		{
			progressBar_Process.Value = value;
			if (MainForm0.uc_smtRunning != null && !MainForm0.uc_smtRunning.IsDisposed)
			{
				MainForm0.uc_smtRunning.set_progress_bar_v(mFn, value);
			}
		}

		public int get_progress_bar_max_v()
		{
			return progressBar_Process.Maximum;
		}

		public int get_progress_bar_v()
		{
			return progressBar_Process.Value;
		}
	}
}
