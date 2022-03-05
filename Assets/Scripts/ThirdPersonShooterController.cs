using UnityEngine;
using Cinemachine;
using Movement;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalCameraSensitivity = 1f;
    [SerializeField] private float aimSensitivity = 0.5f;
    private Inputs inputs;
    private ThirdPersonController thirdPersonController;

    private void Awake()
    {
        inputs = FindObjectOfType<Inputs>();
        thirdPersonController = FindObjectOfType<ThirdPersonController>();
    }

    void Update()
    {
        if (inputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetCameraSensitivity(aimSensitivity);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetCameraSensitivity(normalCameraSensitivity);
        }

    }
}
