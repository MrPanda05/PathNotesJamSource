using Godot;
using System;

namespace Commons.Autoloads
{
    public enum GameState
    {
        Story,
        Overworld,
        Combat,
        Paused,
        Other,
        NULL
    };
    public partial class GameManager : Node
    {
        public static GameManager Instance { get; private set; }

        public RandomNumberGenerator RNG { get; private set; } = new RandomNumberGenerator();
        [Export]
        public GameState CurrentState { get; private set; }

        public Action OnStoryEnter;
        public Action OnStoryExit;
        public Action OnOverWorldEnter;
        public Action OnOverWorldExit;
        public Action OnCombatEnter;
        public Action OnCombatExit;
        public Action OnPausedEnter;
        public Action OnPausedExit;
        public Action OnOtherEnter;
        public Action OnOtherExit;
        public Action OnNullEnter;
        public Action OnNullExit;


        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            RNG.Randomize();
        }
        public void ChangeState(GameState newState)
        {
            if (newState == CurrentState) return;

            switch (CurrentState)
            {
                case GameState.Story: OnStoryExit?.Invoke(); break;
                case GameState.Overworld: OnOverWorldExit?.Invoke(); break;
                case GameState.Combat: OnCombatExit?.Invoke(); break;
                case GameState.Paused: OnPausedExit?.Invoke(); break;
                case GameState.Other: OnOtherExit?.Invoke(); break;
                case GameState.NULL: OnNullExit?.Invoke(); break;
            }

            CurrentState = newState;

            // Fire enter event for new state
            switch (CurrentState)
            {
                case GameState.Story: OnStoryEnter?.Invoke(); break;
                case GameState.Overworld: OnOverWorldEnter?.Invoke(); break;
                case GameState.Combat: OnCombatEnter?.Invoke(); break;
                case GameState.Paused: OnPausedEnter?.Invoke(); break;
                case GameState.Other: OnOtherEnter?.Invoke(); break;
                case GameState.NULL: OnNullEnter?.Invoke(); break;
            }

        }
    }
}
