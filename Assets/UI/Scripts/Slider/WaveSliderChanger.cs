using Script.Wave;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Script
{
    public class WaveSliderChanger: MonoBehaviour
    {
        [SerializeField] private TMP_Text currentWaveTextField;
        [SerializeField] private TMP_Text nextWaveTextField;
        [SerializeField] private SliderView sliderView;
        
        [Inject] private WavesController _wavesController;

        private float _waveTime;

        private void OnEnable()
        {
            _wavesController.WaveChanged += OnWaveChanged;
        }

        private void OnDestroy()
        {
            _wavesController.WaveChanged -= OnWaveChanged;
        }

        private void FixedUpdate()
        {
            sliderView.IncreaseValue(Time.deltaTime, _waveTime);
        }

        private void OnWaveChanged(float currentWave, float nextWave, float waveTime)
        {
            sliderView.ChangeValue(0, waveTime);
            _waveTime = waveTime;
            currentWaveTextField.text = currentWave.ToString();
            nextWaveTextField.text = nextWave.ToString();
        }
    }
}