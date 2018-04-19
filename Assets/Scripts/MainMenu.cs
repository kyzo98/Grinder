using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour {

    public string SceneToLoad = "Arcade";
    
    public void Start()
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }
    
}
