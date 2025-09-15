using Commons.Autoloads;
using Godot;
using System;

namespace Story.Dialogues
{
    public partial class DialogueBox : Control
    {
        public DialogueList mainList, flirtList, talkList;

        private DialogueControl _dialogueControl;

        public bool IsInDialogue;
        public bool IsInSpeakMode;
        [Export]
        public Control Buttons;

        private int count = 0;

        public override void _Ready()
        {
            _dialogueControl = GetNode<DialogueControl>("DialoguePanel");
        }
        public void Initialize(DialogueList main, DialogueList flirt, DialogueList talk)
        {
            IsInSpeakMode = true;
            Buttons.Visible = false;
            mainList = main;
            flirtList = flirt;
            talkList = talk;
            _dialogueControl.currentDialogue = mainList;
            _dialogueControl.Visible = true;
            _dialogueControl.OnDialogueStart += DialogueStarted;
            _dialogueControl.OnDialogueStop += DialogueEnded;
            _dialogueControl.Enter();
        }
        public void Exit()
        {
            IsInSpeakMode = false;
            mainList = null;
            flirtList = null;
            talkList = null;
            Buttons.Visible = false;
            _dialogueControl.Visible = false;
            _dialogueControl.OnDialogueStart -= DialogueStarted;
            _dialogueControl.OnDialogueStop -= DialogueEnded;

        }

        private void DialogueStarted()
        {
            IsInDialogue = true;
            Buttons.Visible = false;
            _dialogueControl.Visible = true;
        }

        private void DialogueEnded()
        {
            if(flirtList == null)
            {
                GetTree().Quit();
                return;
            }
            _dialogueControl.Visible = false;
            IsInDialogue = false;
            Buttons.Visible = true;
        }

        public void OnTalkButtonButtonDown()
        {
            _dialogueControl.currentDialogue = talkList;
            _dialogueControl.Enter();
        }
        public void OnFlirtButtonButtonDown()
        {
            _dialogueControl.currentDialogue = flirtList;
            _dialogueControl.Enter();
        }
        public void OnExitButtonButtonDown()
        {
            Exit();
            GameManager.Instance.ChangeState(GameState.Overworld);
        }
        public override void _PhysicsProcess(double delta)
        {
            if (Input.IsActionJustPressed("Click") && IsInDialogue)
            {
                GD.Print("NextDialogue");
                _dialogueControl.NextPage();
            }
        }
    }
}
