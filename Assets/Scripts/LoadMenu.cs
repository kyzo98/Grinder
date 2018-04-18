using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadMenu : MonoBehaviour {

    public string SceneToLoad = "Menu";
    public float DelayTime = 4.0f;
    public void Start()
    {
        StartCoroutine("Wait");
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(DelayTime);

        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);

    }
}
