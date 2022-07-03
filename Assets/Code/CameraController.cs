using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;

    private void Awake() => _virtualCamera = GetComponent<CinemachineVirtualCamera>();

    public void ComposerLookAt(Transform transform) => 
        _virtualCamera.LookAt = transform;

    public void SetComposerTrackedObjectOffsetY(float value) => 
        _virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y = value;
}