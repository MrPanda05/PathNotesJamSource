using Godot;
using System;

namespace Story.Dialogues
{
    /// <summary>
    /// Control the dialogue box, showing the first text and changing pages/ text
    /// </summary>
    public partial class DialogueControl : Panel
    {
        public DialogueList currentDialogue;
        [Export]
        public Label authorLabel, speachLabel;

        private int _currentIndex = 0;
        private int _listSize = 0;

        public Action OnDialogueStart;
        public Action OnDialogueStop;
        [Export]
        public TextureRect texture;
        public void Enter(DialogueList dialogue)
        {
            currentDialogue = dialogue;
            _currentIndex = 0;
            if (currentDialogue == null)
            {
                GD.PrintErr("No dialogueList found");
                return;
            }
            currentDialogue.OnDialogueStarts();
            _listSize = currentDialogue.Dialogues.Length;
            if(_listSize == 0)
            {
                GD.PrintErr("DialogueList with no actual dialogue");
                return;
            }
            authorLabel.Text = currentDialogue.Dialogues[_currentIndex].Author;
            speachLabel.Text = currentDialogue.Dialogues[_currentIndex].Speach;
            texture.Texture = currentDialogue.Dialogues[_currentIndex].Sprite;
            OnDialogueStart?.Invoke();
        }
        public void NextPage()
        {
            if(_currentIndex+1 > _listSize)
            {
                currentDialogue.OnDialoguesEnds();
                currentDialogue = null;
                OnDialogueStop?.Invoke();
                return;
            }
            //currentDialogue.Dialogues[_currentIndex].OnFlipEnter();
            authorLabel.Text = currentDialogue.Dialogues[_currentIndex].Author;
            speachLabel.Text = currentDialogue.Dialogues[_currentIndex].Speach;
            texture.Texture = currentDialogue.Dialogues[_currentIndex].Sprite;
            _currentIndex++;
        }

        
    }
}
