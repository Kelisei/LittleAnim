using LittleAnim.Drawables;

namespace LittleAnim.Animations
{
		abstract class Animation(float startTime, float duration)
		{
				protected float StartTime { get; set; } = startTime;
				protected float Duration { get; set; } = duration;

				public bool IsActive(float t) => t >= StartTime && t <= StartTime + Duration;

				public abstract void Apply(Drawable target, float time);
		}

}