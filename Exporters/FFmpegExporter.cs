using FFMpegCore;
using FFMpegCore.Enums;
using LittleAnim.Rendering;
namespace LittleAnim.Exporters
{
		/// <summary>
		/// Exports a sequence of images to a video file using FFmpeg.  
		/// Manages temporary storage of frames, adds frames via <see cref="AddFrame"/>,  
		/// and compiles them into a video with <see cref="Finish"/>.  
		/// Use <see cref="Start"/> to initialize export settings like output path and FPS.
		/// </summary>
		class FFmpegExporter : IExporter
		{
				private string _tempPath;
				private string _fileName;
				private string _outputPath;
				private uint _fps;
				private int _frameCounter;
				private readonly List<string> _framePaths = [];

				public void Start(string outputPath, uint fps, int width, int height)
				{
						_outputPath = outputPath;
						_fps = fps;
						_frameCounter = 0;
						_tempPath = Path.Combine(Path.GetTempPath(), "littleanim_" + Path.GetRandomFileName());
						Directory.CreateDirectory(_tempPath);
				}

				public void AddFrame(IImage frame)
				{
						string framePath = Path.Combine(_tempPath, $"frame_{_frameCounter:D5}.png");
						frame.Save(framePath);
						_framePaths.Add(framePath);
						_frameCounter++;
				}

				public void Finish()
				{
						{
								try
								{
										var pattern = Path.Combine(_tempPath, "frame_%05d.png");
										bool ok = FFMpegArguments
												.FromFileInput(pattern, verifyExists: false, opt => opt
																.WithFramerate(_fps)
																.ForceFormat("image2"))
												.OutputToFile(_outputPath, overwrite: true, opt => opt
																.WithVideoCodec(VideoCodec.LibX264)
																.ForcePixelFormat("yuv420p")
																.WithFramerate(_fps))
												.ProcessSynchronously();
										if (!ok)
										{
												throw new Exception("Couldn't process image sequence");
										}
								}
								catch (Exception ex)
								{
										throw new Exception("Something happened while compiling the video", ex);
								}
								finally
								{
										if (Directory.Exists(_tempPath))
										{
												Directory.Delete(_tempPath, true);
										}
								}
						}
				}
		}
}
