using LittleAnim.Common;
using LittleAnim.Rendering;
using System.Numerics;

namespace LittleAnim.Drawables
{
		class TextDrawable(Vector2 position, Font font, Color color, string text) : Drawable(position)
		{
				public Font Font { get; set; } = font;
				public string Text { get; set; } = text;
				public Color Color { get; set; } = color;

				public override void Draw(ICanvas canvas)
				{
						canvas.DrawText(Text, Position, Font, Color);
				}
		}
}