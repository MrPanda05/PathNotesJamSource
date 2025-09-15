using Godot;
using System;

namespace TurnCombat.Battle
{
    public partial class EnemyUi : Control
    {
        private BattleMec _battleMec;
        private HealthBar _healthBar;
        private Label _enemyName;
        public void OnBattleMecReady()
        {
            _battleMec = GetParent<BattleMec>();
            _healthBar = GetNode<HealthBar>("EnemyStats/HealthBar");
            _enemyName = GetNode<Label>("Label");
            UpdateBars();
            _battleMec.OnUpdate += UpdateBars;
            _enemyName.Text = _battleMec.EnemySource.EnemyName;
        }

        private void UpdateBars()
        {
            _healthBar.SetValues(_battleMec.EnemySource.MaxHealth, _battleMec.EnemySource.Health, $"{_battleMec.EnemySource.Health}/{_battleMec.EnemySource.MaxHealth}");
        }


        public override void _ExitTree()
        {
            _battleMec.OnUpdate -= UpdateBars;
        }
    }
}
