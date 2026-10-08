using Godot;
using System;

public partial class Frog : EnemyBase
{
	private readonly Vector2 JUMP_VELOCITY = new(100.0f, -150.0f);
	private bool _jump = false;

	public override void _Ready()
	{
		base._Ready();
		_behaviorTimer.OneShot = true;
		_behaviorTimer.WaitTime = GD.RandRange(2.0f, 4.0f);
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity = ApplyGravity(velocity, delta);

		Velocity = velocity;
		ApplyJump();
		MoveAndSlide();
		FlipMe();
		ApplyIdle();
	}

	private void ApplyJump()
	{
		if(IsOnFloor() && _jump)
		{
			_animatedSprite.Play("frog_jump");
			Velocity = _animatedSprite.FlipH ? JUMP_VELOCITY : new Vector2(-JUMP_VELOCITY.X, JUMP_VELOCITY.Y);
			_jump = false;
			_behaviorTimer.Start(GD.RandRange(2.0f, 4.0f));
		}
	}

	private void ApplyIdle()
	{
		if(IsOnFloor())
		{
			_animatedSprite.Play("frog_idle");
			Velocity = Vector2.Zero;
		}
	}

	protected override void OnBehaviorTimerTimeout() => _jump = true;
}
