using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    [SerializeField] private int index = 0;

    public string[] levels = new[]
    {
        "level1",
        "level2",
        "level3"
    };
    
    public void LoadNextLevel()
    {
        index++;
        ReloadLevel();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(levels[index]);
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}