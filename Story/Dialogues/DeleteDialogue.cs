using Commons.Autoloads;
using Godot;
using System;

namespace Story.Dialogues
{
    [GlobalClass]
    public partial class DeleteDialogue : Dialogue
    {
        public override void OnFlipExit()
        {
            GameManager.Instance.CloseGame();
        }
        public DeleteDialogue() : this("", "", null) { }
        public DeleteDialogue(string author, string speach, Texture2D sprite) : base(author, speach, sprite) { }
    }
}
