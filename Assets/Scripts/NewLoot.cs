using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLoot : MonoBehaviour {

    public float minimum = 0.0f;
    public float maximum = 1.0f;
    public float duration = 0.2f;
    private float startTime = 0;
    public Text prueba;
    Vector3 startPosition;
    Vector3 target;
    public string value;

	// Use this for initialization
	void Start () {
        prueba = gameObject.GetComponent<Text>();
        startTime = Time.time;
        startPosition = new Vector3(0, 7.8f, 0);
        transform.position = startPosition;
        target = new Vector3(0, 8.2f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        float t = (Time.time - startTime) / duration * 4;
        transform.position = Vector3.Lerp(startPosition, target, t);
        prueba.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
        if(value == "0")
            prueba.text = string.Concat("Same");
        else
            prueba.text = string.Concat("+", value);
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject, 1.5f);
    }
}
