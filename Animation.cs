namespace LittleAnim
{
		abstract class Animation
		{
				public float StartTime { get; }
				public float Duration { get; }

				protected Animation(float startTime, float duration)
				{
						StartTime = startTime;
						Duration = duration;
				}

				public bool IsActive(float t) => t >= StartTime && t <= StartTime + Duration;

				public abstract void Apply(Drawable target, float time);
		}

}