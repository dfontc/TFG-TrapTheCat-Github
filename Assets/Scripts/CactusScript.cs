using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{


    private Rigidbody2D Rigidbody2D;
  

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.Hit();
        }

    }
}
