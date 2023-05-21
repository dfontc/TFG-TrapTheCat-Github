using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionInferior : MonoBehaviour
{
        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
            EnemyScriptExtreme enemyExtreme = collision.collider.GetComponent<EnemyScriptExtreme>();
            if (player != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
            if (enemyExtreme != null){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
            }
        }
}
