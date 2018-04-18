using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clouds : MonoBehaviour {
    public GameObject cloud;
    float timer;
    float absoluteTime;
    // Use this for initialization
    void Start () {
        absoluteTime = 4.0f;
        timer = absoluteTime;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0) {
            GameObject newCloud = Instantiate(cloud, new Vector3(0, 8, 0), Quaternion.identity) as GameObject;
            newCloud.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            RectTransform newCloudRT = newCloud.GetComponent<RectTransform>();
            newCloudRT.SetAsFirstSibling();
            timer = absoluteTime;
        }
    }
}
