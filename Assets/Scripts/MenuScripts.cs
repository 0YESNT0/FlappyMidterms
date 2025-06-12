using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject Notification;
    public static Action Reset;
    void Start()
    {
        BirbScript.Dead += GameOver; 
        BirbScript.Start += HideNotification;  
    }
    public void StartGame(){
        MainMenu.SetActive(false);
    }

    private void GameOver()
    {
        GameOverMenu.SetActive(true);
    }
    public void ResetGame()
    {
        Reset?.Invoke();
        GameOverMenu.SetActive(false);
        Notification.SetActive(true);        
    }

    private void HideNotification(){
        Notification.SetActive(false);
    }
}
