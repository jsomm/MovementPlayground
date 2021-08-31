using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float _zoomSpeed = 3f;
    [SerializeField] private float _zoomInMax = 35f;
    [SerializeField] private float _zoomOutMax = 75f;

    private CinemachineInputProvider _inputProvider;
    private CinemachineVirtualCamera _virtualCamera;

    private void Awake()
    {
        _inputProvider = GetComponent<CinemachineInputProvider>();
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {

        float z = _inputProvider.GetAxisValue(2);
        if (z != 0)
            ZoomScreen(z);
    }

    public void ZoomScreen(float increment)
    {
        float fov = _virtualCamera.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + increment, _zoomInMax, _zoomOutMax);

        _virtualCamera.m_Lens.FieldOfView = Mathf.MoveTowards(fov, target, _zoomSpeed);
    }
}
