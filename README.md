# ansi
Ansi extensions for your favourite `StringBuilder`

# Example

```csharp

/*** NOTE: To use esapce sequences on your Windows 
  Console, you need to enable virtual terminal 
  processing. This is easy; */
WindowsConsole.TryEnableVirtualTerminalProcessing();
/* TryEnableVirtualTerminalProcessing shouldn't fail 
   and only really does something on Windows Platforms
*/
```


```csharp
Console.Write( new StringBuilder()
	.SetTitle("Hello World")
	.HideCursor()
	.SaveState() /* save state so we can restore it top of next loop*/
);

for( var i = 0;; i++ ) {
	/* What, ain't monochrome good enough for ya? */
	var color = new Rgb(
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
```

