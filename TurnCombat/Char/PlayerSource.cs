using Godot;
using System;
using TurnCombat.Attacks;
using TurnCombat.Inventorys;

namespace TurnCombat.Char
{
    [GlobalClass]
    public partial class PlayerSource : Resource
    {
        [Export]
        public string PlayerName { get; set; }
        [Export]
        public int MaxHealth { get; set; } = 100;
        [Export]
        public int Health { get; set; } = 100;
        [Export]
        public int MaxStamina { get; set; } = 100;
        [Export]
        public int Stamina { get; set; } = 100;
        [Export]
        public AttacksSource[] Attacks { get; set; }
        [Export]
        public Inventory Inventory { get; set; } = null;
        [Export]
        public Texture2D PlayerTexture { get; set; }

        public Action OnDeath;

        public void AddHealth(int health)
        {
            Health += health;
            if(Health > MaxHealth) MaxHealth = Health;
        }
        public void AddStamina(int stamina)
        {
            Stamina += stamina;
            if(Stamina > MaxStamina) MaxStamina = Stamina;
        }
        public void DecreaseHealth(int health)
        {
            Health -= health;
            if(Health <= 0)
            {
                Health = 0;
                OnDeath?.Invoke();
            }
        }
        public void DecreaseStamina(int stamina)
        {
            Stamina -= stamina;
            if( Stamina <= 0)
            {
                Stamina = 0;
            }
        }
        public PlayerSource() : this("",0, 0, 0, 0, null, null, null) { }

        public PlayerSource(string playerName, int maxHealth, int health, int maxStamina, int stamina, AttacksSource[] attacks, Inventory inventory, Texture2D playerTexture)
        {
            PlayerName = playerName;
            MaxHealth = maxHealth;
            Health = health;
            MaxStamina = maxStamina;
            Stamina = stamina;
            Attacks = attacks ?? Array.Empty<AttacksSource>();
            Inventory = inventory;
            PlayerTexture = playerTexture;

        }
    }
}