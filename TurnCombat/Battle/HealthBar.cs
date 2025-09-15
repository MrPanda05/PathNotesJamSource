using Godot;
using System;

namespace TurnCombat.Battle
{
    public partial class HealthBar : HSlider
    {
        private Label healthLabel;

        public override void _Ready()
        {
            healthLabel = GetNode<Label>("Label");
        }
        public void SetValues(int maxValue, int value, string labelText)
        {
            healthLabel.Text = labelText;
            MaxValue = maxValue;
            if (value > MaxValue)
            {
                Value = MaxValue;
            }
            else
            {
                Value = value;
            }
        }
    }
}
