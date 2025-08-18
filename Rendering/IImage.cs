namespace LittleAnim.Rendering
{
		interface IImage
		{
				void Save(string path);
	
		}
		interface IImage<T> : IImage
		{
				T GetImage();
		}
}