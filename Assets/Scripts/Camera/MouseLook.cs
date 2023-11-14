using UnityEngine;

namespace Camera
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private Transform _playerBody;
        [SerializeField] private float _mouseSens = 100f;

        private float _xRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            LookAround();
        }

        private void LookAround()
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSens * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}