using Commons.Autoloads;
using Godot;
using System;
using Overworld.Char;

namespace Overworld
{
    public partial class OverworldNode : Node2D
    {
        [Export]
        private int _currentWorldNum;
        private const string TestWorld = "res://Overworld/Levels/TestLevel.tscn";
        private Player _player;
        private Node2D _currentWorld;
        public override void _Ready()
        {
            GameManager.Instance.OnGameStateEnter += EnterOverWorld;
            GameManager.Instance.OnGameStateExit += ExitOverWorld;
        }
        private string GetCurrentWorld(int world)
        {
            switch (world)
            {
                case -1: return TestWorld;
                case 0: return "res://Overworld/Levels/Forest.tscn";
                case 1: return "res://Overworld/Levels/Ice.tscn";
                case 2: return "res://Overworld/Levels/Volcano.tscn";
            }
            return "";
        }
        public void EnterOverWorld(GameState gameState)
        {
            if(gameState == GameState.Story)
            {
                Visible = false;
                if (_currentWorld == null) return;
                _currentWorld.QueueFree();
                _currentWorld = null;
                _currentWorldNum++;
            }
            if (gameState != GameState.Overworld) return;
            if (_currentWorld != null) return;
            Visible = true;
            if(_player == null)
            {
                GD.Print("Create player");
                _player = GD.Load<PackedScene>("res://Overworld/Char/PlayerOverworld.tscn").Instantiate<Player>();
                AddChild(_player);
                _player.SwitchState(GameState.Overworld);
                _player.GlobalPosition = new Vector2(334, 352);
            }
            _currentWorld = GD.Load<PackedScene>(GetCurrentWorld(_currentWorldNum)).Instantiate<Node2D>();
            CallDeferred("InstantiateWorld", _currentWorld);
        }
        private void InstantiateWorld(Node2D world)
        {
            AddChild(world);
        }
        public void ExitOverWorld(GameState gameState)
        {
            if(gameState == GameState.Combat)
            {
                Visible = true;
                GD.Print("Do nothing");
            }
            if(gameState == GameState.Overworld)
            {
                GD.Print("Exiting the overworld");
                Visible = false;
                //_player.GlobalPosition = new Vector2(334, 352);
            }
        }
    }
}
