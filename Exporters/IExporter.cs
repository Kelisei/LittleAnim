using LittleAnim.Rendering;

namespace LittleAnim.Exporters
{
	 interface IExporter
		{
				void Start(string outputPath, uint fps, int width, int height);
				void AddFrame(IImage frame);
				void Finish();
		}
}