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
            GameManager.Instance.OnCombatEnter += InitiateBattle;
        }
        public override void _ExitTree()
        {
            GameManager.Instance.OnCombatEnter -= InitiateBattle;
        }
        private void InitiateBattle()
        {
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
