using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private InteractableBike interactableBike;
    private CinemachineVirtualCamera gameCam;

    private void OnEnable()
    {
        interactableBike.onIndicate_RagdollFalling += FinishCamera;
        GameManager.onWinGame += FinishCamera;
    }

    private void OnDisable()
    {
        interactableBike.onIndicate_RagdollFalling -= FinishCamera;
        GameManager.onWinGame -= FinishCamera;
    }

    private void Awake()
    {
        gameCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void FinishCamera()
    {
        gameCam.LookAt = null;
        gameCam.Follow = null;
    }
}
