using LittleAnim.Common;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Numerics;

namespace LittleAnim.Rendering
{
		class ImageSharpCanvas : ICanvas, IDisposable
		{
				private Image<Rgba32> _image;
				private readonly Dictionary<string, FontFamily> _fontFamilies = new();
				public int Width => _image.Width;
				public int Height => _image.Height;


				public ImageSharpCanvas(int width, int height)
				{
						_image = new Image<Rgba32>(width, height);
				}

				public void Clear(Common.Color backgroundColor)
				{
						SixLabors.ImageSharp.Color color = new SixLabors.ImageSharp.Color(
								new Rgba32(backgroundColor.R, backgroundColor.G, backgroundColor.B, backgroundColor.A));

						_image.Mutate(ctx => ctx.Fill(color));
				}

				public void Dispose()
				{
						_image.Dispose();
				}
				public void DrawBox(Vector2 position, float width, float height, Common.Color fillColor, Common.Color? strokeColor = null, float strokeWidth = 1)
				{
						var rect = new RectangularPolygon(position.X, position.Y, width, height);
						_image.Mutate(ctx =>
						{
								ctx.Fill(ToSharpColor(fillColor), rect);

								if (strokeColor.HasValue)
								{
										ctx.Draw(ToSharpColor(strokeColor.Value), strokeWidth, rect);
								}
						});
				}

				public void DrawCircle(Vector2 center, float radius, Common.Color fillColor, Common.Color? strokeColor = null, float strokeWidth = 1)
				{
						var circle = new EllipsePolygon(center.X, center.Y, radius);

						_image.Mutate(ctx =>
						{
								ctx.Fill(ToSharpColor(fillColor), circle);

								if (strokeColor.HasValue)
								{
										ctx.Draw(ToSharpColor(strokeColor.Value), strokeWidth, circle);
								}
						});
				}

				public void DrawImage(IImage image, Vector2 position, float opacity)
				{
						if (image is not ImageSharpImage sharpImg)
								throw new ArgumentException("Only ImageSharpImage can be drawn on ImageSharpCanvas");

						var usableImage = sharpImg.GetImage();
						if (usableImage == null)
								throw new Exception("Invalid underlying type in ImageSharpImage");

						_image.Mutate(ctx =>
						{
								ctx.DrawImage(usableImage, new Point((int)position.X, (int)position.Y), opacity);
						});
				}


				public void DrawLine(Vector2 start, Vector2 end, Common.Color color, float width)
				{
						var line = new SixLabors.ImageSharp.Drawing.Path(
										new LinearLineSegment(
														new PointF(start.X, start.Y),
														new PointF(end.X, end.Y)));

						_image.Mutate(ctx =>
						{
								ctx.Draw(ToSharpColor(color), width, line);
						});
				}


				public void DrawText(string text, Vector2 position, Common.Font font, Common.Color color)
				{
						if (!_fontFamilies.TryGetValue(font.FamilyName, out var fontFamily))
						{
								FontCollection collection = new FontCollection();
								FontFamily family = collection.Add(font.Path);
								_fontFamilies.Add(font.FamilyName, family);
								fontFamily = family;
						}

						var fontToDraw = fontFamily.CreateFont(font.Size);
						var brush = new SolidBrush(ToSharpColor(color));
						var location = ToSharpPoint(position);

						_image.Mutate(ctx => ctx.DrawText(text, fontToDraw, brush, location));
				}

				public IImage GetCurrent()
				{
						return new ImageSharpImage(_image);
				}

				private SixLabors.ImageSharp.Color ToSharpColor(Common.Color c)
								=> SixLabors.ImageSharp.Color.FromRgba(c.R, c.G, c.B, c.A);

				private PointF ToSharpPoint(Vector2 p)
								=> new PointF(p.X, p.Y);
		}
}
