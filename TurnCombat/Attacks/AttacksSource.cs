using Godot;
using System;

namespace TurnCombat.Attacks
{
    [GlobalClass]
    public partial class AttacksSource : Resource
    {
        [Export]
        public string AttackName { get; set; } = "Gay";
        [Export]
        public string Description { get; set; } = "does damage";
        [Export]
        public int Damage { get; set; } = 10;
        [Export]
        public int StaminaCost { get; set; } = 4;

        public AttacksSource() : this("", "", 0, 0) { }

        public AttacksSource(string attackName, string description, int damage, int staminaCost)
        {
            AttackName = attackName;
            Description = description;
            Damage = damage;
            StaminaCost = staminaCost;
        }
    }
}
