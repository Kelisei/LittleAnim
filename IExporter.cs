namespace LittleAnim
{
	 interface IExporter
		{
				void Start(string outputPath, uint fps, int width, int height);
				void AddFrame(IImage frame);
				void Finish();
		}
}