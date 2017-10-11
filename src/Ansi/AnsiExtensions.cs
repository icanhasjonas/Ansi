using System.Linq;
using System.Text;

namespace Ansi {
	public static class AnsiExtensions {
		// https://www.gnu.org/software/screen/manual/html_node/Control-Sequences.html

		private static StringBuilder Escape( this StringBuilder b ) => b.Append( '\x001b' );
		public static StringBuilder Bell( this StringBuilder b ) => b.Append( '\x0007' );

		public static StringBuilder SetTitle( this StringBuilder b, string title ) => b
			.Escape()
			.Append( "]0;" )
			.Append( title )
			.Bell();

		public static StringBuilder ResizeWindow( this StringBuilder b, int lines, int columns ) => b
			.Escape()
			.Append( "[8;" )
			.Append( lines )
			.Append( ';' )
			.Append( columns )
			.Append( 't' );

		public static StringBuilder HideCursor( this StringBuilder b ) => b.Escape().Append( "[?25l" );
		public static StringBuilder ShowCursor( this StringBuilder b ) => b.Escape().Append( "[?25h" );
		public static StringBuilder VisualBell( this StringBuilder b ) => b.Escape().Append( "g" );
		public static StringBuilder ResetState( this StringBuilder b ) => b.Escape().Append( "c" );
		public static StringBuilder SaveState( this StringBuilder b ) => b.Escape().Append( "[s" );
		public static StringBuilder RestoreState( this StringBuilder b ) => b.Escape().Append( "[u" );
		public static StringBuilder SetCursorHome( this StringBuilder b ) => b.Escape().Append( "[H" );

		public static StringBuilder SetCursorPosition( this StringBuilder b, int line, int col ) => b
			.Escape()
			.Append( '[' )
			.Append( line )
			.Append( col )
			.Append( 'H' );

		public static StringBuilder EraseScreen( this StringBuilder b ) => b.Escape().Append( "[2J" );
		public static StringBuilder EraseScreenToCursor( this StringBuilder b ) => b.Escape().Append( "[1J" );
		public static StringBuilder EraseScreenFromCursor( this StringBuilder b ) => b.Escape().Append( "[0J" );

		public static StringBuilder EraseLine( this StringBuilder b ) => b.Escape().Append( "[2K" );
		public static StringBuilder EraseLineToCursor( this StringBuilder b ) => b.Escape().Append( "[1K" );
		public static StringBuilder EraseLineFromCursor( this StringBuilder b ) => b.Escape().Append( "[0K" );


		public static StringBuilder SetMode( this StringBuilder b, params Mode[] modes ) => b
			.Escape()
			.Append( '[' )
			.Append( string.Join( ";", modes.Select( x => (int)x ) ) )
			.Append( 'm' );

		private static StringBuilder SetColorColor( this StringBuilder b, Mode mode, Rgb color ) => b
			.Escape()
			.Append( '[' )
			.Append( (byte)mode )
			.Append( ";2;" )
			.Append( color.R ).Append( ';' )
			.Append( color.G ).Append( ';' )
			.Append( color.B ).Append( 'm' );

		public static StringBuilder SetBackgroundColor( this StringBuilder b, Rgb color ) => b.SetColorColor( Mode.SetBackgroundColor, color );
		public static StringBuilder SetForegroundColor( this StringBuilder b, Rgb color ) => b.SetColorColor( Mode.SetForegroundColor, color );

		private static StringBuilder AnsiEscapePrefix( this StringBuilder b, int count ) => b.Escape().Append( '[' ).Append( count );
		public static StringBuilder Up( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'A' );
		public static StringBuilder Down( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'B' );
		public static StringBuilder Right( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'C' );
		public static StringBuilder Left( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'D' );

		public static StringBuilder NextLine( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'E' );
		public static StringBuilder PreviousLine( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'F' );
		public static StringBuilder Column( this StringBuilder b, int col = 1 ) => b.AnsiEscapePrefix( col ).Append( 'G' );

		public static StringBuilder InsertLine( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'L' );
		public static StringBuilder DeleteLine( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'M' );

		public static StringBuilder ScrollRegionUp( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'S' );
		public static StringBuilder ScrollRegionDown( this StringBuilder b, int count = 1 ) => b.AnsiEscapePrefix( count ).Append( 'T' );
	}
}