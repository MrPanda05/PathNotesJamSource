using Godot;
using System;
using System.Linq;
using TurnCombat.Attacks;

namespace TurnCombat.Battle
{
    public partial class IventoryUI : Control
    {
        private BattleMec _battleMech;
        public void OnBattleMecReady()
        {
            _battleMech = GetParent().GetParent().GetParent<BattleMec>();
            var items = _battleMech.PlayerSource.Inventory.InventorySlots;
            var children = GetChildren();
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i] is InventoryButton button)
                {
                    button.Initialize(items[i], _battleMech);
                }
            }
        }
        public void OnButtonButtonDown()
        {
            foreach (var item in _battleMech.PlayerSource.Inventory.InventorySlots)
            {
                GD.Print($"This slot has {item.Amount}x of {item.Item.ItemName}");
            }
            //GD.Print("You used an item");
            //_battleMech.PlayerSource.Health += 30;
            //_battleMech.NextTurn();
        }
    }
}
