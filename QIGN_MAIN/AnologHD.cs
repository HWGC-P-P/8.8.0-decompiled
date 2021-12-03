using System;
using System.Runtime.InteropServices;
using QIGN_COMMON;

namespace QIGN_MAIN
{
	internal class AnologHD
	{
		[DllImport("dvrshw.dll")]
		public static extern int InitDSPs();

		[DllImport("dvrshw.dll")]
		public static extern int StartVideoPreview(IntPtr hChannelHd, IntPtr WndHandle, ref RECT rect, bool bOverlay, int VideoFormat, int FrameRate);

		[DllImport("dvrshw.dll")]
		public static extern int StopVideoPreview(IntPtr hChannelHd);

		[DllImport("dvrshw.dll")]
		public static extern int ConfigSubChannelSplit(int nMaxSubCh, int nMode = 0);

		[DllImport("dvrshw.dll")]
		public static extern int GetTotalChannels();

		[DllImport("dvrshw.dll")]
		public static extern IntPtr ChannelOpen(int nChannel);

		[DllImport("dvrshw.dll")]
		public static extern int GetHardWare_Version(IntPtr hChannelHd);

		[DllImport("dvrshw.dll")]
		public static extern int Set_DeInterlace_Enable(IntPtr hChannelHd, int status);

		[DllImport("dvrshw.dll")]
		public static extern int Set_FullSizeRecoder_Enable(IntPtr hChannelHd, int status);

		[DllImport("dvrshw.dll")]
		public static extern int SetVideoStandard(IntPtr hChannelHd, VideoStandard VideoStandard);

		[DllImport("dvrshw.dll")]
		public static extern int SetEncoderPictureFormat(IntPtr hChannelHd, PictureFormat PictureFormat);

		[DllImport("dvrshw.dll")]
		public static extern int SetVideoPara(IntPtr hChannelHd, int Brightness, int Contrast, int Saturation, int Hue);

		[DllImport("dvrshw.dll")]
		public static extern int SetVideoSharp(IntPtr hChannelHd, int nLevel);

		[DllImport("dvrshw.dll")]
		public static extern int SetRecoderFrameRate(IntPtr hChannelHd, int nFrameRate);

		[DllImport("dvrshw.dll")]
		public static extern int Set_Video_Quality_Level(IntPtr hChannelHd, int lv);

		[DllImport("dvrshw.dll")]
		public static extern int SetVideoFrameRate(IntPtr hChannelHd, int nFrameRate);

		[DllImport("dvrshw.dll")]
		public static extern int StartVideoCapture(IntPtr hChannelHd);

		[DllImport("dvrshw.dll")]
		public static extern int StartDsp(IntPtr hChannelHd);

		[DllImport("dvrshw.dll")]
		public static extern int Set_Main_Enable(IntPtr hChannelHd, int status);

		[DllImport("dvrshw.dll")]
		public static extern int StopDMA(IntPtr hChannelHd);

		[DllImport("dvrshw.dll")]
		public static extern int StartDMA(IntPtr hChannelHd);

		[DllImport("dvrshw.dll")]
		public static extern int StopDsp(IntPtr hChannelHd);

		[DllImport("dvrshw.dll")]
		public static extern int GetOriginalImage(IntPtr hChannelHd, byte[] ImageBuf, ref ulong Size);

		[DllImport("dvrshw.dll")]
		public static extern int GetOriginalImage(IntPtr hChannelHd, IntPtr ImageBuf, ref ulong Size);

		[DllImport("dvrshw.dll")]
		public static extern int RegisterRAWStreamDirectCallback(RAWSTREAM_DIRECT_READ_CALLBACK RawStreamDirectReadCallback, IntPtr Context);
	}
}
