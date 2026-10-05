using Godot;
using System;
public partial class Snail : EnemyBase
{
	[Export] private RayCast2D _floorDetect;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity = ApplyGravity(velocity, delta);
		velocity = DetermineDirection(velocity, delta);

		Velocity = velocity;
		MoveAndSlide();
		FlipMe();
	}

	private Vector2 ApplyGravity(Vector2 velocity,double delta)
	{
		velocity.Y += _gravity * (float)delta;
		return velocity;
	}

	private Vector2 DetermineDirection(Vector2 velocity,double delta)
	{
		if (IsOnFloor())
		{
			velocity.X = _animatedSprite.FlipH ? _speed : -_speed;
		}
		return velocity;
	}

	private void FlipMe()
	{
		if(!_floorDetect.IsColliding() || IsOnWall())
		{
			_animatedSprite.FlipH = !_animatedSprite.FlipH;
			_floorDetect.Position = new Vector2(_floorDetect.Position.X * -1, _floorDetect.Position.Y);
		}
	}
}
