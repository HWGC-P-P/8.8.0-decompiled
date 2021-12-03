using System.Runtime.InteropServices;

namespace QIGN_MAIN
{
	public class BUS
	{
		[DllImport("moon_run.dll")]
		public static extern int InitConnection();

		[DllImport("moon_run.dll")]
		public static extern void UninitConnection();
	}
}
