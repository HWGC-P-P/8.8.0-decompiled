using System;
using System.Windows.Forms;

namespace QIGN_MAIN
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new MainForm0());
		}
	}
}
