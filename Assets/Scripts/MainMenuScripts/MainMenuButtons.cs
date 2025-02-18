using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject ZenModePopUp;
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

    public void PlayZenMode()
    {
        ZenModePopUp.SetActive(true);
    }
}
