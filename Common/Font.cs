namespace LittleAnim.Common
{
		public struct Font
		{
				public string FamilyName { get; }
				public float Size { get; }
				public string Path { get; }
				public Font(string familyName, float size, string path)
				{
						FamilyName = familyName;
						Size = size;
						Path = path;
				}
		}
}