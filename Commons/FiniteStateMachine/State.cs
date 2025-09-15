using Godot;
using System;

namespace Commons.FiniteStateMachine
{
    /// <summary>
    /// State is a base class for creating states in a finite state machine (FSM).
    /// </summary>
    public partial class State : Node
    {
        /// <summary>
        /// The FSM that owns this state.
        /// </summary>
        public FSM FiniteStateMachine;
        /// <summary>
        /// Called when the state is added to the scene tree. Used for initialization. Like chaching and things that should be done only once.
        /// </summary>
        public virtual void Start() { }
        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        public virtual void Enter() { }
        /// <summary>
        /// Called when the state is exited.
        /// </summary>
        public virtual void Exit() { }
        /// <summary>
        /// Called every framed by the FSM's _Process method.
        /// </summary>
        /// <param name="delta"></param>
        public virtual void Update(float delta) { }
        /// <summary>
        /// Called every physics frame by the FSM's _PhysicsProcess method.
        /// </summary>
        /// <param name="delta"></param>
        public virtual void FixUpdate(float delta) { }
        /// <summary>
        /// Called by the FSM's _UnhandledInput method when an input event is not handled.
        /// </summary>
        /// <param name="event"></param>
        public virtual void HandleInput(InputEvent @event) { }
    }
}
