using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptMedium : MonoBehaviour
{
    public GameObject Player;
    public GameObject ScratchPrefab;
    
    public int Health;
    private float LastScratch;

    // Update is called once per frame
    private void Update()
    {
        //if (Player ==  null) return;

        Vector3 direction = Player.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        
        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < 0.8f && Time.time > LastScratch + 2f)
        {
            Scratch();
            LastScratch = Time.time;
        }
    }

    private void Scratch()
    {
        /*
        Vector3 direction;
        if (transform.localScale.x == -1.0f) direction = Vector3.left;
        else direction = Vector3.right;


        GameObject scratch = Instantiate(ScratchPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        scratch.GetComponent<ScratchScript>().SetDirection(direction);
        */
        Vector3 direction;
        if (transform.localScale.x == -1.0f) direction = Vector3.left;
        else direction = Vector3.right;


        GameObject scratch = Instantiate(ScratchPrefab, transform.position + direction * 0.3f, Quaternion.identity);
        scratch.GetComponent<ScratchScript>().SetDirection(direction);
    }

    public void Hit()
    {
        //Debug.Log("Health Enemy: " + Health);
        Health -= 1;
        
        if (Health == 0)  Destroy(gameObject);
    }
}
