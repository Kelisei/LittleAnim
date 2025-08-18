using LittleAnim.Drawables;
using LittleAnim.Exporters;
using LittleAnim.Rendering;

namespace LittleAnim.Core
{
		/// <summary>
		/// Main rendering and export engine.  
		/// Controls the animation loop by iterating frames according to FPS and duration,  
		/// updating and drawing all registered drawables onto the canvas, and passing  
		/// rendered frames to the configured exporter.  
		/// Use <see cref="AddDrawable"/> to register drawables and <see cref="Export"/>  
		/// to generate the final output.
		/// </summary>
		class Engine(uint fps, TimeSpan duration, ICanvas canvas, IExporter exporter)
		{
				private uint Fps { get; set; } = fps;
				private TimeSpan Duration { get; set; } = duration;
				private List<Drawable> Drawables { get; set; } = [];
				private ICanvas Canvas { get; set; } = canvas;
				private IExporter Exporter { get; set; } = exporter;
				public void Export(string outputPath)
				{
						try
						{
								Exporter.Start(outputPath, Fps, Canvas.Width, Canvas.Height);

								long totalFrames = (long)(Duration.TotalSeconds * Fps);

								for (int i = 0; i < totalFrames; i++)
								{
										float time = i / (float)Fps;
										Canvas.Clear(new Common.Color(255, 255, 255, 255));

										foreach (Drawable drawable in Drawables)
										{
												drawable.Update(time);
												drawable.Draw(Canvas);
										}

										Exporter.AddFrame(Canvas.GetCurrent());
								}
						}
						catch (Exception ex) 
						{
								Console.WriteLine(ex);
						}
						finally
						{
								Exporter.Finish();
						}
    }

				public void AddDrawable(Drawable drawable)
				{
						Drawables.Add(drawable);
				}
		}
}
