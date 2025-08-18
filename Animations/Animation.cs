using LittleAnim.Drawables;

namespace LittleAnim.Animations
{
		abstract class Animation
		{
				protected float _startTime { get; set; }
				protected float _duration { get; set;  }

				protected Animation(float startTime, float duration)
				{
						_startTime = startTime;
						_duration = duration;
				}

				public bool IsActive(float t) => t >= _startTime && t <= _startTime + _duration;

				public abstract void Apply(Drawable target, float time);
		}

}