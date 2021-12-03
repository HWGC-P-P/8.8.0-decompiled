using System;
using System.Runtime.InteropServices;

namespace QIGN_MAIN
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int RAWSTREAM_DIRECT_READ_CALLBACK(uint channelNumber, IntPtr DataBuf, int FrameType, int width, int height, IntPtr Context);
}
