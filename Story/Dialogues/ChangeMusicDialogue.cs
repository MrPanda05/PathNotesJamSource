using Commons.Autoloads;
using Godot;
using System;

namespace Story.Dialogues
{
    [GlobalClass]
    public partial class ChangeMusicDialogue : Dialogue
    {
        [Export]
        public AudioStream Music { get; set; } = null;

        public override void OnFlipEnter()
        {
            MusicManager.Instance.PlayMusic(Music);
        }
        public ChangeMusicDialogue() : this("", "", null, null) { }
        public ChangeMusicDialogue(string author, string speach, Texture2D sprite, AudioStream music) : base(author, speach, sprite)
        {
            Music = music;
        }
    }
}
