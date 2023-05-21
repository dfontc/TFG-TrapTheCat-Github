using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGame : MonoBehaviour
{
    public void Back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    public void Home(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
}

