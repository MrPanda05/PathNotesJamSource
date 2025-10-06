using Commons.Autoloads;
using Godot;
using System;

namespace TurnCombat.Battle
{
    /// <summary>
    /// Handles talking
    /// </summary>
    public partial class Talking : Control
    {
        private BattleMec _battleMec;
        [Export]
        public AudioStream _talkSFX;

        public static Action OnTalkButtonPressed;
        public void OnBattleMecReady()
        {
            _battleMec = GetParent().GetParent().GetParent().GetParent<BattleMec>();
            Visible = false;
        }
        public void OnTalkButtonMouseEntered()
        {
            DescriptionsPlayer.SetDescription("Try to do some small talk!");
        }
        public void OnTalkButtonMouseExited()
        {
            DescriptionsPlayer.ClearDescription();
        }
        public void OnFlirtButtonMouseEntered()
        {
            DescriptionsPlayer.SetDescription("You are such a freaky knight");
        }
        public void OnFlirtButtonMouseExited()
        {
            DescriptionsPlayer.ClearDescription();
        }
        public void OnRestButtonMouseEntered()
        {
            DescriptionsPlayer.SetDescription("Hmm... a little nap doesn't hurt, right?");
        }
        public void OnRestButtonMouseExited()
        {
            DescriptionsPlayer.ClearDescription();
        }
        public void OnInsultButtonMouseEntered()
        {
            DescriptionsPlayer.SetDescription("Show what a true gamer can do!");
        }
        public void OnInsultButtonMouseExited()
        {
            DescriptionsPlayer.ClearDescription();
        }
        public void OnTalkButtonButtonDown()
        {
            AudioPlayerGlobal.Instance.PlaySound(_talkSFX, audioBus: "SFX");
            GD.Print("You tried to talk");
            OnTalkButtonPressed?.Invoke();
            _battleMec.UpdateText?.Invoke("You've tried to have s small talk");
            _battleMec.PlayerSource.AddStamina(30);
            _battleMec.NextTurn();
        }
        public void OnFlirtButtonButtonDown()
        {
            AudioPlayerGlobal.Instance.PlaySound(_talkSFX, audioBus: "SFX");

            GD.Print("You tried to flirt");
            OnTalkButtonPressed?.Invoke();

            _battleMec.UpdateText?.Invoke("You've tried to flirt");
            _battleMec.PlayerSource.AddStamina(25);
            _battleMec.PlayerSource.AddHealth(10);
            _battleMec.EnemySource.AddHealth(5);
            _battleMec.NextTurn();
        }
        public void OnRestButtonButtonDown()
        {
            AudioPlayerGlobal.Instance.PlaySound(_talkSFX, audioBus: "SFX");

            GD.Print("You laid down");
            OnTalkButtonPressed?.Invoke();

            _battleMec.UpdateText?.Invoke("You laid down to nap");
            _battleMec.PlayerSource.AddStamina(65);
            _battleMec.NextTurn();
        }
        public void OnInsultButtonButtonDown()
        {
            AudioPlayerGlobal.Instance.PlaySound(_talkSFX, audioBus: "SFX");

            GD.Print("You insulted");
            OnTalkButtonPressed?.Invoke();

            _battleMec.UpdateText?.Invoke("You insulted your enemy");
            _battleMec.PlayerSource.AddStamina(20);
            _battleMec.EnemySource.DecreaseHealth(GameManager.Instance.RNG.RandiRange(1, 25));
            _battleMec.NextTurn();
        }
    }
}
