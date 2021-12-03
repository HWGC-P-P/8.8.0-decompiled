using System;
using System.Runtime.InteropServices;

namespace QIGN_MAIN
{
	internal class CAM
	{
		public enum KSJ_ADDRESSMODE
		{
			KSJ_SKIPNONE,
			KSJ_SKIP2,
			KSJ_SKIP3,
			KSJ_SKIP4,
			KSJ_SKIP8
		}

		public enum KSJ_PARAM
		{
			KSJ_EXPOSURE,
			KSJ_RED,
			KSJ_GREEN,
			KSJ_BLUE,
			KSJ_GAMMA,
			KSJ_PREVIEW_COLUMNSTART,
			KSJ_PREVIEW_ROWSTART,
			KSJ_CAPTURE_COLUMNSTART,
			KSJ_CAPTURE_ROWSTART,
			KSJ_HORIZONTALBLANK,
			KSJ_VERTICALBLANK,
			KSJ_FLIP,
			KSJ_BIN,
			KSJ_MIRROR,
			KSJ_CONTRAST,
			KSJ_BRIGHTNESS,
			KSJ_VGAGAIN,
			KSJ_CLAMPLEVEL,
			KSJ_CDSGAIN,
			KSJ_RED_SHIFT,
			KSJ_GREEN_SHIFT,
			KSJ_BLUE_SHIFT,
			KSJ_COMPANDING,
			KSJ_EXPOSURE_LINES,
			KSJ_SATURATION,
			KSJ_TRIGGERDELAY,
			KSJ_STROBEDELAY,
			KSJ_TRIGGER_MODE,
			KSJ_TRIGGER_METHOD
		}

		public enum KSJ_PREVIEWMODE
		{
			PM_RAWDATA,
			PM_RGBDATA
		}

		[DllImport("JVSDK.dll")]
		public static extern int JVS_InitSDK(int dwWD1Mode);

		[DllImport("JVSDK.dll")]
		public static extern int JVS_InitSDK();

		[DllImport("JVSDK.dll")]
		public static extern void JVS_ReleaseSDK();

		[DllImport("JVSDK.dll")]
		public static extern bool JVS_OpenChannel(int nChannel);

		[DllImport("JVSDK.dll")]
		public static extern void JVS_CloseChannel(int nChannel);

		[DllImport("JVSDK.dll")]
		public static extern bool JVS_InitPreview();

		[DllImport("JVSDK.dll")]
		public static extern void JVS_ReleasePreview();

		[DllImport("JVSDK.dll")]
		public static extern bool JVS_SetVideoPreview(int nChannel, IntPtr hWnd, int[] rt, bool bPreview);

		public static bool JVS_CloseVideoPreview(int nChannel)
		{
			return JVS_SetVideoPreview(nChannel, default(IntPtr), new int[4], bPreview: false);
		}

		[DllImport("JVSDK.dll")]
		public static extern void JVS_SetVideoPara(int nChannel, int nBrightness, int nContrast, int nSatuation, int nHue);

		[DllImport("JVSDK.dll")]
		public static extern void JVS_SetVideoPara(int nChannel, int nBrightness, int nContrast, int nSatuation, int nHue, int nSharpness);

		[DllImport("JVSDK.dll")]
		public static extern void JVS_SetVideoPixelMode(int nChannel, int dwPixelMode, int dwVideoFormat, int dwPixelFormat, int dwVideoCut);

		[DllImport("JVSDK.dll")]
		public static extern void JVS_SetVideoPixelMode(int nChannel, int dwPixelMode, int dwVideoFormat);

		[DllImport("JVSDK.dll")]
		public static extern void JVS_RegisterNotify(IntPtr hWnd, int dwNotifyMsg);

		[DllImport("JVSDK.dll")]
		public static extern bool JVS_GetBitmapSize(int nChannel, out int dwWidth, out int dwHeight);

		[DllImport("JVSDK.dll")]
		public static extern bool JVS_GetBitmap(int nChannel, byte[] pBuffer);

		[DllImport("JVSDK.dll")]
		public static extern bool JVS_GetBitmap(int nChannel, IntPtr pBuffer);

		[DllImport("JVSDK.dll")]
		public static extern bool JVS_GetBitmapToFile(int nChannel, string pCapBmpFile);

		[DllImport("JVSDK.dll")]
		public static extern void JVS_EnablePreviewHD1(int nChannel, bool bEnableHD1);

		[DllImport("JVSDK.dll")]
		public static extern void JVS_SetVideoCrop(int nChannel, int dwPixelCroped);

		[DllImport("JVSDK.dll")]
		public static extern void JVS_SetVideoMask(int nChannel, bool bEnableMask, bool bMaskToRec, int nMaskX, int nMaskY, int nWidth, int nHeight);

		[DllImport("JVSDK.dll", EntryPoint = "JVS_SetVideoMask")]
		public static extern void JVS_SetOSD(int nChannel, int dwOsdMode, char[] pText, bool bEnable);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_Init();

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_UnInit();

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_PreviewSetFieldOfView(int nChannel, int nColumnStart, int nRowStart, int nColumnSize, int nRowSize, KSJ_ADDRESSMODE ColumnAddressMode, KSJ_ADDRESSMODE RowAddressMode);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_CaptureSetFieldOfView(int nChannel, int nColumnStart, int nRowStart, int nColumnSize, int nRowSize, KSJ_ADDRESSMODE ColumnAddressMode, KSJ_ADDRESSMODE RowAddressMode);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_PreviewSetMode(int nIndex, KSJ_PREVIEWMODE PreviewMode);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_PreviewGetMode(int nIndex, ref KSJ_PREVIEWMODE PreviewMode);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_PreviewGetSize(int nChannel, out int pnWidth, out int pnHeight);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_CaptureGetSize(int nChannel, out int pnWidth, out int pnHeight);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_PreviewSetPos(int nChannel, IntPtr hWnd, int x, int y, int nWidth, int nHeight);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_PreviewStart(int nChannel, bool bStart);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_CaptureRgbData(int nChannel, byte[] pRgbData);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_CaptureRgbData(int nChannel, IntPtr pRgbData);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_HelperSaveToBmp(byte[] pRgbData, int nWidth, int nHeight, int nBitCount, string pszfileName);

		[DllImport("KSJApi.dll", EntryPoint = "KSJ_HelperSaveToBmp")]
		public static extern int KSJ_HelperStretchBmp(byte[] pRgbDataS, int nWidth, int nHeight, int nBitCount, byte[] pRgbDataD, int nStretchWidth, int nStretchHeight);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_PreviewGetFrameRate(int nChannel, out float fFrameRate);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_CaptureGetSizeEx(int nChannel, out int pnWidth, out int pnHeight, out int pnBitCount);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_CaptureRgbDataAfterEmptyFrameBuffer(int nChannel, byte[] pRgbData);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_GetParamRange(int nChannel, KSJ_PARAM Param, out int pnMinValue, out int pnMaxValue);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_SetParam(int nChannel, KSJ_PARAM Param, int nValue);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_GetParam(int nChannel, KSJ_PARAM Param, out int pnValue);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_ExposureTimeSet(int nChannel, float fExpTimeMs);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_ExposureTimeGet(int nChannel, out float pfExpTimeMs);

		[DllImport("KSJApi.dll")]
		public static extern int KSJ_DeviceGetCount();
	}
}
