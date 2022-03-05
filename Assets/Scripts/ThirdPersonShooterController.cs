using UnityEngine;
using Cinemachine;
using Movement;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalCameraSensitivity = 1f;
    [SerializeField] private float aimSensitivity = 0.5f;
    [SerializeField] private Image reticle;
    private Inputs inputs;
    private ThirdPersonController thirdPersonController;

    private void Awake()
    {
        inputs = FindObjectOfType<Inputs>();
        thirdPersonController = FindObjectOfType<ThirdPersonController>();
    }

    void FixedUpdate()
    {
        if (inputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            reticle.gameObject.SetActive(true);
            thirdPersonController.SetCameraSensitivity(aimSensitivity);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            reticle.gameObject.SetActive(false);
            thirdPersonController.SetCameraSensitivity(normalCameraSensitivity);
        }

    }
}
