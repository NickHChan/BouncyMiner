using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class MusicSettingsScripts : MonoBehaviour
{
    [SerializeField] private Sprite lowVolumeSprite;
    [SerializeField] private Sprite mediumVolumeSprite;
    [SerializeField] private Sprite highVolumeSprite;
    [SerializeField] private GameObject sliderHandle;
    private Slider currentSlider;
    private Image currentSliderImage;
    private RectTransform currentSliderRect;
    private float musicVolumeValue;
    private float sfxVolumeValue;


    private void Awake()
    {
        currentSlider = GetComponent<Slider>();
        currentSliderImage = sliderHandle.GetComponent<Image>();
        currentSliderRect = sliderHandle.GetComponent<RectTransform>();
    }

    private void Start()
    {
        LoadVolumeProfile();
        
    }

    public void ChangeSliderSpriteOnVolume()
    {
        if (currentSlider.value <= 0.33f)
        {
            // currentSliderRect.localScale = new Vector3(2,2.5f,1);
            currentSliderImage.sprite = lowVolumeSprite;
            currentSliderImage.SetNativeSize();
        }
        else if (currentSlider.value > 0.33f && currentSlider.value <= 0.66f)
        {
            // currentSliderRect.localScale = new Vector3(2,2f,1);
            currentSliderImage.sprite = mediumVolumeSprite;
            currentSliderImage.SetNativeSize();
        }
        else
        {
            // currentSliderRect.localScale = new Vector3(2,2f,1);
            currentSliderImage.sprite = highVolumeSprite;
            currentSliderImage.SetNativeSize();
        }
    }

    public void SaveVolumeProfile()
    {
        if (gameObject.CompareTag("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", currentSlider.value);
        }

        if (gameObject.CompareTag("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", currentSlider.value);
        }
    }      
    public void CancelVolumeProfile()
    {
        if (gameObject.CompareTag("MusicVolume"))
        {
            currentSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (gameObject.CompareTag("SFXVolume"))
        {
            currentSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }   
    private void LoadVolumeProfile()
    {
        if (gameObject.CompareTag("MusicVolume") && PlayerPrefs.HasKey("MusicVolume"))
        {
            currentSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (gameObject.CompareTag("SFXVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {
            currentSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }
}
