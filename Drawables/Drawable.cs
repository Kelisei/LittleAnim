using LittleAnim.Animations;
using LittleAnim.Rendering;
using System.Numerics;

namespace LittleAnim.Drawables
{
		abstract class Drawable(Vector2 position)
		{
				public Vector2 Position { get; set; } = position;

				protected List<Animation> Animations { get; set; } = new List<Animation>();
				public void AddAnimation(Animation animation)
				{
						Animations.Add(animation);
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