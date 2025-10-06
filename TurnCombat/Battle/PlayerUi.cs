using Godot;
using System;

namespace TurnCombat.Battle
{
    /// <summary>
    /// Updates player stamina and healthbar
    /// </summary>
    public partial class PlayerUi : Control
    {
        private BattleMec _battleMec;
        private HealthBar _healthBar;
        private StaminaBar _staminaBar;
        [Export]
        private Panel Options;
        [Export]
        private Control Buttons;
        public void OnBattleMecReady()
        {
            _battleMec = GetParent<BattleMec>();
            _healthBar = GetNode<HealthBar>("PlayerStats/HealthBar");
            _staminaBar = GetNode<StaminaBar>("PlayerStats/StaminaBar");
            UpdateBars();
            _battleMec.OnUpdate += UpdateBars;
            AttackButton.OnAttackButtonPressed += DisableOptions;
            InventoryButton.OnInventoryButtonPressed += DisableOptions;
            Talking.OnTalkButtonPressed += DisableOptions;
            _battleMec.OnEnemyTurnEnded += EnableOptions;
        }
        private void DisableOptions()
        {
            Options.Visible = false;
            Buttons.Visible = false;
        }
        private void EnableOptions()
        {
            Options.Visible = true;
        }
        private void UpdateBars()
        {
            _healthBar.SetValues(_battleMec.PlayerSource.MaxHealth, _battleMec.PlayerSource.Health, $"{_battleMec.PlayerSource.Health}/{_battleMec.PlayerSource.MaxHealth}");
            _staminaBar.SetValues(_battleMec.PlayerSource.MaxStamina, _battleMec.PlayerSource.Stamina, $"{_battleMec.PlayerSource.Stamina}/{_battleMec.PlayerSource.MaxStamina}");

        }


        public override void _ExitTree()
        {
            _battleMec.OnUpdate -= UpdateBars;
            AttackButton.OnAttackButtonPressed -= DisableOptions;
            InventoryButton.OnInventoryButtonPressed -= DisableOptions;
            Talking.OnTalkButtonPressed -= DisableOptions;
            _battleMec.OnEnemyTurnEnded -= EnableOptions;

        }
    }
}
