using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private Color _defaultTextColor;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonText.color = Color.white;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonText.color = _defaultTextColor; 
    }
}
