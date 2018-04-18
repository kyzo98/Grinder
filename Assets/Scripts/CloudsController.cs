using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour {
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed;
    private float startTime;
    private float journeyLength;

    // Use this for initialization
    void Start () {
        int ypos = Random.Range(-3, 5);
        startTime = Time.time;
        pos1 = new Vector3(-5, ypos, 0);
        pos2 = new Vector3(5, ypos, 0);
        journeyLength = Vector3.Distance(pos1, pos2);
        transform.position = pos1;
        speed = Random.Range(0.5F, 1.5F);
    }
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(pos1, pos2, fracJourney);

        if (transform.position == pos2) {
            DestroyGameObject();
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
