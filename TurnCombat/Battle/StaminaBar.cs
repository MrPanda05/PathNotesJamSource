using Godot;
using System;

namespace TurnCombat.Battle
{
    public partial class StaminaBar : HSlider
    {
        private Label staminaLabel;

        public override void _Ready()
        {
            staminaLabel = GetNode<Label>("Label");
        }
        public void SetValues(int maxValue, int value, string labelText)
        {
            staminaLabel.Text = labelText;
            MaxValue = maxValue;
            Value = value;
        }
    }
}
