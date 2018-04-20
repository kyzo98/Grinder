using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class LoadMenu : MonoBehaviour {

    public string SceneToLoad = "Menu";

    public Image grinder;

    IEnumerator Start()
    {
        grinder.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);

    }

    void FadeIn()
    {
        grinder.CrossFadeAlpha(1.0f, 1.0f, false);
    }

}
