using Godot;
using System;

public partial class ObjectMaker : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalHub.Instance.Connect(SignalHub.SignalName.OnCreateBullet, Callable.From<Vector2, Vector2, float, PackedScene>(OnCreateBullet));
	}

    private void OnCreateBullet(Vector2 pos, Vector2 dir, float speed, PackedScene scene)
    {
        BulletBase bullet = scene.Instantiate<BulletBase>();
		bullet.Setup(pos, dir, speed);
		CallDeferred(MethodName.AddChild, bullet);
    }
}
