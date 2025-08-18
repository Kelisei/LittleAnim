using LittleAnim.Rendering;

namespace LittleAnim.Exporters
{
		/// <summary>
		/// Defines the interface for exporting rendered frames.  
		/// Implementations must support initializing export settings (<see cref="Start"/>),  
		/// adding individual frames (<see cref="AddFrame"/>), and finalizing the export (<see cref="Finish"/>).
		/// </summary>
		interface IExporter
		{
				void Start(string outputPath, uint fps, int width, int height);
				void AddFrame(IImage frame);
				void Finish();
		}
}