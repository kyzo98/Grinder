using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMinedRender : MonoBehaviour {
    public Sprite spriteMined;
    public Sprite spriteNotMined;
    public Sprite spriteNotAble;

    private SpriteRenderer spriteR;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.parent.gameObject.GetComponent<Box>().isMined)
        {
            if (gameObject.transform.parent.gameObject.GetComponent<Box>().depth < 1)
            {
                spriteR.sprite = spriteNotAble;
            }
            else
            {
                spriteR.sprite = spriteMined;
            }
        }
        else
        {
            spriteR.sprite = spriteNotMined;
        }
    }
}
