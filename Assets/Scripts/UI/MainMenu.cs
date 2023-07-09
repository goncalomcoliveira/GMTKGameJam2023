using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioClip theme;
    public SceneChanger sc;

    void Start()
    {
        SoundManager.Instance.ChangeTrack(theme);
    }

    public void PlayGame() {
        sc.LoadMainScene();
    }

    public void QuitGame() {
        Application.Quit();
    }
}
