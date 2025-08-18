using LittleAnim.Animations;
using LittleAnim.Rendering;
using System.Numerics;

namespace LittleAnim.Drawables
{
		/// <summary>
		/// Base class for objects that can be drawn on a canvas.  
		/// Holds a position and a list of animations, providing methods to update  
		/// animations over time and to draw the object.  
		/// Subclasses must implement <see cref="Draw"/> to define rendering behavior.
		/// </summary>
		abstract class Drawable(Vector2 position)
		{
				public Vector2 Position { get; set; } = position;

				protected List<Animation> Animations { get; set; } = [];
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