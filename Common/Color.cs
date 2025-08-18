namespace LittleAnim.Common
{
		/// <summary>
		/// Immutable RGBA color struct with 8-bit channels.  
		/// Provides read-only properties for red, green, blue, and alpha,  
		/// where alpha defaults to 255 (fully opaque).
		/// </summary>
		public readonly struct Color(byte r, byte g, byte b, byte a = 255)
		{
				public byte R { get; } = r;
				public byte G { get; } = g;
				public byte B { get; } = b;
				public byte A { get; } = a;
		}
}
