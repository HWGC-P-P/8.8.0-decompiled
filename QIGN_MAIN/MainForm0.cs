using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using QIGN_COMMON;
using QIGN_COMMON.Properties;
using QIGN_COMMON.vs_acontrol;
using QIGN_COMMON.vs_class;
using QIGN_COMMON.vs_Forms;
using QIGN_COMMON.vs_Forms.Form_Debug;
using QIGN_CONNECTION;

namespace QIGN_MAIN
{
	public class MainForm0 : Form
	{
		public delegate int int_Func_ptr_int_vin_vout(IntPtr scan0, int vis, ref VisInput vinput, ref VisOutput voutput);

		public struct VisItem
		{
			public VisualType vistype;

			public string name;

			public Bitmap pic;
		}

		public struct VisLib
		{
			public IntPtr vDll;

			public string name;

			public int_Func_void nmoon_birds_get_count;

			public int_Func_int nmoon_birds_get_visual;

			public int_Func_int_ptr nmoon_birds_get_pic;

			public int_Func_int_int_ptr nmoon_birds_get_namestring;

			public int_Func_ptr_int_vin_vout nmoon_birds_visualrun;

			public VisItem[] vTab;

			public int vCount;
		}

		public enum PixFormat
		{
			YUYV = 1,
			RGB24 = 3,
			RGB32 = 4
		}

		public struct VisInput
		{
			public int pixfmt;

			public int w_use;

			public int h_use;

			public int scan_center_x;

			public int scan_center_y;

			public int scan_r;

			public int threshold;

			public int is_opposite;

			public int is_debug;

			public float pixel_scale;

			public float chip_l;

			public float chip_w;

			public int footprint_pinmode;

			public int is_defects_detection;

			public int is_pin_diff;

			public float pin_side_dis;

			public float pin_side_dis2;

			public int pin0_counts;

			public float pin0_l;

			public float pin0_w;

			public float pin0_slot;

			public float pin0_dis;

			public float pin0_offset;

			public int pin1_counts;

			public float pin1_l;

			public float pin1_w;

			public float pin1_slot;

			public float pin1_dis;

			public float pin1_offset;

			public int pin2_counts;

			public float pin2_l;

			public float pin2_w;

			public float pin2_slot;

			public float pin2_dis;

			public float pin2_offset;

			public int pin3_counts;

			public float pin3_l;

			public float pin3_w;

			public float pin3_slot;

			public float pin3_dis;

			public float pin3_offset;
		}

		public struct VisOutput
		{
			public float box2d_center_x;

			public float box2d_center_y;

			public float box2d_w;

			public float box2d_h;

			public float box2d_angel;

			public int pno;

			public int threshold;

			public VisOutput(int a)
			{
				box2d_center_x = 0f;
				box2d_center_y = 0f;
				box2d_w = 0f;
				box2d_h = 0f;
				box2d_angel = 0f;
				pno = 0;
				threshold = 0;
			}
		}

		public enum UI_ENABLE
		{
			USR,
			SMT,
			OPT
		}

		public enum HardwareEnum
		{
			Win32_Processor,
			Win32_PhysicalMemory,
			Win32_Keyboard,
			Win32_PointingDevice,
			Win32_FloppyDrive,
			Win32_DiskDrive,
			Win32_CDROMDrive,
			Win32_BaseBoard,
			Win32_BIOS,
			Win32_ParallelPort,
			Win32_SerialPort,
			Win32_SerialPortConfiguration,
			Win32_SoundDevice,
			Win32_SystemSlot,
			Win32_USBController,
			Win32_NetworkAdapter,
			Win32_NetworkAdapterConfiguration,
			Win32_Printer,
			Win32_PrinterConfiguration,
			Win32_PrintJob,
			Win32_TCPIPPrinterPort,
			Win32_POTSModem,
			Win32_POTSModemToSerialPort,
			Win32_DesktopMonitor,
			Win32_DisplayConfiguration,
			Win32_DisplayControllerConfiguration,
			Win32_VideoController,
			Win32_VideoSettings,
			Win32_TimeZone,
			Win32_SystemDriver,
			Win32_DiskPartition,
			Win32_LogicalDisk,
			Win32_LogicalDiskToPartition,
			Win32_LogicalMemoryConfiguration,
			Win32_PageFile,
			Win32_PageFileSetting,
			Win32_BootConfiguration,
			Win32_ComputerSystem,
			Win32_OperatingSystem,
			Win32_StartupCommand,
			Win32_Service,
			Win32_Group,
			Win32_GroupUser,
			Win32_UserAccount,
			Win32_Process,
			Win32_Thread,
			Win32_Share,
			Win32_NetworkClient,
			Win32_NetworkProtocol,
			Win32_PnPEntity
		}

		public struct Coordst
		{
			public volatile int x;

			public volatile int y;

			public volatile int[] z;

			public volatile int[] a;
		}

		public enum StackSel
		{
			FeederIndex,
			PlateIndex,
			VibraIndex,
			VisualIndex,
			Num
		}

		public enum SmtHead
		{
			ISMOUNT,
			LABEL,
			VALUE,
			STACKTYPE,
			STACKNO,
			X,
			Y,
			A,
			ARRAY,
			NOZZLE,
			CAMERA,
			VISUAL,
			GROUP,
			FOOTPRINT,
			LOWSPEED,
			NUM
		}

		public class SmtHeadSt
		{
			public string Lb;

			public int W;
		}

		private const int MF_BYPOSITION = 1024;

		private const int MF_REMOVE = 4096;

		private const int OF_READWRITE = 2;

		private const int OF_SHARE_DENY_NONE = 64;

		public static int mJvs_picboxWidth;

		public static int mJvs_picboxHeight;

		public static bool mIsPreviewZoom = false;

		public static Bitmap[] mBitmapVisualTest;

		public static Bitmap[] mBitmapVisualRunning;

		public static bool JK_PrvMove = true;

		public static CameraType[] mCurCam = null;

		public static float mMarkPreviewRatio = 1f;

		public static volatile int mJVS_OpenedPreviewMask = 0;

		public static volatile bool[] bJVSCameraRecived;

		public static volatile Bitmap[] mJVSBitmap;

		public static volatile BitmapData[] mJVSBitmap_Data;

		public static int mJvs_Channels = 0;

		public static IntPtr[] mJvs_Hd;

		public static int mJvs_rawWidth = 704;

		public static int mJvs_rawHeight = 576;

		public static int mJvs_usrWidth = 704;

		public static int mJvs_usrHeight = 576;

		private static bool mJvs_State = false;

		public static JvsDriver mJvsDriver = JvsDriver.JVS900;

		public static JvsDriver mKsjDriver = JvsDriver.KSJ_U3C500;

		private static Semaphore stillMutex;

		private string m_Tst;

		public static string mProjectFileName = "";

		public static USR3_BASE[] USR3B;

		public static USR_PRJ_EX_DATA USR_PRJ_EX;

		public static USR3_INIT_DATA USR3_INIT = null;

		public static BindingList<USR3_DATA>[] U3;

		public static int[] U3Idx;

		public static int[] U3Idx_Prev;

		public static USR3_DATA[][] __mUSR3;

		public static Form_LabProviders mForm_LabProvider = null;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		public List<LanguageToolStripMenuItem> mLanguageToolStripMenuItemList = new List<LanguageToolStripMenuItem>();

		public static volatile bool mMutexMoveXYZA = false;

		public static volatile byte[] mRunDoing;

		public static volatile Coordinate[] mWaitXY;

		public static volatile int[][] mWaitZ;

		public static volatile int[][] mWaitA;

		public static volatile bool mIsBoardFixed = false;

		public int m_InitDone;

		public static int[] m_hDSP;

		public int youxian_pik;

		private static DvrshMethod.RAWSTREAM_DIRECT_CALLBACK ahd8_callback_fn;

		public static bool is_ahd8_callbackmode = true;

		private static volatile bool[] is_ahd8_start_capture;

		private static byte[][] ahd8_pYuvBuffer;

		private static byte[][] ahd8_pRgb32Buffer;

		public static string[] moonNozzles = new string[10] { "500", "501", "502", "503", "504", "505", "506", "507", "508", "509" };

		public static VisLib[] vmLib;

		public static bool mIsSwitchDevice = false;

		public static int mSmtMiles = 0;

		public static bool mIsSimulation = false;

		public static bool mIsSecurityTest = false;

		public static Label static_label_notice_register = null;

		public static bool mDebug_Factory = false;

		public static string[] static_firmware_version = null;

		public static volatile bool mMutexBt = false;

		public static volatile bool mMutexBtDown = false;

		public static volatile bool mMutexLog = false;

		public static PictureBox[] PicBox_Preview = null;

		public static PictureBox[] PicBox_Preview2 = null;

		public static PictureBox[] pictureBox_visualrunning = null;

		public static Panel[] panel_preview = null;

		public static CnButton[] button_stop_runningvisual = null;

		public static PictureBox[] pictureBox_VisualTest;

		public static bool[] mIsAutoSelect_PcbCheck_NearestMarkChip = null;

		public static BindingList<slot_item_for_catfromotherfile>[] slotcatitems_from_otherfile_lists;

		public IntPtr mMainHandle;

		public bool addEvent_for_tabControl_main_flag;

		public int alarm;

		public static string[] mLegal_Msg = new string[1];

		public static readonly Bitmap[] SIGN_PICTURE = new Bitmap[4]
		{
			Resources.Sign1,
			Resources.Sign2,
			Resources.Sign3,
			Resources.Sign4
		};

		public static readonly Icon[] ICON_PICTURE = new Icon[17]
		{
			Resources._128X128,
			Resources._128X128_YX,
			Resources._128X128_ZB,
			Resources._128X128_RTR,
			Resources._128X128_JT,
			Resources._128X128_SMT,
			Resources._128X128_FLK,
			Resources._128X128_WCH,
			Resources._128X128_MENGDA,
			Resources._128X128_SMT,
			Resources._128X128_YIDANUO,
			Resources._128X128_TE108_2,
			Resources._128X128_SMT,
			Resources._128X128_DENAYUAN,
			Resources._128X128_HAOBEN,
			Resources._128X128_JIDA,
			Resources._128X128_FLEXIUM
		};

		public static readonly Bitmap[] MAIN_PICTURE = new Bitmap[17]
		{
			Resources.HWGC_IMAGE7,
			Resources.YX_IMAGE,
			Resources.ZB_IMAGE,
			Resources.RTR_IMAGE,
			Resources.JT_IMAGE,
			Resources.SMT_IMAGE2,
			Resources.FLK_IMAGE,
			Resources.WCH_IMAGE,
			Resources.MENGDA_IMAGE,
			Resources.SMT_IMAGE2,
			Resources.YIDANUO_IMAGE,
			Resources.TE108_IMAGE2,
			Resources.SMT_IMAGE,
			Resources.DENAYUAN_IMAGE,
			Resources.HAOBEN_IMAGE,
			Resources.JIDA_IMAGE,
			Resources.FLEXIUM_IMAGE
		};

		public static MainForm0 static_this;

		public static Label static_label_smtdevicetype;

		public static TabControl static_tabControl_dsq;

		public static int mFn = 0;

		public static UserControl_SmtRunning uc_smtRunning = null;

		public static double total_avespeed;

		public static double total_maxspeed;

		public static bool mutex_fm_smtrunning = false;

		public static volatile bool mutex_readplaywood = false;

		public static UserControl_UsrOperation[] uc_usroperarion = null;

		public static Panel[] panel_mainAreas = null;

		public static Panel[] panel_mainPictures = null;

		public static Panel[] panel_newProjects = null;

		public static UserControl_job[] uc_job = null;

		public static UserControl_SystemSetting[] uc_devicecalibration = null;

		private TrackBar[] trackBar_color;

		public static volatile byte[][] pKSJBuffer;

		public static volatile bool[] bKSJCameraRecived;

		private static int mKSJ_VWsize = 1944;

		private static int mKSJ_VHsize = 1944;

		private volatile int mKSJ_OpenedPreviewMask;

		private bool mDriverState_KSJ;

		private CAM.KSJ_PREVIEWMODE mKSJ_PreviewMode;

		public static volatile IntPtr[][] hvc_tmp_buffer;

		public static bool mIsHvcCallbackMode = true;

		public static volatile IntPtr[] HVC_DATA_PTR;

		public static volatile int[] HVC_WAIT_COUNT;

		private static JW6008HT.IMAGE_STREAM_CALLBACK[] callbackImageStream;

		public static Form_MarkCamPara mForm_MarkCamPara = null;

		public static UserControl_MarkCamPara uc_markcampara = null;

		public static volatile bool mIsVisualRunning = false;

		private Point p_bk;

		public static bool is_smt_test = false;

		public static string mLogFileName = null;

		private readonly IntPtr HFILE_ERROR = new IntPtr(-1);

		private bool mIsNewCom;

		public static USR2_DATA[] USR2;

		public static USR2_DATA USR2_DEFAUL;

		public static Thread[] mThd_FeederGoodbye = null;

		private Form_OpenShape[] mFmFeederGoodbye;

		public static volatile bool[] mIsFeederUp = null;

		public static volatile bool[] mIsXYMoving = null;

		private bool[] mIsRunDoingBackSetRRRR_FeederGoodbye;

		private byte[] mRunDoingBackUp_FeederGoodbye;

		private bool[] mIsCloseNotDone_FeederGoodbye;

		private bool[] mIsRunDoingBackSetRRRR;

		private byte[] mRunDoingBackUp;

		private bool[] mIsCloseNotDone;

		private Thread[] mThd_OpenShape;

		private Form_OpenShape[] mFmOpenShape;

		public static string mEngineerPassword = "0000";

		public static bool mIsPassedEngineerPassword = false;

		public static volatile bool mutex_piktocam = false;

		private bool mIsInitSuccess_Serial;

		private bool mIsInitSuccess_FastCam;

		private bool mIsInitSuccess_HighCam;

		public static bool mIsOpenShape_Enabled = false;

		private volatile bool is_serial_init_finished;

		private volatile bool is_camera_init_finished;

		public static UserControl_VisualShow[] uc_VisualShowSmt = null;

		public static QnConnectionClass[] mCom;

		public static BindingList<QnConnectionClass> mComUsingList;

		public static QnConnectionClass[] mConDev;

		public static QnConnectionClass[] mConDev2;

		public static QnConnectionClass[] mConDevExt;

		public static QnConnectionClass[] mConDevExtExt;

		public static BindingList<string> mPortName;

		public static BindingList<int> mPortBautRate;

		private volatile ResetState mFlkTabResetState;

		private static bool bmIsConnected = false;

		private static volatile int mResponseCheckCount = 0;

		private static int mBautRate = 460800;

		private object mDat = new object();

		private int workaround_count;

		private byte[] workaround_databuf = new byte[6];

		private static Mutex mMutexResearvedData = new Mutex();

		private byte[][] sReserved;

		private IContainer components;

		private CnButton btn_Connect;

		private SaveFileDialog saveFileDialog1;

		private CnButton btn_OpenCreateProject;

		private CnButton btn_FixedSetting;

		private RadioButton radioBn_Z4;

		private RadioButton radioBn_Z7;

		private RadioButton radioBn_Z6;

		private RadioButton radioBn_Z5;

		private RadioButton radioBn_Z3;

		private RadioButton radioBn_Z2;

		private RadioButton radioBn_Z1;

		private RadioButton radioBn_Z0;

		private TableLayoutPanel tabpnl_dummy;

		private OpenFileDialog openFileDialog_componentfile;

		private ContextMenuStrip contextMenuStrip_pcbedit_cell;

		private ToolStripMenuItem toolStripMenuItem_fill0;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem toolStripMenuItem_fill1;

		private ToolStripMenuItem toolStripMenuItem_fill2;

		private ToolStripMenuItem toolStripMenuItem_fill3;

		private ToolStripMenuItem toolStripMenuItem_fill4;

		private ToolStripMenuItem toolStripMenuItem_fill5;

		private ToolStripMenuItem toolStripMenuItem_fillmanual;

		private Label label_projectname;

		private ContextMenuStrip contextMenuStrip_pcbcat_cell;

		private CnButton button_ProjectClose;

		private BindingSource bindingSource1;

		private Label label_smtdevicetype;

		private ContextMenuStrip contextMenuStrip_smtlist;

		private FolderBrowserDialog folderBrowserDialog_Para;

		private Panel panel_head;

		private Panel panel_nozzle1;

		private Label label_platform;

		private CnButton button_DeviceCalibraion;

		private CnButton button_minize;

		private Panel panel_color;

		private TrackBar trackBar_color_b;

		private TrackBar trackBar_color_g;

		private TrackBar trackBar_color_r;

		private TabPage tabPage22;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private Panel panel_nozzle2;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private RadioButton radioButton3;

		private RadioButton radioButton4;

		private RadioButton radioButton5;

		private RadioButton radioButton6;

		private RadioButton radioButton7;

		private RadioButton radioButton8;

		private TabControl tabControl_dsq;

		private TabPage tabPage_dsq1F;

		private TabPage tabPage_dsq2F;

		private TabControl tabControl_temp;

		private Label label_simulation;

		private Label label_hi_title;

		private CnButton cnButton_exit;

		private CnButton cnButton_AHD8Test;

		private static string sdefault = "";

		public BindingList<ChipBoardElement> importList;

		private int selectrowindex = -1;

		private ToolStripMenuItem[] ts_sn;

		private ToolStripMenuItem[] toolStripMenuItem_SetMark;

		private TextBox[] textBox_mark;

		private Label[] label_titles_mark;

		private Label[] label_xy_mark;

		private Button[] button_mark_save;

		private Button[] button_mark_goto;

		private PictureBox[] pictureBox_Sign;

		private Coordinate[] fill_signxy;

		private static RAWSTREAM_DIRECT_READ_CALLBACK ahd_callback_fn;

		public static bool is_ahd_callbackmode = true;

		private static volatile bool[] is_ahd_start_capture;

		private static byte[][] pYuvBuffer;

		private static byte[][] pRgb32Buffer;

		public static volatile Coordst[] mCur;

		public static volatile int[] mZn;

		public static volatile int[] mZn_prev;

		public static RadioButton[][] radiobt_zn;

		public static Panel[] panel_nozzle;

		public static string mDeviceName = "";

		private BindingList<string> mDevStringlist = new BindingList<string>();

		public bool mIsHCamCalibration;

		public static USR_DATA[] USR;

		public static USR_INIT_DATA USR_INIT;

		public static FootPrintPath FP_PATH;

		public int temperror;

		public static Bitmap[][] newBitmaps_des = null;

		public static volatile bool mIsDebug_Visual = false;

		private int test_pic_index;

		public static int test_pic_num = 0;

		public static string[][] STACK_SEL_STR = new string[4][]
		{
			new string[3] { "普通飞达", "普通飞达", "FEEDER" },
			new string[3] { "料盘", "料盘", "PLATE" },
			new string[3] { "振动飞达", "振动飞达", "VIBRA FEEDER" },
			new string[3] { "通用视觉", "通用视觉", "VISUAL SETTING" }
		};

		public Button[] button_stacksel;

		public Label[] label_stack_pikZnName;

		public Label[] label_stack_pikH;

		public NumericUpDown[][] numericUpDown_stack_pikConfig;

		public Label[] label_stack_mntZnName;

		public Label[] label_stack_mntH;

		public NumericUpDown[][] numericUpDown_stack_mntConfig;

		public Label[] label_stack_threshold;

		public Label[] label_stack_nozzleEnName;

		public static bool is_jvs_init_success = false;

		private bool b_debug_hv_preview;

		public static Form_LabPrintfoot mForm_LabPrintfoot = null;

		public static string str_wind_sw_state = "";

		public static string str_wind_keytime = "";

		public static string waiting_str = "正在运行，请稍后";

		public static int waiting_milislots = 3;

		public static int waiting_str_lines = 1;

		public static Form_Waiting waiting_form;

		public static volatile bool[] mIsBuzzerWarning;

		public static bool mIsOpen_PcbArrayPage = false;

		public static bool mIsOpen_PcbMarkPage = false;

		public static bool mIsOpen_PcbImportPage = false;

		public static Form_Debug mDebugForm;

		public static Form_DebugDSQ mDebugFormDSQ;

		public static Form_DebugTRAN4 mDebugFormTRAN4;

		public static bool[] mFastCamLedState;

		public static bool[] mHighCamLedState;

		private SmtHeadSt[] mSmtHeadSt = new SmtHeadSt[15]
		{
			new SmtHeadSt
			{
				Lb = "是否贴装",
				W = 50
			},
			new SmtHeadSt
			{
				Lb = "位号",
				W = 50
			},
			new SmtHeadSt
			{
				Lb = "型号",
				W = 55
			},
			new SmtHeadSt
			{
				Lb = "供料",
				W = 50
			},
			new SmtHeadSt
			{
				Lb = "料站号",
				W = 45
			},
			new SmtHeadSt
			{
				Lb = "X坐标",
				W = 60
			},
			new SmtHeadSt
			{
				Lb = "Y坐标",
				W = 60
			},
			new SmtHeadSt
			{
				Lb = "角度",
				W = 55
			},
			new SmtHeadSt
			{
				Lb = "拼板",
				W = 50
			},
			new SmtHeadSt
			{
				Lb = "吸嘴号",
				W = 45
			},
			new SmtHeadSt
			{
				Lb = "相机",
				W = 80
			},
			new SmtHeadSt
			{
				Lb = "视觉算法",
				W = 80
			},
			new SmtHeadSt
			{
				Lb = "封装",
				W = 80
			},
			new SmtHeadSt
			{
				Lb = "轮组",
				W = 30
			},
			new SmtHeadSt
			{
				Lb = "降速搬运",
				W = 50
			}
		};

		private string[] mSmtHeadString = new string[15]
		{
			"是否贴装", "位号", "型号", "供料", "料站号", "X坐标", "Y坐标", "角度", "拼板", "吸嘴号",
			"相机", "视觉算法", "封装", "轮组", "降速搬运"
		};

		public static int mSmtCurAllProjectChips_Index = 0;

		public static int mSmtCurAllProjectPcb_Index = 0;

		public static volatile bool[][][] mIsFeederReady;

		public static volatile bool[][] mIsVacuumOn;

		public static volatile bool[][] mIsFeederOn;

		private int m_system_version;

		public static RECT mRect;

		private Size mRectSize;

		private IntPtr[] mRectHandle;

		private Point mRectPanelPoint;

		public static int[] mJVSPreviewWinRC;

		public static volatile ResetState[] mResetState2 = null;

		public static volatile byte[] mComSubCmdTag = null;

		public static UserControl_CamPara uc_campara = null;

		public static Visual_Form[] mVisualForm = null;

		public static volatile bool mMutex_PushButton = false;

		public static volatile bool mIsNoLight = false;

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moondebug_calibration();

		private void button_camera_calibration_debug_Click(object sender, EventArgs e)
		{
			moondebug_calibration();
		}

		public static int feederinstall_reflush(int fn)
		{
			BindingList<SmtFeederInstallElement>[] array = new BindingList<SmtFeederInstallElement>[3];
			for (int i = 0; i < 3; i++)
			{
				array[i] = new BindingList<SmtFeederInstallElement>();
			}
			if (USR3B[fn].mPointlistCat == null)
			{
				return -2;
			}
			for (int j = 0; j < USR3B[fn].mPointlistCat.Count; j++)
			{
				for (int k = 0; k < USR3B[fn].mPointlistCat[j].MultiFeeders; k++)
				{
					SmtFeederInstallElement smtFeederInstallElement = new SmtFeederInstallElement(USR_INIT.mLanguage);
					smtFeederInstallElement.Count = USR3B[fn].mPointlistCat[j].Count;
					smtFeederInstallElement.Feedertype = USR3B[fn].mPointlistCat[j].Feedertype;
					smtFeederInstallElement.Footprint = USR3B[fn].mPointlistCat[j].Footprint;
					smtFeederInstallElement.IsInserted = false;
					smtFeederInstallElement.Material_value = USR3B[fn].mPointlistCat[j].Material_value;
					smtFeederInstallElement.Stack_no = USR3B[fn].mPointlistCat[j].feeder_no[k];
					smtFeederInstallElement.Height = USR3B[fn].mPointlistCat[j].Height;
					smtFeederInstallElement.Stacktype = format_feeder_to_providertype(USR3B[fn].mPointlistCat[j].Feedertype);
					array[(int)smtFeederInstallElement.Stacktype].Add(smtFeederInstallElement);
					ProviderType providerType = format_feeder_to_providertype(USR3B[fn].mPointlistCat[j].Feedertype);
					if (smtFeederInstallElement.Stack_no > 0)
					{
						USR2[fn].mStackLib.stacktab[(int)providerType][smtFeederInstallElement.Stack_no - 1].height = smtFeederInstallElement.Height;
						USR2[fn].mStackLib.stacktab[(int)providerType][smtFeederInstallElement.Stack_no - 1].visualtype = USR3B[fn].mPointlistCat[j].Visualtype;
						USR2[fn].mStackLib.stacktab[(int)providerType][smtFeederInstallElement.Stack_no - 1].cameratype = USR3B[fn].mPointlistCat[j].Cameratype;
					}
				}
			}
			int[] array2 = HW.mStackNum[fn];
			for (int l = 0; l < 3; l++)
			{
				for (int m = 0; m < array[l].Count; m++)
				{
					if (array[l][m].Feedertype == FeederType.N_A || array[l][m].Stack_no <= 0 || array[l][m].Stack_no > array2[l])
					{
						return -1;
					}
				}
			}
			if (USR3B[fn].mFeederInstallList == null)
			{
				USR3B[fn].mFeederInstallList = new BindingList<SmtFeederInstallElement>();
			}
			USR3B[fn].mFeederInstallList.Clear();
			for (int n = 0; n < 3; n++)
			{
				SmtFeederInstallElement[] array3 = array[n].OrderBy((SmtFeederInstallElement a) => a.Stack_no).ToArray();
				if (array3 != null)
				{
					for (int num = 0; num < array[n].Count; num++)
					{
						USR3B[fn].mFeederInstallList.Add(array3[num]);
					}
				}
			}
			update_usr2_stacks_used_show(fn);
			update_usr2_stacks_used_nozzles(fn);
			return 0;
		}

		private bool vsplus_nozzledelta_auto_center_loop()
		{
			bool flag = false;
			Invoke((MethodInvoker)delegate
			{
				pictureBox_visualrunning[mFn].Visible = true;
				pictureBox_visualrunning[mFn].BringToFront();
			});
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			int num = 0;
			int num2 = 0;
			visual_result.is_test = true;
			while (true)
			{
				if (mIsVisualRunning)
				{
					if (ImageVisual(mFn, VISUAL_MODE.AUTODELTA_MARK, CameraType.Mark, VisualType.Circle, USR[mFn].mcir_nz_scanr, USR[mFn].mcir_nz_threshold, 0, 0, 0, 0f, ref visual_result) != 0)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Did not detect point， please try to adjust Threshold!" : "没有识别到圆点,请尝试调节视觉阈值等参数！");
						flag = false;
						break;
					}
					if (Math.Abs(visual_result.move_x) > num || Math.Abs(visual_result.move_y) > num)
					{
						if (num2++ == 10)
						{
							if (num >= 3)
							{
								CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Detect fail, please check the ink Points!" : "识别错误，请检查扎点是否完整！");
								flag = false;
								break;
							}
							num2 = 0;
							num++;
						}
						moveToXY_andWait(mFn, USR[mFn].mXYSpeed, new Coordinate(mCur[mFn].x - visual_result.move_x, mCur[mFn].y + visual_result.move_y));
						continue;
					}
				}
				flag = true;
				break;
			}
			Invoke((MethodInvoker)delegate
			{
				pictureBox_visualrunning[mFn].Visible = false;
			});
			return flag;
		}

		private bool initConnection_gen0()
		{
			sReserved = new byte[mPortName.Count][];
			mMutexResearvedData = new Mutex();
			mComUsingList = new BindingList<QnConnectionClass>();
			mCom = new QnConnectionClass[mPortName.Count];
			mConDev = new QnConnectionClass[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mConDev[i] = null;
			}
			mConDevExt = new QnConnectionClass[HW.mFnNum];
			for (int j = 0; j < HW.mFnNum; j++)
			{
				mConDevExt[j] = null;
			}
			mConDevExtExt = new QnConnectionClass[HW.mFnNum];
			for (int k = 0; k < HW.mFnNum; k++)
			{
				mConDevExtExt[k] = null;
			}
			mResetState2 = new ResetState[HW.mFnNum];
			for (int l = 0; l < HW.mFnNum; l++)
			{
				mResetState2[l] = ResetState.Unknown;
			}
			if (USR_INIT.mDeviceType == DeviceType.HW_6 || USR_INIT.mDeviceType == DeviceType.HW_4_42 || USR_INIT.mDeviceType == DeviceType.HW_4_50 || USR_INIT.mDeviceType == DeviceType.HW_4SG_50 || USR_INIT.mDeviceType == DeviceType.HW_4SG_44)
			{
				int num = 0;
				for (int m = 0; m < mPortName.Count; m++)
				{
					mCom[m] = new QnConnectionClass(m, mIsSimulation);
					if (mCom[m].Open(mPortName[m], mPortBautRate[m] / 2))
					{
						mCom[m].ClearDataBuffer();
						mCom[m].sendWrong();
						mCom[m].Close();
						mCom[m].DataReceived += mSerialPort_DataReceived;
						mCom[m].ERRORReceived += mSerialPort_ERRORReceived;
						mCom[m].LogMessage += mSerialPort_LogMessage;
						if (mCom[m].Open(mPortName[m], mPortBautRate[m]))
						{
							mCom[m].ClearDataBuffer();
							QnCommon.mComType = 255;
							mCom[m].sendReadVersion();
							DateTime now = DateTime.Now;
							bool flag = false;
							while (QnCommon.mComType == 255)
							{
								DateTime now2 = DateTime.Now;
								if ((now2 - now).TotalMilliseconds > 1000.0)
								{
									flag = true;
									write_to_logFile(mLogFileName, "E:" + mPortName[m] + Environment.NewLine);
									break;
								}
							}
							if (flag)
							{
								mCom[m].Close();
								continue;
							}
							num++;
							mConDev[0] = mCom[m];
							mComUsingList.Add(mCom[m]);
							static_firmware_version[0] = QnCommon.sBaseVersion + " " + QnCommon.mComType.ToString("X2");
							write_to_logFile(mLogFileName, "下位机：" + QnCommon.sBaseVersion + Environment.NewLine);
						}
						if (num != HW.mConNum)
						{
							CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Connect Fail, please check power/cables!" : "设备连接失败，请检查电源/连线正确之后重启软件");
							Environment.Exit(0);
							return false;
						}
						mConDev[mFn].sendMaxXYDistance(0);
						DateTime now3 = DateTime.Now;
						for (double totalMilliseconds = (DateTime.Now - now3).TotalMilliseconds; totalMilliseconds <= 300.0; totalMilliseconds = (DateTime.Now - now3).TotalMilliseconds)
						{
						}
						mConDev[mFn].sendMaxZDistance(0);
						mCur[0].x = 0;
						mCur[0].y = 0;
						for (int n = 0; n < HW.mZnNum[0]; n++)
						{
							mCur[0].z[n] = 0;
							mCur[0].a[n] = 0;
						}
						mResetState2[0] = ResetState.Unknown;
						mConDev[0].sendReset();
						while (mResetState2[0] == ResetState.Unknown)
						{
							Thread.Sleep(1);
						}
						if (mResetState2[0] == ResetState.Fail)
						{
							CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "复位失败，请重启机器！");
							Environment.Exit(0);
							return false;
						}
						mConDevExt[0] = mConDev[0];
						for (int num2 = 0; num2 < HW.mZnNum[0]; num2++)
						{
							misc_vacc_onoff(0, num2, 0);
						}
						for (int num3 = 0; num3 < HW.mStackNum[0][0]; num3++)
						{
							misc_feeder_onoff(0, ProviderType.Feedr, num3, flag: false);
						}
						mConDev[0].sendBuzzerOnOff(0);
						mConDev[0].readOpenShapeStatus();
						mConDev[0].readFeederGoodbyeStatus();
						mConDevExt[0].sendTrackSpeed(10 - USR[0].mTrackSpeed);
						mConDevExt[0].sendTrackDelay((int)(USR[0].mTrackDelay * 10f));
						bmIsConnected = true;
						mark_lightlevel_set(0);
						mark_light_on(0, USR[0].mMarkCamPara[USR[0].mMarkCamParaIndex].mLightOn);
						mark_led_on(0, USR[0].mMarkCamPara[USR[0].mMarkCamParaIndex].mLedOn);
						continue;
					}
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Connect Fail, please check cables1!" : "贴片机通信失效，关闭软件，检查连接线1");
					return false;
				}
			}
			else if (USR_INIT.mDeviceType == DeviceType.HW_8S || USR_INIT.mDeviceType == DeviceType.HW_6S || USR_INIT.mDeviceType == DeviceType.HW_6SX || USR_INIT.mDeviceType == DeviceType.HW_8S_PLUS || USR_INIT.mDeviceType == DeviceType.HW_8SX_72F || USR_INIT.mDeviceType == DeviceType.HW_8SX || USR_INIT.mDeviceType == DeviceType.HW_8SX_1200 || USR_INIT.mDeviceType == DeviceType.HW_8SP_1200 || USR_INIT.mDeviceType == DeviceType.HW_6_FLK || USR_INIT.mDeviceType == DeviceType.HW_6_TRANSFER || USR_INIT.mDeviceType == DeviceType.HW_DT408H || USR_INIT.mDeviceType == DeviceType.HW_6_TRAN2 || USR_INIT.mDeviceType == DeviceType.HW_6S_TRAN3 || USR_INIT.mDeviceType == DeviceType.HW_8S_TRAN4 || USR_INIT.mDeviceType == DeviceType.HW_6S_TRAN4)
			{
				int num4 = 0;
				for (int num5 = 0; num5 < mPortName.Count; num5++)
				{
					mCom[num5] = new QnConnectionClass(num5, mIsSimulation);
					if (mCom[num5].Open(mPortName[num5], mPortBautRate[num5] / 2))
					{
						mCom[num5].ClearDataBuffer();
						mCom[num5].sendWrong();
						mCom[num5].Close();
						mCom[num5].DataReceived += mSerialPort_DataReceived;
						mCom[num5].ERRORReceived += mSerialPort_ERRORReceived;
						mCom[num5].LogMessage += mSerialPort_LogMessage;
						if (!mCom[num5].Open(mPortName[num5], mPortBautRate[num5]))
						{
							continue;
						}
						mCom[num5].ClearDataBuffer();
						QnCommon.mComType = 255;
						mCom[num5].sendReadVersion();
						DateTime now4 = DateTime.Now;
						bool flag2 = false;
						while (QnCommon.mComType == 255)
						{
							DateTime now5 = DateTime.Now;
							if ((now5 - now4).TotalMilliseconds > 1000.0)
							{
								write_to_logFile(mLogFileName, "E:" + mPortName[num5] + Environment.NewLine);
								flag2 = true;
								break;
							}
						}
						if (flag2)
						{
							mCom[num5].Close();
							continue;
						}
						write_to_logFile(mLogFileName, QnCommon.mComType.ToString("X") + "：" + QnCommon.sBaseVersion + Environment.NewLine);
						mCom[num5].SetComType(QnCommon.mComType);
						if (QnCommon.mComType == 160)
						{
							static_firmware_version[0] = QnCommon.sBaseVersion + " " + QnCommon.mComType.ToString("X2");
							num4++;
							mConDev[0] = mCom[num5];
							mComUsingList.Add(mCom[num5]);
						}
						else if (QnCommon.mComType == 161)
						{
							static_firmware_version[1] = QnCommon.sBaseVersion + " " + QnCommon.mComType.ToString("X2");
							num4++;
							mConDevExt[0] = mCom[num5];
							mComUsingList.Add(mCom[num5]);
						}
						else if (QnCommon.mComType == 174)
						{
							static_firmware_version[2] = QnCommon.sBaseVersion + " " + QnCommon.mComType.ToString("X2");
							num4++;
							mConDevExtExt[0] = mCom[num5];
							mComUsingList.Add(mCom[num5]);
						}
						continue;
					}
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Connect Fail, please check cables1!" : ("贴片机通信失效，关闭软件，检查连接线1--" + num5));
					return false;
				}
				if (num4 != HW.mConNum)
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Connect Fail, please check power/cables!" : "设备连接失败，请检查电源/连线正确之后重启软件");
					write_to_logFile(mLogFileName, "连接失败:" + num4 + "个有效端口" + Environment.NewLine);
					Environment.Exit(0);
					return false;
				}
				if (mConDevExt[0] == null)
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot find the Second MainBoard!" : "未发现副控制板");
					return false;
				}
				if (mConDev[0] == null)
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot find the MainBoard!" : "未发现主控制板");
					return false;
				}
				mConDev[0].sendMaxXYDistance(0);
				if (USR_INIT.mDeviceType == DeviceType.HW_6_FLK)
				{
					mConDevExt[0].sendMaxFLKTABXDistance();
				}
				DateTime now6 = DateTime.Now;
				for (double totalMilliseconds2 = (DateTime.Now - now6).TotalMilliseconds; totalMilliseconds2 <= 300.0; totalMilliseconds2 = (DateTime.Now - now6).TotalMilliseconds)
				{
				}
				if (USR_INIT.mDeviceType == DeviceType.HW_6_FLK)
				{
					now6 = DateTime.Now;
					for (double totalMilliseconds2 = (DateTime.Now - now6).TotalMilliseconds; totalMilliseconds2 <= 300.0; totalMilliseconds2 = (DateTime.Now - now6).TotalMilliseconds)
					{
					}
				}
				mConDev[0].sendMaxZDistance(0);
				mCur[mFn].x = 0;
				mCur[mFn].y = 0;
				for (int num6 = 0; num6 < HW.mZnNum[mFn]; num6++)
				{
					mCur[mFn].z[num6] = 0;
					mCur[mFn].a[num6] = 0;
				}
				mResetState2[0] = ResetState.Unknown;
				mConDev[0].sendReset();
				while (mResetState2[0] == ResetState.Unknown)
				{
					Thread.Sleep(1);
				}
				if (mResetState2[0] == ResetState.Fail)
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "复位失败，请重启机器！");
					Environment.Exit(0);
					return false;
				}
				if (HW.mZnNum[0] == 8 || HW.mZnNum[0] == 6)
				{
					mConDev[0].sendFNOFB(HW.malgo2[0].slt_l[0] + HW.malgo2[0].slt_r[0]);
					msdelay(100);
				}
				for (int num7 = 0; num7 < HW.mZnNum[0]; num7++)
				{
					misc_vacc_onoff(0, num7, 0);
				}
				for (int num8 = 0; num8 < HW.mStackNum[0][0]; num8++)
				{
					misc_feeder_onoff(0, ProviderType.Feedr, num8, flag: false);
					mConDev[0].sendBuzzerOnOff(0);
				}
				if (USR_INIT.mDeviceType != DeviceType.HW_6_FLK)
				{
					mConDevExt[0].send_inboard_reset();
					msdelay(200);
					mConDevExt[0].ClearDataBuffer();
					sReserved[mConDevExt[0].mCno] = null;
					QnCommon.mComType = 255;
					mConDevExt[0].sendReadVersion();
					DateTime now7 = DateTime.Now;
					bool flag3 = false;
					while (QnCommon.mComType == 255)
					{
						DateTime now8 = DateTime.Now;
						if ((now8 - now7).TotalMilliseconds > 1000.0)
						{
							write_to_logFile(mLogFileName, "E:" + mPortName[mConDevExt[0].mCno] + Environment.NewLine);
							flag3 = true;
							break;
						}
					}
					if (flag3)
					{
						mConDevExt[0].Close();
						write_to_logFile("进板贴板模式设置初始化失败!");
						CmMessageBoxTop_Ok("进板贴板模式设置初始化失败!");
					}
					write_to_logFile("进板贴板模式设置初始化：0x" + QnCommon.mComType.ToString("X2"));
					mConDevExt[0].send_inboard_mode((USR_INIT.mInBoard_Mode == 1) ? 1 : 0);
					mConDevExt[0].sendTrackSpeed(10 - USR[0].mTrackSpeed);
					mConDevExt[0].sendTrackDelay((int)(USR[0].mTrackDelay * 10f));
				}
				if (USR_INIT.mDeviceType == DeviceType.HW_6S_TRAN3)
				{
					mConDevExtExt[0].sendTran3Speed(0, USR[0].mTran3_Speed0);
					mConDevExtExt[0].sendTran3Delay(0, (int)(USR[0].mTran3_Delay0 * 10f));
					mConDevExtExt[0].sendTran3Speed(1, USR[0].mTran3_Speed1);
					mConDevExtExt[0].sendTran3Delay(1, (int)(USR[0].mTran3_Delay1 * 10f));
				}
				if (HW.mDeviceType == DeviceType.HW_6_TRANSFER || HW.mDeviceType == DeviceType.HW_6_TRAN2)
				{
					mConDevExt[0].send_transfer_plateempty(0);
					mConDevExt[0].send_transfer_smttaskrun(0);
					mConDevExt[0].send_transfer_smtdone(0, 0);
					mConDevExt[0].send_transfer_smtdone(1, 0);
				}
				bmIsConnected = true;
			}
			if (mConDev[0] == null || mConDevExt[0] == null)
			{
				CmMessageBoxTop_Ok("连接设备失败，请检查供电等情况!");
				Environment.Exit(0);
				return false;
			}
			mConDev[0].readOpenShapeStatus();
			mConDev[0].readFeederGoodbyeStatus();
			mConDevExt[0].send_trackspeedbase(USR_INIT.mTrackSpeedBase);
			set_warningalarm_idle();
			mark_lightlevel_set(0);
			mark_light_on_ext(0, USR[0].mMarkCamPara[USR[0].mMarkCamParaIndex].mLightOn);
			mark_led_on_ext(0, USR[0].mMarkCamPara[USR[0].mMarkCamParaIndex].mLedOn);
			return true;
		}

		private void init_camera_driver_only_once()
		{
			mJvs_State = false;
			mJvs_Channels = 0;
			create_jvsFile();
			mJvs_rawWidth = CAMS.META[(int)mJvsDriver].rawsize.Width;
			mJvs_rawHeight = CAMS.META[(int)mJvsDriver].rawsize.Height;
			mJvs_usrWidth = CAMS.META[(int)mJvsDriver].usrsize.Width;
			mJvs_usrHeight = CAMS.META[(int)mJvsDriver].usrsize.Height;
			mJVS_OpenedPreviewMask = 0;
			if (mJvsDriver == JvsDriver.MV360 || mJvsDriver == JvsDriver.AHD8)
			{
				mMarkPreviewRatio = 1.30909085f;
			}
			else
			{
				mMarkPreviewRatio = 1f;
			}
			pKSJBuffer = new byte[HW.mCamBTotalNum * 8][];
			for (int i = 0; i < HW.mCamBTotalNum * 8; i++)
			{
				byte[] array = new byte[mKSJ_VWsize * mKSJ_VHsize * 3];
				pKSJBuffer[i] = array;
			}
			bKSJCameraRecived = new bool[HW.mCamBTotalNum * 8];
			for (int j = 0; j < HW.mCamBTotalNum * 8; j++)
			{
				bKSJCameraRecived[j] = false;
			}
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				bJVSCameraRecived = new bool[12];
				for (int k = 0; k < 12; k++)
				{
					bJVSCameraRecived[k] = false;
				}
				mJVSBitmap = new Bitmap[12];
				mJVSBitmap_Data = new BitmapData[12];
				for (int l = 0; l < 12; l++)
				{
					mJVSBitmap[l] = new Bitmap(mJvs_rawWidth, mJvs_rawHeight, PixelFormat.Format32bppRgb);
					mJVSBitmap_Data[l] = null;
				}
				ulong num = (ulong)(mJvs_rawWidth * mJvs_rawHeight * 2);
				pYuvBuffer = new byte[12][];
				for (int m = 0; m < 12; m++)
				{
					pYuvBuffer[m] = new byte[num];
				}
				pRgb32Buffer = new byte[12][];
				for (int n = 0; n < 12; n++)
				{
					pRgb32Buffer[n] = new byte[mJvs_rawWidth * mJvs_rawHeight * 4];
				}
			}
			else if (mJvsDriver == JvsDriver.MV360 || mJvsDriver == JvsDriver.AHD8)
			{
				bJVSCameraRecived = new bool[12];
				for (int num2 = 0; num2 < 12; num2++)
				{
					bJVSCameraRecived[num2] = false;
				}
				mJVSBitmap = new Bitmap[12];
				mJVSBitmap_Data = new BitmapData[12];
				for (int num3 = 0; num3 < 12; num3++)
				{
					mJVSBitmap[num3] = new Bitmap(mJvs_rawWidth, mJvs_rawHeight, PixelFormat.Format32bppRgb);
					mJVSBitmap_Data[num3] = null;
				}
			}
			else
			{
				bJVSCameraRecived = new bool[12];
				for (int num4 = 0; num4 < 12; num4++)
				{
					bJVSCameraRecived[num4] = false;
				}
				mJVSBitmap = new Bitmap[12];
				mJVSBitmap_Data = new BitmapData[12];
				for (int num5 = 0; num5 < 12; num5++)
				{
					mJVSBitmap[num5] = new Bitmap(mJvs_rawWidth, mJvs_rawHeight, PixelFormat.Format32bppRgb);
					mJVSBitmap_Data[num5] = null;
				}
			}
			stillMutex = new Semaphore(1, 1);
		}

		private void uninitCamera()
		{
			release_camera();
		}

		private bool init_fastcam()
		{
			if (USR_INIT.misfcam_def_channel)
			{
				for (int i = 0; i < HW.mZnNum[0]; i++)
				{
					HW.mFastCamItem[0].index[i] = USR_INIT.fcam_def_channel[i];
				}
				HW.mMarkCamItem[0].index[0] = USR_INIT.mark_def_channel;
			}
			if (mJvsDriver == JvsDriver.MV360)
			{
				mJvs_State = initAHD();
			}
			else if (mJvsDriver == JvsDriver.AHD8)
			{
				mJvs_State = initAHD8();
			}
			else if (mJvsDriver == JvsDriver.JW6008HT)
			{
				mJvs_State = initHVC();
			}
			else if ((mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S) && (HW.mMarkCamItem[0].type == "CAM_JVS" || HW.mFastCamItem[0].type == "CAM_JVS"))
			{
				mJvs_State = initJVS();
			}
			openMarkCam(mFn);
			write_to_logFile("快速相机初始化完成" + mJvsDriver);
			return mJvs_State;
		}

		private bool init_highcam()
		{
			if (mKsjDriver == JvsDriver.NONE)
			{
				mDriverState_KSJ = true;
				return mDriverState_KSJ;
			}
			if (HW.mHighCamItem[0].type == "CAM_KSJ")
			{
				uninitKSJ();
				mDriverState_KSJ = false;
				mDriverState_KSJ = initKSJ();
				write_to_logFile("高清相机初始化完成");
				return mDriverState_KSJ;
			}
			return false;
		}

		private void uninit_fastcam()
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				uninitHVC();
				mJvs_State = false;
			}
			else if (mJvsDriver == JvsDriver.MV360)
			{
				uninitAHD();
				mJvs_State = false;
			}
			else if (mJvsDriver == JvsDriver.AHD8)
			{
				uninitAHD8();
				mJvs_State = false;
			}
			else if ((mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S) && (HW.mMarkCamItem[0].type == "CAM_JVS" || HW.mFastCamItem[0].type == "CAM_JVS"))
			{
				uninitJVS();
			}
		}

		private void uninit_highcam()
		{
			if (mKsjDriver == JvsDriver.NONE)
			{
				mDriverState_KSJ = false;
			}
			else if (HW.mHighCamItem[0].type == "CAM_KSJ" && mDriverState_KSJ)
			{
				uninitKSJ();
				mDriverState_KSJ = false;
			}
		}

		private void release_camera()
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				uninitHVC();
				mJvs_State = false;
			}
			else if (mJvsDriver == JvsDriver.MV360)
			{
				uninitAHD();
				mJvs_State = false;
			}
			else if (mJvsDriver == JvsDriver.AHD8)
			{
				uninitAHD8();
				mJvs_State = false;
			}
			else if ((mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S) && (HW.mMarkCamItem[0].type == "CAM_JVS" || HW.mFastCamItem[0].type == "CAM_JVS"))
			{
				uninitJVS();
			}
			if (HW.mHighCamItem[0].type == "CAM_KSJ" && mDriverState_KSJ)
			{
				uninitKSJ();
				mDriverState_KSJ = false;
			}
		}

		public bool openMarkCam(int fn)
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				return openHVCPreview(HW.mMarkCamItem[fn].index[0]);
			}
			if (mJvsDriver == JvsDriver.MV360)
			{
				return openAHDPreview(HW.mMarkCamItem[fn].index[0]);
			}
			if (mJvsDriver == JvsDriver.AHD8)
			{
				return openAHD8Preview(HW.mMarkCamItem[fn].index[0]);
			}
			if (mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S)
			{
				closeJVSPreview(fn);
				return openJVSPreview(HW.mMarkCamItem[fn].index[0]);
			}
			return false;
		}

		public static void closeMarkCam(int fn)
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				closeHVCPreview(fn);
			}
			else if (mJvsDriver == JvsDriver.MV360)
			{
				closeAHDPreview(fn);
			}
			else if (mJvsDriver == JvsDriver.AHD8)
			{
				closeAHD8Preview(fn);
			}
			else
			{
				closeJVSPreview(fn);
			}
		}

		private bool openFastCam(int fn, int zn)
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				return openHVCPreview(HW.mFastCamItem[fn].index[zn]);
			}
			if (mJvsDriver == JvsDriver.MV360)
			{
				return openAHDPreview(HW.mFastCamItem[fn].index[zn]);
			}
			if (mJvsDriver == JvsDriver.AHD8)
			{
				return openAHD8Preview(HW.mFastCamItem[fn].index[zn]);
			}
			if (mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S)
			{
				closeJVSPreview(fn);
				return openJVSPreview(HW.mFastCamItem[fn].index[zn]);
			}
			return false;
		}

		private void closeFastCam(int fn)
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				closeHVCPreview(fn);
			}
			else if (mJvsDriver == JvsDriver.MV360)
			{
				closeAHDPreview(fn);
			}
			else if (mJvsDriver == JvsDriver.AHD8)
			{
				closeAHD8Preview(fn);
			}
			else if (mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S)
			{
				closeJVSPreview(fn);
			}
		}

		private bool openHighCam(int fn)
		{
			closeKSJPreview(fn);
			return openKSJPreview(HW.mHighCamItem[fn].index[0]);
		}

		private void closeHighCam(int fn)
		{
			closeKSJPreview(fn);
		}

		private void updateZnChangedCameraShow(int fn)
		{
			if (mCurCam[fn] == CameraType.Fast)
			{
				closeFastCam(fn);
				openFastCam(fn, mZn[fn]);
			}
		}

		public void vsplus_reopen_preview(int fn)
		{
			if (!mIsSimulation)
			{
				if ((mJvsDriver == JvsDriver.MV360 || mJvsDriver == JvsDriver.AHD8) && (mCurCam[fn] == CameraType.Mark || mCurCam[fn] == CameraType.Fast))
				{
					ahd_flush_preview(fn);
				}
				if (mCurCam[fn] == CameraType.Mark)
				{
					closeMarkCam(fn);
					openMarkCam(fn);
				}
				else if (mCurCam[fn] == CameraType.Fast)
				{
					closeFastCam(fn);
					openFastCam(fn, mZn[fn]);
				}
				else if (mCurCam[fn] == CameraType.High)
				{
					closeHighCam(fn);
					openHighCam(fn);
				}
			}
		}

		private void vsplus_switch_to_camera(int fn, CameraType cam)
		{
			if (mIsSimulation)
			{
				mCurCam[fn] = cam;
				return;
			}
			switch (cam)
			{
			case CameraType.Mark:
				closeFastCam(fn);
				closeHighCam(fn);
				openMarkCam(fn);
				break;
			case CameraType.Fast:
				closeMarkCam(fn);
				closeHighCam(fn);
				openFastCam(fn, mZn[fn]);
				break;
			case CameraType.High:
				closeMarkCam(fn);
				closeFastCam(fn);
				openHighCam(fn);
				break;
			}
			mCurCam[fn] = cam;
		}

		public static void startFastStill_andWait(CameraType camtype, int fn, int zn)
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				startHVCStill_andWait(camtype, fn, zn);
			}
			else if (mJvsDriver == JvsDriver.MV360)
			{
				startAHDStill_andWait(camtype, fn, zn);
			}
			else if (mJvsDriver == JvsDriver.AHD8)
			{
				startAHD8Still_andWait(camtype, fn, zn);
			}
			else if (mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S)
			{
				startJVSStill_andWait(camtype, fn, zn);
			}
		}

		private void startFastStill_andWait_ImmediatelySmt(int fn, int zn, int stilldelay)
		{
			int ch = HW.mFastCamItem[fn].index[zn];
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				hvcstill_andwait(ch, stilldelay);
			}
			else if (mJvsDriver == JvsDriver.MV360)
			{
				ahdstill_andwait(ch, stilldelay);
			}
			else if (mJvsDriver == JvsDriver.AHD8)
			{
				ahd8still_andwait(ch, stilldelay);
			}
			else if (mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S)
			{
				jvsstill_andwait(ch, stilldelay);
			}
		}

		public static bool startFastStill_noWait(CameraType camtype, int fn, int zn)
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				return startHVCStill_noWait(camtype, fn, zn);
			}
			if (mJvsDriver == JvsDriver.MV360)
			{
				return startAHDStill_noWait(camtype, fn, zn);
			}
			if (mJvsDriver == JvsDriver.AHD8)
			{
				return startAHD8Still_noWait(camtype, fn, zn);
			}
			if (mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S)
			{
				return startJVSStill_noWait(camtype, fn, zn);
			}
			return true;
		}

		public static void startMarkStill_andWait(int fn)
		{
			if (mJvsDriver == JvsDriver.JW6008HT)
			{
				startHVCStill_andWait(CameraType.Mark, fn, 0);
			}
			else if (mJvsDriver == JvsDriver.MV360)
			{
				startAHDStill_andWait(CameraType.Mark, fn, 0);
			}
			else if (mJvsDriver == JvsDriver.AHD8)
			{
				startAHD8Still_andWait(CameraType.Mark, fn, 0);
			}
			else if (mJvsDriver == JvsDriver.JVS900 || mJvsDriver == JvsDriver.JVS960S)
			{
				startJVSStill_andWait(CameraType.Mark, fn, 0);
			}
		}

		public string[] Getdevice()
		{
			BindingList<string> bindingList = new BindingList<string>();
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				bindingList.Add(Convert.ToString(item["Name"]));
			}
			string[] array = new string[bindingList.Count];
			for (int i = 0; i < bindingList.Count; i++)
			{
				array[i] = bindingList[i];
			}
			return array;
		}

		public void vsplus_restart_camerapreview(int fn)
		{
			if (mCurCam[fn] == CameraType.Mark)
			{
				closeMarkCam(fn);
				openMarkCam(fn);
			}
			else if (mCurCam[fn] == CameraType.Fast)
			{
				closeFastCam(fn);
				openFastCam(fn, mZn[fn]);
			}
		}

		private JvsDriver create_jvsFile()
		{
			mJvsDriver = JvsDriver.NONE;
			mKsjDriver = JvsDriver.NONE;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
			string msg = registryKey.GetValue("ProductName").ToString();
			write_to_logFile(msg);
			if (HW.mDeviceType == DeviceType.HW_6_FLK)
			{
				mJvsDriver = JvsDriver.JVS900;
				mKsjDriver = JvsDriver.KSJ_U3C500;
			}
			else
			{
				string[] array;
				if (HW.mDeviceType == DeviceType.HW_4_50)
				{
					array = null;
					mJvsDriver = JvsDriver.JVS960S;
					mKsjDriver = JvsDriver.KSJ_U3C500;
				}
				else
				{
					array = Getdevice();
				}
				if (array != null)
				{
					for (int i = 0; i < array.Count(); i++)
					{
						if (array[i] == "JVSC960S Device")
						{
							mJvsDriver = JvsDriver.JVS960S;
							if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
							{
								break;
							}
						}
						else if (array[i] == "JVSC900 Device")
						{
							mJvsDriver = JvsDriver.JVS900;
							if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
							{
								break;
							}
						}
						else if (array[i] == "HV7000 4/8CH 960H PCIE DVR Card")
						{
							mJvsDriver = JvsDriver.JW6008HT;
							if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
							{
								break;
							}
						}
						else if (array[i] == "MV360 PCIE Capture card Driver" || array[i] == "QiGn_V PCIE Capture card Driver")
						{
							mJvsDriver = JvsDriver.MV360;
							if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
							{
								break;
							}
						}
						else if (array[i] == "QiGn_V8 PCIE Card")
						{
							mJvsDriver = JvsDriver.AHD8;
							if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
							{
								break;
							}
						}
						else if (array[i].Contains("U3C500"))
						{
							mKsjDriver = JvsDriver.KSJ_U3C500;
							if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
							{
								break;
							}
						}
					}
				}
			}
			if (mJvsDriver == JvsDriver.NONE)
			{
				write_to_logFile((USR_INIT.mLanguage == 2) ? "Fast Camera device cannot be detected!" : "未检测到快速图像视觉设备！");
			}
			if (mKsjDriver == JvsDriver.NONE)
			{
				write_to_logFile((USR_INIT.mLanguage == 2) ? "High Camera device cannot be detected!" : "未检测到高清图像视觉设备！");
			}
			if (mJvsDriver == JvsDriver.JVS960S || mJvsDriver == JvsDriver.JVS900)
			{
				File.Delete("./JVSDK.dll");
				File.Delete("./JAENC.dll");
				File.Delete("./JENC04.dll");
				File.Delete("./JENC05.dll");
				File.Delete("./JvDeinterlace.dll");
				if (mJvsDriver == JvsDriver.JVS960S)
				{
					if (File.Exists("./JVSDK960.dll"))
					{
						File.Copy("./JVSDK960.dll", "./JVSDK.dll");
						File.Copy("./JAENC_960.dll", "./JAENC.dll");
						File.Copy("./JENC04_960.dll", "./JENC04.dll");
						File.Copy("./JENC05_960.dll", "./JENC05.dll");
						File.Copy("./JvDeinterlace_960.dll", "./JvDeinterlace.dll");
					}
				}
				else if (File.Exists("./JVSDK_900legacy.dll"))
				{
					File.Copy("./JVSDK_900legacy.dll", "./JVSDK.dll");
					File.Copy("./JAENC_900legacy.dll", "./JAENC.dll");
					File.Copy("./JENC04_900legacy.dll", "./JENC04.dll");
					File.Copy("./JENC05_900legacy.dll", "./JENC05.dll");
					File.Copy("./JvDeinterlace_900legacy.dll", "./JvDeinterlace.dll");
				}
			}
			return mJvsDriver;
		}

		private void get_cameradrivertype()
		{
			mJvsDriver = JvsDriver.NONE;
			mKsjDriver = JvsDriver.NONE;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
			string msg = registryKey.GetValue("ProductName").ToString();
			write_to_logFile(msg);
			string[] array = Getdevice();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Count(); i++)
			{
				if (array[i] == "JVSC960S Device")
				{
					mJvsDriver = JvsDriver.JVS960S;
					if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
					{
						break;
					}
				}
				else if (array[i] == "JVSC900 Device")
				{
					mJvsDriver = JvsDriver.JVS900;
					if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
					{
						break;
					}
				}
				else if (array[i] == "HV7000 4/8CH 960H PCIE DVR Card")
				{
					mJvsDriver = JvsDriver.JW6008HT;
					if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
					{
						break;
					}
				}
				else if (array[i] == "MV360 PCIE Capture card Driver" || array[i] == "QiGn_V PCIE Capture card Driver")
				{
					mJvsDriver = JvsDriver.MV360;
					if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
					{
						break;
					}
				}
				else if (array[i] == "QiGn_V8 PCIE Card")
				{
					mJvsDriver = JvsDriver.AHD8;
					if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
					{
						break;
					}
				}
				else if (array[i].Contains("U3C500"))
				{
					mKsjDriver = JvsDriver.KSJ_U3C500;
					if (mJvsDriver != JvsDriver.NONE && mKsjDriver != JvsDriver.NONE)
					{
						break;
					}
				}
			}
		}

		public void create_usrProjectData()
		{
			int mSections = HW.mSections;
			USR3_INIT = new USR3_INIT_DATA();
			int fn;
			for (fn = 0; fn < HW.mFnNum; fn++)
			{
				USR2[fn] = new USR2_DATA();
				USR3B[fn] = new USR3_BASE();
				USR3B[fn].mInBoardMode = USR_INIT.mInBoard_Mode;
				__mUSR3[fn] = new USR3_DATA[mSections];
				for (int i = 0; i < mSections; i++)
				{
					__mUSR3[fn][i] = new USR3_DATA();
				}
				if (USR3B[fn].mInBoardMode == 2)
				{
					USR3B[fn].mPrjMode = 1;
					USR3B[fn].mIsPrjModeFixed = true;
					USR3B[fn].mPrjSmtMode = 1;
					__mUSR3[fn][0].mPcbID = "A";
					__mUSR3[fn][0].mPcbDescription = "对接A信号";
					__mUSR3[fn][1].mPcbID = "B";
					__mUSR3[fn][1].mPcbDescription = "对接B信号";
				}
				else if (USR3B[fn].mInBoardMode == 1)
				{
					USR3B[fn].mPrjMode = 1;
					USR3B[fn].mIsPrjModeFixed = true;
					USR3B[fn].mPrjSmtMode = 2;
					for (int j = 0; j < __mUSR3[fn].Count(); j++)
					{
						__mUSR3[fn][j].mPcbID = "PCB" + (j + 1);
						string[] array = new string[3]
						{
							"第" + (j + 1) + "分段",
							"第" + (j + 1) + "分段",
							"Section-" + (j + 1)
						};
						__mUSR3[fn][j].mPcbDescription = array[USR_INIT.mLanguage];
					}
					Invoke((MethodInvoker)delegate
					{
						uc_job[fn].set_inboradmode(USR3B[fn].mInBoardMode);
					});
				}
				else
				{
					Invoke((MethodInvoker)delegate
					{
						uc_job[fn].set_inboradmode(USR3B[fn].mInBoardMode);
					});
				}
				U3[fn] = new BindingList<USR3_DATA>();
				for (int k = 0; k < __mUSR3[fn].Count(); k++)
				{
					U3[fn].Add(__mUSR3[fn][k]);
				}
				U3Idx[fn] = 0;
			}
			init_usr2_history();
			init_usr3_history();
			init_usr2(iscreatefile: true);
			init_usr3(iscreatefile: true);
			init_pcbedit();
			for (int l = 0; l < HW.mFnNum; l++)
			{
				uc_job[l].set_edit(flag: true);
			}
		}

		public void load_usr2only(string filename)
		{
			if (!File.Exists(filename))
			{
				return;
			}
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
			USR_PRJ_EX_DATA uSR_PRJ_EX_DATA = (USR_PRJ_EX_DATA)formatter.Deserialize(stream);
			stream.Close();
			USR2[0] = uSR_PRJ_EX_DATA.USR2;
			if (HW.mFnNum == 2)
			{
				if (uSR_PRJ_EX_DATA.mExPRJ != null)
				{
					USR2[1] = uSR_PRJ_EX_DATA.mExPRJ.USR2;
				}
				if (USR2[1] == null)
				{
					USR2[1] = new USR2_DATA();
				}
			}
			init_usr2_history();
			for (int i = 0; i < HW.mFnNum; i++)
			{
				write_to_logFile("USR2 CREATE SW HISTORY " + USR2[i].mHistory);
				write_to_logFile("USR2 CREATE SW HISTORY " + USR2[i].mSwVersion);
				update_usr2_stacks_used_show(i);
				update_usr2_stacks_used_nozzles(i);
			}
		}

		public bool load_usrProjectData_EX()
		{
			if (File.Exists(mProjectFileName))
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(mProjectFileName, FileMode.Open, FileAccess.Read, FileShare.None);
				USR_PRJ_EX = (USR_PRJ_EX_DATA)formatter.Deserialize(stream);
				stream.Close();
				USR3_INIT = USR_PRJ_EX.USR3_INIT;
				if (USR3_INIT == null)
				{
					USR3_INIT = new USR3_INIT_DATA();
				}
				USR2[0] = USR_PRJ_EX.USR2;
				if (HW.mFnNum == 2)
				{
					if (USR_PRJ_EX.mExPRJ != null)
					{
						USR2[1] = USR_PRJ_EX.mExPRJ.USR2;
					}
					if (USR2[1] == null)
					{
						USR2[1] = new USR2_DATA();
					}
				}
				USR3B[0] = USR_PRJ_EX.USR3B;
				if (HW.mFnNum == 2)
				{
					if (USR_PRJ_EX.mExPRJ != null)
					{
						USR3B[1] = USR_PRJ_EX.mExPRJ.USR3B;
					}
					if (USR3B[1] == null)
					{
						USR3B[1] = new USR3_BASE();
					}
				}
				if (USR_PRJ_EX.USR3 != null)
				{
					__mUSR3[0] = USR_PRJ_EX.USR3;
				}
				else
				{
					__mUSR3[0] = new USR3_DATA[1]
					{
						new USR3_DATA()
					};
				}
				if (HW.mFnNum == 2)
				{
					if (USR_PRJ_EX.mExPRJ != null && USR_PRJ_EX.mExPRJ.USR3 != null)
					{
						__mUSR3[1] = USR_PRJ_EX.mExPRJ.USR3;
					}
					else
					{
						__mUSR3[1] = new USR3_DATA[1]
						{
							new USR3_DATA()
						};
					}
				}
				if (USR_PRJ_EX.USR3LIST != null)
				{
					U3[0] = USR_PRJ_EX.USR3LIST;
					U3Idx[0] = USR_PRJ_EX.USR3LISTIDX;
					U3Idx_Prev[0] = 0;
					if (U3[0].Count == 0)
					{
						U3[0].Add(__mUSR3[0][0]);
						U3Idx[0] = 0;
					}
					if ((HW.mDeviceType == DeviceType.HW_6S_TRAN4 || HW.mDeviceType == DeviceType.HW_8S_TRAN4) && USR3B[0].mPrjSmtMode != 1)
					{
						CmMessageBoxTop_Ok("该机型只能打开信号对接模式工程!");
						return false;
					}
				}
				else
				{
					U3[0] = new BindingList<USR3_DATA>();
					U3[0].Add(__mUSR3[0][0]);
					U3Idx[0] = 0;
					U3Idx_Prev[0] = 0;
				}
				if (HW.mFnNum == 2)
				{
					if (USR_PRJ_EX.mExPRJ != null && USR_PRJ_EX.mExPRJ.USR3LIST != null)
					{
						U3[1] = USR_PRJ_EX.mExPRJ.USR3LIST;
						U3Idx[1] = USR_PRJ_EX.mExPRJ.USR3LISTIDX;
					}
					else
					{
						U3[1] = new BindingList<USR3_DATA>();
						U3Idx[0] = 0;
					}
					U3Idx_Prev[1] = 0;
					if (U3[1] == null)
					{
						U3[1] = new BindingList<USR3_DATA>();
					}
					if (U3[1].Count == 0)
					{
						U3[1].Add(__mUSR3[1][0]);
						U3Idx[1] = 0;
					}
				}
				int fn;
				for (fn = 0; fn < HW.mFnNum; fn++)
				{
					write_to_logFile("USR 2 CREATE SW HISTORY " + USR2[fn].mHistory);
					write_to_logFile("USR 2 CREATE SW HISTORY " + USR2[fn].mSwVersion);
					write_to_logFile("PRJ 3B CREATE SW HISTORY " + USR3B[fn].mHistory);
					write_to_logFile("PRJ 3B CREATE SW HISTORY " + USR3B[fn].mSwVersion);
					write_to_logFile("PRJ 3 CREATE SW HISTORY " + U3[fn][U3Idx[fn]].mHistory);
					write_to_logFile("PRJ 3 CREATE SW HISTORY " + U3[fn][U3Idx[fn]].mSwVersion);
					if (USR3B[fn].mInBoardMode != USR_INIT.mInBoard_Mode)
					{
						common_waiting_break();
						CmMessageBoxTop_Ok("工程和设备进板贴装模式不相符，请确认");
						return false;
					}
					Invoke((MethodInvoker)delegate
					{
						uc_job[fn].set_inboradmode(USR3B[fn].mInBoardMode);
					});
				}
				init_usr2_history();
				init_usr3_history();
				init_usr2(iscreatefile: false);
				init_usr3(iscreatefile: false);
				init_pcbedit();
				return true;
			}
			return false;
		}

		public void init_usr2_history()
		{
			vsplus_usr2_history_before_2019_3();
			vsplus_usr2_history_before_2020_7();
			vsplus_usr2_history_before_2020_8();
		}

		public void init_usr3_history()
		{
			vsplus_usr3_history_before_2020_5();
			vsplus_usr3_history_before_2020_7();
			vsplus_usr3_history_common();
		}

		public void init_usr2(bool iscreatefile)
		{
			if (iscreatefile)
			{
				for (int i = 0; i < HW.mFnNum; i++)
				{
					StackElement[] array = USR2[i].mStackLib.stacktab[0];
					for (int j = 0; j < HW.mStackNum[i][0]; j++)
					{
						array[j].mXY.X = USR[i].mSlotAllCoord[j].X;
						array[j].mXY.Y = USR[i].mSlotAllCoord[j].Y;
					}
				}
				USR2_DATA[] array2 = new USR2_DATA[HW.mFnNum];
				string path = "../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin";
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
				array2[0] = (USR2_DATA)formatter.Deserialize(stream);
				stream.Close();
				if (array2 != null && HW.mFnNum == 2)
				{
					array2[1] = array2[0].mExUsr2;
				}
				for (int k = 0; k < HW.mFnNum; k++)
				{
					if (array2[k] == null)
					{
						continue;
					}
					if (array2[k].mHighCamScanRange == null)
					{
						array2[k].mHighCamScanRange = new int[2][];
						for (int l = 0; l < 2; l++)
						{
							array2[k].mHighCamScanRange[l] = new int[8] { 450, 450, 450, 450, 450, 450, 450, 450 };
						}
					}
					for (int m = 0; m < HW.mZnNum[k]; m++)
					{
						USR2[k].mFastCamMinValidPixel[0][m] = array2[k].mFastCamMinValidPixel[0][m];
						USR2[k].mFastCamScanRange[0][m] = array2[k].mFastCamScanRange[0][m];
						USR2[k].mHighCamMinValidPixel[0][m] = array2[k].mHighCamMinValidPixel[0][m];
						USR2[k].mHighCamScanRange[0][m] = array2[k].mHighCamScanRange[0][m];
						USR2[k].mHighCamStillDelay[0][m] = array2[k].mHighCamStillDelay[0][m];
					}
					for (int n = 0; n < HW.mFastLedNum; n++)
					{
						USR2[k].mFastCamLightLevel[0][n] = array2[k].mFastCamLightLevel[0][n];
					}
					USR2[k].mFastCamStillDelay[0] = array2[k].mFastCamStillDelay[0];
					USR2[k].mHighCamLightLevel[0] = array2[k].mHighCamLightLevel[0];
					USR2[k].mHCamPrisice_DeltaA = array2[k].mHCamPrisice_DeltaA;
					USR2[k].mHCamPrisice_DeltaXY = array2[k].mHCamPrisice_DeltaXY;
					USR2[k].mHCamPrisice_TryNum = array2[k].mHCamPrisice_TryNum;
				}
			}
			init_usr2_related();
		}

		public void init_usr3_language()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR3B[i] != null && USR3B[i].mPointlistCat != null && USR3B[i].mPointlistCat.Count > 0)
				{
					for (int j = 0; j < USR3B[i].mPointlistCat.Count; j++)
					{
						USR3B[i].mPointlistCat[j].mLanguage = USR_INIT.mLanguage;
						if (U3[i][U3Idx[i]].mHistory == 0)
						{
							USR3B[i].mPointlistCat[j].HistoryReback();
						}
					}
				}
				if (USR3B[i] != null && USR3B[i].mFeederInstallList != null && USR3B[i].mFeederInstallList.Count > 0)
				{
					for (int k = 0; k < USR3B[i].mFeederInstallList.Count; k++)
					{
						USR3B[i].mFeederInstallList[k].mLanguage = USR_INIT.mLanguage;
						if (U3[i][U3Idx[i]].mHistory == 0)
						{
							USR3B[i].mFeederInstallList[k].HistoryReback();
						}
					}
				}
				if (__mUSR3[i] == null)
				{
					continue;
				}
				for (int l = 0; l < __mUSR3[i].Count(); l++)
				{
					if (__mUSR3[i][l] == null || __mUSR3[i][l].mPointlist == null || __mUSR3[i][l].mPointlist.Count <= 0)
					{
						continue;
					}
					for (int m = 0; m < __mUSR3[i][l].mPointlist.Count; m++)
					{
						__mUSR3[i][l].mPointlist[m].mLanguage = USR_INIT.mLanguage;
						if (__mUSR3[i][l].mHistory == 0)
						{
							__mUSR3[i][l].mPointlist[m].HistoryReback();
						}
					}
				}
			}
		}

		public void init_usr3(bool iscreatefile)
		{
			init_usr3_language();
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR3B[i].mSmtXYSpeed == 0)
				{
					USR3B[i].mSmtXYSpeed = 60;
				}
				if (USR3B[i].mSmtASpeed == 0)
				{
					USR3B[i].mSmtASpeed = 60;
				}
				if (USR3B[i].mSmtPikRetryNum <= 0)
				{
					USR3B[i].mSmtPikRetryNum = 3;
				}
				if (USR3B[i].mGen0SafeZ == 0)
				{
					USR3B[i].mGen0SafeZ = 768;
				}
				if (HW.mSmtGenerationNo == 2)
				{
					if (USR3B[i].mSmtSafeSpace == 0f)
					{
						USR3B[i].mSmtSafeSpace = 5f;
					}
					if (USR3B[i].mSmtSafeSpace < 2f)
					{
						USR3B[i].mSmtSafeSpace = 2f;
					}
					else if (USR3B[i].mSmtSafeSpace > 25f)
					{
						USR3B[i].mSmtSafeSpace = 25f;
					}
				}
				if (USR3B[i].mInfo == null || USR3B[i].mInfo.mnt_chips == null)
				{
					USR3B[i].mInfo = new SmtInfo();
				}
				for (int j = 0; j < __mUSR3[i].Count(); j++)
				{
					if (__mUSR3[i][j].mInfo == null || __mUSR3[i][j].mInfo.mnt_chips == null)
					{
						__mUSR3[i][j].mInfo = new SmtInfo();
					}
				}
				vsplus_pcbedit_load(i);
				uc_job[i].load_data();
			}
			if (HW.mDeviceType == DeviceType.DSQ800_120F)
			{
				if (iscreatefile)
				{
					if (USR_INIT.mTrack == null)
					{
						USR_INIT.mTrack = new TrackPara();
					}
					USR3_INIT.mTrack.copyto(USR_INIT.mTrack);
				}
				else
				{
					if (USR3_INIT.mTrack == null)
					{
						USR3_INIT.mTrack = new TrackPara();
					}
					USR_INIT.mTrack.copyto(USR3_INIT.mTrack);
				}
				mConDevExt[0].sendTrackDelay((int)(USR3_INIT.mTrack.delayL * 10f), (int)(USR3_INIT.mTrack.delayM * 10f), (int)(USR3_INIT.mTrack.delayR * 10f));
				mConDevExt[0].sendTrackSpeed(10 - USR3_INIT.mTrack.speed);
			}
			else
			{
				for (int k = 0; k < HW.mFnNum; k++)
				{
					if (iscreatefile)
					{
						USR3B[k].mTrackDelay = USR[k].mTrackDelay;
						USR3B[k].mTrackSpeed = USR[k].mTrackSpeed;
					}
					else
					{
						USR[k].mTrackDelay = USR3B[k].mTrackDelay;
						USR[k].mTrackSpeed = USR3B[k].mTrackSpeed;
					}
					if (USR3B[k].mTrackDelay == 0f)
					{
						USR3B[k].mTrackDelay = (USR[k].mTrackDelay = (HW.mIsSanduanshi ? 0.7f : 0.1f));
					}
					if (USR3B[k].mTrackSpeed == 0)
					{
						USR3B[k].mTrackSpeed = (USR[k].mTrackSpeed = 9);
					}
					mConDevExt[k].sendTrackSpeed(10 - USR[k].mTrackSpeed);
					mConDevExt[k].sendTrackDelay((int)(USR[k].mTrackDelay * 10f));
				}
			}
			if (!mIsSimulation)
			{
				if (HW.mFnNum >= 2)
				{
					mConDevExt[0].send_loukong_enable(USR3_INIT.mIsLoukong ? 1 : 0, HW.mIsSanduanshi);
				}
				else
				{
					mConDevExt[0].send_loukong_enable(USR3B[0].mIsLoukongPCB ? 1 : 0, HW.mIsSanduanshi);
				}
			}
			save_usrProjectData();
		}

		public static void save_usrProjectData()
		{
			if (mProjectFileName != "" && USR2 != null && __mUSR3 != null && USR3B != null)
			{
				USR_PRJ_EX = new USR_PRJ_EX_DATA();
				USR_PRJ_EX.SECTIONS = HW.mSections;
				USR_PRJ_EX.HISTORY = 8;
				USR_PRJ_EX.SW_VERSION = "20210712_8.8.0_T46_R";
				USR_PRJ_EX.USR2 = USR2[0];
				USR_PRJ_EX.USR3B = USR3B[0];
				USR_PRJ_EX.USR3B.mHistory = 8;
				USR_PRJ_EX.USR3B.mSwVersion = "20210712_8.8.0_T46_R";
				USR_PRJ_EX.USR2.mHistory = 8;
				USR_PRJ_EX.USR2.mSwVersion = "20210712_8.8.0_T46_R";
				USR_PRJ_EX.USR3 = __mUSR3[0];
				USR_PRJ_EX.USR3LIST = U3[0];
				USR_PRJ_EX.USR3LISTIDX = U3Idx[0];
				USR_PRJ_EX.USR3[0] = __mUSR3[0][0];
				USR_PRJ_EX.USR3[0].mHistory = 8;
				USR_PRJ_EX.USR3[0].mSwVersion = "20210712_8.8.0_T46_R";
				if (HW.mFnNum == 2)
				{
					USR_PRJ_EX.mExPRJ = new USR_PRJ_EX_DATA();
					USR_PRJ_EX.mExPRJ.SECTIONS = HW.mSections;
					USR_PRJ_EX.mExPRJ.HISTORY = 8;
					USR_PRJ_EX.mExPRJ.SW_VERSION = "20210712_8.8.0_T46_R";
					USR_PRJ_EX.mExPRJ.USR2 = USR2[1];
					USR_PRJ_EX.mExPRJ.USR3B = USR3B[1];
					USR_PRJ_EX.mExPRJ.USR3B.mHistory = 8;
					USR_PRJ_EX.mExPRJ.USR3B.mSwVersion = "20210712_8.8.0_T46_R";
					USR_PRJ_EX.mExPRJ.USR2.mHistory = 8;
					USR_PRJ_EX.mExPRJ.USR2.mSwVersion = "20210712_8.8.0_T46_R";
					USR_PRJ_EX.mExPRJ.USR3 = __mUSR3[1];
					USR_PRJ_EX.mExPRJ.USR3LIST = U3[1];
					USR_PRJ_EX.mExPRJ.USR3LISTIDX = U3Idx[1];
					USR_PRJ_EX.mExPRJ.USR3[0] = __mUSR3[1][0];
					USR_PRJ_EX.mExPRJ.USR3[0].mHistory = 8;
					USR_PRJ_EX.mExPRJ.USR3[0].mSwVersion = "20210712_8.8.0_T46_R";
				}
				Stream stream = new FileStream(mProjectFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				IFormatter formatter = new BinaryFormatter();
				try
				{
					formatter.Serialize(stream, USR_PRJ_EX);
				}
				catch (Exception)
				{
					write_to_logFile_EXCEPTION(" save_usrProjectData");
				}
				stream.Close();
			}
		}

		private void init_pcbedit()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				uc_job[i].subpcb_flush_sectionhead("init");
				uc_job[i].subpcb_flush_all();
				uc_job[i].init_pcbedit_smtlist(i);
			}
		}

		private bool fastCam_calcPixRatio(int fn, Coordinate point)
		{
			double[] array = new double[4];
			float[] array2 = new float[4];
			int num = USR[fn].mFastCamLiebians[mZn[fn]] / 2;
			for (int i = 0; i < 4; i++)
			{
				moveToZero_A_andWait(fn);
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				int num2 = ((i % 2 == 0) ? 1 : (-1));
				moveToXY_andWait(fn, USR[fn].mXYSpeed, new Coordinate(point.X - USR[fn].mFastCamLiebians[mZn[fn]] * num2, point.Y - USR[fn].mFastCamLiebians[mZn[fn]]));
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				List<s_POINT_f> list = new List<s_POINT_f>();
				for (int j = 0; j < 8; j++)
				{
					moveToA_andWait(fn, mZn[fn], USR[fn].mASpeed, (int)Math.Round((double)(45 * j * 128) * 200.0 / 360.0, 0) % (200 * HW.mAaxisSubDivision));
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					VISUAL_RESULT visual_result = new VISUAL_RESULT();
					visual_result.is_test = true;
					if (ImageVisual(fn, VISUAL_MODE.AUTODETECT, CameraType.Fast, VisualType.Circle, USR[fn].mfcam_scanr, USR[fn].mfcam_threshold, mZn[fn], -num * num2, -num, 0f, ref visual_result) != 0)
					{
						thd_ZnAlltoZero(fn);
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot detect nozzle, please adjust light related parameters!" : "未发现识别的吸嘴，请调整相关参数（比如灯光强度、将吸嘴靠近灯源中心、将吸嘴更换为实心吸嘴）");
						return false;
					}
					if (visual_result.box_width > (float)USR[fn].mfcam_rec_size || visual_result.box_height > (float)USR[fn].mfcam_rec_size)
					{
						thd_ZnAlltoZero(fn);
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? ("Noz" + (mZn[fn] + 1) + "is too large!") : ("吸嘴" + (mZn[fn] + 1) + "识别尺寸超出合理范围，请调整相关参数"));
						return false;
					}
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					list.Add(new s_POINT_f
					{
						x = visual_result.box_center_x,
						y = visual_result.box_center_y
					});
				}
				Circle circle = fake_FittingCircle(list);
				float num3 = (float)circle.X;
				float num4 = (float)circle.Y;
				moveToZero_A_andWait(fn);
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				moveToXY_andWait(fn, USR[fn].mXYSpeed, new Coordinate(point.X + USR[fn].mFastCamLiebians[mZn[fn]] * num2, point.Y + USR[fn].mFastCamLiebians[mZn[fn]]));
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				List<s_POINT_f> list2 = new List<s_POINT_f>();
				for (int k = 0; k < 8; k++)
				{
					moveToA_andWait(fn, mZn[fn], USR[fn].mASpeed, (int)Math.Round((double)(45 * k * 128) * 200.0 / 360.0, 0) % (200 * HW.mAaxisSubDivision));
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					VISUAL_RESULT visual_result2 = new VISUAL_RESULT();
					visual_result2.is_test = true;
					if (ImageVisual(fn, VISUAL_MODE.AUTODETECT, CameraType.Fast, VisualType.Circle, USR[fn].mfcam_scanr, USR[fn].mfcam_threshold, mZn[fn], num * num2, num, 0f, ref visual_result2) != 0)
					{
						thd_ZnAlltoZero(fn);
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot detect nozzle, please adjust light related parameters!" : "未发现识别的吸嘴，请调整相关参数（比如灯光强度、将吸嘴靠近灯源中心、将吸嘴更换为实心吸嘴）");
						return false;
					}
					if (visual_result2.box_width > (float)USR[fn].mfcam_rec_size || visual_result2.box_height > (float)USR[fn].mfcam_rec_size)
					{
						thd_ZnAlltoZero(fn);
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? ("Noz" + (mZn[fn] + 1) + "is too large!") : ("吸嘴" + (mZn[fn] + 1) + "识别尺寸超出合理范围，请调整相关参数"));
						return false;
					}
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					list2.Add(new s_POINT_f
					{
						x = visual_result2.box_center_x,
						y = visual_result2.box_center_y
					});
				}
				Circle circle2 = fake_FittingCircle(list2);
				float num5 = (float)circle2.X;
				float num6 = (float)circle2.Y;
				array[i] = Math.Atan2(num6 - num4, num5 - num3) * 180.0 / Math.PI - 90.0 + (double)(45 * num2);
				array2[i] = ((float)USR[fn].mFastCamLiebians[mZn[fn]] * 2f / Math.Abs(num5 - num3) + (float)USR[fn].mFastCamLiebians[mZn[fn]] * 2f / Math.Abs(num6 - num4)) / 2f;
				write_to_logFile(mLogFileName, i % 2 + "  调试：吸嘴" + (mZn[fn] + 1) + ", jktemp=" + array[i].ToString("F4") + ",old:(" + num3.ToString("F4") + "," + num4.ToString("F4") + "), new:(" + num5.ToString("F4") + "," + num6.ToString("F4") + ")" + Environment.NewLine);
			}
			USR[fn].mFastCamRatio[0][mZn[fn]] = (array2[0] + array2[1] + array2[2] + array2[3]) / 4f;
			USR[fn].mFastCamRatioExt[0][mZn[fn]] = (float)((array[0] + array[1] + array[2] + array[3]) / 4.0);
			moveToXY_andWait(fn, USR[fn].mXYSpeed, point);
			return true;
		}

		private void AdjustScanCenterInImage(int fn, int zn)
		{
			int num = mJvs_usrWidth;
			int num2 = mJvs_rawWidth;
			int num3 = (int)USR[fn].mFastCamCenterPosition[0][zn].X - num / 2;
			if (Math.Abs(num3) < (num2 - num) / 2)
			{
				USR[fn].mFastCamCenterDeltaX[0][zn] = num3;
				USR[fn].mFastCamCenterPosition[0][zn].X -= num3;
				return;
			}
			int num4 = ((num3 >= 0) ? 1 : (-1));
			num3 = num4 * (num2 - num) / 2;
			USR[fn].mFastCamCenterDeltaX[0][zn] = num3;
			USR[fn].mFastCamCenterPosition[0][zn].X -= num3;
		}

		private bool highCam_calcPixRatio(int fn, Coordinate point)
		{
			double[] array = new double[4];
			float[] array2 = new float[4];
			if (USR[fn].mHighCamRatio[0] == 0f)
			{
				USR[fn].mHighCamRatio[0] = 2.77f;
			}
			int num = (int)((float)USR[fn].mHighCamLiebian / USR[fn].mHighCamRatio[0]);
			for (int i = 0; i < 4; i++)
			{
				moveToZero_A_andWait(fn);
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				int num2 = ((i % 2 == 0) ? 1 : (-1));
				moveToXY_andWait(fn, USR[fn].mXYSpeed, new Coordinate(point.X - USR[fn].mHighCamLiebian * 3 * num2, point.Y - USR[fn].mHighCamLiebian));
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				List<s_POINT_f> list = new List<s_POINT_f>();
				for (int j = 0; j < 8; j++)
				{
					moveToA_andWait(fn, mZn[fn], USR[fn].mASpeed, (int)Math.Round((double)(45 * j * 128) * 200.0 / 360.0, 0) % (200 * HW.mAaxisSubDivision));
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					VISUAL_RESULT visual_result = new VISUAL_RESULT();
					visual_result.is_test = true;
					if (ImageVisual(fn, VISUAL_MODE.AUTODETECT, CameraType.High, VisualType.NoAngle, USR[fn].mhcam_scanr, USR[fn].mhcam_threshold, mZn[fn], -num * 3 * num2, -num, 0f, ref visual_result) != 0)
					{
						thd_ZnAlltoZero(fn);
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot detect nozzle, please adjust light related parameters!" : "未发现识别的吸嘴，请调整相关参数（比如灯光强度、将吸嘴靠近灯源中心、将吸嘴更换为实心吸嘴）");
						return false;
					}
					if (visual_result.box_width > (float)USR[fn].mhcam_rec_size || visual_result.box_height > (float)USR[fn].mhcam_rec_size)
					{
						thd_ZnAlltoZero(fn);
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? ("Noz" + (mZn[fn] + 1) + "is too large!") : ("吸嘴" + (mZn[fn] + 1) + "识别尺寸超出合理范围，请调整相关参数"));
						return false;
					}
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					list.Add(new s_POINT_f
					{
						x = visual_result.box_center_x,
						y = visual_result.box_center_y
					});
				}
				Circle circle = fake_FittingCircle(list);
				float num3 = (float)circle.X;
				float num4 = (float)circle.Y;
				moveToZero_A_andWait(fn);
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				moveToXY_andWait(fn, USR[fn].mXYSpeed, new Coordinate(point.X + USR[fn].mHighCamLiebian * 3 * num2, point.Y + USR[fn].mHighCamLiebian));
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				List<s_POINT_f> list2 = new List<s_POINT_f>();
				for (int k = 0; k < 8; k++)
				{
					moveToA_andWait(fn, mZn[fn], USR[fn].mASpeed, (int)Math.Round((double)(45 * k * 128) * 200.0 / 360.0, 0) % (200 * HW.mAaxisSubDivision));
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					VISUAL_RESULT visual_result2 = new VISUAL_RESULT();
					visual_result2.is_test = true;
					if (ImageVisual(fn, VISUAL_MODE.AUTODETECT, CameraType.High, VisualType.NoAngle, USR[fn].mhcam_scanr, USR[fn].mhcam_threshold, mZn[fn], num * 3 * num2, num, 0f, ref visual_result2) != 0)
					{
						thd_ZnAlltoZero(fn);
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot detect nozzle, please adjust light related parameters!" : "未发现识别的吸嘴，请调整相关参数（比如灯光强度、将吸嘴靠近灯源中心、将吸嘴更换为实心吸嘴）");
						return false;
					}
					if (visual_result2.box_width > (float)USR[fn].mhcam_rec_size || visual_result2.box_height > (float)USR[fn].mhcam_rec_size)
					{
						thd_ZnAlltoZero(fn);
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? ("Noz" + (mZn[fn] + 1) + "is too large!") : ("吸嘴" + (mZn[fn] + 1) + "识别尺寸超出合理范围，请调整相关参数"));
						return false;
					}
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					list2.Add(new s_POINT_f
					{
						x = visual_result2.box_center_x,
						y = visual_result2.box_center_y
					});
				}
				Circle circle2 = fake_FittingCircle(list2);
				float num5 = (float)circle2.X;
				float num6 = (float)circle2.Y;
				array[i] = (Math.Atan2(num6 - num4, num5 - num3) - Math.PI / 2.0 - (Math.Atan2(1.0, 3.0) - Math.PI / 2.0) * (double)num2) * 180.0 / Math.PI;
				array2[i] = (float)(Math.Sqrt(USR[fn].mHighCamLiebian * 6 * (USR[fn].mHighCamLiebian * 6) + USR[fn].mHighCamLiebian * 2 * (USR[fn].mHighCamLiebian * 2)) / Math.Sqrt((num5 - num3) * (num5 - num3) + (num6 - num4) * (num6 - num4)));
				write_to_logFile(mLogFileName, i % 2 + " HQ 调试：吸嘴" + (mZn[fn] + 1) + ", jktemp=" + array[i].ToString("F4") + ",old:(" + num3.ToString("F4") + "," + num4.ToString("F4") + "), new:(" + num5.ToString("F4") + "," + num6.ToString("F4") + ")" + Environment.NewLine);
			}
			USR[fn].mHighCamRatio[0] = (array2[0] + array2[1] + array2[2] + array2[3]) / 4f;
			USR[fn].mHighCamRatioExt[0] = (float)(array[0] + array[1] + array[2] + array[3]) / 4f;
			moveToXY_andWait(fn, USR[fn].mXYSpeed, point);
			return true;
		}

		public Coordinate auto_findcenter(int fn, int zn)
		{
			int num = 0;
			int num2 = 0;
			int cur_range = 180;
			int cur_threshold = 127;
			int num3 = 140;
			if (mCurCam[fn] == CameraType.Fast)
			{
				num = mJvs_usrWidth;
				num2 = mJvs_usrHeight;
				cur_range = USR[fn].mfcam_scanr;
				cur_threshold = USR[fn].mfcam_threshold;
				num3 = USR[fn].mfcam_rec_size;
			}
			else if (mCurCam[fn] == CameraType.High)
			{
				num = 1944;
				num2 = 1944;
				cur_range = USR[fn].mhcam_scanr;
				cur_threshold = USR[fn].mhcam_threshold;
				num3 = USR[fn].mhcam_rec_size;
			}
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			while (true)
			{
				List<s_POINT_f> list = new List<s_POINT_f>();
				for (int i = 0; i < 8; i++)
				{
					moveToA_andWait(fn, mZn[fn], USR[fn].mASpeed, (int)Math.Round((double)(45 * i * 128) * 200.0 / 360.0, 0) % (200 * HW.mAaxisSubDivision));
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return null;
					}
					visual_result.is_test = true;
					if (ImageVisual(fn, VISUAL_MODE.AUTODETECT, mCurCam[fn], VisualType.Circle, cur_range, cur_threshold, zn, 0, 0, 0f, ref visual_result) != 0)
					{
						thd_ZnAlltoZero(fn);
						string text = "Canot found Noz" + (zn + 1) + ", please adjust ligit/nozzle related parameters";
						string text2 = "未发现吸嘴" + (zn + 1) + "，请调整相关参数（比如将吸嘴靠近灯源中心、灯光强度、将吸嘴更换为实心吸嘴）";
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? text : text2);
						return null;
					}
					if (visual_result.box_width > (float)num3 || visual_result.box_height > (float)num3)
					{
						string text3 = "Noz" + (zn + 1) + "is too large, please adjust ligit/nozzle related parameters";
						string text4 = "吸嘴" + (zn + 1) + "识别尺寸超出合理范围，请调整相关参数";
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? text3 : text4);
						return null;
					}
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return null;
					}
					list.Add(new s_POINT_f
					{
						x = visual_result.box_center_x,
						y = visual_result.box_center_y
					});
				}
				Circle circle = fake_FittingCircle(list);
				float num4 = (float)num / 2f - (float)circle.X;
				float num5 = (float)num2 / 2f - (float)circle.Y;
				float num6 = 1f;
				if (Math.Abs(num4) < 0.5f && Math.Abs(num5) < 0.5f)
				{
					break;
				}
				int num7 = mCur[fn].x + (int)(num4 * num6 + 0.5f * (float)((num4 > 0f) ? 1 : (-1)));
				int num8 = mCur[fn].y + (int)(num5 * num6 + 0.5f * (float)((num5 > 0f) ? 1 : (-1)));
				num7 = ((num7 >= 0) ? ((num7 > HW.mMaxX[fn]) ? HW.mMaxX[fn] : num7) : 0);
				num8 = ((num8 >= 0) ? ((num8 > HW.mMaxY[fn]) ? HW.mMaxY[fn] : num8) : 0);
				moveToXY_andWait(fn, USR[fn].mXYSpeed, new Coordinate(num7, num8));
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return null;
				}
			}
			return new Coordinate(mCur[fn].x, mCur[fn].y);
		}

		public Coordinate auto_findcenter_post(int fn, int zn)
		{
			int num = 140;
			if (mCurCam[fn] == CameraType.Fast)
			{
				num = USR[fn].mfcam_rec_size;
			}
			else if (mCurCam[fn] == CameraType.High)
			{
				num = USR[fn].mhcam_rec_size;
			}
			List<s_POINT_f> list = new List<s_POINT_f>();
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			for (int i = 0; i < 8; i++)
			{
				moveToA_andWait(fn, mZn[fn], USR[fn].mASpeed, (int)Math.Round((double)(45 * i * 128) * 200.0 / 360.0, 0) % (200 * HW.mAaxisSubDivision));
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return null;
				}
				float[] array = new float[3];
				float[] array2 = new float[3];
				bool flag = true;
				visual_result.is_test = true;
				flag = ImageVisual(fn, VISUAL_MODE.AUTODETECT, CameraType.Fast, VisualType.Circle, USR[fn].mfcam_scanr, USR[fn].mfcam_threshold, zn, 0, 0, 0f, ref visual_result) == ImageVisual_Result.OK;
				array[0] = visual_result.box_center_x;
				array2[0] = visual_result.box_center_y;
				visual_result.is_test = true;
				flag = ImageVisual(fn, VISUAL_MODE.AUTODETECT, CameraType.Fast, VisualType.Circle, USR[fn].mfcam_scanr, USR[fn].mfcam_threshold, zn, 0, 0, 0f, ref visual_result) == ImageVisual_Result.OK && flag;
				array[1] = visual_result.box_center_x;
				array2[1] = visual_result.box_center_y;
				visual_result.is_test = true;
				flag = ImageVisual(fn, VISUAL_MODE.AUTODETECT, CameraType.Fast, VisualType.Circle, USR[fn].mfcam_scanr, USR[fn].mfcam_threshold, zn, 0, 0, 0f, ref visual_result) == ImageVisual_Result.OK && flag;
				array[2] = visual_result.box_center_x;
				array2[2] = visual_result.box_center_y;
				if (visual_result.box_width > (float)num || visual_result.box_height > (float)num)
				{
					string text = "Noz" + (zn + 1) + "is too large, please adjust ligit/nozzle related parameters";
					string text2 = "吸嘴" + (zn + 1) + "识别尺寸超出合理范围，请调整相关参数";
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? text : text2);
					return null;
				}
				if (!flag)
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot detect nozzle, please adjust light related parameters!" : "未发现识别的吸嘴，请调整相关参数（比如将吸嘴靠近灯源中心、灯光强度、将吸嘴更换为实心吸嘴）");
					return null;
				}
				list.Add(new s_POINT_f
				{
					x = array.Sum() / 3f,
					y = array2.Sum() / 3f
				});
			}
			Circle circle = fake_FittingCircle(list);
			return new Coordinate((int)Math.Round((float)circle.X, 0), (int)Math.Round((float)circle.Y, 0));
		}

		private void button_labprovider_Click(object sender, EventArgs e)
		{
			if (mForm_LabProvider == null || mForm_LabProvider.IsDisposed)
			{
				int num = 560;
				mForm_LabProvider = new Form_LabProviders(USR[mFn]);
				mForm_LabProvider.Size = new Size(707, 880);
				mForm_LabProvider.Location = new Point(4 + num, 132);
				mForm_LabProvider.Show();
				mForm_LabProvider.TopMost = true;
			}
		}

		private void sub_transter_4_boardsmt_finish(int fn, int boardno)
		{
			if (!mIsSimulation)
			{
				mConDevExt[fn].send_tran4_smt_finish(boardno, 1);
			}
			msdelay(USR3B[fn].mOem.tran4_waitnewsignal_delay);
			Thread thread = new Thread(thd_transter_4_boardsmt_finish_signal_close);
			thread.IsBackground = true;
			thread.Start(new int_2d(fn, boardno));
		}

		private void thd_transter_4_boardsmt_finish_signal_close(object o)
		{
			int a = ((int_2d)o).a;
			int b = ((int_2d)o).b;
			msdelay(USR3B[a].mOem.tran4_finishsignal_delay);
			if (!mIsSimulation)
			{
				mConDevExt[a].send_tran4_smt_finish(b, 0);
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

		private void updateLanguage()
		{
			label_smtdevicetype.Font = new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], label_smtdevicetype.Font.Size, FontStyle.Regular);
			foreach (LanguageItem mLanguage in mLanguageList)
			{
				if (mLanguage.ctrl == btn_Connect)
				{
					mLanguage.ctrl.Text = mLanguage.str[(bmIsConnected ? 1 : 0) * 3 + USR_INIT.mLanguage];
				}
				else
				{
					mLanguage.ctrl.Text = mLanguage.str[USR_INIT.mLanguage];
				}
				if (mLanguage.font != null && mLanguage.fsize != null)
				{
					mLanguage.ctrl.Font = new Font(mLanguage.font[USR_INIT.mLanguage], mLanguage.ctrl.Font.Size + mLanguage.fsize[USR_INIT.mLanguage], mLanguage.ctrl.Font.Style);
				}
				else if (USR_INIT.mLanguage == 2)
				{
					mLanguage.ctrl.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], mLanguage.ctrl.Font.Size + DEF.FSIZE_2020_YH[USR_INIT.mLanguage], FontStyle.Regular);
				}
				else if (USR_INIT.mLanguage == 0 || USR_INIT.mLanguage == 1)
				{
					mLanguage.ctrl.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], mLanguage.ctrl.Font.Size + DEF.FSIZE_2020_YH[USR_INIT.mLanguage], mLanguage.ctrl.Font.Style);
				}
			}
			foreach (LanguageToolStripMenuItem mLanguageToolStripMenuItem in mLanguageToolStripMenuItemList)
			{
				mLanguageToolStripMenuItem.ctrl.Text = mLanguageToolStripMenuItem.str[USR_INIT.mLanguage];
				if (mLanguageToolStripMenuItem.font != null && mLanguageToolStripMenuItem.fsize != null)
				{
					mLanguageToolStripMenuItem.ctrl.Font = new Font(mLanguageToolStripMenuItem.font[USR_INIT.mLanguage], mLanguageToolStripMenuItem.ctrl.Font.Size + mLanguageToolStripMenuItem.fsize[USR_INIT.mLanguage], mLanguageToolStripMenuItem.ctrl.Font.Style);
				}
				else if (USR_INIT.mLanguage == 2)
				{
					mLanguageToolStripMenuItem.ctrl.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], mLanguageToolStripMenuItem.ctrl.Font.Size + DEF.FSIZE_2020_YH[USR_INIT.mLanguage], FontStyle.Regular);
				}
				else
				{
					mLanguageToolStripMenuItem.ctrl.Font = new Font(STR.LANGUAGE[USR_INIT.mLanguage], mLanguageToolStripMenuItem.ctrl.Font.Size + DEF.FSIZE_2020_YH[USR_INIT.mLanguage], mLanguageToolStripMenuItem.ctrl.Font.Style);
				}
			}
			Text = STR.WENZHOUYINGXING[USR_INIT.mLanguage];
		}

		private void initLanguageTable()
		{
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = radioBn_Z0,
				str = new string[3] { "吸嘴1", "吸嘴1", "Noz1" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = radioBn_Z1,
				str = new string[3] { "吸嘴2", "吸嘴2", "Noz2" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = radioBn_Z2,
				str = new string[3] { "吸嘴3", "吸嘴3", "Noz3" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = radioBn_Z3,
				str = new string[3] { "吸嘴4", "吸嘴4", "Noz4" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = radioBn_Z4,
				str = new string[3] { "吸嘴5", "吸嘴5", "Noz5" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = radioBn_Z5,
				str = new string[3] { "吸嘴6", "吸嘴6", "Noz6" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = radioBn_Z6,
				str = new string[3] { "吸嘴7", "吸嘴7", "Noz7" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = radioBn_Z7,
				str = new string[3] { "吸嘴8", "吸嘴8", "Noz8" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = label_hi_title,
				str = new string[3] { "华维国创 智控系统", "华维国创 智控系统", "HWGC Intelligent System" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = btn_Connect,
				str = STR.CONNECT
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_projectname,
				str = new string[3] { "工程：", "工程：", "PROJECT: " }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ProjectClose,
				str = new string[3] { "关闭工程", "关闭工程", "Close" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = btn_OpenCreateProject,
				str = new string[3] { "工程文件", "工程文件", "Project" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = btn_FixedSetting,
				str = new string[3] { "系统参数", "系統參數", "System Setting" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020_TITLE,
				fsize = DEF.FSIZE_2020,
				ctrl = button_DeviceCalibraion,
				str = new string[3] { "机器校准", "機器校準", "Calibration" }
			});
			mLanguageList.Add(new LanguageItem
			{
				ctrl = this,
				str = new string[3] { "北京华维国创电子科技有限公司 贴片机控制系统 2018智能版", "北京华维国创电子科技有限公司 贴片机控制系统 2018智能版", "北京华维国创电子科技有限公司 贴片机控制系统 2018智能版" }
			});
		}

		private void init_Language()
		{
			initLanguageTable();
			updateLanguage();
			label_hi_title.Text = "Intelligent System";
		}

		public void init_MoveButton()
		{
			mRunDoing = new byte[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mRunDoing[i] = 0;
			}
			mWaitXY = new Coordinate[HW.mFnNum];
			for (int j = 0; j < HW.mFnNum; j++)
			{
				mWaitXY[j] = new Coordinate(0L, 0L);
			}
			mWaitZ = new int[HW.mFnNum][];
			for (int k = 0; k < HW.mFnNum; k++)
			{
				int[] array = (mWaitZ[k] = new int[8]);
			}
			mWaitA = new int[HW.mFnNum][];
			for (int l = 0; l < HW.mFnNum; l++)
			{
				int[] array2 = (mWaitA[l] = new int[8]);
			}
		}

		private static int aStepTip(int value)
		{
			int num = value % 25600;
			if (value < 0)
			{
				return num + 25600;
			}
			return num;
		}

		private static int aStepTip_minus(int value)
		{
			return value % 25600;
		}

		private void thd_ZnAlltoZero(object fn)
		{
			moveToZero_Z_andWait((int)fn);
		}

		public static void thd_ZnAnAlltoZero(object fn)
		{
			moveToZero_ZA_andWait((int)fn);
			mMutexMoveXYZA = false;
		}

		public static void thd_AnAlltoZero(object fn)
		{
			moveToZero_A_andWait((int)fn);
			mMutexMoveXYZA = false;
		}

		public static void thd_MoveXYOperate(object point)
		{
			Coordinate coordinate = new Coordinate(((Coordinate)point).X + mCur[mFn].x, ((Coordinate)point).Y + mCur[mFn].y);
			if (coordinate.X < 0)
			{
				coordinate.X = 0L;
			}
			else if (coordinate.X > HW.mMaxX[0])
			{
				coordinate.X = HW.mMaxX[0];
			}
			if (coordinate.Y < 0)
			{
				coordinate.Y = 0L;
			}
			else if (coordinate.Y > HW.mMaxY[0])
			{
				coordinate.Y = HW.mMaxY[0];
			}
			moveToZero_Z_andWait(mFn);
			moveToXY_andWait(mFn, USR[mFn].mXYSpeed, coordinate);
			pcbcheck_sel_nearestchip(mFn);
		}

		public static void thd_MoveToAbsoluteXYOperate(object point)
		{
			moveToZero_Z_andWait(mFn);
			moveToXY_andWait(mFn, USR[mFn].mXYSpeed, (Coordinate)point);
			mMutexMoveXYZA = false;
		}

		public static void thd_MoveToAbsoluteZOperate(object height)
		{
			moveToZ_andWait(mFn, mZn[mFn], USR[mFn].mZSpeed, (int)height);
			mMutexMoveXYZA = false;
		}

		public static void moveToXY_andWait(int fn, int speed, Coordinate point)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			mIsXYMoving[fn] = true;
			if (mIsFeederUp[fn])
			{
				Thread.Sleep(5);
				mIsXYMoving[fn] = false;
				return;
			}
			int num = (int)point.X;
			int num2 = (int)point.Y;
			num = ((num >= 0) ? ((num > HW.mMaxX[fn]) ? HW.mMaxX[fn] : num) : 0);
			num2 = ((num2 >= 0) ? ((num2 > HW.mMaxY[fn]) ? HW.mMaxY[fn] : num2) : 0);
			mWaitXY[fn] = new Coordinate(num, num2);
			mConDev[fn].sendxyCoordinate(num, num2, speed);
			Waiting(96, fn, 0, 15000, 0);
			mIsXYMoving[fn] = false;
		}

		private void moveToXY_noWait(int fn, int speed, Coordinate point)
		{
			mIsXYMoving[fn] = true;
			if (mIsFeederUp[fn])
			{
				Thread.Sleep(1000);
			}
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					mIsXYMoving[fn] = false;
					return;
				}
				Thread.Sleep(1);
			}
			int num = (int)point.X;
			int num2 = (int)point.Y;
			num = ((num >= 0) ? ((num > HW.mMaxX[fn]) ? HW.mMaxX[fn] : num) : 0);
			num2 = ((num2 >= 0) ? ((num2 > HW.mMaxY[fn]) ? HW.mMaxY[fn] : num2) : 0);
			mWaitXY[fn] = new Coordinate(num, num2);
			mConDev[fn].sendxyCoordinate(num, num2, speed);
		}

		public static void WaitComplete_XY(int fn)
		{
			while (true)
			{
				if (mRunDoing[fn] != 0)
				{
					if ((mRunDoing[fn] & 2u) != 0)
					{
						break;
					}
					Thread.Sleep(1);
					continue;
				}
				Waiting(96, fn, 0, 15000, 0);
				break;
			}
			mIsXYMoving[fn] = false;
		}

		public static void moveToZero_ZA_andWait(int fn)
		{
			for (int i = 0; i < HW.mZnNum[fn]; i++)
			{
				mWaitA[fn][i] = 0;
				if (mCur[fn].a[i] != 0)
				{
					move_a_coordinate(fn, i, 0, 40);
				}
			}
			if (HW.mSmtGenerationNo == 0)
			{
				for (int j = 0; j < HW.mZnNum[fn] / 2; j++)
				{
					mWaitZ[fn][j * 2] = 0;
					mWaitZ[fn][j * 2 + 1] = 0;
					if (mCur[fn].z[j * 2] != 0 || mCur[fn].z[j * 2 + 1] != 0)
					{
						mConDev[fn].sendzCoordinate(j * 2, 0, USR[fn].mZSpeed);
					}
				}
			}
			else if (HW.mSmtGenerationNo == 2)
			{
				for (int k = 0; k < HW.mZnNum[fn]; k++)
				{
					mWaitZ[fn][k] = 0;
					if (mCur[fn].z[k] != 0)
					{
						move_z_coordinate_gen2(fn, k, 0, USR[fn].mZSpeed);
					}
				}
			}
			for (int l = 0; l < HW.mZnNum[fn]; l++)
			{
				if (mCur[fn].a[l] != 0)
				{
					Waiting(22, fn, l, 15000, 0);
				}
				if (mCur[fn].z[l] != 0)
				{
					Waiting(98, fn, l, 15000, 0);
				}
			}
		}

		public static void moveToZero_Z_andWait(int fn)
		{
			if (HW.mSmtGenerationNo == 0)
			{
				for (int i = 0; i < HW.mZnNum[fn] / 2; i++)
				{
					if (mCur[fn].z[i * 2] != 0 || mCur[fn].z[i * 2 + 1] != 0)
					{
						mWaitZ[fn][i * 2] = 0;
						mWaitZ[fn][i * 2 + 1] = 0;
						mConDev[fn].sendzCoordinate(i * 2, 0, USR[fn].mZSpeed);
					}
				}
			}
			else if (HW.mSmtGenerationNo == 2)
			{
				for (int j = 0; j < HW.mZnNum[fn]; j++)
				{
					mWaitZ[fn][j] = 0;
					if (mCur[fn].z[j] != 0)
					{
						move_z_coordinate_gen2(fn, j, 0, USR[fn].mZSpeed);
					}
				}
			}
			for (int k = 0; k < HW.mZnNum[fn]; k++)
			{
				if (mCur[fn].z[k] != 0)
				{
					Waiting(98, fn, k, 15000, 0);
				}
			}
		}

		public static void moveToZero_Z_andWait(int fn, int speed)
		{
			if (HW.mSmtGenerationNo == 0)
			{
				for (int i = 0; i < HW.mZnNum[fn] / 2; i++)
				{
					if (mCur[fn].z[i * 2] != 0 || mCur[fn].z[i * 2 + 1] != 0)
					{
						mWaitZ[fn][i * 2] = 0;
						mWaitZ[fn][i * 2 + 1] = 0;
						mConDev[fn].sendzCoordinate(i * 2, 0, speed);
					}
				}
			}
			else if (HW.mSmtGenerationNo == 2)
			{
				for (int j = 0; j < HW.mZnNum[fn]; j++)
				{
					mWaitZ[fn][j] = 0;
					if (mCur[fn].z[j] != 0)
					{
						move_z_coordinate_gen2(fn, j, 0, speed);
					}
				}
			}
			for (int k = 0; k < HW.mZnNum[fn]; k++)
			{
				if (mCur[fn].z[k] != 0)
				{
					Waiting(98, fn, k, 15000, 0);
				}
			}
		}

		public static void moveToZero_A_andWait(int fn)
		{
			for (int i = 0; i < HW.mZnNum[fn]; i++)
			{
				mWaitA[fn][i] = 0;
				if (mCur[fn].a[i] != 0)
				{
					move_a_coordinate(fn, i, 0, 40);
				}
			}
			for (int j = 0; j < HW.mZnNum[fn]; j++)
			{
				if (mCur[fn].a[j] != 0)
				{
					Waiting(22, fn, j, 15000, 0);
				}
			}
		}

		public static void moveToZ_andWait(int fn, int zn, int speed, int height)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			if (HW.mSmtGenerationNo == 0)
			{
				int num = height;
				if (zn % 2 == 0)
				{
					if (num > 0)
					{
						num = 0;
					}
					else if (num < -HW.mMaxZ[fn])
					{
						num = -HW.mMaxZ[fn];
					}
				}
				else if (num < 0)
				{
					num = 0;
				}
				else if (num > HW.mMaxZ[fn])
				{
					num = HW.mMaxZ[fn];
				}
				mWaitZ[fn][zn] = num;
				mConDev[fn].sendzCoordinate(zn, num, speed);
			}
			else if (HW.mSmtGenerationNo == 2)
			{
				int num2 = height;
				if (num2 < 0)
				{
					num2 = 0;
				}
				else if (num2 > HW.mMaxZ[fn])
				{
					num2 = HW.mMaxZ[fn];
				}
				mWaitZ[fn][zn] = num2;
				move_z_coordinate_gen2(fn, zn, num2, speed);
			}
			Waiting(98, fn, zn, 15000, 0);
		}

		public static void moveToZ_noWait(int fn, int zn, int speed, int height)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			if (HW.mSmtGenerationNo == 0)
			{
				int num = height;
				if (zn % 2 == 0)
				{
					if (num > 0)
					{
						num = 0;
					}
					else if (num < -HW.mMaxZ[fn])
					{
						num = -HW.mMaxZ[fn];
					}
				}
				else if (num < 0)
				{
					num = 0;
				}
				else if (num > HW.mMaxZ[fn])
				{
					num = HW.mMaxZ[fn];
				}
				mWaitZ[fn][zn] = num;
				mConDev[fn].sendzCoordinate(zn, num, speed);
			}
			else if (HW.mSmtGenerationNo == 2)
			{
				int num2 = height;
				if (num2 < 0)
				{
					num2 = 0;
				}
				else if (num2 > HW.mMaxZ[fn])
				{
					num2 = HW.mMaxZ[fn];
				}
				mWaitZ[fn][zn] = num2;
				move_z_coordinate_gen2(fn, zn, num2, speed);
			}
		}

		public static void WaitComplete_Z(int fn, int zn)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			Waiting(98, fn, zn, 15000, 0);
		}

		public static void moveToA_andWait(int fn, int zn, int speed, int a)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			a %= 25600;
			mWaitA[fn][zn] = a;
			move_a_coordinate(fn, zn, a, speed);
			Waiting(22, fn, zn, 15000, 0);
		}

		public static void moveToA_noWait(int fn, int zn, int speed, int a)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			a %= 25600;
			mWaitA[fn][zn] = a;
			move_a_coordinate(fn, zn, a, speed);
		}

		public static void WaitComplete_A(int fn, int zn)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			Waiting(22, fn, zn, 15000, 0);
		}

		public static int AngleToSteps(float angle)
		{
			return (int)Math.Round((double)(angle * 128f) * 200.0 / 360.0, 0) % (200 * HW.mAaxisSubDivision);
		}

		public static void WaitingAll_Z(int fn, int zn_num, int timeout_ms)
		{
			string text = "                类型F：下位机响应类型" + Environment.NewLine;
			int num = (1 << zn_num) - 1;
			DateTime now = DateTime.Now;
			DateTime now2 = DateTime.Now;
			DateTime now3 = DateTime.Now;
			int num2 = 0;
			do
			{
				for (int i = 0; i < zn_num; i++)
				{
					if ((num & (1 << i)) != 0 && mWaitZ[fn][i] == mCur[fn].z[i])
					{
						num &= ~(1 << i);
					}
				}
				if (num == 0)
				{
					return;
				}
				Thread.Sleep(1);
				num2 = (int)(DateTime.Now - now).TotalMilliseconds;
				if (num2 > timeout_ms)
				{
					break;
				}
				int num3 = (int)(DateTime.Now - now3).TotalMilliseconds;
				if (num3 > timeout_ms * 2 / 3)
				{
					for (int j = 0; j < zn_num; j++)
					{
						if ((num & (1 << j)) != 0)
						{
							if (HW.mSmtGenerationNo == 0)
							{
								mConDev[0].sendzCoordinate(j, mWaitZ[fn][j], 48);
							}
							else if (HW.mSmtGenerationNo == 2)
							{
								move_z_coordinate_gen2(fn, j, mWaitZ[fn][j], 48);
							}
						}
					}
					now3 = DateTime.Now;
					text = text + "                响应活动点: 0x" + mResponseCheckCount.ToString("X") + Environment.NewLine;
					Thread.Sleep(300);
				}
				int num4 = (int)(DateTime.Now - now2).TotalMilliseconds;
				if (num4 <= 200)
				{
					continue;
				}
				for (int k = 0; k < zn_num; k++)
				{
					if ((num & (1 << k)) != 0)
					{
						read_z_coordinate(fn, k);
					}
				}
				now2 = DateTime.Now;
				Thread.Sleep(200);
			}
			while (num != 0);
			if (num2 <= timeout_ms && num == 0)
			{
				return;
			}
			for (int l = 0; l < zn_num; l++)
			{
				if ((num & (1 << l)) != 0)
				{
					string text2 = text;
					text = text2 + "                吸嘴" + (l + 1) + ", Z轴" + Environment.NewLine + "                目标坐标: " + mWaitZ[fn][l] + Environment.NewLine + "                实际坐标: " + mCur[fn].z[l] + Environment.NewLine;
				}
			}
			text = text + "                响应活动点: 0x" + mResponseCheckCount.ToString("X") + Environment.NewLine;
			write_to_logFile(mLogFileName, text);
			Form_NoticeError fm = new Form_NoticeError(USR_INIT.mLanguage, "系统硬件出现异常，需要重启软件");
			static_this.Invoke((MethodInvoker)delegate
			{
				fm.ShowDialog();
				Environment.Exit(0);
			});
		}

		public static void Waiting(int cmd, int fn, int zn, int timeout_ms, int com)
		{
			bool flag = false;
			int millisecondsTimeout = 1;
			int num = 100;
			if (mIsSimulation)
			{
				switch (cmd)
				{
				case 98:
					mCur[fn].z[zn] = mWaitZ[fn][zn];
					break;
				case 96:
					mCur[fn].x = (int)mWaitXY[fn].X;
					mCur[fn].y = (int)mWaitXY[fn].Y;
					break;
				case 22:
					mCur[fn].a[zn] = mWaitA[fn][zn];
					break;
				}
			}
			DateTime now = DateTime.Now;
			double num2 = 0.0;
			if (cmd == 98)
			{
				do
				{
					DateTime now2 = DateTime.Now;
					double num3 = 0.0;
					do
					{
						if (mWaitZ[fn][zn] == mCur[fn].z[zn])
						{
							return;
						}
						Thread.Sleep(millisecondsTimeout);
						num3 = (DateTime.Now - now2).TotalMilliseconds;
					}
					while (num3 <= (double)num);
					read_z_coordinate(fn, zn);
					num2 = (DateTime.Now - now).TotalMilliseconds;
				}
				while (num2 <= (double)timeout_ms);
			}
			else if (cmd == 96)
			{
				do
				{
					DateTime now3 = DateTime.Now;
					double num4 = 0.0;
					do
					{
						if (mWaitXY[fn].X == mCur[fn].x && mWaitXY[fn].Y == mCur[fn].y)
						{
							return;
						}
						Thread.Sleep(millisecondsTimeout);
						num4 = (DateTime.Now - now3).TotalMilliseconds;
					}
					while (num4 <= (double)num);
					mConDev[fn].readxyCoordinate();
					num2 = (DateTime.Now - now).TotalMilliseconds;
				}
				while (num2 <= (double)timeout_ms);
			}
			else if (cmd == 22)
			{
				do
				{
					DateTime now4 = DateTime.Now;
					double num5 = 0.0;
					do
					{
						if (aStepTip(mWaitA[fn][zn]) == aStepTip(mCur[fn].a[zn]))
						{
							return;
						}
						Thread.Sleep(millisecondsTimeout);
						num5 = (DateTime.Now - now4).TotalMilliseconds;
					}
					while (num5 <= (double)num);
					read_a_coordinate(fn, zn);
					num2 = (DateTime.Now - now).TotalMilliseconds;
				}
				while (num2 <= (double)timeout_ms);
			}
			else if (cmd == 127)
			{
				do
				{
					DateTime now5 = DateTime.Now;
					for (double num6 = 0.0; num6 <= (double)num; num6 = (DateTime.Now - now5).TotalMilliseconds)
					{
						if (mResetState2[fn] != 0)
						{
							return;
						}
						Thread.Sleep(millisecondsTimeout);
					}
					num2 = (DateTime.Now - now).TotalMilliseconds;
				}
				while (num2 <= (double)timeout_ms);
			}
			if (num2 <= (double)timeout_ms)
			{
				flag = true;
				return;
			}
			string text = "";
			switch (cmd)
			{
			case 22:
			{
				int value = mCur[fn].a[zn];
				text = "                类型F：下位机响应类型" + Environment.NewLine + "                第" + (com + 1) + "主板, 吸嘴" + (zn + 1) + ", A轴" + Environment.NewLine + "                目标坐标: " + mWaitA[fn][zn] + " (" + aStepTip(mWaitA[fn][zn]) + ")" + Environment.NewLine + "                实际坐标: " + value + " (" + aStepTip(value) + ")" + Environment.NewLine;
				break;
			}
			case 98:
			{
				int num9 = mCur[fn].z[zn];
				text = "                类型F：下位机响应类型" + Environment.NewLine + "                第" + (com + 1) + "主板, 吸嘴" + (zn + 1) + ", Z轴" + Environment.NewLine + "                目标坐标: " + mWaitZ[fn][zn] + Environment.NewLine + "                实际坐标: " + num9 + Environment.NewLine;
				break;
			}
			case 96:
			{
				int num7 = mCur[fn].x;
				int num8 = mCur[fn].y;
				text = "                类型F：下位机响应类型" + Environment.NewLine + "                第" + (com + 1) + "主板, XY轴" + Environment.NewLine + "                目标坐标: (" + mWaitXY[fn].X + ", " + mWaitXY[fn].Y + ")" + Environment.NewLine + "                实际坐标: (" + num7 + ", " + num8 + ")" + Environment.NewLine;
				break;
			}
			case 127:
				text = "                类型F：下位机响应类型" + Environment.NewLine + "                第" + (com + 1) + "主板, 复位" + Environment.NewLine;
				break;
			}
			text = text + "                响应活动点: 0x" + mResponseCheckCount.ToString("X") + Environment.NewLine;
			write_to_logFile(mLogFileName, text);
			text = "";
			switch (cmd)
			{
			case 22:
			{
				int value2 = mCur[fn].a[zn];
				move_a_coordinate(fn, zn, mWaitA[fn][zn], (U3[fn] == null) ? USR[fn].mASpeed : U3[fn][U3Idx[fn]].mSmtASpeed);
				Thread.Sleep(300);
				text = "                类型F：下位机响应类型" + Environment.NewLine + "                第" + (com + 1) + "主板, 吸嘴" + (zn + 1) + ", A轴" + Environment.NewLine + "                目标坐标: " + mWaitA[fn][zn] + " (" + aStepTip(mWaitA[fn][zn]) + ")" + Environment.NewLine + "                实际坐标: " + value2 + " (" + aStepTip(value2) + ")" + Environment.NewLine + "                重读坐标: " + mCur[fn].a[zn] + " (" + aStepTip(mCur[fn].a[zn]) + ")" + Environment.NewLine;
				break;
			}
			case 98:
			{
				int num12 = mCur[fn].z[zn];
				if (HW.mSmtGenerationNo == 0)
				{
					mConDev[fn].sendzCoordinate(zn, mWaitZ[fn][zn], 48);
				}
				else if (HW.mSmtGenerationNo == 2)
				{
					move_z_coordinate_gen2(fn, zn, mWaitZ[fn][zn], 48);
				}
				Thread.Sleep(100);
				text = "                类型F：下位机响应类型" + Environment.NewLine + "                第" + (com + 1) + "主板, 吸嘴" + (zn + 1) + ", Z轴" + Environment.NewLine + "                目标坐标: " + mWaitZ[fn][zn] + Environment.NewLine + "                实际坐标: " + num12 + Environment.NewLine + "                重读坐标: " + mCur[fn].z[zn] + Environment.NewLine;
				break;
			}
			case 96:
			{
				int num10 = mCur[fn].x;
				int num11 = mCur[fn].y;
				mConDev[fn].sendxyCoordinate((int)mWaitXY[fn].X, (int)mWaitXY[fn].Y, (U3[fn] == null) ? USR[fn].mXYSpeed : U3[fn][U3Idx[fn]].mSmtXYSpeed);
				mConDev[fn].readxyCoordinate();
				Thread.Sleep(100);
				text = "                类型F：下位机响应类型" + Environment.NewLine + "                第" + (com + 1) + "主板, XY轴" + Environment.NewLine + "                目标坐标: (" + mWaitXY[fn].X + ", " + mWaitXY[fn].Y + ")" + Environment.NewLine + "                实际坐标: (" + num10 + ", " + num11 + ")" + Environment.NewLine + "                重读坐标: (" + mCur[fn].x + ", " + mCur[fn].y + ")" + Environment.NewLine;
				break;
			}
			case 127:
				text = "                类型F：下位机响应类型" + Environment.NewLine + "                第" + (com + 1) + "主板, 复位" + Environment.NewLine;
				write_to_logFile(mLogFileName, text);
				return;
			}
			text = text + "                响应活动点: 0x" + mResponseCheckCount.ToString("X") + Environment.NewLine;
			write_to_logFile(mLogFileName, text);
			if (!flag)
			{
				Form_NoticeError form_NoticeError = new Form_NoticeError(USR_INIT.mLanguage, "系统硬件出现异常，需要重启软件，并打开日志查看异常");
				form_NoticeError.ShowDialog();
				Environment.Exit(0);
			}
		}

		private void thd_updateConnectBt(object o)
		{
			Invoke((MethodInvoker)delegate
			{
				btn_Connect.Text = STR.CONNECT[(((bool)o) ? 1 : 0) * 3 + USR_INIT.mLanguage];
			});
		}

		private void updateConnectButton(bool isConnect)
		{
			Thread thread = new Thread(thd_updateConnectBt);
			thread.IsBackground = true;
			thread.Start(isConnect);
		}

		private void updateCoordinateXY(int fn, int x, int y)
		{
			if (uc_usroperarion != null && !uc_usroperarion[fn].IsDisposed)
			{
				uc_usroperarion[fn].updateCoordinateXY(x, y);
			}
		}

		private void updateCoordinateZ(int fn, int zn, int value)
		{
			if (uc_usroperarion != null && !uc_usroperarion[fn].IsDisposed)
			{
				uc_usroperarion[fn].updateCoordinateZ(zn, value);
			}
		}

		private void updateCoordinateA(int fn, int zn, int value)
		{
			if (uc_usroperarion != null && !uc_usroperarion[fn].IsDisposed)
			{
				uc_usroperarion[fn].updateCoordinateA(zn, value);
			}
		}

		private void Reset(int fn)
		{
			if (mMutexMoveXYZA)
			{
				return;
			}
			mMutexMoveXYZA = true;
			if (CmMessageBox(STR.RESET_ORNOT[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				UI_ControlEnable(fn, flag: false, UI_ENABLE.USR);
				for (int i = 0; i < HW.mZnNum[fn]; i++)
				{
					misc_vacc_onoff(fn, i, 0);
				}
				for (int j = 0; j < HW.mStackNum[fn][0]; j++)
				{
					misc_feeder_onoff(fn, ProviderType.Feedr, j, flag: false);
				}
				if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
				{
					mResetState2[0] = ResetState.Unknown;
					mResetState2[1] = ResetState.Unknown;
					mConDev[0].sendReset(1);
					mConDev2[0].sendReset(1);
					while (mResetState2[0] == ResetState.Unknown || mResetState2[1] == ResetState.Unknown)
					{
						Thread.Sleep(1);
					}
					if (mResetState2[0] == ResetState.Fail)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "第一块主板ZA复位失败，请重启机器！");
						Environment.Exit(0);
						return;
					}
					if (mResetState2[1] == ResetState.Fail)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "第二块主板ZA复位失败，请重启机器！");
						Environment.Exit(0);
						return;
					}
					mResetState2[0] = ResetState.Unknown;
					mConDev[0].sendReset(2);
					while (mResetState2[0] == ResetState.Unknown)
					{
						Thread.Sleep(1);
					}
					if (mResetState2[0] == ResetState.Fail)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "第一块主板XY复位失败，请重启机器！");
						Environment.Exit(0);
						return;
					}
					bmIsConnected = true;
					updateConnectButton(bmIsConnected);
					updateCoordinateXY(fn, mCur[fn].x, mCur[fn].y);
					for (int k = 0; k < HW.mZnNum[mFn]; k++)
					{
						updateCoordinateZ(fn, k, mCur[fn].z[k]);
						updateCoordinateA(fn, k, mCur[fn].a[k]);
					}
				}
				else
				{
					mResetState2[fn] = ResetState.Unknown;
					mConDev[fn].sendReset();
					Waiting(127, fn, 0, 15000, 0);
				}
				UI_ControlEnable(fn, flag: true, UI_ENABLE.USR);
				mMutexMoveXYZA = false;
			}
			else
			{
				mMutexMoveXYZA = false;
			}
		}

		public static void pcbcheck_sel_nearestchip(int fn)
		{
			if (mIsAutoSelect_PcbCheck_NearestMarkChip[fn])
			{
				static_this.Invoke((MethodInvoker)delegate
				{
					uc_job[fn].sel_nearest_chip(new Coordinate(mCur[fn].x, mCur[fn].y));
				});
			}
		}

		public static void move_z_coordinate_gen2(int fn, int zn, int value, int speed)
		{
			if (zn < 4)
			{
				mConDev[fn].sendzCoordinate_gen2(zn, value, speed);
			}
			else
			{
				mConDev2[fn].sendzCoordinate_gen2(zn - 4, value, speed);
			}
		}

		public static void move_z_constant_gen2(int fn, QnCommon.RunDirEn dir, int zn, int zspeed)
		{
			if (HW.mDeviceType == DeviceType.DSQ800_120F || HW.mDeviceType == DeviceType.DUDU_400 || HW.mDeviceType == DeviceType.DUDU_400_64FX || HW.mDeviceType == DeviceType.DUDU_400_50K)
			{
				mConDev[fn].sendzConstantSpeed_gen2(dir, zn, zspeed);
			}
			else if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
			{
				if (zn / 4 == 1)
				{
					mConDev2[fn].sendzConstantSpeed_gen2(dir, zn % 4, zspeed);
				}
				else if (zn / 4 == 0)
				{
					mConDev[fn].sendzConstantSpeed_gen2(dir, zn % 4, zspeed);
				}
			}
		}

		public static void move_stop_gen2(int fn)
		{
			if (HW.mDeviceType == DeviceType.DSQ800_120F || HW.mDeviceType == DeviceType.DUDU_400 || HW.mDeviceType == DeviceType.DUDU_400_64FX || HW.mDeviceType == DeviceType.DUDU_400_50K)
			{
				mConDev[fn].SendStopMove();
			}
			else if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
			{
				if (mZn[fn] / 4 == 1)
				{
					mConDev2[fn].SendStopMove();
				}
				else if (mZn[fn] / 4 == 0)
				{
					mConDev[fn].SendStopMove();
				}
			}
		}

		public static void read_z_coordinate(int fn, int zn)
		{
			if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
			{
				if (zn / 4 == 1)
				{
					mConDev2[fn].readzCoordinate(zn % 4);
				}
				else if (zn / 4 == 0)
				{
					mConDev[fn].readzCoordinate(zn % 4);
				}
			}
			else
			{
				mConDev[fn].readzCoordinate(zn);
			}
		}

		public static void move_a_coordinate(int fn, int zn, int value, int speed)
		{
			if (HW.mSmtGenerationNo == 0)
			{
				mConDev[fn].sendaCoordinate(zn, value, speed);
			}
			else if (zn < 4)
			{
				mConDev[fn].sendaCoordinate(zn, value, speed);
			}
			else
			{
				mConDev2[fn].sendaCoordinate(zn - 4, value, speed);
			}
		}

		public static void move_a_constant(int fn, QnCommon.RunDirEn dir, int zn, int speed)
		{
			if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
			{
				if (zn / 4 == 1)
				{
					mConDev2[fn].sendaConstantSpeed(dir, zn % 4, speed);
				}
				else if (zn / 4 == 0)
				{
					mConDev[fn].sendaConstantSpeed(dir, zn % 4, speed);
				}
			}
			else
			{
				mConDev[fn].sendaConstantSpeed(dir, zn, speed);
			}
		}

		public static void read_a_coordinate(int fn, int zn)
		{
			if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
			{
				if (zn / 4 == 1)
				{
					mConDev2[fn].readaCoordinate(zn % 4);
				}
				else if (zn / 4 == 0)
				{
					mConDev[fn].readaCoordinate(zn % 4);
				}
			}
			else
			{
				mConDev[fn].readaCoordinate(zn);
			}
		}

		public void misc_board_out(int fn, int psd, int delay, bool useBTC)
		{
			if (mConDevExt != null && mConDevExt[fn] != null)
			{
				mConDevExt[fn].sendOutBoard(fn, psd, delay, useBTC);
			}
			if (HW.mFnNum >= 2 && USR3_INIT != null && USR3_INIT.mIsLoukong && USR3B[fn] != null)
			{
				if (fn == HW.mFnNum - 1)
				{
					Invoke((MethodInvoker)delegate
					{
						uc_smtRunning.ucs_singlesmt[fn].set_loukong_takeaway_visiable(flag: true);
					});
				}
			}
			else if (USR3B[fn] != null && USR3B[fn].mIsLoukongPCB && USR_INIT.mIsBCTEnabled)
			{
				Invoke((MethodInvoker)delegate
				{
					uc_job[fn].set_loukong_takeaway_visiable(flag: true);
				});
			}
		}

		private void btn_Throw_Click(object sender, EventArgs e)
		{
			if (!mMutexMoveXYZA)
			{
				mMutexMoveXYZA = true;
				Thread thread = new Thread(thd_Throw);
				thread.IsBackground = true;
				thread.Start(new int_2d(mFn, mZn[mFn]));
			}
		}

		public static void thd_Throw(object o)
		{
			int a = ((int_2d)o).a;
			int b = ((int_2d)o).b;
			moveToZero_ZA_andWait(a);
			moveToXY_andWait(a, USR[a].mXYSpeed, new Coordinate(USR[a].mThrowCoord.X - USR[a].mDeltaNozzle[0][b].X, USR[a].mThrowCoord.Y - USR[a].mDeltaNozzle[0][b].Y));
			misc_vacc_onoff(a, b, 0);
			mMutexMoveXYZA = false;
			fhcam_led_on_ext(a, CameraType.Fast, flag: false);
			fhcam_led_on_ext(a, CameraType.High, flag: false);
			mark_led_on_ext(a, flag: true);
			mark_light_on_ext(a, flag: true);
		}

		public static void throw_andWait(int tn, int zn, int speed)
		{
		}

		private void button_CamPara_Click(object sender, EventArgs e)
		{
			vsplus_open_campara();
		}

		private bool initAHD8()
		{
			mJVS_OpenedPreviewMask = 0;
			int fn;
			for (fn = 0; fn < HW.mFnNum; fn++)
			{
				PicBox_Preview2[fn].Invoke((MethodInvoker)delegate
				{
					PicBox_Preview2[fn].Visible = true;
					PicBox_Preview2[fn].Size = new Size(978, 550);
					PicBox_Preview2[fn].Location = new Point(-(PicBox_Preview2[fn].Size.Width - 550) / 2 - USR[mFn].mPreviewOffset_X, -USR[mFn].mPreviewOffset_Y);
					mRect = default(RECT);
					mRect.bottom = PicBox_Preview2[fn].Bottom;
					mRect.left = PicBox_Preview2[fn].Left;
					mRect.top = PicBox_Preview2[fn].Top;
					mRect.right = PicBox_Preview2[fn].Right;
					ref IntPtr reference = ref mRectHandle[fn];
					reference = PicBox_Preview2[fn].Handle;
					PicBox_Preview2[fn].BackColor = Color.Green;
				});
			}
			if (mIsSimulation)
			{
				mJvs_Channels = HW.mCamATotalNum;
				return true;
			}
			if (m_InitDone == 1)
			{
				uninitAHD8();
			}
			DvrshMethod.SetMax_VideoSize(1280, 720);
			int num = DvrshMethod.InitHwDSPs();
			int videoTotalChannels = DvrshMethod.GetVideoTotalChannels();
			if (videoTotalChannels == 0)
			{
				CmMessageBoxTop_Ok("没有采集卡！" + num);
				return false;
			}
			write_to_logFile("初始化 " + num + "， 采集卡通道数量： " + videoTotalChannels);
			mJvs_Channels = videoTotalChannels;
			if (mJvs_Channels >= HW.mCamATotalNum)
			{
				m_hDSP = new int[mJvs_Channels];
				for (int i = 0; i < mJvs_Channels; i++)
				{
					m_hDSP[i] = DvrshMethod.VideoChannelOpen(i, 1280, 720, 25);
				}
				int num2 = HW.mMarkCamItem[mFn].index[0];
				if (m_hDSP[num2] != -1)
				{
					openAHD8Preview(num2);
				}
				m_InitDone = 1;
				init_ahd8_callback();
				return true;
			}
			return false;
		}

		private void uninitAHD8()
		{
			if (m_InitDone == 0)
			{
				return;
			}
			int fn;
			for (fn = 0; fn < HW.mFnNum; fn++)
			{
				closeAHD8Preview(fn);
				PicBox_Preview2[fn].Invoke((MethodInvoker)delegate
				{
					PicBox_Preview2[fn].Refresh();
				});
			}
			for (int i = 0; i < mJvs_Channels; i++)
			{
				if (m_hDSP[i] != -1)
				{
					DvrshMethod.StopVideoCapture(m_hDSP[i]);
					m_hDSP[i] = -1;
				}
			}
			DvrshMethod.DeInitHwDSPs();
			m_InitDone = 0;
		}

		public bool openAHD8Preview(int nChannel)
		{
			if (((mJVS_OpenedPreviewMask >> nChannel) & 1) == 1)
			{
				return true;
			}
			int num = HW.mMFCamChnFn[nChannel];
			closeAHD8Preview(num);
			if (!mIsSimulation)
			{
				if (m_hDSP == null)
				{
					return true;
				}
				PicBox_Preview2[num].Visible = true;
				_ = mJvs_rawWidth * 550 / 720 / 2;
				_ = mJvs_rawHeight * 550 / 720 / 2;
				if (nChannel != HW.mMarkCamItem[num].index[0])
				{
					_ = USR[num].mFastCamCenterDeltaX[0][mZn[num]];
				}
				DvrshMethod.StartVideoPreview(m_hDSP[nChannel], mRectHandle[num], ref mRect);
			}
			mJVS_OpenedPreviewMask |= 1 << nChannel;
			return true;
		}

		public static bool closeAHD8Preview(int fn)
		{
			int num = 0;
			while (mJVS_OpenedPreviewMask != 0)
			{
				if (!mIsSimulation && (mJVS_OpenedPreviewMask & 1) == 1)
				{
					if (m_hDSP == null)
					{
						return true;
					}
					DvrshMethod.StartVideoPreview(m_hDSP[num], IntPtr.Zero, ref mRect);
				}
				mJVS_OpenedPreviewMask >>= 1;
				num++;
			}
			PicBox_Preview2[fn].Invoke((MethodInvoker)delegate
			{
				PicBox_Preview2[fn].Visible = false;
			});
			return true;
		}

		public static bool startAHD8Still_noWait(CameraType camtype, int fn, int zn)
		{
			int num = 0;
			int num2 = 100;
			bool flag = mDebug_Factory;
			switch (camtype)
			{
			case CameraType.Mark:
				num = HW.mMarkCamItem[fn].index[0];
				if (USR[fn].mMarkCamStillDelay <= 10)
				{
					USR[fn].mMarkCamStillDelay = 100;
				}
				num2 = USR[fn].mMarkCamStillDelay;
				if (flag)
				{
					write_to_logFile(mLogFileName, "startJVSStill_noWait: ch=" + num + " still_delay=" + num2 + Environment.NewLine);
				}
				return ahd8still_nowait(num, num2);
			case CameraType.Fast:
				num = HW.mFastCamItem[fn].index[zn];
				num2 = ((USR2[fn] == null) ? USR[fn].mfcam_stilldelay : USR2[fn].mFastCamStillDelay[0]);
				if (flag)
				{
					write_to_logFile(mLogFileName, "startJVSStill_noWait: ch=" + num + " still_delay=" + num2 + Environment.NewLine);
				}
				return ahd8still_nowait(num, num2);
			default:
				return false;
			}
		}

		public static bool ahd8still_nowait(int ch, int still_delay)
		{
			if (mIsSimulation)
			{
				bJVSCameraRecived[ch] = true;
				return true;
			}
			_ = mJvs_rawWidth;
			_ = mJvs_rawHeight;
			bJVSCameraRecived[ch] = false;
			jvsstill_LockBitmap(ch);
			AHD8_Capture(ch);
			return true;
		}

		private static void startAHD8Still_andWait(CameraType camtype, int fn, int zn)
		{
			int num = 0;
			int num2 = 500;
			switch (camtype)
			{
			case CameraType.Mark:
				num = HW.mMarkCamItem[fn].index[0];
				if (USR[fn].mMarkCamStillDelay <= 10)
				{
					USR[fn].mMarkCamStillDelay = 100;
				}
				num2 = USR[fn].mMarkCamStillDelay;
				ahd8still_andwait(num, num2);
				break;
			case CameraType.Fast:
				num = HW.mFastCamItem[fn].index[zn];
				num2 = ((USR2[fn] == null) ? USR[fn].mfcam_stilldelay : USR2[fn].mFastCamStillDelay[0]);
				ahd8still_andwait(num, num2);
				break;
			}
		}

		public static void ahd8still_andwait(int ch, int still_delay)
		{
			if (mIsSimulation)
			{
				bJVSCameraRecived[ch] = true;
				return;
			}
			bJVSCameraRecived[ch] = false;
			jvsstill_LockBitmap(ch);
			if (still_delay > 0)
			{
				Thread.Sleep(still_delay);
			}
			AHD8_Capture(ch);
			while (!bJVSCameraRecived[ch])
			{
				Thread.Sleep(1);
			}
			bJVSCameraRecived[ch] = false;
			jvsstill_UnlockBitmap(ch);
		}

		private static void AHD8_Capture(int ch)
		{
			Thread thread = new Thread(thd_ahd8_capture);
			thread.IsBackground = true;
			thread.Start(ch);
		}

		private static void thd_ahd8_capture(object o)
		{
			int num = (int)o;
			if (mIsSimulation)
			{
				bJVSCameraRecived[num] = true;
				return;
			}
			int offset = 4;
			_ = mJvs_rawWidth;
			_ = mJvs_rawHeight;
			byte[] pDIBits = ahd8_pYuvBuffer[num];
			if (is_ahd8_callbackmode)
			{
				is_ahd8_start_capture[num] = true;
				offset = 0;
				while (is_ahd8_start_capture[num])
				{
					Thread.Sleep(0);
				}
			}
			byte[] array = ahd8_pRgb32Buffer[num];
			moon_yuyv_to_rgb32(pDIBits, array, mJvs_rawWidth, mJvs_rawHeight, offset);
			Marshal.Copy(array, 0, mJVSBitmap_Data[num].Scan0, mJvs_rawWidth * mJvs_rawHeight * 4);
			bJVSCameraRecived[num] = true;
		}

		public void vsplus_pcbedit_load(int fn)
		{
			uc_job[fn].instantiation(USR[fn], USR2[fn], USR3B[fn], U3[fn], U3Idx[fn]);
		}

		public void vsplus_pcbedit_unload(int fn)
		{
			uc_job[fn].clear_continuemode();
			uc_job[fn].uninstantiation();
		}

		public static void vsplus_pcbedit_gotoxy_post(int fn, int x, int y, float ag)
		{
			if (x >= 0 && y >= 0)
			{
				if (uc_usroperarion[fn] != null && !uc_usroperarion[fn].IsDisposed)
				{
					uc_usroperarion[fn].switch_to_cam(CameraType.Mark);
				}
				Thread thread = new Thread(thd_MoveToAbsoluteXYOperate);
				thread.IsBackground = true;
				thread.Start(new Coordinate(x, y));
				if (uc_usroperarion[fn] != null && !uc_usroperarion[fn].IsDisposed)
				{
					uc_usroperarion[fn].set_chipBox(USR[fn].mBoxWidth, USR[fn].mBoxHeight, ag);
				}
			}
		}

		public static void vsplus_pcbedit_gotoxy(Coordinate o)
		{
			if (uc_usroperarion[mFn] != null && !uc_usroperarion[mFn].IsDisposed)
			{
				uc_usroperarion[mFn].switch_to_cam(CameraType.Mark);
			}
			Thread thread = new Thread(thd_MoveToAbsoluteXYOperate);
			thread.IsBackground = true;
			thread.Start(o);
		}

		public FeederType check_return_feedertype(string str)
		{
			switch (str)
			{
			case "CL8_2_0201":
			case "CL8-2-0201":
				return FeederType.CL8_2_0201;
			case "CL8_2":
			case "CL8-2":
				return FeederType.CL8_2;
			case "CL8_4":
			case "CL8-4":
				return FeederType.CL8_4;
			case "CL12":
				return FeederType.CL12;
			case "CL16":
				return FeederType.CL16;
			case "CL24":
				return FeederType.CL24;
			case "CL32":
				return FeederType.CL32;
			case "CL44":
				return FeederType.CL44;
			case "料盘":
				return FeederType.Plate;
			case "震动飞达":
			case "振动飞达":
				return FeederType.Vibra;
			default:
				return FeederType.N_A;
			}
		}

		public ProviderType check_return_providertype(string str)
		{
			switch (str)
			{
			case "CL8_2_0201":
			case "CL8-2-0201":
				return ProviderType.Feedr;
			case "CL8_2":
			case "CL8-2":
				return ProviderType.Feedr;
			case "CL8_4":
			case "CL8-4":
				return ProviderType.Feedr;
			case "CL12":
				return ProviderType.Feedr;
			case "CL16":
				return ProviderType.Feedr;
			case "CL24":
				return ProviderType.Feedr;
			case "料盘":
				return ProviderType.Plate;
			case "震动飞达":
			case "振动飞达":
				return ProviderType.Vibra;
			default:
				return ProviderType.Feedr;
			}
		}

		public static ProviderType check_return_providertype(FeederType fd)
		{
			return fd switch
			{
				FeederType.Vibra => ProviderType.Vibra, 
				FeederType.Plate => ProviderType.Plate, 
				_ => ProviderType.Feedr, 
			};
		}

		public int check_return_intno(string str)
		{
			float num = 0f;
			try
			{
				num = float.Parse(str);
			}
			catch (Exception)
			{
				write_to_logFile("EXCEPTION:check_return_intno " + str);
				num = 0f;
			}
			return (int)num;
		}

		public float check_return_floatvalue(string str)
		{
			float num = 0f;
			try
			{
				return float.Parse(str);
			}
			catch (Exception)
			{
				write_to_logFile("EXCEPTION:check_return_floatvalue " + str);
				return 0f;
			}
		}

		public int check_return_nozzletype(string str)
		{
			return str switch
			{
				"500" => 0, 
				"501" => 1, 
				"502" => 2, 
				"503" => 3, 
				"504" => 4, 
				"505" => 5, 
				"506" => 6, 
				"507" => 7, 
				"508" => 8, 
				"509" => 9, 
				_ => -1, 
			};
		}

		public CameraType check_return_cameratype(string str)
		{
			switch (str)
			{
			case "普通相机":
			case "快速相机":
				return CameraType.Fast;
			case "高清相机":
				return CameraType.High;
			case "无相机":
				return CameraType.None;
			default:
				return CameraType.N_A;
			}
		}

		public VisualType check_return_visualtype(string str)
		{
			switch (str)
			{
			case "普通视觉":
			case "普通识别":
			case "标准视觉":
			case "标准识别":
				return VisualType.Normal;
			case "模糊视觉":
			case "模糊识别":
				return VisualType.Draft;
			case "三角透镜":
				return VisualType.TriAG;
			case "忽略角度":
				return VisualType.NoAngle;
			case "半角补偿":
			case "半角识别":
				return VisualType.D45Angle;
			case "多体识别":
				return VisualType.MultiRec;
			case "降噪处理":
				return VisualType.NormalNew1;
			case "SOT23-3":
				return VisualType.SOT23_3;
			case "大功率灯":
				return VisualType.Ellipe;
			case "精准BGA":
				return VisualType.ConvexBGA;
			case "矩形玻璃片":
				return VisualType.TranRec0;
			case "无极性电感":
				return VisualType.NonpolarHn;
			case "ICNT7183":
				return VisualType.YIX_ICNT7183;
			case "BF5325":
				return VisualType.YIX_BF5325;
			case "标准矩形":
				return VisualType.Rectangle;
			default:
				return VisualType.N_A;
			}
		}

		public LoopType check_return_looptype(string str)
		{
			switch (str)
			{
			case "开环":
			case "普通开环":
			case "标准开环":
				return LoopType.OpenLoop;
			case "二阶闭环":
				return LoopType.HalfLoop;
			case "精准闭环":
			case "全闭环":
				return LoopType.CloseLoop;
			default:
				return LoopType.N_A;
			}
		}

		public bool check_return_ismount(string str)
		{
			switch (str)
			{
			case "不贴装":
			case "不贴":
			case "跳空":
			case "人工跳空":
			case "否":
				return false;
			default:
				return true;
			}
		}

		public bool check_return_islowspeed(string str)
		{
			switch (str)
			{
			case "降速搬运":
			case "降速":
			case "是":
				return true;
			default:
				return false;
			}
		}

		public bool check_return_iscollect(string str)
		{
			if (str == "是")
			{
				return true;
			}
			return false;
		}

		public bool check_return_ispricise(string str)
		{
			if (str == "精准闭环" || str == "精准模式" || str == "精准识别" || str == "精准视觉" || str == "精准识别" || str == "是" || str == "闭环" || str == "闭环")
			{
				return true;
			}
			return false;
		}

		public bool check_return_ishigh(string str)
		{
			switch (str)
			{
			case "高料":
			case "是高料":
			case "是":
				return true;
			default:
				return false;
			}
		}

		public SnHead check_return_snhead(string str)
		{
			if (str == "位号" || str == "位置号")
			{
				return SnHead.LABEL;
			}
			if (str == "封装")
			{
				return SnHead.FOOTPRINT;
			}
			if (str == "型号" || str == "值")
			{
				return SnHead.VALUE;
			}
			if (str == "X" || str == "X坐标" || str == "X中心")
			{
				return SnHead.X;
			}
			if (str == "Y" || str == "Y坐标" || str == "Y中心")
			{
				return SnHead.Y;
			}
			if (str == "A" || str == "角度")
			{
				return SnHead.A;
			}
			if (str == "供料器" || str == "供料器型号" || str == "供料器类型" || str == "飞达" || str == "飞达型号" || str == "飞达类型")
			{
				return SnHead.FEEDERTYPE;
			}
			if (str == "料站号" || str == "飞达号" || str == "料站编号" || str == "飞达编号")
			{
				return SnHead.STACKNO;
			}
			if (str == "吸嘴类型" || str == "吸嘴型号")
			{
				return SnHead.NOZZLETYPE;
			}
			if (str == "吸嘴号" || str == "吸嘴编号")
			{
				return SnHead.NOZZLENO;
			}
			if (str == "相机" || str == "相机类型" || str == "相机型号")
			{
				return SnHead.CAMERA;
			}
			if (str == "视觉" || str == "视觉类型" || str == "识别类型" || str == "识别算法" || str == "视觉算法")
			{
				return SnHead.VISUAL;
			}
			if (str == "精准闭环" || str == "精准模式" || str == "闭环模式")
			{
				return SnHead.ISPRICISE;
			}
			if (str == "扫描半径")
			{
				return SnHead.SCANR;
			}
			if (str == "视觉阈值")
			{
				return SnHead.THRESHOLD;
			}
			if (str == "长度" || str == "长" || str == "元件长度")
			{
				return SnHead.LENGHT;
			}
			if (str == "宽度" || str == "宽" || str == "元件宽度")
			{
				return SnHead.WIDTH;
			}
			if (str == "高度" || str == "高" || str == "元件高度")
			{
				return SnHead.HEIGHT;
			}
			if (str == "特征识别")
			{
				return SnHead.ISCOLLECT;
			}
			if (str == "识别容差")
			{
				return SnHead.COLLECT_DELTA;
			}
			if (str == "取料下压偏移" || str == "取料下压缓冲" || str == "拾取下压偏移" || str == "取料下压缓冲")
			{
				return SnHead.PIK_H_OFFSET;
			}
			if (str == "取料上拉速度" || str == "取料Z上拉速度" || str == "取料Z轴上拉速度")
			{
				return SnHead.SPEEDZ_UP;
			}
			if (str == "取料下伸速度" || str == "取料Z下伸速度" || str == "取料Z轴下伸速度")
			{
				return SnHead.SPEEDZ_DOWN;
			}
			if (str == "取料延时")
			{
				return SnHead.PIK_DELAY;
			}
			if (!(str == "贴装下压偏移") && !(str == "贴装下压缓冲"))
			{
				switch (str)
				{
				case "贴装下压偏移":
				case "贴装下压缓冲":
					break;
				case "贴装上拉速度":
				case "贴装Z上拉速度":
				case "贴装Z轴上拉速度":
					return SnHead.ZMNT_UP_SPEED;
				case "贴装下伸速度":
				case "贴装Z下伸速度":
				case "贴装Z轴下伸速度":
					return SnHead.ZMNT_DOWN_SPEED;
				case "贴装延时":
					return SnHead.MNT_DELAY;
				case "同取容差":
					return SnHead.SAMPIK;
				case "是否贴装":
				case "贴装":
					return SnHead.ISMOUNT;
				case "降速搬运":
				case "是否降速搬运":
				case "降速":
					return SnHead.ISLOWSPEED;
				case "是否高料":
				case "高料":
					return SnHead.ISHIGH;
				default:
					return SnHead.NUM;
				}
			}
			return SnHead.MNT_H_OFFSET;
		}

		private void ahd8_RawStreamDirectReadCallback(int ch, IntPtr DataBuf, int FrameType, int width, int height, IntPtr Context)
		{
			if (is_ahd8_start_capture[ch])
			{
				Marshal.Copy(DataBuf, ahd8_pYuvBuffer[ch], 0, 1843200);
				is_ahd8_start_capture[ch] = false;
			}
		}

		private int init_ahd8_callback()
		{
			is_ahd8_callbackmode = true;
			int num = 4;
			ulong num2 = (ulong)(mJvs_rawWidth * mJvs_rawHeight * 2 + num);
			ahd8_pYuvBuffer = new byte[mJvs_Channels][];
			for (int i = 0; i < mJvs_Channels; i++)
			{
				ahd8_pYuvBuffer[i] = new byte[num2];
			}
			ahd8_pRgb32Buffer = new byte[mJvs_Channels][];
			for (int j = 0; j < mJvs_Channels; j++)
			{
				ahd8_pRgb32Buffer[j] = new byte[mJvs_rawWidth * mJvs_rawHeight * 4];
			}
			if (!is_ahd8_callbackmode)
			{
				return 0;
			}
			is_ahd8_start_capture = new bool[mJvs_Channels];
			for (int k = 0; k < mJvs_Channels; k++)
			{
				is_ahd8_start_capture[k] = false;
			}
			ahd8_callback_fn = ahd8_RawStreamDirectReadCallback;
			DvrshMethod.RegisterRAWDirectCallback(ahd8_callback_fn, mMainHandle);
			return 0;
		}

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "moon_function_init_v2")]
		public static extern int moon_function_init(IntPtr p0, int nLen0, IntPtr p, int nLen, int device, IntPtr slot_xy, IntPtr nozdelta_xy, IntPtr fastcamxy, int oem);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function_init_pointlist_section(IntPtr p, int nLen, int index);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function0(int nozzle_enable_mask, int[] nozzles);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function1(float[] isbrkn, float[] isocpy);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function2(int[] slot_feeder_component_nums_remains);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function2_pointlist_section(int[] slot_feeder_component_nums_remains, int index, int is_single_section);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function_fetch(ref moonSmtFeederInstallElement stacklist, ref int stacklist_len, ref moonChipCatElement slots, ref float brkn, ref float ocpy);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function_fetch2(ref moonChipBoardElement stacklist);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function_fetch2_pointlist_section(ref moonChipBoardElement stacklist, int index);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function_free();

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function_free_pointlist_section();

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern float moon_function_pcbload(CoordinateDouble[] mk, CoordinateDouble[] mk_r, CoordinateDouble[] emt, ref CoordinateDouble emt_r, int count, int oem);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern float moon_function_pcbload2(CoordinateDouble[] mk, CoordinateDouble[] mk_r, CoordinateDouble[] emt, ref CoordinateDouble emt_r, ref CoordinateDouble fake_mk23, ref CoordinateDouble fake_mk23_r, int count, int oem);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_function_config(byte[] db, int len);

		public static bool moon_kk_Init(int fn)
		{
			int cb = Marshal.SizeOf(typeof(moonChipCatElement)) * USR3B[fn].mPointlistCat.Count;
			IntPtr p = Marshal.AllocHGlobal(cb);
			moonChipCatElement[] array = new moonChipCatElement[USR3B[fn].mPointlistCat.Count];
			long num = p.ToInt64();
			for (int i = 0; i < USR3B[fn].mPointlistCat.Count; i++)
			{
				IntPtr ptr = new IntPtr(num);
				array[i] = default(moonChipCatElement);
				array[i].cat_type = i;
				array[i].tag = USR3B[fn].mPointlistCat[i].tag;
				array[i].camera_type = (int)USR3B[fn].mPointlistCat[i].Cameratype;
				array[i].visual_type = (int)USR3B[fn].mPointlistCat[i].Visualtype;
				array[i].loop_type = (int)USR3B[fn].mPointlistCat[i].Looptype;
				array[i].count = USR3B[fn].mPointlistCat[i].Count;
				array[i].delta = USR3B[fn].mPointlistCat[i].Delta;
				array[i].multiFeeders = USR3B[fn].mPointlistCat[i].MultiFeeders;
				array[i].is_lowspeed = (USR3B[fn].mPointlistCat[i].IsLowSpeed ? 1 : 0);
				array[i].lenght = USR3B[fn].mPointlistCat[i].Lenght;
				array[i].width = USR3B[fn].mPointlistCat[i].Width;
				array[i].height = USR3B[fn].mPointlistCat[i].Height;
				array[i].is_collect = (USR3B[fn].mPointlistCat[i].is_collect ? 1 : 0);
				array[i].collectdelta = USR3B[fn].mPointlistCat[i].collectdelta;
				array[i].pik_h_offset = USR3B[fn].mPointlistCat[i].pik_h_offset;
				array[i].mnt_h_offset = USR3B[fn].mPointlistCat[i].mnt_h_offset;
				array[i].zup_speed = USR3B[fn].mPointlistCat[i].zup_speed;
				array[i].zdown_speed = USR3B[fn].mPointlistCat[i].zdown_speed;
				array[i].zpik_delay = USR3B[fn].mPointlistCat[i].zpik_delay;
				array[i].zmnt_up_speed = USR3B[fn].mPointlistCat[i].zmnt_up_speed;
				array[i].zmnt_down_speed = USR3B[fn].mPointlistCat[i].zmnt_down_speed;
				array[i].zmnt_delay = USR3B[fn].mPointlistCat[i].zmnt_delay;
				array[i].scan_r = USR3B[fn].mPointlistCat[i].scan_r;
				array[i].threshold = USR3B[fn].mPointlistCat[i].threshold;
				array[i].is_high = (USR3B[fn].mPointlistCat[i].is_high ? 1 : 0);
				array[i].nozzle0_type = moon_nozzletype(USR3B[fn].mPointlistCat[i].Nozzle_type0);
				array[i].nozzle1_type = (USR3B[fn].mIsEnableBackupNozzle ? moon_nozzletype(USR3B[fn].mPointlistCat[i].Nozzle_type1) : array[i].nozzle0_type);
				array[i].feeder_type = (int)USR3B[fn].mPointlistCat[i].Feedertype;
				if (USR3B[fn].mPointlistCat[i].feeder_no == null)
				{
					int[] array2 = (USR3B[fn].mPointlistCat[i].feeder_no = new int[4]);
				}
				array[i].feeder_no0 = (USR3B[fn].mPointlistCat[i].feeder_no[0] & 0xFF) | ((USR3B[fn].mPointlistCat[i].feeder_no[1] & 0xFF) << 8) | ((USR3B[fn].mPointlistCat[i].feeder_no[2] & 0xFF) << 16) | ((USR3B[fn].mPointlistCat[i].feeder_no[3] & 0xFF) << 24);
				array[i].feeder_no1 = (USR3B[fn].mPointlistCat[i].feeder_no[4] & 0xFF) | ((USR3B[fn].mPointlistCat[i].feeder_no[5] & 0xFF) << 8) | ((USR3B[fn].mPointlistCat[i].feeder_no[6] & 0xFF) << 16) | ((USR3B[fn].mPointlistCat[i].feeder_no[7] & 0xFF) << 24);
				array[i].feeder_no2 = (USR3B[fn].mPointlistCat[i].feeder_no[8] & 0xFF) | ((USR3B[fn].mPointlistCat[i].feeder_no[9] & 0xFF) << 8) | ((USR3B[fn].mPointlistCat[i].feeder_no[10] & 0xFF) << 16) | ((USR3B[fn].mPointlistCat[i].feeder_no[11] & 0xFF) << 24);
				array[i].feeder_no3 = (USR3B[fn].mPointlistCat[i].feeder_no[12] & 0xFF) | ((USR3B[fn].mPointlistCat[i].feeder_no[13] & 0xFF) << 8) | ((USR3B[fn].mPointlistCat[i].feeder_no[14] & 0xFF) << 16) | ((USR3B[fn].mPointlistCat[i].feeder_no[15] & 0xFF) << 24);
				Marshal.StructureToPtr((object)array[i], ptr, fDeleteOld: false);
				num += Marshal.SizeOf(typeof(moonChipCatElement));
			}
			int cb2 = Marshal.SizeOf(typeof(moonCoordinate)) * 80;
			IntPtr slot_xy = Marshal.AllocHGlobal(cb2);
			moonCoordinate[] array3 = new moonCoordinate[80];
			long num2 = slot_xy.ToInt64();
			for (int j = 0; j < 80; j++)
			{
				IntPtr ptr2 = new IntPtr(num2);
				array3[j] = default(moonCoordinate);
				array3[j].x = (int)USR[fn].mSlotAllCoord[j].X;
				array3[j].y = (int)USR[fn].mSlotAllCoord[j].Y;
				Marshal.StructureToPtr((object)array3[j], ptr2, fDeleteOld: false);
				num2 += Marshal.SizeOf(typeof(moonCoordinate));
			}
			int cb3 = Marshal.SizeOf(typeof(moonCoordinate)) * 8;
			IntPtr nozdelta_xy = Marshal.AllocHGlobal(cb3);
			moonCoordinate[] array4 = new moonCoordinate[8];
			long num3 = nozdelta_xy.ToInt64();
			for (int k = 0; k < HW.mZnNum[mFn]; k++)
			{
				IntPtr ptr3 = new IntPtr(num3);
				array4[k] = default(moonCoordinate);
				array4[k].x = (int)USR[fn].mDeltaNozzle[0][k].X;
				array4[k].y = (int)USR[fn].mDeltaNozzle[0][k].Y;
				Marshal.StructureToPtr((object)array4[k], ptr3, fDeleteOld: false);
				num3 += Marshal.SizeOf(typeof(moonCoordinate));
			}
			int cb4 = Marshal.SizeOf(typeof(moonChipBoardElement)) * U3[fn][U3Idx[fn]].mPointlist.Count;
			IntPtr p2 = Marshal.AllocHGlobal(cb4);
			moonChipBoardElement[] array5 = new moonChipBoardElement[U3[fn][U3Idx[fn]].mPointlist.Count];
			long num4 = p2.ToInt64();
			for (int l = 0; l < U3[fn][U3Idx[fn]].mPointlist.Count; l++)
			{
				IntPtr ptr4 = new IntPtr(num4);
				array5[l] = default(moonChipBoardElement);
				array5[l].ismount = (U3[fn][U3Idx[fn]].mPointlist[l].Ismount ? 1 : 0);
				array5[l].group = U3[fn][U3Idx[fn]].mPointlist[l].Group;
				array5[l].camera_type = (int)U3[fn][U3Idx[fn]].mPointlist[l].Cameratype;
				array5[l].visual_type = (int)U3[fn][U3Idx[fn]].mPointlist[l].Visualtype;
				array5[l].loop_type = (int)U3[fn][U3Idx[fn]].mPointlist[l].Looptype;
				array5[l].arrayno = U3[fn][U3Idx[fn]].mPointlist[l].Arrayno;
				array5[l].is_aix = (U3[fn][U3Idx[fn]].mPointlist[l].isAix ? 1 : 0);
				array5[l].x = (int)U3[fn][U3Idx[fn]].mPointlist[l].X;
				array5[l].y = (int)U3[fn][U3Idx[fn]].mPointlist[l].Y;
				array5[l].is_lowspeed = (U3[fn][U3Idx[fn]].mPointlist[l].IsLowSpeed ? 1 : 0);
				array5[l].import_no = U3[fn][U3Idx[fn]].mPointlist[l].ImportNo;
				array5[l].a = U3[fn][U3Idx[fn]].mPointlist[l].A;
				array5[l].stack_type = (int)U3[fn][U3Idx[fn]].mPointlist[l].Stacktype;
				array5[l].stack_no = U3[fn][U3Idx[fn]].mPointlist[l].Stack_no;
				array5[l].nozzle_no = U3[fn][U3Idx[fn]].mPointlist[l].Nozzle;
				array5[l].samePikNo = -1;
				array5[l].isOptimization = 0;
				array5[l].labeltab = l;
				array5[l].cat_type = moon_CatType(fn, U3[fn][U3Idx[fn]].mPointlist[l].Material_value, U3[fn][U3Idx[fn]].mPointlist[l].Footprint);
				array5[l].sampik_delta = U3[fn][U3Idx[fn]].mPointlist[l].sampik_delta;
				array5[l].feeder_type = (int)U3[fn][U3Idx[fn]].mPointlist[l].Feedertype;
				array5[l].nozzle_type = U3[fn][U3Idx[fn]].mPointlist[l].Nozzletype;
				array5[l].scan_r = U3[fn][U3Idx[fn]].mPointlist[l].scanR;
				array5[l].threshold = U3[fn][U3Idx[fn]].mPointlist[l].threshold;
				array5[l].length = U3[fn][U3Idx[fn]].mPointlist[l].length;
				array5[l].width = U3[fn][U3Idx[fn]].mPointlist[l].width;
				array5[l].height = U3[fn][U3Idx[fn]].mPointlist[l].height;
				array5[l].is_collect = (U3[fn][U3Idx[fn]].mPointlist[l].is_collect ? 1 : 0);
				array5[l].collectdelta = U3[fn][U3Idx[fn]].mPointlist[l].collectdelta;
				array5[l].pik_h_offset = U3[fn][U3Idx[fn]].mPointlist[l].pik_h_offset;
				array5[l].mnt_h_offset = U3[fn][U3Idx[fn]].mPointlist[l].mnt_h_offset;
				array5[l].zup_speed = U3[fn][U3Idx[fn]].mPointlist[l].zup_speed;
				array5[l].zdown_speed = U3[fn][U3Idx[fn]].mPointlist[l].zdown_speed;
				array5[l].zpik_delay = U3[fn][U3Idx[fn]].mPointlist[l].zpik_delay;
				array5[l].zmnt_up_speed = U3[fn][U3Idx[fn]].mPointlist[l].zmnt_up_speed;
				array5[l].zmnt_down_speed = U3[fn][U3Idx[fn]].mPointlist[l].zmnt_down_speed;
				array5[l].zmnt_delay = U3[fn][U3Idx[fn]].mPointlist[l].zmnt_delay;
				array5[l].is_high = (U3[fn][U3Idx[fn]].mPointlist[l].is_high ? 1 : 0);
				Marshal.StructureToPtr((object)array5[l], ptr4, fDeleteOld: false);
				num4 += Marshal.SizeOf(typeof(moonChipBoardElement));
			}
			int cb5 = Marshal.SizeOf(typeof(moonCoordinate)) * 2;
			IntPtr fastcamxy = Marshal.AllocHGlobal(cb5);
			moonCoordinate[] array6 = new moonCoordinate[2];
			long num5 = fastcamxy.ToInt64();
			for (int m = 0; m < HW.mTnNum; m++)
			{
				IntPtr ptr5 = new IntPtr(num5);
				array6[m] = default(moonCoordinate);
				array6[m].x = (int)USR[fn].mFastCamRecognizeCoord[m].X;
				array6[m].y = (int)USR[fn].mFastCamRecognizeCoord[m].Y;
				Marshal.StructureToPtr((object)array6[m], ptr5, fDeleteOld: false);
				num5 += Marshal.SizeOf(typeof(moonCoordinate));
			}
			int num6 = moon_function_init(p2, U3[fn][U3Idx[fn]].mPointlist.Count, p, USR3B[fn].mPointlistCat.Count, (int)HW.mDeviceType, slot_xy, nozdelta_xy, fastcamxy, 1);
			if (num6 != 1)
			{
				moon_function_free();
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Stack Number conflict!" : "料站号指定发生冲突，请重新调整！");
			}
			else
			{
				moon_function_config(new byte[12]
				{
					(byte)HW.malgo2[fn].ant[0],
					(byte)HW.malgo2[fn].ant[1],
					(byte)HW.malgo2[fn].emp_l[0],
					(byte)HW.malgo2[fn].emp_l[1],
					(byte)HW.malgo2[fn].slt_l[0],
					(byte)HW.malgo2[fn].slt_l[1],
					(byte)HW.malgo2[fn].emp_m[0],
					(byte)HW.malgo2[fn].emp_m[1],
					(byte)HW.malgo2[fn].slt_r[0],
					(byte)HW.malgo2[fn].slt_r[1],
					(byte)HW.malgo2[fn].emp_r[0],
					(byte)HW.malgo2[fn].emp_r[1]
				}, 12);
			}
			for (int n = 0; n < U3[fn].Count; n++)
			{
				USR3_DATA uSR3_DATA = U3[fn][n];
				if (uSR3_DATA.mPointlist != null)
				{
					int cb6 = Marshal.SizeOf(typeof(moonChipBoardElement)) * uSR3_DATA.mPointlist.Count;
					IntPtr p3 = Marshal.AllocHGlobal(cb6);
					moonChipBoardElement[] array7 = new moonChipBoardElement[uSR3_DATA.mPointlist.Count];
					long num7 = p3.ToInt64();
					for (int num8 = 0; num8 < uSR3_DATA.mPointlist.Count; num8++)
					{
						IntPtr ptr6 = new IntPtr(num7);
						array7[num8] = default(moonChipBoardElement);
						array7[num8].ismount = (uSR3_DATA.mPointlist[num8].Ismount ? 1 : 0);
						array7[num8].group = uSR3_DATA.mPointlist[num8].Group;
						array7[num8].camera_type = (int)uSR3_DATA.mPointlist[num8].Cameratype;
						array7[num8].visual_type = (int)uSR3_DATA.mPointlist[num8].Visualtype;
						array7[num8].loop_type = (int)uSR3_DATA.mPointlist[num8].Looptype;
						array7[num8].arrayno = uSR3_DATA.mPointlist[num8].Arrayno;
						array7[num8].is_aix = (uSR3_DATA.mPointlist[num8].isAix ? 1 : 0);
						array7[num8].x = (int)uSR3_DATA.mPointlist[num8].X;
						array7[num8].y = (int)uSR3_DATA.mPointlist[num8].Y;
						array7[num8].is_lowspeed = (uSR3_DATA.mPointlist[num8].IsLowSpeed ? 1 : 0);
						array7[num8].import_no = uSR3_DATA.mPointlist[num8].ImportNo;
						array7[num8].a = uSR3_DATA.mPointlist[num8].A;
						array7[num8].stack_type = (int)uSR3_DATA.mPointlist[num8].Stacktype;
						array7[num8].stack_no = uSR3_DATA.mPointlist[num8].Stack_no;
						array7[num8].nozzle_no = uSR3_DATA.mPointlist[num8].Nozzle;
						array7[num8].samePikNo = -1;
						array7[num8].isOptimization = 0;
						array7[num8].labeltab = num8;
						array7[num8].cat_type = moon_CatType(fn, uSR3_DATA.mPointlist[num8].Material_value, uSR3_DATA.mPointlist[num8].Footprint);
						array7[num8].sampik_delta = uSR3_DATA.mPointlist[num8].sampik_delta;
						array7[num8].feeder_type = (int)uSR3_DATA.mPointlist[num8].Feedertype;
						array7[num8].nozzle_type = uSR3_DATA.mPointlist[num8].Nozzletype;
						array7[num8].scan_r = uSR3_DATA.mPointlist[num8].scanR;
						array7[num8].threshold = uSR3_DATA.mPointlist[num8].threshold;
						array7[num8].length = uSR3_DATA.mPointlist[num8].length;
						array7[num8].width = uSR3_DATA.mPointlist[num8].width;
						array7[num8].height = uSR3_DATA.mPointlist[num8].height;
						array7[num8].is_collect = (uSR3_DATA.mPointlist[num8].is_collect ? 1 : 0);
						array7[num8].collectdelta = uSR3_DATA.mPointlist[num8].collectdelta;
						array7[num8].pik_h_offset = uSR3_DATA.mPointlist[num8].pik_h_offset;
						array7[num8].mnt_h_offset = uSR3_DATA.mPointlist[num8].mnt_h_offset;
						array7[num8].zup_speed = uSR3_DATA.mPointlist[num8].zup_speed;
						array7[num8].zdown_speed = uSR3_DATA.mPointlist[num8].zdown_speed;
						array7[num8].zpik_delay = uSR3_DATA.mPointlist[num8].zpik_delay;
						array7[num8].zmnt_up_speed = uSR3_DATA.mPointlist[num8].zmnt_up_speed;
						array7[num8].zmnt_down_speed = uSR3_DATA.mPointlist[num8].zmnt_down_speed;
						array7[num8].zmnt_delay = uSR3_DATA.mPointlist[num8].zmnt_delay;
						array7[num8].is_high = (uSR3_DATA.mPointlist[num8].is_high ? 1 : 0);
						Marshal.StructureToPtr((object)array7[num8], ptr6, fDeleteOld: false);
						num7 += Marshal.SizeOf(typeof(moonChipBoardElement));
					}
					num6 = moon_function_init_pointlist_section(p3, uSR3_DATA.mPointlist.Count, n);
					if (num6 != 1)
					{
						moon_function_free_pointlist_section();
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Stack Number conflict!" : "料站号指定发生冲突，请重新调整！");
					}
				}
			}
			if (num6 != 1)
			{
				return false;
			}
			return true;
		}

		public static void moon_kk_Optimization(int fn)
		{
			int num = 0;
			for (int i = 0; i < HW.mZnNum[fn]; i++)
			{
				num |= (USR3B[fn].mNozzleEnable[i] & 1) << i;
			}
			int[] array = new int[HW.mZnNum[fn]];
			int num2 = moon_function0(num, array);
			if (num2 == -1)
			{
				CmMessageBoxTop_Ok("数据里的吸嘴种类已经超出设备吸嘴总数量，请重新调整!");
				return;
			}
			for (int j = 0; j < HW.mZnNum[fn]; j++)
			{
				USR3B[fn].mNozzles[j] = moon_nozzletype(array[j]);
			}
			update_NozzleInstallTable(fn, USR3B[fn].mNozzles);
			float[] array2 = new float[200];
			float[] array3 = new float[200];
			for (int k = 0; k < 2; k++)
			{
				for (int l = 0; l < HW.malgo2[fn].len[k]; l++)
				{
					if (l < HW.malgo2[fn].emp_l[k] || (l >= HW.malgo2[fn].emp_l[k] + HW.malgo2[fn].slt_l[k] && l < HW.malgo2[fn].emp_l[k] + HW.malgo2[fn].slt_l[k] + HW.malgo2[fn].emp_m[k]) || l >= HW.malgo2[fn].len[k] - HW.malgo2[fn].emp_r[k])
					{
						uc_job[fn].isSlotBrkn[k][l] = 1f;
					}
					array2[k * 100 + l] = USR3B[fn].isSlotBrkn[k][l];
					array3[k * 100 + l] = USR3B[fn].isSlotOcpy[k][l];
				}
			}
			num2 = moon_function1(array2, array3);
			int[][] array4 = new int[U3[fn].Count][];
			for (int m = 0; m < U3[fn].Count; m++)
			{
				array4[m] = new int[200];
				for (int n = 0; n < 200; n++)
				{
					array4[m][n] = 0;
				}
				num2 = moon_function2_pointlist_section(array4[m], m, (m == 0 && U3[fn].Count == 1) ? 1 : 0);
			}
			moonSmtFeederInstallElement[] array5 = new moonSmtFeederInstallElement[HW.mStackNum[fn][0] + HW.mStackNum[fn][1] + HW.mStackNum[fn][2]];
			for (int num3 = 0; num3 < HW.mStackNum[fn][0] + HW.mStackNum[fn][1] + HW.mStackNum[fn][2]; num3++)
			{
				array5[num3] = default(moonSmtFeederInstallElement);
			}
			moonChipCatElement[] array6 = new moonChipCatElement[200];
			for (int num4 = 0; num4 < 200; num4++)
			{
				array6[num4] = default(moonChipCatElement);
			}
			float[] array7 = new float[200];
			float[] array8 = new float[200];
			int stacklist_len = 0;
			num2 = moon_function_fetch(ref array5[0], ref stacklist_len, ref array6[0], ref array7[0], ref array8[0]);
			USR3B[fn].mFeederInstallList.Clear();
			if (USR3B[fn].mPlateInstallList == null)
			{
				USR3B[fn].mPlateInstallList = new BindingList<SmtFeederInstallElement>();
			}
			USR3B[fn].mPlateInstallList.Clear();
			if (USR3B[fn].mVibraInstallList == null)
			{
				USR3B[fn].mVibraInstallList = new BindingList<SmtFeederInstallElement>();
			}
			USR3B[fn].mVibraInstallList.Clear();
			for (int num5 = 0; num5 < stacklist_len; num5++)
			{
				SmtFeederInstallElement smtFeederInstallElement = new SmtFeederInstallElement(USR_INIT.mLanguage);
				smtFeederInstallElement.Count = array5[num5].count;
				smtFeederInstallElement.Stacktype = (ProviderType)array5[num5].stack_type;
				smtFeederInstallElement.Stack_no = array5[num5].stack_no;
				smtFeederInstallElement.Feedertype = (FeederType)array5[num5].feeder_type;
				smtFeederInstallElement.Height = array5[num5].height;
				smtFeederInstallElement.Material_value = USR3B[fn].mPointlistCat[array5[num5].cat_type].Material_value;
				smtFeederInstallElement.Footprint = USR3B[fn].mPointlistCat[array5[num5].cat_type].Footprint;
				USR3B[fn].mFeederInstallList.Add(smtFeederInstallElement);
				if (smtFeederInstallElement.Stacktype == ProviderType.Vibra)
				{
					USR3B[fn].mVibraInstallList.Add(smtFeederInstallElement);
				}
				if (smtFeederInstallElement.Stacktype == ProviderType.Plate)
				{
					USR3B[fn].mPlateInstallList.Add(smtFeederInstallElement);
				}
			}
			update_usr2_stacks_used_show(fn);
			BindingList<SmtFeederInstallElement> bindingList = new BindingList<SmtFeederInstallElement>();
			for (int num6 = 0; num6 < USR3B[fn].mFeederInstallList.Count; num6++)
			{
				bindingList.Add(USR3B[fn].mFeederInstallList[num6]);
			}
			for (int num7 = 0; num7 < USR3B[fn].mPointlistCat.Count; num7++)
			{
				for (int num8 = 0; num8 < USR3B[fn].mPointlistCat[num7].MultiFeeders; num8++)
				{
					FeederType feedertype = USR3B[fn].mPointlistCat[num7].Feedertype;
					string material_value = USR3B[fn].mPointlistCat[num7].Material_value;
					string footprint = USR3B[fn].mPointlistCat[num7].Footprint;
					bool flag = false;
					for (int num9 = 0; num9 < bindingList.Count; num9++)
					{
						if (feedertype == bindingList[num9].Feedertype && material_value == bindingList[num9].Material_value && footprint == bindingList[num9].Footprint)
						{
							flag = true;
							USR3B[fn].mPointlistCat[num7].feeder_no[num8] = bindingList[num9].Stack_no;
							bindingList.Remove(bindingList[num9]);
							break;
						}
					}
					if (!flag)
					{
						break;
					}
				}
			}
			for (int num10 = 0; num10 < 2; num10++)
			{
				for (int num11 = 0; num11 < HW.malgo2[fn].len[num10]; num11++)
				{
					if (array6[num10 * 100 + num11].count > 0)
					{
						ChipCategoryElement chipCategoryElement = new ChipCategoryElement(USR_INIT.mLanguage);
						chipCategoryElement.Cameratype = (CameraType)array6[num10 * 100 + num11].camera_type;
						chipCategoryElement.Count = array6[num10 * 100 + num11].count;
						chipCategoryElement.Delta = array6[num10 * 100 + num11].delta;
						chipCategoryElement.MultiFeeders = array6[num10 * 100 + num11].multiFeeders;
						for (int num12 = 0; num12 < chipCategoryElement.MultiFeeders; num12++)
						{
							if (num12 < 4)
							{
								chipCategoryElement.feeder_no[num12] = (array6[num10 * 100 + num11].feeder_no0 >> num12 * 8) & 0xFF;
							}
							else if (num12 < 8)
							{
								chipCategoryElement.feeder_no[num12] = (array6[num10 * 100 + num11].feeder_no1 >> (num12 - 4) * 8) & 0xFF;
							}
							else if (num12 < 12)
							{
								chipCategoryElement.feeder_no[num12] = (array6[num10 * 100 + num11].feeder_no2 >> (num12 - 8) * 8) & 0xFF;
							}
							else if (num12 < 16)
							{
								chipCategoryElement.feeder_no[num12] = (array6[num10 * 100 + num11].feeder_no3 >> (num12 - 12) * 8) & 0xFF;
							}
						}
						chipCategoryElement.Feedertype = (FeederType)array6[num10 * 100 + num11].feeder_type;
						chipCategoryElement.Footprint = USR3B[fn].mPointlistCat[array6[num10 * 100 + num11].cat_type].Footprint;
						chipCategoryElement.Material_value = USR3B[fn].mPointlistCat[array6[num10 * 100 + num11].cat_type].Material_value;
						chipCategoryElement.MultiFeeders = USR3B[fn].mPointlistCat[array6[num10 * 100 + num11].cat_type].MultiFeeders;
						chipCategoryElement.Lenght = array6[num10 * 100 + num11].lenght;
						chipCategoryElement.Width = array6[num10 * 100 + num11].width;
						chipCategoryElement.Height = array6[num10 * 100 + num11].height;
						chipCategoryElement.is_collect = ((array6[num10 * 100 + num11].is_collect != 0) ? true : false);
						chipCategoryElement.collectdelta = array6[num10 * 100 + num11].collectdelta;
						chipCategoryElement.pik_h_offset = array6[num10 * 100 + num11].pik_h_offset;
						chipCategoryElement.mnt_h_offset = array6[num10 * 100 + num11].mnt_h_offset;
						chipCategoryElement.zup_speed = array6[num10 * 100 + num11].zup_speed;
						chipCategoryElement.zdown_speed = array6[num10 * 100 + num11].zdown_speed;
						chipCategoryElement.zpik_delay = array6[num10 * 100 + num11].zpik_delay;
						chipCategoryElement.zmnt_up_speed = array6[num10 * 100 + num11].zmnt_up_speed;
						chipCategoryElement.zmnt_down_speed = array6[num10 * 100 + num11].zmnt_down_speed;
						chipCategoryElement.zmnt_delay = array6[num10 * 100 + num11].zmnt_delay;
						chipCategoryElement.scan_r = array6[num10 * 100 + num11].scan_r;
						chipCategoryElement.threshold = array6[num10 * 100 + num11].threshold;
						chipCategoryElement.is_high = ((array6[num10 * 100 + num11].is_high != 0) ? true : false);
						chipCategoryElement.IsLowSpeed = ((array6[num10 * 100 + num11].is_lowspeed != 0) ? true : false);
						chipCategoryElement.Nozzletype0 = array6[num10 * 100 + num11].nozzle0_type;
						chipCategoryElement.Nozzletype1 = array6[num10 * 100 + num11].nozzle1_type;
						chipCategoryElement.tag = array6[num10 * 100 + num11].tag;
						chipCategoryElement.Visualtype = (VisualType)array6[num10 * 100 + num11].visual_type;
						chipCategoryElement.Looptype = (LoopType)array6[num10 * 100 + num11].loop_type;
						USR3B[fn].slot_feeder_component[num10][num11] = chipCategoryElement;
					}
					else
					{
						USR3B[fn].slot_feeder_component[num10][num11] = null;
					}
					USR3B[fn].isSlotBrkn[num10][num11] = array7[num10 * 100 + num11];
					USR3B[fn].isSlotOcpy[num10][num11] = array8[num10 * 100 + num11];
				}
			}
			int num13 = 0;
			for (int num14 = 0; num14 < U3[fn].Count; num14++)
			{
				for (int num15 = 0; num15 < 2; num15++)
				{
					for (int num16 = 0; num16 < HW.malgo2[fn].len[num15]; num16++)
					{
						if (array4[num14][num15 * 100 + num16] != 0)
						{
							num13++;
						}
					}
				}
			}
			int num17 = 0;
			for (int num18 = 0; num18 < USR3B[fn].mPointlistCat.Count; num18++)
			{
				USR3B[fn].mPointlistCat[num18].mOptimizeResult = OptimizeResult.None;
				for (int num19 = 0; num19 < USR3B[fn].mPointlistCat[num18].MultiFeeders; num19++)
				{
					if (num17 < num13 && common_get_providertype(USR3B[fn].mPointlistCat[num18].Feedertype) == ProviderType.Feedr)
					{
						for (int num20 = 0; num20 < 2; num20++)
						{
							for (int num21 = 0; num21 < HW.malgo2[fn].len[num20]; num21++)
							{
								for (int num22 = 0; num22 < U3[fn].Count; num22++)
								{
									if (array4[num22][num20 * 100 + num21] != 0)
									{
										int num23 = format_stackno(fn, num20, num21) + 1;
										if (USR3B[fn].mPointlistCat[num18].feeder_no[num19] == num23)
										{
											USR3B[fn].mPointlistCat[num18].mOptimizeResult = OptimizeResult.Fail;
											num17++;
											break;
										}
									}
								}
							}
						}
					}
					if (USR3B[fn].mPointlistCat[num18].mOptimizeResult == OptimizeResult.Fail)
					{
						break;
					}
					if (USR3B[fn].mPointlistCat[num18].feeder_no[num19] != USR3B[fn].mPointlistCat_History[num18].feeder_no[num19])
					{
						USR3B[fn].mPointlistCat[num18].mOptimizeResult = OptimizeResult.OK_Diff;
						break;
					}
					USR3B[fn].mPointlistCat[num18].mOptimizeResult = OptimizeResult.OK_Keep;
				}
			}
			for (int num24 = 0; num24 < U3[fn].Count; num24++)
			{
				_ = U3[fn][num24];
				USR3_DATA uSR3_DATA = U3[fn][num24];
				uSR3_DATA.mPointlistSmt.Clear();
				if (uSR3_DATA.mPointlist == null || uSR3_DATA.mPointlist.Count <= 0)
				{
					continue;
				}
				moonChipBoardElement[] array9 = new moonChipBoardElement[uSR3_DATA.mPointlist.Count];
				for (int num25 = 0; num25 < uSR3_DATA.mPointlist.Count; num25++)
				{
					array9[num25] = default(moonChipBoardElement);
				}
				num2 = moon_function_fetch2_pointlist_section(ref array9[0], num24);
				for (int num26 = 0; num26 < uSR3_DATA.mPointlist.Count; num26++)
				{
					ChipBoardElement chipBoardElement = new ChipBoardElement(USR_INIT.mLanguage, uSR3_DATA.mPointlist[array9[num26].labeltab].Guid);
					chipBoardElement.A = array9[num26].a;
					chipBoardElement.Arrayno = array9[num26].arrayno;
					chipBoardElement.isAix = ((array9[num26].is_aix != 0) ? true : false);
					chipBoardElement.Arrayno_S = (chipBoardElement.isAix ? "*" : "") + (array9[num26].arrayno / uSR3_DATA.mArrayPCBColumn + 1) + "-" + (array9[num26].arrayno % uSR3_DATA.mArrayPCBColumn + 1);
					chipBoardElement.Cameratype = (CameraType)array9[num26].camera_type;
					chipBoardElement.Visualtype = (VisualType)array9[num26].visual_type;
					chipBoardElement.Looptype = (LoopType)array9[num26].loop_type;
					chipBoardElement.Footprint = USR3B[fn].mPointlistCat[array9[num26].cat_type].Footprint;
					chipBoardElement.Material_value = USR3B[fn].mPointlistCat[array9[num26].cat_type].Material_value;
					chipBoardElement.Labeltab = uSR3_DATA.mPointlist[array9[num26].labeltab].Labeltab;
					chipBoardElement.Group = array9[num26].group;
					chipBoardElement.IsLowSpeed = ((array9[num26].is_lowspeed != 0) ? true : false);
					chipBoardElement.ImportNo = array9[num26].import_no;
					chipBoardElement.Ismount = ((array9[num26].ismount != 0) ? true : false);
					chipBoardElement.isOptimization = ((array9[num26].isOptimization != 0) ? true : false);
					chipBoardElement.Nozzle = array9[num26].nozzle_no;
					chipBoardElement.pointIndex = array9[num26].labeltab;
					chipBoardElement.samePikNo = array9[num26].samePikNo;
					chipBoardElement.Stack_no = array9[num26].stack_no;
					chipBoardElement.Stacktype = (ProviderType)array9[num26].stack_type;
					chipBoardElement.Guid = uSR3_DATA.mPointlist[array9[num26].labeltab].Guid;
					chipBoardElement.X = array9[num26].x;
					chipBoardElement.Y = array9[num26].y;
					chipBoardElement.Feedertype = (FeederType)array9[num26].feeder_type;
					chipBoardElement.Nozzletype = array9[num26].nozzle_type;
					chipBoardElement.scanR = array9[num26].scan_r;
					chipBoardElement.threshold = array9[num26].threshold;
					chipBoardElement.length = array9[num26].length;
					chipBoardElement.width = array9[num26].width;
					chipBoardElement.height = array9[num26].height;
					chipBoardElement.is_collect = ((array9[num26].is_collect != 0) ? true : false);
					chipBoardElement.collectdelta = array9[num26].collectdelta;
					chipBoardElement.pik_h_offset = array9[num26].pik_h_offset;
					chipBoardElement.mnt_h_offset = array9[num26].mnt_h_offset;
					chipBoardElement.zup_speed = array9[num26].zup_speed;
					chipBoardElement.zdown_speed = array9[num26].zdown_speed;
					chipBoardElement.zpik_delay = array9[num26].zpik_delay;
					chipBoardElement.zmnt_up_speed = array9[num26].zmnt_up_speed;
					chipBoardElement.zmnt_down_speed = array9[num26].zmnt_down_speed;
					chipBoardElement.zmnt_delay = array9[num26].zmnt_delay;
					chipBoardElement.sampik_delta = array9[num26].sampik_delta;
					chipBoardElement.is_high = ((array9[num26].is_high != 0) ? true : false);
					uSR3_DATA.mPointlistSmt.Add(chipBoardElement);
				}
				uSR3_DATA.mPointlist.Clear();
				for (int num27 = 0; num27 < uSR3_DATA.mPointlistSmt.Count; num27++)
				{
					for (int num28 = 0; num28 < uSR3_DATA.mPointlistSmt.Count; num28++)
					{
						if (num27 == array9[num28].labeltab)
						{
							uSR3_DATA.mPointlist.Add(uSR3_DATA.mPointlistSmt[num28]);
							break;
						}
					}
				}
				uSR3_DATA.mIsGenSmt = true;
				pcbsmt_update_Groups(uSR3_DATA);
			}
			num2 = moon_function_free();
			num2 = moon_function_free_pointlist_section();
			update_NozzleFeederInstallTable_Post(fn);
			update_usr2_stacks_used_nozzles(fn);
		}

		public static int moon_CatType(int fn, string value, string footprint)
		{
			int result = -1;
			for (int i = 0; i < USR3B[fn].mPointlistCat.Count; i++)
			{
				if (value == USR3B[fn].mPointlistCat[i].Material_value && footprint == USR3B[fn].mPointlistCat[i].Footprint)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		public static int moon_nozzletype(string type)
		{
			for (int i = 0; i < moonNozzles.Count(); i++)
			{
				if (type == moonNozzles[i])
				{
					return i;
				}
				if (type == "已禁用")
				{
					return -2;
				}
			}
			return -1;
		}

		public static string moon_nozzletype(int type)
		{
			if (type >= 0 && type < moonNozzles.Count())
			{
				return moonNozzles[type];
			}
			if (type == -2)
			{
				return "已禁用";
			}
			return "";
		}

		public void vsplus_usr_history_before_2021_9()
		{
			if (USR[0].mHistory < 8)
			{
				USR_INIT.mIsOpenShapeStopRun = USR[0].mIsOpenShapeStopRun;
				USR_INIT.mIsNotFeederGoodbye = USR[0].mIsNotFeederGoodbye;
				USR_INIT.mIsBCTEnabled = USR[0].mIsBCTEnabled;
				USR_INIT.mTrackSpeedBase = USR[0].mTrackSpeedBase;
				USR_INIT.mWarningAlarmMode = USR[0].mWarningAlarmMode;
				USR_INIT.misfcam_def_channel = USR[0].misfcam_def_channel;
				USR_INIT.mark_def_channel = USR[0].mark_def_channel;
				if (USR_INIT.fcam_def_channel == null)
				{
					USR_INIT.fcam_def_channel = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				}
				if (USR[0].fcam_def_channel == null)
				{
					USR[0].fcam_def_channel = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				}
				for (int i = 0; i < USR[0].fcam_def_channel.Count(); i++)
				{
					USR_INIT.fcam_def_channel[i] = USR[0].fcam_def_channel[i];
				}
			}
		}

		public void vsplus_usr_history_before_2020_7()
		{
			if (USR[0].mHistory < 7 && mJvsDriver == JvsDriver.MV360)
			{
				for (int i = 0; i < HW.mFnNum; i++)
				{
					int num = USR[i].mfcam_para.Count();
					for (int j = 0; j < num; j++)
					{
						if (USR[i].mfcam_para[j][0] < 64)
						{
							USR[i].mfcam_para[j][0] += 128;
						}
						else if (USR[i].mfcam_para[j][0] > 148)
						{
							USR[i].mfcam_para[j][0] -= 128;
						}
					}
					for (int k = 0; k < USR[i].mMarkCamPara.Count(); k++)
					{
						if (USR[i].mMarkCamPara[k].mParaCam[0] < 64)
						{
							USR[i].mMarkCamPara[k].mParaCam[0] += 128;
						}
						else if (USR[i].mMarkCamPara[k].mParaCam[0] > 148)
						{
							USR[i].mMarkCamPara[k].mParaCam[0] -= 128;
						}
					}
				}
			}
			for (int l = 0; l < HW.mFnNum; l++)
			{
				if (USR[l].mBaseHeight_saferun_limit == null)
				{
					USR[l].mBaseHeight_saferun_limit = new int[8] { 420, 420, 420, 420, 420, 420, 420, 420 };
				}
			}
		}

		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibrary(string path);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetProcAddress(IntPtr lib, string funcName);

		[DllImport("kernel32.dll")]
		private static extern bool FreeLibrary(IntPtr lib);

		public void init_visualbirds_lib()
		{
			BindingList<string> bindingList = new BindingList<string>();
			string[] files = Directory.GetFiles(".\\");
			string[] array = files;
			foreach (string text in array)
			{
				if (text.Contains("moon_birds") && text.Contains(".dll") && !text.Contains(".manifest"))
				{
					bindingList.Add(text);
				}
			}
			if (bindingList.Count == 0)
			{
				return;
			}
			vmLib = new VisLib[bindingList.Count];
			for (int j = 0; j < bindingList.Count; j++)
			{
				vmLib[j] = default(VisLib);
				vmLib[j].vDll = LoadLibrary(bindingList[j]);
				if (!(vmLib[j].vDll != (IntPtr)0))
				{
					continue;
				}
				vmLib[j].nmoon_birds_get_count = (int_Func_void)Invoke(vmLib[j].vDll, "nmoon_birds_get_count", typeof(int_Func_void));
				vmLib[j].nmoon_birds_get_visual = (int_Func_int)Invoke(vmLib[j].vDll, "nmoon_birds_get_visual", typeof(int_Func_int));
				vmLib[j].nmoon_birds_get_namestring = (int_Func_int_int_ptr)Invoke(vmLib[j].vDll, "nmoon_birds_get_namestring", typeof(int_Func_int_int_ptr));
				vmLib[j].nmoon_birds_get_pic = (int_Func_int_ptr)Invoke(vmLib[j].vDll, "nmoon_birds_get_pic", typeof(int_Func_int_ptr));
				vmLib[j].nmoon_birds_visualrun = (int_Func_ptr_int_vin_vout)Invoke(vmLib[j].vDll, "nmoon_birds_visualrun", typeof(int_Func_ptr_int_vin_vout));
				vmLib[j].vCount = vmLib[j].nmoon_birds_get_count();
				vmLib[j].vTab = new VisItem[vmLib[j].vCount];
				try
				{
					for (int k = 0; k < vmLib[j].vCount; k++)
					{
						vmLib[j].vTab[k] = default(VisItem);
						vmLib[j].vTab[k].vistype = (VisualType)vmLib[j].nmoon_birds_get_visual(k);
						IntPtr intPtr = mallocIntptr(32);
						vmLib[j].nmoon_birds_get_namestring(k, USR_INIT.mLanguage, intPtr);
						vmLib[j].vTab[k].name = Marshal.PtrToStringAnsi(intPtr);
						Marshal.FreeHGlobal(intPtr);
						vmLib[j].vTab[k].pic = new Bitmap(128, 128, PixelFormat.Format24bppRgb);
						BitmapData bitmapData = vmLib[j].vTab[k].pic.LockBits(new Rectangle(0, 0, 128, 128), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
						vmLib[j].nmoon_birds_get_pic(k, bitmapData.Scan0);
						vmLib[j].vTab[k].pic.UnlockBits(bitmapData);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		public void uninit_visualbirds_lib()
		{
			if (vmLib == null)
			{
				return;
			}
			for (int i = 0; i < vmLib.Count(); i++)
			{
				if (vmLib[i].vDll != (IntPtr)0)
				{
					FreeLibrary(vmLib[i].vDll);
					vmLib[i].vDll = (IntPtr)0;
				}
			}
		}

		public static int get_vmtab_viscounts()
		{
			int num = 0;
			if (vmLib != null)
			{
				for (int i = 0; i < vmLib.Count(); i++)
				{
					num += vmLib[i].vCount;
				}
			}
			return num;
		}

		public static int_2d get_vmtab_visindex(VisualType vis)
		{
			int_2d int_2d = new int_2d(-1, -1);
			if (vmLib != null)
			{
				for (int i = 0; i < vmLib.Count(); i++)
				{
					if (vmLib[i].vTab == null)
					{
						continue;
					}
					for (int j = 0; j < vmLib[i].vTab.Count(); j++)
					{
						if (vmLib[i].vTab[j].vistype == vis)
						{
							int_2d.a = i;
							int_2d.b = j;
							return int_2d;
						}
					}
				}
			}
			return int_2d;
		}

		public static PixFormat get_vmtab_pixformat(PixelFormat f)
		{
			return f switch
			{
				PixelFormat.Format24bppRgb => PixFormat.RGB24, 
				PixelFormat.Format32bppRgb => PixFormat.RGB32, 
				_ => PixFormat.YUYV, 
			};
		}

		public Delegate Invoke(IntPtr handle, string APIName, Type t)
		{
			IntPtr procAddress = GetProcAddress(handle, APIName);
			return Marshal.GetDelegateForFunctionPointer(procAddress, t);
		}

		private static IntPtr mallocIntptr(string strData)
		{
			byte[] bytes = Encoding.Default.GetBytes(strData);
			IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length);
			byte[] array = new byte[bytes.Length + 1];
			Marshal.Copy(array, 0, intPtr, array.Length);
			Marshal.Copy(bytes, 0, intPtr, bytes.Length);
			return intPtr;
		}

		private static IntPtr mallocIntptr(int length)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(length);
			byte[] array = new byte[length + 1];
			Marshal.Copy(array, 0, intPtr, array.Length);
			Marshal.Copy(array, 0, intPtr, length);
			return intPtr;
		}

		public MainForm0()
		{
			InitializeComponent();
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			static_this = this;
			static_label_smtdevicetype = label_smtdevicetype;
			static_tabControl_dsq = tabControl_dsq;
			base.Size = new Size(1280, 1024);
			base.Location = new Point(0, 0);
		}

		private unsafe void FormMain_Load(object sender, EventArgs e)
		{
			mMainHandle = base.Handle;
			mMutexBt = false;
			mMutexLog = false;
			mMutexBtDown = false;
			mMutexMoveXYZA = false;
			mIsBoardFixed = false;
			mIsOpenShape_Enabled = false;
			static_firmware_version = new string[8];
			mIsSecurityTest = true;
			label_platform.Text = (Environment.Is64BitProcess ? "64" : "32");
			tabControl_temp.Location = new Point(1285, 10);
			base.Icon = GetIcon(1);
			RemoveMenu(GetSystemMenu(base.Handle, IntPtr.Zero), 1, 5120);
			create_logFile();
			write_to_logFile(mLogFileName, "20210712_8.8.0_T46_R" + Environment.NewLine);
			init_configdata_folder_part0();
			load_FixedData_ConfigInit();
			init_Hardware();
			init_footprintlib();
			write_to_logFile("[LOAD FORM] user init");
			mCurCam = new CameraType[HW.mFnNum];
			USR = new USR_DATA[HW.mFnNum];
			USR2 = new USR2_DATA[HW.mFnNum];
			USR3B = new USR3_BASE[HW.mFnNum];
			U3 = new BindingList<USR3_DATA>[HW.mFnNum];
			U3Idx = new int[HW.mFnNum];
			U3Idx_Prev = new int[HW.mFnNum];
			__mUSR3 = new USR3_DATA[HW.mFnNum][];
			mRectHandle = new IntPtr[HW.mFnNum];
			uc_VisualShowSmt = new UserControl_VisualShow[HW.mFnNum];
			PicBox_Preview = new PictureBox[HW.mFnNum];
			PicBox_Preview2 = new PictureBox[HW.mFnNum];
			pictureBox_visualrunning = new PictureBox[HW.mFnNum];
			panel_preview = new Panel[HW.mFnNum];
			button_stop_runningvisual = new CnButton[HW.mFnNum];
			pictureBox_VisualTest = new PictureBox[HW.mFnNum];
			mBitmapVisualTest = new Bitmap[HW.mFnNum];
			mBitmapVisualRunning = new Bitmap[HW.mFnNum];
			slotcatitems_from_otherfile_lists = new BindingList<slot_item_for_catfromotherfile>[HW.mFnNum];
			newBitmaps_des = new Bitmap[HW.mFnNum][];
			mIsAutoSelect_PcbCheck_NearestMarkChip = new bool[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				USR2[i] = null;
				USR3B[i] = null;
				U3[i] = null;
				U3Idx[i] = 0;
				U3Idx_Prev[i] = -1;
				__mUSR3[i] = null;
				mCurCam[i] = CameraType.Mark;
				ref IntPtr reference = ref mRectHandle[i];
				reference = (IntPtr)(void*)null;
				PicBox_Preview[i] = null;
				PicBox_Preview2[i] = null;
				pictureBox_visualrunning[i] = null;
				panel_preview[i] = null;
				button_stop_runningvisual[i] = null;
				pictureBox_VisualTest[i] = null;
				mBitmapVisualTest[i] = null;
				mBitmapVisualRunning[i] = null;
				slotcatitems_from_otherfile_lists[i] = null;
				newBitmaps_des[i] = new Bitmap[HW.mZnNum[mFn]];
				mIsAutoSelect_PcbCheck_NearestMarkChip[i] = false;
			}
			if (HW.mDeviceType == DeviceType.HW_8S_TRAN4 || HW.mDeviceType == DeviceType.HW_6S_TRAN4)
			{
				USR_INIT.mInBoard_Mode = 2;
			}
			else if (HW.mDeviceType == DeviceType.HW_8SP_1200 || HW.mDeviceType == DeviceType.HW_8SX_1200)
			{
				USR_INIT.mInBoard_Mode = 1;
			}
			else if (USR_INIT.mInBoard_Mode == 1)
			{
				HW.mSections = 2;
			}
			init_TnZn();
			init_MoveButton();
			init_common_var();
			init_feedergoodbye();
			init_misc();
			init_visual_light();
			write_to_logFile("[LOAD FORM] init var");
			init_Language();
			write_to_logFile("[LOAD FORM] init lan");
			load_FixedData();
			init_fixed_onlyonce();
			write_to_logFile("[LOAD FORM] init user fixed");
			get_cameradrivertype();
			init_camera_driver_only_once();
			write_to_logFile("[LOAD FORM] init cam");
			initConnectionPre();
			write_to_logFile("[LOAD FORM] init connect ");
			vsplus_init_deviceui();
			write_to_logFile("[LOAD FORM] init all page");
			for (int j = 0; j < HW.mFnNum; j++)
			{
				UI_ControlEnable(j, flag: false, UI_ENABLE.USR);
			}
			static_label_notice_register = new Label();
			static_label_notice_register.Visible = false;
			static_label_notice_register.Size = new Size(550, 40);
			static_label_notice_register.Location = new Point(0, 10);
			static_label_notice_register.BackColor = Color.Blue;
			static_label_notice_register.ForeColor = Color.Red;
			static_label_notice_register.Font = new Font("黑体", 18.5f, FontStyle.Bold);
			static_label_notice_register.TextAlign = ContentAlignment.MiddleCenter;
			PicBox_Preview[0].Controls.Add(static_label_notice_register);
			if (moon_is_dudu_debug() == 1)
			{
				CmMessageBoxTop_Ok("当前为调试模式");
			}
			write_to_logFile("[LOAD FORM] after check debug");
			getDeviceSerialCode();
			write_to_logFile("[LOAD FORM] after get up code");
			moon_wind_update_reference_time();
			__wind_checkget_software_state(0);
			mSmtMiles = moon_wind_get_current_miles();
			if (mSmtMiles < 0)
			{
				mSmtMiles = 840000;
				moon_wind_update_current_miles(mSmtMiles);
			}
			write_to_logFile("[LOAD FORM] done");
			init_visualbirds_lib();
		}

		public void init_usr2_related()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				flush_visual_light(i);
			}
		}

		private void FormMain_Closing(object sender, FormClosingEventArgs e)
		{
			if (!mIsSwitchDevice)
			{
				save_FixedData();
				save_usrProjectData();
			}
			release_camera();
			if (mIsSecurityTest)
			{
				moon_wind_update_reference_time();
			}
		}

		public void enable_LoadComponentFile()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				panel_newProjects[i].Visible = false;
				panel_mainPictures[i].Visible = false;
			}
		}

		public void enable_MainProject()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				panel_newProjects[i].Visible = true;
				panel_mainPictures[i].Visible = false;
			}
		}

		public void enable_MainProject_OpenPrj()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				panel_newProjects[i].Visible = true;
				panel_mainPictures[i].Visible = false;
			}
		}

		public void enable_MainPictrue()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				panel_newProjects[i].Visible = false;
				panel_mainPictures[i].Visible = true;
			}
		}

		private void fixpage_enable(bool en)
		{
		}

		private void btn_FixedSetting_Click(object sender, EventArgs e)
		{
			mMutexBt = false;
			mMutexBtDown = false;
			mMutexMoveXYZA = false;
			if (is_engineer_password_correct())
			{
				Form_System form_System = new Form_System(USR_INIT, USR[mFn]);
				DialogResult dialogResult = form_System.ShowDialog();
				if (dialogResult == DialogResult.Retry)
				{
					button_Library_Click(sender, e);
				}
				uc_usroperarion[mFn].set_inboard_mode();
			}
		}

		[DllImport("User32.dll")]
		private static extern IntPtr SendMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam);

		private void tb_FixedSetting_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.P == e.KeyCode && e.Shift && e.Control)
			{
				_ = e.Alt;
			}
		}

		public void ControlEnable(Control ctl, bool flag)
		{
			ctl.Invoke((MethodInvoker)delegate
			{
				ctl.Enabled = flag;
			});
		}

		public void addEvent_for_tabControl_main(bool flag)
		{
			if (!addEvent_for_tabControl_main_flag && flag)
			{
				addEvent_for_tabControl_main_flag = true;
			}
			else if (addEvent_for_tabControl_main_flag && !flag)
			{
				addEvent_for_tabControl_main_flag = false;
			}
		}

		public void UI_ControlEnable(int mfn, bool flag, UI_ENABLE mode)
		{
			if (mCurCam[mFn] == CameraType.Mark)
			{
				JK_PrvMove = flag;
			}
			else
			{
				JK_PrvMove = true;
			}
			switch (mode)
			{
			case UI_ENABLE.OPT:
				return;
			case UI_ENABLE.USR:
				panel_mainAreas[mfn].Enabled = flag;
				btn_OpenCreateProject.Enabled = flag;
				break;
			case UI_ENABLE.SMT:
			{
				btn_FixedSetting.Enabled = flag;
				CnButton cnButton = cnButton_exit;
				bool enabled = (btn_Connect.Enabled = flag);
				cnButton.Enabled = enabled;
				break;
			}
			}
			button_ProjectClose.Enabled = flag;
			uc_usroperarion[mfn].Enabled = flag;
			button_DeviceCalibraion.Enabled = flag;
			uc_job[mfn].set_enable(flag);
		}

		public void UI_Enable_USR(int mfn, bool flag)
		{
			Invoke((MethodInvoker)delegate
			{
				UI_ControlEnable(mfn, flag, UI_ENABLE.USR);
			});
		}

		public void UI_Enable_SMT(int mfn, bool flag)
		{
			Invoke((MethodInvoker)delegate
			{
				UI_ControlEnable(mfn, flag, UI_ENABLE.SMT);
			});
		}

		public void UI_Enable_OPT(int mfn, bool flag)
		{
			Invoke((MethodInvoker)delegate
			{
				UI_ControlEnable(mfn, flag, UI_ENABLE.OPT);
			});
		}

		private void tabControl_main_Selecting(object sender, TabControlCancelEventArgs e)
		{
			e.Cancel = true;
		}

		private void button_SaveFile_Click(object sender, EventArgs e)
		{
			write_to_logFile_hand("HAND: button_SaveFile_Click" + Environment.NewLine);
			save_file();
		}

		private void save_file()
		{
			save_FixedData();
			save_usrProjectData();
		}

		public static void CopyValue(object origin, object target)
		{
			PropertyInfo[] properties = target.GetType().GetProperties();
			FieldInfo[] fields = origin.GetType().GetFields();
			for (int i = 0; i < fields.Length; i++)
			{
				for (int j = 0; j < properties.Length; j++)
				{
					if (fields[i].Name == properties[j].Name && properties[j].CanWrite)
					{
						properties[j].SetValue(target, fields[i].GetValue(origin), null);
					}
				}
			}
		}

		private void button_test000_Click(object sender, EventArgs e)
		{
			mConDev[0].sendSwitchAlarmLamp(alarm / 3, alarm % 3);
			alarm++;
			if (alarm == 6)
			{
				alarm = 0;
			}
		}

		public void MessageBoxShow_OK(string msg)
		{
			Invoke(new MessageBoxShow(MessageBoxShow_F), msg);
		}

		public static void MessageBoxShow_F(string msg)
		{
			MessageBox.Show(msg, STR.NOTICE_INFO[USR_INIT.mLanguage], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void button_QA_main_Click(object sender, EventArgs e)
		{
			Form_QA_main form_QA_main = new Form_QA_main(USR_INIT.mLanguage);
			form_QA_main.ShowDialog();
		}

		private void UI_ControlEnable_FactoryTest(bool flag)
		{
			btn_Connect.Enabled = flag;
			button_ProjectClose.Enabled = flag;
		}

		private void tabControl_mainwork_SelectedIndexChanged(object sender, EventArgs e)
		{
			TabControl tabControl = (TabControl)sender;
			if (tabControl.SelectedIndex == 0 && !is_engineer_password_correct())
			{
				tabControl.SelectedIndex = 1;
			}
		}

		private void button_debug_mark_Click(object sender, EventArgs e)
		{
			Form_DebugMark form_DebugMark = new Form_DebugMark();
			form_DebugMark.ShowDialog();
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 258:
				MessageBox.Show("WM_CHAR");
				break;
			case 45:
				MessageBox.Show("WM_DELETEITEM");
				break;
			case 274:
				m.WParam.ToInt32();
				_ = 61472;
				break;
			}
			base.WndProc(ref m);
		}

		private void button_factory_marktest_Click(object sender, EventArgs e)
		{
			Form_MarkTest form_MarkTest = new Form_MarkTest();
			form_MarkTest.ShowDialog();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				uc_job[i].set_simulation();
			}
		}

		private void button_feederlib_Click(object sender, EventArgs e)
		{
			Form_FeederPara form_FeederPara = new Form_FeederPara(USR[mFn]);
			form_FeederPara.ShowDialog();
		}

		private void button_DeviceCalibraion_Click(object sender, EventArgs e)
		{
			write_to_logFile_hand("HAND: button_DeviceCalibraion_Click" + Environment.NewLine);
			uc_devicecalibration[mFn].BringToFront();
			uc_devicecalibration[mFn].Visible = true;
			uc_devicecalibration[mFn].Show();
		}

		private void button_fastcam_fabtest_Click(object sender, EventArgs e)
		{
		}

		private void button_minize_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void btn_Connect_Click(object sender, EventArgs e)
		{
			__btn_Connect_Click(sender, e);
		}

		private void btn_Project_Click(object sender, EventArgs e)
		{
			__btn_Project_Click(sender, e);
		}

		private void button_ProjectClose_Click(object sender, EventArgs e)
		{
			__button_ProjectClose_Click(sender, e);
		}

		private void cnButton_exit_Click(object sender, EventArgs e)
		{
			if (CmMessageBox((USR_INIT.mLanguage == 2) ? "Are you going to close software?" : "是否关闭软件？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (USR3_INIT != null)
				{
					__button_ProjectClose_Click(sender, e);
				}
				if (!mIsSwitchDevice)
				{
					save_FixedData();
					save_usrProjectData();
				}
				release_camera();
				moon_wind_update_reference_time();
				Environment.Exit(0);
			}
		}

		private void tabControl_dsq_SelectedIndexChanged(object sender, EventArgs e)
		{
			__tabControl_dsq_SelectedIndexChanged(sender, e);
		}

		private void cnButton_AHD8Test_Click(object sender, EventArgs e)
		{
			Form_AHD8Test form_AHD8Test = new Form_AHD8Test();
			form_AHD8Test.ShowDialog();
		}

		private void button_Legal_Click(object sender, EventArgs e)
		{
			write_to_logFile_hand("HAND: button_Legal_Click" + Environment.NewLine);
			pcbsmt_legalcheck(mFn, must_show: true);
		}

		public static int pcbsmt_legalcheck(int fn, bool must_show)
		{
			int num = 0;
			string text = "";
			if (U3[fn] == null || U3[fn].Count <= 0)
			{
				string text2 = "[ERROR] PCB: None PCB Project! ";
				string text3 = "[错误] 贴装工程: 没有可以贴装的PCB工程！";
				text = text + ((USR_INIT.mLanguage == 2) ? text2 : text3) + Environment.NewLine;
				num++;
			}
			if (U3Idx[fn] < 0 || U3Idx[fn] >= U3[fn].Count)
			{
				string text4 = "[ERROR] PCB: Error PCB index! ";
				string text5 = "[错误] 贴装工程: PCB工程索引超出范围！";
				text = text + ((USR_INIT.mLanguage == 2) ? text4 : text5) + Environment.NewLine;
				num++;
			}
			for (int i = 0; i < HW.mStackNum[fn][1]; i++)
			{
				StackElement[] array = USR2[fn].mStackLib.stacktab[1];
				if (!array[i].mSelected)
				{
					continue;
				}
				if (array[i].mPlt.mXYlist == null || array[i].mPlt.mXYlist.Count <= 0 || array[i].mPlt.mStartIndex < 0 || array[i].mPlt.mStartIndex > array[i].mPlt.mXYlist.Count)
				{
					_ = USR_INIT.mLanguage;
					string text6 = i + 1 + "号料盘，数据非法，请正确设置！";
					string text7 = i + 1 + " setting invalid, please modify!";
					text += ((USR_INIT.mLanguage == 2) ? text7 : (text6 + Environment.NewLine));
					num++;
				}
				if (!USR2[fn].mIsHOffsetMode || HW.mSmtGenerationNo == 0)
				{
					continue;
				}
				for (int j = 0; j < HW.mZnNum[fn]; j++)
				{
					if (array[i].mZnData[j].mEnabled)
					{
						if (array[i].mZnData[j].baseH == 0)
						{
							string text8 = ((USR_INIT.mLanguage == 2) ? "[ERROR] PLATE " : "[错误] 料盘");
							string text9 = text8 + (i + 1) + "号料盘，最高基准点未设置，请正确设置！";
							string text10 = text8 + (i + 1) + " Highest Base-H is not set, please modify!";
							text += ((USR_INIT.mLanguage == 2) ? text10 : (text9 + Environment.NewLine));
							num++;
						}
						else if (array[i].mZnData[j].baseH < USR[fn].mBaseHeight_saferun[j] + 20)
						{
							string text11 = ((USR_INIT.mLanguage == 2) ? "[ERROR] PLATE " : "[错误] 危险的托盘高度 ");
							string text12 = text11 + (i + 1) + "号料盘，最高基准点与安全高度间距至少应为2mm，请正确设置！";
							string text13 = text11 + (i + 1) + " Highest Base-H is too similar as safe running based-H, please modify!";
							text += ((USR_INIT.mLanguage == 2) ? text13 : (text12 + Environment.NewLine));
							num++;
						}
					}
				}
			}
			for (int k = 0; k < USR3B[fn].mPointlistCat.Count; k++)
			{
				if (USR3B[fn].mPointlistCat[k].Feedertype == FeederType.Plate)
				{
					for (int l = 0; l < USR3B[fn].mPointlistCat[k].MultiFeeders; l++)
					{
						int num2 = USR3B[fn].mPointlistCat[k].feeder_no[l] - 1;
						if (num2 < 0 || num2 > HW.mStackNum[fn][1])
						{
							_ = USR_INIT.mLanguage;
							string text14 = num2 + 1 + "号错误，请正确设置！";
							string text15 = num2 + 1 + " setting invalid, please modify!";
							text += ((USR_INIT.mLanguage == 2) ? text15 : (text14 + Environment.NewLine));
							num++;
						}
						else if (USR2[fn].mStackLib.stacktab[1][num2].mPlt.mXYlist == null || USR2[fn].mStackLib.stacktab[1][num2].mPlt.mXYlist.Count <= 0 || USR2[fn].mStackLib.stacktab[1][num2].mPlt.mStartIndex < 0 || USR2[fn].mStackLib.stacktab[1][num2].mPlt.mStartIndex > USR2[fn].mStackLib.stacktab[1][num2].mPlt.mXYlist.Count)
						{
							string text16 = ((USR_INIT.mLanguage == 2) ? "[ERROR] PLATE " : "[错误] 料盘");
							string text17 = text16 + (num2 + 1) + "号料盘，取料坐标数据非法，请正确设置！";
							string text18 = text16 + (num2 + 1) + " setting invalid, please modify!";
							text += ((USR_INIT.mLanguage == 2) ? text18 : (text17 + Environment.NewLine));
							num++;
						}
					}
				}
				if (USR3B[fn].mPointlistCat[k].Visualtype == VisualType.FootPrint_R)
				{
					string footprint = USR3B[fn].mPointlistCat[k].Footprint;
					PinConfig pinConfig = common_footprint_get_pinconfig(footprint);
					if (pinConfig.pin_mode == 0 || pinConfig.pin_mode == 1 || pinConfig.pin_length == 0f || pinConfig.pin_width == 0f)
					{
						string text19 = ((USR_INIT.mLanguage == 2) ? "[ERROR] FootPrint Visual " : "[错误] 封装匹配视觉算法");
						string text20 = text19 + footprint + " 封装匹配算法失败，因为在封装库里没有相应数据";
						string text21 = text19 + footprint + " cannot be found int footprint lab";
						text += ((USR_INIT.mLanguage == 2) ? text21 : (text20 + Environment.NewLine));
						num++;
					}
				}
			}
			for (int m = 0; m < U3[fn].Count; m++)
			{
				if (USR3B[fn].mPrjMode == 0)
				{
					m = U3Idx[fn];
				}
				USR3_DATA uSR3_DATA = U3[fn][m];
				string text22 = uSR3_DATA.mPcbID + " ";
				if (USR3B[fn].mPrjMode == 0)
				{
					text22 = "";
				}
				if (!USR3B[fn].mIsDisableMark && (uSR3_DATA.mMarkPic[0] == null || uSR3_DATA.mMarkPic[1] == null))
				{
					string text23 = text22 + "[ERROR] MARK: Invalid MARK setting, please set MARK in PCB EDIT page! ";
					string text24 = text22 + "[错误] MARK点: 非法的MARK点设置，请回到PCB编辑里重新设置MARK点！";
					text = text + ((USR_INIT.mLanguage == 2) ? text23 : text24) + Environment.NewLine;
					num++;
				}
				if (uSR3_DATA.mPointlistSmt != null && uSR3_DATA.mPointlistSmt.Count > 0)
				{
					BindingList<BindingList<ChipBoardElement>> bindingList = new BindingList<BindingList<ChipBoardElement>>();
					int num3 = 0;
					int num4 = -1;
					int num5 = -1;
					for (num3 = 0; num3 < uSR3_DATA.mPointlistSmt.Count; num3++)
					{
						if (uSR3_DATA.mPointlistSmt[num3].Group != num5)
						{
							num4++;
							num5 = uSR3_DATA.mPointlistSmt[num3].Group;
							BindingList<ChipBoardElement> item = new BindingList<ChipBoardElement>();
							bindingList.Add(item);
						}
						bindingList[num4].Add(uSR3_DATA.mPointlistSmt[num3]);
					}
					for (num4 = 0; num4 < bindingList.Count; num4++)
					{
						BindingList<ChipBoardElement> bindingList2 = bindingList[num4];
						for (num3 = 0; num3 < bindingList2.Count; num3++)
						{
							string text25 = text22 + ((USR_INIT.mLanguage == 2) ? "[ERROR] GROUP " : "[错误] 轮组") + bindingList2[num3].Group + " ";
							string text26 = text25;
							text25 = text26 + ((USR_INIT.mLanguage == 2) ? "Chip " : "元件 ") + bindingList2[num3].Material_value + ((USR_INIT.mLanguage == 2) ? "Footprint " : " 封装 ") + bindingList2[num3].Footprint + ":";
							if (bindingList2[num3].Cameratype_S == "" || bindingList2[num3].Visualtype_S == "")
							{
								text = text + text25 + ((USR_INIT.mLanguage == 2) ? "Please fill the blank camera/visual items " : "请完善相机/视觉类型") + Environment.NewLine;
								num++;
							}
							if (bindingList2[num3].Stacktype != 0 && bindingList2[num3].Stacktype != ProviderType.Plate && bindingList2[num3].Stacktype != ProviderType.Vibra)
							{
								string text27 = "Please complete provider type: feeder/plate/vibra feeder";
								string text28 = "请完善供料类型：料站/料盘/振动飞达";
								text = text + text25 + ((USR_INIT.mLanguage == 2) ? text27 : text28) + Environment.NewLine;
								num++;
							}
							if (bindingList2[num3].Arrayno < 0 || bindingList2[num3].Arrayno >= uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn)
							{
								string text29 = "Please modify invalid array no";
								string text30 = "拼板号超出有效范围，请检查工程数据";
								text = text + text25 + ((USR_INIT.mLanguage == 2) ? text29 : text30) + Environment.NewLine;
								num++;
							}
							if (num3 >= 1)
							{
								if (bindingList2[num3].Cameratype == CameraType.High && bindingList2[num3].Looptype == LoopType.CloseLoop)
								{
									string text31 = "Groups of chips that using pecise visual cannot be combine!";
									string text32 = "精准视觉的元件不允许合并轮组";
									text = text + text25 + ((USR_INIT.mLanguage == 2) ? text31 : text32) + Environment.NewLine;
									num++;
								}
								if (bindingList2[num3].IsLowSpeed)
								{
									string text33 = "Groups of chips that using los speed mode cannot be combine!";
									string text34 = "降速搬运的元件不允许合并轮组";
									text = text + text25 + ((USR_INIT.mLanguage == 2) ? text33 : text34) + Environment.NewLine;
									num++;
								}
							}
							ProviderType stacktype = bindingList2[num3].Stacktype;
							int num6 = bindingList2[num3].Stack_no - 1;
							int num7 = bindingList2[num3].Nozzle - 1;
							if (num6 < 0 || num6 >= HW.mStackNum[fn][(int)stacktype])
							{
								string text35 = "Please modify invalid feeder no: feeder no must be between 1 and " + HW.mStackNum.ToString();
								string text36 = "请修改不合法的料站号：该料站/盘/振动号必须在 1-" + HW.mStackNum[(int)stacktype].ToString() + "之间";
								text = text + text25 + ((USR_INIT.mLanguage == 2) ? text35 : text36) + Environment.NewLine;
								num++;
								continue;
							}
							if (num7 < 0 || num7 >= HW.mZnNum[mFn])
							{
								string text37 = "Please modify invalid nozzle no. Nozzle no must be between 1 and " + HW.mZnNum[mFn];
								string text38 = "请修改不合法的吸嘴号：吸嘴号必须在1-" + HW.mZnNum[mFn] + "之间";
								text = text + text25 + ((USR_INIT.mLanguage == 2) ? text37 : text38) + Environment.NewLine;
								num++;
								continue;
							}
							StackElement[] array2 = USR2[fn].mStackLib.stacktab[(int)stacktype];
							switch (stacktype)
							{
							case ProviderType.Feedr:
							case ProviderType.Vibra:
							{
								int num10 = (int)(array2[num6].mXY.X - USR[fn].mDeltaNozzle[0][num7].X);
								int num11 = (int)(array2[num6].mXY.Y - USR[fn].mDeltaNozzle[0][num7].Y);
								if (num10 < 0 || num10 >= HW.mMaxX[0] || num11 < 0 || num11 >= HW.mMaxY[0])
								{
									string text43 = "Please modify invalid pick XY, (" + num10 + "," + num11 + ")";
									string text44 = "请修改不合法的取料坐标：取料坐标超行程, (" + num10 + "," + num11 + ")";
									text = text + text25 + ((USR_INIT.mLanguage == 2) ? text43 : text44) + Environment.NewLine;
									num++;
								}
								break;
							}
							case ProviderType.Plate:
							{
								if (array2[num6].mPlt.mXYlist == null)
								{
									break;
								}
								for (int n = 0; n < array2[num6].mPlt.mXYlist.Count; n++)
								{
									int num8 = (int)(array2[num6].mPlt.mXYlist[n].X - USR[fn].mDeltaNozzle[0][num7].X);
									int num9 = (int)(array2[num6].mPlt.mXYlist[n].Y - USR[fn].mDeltaNozzle[0][num7].Y);
									if (num8 < 0 || num8 >= HW.mMaxX[0] || num9 < 0 || num9 >= HW.mMaxY[0])
									{
										string text41 = "Please modify invalid pick XY, (" + num8 + "," + num9 + ")";
										string text42 = "请修改不合法的取料坐标：取料坐标超行程, (" + num8 + "," + num9 + ")";
										text = text + text25 + ((USR_INIT.mLanguage == 2) ? text41 : text42) + Environment.NewLine;
										num++;
										break;
									}
								}
								break;
							}
							default:
							{
								string text39 = "Please complete provider type: feeder/plate/vibra feeder";
								string text40 = "请完善供料类型：料站/料盘/振动飞达";
								text = text + text25 + ((USR_INIT.mLanguage == 2) ? text39 : text40) + Environment.NewLine;
								num++;
								break;
							}
							}
							int num12 = (int)(bindingList2[num3].X - USR[fn].mDeltaNozzle[0][num7].X);
							int num13 = (int)(bindingList2[num3].Y - USR[fn].mDeltaNozzle[0][num7].Y);
							if (num12 < 0 || num12 >= HW.mMaxX[fn] || num13 < 0 || num13 >= HW.mMaxY[fn])
							{
								string text45 = "Please modify invalid mnt XY, Nozzle " + (num7 + 1) + " can not arrive the coordinate (" + num12 + "," + num12 + ")";
								string text46 = "请修改不合法的贴装坐标：" + (num7 + 1) + "号吸嘴无法运行到坐标 (" + num13 + "," + num13 + ")";
								text = text + text25 + ((USR_INIT.mLanguage == 2) ? text45 : text46) + Environment.NewLine;
								num++;
							}
						}
						CameraType cameratype = bindingList2[0].Cameratype;
						_ = bindingList2[0].Visualtype;
						_ = bindingList2[0].Looptype;
						ProviderType stacktype2 = bindingList2[0].Stacktype;
						_ = bindingList2[0].Stack_no;
						_ = bindingList2[0].Material_value;
						_ = bindingList2[0].Footprint;
						for (num3 = 1; num3 < bindingList2.Count; num3++)
						{
							string text47 = text22 + ((USR_INIT.mLanguage == 2) ? "[ERROR] GROUP " : "[错误] 轮组") + bindingList2[num3].Group + " ";
							if (bindingList2[num3].Cameratype != cameratype)
							{
								string text48 = "Groups need to be combined must have same camera and visual type!";
								string text49 = "请修正不合法的相机类型：所有参与合并的元件相机必须相同";
								text = text + text47 + ((USR_INIT.mLanguage == 2) ? text48 : text49) + Environment.NewLine;
								num++;
							}
							if (bindingList2[num3].Stacktype != stacktype2)
							{
								string text50 = "Groups need to be combined must have same provider type!";
								string text51 = "请修正不合法的供料类型：所有参与合并的元件供料类型必须相同（料站/料盘/振动飞达）";
								text = text + text47 + ((USR_INIT.mLanguage == 2) ? text50 : text51) + Environment.NewLine;
								num++;
							}
						}
						if (stacktype2 == ProviderType.Vibra)
						{
							for (num3 = 0; num3 < bindingList2.Count; num3++)
							{
								string text52 = text22 + ((USR_INIT.mLanguage == 2) ? "[ERROR] GROUP " : "[错误] 轮组") + bindingList2[num3].Group + " ";
								for (int num14 = 0; num14 < bindingList2.Count; num14++)
								{
									if (num3 != num14 && bindingList2[num3].Stack_no == bindingList2[num14].Stack_no)
									{
										string text53 = "Vibra feeder cannot be in the same groups!";
										string text54 = "请修正不合法的振动飞达号：振动飞达相同的料站号不可以在相同的轮组";
										text = text + text52 + ((USR_INIT.mLanguage == 2) ? text53 : text54) + Environment.NewLine;
										num++;
									}
								}
							}
						}
						for (num3 = 0; num3 < bindingList2.Count; num3++)
						{
							string text55 = text22 + ((USR_INIT.mLanguage == 2) ? "[ERROR] GROUP " : "[错误] 轮组") + bindingList2[num3].Group + " ";
							for (int num15 = 0; num15 < bindingList2.Count; num15++)
							{
								if (num3 != num15 && bindingList2[num3].Nozzle == bindingList2[num15].Nozzle)
								{
									string text56 = "Same group cannot have the same nozzle no!";
									string text57 = "请修正不合法的吸嘴号：同一个轮组中不可以相同的吸嘴号";
									text = text + text55 + ((USR_INIT.mLanguage == 2) ? text56 : text57) + Environment.NewLine;
									num++;
								}
							}
						}
						if (HW.mSmtGenerationNo == 0)
						{
							continue;
						}
						for (num3 = 0; num3 < bindingList2.Count; num3++)
						{
							string text58 = text22 + ((USR_INIT.mLanguage == 2) ? "[ERROR] GROUP " : "[错误] 轮组") + bindingList2[num3].Group + " ";
							for (int num16 = 0; num16 < bindingList2.Count; num16++)
							{
								ProviderType stacktype3 = bindingList2[num16].Stacktype;
								int num17 = bindingList2[num16].Stack_no - 1;
								string[] array3 = new string[3] { "料站", "料盘", "振动飞达" };
								StackElement[] array4;
								if (stacktype3 == ProviderType.Feedr)
								{
									array4 = USR2[fn].mStackLib.stacktab[0];
								}
								else if (stacktype3 == ProviderType.Vibra)
								{
									array4 = USR2[fn].mStackLib.stacktab[2];
								}
								else
								{
									if (stacktype3 != ProviderType.Plate)
									{
										continue;
									}
									array4 = USR2[fn].mStackLib.stacktab[1];
								}
								if (num17 > HW.mStackNum[fn][(int)stacktype3] || num17 < 0)
								{
									string text59 = "Stack no is out of range!";
									string text60 = "请修正不合法的料站号：料站/盘号超出范围";
									text = text + text58 + ((USR_INIT.mLanguage == 2) ? text59 : text60) + Environment.NewLine;
									num++;
									continue;
								}
								if (array4[num17].height <= 0f)
								{
									string text61 = "Invalid Chip Thick Height!";
									string text62 = "请修正不合法的元件厚度：请在" + array3[(int)stacktype3] + (num17 + 1) + "参数里修正不合法的元件厚度";
									text = text + text58 + ((USR_INIT.mLanguage == 2) ? text61 : text62) + Environment.NewLine;
									num++;
								}
								bool flag = false;
								if (stacktype3 == ProviderType.Feedr)
								{
									flag = ((num17 < HW.malgo2[fn].slt_l[0] + HW.malgo2[fn].slt_r[0]) ? true : false);
								}
								bool flag2 = false;
								for (int num18 = 0; num18 < HW.mZnNum[fn]; num18++)
								{
									if (!array4[num17].mZnData[num18].mEnabled)
									{
										continue;
									}
									int num19 = array4[num17].mZnData[num18].Pik.Height;
									if (USR2[fn].mIsHOffsetMode)
									{
										if (array4[num17].mZnData[num18].baseH == 0)
										{
											continue;
										}
										float num20 = format_H_to_Hmm(Math.Abs(flag ? USR[fn].mBaseHeight_feeder[num3] : USR[fn].mBaseHeight_feederBk[num3]));
										if (stacktype3 == ProviderType.Vibra || stacktype3 == ProviderType.Plate)
										{
											num20 = format_H_to_Hmm(Math.Abs(array4[num17].mZnData[num18].baseH));
										}
										float hmm = num20 + array4[num17].mZnData[num18].Pik.Offset;
										int num21 = format_Hmm_to_H(hmm) * ((num18 % 2 != 0) ? 1 : (-1));
										if (HW.mSmtGenerationNo == 2)
										{
											num21 = Math.Abs(num21);
										}
										num19 = num21;
									}
									if (num19 != 0 && USR[fn].mBaseHeight_saferun[num18] >= num19 - 12)
									{
										flag2 = true;
									}
								}
								if (flag2)
								{
									string text63 = "Dangerous Safe Height: Conflict with Safe Height!";
									string text64 = "危险的托盘高度：" + array3[(int)stacktype3] + (num17 + 1) + "的高度与安全高度发生危险冲突风险！";
									text = text + text58 + ((USR_INIT.mLanguage == 2) ? text63 : text64) + Environment.NewLine;
									num++;
								}
							}
						}
					}
				}
				if (USR3B[fn].mPrjMode == 0)
				{
					break;
				}
			}
			if (num == 0)
			{
				string text26 = text;
				text = text26 + Environment.NewLine + ((USR_INIT.mLanguage == 2) ? "   Total " : "   共计 ") + num + ((USR_INIT.mLanguage == 2) ? "   errors! " : "个错误！") + Environment.NewLine;
			}
			else
			{
				string text26 = text;
				text = text26 + Environment.NewLine + ((USR_INIT.mLanguage == 2) ? "   Total " : "   共计 ") + num + ((USR_INIT.mLanguage == 2) ? "   errors! Please correct them! " : " 个错误, 请修正！ ") + Environment.NewLine;
			}
			mLegal_Msg[0] = text;
			if ((must_show || (!must_show && num > 0)) && !USR3B[fn].mIsJieBoTaiMode)
			{
				Form_Legal form_Legal = new Form_Legal(USR_INIT.mLanguage, U3[fn][U3Idx[fn]].mPointlistSmt, mLegal_Msg);
				form_Legal.ShowDialog();
			}
			return num;
		}

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void moon_wind_update_current_miles(int smtcounts);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_wind_get_current_miles();

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "moon_wind_update_current_reftime")]
		public static extern void moon_wind_update_reference_time();

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_wind_checkget_software_state(ref byte ktime, ref byte is_h);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_wind_set_key(string key, int size);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_wind_get_key(ref byte key);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_set_wind_devcode(string code, ref byte out_code, int size);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_get_wind_devcode(ref byte out_code);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_is_dudu_debug();

		public static Icon GetIcon(int oem)
		{
			return ICON_PICTURE[oem];
		}

		[DllImport("user32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);

		[DllImport("user32.dll")]
		private static extern int RemoveMenu(IntPtr hMenu, int nPos, int flags);

		[DllImport("moon_jvs.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "JVS_InitSDK")]
		public static extern int myJVS_InitSDK();

		private void __tabControl_dsq_SelectedIndexChanged(object sender, EventArgs e)
		{
			mFn = tabControl_dsq.SelectedIndex;
			write_to_logFile("Fn = " + (mFn + 1));
			if (mCurCam[mFn] == CameraType.Mark)
			{
				openMarkCam(mFn);
			}
			else if (mCurCam[mFn] == CameraType.Fast)
			{
				openFastCam(mFn, mZn[mFn]);
			}
			else if (mCurCam[mFn] == CameraType.High)
			{
				openHighCam(mFn);
			}
		}

		public void set_tabControl_dsq(int fn)
		{
			tabControl_dsq.SelectedIndex = fn;
		}

		public Color system_color(int[] color)
		{
			int[] array = new int[3];
			int[] array2 = array;
			return Color.FromArgb((color[0] + array2[0]) % 256, (color[1] + array2[1]) % 256, (color[2] + array2[2]) % 256);
		}

		private void trackBar_color_valueChanged(object sender, EventArgs e)
		{
			if (USR != null && USR[mFn].mColor != null)
			{
				TrackBar trackBar = (TrackBar)sender;
				int num = (int)trackBar.Tag;
				USR[mFn].mColor[num] = trackBar.Value;
				Color color = system_color(USR[mFn].mColor);
				panel_color.BackColor = color;
				panel_nozzle1.BackColor = color;
				if (uc_usroperarion != null && uc_usroperarion[mFn] != null)
				{
					uc_usroperarion[mFn].set_color(color);
				}
			}
		}

		private void init_fixed_basic()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR[i].mColor == null)
				{
					USR[i].mColor = new int[3] { 100, 157, 180 };
				}
				if ((USR[i].mColor[0] < 10 && USR[i].mColor[1] < 10 && USR[i].mColor[2] < 10) || USR[i].mColor[0] + USR[i].mColor[1] + USR[i].mColor[2] < 30)
				{
					USR[i].mColor[0] = 100;
					USR[i].mColor[1] = 157;
					USR[i].mColor[2] = 180;
				}
				trackBar_color = new TrackBar[3] { trackBar_color_r, trackBar_color_g, trackBar_color_b };
				for (int j = 0; j < 3; j++)
				{
					trackBar_color[j].Value = USR[i].mColor[j];
					trackBar_color[j].Tag = j;
					trackBar_color[j].ValueChanged += trackBar_color_valueChanged;
				}
				panel_color.BackColor = system_color(USR[i].mColor);
				if (USR[i].mTrackDelay == 0f)
				{
					USR[i].mTrackDelay = (HW.mIsSanduanshi ? 0.7f : 0.5f);
				}
				if (USR[i].mTrackSpeed == 0)
				{
					USR[i].mTrackSpeed = 8;
				}
				if (USR[i].mSlot4ConnerCoord == null)
				{
					USR[i].mSlot4ConnerCoord = new Coordinate[4];
					for (int k = 0; k < 4; k++)
					{
						USR[i].mSlot4ConnerCoord[k] = new Coordinate(0L, 0L);
					}
				}
				if (USR[i].mSlotAllCoord == null)
				{
					USR[i].mSlotAllCoord = new Coordinate[160];
					for (int l = 0; l < 160; l++)
					{
						USR[i].mSlotAllCoord[l] = new Coordinate(0L, 0L);
					}
				}
				else if (USR[i].mSlotAllCoord.Count() < 160)
				{
					Coordinate[] array = new Coordinate[USR[i].mSlotAllCoord.Count()];
					for (int m = 0; m < USR[i].mSlotAllCoord.Count(); m++)
					{
						array[m] = new Coordinate(USR[i].mSlotAllCoord[m]);
					}
					USR[i].mSlotAllCoord = new Coordinate[160];
					for (int n = 0; n < 160; n++)
					{
						if (n < array.Count())
						{
							USR[i].mSlotAllCoord[n] = new Coordinate(array[n]);
						}
						else
						{
							USR[i].mSlotAllCoord[n] = new Coordinate(0L, 0L);
						}
					}
				}
				for (int num = 0; num < 160; num++)
				{
					if (USR[i].mSlotAllCoord[num] == null)
					{
						USR[i].mSlotAllCoord[num] = new Coordinate(0L, 0L);
					}
				}
				if (USR[i].misfcam_disable == null)
				{
					bool[] array2 = (USR[i].misfcam_disable = new bool[8]);
				}
			}
			save_FixedData();
		}

		private bool initKSJ()
		{
			int num = 1;
			int nColumnStart = 324;
			int nColumnSize = 1944;
			int nRowSize = 1944;
			if (!mIsSimulation)
			{
				num = CAM.KSJ_Init();
				if (num <= 0)
				{
					write_to_logFile("CAM.KSJ_Init:" + num);
					return false;
				}
				CAM.KSJ_PREVIEWMODE PreviewMode = CAM.KSJ_PREVIEWMODE.PM_RAWDATA;
				CAM.KSJ_PreviewGetMode(0, ref PreviewMode);
				mKSJ_PreviewMode = PreviewMode;
				int num2 = CAM.KSJ_PreviewSetFieldOfView(0, nColumnStart, 0, nColumnSize, nRowSize, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE);
				if (num2 <= 0)
				{
					write_to_logFile("CAM.KSJ_PreviewSetFieldOfView:" + num2);
					return false;
				}
				num2 = CAM.KSJ_CaptureSetFieldOfView(0, nColumnStart, 0, nColumnSize, nRowSize, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE);
				if (num2 <= 0)
				{
					write_to_logFile("CAM.KSJ_CaptureSetFieldOfView:" + num2);
					return false;
				}
				Invoke((MethodInvoker)delegate
				{
					CAM.KSJ_PreviewSetPos(0, PicBox_Preview[HW.mHCamChnFn[0]].Handle, 0, 0, PicBox_Preview[HW.mHCamChnFn[0]].Size.Width, PicBox_Preview[HW.mHCamChnFn[0]].Size.Height);
					CAM.KSJ_SetParam(0, CAM.KSJ_PARAM.KSJ_RED, 0);
					CAM.KSJ_SetParam(0, CAM.KSJ_PARAM.KSJ_GREEN, 10);
					CAM.KSJ_SetParam(0, CAM.KSJ_PARAM.KSJ_BLUE, 10);
					CAM.KSJ_SetParam(0, CAM.KSJ_PARAM.KSJ_EXPOSURE_LINES, 500);
					CAM.KSJ_SetParam(0, CAM.KSJ_PARAM.KSJ_BRIGHTNESS, 60);
					CAM.KSJ_SetParam(0, CAM.KSJ_PARAM.KSJ_CONTRAST, 25);
				});
			}
			return true;
		}

		private void uninitKSJ()
		{
			if (!mIsSimulation)
			{
				CAM.KSJ_UnInit();
			}
		}

		private bool openKSJPreview(int channel)
		{
			if (((mKSJ_OpenedPreviewMask >> channel) & 1) == 1)
			{
				return true;
			}
			if (!mIsSimulation)
			{
				int nColumnStart = 324 + 486 * (mIsPreviewZoom ? 1 : 0);
				int nRowStart = 486 * (mIsPreviewZoom ? 1 : 0);
				int nColumnSize = 1944 / ((!mIsPreviewZoom) ? 1 : 2);
				int nRowSize = 1944 / ((!mIsPreviewZoom) ? 1 : 2);
				int num = CAM.KSJ_PreviewSetFieldOfView(0, nColumnStart, nRowStart, nColumnSize, nRowSize, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE);
				if (num <= 0)
				{
					write_to_logFile("CAM.KSJ_PreviewSetFieldOfView:" + num);
					return false;
				}
				DateTime now = DateTime.Now;
				CAM.KSJ_PreviewStart(channel, bStart: true);
				DateTime now2 = DateTime.Now;
				write_to_logFile("openKSJPreview: CAM.KSJ_PreviewStart(ch, true): " + (now2 - now).TotalMilliseconds + " ms");
			}
			mKSJ_OpenedPreviewMask |= 1 << channel;
			return true;
		}

		private bool closeKSJPreview(int fn)
		{
			int num = 0;
			while (mKSJ_OpenedPreviewMask != 0)
			{
				if ((mKSJ_OpenedPreviewMask & 1) == 1 && !mIsSimulation)
				{
					DateTime now = DateTime.Now;
					CAM.KSJ_PreviewStart(num, bStart: false);
					DateTime now2 = DateTime.Now;
					write_to_logFile("closeKSJPreview: CAM.KSJ_PreviewStart(ch, false): " + (now2 - now).TotalMilliseconds + " ms");
				}
				mKSJ_OpenedPreviewMask >>= 1;
				num++;
			}
			return true;
		}

		public static void thd_ksjstill(object chnl)
		{
			int num = (int)chnl;
			if (mIsSimulation)
			{
				msdelay(75);
				return;
			}
			CAM.KSJ_CaptureSetFieldOfView(0, 324, 0, mKSJ_VWsize, mKSJ_VHsize, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE);
			CAM.KSJ_CaptureRgbData(0, pKSJBuffer[num]);
			CAM.KSJ_CaptureGetSizeEx(0, out var _, out var _, out var pnBitCount);
			if (pnBitCount == 8)
			{
				int num2 = mKSJ_VWsize * mKSJ_VHsize;
				for (int i = 0; i < num2; i++)
				{
					int num3 = num2 - i - 1;
					int num4 = (num2 - i) * 3 - 1;
					int num5 = (num2 - i) * 3 - 2;
					int num6 = (num2 - i) * 3 - 3;
					pKSJBuffer[num][num4] = 0;
					pKSJBuffer[num][num5] = pKSJBuffer[num][num3];
					pKSJBuffer[num][num6] = pKSJBuffer[num][num3];
				}
			}
		}

		public static void startKSJStillAndWait(int ch)
		{
			thd_ksjstill(ch);
		}

		private void button_fcam_distortion_para_Click(object sender, EventArgs e)
		{
			Form_CamDistortionPara form_CamDistortionPara = new Form_CamDistortionPara(USR[mFn], CameraType.Fast);
			form_CamDistortionPara.ShowDialog();
		}

		private void button_hcam_distortion_para_Click(object sender, EventArgs e)
		{
			Form_CamDistortionPara form_CamDistortionPara = new Form_CamDistortionPara(USR[mFn], CameraType.High);
			form_CamDistortionPara.ShowDialog();
		}

		private void button_fcam_chess_Click(object sender, EventArgs e)
		{
			mark_led_on(mFn, flag: false);
			mark_light_on(mFn, flag: false);
			fhcam_led_on(mFn, CameraType.Fast, flag: true);
			Thread thread = new Thread(thd_fcam_chess);
			thread.IsBackground = true;
			thread.Start();
		}

		private void thd_fcam_chess()
		{
			int num = 10;
			while (num-- != 0)
			{
				VISUAL_RESULT visual_result = new VISUAL_RESULT();
				if (ImageVisual(mFn, VISUAL_MODE.CHESS_NONE_RESIZE, CameraType.Fast, VisualType.Chess, 280, 127, 0, 0, 0, 0f, ref visual_result) == ImageVisual_Result.OK)
				{
					Coordinate coordinate = new Coordinate(1L, 1L);
					double num2 = visual_result.box_center_x - 288f;
					double num3 = visual_result.box_center_y - 288f;
					coordinate.X = (long)((double)mCur[mFn].x - ((Math.Abs(num2) < 2.0) ? ((double)((num2 > 0.0) ? 1 : ((num2 < 0.0) ? (-1) : 0))) : num2) + 0.5);
					coordinate.Y = (long)((double)mCur[mFn].y - ((Math.Abs(num3) < 2.0) ? ((double)((num3 > 0.0) ? 1 : ((num3 < 0.0) ? (-1) : 0))) : num3) + 0.5);
					moveToXY_andWait(mFn, USR[mFn].mXYSpeed, coordinate);
					while (visual_result.move_a > 6400)
					{
						visual_result.move_a -= 12800;
					}
					while (visual_result.move_a <= -6400)
					{
						visual_result.move_a += 12800;
					}
					int num4 = mCur[mFn].a[mZn[mFn]] + visual_result.move_a;
					int a = num4 % 12800;
					moveToA_andWait(mFn, mZn[mFn], USR[mFn].mASpeed, a);
					continue;
				}
				return;
			}
			VISUAL_RESULT visual_result2 = new VISUAL_RESULT();
			float num5 = 0f;
			if (ImageVisual(mFn, VISUAL_MODE.CHESS_NONE_RESIZE, CameraType.Fast, VisualType.Chess, 280, 127, 0, 0, 0, 0f, ref visual_result2) != 0)
			{
				return;
			}
			num5 = Math.Max(visual_result2.box_height, visual_result2.box_width);
			int a2 = (mCur[mFn].a[mZn[mFn]] + AngleToSteps(90f)) % 12800;
			moveToA_andWait(mFn, mZn[mFn], USR[mFn].mASpeed, a2);
			float num6 = 0f;
			if (ImageVisual(mFn, VISUAL_MODE.CHESS_NONE_RESIZE, CameraType.Fast, VisualType.Chess, 280, 127, 0, 0, 0, 0f, ref visual_result2) != 0)
			{
				return;
			}
			num6 = Math.Max(visual_result2.box_height, visual_result2.box_width);
			USR[mFn].mFastCamDistortion[mZn[mFn]][0] = num5 / num6;
			int a3 = (mCur[mFn].a[mZn[mFn]] - AngleToSteps(90f)) % 12800;
			moveToA_andWait(mFn, mZn[mFn], USR[mFn].mASpeed, a3);
			VISUAL_RESULT visual_result3 = new VISUAL_RESULT();
			float num7 = 0f;
			if (ImageVisual(mFn, VISUAL_MODE.CHESS_RESIZE, CameraType.Fast, VisualType.Chess, 280, 127, 0, 0, 0, 0f, ref visual_result3) != 0)
			{
				return;
			}
			num7 = Math.Max(visual_result3.box_height, visual_result3.box_width);
			a3 = (mCur[mFn].a[mZn[mFn]] + AngleToSteps(90f)) % 12800;
			moveToA_andWait(mFn, mZn[mFn], USR[mFn].mASpeed, a3);
			float num8 = 0f;
			if (ImageVisual(mFn, VISUAL_MODE.CHESS_RESIZE, CameraType.Fast, VisualType.Chess, 280, 127, 0, 0, 0, 0f, ref visual_result3) != 0)
			{
				return;
			}
			num8 = Math.Max(visual_result3.box_height, visual_result3.box_width);
			if ((double)(num7 / num8) > 1.01)
			{
				MessageBox.Show("计算得出的参数不合理，请重新调整光源，再进行校准！");
				return;
			}
			int a4 = (mCur[mFn].a[mZn[mFn]] - AngleToSteps(90f)) % 12800;
			moveToA_andWait(mFn, mZn[mFn], USR[mFn].mASpeed, a4);
			moon_Visual_Chess_Clear();
			int num9 = mCur[mFn].x;
			int num10 = mCur[mFn].y;
			int num11 = mCur[mFn].a[mZn[mFn]];
			int num12 = 2133;
			int[][] array = new int[18][]
			{
				new int[3] { -250, 0, 0 },
				new int[3] { -200, -200, num12 },
				new int[3] { 0, -200, 0 },
				new int[3]
				{
					200,
					-200,
					-num12
				},
				new int[3] { 250, 0, 0 },
				new int[3] { 200, 200, num12 },
				new int[3] { 0, 200, 0 },
				new int[3]
				{
					-200,
					200,
					-num12
				},
				new int[3] { -250, 0, 0 },
				new int[3] { -200, -200, num12 },
				new int[3] { 0, -200, 0 },
				new int[3]
				{
					200,
					-200,
					-num12
				},
				new int[3] { 250, 0, 0 },
				new int[3] { 200, 200, num12 },
				new int[3] { 0, 200, 0 },
				new int[3]
				{
					-200,
					200,
					-num12
				},
				new int[3]
				{
					0,
					0,
					num12 * 3
				},
				null
			};
			int[] array2 = (array[17] = new int[3]);
			int[][] array3 = array;
			for (int i = 0; i < array3.Count(); i++)
			{
				moveToXY_noWait(mFn, USR[mFn].mXYSpeed, new Coordinate(num9 + array3[i][0], num10 + array3[i][1]));
				moveToA_andWait(mFn, mZn[mFn], USR[mFn].mASpeed, num11 + array3[i][2]);
				WaitComplete_XY(mFn);
				msdelay(100);
				VISUAL_RESULT visual_result4 = new VISUAL_RESULT();
				ImageVisual(mFn, VISUAL_MODE.CHESS_RESIZE, CameraType.Fast, VisualType.Chess, 280, 127, 0, 0, 0, 0f, ref visual_result4);
			}
			int num13 = (int)((double)mJvs_rawHeight * USR[mFn].mFastCamDistortion[mZn[mFn]][0] + 0.5);
			double[] array4 = new double[10];
			moon_Visual_Chess_CalibrateCamera(new Size(num13, num13), new Size(9, 7), new Size(1, 1), array4);
			for (int j = 0; j < 10; j++)
			{
				USR[mFn].mFastCamDistortion[mZn[mFn]][j + 1] = array4[j];
			}
			moon_Visual_Chess_Clear();
			Invoke((MethodInvoker)delegate
			{
				Form_CamDistortionPara form_CamDistortionPara = new Form_CamDistortionPara(USR[mFn], CameraType.Fast);
				form_CamDistortionPara.ShowDialog();
			});
		}

		private void init_fixed_delta()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR[i].mInkPad_CollectCoord == null)
				{
					USR[i].mInkPad_CollectCoord = new Coordinate(42999L, 72942L);
				}
				if (USR[i].mInkPad_WriteCoord == null)
				{
					USR[i].mInkPad_WriteCoord = new Coordinate(35659L, 40651L);
				}
				if (USR[i].mInkPad_WriteHeight == null)
				{
					USR[i].mInkPad_WriteHeight = new int[8] { -6793, 7079, -7033, 7136, -7231, 7098, -6865, 7005 };
				}
				if (USR[i].mInkPad_CollectHeight == null)
				{
					USR[i].mInkPad_CollectHeight = new int[8] { -6115, 6499, -6370, 6643, -6792, 6781, -6492, 6808 };
				}
				if (USR[i].mDeltaNozzle_Detail == null)
				{
					USR[i].mDeltaNozzle_Detail = new Coordinate[8][];
				}
				for (int j = 0; j < 8; j++)
				{
					if (USR[i].mDeltaNozzle_Detail[j] == null)
					{
						USR[i].mDeltaNozzle_Detail[j] = new Coordinate[8];
						for (int k = 0; k < 8; k++)
						{
							USR[i].mDeltaNozzle_Detail[j][k] = new Coordinate(USR[i].mDeltaNozzle[0][k].X, USR[i].mDeltaNozzle[0][k].Y);
						}
					}
				}
				if (USR[i].mTest_ScanR == 0)
				{
					USR[i].mTest_ScanR = 55;
				}
				if (USR[i].mTest_Threshold == 0)
				{
					USR[i].mTest_Threshold = 44;
				}
				if (USR[i].mTest_Pno == 0)
				{
					USR[i].mTest_Pno = 100;
				}
			}
		}

		public void hvc_imagestream_callback(uint ch, IntPtr context)
		{
			if (HVC_WAIT_COUNT[ch]++ >= 20)
			{
				ref IntPtr reference = ref HVC_DATA_PTR[ch];
				reference = hvc_tmp_buffer[ch][0];
			}
		}

		private void init_hvc_callback()
		{
			mIsHvcCallbackMode = true;
			if (!mIsHvcCallbackMode)
			{
				return;
			}
			HVC_DATA_PTR = new IntPtr[mJvs_Channels];
			HVC_WAIT_COUNT = new int[mJvs_Channels];
			hvc_tmp_buffer = new IntPtr[mJvs_Channels][];
			for (int i = 0; i < mJvs_Channels; i++)
			{
				ref IntPtr reference = ref HVC_DATA_PTR[i];
				reference = (IntPtr)0;
				HVC_WAIT_COUNT[i] = 0;
				hvc_tmp_buffer[i] = new IntPtr[1];
			}
			callbackImageStream = new JW6008HT.IMAGE_STREAM_CALLBACK[mJvs_Channels];
			for (int j = 0; j < mJvs_Channels; j++)
			{
				callbackImageStream[j] = hvc_imagestream_callback;
				JW6008HT.RegisterChannelImageStreamCallback(mJvs_Hd[j], callbackImageStream[j], mJvs_Hd[j]);
				JW6008HT.SetImageStream(mJvs_Hd[j], 1, 25u, (uint)mJvs_rawWidth, (uint)mJvs_rawHeight, hvc_tmp_buffer[j], 0);
			}
			write_to_logFile("hv-0");
			for (int k = 0; k < HW.mZnNum[mFn]; k++)
			{
				int num = HW.mFastCamItem[0].index[k];
				while (HVC_DATA_PTR[num] == (IntPtr)0)
				{
					Thread.Sleep(5);
				}
			}
			while (HVC_DATA_PTR[HW.mMarkCamItem[0].index[0]] == (IntPtr)0)
			{
				Thread.Sleep(5);
			}
			write_to_logFile("hv-1");
			for (int l = 0; l < mJvs_Channels; l++)
			{
				JW6008HT.SetImageStream(mJvs_Hd[l], 0, 25u, (uint)mJvs_rawWidth, (uint)mJvs_rawHeight, hvc_tmp_buffer[l], 0);
			}
		}

		public static void run_hvc_callback_mode_capture(int ch, byte[] jsvbuffer, int size)
		{
			if (HVC_DATA_PTR[ch] != (IntPtr)0)
			{
				Marshal.Copy(HVC_DATA_PTR[ch], jsvbuffer, 0, mJvs_rawWidth * mJvs_rawHeight * 2);
			}
		}

		private void vsplus_markCameraPara(int fn)
		{
			if (uc_markcampara == null || uc_markcampara.IsDisposed)
			{
				uc_markcampara = new UserControl_MarkCamPara(USR[fn]);
				base.Controls.Add(uc_markcampara);
				uc_markcampara.Location = new Point(4, 595);
				uc_markcampara.BringToFront();
				uc_markcampara.Show();
			}
		}

		public static void change_button_MarkCamPara_Text()
		{
		}

		public static void change_lightonoff_button(bool flag)
		{
		}

		public static void create_logFile()
		{
			mLogFileName = "C:/SmtLog/log_";
			DateTime now = DateTime.Now;
			string text = mLogFileName;
			mLogFileName = text + now.Year + now.Month.ToString("D2") + now.Day.ToString("D2") + "_" + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2") + "_" + now.Millisecond.ToString("D3") + ".txt";
			try
			{
				if (!Directory.Exists("C:/SmtLog"))
				{
					Directory.CreateDirectory("C:/SmtLog");
				}
				FileStream fileStream = new FileStream(mLogFileName, FileMode.OpenOrCreate);
				fileStream.Close();
			}
			catch (Exception)
			{
			}
		}

		public static void write_to_logFile_EXCEPTION(string msg)
		{
			write_to_logFile(mLogFileName, "EXCEPTION: " + msg + Environment.NewLine);
		}

		public static void write_to_logFile(string msg)
		{
			write_to_logFile(mLogFileName, msg + Environment.NewLine);
		}

		[DllImport("kernel32.dll")]
		private static extern IntPtr _lopen(string lpPathName, int iReadWrite);

		public static void write_to_logFile(string filename, string msg)
		{
			if (mMutexLog)
			{
				return;
			}
			mMutexLog = true;
			FileStream fileStream;
			if (File.Exists(filename))
			{
				IntPtr intPtr = _lopen(filename, 66);
				if (intPtr == new IntPtr(-1))
				{
					mMutexLog = false;
					return;
				}
				CloseHandle(intPtr);
				fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
			}
			else
			{
				fileStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
			}
			StreamWriter streamWriter = new StreamWriter(fileStream);
			string value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "  " + msg;
			streamWriter.Write(value);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
			mMutexLog = false;
		}

		public static void write_to_logFile_hand(string msg)
		{
			write_to_logFile(mLogFileName, msg);
		}

		private void button_NewCom_Click(object sender, EventArgs e)
		{
			int num = BUS.InitConnection();
			if (num == 1)
			{
				mIsNewCom = true;
			}
			MessageBox.Show(num.ToString());
		}

		private void button_NewCom_Close_Click(object sender, EventArgs e)
		{
			if (mIsNewCom)
			{
				BUS.UninitConnection();
				mIsNewCom = false;
			}
		}

		private void button_tempTest_Click_1(object sender, EventArgs e)
		{
			Thread thread = new Thread(thd_testZ);
			thread.Start();
		}

		private void thd_testZ()
		{
			DateTime now = DateTime.Now;
			for (int i = 0; i < 500; i++)
			{
				moveToZ_andWait(0, 0, 64, 500);
				moveToZ_andWait(0, 0, 64, 0);
			}
			DateTime now2 = DateTime.Now;
			MessageBox.Show((now2 - now).TotalMilliseconds.ToString());
		}

		private void panel_fakepcb_smt_Paint(object sender, PaintEventArgs e)
		{
		}

		public void load_UsrData()
		{
			USR2_DEFAUL = new USR2_DATA();
			string path = "./" + STR.DEVICE[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin";
			if (File.Exists(path))
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
				USR2_DEFAUL = (USR2_DATA)formatter.Deserialize(stream);
				stream.Close();
			}
		}

		public void save_UsrData()
		{
			IFormatter formatter = new BinaryFormatter();
			string path = "./" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin";
			Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, USR2_DEFAUL);
			stream.Close();
		}

		private void MessageNoticeFeederGoodbye(int fn)
		{
			mThd_FeederGoodbye[fn] = new Thread(thd_MessageNoticeFeederGoodbye);
			mThd_FeederGoodbye[fn].IsBackground = true;
			mThd_FeederGoodbye[fn].Start(fn);
		}

		private void init_feedergoodbye()
		{
			mThd_FeederGoodbye = new Thread[HW.mFnNum];
			mFmFeederGoodbye = new Form_OpenShape[HW.mFnNum];
			mIsRunDoingBackSetRRRR_FeederGoodbye = new bool[HW.mFnNum];
			mRunDoingBackUp_FeederGoodbye = new byte[HW.mFnNum];
			mIsCloseNotDone_FeederGoodbye = new bool[HW.mFnNum];
			mIsRunDoingBackSetRRRR = new bool[HW.mFnNum];
			mRunDoingBackUp = new byte[HW.mFnNum];
			mIsCloseNotDone = new bool[HW.mFnNum];
			mThd_OpenShape = new Thread[HW.mFnNum];
			mFmOpenShape = new Form_OpenShape[HW.mFnNum];
			mIsFeederUp = new bool[HW.mFnNum];
			mIsXYMoving = new bool[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mThd_FeederGoodbye[i] = null;
				mFmFeederGoodbye[i] = null;
				mIsRunDoingBackSetRRRR_FeederGoodbye[i] = false;
				mRunDoingBackUp_FeederGoodbye[i] = 0;
				mIsCloseNotDone_FeederGoodbye[i] = false;
				mIsRunDoingBackSetRRRR[i] = false;
				mRunDoingBackUp[i] = 0;
				mIsCloseNotDone[i] = false;
				mThd_OpenShape[i] = null;
				mFmOpenShape[i] = null;
				mIsFeederUp[i] = false;
				mIsXYMoving[i] = false;
			}
		}

		private void thd_MessageNoticeFeederGoodbye(object o)
		{
			int fn = (int)o;
			mIsFeederUp[fn] = true;
			if (!mIsXYMoving[fn])
			{
				if (mConDev != null && mConDev[fn] != null)
				{
					mConDev[fn].readFeederGoodbyeStatus();
				}
				return;
			}
			Invoke((MethodInvoker)delegate
			{
				if (!mIsRunDoingBackSetRRRR_FeederGoodbye[fn])
				{
					mIsRunDoingBackSetRRRR_FeederGoodbye[fn] = true;
					mRunDoingBackUp_FeederGoodbye[fn] = mRunDoing[fn];
				}
				mRunDoing[fn] |= 1;
				if (!mIsCloseNotDone_FeederGoodbye[fn])
				{
					mIsCloseNotDone_FeederGoodbye[fn] = true;
					mFmFeederGoodbye[fn] = new Form_OpenShape(USR_INIT.mLanguage, "feeder");
					mFmFeederGoodbye[fn].FeederGoodbye();
					if (!mIsBuzzerWarning[fn])
					{
						mIsBuzzerWarning[fn] = true;
						Thread thread = new Thread(thd_buzzer_warning);
						thread.IsBackground = true;
						thread.Start(mFn);
					}
					switch (mFmFeederGoodbye[fn].ShowDialog())
					{
					case DialogResult.Cancel:
						mIsCloseNotDone_FeederGoodbye[fn] = false;
						if ((!QnCommon.mIsFeederGoodbye[fn] || !mIsXYMoving[fn]) && !USR_INIT.mIsNotFeederGoodbye && mIsRunDoingBackSetRRRR_FeederGoodbye[fn])
						{
							mIsRunDoingBackSetRRRR_FeederGoodbye[fn] = false;
							mRunDoing[fn] = mRunDoingBackUp_FeederGoodbye[fn];
						}
						break;
					case DialogResult.No:
						USR_INIT.mIsNotFeederGoodbye = true;
						mIsCloseNotDone_FeederGoodbye[fn] = false;
						if (mIsRunDoingBackSetRRRR_FeederGoodbye[fn])
						{
							mIsRunDoingBackSetRRRR_FeederGoodbye[fn] = false;
							mRunDoing[fn] = mRunDoingBackUp_FeederGoodbye[fn];
						}
						break;
					}
				}
				else if (mFmFeederGoodbye[fn] != null && !mFmFeederGoodbye[fn].IsDisposed)
				{
					mFmFeederGoodbye[fn].FeederGoodbye();
				}
				if (mConDev != null && mConDev[fn] != null)
				{
					mConDev[fn].readFeederGoodbyeStatus();
				}
			});
		}

		private void thd_MessageNoticeFeederGoodbyeClear(object o)
		{
			int fn = (int)o;
			mIsFeederUp[fn] = false;
			Invoke((MethodInvoker)delegate
			{
				if (mFmFeederGoodbye[fn] != null && !mFmFeederGoodbye[fn].IsDisposed)
				{
					mFmFeederGoodbye[fn].FeederGoodbye_Clear();
					mIsBuzzerWarning[fn] = false;
				}
			});
		}

		private void MessageNoticeFeederGoodbyeClearEnd(int fn)
		{
			Thread thread = new Thread(thd_MessageNoticeFeederGoodbyeClear);
			thread.IsBackground = true;
			thread.Start(fn);
		}

		private void thd_MessageNoticeOpenShape(object o)
		{
			int fn = (int)o;
			Invoke((MethodInvoker)delegate
			{
				if (!mIsRunDoingBackSetRRRR[fn])
				{
					mIsRunDoingBackSetRRRR[fn] = true;
					mRunDoingBackUp[fn] = mRunDoing[fn];
				}
				mRunDoing[fn] |= 1;
				if (!mIsCloseNotDone[fn])
				{
					mIsCloseNotDone[fn] = true;
					mFmOpenShape[fn] = new Form_OpenShape(USR_INIT.mLanguage, "shape");
					mFmOpenShape[fn].OpenShape();
					if (mFmOpenShape[fn].ShowDialog() == DialogResult.Cancel)
					{
						mIsCloseNotDone[fn] = false;
						if (!QnCommon.mIsShapeOpen[fn] && USR_INIT.mIsOpenShapeStopRun && mIsRunDoingBackSetRRRR[fn])
						{
							mIsRunDoingBackSetRRRR[fn] = false;
							mRunDoing[fn] = mRunDoingBackUp[fn];
						}
					}
				}
				else if (mFmOpenShape[fn] != null && !mFmOpenShape[fn].IsDisposed)
				{
					mFmOpenShape[fn].OpenShape();
				}
				if (mConDev != null && mConDev[fn] != null)
				{
					mConDev[fn].readOpenShapeStatus();
				}
			});
		}

		private void MessageNoticeOpenShape(int fn)
		{
			mThd_OpenShape[fn] = new Thread(thd_MessageNoticeOpenShape);
			mThd_OpenShape[fn].IsBackground = true;
			mThd_OpenShape[fn].Start(fn);
		}

		private void thd_MessageNoticeCloseShape(object o)
		{
			int fn = (int)o;
			Invoke((MethodInvoker)delegate
			{
				if (mFmOpenShape[fn] != null && !mFmOpenShape[fn].IsDisposed)
				{
					mFmOpenShape[fn].CloseShape();
				}
			});
		}

		private void MessageNoticeCloseShapeEnd(int fn)
		{
			Thread thread = new Thread(thd_MessageNoticeCloseShape);
			thread.IsBackground = true;
			thread.Start(fn);
		}

		public static bool is_engineer_password_correct()
		{
			if (mIsPassedEngineerPassword)
			{
				return mIsPassedEngineerPassword;
			}
			if (File.Exists("../configdata/ENGINEER_PASSWORD.bin"))
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream("../configdata/ENGINEER_PASSWORD.bin", FileMode.Open, FileAccess.Read, FileShare.None);
				mEngineerPassword = (string)formatter.Deserialize(stream);
				stream.Close();
			}
			else
			{
				mEngineerPassword = "";
				IFormatter formatter2 = new BinaryFormatter();
				Stream stream2 = new FileStream("../configdata/ENGINEER_PASSWORD.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				formatter2.Serialize(stream2, mEngineerPassword);
				stream2.Close();
			}
			if (mEngineerPassword == "")
			{
				return true;
			}
			Form_EngineerPassword form_EngineerPassword = new Form_EngineerPassword(USR_INIT.mLanguage, 0, mEngineerPassword);
			switch (form_EngineerPassword.ShowDialog())
			{
			case DialogResult.Yes:
				modify_engineer_password();
				break;
			case DialogResult.Cancel:
				mIsPassedEngineerPassword = false;
				break;
			case DialogResult.OK:
				mIsPassedEngineerPassword = true;
				break;
			}
			return mIsPassedEngineerPassword;
		}

		public static bool modify_engineer_password()
		{
			Form_EngineerPassword form_EngineerPassword = new Form_EngineerPassword(USR_INIT.mLanguage, 1, mEngineerPassword);
			DialogResult dialogResult = form_EngineerPassword.ShowDialog();
			if (dialogResult == DialogResult.OK || dialogResult == DialogResult.No)
			{
				mEngineerPassword = form_EngineerPassword.get_form_engineer_password();
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream("../configdata/ENGINEER_PASSWORD.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				formatter.Serialize(stream, mEngineerPassword);
				stream.Close();
				mIsPassedEngineerPassword = true;
				CmMessageBoxTop_Ok((dialogResult != DialogResult.No) ? ((USR_INIT.mLanguage == 2) ? "Engineer password modify done!" : "工程师密码修改成功！") : ((USR_INIT.mLanguage == 2) ? "Engineer password delete done!" : "工程师密码删除成功！"));
				return mIsPassedEngineerPassword;
			}
			return false;
		}

		public static void lock_engineer_password()
		{
			if (CmMessageBox((USR_INIT.mLanguage == 2) ? "After engineer locked, you need to enter engineer password to unlock, continue?" : "密码锁定后，需要输入工程师密码进行解锁，确定进行？", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				mIsPassedEngineerPassword = false;
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Engineer password locked done!" : "工程师密码锁定成功！");
			}
		}

		public static void vsplus_visualtest(USR2_DATA usr2)
		{
			USR2[mFn] = usr2;
			if (!mutex_piktocam)
			{
				mutex_piktocam = true;
				Thread thread = new Thread(thd_vsplus_visual_test);
				thread.IsBackground = true;
				thread.Start((int)USR2[mFn].mStackLib.sel);
			}
		}

		public static void thd_vsplus_visual_test(object o)
		{
			mark_led_on_ext(mFn, flag: false);
			mark_light_on_ext(mFn, flag: false);
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			visual_result.is_test = true;
			if (mCurCam[mFn] != CameraType.Fast && mCurCam[mFn] != CameraType.High)
			{
				CmMessageBoxTop_Ok("请切换到正确的相机类型");
			}
			else
			{
				StackElement[] array = USR2[mFn].mStackLib.stacktab[(int)o];
				int num = USR2[mFn].mStackLib.index[(int)o];
				VisualType visualtype = array[num].visualtype;
				int cur_range = array[num].scanR;
				int threshold = array[num].mZnData[mZn[mFn]].threshold;
				if (visualtype == VisualType.FootPrint_R)
				{
					PinConfig pinconfig = common_footprint_get_pinconfig(array[num].mChipFootprint);
					visual_result.set_pinconfig(pinconfig);
				}
				is_smt_test = true;
				switch (mCurCam[mFn])
				{
				case CameraType.Fast:
					if (!array[num].mIsScanR)
					{
						cur_range = USR2[mFn].mFastCamScanRange[0][mZn[mFn]];
					}
					uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
					fhcam_led_on_ext(mFn, CameraType.Fast, flag: true);
					visual_result.is_test = true;
					visual_result.set_w_h(array[num].lenght, array[num].width);
					if (mIsSimulation && File.Exists("C:\\E\\hwgcpic\\fastcam.bmp"))
					{
						int num2 = HW.mFastCamItem[mFn].index[mZn[mFn]];
						mJVSBitmap[num2] = new Bitmap("C:\\E\\hwgcpic\\fastcam.bmp");
					}
					if (ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.Fast, visualtype, cur_range, threshold, mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
					{
						CmMessageBox((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "快速相机识别测试识别失败", MessageBoxButtons.OK);
					}
					break;
				case CameraType.High:
				{
					if (!array[num].mIsScanR)
					{
						cur_range = USR2[mFn].mHighCamScanRange[0][mZn[mFn]];
					}
					uc_usroperarion[mFn].switch_to_cam(CameraType.High);
					fhcam_led_on_ext(mFn, CameraType.High, flag: true);
					if (USR2 != null && array[num].mIsHCamSpecialPara)
					{
						hcam_lightlevel_set(mFn, array[num].HCamSpecial_ledlevel);
					}
					if (mIsSimulation)
					{
						string text = "C:\\E\\hwgcpic\\highcam.bmp";
						if (File.Exists(text))
						{
							Bitmap bitmap = new Bitmap(text);
							BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, 1944, 1944), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
							Marshal.Copy(bitmapData.Scan0, pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 0, 11337408);
							bitmap.UnlockBits(bitmapData);
						}
					}
					VISUAL_MODE vISUAL_MODE = VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE;
					vISUAL_MODE = VISUAL_MODE.COMMON;
					visual_result.is_test = true;
					visual_result.set_w_h(array[num].lenght, array[num].width);
					if (ImageVisual(mFn, vISUAL_MODE, CameraType.High, visualtype, cur_range, threshold, mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
					{
						CmMessageBox((USR_INIT.mLanguage == 2) ? "HD camera detect chip fail!" : "高清相机识别测试识别失败", MessageBoxButtons.OK);
					}
					break;
				}
				}
			}
			mutex_piktocam = false;
		}

		public static void vsplus_running_visual(USR2_DATA usr2)
		{
			if (mIsSimulation && mIsVisualRunning)
			{
				if (!Directory.Exists(USR[mFn].mDebug_PicFolder))
				{
					return;
				}
				DirectoryInfo directoryInfo = new DirectoryInfo(USR[mFn].mDebug_PicFolder);
				FileInfo[] files = directoryInfo.GetFiles();
				if (files.Count() == 0)
				{
					return;
				}
				test_pic_num = files.Count();
				if (USR[mFn].mDebug_PicIndex >= test_pic_num)
				{
					USR[mFn].mDebug_PicIndex = test_pic_num - 1;
				}
				else if (USR[mFn].mDebug_PicIndex < 0)
				{
					USR[mFn].mDebug_PicIndex = 0;
				}
				string filename = USR[mFn].mDebug_PicFolder + files[USR[mFn].mDebug_PicIndex];
				int num = mZn[mFn];
				mJVSBitmap[num] = new Bitmap(filename);
			}
			USR2[mFn] = usr2;
			Thread thread = new Thread(thd_vsplus_visualrunning);
			thread.IsBackground = true;
			thread.Start(USR2[mFn].mStackLib.sel);
		}

		public static void thd_vsplus_visualrunning(object o)
		{
			StackElement[] array = USR2[mFn].mStackLib.stacktab[(int)o];
			int num = USR2[mFn].mStackLib.index[(int)o];
			mark_light_on_ext(mFn, flag: false);
			mark_led_on_ext(mFn, flag: false);
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			static_this.Invoke((MethodInvoker)delegate
			{
				pictureBox_visualrunning[mFn].Visible = true;
				button_stop_runningvisual[mFn].Visible = true;
				uc_usroperarion[mFn].hiden_cam_button(flag: true);
				button_stop_runningvisual[mFn].BringToFront();
			});
			while (mIsVisualRunning)
			{
				VisualType visualtype = array[num].visualtype;
				int cur_range = array[num].scanR;
				int threshold = array[num].mZnData[mZn[mFn]].threshold;
				if (visualtype == VisualType.FootPrint_R)
				{
					PinConfig pinconfig = common_footprint_get_pinconfig(array[num].mChipFootprint);
					visual_result.set_pinconfig(pinconfig);
				}
				switch (mCurCam[mFn])
				{
				case CameraType.Fast:
					if (!array[num].mIsScanR)
					{
						cur_range = USR2[mFn].mFastCamScanRange[0][mZn[mFn]];
					}
					uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
					fhcam_led_on(mFn, CameraType.Fast, flag: true);
					visual_result.is_test = true;
					visual_result.set_w_h(array[num].lenght, array[num].width);
					ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.Fast, visualtype, cur_range, threshold, mZn[mFn], 0, 0, 0f, ref visual_result);
					break;
				case CameraType.High:
				{
					if (!array[num].mIsScanR)
					{
						cur_range = USR2[mFn].mHighCamScanRange[0][mZn[mFn]];
					}
					uc_usroperarion[mFn].switch_to_cam(CameraType.High);
					if (USR2 != null)
					{
						if (array[num].mIsHCamSpecialPara)
						{
							hcam_lightlevel_set(mFn, array[num].HCamSpecial_ledlevel);
						}
						else
						{
							hcam_lightlevel_set(mFn, USR2[mFn].mHighCamLightLevel[0]);
						}
					}
					else
					{
						fhcam_led_on(mFn, CameraType.High, flag: true);
					}
					VISUAL_MODE vISUAL_MODE = VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE;
					vISUAL_MODE = VISUAL_MODE.COMMON;
					visual_result.is_test = true;
					visual_result.set_w_h(array[num].lenght, array[num].width);
					ImageVisual(mFn, vISUAL_MODE, CameraType.High, visualtype, cur_range, threshold, mZn[mFn], 0, 0, 0f, ref visual_result);
					break;
				}
				}
				Thread.Sleep(20);
			}
			static_this.Invoke((MethodInvoker)delegate
			{
				pictureBox_visualrunning[mFn].Visible = false;
				button_stop_runningvisual[mFn].Visible = false;
				uc_usroperarion[mFn].hiden_cam_button(flag: false);
			});
		}

		private void button_stop_runningvisual_Click(object sender, EventArgs e)
		{
			if (uc_job[mFn].uc_stack != null && !uc_job[mFn].uc_stack.IsDisposed)
			{
				uc_job[mFn].uc_stack.button_visualrunning_Click(sender, e);
			}
			else if (mIsSimulation)
			{
				button_algorithm_debug_running_Click(sender, e);
			}
		}

		private void thd_init_hardware()
		{
			string text = "";
			text = "设备连接中...";
			string text2 = text;
			text = text2 + Environment.NewLine + Environment.NewLine + "机型：" + STR.DEVICE[(int)HW.mDeviceType];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < HW.mFnNum; i++)
			{
				num += HW.mZnNum[i];
				num2 += HW.mStackNum[i][0];
			}
			text = text + Environment.NewLine + "吸嘴数量：" + num;
			if (HW.mFnNum == 2)
			{
				string text3 = text;
				text = text3 + "  (左机：" + HW.mZnNum[0] + "  右机：" + HW.mZnNum[1] + " )";
			}
			text = text + Environment.NewLine + "飞达数量：" + num2;
			if (HW.mFnNum == 2)
			{
				string text4 = text;
				text = text4 + "  (左机：" + HW.mStackNum[0][0] + "  右机：" + HW.mStackNum[1][0] + " )";
			}
			common_waiting_start((USR_INIT.mLanguage == 2) ? "Loading..." : text, 80, 5);
			is_serial_init_finished = false;
			is_camera_init_finished = false;
			write_to_logFile("设备连接初始化：开始");
			Thread thread = new Thread(thd_init_serial);
			thread.IsBackground = true;
			thread.Start();
			thd_init_fastcam();
		}

		private void init_done()
		{
			write_to_logFile("设备连接初始化：结果" + (mIsInitSuccess_FastCam ? "1" : "0") + (mIsInitSuccess_HighCam ? "1" : "0") + (mIsInitSuccess_Serial ? "  1" : "  0"));
			if (!mIsInitSuccess_Serial)
			{
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Connect Fail!" : "设备连接失败，请检查控制机与机器之间的连接！");
			}
			if (!mIsInitSuccess_FastCam)
			{
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Fast Camera Init Fail!" : "快速相机初始化失败！");
			}
			if (!mIsInitSuccess_HighCam)
			{
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "High Camera Init Fail!" : "高清相机初始化失败！");
			}
			if (mIsInitSuccess_FastCam && mIsInitSuccess_Serial)
			{
				for (int i = 0; i < HW.mFnNum; i++)
				{
					flush_visual_light(i);
				}
				try_visual_test();
			}
			int f;
			for (f = 0; f < HW.mFnNum; f++)
			{
				UI_Enable_USR(f, flag: true);
				Invoke((MethodInvoker)delegate
				{
					uc_usroperarion[f].hiden_cam_button(flag: false);
				});
			}
			common_waiting_break();
			write_to_logFile("设备连接初始化：完成");
		}

		private void thd_init_serial()
		{
			write_to_logFile("通讯接口初始化线程开始");
			mIsInitSuccess_Serial = initConnection();
			if (!mIsInitSuccess_Serial)
			{
				uninitConnection();
			}
			write_to_logFile("通讯接口初始化线程完成");
			is_serial_init_finished = true;
			while (!is_serial_init_finished || !is_camera_init_finished)
			{
				Thread.Sleep(10);
			}
			init_done();
		}

		private void thd_init_fastcam()
		{
			write_to_logFile("相机初始化线程开始");
			mIsInitSuccess_HighCam = init_highcam();
			if (!mIsInitSuccess_HighCam)
			{
				uninit_highcam();
			}
			mIsInitSuccess_FastCam = init_fastcam();
			if (!mIsInitSuccess_FastCam)
			{
				uninit_fastcam();
			}
			write_to_logFile("相机初始化线程完成");
			is_camera_init_finished = true;
		}

		private void __btn_Connect_Click(object sender, EventArgs e)
		{
			if (mIsSecurityTest)
			{
				int num = __wind_checkget_software_state(1);
				if (num == 2 || num == 3 || num == 4)
				{
					return;
				}
			}
			mMutexMoveXYZA = false;
			if (!bmIsConnected)
			{
				write_to_logFile_hand("HAND: btn_Connect_Click Connect" + Environment.NewLine);
				thd_init_hardware();
			}
			else
			{
				if (CmMessageBox((USR_INIT.mLanguage == 2) ? "Sure to Disconnect Device?" : "是否确定断开连接?", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
				write_to_logFile_hand("HAND: btn_Connect_Click Disconnect" + Environment.NewLine);
				for (int i = 0; i < HW.mFnNum; i++)
				{
					for (int j = 0; j < HW.mZnNum[i]; j++)
					{
						misc_vacc_onoff(i, j, 0);
					}
					for (int k = 0; k < HW.mStackNum[i][0]; k++)
					{
						misc_feeder_onoff(i, ProviderType.Feedr, k, flag: false);
					}
				}
				uninitCamera();
				uninitConnection();
				for (int l = 0; l < HW.mFnNum; l++)
				{
					UI_ControlEnable(l, flag: false, UI_ENABLE.USR);
				}
			}
		}

		public static void PR_Draw(PictureBox pb_r2, PointF center, SizeF size, double angle)
		{
			if (!size.IsEmpty)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				angle = angle * Math.PI / 180.0;
				float num = (float)Math.Cos(0.0 - angle) * 0.5f;
				float num2 = (float)Math.Sin(0.0 - angle) * 0.5f;
				PointF[] array = new PointF[4]
				{
					default(PointF),
					default(PointF),
					default(PointF),
					default(PointF)
				};
				if (mIsPreviewZoom)
				{
					size.Width *= 2f;
					size.Height *= 2f;
				}
				array[0].X = center.X - num * size.Width - num2 * size.Height;
				array[0].Y = center.Y + num2 * size.Width - num * size.Height;
				array[1].X = center.X + num * size.Width - num2 * size.Height;
				array[1].Y = center.Y - num2 * size.Width - num * size.Height;
				array[2].X = 2f * center.X - array[0].X;
				array[2].Y = 2f * center.Y - array[0].Y;
				array[3].X = 2f * center.X - array[1].X;
				array[3].Y = 2f * center.Y - array[1].Y;
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[0]);
				size.Width -= 2f;
				size.Height -= 2f;
				array[0].X = center.X - num * size.Width - num2 * size.Height;
				array[0].Y = center.Y + num2 * size.Width - num * size.Height;
				array[1].X = center.X + num * size.Width - num2 * size.Height;
				array[1].Y = center.Y - num2 * size.Width - num * size.Height;
				array[2].X = 2f * center.X - array[0].X;
				array[2].Y = 2f * center.Y - array[0].Y;
				array[3].X = 2f * center.X - array[1].X;
				array[3].Y = 2f * center.Y - array[1].Y;
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[0]);
				graphicsPath.CloseFigure();
				PointF pointF = new PointF(array[0].X + 11f * (array[0].X - array[1].X) / size.Width, array[0].Y + 11f * (array[0].Y - array[1].Y) / size.Width);
				PointF pointF2 = new PointF(array[3].X + 11f * (array[3].X - array[2].X) / size.Width, array[3].Y + 11f * (array[3].Y - array[2].Y) / size.Width);
				PointF pointF3 = new PointF(array[0].X + 9f * (array[0].X - array[1].X) / size.Width, array[0].Y + 9f * (array[0].Y - array[1].Y) / size.Width);
				PointF pointF4 = new PointF(array[3].X + 9f * (array[3].X - array[2].X) / size.Width, array[3].Y + 9f * (array[3].Y - array[2].Y) / size.Width);
				graphicsPath.AddLine(pointF, pointF3);
				graphicsPath.AddLine(pointF3, pointF4);
				graphicsPath.AddLine(pointF4, pointF2);
				graphicsPath.AddLine(pointF2, pointF);
				graphicsPath.CloseFigure();
				pb_r2.Region = new Region(graphicsPath);
			}
		}

		public static void DU_Draw(PictureBox pb_r3, PointF center, int R)
		{
			if (R >= 0)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				if (mIsPreviewZoom)
				{
					R *= 2;
				}
				int num = (int)center.X - R;
				int num2 = (int)center.Y - R;
				int num3 = R * 2;
				int num4 = R * 2;
				graphicsPath.AddEllipse(num, num2, num3, num4);
				graphicsPath.AddEllipse(num + 2, num2 + 2, num3 - 4, num4 - 4);
				graphicsPath.CloseFigure();
				pb_r3.Region = new Region(graphicsPath);
			}
		}

		public static Region GetRegionForPicBoxCSL(PictureBox pb)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int num = 15;
			int num2 = 12;
			for (int i = -16; i < 17; i++)
			{
				if (Math.Abs(i) > 2)
				{
					graphicsPath.AddRectangle(new Rectangle(pb.Width / 2 - i * num, pb.Height / 2 - num2 * (Math.Abs((i + 1) % 2) + 1), 1, num2 * 2 * (Math.Abs((i + 1) % 2) + 1) + 1));
					graphicsPath.AddRectangle(new Rectangle(pb.Width / 2 - num2 * (Math.Abs((i + 1) % 2) + 1), pb.Height / 2 - i * num, num2 * 2 * (Math.Abs((i + 1) % 2) + 1) + 1, 1));
				}
			}
			num = 5;
			num2 = 3;
			for (int j = -8; j < 9; j++)
			{
				graphicsPath.AddRectangle(new Rectangle(pb.Width / 2 - j * num, pb.Height / 2 - num2 * (Math.Abs((j + 1) % 2) + 1), 1, num2 * 2 * (Math.Abs((j + 1) % 2) + 1) + 1));
				graphicsPath.AddRectangle(new Rectangle(pb.Width / 2 - num2 * (Math.Abs((j + 1) % 2) + 1), pb.Height / 2 - j * num, num2 * 2 * (Math.Abs((j + 1) % 2) + 1) + 1, 1));
			}
			graphicsPath.FillMode = FillMode.Winding;
			return new Region(graphicsPath);
		}

		private void button_moon_qign_test_Click(object sender, EventArgs e)
		{
			if (mCurCam[mFn] == CameraType.High)
			{
				moon_buffer_move_angel(pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 24, new Size(1944, 1944), new Point(972, 972), USR[mFn].mhcam_scanr, USR[mFn].mAStepDegree);
				VISUAL_RESULT visual_result = new VISUAL_RESULT();
				visual_result.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
				if (ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.High, VisualType.Normal, USR[mFn].mhcam_scanr, USR[mFn].mhcam_threshold, mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
				{
					MessageBoxShow_OK((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "高清相机识别测试识别失败");
				}
			}
		}

		private void try_visual_test()
		{
			if (mJvsDriver == JvsDriver.JVS960S && HW.mZnNum[mFn] == 4)
			{
				Thread thread = new Thread(thd_try_visual_test);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		private void thd_try_visual_test()
		{
			uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
			msdelay(50);
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			int i;
			for (i = 0; i < HW.mZnNum[mFn]; i++)
			{
				radiobt_zn[mFn][i].Invoke((MethodInvoker)delegate
				{
					radiobt_zn[mFn][i].Checked = true;
				});
				msdelay(200);
				visual_result.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
				ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.Fast, VisualType.Normal, USR[mFn].mfcam_scanr, USR[mFn].mfcam_threshold, mZn[mFn], 0, 0, 0f, ref visual_result);
				msdelay(20);
			}
		}

		private static string[] GetHarewareInfo(HardwareEnum hardType, string propKey)
		{
			List<string> list = new List<string>();
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from " + hardType))
				{
					ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
					foreach (ManagementBaseObject item2 in managementObjectCollection)
					{
						if (item2.Properties[propKey].Value != null)
						{
							string item = item2.Properties[propKey].Value.ToString();
							list.Add(item);
						}
					}
				}
				return list.ToArray();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
			finally
			{
				list = null;
			}
		}

		public List<string> queryValidComList()
		{
			List<string> list = new List<string>();
			string[] harewareInfo = GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name");
			if (harewareInfo != null)
			{
				string[] array = harewareInfo;
				foreach (string text in array)
				{
					if ((text.Length < 23 || !text.Contains("Serial Port")) && (text.Length < 23 || !text.Contains("CP210x")) && (text.Length < 10 || !text.Contains("HWGC-QiGn")))
					{
						continue;
					}
					write_to_logFile(text);
					string[] array2 = text.Split('(');
					if (array2.Count() == 2)
					{
						string[] array3 = array2[1].Split(')');
						if (array3.Count() == 2)
						{
							list.Add(array3[0]);
							mPortBautRate.Add(queryBautRate(text));
							write_to_logFile(array3[0]);
						}
					}
				}
			}
			return list;
		}

		public int queryBautRate(string portname)
		{
			if (portname.Contains("HWGC-QiGn"))
			{
				return 19200;
			}
			return 460800;
		}

		private void initConnectionPre()
		{
			string[] portNames = SerialPort.GetPortNames();
			Array.Sort(portNames);
			mPortName = new BindingList<string>();
			mPortName.Clear();
			mPortBautRate = new BindingList<int>();
			mPortBautRate.Clear();
			List<string> list = queryValidComList();
			for (int i = 0; i < list.Count; i++)
			{
				mPortName.Add(list[i]);
			}
			bmIsConnected = false;
		}

		private void uninitConnection()
		{
			if (mComUsingList != null && mComUsingList.Count > 0)
			{
				for (int i = 0; i < mComUsingList.Count; i++)
				{
					mComUsingList[i].ClearDataBuffer();
					mComUsingList[i].Close();
					mComUsingList[i] = null;
				}
				mComUsingList.Clear();
			}
			bmIsConnected = false;
			Invoke((MethodInvoker)delegate
			{
				btn_Connect.Text = STR.CONNECT[USR_INIT.mLanguage];
			});
		}

		private bool initConnection()
		{
			if (HW.mSmtGenerationNo == 2)
			{
				return initConnection_gen2();
			}
			return initConnection_gen0();
		}

		private void mSerialPort_LogMessage(object sender, string msg, int Comn, int fn)
		{
		}

		private void process_ReceivedLogMessage(byte[] data, int Comn, int fn)
		{
		}

		private void mSerialPort_ERRORReceived(object sender, byte[] data, int Comn, int fn)
		{
			lock (data)
			{
				string text = "mSerialPort_ERRORReceived 主板" + Comn + Environment.NewLine;
				for (int i = 0; i < data.Count(); i++)
				{
					text = text + "0x" + data[i].ToString("X") + Environment.NewLine;
				}
				msdelay(200);
			}
		}

		private void mSerialPort_DataReceived(object sender, byte[] data, int Comn, int fn)
		{
			lock (mDat)
			{
				ProcessData(data, Comn, fn);
			}
		}

		private void workaround_reseaved_extern_len(int comn, int zerolen)
		{
			if (zerolen <= 0 || zerolen >= 6)
			{
				return;
			}
			lock (sReserved)
			{
				if (sReserved[comn] == null || sReserved[comn].Length == 0)
				{
					sReserved[comn] = new byte[zerolen];
					for (int i = 0; i < zerolen; i++)
					{
						sReserved[comn][i] = 0;
					}
					return;
				}
				byte[] array = new byte[sReserved[comn].Length];
				sReserved[comn].CopyTo(array, 0);
				sReserved[comn] = new byte[array.Length + zerolen];
				array.CopyTo(sReserved[comn], 0);
				for (int j = 0; j < zerolen; j++)
				{
					sReserved[comn][j + array.Length] = 0;
				}
			}
		}

		private bool workaround_is_valid_cmd(byte[] data)
		{
			bool result = false;
			switch (data[0])
			{
			case 224:
			{
				int num = data[2] | (data[3] << 8) | ((data[1] & 0xF0) << 12);
				int num2 = data[4] | (data[5] << 8) | ((data[1] & 0xF) << 16);
				if (num >= 0 && num < HW.mMaxX[0] && num2 >= 0 && num2 < HW.mMaxY[0])
				{
					result = true;
					break;
				}
				return false;
			}
			case 226:
			{
				int num5 = data[1];
				if (num5 >= HW.mZnNum[mFn] / 2 || num5 < 0)
				{
					return false;
				}
				int num6 = data[2] | (data[3] << 8) | (data[4] << 16) | (data[5] << 24);
				if (num6 <= -HW.mMaxZ[0] || num6 >= HW.mMaxZ[0])
				{
					return false;
				}
				result = true;
				break;
			}
			case 150:
			{
				int num3 = data[1];
				if (num3 >= HW.mZnNum[mFn] || num3 < 0)
				{
					return false;
				}
				int num4 = data[2] | (data[3] << 8) | (data[4] << 16) | (data[5] << 24);
				if (num4 < -25600 || num4 > 25600)
				{
					return false;
				}
				result = true;
				break;
			}
			case 185:
				if (!HW.mIsSanduanshi)
				{
					for (int i = 1; i <= 4; i++)
					{
						if ((data[i] & 0xFEu) != 0)
						{
							return false;
						}
					}
				}
				else
				{
					if (data[1] >> 5 != 0)
					{
						return false;
					}
					if (data[2] >> 3 != 0)
					{
						return false;
					}
				}
				result = true;
				break;
			}
			return result;
		}

		private void workaround_process_error(int comn, byte[] data)
		{
			bool flag = true;
			for (int i = 0; i < 6; i++)
			{
				if (data[i] != workaround_databuf[i])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				workaround_count++;
			}
			else
			{
				workaround_count = 0;
			}
			data.CopyTo(workaround_databuf, 0);
			if (workaround_count != 2)
			{
				return;
			}
			byte[] array = new byte[12];
			for (int j = 0; j < 6; j++)
			{
				int num = j;
				byte b;
				array[j + 6] = (b = data[j]);
				array[num] = b;
			}
			for (int num2 = 5; num2 > 0; num2--)
			{
				byte[] array2 = new byte[6];
				for (int k = 0; k < 6; k++)
				{
					array2[k] = array[k + num2];
				}
				if (workaround_is_valid_cmd(array2))
				{
					workaround_reseaved_extern_len(comn, 6 - num2);
					break;
				}
			}
		}

		private void ProcessData(byte[] data, int comn, int fn)
		{
			if (comn < 0 || comn >= mPortName.Count)
			{
				MessageBox.Show((USR_INIT.mLanguage == 2) ? "Comn counts is error, please check device type setting!" : ("comn数量有误，请检查机型是否正确 " + comn));
				return;
			}
			mMutexResearvedData.WaitOne();
			mResponseCheckCount++;
			byte[] array;
			if (sReserved[comn] != null && sReserved[comn].Length > 0)
			{
				array = new byte[data.Length + sReserved[comn].Length];
				sReserved[comn].CopyTo(array, 0);
				data.CopyTo(array, sReserved[comn].Length);
			}
			else
			{
				array = new byte[data.Length];
				data.CopyTo(array, 0);
			}
			if (array.Length % 6 != 0)
			{
				sReserved[comn] = new byte[array.Length - array.Length / 6 * 6];
				int num = 0;
				for (int i = array.Length / 6 * 6; i < array.Length; i++)
				{
					sReserved[comn][num] = array[i];
					num++;
				}
			}
			else
			{
				sReserved[comn] = new byte[0];
			}
			int num2 = array.Length / 6;
			for (int j = 0; j < num2; j++)
			{
				byte[] array2 = new byte[6];
				Buffer.BlockCopy(array, j * 6, array2, 0, 6);
				ProcessSingleData(array2, comn, fn);
			}
			mMutexResearvedData.ReleaseMutex();
		}

		public int tnfromCom(int comn)
		{
			int num = 0;
			num = mCom[comn].GetComType();
			if (num == 176 || num == 177)
			{
				return 1;
			}
			return 0;
		}

		private void ProcessSingleData(byte[] data, int comn, int fn)
		{
			if (data.Length != 6)
			{
				return;
			}
			bool flag = true;
			switch (data[0])
			{
			case 127:
				if (HW.mDeviceType == DeviceType.DSQ800_120F || HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E || HW.mDeviceType == DeviceType.DUDU_400 || HW.mDeviceType == DeviceType.DUDU_400_64FX || HW.mDeviceType == DeviceType.DUDU_400_50K)
				{
					if (data[1] == 1)
					{
						if (HW.mDeviceType == DeviceType.DSQ800_120F)
						{
							if (mComSubCmdTag[comn] == 160 || mComSubCmdTag[comn] == 162)
							{
								mResetState2[fn] = ResetState.Success;
								for (int i = 0; i < HW.mZnNum[fn]; i++)
								{
									mCur[fn].z[i] = 0;
									mCur[fn].a[i] = 0;
									mWaitZ[fn][i] = 0;
									mWaitA[fn][i] = 0;
								}
								write_to_logFile(mLogFileName, "F" + (fn + 1) + " " + comn.ToString("X") + ": ZA复位成功！" + Environment.NewLine);
							}
						}
						else if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
						{
							if (mComSubCmdTag[comn] == 160)
							{
								mResetState2[0] = ResetState.Success;
								for (int j = 0; j < HW.mZnNum[fn] / 2; j++)
								{
									mCur[fn].z[j] = 0;
									mCur[fn].a[j] = 0;
									mWaitZ[fn][j] = 0;
									mWaitA[fn][j] = 0;
								}
								write_to_logFile(mLogFileName, comn.ToString("X") + ": ZA复位成功！" + Environment.NewLine);
							}
							else if (mComSubCmdTag[comn] == 162)
							{
								mResetState2[1] = ResetState.Success;
								for (int k = HW.mZnNum[fn] / 2; k < HW.mZnNum[fn]; k++)
								{
									mCur[fn].z[k] = 0;
									mCur[fn].a[k] = 0;
									mWaitZ[fn][k] = 0;
									mWaitA[fn][k] = 0;
								}
								write_to_logFile(mLogFileName, comn.ToString("X") + ": ZA复位成功！" + Environment.NewLine);
							}
						}
						else if ((HW.mDeviceType == DeviceType.DUDU_400 || HW.mDeviceType == DeviceType.DUDU_400_64FX || HW.mDeviceType == DeviceType.DUDU_400_50K) && mComSubCmdTag[comn] == 160)
						{
							mResetState2[0] = ResetState.Success;
							for (int l = 0; l < HW.mZnNum[fn]; l++)
							{
								mCur[fn].z[l] = 0;
								mCur[fn].a[l] = 0;
								mWaitZ[fn][l] = 0;
								mWaitA[fn][l] = 0;
							}
							write_to_logFile(mLogFileName, comn.ToString("X") + ": ZA复位成功！" + Environment.NewLine);
						}
					}
					else if (data[1] == 2)
					{
						if (mComSubCmdTag[comn] == 160 || (HW.mDeviceType == DeviceType.DSQ800_120F && (mComSubCmdTag[comn] == 160 || mComSubCmdTag[comn] == 162)))
						{
							mResetState2[fn] = ResetState.Success;
							mCur[fn].x = mapping_x(fn, 0);
							mCur[fn].y = 0;
							mWaitXY[fn].X = mapping_x(fn, 0);
							mWaitXY[fn].Y = 0L;
							updateCoordinateXY(fn, mCur[fn].x, mCur[fn].y);
							write_to_logFile(mLogFileName, "F" + (fn + 1) + " " + comn.ToString("X") + ": XY复位成功！" + Environment.NewLine);
						}
					}
					else if (data[1] == 0 && (mComSubCmdTag[comn] == 160 || mComSubCmdTag[comn] == 162))
					{
						mCur[fn].x = mapping_x(fn, 0);
						mCur[fn].y = 0;
						mWaitXY[fn].X = mapping_x(fn, 0);
						mWaitXY[fn].Y = 0L;
						for (int m = 0; m < HW.mZnNum[fn]; m++)
						{
							mCur[fn].z[m] = 0;
							mCur[fn].a[m] = 0;
							mWaitZ[fn][m] = 0;
							mWaitA[fn][m] = 0;
						}
						bmIsConnected = true;
						updateConnectButton(bmIsConnected);
						updateCoordinateXY(fn, mCur[fn].x, mCur[fn].y);
						for (int n = 0; n < HW.mZnNum[fn]; n++)
						{
							updateCoordinateZ(fn, n, mCur[fn].z[n]);
							updateCoordinateA(fn, n, mCur[fn].a[n]);
						}
						write_to_logFile(mLogFileName, "复位成功！" + Environment.NewLine);
						mResetState2[fn] = ResetState.Success;
					}
				}
				else
				{
					mCur[fn].x = mapping_x(fn, 0);
					mCur[fn].y = 0;
					mWaitXY[fn].X = mapping_x(fn, 0);
					mWaitXY[fn].Y = 0L;
					for (int num5 = 0; num5 < HW.mZnNum[fn]; num5++)
					{
						mCur[fn].z[num5] = 0;
						mCur[fn].a[num5] = 0;
						mWaitZ[fn][num5] = 0;
						mWaitA[fn][num5] = 0;
					}
					bmIsConnected = true;
					updateConnectButton(bmIsConnected);
					updateCoordinateXY(fn, mCur[fn].x, mCur[fn].y);
					for (int num6 = 0; num6 < HW.mZnNum[fn]; num6++)
					{
						updateCoordinateZ(fn, num6, mCur[fn].z[num6]);
						updateCoordinateA(fn, num6, mCur[fn].a[num6]);
					}
					write_to_logFile(mLogFileName, "复位成功！" + Environment.NewLine);
					mResetState2[fn] = ResetState.Success;
				}
				break;
			case 122:
				if (HW.mDeviceType == DeviceType.DSQ800_120F || HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E || HW.mDeviceType == DeviceType.DUDU_400 || HW.mDeviceType == DeviceType.DUDU_400_64FX || HW.mDeviceType == DeviceType.DUDU_400_50K)
				{
					if (mComSubCmdTag[comn] == 160)
					{
						mResetState2[0] = ResetState.Fail;
						write_to_logFile(mLogFileName, comn.ToString("X") + ": 复位失败！" + Environment.NewLine);
					}
					else if (mComSubCmdTag[comn] == 162)
					{
						mResetState2[1] = ResetState.Fail;
						write_to_logFile(mLogFileName, comn.ToString("X") + ": 复位失败！" + Environment.NewLine);
					}
				}
				else
				{
					mResetState2[0] = ResetState.Fail;
					write_to_logFile(mLogFileName, "复位失败：0x7A" + Environment.NewLine);
				}
				break;
			case 96:
			case 224:
				if (HW.mSmtGenerationNo == 0 && HW.mZnNum[fn] == 4)
				{
					data[1] = 0;
				}
				mCur[fn].y = data[4] | (data[5] << 8) | ((data[1] & 0xF) << 16);
				mCur[fn].x = mapping_x(fn, data[2] | (data[3] << 8) | ((data[1] & 0xF0) << 12));
				updateCoordinateXY(fn, mCur[fn].x, mCur[fn].y);
				break;
			case 98:
			case 226:
			{
				int num10 = data[1];
				int num11 = data[2] | (data[3] << 8) | (data[4] << 16) | (data[5] << 24);
				if (HW.mSmtGenerationNo == 0)
				{
					if (num10 >= HW.mZnNum[fn] / 2 || num10 < 0)
					{
						string text2 = "信号接收:";
						text2 = text2 + "（主板号0x" + mCom[comn].GetComType().ToString("X2") + "） ";
						text2 = text2 + "zno = " + num10 + Environment.NewLine;
						write_to_logFile(mLogFileName, text2);
						flag = false;
						break;
					}
					if (num11 <= 0)
					{
						mCur[fn].z[num10 * 2] = num11;
						updateCoordinateZ(fn, num10 * 2, mCur[fn].z[num10 * 2]);
					}
					if (num11 >= 0)
					{
						mCur[fn].z[num10 * 2 + 1] = num11;
						updateCoordinateZ(fn, num10 * 2 + 1, mCur[fn].z[num10 * 2 + 1]);
					}
				}
				else
				{
					if (HW.mSmtGenerationNo != 2)
					{
						break;
					}
					if (num10 >= HW.mZnNum[fn] || num10 < 0)
					{
						string text3 = "信号接收:";
						text3 = text3 + "（主板号0x" + mCom[comn].GetComType().ToString("X2") + "） ";
						text3 = text3 + "zno = " + num10 + Environment.NewLine;
						write_to_logFile(mLogFileName, text3);
						flag = false;
						break;
					}
					num11 = Math.Abs(num11);
					if (num11 > HW.mMaxZ[fn])
					{
						num11 = HW.mMaxZ[fn];
						string text4 = "信号接收:";
						text4 = text4 + "（主板号0x" + mCom[comn].GetComType().ToString("X2") + "） ";
						text4 = text4 + "z_value = " + num11 + Environment.NewLine;
						write_to_logFile(mLogFileName, text4);
						flag = false;
					}
					else
					{
						if ((HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E) && mComSubCmdTag[comn] == 162)
						{
							num10 += 4;
						}
						mCur[fn].z[num10] = num11;
						updateCoordinateZ(fn, num10, mCur[fn].z[num10]);
					}
				}
				break;
			}
			case 22:
			case 150:
			{
				int num8 = data[1];
				if (num8 >= HW.mZnNum[fn] || num8 < 0)
				{
					string text = "信号接收:";
					text = text + "（主板号0x" + mCom[comn].GetComType().ToString("X2") + "） ";
					text = text + "ano = " + num8 + Environment.NewLine;
					write_to_logFile(mLogFileName, text);
					flag = false;
				}
				else
				{
					if ((HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E) && mComSubCmdTag[comn] == 162)
					{
						num8 += 4;
					}
					mCur[fn].a[num8] = data[2] | (data[3] << 8) | (data[4] << 16) | (data[5] << 24);
					updateCoordinateA(fn, num8, mCur[fn].a[num8]);
				}
				break;
			}
			case 48:
				if (!HW.mIsSanduanshi)
				{
					int num9 = 0;
					num9 |= data[2];
					num9 |= data[3] << 8;
					num9 |= data[4] << 16;
					switch (num9 | (data[5] << 24))
					{
					case 170:
						QnCommon.mInBoardState[0] = QnCommon.BoardStateEn.Fail;
						break;
					case 0:
						QnCommon.mInBoardState[0] = QnCommon.BoardStateEn.Ok;
						break;
					default:
						QnCommon.mInBoardState[0] = QnCommon.BoardStateEn.Unknown;
						break;
					}
				}
				break;
			case 49:
				if (!HW.mIsSanduanshi)
				{
					int num7 = 0;
					num7 |= data[2];
					num7 |= data[3] << 8;
					num7 |= data[4] << 16;
					switch (num7 | (data[5] << 24))
					{
					case 170:
						QnCommon.mOutBoardState[0] = QnCommon.BoardStateEn.Fail;
						break;
					case 0:
						QnCommon.mOutBoardState[0] = QnCommon.BoardStateEn.Ok;
						break;
					default:
						QnCommon.mOutBoardState[0] = QnCommon.BoardStateEn.Unknown;
						break;
					}
				}
				break;
			case 238:
				if (HW.mDeviceType == DeviceType.HW_8SX_1200 || HW.mDeviceType == DeviceType.HW_8SP_1200)
				{
					if ((data[2] & 0x10) == 0)
					{
						QnCommon.mInBoardState[0] = (QnCommon.BoardStateEn)(data[2] & 0xF);
					}
					else if ((data[2] & 0x10) == 16)
					{
						QnCommon.mOutBoardState[0] = (QnCommon.BoardStateEn)(data[2] & 0xF);
					}
				}
				else
				{
					if (!HW.mIsSanduanshi)
					{
						break;
					}
					if (data[1] != 0)
					{
						if ((data[1] & 0x10) == 0)
						{
							QnCommon.mInBoardState[0] = (QnCommon.BoardStateEn)(data[1] & 0xF);
						}
						else if ((data[1] & 0x10) == 16)
						{
							QnCommon.mOutBoardState[0] = (QnCommon.BoardStateEn)(data[1] & 0xF);
						}
					}
					if (HW.mDeviceType == DeviceType.DSQ800_120F && data[2] != 0)
					{
						if ((data[2] & 0x10) == 0)
						{
							QnCommon.mInBoardState[1] = (QnCommon.BoardStateEn)(data[2] & 0xF);
						}
						else if ((data[2] & 0x10) == 16)
						{
							QnCommon.mOutBoardState[1] = (QnCommon.BoardStateEn)(data[2] & 0xF);
						}
					}
				}
				break;
			case 185:
				if (HW.mDeviceType == DeviceType.HW_6_FLK)
				{
					QnCommon.mPlayWoodState_Sensor = data[1];
				}
				else if (!HW.mIsSanduanshi)
				{
					QnCommon.mPlayWoodState_Sensor = 0;
					QnCommon.mPlayWoodState_Sensor |= ((data[1] == 0) ? 2 : 0);
					QnCommon.mPlayWoodState_Sensor |= ((data[2] == 0) ? 4 : 0);
					QnCommon.mPlayWoodState_Sensor |= ((data[3] == 0) ? 8 : 0);
					QnCommon.mPlayWoodState_Sensor |= ((data[4] == 1) ? 16 : 0);
				}
				else
				{
					QnCommon.mPlayWoodState_Sensor = data[1];
					QnCommon.mPlayWoodState_Motor = data[2];
				}
				break;
			case 128:
			{
				int num = data[1];
				int num2 = data[2];
				int num3 = data[3];
				int num4 = data[4];
				int mComType = data[5];
				QnCommon.sBaseVersion = num + "." + num2 + "." + num3 + "." + num4;
				try
				{
					QnCommon.dDateVersion = new DateTime(2000 + num, num2, num3, 1, 0, 0);
				}
				catch (Exception)
				{
					write_to_logFile("EXCEPTION: 下位机版本号错误: " + QnCommon.sBaseVersion);
				}
				QnCommon.mVersionNum = num4;
				QnCommon.mComType = mComType;
				break;
			}
			case 80:
			case 208:
				mIsOpenShape_Enabled = true;
				QnCommon.mIsShapeOpen[fn] = ((data[5] == 0) ? true : false);
				if (QnCommon.mIsShapeOpen[fn] && USR_INIT.mIsOpenShapeStopRun)
				{
					MessageNoticeOpenShape(fn);
				}
				else
				{
					MessageNoticeCloseShapeEnd(fn);
				}
				break;
			case 81:
			case 209:
				if (HW.mDeviceType == DeviceType.HW_6)
				{
					QnCommon.mIsFeederGoodbye[fn] = ((data[5] == 0) ? true : false);
				}
				else if (HW.mDeviceType == DeviceType.HW_6S || HW.mDeviceType == DeviceType.HW_6SX)
				{
					QnCommon.mIsFeederGoodbye[fn] = ((data[1] == 0 || data[2] == 0) ? true : false);
				}
				else if (HW.mDeviceType == DeviceType.HW_8S || HW.mDeviceType == DeviceType.HW_8S_PLUS || HW.mDeviceType == DeviceType.HW_8SX || HW.mDeviceType == DeviceType.HW_8SX_72F)
				{
					QnCommon.mIsFeederGoodbye[fn] = ((data[1] == 0 || data[2] == 0) ? true : false);
				}
				else
				{
					if (HW.mDeviceType != DeviceType.DUDU_800 && HW.mDeviceType != DeviceType.DUDU_800_E && HW.mDeviceType != DeviceType.DUDU_400 && HW.mDeviceType != DeviceType.DUDU_400_64FX && HW.mDeviceType != DeviceType.DUDU_400_50K)
					{
						break;
					}
					QnCommon.mIsFeederGoodbye[fn] = ((data[1] == 0 || data[2] == 0) ? true : false);
				}
				if (QnCommon.mIsFeederGoodbye[fn] && !USR_INIT.mIsNotFeederGoodbye)
				{
					MessageNoticeFeederGoodbye(fn);
				}
				else
				{
					MessageNoticeFeederGoodbyeClearEnd(fn);
				}
				break;
			default:
				flag = false;
				break;
			case 170:
				break;
			}
			if (!flag)
			{
				string text5 = "信号接收:";
				if (data[0] != 16 && data[0] != 17 && data[0] != 172 && data[0] != 188)
				{
					text5 = "信号接收类型E:";
				}
				text5 = text5 + "（主板号0x" + mCom[comn].GetComType().ToString("X2") + "） ";
				string text6 = text5;
				text5 = text6 + "0x" + data[0].ToString("X2") + ",0x" + data[1].ToString("X2") + ",0x" + data[2].ToString("X2") + ",0x" + data[3].ToString("X2") + ",0x" + data[4].ToString("X2") + ",0x" + data[5].ToString("X2") + " " + Environment.NewLine;
				write_to_logFile(mLogFileName, text5);
				workaround_process_error(comn, data);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QIGN_MAIN.MainForm0));
			saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			radioBn_Z0 = new System.Windows.Forms.RadioButton();
			radioBn_Z1 = new System.Windows.Forms.RadioButton();
			radioBn_Z7 = new System.Windows.Forms.RadioButton();
			radioBn_Z2 = new System.Windows.Forms.RadioButton();
			radioBn_Z3 = new System.Windows.Forms.RadioButton();
			radioBn_Z4 = new System.Windows.Forms.RadioButton();
			radioBn_Z5 = new System.Windows.Forms.RadioButton();
			radioBn_Z6 = new System.Windows.Forms.RadioButton();
			tabpnl_dummy = new System.Windows.Forms.TableLayoutPanel();
			openFileDialog_componentfile = new System.Windows.Forms.OpenFileDialog();
			contextMenuStrip_pcbedit_cell = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem_fillmanual = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_fill0 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_fill1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_fill2 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_fill3 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_fill4 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_fill5 = new System.Windows.Forms.ToolStripMenuItem();
			label_projectname = new System.Windows.Forms.Label();
			contextMenuStrip_pcbcat_cell = new System.Windows.Forms.ContextMenuStrip(components);
			label_smtdevicetype = new System.Windows.Forms.Label();
			bindingSource1 = new System.Windows.Forms.BindingSource(components);
			contextMenuStrip_smtlist = new System.Windows.Forms.ContextMenuStrip(components);
			folderBrowserDialog_Para = new System.Windows.Forms.FolderBrowserDialog();
			panel_head = new System.Windows.Forms.Panel();
			label_hi_title = new System.Windows.Forms.Label();
			label_simulation = new System.Windows.Forms.Label();
			label_platform = new System.Windows.Forms.Label();
			panel_color = new System.Windows.Forms.Panel();
			trackBar_color_b = new System.Windows.Forms.TrackBar();
			trackBar_color_g = new System.Windows.Forms.TrackBar();
			trackBar_color_r = new System.Windows.Forms.TrackBar();
			panel_nozzle1 = new System.Windows.Forms.Panel();
			tabPage22 = new System.Windows.Forms.TabPage();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			panel_nozzle2 = new System.Windows.Forms.Panel();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton8 = new System.Windows.Forms.RadioButton();
			radioButton4 = new System.Windows.Forms.RadioButton();
			radioButton7 = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton6 = new System.Windows.Forms.RadioButton();
			tabControl_dsq = new System.Windows.Forms.TabControl();
			tabPage_dsq1F = new System.Windows.Forms.TabPage();
			tabPage_dsq2F = new System.Windows.Forms.TabPage();
			tabControl_temp = new System.Windows.Forms.TabControl();
			cnButton_AHD8Test = new QIGN_COMMON.vs_acontrol.CnButton();
			btn_Connect = new QIGN_COMMON.vs_acontrol.CnButton();
			btn_OpenCreateProject = new QIGN_COMMON.vs_acontrol.CnButton();
			cnButton_exit = new QIGN_COMMON.vs_acontrol.CnButton();
			button_minize = new QIGN_COMMON.vs_acontrol.CnButton();
			button_DeviceCalibraion = new QIGN_COMMON.vs_acontrol.CnButton();
			btn_FixedSetting = new QIGN_COMMON.vs_acontrol.CnButton();
			button_ProjectClose = new QIGN_COMMON.vs_acontrol.CnButton();
			contextMenuStrip_pcbedit_cell.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
			panel_head.SuspendLayout();
			panel_color.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_color_b).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_color_g).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar_color_r).BeginInit();
			panel_nozzle1.SuspendLayout();
			tabPage22.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			panel_nozzle2.SuspendLayout();
			tabControl_dsq.SuspendLayout();
			tabControl_temp.SuspendLayout();
			SuspendLayout();
			radioBn_Z0.Checked = true;
			radioBn_Z0.Font = new System.Drawing.Font("黑体", 12.25f);
			radioBn_Z0.Location = new System.Drawing.Point(3, 1);
			radioBn_Z0.Name = "radioBn_Z0";
			radioBn_Z0.Size = new System.Drawing.Size(83, 23);
			radioBn_Z0.TabIndex = 0;
			radioBn_Z0.TabStop = true;
			radioBn_Z0.Tag = "0";
			radioBn_Z0.Text = "吸嘴1";
			radioBn_Z0.UseVisualStyleBackColor = true;
			radioBn_Z0.CheckedChanged += new System.EventHandler(radioBn_Zn_CheckedChanged);
			radioBn_Z1.Font = new System.Drawing.Font("黑体", 12.25f);
			radioBn_Z1.Location = new System.Drawing.Point(92, 2);
			radioBn_Z1.Name = "radioBn_Z1";
			radioBn_Z1.Size = new System.Drawing.Size(83, 23);
			radioBn_Z1.TabIndex = 1;
			radioBn_Z1.Tag = "1";
			radioBn_Z1.Text = "吸嘴2";
			radioBn_Z1.UseVisualStyleBackColor = true;
			radioBn_Z1.CheckedChanged += new System.EventHandler(radioBn_Zn_CheckedChanged);
			radioBn_Z7.Font = new System.Drawing.Font("黑体", 12.25f);
			radioBn_Z7.Location = new System.Drawing.Point(626, 2);
			radioBn_Z7.Name = "radioBn_Z7";
			radioBn_Z7.Size = new System.Drawing.Size(83, 23);
			radioBn_Z7.TabIndex = 7;
			radioBn_Z7.Tag = "7";
			radioBn_Z7.Text = "吸嘴8";
			radioBn_Z7.UseVisualStyleBackColor = true;
			radioBn_Z7.CheckedChanged += new System.EventHandler(radioBn_Zn_CheckedChanged);
			radioBn_Z2.Font = new System.Drawing.Font("黑体", 12.25f);
			radioBn_Z2.Location = new System.Drawing.Point(181, 2);
			radioBn_Z2.Name = "radioBn_Z2";
			radioBn_Z2.Size = new System.Drawing.Size(83, 23);
			radioBn_Z2.TabIndex = 2;
			radioBn_Z2.Tag = "2";
			radioBn_Z2.Text = "吸嘴3";
			radioBn_Z2.UseVisualStyleBackColor = true;
			radioBn_Z2.CheckedChanged += new System.EventHandler(radioBn_Zn_CheckedChanged);
			radioBn_Z3.Font = new System.Drawing.Font("黑体", 12.25f);
			radioBn_Z3.Location = new System.Drawing.Point(270, 2);
			radioBn_Z3.Name = "radioBn_Z3";
			radioBn_Z3.Size = new System.Drawing.Size(83, 23);
			radioBn_Z3.TabIndex = 3;
			radioBn_Z3.Tag = "3";
			radioBn_Z3.Text = "吸嘴4";
			radioBn_Z3.UseVisualStyleBackColor = true;
			radioBn_Z3.CheckedChanged += new System.EventHandler(radioBn_Zn_CheckedChanged);
			radioBn_Z4.Font = new System.Drawing.Font("黑体", 12.25f);
			radioBn_Z4.Location = new System.Drawing.Point(359, 2);
			radioBn_Z4.Name = "radioBn_Z4";
			radioBn_Z4.Size = new System.Drawing.Size(83, 23);
			radioBn_Z4.TabIndex = 4;
			radioBn_Z4.Tag = "4";
			radioBn_Z4.Text = "吸嘴5";
			radioBn_Z4.UseVisualStyleBackColor = false;
			radioBn_Z4.CheckedChanged += new System.EventHandler(radioBn_Zn_CheckedChanged);
			radioBn_Z5.Font = new System.Drawing.Font("黑体", 12.25f);
			radioBn_Z5.Location = new System.Drawing.Point(448, 2);
			radioBn_Z5.Name = "radioBn_Z5";
			radioBn_Z5.Size = new System.Drawing.Size(83, 23);
			radioBn_Z5.TabIndex = 5;
			radioBn_Z5.Tag = "5";
			radioBn_Z5.Text = "吸嘴6";
			radioBn_Z5.UseVisualStyleBackColor = true;
			radioBn_Z5.CheckedChanged += new System.EventHandler(radioBn_Zn_CheckedChanged);
			radioBn_Z6.Font = new System.Drawing.Font("黑体", 12.25f);
			radioBn_Z6.Location = new System.Drawing.Point(537, 2);
			radioBn_Z6.Name = "radioBn_Z6";
			radioBn_Z6.Size = new System.Drawing.Size(83, 23);
			radioBn_Z6.TabIndex = 6;
			radioBn_Z6.Tag = "6";
			radioBn_Z6.Text = "吸嘴7";
			radioBn_Z6.UseVisualStyleBackColor = true;
			radioBn_Z6.CheckedChanged += new System.EventHandler(radioBn_Zn_CheckedChanged);
			tabpnl_dummy.Anchor = System.Windows.Forms.AnchorStyles.None;
			tabpnl_dummy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			tabpnl_dummy.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
			tabpnl_dummy.ColumnCount = 1;
			tabpnl_dummy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tabpnl_dummy.Location = new System.Drawing.Point(10573, 1492);
			tabpnl_dummy.Name = "tabpnl_dummy";
			tabpnl_dummy.RowCount = 1;
			tabpnl_dummy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tabpnl_dummy.Size = new System.Drawing.Size(87, 57);
			tabpnl_dummy.TabIndex = 4;
			openFileDialog_componentfile.FileName = "openFileDialog1";
			contextMenuStrip_pcbedit_cell.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { toolStripMenuItem_fillmanual, toolStripSeparator1, toolStripMenuItem_fill0, toolStripMenuItem_fill1, toolStripMenuItem_fill2, toolStripMenuItem_fill3, toolStripMenuItem_fill4, toolStripMenuItem_fill5 });
			contextMenuStrip_pcbedit_cell.Name = "contextMenuStrip_pcbedit_cell";
			contextMenuStrip_pcbedit_cell.Size = new System.Drawing.Size(137, 164);
			toolStripMenuItem_fillmanual.Name = "toolStripMenuItem_fillmanual";
			toolStripMenuItem_fillmanual.Size = new System.Drawing.Size(136, 22);
			toolStripMenuItem_fillmanual.Text = "手动填充";
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
			toolStripMenuItem_fill0.Name = "toolStripMenuItem_fill0";
			toolStripMenuItem_fill0.Size = new System.Drawing.Size(136, 22);
			toolStripMenuItem_fill0.Text = "填充：XXX";
			toolStripMenuItem_fill1.Name = "toolStripMenuItem_fill1";
			toolStripMenuItem_fill1.Size = new System.Drawing.Size(136, 22);
			toolStripMenuItem_fill1.Text = "填充：XXX";
			toolStripMenuItem_fill2.Name = "toolStripMenuItem_fill2";
			toolStripMenuItem_fill2.Size = new System.Drawing.Size(136, 22);
			toolStripMenuItem_fill2.Text = "填充：XXX";
			toolStripMenuItem_fill3.Name = "toolStripMenuItem_fill3";
			toolStripMenuItem_fill3.Size = new System.Drawing.Size(136, 22);
			toolStripMenuItem_fill3.Text = "填充：XXX";
			toolStripMenuItem_fill4.Name = "toolStripMenuItem_fill4";
			toolStripMenuItem_fill4.Size = new System.Drawing.Size(136, 22);
			toolStripMenuItem_fill4.Text = "填充：XXX";
			toolStripMenuItem_fill5.Name = "toolStripMenuItem_fill5";
			toolStripMenuItem_fill5.Size = new System.Drawing.Size(136, 22);
			toolStripMenuItem_fill5.Text = "填充：XXX";
			label_projectname.BackColor = System.Drawing.SystemColors.AppWorkspace;
			label_projectname.Font = new System.Drawing.Font("楷体", 11.5f);
			label_projectname.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			label_projectname.Location = new System.Drawing.Point(563, 56);
			label_projectname.Name = "label_projectname";
			label_projectname.Size = new System.Drawing.Size(698, 28);
			label_projectname.TabIndex = 70;
			label_projectname.Text = "工程：";
			label_projectname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			contextMenuStrip_pcbcat_cell.Name = "contextMenuStrip_pcbcat_cell";
			contextMenuStrip_pcbcat_cell.Size = new System.Drawing.Size(61, 4);
			label_smtdevicetype.BackColor = System.Drawing.Color.DimGray;
			label_smtdevicetype.Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_smtdevicetype.Location = new System.Drawing.Point(426, 56);
			label_smtdevicetype.Name = "label_smtdevicetype";
			label_smtdevicetype.Size = new System.Drawing.Size(126, 28);
			label_smtdevicetype.TabIndex = 155;
			label_smtdevicetype.Text = "授权成功";
			label_smtdevicetype.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			contextMenuStrip_smtlist.Name = "contextMenuStrip_smtlist";
			contextMenuStrip_smtlist.Size = new System.Drawing.Size(61, 4);
			panel_head.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
			panel_head.Controls.Add(cnButton_AHD8Test);
			panel_head.Controls.Add(btn_Connect);
			panel_head.Controls.Add(btn_OpenCreateProject);
			panel_head.Controls.Add(cnButton_exit);
			panel_head.Controls.Add(label_hi_title);
			panel_head.Controls.Add(label_simulation);
			panel_head.Controls.Add(button_minize);
			panel_head.Controls.Add(button_DeviceCalibraion);
			panel_head.Controls.Add(btn_FixedSetting);
			panel_head.Controls.Add(label_platform);
			panel_head.Controls.Add(button_ProjectClose);
			panel_head.Location = new System.Drawing.Point(7, 3);
			panel_head.Name = "panel_head";
			panel_head.Size = new System.Drawing.Size(1271, 48);
			panel_head.TabIndex = 166;
			label_hi_title.AutoSize = true;
			label_hi_title.Font = new System.Drawing.Font("黑体", 19.25f);
			label_hi_title.ForeColor = System.Drawing.Color.White;
			label_hi_title.Location = new System.Drawing.Point(131, 12);
			label_hi_title.Name = "label_hi_title";
			label_hi_title.Size = new System.Drawing.Size(233, 26);
			label_hi_title.TabIndex = 160;
			label_hi_title.Text = "华维国创 智控系统";
			label_simulation.BackColor = System.Drawing.Color.MediumVioletRed;
			label_simulation.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_simulation.ForeColor = System.Drawing.Color.White;
			label_simulation.Location = new System.Drawing.Point(454, 5);
			label_simulation.Name = "label_simulation";
			label_simulation.Size = new System.Drawing.Size(42, 40);
			label_simulation.TabIndex = 159;
			label_simulation.Text = "仿真";
			label_simulation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_simulation.Visible = false;
			label_platform.Font = new System.Drawing.Font("黑体", 14f);
			label_platform.ForeColor = System.Drawing.Color.White;
			label_platform.Location = new System.Drawing.Point(1136, 4);
			label_platform.Name = "label_platform";
			label_platform.Size = new System.Drawing.Size(43, 40);
			label_platform.TabIndex = 155;
			label_platform.Text = "32";
			label_platform.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_color.BackColor = System.Drawing.Color.DarkGray;
			panel_color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_color.Controls.Add(trackBar_color_b);
			panel_color.Controls.Add(trackBar_color_g);
			panel_color.Controls.Add(trackBar_color_r);
			panel_color.Location = new System.Drawing.Point(517, 58);
			panel_color.Name = "panel_color";
			panel_color.Size = new System.Drawing.Size(125, 65);
			panel_color.TabIndex = 100;
			panel_color.Visible = false;
			trackBar_color_b.Location = new System.Drawing.Point(-4, 39);
			trackBar_color_b.Maximum = 255;
			trackBar_color_b.Name = "trackBar_color_b";
			trackBar_color_b.Size = new System.Drawing.Size(129, 45);
			trackBar_color_b.TabIndex = 0;
			trackBar_color_b.Tag = "0";
			trackBar_color_b.TickFrequency = 10;
			trackBar_color_g.Location = new System.Drawing.Point(-4, 19);
			trackBar_color_g.Maximum = 255;
			trackBar_color_g.Name = "trackBar_color_g";
			trackBar_color_g.Size = new System.Drawing.Size(129, 45);
			trackBar_color_g.TabIndex = 0;
			trackBar_color_g.Tag = "1";
			trackBar_color_g.TickFrequency = 10;
			trackBar_color_r.Location = new System.Drawing.Point(-4, -1);
			trackBar_color_r.Maximum = 255;
			trackBar_color_r.Name = "trackBar_color_r";
			trackBar_color_r.Size = new System.Drawing.Size(129, 45);
			trackBar_color_r.TabIndex = 0;
			trackBar_color_r.Tag = "0";
			trackBar_color_r.TickFrequency = 10;
			panel_nozzle1.BackColor = System.Drawing.Color.LightSteelBlue;
			panel_nozzle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_nozzle1.Controls.Add(radioBn_Z0);
			panel_nozzle1.Controls.Add(radioBn_Z1);
			panel_nozzle1.Controls.Add(radioBn_Z7);
			panel_nozzle1.Controls.Add(radioBn_Z6);
			panel_nozzle1.Controls.Add(radioBn_Z2);
			panel_nozzle1.Controls.Add(radioBn_Z5);
			panel_nozzle1.Controls.Add(radioBn_Z3);
			panel_nozzle1.Controls.Add(radioBn_Z4);
			panel_nozzle1.Location = new System.Drawing.Point(18, 196);
			panel_nozzle1.Name = "panel_nozzle1";
			panel_nozzle1.Size = new System.Drawing.Size(710, 29);
			panel_nozzle1.TabIndex = 156;
			tabPage22.Controls.Add(tabControl1);
			tabPage22.Location = new System.Drawing.Point(4, 28);
			tabPage22.Name = "tabPage22";
			tabPage22.Padding = new System.Windows.Forms.Padding(3);
			tabPage22.Size = new System.Drawing.Size(764, 995);
			tabPage22.TabIndex = 10;
			tabPage22.Text = "PCBE";
			tabPage22.UseVisualStyleBackColor = true;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Location = new System.Drawing.Point(1, 2);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(757, 419);
			tabControl1.TabIndex = 0;
			tabPage1.Controls.Add(panel_nozzle1);
			tabPage1.Controls.Add(panel_color);
			tabPage1.Controls.Add(panel_nozzle2);
			tabPage1.Controls.Add(tabControl_dsq);
			tabPage1.Location = new System.Drawing.Point(4, 28);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(749, 387);
			tabPage1.TabIndex = 13;
			tabPage1.Text = "大杀器";
			tabPage1.UseVisualStyleBackColor = true;
			panel_nozzle2.BackColor = System.Drawing.Color.LightSteelBlue;
			panel_nozzle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_nozzle2.Controls.Add(radioButton1);
			panel_nozzle2.Controls.Add(radioButton2);
			panel_nozzle2.Controls.Add(radioButton3);
			panel_nozzle2.Controls.Add(radioButton8);
			panel_nozzle2.Controls.Add(radioButton4);
			panel_nozzle2.Controls.Add(radioButton7);
			panel_nozzle2.Controls.Add(radioButton5);
			panel_nozzle2.Controls.Add(radioButton6);
			panel_nozzle2.Location = new System.Drawing.Point(18, 243);
			panel_nozzle2.Name = "panel_nozzle2";
			panel_nozzle2.Size = new System.Drawing.Size(710, 28);
			panel_nozzle2.TabIndex = 157;
			radioButton1.Checked = true;
			radioButton1.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton1.Location = new System.Drawing.Point(4, -2);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(73, 23);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Tag = "0";
			radioButton1.Text = "吸嘴1";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton2.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton2.Location = new System.Drawing.Point(88, -2);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(82, 23);
			radioButton2.TabIndex = 1;
			radioButton2.Tag = "1";
			radioButton2.Text = "吸嘴2";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton3.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton3.Location = new System.Drawing.Point(622, -2);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(81, 23);
			radioButton3.TabIndex = 7;
			radioButton3.Tag = "7";
			radioButton3.Text = "吸嘴8";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton8.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton8.Location = new System.Drawing.Point(533, -2);
			radioButton8.Name = "radioButton8";
			radioButton8.Size = new System.Drawing.Size(82, 23);
			radioButton8.TabIndex = 6;
			radioButton8.Tag = "6";
			radioButton8.Text = "吸嘴7";
			radioButton8.UseVisualStyleBackColor = true;
			radioButton4.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton4.Location = new System.Drawing.Point(177, -2);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(82, 23);
			radioButton4.TabIndex = 2;
			radioButton4.Tag = "2";
			radioButton4.Text = "吸嘴3";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton7.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton7.Location = new System.Drawing.Point(444, -2);
			radioButton7.Name = "radioButton7";
			radioButton7.Size = new System.Drawing.Size(79, 23);
			radioButton7.TabIndex = 5;
			radioButton7.Tag = "5";
			radioButton7.Text = "吸嘴6";
			radioButton7.UseVisualStyleBackColor = true;
			radioButton5.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton5.Location = new System.Drawing.Point(266, -2);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(79, 23);
			radioButton5.TabIndex = 3;
			radioButton5.Tag = "3";
			radioButton5.Text = "吸嘴4";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton6.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			radioButton6.Location = new System.Drawing.Point(355, -2);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new System.Drawing.Size(77, 23);
			radioButton6.TabIndex = 4;
			radioButton6.Tag = "4";
			radioButton6.Text = "吸嘴5";
			radioButton6.UseVisualStyleBackColor = false;
			tabControl_dsq.Controls.Add(tabPage_dsq1F);
			tabControl_dsq.Controls.Add(tabPage_dsq2F);
			tabControl_dsq.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			tabControl_dsq.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			tabControl_dsq.ItemSize = new System.Drawing.Size(160, 26);
			tabControl_dsq.Location = new System.Drawing.Point(19, 26);
			tabControl_dsq.Name = "tabControl_dsq";
			tabControl_dsq.RightToLeft = System.Windows.Forms.RightToLeft.No;
			tabControl_dsq.SelectedIndex = 0;
			tabControl_dsq.Size = new System.Drawing.Size(350, 162);
			tabControl_dsq.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tabControl_dsq.TabIndex = 0;
			tabControl_dsq.DrawItem += new System.Windows.Forms.DrawItemEventHandler(tabControl_dsq_DrawItem);
			tabControl_dsq.SelectedIndexChanged += new System.EventHandler(tabControl_dsq_SelectedIndexChanged);
			tabPage_dsq1F.Font = new System.Drawing.Font("黑体", 13.25f, System.Drawing.FontStyle.Bold);
			tabPage_dsq1F.Location = new System.Drawing.Point(4, 30);
			tabPage_dsq1F.Name = "tabPage_dsq1F";
			tabPage_dsq1F.Padding = new System.Windows.Forms.Padding(3);
			tabPage_dsq1F.Size = new System.Drawing.Size(342, 128);
			tabPage_dsq1F.TabIndex = 0;
			tabPage_dsq1F.Text = "DSQ800-左机";
			tabPage_dsq1F.UseVisualStyleBackColor = true;
			tabPage_dsq2F.Font = new System.Drawing.Font("黑体", 13.25f, System.Drawing.FontStyle.Bold);
			tabPage_dsq2F.Location = new System.Drawing.Point(4, 30);
			tabPage_dsq2F.Name = "tabPage_dsq2F";
			tabPage_dsq2F.Padding = new System.Windows.Forms.Padding(3);
			tabPage_dsq2F.Size = new System.Drawing.Size(342, 128);
			tabPage_dsq2F.TabIndex = 1;
			tabPage_dsq2F.Text = "DSQ800-右机";
			tabPage_dsq2F.UseVisualStyleBackColor = true;
			tabControl_temp.Controls.Add(tabPage22);
			tabControl_temp.Font = new System.Drawing.Font("微软雅黑", 11.25f, System.Drawing.FontStyle.Bold);
			tabControl_temp.Location = new System.Drawing.Point(563, 98);
			tabControl_temp.Name = "tabControl_temp";
			tabControl_temp.SelectedIndex = 0;
			tabControl_temp.Size = new System.Drawing.Size(772, 1027);
			tabControl_temp.TabIndex = 153;
			cnButton_AHD8Test.BackColor = System.Drawing.Color.LightGray;
			cnButton_AHD8Test.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_AHD8Test.CnPressDownColor = System.Drawing.Color.White;
			cnButton_AHD8Test.Location = new System.Drawing.Point(16, 13);
			cnButton_AHD8Test.Name = "cnButton_AHD8Test";
			cnButton_AHD8Test.Size = new System.Drawing.Size(75, 23);
			cnButton_AHD8Test.TabIndex = 167;
			cnButton_AHD8Test.Text = "AHD8_Test";
			cnButton_AHD8Test.UseVisualStyleBackColor = false;
			cnButton_AHD8Test.Visible = false;
			cnButton_AHD8Test.Click += new System.EventHandler(cnButton_AHD8Test_Click);
			btn_Connect.BackColor = System.Drawing.Color.Tomato;
			btn_Connect.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.PressDown;
			btn_Connect.CnPressDownColor = System.Drawing.Color.Red;
			btn_Connect.Font = new System.Drawing.Font("黑体", 13f);
			btn_Connect.ForeColor = System.Drawing.Color.White;
			btn_Connect.Location = new System.Drawing.Point(556, 9);
			btn_Connect.Name = "btn_Connect";
			btn_Connect.Size = new System.Drawing.Size(146, 32);
			btn_Connect.TabIndex = 1;
			btn_Connect.Text = "连接设备";
			btn_Connect.UseVisualStyleBackColor = false;
			btn_Connect.Click += new System.EventHandler(btn_Connect_Click);
			btn_OpenCreateProject.BackColor = System.Drawing.Color.DimGray;
			btn_OpenCreateProject.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			btn_OpenCreateProject.CnPressDownColor = System.Drawing.Color.White;
			btn_OpenCreateProject.Enabled = false;
			btn_OpenCreateProject.Font = new System.Drawing.Font("黑体", 13f);
			btn_OpenCreateProject.ForeColor = System.Drawing.Color.White;
			btn_OpenCreateProject.Location = new System.Drawing.Point(707, 9);
			btn_OpenCreateProject.Name = "btn_OpenCreateProject";
			btn_OpenCreateProject.Size = new System.Drawing.Size(106, 32);
			btn_OpenCreateProject.TabIndex = 1;
			btn_OpenCreateProject.Text = "工程文件";
			btn_OpenCreateProject.UseVisualStyleBackColor = false;
			btn_OpenCreateProject.Click += new System.EventHandler(btn_Project_Click);
			cnButton_exit.BackColor = System.Drawing.Color.WhiteSmoke;
			cnButton_exit.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			cnButton_exit.CnPressDownColor = System.Drawing.Color.White;
			cnButton_exit.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cnButton_exit.Location = new System.Drawing.Point(1224, 12);
			cnButton_exit.Name = "cnButton_exit";
			cnButton_exit.Size = new System.Drawing.Size(40, 22);
			cnButton_exit.TabIndex = 161;
			cnButton_exit.Text = "X";
			cnButton_exit.UseVisualStyleBackColor = false;
			cnButton_exit.Click += new System.EventHandler(cnButton_exit_Click);
			button_minize.BackColor = System.Drawing.Color.WhiteSmoke;
			button_minize.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_minize.CnPressDownColor = System.Drawing.Color.White;
			button_minize.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button_minize.Location = new System.Drawing.Point(1179, 12);
			button_minize.Name = "button_minize";
			button_minize.Size = new System.Drawing.Size(40, 22);
			button_minize.TabIndex = 157;
			button_minize.Text = "-";
			button_minize.UseVisualStyleBackColor = false;
			button_minize.Click += new System.EventHandler(button_minize_Click);
			button_DeviceCalibraion.BackColor = System.Drawing.Color.DimGray;
			button_DeviceCalibraion.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_DeviceCalibraion.CnPressDownColor = System.Drawing.Color.White;
			button_DeviceCalibraion.Enabled = false;
			button_DeviceCalibraion.Font = new System.Drawing.Font("黑体", 13f);
			button_DeviceCalibraion.ForeColor = System.Drawing.Color.White;
			button_DeviceCalibraion.Location = new System.Drawing.Point(1034, 9);
			button_DeviceCalibraion.Name = "button_DeviceCalibraion";
			button_DeviceCalibraion.Size = new System.Drawing.Size(106, 32);
			button_DeviceCalibraion.TabIndex = 156;
			button_DeviceCalibraion.Text = "机器校准";
			button_DeviceCalibraion.UseVisualStyleBackColor = false;
			button_DeviceCalibraion.Click += new System.EventHandler(button_DeviceCalibraion_Click);
			btn_FixedSetting.BackColor = System.Drawing.Color.DimGray;
			btn_FixedSetting.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			btn_FixedSetting.CnPressDownColor = System.Drawing.Color.White;
			btn_FixedSetting.Font = new System.Drawing.Font("黑体", 13f);
			btn_FixedSetting.ForeColor = System.Drawing.Color.White;
			btn_FixedSetting.Location = new System.Drawing.Point(925, 9);
			btn_FixedSetting.Name = "btn_FixedSetting";
			btn_FixedSetting.Size = new System.Drawing.Size(106, 32);
			btn_FixedSetting.TabIndex = 1;
			btn_FixedSetting.Text = "系统参数";
			btn_FixedSetting.UseVisualStyleBackColor = false;
			btn_FixedSetting.Click += new System.EventHandler(btn_FixedSetting_Click);
			button_ProjectClose.BackColor = System.Drawing.Color.DimGray;
			button_ProjectClose.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button_ProjectClose.CnPressDownColor = System.Drawing.Color.White;
			button_ProjectClose.Enabled = false;
			button_ProjectClose.Font = new System.Drawing.Font("黑体", 13f);
			button_ProjectClose.ForeColor = System.Drawing.Color.White;
			button_ProjectClose.Location = new System.Drawing.Point(816, 9);
			button_ProjectClose.Name = "button_ProjectClose";
			button_ProjectClose.Size = new System.Drawing.Size(106, 32);
			button_ProjectClose.TabIndex = 2;
			button_ProjectClose.Text = "关闭工程";
			button_ProjectClose.UseVisualStyleBackColor = false;
			button_ProjectClose.Click += new System.EventHandler(button_ProjectClose_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(1694, 997);
			base.Controls.Add(tabControl_temp);
			base.Controls.Add(panel_head);
			base.Controls.Add(label_projectname);
			base.Controls.Add(tabpnl_dummy);
			base.Controls.Add(label_smtdevicetype);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("黑体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "MainForm0";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "北京华维国创电子科技有限公司 贴片机控制系统 2018智能版";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormMain_Closing);
			base.Load += new System.EventHandler(FormMain_Load);
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(MainForm0_KeyDown);
			contextMenuStrip_pcbedit_cell.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
			panel_head.ResumeLayout(false);
			panel_head.PerformLayout();
			panel_color.ResumeLayout(false);
			panel_color.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_color_b).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_color_g).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar_color_r).EndInit();
			panel_nozzle1.ResumeLayout(false);
			tabPage22.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			panel_nozzle2.ResumeLayout(false);
			tabControl_dsq.ResumeLayout(false);
			tabControl_temp.ResumeLayout(false);
			ResumeLayout(false);
		}

		public static bool pcblist_to_cat(int fn)
		{
			bool result = false;
			bool flag = false;
			if (USR3B[fn].mPointlistCat == null)
			{
				USR3B[fn].mPointlistCat = new BindingList<ChipCategoryElement>();
			}
			BindingList<ChipCategoryElement> bindingList = new BindingList<ChipCategoryElement>();
			for (int i = 0; i < USR3B[fn].mPointlistCat.Count; i++)
			{
				bindingList.Add(USR3B[fn].mPointlistCat[i]);
			}
			USR3B[fn].mPointlistCat.Clear();
			for (int j = 0; j < U3[fn].Count; j++)
			{
				USR3_DATA uSR3_DATA = U3[fn][j];
				if (uSR3_DATA == null || uSR3_DATA.mPointlist == null)
				{
					continue;
				}
				if (uSR3_DATA.mPointlistCat == null)
				{
					uSR3_DATA.mPointlistCat = new BindingList<ChipCategoryElement>();
				}
				uSR3_DATA.mPointlistCat.Clear();
				for (int k = 0; k < uSR3_DATA.mPointlist.Count; k++)
				{
					bool flag2 = false;
					for (int l = 0; l < uSR3_DATA.mPointlistCat.Count; l++)
					{
						if (!(uSR3_DATA.mPointlist[k].Material_value == uSR3_DATA.mPointlistCat[l].Material_value) || !(uSR3_DATA.mPointlist[k].Footprint == uSR3_DATA.mPointlistCat[l].Footprint))
						{
							continue;
						}
						uSR3_DATA.mPointlistCat[l].Count++;
						if (uSR3_DATA.mPointlist[k].Feedertype != uSR3_DATA.mPointlistCat[l].Feedertype)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Feedertype = FeederType.N_A;
						}
						if (uSR3_DATA.mPointlist[k].Nozzletype != uSR3_DATA.mPointlistCat[l].Nozzletype0)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Nozzletype0 = (uSR3_DATA.mPointlistCat[l].Nozzletype1 = -1);
						}
						if (uSR3_DATA.mPointlist[k].Cameratype != uSR3_DATA.mPointlistCat[l].Cameratype)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Cameratype = CameraType.N_A;
						}
						if (uSR3_DATA.mPointlist[k].Visualtype != uSR3_DATA.mPointlistCat[l].Visualtype)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Visualtype = VisualType.N_A;
						}
						if (uSR3_DATA.mPointlist[k].Looptype != uSR3_DATA.mPointlistCat[l].Looptype)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Looptype = LoopType.N_A;
						}
						if (uSR3_DATA.mPointlist[k].sampik_delta != uSR3_DATA.mPointlistCat[l].Delta)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Delta = 0.5f;
						}
						if (uSR3_DATA.mPointlist[k].scanR != uSR3_DATA.mPointlistCat[l].scan_r)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].scan_r = 0f;
						}
						if (uSR3_DATA.mPointlist[k].threshold != uSR3_DATA.mPointlistCat[l].threshold)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].threshold = 0;
						}
						if (uSR3_DATA.mPointlist[k].length != uSR3_DATA.mPointlistCat[l].Lenght)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Lenght = 0f;
						}
						if (uSR3_DATA.mPointlist[k].width != uSR3_DATA.mPointlistCat[l].Width)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Width = 0f;
						}
						if (uSR3_DATA.mPointlist[k].height != uSR3_DATA.mPointlistCat[l].Height)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].Height = 0f;
						}
						if (uSR3_DATA.mPointlist[k].is_collect != uSR3_DATA.mPointlistCat[l].is_collect)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].is_collect = false;
						}
						if (uSR3_DATA.mPointlist[k].collectdelta != uSR3_DATA.mPointlistCat[l].collectdelta)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].collectdelta = 30f;
						}
						if (uSR3_DATA.mPointlist[k].pik_h_offset != uSR3_DATA.mPointlistCat[l].pik_h_offset)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].pik_h_offset = 1f;
						}
						if (uSR3_DATA.mPointlist[k].mnt_h_offset != uSR3_DATA.mPointlistCat[l].mnt_h_offset)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].mnt_h_offset = 1f;
						}
						if (uSR3_DATA.mPointlist[k].zup_speed != uSR3_DATA.mPointlistCat[l].zup_speed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].zup_speed = 0;
						}
						if (uSR3_DATA.mPointlist[k].zdown_speed != uSR3_DATA.mPointlistCat[l].zdown_speed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].zdown_speed = 0;
						}
						if (uSR3_DATA.mPointlist[k].zpik_delay != uSR3_DATA.mPointlistCat[l].zpik_delay)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].zpik_delay = 0f;
						}
						if (uSR3_DATA.mPointlist[k].zmnt_up_speed != uSR3_DATA.mPointlistCat[l].zmnt_up_speed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].zmnt_up_speed = 0;
						}
						if (uSR3_DATA.mPointlist[k].zmnt_down_speed != uSR3_DATA.mPointlistCat[l].zmnt_down_speed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].zmnt_down_speed = 0;
						}
						if (uSR3_DATA.mPointlist[k].zmnt_delay != uSR3_DATA.mPointlistCat[l].zmnt_delay)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].zmnt_delay = 0f;
						}
						if (uSR3_DATA.mPointlist[k].IsLowSpeed != uSR3_DATA.mPointlistCat[l].IsLowSpeed)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].IsLowSpeed = false;
						}
						if (uSR3_DATA.mPointlist[k].is_high != uSR3_DATA.mPointlistCat[l].is_high)
						{
							result = true;
							uSR3_DATA.mPointlistCat[l].is_high = false;
						}
						bool flag3 = false;
						for (int m = 0; m < uSR3_DATA.mPointlistCat[l].MultiFeeders; m++)
						{
							if (uSR3_DATA.mPointlist[k].Stack_no == uSR3_DATA.mPointlistCat[l].feeder_no[m])
							{
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							if (uSR3_DATA.mPointlistCat[l].MultiFeeders < HW.mMaxMultiFeederNum[mFn])
							{
								uSR3_DATA.mPointlistCat[l].feeder_no[uSR3_DATA.mPointlistCat[l].MultiFeeders] = uSR3_DATA.mPointlist[k].Stack_no;
								uSR3_DATA.mPointlistCat[l].MultiFeeders++;
							}
							else
							{
								flag = true;
							}
						}
						flag2 = true;
					}
					if (!flag2)
					{
						ChipCategoryElement chipCategoryElement = new ChipCategoryElement(USR_INIT.mLanguage);
						chipCategoryElement.Material_value = uSR3_DATA.mPointlist[k].Material_value;
						chipCategoryElement.Footprint = uSR3_DATA.mPointlist[k].Footprint;
						chipCategoryElement.Count = 1;
						chipCategoryElement.Feedertype = uSR3_DATA.mPointlist[k].Feedertype;
						chipCategoryElement.Nozzletype0 = uSR3_DATA.mPointlist[k].Nozzletype;
						chipCategoryElement.Nozzletype1 = uSR3_DATA.mPointlist[k].Nozzletype;
						chipCategoryElement.Cameratype = uSR3_DATA.mPointlist[k].Cameratype;
						chipCategoryElement.Visualtype = uSR3_DATA.mPointlist[k].Visualtype;
						chipCategoryElement.Looptype = uSR3_DATA.mPointlist[k].Looptype;
						chipCategoryElement.Delta = uSR3_DATA.mPointlist[k].sampik_delta;
						chipCategoryElement.scan_r = uSR3_DATA.mPointlist[k].scanR;
						chipCategoryElement.threshold = uSR3_DATA.mPointlist[k].threshold;
						chipCategoryElement.Lenght = uSR3_DATA.mPointlist[k].length;
						chipCategoryElement.Width = uSR3_DATA.mPointlist[k].width;
						chipCategoryElement.Height = uSR3_DATA.mPointlist[k].height;
						chipCategoryElement.is_collect = uSR3_DATA.mPointlist[k].is_collect;
						chipCategoryElement.collectdelta = uSR3_DATA.mPointlist[k].collectdelta;
						chipCategoryElement.pik_h_offset = uSR3_DATA.mPointlist[k].pik_h_offset;
						chipCategoryElement.mnt_h_offset = uSR3_DATA.mPointlist[k].mnt_h_offset;
						chipCategoryElement.zup_speed = uSR3_DATA.mPointlist[k].zup_speed;
						chipCategoryElement.zdown_speed = uSR3_DATA.mPointlist[k].zdown_speed;
						chipCategoryElement.zpik_delay = uSR3_DATA.mPointlist[k].zpik_delay;
						chipCategoryElement.zmnt_up_speed = uSR3_DATA.mPointlist[k].zmnt_up_speed;
						chipCategoryElement.zmnt_down_speed = uSR3_DATA.mPointlist[k].zmnt_down_speed;
						chipCategoryElement.zmnt_delay = uSR3_DATA.mPointlist[k].zmnt_delay;
						chipCategoryElement.is_high = uSR3_DATA.mPointlist[k].is_high;
						chipCategoryElement.IsLowSpeed = uSR3_DATA.mPointlist[k].IsLowSpeed;
						chipCategoryElement.MultiFeeders = 1;
						chipCategoryElement.feeder_no[0] = uSR3_DATA.mPointlist[k].Stack_no;
						uSR3_DATA.mPointlistCat.Add(chipCategoryElement);
					}
					flag2 = false;
					for (int n = 0; n < USR3B[fn].mPointlistCat.Count; n++)
					{
						if (!(uSR3_DATA.mPointlist[k].Material_value == USR3B[fn].mPointlistCat[n].Material_value) || !(uSR3_DATA.mPointlist[k].Footprint == USR3B[fn].mPointlistCat[n].Footprint))
						{
							continue;
						}
						USR3B[fn].mPointlistCat[n].Count++;
						if (uSR3_DATA.mPointlist[k].Feedertype != USR3B[fn].mPointlistCat[n].Feedertype)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Feedertype = FeederType.N_A;
						}
						if (uSR3_DATA.mPointlist[k].Nozzletype != USR3B[fn].mPointlistCat[n].Nozzletype0)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Nozzletype0 = (USR3B[fn].mPointlistCat[n].Nozzletype1 = -1);
						}
						if (uSR3_DATA.mPointlist[k].Cameratype != USR3B[fn].mPointlistCat[n].Cameratype)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Cameratype = CameraType.N_A;
						}
						if (uSR3_DATA.mPointlist[k].Visualtype != USR3B[fn].mPointlistCat[n].Visualtype)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Visualtype = VisualType.N_A;
						}
						if (uSR3_DATA.mPointlist[k].Looptype != USR3B[fn].mPointlistCat[n].Looptype)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Looptype = LoopType.N_A;
						}
						if (uSR3_DATA.mPointlist[k].sampik_delta != USR3B[fn].mPointlistCat[n].Delta)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Delta = 0.5f;
						}
						if (uSR3_DATA.mPointlist[k].scanR != USR3B[fn].mPointlistCat[n].scan_r)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].scan_r = 0f;
						}
						if (uSR3_DATA.mPointlist[k].threshold != USR3B[fn].mPointlistCat[n].threshold)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].threshold = 0;
						}
						if (uSR3_DATA.mPointlist[k].length != USR3B[fn].mPointlistCat[n].Lenght)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Lenght = 0f;
						}
						if (uSR3_DATA.mPointlist[k].width != USR3B[fn].mPointlistCat[n].Width)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Width = 0f;
						}
						if (uSR3_DATA.mPointlist[k].height != USR3B[fn].mPointlistCat[n].Height)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].Height = 0f;
						}
						if (uSR3_DATA.mPointlist[k].is_collect != USR3B[fn].mPointlistCat[n].is_collect)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].is_collect = false;
						}
						if (uSR3_DATA.mPointlist[k].collectdelta != USR3B[fn].mPointlistCat[n].collectdelta)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].collectdelta = 30f;
						}
						if (uSR3_DATA.mPointlist[k].pik_h_offset != USR3B[fn].mPointlistCat[n].pik_h_offset)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].pik_h_offset = 1f;
						}
						if (uSR3_DATA.mPointlist[k].mnt_h_offset != USR3B[fn].mPointlistCat[n].mnt_h_offset)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].mnt_h_offset = 1f;
						}
						if (uSR3_DATA.mPointlist[k].zup_speed != USR3B[fn].mPointlistCat[n].zup_speed)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].zup_speed = 0;
						}
						if (uSR3_DATA.mPointlist[k].zdown_speed != USR3B[fn].mPointlistCat[n].zdown_speed)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].zdown_speed = 0;
						}
						if (uSR3_DATA.mPointlist[k].zpik_delay != USR3B[fn].mPointlistCat[n].zpik_delay)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].zpik_delay = 0f;
						}
						if (uSR3_DATA.mPointlist[k].zmnt_up_speed != USR3B[fn].mPointlistCat[n].zmnt_up_speed)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].zmnt_up_speed = 0;
						}
						if (uSR3_DATA.mPointlist[k].zmnt_down_speed != USR3B[fn].mPointlistCat[n].zmnt_down_speed)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].zmnt_down_speed = 0;
						}
						if (uSR3_DATA.mPointlist[k].zmnt_delay != USR3B[fn].mPointlistCat[n].zmnt_delay)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].zmnt_delay = 0f;
						}
						if (uSR3_DATA.mPointlist[k].IsLowSpeed != USR3B[fn].mPointlistCat[n].IsLowSpeed)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].IsLowSpeed = false;
						}
						if (uSR3_DATA.mPointlist[k].is_high != USR3B[fn].mPointlistCat[n].is_high)
						{
							result = true;
							USR3B[fn].mPointlistCat[n].is_high = false;
						}
						bool flag4 = false;
						for (int num = 0; num < USR3B[fn].mPointlistCat[n].MultiFeeders; num++)
						{
							if (uSR3_DATA.mPointlist[k].Stack_no == USR3B[fn].mPointlistCat[n].feeder_no[num])
							{
								flag4 = true;
								break;
							}
						}
						if (!flag4)
						{
							if (USR3B[fn].mPointlistCat[n].MultiFeeders < HW.mMaxMultiFeederNum[mFn])
							{
								USR3B[fn].mPointlistCat[n].feeder_no[USR3B[fn].mPointlistCat[n].MultiFeeders] = uSR3_DATA.mPointlist[k].Stack_no;
								USR3B[fn].mPointlistCat[n].MultiFeeders++;
							}
							else
							{
								flag = true;
							}
						}
						flag2 = true;
					}
					if (flag2)
					{
						continue;
					}
					ChipCategoryElement chipCategoryElement2 = new ChipCategoryElement(USR_INIT.mLanguage);
					chipCategoryElement2.Material_value = uSR3_DATA.mPointlist[k].Material_value;
					chipCategoryElement2.Footprint = uSR3_DATA.mPointlist[k].Footprint;
					chipCategoryElement2.Count = 1;
					chipCategoryElement2.Feedertype = uSR3_DATA.mPointlist[k].Feedertype;
					chipCategoryElement2.Nozzletype0 = uSR3_DATA.mPointlist[k].Nozzletype;
					chipCategoryElement2.Nozzletype1 = uSR3_DATA.mPointlist[k].Nozzletype;
					chipCategoryElement2.Cameratype = uSR3_DATA.mPointlist[k].Cameratype;
					chipCategoryElement2.Visualtype = uSR3_DATA.mPointlist[k].Visualtype;
					chipCategoryElement2.Looptype = uSR3_DATA.mPointlist[k].Looptype;
					chipCategoryElement2.Delta = uSR3_DATA.mPointlist[k].sampik_delta;
					chipCategoryElement2.scan_r = uSR3_DATA.mPointlist[k].scanR;
					chipCategoryElement2.threshold = uSR3_DATA.mPointlist[k].threshold;
					chipCategoryElement2.Lenght = uSR3_DATA.mPointlist[k].length;
					chipCategoryElement2.Width = uSR3_DATA.mPointlist[k].width;
					chipCategoryElement2.Height = uSR3_DATA.mPointlist[k].height;
					chipCategoryElement2.is_collect = uSR3_DATA.mPointlist[k].is_collect;
					chipCategoryElement2.collectdelta = uSR3_DATA.mPointlist[k].collectdelta;
					chipCategoryElement2.pik_h_offset = uSR3_DATA.mPointlist[k].pik_h_offset;
					chipCategoryElement2.mnt_h_offset = uSR3_DATA.mPointlist[k].mnt_h_offset;
					chipCategoryElement2.zup_speed = uSR3_DATA.mPointlist[k].zup_speed;
					chipCategoryElement2.zdown_speed = uSR3_DATA.mPointlist[k].zdown_speed;
					chipCategoryElement2.zpik_delay = uSR3_DATA.mPointlist[k].zpik_delay;
					chipCategoryElement2.zmnt_up_speed = uSR3_DATA.mPointlist[k].zmnt_up_speed;
					chipCategoryElement2.zmnt_down_speed = uSR3_DATA.mPointlist[k].zmnt_down_speed;
					chipCategoryElement2.zmnt_delay = uSR3_DATA.mPointlist[k].zmnt_delay;
					chipCategoryElement2.is_high = uSR3_DATA.mPointlist[k].is_high;
					chipCategoryElement2.IsLowSpeed = uSR3_DATA.mPointlist[k].IsLowSpeed;
					chipCategoryElement2.feeder_no[0] = uSR3_DATA.mPointlist[k].Stack_no;
					for (int num2 = 0; num2 < bindingList.Count; num2++)
					{
						if (chipCategoryElement2.Material_value == bindingList[num2].Material_value && chipCategoryElement2.Footprint == bindingList[num2].Footprint)
						{
							chipCategoryElement2.Nozzletype0 = bindingList[num2].Nozzletype0;
							chipCategoryElement2.Nozzletype1 = bindingList[num2].Nozzletype1;
						}
					}
					USR3B[fn].mPointlistCat.Add(chipCategoryElement2);
				}
			}
			pcbcat_order(PcatHead.FOOTPRINT, SortOrder.Ascending, USR3B[fn].mPointlistCat);
			if (flag)
			{
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Multi feeder count is out of range: " : ("一些多组供料的feeder数量太多，已超过最大值：" + HW.mMaxMultiFeederNum.ToString()));
			}
			bindingList.Clear();
			return result;
		}

		public static void pcbcat_order(PcatHead column, SortOrder order, BindingList<ChipCategoryElement> catlist)
		{
			if (column != PcatHead.FOOTPRINT && column != 0 && column != PcatHead.COUNT && column != PcatHead.FEEDER_NO)
			{
				return;
			}
			BindingList<ChipCategoryElement> bindingList = new BindingList<ChipCategoryElement>();
			for (int i = 0; i < catlist.Count; i++)
			{
				bindingList.Add(catlist[i]);
			}
			catlist.Clear();
			ChipCategoryElement[] array = null;
			if (column == PcatHead.FOOTPRINT)
			{
				array = ((order != SortOrder.Descending) ? bindingList.OrderBy((ChipCategoryElement a) => a.Footprint).ToArray() : bindingList.OrderByDescending((ChipCategoryElement a) => a.Footprint).ToArray());
			}
			if (column == PcatHead.VALUE)
			{
				array = ((order == SortOrder.Descending) ? bindingList.OrderBy((ChipCategoryElement a) => a.Material_value).ToArray() : bindingList.OrderByDescending((ChipCategoryElement a) => a.Material_value).ToArray());
			}
			if (column == PcatHead.COUNT)
			{
				array = ((order == SortOrder.Descending) ? bindingList.OrderBy((ChipCategoryElement a) => a.Count).ToArray() : bindingList.OrderByDescending((ChipCategoryElement a) => a.Count).ToArray());
			}
			try
			{
				if (column == PcatHead.FEEDER_NO)
				{
					array = ((order == SortOrder.Descending) ? bindingList.OrderBy((ChipCategoryElement a) => a.feeder_no[0]).ToArray() : bindingList.OrderByDescending((ChipCategoryElement a) => a.feeder_no[0]).ToArray());
				}
			}
			catch (Exception)
			{
				CmMessageBoxTop_Ok("EXCEPTION: pcbcat_order ");
				return;
			}
			if (array != null)
			{
				for (int j = 0; j < bindingList.Count; j++)
				{
					catlist.Add(array[j]);
				}
			}
		}

		public static void catlist_to_pointlist(int fn)
		{
			for (int i = 0; i < U3[fn].Count; i++)
			{
				BindingList<ChipBoardElement> mPointlist = U3[fn][i].mPointlist;
				if (mPointlist == null || mPointlist.Count <= 0 || USR3B[fn].mPointlistCat == null || USR3B[fn].mPointlistCat.Count <= 0)
				{
					continue;
				}
				for (int j = 0; j < mPointlist.Count; j++)
				{
					for (int k = 0; k < USR3B[fn].mPointlistCat.Count; k++)
					{
						if (mPointlist[j].Material_value == USR3B[fn].mPointlistCat[k].Material_value && mPointlist[j].Footprint == USR3B[fn].mPointlistCat[k].Footprint)
						{
							mPointlist[j].Stacktype = check_return_providertype(USR3B[fn].mPointlistCat[k].Feedertype);
							mPointlist[j].Feedertype = USR3B[fn].mPointlistCat[k].Feedertype;
							mPointlist[j].Nozzletype = USR3B[fn].mPointlistCat[k].Nozzletype0;
							mPointlist[j].sampik_delta = USR3B[fn].mPointlistCat[k].Delta;
							mPointlist[j].length = USR3B[fn].mPointlistCat[k].Lenght;
							mPointlist[j].width = USR3B[fn].mPointlistCat[k].Width;
							mPointlist[j].height = USR3B[fn].mPointlistCat[k].Height;
							mPointlist[j].is_collect = USR3B[fn].mPointlistCat[k].is_collect;
							mPointlist[j].collectdelta = USR3B[fn].mPointlistCat[k].collectdelta;
							mPointlist[j].pik_h_offset = USR3B[fn].mPointlistCat[k].pik_h_offset;
							mPointlist[j].mnt_h_offset = USR3B[fn].mPointlistCat[k].mnt_h_offset;
							mPointlist[j].zup_speed = USR3B[fn].mPointlistCat[k].zup_speed;
							mPointlist[j].zdown_speed = USR3B[fn].mPointlistCat[k].zdown_speed;
							mPointlist[j].zpik_delay = USR3B[fn].mPointlistCat[k].zpik_delay;
							mPointlist[j].zmnt_up_speed = USR3B[fn].mPointlistCat[k].zmnt_up_speed;
							mPointlist[j].zmnt_down_speed = USR3B[fn].mPointlistCat[k].zmnt_down_speed;
							mPointlist[j].zmnt_delay = USR3B[fn].mPointlistCat[k].zmnt_delay;
							mPointlist[j].scanR = USR3B[fn].mPointlistCat[k].scan_r;
							mPointlist[j].threshold = USR3B[fn].mPointlistCat[k].threshold;
							mPointlist[j].Cameratype = USR3B[fn].mPointlistCat[k].Cameratype;
							mPointlist[j].Visualtype = USR3B[fn].mPointlistCat[k].Visualtype;
							mPointlist[j].Looptype = USR3B[fn].mPointlistCat[k].Looptype;
							mPointlist[j].IsLowSpeed = USR3B[fn].mPointlistCat[k].IsLowSpeed;
							mPointlist[j].is_high = USR3B[fn].mPointlistCat[k].is_high;
							if (USR3B[fn].mPointlistCat[k].MultiFeeders == 1 && USR3B[fn].mPointlistCat[k].feeder_no[0] != 0)
							{
								mPointlist[j].Stack_no = USR3B[fn].mPointlistCat[k].feeder_no[0];
							}
						}
					}
				}
			}
		}

		public static void moveToXY_andWait_Smt(int fn, int speed, Coordinate point)
		{
			mIsXYMoving[fn] = true;
			if (mIsFeederUp[fn])
			{
				Thread.Sleep(1000);
			}
			while (true)
			{
				if (mRunDoing[fn] != 0)
				{
					if ((mRunDoing[fn] & 2u) != 0)
					{
						break;
					}
					Thread.Sleep(1);
					continue;
				}
				int num = (int)point.X;
				mWaitXY[fn].X = num;
				int num2 = (int)point.Y;
				mWaitXY[fn].Y = num2;
				mConDev[fn].sendxyCoordinate(num, num2, speed);
				Waiting(96, fn, 0, 15000, 0);
				break;
			}
			mIsXYMoving[fn] = false;
		}

		public static void moveToXY_noWait_Smt(int fn, int speed, Coordinate point)
		{
			mIsXYMoving[fn] = true;
			if (mIsFeederUp[fn])
			{
				Thread.Sleep(1000);
			}
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					mIsXYMoving[fn] = false;
					return;
				}
				Thread.Sleep(1);
			}
			int num = (int)point.X;
			mWaitXY[fn].X = num;
			int num2 = (int)point.Y;
			mWaitXY[fn].Y = num2;
			mWaitXY[fn] = new Coordinate(num, num2);
			mConDev[fn].sendxyCoordinate(num, num2, speed);
		}

		public static void moveToZ_andWait_Smt(int fn, int zn, int speed, int height)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			switch (HW.mSmtGenerationNo)
			{
			case 0:
				mWaitZ[fn][zn] = height;
				mConDev[fn].sendzCoordinate(zn, height, speed);
				break;
			case 2:
				mWaitZ[fn][zn] = height;
				move_z_coordinate_gen2(fn, zn, height, speed);
				break;
			}
			Waiting(98, fn, zn, 15000, 0);
		}

		public static void moveToZ_noWait_Smt(int fn, int zn, int speed, int height)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			switch (HW.mSmtGenerationNo)
			{
			case 0:
				mWaitZ[fn][zn] = height;
				mConDev[fn].sendzCoordinate(zn, height, speed);
				break;
			case 2:
				mWaitZ[fn][zn] = height;
				move_z_coordinate_gen2(fn, zn, height, speed);
				break;
			case 1:
				break;
			}
		}

		public static void moveToA_andWait_Smt(int fn, int zn, int speed, int a)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			mWaitA[fn][zn] = a;
			move_a_coordinate(fn, zn, a, speed);
			Waiting(22, fn, zn, 15000, 0);
		}

		public static void moveToA_noWait_Smt(int fn, int zn, int speed, int a)
		{
			while (mRunDoing[fn] != 0)
			{
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return;
				}
				Thread.Sleep(1);
			}
			mWaitA[fn][zn] = a;
			move_a_coordinate(fn, zn, a, speed);
		}

		private void __btn_Project_Click(object sender, EventArgs e)
		{
			write_to_logFile_hand("[PROJECT] " + Environment.NewLine);
			mMutexMoveXYZA = false;
			int num = __wind_checkget_software_state(1);
			if (num == 2 || num == 3 || num == 4)
			{
				write_to_logFile_hand("[PROJECT] registry fail" + Environment.NewLine);
				return;
			}
			write_to_logFile_hand("[PROJECT] start" + Environment.NewLine);
			FormOpen formOpen = new FormOpen(USR_INIT.mLanguage);
			switch (formOpen.ShowDialog())
			{
			case DialogResult.Retry:
			{
				if (!is_engineer_password_correct())
				{
					break;
				}
				write_to_logFile_hand("[PROJECT] create" + Environment.NewLine);
				if (USR_INIT.mInBoard_Mode == 1 && HW.mIsSanduanshi)
				{
					string[] array = new string[3]
					{
						"当前为分" + HW.mSections + "段贴板模式，您需要编辑" + HW.mSections + "个子工程，是否继续?",
						"當前為分" + HW.mSections + "段貼板模式，您需要編輯" + HW.mSections + "個子工程，是否繼續?",
						"This is " + HW.mSections + " sections mode. You need to edit " + HW.mSections + "sub pcb, are you continue?"
					};
					if (CmMessageBox(array[USR_INIT.mLanguage], MessageBoxButtons.YesNo) != DialogResult.Yes)
					{
						break;
					}
				}
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = ((USR_INIT.mLanguage == 2) ? "Project Files(*.qn)|*.qn" : "工程文件(*.qn)|*.qn");
				saveFileDialog.RestoreDirectory = true;
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					break;
				}
				Stream stream2 = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				stream2.Flush();
				stream2.Close();
				label_projectname.Text = STR.PROJECT[USR_INIT.mLanguage] + saveFileDialog.FileName;
				mProjectFileName = saveFileDialog.FileName;
				write_to_logFile(mLogFileName, mProjectFileName + Environment.NewLine);
				FormCreateMode formCreateMode = new FormCreateMode(USR_INIT.mLanguage);
				DialogResult dialogResult = formCreateMode.ShowDialog();
				create_usrProjectData();
				save_usrProjectData();
				enable_MainProject();
				btn_OpenCreateProject.Enabled = false;
				btn_Connect.Enabled = false;
				if (dialogResult == DialogResult.Yes)
				{
					for (int k = 0; k < HW.mFnNum; k++)
					{
						uc_job[k].display_pcbedit_import(flag: true);
					}
				}
				if (!HW.mIsSanduanshi && HW.mSmtGenerationNo == 0)
				{
					Form_TrackNotice form_TrackNotice = new Form_TrackNotice();
					if (form_TrackNotice.ShowDialog() == DialogResult.OK)
					{
						uc_usroperarion[0].trackpara_click();
					}
				}
				for (int l = 0; l < HW.mFnNum; l++)
				{
					uc_usroperarion[l].set_visualtest_para_visable(flag: false);
				}
				break;
			}
			case DialogResult.Yes:
			{
				write_to_logFile_hand("[PROJECT] open" + Environment.NewLine);
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = ((USR_INIT.mLanguage == 2) ? "Project Files(*.qn)|*.qn" : "工程文件(*.qn)|*.qn");
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					break;
				}
				common_waiting_start((USR_INIT.mLanguage == 2) ? "Loading..." : "正在加载数据...", 20);
				Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
				stream.Flush();
				stream.Close();
				label_projectname.Text = STR.PROJECT[USR_INIT.mLanguage] + openFileDialog.FileName;
				mProjectFileName = openFileDialog.FileName;
				write_to_logFile(mLogFileName, mProjectFileName + Environment.NewLine);
				if (!load_usrProjectData_EX())
				{
					common_waiting_break();
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Invalid File!" : "此文件不合法，打开失败！");
					break;
				}
				for (int i = 0; i < HW.mFnNum; i++)
				{
					uc_job[i].set_tab_index(1);
				}
				enable_MainProject_OpenPrj();
				btn_OpenCreateProject.Enabled = false;
				btn_Connect.Enabled = false;
				for (int j = 0; j < HW.mFnNum; j++)
				{
					uc_usroperarion[j].set_visualtest_para_visable(flag: false);
				}
				common_waiting_break();
				break;
			}
			}
		}

		private void __button_ProjectClose_Click(object sender, EventArgs e)
		{
			write_to_logFile_hand("HAND: button_ProjectClose_Click" + Environment.NewLine);
			mMutexMoveXYZA = false;
			save_file();
			for (int i = 0; i < HW.mFnNum; i++)
			{
				uc_usroperarion[i].set_visualtest_para_visable(flag: true);
			}
			if (uc_smtRunning != null)
			{
				if (!uc_smtRunning.IsDisposed)
				{
					uc_smtRunning.Dispose();
				}
				uc_smtRunning = null;
			}
			for (int j = 0; j < HW.mFnNum; j++)
			{
				vsplus_pcbedit_unload(j);
			}
			label_projectname.Text = STR.PROJECT[USR_INIT.mLanguage];
			enable_MainPictrue();
			btn_OpenCreateProject.Enabled = true;
			btn_Connect.Enabled = true;
			mProjectFileName = "";
			USR3_INIT = null;
			for (int k = 0; k < HW.mFnNum; k++)
			{
				USR2[k] = null;
				USR3B[k] = null;
				flush_visual_light(k);
				if (U3[k] != null)
				{
					U3[k].Clear();
					U3[k] = null;
				}
				U3Idx[k] = 0;
			}
			mConDevExt[0].send_loukong_enable(0, HW.mIsSanduanshi);
		}

		private int RawStreamDirectReadCallback(uint ch, IntPtr DataBuf, int FrameType, int width, int height, IntPtr Context)
		{
			if (is_ahd_start_capture[ch])
			{
				Marshal.Copy(DataBuf, pYuvBuffer[ch], 0, 1843200);
				is_ahd_start_capture[ch] = false;
			}
			return 0;
		}

		private int init_ahd_callback()
		{
			int num = 4;
			ulong num2 = (ulong)(mJvs_rawWidth * mJvs_rawHeight * 2 + num);
			pYuvBuffer = new byte[mJvs_Channels][];
			for (int i = 0; i < mJvs_Channels; i++)
			{
				pYuvBuffer[i] = new byte[num2];
			}
			pRgb32Buffer = new byte[mJvs_Channels][];
			for (int j = 0; j < mJvs_Channels; j++)
			{
				pRgb32Buffer[j] = new byte[mJvs_rawWidth * mJvs_rawHeight * 4];
			}
			if (!is_ahd_callbackmode)
			{
				return 0;
			}
			is_ahd_start_capture = new bool[mJvs_Channels];
			for (int k = 0; k < mJvs_Channels; k++)
			{
				is_ahd_start_capture[k] = false;
			}
			ahd_callback_fn = RawStreamDirectReadCallback;
			AnologHD.RegisterRAWStreamDirectCallback(ahd_callback_fn, mMainHandle);
			return 0;
		}

		public void vsplus_usr2_history_before_2020_8()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR2[i].mHistory < 8 && USR2[i].mStackLib == null)
				{
					USR2[i].mStackLib = new USR_STACKLIB(USR2[i].mStack, USR2[i].mPlate, USR2[i].mVibra);
				}
			}
		}

		public void vsplus_usr2_history_before_2020_7()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR2[i].mHighCamScanRange == null)
				{
					USR2[i].mHighCamScanRange = new int[2][];
					for (int j = 0; j < 2; j++)
					{
						USR2[i].mHighCamScanRange[j] = new int[8] { 300, 300, 300, 300, 300, 300, 300, 300 };
					}
				}
				if (USR2[i].mFastCamScanRange == null)
				{
					USR2[i].mFastCamScanRange = new int[2][];
					for (int k = 0; k < 2; k++)
					{
						USR2[i].mFastCamScanRange[k] = new int[8] { 150, 150, 150, 150, 150, 150, 150, 150 };
					}
				}
				if (USR2[i].mVibra == null)
				{
					for (int l = 0; l < 80; l++)
					{
						USR2[i].mVibra[l] = new StackElement();
					}
				}
				if (USR2[i].mHistory >= 7)
				{
					continue;
				}
				bool mIsPrepareVacuumLater = false;
				if (U3[i] != null && U3[i].Count > 0)
				{
					mIsPrepareVacuumLater = U3[i][0].mIsNotPreOpenVacc;
				}
				USR2[i].mIsPrepareVacuumLater = mIsPrepareVacuumLater;
				for (int m = 0; m < USR2[i].mStack.Count(); m++)
				{
					USR2[i].mStack[m].mIsHCamSpecialPara = false;
					USR2[i].mStack[m].HCamSpecial_angle_delta = 0;
					USR2[i].mStack[m].HCamSpecial_ledlevel = 0;
					USR2[i].mStack[m].HCamSpecial_retrycounts = 0;
					USR2[i].mStack[m].HCamSpecial_scanr = 0;
					USR2[i].mStack[m].HCamSpecial_xy_delta = 0;
				}
				for (int n = 0; n < USR2[i].mPlate.Count(); n++)
				{
					USR2[i].mPlate[n].mIsHCamSpecialPara = false;
					USR2[i].mPlate[n].HCamSpecial_angle_delta = 0;
					USR2[i].mPlate[n].HCamSpecial_ledlevel = 0;
					USR2[i].mPlate[n].HCamSpecial_retrycounts = 0;
					USR2[i].mPlate[n].HCamSpecial_scanr = 0;
					USR2[i].mPlate[n].HCamSpecial_xy_delta = 0;
				}
				for (int num = 0; num < USR2[i].mVibra.Count(); num++)
				{
					USR2[i].mVibra[num].mIsHCamSpecialPara = false;
					USR2[i].mVibra[num].HCamSpecial_angle_delta = 0;
					USR2[i].mVibra[num].HCamSpecial_ledlevel = 0;
					USR2[i].mVibra[num].HCamSpecial_retrycounts = 0;
					USR2[i].mVibra[num].HCamSpecial_scanr = 0;
					USR2[i].mVibra[num].HCamSpecial_xy_delta = 0;
				}
				for (int num2 = 0; num2 < USR2[i].mPlate.Count(); num2++)
				{
					USR2[i].mPlate[num2].mPlt.mAngle = 0f;
					BindingList<sSubPlate> mSubList = USR2[i].mPlate[num2].mPlt.mSubList;
					if (mSubList != null && mSubList.Count > 0)
					{
						for (int num3 = 0; num3 < mSubList.Count; num3++)
						{
							mSubList[num3].mAngle = 0f;
						}
					}
					BindingList<StackPlateXYElement> mXYlist = USR2[i].mPlate[num2].mPlt.mXYlist;
					if (mXYlist != null && mXYlist.Count > 0)
					{
						for (int num4 = 0; num4 < mXYlist.Count; num4++)
						{
							mXYlist[num4].mEnable = true;
						}
					}
				}
			}
		}

		public void vsplus_usr2_history_before_2019_3()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR2[i].mVibra != null)
				{
					continue;
				}
				USR2[i].mVibra = new StackElement[80];
				for (int j = 0; j < 80; j++)
				{
					USR2[i].mVibra[j] = new StackElement(USR2[i].mStack[j + 80]);
				}
				for (int k = 0; k < 160; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						USR2[i].mStack[k].mZnData[l].threshold = USR2[i].mFastCamThreshold[0][l];
					}
				}
				for (int m = 0; m < 80; m++)
				{
					for (int n = 0; n < 8; n++)
					{
						USR2[i].mVibra[m].mZnData[n].threshold = USR2[i].mFastCamThreshold[0][n];
					}
				}
				for (int num = 0; num < 80; num++)
				{
					for (int num2 = 0; num2 < 8; num2++)
					{
						USR2[i].mPlate[num].mZnData[num2].threshold = USR2[i].mFastCamThreshold[0][num2];
					}
				}
				for (int num3 = 0; num3 < 160; num3++)
				{
					USR2[i].mStack[num3].scanR = USR2[i].mFastCamScanRange[0][0];
				}
				for (int num4 = 0; num4 < 80; num4++)
				{
					USR2[i].mVibra[num4].scanR = USR2[i].mFastCamScanRange[0][0];
				}
				for (int num5 = 0; num5 < 80; num5++)
				{
					USR2[i].mPlate[num5].scanR = USR2[i].mFastCamScanRange[0][0];
				}
				for (int num6 = 0; num6 < U3[i].Count(); num6++)
				{
					for (int num7 = 0; num7 < U3[i][num6].mPointlist.Count; num7++)
					{
						if (U3[i][num6].mPointlist != null && U3[i][num6].mPointlist[num7].Visualtype == VisualType.Precise)
						{
							U3[i][num6].mPointlist[num7].Visualtype = VisualType.Normal;
							U3[i][num6].mPointlist[num7].isPricise = true;
							U3[i][num6].mPointlist[num7].Looptype = LoopType.CloseLoop;
						}
					}
				}
				for (int num8 = 0; num8 < U3[i].Count(); num8++)
				{
					for (int num9 = 0; num9 < U3[i][num8].mPointlistCat.Count; num9++)
					{
						if (U3[i][num8].mPointlistCat != null && U3[i][num8].mPointlistCat[num9].Visualtype == VisualType.Precise)
						{
							U3[i][num8].mPointlistCat[num9].Visualtype = VisualType.Normal;
							U3[i][num8].mPointlistCat[num9].IsPricise = true;
						}
					}
				}
				for (int num10 = 0; num10 < USR3B[i].mPointlistCat.Count; num10++)
				{
					if (USR3B[i].mPointlistCat != null && USR3B[i].mPointlistCat[num10].Visualtype == VisualType.Precise)
					{
						USR3B[i].mPointlistCat[num10].Visualtype = VisualType.Normal;
						USR3B[i].mPointlistCat[num10].IsPricise = true;
					}
				}
			}
		}

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_Visual_MarkGen(IntPtr pTempBits, int pixfmt, Size size, ref int thrsd, int min_pno, int max_pno, ref int len);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_Visual_MarkGen_GetData(int[] psize, int[] pdata);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_Visual_MarkGen_Match(IntPtr pDIBits, int[] pcontour, int len, int pixfmt, Size size, int thrsd, double[] cirs, int max_cirs);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_isRec(float[] points, float delta);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_isParallelogram(float[] points, float delta);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_Visual_Chess(IntPtr pDIBits, int pixelbit, Size size, Size bsize, ref BOX2D box, ref PointF ptf);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_Visual_Chess(byte[] pDIBits, int pixelbit, Size size, Size bsize, ref BOX2D box, ref PointF ptf);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void moon_Visual_Chess_Clear();

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_Visual_Chess_CalibrateCamera(Size size, Size bsize, Size rsize, double[] ptf);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_rgb32_1280x720_to_720x720(IntPtr pDIBits, IntPtr pDIBits2);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_yuyv_to_yyy32(byte[] pDIBits, byte[] pDIBits2, int w, int h, int offset);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_yuyv_to_rgb32(byte[] pDIBits, byte[] pDIBits2, int w, int h, int offset);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_Average(IntPtr pDIBits, IntPtr pDIBits2, Size size);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_CameraCalibration(IntPtr pDIBits, int pixelbit, Size size, double[] para);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern double moon_FindMark(IntPtr pTempBits, Size TempSize, IntPtr pSearchBits, Size SearchSize, ref PointF leftpoint, ref PointF ptf, int pixbit);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern double moon_FindMark(IntPtr pTempBits, Size TempSize, ref byte pSearchBits, Size SearchSize, ref PointF leftpoint, ref PointF ptf, int pixbit);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void moon_qign_button_create(int width, int height, IntPtr scan0, int r0, int g0, int b0, IntPtr scan1, int r1, int g1, int b1, IntPtr scan2, int r2, int g2, int b2);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_buffer_move_angel(IntPtr pDIBits, int pixelbit, Size size, Point center, int scanradius, float a);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_buffer_move_angel(byte[] pDIBits, int pixelbit, Size size, Point center, int scanradius, float a);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_buffer_move_xy(IntPtr pDIBits, int pixelbit, Size size, Point center, int scanradius, float x, float y);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_buffer_move_xy(byte[] pDIBits, int pixelbit, Size size, Point center, int scanradius, float x, float y);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_visual_autopixXY_YK(IntPtr pDIBits, int pixelbit, Size size, Point center, int scanradius, ref BOX2D box, ref PointF ptf, char isoppovisual, bool isdebug);

		[DllImport("moon_qign.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int moon_visual_autopixXY_YK(byte[] pDIBits, int pixelbit, Size size, Point center, int scanradius, ref BOX2D box, ref PointF ptf, char isoppovisual, bool isdebug);

		public void vsplus_init_deviceui()
		{
			base.Controls.Add(tabControl_dsq);
			tabControl_dsq.BringToFront();
			tabControl_dsq.Location = new Point(0, 50);
			tabControl_dsq.Size = new Size(1280, 1080);
			uc_usroperarion = new UserControl_UsrOperation[HW.mFnNum];
			panel_mainAreas = new Panel[HW.mFnNum];
			panel_mainPictures = new Panel[HW.mFnNum];
			panel_newProjects = new Panel[HW.mFnNum];
			uc_job = new UserControl_job[HW.mFnNum];
			uc_devicecalibration = new UserControl_SystemSetting[HW.mFnNum];
			mFn = 0;
			for (int i = 0; i < HW.mFnNum; i++)
			{
				uc_usroperarion[i] = new UserControl_UsrOperation(i, USR[i]);
				tabControl_dsq.TabPages[i].Controls.Add(uc_usroperarion[i]);
				uc_usroperarion[i].Reset += Reset;
				uc_usroperarion[i].misc_board_out += misc_board_out;
				uc_usroperarion[i].vsplus_switch_to_camera += vsplus_switch_to_camera;
				uc_usroperarion[i].vsplus_markCameraPara += vsplus_markCameraPara;
				uc_usroperarion[i].vsplus_reopen_preview += vsplus_reopen_preview;
				uc_usroperarion[i].vsplus_visual_test += vsplus_visual_test;
				uc_usroperarion[i].vsplus_open_visualshow += vsplus_open_visualshow;
				uc_usroperarion[i].vsplus_factory_capture += vsplus_factory_capture;
				uc_usroperarion[i].vsplus_open_fixcampara += vsplus_open_fixcampara;
				uc_usroperarion[i].Location = new Point(4, 2);
				uc_usroperarion[i].Enabled = false;
				uc_usroperarion[i].BackColor = ((i == 0) ? Color.LightSkyBlue : Color.LightCoral);
				panel_mainAreas[i] = new Panel();
				tabControl_dsq.TabPages[i].Controls.Add(panel_mainAreas[i]);
				panel_mainAreas[i].Location = new Point(559, 3);
				panel_mainAreas[i].Size = new Size(713, 940);
				panel_mainAreas[i].BorderStyle = BorderStyle.Fixed3D;
				panel_mainPictures[i] = new Panel();
				panel_mainAreas[i].Controls.Add(panel_mainPictures[i]);
				panel_mainPictures[i].Location = new Point(0, 0);
				panel_mainPictures[i].Size = new Size(714, 945);
				panel_mainPictures[i].BackgroundImage = ((i == 0) ? MAIN_PICTURE[1] : Resources.HWGC_IMAGE2);
				panel_mainPictures[i].BackgroundImageLayout = ImageLayout.Stretch;
				panel_newProjects[i] = new Panel();
				panel_mainAreas[i].Controls.Add(panel_newProjects[i]);
				panel_newProjects[i].Location = new Point(0, -1);
				panel_newProjects[i].Size = new Size(713, 960);
				panel_newProjects[i].Visible = false;
				PicBox_Preview[i] = uc_usroperarion[i].get_preview_picturebox();
				PicBox_Preview2[i] = uc_usroperarion[i].get_preview2_picturebox();
				pictureBox_visualrunning[i] = uc_usroperarion[i].get_visualrunning_pictureBox();
				panel_preview[i] = uc_usroperarion[i].get_preview_panel();
				pictureBox_VisualTest[i] = uc_usroperarion[i].get_visualtest_picturebox();
				button_stop_runningvisual[i] = uc_usroperarion[i].get_stop_visualrunning_button();
				uc_devicecalibration[i] = new UserControl_SystemSetting(i, USR[i]);
				uc_devicecalibration[i].Visible = false;
				panel_mainAreas[i].Controls.Add(uc_devicecalibration[i]);
				uc_devicecalibration[i].Location = new Point(-1, -1);
				uc_devicecalibration[i].vsplus_start_fcam_auto_calibration += vsplus_start_fcam_auto_calibration;
				uc_devicecalibration[i].vsplus_start_hcam_auto_calibration += vsplus_start_hcam_auto_calibration;
				uc_devicecalibration[i].vsplus_start_hcam_singel_calibration += vsplus_start_hcam_singel_calibration;
				uc_devicecalibration[i].vsplus_restart_camerapreview += vsplus_restart_camerapreview;
				uc_devicecalibration[i].vsplus_nozzledelta_auto_center_loop += vsplus_nozzledelta_auto_center_loop;
				uc_devicecalibration[i].vsplus_test_previewoffset += vsplus_test_previewoffset;
				uc_devicecalibration[i].vsplus_open_fixcampara += vsplus_open_fixcampara;
				uc_devicecalibration[i].vsplus_visual_test += vsplus_visual_test;
				uc_devicecalibration[i].vsplus_open_visualshow += vsplus_open_visualshow;
				uc_devicecalibration[i].vsplus_factory_capture += vsplus_factory_capture;
				uc_devicecalibration[i].vsplus_visual_algorithms_debug += vsplus_visual_algorithms_debug;
				uc_devicecalibration[i].vsplus_visual_algorithms_running_debug += vsplus_visual_algorithms_running_debug;
				uc_devicecalibration[i].vsplus_visual_algorithms += vsplus_visual_algorithms;
				uc_devicecalibration[i].BringToFront();
				uc_job[i] = new UserControl_job(i);
				panel_newProjects[i].Controls.Add(uc_job[i]);
				uc_job[i].Location = new Point(0, 2);
				uc_job[i].BringToFront();
				button_stop_runningvisual[i].Click += button_stop_runningvisual_Click;
				mBitmapVisualRunning[i] = new Bitmap(pictureBox_visualrunning[i].Size.Width, pictureBox_visualrunning[i].Size.Height);
				mBitmapVisualTest[i] = new Bitmap(PicBox_Preview[i].Size.Width, PicBox_Preview[i].Size.Height);
				mFn++;
			}
			mFn = 0;
			if (HW.mFnNum == 1)
			{
				tabControl_dsq.TabPages.RemoveAt(1);
				tabPage_dsq1F.Text = STR.DEVICE[(int)HW.mDeviceType];
			}
			base.Controls.Add(label_projectname);
			label_projectname.Location = new Point(170 * HW.mFnNum, 52);
			label_projectname.Size = new Size(820, 26);
			label_projectname.BackColor = Color.FromKnownColor(KnownColor.Control);
			label_projectname.BringToFront();
			base.Controls.Add(label_smtdevicetype);
			label_smtdevicetype.BackColor = Color.FromKnownColor(KnownColor.Control);
			label_smtdevicetype.Location = new Point(1155, 52);
			label_smtdevicetype.Size = new Size(120, 26);
			label_smtdevicetype.BringToFront();
			base.Controls.Add(panel_head);
			panel_head.Location = new Point(4, 3);
			panel_head.BringToFront();
			write_to_logFile("Fn = " + (mFn + 1));
		}

		private void tabControl_dsq_DrawItem(object sender, DrawItemEventArgs e)
		{
			TabControl tabControl = (TabControl)sender;
			SolidBrush brush = new SolidBrush(Color.Red);
			SolidBrush brush2 = new SolidBrush(Color.Gray);
			SolidBrush solidBrush = new SolidBrush(Color.White);
			SolidBrush solidBrush2 = new SolidBrush(Color.Black);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			for (int i = 0; i < tabControl.TabPages.Count; i++)
			{
				Rectangle tabRect = tabControl.GetTabRect(i);
				if (i == tabControl.SelectedIndex)
				{
					e.Graphics.FillRectangle(brush, tabRect);
				}
				else
				{
					e.Graphics.FillRectangle(brush2, tabRect);
				}
				int num = 5;
				tabRect.Y += num;
				tabRect.Height -= num;
				tabRect.Size = new Size(tabRect.Size.Width, tabRect.Height);
				tabRect.Location = new Point(tabRect.Location.X, tabRect.Y);
				e.Graphics.DrawString(tabControl.TabPages[i].Text, new Font(DEF.FONT_2020_TITLE[USR_INIT.mLanguage], 14f, FontStyle.Regular), (i == tabControl.SelectedIndex) ? solidBrush : solidBrush2, tabRect, stringFormat);
			}
		}

		private void button_saveToDefaultUSR2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show((USR_INIT.mLanguage == 2) ? "Save current project feeder/plates/visual para as default setting?" : "确定将当前工程的料站/料盘/视觉参数设置保存为该机器的默认设置？", STR.NOTICE_INFO[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				IFormatter formatter = new BinaryFormatter();
				string path = "./" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin";
				Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				if (USR2 != null)
				{
					formatter.Serialize(stream, USR2);
				}
				stream.Close();
				MessageBox.Show((USR_INIT.mLanguage == 2) ? "Done!" : "完成！");
			}
		}

		private void button_USR2fromOtherPrj_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show((USR_INIT.mLanguage == 2) ? "Update feeder/plates/visual para from other project?" : "确定使用其他工程的料站/料盘/视觉参数设置？", STR.NOTICE_INFO[USR_INIT.mLanguage], MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = ((USR_INIT.mLanguage == 2) ? "Project Files(*.qn)|*.qn" : "工程文件(*.qn)|*.qn");
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
					stream.Flush();
					stream.Close();
					load_usr2only(openFileDialog.FileName);
					MessageBox.Show((USR_INIT.mLanguage == 2) ? "Done!" : "完成！");
				}
			}
		}

		public void init_TnZn()
		{
			panel_nozzle = new Panel[HW.mFnNum];
			radiobt_zn = new RadioButton[HW.mFnNum][];
			mZn = new int[HW.mFnNum];
			mZn_prev = new int[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mZn[i] = 0;
				mZn_prev[i] = -1;
				panel_nozzle[i] = new Panel();
				tabControl_temp.TabPages[0].Controls.Add(panel_nozzle[i]);
				radiobt_zn[i] = new RadioButton[HW.mZnNum[i]];
				for (int j = 0; j < HW.mZnNum[i]; j++)
				{
					RadioButton radioButton = new RadioButton();
					panel_nozzle[i].Controls.Add(radioButton);
					radioButton.TabIndex = j;
					radioButton.Tag = i;
					radiobt_zn[i][j] = radioButton;
					radiobt_zn[i][j].CheckedChanged += radioBn_Zn_CheckedChanged;
				}
				radiobt_zn[i][0].Checked = true;
			}
			mCur = new Coordst[HW.mFnNum];
			for (int k = 0; k < HW.mFnNum; k++)
			{
				mCur[k].x = 0;
				mCur[k].y = 0;
				mCur[k].z = new int[HW.mZnNum[k]];
				mCur[k].a = new int[HW.mZnNum[k]];
				for (int l = 0; l < HW.mZnNum[k]; l++)
				{
					mCur[k].z[l] = 0;
					mCur[k].a[l] = 0;
				}
			}
		}

		private void radioBn_Zn_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				mFn = (int)radioButton.Tag;
				mZn[mFn] = radioButton.TabIndex;
				updateZnChangedShow();
				if (uc_devicecalibration != null && uc_devicecalibration[mFn] != null && !uc_devicecalibration[mFn].IsDisposed)
				{
					uc_devicecalibration[mFn].flush_byZn();
				}
				if (uc_usroperarion != null && uc_usroperarion[mFn] != null && !uc_usroperarion[mFn].IsDisposed)
				{
					uc_usroperarion[mFn].flush_byZn();
				}
			}
			else
			{
				mZn_prev[mFn] = radioButton.TabIndex;
			}
			if (bmIsConnected)
			{
				Thread thread = new Thread(thd_ZnAlltoZero);
				thread.Start(mFn);
			}
		}

		public void updateZnChangedShow()
		{
			updateZnChangedCameraShow(mFn);
		}

		public int getIndexFrom_cbo_SmtDevice(DeviceType devtype)
		{
			DeviceType[] array = OEM.DevList[1];
			int result = 0;
			int num = array.Count();
			for (int i = 0; i < num; i++)
			{
				if (array[i] == devtype)
				{
					result = i;
				}
			}
			return result;
		}

		public bool init_Hardware()
		{
			return updateHwPara(USR_INIT.mDeviceType);
		}

		public bool updateHwPara(DeviceType type)
		{
			HW.mAaxisSubDivision = 128;
			HW.mZaxisSubDivision = 32;
			HW.mDeviceType = DeviceType.HW_6S;
			HW.mIsSanduanshi = false;
			HW.mSections = 1;
			HW.mSmtSubDevice = USR_INIT.mSmtSubDevice;
			HW.mSmtGenerationNo = 0;
			HW.mSlotPitch = 1600;
			HW.mFnNum = 1;
			label_smtdevicetype.Text = "";
			write_to_logFile(mLogFileName, STR.DEVICE[(int)type] + Environment.NewLine);
			mDeviceName = label_smtdevicetype.Text;
			HW.malgo2 = new MAlgo2[1]
			{
				new MAlgo2()
			};
			int[] array = (HW.mRstConner = new int[1]);
			array = (HW.mMFCamChnFn = new int[16]);
			array = (HW.mHCamChnFn = new int[1]);
			HW.mHCamEn = new bool[1] { true };
			switch (type)
			{
			case DeviceType.HW_4SG_44:
			{
				HW.mTnNum = 1;
				HW.mDeviceType = DeviceType.HW_4SG_44;
				HW.mIsSanduanshi = false;
				HW.mZnNum = new int[1] { 4 };
				HW.mConNum = 1;
				HW.mMaxX = new int[1] { 44300 };
				HW.mMaxY = new int[1] { 57200 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 7;
				HW.mFastLedCodeNo = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 7 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 4 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 0, 1, 2, 3 }
				};
				CamItem[] mHighCamItem18 = HW.mHighCamItem;
				CamItem camItem18 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem18.index = new int[1]);
				mHighCamItem18[0] = camItem18;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 1;
				HW.malgo2[0].slt_l[0] = 12;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 13;
				HW.malgo2[0].emp_r[0] = 1;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 1;
				HW.malgo2[0].slt_l[1] = 19;
				HW.malgo2[0].emp_m[1] = 6;
				HW.malgo2[0].slt_r[1] = 0;
				HW.malgo2[0].emp_r[1] = 1;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_4SG_50:
			{
				HW.mTnNum = 1;
				HW.mDeviceType = DeviceType.HW_4SG_50;
				HW.mIsSanduanshi = false;
				HW.mZnNum = new int[1] { 4 };
				HW.mConNum = 1;
				HW.mMaxX = new int[1] { 44300 };
				HW.mMaxY = new int[1] { 57200 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 7;
				HW.mFastLedCodeNo = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 7 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 4 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 0, 1, 2, 3 }
				};
				CamItem[] mHighCamItem17 = HW.mHighCamItem;
				CamItem camItem17 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem17.index = new int[1]);
				mHighCamItem17[0] = camItem17;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 1;
				HW.malgo2[0].slt_l[0] = 12;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 13;
				HW.malgo2[0].emp_r[0] = 1;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 1;
				HW.malgo2[0].slt_l[1] = 12;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 13;
				HW.malgo2[0].emp_r[1] = 1;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_4_50:
			{
				HW.mTnNum = 1;
				HW.mDeviceType = DeviceType.HW_4_50;
				HW.mIsSanduanshi = false;
				HW.mZnNum = new int[1] { 4 };
				HW.mConNum = 1;
				HW.mMaxX = new int[1] { 50900 };
				HW.mMaxY = new int[1] { 61900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 7;
				HW.mFastLedCodeNo = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 7 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 4 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 0, 1, 2, 3 }
				};
				CamItem[] mHighCamItem16 = HW.mHighCamItem;
				CamItem camItem16 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem16.index = new int[1]);
				mHighCamItem16[0] = camItem16;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 1;
				HW.malgo2[0].slt_l[0] = 10;
				HW.malgo2[0].emp_m[0] = 10;
				HW.malgo2[0].slt_r[0] = 10;
				HW.malgo2[0].emp_r[0] = 1;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 1;
				HW.malgo2[0].slt_l[1] = 15;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 15;
				HW.malgo2[0].emp_r[1] = 1;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_4_44:
				HW.mMaxX = new int[1] { 38900 };
				HW.mMaxY = new int[1] { 55900 };
				break;
			case DeviceType.HW_4_42:
			{
				HW.mTnNum = 1;
				HW.mDeviceType = DeviceType.HW_4_42;
				HW.mIsSanduanshi = false;
				HW.mZnNum = new int[1] { 4 };
				HW.mConNum = 1;
				HW.mMaxX = new int[1] { 44900 };
				HW.mMaxY = new int[1] { 55900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 7;
				HW.mFastLedCodeNo = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 7 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 4 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 0, 1, 2, 3 }
				};
				CamItem[] mHighCamItem4 = HW.mHighCamItem;
				CamItem camItem4 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem4.index = new int[1]);
				mHighCamItem4[0] = camItem4;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 8;
				HW.malgo2[0].emp_m[0] = 10;
				HW.malgo2[0].slt_r[0] = 8;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 13;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 13;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_6:
			{
				HW.mDeviceType = DeviceType.HW_6;
				HW.mIsSanduanshi = false;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 6 };
				HW.mConNum = 1;
				HW.mMaxX = new int[1] { 63500 };
				HW.mMaxY = new int[1] { 67900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 11;
				HW.mFastLedCodeNo = new int[11]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				};
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 6 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 6,
					index = new int[6] { 0, 1, 2, 3, 4, 5 }
				};
				CamItem[] mHighCamItem3 = HW.mHighCamItem;
				CamItem camItem3 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem3.index = new int[1]);
				mHighCamItem3[0] = camItem3;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 13;
				HW.malgo2[0].emp_m[0] = 12;
				HW.malgo2[0].slt_r[0] = 13;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 19;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 19;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_6S:
			{
				HW.mDeviceType = DeviceType.HW_6S;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 6 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 63500 };
				HW.mMaxY = new int[1] { 67900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 11;
				HW.mFastLedCodeNo = new int[11]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				};
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 6 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 6,
					index = new int[6] { 0, 1, 2, 3, 4, 5 }
				};
				CamItem[] mHighCamItem5 = HW.mHighCamItem;
				CamItem camItem5 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem5.index = new int[1]);
				mHighCamItem5[0] = camItem5;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 13;
				HW.malgo2[0].emp_m[0] = 12;
				HW.malgo2[0].slt_r[0] = 13;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 19;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 19;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_6SX:
			{
				HW.mDeviceType = DeviceType.HW_6SX;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 6 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 63500 };
				HW.mMaxY = new int[1] { 67900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 11;
				HW.mFastLedCodeNo = new int[11]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				};
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 6 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 6,
					index = new int[6] { 0, 1, 2, 3, 4, 5 }
				};
				CamItem[] mHighCamItem25 = HW.mHighCamItem;
				CamItem camItem25 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem25.index = new int[1]);
				mHighCamItem25[0] = camItem25;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 19;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 19;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 13;
				HW.malgo2[0].emp_m[1] = 12;
				HW.malgo2[0].slt_r[1] = 13;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_8S:
			{
				HW.mDeviceType = DeviceType.HW_8S;
				HW.mSections = 1;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 65050 };
				HW.mMaxY = new int[1] { 74600 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem24 = HW.mHighCamItem;
				CamItem camItem24 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem24.index = new int[1]);
				mHighCamItem24[0] = camItem24;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 4;
				HW.malgo2[0].slt_l[0] = 15;
				HW.malgo2[0].emp_m[0] = 8;
				HW.malgo2[0].slt_r[0] = 15;
				HW.malgo2[0].emp_r[0] = 4;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 4;
				HW.malgo2[0].slt_l[1] = 19;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 19;
				HW.malgo2[0].emp_r[1] = 4;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_8SX:
			{
				HW.mDeviceType = DeviceType.HW_8SX;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 65050 };
				HW.mMaxY = new int[1] { 74600 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem23 = HW.mHighCamItem;
				CamItem camItem23 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem23.index = new int[1]);
				mHighCamItem23[0] = camItem23;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 4;
				HW.malgo2[0].slt_l[0] = 19;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 19;
				HW.malgo2[0].emp_r[0] = 4;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 4;
				HW.malgo2[0].slt_l[1] = 15;
				HW.malgo2[0].emp_m[1] = 8;
				HW.malgo2[0].slt_r[1] = 15;
				HW.malgo2[0].emp_r[1] = 4;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_8SX_72F:
			{
				HW.mDeviceType = DeviceType.HW_8SX_72F;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 65600 };
				HW.mMaxY = new int[1] { 74600 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem22 = HW.mHighCamItem;
				CamItem camItem22 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem22.index = new int[1]);
				mHighCamItem22[0] = camItem22;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 4;
				HW.malgo2[0].slt_l[0] = 20;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 20;
				HW.malgo2[0].emp_r[0] = 4;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 4;
				HW.malgo2[0].slt_l[1] = 16;
				HW.malgo2[0].emp_m[1] = 8;
				HW.malgo2[0].slt_r[1] = 16;
				HW.malgo2[0].emp_r[1] = 4;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_8S_PLUS:
			{
				HW.mDeviceType = DeviceType.HW_8S_PLUS;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 65600 };
				HW.mMaxY = new int[1] { 74600 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem21 = HW.mHighCamItem;
				CamItem camItem21 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem21.index = new int[1]);
				mHighCamItem21[0] = camItem21;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 4;
				HW.malgo2[0].slt_l[0] = 20;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 20;
				HW.malgo2[0].emp_r[0] = 4;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 4;
				HW.malgo2[0].slt_l[1] = 20;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 20;
				HW.malgo2[0].emp_r[1] = 4;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_8SP_1200:
			{
				HW.mSections = 3;
				HW.mDeviceType = DeviceType.HW_8SP_1200;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 65600 };
				HW.mMaxY = new int[1] { 74600 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem20 = HW.mHighCamItem;
				CamItem camItem20 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem20.index = new int[1]);
				mHighCamItem20[0] = camItem20;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 4;
				HW.malgo2[0].slt_l[0] = 20;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 20;
				HW.malgo2[0].emp_r[0] = 4;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 4;
				HW.malgo2[0].slt_l[1] = 20;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 20;
				HW.malgo2[0].emp_r[1] = 4;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_8SX_1200:
			{
				HW.mSections = 3;
				HW.mDeviceType = DeviceType.HW_8SX_1200;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 65050 };
				HW.mMaxY = new int[1] { 74600 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem19 = HW.mHighCamItem;
				CamItem camItem19 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem19.index = new int[1]);
				mHighCamItem19[0] = camItem19;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 4;
				HW.malgo2[0].slt_l[0] = 19;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 19;
				HW.malgo2[0].emp_r[0] = 4;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 4;
				HW.malgo2[0].slt_l[1] = 15;
				HW.malgo2[0].emp_m[1] = 8;
				HW.malgo2[0].slt_r[1] = 15;
				HW.malgo2[0].emp_r[1] = 4;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_6_FLK:
			{
				HW.mDeviceType = DeviceType.HW_6_FLK;
				HW.mIsSanduanshi = false;
				HW.mTnNum = 1;
				HW.mFlkTabVaccNum = 6;
				HW.mZnNum = new int[1] { 6 };
				HW.mConNum = 2;
				if (HW.mSmtSubDevice == 0)
				{
					HW.mMaxX = new int[1] { 33000 };
					HW.mMaxY = new int[1] { 38000 };
					HW.mMaxFlkTabX = 36000;
				}
				else if (HW.mSmtSubDevice == 1)
				{
					HW.mMaxX = new int[1] { 63500 };
					HW.mMaxY = new int[1] { 67900 };
					HW.mMaxFlkTabX = 66000;
				}
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 11;
				HW.mFastLedCodeNo = new int[11]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				};
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 6 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 6,
					index = new int[6] { 0, 1, 2, 3, 4, 5 }
				};
				CamItem[] mHighCamItem15 = HW.mHighCamItem;
				CamItem camItem15 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem15.index = new int[1]);
				mHighCamItem15[0] = camItem15;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 5;
				HW.malgo2[0].emp_m[0] = 8;
				HW.malgo2[0].slt_r[0] = 5;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 0;
				HW.malgo2[0].emp_m[1] = 18;
				HW.malgo2[0].slt_r[1] = 0;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_6_TRANSFER:
			{
				HW.mSections = 3;
				HW.mDeviceType = DeviceType.HW_6_TRANSFER;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 6 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 63500 };
				HW.mMaxY = new int[1] { 67900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 11;
				HW.mFastLedCodeNo = new int[11]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				};
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 6 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 6,
					index = new int[6] { 0, 1, 2, 3, 4, 5 }
				};
				CamItem[] mHighCamItem14 = HW.mHighCamItem;
				CamItem camItem14 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem14.index = new int[1]);
				mHighCamItem14[0] = camItem14;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 13;
				HW.malgo2[0].emp_m[0] = 12;
				HW.malgo2[0].slt_r[0] = 13;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 19;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 19;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_DT408H:
			{
				HW.mSections = 10;
				HW.mDeviceType = DeviceType.HW_DT408H;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 65050 };
				HW.mMaxY = new int[1] { 74600 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem13 = HW.mHighCamItem;
				CamItem camItem13 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem13.index = new int[1]);
				mHighCamItem13[0] = camItem13;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 4;
				HW.malgo2[0].slt_l[0] = 15;
				HW.malgo2[0].emp_m[0] = 8;
				HW.malgo2[0].slt_r[0] = 15;
				HW.malgo2[0].emp_r[0] = 4;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 4;
				HW.malgo2[0].slt_l[1] = 19;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 19;
				HW.malgo2[0].emp_r[1] = 4;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_6_TRAN2:
			{
				HW.mSections = 3;
				HW.mDeviceType = DeviceType.HW_6_TRAN2;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 6 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 63500 };
				HW.mMaxY = new int[1] { 67900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 11;
				HW.mFastLedCodeNo = new int[11]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				};
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 6 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 6,
					index = new int[6] { 0, 1, 2, 3, 4, 5 }
				};
				CamItem[] mHighCamItem12 = HW.mHighCamItem;
				CamItem camItem12 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem12.index = new int[1]);
				mHighCamItem12[0] = camItem12;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 13;
				HW.malgo2[0].emp_m[0] = 12;
				HW.malgo2[0].slt_r[0] = 13;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 19;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 19;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_6S_TRAN3:
			{
				HW.mSections = 1;
				HW.mDeviceType = DeviceType.HW_6S_TRAN3;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 6 };
				HW.mConNum = 3;
				HW.mMaxX = new int[1] { 63500 };
				HW.mMaxY = new int[1] { 67900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 11;
				HW.mFastLedCodeNo = new int[11]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				};
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 6 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 6,
					index = new int[6] { 0, 1, 2, 3, 4, 5 }
				};
				CamItem[] mHighCamItem11 = HW.mHighCamItem;
				CamItem camItem11 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem11.index = new int[1]);
				mHighCamItem11[0] = camItem11;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 13;
				HW.malgo2[0].emp_m[0] = 12;
				HW.malgo2[0].slt_r[0] = 13;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 19;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 19;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_8S_TRAN4:
			{
				HW.mDeviceType = DeviceType.HW_8S_TRAN4;
				HW.mSections = 2;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 65600 };
				HW.mMaxY = new int[1] { 74600 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem10 = HW.mHighCamItem;
				CamItem camItem10 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem10.index = new int[1]);
				mHighCamItem10[0] = camItem10;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 3;
				HW.malgo2[0].slt_l[0] = 20;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 20;
				HW.malgo2[0].emp_r[0] = 3;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 3;
				HW.malgo2[0].slt_l[1] = 20;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 20;
				HW.malgo2[0].emp_r[1] = 3;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.HW_6S_TRAN4:
			{
				HW.mDeviceType = DeviceType.HW_6S_TRAN4;
				HW.mSections = 2;
				HW.mIsSanduanshi = true;
				HW.mTnNum = 1;
				HW.mZnNum = new int[1] { 6 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 63500 };
				HW.mMaxY = new int[1] { 67900 };
				HW.mMaxZ = new int[1] { 11520 };
				HW.mFastLedNum = 11;
				HW.mFastLedCodeNo = new int[11]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				};
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 14, 15 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 6 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 6,
					index = new int[6] { 0, 1, 2, 3, 4, 5 }
				};
				CamItem[] mHighCamItem9 = HW.mHighCamItem;
				CamItem camItem9 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem9.index = new int[1]);
				mHighCamItem9[0] = camItem9;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 19;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 19;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 13;
				HW.malgo2[0].emp_m[1] = 12;
				HW.malgo2[0].slt_r[1] = 13;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.DUDU_400:
			{
				HW.mTnNum = 1;
				HW.mDeviceType = DeviceType.DUDU_400;
				HW.mSmtGenerationNo = 2;
				HW.mIsSanduanshi = true;
				HW.mZnNum = new int[1] { 4 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 64000 };
				HW.mMaxY = new int[1] { 69000 };
				HW.mMaxZ = new int[1] { 500 };
				HW.mSlotPitch = 2550;
				HW.mFastLedNum = 7;
				HW.mFastLedCodeNo = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 4;
				HW.mMarkLedCodeNo = new int[4] { 14, 15, 12, 13 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 4 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 0, 1, 2, 3 }
				};
				CamItem[] mHighCamItem8 = HW.mHighCamItem;
				CamItem camItem8 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem8.index = new int[1]);
				mHighCamItem8[0] = camItem8;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1111;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 12;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 12;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1111;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 9;
				HW.malgo2[0].emp_m[1] = 6;
				HW.malgo2[0].slt_r[1] = 9;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.DUDU_400_50K:
			{
				HW.mTnNum = 1;
				HW.mDeviceType = DeviceType.DUDU_400_50K;
				HW.mSmtGenerationNo = 2;
				HW.mIsSanduanshi = true;
				HW.mZnNum = new int[1] { 4 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 64000 };
				HW.mMaxY = new int[1] { 69000 };
				HW.mMaxZ = new int[1] { 500 };
				HW.mSlotPitch = 2550;
				HW.mFastLedNum = 7;
				HW.mFastLedCodeNo = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 4;
				HW.mMarkLedCodeNo = new int[4] { 14, 15, 12, 13 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 4 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 0, 1, 2, 3 }
				};
				CamItem[] mHighCamItem7 = HW.mHighCamItem;
				CamItem camItem7 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem7.index = new int[1]);
				mHighCamItem7[0] = camItem7;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].emp_l[1] = 3;
				HW.malgo2[0].emp_r[1] = 3;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.DUDU_400_64FX:
			{
				HW.mTnNum = 1;
				HW.mDeviceType = DeviceType.DUDU_400_64FX;
				HW.mSmtGenerationNo = 2;
				HW.mIsSanduanshi = true;
				HW.mZnNum = new int[1] { 4 };
				HW.mConNum = 2;
				HW.mMaxX = new int[1] { 64000 };
				HW.mMaxY = new int[1] { 69000 };
				HW.mMaxZ = new int[1] { 500 };
				HW.mSlotPitch = 2550;
				HW.mFastLedNum = 7;
				HW.mFastLedCodeNo = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 4;
				HW.mMarkLedCodeNo = new int[4] { 14, 15, 12, 13 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 4 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 0, 1, 2, 3 }
				};
				CamItem[] mHighCamItem6 = HW.mHighCamItem;
				CamItem camItem6 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem6.index = new int[1]);
				mHighCamItem6[0] = camItem6;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1001;
				HW.malgo2[0].emp_l[0] = 2;
				HW.malgo2[0].slt_l[0] = 19;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 19;
				HW.malgo2[0].emp_r[0] = 2;
				HW.malgo2[0].ant[1] = AntType.Ant1001;
				HW.malgo2[0].emp_l[1] = 2;
				HW.malgo2[0].slt_l[1] = 13;
				HW.malgo2[0].emp_m[1] = 12;
				HW.malgo2[0].slt_r[1] = 13;
				HW.malgo2[0].emp_r[1] = 2;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.DUDU_800:
			case DeviceType.DUDU_800_E:
			{
				HW.mTnNum = 1;
				HW.mDeviceType = type;
				HW.mSmtGenerationNo = 2;
				HW.mIsSanduanshi = true;
				HW.mZnNum = new int[1] { 8 };
				HW.mConNum = 3;
				HW.mMaxX = new int[1] { 64000 };
				HW.mMaxY = new int[1] { 74600 + ((type == DeviceType.DUDU_800_E) ? 3000 : 0) };
				HW.mMaxZ = new int[1] { 500 };
				HW.mSlotPitch = 1275;
				HW.mFastLedNum = 8;
				HW.mFastLedCodeNo = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[1] { 11 };
				HW.mMarkLedNum = 4;
				HW.mMarkLedCodeNo = new int[4] { 14, 15, 12, 13 };
				HW.mMarkCamItem = new CamItem[1];
				HW.mFastCamItem = new CamItem[1];
				HW.mHighCamItem = new CamItem[1];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 8,
					index = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem2 = HW.mHighCamItem;
				CamItem camItem2 = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem2.index = new int[1]);
				mHighCamItem2[0] = camItem2;
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2[0].ant[0] = AntType.Ant1010;
				HW.malgo2[0].emp_l[0] = 6;
				HW.malgo2[0].slt_l[0] = 24;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 24;
				HW.malgo2[0].emp_r[0] = 6;
				HW.malgo2[0].ant[1] = AntType.Ant1010;
				HW.malgo2[0].emp_l[1] = 6;
				HW.malgo2[0].slt_l[1] = 24;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 24;
				HW.malgo2[0].emp_r[1] = 6;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				break;
			}
			case DeviceType.DSQ800_120F:
			{
				HW.mTnNum = 1;
				HW.mFnNum = 2;
				HW.mDeviceType = DeviceType.DSQ800_120F;
				HW.mSmtGenerationNo = 2;
				HW.mIsSanduanshi = true;
				HW.mZnNum = new int[2] { 4, 4 };
				HW.mConNum = 3;
				HW.mMaxX = new int[2] { 42350, 42350 };
				HW.mMaxY = new int[2] { 74600, 74600 };
				HW.mMaxZ = new int[2] { 500, 500 };
				HW.mRstConner = new int[2] { 1, 0 };
				HW.mSlotPitch = 1275;
				HW.mFastLedNum = 7;
				HW.mFastLedCodeNo = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
				HW.mHighLedNum = 1;
				HW.mHighLedCodeNo = new int[2] { 8, 9 };
				HW.mMarkLedNum = 2;
				HW.mMarkLedCodeNo = new int[2] { 10, 11 };
				HW.mMarkCamItem = new CamItem[2];
				HW.mFastCamItem = new CamItem[2];
				HW.mHighCamItem = new CamItem[2];
				HW.mMarkCamItem[0] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 8 }
				};
				HW.mFastCamItem[0] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 0, 1, 2, 3 }
				};
				HW.mHighCamItem[0] = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 0,
					index = null
				};
				HW.mMarkCamItem[1] = new CamItem
				{
					usage = "MARK_CAM",
					type = "CAM_JVS",
					num = 1,
					index = new int[1] { 9 }
				};
				HW.mFastCamItem[1] = new CamItem
				{
					usage = "FAST_CAM",
					type = "CAM_JVS",
					num = 4,
					index = new int[4] { 4, 5, 6, 7 }
				};
				CamItem[] mHighCamItem = HW.mHighCamItem;
				CamItem camItem = new CamItem
				{
					usage = "HIGH_CAM",
					type = "CAM_KSJ",
					num = 1
				};
				array = (camItem.index = new int[1]);
				mHighCamItem[1] = camItem;
				HW.mMFCamChnFn = new int[16]
				{
					0, 0, 0, 0, 1, 1, 1, 1, 0, 1,
					0, 0, 0, 0, 0, 0
				};
				HW.mHCamChnFn = new int[1] { 1 };
				HW.mHCamEn = new bool[2] { false, true };
				HW.mCamATotalNum = HW.mMarkCamItem[0].num + HW.mFastCamItem[0].num + HW.mMarkCamItem[1].num + HW.mFastCamItem[1].num;
				HW.mCamBTotalNum = HW.mHighCamItem[0].num + HW.mHighCamItem[1].num;
				HW.mAaxisSubDivision = 128;
				HW.mZaxisSubDivision = 32;
				HW.malgo2 = new MAlgo2[2]
				{
					new MAlgo2(),
					new MAlgo2()
				};
				HW.malgo2[0].ant[0] = AntType.Ant1010;
				HW.malgo2[0].emp_l[0] = 6;
				HW.malgo2[0].slt_l[0] = 15;
				HW.malgo2[0].emp_m[0] = 0;
				HW.malgo2[0].slt_r[0] = 15;
				HW.malgo2[0].emp_r[0] = 6;
				HW.malgo2[0].ant[1] = AntType.Ant1010;
				HW.malgo2[0].emp_l[1] = 6;
				HW.malgo2[0].slt_l[1] = 15;
				HW.malgo2[0].emp_m[1] = 0;
				HW.malgo2[0].slt_r[1] = 15;
				HW.malgo2[0].emp_r[1] = 6;
				HW.malgo2[0].mPlateNum = 48;
				HW.malgo2[0].mVabraNum = 35;
				HW.malgo2[1].ant[0] = AntType.Ant1010;
				HW.malgo2[1].emp_l[0] = 6;
				HW.malgo2[1].slt_l[0] = 15;
				HW.malgo2[1].emp_m[0] = 0;
				HW.malgo2[1].slt_r[0] = 15;
				HW.malgo2[1].emp_r[0] = 6;
				HW.malgo2[1].ant[1] = AntType.Ant1010;
				HW.malgo2[1].emp_l[1] = 6;
				HW.malgo2[1].slt_l[1] = 15;
				HW.malgo2[1].emp_m[1] = 0;
				HW.malgo2[1].slt_r[1] = 15;
				HW.malgo2[1].emp_r[1] = 6;
				HW.malgo2[1].mPlateNum = 48;
				HW.malgo2[1].mVabraNum = 35;
				break;
			}
			}
			HW.mStackNum = new int[HW.mFnNum][];
			HW.mMaxMultiFeederNum = new int[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				HW.malgo2[i].len[0] = HW.malgo2[i].emp_l[0] + HW.malgo2[i].slt_l[0] + HW.malgo2[i].emp_m[0] + HW.malgo2[i].slt_r[0] + HW.malgo2[i].emp_r[0];
				HW.malgo2[i].len[1] = HW.malgo2[i].emp_l[1] + HW.malgo2[i].slt_l[1] + HW.malgo2[i].emp_m[1] + HW.malgo2[i].slt_r[1] + HW.malgo2[i].emp_r[1];
				HW.mStackNum[i] = new int[3]
				{
					HW.malgo2[i].slt_l[0] + HW.malgo2[i].slt_r[0] + HW.malgo2[i].slt_l[1] + HW.malgo2[i].slt_r[1],
					HW.malgo2[i].mPlateNum,
					HW.malgo2[i].mVabraNum
				};
				if (HW.mSmtGenerationNo == 0)
				{
					HW.mMaxMultiFeederNum[i] = HW.mZnNum[i] / 2;
				}
				else
				{
					HW.mMaxMultiFeederNum[i] = HW.mZnNum[i];
				}
				if (HW.mZnNum[i] > 8 || HW.mTnNum > 2 || (HW.mTnNum > 1 && HW.mZnNum[1] > 8))
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Project Configuration Fail!!" : "工程选项失败，需要更新操作软件");
					return false;
				}
			}
			return true;
		}

		private void init_fixed_cam()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				for (int j = 0; j < HW.mFastLedNum; j++)
				{
					if (USR[i].mFastCamLightLevel[j] > 840 || USR[i].mFastCamLightLevel[j] < 1)
					{
						USR[i].mFastCamLightLevel[j] = 100;
					}
				}
				if (USR[i].mHighCamLightLevel > 840 || USR[i].mHighCamLightLevel < 1)
				{
					USR[i].mHighCamLightLevel = 100;
				}
				if (USR[i].mfcam_para == null)
				{
					USR[i].mfcam_para = new int[8][];
					for (int k = 0; k < 8; k++)
					{
						USR[i].mfcam_para[k] = new int[6];
						for (int l = 0; l < 6; l++)
						{
							USR[i].mfcam_para[k][l] = DEF.FCAM_PARA_DEFAULT[l];
						}
					}
				}
				if (USR[i].mMarkCamPara == null)
				{
					USR[i].mMarkCamPara = new MarkCamPara[20];
					for (int m = 0; m < 20; m++)
					{
						USR[i].mMarkCamPara[m] = new MarkCamPara();
					}
				}
				change_button_MarkCamPara_Text();
				if (USR[i].mFastCamDistortion == null)
				{
					USR[i].mFastCamDistortion = new double[8][];
					for (int n = 0; n < 8; n++)
					{
						USR[i].mFastCamDistortion[n] = new double[11]
						{
							275.0 / 288.0,
							0.0,
							0.0,
							0.0,
							0.0,
							0.0,
							0.0,
							0.0,
							0.0,
							0.0,
							0.0
						};
					}
				}
				for (int num = 0; num < 8; num++)
				{
					if (USR[i].mFastCamDistortion[num][0] > 1.0)
					{
						USR[i].mFastCamDistortion[num][0] = 275.0 / 288.0;
					}
				}
				if (USR[i].mHighCamDistortion == null)
				{
					USR[i].mHighCamDistortion = new double[11]
					{
						1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
						0.0
					};
				}
				if (USR[i].mMarkCamDistortion == null)
				{
					USR[i].mMarkCamDistortion = new double[11]
					{
						275.0 / 288.0,
						0.0,
						0.0,
						0.0,
						0.0,
						0.0,
						0.0,
						0.0,
						0.0,
						0.0,
						0.0
					};
				}
				if (USR[i].mMarkCamDistortion[0] > 1.0)
				{
					USR[i].mMarkCamDistortion[0] = 275.0 / 288.0;
				}
				if (USR[i].mfcam_rec_size <= 0)
				{
					USR[i].mfcam_rec_size = 140;
				}
				if (USR[i].mhcam_rec_size <= 0)
				{
					USR[i].mhcam_rec_size = 160;
				}
			}
		}

		public static void set_camera_parameter(int ch, int bri, int cont, int sat, int hue)
		{
			if (!mIsSimulation)
			{
				if (mJvsDriver == JvsDriver.JW6008HT)
				{
					JW6008HT.SetVideoPara(mJvs_Hd[ch], bri, cont / 2, sat, hue);
				}
				else if (mJvsDriver == JvsDriver.MV360)
				{
					AnologHD.SetVideoPara(mJvs_Hd[ch], (bri + 128) % 256, cont, sat, (hue + 128) % 256);
				}
				else if (mJvsDriver == JvsDriver.JVS960S)
				{
					CAM.JVS_SetVideoPara(ch, bri, cont, sat, hue, 128);
				}
				else
				{
					_ = mJvsDriver;
				}
			}
		}

		public static void set_camera_parameter(int ch, int[] para)
		{
			if (!mIsSimulation)
			{
				if (mJvsDriver == JvsDriver.JW6008HT)
				{
					JW6008HT.SetVideoPara(mJvs_Hd[ch], para[0], para[1] / 2, para[2] / 2, para[3]);
				}
				else if (mJvsDriver == JvsDriver.MV360)
				{
					AnologHD.SetVideoPara(mJvs_Hd[ch], (para[0] + 128) % 256, para[1], para[2], (para[3] + 128) % 256);
				}
				else if (mJvsDriver == JvsDriver.JVS960S)
				{
					CAM.JVS_SetVideoPara(ch, para[0], para[1], para[2], para[3], 128);
				}
				else
				{
					_ = mJvsDriver;
				}
			}
		}

		private void button_fcam_disable_Click(object sender, EventArgs e)
		{
			Form_CamDisable form_CamDisable = new Form_CamDisable(USR[mFn]);
			form_CamDisable.ShowDialog();
		}

		public static DeviceType GetDeviceType(string type)
		{
			for (int i = 0; i < 27; i++)
			{
				if (type == STR.DEVICE[i])
				{
					return (DeviceType)i;
				}
				if (type == STR.DEVICE_0[i])
				{
					return (DeviceType)i;
				}
				if (type == STR.DEVICE_YX[i])
				{
					return (DeviceType)i;
				}
			}
			return DeviceType.HW_8SX_72F;
		}

		public void load_FixedData_ConfigInit()
		{
			if (File.Exists("../configdata/CONFIG_INIT.bin"))
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream("../configdata/CONFIG_INIT.bin", FileMode.Open, FileAccess.Read, FileShare.None);
				USR_INIT = (USR_INIT_DATA)formatter.Deserialize(stream);
				stream.Close();
			}
			else
			{
				USR_INIT = new USR_INIT_DATA();
			}
			if (File.Exists("../configdata/FOOTPRINT_PATH.bin"))
			{
				IFormatter formatter2 = new BinaryFormatter();
				Stream stream2 = new FileStream("../configdata/FOOTPRINT_PATH.bin", FileMode.Open, FileAccess.Read, FileShare.None);
				FP_PATH = (FootPrintPath)formatter2.Deserialize(stream2);
				stream2.Close();
			}
			else
			{
				FP_PATH = new FootPrintPath();
			}
			if (FP_PATH.mFootprintLib_NameList == null)
			{
				FP_PATH.mFootprintLib_Index = USR_INIT.mFootprintLib_Index;
				FP_PATH.mFootprintLib_NameList = new BindingList<string>();
				if (USR_INIT.mFootprintLib_NameList != null)
				{
					for (int i = 0; i < USR_INIT.mFootprintLib_NameList.Count; i++)
					{
						USR_INIT.mFootprintLib_NameList.Add(USR_INIT.mFootprintLib_NameList[i]);
					}
				}
			}
			if (USR_INIT.mTrack == null)
			{
				USR_INIT.mTrack = new TrackPara();
			}
			if (USR_INIT.mTrack.delayL < 0.25f)
			{
				USR_INIT.mTrack.delayL = 0.25f;
			}
			if (USR_INIT.mTrack.delayM < 0.25f)
			{
				USR_INIT.mTrack.delayM = 0.25f;
			}
			if (USR_INIT.mTrack.delayR < 0.25f)
			{
				USR_INIT.mTrack.delayR = 0.25f;
			}
		}

		public void load_FixedData()
		{
			init_configdata_folder_part1();
			string path = "../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_FIXED.bin";
			if (!File.Exists(path))
			{
				return;
			}
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
			USR[0] = (USR_DATA)formatter.Deserialize(stream);
			stream.Close();
			if (HW.mFnNum == 2)
			{
				if (USR[0].mExUsr == null)
				{
					USR[0].mExUsr = new USR_DATA();
				}
				USR[1] = USR[0].mExUsr;
			}
			write_to_logFile("USR FIX CREATE SW HISTORY " + USR[0].mHistory);
			write_to_logFile("USR FIX CREATE SW HISTORY " + USR[0].mSwVersion);
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR[i].mfcam_para != null)
				{
					continue;
				}
				USR[i].mfcam_para = new int[8][];
				for (int j = 0; j < 8; j++)
				{
					USR[i].mfcam_para[j] = new int[6];
					for (int k = 0; k < 6; k++)
					{
						USR[i].mfcam_para[j][k] = DEF.FCAM_PARA_DEFAULT[k];
					}
				}
			}
			vsplus_usr_history_before_2020_7();
			vsplus_usr_history_before_2021_9();
		}

		public static void save_FixedData_ConfigInit()
		{
			USR_INIT.mHistory = 8;
			USR_INIT.mSwVersion = "20210712_8.8.0_T46_R";
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("../configdata/CONFIG_INIT.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, USR_INIT);
			stream.Close();
			IFormatter formatter2 = new BinaryFormatter();
			Stream stream2 = new FileStream("../configdata/FOOTPRINT_PATH.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter2.Serialize(stream2, FP_PATH);
			stream2.Close();
		}

		public static void save_FixedData()
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("../configdata/CONFIG_INIT.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, USR_INIT);
			stream.Close();
			IFormatter formatter2 = new BinaryFormatter();
			Stream stream2 = new FileStream("../configdata/FOOTPRINT_PATH.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter2.Serialize(stream2, FP_PATH);
			stream2.Close();
			for (int i = 0; i < HW.mFnNum; i++)
			{
				USR[i].mHistory = 8;
				USR[i].mSwVersion = "20210712_8.8.0_T46_R";
			}
			string path = "../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_FIXED.bin";
			IFormatter formatter3 = new BinaryFormatter();
			Stream stream3 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter3.Serialize(stream3, USR[0]);
			stream3.Close();
		}

		public void init_configdata_folder_part0()
		{
			if (!Directory.Exists("../configdata/"))
			{
				Directory.CreateDirectory("../configdata/");
			}
			if (!File.Exists("../configdata/CONFIG_INIT.bin"))
			{
				File.Copy("../configdata_golden/CONFIG_INIT.bin", "../configdata/CONFIG_INIT.bin");
			}
			if (!File.Exists("../configdata/CONPONENTS_LIB.bin"))
			{
				File.Copy("../configdata_golden/CONPONENTS_LIB.bin", "../configdata/CONPONENTS_LIB.bin");
			}
			if (!File.Exists("../configdata/FOOTPRINT_PATH.bin"))
			{
				File.Copy("../configdata_golden/FOOTPRINT_PATH.bin", "../configdata/FOOTPRINT_PATH.bin");
			}
			if (!File.Exists("../configdata/DefaultChips.footprint"))
			{
				File.Copy("../configdata_golden/DefaultChips.footprint", "../configdata/DefaultChips.footprint");
			}
		}

		public void init_configdata_folder_part1()
		{
			if (!File.Exists("../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_FIXED.bin"))
			{
				File.Copy("../configdata_golden/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_FIXED.bin", "../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_FIXED.bin");
			}
			if (!File.Exists("../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin"))
			{
				File.Copy("../configdata_golden/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin", "../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_DEFAULT.bin");
			}
			if (!File.Exists("../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_FACTORY.bin"))
			{
				File.Copy("../configdata_golden/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_FACTORY.bin", "../configdata/" + STR.DEV_[(int)USR_INIT.mDeviceType] + "_CONFIG_USR2_FACTORY.bin");
			}
		}

		private void init_fixed_onlyonce()
		{
			init_fixed_basic();
			init_fixed_cam();
			init_fixed_delta();
		}

		private void button_test_hv_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(thd_test_hv);
			thread.IsBackground = true;
			thread.Start();
		}

		private void thd_test_hv()
		{
			MessageBox.Show(HV.InitDSPs().ToString());
		}

		private Circle fake_FittingCircle(List<s_POINT_f> pPointList)
		{
			Circle result = default(Circle);
			if (pPointList.Count < 1)
			{
				return result;
			}
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < pPointList.Count; i++)
			{
				num += pPointList[i].x;
				num2 += pPointList[i].y;
			}
			result.X = num / (float)pPointList.Count;
			result.Y = num2 / (float)pPointList.Count;
			result.R = 0.0;
			return result;
		}

		private Circle FittingCircle(List<s_POINT_f> pPointList)
		{
			Circle result = default(Circle);
			if (pPointList.Count < 3)
			{
				return result;
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			for (int i = 0; i < pPointList.Count; i++)
			{
				num += (double)pPointList[i].x;
				num2 += (double)pPointList[i].y;
				num3 += (double)(pPointList[i].x * pPointList[i].x);
				num4 += (double)(pPointList[i].y * pPointList[i].y);
				num5 += (double)(pPointList[i].x * pPointList[i].x * pPointList[i].x);
				num6 += (double)(pPointList[i].y * pPointList[i].y * pPointList[i].y);
				num7 += (double)(pPointList[i].x * pPointList[i].y);
				num8 += (double)(pPointList[i].x * pPointList[i].y * pPointList[i].y);
				num9 += (double)(pPointList[i].x * pPointList[i].x * pPointList[i].y);
			}
			double num10 = pPointList.Count;
			double num11 = num10 * num3 - num * num;
			double num12 = num10 * num7 - num * num2;
			double num13 = num10 * num5 + num10 * num8 - (num3 + num4) * num;
			double num14 = num10 * num4 - num2 * num2;
			double num15 = num10 * num9 + num10 * num6 - (num3 + num4) * num2;
			double num16 = (num15 * num12 - num13 * num14) / (num11 * num14 - num12 * num12);
			double num17 = (num15 * num11 - num13 * num12) / (num12 * num12 - num14 * num11);
			double num18 = (0.0 - (num16 * num + num17 * num2 + num3 + num4)) / num10;
			result.X = num16 / -2.0;
			result.Y = num17 / -2.0;
			result.R = Math.Sqrt(num16 * num16 + num17 * num17 - 4.0 * num18) / 2.0;
			return result;
		}

		public static Circle FittingCircle(BindingList<CvPoint> pPointList)
		{
			Circle result = default(Circle);
			if (pPointList.Count < 3)
			{
				return result;
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			for (int i = 0; i < pPointList.Count; i++)
			{
				num += (double)pPointList[i].X;
				num2 += (double)pPointList[i].Y;
				num3 += (double)(pPointList[i].X * pPointList[i].X);
				num4 += (double)(pPointList[i].Y * pPointList[i].Y);
				num5 += (double)(pPointList[i].X * pPointList[i].X * pPointList[i].X);
				num6 += (double)(pPointList[i].Y * pPointList[i].Y * pPointList[i].Y);
				num7 += (double)(pPointList[i].X * pPointList[i].Y);
				num8 += (double)(pPointList[i].X * pPointList[i].Y * pPointList[i].Y);
				num9 += (double)(pPointList[i].X * pPointList[i].X * pPointList[i].Y);
			}
			double num10 = pPointList.Count;
			double num11 = num10 * num3 - num * num;
			double num12 = num10 * num7 - num * num2;
			double num13 = num10 * num5 + num10 * num8 - (num3 + num4) * num;
			double num14 = num10 * num4 - num2 * num2;
			double num15 = num10 * num9 + num10 * num6 - (num3 + num4) * num2;
			double num16 = (num15 * num12 - num13 * num14) / (num11 * num14 - num12 * num12);
			double num17 = (num15 * num11 - num13 * num12) / (num12 * num12 - num14 * num11);
			double num18 = (0.0 - (num16 * num + num17 * num2 + num3 + num4)) / num10;
			result.X = num16 / -2.0;
			result.Y = num17 / -2.0;
			result.R = Math.Sqrt(num16 * num16 + num17 * num17 - 4.0 * num18) / 2.0;
			return result;
		}

		public static ImageVisual_Result ImageVisual(int fn, VISUAL_MODE mode, CameraType cam, VisualType visual, int cur_range, int cur_threshold, int zno, int xoffset, int yoffset, float angle, ref VISUAL_RESULT visual_result)
		{
			Bitmap bitmap = null;
			bool is_test = visual_result.is_test;
			bool flag = mode >= VISUAL_MODE.LOOP_HALF_COMMON;
			mode &= (VISUAL_MODE)(-129);
			ImageVisual_Result result = ImageVisual_Result.Err;
			float num = 2.7f;
			float num2 = 0f;
			int num3 = 50;
			num3 = USR[fn].mTest_Pno;
			if ((cam == CameraType.Fast || cam == CameraType.Mark) && cur_range > 360)
			{
				cur_range = 360;
			}
			int num4 = 0;
			bool flag2 = false;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			BOX2D box = default(BOX2D);
			PointF[] array = new PointF[40];
			for (int i = 0; i < 40; i++)
			{
				array[i] = default(PointF);
				array[i].X = 0f;
				array[i].Y = 0f;
			}
			PointF[] array2 = new PointF[4];
			for (int j = 0; j < 4; j++)
			{
				array2[j] = default(PointF);
			}
			int num10 = 0;
			float num11 = 0f;
			int num12 = cur_threshold;
			VisInput vinput = default(VisInput);
			int_2d int_2d = get_vmtab_visindex(visual);
			if (int_2d.a == -1 && visual != VisualType.MarkAutoPikXY)
			{
				return result;
			}
			VisOutput voutput = new VisOutput(0);
			Point center;
			switch (cam)
			{
			case CameraType.Mark:
			{
				_ = zno % 2;
				num = USR[fn].mMarkCamRatio[0];
				num4 = HW.mMarkCamItem[fn].index[0];
				flag2 = true;
				num5 = mJvs_usrWidth;
				num6 = mJvs_usrHeight;
				num7 = mJvs_rawWidth;
				num8 = mJvs_rawHeight;
				center = new Point(num5 / 2 + xoffset, num6 / 2 + yoffset);
				num3 = 20;
				if (mode != VISUAL_MODE.NOSTILL)
				{
					startMarkStill_andWait(fn);
				}
				newBitmaps_des[fn][zno] = new Bitmap(num5, num6);
				Rectangle destRect = new Rectangle(0, 0, num5, num6);
				Rectangle srcRect = new Rectangle((num7 - num5) / 2 + num9, 0, num5, num8);
				Graphics graphics = Graphics.FromImage(newBitmaps_des[fn][zno]);
				if (flag2)
				{
					graphics.CompositingQuality = CompositingQuality.HighQuality;
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				}
				graphics.DrawImage(mJVSBitmap[num4], destRect, srcRect, GraphicsUnit.Pixel);
				graphics.Dispose();
				PixelFormat pixelFormat = PixelFormat.Format32bppRgb;
				int pixelbit = 32;
				if (mIsSimulation)
				{
					pixelFormat = PixelFormat.Format32bppRgb;
				}
				switch (pixelFormat)
				{
				case PixelFormat.Format32bppRgb:
					pixelbit = 32;
					break;
				case PixelFormat.Format24bppRgb:
					pixelbit = 24;
					break;
				}
				BitmapData bitmapData2 = newBitmaps_des[fn][zno].LockBits(new Rectangle(0, 0, newBitmaps_des[fn][zno].Width, newBitmaps_des[fn][zno].Height), ImageLockMode.ReadWrite, pixelFormat);
				char c = '\0';
				c = (char)(USR[fn].mIsFastCamOppositeVisual ? 1u : 0u);
				if (mode == VISUAL_MODE.AUTODELTA_MARK)
				{
					num3 = USR[fn].mTest_Pno;
					c = '\u0001';
				}
				switch (visual)
				{
				case VisualType.Normal:
				case VisualType.NoAngle:
				case VisualType.Circle:
					vinput.pixfmt = (int)get_vmtab_pixformat(pixelFormat);
					vinput.w_use = num5;
					vinput.h_use = num6;
					vinput.is_opposite = c;
					vinput.is_debug = (mDebug_Factory ? 1 : 0);
					vinput.scan_center_x = center.X;
					vinput.scan_center_y = center.Y;
					vinput.scan_r = cur_range;
					vinput.threshold = cur_threshold;
					vinput.pixel_scale = num;
					vinput.chip_l = visual_result.box_width;
					vinput.chip_w = visual_result.box_height;
					vinput.footprint_pinmode = visual_result.pinconfig.pin_mode;
					vinput.pin0_counts = 1;
					vinput.pin0_l = visual_result.pinconfig.pin_length;
					vinput.pin0_w = visual_result.pinconfig.pin_width;
					vinput.pin0_offset = 0f;
					vinput.pin0_dis = visual_result.pinconfig.pin_side_dis;
					vmLib[int_2d.a].nmoon_birds_visualrun(bitmapData2.Scan0, (int)visual, ref vinput, ref voutput);
					box.center.X = voutput.box2d_center_x;
					box.center.Y = voutput.box2d_center_y;
					box.size.Width = voutput.box2d_w;
					box.size.Height = voutput.box2d_h;
					box.angle = voutput.box2d_angel;
					num12 = voutput.threshold;
					num10 = voutput.pno;
					break;
				case VisualType.MarkAutoPikXY:
				{
					char isoppovisual = (char)xoffset;
					box.size.Width = visual_result.box_width * 100f / USR[fn].mMarkCamRatio[0] * 1.1f;
					box.size.Height = visual_result.box_height * 100f / USR[fn].mMarkCamRatio[0] * 1.1f;
					num10 = moon_visual_autopixXY_YK(bitmapData2.Scan0, pixelbit, new Size(num5, num6), center, cur_range, ref box, ref array[0], isoppovisual, mDebug_Factory);
					break;
				}
				}
				newBitmaps_des[fn][zno].UnlockBits(bitmapData2);
				break;
			}
			case CameraType.Fast:
			{
				num4 = HW.mFastCamItem[fn].index[zno];
				flag2 = true;
				num5 = mJvs_usrWidth;
				num6 = mJvs_usrHeight;
				num7 = mJvs_rawWidth;
				num8 = mJvs_rawHeight;
				center = new Point(num5 / 2 + xoffset, num6 / 2 + yoffset);
				if (mode != VISUAL_MODE.AUTODETECT)
				{
					num9 = USR[fn].mFastCamCenterDeltaX[0][zno];
					num = USR[fn].mFastCamRatio[0][zno];
					num2 = USR[fn].mFastCamRatioExt[0][zno];
					center = new Point((int)USR[fn].mFastCamCenterPosition[0][zno].X + xoffset, (int)USR[fn].mFastCamCenterPosition[0][zno].Y + yoffset);
					if (USR2 != null && USR2[fn] != null)
					{
						_ = USR2[fn].mFastCamStillDelay[0];
						num3 = USR2[fn].mFastCamMinValidPixel[0][zno];
					}
				}
				if (mode != VISUAL_MODE.NOSTILL)
				{
					startFastStill_andWait(cam, fn, zno);
				}
				PixelFormat pixelFormat2 = PixelFormat.Format32bppRgb;
				if (mIsSimulation)
				{
					pixelFormat2 = PixelFormat.Format32bppRgb;
				}
				if (pixelFormat2 != PixelFormat.Format32bppRgb)
				{
					_ = 137224;
				}
				newBitmaps_des[fn][zno] = new Bitmap(num5, num6);
				Rectangle destRect2 = new Rectangle(0, 0, num5, num6);
				Rectangle srcRect2 = new Rectangle((num7 - num5) / 2 + num9, 0, num5, num8);
				Graphics graphics2 = Graphics.FromImage(newBitmaps_des[fn][zno]);
				if (flag2)
				{
					graphics2.CompositingQuality = CompositingQuality.HighQuality;
					graphics2.SmoothingMode = SmoothingMode.HighQuality;
					graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
				}
				graphics2.DrawImage(mJVSBitmap[num4], destRect2, srcRect2, GraphicsUnit.Pixel);
				graphics2.Dispose();
				BitmapData bitmapData3 = newBitmaps_des[fn][zno].LockBits(new Rectangle(0, 0, newBitmaps_des[fn][zno].Width, newBitmaps_des[fn][zno].Height), ImageLockMode.ReadWrite, pixelFormat2);
				if (visual == VisualType.Normal || visual == VisualType.NoAngle || visual == VisualType.Draft || visual == VisualType.D45Angle || visual == VisualType.Ellipe || visual == VisualType.Rectangle || visual == VisualType.Circle || visual == VisualType.NonpolarHn || visual == VisualType.ConvexBGA || visual == VisualType.SOT23_3 || visual == VisualType.TranRec0 || visual == VisualType.TranRec1 || visual == VisualType.Special_Rec2 || visual == VisualType.YIX_ICNT7183 || visual == VisualType.YIX_BF5325 || visual == VisualType.FootPrint_R)
				{
					vinput.pixfmt = (int)get_vmtab_pixformat(pixelFormat2);
					vinput.w_use = num5;
					vinput.h_use = num6;
					vinput.is_opposite = (USR[fn].mIsFastCamOppositeVisual ? 1 : 0);
					vinput.is_debug = (mDebug_Factory ? 1 : 0);
					vinput.scan_center_x = center.X;
					vinput.scan_center_y = center.Y;
					vinput.scan_r = cur_range;
					vinput.threshold = cur_threshold;
					vinput.pixel_scale = num;
					vinput.chip_l = visual_result.box_width;
					vinput.chip_w = visual_result.box_height;
					if (visual == VisualType.FootPrint_R)
					{
						common_set_pinconfig2visinput(ref vinput, visual_result.pinconfig);
					}
					vmLib[int_2d.a].nmoon_birds_visualrun(bitmapData3.Scan0, (int)visual, ref vinput, ref voutput);
					box.center.X = voutput.box2d_center_x;
					box.center.Y = voutput.box2d_center_y;
					box.size.Width = voutput.box2d_w;
					box.size.Height = voutput.box2d_h;
					box.angle = voutput.box2d_angel;
					num12 = voutput.threshold;
					num10 = voutput.pno;
				}
				newBitmaps_des[fn][zno].UnlockBits(bitmapData3);
				break;
			}
			case CameraType.High:
			{
				num7 = 1944;
				num8 = 1944;
				if (mode != VISUAL_MODE.AUTODETECT && USR2[fn] != null)
				{
					_ = USR2[fn].mHighCamStillDelay[0][zno];
					num3 = USR2[fn].mHighCamMinValidPixel[0][zno];
					num2 = USR[fn].mHighCamRatioExt[0];
					num = USR[fn].mHighCamRatio[0];
				}
				_ = num5 * num6 * 24 / 8;
				BitmapData bitmapData;
				if (mode == VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE || (mode == VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE_PRICISE_SECOND && USR2 != null))
				{
					num5 = ((cur_range * 2 + 50) / 4 + 1) * 4;
					if (num5 > num7)
					{
						num5 = num7;
					}
					num6 = ((cur_range * 2 + 50) / 4 + 1) * 4;
					if (num6 > num8)
					{
						num6 = num8;
					}
					center = new Point(num5 / 2, num6 / 2);
					CAM.KSJ_CaptureSetFieldOfView(0, 324 + (num7 - num5) / 2, (num8 - num6) / 2, num5, num6, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE, CAM.KSJ_ADDRESSMODE.KSJ_SKIPNONE);
					msdelay(USR2[fn].mHighCamStillDelay[0][zno]);
					newBitmaps_des[fn][zno] = new Bitmap(num5, num6, PixelFormat.Format24bppRgb);
					bitmapData = newBitmaps_des[fn][zno].LockBits(new Rectangle(0, 0, num5, num6), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
					CAM.KSJ_CaptureRgbData(0, bitmapData.Scan0);
					bKSJCameraRecived[zno] = true;
				}
				else
				{
					num5 = 1944;
					num6 = 1944;
					center = new Point(num5 / 2 + xoffset, num6 / 2 + yoffset);
					if (mode != VISUAL_MODE.NOSTILL)
					{
						startKSJStillAndWait(HW.mHighCamItem[fn].index[0]);
					}
					bKSJCameraRecived[zno] = true;
					newBitmaps_des[fn][zno] = new Bitmap(num7, num8);
					bitmapData = newBitmaps_des[fn][zno].LockBits(new Rectangle(0, 0, num7, num8), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
					Marshal.Copy(pKSJBuffer[HW.mHighCamItem[fn].index[0]], 0, bitmapData.Scan0, num7 * num8 * 3);
				}
				if (visual == VisualType.Normal || visual == VisualType.NoAngle || visual == VisualType.Draft || visual == VisualType.D45Angle || visual == VisualType.Ellipe || visual == VisualType.Rectangle || visual == VisualType.Circle || visual == VisualType.NonpolarHn || visual == VisualType.ConvexBGA || visual == VisualType.SOT23_3 || visual == VisualType.TranRec0 || visual == VisualType.TranRec1 || visual == VisualType.Special_Rec2 || visual == VisualType.YIX_ICNT7183 || visual == VisualType.YIX_BF5325)
				{
					vinput.pixfmt = (int)get_vmtab_pixformat(PixelFormat.Format24bppRgb);
					vinput.w_use = num5;
					vinput.h_use = num6;
					vinput.is_opposite = (USR[fn].mIsFastCamOppositeVisual ? 1 : 0);
					vinput.is_debug = (mDebug_Factory ? 1 : 0);
					vinput.scan_center_x = center.X;
					vinput.scan_center_y = center.Y;
					vinput.scan_r = cur_range;
					vinput.threshold = cur_threshold;
					vinput.pixel_scale = num;
					vinput.chip_l = visual_result.box_width;
					vinput.chip_w = visual_result.box_height;
					vmLib[int_2d.a].nmoon_birds_visualrun(bitmapData.Scan0, (int)visual, ref vinput, ref voutput);
					box.center.X = voutput.box2d_center_x;
					box.center.Y = voutput.box2d_center_y;
					box.size.Width = voutput.box2d_w;
					box.size.Height = voutput.box2d_h;
					box.angle = voutput.box2d_angel;
					num12 = voutput.threshold;
					num10 = voutput.pno;
				}
				newBitmaps_des[fn][zno].UnlockBits(bitmapData);
				break;
			}
			default:
				return result;
			}
			float num13 = (flag ? (box.angle - angle) : (box.angle - 0f));
			if (visual != VisualType.SOT23_3 && visual != VisualType.NonpolarHn && visual != VisualType.YIX_ICNT7183 && visual != VisualType.YIX_BF5325 && visual != VisualType.Rectangle)
			{
				num13 = format_angle(num13, -45f, 45f, 90f);
			}
			if (visual != VisualType.SOT23_3 && visual != VisualType.NonpolarHn && visual != VisualType.Draft && mode != VISUAL_MODE.AUTODETECT && mode != VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE_PRICISE_SECOND && mode != VISUAL_MODE.HIGHCAM_SMT_PRICISE_SECOND && visual != VisualType.YIX_ICNT7183 && visual != VisualType.YIX_BF5325 && visual != VisualType.Rectangle && ((num13 > 40f && num13 < 50f) || (num13 < -40f && num13 > -50f)))
			{
				result = ImageVisual_Result.Err;
			}
			result = ((num10 <= num3) ? ((Math.Abs(num10) >= num3) ? ImageVisual_Result.Err : ImageVisual_Result.NoneChip) : ImageVisual_Result.OK);
			double num14 = 0.0;
			num14 = ((!flag) ? (((double)(0f - angle) + (double)num13 - (double)num2) * Math.PI / 180.0) : ((double)(num13 - num2) * Math.PI / 180.0));
			if (mode == VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE_PRICISE_SECOND || mode == VISUAL_MODE.HIGHCAM_SMT_PRICISE_SECOND)
			{
				num14 = 0.0;
			}
			double num15 = Math.Sin(num14);
			double num16 = Math.Cos(num14);
			double num17 = box.center.X - (float)center.X;
			double num18 = box.center.Y - (float)center.Y;
			if (cam == CameraType.High)
			{
				num17 = box.center.X - (float)(num5 / 2);
				num18 = box.center.Y - (float)(num6 / 2);
			}
			double num19 = num17 * num16 + num18 * num15;
			double num20 = num18 * num16 - num17 * num15;
			if (num10 <= num3)
			{
				box.center.X = num5 / 2;
				box.center.Y = num6 / 2;
				num19 = 0.0;
				num20 = 0.0;
			}
			bool flag3 = false;
			if (uc_VisualShowSmt[fn] != null && !uc_VisualShowSmt[fn].IsDisposed)
			{
				flag3 = true;
			}
			if (is_smt_test || mode != VISUAL_MODE.NOSTILL || flag3)
			{
				is_smt_test = false;
				Graphics graphics3 = Graphics.FromImage(newBitmaps_des[fn][zno]);
				Pen pen = new Pen(Color.Yellow);
				if (cam == CameraType.High)
				{
					graphics3.DrawLine(pen, 0, num6 / 2, num5, num6 / 2);
					graphics3.DrawLine(pen, num5 / 2, 0, num5 / 2, num6);
					graphics3.DrawEllipse(pen, num5 / 2 + xoffset - cur_range, num6 / 2 + yoffset - cur_range, cur_range * 2, cur_range * 2);
				}
				else
				{
					graphics3.DrawLine(pen, 0, center.Y, num5, center.Y);
					graphics3.DrawLine(pen, center.X, 0, center.X, num5);
					graphics3.DrawEllipse(pen, center.X - cur_range, center.Y - cur_range, cur_range * 2, cur_range * 2);
				}
				VisualResultString0 visualResultString = new VisualResultString0();
				if (num10 > num3)
				{
					visualResultString.state = ((USR_INIT.mLanguage == 2) ? "Detect chip successfully!" : "已经识别出元件！");
					pen.Color = ((cam == CameraType.High) ? Color.FromArgb(255, 60, 140) : Color.FromArgb(0, 255, 0));
					pen.Width = ((cam == CameraType.High) ? 5 : 2);
					if (visual == VisualType.MarkAutoPikXY)
					{
						for (int k = 0; k < 10 && (array[k * 4].X != 0f || array[k * 4].Y != 0f); k++)
						{
							pen.Color = ((cam == CameraType.High) ? Color.FromArgb(255, 60, 140) : Color.FromArgb(0, 255, 0));
							pen.Width = ((cam == CameraType.High) ? 5 : 2);
							if (visual == VisualType.FootPrint_R && cam == CameraType.Fast)
							{
								pen.Color = ((k == 0) ? Color.FromArgb(0, 255, 0) : Color.FromArgb(255, 0, 0));
								pen.Width = ((k == 0) ? 3 : 2);
							}
							graphics3.DrawLine(pen, array[k * 4].X, array[k * 4].Y, array[k * 4 + 1].X, array[k * 4 + 1].Y);
							graphics3.DrawLine(pen, array[k * 4 + 1].X, array[k * 4 + 1].Y, array[k * 4 + 2].X, array[k * 4 + 2].Y);
							graphics3.DrawLine(pen, array[k * 4 + 2].X, array[k * 4 + 2].Y, array[k * 4 + 3].X, array[k * 4 + 3].Y);
							graphics3.DrawLine(pen, array[k * 4 + 3].X, array[k * 4 + 3].Y, array[k * 4].X, array[k * 4].Y);
							pen.Color = Color.FromArgb(0, 0, 255);
							pen.Width = ((cam == CameraType.High) ? 5 : 2);
							if (visual != VisualType.FootPrint_R || k <= 0)
							{
								graphics3.DrawLine(pen, (array[k * 4].X + array[k * 4 + 1].X - 0f) / 2f, (array[k * 4].Y + array[k * 4 + 1].Y) / 2f, (array[k * 4 + 2].X + array[k * 4 + 3].X - 0f) / 2f, (array[k * 4 + 2].Y + array[k * 4 + 3].Y) / 2f);
								graphics3.DrawLine(pen, (array[k * 4 + 1].X + array[k * 4 + 2].X - 0f) / 2f, (array[k * 4 + 1].Y + array[k * 4 + 2].Y) / 2f, (array[k * 4 + 3].X + array[k * 4].X - 0f) / 2f, (array[k * 4 + 3].Y + array[k * 4].Y) / 2f);
							}
						}
					}
				}
				else
				{
					visualResultString.state = ((USR_INIT.mLanguage == 2) ? "Cannot detect chip!" : "未能正确识别元件！");
				}
				pen.Dispose();
				graphics3.Dispose();
				if (is_test)
				{
					static_this.Invoke((MethodInvoker)delegate
					{
						newBitmaps_des[fn][zno].RotateFlip(RotateFlipType.Rotate180FlipX);
						if (mBitmapVisualTest[fn] == null)
						{
							mBitmapVisualTest[fn] = new Bitmap(newBitmaps_des[fn][zno].Size.Width, newBitmaps_des[fn][zno].Size.Height);
						}
						else if (mBitmapVisualTest[fn].Size.Width != newBitmaps_des[fn][zno].Size.Width && mBitmapVisualTest[fn].Size.Height != newBitmaps_des[fn][zno].Size.Height)
						{
							mBitmapVisualTest[fn].Dispose();
							mBitmapVisualTest[fn] = new Bitmap(newBitmaps_des[fn][zno].Size.Width, newBitmaps_des[fn][zno].Size.Height);
						}
						Rectangle destRect3 = new Rectangle(0, 0, mBitmapVisualTest[fn].Size.Width, mBitmapVisualTest[fn].Size.Height);
						Rectangle srcRect3 = new Rectangle(0, 0, newBitmaps_des[fn][zno].Size.Width, newBitmaps_des[fn][zno].Size.Height);
						Graphics graphics5 = Graphics.FromImage(mBitmapVisualTest[fn]);
						graphics5.CompositingQuality = CompositingQuality.HighQuality;
						graphics5.SmoothingMode = SmoothingMode.HighQuality;
						graphics5.InterpolationMode = InterpolationMode.HighQualityBicubic;
						graphics5.DrawImage(newBitmaps_des[fn][zno], destRect3, srcRect3, GraphicsUnit.Pixel);
						graphics5.Dispose();
						pictureBox_VisualTest[fn].Image = mBitmapVisualTest[fn];
						if (mIsVisualRunning)
						{
							Rectangle destRect4 = new Rectangle(0, 0, mBitmapVisualRunning[fn].Size.Width, mBitmapVisualRunning[fn].Size.Height);
							Rectangle srcRect4 = new Rectangle(0, 0, newBitmaps_des[fn][zno].Size.Width, newBitmaps_des[fn][zno].Size.Height);
							Graphics graphics6 = Graphics.FromImage(mBitmapVisualRunning[fn]);
							graphics6.CompositingQuality = CompositingQuality.HighQuality;
							graphics6.SmoothingMode = SmoothingMode.HighQuality;
							graphics6.InterpolationMode = InterpolationMode.HighQualityBicubic;
							graphics6.DrawImage(newBitmaps_des[fn][zno], destRect4, srcRect4, GraphicsUnit.Pixel);
							graphics6.Dispose();
							pictureBox_visualrunning[fn].Image = mBitmapVisualRunning[fn];
						}
					});
				}
				float num21 = box.size.Width * num / 100f;
				float num22 = box.size.Height * num / 100f;
				visualResultString.size = box.size.Width.ToString("F2") + "x" + box.size.Height.ToString("F2") + " @ " + num10 + "  " + num21.ToString("F2") + "x" + num22.ToString("F2");
				visualResultString.post = "X:" + (box.center.X - (float)(num5 / 2)).ToString("F3") + " Y:" + (box.center.Y - (float)(num6 / 2)).ToString("F3");
				visualResultString.angle = num13.ToString("F3") + ((num2 >= 0f) ? (" - " + num2) : (" + " + (0f - num2))) + " °";
				visualResultString.paost = "X:" + (num19 * 1.0).ToString("F3") + " Y:" + (num20 * 1.0).ToString("F3");
				visualResultString.sost = "X:" + ((0.0 - num19) * (double)num).ToString("F3") + " Y:" + ((0.0 - num20) * (double)num).ToString("F3") + " A:" + (0f - num13).ToString("F3") + "°";
				visualResultString.threshold = "THRHD:" + num12;
				if (visual == VisualType.TriAG)
				{
					visualResultString.angle_t = num11.ToString();
				}
				pictureBox_VisualTest[fn].Tag = visualResultString;
				if (uc_VisualShowSmt[fn] != null && !uc_VisualShowSmt[fn].IsDisposed)
				{
					bool isfull = false;
					switch (cam)
					{
					case CameraType.Fast:
						if (cur_range > 250)
						{
							isfull = true;
						}
						break;
					case CameraType.High:
						if (cur_range > 800)
						{
							isfull = true;
						}
						break;
					}
					uc_VisualShowSmt[fn].ShowDetails(newBitmaps_des[fn][zno], zno, visual_result.vis_info, isfull);
				}
				if (is_test && mVisualForm != null && mVisualForm[fn] != null && !mVisualForm[fn].IsDisposed)
				{
					static_this.Invoke((MethodInvoker)delegate
					{
						mVisualForm[fn].ShowDetails(newBitmaps_des[fn][zno], (VisualResultString0)pictureBox_VisualTest[fn].Tag);
					});
				}
			}
			if (result != 0 && USR[fn].mDebug_IsSaveErrBitmap)
			{
				bitmap = null;
				switch (cam)
				{
				case CameraType.Fast:
					bitmap = new Bitmap(mJVSBitmap[num4]);
					break;
				case CameraType.High:
				{
					bitmap = new Bitmap(num7, num8);
					BitmapData bitmapData4 = bitmap.LockBits(new Rectangle(0, 0, num7, num8), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
					Marshal.Copy(pKSJBuffer[HW.mHighCamItem[fn].index[0]], 0, bitmapData4.Scan0, num7 * num8 * 3);
					bitmap.UnlockBits(bitmapData4);
					break;
				}
				}
				if (bitmap != null)
				{
					string text = "C:/SmtLog/Picture/err_";
					DateTime now = DateTime.Now;
					string text2 = text;
					text = text2 + (zno + 1) + "_" + now.Year + now.Month.ToString("D2") + now.Day.ToString("D2") + "_" + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2") + "_" + now.Millisecond.ToString("D3") + ".jpg";
					Graphics graphics4 = Graphics.FromImage(bitmap);
					graphics4.CompositingQuality = CompositingQuality.HighQuality;
					graphics4.SmoothingMode = SmoothingMode.HighQuality;
					graphics4.InterpolationMode = InterpolationMode.HighQualityBicubic;
					Brush brush = new SolidBrush(Color.FromArgb(0, 255, 0));
					string text3 = "";
					text2 = text3;
					text3 = text2 + "时间 " + now.Year + "年" + now.Month.ToString("D2") + "月" + now.Day.ToString("D2") + "日" + now.Hour.ToString("D2") + "时" + now.Minute.ToString("D2") + "分" + now.Second.ToString("D2") + "." + now.Millisecond.ToString("D3") + "秒";
					text3 += Environment.NewLine;
					text3 += "光源 ";
					switch (cam)
					{
					case CameraType.Fast:
					{
						for (int l = 0; l < HW.mFastLedNum; l++)
						{
							int num24 = 0;
							if (USR2 != null)
							{
								num24 = USR2[fn].mFastCamLightLevel[0][l];
							}
							text3 = text3 + num24 + " ";
						}
						break;
					}
					case CameraType.High:
					{
						int num23 = 0;
						if (USR2 != null)
						{
							num23 = USR2[fn].mHighCamLightLevel[0];
						}
						text3 += num23;
						break;
					}
					}
					text3 += Environment.NewLine;
					text3 += "软件版本 20210712_8.8.0_T46_R";
					text3 = text3 + "门限阈值 " + cur_threshold + Environment.NewLine;
					text3 = text3 + "扫描半径 " + cur_range + Environment.NewLine;
					text3 = text3 + "有效像素 " + num3 + Environment.NewLine;
					text3 = text3 + "识别方式 " + flag + Environment.NewLine;
					text3 = text3 + "吸嘴 " + (zno + 1) + Environment.NewLine;
					text3 = text3 + STR.CAMERA_STR[(int)cam][0] + Environment.NewLine;
					text3 = text3 + STR.VISUAL_STR[(int)visual][0] + Environment.NewLine;
					text3 = text3 + "已贴数量 " + (mSmtCurAllProjectChips_Index + 1);
					for (int m = 0; m < 22; m++)
					{
						text3 += Environment.NewLine;
					}
					text3 = text3 + "角度 " + num13.ToString("F2") + Environment.NewLine;
					text3 = text3 + "像素 " + num10 + Environment.NewLine;
					text3 = text3 + "阈值 " + num12 + Environment.NewLine;
					text2 = text3;
					text3 = text2 + "长宽 " + box.size.Width.ToString("F2") + "x" + box.size.Height.ToString("F2") + Environment.NewLine;
					text2 = text3;
					text3 = text2 + "中心 " + box.center.X.ToString("F2") + "x" + box.center.Y.ToString("F2") + Environment.NewLine;
					graphics4.DrawString(text3, new Font("", 10.5f), brush, 2f, 2f);
					if (!Directory.Exists("C:/SmtLog/Picture/"))
					{
						Directory.CreateDirectory("C:/SmtLog/Picture/");
					}
					try
					{
						bitmap.Save(text, ImageFormat.Jpeg);
					}
					catch (Exception)
					{
						write_to_logFile_EXCEPTION(" ImageVisual 1");
					}
					brush.Dispose();
					graphics4.Dispose();
					bitmap.Dispose();
				}
			}
			visual_result.move_x = (int)Math.Round((0.0 - num19) * (double)num, 0);
			visual_result.move_y = (int)Math.Round((0.0 - num20) * (double)num, 0);
			visual_result.move_a = AngleToSteps(0f - (num13 - num2));
			visual_result.move_angle = 0f - (num13 - num2);
			visual_result.pno = num10;
			visual_result.box_center_x = box.center.X;
			visual_result.box_center_y = box.center.Y;
			visual_result.box_width = box.size.Width;
			visual_result.box_height = box.size.Height;
			visual_result.px = (float)num17;
			visual_result.py = (float)num18;
			if (visual == VisualType.Draft)
			{
				visual_result.move_x = 0;
				visual_result.move_y = 0;
				visual_result.move_a = 0;
			}
			if (mIsSimulation)
			{
				if (mIsDebug_Visual)
				{
					return result;
				}
				bool is_ignore_visualfail = false;
				static_this.Invoke((MethodInvoker)delegate
				{
					is_ignore_visualfail = uc_job[fn].get_simulate_visualpass();
				});
				if (is_ignore_visualfail)
				{
					return ImageVisual_Result.OK;
				}
			}
			return result;
		}

		private void thd_visual_fastcam_single_find_center()
		{
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			if (ImageVisual(mFn, VISUAL_MODE.AUTODETECT, CameraType.Fast, VisualType.Circle, USR[mFn].mfcam_scanr, USR[mFn].mfcam_threshold, mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
			{
				MessageBoxShow_OK((USR_INIT.mLanguage == 2) ? ("Cannot find Noz" + (mZn[mFn] + 1)) : ("未发现" + (mZn[mFn] + 1) + "号吸嘴，请调整相关参数（比如灯光强度、将吸嘴靠近灯源中心、将吸嘴更换为实心吸嘴）"));
				return;
			}
			MessageBoxShow_OK("okokok!");
			save_FixedData();
		}

		private void button_algorithm_debug_running_Click(object sender, EventArgs e)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(USR[mFn].mDebug_PicFolder);
			if (!Directory.Exists(USR[mFn].mDebug_PicFolder))
			{
				return;
			}
			FileInfo[] files = directoryInfo.GetFiles();
			if (files.Count() != 0)
			{
				test_pic_num = files.Count();
				if (test_pic_index >= test_pic_num)
				{
					test_pic_index = test_pic_num - 1;
				}
				else if (test_pic_index < 0)
				{
					test_pic_index = 0;
				}
				string mypath = USR[mFn].mDebug_PicFolder + files[test_pic_index];
				vsplus_visual_algorithms_running_debug(mypath);
			}
		}

		private void button_openFeederPage_Click(object sender, EventArgs e)
		{
			if (mIsSecurityTest)
			{
				int num = __wind_checkget_software_state(1);
				if (num == 2 || num == 3 || num == 4)
				{
					return;
				}
			}
			if (is_engineer_password_correct())
			{
				write_to_logFile_hand("HAND: button_openFeederPage_Click" + Environment.NewLine);
			}
		}

		private void init_rect_handle()
		{
			int fn;
			for (fn = 0; fn < HW.mFnNum; fn++)
			{
				PicBox_Preview[fn].Invoke((MethodInvoker)delegate
				{
					mRect = default(RECT);
					mRect.bottom = PicBox_Preview[fn].Bottom;
					mRect.left = PicBox_Preview[fn].Left;
					mRect.top = PicBox_Preview[fn].Top;
					mRect.right = PicBox_Preview[fn].Right;
					mRectSize = default(Size);
					mRectSize.Width = PicBox_Preview[fn].Size.Width;
					mRectSize.Height = PicBox_Preview[fn].Size.Height;
					ref IntPtr reference = ref mRectHandle[fn];
					reference = PicBox_Preview[fn].Handle;
					mRectPanelPoint = PointToScreen(new Point(panel_preview[fn].Location.X + panel_preview[fn].Parent.Location.X, panel_preview[fn].Location.Y + panel_preview[fn].Parent.Location.Y));
				});
			}
		}

		private bool initHVC()
		{
			mJvs_usrWidth = 542;
			mJvs_usrHeight = 542;
			init_rect_handle();
			is_jvs_init_success = false;
			if (mJvs_Channels == 0)
			{
				mJvs_Channels = JW6008HT.InitDSPs();
				if (mJvs_Channels > 0)
				{
					mJvs_Channels = JW6008HT.GetTotalDSPs();
				}
			}
			mJVS_OpenedPreviewMask = 0;
			if (mJvs_Channels >= HW.mCamATotalNum)
			{
				if (mJvs_Hd == null)
				{
					mJvs_Hd = new IntPtr[mJvs_Channels];
					for (int i = 0; i < mJvs_Channels; i++)
					{
						ref IntPtr reference = ref mJvs_Hd[i];
						reference = JW6008HT.ChannelOpen(i);
						JW6008HT.SetEncoderPictureFormat(mJvs_Hd[i], PictureFormat.ENC_4CIF_FORMAT);
						JW6008HT.SetVideoStandard(mJvs_Hd[i], VideoStandard.StandardPAL);
					}
				}
				mRect = default(RECT);
				mRect.left = 0;
				mRect.top = 0;
				mRect.right = mRectSize.Width;
				mRect.bottom = mRectSize.Height;
				for (int j = 0; j < mJvs_Channels; j++)
				{
					JW6008HT.StartVideoPreviewEx(mJvs_Hd[j], mRectHandle[HW.mMFCamChnFn[j]], ref mRect, bOverlay: true, 128, 25);
				}
				JW6008HT.UpdateVideoPreviewEx(12, (int)mJvs_Hd[0]);
				JW6008HT.UpdateVideoPreviewEx(12, (int)mJvs_Hd[0]);
				for (int k = 0; k < mJvs_Channels; k++)
				{
					JW6008HT.StopVideoPreviewEx(mJvs_Hd[k]);
				}
				for (int l = 0; l < mJvs_Channels; l++)
				{
					JW6008HT.StartVideoPreviewEx(mJvs_Hd[l], mRectHandle[HW.mMFCamChnFn[l]], ref mRect, bOverlay: true, 128, 25);
				}
				JW6008HT.UpdateVideoPreviewEx(12, (int)mJvs_Hd[0]);
				for (int m = 0; m < mJvs_Channels; m++)
				{
					JW6008HT.StopVideoPreviewEx(mJvs_Hd[m]);
				}
				is_jvs_init_success = true;
				mJVS_OpenedPreviewMask = 0;
				JW6008HT.StartVideoPreviewEx(mJvs_Hd[0], mRectHandle[0], ref mRect, bOverlay: true, 128, 25);
				mJVS_OpenedPreviewMask |= 1;
			}
			set_camera_parameter(HW.mMarkCamItem[0].index[0], USR[mFn].mMarkCamPara[USR[mFn].mMarkCamParaIndex].mParaCam);
			for (int n = 0; n < HW.mZnNum[mFn]; n++)
			{
				set_camera_parameter(HW.mFastCamItem[0].index[n], USR[mFn].mfcam_para[n]);
			}
			for (int num = 0; num < mJvs_Channels; num++)
			{
				openHVCPreview(num);
			}
			init_hvc_callback();
			for (int num2 = 0; num2 < HW.mZnNum[mFn]; num2++)
			{
				openHVCPreview(HW.mFastCamItem[0].index[num2]);
			}
			openHVCPreview(HW.mMarkCamItem[0].index[0]);
			JW6008HT.StartVideoPreviewEx(mJvs_Hd[HW.mMarkCamItem[0].index[0]], mRectHandle[0], ref mRect, bOverlay: true, 128, 25);
			return true;
		}

		private void uninitHVC()
		{
			closeHVCPreview(mFn);
		}

		public bool openHVCPreview(int nChannel)
		{
			if (!is_jvs_init_success)
			{
				return true;
			}
			if (mJvs_Hd == null)
			{
				return true;
			}
			int num = 0;
			int num2 = 0;
			if (((mJVS_OpenedPreviewMask >> nChannel) & 1) == 1)
			{
				return true;
			}
			closeHVCPreview(mFn);
			num = mJvs_rawWidth;
			num2 = mJvs_usrHeight;
			int num3 = ((nChannel != HW.mMarkCamItem[0].index[0]) ? USR[mFn].mFastCamCenterDeltaX[0][mZn[mFn]] : 0);
			mRect.left = (mRectSize.Width - num) / 2 - num3 + USR[mFn].mPreviewOffset_X;
			mRect.right = mRect.left + num;
			mRect.top = (mRectSize.Height - num2) / 2 + USR[mFn].mPreviewOffset_Y;
			mRect.bottom = mRect.top + num2;
			JW6008HT.StartVideoPreviewEx(mJvs_Hd[nChannel], mRectHandle[0], ref mRect, bOverlay: true, 128, 25);
			RECT rect = default(RECT);
			for (int i = 0; i < mJvs_Channels; i++)
			{
				if (i != nChannel)
				{
					rect.left = mRect.right + 1 + i;
					rect.right = rect.left;
					rect.top = mRect.bottom + 1 + i;
					rect.bottom = rect.top;
					JW6008HT.StartVideoPreviewEx(mJvs_Hd[i], mRectHandle[0], ref rect, bOverlay: true, 128, 25);
				}
			}
			JW6008HT.UpdateVideoPreviewEx(12, (int)mJvs_Hd[nChannel]);
			mJVS_OpenedPreviewMask |= 1 << nChannel;
			return true;
		}

		public static bool closeHVCPreview(int fn)
		{
			int num = 0;
			while (mJVS_OpenedPreviewMask != 0)
			{
				if ((mJVS_OpenedPreviewMask & 1) == 1)
				{
					JW6008HT.StopVideoPreviewEx(mJvs_Hd[num]);
				}
				mJVS_OpenedPreviewMask >>= 1;
				num++;
			}
			return true;
		}

		public static void startHVCStill_andWait(CameraType camtype, int fn, int zn)
		{
			int num = 0;
			int num2 = 500;
			switch (camtype)
			{
			case CameraType.Mark:
				num = HW.mMarkCamItem[fn].index[0];
				if (USR[fn].mMarkCamStillDelay <= 10)
				{
					USR[fn].mMarkCamStillDelay = 100;
				}
				num2 = USR[fn].mMarkCamStillDelay;
				hvcstill_andwait(num, num2);
				break;
			case CameraType.Fast:
				num = HW.mFastCamItem[fn].index[zn];
				num2 = ((USR2[fn] == null) ? USR[fn].mfcam_stilldelay : USR2[fn].mFastCamStillDelay[fn]);
				hvcstill_andwait(num, num2);
				break;
			}
		}

		public static void hvcstill_andwait(int ch, int still_delay)
		{
			if (mIsSimulation)
			{
				bJVSCameraRecived[ch] = true;
				return;
			}
			bJVSCameraRecived[ch] = false;
			jvsstill_LockBitmap(ch);
			if (still_delay > 0)
			{
				Thread.Sleep(still_delay);
			}
			HVC_Capture(ch);
			while (!bJVSCameraRecived[ch])
			{
				DateTime now = DateTime.Now;
				for (double totalMilliseconds = (DateTime.Now - now).TotalMilliseconds; totalMilliseconds <= 100.0; totalMilliseconds = (DateTime.Now - now).TotalMilliseconds)
				{
				}
			}
			bJVSCameraRecived[ch] = false;
			jvsstill_UnlockBitmap(ch);
		}

		public static bool startHVCStill_noWait(CameraType camtype, int fn, int zn)
		{
			int num = 0;
			int num2 = 100;
			bool flag = mDebug_Factory;
			switch (camtype)
			{
			case CameraType.Mark:
				num = HW.mMarkCamItem[fn].index[0];
				if (USR[fn].mMarkCamStillDelay <= 10)
				{
					USR[fn].mMarkCamStillDelay = 100;
				}
				num2 = USR[fn].mMarkCamStillDelay;
				if (flag)
				{
					write_to_logFile(mLogFileName, "startJVSStill_noWait: ch=" + num + " still_delay=" + num2 + Environment.NewLine);
				}
				return hvcstill_nowait(num, num2);
			case CameraType.Fast:
				num = HW.mFastCamItem[fn].index[zn];
				num2 = ((USR2[fn] == null) ? USR[fn].mfcam_stilldelay : USR2[fn].mFastCamStillDelay[0]);
				if (flag)
				{
					write_to_logFile(mLogFileName, "startJVSStill_noWait: ch=" + num + " still_delay=" + num2 + Environment.NewLine);
				}
				return hvcstill_nowait(num, num2);
			default:
				return false;
			}
		}

		public static bool hvcstill_nowait(int ch, int still_delay)
		{
			if (mIsSimulation)
			{
				bJVSCameraRecived[ch] = true;
				return true;
			}
			_ = mJvs_rawWidth;
			_ = mJvs_rawHeight;
			bJVSCameraRecived[ch] = false;
			jvsstill_LockBitmap(ch);
			HVC_Capture(ch);
			return true;
		}

		public static void HVC_Capture(int ch)
		{
			Thread thread = new Thread(thd_hvc_capture);
			thread.IsBackground = true;
			thread.Start(ch);
		}

		public static void thd_hvc_capture(object o)
		{
			int num = (int)o;
			if (mIsSimulation)
			{
				bJVSCameraRecived[num] = true;
				return;
			}
			int Size = mJvs_rawWidth * mJvs_rawHeight * 2;
			byte[] array = pYuvBuffer[num];
			if (mIsHvcCallbackMode)
			{
				run_hvc_callback_mode_capture(num, array, Size);
			}
			else
			{
				write_buffer_aa55(array, Size);
				do
				{
					stillMutex.WaitOne();
					JW6008HT.GetOriginalImage(mJvs_Hd[num], array, ref Size);
					stillMutex.Release();
				}
				while (check_buffer_aa55(array, Size));
			}
			byte[] array2 = pRgb32Buffer[num];
			moon_yuyv_to_yyy32(array, array2, mJvs_rawWidth, mJvs_rawHeight, 0);
			Marshal.Copy(array2, 0, mJVSBitmap_Data[num].Scan0, mJvs_rawWidth * mJvs_rawHeight * 4);
			bJVSCameraRecived[num] = true;
		}

		public void vsplus_usr3_history_common()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				for (int j = 0; j < U3[i].Count; j++)
				{
					USR3_DATA uSR3_DATA = U3[i][j];
					for (int k = 0; k < 2; k++)
					{
						if (uSR3_DATA.mMarkPara[k].mPicMark == null && uSR3_DATA.mMarkPic[k] != null)
						{
							uSR3_DATA.mMarkPara[k].mPicMark = new Bitmap(uSR3_DATA.mMarkPic[k]);
						}
					}
				}
			}
		}

		public void vsplus_usr3_history_before_2020_7()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR3B[i].mHistory >= 7)
				{
					continue;
				}
				if (U3[i].Count > 0)
				{
					USR3B[i].mSmtASpeed = U3[i][0].mSmtASpeed;
					USR3B[i].mSmtXYSpeed = U3[i][0].mSmtXYSpeed;
					USR3B[i].mSmtPikRetryNum = U3[i][0].mSmtPikRetryNum;
					USR3B[i].mSmtSafeSpace = U3[i][0].mSmtSafeSpace;
					USR3B[i].mIsLoukongPCB = U3[i][0].mIsLoukongPCB;
					USR3B[i].mTrackDelay = U3[i][0].mTrackDelay;
					USR3B[i].mTrackSpeed = U3[i][0].mTrackSpeed;
					USR3B[i].mIsCheckNozzleDirty = U3[i][0].mIsCheckNozzleDirty;
					USR3B[i].mIsMountStacksNew = new bool[3][];
					for (int j = 0; j < 3; j++)
					{
						USR3B[i].mIsMountStacksNew[j] = new bool[240];
						for (int k = 0; k < 240; k++)
						{
							USR3B[i].mIsMountStacksNew[j][k] = true;
							if (U3[i][0].mIsMountStacksNew != null && U3[i][0].mIsMountStacksNew.Count() == 3 && U3[i][0].mIsMountStacksNew[j] != null && k < U3[i][0].mIsMountStacksNew[j].Count())
							{
								USR3B[i].mIsMountStacksNew[j][k] = U3[i][0].mIsMountStacksNew[j][k];
							}
						}
					}
				}
				else
				{
					USR3B[i].mSmtPikRetryNum = 3;
				}
				for (int l = 0; l < U3[i].Count; l++)
				{
					USR3_DATA uSR3_DATA = U3[i][l];
					if (uSR3_DATA.mHistory >= 7)
					{
						continue;
					}
					if (uSR3_DATA.mPointlist != null)
					{
						for (int m = 0; m < uSR3_DATA.mPointlist.Count; m++)
						{
							if (uSR3_DATA.mPointlist[m].isAix)
							{
								uSR3_DATA.mIsPcbAix = true;
								break;
							}
						}
					}
					uSR3_DATA.mIsArrayMount = new bool[uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn];
					for (int n = 0; n < uSR3_DATA.mIsArrayMount.Count(); n++)
					{
						uSR3_DATA.mIsArrayMount[n] = true;
					}
					if (uSR3_DATA.mIsPcbAix)
					{
						uSR3_DATA.mIsArrayAixMount = new bool[uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn];
						for (int num = 0; num < uSR3_DATA.mIsArrayAixMount.Count(); num++)
						{
							uSR3_DATA.mIsArrayAixMount[num] = true;
						}
					}
					if (uSR3_DATA.mArrayIsMountList != null)
					{
						for (int num2 = 0; num2 < uSR3_DATA.mArrayIsMountList.Count; num2++)
						{
							int arrayno = uSR3_DATA.mArrayIsMountList[num2].Arrayno;
							if (arrayno < uSR3_DATA.mArrayPCBRow * uSR3_DATA.mArrayPCBColumn)
							{
								uSR3_DATA.mIsArrayMount[arrayno] = uSR3_DATA.mArrayIsMountList[num2].Ismount;
								if (uSR3_DATA.mIsPcbAix && uSR3_DATA.mArrayIsMountList[num2].isHaveAix)
								{
									uSR3_DATA.mIsArrayAixMount[arrayno] = uSR3_DATA.mArrayIsMountList[num2].IsmountAix;
								}
							}
						}
					}
					if (uSR3_DATA.mIsMarkSearch == null)
					{
						bool[] array = (uSR3_DATA.mIsMarkSearch = new bool[2]);
					}
					if (uSR3_DATA.mMarkSearch == null)
					{
						uSR3_DATA.mMarkSearch = new Coordinate[2]
						{
							new Coordinate(0L, 0L),
							new Coordinate(0L, 0L)
						};
					}
					for (int num3 = 0; num3 < 2; num3++)
					{
						if (uSR3_DATA.mMarkSearch[num3].X > 0 || uSR3_DATA.mMarkSearch[num3].Y > 0)
						{
							uSR3_DATA.mIsMarkSearch[num3] = true;
						}
					}
					if (mJvsDriver != JvsDriver.MV360)
					{
						continue;
					}
					for (int num4 = 0; num4 < 2; num4++)
					{
						if (uSR3_DATA.mMarkPara[num4].mPara.mParaCam[0] < 64)
						{
							uSR3_DATA.mMarkPara[num4].mPara.mParaCam[0] += 128;
						}
					}
				}
			}
		}

		private void vsplus_usr3_history_before_2020_5()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (USR3B[i].mHistory < 5)
				{
					BindingList<BindingList<ChipCategoryElement>> bindingList = new BindingList<BindingList<ChipCategoryElement>>();
					bindingList.Add(USR3B[i].mPointlistCat);
					bindingList.Add(USR3B[i].mPointlistCat_History);
					for (int j = 0; j < U3[i].Count(); j++)
					{
						bindingList.Add(U3[i][j].mPointlistCat);
					}
					for (int k = 0; k < bindingList.Count; k++)
					{
						BindingList<ChipCategoryElement> bindingList2 = bindingList[k];
						if (bindingList2 == null || bindingList2.Count <= 0)
						{
							continue;
						}
						for (int l = 0; l < bindingList2.Count; l++)
						{
							BindingList<int> bindingList3 = new BindingList<int>();
							for (int m = 0; m < bindingList2[l].MultiFeeders; m++)
							{
								bindingList3.Add(bindingList2[l].feeder_no[m]);
							}
							int num = Math.Max(16, bindingList2[l].MultiFeeders);
							bindingList2[l].feeder_no = new int[num];
							for (int n = 0; n < num; n++)
							{
								if (n < bindingList3.Count)
								{
									bindingList2[l].feeder_no[n] = bindingList3[n];
								}
								else
								{
									bindingList2[l].feeder_no[n] = 0;
								}
							}
						}
					}
				}
				if (USR3B[i].mHistory < 5)
				{
					if (USR3B[i].mThrowRateCheckList != null)
					{
						int num2 = USR3B[i].mThrowRateCheckList[0].Count();
						if (num2 < 160)
						{
							int[][][] array = new int[3][][];
							for (int num3 = 0; num3 < 3; num3++)
							{
								array[num3] = new int[num2][];
								for (int num4 = 0; num4 < num2; num4++)
								{
									array[num3][num4] = new int[8];
									for (int num5 = 0; num5 < 8; num5++)
									{
										array[num3][num4][num5] = USR3B[i].mThrowRateCheckList[num3][num4][num5];
									}
								}
							}
							USR3B[i].mThrowRateCheckList = new int[3][][];
							for (int num6 = 0; num6 < 3; num6++)
							{
								USR3B[i].mThrowRateCheckList[num6] = new int[160][];
								for (int num7 = 0; num7 < 160; num7++)
								{
									USR3B[i].mThrowRateCheckList[num6][num7] = new int[8];
									for (int num8 = 0; num8 < 8; num8++)
									{
										USR3B[i].mThrowRateCheckList[num6][num7][num8] = ((num7 < num2) ? array[num6][num7][num8] : 0);
									}
								}
							}
						}
					}
					if (USR3B[i].mNoneChipRateCheckList != null)
					{
						int num9 = USR3B[i].mNoneChipRateCheckList[0].Count();
						if (num9 < 160)
						{
							int[][][] array2 = new int[3][][];
							for (int num10 = 0; num10 < 3; num10++)
							{
								array2[num10] = new int[num9][];
								for (int num11 = 0; num11 < num9; num11++)
								{
									array2[num10][num11] = new int[8];
									for (int num12 = 0; num12 < 8; num12++)
									{
										array2[num10][num11][num12] = USR3B[i].mNoneChipRateCheckList[num10][num11][num12];
									}
								}
							}
							USR3B[i].mNoneChipRateCheckList = new int[3][][];
							for (int num13 = 0; num13 < 3; num13++)
							{
								USR3B[i].mNoneChipRateCheckList[num13] = new int[160][];
								for (int num14 = 0; num14 < 160; num14++)
								{
									USR3B[i].mNoneChipRateCheckList[num13][num14] = new int[8];
									for (int num15 = 0; num15 < 8; num15++)
									{
										USR3B[i].mNoneChipRateCheckList[num13][num14][num15] = ((num14 < num9) ? array2[num13][num14][num15] : 0);
									}
								}
							}
						}
					}
				}
				if (USR3B[i].mHistory < 5)
				{
					for (int num16 = 0; num16 < U3[i].Count(); num16++)
					{
						if (U3[i][num16] == null)
						{
							continue;
						}
						if (U3[i][num16].mPointlist != null)
						{
							for (int num17 = 0; num17 < U3[i][num16].mPointlist.Count; num17++)
							{
								if (U3[i][num16].mPointlist[num17].Looptype == LoopType.N_A)
								{
									U3[i][num16].mPointlist[num17].Looptype = ((!U3[i][num16].mPointlist[num17].isPricise) ? LoopType.OpenLoop : LoopType.CloseLoop);
								}
							}
							for (int num18 = 0; num18 < U3[i][num16].mPointlistSmt.Count; num18++)
							{
								if (U3[i][num16].mPointlistSmt[num18].Looptype == LoopType.N_A)
								{
									U3[i][num16].mPointlistSmt[num18].Looptype = ((!U3[i][num16].mPointlistSmt[num18].isPricise) ? LoopType.OpenLoop : LoopType.CloseLoop);
								}
							}
						}
						if (U3[i][num16].mPointlistCat == null)
						{
							continue;
						}
						for (int num19 = 0; num19 < U3[i][num16].mPointlistCat.Count; num19++)
						{
							if (U3[i][num16].mPointlistCat[num19].Looptype == LoopType.N_A)
							{
								U3[i][num16].mPointlistCat[num19].Looptype = ((!U3[i][num16].mPointlistCat[num19].Is_VisualPricise) ? LoopType.OpenLoop : LoopType.CloseLoop);
							}
						}
					}
					if (USR3B[i].mPointlistCat != null)
					{
						for (int num20 = 0; num20 < USR3B[i].mPointlistCat.Count; num20++)
						{
							if (USR3B[i].mPointlistCat[num20].Looptype == LoopType.N_A)
							{
								USR3B[i].mPointlistCat[num20].Looptype = ((!USR3B[i].mPointlistCat[num20].Is_VisualPricise) ? LoopType.OpenLoop : LoopType.CloseLoop);
							}
						}
					}
				}
				if (USR3B[i].mHistory >= 5)
				{
					continue;
				}
				for (int num21 = 0; num21 < U3[i].Count(); num21++)
				{
					if (U3[i][num21].LD2 == null)
					{
						U3[i][num21].LD2 = new LD_DATA2();
					}
					if (U3[i][num21].LD2.mSignPara == null)
					{
						U3[i][num21].LD2.mSignPara = new MARK_PARA[4];
					}
					for (int num22 = 0; num22 < 4; num22++)
					{
						if (U3[i][num21].LD2.mSignPara[num22].mPara == null)
						{
							U3[i][num21].LD2.mSignPara[num22].mPara = new MarkCamPara();
						}
					}
					if (U3[i][num21].mMarkPara == null)
					{
						U3[i][num21].mMarkPara = new MARK_PARA[2];
						for (int num23 = 0; num23 < 2; num23++)
						{
							U3[i][num21].mMarkPara[num23] = new MARK_PARA();
						}
					}
					for (int num24 = 0; num24 < 2; num24++)
					{
						if (U3[i][num21].mMarkPara[num24].mPara == null)
						{
							U3[i][num21].mMarkPara[num24].mPara = new MarkCamPara();
						}
					}
					if (U3[i][num21].mPcbArrayXCheckMarkPara == null)
					{
						U3[i][num21].mPcbArrayXCheckMarkPara = new MARK_PARA();
					}
					if (U3[i][num21].mPcbArrayXCheckMarkPara.mPara == null)
					{
						U3[i][num21].mPcbArrayXCheckMarkPara.mPara = new MarkCamPara();
					}
				}
			}
		}

		private void button_Library_Click(object sender, EventArgs e)
		{
			if (mForm_LabPrintfoot == null || mForm_LabPrintfoot.IsDisposed)
			{
				mForm_LabPrintfoot = new Form_LabPrintfoot(USR_INIT, 0);
				mForm_LabPrintfoot.Location = new Point(253, 87);
				mForm_LabPrintfoot.Show();
				mForm_LabPrintfoot.TopMost = true;
			}
		}

		private void init_footprintlib()
		{
			FP_PATH.mFootprintLib_NameList = recheck_footprintlib(FP_PATH.mFootprintLib_NameList);
		}

		private BindingList<string> recheck_footprintlib(BindingList<string> filelist)
		{
			if (filelist == null)
			{
				filelist = new BindingList<string>();
			}
			int count = filelist.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				if (!filelist[num].Contains(".footprint"))
				{
					filelist.RemoveAt(num);
				}
				else if (!File.Exists(filelist[num]))
				{
					filelist.RemoveAt(num);
				}
			}
			return filelist;
		}

		public static string GetNetworkAdapterPermanentAddress(string PNPDeviceID)
		{
			IntPtr intPtr = new IntPtr(-1);
			string lpFileName = "\\\\.\\" + PNPDeviceID.Replace('\\', '#') + "#{ad498944-762f-11d0-8dcb-00c04fc3358c}";
			IntPtr intPtr2 = CreateFile(lpFileName, 0u, 3u, IntPtr.Zero, 3u, 0u, IntPtr.Zero);
			if (intPtr2 != intPtr)
			{
				byte[] array = new byte[8];
				uint lpInBuffer = 16843009u;
				int nBytesReturned;
				bool flag = DeviceIoControl(intPtr2, 1507330u, ref lpInBuffer, Marshal.SizeOf((object)lpInBuffer), array, array.Length, out nBytesReturned, IntPtr.Zero);
				CloseHandle(intPtr2);
				if (flag)
				{
					StringBuilder stringBuilder = new StringBuilder(nBytesReturned * 3);
					byte[] array2 = array;
					foreach (byte b in array2)
					{
						stringBuilder.Append(b.ToString("X2"));
						stringBuilder.Append(':');
					}
					return stringBuilder.ToString(0, nBytesReturned * 3 - 1);
				}
			}
			return null;
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref uint lpInBuffer, int nInBufferSize, byte[] lpOutBuffer, int nOutBufferSize, out int nBytesReturned, IntPtr lpOverlapped);

		private void getDeviceSerialCode()
		{
			string text = "";
			string queryString = "SELECT * FROM Win32_NetworkAdapter WHERE (MACAddress IS NOT NULL) AND (NOT (PNPDeviceID LIKE 'ROOT%')) AND (PNPDeviceID LIKE 'PCI%')";
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher(queryString).Get();
			if (managementObjectCollection != null)
			{
				using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator();
				if (managementObjectEnumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
					text = GetNetworkAdapterPermanentAddress(managementObject["PNPDeviceID"] as string);
					write_to_logFile(text);
					text = text.Replace(":", "");
				}
			}
			if (text == "")
			{
				queryString = "SELECT * FROM Win32_NetworkAdapter WHERE (MACAddress IS NOT NULL) AND (NOT (PNPDeviceID LIKE 'ROOT%'))";
				managementObjectCollection = new ManagementObjectSearcher(queryString).Get();
				using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator2 = managementObjectCollection.GetEnumerator();
				if (managementObjectEnumerator2.MoveNext())
				{
					ManagementObject managementObject2 = (ManagementObject)managementObjectEnumerator2.Current;
					text = GetNetworkAdapterPermanentAddress(managementObject2["PNPDeviceID"] as string);
					write_to_logFile(text);
					text = text.Replace(":", "");
				}
			}
			ManagementClass managementClass = new ManagementClass("Win32_PhysicalMedia");
			ManagementObjectCollection instances = managementClass.GetInstances();
			string text2 = "";
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator3 = instances.GetEnumerator())
			{
				if (managementObjectEnumerator3.MoveNext())
				{
					ManagementObject managementObject3 = (ManagementObject)managementObjectEnumerator3.Current;
					text2 = managementObject3.Properties["SerialNumber"].Value.ToString();
				}
			}
			text2 = text2 + "HWGC" + text;
			text2 = text2.Replace("_", "").Replace(".", "").Replace(" ", "");
			string text3 = text2;
			byte[] array = new byte[1024];
			moon_set_wind_devcode(text3, ref array[0], text3.Length);
		}

		public static void __wind_button_sw_register_Click()
		{
			byte[] array = new byte[512];
			int count = moon_get_wind_devcode(ref array[0]);
			string @string = Encoding.Default.GetString(array, 0, count);
			byte[] array2 = new byte[14];
			byte[] array3 = new byte[1];
			int num = moon_wind_checkget_software_state(ref array2[0], ref array3[0]);
			string key = "";
			if (num != 0)
			{
				byte[] array4 = new byte[1024];
				moon_wind_get_key(ref array4[0]);
				key = Encoding.Default.GetString(array4, 0, array4.Length);
			}
			Form_Register form_Register = new Form_Register(@string, key, USR_INIT.mLanguage);
			if (form_Register.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string input_key = form_Register.get_input_key();
			switch (moon_wind_set_key(input_key, input_key.Length))
			{
			case 1:
			{
				moon_wind_checkget_software_state(ref array2[0], ref array3[0]);
				string text = Encoding.Default.GetString(array2, 0, 4) + "/" + Encoding.Default.GetString(array2, 4, 2) + "/" + Encoding.Default.GetString(array2, 6, 2) + " " + Encoding.Default.GetString(array2, 8, 2) + ":" + Encoding.Default.GetString(array2, 10, 2) + ":" + Encoding.Default.GetString(array2, 12, 2);
				int num2 = 2019;
				try
				{
					num2 = (int)float.Parse(Encoding.Default.GetString(array2, 0, 4));
				}
				catch (Exception ex)
				{
					write_to_logFile(mLogFileName, ex.ToString() + Environment.NewLine);
					write_to_logFile(mLogFileName, "Exception: button_sw_register_Click" + Environment.NewLine);
				}
				if (num2 >= 2036)
				{
					text = ((USR_INIT.mLanguage == 2) ? "Permanent License" : "永久授权");
				}
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBoxTop_Ok("Valid Date to " + text);
				}
				else
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Software Register Successfully, valid date to " : ("软件授权成功, 有效期为 " + text));
				}
				break;
			}
			case 0:
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBoxTop_Ok("Error Key!");
				}
				else
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Register key is not correct!" : "软件授权码不正确！");
				}
				break;
			case 2:
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBoxTop_Ok("Time Expire!");
				}
				else
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Register key is overtime!" : "授权码已过期，授权失败！");
				}
				break;
			case 3:
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBoxTop_Ok("Miles Expire!");
				}
				else
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Register key is over miles, fail!" : "授权码已超贴装里程，授权失败！");
				}
				break;
			case 4:
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBoxTop_Ok("System Locked!");
				}
				else
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Device is Locked, please contact with the company for new register key!" : "软件已被锁定，请联系厂家获得解锁密码！");
				}
				break;
			case 5:
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBoxTop_Ok("Unlock key invalid!");
				}
				else
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Register key is not correct!" : "解锁密码输入错误！");
				}
				break;
			case 6:
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBoxTop_Ok("Unlock key can only use one time!");
				}
				else
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Register key is valid only once!" : "解锁密码只能使用一次！");
				}
				break;
			case 7:
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBoxTop_Ok("Unlock Done!");
				}
				else
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Unlock to trial version successfully, if the device is still within valid date, please input valid key!" : "解锁成功，软件恢复试用版本，如果您还在授权日期之内，请重新输入有效的授权码进行授权！");
				}
				break;
			}
			__wind_checkget_software_state(0);
		}

		public static int __wind_checkget_software_state(int mode)
		{
			moon_wind_update_reference_time();
			byte[] key_time = new byte[14];
			byte[] array = new byte[1];
			int state = moon_wind_checkget_software_state(ref key_time[0], ref array[0]);
			if (state == 5)
			{
				if (USR_INIT.mLanguage == 2)
				{
					CmMessageBox("Lack of system files!", MessageBoxButtons.OK);
				}
				else
				{
					CmMessageBox("缺少系统文件导致软件无法启动，请卸载软件并使用管理员模式重新安装软件！", MessageBoxButtons.OK);
				}
				Environment.Exit(0);
			}
			bool is_hiden = false;
			static_this.Invoke((MethodInvoker)delegate
			{
				string text = "";
				if (state == 0)
				{
					text = ((USR_INIT.mLanguage == 2) ? "Trail" : "试用版本");
				}
				else if (state == 1)
				{
					text = ((USR_INIT.mLanguage == 2) ? "Registered" : "授权成功");
				}
				else if (state == 3)
				{
					text = ((USR_INIT.mLanguage == 2) ? "Expired" : "授权过期");
				}
				else if (state == 4)
				{
					text = ((USR_INIT.mLanguage == 2) ? "Expired" : "授权过期");
				}
				else if (state == 2)
				{
					text = ((USR_INIT.mLanguage == 2) ? "Locked" : "软件锁定");
				}
				if (state == 0)
				{
					uc_usroperarion[mFn].set_throwbutton_color(Color.Gray);
				}
				else if (state == 1)
				{
					uc_usroperarion[mFn].set_throwbutton_color(Color.LightGray);
				}
				else if (state == 3)
				{
					uc_usroperarion[mFn].set_throwbutton_color(Color.Red);
				}
				else if (state == 4)
				{
					uc_usroperarion[mFn].set_throwbutton_color(Color.Pink);
				}
				else if (state == 2)
				{
					uc_usroperarion[mFn].set_throwbutton_color(Color.Black);
				}
				static_label_notice_register.Visible = false;
				if (state == 1 || state == 3 || state == 4)
				{
					str_wind_keytime = Encoding.Default.GetString(key_time, 0, 4) + "/" + Encoding.Default.GetString(key_time, 4, 2) + "/" + Encoding.Default.GetString(key_time, 6, 2) + " " + Encoding.Default.GetString(key_time, 8, 2) + ":" + Encoding.Default.GetString(key_time, 10, 2) + ":" + Encoding.Default.GetString(key_time, 12, 2);
					int num = 2019;
					try
					{
						num = (int)float.Parse(Encoding.Default.GetString(key_time, 0, 4));
					}
					catch (Exception)
					{
						write_to_logFile(mLogFileName, "Exception: __wind_checkget_software_state" + Environment.NewLine);
					}
					if (num >= 2035)
					{
						str_wind_keytime = ((USR_INIT.mLanguage == 2) ? "Permanent License" : "永久授权");
					}
					if (state == 1)
					{
						if (key_time[4] == 48 && key_time[5] == 50 && key_time[6] >= 51)
						{
							key_time[6] = (byte)(key_time[6] - 3);
						}
						string value = Encoding.Default.GetString(key_time, 0, 4) + "-" + Encoding.Default.GetString(key_time, 4, 2) + "-" + Encoding.Default.GetString(key_time, 6, 2);
						DateTime dateTime;
						try
						{
							dateTime = Convert.ToDateTime(value);
						}
						catch (Exception)
						{
							key_time[6] = (byte)(key_time[6] - 3);
							dateTime = Convert.ToDateTime(Encoding.Default.GetString(key_time, 0, 4) + "-" + Encoding.Default.GetString(key_time, 4, 2) + "-" + Encoding.Default.GetString(key_time, 6, 2));
						}
						DateTime now = DateTime.Now;
						int num2 = dateTime.Subtract(now).Days + 1;
						if (num2 <= 5)
						{
							static_label_notice_register.Text = ((USR_INIT.mLanguage == 2) ? ("Valid Remain " + num2 + " Days!!!") : ("设备运行有效期还剩 " + num2 + " 天!!!"));
							static_label_notice_register.Visible = true;
							static_label_notice_register.BringToFront();
							is_hiden = false;
							if (mode != 2)
							{
								Form_NoticeError form_NoticeError = new Form_NoticeError(USR_INIT.mLanguage, static_label_notice_register.Text);
								form_NoticeError.ShowDialog();
							}
						}
					}
					else
					{
						static_label_notice_register.Text = ((USR_INIT.mLanguage == 2) ? "Register Expire!!!" : "授权到期 设备锁定！！！");
						static_label_notice_register.Visible = true;
						static_label_notice_register.BringToFront();
						is_hiden = false;
					}
				}
				else if (state == 2)
				{
					str_wind_keytime = ((USR_INIT.mLanguage == 2) ? "Modified System Time" : "试图修改系统时间");
					static_label_notice_register.Text = ((USR_INIT.mLanguage == 2) ? "Illegal operation System Lock!!!" : "违规操作 设备锁定！！！");
					static_label_notice_register.Visible = true;
					static_label_notice_register.BringToFront();
					is_hiden = false;
				}
				else
				{
					str_wind_keytime = "";
				}
				if (state == 0)
				{
					str_wind_sw_state = ((USR_INIT.mLanguage == 2) ? "Trial Version Limited" : "试用版本 功能受限");
				}
				else if (state == 1)
				{
					str_wind_sw_state = ((USR_INIT.mLanguage == 2) ? "Register Done! Valid Date " : "授权成功 有效期至 ");
				}
				else if (state == 3)
				{
					str_wind_sw_state = ((USR_INIT.mLanguage == 2) ? "System Lock! Time Expire " : "系统锁定 授权过期 ");
				}
				else if (state == 4)
				{
					str_wind_sw_state = ((USR_INIT.mLanguage == 2) ? "System Lock! Miles Expire " : "系统锁定 里程超额 ");
				}
				else if (state == 2)
				{
					str_wind_sw_state = ((USR_INIT.mLanguage == 2) ? "System Lock! Illegal Operation " : "系统锁定 违规操作 ");
				}
				if (is_hiden)
				{
					static_label_smtdevicetype.Text = "";
				}
				else
				{
					static_label_smtdevicetype.Text = text;
				}
				if (mode == 1)
				{
					if (state == 0 && !is_hiden)
					{
						string text2 = "";
						text2 = ((USR_INIT.mLanguage != 2) ? ("试用版本，功能受限制，请联系厂家获得正式版本授权！" + Environment.NewLine + "限制一：全自动模式只能连续贴装" + 5 + "块板子" + Environment.NewLine + "限制二：导入功能最多只支持" + 150 + "颗芯片" + Environment.NewLine + "限制三：优化功能最多只支持" + 5 + "种芯片" + Environment.NewLine + "限制四：贴装限制" + 10 + "块板子需要重启软件一次" + Environment.NewLine + "限制五：最高贴装里程为" + 120000) : ("Trial Version，Function Limited!" + Environment.NewLine + "Limit 1：Auto run mode can only run " + 5 + "boards once" + Environment.NewLine + "Limit 2：Most import " + 150 + "chips" + Environment.NewLine + "Limit 3：Most optimize" + 5 + "kinds chips" + Environment.NewLine + "Limit 4：After run" + 10 + "boards, restart is required" + Environment.NewLine + "Limit 5：Most number to run chips is" + 120000));
						CmMessageBoxTop_Ok(text2);
					}
					else if (state == 2)
					{
						if (USR_INIT.mLanguage == 2)
						{
							CmMessageBoxTop_Ok("System have been locked since illegal operation to modify system time!");
						}
						else
						{
							CmMessageBoxTop_Ok("尊敬的客户，您因试图修改系统时间等违规操作导致软件锁死，请联系厂家解锁！");
						}
					}
					else if (state == 3)
					{
						if (USR_INIT.mLanguage == 2)
						{
							CmMessageBoxTop_Ok("System have been locked since registered times out!");
						}
						else
						{
							CmMessageBoxTop_Ok("尊敬的客户，软件授权时间已到期，软件被锁定，请联系厂家解锁！");
						}
					}
					else if (state == 4)
					{
						if (USR_INIT.mLanguage == 2)
						{
							CmMessageBoxTop_Ok("System have been locked since registered miles out!");
						}
						else
						{
							CmMessageBoxTop_Ok("尊敬的客户，贴装点数已经到达软件授权点数，软件被锁定，请联系厂家解锁！");
						}
					}
				}
			});
			return state;
		}

		public static float format_angle(float input_angle, float from, float to, float step)
		{
			while (input_angle > to)
			{
				input_angle -= Math.Abs(step);
			}
			while (input_angle <= from)
			{
				input_angle += Math.Abs(step);
			}
			return input_angle;
		}

		public static string format_XY_label_string(Coordinate d)
		{
			return "X" + d.X.ToString("D5") + Environment.NewLine + "Y" + d.Y.ToString("D5");
		}

		public static float format_H_to_Hmm(int H)
		{
			if (HW.mSmtGenerationNo == 0)
			{
				return (float)(10.5 - 10.5 * Math.Cos(Math.Abs((double)(H * 2) * 3.1415927 / 128.0 / 200.0)));
			}
			if (HW.mSmtGenerationNo == 2)
			{
				return (float)H / 10f;
			}
			return 0f;
		}

		public static int format_Hmm_to_H(float Hmm)
		{
			if (HW.mSmtGenerationNo == 0)
			{
				if (Hmm > 21f)
				{
					Hmm = 21f;
				}
				return (int)(Math.Acos(1f - Hmm / 10.5f) * 128.0 * 200.0 / 6.2831854 + 0.5);
			}
			if (HW.mSmtGenerationNo == 2)
			{
				return (int)(Hmm * 10f + 0.5f);
			}
			return 0;
		}

		public static float format_mm_to_pix(float Lmm, float ratio)
		{
			if (ratio == 0f)
			{
				return -1f;
			}
			return Lmm * 100f / ratio;
		}

		public static float format_pix_to_mm(float Lpix, float ratio)
		{
			if (ratio == 0f)
			{
				return -1f;
			}
			return Lpix * ratio / 100f;
		}

		public static double format_distance(Coordinate a, Coordinate b)
		{
			int num = (int)((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
			return Math.Sqrt(num);
		}

		public static int format_distance2(Coordinate a, Coordinate b)
		{
			return (int)((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
		}

		public static void msdelay(int ms)
		{
			DateTime now = DateTime.Now;
			double totalMilliseconds = (DateTime.Now - now).TotalMilliseconds;
			while (totalMilliseconds <= (double)ms)
			{
				totalMilliseconds = (DateTime.Now - now).TotalMilliseconds;
				Thread.Sleep(0);
			}
		}

		public static ProviderType format_feeder_to_providertype(FeederType feedertype)
		{
			return feedertype switch
			{
				FeederType.Plate => ProviderType.Plate, 
				FeederType.Vibra => ProviderType.Vibra, 
				_ => ProviderType.Feedr, 
			};
		}

		public static int format_cameralist_index(CameraType cam)
		{
			return cam switch
			{
				CameraType.Fast => 0, 
				CameraType.High => 1, 
				CameraType.None => 2, 
				_ => -1, 
			};
		}

		public static int format_providerlist_index(ProviderType prd)
		{
			return prd switch
			{
				ProviderType.Feedr => 0, 
				ProviderType.Plate => 1, 
				ProviderType.Vibra => 2, 
				_ => -1, 
			};
		}

		public static int format_feederlist_index(FeederType feeder)
		{
			for (int i = 0; i < 10; i++)
			{
				if (feeder == (FeederType)i)
				{
					return i;
				}
			}
			return -1;
		}

		public static void datagridview_set_row_backcolor(DataGridView dgv, int r, Color color)
		{
			if (dgv == null)
			{
				return;
			}
			int columnCount = dgv.ColumnCount;
			int rowCount = dgv.RowCount;
			if (r < rowCount && r >= 0)
			{
				for (int i = 0; i < columnCount; i++)
				{
					dgv.Rows[r].Cells[i].Style.BackColor = color;
				}
			}
		}

		public static int format_feeder_front_or_back(int f, int feederno)
		{
			if (feederno >= HW.malgo2[f].slt_l[0] + HW.malgo2[f].slt_r[0])
			{
				return 1;
			}
			return 0;
		}

		public static bool format_is_pricise(LoopType lp)
		{
			if (lp != LoopType.CloseLoop)
			{
				return false;
			}
			return true;
		}

		public static int format_stackno(int f, int si, int p)
		{
			int result = -1;
			switch (si)
			{
			case 0:
				if (p >= HW.malgo2[f].emp_l[0] && p < HW.malgo2[f].emp_l[0] + HW.malgo2[f].slt_l[0])
				{
					result = p - HW.malgo2[f].emp_l[0];
				}
				else if (p >= HW.malgo2[f].emp_l[0] + HW.malgo2[f].slt_l[0] + HW.malgo2[f].emp_m[0] && p < HW.malgo2[f].emp_l[0] + HW.malgo2[f].slt_l[0] + HW.malgo2[f].emp_m[0] + HW.malgo2[f].slt_r[0])
				{
					result = p - (HW.malgo2[f].emp_l[0] + HW.malgo2[f].emp_m[0]);
				}
				break;
			case 1:
				if (p >= HW.malgo2[f].emp_l[1] && p < HW.malgo2[f].emp_l[1] + HW.malgo2[f].slt_l[1])
				{
					result = p - HW.malgo2[f].emp_l[1] + (HW.malgo2[f].slt_l[0] + HW.malgo2[f].slt_r[0]);
				}
				else if (p >= HW.malgo2[f].emp_l[1] + HW.malgo2[f].slt_l[1] + HW.malgo2[f].emp_m[1] && p < HW.malgo2[f].emp_l[1] + HW.malgo2[f].slt_l[1] + HW.malgo2[f].emp_m[1] + HW.malgo2[f].slt_r[1])
				{
					result = p - (HW.malgo2[f].emp_l[1] + HW.malgo2[f].emp_m[1]) + (HW.malgo2[f].slt_l[0] + HW.malgo2[f].slt_r[0]);
				}
				break;
			}
			return result;
		}

		public static int format_stackno(int f, int stkno, ref int si, ref int p)
		{
			int num = 0;
			num = ((stkno < HW.malgo2[f].slt_l[0]) ? (stkno + HW.malgo2[f].emp_l[0]) : ((stkno < HW.malgo2[f].slt_l[0] + HW.malgo2[f].slt_r[0]) ? (stkno + HW.malgo2[f].emp_l[0] + HW.malgo2[f].emp_m[0]) : ((stkno >= HW.malgo2[f].slt_l[0] + HW.malgo2[f].slt_r[0] + HW.malgo2[f].slt_l[1]) ? (stkno + HW.malgo2[f].emp_l[0] + HW.malgo2[f].emp_m[0] + HW.malgo2[f].emp_r[0] + HW.malgo2[f].emp_l[1] + HW.malgo2[f].emp_m[1]) : (stkno + HW.malgo2[f].emp_l[0] + HW.malgo2[f].emp_m[0] + HW.malgo2[f].emp_r[0] + HW.malgo2[f].emp_l[1]))));
			int num2 = HW.malgo2[f].emp_l[0] + HW.malgo2[f].emp_m[0] + HW.malgo2[f].emp_r[0] + HW.malgo2[f].slt_l[0] + HW.malgo2[f].slt_r[0];
			if (num >= num2)
			{
				si = 1;
				p = num - num2;
			}
			else
			{
				si = 0;
				p = num;
			}
			return num;
		}

		public static Region common_getCSLRegion(PictureBox pb)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(new Rectangle(0, pb.Height / 2, pb.Width, 1));
			graphicsPath.AddRectangle(new Rectangle(pb.Width / 2, 0, 1, pb.Height));
			graphicsPath.FillMode = FillMode.Winding;
			return new Region(graphicsPath);
		}

		public static void common_addCSLforPicture(PictureBox main_pic, Color clr)
		{
			PictureBox pictureBox = new PictureBox();
			main_pic.Parent.Controls.Add(pictureBox);
			pictureBox.BorderStyle = BorderStyle.FixedSingle;
			pictureBox.Location = main_pic.Location;
			pictureBox.Size = main_pic.Size;
			pictureBox.BringToFront();
			pictureBox.BackColor = clr;
			pictureBox.Visible = true;
			pictureBox.Region = common_getCSLRegion(pictureBox);
		}

		public static bool common_is_size_match(float w, float h, float ref_w, float ref_h, float ref_delta)
		{
			float num = ((h > w) ? h : w);
			float num2 = ((h < w) ? h : w);
			float num3 = ((ref_h > ref_w) ? ref_h : ref_w);
			float num4 = ((ref_h < ref_w) ? ref_h : ref_w);
			float num5 = Math.Abs(num - num3) / num3 * 100f;
			float num6 = Math.Abs(num2 - num4) / num4 * 100f;
			if (num5 > ref_delta || num6 > ref_delta)
			{
				return false;
			}
			return true;
		}

		public static bool is_match_footprint(FootPrint fp, string name)
		{
			if (fp == null)
			{
				return false;
			}
			if (fp.name == name)
			{
				return true;
			}
			if (fp.nick_namelist != null && fp.nick_namelist.Count > 0)
			{
				for (int i = 0; i < fp.nick_namelist.Count; i++)
				{
					if (fp.nick_namelist[i] == name)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static void save_footprint_file(string filename, USR_LIB lib)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, lib);
			stream.Close();
		}

		public static USR_LIB load_footprint_file(string filename)
		{
			USR_LIB uSR_LIB = new USR_LIB();
			if (File.Exists(filename))
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
				try
				{
					uSR_LIB = (USR_LIB)formatter.Deserialize(stream);
				}
				catch (Exception)
				{
				}
				stream.Close();
				if (uSR_LIB.version == 0)
				{
					uSR_LIB.fpcatlist = new BindingList<FP_CAT>();
					FP_CAT fP_CAT = new FP_CAT();
					if (uSR_LIB.footlist != null)
					{
						for (int i = 0; i < uSR_LIB.footlist.Count; i++)
						{
							fP_CAT.footlist.Add(uSR_LIB.footlist[i]);
						}
						fP_CAT.index = uSR_LIB.index;
						fP_CAT.description = "其他";
					}
					uSR_LIB.fpcatlist.Add(fP_CAT);
					uSR_LIB.version = 1;
				}
			}
			return uSR_LIB;
		}

		public static USR_STACKLIB load_provider_file(string filename)
		{
			USR_STACKLIB result = new USR_STACKLIB();
			if (File.Exists(filename))
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
				result = (USR_STACKLIB)formatter.Deserialize(stream);
				stream.Close();
			}
			return result;
		}

		public static void save_provider_file(string filename, USR_STACKLIB lib)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, lib);
			stream.Close();
		}

		public static int common_mm_to_pixel(float mm, CameraType cam, int zn)
		{
			float num = 0f;
			switch (cam)
			{
			case CameraType.High:
				num = USR[mFn].mHighCamRatio[0];
				break;
			case CameraType.Fast:
				num = USR[mFn].mFastCamRatio[0][zn];
				break;
			case CameraType.Mark:
				num = USR[mFn].mMarkCamRatio[0];
				break;
			}
			return (int)((double)(mm * num) + 0.5);
		}

		public static void common_copy_footprint_to_cat(ChipCategoryElement cat, FootPrint footprint_data, int mode)
		{
			if (mode != 0)
			{
				cat.Footprint = footprint_data.name;
			}
			cat.Lenght = footprint_data.length;
			cat.Width = footprint_data.width;
			cat.Height = footprint_data.height;
			cat.Delta = footprint_data.delta;
			cat.threshold = footprint_data.threshold;
			cat.Cameratype = footprint_data.camera;
			cat.Visualtype = footprint_data.visual;
			cat.Looptype = footprint_data.loop;
			cat.Feedertype = footprint_data.feedertype;
			cat.Nozzletype0 = footprint_data.nozzle;
			cat.Nozzletype1 = footprint_data.nozzle2;
			cat.is_collect = footprint_data.iscollect;
			cat.Collect_Delta = footprint_data.collect_rate;
			cat.IsLowSpeed = footprint_data.islowspeed;
			cat.pik_h_offset = footprint_data.pik_offset;
			cat.zdown_speed = footprint_data.pik_down_speed;
			cat.zpik_delay = footprint_data.pik_delay;
			cat.zup_speed = footprint_data.pik_up_speed;
			cat.mnt_h_offset = footprint_data.mnt_offset;
			cat.zmnt_delay = footprint_data.mnt_delay;
			cat.zmnt_down_speed = footprint_data.mnt_down_speed;
			cat.zmnt_up_speed = footprint_data.mnt_up_speed;
		}

		public static void common_copy_footprint_to_emt(ChipBoardElement emt, FootPrint footprint_data, int mode)
		{
			if (mode != 0)
			{
				emt.Footprint = footprint_data.name;
			}
			emt.length = footprint_data.length;
			emt.width = footprint_data.width;
			emt.height = footprint_data.height;
			emt.sampik_delta = footprint_data.delta;
			emt.threshold = footprint_data.threshold;
			emt.Cameratype = footprint_data.camera;
			emt.Visualtype = footprint_data.visual;
			emt.Looptype = footprint_data.loop;
			emt.Feedertype = footprint_data.feedertype;
			emt.Stacktype = footprint_data.providertype;
			emt.Nozzletype = footprint_data.nozzle;
			emt.is_collect = footprint_data.iscollect;
			emt.collectdelta = footprint_data.collect_rate;
			emt.IsLowSpeed = footprint_data.islowspeed;
			emt.pik_h_offset = footprint_data.pik_offset;
			emt.zdown_speed = footprint_data.pik_down_speed;
			emt.zpik_delay = footprint_data.pik_delay;
			emt.zup_speed = footprint_data.pik_up_speed;
			emt.mnt_h_offset = footprint_data.mnt_offset;
			emt.zmnt_delay = footprint_data.mnt_delay;
			emt.zmnt_down_speed = footprint_data.mnt_down_speed;
			emt.zmnt_up_speed = footprint_data.mnt_up_speed;
		}

		public static void common_copy_cat_to_emt(ChipBoardElement emt, ChipCategoryElement cat)
		{
			emt.Material_value = cat.Material_value;
			emt.Footprint = cat.Footprint;
			emt.length = cat.Lenght;
			emt.width = cat.Width;
			emt.height = cat.Height;
			emt.scanR = cat.scan_r;
			emt.sampik_delta = cat.Delta;
			emt.threshold = cat.threshold;
			emt.Cameratype = cat.Cameratype;
			emt.Visualtype = cat.Visualtype;
			emt.Looptype = cat.Looptype;
			emt.Feedertype = cat.Feedertype;
			emt.Stacktype = common_get_providertype(cat.Feedertype);
			emt.Nozzletype = cat.Nozzletype0;
			emt.is_collect = cat.is_collect;
			emt.collectdelta = cat.Collect_Delta;
			emt.IsLowSpeed = cat.IsLowSpeed;
			emt.pik_h_offset = cat.pik_h_offset;
			emt.zdown_speed = cat.zdown_speed;
			emt.zpik_delay = cat.zpik_delay;
			emt.zup_speed = cat.zup_speed;
			emt.mnt_h_offset = cat.mnt_h_offset;
			emt.zmnt_delay = cat.zmnt_delay;
			emt.zmnt_down_speed = cat.zmnt_down_speed;
			emt.zmnt_up_speed = cat.zmnt_up_speed;
		}

		public static void common_copy_emt_to_cat(ChipCategoryElement cat, ChipBoardElement emt)
		{
			cat.Material_value = emt.Material_value;
			cat.Footprint = emt.Footprint;
			cat.Lenght = emt.length;
			cat.Width = emt.width;
			cat.Height = emt.height;
			cat.scan_r = emt.scanR;
			cat.Delta = emt.sampik_delta;
			cat.threshold = emt.threshold;
			cat.Cameratype = emt.Cameratype;
			cat.Visualtype = emt.Visualtype;
			cat.Looptype = emt.Looptype;
			cat.Feedertype = emt.Feedertype;
			cat.Nozzletype0 = emt.Nozzletype;
			cat.Nozzletype1 = emt.Nozzletype;
			cat.is_collect = emt.is_collect;
			cat.Collect_Delta = emt.collectdelta;
			cat.IsLowSpeed = emt.IsLowSpeed;
			cat.pik_h_offset = emt.pik_h_offset;
			cat.zdown_speed = emt.zdown_speed;
			cat.zpik_delay = emt.zpik_delay;
			cat.zup_speed = emt.zup_speed;
			cat.mnt_h_offset = emt.mnt_h_offset;
			cat.zmnt_delay = emt.zmnt_delay;
			cat.zmnt_down_speed = emt.zmnt_down_speed;
			cat.zmnt_up_speed = emt.zmnt_up_speed;
		}

		public static void common_copy_stackemt(StackElement d, StackElement s)
		{
			d.height = s.height;
			d.lenght = s.lenght;
			d.width = s.width;
			d.mChipFootprint = s.mChipFootprint;
			d.mChipValue = s.mChipValue;
			d.mCollectDelta = s.mCollectDelta;
			d.mCollectL = s.mCollectL;
			d.mCollectW = s.mCollectW;
			d.mEnabled = s.mEnabled;
			d.mFeederDelay = s.mFeederDelay;
			d.mIsCollect = s.mIsCollect;
			d.mIsLowSpeed = s.mIsLowSpeed;
			d.mIsScanR = s.mIsScanR;
			d.mnt_HmmOffset = s.mnt_HmmOffset;
			d.mSelected = s.mSelected;
			d.pik_HmmOffset = s.pik_HmmOffset;
			d.scanR = s.scanR;
			d.visualtype = s.visualtype;
			d.mXY.X = s.mXY.X;
			d.mXY.Y = s.mXY.Y;
			d.mPlt.mAutoEntTimeDelay = s.mPlt.mAutoEntTimeDelay;
			d.mPlt.mColumnNum = s.mPlt.mColumnNum;
			d.mPlt.mGuid = s.mPlt.mGuid;
			d.mPlt.mIsAutoEnt = s.mPlt.mIsAutoEnt;
			d.mPlt.mRowNum = s.mPlt.mRowNum;
			d.mPlt.mStartIndex = s.mPlt.mStartIndex;
			d.mPlt.mTotalNum = s.mPlt.mTotalNum;
			if (s.mPlt.mXYS != null)
			{
				for (int i = 0; i < s.mPlt.mXYS.Count(); i++)
				{
					d.mPlt.mXYS[i].X = s.mPlt.mXYS[i].X;
					d.mPlt.mXYS[i].Y = s.mPlt.mXYS[i].Y;
				}
			}
			if (s.mPlt.mXYlist != null)
			{
				d.mPlt.mXYlist = new BindingList<StackPlateXYElement>();
				for (int j = 0; j < s.mPlt.mXYlist.Count; j++)
				{
					d.mPlt.mXYlist.Add(new StackPlateXYElement(s.mPlt.mXYlist[j]));
				}
			}
			if (s.mPlt.mSubList != null)
			{
				d.mPlt.mSubList = new BindingList<sSubPlate>();
				for (int k = 0; k < s.mPlt.mSubList.Count; k++)
				{
					d.mPlt.mSubList.Add(new sSubPlate(s.mPlt.mSubList[k]));
				}
			}
			d.mZnData = new sData[8];
			for (int l = 0; l < 8; l++)
			{
				d.mZnData[l] = new sData(s.mZnData[l]);
			}
		}

		public static ProviderType common_get_providertype(FeederType feedertype)
		{
			switch (feedertype)
			{
			case FeederType.Plate:
				return ProviderType.Plate;
			case FeederType.Vibra:
				return ProviderType.Vibra;
			case FeederType.N_A:
			case FeederType.NUM:
				return ProviderType.Num;
			default:
				return ProviderType.Feedr;
			}
		}

		public static VisualType common_get_visual_from_str(string str)
		{
			for (int i = 0; i < 25; i++)
			{
				if (str == STR.VISUAL_STR[i][0] || str == STR.VISUAL_STR[i][1] || str == STR.VISUAL_STR[i][2])
				{
					return (VisualType)i;
				}
			}
			return VisualType.N_A;
		}

		public static LoopType common_get_loop_from_str(string str)
		{
			for (int i = 0; i < 4; i++)
			{
				if (str == STR.LOOP_STR[i][0] || str == STR.VISUAL_STR[i][1] || str == STR.VISUAL_STR[i][2])
				{
					return (LoopType)i;
				}
			}
			return LoopType.N_A;
		}

		public static DialogResult CmMessageBox(string msg, MessageBoxButtons btmode)
		{
			Form_MessageBox form_MessageBox = new Form_MessageBox(msg, btmode);
			form_MessageBox.TopMost = true;
			return form_MessageBox.ShowDialog();
		}

		public static void CmMessageBoxTop_Ok(string msg)
		{
			static_this.Invoke(new dg_MessageBoxShow_s_b(CmMessageBox), msg, MessageBoxButtons.OK);
		}

		public static DialogResult CmMessageBoxTop(string msg, MessageBoxButtons btmode)
		{
			return (DialogResult)static_this.Invoke(new dg_MessageBoxShow_s_b(CmMessageBox), msg, btmode);
		}

		public static bool common_is_string_alldifferent(BindingList<string> list)
		{
			if (list == null || list.Count <= 1)
			{
				return true;
			}
			for (int i = 0; i < list.Count - 1; i++)
			{
				for (int j = i + 1; j < list.Count; j++)
				{
					if (list[i] == list[j])
					{
						return false;
					}
				}
			}
			return true;
		}

		public static void common_waiting_start(string str, int ms)
		{
			waiting_str = str;
			waiting_milislots = ms;
			waiting_str_lines = 1;
			Thread thread = new Thread(thd_common_flush_waiting);
			thread.IsBackground = true;
			thread.Start();
		}

		public static void common_waiting_start(string str, int ms, int str_lines)
		{
			waiting_str = str;
			waiting_milislots = ms;
			waiting_str_lines = str_lines;
			Thread thread = new Thread(thd_common_flush_waiting);
			thread.IsBackground = true;
			thread.Start();
		}

		public static void common_waiting_break()
		{
			if (waiting_form != null)
			{
				waiting_form.set_return();
			}
		}

		public static void thd_common_flush_waiting()
		{
			if (waiting_form != null && !waiting_form.IsDisposed)
			{
				common_waiting_break();
				Thread.Sleep(5);
			}
			waiting_form = new Form_Waiting(waiting_str, waiting_milislots, waiting_str_lines);
			waiting_form.StartPosition = FormStartPosition.Manual;
			waiting_form.Location = new Point((1280 - waiting_form.Size.Width) / 2, (1024 - waiting_form.Size.Height) / 2);
			waiting_form.ShowDialog();
		}

		public static int get_max_importno(BindingList<ChipBoardElement> pointlist)
		{
			int num = -1;
			if (pointlist != null)
			{
				for (int i = 0; i < pointlist.Count; i++)
				{
					if (pointlist[i].ImportNo > num)
					{
						num = pointlist[i].ImportNo;
					}
				}
			}
			return num;
		}

		public static int get_max_group(BindingList<ChipBoardElement> pointlist)
		{
			int num = 0;
			if (pointlist != null)
			{
				for (int i = 0; i < pointlist.Count; i++)
				{
					if (pointlist[i].Group > num)
					{
						num = pointlist[i].Group;
					}
				}
			}
			return num;
		}

		public static void Copy_ChipBoardElement(ChipBoardElement dest, ChipBoardElement srcemt, int mode, bool isguid)
		{
			if (mode == 0)
			{
				dest.Arrayno = srcemt.Arrayno;
				dest.Arrayno_S = srcemt.Arrayno_S;
				dest.Group = srcemt.Group;
				dest.isOptimization = srcemt.isOptimization;
				dest.Nozzle = srcemt.Nozzle;
				dest.samePikNo = srcemt.samePikNo;
				dest.Stack_no = srcemt.Stack_no;
				dest.ImportNo = srcemt.ImportNo;
				if (isguid)
				{
					dest.Guid = srcemt.Guid;
				}
			}
			dest.Ismount = srcemt.Ismount;
			dest.Cameratype = srcemt.Cameratype;
			dest.Cameratype_S = srcemt.Cameratype_S;
			dest.Footprint = srcemt.Footprint;
			dest.IsLowSpeed = srcemt.IsLowSpeed;
			dest.Labeltab = srcemt.Labeltab;
			dest.Material_value = srcemt.Material_value;
			dest.Stacktype = srcemt.Stacktype;
			dest.Visualtype = srcemt.Visualtype;
			dest.Visualtype_S = srcemt.Visualtype_S;
			dest.Looptype = srcemt.Looptype;
			dest.X = srcemt.X;
			dest.Y = srcemt.Y;
			dest.A = srcemt.A;
			dest.X_Real = srcemt.X_Real;
			dest.Y_Real = srcemt.Y_Real;
			dest.A_Real = srcemt.A_Real;
			dest.isAngle180 = srcemt.isAngle180;
			dest.isAix = srcemt.isAix;
			dest.Feedertype = srcemt.Feedertype;
			dest.Nozzletype = srcemt.Nozzletype;
			dest.scanR = srcemt.scanR;
			dest.threshold = srcemt.threshold;
			dest.length = srcemt.length;
			dest.width = srcemt.width;
			dest.height = srcemt.height;
			dest.is_collect = srcemt.is_collect;
			dest.collectdelta = srcemt.collectdelta;
			dest.pik_h_offset = srcemt.pik_h_offset;
			dest.mnt_h_offset = srcemt.mnt_h_offset;
			dest.zup_speed = srcemt.zup_speed;
			dest.zdown_speed = srcemt.zdown_speed;
			dest.zpik_delay = srcemt.zpik_delay;
			dest.zmnt_delay = srcemt.zmnt_delay;
			dest.zmnt_up_speed = srcemt.zmnt_up_speed;
			dest.zmnt_down_speed = srcemt.zmnt_down_speed;
			dest.sampik_delta = srcemt.sampik_delta;
			dest.is_high = srcemt.is_high;
		}

		public static void pcbsmt_reorder_groups(USR3_DATA usr3)
		{
			if (usr3.mPointlistSmt == null || usr3.mPointlistSmt.Count <= 0)
			{
				return;
			}
			BindingList<BindingList<ChipBoardElement>> bindingList = new BindingList<BindingList<ChipBoardElement>>();
			int num = 0;
			int num2 = -1;
			int num3 = -1;
			for (num = 0; num < usr3.mPointlistSmt.Count; num++)
			{
				if (usr3.mPointlistSmt[num].Group == num3)
				{
					bindingList[num2].Add(usr3.mPointlistSmt[num]);
					continue;
				}
				int num4 = 0;
				for (num4 = 0; num4 < bindingList.Count; num4++)
				{
					if (bindingList[num4].Count > 0 && usr3.mPointlistSmt[num].Group == bindingList[num4][0].Group)
					{
						bindingList[num4].Add(usr3.mPointlistSmt[num]);
						break;
					}
				}
				if (num4 == bindingList.Count)
				{
					num2++;
					num3 = usr3.mPointlistSmt[num].Group;
					BindingList<ChipBoardElement> item = new BindingList<ChipBoardElement>();
					bindingList.Add(item);
					bindingList[num2].Add(usr3.mPointlistSmt[num]);
				}
			}
			usr3.mPointlistSmt.Clear();
			for (num2 = 0; num2 < bindingList.Count; num2++)
			{
				for (int i = 0; i < bindingList[num2].Count; i++)
				{
					usr3.mPointlistSmt.Add(bindingList[num2][i]);
				}
			}
		}

		public static void pcbsmt_refresh_groups(USR3_DATA usr3)
		{
			pcbsmt_reorder_groups(usr3);
			if (usr3.mPointlistSmt == null || usr3.mPointlistSmt.Count <= 0)
			{
				return;
			}
			BindingList<BindingList<ChipBoardElement>> bindingList = new BindingList<BindingList<ChipBoardElement>>();
			int num = 0;
			int num2 = -1;
			int num3 = -1;
			for (num = 0; num < usr3.mPointlistSmt.Count; num++)
			{
				if (usr3.mPointlistSmt[num].Group != num3)
				{
					num2++;
					num3 = usr3.mPointlistSmt[num].Group;
					BindingList<ChipBoardElement> item = new BindingList<ChipBoardElement>();
					bindingList.Add(item);
				}
				bindingList[num2].Add(usr3.mPointlistSmt[num]);
			}
			for (num2 = 0; num2 < bindingList.Count; num2++)
			{
				for (int i = 0; i < bindingList[num2].Count; i++)
				{
					bindingList[num2][i].Group = num2 + 1;
				}
			}
			usr3.mPointlistSmtGroup = bindingList;
		}

		public static void pcbsmt_refresh_arrays(USR3_DATA usr3)
		{
			if (usr3.mPointlist == null || usr3.mPointlist.Count <= 0 || usr3.mArrayPCBRow * usr3.mArrayPCBColumn <= 0)
			{
				return;
			}
			BindingList<ChipBoardElement>[] array = new BindingList<ChipBoardElement>[usr3.mArrayPCBRow * usr3.mArrayPCBColumn];
			BindingList<ChipBoardElement>[] array2 = new BindingList<ChipBoardElement>[usr3.mArrayPCBRow * usr3.mArrayPCBColumn];
			for (int i = 0; i < usr3.mArrayPCBRow * usr3.mArrayPCBColumn; i++)
			{
				array[i] = new BindingList<ChipBoardElement>();
				array2[i] = new BindingList<ChipBoardElement>();
			}
			int count = usr3.mPointlist.Count;
			for (int j = 0; j < count; j++)
			{
				if (usr3.mPointlist[j].Arrayno == 0)
				{
					if (!usr3.mPointlist[j].isAix)
					{
						array[0].Add(usr3.mPointlist[j]);
					}
					if (usr3.mPointlist[j].isAix)
					{
						array2[0].Add(usr3.mPointlist[j]);
					}
				}
			}
			for (int k = 0; k < array[0].Count; k++)
			{
				usr3.mPointlist.Remove(array[0][k]);
			}
			for (int l = 0; l < array2[0].Count; l++)
			{
				usr3.mPointlist.Remove(array2[0][l]);
			}
			for (int m = 0; m < array[0].Count; m++)
			{
				string guid = array[0][m].Guid;
				_ = array[0][m].Labeltab;
				_ = array[0][m].Material_value;
				_ = array[0][m].Footprint;
				for (int num = usr3.mPointlist.Count - 1; num >= 0; num--)
				{
					if (usr3.mPointlist[num].Guid == guid)
					{
						int arrayno = usr3.mPointlist[num].Arrayno;
						if (!usr3.mPointlist[num].isAix)
						{
							array[arrayno].Add(usr3.mPointlist[num]);
						}
						else
						{
							array2[arrayno].Add(usr3.mPointlist[num]);
						}
						usr3.mPointlist.RemoveAt(num);
					}
				}
			}
			for (int n = 0; n < usr3.mPointlist.Count; n++)
			{
				int arrayno2 = usr3.mPointlist[n].Arrayno;
				if (!usr3.mPointlist[n].isAix)
				{
					array[arrayno2].Add(usr3.mPointlist[n]);
				}
				else
				{
					array2[arrayno2].Add(usr3.mPointlist[n]);
				}
			}
			usr3.mPointlist.Clear();
			for (int num2 = 0; num2 < usr3.mArrayPCBRow * usr3.mArrayPCBColumn; num2++)
			{
				for (int num3 = 0; num3 < array[num2].Count; num3++)
				{
					usr3.mPointlist.Add(array[num2][num3]);
				}
				for (int num4 = 0; num4 < array2[num2].Count; num4++)
				{
					usr3.mPointlist.Add(array2[num2][num4]);
				}
				array[num2].Clear();
				array2[num2].Clear();
			}
		}

		public static void init_common_var()
		{
			mIsBuzzerWarning = new bool[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mIsBuzzerWarning[i] = false;
			}
		}

		public static void start_buzzer_warning(int fn)
		{
			mIsBuzzerWarning[fn] = true;
			Thread thread = new Thread(thd_buzzer_warning);
			thread.IsBackground = true;
			thread.Start(fn);
		}

		public static void stop_buzzer_warning(int fn)
		{
			mIsBuzzerWarning[fn] = false;
			Thread.Sleep(400);
		}

		public static void thd_buzzer_warning(object o)
		{
			int num = (int)o;
			QnConnectionClass qnConnectionClass = mConDev[num];
			if (HW.mDeviceType == DeviceType.DSQ800_120F)
			{
				qnConnectionClass = mConDevExt[0];
			}
			while (mIsBuzzerWarning[num])
			{
				qnConnectionClass.sendSwitchAlarmLamp(1, 2);
				mConDev[num].sendBuzzerOnOff(1);
				Thread.Sleep(400);
				qnConnectionClass.sendSwitchAlarmLamp(0, 2);
				mConDev[num].sendBuzzerOnOff(0);
				Thread.Sleep(400);
			}
			qnConnectionClass.sendSwitchAlarmLamp(0, 2);
			mConDev[num].sendBuzzerOnOff(0);
			Thread.Sleep(400);
		}

		public static void set_warningalarm_idle()
		{
			QnConnectionClass qnConnectionClass = mConDev[0];
			if (HW.mDeviceType == DeviceType.DSQ800_120F)
			{
				qnConnectionClass = mConDevExt[0];
			}
			if (USR_INIT.mWarningAlarmMode == 0)
			{
				qnConnectionClass.sendSwitchAlarmLamp(1);
				qnConnectionClass.sendSwitchAlarmLamp(0, 1);
				qnConnectionClass.sendSwitchAlarmLamp(0, 2);
			}
			else if (USR_INIT.mWarningAlarmMode == 1)
			{
				qnConnectionClass.sendSwitchAlarmLamp(0);
				qnConnectionClass.sendSwitchAlarmLamp(1, 1);
				qnConnectionClass.sendSwitchAlarmLamp(0, 2);
			}
		}

		public static void set_warningalarm_run()
		{
			QnConnectionClass qnConnectionClass = mConDev[0];
			if (HW.mDeviceType == DeviceType.DSQ800_120F)
			{
				qnConnectionClass = mConDevExt[0];
			}
			if (USR_INIT.mWarningAlarmMode == 0)
			{
				qnConnectionClass.sendSwitchAlarmLamp(0);
				qnConnectionClass.sendSwitchAlarmLamp(1, 1);
				qnConnectionClass.sendSwitchAlarmLamp(0, 2);
			}
			else if (USR_INIT.mWarningAlarmMode == 1)
			{
				qnConnectionClass.sendSwitchAlarmLamp(1);
				qnConnectionClass.sendSwitchAlarmLamp(0, 1);
				qnConnectionClass.sendSwitchAlarmLamp(0, 2);
			}
		}

		public static void CreateAddButtonPic(Button btn)
		{
			Bitmap map0 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData = map0.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap map1 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData2 = map1.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap map2 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData3 = map2.LockBits(new Rectangle(0, 0, map0.Width, map0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			moon_qign_button_create(btn.Size.Width, btn.Size.Height, bitmapData.Scan0, 210, 210, 210, bitmapData2.Scan0, 230, 216, 173, bitmapData3.Scan0, 230, 216, 173);
			map0.UnlockBits(bitmapData);
			map1.UnlockBits(bitmapData2);
			map2.UnlockBits(bitmapData3);
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
			btn.BackgroundImage = map0;
			btn.MouseEnter += delegate(object sender, EventArgs e)
			{
				((Button)sender).BackgroundImage = map1;
			};
			btn.MouseLeave += delegate(object sender, EventArgs e)
			{
				((Button)sender).BackgroundImage = map0;
			};
			btn.MouseDown += delegate(object sender, MouseEventArgs e)
			{
				((Button)sender).BackgroundImage = map2;
			};
			btn.MouseUp += delegate(object sender, MouseEventArgs e)
			{
				((Button)sender).BackgroundImage = map1;
			};
		}

		public static int mapping_x(int fn, int x)
		{
			if (HW.mRstConner[fn] != 1)
			{
				return x;
			}
			return HW.mMaxX[fn] - x;
		}

		public static void CreateAddButtonPic2(Button btn)
		{
			Bitmap bitmap = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap bitmap2 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap map2 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData3 = map2.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			moon_qign_button_create(btn.Size.Width, btn.Size.Height, bitmapData.Scan0, 150, 150, 150, bitmapData2.Scan0, 150, 150, 150, bitmapData3.Scan0, 50, 50, 255);
			bitmap.UnlockBits(bitmapData);
			bitmap2.UnlockBits(bitmapData2);
			map2.UnlockBits(bitmapData3);
			ButtonTag buttonTag = new ButtonTag();
			buttonTag.map0 = bitmap;
			buttonTag.map1 = bitmap2;
			buttonTag.map2 = map2;
			btn.Tag = buttonTag;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
			btn.BackgroundImage = bitmap;
			btn.MouseDown += delegate(object sender, MouseEventArgs e)
			{
				((Button)sender).BackgroundImage = map2;
			};
		}

		public static void common_setButton_PressDownMode(CnButton btn, bool init_flag, Color c0, Color c1)
		{
			btn.CnButtonMode = ButtonModeEn.PressDown;
			btn.BackColor = c0;
			btn.CnPressDownColor = c1;
			btn.CnSetPressDown(init_flag);
		}

		public static void SelButton_OnOff(Button btn, bool init_flag, Color c0, Color c1, Color c2)
		{
			Bitmap bitmap = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap bitmap2 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Bitmap bitmap3 = new Bitmap(btn.Size.Width, btn.Size.Height, PixelFormat.Format32bppRgb);
			BitmapData bitmapData3 = bitmap3.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			moon_qign_button_create(btn.Size.Width, btn.Size.Height, bitmapData.Scan0, c0.B, c0.G, c0.R, bitmapData2.Scan0, c1.B, c1.G, c1.R, bitmapData3.Scan0, c2.B, c2.G, c2.R);
			bitmap.UnlockBits(bitmapData);
			bitmap2.UnlockBits(bitmapData2);
			bitmap3.UnlockBits(bitmapData3);
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
			if (init_flag)
			{
				btn.BackgroundImage = bitmap3;
			}
			else
			{
				btn.BackgroundImage = bitmap;
			}
			ButtonTag buttonTag = new ButtonTag();
			buttonTag.tag = (init_flag ? 1 : 0);
			buttonTag.map0 = bitmap;
			buttonTag.map1 = bitmap2;
			buttonTag.map2 = bitmap3;
			btn.Tag = buttonTag;
			btn.MouseDown += delegate(object sender, MouseEventArgs e)
			{
				if (btn.Tag != null)
				{
					ButtonTag buttonTag2 = (ButtonTag)btn.Tag;
					if (buttonTag2.tag == 0)
					{
						((Button)sender).BackgroundImage = buttonTag2.map2;
						buttonTag2.tag = 1;
					}
					else
					{
						((Button)sender).BackgroundImage = buttonTag2.map1;
						buttonTag2.tag = 0;
					}
				}
			};
		}

		public static PinConfig common_footprint_get_pinconfig(string footprint_name)
		{
			PinConfig result = default(PinConfig);
			if (FP_PATH.mFootprintLib_NameList == null || FP_PATH.mFootprintLib_NameList.Count <= 0 || FP_PATH.mFootprintLib_Index < 0 || FP_PATH.mFootprintLib_Index > FP_PATH.mFootprintLib_NameList.Count)
			{
				write_to_logFile("封装库文件为空，请先去[封装库]里新建或添加封装库文件!");
				return result;
			}
			bool flag = false;
			for (int i = 0; i < FP_PATH.mFootprintLib_NameList.Count; i++)
			{
				USR_LIB uSR_LIB = load_footprint_file(FP_PATH.mFootprintLib_NameList[i]);
				if (uSR_LIB.fpcatlist == null)
				{
					uSR_LIB.fpcatlist = new BindingList<FP_CAT>();
				}
				flag = false;
				for (int j = 0; j < uSR_LIB.fpcatlist.Count; j++)
				{
					BindingList<FootPrint> footlist = uSR_LIB.fpcatlist[j].footlist;
					if (footlist == null)
					{
						continue;
					}
					for (int k = 0; k < footlist.Count; k++)
					{
						if (footprint_name == footlist[k].name)
						{
							flag = true;
						}
						else if (footlist[k].nick_namelist != null)
						{
							for (int l = 0; l < footlist[k].nick_namelist.Count; l++)
							{
								if (footprint_name == footlist[k].nick_namelist[l])
								{
									flag = true;
									break;
								}
							}
						}
						if (flag)
						{
							result.pin_mode = (int)footlist[k].pin_mode;
							result.is_defects_detection = footlist[k].is_defects_detection;
							result.is_pin_diff = footlist[k].is_pin_diff;
							result.pin_side_dis = footlist[k].side_dis;
							result.pin_side_dis2 = footlist[k].side_dis2;
							result.pin_count = footlist[k].pin_count;
							result.pin_length = footlist[k].pin_length;
							result.pin_width = footlist[k].pin_width;
							result.pin_slot = footlist[k].pin_slot;
							result.pin_dis = footlist[k].pin_dis;
							result.pin_offset = footlist[k].pin_offset;
							result.pin_count1 = (footlist[k].is_pin_diff ? footlist[k].pin_count1 : footlist[k].pin_count);
							result.pin_length1 = (footlist[k].is_pin_diff ? footlist[k].pin_length1 : footlist[k].pin_length);
							result.pin_width1 = (footlist[k].is_pin_diff ? footlist[k].pin_width1 : footlist[k].pin_width);
							result.pin_slot1 = (footlist[k].is_pin_diff ? footlist[k].pin_slot1 : footlist[k].pin_slot);
							result.pin_dis1 = (footlist[k].is_pin_diff ? footlist[k].pin_dis1 : footlist[k].pin_dis);
							result.pin_offset1 = (footlist[k].is_pin_diff ? footlist[k].pin_offset1 : footlist[k].pin_offset);
							result.pin_count2 = (footlist[k].is_pin_diff ? footlist[k].pin_count2 : footlist[k].pin_count);
							result.pin_length2 = (footlist[k].is_pin_diff ? footlist[k].pin_length2 : footlist[k].pin_length);
							result.pin_width2 = (footlist[k].is_pin_diff ? footlist[k].pin_width2 : footlist[k].pin_width);
							result.pin_slot2 = (footlist[k].is_pin_diff ? footlist[k].pin_slot2 : footlist[k].pin_slot);
							result.pin_dis2 = (footlist[k].is_pin_diff ? footlist[k].pin_dis2 : footlist[k].pin_dis);
							result.pin_offset2 = (footlist[k].is_pin_diff ? footlist[k].pin_offset2 : footlist[k].pin_offset);
							result.pin_count3 = (footlist[k].is_pin_diff ? footlist[k].pin_count2 : footlist[k].pin_count);
							result.pin_length3 = (footlist[k].is_pin_diff ? footlist[k].pin_length2 : footlist[k].pin_length);
							result.pin_width3 = (footlist[k].is_pin_diff ? footlist[k].pin_width2 : footlist[k].pin_width);
							result.pin_slot3 = (footlist[k].is_pin_diff ? footlist[k].pin_slot2 : footlist[k].pin_slot);
							result.pin_dis3 = (footlist[k].is_pin_diff ? footlist[k].pin_dis2 : footlist[k].pin_dis);
							result.pin_offset3 = (footlist[k].is_pin_diff ? footlist[k].pin_offset2 : footlist[k].pin_offset);
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			return result;
		}

		public static void common_set_pinconfig2visinput(ref VisInput vis_input, PinConfig pinconfig)
		{
			vis_input.footprint_pinmode = pinconfig.pin_mode;
			vis_input.is_defects_detection = (pinconfig.is_defects_detection ? 1 : 0);
			vis_input.is_pin_diff = (pinconfig.is_pin_diff ? 1 : 0);
			vis_input.pin_side_dis = pinconfig.pin_side_dis;
			vis_input.pin_side_dis2 = pinconfig.pin_side_dis2;
			vis_input.pin0_counts = pinconfig.pin_count;
			vis_input.pin0_l = pinconfig.pin_length;
			vis_input.pin0_w = pinconfig.pin_width;
			vis_input.pin0_slot = pinconfig.pin_slot;
			vis_input.pin0_dis = pinconfig.pin_dis;
			vis_input.pin0_offset = pinconfig.pin_offset;
			vis_input.pin1_counts = pinconfig.pin_count1;
			vis_input.pin1_l = pinconfig.pin_length1;
			vis_input.pin1_w = pinconfig.pin_width1;
			vis_input.pin1_slot = pinconfig.pin_slot1;
			vis_input.pin1_dis = pinconfig.pin_dis1;
			vis_input.pin1_offset = pinconfig.pin_offset1;
			vis_input.pin2_counts = pinconfig.pin_count2;
			vis_input.pin2_l = pinconfig.pin_length2;
			vis_input.pin2_w = pinconfig.pin_width2;
			vis_input.pin2_slot = pinconfig.pin_slot2;
			vis_input.pin2_dis = pinconfig.pin_dis2;
			vis_input.pin2_offset = pinconfig.pin_offset2;
			vis_input.pin3_counts = pinconfig.pin_count3;
			vis_input.pin3_l = pinconfig.pin_length3;
			vis_input.pin3_w = pinconfig.pin_width3;
			vis_input.pin3_slot = pinconfig.pin_slot3;
			vis_input.pin3_dis = pinconfig.pin_dis3;
			vis_input.pin3_offset = pinconfig.pin_offset3;
		}

		public static void common_updateLanguage(int lan, List<LanguageItem> itemlist)
		{
			foreach (LanguageItem item in itemlist)
			{
				if (item.str[lan] != null)
				{
					item.ctrl.Text = item.str[lan];
				}
				if (item.font != null && item.fsize != null)
				{
					if (item.ctrl.Font.Size > 5f)
					{
						item.ctrl.Font = new Font(item.font[lan], item.ctrl.Font.Size + item.fsize[lan], item.ctrl.Font.Style);
					}
					continue;
				}
				switch (lan)
				{
				case 2:
					item.ctrl.Font = new Font("Oswald", item.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					item.ctrl.Font = new Font("微软雅黑", item.ctrl.Font.Size, item.ctrl.Font.Style);
					break;
				}
			}
		}

		public static void common_updateLanguage(int lan, List<LanguageToolStripMenuItem> itemlist)
		{
			foreach (LanguageToolStripMenuItem item in itemlist)
			{
				if (item.str[lan] != null)
				{
					item.ctrl.Text = item.str[lan];
				}
				if (item.font != null && item.fsize != null)
				{
					if (item.ctrl.Font.Size > 5f)
					{
						item.ctrl.Font = new Font(item.font[lan], item.ctrl.Font.Size + item.fsize[lan], item.ctrl.Font.Style);
					}
					continue;
				}
				switch (lan)
				{
				case 2:
					item.ctrl.Font = new Font("Oswald", item.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					item.ctrl.Font = new Font("微软雅黑", item.ctrl.Font.Size, item.ctrl.Font.Style);
					break;
				}
			}
		}

		private void vsplus_visual_algorithms_debug(string mypath)
		{
			if (!mMutex_PushButton)
			{
				mMutex_PushButton = true;
				Thread thread = new Thread(thd_algorithms_debug);
				thread.IsBackground = false;
				thread.Start(mypath);
			}
		}

		private void thd_algorithms_debug(object o)
		{
			string filename = (string)o;
			PinConfig pinconfig = common_footprint_get_pinconfig(USR[mFn].mTest_FootprintName);
			if (mCurCam[mFn] == CameraType.Fast)
			{
				VisualType mTest_VisualType = USR[mFn].mTest_VisualType;
				int num = mZn[mFn];
				mJVSBitmap[num] = new Bitmap(filename);
				VISUAL_RESULT visual_result = new VISUAL_RESULT();
				visual_result.is_test = true;
				visual_result.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
				visual_result.set_pinconfig(pinconfig);
				if (ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.Fast, mTest_VisualType, USR[mFn].mTest_ScanR, USR[mFn].mTest_Threshold, mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
				{
					CmMessageBox((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "快速相机识别测试识别失败", MessageBoxButtons.OK);
				}
			}
			else if (mCurCam[mFn] == CameraType.Mark)
			{
				VisualType mTest_VisualType2 = USR[mFn].mTest_VisualType;
				_ = HW.mMarkCamItem[mFn].index[0];
				VISUAL_RESULT visual_result2 = new VISUAL_RESULT();
				mTest_VisualType2 = VisualType.MarkAutoPikXY;
				visual_result2.is_test = true;
				visual_result2.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
				visual_result2.set_pinconfig(pinconfig);
				if (ImageVisual(mFn, VISUAL_MODE.AUTODELTA_MARK, CameraType.Mark, mTest_VisualType2, USR[mFn].mTest_ScanR, USR[mFn].mTest_Threshold, mZn[mFn], 0, 0, 0f, ref visual_result2) != 0)
				{
					CmMessageBox((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "MARK相机识别测试识别失败", MessageBoxButtons.OK);
				}
			}
			else if (mCurCam[mFn] == CameraType.High)
			{
				VisualType mTest_VisualType3 = USR[mFn].mTest_VisualType;
				int num2 = 1;
				mZn[mFn] = num2;
				Bitmap bitmap = new Bitmap(filename);
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, 1944, 1944), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
				pKSJBuffer = new byte[1][];
				pKSJBuffer[0] = new byte[11337408];
				Marshal.Copy(bitmapData.Scan0, pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 0, 11337408);
				bitmap.UnlockBits(bitmapData);
				VISUAL_RESULT visual_result3 = new VISUAL_RESULT();
				visual_result3.is_test = true;
				visual_result3.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
				visual_result3.set_pinconfig(pinconfig);
				if (ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.High, mTest_VisualType3, USR[mFn].mTest_ScanR, USR[mFn].mTest_Threshold, mZn[mFn], 0, 0, 0f, ref visual_result3) != 0)
				{
					CmMessageBox((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "高清相机识别测试识别失败", MessageBoxButtons.OK);
				}
			}
			mMutex_PushButton = false;
		}

		private void vsplus_visual_algorithms_running_debug(string mypath)
		{
			if (!mIsVisualRunning)
			{
				mIsVisualRunning = true;
				Thread thread = new Thread(thd_algorithm_debug_visualrunning);
				thread.IsBackground = true;
				thread.Start(mypath);
			}
			else
			{
				mIsVisualRunning = false;
			}
		}

		private void thd_algorithm_debug_visualrunning(object o)
		{
			string filename = (string)o;
			PinConfig pinconfig = common_footprint_get_pinconfig(USR[mFn].mTest_FootprintName);
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			visual_result.is_test = true;
			Invoke((MethodInvoker)delegate
			{
				pictureBox_visualrunning[mFn].Visible = true;
				button_stop_runningvisual[mFn].Visible = true;
				button_stop_runningvisual[mFn].BringToFront();
				uc_usroperarion[mFn].hiden_cam_button(flag: true);
			});
			while (mIsVisualRunning)
			{
				VisualType mTest_VisualType = USR[mFn].mTest_VisualType;
				int mfcam_scanr = USR[mFn].mfcam_scanr;
				int mfcam_threshold = USR[mFn].mfcam_threshold;
				if (mCurCam[mFn] == CameraType.Fast)
				{
					int num = mZn[mFn];
					mJVSBitmap[num] = new Bitmap(filename);
					mfcam_scanr = USR[mFn].mfcam_scanr;
					mfcam_threshold = USR[mFn].mfcam_threshold;
					if (uc_usroperarion[mFn] != null && !uc_usroperarion[mFn].IsDisposed)
					{
						uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
					}
					fhcam_led_on(mFn, CameraType.Fast, flag: true);
					visual_result.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
					visual_result.set_pinconfig(pinconfig);
					ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.Fast, mTest_VisualType, mfcam_scanr, mfcam_threshold, mZn[mFn], 0, 0, 0f, ref visual_result);
				}
				else if (mCurCam[mFn] == CameraType.High)
				{
					int num2 = 1;
					mZn[mFn] = num2;
					Bitmap bitmap = new Bitmap(filename);
					BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, 1944, 1944), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
					pKSJBuffer = new byte[1][];
					pKSJBuffer[0] = new byte[11337408];
					Marshal.Copy(bitmapData.Scan0, pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 0, 11337408);
					bitmap.UnlockBits(bitmapData);
					mfcam_scanr = USR[mFn].mhcam_scanr;
					mfcam_threshold = USR[mFn].mhcam_threshold;
					if (uc_usroperarion[mFn] != null && !uc_usroperarion[mFn].IsDisposed)
					{
						uc_usroperarion[mFn].switch_to_cam(CameraType.High);
					}
					fhcam_led_on(mFn, CameraType.High, flag: true);
					VISUAL_MODE vISUAL_MODE = VISUAL_MODE.HIGHCAM_SMT_AUTOSIZE;
					vISUAL_MODE = VISUAL_MODE.COMMON;
					visual_result.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
					visual_result.set_pinconfig(pinconfig);
					ImageVisual(mFn, vISUAL_MODE, CameraType.High, mTest_VisualType, mfcam_scanr, mfcam_threshold, mZn[mFn], 0, 0, 0f, ref visual_result);
				}
				Thread.Sleep(20);
			}
			Invoke((MethodInvoker)delegate
			{
				pictureBox_visualrunning[mFn].Visible = false;
				button_stop_runningvisual[mFn].Visible = false;
				uc_usroperarion[mFn].hiden_cam_button(flag: false);
			});
			mark_light_on(mFn, flag: true);
		}

		private bool vsplus_visual_algorithms(string o)
		{
			PinConfig pinconfig = common_footprint_get_pinconfig(USR[mFn].mTest_FootprintName);
			VisualType visual = USR[mFn].mTest_VisualType;
			int num = 1;
			mZn[mFn] = num;
			if (mCurCam[mFn] == CameraType.Mark)
			{
				num = HW.mMarkCamItem[mFn].index[0];
				visual = VisualType.MarkAutoPikXY;
			}
			mJVSBitmap[num] = new Bitmap(o);
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			visual_result.is_test = true;
			visual_result.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
			visual_result.set_pinconfig(pinconfig);
			if (ImageVisual(mFn, VISUAL_MODE.COMMON, mCurCam[mFn], visual, USR[mFn].mfcam_scanr, USR[mFn].mfcam_threshold, mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
			{
				return false;
			}
			return true;
		}

		private void MainForm0_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.T == e.KeyCode && e.Shift && e.Control && e.Alt)
			{
				button_TempTest_Click(sender, e);
			}
			else if (Keys.U == e.KeyCode && e.Shift && e.Control && e.Alt)
			{
				panel_color.Visible = true;
			}
			else if (Keys.I == e.KeyCode && e.Shift && e.Control && e.Alt)
			{
				panel_color.Visible = false;
			}
		}

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int purple_jvs_register(IntPtr hWnd, int dwNotifyMsg);

		[DllImport("moon_boxes.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int purple_jvs_postmessage(int flag, int ch);

		private void button_TempTest_Click(object sender, EventArgs e)
		{
			mIsSimulation = true;
			init_simulation();
		}

		private void init_simulation()
		{
			if (mPortName == null)
			{
				mPortName = new BindingList<string>();
			}
			mPortName.Clear();
			for (int i = 0; i < HW.mConNum; i++)
			{
				mPortName.Add("COM" + (i + 1));
			}
			if (mPortBautRate == null)
			{
				mPortBautRate = new BindingList<int>();
			}
			mPortBautRate.Clear();
			for (int j = 0; j < HW.mConNum; j++)
			{
				mPortBautRate.Add(460800);
			}
			Form_BoxSel form_BoxSel = new Form_BoxSel("选择小相机驱动类型", "1280x720", "704x576", "");
			if (form_BoxSel.ShowDialog() == DialogResult.OK)
			{
				mJvsDriver = JvsDriver.MV360;
			}
			else
			{
				mJvsDriver = JvsDriver.JVS900;
			}
			for (int k = 0; k < HW.mFnNum; k++)
			{
				uc_job[k].set_simulation();
			}
			mJvs_rawWidth = CAMS.META[(int)mJvsDriver].rawsize.Width;
			mJvs_rawHeight = CAMS.META[(int)mJvsDriver].rawsize.Height;
			mJvs_usrWidth = CAMS.META[(int)mJvsDriver].usrsize.Width;
			mJvs_usrHeight = CAMS.META[(int)mJvsDriver].usrsize.Height;
			mJVS_OpenedPreviewMask = 0;
			if (mJvsDriver == JvsDriver.MV360)
			{
				mMarkPreviewRatio = 1.30909085f;
			}
			else
			{
				mMarkPreviewRatio = 1f;
			}
			purple_jvs_register(base.Handle, 1281);
		}

		private void init_visual_light()
		{
			bool[] array = (mHighCamLedState = new bool[2]);
			bool[] array2 = (mFastCamLedState = new bool[2]);
		}

		private void flush_visual_light(int fn)
		{
			if (mConDev == null || mConDev[fn] == null)
			{
				return;
			}
			if (USR2[fn] == null)
			{
				for (int i = 0; i < HW.mFastLedNum; i++)
				{
					mConDev[fn].sendLevelLED(HW.mFastLedCodeNo[i], USR[fn].mFastCamLightLevel[i]);
				}
				if (mConDev[fn] != null)
				{
					mConDev[fn].sendHSLEDSW(sw: false);
				}
			}
			else
			{
				for (int j = 0; j < HW.mFastLedNum; j++)
				{
					mConDev[fn].sendLevelLED(HW.mFastLedCodeNo[j], USR2[fn].mFastCamLightLevel[0][j]);
				}
				if (mConDev[fn] != null)
				{
					mConDev[fn].sendHSLEDSW(sw: false);
				}
			}
			fhcam_led_on_ext(fn, CameraType.Fast, flag: false);
			fhcam_led_on_ext(fn, CameraType.High, flag: false);
			mark_light_on_ext(fn, USR[fn].mIsMarkLightOn);
			mark_led_on_ext(fn, USR[fn].mIsMarkLedOn);
		}

		public static void fhcam_led_on(int fn, CameraType camtype, bool flag)
		{
			switch (camtype)
			{
			case CameraType.Fast:
				mConDev[fn].sendHSLEDSW(flag);
				mFastCamLedState[fn] = flag;
				break;
			case CameraType.High:
				mConDev[fn].sendLevelLED(HW.mHighLedCodeNo[0], flag ? ((USR2[fn] == null) ? USR[fn].mHighCamLightLevel : USR2[fn].mHighCamLightLevel[0]) : 0);
				mHighCamLedState[fn] = flag;
				break;
			}
		}

		public static void fhcam_led_on_ext(int fn, CameraType camtype, bool flag)
		{
			fhcam_led_on(fn, camtype, flag);
			if (uc_usroperarion != null && !uc_usroperarion[fn].IsDisposed)
			{
				uc_usroperarion[fn].update_led_button_state(camtype);
			}
		}

		public static void mark_light_on(int fn, bool flag)
		{
			mConDev[fn].sendSwitchMarkLEDiLL(flag ? 1 : 0);
			USR[fn].mIsMarkLightOn = flag;
		}

		public static void mark_light_on_ext(int fn, bool flag)
		{
			mark_light_on(fn, flag);
			if (uc_usroperarion[fn] != null && !uc_usroperarion[fn].IsDisposed)
			{
				uc_usroperarion[fn].update_light_button_state();
			}
		}

		public static void mark_led_on(int fn, bool flag)
		{
			mConDev[fn].sendSwitchMarkLED(flag ? 1 : 0);
			USR[fn].mIsMarkLedOn = flag;
		}

		public static void mark_led_on_ext(int fn, bool flag)
		{
			mark_led_on(fn, flag);
			if (uc_usroperarion[fn] != null && !uc_usroperarion[fn].IsDisposed)
			{
				uc_usroperarion[fn].update_led_button_state(CameraType.Mark);
			}
		}

		public static void mark_lightlevel_set(int fn, int[] levels)
		{
			for (int i = 0; i < HW.mMarkLedNum; i++)
			{
				mConDev[fn].sendLevelLED(HW.mMarkLedCodeNo[i], levels[i]);
			}
		}

		public static void mark_lightlevel_set(int fn, int index, int level)
		{
			mConDev[fn].sendLevelLED(HW.mMarkLedCodeNo[index], level);
		}

		public static void mark_lightlevel_set(int fn)
		{
			for (int i = 0; i < HW.mMarkLedNum; i++)
			{
				mConDev[fn].sendLevelLED(HW.mMarkLedCodeNo[i], USR[fn].mMarkCamPara[USR[fn].mMarkCamParaIndex].mParaLed[i]);
			}
		}

		public static void fcam_lightlevel_set(int fn, int index, int level)
		{
			mConDev[fn].sendLevelLED(HW.mFastLedCodeNo[index], level);
		}

		public static void hcam_lightlevel_set(int fn, int level)
		{
			mConDev[fn].sendLevelLED(HW.mHighLedCodeNo[0], level);
		}

		private bool fastCam_autoVisualFindCenter(int fn)
		{
			_ = mJvs_usrWidth;
			_ = mJvs_usrHeight;
			List<Coordinate> list = new List<Coordinate>();
			thd_AnAlltoZero(fn);
			int zn2;
			for (zn2 = 0; zn2 < HW.mZnNum[fn]; zn2++)
			{
				if (!USR[fn].misfcam_disable[zn2])
				{
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					radiobt_zn[fn][zn2].Invoke((MethodInvoker)delegate
					{
						radiobt_zn[fn][zn2].Checked = true;
					});
					msdelay(200);
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					if (HW.mSmtGenerationNo == 2)
					{
						moveToZ_andWait(fn, zn2, USR[fn].mZSpeed, USR[fn].mBaseHeight_camera[zn2]);
					}
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					Coordinate coordinate = auto_findcenter(fn, zn2);
					if (coordinate == null)
					{
						return false;
					}
					list.Add(coordinate);
					if (!fastCam_calcPixRatio(fn, coordinate))
					{
						return false;
					}
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					moveToXY_andWait(fn, USR[fn].mXYSpeed, coordinate);
				}
			}
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			if (list.Count == 0)
			{
				return false;
			}
			Coordinate coordinate2 = new Coordinate(0L, 0L);
			for (int i = 0; i < list.Count; i++)
			{
				coordinate2.X += list[i].X;
				coordinate2.Y += list[i].Y;
			}
			coordinate2.X = (coordinate2.X * 10 / list.Count + 5) / 10;
			coordinate2.Y = (coordinate2.Y * 10 / list.Count + 5) / 10;
			USR[fn].mFastCamRecognizeCoord[0] = coordinate2;
			moveToXY_andWait(fn, USR[fn].mXYSpeed, USR[fn].mFastCamRecognizeCoord[0]);
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			thd_AnAlltoZero(fn);
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			int zn;
			for (zn = 0; zn < HW.mZnNum[fn]; zn++)
			{
				if (!USR[fn].misfcam_disable[zn])
				{
					radiobt_zn[fn][zn].Invoke((MethodInvoker)delegate
					{
						radiobt_zn[fn][zn].Checked = true;
					});
					msdelay(200);
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					if (HW.mSmtGenerationNo == 2)
					{
						moveToZ_andWait(fn, zn, USR[fn].mZSpeed, USR[fn].mBaseHeight_camera[zn]);
					}
					if ((mRunDoing[fn] & 2u) != 0)
					{
						return false;
					}
					Coordinate coordinate3 = auto_findcenter_post(fn, zn);
					if (coordinate3 == null)
					{
						return false;
					}
					USR[fn].mFastCamCenterPosition[0][zn] = coordinate3;
					AdjustScanCenterInImage(fn, zn);
				}
			}
			radiobt_zn[fn][0].Invoke((MethodInvoker)delegate
			{
				radiobt_zn[fn][0].Checked = true;
			});
			thd_ZnAnAlltoZero(fn);
			CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Found all visual centers!" : "已找到所有吸嘴视觉中心坐标！");
			return true;
		}

		private bool highCam_AutoFindPreciseCenter(int fn)
		{
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			thd_AnAlltoZero(fn);
			List<Coordinate> list = new List<Coordinate>();
			int zn;
			for (zn = 0; zn < HW.mZnNum[fn]; zn++)
			{
				radiobt_zn[fn][zn].Invoke((MethodInvoker)delegate
				{
					radiobt_zn[fn][zn].Checked = true;
				});
				msdelay(200);
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				if (HW.mSmtGenerationNo == 2)
				{
					moveToZ_andWait(fn, zn, USR[fn].mZSpeed, USR[fn].mBaseHeight_Hcam[zn]);
				}
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				Coordinate coordinate = auto_findcenter(fn, zn);
				if (coordinate == null)
				{
					return false;
				}
				list.Add(coordinate);
				USR[fn].mHighCamRecognizeCoord[0][zn] = coordinate;
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
				moveToXY_andWait(fn, USR[fn].mXYSpeed, new Coordinate(mCur[fn].x - 2500, mCur[fn].y));
				if ((mRunDoing[fn] & 2u) != 0)
				{
					return false;
				}
			}
			moveToXY_andWait(fn, USR[fn].mXYSpeed, new Coordinate(list[0].X, list[0].Y));
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			Invoke((MethodInvoker)delegate
			{
				radiobt_zn[fn][0].Checked = true;
			});
			msdelay(200);
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			if (HW.mSmtGenerationNo == 2)
			{
				moveToZ_andWait(fn, mZn[fn], USR[fn].mZSpeed, USR[fn].mBaseHeight_Hcam[mZn[fn]]);
			}
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			highCam_calcPixRatio(fn, new Coordinate(list[0].X, list[0].Y));
			thd_ZnAnAlltoZero(fn);
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Found all visual centers!" : "已找到所有吸嘴精准视觉中心坐标！");
			return true;
		}

		private bool highCam_AutoFindSinglePreciseCenter(int fn)
		{
			thd_AnAlltoZero(fn);
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			if (HW.mSmtGenerationNo == 2)
			{
				moveToZ_andWait(fn, mZn[fn], USR[fn].mZSpeed, USR[fn].mBaseHeight_Hcam[mZn[fn]]);
			}
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			Coordinate coordinate = auto_findcenter(fn, mZn[fn]);
			if (coordinate == null)
			{
				thd_ZnAnAlltoZero(fn);
				return false;
			}
			USR[fn].mHighCamRecognizeCoord[0][mZn[fn]] = coordinate;
			if ((mRunDoing[fn] & 2u) != 0)
			{
				return false;
			}
			bool flag = highCam_calcPixRatio(fn, coordinate);
			thd_ZnAnAlltoZero(fn);
			if (!flag)
			{
				return flag;
			}
			CmMessageBoxTop_Ok(STR.NOZZLE_a[USR_INIT.mLanguage] + (mZn[fn] + 1) + ((USR_INIT.mLanguage == 2) ? " precise visual center has been detected!" : "精准视觉中心坐标已经找到！"));
			return true;
		}

		public static void update_NozzleInstallTable(int fn, string[] mNozzles)
		{
			USR3B[fn].mNozzleInstallList2.Clear();
			for (int i = 0; i < HW.mZnNum[fn]; i++)
			{
				SmtNozzleInstallElement2 smtNozzleInstallElement = new SmtNozzleInstallElement2();
				smtNozzleInstallElement.Nozzle_name = STR.NOZZLE_a[USR_INIT.mLanguage] + (i + 1);
				smtNozzleInstallElement.Nozzle_type = mNozzles[i];
				USR3B[fn].mNozzleInstallList2.Add(smtNozzleInstallElement);
			}
		}

		public static void update_NozzleFeederInstallTable_Post(int fn)
		{
			if (USR3B[fn] == null || USR3B[fn].mNozzleInstallList2 == null)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < U3[fn].Count; i++)
			{
				if (U3[fn][i].mPointlistSmt != null && U3[fn][i].mPointlistSmt.Count > 0)
				{
					num += U3[fn][i].mPointlistSmt.Count;
				}
			}
			if (num >= HW.mZnNum[fn] * 3)
			{
				return;
			}
			bool[] array = new bool[HW.mZnNum[fn]];
			for (int j = 0; j < HW.mZnNum[fn]; j++)
			{
				array[j] = false;
			}
			for (int k = 0; k < U3[fn].Count; k++)
			{
				if (U3[fn][k].mPointlistSmt == null || U3[fn][k].mPointlistSmt.Count <= 0)
				{
					continue;
				}
				for (int l = 0; l < U3[fn][k].mPointlistSmt.Count; l++)
				{
					int num2 = U3[fn][k].mPointlistSmt[l].Nozzle - 1;
					if (num2 < 0 && num2 > HW.mZnNum[fn])
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Invalid SMT DATA!" : "贴装数据非法！");
						return;
					}
					array[num2] = true;
				}
			}
			for (int m = 0; m < HW.mZnNum[fn]; m++)
			{
				if (!array[m])
				{
					USR3B[fn].mNozzleInstallList2[m].Nozzle_type = "--";
				}
			}
		}

		public static void pcbsmt_update_Groups(USR3_DATA usr3)
		{
			if (usr3.mPointlistSmtGroup == null)
			{
				usr3.mPointlistSmtGroup = new BindingList<BindingList<ChipBoardElement>>();
			}
			usr3.mPointlistSmtGroup.Clear();
			bool[] array = new bool[usr3.mPointlistSmt.Count];
			for (int i = 0; i < usr3.mPointlistSmt.Count; i++)
			{
				array[i] = false;
			}
			for (int j = 0; j < usr3.mPointlistSmt.Count; j++)
			{
				if (usr3.mPointlistSmt[j].Group > 0)
				{
					if (!array[usr3.mPointlistSmt[j].Group - 1])
					{
						BindingList<ChipBoardElement> item = new BindingList<ChipBoardElement>();
						usr3.mPointlistSmtGroup.Add(item);
						array[usr3.mPointlistSmt[j].Group - 1] = true;
					}
					if (array[usr3.mPointlistSmt[j].Group - 1])
					{
						usr3.mPointlistSmtGroup[usr3.mPointlistSmt[j].Group - 1].Add(usr3.mPointlistSmt[j]);
					}
				}
			}
			for (int k = 0; k < usr3.mPointlistSmtGroup.Count; k++)
			{
				if (usr3.mPointlistSmtGroup[k].Count > HW.mZnNum[mFn])
				{
					CmMessageBox((USR_INIT.mLanguage == 2) ? "Invalid!" : "无效！", MessageBoxButtons.OK);
					break;
				}
			}
		}

		public static void update_usr2_stacks_used_nozzles(int fn)
		{
			if (USR2 == null || USR2[fn] == null || USR2[fn].mStackLib == null || USR2[fn].mStackLib.stacktab == null || USR2[fn].mStackLib.index == null)
			{
				return;
			}
			for (int i = 0; i < 160; i++)
			{
				for (int j = 0; j < HW.mZnNum[fn]; j++)
				{
					USR2[fn].mStackLib.stacktab[0][i].mZnData[j].mEnabled = false;
				}
			}
			for (int k = 0; k < 80; k++)
			{
				for (int l = 0; l < HW.mZnNum[fn]; l++)
				{
					USR2[fn].mStackLib.stacktab[2][k].mZnData[l].mEnabled = false;
				}
			}
			for (int m = 0; m < 80; m++)
			{
				for (int n = 0; n < HW.mZnNum[fn]; n++)
				{
					USR2[fn].mStackLib.stacktab[1][m].mZnData[n].mEnabled = false;
				}
			}
			if (U3[fn][U3Idx[fn]] == null || U3[fn][U3Idx[fn]].mPointlistSmt == null)
			{
				return;
			}
			for (int num = 0; num < U3[fn][U3Idx[fn]].mPointlistSmt.Count; num++)
			{
				int num2 = U3[fn][U3Idx[fn]].mPointlistSmt[num].Stack_no - 1;
				int num3 = U3[fn][U3Idx[fn]].mPointlistSmt[num].Nozzle - 1;
				if (num2 < 0 || num3 < 0)
				{
					return;
				}
				if (U3[fn][U3Idx[fn]].mPointlistSmt[num].Stacktype == ProviderType.Feedr)
				{
					USR2[fn].mStackLib.stacktab[0][num2].mZnData[num3].mEnabled = true;
				}
				else if (U3[fn][U3Idx[fn]].mPointlistSmt[num].Stacktype == ProviderType.Vibra)
				{
					USR2[fn].mStackLib.stacktab[2][num2].mZnData[num3].mEnabled = true;
				}
				else if (U3[fn][U3Idx[fn]].mPointlistSmt[num].Stacktype == ProviderType.Plate)
				{
					USR2[fn].mStackLib.stacktab[1][num2].mZnData[num3].mEnabled = true;
				}
			}
			save_usrProjectData();
		}

		public static void update_usr2_stacks_used_show(int fn)
		{
			if (USR2 == null || USR2[fn] == null || USR2[fn].mStackLib == null || USR2[fn].mStackLib.stacktab == null || USR2[fn].mStackLib.index == null)
			{
				return;
			}
			StackElement[][] array = new StackElement[3][]
			{
				USR2[fn].mStackLib.stacktab[0],
				USR2[fn].mStackLib.stacktab[1],
				USR2[fn].mStackLib.stacktab[2]
			};
			int[] array2 = HW.mStackNum[mFn];
			if (USR3B[fn].mFeederInstallList == null)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < array2[i]; j++)
				{
					array[i][j].mSelected = false;
				}
				for (int k = 0; k < array2[i]; k++)
				{
					int l;
					for (l = 0; l < USR3B[fn].mFeederInstallList.Count && (USR3B[fn].mFeederInstallList[l].Stacktype != (ProviderType)i || k != USR3B[fn].mFeederInstallList[l].Stack_no - 1); l++)
					{
					}
					array[i][k].mSelected = ((l != USR3B[fn].mFeederInstallList.Count) ? true : false);
					if (array[i][k].mSelected)
					{
						array[i][k].mChipValue = USR3B[fn].mFeederInstallList[l].Material_value;
						array[i][k].mChipFootprint = USR3B[fn].mFeederInstallList[l].Footprint;
					}
					else
					{
						array[i][k].mChipValue = "";
						array[i][k].mChipFootprint = "";
					}
				}
			}
			save_usrProjectData();
		}

		public void init_misc()
		{
			mIsFeederReady = new bool[HW.mFnNum][][];
			mIsVacuumOn = new bool[HW.mFnNum][];
			mIsFeederOn = new bool[HW.mFnNum][];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mIsFeederReady[i] = new bool[3][];
				for (int j = 0; j < 3; j++)
				{
					mIsFeederReady[i][j] = new bool[160];
					for (int k = 0; k < 160; k++)
					{
						mIsFeederReady[i][j][k] = true;
					}
				}
				mIsVacuumOn[i] = new bool[HW.mZnNum[i]];
				for (int l = 0; l < HW.mZnNum[i]; l++)
				{
					mIsVacuumOn[i][l] = false;
				}
				mIsFeederOn[i] = new bool[256];
				for (int m = 0; m < 256; m++)
				{
					mIsFeederOn[i][m] = false;
				}
			}
		}

		public static void misc_vacc_onoff(int fn, int zn, int flag)
		{
			if (mIsSimulation)
			{
				mIsVacuumOn[fn][zn] = ((flag != 0) ? true : false);
				return;
			}
			QnConnectionClass qnConnectionClass = mConDev[fn];
			int num = zn;
			if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
			{
				qnConnectionClass = ((zn / 4 == 1) ? mConDev2[0] : mConDev[0]);
				num = zn % 4;
			}
			if (flag == 0 && HW.mSmtGenerationNo == 2)
			{
				qnConnectionClass.sendBreakVacuum(num, USR[fn].mVaccBreakDelay[zn]);
			}
			else
			{
				qnConnectionClass.sendSwitchvacuum(num, flag);
			}
			mIsVacuumOn[fn][zn] = ((flag != 0) ? true : false);
		}

		public static void misc_feeder_onoff(int fn, ProviderType stacktype, int stackno, bool flag)
		{
			if (flag)
			{
				if (stacktype == ProviderType.Feedr || stacktype == ProviderType.Vibra)
				{
					while (!mIsFeederReady[fn][(int)stacktype][stackno])
					{
						Thread.Sleep(1);
					}
					if (stacktype == ProviderType.Feedr)
					{
						mConDev[fn].sendSwitchfeeder(stackno, 1);
					}
				}
			}
			else if (stacktype == ProviderType.Feedr || stacktype == ProviderType.Vibra)
			{
				if (stacktype == ProviderType.Feedr)
				{
					mConDev[fn].sendSwitchfeeder(stackno, 0);
				}
				mIsFeederReady[fn][(int)stacktype][stackno] = false;
				Thread thread = new Thread(thd_feeder_wakeup_time);
				thread.IsBackground = true;
				thread.Start(new int_3d(fn, (int)stacktype, stackno));
			}
		}

		public static void thd_feeder_wakeup_time(object o)
		{
			int a = ((int_3d)o).a;
			int b = ((int_3d)o).b;
			int c = ((int_3d)o).c;
			int num = 0;
			if (USR2 != null && USR2[a] != null)
			{
				switch (b)
				{
				case 0:
					num = USR2[a].mStackLib.stacktab[0][c].mFeederDelay;
					break;
				case 2:
					num = USR2[a].mStackLib.stacktab[2][c].mFeederDelay;
					break;
				}
			}
			if (num > 0)
			{
				Thread.Sleep(num);
			}
			mIsFeederReady[a][b][c] = true;
		}

		public void vsplus_test_previewoffset(int fn)
		{
			Thread thread = new Thread(thd_test_mark_capture);
			thread.IsBackground = true;
			thread.Start(fn);
		}

		private void thd_test_mark_capture(object o)
		{
			int num = (int)o;
			startMarkStill_andWait(num);
			Form_MarkTest form_MarkTest = new Form_MarkTest(mJVSBitmap[HW.mMarkCamItem[num].index[0]]);
			if (mJvsDriver == JvsDriver.MV360)
			{
				form_MarkTest.Size = new Size(1102, 620);
			}
			else
			{
				form_MarkTest.Size = new Size(780, 620);
			}
			form_MarkTest.ShowDialog();
		}

		public void vsplus_start_fcam_auto_calibration(int fn)
		{
			Thread thread = new Thread(thd_visual_fastcam_auto_find_center);
			thread.Start(fn);
		}

		private void thd_visual_fastcam_auto_find_center(object o)
		{
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			int fn = (int)o;
			uc_devicecalibration[fn].set_pausestop_visable("cam", flag: true);
			int zn = 0;
			while (true)
			{
				if (zn < HW.mZnNum[fn])
				{
					if (!USR[fn].misfcam_disable[zn])
					{
						radiobt_zn[fn][zn].Invoke((MethodInvoker)delegate
						{
							radiobt_zn[fn][zn].Checked = true;
						});
						msdelay(200);
						if (HW.mSmtGenerationNo == 2)
						{
							if ((mRunDoing[fn] & 2u) != 0)
							{
								break;
							}
							moveToZ_andWait(fn, zn, USR[fn].mZSpeed, USR[fn].mBaseHeight_camera[zn]);
						}
						visual_result.is_test = true;
						if (ImageVisual(fn, VISUAL_MODE.AUTODETECT, CameraType.Fast, VisualType.Circle, USR[fn].mfcam_scanr, USR[fn].mfcam_threshold, zn, 0, 0, 0f, ref visual_result) != 0)
						{
							CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? ("Cannot find Noz" + (zn + 1)) : ("未发现" + (zn + 1) + "号吸嘴，请调整相关参数（比如灯光强度、将吸嘴靠近灯源中心、将吸嘴更换为实心吸嘴）"));
							break;
						}
						if (visual_result.box_width > (float)USR[fn].mfcam_rec_size || visual_result.box_height > (float)USR[fn].mfcam_rec_size)
						{
							CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? ("Noz" + (zn + 1) + "is too large!") : ("吸嘴" + (zn + 1) + "识别尺寸超出合理范围，请调整相关参数"));
							break;
						}
					}
					zn++;
					continue;
				}
				if (fastCam_autoVisualFindCenter(fn))
				{
					save_FixedData();
				}
				break;
			}
			mRunDoing[fn] = 0;
			radiobt_zn[fn][0].Invoke((MethodInvoker)delegate
			{
				radiobt_zn[fn][0].Checked = true;
			});
			thd_ZnAnAlltoZero(fn);
			uc_devicecalibration[fn].set_pausestop_visable("cam", flag: false);
		}

		public void vsplus_start_hcam_auto_calibration(int fn)
		{
			Thread thread = new Thread(thd_visual_highcam_auto_find_center);
			thread.Start(fn);
		}

		private void thd_visual_highcam_auto_find_center(object o)
		{
			int num = (int)o;
			uc_devicecalibration[num].set_pausestop_visable("cam", flag: true);
			mIsHCamCalibration = true;
			if (HW.mSmtGenerationNo == 2)
			{
				moveToZ_andWait(num, mZn[num], USR[num].mZSpeed, USR[num].mBaseHeight_Hcam[mZn[num]]);
				if ((mRunDoing[num] & 2u) != 0)
				{
					goto IL_016c;
				}
			}
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			visual_result.is_test = true;
			if (ImageVisual(num, VISUAL_MODE.AUTODETECT, CameraType.High, VisualType.NoAngle, USR[num].mhcam_scanr, USR[num].mhcam_threshold, mZn[num], 0, 0, 0f, ref visual_result) != 0)
			{
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot find Noz1" : "未发现识别的吸嘴1，请调整相关参数（比如灯光强度、将吸嘴靠近灯源中心、将吸嘴更换为实心吸嘴）");
			}
			else if (visual_result.box_width > (float)USR[num].mhcam_rec_size || visual_result.box_height > (float)USR[num].mhcam_rec_size)
			{
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? ("Noz" + (mZn[num] + 1) + "is too large!") : ("吸嘴" + (mZn[num] + 1) + "识别尺寸超出合理范围，请调整相关参数"));
				mIsHCamCalibration = false;
			}
			else if (highCam_AutoFindPreciseCenter(num))
			{
				save_FixedData();
			}
			goto IL_016c;
			IL_016c:
			mIsHCamCalibration = false;
			uc_devicecalibration[num].set_pausestop_visable("cam", flag: false);
		}

		public void vsplus_start_hcam_singel_calibration(int fn)
		{
			Thread thread = new Thread(thd_visual_highcam_single_find_center);
			thread.Start(fn);
		}

		private void thd_visual_highcam_single_find_center(object o)
		{
			int num = (int)o;
			mIsHCamCalibration = true;
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			uc_devicecalibration[num].set_pausestop_visable("cam", flag: true);
			if (HW.mSmtGenerationNo == 2)
			{
				moveToZ_andWait(num, mZn[num], USR[num].mZSpeed, USR[num].mBaseHeight_Hcam[mZn[num]]);
			}
			visual_result.is_test = true;
			if (ImageVisual(num, VISUAL_MODE.AUTODETECT, CameraType.High, VisualType.NoAngle, USR[num].mhcam_scanr, USR[num].mhcam_threshold, mZn[num], 0, 0, 0f, ref visual_result) != 0)
			{
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot find Nozzles" : "未发现识别的吸嘴，请调整相关参数（比如灯光强度、将吸嘴靠近灯源中心、将吸嘴更换为实心吸嘴）");
				mIsHCamCalibration = false;
			}
			else if (visual_result.box_width > (float)USR[num].mhcam_rec_size || visual_result.box_height > (float)USR[num].mhcam_rec_size)
			{
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? ("Noz" + (mZn[num] + 1) + "is too large!") : ("吸嘴" + (mZn[num] + 1) + "识别尺寸超出合理范围，请调整相关参数"));
				mIsHCamCalibration = false;
			}
			else if (highCam_AutoFindSinglePreciseCenter(num))
			{
				save_FixedData();
			}
			mIsHCamCalibration = false;
			uc_devicecalibration[num].set_pausestop_visable("cam", flag: false);
		}

		private void uninitAHD()
		{
			int fn;
			for (fn = 0; fn < HW.mFnNum; fn++)
			{
				closeAHDPreview(fn);
				PicBox_Preview2[fn].Invoke((MethodInvoker)delegate
				{
					PicBox_Preview2[fn].Refresh();
				});
			}
		}

		public void ahd_flush_preview(int fn)
		{
			PicBox_Preview2[fn].Invoke((MethodInvoker)delegate
			{
				int num = 978;
				int num2 = 550;
				PicBox_Preview2[fn].Visible = true;
				PicBox_Preview2[fn].Size = new Size(num * ((!mIsPreviewZoom) ? 1 : 2), num2 * ((!mIsPreviewZoom) ? 1 : 2));
				PicBox_Preview2[fn].Location = new Point(-(PicBox_Preview2[fn].Size.Width - 550) / 2 - USR[mFn].mPreviewOffset_X * ((!mIsPreviewZoom) ? 1 : 2), -(PicBox_Preview2[fn].Size.Height - 550) / 2 - USR[mFn].mPreviewOffset_Y * ((!mIsPreviewZoom) ? 1 : 2));
				mRect = default(RECT);
				mRect.bottom = PicBox_Preview2[fn].Bottom;
				mRect.left = PicBox_Preview2[fn].Left;
				mRect.top = PicBox_Preview2[fn].Top;
				mRect.right = PicBox_Preview2[fn].Right;
				ref IntPtr reference = ref mRectHandle[fn];
				reference = PicBox_Preview2[fn].Handle;
			});
		}

		private unsafe bool initAHD()
		{
			int fn;
			for (fn = 0; fn < HW.mFnNum; fn++)
			{
				PicBox_Preview2[fn].Invoke((MethodInvoker)delegate
				{
					PicBox_Preview2[fn].Visible = true;
					PicBox_Preview2[fn].Size = new Size(978, 550);
					PicBox_Preview2[fn].Location = new Point(-(PicBox_Preview2[fn].Size.Width - 550) / 2 - USR[mFn].mPreviewOffset_X, -USR[mFn].mPreviewOffset_Y);
					mRect = default(RECT);
					mRect.bottom = PicBox_Preview2[fn].Bottom;
					mRect.left = PicBox_Preview2[fn].Left;
					mRect.top = PicBox_Preview2[fn].Top;
					mRect.right = PicBox_Preview2[fn].Right;
					ref IntPtr reference2 = ref mRectHandle[fn];
					reference2 = PicBox_Preview2[fn].Handle;
				});
			}
			if (mIsSimulation)
			{
				mJvs_Channels = HW.mCamATotalNum;
				return true;
			}
			AnologHD.InitDSPs();
			AnologHD.ConfigSubChannelSplit(16, 2);
			mJvs_Channels = AnologHD.GetTotalChannels();
			if (mJvs_Channels >= HW.mCamATotalNum)
			{
				mJvs_Hd = new IntPtr[mJvs_Channels];
				for (int i = 0; i < mJvs_Channels; i++)
				{
					ref IntPtr reference = ref mJvs_Hd[i];
					reference = AnologHD.ChannelOpen(i);
				}
				RECT rect = default(RECT);
				for (int j = 0; j < mJvs_Channels; j++)
				{
					if (mJvs_Hd[j] != (IntPtr)(-1))
					{
						rect.bottom = 0;
						rect.left = 0;
						rect.top = 0;
						rect.right = 0;
						AnologHD.StartVideoPreview(mJvs_Hd[j], (IntPtr)(void*)null, ref rect, bOverlay: false, 0, 0);
					}
				}
				m_system_version = AnologHD.GetHardWare_Version(mJvs_Hd[0]);
				for (int k = 0; k < mJvs_Channels; k++)
				{
					if (mJvs_Hd[k] != (IntPtr)(-1))
					{
						ahd_set_parameter(k);
					}
				}
				for (int l = 0; l < mJvs_Channels; l++)
				{
					if (mJvs_Hd[l] != (IntPtr)(-1))
					{
						AnologHD.StartDsp(mJvs_Hd[l]);
						AnologHD.Set_Main_Enable(mJvs_Hd[l], 0);
					}
				}
				for (int m = 0; m < mJvs_Channels; m++)
				{
					if (mJvs_Hd[m] != (IntPtr)(-1))
					{
						AnologHD.StartDMA(mJvs_Hd[m]);
					}
				}
				int num = HW.mMarkCamItem[mFn].index[0];
				if (mJvs_Hd[num] != (IntPtr)(-1))
				{
					openAHDPreview(num);
				}
				for (int n = 0; n < HW.mFnNum; n++)
				{
					set_camera_parameter(HW.mMarkCamItem[n].index[0], USR[n].mMarkCamPara[USR[n].mMarkCamParaIndex].mParaCam);
					for (int num2 = 0; num2 < HW.mZnNum[n]; num2++)
					{
						set_camera_parameter(HW.mFastCamItem[n].index[num2], USR[n].mfcam_para[num2]);
					}
				}
				init_ahd_callback();
				return true;
			}
			return false;
		}

		public bool openAHDPreview(int nChannel)
		{
			if (((mJVS_OpenedPreviewMask >> nChannel) & 1) == 1)
			{
				return true;
			}
			int num = HW.mMFCamChnFn[nChannel];
			closeAHDPreview(num);
			if (!mIsSimulation)
			{
				if (mJvs_Hd == null)
				{
					return true;
				}
				PicBox_Preview2[num].Visible = true;
				_ = mJvs_rawWidth * 550 / 720 / 2;
				_ = mJvs_rawHeight * 550 / 720 / 2;
				if (nChannel != HW.mMarkCamItem[num].index[0])
				{
					_ = USR[num].mFastCamCenterDeltaX[0][mZn[num]];
				}
				AnologHD.StartVideoPreview(mJvs_Hd[nChannel], mRectHandle[num], ref mRect, bOverlay: false, 0, 0);
			}
			mJVS_OpenedPreviewMask |= 1 << nChannel;
			return true;
		}

		public static bool closeAHDPreview(int fn)
		{
			int num = 0;
			while (mJVS_OpenedPreviewMask != 0)
			{
				if (!mIsSimulation && (mJVS_OpenedPreviewMask & 1) == 1)
				{
					if (mJvs_Hd == null)
					{
						return true;
					}
					AnologHD.StopVideoPreview(mJvs_Hd[num]);
				}
				mJVS_OpenedPreviewMask >>= 1;
				num++;
			}
			PicBox_Preview2[fn].Invoke((MethodInvoker)delegate
			{
				PicBox_Preview2[fn].Visible = false;
			});
			return true;
		}

		public static bool startAHDStill_noWait(CameraType camtype, int fn, int zn)
		{
			int num = 0;
			int num2 = 100;
			bool flag = mDebug_Factory;
			switch (camtype)
			{
			case CameraType.Mark:
				num = HW.mMarkCamItem[fn].index[0];
				if (USR[fn].mMarkCamStillDelay <= 10)
				{
					USR[fn].mMarkCamStillDelay = 100;
				}
				num2 = USR[fn].mMarkCamStillDelay;
				if (flag)
				{
					write_to_logFile(mLogFileName, "startJVSStill_noWait: ch=" + num + " still_delay=" + num2 + Environment.NewLine);
				}
				return ahdstill_nowait(num, num2);
			case CameraType.Fast:
				num = HW.mFastCamItem[fn].index[zn];
				num2 = ((USR2[fn] == null) ? USR[fn].mfcam_stilldelay : USR2[fn].mFastCamStillDelay[0]);
				if (flag)
				{
					write_to_logFile(mLogFileName, "startJVSStill_noWait: ch=" + num + " still_delay=" + num2 + Environment.NewLine);
				}
				return ahdstill_nowait(num, num2);
			default:
				return false;
			}
		}

		public static bool ahdstill_nowait(int ch, int still_delay)
		{
			if (mIsSimulation)
			{
				bJVSCameraRecived[ch] = true;
				return true;
			}
			_ = mJvs_rawWidth;
			_ = mJvs_rawHeight;
			bJVSCameraRecived[ch] = false;
			jvsstill_LockBitmap(ch);
			AHD_Capture(ch);
			return true;
		}

		private static void startAHDStill_andWait(CameraType camtype, int fn, int zn)
		{
			int num = 0;
			int num2 = 500;
			switch (camtype)
			{
			case CameraType.Mark:
				num = HW.mMarkCamItem[fn].index[0];
				if (USR[fn].mMarkCamStillDelay <= 10)
				{
					USR[fn].mMarkCamStillDelay = 100;
				}
				num2 = USR[fn].mMarkCamStillDelay;
				ahdstill_andwait(num, num2);
				break;
			case CameraType.Fast:
				num = HW.mFastCamItem[fn].index[zn];
				num2 = ((USR2[fn] == null) ? USR[fn].mfcam_stilldelay : USR2[fn].mFastCamStillDelay[0]);
				ahdstill_andwait(num, num2);
				break;
			}
		}

		public static void ahdstill_andwait(int ch, int still_delay)
		{
			if (mIsSimulation)
			{
				bJVSCameraRecived[ch] = true;
				return;
			}
			bJVSCameraRecived[ch] = false;
			jvsstill_LockBitmap(ch);
			if (still_delay > 0)
			{
				Thread.Sleep(still_delay);
			}
			AHD_Capture(ch);
			while (!bJVSCameraRecived[ch])
			{
				Thread.Sleep(1);
			}
			bJVSCameraRecived[ch] = false;
			jvsstill_UnlockBitmap(ch);
		}

		private static void AHD_Capture(int ch)
		{
			Thread thread = new Thread(thd_ahd_capture);
			thread.IsBackground = true;
			thread.Start(ch);
		}

		private static void thd_ahd_capture(object o)
		{
			int num = (int)o;
			if (mIsSimulation)
			{
				bJVSCameraRecived[num] = true;
				return;
			}
			int num2 = 4;
			ulong Size = (ulong)(mJvs_rawWidth * mJvs_rawHeight * 2 + num2);
			byte[] array = pYuvBuffer[num];
			if (is_ahd_callbackmode)
			{
				is_ahd_start_capture[num] = true;
				num2 = 0;
				while (is_ahd_start_capture[num])
				{
					Thread.Sleep(0);
				}
			}
			else
			{
				write_buffer_aa55(array, (int)Size);
				do
				{
					AnologHD.GetOriginalImage(mJvs_Hd[num], array, ref Size);
				}
				while (check_buffer_aa55(array, (int)Size));
			}
			byte[] array2 = pRgb32Buffer[num];
			moon_yuyv_to_rgb32(array, array2, mJvs_rawWidth, mJvs_rawHeight, num2);
			Marshal.Copy(array2, 0, mJVSBitmap_Data[num].Scan0, mJvs_rawWidth * mJvs_rawHeight * 4);
			bJVSCameraRecived[num] = true;
		}

		private void ahd_set_parameter(int ch)
		{
			AnologHD.Set_DeInterlace_Enable(mJvs_Hd[ch], 1);
			AnologHD.Set_FullSizeRecoder_Enable(mJvs_Hd[ch], 0);
			AnologHD.SetVideoStandard(mJvs_Hd[ch], VideoStandard.StandardPAL);
			AnologHD.SetEncoderPictureFormat(mJvs_Hd[ch], PictureFormat.ENC_4CIF_FORMAT);
			AnologHD.SetVideoPara(mJvs_Hd[ch], 8, 146, 136, 0);
			AnologHD.SetVideoSharp(mJvs_Hd[ch], 4);
		}

		private bool initJVS()
		{
			mJVSPreviewWinRC = new int[4];
			if (mJvs_State && mJvs_Channels > 0)
			{
				int fn2;
				for (fn2 = 0; fn2 < HW.mFnNum; fn2++)
				{
					PicBox_Preview[fn2].Invoke((MethodInvoker)delegate
					{
						mRectSize = default(Size);
						mRectSize.Width = PicBox_Preview[fn2].Size.Width;
						mRectSize.Height = PicBox_Preview[fn2].Size.Height;
						ref IntPtr reference2 = ref mRectHandle[fn2];
						reference2 = PicBox_Preview[fn2].Handle;
						mRectPanelPoint = PointToScreen(new Point(panel_preview[fn2].Location.X + panel_preview[fn2].Parent.Location.X, panel_preview[fn2].Location.Y + panel_preview[fn2].Parent.Location.Y));
					});
				}
				openJVSPreview(HW.mMarkCamItem[0].index[0]);
				return true;
			}
			if (mIsSimulation)
			{
				mJvs_Channels = 16;
			}
			else if (mJvsDriver == JvsDriver.JVS960S)
			{
				mJvs_Channels = CAM.JVS_InitSDK(0);
			}
			else if (mJvsDriver == JvsDriver.JVS900)
			{
				mJvs_Channels = CAM.JVS_InitSDK();
			}
			mJvs_usrWidth = 541;
			mJvs_usrHeight = 541;
			mJvs_usrHeight = 542;
			mJvs_usrWidth = 542;
			int fn;
			for (fn = 0; fn < HW.mFnNum; fn++)
			{
				PicBox_Preview[fn].Invoke((MethodInvoker)delegate
				{
					mRectSize = default(Size);
					mRectSize.Width = PicBox_Preview[fn].Size.Width;
					mRectSize.Height = PicBox_Preview[fn].Size.Height;
					ref IntPtr reference = ref mRectHandle[fn];
					reference = PicBox_Preview[fn].Handle;
					int num2 = panel_preview[fn].Location.X + panel_preview[fn].Parent.Location.X + panel_preview[fn].Parent.Parent.Location.X + panel_preview[fn].Parent.Parent.Parent.Location.X;
					int num3 = panel_preview[fn].Location.Y + panel_preview[fn].Parent.Location.Y + panel_preview[fn].Parent.Parent.Location.Y + panel_preview[fn].Parent.Parent.Parent.Location.Y;
					mRectPanelPoint = PointToScreen(new Point(num2, num3));
				});
			}
			if (mJvs_Channels < 4)
			{
				return false;
			}
			if (!mIsSimulation && CAM.JVS_InitPreview())
			{
				CAM.JVS_RegisterNotify(base.Handle, 1281);
				for (int i = 0; i < mJvs_Channels; i++)
				{
					if (is_channel_enable(i))
					{
						if (mJvsDriver == JvsDriver.JVS900)
						{
							CAM.JVS_SetVideoPixelMode(i, 1, 0);
						}
						if (!CAM.JVS_OpenChannel(i))
						{
							string text = "Fail to open fast camera " + (i + 1) + ", please close software and check CS9600 existing in device manangement";
							string text2 = "普通相机的第" + (i + 1) + "号打开出错（后果-造成无法正常贴装），关闭软件，查看设备管理器中是否有普通视觉相机（CS9600）";
							CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? text : text2);
							return false;
						}
						if (mJvsDriver == JvsDriver.JVS960S)
						{
							CAM.JVS_SetVideoPixelMode(i, 1, 0, 0, 0);
						}
						else if (mJvsDriver == JvsDriver.JVS900)
						{
							CAM.JVS_SetVideoPixelMode(i, 1, 0);
						}
					}
				}
				CAM.JVS_GetBitmapSize(0, out mJvs_rawWidth, out mJvs_rawHeight);
				for (int j = 0; j < mJvs_Channels; j++)
				{
					if (!is_channel_enable(j))
					{
						continue;
					}
					if (!openJVSPreview(j))
					{
						CmMessageBoxTop_Ok("尝试打开预览失败: 通道" + (j + 1));
					}
					int num = 5;
					while (num-- != 0)
					{
						if (mJvsDriver == JvsDriver.JVS900)
						{
							CAM.JVS_SetVideoPixelMode(j, 1, 0);
						}
						Thread.Sleep(1);
					}
					if (mJvsDriver == JvsDriver.JVS900)
					{
						CAM.JVS_SetVideoPixelMode(j, 1, 0);
					}
					Thread.Sleep(1);
					closeJVSPreview(mFn);
				}
				CAM.JVS_RegisterNotify(mMainHandle, 1281);
			}
			for (int k = 0; k < HW.mFnNum; k++)
			{
				for (int l = 0; l < HW.mZnNum[k]; l++)
				{
					set_camera_parameter(HW.mFastCamItem[k].index[l], USR[k].mfcam_para[l]);
				}
				set_camera_parameter(HW.mMarkCamItem[k].index[0], USR[k].mMarkCamPara[USR[k].mMarkCamParaIndex].mParaCam);
			}
			return true;
		}

		private bool is_channel_enable(int ch)
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				if (ch == HW.mMarkCamItem[i].index[0])
				{
					return true;
				}
				for (int j = 0; j < HW.mZnNum[i]; j++)
				{
					if (ch == HW.mFastCamItem[i].index[j])
					{
						return true;
					}
				}
			}
			return false;
		}

		private void uninitJVS()
		{
			for (int i = 0; i < HW.mFnNum; i++)
			{
				closeJVSPreview(i);
			}
		}

		public bool openJVSPreview(int ch)
		{
			int num = 0;
			int num2 = 0;
			int num3 = HW.mMFCamChnFn[ch];
			if (((mJVS_OpenedPreviewMask >> ch) & 1) == 1)
			{
				return true;
			}
			if (mIsSimulation)
			{
				mJVS_OpenedPreviewMask |= 1 << ch;
				return true;
			}
			CAM.JVS_GetBitmapSize(0, out mJvs_rawWidth, out mJvs_rawHeight);
			num = mJvs_rawWidth;
			num2 = mJvs_usrHeight;
			int num4 = ((ch != HW.mMarkCamItem[num3].index[0]) ? USR[num3].mFastCamCenterDeltaX[0][mZn[num3]] : 0);
			mJVSPreviewWinRC[0] = mRectPanelPoint.X + (mRectSize.Width - num * ((!mIsPreviewZoom) ? 1 : 2)) / 2 + (USR[num3].mPreviewOffset_X - num4) * ((!mIsPreviewZoom) ? 1 : 2);
			mJVSPreviewWinRC[1] = mRectPanelPoint.Y + (mRectSize.Height - num2 * ((!mIsPreviewZoom) ? 1 : 2)) / 2 + USR[num3].mPreviewOffset_Y * ((!mIsPreviewZoom) ? 1 : 2);
			mJVSPreviewWinRC[2] = mJVSPreviewWinRC[0] + num * ((!mIsPreviewZoom) ? 1 : 2);
			mJVSPreviewWinRC[3] = mJVSPreviewWinRC[1] + num2 * ((!mIsPreviewZoom) ? 1 : 2);
			if (CAM.JVS_SetVideoPreview(ch, mRectHandle[num3], mJVSPreviewWinRC, bPreview: true))
			{
				mJVS_OpenedPreviewMask |= 1 << ch;
				return true;
			}
			return false;
		}

		public static bool closeJVSPreview(int fn)
		{
			int num = 0;
			while (mJVS_OpenedPreviewMask != 0)
			{
				if ((mJVS_OpenedPreviewMask & 1) == 1 && !mIsSimulation)
				{
					CAM.JVS_CloseVideoPreview(num);
				}
				mJVS_OpenedPreviewMask >>= 1;
				num++;
			}
			return true;
		}

		protected override void DefWndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg == 1281)
			{
				if ((int)m.LParam == 1)
				{
					int num = (int)m.WParam;
					lock (bJVSCameraRecived)
					{
						bJVSCameraRecived[num] = true;
					}
				}
			}
			else
			{
				base.DefWndProc(ref m);
			}
		}

		public static void startJVSStill_andWait(CameraType camtype, int fn, int zn)
		{
			int num = 0;
			int num2 = 75;
			switch (camtype)
			{
			case CameraType.Mark:
				num = HW.mMarkCamItem[fn].index[0];
				if (USR[fn].mMarkCamStillDelay <= 10)
				{
					USR[fn].mMarkCamStillDelay = 100;
				}
				num2 = USR[fn].mMarkCamStillDelay;
				jvsstill_andwait(num, num2);
				break;
			case CameraType.Fast:
				num = HW.mFastCamItem[fn].index[zn];
				num2 = ((USR2[fn] == null) ? USR[fn].mfcam_stilldelay : USR2[fn].mFastCamStillDelay[0]);
				jvsstill_andwait(num, num2);
				break;
			}
		}

		public static bool startJVSStill_noWait(CameraType camtype, int fn, int zn)
		{
			int num = 0;
			int num2 = 75;
			bool flag = mDebug_Factory;
			switch (camtype)
			{
			case CameraType.Mark:
				num = HW.mMarkCamItem[fn].index[0];
				if (USR[fn].mMarkCamStillDelay <= 10)
				{
					USR[fn].mMarkCamStillDelay = 100;
				}
				num2 = USR[fn].mMarkCamStillDelay;
				if (flag)
				{
					write_to_logFile(mLogFileName, "startJVSStill_noWait: ch=" + num + " still_delay=" + num2 + Environment.NewLine);
				}
				return jvsstill_nowait(num, num2);
			case CameraType.Fast:
				num = HW.mFastCamItem[fn].index[zn];
				num2 = ((USR2[fn] == null) ? USR[fn].mfcam_stilldelay : USR2[fn].mFastCamStillDelay[0]);
				if (flag)
				{
					write_to_logFile(mLogFileName, "startJVSStill_noWait: ch=" + num + " still_delay=" + num2 + Environment.NewLine);
				}
				return jvsstill_nowait(num, num2);
			default:
				return false;
			}
		}

		public static void write_buffer_aa55(byte[] buf, int len)
		{
			buf[len - 1] = 170;
			buf[len - 5] = 85;
		}

		public static bool check_buffer_aa55(byte[] buf, int len)
		{
			if (buf[len - 1] == 170 && buf[len - 5] == 85)
			{
				return true;
			}
			return false;
		}

		public unsafe static void write_buffer_aa55(IntPtr scan0, int len)
		{
			byte* ptr = (byte*)scan0.ToPointer();
			ptr[len - 1] = 170;
			ptr[len - 5] = 85;
		}

		public unsafe static bool check_buffer_aa55(IntPtr scan0, int len)
		{
			byte* ptr = (byte*)scan0.ToPointer();
			if (ptr[len - 1] == 170 && ptr[len - 5] == 85)
			{
				return true;
			}
			return false;
		}

		public static bool checkJVSStill_IsAA55(int ch)
		{
			if (mIsSimulation)
			{
				return false;
			}
			if (mJvsDriver != 0 && mJvsDriver != JvsDriver.JVS960S && mJvsDriver != JvsDriver.JW6008HT)
			{
				return false;
			}
			if (mJVSBitmap_Data[ch] == null)
			{
				mJVSBitmap_Data[ch] = mJVSBitmap[ch].LockBits(new Rectangle(0, 0, mJvs_rawWidth, mJvs_rawHeight), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			}
			return check_buffer_aa55(mJVSBitmap_Data[ch].Scan0, mJvs_rawWidth * mJvs_rawHeight * 4);
		}

		public static void jvsstill_UnlockBitmap(int ch)
		{
			if (!mIsSimulation && mJVSBitmap_Data[ch] != null)
			{
				mJVSBitmap[ch].UnlockBits(mJVSBitmap_Data[ch]);
				mJVSBitmap_Data[ch] = null;
			}
		}

		public static void jvsstill_LockBitmap(int ch)
		{
			if (!mIsSimulation)
			{
				if (mJVSBitmap_Data[ch] != null)
				{
					mJVSBitmap[ch].UnlockBits(mJVSBitmap_Data[ch]);
					mJVSBitmap_Data[ch] = null;
				}
				mJVSBitmap_Data[ch] = mJVSBitmap[ch].LockBits(new Rectangle(0, 0, mJvs_rawWidth, mJvs_rawHeight), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			}
		}

		public static void jvsstill_andwait(int ch, int still_delay)
		{
			if (mIsSimulation)
			{
				msdelay(still_delay);
				purple_jvs_postmessage(1, ch);
				return;
			}
			bJVSCameraRecived[ch] = false;
			jvsstill_LockBitmap(ch);
			write_buffer_aa55(mJVSBitmap_Data[ch].Scan0, mJvs_rawWidth * mJvs_rawHeight * 4);
			bool flag = false;
			do
			{
				if (still_delay > 0)
				{
					Thread.Sleep(still_delay);
				}
				if (!CAM.JVS_GetBitmap(ch, mJVSBitmap_Data[ch].Scan0))
				{
					CmMessageBox("JVS_GetBitmap fail!", MessageBoxButtons.OK);
				}
				while (!bJVSCameraRecived[ch])
				{
					DateTime now = DateTime.Now;
					for (double totalMilliseconds = (DateTime.Now - now).TotalMilliseconds; totalMilliseconds <= 100.0; totalMilliseconds = (DateTime.Now - now).TotalMilliseconds)
					{
					}
				}
				bJVSCameraRecived[ch] = false;
			}
			while (check_buffer_aa55(mJVSBitmap_Data[ch].Scan0, mJvs_rawWidth * mJvs_rawHeight * 4));
			jvsstill_UnlockBitmap(ch);
		}

		public static bool jvsstill_nowait(int ch, int still_delay)
		{
			bool flag = mDebug_Factory;
			if (mIsSimulation)
			{
				purple_jvs_postmessage(1, ch);
				return true;
			}
			int len = mJvs_rawWidth * mJvs_rawHeight * 4;
			bJVSCameraRecived[ch] = false;
			if (flag)
			{
				write_to_logFile(mLogFileName, "   jvsstill_nowait: ch=" + ch + " len=" + len + Environment.NewLine);
			}
			jvsstill_LockBitmap(ch);
			if (flag)
			{
				write_to_logFile(mLogFileName, "   jvsstill_nowait: mJVSBitmap_Data[ch]=" + mJVSBitmap_Data[ch].ToString() + " mJVSBitmap[ch]=" + mJVSBitmap[ch].ToString() + Environment.NewLine);
			}
			write_buffer_aa55(mJVSBitmap_Data[ch].Scan0, len);
			if (!CAM.JVS_GetBitmap(ch, mJVSBitmap_Data[ch].Scan0))
			{
				CmMessageBoxTop_Ok("JVS_GetBitmap fail!");
				return false;
			}
			return true;
		}

		private bool initConnection_gen2()
		{
			sReserved = new byte[mPortName.Count][];
			mMutexResearvedData = new Mutex();
			mCom = new QnConnectionClass[mPortName.Count];
			mComUsingList = new BindingList<QnConnectionClass>();
			mConDev = new QnConnectionClass[HW.mFnNum];
			for (int i = 0; i < HW.mFnNum; i++)
			{
				mConDev[i] = null;
			}
			mConDev2 = new QnConnectionClass[HW.mFnNum];
			for (int j = 0; j < HW.mFnNum; j++)
			{
				mConDev2[j] = null;
			}
			mConDevExt = new QnConnectionClass[HW.mFnNum];
			for (int k = 0; k < HW.mFnNum; k++)
			{
				mConDevExt[k] = null;
			}
			mConDevExtExt = new QnConnectionClass[HW.mFnNum];
			for (int l = 0; l < HW.mFnNum; l++)
			{
				mConDevExtExt[l] = null;
			}
			ResetState[] array = (mResetState2 = new ResetState[2]);
			mComSubCmdTag = new byte[mPortName.Count];
			for (int m = 0; m < mPortName.Count; m++)
			{
				mComSubCmdTag[m] = 0;
			}
			int num = 0;
			if (USR_INIT.mDeviceType == DeviceType.DUDU_400 || USR_INIT.mDeviceType == DeviceType.DUDU_400_50K || USR_INIT.mDeviceType == DeviceType.DUDU_400_64FX || USR_INIT.mDeviceType == DeviceType.DUDU_800 || USR_INIT.mDeviceType == DeviceType.DUDU_800_E || USR_INIT.mDeviceType == DeviceType.DSQ800_120F)
			{
				while (true)
				{
					int num2 = 0;
					for (int n = 0; n < mPortName.Count; n++)
					{
						mCom[n] = new QnConnectionClass(n, mIsSimulation);
						if (mCom[n].Open(mPortName[n], mPortBautRate[n] / 2))
						{
							mCom[n].ClearDataBuffer();
							mCom[n].sendWrong();
							mCom[n].Close();
							mCom[n].DataReceived += mSerialPort_DataReceived;
							mCom[n].ERRORReceived += mSerialPort_ERRORReceived;
							mCom[n].LogMessage += mSerialPort_LogMessage;
							if (!mCom[n].Open(mPortName[n], mPortBautRate[n]))
							{
								continue;
							}
							mCom[n].ClearDataBuffer();
							QnCommon.mComType = 255;
							mCom[n].sendReadVersion();
							DateTime now = DateTime.Now;
							bool flag = false;
							while (true)
							{
								Thread.Sleep(2);
								if (QnCommon.mComType != 255)
								{
									break;
								}
								DateTime now2 = DateTime.Now;
								if ((now2 - now).TotalMilliseconds > 1000.0)
								{
									write_to_logFile(mLogFileName, "E:" + mPortName[n] + Environment.NewLine);
									flag = true;
									break;
								}
							}
							if (flag)
							{
								mCom[n].Close();
								continue;
							}
							write_to_logFile(mLogFileName, QnCommon.mComType.ToString("X") + "：" + QnCommon.sBaseVersion + Environment.NewLine);
							mCom[n].SetComType(QnCommon.mComType);
							mCom[n].SetmFn(0);
							if (QnCommon.mComType == 160)
							{
								static_firmware_version[0] = QnCommon.sBaseVersion + " " + QnCommon.mComType.ToString("X2");
								mComSubCmdTag[n] = 160;
								mConDev[0] = mCom[n];
								num2++;
								mComUsingList.Add(mCom[n]);
							}
							else if (QnCommon.mComType == 161)
							{
								static_firmware_version[1] = QnCommon.sBaseVersion + " " + QnCommon.mComType.ToString("X2");
								mComSubCmdTag[n] = 161;
								mConDevExt[0] = mCom[n];
								num2++;
								mComUsingList.Add(mCom[n]);
							}
							else if (QnCommon.mComType == 162)
							{
								static_firmware_version[2] = QnCommon.sBaseVersion + " " + QnCommon.mComType.ToString("X2");
								mComSubCmdTag[n] = 162;
								mConDev2[0] = mCom[n];
								num2++;
								mComUsingList.Add(mCom[n]);
							}
							else if (QnCommon.mComType == 174)
							{
								static_firmware_version[3] = QnCommon.sBaseVersion + " " + QnCommon.mComType.ToString("X2");
								mComSubCmdTag[n] = 174;
								mConDevExtExt[0] = mCom[n];
								num2++;
								mComUsingList.Add(mCom[n]);
							}
							continue;
						}
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Connect Fail, please check cables1!" : ("贴片机通信失效，关闭软件，检查连接线1--" + n));
						return false;
					}
					if (num2 != HW.mConNum)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Connect Fail, please check power/cables!" : "设备连接失败，请检查电源/连线正确之后重启软件");
						write_to_logFile(mLogFileName, "连接失败:" + num2 + "个有效端口" + Environment.NewLine);
						Environment.Exit(0);
						return false;
					}
					if (mConDevExt[0] != null)
					{
						break;
					}
					if (num <= 2)
					{
						for (int num3 = 0; num3 < mPortName.Count; num3++)
						{
							if (mCom[num3] != null)
							{
								mCom[num3].Close();
							}
						}
						mComUsingList.Clear();
						num++;
						write_to_logFile(mLogFileName, (USR_INIT.mLanguage == 2) ? "Cannot find the Second MainBoard!" : ("未发现副控制板" + Environment.NewLine));
						continue;
					}
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot find the Second MainBoard!" : "未发现副控制板");
					return false;
				}
				if (mConDev[0] == null)
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot find the MainBoard!" : "未发现主控制板");
					return false;
				}
				if ((USR_INIT.mDeviceType == DeviceType.DUDU_800 || USR_INIT.mDeviceType == DeviceType.DUDU_800_E || USR_INIT.mDeviceType == DeviceType.DSQ800_120F) && mConDev2[0] == null)
				{
					CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Cannot find the MainBoard!" : "未发现第二块主控制板");
					return false;
				}
				if (USR_INIT.mDeviceType == DeviceType.DSQ800_120F)
				{
					mConDev[1] = mConDev2[0];
					mConDevExt[1] = mConDevExt[0];
					mConDev[1].SetmFn(1);
					mConDevExt[1].SetmFn(1);
				}
				for (int num4 = 0; num4 < HW.mFnNum; num4++)
				{
					mConDev[num4].sendMaxXYDistance(0);
					DateTime now3 = DateTime.Now;
					for (double totalMilliseconds = (DateTime.Now - now3).TotalMilliseconds; totalMilliseconds <= 300.0; totalMilliseconds = (DateTime.Now - now3).TotalMilliseconds)
					{
					}
					mConDev[num4].sendMaxZDistance(0);
					mCur[num4].x = 0;
					mCur[num4].y = 0;
					for (int num5 = 0; num5 < HW.mZnNum[num4]; num5++)
					{
						mCur[num4].z[num5] = 0;
						mCur[num4].a[num5] = 0;
					}
				}
				if (HW.mDeviceType == DeviceType.DUDU_800 || HW.mDeviceType == DeviceType.DUDU_800_E)
				{
					mConDev2[0].sendMaxZDistance(0);
					mResetState2[0] = ResetState.Unknown;
					mResetState2[1] = ResetState.Unknown;
					mConDev[0].sendReset(1);
					mConDev2[0].sendReset(1);
					while (mResetState2[0] == ResetState.Unknown || mResetState2[1] == ResetState.Unknown)
					{
						Thread.Sleep(1);
					}
					if (mResetState2[0] == ResetState.Fail)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "第一块主板ZA复位失败，请重启机器！");
						Environment.Exit(0);
						return false;
					}
					if (mResetState2[1] == ResetState.Fail)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "第二块主板ZA复位失败，请重启机器！");
						Environment.Exit(0);
						return false;
					}
					mResetState2[0] = ResetState.Unknown;
					mConDev[0].sendReset(2);
					while (mResetState2[0] == ResetState.Unknown)
					{
						Thread.Sleep(1);
					}
					if (mResetState2[0] == ResetState.Fail)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "第一块主板XY复位失败，请重启机器！");
						Environment.Exit(0);
						return false;
					}
					bmIsConnected = true;
					updateConnectButton(bmIsConnected);
					updateCoordinateXY(0, mCur[0].x, mCur[0].y);
					for (int num6 = 0; num6 < HW.mZnNum[0]; num6++)
					{
						updateCoordinateZ(0, num6, mCur[0].z[num6]);
						updateCoordinateA(0, num6, mCur[0].a[num6]);
					}
				}
				else if (HW.mDeviceType == DeviceType.DUDU_400 || HW.mDeviceType == DeviceType.DUDU_400_64FX || HW.mDeviceType == DeviceType.DUDU_400_50K)
				{
					mResetState2[0] = ResetState.Unknown;
					mConDev[0].sendReset(0);
					while (mResetState2[0] == ResetState.Unknown)
					{
						Thread.Sleep(1);
					}
					if (mResetState2[0] == ResetState.Fail)
					{
						CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Reset errors please restart!" : "复位失败，请重启机器！");
						Environment.Exit(0);
						return false;
					}
					bmIsConnected = true;
					updateConnectButton(bmIsConnected);
					updateCoordinateXY(0, mCur[0].x, mCur[0].y);
					for (int num7 = 0; num7 < HW.mZnNum[0]; num7++)
					{
						updateCoordinateZ(0, num7, mCur[0].z[num7]);
						updateCoordinateA(0, num7, mCur[0].a[num7]);
					}
				}
				else if (HW.mDeviceType == DeviceType.DSQ800_120F)
				{
					for (int num8 = 0; num8 < HW.mFnNum; num8++)
					{
						mResetState2[num8] = ResetState.Unknown;
						mConDev[num8].sendReset(1);
					}
					while (true)
					{
						int num9;
						for (num9 = 0; num9 < HW.mFnNum && mResetState2[num9] != 0; num9++)
						{
						}
						if (num9 == HW.mFnNum)
						{
							break;
						}
						Thread.Sleep(1);
					}
					for (int num10 = 0; num10 < HW.mFnNum; num10++)
					{
						if (mResetState2[num10] == ResetState.Fail)
						{
							CmMessageBoxTop_Ok("F" + (num10 + 1) + ((USR_INIT.mLanguage == 2) ? " Reset errors please restart!" : " ZA复位失败，请重启机器！"));
							Environment.Exit(0);
							return false;
						}
					}
					for (int num11 = 0; num11 < HW.mFnNum; num11++)
					{
						mResetState2[num11] = ResetState.Unknown;
						mConDev[num11].sendReset(2);
					}
					while (true)
					{
						int num12;
						for (num12 = 0; num12 < HW.mFnNum && mResetState2[num12] != 0; num12++)
						{
						}
						if (num12 == HW.mFnNum)
						{
							break;
						}
						Thread.Sleep(1);
					}
					for (int num13 = 0; num13 < HW.mFnNum; num13++)
					{
						if (mResetState2[num13] == ResetState.Fail)
						{
							CmMessageBoxTop_Ok("F" + (num13 + 1) + ((USR_INIT.mLanguage == 2) ? " Reset errors please restart!" : " XY复位失败，请重启机器！"));
							Environment.Exit(0);
							return false;
						}
					}
					bmIsConnected = true;
					updateConnectButton(bmIsConnected);
					for (int num14 = 0; num14 < HW.mFnNum; num14++)
					{
						updateCoordinateXY(num14, mCur[num14].x, mCur[num14].y);
						for (int num15 = 0; num15 < HW.mZnNum[num14]; num15++)
						{
							updateCoordinateZ(num14, num15, mCur[num14].z[num15]);
							updateCoordinateA(num14, num15, mCur[num14].a[num15]);
						}
					}
				}
				for (int num16 = 0; num16 < HW.mFnNum; num16++)
				{
					if (HW.mDeviceType == DeviceType.DSQ800_120F)
					{
						mConDev[num16].sendFNOFB(HW.mStackNum[num16][0]);
						msdelay(100);
					}
					else
					{
						mConDev[num16].sendFNOFB(HW.malgo2[num16].slt_l[0] + HW.malgo2[num16].slt_r[0]);
						msdelay(100);
					}
					for (int num17 = 0; num17 < HW.mZnNum[num16]; num17++)
					{
						misc_vacc_onoff(num16, num17, 0);
					}
					for (int num18 = 0; num18 < HW.mStackNum[num16][0]; num18++)
					{
						misc_feeder_onoff(num16, ProviderType.Feedr, num18, flag: false);
						mConDev[num16].sendBuzzerOnOff(0);
					}
				}
				if (HW.mDeviceType != DeviceType.DSQ800_120F)
				{
					mConDevExt[0].send_inboard_reset();
					msdelay(200);
					mConDevExt[0].ClearDataBuffer();
					sReserved[mConDevExt[0].mCno] = null;
					QnCommon.mComType = 255;
					mConDevExt[0].sendReadVersion();
					DateTime now4 = DateTime.Now;
					bool flag2 = false;
					while (QnCommon.mComType == 255)
					{
						DateTime now5 = DateTime.Now;
						if ((now5 - now4).TotalMilliseconds > 1000.0)
						{
							write_to_logFile(mLogFileName, "E:" + mPortName[mConDevExt[0].mCno] + Environment.NewLine);
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						mConDevExt[0].Close();
						write_to_logFile("进板贴板模式设置初始化失败!");
						CmMessageBoxTop_Ok("进板贴板模式设置初始化失败!");
					}
					write_to_logFile("进板贴板模式设置初始化：0x" + QnCommon.mComType.ToString("X2"));
					mConDevExt[0].send_inboard_mode((USR_INIT.mInBoard_Mode == 1) ? 1 : 0);
				}
				for (int num19 = 0; num19 < HW.mFnNum; num19++)
				{
					mConDevExt[num19].sendTrackSpeed(10 - USR[num19].mTrackSpeed);
					mConDevExt[num19].sendTrackDelay((int)(USR[num19].mTrackDelay * 10f));
					mConDevExt[num19].send_trackspeedbase(USR_INIT.mTrackSpeedBase);
					mConDev[num19].readOpenShapeStatus();
					mConDev[num19].readFeederGoodbyeStatus();
					set_warningalarm_idle();
					mark_lightlevel_set(num19);
					mark_light_on_ext(num19, USR[num19].mMarkCamPara[USR[num19].mMarkCamParaIndex].mLightOn);
					mark_led_on_ext(num19, USR[num19].mMarkCamPara[USR[num19].mMarkCamParaIndex].mLedOn);
				}
				if (HW.mDeviceType == DeviceType.DSQ800_120F)
				{
					mConDevExt[0].sendTrackDelay((int)(USR_INIT.mTrack.delayL * 10f), (int)(USR_INIT.mTrack.delayM * 10f), (int)(USR_INIT.mTrack.delayR * 10f));
					mConDevExt[0].sendTrackSpeed(10 - USR_INIT.mTrack.speed);
				}
			}
			return true;
		}

		public static void vsplus_open_campara()
		{
			if (uc_campara != null && !uc_campara.IsDisposed)
			{
				uc_campara.Dispose();
			}
			if (uc_campara == null || uc_campara.IsDisposed)
			{
				uc_campara = new UserControl_CamPara(mFn, USR[mFn], USR2[mFn]);
				uc_usroperarion[mFn].Controls.Add(uc_campara);
				uc_campara.Location = new Point(0, 582);
				uc_campara.Size = new Size(uc_campara.Size.Width - 8, 356);
				uc_campara.Show();
				uc_campara.BringToFront();
			}
		}

		public static void vsplus_open_fixcampara(int arg)
		{
			if (uc_campara != null && !uc_campara.IsDisposed)
			{
				uc_campara.Dispose();
			}
			if (uc_campara == null || uc_campara.IsDisposed)
			{
				uc_campara = new UserControl_CamPara(mFn, USR[mFn], null);
				uc_usroperarion[mFn].Controls.Add(uc_campara);
				uc_campara.Location = new Point(0, 582);
				uc_campara.Size = new Size(uc_campara.Size.Width - 8, 356);
				uc_campara.sel_pagenum(arg);
				uc_campara.Show();
				uc_campara.BringToFront();
			}
		}

		private void vsplus_visual_test(VisualPara visualpara)
		{
			Thread thread = new Thread(thd_visual_test);
			thread.Start(visualpara);
		}

		private void thd_visual_test(object o)
		{
			VisualPara visualPara = (VisualPara)o;
			VISUAL_RESULT visual_result = new VISUAL_RESULT();
			visual_result.is_test = true;
			is_smt_test = true;
			if (visualPara.visualtype == VisualType.FootPrint_R)
			{
				PinConfig pinconfig = common_footprint_get_pinconfig(visualPara.footprintname);
				visual_result.set_pinconfig(pinconfig);
			}
			switch (mCurCam[mFn])
			{
			case CameraType.Fast:
				mark_led_on_ext(mFn, flag: false);
				mark_light_on_ext(mFn, flag: false);
				if (uc_usroperarion[mFn] != null && !uc_usroperarion[mFn].IsDisposed)
				{
					uc_usroperarion[mFn].switch_to_cam(CameraType.Fast);
				}
				fhcam_led_on(mFn, CameraType.Fast, flag: true);
				if (mIsSimulation && File.Exists("C:\\E\\hwgcpic\\fastcam.bmp"))
				{
					int num = HW.mFastCamItem[mFn].index[mZn[mFn]];
					mJVSBitmap[num] = new Bitmap("C:\\E\\hwgcpic\\fastcam.bmp");
				}
				visual_result.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
				if (ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.Fast, visualPara.visualtype, visualPara.scanr, visualPara.threshold, mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
				{
					CmMessageBoxTop((USR_INIT.mLanguage == 2) ? "Fast camera detect chip fail!" : "快速相机识别测试识别失败", MessageBoxButtons.OK);
				}
				break;
			case CameraType.High:
				mark_led_on_ext(mFn, flag: false);
				mark_light_on_ext(mFn, flag: false);
				if (uc_usroperarion[mFn] != null && !uc_usroperarion[mFn].IsDisposed)
				{
					uc_usroperarion[mFn].switch_to_cam(CameraType.High);
				}
				fhcam_led_on(mFn, CameraType.High, flag: true);
				if (mIsSimulation)
				{
					string text = "C:\\E\\hwgcpic\\highcam.bmp";
					if (File.Exists(text))
					{
						Bitmap bitmap = new Bitmap(text);
						BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, 1944, 1944), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
						Marshal.Copy(bitmapData.Scan0, pKSJBuffer[HW.mHighCamItem[mFn].index[0]], 0, 11337408);
						bitmap.UnlockBits(bitmapData);
					}
				}
				visual_result.set_w_h(USR[mFn].mTest_Lmm, USR[mFn].mTest_Wmm);
				if (ImageVisual(mFn, VISUAL_MODE.COMMON, CameraType.High, visualPara.visualtype, visualPara.scanr, visualPara.threshold, mZn[mFn], 0, 0, 0f, ref visual_result) != 0)
				{
					CmMessageBoxTop((USR_INIT.mLanguage == 2) ? "HD camera detect chip fail!" : "高清相机识别测试识别失败", MessageBoxButtons.OK);
				}
				break;
			}
			mMutexBt = false;
		}

		public void vsplus_open_visualshow(int fn)
		{
			if (mVisualForm == null)
			{
				mVisualForm = new Visual_Form[HW.mFnNum];
				for (int i = 0; i < HW.mFnNum; i++)
				{
					mVisualForm[i] = null;
				}
			}
			if (mVisualForm[fn] == null || mVisualForm[fn].IsDisposed)
			{
				mVisualForm[fn] = new Visual_Form(USR_INIT.mLanguage);
				mVisualForm[fn].ShowDetails(pictureBox_VisualTest[fn].Image, (VisualResultString0)pictureBox_VisualTest[fn].Tag);
				mVisualForm[fn].Show();
			}
		}

		private void vsplus_factory_capture(int mode)
		{
			if (!mMutex_PushButton)
			{
				mMutex_PushButton = true;
				Thread thread = new Thread(thd_factory_capture);
				thread.Start(mode);
			}
		}

		private void thd_factory_capture(object o)
		{
			int num = (int)o;
			if (mCurCam[mFn] == CameraType.Mark)
			{
				Bitmap bitmap = null;
				int num2 = HW.mMarkCamItem[mFn].index[0];
				bool flag = true;
				int num3 = mJvs_usrWidth;
				int num4 = mJvs_usrHeight;
				int num5 = mJvs_rawWidth;
				int num6 = mJvs_rawHeight;
				bool flag2 = mIsNoLight;
				mIsNoLight = true;
				startMarkStill_andWait(mFn);
				mIsNoLight = flag2;
				Rectangle destRect;
				Rectangle srcRect;
				if (num == 0)
				{
					bitmap = new Bitmap(num5, num6);
					destRect = new Rectangle(0, 0, num5, num6);
					srcRect = new Rectangle(0, 0, num5, num6);
				}
				else
				{
					bitmap = new Bitmap(num3, num4);
					destRect = new Rectangle(0, 0, num3, num4);
					srcRect = new Rectangle((num5 - num3) / 2, 0, num3, num6);
				}
				Graphics graphics = Graphics.FromImage(bitmap);
				if (flag)
				{
					graphics.CompositingQuality = CompositingQuality.HighQuality;
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				}
				graphics.DrawImage(mJVSBitmap[num2], destRect, srcRect, GraphicsUnit.Pixel);
				graphics.Dispose();
				BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
				bitmap.UnlockBits(bitmapdata);
				string text = "C:/pic_";
				DateTime now = DateTime.Now;
				string text2 = text;
				text = text2 + now.Year + now.Month.ToString("D2") + now.Day.ToString("D2") + "_" + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2") + "_" + now.Millisecond.ToString("D3") + ".bmp";
				if (!mIsSimulation)
				{
					bitmap.Save(text, ImageFormat.Bmp);
				}
				bitmap.Dispose();
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Collect done: " : ("采集完成: " + text));
			}
			else if (mCurCam[mFn] == CameraType.Fast)
			{
				mark_led_on_ext(mFn, flag: false);
				mark_light_on_ext(mFn, flag: false);
				Bitmap bitmap2 = null;
				int num7 = mZn[mFn];
				int num8 = HW.mFastCamItem[mFn].index[num7];
				bool flag3 = true;
				int num9 = mJvs_usrWidth;
				int num10 = mJvs_usrHeight;
				int num11 = mJvs_rawWidth;
				int num12 = mJvs_rawHeight;
				bool flag4 = mIsNoLight;
				mIsNoLight = true;
				startFastStill_andWait(mCurCam[mFn], mFn, num7);
				mIsNoLight = flag4;
				Rectangle destRect2;
				Rectangle srcRect2;
				if (num == 0)
				{
					bitmap2 = new Bitmap(num11, num12);
					destRect2 = new Rectangle(0, 0, num11, num12);
					srcRect2 = new Rectangle(0, 0, num11, num12);
				}
				else
				{
					bitmap2 = new Bitmap(num9, num10);
					destRect2 = new Rectangle(0, 0, num9, num10);
					srcRect2 = new Rectangle((num11 - num9) / 2, 0, num9, num12);
				}
				Graphics graphics2 = Graphics.FromImage(bitmap2);
				if (flag3)
				{
					graphics2.CompositingQuality = CompositingQuality.HighQuality;
					graphics2.SmoothingMode = SmoothingMode.HighQuality;
					graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
				}
				graphics2.DrawImage(mJVSBitmap[num8], destRect2, srcRect2, GraphicsUnit.Pixel);
				graphics2.Dispose();
				BitmapData bitmapdata2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
				bitmap2.UnlockBits(bitmapdata2);
				string text3 = "C:/pic_";
				DateTime now2 = DateTime.Now;
				string text4 = text3;
				text3 = text4 + now2.Year + now2.Month.ToString("D2") + now2.Day.ToString("D2") + "_" + now2.Hour.ToString("D2") + now2.Minute.ToString("D2") + now2.Second.ToString("D2") + "_" + now2.Millisecond.ToString("D3") + ".bmp";
				if (!mIsSimulation)
				{
					bitmap2.Save(text3, ImageFormat.Bmp);
				}
				bitmap2.Dispose();
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Collect done:" : ("采集完成: " + text3));
			}
			else if (mCurCam[mFn] == CameraType.High)
			{
				mark_led_on_ext(mFn, flag: false);
				mark_light_on_ext(mFn, flag: false);
				Bitmap bitmap3 = null;
				int num13 = mZn[mFn];
				_ = mKSJ_VWsize;
				_ = mKSJ_VHsize;
				int num14 = mKSJ_VWsize;
				int num15 = mKSJ_VHsize;
				bool flag5 = mIsNoLight;
				mIsNoLight = true;
				startKSJStillAndWait(num13);
				mIsNoLight = flag5;
				bitmap3 = new Bitmap(num14, num15);
				new Rectangle(0, 0, num14, num15);
				new Rectangle(0, 0, num14, num15);
				BitmapData bitmapData = bitmap3.LockBits(new Rectangle(0, 0, bitmap3.Width, bitmap3.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
				Marshal.Copy(pKSJBuffer[num13], 0, bitmapData.Scan0, num14 * num15 * 3);
				bitmap3.UnlockBits(bitmapData);
				string text5 = "C:/pic_highcam_";
				DateTime now3 = DateTime.Now;
				string text6 = text5;
				text5 = text6 + now3.Year + now3.Month.ToString("D2") + now3.Day.ToString("D2") + "_" + now3.Hour.ToString("D2") + now3.Minute.ToString("D2") + now3.Second.ToString("D2") + "_" + now3.Millisecond.ToString("D3") + ".bmp";
				if (!mIsSimulation)
				{
					bitmap3.Save(text5, ImageFormat.Bmp);
				}
				bitmap3.Dispose();
				CmMessageBoxTop_Ok((USR_INIT.mLanguage == 2) ? "Collect done:" : ("采集完成: " + text5));
			}
			mMutex_PushButton = false;
		}
	}
}
