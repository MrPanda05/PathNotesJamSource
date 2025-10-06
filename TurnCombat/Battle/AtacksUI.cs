using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using TurnCombat.Attacks;

namespace TurnCombat.Battle
{
    /// <summary>
    /// Sets the player attacks ui
    /// </summary>
    public partial class AtacksUI : Control
    {
        private BattleMec _battleMech;
        private List<AttacksSource> _attacksSources = new List<AttacksSource>();
        public void OnBattleMecReady()
        {
            Visible = false;
            _battleMech = GetParent().GetParent().GetParent().GetParent<BattleMec>();
            _attacksSources = _battleMech.PlayerSource.Attacks.ToList();
            var children = GetChildren();
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i] is AttackButton button)
                {
                    button.Initialize(_attacksSources[i], _battleMech);
                }
            }
        }
    }
}
