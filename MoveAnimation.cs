using System.Numerics;

namespace LittleAnim
{
		internal class MoveAnimation : Animation
		{
				private Vector2 _from;
				private Vector2 _to;

				public MoveAnimation(float startTime, float duration, Vector2 from, Vector2 to)
								: base(startTime, duration)
				{
						this._from = from;
						this._to = to;
				}

				public override void Apply(Drawable target, float time)
				{
						float progress = (time - _startTime) / _duration;
						progress = Math.Clamp(progress, 0f, 1f);

						target.Position = Vector2.Lerp(_from, _to, progress);
				}
		}
}
