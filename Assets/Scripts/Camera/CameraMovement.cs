using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _cameraPosition;
    [SerializeField] private float _speedCamera;

    private void FixedUpdate()
    {
        if (_playerTransform != null)
        {
            _cameraPosition = new Vector3(_playerTransform.transform.position.x, _playerTransform.transform.position.y, -10f);
            transform.position = Vector3.Lerp(transform.position, _cameraPosition, _speedCamera * Time.fixedDeltaTime);
        }
    }
}
