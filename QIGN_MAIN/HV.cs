using System.Runtime.InteropServices;

namespace QIGN_MAIN
{
	public class HV
	{
		[DllImport("moon_jvs.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int InitDSPs();
	}
}
