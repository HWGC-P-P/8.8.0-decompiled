using System;
using System.Runtime.InteropServices;

namespace QIGN_COMMON
{
	internal class DvrshMethod
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void RAWSTREAM_DIRECT_CALLBACK(int channelNumber, IntPtr DataBuf, int FrameType, int width, int height, IntPtr context);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void VIDEOSTATUS_CALLBACK(int channelNumber, int FrameType, IntPtr context);

		[DllImport("hwsys.dll")]
		public static extern int InitHwDSPs();

		[DllImport("hwsys.dll")]
		public static extern int DeInitHwDSPs();

		[DllImport("hwsys.dll")]
		public static extern int StartVideoPreview(int hChannel, IntPtr WndHandle, ref RECT rect);

		[DllImport("hwsys.dll")]
		public static extern int SaveCaptureImage(int hChannel, string path);

		[DllImport("hwsys.dll")]
		public static extern int GetVideoTotalChannels();

		[DllImport("hwsys.dll")]
		public static extern int VideoChannelOpen(int nChannel, int w, int h, int fps);

		[DllImport("hwsys.dll")]
		public static extern int StopVideoCapture(int nChannel);

		[DllImport("hwsys.dll")]
		public static extern int RegisterRAWDirectCallback(RAWSTREAM_DIRECT_CALLBACK StreamDirectReadCallback, IntPtr Context);

		[DllImport("hwsys.dll")]
		public static extern int RegisterVideoStatusCallback(VIDEOSTATUS_CALLBACK StreamDirectReadCallback, IntPtr Context);

		[DllImport("hwsys.dll")]
		public static extern void ChangeYUVToRGB(IntPtr yuvdata, IntPtr rgbdata, int width, int height);

		[DllImport("hwsys.dll")]
		public static extern void ChangeYUVToGrayRGB(IntPtr yuvdata, IntPtr rgbdata, int width, int height);

		[DllImport("hwsys.dll")]
		public static extern void SetMax_VideoSize(int width, int height);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern void OutputDebugString(string message);

		[DllImport("kernel32.dll")]
		public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
	}
}
