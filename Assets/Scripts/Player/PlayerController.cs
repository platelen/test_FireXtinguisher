using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _foamParticles;

        public static PlayerController Instance;

        void Awake()
        {
            // Устанавливаем экземпляр при старте игры
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("Duplicate instance of PlayerController. Deleting the new one.");
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartExtinguishing();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                StopExtinguishing();
            }
        }

        private void StartExtinguishing()
        {
            _foamParticles.Play();
            // Дополнительные действия при начале тушения
        }

        private void StopExtinguishing()
        {
            _foamParticles.Stop();
            // Дополнительные действия при окончании тушения
        }
    }
}