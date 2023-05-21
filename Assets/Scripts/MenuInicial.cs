using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Exit(){
        Application.Quit();
    }
    public void MenuGameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
    public void MenuYouWin(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
    }
}

