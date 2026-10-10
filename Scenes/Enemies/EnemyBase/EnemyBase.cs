using Godot;
using System;

public partial class EnemyBase : CharacterBody2D
{
	[Export] private VisibleOnScreenNotifier2D _screenNotifier;
	[Export] protected AnimatedSprite2D _animatedSprite;
	[Export] private HitBox _hitBox;
	[Export] protected float _speed = 30.0f;
	[Export] protected float _fallenOffY = 200.0f;
	[Export] protected Timer _behaviorTimer;

	protected float _gravity = 800.0f;
	protected Player _player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetTree().GetFirstNodeInGroup(GameConstants.GROUP_PLAYER) as Player;
		if(_player == null)
		{
			GD.PrintErr("Player not found in scene tree");
			QueueFree();
		}
		_screenNotifier.ScreenEntered += OnScreenEntered;
		_behaviorTimer.Timeout += OnBehaviorTimerTimeout;
	}

    

    protected virtual void OnScreenEntered()
    {
		_behaviorTimer.Start();
		_screenNotifier.ScreenEntered -= OnScreenEntered;
    }

    public override void _Process(double delta)
    {
        FallenOff();
    }

	private void FallenOff()
	{
		if(GlobalPosition.Y > _fallenOffY)
		{
			CallDeferred(MethodName.QueueFree);
		}
	}

	protected Vector2 ApplyGravity(Vector2 velocity,double delta)
	{
		velocity.Y += _gravity * (float)delta;
		return velocity;
	}

	protected virtual void FlipMe()
	{
		_animatedSprite.FlipH = _player.GlobalPosition.X > GlobalPosition.X;
	}
	protected virtual void OnBehaviorTimerTimeout() { }
}
