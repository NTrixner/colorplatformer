using Movement;
using UnityEngine;

public class Gateway : MonoBehaviour
{
    [SerializeField] private Timer timer;

    [SerializeField] private AudioSource winTrack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>() != null)
        {
            FindObjectOfType<SceneSwapper>().LevelFinished();
            winTrack.Play();
            timer.FinishLevel();
        }
    }
}
