using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMouseFollower : MonoBehaviour
{
    [SerializeField] LayerMask _groundMask;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _maxDistanceFromPlayerUp = 3f;
    [SerializeField] float _maxDistanceFromPlayerDown = 2f;
    [SerializeField] float _maxDistanceFromPlayerLeftRight = 4f;

    Camera _cam;

    private void Awake() => _cam = Camera.main;

    private void LateUpdate()
    {
        Ray ray = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _groundMask))
        {
            Vector3 targetPosition = new Vector3
            {
                x = Mathf.Clamp(hitInfo.point.x, -_maxDistanceFromPlayerLeftRight + _playerTransform.position.x, _maxDistanceFromPlayerLeftRight + _playerTransform.position.x),
                y = 0.0f,
                z = Mathf.Clamp(hitInfo.point.z, -_maxDistanceFromPlayerDown + _playerTransform.position.z, _maxDistanceFromPlayerUp + _playerTransform.position.z)
            };

            transform.position = targetPosition;
        }
    }
}
