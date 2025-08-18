using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace LittleAnim.Rendering
{
		/// <summary>
		/// Wraps a SixLabors.ImageSharp <see cref="Image{Rgba32}"/> as an <see cref="IImage{T}"/>.  
		/// Provides access to the underlying image and allows saving it to disk as PNG.
		/// </summary>
		class ImageSharpImage(Image<Rgba32> image) : IImage<Image<Rgba32>>
		{
				private readonly Image<Rgba32> _image = image.Clone();

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
