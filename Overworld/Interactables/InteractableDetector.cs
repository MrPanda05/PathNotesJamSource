using Godot;
using System;

namespace Overworld.Interactables
{
    /// <summary>
    /// Detects interactable areas to be able to interact with them
    /// 
    /// THIS IS DESIGNED TO WORK WITH ONLY ONE INTERACBLE AREA
    /// </summary>
    public partial class InteractableDetector : Area2D
    {
        private bool _onInteraction;
        private IInteractable _currentInteractable = null;
        public void OnAreaEntered(Area2D area)
        {
            if(area is IInteractable interactable)
            {
                GD.Print("Detected an interactble, press E");
                _onInteraction = true;
                _currentInteractable = interactable;
            }
        }
        public void OnAreaExited(Area2D area)
        {
            if(area is IInteractable interactable)
            {
                GD.Print("You've exit an interacble");
                _onInteraction = false;
                _currentInteractable = null;
            }
        }

        public override void _PhysicsProcess(double delta)
        {
            if(_onInteraction)
            {
                if (Input.IsActionJustPressed("Interact"))
                {
                    _currentInteractable.Interact();
                }
            }
        }
    }
}
