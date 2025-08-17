namespace LittleAnim
{
		class Engine(uint fps, TimeSpan duration, ICanvas canvas, IExporter exporter)
		{
				private uint _fps { get; set; } = fps;
				private TimeSpan _duration { get; set; } = duration;
				private List<Drawable> _drawables { get; set; } = new List<Drawable>();
				private ICanvas _canvas { get; set; } = canvas;
				private IExporter _exporter { get; set; } = exporter;
				public void Export(string outputPath)
				{
						try
						{
								_exporter.Start(outputPath, _fps, _canvas.Width, _canvas.Height);

								long totalFrames = (long)(_duration.TotalSeconds * _fps);

								for (int i = 0; i < totalFrames; i++)
								{
										float time = i / (float)_fps;
										_canvas.Clear(new Color(255, 255, 255, 255));

										foreach (Drawable drawable in _drawables)
										{
												drawable.Update(time);
												drawable.Draw(_canvas);
										}

										_exporter.AddFrame(_canvas.GetCurrent());
								}
						}
						catch (Exception ex) 
						{
								Console.WriteLine(ex);
						}
						finally
						{
								_exporter.Finish();
						}
    }

				public void AddDrawable(Drawable drawable)
				{
						this._drawables.Add(drawable);
				}
		}
}
