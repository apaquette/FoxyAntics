using Godot;
using System;

public partial class LifeTime : Node
{
	[Export] private Timer _timer;
	[Export] private float _waitTime = 30.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer.Start(_waitTime);
		_timer.Timeout += OneTimeout;
	}

    private void OneTimeout()
    {
        GetParent().QueueFree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
