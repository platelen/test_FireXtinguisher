using Events;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _foamParticles;
        [SerializeField] private GameObject _prefabFireExtinguisher;

        public static PlayerController Instance;

        private bool _isPullThePin;
        private bool _isPullOutTheSeal;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("Duplicate instance of PlayerController. Deleting the new one.");
                Destroy(gameObject);
            }

            GlobalEvents.OnStartTakeFireExtinguisher.AddListener(EnabledPrefab);
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CheckStateThePin();
                _prefabFireExtinguisher.transform.GetChild(3).GetComponent<Animator>().enabled = true;
                //Включаем аниматор у чеки
            }

            if (_isPullThePin)
            {
                GlobalEvents.SendStartPullOutTheSeal();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    CheckStateTheSeal();
                    _prefabFireExtinguisher.transform.GetChild(4).GetComponent<Animator>().enabled = true;
                    GlobalEvents.SendStartPutOutTheFire();
                    _isPullThePin = false;
                    //Включаем аниматор у пломбы
                }
            }

            if (_isPullOutTheSeal)
            {
                _prefabFireExtinguisher.transform.GetChild(2).GetComponent<Animator>().enabled = true;
                CheckStatePutOutTheFire();
            }
        }

        private void StartExtinguishing()
        {
            _foamParticles.Play();
        }

        private void StopExtinguishing()
        {
            _foamParticles.Stop();
        }

        private void EnabledPrefab()
        {
            _prefabFireExtinguisher.SetActive(true);
        }

        private void CheckStateThePin()
        {
            GlobalEvents.SendStartPullThePin();
            _isPullThePin = true;
        }

        private void CheckStateTheSeal()
        {
            _isPullThePin = false;
            _isPullOutTheSeal = true;
        }

        private void CheckStatePutOutTheFire()
        {
            if (Input.GetButton("Fire1"))
            {
                GlobalEvents.SendStartFireParticlesOff();
                StartExtinguishing();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                StopExtinguishing();
            }
        }

        private void OnDestroy()
        {
            GlobalEvents.OnStartTakeFireExtinguisher.RemoveListener(EnabledPrefab);
        }
    }
}