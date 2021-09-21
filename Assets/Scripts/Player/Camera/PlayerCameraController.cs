using Cinemachine;

using Mirror;

using UnityEngine;

namespace MovementPlayground
{
    public class PlayerCameraController : NetworkBehaviour
    {
        [SerializeField] GameObject _cameraPrefab;
        [SerializeField] Transform _followTarget;

        public override void OnStartAuthority()
        {
            // spawn in a camera and set the follow target
            CinemachineVirtualCamera cam = Instantiate(_cameraPrefab, transform.position, Quaternion.identity, null).GetComponentInChildren<CinemachineVirtualCamera>();
            cam.Follow = _followTarget;
        }

    }
}
