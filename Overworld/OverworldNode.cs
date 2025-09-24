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
            GameManager.Instance.OnOverWorldEnter += EnterOverWorld;
            GameManager.Instance.OnOverWorldExit += ExitOverWorld;
            GameManager.Instance.OnStoryEnter += EnterStory;
            GameManager.Instance.OnCombatExit += ExitCombat;
        }
        public override void _ExitTree()
        {
            GameManager.Instance.OnOverWorldEnter -= EnterOverWorld;
            GameManager.Instance.OnOverWorldExit -= ExitOverWorld;
            GameManager.Instance.OnStoryEnter -= EnterStory;
            GameManager.Instance.OnCombatExit -= ExitCombat;
        }
        private string GetCurrentWorld(int world)
        {
            //Here to add here new level to add more spice if needeed
            switch (world)
            {
                case -1: return TestWorld;
                case 0: return "res://Overworld/Levels/Forest.tscn";
                case 1: return "res://Overworld/Levels/Ice.tscn";
                case 2: return "res://Overworld/Levels/Volcano.tscn";
            }
            return "";
        }
        private void EnterStory()
        {
            Visible = false;
            if (_currentWorld == null) return;
            _currentWorld.QueueFree();
            _currentWorld = null;
            _currentWorldNum++;
        }
        public void EnterOverWorld()
        {
    
            if (_currentWorld != null) return;
            Visible = true;
            if(_player == null)
            {
                GD.Print("Create player");
                _player = GD.Load<PackedScene>("res://Overworld/Char/PlayerOverworld.tscn").Instantiate<Player>();
                AddChild(_player);
                _player.GlobalPosition = new Vector2(334, 352);
            }
            _currentWorld = GD.Load<PackedScene>(GetCurrentWorld(_currentWorldNum)).Instantiate<Node2D>();
            CallDeferred("InstantiateWorld", _currentWorld);
        }
        private void InstantiateWorld(Node2D world) 
        {
            AddChild(world);
        }

        private void ExitCombat()
        {
            Visible = true;
            GD.Print("Do nothing");
        }
        public void ExitOverWorld()
        {
            GD.Print("Exiting the overworld");
            Visible = false;
        }
    }
}
