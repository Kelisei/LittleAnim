namespace LittleAnim
{
		class Engine(uint fps, TimeSpan duration, ICanvas canvas)
		{
				private uint Fps { get; set; } = fps;
				private TimeSpan Duration { get; set; } = duration;
				private List<IImage> Frames { get; set; } = new List<IImage>();
				private List<Drawable> Drawables { get; set; } = new List<Drawable>();
				private ICanvas Canvas { get; set; } = canvas;

				public void Compile()
				{
						long totalFps = (this.Fps * this.Duration.Seconds);
						for (int i = 0; i < totalFps; i++)
						{
								float time = i / (float)this.Fps;
								Canvas.Clear(new Color(255, 255, 255, 255));
								foreach (Drawable drawable in Drawables)
								{
										drawable.Draw(Canvas, time);
								}
								Frames.Add(Canvas.GetCurrent());
						}
				}

				public void AddDrawable(Drawable drawable)
				{
						this.Drawables.Add(drawable);
				}
				public void ToFile(string folderPath)
				{
						Directory.CreateDirectory(folderPath);
						for (int i = 0; i < Frames.Count; i++)
						{
								string filePath = Path.Combine(folderPath, $"frame_{i:D4}.png");
								Frames[i].Save(filePath);
						}
				}
		}
}
