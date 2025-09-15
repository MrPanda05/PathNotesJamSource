using Godot;
using System;
using TurnCombat.Items;

namespace TurnCombat.Inventorys
{
    [GlobalClass]
    public partial class InventorySlot : Resource
    {
        [Export]
        public ItemSource Item { get; set; } = null;
        [Export]
        public int Amount { get; set; } = 0;

        public InventorySlot(): this(null, 0) { }
        public InventorySlot(ItemSource item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}
