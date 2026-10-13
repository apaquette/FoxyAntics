using Godot;
using System;

public partial class Shooter : Node2D
{
	[Export] private PackedScene _bulletScene;
	[Export] private float _speed = 50.0f, _shootDelay = 0.7f;
	[Export] private AudioStreamPlayer2D _sound;
	[Export] private Timer _timer;
	private bool _canShoot = true;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer.Timeout += () => _canShoot = true;
		_timer.WaitTime = _shootDelay;
	}

	public void Shoot(Vector2 direction)
	{
		if (!_canShoot) return;
		_canShoot = false;

		SignalHub.EmitOnCreateBullet(GlobalPosition, direction, _speed, _bulletScene);
		_sound.Play();
	}
}
