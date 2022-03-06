using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject levelsMenu;

    [SerializeField] private Button[] LevelButtons;

    public void Awake()
    {
        OpenMainMenu();
        LevelButtons[0].interactable = true;
        for (int i = 1; i < LevelButtons.Length; i++)
        {
            ActivateLevelButton(i);
        }
        
        FindObjectOfType<GlobalSoundProvider>().StartMenu();
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
        levelsMenu.SetActive(false);
    }

    public void OpenControlsMenu()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
        levelsMenu.SetActive(false);
    }
    
    public void OpenLevelsMenu()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    public void ActivateLevelButton(int index)
    {
        LevelButtons[index].interactable = PlayerPrefs.HasKey("FinishLevel" + (index-1)) &&
                                           PlayerPrefs.GetInt("FinishLevel" + (index-1)) == 1;
    }
}