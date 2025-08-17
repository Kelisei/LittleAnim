using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleAnim
{
		class ImageSharpImage : IImage
		{
				private readonly Image Image;
				public ImageSharpImage(Image image)
				{
						Image = image.Clone(ctx => { });
				}

				public void Save(string path)
				{
						Image.SaveAsPng(path);
				}
		}
}
