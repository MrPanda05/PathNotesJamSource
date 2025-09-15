using Commons.Autoloads;
using Godot;
using System;
using TurnCombat.Char;
using TurnCombat.Enemies;

namespace TurnCombat.Battle
{
    /// <summary>
    /// This is the UI of the turn based combat
    /// This is not the best way to do it, as it is just creating and recreating the scene... but it is the only way I can think on how to chance what happens when the battle ends....
    /// </summary>
    public partial class BattleMec : CanvasLayer
    {
        public EnemySource EnemySource;
        public PlayerSource PlayerSource;
        public bool CurrentTurn = true; //false - enemy | true - player;
        public bool IsBattleOver { get; protected set; }

        [Export]
        public Sprite2D PlayerSprite, EnemySprite;

        [Export]
        protected Label turnLabel;
        [Export]
        protected Panel playerOptions;

        [Export]
        protected Timer EnemyTimer;

        public Action OnUpdate;
        public Action<string> UpdateText;

        [Export]
        public AudioStream playerWinSFX;

        [Export]
        public GameState StateToGo = GameState.Overworld;

        public virtual void BattleEnter()
        {
            GameManager.Instance.ChangeState(GameState.Combat);
            if (CurrentTurn)
            {
                turnLabel.Text = "Your turn";
                playerOptions.Visible = true;
            }
            else
            {
                turnLabel.Text = "Enemy turn";
                playerOptions.Visible = false;
            }
            PlayerSource.OnDeath += HandlePlayerDeath;
            EnemySource.OnDeath += HandleEnemyDeath;
            PlayerSprite.Texture = PlayerSource.PlayerTexture;
            EnemySprite.Texture = EnemySource.EnemyTexture;
            IsBattleOver = false;
        }
        public virtual void BattleExit()
        {
            PlayerSprite.Texture = null;
            EnemySprite.Texture = null;
            PlayerSource.Inventory.InventorySlots[0].Amount++;
            PlayerSource.Inventory.InventorySlots[1].Amount++;
            PlayerSource.Inventory.InventorySlots[2].Amount++;
            PlayerSource.Inventory.InventorySlots[3].Amount++;
            PlayerSource.OnDeath -= HandlePlayerDeath;
            EnemySource.OnDeath -= HandleEnemyDeath;
            GameManager.Instance.ChangeState(StateToGo);
            CombatManager.Instance.BattleEnd();
        }
        protected virtual void HandlePlayerDeath()
        {
            IsBattleOver = true;
            GD.Print("Enemy wins");
            GetTree().Quit();
            BattleExit();
        }
        protected virtual void HandleEnemyDeath()
        {
            IsBattleOver = true;
            GD.Print("Player wins");
            PlayerSource.AddStamina(GameManager.Instance.RNG.RandiRange(5, 35));
            AudioPlayerGlobal.Instance.PlaySound(playerWinSFX, audioBus: "SFX");
            BattleExit();
        }
        public void NextTurn()
        {
            OnUpdate?.Invoke();
            if (IsBattleOver) return;
            if (EnemySource.Health <= 0)
            {
                BattleExit();
                GD.Print("Player Wins");
                return;
            }
            if(PlayerSource.Health <= 0)
            {
                BattleExit();
                GD.Print("Enemy Wins");
                return;
            }
            if (CurrentTurn)
            {
                turnLabel.Text = "Enemy turn";
                EnemysTurn();
            }
            else
            {
                turnLabel.Text = "Your turn";
                PlayersTurn();
            }
        }
        protected void PlayersTurn()
        {
            CurrentTurn = true;
            playerOptions.Visible = true;
        }
        protected void EnemysTurn()
        {
            CurrentTurn = false;
            playerOptions.Visible = false;
            EnemyTimer.Start();
        }
        public void OnEnemyTimerTimeout()
        {
            GD.Print("Enemy thinking.....");
            UpdateText?.Invoke($"Enemy attacked you with {EnemySource.Attacks[0].AttackName}");
            PlayerSource.DecreaseHealth(GameManager.Instance.RNG.RandiRange(5, 30));
            NextTurn();
        }
        //public void OnAttackButtonDown()
        //{
        //    EnemySource.Health -= 10;
        //    UpdateHealth();
        //    NextTurn();
        //}
        public override void _PhysicsProcess(double delta)
        {
            if (Input.IsActionJustPressed("Cancel"))
            {
                BattleExit();
            }
        }
    }
}
