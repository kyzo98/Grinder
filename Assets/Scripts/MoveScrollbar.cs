using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScrollbar : MonoBehaviour {
    public float xPos;
    public float yPos;
    // Use this for initialization
    void Start () {
        xPos = 0.8f;
        yPos = 5f;
        transform.position = new Vector3(xPos, yPos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(xPos, yPos, 0);
    }
}

