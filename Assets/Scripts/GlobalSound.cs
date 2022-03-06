using UnityEngine;

public class GlobalSound : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private AudioSource splatter;
    private void Awake()
    {
        GlobalSound[] objs = FindObjectsOfType<GlobalSound>();

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Click()
    {
        clickSound.Play();
    }

    public void StartMenu()
    {
        menuMusic.Play();
    }

    public void StopMenu()
    {
        menuMusic.Stop();
    }

    public void StartLevel()
    {
        levelMusic.Play();
    }

    public void StopLevel()
    {
        levelMusic.Stop();
    }

    public void Splatter()
    {
        splatter.Play();
    }
}
