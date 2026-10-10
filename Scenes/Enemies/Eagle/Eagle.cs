using Godot;
using System;

public partial class Eagle : EnemyBase
{
	private readonly Vector2 FLY_SPEED = new(35.0f, 15.0f);
	private Vector2 _flyDirection = Vector2.Zero;
    protected override void OnScreenEntered()
    {
        base.OnScreenEntered();
		_animatedSprite.Play("eagle");
		FlyToPlayer();
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = _flyDirection;
		MoveAndSlide();
    }

	private void FlyToPlayer()
	{
		FlipMe();
		_flyDirection = _animatedSprite.FlipH? FLY_SPEED :  new Vector2(-FLY_SPEED.X, FLY_SPEED.Y);
	}

    protected override void OnBehaviorTimerTimeout()
    {
        FlyToPlayer();
    }
}
