using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        SoundManager.Instance.ChangeFadeDuration(slider.value);
        slider.onValueChanged.AddListener(
            value => SoundManager.Instance.ChangeFadeDuration(value)
        );
    }
}