using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int mainSceneIndex;
    public float transitionTime = 3f;
    public Transition transition;

    public void LoadMainScene() {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene() {
        transition.AnimateIn();

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(mainSceneIndex);
    }
}
