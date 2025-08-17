using System.Numerics;

namespace LittleAnim
{
		abstract class Drawable(Vector2 position)
		{
				public Vector2 Position { get; set; } = position;

				protected List<Animation> Animations { get; set; } = new List<Animation>();
				public void AddAnimation(Animation animation)
				{
						this.Animations.Add(animation);
				}
				public abstract void Draw(ICanvas canvas);
				public void Update(float time)
				{
						foreach (var animation in Animations)
						{
								if (animation.IsActive(time))
								{
										animation.Apply(this, time);
								}
						}
				}
		}
}