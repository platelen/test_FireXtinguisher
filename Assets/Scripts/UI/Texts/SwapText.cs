using Events;
using TMPro;
using UnityEngine;

namespace UI.Texts
{
    public class SwapText : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private string _textTakeFireExtinguisher = "Нажмите 'E', чтобы взять огнетушитель в руки!";
        private string _textPullThePin = "Нажмите 'Q', чтобы выдернуть чеку!";
        private string _textPullOutTheSeal = "Нажмите 'E', чтобы выдернуть пломбу";
        private string _textClickMouseButton = "Нажимайте левую кнопку мыши, чтобы тушить пожар!";
        private string _textPutOutTheFire = "Зажмите левую кнопку мыши, чтобы тушить пожар!";

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();

            GlobalEvents.OnStartTakeFireExtinguisherText.AddListener(OnStartTakeFireExtinguisher);
            GlobalEvents.OnStartUseFireExtinguisher.AddListener(OnStartPullThePin);
            GlobalEvents.OnStartPullOutTheSeal.AddListener(OnStartPullOutTheSeal);
            GlobalEvents.OnStartClickMouseButton.AddListener(OnStartClickMouseButton);
            GlobalEvents.OnStartPutOutTheFire.AddListener(OnStartPutOutTheFire);
        }


        private void OnStartTakeFireExtinguisher()
        {
            _text.text = _textTakeFireExtinguisher;
        }

        private void OnStartPullThePin()
        {
            _text.text = _textPullThePin;
        }

        private void OnStartPullOutTheSeal()
        {
            _text.text = _textPullOutTheSeal;
        }

        private void OnStartClickMouseButton()
        {
            _text.text = _textClickMouseButton;
        }

        private void OnStartPutOutTheFire()
        {
            _text.text = _textPutOutTheFire;
        }

        private void OnDestroy()
        {
            GlobalEvents.OnStartTakeFireExtinguisherText.RemoveListener(OnStartTakeFireExtinguisher);
            GlobalEvents.OnStartPullThePin.RemoveListener(OnStartPullThePin);
            GlobalEvents.OnStartPullOutTheSeal.RemoveListener(OnStartPullOutTheSeal);
            GlobalEvents.OnStartClickMouseButton.RemoveListener(OnStartClickMouseButton);
            GlobalEvents.OnStartPutOutTheFire.RemoveListener(OnStartPutOutTheFire);
        }
    }
}