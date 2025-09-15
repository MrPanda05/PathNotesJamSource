using Godot;
using System;

namespace TurnCombat.Inventorys
{
    [GlobalClass]
    public partial class Inventory : Resource
    {
        [Export]
        public Godot.Collections.Array<InventorySlot> InventorySlots { get; set; } = new Godot.Collections.Array<InventorySlot>();
    }
}
