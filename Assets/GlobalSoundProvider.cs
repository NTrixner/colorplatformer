using UnityEngine;

public class GlobalSoundProvider : MonoBehaviour
{
    public void Click()
    {
        FindObjectOfType<GlobalSound>().Click();
    }
    
    public void Splatter()
    {
        FindObjectOfType<GlobalSound>().Splatter();
    }

    public void StartMenu()
    {
        FindObjectOfType<GlobalSound>().StartMenu();
    }
    
    public void StartLevel()
    {
        FindObjectOfType<GlobalSound>().StartLevel();
    }
}
