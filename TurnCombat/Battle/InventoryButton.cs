using Commons.Autoloads;
using Godot;
using System;
using TurnCombat.Attacks;
using TurnCombat.Inventorys;

namespace TurnCombat.Battle
{
    public partial class InventoryButton : Button
    {
        private BattleMec _battlemMec;
        private InventorySlot _slot;
        [Export]
        public AudioStream _audioFail;

        public void Initialize(InventorySlot inventorySlot, BattleMec battlemMec)
        {
            _battlemMec = battlemMec;
            _slot = inventorySlot;
            Text = $"{_slot.Item.ItemName} x{_slot.Amount}";
        }

        public void OnButtonDown()
        {
            if(_slot.Amount <= 0)
            {
                AudioPlayerGlobal.Instance.PlaySound(_audioFail, audioBus: "SFX");
                Text = $"{_slot.Item.ItemName} x{_slot.Amount}";
                _battlemMec.UpdateText?.Invoke("Out of stock");
                GD.Print("You do not have this item stocked");
                return;
            }
            _slot.Item.Use(_battlemMec.PlayerSource, _battlemMec.EnemySource);
            _slot.Amount--;
            Text = $"{_slot.Item.ItemName} x{_slot.Amount}";
            _battlemMec.UpdateText?.Invoke($"You used {_slot.Item.ItemName}");
            _battlemMec.OnUpdate?.Invoke();

        }
    }
}
