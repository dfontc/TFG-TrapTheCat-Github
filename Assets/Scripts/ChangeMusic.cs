using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{

    public AudioSource desert;


    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
            desert.Play();
        }

    }
}
