using UnityEngine;

public class ZenmodePopUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void OnClickOkButton()
    {
        gameObject.SetActive(false);
    }
}
