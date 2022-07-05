using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winbox : MonoBehaviour
{

    void Start() 
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        
        GameObject.FindWithTag("Player").SendMessage("Finnish");
     
    }
}
