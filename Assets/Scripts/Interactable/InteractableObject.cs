using Events;
using Player;
using UnityEngine;

namespace Interactable
{
    public class InteractableObject : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance = 3f;

        void Update()
        {
            if (IsPlayerNearby())
            {
                GlobalEvents.SendStartTakeFireExtinguisherText();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GlobalEvents.SendStartUseFireExtinguisher();
                    TryInteract();
                    Destroy(gameObject);
                }
            }
        }

        private bool IsPlayerNearby()
        {
            return Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <
                   _interactionDistance;
        }

        private void TryInteract()
        {
            GlobalEvents.SendStartTakeFireExtinguisher();
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _interactionDistance);
        }
    }
}