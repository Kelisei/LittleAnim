namespace LittleAnim.Common
{
		/// <summary>
		/// Represents a font resource with family name, size, and file path.  
		/// Immutable struct intended for defining text rendering properties.
		/// </summary>
		public readonly struct Font(string familyName, float size, string path)
		{
				public string FamilyName { get; } = familyName;
				public float Size { get; } = size;
				public string Path { get; } = path;
		}
}