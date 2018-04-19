using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScene2 : MonoBehaviour {

    public string SceneToLoad = "GrinderTitleScene";
    public float DelayTime = 3.0f;
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

    