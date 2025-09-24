using Commons.Autoloads;
using Commons.FiniteStateMachine;
using Godot;
using System;
using TurnCombat.Char;

namespace Overworld.Char
{
    public partial class Player : CharacterBody2D
    {
        [Export]
        public float Speed { get; set; }
        [Export]
        public PlayerSource Stats { get; set; }


        private FSM _finiteStateMachine;
        private Vector2 _vel;

        public void Movement()
        {
            var inputVector = new Vector2(Input.GetAxis("Left", "Right"), Input.GetAxis("Up", "Down")).Normalized();
            _vel = Velocity;
            _vel = inputVector * Speed;
            Velocity = _vel;
            MoveAndSlide();
        }


        public override void _Ready()
        {
            _finiteStateMachine = GetNode<FSM>("FSM");
            GameManager.Instance.OnCombatEnter += EnterBattle;
            GameManager.Instance.OnOverWorldEnter += EnterOverWorld;
            GameManager.Instance.OnStoryEnter += EnterStory;

        }
        
        private void EnterBattle()
        {
            _finiteStateMachine.TransitioToState("Battle");
        }
        private void EnterOverWorld()
        {
            _finiteStateMachine.TransitioToState("Playing");
        }
        private void EnterStory()
        {
            _finiteStateMachine.ForceNullState();
        }
        public override void _ExitTree()
        {
            GameManager.Instance.OnCombatEnter -= EnterBattle;
            GameManager.Instance.OnOverWorldEnter -= EnterOverWorld;
            GameManager.Instance.OnStoryEnter -= EnterStory;
        }
    }
}
