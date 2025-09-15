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
            GameManager.Instance.OnGameStateEnter += SwitchState;
        }
        public void SwitchState(GameState state)
        {
            if(state == GameState.Combat)
            {
                _finiteStateMachine.TransitioToState("Battle");
                return;
            }
            if(state == GameState.Overworld)
            {
                _finiteStateMachine.TransitioToState("Playing");
                return;
            }
            if(state == GameState.Story)
            {
                _finiteStateMachine.ForceNullState();
                return;
            }
        }

        public override void _ExitTree()
        {
            GameManager.Instance.OnGameStateEnter -= SwitchState;
        }
    }
}
