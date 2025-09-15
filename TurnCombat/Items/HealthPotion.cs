using Commons.Autoloads;
using Godot;
using System;
using TurnCombat.Char;
using TurnCombat.Enemies;

namespace TurnCombat.Items
{
    [GlobalClass]
    public partial class HealthPotion : ItemSource
    {
        [Export]
        public int HealAmount { get; set; } = 25;
        public override void Use(PlayerSource playerSource, EnemySource enemySource)
        {
            playerSource.AddHealth(HealAmount);
            AudioPlayerGlobal.Instance.PlaySound(SoundEffect, audioBus:"SFX");
        }
        public HealthPotion() : this("","",null,0) { }
        public HealthPotion(string itemName, string itemDescription, AudioStream soundEffect, int healAmount) : base(itemName, itemDescription, soundEffect)
        {
            HealAmount = healAmount;
        }
    }
}
