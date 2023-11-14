using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace ManagerParticles
{
    public class ManagerParticles : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _particlesFire;
        [SerializeField] private float _duration = 5f;

        private void Start()
        {
            GlobalEvents.OnStartFireParticlesOff.AddListener(StartDisableParticlesCoroutine);
        }

        private void StartDisableParticlesCoroutine()
        {
            StartCoroutine(DisableParticlesSequentially());
        }

        private IEnumerator DisableParticlesSequentially()
        {
            foreach (var particles in _particlesFire)
            {
                particles.SetActive(false);
                yield return new WaitForSeconds(_duration / _particlesFire.Count);
            }

            if (_particlesFire[_particlesFire.Count - 1].activeSelf == false)
            {
                GlobalEvents.SendStartCongratulation();
            }
        }
    }
}