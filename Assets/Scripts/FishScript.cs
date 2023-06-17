using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public BarraDeVida barraDeVida;
    public int Pescado;
    public AudioClip Sound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();

        
         
        if (player != null)
        {
            barraDeVida = FindObjectOfType<BarraDeVida>();
            if (barraDeVida.vidaActual <= (100-Pescado))
            {
                 player.Health += Pescado;

                 barraDeVida = FindObjectOfType<BarraDeVida>();
                 Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
                 barraDeVida.vidaActual += Pescado;
                 barraDeVida.Update();

                 Destroy(gameObject);
            }
            else{
                barraDeVida.vidaActual = 100;
                barraDeVida.Update();
                Destroy(gameObject);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
            }
        }

    }
}
