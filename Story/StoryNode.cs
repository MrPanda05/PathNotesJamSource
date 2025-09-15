using Commons.Autoloads;
using Godot;
using Story.Dialogues;
using System;

namespace Story
{
    public partial class StoryNode : Node2D
    {
        [Export]
        private CanvasLayer _layer;

        private int currentChapter = 0;

        [Export]
        private DialogueBox _dialogueBox;
        [ExportGroup("Prologue")]
        [Export]
        public DialogueList prologueMain, prologueFlirt, prologueTalk;
        [ExportGroup("Ch1")]
        [Export]
        public DialogueList ch1Main, ch1Flirt, ch1Talk;
        [ExportGroup("Ch2")]
        [Export]
        public DialogueList ch2Main, ch2Flirt, ch2Talk;
        [ExportGroup("Ch3")]
        [Export]
        public DialogueList ch3Main, ch3Flirt, ch3Talk;
        public override void _Ready()
        {
            GameManager.Instance.OnGameStateEnter += EnterStory;
            GameManager.Instance.OnGameStateExit += ExitStory;
        }
        public void EnterStory(GameState gameState)
        {
            if (gameState != GameState.Story) return;
            GD.Print("You are in the story mode");
            Visible = true;
            _layer.Visible = true;
            switch (currentChapter)
            {
                case 0: _dialogueBox.Initialize(prologueMain, prologueFlirt, prologueTalk);
                    break;
                case 1:
                    _dialogueBox.Initialize(ch1Main, ch1Flirt, ch1Talk);
                    break;
                case 2:
                    _dialogueBox.Initialize(ch2Main, ch2Flirt, ch2Talk);
                    break;
                case 3:
                    _dialogueBox.Initialize(ch3Main, ch3Flirt, ch3Talk);
                    break;
                default:
                    break;
            }

        }
        public void ExitStory(GameState gameState)
        {
            if (gameState != GameState.Story) return;
            GD.Print("You are exiting the story mode");
            Visible = false;
            _layer.Visible = false;
            currentChapter++;
        }

        public void OnTetsButtonButtonDown()
        {
            GameManager.Instance.ChangeState(GameState.Overworld);
        }
    }
}
