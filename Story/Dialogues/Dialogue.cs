using Godot;
using System;

namespace Story.Dialogues
{
    /// <summary>
    /// A resource that is designed to be a single "page" of a character line
    /// </summary>
    [GlobalClass]
    public partial class Dialogue : Resource
    {
        [Export]
        public string Author { get; set; } = "Speaker";
        [Export]
        public string Speach { get; set; } = "Hey there, I am there using uatisappiii";
        [Export]
        public Texture2D Sprite { get; set; } = null;

        /// <summary>
        /// Used when this dialogue is changed by another
        /// </summary>
        public virtual void OnFlip()
        {
            GD.Print("I was flipped");
        }

        public Dialogue(): this("", "", null) { }

        public Dialogue(string author, string speach, Texture2D sprite)
        {
            Author = author;
            Speach = speach;
            Sprite = sprite;
        }
    }
}
