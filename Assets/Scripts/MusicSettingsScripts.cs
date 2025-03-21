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


    private void Awake()
    {
        currentSlider = GetComponent<Slider>();
        currentSliderImage = sliderHandle.GetComponent<Image>();
        currentSliderRect = sliderHandle.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (currentSlider.value <= 0.33f)
        {
            currentSliderRect.localScale = new Vector3(2,2.5f,1);
            currentSliderImage.sprite = lowVolumeSprite;
        }
        else if (currentSlider.value > 0.33f && currentSlider.value <= 0.66f)
        {
            currentSliderRect.localScale = new Vector3(2,2f,1);
            currentSliderImage.sprite = mediumVolumeSprite;
        }
        else
        {
            currentSliderRect.localScale = new Vector3(2,2f,1);
            currentSliderImage.sprite = highVolumeSprite;
        }
    }
}
