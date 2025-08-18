namespace LittleAnim.Common
{
		public readonly struct Font(string familyName, float size, string path)
		{
				public string FamilyName { get; } = familyName;
				public float Size { get; } = size;
				public string Path { get; } = path;
		}
}