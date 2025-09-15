using Commons.Autoloads;
using Godot;
using System;

namespace TurnCombat.Battle
{
    public partial class Talking : Control
    {
        private BattleMec _battleMec;
        [Export]
        public AudioStream _talkSFX;
        public void OnBattleMecReady()
        {
            _battleMec = GetParent().GetParent().GetParent<BattleMec>();
        }
        public void OnTalkButtonButtonDown()
        {
            AudioPlayerGlobal.Instance.PlaySound(_talkSFX, audioBus: "SFX");
            GD.Print("You tried to talk");
            _battleMec.UpdateText?.Invoke("You've tried to have s small talk");
            _battleMec.PlayerSource.AddStamina(20);
            _battleMec.NextTurn();
        }
        public void OnFlirtButtonButtonDown()
        {
            AudioPlayerGlobal.Instance.PlaySound(_talkSFX, audioBus: "SFX");

            GD.Print("You tried to flirt");
            _battleMec.UpdateText?.Invoke("You've tried to flirt");
            _battleMec.PlayerSource.AddStamina(15);
            _battleMec.NextTurn();
        }
        public void OnRestButtonButtonDown()
        {
            AudioPlayerGlobal.Instance.PlaySound(_talkSFX, audioBus: "SFX");

            GD.Print("You laid down");
            _battleMec.UpdateText?.Invoke("You laid down to nap");
            _battleMec.PlayerSource.AddStamina(45);
            _battleMec.NextTurn();
        }
        public void OnInsultButtonButtonDown()
        {
            AudioPlayerGlobal.Instance.PlaySound(_talkSFX, audioBus: "SFX");

            GD.Print("You insulted");
            _battleMec.UpdateText?.Invoke("You insulted your enemy");
            _battleMec.PlayerSource.AddStamina(20);
            _battleMec.NextTurn();
        }
    }
}
