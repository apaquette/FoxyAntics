using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }
	public static PackedScene MainScene {get; private set;} = GD.Load<PackedScene>("res://Scenes/Main/Main.tscn");
	public static PackedScene LevelScene {get; private set;} = GD.Load<PackedScene>("res://Scenes/LevelBase/LevelBase.tscn");
	
	public override void _Ready()
	{
		Instance = this;
	}

	public static void LoadScene(PackedScene scene) => Instance.GetTree().ChangeSceneToPacked(scene);
}
