using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource track1Source;
    [SerializeField] private AudioSource track2Source;
    [SerializeField] private AudioSource effectsSource;

    [Header("Track Swap Settings")]
    [SerializeField] private bool playFromStart = true; 
    [SerializeField] private bool fadeTracks = true;
    [Range(0.01f, 5f)] [SerializeField] private float timeToFade = 0.25f;

    private bool track1Active = true;

    // enforce singleton design pattern
    void Awake(){
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
            Destroy(gameObject);
    }

    // play one-shot effect
    public void PlaySound(AudioClip clip){
        effectsSource.PlayOneShot(clip);
    }

    // change master volume
    public void ChangeMasterVolume(float value){
        AudioListener.volume = value;
    }

    // change music volume
    public void ChangeMusicVolume(float value){
        track1Source.volume = value;
        track2Source.volume = value;
    }

    // change effects volume
    public void ChangeEffectsVolume(float value){
        effectsSource.volume = value;
    }

    // change effects volume
    public void ChangeFadeDuration(float value){
        timeToFade = value;
    }

    // toggle music volume mute
    public void ToggleMusic(){
        track1Source.mute = !track1Source.mute;
        track2Source.mute = !track2Source.mute;
    }

    // toggle effects volume mute
    public void ToggleEffects(){
        effectsSource.mute = !effectsSource.mute;
    }

    // toggle track fading
    public void ToggleFadeTracks(){
        fadeTracks = !fadeTracks;
    }

    // toggle track fading
    public void TogglePlayFromStart(){
        playFromStart = !playFromStart;
    }

    // fade/swap from current music clip to input clip
    public void ChangeTrack(AudioClip newClip){
        StopAllCoroutines();
        StartCoroutine(FadeTrack(newClip));

        track1Active = !track1Active;
    }

    // fade/swap from current music clip to input clip
    private IEnumerator FadeTrack(AudioClip newClip){

        float timeElapsed = 0f;

        if (track1Active){
            track2Source.clip = newClip;
            if (!playFromStart) 
                track2Source.time = getStartTime(track1Source, track2Source);
            else track2Source.time = 0f;
            track2Source.Play();

            if (fadeTracks){
                float targetVolume = track1Source.volume;
                while (timeElapsed < timeToFade){
                    track2Source.volume = Mathf.Lerp(0, targetVolume, timeElapsed / timeToFade);
                    track1Source.volume = Mathf.Lerp(targetVolume, 0, timeElapsed / timeToFade);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                } 
            }
            track1Source.Stop();
        }
        else {
            track1Source.clip = newClip;
            if (!playFromStart) 
                track1Source.time = getStartTime(track2Source, track1Source);
            else track1Source.time = 0f;
            track1Source.Play();

            if (fadeTracks){
                float targetVolume = track2Source.volume;
                while (timeElapsed < timeToFade){
                    track1Source.volume = Mathf.Lerp(0, targetVolume, timeElapsed / timeToFade);
                    track2Source.volume = Mathf.Lerp(targetVolume, 0, timeElapsed / timeToFade);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                } 
            }
            track2Source.Stop();
        }

        yield return null;
    }

    private float getStartTime(AudioSource oldTrack, AudioSource newTrack){
        float startTime = oldTrack.time;
        if (startTime < newTrack.clip.length - timeToFade) return startTime;
        else return 0f;
    }
}