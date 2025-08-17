using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace LittleAnim
{
		class ImageSharpImage : IImage<Image<Rgba32>>
		{
				private readonly Image<Rgba32> _image;
				public ImageSharpImage(Image<Rgba32> image)
				{
						_image = image.Clone();
				}

				public Image<Rgba32> GetImage()
				{
						return _image;
				}
				public void Save(string path)
				{
						_image.SaveAsPng(path);
				}
		}
}
