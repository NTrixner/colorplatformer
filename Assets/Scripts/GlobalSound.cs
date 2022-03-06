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
        if(!menuMusic.isPlaying)
            menuMusic.Play();
        if(levelMusic.isPlaying)
            levelMusic.Stop();
    }

    public void StartLevel()
    {        
        if(!levelMusic.isPlaying)
            levelMusic.Play();
        if(menuMusic.isPlaying)
            menuMusic.Stop();
    }

    public void Splatter()
    {
        splatter.Play();
    }
}
