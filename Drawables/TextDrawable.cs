using LittleAnim.Common;
using LittleAnim.Rendering;
using System.Numerics;

namespace LittleAnim.Drawables
{
		/// <summary>
		/// Drawable that renders a text string on a canvas.  
		/// Stores text content, font, and color, and draws itself at its current position.  
		/// Inherits animation capabilities from <see cref="Drawable"/>.
		/// </summary>
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