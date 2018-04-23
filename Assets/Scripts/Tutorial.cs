using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public Text tutorialText;

	// Use this for initialization
	void Start () {
        tutorialText.text = "Tu objetivo es alcanzar la mayor profunidad. Pulsa las flechas para moverte.";
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
