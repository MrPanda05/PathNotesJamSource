using Commons.Autoloads;
using Godot;
using System;
using TurnCombat.Attacks;

namespace TurnCombat.Battle
{
    /// <summary>
    /// Handles the attack button in the battle UI
    /// </summary>
    public partial class AttackButton : Button
    {
        private AttacksSource _attackSource;
        private BattleMec _battlemMec;
        [Export]
        public AudioStream attackSFXSucess, attackSFXFail;
        public static Action OnAttackButtonPressed;

        public void Initialize(AttacksSource attackSource, BattleMec battlemMec)
        {
            _attackSource = attackSource;
            _battlemMec = battlemMec;
            GD.Print(_attackSource.AttackName);
            Text = $"{_attackSource.AttackName} : {_attackSource.StaminaCost} STM";
        }
        public void OnMouseEntered()
        {
            DescriptionsPlayer.SetDescription(_attackSource.Description);
        }
        public void OnMouseExited()
        {
            DescriptionsPlayer.ClearDescription();
        }
        public void OnButtonDown()
        {
            if(_battlemMec.PlayerSource.Stamina < _attackSource.StaminaCost)
            {
                DescriptionsPlayer.SetDescription("Lack stamina");
                AudioPlayerGlobal.Instance.PlaySound(attackSFXFail, audioBus: "SFX");
                GD.Print("You do not have stamina");
                return;
            }
            OnAttackButtonPressed?.Invoke();
            _battlemMec.UpdateText?.Invoke($"You used {_attackSource.AttackName}");
            AudioPlayerGlobal.Instance.PlaySound(attackSFXSucess, audioBus:"SFX");
            _battlemMec.PlayerSource.DecreaseStamina(_attackSource.StaminaCost);
            _battlemMec.EnemySource.DecreaseHealth(_attackSource.Damage);
            _battlemMec.NextTurn();
        }
    }
}
