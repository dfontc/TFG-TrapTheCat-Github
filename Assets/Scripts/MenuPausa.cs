using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //[SerializeField] private GameObject botonPausa;

    public GameObject botonPausa;
    public GameObject BackButton;
    public GameObject RestartButton;
    public GameObject HomeButton;

    //[SerializeField] private GameObject menuPausa;

    public GameObject menuPausa;

    public void Pausa()
    {
        Time.timeScale = 0f;

        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        BackButton.SetActive(true);
        RestartButton.SetActive(true);
        HomeButton.SetActive(true);

        /*AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }*/
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;

        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        BackButton.SetActive(false);
        RestartButton.SetActive(false);
        HomeButton.SetActive(false);

        /*AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }*/


    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    /*
    public void Reanudar()
    {
        Time.timeScale = 1f;

        botonPausa = SetActive(true);

        menuPausa.SetActive(false);
    }*/

}

