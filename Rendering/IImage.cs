namespace LittleAnim.Rendering
{
		/// <summary>
		/// Represents an image that can be saved to disk.  
		/// The generic <see cref="IImage{T}"/> allows access to the underlying image type.
		/// </summary>
		interface IImage
		{
				void Save(string path);
	
		}
		/// <summary>
		/// Represents an image that can be saved to disk.  
		/// The generic <see cref="IImage{T}"/> allows access to the underlying image type.
		/// </summary>
		interface IImage<T> : IImage
		{
				T GetImage();
		}
}