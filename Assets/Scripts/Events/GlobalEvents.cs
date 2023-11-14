using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GlobalEvents : MonoBehaviour
    {
        
        public static readonly UnityEvent OnStartTakeFireExtinguisher = new UnityEvent();
        public static readonly UnityEvent OnStartTakeFireExtinguisherText = new UnityEvent();
        public static readonly UnityEvent OnStartUseFireExtinguisher = new UnityEvent();
        public static readonly UnityEvent OnStartPullThePin = new UnityEvent();
        public static readonly UnityEvent OnStartPullOutTheSeal = new UnityEvent();
        public static readonly UnityEvent OnStartClickMouseButton = new UnityEvent();
        public static readonly UnityEvent OnStartPutOutTheFire = new UnityEvent();


        public static void SendStartTakeFireExtinguisher()
        {
            OnStartTakeFireExtinguisher.Invoke();
        }

        public static void SendStartTakeFireExtinguisherText()
        {
            OnStartTakeFireExtinguisherText.Invoke();
        }
        public static void SendStartUseFireExtinguisher()
        {
            OnStartUseFireExtinguisher.Invoke();
        }

        public static void SendStartPullThePin()
        {
            OnStartPullThePin.Invoke();
        }

        public static void SendStartPullOutTheSeal()
        {
            OnStartPullOutTheSeal.Invoke();
        }

        public static void SendStartClickMouseButton()
        {
            OnStartClickMouseButton.Invoke();
        }

        public static void SendStartPutOutTheFire()
        {
            OnStartPutOutTheFire.Invoke();
        }
    }
}