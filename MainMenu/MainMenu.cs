using Commons.Autoloads;
using Godot;
using System;

namespace MainMenu
{
    public partial class MainMenu : Control
    {
        [Export]
        private Control Menu, Settings;
        public override void _Ready()
        {
            GameManager.Instance.ChangeState(GameState.Other);
        }
        public void OnPlayButtonButtonDown()
        {
            Visible = false;
            GameManager.Instance.ChangeState(GameState.Story);
        }
    }
}
