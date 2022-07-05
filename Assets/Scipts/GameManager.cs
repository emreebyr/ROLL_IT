using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{  
    public static bool gameOver;
    public GameObject gameOverPanel;
    public float threshold =-1f;
    public RoadController Control2;
    public PlayerController Control;
    


    void Start()
    {
        Control = GetComponent<PlayerController>();
        gameOver = false;
        Control2 = GetComponent<RoadController>();
        
    }

    void Update()
    {
        if(transform.position.y < threshold)
        {
           GameObject.FindWithTag("Player").SendMessage("Finnish");
     
            


        }
    }

         void OnTriggerEnter(Collider other )
        {
            if(other.gameObject.tag=="Obstacle")
            {
               GameObject.FindWithTag("Player").SendMessage("Finnish");
         
     
            }

            if(other.gameObject.tag=="Boost+")
            {
               Control.ForwardSpeed += 5f;
            }

             if(other.gameObject.tag=="Boost-")
            {
               Control.ForwardSpeed -= 5f;

            }

             if(other.gameObject.tag=="Coin")
            {
              
              Destroy (other.gameObject);
              Control.score++;
              
              //(Control.score.ToString());
            }
        }


    void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time);
    }
}           
                            
                    