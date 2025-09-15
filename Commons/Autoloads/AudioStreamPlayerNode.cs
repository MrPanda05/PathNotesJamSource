using Godot;
using System;


namespace Commons.Autoloads
{
    public partial class AudioStreamPlayerNode : AudioStreamPlayer
    {
        public void OnFinished()
        {
            QueueFree();
        }
    }
}
