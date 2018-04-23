using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public GameObject character;
    public GameObject newLoot;

    public enum Ground { Sky, Grass, Soil, Rock, Sand, Stone, Coal_Rock, Organic_Strata, Petroleum, Vegetal_Sediment, Frost, Snow, Ice, Ice_Rock, Soul_Sand, Lava, Bone_Tomb, Infernal_Rock };
    public enum Loot { Nothing, Coal, Quartz, Diamond, Silver, Gold, Ruby };

    public Ground ground;
    public Loot loot;

    public bool isMined;
    public int depth;
    public int value;

    public int xpos;
    public int ypos;

    //Earth
    public Sprite skySprite;
    public Sprite grassSprite;
    public Sprite soilSprite;
    public Sprite rockSprite;
    public Sprite sandSprite;
    public Sprite stoneSprite;

    //Coal
    public Sprite coal_rockSprite;
    public Sprite organic_strataSprite;
    public Sprite petroleumSprite;
    public Sprite vegetal_sedimentSprite;

    //Snow
    public Sprite frostSprite;
    public Sprite snowSprite;
    public Sprite iceSprite;
    public Sprite ice_rockSprite;

    //Infernal
    public Sprite soul_sandSprite;
    public Sprite lavaSprite;
    public Sprite bone_tombSprite;
    public Sprite infernal_rockSprite;

    private SpriteRenderer spriteR;

    void Start()
    {
        transform.position = new Vector3(xpos, ypos, 0);
        spriteR = gameObject.GetComponent<SpriteRenderer>();

        GroundRandomizer();
        LootRandomizer();
        GroundSprite(ground);
        ValueGenerator(ground, loot);
    }

    // Update is called once per frame
    void Update()
    {
        character = GameObject.Find("Character");
        MoveCharacter characterControl = character.GetComponent<MoveCharacter>();
        if (!characterControl.gameOver)
        {
            if (!characterControl.pauseToggle && Input.GetKeyDown("down") && (!Input.GetKeyDown("left") || Input.GetKeyDown("right")))
            {
                ypos += 2;
                transform.position = new Vector3(xpos, ypos, 0);
            }
            if (xpos == character.transform.position.x && ypos == character.transform.position.y)
            {
                if (!isMined)
                {
                    characterControl.moves += value;
                    characterControl.turnTime = characterControl.absoluteTurnTime;
                    isMined = true;
                    if (loot != Loot.Nothing)
                    {
                        GameObject newNewLoot = Instantiate(newLoot, new Vector3(0, 8, 0), Quaternion.identity) as GameObject;
                        newNewLoot.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                        NewLoot newLootControl = newNewLoot.GetComponent<NewLoot>();
                        newLootControl.value = value.ToString();
                    }
                    loot = Loot.Nothing; 
                }
            }
            if (ypos > 10)
            {
                DestroyGameObject();
            }
        }
        else
        {
            
        }
    }

    //A cada tipo de ground le asignamos su sprite
    void GroundSprite(Ground ground)
    {
        switch (ground)
        {
            case Ground.Sky:
                spriteR.sprite = skySprite;
                break;
            case Ground.Grass:
                spriteR.sprite = grassSprite;
                break;
            case Ground.Soil:
                spriteR.sprite = soilSprite;
                break;
            case Ground.Rock:
                spriteR.sprite = rockSprite;
                break;
            case Ground.Sand:
                spriteR.sprite = sandSprite;
                break;
            case Ground.Stone:
                spriteR.sprite = stoneSprite;
                break;
            case Ground.Coal_Rock:
                spriteR.sprite = coal_rockSprite;
                break;
            case Ground.Organic_Strata:
                spriteR.sprite = organic_strataSprite;
                break;
            case Ground.Petroleum:
                spriteR.sprite = petroleumSprite;
                break;
            case Ground.Vegetal_Sediment:
                spriteR.sprite = vegetal_sedimentSprite;
                break;
            case Ground.Frost:
                spriteR.sprite = frostSprite;
                break;
            case Ground.Snow:
                spriteR.sprite = snowSprite;
                break;
            case Ground.Ice:
                spriteR.sprite = iceSprite;
                break;
            case Ground.Ice_Rock:
                spriteR.sprite = ice_rockSprite;
                break;
            case Ground.Soul_Sand:
                spriteR.sprite = soul_sandSprite;
                break;
            case Ground.Lava:
                spriteR.sprite = lavaSprite;
                break;
            case Ground.Bone_Tomb:
                spriteR.sprite = bone_tombSprite;
                break;
            case Ground.Infernal_Rock:
                spriteR.sprite = infernal_rockSprite;
                break;
            default:
                break;
        }
    }

    //Genera el valor de cada casilla dependiendo el tipo de ground y de loot
    void ValueGenerator(Ground ground, Loot loot)
    {
        switch (ground)
        {
            case Ground.Sky:
                value = 0;
                break;
            case Ground.Grass:
                value = -1;
                break;
            case Ground.Soil:
                value = -1;
                break;
            case Ground.Rock:
                value = -2;
                break;
            case Ground.Sand:
                value = 0;
                break;
            case Ground.Stone:
                value = -4;
                break;
            case Ground.Coal_Rock:
                value = -5;
                break;
            case Ground.Organic_Strata:
                value = -3;
                break;
            case Ground.Petroleum:
                value = -2;
                break;
            case Ground.Vegetal_Sediment:
                value = -1;
                break;
            case Ground.Frost:
                value = -2;
                break;
            case Ground.Snow:
                value = -3;
                break;
            case Ground.Ice:
                value = -4;
                break;
            case Ground.Ice_Rock:
                value = -5;
                break;
            case Ground.Soul_Sand:
                value = -4;
                break;
            case Ground.Lava:
                value = -1;
                break;
            case Ground.Bone_Tomb:
                value = -5;
                break;
            case Ground.Infernal_Rock:
                value = -7;
                break;
            default:
                break;
        }
        switch (loot)
        {
            case Loot.Coal:
                value += Random.Range(1, 3);
                break;
            case Loot.Quartz:
                value += Random.Range(6, 8);
                break;
            case Loot.Diamond:
                value += Random.Range(14, 16);
                break;
            case Loot.Silver:
                value += Random.Range(3, 4);
                break;
            case Loot.Gold:
                value += Random.Range(4, 6);
                break;
            case Loot.Ruby:
                value += Random.Range(10, 12);
                break;
            default:
                break;
        }
    }

    void GroundRandomizer()
    {
        int randomizer = Random.Range(0, 100);
        if (depth < 1)
        {
            ground = Ground.Sky;
            isMined = true;
        }
        else if (depth == 1)
        {
            ground = Ground.Grass;
        }
        else if(depth > 1 && depth <= 100)
        {
            if(randomizer % 20 == 0)
            {
                ground = Ground.Sand;
            }
            else if(randomizer % 10 == 0)
            {
                ground = Ground.Soil;
            }
            else if(randomizer + depth > 110)
            {
                ground = Ground.Stone;
            }
            else if (randomizer + depth > 70)
            {
                ground = Ground.Rock;
            }
            else
            {
                ground = Ground.Soil;
            }
        }
        else if (depth > 100 && depth <= 250)
        {
            if (randomizer % 20 == 0)
            {
                ground = Ground.Petroleum;
            }
            else if (randomizer % 10 == 0)
            {
                ground = Ground.Vegetal_Sediment;
            }
            else if (randomizer + depth > 210)
            {
                ground = Ground.Organic_Strata;
            }
            else if (randomizer + depth > 170)
            {
                ground = Ground.Coal_Rock;
            }
            else
            {
                ground = Ground.Vegetal_Sediment;
            }
        }
        else if (depth > 250 && depth <= 500)
        {
            if (randomizer % 20 == 0)
            {
                ground = Ground.Frost;
            }
            else if(randomizer % 10 == 0)
            {
                ground = Ground.Snow;
            }
            else if (randomizer + depth > 310)
            {
                ground = Ground.Ice;
            }
            else if (randomizer + depth > 270)
            {
                ground = Ground.Ice_Rock;
            }
        }
        else
        {
            if (randomizer % 20 == 0)
            {
                ground = Ground.Lava;
            }
            else if (randomizer % 10 == 0)
            {
                ground = Ground.Soul_Sand;
            }
            else if (randomizer + depth > 410)
            {
                ground = Ground.Bone_Tomb;
            }
            else if (randomizer + depth > 370)
            {
                ground = Ground.Infernal_Rock;
            }
        }
    }

    void LootRandomizer()
    {
        int randomizer2 = Random.Range(0, 9999);
        if (randomizer2 % 10 <= 1)
        {
            randomizer2 /= 10;
            if (ground == Ground.Soil)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Coal;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Silver;
                }
                else
                {
                    loot = Loot.Gold;
                }
            }
            else if (ground == Ground.Rock)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Silver;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Gold;
                }
                else
                {
                    loot = Loot.Quartz;
                }
            }
            else if (ground == Ground.Stone)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Gold;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Quartz;
                }
                else if (randomizer2 <= 900)
                {
                    loot = Loot.Ruby;
                }
                else
                {
                    loot = Loot.Diamond;
                }
            }
            else if (ground == Ground.Vegetal_Sediment)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Coal;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Silver;
                }
                else
                {
                    loot = Loot.Gold;
                }
            }
            else if (ground == Ground.Petroleum)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Silver;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Gold;
                }
                else
                {
                    loot = Loot.Quartz;
                }
            }
            else if (ground == Ground.Organic_Strata)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Silver;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Gold;
                }
                else
                {
                    loot = Loot.Quartz;
                }
            }
            else if (ground == Ground.Coal_Rock)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Gold;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Quartz;
                }
                else if (randomizer2 <= 900)
                {
                    loot = Loot.Ruby;
                }
                else
                {
                    loot = Loot.Diamond;
                }
            }
            else if (ground == Ground.Frost)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Coal;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Silver;
                }
                else
                {
                    loot = Loot.Gold;
                }
            }
            else if (ground == Ground.Snow)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Coal;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Silver;
                }
                else
                {
                    loot = Loot.Gold;
                }
            }
            else if (ground == Ground.Ice)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Silver;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Gold;
                }
                else
                {
                    loot = Loot.Quartz;
                }
            }
            else if (ground == Ground.Ice_Rock)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Gold;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Quartz;
                }
                else if (randomizer2 <= 900)
                {
                    loot = Loot.Ruby;
                }
                else
                {
                    loot = Loot.Diamond;
                }
            }
            else if (ground == Ground.Lava)
            {
                loot = Loot.Nothing;
            }
            else if (ground == Ground.Soul_Sand)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Silver;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Gold;
                }
                else
                {
                    loot = Loot.Quartz;
                }
            }
            else if (ground == Ground.Bone_Tomb)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Silver;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Gold;
                }
                else
                {
                    loot = Loot.Quartz;
                }
            }
            else if (ground == Ground.Infernal_Rock)
            {
                if (randomizer2 <= 500)
                {
                    loot = Loot.Gold;
                }
                else if (randomizer2 <= 800)
                {
                    loot = Loot.Quartz;
                }
                else if (randomizer2 <= 900)
                {
                    loot = Loot.Ruby;
                }
                else
                {
                    loot = Loot.Diamond;
                }
            }
        }
        else
        {
            loot = Loot.Nothing;
        }
    }

    //Destruye las box sobrantes
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}