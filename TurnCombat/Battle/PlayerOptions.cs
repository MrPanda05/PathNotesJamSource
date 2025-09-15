using Godot;
using System;

namespace TurnCombat.Battle
{
    public partial class PlayerOptions : Panel
    {
        private BattleMec _battleMech;
        [Export]
        private Control OptionBox;
        [Export]
        private Control AttackBox, InventoryBox, Talkbox;

        private void SetUpCorrectly()
        {
            OptionBox.Visible = true;
            Talkbox.Visible = false;
            InventoryBox.Visible = false;
            AttackBox.Visible = false;
        }
        public void OnBattleMecReady()
        {
            _battleMech = GetParent().GetParent<BattleMec>();
            _battleMech.OnUpdate += SetUpCorrectly;
        }
        public void OnAttackButtonDown()
        {
            OptionBox.Visible = false;
            AttackBox.Visible = true;
        }
        public void OnUseButtonDown()
        {
            OptionBox.Visible = false;
            InventoryBox.Visible = true;
        }
        public void OnTalkButtonDown()
        {
            OptionBox.Visible = false;
            Talkbox.Visible = true;
        }
        public override void _PhysicsProcess(double delta)
        {
            if (Input.IsActionJustPressed("Esc") && !OptionBox.Visible)
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
