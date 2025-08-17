namespace LittleAnim
{
		internal class Program
		{
				static void Main(string[] args)
				{
						ICanvas canvas = new ImageSharpCanvas(800, 800);
						Engine engine = new Engine(30, TimeSpan.FromSeconds(1), canvas);
						Drawable drawable = new TextDrawable(
								new System.Numerics.Vector2(0, 0),
								new Font("Arial", 20, "C:/WINDOWS/FONTS/ARIAL.TTF"),
								new Color(0, 0, 0, 255),
								"Hello, World!"
								);
						Animation moveText = new MoveAnimation(
							0,
							1,
							new System.Numerics.Vector2(0, 0),
							new System.Numerics.Vector2(400, 400)
							);
						drawable.AddAnimation( moveText );
						engine.AddDrawable(drawable);
						engine.Compile();
						engine.ToFile("C:\\Users\\frank\\OneDrive\\Desktop\\New folder");
				}
		}
}
