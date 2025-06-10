using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject GameOverMenu;
    public static Action Reset;
    void Start()
    {
        BirbScript.Dead += GameOver;   
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
        GameOverMenu.SetActive(false);
        Reset?.Invoke();
    }
}
