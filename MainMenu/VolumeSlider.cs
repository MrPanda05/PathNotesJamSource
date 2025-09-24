using Commons.Autoloads;
using Godot;
using System;

namespace MainMenu
{
    public partial class VolumeSlider : HSlider
    {
        [Export]
        public string BusName { get; set; } = "Master";
        [Export]
        public int BusPort { get; set; } = 0;
        [Export]
        private AudioStreamPlayer _feedbackAudio;

        private Label _labelName, _labelVolume;

        private Action OnAudioUpdate;

        public override void _Ready()
        {
            SaveSystem.Instance.AddNewField(BusName, 25);
            Value = (double)SaveSystem.Instance.GetValue(BusName);
            _labelName = GetNode<Label>("name");
            _labelVolume = GetNode<Label>("volume");
            _labelName.Text = BusName;
            if(_feedbackAudio != null)
            {
                _feedbackAudio.Bus = AudioServer.GetBusName(BusPort);
            }
            OnAudioUpdate += MakeSure;
            _labelVolume.Text = (double)SaveSystem.Instance.GetValue(BusName) + " %";
        }
        /// <summary>
        /// Prevents a bug where audio are desynced
        /// </summary>
        private void MakeSure()
        {
            Value = (double)SaveSystem.Instance.GetValue(BusName);
        }

        public float ScaleDecibels(float value)
        {
            float scale = 20.0f;
            float divisor = 50.0f;
            return scale * (float)Math.Log10(value / divisor);
        }

        public void OnValueChanged(float value)
        {
            AudioServer.SetBusVolumeDb(BusPort, ScaleDecibels(value));
            if (value <= 0)
            {
                AudioServer.SetBusMute(BusPort, true);
            }
            else if (value > 0 && AudioServer.IsBusMute(BusPort))
            {
                AudioServer.SetBusMute(BusPort, false);
            }
            if(_labelVolume != null)
            {
                _labelVolume.Text = value.ToString() + " %";
            }
        }
        public void OnDragEnded(bool value_changed)
        {
            _feedbackAudio?.Play();
            SaveSystem.Instance.Update(BusName, Mathf.RoundToInt(Value));
            OnAudioUpdate?.Invoke();
        }
        public override void _ExitTree()
        {
            OnAudioUpdate -= MakeSure;
        }
    }
}
