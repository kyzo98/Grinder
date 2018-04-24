using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLoot : MonoBehaviour {
    public GameObject character;

    public float minimum = 0.0f;
    public float maximum = 1.0f;
    public float duration = 0.2f;
    private float startTime = 0;
    public Text prueba;
    Vector3 startPosition;
    Vector3 target;
    public int value;

	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character");
        MoveCharacter characterControl = character.GetComponent<MoveCharacter>();
        if(value>0)
            characterControl.loot++;
        prueba = gameObject.GetComponent<Text>();
        startTime = Time.time;

        if(value < 0)
        {
            startPosition = new Vector3(characterControl.xPos - 0.25f, 5.8f, 0);
            transform.position = startPosition;
            target = new Vector3(characterControl.xPos - 0.5f, 6.2f, 0);
        }
        else if (value == 0)
        {
            startPosition = new Vector3(characterControl.xPos, 5.8f, 0);
            transform.position = startPosition;
            target = new Vector3(characterControl.xPos, 6.2f, 0);
        }
        else
        {
            startPosition = new Vector3(characterControl.xPos + 0.25f, 5.8f, 0);
            transform.position = startPosition;
            target = new Vector3(characterControl.xPos + 0.5f, 6.2f, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float t = (Time.time - startTime) / duration * 4;
        transform.position = Vector3.Lerp(startPosition, target, t);
        if (value < 0)
        {
            prueba.color = new Color(1f, 0f, 0f, Mathf.SmoothStep(maximum, minimum, t));
            prueba.text = string.Concat(value.ToString());
        }
        else if (value == 0)
        {
            prueba.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
            prueba.text = string.Concat(value.ToString());
        }
        else
        {
            prueba.color = new Color(0f, 1f, 0f, Mathf.SmoothStep(maximum, minimum, t));
            prueba.text = string.Concat("+", value.ToString());
        }
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject, 1.5f);
    }
}
