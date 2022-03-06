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

    public void LevelFinished()
    {
        PlayerPrefs.SetInt("FinishLevel"+index, 1);
    }

    public void LoadLevel(int index)
    {
        this.index = index;
        ReloadLevel();
    }
    
    public void LoadNextLevel()
    {
        index++;
        ReloadLevel();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(levels[index]);
        FindObjectOfType<GlobalSoundProvider>().StartLevel();
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Menu");
        FindObjectOfType<GlobalSoundProvider>().StartMenu();
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}