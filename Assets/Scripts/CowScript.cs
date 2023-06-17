using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    public BarraDeVida barraDeVida;
    public GameObject CowMilk;
    public int Cow;
    public bool isPowerUp;
    public GameObject canvasTimer;
    public AudioClip Sound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();

        if (player != null)
        {
            isPowerUp = true;
            canvasTimer.SetActive(true);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
            barraDeVida = FindObjectOfType<BarraDeVida>();
            if (barraDeVida.vidaActual <= (100-Cow))
            {
                 player.Health += Cow;

                 barraDeVida = FindObjectOfType<BarraDeVida>();

                 barraDeVida.vidaActual += Cow;
                 barraDeVida.Update();

                 Destroy(gameObject);
            }
            else{
                barraDeVida.vidaActual = 100;
                barraDeVida.Update();
                Destroy(gameObject);
            }

        }

    }
}
