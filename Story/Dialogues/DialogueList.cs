using Godot;
using System;
using TurnCombat.Attacks;

namespace Story.Dialogues
{
    /// <summary>
    /// A list of dialogues, holding "pages" of a character lines/ or conversation
    /// </summary>
    [GlobalClass]
    public partial class DialogueList : Resource
    {
        [Export]
        public Dialogue[] Dialogues { get; set; }
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
        public virtual void OnDialogueStarts()
        {
            GD.Print("This list of dialogue is starting");
        }
        public virtual void OnDialoguesEnds()
        {
            GD.Print("This list of dialogue Has ended");
        }

        public DialogueList() : this(null) { }

        public DialogueList(Dialogue[] dialogues)
        {
            dialogues = dialogues ?? Array.Empty<Dialogue>();
            DialogueSize = dialogues.Length;
            currentIndex = 0;
        }
    }
}
