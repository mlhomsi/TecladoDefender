using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject gameOver, winScreen;
    public static Manager instance;

    void Awake(){
        if(instance == null) instance = this;
    }

    public void GameOver(){
        gameOver.SetActive(true);
    }

    public void WinScreen(){
        winScreen.SetActive(true);
    }
}
