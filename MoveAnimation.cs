using System.Numerics;

namespace LittleAnim
{
		internal class MoveAnimation : Animation
		{
				private Vector2 from;
				private Vector2 to;

				public MoveAnimation(float startTime, float duration, Vector2 from, Vector2 to)
								: base(startTime, duration)
				{
						this.from = from;
						this.to = to;
				}

				public override void Apply(Drawable target, float time)
				{
						float progress = (time - StartTime) / Duration;
						progress = Math.Clamp(progress, 0f, 1f);

						target.Position = Vector2.Lerp(from, to, progress);
				}
		}

}
