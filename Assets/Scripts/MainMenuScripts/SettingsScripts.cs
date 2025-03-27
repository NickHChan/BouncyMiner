using UnityEngine;

public class SettingsScripts : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void CancelButton()
    {
;       gameObject.SetActive(false);
    }

    public void SaveButton()
    {
        gameObject.SetActive(false);
    }
}
