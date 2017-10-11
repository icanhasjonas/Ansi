namespace Ansi {
	public enum Mode {
		Reset = 0,
		Bold = 1,

		Faint = 2,
		Italic = 3,
		Underline = 4,
		Blink = 5,
		Inverse = 7,

		Normal = 22,
		NoItalic = 23,
		NoUnderline = 24,
		NoBlink = 25,
		NoInverse = 27,


		ForegroundBlack = 30,
		ForegroundRed = 31,
		ForegroundGreen = 32,
		ForegroundYellow = 33,
		ForegroundBlue = 34,
		ForegroundMagenta = 35,
		ForegroundCyan = 36,
		ForegroundWhite = 37,
		ForegroundDefault = 39,

		SetForegroundColor = 38,


		BackgroundBlack = 40,
		BackgroundRed = 41,
		BackgroundGreen = 42,
		BackgroundYellow = 43,
		BackgroundBlue = 44,
		BackgroundMagenta = 45,
		BackgroundCyan = 46,
		BackgroundWhite = 47,
		BackgroundDefault = 49,

		SetBackgroundColor = 48
	}
}