using Godot;
using System;

namespace Story.Dialogues
{
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
        public void Enter()
        {
            _currentIndex = 0;
            authorLabel.Text = currentDialogue.Dialoguess[_currentIndex].Author;
            speachLabel.Text = currentDialogue.Dialoguess[_currentIndex].Speach;
            texture.Texture = currentDialogue.Dialoguess[_currentIndex].Sprite;
            _listSize = currentDialogue.Dialoguess.Length;
            OnDialogueStart?.Invoke();
        }
        public void NextPage()
        {
            if(_currentIndex+1 > _listSize)
            {
                OnDialogueStop?.Invoke();
                return;
            }
            authorLabel.Text = currentDialogue.Dialoguess[_currentIndex].Author;
            speachLabel.Text = currentDialogue.Dialoguess[_currentIndex].Speach;
            texture.Texture = currentDialogue.Dialoguess[_currentIndex].Sprite;
            _currentIndex++;
        }

        
    }
}
