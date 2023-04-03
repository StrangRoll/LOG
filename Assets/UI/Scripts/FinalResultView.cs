using Script.Wave;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Script
{
    public class FinalResultView : MonoBehaviour
    {
        [SerializeField] private TMP_Text resultTextField;
        
        [Inject] private WavesController _wavesController;

        private void OnEnable()
        {
            resultTextField.text = $"You have reached the {_wavesController.CurrentWave}th wave!";
        }
    }
}