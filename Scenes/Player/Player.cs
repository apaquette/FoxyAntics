using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float GRAVITY = 690.0f, RUN_SPEED = 120.0f, JUMP_SPEED = -270.0f, MAX_FALL = 300.0f;
	private bool _jumped = false;
	[Export] private AudioStreamPlayer2D _jumpSound;
	[Export] private Sprite2D _sprite;

    public override void _UnhandledInput(InputEvent @event)
    {
		if (@event.IsActionPressed("jump"))
			_jumped = true;
    }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity = GetGravity(velocity, delta);
		Velocity = GetInput(velocity);
		velocity.Y = Mathf.Clamp(velocity.Y, JUMP_SPEED, MAX_FALL);
		MoveAndSlide();
	}

	private static Vector2 GetGravity(Vector2 velocity, double delta)
	{
		velocity.Y += GRAVITY * (float)delta;
		return velocity;
	}

	private Vector2 GetInput(Vector2 velocity)
	{
		velocity.X = Input.GetAxis("left", "right") * RUN_SPEED;

		if (IsOnFloor() && _jumped)
		{
			_jumped = false;
			velocity.Y = JUMP_SPEED;
			_jumpSound.Play();
		}

		if (!Mathf.IsZeroApprox(velocity.X))
		{
			_sprite.FlipH = velocity.X < 0;
		}

		return velocity;
	}
}
