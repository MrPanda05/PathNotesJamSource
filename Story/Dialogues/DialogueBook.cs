using Godot;
using System;

namespace Story.Dialogues
{
    /// <summary>
    /// A resource that represents an book, of a conversation with the princess
    /// having the main dialogue that happens at the start, the flirt path and the talk path
    /// </summary>
    [GlobalClass]
    public partial class DialogueBook : Resource
    {
        [Export]
        public DialogueList MainList { get; set; }
        [Export]
        public DialogueList FlirtList { get; set; }
        [Export]
        public DialogueList TalkList { get; set; }

        public virtual void BookStart()
        {
            MainList.Dialogues[0].OnFlipEnter();
        }
        public virtual void BookEnd()
        {
            MainList.Dialogues[^1].OnFlipExit();
        }
        public DialogueBook() : this(null, null, null) { }
        public DialogueBook(DialogueList main, DialogueList flirt, DialogueList talk)
        {
            MainList = main;
            FlirtList = flirt;
            TalkList = talk;
        }
    }
}
