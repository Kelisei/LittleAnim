using LittleAnim.Drawables;
using System.Numerics;

namespace LittleAnim.Animations
{
		/// <summary>
		/// Animates a drawable's position from a starting point to an endpoint over time.  
		/// Inherits from <see cref="Animation"/> and interpolates the target's position  
		/// based on the current time relative to the animation's start and duration.
		/// </summary>
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
