using Godot;
using System;

namespace TurnCombat.Battle
{
    /// <summary>
    /// Show the players options, being attack, use item or talk
    /// </summary>
    public partial class PlayerOptions : Panel
    {
        private BattleMec _battleMech;
        [Export]
        private Control PlayerButtons;
        [Export]
        private Control AttackBox, InventoryBox, Talkbox;

        private void SetUpCorrectly()
        {
            Visible = true;
            Talkbox.Visible = false;
            InventoryBox.Visible = false;
            AttackBox.Visible = false;
            PlayerButtons.Visible = false;
        }
        public void OnBattleMecReady()
        {
            _battleMech = GetParent().GetParent<BattleMec>();
            _battleMech.OnUpdate += SetUpCorrectly;
            SetUpCorrectly();
        }
        public void OnAttackButtonDown()
        {
            PlayerButtons.Visible = true;
            Visible = false;
            AttackBox.Visible = true;
        }
        public void OnUseButtonDown()
        {
            PlayerButtons.Visible = true;
            Visible = false;
            InventoryBox.Visible = true;
        }
        public void OnTalkButtonDown()
        {
            PlayerButtons.Visible = true;
            Visible = false;
            Talkbox.Visible = true;
        }
        public override void _PhysicsProcess(double delta)
        {
            if (Input.IsActionJustPressed("Esc") && !Visible)
            {
                SetUpCorrectly();
            }
        }
        public override void _ExitTree()
        {
            _battleMech.OnUpdate -= SetUpCorrectly;

        }
    }
}
