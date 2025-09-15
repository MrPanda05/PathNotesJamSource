using Godot;
using System;
using Commons.FiniteStateMachine;

namespace Overworld.Char.States
{
    public partial class Playing : State
    {
        [Export]
        private Player _player;

        public override void FixUpdate(float delta)
        {
            _player.Movement();
        }
    }
}
