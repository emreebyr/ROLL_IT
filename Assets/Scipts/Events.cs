using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Events : MonoBehaviour
{


    public GameObject  PlayingPanel;
    public GameObject  StartingPanel;

    public GameObject  MarketPanel;

    public GameObject  Player;
    public GameObject  Player1;
    public GameObject  Player2;
    public GameObject  Player3;

    public GameObject  kamera;
    public GameObject  kamera1;
    public GameObject  kamera2;
    public GameObject  kamera3;

public GameObject Object;
    [SerializeField] private MeshRenderer rend;
    public Material materials;




     void Start()
    {
        Time.timeScale = 0.0f;
        Object.GetComponent<MeshRenderer>().material = materials;

      
    }

    public void ReplayGame () 
    {
        PlayingPanel.SetActive(true);
        SceneManager.LoadScene("Roll_İT");
    }

    public void Quit () 
    {
        Application.Quit();    
    }

    public void StartButton()
     {

         PlayingPanel.SetActive(true);
         Time.timeScale = 1.0f;
         StartingPanel.SetActive(false);
         
        
     }

     public void MarketButton()
     {
        MarketPanel.SetActive(true);
        PlayingPanel.SetActive(false);
        StartingPanel.SetActive(false);
     }

     public void Ates()
     {
        MarketPanel.SetActive(false);
        PlayingPanel.SetActive(true);
        Player.SetActive(true);
        Time.timeScale = 1.0f;
  
     }

     public void Su()
     {
        MarketPanel.SetActive(false);
        PlayingPanel.SetActive(true);
        kamera1.SetActive(true);
        kamera.SetActive(false);
        Player.SetActive(false);
        Player1.SetActive(true);
        Time.timeScale = 1.0f;

     }

     public void Toprak()
     {
        MarketPanel.SetActive(false);
        PlayingPanel.SetActive(true);
        kamera2.SetActive(true);
        kamera.SetActive(false);
           Player.SetActive(false);
        Player2.SetActive(true);
        Time.timeScale = 1.0f;

     }

     public void Tahta()
     {
        MarketPanel.SetActive(false);
        PlayingPanel.SetActive(true);
        kamera3.SetActive(true);
        kamera.SetActive(false);
           Player.SetActive(false);
        Player3.SetActive(true);
        Time.timeScale = 1.0f;

     }

     
}
