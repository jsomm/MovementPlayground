using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float ZoomSpeed = 3f;
    [SerializeField] private float ZoomInMax = 35f;
    [SerializeField] private float ZoomOutMax = 75f;

    private CinemachineInputProvider InputProvider;
    private CinemachineVirtualCamera VirtualCamera;

    private void Awake()
    {
        InputProvider = GetComponent<CinemachineInputProvider>();
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {

        float z = InputProvider.GetAxisValue(2);
        if (z != 0)
        {
            ZoomScreen(z);
        }
    }

    public void ZoomScreen(float increment)
    {
        float fov = VirtualCamera.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + increment, ZoomInMax, ZoomOutMax);

        VirtualCamera.m_Lens.FieldOfView = Mathf.MoveTowards(fov, target, ZoomSpeed);
    }
}
