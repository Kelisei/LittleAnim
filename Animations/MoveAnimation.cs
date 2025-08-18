using LittleAnim.Drawables;
using System.Numerics;

namespace LittleAnim.Animations
{
		class MoveAnimation(float startTime, float duration, Vector2 from, Vector2 to) : Animation(startTime, duration)
		{
				private Vector2 _from = from;
				private Vector2 _to = to;

				public override void Apply(Drawable target, float time)
				{
						float progress = (time - StartTime) / Duration;
						progress = Math.Clamp(progress, 0f, 1f);

						target.Position = Vector2.Lerp(_from, _to, progress);
				}
		}
}
