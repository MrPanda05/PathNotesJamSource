using Commons.Autoloads;
using Godot;
using System;
using TurnCombat.Battle;
using TurnCombat.Char;
using TurnCombat.Enemies;

namespace TurnCombat
{
    public partial class CombatManager : Node
    {
        public static CombatManager Instance { get; private set; }
        private BattleMec _battleUI;
        public bool IsInBattle {  get; private set; }

        public Action OnBattleStart;
        public Action OnBattleEnd;
        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }

        public void InitiateBattle(PlayerSource player, EnemySource enemy, PackedScene battleMec, GameState StateToChange)
        {
            GameManager.Instance.ChangeState(GameState.Combat);
            GD.Print($"{player.PlayerName} is fighting {enemy.EnemyName}");
            var newBattle = battleMec.Instantiate<BattleMec>();
            _battleUI = newBattle;
            _battleUI.EnemySource = enemy;
            _battleUI.PlayerSource = player;
            _battleUI.StateToGo = StateToChange;
            AddChild(newBattle);
            BattleStart();
        }
        public void BattleStart()
        {
            GD.Print("BattleStarting");
            _battleUI.Visible = true;
            _battleUI.BattleEnter();
            IsInBattle = true;
            OnBattleStart?.Invoke();
        }
        public void BattleEnd()
        {
            _battleUI.Visible = false;
            _battleUI.QueueFree();
            _battleUI = null;
            IsInBattle = false;
            OnBattleEnd?.Invoke();
        }
       
    }
}
