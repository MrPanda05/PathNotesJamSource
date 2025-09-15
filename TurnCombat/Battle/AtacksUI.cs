using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using TurnCombat.Attacks;

namespace TurnCombat.Battle
{
    public partial class AtacksUI : Control
    {
        private BattleMec _battleMech;
        private List<AttacksSource> _attacksSources = new List<AttacksSource>();
        public void OnBattleMecReady()
        {
            _battleMech = GetParent().GetParent().GetParent<BattleMec>();
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
        public void OnButtonButtonDown()
        {
            GD.Print("You chose to attack!!");
            _battleMech.EnemySource.Health -= 10;
            _battleMech.NextTurn();
        }
    }
}
