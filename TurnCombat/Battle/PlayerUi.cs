using Godot;
using System;

namespace TurnCombat.Battle
{
    public partial class PlayerUi : Control
    {
        private BattleMec _battleMec;
        private HealthBar _healthBar;
        private StaminaBar _staminaBar;
        public void OnBattleMecReady()
        {
            _battleMec = GetParent<BattleMec>();
            _healthBar = GetNode<HealthBar>("PlayerStats/HealthBar");
            _staminaBar = GetNode<StaminaBar>("PlayerStats/StaminaBar");
            UpdateBars();
            _battleMec.OnUpdate += UpdateBars;
        }

        private void UpdateBars()
        {
            _healthBar.SetValues(_battleMec.PlayerSource.MaxHealth, _battleMec.PlayerSource.Health, $"{_battleMec.PlayerSource.Health}/{_battleMec.PlayerSource.MaxHealth}");
            _staminaBar.SetValues(_battleMec.PlayerSource.MaxStamina, _battleMec.PlayerSource.Stamina, $"{_battleMec.PlayerSource.Stamina}/{_battleMec.PlayerSource.MaxStamina}");

        }


        public override void _ExitTree()
        {
            _battleMec.OnUpdate -= UpdateBars;
        }
    }
}
