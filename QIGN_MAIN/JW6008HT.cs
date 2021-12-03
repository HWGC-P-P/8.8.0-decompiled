using System;
using System.Runtime.InteropServices;
using QIGN_COMMON;

namespace QIGN_MAIN
{
	internal class JW6008HT
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void IMAGE_STREAM_CALLBACK(uint channelNumber, IntPtr context);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int InitDSPs();

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int GetTotalDSPs();

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int DeInitDSPs();

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr ChannelOpen(int ChannelNum);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int ChannelClose(IntPtr handle);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int SetVideoStandard(IntPtr handle, VideoStandard VideoStandard);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int StartVideoPreview(IntPtr handle, IntPtr WndHandle, ref RECT rect, bool bOverlay, int VideoFormat, int FrameRate);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int StopVideoPreview(IntPtr hChannel);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int SetEncoderPictureFormat(IntPtr handle, PictureFormat PictureFormat);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int SetVideoPara(IntPtr handle, int Brightness, int Contrast, int Saturation, int Hue);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int GetVideoPara(IntPtr handle, ref VideoStandard VideoStandard, ref int Brightness, ref int Contrast, ref int Saturation, ref int Hue);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int GetOriginalImage(IntPtr handle, IntPtr ImageBuf, ref int Size);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int GetOriginalImage(IntPtr handle, byte[] ImageBuf, ref int Size);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int GetJpegImage(IntPtr handle, IntPtr ImageBuf, ref int Size, int nQuality);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int GetJpegImageFile(IntPtr handle, string ImageFile, int nQuality);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int SetOverlayColorKey(uint DestColorKey);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int SetPreviewOsdMode(int nMode);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int SetPreviewOverlayMode(bool bTrue);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int StartVideoPreviewEx(IntPtr ChannelNum, IntPtr WndHandle, ref RECT rect, bool bOverlay, int VideoFormat, int FrameRate);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int StopVideoPreviewEx(IntPtr ChannelNum);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int UpdateVideoPreviewEx(int nCount, int index = 0);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int ConfigSubChannelSplit(int nMaxSubCh, int nMode = 0);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int SetupInfoDisplay(IntPtr hChannel, int x, int y, int w, int h, IntPtr pBits, int size);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int SetInfoDisplay(IntPtr hChannel, bool bEnable);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int SetupNotifyThreshold(IntPtr hChannel, int iFramesThreshold);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int RegisterMessageNotifyHandle(IntPtr hWnd, uint MessageId);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int SetImageStream(IntPtr hChannel, int bStart, uint fps, uint width, uint height, IntPtr[] imageBuffer, int bVideoIn);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int RegisterImageStreamCallback(IMAGE_STREAM_CALLBACK ImageStreamCallback, IntPtr Context);

		[DllImport("hvCapSDK.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern int RegisterChannelImageStreamCallback(IntPtr hChannel, IMAGE_STREAM_CALLBACK ImageStreamCallback, IntPtr Context);
	}
}
