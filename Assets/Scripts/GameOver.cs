using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public void PlayGame()
    {
        Application.LoadLevel("Arcade");
    }

    public void MainMenu()
    {


        Application.LoadLevel("Menu");
    }
}
