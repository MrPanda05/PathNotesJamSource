using Godot;
using System;
using TurnCombat.Attacks;

namespace Story.Dialogues
{
    [GlobalClass]
    public partial class DialogueList : Resource
    {
        [Export]
        public Dialogue[] Dialoguess { get; set; }
        public int DialogueSize {get; private set;}
        public int currentIndex = 0;
        public Action OnDialogueListEnd;

        public void NextPage()
        {
            if(currentIndex > DialogueSize)
            {
                return;
            }
            currentIndex++;
        }

        public DialogueList(): this(null) { }

        public DialogueList(Dialogue[] dialogues)
        {
            dialogues = dialogues ?? Array.Empty<Dialogue>();
            DialogueSize = dialogues.Length;
            currentIndex = 0;
        }
    }
}
