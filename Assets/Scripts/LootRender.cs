using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRender : MonoBehaviour {
    enum Loot { Nothing, Coal, Quartz, Diamond, Silver, Gold, Ruby, Emerald, Coltan, Obsidian };

    public Sprite spriteNothing;
    public Sprite spriteCoal;
    public Sprite spriteQuartz;
    public Sprite spriteDiamond;
    public Sprite spriteSilver;
    public Sprite spriteGold;
    public Sprite spriteRuby;
    public Sprite spriteEmerald;
    public Sprite spriteColtan;
    public Sprite spriteObsidian;


    private SpriteRenderer spriteR;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        switch (gameObject.transform.parent.gameObject.GetComponent<Box>().loot)
        {
            case Box.Loot.Nothing:
                spriteR.sprite = spriteNothing;
                break;
            case Box.Loot.Coal:
                spriteR.sprite = spriteCoal;
                break;
            case Box.Loot.Quartz:
                spriteR.sprite = spriteQuartz;
                break;
            case Box.Loot.Diamond:
                spriteR.sprite = spriteDiamond;
                break;
            case Box.Loot.Silver:
                spriteR.sprite = spriteSilver;
                break;
            case Box.Loot.Gold:
                spriteR.sprite = spriteGold;
                break;
            case Box.Loot.Ruby:
                spriteR.sprite = spriteRuby;
                break;
            case Box.Loot.Emerald:
                spriteR.sprite = spriteEmerald;
                break;
            case Box.Loot.Coltan:
                spriteR.sprite = spriteColtan;
                break;
            case Box.Loot.Obsidian:
                spriteR.sprite = spriteObsidian;
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.parent.gameObject.GetComponent<Box>().isMined)
        {
            spriteR.sprite = spriteNothing;
        }
	}
}
