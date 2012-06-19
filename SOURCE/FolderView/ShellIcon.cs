using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;

namespace FolderView
{
	public class ShellIcon
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct SHFILEINFO
		{
			public IntPtr hIcon;
			public IntPtr iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		};
		class Win32
		{
			public const uint SHGFI_ICON = 0x100;
			public const uint SHGFI_LARGEICON = 0x0; // Large icon
			public const uint SHGFI_SMALLICON = 0x1; // Small icon
			public const uint USEFILEATTRIBUTES = 0x000000010; // when the full path isn't available
			[DllImport("shell32.dll")]
			public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbSizeFileInfo, uint uFlags);
			[DllImport("User32.dll")]
			public static extern int DestroyIcon(IntPtr hIcon);
		}

		[DllImport("Shell32", CharSet = CharSet.Auto)]
		extern static int ExtractIconEx(
			[MarshalAs(UnmanagedType.LPTStr)] 
            string lpszFile,
			int nIconIndex,
			IntPtr[] phIconLarge,
			IntPtr[] phIconSmall,
			int nIcons);

		private static Icon GetIcon(string extension,bool large)
		{
			
            //opens the registry for the wanted key.
            RegistryKey Root = Registry.ClassesRoot;

            RegistryKey ExtensionKey = Root.OpenSubKey(extension);
			if (ExtensionKey == null)
				return null;

            ExtensionKey.GetValueNames();
            RegistryKey ApplicationKey =
                Root.OpenSubKey(ExtensionKey.GetValue("").ToString());

            //gets the name of the file that have the icon.
            string IconLocation = ApplicationKey.OpenSubKey("DefaultIcon").GetValue("").ToString();

            string[] IconPath = IconLocation.Split(',');

            if (IconPath[1] == null) 
				IconPath[1] = "0";

			if (IconPath[0][IconPath[0].Length - 1] == 34)
				IconPath[0] = IconPath[0].Substring(0, IconPath[0].Length - 1);

			if (IconPath[0][0] == 34)
				IconPath[0] = IconPath[0].Substring(1);

            IntPtr[] Large = new IntPtr[1], Small = new IntPtr[1];

            //extracts the icon from the file.
            ExtractIconEx(IconPath[0],Convert.ToInt16(IconPath[1]), Large, Small, 1);

            return large ? Icon.FromHandle(Large[0]) : Icon.FromHandle(Small[0]);

		}
		
		public static int getSetImage(string fileName, ref ImageList IL,bool large)
		{
			if (fileName.Contains('.') == false)
				return 0;

			String extension = fileName.Substring(fileName.LastIndexOf('.') + 1);

			if (extension[0] != '.') 
				extension = '.' + extension;

			Icon I=null;
			if (IL.Images.ContainsKey(extension) == false)
			{
				I = GetIcon(extension, large);
				if (I != null)
					IL.Images.Add(extension, I);
				else
					return -1;
			}

			return IL.Images.IndexOfKey(extension);
		}
	}
}
