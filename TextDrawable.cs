using System.Numerics;

namespace LittleAnim
{
		internal class TextDrawable : Drawable
		{
				public Font Font { get; set; }
				public string Text { get; set; }
				public Color Color { get; set; }
				public TextDrawable(Vector2 position, Font font, Color color, string text) : base(position)
				{
						Font = font;
						Color = color;
						Text = text;
				}

				public override void Draw(ICanvas canvas, float time)
				{
						foreach (var animation in Animations)
						{
								if (animation.IsActive(time))
								{
										animation.Apply(this, time);
								}
						}
						canvas.DrawText(Text, Position, Font, Color);
				}
		}
}