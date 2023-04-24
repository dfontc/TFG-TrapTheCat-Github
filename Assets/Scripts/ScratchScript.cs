using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }
    
    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }
    

    public void DestroyScratch(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Debug.Log("Entro al triggerenter2d");

        EnemyScript enemy = other.GetComponent<EnemyScript>();
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        Debug.Log("Enemy: " + enemy);
        Debug.Log("Player: " + player);
        if (enemy != null)
        {
            enemy.Hit();
        }
        if (player != null)
        {
            player.Hit();
        }
        DestroyScratch();*/
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
        EnemyScriptEasy enemyEasy = collision.collider.GetComponent<EnemyScriptEasy>();
        EnemyScriptMedium enemyMedium = collision.collider.GetComponent<EnemyScriptMedium>();
        EnemyScriptHard enemyHard = collision.collider.GetComponent<EnemyScriptHard>();
        EnemyScriptExtreme enemyExtreme = collision.collider.GetComponent<EnemyScriptExtreme>();

        if (player != null)
        {
            player.Hit();
        }

        if (enemyEasy != null)
        {
            enemyEasy.Hit();
        }
         if (enemyMedium != null)
        {
            enemyMedium.Hit();
        }
        
         if (enemyHard != null)
        {
            enemyHard.Hit();
        }

        if (enemyExtreme != null)
        {
            enemyExtreme.Hit();
        }
        
        
        DestroyScratch();
    }
}
