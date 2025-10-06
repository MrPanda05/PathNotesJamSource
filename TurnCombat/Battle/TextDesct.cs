using Godot;
using System;

namespace TurnCombat.Battle
{
    /// <summary>
    /// Set the description of what happpens in battle
    /// </summary>
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
            Visible = true;
            Text = text;
        }
        public override void _ExitTree()
        {
            _battlemMec.UpdateText -= UpdateText;
        }
    }
}
