using Commons.Autoloads;
using Godot;
using System;

namespace Story.Dialogues
{
    /// <summary>
    /// Handles the Dialogues, it is responsible for initializing things and managing it
    /// </summary>
    public partial class DialogueBox : Control
    {
        public DialogueList mainList, flirtList, talkList;

        private DialogueControl _dialogueControl;
        private DialogueBook _bookDialogue;

        public bool IsAnDialogueActive;
        public bool IsOnDialogueMode;
        [Export]
        public Control Buttons;

        public Action OnConversationExited;

        private int count = 0;

        public override void _Ready()
        {
            _dialogueControl = GetNode<DialogueControl>("DialogueControl");
        }
        public void Initialize(DialogueBook book)
        {
            book.BookStart();
            IsOnDialogueMode = true;
            Buttons.Visible = false;
            mainList = book.MainList;
            flirtList = book.FlirtList;
            talkList = book.TalkList;
            _bookDialogue = book;
            _dialogueControl.Visible = true;
            _dialogueControl.OnDialogueStart += DialogueStarted;
            _dialogueControl.OnDialogueStop += DialogueEnded;
            _dialogueControl.Enter(mainList);
        }
        public void Exit()
        {
            _bookDialogue.BookEnd();
            IsOnDialogueMode = false;
            mainList = null;
            flirtList = null;
            talkList = null;
            _bookDialogue = null;
            Buttons.Visible = false;
            _dialogueControl.Visible = false;
            _dialogueControl.OnDialogueStart -= DialogueStarted;
            _dialogueControl.OnDialogueStop -= DialogueEnded;

        }

        private void DialogueStarted()
        {
            IsAnDialogueActive = true;
            Buttons.Visible = false;
            _dialogueControl.Visible = true;
        }

        private void DialogueEnded()
        {
            if(_bookDialogue.FlirtList == null || _bookDialogue.TalkList == null)
            {
                GameManager.Instance.CloseGame();
            }
            _dialogueControl.Visible = false;
            IsAnDialogueActive = false;
            Buttons.Visible = true;
        }

        public void OnTalkButtonButtonDown()
        {
            _dialogueControl.Enter(talkList);
        }
        public void OnFlirtButtonButtonDown()
        {
            _dialogueControl.Enter(flirtList);
        }
        public void OnExitButtonButtonDown()
        {
            Exit();
            OnConversationExited?.Invoke();
            GameManager.Instance.ChangeState(GameState.Overworld);
        }
        public override void _PhysicsProcess(double delta)
        {
            if (Input.IsActionJustPressed("Click") && IsAnDialogueActive)
            {
                GD.Print("NextDialogue");
                _dialogueControl.NextPage();
            }
        }
    }
}
