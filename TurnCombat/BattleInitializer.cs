using Commons.Autoloads;
using Godot;
using System;

namespace TurnCombat
{
    public partial class BattleInitializer : Node
    {

        [Export]
        private CanvasLayer _battleUI;
        public override void _Ready()
        {
            GameManager.Instance.OnGameStateEnter += InitiateBattle;
        }
        private void InitiateBattle(GameState gameState)
        {
            if (gameState != GameState.Combat) return;
            BattleStart();
        }
        public void BattleStart()
        {
            GD.Print("BattleStarting");
            _battleUI.Visible = true;
        }
        public void BattleEnd()
        {
            _battleUI.Visible=false;
        }
    }
}
