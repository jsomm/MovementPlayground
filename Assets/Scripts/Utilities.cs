using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementPlayground
{
    public static class Utilities
    {
        static Camera _cam = Camera.main;

        public static Vector3 GetMousePosition()
        {
            return _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }

        public static Ray CameraRaycast()
        {
            return _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        }
    }
}
