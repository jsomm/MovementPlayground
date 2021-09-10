using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementPlayground
{
    public class ProjectileOriginController : MonoBehaviour
    {
        [SerializeField] LayerMask _groundMask;
        [SerializeField] Transform _playerTransform;
        [SerializeField] float _distanceFromPlayer = 0.5f;

        private void Update()
        {

            Ray ray = Utilities.CameraRaycast();
            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _groundMask))
            {
                Vector3 direction = (hitInfo.point - transform.position).normalized;
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float distance = Mathf.Clamp(Vector3.Distance(hitInfo.point, transform.position), _distanceFromPlayer, _distanceFromPlayer);
                Vector3 targetPosition = _playerTransform.position + direction * distance;
                targetPosition.y = 1;

                transform.position = targetPosition;
                transform.eulerAngles = new Vector3(0, angle, 0);
            }
        }
    }
}
