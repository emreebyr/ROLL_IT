using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private PlayerController Control;
    [SerializeField] public float swerveSpeed;
    [SerializeField] public float maxSwerveAmount;
    
    private void Awake()
    {
        Control = GetComponent<PlayerController>();
    }

    private void Update()
    {   
        float swerveAmount = Time.deltaTime * swerveSpeed * Control.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
    }
}
