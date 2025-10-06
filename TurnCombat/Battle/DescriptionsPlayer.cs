using Godot;
using System;

namespace TurnCombat.Battle
{
    public partial class DescriptionsPlayer : Panel
    {
        private static Label descriptionLabel;
        public override void _Ready()
        {
            descriptionLabel = GetNode<Label>("Label");
        }

        
        public static void SetDescription(string description)
        {
            descriptionLabel.Text = description;
        }
        public static void ClearDescription()
        {
            descriptionLabel.Text = "";
        }
    }
}
