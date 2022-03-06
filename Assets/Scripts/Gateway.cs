using Movement;
using UnityEngine;

public class Gateway : MonoBehaviour
{
    [SerializeField] private Timer timer;

    [SerializeField] private GameObject gameOverGraphics;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>() != null)
        {
            FindObjectOfType<SceneSwapper>().LevelFinished();
            timer.FinishLevel();
        }
    }
}
