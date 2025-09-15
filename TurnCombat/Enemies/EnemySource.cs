using Godot;
using System;
using TurnCombat.Attacks;

namespace TurnCombat.Enemies
{
    [GlobalClass]
    public partial class EnemySource : Resource
    {

        [Export]
        public string EnemyName { get; set; }
        [Export]
        public int MaxHealth { get; set; } = 100;
        [Export]
        public int Health { get; set; } = 100;
        [Export]
        public AttacksSource[] Attacks { get; set; }

        public Action OnDeath;

        [Export]
        public Texture2D EnemyTexture { get; set; }

        public void AddHealth(int health)
        {
            Health += health;
            if (Health > MaxHealth) MaxHealth = Health;
        }

        public void DecreaseHealth(int health)
        {
            Health -= health;
            if (Health <= 0)
            {
                Health = 0;
                OnDeath?.Invoke();

            }
        }
        public EnemySource() : this("",0, 0, null, null) { }

        public EnemySource(string enemyName, int maxHealth, int health, AttacksSource[] attacks, Texture2D enemyTexture)
        {
            EnemyName = enemyName;
            MaxHealth = maxHealth;
            Health = health;
            Attacks = attacks ?? Array.Empty<AttacksSource>();
            EnemyTexture = enemyTexture;

        }
    }
}
