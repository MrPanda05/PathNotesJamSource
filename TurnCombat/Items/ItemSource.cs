using Godot;
using System;
using TurnCombat.Char;
using TurnCombat.Enemies;

namespace TurnCombat.Items
{
    public partial class ItemSource : Resource
    {
        [Export]
        public string ItemName { get; set; } = "item";
        [Export]
        public string ItemDescription { get; set; } = string.Empty;

        [Export]
        public AudioStream SoundEffect;

        public virtual void Use(PlayerSource playerSource, EnemySource enemySource)
        {
            GD.Print("I was used");
        }

        public ItemSource() : this("", "", null) { }

        public ItemSource(string itemName, string itemDescription, AudioStream soundEffect)
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
            SoundEffect = soundEffect;

        }

    }
}
