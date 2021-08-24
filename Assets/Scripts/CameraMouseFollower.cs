using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMouseFollower : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform playerTransform;
    [SerializeField] float maxDistanceFromPlayerUp = 3f;
    [SerializeField] float maxDistanceFromPlayerDown = 2f;
    [SerializeField] float maxDistanceFromPlayerLeftRight = 4f;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            Vector3 targetPosition = new Vector3
            {
                x = Mathf.Clamp(hitInfo.point.x, -maxDistanceFromPlayerLeftRight + playerTransform.position.x, maxDistanceFromPlayerLeftRight + playerTransform.position.x),
                y = 0.0f,
                z = Mathf.Clamp(hitInfo.point.z, -maxDistanceFromPlayerDown + playerTransform.position.z, maxDistanceFromPlayerUp + playerTransform.position.z)
            };

            transform.position = targetPosition;
        }
    }
}
