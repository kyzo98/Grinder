using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCharacter : MonoBehaviour {
    public enum Move { Down, Right, Left, None };
    public GameObject box;
    public Image scrollBar;
    public GameObject GameOverCanvas; 
    public GameObject PauseCanvas; 

    public float fadeTime = 1.0f;

    public Text mincedText;
    public Text depthText;
    public Text gameOverDepthText;
    public Text gameOverLootText;
    public Text newLootText;
    public Text renderCanvas;

    public Move lastMove;

    public int xPos;
    public int yPos;

    public int moves;

    int depth;
    public int loot;
    public float absoluteTurnTime;
    public float turnTime;

    bool orientation;
    bool temporizador;
    public bool pauseToggle;


    public Animator anim;
    public bool gameOver;

    public bool moving;
    float absoluteMoveTime;
    float moveTime;

    // Use this for initialization
    void Start () {
        moving = false;
        Time.timeScale = 1;
        yPos = 5;
        lastMove = Move.Down;
        depth = 0;
        loot = 0;
        moves = 15;
        gameOver = GameOver();
        InicialiceMap(depth - 2);
        transform.position = new Vector3(xPos, yPos, 0);
        RefreshValues();
        turnTime = absoluteTurnTime;
        orientation = true;
        temporizador = false;
        pauseToggle = false;
        anim = gameObject.GetComponent<Animator>();
        absoluteMoveTime = 0.2f;
        moveTime = absoluteMoveTime;
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Down", false);
        anim.SetBool("Lateral", false);
        gameOver = GameOver();
        if (!gameOver)
        {
            //Orientación del pj
            if (!orientation)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            //Temporizador scroll
            if (temporizador)
            {
                turnTime -= Time.deltaTime;
                if (turnTime <= 0)
                {
                    moves--;
                    turnTime = absoluteTurnTime;
                }
                scrollBar.fillAmount = turnTime / absoluteTurnTime;
            }
            //Movimiento
            if (!moving)
            {
                if (Input.GetKeyDown("left") && !Input.GetKeyDown("down") && !pauseToggle)
                {
                    orientation = false;
                    lastMove = Move.Left;
                    if (xPos != -4)
                    {
                        xPos -= 2;
                        moving = true;
                    }
                    //transform.position = new Vector3(xPos, yPos, 0);
                    
                }
                if (Input.GetKeyDown("right") && !Input.GetKeyDown("down") && !pauseToggle)
                {
                    orientation = true;
                    lastMove = Move.Right;
                    if (xPos != 4)
                    {
                        xPos += 2;
                        moving = true;
                    }
                    //transform.position = new Vector3(xPos, yPos, 0);
                    
                }
                if (Input.GetKeyDown("down") && (!Input.GetKeyDown("left") || Input.GetKeyDown("right")) && !pauseToggle)
                {
                    anim.SetBool("Down", true);
                    moving = true;
                    lastMove = Move.Down;
                    if (!temporizador)
                        temporizador = true;
                }
            }
            else
            {
                StopMoving(lastMove);
            }

            //Pausa
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseFunc();
            }
        }
        else
        {
            moves = 0;
            //Cambiar a la escena gameover
            gameOverDepthText.text = depth.ToString();
            gameOverLootText.text = loot.ToString();
            GameOverCanvas.SetActive(true);
        }
        RefreshValues();
    }

    //Instancia el mapa de box
    void InicialiceMap(int depth_)
    {
        for (int i = 9; i > -10; i = i - 2)
        {
            for (int j = -4; j < 5; j = j + 2)
            {
                GameObject newBox = box;
                Box boxControl = newBox.GetComponent<Box>();
                boxControl.xpos = j;
                boxControl.ypos = i;
                boxControl.depth = depth_;
                boxControl.isMined = false;
                Instantiate(newBox);
            }
            depth_++;
        }
    }

    //Recarga los valores en la UI
    void RefreshValues()
    {
        mincedText.text = moves.ToString();
        depthText.text = depth.ToString();
    }

    //Genera box al moverse
    void BoxMove(int depth_)
    {
        for (int j = -4; j < 5; j = j + 2)
        {
            GameObject newBox = box;
            Box boxControl = newBox.GetComponent<Box>();
            boxControl.xpos = j;
            boxControl.ypos = -9;
            boxControl.depth = depth_;
            boxControl.isMined = false;
            Instantiate(newBox);
        }
    }

    //Moving stop
    void StopMoving(Move lastMove_)
    {
        moveTime -= Time.deltaTime;
        if(moveTime <= 0)
        {
            switch (lastMove_)
            {
                case Move.Left:
                    transform.position = new Vector3(xPos, yPos, 0);
                    break;
                case Move.Right:
                    transform.position = new Vector3(xPos, yPos, 0);
                    break;
                case Move.Down:
                    BoxMove(depth + 9);
                    depth++;
                    break;
            }
            moveTime = absoluteMoveTime;
            moving = false;
        }
    }

    //Pause
    public void PauseFunc()
    {
        if (pauseToggle)
        {
            PauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }
        pauseToggle = !pauseToggle;
    }
    //Si te quedas sin picadas pierdes
    bool GameOver()
    {
        return moves <= 0;
    }
}
