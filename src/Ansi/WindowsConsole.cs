using System;
using System.Runtime.InteropServices;

namespace Ansi {
	public static class WindowsConsole {
		internal static class NativeMethods {
			private const string Kernel32 = "kernel32.dll";

			[DllImport( Kernel32, EntryPoint = "GetVersion", SetLastError = true )]
			internal static extern int GetVersion();

			[DllImport( Kernel32, EntryPoint = "SetConsoleMode", SetLastError = true )]
			internal static extern bool SetConsoleMode( IntPtr hConsoleHandle, int mode );

			[DllImport( Kernel32, EntryPoint = "GetConsoleMode", SetLastError = true )]
			internal static extern bool GetConsoleMode( IntPtr handle, out int mode );

			[DllImport( Kernel32, EntryPoint = "GetStdHandle", SetLastError = true )]
			internal static extern IntPtr GetStdHandle( int handle );
		}

		public static bool TryEnableVirtualTerminalProcessing()
		{
			if( !RuntimeInformation.IsOSPlatform( OSPlatform.Windows ) ) return false;

			try {
				var handle = NativeMethods.GetStdHandle( -11 );
				NativeMethods.GetConsoleMode( handle, out var mode );
				NativeMethods.SetConsoleMode( handle, mode | 0x4 );
				NativeMethods.GetConsoleMode( handle, out mode );
				return (mode & 0x4) == 0x4;
			}
			catch( DllNotFoundException ) {
				return false;
			}
			catch( EntryPointNotFoundException ) {
				return false;
			}
		}
	}
}