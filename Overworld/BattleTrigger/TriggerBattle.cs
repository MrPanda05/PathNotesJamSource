using Commons.Autoloads;
using Godot;
using Overworld.Char;
using System;
using TurnCombat;
using TurnCombat.Enemies;

namespace Overworld.BattleTrigger
{
    public partial class TriggerBattle : Area2D
    {
        [Export]
        public EnemySource Enemy { get; set; }
        [Export]
        public PackedScene BattleUI { get; set; }
        [Export]
        public GameState StateToGo = GameState.Overworld;
        [Export]
        public bool ResetPos = false;
        [Export]
        public AudioStream encounterSfx;
        public void OnBodyEntered(Player player)
        {
            if (GameManager.Instance.CurrentState == GameState.Combat) return;
            CombatManager.Instance.InitiateBattle(player.Stats, Enemy, BattleUI, StateToGo);
            AudioPlayerGlobal.Instance.PlaySound(encounterSfx, audioBus:"SFX");
            GD.Print("Player enter, trigering battle");
            if (ResetPos)
            {
                player.GlobalPosition = new Vector2(334, 352);
            }
        }

        public void OnBodyExited(Player player)
        {
            GD.Print("Player exit");
            CallDeferred("Destroy");
        }
        private void Destroy()
        {
            QueueFree();
        }
    }
}
