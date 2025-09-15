using Godot;
using System;

namespace Story.Dialogues
{
    [GlobalClass]
    public partial class Dialogue : Resource
    {
        [Export]
        public string Author { get; set; } = "Speaker";
        [Export]
        public string Speach { get; set; } = "Hey there, I am there using uatisappiii";
        [Export]
        public Texture2D Sprite { get; set; } = null;

        public Dialogue(): this("", "", null) { }

        public Dialogue(string author, string speach, Texture2D sprite)
        {
            Author = author;
            Speach = speach;
            Sprite = sprite;
        }
    }
}
