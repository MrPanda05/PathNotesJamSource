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
        public GameState State { get; private set; }

        public Action<GameState> OnGameStateEnter;//Sends the new state
        public Action<GameState> OnGameStateExit;//Sends the old state
        public Action OnGameStateUpdate;


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
            if (State.Equals(newState)) return;
            OnGameStateExit?.Invoke(State);
            State = newState;
            OnGameStateEnter?.Invoke(newState);
            GD.Print("Entering Gamestate: " + newState);
            OnGameStateUpdate?.Invoke();
        }
    }
}
