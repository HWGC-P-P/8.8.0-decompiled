using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace QIGN_MAIN
{
	internal class Externs
	{
		[StructLayout(LayoutKind.Sequential)]
		public class SP_DEVINFO_DATA
		{
			public int cbSize;

			public Guid classGuid;

			public int devInst;

			public ulong reserved;
		}

		public const int DIGCF_ALLCLASSES = 4;

		public const int DIGCF_PRESENT = 2;

		public const int SPDRP_DEVICEDESC = 0;

		public const int INVALID_HANDLE_VALUE = -1;

		public const int MAX_DEV_LEN = 1000;

		public static string[] portArray;

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, uint iEnumerator, IntPtr hParent, uint nFlags);

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern int SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern bool SetupDiEnumDeviceInfo(IntPtr lpInfoSet, uint dwIndex, SP_DEVINFO_DATA devInfoData);

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern bool SetupDiGetDeviceRegistryProperty(IntPtr lpInfoSet, SP_DEVINFO_DATA DeviceInfoData, uint Property, uint PropertyRegDataType, StringBuilder PropertyBuffer, uint PropertyBufferSize, IntPtr RequiredSize);

		public static string[] DiviceName()
		{
			List<string> list = new List<string>();
			try
			{
				Guid gClass = Guid.Empty;
				IntPtr lpInfoSet = SetupDiGetClassDevs(ref gClass, 0u, IntPtr.Zero, 6u);
				if (lpInfoSet.ToInt32() == -1)
				{
					throw new Exception("Invalid Handle");
				}
				SP_DEVINFO_DATA sP_DEVINFO_DATA = new SP_DEVINFO_DATA();
				sP_DEVINFO_DATA.cbSize = 28;
				sP_DEVINFO_DATA.devInst = 0;
				sP_DEVINFO_DATA.classGuid = Guid.Empty;
				sP_DEVINFO_DATA.reserved = 0uL;
				StringBuilder stringBuilder = new StringBuilder("");
				stringBuilder.Capacity = 1000;
				for (uint num = 0u; SetupDiEnumDeviceInfo(lpInfoSet, num, sP_DEVINFO_DATA); num++)
				{
					DateTime now = DateTime.Now;
					while (!SetupDiGetDeviceRegistryProperty(lpInfoSet, sP_DEVINFO_DATA, 0u, 0u, stringBuilder, 1000u, IntPtr.Zero))
					{
						double totalMilliseconds = (DateTime.Now - now).TotalMilliseconds;
						if (totalMilliseconds > 100.0)
						{
							break;
						}
					}
					list.Add(stringBuilder.ToString());
				}
				SetupDiDestroyDeviceInfoList(lpInfoSet);
			}
			catch (Exception innerException)
			{
				throw new Exception("枚举设备列表出错", innerException);
			}
			return list.ToArray();
		}
	}
}
