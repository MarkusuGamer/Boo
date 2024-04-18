using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // ---- / Serialized Variables / ---- //
    [SerializeField] private GameObject settingsMenu;
    
    public void Play()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
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
}
