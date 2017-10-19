using System;
using System.Text;
using System.Threading;

namespace Ansi.ConsoleTest {
	class Program {
		static void Main( string[] args )
		{
			WindowsConsole.TryEnableVirtualTerminalProcessing();

			Console.Write( new StringBuilder()
				.SetTitle("Hello World")
				.HideCursor()
				.SaveState()
			);

			for( var i = 0;; i++ ) {
				var color = new AnsiColor(
					(byte)(128 + Math.Sin( i / 200d ) * 127),
					(byte)(128 + Math.Sin( i / 100d ) * 127),
					(byte)(128 + Math.Sin( i / 130d ) * 80) );
				Console.Write( new StringBuilder()
					.RestoreState()
					.SaveState()
					.SetMode( Mode.Reset )
					.Append( "HELLO" )
					.SetMode( Mode.Bold )
					.SetForegroundColor( color )
					.Append( "WORLD" )
				);
				Thread.Sleep( 25 );
			}
		}
	}
}