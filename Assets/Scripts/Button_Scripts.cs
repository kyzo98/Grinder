using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Scripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSurvey()
    {
        Application.OpenURL("https://goo.gl/forms/RyOX1cJq6bgdiajF2");
    }
}
