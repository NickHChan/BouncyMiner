using UnityEngine;

public class BunnyMainMenuQuitGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bunny has quit the game");
        Application.Quit();
    }
}
