using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // ---- / Serialized Variables / ---- //
    [SerializeField] private GameObject settingsMenu;
    
    public void Play()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        settingsMenu.SetActive(false);
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }
}
