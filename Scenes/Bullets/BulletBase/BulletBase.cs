using Godot;
using System;

public partial class BulletBase : Area2D
{
	private float _despawn = 5000.0f;
	private Vector2 _direction = Vector2.Right;

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
	{
		Position += _direction * (float)delta;
	}

	public void Setup(Vector2 pos, Vector2 dir, float speed)
	{
		GlobalPosition = pos;
		_direction = dir * speed;
	}
}
