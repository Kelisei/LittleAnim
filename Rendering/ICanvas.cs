using LittleAnim.Common;
using System.Drawing;
using System.Numerics;

namespace LittleAnim.Rendering
{
		/// <summary>
		/// Represents a drawable canvas.  
		/// Provides methods for clearing, drawing shapes, text, images, and retrieving the current frame.  
		/// Implementations define how drawing operations are rendered and stored.
		/// </summary>
		interface ICanvas
		{
				public int Width { get; }
				public int Height { get; }
				void Clear(Common.Color background);

				IImage GetCurrent();
				void DrawText(string text, Vector2 position, Common.Font font, Common.Color color);
				void DrawBox(Vector2 position, float width, float height, Common.Color fillColor, Common.Color? strokeColor = null, float strokeWidth = 1.0f);
				void DrawImage(IImage image, Vector2 position, float opacity);
				void DrawLine(Vector2 start, Vector2 end, Common.Color color, float width);
				void DrawCircle(Vector2 center, float radius, Common.Color fillColor, Common.Color? strokeColor = null, float strokeWidth = 1.0f);
		}
}