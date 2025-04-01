using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScripts : MonoBehaviour
{
    [SerializeField] private Toggle tutorialToggle;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        LoadTutorialToggle();
    }

    public void CancelButton()
    {
;       gameObject.SetActive(false);
    }

    public void SaveButton()
    {
        gameObject.SetActive(false);
    }

    private void LoadTutorialToggle()
    {
        if (!PlayerPrefs.HasKey("NeedTutorial")) return;
        tutorialToggle.isOn = PlayerPrefs.GetInt("NeedTutorial") == 1;
    }

    public void SaveTutorialToggle()
    {
        PlayerPrefs.SetInt("NeedTutorial", tutorialToggle.isOn ? 1 : 0);
    }

    public void CancelTutorialToggle()
    {
        PlayerPrefs.SetInt("NeedTutorial", tutorialToggle.isOn ? 1 : 0);
    }
}
