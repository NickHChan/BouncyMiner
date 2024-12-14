using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Player.ResetPlayerScore();
        Player.ResetPlayerHealth();
        Tools.ResetToolDurability();
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }


}
