using Godot;
using System;

namespace MainMenu
{
    public partial class MenuButtons : Control
    {
        [Export]
        private Control Settings;

        public void OnSettingsButtonButtonDown()
        {
            Visible = false;
            Settings.Visible = true;
        }
        public void OnQuitButtonButtonDown()
        {
            GetTree().Quit();
        }
    }
}
