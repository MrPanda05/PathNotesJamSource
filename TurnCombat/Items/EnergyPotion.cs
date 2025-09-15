using Commons.Autoloads;
using Godot;
using System;
using TurnCombat.Char;
using TurnCombat.Enemies;

namespace TurnCombat.Items
{
    [GlobalClass]
    public partial class EnergyPotion : ItemSource
    {
        [Export]
        public int RecoverStaminaAmount { get; set; } = 25;
        public override void Use(PlayerSource playerSource, EnemySource enemySource)
        {
            playerSource.AddStamina(RecoverStaminaAmount);
            AudioPlayerGlobal.Instance.PlaySound(SoundEffect, audioBus: "SFX");
        }
        public EnergyPotion() : this("", "", null, 0) { }
        public EnergyPotion(string itemName, string itemDescription, AudioStream soundEffect, int staminaAmout) : base(itemName, itemDescription, soundEffect)
        {
            RecoverStaminaAmount = staminaAmout;
        }
    }
}
