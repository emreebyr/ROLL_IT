using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform Player;

    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = Player.position.z.ToString("0");
        
    }
}
