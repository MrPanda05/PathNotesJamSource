using Godot;
using System;

namespace MainMenu
{
    public partial class Settings : Control
    {
        [Export]
        public Control menu;

        public void OnReturnButtonButtonDown()
        {
            menu.Visible = true;
            Visible = false;
        }
    }
}
