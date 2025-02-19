using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject ZenModePopUp;
    [SerializeField] private GameObject SettingsPopUp;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ZenModePopUp.SetActive(false);
        }
    }

    
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsPopUpButton()
    {
        SettingsPopUp.SetActive(true);
    }

    public void PlayZenMode()
    {
        ZenModePopUp.SetActive(true);
    }
}
