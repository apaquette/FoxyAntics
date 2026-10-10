using Godot;
using System;

public partial class LevelBase : Node
{
	[Export] private Node bullets;
	[Export] private PackedScene _bulletScene;
	public override void _UnhandledInput(InputEvent @event)
    {
		if (@event.IsActionPressed("quit"))
		{
			GameManager.LoadScene(GameManager.MainScene);
		}
		if (@event.IsActionPressed("test"))
		{	
			SignalHub.EmitOnCreateBullet(new(150,-50), new(1,1), 200.0f, _bulletScene);
		}
    }
}
