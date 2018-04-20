using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class JumpScene2 : MonoBehaviour {

    public string SceneToLoad = "GrinderTitleScene";

    public Image akona;
   
     IEnumerator Start()
    {
       akona.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(3.0f); 

        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);

    }

    void FadeIn()
    {
        akona.CrossFadeAlpha(1.0f, 1.0f, false); 
    }

} 

    