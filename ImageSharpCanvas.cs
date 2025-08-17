using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Numerics;

namespace LittleAnim
{
		class ImageSharpCanvas : ICanvas, IDisposable
		{
				private Image Image;
				private readonly Dictionary<string, FontFamily> FontFamilies = new();
				public int Width => Image.Width;
				public int Height => Image.Height;
				public ImageSharpCanvas(int width, int height)
				{
						Image = new Image<Rgba32>(width, height);
				}

				public void Clear(LittleAnim.Color backgroundColor)
				{
						SixLabors.ImageSharp.Color color = new SixLabors.ImageSharp.Color(
								new Rgba32(backgroundColor.R, backgroundColor.G, backgroundColor.B, backgroundColor.A));

						Image.Mutate(ctx => ctx.Fill(color));
				}

				public void Dispose()
				{
						Image.Dispose();
				}

				public void DrawBox(Vector2 position, float width, float height, Color fillColor, Color? strokeColor = null, float strokeWidth = 1)
				{
						throw new NotImplementedException();
				}

				public void DrawCircle(Vector2 center, float radius, Color fillColor, Color? strokeColor = null, float strokeWidth = 1)
				{
						throw new NotImplementedException();
				}

				public void DrawImage(IImage image, Vector2 position)
				{
						throw new NotImplementedException();
				}

				public void DrawLine(Vector2 start, Vector2 end, Color color, float width)
				{
						throw new NotImplementedException();
				}

				public void DrawText(string text, Vector2 position, Font font, LittleAnim.Color color)
				{
						if (!FontFamilies.TryGetValue(font.FamilyName, out var fontFamily))
						{
								FontCollection collection = new FontCollection();
								FontFamily family = collection.Add(font.Path);
								FontFamilies.Add(font.FamilyName, family);
								fontFamily = family;
						}

						var fontToDraw = fontFamily.CreateFont(font.Size);
						var brush = new SolidBrush(ToSharpColor(color));
						var location = ToSharpPoint(position);

						Image.Mutate(ctx => ctx.DrawText(text, fontToDraw, brush, location));
				}

				public IImage GetCurrent()
				{
						return new ImageSharpImage(Image);
				}


				private SixLabors.ImageSharp.Color ToSharpColor(LittleAnim.Color c)
								=> SixLabors.ImageSharp.Color.FromRgba(c.R, c.G, c.B, c.A);

				private SixLabors.ImageSharp.PointF ToSharpPoint(Vector2 p)
								=> new SixLabors.ImageSharp.PointF(p.X, p.Y);
		}
}
