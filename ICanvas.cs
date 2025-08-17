
using System.Drawing;
using System.Numerics;

namespace LittleAnim
{
		interface ICanvas
		{
				int Width { get; }
				int Height { get; }
				void Clear(Color background);

				IImage GetCurrent();
				void DrawText(string text, Vector2 position, Font font, Color color);
				void DrawBox(Vector2 position, float width, float height, Color fillColor, Color? strokeColor = null, float strokeWidth = 1.0f);
				void DrawImage(IImage image, Vector2 position);
				void DrawLine(Vector2 start, Vector2 end, Color color, float width);
				void DrawCircle(Vector2 center, float radius, Color fillColor, Color? strokeColor = null, float strokeWidth = 1.0f);
		}
}