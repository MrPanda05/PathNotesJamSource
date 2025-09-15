using Godot;
using System;
using System.Collections.Generic;

namespace Commons.FiniteStateMachine
{
    [Tool]
    public partial class FSM : Node
    {
        private NodePath _initialString;
        [Export]
        public NodePath InitialState
        {
            get => _initialString;
            set
            {
                _initialString = value;
                UpdateConfigurationWarnings();
            }
        }

        public Dictionary<string, State> States { get; private set; }
        public State CurrentState { get; private set; }

        public Action<string> OnStateChangeTo;

        public override string[] _GetConfigurationWarnings()
        {
            var warnings = new List<string>();

            if (string.IsNullOrEmpty(InitialState))
            {
                warnings.Add("Not initial state set");
            }
            return warnings.ToArray();
        }

        public override void _Ready()
        {
            if (Engine.IsEditorHint()) return;
            if (GetChildCount() == 0)
            {
                GD.PushWarning("No states found in FSM");
                return;
            }
            States = new Dictionary<string, State>();
            foreach (Node node in GetChildren())
            {
                if (node is State s)
                {
                    States[node.Name] = s;
                    s.FiniteStateMachine = this;
                    s.Start();
                }
            }

            if (InitialState == null)
            {
                GD.PushWarning("No initial state set in FSM");
                return;
            }
            CurrentState = GetNode<State>(InitialState);
            CurrentState?.Enter();
        }

        public override void _Process(double delta)
        {
            if (Engine.IsEditorHint()) return;
            CurrentState?.Update((float)delta);
        }
        public override void _PhysicsProcess(double delta)
        {
            if (Engine.IsEditorHint()) return;
            CurrentState?.FixUpdate((float)delta);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            if (Engine.IsEditorHint()) return;
            CurrentState?.HandleInput(@event);
        }
        public void TransitioToState(string key)
        {
            if (!States.ContainsKey(key) || CurrentState == States[key]) return;
            GD.Print("Entering " + key);
            OnStateChangeTo?.Invoke(key);
            CurrentState?.Exit();
            CurrentState = States[key];
            CurrentState.Enter();

        }
        public string GetCurrentStateName()
        {
            return CurrentState.Name;
        }
        public void ForceNullState()
        {
            CurrentState.Exit();
            CurrentState = null;
            OnStateChangeTo?.Invoke("null");
        }
    }
}
