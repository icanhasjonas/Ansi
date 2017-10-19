using System;
using System.Collections.Generic;
using System.Text;

namespace Ansi {
	public class AnsiFormatter {
		private static readonly IDictionary<ConsoleColor, string> _map = new Dictionary<ConsoleColor, string> {
			{ConsoleColor.Black, new StringBuilder().SetMode( Mode.ForegroundBlack, Mode.Normal ).ToString()},
			{ConsoleColor.DarkBlue, new StringBuilder().SetMode( Mode.ForegroundBlue, Mode.Normal ).ToString()},
			{ConsoleColor.DarkGreen, new StringBuilder().SetMode( Mode.ForegroundGreen, Mode.Normal ).ToString()},
			{ConsoleColor.DarkCyan, new StringBuilder().SetMode( Mode.ForegroundCyan, Mode.Normal ).ToString()},
			{ConsoleColor.DarkRed, new StringBuilder().SetMode( Mode.ForegroundRed, Mode.Normal ).ToString()},
			{ConsoleColor.DarkMagenta, new StringBuilder().SetMode( Mode.ForegroundMagenta, Mode.Normal ).ToString()},
			{ConsoleColor.DarkYellow, new StringBuilder().SetMode( Mode.ForegroundYellow, Mode.Normal ).ToString()},
			{ConsoleColor.Gray, new StringBuilder().SetMode( Mode.ForegroundWhite, Mode.Normal ).ToString()},

			{ConsoleColor.DarkGray, new StringBuilder().SetMode( Mode.ForegroundBlack, Mode.Bold ).ToString()},
			{ConsoleColor.Blue, new StringBuilder().SetMode( Mode.ForegroundBlue, Mode.Bold ).ToString()},
			{ConsoleColor.Green, new StringBuilder().SetMode( Mode.ForegroundGreen, Mode.Bold ).ToString()},
			{ConsoleColor.Cyan, new StringBuilder().SetMode( Mode.ForegroundCyan, Mode.Bold ).ToString()},
			{ConsoleColor.Red, new StringBuilder().SetMode( Mode.ForegroundRed, Mode.Bold ).ToString()},
			{ConsoleColor.Magenta, new StringBuilder().SetMode( Mode.ForegroundMagenta, Mode.Bold ).ToString()},
			{ConsoleColor.Yellow, new StringBuilder().SetMode( Mode.ForegroundYellow, Mode.Bold ).ToString()},
			{ConsoleColor.White, new StringBuilder().SetMode( Mode.ForegroundWhite, Mode.Bold ).ToString()},
		};

		public static AnsiColor Rgb( byte r, byte g, byte b ) => new AnsiColor( r, g, b );

		public static string Colorize(FormattableString fw)
		{
			var args = fw.GetArguments();
			for (var i = 0; i < args.Length; i++)
			{
				switch( args[i] ) {
					case ConsoleColor c:
						args[i] = _map[c];
						break;

					case AnsiColor x:
						args[i] = new StringBuilder().SetForegroundColor( x );
						break;
				}
			}
			return string.Format(fw.Format, args);
		}
	}
}