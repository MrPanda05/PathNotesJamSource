using Godot;
using System;

namespace TurnCombat.Battle
{
    public partial class TextDesct : Label
    {
        private BattleMec _battlemMec;
        public void OnBattleMecReady()
        {
            _battlemMec = GetParent<BattleMec>();
            _battlemMec.UpdateText += UpdateText;
        }
        public void UpdateText(string text)
        {
            Text = text;
        }
        public override void _ExitTree()
        {
            _battlemMec.UpdateText -= UpdateText;
        }
    }
}
