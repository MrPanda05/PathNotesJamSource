using Godot;
using System;

namespace Overworld.Interactables.InteractableList
{
    public partial class TestInteractable : Area2D, IInteractable
    {
        public void Interact()
        {
            GD.Print("I got interacted");
        }
    }
}
