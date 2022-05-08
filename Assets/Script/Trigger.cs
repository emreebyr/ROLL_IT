using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Events.UnityEvent<string> triggerEvent;

    int score = 0 ;
   private void OnTriggerEnter(Collider other) {
       Destroy (other.gameObject);
       score  ++ ;
       Debug.Log ("score"+score);

       triggerEvent.Invoke (score.ToString());

       
   }
}
