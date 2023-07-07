using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum SliderControl {
    Master, 
    Music, 
    Effects
};

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SliderControl control = SliderControl.Master;

    void Start()
    {
        if (control == SliderControl.Master){
            SoundManager.Instance.ChangeMasterVolume(slider.value);
            slider.onValueChanged.AddListener(
                value => SoundManager.Instance.ChangeMasterVolume(value)
            );
        }
        else if (control == SliderControl.Music){
            SoundManager.Instance.ChangeMusicVolume(slider.value);
            slider.onValueChanged.AddListener(
                value => SoundManager.Instance.ChangeMusicVolume(value)
            );
        }
        else {
            SoundManager.Instance.ChangeEffectsVolume(slider.value);
            slider.onValueChanged.AddListener(
                value => SoundManager.Instance.ChangeEffectsVolume(value)
            );
        }
    }
}