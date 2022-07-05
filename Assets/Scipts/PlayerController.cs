using System.Net.Mime;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float ForwardSpeed;
    public float BoostSpeed;
    public Touch touch;
    public float speedModifier;
    public GameObject startingText;
    public Animator player_animation;
    public GameManager Control;
    private float startTime;
    public bool finnished = false;
    public bool GoForward;
    public Camera Camera;
    public GameObject Player;
    public TextMeshProUGUI TimerTextPro;
    public static bool gameOver;
    public GameObject gameOverPanel;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    public TextMeshProUGUI coinscore;

    public int score=-1;

    public GameObject StartingPanel;

    public GameObject  PlayingPanel;

    public GameObject  MarketPanel;
    
    void Start()
    {
        player_animation= gameObject.GetComponent<Animator>();
        Control = GetComponent<GameManager>();
        GoForward= false;
        


        GameManager.gameOver=false;

        
        

        Camera.transform.DOMoveY(Player.transform.position.y,2f);
        Camera.transform.DOMoveZ(Player.transform.position.z+40,2f);
        
        
    }

    void Update()
    {   
            if (finnished)
            return;  
            float t = Time.time - startTime;
            string minutes = ((int) t /60) . ToString();
            string seconds = (t % 60).ToString("f2");
            TimerTextPro.text = minutes + ":" + seconds;
            coinscore.text = "Coin" + ":" + score;
            
            Debug.Log(score);

            if(GoForward)
            {
                transform.position = transform.position + new Vector3(0,0,ForwardSpeed*BoostSpeed*Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0))
            {   
                _lastFrameFingerPositionX = Input.mousePosition.x;
                GoForward = true;
                Destroy(startingText);
                player_animation.SetBool("Go",true);
                
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
                BoostSpeed=1.1f;
                
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
                BoostSpeed=1;
                

            }
           
        if (Input.touchCount>0)
        {   
            
            touch = Input.GetTouch(0);
            GoForward = true;
            Destroy(startingText);
            player_animation.SetBool("Go",true);

            if (touch.phase == TouchPhase.Moved && GoForward== true)
            {
                
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x,-4f,4f) + touch.deltaPosition.x * speedModifier/200,
                    transform.position.y,
                    transform.position.z
                );
            }
        }
    }

        public void Finnish()
        {   
            player_animation.SetBool("Go",false);
            TimerTextPro.color = Color.yellow;
            Invoke("GameFinish",3f);
            finnished = true;
            GoForward = false;

        }

            public void GameFinish()

            {   
                gameOverPanel.SetActive(true);
                Destroy(TimerTextPro);     
                PlayingPanel.SetActive(false);

            }
}