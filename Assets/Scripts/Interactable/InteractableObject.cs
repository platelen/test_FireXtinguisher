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
                Debug.Log("Можно взаимодействовать");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TryInteract();
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
            Debug.Log("Interacted with object");
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _interactionDistance);
        }
    }
}