using LittleAnim.Drawables;

namespace LittleAnim.Animations
{
		/// <summary>
		/// Base class for animations applied to drawables.  
		/// Defines a start time and duration, and provides a method to check  
		/// if the animation is active at a given time.  
		/// Subclasses must implement <see cref="Apply"/> to modify the target drawable.
		/// </summary>
		abstract class Animation(float startTime, float duration)
		{
				protected float StartTime { get; set; } = startTime;
				protected float Duration { get; set; } = duration;

				public bool IsActive(float t) => t >= StartTime && t <= StartTime + Duration;

				public abstract void Apply(Drawable target, float time);
		}

}