using Commons.Autoloads;
using Godot;
using Story.Dialogues;
using System;

namespace Story
{
    /// <summary>
    /// This starts the dialogue. This starts each time Game state.
    /// </summary>
    public partial class StoryNode : Node2D
    {
        [Export]
        private CanvasLayer _layer;

        private int currentChapter = 0;

        [Export]
        private DialogueBox _dialogueBox;
        
        [Export]
        public DialogueBook[] dialogues;
        public override void _Ready()
        {
            GameManager.Instance.OnStoryEnter += EnterStory;
            GameManager.Instance.OnStoryExit += ExitStory;
        }
        public override void _ExitTree()
        {
            GameManager.Instance.OnStoryEnter -= EnterStory;
            GameManager.Instance.OnStoryExit -= ExitStory;
        }
        public void EnterStory()
        {
            GD.Print("You are in the story mode");
            Visible = true;
            _layer.Visible = true;
            if (currentChapter <= dialogues.Length - 1)
            {
                _dialogueBox.Initialize(dialogues[currentChapter]);
            }

        }
        public void ExitStory()
        {
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
